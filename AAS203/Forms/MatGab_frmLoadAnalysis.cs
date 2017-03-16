using AAS203.Common;
using AAS203Library;
using AAS203Library.Method;
using AAS203Library.Analysis;

public class frmLoadAnalysis : System.Windows.Forms.Form
{

	bool blnFlag;
	#Region " Windows Form Designer generated code "

	public frmLoadAnalysis(DataTable mdtMultiReport__1 = null)
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
		mdtMultireport = mdtMultireport;

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
	internal GradientPanel.CustomPanel CustomPanelBottom;
	internal System.Windows.Forms.GroupBox gbMultiElementReport;
	internal System.Windows.Forms.ListBox lbRun;
	internal NETXP.Controls.XPButton btnCreateReport;
	internal NETXP.Controls.XPButton btnRemove;
	internal NETXP.Controls.XPButton btnAddRun;
	internal NETXP.Controls.XPButton btnCancel;
	internal System.Windows.Forms.GroupBox GroupBox2;
	internal NETXP.Controls.XPButton btnDeleteRun;
	internal NETXP.Controls.XPButton btnSelectByRunNo;
	internal NETXP.Controls.XPButton btnOk;
	internal GradientPanel.CustomPanel CustomPanelTop;
	internal GradientPanel.CustomPanel CustomPanelMethod;
	internal System.Windows.Forms.Label lblMethodComments;
	internal System.Windows.Forms.Label lblMethodInformation;
	internal System.Windows.Forms.Label lblRuns;
	internal System.Windows.Forms.Label lblMethods;
	internal System.Windows.Forms.ListBox lbMethodInformation;
	internal System.Windows.Forms.ListBox lbMethods;
	internal System.Windows.Forms.TextBox txtMethod;
	internal System.Windows.Forms.ListBox lbRunNos;
	internal System.Windows.Forms.Label lblMethod;
	internal System.Windows.Forms.Label lbMethodComments;
	internal AAS203.AASGraph PreviewGraph;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmLoadAnalysis));
		this.CustomPanelMain = new GradientPanel.CustomPanel();
		this.CustomPanelTop = new GradientPanel.CustomPanel();
		this.CustomPanelMethod = new GradientPanel.CustomPanel();
		this.lbMethodComments = new System.Windows.Forms.Label();
		this.lblMethod = new System.Windows.Forms.Label();
		this.txtMethod = new System.Windows.Forms.TextBox();
		this.lblMethodComments = new System.Windows.Forms.Label();
		this.lblMethodInformation = new System.Windows.Forms.Label();
		this.lblRuns = new System.Windows.Forms.Label();
		this.lblMethods = new System.Windows.Forms.Label();
		this.lbMethodInformation = new System.Windows.Forms.ListBox();
		this.lbRunNos = new System.Windows.Forms.ListBox();
		this.lbMethods = new System.Windows.Forms.ListBox();
		this.CustomPanelBottom = new GradientPanel.CustomPanel();
		this.PreviewGraph = new AAS203.AASGraph();
		this.gbMultiElementReport = new System.Windows.Forms.GroupBox();
		this.lbRun = new System.Windows.Forms.ListBox();
		this.btnCreateReport = new NETXP.Controls.XPButton();
		this.btnRemove = new NETXP.Controls.XPButton();
		this.btnAddRun = new NETXP.Controls.XPButton();
		this.btnCancel = new NETXP.Controls.XPButton();
		this.GroupBox2 = new System.Windows.Forms.GroupBox();
		this.btnDeleteRun = new NETXP.Controls.XPButton();
		this.btnSelectByRunNo = new NETXP.Controls.XPButton();
		this.btnOk = new NETXP.Controls.XPButton();
		this.CustomPanelMain.SuspendLayout();
		this.CustomPanelTop.SuspendLayout();
		this.CustomPanelMethod.SuspendLayout();
		this.CustomPanelBottom.SuspendLayout();
		this.gbMultiElementReport.SuspendLayout();
		this.GroupBox2.SuspendLayout();
		this.SuspendLayout();
		//
		//CustomPanelMain
		//
		this.CustomPanelMain.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanelMain.Controls.Add(this.CustomPanelTop);
		this.CustomPanelMain.Controls.Add(this.CustomPanelBottom);
		this.CustomPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanelMain.Location = new System.Drawing.Point(0, 0);
		this.CustomPanelMain.Name = "CustomPanelMain";
		this.CustomPanelMain.Size = new System.Drawing.Size(584, 399);
		this.CustomPanelMain.TabIndex = 0;
		//
		//CustomPanelTop
		//
		this.CustomPanelTop.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanelTop.Controls.Add(this.CustomPanelMethod);
		this.CustomPanelTop.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanelTop.Location = new System.Drawing.Point(0, 0);
		this.CustomPanelTop.Name = "CustomPanelTop";
		this.CustomPanelTop.Size = new System.Drawing.Size(584, 247);
		this.CustomPanelTop.TabIndex = 21;
		//
		//CustomPanelMethod
		//
		this.CustomPanelMethod.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanelMethod.Controls.Add(this.lbMethodComments);
		this.CustomPanelMethod.Controls.Add(this.lblMethod);
		this.CustomPanelMethod.Controls.Add(this.txtMethod);
		this.CustomPanelMethod.Controls.Add(this.lblMethodComments);
		this.CustomPanelMethod.Controls.Add(this.lblMethodInformation);
		this.CustomPanelMethod.Controls.Add(this.lblRuns);
		this.CustomPanelMethod.Controls.Add(this.lblMethods);
		this.CustomPanelMethod.Controls.Add(this.lbMethodInformation);
		this.CustomPanelMethod.Controls.Add(this.lbRunNos);
		this.CustomPanelMethod.Controls.Add(this.lbMethods);
		this.CustomPanelMethod.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanelMethod.Location = new System.Drawing.Point(0, 0);
		this.CustomPanelMethod.Name = "CustomPanelMethod";
		this.CustomPanelMethod.Size = new System.Drawing.Size(584, 247);
		this.CustomPanelMethod.TabIndex = 0;
		//
		//lbMethodComments
		//
		this.lbMethodComments.BackColor = System.Drawing.Color.White;
		this.lbMethodComments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.lbMethodComments.Location = new System.Drawing.Point(352, 192);
		this.lbMethodComments.Name = "lbMethodComments";
		this.lbMethodComments.Size = new System.Drawing.Size(225, 40);
		this.lbMethodComments.TabIndex = 4;
		//
		//lblMethod
		//
		this.lblMethod.Location = new System.Drawing.Point(360, 15);
		this.lblMethod.Name = "lblMethod";
		this.lblMethod.Size = new System.Drawing.Size(88, 16);
		this.lblMethod.TabIndex = 32;
		this.lblMethod.Text = "Method";
		this.lblMethod.Visible = false;
		//
		//txtMethod
		//
		this.txtMethod.BackColor = System.Drawing.Color.White;
		this.txtMethod.Location = new System.Drawing.Point(456, 13);
		this.txtMethod.Name = "txtMethod";
		this.txtMethod.ReadOnly = true;
		this.txtMethod.Size = new System.Drawing.Size(120, 20);
		this.txtMethod.TabIndex = 2;
		this.txtMethod.Text = "";
		this.txtMethod.Visible = false;
		//
		//lblMethodComments
		//
		this.lblMethodComments.Location = new System.Drawing.Point(351, 166);
		this.lblMethodComments.Name = "lblMethodComments";
		this.lblMethodComments.Size = new System.Drawing.Size(104, 16);
		this.lblMethodComments.TabIndex = 30;
		this.lblMethodComments.Text = "Method Comments";
		//
		//lblMethodInformation
		//
		this.lblMethodInformation.Location = new System.Drawing.Point(351, 38);
		this.lblMethodInformation.Name = "lblMethodInformation";
		this.lblMethodInformation.Size = new System.Drawing.Size(104, 16);
		this.lblMethodInformation.TabIndex = 29;
		this.lblMethodInformation.Text = "Method Information";
		//
		//lblRuns
		//
		this.lblRuns.Location = new System.Drawing.Point(191, 7);
		this.lblRuns.Name = "lblRuns";
		this.lblRuns.Size = new System.Drawing.Size(96, 16);
		this.lblRuns.TabIndex = 28;
		this.lblRuns.Text = "Runs";
		//
		//lblMethods
		//
		this.lblMethods.Location = new System.Drawing.Point(18, 7);
		this.lblMethods.Name = "lblMethods";
		this.lblMethods.Size = new System.Drawing.Size(72, 16);
		this.lblMethods.TabIndex = 27;
		this.lblMethods.Text = "Methods";
		//
		//lbMethodInformation
		//
		this.lbMethodInformation.Location = new System.Drawing.Point(351, 54);
		this.lbMethodInformation.Name = "lbMethodInformation";
		this.lbMethodInformation.Size = new System.Drawing.Size(225, 108);
		this.lbMethodInformation.TabIndex = 3;
		//
		//lbRunNos
		//
		this.lbRunNos.BackColor = System.Drawing.Color.White;
		this.lbRunNos.Location = new System.Drawing.Point(191, 27);
		this.lbRunNos.Name = "lbRunNos";
		this.lbRunNos.Size = new System.Drawing.Size(129, 212);
		this.lbRunNos.TabIndex = 1;
		//
		//lbMethods
		//
		this.lbMethods.BackColor = System.Drawing.Color.White;
		this.lbMethods.Location = new System.Drawing.Point(18, 27);
		this.lbMethods.Name = "lbMethods";
		this.lbMethods.Size = new System.Drawing.Size(160, 212);
		this.lbMethods.TabIndex = 0;
		//
		//CustomPanelBottom
		//
		this.CustomPanelBottom.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanelBottom.Controls.Add(this.PreviewGraph);
		this.CustomPanelBottom.Controls.Add(this.gbMultiElementReport);
		this.CustomPanelBottom.Controls.Add(this.btnCancel);
		this.CustomPanelBottom.Controls.Add(this.GroupBox2);
		this.CustomPanelBottom.Controls.Add(this.btnOk);
		this.CustomPanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.CustomPanelBottom.Location = new System.Drawing.Point(0, 247);
		this.CustomPanelBottom.Name = "CustomPanelBottom";
		this.CustomPanelBottom.Size = new System.Drawing.Size(584, 152);
		this.CustomPanelBottom.TabIndex = 0;
		//
		//PreviewGraph
		//
		this.PreviewGraph.AldysGraphCursor = System.Windows.Forms.Cursors.Hand;
		this.PreviewGraph.AldysGraphPrintColor = System.Drawing.Color.Black;
		this.PreviewGraph.BackColor = System.Drawing.Color.LightGray;
		this.PreviewGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.PreviewGraph.GraphDataSource = null;
		this.PreviewGraph.GraphImage = null;
		this.PreviewGraph.IsShowGrid = true;
		this.PreviewGraph.Location = new System.Drawing.Point(16, 8);
		this.PreviewGraph.Name = "PreviewGraph";
		this.PreviewGraph.Size = new System.Drawing.Size(224, 136);
		this.PreviewGraph.TabIndex = 24;
		this.PreviewGraph.UseDefaultSettings = false;
		this.PreviewGraph.XAxisDateMax = new System.DateTime(2007, 3, 16, 23, 59, 59, 0);
		this.PreviewGraph.XAxisDateMin = new System.DateTime(2007, 3, 16, 0, 0, 0, 0);
		this.PreviewGraph.XAxisDateScaleFormat = AAS203.AASGraph.enumDateScaleFormat.HHMM;
		this.PreviewGraph.XAxisLabel = "TIME(seconds)";
		this.PreviewGraph.XAxisMax = 100;
		this.PreviewGraph.XAxisMin = 0;
		this.PreviewGraph.XAxisMinorStep = 2;
		this.PreviewGraph.XAxisScaleFormat = "";
		this.PreviewGraph.XAxisStep = 10;
		this.PreviewGraph.XAxisType = AldysGraph.AxisType.Linear;
		this.PreviewGraph.YAxisLabel = "ABSORBANCE";
		this.PreviewGraph.YAxisMax = 1.1;
		this.PreviewGraph.YAxisMin = -0.2;
		this.PreviewGraph.YAxisMinorStep = 0.05;
		this.PreviewGraph.YAxisScaleFormat = null;
		this.PreviewGraph.YAxisStep = 0.1;
		this.PreviewGraph.YAxisType = AldysGraph.AxisType.Linear;
		//
		//gbMultiElementReport
		//
		this.gbMultiElementReport.BackColor = System.Drawing.Color.Transparent;
		this.gbMultiElementReport.Controls.Add(this.lbRun);
		this.gbMultiElementReport.Controls.Add(this.btnCreateReport);
		this.gbMultiElementReport.Controls.Add(this.btnRemove);
		this.gbMultiElementReport.Controls.Add(this.btnAddRun);
		this.gbMultiElementReport.Location = new System.Drawing.Point(374, 3);
		this.gbMultiElementReport.Name = "gbMultiElementReport";
		this.gbMultiElementReport.Size = new System.Drawing.Size(192, 101);
		this.gbMultiElementReport.TabIndex = 1;
		this.gbMultiElementReport.TabStop = false;
		this.gbMultiElementReport.Text = "Multi - Element Report";
		//
		//lbRun
		//
		this.lbRun.BackColor = System.Drawing.Color.White;
		this.lbRun.Location = new System.Drawing.Point(8, 14);
		this.lbRun.Name = "lbRun";
		this.lbRun.Size = new System.Drawing.Size(176, 56);
		this.lbRun.TabIndex = 0;
		//
		//btnCreateReport
		//
		this.btnCreateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCreateReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCreateReport.Location = new System.Drawing.Point(128, 72);
		this.btnCreateReport.Name = "btnCreateReport";
		this.btnCreateReport.Size = new System.Drawing.Size(54, 24);
		this.btnCreateReport.TabIndex = 3;
		this.btnCreateReport.Text = "Create ";
		//
		//btnRemove
		//
		this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnRemove.Location = new System.Drawing.Point(68, 72);
		this.btnRemove.Name = "btnRemove";
		this.btnRemove.Size = new System.Drawing.Size(54, 24);
		this.btnRemove.TabIndex = 2;
		this.btnRemove.Text = "Remove";
		//
		//btnAddRun
		//
		this.btnAddRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnAddRun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnAddRun.Location = new System.Drawing.Point(8, 72);
		this.btnAddRun.Name = "btnAddRun";
		this.btnAddRun.Size = new System.Drawing.Size(54, 24);
		this.btnAddRun.TabIndex = 1;
		this.btnAddRun.Text = "Add Run";
		//
		//btnCancel
		//
		this.btnCancel.BackColor = System.Drawing.Color.Transparent;
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCancel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnCancel.Image = (System.Drawing.Image)resources.GetObject("btnCancel.Image");
		this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCancel.Location = new System.Drawing.Point(478, 108);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(86, 34);
		this.btnCancel.TabIndex = 3;
		this.btnCancel.Text = "&Cancel";
		//
		//GroupBox2
		//
		this.GroupBox2.Controls.Add(this.btnDeleteRun);
		this.GroupBox2.Controls.Add(this.btnSelectByRunNo);
		this.GroupBox2.Location = new System.Drawing.Point(246, 3);
		this.GroupBox2.Name = "GroupBox2";
		this.GroupBox2.Size = new System.Drawing.Size(126, 141);
		this.GroupBox2.TabIndex = 0;
		this.GroupBox2.TabStop = false;
		//
		//btnDeleteRun
		//
		this.btnDeleteRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnDeleteRun.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnDeleteRun.Image = (System.Drawing.Image)resources.GetObject("btnDeleteRun.Image");
		this.btnDeleteRun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnDeleteRun.Location = new System.Drawing.Point(8, 77);
		this.btnDeleteRun.Name = "btnDeleteRun";
		this.btnDeleteRun.Size = new System.Drawing.Size(108, 38);
		this.btnDeleteRun.TabIndex = 1;
		this.btnDeleteRun.Text = "&Delete Run";
		this.btnDeleteRun.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//btnSelectByRunNo
		//
		this.btnSelectByRunNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnSelectByRunNo.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnSelectByRunNo.Image = (System.Drawing.Image)resources.GetObject("btnSelectByRunNo.Image");
		this.btnSelectByRunNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnSelectByRunNo.Location = new System.Drawing.Point(8, 31);
		this.btnSelectByRunNo.Name = "btnSelectByRunNo";
		this.btnSelectByRunNo.Size = new System.Drawing.Size(108, 38);
		this.btnSelectByRunNo.TabIndex = 0;
		this.btnSelectByRunNo.Text = "&Select By Run no.";
		this.btnSelectByRunNo.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnOk
		//
		this.btnOk.BackColor = System.Drawing.Color.Transparent;
		this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOk.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnOk.Image = (System.Drawing.Image)resources.GetObject("btnOk.Image");
		this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOk.Location = new System.Drawing.Point(374, 108);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(86, 34);
		this.btnOk.TabIndex = 2;
		this.btnOk.Text = "&OK";
		//
		//frmLoadAnalysis
		//
		this.AcceptButton = this.btnOk;
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.CancelButton = this.btnCancel;
		this.ClientSize = new System.Drawing.Size(584, 399);
		this.Controls.Add(this.CustomPanelMain);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmLoadAnalysis";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Load Analysis";
		this.CustomPanelMain.ResumeLayout(false);
		this.CustomPanelTop.ResumeLayout(false);
		this.CustomPanelMethod.ResumeLayout(false);
		this.CustomPanelBottom.ResumeLayout(false);
		this.gbMultiElementReport.ResumeLayout(false);
		this.GroupBox2.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Private Constants"

	private const  ConstAnalysedOn = "Analysed On ";
	private const  ConstElementName = "Element Name  ";
	private const  ConstOperationMode = "Mode         ";
	private const  ConstCreatedBy = "Created By  ";
	private const  ConstCreatedOn = "Created On  ";
	private const  ConstStatus = "Status      ";
	private const  ConstChangedOn = "Changed On  ";
	private const  ConstLastUsedOn = "Last Used On";
	private const  ConstActive = "Active";
	private const  ConstNotActive = "Inactive";
	private const  ConstColumnMethodID = "MethodID";
	private const  ConstColumnRunNumberToSort = "RunNumber";
	private const  ConstColumnMethodName = "MethodName";
	private const  ConstColumnRunNo = "RunNo";
	private const  ConstFormLoad = "-DataFiles-LoadAnalysis";

	private const  ConstParentFormLoad = "-DataFiles";
	#End Region

	#Region " Private Member Variables "

	//Private mblnShowByRunNo As Boolean


	private bool mblnShowByRunNo;
	private int mintSelectedMethodID;

	private int mintSelectedRunNo;
	private AldysGraph.CurveItem mobjPreviewCurve;
	private int intElementID;
	//Private mobjDtRunNos As New DataTable

	private clsDataFileReport mobjClsDataFileReport = new clsDataFileReport();
	public event  LoadRunNo;
	private int[,] arrRunNoList = new int[99, -1];
	private DataTable dtMultiReport;
	DataColumn Col01 = new DataColumn("ContaintId", typeof(long));
	DataColumn Col02 = new DataColumn("SelectMethodID", typeof(string));
	DataColumn Col03 = new DataColumn("SelectRunID", typeof(string));
	DataColumn Col04 = new DataColumn("RunDesc", typeof(string));
	DataColumn Col05 = new DataColumn("MethodIndexID", typeof(string));

	DataColumn Col06 = new DataColumn("RunIndexID", typeof(string));
	public event  StoreMultiReportDataTable;
	//Saurabh 22.07.07

	#End Region

	#Region " Private Properties "

	//Private Property IsShowByRunNo() As Boolean
	//    Get
	//        Return mblnShowByRunNo
	//    End Get
	//    Set(ByVal Value As Boolean)
	//        mblnShowByRunNo = Value
	//        Try
	//            If mblnShowByRunNo = True Then
	//                Dim objDtRunNos As New DataTable
	//                Dim intCounter As Integer
	//                Dim objRow As DataRow

	//                lbRunNos.Visible = True
	//                lbMethods.Visible = False
	//                lbRunNos.Width = (2 * lbMethods.Width) + 5
	//                lblMethod.Visible = True
	//                txtMethod.Visible = True

	//                objDtRunNos.Columns.Add(ConstColumnRunNo)
	//                'objDtRunNos.Columns.Add(ConstColumnMethodName)

	//                For intCounter = 0 To gobjNewMethod.QuantitativeDataCollection.Count - 1
	//                    objRow = objDtRunNos.NewRow
	//                    objRow.Item(ConstColumnRunNo) = gobjNewMethod.QuantitativeDataCollection.Item(intCounter).RunNumber
	//                    'objRow.Item(ConstColumnMethodName) = gobjMethodCollection.item(intCounter).MethodName
	//                    objDtRunNos.Rows.Add(objRow)
	//                Next
	//                lbRunNos.DataSource = objDtRunNos
	//                lbRunNos.DisplayMember = ConstColumnMethodName
	//                lbRunNos.ValueMember = ConstColumnMethodID
	//                mintSelectedMethodID = CInt(lbRunNos.SelectedValue)
	//            Else
	//                lbRunNos.Visible = True
	//                lbMethods.Visible = True
	//                lbRunNos.Width = lbMethods.Width
	//                lbMethods.Visible = False
	//                txtMethod.Visible = False
	//                mintSelectedMethodID = CInt(lbMethods.SelectedValue)
	//            End If

	//        Catch ex As Exception
	//            '---------------------------------------------------------
	//            'Error Handling and logging
	//            gobjErrorHandler.ErrorDescription = ex.Message
	//            gobjErrorHandler.ErrorMessage = ex.Message
	//            gobjErrorHandler.WriteErrorLog(ex)
	//            '---------------------------------------------------------
	//        Finally
	//            '---------------------------------------------------------
	//            'Writing Execution log
	//            If CONST_CREATE_EXECUTION_LOG = 1 Then
	//                gobjErrorHandler.WriteExecutionLog()
	//            End If
	//            '---------------------------------------------------------
	//        End Try
	//    End Set
	//End Property

	private int SelectedRunNo {
		get { return mintSelectedRunNo; }
		set {
			mintSelectedRunNo = Value;

			int intCount;
			DataTable objDtRunNo = new DataTable();
			int intRunNumberCounter;
			string strRunNumber;

			try {
				for (intCount = 0; intCount <= gobjMethodCollection.Count - 1; intCount++) {
					if (mintSelectedMethodID == gobjMethodCollection.item(intCount).MethodID) {
						//If gobjMethodCollection.item(intCount).QuantitativeDataCollection.Count > 0 Then
						for (intRunNumberCounter = 0; intRunNumberCounter <= gobjMethodCollection.item(intCount).QuantitativeDataCollection.Count - 1; intRunNumberCounter++) {
							if ((int)gobjMethodCollection.item(intCount).QuantitativeDataCollection.Item(intRunNumberCounter).RunNumber == mintSelectedRunNo) {
								intElementID = gobjMethodCollection.item(intCount).InstrumentCondition.ElementID;
								strRunNumber = gobjMethodCollection.item(intCount).QuantitativeDataCollection.Item(intRunNumberCounter).RunNumber;
								funcShowMethodGeneralInfo(gobjMethodCollection.item(intCount), strRunNumber);
								break; // TODO: might not be correct. Was : Exit For
							}
						}
						//Else
						//PreviewGraph.Visible = False
						//End If
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
	}

	public int SelectedMethodID {
		get { return mintSelectedMethodID; }
	}

	public int SelectedRunNumber {
		get { return mintSelectedRunNo; }
	}

	#End Region

	#Region " Form Events"

	private void  // ERROR: Handles clauses are not supported in C#
frmLoadAnalysis_Load(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmLoadAnalysis_Load
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To initialize the form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 28.01.2007
		// Revisions             : 
		//=====================================================================
		try {
			gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType + ConstFormLoad);

			Application.DoEvents();
			//  Add handlers of form object
			Addhandlers();
			// Init the form objects and process
			funcInitialise();
			btnSelectByRunNo_Click(sender, e);
			//Call lbMethods_SelectedIndexChanged(lbMethods, EventArgs.Empty)
			lbMethods.Focus();
		//lbRun_SelectedIndexChanged(Me, EventArgs.Empty)
		//SelectedRunNo = lbRunNos.SelectedValue

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
			gobjMain.HideProgressBar();
			//---------------------------------------------------------
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
frmLoadAnalysis_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmLoadAnalysis_Closing
		// Parameters Passed     : Object, CancelEventArgs
		// Returns               : None
		// Purpose               : To set MultiReport data table as nothing.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 28.01.2007
		// Revisions             : 
		//=====================================================================
		try {
			//show the progress bar
			gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType + ConstParentFormLoad);
			// Erase data table 
			if (!(dtMultiReport == null)) {
				dtMultiReport = null;
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
			//objWait.Dispose()
			//---------------------------------------------------------
		}
	}

	#End Region

	#Region " Private Functions "

	private void Addhandlers()
	{
		//=====================================================================
		// Procedure Name        : Addhandlers
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To add event handlers
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 28.01.2007
		// Revisions             : 
		//=====================================================================
		btnSelectByRunNo.Click += btnSelectByRunNo_Click;
		//AddHandler lbRunNos.SelectedIndexChanged, AddressOf lbRunNos_SelectedIndexChanged
		//AddHandler lbMethods.SelectedIndexChanged, AddressOf lbMethods_SelectedIndexChanged
		btnOk.Click += btnOk_Click;

	}

	private void btnSelectByRunNo_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnSelectByRunNo_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : To Show the SelectByRunNo. option.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 28.01.2007
		// Revisions             : 
		//=====================================================================
		try {
			// Set the setting of selection of Run No by "Load Analysis Run Report by Method"
			if (blnFlag == false) {
				this.Text = "Load Analysis Run Report by Method";
				lbMethods.Visible = true;
				lbMethods.Location = new Point(18, 27);
				lbRunNos.Width = 129;
				lbRunNos.Location = new Point(191, 27);
				lblMethod.Visible = false;
				txtMethod.Visible = false;
				CustomPanelMethod.Dock = DockStyle.Fill;
				CustomPanelMethod.Visible = true;
				btnSelectByRunNo.Text = "Select By Run No.";
				lblMethods.Visible = true;
				lblRuns.Location = new Point(191, 7);
				blnFlag = true;
				lbMethods_SelectedIndexChanged(sender, e);
				mblnShowByRunNo = false;
			} else {
				// Set the setting of selection of Run No by "Load Analysis Run Report by Run Nos."
				this.Text = "Load Analysis Run Report by Run Nos.";
				lbRunNos.Width = (2 * lbMethods.Width);
				lbMethods.Visible = false;
				lbRunNos.Location = new Point(18, 27);
				lblMethod.Visible = true;
				txtMethod.Visible = true;
				lblMethods.Visible = false;
				lblRuns.Location = new Point(18, 7);
				btnSelectByRunNo.Text = "Select By Method";
				blnFlag = false;
				lbRunNos.Refresh();
				SelectByRunNo();
				mblnShowByRunNo = true;
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
			//objWait.Dispose()
			//---------------------------------------------------------
		}
	}

	private bool funcInitialise()
	{
		//=====================================================================
		// Procedure Name        : funcInitialise
		// Parameters Passed     : None
		// Returns               : True or False
		// Purpose               : To initialise the Load Analysis form.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 28.01.2007
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();

		DataTable objDtMethods = new DataTable();
		int intCounter;
		DataRow objRow;

		try {
			funcInitialise = false;
			blnFlag = true;

			btnRemove.Enabled = false;
			btnCreateReport.Enabled = false;

			this.Text = "Load Analysis Run Report by Method";
			CustomPanelMethod.Dock = DockStyle.Fill;

			lbMethods.SelectedIndexChanged -= lbMethods_SelectedIndexChanged;
			// loads all methods from file system
			if (funcLoadMethods() == true) {
				// Load method data object into Data Table
				if (gobjMethodCollection.Count > 0) {
					objDtMethods.Columns.Add(ConstColumnMethodID);
					objDtMethods.Columns.Add(ConstColumnMethodName);
					mintSelectedMethodID = 0;

					for (intCounter = gobjMethodCollection.Count - 1; intCounter >= 0; intCounter += -1) {
						objRow = objDtMethods.NewRow;
						objRow.Item(ConstColumnMethodID) = gobjMethodCollection.item(intCounter).MethodID;
						objRow.Item(ConstColumnMethodName) = gobjMethodCollection.item(intCounter).MethodName;
						objDtMethods.Rows.Add(objRow);
					}
					lbMethods.DataSource = objDtMethods;
					lbMethods.DisplayMember = ConstColumnMethodName;
					lbMethods.ValueMember = ConstColumnMethodID;
					lbMethods.Refresh();
				}
			}
			int intCount;
			// Init array for Run No list.
			for (intCount = 0; intCount <= arrRunNoList.GetUpperBound(0); intCount++) {
				arrRunNoList(intCount, 0) = -1;
			}

			lbMethods.SelectedIndexChanged += lbMethods_SelectedIndexChanged;
			lbMethods_SelectedIndexChanged(this, new EventArgs());

			funcInitialise = true;
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
			//objWait.Dispose()
			//---------------------------------------------------------
		}
	}

	private bool funcLoadRunNos()
	{
		//=====================================================================
		// Procedure Name        : funcLoadRunNos
		// Parameters Passed     : None
		// Returns               : True or false
		// Purpose               : To Load all the RunNos. of selected Method.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 28.01.2007
		// Revisions             : 
		//=====================================================================
		int intMethodCounter;
		int intRunCounter;
		DataTable objDtRunNo = new DataTable();
		DataRow objDrNewRow;

		try {
			// Load Run No and Method no into Data table
			mintSelectedRunNo = -1;
			objDtRunNo.Columns.Add(ConstColumnRunNo);
			objDtRunNo.Columns.Add(ConstColumnMethodID);
			// use loop to store run No and method no
			for (intMethodCounter = 0; intMethodCounter <= gobjMethodCollection.Count - 1; intMethodCounter++) {
				for (intRunCounter = 0; intRunCounter <= gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Count - 1; intRunCounter++) {
					if (!Val(gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Item(intRunCounter).RunNumber) == -1.0) {
						objDrNewRow = objDtRunNo.NewRow;
						objDrNewRow.Item(ConstColumnRunNo) = gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Item(intRunCounter).RunNumber;
						objDrNewRow.Item(ConstColumnMethodID) = gobjMethodCollection.item(intMethodCounter).MethodID;
						objDtRunNo.Rows.Add(objDrNewRow);
					}
				}
			}

			lbRunNos.DataSource = objDtRunNo;
			lbRunNos.DisplayMember = ConstColumnRunNo;
			lbRunNos.ValueMember = ConstColumnRunNo;
			lbRunNos.Refresh();

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
			//objWait.Dispose()
			//---------------------------------------------------------
		}
	}

	private bool funcShowMethodGeneralInfo(clsMethod objMethod, string strRunNumber)
	{
		//=====================================================================
		// Procedure Name        : funcShowMethodGeneralInfo
		// Parameters Passed     : clsMethod object, Run Number
		// Returns               : True or False
		// Purpose               : To show method information 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		DataRow objRow;
		string strStatus = "";


		try {
			lbMethodComments.Text = objMethod.Comments;
			// get Method info. into data table
			objRow = gobjClsAAS203.funcGetMethodType(objMethod.OperationMode);

			// Set form object of method info. from data table 
			if (!objRow == null) {
				if (objMethod.OperationMode == 2 | objMethod.OperationMode == 4) {
					txtMethod.Text = "";
				}
			}

			if (objMethod.Status == true) {
				strStatus = ConstActive;
			} else {
				strStatus = ConstNotActive;
			}
			string strDateOfModification;
			string strDateOfLastUse;

			if (!objMethod.DateOfModification == System.DateTime.FromOADate(0.0)) {
				strDateOfModification = Format(objMethod.DateOfModification, "dd-MMM-yyyy hh:mm tt");
			}
			if (!objMethod.DateOfLastUse == System.DateTime.FromOADate(0.0)) {
				strDateOfLastUse = Format(objMethod.DateOfLastUse, "dd-MMM-yyyy hh:mm tt");
			}

			txtMethod.Text = (string)objMethod.MethodName;

			////----- Added by Sachin Dokhale
			string strOperationMode;
			string strElementName;
			DataTable objDtElements;
			// Get Element details from cookbook
			objDtElements = gobjDataAccess.GetCookBookData(objMethod.InstrumentCondition.ElementID);
			if (!objDtElements == null) {
				if (objDtElements.Rows.Count > 0) {
					strElementName = objDtElements.Rows(0).Item(ConstColumnElementName);
				}
				objDtElements = null;
			}
			// Set operation mode
			switch (objMethod.OperationMode) {
				case EnumOperationMode.MODE_AA:
					strOperationMode = "AA Quantitative Mode";
				case EnumOperationMode.MODE_AABGC:
					strOperationMode = "AABGC Quantitative Mode";
				case EnumOperationMode.MODE_EMMISSION:
					strOperationMode = "Emission Quantitative Mode";
				case EnumOperationMode.MODE_UVABS:
					strOperationMode = "UV Quantitative Mode";
				default:
					strOperationMode = "AA Quantitative Mode";
			}
			////-----

			// Set general Method info to the form object
			lbMethodInformation.Items.Clear();
			////----- Added by Sachin Dokhale


			//lbMethodInformation.Items.Add(ConstAnalysedOn & vbTab & CStr(Format(objMethod.DateOfLastUse, "dd-MMM-yyyy hh:mm tt"))) 'code commented by : dinesh wagh on 10.2.2010

			//-------------------------------------------------
			//by dinesh wagh on 10.2.2010
			//--------------------------------------------------
			int intRunIndex;
			for (intRunIndex = 0; intRunIndex <= objMethod.QuantitativeDataCollection.Count - 1; intRunIndex++) {
				if (objMethod.QuantitativeDataCollection(intRunIndex).RunNumber == strRunNumber) {
					break; // TODO: might not be correct. Was : Exit For
				}
			}
			lbMethodInformation.Items.Add(ConstAnalysedOn + vbTab + (string)Format(objMethod.QuantitativeDataCollection(intRunIndex).AnalysisParameters.Analysis_Date, "dd-MMM-yyyy hh:mm tt"));
			//----------------------------------------------



			lbMethodInformation.Items.Add(ConstElementName + vbTab + strElementName);
			lbMethodInformation.Items.Add(ConstOperationMode + vbTab + strOperationMode);
			////-----
			lbMethodInformation.Items.Add(ConstCreatedBy + vbTab + objMethod.UserName);
			lbMethodInformation.Items.Add(ConstCreatedOn + vbTab + Format(objMethod.DateOfCreation, "dd-MMM-yyyy hh:mm tt"));


			lbMethodInformation.Items.Add(ConstStatus + vbTab + strStatus);
			lbMethodInformation.Items.Add(ConstChangedOn + vbTab + strDateOfModification);
			lbMethodInformation.Items.Add(ConstLastUsedOn + vbTab + strDateOfLastUse);
			// Set graph porperty depending upon opration mode
			switch (objMethod.OperationMode) {
				case EnumOperationMode.MODE_UVABS:

					PreviewGraph.Visible = false;
				//Saurabh 28 MAy 2007---------------------------------------
				case EnumOperationMode.MODE_EMMISSION:
					PreviewGraph.Visible = true;
					PreviewGraph.YAxisLabel = "EMISSION";
					PreviewGraph.YAxisMin = 0;
					PreviewGraph.YAxisMax = 100;
					PreviewGraph.YAxisMinorStep = 2;
					PreviewGraph.YAxisStep = 10;
					gobjClsAAS203.subShowGraphPreview(this.PreviewGraph, mobjPreviewCurve, strRunNumber, objMethod);
					PreviewGraph.IsShowGrid = true;
					PreviewGraph.Invalidate();
					PreviewGraph.Refresh();
					this.Refresh();
					PreviewGraph.Refresh();
					Application.DoEvents();
				//Saurabh 28 MAy 2007---------------------------------------

				//Saurabh 30 MAy 2007---------------------------------------
				case EnumOperationMode.MODE_AA:
					PreviewGraph.Visible = true;
					PreviewGraph.YAxisLabel = "ABSORBANCE";
					PreviewGraph.YAxisMin = -0.2;
					PreviewGraph.YAxisMax = 1.1;
					PreviewGraph.YAxisMinorStep = 0.05;
					PreviewGraph.YAxisStep = 0.1;
					gobjClsAAS203.subShowGraphPreview(this.PreviewGraph, mobjPreviewCurve, strRunNumber, objMethod);
					PreviewGraph.IsShowGrid = true;
					PreviewGraph.Invalidate();
					this.Refresh();
					Application.DoEvents();
				//Saurabh 30 MAy 2007---------------------------------------

				default:
					PreviewGraph.Visible = true;
					// Show graph preview
					gobjClsAAS203.subShowGraphPreview(this.PreviewGraph, mobjPreviewCurve, strRunNumber, objMethod);
					PreviewGraph.IsShowGrid = true;
					this.PreviewGraph.Refresh();

					Application.DoEvents();
			}

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

	private bool SelectByRunNo()
	{
		//=====================================================================
		// Procedure Name        : SelectByRunNo
		// Parameters Passed     : None
		// Returns               : True or False
		// Purpose               : To Show the SelectByRunNo. option.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 28.01.2007
		// Revisions             : 
		//=====================================================================
		DataTable objDtRunNos;
		int intCounter;
		DataRow objRow;
		int intMethodCounter;
		string[] RunNo = new string[98];

		try {
			// Set the Run no list box by selecting Run no
			lbRunNos.SelectedIndexChanged -= lbRunNos_SelectedIndexChanged;
			// Set Data table for Run no
			if (IsNothing(objDtRunNos)) {
				objDtRunNos = new DataTable();

				objDtRunNos.Columns.Add(ConstColumnRunNo, System.Type.GetType("System.String"));
				objDtRunNos.Columns.Add(ConstColumnMethodID, System.Type.GetType("System.Int32"));
				objDtRunNos.Columns.Add(ConstColumnRunNumberToSort, System.Type.GetType("System.Int32"));
			}

			for (intMethodCounter = 0; intMethodCounter <= gobjMethodCollection.Count - 1; intMethodCounter++) {
				for (intCounter = 0; intCounter <= gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Count - 1; intCounter++) {
					if (!Val(gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Item(intCounter).RunNumber) == -1.0) {
						objRow = objDtRunNos.NewRow;
						objRow.Item(ConstColumnRunNo) = gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Item(intCounter).RunNumber;
						objRow.Item(ConstColumnMethodID) = gobjMethodCollection.item(intMethodCounter).MethodID;
						objRow.Item(ConstColumnRunNumberToSort) = Convert.ToInt32(gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Item(intCounter).RunNumber);
						objDtRunNos.Rows.Add(objRow);
						//RunNo(intMethodCounter) = gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Item(intCounter).RunNumber
					}
				}
			}
			// arrange the data table in Desc. order
			objDtRunNos.DefaultView.Sort = ConstColumnRunNumberToSort + " Desc";

			// Set the Run no list box property for data table
			if (!IsNothing(objDtRunNos)) {
				lbRunNos.DataSource = null;
				lbRunNos.DataSource = objDtRunNos.DefaultView;
				lbRunNos.DisplayMember = ConstColumnRunNo;
				lbRunNos.ValueMember = ConstColumnRunNo;
				lbRunNos.SelectedIndex = 0;
				lbRunNos.Refresh();
			} else {
				lbRunNos.DataSource = null;
				lbRunNos.SelectedIndex = -1;
			}

			lbRunNos.SelectedIndexChanged += lbRunNos_SelectedIndexChanged;
			lbRunNos_SelectedIndexChanged(this, new System.EventArgs());
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
			//objWait.Dispose()
			//---------------------------------------------------------
		}
	}

	private void lbRunNos_SelectedIndexChanged(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : lbRunNos_SelectedIndexChanged
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : To Load the Run nos. details.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 27.01.2007
		// Revisions             : Deepak on 04.08.07
		//=====================================================================
		int intCount;
		DataView dv = new DataView();
		try {
			// Select Method Id from Run no list box
			// Select Run No from Run no list box
			if (!lbRunNos.Items.Count == 0) {
				btnOk.Enabled = true;
				btnDeleteRun.Enabled = true;
				btnAddRun.Enabled = true;

				if (mblnShowByRunNo == true) {
					if (!lbRunNos.DataSource == null) {
						if (lbRunNos.DataSource is DataView) {
							dv = (DataView)lbRunNos.DataSource;
							for (intCount = 0; intCount <= dv.Count - 1; intCount++) {
								if (dv.Item(intCount).Row.Item(ConstColumnRunNo) == (int)lbRunNos.SelectedValue) {
									mintSelectedMethodID = dv.Item(intCount).Row.Item(ConstColumnMethodID);
								}
							}
						}
					}
				} else {
					mintSelectedMethodID = (int)lbMethods.SelectedValue;
				}
				SelectedRunNo = (int)lbRunNos.SelectedValue;
				lbRunNos.Refresh();
				PreviewGraph.Refresh();
			} else {
				btnOk.Enabled = false;
				btnDeleteRun.Enabled = false;
				btnAddRun.Enabled = false;
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
			//objWait.Dispose()
			//---------------------------------------------------------
		}
	}

	private void lbMethods_SelectedIndexChanged(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : lbMethods_SelectedIndexChanged
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : To load selected method
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 27.01.2007
		// Revisions             : 
		//=====================================================================
		try {
			lbMethodComments.Text = "";
			lbMethodInformation.Items.Clear();
			// Select Method ID and to select Method info.
			mintSelectedMethodID = (int)lbMethods.SelectedValue;

			funcLoadSelectedMethod(mintSelectedMethodID);

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
			//objWait.Dispose()
			//---------------------------------------------------------
		}
	}

	private bool funcLoadSelectedMethod(int intMethodID)
	{
		//=====================================================================
		// Procedure Name        : funcLoadSelectedMethod
		// Parameters Passed     : Selected method ID
		// Returns               : True if success
		// Purpose               : To load the selected method.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 28.01.2007
		// Revisions             : 
		//=====================================================================
		DataTable objDtRunNos;
		int intCounter;
		DataRow objRow;
		int intMethodCounter;

		try {
			lbRunNos.SelectedIndexChanged -= lbRunNos_SelectedIndexChanged;
			// Select method details from Method collection into data table
			for (intMethodCounter = gobjMethodCollection.Count - 1; intMethodCounter >= 0; intMethodCounter += -1) {
				if (gobjMethodCollection.item(intMethodCounter).MethodID == intMethodID) {
					if (gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Count > 0) {
						for (intCounter = gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Count - 1; intCounter >= 0; intCounter += -1) {
							if (!Val(gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Item(intCounter).RunNumber) == -1.0) {
								if (IsNothing(objDtRunNos)) {
									objDtRunNos = new DataTable();
									objDtRunNos.Columns.Add(ConstColumnRunNo);
									objDtRunNos.Columns.Add(ConstColumnMethodID);
								}
								// Add method details into data table
								objRow = objDtRunNos.NewRow;
								objRow.Item(ConstColumnRunNo) = gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Item(intCounter).RunNumber;
								objRow.Item(ConstColumnMethodID) = gobjMethodCollection.item(intMethodCounter).MethodID;
								objDtRunNos.Rows.Add(objRow);
							}
						}
						break; // TODO: might not be correct. Was : Exit For
					} else {
						PreviewGraph.Visible = false;
					}
				}
			}

			if (!IsNothing(objDtRunNos)) {
				lbRunNos.DataSource = null;
				lbRunNos.DataSource = objDtRunNos;
				lbRunNos.DisplayMember = ConstColumnRunNo;
				lbRunNos.ValueMember = ConstColumnRunNo;
				lbRunNos.SelectedIndex = 0;
			} else {
				lbRunNos.DataSource = null;
				lbRunNos.SelectedIndex = -1;
			}

			lbRunNos.SelectedIndexChanged += lbRunNos_SelectedIndexChanged;

			lbRunNos_SelectedIndexChanged(lbRunNos, EventArgs.Empty);

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

	private void btnOk_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnOk_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : None
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 28.01.2007
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		int intCounter;
		int intCount;
		string strRunNo;

		try {
			// Create multi report 
			if (!dtMultiReport == null) {
				if (StoreMultiReportDataTable != null) {
					StoreMultiReportDataTable(dtMultiReport);
				}
			}

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
			//objWait.Dispose()
			//---------------------------------------------------------
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
btnAddRun_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnAddRun_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : To add run nos. for multi report.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 28.01.2007
		// Revisions             : 
		//=====================================================================
		string strElementName;
		DataTable objDtElements = new DataTable();
		static int intMethod = 0;
		static int intRunNo;
		int intCount;
		bool blnFoundMethod = false;
		bool blnFoundRunNo = false;
		static int intSndDime;
		bool blnAddRunNo;
		int intCount1;
		int intSelectId;
		DataRow DtRow;
		bool blnIsRunFound;
		int intRowIndex;
		// Add Run No against Method No into 2 diamentional array
		// This function logic is use to store unic Run no against Method ID in 2 dimetional array
		// as a 1st col. holds the method ID and against it from 2 cols. it holds Run No. 
		// each Run No is unic for that method ID. Logic is written in that way.
		try {
			// Add Run No into list box to create multi report
			objDtElements = gobjDataAccess.GetCookBookData(intElementID);
			if (!objDtElements == null) {
				if (objDtElements.Rows.Count > 0) {
					strElementName = objDtElements.Rows(0).Item(ConstColumnElementName);
				}
			}
			// Init Multi report columns
			if ((dtMultiReport == null)) {
				dtMultiReport = new DataTable();

				dtMultiReport.Columns.Add(Col01);
				dtMultiReport.Columns.Add(Col02);
				dtMultiReport.Columns.Add(Col03);
				dtMultiReport.Columns.Add(Col04);
				dtMultiReport.Columns.Add(Col05);
				dtMultiReport.Columns.Add(Col06);

			}

			if (!(dtMultiReport == null)) {
				//Saurabh 12.07.07 TO set Max Run Nos. for Multielement Report
				if (dtMultiReport.Rows.Count > 9) {
					gobjMessageAdapter.ShowMessage("You can select maximum 10 Run numbers only", "Run Number", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage);
					return;
				}
				//Saurabh 12.07.07 TO set Max Run Nos. for Multielement Report

				if (dtMultiReport.Rows.Count > 0) {
					for (intRowIndex = 0; intRowIndex <= dtMultiReport.Rows.Count - 1; intRowIndex++) {
						if (mintSelectedMethodID == (int)dtMultiReport.Rows(intRowIndex).Item(1)) {
							if (mintSelectedRunNo == (int)dtMultiReport.Rows(intRowIndex).Item(2)) {
								blnIsRunFound = true;
								break; // TODO: might not be correct. Was : Exit For
							}
						}
					}
				}
			}

			//If lbRun.Items.Contains(lbRunNos.SelectedValue & "      " & strElementName) Then
			if (blnIsRunFound == true) {
				return;
			} else {
				// Init List box object
				lbRun.DataSource = dtMultiReport;
				lbRun.DisplayMember = "RunDesc";
				lbRun.ValueMember = "ContaintId";
				lbRun.Refresh();
				// Add Method no and selected Run No into multi array 
				if (!arrRunNoList == null) {
					if (arrRunNoList.GetUpperBound(0) > 0) {
						while (intCount <= arrRunNoList.GetUpperBound(0)) {
							if (arrRunNoList(intCount, 0) == mintSelectedMethodID) {
								blnFoundMethod = true;
								intMethod = intCount + 1;
								break; // TODO: might not be correct. Was : Exit Do
							}
							intCount += 1;
						}

						if (blnFoundMethod == false) {
							intMethod += 1;
							intRunNo = 0;
						}

						while (intCount <= arrRunNoList.GetUpperBound(1)) {
							if (arrRunNoList(intMethod, intCount) == mintSelectedRunNo) {
								blnFoundRunNo = true;
								intRunNo = intCount + 1;
								break; // TODO: might not be correct. Was : Exit Do
							}
							intCount += 1;
						}

						if (blnFoundRunNo == false) {
							intRunNo += 1;
						}
					}

					if (intSndDime < intRunNo) {
						intSndDime = intRunNo;
						Array.Resize(ref arrRunNoList, 101, intSndDime + 1);
					}

					for (intCount = 0; intCount <= gobjMethodCollection.Count - 1; intCount++) {
						if (mintSelectedMethodID == gobjMethodCollection(intCount).MethodID) {
							intSelectId = intCount;
							mobjClsDataFileReport.MethodID = intCount;
							arrRunNoList(intMethod - 1, 0) = intSelectId + 1;
							// - 1
							break; // TODO: might not be correct. Was : Exit For
						}
					}

					for (intCount = 0; intCount <= gobjMethodCollection(intSelectId).QuantitativeDataCollection.Count - 1; intCount++) {
						if (mintSelectedRunNo == (int)gobjMethodCollection(intSelectId).QuantitativeDataCollection(intCount).RunNumber) {
							intSelectId = intCount;
							mobjClsDataFileReport.RunNumber = intCount;
							arrRunNoList(intMethod - 1, intRunNo) = intSelectId + 1;
							if (blnIsRunFound == false) {
								DtRow = dtMultiReport.NewRow();
								DtRow(0) = dtMultiReport.Rows.Count;
								DtRow(1) = mintSelectedMethodID;
								DtRow(2) = mintSelectedRunNo;
								DtRow(3) = lbRunNos.SelectedValue + "      " + strElementName;
								DtRow(4) = arrRunNoList(intMethod - 1, 0);
								DtRow(5) = arrRunNoList(intMethod - 1, intRunNo);
								dtMultiReport.Rows.Add(DtRow);
							}
							blnAddRunNo = true;
							break; // TODO: might not be correct. Was : Exit For
						}
					}

					if (blnAddRunNo) {
						for (intCount = 0; intCount <= intMethod; intCount++) {
							for (intCount1 = 0; intCount1 <= intSndDime; intCount1++) {
								if (arrRunNoList(intCount, intCount1) == 0) {
									arrRunNoList(intCount, intCount1) = -1;
								}
							}
						}
					}
				} else {
					//ReDim arrRunNoList(intMethod - 1, lbRun.Items.Count)
				}
			}

			lbRun.TopIndex = lbRun.SelectedIndex;
			lbRun.SelectedIndex = 0;

			btnRemove.Enabled = true;
			btnCreateReport.Enabled = true;
			lbRun.Refresh();



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
			//objWait.Dispose()
			//---------------------------------------------------------
		}

	}

	private void  // ERROR: Handles clauses are not supported in C#
btnRemove_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnRemove_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : To remove the run nos added for multi report.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 28.01.2007
		// Revisions             : 
		//=====================================================================
		try {
			bool blnFoundMethod;
			int intCount;
			int intCount1;
			int intCount2;
			// remove the run nos added for multi report from list box of multireport.
			//lbRun.Items.Remove(lbRun.SelectedItem)
			if (lbRun.Items.Count > 0) {
				btnRemove.Enabled = true;
				btnCreateReport.Enabled = true;

				// Search Selected Run into array and remove from it.
				bool blnIsRemoveRow = false;
				if (arrRunNoList.GetUpperBound(1) > 0) {
					while (intCount <= arrRunNoList.GetUpperBound(0)) {
						while (intCount1 <= arrRunNoList.GetUpperBound(1)) {
							intCount2 = lbRun.SelectedIndex;
							if (dtMultiReport.Rows(intCount2).Item(4) == arrRunNoList(intCount, 0)) {
								if (dtMultiReport.Rows(intCount2).Item(5) == arrRunNoList(intCount, intCount1)) {
									arrRunNoList(intCount, intCount1) = 0;
									//lbRun.Items.Remove(lbRun.SelectedItem)
									dtMultiReport.Rows.Remove(lbRun.SelectedItem.row);
									lbRun.Refresh();
									blnIsRemoveRow = true;
									break; // TODO: might not be correct. Was : Exit Do
								}
							}
							if (lbRun.Items.Count > 0) {
								btnRemove.Enabled = true;
								btnCreateReport.Enabled = true;
							} else {
								btnRemove.Enabled = false;
								btnCreateReport.Enabled = false;
							}

							intCount1 += 1;
						}
						intCount += 1;
						intCount1 = 0;
						if (blnIsRemoveRow == true) {
							break; // TODO: might not be correct. Was : Exit Do
						}
					}
				}
			} else {
				btnRemove.Enabled = false;
				btnCreateReport.Enabled = false;
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
			//objWait.Dispose()
			//---------------------------------------------------------
		}

	}

	private void  // ERROR: Handles clauses are not supported in C#
btnDeleteRun_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnDeleteRun_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : To delete the saved run nos.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 28.01.2007
		// Revisions             : Deepak on 04.08.07
		//=====================================================================
		CWaitCursor objWait;
		int intRunNumberCounter;
		int intCount;
		DataRow objRow;
		DataTable objDtMethods = new DataTable();

		try {
			//delete the saved run no from Method collection object.
			if (gobjMessageAdapter.ShowMessage(constSelectedRunNo) == true) {
				Application.DoEvents();
				objWait = new CWaitCursor();
				for (intCount = gobjMethodCollection.Count - 1; intCount >= 0; intCount += -1) {
					if (gobjMethodCollection.item(intCount).MethodID == mintSelectedMethodID) {
						for (intRunNumberCounter = 0; intRunNumberCounter <= gobjMethodCollection.item(intCount).QuantitativeDataCollection.Count - 1; intRunNumberCounter++) {
							if ((int)gobjMethodCollection.item(intCount).QuantitativeDataCollection.Item(intRunNumberCounter).RunNumber == mintSelectedRunNo) {
								gobjMethodCollection.item(intCount).QuantitativeDataCollection.RemoveAt(intRunNumberCounter);
								break; // TODO: might not be correct. Was : Exit For
							}
						}
					}
				}

				lbRunNos.SelectedIndexChanged -= lbRunNos_SelectedIndexChanged;
				// Init Method collection and form object
				if (funcSaveAllMethods(gobjMethodCollection)) {
					lbMethods.SelectedIndexChanged -= lbMethods_SelectedIndexChanged;
					if (funcLoadMethods() == true) {
						if (gobjMethodCollection.Count > 0) {
							objDtMethods.Columns.Add(ConstColumnMethodID);
							objDtMethods.Columns.Add(ConstColumnMethodName);
							for (intCount = gobjMethodCollection.Count - 1; intCount >= 0; intCount += -1) {
								objRow = objDtMethods.NewRow;
								objRow.Item(ConstColumnMethodID) = gobjMethodCollection.item(intCount).MethodID;
								objRow.Item(ConstColumnMethodName) = gobjMethodCollection.item(intCount).MethodName;
								objDtMethods.Rows.Add(objRow);
							}
							lbMethods.DataSource = objDtMethods;
							lbMethods.DisplayMember = ConstColumnMethodName;
							lbMethods.ValueMember = ConstColumnMethodID;
							lbMethods.Refresh();
						}
					}

					lbMethods.SelectedIndexChanged += lbMethods_SelectedIndexChanged;
					lbRunNos.SelectedIndexChanged += lbRunNos_SelectedIndexChanged;

					if (mblnShowByRunNo == true) {
						SelectByRunNo();
					} else {
						lbMethods.SelectedValue = mintSelectedMethodID;
						lbMethods_SelectedIndexChanged(sender, e);
					}

					gobjMessageAdapter.ShowMessage(constSelectedRunNoDeletd);
				}
			}

			lbRunNos.Refresh();
			Application.DoEvents();
			if (lbRunNos.Items.Count == 0) {
				btnOk.Enabled = false;
				btnDeleteRun.Enabled = false;
				btnAddRun.Enabled = false;
			}
			btnOk.Focus();
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

	private void  // ERROR: Handles clauses are not supported in C#
btnCreateReport_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnCreateReport_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : 
		// Purpose               : To show the multi Reports.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		int intCount;
		int intCount1;

		try {

			// Create the multi report for selected Run Nos
			mobjClsDataFileReport.DefaultFont = this.DefaultFont();
			mobjClsDataFileReport.funcMultiReport(arrRunNoList);

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

	private void  // ERROR: Handles clauses are not supported in C#
lbRun_SelectedIndexChanged(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : lbRun_SelectedIndexChanged
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : Select the Run for add or remove multi report
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 28.01.2007
		// Revisions             : 
		//=====================================================================
		try {
			//Select the Run for add or remove multi report
			if (lbRun.Items.Count == 0) {
				btnRemove.Enabled = false;
				btnCreateReport.Enabled = false;
			} else {
				btnRemove.Enabled = true;
				btnCreateReport.Enabled = true;
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

	private void  // ERROR: Handles clauses are not supported in C#
frmLoadAnalysis_Activated(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmLoadAnalysis_Activated
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To Activated the form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 28.01.2007
		// Revisions             : 
		//=====================================================================
		SelectedRunNo = lbRunNos.SelectedValue;
	}

}
