using AAS203.Common;
using System.IO;

public class frmParameter : System.Windows.Forms.Form
{


	//Public SpectrumParameter As Object
	#Region " Windows Form Designer generated code "

	public frmParameter()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call

	}



	public frmParameter(object RefobjParameter)
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
		SpectrumParameter = new Spectrum.EnergySpectrumParameter();
		//SpectrumParameter = New Object
		SpectrumParameter = RefobjParameter;



	}

	//Public Sub New(ByVal RefobjParameter As Spectrum.EnergySpectrumParameter)
	//    MyBase.New()

	//    'This call is required by the Windows Form Designer.
	//    InitializeComponent()

	//    'Add any initialization after the InitializeComponent() call
	//    SpectrumParameter = New Spectrum.EnergySpectrumParameter
	//    'SpectrumParameter = New Object
	//    SpectrumParameter = RefobjParameter



	//End Sub
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
	internal NETXP.Controls.XPButton btnOk;
	internal NETXP.Controls.XPButton btnCancel;
	internal GradientPanel.CustomPanel CustomPanel2;
	internal System.Windows.Forms.Label lblComments;
	internal System.Windows.Forms.TextBox txtComments;
	internal System.Windows.Forms.Label lblSampName;
	internal System.Windows.Forms.TextBox txtSampName;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmParameter));
		this.CustomPanel1 = new GradientPanel.CustomPanel();
		this.CustomPanel2 = new GradientPanel.CustomPanel();
		this.lblSampName = new System.Windows.Forms.Label();
		this.lblComments = new System.Windows.Forms.Label();
		this.txtSampName = new System.Windows.Forms.TextBox();
		this.txtComments = new System.Windows.Forms.TextBox();
		this.btnOk = new NETXP.Controls.XPButton();
		this.btnCancel = new NETXP.Controls.XPButton();
		this.CustomPanel1.SuspendLayout();
		this.CustomPanel2.SuspendLayout();
		this.SuspendLayout();
		//
		//CustomPanel1
		//
		this.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanel1.Controls.Add(this.CustomPanel2);
		this.CustomPanel1.Controls.Add(this.btnOk);
		this.CustomPanel1.Controls.Add(this.btnCancel);
		this.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanel1.Location = new System.Drawing.Point(0, 0);
		this.CustomPanel1.Name = "CustomPanel1";
		this.CustomPanel1.Size = new System.Drawing.Size(354, 183);
		this.CustomPanel1.TabIndex = 0;
		//
		//CustomPanel2
		//
		this.CustomPanel2.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanel2.Controls.Add(this.lblSampName);
		this.CustomPanel2.Controls.Add(this.lblComments);
		this.CustomPanel2.Controls.Add(this.txtSampName);
		this.CustomPanel2.Controls.Add(this.txtComments);
		this.CustomPanel2.Location = new System.Drawing.Point(8, 8);
		this.CustomPanel2.Name = "CustomPanel2";
		this.CustomPanel2.Size = new System.Drawing.Size(336, 120);
		this.CustomPanel2.TabIndex = 0;
		//
		//lblSampName
		//
		this.lblSampName.BackColor = System.Drawing.Color.AliceBlue;
		this.lblSampName.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSampName.Location = new System.Drawing.Point(16, 19);
		this.lblSampName.Name = "lblSampName";
		this.lblSampName.Size = new System.Drawing.Size(96, 16);
		this.lblSampName.TabIndex = 21;
		this.lblSampName.Text = "Sample Name";
		//
		//lblComments
		//
		this.lblComments.BackColor = System.Drawing.Color.AliceBlue;
		this.lblComments.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblComments.Location = new System.Drawing.Point(16, 55);
		this.lblComments.Name = "lblComments";
		this.lblComments.Size = new System.Drawing.Size(72, 16);
		this.lblComments.TabIndex = 22;
		this.lblComments.Text = "Comments";
		//
		//txtSampName
		//
		this.txtSampName.BackColor = System.Drawing.Color.White;
		this.txtSampName.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtSampName.Location = new System.Drawing.Point(120, 16);
		this.txtSampName.MaxLength = 20;
		this.txtSampName.Name = "txtSampName";
		this.txtSampName.Size = new System.Drawing.Size(200, 22);
		this.txtSampName.TabIndex = 0;
		this.txtSampName.Text = "";
		//
		//txtComments
		//
		this.txtComments.BackColor = System.Drawing.Color.White;
		this.txtComments.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtComments.Location = new System.Drawing.Point(120, 48);
		this.txtComments.MaxLength = 2000;
		this.txtComments.Multiline = true;
		this.txtComments.Name = "txtComments";
		this.txtComments.Size = new System.Drawing.Size(200, 64);
		this.txtComments.TabIndex = 1;
		this.txtComments.Text = "";
		//
		//btnOk
		//
		this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOk.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnOk.Image = (System.Drawing.Image)resources.GetObject("btnOk.Image");
		this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOk.Location = new System.Drawing.Point(88, 136);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(86, 34);
		this.btnOk.TabIndex = 1;
		this.btnOk.Text = "&OK";
		//
		//btnCancel
		//
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCancel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnCancel.Image = (System.Drawing.Image)resources.GetObject("btnCancel.Image");
		this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCancel.Location = new System.Drawing.Point(192, 136);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(86, 34);
		this.btnCancel.TabIndex = 2;
		this.btnCancel.Text = "&Cancel";
		//
		//frmParameter
		//
		this.AcceptButton = this.btnOk;
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.CancelButton = this.btnCancel;
		this.ClientSize = new System.Drawing.Size(354, 183);
		this.Controls.Add(this.CustomPanel1);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmParameter";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Scan Parameter";
		this.CustomPanel1.ResumeLayout(false);
		this.CustomPanel2.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Variable Declaration"
	bool mblnAvoidProcessing;
	public object SpectrumParameter;
	//Public SpectrumParameter As Spectrum.EnergySpectrumParameter
	#End Region

	#Region " Private Constant"



	#End Region

	#Region " Form Events"

	private void  // ERROR: Handles clauses are not supported in C#
