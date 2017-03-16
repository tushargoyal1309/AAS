using BgThread;
using AAS203.Common;


public class frmBurnerOptimisation : System.Windows.Forms.Form, BgThread.Iclient
{

	// This form object is used to perform opration for Burner height optimisation and 
	// Fuel optimisation

	#Region " Class Member Variables "

	private clsBgThread mController;
	private AldysGraph.Defaults objDefaultSettings;
	private bool mblnStop = false;
	private double mdblLampCurrent;
	private int mintLampPosition;
	private int mintOccurence = 0;
	private double mdblYaxis;
	private double mdblXaxis;
	private clsBgBurnerOptimization BHOptimizationThread = new clsBgBurnerOptimization();

	AldysGraph.CurveItem mobjCurve;
	private double mdblMaxXaxis;
	private double mdblMaxYaxis = 3.0;
	private double mdblMinXaxis;
	private double mdblMinYaxis = 0.0;
	//Private mblnAvoideProcess As Boolean = False
	//Public BurnerHeightParameter As Object

	#End Region

	#Region " Windows Form Designer generated code "

	public frmBurnerOptimisation()
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
	internal GradientPanel.CustomPanel CustomPanel2;
	internal System.Windows.Forms.Button btnClose;
	internal GradientPanel.CustomPanel CustomPanel1;
	internal AAS203.AASGraph aasGraphOptimisation;
	internal GradientPanel.CustomPanel custPnlInstConditions;
	internal System.Windows.Forms.Label lblBurnerFlame;
	internal System.Windows.Forms.Label lblWavelength;
	internal System.Windows.Forms.Label lblSlitWidth;
	internal System.Windows.Forms.Label lblLampCurrent;
	internal System.Windows.Forms.Label lblElementName;
	internal System.Windows.Forms.Label lblInstConditions;
	internal System.Windows.Forms.Label lblBH;
	internal System.Windows.Forms.Label lblPosition;
	internal System.Windows.Forms.Label lblOptimisation;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmBurnerOptimisation));
		this.CustomPanelMain = new GradientPanel.CustomPanel();
		this.CustomPanel2 = new GradientPanel.CustomPanel();
		this.custPnlInstConditions = new GradientPanel.CustomPanel();
		this.lblBurnerFlame = new System.Windows.Forms.Label();
		this.lblWavelength = new System.Windows.Forms.Label();
		this.lblSlitWidth = new System.Windows.Forms.Label();
		this.lblLampCurrent = new System.Windows.Forms.Label();
		this.lblElementName = new System.Windows.Forms.Label();
		this.lblInstConditions = new System.Windows.Forms.Label();
		this.lblBH = new System.Windows.Forms.Label();
		this.lblPosition = new System.Windows.Forms.Label();
		this.lblOptimisation = new System.Windows.Forms.Label();
		this.btnClose = new System.Windows.Forms.Button();
		this.CustomPanel1 = new GradientPanel.CustomPanel();
		this.aasGraphOptimisation = new AAS203.AASGraph();
		this.CustomPanelMain.SuspendLayout();
		this.CustomPanel2.SuspendLayout();
		this.custPnlInstConditions.SuspendLayout();
		this.CustomPanel1.SuspendLayout();
		this.SuspendLayout();
		//
		//CustomPanelMain
		//
		this.CustomPanelMain.BackColor = System.Drawing.Color.Transparent;
		this.CustomPanelMain.Controls.Add(this.CustomPanel2);
		this.CustomPanelMain.Controls.Add(this.CustomPanel1);
		this.CustomPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanelMain.Location = new System.Drawing.Point(0, 0);
		this.CustomPanelMain.Name = "CustomPanelMain";
		this.CustomPanelMain.Size = new System.Drawing.Size(458, 455);
		this.CustomPanelMain.TabIndex = 1;
		//
		//CustomPanel2
		//
		this.CustomPanel2.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanel2.Controls.Add(this.custPnlInstConditions);
		this.CustomPanel2.Controls.Add(this.lblBH);
		this.CustomPanel2.Controls.Add(this.lblPosition);
		this.CustomPanel2.Controls.Add(this.lblOptimisation);
		this.CustomPanel2.Controls.Add(this.btnClose);
		this.CustomPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.CustomPanel2.Location = new System.Drawing.Point(0, 327);
		this.CustomPanel2.Name = "CustomPanel2";
		this.CustomPanel2.Size = new System.Drawing.Size(458, 128);
		this.CustomPanel2.TabIndex = 1;
		//
		//custPnlInstConditions
		//
		this.custPnlInstConditions.BackColor = System.Drawing.Color.Transparent;
		this.custPnlInstConditions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.custPnlInstConditions.Controls.Add(this.lblBurnerFlame);
		this.custPnlInstConditions.Controls.Add(this.lblWavelength);
		this.custPnlInstConditions.Controls.Add(this.lblSlitWidth);
		this.custPnlInstConditions.Controls.Add(this.lblLampCurrent);
		this.custPnlInstConditions.Controls.Add(this.lblElementName);
		this.custPnlInstConditions.Controls.Add(this.lblInstConditions);
		this.custPnlInstConditions.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.custPnlInstConditions.Location = new System.Drawing.Point(0, 74);
		this.custPnlInstConditions.Name = "custPnlInstConditions";
		this.custPnlInstConditions.Size = new System.Drawing.Size(458, 54);
		this.custPnlInstConditions.TabIndex = 5;
		//
		//lblBurnerFlame
		//
		this.lblBurnerFlame.BackColor = System.Drawing.Color.White;
		this.lblBurnerFlame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblBurnerFlame.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblBurnerFlame.ForeColor = System.Drawing.Color.Blue;
		this.lblBurnerFlame.Location = new System.Drawing.Point(364, 8);
		this.lblBurnerFlame.Name = "lblBurnerFlame";
		this.lblBurnerFlame.Size = new System.Drawing.Size(74, 16);
		this.lblBurnerFlame.TabIndex = 5;
		//
		//lblWavelength
		//
		this.lblWavelength.BackColor = System.Drawing.Color.White;
		this.lblWavelength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblWavelength.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblWavelength.ForeColor = System.Drawing.Color.Blue;
		this.lblWavelength.Location = new System.Drawing.Point(148, 29);
		this.lblWavelength.Name = "lblWavelength";
		this.lblWavelength.Size = new System.Drawing.Size(150, 16);
		this.lblWavelength.TabIndex = 4;
		//
		//lblSlitWidth
		//
		this.lblSlitWidth.BackColor = System.Drawing.Color.White;
		this.lblSlitWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblSlitWidth.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSlitWidth.ForeColor = System.Drawing.Color.Blue;
		this.lblSlitWidth.Location = new System.Drawing.Point(314, 29);
		this.lblSlitWidth.Name = "lblSlitWidth";
		this.lblSlitWidth.Size = new System.Drawing.Size(124, 16);
		this.lblSlitWidth.TabIndex = 3;
		//
		//lblLampCurrent
		//
		this.lblLampCurrent.BackColor = System.Drawing.Color.White;
		this.lblLampCurrent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblLampCurrent.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblLampCurrent.ForeColor = System.Drawing.Color.Blue;
		this.lblLampCurrent.Location = new System.Drawing.Point(10, 29);
		this.lblLampCurrent.Name = "lblLampCurrent";
		this.lblLampCurrent.Size = new System.Drawing.Size(120, 16);
		this.lblLampCurrent.TabIndex = 2;
		//
		//lblElementName
		//
		this.lblElementName.BackColor = System.Drawing.Color.White;
		this.lblElementName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblElementName.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblElementName.ForeColor = System.Drawing.Color.Blue;
		this.lblElementName.Location = new System.Drawing.Point(246, 8);
		this.lblElementName.Name = "lblElementName";
		this.lblElementName.Size = new System.Drawing.Size(100, 16);
		this.lblElementName.TabIndex = 1;
		this.lblElementName.Text = "Element Name";
		//
		//lblInstConditions
		//
		this.lblInstConditions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblInstConditions.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblInstConditions.ForeColor = System.Drawing.Color.Blue;
		this.lblInstConditions.Location = new System.Drawing.Point(10, 8);
		this.lblInstConditions.Name = "lblInstConditions";
		this.lblInstConditions.Size = new System.Drawing.Size(222, 16);
		this.lblInstConditions.TabIndex = 0;
		this.lblInstConditions.Text = "Instrument Conditions for Element :";
		//
		//lblBH
		//
		this.lblBH.BackColor = System.Drawing.Color.White;
		this.lblBH.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblBH.ForeColor = System.Drawing.Color.Blue;
		this.lblBH.Location = new System.Drawing.Point(10, 8);
		this.lblBH.Name = "lblBH";
		this.lblBH.Size = new System.Drawing.Size(422, 16);
		this.lblBH.TabIndex = 2;
		//
		//lblPosition
		//
		this.lblPosition.BackColor = System.Drawing.Color.White;
		this.lblPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblPosition.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPosition.ForeColor = System.Drawing.Color.Blue;
		this.lblPosition.Location = new System.Drawing.Point(10, 27);
		this.lblPosition.Name = "lblPosition";
		this.lblPosition.Size = new System.Drawing.Size(422, 16);
		this.lblPosition.TabIndex = 1;
		//
		//lblOptimisation
		//
		this.lblOptimisation.BackColor = System.Drawing.Color.White;
		this.lblOptimisation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblOptimisation.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblOptimisation.ForeColor = System.Drawing.Color.Blue;
		this.lblOptimisation.Location = new System.Drawing.Point(10, 46);
		this.lblOptimisation.Name = "lblOptimisation";
		this.lblOptimisation.Size = new System.Drawing.Size(422, 16);
		this.lblOptimisation.TabIndex = 0;
		//
		//btnClose
		//
		this.btnClose.Location = new System.Drawing.Point(362, 65);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(74, 22);
		this.btnClose.TabIndex = 3;
		this.btnClose.Text = "Close";
		this.btnClose.Visible = false;
		//
		//CustomPanel1
		//
		this.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanel1.Controls.Add(this.aasGraphOptimisation);
		this.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Top;
		this.CustomPanel1.Location = new System.Drawing.Point(0, 0);
		this.CustomPanel1.Name = "CustomPanel1";
		this.CustomPanel1.Size = new System.Drawing.Size(458, 312);
		this.CustomPanel1.TabIndex = 0;
		//
		//aasGraphOptimisation
		//
		this.aasGraphOptimisation.AldysGraphCursor = null;
		this.aasGraphOptimisation.AldysGraphPrintColor = System.Drawing.Color.Black;
		this.aasGraphOptimisation.BackColor = System.Drawing.Color.LightGray;
		this.aasGraphOptimisation.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.aasGraphOptimisation.GraphDataSource = null;
		this.aasGraphOptimisation.GraphImage = null;
		this.aasGraphOptimisation.IsShowGrid = true;
		this.aasGraphOptimisation.Location = new System.Drawing.Point(6, 4);
		this.aasGraphOptimisation.Name = "aasGraphOptimisation";
		this.aasGraphOptimisation.Size = new System.Drawing.Size(442, 300);
		this.aasGraphOptimisation.TabIndex = 3;
		this.aasGraphOptimisation.UseDefaultSettings = false;
		this.aasGraphOptimisation.XAxisDateMax = new System.DateTime((long)0);
		this.aasGraphOptimisation.XAxisDateMin = new System.DateTime((long)0);
		this.aasGraphOptimisation.XAxisDateScaleFormat = AAS203.AASGraph.enumDateScaleFormat.YYYY;
		this.aasGraphOptimisation.XAxisLabel = "BURNER POSITION";
		this.aasGraphOptimisation.XAxisMax = 6;
		this.aasGraphOptimisation.XAxisMin = 0;
		this.aasGraphOptimisation.XAxisMinorStep = 0.5;
		this.aasGraphOptimisation.XAxisScaleFormat = null;
		this.aasGraphOptimisation.XAxisStep = 1;
		this.aasGraphOptimisation.XAxisType = AldysGraph.AxisType.Linear;
		this.aasGraphOptimisation.YAxisLabel = "ABS";
		this.aasGraphOptimisation.YAxisMax = 3;
		this.aasGraphOptimisation.YAxisMin = 0;
		this.aasGraphOptimisation.YAxisMinorStep = 0.2;
		this.aasGraphOptimisation.YAxisScaleFormat = null;
		this.aasGraphOptimisation.YAxisStep = 1;
		this.aasGraphOptimisation.YAxisType = AldysGraph.AxisType.Linear;
		//
		//frmBurnerOptimisation
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.ClientSize = new System.Drawing.Size(458, 455);
		this.ControlBox = false;
		this.Controls.Add(this.CustomPanelMain);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmBurnerOptimisation";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Burner Optimisation";
		this.TopMost = true;
		this.CustomPanelMain.ResumeLayout(false);
		this.CustomPanel2.ResumeLayout(false);
		this.custPnlInstConditions.ResumeLayout(false);
		this.CustomPanel1.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Public Property  "


	public double XMin {
		//'this is used for setting and getting a Xmin value.
		get { XMin = mdblMinXaxis; }
		set { mdblMinXaxis = Value; }
	}

	public double XMax {
		//'this is used for setting and getting a Xmax value.
		get { XMax = mdblMaxXaxis; }
		set { mdblMaxXaxis = Value; }
	}

	public double YMin {
		//'this is used for setting and getting a Ymin value.
		get { YMin = mdblMinYaxis; }
		set { mdblMinYaxis = Value; }
	}
	public double YMax {
		//'this is used for setting and getting a Ymax value.
		get { YMax = mdblMaxYaxis; }
		set { mdblMaxYaxis = Value; }
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
		// Description           : to handle a completion of thread.
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 12.12.06
		// Revisions             : praveen
		//=====================================================================
		//btnClose.Visible = True
		if (Cancelled == true) {
			mblnStop = true;
			//Me.DialogResult = DialogResult.OK
			//btnClose.Visible = True

			//---Added By Mangesh 
			if (!IsNothing(mobjCurve)) {
				aasGraphOptimisation.StopOnlineGraph(mobjCurve);
				//'stop a online graph.
				aasGraphOptimisation.DrawHighestPeakLine(mobjCurve);
				//'display a peak line
				if (gintOptimisation == modGlobalDeclarations.EnumBH_FP_Opimisation.FuelPresure) {
					//'for fuel presure
					aasGraphOptimisation.ShowHighPeakLineLabel("Max. Ratio", false, 0);
				} else if (gintOptimisation == modGlobalDeclarations.EnumBH_FP_Opimisation.BurnerHeight) {
					//'check for burner
					aasGraphOptimisation.ShowHighPeakLineLabel("Max. Height", false, 0);
				}

			}
			//---Added By Mangesh 
		}
		gobjCommProtocol.mobjCommdll.subTime_Delay(2000);
		//'for communication delay during a thread
		this.Close();
	}

	public void BgThread.Iclient.Display(string Text)
	{
		//=====================================================================
		// Procedure Name        : Display
		// Parameters Passed     : Text
		// Returns               : None
		// Purpose               : 
		// Description           : to display a thread calculation on a screen
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 12.12.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is called by burner optimization thread.
		//'this is used to diaplayed a thread calculation on a screen.
		//'here we have to pass a string ,which is to be displayed.
		string[] strDataValues;
		double dblX;
		double dblY;
		string strGraphLedgend;

		try {
			if (!Text == string.Empty) {
				strDataValues = Text.Split("|");
				//'set a spliter for given string
				if (strDataValues.Length > 0) {
					//'check for length
					mintOccurence = mintOccurence + 1;

					dblX = (double)strDataValues(0);
					dblY = (double)strDataValues(1);
					//'get a value of X,Y from a given string
					if (mintOccurence == 1) {
						//agTurretOptimisation.PlotPoint(0, 0, dblX, dblY, 1)
						//---Added By Mangesh 
						if (gintOptimisation == modGlobalDeclarations.EnumBH_FP_Opimisation.BurnerHeight) {
							strGraphLedgend = "Burner Height";
						} else if (gintOptimisation == modGlobalDeclarations.EnumBH_FP_Opimisation.FuelPresure) {
							strGraphLedgend = "Fuel Ratio";
						}

						mobjCurve = aasGraphOptimisation.StartOnlineGraph(strGraphLedgend, Color.Red, AldysGraph.SymbolType.NoSymbol);
						//'draw a online graph as per given parameter 
						aasGraphOptimisation.PlotPoint(mobjCurve, dblX, dblY);
					//'plot a point on graph with respect to given value of X,Y
					} else {
						//agTurretOptimisation.PlotPoint(mdblXaxis, mdblYaxis, dblX, dblY, 1)
						//---Added By Mangesh 
						aasGraphOptimisation.PlotPoint(mobjCurve, dblX, dblY);
					}

					mdblYaxis = dblY;
					mdblXaxis = dblX;

					//agTurretOptimisation.RefreshGraph()
					//---Added By Mangesh 
					aasGraphOptimisation.AldysPane.AxisChange();
					//'called for axis change
					aasGraphOptimisation.Invalidate();
					Application.DoEvents();
					//'now allow application to perfrom its panding work.
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
		//=====================================================================
		// Procedure Name        : Failed
		// Parameters Passed     : e
		// Returns               : Implements BgThread.Iclient.Failed
		// Purpose               : 
		// Description           : called when thread operation is failed.
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 12.12.06
		// Revisions             : praveen
		//=====================================================================
		//btnClose.Visible = True
		gobjCommProtocol.mobjCommdll.subTime_Delay(2000);
		this.Close();

	}

	public void BgThread.Iclient.Start(BgThread.clsBgThread clsBgThread)
	{
	}


	#End Region

	#Region " Public Functions "

	//Public Function SetDefaultSettingsToGraph() As Boolean
	//    ''not in used
	//    Try


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

	//End Function

	//Public Sub InitializeGraph()

	//    ''not in used.

	//    '    Dim objWait As New CWaitCursor
	//    Try
	//        '        '---Set the Properties of X-Axis


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
	//        'objWait.Dispose()
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	//Public Function PlotPoint(ByVal intPosition As Integer, ByVal dblEnergy As Double) As Boolean
	//    ''not in used.
	//End Function

	public void StartOptimizeTread()
	{
		//=====================================================================
		// Procedure Name        : StartOptimizeTread
		// Parameters Passed     : 
		// Returns               : None
		// Purpose               : Star to BH Optimisation and/or Fuel optimisation
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is called for starting a burner optimization thread
		try {
			// Init thread object and start to thread
			mController = new clsBgThread(this);
			//btnClose.Visible = True
			btnClose.Refresh();
			BHOptimizationThread = new clsBgBurnerOptimization(lblBH, lblPosition, lblOptimisation, mdblLampCurrent, mintLampPosition, aasGraphOptimisation);
			//'initialise the BHOptimizationThread  object
			//'TurretOptimizationThread = New clsBgTurretOptimization(lblPMT, lblTurretPosition, lblTurretOptimisation, mdblLampCurrent, mintLampPosition, aasGraphTurretOptimisation)
			mController.Start(BHOptimizationThread);
		//'start a thread.

		//mController.Start(New clsBgTurretOptimization(mdblLampCurrent, mintLampPosition))
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
			//Application.DoEvents()     'Commented by Saurabh 20.07.07
			//---------------------------------------------------------
		}
	}

	#End Region

	#Region "Private Functions"

	//Private Sub TurretOptimizationThread_OptimizationStatus(ByVal strLine1 As String) Handles TurretOptimizationThread.OptimizationStatus
	//    'MessageBox.Show(strLine1)
	//    lblTurretOptimisation.Text = strLine1
	//End Sub

	private void  // ERROR: Handles clauses are not supported in C#
btnClose_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnClose_Click
		// Parameters Passed     : 
		// Returns               : 
		// Purpose               : this is called when user click on close button
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : praveen
		//=====================================================================
		try {
			// Set interupte for Termination of the thread
			gblnSpectrumTerminated = true;
			BHOptimizationThread.ThTerminate = true;
			//'set a flag for terminate a thread
			Application.DoEvents();
			//'allow application to perfrom its panding work.
			if (mController.IsThreadRunning) {
				//'check if thread is running then
				mController.Cancel();
				//'stop the thread
			}
			Application.DoEvents();

			this.DialogResult = DialogResult.OK;
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

	private void  // ERROR: Handles clauses are not supported in C#
frmBurnerOptimisation_Load(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmBurnerOptimisation_Load
		// Parameters Passed     : 
		// Returns               : 
		// Purpose               : this is called when burner optimization form is loaded.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : praveen
		//=====================================================================
		try {
			this.Hide();

			if (ReadAndSetBHScanConditions() == false) {
				//Set BH/Fuel setting to the form object
				this.Close();
				return;
			}
			StartOptimizeTread();
		//'for starting a burner optimization thread.
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

	private bool ReadAndSetBHScanConditions()
	{
		//=====================================================================
		// Procedure Name        : ReadAndSetBHScanConditions
		// Parameters Passed     : 
		// Returns               : return true when success 
		// Purpose               : Set BH/Fuel setting to the form object
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : praveen
		//=====================================================================
		try {
			//btnClose.Visible = True
			// Set graph parameter objects
			if (gintOptimisation == modGlobalDeclarations.EnumBH_FP_Opimisation.BurnerHeight) {
				//'check a flag for burner
				aasGraphOptimisation.XAxisMin = 0;
				aasGraphOptimisation.XAxisMax = 6;
				aasGraphOptimisation.YAxisMin = 0;
				aasGraphOptimisation.YAxisMax = 3.0;
				aasGraphOptimisation.XAxisLabel = "BURNER POSITION";
				aasGraphOptimisation.YAxisMinorStep = 0.1;
				aasGraphOptimisation.YAxisStep = 0.5;
			} else if (gintOptimisation == modGlobalDeclarations.EnumBH_FP_Opimisation.FuelPresure) {
				//'check a flag for fuel presure.
				aasGraphOptimisation.XAxisMin = 2.0;
				aasGraphOptimisation.XAxisMax = 4.5;
				aasGraphOptimisation.YAxisMin = 0;
				aasGraphOptimisation.YAxisMax = 3.0;
				aasGraphOptimisation.XAxisLabel = "FUEL RATIO";
				aasGraphOptimisation.YAxisMinorStep = 0.1;
				aasGraphOptimisation.YAxisStep = 0.5;
			}

			aasGraphOptimisation.AldysPane.AxisChange();
			aasGraphOptimisation.Invalidate();
			aasGraphOptimisation.Refresh();

			//**********************************************
			//---STEP 15 : Set Instrument Conditions
			//**********************************************
			gobjClsAAS203.funcSetInstrumentCondns(true, lblElementName, lblLampCurrent, lblWavelength, lblSlitWidth, lblBurnerFlame);
			Application.DoEvents();
			//'allow application to perfrom its panding work.
			frmBHParameter objfrmBHParameter = new frmBHParameter();
			//'object for BHparemeter form.
			objfrmBHParameter.BHStartScan = aasGraphOptimisation.XAxisMin;
			objfrmBHParameter.BHEndScan = aasGraphOptimisation.XAxisMax;
			//'set a initiale parameter for object.
			if (objfrmBHParameter.ShowDialog() == DialogResult.OK) {
				aasGraphOptimisation.XAxisMin = objfrmBHParameter.BHStartScan;
				aasGraphOptimisation.XAxisMax = objfrmBHParameter.BHEndScan;

				aasGraphOptimisation.AldysPane.AxisChange();
				aasGraphOptimisation.Invalidate();
				aasGraphOptimisation.Refresh();
			} else {
				objfrmBHParameter.Dispose();
				return false;
			}
			objfrmBHParameter.Dispose();
			this.BringToFront();
			Application.DoEvents();
			//---to validate burner height
			if ((aasGraphOptimisation.XAxisMin > aasGraphOptimisation.XAxisMax) & (gobjClsAAS203.funcValidateHt(aasGraphOptimisation.XAxisMin)) & (gobjClsAAS203.funcValidateHt(aasGraphOptimisation.XAxisMax))) {
				return false;
			}

			gobjMessageAdapter.ShowMessage(constAspirateMaxStd);
			this.BringToFront();
			Application.DoEvents();
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
frmBurnerOptimisation_Activated(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmBurnerOptimisation_Activated
		// Parameters Passed     : 
		// Returns               : 
		// Purpose               : for activation of burneroptimization.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : praveen
		//=====================================================================
		try {
			if (gintOptimisation == modGlobalDeclarations.EnumBH_FP_Opimisation.FuelPresure) {
				//'check a flag for prasure
				//'set a text 
				this.Text = "Fuel Optimisation";
			} else if (gintOptimisation == modGlobalDeclarations.EnumBH_FP_Opimisation.BurnerHeight) {
				//'check a flag for burner
				//'and set a text
				this.Text = "Burner Height Optimisation";
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
