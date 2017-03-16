public class CommonGraphControl : AldysGraph.AldysGraph
{
	//************************************************************************************************************
	// File Header       : CommonGraphControl
	// File Name 		: CommonGraphControl.vb
	// Author			: Sachin Ashtankar
	// Date/Time			: 31-Oct-2004 03:30 PM
	// Description		: This class is use to Plot the generlised graph
	//************************************************************************************************************
	#Region " Component Designer generated code "

	public CommonGraphControl(System.ComponentModel.IContainer Container)
	{
		 // ERROR: Not supported in C#: ClassReferenceExpression
.New();
		try {
			Container.Add(this);
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

	public CommonGraphControl()
	{
		base.New();

		try {

			//This call is required by the Component Designer.
			InitializeComponent();

			//Add any initialization after the InitializeComponent() call
			strYAxisScale = "";

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

	//Component overrides dispose to clean up the component list.

	protected override void Dispose(bool disposing)
	{
		if (disposing) {
			if (!(components == null)) {
				components.Dispose();
			}
		}
		base.Dispose(disposing);
	}

	//Required by the Component Designer

	private System.ComponentModel.IContainer components;
	//NOTE: The following procedure is required by the Component Designer
	//It can be modified using the Component Designer.
	//Do not modify it using the code editor.
	internal NETXP.Controls.Bars.CommandBarButtonItem btnUseDefaultSettings;
	internal NETXP.Controls.Bars.CommandBarButtonItem btnGrid;
	internal NETXP.Controls.Bars.CommandContextMenu CommandContextMenus;
	internal NETXP.Controls.Bars.CommandBarButtonItem btnCustomizedGraph;
	internal NETXP.Controls.Bars.CommandBarButtonItem btnZoom;
	internal NETXP.Controls.Bars.CommandBarButtonItem btnPeakEdit;

	internal NETXP.Controls.Bars.CommandBarButtonItem btnLegends;
	internal NETXP.Controls.Bars.CommandBarSeparatorItem CommandBarSeparatorItem1;
	internal NETXP.Controls.Bars.CommandBarSeparatorItem CommandBarSeparatorItem2;
	internal NETXP.Controls.Bars.CommandBarSeparatorItem CommandBarSeparatorItem3;
	internal NETXP.Controls.Bars.CommandBarSeparatorItem CommandBarSeparatorItem4;
	internal NETXP.Controls.Bars.CommandBarButtonItem btnScale;
	internal NETXP.Controls.Bars.CommandBarButtonItem btnPrint;
	internal NETXP.Controls.Bars.CommandBarButtonItem btnPrintPreview;
	internal NETXP.Controls.Bars.CommandBarSeparatorItem CommandBarSeparatorItem5;
	internal NETXP.Controls.Bars.CommandBarSeparatorItem CommandBarSeparatorItem6;
	internal NETXP.Controls.Bars.CommandBarButtonItem btnSelectCurve;
	internal NETXP.Controls.Bars.CommandBarButtonItem btnDisablePeak;
	internal System.Windows.Forms.ToolTip ToolTip1;
	internal NETXP.Controls.Bars.CommandBarButtonItem btnShowCurveLabels;
	internal NETXP.Controls.Bars.CommandBarSeparatorItem CommandBarSeparatorItem7;

	internal NETXP.Controls.Bars.CommandBarButtonItem btnShowXYValues;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CommonGraphControl));
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
		this.CommandBarSeparatorItem1 = new NETXP.Controls.Bars.CommandBarSeparatorItem();
		this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
		//
		//CustPan
		//
		this.CustPan.Name = "CustPan";
		this.CustPan.Size = new System.Drawing.Size(150, 120);
		this.ToolTip1.SetToolTip(this.CustPan, "Right click here to see various graph options.");
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
		//
		//btnCustomizedGraph
		//
		this.btnCustomizedGraph.Text = "Customized Graph";
		//
		//btnPeakEdit
		//
		this.btnPeakEdit.Text = "Peak Edit";
		this.btnPeakEdit.Visible = false;
		//
		//CommandBarSeparatorItem3
		//
		this.CommandBarSeparatorItem3.Visible = false;
		//
		//btnGrid
		//
		this.btnGrid.Text = "Grid";
		//
		//btnZoom
		//
		this.btnZoom.Image = (System.Drawing.Image)resources.GetObject("btnZoom.Image");
		this.btnZoom.Text = "Zoom";
		//
		//btnLegends
		//
		this.btnLegends.Image = (System.Drawing.Image)resources.GetObject("btnLegends.Image");
		this.btnLegends.Text = "Legends";
		//
		//btnScale
		//
		this.btnScale.Image = (System.Drawing.Image)resources.GetObject("btnScale.Image");
		this.btnScale.Text = "Scale";
		//
		//btnPrint
		//
		this.btnPrint.Image = (System.Drawing.Image)resources.GetObject("btnPrint.Image");
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
		this.btnShowXYValues.ShowText = true;
		this.btnShowXYValues.Text = "Show X,Y Values";
		//
		//btnSelectCurve
		//
		this.btnSelectCurve.Image = (System.Drawing.Image)resources.GetObject("btnSelectCurve.Image");
		this.btnSelectCurve.Text = "Peak Curve";
		this.btnSelectCurve.Visible = false;
		//
		//btnDisablePeak
		//
		this.btnDisablePeak.Text = "Disable Peak";
		this.btnDisablePeak.Visible = false;
		//
		//btnShowCurveLabels
		//
		this.btnShowCurveLabels.ShowText = true;
		this.btnShowCurveLabels.Text = "Show Curve Labels";
		//
		//CommonGraphControl
		//
		this.Name = "CommonGraphControl";
		this.Size = new System.Drawing.Size(150, 120);

	}

	#End Region

	#Region " Event Declaration "

	public event  RestoreOrignalGraph;
	public event  RestoreOrignalSettings;
	public event  SetChangedSettings;

	#End Region

	#Region " Private Variables & Constants "

	private AldysGraph.AldysPane objBeforeZoomGraph;
	private bool blnShowRainBowBand = false;
		// A CurveItem type object to Plot the Curve on the Graph Rect
	private AldysGraph.CurveItem curve;

		// A String Type variable to store Scale to Y Axis i.e Reflectance, K/S, LOG(K/S)
	private string strYAxisScale;
		// A Data Table type object to get X and Y coordinates for the calling function
	private DataTable dtGraphData;

	private const string LOGKS = "LOG(K/S)";
	private const string KS = "K/S";

	private const string RFL = "REFLECTANCE";
	private const double Y_LOGKS_AXIS_MIN = -4.0;
	private const double Y_LOGKS_AXIS_MAX = 2.0;
	private const double Y_LOGKS_AXIS_MINIOR_STEP = 0.25;

	private const double Y_LOGKS_AXIS_STEP = 1;
	private const double Y_KS_AXIS_MIN = 0;
	private const double Y_KS_AXIS_MAX = 25;
	private const double Y_KS_AXIS_MINIOR_STEP = 1;

	private const double Y_KS_AXIS_STEP = 5;
	private const double Y_RFL_AXIS_MIN = 0;
	private const double Y_RFL_AXIS_MAX = 100;
	private const double Y_RFL_AXIS_MINIOR_STEP = 2;

	private const double Y_RFL_AXIS_STEP = 10;
	private const double X_AXIS_MINOR_STEP = 25;

	private const double X_AXIS_STEP = 100;

	private const string X_AXIS_TITLE = "Wavelength(nm)";
	private bool bToggleGraph;
	private int intGraphLeft;
	private int intGraphWidth;
	private int intGraphHeight;

	private int intGraphTop;
	//Private enumGraphSettings As New GraphSettings
	//Private enumGraphConstants As GraphSettings
	private Hashtable colSettings = new Hashtable();
	//Private objClsQAGeneral As New clsQAGeneral
	private AldysGraph.Defaults objDefaultSettings = new AldysGraph.Defaults();
	private bool blnUseDefaultSettings = true;
	private int intICurveCounter = 0;
	//Private objIniFileOperations As New clsIniFIleReadWrite
	private string frmName = "GeneralForm";
	string strSettings = "";
	//Dim strIniFilePath As String = Application.StartupPath & ConstGraphSettingsINIFileName

	#End Region

	#Region " Properties "

	//Sets the Scale for Y-Axis
	public string YScale {
		get { return strYAxisScale; }
		set { strYAxisScale = Value; }
	}
	//Sets the Data Table to extract X and Y coordinates
	public DataTable GraphDataSource {
		get { return dtGraphData; }
		set { dtGraphData = Value; }
	}

	internal Hashtable CustomizedGraphSettings {
		get { return colSettings; }
		set { colSettings = Value; }
	}

	public bool UseDefaultSettings {
		get { return blnUseDefaultSettings; }
		set { blnUseDefaultSettings = Value; }
	}

	public string ParentFormName {
		get { return (frmName); }
		set { frmName = Value; }
	}

	#End Region

	#Region " Private Functions "

	private bool AddHandlers()
	{
		AldysGraph.AldysGraph.StatusEvent += CommonGraphControl_StatusEvent;
		//AddHandler btnCustomizedGraph.Click, AddressOf submnuCustomize_Click
		btnGrid.Click += submnuGrid_Click;
		btnPeakEdit.Click += submnuPeakEdit_Click;
		btnPrint.Click += submnuPrint_Click;
		btnPrintPreview.Click += submnuPrintPreview_Click;
		btnZoom.Click += submnuZoom_Click;
		btnUseDefaultSettings.Click += submnuUseDefaultSettings_Click;
		//AddHandler btnScale.Click, AddressOf submnuScale_Click
		btnLegends.Click += mnuLegends_Click;
		btnDisablePeak.Click += btnDisablePeak_Click;
		btnShowCurveLabels.Click += btnShowCurveLabels_Click;
		//AddHandler Me.OnAxisChange, AddressOf LoadRainBowBand
		btnShowXYValues.Click += btnShowXYValues_Click;
		//AddHandler Me.CustPaneMouseDown, AddressOf CommonGraphControl_MouseDown

		//AddHandler Me.MouseDown, AddressOf Me_MouseDown
		//AddHandler CustPane.MouseDown, AddressOf CommonGraphControl_MouseDown
	}

	//Public Sub LoadRainBowBand()
	//    Dim RainBowBand As New RainbowBand.RainbowColorBand
	//    Dim ctrlRainBoBand As New RainbowBand.RainbowColorBand
	//    Try
	//        For Each ctrlRainBoBand In Me.CustPan.Controls
	//            ctrlRainBoBand.Dispose()
	//        Next

	//        RainBowBand.Location = New Point(Me.AldysPane.AxisRect.X, Me.AldysPane.AxisRect.Bottom)
	//        'RainBowBand.Location = New Point(Me.AldysPane.AxisRect.X, Me.AldysPane.AxisRect.Bottom + 48)
	//        RainBowBand.Width = Me.AldysPane.AxisRect.Width
	//        RainBowBand.Height = 8
	//        RainBowBand.MaxWavelength = Me.AldysPane.XAxis.Max
	//        RainBowBand.MinWavelength = Me.AldysPane.XAxis.Min
	//        If Me.AldysPane.XAxis.Max > 0 And Me.AldysPane.XAxis.Min > 0 Then
	//            RainBowBand.RGBData = gobjComputation.GetRainbowColors(Me.AldysPane.XAxis.Min, Me.AldysPane.XAxis.Max, 1)
	//            RainBowBand.ShowColorBand()
	//            Me.CustPan.Controls.Add(RainBowBand)
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

	//Private Function FillHashTableFromINIFile() As Boolean

	//    Dim strKey As String = ""
	//    Try

	//        colSettings.Clear()
	//        For Each strKey In enumGraphConstants.GetNames(GetType(GraphSettings))
	//            colSettings.Add(Trim(UCase(strKey)), objIniFileOperations.GetFromINI(UCase(frmName), UCase(strKey), ConstCheckStar))
	//        Next
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

	#End Region

	#Region " Component Events "

	private void  // ERROR: Handles clauses are not supported in C#
CommonGraphControl_CustPaneMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
	{
		try {
			btnGrid.Checked = AldysPane.XAxis.IsShowGrid;
			btnLegends.Checked = AldysPane.Legend.IsVisible;
			btnUseDefaultSettings.Checked = blnUseDefaultSettings;
			if (blnUseDefaultSettings == true) {
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
				btnShowCurveLabels.Visible = true;
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

	//Private Sub submnuCustomize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    Dim bSuccess As Boolean = False
	//    Try
	//        Dim frmGraphCust As New frmGraphCustmization(Me.AldysPane.Clone())
	//        '---Set the Graph type
	//        frmGraphCust.BackColor1 = Me.CustPan.BackColor
	//        frmGraphCust.BackColor2 = Me.CustPan.BackColor2
	//        frmGraphCust.GraphType = frmName 'ConstGraphTypeCommonGraphControl
	//        If frmGraphCust.ShowDialog() = (DialogResult.OK) Then
	//            Me.colSettings = frmGraphCust.colSettings.Clone()
	//            frmGraphCust.Close()
	//            btnCustomizedGraph.Checked = True
	//            btnUseDefaultSettings.Checked = False
	//            blnUseDefaultSettings = False
	//            bSuccess = objIniFileOperations.WriteToINI(UCase(frmName), ConstUseDefaultSettings, "False")
	//            Call SetCustomizedSettingsToGraph()
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

	private void submnuZoom_Click(System.Object sender, System.EventArgs e)
	{
		try {
			btnZoom.Checked = !(btnZoom.Checked);

			if (btnZoom.Checked == true) {
				this.Zoom = true;

				if (btnShowCurveLabels.Checked == true) {
					RemoveCurveLabels();
					btnShowCurveLabels.Checked = false;
				}

				blnShowRainBowBand = this.blnShowRainboBand;
				objBeforeZoomGraph = this.AldysPane.Clone();
			} else {
				this.Zoom = false;
				this.AldysPane = objBeforeZoomGraph.Clone();


				if (blnShowRainBowBand == true) {
					//Call LoadRainBowBand()
				}
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


	private void submnuPeakEdit_Click(System.Object sender, System.EventArgs e)
	{
		try {
			btnPeakEdit.Checked = !(btnPeakEdit.Checked);

			if (btnPeakEdit.Checked == true) {
				//Dim frmPeakEdit As New frmSelectPeakEdit
				AldysGraph.CurveItem curve;
				DataTable dtCurveNames = new DataTable();
				DataRow dtRow;

				dtCurveNames.Columns.Add("CurveIndex");
				dtCurveNames.Columns.Add("CurveName");


				intICurveCounter = 0;


				foreach ( curve in this.AldysPane.CurveList) {
					dtRow = dtCurveNames.NewRow;
					dtRow("CurveIndex") = intICurveCounter;

					if (Len(curve.Label) > 0) {
						dtRow("CurveName") = curve.Label;
					} else {
						dtRow("CurveName") = "Curve : " + intICurveCounter + 1;
					}

					dtCurveNames.Rows.Add(dtRow);


					intICurveCounter += 1;
				}

				//frmPeakEdit.CurveTable = dtCurveNames

				this.trackBarColor = Color.WhiteSmoke;


				this.peakLineWidth = 1;
				intICurveCounter = 0;

				Point pos = new Point();
				pos.X = MousePosition.X;
				pos.Y = MousePosition.Y;
				//frmPeakEdit.Location = pos
				//frmPeakEdit.Name = Me.Name

				this.pXYFont.IsFramed = true;
				this.pXYFont.Size = 14;
				//If frmPeakEdit.ShowDialog(Me) = DialogResult.OK Then
				//    intICurveCounter = CInt(frmPeakEdit.cmbCurveName.SelectedValue)
				//    Me.peakLineColor = Me.AldysPane.CurveList.Item(intICurveCounter).Line.Color()
				//    Me.ShowXYPeak = True
				//    Me.EnablePeakTrace(intICurveCounter, True)
				//    frmPeakEdit.Dispose()
				//Else
				//    Me.peakLineColor = Me.AldysPane.CurveList.Item(intICurveCounter).Line.Color()
				//    Me.ShowXYPeak = True
				//    Me.EnablePeakTrace(intICurveCounter, True)
				//    frmPeakEdit.Dispose()
				//End If
				dtCurveNames.Dispose();
				dtRow = null;
			} else {
				this.EnablePeakTrace(intICurveCounter, false);

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

	//Private Sub submnuScale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    Dim frmScale As New frmGraphScale
	//    Try
	//        ''17.03.06 deepak 
	//        'frmScale.NVXMin.MinimumRange = 300
	//        'frmScale.NVXMin.MaximumRange = 1100
	//        'frmScale.NVXMax.MinimumRange = 300
	//        'frmScale.NVXMax.MaximumRange = 1100
	//        'frmScale.NVYMin.MinimumRange = 0
	//        'frmScale.NVYMin.MaximumRange = 100
	//        'frmScale.NVYMax.MinimumRange = 0
	//        'frmScale.NVYMax.MaximumRange = 100
	//        ''17.03.06 deepak 

	//        frmScale.NVXMin.Text = AldysPane.XAxis.Min
	//        frmScale.NVXMax.Text = AldysPane.XAxis.Max

	//        frmScale.NVYMin.Text = AldysPane.YAxis.Min
	//        frmScale.NVYMax.Text = AldysPane.YAxis.Max

	//        If AldysPane.XAxis.Title = X_AXIS_TITLE Then
	//            frmScale.XAxisWavelength = True
	//        Else
	//            frmScale.XAxisWavelength = False
	//        End If

	//        If frmScale.ShowDialog(Me) = DialogResult.OK Then
	//            AldysPane.XAxis.Min = CDbl(frmScale.NVXMin.Text)
	//            AldysPane.XAxis.Max = CDbl(frmScale.NVXMax.Text)
	//            AldysPane.YAxis.Min = CDbl(frmScale.NVYMin.Text)
	//            AldysPane.YAxis.Max = CDbl(frmScale.NVYMax.Text)

	//            AldysPane.XAxis.MinorStepAuto = True
	//            AldysPane.XAxis.StepAuto = True
	//            AldysPane.YAxis.MinorStepAuto = True
	//            AldysPane.YAxis.StepAuto = True

	//            frmScale.Close()
	//            AldysPane.AxisChange()
	//            Me.Invalidate()
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

	private void submnuGrid_Click(System.Object sender, System.EventArgs e)
	{
		try {
			btnGrid.Checked = !(btnGrid.Checked);
			AldysPane.XAxis.IsShowGrid = btnGrid.Checked;
			AldysPane.YAxis.IsShowGrid = btnGrid.Checked;
			AldysPane.AxisChange();
			this.Invalidate();
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
		bool bSuccess = false;
		try {
			btnCustomizedGraph.Checked = false;
			btnUseDefaultSettings.Checked = true;
			blnUseDefaultSettings = true;
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

	private void  // ERROR: Handles clauses are not supported in C#
CommonGraphControl_DoubleClick(object sender, System.EventArgs e)
	{
		if (bToggleGraph == false) {
			this.Top = 0;
			this.Left = 0;
			this.Width = Parent.Width;
			this.Height = Parent.Height;
			bToggleGraph = true;
		} else {
			this.Left = intGraphLeft;
			this.Height = intGraphHeight;
			this.Width = intGraphWidth;
			this.Top = intGraphTop;
			bToggleGraph = false;
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
CommonGraphControl_Load(object sender, System.EventArgs e)
	{
		try {
			AddHandlers();

			this.SettingsChanged();

			if (!(this.ParentForm) == null) {
				frmName = this.ParentForm.Name;
			} else {
				frmName = this.Parent.Parent.Name;
			}

		//objIniFileOperations.INIFileName = strIniFilePath

		//strSettings = objIniFileOperations.GetFromINI(UCase(frmName), ConstUseDefaultSettings, ConstCheckStar)

		//If strSettings <> ConstCheckStar Then
		//    If UCase(strSettings) = UCase("True") Then
		//        UseDefaultSettings = True
		//    Else
		//        UseDefaultSettings = False
		//        Call FillHashTableFromINIFile()
		//        Call SetCustomizedSettingsToGraph()
		//    End If
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


	private void CommonGraphControl_StatusEvent(System.Object o, AldysGraph.CurveStatus e)
	{
	}

	private void  // ERROR: Handles clauses are not supported in C#
CommonGraphControl_peakEvent(object o, AldysGraph.PeakEditArgs e)
	{
		try {
		//AldysPane.XAxis.Title = "X : " & CStr(e.X) & "  Y : " & CStr(e.Y)
		//Me.Invalidate()
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
				if (blnShowRainBowBand == true) {
					this.blnShowRainboBand = true;
					blnShowRainBowBand = false;
				}
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

	private void Curve_Click(System.Object sender, System.EventArgs e)
	{
		try {
			if (this.blnShowRainboBand == true) {
				blnShowRainBowBand = true;
				this.blnShowRainboBand = false;
			}
			this.btnSelectCurve.Checked = true;
			this.trackBarColor = Color.Gainsboro;
			this.peakLineColor = this.AldysPane.CurveList.Item((int)sender.Tag).Line.Color();
			this.ShowXYPeak = true;
			this.EnablePeakTrace((int)sender.Tag, true);
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

	private void btnShowCurveLabels_Click(object sender, System.EventArgs e)
	{
		try {
			btnShowCurveLabels.Checked = !(btnShowCurveLabels.Checked);

			if (btnShowCurveLabels.Checked == true) {
				this.AldysPane.ShowCurveLabels = true;
				this.AldysPane.DrawCurveLabels();
				this.Invalidate();
			} else {
				this.AldysPane.ShowCurveLabels = false;
				RemoveCurveLabels();
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

	private void btnShowXYValues_Click(object sender, System.EventArgs e)
	{
		try {
			btnShowXYValues.Checked = !(btnShowXYValues.Checked);

			if (btnShowXYValues.Checked == true) {
				this.ShowXYValues = true;
			} else {
				this.ShowXYValues = false;
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

	#Region " Functions "

	private bool RemoveCurveLabels()
	{
		int intTextCount = 0;
		AldysGraph.CurveItem curve;
		try {
			foreach ( curve in this.AldysPane.CurveList) {
				if (!curve.LabelX == null) {
					curve.Label = curve.LabelX;
				}
			}


			for (intTextCount = 0; intTextCount <= this.AldysPane.TextList.Count - 1; intTextCount++) {
				if (this.AldysPane.TextList.Item(intTextCount).ForCurveLabel == true) {
					this.AldysPane.TextList.Remove(intTextCount);
					intTextCount -= 1;
					if (this.AldysPane.TextList.Count == 0)
						break; // TODO: might not be correct. Was : Exit For

				}
			}

			this.AldysPane.AxisChange();
			this.Invalidate();


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

	public bool ToggleGrid()
	{
		//=====================================================================
		// Procedure Name        : ToggleGrid
		// Parameters Passed     : Nothing
		// Returns               : Nothing
		// Purpose               : To Show the grid on the graph
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Ashtankar
		// Created               : 01-Nov-2004 03:30 PM
		// Revisions             : 
		//=====================================================================
		try {
			this.AldysPane.YAxis.IsShowGrid = !(this.AldysPane.YAxis.IsShowGrid);
			//Me.AldysPane.YAxis.GridColor = Color.CornflowerBlue
			this.AldysPane.XAxis.IsShowGrid = !(this.AldysPane.XAxis.IsShowGrid);
			//Me.AldysPane.XAxis.GridColor = Color.CornflowerBlue
			this.AldysPane.AxisChange();

			this.Invalidate();
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

	public bool PlotGraph()
	{
		//=====================================================================
		// Procedure Name        : PlotGraph
		// Parameters Passed     : Nothing
		// Returns               : True if graph plotted successfully else False
		// Purpose               : To Plot the Graph according to the specification
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
			ArrayList dblArrXCoordinates = new ArrayList();
			// A Double Type array to Store X-Coordinates to be plotted

			//---Clear the Items in the Curve List
			this.AldysPane.CurveList.Clear();
			this.AldysPane.TextList.Clear();

			//---Extract the value of X-Coordinates into a double type array
			if (dtGraphData.Rows.Count() > 0) {
				for (intICounter = 0; intICounter <= dtGraphData.Rows.Count() - 1; intICounter++) {
					dblArrXCoordinates.Add((double)dtGraphData.Rows.Item(intICounter).Item(0));
				}
			}

			//---Set the Properties of X-Axis
			this.AldysPane.XAxis.Type = AldysGraph.AxisType.Linear;
			this.AldysPane.XAxis.Title = X_AXIS_TITLE;
			this.AldysPane.XAxis.MaxAuto = false;
			this.AldysPane.XAxis.MinAuto = false;
			this.AldysPane.XAxis.StepAuto = false;
			this.AldysPane.XAxis.MinorStepAuto = false;
			this.AldysPane.XAxis.Min = (int)dtGraphData.Rows.Item(0).Item(0) + "";
			this.AldysPane.XAxis.Max = (int)dtGraphData.Rows.Item(dtGraphData.Rows.Count() - 1).Item(0) + "";
			this.AldysPane.XAxis.MinorStep = X_AXIS_MINOR_STEP;
			this.AldysPane.XAxis.Step = X_AXIS_STEP;

			//---Set the Properties of Y-Axis
			this.AldysPane.YAxis.MaxAuto = false;
			this.AldysPane.YAxis.MinAuto = false;
			this.AldysPane.YAxis.StepAuto = false;
			this.AldysPane.YAxis.MinorStepAuto = false;

			//If UCase(strYAxisScale.ToString) = LOGKS Or UCase(strYAxisScale.ToString) = constLOGABS Then
			//    Me.AldysPane.YAxis.Type = AldysGraph.AxisType.Linear
			//    Me.AldysPane.YAxis.Min = Y_LOGKS_AXIS_MIN
			//    Me.AldysPane.YAxis.Max = Y_LOGKS_AXIS_MAX
			//    Me.AldysPane.YAxis.MinorStep = Y_LOGKS_AXIS_MINIOR_STEP
			//    Me.AldysPane.YAxis.Step = Y_LOGKS_AXIS_STEP
			//ElseIf UCase(strYAxisScale.ToString) = KS Or UCase(strYAxisScale.ToString) = constABS Then
			//    Me.AldysPane.YAxis.Type = AldysGraph.AxisType.Linear
			//    Me.AldysPane.YAxis.Min = Y_KS_AXIS_MIN
			//    Me.AldysPane.YAxis.Max = Y_KS_AXIS_MAX
			//    Me.AldysPane.YAxis.MinorStep = Y_KS_AXIS_MINIOR_STEP
			//    Me.AldysPane.YAxis.Step = Y_KS_AXIS_STEP
			//ElseIf UCase(strYAxisScale.ToString) = RFL Or UCase(strYAxisScale.ToString) = constTRANS Then
			//    Me.AldysPane.YAxis.Type = AldysGraph.AxisType.Linear
			//    Me.AldysPane.YAxis.Min = Y_RFL_AXIS_MIN
			//    Me.AldysPane.YAxis.Max = Y_RFL_AXIS_MAX
			//    Me.AldysPane.YAxis.MinorStep = Y_RFL_AXIS_MINIOR_STEP
			//    Me.AldysPane.YAxis.Step = Y_RFL_AXIS_STEP
			//Else
			this.AldysPane.YAxis.Type = AldysGraph.AxisType.Linear;
			this.AldysPane.YAxis.Min = Y_RFL_AXIS_MIN;
			this.AldysPane.YAxis.Max = Y_RFL_AXIS_MAX;
			this.AldysPane.YAxis.MinorStep = Y_RFL_AXIS_MINIOR_STEP;
			this.AldysPane.YAxis.Step = Y_RFL_AXIS_STEP;
			//End If


			this.AldysPane.YAxis.Title = strYAxisScale;

			//---Draw the curve on the Graph Rect X Coordinates as Wavelength and Y coordinates as Rfl, K/S, Log K/S
			if (dtGraphData.Columns.Count > 0) {
				for (intICounter = 1; intICounter <= dtGraphData.Columns.Count() - 1; intICounter++) {
					ArrayList dblArrYCoordinates = new ArrayList();
					//---A Double Type array to Store Y-Coordinates to be plotted
					//---Extract the value of Y-Coordinates into a double type array for different Batch
					if (dtGraphData.Rows.Count() > 0) {
						for (intJCounter = 0; intJCounter <= dtGraphData.Rows.Count() - 1; intJCounter++) {
							dblArrYCoordinates.Add((double)dtGraphData.Rows.Item(intJCounter).Item(intICounter) + "");
						}
					}

					//---Add the Curve in Curve List
					curve = this.AldysPane.AddCurve((string)dtGraphData.Columns.Item(intICounter).ColumnName + "", dblArrXCoordinates, dblArrYCoordinates, GetColor(intICounter - 1), AldysGraph.SymbolType.NoSymbol);
					curve.Line.Style = Drawing2D.DashStyle.Solid;
				}
			}

			//---Set the Properties of graph
			if (blnUseDefaultSettings == true) {
				SetDefaultSettingsToGraph();
			} else {
				//Call SetCustomizedSettingsToGraph()
			}

			this.AldysPane.Title = "";
			//---strYAxisScale & " Vs " & X_AXIS_TITLE

			//AldysPane.Legend.IsVisible = False
			this.AldysPane.YAxis.LowerAlarmLine = true;
			this.AldysPane.YAxis.LowerAlarmLineY = 0f;
			this.AldysPane.YAxis.LowerAlarmLineColor = Color.Black;

			btnShowCurveLabels.Checked = false;
			btnZoom.Checked = false;

			//---Force the Graph control to Draw according to the Change in Specification
			this.AldysPane.AxisChange();
			this.Invalidate();
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

	//Public Function SetCustomizedSettingsToGraph() As Boolean

	//    Try
	//        If colSettings.Count > 0 Then

	//            '---Axis Pane-------
	//            'If CStr(colSettings.Item(UCase(enumGraphSettings.AxisPaneBackColor.ToString()))) <> ConstCheckStar Then
	//            '    AldysPane.AxisBackColor = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.AxisPaneBackColor.ToString()))))
	//            'Else
	//            '    AldysPane.AxisBackColor = objDefaultSettings.Axis.BackColor
	//            'End If

	//            If CStr(colSettings.Item(UCase(enumGraphSettings.AxisPaneFrameColor.ToString()))) <> ConstCheckStar Then
	//                AldysPane.AxisFrameColor = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.AxisPaneFrameColor.ToString()))))
	//            Else
	//                AldysPane.AxisFrameColor = objDefaultSettings.Axis.FrameColor
	//            End If
	//            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.AxisPaneIsFramed.ToString())))) <> ConstCheckStar Then
	//                AldysPane.IsAxisFramed = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.AxisPaneIsFramed.ToString()))))) = UCase("True"), "True", "False"))
	//            Else
	//                AldysPane.IsAxisFramed = objDefaultSettings.Axis.IsFramed
	//            End If

	//            '---Graph Pane---
	//            'If CStr(colSettings.Item(UCase(enumGraphSettings.GraphPaneBackColor.ToString()))) <> ConstCheckStar Then
	//            '    AldysPane.PaneBackColor = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.GraphPaneBackColor.ToString()))))
	//            'Else
	//            '    AldysPane.PaneBackColor = objDefaultSettings.Pane.BackColor
	//            'End If

	//            If CStr(colSettings.Item(UCase(enumGraphSettings.GraphPaneFrameColor.ToString()))) <> ConstCheckStar Then
	//                AldysPane.PaneFrameColor = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.GraphPaneFrameColor.ToString()))))
	//            Else
	//                AldysPane.PaneFrameColor = objDefaultSettings.Pane.FrameColor
	//            End If

	//            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.GraphPaneIsFramed.ToString())))) <> ConstCheckStar Then
	//                AldysPane.IsPaneFramed = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.GraphPaneIsFramed.ToString()))))) = UCase("True"), "True", "False"))
	//            Else
	//                AldysPane.IsPaneFramed = objDefaultSettings.Pane.IsFramed
	//            End If

	//            '---Graph Title
	//            If CStr(colSettings.Item(UCase(enumGraphSettings.GraphTitleFillColor.ToString()))) <> ConstCheckStar Then
	//                AldysPane.FontSpec.FontColor = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.GraphTitleFillColor.ToString()))))
	//            Else
	//                AldysPane.FontSpec.FontColor = objDefaultSettings.Pane.FontColor
	//            End If

	//            If CStr(colSettings.Item(UCase(enumGraphSettings.GraphTitleFrameColor.ToString()))) <> ConstCheckStar Then
	//                AldysPane.FontSpec.FrameColor = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.GraphTitleFrameColor.ToString()))))
	//            Else
	//                AldysPane.FontSpec.FrameColor = objDefaultSettings.Pane.FrameColor
	//            End If

	//            If CStr(colSettings.Item(UCase(enumGraphSettings.GraphTitleFillColor.ToString()))) <> ConstCheckStar Then
	//                AldysPane.FontSpec.FillColor = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.GraphTitleFillColor.ToString()))))
	//            Else
	//                AldysPane.FontSpec.FillColor = objDefaultSettings.Pane.BackColor
	//            End If

	//            If CStr(colSettings.Item(UCase(enumGraphSettings.GraphTitleFontSpceSize.ToString()))) <> ConstCheckStar Then
	//                AldysPane.FontSpec.Size = CSng(colSettings.Item(UCase(enumGraphSettings.GraphTitleFontSpceSize.ToString())))
	//            Else
	//                AldysPane.FontSpec.Size = objDefaultSettings.Pane.FontSize
	//            End If

	//            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.GraphTitleFontSpceFamily.ToString())))) <> ConstCheckStar Then
	//                AldysPane.FontSpec.Family = CStr(colSettings.Item(UCase(CStr(enumGraphSettings.GraphTitleFontSpceFamily.ToString()))))
	//            Else
	//                AldysPane.FontSpec.Family = objDefaultSettings.Pane.FontFamily
	//            End If

	//            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.GraphTitleFontSpceBold.ToString())))) <> ConstCheckStar Then
	//                AldysPane.FontSpec.IsBold = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.GraphTitleFontSpceBold.ToString()))))) = UCase("True"), "True", "False"))
	//            Else
	//                AldysPane.FontSpec.IsBold = objDefaultSettings.Pane.FontBold
	//            End If

	//            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.GraphTitleFontSpceItalic.ToString())))) <> ConstCheckStar Then
	//                AldysPane.FontSpec.IsItalic = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.GraphTitleFontSpceItalic.ToString()))))) = UCase("True"), "True", "False"))
	//            Else
	//                AldysPane.FontSpec.IsItalic = objDefaultSettings.Pane.FontItalic
	//            End If

	//            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.GraphTitleFontSpceUnderlined.ToString())))) <> ConstCheckStar Then
	//                AldysPane.FontSpec.IsUnderline = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.GraphTitleFontSpceUnderlined.ToString()))))) = UCase("True"), "True", "False"))
	//            Else
	//                AldysPane.FontSpec.IsUnderline = objDefaultSettings.Pane.FontUnderline
	//            End If



	//            '---XAxis----
	//            If CStr(colSettings.Item(UCase(enumGraphSettings.XAxisGridColor.ToString()))) <> ConstCheckStar Then
	//                AldysPane.XAxis.GridColor = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.XAxisGridColor.ToString()))))
	//            Else
	//                AldysPane.XAxis.GridColor = objDefaultSettings.Axis.GridColor
	//            End If

	//            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisGridIsShowGrid.ToString())))) <> ConstCheckStar Then
	//                AldysPane.XAxis.IsShowGrid = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisGridIsShowGrid.ToString()))))) = UCase("True"), "True", "False"))
	//            Else
	//                AldysPane.XAxis.IsShowGrid = objDefaultSettings.Axis.IsShowGrid
	//            End If

	//            If CStr(colSettings.Item(UCase(enumGraphSettings.XAxisTitleFillColor.ToString()))) <> ConstCheckStar Then
	//                AldysPane.XAxis.TitleFontSpec.FillColor = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.XAxisTitleFillColor.ToString()))))
	//            Else
	//                AldysPane.XAxis.TitleFontSpec.FillColor = Color.Transparent
	//            End If

	//            If CStr(colSettings.Item(UCase(enumGraphSettings.XAxisTitleFontSpceColor.ToString()))) <> ConstCheckStar Then
	//                AldysPane.XAxis.TitleFontSpec.FontColor = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.XAxisTitleFontSpceColor.ToString()))))
	//            Else
	//                AldysPane.XAxis.TitleFontSpec.FontColor = objDefaultSettings.Axis.TitleFontColor
	//            End If
	//            If CStr(colSettings.Item(UCase(enumGraphSettings.XAxisTitleFrameColor.ToString()))) <> ConstCheckStar Then
	//                AldysPane.XAxis.TitleFontSpec.FrameColor = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.XAxisTitleFrameColor.ToString()))))
	//            Else
	//                AldysPane.XAxis.TitleFontSpec.FrameColor = objDefaultSettings.Axis.FrameColor
	//            End If

	//            If CStr(colSettings.Item(UCase(enumGraphSettings.XAxisTitleFontSpceSize.ToString()))) <> ConstCheckStar Then
	//                AldysPane.XAxis.TitleFontSpec.Size = CSng(colSettings.Item(UCase(enumGraphSettings.XAxisTitleFontSpceSize.ToString())))
	//            Else
	//                AldysPane.XAxis.TitleFontSpec.Size = objDefaultSettings.Axis.TitleFontSize
	//            End If

	//            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisTitleIsFilled.ToString())))) <> ConstCheckStar Then
	//                AldysPane.XAxis.TitleFontSpec.IsFilled = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisTitleIsFilled.ToString()))))) = UCase("True"), "True", "False"))
	//            Else
	//                AldysPane.XAxis.TitleFontSpec.IsFilled = False
	//            End If

	//            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisTitleIsFramed.ToString())))) <> ConstCheckStar Then
	//                AldysPane.XAxis.TitleFontSpec.IsFramed = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisTitleIsFramed.ToString()))))) = UCase("True"), "True", "False"))
	//            Else
	//                AldysPane.XAxis.TitleFontSpec.IsFramed = False
	//            End If

	//            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisTitleFontSpceBold.ToString())))) <> ConstCheckStar Then
	//                AldysPane.XAxis.TitleFontSpec.IsBold = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisTitleFontSpceBold.ToString()))))) = UCase("True"), "True", "False"))
	//            Else
	//                AldysPane.XAxis.TitleFontSpec.IsBold = objDefaultSettings.Axis.TitleFontBold
	//            End If

	//            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisTitleFontSpceItalic.ToString())))) <> ConstCheckStar Then
	//                AldysPane.XAxis.TitleFontSpec.IsItalic = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisTitleFontSpceItalic.ToString()))))) = UCase("True"), "True", "False"))
	//            Else
	//                AldysPane.XAxis.TitleFontSpec.IsItalic = objDefaultSettings.Axis.TitleFontItalic
	//            End If

	//            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisTitleFontSpceUnderlined.ToString())))) <> ConstCheckStar Then
	//                AldysPane.XAxis.TitleFontSpec.IsUnderline = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisTitleFontSpceUnderlined.ToString()))))) = UCase("True"), "True", "False"))
	//            Else
	//                AldysPane.XAxis.TitleFontSpec.IsUnderline = objDefaultSettings.Axis.TitleFontUnderline
	//            End If

	//            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisTitleFontSpceFamily.ToString())))) <> ConstCheckStar Then
	//                AldysPane.XAxis.TitleFontSpec.Family = CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisTitleFontSpceFamily.ToString()))))
	//            Else
	//                AldysPane.XAxis.TitleFontSpec.Family = objDefaultSettings.Axis.TitleFontFamily
	//            End If

	//            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisScaleFontSpceFamily.ToString())))) <> ConstCheckStar Then
	//                AldysPane.XAxis.ScaleFontSpec.Family = CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisScaleFontSpceFamily.ToString()))))
	//            Else
	//                AldysPane.XAxis.ScaleFontSpec.Family = objDefaultSettings.Axis.ScaleFontFamily
	//            End If

	//            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisScaleFontSpceBold.ToString())))) <> ConstCheckStar Then
	//                AldysPane.XAxis.ScaleFontSpec.IsBold = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisScaleFontSpceBold.ToString()))))) = UCase("True"), "True", "False"))
	//            Else
	//                AldysPane.XAxis.ScaleFontSpec.IsBold = objDefaultSettings.Axis.ScaleFontBold
	//            End If
	//            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisScaleFontSpceItalic.ToString())))) <> ConstCheckStar Then
	//                AldysPane.XAxis.ScaleFontSpec.IsItalic = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisScaleFontSpceItalic.ToString()))))) = UCase("True"), "True", "False"))
	//            Else
	//                AldysPane.XAxis.ScaleFontSpec.IsItalic = objDefaultSettings.Axis.ScaleFontItalic
	//            End If

	//            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisScaleFontSpceUnderlined.ToString())))) <> ConstCheckStar Then
	//                AldysPane.XAxis.ScaleFontSpec.IsUnderline = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisScaleFontSpceUnderlined.ToString()))))) = UCase("True"), "True", "False"))
	//            Else
	//                AldysPane.XAxis.ScaleFontSpec.IsUnderline = objDefaultSettings.Axis.ScaleFontUnderline
	//            End If
	//            If CStr(colSettings.Item(UCase(enumGraphSettings.XAxisScaleFontSpceSize.ToString()))) <> ConstCheckStar Then
	//                AldysPane.XAxis.ScaleFontSpec.Size = CSng(colSettings.Item(UCase(enumGraphSettings.XAxisScaleFontSpceSize.ToString())))
	//            Else
	//                AldysPane.XAxis.ScaleFontSpec.Size = objDefaultSettings.Axis.ScaleFontSize
	//            End If


	//            '---YAxis----
	//            If CStr(colSettings.Item(UCase(enumGraphSettings.YAxisGridColor.ToString()))) <> ConstCheckStar Then
	//                AldysPane.YAxis.GridColor = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.YAxisGridColor.ToString()))))
	//            Else
	//                AldysPane.YAxis.GridColor = objDefaultSettings.Axis.GridColor
	//            End If

	//            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisGridIsShowGrid.ToString())))) <> ConstCheckStar Then
	//                AldysPane.YAxis.IsShowGrid = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisGridIsShowGrid.ToString()))))) = UCase("True"), "True", "False"))
	//            Else
	//                AldysPane.YAxis.IsShowGrid = objDefaultSettings.Axis.IsShowGrid
	//            End If

	//            If CStr(colSettings.Item(UCase(enumGraphSettings.YAxisTitleFillColor.ToString()))) <> ConstCheckStar Then
	//                AldysPane.YAxis.TitleFontSpec.FillColor = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.YAxisTitleFillColor.ToString()))))
	//            Else
	//                AldysPane.YAxis.TitleFontSpec.FillColor = Color.Transparent
	//            End If

	//            If CStr(colSettings.Item(UCase(enumGraphSettings.YAxisTitleFontSpceColor.ToString()))) <> ConstCheckStar Then
	//                AldysPane.YAxis.TitleFontSpec.FontColor = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.YAxisTitleFontSpceColor.ToString()))))
	//            Else
	//                AldysPane.YAxis.TitleFontSpec.FontColor = objDefaultSettings.Axis.TitleFontColor
	//            End If
	//            If CStr(colSettings.Item(UCase(enumGraphSettings.YAxisTitleFrameColor.ToString()))) <> ConstCheckStar Then
	//                AldysPane.YAxis.TitleFontSpec.FrameColor = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.YAxisTitleFrameColor.ToString()))))
	//            Else
	//                AldysPane.YAxis.TitleFontSpec.FrameColor = objDefaultSettings.Axis.FrameColor
	//            End If

	//            If CStr(colSettings.Item(UCase(enumGraphSettings.YAxisTitleFontSpceSize.ToString()))) <> ConstCheckStar Then
	//                AldysPane.YAxis.TitleFontSpec.Size = CSng(colSettings.Item(UCase(enumGraphSettings.YAxisTitleFontSpceSize.ToString())))
	//            Else
	//                AldysPane.YAxis.TitleFontSpec.Size = objDefaultSettings.Axis.TitleFontSize
	//            End If

	//            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisTitleIsFilled.ToString())))) <> ConstCheckStar Then
	//                AldysPane.YAxis.TitleFontSpec.IsFilled = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisTitleIsFilled.ToString()))))) = UCase("True"), "True", "False"))
	//            Else
	//                AldysPane.YAxis.TitleFontSpec.IsFilled = False
	//            End If
	//            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisTitleIsFramed.ToString())))) <> ConstCheckStar Then
	//                AldysPane.YAxis.TitleFontSpec.IsFramed = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisTitleIsFramed.ToString()))))) = UCase("True"), "True", "False"))
	//            Else
	//                AldysPane.YAxis.TitleFontSpec.IsFramed = False
	//            End If

	//            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisTitleFontSpceBold.ToString())))) <> ConstCheckStar Then
	//                AldysPane.YAxis.TitleFontSpec.IsBold = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisTitleFontSpceBold.ToString()))))) = UCase("True"), "True", "False"))
	//            Else
	//                AldysPane.YAxis.TitleFontSpec.IsBold = objDefaultSettings.Axis.TitleFontBold
	//            End If

	//            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisTitleFontSpceItalic.ToString())))) <> ConstCheckStar Then
	//                AldysPane.YAxis.TitleFontSpec.IsItalic = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisTitleFontSpceItalic.ToString()))))) = UCase("True"), "True", "False"))
	//            Else
	//                AldysPane.YAxis.TitleFontSpec.IsItalic = objDefaultSettings.Axis.TitleFontItalic
	//            End If

	//            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisTitleFontSpceUnderlined.ToString())))) <> ConstCheckStar Then
	//                AldysPane.YAxis.TitleFontSpec.IsUnderline = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisTitleFontSpceUnderlined.ToString()))))) = UCase("True"), "True", "False"))
	//            Else
	//                AldysPane.YAxis.TitleFontSpec.IsUnderline = objDefaultSettings.Axis.TitleFontUnderline
	//            End If

	//            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisTitleFontSpceFamily.ToString())))) <> ConstCheckStar Then
	//                AldysPane.YAxis.TitleFontSpec.Family = CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisTitleFontSpceFamily.ToString()))))
	//            Else
	//                AldysPane.YAxis.TitleFontSpec.Family = objDefaultSettings.Axis.TitleFontFamily
	//            End If

	//            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisScaleFontSpceFamily.ToString())))) <> ConstCheckStar Then
	//                AldysPane.YAxis.ScaleFontSpec.Family = CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisScaleFontSpceFamily.ToString()))))
	//            Else
	//                AldysPane.YAxis.ScaleFontSpec.Family = objDefaultSettings.Axis.ScaleFontFamily
	//            End If

	//            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisScaleFontSpceBold.ToString())))) <> ConstCheckStar Then
	//                AldysPane.YAxis.ScaleFontSpec.IsBold = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisScaleFontSpceBold.ToString()))))) = UCase("True"), "True", "False"))
	//            Else
	//                AldysPane.YAxis.ScaleFontSpec.IsBold = objDefaultSettings.Axis.ScaleFontBold
	//            End If
	//            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisScaleFontSpceItalic.ToString())))) <> ConstCheckStar Then
	//                AldysPane.YAxis.ScaleFontSpec.IsItalic = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisScaleFontSpceItalic.ToString()))))) = UCase("True"), "True", "False"))
	//            Else
	//                AldysPane.YAxis.ScaleFontSpec.IsItalic = objDefaultSettings.Axis.ScaleFontItalic
	//            End If

	//            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisScaleFontSpceUnderlined.ToString())))) <> ConstCheckStar Then
	//                AldysPane.YAxis.ScaleFontSpec.IsUnderline = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisScaleFontSpceUnderlined.ToString()))))) = UCase("True"), "True", "False"))
	//            Else
	//                AldysPane.YAxis.ScaleFontSpec.IsUnderline = objDefaultSettings.Axis.ScaleFontUnderline
	//            End If
	//            If CStr(colSettings.Item(UCase(enumGraphSettings.YAxisScaleFontSpceSize.ToString()))) <> ConstCheckStar Then
	//                AldysPane.YAxis.ScaleFontSpec.Size = CSng(colSettings.Item(UCase(enumGraphSettings.YAxisScaleFontSpceSize.ToString())))
	//            Else
	//                AldysPane.YAxis.ScaleFontSpec.Size = objDefaultSettings.Axis.ScaleFontSize
	//            End If

	//            '-----Legends-----
	//            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.LegendsIsFilled.ToString())))) <> ConstCheckStar Then
	//                AldysPane.Legend.IsFilled = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.LegendsIsFilled.ToString()))))) = UCase("True"), "True", "False"))
	//            Else
	//                AldysPane.Legend.IsFilled = objDefaultSettings.Legend.IsFilled
	//            End If

	//            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.LegendsIsFramed.ToString())))) <> ConstCheckStar Then
	//                AldysPane.Legend.IsFramed = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.LegendsIsFramed.ToString()))))) = UCase("True"), "True", "False"))
	//            Else
	//                AldysPane.Legend.IsFramed = objDefaultSettings.Legend.IsFramed
	//            End If

	//            If CStr(colSettings.Item(UCase(enumGraphSettings.LegendsFillColor.ToString()))) <> ConstCheckStar Then
	//                AldysPane.Legend.FillColor = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.LegendsFillColor.ToString()))))
	//            Else
	//                AldysPane.Legend.FillColor = objDefaultSettings.Legend.FillColor
	//            End If

	//            If CStr(colSettings.Item(UCase(enumGraphSettings.LegendsFrameColor.ToString()))) <> ConstCheckStar Then
	//                AldysPane.Legend.FrameColor = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.LegendsFrameColor.ToString()))))
	//            Else
	//                AldysPane.Legend.FrameColor = objDefaultSettings.Legend.FrameColor
	//            End If

	//            If CStr(colSettings.Item(UCase(enumGraphSettings.LegendsFontSpceColor.ToString()))) <> ConstCheckStar Then
	//                AldysPane.Legend.FontSpec.FontColor = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.LegendsFontSpceColor.ToString()))))
	//            Else
	//                AldysPane.Legend.FontSpec.FontColor = objDefaultSettings.Legend.FontColor
	//            End If

	//            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.LegendsFontSpceFamily.ToString())))) <> ConstCheckStar Then
	//                AldysPane.Legend.FontSpec.Family = CStr(colSettings.Item(UCase(CStr(enumGraphSettings.LegendsFontSpceFamily.ToString()))))
	//            Else
	//                AldysPane.Legend.FontSpec.Family = objDefaultSettings.Legend.FontFamily
	//            End If

	//            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.LegendsFontSpceBold.ToString())))) <> ConstCheckStar Then
	//                AldysPane.Legend.FontSpec.IsBold = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.LegendsFontSpceBold.ToString()))))) = UCase("True"), "True", "False"))
	//            Else
	//                AldysPane.Legend.FontSpec.IsBold = objDefaultSettings.Legend.FontBold
	//            End If

	//            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.LegendsFontSpceItalic.ToString())))) <> ConstCheckStar Then
	//                AldysPane.Legend.FontSpec.IsItalic = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.LegendsFontSpceItalic.ToString()))))) = UCase("True"), "True", "False"))
	//            Else
	//                AldysPane.Legend.FontSpec.IsItalic = objDefaultSettings.Legend.FontItalic
	//            End If

	//            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.LegendsFontSpceUnderlined.ToString())))) <> ConstCheckStar Then
	//                AldysPane.Legend.FontSpec.IsUnderline = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.LegendsFontSpceUnderlined.ToString()))))) = UCase("True"), "True", "False"))
	//            Else
	//                AldysPane.Legend.FontSpec.IsUnderline = objDefaultSettings.Legend.FontUnderline
	//            End If

	//            If CStr(colSettings.Item(UCase(enumGraphSettings.LegendsFontSpceSize.ToString()))) <> ConstCheckStar Then
	//                AldysPane.Legend.FontSpec.Size = CSng(colSettings.Item(UCase(enumGraphSettings.LegendsFontSpceSize.ToString())))
	//            Else
	//                AldysPane.Legend.FontSpec.Size = objDefaultSettings.Legend.FontSize
	//            End If

	//            AldysPane.AxisBackColor = Color.Transparent
	//            AldysPane.PaneBackColor = Color.Transparent

	//            If CStr(colSettings.Item(UCase(enumGraphSettings.GraphPaneBackColor.ToString()))) <> ConstCheckStar Then
	//                Me.CustPan.BackColor = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.GraphPaneBackColor.ToString()))))
	//            Else
	//                Me.CustPan.BackColor = Color.Gainsboro
	//            End If

	//            If CStr(colSettings.Item(UCase(enumGraphSettings.GraphPaneBackColor2.ToString()))) <> ConstCheckStar Then
	//                Me.CustPan.BackColor2 = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.GraphPaneBackColor2.ToString()))))
	//            Else
	//                Me.CustPan.BackColor2 = Color.White
	//            End If

	//            AldysPane.AxisChange()
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
	//End Function

	public bool SetDefaultSettingsToGraph()
	{


		try {
			AldysPane.Legend.IsVisible = true;
			AldysPane.Legend.FillColor = objDefaultSettings.Legend.FillColor;
			AldysPane.Legend.FrameColor = objDefaultSettings.Legend.FrameColor;
			AldysPane.Legend.IsFilled = objDefaultSettings.Legend.IsFilled;
			AldysPane.Legend.IsFramed = objDefaultSettings.Legend.IsFramed;

			AldysPane.FontSpec.FontColor = objDefaultSettings.Pane.FontColor;
			AldysPane.FontSpec.FrameColor = objDefaultSettings.Pane.FrameColor;
			AldysPane.FontSpec.FillColor = objDefaultSettings.Pane.BackColor;
			AldysPane.FontSpec.Size = objDefaultSettings.Pane.FontSize;
			AldysPane.FontSpec.Family = objDefaultSettings.Pane.FontFamily;
			AldysPane.FontSpec.IsBold = objDefaultSettings.Pane.FontBold;
			AldysPane.FontSpec.IsItalic = objDefaultSettings.Pane.FontItalic;
			AldysPane.FontSpec.IsUnderline = objDefaultSettings.Pane.FontUnderline;

			AldysPane.XAxis.GridColor = Color.FromArgb(175, 200, 245);
			//  objDefaultSettings.Axis.GridColor
			AldysPane.XAxis.IsShowGrid = objDefaultSettings.Axis.IsShowGrid;
			AldysPane.XAxis.IsShowGrid = objDefaultSettings.Axis.IsShowGrid;
			AldysPane.XAxis.TitleFontSpec.FillColor = Color.Transparent;
			AldysPane.XAxis.TitleFontSpec.FrameColor = objDefaultSettings.Axis.FrameColor;
			AldysPane.XAxis.TitleFontSpec.FontColor = objDefaultSettings.Axis.TitleFontColor;
			AldysPane.XAxis.TitleFontSpec.Size = objDefaultSettings.Axis.TitleFontSize;
			AldysPane.XAxis.TitleFontSpec.IsFramed = false;
			AldysPane.XAxis.TitleFontSpec.IsFilled = false;
			AldysPane.XAxis.TitleFontSpec.IsBold = objDefaultSettings.Axis.TitleFontBold;
			AldysPane.XAxis.TitleFontSpec.IsItalic = objDefaultSettings.Axis.TitleFontItalic;
			AldysPane.XAxis.TitleFontSpec.IsUnderline = objDefaultSettings.Axis.TitleFontUnderline;
			AldysPane.XAxis.TitleFontSpec.Family = objDefaultSettings.Axis.TitleFontFamily;
			AldysPane.XAxis.ScaleFontSpec.Family = objDefaultSettings.Axis.ScaleFontFamily;
			AldysPane.XAxis.ScaleFontSpec.IsBold = objDefaultSettings.Axis.ScaleFontBold;
			AldysPane.XAxis.ScaleFontSpec.IsItalic = objDefaultSettings.Axis.ScaleFontItalic;
			AldysPane.XAxis.ScaleFontSpec.IsUnderline = objDefaultSettings.Axis.ScaleFontUnderline;

			AldysPane.YAxis.GridColor = Color.FromArgb(175, 200, 245);
			//objDefaultSettings.Axis.GridColor
			AldysPane.YAxis.IsShowGrid = objDefaultSettings.Axis.IsShowGrid;
			AldysPane.YAxis.IsShowGrid = objDefaultSettings.Axis.IsShowGrid;
			AldysPane.YAxis.TitleFontSpec.FillColor = Color.Transparent;
			AldysPane.YAxis.TitleFontSpec.FrameColor = objDefaultSettings.Axis.FrameColor;
			AldysPane.YAxis.TitleFontSpec.FontColor = objDefaultSettings.Axis.TitleFontColor;
			AldysPane.YAxis.TitleFontSpec.Size = objDefaultSettings.Axis.TitleFontSize;
			AldysPane.YAxis.TitleFontSpec.IsFramed = false;
			AldysPane.YAxis.TitleFontSpec.IsFilled = false;
			AldysPane.YAxis.TitleFontSpec.IsBold = objDefaultSettings.Axis.TitleFontBold;
			AldysPane.YAxis.TitleFontSpec.IsItalic = objDefaultSettings.Axis.TitleFontItalic;
			AldysPane.YAxis.TitleFontSpec.IsUnderline = objDefaultSettings.Axis.TitleFontUnderline;
			AldysPane.YAxis.TitleFontSpec.Family = objDefaultSettings.Axis.TitleFontFamily;
			AldysPane.YAxis.ScaleFontSpec.Family = objDefaultSettings.Axis.ScaleFontFamily;
			AldysPane.YAxis.ScaleFontSpec.IsBold = objDefaultSettings.Axis.ScaleFontBold;
			AldysPane.YAxis.ScaleFontSpec.IsItalic = objDefaultSettings.Axis.ScaleFontItalic;
			AldysPane.YAxis.ScaleFontSpec.IsUnderline = objDefaultSettings.Axis.ScaleFontUnderline;

			AldysPane.PaneBackColor = Color.Transparent;
			//objDefaultSettings.Pane.BackColor
			AldysPane.PaneFrameColor = Color.Transparent;
			//objDefaultSettings.Pane.FrameColor
			AldysPane.IsPaneFramed = false;
			// objDefaultSettings.Pane.IsFramed

			AldysPane.AxisBackColor = Color.Transparent;
			//objDefaultSettings.Axis.BackColor
			AldysPane.AxisFrameColor = Color.FromArgb(175, 200, 245);
			//objDefaultSettings.Axis.FrameColor
			AldysPane.IsAxisFramed = true;
			//objDefaultSettings.Axis.IsFramed
			AldysPane.IsShowTitle = false;
			//---------------------------------
			this.CustPan.GradientMode = GradientPanel.LinearGradientMode.Vertical;
			this.CustPan.BackColor = Color.Gainsboro;
			this.CustPan.BackColor2 = Color.White;
			//---------------------------------

			//---added by deepak b on 09.02.06 
			//---for curve lebels 
			if (btnShowCurveLabels.Checked == true) {
				this.AldysPane.ShowCurveLabels = true;
				this.AldysPane.DrawCurveLabels();
				this.Invalidate();
			}

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

	public ArrayList GetSymbolArraylist(int intNoOfSymbol, AldysGraph.SymbolType SymType)
	{
		ArrayList arrSymbol = new ArrayList();
		int intICounter = 0;
		try {
			for (intICounter = 0; intICounter <= intNoOfSymbol; intICounter++) {
				arrSymbol.Add(SymType);
			}

			return arrSymbol;
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

	public bool SettingsChanged()
	{
		if (UseDefaultSettings == true) {
			SetDefaultSettingsToGraph();
		} else {
			//Call SetCustomizedSettingsToGraph()
		}
	}

	#End Region

}
