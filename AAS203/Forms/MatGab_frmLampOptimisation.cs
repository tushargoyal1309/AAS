using AAS203.Common;
using BgThread;

public class frmLampOptimisation : System.Windows.Forms.Form, BgThread.Iclient
{

	#Region " Windows Form Designer generated code "

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
	internal System.Windows.Forms.Label lblPMT;
	internal System.Windows.Forms.Button btnClose;
	internal AAS203.AASGraph aasGraphTurretOptimisation;
	internal System.Windows.Forms.Label lblLampPosition;
	internal System.Windows.Forms.Label lblLampOptimisation;
	internal System.Windows.Forms.Label lblInstConditions;
	internal System.Windows.Forms.Label lblElementName;
	internal System.Windows.Forms.Label lblLampCurrent;
	internal System.Windows.Forms.Label lblWavelength;
	internal System.Windows.Forms.Label lblSlitWidth;
	internal System.Windows.Forms.Label lblBurnerFlame;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmLampOptimisation));
		this.CustomPanelMain = new GradientPanel.CustomPanel();
		this.CustomPanel2 = new GradientPanel.CustomPanel();
		this.lblPMT = new System.Windows.Forms.Label();
		this.lblLampPosition = new System.Windows.Forms.Label();
		this.lblLampOptimisation = new System.Windows.Forms.Label();
		this.btnClose = new System.Windows.Forms.Button();
		this.lblElementName = new System.Windows.Forms.Label();
		this.lblInstConditions = new System.Windows.Forms.Label();
		this.lblWavelength = new System.Windows.Forms.Label();
		this.lblBurnerFlame = new System.Windows.Forms.Label();
		this.lblSlitWidth = new System.Windows.Forms.Label();
		this.lblLampCurrent = new System.Windows.Forms.Label();
		this.CustomPanel1 = new GradientPanel.CustomPanel();
		this.aasGraphTurretOptimisation = new AAS203.AASGraph();
		this.CustomPanelMain.SuspendLayout();
		this.CustomPanel2.SuspendLayout();
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
		this.CustomPanelMain.Size = new System.Drawing.Size(478, 477);
		this.CustomPanelMain.TabIndex = 0;
		//
		//CustomPanel2
		//
		this.CustomPanel2.BackColor = System.Drawing.Color.Transparent;
		this.CustomPanel2.Controls.Add(this.lblPMT);
		this.CustomPanel2.Controls.Add(this.lblLampPosition);
		this.CustomPanel2.Controls.Add(this.lblLampOptimisation);
		this.CustomPanel2.Controls.Add(this.btnClose);
		this.CustomPanel2.Controls.Add(this.lblElementName);
		this.CustomPanel2.Controls.Add(this.lblInstConditions);
		this.CustomPanel2.Controls.Add(this.lblWavelength);
		this.CustomPanel2.Controls.Add(this.lblBurnerFlame);
		this.CustomPanel2.Controls.Add(this.lblSlitWidth);
		this.CustomPanel2.Controls.Add(this.lblLampCurrent);
		this.CustomPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.CustomPanel2.Location = new System.Drawing.Point(0, 322);
		this.CustomPanel2.Name = "CustomPanel2";
		this.CustomPanel2.Size = new System.Drawing.Size(478, 155);
		this.CustomPanel2.TabIndex = 1;
		//
		//lblPMT
		//
		this.lblPMT.BackColor = System.Drawing.Color.White;
		this.lblPMT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblPMT.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold);
		this.lblPMT.ForeColor = System.Drawing.Color.Blue;
		this.lblPMT.Location = new System.Drawing.Point(11, 62);
		this.lblPMT.Name = "lblPMT";
		this.lblPMT.Size = new System.Drawing.Size(456, 16);
		this.lblPMT.TabIndex = 2;
		//
		//lblLampPosition
		//
		this.lblLampPosition.BackColor = System.Drawing.Color.White;
		this.lblLampPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblLampPosition.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold);
		this.lblLampPosition.ForeColor = System.Drawing.Color.Blue;
		this.lblLampPosition.Location = new System.Drawing.Point(11, 84);
		this.lblLampPosition.Name = "lblLampPosition";
		this.lblLampPosition.Size = new System.Drawing.Size(456, 16);
		this.lblLampPosition.TabIndex = 1;
		//
		//lblLampOptimisation
		//
		this.lblLampOptimisation.BackColor = System.Drawing.Color.Transparent;
		this.lblLampOptimisation.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold);
		this.lblLampOptimisation.ForeColor = System.Drawing.Color.Blue;
		this.lblLampOptimisation.Location = new System.Drawing.Point(11, 31);
		this.lblLampOptimisation.Name = "lblLampOptimisation";
		this.lblLampOptimisation.Size = new System.Drawing.Size(456, 25);
		this.lblLampOptimisation.TabIndex = 0;
		//
		//btnClose
		//
		this.btnClose.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnClose.Location = new System.Drawing.Point(22, 4);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(74, 22);
		this.btnClose.TabIndex = 3;
		this.btnClose.Text = "Close";
		this.btnClose.Visible = false;
		//
		//lblElementName
		//
		this.lblElementName.BackColor = System.Drawing.Color.White;
		this.lblElementName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblElementName.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblElementName.ForeColor = System.Drawing.Color.Blue;
		this.lblElementName.Location = new System.Drawing.Point(248, 106);
		this.lblElementName.Name = "lblElementName";
		this.lblElementName.Size = new System.Drawing.Size(100, 16);
		this.lblElementName.TabIndex = 1;
		this.lblElementName.Text = "Element Name";
		//
		//lblInstConditions
		//
		this.lblInstConditions.BackColor = System.Drawing.Color.White;
		this.lblInstConditions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblInstConditions.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblInstConditions.ForeColor = System.Drawing.Color.Blue;
		this.lblInstConditions.Location = new System.Drawing.Point(11, 106);
		this.lblInstConditions.Name = "lblInstConditions";
		this.lblInstConditions.Size = new System.Drawing.Size(222, 16);
		this.lblInstConditions.TabIndex = 0;
		this.lblInstConditions.Text = "Instrument Conditions for Element :";
		//
		//lblWavelength
		//
		this.lblWavelength.BackColor = System.Drawing.Color.White;
		this.lblWavelength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblWavelength.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblWavelength.ForeColor = System.Drawing.Color.Blue;
		this.lblWavelength.Location = new System.Drawing.Point(118, 128);
		this.lblWavelength.Name = "lblWavelength";
		this.lblWavelength.Size = new System.Drawing.Size(148, 20);
		this.lblWavelength.TabIndex = 4;
		//
		//lblBurnerFlame
		//
		this.lblBurnerFlame.BackColor = System.Drawing.Color.White;
		this.lblBurnerFlame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblBurnerFlame.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblBurnerFlame.ForeColor = System.Drawing.Color.Blue;
		this.lblBurnerFlame.Location = new System.Drawing.Point(388, 128);
		this.lblBurnerFlame.Name = "lblBurnerFlame";
		this.lblBurnerFlame.Size = new System.Drawing.Size(78, 20);
		this.lblBurnerFlame.TabIndex = 5;
		//
		//lblSlitWidth
		//
		this.lblSlitWidth.BackColor = System.Drawing.Color.White;
		this.lblSlitWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblSlitWidth.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSlitWidth.ForeColor = System.Drawing.Color.Blue;
		this.lblSlitWidth.Location = new System.Drawing.Point(269, 128);
		this.lblSlitWidth.Name = "lblSlitWidth";
		this.lblSlitWidth.Size = new System.Drawing.Size(116, 20);
		this.lblSlitWidth.TabIndex = 3;
		//
		//lblLampCurrent
		//
		this.lblLampCurrent.BackColor = System.Drawing.Color.White;
		this.lblLampCurrent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblLampCurrent.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblLampCurrent.ForeColor = System.Drawing.Color.Blue;
		this.lblLampCurrent.Location = new System.Drawing.Point(11, 128);
		this.lblLampCurrent.Name = "lblLampCurrent";
		this.lblLampCurrent.Size = new System.Drawing.Size(104, 20);
		this.lblLampCurrent.TabIndex = 2;
		//
		//CustomPanel1
		//
		this.CustomPanel1.BackColor = System.Drawing.Color.Transparent;
		this.CustomPanel1.Controls.Add(this.aasGraphTurretOptimisation);
		this.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Top;
		this.CustomPanel1.Location = new System.Drawing.Point(0, 0);
		this.CustomPanel1.Name = "CustomPanel1";
		this.CustomPanel1.Size = new System.Drawing.Size(478, 312);
		this.CustomPanel1.TabIndex = 0;
		//
		//aasGraphTurretOptimisation
		//
		this.aasGraphTurretOptimisation.AldysGraphCursor = null;
		this.aasGraphTurretOptimisation.AldysGraphPrintColor = System.Drawing.Color.Black;
		this.aasGraphTurretOptimisation.BackColor = System.Drawing.Color.LightGray;
		this.aasGraphTurretOptimisation.Dock = System.Windows.Forms.DockStyle.Fill;
		this.aasGraphTurretOptimisation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.aasGraphTurretOptimisation.GraphDataSource = null;
		this.aasGraphTurretOptimisation.GraphImage = null;
		this.aasGraphTurretOptimisation.IsShowGrid = true;
		this.aasGraphTurretOptimisation.Location = new System.Drawing.Point(0, 0);
		this.aasGraphTurretOptimisation.Name = "aasGraphTurretOptimisation";
		this.aasGraphTurretOptimisation.Size = new System.Drawing.Size(478, 312);
		this.aasGraphTurretOptimisation.TabIndex = 3;
		this.aasGraphTurretOptimisation.UseDefaultSettings = false;
		this.aasGraphTurretOptimisation.XAxisDateMax = new System.DateTime((long)0);
		this.aasGraphTurretOptimisation.XAxisDateMin = new System.DateTime((long)0);
		this.aasGraphTurretOptimisation.XAxisDateScaleFormat = AAS203.AASGraph.enumDateScaleFormat.YYYY;
		this.aasGraphTurretOptimisation.XAxisLabel = "WAVELENGTH (nm)";
		this.aasGraphTurretOptimisation.XAxisMax = 325;
		this.aasGraphTurretOptimisation.XAxisMin = 323;
		this.aasGraphTurretOptimisation.XAxisMinorStep = 0.1;
		this.aasGraphTurretOptimisation.XAxisScaleFormat = null;
		this.aasGraphTurretOptimisation.XAxisStep = 0.5;
		this.aasGraphTurretOptimisation.XAxisType = AldysGraph.AxisType.Linear;
		this.aasGraphTurretOptimisation.YAxisLabel = "ENERGY";
		this.aasGraphTurretOptimisation.YAxisMax = 100;
		this.aasGraphTurretOptimisation.YAxisMin = 0;
		this.aasGraphTurretOptimisation.YAxisMinorStep = 5;
		this.aasGraphTurretOptimisation.YAxisScaleFormat = null;
		this.aasGraphTurretOptimisation.YAxisStep = 10;
		this.aasGraphTurretOptimisation.YAxisType = AldysGraph.AxisType.Linear;
		//
		//frmLampOptimisation
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.ClientSize = new System.Drawing.Size(478, 477);
		this.ControlBox = false;
		this.Controls.Add(this.CustomPanelMain);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmLampOptimisation";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Analytical Peak Search";
		this.CustomPanelMain.ResumeLayout(false);
		this.CustomPanel2.ResumeLayout(false);
		this.CustomPanel1.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Constructors "

	public frmLampOptimisation()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call

	}

	public frmLampOptimisation(bool blnIsHCLEMode)
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
		mblnIsHCLEMode = blnIsHCLEMode;

	}

	#End Region

	#Region " Class Member Variables "

	private clsBgThread mController;

	private AldysGraph.Defaults objDefaultSettings;
	private bool mblnIsHCLEMode;
	private bool mblnIsLampOptimized;

	private double mdblOptimizedWavelength;

	private int mintOccurence = 0;

	private clsBgLampOptimization LampOptimizationThread = new clsBgLampOptimization();

	AldysGraph.CurveItem mobjCurve;
	#End Region

	#Region " Public Properties "

	public bool IsLampOptimized {
		get { return mblnIsLampOptimized; }
	}

	public double OptimizedWavelength {
		get { return mdblOptimizedWavelength; }
	}

	#End Region

	#Region " Form Events "

	private void  // ERROR: Handles clauses are not supported in C#
