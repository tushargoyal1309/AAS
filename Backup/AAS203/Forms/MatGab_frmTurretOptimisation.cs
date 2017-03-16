using AAS203.Common;
using BgThread;
//'this is like supporting files.
//'class behind the class.
public class frmTurretOptimisation : System.Windows.Forms.Form, BgThread.Iclient
{

	#Region " Windows Form Designer generated code "

	public frmTurretOptimisation()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call

	}

	public frmTurretOptimisation(double dblLampCurrent, int intLampPos)
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
		mdblLampCurrent = dblLampCurrent;
		mintLampPosition = intLampPos;

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
	internal GradientPanel.CustomPanel CustomPanel1;
	internal System.Windows.Forms.Button btnClose;
	internal AAS203.AASGraph aasGraphTurretOptimisation;
	internal GradientPanel.CustomPanel CustomPanel2;
	internal System.Windows.Forms.Label lblTurretOptimisation;
	internal System.Windows.Forms.Label lblTurretPosition;
	internal System.Windows.Forms.Label lblPMT;
	internal System.Windows.Forms.Label lblWavelengthStatus;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmTurretOptimisation));
		this.CustomPanelMain = new GradientPanel.CustomPanel();
		this.CustomPanel1 = new GradientPanel.CustomPanel();
		this.aasGraphTurretOptimisation = new AAS203.AASGraph();
		this.CustomPanel2 = new GradientPanel.CustomPanel();
		this.lblWavelengthStatus = new System.Windows.Forms.Label();
		this.lblTurretOptimisation = new System.Windows.Forms.Label();
		this.lblTurretPosition = new System.Windows.Forms.Label();
		this.btnClose = new System.Windows.Forms.Button();
		this.lblPMT = new System.Windows.Forms.Label();
		this.CustomPanelMain.SuspendLayout();
		this.CustomPanel1.SuspendLayout();
		this.CustomPanel2.SuspendLayout();
		this.SuspendLayout();
		//
		//CustomPanelMain
		//
		this.CustomPanelMain.BackColor = System.Drawing.Color.Transparent;
		this.CustomPanelMain.Controls.Add(this.CustomPanel1);
		this.CustomPanelMain.Controls.Add(this.CustomPanel2);
		this.CustomPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanelMain.Location = new System.Drawing.Point(0, 0);
		this.CustomPanelMain.Name = "CustomPanelMain";
		this.CustomPanelMain.Size = new System.Drawing.Size(404, 405);
		this.CustomPanelMain.TabIndex = 0;
		//
		//CustomPanel1
		//
		this.CustomPanel1.BackColor = System.Drawing.Color.Transparent;
		this.CustomPanel1.Controls.Add(this.aasGraphTurretOptimisation);
		this.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanel1.Location = new System.Drawing.Point(0, 0);
		this.CustomPanel1.Name = "CustomPanel1";
		this.CustomPanel1.Size = new System.Drawing.Size(404, 305);
		this.CustomPanel1.TabIndex = 0;
		//
		//aasGraphTurretOptimisation
		//
		this.aasGraphTurretOptimisation.AldysGraphCursor = null;
		this.aasGraphTurretOptimisation.AldysGraphPrintColor = System.Drawing.Color.Black;
		this.aasGraphTurretOptimisation.BackColor = System.Drawing.Color.LightGray;
		this.aasGraphTurretOptimisation.Dock = System.Windows.Forms.DockStyle.Fill;
		this.aasGraphTurretOptimisation.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.aasGraphTurretOptimisation.GraphDataSource = null;
		this.aasGraphTurretOptimisation.GraphImage = null;
		this.aasGraphTurretOptimisation.IsShowGrid = true;
		this.aasGraphTurretOptimisation.Location = new System.Drawing.Point(0, 0);
		this.aasGraphTurretOptimisation.Name = "aasGraphTurretOptimisation";
		this.aasGraphTurretOptimisation.Size = new System.Drawing.Size(404, 305);
		this.aasGraphTurretOptimisation.TabIndex = 3;
		this.aasGraphTurretOptimisation.UseDefaultSettings = false;
		this.aasGraphTurretOptimisation.XAxisDateMax = new System.DateTime((long)0);
		this.aasGraphTurretOptimisation.XAxisDateMin = new System.DateTime((long)0);
		this.aasGraphTurretOptimisation.XAxisDateScaleFormat = AAS203.AASGraph.enumDateScaleFormat.YYYY;
		this.aasGraphTurretOptimisation.XAxisLabel = "TURRET STEP";
		this.aasGraphTurretOptimisation.XAxisMax = 100;
		this.aasGraphTurretOptimisation.XAxisMin = 0;
		this.aasGraphTurretOptimisation.XAxisMinorStep = 5;
		this.aasGraphTurretOptimisation.XAxisScaleFormat = null;
		this.aasGraphTurretOptimisation.XAxisStep = 10;
		this.aasGraphTurretOptimisation.XAxisType = AldysGraph.AxisType.Linear;
		this.aasGraphTurretOptimisation.YAxisLabel = "ENERGY";
		this.aasGraphTurretOptimisation.YAxisMax = 100;
		this.aasGraphTurretOptimisation.YAxisMin = 0;
		this.aasGraphTurretOptimisation.YAxisMinorStep = 5;
		this.aasGraphTurretOptimisation.YAxisScaleFormat = null;
		this.aasGraphTurretOptimisation.YAxisStep = 10;
		this.aasGraphTurretOptimisation.YAxisType = AldysGraph.AxisType.Linear;
		//
		//CustomPanel2
		//
		this.CustomPanel2.BackColor = System.Drawing.Color.Transparent;
		this.CustomPanel2.Controls.Add(this.lblWavelengthStatus);
		this.CustomPanel2.Controls.Add(this.lblTurretOptimisation);
		this.CustomPanel2.Controls.Add(this.lblTurretPosition);
		this.CustomPanel2.Controls.Add(this.btnClose);
		this.CustomPanel2.Controls.Add(this.lblPMT);
		this.CustomPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.CustomPanel2.Location = new System.Drawing.Point(0, 305);
		this.CustomPanel2.Name = "CustomPanel2";
		this.CustomPanel2.Size = new System.Drawing.Size(404, 100);
		this.CustomPanel2.TabIndex = 4;
		//
		//lblWavelengthStatus
		//
		this.lblWavelengthStatus.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblWavelengthStatus.ForeColor = System.Drawing.Color.Blue;
		this.lblWavelengthStatus.Location = new System.Drawing.Point(5, 71);
		this.lblWavelengthStatus.Name = "lblWavelengthStatus";
		this.lblWavelengthStatus.Size = new System.Drawing.Size(210, 24);
		this.lblWavelengthStatus.TabIndex = 4;
		//
		//lblTurretOptimisation
		//
		this.lblTurretOptimisation.BackColor = System.Drawing.Color.White;
		this.lblTurretOptimisation.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblTurretOptimisation.ForeColor = System.Drawing.Color.Blue;
		this.lblTurretOptimisation.Location = new System.Drawing.Point(5, 6);
		this.lblTurretOptimisation.Name = "lblTurretOptimisation";
		this.lblTurretOptimisation.Size = new System.Drawing.Size(395, 16);
		this.lblTurretOptimisation.TabIndex = 2;
		this.lblTurretOptimisation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblTurretPosition
		//
		this.lblTurretPosition.BackColor = System.Drawing.Color.White;
		this.lblTurretPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblTurretPosition.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblTurretPosition.ForeColor = System.Drawing.Color.Blue;
		this.lblTurretPosition.Location = new System.Drawing.Point(5, 44);
		this.lblTurretPosition.Name = "lblTurretPosition";
		this.lblTurretPosition.Size = new System.Drawing.Size(395, 16);
		this.lblTurretPosition.TabIndex = 0;
		this.lblTurretPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//btnClose
		//
		this.btnClose.Location = new System.Drawing.Point(320, 70);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(74, 22);
		this.btnClose.TabIndex = 3;
		this.btnClose.Text = "Close";
		this.btnClose.Visible = false;
		//
		//lblPMT
		//
		this.lblPMT.BackColor = System.Drawing.Color.White;
		this.lblPMT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblPMT.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPMT.ForeColor = System.Drawing.Color.Blue;
		this.lblPMT.Location = new System.Drawing.Point(5, 25);
		this.lblPMT.Name = "lblPMT";
		this.lblPMT.Size = new System.Drawing.Size(395, 16);
		this.lblPMT.TabIndex = 1;
		this.lblPMT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//frmTurretOptimisation
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.ClientSize = new System.Drawing.Size(404, 405);
		this.ControlBox = false;
		this.Controls.Add(this.CustomPanelMain);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmTurretOptimisation";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "TURRET OPTIMIZATION";
		this.CustomPanelMain.ResumeLayout(false);
		this.CustomPanel1.ResumeLayout(false);
		this.CustomPanel2.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Class Member Variables "

	private clsBgThread mController;
	private bool mblnStop = false;
	private double mdblLampCurrent;
	private int mintLampPosition;
	private int mintOccurence = 0;
	private int mintOccurence2 = 0;
	private int mintOccurence3 = 0;
	private int mintOccurence4 = 0;
	private int mintOccurence5 = 0;

	private int mintOccurence6 = 0;
	private clsBgTurretOptimization TurretOptimizationThread = new clsBgTurretOptimization();

	AldysGraph.CurveItem mobjCurve;
	#End Region

	#Region " Form Events "

	private void  // ERROR: Handles clauses are not supported in C#
