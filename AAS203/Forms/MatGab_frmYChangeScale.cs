using AAS203.Common;
using System.IO;

public class frmYChangeScale : System.Windows.Forms.Form
{

	#Region "Public Variables"
		#End Region
	public object SpectrumParameter;

	#Region "Private Variable"
		#End Region
	bool mblnAvoidProcessing;

	#Region " Windows Form Designer generated code "

	public frmYChangeScale()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call

	}

	public frmYChangeScale(object RefobjParameter)
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
		//SpectrumParameter = New Spectrum.UVSpectrumParameter
		SpectrumParameter = new object();
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
	internal System.Windows.Forms.Label lblYAxisMax;
	internal System.Windows.Forms.Label lblYAxisMin;
	internal NumberValidator.NumberValidator txtYaxisMax;
	internal NumberValidator.NumberValidator txtYaxisMin;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmYChangeScale));
		this.CustomPanel1 = new GradientPanel.CustomPanel();
		this.txtYaxisMin = new NumberValidator.NumberValidator();
		this.txtYaxisMax = new NumberValidator.NumberValidator();
		this.lblYAxisMax = new System.Windows.Forms.Label();
		this.lblYAxisMin = new System.Windows.Forms.Label();
		this.btnOk = new NETXP.Controls.XPButton();
		this.btnCancel = new NETXP.Controls.XPButton();
		this.CustomPanel1.SuspendLayout();
		this.SuspendLayout();
		//
		//CustomPanel1
		//
		this.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanel1.Controls.Add(this.txtYaxisMin);
		this.CustomPanel1.Controls.Add(this.txtYaxisMax);
		this.CustomPanel1.Controls.Add(this.lblYAxisMax);
		this.CustomPanel1.Controls.Add(this.lblYAxisMin);
		this.CustomPanel1.Controls.Add(this.btnOk);
		this.CustomPanel1.Controls.Add(this.btnCancel);
		this.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanel1.Location = new System.Drawing.Point(0, 0);
		this.CustomPanel1.Name = "CustomPanel1";
		this.CustomPanel1.Size = new System.Drawing.Size(322, 111);
		this.CustomPanel1.TabIndex = 0;
		//
		//txtYaxisMin
		//
		this.txtYaxisMin.DigitsAfterDecimalPoint = 3;
		this.txtYaxisMin.ErrorColor = System.Drawing.Color.Empty;
		this.txtYaxisMin.ErrorMessage = null;
		this.txtYaxisMin.Location = new System.Drawing.Point(96, 16);
		this.txtYaxisMin.MaximumRange = 5000;
		this.txtYaxisMin.MaxLength = 10;
		this.txtYaxisMin.MinimumRange = -5000;
		this.txtYaxisMin.Name = "txtYaxisMin";
		this.txtYaxisMin.RangeValidation = true;
		this.txtYaxisMin.Size = new System.Drawing.Size(56, 20);
		this.txtYaxisMin.TabIndex = 1;
		this.txtYaxisMin.Text = "";
		this.txtYaxisMin.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly;
		//
		//txtYaxisMax
		//
		this.txtYaxisMax.DigitsAfterDecimalPoint = 0;
		this.txtYaxisMax.ErrorColor = System.Drawing.Color.Empty;
		this.txtYaxisMax.ErrorMessage = null;
		this.txtYaxisMax.Location = new System.Drawing.Point(256, 16);
		this.txtYaxisMax.MaximumRange = 5000;
		this.txtYaxisMax.MinimumRange = -5000;
		this.txtYaxisMax.Name = "txtYaxisMax";
		this.txtYaxisMax.RangeValidation = true;
		this.txtYaxisMax.Size = new System.Drawing.Size(56, 20);
		this.txtYaxisMax.TabIndex = 2;
		this.txtYaxisMax.Text = "";
		this.txtYaxisMax.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly;
		//
		//lblYAxisMax
		//
		this.lblYAxisMax.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblYAxisMax.Location = new System.Drawing.Point(168, 16);
		this.lblYAxisMax.Name = "lblYAxisMax";
		this.lblYAxisMax.Size = new System.Drawing.Size(85, 16);
		this.lblYAxisMax.TabIndex = 29;
		this.lblYAxisMax.Text = "Y axis Max";
		//
		//lblYAxisMin
		//
		this.lblYAxisMin.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblYAxisMin.Location = new System.Drawing.Point(16, 16);
		this.lblYAxisMin.Name = "lblYAxisMin";
		this.lblYAxisMin.Size = new System.Drawing.Size(72, 16);
		this.lblYAxisMin.TabIndex = 27;
		this.lblYAxisMin.Text = "Y axis Min";
		//
		//btnOk
		//
		this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOk.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnOk.Image = (System.Drawing.Image)resources.GetObject("btnOk.Image");
		this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOk.Location = new System.Drawing.Point(56, 56);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(86, 34);
		this.btnOk.TabIndex = 3;
		this.btnOk.Text = "&OK";
		//
		//btnCancel
		//
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCancel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnCancel.Image = (System.Drawing.Image)resources.GetObject("btnCancel.Image");
		this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCancel.Location = new System.Drawing.Point(184, 56);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(86, 34);
		this.btnCancel.TabIndex = 4;
		this.btnCancel.Text = "&Cancel";
		this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//frmYChangeScale
		//
		this.AcceptButton = this.btnOk;
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.CancelButton = this.btnCancel;
		this.ClientSize = new System.Drawing.Size(322, 111);
		this.Controls.Add(this.CustomPanel1);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmYChangeScale";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Change Scale";
		this.CustomPanel1.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region "Private Functions"

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
		// Revisions             : 
		//=====================================================================

		//'note;
		//'this is used to take some initialization of form.
		//'for eg set a validation of textbox.
		//'set onscreen arrengment etc.

		try {
			txtYaxisMax.RangeValidation = true;
			txtYaxisMax.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly;

			txtYaxisMin.RangeValidation = true;
			txtYaxisMin.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly;
			//'format the text player.
			txtYaxisMin.Text = Format(SpectrumParameter.YaxisMin, "0.000");
			txtYaxisMax.Text = Format(SpectrumParameter.YaxisMax, "0.000");

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
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is called when user click on OK button.
		//'this will set sxale set by user to data structure.
		//'which will being later used.

		CWaitCursor objWait = new CWaitCursor();

		try {
			if (funcSetScale() == true) {
				//'function for setting scale.
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
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : Set X & Y Axis
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			if (mblnAvoidProcessing == true) {
				//'check a flag for avoiding a process
				return;
			}
			mblnAvoidProcessing = true;
			Application.DoEvents();
			//'allow application to perfrom its panding work.

			if ((txtYaxisMax.Text.Trim() == "")) {
				txtYaxisMax.Text = "0";
				//'set scale to zero if user has't enter anything.
			}
			if ((txtYaxisMin.Text.Trim() == "")) {
				txtYaxisMin.Text = "0";
			}
			if ((double)txtYaxisMin.Text >= (double)txtYaxisMax.Text) {
				//'min value should be less then max value.
				gobjMessageAdapter.ShowMessage(constValueMinToMax);
				return false;
			}

			if (txtYaxisMin.MinimumRange <= (double)txtYaxisMin.Text & txtYaxisMin.MaximumRange >= (double)txtYaxisMin.Text) {
				SpectrumParameter.YaxisMin = (double)txtYaxisMin.Text;
			} else {
				gobjMessageAdapter.ShowMessage(constInvalidRange);
				return false;
			}
			if (txtYaxisMax.MaximumRange >= (double)txtYaxisMax.Text & txtYaxisMax.MinimumRange <= (double)txtYaxisMax.Text) {
				SpectrumParameter.YaxisMax = (double)txtYaxisMax.Text;
				funcSetScale = true;
			} else {
				gobjMessageAdapter.ShowMessage(constInvalidRange);
				//'show the error mess.
				return false;
			}
			this.Close();
			//'close the form after setting a scale.
			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
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
		//'this is called when user click on cancel button.
		CWaitCursor objWait = new CWaitCursor();

		try {
			if (mblnAvoidProcessing == true) {
				return;
			}
			this.Close();
		//'close the form.
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
		//'note:
		//'this is called when the form is loaded 
		//'this will call initialization function.
		CWaitCursor objWait = new CWaitCursor();

		try {
			funcfrmInitialise();
		//'function for initialise
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

	internal void funcSetValidatingScale(EnumCalibrationMode ValMode)
	{
		//=====================================================================
		// Procedure Name        : funcSetValidatingScale
		// Parameters Passed     : ValMode
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 12.12.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this will used to set a validation of scale.
		//'this is set as par the mode of operation.
		int intMaxLength = 7;
		int intMinimumRangeY;
		int intMaximumRangeY;
		int intPlaceDecimalPoint = 1;
		try {
			switch (ValMode) {
				//set a validation as per mode.
				case modGlobalConstants.EnumCalibrationMode.AA:
				case modGlobalConstants.EnumCalibrationMode.AABGC:
				case modGlobalConstants.EnumCalibrationMode.AABGCSR:
				case modGlobalConstants.EnumCalibrationMode.MABS:
					intPlaceDecimalPoint = 3;
				case modGlobalConstants.EnumCalibrationMode.D2E:
				case modGlobalConstants.EnumCalibrationMode.EMISSION:
				case modGlobalConstants.EnumCalibrationMode.HCLE:
					intPlaceDecimalPoint = 1;
				case modGlobalConstants.EnumCalibrationMode.SELFTEST:
					intPlaceDecimalPoint = 0;
			}

			txtYaxisMax.MaxLength = intMaxLength;
			txtYaxisMax.DigitsAfterDecimalPoint = intPlaceDecimalPoint;

			txtYaxisMin.MaxLength = intMaxLength;
			txtYaxisMin.DigitsAfterDecimalPoint = intPlaceDecimalPoint;

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
