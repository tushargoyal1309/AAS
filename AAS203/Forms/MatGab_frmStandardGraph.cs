using AAS203.Common;
using AAS203Library.Method;

public class frmStandardGraph : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmStandardGraph()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call

	}

	public frmStandardGraph(bool blnIsSampleGraph, bool blnIsAnalysisMode, ref clsMethod objclsMethod, int intSelectedRunNumber)
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
		mblnIsSampleGraph = blnIsSampleGraph;
		mblnIsAnalysisMode = blnIsAnalysisMode;
		mobjclsMethod = objclsMethod;
		mintSelectedRunNumber = intSelectedRunNumber;

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
	internal NETXP.Controls.XPButton btnOk;
	internal GradientPanel.CustomPanel CustomPanelMain;
	internal GradientPanel.CustomPanel CustomPanelTop;
	internal GradientPanel.CustomPanel CustomPanelBottom;
	internal System.Windows.Forms.GroupBox gbCalculationMode;
	internal System.Windows.Forms.RadioButton rbDirect;
	internal System.Windows.Forms.RadioButton rbLinear;
	internal System.Windows.Forms.RadioButton rbRatioMethod;
	internal System.Windows.Forms.RadioButton rbQuadratic;
	internal System.Windows.Forms.RadioButton rbCubic;
	internal System.Windows.Forms.RadioButton rb4thOrder;
	internal System.Windows.Forms.RadioButton rb5thOrder;
	internal System.Windows.Forms.TextBox txtCalcProcess;
	internal System.Windows.Forms.Label lblCalcDescription;
	internal AAS203.AASGraph Graph;
	internal NETXP.Controls.XPButton btnPrint;
	internal NETXP.Controls.XPButton cmdChangeScale;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmStandardGraph));
		this.CustomPanelMain = new GradientPanel.CustomPanel();
		this.CustomPanelTop = new GradientPanel.CustomPanel();
		this.Graph = new AAS203.AASGraph();
		this.CustomPanelBottom = new GradientPanel.CustomPanel();
		this.cmdChangeScale = new NETXP.Controls.XPButton();
		this.btnPrint = new NETXP.Controls.XPButton();
		this.btnOk = new NETXP.Controls.XPButton();
		this.lblCalcDescription = new System.Windows.Forms.Label();
		this.txtCalcProcess = new System.Windows.Forms.TextBox();
		this.gbCalculationMode = new System.Windows.Forms.GroupBox();
		this.rb5thOrder = new System.Windows.Forms.RadioButton();
		this.rb4thOrder = new System.Windows.Forms.RadioButton();
		this.rbCubic = new System.Windows.Forms.RadioButton();
		this.rbQuadratic = new System.Windows.Forms.RadioButton();
		this.rbRatioMethod = new System.Windows.Forms.RadioButton();
		this.rbLinear = new System.Windows.Forms.RadioButton();
		this.rbDirect = new System.Windows.Forms.RadioButton();
		this.CustomPanelMain.SuspendLayout();
		this.CustomPanelTop.SuspendLayout();
		this.CustomPanelBottom.SuspendLayout();
		this.gbCalculationMode.SuspendLayout();
		this.SuspendLayout();
		//
		//CustomPanelMain
		//
		this.CustomPanelMain.BackColor = System.Drawing.Color.DeepSkyBlue;
		this.CustomPanelMain.Controls.Add(this.CustomPanelTop);
		this.CustomPanelMain.Controls.Add(this.CustomPanelBottom);
		this.CustomPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanelMain.Location = new System.Drawing.Point(0, 0);
		this.CustomPanelMain.Name = "CustomPanelMain";
		this.CustomPanelMain.Size = new System.Drawing.Size(498, 415);
		this.CustomPanelMain.TabIndex = 0;
		//
		//CustomPanelTop
		//
		this.CustomPanelTop.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanelTop.Controls.Add(this.Graph);
		this.CustomPanelTop.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanelTop.Location = new System.Drawing.Point(0, 0);
		this.CustomPanelTop.Name = "CustomPanelTop";
		this.CustomPanelTop.Size = new System.Drawing.Size(498, 247);
		this.CustomPanelTop.TabIndex = 0;
		//
		//Graph
		//
		this.Graph.AldysGraphCursor = System.Windows.Forms.Cursors.Hand;
		this.Graph.AldysGraphPrintColor = System.Drawing.Color.Black;
		this.Graph.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right;
		this.Graph.BackColor = System.Drawing.Color.LightGray;
		this.Graph.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Graph.GraphDataSource = null;
		this.Graph.GraphImage = null;
		this.Graph.IsShowGrid = true;
		this.Graph.Location = new System.Drawing.Point(4, 5);
		this.Graph.Name = "Graph";
		this.Graph.Size = new System.Drawing.Size(492, 235);
		this.Graph.TabIndex = 1;
		this.Graph.UseDefaultSettings = false;
		this.Graph.XAxisDateMax = new System.DateTime((long)0);
		this.Graph.XAxisDateMin = new System.DateTime((long)0);
		this.Graph.XAxisDateScaleFormat = AAS203.AASGraph.enumDateScaleFormat.YYYY;
		this.Graph.XAxisLabel = "CONCENTRATION";
		this.Graph.XAxisMax = 100;
		this.Graph.XAxisMin = 0;
		this.Graph.XAxisMinorStep = 2;
		this.Graph.XAxisScaleFormat = null;
		this.Graph.XAxisStep = 10;
		this.Graph.XAxisType = AldysGraph.AxisType.Linear;
		this.Graph.YAxisLabel = "ABSORBANCE";
		this.Graph.YAxisMax = 100;
		this.Graph.YAxisMin = 0;
		this.Graph.YAxisMinorStep = 2;
		this.Graph.YAxisScaleFormat = null;
		this.Graph.YAxisStep = 10;
		this.Graph.YAxisType = AldysGraph.AxisType.Linear;
		//
		//CustomPanelBottom
		//
		this.CustomPanelBottom.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanelBottom.Controls.Add(this.cmdChangeScale);
		this.CustomPanelBottom.Controls.Add(this.btnPrint);
		this.CustomPanelBottom.Controls.Add(this.btnOk);
		this.CustomPanelBottom.Controls.Add(this.lblCalcDescription);
		this.CustomPanelBottom.Controls.Add(this.txtCalcProcess);
		this.CustomPanelBottom.Controls.Add(this.gbCalculationMode);
		this.CustomPanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.CustomPanelBottom.Location = new System.Drawing.Point(0, 247);
		this.CustomPanelBottom.Name = "CustomPanelBottom";
		this.CustomPanelBottom.Size = new System.Drawing.Size(498, 168);
		this.CustomPanelBottom.TabIndex = 1;
		//
		//cmdChangeScale
		//
		this.cmdChangeScale.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.cmdChangeScale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cmdChangeScale.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.cmdChangeScale.Image = (System.Drawing.Image)resources.GetObject("cmdChangeScale.Image");
		this.cmdChangeScale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.cmdChangeScale.Location = new System.Drawing.Point(408, 32);
		this.cmdChangeScale.Name = "cmdChangeScale";
		this.cmdChangeScale.Size = new System.Drawing.Size(80, 34);
		this.cmdChangeScale.TabIndex = 3;
		this.cmdChangeScale.Text = "Change Scale";
		this.cmdChangeScale.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnPrint
		//
		this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnPrint.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnPrint.Image = (System.Drawing.Image)resources.GetObject("btnPrint.Image");
		this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnPrint.Location = new System.Drawing.Point(408, 126);
		this.btnPrint.Name = "btnPrint";
		this.btnPrint.Size = new System.Drawing.Size(80, 34);
		this.btnPrint.TabIndex = 2;
		this.btnPrint.Text = "&Print";
		//
		//btnOk
		//
		this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOk.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnOk.Image = (System.Drawing.Image)resources.GetObject("btnOk.Image");
		this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOk.Location = new System.Drawing.Point(408, 79);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(80, 34);
		this.btnOk.TabIndex = 1;
		this.btnOk.Text = "OK";
		//
		//lblCalcDescription
		//
		this.lblCalcDescription.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblCalcDescription.Location = new System.Drawing.Point(215, 80);
		this.lblCalcDescription.Name = "lblCalcDescription";
		this.lblCalcDescription.Size = new System.Drawing.Size(193, 80);
		this.lblCalcDescription.TabIndex = 2;
		//
		//txtCalcProcess
		//
		this.txtCalcProcess.BackColor = System.Drawing.Color.White;
		this.txtCalcProcess.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtCalcProcess.Location = new System.Drawing.Point(8, 80);
		this.txtCalcProcess.Multiline = true;
		this.txtCalcProcess.Name = "txtCalcProcess";
		this.txtCalcProcess.ReadOnly = true;
		this.txtCalcProcess.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtCalcProcess.Size = new System.Drawing.Size(200, 80);
		this.txtCalcProcess.TabIndex = 1;
		this.txtCalcProcess.Text = "";
		//
		//gbCalculationMode
		//
		this.gbCalculationMode.BackColor = System.Drawing.Color.AliceBlue;
		this.gbCalculationMode.Controls.Add(this.rb5thOrder);
		this.gbCalculationMode.Controls.Add(this.rb4thOrder);
		this.gbCalculationMode.Controls.Add(this.rbCubic);
		this.gbCalculationMode.Controls.Add(this.rbQuadratic);
		this.gbCalculationMode.Controls.Add(this.rbRatioMethod);
		this.gbCalculationMode.Controls.Add(this.rbLinear);
		this.gbCalculationMode.Controls.Add(this.rbDirect);
		this.gbCalculationMode.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.gbCalculationMode.Location = new System.Drawing.Point(8, 8);
		this.gbCalculationMode.Name = "gbCalculationMode";
		this.gbCalculationMode.Size = new System.Drawing.Size(392, 64);
		this.gbCalculationMode.TabIndex = 0;
		this.gbCalculationMode.TabStop = false;
		this.gbCalculationMode.Text = "Calculation Mode";
		//
		//rb5thOrder
		//
		this.rb5thOrder.Location = new System.Drawing.Point(280, 40);
		this.rb5thOrder.Name = "rb5thOrder";
		this.rb5thOrder.Size = new System.Drawing.Size(70, 16);
		this.rb5thOrder.TabIndex = 6;
		this.rb5thOrder.Text = "5th Order";
		//
		//rb4thOrder
		//
		this.rb4thOrder.Location = new System.Drawing.Point(192, 40);
		this.rb4thOrder.Name = "rb4thOrder";
		this.rb4thOrder.Size = new System.Drawing.Size(80, 16);
		this.rb4thOrder.TabIndex = 5;
		this.rb4thOrder.Text = "4th Order";
		//
		//rbCubic
		//
		this.rbCubic.Location = new System.Drawing.Point(88, 40);
		this.rbCubic.Name = "rbCubic";
		this.rbCubic.Size = new System.Drawing.Size(56, 16);
		this.rbCubic.TabIndex = 4;
		this.rbCubic.Text = "Cubic";
		//
		//rbQuadratic
		//
		this.rbQuadratic.Location = new System.Drawing.Point(8, 40);
		this.rbQuadratic.Name = "rbQuadratic";
		this.rbQuadratic.Size = new System.Drawing.Size(80, 16);
		this.rbQuadratic.TabIndex = 3;
		this.rbQuadratic.Text = "Quadratic";
		//
		//rbRatioMethod
		//
		this.rbRatioMethod.Location = new System.Drawing.Point(88, 16);
		this.rbRatioMethod.Name = "rbRatioMethod";
		this.rbRatioMethod.Size = new System.Drawing.Size(96, 16);
		this.rbRatioMethod.TabIndex = 2;
		this.rbRatioMethod.Text = "Ratio Method";
		//
		//rbLinear
		//
		this.rbLinear.Location = new System.Drawing.Point(192, 16);
		this.rbLinear.Name = "rbLinear";
		this.rbLinear.Size = new System.Drawing.Size(64, 16);
		this.rbLinear.TabIndex = 1;
		this.rbLinear.Text = "Linear";
		//
		//rbDirect
		//
		this.rbDirect.Location = new System.Drawing.Point(8, 16);
		this.rbDirect.Name = "rbDirect";
		this.rbDirect.Size = new System.Drawing.Size(80, 16);
		this.rbDirect.TabIndex = 0;
		this.rbDirect.Text = "Direct";
		//
		//frmStandardGraph
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(498, 415);
		this.Controls.Add(this.CustomPanelMain);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmStandardGraph";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.CustomPanelMain.ResumeLayout(false);
		this.CustomPanelTop.ResumeLayout(false);
		this.CustomPanelBottom.ResumeLayout(false);
		this.gbCalculationMode.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Private Class Member Variables "

	private bool mblnIsSampleGraph;
	private Spectrum.EnergySpectrumParameter mobjParameters = new Spectrum.EnergySpectrumParameter();
	private clsQuantitativeData.enumCalculationMode mintCalculationMode;
	private bool Init = false;
	private bool disp = false;
	private int mintRunNumberIndex;

	private bool mblnIsEmmissionMode;
	private AldysGraph.CurveItem mobjStdSampleCurve;
	private AldysGraph.CurveItem mobjScatteredPointsCurve;

	private bool mblnIsAnalysisMode;
	public clsMethod mobjclsMethod = new clsMethod();

	private int mintSelectedRunNumber;
	private clsDataFileReport mobjClsDataFileReport = new clsDataFileReport();
	private int mintSelectedMethodID = 0;
		#End Region
	private AAS203.AASGraph.PointAddRemoveHandler GrpEvn;

	#Region " Private Constants"

	private const  ConstFormDataFilesStd = "-DataFiles-StandardGraph";
	private const  ConstFormDataFilesSam = "-DataFiles-SampleGraph";
	private const  ConstParentFormLoadDataFiles = "-DataFiles";
	private const  ConstFormAnalysisStd = "-Analysis-StandardGraph";
	private const  ConstFormAnalysisSam = "-Analysis-SampleGraph";

	private const  ConstParentFormLoadAnalysis = "-Analysis";
	#End Region

	#Region " Private Properties "

	#End Region

	#Region " Form Load and Event Handling Functions "

	private void  // ERROR: Handles clauses are not supported in C#