frmTurretOptimisation_Load(object sender, System.EventArgs e)
	{
		//'  '=====================================================================
		// Procedure Name        : frmTurretOptimisation_Load
		// Parameters Passed     : 
		// Returns               : None
		// Purpose               : 
		// Description           : do some initialization here .
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 24-Jan-2007 04:15 pm
		// Revisions             : 1
		//=====================================================================
		//'note:
		//'this is called when form is loaded 
		//'do some initialization here .
		//'like setr the arrengement , setthe validation. etc.


		//used for uv graph control
		//agTurretOptimisation.xmin = 10
		//agTurretOptimisation.Xmax = 100
		//agTurretOptimisation.xdiv = 5
		//agTurretOptimisation.xlabel = "Turret Step"
		//agTurretOptimisation.ymin = 10
		//agTurretOptimisation.ymax = 100
		//agTurretOptimisation.ydiv = 5
		//agTurretOptimisation.ylabel = "Energy"
		//agTurretOptimisation.Refresh()

		//---Added By Mangesh 
		//update aasGraphTurretOptimisation data structure for graph display
		aasGraphTurretOptimisation.XAxisMin = 0;
		//Repalce 1 and added 0 by Saurabh 26 May 2007
		aasGraphTurretOptimisation.XAxisMax = 100;
		aasGraphTurretOptimisation.XAxisStep = 10;
		aasGraphTurretOptimisation.XAxisMinorStep = 5;
		aasGraphTurretOptimisation.XAxisLabel = "TURRET STEP";
		aasGraphTurretOptimisation.XAxisType = AldysGraph.AxisType.Linear;

		aasGraphTurretOptimisation.YAxisMin = 0;
		aasGraphTurretOptimisation.YAxisMax = 80;
		aasGraphTurretOptimisation.YAxisStep = 10;
		aasGraphTurretOptimisation.YAxisMinorStep = 5;
		aasGraphTurretOptimisation.YAxisLabel = "ENERGY";
		aasGraphTurretOptimisation.YAxisType = AldysGraph.AxisType.Linear;

		aasGraphTurretOptimisation.AldysPane.AxisChange();
		aasGraphTurretOptimisation.Invalidate();
		//---Added By Mangesh 

		btnClose.Visible = false;

	}

	private void  // ERROR: Handles clauses are not supported in C#
