using System.Threading;
using AAS203.Common;
using BgThread;
using System.IO;
using Microsoft.VisualBasic;
//Imports AAS203.Spectrum
public class frmD2PeakSearch : System.Windows.Forms.Form, Iclient
{

	#Region " Private Variable "


	bool mblnAvoidProcessing;
	bool mblnD2OptimiseStarted;
	//Private mController As New clsBgThread(Me)
	//--- Declaration for the controller object of the BgThread
	private BgThread.clsBgThread mobjController = new BgThread.clsBgThread(this);

	private clsBgD2Optimisation mobjclsBgD2Optimisation;
	private const  CONST_486XaxisMin = 480.0;
	private const  CONST_486XaxisMax = 490.0;
	double m_486YaxisMin = 0.0;

	double m_486YaxisMax = 40.0;

	private const  CONST_656XaxisMin = 650.0;
	private const  CONST_656XaxisMax = 660.0;
	double m_656YaxisMin = 0.0;

	double m_656YaxisMax = 40.0;
	//Dim m_486PeakCurveItem As AldysGraph.CurveItem
	//Dim m_656PeakCurveItem As AldysGraph.CurveItem

	////----- Display peak on Graph 
	double m_dblYMax486 = 0.0;

	double m_dblYMax656 = 0.0;
	double m_dblYMin486 = 0.0;

	double m_dblYMin656 = 0.0;
	bool blnIsFoundPeak486Flag;

	bool blnIsFoundPeak656Flag;
	DataTable m_dtPeak486 = new DataTable();
	DataTable m_dtPeak656 = new DataTable();
		//Saurabh to Check Tolerance
	private double m_dblXmax656;
		//Saurabh to Check Tolerance
	private double m_dblXmax486;
		//Saurabh to Check Tolerance
	private bool mblnD2PeakOK;
	private double mblnD2Peak486OK;
	private double mblnD2Peak656OK;


	#End Region

	#Region " Windows Form Designer generated code "

