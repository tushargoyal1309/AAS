using AAS203.Common;
using System.IO;

//class behind the class
public class frmBHParameter : System.Windows.Forms.Form
{

	public double BHStartScan;

	public double BHEndScan;
	#Region "Private Variable"
	bool mblnAvoidProcessing;
	//'bool flag 

	#End Region

	#Region " Windows Form Designer generated code "

	public frmBHParameter()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call

	}
	public frmBHParameter(object RefobjParameter)
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
		//SpectrumParameter = New Spectrum.UVSpectrumParameter

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
	internal System.Windows.Forms.Label lblBHEnd;
	internal System.Windows.Forms.Label lblBHStart;
	internal NumberValidator.NumberValidator txtBHStart;
	internal NumberValidator.NumberValidator txtBHEnd;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmBHParameter));
		this.CustomPanel1 = new GradientPanel.CustomPanel();
		this.txtBHEnd = new NumberValidator.NumberValidator();
		this.txtBHStart = new NumberValidator.NumberValidator();
		this.btnOk = new NETXP.Controls.XPButton();
		this.btnCancel = new NETXP.Controls.XPButton();
		this.lblBHEnd = new System.Windows.Forms.Label();
		this.lblBHStart = new System.Windows.Forms.Label();
		this.CustomPanel1.SuspendLayout();
		this.SuspendLayout();
		//
		//CustomPanel1
		//
		this.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanel1.Controls.Add(this.txtBHEnd);
		this.CustomPanel1.Controls.Add(this.txtBHStart);
		this.CustomPanel1.Controls.Add(this.btnOk);
		this.CustomPanel1.Controls.Add(this.btnCancel);
		this.CustomPanel1.Controls.Add(this.lblBHEnd);
		this.CustomPanel1.Controls.Add(this.lblBHStart);
		this.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanel1.Location = new System.Drawing.Point(0, 0);
		this.CustomPanel1.Name = "CustomPanel1";
		this.CustomPanel1.Size = new System.Drawing.Size(306, 151);
		this.CustomPanel1.TabIndex = 0;
		//
		//txtBHEnd
		//
		this.txtBHEnd.DigitsAfterDecimalPoint = 0;
		this.txtBHEnd.ErrorColor = System.Drawing.Color.Empty;
		this.txtBHEnd.ErrorMessage = null;
		this.txtBHEnd.Location = new System.Drawing.Point(232, 51);
		this.txtBHEnd.MaximumRange = 6;
		this.txtBHEnd.MaxLength = 4;
		this.txtBHEnd.MinimumRange = 0;
		this.txtBHEnd.Name = "txtBHEnd";
		this.txtBHEnd.RangeValidation = false;
		this.txtBHEnd.Size = new System.Drawing.Size(56, 20);
		this.txtBHEnd.TabIndex = 18;
		this.txtBHEnd.Text = "";
		this.txtBHEnd.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly;
		//
		//txtBHStart
		//
		this.txtBHStart.DigitsAfterDecimalPoint = 0;
		this.txtBHStart.ErrorColor = System.Drawing.Color.Empty;
		this.txtBHStart.ErrorMessage = null;
		this.txtBHStart.Location = new System.Drawing.Point(232, 16);
		this.txtBHStart.MaximumRange = 0;
		this.txtBHStart.MinimumRange = 0;
		this.txtBHStart.Name = "txtBHStart";
		this.txtBHStart.RangeValidation = false;
		this.txtBHStart.Size = new System.Drawing.Size(56, 20);
		this.txtBHStart.TabIndex = 17;
		this.txtBHStart.Text = "";
		this.txtBHStart.ValidationType = NumberValidator.NumberValidator.Validations.AlphaNumeric;
		//
		//btnOk
		//
		this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOk.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnOk.Image = (System.Drawing.Image)resources.GetObject("btnOk.Image");
		this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOk.Location = new System.Drawing.Point(64, 96);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(86, 34);
		this.btnOk.TabIndex = 15;
		this.btnOk.Text = "&OK";
		//
		//btnCancel
		//
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCancel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnCancel.Image = (System.Drawing.Image)resources.GetObject("btnCancel.Image");
		this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCancel.Location = new System.Drawing.Point(168, 96);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(86, 34);
		this.btnCancel.TabIndex = 16;
		this.btnCancel.Text = "&Cancel";
		//
		//lblBHEnd
		//
		this.lblBHEnd.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblBHEnd.Location = new System.Drawing.Point(13, 51);
		this.lblBHEnd.Name = "lblBHEnd";
		this.lblBHEnd.Size = new System.Drawing.Size(219, 16);
		this.lblBHEnd.TabIndex = 1;
		this.lblBHEnd.Text = "Burner Height Scan End (0 - 6 mm)";
		//
		//lblBHStart
		//
		this.lblBHStart.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblBHStart.Location = new System.Drawing.Point(13, 19);
		this.lblBHStart.Name = "lblBHStart";
		this.lblBHStart.Size = new System.Drawing.Size(219, 16);
		this.lblBHStart.TabIndex = 0;
		this.lblBHStart.Text = "Burner Height Scan Start (0 - 6 mm)";
		//
		//frmBHParameter
		//
		this.AcceptButton = this.btnOk;
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.CancelButton = this.btnCancel;
		this.ClientSize = new System.Drawing.Size(306, 151);
		this.Controls.Add(this.CustomPanel1);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmBHParameter";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Change Scale";
		this.CustomPanel1.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region


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
		//'this is called when form is loaded .
		//'do some initialisation over here.

		try {

			if (gintOptimisation == modGlobalDeclarations.EnumBH_FP_Opimisation.BurnerHeight) {
				//'check for burner optimization flag.
				//'if yes then set some validation here.
				lblBHStart.Text = "Burner Height Scan Start (0 - 6 mm)";
				lblBHEnd.Text = "Burner Height Scan End (0 - 6 mm)";
				txtBHStart.MaximumRange = 6.0;
				txtBHStart.MinimumRange = 0.0;
				txtBHEnd.MaximumRange = 6.0;
				txtBHEnd.MinimumRange = 0.0;

			} else if (gintOptimisation == modGlobalDeclarations.EnumBH_FP_Opimisation.FuelPresure) {
				//'check for fuel presure
				//'and set a validation.
				lblBHStart.Text = "Fuel Scan Start (Low Fuel)";
				lblBHEnd.Text = "Fuel Scan End (High Fuel)";
				txtBHStart.MaximumRange = 5.0;
				txtBHStart.MinimumRange = 1.0;
				txtBHEnd.MaximumRange = 5.0;
				txtBHEnd.MinimumRange = 0.0;
			}
			txtBHStart.DigitsAfterDecimalPoint = 2;
			txtBHStart.RangeValidation = true;
			txtBHStart.MaxLength = 6;
			txtBHStart.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly;

			txtBHEnd.DigitsAfterDecimalPoint = 2;
			txtBHEnd.RangeValidation = true;
			txtBHEnd.MaxLength = 6;
			txtBHEnd.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly;

			txtBHStart.Text = Format(BHStartScan, "0.0");
			txtBHEnd.Text = Format(BHEndScan, "0.0");

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
		// Description           : Set X & Y Axis
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is called when user click on ok button
		//'this is used to set a scale.
		CWaitCursor objWait = new CWaitCursor();

		try {
			if (funcSetScale() == true) {
				//'bool function for setting a scale.
				this.DialogResult = DialogResult.OK;
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

	private bool funcSetScale()
	{
		//=====================================================================
		// Procedure Name        : funcSetScale
		// Parameters Passed     : 
		// Returns               : True/False
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 31.12.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is called when user clicked on ok button for setting a scale .
		//'this will first check a validation of input value.
		//'the set it to data structure
		CWaitCursor objWait = new CWaitCursor();
		double dblWvMin;
		double dblWvMax;
		try {
			if (mblnAvoidProcessing == true) {
				//'check flag for avoiding a process
				return;
			}
			mblnAvoidProcessing = true;
			Application.DoEvents();
			//'allow application to perfrom it panding work.

			//BHStartScan = CDbl(txtBHStart.Text)
			//BHEndScan = CDbl(txtBHEnd.Text)
			if ((double)txtBHStart.Text > (double)txtBHEnd.Text) {
				//'check for min\max range
				gobjMessageAdapter.ShowMessage(constValueMinToMax);
				return false;
			}
			//'Added by praveen Bcoz timescan mode is hanged if both value's are same
			if ((double)txtBHStart.Text == (double)txtBHEnd.Text) {
				//'check for same range
				gobjMessageAdapter.ShowMessage(constValueMinToMax);
				return false;
			}
			//'Ended by praveen
			//--- Check for Min and max range of start position 
			if (txtBHStart.MinimumRange <= (double)txtBHStart.Text & txtBHStart.MaximumRange >= (double)txtBHStart.Text) {
				BHStartScan = (double)txtBHStart.Text;
			} else {
				gobjMessageAdapter.ShowMessage(constInvalidRange);
				return false;
			}
			//--- Check for Min and max range of end position 
			if (txtBHEnd.MaximumRange >= (double)txtBHEnd.Text & txtBHEnd.MinimumRange <= (double)txtBHEnd.Text) {
				BHEndScan = (double)txtBHEnd.Text;
			} else {
				gobjMessageAdapter.ShowMessage(constInvalidRange);
				return false;
			}

			this.Close();
			return true;
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
		// Description           : Set X & Y Axis
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is called when user click on cancel button
		CWaitCursor objWait = new CWaitCursor();

		try {
			if (mblnAvoidProcessing == true) {
				//'check a flag for avoiding a process.
				return;
			}

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
			mblnAvoidProcessing = false;
			if (!objWait == null) {
				objWait.Dispose();
			}

			//---------------------------------------------------------
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
frmChangeScale_Load(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmChangeScale_Load
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
		//'note;
		//'this is called when change scale form is loaded.
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
				//'destructor.
			}

			//---------------------------------------------------------
		}
	}

}