frmTurretOptimisation_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		//'  '=====================================================================
		// Procedure Name        : frmTurretOptimisation_Closing
		// Parameters Passed     : 
		// Returns               : None
		// Purpose               : 
		// Description           : to close the optimisation form.
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 24-Jan-2007 04:15 pm
		// Revisions             : 1
		//=====================================================================

		//'note:
		//'this is called when user close the form.
		//'stop the thread here if it running.
		if (mController.IsThreadRunning) {
			mController.Cancel();
		}
	}

	#End Region

	#Region " IClient Events for receiving the Turrent Position value from thread "

	public void BgThread.Iclient.Completed(bool Cancelled)
	{
		//'  '=====================================================================
		// Procedure Name        : Completed
		// Parameters Passed     : 
		// Returns               : bool flag for cancel.
		// Purpose               : 
		// Description           : to completed the thread.
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 24-Jan-2007 04:15 pm
		// Revisions             : 1
		//=====================================================================
		if (Cancelled == false) {
			//Me.DialogResult = DialogResult.OK
			//btnClose.Visible = True

			//---Added By Mangesh 
			if (!IsNothing(mobjCurve)) {
				aasGraphTurretOptimisation.StopOnlineGraph(mobjCurve);
				//'stop the online graph here.
				aasGraphTurretOptimisation.DrawHighestPeakLine(mobjCurve);
				//Draw highest peak line
				aasGraphTurretOptimisation.ShowHighPeakLineLabel("Optimized Position", false, 0);
				//show highpeakline label
			}
		//mblnStop = True
		//---Added By Mangesh 
		//Me.DialogResult = DialogResult.OK
		} else {
			mblnStop = true;
			this.DialogResult = DialogResult.OK;
		}
	}

	public void BgThread.Iclient.Display(string Text)
	{
		//'  '=====================================================================
		// Procedure Name        : Display
		// Parameters Passed     : 
		// Returns               : string to be displayed.
		// Purpose               : 
		// Description           : for displaying a graph.
		// Assumptions           : 
		// Dependencies          : 
		// Author                : 
		// Created               : 24-Jan-2007 04:15 pm
		// Revisions             : 1
		//=====================================================================
		string[] strDataValues;
		double dblX;
		double dblY;
		int intOcc;
		try {
			if (!Text == string.Empty) {
				strDataValues = Text.Split(',');
				//'split a passed string and stroe it a string variable.


				if (strDataValues.Length > 0) {
					dblX = (double)strDataValues(0);
					dblY = (double)strDataValues(1);
					intOcc = (int)strDataValues(2);
					//'get a seprated value from string 
					//'like x,y value.

					switch (intOcc) {
						case 1:
							mintOccurence = mintOccurence + 1;
							if (mintOccurence == 1) {
								mobjCurve = aasGraphTurretOptimisation.StartOnlineGraph("ENERGY", Color.Red, AldysGraph.SymbolType.NoSymbol);
								aasGraphTurretOptimisation.PlotPoint(mobjCurve, dblX, dblY);
							} else {
								aasGraphTurretOptimisation.PlotPoint(mobjCurve, dblX, dblY);
							}
						case 2:
							mintOccurence2 = mintOccurence2 + 1;
							if (mintOccurence2 == 1) {
								mobjCurve = aasGraphTurretOptimisation.StartOnlineGraph("ENERGY", Color.Red, AldysGraph.SymbolType.NoSymbol);
								aasGraphTurretOptimisation.PlotPoint(mobjCurve, dblX, dblY);
							} else {
								aasGraphTurretOptimisation.PlotPoint(mobjCurve, dblX, dblY);
							}
						case 3:
							mintOccurence3 = mintOccurence3 + 1;
							if (mintOccurence3 == 1) {
								mobjCurve = aasGraphTurretOptimisation.StartOnlineGraph("ENERGY", Color.Red, AldysGraph.SymbolType.NoSymbol);
								aasGraphTurretOptimisation.PlotPoint(mobjCurve, dblX, dblY);
							} else {
								aasGraphTurretOptimisation.PlotPoint(mobjCurve, dblX, dblY);
							}
						case 4:
							mintOccurence4 = mintOccurence4 + 1;
							if (mintOccurence4 == 1) {
								mobjCurve = aasGraphTurretOptimisation.StartOnlineGraph("ENERGY", Color.Red, AldysGraph.SymbolType.NoSymbol);
								aasGraphTurretOptimisation.PlotPoint(mobjCurve, dblX, dblY);
							} else {
								aasGraphTurretOptimisation.PlotPoint(mobjCurve, dblX, dblY);
							}
						case 5:
							mintOccurence5 = mintOccurence5 + 1;
							if (mintOccurence5 == 1) {
								mobjCurve = aasGraphTurretOptimisation.StartOnlineGraph("ENERGY", Color.Red, AldysGraph.SymbolType.NoSymbol);
								aasGraphTurretOptimisation.PlotPoint(mobjCurve, dblX, dblY);
							} else {
								aasGraphTurretOptimisation.PlotPoint(mobjCurve, dblX, dblY);
							}
						case 6:
							mintOccurence6 = mintOccurence6 + 1;
							if (mintOccurence6 == 1) {
								mobjCurve = aasGraphTurretOptimisation.StartOnlineGraph("ENERGY", Color.Red, AldysGraph.SymbolType.NoSymbol);
								aasGraphTurretOptimisation.PlotPoint(mobjCurve, dblX, dblY);
							} else {
								aasGraphTurretOptimisation.PlotPoint(mobjCurve, dblX, dblY);
							}
					}

					//update graph data structure
					aasGraphTurretOptimisation.AldysPane.XAxis.PickScale(aasGraphTurretOptimisation.XAxisMin, aasGraphTurretOptimisation.XAxisMax);
					aasGraphTurretOptimisation.AldysPane.XAxis.StepAuto = true;
					aasGraphTurretOptimisation.AldysPane.XAxis.MinorStepAuto = true;

					aasGraphTurretOptimisation.AldysPane.YAxis.PickScale(aasGraphTurretOptimisation.YAxisMin, aasGraphTurretOptimisation.YAxisMax);
					aasGraphTurretOptimisation.AldysPane.YAxis.StepAuto = true;
					aasGraphTurretOptimisation.AldysPane.YAxis.MinorStepAuto = true;

					aasGraphTurretOptimisation.AldysPane.AxisChange();
					aasGraphTurretOptimisation.Invalidate();

					Application.DoEvents();
					//'allow application to perfrom its panding work.

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

	public void BgThread.Iclient.Failed(System.Exception e)
	{
		//'not in used
	}

	public void BgThread.Iclient.Start(BgThread.clsBgThread clsBgThread)
	{
		//'not in used
	}

	#End Region

	#Region " Public Functions "


	public void StartOptimizeTread()
	{
		//'  '=====================================================================
		// Procedure Name        : StartOptimizeTread
		// Parameters Passed     : 
		// Returns               : 
		// Purpose               : 
		// Description           : for starting a thread.
		// Assumptions           : 
		// Dependencies          : 
		// Author                : 
		// Created               : 24-Jan-2007 04:15 pm
		// Revisions             : 1
		//=====================================================================
		//'note:
		//'this is used to start a thread 
		//'first initialise  the object of thread with needed info.
		//'then call a function for starting a thread.
		mController = new clsBgThread(this);

		//Saurabh 06-06-2007 added parameter lblWavelengthStatus
		//TurretOptimizationThread = New clsBgTurretOptimization(lblPMT, lblTurretPosition, lblTurretOptimisation, mdblLampCurrent, mintLampPosition, aasGraphTurretOptimisation)
		//create object for turret optimization thread
		TurretOptimizationThread = new clsBgTurretOptimization(lblPMT, lblTurretPosition, lblTurretOptimisation, mdblLampCurrent, mintLampPosition, aasGraphTurretOptimisation, lblWavelengthStatus);
		//Saurabh 06-06-2007

		//'TurretOptimizationThread = New clsBgTurretOptimization(lblPMT, lblTurretPosition, lblTurretOptimisation, mdblLampCurrent, mintLampPosition, aasGraphTurretOptimisation)
		//start turret optimization thread
		mController.Start(TurretOptimizationThread);

		//mController.Start(New clsBgTurretOptimization(mdblLampCurrent, mintLampPosition))
	}

	#End Region

	#Region " Private Functions"

	private void  // ERROR: Handles clauses are not supported in C#
btnClose_Click(System.Object sender, System.EventArgs e)
	{
		//'  '=====================================================================
		// Procedure Name        : btnClose_Click
		// Parameters Passed     : 
		// Returns               : 
		// Purpose               : 
		// Description           : for clodeing a form.
		// Assumptions           : 
		// Dependencies          : 
		// Author                : 
		// Created               : 24-Jan-2007 04:15 pm
		// Revisions             : 1
		//=====================================================================
		//update dialog result
		this.DialogResult = DialogResult.OK;
	}

	#End Region


}