	public frmD2PeakSearch()
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
	internal GradientPanel.CustomPanel CustomPanel1;
	internal GradientPanel.CustomPanel CustomPanel2;
	internal AAS203.AASGraph AASD2EnergyPeak486;
	internal AAS203.AASGraph AASD2EnergyPeak656;
	internal GradientPanel.CustomPanel CustomPanel3;
	internal System.Windows.Forms.Label lbl4;
	internal System.Windows.Forms.Label Lbl3;
	internal System.Windows.Forms.Label Lbl2;
	internal NETXP.Controls.XPButton btnPrintGraph;
	internal System.Windows.Forms.Button btnReturn1;
	internal NETXP.Controls.XPButton btnReturn;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmD2PeakSearch));
		this.CustomPanel1 = new GradientPanel.CustomPanel();
		this.CustomPanel3 = new GradientPanel.CustomPanel();
		this.btnReturn = new NETXP.Controls.XPButton();
		this.btnPrintGraph = new NETXP.Controls.XPButton();
		this.lbl4 = new System.Windows.Forms.Label();
		this.Lbl3 = new System.Windows.Forms.Label();
		this.Lbl2 = new System.Windows.Forms.Label();
		this.btnReturn1 = new System.Windows.Forms.Button();
		this.CustomPanel2 = new GradientPanel.CustomPanel();
		this.AASD2EnergyPeak656 = new AAS203.AASGraph();
		this.AASD2EnergyPeak486 = new AAS203.AASGraph();
		this.CustomPanel1.SuspendLayout();
		this.CustomPanel3.SuspendLayout();
		this.CustomPanel2.SuspendLayout();
		this.SuspendLayout();
		//
		//CustomPanel1
		//
		this.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanel1.Controls.Add(this.CustomPanel3);
		this.CustomPanel1.Controls.Add(this.CustomPanel2);
		this.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanel1.Location = new System.Drawing.Point(0, 0);
		this.CustomPanel1.Name = "CustomPanel1";
		this.CustomPanel1.Size = new System.Drawing.Size(650, 423);
		this.CustomPanel1.TabIndex = 0;
		//
		//CustomPanel3
		//
		this.CustomPanel3.Controls.Add(this.btnReturn);
		this.CustomPanel3.Controls.Add(this.btnPrintGraph);
		this.CustomPanel3.Controls.Add(this.lbl4);
		this.CustomPanel3.Controls.Add(this.Lbl3);
		this.CustomPanel3.Controls.Add(this.Lbl2);
		this.CustomPanel3.Controls.Add(this.btnReturn1);
		this.CustomPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.CustomPanel3.Location = new System.Drawing.Point(0, 327);
		this.CustomPanel3.Name = "CustomPanel3";
		this.CustomPanel3.Size = new System.Drawing.Size(650, 96);
		this.CustomPanel3.TabIndex = 9;
		//
		//btnReturn
		//
		this.btnReturn.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right;
		this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnReturn.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnReturn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnReturn.Location = new System.Drawing.Point(328, 64);
		this.btnReturn.Name = "btnReturn";
		this.btnReturn.RightToLeft = System.Windows.Forms.RightToLeft.No;
		this.btnReturn.Size = new System.Drawing.Size(110, 25);
		this.btnReturn.TabIndex = 8;
		this.btnReturn.Text = "&Return";
		//
		//btnPrintGraph
		//
		this.btnPrintGraph.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right;
		this.btnPrintGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnPrintGraph.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnPrintGraph.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnPrintGraph.Location = new System.Drawing.Point(328, 32);
		this.btnPrintGraph.Name = "btnPrintGraph";
		this.btnPrintGraph.RightToLeft = System.Windows.Forms.RightToLeft.No;
		this.btnPrintGraph.Size = new System.Drawing.Size(110, 25);
		this.btnPrintGraph.TabIndex = 7;
		this.btnPrintGraph.Text = "&Print Graph";
		this.btnPrintGraph.Visible = false;
		//
		//lbl4
		//
		this.lbl4.Anchor = (System.Windows.Forms.AnchorStyles)System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.lbl4.BackColor = System.Drawing.Color.White;
		this.lbl4.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lbl4.ForeColor = System.Drawing.Color.Blue;
		this.lbl4.Location = new System.Drawing.Point(30, 19);
		this.lbl4.Name = "lbl4";
		this.lbl4.Size = new System.Drawing.Size(280, 16);
		this.lbl4.TabIndex = 5;
		this.lbl4.Text = "D2 Peak Search";
		//
		//Lbl3
		//
		this.Lbl3.Anchor = (System.Windows.Forms.AnchorStyles)System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.Lbl3.BackColor = System.Drawing.Color.White;
		this.Lbl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.Lbl3.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Lbl3.ForeColor = System.Drawing.Color.Blue;
		this.Lbl3.Location = new System.Drawing.Point(30, 43);
		this.Lbl3.Name = "Lbl3";
		this.Lbl3.Size = new System.Drawing.Size(280, 16);
		this.Lbl3.TabIndex = 4;
		//
		//Lbl2
		//
		this.Lbl2.Anchor = (System.Windows.Forms.AnchorStyles)System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.Lbl2.BackColor = System.Drawing.Color.White;
		this.Lbl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.Lbl2.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Lbl2.ForeColor = System.Drawing.Color.Blue;
		this.Lbl2.Location = new System.Drawing.Point(30, 67);
		this.Lbl2.Name = "Lbl2";
		this.Lbl2.Size = new System.Drawing.Size(280, 16);
		this.Lbl2.TabIndex = 3;
		//
		//btnReturn1
		//
		this.btnReturn1.Anchor = (System.Windows.Forms.AnchorStyles)System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.btnReturn1.Location = new System.Drawing.Point(456, 32);
		this.btnReturn1.Name = "btnReturn1";
		this.btnReturn1.Size = new System.Drawing.Size(88, 24);
		this.btnReturn1.TabIndex = 6;
		this.btnReturn1.Text = "&Return";
		this.btnReturn1.Visible = false;
		//
		//CustomPanel2
		//
		this.CustomPanel2.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanel2.Controls.Add(this.AASD2EnergyPeak656);
		this.CustomPanel2.Controls.Add(this.AASD2EnergyPeak486);
		this.CustomPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanel2.Location = new System.Drawing.Point(0, 0);
		this.CustomPanel2.Name = "CustomPanel2";
		this.CustomPanel2.Size = new System.Drawing.Size(650, 423);
		this.CustomPanel2.TabIndex = 8;
		//
		//AASD2EnergyPeak656
		//
		this.AASD2EnergyPeak656.AldysGraphCursor = null;
		this.AASD2EnergyPeak656.AldysGraphPrintColor = System.Drawing.Color.Black;
		this.AASD2EnergyPeak656.BackColor = System.Drawing.Color.LightGray;
		this.AASD2EnergyPeak656.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.AASD2EnergyPeak656.GraphDataSource = null;
		this.AASD2EnergyPeak656.GraphImage = null;
		this.AASD2EnergyPeak656.IsShowGrid = true;
		this.AASD2EnergyPeak656.Location = new System.Drawing.Point(328, 3);
		this.AASD2EnergyPeak656.Name = "AASD2EnergyPeak656";
		this.AASD2EnergyPeak656.Size = new System.Drawing.Size(320, 312);
		this.AASD2EnergyPeak656.TabIndex = 28;
		this.AASD2EnergyPeak656.UseDefaultSettings = false;
		this.AASD2EnergyPeak656.XAxisDateMax = new System.DateTime((long)0);
		this.AASD2EnergyPeak656.XAxisDateMin = new System.DateTime((long)0);
		this.AASD2EnergyPeak656.XAxisDateScaleFormat = AAS203.AASGraph.enumDateScaleFormat.YYYY;
		this.AASD2EnergyPeak656.XAxisLabel = "Wv";
		this.AASD2EnergyPeak656.XAxisMax = 660;
		this.AASD2EnergyPeak656.XAxisMin = 650;
		this.AASD2EnergyPeak656.XAxisMinorStep = 0.5;
		this.AASD2EnergyPeak656.XAxisScaleFormat = null;
		this.AASD2EnergyPeak656.XAxisStep = 1;
		this.AASD2EnergyPeak656.XAxisType = AldysGraph.AxisType.Linear;
		this.AASD2EnergyPeak656.YAxisLabel = "ENERGY";
		this.AASD2EnergyPeak656.YAxisMax = 10;
		this.AASD2EnergyPeak656.YAxisMin = 0;
		this.AASD2EnergyPeak656.YAxisMinorStep = 0.5;
		this.AASD2EnergyPeak656.YAxisScaleFormat = null;
		this.AASD2EnergyPeak656.YAxisStep = 1;
		this.AASD2EnergyPeak656.YAxisType = AldysGraph.AxisType.Linear;
		//
		//AASD2EnergyPeak486
		//
		this.AASD2EnergyPeak486.AldysGraphCursor = null;
		this.AASD2EnergyPeak486.AldysGraphPrintColor = System.Drawing.Color.Black;
		this.AASD2EnergyPeak486.BackColor = System.Drawing.Color.LightGray;
		this.AASD2EnergyPeak486.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.AASD2EnergyPeak486.GraphDataSource = null;
		this.AASD2EnergyPeak486.GraphImage = null;
		this.AASD2EnergyPeak486.IsShowGrid = true;
		this.AASD2EnergyPeak486.Location = new System.Drawing.Point(8, 3);
		this.AASD2EnergyPeak486.Name = "AASD2EnergyPeak486";
		this.AASD2EnergyPeak486.Size = new System.Drawing.Size(318, 313);
		this.AASD2EnergyPeak486.TabIndex = 27;
		this.AASD2EnergyPeak486.UseDefaultSettings = true;
		this.AASD2EnergyPeak486.XAxisDateMax = new System.DateTime((long)0);
		this.AASD2EnergyPeak486.XAxisDateMin = new System.DateTime((long)0);
		this.AASD2EnergyPeak486.XAxisDateScaleFormat = AAS203.AASGraph.enumDateScaleFormat.YYYY;
		this.AASD2EnergyPeak486.XAxisLabel = "Wv";
		this.AASD2EnergyPeak486.XAxisMax = 490;
		this.AASD2EnergyPeak486.XAxisMin = 480;
		this.AASD2EnergyPeak486.XAxisMinorStep = 2;
		this.AASD2EnergyPeak486.XAxisScaleFormat = null;
		this.AASD2EnergyPeak486.XAxisStep = 10;
		this.AASD2EnergyPeak486.XAxisType = AldysGraph.AxisType.Linear;
		this.AASD2EnergyPeak486.YAxisLabel = "ENERGY";
		this.AASD2EnergyPeak486.YAxisMax = 100;
		this.AASD2EnergyPeak486.YAxisMin = 0;
		this.AASD2EnergyPeak486.YAxisMinorStep = 5;
		this.AASD2EnergyPeak486.YAxisScaleFormat = null;
		this.AASD2EnergyPeak486.YAxisStep = 10;
		this.AASD2EnergyPeak486.YAxisType = AldysGraph.AxisType.Linear;
		//
		//frmD2PeakSearch
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(650, 423);
		this.Controls.Add(this.CustomPanel1);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmD2PeakSearch";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "D2 Peak Test";
		this.CustomPanel1.ResumeLayout(false);
		this.CustomPanel3.ResumeLayout(false);
		this.CustomPanel2.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region "Form Events"

	private void  // ERROR: Handles clauses are not supported in C#
