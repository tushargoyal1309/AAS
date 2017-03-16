using AAS203.Common;
//'this is a class behind the form
public class frmCommandTest : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmCommandTest()
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
	internal System.Windows.Forms.Label Label1;
	internal NETXP.Controls.XPButton btnCancel;
	internal NETXP.Controls.XPButton btnOk;
	internal NETXP.Controls.XPButton btnClear;
	internal NETXP.Controls.XPButton btnSendCommand;
	internal System.Windows.Forms.TextBox txtCommand;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmCommandTest));
		this.txtCommand = new System.Windows.Forms.TextBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.btnCancel = new NETXP.Controls.XPButton();
		this.btnOk = new NETXP.Controls.XPButton();
		this.btnClear = new NETXP.Controls.XPButton();
		this.btnSendCommand = new NETXP.Controls.XPButton();
		this.SuspendLayout();
		//
		//txtCommand
		//
		this.txtCommand.BackColor = System.Drawing.Color.White;
		this.txtCommand.Enabled = false;
		this.txtCommand.ForeColor = System.Drawing.Color.Black;
		this.txtCommand.Location = new System.Drawing.Point(16, 16);
		this.txtCommand.Multiline = true;
		this.txtCommand.Name = "txtCommand";
		this.txtCommand.ReadOnly = true;
		this.txtCommand.Size = new System.Drawing.Size(416, 144);
		this.txtCommand.TabIndex = 0;
		this.txtCommand.Text = "";
		//
		//Label1
		//
		this.Label1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.Label1.Location = new System.Drawing.Point(6, 176);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(434, 3);
		this.Label1.TabIndex = 1;
		//
		//btnCancel
		//
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCancel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnCancel.Image = (System.Drawing.Image)resources.GetObject("btnCancel.Image");
		this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCancel.Location = new System.Drawing.Point(338, 192);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(100, 38);
		this.btnCancel.TabIndex = 3;
		this.btnCancel.Text = "Cancel";
		//
		//btnOk
		//
		this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOk.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnOk.Image = (System.Drawing.Image)resources.GetObject("btnOk.Image");
		this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOk.Location = new System.Drawing.Point(228, 192);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(100, 38);
		this.btnOk.TabIndex = 2;
		this.btnOk.Text = "OK";
		//
		//btnClear
		//
		this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnClear.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnClear.Image = (System.Drawing.Image)resources.GetObject("btnClear.Image");
		this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnClear.Location = new System.Drawing.Point(118, 192);
		this.btnClear.Name = "btnClear";
		this.btnClear.Size = new System.Drawing.Size(100, 38);
		this.btnClear.TabIndex = 1;
		this.btnClear.Text = "Clear";
		//
		//btnSendCommand
		//
		this.btnSendCommand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnSendCommand.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnSendCommand.Image = (System.Drawing.Image)resources.GetObject("btnSendCommand.Image");
		this.btnSendCommand.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnSendCommand.Location = new System.Drawing.Point(8, 192);
		this.btnSendCommand.Name = "btnSendCommand";
		this.btnSendCommand.Size = new System.Drawing.Size(100, 38);
		this.btnSendCommand.TabIndex = 0;
		this.btnSendCommand.Text = "Send Command";
		this.btnSendCommand.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//frmCommandTest
		//
		this.AcceptButton = this.btnOk;
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.CancelButton = this.btnCancel;
		this.ClientSize = new System.Drawing.Size(450, 239);
		this.Controls.Add(this.btnClear);
		this.Controls.Add(this.btnSendCommand);
		this.Controls.Add(this.btnCancel);
		this.Controls.Add(this.btnOk);
		this.Controls.Add(this.Label1);
		this.Controls.Add(this.txtCommand);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmCommandTest";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Command Test";
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Variables"
	private frmCommand mobjfrmCommand = new frmCommand();
		#End Region
	bool blnCheck = false;

	#Region " Private Constants"

	#End Region

	#Region " Form Events"

	private void  // ERROR: Handles clauses are not supported in C#
frmCommandTest_Load(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmCommandTest_Load
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the Command Test form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S.
		// Created               : 07.12.06
		// Revisions             : 
		//=====================================================================

		//'this is called when the form is loaded


		CWaitCursor objWait = new CWaitCursor();
		try {
			btnSendCommand.Focus();
			AddHandlers();
		//'for adding event handler
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

		//::note:
		//'htis is for adding event handler

		try {
			btnCancel.Click += btnCancel_Click;
			btnClear.Click += btnClear_Click;
			btnOk.Click += btnOk_Click;
			btnSendCommand.Click += btnSendCommand_Click;

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

	private void btnSendCommand_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnSendCommand_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : This will open Command window.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 07.12.06
		// Revisions             : 
		//=====================================================================

		//'note:
		//'this is used to open the command window


		CWaitCursor objWait = new CWaitCursor();
		mobjfrmCommand = new frmCommand();
		//---02.06.09
		try {
			if (mobjfrmCommand.ShowDialog == DialogResult.OK) {
				mobjfrmCommand.Close();
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

		//'this is called when user click button
		CWaitCursor objWait = new CWaitCursor();
		try {
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	private void btnClear_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnClear_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To clear the text box. 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 25.09.06
		// Revisions             : 
		//=====================================================================

		//'note:
		//'this is called when click on clear button
		//'this is usede for clearing the text
		CWaitCursor objWait = new CWaitCursor();
		try {
			blnCheck = true;
			if (!txtCommand.Text == "") {
				txtCommand.Text = "";

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

	private void btnOk_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnOk_Click
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


		//'this is called when user lcick on OK button.

		CWaitCursor objWait = new CWaitCursor();
		try {
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

	//Private Sub Response(ByVal strResponse As String) Handles mobjfrmCommand.CheckResponse
	//    If blnCheck = True Then
	//        txtCommand.Text = ""
	//    End If

	//    blnCheck = False

	//End Sub

	private void  // ERROR: Handles clauses are not supported in C#
mobjfrmCommand_CheckResponse(string strResponse)
	{
		txtCommand.Text = txtCommand.Text + strResponse + vbCrLf;
		txtCommand.Refresh();
	}

	#End Region


}
