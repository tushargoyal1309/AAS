using AAS203.Common;
using AAS203Library.Method;

//' class behind the class.
public class frmLoadMethod : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmLoadMethod()
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
	internal GradientPanel.CustomPanel CustomPanelRightBottom;
	internal System.Windows.Forms.Label lblMethodInformation;
	internal NETXP.Controls.XPButton btnOk;
	internal NETXP.Controls.XPButton btnCancel;
	internal NETXP.Controls.XPButton btnDelete;
	internal NETXP.Controls.XPButton btnHelp;
	internal GradientPanel.CustomPanel CustomPanelMain;
	internal GradientPanel.CustomPanel CustomPanelBottom;
	internal System.Windows.Forms.Label lblMethodComments;
	internal System.Windows.Forms.TextBox txtMethodComments;
	internal GradientPanel.CustomPanel CustomPanelTop;
	internal System.Windows.Forms.RadioButton rbMethodName;
	internal System.Windows.Forms.RadioButton rbElementName;
	internal CodeIntellects.Office2003Controls.Office2003Header Office2003Header1;
	internal GradientPanel.CustomPanel CustomPanelLeft;
	internal System.Windows.Forms.Label lblOperationMode;
	internal System.Windows.Forms.TextBox txtOperationMode;
	internal GradientPanel.CustomPanel CustomPanelBottomTop;
	internal System.Windows.Forms.GroupBox gbShowMethods;
	internal System.Windows.Forms.ListBox lstElements;
	internal System.Windows.Forms.ListBox lstMethodName;
	internal System.Windows.Forms.ListBox lstMethodInformation;
	internal System.Windows.Forms.TextBox txtElement;
	internal System.Windows.Forms.Label lblElement;
	internal System.Windows.Forms.GroupBox GroupBox1;
	internal System.Windows.Forms.CheckBox chkUVABS;
	internal System.Windows.Forms.CheckBox chkAABGCQuant;
	internal System.Windows.Forms.CheckBox chkEmission;
	internal System.Windows.Forms.CheckBox chkAAQuant;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmLoadMethod));
		this.CustomPanelMain = new GradientPanel.CustomPanel();
		this.CustomPanelRightBottom = new GradientPanel.CustomPanel();
		this.lstMethodInformation = new System.Windows.Forms.ListBox();
		this.lblOperationMode = new System.Windows.Forms.Label();
		this.txtOperationMode = new System.Windows.Forms.TextBox();
		this.lblMethodComments = new System.Windows.Forms.Label();
		this.lblMethodInformation = new System.Windows.Forms.Label();
		this.txtMethodComments = new System.Windows.Forms.TextBox();
		this.CustomPanelLeft = new GradientPanel.CustomPanel();
		this.lstMethodName = new System.Windows.Forms.ListBox();
		this.lstElements = new System.Windows.Forms.ListBox();
		this.CustomPanelBottom = new GradientPanel.CustomPanel();
		this.CustomPanelBottomTop = new GradientPanel.CustomPanel();
		this.gbShowMethods = new System.Windows.Forms.GroupBox();
		this.chkUVABS = new System.Windows.Forms.CheckBox();
		this.chkAABGCQuant = new System.Windows.Forms.CheckBox();
		this.chkEmission = new System.Windows.Forms.CheckBox();
		this.chkAAQuant = new System.Windows.Forms.CheckBox();
		this.btnDelete = new NETXP.Controls.XPButton();
		this.btnHelp = new NETXP.Controls.XPButton();
		this.btnOk = new NETXP.Controls.XPButton();
		this.btnCancel = new NETXP.Controls.XPButton();
		this.CustomPanelTop = new GradientPanel.CustomPanel();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.rbMethodName = new System.Windows.Forms.RadioButton();
		this.rbElementName = new System.Windows.Forms.RadioButton();
		this.lblElement = new System.Windows.Forms.Label();
		this.txtElement = new System.Windows.Forms.TextBox();
		this.Office2003Header1 = new CodeIntellects.Office2003Controls.Office2003Header();
		this.CustomPanelMain.SuspendLayout();
		this.CustomPanelRightBottom.SuspendLayout();
		this.CustomPanelLeft.SuspendLayout();
		this.CustomPanelBottom.SuspendLayout();
		this.CustomPanelBottomTop.SuspendLayout();
		this.gbShowMethods.SuspendLayout();
		this.CustomPanelTop.SuspendLayout();
		this.GroupBox1.SuspendLayout();
		this.SuspendLayout();
		//
		//CustomPanelMain
		//
		this.CustomPanelMain.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanelMain.BackColor2 = System.Drawing.Color.AliceBlue;
		this.CustomPanelMain.Controls.Add(this.CustomPanelRightBottom);
		this.CustomPanelMain.Controls.Add(this.CustomPanelLeft);
		this.CustomPanelMain.Controls.Add(this.CustomPanelBottom);
		this.CustomPanelMain.Controls.Add(this.CustomPanelTop);
		this.CustomPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanelMain.Location = new System.Drawing.Point(0, 22);
		this.CustomPanelMain.Name = "CustomPanelMain";
		this.CustomPanelMain.Size = new System.Drawing.Size(448, 403);
		this.CustomPanelMain.TabIndex = 0;
		//
		//CustomPanelRightBottom
		//
		this.CustomPanelRightBottom.BackColor = System.Drawing.Color.Transparent;
		this.CustomPanelRightBottom.BackColor2 = System.Drawing.Color.Transparent;
		this.CustomPanelRightBottom.Controls.Add(this.lstMethodInformation);
		this.CustomPanelRightBottom.Controls.Add(this.lblOperationMode);
		this.CustomPanelRightBottom.Controls.Add(this.txtOperationMode);
		this.CustomPanelRightBottom.Controls.Add(this.lblMethodComments);
		this.CustomPanelRightBottom.Controls.Add(this.lblMethodInformation);
		this.CustomPanelRightBottom.Controls.Add(this.txtMethodComments);
		this.CustomPanelRightBottom.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanelRightBottom.Location = new System.Drawing.Point(182, 56);
		this.CustomPanelRightBottom.Name = "CustomPanelRightBottom";
		this.CustomPanelRightBottom.Size = new System.Drawing.Size(266, 215);
		this.CustomPanelRightBottom.TabIndex = 7;
		//
		//lstMethodInformation
		//
		this.lstMethodInformation.ItemHeight = 15;
		this.lstMethodInformation.Location = new System.Drawing.Point(16, 65);
		this.lstMethodInformation.Name = "lstMethodInformation";
		this.lstMethodInformation.Size = new System.Drawing.Size(232, 64);
		this.lstMethodInformation.TabIndex = 7;
		//
		//lblOperationMode
		//
		this.lblOperationMode.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblOperationMode.Location = new System.Drawing.Point(16, 3);
		this.lblOperationMode.Name = "lblOperationMode";
		this.lblOperationMode.Size = new System.Drawing.Size(156, 16);
		this.lblOperationMode.TabIndex = 5;
		this.lblOperationMode.Text = "Operation Mode";
		//
		//txtOperationMode
		//
		this.txtOperationMode.BackColor = System.Drawing.Color.AliceBlue;
		this.txtOperationMode.Location = new System.Drawing.Point(16, 22);
		this.txtOperationMode.Name = "txtOperationMode";
		this.txtOperationMode.ReadOnly = true;
		this.txtOperationMode.Size = new System.Drawing.Size(234, 21);
		this.txtOperationMode.TabIndex = 6;
		this.txtOperationMode.Text = "";
		//
		//lblMethodComments
		//
		this.lblMethodComments.BackColor = System.Drawing.Color.Transparent;
		this.lblMethodComments.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblMethodComments.Location = new System.Drawing.Point(16, 139);
		this.lblMethodComments.Name = "lblMethodComments";
		this.lblMethodComments.Size = new System.Drawing.Size(144, 16);
		this.lblMethodComments.TabIndex = 3;
		this.lblMethodComments.Text = "Method Comments";
		//
		//lblMethodInformation
		//
		this.lblMethodInformation.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblMethodInformation.Location = new System.Drawing.Point(16, 47);
		this.lblMethodInformation.Name = "lblMethodInformation";
		this.lblMethodInformation.Size = new System.Drawing.Size(156, 16);
		this.lblMethodInformation.TabIndex = 2;
		this.lblMethodInformation.Text = "Method Information";
		//
		//txtMethodComments
		//
		this.txtMethodComments.BackColor = System.Drawing.Color.AliceBlue;
		this.txtMethodComments.Location = new System.Drawing.Point(16, 159);
		this.txtMethodComments.Multiline = true;
		this.txtMethodComments.Name = "txtMethodComments";
		this.txtMethodComments.ReadOnly = true;
		this.txtMethodComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtMethodComments.Size = new System.Drawing.Size(234, 53);
		this.txtMethodComments.TabIndex = 8;
		this.txtMethodComments.Text = "";
		//
		//CustomPanelLeft
		//
		this.CustomPanelLeft.BackColor = System.Drawing.Color.Transparent;
		this.CustomPanelLeft.BackColor2 = System.Drawing.Color.Transparent;
		this.CustomPanelLeft.Controls.Add(this.lstMethodName);
		this.CustomPanelLeft.Controls.Add(this.lstElements);
		this.CustomPanelLeft.Dock = System.Windows.Forms.DockStyle.Left;
		this.CustomPanelLeft.Location = new System.Drawing.Point(0, 56);
		this.CustomPanelLeft.Name = "CustomPanelLeft";
		this.CustomPanelLeft.Size = new System.Drawing.Size(182, 215);
		this.CustomPanelLeft.TabIndex = 10;
		//
		//lstMethodName
		//
		this.lstMethodName.Dock = System.Windows.Forms.DockStyle.Right;
		this.lstMethodName.ItemHeight = 15;
		this.lstMethodName.Location = new System.Drawing.Point(96, 0);
		this.lstMethodName.Name = "lstMethodName";
		this.lstMethodName.Size = new System.Drawing.Size(86, 214);
		this.lstMethodName.TabIndex = 5;
		//
		//lstElements
		//
		this.lstElements.Dock = System.Windows.Forms.DockStyle.Left;
		this.lstElements.ItemHeight = 15;
		this.lstElements.Location = new System.Drawing.Point(0, 0);
		this.lstElements.Name = "lstElements";
		this.lstElements.Size = new System.Drawing.Size(86, 214);
		this.lstElements.TabIndex = 4;
		//
		//CustomPanelBottom
		//
		this.CustomPanelBottom.BackColor = System.Drawing.Color.Transparent;
		this.CustomPanelBottom.BackColor2 = System.Drawing.Color.Transparent;
		this.CustomPanelBottom.Controls.Add(this.CustomPanelBottomTop);
		this.CustomPanelBottom.Controls.Add(this.btnDelete);
		this.CustomPanelBottom.Controls.Add(this.btnHelp);
		this.CustomPanelBottom.Controls.Add(this.btnOk);
		this.CustomPanelBottom.Controls.Add(this.btnCancel);
		this.CustomPanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.CustomPanelBottom.Location = new System.Drawing.Point(0, 271);
		this.CustomPanelBottom.Name = "CustomPanelBottom";
		this.CustomPanelBottom.Size = new System.Drawing.Size(448, 132);
		this.CustomPanelBottom.TabIndex = 8;
		//
		//CustomPanelBottomTop
		//
		this.CustomPanelBottomTop.BackColor = System.Drawing.Color.Transparent;
		this.CustomPanelBottomTop.BackColor2 = System.Drawing.Color.Transparent;
		this.CustomPanelBottomTop.Controls.Add(this.gbShowMethods);
		this.CustomPanelBottomTop.Dock = System.Windows.Forms.DockStyle.Top;
		this.CustomPanelBottomTop.Location = new System.Drawing.Point(0, 0);
		this.CustomPanelBottomTop.Name = "CustomPanelBottomTop";
		this.CustomPanelBottomTop.Size = new System.Drawing.Size(448, 78);
		this.CustomPanelBottomTop.TabIndex = 9;
		//
		//gbShowMethods
		//
		this.gbShowMethods.Controls.Add(this.chkUVABS);
		this.gbShowMethods.Controls.Add(this.chkAABGCQuant);
		this.gbShowMethods.Controls.Add(this.chkEmission);
		this.gbShowMethods.Controls.Add(this.chkAAQuant);
		this.gbShowMethods.Location = new System.Drawing.Point(11, 6);
		this.gbShowMethods.Name = "gbShowMethods";
		this.gbShowMethods.Size = new System.Drawing.Size(424, 66);
		this.gbShowMethods.TabIndex = 0;
		this.gbShowMethods.TabStop = false;
		this.gbShowMethods.Text = "Include Methods";
		//
		//chkUVABS
		//
		this.chkUVABS.Location = new System.Drawing.Point(220, 38);
		this.chkUVABS.Name = "chkUVABS";
		this.chkUVABS.Size = new System.Drawing.Size(206, 24);
		this.chkUVABS.TabIndex = 12;
		this.chkUVABS.Text = "&UVABS Quantitative Methods";
		//
		//chkAABGCQuant
		//
		this.chkAABGCQuant.Location = new System.Drawing.Point(220, 14);
		this.chkAABGCQuant.Name = "chkAABGCQuant";
		this.chkAABGCQuant.Size = new System.Drawing.Size(202, 24);
		this.chkAABGCQuant.TabIndex = 10;
		this.chkAABGCQuant.Text = "AA&BGC Quantitative Methods";
		//
		//chkEmission
		//
		this.chkEmission.Location = new System.Drawing.Point(16, 38);
		this.chkEmission.Name = "chkEmission";
		this.chkEmission.Size = new System.Drawing.Size(220, 24);
		this.chkEmission.TabIndex = 11;
		this.chkEmission.Text = "EMI&SSION Quantitative Methods";
		//
		//chkAAQuant
		//
		this.chkAAQuant.Location = new System.Drawing.Point(16, 14);
		this.chkAAQuant.Name = "chkAAQuant";
		this.chkAAQuant.Size = new System.Drawing.Size(192, 24);
		this.chkAAQuant.TabIndex = 9;
		this.chkAAQuant.Text = "&AA Quantitative Method";
		//
		//btnDelete
		//
		this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnDelete.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnDelete.Image = (System.Drawing.Image)resources.GetObject("btnDelete.Image");
		this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnDelete.Location = new System.Drawing.Point(215, 87);
		this.btnDelete.Name = "btnDelete";
		this.btnDelete.Size = new System.Drawing.Size(86, 34);
		this.btnDelete.TabIndex = 15;
		this.btnDelete.Text = "&Delete";
		//
		//btnHelp
		//
		this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnHelp.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnHelp.Image = (System.Drawing.Image)resources.GetObject("btnHelp.Image");
		this.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnHelp.Location = new System.Drawing.Point(348, 87);
		this.btnHelp.Name = "btnHelp";
		this.btnHelp.Size = new System.Drawing.Size(86, 34);
		this.btnHelp.TabIndex = 16;
		this.btnHelp.Text = "&Help";
		this.btnHelp.Visible = false;
		//
		//btnOk
		//
		this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOk.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnOk.Image = (System.Drawing.Image)resources.GetObject("btnOk.Image");
		this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOk.Location = new System.Drawing.Point(13, 87);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(86, 34);
		this.btnOk.TabIndex = 13;
		this.btnOk.Text = "&OK";
		//
		//btnCancel
		//
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCancel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnCancel.Image = (System.Drawing.Image)resources.GetObject("btnCancel.Image");
		this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCancel.Location = new System.Drawing.Point(115, 87);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(86, 34);
		this.btnCancel.TabIndex = 14;
		this.btnCancel.Text = "&Cancel";
		//
		//CustomPanelTop
		//
		this.CustomPanelTop.BackColor = System.Drawing.Color.Transparent;
		this.CustomPanelTop.BackColor2 = System.Drawing.Color.Transparent;
		this.CustomPanelTop.Controls.Add(this.GroupBox1);
		this.CustomPanelTop.Controls.Add(this.lblElement);
		this.CustomPanelTop.Controls.Add(this.txtElement);
		this.CustomPanelTop.Dock = System.Windows.Forms.DockStyle.Top;
		this.CustomPanelTop.Location = new System.Drawing.Point(0, 0);
		this.CustomPanelTop.Name = "CustomPanelTop";
		this.CustomPanelTop.Size = new System.Drawing.Size(448, 56);
		this.CustomPanelTop.TabIndex = 9;
		//
		//GroupBox1
		//
		this.GroupBox1.Controls.Add(this.rbMethodName);
		this.GroupBox1.Controls.Add(this.rbElementName);
		this.GroupBox1.Location = new System.Drawing.Point(7, 1);
		this.GroupBox1.Name = "GroupBox1";
		this.GroupBox1.Size = new System.Drawing.Size(266, 52);
		this.GroupBox1.TabIndex = 13;
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = "Load Element By";
		//
		//rbMethodName
		//
		this.rbMethodName.Location = new System.Drawing.Point(25, 21);
		this.rbMethodName.Name = "rbMethodName";
		this.rbMethodName.Size = new System.Drawing.Size(110, 24);
		this.rbMethodName.TabIndex = 2;
		this.rbMethodName.Text = "&Method Name";
		//
		//rbElementName
		//
		this.rbElementName.Location = new System.Drawing.Point(143, 21);
		this.rbElementName.Name = "rbElementName";
		this.rbElementName.Size = new System.Drawing.Size(115, 24);
		this.rbElementName.TabIndex = 1;
		this.rbElementName.Text = "&Element Name";
		//
		//lblElement
		//
		this.lblElement.Location = new System.Drawing.Point(290, 22);
		this.lblElement.Name = "lblElement";
		this.lblElement.Size = new System.Drawing.Size(54, 14);
		this.lblElement.TabIndex = 12;
		this.lblElement.Text = "E&lement";
		//
		//txtElement
		//
		this.txtElement.BackColor = System.Drawing.Color.White;
		this.txtElement.Location = new System.Drawing.Point(346, 20);
		this.txtElement.Name = "txtElement";
		this.txtElement.ReadOnly = true;
		this.txtElement.Size = new System.Drawing.Size(71, 21);
		this.txtElement.TabIndex = 3;
		this.txtElement.Text = "";
		//
		//Office2003Header1
		//
		this.Office2003Header1.BackColor = System.Drawing.SystemColors.Control;
		this.Office2003Header1.Dock = System.Windows.Forms.DockStyle.Top;
		this.Office2003Header1.Location = new System.Drawing.Point(0, 0);
		this.Office2003Header1.Name = "Office2003Header1";
		this.Office2003Header1.Size = new System.Drawing.Size(448, 22);
		this.Office2003Header1.TabIndex = 11;
		this.Office2003Header1.TitleFont = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Office2003Header1.TitleText = "Load Method";
		//
		//frmLoadMethod
		//
		this.AcceptButton = this.btnOk;
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.CancelButton = this.btnCancel;
		this.ClientSize = new System.Drawing.Size(448, 425);
		this.ControlBox = false;
		this.Controls.Add(this.CustomPanelMain);
		this.Controls.Add(this.Office2003Header1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmLoadMethod";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Method ";
		this.CustomPanelMain.ResumeLayout(false);
		this.CustomPanelRightBottom.ResumeLayout(false);
		this.CustomPanelLeft.ResumeLayout(false);
		this.CustomPanelBottom.ResumeLayout(false);
		this.CustomPanelBottomTop.ResumeLayout(false);
		this.gbShowMethods.ResumeLayout(false);
		this.CustomPanelTop.ResumeLayout(false);
		this.GroupBox1.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Private Member Variables "

	private bool mblnShowByMethod = false;
	private int mintSelectedMethodID = 0;
	public event  LoadMethod;
	public event  LampReplaced;
	private int mintSelectedElementID = 0;
	//Dim objDtMethodNames As New DataTable

	#End Region

	#Region " Private Constants "

	private const  ConstCreatedBy = "Created By  ";
	private const  ConstCreatedOn = "Created On  ";
	private const  ConstStatus = "Status      ";
	private const  ConstChangedOn = "Changed On  ";
	private const  ConstLastUsedOn = "Last Used On";
	private const  ConstActive = "Active";
	private const  ConstNotActive = "Inactive";
	private const  ConstColumnMethodID = "MethodID";
	private const  ConstColumnMethodName = "MethodName";
	private const  ConstFormLoad = "-Method-Load";

	private const  ConstParentFormLoad = "-Method";
	//Enum OperationMode
	//    AA_Quantitative_Mode = 1
	//    UV_ABS_Quantitative_Mode = 2
	//    AABGC_Quantitative_Mode = 3
	//    Emmission_Quantitative_Mode = 4
	//End Enum

	#End Region

	#Region " Private Properties "

	private bool IsShowByMethod {
		get { return mblnShowByMethod; }
		set {
			mblnShowByMethod = Value;


			try {
				if (IsShowByMethod == true) {
					DataTable objDtMethodNames = new DataTable();
					int intCounter;
					DataRow objRow;

					lstMethodName.Visible = true;
					lstElements.Visible = false;

					//lstElements.Sorted = True
					lstMethodName.Width = (2 * lstElements.Width) + 5;
					lblElement.Visible = true;
					txtElement.Visible = true;
					lstMethodName.BeginUpdate();
					//Saurabh
					objDtMethodNames.Columns.Add(ConstColumnMethodID);
					objDtMethodNames.Columns.Add(ConstColumnMethodName);
					for (intCounter = gobjMethodCollection.Count - 1; intCounter >= 0; intCounter += -1) {
						objRow = objDtMethodNames.NewRow;
						objRow.Item(ConstColumnMethodID) = gobjMethodCollection.item(intCounter).MethodID;
						objRow.Item(ConstColumnMethodName) = gobjMethodCollection.item(intCounter).MethodName;
						objDtMethodNames.Rows.Add(objRow);
						if (gobjMethodCollection.item(intCounter).OperationMode == 1) {
							chkAAQuant.Checked = true;
						}
						if (gobjMethodCollection.item(intCounter).OperationMode == 2) {
							chkAABGCQuant.Checked = true;
						}
						if (gobjMethodCollection.item(intCounter).OperationMode == 3) {
							chkEmission.Checked = true;
						}
						if (gobjMethodCollection.item(intCounter).OperationMode == 4) {
							chkUVABS.Checked = true;
						}
					}
					lstMethodName.DataSource = objDtMethodNames;
					lstMethodName.DisplayMember = ConstColumnMethodName;
					lstMethodName.ValueMember = ConstColumnMethodID;
					lstMethodName.EndUpdate();
					//Saurabh

					SelectedMethodID = lstMethodName.SelectedValue;
				} else {
					lstMethodName.Visible = true;
					lstElements.Visible = true;
					lstMethodName.Width = lstElements.Width;
					lblElement.Visible = false;
					txtElement.Visible = false;

					SelectedElementID = lstElements.SelectedValue;
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

	private int SelectedMethodID {
		get { return mintSelectedMethodID; }
		set {
			mintSelectedMethodID = Value;

			int intCount;
			DataTable objDtElement = new DataTable();

			for (intCount = 0; intCount <= gobjMethodCollection.Count - 1; intCount++) {

				if (gobjMethodCollection.item(intCount).MethodID == SelectedMethodID) {
					funcShowMethodGeneralInfo(gobjMethodCollection.item(intCount));
					objDtElement = gobjClsAAS203.funcGetElement(gobjMethodCollection.item(intCount).InstrumentCondition.ElementID);

					if (!objDtElement == null) {
						if (objDtElement.Rows.Count > 0) {
							txtElement.Text = objDtElement.Rows(0).Item(ConstColumnElementName);
						}
					}
					break; // TODO: might not be correct. Was : Exit For
				}
			}

		}
	}

	private int SelectedElementID {
		get { return mintSelectedElementID; }
		set {
			mintSelectedElementID = Value;

			DataTable objDtMethodNames = new DataTable();
			int intCounter;
			DataRow objRow;
			try {
				objDtMethodNames.Columns.Add(ConstColumnMethodID);
				objDtMethodNames.Columns.Add(ConstColumnMethodName);
				for (intCounter = gobjMethodCollection.Count - 1; intCounter >= 0; intCounter += -1) {
					if (gobjMethodCollection.item(intCounter).InstrumentCondition.ElementID == SelectedElementID) {
						objRow = objDtMethodNames.NewRow;
						objRow.Item(ConstColumnMethodID) = gobjMethodCollection.item(intCounter).MethodID;
						objRow.Item(ConstColumnMethodName) = gobjMethodCollection.item(intCounter).MethodName;
						if (gobjMethodCollection.item(intCounter).OperationMode == 1) {
							chkAAQuant.Checked = true;
						}
						if (gobjMethodCollection.item(intCounter).OperationMode == 2) {
							chkAABGCQuant.Checked = true;
						}
						if (gobjMethodCollection.item(intCounter).OperationMode == 3) {
							chkEmission.Checked = true;
						}
						if (gobjMethodCollection.item(intCounter).OperationMode == 4) {
							chkUVABS.Checked = true;
						}
						objDtMethodNames.Rows.Add(objRow);
					}
				}
				lstMethodName.DataSource = objDtMethodNames;
				lstMethodName.DisplayMember = ConstColumnMethodName;
				lstMethodName.ValueMember = ConstColumnMethodID;
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

	#End Region

	#Region " Form Events "

	private void  // ERROR: Handles clauses are not supported in C#
frmLoadMethod_Load(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmLoadMethod_Load
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To initialize the form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 07.10.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is called when load method form is loaded.
		//'do some initialzation here.
		CWaitCursor objWait = new CWaitCursor();
		DataTable objDtMethodNames = new DataTable();
		int intCounter;
		DataRow objRow;

		try {
			gobjMain.ShowProgressBar(gstrTitleInstrumentType + ConstFormLoad);
			//'show some instrument info on status
			//'and unchecked the following control.
			chkAABGCQuant.Checked = false;
			chkAAQuant.Checked = false;
			chkEmission.Checked = false;
			chkUVABS.Checked = false;
			//If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
			//    If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
			//        chkEmission.Visible = False
			//        chkUVABS.Visible = False
			//    End If
			//End If
			SubAddHandlers();
			//'for adding all the event to control.

			lstMethodName.SelectedIndexChanged -= lstMethodName_SelectedIndexChanged;

			if (funcLoadMethods() == true) {
				//'It loads all methods from method file
				objDtMethodNames.Columns.Add(ConstColumnMethodID);
				//'for addind method ID
				objDtMethodNames.Columns.Add(ConstColumnMethodName);
				//'for adding Method name
				for (intCounter = 0; intCounter <= gobjMethodCollection.Count - 1; intCounter++) {
					//'make a counter up to a collection.
					objRow = objDtMethodNames.NewRow;
					objRow.Item(ConstColumnMethodID) = gobjMethodCollection.item(intCounter).MethodID;
					objRow.Item(ConstColumnMethodName) = gobjMethodCollection.item(intCounter).MethodName;
					objDtMethodNames.Rows.Add(objRow);
				}
				lstMethodName.DataSource = objDtMethodNames;
				lstMethodName.DisplayMember = ConstColumnMethodName;
				lstMethodName.ValueMember = ConstColumnMethodID;
			}

			lstMethodName_SelectedIndexChanged(lstMethodName, EventArgs.Empty);
			//'handle a event of Method Name changed.
			lstMethodName.SelectedIndexChanged += lstMethodName_SelectedIndexChanged;

			funcLoadElementsList();
			//'this is To load the elements list

			//----Added By Pankaj 11 May 07
			//rbMethodName.Checked = True
			//rbMethodName_CheckedChanged2(sender, e)

			////----- Modified by Sachin Dokhale
			rbMethodName.Checked = false;
			rbElementName.Checked = true;
			IsShowByMethod = false;
			////-----
			//Saurabh 10.07.07 To bring status form in front
			gobjfrmStatus.Show();
		//'for showing status 
		//Saurabh

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
			gobjMain.HideProgressBar();
			//---------------------------------------------------------
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
frmLoadMethod_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmLoadMethod_Closing
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : to close the method form.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 30.10.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is called when user close the method form.
		gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType + ConstParentFormLoad);
	}

	private void  // ERROR: Handles clauses are not supported in C#
btnDelete_Click_1(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnDelete_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To delete the selected method
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 30.10.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is called when user clicked on Delete button.
		CWaitCursor objWait;
		int intCounter;
		DataRow objRow;
		DataTable objDtMethodNames = new DataTable();


		try {
			if (gobjMessageAdapter.ShowMessage(constWantToDelete) == true) {
				Application.DoEvents();
				//'allow application to perfrom its panding work.

				objWait = new CWaitCursor();
				//'ask user for deletion show a message.
				for (intCounter = gobjMethodCollection.Count - 1; intCounter >= 0; intCounter += -1) {
					if (gobjMethodCollection.item(intCounter).MethodID == SelectedMethodID) {
						//'serach in a data structure and delete as par methodID
						gobjMethodCollection.RemoveAt(intCounter);
						break; // TODO: might not be correct. Was : Exit For
					}
				}
				//Added By Pankaj 27 May 07 
				if (!IsNothing(gobjNewMethod)) {
					if ((SelectedMethodID == gobjNewMethod.MethodID)) {
						gobjNewMethod = null;
					}
				}
				//------
				//funcSerialize(ConstMethodsFileName, gobjMethodCollection) = True Then
				if (funcSaveAllMethods(gobjMethodCollection)) {
					//'To serialize the clsMethodCollection object
					lstMethodName.SelectedIndexChanged -= lstMethodName_SelectedIndexChanged;
					if (funcLoadMethods() == true) {
						//'load the remaining method
						objDtMethodNames.Columns.Add(ConstColumnMethodID);
						objDtMethodNames.Columns.Add(ConstColumnMethodName);
						for (intCounter = 0; intCounter <= gobjMethodCollection.Count - 1; intCounter++) {
							objRow = objDtMethodNames.NewRow;
							objRow.Item(ConstColumnMethodID) = gobjMethodCollection.item(intCounter).MethodID;
							objRow.Item(ConstColumnMethodName) = gobjMethodCollection.item(intCounter).MethodName;
							objDtMethodNames.Rows.Add(objRow);
						}
						lstMethodName.DataSource = objDtMethodNames;
						lstMethodName.DisplayMember = ConstColumnMethodName;
						lstMethodName.ValueMember = ConstColumnMethodID;
					}

					lstMethodName_SelectedIndexChanged(sender, e);
					lstMethodName.SelectedIndexChanged += lstMethodName_SelectedIndexChanged;
					funcLoadElementsList();
					//'for loadind element list
					IsShowByMethod = IsShowByMethod;
					gobjMessageAdapter.ShowMessage(constDeleteConfirmation);
					Application.DoEvents();
					//'allow application to perfrom it panding task.
					if (gobjMethodCollection.Count == 0) {
						//'if ther is no another method then
						txtElement.Text = "";
						txtOperationMode.Text = "";
						lstMethodInformation.Items.Clear();
						txtMethodComments.Text = "";
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	#End Region

	#Region " Private Functions "

	private void SubAddHandlers()
	{
		//=====================================================================
		// Procedure Name        : SubAddHandlers
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To add handlers
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 07.10.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is used for adding a event to a control.
		//'this is called during the loading of a form.

		try {

			btnCancel.Click += btnCancel_Click;
			//'for eg if we click on cancel button then btnCancel_Click event is called.
			rbMethodName.CheckedChanged += rbMethodName_CheckedChanged;
			btnOk.Click += btnOk_Click;
			chkAAQuant.CheckedChanged += chkAAQuant_CheckedChanged;
			chkAABGCQuant.CheckedChanged += OperationMode_CheckedChanged;
			chkEmission.CheckedChanged += OperationMode_CheckedChanged;
			chkUVABS.CheckedChanged += OperationMode_CheckedChanged;
		//AddHandler btnDelete.Click, AddressOf btnDelete_Click
		//RemoveHandler rbMethodName.CheckedChanged, AddressOf rbMethodName_CheckedChanged
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


	private void rbMethodName_CheckedChanged(System.Object sender, System.EventArgs e)
	{
		//'not in used 
	}

	private void rbMethodName_CheckedChanged2(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : rbMethodName_CheckedChanged
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To set the property IsShowByMethod
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 07.10.06
		// Revisions             : 'Added By Pankaj 11 May 07 
		//=====================================================================
		//'note:
		//'we can display a method by two type
		//'by methodID or by element name
		//'by this function we can arrenge the method by methodname.
		try {
			chkAAQuant.CheckedChanged -= chkAAQuant_CheckedChanged;
			chkAABGCQuant.CheckedChanged -= OperationMode_CheckedChanged;
			chkEmission.CheckedChanged -= OperationMode_CheckedChanged;
			chkUVABS.CheckedChanged -= OperationMode_CheckedChanged;
			chkAAQuant.Checked = false;
			chkUVABS.Checked = false;
			chkAABGCQuant.Checked = false;
			chkEmission.Checked = false;

			if (rbMethodName.Checked == true) {
				if (lstMethodName.Items.Count == 0) {
					//'check for a item in a list.
					btnOk.Enabled = false;
					btnDelete.Enabled = false;
				} else {
					btnOk.Enabled = true;
					btnDelete.Enabled = true;
				}
				IsShowByMethod = true;

			} else {
				IsShowByMethod = false;
			}
			chkAAQuant.CheckedChanged += chkAAQuant_CheckedChanged;
			chkAABGCQuant.CheckedChanged += OperationMode_CheckedChanged;
			chkEmission.CheckedChanged += OperationMode_CheckedChanged;
			chkUVABS.CheckedChanged += OperationMode_CheckedChanged;
		//'adding a event handle.
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

	private void lstMethodName_SelectedIndexChanged(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : lstMethodName_SelectedIndexChanged
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To display method general information of selected element
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 08.10.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is called when user change the method id
		//'To display method general information of selected element
		int intCounter;
		try {
			if (lstMethodName.Items.Count == 0) {
				//'check for item in a list
				btnOk.Enabled = false;
				btnDelete.Enabled = false;
			} else {
				btnOk.Enabled = true;
				btnDelete.Enabled = true;
			}
			SelectedMethodID = lstMethodName.SelectedValue;
		//'get a selected method ID
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

	private bool funcShowMethodGeneralInfo(clsMethod objMethod)
	{
		//=====================================================================
		// Procedure Name        : funcShowMethodGeneralInfo
		// Parameters Passed     : None
		// Returns               : True or False
		// Purpose               : To show method information 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is used to show method info as par method id
		DataRow objRow;
		string strStatus = "";

		try {
			txtMethodComments.Text = objMethod.Comments;
			//'get a comment on a comment text box.
			objRow = gobjClsAAS203.funcGetMethodType(objMethod.OperationMode);
			//'for getting method type
			if (!objRow == null) {
				if (objMethod.OperationMode == 4) {
					//'check for operation mode 
					txtElement.Text = "D2";
				} else if (objMethod.OperationMode == 3) {
					//txtElement.Text = objMethod.InstrumentConditions.item(0).ElementName
					txtElement.Text = objMethod.InstrumentCondition.ElementName;
				}
				txtOperationMode.Text = objRow.Item(ConstColumnMethodType);
				//'got a method type in a operation mode text.
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
				//'get a date of modification for method.
			}
			if (!objMethod.DateOfLastUse == System.DateTime.FromOADate(0.0)) {
				strDateOfLastUse = Format(objMethod.DateOfLastUse, "dd-MMM-yyyy hh:mm tt");
				//'get last used date.
			}

			lstMethodInformation.Items.Clear();
			//'first clear the list
			lstMethodInformation.Items.Add(ConstCreatedBy + vbTab + objMethod.UserName);
			//'add user name...
			lstMethodInformation.Items.Add(ConstCreatedOn + vbTab + Format(objMethod.DateOfCreation, "dd-MMM-yyyy hh:mm tt"));
			//'add date 
			//lstMethodInformation.Items.Add(ConstStatus & Space(19) & strStatus)
			lstMethodInformation.Items.Add(ConstStatus + vbTab + vbTab + strStatus);
			//'get a status.
			lstMethodInformation.Items.Add(ConstChangedOn + vbTab + strDateOfModification);
			lstMethodInformation.Items.Add(ConstLastUsedOn + vbTab + strDateOfLastUse);
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

	private void btnOk_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnOk_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the selected method
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 08.10.06
		// Revisions             : By Deepak on 14.01.07
		//=====================================================================
		//'note:
		//'this is called when user clicked on OK button
		//'this will load a current selected methos to software''
		//'and get software ready for analysis
		CWaitCursor objWait = new CWaitCursor();
		int intCounter;

		try {
			//-------------Added By Pankaj 27 May  07
			gobjchkActiveMethod.NewMethod = false;
			gobjchkActiveMethod.CancelMethod = false;
			//gobjchkActiveMethod.fillInstruments = False  '27.07.07
			//gobjchkActiveMethod.fillParameters = False     '27.07.07
			gobjchkActiveMethod.fillStdConcentration = false;
			//-----------
			if (this.DialogResult == DialogResult.OK) {
				return;
			}
			for (intCounter = 0; intCounter <= gobjMethodCollection.Count - 1; intCounter++) {
				//'make a counter up to a collection.
				if (gobjMethodCollection.item(intCounter).MethodID == SelectedMethodID) {
					//'check for a selected MethodID
					gobjNewMethod = gobjMethodCollection.item(intCounter).Clone();

					//---Changed and Added by Mangesh On 13-Feb-2007
					int intCount;
					if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_AA | gobjNewMethod.OperationMode == EnumOperationMode.MODE_AABGC) {
						gobjNewMethod.InstrumentCondition.IsOptimize = false;

						gobjInst.Lamp.LampParametersCollection.item(gobjNewMethod.InstrumentCondition.TurretNumber - 1).Current = gobjNewMethod.InstrumentCondition.LampCurrent;
						gobjInst.Lamp.LampParametersCollection.item(gobjNewMethod.InstrumentCondition.TurretNumber - 1).SlitWidth = gobjNewMethod.InstrumentCondition.SlitWidth;

						//'check for a operation mode.
						//---added by deepak on 03.09.07
						int intCount2;
						for (intCount2 = 0; intCount2 <= gobjInst.Lamp.LampParametersCollection.Count - 1; intCount2++) {
							if ((intCount2 + 1) == gobjInst.Lamp_Position) {
								gobjfrmStatus.lblElementName.Text = gobjInst.Lamp.LampParametersCollection.item(intCount2).ElementName;
								//'show a element name in a status form.
								break; // TODO: might not be correct. Was : Exit For
							}
						}
						//------------
					}

					if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
						gobjfrmStatus.lblElementName.Text = gobjNewMethod.InstrumentCondition.ElementName;
						gobjNewMethod.InstrumentCondition.IsOptimize = false;
						//'show a element name in a status form.
					}

					//Saurabh 28 May 2007----------------
					if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_AA | gobjNewMethod.OperationMode == EnumOperationMode.MODE_AABGC) {
						int intMethodTurrNo;
						int intCount2;
						int intLamp;
						if (!gobjNewMethod.InstrumentCondition == null) {
							if (gobjNewMethod.InstrumentCondition.ElementID != 0 & gobjNewMethod.InstrumentCondition.TurretNumber != 0) {
								//'check for elementID a turrert num validation
								intMethodTurrNo = gobjNewMethod.InstrumentCondition.TurretNumber();
								//'get a turrert no.
								//intLamp = gobjNewMethod.InstrumentCondition.ElementName
								intLamp = (int)gobjClsAAS203.funcGetElement_AtomicNo(gobjNewMethod.InstrumentCondition.ElementID).Rows(0).Item("ATNO");
								//'get a lamp.
								//dr(0).GetType.ToString 
								if ((intMethodTurrNo > 0 & intMethodTurrNo < 7)) {
									//'check for validate turrert num.
									if (gobjInst.Lamp.LampParametersCollection.item(intMethodTurrNo - 1).AtomicNumber == intLamp) {
									//---allow loading method
									} else {
										gobjNewMethod.InstrumentCondition.ElementName = (string)gobjClsAAS203.funcGetElement(gobjNewMethod.InstrumentCondition.ElementID).Rows(0).Item(1);

										funCheckMethod();
										//added By PAnkaj 24 MAy 07 
										//'for checking a method.
									}
								}
							}
						}
						//Saurabh 28 May 2007----------------------------------

						///below we are showing a status as per proper cond.

						if (gobjfrmStatus.lblTurretNo.Visible == false) {
							gobjfrmStatus.lblTurretNo.Visible = true;
						}
						if (gobjfrmStatus.lblElementName.Visible == false) {
							gobjfrmStatus.lblElementName.Visible = true;
						}
					//gobjfrmwStatus.lblElementName.Text = CStr(gobjClsAAS203.funcGetElement(gobjNewMethod.InstrumentCondition.ElementID).Rows(0).Item(1))
					} else if ((gobjNewMethod.OperationMode == EnumOperationMode.MODE_UVABS)) {
						if (gobjfrmStatus.lblTurretNo.Visible == true) {
							gobjfrmStatus.lblTurretNo.Visible = false;
						}
						if (gobjfrmStatus.lblElementName.Visible == true) {
							gobjfrmStatus.lblElementName.Visible = false;
						}
					} else {
						if (gobjfrmStatus.lblTurretNo.Visible == true) {
							gobjfrmStatus.lblTurretNo.Visible = false;
						}
						if (gobjfrmStatus.lblElementName.Visible == false) {
							gobjfrmStatus.lblElementName.Visible = true;
						}
						if (!gobjNewMethod.InstrumentCondition == null) {
							if (gobjNewMethod.InstrumentCondition.ElementID != 0) {
								gobjNewMethod.InstrumentCondition.ElementName = (string)gobjClsAAS203.funcGetElement(gobjNewMethod.InstrumentCondition.ElementID).Rows(0).Item(1);
							}
						}
						//gobjfrmStatus.lblElementName.Text = CStr(gobjClsAAS203.funcGetElement(gobjNewMethod.InstrumentCondition.ElementID).Rows(0).Item(1))
					}
					//Saurabh 28 May 2007---------------------------------------

					break; // TODO: might not be correct. Was : Exit For
				}
			}

			if (LoadMethod != null) {
				LoadMethod(gobjNewMethod);
			}
			//'event for loading a method.
			gIntMethodID = gobjNewMethod.MethodID;
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				//'for 201 instrument.
				gobjfrmStatus.ElementName = (string)gobjClsAAS203.funcGetElement(gobjNewMethod.InstrumentCondition.ElementID).Rows(0).Item("NAME");
				gobjfrmStatus.TurretNumber = gobjNewMethod.InstrumentCondition.TurretNumber;
				gobjInst.Lamp_Position = gobjNewMethod.InstrumentCondition.TurretNumber;
				//---11.09.09
			}
			//gobjfrmStatus.ElementName = gobjNewMethod.InstrumentCondition.ElementName
			//gobjfrmStatus.TurretNumber = gobjNewMethod.InstrumentCondition.TurretNumber

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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	private object funCheckMethod()
	{
		//=====================================================================
		// Procedure Name        : funCheckMethod
		// Parameters Passed     : 
		// Returns               : None
		// Purpose               : To check method
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Pankaj Bamb
		// Created               : 25.05.07
		// Revisions             : 
		//=====================================================================
		//--- display message "method lamp position and turret position mismatch"
		//---check for strLamp presense in gobjinst
		//--- if present then display instrument conditions form opened in edit mode
		//---on ok loaded method turret position will change.
		//---if strLamp not present in gobjinst then
		//---display message "lamp is not present in the turret do u want to insert lamp?"
		//---if no then display instrument conditions form opened in edit mode
		//---if yes then insert selected method element in turret at position ------??
		bool blLamp = false;
		int intLamp;
		int intMethodTurrNo;
		try {
			intMethodTurrNo = gobjNewMethod.InstrumentCondition.TurretNumber();
			//'get a turrert no
			intLamp = (int)gobjClsAAS203.funcGetElement_AtomicNo(gobjNewMethod.InstrumentCondition.ElementID).Rows(0).Item("ATNO");
			//'get a lamp
			for (intMethodTurrNo = 1; intMethodTurrNo <= 6; intMethodTurrNo++) {
				//'loop a counter for turrert
				if ((gobjInst.Lamp.LampParametersCollection.item(intMethodTurrNo - 1).AtomicNumber == intLamp)) {
					intLamp = gobjInst.Lamp.LampParametersCollection.item(intMethodTurrNo - 1).AtomicNumber;
					blLamp = true;
					break; // TODO: might not be correct. Was : Exit For
				}
			}
			gobjMessageAdapter.ShowMessage(constLampPositionMismatch);
			//'show a mess of position mismatch
			frmInstrumentParameters objfrmInstPara = new frmInstrumentParameters(modGlobalConstants.EnumMethodMode.NewMode);
			//'creat a object for instrument parameter form.
			object intElementID = gobjNewMethod.InstrumentCondition.ElementID;
			if ((blLamp == true)) {
				//'if lamp present then.
				gobjNewMethod.InstrumentCondition.ElementID = 0;
				//Lamp present
				//gobjNewMethod.InstrumentCondition.ElementID = CInt(gobjClsAAS203.funcGetElementID (intLamp)
				//gobjNewMethod.InstrumentCondition.TurretNumber = intMethodTurrNo

				objfrmInstPara.ShowDialog();
			//'show a instrument parameter dialog.
			} else {
				//Lamp not present
				intLamp = gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).AtomicNumber;
				if ((gobjMessageAdapter.ShowMessage(constLampNotPresent) == true)) {
					objfrmInstPara = new frmInstrumentParameters(modGlobalConstants.EnumMethodMode.NewMode);
					//gobjNewMethod.InstrumentCondition.ElementID = gobjClsAAS203.funcGetElementID(intLamp)
					//gobjNewMethod.InstrumentCondition.TurretNumber = gobjInst.Lamp_Position
					gobjInst.Lamp.LampParametersCollection.item(gobjNewMethod.InstrumentCondition.TurretNumber - 1).AtomicNumber = (int)gobjClsAAS203.funcGetElement_AtomicNo(gobjNewMethod.InstrumentCondition.ElementID).Rows(0).Item("ATNO");
					gobjInst.Lamp.LampParametersCollection.item(gobjNewMethod.InstrumentCondition.TurretNumber - 1).ElementName = gobjNewMethod.InstrumentCondition.ElementName;
					gobjInst.Lamp.LampParametersCollection.item(gobjNewMethod.InstrumentCondition.TurretNumber - 1).Current = gobjNewMethod.InstrumentCondition.LampCurrent;
					gobjInst.Lamp.LampParametersCollection.item(gobjNewMethod.InstrumentCondition.TurretNumber - 1).SlitWidth = gobjNewMethod.InstrumentCondition.SlitWidth;
					//gobjInst.Lamp.LampParametersCollection.item(gobjNewMethod.InstrumentCondition.TurretNumber - 1).Wavelength = gobjNewMethod.InstrumentCondition.Wavelength.
					InsertLamp(gobjNewMethod.InstrumentCondition.TurretNumber);
				//gobjNewMethod.InstrumentCondition.ElementID = 0
				//gobjMessageAdapter.ShowMessage("Insert " & gobjInst.ElementName & " Lamp in turret no " & gobjInst.Lamp_Position & " and click ok button ", "Method Load", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
				} else {
					gobjNewMethod.InstrumentCondition.ElementID = 0;
				}
				objfrmInstPara.ShowDialog();
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

	private void InsertLamp(int TurretPosition)
	{
		//=====================================================================
		// Procedure Name        : InsertLamp
		// Parameters Passed     : 
		// Returns               : None
		// Purpose               : To insert lamp 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Pankaj
		// Created               : 25.05.07
		// Revisions             : 
		//=====================================================================

		//'note:
		//'this is called for insert lamp.
		//'this will insert a selected lamp at passed turrert Num.
		CWaitCursor objWait = new CWaitCursor();
		DataTable objDtElement = new DataTable();
		DataTable objDtElementWvs = new DataTable();
		frmCookBook objfrmCookBook = new frmCookBook();
		//'object for cookbook
		clsInstrumentParameters objClsInstrumentParameters;
		int intRowCounter;
		double dblWV;
		Int16 nosteps;
		AAS203Library.Instrument.ClsLampParameters objLampPar = new AAS203Library.Instrument.ClsLampParameters();
		CWaitCursor objwait1 = new CWaitCursor();
		int intCount;

		try {
			//---Getting Lamp No. ## for replacement .... Please Wait
			gobjMessageAdapter.ShowStatusMessageBox("Getting Lamp No. " + TurretPosition + " for replacement...Please Wait", "Lamp Replacement", EnumMessageType.Information, 0);
			Application.DoEvents();
			//'show a message and allow application to perfrom its panding work.
			if (gfuncInit_Lamp_Par(objLampPar) == true) {
				//'get a info of lamp ,eg element of lamp etc.
				objLampPar.ElementName = gobjInst.Lamp.LampParametersCollection.item(TurretPosition - 1).ElementName;
				//'get a element name
				objLampPar.Current = gobjInst.Lamp.LampParametersCollection.item(TurretPosition - 1).Current;
				//'get a current
				objLampPar.AtomicNumber = gobjInst.Lamp.LampParametersCollection.item(TurretPosition - 1).AtomicNumber;
				//'get a atomic num
				objLampPar.SlitWidth = gobjInst.Lamp.LampParametersCollection.item(TurretPosition - 1).SlitWidth;
				//'get a slitwidth
				objLampPar.Wavelength = gobjInst.Lamp.LampParametersCollection.item(TurretPosition - 1).Wavelength;
				//'get a wavelength.
			}
			if (gfuncSet_Lamp_Parameters(objLampPar, TurretPosition - 1) == true) {
				//'function for setting lamp at given turrert num.
				if (gobjCommProtocol.gFuncTurret_Home()) {
					//'first set a turrert at HOME position
					nosteps = gfuncTurretStepsForLampTop(TurretPosition);
					//'get a num of step for setting lamp to home.
					if (gobjCommProtocol.funcRotate_Steps_Tur_Clock(nosteps)) {
						//'now rotated a turrert in clock wise direction with respect to step.

						gobjMessageAdapter.CloseStatusMessageBox();
						Application.DoEvents();
						//---Insert Cu Lamp in turret No. 3 and click OK button                       
						if (gobjMessageAdapter.ShowMessage("Insert " + gobjNewMethod.InstrumentCondition.ElementName + " lamp in turret No. " + TurretPosition + " and click OK button", "Lamp Replacement", EnumMessageType.Information)) {
							//'now prompt user for inserting a lamp.
							Application.DoEvents();
							CWaitCursor objwait2 = new CWaitCursor();
							//---Initializing .... Please Wait
							Application.DoEvents();
							gobjMessageAdapter.ShowStatusMessageBox("Initializing .... Please Wait", "Lamp Replacement", EnumMessageType.Information, 0);
							Application.DoEvents();
							//'allow application to perfrom its panding work
							gobjCommProtocol.gFuncTurret_Home();
							//'get a turrert at HOME position.
							//mintLatestTurretPosition = TurretPosition 'objClsInstrumentParameters.TurretNumber
							gfuncLamp_connected(TurretPosition);
							//'check for a lamp connection
							gobjMessageAdapter.CloseStatusMessageBox();
							Application.DoEvents();
							//funcInitiliaze_Lamps()
							//RaiseEvent LampReplaced()
						}
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			gobjMessageAdapter.CloseStatusMessageBox();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	//Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : btnDelete_Click
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : To delete the selected method
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Deepak Bhati
	//    ' Created               : 30.10.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    Dim objWait As New CWaitCursor
	//    Dim intCounter As Integer
	//    Dim objRow As DataRow
	//    Dim objDtMethodNames As New DataTable

	//    Try

	//        If gobjMessageAdapter.ShowMessage(constWantToDelete) = True Then
	//            Application.DoEvents()

	//            For intCounter = gobjMethodCollection.Count - 1 To 0 Step -1
	//                If gobjMethodCollection.item(intCounter).MethodID = SelectedMethodID Then
	//                    gobjMethodCollection.RemoveAt(intCounter)
	//                    Exit For
	//                End If
	//            Next

	//            If funcSaveAllMethods(gobjMethodCollection) Then   'funcSerialize(ConstMethodsFileName, gobjMethodCollection) = True Then
	//                RemoveHandler lstMethodName.SelectedIndexChanged, AddressOf lstMethodName_SelectedIndexChanged
	//                If funcLoadMethods() = True Then
	//                    objDtMethodNames.Columns.Add(ConstColumnMethodID)
	//                    objDtMethodNames.Columns.Add(ConstColumnMethodName)
	//                    For intCounter = 0 To gobjMethodCollection.Count - 1
	//                        objRow = objDtMethodNames.NewRow
	//                        objRow.Item(ConstColumnMethodID) = gobjMethodCollection.item(intCounter).MethodID
	//                        objRow.Item(ConstColumnMethodName) = gobjMethodCollection.item(intCounter).MethodName
	//                        objDtMethodNames.Rows.Add(objRow)
	//                    Next
	//                    lstMethodName.DataSource = objDtMethodNames
	//                    lstMethodName.DisplayMember = ConstColumnMethodName
	//                    lstMethodName.ValueMember = ConstColumnMethodID
	//                End If

	//                lstMethodName_SelectedIndexChanged(sender, e)
	//                AddHandler lstMethodName.SelectedIndexChanged, AddressOf lstMethodName_SelectedIndexChanged
	//                funcLoadElementsList()
	//                IsShowByMethod = True
	//                gobjMessageAdapter.ShowMessage(constDeleteConfirmation)
	//                lstMethodName.Refresh()
	//                Application.DoEvents()

	//            End If
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
	//        If Not objWait Is Nothing Then
	//            objWait.Dispose()
	//        End If
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	private void btnCancel_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnCancel_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To send dialog result as cancel
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 07.10.06
		// Revisions             : 
		//=====================================================================
		try {
			//'note:
			//'this is called when user clicled on cancel button.
			lstElements.SelectedIndexChanged -= lstElements_SelectedIndexChanged;
			lstMethodName.SelectedIndexChanged -= lstMethodName_SelectedIndexChanged;
			rbMethodName.CheckedChanged -= rbMethodName_CheckedChanged;

			this.DialogResult = DialogResult.Cancel;
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

	private bool funcLoadElementsList()
	{
		//=====================================================================
		// Procedure Name        : funcLoadElementsList
		// Parameters Passed     : None
		// Returns               : True or False
		// Purpose               : To load the elements list
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 11.10.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is called for loading a element list 
		//'from datastructure
		int intCount;
		int intCounter;
		int intEleID;
		string strEleName;
		DataTable objDtElement;
		DataTable objDtShowElements;
		bool blnIsUnique = true;
		DataRow DtRow;
		try {
			lstElements.SelectedIndexChanged -= lstElements_SelectedIndexChanged;

			//If gobjMethodCollection.Count > 0 Then
			//    If gobjMethodCollection.item(0).OperationMode = EnumOperationMode.MODE_UVABS Or _
			//       gobjMethodCollection.item(0).OperationMode = EnumOperationMode.MODE_UVSPECT Then
			//        objDtElement = gobjClsAAS203.funcGetElement(200)
			//        objDtShowElements = objDtElement.Clone
			//    Else
			//        objDtElement = gobjClsAAS203.funcGetElement(gobjMethodCollection.item(0).InstrumentCondition.ElementID)
			//        objDtShowElements = objDtElement.Clone

			//    End If
			//    objDtElement.Clear()
			//End If

			//gobjNewMethod.InstrumentConditions(0).ElementID()

			//For intCount = 0 To gobjMethodCollection.Count - 1
			//    intEleID = gobjMethodCollection.item(intCount).InstrumentCondition.ElementID

			//    If objDtShowElements.Rows.Count > 0 Then
			//        For intCounter = 0 To objDtShowElements.Rows.Count - 1
			//            If objDtShowElements.Rows(intCounter).Item(ConstColumnElementID) = intEleID Then
			//                blnIsUnique = False
			//                'Exit For
			//            End If
			//        Next
			//    End If

			//    If blnIsUnique = True Then

			//        objDtElement = gobjClsAAS203.funcGetElement(intEleID)

			//        If Not objDtElement Is Nothing Then
			//            If objDtElement.Rows.Count > 0 Then

			//                objDtShowElements.ImportRow(objDtElement.Rows(0))

			//            End If
			//        End If
			//    End If
			//    blnIsUnique = True
			//Next

			ArrayList arr = new ArrayList();
			blnIsUnique = true;
			//'flag for checking unique
			for (intCount = 0; intCount <= gobjMethodCollection.Count - 1; intCount++) {
				//'make a counter up to a collection.
				intEleID = gobjMethodCollection.item(intCount).InstrumentCondition.ElementID;
				//'get a elementID
				for (intCounter = 0; intCounter <= arr.Count - 1; intCounter++) {
					if (arr.Count > 0) {
						if (intEleID == arr(intCounter)) {
							//'check for unique elementID
							blnIsUnique = false;
						}
					}
				}

				if (blnIsUnique == true) {
					arr.Add(intEleID);
				}

				blnIsUnique = true;
			}

			//Dim blnIsClone As Boolean = False
			//For intCounter = 0 To arr.Count - 1
			//    objDtElement = gobjClsAAS203.funcGetElement(arr(intCounter))
			//    If Not objDtElement Is Nothing Then
			//        If blnIsClone = False Then
			//            objDtShowElements = objDtElement.Clone
			//            blnIsClone = True
			//        End If
			//        If objDtElement.Rows.Count Then
			//            objDtShowElements.ImportRow(objDtElement.Rows(0))
			//        End If
			//    End If
			//Next

			objDtElement = gobjClsAAS203.funcGetElement(1);
			//'Toget element details from cookBook
			if (!objDtElement == null) {
				objDtShowElements = objDtElement.Clone;
				objDtShowElements.Clear();
			}

			for (intCounter = 0; intCounter <= arr.Count - 1; intCounter++) {
				objDtElement = gobjClsAAS203.funcGetElement(arr(intCounter));
				//'Toget element details from cookBook
				if (!objDtElement == null) {
					if (objDtElement.Rows.Count > 0) {
						objDtShowElements.ImportRow(objDtElement.Rows(0));
					}
				}
			}


			if (!IsNothing(objDtShowElements)) {
				if (objDtShowElements.Rows.Count > 0) {
					//'show a info on element list
					lstElements.DataSource = objDtShowElements;
					//'connect to temp datasource.
					lstElements.DisplayMember = ConstColumnElementName;
					//'get a element name
					lstElements.ValueMember = ConstColumnElementID;
					SelectedElementID = lstElements.SelectedValue;
				} else {
					lstElements.DataSource = null;
					txtElement.Text = "";
				}
			} else {
				lstElements.DataSource = null;
				txtElement.Text = "";
			}

			lstElements.SelectedIndexChanged += lstElements_SelectedIndexChanged;

			return true;
		//'return true if succed.
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

	private void lstElements_SelectedIndexChanged(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : lstElements_SelectedIndexChanged
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To set the property selectedElementID
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 11.10.06
		// Revisions             : 
		//=====================================================================
		try {
			//'note:
			//'this will get a element id as par "element combo box"  selected. 
			SelectedElementID = lstElements.SelectedValue;

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

	private void chkAAQuant_CheckedChanged(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : chkAAQuant_CheckedChanged
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To enable and disable ok button
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 11.10.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'here we are doing some on screen validation for AA quan mode
		//'for eg OK button should be disable.
		DataTable objDtMethodNames = new DataTable();
		int intCounter;
		DataRow objRow;
		try {
			//btnOk.Enabled = chkAAQuant.Checked

			ArrayList arrFilters = new ArrayList();
			arrFilters = funcGetSelectedFilterOptions();
			//'get selected filter option in a array
			if (!arrFilters == null) {
				funcFilterMethods(arrFilters);
				//'filter a method as per selected filter option.
			}

			if (lstMethodName.Items.Count == 0) {
				//'if there is no item then
				btnOk.Enabled = false;
				btnDelete.Enabled = false;
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

	private bool funcFilterMethods(ArrayList ArrOperationMode)
	{
		//=====================================================================
		// Procedure Name        : funcFilterMethods
		// Parameters Passed     : ArrayList
		// Returns               : True or False
		// Purpose               : To filter method listing according to the selected criteria.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 12.10.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is used for flter a method as per selected filter option.
		DataTable objDtMethodNames = new DataTable();
		int intCounter;
		DataRow objRow;
		int intCount;
		bool blnMatch = false;

		try {
			lstMethodName.SelectedIndexChanged -= lstMethodName_SelectedIndexChanged;

			objDtMethodNames.Columns.Add(ConstColumnMethodID);
			objDtMethodNames.Columns.Add(ConstColumnMethodName);
			//'make a datasource for datagrid.

			for (intCounter = 0; intCounter <= gobjMethodCollection.Count - 1; intCounter++) {
				for (intCount = 0; intCount <= ArrOperationMode.Count - 1; intCount++) {
					//'make a counter up to a last filter option.
					if (!rbMethodName.Checked) {
						if (gobjMethodCollection.item(intCounter).InstrumentCondition.ElementID == SelectedElementID) {
							if (gobjMethodCollection.item(intCounter).OperationMode == ArrOperationMode(intCount)) {
								blnMatch = true;
								break; // TODO: might not be correct. Was : Exit For
							}
						} else {
						}
					} else {
						if (gobjMethodCollection.item(intCounter).OperationMode == ArrOperationMode(intCount)) {
							blnMatch = true;
							break; // TODO: might not be correct. Was : Exit For
						}
					}

				}
				if (blnMatch == true) {
					objRow = objDtMethodNames.NewRow;
					objRow.Item(ConstColumnMethodID) = gobjMethodCollection.item(intCounter).MethodID;
					objRow.Item(ConstColumnMethodName) = gobjMethodCollection.item(intCounter).MethodName;
					objDtMethodNames.Rows.Add(objRow);
				}
				blnMatch = false;

			}

			lstMethodName.SelectedIndexChanged -= lstMethodName_SelectedIndexChanged;

			lstMethodName.DataSource = objDtMethodNames;
			lstMethodName.DisplayMember = ConstColumnMethodName;
			lstMethodName.ValueMember = ConstColumnMethodID;
			lstMethodName.Refresh();
			//'bind a elementlist box with data source.

			if (!rbElementName.Checked) {
				//'check whatever method is shown by element name or method ID
				if (IsShowByMethod == true) {
					SelectedMethodID = lstMethodName.SelectedValue;
				//'get a selected method ID
				} else {
					SelectedElementID = lstElements.SelectedValue;
					//'get a selected element ID
				}
			}

			return true;
		//'return a true if succed.

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
			lstMethodName.SelectedIndexChanged += lstMethodName_SelectedIndexChanged;
			Application.DoEvents();
			//'allow application to perfrom its panding work.
			//---------------------------------------------------------
		}
	}

	private void OperationMode_CheckedChanged(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : OperationMode_CheckedChanged
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To filter method listing
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 12.10.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is used to filter the element as par a operation mode.
		ArrayList arrFilters = new ArrayList();
		try {
			arrFilters = funcGetSelectedFilterOptions();
			//'get all filter option in an array
			if (!arrFilters == null) {
				funcFilterMethods(arrFilters);
				//'filter method as per filter option.
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

	private ArrayList funcGetSelectedFilterOptions()
	{
		//=====================================================================
		// Procedure Name        : funcGetSelectedFilterOptions
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To return the filter critetia
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 12.10.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this will first checked all selected option.
		//'store it in array
		//'and return this array ,then this is used in rest application.

		bool blnAAQuant;
		bool blnAABGC;
		bool blnUV;
		bool blnEmission;
		ArrayList arrMode = new ArrayList();
		try {
			//If lstMethodName.Items.Count = 0 Then
			//    btnOk.Enabled = False
			//End If
			blnAAQuant = chkAAQuant.Checked;
			blnAABGC = chkAABGCQuant.Checked;
			blnUV = chkUVABS.Checked;
			blnEmission = chkEmission.Checked;
			if (blnAAQuant == true) {
				//'add mode as per filter option
				arrMode.Add(EnumOperationMode.MODE_AA);
			}
			if (blnAABGC == true) {
				//' add AABGC mode
				arrMode.Add(EnumOperationMode.MODE_AABGC);
			}

			if (blnUV == true) {
				//'add UV mode.
				arrMode.Add(EnumOperationMode.MODE_UVABS);
			}
			if (blnEmission == true) {
				//'add emission mode.
				arrMode.Add(EnumOperationMode.MODE_EMMISSION);
			}

			if (chkAAQuant.Checked == false) {
				//'check for AAQuant
				if (chkAABGCQuant.Checked == false) {
					if (blnUV == false) {
						if (blnEmission == false) {
							btnOk.Enabled = false;
							btnDelete.Enabled = false;
							txtElement.Text = "";
							txtOperationMode.Text = "";
							txtMethodComments.Text = "";
							lstMethodInformation.Items.Clear();
						} else {
							btnOk.Enabled = true;
							btnDelete.Enabled = true;
						}
					} else {
						btnOk.Enabled = true;
						btnDelete.Enabled = true;
					}
				} else {
					btnOk.Enabled = true;
					btnDelete.Enabled = true;
				}
			} else if (blnAAQuant == true | blnAABGC == true | blnUV == true | blnEmission == true) {
				btnOk.Enabled = true;
				btnDelete.Enabled = true;
			}

			if (lstMethodName.Items.Count == 0) {
				///if null data then.
				btnOk.Enabled = false;
				btnDelete.Enabled = false;
				txtElement.Text = "";
				txtOperationMode.Text = "";
				txtMethodComments.Text = "";
				lstMethodInformation.Items.Clear();
			}

			return arrMode;
		//'return a array with selected option.
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

	private void  // ERROR: Handles clauses are not supported in C#
lstMethodName_DoubleClick(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : lstMethodName_DoubleClick
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the selected method on double click 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S.
		// Created               : 10.11.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is a event ,which called when user double click on methodname
		try {
			if (lstMethodName.Items.Count == 0) {
				//'if there is no data then
				return;
			}
			int intCounter;
			for (intCounter = 0; intCounter <= gobjMethodCollection.Count - 1; intCounter++) {
				//'make a counter up to a collection
				if (gobjMethodCollection.item(intCounter).MethodID == SelectedMethodID) {
					//'match a MethodID
					gobjNewMethod = gobjMethodCollection.item(intCounter).Clone;
					///make a clone for a object gobjNewMethod 
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			this.DialogResult = DialogResult.OK;
			if (LoadMethod != null) {
				LoadMethod(gobjNewMethod);
			}
		//'event for loadind method.


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
rbMethodName_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : rbMethodName_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : handle a event.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S.
		// Created               : 10.11.06
		// Revisions             : 
		//=====================================================================
		//Added By Pankaj 11 May 07
		rbMethodName_CheckedChanged2(sender, e);
	}

	private void  // ERROR: Handles clauses are not supported in C#
rbElementName_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : rbElementName_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : handle a event.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S.
		// Created               : 10.11.06
		// Revisions             : 
		//=====================================================================
		//Added By Pankaj 11 May 07
		rbMethodName_CheckedChanged2(sender, e);
	}

	#End Region

}

