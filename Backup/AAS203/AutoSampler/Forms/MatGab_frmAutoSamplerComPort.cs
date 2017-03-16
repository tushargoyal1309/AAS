
using Microsoft.Win32;

public class frmAutoSamplerComPort : System.Windows.Forms.Form
{
		#Region " Windows Form Designer generated code "
	bool mblnCommSelectionOnce = false;

	public frmAutoSamplerComPort()
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
	internal System.Windows.Forms.Button cmdOk;
	internal System.Windows.Forms.Panel Panel1;
	internal System.Windows.Forms.ComboBox cboPort_Selection;
	internal System.Windows.Forms.Label lblPort_Selection;
	internal System.Windows.Forms.Button cmdCancel;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmAutoSamplerComPort));
		this.cmdOk = new System.Windows.Forms.Button();
		this.Panel1 = new System.Windows.Forms.Panel();
		this.cboPort_Selection = new System.Windows.Forms.ComboBox();
		this.lblPort_Selection = new System.Windows.Forms.Label();
		this.cmdCancel = new System.Windows.Forms.Button();
		this.Panel1.SuspendLayout();
		this.SuspendLayout();
		//
		//cmdOk
		//
		this.cmdOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdOk.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.cmdOk.Image = (System.Drawing.Image)resources.GetObject("cmdOk.Image");
		this.cmdOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.cmdOk.Location = new System.Drawing.Point(144, 136);
		this.cmdOk.Name = "cmdOk";
		this.cmdOk.Size = new System.Drawing.Size(70, 30);
		this.cmdOk.TabIndex = 4;
		this.cmdOk.Text = "&Ok";
		//
		//Panel1
		//
		this.Panel1.BackColor = System.Drawing.Color.AliceBlue;
		this.Panel1.Controls.Add(this.cboPort_Selection);
		this.Panel1.Controls.Add(this.lblPort_Selection);
		this.Panel1.Location = new System.Drawing.Point(3, 8);
		this.Panel1.Name = "Panel1";
		this.Panel1.Size = new System.Drawing.Size(287, 116);
		this.Panel1.TabIndex = 3;
		//
		//cboPort_Selection
		//
		this.cboPort_Selection.BackColor = System.Drawing.Color.AliceBlue;
		this.cboPort_Selection.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.cboPort_Selection.Location = new System.Drawing.Point(136, 82);
		this.cboPort_Selection.Name = "cboPort_Selection";
		this.cboPort_Selection.Size = new System.Drawing.Size(106, 23);
		this.cboPort_Selection.TabIndex = 1;
		//
		//lblPort_Selection
		//
		this.lblPort_Selection.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPort_Selection.Location = new System.Drawing.Point(10, 8);
		this.lblPort_Selection.Name = "lblPort_Selection";
		this.lblPort_Selection.Size = new System.Drawing.Size(274, 70);
		this.lblPort_Selection.TabIndex = 0;
		this.lblPort_Selection.Text = "Select one of the serial communication ports attached to the Autosampler";
		this.lblPort_Selection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//cmdCancel
		//
		this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdCancel.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.cmdCancel.Image = (System.Drawing.Image)resources.GetObject("cmdCancel.Image");
		this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.cmdCancel.Location = new System.Drawing.Point(216, 136);
		this.cmdCancel.Name = "cmdCancel";
		this.cmdCancel.Size = new System.Drawing.Size(70, 30);
		this.cmdCancel.TabIndex = 5;
		this.cmdCancel.Text = "E&xit";
		//
		//frmAutoSamplerComPort
		//
		this.AcceptButton = this.cmdOk;
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.ClientSize = new System.Drawing.Size(292, 167);
		this.Controls.Add(this.cmdOk);
		this.Controls.Add(this.Panel1);
		this.Controls.Add(this.cmdCancel);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmAutoSamplerComPort";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "AutoSampler Comm Port Selection";
		this.Panel1.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	private void  // ERROR: Handles clauses are not supported in C#
