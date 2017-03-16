public class AutoSamplerInterface : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public AutoSamplerInterface()
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
	internal System.Windows.Forms.Label lblProbe;
	internal System.Windows.Forms.Label lblPump;
	internal System.Windows.Forms.Label lblIntakeTime;
	internal System.Windows.Forms.Label lblWashTime;
	internal System.Windows.Forms.Button btnCancel;
	internal System.Windows.Forms.GroupBox gbCommands;
	internal System.Windows.Forms.GroupBox gbStatus;
	internal System.Windows.Forms.GroupBox gbTime;
	internal System.Windows.Forms.Label lblPosition;
	internal System.Windows.Forms.Label lblHome;
	internal System.Windows.Forms.Button btnSamplerHome;
	internal System.Windows.Forms.Button btnGoto;
	internal System.Windows.Forms.Button btnProbe;
	internal System.Windows.Forms.Button btnPumpRev;
	internal System.Windows.Forms.Button btnTest;
	internal System.Windows.Forms.Label lblHomeStatus;
	internal System.Windows.Forms.Label lblPositionStatus;
	internal System.Windows.Forms.Label lblProbeStatus;
	internal System.Windows.Forms.Label lblPumpStatus;
	internal System.Windows.Forms.Label lblPumpRevStatus;
	internal System.Windows.Forms.Button btnPumpForward;
	internal NumberValidator.NumberValidator txtWashTime;
	internal NumberValidator.NumberValidator txtIntakeTime;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AutoSamplerInterface));
		this.gbCommands = new System.Windows.Forms.GroupBox();
		this.btnTest = new System.Windows.Forms.Button();
		this.btnPumpRev = new System.Windows.Forms.Button();
		this.btnPumpForward = new System.Windows.Forms.Button();
		this.btnProbe = new System.Windows.Forms.Button();
		this.btnGoto = new System.Windows.Forms.Button();
		this.btnSamplerHome = new System.Windows.Forms.Button();
		this.gbStatus = new System.Windows.Forms.GroupBox();
		this.lblPumpRevStatus = new System.Windows.Forms.Label();
		this.lblPumpStatus = new System.Windows.Forms.Label();
		this.lblProbeStatus = new System.Windows.Forms.Label();
		this.lblPositionStatus = new System.Windows.Forms.Label();
		this.lblHomeStatus = new System.Windows.Forms.Label();
		this.lblHome = new System.Windows.Forms.Label();
		this.lblPosition = new System.Windows.Forms.Label();
		this.lblPump = new System.Windows.Forms.Label();
		this.lblProbe = new System.Windows.Forms.Label();
		this.gbTime = new System.Windows.Forms.GroupBox();
		this.txtIntakeTime = new NumberValidator.NumberValidator();
		this.txtWashTime = new NumberValidator.NumberValidator();
		this.lblWashTime = new System.Windows.Forms.Label();
		this.lblIntakeTime = new System.Windows.Forms.Label();
		this.btnCancel = new System.Windows.Forms.Button();
		this.gbCommands.SuspendLayout();
		this.gbStatus.SuspendLayout();
		this.gbTime.SuspendLayout();
		this.SuspendLayout();
		//
		//gbCommands
		//
		this.gbCommands.Controls.Add(this.btnTest);
		this.gbCommands.Controls.Add(this.btnPumpRev);
		this.gbCommands.Controls.Add(this.btnPumpForward);
		this.gbCommands.Controls.Add(this.btnProbe);
		this.gbCommands.Controls.Add(this.btnGoto);
		this.gbCommands.Controls.Add(this.btnSamplerHome);
		this.gbCommands.Location = new System.Drawing.Point(6, 0);
		this.gbCommands.Name = "gbCommands";
		this.gbCommands.Size = new System.Drawing.Size(176, 304);
		this.gbCommands.TabIndex = 0;
		this.gbCommands.TabStop = false;
		this.gbCommands.Text = "AutoSampler Commands";
		//
		//btnTest
		//
		this.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.btnTest.Location = new System.Drawing.Point(16, 264);
		this.btnTest.Name = "btnTest";
		this.btnTest.Size = new System.Drawing.Size(144, 32);
		this.btnTest.TabIndex = 5;
		this.btnTest.Text = "&Test All Positions";
		//
		//btnPumpRev
		//
		this.btnPumpRev.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.btnPumpRev.Location = new System.Drawing.Point(16, 216);
		this.btnPumpRev.Name = "btnPumpRev";
		this.btnPumpRev.Size = new System.Drawing.Size(144, 32);
		this.btnPumpRev.TabIndex = 4;
		this.btnPumpRev.Text = "Pump ON (&R)";
		//
		//btnPumpForward
		//
		this.btnPumpForward.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.btnPumpForward.Location = new System.Drawing.Point(16, 168);
		this.btnPumpForward.Name = "btnPumpForward";
		this.btnPumpForward.Size = new System.Drawing.Size(144, 32);
		this.btnPumpForward.TabIndex = 3;
		this.btnPumpForward.Text = "Pump ON (&F)";
		//
		//btnProbe
		//
		this.btnProbe.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.btnProbe.Location = new System.Drawing.Point(16, 120);
		this.btnProbe.Name = "btnProbe";
		this.btnProbe.Size = new System.Drawing.Size(144, 32);
		this.btnProbe.TabIndex = 2;
		this.btnProbe.Text = "&Probe Down";
		//
		//btnGoto
		//
		this.btnGoto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.btnGoto.Location = new System.Drawing.Point(16, 72);
		this.btnGoto.Name = "btnGoto";
		this.btnGoto.Size = new System.Drawing.Size(144, 32);
		this.btnGoto.TabIndex = 1;
		this.btnGoto.Text = "&Go To";
		//
		//btnSamplerHome
		//
		this.btnSamplerHome.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.btnSamplerHome.Location = new System.Drawing.Point(16, 24);
		this.btnSamplerHome.Name = "btnSamplerHome";
		this.btnSamplerHome.Size = new System.Drawing.Size(144, 32);
		this.btnSamplerHome.TabIndex = 0;
		this.btnSamplerHome.Text = "Sampler &Home";
		//
		//gbStatus
		//
		this.gbStatus.Controls.Add(this.lblPumpRevStatus);
		this.gbStatus.Controls.Add(this.lblPumpStatus);
		this.gbStatus.Controls.Add(this.lblProbeStatus);
		this.gbStatus.Controls.Add(this.lblPositionStatus);
		this.gbStatus.Controls.Add(this.lblHomeStatus);
		this.gbStatus.Controls.Add(this.lblHome);
		this.gbStatus.Controls.Add(this.lblPosition);
		this.gbStatus.Controls.Add(this.lblPump);
		this.gbStatus.Controls.Add(this.lblProbe);
		this.gbStatus.Location = new System.Drawing.Point(190, 0);
		this.gbStatus.Name = "gbStatus";
		this.gbStatus.Size = new System.Drawing.Size(232, 192);
		this.gbStatus.TabIndex = 1;
		this.gbStatus.TabStop = false;
		this.gbStatus.Text = " AutoSampler Status";
		//
		//lblPumpRevStatus
		//
		this.lblPumpRevStatus.Location = new System.Drawing.Point(96, 144);
		this.lblPumpRevStatus.Name = "lblPumpRevStatus";
		this.lblPumpRevStatus.Size = new System.Drawing.Size(128, 24);
		this.lblPumpRevStatus.TabIndex = 14;
		this.lblPumpRevStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblPumpStatus
		//
		this.lblPumpStatus.Location = new System.Drawing.Point(96, 144);
		this.lblPumpStatus.Name = "lblPumpStatus";
		this.lblPumpStatus.Size = new System.Drawing.Size(128, 24);
		this.lblPumpStatus.TabIndex = 13;
		this.lblPumpStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblPumpStatus.Visible = false;
		//
		//lblProbeStatus
		//
		this.lblProbeStatus.Location = new System.Drawing.Point(96, 104);
		this.lblProbeStatus.Name = "lblProbeStatus";
		this.lblProbeStatus.Size = new System.Drawing.Size(128, 24);
		this.lblProbeStatus.TabIndex = 12;
		this.lblProbeStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblPositionStatus
		//
		this.lblPositionStatus.Location = new System.Drawing.Point(96, 64);
		this.lblPositionStatus.Name = "lblPositionStatus";
		this.lblPositionStatus.Size = new System.Drawing.Size(128, 24);
		this.lblPositionStatus.TabIndex = 11;
		this.lblPositionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblHomeStatus
		//
		this.lblHomeStatus.Location = new System.Drawing.Point(96, 24);
		this.lblHomeStatus.Name = "lblHomeStatus";
		this.lblHomeStatus.Size = new System.Drawing.Size(128, 24);
		this.lblHomeStatus.TabIndex = 10;
		this.lblHomeStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblHome
		//
		this.lblHome.Location = new System.Drawing.Point(20, 24);
		this.lblHome.Name = "lblHome";
		this.lblHome.Size = new System.Drawing.Size(64, 24);
		this.lblHome.TabIndex = 9;
		this.lblHome.Text = "Home";
		this.lblHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblPosition
		//
		this.lblPosition.Location = new System.Drawing.Point(20, 64);
		this.lblPosition.Name = "lblPosition";
		this.lblPosition.Size = new System.Drawing.Size(64, 24);
		this.lblPosition.TabIndex = 8;
		this.lblPosition.Text = "Position";
		this.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblPump
		//
		this.lblPump.Location = new System.Drawing.Point(20, 144);
		this.lblPump.Name = "lblPump";
		this.lblPump.Size = new System.Drawing.Size(64, 24);
		this.lblPump.TabIndex = 3;
		this.lblPump.Text = "Pump";
		this.lblPump.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblProbe
		//
		this.lblProbe.Location = new System.Drawing.Point(20, 104);
		this.lblProbe.Name = "lblProbe";
		this.lblProbe.Size = new System.Drawing.Size(64, 24);
		this.lblProbe.TabIndex = 2;
		this.lblProbe.Text = "Probe";
		this.lblProbe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//gbTime
		//
		this.gbTime.Controls.Add(this.txtIntakeTime);
		this.gbTime.Controls.Add(this.txtWashTime);
		this.gbTime.Controls.Add(this.lblWashTime);
		this.gbTime.Controls.Add(this.lblIntakeTime);
		this.gbTime.Location = new System.Drawing.Point(190, 208);
		this.gbTime.Name = "gbTime";
		this.gbTime.Size = new System.Drawing.Size(232, 96);
		this.gbTime.TabIndex = 2;
		this.gbTime.TabStop = false;
		this.gbTime.Text = "Select Time";
		//
		//txtIntakeTime
		//
		this.txtIntakeTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtIntakeTime.DigitsAfterDecimalPoint = 0;
		this.txtIntakeTime.ErrorColor = System.Drawing.Color.Empty;
		this.txtIntakeTime.ErrorMessage = null;
		this.txtIntakeTime.Location = new System.Drawing.Point(168, 29);
		this.txtIntakeTime.MaximumRange = 999;
		this.txtIntakeTime.MinimumRange = 1;
		this.txtIntakeTime.Name = "txtIntakeTime";
		this.txtIntakeTime.RangeValidation = false;
		this.txtIntakeTime.Size = new System.Drawing.Size(56, 21);
		this.txtIntakeTime.TabIndex = 5;
		this.txtIntakeTime.Text = "";
		this.txtIntakeTime.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly;
		//
		//txtWashTime
		//
		this.txtWashTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtWashTime.DigitsAfterDecimalPoint = 0;
		this.txtWashTime.ErrorColor = System.Drawing.Color.Empty;
		this.txtWashTime.ErrorMessage = null;
		this.txtWashTime.Location = new System.Drawing.Point(168, 69);
		this.txtWashTime.MaximumRange = 999;
		this.txtWashTime.MinimumRange = 1;
		this.txtWashTime.Name = "txtWashTime";
		this.txtWashTime.RangeValidation = false;
		this.txtWashTime.Size = new System.Drawing.Size(56, 21);
		this.txtWashTime.TabIndex = 4;
		this.txtWashTime.Text = "";
		this.txtWashTime.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly;
		//
		//lblWashTime
		//
		this.lblWashTime.Location = new System.Drawing.Point(8, 64);
		this.lblWashTime.Name = "lblWashTime";
		this.lblWashTime.Size = new System.Drawing.Size(152, 24);
		this.lblWashTime.TabIndex = 1;
		this.lblWashTime.Text = "Sample Wash Time (Secs)";
		this.lblWashTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblIntakeTime
		//
		this.lblIntakeTime.Location = new System.Drawing.Point(8, 24);
		this.lblIntakeTime.Name = "lblIntakeTime";
		this.lblIntakeTime.Size = new System.Drawing.Size(152, 24);
		this.lblIntakeTime.TabIndex = 0;
		this.lblIntakeTime.Text = "Sample IntakeTime (secs)";
		this.lblIntakeTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//btnCancel
		//
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.btnCancel.Image = (System.Drawing.Image)resources.GetObject("btnCancel.Image");
		this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCancel.Location = new System.Drawing.Point(350, 312);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(72, 24);
		this.btnCancel.TabIndex = 3;
		this.btnCancel.Text = "&Cancel";
		this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		//
		//AutoSamplerInterface
		//
		this.AcceptButton = this.btnCancel;
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.ClientSize = new System.Drawing.Size(427, 343);
		this.Controls.Add(this.btnCancel);
		this.Controls.Add(this.gbTime);
		this.Controls.Add(this.gbStatus);
		this.Controls.Add(this.gbCommands);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "AutoSamplerInterface";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "AutoSampler Interface";
		this.gbCommands.ResumeLayout(false);
		this.gbStatus.ResumeLayout(false);
		this.gbTime.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region
	int mintx = 0;
	int minty = 0;
	bool mblnAvoidProcessing = false;

	private void txtIntakeTime_KeyUp(System.Object sender, System.Windows.Forms.KeyEventArgs e)
	{
		//mfuncAceptInteger(txtIntakeTime, e)
	}

	private void txtWashTime_KeyUp(System.Object sender, System.Windows.Forms.KeyEventArgs e)
	{
		//mfuncAceptInteger(txtWashTime, e)
	}

	private void  // ERROR: Handles clauses are not supported in C#
