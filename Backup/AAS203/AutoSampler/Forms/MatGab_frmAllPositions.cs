public class frmAutoSamplerStatus : System.Windows.Forms.Form
{
	#Region "Module lelvel Declaration"
	bool mblnCancel;
	bool mblnCallOnce = false;
	int mintx = 0;
	int minty = -1;

	Int16 mintAutoSamplerStatus;
	#End Region

	#Region " Windows Form Designer generated code "

	public frmAutoSamplerStatus()
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
	internal System.Windows.Forms.GroupBox GroupBox1;
	internal System.Windows.Forms.GroupBox GroupBox2;
	internal System.Windows.Forms.Label lblPosition;
	internal System.Windows.Forms.Button btnOk;
	internal System.Windows.Forms.Label lblStatus;
	internal System.Windows.Forms.Label lblDisplayPosition;
	internal System.Windows.Forms.Label lblPump;
	internal System.Windows.Forms.Label lblProbe;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmAutoSamplerStatus));
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.lblStatus = new System.Windows.Forms.Label();
		this.GroupBox2 = new System.Windows.Forms.GroupBox();
		this.lblProbe = new System.Windows.Forms.Label();
		this.lblPump = new System.Windows.Forms.Label();
		this.lblDisplayPosition = new System.Windows.Forms.Label();
		this.lblPosition = new System.Windows.Forms.Label();
		this.btnOk = new System.Windows.Forms.Button();
		this.GroupBox1.SuspendLayout();
		this.GroupBox2.SuspendLayout();
		this.SuspendLayout();
		//
		//GroupBox1
		//
		this.GroupBox1.Controls.Add(this.lblStatus);
		this.GroupBox1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.GroupBox1.Location = new System.Drawing.Point(8, 8);
		this.GroupBox1.Name = "GroupBox1";
		this.GroupBox1.Size = new System.Drawing.Size(256, 64);
		this.GroupBox1.TabIndex = 0;
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = "Status";
		//
		//lblStatus
		//
		this.lblStatus.Location = new System.Drawing.Point(16, 24);
		this.lblStatus.Name = "lblStatus";
		this.lblStatus.Size = new System.Drawing.Size(232, 32);
		this.lblStatus.TabIndex = 0;
		this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//GroupBox2
		//
		this.GroupBox2.Controls.Add(this.lblProbe);
		this.GroupBox2.Controls.Add(this.lblPump);
		this.GroupBox2.Controls.Add(this.lblDisplayPosition);
		this.GroupBox2.Controls.Add(this.lblPosition);
		this.GroupBox2.Location = new System.Drawing.Point(8, 72);
		this.GroupBox2.Name = "GroupBox2";
		this.GroupBox2.Size = new System.Drawing.Size(256, 144);
		this.GroupBox2.TabIndex = 1;
		this.GroupBox2.TabStop = false;
		//
		//lblProbe
		//
		this.lblProbe.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblProbe.Location = new System.Drawing.Point(16, 64);
		this.lblProbe.Name = "lblProbe";
		this.lblProbe.Size = new System.Drawing.Size(112, 23);
		this.lblProbe.TabIndex = 6;
		this.lblProbe.Text = "Down";
		this.lblProbe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblPump
		//
		this.lblPump.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPump.Location = new System.Drawing.Point(16, 104);
		this.lblPump.Name = "lblPump";
		this.lblPump.Size = new System.Drawing.Size(112, 23);
		this.lblPump.TabIndex = 5;
		this.lblPump.Text = "OFF";
		this.lblPump.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblDisplayPosition
		//
		this.lblDisplayPosition.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblDisplayPosition.Location = new System.Drawing.Point(16, 24);
		this.lblDisplayPosition.Name = "lblDisplayPosition";
		this.lblDisplayPosition.Size = new System.Drawing.Size(112, 23);
		this.lblDisplayPosition.TabIndex = 4;
		this.lblDisplayPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblPosition
		//
		this.lblPosition.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPosition.Location = new System.Drawing.Point(144, 23);
		this.lblPosition.Name = "lblPosition";
		this.lblPosition.Size = new System.Drawing.Size(64, 24);
		this.lblPosition.TabIndex = 0;
		this.lblPosition.Text = "Position";
		this.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//btnOk
		//
		this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.btnOk.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnOk.Image = (System.Drawing.Image)resources.GetObject("btnOk.Image");
		this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOk.Location = new System.Drawing.Point(192, 224);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(72, 24);
		this.btnOk.TabIndex = 2;
		this.btnOk.Text = "&Cancel";
		this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		//
		//frmAutoSamplerStatus
		//
		this.AcceptButton = this.btnOk;
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.ClientSize = new System.Drawing.Size(272, 255);
		this.Controls.Add(this.btnOk);
		this.Controls.Add(this.GroupBox2);
		this.Controls.Add(this.GroupBox1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmAutoSamplerStatus";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "AutoSampler Status";
		this.GroupBox1.ResumeLayout(false);
		this.GroupBox2.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region "Form Events"
	private void  // ERROR: Handles clauses are not supported in C#
frmAllPositions_Load(System.Object sender, System.EventArgs e)
	{
		mblnCancel = false;
		mintAutoSamplerStatus = enumAutoSamplerOperation.Home;
	}

	private void  // ERROR: Handles clauses are not supported in C#
btnOk_Click(System.Object sender, System.EventArgs e)
	{
		mblnCancel = true;
	}
	#End Region

	#Region "General Functions"

	private object funcTesting()
	{
		bool blnFlag = false;
		int intCurrentx;
		int intCurrenty;
		try {
			while (mblnCancel == false) {
				Application.DoEvents();
				funcDisplayCurrentStatus(mintAutoSamplerStatus, blnFlag);
				switch (mintAutoSamplerStatus) {
					case enumAutoSamplerOperation.Home:
						if (gobjCommProtocol.funcAutoSamplerHome()) {
							gstructAutoSampler.blnHome = true;
							gstructAutoSampler.blnCommunication = true;
							gstructAutoSampler.intCoordinateX = 0;
							gstructAutoSampler.intCoordinateY = 0;
							mintAutoSamplerStatus = enumAutoSamplerOperation.Positioning;

						}
					case enumAutoSamplerOperation.Positioning:
						intCurrentx = mintx;
						intCurrenty = minty;
						minty += 1;
						if (minty > 5) {
							mintx += 1;
							if (mintx > 12) {
								mintx = 0;
							}
							minty = 0;
						}
						if (gobjCommProtocol.funcAutoSamplerGoTo(mintx, minty, gstructAutoSampler)) {
							gstructAutoSampler.intCoordinateX = mintx;
							gstructAutoSampler.intCoordinateY = minty;
							mintAutoSamplerStatus = enumAutoSamplerOperation.PumpON;
						} else {
							mintx = intCurrentx;
							minty = intCurrenty;
						}
					case enumAutoSamplerOperation.PumpON:
						if (gobjCommProtocol.funcAutoSamplerPumpON()) {
							gstructAutoSampler.blnPump = true;
							mintAutoSamplerStatus = enumAutoSamplerOperation.ProbeDown;
						}
					case enumAutoSamplerOperation.ProbeDown:
						if (gobjCommProtocol.funcAutoSamplerProbeDown()) {
							gstructAutoSampler.blnProbe = false;
							mintAutoSamplerStatus = enumAutoSamplerOperation.Waiting;
						}
					case enumAutoSamplerOperation.ProbeUp:
						if (gobjCommProtocol.funcAutoSamplerProbeUp()) {
							gstructAutoSampler.blnProbe = true;
							mintAutoSamplerStatus = enumAutoSamplerOperation.PumpOff;
						}
					case enumAutoSamplerOperation.PumpOff:
						if (gobjCommProtocol.funcAutoSamplerPumpOFF()) {
							gstructAutoSampler.blnPump = false;
							mintAutoSamplerStatus = enumAutoSamplerOperation.Positioning;
						}
					case enumAutoSamplerOperation.Waiting:
						//subTime_Delay(gstructAutoSampler.intIntakeTime * 1000)
						//Call gobjCommProtocol.mobjCommdll.subTime_Delay(gstructAutoSampler.intIntakeTime * 1000)'Commented by pankaj on 25 Mar 08
						gobjCommProtocol.mobjCommdllAutoSampler.subTime_Delay(gstructAutoSampler.intIntakeTime * 1000);
						//added by pankaj on 25 Mar 08
						mintAutoSamplerStatus = enumAutoSamplerOperation.ProbeUp;
				}
				Application.DoEvents();
			}

			if (gobjCommProtocol.funcAutoSamplerPumpOFF()) {
				gstructAutoSampler.blnPump = false;
			}
			if (gobjCommProtocol.funcAutoSamplerProbeUp()) {
				gstructAutoSampler.blnProbe = true;
			}

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

	public object funcDisplayCurrentStatus(Int16 intStatus, bool blnFlag)
	{
		try {
			switch (intStatus) {
				case 0:
					lblStatus.Text = "Setting Home";
				case 1:
					lblStatus.Text = "Positioning ";
				case 2:
					lblStatus.Text = "Setting Pump ON";
				case 3:
					lblStatus.Text = "Setting Probe Down";
				case 4:
					lblStatus.Text = "Setting Probe UP";
				case 5:
					lblStatus.Text = "Setting Pump OFF";
				case 6:
					lblStatus.Text = "Waiting ";
			}
			funcDisplayStatus();

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

	public object funcDisplayStatus()
	{
		try {
			if (gstructAutoSampler.intCoordinateX >= 0 & gstructAutoSampler.intCoordinateY >= 0) {
				lblDisplayPosition.Text = "X  = " + gstructAutoSampler.intCoordinateX + ",Y =  " + gstructAutoSampler.intCoordinateY;
			} else {
				lblDisplayPosition.Text = " ";
			}
			if (gstructAutoSampler.blnProbe == true) {
				lblProbe.Text = "Probe UP";
			} else {
				lblProbe.Text = "Probe DOWN";
			}

			if (gstructAutoSampler.blnPump == true) {
				lblPump.Text = "Pump ON ";
			} else {
				lblPump.Text = "Pump OFF";
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
frmAllPositions_Activated(object sender, System.EventArgs e)
	{
		try {
			if (mblnCallOnce == false) {
				mblnCallOnce = true;
				funcTesting();
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