frmD2PeakSearch_Load(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmD2PeakSearch_Load
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : to load initial settings and to start d2 peak search
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			if (mblnAvoidProcessing == true) {
				return;
			}
			mblnAvoidProcessing = true;
			//ShowProgressBar(ConstFormLoad)
			//---form initialize
			funcInitialise();
			//funcOnContinuesScan()
			//
			//---call d2 peak search routine
			funcOnOptimise(Lbl3, Lbl2);

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
			//HideProgressBar()
			//---------------------------------------------------------
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
frmD2PeakSearch_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmD2PeakSearch_Closing
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : to close the form and start flame status
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		try {
			if (!mobjclsBgD2Optimisation == null) {
				if (mblnAvoidProcessing == true) {
					e.Cancel = true;
				} else {
					e.Cancel = false;
					if (!IsNothing(gobjMain)) {
						if (gobjMain.mobjController.IsThreadRunning == false) {
							gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
							Application.DoEvents();
							gobjMain.mobjController.Start(gobjclsBgFlameStatus);
						}
						gobjfrmStatus.Visible = true;
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

	private void mnuExit_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuExit_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To close the Energy Spectrum Mode form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 07.10.06
		// Revisions             : 
		//=====================================================================
		try {
			//stop thread if running

			if (!mobjclsBgD2Optimisation == null) {
				if (mblnAvoidProcessing == true) {
					Application.DoEvents();
					mobjclsBgD2Optimisation.ThTerminate = true;
					return;
				} else {
					if (!(mobjController == null)) {
						if (mobjController.IsThreadRunning) {
							mobjController.Cancel();
						}
					}
				}
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
		}
	}

	#End Region

	#Region "Private functions"

	private object funcInitialise()
	{
		//=====================================================================
		// Procedure Name        : funcInitialise
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : Initialise the form Object
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		DataColumn objdtCol1;
		DataColumn objdtCol2;
		DataColumn objdtCol3;
		DataColumn objdtCol4;

		try {

			////----- Create Data Table to hold Scan Data for 486 and 656 peaks
			objdtCol1 = new DataColumn("Xaxis", typeof(double));
			objdtCol2 = new DataColumn("Yaxis", typeof(double));
			objdtCol3 = new DataColumn("Xaxis", typeof(double));
			objdtCol4 = new DataColumn("Yaxis", typeof(double));

			m_dtPeak486.Columns.Add(objdtCol1);
			m_dtPeak486.Columns.Add(objdtCol2);

			m_dtPeak656.Columns.Add(objdtCol3);
			m_dtPeak656.Columns.Add(objdtCol4);
			////------
			//cmbSpeed.Visible = True
			lbl4.Text = "Search D2 Peak for 486";
			lbl4.Refresh();
			//Call gobjClsAAS203.funcSetInstrumentCondns(True, lblElementName, lblLampCurrent, lblWavelength, lblSlitWidth, lblBurnerFlame)

			////----- Disable Element name and Turret no 
			gobjfrmStatus.lblElementName.Text = "";
			gobjfrmStatus.lblTurretNo.Text = "";


			////-----
			if (!IsNothing(gobjMain)) {
				//'mblnIsfrmFlameStatusWork = True
				gobjMain.mobjController.Cancel();
				gobjCommProtocol.mobjCommdll.subTime_Delay(500);
				//10.12.07
				Application.DoEvents();
			}
			Application.DoEvents();
			AddHandlers();

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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	private void AddHandlers()
	{
		//=====================================================================
		// Procedure Name        : AddHandlers
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To add event handlers
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh
		// Created               : 15.11.06
		// Revisions             : 
		//=====================================================================
		try {
			//add handler to button
			btnReturn.Click += mnuExit_Click;

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


	public bool funcOnOptimise(ref System.Object lblScanStatus, ref System.Object lblOnlineWv)
	{
		//=====================================================================
		// Procedure Name        : funcOnOptimise
		// Parameters Passed     : lblScanStatus,lblOnlineWv as object
		// Returns               : Bool. True if success
		// Purpose               :  Start to search D2 peak
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh
		// Created               : 15.11.06
		// Revisions             : 
		//=====================================================================
		mblnAvoidProcessing = true;
		try {
			////----- Orig
			//addata.counter = 0;
			// if (addata.speed==0){
			//if (GetInstrument()==AA202) addata.speed=FASTSTEP_AA202;
			//else addata.speed=FAST;
			// }
			// speed = addata.speed;
			///-----

			//----for graph initial setting
			if (!funcGraphPreRequisite(AASD2EnergyPeak486, CONST_486XaxisMin, CONST_486XaxisMax, m_486YaxisMin, m_486YaxisMax)) {
				return;
			}
			if (AASD2EnergyPeak656.AldysPane.CurveList.Count > 0) {
				AASD2EnergyPeak486.AldysPane.CurveList(0).Label = "Peak for 486.00 nm";
			}

			//----for graph initial setting
			if (!funcGraphPreRequisite(AASD2EnergyPeak656, CONST_656XaxisMin, CONST_656XaxisMax, m_656YaxisMin, m_656YaxisMax)) {
				return;
			}



			mblnD2OptimiseStarted = true;
			//--- Start the Spectrum analysis
			mobjController = new clsBgThread(this);
			mobjclsBgD2Optimisation = new clsBgD2Optimisation(Lbl3, Lbl2);
			//---start d2 optimization thread
			mobjController.Start(mobjclsBgD2Optimisation);

			funcOnOptimise = true;
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

	#End Region

	#Region " IClient Events for receiving the wavelength and Abs value from Receiving thread "

	private void BgThread.Iclient.TaskStarted(clsBgThread BgThread)
	{
		//=====================================================================
		// Procedure Name        : TaskStarted
		// Parameters Passed     : BgThread As clsBgThread
		// Returns               : Iclient.Start
		// Purpose               : Thread task is started  
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh
		// Created               : 15.11.06
		// Revisions             : 
		//=====================================================================
		try {
			mblnAvoidProcessing = true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
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

	private void Iclient.TaskStatus(string Text)
	{
		//=====================================================================
		// Procedure Name        : TaskStatus
		// Parameters Passed     : Text
		// Returns               : Iclient.Display
		// Purpose               : get the data from thread 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh
		// Created               : 15.11.06
		// Revisions             : 
		//=====================================================================
		try {
			//---send data to display on form
			funcIclientTaskDisplayData(Text);

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//--------------------------------------------------------
		}
	}


	private void Iclient.TaskFailed(Exception e)
	{
		//=====================================================================
		// Procedure Name        : TaskFailed
		// Parameters Passed     : Exception
		// Returns               : Iclient.Failed as Implements
		// Purpose               :  
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh
		// Created               : 15.11.06
		// Revisions             : 
		//=====================================================================
		try {
			funcIclientTaskFalied();
			mblnAvoidProcessing = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
			mblnAvoidProcessing = false;
		}
	}

	private void Iclient.TaskCompleted(bool Cancelled)
	{
		//=====================================================================
		// Procedure Name        : TaskCompleted
		// Parameters Passed     : Cancelled
		// Returns               : Iclient.Completed as Implemented
		// Purpose               :  
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh
		// Created               : 15.11.06
		// Revisions             : 
		//=====================================================================
		try {
			funcIclientTaskCompleted();

			mblnAvoidProcessing = false;

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
			//---------------------------------------------------------

		}

	}



	#End Region

	#Region "IClient Private Function"

	private bool funcIclientTaskCompleted()
	{
		//=====================================================================
		// Procedure Name        :   funcIclientTaskCompleted
		// Description           :   task completed received from instrument 
		//                           
		// Purpose               :   
		// Parameters Passed     :  None
		// Returns               :   True, if successful.
		// Parameters Affected   :   
		// Assumptions           :   None.
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   17.12.06
		// Revisions             :
		//=====================================================================

		try {
			funcIclientTaskCompleted = false;

			//---after finish of thread display highest peak
			if (blnIsFoundPeak656Flag == true) {
				AASD2EnergyPeak656.YAxisMax = gFuncGetEnergy(m_dblYMax656 + 50.0);
				AASD2EnergyPeak656.YAxisMin = gFuncGetEnergy(m_dblYMin656 - 4.096);
				funcDisplayGraph(AASD2EnergyPeak656, m_dtPeak656);
				if (AASD2EnergyPeak656.AldysPane.CurveList.Count > 0) {
					AASD2EnergyPeak656.AldysPane.CurveList(0).Label = "Peak for 656.1 nm";
				}
				AASD2EnergyPeak656.DrawHighestPeakLine(AASD2EnergyPeak656.AldysPane.CurveList(0));
				AASD2EnergyPeak656.ShowHighPeakLineLabel("  Max. Position ", false, 20);
			} else {
				//--- Else display each point on graph
				funcDisplayGraph(AASD2EnergyPeak656, m_dtPeak656);
				if (AASD2EnergyPeak656.AldysPane.CurveList.Count > 0) {
					AASD2EnergyPeak656.AldysPane.CurveList(0).Label = "Peak for 656.1 nm";
				}
			}

			AASD2EnergyPeak656.AldysPane.AxisChange();
			AASD2EnergyPeak656.Refresh();
			Application.DoEvents();

			funcScanCompleted(true);
			mblnAvoidProcessing = false;
			funcIclientTaskCompleted = true;

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

	private bool funcIclientTaskFalied()
	{
		//=====================================================================
		// Procedure Name        :   funcIclientTaskFalied
		// Description           :   task falied received from instrument 
		//                           
		// Purpose               :   
		// Parameters Passed     :   None
		// Returns               :   True, if successful.
		// Parameters Affected   :   
		// Assumptions           :   None.
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   18.12.06
		// Revisions             :
		//=====================================================================

		try {
			funcIclientTaskFalied = false;

			// If scan is terminated by user in between then gblnSpectrumTerminated = True
			//If ArrlstGraphCurveItem.Count >= intCurveIndex + 1 Then

			//intCurveIndex += 1
			// End If

			//mobjOnlineChannel = New Channel(True)
			//mobjOnlineReadings = New Readings
			//mblnSpectrumStarted = False

			//Application.DoEvents()
			//display message for termination and write pmt to ini file
			funcScanCompleted(false);

			Application.DoEvents();
			gobjMessageAdapter.ShowMessage(constSpectrumScanningFailed);
			Application.DoEvents();
			//gFuncShowMessage("Error...", "Spectrum scanning failed.", EnumMessageType.Information)
			mblnAvoidProcessing = false;
			funcIclientTaskFalied = true;

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

	private bool funcScanCompleted(bool blnCompleted)
	{
		//=====================================================================
		// Procedure Name        :   funcScanCompleted
		// Description           :   if scan completed or terminated by user
		// Purpose               :   to show termination message and write D2 pmt to ini file
		// Parameters Passed     :   blnCompleted is true if completed successfully 
		//                          & false if terminated by user
		// Returns               :   True, if successful.
		// Parameters Affected   :   
		// Assumptions           :   None.
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   Tuesday, April 06, 2004 18:36
		// Revisions             :
		//=====================================================================
		int dblD2_PMT;
		try {
			//--- Check for D2 peak where it's detected or not and set messsage
			if (blnCompleted) {
				if (mblnD2PeakOK == true) {
					lbl4.Text = "Search D2 Peak OK";
					lbl4.Refresh();
				} else {
					lbl4.Text = "Search D2 Peak Failed";
					lbl4.Refresh();
				}
			} else {
				lbl4.Text = "Search D2 Peak Failed";
				lbl4.Refresh();
			}

			//--- write D2 PMT to ini 
			dblD2_PMT = gobjInst.PmtVoltage;
			gFuncWriteToINI(SECTION_D2Setting, KEY_D2PMT, (string)dblD2_PMT, INI_SETTINGS_PATH);

			this.Cursor = Cursors.Default;
			gblnSpectrumTerminated = false;
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

	private bool funcIclientTaskDisplayData(string strData)
	{
		//=====================================================================
		// Procedure Name        :   funcIclientTaskDisplayData
		// Description           :   Plot the graph on the screen.
		// Purpose               :   To plot the graph on the screen for the given
		//                           Wavelength and absorbtion.           
		// Parameters Passed     :   strData.
		// Returns               :   True, if successful.
		// Parameters Affected   :   
		// Assumptions           :   Graph object is already decleare.
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale 
		// Created               :   10.12.06
		// Revisions             :
		//=====================================================================
		//---to display graph of d2 peak search
		try {
			//-----------------------------------------------------
			//Data in the Text arg would be "Wavelength|Abs"
			//-----------------------------------------------------
			//Dim objData As New Spectrum.Data
			string[] arrData;
			int O;
			// same as in function funcSmoothgraphonline
			int intCount;
			bool mRunningTab486 = false;
			bool mRunningTab656 = false;
			double XaxisData;
			double YaxisData;
			double YaxisValue;
			DataRow dtRow;
			static bool blnIsTabSetting;
			static bool blnIsTabChange;

			Application.DoEvents();
			//--- Split the data for Wv and Abs
			arrData = Split(strData, "|");

			if (arrData(0).Length > 0 & arrData(1).Length > 0) {
				mRunningTab486 = arrData(2);
				mRunningTab656 = arrData(3);
				XaxisData = Val(arrData(0));
				// wv

				YaxisData = Val(arrData(1));
				YaxisValue = gFuncGetEnergy(YaxisData);
				Lbl3.Text = "Wavelength : " + Format(XaxisData, "#000.0") + " Energy : " + Format(YaxisValue, "#00.00") + "%";
				Lbl3.Refresh();
				//==================================
				//for (i=0; i<n; i++){
				//if (arri]>ymax) 
				//Static Dim dblYMax As Double


				//		  ymax = arr[i];
				//		  ioff=i;
				//		  flag=TRUE;
				//		  }
				//	  if (arr[i]<ymin) ymin = arr[i];
				//		 }
				//	PeakGraph.Ymax=  GetEnergy(ymax+8.192);
				//	PeakGraph.Ymin=  GetEnergy(ymin-4.096);

				//================================

				if (blnIsTabChange == false) {

					if (mRunningTab486 == false & mRunningTab656 == false) {
						if (blnIsTabSetting == false) {
							blnIsTabSetting = true;
							blnIsTabChange = false;
							m_dblYMin486 = YaxisData;
						} else {
						}
						if (m_dblYMax486 < YaxisData) {
							m_dblYMax486 = YaxisData;
							blnIsFoundPeak486Flag = true;
							m_dblXmax486 = XaxisData;
							//Saurabh 29.07.07 To check D2Peak OK
						}
						if ((YaxisData < m_dblYMin486)) {
							m_dblYMin486 = YaxisData;
						}

						dtRow = m_dtPeak486.NewRow;
						m_dtPeak486.Rows.Add(dtRow);
						m_dtPeak486.Rows.Item(m_dtPeak486.Rows.Count - 1).Item(0) = XaxisData;
						m_dtPeak486.Rows.Item(m_dtPeak486.Rows.Count - 1).Item(1) = YaxisValue;

						Application.DoEvents();

					} else if (mRunningTab486 == true & mRunningTab656 == false) {
						if (blnIsTabSetting == false) {
							blnIsTabSetting = true;
							blnIsTabChange = false;
							m_dblYMin656 = YaxisData;
						//funcDisplayGraph_RealTime(AASD2EnergyPeak656, m_656PeakCurveItem, XaxisData, YaxisData)
						} else {
							//funcDisplayGraph_RealTime(AASD2EnergyPeak656, m_656PeakCurveItem, XaxisData, YaxisData)
						}

						if (m_dblYMax656 < YaxisData) {
							m_dblYMax656 = YaxisData;
							blnIsFoundPeak656Flag = true;
							m_dblXmax656 = XaxisData;
							//Saurabh 29.07.07 To check D2Peak OK
						}
						if ((YaxisData < m_dblYMin656)) {
							m_dblYMin656 = YaxisData;

						}

						dtRow = m_dtPeak656.NewRow;
						m_dtPeak656.Rows.Add(dtRow);
						m_dtPeak656.Rows.Item(m_dtPeak656.Rows.Count - 1).Item(0) = XaxisData;
						m_dtPeak656.Rows.Item(m_dtPeak656.Rows.Count - 1).Item(1) = YaxisValue;
						Application.DoEvents();

					} else if (mRunningTab486 == true & mRunningTab656 == true) {
						blnIsTabChange = false;
						blnIsTabSetting = false;
						AASD2EnergyPeak486.XAxisMax = 490.0;
						AASD2EnergyPeak486.XAxisMin = 480.0;

						if (blnIsFoundPeak486Flag == true) {
							AASD2EnergyPeak486.YAxisMax = gFuncGetEnergy(m_dblYMax486) + 1.5;
							AASD2EnergyPeak486.YAxisMin = gFuncGetEnergy(m_dblYMin486 - 4.096);
							funcDisplayGraph(AASD2EnergyPeak486, m_dtPeak486);
							if (AASD2EnergyPeak486.AldysPane.CurveList.Count > 0) {
								AASD2EnergyPeak486.AldysPane.CurveList(0).Label = "Peak for 486.0 nm";
							}
							AASD2EnergyPeak486.DrawHighestPeakLine(AASD2EnergyPeak486.AldysPane.CurveList(0));
							AASD2EnergyPeak486.ShowHighPeakLineLabel("  Max. Position ", false, 20);


						} else {
							funcDisplayGraph(AASD2EnergyPeak486, m_dtPeak486);
							if (AASD2EnergyPeak486.AldysPane.CurveList.Count > 0) {
								AASD2EnergyPeak486.AldysPane.CurveList(0).Label = "Peak for 486.0 nm";
							}
						}

						lbl4.Text = "Search D2 Peak for 656";
						lbl4.Refresh();
						AASD2EnergyPeak486.Refresh();
						Application.DoEvents();

					}
				} else {
					if (mRunningTab486 == true & mRunningTab656 == true) {
						blnIsTabChange = false;
						blnIsTabSetting = false;
					}
				}
				//--- update D2Peakflag
				//--- Check for D2 peak for 486nm
				if (m_dblXmax486 > 487 | m_dblXmax486 < 485) {
					mblnD2Peak486OK = false;
				} else {
					mblnD2Peak486OK = true;
				}
				//--- Check for D2 peak for 656nm
				if (m_dblXmax656 > 657 | m_dblXmax656 < 655) {
					mblnD2Peak656OK = false;
				} else {
					mblnD2Peak656OK = true;
				}
				//--- Check if both peaks are detected then D2 peak search is true
				if (mblnD2Peak656OK == true & mblnD2Peak486OK == true) {
					mblnD2PeakOK = true;
				} else {
					mblnD2PeakOK = false;

				}
			}

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
			//--------------------------------------------------------
		}
	}

	#End Region

	#Region "Graph Method"

	private bool funcGraphPreRequisite(ref AAS203.AASGraph AASD2EnergyGraph, double intXmin = 0.0, double intXmax = 0.0, double intYmin = 0.0, double intYmax = 0.0)
	{
		//=====================================================================
		// Procedure Name        :   funcGraphPreRequisite
		// Description           :   for graph settings
		// Purpose               :   
		// Parameters Passed     :   
		// Returns               :   True, if successful.
		// Parameters Affected   :   
		// Assumptions           :   
		// Dependencies          :   
		// Author                :   Sachin Dokhale 
		// Created               :   10.12.06
		// Revisions             :
		//=====================================================================
		double dblDiffX;
		double dblMajorStepX;
		double dblMinorStepX;
		double dblDiffY;
		double dblMajorStepY;
		double dblMinorStepY;

		try {
			//--- get xmin and ymin
			if (intXmin == 0.0) {
				intXmin = AASD2EnergyGraph.XAxisMin;
			}
			if (intXmax == 0.0) {
				intXmax = AASD2EnergyGraph.XAxisMax;
			}
			if (intYmin == 0.0) {
				intYmin = AASD2EnergyGraph.YAxisMin;
			}
			if (intYmax == 0.0) {
				intYmax = AASD2EnergyGraph.YAxisMax;
			}
			//--- get x major and x minor steps

			dblDiffX = Fix(intXmax - intXmin);
			dblMajorStepX = dblDiffX / 5;
			dblMinorStepX = dblMajorStepX / 1;
			//--- get y major and y minor steps
			dblDiffY = (intYmax - intYmin);
			dblMajorStepY = dblDiffY / 10;
			dblMinorStepY = dblMajorStepY / 2;
			AASD2EnergyGraph.btnPeakEdit.Enabled = false;
			AASD2EnergyGraph.btnShowXYValues.Enabled = false;

			//--- Assigning Values to Xmin,xmax,ymin,ymax properties

			//--- Set font setting for graph 

			AASD2EnergyGraph.XAxisMin = intXmin;
			AASD2EnergyGraph.XAxisMax = intXmax;
			AASD2EnergyGraph.AldysPane.XAxis.Min = intXmin;
			AASD2EnergyGraph.AldysPane.XAxis.Max = intXmax;

			AASD2EnergyGraph.AldysPane.FontSpec.Size = 16;
			AASD2EnergyGraph.AldysPane.Legend.FontSpec.Size = 20;
			AASD2EnergyGraph.AldysPane.Legend.IsVisible = false;
			AASD2EnergyGraph.AldysPane.CurveLabelSize = 16;
			AASD2EnergyGraph.AldysPane.XAxis.ScaleFontSpec.Size = 16;
			AASD2EnergyGraph.AldysPane.YAxis.ScaleFontSpec.Size = 16;
			AASD2EnergyGraph.AldysPane.XAxis.TitleFontSpec.Size = 18;
			AASD2EnergyGraph.AldysPane.YAxis.TitleFontSpec.Size = 18;

			//--- update x min,y min, x max,y max, 
			//--- x minor steps,y minor steps,y major steps, x major steps and the axis lables
			AASD2EnergyGraph.XAxisLabel = "Wv";

			if (AASD2EnergyGraph.AldysPane.CurveList.Count > 0) {
				AASD2EnergyGraph.AldysPane.CurveList(0).Label = "ENERGY";
			}

			AASD2EnergyGraph.YAxisMin = intYmin;
			AASD2EnergyGraph.YAxisMax = intYmax;
			AASD2EnergyGraph.YAxisLabel = "ENERGY";

			AASD2EnergyGraph.AldysPane.XAxis.Step = dblMajorStepX;
			AASD2EnergyGraph.AldysPane.XAxis.MinorStep = dblMinorStepX;
			AASD2EnergyGraph.AldysPane.YAxis.Step = dblMajorStepY;
			AASD2EnergyGraph.AldysPane.YAxis.MinorStep = dblMinorStepY;

			AASD2EnergyGraph.XAxisStep = dblMajorStepX;
			AASD2EnergyGraph.YAxisStep = dblMajorStepY;
			AASD2EnergyGraph.XAxisMinorStep = dblMinorStepX;
			AASD2EnergyGraph.YAxisMinorStep = dblMinorStepY;
			AASD2EnergyGraph.btnPeakEdit.Checked = false;
			AASD2EnergyGraph.AldysPane.AxisChange();
			AASD2EnergyGraph.Refresh();

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

	private bool funcDisplayGraph_RealTime(ref AAS203.AASGraph AASD2EnergyGraph, ref AldysGraph.CurveItem PeakCurveItem, double dblXAxis, double dblYAxis)
	{
		//=====================================================================
		// Procedure Name        :   funcDisplayGraph_RealTime
		// Description           :   Plot the graph on the screen.
		// Purpose               :   To plot the graph on the screen for the given
		//                           Wavelength and absorbtion.           
		// Parameters Passed     :   AASD2EnergyGraph As AASGraph,dblXAxis,dblYAxis as double
		// Returns               :   True, if successful.
		// Parameters Affected   :   
		// Assumptions           :   Graph pre-requisites are already been set.
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale 
		// Created               :   10.12.06
		// Revisions             :
		//=====================================================================
		double dblX_Axis;
		double dblToY;
		long tval;
		double dblDiffX;
		double dblMajorStepX;
		double dblMinorStepX;
		double dblDiffY;
		double dblMajorStepY;
		double dblMinorStepY;

		try {
			Application.DoEvents();
			//--- Plot the graph for the given coordinates.
			dblX_Axis = dblXAxis;
			dblToY = dblYAxis;

			//--- Check if the X-coordinates and Y-coordinates are less than
			//--- Xmin and Ymin

			dblYAxis = dblToY;

			Lbl3.TextAlign = ContentAlignment.MiddleRight;
			Lbl3.Text = "Wavelength " + Format(dblX_Axis, "#000.0") + " Energy " + Format(dblYAxis, "#0.0") + "%";

			//            if (xtime1>=AbsGraph.Xmax){
			//			tval =(AbsGraph.Xmax-AbsGraph.Xmin);
			//			AbsGraph.Xmin = AbsGraph.Xmax;//(double)5.0;
			//			AbsGraph.Xmax +=tval;// (double)5.0;
			//			Calculate_Abs_Scan_Param(&AbsGraph);
			//			Afirst=TRUE;
			//			InvalidateRect(hwnd, NULL, TRUE); //AbsGraph.RC, TRUE);
			//			UpdateWindow(hwnd);
			//			CEnd1 = clock();
			////			CStart += (CEnd1-CEnd);
			//		  }
			//		 if (Afirst){
			//			PlotInit(hdc, xtime1, abs, AbsGraph.RC, &AbsGraph);
			//			Afirst=FALSE;
			//		  }
			//                Else
			//			Plotg(hdc, xtime1, abs, AbsGraph.RC, &AbsGraph);
			//		}

			//--- Check if the wavelength is equal to the max wv
			AASD2EnergyGraph.PlotPoint(PeakCurveItem, dblXAxis, dblYAxis);
			AASD2EnergyGraph.AldysPane.AxisChange();
			AASD2EnergyGraph.Refresh();

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

	internal bool funcDisplayGraph(AAS203.AASGraph AASD2EnergyGraph, DataTable dtPlotValue)
	{
		//=====================================================================
		// Procedure Name        : funcDisplayGraph
		// Parameters Passed     : AASD2EnergyGraph,dtPlotValue
		// Returns               : Boolean
		// Purpose               : 
		// Description           :  to plot the graph
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 17-May-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		long lngDataCount;
		Spectrum.Readings objReadingCol = new Spectrum.Readings();
		double dblFromX;
		double dblFromY;
		double dblToX;
		double dblToY;

		try {
			//--- This is done when the Print overlay functionality is operated
			//--- because graph should come as overlay

			AASD2EnergyGraph.GraphDataSource = dtPlotValue;
			AASD2EnergyGraph.PlotGraph();
			funcGraphPreRequisite(AASD2EnergyGraph);
			AASD2EnergyGraph.Refresh();
			Application.DoEvents();

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

	internal bool funcClearGraph(AAS203.AASGraph AASD2EnergyGraph)
	{
		//=====================================================================
		// Procedure Name        : funcClearGraph
		// Parameters Passed     : AASD2EnergyGraph
		// Returns               : Boolean
		// Purpose               : 
		// Description           :  to clear the graph
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 17-May-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		long lngDataCount;
		double dblFromX;
		double dblFromY;
		double dblToX;
		double dblToY;

		//---to clear the graph
		try {
			AASD2EnergyGraph.AldysPane.CurveList.Clear();
			AASD2EnergyGraph.Refresh();
			Application.DoEvents();
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

	#End Region

	private void  // ERROR: Handles clauses are not supported in C#
btnPrintGraph_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : tlbbtnPrintGraph_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           :  to print the graph
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 17-May-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================


		//to print the graph
		CWaitCursor objWait = new CWaitCursor();
		clsDataFileReport mobjClsDataFileReport;

		try {
			//-----Added By Pankaj Fri 18 May 07
			if ((gstructSettings.Enable21CFR == true)) {
				if (!funcCheckActivityAuthentication(enumActivityAuthentication.Print, gstructUserDetails.Access)) {
					return;
					return;
				}
				gfuncInsertActivityLog(EnumModules.Print, "Print DataFiles Graph Accessed");
			}
			//------

			//--- Print the graph to print Preview
			mobjClsDataFileReport = new clsDataFileReport();
			mobjClsDataFileReport.DefaultFont = this.DefaultFont;
			mobjClsDataFileReport.funcPrintD2Peak(AASD2EnergyPeak486, AASD2EnergyPeak656);
		//AASD2EnergyPeak486.PrintPreViewGraph()
		//AASD2EnergyPeak656.PrintPreViewGraph()

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
			mobjClsDataFileReport = null;
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

}