frmTurretOptimisation_Load(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmTurretOptimisation_Load
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : for handle an event
		// Description           : initialize form and other settings
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 24.06.07
		// Revisions             : 
		//=====================================================================
		int intCount;
		DataTable objdtWV;
		int intWvCount;
		double dblWV;
		int intWv;

		try {
			//Saurabh 27.07.07 Setting for Emission Mode
			if (!gstructSettings.EnableServiceUtility) {
				if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
					lblLampCurrent.Visible = false;
					lblBurnerFlame.Visible = false;
					lblWavelength.Location = new Point(11, 128);
					lblSlitWidth.Location = new Point(173, 128);
				}
			} else {
				if (gobjInst.Mode == EnumCalibrationMode.EMISSION) {
					lblLampCurrent.Visible = false;
					lblBurnerFlame.Visible = false;
					lblWavelength.Location = new Point(11, 128);
					lblSlitWidth.Location = new Point(173, 128);
				}
			}
			//Saurabh 27.07.07
			if (!IsNothing(gobjNewMethod)) {
				objdtWV = gobjNewMethod.InstrumentCondition.Wavelength.Copy;
			}

			//---get wavelength to latch
			if (!gstructSettings.ExeToRun == EnumApplicationMode.ServiceUtility) {
				if (!IsNothing(objdtWV)) {
					for (intWvCount = 0; intWvCount <= objdtWV.Rows.Count - 1; intWvCount++) {
						if (objdtWV.Rows.Item(intWvCount).Item(0) == gobjNewMethod.InstrumentCondition.SelectedWavelengthID) {
							dblWV = objdtWV.Rows.Item(intWvCount).Item(2);
						}
					}
				}
				intWv = Fix(dblWV);
			} else {
				intWv = Fix(gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).Wavelength);
			}


			//---Saurabh----23.06.07
			if (!IsNothing(gobjNewMethod)) {
				if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
					intWv = Fix(gobjInst.Lamp.EMSCondition.Wavelength);
				}
			}
			//---Saurabh----23.06.07

			//---set graph axis values
			aasGraphTurretOptimisation.XAxisMin = intWv - 1;
			aasGraphTurretOptimisation.XAxisMax = intWv + 1;
			//---Added by Mangesh on 14-Mar-2007
			aasGraphTurretOptimisation.AldysPane.XAxis.Min = intWv - 1;
			aasGraphTurretOptimisation.AldysPane.XAxis.Max = intWv + 1;
			aasGraphTurretOptimisation.XAxisStep = 0.5;
			aasGraphTurretOptimisation.XAxisMinorStep = 0.1;
			//---Added by Mangesh on 14-Mar-2007
			//-----------------------------------------------------------------------------------------------
			aasGraphTurretOptimisation.AldysPane.Legend.IsVisible = false;

			//---set form title according to operation mode
			if ((mblnIsHCLEMode)) {
				//Me.Text = "Analytical Peak Search"
				switch (gobjNewMethod.OperationMode) {
					case EnumOperationMode.MODE_AA:
						this.Text = "ANALYTICAL LINE SEARCH - AA Mode";
					case EnumOperationMode.MODE_AABGC:
						this.Text = "ANALYTICAL LINE SEARCH - AABGC Mode";
				}
				aasGraphTurretOptimisation.YAxisLabel = "ENERGY";
				aasGraphTurretOptimisation.YAxisMax = 80;
				//gFuncGetEnergy(2047.0 + 409.6 * 4)
			} else {
				this.Text = "Emission Peak Search";
				aasGraphTurretOptimisation.YAxisLabel = "EMISSION";
				aasGraphTurretOptimisation.YAxisMax = 100;
				//gFuncGetEnergy(2047.0 + 409.6 * 5)
			}
			aasGraphTurretOptimisation.YAxisMin = gFuncGetEnergy(2047);
			aasGraphTurretOptimisation.XAxisLabel = "WAVELENGTH (nm)";

			btnClose.Visible = false;
			mblnIsLampOptimized = false;

			aasGraphTurretOptimisation.Refresh();
			Refresh();
			Application.DoEvents();
			//---start analytical peak search thread

			StartOptimizeTread();

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
			if (!objdtWV == null) {
				objdtWV.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
frmTurretOptimisation_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmTurretOptimisation_Closing
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : for handle an event
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 24.06.07
		// Revisions             : 
		//=====================================================================

		try {
			//---to close the form
			if (mController.IsThreadRunning) {
				mController.Cancel();
				gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
				//10.12.07
				Application.DoEvents();
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
btnClose_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnClose_Click
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : for handle an event
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 24.06.07
		// Revisions             : 
		//=====================================================================
		try {
			this.Close();
			this.Dispose();

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

	#Region " IClient Events for receiving the Turrent Position value from thread "

	public void BgThread.Iclient.Completed(bool Cancelled)
	{
		//=====================================================================
		// Procedure Name        : Completed
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : for handle an event
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 24.06.07
		// Revisions             : 
		//=====================================================================
		try {
			//btnClose.Visible = True

			aasGraphTurretOptimisation.AldysPane.Legend.IsVisible = false;

			if (!Cancelled) {
				if (!IsNothing(mobjCurve)) {
					aasGraphTurretOptimisation.StopOnlineGraph(mobjCurve);
					aasGraphTurretOptimisation.DrawHighestPeakLine(mobjCurve);
					aasGraphTurretOptimisation.ShowHighPeakLineLabel("Optimized Wavelength", false, 0);

					if (aasGraphTurretOptimisation.AldysPane.CurveList.Count > 1) {
						if ((aasGraphTurretOptimisation.AldysPane.CurveList(1).IsHighPeakLine)) {
							mdblOptimizedWavelength = aasGraphTurretOptimisation.AldysPane.CurveList(1).HighPeakXValue;
							lblLampPosition.Text = "Optimized Wavelength :- " + FormatNumber(mdblOptimizedWavelength, 2);
						}
					}
					mblnIsLampOptimized = LampOptimizationThread.IsLampOptimized;
				}
			}

			gobjCommProtocol.mobjCommdll.subTime_Delay(1500);
			this.DialogResult = DialogResult.Cancel;

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

	public void BgThread.Iclient.Display(string Text)
	{
		//=====================================================================
		// Procedure Name        : Display
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               :  to plot graph
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 24.06.07
		// Revisions             : 
		//=====================================================================
		string[] strDataValues;
		double dblX;
		double dblY;

		try {
			//---to plot graph
			if (!Text == string.Empty) {
				strDataValues = Text.Split(",");

				if (strDataValues.Length > 0) {
					mintOccurence = mintOccurence + 1;

					//06.09.07
					if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
						dblX = (double)strDataValues(0);
						dblY = (double)strDataValues(1);
						if (dblY < 0) {
							dblY = 0;
						}
					} else {
						dblX = (double)strDataValues(0);
						dblY = (double)strDataValues(1);
					}


					if (mintOccurence == 1) {
						mobjCurve = aasGraphTurretOptimisation.StartOnlineGraph("AnalysisPeak", Color.Red, AldysGraph.SymbolType.NoSymbol);
						aasGraphTurretOptimisation.PlotPoint(mobjCurve, dblX, dblY);
					} else {
						aasGraphTurretOptimisation.PlotPoint(mobjCurve, dblX, dblY);
					}

					aasGraphTurretOptimisation.AldysPane.XAxis.PickScale(aasGraphTurretOptimisation.XAxisMin, aasGraphTurretOptimisation.XAxisMax);
					aasGraphTurretOptimisation.AldysPane.XAxis.StepAuto = true;
					aasGraphTurretOptimisation.AldysPane.XAxis.MinorStepAuto = true;

					aasGraphTurretOptimisation.AldysPane.YAxis.PickScale(aasGraphTurretOptimisation.YAxisMin, aasGraphTurretOptimisation.YAxisMax);
					aasGraphTurretOptimisation.AldysPane.YAxis.StepAuto = true;
					aasGraphTurretOptimisation.AldysPane.YAxis.MinorStepAuto = true;

					aasGraphTurretOptimisation.AldysPane.AxisChange();
					aasGraphTurretOptimisation.Invalidate();

					Application.DoEvents();
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
	}


	public void BgThread.Iclient.Start(BgThread.clsBgThread clsBgThread)
	{
	}

	#End Region

	#Region " Public Functions "

	public void StartOptimizeTread()
	{
		//=====================================================================
		// Procedure Name        : StartOptimizeTread
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               :  to start lamp optimization thread
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 24.06.07
		// Revisions             : 
		//=====================================================================
		try {
			mController = new clsBgThread(this);
			gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
			//10.12.07
			Application.DoEvents();
			LampOptimizationThread = new clsBgLampOptimization(mblnIsHCLEMode, aasGraphTurretOptimisation, lblPMT, lblLampPosition, lblLampOptimisation, lblElementName, lblLampCurrent, lblWavelength, lblSlitWidth, lblBurnerFlame);

			//---start the lamp optimization thread
			mController.Start(LampOptimizationThread);

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

}
