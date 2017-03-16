
using Microsoft.Win32;

//'class behind the class
public class frmCommPorts_Selection : System.Windows.Forms.Form
{

	private bool mblnCommSelectionOnce = false;
	private int mintCommPortSelected;
	private bool mblnInProcess = false;

	frmAASInitialisation objfrmAASInitialisation;
	#Region " Windows Form Designer generated code "

	public frmCommPorts_Selection()
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
	internal System.Windows.Forms.Panel Panel1;
	internal System.Windows.Forms.ComboBox cboPort_Selection;
	internal System.Windows.Forms.Label lblPort_Selection;
	internal NETXP.Controls.XPButton cmdCancel;
	internal NETXP.Controls.XPButton cmdOK;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmCommPorts_Selection));
		this.Panel1 = new System.Windows.Forms.Panel();
		this.cboPort_Selection = new System.Windows.Forms.ComboBox();
		this.lblPort_Selection = new System.Windows.Forms.Label();
		this.cmdCancel = new NETXP.Controls.XPButton();
		this.cmdOK = new NETXP.Controls.XPButton();
		this.Panel1.SuspendLayout();
		this.SuspendLayout();
		//
		//Panel1
		//
		this.Panel1.BackColor = System.Drawing.Color.AliceBlue;
		this.Panel1.Controls.Add(this.cboPort_Selection);
		this.Panel1.Controls.Add(this.lblPort_Selection);
		this.Panel1.Location = new System.Drawing.Point(3, 42);
		this.Panel1.Name = "Panel1";
		this.Panel1.Size = new System.Drawing.Size(287, 118);
		this.Panel1.TabIndex = 0;
		//
		//cboPort_Selection
		//
		this.cboPort_Selection.BackColor = System.Drawing.Color.White;
		this.cboPort_Selection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboPort_Selection.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.cboPort_Selection.Location = new System.Drawing.Point(136, 82);
		this.cboPort_Selection.Name = "cboPort_Selection";
		this.cboPort_Selection.Size = new System.Drawing.Size(106, 23);
		this.cboPort_Selection.TabIndex = 1;
		//
		//lblPort_Selection
		//
		this.lblPort_Selection.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPort_Selection.Location = new System.Drawing.Point(10, 9);
		this.lblPort_Selection.Name = "lblPort_Selection";
		this.lblPort_Selection.Size = new System.Drawing.Size(270, 70);
		this.lblPort_Selection.TabIndex = 0;
		this.lblPort_Selection.Text = "Select one of the serial communication ports attached to the instrument";
		this.lblPort_Selection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//cmdCancel
		//
		this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cmdCancel.Image = (System.Drawing.Image)resources.GetObject("cmdCancel.Image");
		this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.cmdCancel.Location = new System.Drawing.Point(200, 184);
		this.cmdCancel.Name = "cmdCancel";
		this.cmdCancel.Size = new System.Drawing.Size(86, 34);
		this.cmdCancel.TabIndex = 12;
		this.cmdCancel.Text = "&Exit";
		//
		//cmdOK
		//
		this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cmdOK.Image = (System.Drawing.Image)resources.GetObject("cmdOK.Image");
		this.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.cmdOK.Location = new System.Drawing.Point(88, 184);
		this.cmdOK.Name = "cmdOK";
		this.cmdOK.Size = new System.Drawing.Size(86, 34);
		this.cmdOK.TabIndex = 11;
		this.cmdOK.Text = "&OK";
		//
		//frmCommPorts_Selection
		//
		this.AcceptButton = this.cmdOK;
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.CancelButton = this.cmdCancel;
		this.ClientSize = new System.Drawing.Size(296, 243);
		this.Controls.Add(this.Panel1);
		this.Controls.Add(this.cmdCancel);
		this.Controls.Add(this.cmdOK);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmCommPorts_Selection";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Comm Port Selection";
		this.Panel1.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Private Functions "

	private void  // ERROR: Handles clauses are not supported in C#
