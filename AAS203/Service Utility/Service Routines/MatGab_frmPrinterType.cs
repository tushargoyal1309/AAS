public class frmPrinterType : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmPrinterType()
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
	internal GradientPanel.CustomPanel CustomPanel1;
	internal System.Windows.Forms.Panel Panel1;
	internal NETXP.Controls.XPButton btnCancel;
	internal NETXP.Controls.XPButton btnOk;
	internal System.Windows.Forms.RadioButton rbColor;
	internal System.Windows.Forms.Label lblPrinterType;
	internal System.Windows.Forms.RadioButton rbNormal;
	internal System.Windows.Forms.Panel Panel2;
	internal NETXP.Controls.Bars.CommandBar mnuAutoIgnition;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuIgnite;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuExtinguish;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPrinterType));
		this.CustomPanel1 = new GradientPanel.CustomPanel();
		this.Panel2 = new System.Windows.Forms.Panel();
		this.mnuAutoIgnition = new NETXP.Controls.Bars.CommandBar();
		this.mnuIgnite = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuExtinguish = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.btnCancel = new NETXP.Controls.XPButton();
		this.btnOk = new NETXP.Controls.XPButton();
		this.Panel1 = new System.Windows.Forms.Panel();
		this.rbColor = new System.Windows.Forms.RadioButton();
		this.lblPrinterType = new System.Windows.Forms.Label();
		this.rbNormal = new System.Windows.Forms.RadioButton();
		this.CustomPanel1.SuspendLayout();
		this.Panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.mnuAutoIgnition).BeginInit();
		this.Panel1.SuspendLayout();
		this.SuspendLayout();
		//
		//CustomPanel1
		//
		this.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanel1.Controls.Add(this.Panel2);
		this.CustomPanel1.Controls.Add(this.btnCancel);
		this.CustomPanel1.Controls.Add(this.btnOk);
		this.CustomPanel1.Controls.Add(this.Panel1);
		this.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanel1.Location = new System.Drawing.Point(0, 0);
		this.CustomPanel1.Name = "CustomPanel1";
		this.CustomPanel1.Size = new System.Drawing.Size(292, 119);
		this.CustomPanel1.TabIndex = 0;
		//
		//Panel2
		//
		this.Panel2.Controls.Add(this.mnuAutoIgnition);
		this.Panel2.Location = new System.Drawing.Point(48, 112);
		this.Panel2.Name = "Panel2";
		this.Panel2.Size = new System.Drawing.Size(216, 56);
		this.Panel2.TabIndex = 45;
		//
		//mnuAutoIgnition
		//
		this.mnuAutoIgnition.BackColor = System.Drawing.Color.Transparent;
		this.mnuAutoIgnition.CustomizeText = "&Customize Toolbar...";
		this.mnuAutoIgnition.FullRow = true;
		this.mnuAutoIgnition.ID = 5117;
		this.mnuAutoIgnition.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] {
			this.mnuIgnite,
			this.mnuExtinguish
		});
		this.mnuAutoIgnition.Location = new System.Drawing.Point(66, 16);
		this.mnuAutoIgnition.Margins.Bottom = 1;
		this.mnuAutoIgnition.Margins.Left = 1;
		this.mnuAutoIgnition.Margins.Right = 1;
		this.mnuAutoIgnition.Margins.Top = 1;
		this.mnuAutoIgnition.Name = "mnuAutoIgnition";
		this.mnuAutoIgnition.Size = new System.Drawing.Size(112, 23);
		this.mnuAutoIgnition.Style = NETXP.Controls.Bars.CommandBarStyle.Menu;
		this.mnuAutoIgnition.TabIndex = 2;
		this.mnuAutoIgnition.TabStop = false;
		this.mnuAutoIgnition.Text = "AutoIgnition";
		//
		//mnuIgnite
		//
		this.mnuIgnite.Shortcut = System.Windows.Forms.Shortcut.CtrlI;
		this.mnuIgnite.Text = "Ignite";
		//
		//mnuExtinguish
		//
		this.mnuExtinguish.PadHorizontal = 5;
		this.mnuExtinguish.Shortcut = System.Windows.Forms.Shortcut.CtrlE;
		this.mnuExtinguish.Text = "Extinguish";
		//
		//btnCancel
		//
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCancel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnCancel.Image = (System.Drawing.Image)resources.GetObject("btnCancel.Image");
		this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCancel.Location = new System.Drawing.Point(152, 72);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(86, 34);
		this.btnCancel.TabIndex = 10;
		this.btnCancel.Text = "Cancel";
		//
		//btnOk
		//
		this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOk.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnOk.Image = (System.Drawing.Image)resources.GetObject("btnOk.Image");
		this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOk.Location = new System.Drawing.Point(56, 72);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(86, 34);
		this.btnOk.TabIndex = 9;
		this.btnOk.Text = "OK";
		//
		//Panel1
		//
		this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.Panel1.Controls.Add(this.rbColor);
		this.Panel1.Controls.Add(this.lblPrinterType);
		this.Panel1.Controls.Add(this.rbNormal);
		this.Panel1.Location = new System.Drawing.Point(16, 16);
		this.Panel1.Name = "Panel1";
		this.Panel1.Size = new System.Drawing.Size(256, 48);
		this.Panel1.TabIndex = 0;
		//
		//rbColor
		//
		this.rbColor.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.rbColor.Location = new System.Drawing.Point(103, 13);
		this.rbColor.Name = "rbColor";
		this.rbColor.Size = new System.Drawing.Size(56, 24);
		this.rbColor.TabIndex = 1;
		this.rbColor.Text = "Color";
		//
		//lblPrinterType
		//
		this.lblPrinterType.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPrinterType.Location = new System.Drawing.Point(8, 14);
		this.lblPrinterType.Name = "lblPrinterType";
		this.lblPrinterType.Size = new System.Drawing.Size(72, 20);
		this.lblPrinterType.TabIndex = 0;
		this.lblPrinterType.Text = "Printer Type";
		this.lblPrinterType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//rbNormal
		//
		this.rbNormal.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.rbNormal.Location = new System.Drawing.Point(176, 13);
		this.rbNormal.Name = "rbNormal";
		this.rbNormal.Size = new System.Drawing.Size(64, 24);
		this.rbNormal.TabIndex = 1;
		this.rbNormal.Text = "Normal";
		//
		//frmPrinterType
		//
		this.AcceptButton = this.btnOk;
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.CancelButton = this.btnCancel;
		this.ClientSize = new System.Drawing.Size(292, 119);
		this.Controls.Add(this.CustomPanel1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmPrinterType";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Printer Type";
		this.CustomPanel1.ResumeLayout(false);
		this.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.mnuAutoIgnition).EndInit();
		this.Panel1.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	private void  // ERROR: Handles clauses are not supported in C#
