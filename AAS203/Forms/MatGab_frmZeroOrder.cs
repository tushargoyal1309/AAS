using AAS203.Common;
using BgThread;
using AAS203.AASGraph;

public class frmZeroOrder : System.Windows.Forms.Form, BgThread.Iclient
{

	#Region " Windows Form Designer generated code "

	public frmZeroOrder()
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
	internal System.Windows.Forms.Button btnClose;
	internal AAS203.AASGraph aasGraphZeroOrder;
	internal GradientPanel.CustomPanel CustomPanel2;
	internal System.Windows.Forms.Label lblPMTZeroOrder;
	internal System.Windows.Forms.Label lblTurretPositionZeroOrder;
	internal System.Windows.Forms.Label lblTurretOptimisationZeroOrder;
	internal System.Windows.Forms.Label lblWavelengthStatus;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmZeroOrder));
		this.CustomPanelMain = new GradientPanel.CustomPanel();
		this.CustomPanel1 = new GradientPanel.CustomPanel();
		this.aasGraphZeroOrder = new AAS203.AASGraph();
		this.CustomPanel2 = new GradientPanel.CustomPanel();
		this.lblWavelengthStatus = new System.Windows.Forms.Label();
		this.lblPMTZeroOrder = new System.Windows.Forms.Label();
		this.lblTurretPositionZeroOrder = new System.Windows.Forms.Label();
		this.lblTurretOptimisationZeroOrder = new System.Windows.Forms.Label();
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
		this.CustomPanel1.Controls.Add(this.aasGraphZeroOrder);
		this.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanel1.Location = new System.Drawing.Point(0, 0);
		this.CustomPanel1.Name = "CustomPanel1";
		this.CustomPanel1.Size = new System.Drawing.Size(384, 285);
		this.CustomPanel1.TabIndex = 0;
		//
		//aasGraphZeroOrder
		//
		this.aasGraphZeroOrder.AldysGraphCursor = null;
		this.aasGraphZeroOrder.AldysGraphPrintColor = System.Drawing.Color.Black;
		this.aasGraphZeroOrder.BackColor = System.Drawing.Color.LightGray;
		this.aasGraphZeroOrder.Dock = System.Windows.Forms.DockStyle.Fill;
		this.aasGraphZeroOrder.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.aasGraphZeroOrder.GraphDataSource = null;
		this.aasGraphZeroOrder.GraphImage = null;
		this.aasGraphZeroOrder.IsShowGrid = true;
		this.aasGraphZeroOrder.Location = new System.Drawing.Point(0, 0);
		this.aasGraphZeroOrder.Name = "aasGraphZeroOrder";
		this.aasGraphZeroOrder.Size = new System.Drawing.Size(384, 285);
		this.aasGraphZeroOrder.TabIndex = 4;
		this.aasGraphZeroOrder.UseDefaultSettings = false;
		this.aasGraphZeroOrder.XAxisDateMax = new System.DateTime((long)0);
		this.aasGraphZeroOrder.XAxisDateMin = new System.DateTime((long)0);
		this.aasGraphZeroOrder.XAxisDateScaleFormat = AAS203.AASGraph.enumDateScaleFormat.YYYY;
		this.aasGraphZeroOrder.XAxisLabel = "WAVELENGTH (nm)";
		this.aasGraphZeroOrder.XAxisMax = 4;
		this.aasGraphZeroOrder.XAxisMin = -2;
		this.aasGraphZeroOrder.XAxisMinorStep = 1;
		this.aasGraphZeroOrder.XAxisScaleFormat = "";
		this.aasGraphZeroOrder.XAxisStep = 1;
		this.aasGraphZeroOrder.XAxisType = AldysGraph.AxisType.Linear;
		this.aasGraphZeroOrder.YAxisLabel = "ENERGY";
		this.aasGraphZeroOrder.YAxisMax = 100;
		this.aasGraphZeroOrder.YAxisMin = 0;
		this.aasGraphZeroOrder.YAxisMinorStep = 5;
		this.aasGraphZeroOrder.YAxisScaleFormat = null;
		this.aasGraphZeroOrder.YAxisStep = 10;
		this.aasGraphZeroOrder.YAxisType = AldysGraph.AxisType.Linear;
		//
		//CustomPanel2
		//
		this.CustomPanel2.BackColor = System.Drawing.Color.Transparent;
		this.CustomPanel2.Controls.Add(this.lblWavelengthStatus);
		this.CustomPanel2.Controls.Add(this.lblPMTZeroOrder);
		this.CustomPanel2.Controls.Add(this.lblTurretPositionZeroOrder);
		this.CustomPanel2.Controls.Add(this.lblTurretOptimisationZeroOrder);
		this.CustomPanel2.Controls.Add(this.btnClose);
		this.CustomPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.CustomPanel2.Location = new System.Drawing.Point(0, 285);
		this.CustomPanel2.Name = "CustomPanel2";
		this.CustomPanel2.Size = new System.Drawing.Size(384, 100);
		this.CustomPanel2.TabIndex = 4;
		//
		//lblWavelengthStatus
		//
		this.lblWavelengthStatus.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblWavelengthStatus.ForeColor = System.Drawing.Color.Blue;
		this.lblWavelengthStatus.Location = new System.Drawing.Point(4, 70);
		this.lblWavelengthStatus.Name = "lblWavelengthStatus";
		this.lblWavelengthStatus.Size = new System.Drawing.Size(210, 24);
		this.lblWavelengthStatus.TabIndex = 5;
		//
		//lblPMTZeroOrder
		//
		this.lblPMTZeroOrder.BackColor = System.Drawing.Color.White;
		this.lblPMTZeroOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblPMTZeroOrder.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPMTZeroOrder.ForeColor = System.Drawing.Color.Blue;
		this.lblPMTZeroOrder.Location = new System.Drawing.Point(4, 27);
		this.lblPMTZeroOrder.Name = "lblPMTZeroOrder";
		this.lblPMTZeroOrder.Size = new System.Drawing.Size(376, 16);
		this.lblPMTZeroOrder.TabIndex = 1;
		//
		//lblTurretPositionZeroOrder
		//
		this.lblTurretPositionZeroOrder.BackColor = System.Drawing.Color.White;
		this.lblTurretPositionZeroOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblTurretPositionZeroOrder.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblTurretPositionZeroOrder.ForeColor = System.Drawing.Color.Blue;
		this.lblTurretPositionZeroOrder.Location = new System.Drawing.Point(4, 47);
		this.lblTurretPositionZeroOrder.Name = "lblTurretPositionZeroOrder";
		this.lblTurretPositionZeroOrder.Size = new System.Drawing.Size(376, 16);
		this.lblTurretPositionZeroOrder.TabIndex = 0;
		//
		//lblTurretOptimisationZeroOrder
		//
		this.lblTurretOptimisationZeroOrder.BackColor = System.Drawing.Color.White;
		this.lblTurretOptimisationZeroOrder.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblTurretOptimisationZeroOrder.ForeColor = System.Drawing.Color.Blue;
		this.lblTurretOptimisationZeroOrder.Location = new System.Drawing.Point(4, 7);
		this.lblTurretOptimisationZeroOrder.Name = "lblTurretOptimisationZeroOrder";
		this.lblTurretOptimisationZeroOrder.Size = new System.Drawing.Size(376, 16);
		this.lblTurretOptimisationZeroOrder.TabIndex = 2;
		//
		//btnClose
		//
		this.btnClose.Location = new System.Drawing.Point(306, 70);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(74, 22);
		this.btnClose.TabIndex = 3;
		this.btnClose.Text = "Close";
		this.btnClose.Visible = false;
		//
		//frmZeroOrder
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
		this.Name = "frmZeroOrder";
		this.ShowInTaskbar = false;
		this.Text = "Zero Order";
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
	private clsBgZeroOrder ZeroOrderThread;
	private int mintOccurence;
	private int mintOccurence1;
	private AldysGraph.CurveItem mobjCurve;
	private double mdblYaxis;

	private double mdblXaxis;
	#End Region

	#Region " Form Events "

	private void  // ERROR: Handles clauses are not supported in C#
