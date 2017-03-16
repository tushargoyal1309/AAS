using AAS203Library;
using AAS203Library.Method;

public class AASGraph : AldysGraph.AldysGraph
{

	#Region " Windows Form Designer generated code "

	public AASGraph()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
		this.Load += AASGraph_Load;
		//CONST_dblYpointTolerance = 0.25    'this is for 100 scale
		//CONST_dblXpointTolerance = 0.3     'this is for 5 scale


	}

	//UserControl overrides dispose to clean up the component list.
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
	internal NETXP.Controls.Bars.CommandContextMenu CommandContextMenus;
	internal NETXP.Controls.Bars.CommandBarButtonItem btnUseDefaultSettings;
	internal NETXP.Controls.Bars.CommandBarButtonItem btnCustomizedGraph;
	internal NETXP.Controls.Bars.CommandBarSeparatorItem CommandBarSeparatorItem4;
	internal NETXP.Controls.Bars.CommandBarButtonItem btnPeakEdit;
	internal NETXP.Controls.Bars.CommandBarSeparatorItem CommandBarSeparatorItem3;
	internal NETXP.Controls.Bars.CommandBarButtonItem btnGrid;
	internal NETXP.Controls.Bars.CommandBarButtonItem btnZoom;
	internal NETXP.Controls.Bars.CommandBarButtonItem btnLegends;
	internal NETXP.Controls.Bars.CommandBarSeparatorItem CommandBarSeparatorItem2;
	internal NETXP.Controls.Bars.CommandBarButtonItem btnScale;
	internal NETXP.Controls.Bars.CommandBarSeparatorItem CommandBarSeparatorItem5;
	internal NETXP.Controls.Bars.CommandBarButtonItem btnPrint;
	internal NETXP.Controls.Bars.CommandBarButtonItem btnPrintPreview;
	internal NETXP.Controls.Bars.CommandBarSeparatorItem CommandBarSeparatorItem6;
	internal NETXP.Controls.Bars.CommandBarButtonItem btnShowXYValues;
	internal NETXP.Controls.Bars.CommandBarButtonItem btnSelectCurve;
	internal NETXP.Controls.Bars.CommandBarButtonItem btnDisablePeak;
	internal NETXP.Controls.Bars.CommandBarSeparatorItem CommandBarSeparatorItem7;
	internal NETXP.Controls.Bars.CommandBarButtonItem btnShowCurveLabels;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		this.CommandContextMenus = new NETXP.Controls.Bars.CommandContextMenu();
		this.btnUseDefaultSettings = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.btnCustomizedGraph = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CommandBarSeparatorItem4 = new NETXP.Controls.Bars.CommandBarSeparatorItem();
		this.btnPeakEdit = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CommandBarSeparatorItem3 = new NETXP.Controls.Bars.CommandBarSeparatorItem();
		this.btnGrid = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.btnZoom = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.btnLegends = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CommandBarSeparatorItem2 = new NETXP.Controls.Bars.CommandBarSeparatorItem();
		this.btnScale = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CommandBarSeparatorItem5 = new NETXP.Controls.Bars.CommandBarSeparatorItem();
		this.btnPrint = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.btnPrintPreview = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CommandBarSeparatorItem6 = new NETXP.Controls.Bars.CommandBarSeparatorItem();
		this.btnShowXYValues = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.btnSelectCurve = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.btnDisablePeak = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CommandBarSeparatorItem7 = new NETXP.Controls.Bars.CommandBarSeparatorItem();
		this.btnShowCurveLabels = new NETXP.Controls.Bars.CommandBarButtonItem();
		//
		//CustPan
		//
		this.CustPan.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.CustPan.Name = "CustPan";
		this.CustPan.Size = new System.Drawing.Size(488, 344);
		//
		//CommandContextMenus
		//
		this.CommandContextMenus.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] {
			this.btnUseDefaultSettings,
			this.btnCustomizedGraph,
			this.CommandBarSeparatorItem4,
			this.btnPeakEdit,
			this.CommandBarSeparatorItem3,
			this.btnGrid,
			this.btnZoom,
			this.btnLegends,
			this.CommandBarSeparatorItem2,
			this.btnScale,
			this.CommandBarSeparatorItem5,
			this.btnPrint,
			this.btnPrintPreview,
			this.CommandBarSeparatorItem6,
			this.btnShowXYValues,
			this.btnSelectCurve,
			this.btnDisablePeak,
			this.CommandBarSeparatorItem7,
			this.btnShowCurveLabels
		});
		//
		//btnUseDefaultSettings
		//
		this.btnUseDefaultSettings.Text = "Use Default Settings";
		this.btnUseDefaultSettings.Visible = false;
		//
		//btnCustomizedGraph
		//
		this.btnCustomizedGraph.Text = "Customized Graph";
		this.btnCustomizedGraph.Visible = false;
		//
		//CommandBarSeparatorItem4
		//
		this.CommandBarSeparatorItem4.Visible = false;
		//
		//btnPeakEdit
		//
		this.btnPeakEdit.Enabled = false;
		this.btnPeakEdit.Text = "Peak Edit";
		//
		//btnGrid
		//
		this.btnGrid.Text = "Grid";
		//
		//btnZoom
		//
		this.btnZoom.Text = "Zoom";
		this.btnZoom.Visible = false;
		//
		//btnLegends
		//
		this.btnLegends.Text = "Legends";
		//
		//btnScale
		//
		this.btnScale.Text = "Scale";
		this.btnScale.Visible = false;
		//
		//CommandBarSeparatorItem5
		//
		this.CommandBarSeparatorItem5.Visible = false;
		//
		//btnPrint
		//
		this.btnPrint.Text = "Print";
		this.btnPrint.Visible = false;
		//
		//btnPrintPreview
		//
		this.btnPrintPreview.Text = "Print Preview";
		this.btnPrintPreview.Visible = false;
		//
		//CommandBarSeparatorItem6
		//
		this.CommandBarSeparatorItem6.Visible = false;
		//
		//btnShowXYValues
		//
		this.btnShowXYValues.Enabled = false;
		this.btnShowXYValues.ShowText = true;
		this.btnShowXYValues.Text = "Show X,Y Values";
		//
		//btnSelectCurve
		//
		this.btnSelectCurve.Text = "Peak Curve";
		this.btnSelectCurve.Visible = false;
		//
		//btnDisablePeak
		//
		this.btnDisablePeak.Text = "Disable Peak";
		this.btnDisablePeak.Visible = false;
		//
		//CommandBarSeparatorItem7
		//
		this.CommandBarSeparatorItem7.Visible = false;
		//
		//btnShowCurveLabels
		//
		this.btnShowCurveLabels.ShowText = true;
		this.btnShowCurveLabels.Text = "Show Curve Labels";
		this.btnShowCurveLabels.Visible = false;
		//
		//AASGraph
		//
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Name = "AASGraph";
		this.Size = new System.Drawing.Size(488, 344);

	}

	#End Region

	#Region " Private Member Variables & Constants "

	private AldysGraph.Defaults mobjDefaultSettings;

	private bool mblnUseDefaultSettings;
	//---A CurveItem type object to Plot the Curve on the Graph Rect

	private AldysGraph.CurveItem mobjOfflineCurve;
	private bool mblnIsOnlineCurveStarted;
	private bool mblnIsOnlineGraphRunning;

	private bool mblnIsOnlineGraphStopped;
	private AldysGraph.AldysPane mobjBeforeZoomGraph;

	private int mintCurveCounter = 0;
	//---A Data Table type object to get X and Y coordinates for the calling function

	private DataTable mobjDtGraphData;
	private string mstrGraphTitle;
	private string mstrXAxisLabel;

	private string mstrYAxisLabel;
	private AldysGraph.AxisType mXAxisType;

	private AldysGraph.AxisType mYAxisType;
	private string mstrXAxisScaleFormat;
	private string mstrYAxisScaleFormat;

	private enumDateScaleFormat mstrXAxisDateScaleFormat;
	private double mdblXAxisMin;

	private double mdblXAxisMax;
	private System.DateTime mdblXAxisDateMin;

	private System.DateTime mdblXAxisDateMax;
	private double mdblXAxisMinorStep;
	private double mdblXAxisStep;
	private double mdblYAxisMin;
	private double mdblYAxisMax;
	private double mdblYAxisMinorStep;
	private double mdblYAxisStep;

	private double dblXFator = 0.5;
	#End Region

	#Region " Public Enums, Constants, Events, Structuress.. "

	public enum enumDateScaleFormat
	{
		YYYY = 0,
		//"&yyyy"
		MMMYY = 1,
		//"&mmm-&yy"
		DDMMM = 2,
		//"&d-&mmm"
		DDMMM_HHMM = 3,
		//"&d-&mmm &hh:&nn"
		HHMM = 4,
		//"&hh:&nn"
		mmss = 5
		//"&nn:&ss"
	}

	public event  GraphScaleChanged;

	public event  GraphOptionChanged;
	//Public Const CONST_dblXpointTolerance = 0.3
	//Public Const CONST_dblYpointTolerance = 0.015
		//this is for 100 scale
	public double CONST_dblYpointTolerance = 0.015;
		//this is for 5 scale
	public double CONST_dblXpointTolerance = 0.3;

	#End Region

	#Region " Public Properties "

	public AldysGraph.AxisType XAxisType {
		get { return mXAxisType; }
		set {
			mXAxisType = Value;
			AldysPane.XAxis.Type = Value;
			if (Value == AldysGraph.AxisType.Date) {
				XAxisDateScaleFormat = enumDateScaleFormat.HHMM;
				XAxisDateMin = (System.DateTime)Format(Now, "dd-MMM-yyyy");
				XAxisDateMax = XAxisDateMin.AddDays(1).AddSeconds(-1);
				AldysPane.AxisChange();
				this.Invalidate();
			}
		}
	}

	public string XAxisScaleFormat {
		get { return mstrXAxisScaleFormat; }
		set {
			mstrXAxisScaleFormat = Value;
			AldysPane.XAxis.ScaleFormat = Value;
			AldysPane.AxisChange();
			this.Invalidate();
		}
	}

	public enumDateScaleFormat XAxisDateScaleFormat {
		get { return mstrXAxisDateScaleFormat; }
		set {
			mstrXAxisDateScaleFormat = Value;
			switch (Value) {
				case enumDateScaleFormat.YYYY:
					XAxisScaleFormat = "&yyyy";

					XAxisLabel = "Time (in Years)";
				case enumDateScaleFormat.MMMYY:
					XAxisScaleFormat = "&mmm-&yy";

					XAxisLabel = "Time (in MMM-YY)";
				case enumDateScaleFormat.DDMMM:
					XAxisScaleFormat = "&d-&mmm";

					XAxisLabel = "Time (in DD-MMM)";
				case enumDateScaleFormat.DDMMM_HHMM:
					XAxisScaleFormat = "&d-&mmm &hh:&nn";

					XAxisLabel = "Time (in DD-MMM HH:mm)";
				case enumDateScaleFormat.HHMM:
					XAxisScaleFormat = "&hh:&nn";

					XAxisLabel = "Time (in HH:mm)";
				case enumDateScaleFormat.mmss:
					XAxisScaleFormat = "&nn:&ss";

					XAxisLabel = "Time (in mm:ss)";
			}

			AldysPane.XAxis.StepAuto = true;
			AldysPane.XAxis.MinorStepAuto = true;
			AldysPane.XAxis.PickScale(AldysPane.XAxis.Min, AldysPane.XAxis.Max);
			AldysPane.AxisChange();
			this.Invalidate();
		}
	}

	public string YAxisScaleFormat {
		get { return mstrYAxisScaleFormat; }
		set {
			mstrYAxisScaleFormat = Value;
			AldysPane.YAxis.ScaleFormat = Value;
			AldysPane.AxisChange();
			this.Invalidate();
		}
	}

	public AldysGraph.AxisType YAxisType {
		get { return mYAxisType; }
		set {
			mYAxisType = Value;
			AldysPane.YAxis.Type = Value;
			AldysPane.AxisChange();
			this.Invalidate();
		}
	}

	public string XAxisLabel {
		get { return mstrXAxisLabel; }
		set {
			mstrXAxisLabel = Value;
			AldysPane.XAxis.Title = Value;
			AldysPane.AxisChange();
			this.Invalidate();
		}
	}

	public string YAxisLabel {
		get { return mstrYAxisLabel; }
		set {
			mstrYAxisLabel = Value;
			AldysPane.YAxis.Title = Value;
			AldysPane.AxisChange();
			this.Invalidate();
		}
	}

	public DataTable GraphDataSource {
		get { return mobjDtGraphData; }
		set { mobjDtGraphData = Value; }
	}

	public bool UseDefaultSettings {
		get { return mblnUseDefaultSettings; }
		set { mblnUseDefaultSettings = Value; }
	}

	public double XAxisMin {
		get { return mdblXAxisMin; }
		set {
			mdblXAxisMin = Value;
			AldysPane.XAxis.Min = Value;
			AldysPane.AxisChange();
			this.Invalidate();
		}
	}

	public double XAxisMax {
		get { return mdblXAxisMax; }
		set {
			mdblXAxisMax = Value;
			AldysPane.XAxis.Max = Value;
			AldysPane.AxisChange();
			this.Invalidate();
		}
	}

	public System.DateTime XAxisDateMin {
		get { return mdblXAxisDateMin; }
		set {
			mdblXAxisDateMin = Value;
			XAxisMin = AldysGraph.XDate.DateTimeToXLDate(Value);
			AldysPane.AxisChange();
			this.Invalidate();
		}
	}

	public System.DateTime XAxisDateMax {
		get { return mdblXAxisDateMax; }
		set {
			mdblXAxisDateMax = Value;
			XAxisMax = AldysGraph.XDate.DateTimeToXLDate(Value);
		}
	}

	//Public Property XAxisTimeMin() As String
	//    Get
	//        Return AldysPane.XAxis.Min
	//    End Get
	//    Set(ByVal Value As String)
	//        AldysPane.XAxis.Min = AldysGraph.XDate.DateTimeToXLDate(Value)
	//    End Set
	//End Property

	//Public Property XAxisTimeMax() As String
	//    Get
	//        Return AldysPane.XAxis.Max
	//    End Get
	//    Set(ByVal Value As String)
	//        AldysPane.XAxis.Max = AldysGraph.XDate.DateTimeToXLDate(Value)
	//    End Set
	//End Property

	public double XAxisMinorStep {
		get { return mdblXAxisMinorStep; }
		set {
			mdblXAxisMinorStep = Value;
			AldysPane.XAxis.MinorStep = Value;
			AldysPane.AxisChange();
			this.Invalidate();
		}
	}

	public double XAxisStep {
		get { return mdblXAxisStep; }
		set {
			mdblXAxisStep = Value;
			AldysPane.XAxis.Step = Value;
			AldysPane.AxisChange();
			this.Invalidate();
		}
	}

	public double YAxisMin {
		get { return mdblYAxisMin; }
		set {
			mdblYAxisMin = Value;
			AldysPane.YAxis.Min = Value;
			AldysPane.AxisChange();
			this.Invalidate();
		}
	}

	public double YAxisMax {
		get { return mdblYAxisMax; }
		set {
			mdblYAxisMax = Value;
			AldysPane.YAxis.Max = Value;
			AldysPane.AxisChange();
			this.Invalidate();
		}
	}

	public double YAxisMinorStep {
		get { return mdblYAxisMinorStep; }
		set {
			mdblYAxisMinorStep = Value;
			AldysPane.YAxis.MinorStep = Value;
			AldysPane.AxisChange();
			this.Invalidate();
		}
	}

	public double YAxisStep {
		get { return mdblYAxisStep; }
		set {
			mdblYAxisStep = Value;
			AldysPane.YAxis.Step = Value;
			AldysPane.AxisChange();
			this.Invalidate();
		}
	}

	public AldysGraph.CurveItem OfflineCurve {
		get { return mobjOfflineCurve; }
	}

	public bool IsOnlineGraphRunning {
		get { return mblnIsOnlineGraphRunning; }
	}

	public bool IsShowGrid {
		get {
			if (AldysPane.XAxis.IsShowGrid) {
				return true;
			} else {
				return false;
			}
		}
		set {
			AldysPane.XAxis.IsShowGrid = Value;
			AldysPane.YAxis.IsShowGrid = Value;
			AldysPane.AxisChange();
			this.Invalidate();
		}
	}


	#End Region

	#Region " Event Handling Fucntions "

	private void AASGraph_Load(object sender, EventArgs e)
	{
		try {
			SetDefaultSettingsToGraph();
			AddHandlers();
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

	private void AASGraph_CustPaneMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
	{
		try {
			btnGrid.Checked = AldysPane.XAxis.IsShowGrid;

			btnLegends.Checked = AldysPane.Legend.IsVisible;
			btnUseDefaultSettings.Checked = mblnUseDefaultSettings;
			btnShowXYValues.Checked = this.ShowXYValues;
			btnPeakEdit.Checked = this.ShowXYPeak;
			if (mblnUseDefaultSettings == true) {
				btnCustomizedGraph.Checked = false;
			} else {
				btnCustomizedGraph.Checked = true;
			}

			if (btnZoom.Checked == true) {
				btnShowCurveLabels.Visible = false;
			//btnSelectCurve.Visible = False
			//btnDisablePeak.Visible = False
			//CommandBarSeparatorItem6.Visible = False
			//CommandBarSeparatorItem7.Visible = False
			} else {
				//btnShowCurveLabels.Visible = True
				//btnSelectCurve.Visible = True
				//btnDisablePeak.Visible = True
				//CommandBarSeparatorItem6.Visible = True
				//CommandBarSeparatorItem7.Visible = True
			}

			//If Me.AldysPane.CurveList.Count > 0 Then
			//    Me.btnSelectCurve.Visible = True
			//    Me.btnDisablePeak.Visible = True

			//    If btnZoom.Checked = True Then
			//        btnSelectCurve.Visible = False
			//        btnDisablePeak.Visible = False
			//        CommandBarSeparatorItem6.Visible = False
			//        CommandBarSeparatorItem7.Visible = False
			//    Else
			//        btnSelectCurve.Visible = True
			//        btnDisablePeak.Visible = True
			//        CommandBarSeparatorItem6.Visible = True
			//        CommandBarSeparatorItem7.Visible = True
			//    End If

			//    intICurveCounter = 0
			//    Dim btnCurves(Me.AldysPane.CurveList.Count - 1) As NETXP.Controls.Bars.CommandBarButtonItem
			//    For Each curve In Me.AldysPane.CurveList

			//        btnCurves(intICurveCounter) = New NETXP.Controls.Bars.CommandBarButtonItem

			//        If Len(curve.Label) > 0 Then
			//            btnCurves(intICurveCounter).Text = curve.Label
			//        Else
			//            btnCurves(intICurveCounter).Text = "Curve : " & intICurveCounter + 1
			//        End If

			//        btnCurves(intICurveCounter).Tag = intICurveCounter
			//        AddHandler btnCurves(intICurveCounter).Click, AddressOf Curve_Click
			//        intICurveCounter += 1
			//    Next

			//    Me.btnSelectCurve.Items.Clear()

			//    Me.btnSelectCurve.Items.AddRange(btnCurves)
			//Else
			//    Me.btnSelectCurve.Visible = False
			//    Me.btnDisablePeak.Visible = False
			//End If

			if (e.Button == MouseButtons.Right) {
				Point pos = new Point();
				pos.X = e.X;
				pos.Y = e.Y;
				CommandContextMenus.Animate = true;
				CommandContextMenus.Show(this, pos);
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


	private void AASGraph_StatusEvent(object o, AldysGraph.CurveStatus e)
	{
	}
	//AddHandler MyBase.AddRemovePoint, AddressOf AASGraph_StatusEvent

	private void AASGraph_AddRemovePoint(bool IsAddPoint, AldysGraph.Point Point)
	{
	}
	private void submnuGrid_Click(System.Object sender, System.EventArgs e)
	{
		try {
			btnGrid.Checked = !(btnGrid.Checked);
			this.IsShowGrid = btnGrid.Checked;
			if (GraphOptionChanged != null) {
				GraphOptionChanged();
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

	private void mnuLegends_Click(System.Object sender, System.EventArgs e)
	{
		try {
			btnLegends.Checked = !(btnLegends.Checked);

			AldysPane.Legend.IsVisible = btnLegends.Checked;

			AldysPane.AxisChange();
			this.Invalidate();
			if (GraphOptionChanged != null) {
				GraphOptionChanged();
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

	public void submnuScale_Click(System.Object sender, System.EventArgs e)
	{
		frmGraphScale objfrmGraphScale;

		try {
			objfrmGraphScale = new frmGraphScale();

			objfrmGraphScale.NVXMin.Text = AldysPane.XAxis.Min;
			objfrmGraphScale.NVXMax.Text = AldysPane.XAxis.Max;
			objfrmGraphScale.NVYMin.Text = AldysPane.YAxis.Min;
			objfrmGraphScale.NVYMax.Text = AldysPane.YAxis.Max;

			//If AldysPane.XAxis.Title = mstrXAxisLabel Then
			//    objfrmGraphScale.XAxisWavelength = True
			//Else
			//    objfrmGraphScale.XAxisWavelength = False
			//End If

			//---If X-Axis is Time then display date time values
			if (AldysPane.XAxis.Type == AldysGraph.AxisType.Date) {
				objfrmGraphScale.IsXAxisDateTime = true;

				objfrmGraphScale.dtpXMin.Format = DateTimePickerFormat.Custom;
				objfrmGraphScale.dtpXMax.Format = DateTimePickerFormat.Custom;

				switch (AldysPane.XAxis.ScaleFormat) {
					case  // ERROR: Case labels with binary operators are unsupported : Equality
"&yyyy":
						objfrmGraphScale.dtpXMin.CustomFormat = "yyyy";
						objfrmGraphScale.dtpXMax.CustomFormat = "yyyy";
						objfrmGraphScale.lblXminFormat.Text = "yyyy";

						objfrmGraphScale.lblXMaxFormat.Text = "yyyy";
					case  // ERROR: Case labels with binary operators are unsupported : Equality
"&mmm-&yy":
						objfrmGraphScale.dtpXMin.CustomFormat = "MMM-yy";
						objfrmGraphScale.dtpXMax.CustomFormat = "MMM-yy";
						objfrmGraphScale.lblXminFormat.Text = "MMM-yy";

						objfrmGraphScale.lblXMaxFormat.Text = "MMM-yy";
					case  // ERROR: Case labels with binary operators are unsupported : Equality
"&d-&mmm":
						objfrmGraphScale.dtpXMin.CustomFormat = "dd-MMM";
						objfrmGraphScale.dtpXMax.CustomFormat = "dd-MMM";
						objfrmGraphScale.lblXminFormat.Text = "dd-MMM";

						objfrmGraphScale.lblXMaxFormat.Text = "dd-MMM";
					case  // ERROR: Case labels with binary operators are unsupported : Equality
"&d-&mmm &hh:&nn":
						objfrmGraphScale.dtpXMin.CustomFormat = "dd-MMM HH:mm";
						objfrmGraphScale.dtpXMax.CustomFormat = "dd-MMM HH:mm";
						objfrmGraphScale.lblXminFormat.Text = "dd-MMM HH:mm";

						objfrmGraphScale.lblXMaxFormat.Text = "dd-MMM HH:mm";
					case  // ERROR: Case labels with binary operators are unsupported : Equality
"&hh:&nn":
						objfrmGraphScale.dtpXMin.CustomFormat = "HH:mm";
						objfrmGraphScale.dtpXMax.CustomFormat = "HH:mm";
						objfrmGraphScale.lblXminFormat.Text = "HH:mm";

						objfrmGraphScale.lblXMaxFormat.Text = "HH:mm";
					case  // ERROR: Case labels with binary operators are unsupported : Equality
"&nn:&ss":
						objfrmGraphScale.dtpXMin.CustomFormat = "mm:ss";
						objfrmGraphScale.dtpXMax.CustomFormat = "mm:ss";
						objfrmGraphScale.lblXminFormat.Text = "mm:ss";

						objfrmGraphScale.lblXMaxFormat.Text = "mm:ss";
				}
				objfrmGraphScale.dtpXMin.Value = AldysGraph.XDate.XLDateToDateTime(AldysPane.XAxis.Min);
				objfrmGraphScale.dtpXMax.Value = AldysGraph.XDate.XLDateToDateTime(AldysPane.XAxis.Max);
			}


			if (objfrmGraphScale.ShowDialog(this) == DialogResult.OK) {
				if (AldysPane.XAxis.Type == AldysGraph.AxisType.Date) {
					AldysPane.XAxis.Min = AldysGraph.XDate.DateTimeToXLDate(objfrmGraphScale.dtpXMin.Value);
					AldysPane.XAxis.Max = AldysGraph.XDate.DateTimeToXLDate(objfrmGraphScale.dtpXMax.Value);
				} else {
					AldysPane.XAxis.Min = (double)objfrmGraphScale.NVXMin.Text;
					AldysPane.XAxis.Max = (double)objfrmGraphScale.NVXMax.Text;
				}

				AldysPane.YAxis.Min = (double)objfrmGraphScale.NVYMin.Text;
				AldysPane.YAxis.Max = (double)objfrmGraphScale.NVYMax.Text;

				AldysPane.XAxis.MinorStepAuto = true;
				AldysPane.XAxis.StepAuto = true;
				AldysPane.YAxis.MinorStepAuto = true;
				AldysPane.YAxis.StepAuto = true;

				objfrmGraphScale.Close();
				objfrmGraphScale.Dispose();

				AldysPane.AxisChange();
				this.Invalidate();

				if (GraphScaleChanged != null) {
					GraphScaleChanged(AldysPane.XAxis.Min, AldysPane.XAxis.Max, AldysPane.YAxis.Min, AldysPane.YAxis.Max);
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
	public void disablePeakEdit()
	{
		//Added by pankaj on 26 Aug 07 
		try {
			if (this.AldysPane.CurveList().Count <= 0) {
				btnPeakEdit.Checked = false;
				this.EnablePeakTrace(mintCurveCounter, false);
				this.ShowXYPeak = false;
				this.Invalidate();
				this.XAxisLabel = "";
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
	//Private Sub submnuPeakEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
	public int getCurveListCount()
	{
		//Added by pankaj on 27 Aug 07 
		int iretVal = 0;
		try {
			iretVal = this.AldysPane.CurveList().Count;
			return iretVal;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return iretVal;
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
	public void submnuPeakEdit_Click(System.Object sender, System.EventArgs e)
	{
		AldysGraph.CurveItem curve;
		DataTable dtCurveNames;
		DataRow dtRow;
		frmSelectPeakEdit objfrmPeakEdit;
		static bool statblnGetLegendsPos;
		static string statstrGetXLabel;
		try {
			if (this.AldysPane.CurveList().Count <= 0) {
				gobjMessageAdapter.ShowMessage("No curve found for Peakedit", "Peakedit", MessageHandler.clsMessageHandler.enumMessageType.WarningMessage);
				return;
			}

			btnPeakEdit.Checked = !(btnPeakEdit.Checked);
			objfrmPeakEdit = new frmSelectPeakEdit();

			if (btnPeakEdit.Checked == true) {
				dtCurveNames = new DataTable();
				dtCurveNames.Columns.Add("CurveIndex");
				dtCurveNames.Columns.Add("CurveName");

				mintCurveCounter = 0;

				foreach ( curve in this.AldysPane.CurveList) {
					dtRow = dtCurveNames.NewRow;
					dtRow("CurveIndex") = mintCurveCounter;
					if (Len(curve.Label) > 0) {
						dtRow("CurveName") = curve.Label;
					} else {
						dtRow("CurveName") = "Curve : " + mintCurveCounter + 1;
					}
					dtCurveNames.Rows.Add(dtRow);
					mintCurveCounter += 1;
				}
				objfrmPeakEdit.CurveTable = dtCurveNames;
				this.trackBarColor = Color.WhiteSmoke;
				this.peakLineWidth = 1;
				mintCurveCounter = 0;

				Point pos = new Point();
				pos.X = MousePosition.X;
				pos.Y = MousePosition.Y;
				objfrmPeakEdit.Location = pos;
				objfrmPeakEdit.Name = this.Name;

				this.pXYFont.IsFramed = true;
				this.pXYFont.Size = 11;


				//statstrGetLegends = Me.AldysPane.Legend.IsFilled  
				if (objfrmPeakEdit.ShowDialog(this) == DialogResult.OK) {
					if (this.AldysPane.CurveList.Count > 0) {
						mintCurveCounter = (int)objfrmPeakEdit.cmbCurveName.SelectedValue;
						this.peakLineColor = this.AldysPane.CurveList.Item(mintCurveCounter).Line.Color();
						this.ShowXYPeak = true;
						this.EnablePeakTrace(mintCurveCounter, true);
						objfrmPeakEdit.Dispose();
						statstrGetXLabel = this.XAxisLabel;
						this.XAxisLabel = " ";
					}
				} else {
					//If Me.AldysPane.CurveList.Count > 0 Then
					//    Me.peakLineColor = Me.AldysPane.CurveList.Item(mintCurveCounter).Line.Color()
					//    Me.ShowXYPeak = True
					//    Me.EnablePeakTrace(mintCurveCounter, True)
					//End If
					objfrmPeakEdit.Dispose();
				}

				dtCurveNames.Dispose();
				dtRow = null;
			//statstrGetXLabel = Me.XAxisLabel

			} else {
				this.EnablePeakTrace(mintCurveCounter, false);
				this.ShowXYPeak = false;
				this.Invalidate();
				this.XAxisLabel = statstrGetXLabel;
			}
			if (GraphOptionChanged != null) {
				GraphOptionChanged();
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

	private void btnDisablePeak_Click(System.Object sender, System.EventArgs e)
	{
		try {
			if (this.btnSelectCurve.Checked == true) {
				//'If blnShowRainBowBand = True Then
				//'    Me.blnShowRainboBand = True
				//'    blnShowRainBowBand = False
				//'End If
				this.EnablePeakTrace(this.AldysPane.peakCurveIndex, false);
				this.btnSelectCurve.Checked = false;
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

	private void submnuZoom_Click(System.Object sender, System.EventArgs e)
	{
		try {
			btnZoom.Checked = !(btnZoom.Checked);

			if (btnZoom.Checked == true) {
				this.Zoom = true;

				//If btnShowCurveLabels.Checked = True Then
				//    Call RemoveCurveLabels()
				//    btnShowCurveLabels.Checked = False
				//End If

				//'blnShowRainBowBand = Me.blnShowRainboBand
				mobjBeforeZoomGraph = this.AldysPane.Clone();
			} else {
				this.Zoom = false;
				this.AldysPane = mobjBeforeZoomGraph.Clone();

				//If blnShowRainBowBand = True Then
				//    'Call LoadRainBowBand()
				//End If

				this.AldysPane.AxisChange();
				this.Invalidate();

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

	private void submnuPrint_Click(System.Object sender, System.EventArgs e)
	{
		try {
			this.PrintGraph();

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

	private void submnuPrintPreview_Click(System.Object sender, System.EventArgs e)
	{
		try {
			this.PrintPreViewGraph();

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


	private void submnuUseDefaultSettings_Click(System.Object sender, System.EventArgs e)
	{
		try {
			btnCustomizedGraph.Checked = false;
			btnUseDefaultSettings.Checked = true;
			mblnUseDefaultSettings = true;

			SetDefaultSettingsToGraph();
			AldysPane.AxisChange();
			this.Invalidate();

		//bSuccess = objIniFileOperations.WriteToINI(UCase(frmName), ConstUseDefaultSettings, "True")

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

	private void submnuCustomize_Click(System.Object sender, System.EventArgs e)
	{
		bool bSuccess = false;
		try {
		//Dim frmGraphCust As New frmGraphCustmization(Me.AldysPane.Clone())
		//'---Set the Graph type
		//frmGraphCust.BackColor1 = Me.CustPan.BackColor
		//frmGraphCust.BackColor2 = Me.CustPan.BackColor2
		//frmGraphCust.GraphType = frmName 'ConstGraphTypeCommonGraphControl
		//If frmGraphCust.ShowDialog() = (DialogResult.OK) Then
		//    Me.colSettings = frmGraphCust.colSettings.Clone()
		//    frmGraphCust.Close()
		//    btnCustomizedGraph.Checked = True
		//    btnUseDefaultSettings.Checked = False
		//    blnUseDefaultSettings = False
		//    bSuccess = objIniFileOperations.WriteToINI(UCase(frmName), ConstUseDefaultSettings, "False")
		//    Call SetCustomizedSettingsToGraph()
		//End If
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

	private void btnShowXYValues_Click(object sender, System.EventArgs e)
	{
		try {
			btnShowXYValues.Checked = !(btnShowXYValues.Checked);

			if (btnShowXYValues.Checked == true) {
				this.ShowXYValues = true;
			} else {
				this.ShowXYValues = false;
			}
			if (GraphOptionChanged != null) {
				GraphOptionChanged();
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

	#End Region

	#Region " Private Functions "

	private bool AddHandlers()
	{
		try {
			base.CustPaneMouseDown += AASGraph_CustPaneMouseDown;
			base.StatusEvent += AASGraph_StatusEvent;
			base.AddRemovePoint += AASGraph_AddRemovePoint;

			btnCustomizedGraph.Click += submnuCustomize_Click;
			btnGrid.Click += submnuGrid_Click;
			btnPeakEdit.Click += submnuPeakEdit_Click;
			btnPrint.Click += submnuPrint_Click;
			btnPrintPreview.Click += submnuPrintPreview_Click;
			btnZoom.Click += submnuZoom_Click;
			btnUseDefaultSettings.Click += submnuUseDefaultSettings_Click;
			btnScale.Click += submnuScale_Click;
			btnLegends.Click += mnuLegends_Click;
			btnDisablePeak.Click += btnDisablePeak_Click;
			//'AddHandler btnShowCurveLabels.Click, AddressOf btnShowCurveLabels_Click
			//'AddHandler Me.OnAxisChange, AddressOf LoadRainBowBand
			btnShowXYValues.Click += btnShowXYValues_Click;
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

	#Region " Public Functions "

	public AldysGraph.CurveItem PlotGraph()
	{
		//=====================================================================
		// Procedure Name        : PlotGraph
		// Parameters Passed     : Nothing
		// Returns               : True if graph plotted successfully else False
		// Purpose               : To Plot the Offline Graph according to the specification
		// Description           : 
		// Assumptions           : DataTable to extract X and Y coordinates should available
		//                         Y-Axis Scale should be available   
		// Dependencies          : 
		// Author                : Sachin Ashtankar
		// Created               : 31-Oct-2004 04:20 PM
		// Revisions             : 
		//=====================================================================
		int intICounter = 0;
		int intJCounter = 0;

		try {
			// A Double Type array to Store X-Coordinates to be plotted
			ArrayList dblArrXCoordinates = new ArrayList();

			//---Clear the Items in the Curve List
			this.AldysPane.CurveList.Clear();
			this.AldysPane.TextList.Clear();

			//---Extract the value of X-Coordinates into a double type array
			if (mobjDtGraphData.Rows.Count() > 0) {
				for (intICounter = 0; intICounter <= mobjDtGraphData.Rows.Count() - 1; intICounter++) {
					dblArrXCoordinates.Add((double)mobjDtGraphData.Rows.Item(intICounter).Item(0));
				}
			}

			this.IsShowGrid = true;
			//---Set the Properties of X-Axis
			this.AldysPane.XAxis.Type = mXAxisType;
			//'AldysGraph.AxisType.Linear
			this.AldysPane.XAxis.Title = mstrXAxisLabel;
			this.AldysPane.XAxis.MaxAuto = false;
			this.AldysPane.XAxis.MinAuto = false;
			this.AldysPane.XAxis.StepAuto = false;
			this.AldysPane.XAxis.MinorStepAuto = false;
			if (mobjDtGraphData.Rows.Count() > 0) {
				this.AldysPane.XAxis.Min = (int)mobjDtGraphData.Rows.Item(0).Item(0) + "";
				this.AldysPane.XAxis.Max = (int)mobjDtGraphData.Rows.Item(mobjDtGraphData.Rows.Count() - 1).Item(0) + "";
			}
			this.AldysPane.XAxis.MinorStep = mdblXAxisMinorStep;
			//X_AXIS_MINOR_STEP
			this.AldysPane.XAxis.Step = mdblXAxisStep;
			//X_AXIS_STEP

			//---Set the Properties of Y-Axis
			this.AldysPane.YAxis.MaxAuto = false;
			this.AldysPane.YAxis.MinAuto = false;
			this.AldysPane.YAxis.StepAuto = false;
			this.AldysPane.YAxis.MinorStepAuto = false;

			this.AldysPane.YAxis.Type = AldysGraph.AxisType.Linear;
			this.AldysPane.YAxis.Min = mdblYAxisMin;
			//Y_AXIS_MIN
			this.AldysPane.YAxis.Max = mdblYAxisMax;
			//Y_AXIS_MAX
			this.AldysPane.YAxis.MinorStep = mdblYAxisMinorStep;
			//Y_AXIS_MINIOR_STEP
			this.AldysPane.YAxis.Step = mdblYAxisStep;
			//Y_AXIS_STEP

			this.AldysPane.YAxis.Title = mstrYAxisLabel;

			//---Draw the curve on the Graph Rect X Coordinates as Wavelength and Y coordinates as Rfl, K/S, Log K/S
			if (mobjDtGraphData.Columns.Count > 0) {
				double dblHighPeak;
				double dblXHighPeak;
				double dblYHighPeak;
				bool blnIsFoundPeak = false;
				ArrayList dblArrYCoordinates = new ArrayList();
				//---A Double Type array to Store Y-Coordinates to be plotted
				for (intICounter = 1; intICounter <= mobjDtGraphData.Columns.Count() - 1; intICounter++) {
					//Dim dblArrYCoordinates As New ArrayList       '---A Double Type array to Store Y-Coordinates to be plotted
					//---Extract the value of Y-Coordinates into a double type array for different Batch

					if (mobjDtGraphData.Rows.Count() > 0) {
						//dblHighPeak = CDbl(mobjDtGraphData.Rows.Item(intICounter).Item(1))
						dblHighPeak = (double)mobjDtGraphData.Rows.Item(0).Item(1);
						for (intJCounter = 0; intJCounter <= mobjDtGraphData.Rows.Count() - 1; intJCounter++) {
							dblArrYCoordinates.Add((double)mobjDtGraphData.Rows.Item(intJCounter).Item(intICounter) + "");

							//If dblHighPeak < CDbl(mobjDtGraphData.Rows.Item(intJCounter).Item(intICounter)) Then
							if (dblHighPeak < (double)mobjDtGraphData.Rows.Item(intJCounter).Item(1)) {
								blnIsFoundPeak = true;
								dblXHighPeak = (double)mobjDtGraphData.Rows.Item(intJCounter).Item(0);
								dblYHighPeak = (double)mobjDtGraphData.Rows.Item(intJCounter).Item(1);
								//dblHighPeak = CDbl(mobjDtGraphData.Rows.Item(intICounter).Item(1))
								dblHighPeak = (double)mobjDtGraphData.Rows.Item(intJCounter).Item(1);
							}

						}
					}

					//---Add the Curve in Curve List
					mobjOfflineCurve = this.AldysPane.AddCurve((string)mobjDtGraphData.Columns.Item(intICounter).ColumnName + "", dblArrXCoordinates, dblArrYCoordinates, GetColor(intICounter - 1), AldysGraph.SymbolType.NoSymbol);
					mobjOfflineCurve.Line.Style = Drawing2D.DashStyle.Solid;

					if (blnIsFoundPeak == true) {
						mobjOfflineCurve.HighPeakYValue = dblYHighPeak;
						mobjOfflineCurve.HighPeakXValue = dblXHighPeak;
					}

				}


			}

			//---Set the Properties of graph
			if (mblnUseDefaultSettings == true) {
				SetDefaultSettingsToGraph();
			} else {
				//Call SetCustomizedSettingsToGraph()
			}

			this.AldysPane.Title = mstrGraphTitle;
			this.AldysPane.YAxis.LowerAlarmLine = false;
			this.AldysPane.YAxis.LowerAlarmLineY = 0.0;
			this.AldysPane.YAxis.LowerAlarmLineColor = Color.Black;

			//---Force the Graph control to Draw according to the Change in Specification
			this.AldysPane.AxisChange();
			this.Invalidate();

			if (!IsNothing(mobjOfflineCurve)) {
				return mobjOfflineCurve;
			} else {
				return null;
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return null;
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

	public AldysGraph.CurveItem StartOnlineGraph(string strCurveName, Color curveColor, AldysGraph.SymbolType symbol, bool blnIsColoredGraph = false)
	{
		//=====================================================================
		// Procedure Name        : StartOnlineGraph
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To plot the online graph 
		// Description           : 
		// Assumptions           : 
		//                         
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 28-Nov-2006 04:20 PM
		// Revisions             : 1
		//=====================================================================
		AldysGraph.CurveItem objOnlineCurve;
		ArrayList arrX;
		ArrayList arrY;

		try {
			this.AldysPane.XAxis.Title = mstrXAxisLabel;
			this.AldysPane.XAxis.Type = mXAxisType;
			this.IsShowGrid = true;

			if (mXAxisType == AldysGraph.AxisType.Date) {
				this.AldysPane.XAxis.MaxAuto = true;
				this.AldysPane.XAxis.MinAuto = true;
				this.AldysPane.XAxis.StepAuto = true;
				this.AldysPane.XAxis.MinorStepAuto = true;
			} else {
				this.AldysPane.XAxis.MaxAuto = false;
				this.AldysPane.XAxis.MinAuto = false;
				this.AldysPane.XAxis.StepAuto = false;
				this.AldysPane.XAxis.MinorStepAuto = false;

				this.AldysPane.XAxis.Min = mdblXAxisMin;
				this.AldysPane.XAxis.Max = mdblXAxisMax;
				this.AldysPane.XAxis.MinorStep = mdblXAxisMinorStep;
				this.AldysPane.XAxis.Step = mdblXAxisStep;
			}

			this.AldysPane.YAxis.Type = mYAxisType;
			this.AldysPane.YAxis.Title = mstrYAxisLabel;
			this.AldysPane.YAxis.Min = mdblYAxisMin;
			this.AldysPane.YAxis.Max = mdblYAxisMax;
			this.AldysPane.YAxis.MinorStep = mdblYAxisMinorStep;
			this.AldysPane.YAxis.Step = mdblYAxisStep;

			if (!mXAxisType == AldysGraph.AxisType.Date) {
				arrX = new ArrayList();
				arrX.Add(0.0);
			} else {
				arrX = new ArrayList();
				//arrX.Add(AldysGraph.XDate.XLDateToDateTime(mdblXAxisMin))
				//arrX.Add(mdblXAxisMin)
				arrX.Add(0.0);
			}
			arrY = new ArrayList();
			arrY.Add((double)0.0);

			objOnlineCurve = AldysPane.AddCurve(strCurveName, arrX, arrY, curveColor, symbol);
			objOnlineCurve.Symbol.IsFilled = true;
			objOnlineCurve.AddPointFlg = true;
			objOnlineCurve.Line.Style = System.Drawing.Drawing2D.DashStyle.Solid;

			if (blnIsColoredGraph) {
				objOnlineCurve.CL = new ArrayList();
			}

			AldysPane.CurveList.isResizing = false;
			AldysPane.IsIgnoreInitial = true;

			mblnIsOnlineCurveStarted = true;
			mblnIsOnlineGraphRunning = false;
			mblnIsOnlineGraphStopped = false;

			AldysPane.AxisChange();
			Invalidate();

			return objOnlineCurve;

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

	public void PlotPoint(ref AldysGraph.CurveItem OnlineCurve, double dblX, double dblY, bool blnIsColoredGraph = false)
	{
		//=====================================================================
		// Procedure Name        : PlotPoint
		// Parameters Passed     : x and y co-ordinate values.
		// Returns               : None
		// Purpose               : To plot the next consecutive point the online curve.
		// Description           : 
		// Assumptions           : 
		//                         
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 28-Nov-2006 04:20 PM
		// Revisions             : 1
		//=====================================================================
		try {
			//---If online graph is stopped then don't plot 
			//---any further point.
			if (!mblnIsOnlineGraphStopped) {
				if ((mblnIsOnlineCurveStarted)) {
					mblnIsOnlineCurveStarted = false;
					mblnIsOnlineGraphRunning = true;

					OnlineCurve.X.RemoveAt(0);
					OnlineCurve.Y.RemoveAt(0);
				}

				if (blnIsColoredGraph) {
					//Dim CurveSegmentColor As Color
					//CurveSegmentColor = Color.Red
					//OnlineCurve.CL.Add(CurveSegmentColor)
				}

				OnlineCurve.X.Add(dblX);
				OnlineCurve.Y.Add(dblY);

				AldysPane.IsIgnoreInitial = false;
				AldysPane.AxisChange();
				Invalidate();
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

	public void StopOnlineGraph(ref AldysGraph.CurveItem OnlineCurve)
	{
		//=====================================================================
		// Procedure Name        : StopOnlineGraph
		// Parameters Passed     : Reference to the Online CurveItem
		// Returns               : None
		// Purpose               : To stop the online plotting of curve and
		//                         enable each point info to show to user.
		// Description           : 
		// Assumptions           : 
		//                         
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 28-Nov-2006 04:20 PM
		// Revisions             : 1
		//=====================================================================
		AldysGraph.CurveItem curve;
		int intCounter;

		try {
			for (intCounter = 0; intCounter <= AldysPane.CurveList.Count - 1; intCounter++) {
				curve = AldysPane.CurveList.Item(intCounter);
				if (object.ReferenceEquals(curve, OnlineCurve)) {
					//---Stop the online running of the graph
					mblnIsOnlineGraphStopped = true;
					OnlineCurve.X.Add(curve.X.Item(curve.X.Count - 1));
					OnlineCurve.Y.Add(curve.Y.Item(curve.Y.Count - 1));
					break; // TODO: might not be correct. Was : Exit For
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

	public void RestartOnlineGraph(ref AldysGraph.CurveItem OnlineCurve)
	{
		//=====================================================================
		// Procedure Name        : RestartOnlineGraph
		// Parameters Passed     : Reference to the Online CurveItem
		// Returns               : None
		// Purpose               : To re-start the online plotting of curve 
		// Description           : 
		// Assumptions           : 
		//                         
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 28-Nov-2006 04:20 PM
		// Revisions             : 1
		//=====================================================================
		AldysGraph.CurveItem curve;
		int intCounter;

		try {
			for (intCounter = 0; intCounter <= AldysPane.CurveList.Count - 1; intCounter++) {
				curve = AldysPane.CurveList.Item(intCounter);
				if (object.ReferenceEquals(curve, OnlineCurve)) {
					//---Restart the online running of the graph
					mblnIsOnlineGraphStopped = false;
					break; // TODO: might not be correct. Was : Exit For
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

	public Color GetColor(int intColorNo)
	{
		//=====================================================================
		// Procedure Name        : GetColor
		// Parameters Passed     : intColorNo As Color No
		// Returns               : Color
		// Purpose               : To Get the multiple color while adding curve
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Ashtankar
		// Created               : 01-Nov-2004 09:00 PM
		// Revisions             : 
		//=====================================================================
		switch (intColorNo) {
			case 0:
				return Color.Black;
			case 1:
				return Color.Red;
			case 2:
				return Color.Blue;
			case 3:
				return Color.Green;
			case 4:
				return Color.YellowGreen;
			case 5:
				return Color.Brown;
			case 6:
				return Color.Pink;
			case 7:
				return Color.Purple;
			case 8:
				return Color.OrangeRed;
			case 9:
				return Color.Maroon;
			case 10:
				return Color.CadetBlue;
			case 11:
				return Color.Chocolate;
			case 11:
				return Color.CornflowerBlue;
			case 12:
				return Color.DarkBlue;
			case 13:
				return Color.DarkMagenta;
			case 14:
				return Color.DarkOrange;
			case 15:
				return Color.DarkSeaGreen;
			case 16:
				return Color.DeepPink;
			case 17:
				return Color.Gainsboro;
			case 18:
				return Color.Honeydew;
			case 19:
				return Color.LightBlue;
			case 20:
				return Color.LimeGreen;
			default:
				return Color.Orange;
		}

	}

	public bool SetDefaultSettingsToGraph()
	{

		try {
			btnPeakEdit.Checked = false;
			AldysPane.Legend.IsVisible = true;
			AldysPane.Legend.FillColor = mobjDefaultSettings.Legend.FillColor;
			AldysPane.Legend.FrameColor = mobjDefaultSettings.Legend.FrameColor;
			AldysPane.Legend.IsFilled = mobjDefaultSettings.Legend.IsFilled;
			AldysPane.Legend.IsFramed = mobjDefaultSettings.Legend.IsFramed;

			AldysPane.FontSpec.FontColor = mobjDefaultSettings.Pane.FontColor;
			AldysPane.FontSpec.FrameColor = mobjDefaultSettings.Pane.FrameColor;
			AldysPane.FontSpec.FillColor = mobjDefaultSettings.Pane.BackColor;
			AldysPane.FontSpec.Size = mobjDefaultSettings.Pane.FontSize;
			AldysPane.FontSpec.Family = mobjDefaultSettings.Pane.FontFamily;
			AldysPane.FontSpec.IsBold = mobjDefaultSettings.Pane.FontBold;
			AldysPane.FontSpec.IsItalic = mobjDefaultSettings.Pane.FontItalic;
			AldysPane.FontSpec.IsUnderline = mobjDefaultSettings.Pane.FontUnderline;

			AldysPane.XAxis.GridColor = Color.FromArgb(175, 200, 245);
			//  mobjDefaultSettings.Axis.GridColor
			AldysPane.XAxis.IsShowGrid = true;
			//Saurabh    mobjDefaultSettings.Axis.IsShowGrid
			AldysPane.XAxis.IsShowGrid = true;
			//Saurabh    mobjDefaultSettings.Axis.IsShowGrid
			AldysPane.XAxis.TitleFontSpec.FillColor = Color.Transparent;
			AldysPane.XAxis.TitleFontSpec.FrameColor = mobjDefaultSettings.Axis.FrameColor;
			AldysPane.XAxis.TitleFontSpec.FontColor = mobjDefaultSettings.Axis.TitleFontColor;
			AldysPane.XAxis.TitleFontSpec.Size = mobjDefaultSettings.Axis.TitleFontSize;
			AldysPane.XAxis.TitleFontSpec.IsFramed = false;
			AldysPane.XAxis.TitleFontSpec.IsFilled = false;
			AldysPane.XAxis.TitleFontSpec.IsBold = mobjDefaultSettings.Axis.TitleFontBold;
			AldysPane.XAxis.TitleFontSpec.IsItalic = mobjDefaultSettings.Axis.TitleFontItalic;
			AldysPane.XAxis.TitleFontSpec.IsUnderline = mobjDefaultSettings.Axis.TitleFontUnderline;
			AldysPane.XAxis.TitleFontSpec.Family = mobjDefaultSettings.Axis.TitleFontFamily;
			AldysPane.XAxis.ScaleFontSpec.Family = mobjDefaultSettings.Axis.ScaleFontFamily;
			AldysPane.XAxis.ScaleFontSpec.IsBold = mobjDefaultSettings.Axis.ScaleFontBold;
			AldysPane.XAxis.ScaleFontSpec.IsItalic = mobjDefaultSettings.Axis.ScaleFontItalic;
			AldysPane.XAxis.ScaleFontSpec.IsUnderline = mobjDefaultSettings.Axis.ScaleFontUnderline;

			AldysPane.YAxis.GridColor = Color.FromArgb(175, 200, 245);
			//mobjDefaultSettings.Axis.GridColor
			AldysPane.YAxis.IsShowGrid = true;
			//Sauarbh  mobjDefaultSettings.Axis.IsShowGrid
			AldysPane.YAxis.IsShowGrid = true;
			//Sauarbh  mobjDefaultSettings.Axis.IsShowGrid
			AldysPane.YAxis.TitleFontSpec.FillColor = Color.Transparent;
			AldysPane.YAxis.TitleFontSpec.FrameColor = mobjDefaultSettings.Axis.FrameColor;
			AldysPane.YAxis.TitleFontSpec.FontColor = mobjDefaultSettings.Axis.TitleFontColor;
			AldysPane.YAxis.TitleFontSpec.Size = mobjDefaultSettings.Axis.TitleFontSize;
			AldysPane.YAxis.TitleFontSpec.IsFramed = false;
			AldysPane.YAxis.TitleFontSpec.IsFilled = false;
			AldysPane.YAxis.TitleFontSpec.IsBold = mobjDefaultSettings.Axis.TitleFontBold;
			AldysPane.YAxis.TitleFontSpec.IsItalic = mobjDefaultSettings.Axis.TitleFontItalic;
			AldysPane.YAxis.TitleFontSpec.IsUnderline = mobjDefaultSettings.Axis.TitleFontUnderline;
			AldysPane.YAxis.TitleFontSpec.Family = mobjDefaultSettings.Axis.TitleFontFamily;
			AldysPane.YAxis.ScaleFontSpec.Family = mobjDefaultSettings.Axis.ScaleFontFamily;
			AldysPane.YAxis.ScaleFontSpec.IsBold = mobjDefaultSettings.Axis.ScaleFontBold;
			AldysPane.YAxis.ScaleFontSpec.IsItalic = mobjDefaultSettings.Axis.ScaleFontItalic;
			AldysPane.YAxis.ScaleFontSpec.IsUnderline = mobjDefaultSettings.Axis.ScaleFontUnderline;

			AldysPane.PaneBackColor = Color.Transparent;
			//mobjDefaultSettings.Pane.BackColor
			AldysPane.PaneFrameColor = Color.Transparent;
			//mobjDefaultSettings.Pane.FrameColor
			AldysPane.IsPaneFramed = false;
			// mobjDefaultSettings.Pane.IsFramed

			AldysPane.AxisBackColor = Color.Transparent;
			//mobjDefaultSettings.Axis.BackColor
			AldysPane.AxisFrameColor = Color.FromArgb(175, 200, 245);
			//mobjDefaultSettings.Axis.FrameColor
			AldysPane.IsAxisFramed = true;
			//mobjDefaultSettings.Axis.IsFramed
			AldysPane.IsShowTitle = false;

			//---------------------------------
			this.CustPan.GradientMode = GradientPanel.LinearGradientMode.Vertical;
			this.CustPan.BackColor = Color.Gainsboro;
			this.CustPan.BackColor2 = Color.White;
			//---------------------------------

			//'---added by deepak b on 09.02.06 
			//'---for curve lebels 
			//If btnShowCurveLabels.Checked = True Then
			//    Me.AldysPane.ShowCurveLabels = True
			//    Me.AldysPane.DrawCurveLabels()
			//    Me.Invalidate()
			//End If

			//---Added by Mangesh S. on 10-Jan-2007
			AldysPane.XAxis.Type = AldysGraph.AxisType.Linear;
			AldysPane.XAxis.Max = 100;
			AldysPane.XAxis.Min = 0;
			AldysPane.XAxis.StepAuto = true;
			AldysPane.XAxis.MinorStepAuto = true;

			AldysPane.YAxis.Type = AldysGraph.AxisType.Linear;
			AldysPane.YAxis.Max = 100;
			AldysPane.YAxis.Min = 0;
			AldysPane.YAxis.StepAuto = true;
			AldysPane.YAxis.MinorStepAuto = true;

			AldysPane.AxisChange();

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

	public bool ShowPointInfo(ref AldysGraph.CurveItem Curve)
	{
		//=====================================================================
		// Procedure Name        : ShowPointInfo
		// Parameters Passed     : Reference to the Online CurveItem
		// Returns               : True or false
		// Purpose               : To enable Point Info window to be displayed
		//                         at left click of mouse near point.
		// Description           : 
		// Assumptions           : 
		//                         
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 02:00 PM
		// Revisions             : 1
		//=====================================================================
		AldysGraph.CurveItem curveToCheck;
		int intCounter;

		try {
			for (intCounter = 0; intCounter <= AldysPane.CurveList.Count - 1; intCounter++) {
				curveToCheck = AldysPane.CurveList.Item(intCounter);
				if (object.ReferenceEquals(curveToCheck, Curve)) {
					EnableShowPointInfo(intCounter, true);
					return true;
					break; // TODO: might not be correct. Was : Exit For
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

	public AldysGraph.CurveItem StartScatteredPointsCurve(AldysGraph.SymbolType PointSymbol)
	{
		//=====================================================================
		// Procedure Name        : PlotScatteredPoints
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To plot the Scattered Points on graph 
		// Description           : 
		// Assumptions           : 
		//                         
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 05-Feb-2007 02:45 PM
		// Revisions             : 1
		//=====================================================================
		AldysGraph.CurveItem objScatteredPointsCurve;
		ArrayList arrX;
		ArrayList arrY;
		string strCurveName;
		Color curveColor;

		try {
			this.AldysPane.XAxis.Title = mstrXAxisLabel;
			this.AldysPane.XAxis.Type = mXAxisType;

			if (mXAxisType == AldysGraph.AxisType.Date) {
				this.AldysPane.XAxis.MaxAuto = true;
				this.AldysPane.XAxis.MinAuto = true;
				this.AldysPane.XAxis.StepAuto = true;
				this.AldysPane.XAxis.MinorStepAuto = true;
			} else {
				this.AldysPane.XAxis.MaxAuto = false;
				this.AldysPane.XAxis.MinAuto = false;
				this.AldysPane.XAxis.StepAuto = false;
				this.AldysPane.XAxis.MinorStepAuto = false;

				this.AldysPane.XAxis.Min = mdblXAxisMin;
				this.AldysPane.XAxis.Max = mdblXAxisMax;
				this.AldysPane.XAxis.MinorStep = mdblXAxisMinorStep;
				this.AldysPane.XAxis.Step = mdblXAxisStep;
			}

			this.AldysPane.YAxis.Type = mYAxisType;
			this.AldysPane.YAxis.Title = mstrYAxisLabel;
			this.AldysPane.YAxis.Min = mdblYAxisMin;
			this.AldysPane.YAxis.Max = mdblYAxisMax;
			this.AldysPane.YAxis.MinorStep = mdblYAxisMinorStep;
			this.AldysPane.YAxis.Step = mdblYAxisStep;

			if (!mXAxisType == AldysGraph.AxisType.Date) {
				arrX = new ArrayList();
				arrX.Add(0.0);
			} else {
				arrX = new ArrayList();
				//arrX.Add(AldysGraph.XDate.XLDateToDateTime(mdblXAxisMin))
				//arrX.Add(mdblXAxisMin)
				arrX.Add(0.0);
			}

			arrY = new ArrayList();
			arrY.Add((double)0.0);

			strCurveName = "Scattered Points";
			curveColor = Color.Black;

			objScatteredPointsCurve = AldysPane.AddCurve(strCurveName, arrX, arrY, curveColor, PointSymbol);

			objScatteredPointsCurve.IsScatteredPointsCurve = true;

			objScatteredPointsCurve.Symbol.IsFilled = true;
			objScatteredPointsCurve.AddPointFlg = true;
			objScatteredPointsCurve.Line.Style = System.Drawing.Drawing2D.DashStyle.Solid;

			AldysPane.CurveList.isResizing = false;
			AldysPane.IsIgnoreInitial = true;

			mblnIsOnlineCurveStarted = true;
			mblnIsOnlineGraphRunning = false;
			mblnIsOnlineGraphStopped = false;

			AldysPane.AxisChange();
			Invalidate();

			if (IO.File.Exists(Application.StartupPath + "\\Images\\HAND.CUR")) {
				this.AldysGraphCursor = new Cursor(Application.StartupPath + "\\Images\\HAND.CUR");
			}

			return objScatteredPointsCurve;

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

	public bool PlotScatteredPoints(ref AldysGraph.CurveItem ScatteredPointsCurve, bool blnIsInValid, Method.clsAnalysisStdParameters objStandard = null, Method.clsAnalysisSampleParameters objSample = null, bool blnIsEmmission = false, bool InIsUse_btnRemove = true)
	{
		//=====================================================================
		// Procedure Name        : PlotScatteredPoints
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 05-Feb-2007 04:20 pm
		// Revisions             : 1
		//=====================================================================
		AldysGraph.Point objPoint;

		static int intStdPointIndex;
		static int intSamplePointIndex;


		int intPointIdx = -1;
		bool blnIsPointFound = false;
		AldysGraph.Point objDuplicatePoint;
		ArrayList objRestorePont;
		AldysGraph.Point._point_info pointinfo;
		int PointsNo;
		//Dim strSampleInfoToShow As String

		try {
			if ((ScatteredPointsCurve.IsScatteredPointsCurve)) {
				if (!IsNothing(objStandard)) {
					//pointinfo = New AldysGraph.Point._point_info
					//objPoint.pointinfo = New AldysGraph.Point.

					pointinfo = new AldysGraph.Point._point_info(objStandard.StdNumber, objStandard.StdName, objStandard.Used, AldysGraph.Point.points_type.Std);
					objPoint = new AldysGraph.Point(objStandard.Concentration, objStandard.Abs, intStdPointIndex, blnIsInValid);
					intStdPointIndex += 1;
					objPoint.PointHeading = "Standard Information";

					//Commented and added by Sachin Dokahle
					//objPoint.PointColor = ClsAAS203.STDCOLOR
					if (objStandard.Used == false) {
						objPoint.PointColor = ClsAAS203.BLACKCOLOR;
						objPoint.IsUse_btnRemove = true;

					} else {
						objPoint.PointColor = ClsAAS203.STDCOLOR;
						objPoint.IsUse_btnRemove = InIsUse_btnRemove;
					}
					//pointinfo = New AldysGraph.Point._point_info(objStandard.StdNumber, objStandard.StdName, objStandard.Used, AldysGraph.Point.points_type.Std)
					pointinfo.IsUsed = objStandard.Used;
					pointinfo.PointNo = objStandard.StdNumber;
					pointinfo.PointsName = objStandard.StdName;
					pointinfo.PointsType = AldysGraph.Point.points_type.Std;
					//objPoint.PointRadius = 2.0!

					if (IsNothing(objPoint.UserData))
						objPoint.UserData = new ArrayList();
					objPoint.UserData.Add("Standard No.      : " + objStandard.StdNumber);
					objPoint.UserData.Add("Standard Name     : " + objStandard.StdName);
					objPoint.UserData.Add("Concentration     : " + objStandard.Concentration);

					if (blnIsEmmission) {
						objPoint.UserData.Add("Emission         : " + FormatNumber(objStandard.Abs, CONST_Format_Value_Emission));
						//Saurabh Format to 3 decimal places 31.07.07
					} else {
						objPoint.UserData.Add("Absorbance        : " + FormatNumber(objStandard.Abs, CONST_Format_Value_Absorbance));
						//Saurabh Format to 3 decimal places 31.07.07
					}
					PointsNo = objStandard.StdNumber;
					//objPoint.pointinfo = new AldysGraph.Point._point_info( 

					objPoint.pointinfo = new Collections.ArrayList();
					objPoint.pointinfo.Add(pointinfo);
					ScatteredPointsCurve.ScatteredPoints.Add(objPoint);
				}

				if (!IsNothing(objSample)) {
					CONST_dblXpointTolerance = (this.XAxisMax - this.XAxisMin) * dblXFator / 100;
					CONST_dblYpointTolerance = (this.YAxisMax - this.YAxisMin) * dblXFator / 100;

					blnIsPointFound = false;
					objPoint = new AldysGraph.Point(objSample.Conc, objSample.Abs, intSamplePointIndex, blnIsInValid);
					objPoint.pointinfo = new Collections.ArrayList();
					intSamplePointIndex += 1;
					//Commented and added by Sachin Dokahle
					//objPoint.PointColor = ClsAAS203.SAMPCOLOR
					pointinfo = new AldysGraph.Point._point_info();
					//If objSample.Used = False Then
					//    objPoint.PointColor = ClsAAS203.BLACKCOLOR
					//Else
					//    objPoint.PointColor = ClsAAS203.SAMPCOLOR
					//End If

					pointinfo.IsUsed = objSample.Used;
					pointinfo.PointNo = PointsNo + objSample.SampNumber;
					pointinfo.PointsName = objSample.SampleName;
					//pointinfo.PointsType = AldysGraph.Point.points_type.Samp
					//objPoint.PointRadius = 2.0!

					if (IsNothing(objPoint.UserData))
						objPoint.UserData = new ArrayList();
					if (!(ScatteredPointsCurve.ScatteredPoints) == null) {
						if ((ScatteredPointsCurve.ScatteredPoints.Count > 0)) {
							objRestorePont = new ArrayList();
							for (intPointIdx = 0; intPointIdx <= ScatteredPointsCurve.ScatteredPoints.Count - 1; intPointIdx++) {
								objDuplicatePoint = ScatteredPointsCurve.ScatteredPoints(intPointIdx);
								if ((Math.Abs(objDuplicatePoint.X - objSample.Conc) <= CONST_dblXpointTolerance) & (Math.Abs(objDuplicatePoint.X - objSample.Conc) >= 0.0) & (Math.Abs(objDuplicatePoint.Y - objSample.Abs) <= CONST_dblYpointTolerance) & (Math.Abs(objDuplicatePoint.Y - objSample.Abs) >= 0.0)) {
									blnIsPointFound = true;
									objRestorePont = objDuplicatePoint.UserData.Clone;
									break; // TODO: might not be correct. Was : Exit For
								}
							}
						}

					}


					if (blnIsPointFound == true) {
						objPoint.UserData = objRestorePont.Clone;
						ArrayList ArrLstpointinfo = ScatteredPointsCurve.ScatteredPoints.Item(intPointIdx).pointinfo;
						objPoint.pointinfo = ArrLstpointinfo;
						AldysGraph.Point._point_info objPointInfo;
						bool blnFundStd = false;
						foreach ( objPointInfo in ArrLstpointinfo) {
							if (objPointInfo.PointsType == AldysGraph.Point.points_type.Std) {
								blnFundStd = true;
							}
						}

						if (blnFundStd == true) {
							objPoint.PointHeading = "Std/Sample Information";
							//If objSample.Used = False Then
							if (objPointInfo.IsUsed == false) {
								objPoint.PointColor = ClsAAS203.YELLOW;
							} else {
								objPoint.PointColor = ClsAAS203.GREEN;
							}
							if (ScatteredPointsCurve.ScatteredPoints.Item(intPointIdx).IsUse_btnRemove == true) {
								objPoint.IsUse_btnRemove = true;
							} else {
								objPoint.IsUse_btnRemove = false;
							}
							pointinfo.PointsType = AldysGraph.Point.points_type.StdSamp;
						} else {
							objPoint.PointHeading = "Sample Information";
							if (objSample.Used == false) {
								objPoint.PointColor = ClsAAS203.BLACKCOLOR;
							} else {
								objPoint.PointColor = ClsAAS203.SAMPCOLOR;
							}
							pointinfo.PointsType = AldysGraph.Point.points_type.Samp;
							objPoint.IsUse_btnRemove = false;
						}
					//objPoint.pointinfo.Add(pointinfo)
					} else {
						objPoint.PointHeading = "Sample Information";
						if (objSample.Used == false) {
							objPoint.PointColor = ClsAAS203.BLACKCOLOR;
						} else {
							objPoint.PointColor = ClsAAS203.SAMPCOLOR;
						}
						objPoint.IsUse_btnRemove = false;
						pointinfo.PointsType = AldysGraph.Point.points_type.Samp;
					}

					objPoint.UserData.Add("Sample No.          : " + objSample.SampNumber);
					objPoint.UserData.Add("Sample Name         : " + objSample.SampleName);
					objPoint.UserData.Add("Concentration       : " + FormatNumber(objSample.Conc, 2));
					//Saurabh Format to 2 decimal places 20.07.07
					if (blnIsEmmission) {
						objPoint.UserData.Add("Emission        : " + FormatNumber(objSample.Abs, CONST_Format_Value_Emission));
						//Saurabh Format to 3 decimal places 31.07.07
					} else {
						objPoint.UserData.Add("Absorbance      : " + FormatNumber(objSample.Abs, CONST_Format_Value_Absorbance));
						//Saurabh Format to 3 decimal places 31.07.07
					}
					//objPoint.pointinfo.Add(pointinfo)

					if (blnIsPointFound == true & intPointIdx > -1) {
						//ScatteredPointsCurve.ScatteredPoints.Insert(intPointIdx, objPoint)
						//If CType(objPoint.PointColor, System.Drawing.Color) Is CType(ClsAAS203.STDCOLOR, Color) Then


						//End If
						//For Each ArrLstpointinfo In ScatteredPointsCurve.ScatteredPoints.Item(intPointIdx).pointinfo

						//Next

						//Dim ArrLstpointinfo As ArrayList = ScatteredPointsCurve.ScatteredPoints.Item(intPointIdx).pointinfo
						//objPoint.pointinfo = ArrLstpointinfo
						objPoint.pointinfo.Add(pointinfo);
						ScatteredPointsCurve.ScatteredPoints.Item(intPointIdx) = objPoint;
					////ScatteredPointsCurve.ScatteredPoints.Item(intPointIdx).IsUse_btnRemove = True

					} else {
						//ScatteredPointsCurve.ScatteredPoints.Item(intPointIdx).IsUse_btnRemove = True
						//objPoint.IsUse_btnRemove = False
						objPoint.pointinfo.Add(pointinfo);
						ScatteredPointsCurve.ScatteredPoints.Add(objPoint);
					}

				}
				////ScatteredPointsCurve.ScatteredPoints.Add(objPoint)
				//ScatteredPointsCurve.ScatteredPoints(ScatteredPointsCurve.ScatteredPoints.Count-1).
				AldysPane.AxisChange();
				Invalidate();
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

	#End Region

}