frmCommPorts_Selection_Load(System.Object sender, System.EventArgs e)
	{
		//---------------------------------------------------------------------------------
		//Procedure Name	    :   frmCommPorts_Selection_Load
		//Description	    :   
		//Parameters 	    :   None 
		//Time/Date  	    :   13.03.07
		//Dependencies	    :   
		//Author		        :   Sachin Dokhale
		//Revision		    :   
		//Revision by Person	:   praveen
		//---------------------------------------------------------------------------------
		int intPorts;
		int i;

		try {
			lblPort_Selection.Text = "Select Proper RS232 Communication Port";
			//---get available comm ports count
			intPorts = gFuncGetAvailbleCommPorts();
			//'this will get a all availble port to a inte.
			mintCommPortSelected = gintCommPortSelected;

			if (!mblnCommSelectionOnce) {
				//'check for flag 
				mblnCommSelectionOnce = true;
				////----- Commited by Sachin Dokhale on 17.12.05
				//For i = 0 To intPorts '- 1
				//    cboPort_Selection.Items.Insert(i, "COM" + CStr(i + 1))
				//Next
				////-----

				////----- Added by Sachin Dokhale on 17.12.05
				//---add commports to the combo box list.
				for (i = 0; i <= gintCommPort.GetUpperBound(0); i++) {
					cboPort_Selection.Items.Insert(i, "COM" + (string)gintCommPort(i));
					//'get all selected comm port
				}
				////-----

			}

			//---set commport to the combo box.
			if (mintCommPortSelected > 0) {
				////----- Added by Sachin Dokhale on 17.12.05
				if (mintCommPortSelected > gintCommPort(gintCommPort.GetUpperBound(0))) {
					mintCommPortSelected = gintCommPort(gintCommPort.GetUpperBound(0));
					cboPort_Selection.SelectedIndex = gintCommPort.GetUpperBound(0);
				} else {
					for (i = 0; i <= gintCommPort.GetUpperBound(0); i++) {
						if (gintCommPort(i) == mintCommPortSelected) {
							cboPort_Selection.SelectedIndex = i;
							break; // TODO: might not be correct. Was : Exit For
						}

					}

				}

				//cboPort_Selection.SelectedIndex = gintCommPortSelected - 1
				////-----

			}


			if (cboPort_Selection.SelectedIndex == -1 & cboPort_Selection.Items.Count > 0) {
				cboPort_Selection.SelectedIndex = 0;
			}

			if (gobjCommProtocol.mobjCommdll.gFuncIsPortOpen()) {
				//'check if commport is open or not.
				gobjCommProtocol.mobjCommdll.gFuncCloseComm();
				//'function for close the comm port.
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex)
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
cmdCancel_Click(System.Object sender, System.EventArgs e)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name	    :   cmdCancel_Click
		//Description	    :   
		//Parameters 	    :   None 
		//Time/Date  	    :   13.03.07
		//Dependencies	    :   
		//Author		        :   Sachin Dokhale
		//Revision		    :   
		//Revision by Person	:   praveen
		//--------------------------------------------------------------------------------------
		//'note:
		//'this is called when user clicked on cancel button.
		gintCommPortSelected = 0;
		mintCommPortSelected = 0;
		this.Close();

	}

	private void  // ERROR: Handles clauses are not supported in C#
cmdOk_Click(System.Object sender, System.EventArgs e)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name	    :   cmdOk_Click
		//Description	    :   
		//Parameters 	    :   None 
		//Time/Date  	    :   13.03.07
		//Dependencies	    :   
		//Author		        :   Sachin Dokhale
		//Revision		    :   
		//Revision by Person	:   praveen
		//--------------------------------------------------------------------------------------
		//'note;
		//'this is called when user clicked on OK button.
		//'this will first take a comm port to be opened from user.
		//'check whatever it is already open or not.
		//'if already open then prompt a error mess
		//'else open a commport.
		bool blnFlag;
		try {
			if (mblnInProcess == true) {
				return;
			}
			mblnInProcess = true;

			//If gblnInstrumentInitialized Then
			////----- Added & commited by Sachin Dikhale on 17.12.05
			if (mintCommPortSelected == gintCommPort(cboPort_Selection.SelectedIndex)) {
				////-----
				if (gobjCommProtocol.mobjCommdll.gFuncIsPortOpen()) {
					//gFuncShowMessage("Port Already Open", "The selected port is in use, try with other ports", EnumMessageType.Information)
					gobjMessageAdapter.ShowMessage(constPortAlreadyOpen);
					Application.DoEvents();
					return;
				}
			}
			//End If

			//---if comm port is open then close it
			if (gobjCommProtocol.mobjCommdll.gFuncIsPortOpen()) {
				gobjCommProtocol.mobjCommdll.gFuncCloseComm();
			}

			////----- Added & commited by Sachin Dikhale on 17.12.05
			//gSelected_Port = Trim(cboPort_Selection.Text)
			mintCommPortSelected = gintCommPort(cboPort_Selection.SelectedIndex);
			////-----
			//---open selected comm port
			if (!gobjCommProtocol.mobjCommdll.gFuncISPortAvailable(mintCommPortSelected)) {
				//gFuncShowMessage("Selected communication port not available. ", "Try using another communication port", modConstants.EnumMessageType.Information)
				//gintCommPortSelected = 0
				gobjMessageAdapter.ShowMessage(constComPortNotAvailable);
				Application.DoEvents();
			} else {
				if (!gobjCommProtocol.mobjCommdll.gFuncOpenCommPort(mintCommPortSelected, true)) {
					//gFuncShowMessage("Communication Port Busy ...", "Selected communication port used by another program " & vbCrLf & "Try using another communication port", modConstants.EnumMessageType.Information)
					gobjMessageAdapter.ShowMessage(constComPortBusy);
					Application.DoEvents();
				} else {
					//--- write the port to ini 
					gintCommPortSelected = mintCommPortSelected;
					gFuncWriteToINI(SECTION_COMMSETTINGS, KEY_COMPORT, (string)gintCommPortSelected, INI_SETTINGS_PATH);

				}
			}
			this.DialogResult = DialogResult.OK;
		//Me.Close()

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gintCommPortSelected = 0;
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
			mblnInProcess = false;
			//---------------------------------------------------------
		}

	}

	private void  // ERROR: Handles clauses are not supported in C#
frmCommPorts_Selection_VisibleChanged(object sender, System.EventArgs e)
	{
		Application.DoEvents();
	}

	private void  // ERROR: Handles clauses are not supported in C#
frmCommPorts_Selection_Leave(object sender, System.EventArgs e)
	{
		Application.DoEvents();
	}

	#End Region

}
