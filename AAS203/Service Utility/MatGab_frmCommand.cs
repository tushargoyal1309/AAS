using AAS203.Common;
//'note this is used for checking a AAS protocol by send it theough serial communication

public class frmCommand : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmCommand()
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
	internal System.Windows.Forms.Label Label1;
	internal System.Windows.Forms.Label lblCommand;
	internal System.Windows.Forms.Label lblParam1;
	internal System.Windows.Forms.Label lblParam2;
	internal System.Windows.Forms.Label lblParam3;
	internal System.Windows.Forms.Label Label2;
	internal NETXP.Controls.XPButton btnCancel;
	internal NETXP.Controls.XPButton btnOk;
	internal NumberValidator.NumberValidator txtParam1;
	internal NumberValidator.NumberValidator txtParam2;
	internal NumberValidator.NumberValidator txtParam3;
	internal NumberValidator.NumberValidator txtCommand;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmCommand));
		this.CustomPanel1 = new GradientPanel.CustomPanel();
		this.txtCommand = new NumberValidator.NumberValidator();
		this.txtParam3 = new NumberValidator.NumberValidator();
		this.txtParam2 = new NumberValidator.NumberValidator();
		this.txtParam1 = new NumberValidator.NumberValidator();
		this.btnCancel = new NETXP.Controls.XPButton();
		this.btnOk = new NETXP.Controls.XPButton();
		this.Label2 = new System.Windows.Forms.Label();
		this.lblParam3 = new System.Windows.Forms.Label();
		this.lblParam2 = new System.Windows.Forms.Label();
		this.lblParam1 = new System.Windows.Forms.Label();
		this.lblCommand = new System.Windows.Forms.Label();
		this.Label1 = new System.Windows.Forms.Label();
		this.CustomPanel1.SuspendLayout();
		this.SuspendLayout();
		//
		//CustomPanel1
		//
		this.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanel1.Controls.Add(this.txtCommand);
		this.CustomPanel1.Controls.Add(this.txtParam3);
		this.CustomPanel1.Controls.Add(this.txtParam2);
		this.CustomPanel1.Controls.Add(this.txtParam1);
		this.CustomPanel1.Controls.Add(this.btnCancel);
		this.CustomPanel1.Controls.Add(this.btnOk);
		this.CustomPanel1.Controls.Add(this.Label2);
		this.CustomPanel1.Controls.Add(this.lblParam3);
		this.CustomPanel1.Controls.Add(this.lblParam2);
		this.CustomPanel1.Controls.Add(this.lblParam1);
		this.CustomPanel1.Controls.Add(this.lblCommand);
		this.CustomPanel1.Controls.Add(this.Label1);
		this.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanel1.Location = new System.Drawing.Point(0, 0);
		this.CustomPanel1.Name = "CustomPanel1";
		this.CustomPanel1.Size = new System.Drawing.Size(362, 191);
		this.CustomPanel1.TabIndex = 0;
		//
		//txtCommand
		//
		this.txtCommand.DigitsAfterDecimalPoint = 0;
		this.txtCommand.ErrorColor = System.Drawing.Color.Empty;
		this.txtCommand.ErrorMessage = null;
		this.txtCommand.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtCommand.Location = new System.Drawing.Point(160, 32);
		this.txtCommand.MaximumRange = 55;
		this.txtCommand.MaxLength = 2;
		this.txtCommand.MinimumRange = 0;
		this.txtCommand.Name = "txtCommand";
		this.txtCommand.RangeValidation = true;
		this.txtCommand.Size = new System.Drawing.Size(40, 22);
		this.txtCommand.TabIndex = 13;
		this.txtCommand.Text = "0";
		this.txtCommand.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.txtCommand.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly;
		//
		//txtParam3
		//
		this.txtParam3.DigitsAfterDecimalPoint = 0;
		this.txtParam3.ErrorColor = System.Drawing.Color.Empty;
		this.txtParam3.ErrorMessage = null;
		this.txtParam3.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtParam3.Location = new System.Drawing.Point(160, 137);
		this.txtParam3.MaximumRange = 300;
		this.txtParam3.MaxLength = 3;
		this.txtParam3.MinimumRange = 1;
		this.txtParam3.Name = "txtParam3";
		this.txtParam3.RangeValidation = true;
		this.txtParam3.Size = new System.Drawing.Size(40, 22);
		this.txtParam3.TabIndex = 12;
		this.txtParam3.Text = "0";
		this.txtParam3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.txtParam3.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly;
		//
		//txtParam2
		//
		this.txtParam2.DigitsAfterDecimalPoint = 0;
		this.txtParam2.ErrorColor = System.Drawing.Color.Empty;
		this.txtParam2.ErrorMessage = null;
		this.txtParam2.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtParam2.Location = new System.Drawing.Point(160, 102);
		this.txtParam2.MaximumRange = 300;
		this.txtParam2.MaxLength = 3;
		this.txtParam2.MinimumRange = 1;
		this.txtParam2.Name = "txtParam2";
		this.txtParam2.RangeValidation = true;
		this.txtParam2.Size = new System.Drawing.Size(40, 22);
		this.txtParam2.TabIndex = 11;
		this.txtParam2.Text = "0";
		this.txtParam2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.txtParam2.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly;
		//
		//txtParam1
		//
		this.txtParam1.DigitsAfterDecimalPoint = 0;
		this.txtParam1.ErrorColor = System.Drawing.Color.Empty;
		this.txtParam1.ErrorMessage = null;
		this.txtParam1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtParam1.Location = new System.Drawing.Point(160, 67);
		this.txtParam1.MaximumRange = 300;
		this.txtParam1.MaxLength = 3;
		this.txtParam1.MinimumRange = 1;
		this.txtParam1.Name = "txtParam1";
		this.txtParam1.RangeValidation = true;
		this.txtParam1.Size = new System.Drawing.Size(40, 22);
		this.txtParam1.TabIndex = 10;
		this.txtParam1.Text = "0";
		this.txtParam1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.txtParam1.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly;
		//
		//btnCancel
		//
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCancel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnCancel.Image = (System.Drawing.Image)resources.GetObject("btnCancel.Image");
		this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCancel.Location = new System.Drawing.Point(264, 104);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(86, 34);
		this.btnCancel.TabIndex = 5;
		this.btnCancel.Text = "Cancel";
		//
		//btnOk
		//
		this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOk.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnOk.Image = (System.Drawing.Image)resources.GetObject("btnOk.Image");
		this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOk.Location = new System.Drawing.Point(264, 48);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(86, 34);
		this.btnOk.TabIndex = 4;
		this.btnOk.Text = "OK";
		//
		//Label2
		//
		this.Label2.BackColor = System.Drawing.Color.Black;
		this.Label2.Location = new System.Drawing.Point(248, 8);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(2, 176);
		this.Label2.TabIndex = 9;
		//
		//lblParam3
		//
		this.lblParam3.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblParam3.Location = new System.Drawing.Point(24, 143);
		this.lblParam3.Name = "lblParam3";
		this.lblParam3.Size = new System.Drawing.Size(72, 16);
		this.lblParam3.TabIndex = 4;
		this.lblParam3.Text = "Param3";
		//
		//lblParam2
		//
		this.lblParam2.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblParam2.Location = new System.Drawing.Point(24, 106);
		this.lblParam2.Name = "lblParam2";
		this.lblParam2.Size = new System.Drawing.Size(72, 16);
		this.lblParam2.TabIndex = 3;
		this.lblParam2.Text = "Param2";
		//
		//lblParam1
		//
		this.lblParam1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblParam1.Location = new System.Drawing.Point(24, 69);
		this.lblParam1.Name = "lblParam1";
		this.lblParam1.Size = new System.Drawing.Size(72, 16);
		this.lblParam1.TabIndex = 2;
		this.lblParam1.Text = "Param1";
		//
		//lblCommand
		//
		this.lblCommand.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblCommand.Location = new System.Drawing.Point(24, 32);
		this.lblCommand.Name = "lblCommand";
		this.lblCommand.Size = new System.Drawing.Size(72, 16);
		this.lblCommand.TabIndex = 1;
		this.lblCommand.Text = "Command";
		this.lblCommand.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//Label1
		//
		this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.Label1.Location = new System.Drawing.Point(16, 16);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(208, 160);
		this.Label1.TabIndex = 0;
		//
		//frmCommand
		//
		this.AcceptButton = this.btnOk;
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.CancelButton = this.btnCancel;
		this.ClientSize = new System.Drawing.Size(362, 191);
		this.Controls.Add(this.CustomPanel1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmCommand";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Command";
		this.CustomPanel1.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Variables "

	public event  CheckResponse;

	private bool blnCheck = false;
	#End Region

	#Region " Private Constants "

	private const int intConst1 = 0x32;
	private const int intConst2 = 0x20;

	private const int intConst3 = 0x34;
	#End Region

	#Region " Form Events "

	private void  // ERROR: Handles clauses are not supported in C#
frmCommand_Load(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmCommand_Load
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the Command form.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S.
		// Created               : 07.12.06
		// Revisions             : 
		//=====================================================================
		//'this is called when form is loaded 
		//'this done some initialisation

		CWaitCursor objWait = new CWaitCursor();
		try {
			txtCommand.Focus();
			blnCheck = false;
			AddHandlers();
		//'this is called for adding event handler

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
			objWait.Dispose();
			//---------------------------------------------------------
		}
	}

	#End Region

	#Region " Private Functions "

	private void AddHandlers()
	{
		//=====================================================================
		// Procedure Name        : AddHandlers
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To add event handlers
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================

		//'note:
		//'this is used for adding a event handler
		try {
			btnCancel.Click += btnCancel_Click;
			btnOk.Click += btnOk_Click;

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

	private void btnCancel_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnCancel_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : This will close the Command Test window.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 07.12.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();

		try {
			//'this is called when user close the form
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
			objWait.Dispose();
			//---------------------------------------------------------
		}
	}

	private void btnOk_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnOk_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : This will send the Command .
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 07.12.06
		// Revisions             : 
		//=====================================================================

		//'note:
		//'this is used to send a command to the instrument
		//'step 1: take a value from user to a variable
		//'step 2: check for validation as par protocol notification
		//'and if command is varify then send it via serial communication


		CWaitCursor objWait = new CWaitCursor();
		int intCommand;
		int intParam1;
		int intParam2;
		int intParam3;
		byte[] bytArray = new byte[6];
		string strTrans = "";
		string strRec = "";
		string strConstTrans;
		string strConstRec;

		try {
			intCommand = (int)txtCommand.Text;
			intParam1 = (int)txtParam1.Text;
			intParam2 = (int)txtParam2.Text;
			intParam3 = (int)txtParam3.Text;

			//'here we taking value from user to the variables

			//***********************************************************
			//---Changed By Mangesh on 17-Apr-2007
			//***********************************************************
			//---Max Limit of Command is previously 55 and is changed to 100
			//***********************************************************
			if (intCommand < 0 | intCommand > 100) {
				gobjMessageAdapter.ShowMessage(constCommandValue);
				Application.DoEvents();
				return;
			} else if (intParam1 > 255 | intParam2 > 255 | intParam3 > 255) {
				gobjMessageAdapter.ShowMessage("Parameter value should not be more than 255", "Check value", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage);
				Application.DoEvents();
				return;
			} else if (blnCheck == false) {
				//'by Pankaj on 18.1.08
				//by Pankaj on 18.1.08
				if (gobjCommProtocol.mobjCommdll.gFuncIsPortOpen() == false) {
					frmCommPorts_Selection frmCommPorts_Selection = new frmCommPorts_Selection();
					frmCommPorts_Selection.ShowDialog();
					Application.DoEvents();
				}
				//'---

				if (gobjCommProtocol.mobjCommdll.gFuncTransmitCommand(intCommand, intParam1, intParam2, intParam3)) {
					strConstTrans = Microsoft.VisualBasic.Right(Hex(0 - (intCommand + (int)intParam1 + intParam2 + intParam3 + intConst1 + intConst2 + intConst3)), 2);
					strTrans = "Transmitted -> " + Hex(intConst1) + ", " + Hex(intCommand) + ", " + Hex(intParam1) + ", " + Hex(intParam2) + ", " + Hex(intParam3) + ", " + strConstTrans + ", " + Hex(intConst2) + ", " + Hex(intConst3) + " in HEX";
					if (CheckResponse != null) {
						CheckResponse(strTrans);
					}

					if (gobjCommProtocol.mobjCommdll.gFuncReceiveData(bytArray, CONST_LONG_DELAY)) {

						if (bytArray(1) != 1) {
							strConstRec = Microsoft.VisualBasic.Right(Hex(0 - ((int)bytArray(1) + bytArray(2) + bytArray(3) + (int)intConst1 + intConst2 + intConst3)), 2);
							strRec = "Received -> " + Hex(intConst1) + ", " + Hex(bytArray(1)) + ", " + bytArray(2) + ", " + bytArray(3) + ", " + bytArray(4) + ", " + strConstRec + ", " + Hex(intConst2) + ", " + Hex(intConst3) + " in HEX";
							if (CheckResponse != null) {
								CheckResponse(strRec);
							}

							blnCheck = true;
							this.Close();
							Application.DoEvents();

						} else {
							strConstRec = Microsoft.VisualBasic.Right(Hex(0 - ((int)bytArray(1) + bytArray(2) + bytArray(3) + (int)intConst1 + intConst2 + intConst3)), 2);
							strRec = "Received -> " + Hex(intConst1) + ", " + bytArray(1) + ", " + bytArray(2) + ", " + bytArray(3) + ", " + bytArray(4) + ", " + strConstRec + ", " + Hex(intConst2) + ", " + Hex(intConst3) + " in HEX";
							if (CheckResponse != null) {
								CheckResponse(strRec);
							}

							blnCheck = true;
							this.Close();
							Application.DoEvents();

						}
					} else {
						gobjMessageAdapter.ShowMessage(constErrorRecivedBlockBurner);
						Application.DoEvents();
						System.Environment.Exit(0);
					}
				} else {
					//Application.DoEvents()
				}

			} else if (blnCheck == true) {
				return;
			}

			//---added on 29.01.08
			if (gobjCommProtocol.mobjCommdll.gFuncIsPortOpen()) {
				gobjCommProtocol.funcGet_Current_Wv(gobjInst.WavelengthCur);
			}
		//---added on 29.01.08

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
			objWait.Dispose();
			//---------------------------------------------------------
		}
	}

	#End Region

}