btnOk_Click(System.Object sender, System.EventArgs e)
	{
		if (rbColor.Checked == true) {
			gstructSettings.blnSelectColorPrinter = true;
		} else if (rbNormal.Checked == true) {
			gstructSettings.blnSelectColorPrinter = false;
		}
		this.DialogResult = DialogResult.OK;
	}

	private void  // ERROR: Handles clauses are not supported in C#
btnCancel_Click(System.Object sender, System.EventArgs e)
	{
		this.DialogResult = DialogResult.Cancel;
	}

	private void  // ERROR: Handles clauses are not supported in C#
frmPrinterType_Load(object sender, System.EventArgs e)
	{
		if (gstructSettings.blnSelectColorPrinter == true) {
			rbColor.Checked = true;
		//gstructSettings.Enable21CFR = False
		//       Call gfuncSetEnable21CFRToINI(gstructApplicationSettings.Enable21CFR)
		} else {
			rbNormal.Checked = true;
			//gstructSettings.Enable21CFR = True
			//        Call gfuncSetEnable21CFRToINI(gstructApplicationSettings.Enable21CFR)
		}
		mnuExtinguish.Click += btnExtinguish_Click;
		mnuIgnite.Click += btnAutoIgnition_Click;
	}

	private void btnAutoIgnition_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnAutoIgnition_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 18-Feb-2007 03:15 pm
		// Revisions             : 1
		//=====================================================================
		try {
			mnuIgnite.Click -= btnAutoIgnition_Click;
			//If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
			// mobjController.Cancel()
			Application.DoEvents();

			gobjClsAAS203.funcIgnite(true);

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
			//If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = True
			//mobjController.Start(gobjclsBgFlameStatus)
			Application.DoEvents();
			mnuIgnite.Click += btnAutoIgnition_Click;
			//---------------------------------------------------------
		}
	}

	private void btnExtinguish_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnExtinguish_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 18-Feb-2007 03:15 pm
		// Revisions             : 1
		//=====================================================================
		try {
			mnuExtinguish.Click -= btnExtinguish_Click;
			//If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
			//mobjController.Cancel()
			Application.DoEvents();

			gobjClsAAS203.funcIgnite(false);

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
			//If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = True
			//mobjController.Start(gobjclsBgFlameStatus)
			Application.DoEvents();
			mnuExtinguish.Click += btnExtinguish_Click;
			//---------------------------------------------------------
		}
	}

}