frmStandardGraph_Load(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmStandardGraph_Load
		// Parameters Passed     : object, eventArgs
		// Returns               : None
		// Purpose               : To show the Standard  Graph
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================


		//--- ORIGINAL CODE

		//case	WM_INITDIALOG :
		//   Init=FALSE;
		//   Init_Calculation_Mode(hwnd, &Method->QuantData->cMode);
		//	lMode= Method->QuantData->cMode;
		//#If !STD_ADDN Then
		//	    if (!IsStdCurve())
		//#End If
		//	CalcStdCurve(hwnd);
		//   If (!IsStdCurve()) Then
		//	    PostMessage(hwnd, WM_COMMAND, IDOK,0L);
		//   Else
		//	{
		//	    CalcSampValues();
		//		Change_Calculation_Mode(hwnd, &lMode);
		//		InCurs=FALSE;
		//		ps.hdc=NULL;
		//		if (curs==NULL)
		//		    curs =  	(HCURSOR) LoadCursor(hInst,"hand");
		//       If (oldcurs! = NULL) Then
		//		    SetCursor(oldcurs);
		//		Create_Curve(hwnd, &CurveData);
		//			hfont = Change_Button_font(hwnd, hfont, TRUE, FALSE);
		//       If (hfont) Then
		//		    SendDlgItemMessage(hwnd, IDC_EQN, WM_SETFONT,(WPARAM) hfont, 0L);
		//		SendDlgItemMessage(hwnd, IDC_THINT, WM_SETFONT,(WPARAM) hfont, 0L);
		//		InvalidateRect(hwnd, NULL, TRUE);
		//	}
		//	Init=TRUE;
		//	if(Autosampler && Started )
		//	    SendMessage(hwnd,WM_COMMAND,IDOK,0L);
		//	return TRUE;

		CWaitCursor objWaitCursor = new CWaitCursor();
		// Init Form object

		try {
			// Set the title and messages into the form
			if (!mblnIsSampleGraph) {
				this.Text = "QUANTITATIVE ANALYSIS - STANDARD WORKING GRAPH";
				if (mblnIsAnalysisMode == false) {
					gobjMain.ShowProgressBar(gstrTitleInstrumentType + ConstFormDataFilesStd);
				} else {
					gobjMain.ShowProgressBar(gstrTitleInstrumentType + ConstFormAnalysisStd);
				}
			} else {
				this.Text = "QUANTITATIVE ANALYSIS - SAMPLE WORKING GRAPH";
				if (mblnIsAnalysisMode == false) {
					gobjMain.ShowProgressBar(gstrTitleInstrumentType + ConstFormDataFilesSam);
				} else {
					gobjMain.ShowProgressBar(gstrTitleInstrumentType + ConstFormAnalysisSam);
				}
			}

			Init = false;
			//// Check for selected Run No or for last record of Methos object analysis in process 
			if (mblnIsAnalysisMode) {
				if (mobjclsMethod.QuantitativeDataCollection.Count > 0) {
					mintRunNumberIndex = gobjNewMethod.QuantitativeDataCollection.Count - 1;
				} else {
					mintRunNumberIndex = 0;
				}
			} else {
				//---For Data Files Mode
				mintRunNumberIndex = gfuncGetSelectedMethodRunNumberIndex(mobjclsMethod.MethodID, mintSelectedRunNumber);
			}

			//// Init the appropriate Calculation mode 
			Init_Calculation_Mode(mobjclsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).CalculationMode);
			mintCalculationMode = mobjclsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).CalculationMode;

			//#If !STD_ADDN Then
			//   if (!IsStdCurve())
			//#End If

			//// Calculate the Standard Curve
			CalcStdCurve();

			if (!gobjclsStandardGraph.IsStdCurve()) {
				//PostMessage(hwnd, WM_COMMAND, IDOK,0L)
				btnOk_Click(btnOk, EventArgs.Empty);
			} else {
				// Calculate the sample values
				gobjclsStandardGraph.CalcSampValues(mobjclsMethod.StandardAddition);
				// set the calculated default calculation mode to the graph and data result
				Change_Calculation_Mode(mintCalculationMode);
				objWaitCursor.Dispose();
				objWaitCursor = new CWaitCursor();
				// Create the curve to the graph
				Create_Curve();
				// display the curve to the graph
				Display_Curve();
			}

			Init = true;

			//Set the handler to the this form object
			subAddHandlers();

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
			gobjMain.HideProgressBar();
			//---------------------------------------------------------
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
frmStandardGraph_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmStandardGraph_Closing
		// Parameters Passed     : object, eventArgs
		// Returns               : None
		// Purpose               : This is called when user close the form.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : praveen
		//=====================================================================
		if (mblnIsAnalysisMode == false) {
			gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType + ConstParentFormLoadDataFiles);
		} else {
			gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType + ConstParentFormLoadAnalysis);
		}
	}

	private void btnOk_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnOk_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : This will handle a OK button Click event.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 31-Jan-2007 04:10 pm
		// Revisions             : praveen
		//=====================================================================
		try {
			this.DialogResult = DialogResult.OK;
		//Me.Close()
		//Me.Dispose()

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

	//Private Sub subSetCalculationMode(ByVal sender As Object, ByVal e As EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : subSetCalculationMode
	//    ' Parameters Passed     : Object, EventArgs
	//    ' Returns               : None
	//    ' Purpose               : 
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Mangesh Shardul
	//    ' Created               : 31-Jan-2007 03:25 pm
	//    ' Revisions             : 1
	//    '=====================================================================
	//    Try
	//        If rbDirect.Checked = True Then
	//            mintCalculationMode = clsQuantitativeData.enumCalculationMode.DIRECT
	//            Call Change_Calculation_Mode(mintCalculationMode)

	//        ElseIf rbRatioMethod.Checked = True Then
	//            mintCalculationMode = clsQuantitativeData.enumCalculationMode.RATIONAL
	//            Call Change_Calculation_Mode(mintCalculationMode)

	//        ElseIf rbLinear.Checked = True Then
	//            mintCalculationMode = clsQuantitativeData.enumCalculationMode.LINEAR
	//            Call Change_Calculation_Mode(mintCalculationMode)

	//        ElseIf rbQuadratic.Checked = True Then
	//            mintCalculationMode = clsQuantitativeData.enumCalculationMode.QUADRATIC
	//            Call Change_Calculation_Mode(mintCalculationMode)

	//        ElseIf rbCubic.Checked = True Then
	//            mintCalculationMode = clsQuantitativeData.enumCalculationMode.CUBIC
	//            Call Change_Calculation_Mode(mintCalculationMode)

	//        ElseIf rb4thOrder.Checked = True Then
	//            mintCalculationMode = clsQuantitativeData.enumCalculationMode.FOURTH_ORDER
	//            Call Change_Calculation_Mode(mintCalculationMode)

	//        ElseIf rb5thOrder.Checked = True Then
	//            mintCalculationMode = clsQuantitativeData.enumCalculationMode.FIFTH_ORDER
	//            Call Change_Calculation_Mode(mintCalculationMode)

	//        End If

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
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	private void rbDirect_CheckedChanged(object sender, EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : rbDirect_CheckedChanged
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : Set the Redio button for Direct Mode
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 31-Jan-2007 03:25 pm
		// Revisions             : praveen
		//=====================================================================
		try {
			// Check redio button for if Direct mode is select for calculation mode
			if (rbDirect.Checked == true) {
				Change_Calculation_Mode(clsQuantitativeData.enumCalculationMode.DIRECT);
				//lblCalcDescription.Text = ""
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

	private void rbRatioMethod_CheckedChanged(object sender, EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : rbRatioMethod_CheckedChanged
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : for handle a changed event.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 31-Jan-2007 03:25 pm
		// Revisions             : praveen
		//=====================================================================
		try {
			// Check redio button for if Ratio (RATIONAL) mode is select for calculation mode function
			if (rbRatioMethod.Checked == true) {
				Change_Calculation_Mode(clsQuantitativeData.enumCalculationMode.RATIONAL);
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

	private void rbLinear_CheckedChanged(object sender, EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : rbLinear_CheckedChanged
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               :  ' Check redio button for if Linear mode is select for calculation mode function
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 31-Jan-2007 03:25 pm
		// Revisions             : praveen
		//=====================================================================
		try {
			// Check redio button for if Linear mode is select for calculation mode function
			if (rbLinear.Checked == true) {
				Change_Calculation_Mode(clsQuantitativeData.enumCalculationMode.LINEAR);
				//'To change and apply new Mode of Calculation
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

	private void rbQuadratic_CheckedChanged(object sender, EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : rbQuadratic_CheckedChanged
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : ' Check redio button for if Quadratic mode is select for calculation mode function
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 31-Jan-2007 03:25 pm
		// Revisions             : praveen
		//=====================================================================
		try {
			// Check redio button for if Quadratic mode is select for calculation mode function
			if (rbQuadratic.Checked == true) {
				Change_Calculation_Mode(clsQuantitativeData.enumCalculationMode.QUADRATIC);
				//'To change and apply new Mode of Calculation
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

	private void rbCubic_CheckedChanged(object sender, EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : rbCubic_CheckedChanged
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : ' Check redio button for if Cubic mode is selectd for calculation mode function
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 31-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		try {
			// Check redio button for if Cubic mode is selectd for calculation mode function
			if (rbCubic.Checked == true) {
				Change_Calculation_Mode(clsQuantitativeData.enumCalculationMode.CUBIC);
				//'To change and apply new Mode of Calculation
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

	private void rb4thOrder_CheckedChanged(object sender, EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : rb4thOrder_CheckedChanged
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : ' Check redio button for if Forth Order mode is selected for calculation mode function
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 31-Jan-2007 03:25 pm
		// Revisions             : praveen
		//=====================================================================
		try {
			// Check redio button for if Forth Order mode is selected for calculation mode function
			if (rb4thOrder.Checked == true) {
				Change_Calculation_Mode(clsQuantitativeData.enumCalculationMode.FOURTH_ORDER);
				//'To change and apply new Mode of Calculation
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

	private void rb5thOrder_CheckedChanged(object sender, EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : rb5thOrder_CheckedChanged
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : ' Check redio button for if Fifth Order mode is select for calculation mode function
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 31-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		try {
			// Check redio button for if Fifth Order mode is select for calculation mode function
			if (rb5thOrder.Checked == true) {
				Change_Calculation_Mode(clsQuantitativeData.enumCalculationMode.FIFTH_ORDER);
				///'To change and apply new Mode of Calculation
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

	private void AASGraph_AddRemovePoint(bool IsAddPoint, AldysGraph.Point pointInfo)
	{
		//=====================================================================
		// Procedure Name        : AASGraph_AddRemovePoint
		// Parameters Passed     : Boolean Flag to enable or disable point, PointInfo
		// Returns               : None
		// Purpose               : this is use to Add or Remove selected Std/Samp
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 01-Mar-2007 04:45 pm
		// Revisions             : 1
		//=====================================================================
		int intCounter;
		double dblConcValue;
		double dblAbsValue;
		//'for counter 

		try {
			//this is use to Add or Remove selected Std/Samp
			// Check whther point to insert or remove from graph for poltting graph
			if (IsAddPoint) {
				//---Enable Standard
				for (intCounter = 0; intCounter <= mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).StandardDataCollection.Count - 1; intCounter++) {
					//If mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).StandardDataCollection.item(intCounter).Concentration = CDbl(FormatNumber(pointInfo.X)) Then  '09.05.08
					dblConcValue = mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).StandardDataCollection.item(intCounter).Concentration;
					dblAbsValue = mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).StandardDataCollection.item(intCounter).Abs;
					if ((Math.Abs(pointInfo.X - dblConcValue) <= Graph.CONST_dblXpointTolerance) & (Math.Abs(pointInfo.X - dblConcValue) >= 0.0) & (Math.Abs(pointInfo.Y - dblAbsValue) <= Graph.CONST_dblYpointTolerance) & (Math.Abs(pointInfo.Y - dblAbsValue) >= 0.0)) {
						mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).StandardDataCollection.item(intCounter).Used = true;
						//Exit For
					}
				}
			} else {
				//---Disable Standard

				for (intCounter = 0; intCounter <= mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).StandardDataCollection.Count - 1; intCounter++) {
					dblConcValue = mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).StandardDataCollection.item(intCounter).Concentration;
					dblAbsValue = mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).StandardDataCollection.item(intCounter).Abs;

					//If mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).StandardDataCollection.item(intCounter).Concentration = CDbl(FormatNumber(pointInfo.X, 2)) Then '09.05.08
					if ((Math.Abs(pointInfo.X - dblConcValue) <= Graph.CONST_dblXpointTolerance) & (Math.Abs(pointInfo.X - dblConcValue) >= 0.0) & (Math.Abs(pointInfo.Y - dblAbsValue) <= Graph.CONST_dblYpointTolerance) & (Math.Abs(pointInfo.Y - dblAbsValue) >= 0.0)) {
						mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).StandardDataCollection.item(intCounter).Used = false;
						//Exit For
					}
				}
				//If Not (mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).SampleDataCollection Is Nothing) Then
				//    For intCounter = 0 To mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).SampleDataCollection.Count - 1
				//        If CSng(gobjclsStandardGraph.Get_Conc(mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).SampleDataCollection.item(intCounter).Abs, 0.0)) = CDbl(FormatNumber(pointInfo.X)) Then  '09.05.08
				//            'mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).SampleDataCollection.item(intCounter).Used = False
				//            Exit For
				//        End If
				//    Next
				//End If
			}

			//calculate mode for get result
			Change_Calculation_Mode(mintCalculationMode);

			Init_Calculation_Mode(mobjclsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).CalculationMode);
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

	private void btnPrint_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnPrint_Click
		// Parameters Passed     :  
		// Returns               : None
		// Purpose               : this is called when user clicked on print button.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 01-Mar-2007 04:45 pm
		// Revisions             : 1
		//=====================================================================
		subPrintGraph();
		//'function for printing a graph.
	}

	private void  // ERROR: Handles clauses are not supported in C#
cmdChangeScale_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : cmdChangeScale_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : calculte change scale
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Pankaj Bamb
		// Created               : 1.05.07
		// Revisions             : praveen
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		frmChangeScale objfrmChangeScale;


		try {
			objfrmChangeScale = new frmChangeScale(mobjParameters, false);
			//'initialise the object
			objfrmChangeScale.funcSetValidatingScale(gobjInst.Mode);
			//'set a validation as per mode.
			objfrmChangeScale.lblXAxis.Visible = false;

			objfrmChangeScale.SpectrumParameter.XaxisMin = Graph.XAxisMin;
			objfrmChangeScale.SpectrumParameter.XaxisMax = Graph.XAxisMax;

			objfrmChangeScale.SpectrumParameter.YaxisMin = Graph.YAxisMin;
			objfrmChangeScale.SpectrumParameter.YaxisMax = Graph.YAxisMax;
			//------------------------
			if (objfrmChangeScale.ShowDialog() == DialogResult.OK) {
				//'show the dialog.
				if (!objfrmChangeScale.SpectrumParameter == null) {
					//'set a current scale to mobjParameters object.
					mobjParameters.XaxisMax = objfrmChangeScale.SpectrumParameter.XaxisMax;
					mobjParameters.XaxisMin = objfrmChangeScale.SpectrumParameter.XaxisMin;
					mobjParameters.YaxisMax = objfrmChangeScale.SpectrumParameter.YaxisMax;
					mobjParameters.YaxisMin = objfrmChangeScale.SpectrumParameter.YaxisMin;
				}
				Graph.XAxisMin = mobjParameters.XaxisMin;
				Graph.XAxisMax = mobjParameters.XaxisMax;
				Graph.YAxisMin = mobjParameters.YaxisMin;
				Graph.YAxisMax = mobjParameters.YaxisMax;

				gobjClsAAS203.Calculate_Analysis_Graph_Param(Graph, ClsAAS203.enumChangeAxis.xyAxis);
				//'for calculate a graph parameter
			}
			objfrmChangeScale.Close();
		//'close


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
			objfrmChangeScale.Dispose();
			if (!objWait == null) {
				objWait.Dispose();
			}
			//mblnAvoidProcessing = False
			//---------------------------------------------------------
		}
	}

	#End Region

	#Region " Private Functions "

	private void subAddHandlers()
	{
		//=====================================================================
		// Procedure Name        : subAddHandlers
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : initialize handler to controls
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 31-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		//'note:
		//'this is called during a initialisation
		//'this is used for adding a event to a control
		try {
			btnOk.Click += btnOk_Click;
			Graph.AddRemovePoint += AASGraph_AddRemovePoint;

			rbDirect.CheckedChanged += rbDirect_CheckedChanged;
			rbRatioMethod.CheckedChanged += rbRatioMethod_CheckedChanged;
			rbLinear.CheckedChanged += rbLinear_CheckedChanged;
			rbQuadratic.CheckedChanged += rbQuadratic_CheckedChanged;
			rbCubic.CheckedChanged += rbCubic_CheckedChanged;
			rb4thOrder.CheckedChanged += rb4thOrder_CheckedChanged;
			rb5thOrder.CheckedChanged += rb5thOrder_CheckedChanged;
			btnPrint.Click += btnPrint_Click;

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

	private void Init_Calculation_Mode(ref clsQuantitativeData.enumCalculationMode intCalculationMode)
	{
		//=====================================================================
		// Procedure Name        : Init_Calculation_Mode
		// Parameters Passed     : Reference to Calculation Mode
		// Returns               : None
		// Purpose               : Init. decide default calculation mode 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1 praveencheck
		//=====================================================================


		//--- ORIGINAL CODE

		//void Init_Calculation_Mode(HWND hwnd, int *mode)
		//{
		//   int	nstd;
		//   int	i, j;
		//   HWND	hwnd1;

		//   nstd = GetNoValidStdConcAbs(Method->QuantData->StdTopData);
		//   #If STD_ADDN Then
		//	    if(Method->QuantData->Param.Std_Addn)
		//		    nstd--;
		//   #Else
		//       #If !ZERO_PASSING Then
		//	        nstd--;
		//       #End If
		//   #End If
		//   #if STD_ADDN // added by sss on dt 25/09/2000 for std addn method
		//	    if(Method->QuantData->Param.Std_Addn){
		//		    for(i = IDC_RBDIRECT; i<=IDC_RB5; i++){
		//		        j = i-IDC_RBDIRECT-1;
		//		        hwnd1 =  GetDlgItem(hwnd, i);
		//		        if (j==1){
		//			        if (!IsWindowEnabled(hwnd1))
		//				        EnableWindow(hwnd1, TRUE);
		//		        }
		//		        else
		//				    EnableWindow(hwnd1, FALSE);
		//           }
		//	    }
		//	    else{
		//		    for(i = IDC_RBDIRECT; i<=IDC_RB5; i++){
		//		        j = i-IDC_RBDIRECT-1;
		//		        hwnd1 =  GetDlgItem(hwnd, i);
		//		        if (j>nstd)
		//			        EnableWindow(hwnd1, FALSE);
		//		        else
		//			        if (!IsWindowEnabled(hwnd1))
		//				        EnableWindow(hwnd1, TRUE);
		//	        }
		//	    }
		//   #Else
		//	    for(i = IDC_RBDIRECT; i<=IDC_RB5; i++){
		//	        j = i-IDC_RBDIRECT-1;
		//	        hwnd1 =  GetDlgItem(hwnd, i);
		//           If (j > nstd) Then
		//		        EnableWindow(hwnd1, FALSE);
		//           Else
		//               If (!IsWindowEnabled(hwnd1)) Then
		//			        EnableWindow(hwnd1, TRUE);
		//       }
		//   #End If

		//   /*if (nstd<=2){
		//	    *mode = 2;
		//       If (nstd < 2) Then
		//	        *mode = 1;
		//	    CheckRadioButton(hwnd, IDC_RBDIRECT, IDC_RBDIRECT+FIFTH_ORDER+1, IDC_RBDIRECT+*mode+1);
		//       If (nstd < 2) Then
		//	        EnableWindow(GetDlgItem(hwnd, IDC_RBDIRECT+1), FALSE);
		//   }*/
		//   if (nstd<2){
		//	    *mode = 1;
		//	    CheckRadioButton(hwnd, IDC_RBDIRECT, IDC_RBDIRECT+FIFTH_ORDER+1,IDC_RBDIRECT+*mode+1);
		//	    EnableWindow(GetDlgItem(hwnd, IDC_RBDIRECT+1), FALSE);
		//   }
		//   if (*mode>nstd)
		//	    *mode = nstd;
		//   CheckRadioButton(hwnd, IDC_RBDIRECT, IDC_RBDIRECT+FIFTH_ORDER+1,IDC_RBDIRECT+*mode+1);
		//   SetStdCurveHint(hwnd, IDC_RBDIRECT+*mode+1);
		//}

		int nstd;
		int i;
		int j;

		try {
			// Find the total no of valid standards
			nstd = gobjclsStandardGraph.GetNoValidStdConcAbs(mobjclsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection);

			//#If STD_ADDN Then
			if ((mobjclsMethod.StandardAddition)) {
				//'check for std add
				if ((mobjclsMethod.StandardAddition)) {
					nstd -= 1;
				}
			//#Else
			} else {
				if (!gobjclsStandardGraph.ZERO_PASSING) {
					nstd -= 1;
				}
			}
			//#End If
			//'do some validation 
			rbDirect.Enabled = false;
			rbRatioMethod.Enabled = false;
			rbLinear.Enabled = false;
			rbQuadratic.Enabled = false;
			rbCubic.Enabled = false;
			rb4thOrder.Enabled = false;
			rb5thOrder.Enabled = false;

			//#if STD_ADDN 
			//enable radio button according to calculation mode
			if ((mobjclsMethod.StandardAddition)) {
				for (i = clsQuantitativeData.enumCalculationMode.DIRECT; i <= clsQuantitativeData.enumCalculationMode.FIFTH_ORDER; i++) {
					j = i - clsQuantitativeData.enumCalculationMode.DIRECT - 1;
					switch (i) {
						case clsQuantitativeData.enumCalculationMode.DIRECT:
							if (j == 1) {
								if (rbDirect.Enabled == false)
									rbDirect.Enabled = true;
							} else {
								rbDirect.Enabled = false;

							}
						case clsQuantitativeData.enumCalculationMode.RATIONAL:
							if (j == 1) {
								if (rbRatioMethod.Enabled == false)
									rbRatioMethod.Enabled = true;
							} else {
								rbRatioMethod.Enabled = false;

							}
						case clsQuantitativeData.enumCalculationMode.LINEAR:
							if (j == 1) {
								if (rbLinear.Enabled == false)
									rbLinear.Enabled = true;
							} else {
								rbLinear.Enabled = false;

							}
						case clsQuantitativeData.enumCalculationMode.QUADRATIC:
							if (j == 1) {
								if (rbQuadratic.Enabled == false)
									rbQuadratic.Enabled = true;
							} else {
								rbQuadratic.Enabled = false;

							}
						case clsQuantitativeData.enumCalculationMode.CUBIC:
							if (j == 1) {
								if (rbCubic.Enabled == false)
									rbCubic.Enabled = true;
							} else {
								rbCubic.Enabled = false;

							}
						case clsQuantitativeData.enumCalculationMode.FOURTH_ORDER:
							if (j == 1) {
								if (rb4thOrder.Enabled == false)
									rb4thOrder.Enabled = true;
							} else {
								rb4thOrder.Enabled = false;

							}
						case clsQuantitativeData.enumCalculationMode.FIFTH_ORDER:
							if (j == 1) {
								if (rb5thOrder.Enabled == false)
									rb5thOrder.Enabled = true;
							} else {
								rb5thOrder.Enabled = false;

							}
					}
				}

			} else {
				for (i = clsQuantitativeData.enumCalculationMode.DIRECT; i <= clsQuantitativeData.enumCalculationMode.FIFTH_ORDER; i++) {
					j = i - clsQuantitativeData.enumCalculationMode.DIRECT - 1;
					switch (i) {
						case clsQuantitativeData.enumCalculationMode.DIRECT:
							if ((j > nstd)) {
								rbDirect.Enabled = false;
							} else {
								if (rbDirect.Enabled == false)
									rbDirect.Enabled = true;

							}
						case clsQuantitativeData.enumCalculationMode.RATIONAL:
							if ((j > nstd)) {
								rbRatioMethod.Enabled = false;
							} else {
								if (rbRatioMethod.Enabled == false)
									rbRatioMethod.Enabled = true;

							}
						case clsQuantitativeData.enumCalculationMode.LINEAR:
							if ((j > nstd)) {
								rbLinear.Enabled = false;
							} else {
								if (rbLinear.Enabled == false)
									rbLinear.Enabled = true;

							}
						case clsQuantitativeData.enumCalculationMode.QUADRATIC:
							if ((j > nstd)) {
								rbQuadratic.Enabled = false;
							} else {
								if (rbQuadratic.Enabled == false)
									rbQuadratic.Enabled = true;

							}
						case clsQuantitativeData.enumCalculationMode.CUBIC:
							if ((j > nstd)) {
								rbCubic.Enabled = false;
							} else {
								if (rbCubic.Enabled == false)
									rbCubic.Enabled = true;

							}
						case clsQuantitativeData.enumCalculationMode.FOURTH_ORDER:
							if ((j > nstd)) {
								rb4thOrder.Enabled = false;
							} else {
								if (rb4thOrder.Enabled == false)
									rb4thOrder.Enabled = true;

							}
						case clsQuantitativeData.enumCalculationMode.FIFTH_ORDER:
							if ((j > nstd)) {
								rb5thOrder.Enabled = false;
							} else {
								if (rb5thOrder.Enabled == false)
									rb5thOrder.Enabled = true;
							}
					}
				}
			}

			//#Else
			//For i = IDC_RBDIRECT To IDC_RB5
			//    j = i - IDC_RBDIRECT - 1
			//    hwnd1 = GetDlgItem(hwnd, i)
			//    If (j > nstd) Then
			//        EnableWindow(hwnd1, False)
			//    Else
			//        If Not (IsWindowEnabled(hwnd1)) Then
			//            EnableWindow(hwnd1, True)
			//        End If
			//    End If
			//Next i
			//#End If

			if ((nstd < 2)) {
				intCalculationMode = clsQuantitativeData.enumCalculationMode.LINEAR;
				rbLinear.Checked = true;
				rbRatioMethod.Enabled = false;
			}

			if ((intCalculationMode > nstd)) {
				intCalculationMode = nstd;
			}

			//CheckRadioButton(hwnd, IDC_RBDIRECT, IDC_RBDIRECT + FIFTH_ORDER + 1, IDC_RBDIRECT + intCalculationMode + 1)
			i = clsQuantitativeData.enumCalculationMode.DIRECT + intCalculationMode + 1;
			//check check bok true according to calculation mode
			switch (i) {
				case clsQuantitativeData.enumCalculationMode.DIRECT:

					rbDirect.Checked = true;
				case clsQuantitativeData.enumCalculationMode.RATIONAL:

					rbRatioMethod.Checked = true;
				case clsQuantitativeData.enumCalculationMode.LINEAR:

					rbLinear.Checked = true;
				case clsQuantitativeData.enumCalculationMode.QUADRATIC:

					rbQuadratic.Checked = true;
				case clsQuantitativeData.enumCalculationMode.CUBIC:

					rbCubic.Checked = true;
				case clsQuantitativeData.enumCalculationMode.FOURTH_ORDER:

					rb4thOrder.Checked = true;
				case clsQuantitativeData.enumCalculationMode.FIFTH_ORDER:

					rb5thOrder.Checked = true;
			}

			SetStdCurveHint(clsQuantitativeData.enumCalculationMode.DIRECT + intCalculationMode + 1);

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

	private void SetStdCurveHint(clsQuantitativeData.enumCalculationMode intCalculationMode)
	{
		//=====================================================================
		// Procedure Name        : SetStdCurveHint
		// Parameters Passed     : Calculation Mode
		// Returns               : None
		// Purpose               : for setting a std curve hint as per a calculation mode.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		//void	SetStdCurveHint(HWND hwnd, int id)
		//{
		//	char	str[100]="";
		//	if(Method->Mode == MODE_EMISSION )
		//	{
		//            Switch(id)
		//		{
		//			case  IDC_RBDIRECT :
		//				strcpy(str," Sample caln on bracketd stds");
		//				break;

		//			case  IDC_RBRAT :
		//#If STD_ADDN Then
		//					strcpy(str," RATIO Method :\n EMN/CONC=A+B*EMN+C*EMN^2");
		//#Else
		//					strcpy(str," RATIO Method : plot emn/conc against emn");
		//#End If
		//				break;

		//			case  IDC_RBLINEAR : strcpy(str," LINEAR graph :\nCONC=A+B*EMN ");break;
		//			case  IDC_RBQUAD:		strcpy(str," QUADRATIC curve :\nCONC=A+B*EMN+C*EMN^2");break;
		//			case  IDC_RBCUBIC	 :	strcpy(str," CUBIC curve :\n CONC=A+B*EMN+C*EMN^2+D*EMN^3");break;
		//			case  IDC_RB4	 :		strcpy(str," 4th order Polynomial fit :\nCONC=A+B*EMN+C*EMN^2+D*EMN^3+E*EMN^4");break;
		//			case  IDC_RB5		 :	strcpy(str," 5th order polynomial fit :\nCONC=A+B*EMN+C*EMN^2+D*EMN^3+E*EMN^4+F*EMN^5");break;
		//		}
		//	}
		//        Else
		//	{
		//            Switch(id)
		//		{
		//			case  IDC_RBDIRECT : strcpy(str," Sample caln on bracketd stds");break;
		//			case  IDC_RBRAT :
		//#If STD_ADDN Then
		//					strcpy(str," RATIO Method :\n ABS/CONC=A+B*ABS+C*ABS^2");
		//#Else
		//					strcpy(str," RATIO Method : plot abs/conc against abs");
		//#End If
		//				break;
		//		case  IDC_RBLINEAR :	strcpy(str," LINEAR graph :\nCONC=A+B*ABS ");break;
		//		case  IDC_RBQUAD:		strcpy(str," QUADRATIC curve :\nCONC=A+B*ABS+C*ABS^2");break;
		//		case  IDC_RBCUBIC	 :	strcpy(str," CUBIC curve :\n CONC=A+B*ABS+C*ABS^2+D*ABS^3");break;
		//		case  IDC_RB4	 :		strcpy(str," 4th order Polynomial fit :\nCONC=A+B*ABS+C*ABS^2+D*ABS^3+E*ABS^4");break;
		//		case  IDC_RB5		 :	strcpy(str," 5th order polynomial fit :\nCONC=A+B*ABS+C*ABS^2+D*ABS^3+E*ABS^4+F*ABS^5");break;
		//	  }
		//  }
		//  SetDlgItemText(hwnd, IDC_THINT, str);
		//}

		string strCalcDescription;

		try {
			if ((mobjclsMethod.OperationMode == EnumOperationMode.MODE_EMMISSION)) {
				//'for emission mode
				//set discription according to calculation mode
				switch (intCalculationMode) {
					//check for a calculation mode.
					case clsQuantitativeData.enumCalculationMode.DIRECT:

						strCalcDescription = " Sample calculation on bracketd stds ";
					case clsQuantitativeData.enumCalculationMode.RATIONAL:
						//If mobjclsMethod.StandardAddition Then
						//    strCalcDescription = " RATIO Method :" & vbCrLf & "EMN/CONC=A+B*EMN+C*EMN^2"
						//Else
						//    strCalcDescription = " RATIO Method : plot emn/conc against emn"
						//End If
						////----- Added by Sachin Dokhale 
						////---- Practically display it's worong
						if (gblnSTD_ADDN == true) {
							strCalcDescription = " RATIO Method :" + vbCrLf + "EMN/CONC=A+B*EMN+C*EMN^2";
						} else {
							strCalcDescription = " RATIO Method : plot emn/conc against emn";
						}
					////-----

					case clsQuantitativeData.enumCalculationMode.LINEAR:

						strCalcDescription = " LINEAR graph :" + vbCrLf + "CONC=A+B*EMN ";
					case clsQuantitativeData.enumCalculationMode.QUADRATIC:

						strCalcDescription = " QUADRATIC curve :" + vbCrLf + "CONC=A+B*EMN+C*EMN^2";
					case clsQuantitativeData.enumCalculationMode.CUBIC:

						strCalcDescription = " CUBIC curve :" + vbCrLf + " CONC=A+B*EMN+C*EMN^2+D*EMN^3";
					case clsQuantitativeData.enumCalculationMode.FOURTH_ORDER:

						strCalcDescription = " 4th order Polynomial fit :" + vbCrLf + "CONC=A+B*EMN+C*EMN^2+D*EMN^3+E*EMN^4";
					case clsQuantitativeData.enumCalculationMode.FIFTH_ORDER:

						strCalcDescription = " 5th order polynomial fit :" + vbCrLf + "CONC=A+B*EMN+C*EMN^2+D*EMN^3+E*EMN^4+F*EMN^5";
				}
			} else {
				switch (intCalculationMode) {
					case clsQuantitativeData.enumCalculationMode.DIRECT:

						strCalcDescription = " Sample calculation on bracketd stds ";
					case clsQuantitativeData.enumCalculationMode.RATIONAL:

						//If mobjclsMethod.StandardAddition Then
						//    strCalcDescription = " RATIO Method :" & vbCrLf & " ABS/CONC=A+B*ABS+C*ABS^2"
						//Else
						//    strCalcDescription = " RATIO Method : plot abs/conc against abs"
						//End If
						////----- Added by Sachin Dokhale '---- Practically display it's worong
						if (gblnSTD_ADDN == true) {
							strCalcDescription = " RATIO Method :" + vbCrLf + " ABS/CONC=A+B*ABS+C*ABS^2";
						} else {
							strCalcDescription = " RATIO Method : plot abs/conc against abs";
						}
					////-----

					case clsQuantitativeData.enumCalculationMode.LINEAR:

						strCalcDescription = " LINEAR graph :" + vbCrLf + " CONC=A+B*ABS ";
					case clsQuantitativeData.enumCalculationMode.QUADRATIC:

						strCalcDescription = " QUADRATIC curve :" + vbCrLf + " CONC=A+B*ABS+C*ABS^2";
					case clsQuantitativeData.enumCalculationMode.CUBIC:

						strCalcDescription = " CUBIC curve :" + vbCrLf + " CONC=A+B*ABS+C*ABS^2+D*ABS^3";
					case clsQuantitativeData.enumCalculationMode.FOURTH_ORDER:

						strCalcDescription = " 4th order Polynomial fit :" + vbCrLf + " CONC=A+B*ABS+C*ABS^2+D*ABS^3+E*ABS^4";
					case clsQuantitativeData.enumCalculationMode.FIFTH_ORDER:

						strCalcDescription = " 5th order polynomial fit :" + vbCrLf + " CONC=A+B*ABS+C*ABS^2+D*ABS^3+E*ABS^4+F*ABS^5";
				}
			}

			lblCalcDescription.Text = strCalcDescription;

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

	private void Create_Curve()
	{
		//=====================================================================
		// Procedure Name        : Create_Curve
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : for crearing a curve
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 18-Jan-2007 12:35 pm
		// Revisions             : 1
		//=====================================================================


		//---- ORIGINAL CODE

		//void	Create_Curve(HWND hwnd, CURVEDATA	*Curve)
		//{
		//	double	xmax;
		//	HWND	hwd;
		//	HDC		hdc;
		//	RECT 	R;
		//	RECT 	r;
		//	int		ww; 
		//	POINT	pt1, pt2;

		//	#define	FROMLEFT    7
		//	#define	FROMTOP		0.5
		//	#define	HTRATIO		0.6

		//	if (ht==-1 && wd==-1)
		//	{
		//		hdc= GetDC(hwnd);
		//		Para_Font(hdc, TRUE, TRUE, &ht, &wd);
		//		ReleaseDC(hwnd, hdc);
		//	}

		//	GetClientRect(hwnd, &R);

		//	r.left=FROMLEFT*wd;
		//	r.right= R.right;
		//	r.right-= (FROMLEFT/2)*wd;
		//	r.top=R.top+FROMTOP*ht;
		//	r.bottom =r.top+ (R.bottom-R.top)*HTRATIO; 	//((R.bottom-R.top)-9*ht);

		//	ww = (r.bottom-r.top)*0.2;

		//	xmax=-1;
		//	Curve->RC=r;

		//	Calculate_Curve_Param(Curve);

		//	xmax= (int) Curve->Xmax;

		//	pt1.x = r.left;
		//	pt1.y = r.bottom+2*ht;
		//	pt2.x = r.right-wd; 
		//	pt2.y = pt1.y; 

		//#If STD_ADDN Then
		//		if(Method->QuantData->Param.Std_Addn)
		//			SetWindowText(hwnd, "STANDARD ADDITION [QUANTITATIVE Analysis- STANDARD WORKING GRAPH]");
		//		else
		//#End If
		//	SetWindowText(hwnd, "QUANTITATIVE Analysis - STANDARD WORKING GRAPH");

		//	hwd=CreateWindow("SCROLLBAR","",WS_CHILD|WS_VISIBLE | SBS_HORZ,
		//	pt1.x-ww/2, pt1.y, ww, 11, hwnd, IDC_HSCROL1, hInst,NULL);
		//	ShowScrollBar(hwd, SB_CTL, SW_SHOW);
		//	SetScrollRange(hwd, SB_CTL, 0, xmax,FALSE);
		//	SetScrollPos(hwd, SB_CTL, 0,  TRUE);

		//	hwd=CreateWindow("SCROLLBAR","",WS_CHILD|WS_VISIBLE | SBS_HORZ,
		//			pt2.x-ww/2, pt2.y, ww, 11, hwnd, IDC_HSCROL2,
		//			hInst,NULL);

		//	ShowScrollBar(hwd, SB_CTL, SW_SHOW);
		//	SetScrollRange(hwd, SB_CTL, 0, xmax,FALSE);
		//	SetScrollPos(hwd, SB_CTL, xmax,  TRUE);
		//	pt2.x = r.right+wd; //r.left;
		//	pt2.y = r.top-5;

		//	hwd=CreateWindow("SCROLLBAR","",WS_CHILD|WS_VISIBLE | SBS_VERT,
		//			pt2.x, pt2.y, 11, ww, hwnd, IDC_VSCROL1,
		//			hInst,NULL);

		//	ShowScrollBar(hwd, SB_CTL, SW_SHOW);
		//	SetScrollRange(hwd, SB_CTL, 0, Curve->Ymax,FALSE);
		//	SetScrollPos(hwd, SB_CTL, Curve->Ymax,  TRUE);
		//}

		double xmax;
		const object FROMLEFT = 7;
		const object FROMTOP = 0.5;
		const object HTRATIO = 0.6;

		try {
			//HWND	hwd;
			//HDC	hdc;
			//RECT 	R;
			//RECT 	r; 
			//int	ww;
			//POINT	pt1, pt2;

			//if (ht==-1 && wd==-1)
			//{
			//	hdc= GetDC(hwnd);
			//	Para_Font(hdc, TRUE, TRUE, &ht, &wd);
			//	ReleaseDC(hwnd, hdc);
			//}
			//GetClientRect(hwnd, &R);

			//r.left = FROMLEFT * wd;
			//r.right = R.right;
			//r.right -= (FROMLEFT/2) * wd;
			//r.top = R.top+FROMTOP * ht;
			//r.bottom = r.top + (R.bottom - R.top) * HTRATIO; 	
			//ww = (r.bottom-r.top) * 0.2;

			// Create curve on graph
			xmax = -1;

			Calculate_Curve_Param();
			//' cal. curve parameter
			xmax = Graph.XAxisMax;

			Graph.Invalidate();
			//'checking a validation.

			Graph.Refresh();
			//'refresh the graph.
			//pt1.x = r.left;
			//pt1.y = r.bottom + 2 * ht;
			//pt2.x = r.right - wd; 
			//pt2.y = pt1.y; 

			if ((mobjclsMethod.StandardAddition)) {
				//'check for std add
				this.Text = "STANDARD ADDITION [QUANTITATIVE Analysis- STANDARD WORKING GRAPH]";
			} else {
				// Me.Text = "QUANTITATIVE Analysis - STANDARD WORKING GRAPH"
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

	private void CalcStdCurve()
	{
		//=====================================================================
		// Procedure Name        : CalcStdCurve
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : Calculate the Std Curve and the show the std and sample value
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : praveen
		//=====================================================================


		//---- ORIGINAL CODE

		//void   CalcStdCurve(HWND hwnd)
		//{
		//  Calculate_Std_Curve();
		//  ShowStdSampValues(hwnd);
		//}

		try {
			// Calculate the Std Curve and the show the std and sample value
			gobjclsStandardGraph.Calculate_Std_Curve();
			ShowStdSampValues();

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

	private void ShowStdSampValues()
	{
		//=====================================================================
		// Procedure Name        : ShowStdSampValues
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : for showing a std,sample value on screen.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================


		//---- ORIGINAL CODE 

		//void   ShowStdSampValues(HWND hwnd)
		//{
		//	double	conc1=0.0; 
		//	char	str1[200]="";
		//	char	str[400]="";
		//	STDDATA	*tempk;

		//	Get_Equation(str1);
		//	strcat(str, str1);

		//#If STD_ADDN Then
		//		if(Method->QuantData->Param.Std_Addn)
		//		{
		//			if( Method->QuantData->SampTopData )
		//				sprintf(str1,"Sample Conc: %5.4f\r\n",	Get_percent(Method->QuantData->SampTopData->Data.Conc,
		//										Method->QuantData->SampTopData->Data.Weight,
		//										Method->QuantData->SampTopData->Data.Volume,
		//										Method->QuantData->SampTopData->Data.Dil_Fact,
		//										Method->QuantData->Param.Unit,
		//										Method->QuantData->Param.No_Decimals));

		//			strcat(str,str1);
		//		}
		//#End If

		//	conc1=Get_Conc(0.0, 0.0); //, Method->QuantData->Param.No_Decimals);
		//#If STD_ADDN Then
		//		if(!Method->QuantData->Param.Std_Addn)
		//		{
		//#End If
		//			sprintf(str1,"(%6.3f-0.000\r\n",conc1);
		//			strcat(str, str1);
		//#If STD_ADDN Then
		//		}
		//#End If
		//	tempk = Method->QuantData->StdTopData;
		//   While (tempk)
		//	{
		//		strcpy(str1,"");
		//		conc1=Get_Conc(tempk->Data.Abs, conc1);
		//		//, Method->QuantData->Param.No_Decimals);
		//		sprintf(str1,"(%6.3f-%5.4f\r\n",conc1,tempk->Data.Abs);
		//		strcat(str, str1);
		//		tempk=tempk->next;
		//	}
		//	SetDlgItemText(hwnd, IDC_EQN, str);
		//}

		double conc1;
		string strEquation;
		int intCounter;
		string strTemp;

		try {
			// Get the equation into the string to display it.
			Get_Equation(strEquation);

			//#If STD_ADDN Then
			//   if(mobjclsMethod.StandardAddition)
			//	{
			//	    if( Method->QuantData->SampTopData )
			//		    sprintf(str1,"Sample Conc: %5.4f\r\n",	Get_percent(Method->QuantData->SampTopData->Data.Conc,
			//										Method->QuantData->SampTopData->Data.Weight,
			//										Method->QuantData->SampTopData->Data.Volume,
			//										Method->QuantData->SampTopData->Data.Dil_Fact,
			//										Method->QuantData->Param.Unit,
			//										Method->QuantData->Param.No_Decimals));

			//		    strcat(str,str1);
			//	}
			//#End If
			// To get the concentration for 1st standard
			conc1 = gobjclsStandardGraph.Get_Conc(0.0, 0.0);
			////--- Added by Sachin Dokhale
			strTemp = "";
			strTemp += "(";
			strTemp += Format(conc1, "0.000");
			//strTemp &= "  -  0.000)"
			strTemp += "  -  " + Format(gobjclsStandardGraph.Get_Abs(conc1), "0.000") + ")";
			strTemp += vbCrLf;
			strEquation += strTemp;
			////---

			//#If STD_ADDN Then
			//if(!Method->QuantData->Param.Std_Addn)
			//{
			//#End If
			//	sprintf(str1,"(%6.3f-0.000\r\n",conc1);
			//   strcat(str, str1);
			//#If STD_ADDN Then
			//}
			//#End If

			for (intCounter = 0; intCounter <= mobjclsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count - 1; intCounter++) {
				strTemp = "";
				conc1 = gobjclsStandardGraph.Get_Conc(mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).StandardDataCollection.item(intCounter).Abs, conc1);
				strTemp += "(";
				strTemp += Format(conc1, "0.000");
				strTemp += "  -  ";
				strTemp += Format(mobjclsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCounter).Abs, "0.000");
				strTemp += ")";
				strTemp += vbCrLf;
				strEquation += strTemp;
			}

			txtCalcProcess.Text = strEquation;

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

	private clsQuantitativeData.enumCalculationMode funcGetSelectedCalculationMode()
	{
		//=====================================================================
		// Procedure Name        : funcGetSelectedCalculationMode
		// Parameters Passed     : None
		// Returns               : User Selected Mode Calculation
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 31-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		//'note:
		//'this is used for getting a selected calculation mode.
		try {
			// Set the selected calculation mode

			if (rbDirect.Checked == true) {
				return clsQuantitativeData.enumCalculationMode.DIRECT;

			} else if (rbRatioMethod.Checked == true) {
				return clsQuantitativeData.enumCalculationMode.RATIONAL;

			} else if (rbLinear.Checked == true) {
				return clsQuantitativeData.enumCalculationMode.LINEAR;

			} else if (rbQuadratic.Checked == true) {
				return clsQuantitativeData.enumCalculationMode.QUADRATIC;

			} else if (rbCubic.Checked == true) {
				return clsQuantitativeData.enumCalculationMode.CUBIC;

			} else if (rb4thOrder.Checked == true) {
				return clsQuantitativeData.enumCalculationMode.FOURTH_ORDER;

			} else if (rb5thOrder.Checked == true) {
				return clsQuantitativeData.enumCalculationMode.FIFTH_ORDER;

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

	private void Change_Calculation_Mode(clsQuantitativeData.enumCalculationMode intCalculationMode)
	{
		//=====================================================================
		// Procedure Name        : Change_Calculation_Mode
		// Parameters Passed     : New Calculation Mode 
		// Returns               : None
		// Purpose               : To change and apply new Mode of Calculation
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 18-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================


		//---- ORIGINAL CODE

		//void   Change_Calculation_Mode(HWND hwnd, int *lMode)
		//{
		//	int mode;
		//	mode=  GetIndexOfRBSelection(hwnd, DIRECT+1, FIFTH_ORDER+1, IDC_RBDIRECT);
		//   If (mode! = -1) Then
		//	{
		//		mode--;
		//		if (mode!=*lMode)
		//		{
		//			Method->QuantData->cMode=mode;
		//			*lMode=mode;
		//			CalcStdCurve(hwnd);
		//			InvalidateRect(hwnd, NULL, TRUE);
		//		}
		//       Else
		//		    ShowStdSampValues(hwnd);
		//	}
		//}

		clsQuantitativeData.enumCalculationMode intMode;

		try {
			// Get the selected calculation mode
			intMode = funcGetSelectedCalculationMode();
			// Check selected cal. mode is not DIRECT Mode
			if ((intMode != clsQuantitativeData.enumCalculationMode.DIRECT)) {
				// set the Cal mode value to the method object
				mobjclsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).CalculationMode = intMode;

				intCalculationMode = intMode;
				mintCalculationMode = intCalculationMode;

				SetStdCurveHint(intCalculationMode);
				//'for setting a std curve hint as per a calculation mode.
				CalcStdCurve();
				//'Calculate the Std Curve and the show the std and sample value
				Graph.AldysPane.CurveList.Clear();
				Graph.AldysPane.AxisChange();
				Graph.Invalidate();
				Create_Curve();
				//'for creating a curve
				Display_Curve();
				//'Display curve on graph
				Refresh();
				Application.DoEvents();
			} else if ((intMode == clsQuantitativeData.enumCalculationMode.DIRECT)) {
				mobjclsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).CalculationMode = intMode;
				intCalculationMode = intMode;
				mintCalculationMode = intCalculationMode;
				SetStdCurveHint(intCalculationMode);
				CalcStdCurve();
				Graph.AldysPane.CurveList.Clear();
				Graph.AldysPane.AxisChange();
				Graph.Invalidate();
				//'check for validation.
				Create_Curve();
				Display_Curve();
				Refresh();
				Application.DoEvents();
			} else {
				ShowStdSampValues();
				//'for showing a std sample value on screen.
			}
			mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).CalculationMode = intMode;
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

	private void Display_Curve()
	{
		//=====================================================================
		// Procedure Name        : Display_Curve
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : Display curve on graph
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 04-Feb-2007 03:35 pm
		// Revisions             : 1
		//=====================================================================


		//----- ORIGINAL CODE

		//void Display_Curve(HDC hdc, CURVEDATA *Curve,  BOOL flag,BOOL scrflag,BOOL scr)
		//{
		//	HFONT	hfont;
		//	if (Curve==NULL)
		//		return;
		//	SetBkMode(hdc, TRANSPARENT);
		//	hfont = Para_Font(hdc, FALSE, scr, &ht, &wd);
		//	Rect(hdc, Curve->Xmin, Curve->Ymax, Curve->Xmax, Curve->Ymin, Curve->RC, Curve, wd, ht, scrflag);
		//	Display_Curve_Yaxis(hdc, Curve->RC, wd, ht, Curve);
		//	if (Method->Mode==MODE_EMISSION)
		//		Display_Curve_Yaxis_Divns(hdc,  Curve, "EMISSION", scrflag);
		//            Else
		//		Display_Curve_Yaxis_Divns(hdc,  Curve, "ABSORBANCE", scrflag);
		//	Display_Chart_Xaxis(hdc, Curve,  wd, ht, flag,"Concentration",scrflag);
		//	Disp_Standards(hdc, Curve, Method->QuantData->StdTopData, scrflag);
		//#If STD_ADDN Then
		//	if (SampCurve)
		//	{
		//		Disp_Samples(hdc, Curve, Method->QuantData->SampTopData, scrflag);
		//	}
		//#Else
		//   If (SampCurve) Then
		//	   Disp_Samples(hdc, Curve, Method->QuantData->SampTopData, scrflag);
		//#End If
		//	if (flag && !scrflag)
		//		Display_Legend(hdc,Curve->RC);
		//	DeleteObject(hfont);
		//}

		try {
			if (IsNothing(Graph)) {
				return;
			}

			//SetBkMode(hdc, TRANSPARENT);
			//hfont = Para_Font(hdc, FALSE, scr, &ht, &wd);
			//Rect(hdc, Curve->Xmin, Curve->Ymax, Curve->Xmax, Curve->Ymin, Curve->RC, Curve, wd, ht, scrflag);
			//Display_Curve_Yaxis(hdc, Curve->RC, wd, ht, Curve);
			//Display_Curve_Yaxis()

			if ((mobjclsMethod.OperationMode == EnumOperationMode.MODE_EMMISSION)) {
				//'check for emission mode
				Graph.YAxisLabel = "EMISSION";
				mblnIsEmmissionMode = true;
			} else {
				Graph.YAxisLabel = "ABSORBANCE";
				mblnIsEmmissionMode = false;
			}

			//---'---added on 26.07.09 with ref ramesh/vck
			int intUnit = 0;
			string strconc = "";
			intUnit = mobjclsMethod.AnalysisParameters.Unit;
			if (intUnit == enumUnit.PPM) {
				strconc = "CONCENTRATION  (ppm)";
			} else if (intUnit == enumUnit.Percent) {
				strconc = "CONCENTRATION  (ppm)";
				//---19.04.09
			} else if (intUnit == enumUnit.PPB) {
				strconc = "CONCENTRATION  (ppb)";
			}
			//------------

			Graph.XAxisLabel = strconc;
			//---added on 26.07.09 with ref ramesh/vck
			//Graph.XAxisLabel = "CONCENTRATION"  '---commented on 26.07.09 with ref ramesh/vck

			Disp_Standards(mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).StandardDataCollection);
			//'display Standard from standard collection object
			if (mobjclsMethod.StandardAddition) {
				if ((mblnIsSampleGraph)) {
					Disp_Samples(mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).SampleDataCollection);
					//'Display Sample details
				}
			} else {
				if ((mblnIsSampleGraph)) {
					Disp_Samples(mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).SampleDataCollection);
					//'Display Sample details
				}
			}

			Graph.AldysPane.Legend.IsVisible = false;
			Graph.IsShowGrid = true;
			Graph.AldysPane.AxisChange();
			Graph.Invalidate();
			Invalidate(true);

			Graph.ShowPointInfo(mobjScatteredPointsCurve);
		// Purpose               : To enable Point Info window to be displayed
		//                         at left click of mouse near point.
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

	private void Disp_Standards(clsAnalysisStdParametersCollection objStandardCollection)
	{
		//=====================================================================
		// Procedure Name        : Disp_Standards
		// Parameters Passed     : AASGraph reference, objStandard object
		// Returns               : None
		// Purpose               : display Standard from standard collection object
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 04-Feb-2007 03:45 pm
		// Revisions             : 1
		//=====================================================================


		//----- ORIGINAL CODE

		//void Disp_Standards(HDC hdc, CURVEDATA *Curve,STDDATA	*StdTop,BOOL scr)
		//{
		//	double	xmax=0.0;//, ymax=0.0;
		//	double   x1=0.0, y1=0.0; //, FrqIntv;
		//	HPEN		hpen, hold;
		//	BOOL		first;
		//	//int 		i;
		//	STDDATA	*temp;

		//	if (StdTop==NULL)
		//		return;
		//            If (scr) Then
		//		hpen =  (HPEN) CreatePen(PS_SOLID, 1, RGB(255, 255, 255));
		//            Else
		//	{
		//		hpen =  (HPEN) CreatePen(PS_SOLID, 1, RGB(0, 0, 0));
		//		SetTextColor(hdc, RGB(0, 0,0));
		//	}
		//	hold = SelectObject(hdc, hpen);
		//	first=TRUE;
		//	//i=0;
		//	x1=(double) 0.0;

		//	while(x1<=Curve->Xmax)
		//	{
		//#If QDEMO Then
		//		if (x1>4.0)
		//			y1=0;
		//#End If
		//		y1 =  Get_Abs(x1);
		//#If STD_ADDN Then
		//			if(y1 >= 0.0 )
		//			{
		//#End If
		//		if (x1>= Curve->Xmin && x1<= Curve->Xmax && y1>=Curve->Ymin && y1<= Curve->Ymax)
		//		{
		//                        If (first) Then
		//			{
		//				PlotInit(hdc, x1, y1, Curve->RC, Curve);
		//				first=FALSE;
		//			}
		//                        Else
		//				Plotg(hdc, x1, y1, Curve->RC, Curve);
		//		}
		//#If STD_ADDN Then
		//			}
		//#End If
		//		x1+= (double) ((Curve->Xmax-Curve->Xmin)/200.0) ;
		//	}
		//	//i=0;
		//	temp=StdTop;
		//	xmax=FindMaxStdConc(StdTop);
		//	//ymax=FindMaxStdAbs(StdTop);

		//                            While (temp)
		//	{
		//		y1 =  temp->Data.Abs;
		//		x1 = temp->Data.Conc;
		//		if (x1>= Curve->Xmin && x1<= Curve->Xmax)
		//		{
		//			if (!temp->Data.Used)
		//			MarkInValid(hdc, x1, y1, Curve->RC, ht,Curve, TRUE);
		//                                    Else
		//			{
		//				PlotCurveInit(hdc, x1, y1, Curve->RC, TRUE, Curve, scr, TRUE);
		//				/* ---following fn removed by sss for avoiding the display of std values on x & y axis dt 23/11/2000
		//					Display_Curve_XYaxis(hdc,  Curve->RC, Curve,
		//						x1, y1, RGB(255,0,0),  RGB(0,0,255),
		//							xmax, TRUE, scr);
		//					-------------------------------*/
		//			}
		//		}
		//		temp=temp->next;
		//	}
		//	SelectObject(hdc, hold);
		//	DeleteObject(hpen);
		//}

		double xmax = 0.0;
		double x1 = 0.0;
		double y1 = 0.0;
		bool first;
		int intCounter;

		try {
			if (IsNothing(objStandardCollection)) {
				return;
			}

			//If (scr) Then
			//   hpen =  (HPEN) CreatePen(PS_SOLID, 1, RGB(255, 255, 255));
			//Else
			//   hpen =  (HPEN) CreatePen(PS_SOLID, 1, RGB(0, 0, 0));
			//	SetTextColor(hdc, RGB(0, 0,0));
			//end if

			first = true;
			x1 = 0.0;
			////----- added by Sachin Dokhale
			if (mobjclsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).CalculationMode == clsQuantitativeData.enumCalculationMode.DIRECT) {
				//For intCounter = 0 To objStandardCollection.Count
				intCounter = 0;
				if ((first) & (objStandardCollection.Count > 0)) {
					//PlotInit(hdc, x1, y1, Curve->RC, Curve)
					y1 = 0;
					x1 = 0;
					mobjStdSampleCurve = Graph.StartOnlineGraph("Standards/Sample", Color.Black, AldysGraph.SymbolType.NoSymbol);
					Graph.PlotPoint(mobjStdSampleCurve, x1, y1);
					first = false;
				}

				while (intCounter < objStandardCollection.Count) {
					if (Graph.XAxisMax == Graph.XAxisMin) {
						break; // TODO: might not be correct. Was : Exit While
					}
					if (objStandardCollection.item(intCounter).Used == true) {
						y1 = objStandardCollection.item(intCounter).Abs;
						x1 = objStandardCollection.item(intCounter).Concentration;
						//If (x1 >= Graph.AldysPane.XAxis.Min And x1 <= Graph.AldysPane.XAxis.Max And y1 >= Graph.AldysPane.YAxis.Min And y1 <= Graph.AldysPane.YAxis.Max) Then

						//If (first) Then
						//PlotInit(hdc, x1, y1, Curve->RC, Curve)
						//y1 = 0
						//x1 = 0
						//mobjStdSampleCurve = Graph.StartOnlineGraph("Standards/Sample", Color.Black, AldysGraph.SymbolType.NoSymbol)
						//Graph.PlotPoint(mobjStdSampleCurve, x1, y1)
						//first = False
						//Else
						//Plotg(hdc, x1, y1, Curve->RC, Curve)
						Graph.PlotPoint(mobjStdSampleCurve, x1, y1);
						//End If
					}
					intCounter += 1;
				}
				if (first == false) {
					Graph.StopOnlineGraph(mobjStdSampleCurve);
				}
			////-----
			} else {
				while ((x1 <= Graph.XAxisMax)) {
					if (Graph.XAxisMax == Graph.XAxisMin) {
						break; // TODO: might not be correct. Was : Exit While
					}
					//If objStandardCollection.item(intCounter).Used = True Then

					if (gstructSettings.AppMode == EnumAppMode.DemoMode) {
						if ((x1 > 4.0)) {
							y1 = 0.0;
						}
					}

					y1 = gobjclsStandardGraph.Get_Abs(x1);

					if (mobjclsMethod.StandardAddition) {
						if ((y1 >= 0.0)) {
							if ((x1 >= Graph.AldysPane.XAxis.Min & x1 <= Graph.AldysPane.XAxis.Max & y1 >= Graph.AldysPane.YAxis.Min & y1 <= Graph.AldysPane.YAxis.Max)) {
								if ((first)) {
									//PlotInit(hdc, x1, y1, Curve->RC, Curve)
									mobjStdSampleCurve = Graph.StartOnlineGraph("Standards/Sample", Color.Black, AldysGraph.SymbolType.NoSymbol);
									first = false;
								} else {
									//Plotg(hdc, x1, y1, Curve->RC, Curve)
									Graph.PlotPoint(mobjStdSampleCurve, x1, y1);
								}
							}
						}
					} else {
						if ((x1 >= Graph.AldysPane.XAxis.Min & x1 <= Graph.AldysPane.XAxis.Max & y1 >= Graph.AldysPane.YAxis.Min & y1 <= Graph.AldysPane.YAxis.Max)) {
							if ((first)) {
								//PlotInit(hdc, x1, y1, Curve->RC, Curve)
								mobjStdSampleCurve = Graph.StartOnlineGraph("Standards/Sample", Color.Black, AldysGraph.SymbolType.NoSymbol);
								Graph.PlotPoint(mobjStdSampleCurve, x1, y1);
								first = false;
							} else {
								//Plotg(hdc, x1, y1, Curve->RC, Curve)
								if (gobjclsStandardGraph.mblnSaturation == false & gobjclsStandardGraph.Rational == true) {
									Graph.PlotPoint(mobjStdSampleCurve, x1, y1);
								} else if ((gobjclsStandardGraph.Rational == false)) {
									Graph.PlotPoint(mobjStdSampleCurve, x1, y1);
								}
							}
						}
					}
					//x1 += ((Graph.XAxisMax - Graph.XAxisMin) / 200.0)
					//x1 = Format(x1, "0.00000")

					//If mobjclsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).CalculationMode = clsQuantitativeData.enumCalculationMode.DIRECT Then
					//    'x1 += ((Graph.XAxisMax - Graph.XAxisMin) / xmax)
					//    'x1 = Format(x1, "0.00000")
					//    x1 = objStandardCollection.item(intCounter).Concentration
					//Else
					x1 += ((Graph.XAxisMax - Graph.XAxisMin) / 200.0);
					x1 = Format(x1, "0.00000");


				}
			}
			//If first = False Then
			//    Graph.StopOnlineGraph(mobjStdSampleCurve)
			//End If

			Graph.Refresh();
			Application.DoEvents();
			//'allow application to perfrom its panding work.
			xmax = clsStandardGraph.FindMaxStdConc(objStandardCollection);

			mobjScatteredPointsCurve = Graph.StartScatteredPointsCurve(AldysGraph.SymbolType.Circle);
			first = true;
			bool IsUse_btnRemove = true;
			int intStdSampeCount = 0;
			for (intCounter = 0; intCounter <= objStandardCollection.Count - 1; intCounter++) {
				if ((objStandardCollection.item(intCounter).Used) == true) {
					intStdSampeCount += 1;
				}
			}
			if (intStdSampeCount == 1) {
				IsUse_btnRemove = false;
			}
			for (intCounter = 0; intCounter <= objStandardCollection.Count - 1; intCounter++) {
				y1 = objStandardCollection.item(intCounter).Abs;
				x1 = objStandardCollection.item(intCounter).Concentration;

				if ((x1 >= Graph.AldysPane.XAxis.Min & x1 <= Graph.AldysPane.XAxis.Max)) {
					if ((objStandardCollection.item(intCounter).Used) == false) {
						//MarkInValid(hdc, x1, y1, Curve->RC, ht,Curve, TRUE);
						Graph.PlotScatteredPoints(mobjScatteredPointsCurve, true, objStandardCollection.item(intCounter), null, mblnIsEmmissionMode, IsUse_btnRemove);
					} else {
						//PlotCurveInit(hdc, x1, y1, Curve->RC, TRUE, Curve, scr, TRUE);
						Graph.PlotScatteredPoints(mobjScatteredPointsCurve, false, objStandardCollection.item(intCounter), null, mblnIsEmmissionMode, IsUse_btnRemove);
					}
				}

			}
			Graph.Refresh();
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
		}
	}

	private void Disp_Samples(clsAnalysisSampleParametersCollection objSampleCollection)
	{
		//=====================================================================
		// Procedure Name        : Disp_Samples
		// Parameters Passed     : AASGraph reference, Sample Data Collection
		// Returns               : None
		// Purpose               : Display Sample details
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 04-Feb-2007 04:20 pm
		// Revisions             : 1
		//=====================================================================


		//----- ORIGINAL CODE

		//void   Disp_Samples(HDC hdc, CURVEDATA *Curve,SAMPDATA *SampTop, BOOL scr)
		//{
		//double   x1, y1; //, FrqIntv;
		//HPEN		hpen, hold;
		//int 		i;
		//SAMPDATA	*temp;

		//if (SampTop==NULL)
		//   return;
		//If (scr) Then
		//   hpen =  (HPEN) CreatePen(PS_SOLID, 1, RGB(255, 255, 255));
		//else {
		//   hpen =  (HPEN) CreatePen(PS_SOLID, 1, RGB(0, 0, 0));
		//	SetTextColor(hdc, RGB(0, 0,0));
		//}
		//hold = SelectObject(hdc, hpen);
		//temp=SampTop;
		//i=0;
		//while(temp!=NULL){
		//   y1 =  temp->Data.Abs;
		//	x1 = temp->Data.Conc;
		//	if (x1 < Curve->Xmin || x1> Curve->Xmax ||
		//	    y1 < Curve->Ymin || y1 > Curve->Ymax || !temp->Data.Used){
		//	    y1 =  Curve->Ymin;
		//       //MarkInValid(hdc, x1, y1, Curve->RC, ht,Curve, FALSE);
		//	}
		//	else{
		//	    if (x1>= Curve->Xmin && x1<= Curve->Xmax &&
		//			y1>=Curve->Ymin && y1<= Curve->Ymax)
		//		    PlotCurveInit(hdc, x1, y1, Curve->RC, TRUE, Curve, scr, FALSE);
		//   }
		//	if (!scr){
		//	    if (x1>= Curve->Xmin && x1<= Curve->Xmax)
		//		     Printslno(hdc, temp, Curve->RC, i+1);
		//	}
		//	i++;
		//	temp=temp->next;
		//}
		//SelectObject(hdc, hold);
		//DeleteObject(hpen);
		//}

		double x1;
		double y1;
		int i;

		try {
			if (IsNothing(objSampleCollection)) {
				return;
			}

			//If (scr) Then
			//   hpen =  (HPEN) CreatePen(PS_SOLID, 1, RGB(255, 255, 255));
			//else 
			//{
			//   hpen =  (HPEN) CreatePen(PS_SOLID, 1, RGB(0, 0, 0));
			//   SetTextColor(hdc, RGB(0, 0,0));
			//}

			bool IsUse_btnRemove = false;

			i = 0;

			for (i = 0; i <= objSampleCollection.Count - 1; i++) {
				y1 = objSampleCollection.item(i).Abs;
				x1 = objSampleCollection.item(i).Conc;

				if ((x1 < Graph.AldysPane.XAxis.Min | x1 > Graph.AldysPane.XAxis.Max | y1 < Graph.AldysPane.YAxis.Min | y1 > Graph.AldysPane.YAxis.Max | !objSampleCollection.item(i).Used)) {
					y1 = Graph.YAxisMin;
				} else {
					if ((x1 >= Graph.AldysPane.XAxis.Min & x1 <= Graph.AldysPane.XAxis.Max & y1 >= Graph.AldysPane.YAxis.Min & y1 <= Graph.AldysPane.YAxis.Max)) {
						//PlotCurveInit(hdc, x1, y1, Curve->RC, TRUE, Curve, scr, FALSE);
						if ((objSampleCollection.item(i).Used)) {
							Graph.PlotScatteredPoints(mobjScatteredPointsCurve, false, null, objSampleCollection.item(i), mblnIsEmmissionMode, IsUse_btnRemove);
						}
					}
				}

				//if (!scr)
				//   if (x1>= Curve->Xmin && x1<= Curve->Xmax)
				//       Printslno(hdc, temp, Curve->RC, i+1)
				//   end if
				//end if
			}

			Graph.Refresh();
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
		}
	}

	private void Get_Equation(ref string eqn)
	{
		//=====================================================================
		// Procedure Name        : Get_Equation
		// Parameters Passed     : Reference of equation string 
		// Returns               : None
		// Purpose               : get the equation from given data
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 04-Feb-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================

		//---- ORIGINAL CODE

		//E4FUNC  void	S4FUNC  Get_Equation(char eqn[200])
		//{
		//	char	str[80]="";
		//	int	i;
		//	strcpy(eqn,"");
		//   If (!Curve_Status) Then
		//		return ;
		//	for(i=0; i<N; i++)
		//	{
		//		strcpy(str,"");
		//		if (i==0)
		//		{
		//			if (MatA[i]==(double) 0.0)
		//				sprintf(str,"0 ", MatA[i]);
		//                    Else
		//				sprintf(str,"%-5.4f ", MatA[i]);
		//		}
		//		else if (i==1)
		//		{
		//			if (MatA[i]>(double)0.0)
		//				sprintf(str,"+ %-5.4f*X ",MatA[i]);
		//			else if (MatA[i]<(double)0.0)
		//				sprintf(str,"- %5.4f*X ",fabs(MatA[i]));
		//                        Else
		//				sprintf(str,"%+ 0*X ",MatA[i]);
		//		}
		//		else
		//		{
		//			if (MatA[i]>(double)0.0)
		//				sprintf(str,"+ %-5.4f*X^%-1d ", MatA[i], i);
		//			else if (MatA[i]<(double)0.0)
		//				sprintf(str,"- %-5.4f*X^%-1d ", fabs(MatA[i]), i);
		//                            Else
		//				sprintf(str,"+ 0*X^%-1d ", MatA[i], i);
		//		}
		//		if (strcmp(str,"")!=0)
		//			strcat(eqn, str);
		//	}
		//	if (strcmp(eqn,"")!=0)
		//	{
		//		strcat(eqn, "\r\n");
		//                                        Switch(N)
		//		{
		//			case 0 : 	sprintf(str, " (DIRECT) \r\n");  break;
		//			case 2  :
		//#If STD_ADDN Then
		//					if( stdaddn)
		//						sprintf(str, " (LINEAR)\t\t");
		//					else
		//#End If
		//					sprintf(str, " (LINEAR) %7.5f\r\n", err[1]);
		//				break;
		//			case 3  :
		//                                        If (rational) Then
		//					sprintf(str, " (RATIO) %7.5f\r\n", err[0]);
		//                                        Else
		//					sprintf(str, " (QUADRATIC) %7.5f\r\n", err[2]);
		//				break;

		//			case 4  : sprintf(str, " (CUBIC) %7.5f\r\n", err[3]);break;
		//			case 5  : sprintf(str, " (4th order) %7.5f\r\n", err[4]);break;
		//			case 6  : sprintf(str, " (5th order) %7.5f\r\n", err[5]);break;
		//		}
		//		strcat(eqn, str);
		//	}
		//}

		string str;
		int i;

		try {
			// To make the equation depending upon calculation Mode
			eqn = "";

			if (!(gobjclsStandardGraph.Curve_Status)) {
				return;
			}

			for (i = 0; i <= gobjclsStandardGraph.N - 1; i++) {
				str = "";
				if ((i == 0)) {
					if ((gobjclsStandardGraph.MatA(i) == 0.0)) {
						//sprintf(str,"0 ", MatA(i))
						str = "0 ";
					} else {
						//sprintf(str,"%-5.4f ", MatA(i))
						str = Format(gobjclsStandardGraph.MatA(i), "0.0000");
					}

				} else if ((i == 1)) {
					if ((gobjclsStandardGraph.MatA(i) > 0.0)) {
						//sprintf(str,"+ %-5.4f*X ",MatA[i])
						str = "+ " + Format(gobjclsStandardGraph.MatA(i), "0.0000") + "*X";

					} else if ((gobjclsStandardGraph.MatA(i) < 0.0)) {
						//sprintf(str,"- %5.4f*X ",fabs(MatA[i]))
						str = "- " + Format(Math.Abs(gobjclsStandardGraph.MatA(i)), "0.0000") + "*X";
					} else {
						//sprintf(str,"%+ 0*X ",MatA[i])
						str = gobjclsStandardGraph.MatA(i) + "*X";
					}
				} else {
					if ((gobjclsStandardGraph.MatA(i) > 0.0)) {
						//sprintf(str,"+ %-5.4f*X^%-1d ", MatA[i], i)
						str = "+" + Format(gobjclsStandardGraph.MatA(i), "0.0000") + "*X^-" + i;

					} else if ((gobjclsStandardGraph.MatA(i) < 0.0)) {
						//sprintf(str,"- %-5.4f*X^%-1d ", fabs(MatA[i]), i)
						str = "-" + Format(Math.Abs(gobjclsStandardGraph.MatA(i)), "0.0000") + "*X^" + i;
					} else {
						//sprintf(str,"+ 0*X^%-1d ", MatA[i], i)
						str = "+" + "0*X^" + i;
					}
				}
				if (!(str == "")) {
					eqn = eqn + str;
				}
			}

			if (!(eqn == "")) {
				//strcat(eqn, "\r\n");
				eqn = eqn + vbCrLf;

				switch ((gobjclsStandardGraph.N)) {
					case 0:
						//sprintf(str, " (DIRECT) \r\n");  
						//break;

						str = " (DIRECT) " + vbCrLf;
					case 2:
						//#If STD_ADDN Then
						//   if( stdaddn)
						//	    sprintf(str, " (LINEAR)\t\t");
						//	else
						//#End If
						//   sprintf(str, " (LINEAR) %7.5f\r\n", err[1]);
						//break;

						if ((gobjclsStandardGraph.mblnIsStandardAddition)) {
							//sprintf(str, " (LINEAR)\t\t");
							str = " (LINEAR) " + vbCrLf;
						} else {
							//sprintf(str, " (LINEAR) %7.5f\r\n", err[1]);
							str = " (LINEAR) " + Format(gobjclsStandardGraph.err(1), "0.00000") + vbCrLf;

						}
					case 3:
						if ((gobjclsStandardGraph.Rational)) {
							//sprintf(str, " (RATIO) %7.5f\r\n", err[0]);
							str = " (RATIO) " + Format(gobjclsStandardGraph.err(0), "0.00000") + vbCrLf;
						} else {
							//sprintf(str, " (QUADRATIC) %7.5f\r\n", err[2]);
							str = " (QUADRATIC) " + Format(gobjclsStandardGraph.err(2), "0.00000") + vbCrLf;

						}
					case 4:
						//sprintf(str, " (CUBIC) %7.5f\r\n", err[3]);break;

						str = " (CUBIC) " + Format(gobjclsStandardGraph.err(3), "0.00000") + vbCrLf;
					case 5:
						//sprintf(str, " (4th order) %7.5f\r\n", err[4]);break;

						str = " (4th order) " + Format(gobjclsStandardGraph.err(4), "0.00000") + vbCrLf;
					case 6:
						//sprintf(str, " (5th order) %7.5f\r\n", err[5]);break;

						str = " (5th order) " + Format(gobjclsStandardGraph.err(5), "0.00000") + vbCrLf;
				}

				eqn = eqn + str;
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

	private double Calculate_Curve_Param()
	{
		//=====================================================================
		// Procedure Name        : Calculate_Curve_Param
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : cal. curve parameter
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 31-Jan-2007 04:25 pm
		// Revisions             : 1
		//=====================================================================


		//---- ORIGINAL CODE

		//double	Calculate_Curve_Param(CURVEDATA *Curve)
		//{
		//	double	FrqIntv=0.0, Max=0, Min=0, xmax1=0, xmin1=0,Fmin=0, Fmax=0, Fx=0;
		//	int		fn;
		//	int		tot, tot1;

		//	if (Curve==NULL)
		//		return 0.0;
		//	//Curve->nStds
		//	tot=GetTotStds(Method->QuantData->StdTopData,TRUE);
		//	//tot = Curve->nStds;
		//	xmin1=(double) 0.0; //FindMinStdAbs(Method->QuantData->StdTopData);
		//	Min= xmin1;
		//	xmax1=FindMaxStdAbs(Method->QuantData->StdTopData);
		//	Max= xmax1;

		//	if (Max==Min || Max <Min || Min>Max)
		//	{
		//		Max = 5.0;
		//		Min=0.0;
		//	}
		//	tot1=tot;

		//	FrqIntv =GetInterval(Max, Min, tot1, TRUE);
		//	fn = (int)  (Max/ FrqIntv);
		//	Fmax = (double) fn*  FrqIntv;
		//                If (Max > Fmax) Then
		//		Fmax+= FrqIntv;
		//	fn = (int)  ( Min/ FrqIntv);
		//	Fmin = (double) fn*FrqIntv;

		//                    If (Min < Fmin) Then
		//		Fmin-= FrqIntv;

		//	if (Fmin> Min&& FrqIntv!=(double) -1.0)
		//	{
		//                            While (Fmin > Min)
		//			Fmin-=FrqIntv;
		//	}
		//	if (Fmax< Max&& FrqIntv!=(double) -1.0)
		//	{
		//       While (Fmax < Max)
		//		    Fmax+=FrqIntv;
		//	}

		//	/*if (Fmin==(double) 0.0)
		//	Fmin-=FrqIntv;*/
		//	Curve->Ymin = Fmin;
		//	Curve->Ymax= Fmax;
		//	Curve->FrqIntv =FrqIntv;

		//	xmin1=(double) 0; 
		//	xmax1 = (double)  FindMaxStdConc(Method->QuantData->StdTopData);
		//	Fx =GetInterval(xmax1, xmin1, tot1, TRUE);
		//	fn = (int)  (xmax1/ Fx);
		//	Fmax = (double) fn*  Fx;
		//   If (xmax1 > Fmax) Then
		//	    Fmax+= Fx;

		//	Curve->Xmin = xmin1;
		//	Curve->Xmax = Fmax;
		//	Calculate_Xparameters(Curve);

		//	return FrqIntv;
		//}

		//	double	FrqIntv=0.0, Max=0, Min=0, xmax1=0, xmin1=0,Fmin=0, Fmax=0, Fx=0;
		double FrqIntv;
		double Max;
		double Min;
		double xmax1;
		double xmin1;
		double Fmin;
		double Fmax;
		double Fx;
		int fn;
		int tot;
		int tot1;

		try {
			//calculate the Curve parameter of graph
			if (IsNothing(Graph)) {
				return 0.0;
			}

			tot = clsStandardGraph.GetTotStds(mobjclsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection, true);

			xmin1 = 0.0;
			Min = xmin1;
			xmax1 = clsStandardGraph.FindMaxStdAbs(mobjclsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection);
			Max = xmax1 + 0.01;

			if ((Max == Min) | (Min > Max)) {
				Max = 5.0;
				Min = 0.0;
			}
			tot1 = tot;

			FrqIntv = gobjclsStandardGraph.GetInterval(Max, Min, tot1, true);
			fn = (int)Max / FrqIntv;
			Fmax = (double)fn * FrqIntv;
			if ((Max > Fmax)) {
				Fmax += FrqIntv;
			}
			fn = (int)Min / FrqIntv;
			Fmin = (double)fn * FrqIntv;

			if ((Min < Fmin)) {
				Fmin -= FrqIntv;
			}

			if ((Fmin > Min & FrqIntv != -1.0)) {
				while ((Fmin > Min)) {
					Fmin -= FrqIntv;
				}
			}

			if ((Fmax < Max & FrqIntv != -1.0)) {
				while ((Fmax < Max)) {
					Fmax += FrqIntv;
				}
			}

			Graph.YAxisMin = Fmin;
			Graph.YAxisMax = Fmax;
			Graph.YAxisStep = FrqIntv;

			xmin1 = 0;
			xmax1 = clsStandardGraph.FindMaxStdConc(mobjclsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection);
			Fx = gobjclsStandardGraph.GetInterval(xmax1, xmin1, tot1, true);
			fn = (xmax1 / Fx) + 0.5;
			Fmax = (double)fn * Fx;

			if ((xmax1 > Fmax)) {
				Fmax += Fx;
			}

			Graph.XAxisMin = xmin1;
			Graph.XAxisMax = Fmax;

			Calculate_Xparameters();

			return FrqIntv;

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

	private void Calculate_Xparameters()
	{
		//=====================================================================
		// Procedure Name        : Calculate_Xparameters
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : Cal. X axis parameter for graph
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 31-Jan-2007 04:45 pm
		// Revisions             : 1
		//=====================================================================


		//---- ORIGINAL CODE

		//void(Calculate_Xparameters(CURVEDATA * Curve))
		//{
		//   int	totStd;
		//   if (Curve==NULL)
		//       return;
		//   totStd = GetTotStdsInBetweenConc(Curve->Xmin, Curve->Xmax,
		//				Method->QuantData->StdTopData, FALSE);
		//   Curve->XIntv =GetInterval(Curve->Xmax, Curve->Xmin,
		//					totStd+1, TRUE);
		//}

		int totStd;

		try {
			if (IsNothing(Graph)) {
				return;
			}

			totStd = clsStandardGraph.GetTotStdsInBetweenConc(Graph.XAxisMin, Graph.XAxisMax, mobjclsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection, false);

			Graph.XAxisStep = gobjclsStandardGraph.GetInterval(Graph.XAxisMax, Graph.XAxisMin, totStd + 1, true);

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

	private void subPrintGraph()
	{
		//=====================================================================
		// Procedure Name        : subPrintGraph
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : Print the graph
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 31-Jan-2007 04:45 pm
		// Revisions             : 1
		//=====================================================================
		int intCount;
		int intSelectId;

		// Check for 21CFR setting
		if ((gstructSettings.Enable21CFR == true)) {
			if (!funcCheckActivityAuthentication(enumActivityAuthentication.Print, gstructUserDetails.Access)) {
				return;
				return;
			}
			if (mblnIsSampleGraph) {
				gfuncInsertActivityLog(EnumModules.Print, "Print Sample Graph Accessed");
			} else {
				gfuncInsertActivityLog(EnumModules.Print, "Print Standard Graph Accessed");
			}
		}
		//Select  Method Id from collection object
		if (mblnIsAnalysisMode) {
		} else {
			for (intCount = 0; intCount <= gobjMethodCollection.Count - 1; intCount++) {
				if (mintSelectedMethodID == gobjMethodCollection(intCount).MethodID) {
					intSelectId = intCount;
					mobjClsDataFileReport.MethodID = intCount;
					break; // TODO: might not be correct. Was : Exit For
				}
			}
		}

		//Select  Run No from collection object
		if (mblnIsAnalysisMode) {
			if (mobjclsMethod.QuantitativeDataCollection.Count > 0) {
				mintRunNumberIndex = gobjNewMethod.QuantitativeDataCollection.Count - 1;
				mobjClsDataFileReport.RunNumber = gobjNewMethod.QuantitativeDataCollection(mintRunNumberIndex).RunNumber;
			} else {
				mintRunNumberIndex = 0;
			}
		} else {
			//---For Data Files Mode
			mintRunNumberIndex = gfuncGetSelectedMethodRunNumberIndex(mobjclsMethod.MethodID, mintSelectedRunNumber);
			mobjClsDataFileReport.RunNumber = mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).RunNumber;
		}

		mobjClsDataFileReport.DefaultFont = this.DefaultFont;

		//Graph.XAxisDateScaleFormat = AAS203.AASGraph.enumDateScaleFormat.HHMM
		double conc1;
		string strEquation;
		string strLinear;
		int intCounter = 0;
		string[] strTemp = new string[1];
		string[] strTemp1 = new string[1];
		string strtmp;
		// Set equation for standard graph to print
		Get_Equation(strEquation);
		//Added by pankaj on 14 Aug 07
		strTemp = strEquation.Split(vbCrLf);
		strTemp1 = lblCalcDescription.Text.Split(vbCrLf);
		if ((strTemp.Length > 1)) {
			if ((strTemp(1).Length > 1)) {
				strtmp = strTemp(1).Substring(1);
			}
		}
		//strLinear = strTemp1(0) & strtmp & vbCrLf
		strLinear = "Calibration Graph :" + strtmp + vbCrLf;
		strLinear = strLinear + "Eqn (" + strTemp(0) + " )";
		strEquation = strLinear;

		// Send the data to the Print object depending upon Sample or Standard
		if (mblnIsSampleGraph) {
			mobjClsDataFileReport.funcSampleGraphPrint(Graph, strEquation, mobjclsMethod);
			//txtCalcProcess.Text.ToString
		} else {
			mobjClsDataFileReport.funcStandardGraphPrint(Graph, strEquation, mobjclsMethod);
			//txtCalcProcess.Text.ToString
		}

	}

	#End Region


}
