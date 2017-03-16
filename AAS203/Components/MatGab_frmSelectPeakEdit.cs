
public class frmSelectPeakEdit : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmSelectPeakEdit()
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
		CurveNames.Dispose();
	}

	//Required by the Windows Form Designer

	private System.ComponentModel.IContainer components;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.  
	//Do not modify it using the code editor.
	internal System.Windows.Forms.ComboBox cmbCurveName;
	internal System.Windows.Forms.Label Label1;
	internal GradientPanel.CustomPanel CustomPanelBackground;
	internal NETXP.Controls.XPButton btnOk;
	internal NETXP.Controls.XPButton btnCancel;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmSelectPeakEdit));
		this.cmbCurveName = new System.Windows.Forms.ComboBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.CustomPanelBackground = new GradientPanel.CustomPanel();
		this.btnCancel = new NETXP.Controls.XPButton();
		this.btnOk = new NETXP.Controls.XPButton();
		this.CustomPanelBackground.SuspendLayout();
		this.SuspendLayout();
		//
		//cmbCurveName
		//
		this.cmbCurveName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbCurveName.Location = new System.Drawing.Point(32, 53);
		this.cmbCurveName.Name = "cmbCurveName";
		this.cmbCurveName.Size = new System.Drawing.Size(168, 21);
		this.cmbCurveName.TabIndex = 0;
		//
		//Label1
		//
		this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label1.Location = new System.Drawing.Point(32, 16);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(168, 24);
		this.Label1.TabIndex = 1;
		this.Label1.Text = "Select Curve Name";
		//
		//CustomPanelBackground
		//
		this.CustomPanelBackground.BackColor = System.Drawing.Color.Gainsboro;
		this.CustomPanelBackground.BackColor2 = System.Drawing.Color.White;
		this.CustomPanelBackground.Controls.Add(this.btnCancel);
		this.CustomPanelBackground.Controls.Add(this.btnOk);
		this.CustomPanelBackground.Controls.Add(this.cmbCurveName);
		this.CustomPanelBackground.Controls.Add(this.Label1);
		this.CustomPanelBackground.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanelBackground.DockPadding.All = 1;
		this.CustomPanelBackground.GradientMode = GradientPanel.LinearGradientMode.Vertical;
		this.CustomPanelBackground.Location = new System.Drawing.Point(0, 0);
		this.CustomPanelBackground.Name = "CustomPanelBackground";
		this.CustomPanelBackground.Size = new System.Drawing.Size(218, 135);
		this.CustomPanelBackground.TabIndex = 0;
		//
		//btnCancel
		//
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCancel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCancel.Location = new System.Drawing.Point(136, 104);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(24, 16);
		this.btnCancel.TabIndex = 22;
		this.btnCancel.Text = "&C";
		//
		//btnOk
		//
		this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOk.Image = (System.Drawing.Image)resources.GetObject("btnOk.Image");
		this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOk.Location = new System.Drawing.Point(72, 95);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(90, 30);
		this.btnOk.TabIndex = 1;
		this.btnOk.Text = "&OK";
		//
		//frmSelectPeakEdit
		//
		this.AcceptButton = this.btnOk;
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.CancelButton = this.btnCancel;
		this.ClientSize = new System.Drawing.Size(218, 135);
		this.Controls.Add(this.CustomPanelBackground);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmSelectPeakEdit";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Select Curve for Peak Edit";
		this.TopMost = true;
		this.CustomPanelBackground.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Private Class Variables "


	private DataTable CurveNames = new DataTable();
	#End Region

	#Region " Public Properties "

	public DataTable CurveTable {
		set { CurveNames = Value.Copy(); }
	}

	#End Region

	#Region " Private Functions "


	private void  // ERROR: Handles clauses are not supported in C#
frmSelectPeakEdit_Load(System.Object sender, System.EventArgs e)
	{
		btnOk.BringToFront();
		btnOk.Click += subbtnOk_Click;

		if (CurveNames.Rows.Count > 0) {
			cmbCurveName.DataSource = CurveNames;
			cmbCurveName.ValueMember = CurveNames.Columns.Item(0).ColumnName;
			cmbCurveName.DisplayMember = CurveNames.Columns.Item(1).ColumnName;
		}

	}

	private void subbtnOk_Click(System.Object sender, System.EventArgs e)
	{
		try {
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

}