frmTurretOptimisation_Load(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmTurretOptimisation_Load
		// Parameters Passed     : object, EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 24-Jan-2007 04:15 pm
		// Revisions             : 
		//=====================================================================
		//---set graph properties
		aasGraphZeroOrder.XAxisMin = -2;
		aasGraphZeroOrder.XAxisMax = 4;
		aasGraphZeroOrder.YAxisLabel = "ENERGY";
		aasGraphZeroOrder.XAxisLabel = "WAVELENGTH (nm)";
		aasGraphZeroOrder.XAxisMinorStep = 1;
		aasGraphZeroOrder.XAxisStep = 1;

		aasGraphZeroOrder.AldysPane.XAxis.PickScale(-2, 4);
		aasGraphZeroOrder.AldysPane.XAxis.MinorStepAuto = true;
		aasGraphZeroOrder.AldysPane.XAxis.StepAuto = true;
		aasGraphZeroOrder.Refresh();
	}

	#End Region

	#Region " IClient Events for receiving the Turrent Position value from thread "

	public void BgThread.Iclient.Completed(bool Cancelled)
	{
		//=====================================================================
		// Procedure Name        : Completed
		// Parameters Passed     : Cancelled
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 24-Jan-2007 04:15 pm
		// Revisions             : praveen
		//=====================================================================
		//'this is realted to thread
		//'this will show completion.
		if (Cancelled == false) {
			mblnStop = true;
			//btnClose.Visible = True
			this.DialogResult = DialogResult.OK;
		} else {
			if (!IsNothing(mobjCurve)) {
				aasGraphZeroOrder.StopOnlineGraph(mobjCurve);
				aasGraphZeroOrder.DrawHighestPeakLine(mobjCurve);
				aasGraphZeroOrder.ShowHighPeakLineLabel(" Wavelength", false, 0);
			}
		}
	}

	public void BgThread.Iclient.Display(string Text)
	{
		//=====================================================================
		// Procedure Name        : Display
		// Parameters Passed     : Text
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 24-Jan-2007 04:15 pm
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is used by a thread.
		//'this is used for the display of value on the screen.
		//'here we have to pass a string to be display.
		string[] strDataValues;
		double dblX;
		double dblY;

		try {
			if (!Text == string.Empty) {
				strDataValues = Text.Split(",");
				//'split a given string
				if (strDataValues.Length > 0) {
					mintOccurence = mintOccurence + 1;

					dblX = (double)strDataValues(0);
					dblY = (double)strDataValues(1);
					//'get a value for both the axis value
					if (mintOccurence == 1) {
						mobjCurve = aasGraphZeroOrder.StartOnlineGraph("ENERGY", Color.Red, AldysGraph.SymbolType.NoSymbol);
					//'this will start a online graph as par passed value
					} else {
						aasGraphZeroOrder.PlotPoint(mobjCurve, dblX, dblY);
						//'this will plot a point on a graph
						//'so that graph will display.
					}

					mdblYaxis = dblY;
					mdblXaxis = dblX;

					aasGraphZeroOrder.AldysPane.AxisChange();
					aasGraphZeroOrder.Invalidate();
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
		//=====================================================================
		// Procedure Name        : StartOptimizeTread
		// Parameters Passed     : 
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 24-Jan-2007 04:15 pm
		// Revisions             : 1
		//=====================================================================
		//'note:
		//'this will start the optimize thread 
		//'and let the thread to perfrom all function.

		mController = new clsBgThread(this);

		ZeroOrderThread = new clsBgZeroOrder(lblPMTZeroOrder, lblTurretPositionZeroOrder, lblTurretOptimisationZeroOrder, aasGraphZeroOrder, lblWavelengthStatus);
		//Saurabh 06-06-2007

		mController.Start(ZeroOrderThread);
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
		// Purpose               : this is called when user closed them form
		// Description           : for closing a form.
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 24-Jan-2007 04:15 pm
		// Revisions             : 1
		//=====================================================================
		//'note:
		//'this called when user clicked on close buton
		this.Close();
		this.Dispose();
	}
	#End Region

}
