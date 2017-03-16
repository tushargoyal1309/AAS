using AAS203.Common;
using BgThread;
using AAS203.AASGraph;

public class frmZeroOrder2 : System.Windows.Forms.Form, BgThread.Iclient
{

	#Region " Windows Form Designer generated code "

	public frmZeroOrder2()
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
	internal GradientPanel.CustomPanel CustomPanelMain;
	internal GradientPanel.CustomPanel CustomPanel1;
	internal GradientPanel.CustomPanel CustomPanel2;
	internal System.Windows.Forms.Button btnClose;
	internal AAS203.AASGraph aasGraphOpt;
	internal System.Windows.Forms.Label lblTurretOptimisationOpt;
	internal System.Windows.Forms.Label lblPMTOpt;
	internal System.Windows.Forms.Label lblTurretPositionOpt;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmZeroOrder2));
		this.CustomPanelMain = new GradientPanel.CustomPanel();
		this.CustomPanel1 = new GradientPanel.CustomPanel();
		this.aasGraphOpt = new AAS203.AASGraph();
		this.CustomPanel2 = new GradientPanel.CustomPanel();
		this.lblTurretOptimisationOpt = new System.Windows.Forms.Label();
		this.lblPMTOpt = new System.Windows.Forms.Label();
		this.lblTurretPositionOpt = new System.Windows.Forms.Label();
		this.btnClose = new System.Windows.Forms.Button();
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
		this.CustomPanelMain.Size = new System.Drawing.Size(384, 385);
		this.CustomPanelMain.TabIndex = 0;
		//
		//CustomPanel1
		//
		this.CustomPanel1.BackColor = System.Drawing.Color.Transparent;
		this.CustomPanel1.Controls.Add(this.aasGraphOpt);
		this.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanel1.Location = new System.Drawing.Point(0, 0);
		this.CustomPanel1.Name = "CustomPanel1";
		this.CustomPanel1.Size = new System.Drawing.Size(384, 285);
		this.CustomPanel1.TabIndex = 0;
		//
		//aasGraphOpt
		//
		this.aasGraphOpt.AldysGraphCursor = null;
		this.aasGraphOpt.AldysGraphPrintColor = System.Drawing.Color.Black;
		this.aasGraphOpt.BackColor = System.Drawing.Color.LightGray;
		this.aasGraphOpt.Dock = System.Windows.Forms.DockStyle.Fill;
		this.aasGraphOpt.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.aasGraphOpt.GraphDataSource = null;
		this.aasGraphOpt.GraphImage = null;
		this.aasGraphOpt.IsShowGrid = true;
		this.aasGraphOpt.Location = new System.Drawing.Point(0, 0);
		this.aasGraphOpt.Name = "aasGraphOpt";
		this.aasGraphOpt.Size = new System.Drawing.Size(384, 285);
		this.aasGraphOpt.TabIndex = 5;
		this.aasGraphOpt.UseDefaultSettings = false;
		this.aasGraphOpt.XAxisDateMax = new System.DateTime((long)0);
		this.aasGraphOpt.XAxisDateMin = new System.DateTime((long)0);
		this.aasGraphOpt.XAxisDateScaleFormat = AAS203.AASGraph.enumDateScaleFormat.YYYY;
		this.aasGraphOpt.XAxisLabel = "TURRET POSITION";
		this.aasGraphOpt.XAxisMax = 100;
		this.aasGraphOpt.XAxisMin = 0;
		this.aasGraphOpt.XAxisMinorStep = 5;
		this.aasGraphOpt.XAxisScaleFormat = null;
		this.aasGraphOpt.XAxisStep = 10;
		this.aasGraphOpt.XAxisType = AldysGraph.AxisType.Linear;
		this.aasGraphOpt.YAxisLabel = "ENERGY";
		this.aasGraphOpt.YAxisMax = 100;
		this.aasGraphOpt.YAxisMin = 0;
		this.aasGraphOpt.YAxisMinorStep = 5;
		this.aasGraphOpt.YAxisScaleFormat = null;
		this.aasGraphOpt.YAxisStep = 10;
		this.aasGraphOpt.YAxisType = AldysGraph.AxisType.Linear;
		//
		//CustomPanel2
		//
		this.CustomPanel2.BackColor = System.Drawing.Color.Transparent;
		this.CustomPanel2.Controls.Add(this.lblTurretOptimisationOpt);
		this.CustomPanel2.Controls.Add(this.lblPMTOpt);
		this.CustomPanel2.Controls.Add(this.lblTurretPositionOpt);
		this.CustomPanel2.Controls.Add(this.btnClose);
		this.CustomPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.CustomPanel2.Location = new System.Drawing.Point(0, 285);
		this.CustomPanel2.Name = "CustomPanel2";
		this.CustomPanel2.Size = new System.Drawing.Size(384, 100);
		this.CustomPanel2.TabIndex = 1;
		//
		//lblTurretOptimisationOpt
		//
		this.lblTurretOptimisationOpt.BackColor = System.Drawing.Color.White;
		this.lblTurretOptimisationOpt.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblTurretOptimisationOpt.ForeColor = System.Drawing.Color.Blue;
		this.lblTurretOptimisationOpt.Location = new System.Drawing.Point(6, 8);
		this.lblTurretOptimisationOpt.Name = "lblTurretOptimisationOpt";
		this.lblTurretOptimisationOpt.Size = new System.Drawing.Size(374, 16);
		this.lblTurretOptimisationOpt.TabIndex = 2;
		//
		//lblPMTOpt
		//
		this.lblPMTOpt.BackColor = System.Drawing.Color.White;
		this.lblPMTOpt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblPMTOpt.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPMTOpt.ForeColor = System.Drawing.Color.Blue;
		this.lblPMTOpt.Location = new System.Drawing.Point(6, 26);
		this.lblPMTOpt.Name = "lblPMTOpt";
		this.lblPMTOpt.Size = new System.Drawing.Size(374, 16);
		this.lblPMTOpt.TabIndex = 1;
		//
		//lblTurretPositionOpt
		//
		this.lblTurretPositionOpt.BackColor = System.Drawing.Color.White;
		this.lblTurretPositionOpt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblTurretPositionOpt.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblTurretPositionOpt.ForeColor = System.Drawing.Color.Blue;
		this.lblTurretPositionOpt.Location = new System.Drawing.Point(6, 46);
		this.lblTurretPositionOpt.Name = "lblTurretPositionOpt";
		this.lblTurretPositionOpt.Size = new System.Drawing.Size(374, 16);
		this.lblTurretPositionOpt.TabIndex = 0;
		//
		//btnClose
		//
		this.btnClose.Location = new System.Drawing.Point(5, 70);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(74, 22);
		this.btnClose.TabIndex = 3;
		this.btnClose.Text = "Close";
		this.btnClose.Visible = false;
		//
		//frmZeroOrder2
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.ClientSize = new System.Drawing.Size(384, 385);
		this.ControlBox = false;
		this.Controls.Add(this.CustomPanelMain);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmZeroOrder2";
		this.ShowInTaskbar = false;
		this.Text = "Optimization";
		this.TopMost = true;
		this.CustomPanelMain.ResumeLayout(false);
		this.CustomPanel1.ResumeLayout(false);
		this.CustomPanel2.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Class Member Variables "
	private clsBgThread mController;
	private bool mblnStop = false;
	private clsBgOptimizeAll OptThread;
	private int mintOccurence;
	private AldysGraph.CurveItem mobjCurve;
	private double mdblYaxis;
		#End Region
	private double mdblXaxis;

	#Region " IClient Events for receiving the Turrent Position value from thread "
	//'this are the thread realted function.
	public void BgThread.Iclient.Completed(bool Cancelled)
	{
		//=====================================================================
		// Procedure Name        : Completed
		// Parameters Passed     : Canceled
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : Saturday, January 22, 2005
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is called form thread 
		//'this will used to perfrom a completion event of a thread.
		if (Cancelled == false) {
			//btnClose.Visible = True
			if (!IsNothing(mobjCurve)) {
				aasGraphOpt.StopOnlineGraph(mobjCurve);
				//'stop a onlinegraph
				aasGraphOpt.DrawHighestPeakLine(mobjCurve);
				//'draw highest peak line
				aasGraphOpt.ShowHighPeakLineLabel(" Optimized Position", false, 0);
			}
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
		// Returns               : None
		// Purpose               : 
		// Description           :''here we have to pass the string to be disply. 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 24-Jan-2007 04:15 pm
		// Revisions             : 1
		//=====================================================================
		//'note:
		//'here we have to pass the string to be disply.
		string[] strDataValues;
		double dblX;
		double dblY;

		try {
			if (!Text == string.Empty) {
				strDataValues = Text.Split(",");
				//'split a passed string and store it in a temp string variable.

				if (strDataValues.Length > 0) {
					mintOccurence = mintOccurence + 1;

					dblX = (double)strDataValues(0);
					dblY = (double)strDataValues(1);
					//'now get a x,y value from the passed string.
					if (mintOccurence == 1) {
						mobjCurve = aasGraphOpt.StartOnlineGraph("ENERGY", Color.Red, AldysGraph.SymbolType.NoSymbol);
					//'this will display a online graph as par passed string
					} else {
						aasGraphOpt.PlotPoint(mobjCurve, dblX, dblY);
						//'this will plot a point with respect to the value passed by a string.
					}

					mdblYaxis = dblY;
					mdblXaxis = dblX;

					aasGraphOpt.AldysPane.AxisChange();
					//'for axis change.
					aasGraphOpt.Invalidate();
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

	public void StartOptTread()
	{
		//'  '=====================================================================
		// Procedure Name        : StartOptTread
		// Parameters Passed     : 
		// Returns               : None
		// Purpose               : 
		// Description           : to start the thread 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 24-Jan-2007 04:15 pm
		// Revisions             : 1
		//=====================================================================
		//'note:
		//'this is used to start the thread.
		//'first initialise a thread object with current value
		//'then start a thread with that value.
		mController = new clsBgThread(this);
		OptThread = new clsBgOptimizeAll(lblPMTOpt, lblTurretPositionOpt, lblTurretOptimisationOpt, aasGraphOpt);
		mController.Start(OptThread);
		//'for starting a thread.
	}

	#End Region

	#Region "Private Functions"
	private void  // ERROR: Handles clauses are not supported in C#
btnClose_Click(System.Object sender, System.EventArgs e)
	{
		//'  '=====================================================================
		// Procedure Name        : btnClose_Click
		// Parameters Passed     : 
		// Returns               : None
		// Purpose               : 
		// Description           : to close the form.
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 24-Jan-2007 04:15 pm
		// Revisions             : 1
		//=====================================================================
		this.DialogResult = DialogResult.OK;
	}
	#End Region

}