AutoSamplerInterface_Load(object sender, System.EventArgs e)
	{
		funcFormInitialise();
	}

	private object funcDisplayStatus()
	{
		try {
			if (gstructAutoSampler.blnHome == true) {
				lblHomeStatus.Text = "OK";
			} else {
				lblHomeStatus.Text = "ERROR";
			}
			if (gstructAutoSampler.intCoordinateX >= 0 & gstructAutoSampler.intCoordinateY >= 0) {
				lblPositionStatus.Text = "X  = " + gstructAutoSampler.intCoordinateX + ",Y =  " + gstructAutoSampler.intCoordinateY;
			} else {
				lblPositionStatus.Text = " ";
			}
			if (gstructAutoSampler.blnProbe == true) {
				lblProbeStatus.Text = "Probe UP";
			} else {
				lblProbeStatus.Text = "Probe DOWN";
			}

			if (gstructAutoSampler.blnPump == true) {
				lblPumpStatus.Text = "Pump ON (F)";
			} else {
				lblPumpStatus.Text = "Pump OFF";
			}
			if (gstructAutoSampler.blnPumpPrev == true) {
				lblPumpRevStatus.Text = "Pump ON (R)";
			} else {
				lblPumpRevStatus.Text = "Pump OFF";
			}
			funcShowButtons();
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

	private object funcShowButtons()
	{
		try {
			if (gstructAutoSampler.blnProbe == true) {
				btnProbe.Text = "Probe Down";
			} else {
				btnProbe.Text = "Probe Up";
			}
			if (gstructAutoSampler.blnPump == true) {
				btnPumpForward.Text = "Pump OFF";
			} else {
				btnPumpForward.Text = "Pump ON (F)";
			}
			if (gstructAutoSampler.blnPumpPrev == true) {
				btnPumpRev.Text = "Pump OFF";
			} else {
				btnPumpRev.Text = "Pump ON (R)";
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

	private object funcFormInitialise()
	{
		try {
			if (gobjCommProtocol.funcAutoSamplerHome()) {
				gstructAutoSampler.blnHome = true;
				gstructAutoSampler.blnCommunication = true;
				gstructAutoSampler.intCoordinateX = 0;
				gstructAutoSampler.intCoordinateY = 0;
			}
			if (gobjCommProtocol.funcAutoSamplerGoTo(0, 0, gstructAutoSampler)) {
				mintx = 0;
				minty = 0;
				gstructAutoSampler.intCoordinateX = 0;
				gstructAutoSampler.intCoordinateY = 0;
			}

			if (gobjCommProtocol.funcAutoSamplerProbeUp()) {
				gstructAutoSampler.blnProbe = true;
			}

			gstructAutoSampler.blnPump = true;
			gstructAutoSampler.blnPumpPrev = true;

			if (gobjCommProtocol.funcAutoSamplerPumpOFF()) {
				gstructAutoSampler.blnPump = false;
				gstructAutoSampler.blnPumpPrev = false;
			}

			funcDisplayStatus();
			txtIntakeTime.Text = gstructAutoSampler.intIntakeTime.ToString;
			txtWashTime.Text = gstructAutoSampler.intWashTime.ToString;

			//code added by ; dinesh wagh on 22.1.2010
			//Purpose : to remove pump buttons as there is no motor in AAS autosampler.
			//------------------------------------
			btnPumpForward.Visible = false;
			btnPumpRev.Visible = false;
			lblPump.Visible = false;
			lblPumpRevStatus.Visible = false;
			this.Height -= 60;
			btnGoto.Location = new Point(16, 80);
			btnProbe.Location = new Point(16, 140);
			btnTest.Location = new Point(16, 200);
			btnCancel.Location = new Point(350, 250);
			gbTime.Location = new Point(190, 150);
			gbCommands.Height = gbTime.Top + gbTime.Height;
			gbStatus.Height -= 50;
		//-------------------------------------



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

	//Private Sub txtIntakeTime_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
	//    Try
	//        If Val(txtIntakeTime.Text) >= 1 Or Val(txtIntakeTime.Text) < 1000 Then
	//            gstructAutoSampler.intIntakeTime = CInt(txtIntakeTime.Text)
	//        ElseIf Val(txtIntakeTime.Text) <> 0 Then
	//            'gFuncShowMessage("Invalid Input", "Enter intake time  between 1 and 999", EnumMessageType.Information)
	//            Call gobjMessageAdapter.ShowMessage("Enter intake time  between 1 and 999", "Invalid Input", EnumMessageType.Information)
	//            txtIntakeTime.Focus()
	//            e.Cancel = True
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

	//Private Sub txtWashTime_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
	//    Try
	//        If Val(txtWashTime.Text) >= 1 Or Val(txtWashTime.Text) < 1000 Then
	//            gstructAutoSampler.intWashTime = CInt(txtWashTime.Text)
	//        ElseIf Val(txtWashTime.Text) <> 0 Then
	//            Call gobjMessageAdapter.ShowMessage("Enter wash time between 1 and 999", "Invalid Input", EnumMessageType.Information)
	//            txtWashTime.Focus()
	//            e.Cancel = True
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


	private void  // ERROR: Handles clauses are not supported in C#
btnSamplerHome_Click(object sender, System.EventArgs e)
	{
		if (mblnAvoidProcessing == true) {
			return;
		}

		try {
			mblnAvoidProcessing = true;
			gstructAutoSampler.blnHome = false;

			if (gobjCommProtocol.funcAutoSamplerHome()) {
				gstructAutoSampler.blnHome = true;
				gstructAutoSampler.intCoordinateX = 0;
				gstructAutoSampler.intCoordinateY = 0;

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
			mblnAvoidProcessing = false;
			//---------------------------------------------------------
		}


	}

	private void  // ERROR: Handles clauses are not supported in C#
btnGoto_Click(object sender, System.EventArgs e)
	{
		frmCoordinatePositions objFrmEditValues = new frmCoordinatePositions(mintx, minty);

		if (mblnAvoidProcessing == true) {
			return;
		}

		try {
			mblnAvoidProcessing = true;
			if (!gobjCommProtocol.funcAutoSamplerHome()) {
				gobjMessageAdapter.ShowMessage(constErrorAutoSamplerHome);
				return;
			} else {
				gstructAutoSampler.blnHome = true;
				gstructAutoSampler.blnCommunication = true;
				gstructAutoSampler.intCoordinateX = 0;
				gstructAutoSampler.intCoordinateY = 0;
			}

			objFrmEditValues.ShowDialog();
			Application.DoEvents();
			mintx = objFrmEditValues.mintXCoordinate;
			minty = objFrmEditValues.mintYCoordinate;

			if (gobjCommProtocol.funcAutoSamplerGoTo((byte)mintx, (byte)minty, gstructAutoSampler)) {
				gstructAutoSampler.intCoordinateX = mintx;
				gstructAutoSampler.intCoordinateY = minty;
			}

			funcDisplayStatus();
			objFrmEditValues.Dispose();

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
			mblnAvoidProcessing = false;
			//---------------------------------------------------------
		}

	}

	private void  // ERROR: Handles clauses are not supported in C#
btnPumpForward_Click(System.Object sender, System.EventArgs e)
	{
		if (mblnAvoidProcessing == true) {
			return;
		}

		try {
			mblnAvoidProcessing = true;
			lblPumpStatus.Visible = true;
			lblPumpRevStatus.Visible = false;
			if (gstructAutoSampler.blnPump == true) {
				if (gobjCommProtocol.funcAutoSamplerPumpOFF()) {
					gstructAutoSampler.blnPump = false;
				}

			} else {
				if (gobjCommProtocol.funcAutoSamplerPumpON()) {
					gstructAutoSampler.blnPump = true;
				}
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
			mblnAvoidProcessing = false;
			//---------------------------------------------------------
		}


	}

	private void  // ERROR: Handles clauses are not supported in C#
btnPumpRev_Click(object sender, System.EventArgs e)
	{
		if (mblnAvoidProcessing == true) {
			return;
		}

		try {
			mblnAvoidProcessing = true;
			lblPumpStatus.Visible = false;
			lblPumpRevStatus.Visible = true;

			if (gstructAutoSampler.blnPumpPrev) {
				if (gobjCommProtocol.funcAutoSamplerPumpOFF()) {
					gstructAutoSampler.blnPumpPrev = false;
				}
			} else {
				if (gobjCommProtocol.funcAutoSamplerPumpONRev()) {
					gstructAutoSampler.blnPumpPrev = true;
				}
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
			mblnAvoidProcessing = false;
			//---------------------------------------------------------
		}


	}

	private void  // ERROR: Handles clauses are not supported in C#
btnProbe_Click(object sender, System.EventArgs e)
	{
		if (mblnAvoidProcessing == true) {
			return;
		}

		try {
			mblnAvoidProcessing = true;
			if (gstructAutoSampler.blnProbe == true) {
				if (gobjCommProtocol.funcAutoSamplerProbeDown()) {
					gstructAutoSampler.blnProbe = false;
				}
			} else {
				if (gobjCommProtocol.funcAutoSamplerProbeUp()) {
					gstructAutoSampler.blnProbe = true;
				}
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
			mblnAvoidProcessing = false;
			//---------------------------------------------------------
		}


	}

	private void  // ERROR: Handles clauses are not supported in C#
btnCancel_Click(object sender, System.EventArgs e)
	{
		if (mblnAvoidProcessing == true) {
			return;
		}

		try {
			mblnAvoidProcessing = true;
			gfuncWriteSamplerParametersToINI(gstructAutoSampler);
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
			mblnAvoidProcessing = false;
			//---------------------------------------------------------
		}

	}

	private void  // ERROR: Handles clauses are not supported in C#
btnTest_Click(System.Object sender, System.EventArgs e)
	{
		frmAutoSamplerStatus objFrmAllPosition = new frmAutoSamplerStatus();
		if (mblnAvoidProcessing == true) {
			return;
		}

		try {
			////----- Added by Pankaj on 25 03 08
			if (!((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D))) {
				if (!gstructSettings.ExeToRun == EnumApplicationMode.ServiceUtility) {
					if (!IsNothing(gobjMain)) {
						if (gobjMain.mobjController.IsThreadRunning == true) {
							gobjMain.mobjController.Cancel();
							gobjCommProtocol.mobjCommdll.subTime_Delay(500);
							//10.12.07
							Application.DoEvents();
						}
					}
				}
			}
			////-----
			mblnAvoidProcessing = true;
			this.Enabled = false;
			objFrmAllPosition.ShowDialog();
			objFrmAllPosition.Dispose();
			this.Enabled = true;
			////----- Added by pankaj on 25.03.08
			if (!((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D))) {
				if (!gstructSettings.ExeToRun == EnumApplicationMode.ServiceUtility) {
					if (!IsNothing(gobjMain)) {
						if (gobjMain.mobjController.IsThreadRunning == false) {
							gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
							Application.DoEvents();
							gobjMain.mobjController.Start(gobjclsBgFlameStatus);
						}
					}
				}
			}
		////--
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
			mblnAvoidProcessing = false;
			//---------------------------------------------------------
		}

	}
}