frmParameter_Load(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmParameter_Load
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : load the form object
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 12.12.06
		// Revisions             : praveen
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		//'note:
		//'this is called when the form is loaded.
		try {
			funcfrmInitialise();
		//'for initialisation of form.
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

	#End Region

	#Region " Private Functions"


	private void funcfrmInitialise()
	{
		//=====================================================================
		// Procedure Name        : funcfrmInitialise
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : from Initialise 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is called during the loading of a form.


		try {
			//lblXAxisMin.Text = addataSpect.dblWvMin.ToString
			//lblXAxisMax.Text = addataSpect.dblWvMax.ToString
			//lblYAxisMin.Text = addataSpect.dblYmin.ToString
			//lblYAxisMax.Text = addataSpect.dblYMax.ToString

			//---to display sample name and comment
			txtSampName.Text = SpectrumParameter.SpectrumName;
			txtComments.Text = SpectrumParameter.Comments;
		//lblXAxis.Text = Format(SpectrumParameter.XaxisMin, "#0.0")

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
btnOk_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnOk_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : for setting a parameter
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : praveen
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		//'note:
		//'this is called when user click on OK button
		try {
			//---set sample name and comment
			funcSetParameter();
			//'for setting parameter.
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
			this.DialogResult = DialogResult.OK;
			//---------------------------------------------------------
		}
	}

	private bool funcSetParameter()
	{
		//=====================================================================
		// Procedure Name        : funcSetParameter
		// Parameters Passed     : 
		// Returns               : True/False
		// Purpose               : 
		// Description           : Set Sample Name and Comments
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 15.01.07
		// Revisions             : praveen
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();

		try {
			if (mblnAvoidProcessing == true) {
				//'check for a flag for avoiding a process
				return;
			}
			mblnAvoidProcessing = true;


			//---set sample name and comment to object
			SpectrumParameter.SpectrumName = Trim(txtSampName.Text);
			SpectrumParameter.Comments = Trim(txtComments.Text);

			//Me.Close()

			Application.DoEvents();
		//'allow application to perfrom its panding work.
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
			mblnAvoidProcessing = false;
			//---------------------------------------------------------
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
btnCancel_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnCancel_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : for handle a cancel event
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : praveen
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		//'note:
		//'this is called when user click on cancel button
		//'for handle a cancel event
		try {
			//---to cancel the dialog box
			if (mblnAvoidProcessing == true) {
				return;
			}
			//Me.Close()
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
			mblnAvoidProcessing = false;
			if (!objWait == null) {
				objWait.Dispose();
				//'destructure
			}
			Application.DoEvents();
			//'allow application to perfrom its panding work.
			//---------------------------------------------------------
		}
	}


	#End Region

}