cmdOk_Click(System.Object sender, System.EventArgs e)
	{

		try {
			//If gstructAutoSampler.blnAutoSamplerInitialised Then
			//    If gintCommPortSelected2 = cboPort_Selection.SelectedIndex + 1 Then
			//        If gFuncIsPortOpen2() Then
			//            gFuncShowMessage("Port Already Open", "The selected port is in use, Please try with Other Ports", modConstants.EnumMessageType.Information)
			//            Exit Sub
			//        End If
			//    End If
			//End If

			//If gFuncIsPortOpen2() Then
			//    gFuncCloseComm2()
			//End If

			//gintCommPortSelected2 = cboPort_Selection.SelectedIndex + 1

			//If Not gFuncISPortAvailable(gintCommPortSelected2) Then
			//    gFuncShowMessage("Selected Communication Port Not Available ...", "Please Try Using Another Communication Port", modConstants.EnumMessageType.Information)
			//    gintCommPortSelected2 = 0
			//Else

			//    If Not gFuncOpenCommPort2(gintCommPortSelected2, gstructAutoSampler.intBaudRate, 0, 1, 8) Then
			//        gFuncShowMessage("Communication Port Busy ...", "Selected Communication Port Used By Another Program " & vbCrLf & "Please Try Using Another Communication Port", modConstants.EnumMessageType.Information)
			//        gstructAutoSampler.blnCommunication = False
			//    Else
			//        gstructAutoSampler.blnCommunication = True
			//        '--- write the port to ini 
			//        gFuncWriteToINI(SECTION_AUTOSAMPLER, KEY_SERIALPORT, CStr(gintCommPortSelected2), INI_SETTINGS_PATH)
			//    End If
			//    Call gFuncInitSampler(gstructAutoSampler)
			//    Me.Close()
			//End If 
			////----- Add by Sachi Dokhale on 14.12.05
			if (cboPort_Selection.SelectedIndex > -1) {
				////----- Commited by Sachin Dokhale on 17.12.05
				//gintCommPortSelected2 = cboPort_Selection.SelectedIndex + 1
				////-----
				////----- Added by Sachin Dokhale on 17.12.05
				gintCommPortSelected2 = gintCommPort(cboPort_Selection.SelectedIndex);
			////----- 
			} else {
				gintCommPortSelected2 = 1;
				//cboPort_Selection.SelectedIndex
			}
			gstructAutoSampler.intComPort = gintCommPortSelected2;
			gfuncWriteSamplerParametersToINI(gstructAutoSampler);

			this.Close();
			////-----

			gFuncInitSampler(gstructAutoSampler);
			this.Close();



		//added and commented by kamal on 19March2004
		//----------------------------
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gintCommPortSelected2 = 0;
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
cmdCancel_Click(System.Object sender, System.EventArgs e)
	{
		Application.DoEvents();
		gintCommPortSelected2 = 0;
		this.Close();
	}

	private void  // ERROR: Handles clauses are not supported in C#
frmAutoSamplerComPort_Load(object sender, System.EventArgs e)
	{
		int intPorts;
		int i;
		try {
			//lblPort_Selection.Text = "Select Proper RS232 Communication Port"
			// Call gfuncInitialiseGlobalValues(gstructAutoSampler)
			intPorts = gFuncGetAvailbleCommPorts();

			if (!mblnCommSelectionOnce) {
				mblnCommSelectionOnce = true;
				////----- Commited by Sachin Dokhale on 17.12.05
				//For i = 0 To intPorts - 1
				//   cboPort_Selection.Items.Insert(i, "COM" + CStr(i + 1))
				//Next
				////-----
				////----- Added by Sachin Dokhale on 17.12.05

				for (i = 0; i <= gintCommPort.GetUpperBound(0); i++) {
					cboPort_Selection.Items.Insert(i, "COM" + (string)gintCommPort(i));
				}
				////-----
			}
			gfuncReadSamplerParameterFromINI(gstructAutoSampler);
			gintCommPortSelected2 = gstructAutoSampler.intComPort;

			if (gintCommPortSelected2 > 0) {
				////----- Added by Sachin Dokhale on 17.12.05
				if (gintCommPortSelected2 > gintCommPort(gintCommPort.GetUpperBound(0))) {
					gintCommPortSelected2 = gintCommPort(gintCommPort.GetUpperBound(0));
					cboPort_Selection.SelectedIndex = gintCommPort.GetUpperBound(0);
					//gintCommPortSelected2

				} else {
					for (i = 0; i <= gintCommPort.GetUpperBound(0); i++) {
						if (gintCommPort(i) == gintCommPortSelected2) {
							cboPort_Selection.SelectedIndex = i;
							break; // TODO: might not be correct. Was : Exit For
						}

					}

				}
			////-----

			} else {
				cboPort_Selection.SelectedIndex = 0;
			}

			if (gobjCommProtocol.mobjCommdll.gFuncIsPortOpen2()) {
				gobjCommProtocol.mobjCommdll.gFuncCloseComm2();
			}
		//added and commented by kamal on 19March2004
		//----------------------------
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
frmAutoSamplerComPort_VisibleChanged(object sender, System.EventArgs e)
	{
		Application.DoEvents();
	}

	private void  // ERROR: Handles clauses are not supported in C#
frmAutoSamplerComPort_Leave(object sender, System.EventArgs e)
	{
		Application.DoEvents();
	}
}
