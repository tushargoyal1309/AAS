using AAS203.Common;
using System.IO;

public class frmChangeScale : System.Windows.Forms.Form
{

	//Public SpectrumParameter As Spectrum.UVSpectrumParameter
	public object SpectrumParameter;
		#Region "Private Variable"
	private bool mblnIsSetWv;

	bool mblnAvoidProcessing;
	#End Region

	#Region " Windows Form Designer generated code "

	public frmChangeScale()
	{
		base.New();
		mblnIsSetWv = true;

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call

	}
	public frmChangeScale(object RefobjParameter)
	{
		base.New();
		mblnIsSetWv = true;

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
		//SpectrumParameter = New Spectrum.UVSpectrumParameter
		SpectrumParameter = new object();
		SpectrumParameter = RefobjParameter;



	}

	public frmChangeScale(object RefobjParameter, bool blnIsSetWvIn)
	{
		base.New();
		mblnIsSetWv = true;
		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
		//SpectrumParameter = New Spectrum.UVSpectrumParameter
		SpectrumParameter = new object();
		SpectrumParameter = RefobjParameter;
		mblnIsSetWv = blnIsSetWvIn;

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
	internal System.Windows.Forms.Label lblXAxisMax;
	internal System.Windows.Forms.Label lblYAxisMin;
	internal System.Windows.Forms.Label lblXAxisMin;
	internal NumberValidator.NumberValidator txtYaxisMin;
	internal NumberValidator.NumberValidator txtYaxisMax;
	internal NumberValidator.NumberValidator txtXaxisMin;
	internal NumberValidator.NumberValidator txtXaxisMax;
	public System.Windows.Forms.Label lblXAxis;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmChangeScale));
		this.CustomPanel1 = new GradientPanel.CustomPanel();
		this.txtXaxisMax = new NumberValidator.NumberValidator();
		this.txtXaxisMin = new NumberValidator.NumberValidator();
		this.txtYaxisMax = new NumberValidator.NumberValidator();
		this.txtYaxisMin = new NumberValidator.NumberValidator();
		this.lblXAxis = new System.Windows.Forms.Label();
		this.lblYAxisMax = new System.Windows.Forms.Label();
		this.lblXAxisMax = new System.Windows.Forms.Label();
		this.lblYAxisMin = new System.Windows.Forms.Label();
		this.lblXAxisMin = new System.Windows.Forms.Label();
		this.btnOk = new NETXP.Controls.XPButton();
		this.btnCancel = new NETXP.Controls.XPButton();
		this.CustomPanel1.SuspendLayout();
		this.SuspendLayout();
		//
		//CustomPanel1
		//
		this.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanel1.Controls.Add(this.txtXaxisMax);
		this.CustomPanel1.Controls.Add(this.txtXaxisMin);
		this.CustomPanel1.Controls.Add(this.txtYaxisMax);
		this.CustomPanel1.Controls.Add(this.txtYaxisMin);
		this.CustomPanel1.Controls.Add(this.lblXAxis);
		this.CustomPanel1.Controls.Add(this.lblYAxisMax);
		this.CustomPanel1.Controls.Add(this.lblXAxisMax);
		this.CustomPanel1.Controls.Add(this.lblYAxisMin);
		this.CustomPanel1.Controls.Add(this.lblXAxisMin);
		this.CustomPanel1.Controls.Add(this.btnOk);
		this.CustomPanel1.Controls.Add(this.btnCancel);
		this.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanel1.Location = new System.Drawing.Point(0, 0);
		this.CustomPanel1.Name = "CustomPanel1";
		this.CustomPanel1.Size = new System.Drawing.Size(322, 175);
		this.CustomPanel1.TabIndex = 0;
		//
		//txtXaxisMax
		//
		this.txtXaxisMax.DigitsAfterDecimalPoint = 2;
		this.txtXaxisMax.ErrorColor = System.Drawing.Color.Empty;
		this.txtXaxisMax.ErrorMessage = null;
		this.txtXaxisMax.Location = new System.Drawing.Point(253, 44);
		this.txtXaxisMax.MaximumRange = 1100;
		this.txtXaxisMax.MaxLength = 4;
		this.txtXaxisMax.MinimumRange = -4;
		this.txtXaxisMax.Name = "txtXaxisMax";
		this.txtXaxisMax.RangeValidation = true;
		this.txtXaxisMax.Size = new System.Drawing.Size(56, 20);
		this.txtXaxisMax.TabIndex = 3;
		this.txtXaxisMax.Text = "";
		this.txtXaxisMax.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly;
		//
		//txtXaxisMin
		//
		this.txtXaxisMin.DigitsAfterDecimalPoint = 2;
		this.txtXaxisMin.ErrorColor = System.Drawing.Color.Empty;
		this.txtXaxisMin.ErrorMessage = null;
		this.txtXaxisMin.Location = new System.Drawing.Point(96, 44);
		this.txtXaxisMin.MaximumRange = 1100;
		this.txtXaxisMin.MaxLength = 4;
		this.txtXaxisMin.MinimumRange = -50;
		this.txtXaxisMin.Name = "txtXaxisMin";
		this.txtXaxisMin.RangeValidation = true;
		this.txtXaxisMin.Size = new System.Drawing.Size(56, 20);
		this.txtXaxisMin.TabIndex = 2;
		this.txtXaxisMin.Text = "";
		this.txtXaxisMin.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly;
		//
		//txtYaxisMax
		//
		this.txtYaxisMax.DigitsAfterDecimalPoint = 3;
		this.txtYaxisMax.ErrorColor = System.Drawing.Color.Empty;
		this.txtYaxisMax.ErrorMessage = null;
		this.txtYaxisMax.Location = new System.Drawing.Point(253, 13);
		this.txtYaxisMax.MaximumRange = 5000;
		this.txtYaxisMax.MaxLength = 4;
		this.txtYaxisMax.MinimumRange = -5000;
		this.txtYaxisMax.Name = "txtYaxisMax";
		this.txtYaxisMax.RangeValidation = true;
		this.txtYaxisMax.Size = new System.Drawing.Size(56, 20);
		this.txtYaxisMax.TabIndex = 1;
		this.txtYaxisMax.Text = "";
		this.txtYaxisMax.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly;
		//
		//txtYaxisMin
		//
		this.txtYaxisMin.DigitsAfterDecimalPoint = 3;
		this.txtYaxisMin.ErrorColor = System.Drawing.Color.Empty;
		this.txtYaxisMin.ErrorMessage = null;
		this.txtYaxisMin.Location = new System.Drawing.Point(96, 13);
		this.txtYaxisMin.MaximumRange = 5000;
		this.txtYaxisMin.MaxLength = 4;
		this.txtYaxisMin.MinimumRange = -5000;
		this.txtYaxisMin.Name = "txtYaxisMin";
		this.txtYaxisMin.RangeValidation = true;
		this.txtYaxisMin.Size = new System.Drawing.Size(56, 20);
		this.txtYaxisMin.TabIndex = 0;
		this.txtYaxisMin.Text = "";
		this.txtYaxisMin.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly;
		//
		//lblXAxis
		//
		this.lblXAxis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblXAxis.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblXAxis.ForeColor = System.Drawing.Color.MediumBlue;
		this.lblXAxis.Location = new System.Drawing.Point(16, 80);
		this.lblXAxis.Name = "lblXAxis";
		this.lblXAxis.Size = new System.Drawing.Size(296, 24);
		this.lblXAxis.TabIndex = 25;
		this.lblXAxis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblYAxisMax
		//
		this.lblYAxisMax.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblYAxisMax.Location = new System.Drawing.Point(163, 14);
		this.lblYAxisMax.Name = "lblYAxisMax";
		this.lblYAxisMax.Size = new System.Drawing.Size(85, 16);
		this.lblYAxisMax.TabIndex = 29;
		this.lblYAxisMax.Text = "Y axis Max";
		//
		//lblXAxisMax
		//
		this.lblXAxisMax.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblXAxisMax.Location = new System.Drawing.Point(163, 45);
		this.lblXAxisMax.Name = "lblXAxisMax";
		this.lblXAxisMax.Size = new System.Drawing.Size(85, 16);
		this.lblXAxisMax.TabIndex = 28;
		this.lblXAxisMax.Text = "X axis Max";
		//
		//lblYAxisMin
		//
		this.lblYAxisMin.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblYAxisMin.Location = new System.Drawing.Point(16, 14);
		this.lblYAxisMin.Name = "lblYAxisMin";
		this.lblYAxisMin.Size = new System.Drawing.Size(72, 16);
		this.lblYAxisMin.TabIndex = 27;
		this.lblYAxisMin.Text = "Y axis Min";
		//
		//lblXAxisMin
		//
		this.lblXAxisMin.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblXAxisMin.Location = new System.Drawing.Point(16, 45);
		this.lblXAxisMin.Name = "lblXAxisMin";
		this.lblXAxisMin.Size = new System.Drawing.Size(72, 16);
		this.lblXAxisMin.TabIndex = 26;
		this.lblXAxisMin.Text = "X axis Min";
		//
		//btnOk
		//
		this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOk.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnOk.Image = (System.Drawing.Image)resources.GetObject("btnOk.Image");
		this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOk.Location = new System.Drawing.Point(56, 120);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(86, 34);
		this.btnOk.TabIndex = 4;
		this.btnOk.Text = "&OK";
		//
		//btnCancel
		//
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCancel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnCancel.Image = (System.Drawing.Image)resources.GetObject("btnCancel.Image");
		this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCancel.Location = new System.Drawing.Point(183, 120);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(86, 34);
		this.btnCancel.TabIndex = 5;
		this.btnCancel.Text = "&Cancel";
		//
		//frmChangeScale
		//
		this.AcceptButton = this.btnOk;
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.CancelButton = this.btnCancel;
		this.ClientSize = new System.Drawing.Size(322, 175);
		this.Controls.Add(this.CustomPanel1);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmChangeScale";
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
		//'this is used to initialise a change scale form
		//'do some validation here.

		try {
			//lblXAxisMin.Text = addataSpect.dblWvMin.ToString
			//lblXAxisMax.Text = addataSpect.dblWvMax.ToString
			//lblYAxisMin.Text = addataSpect.dblYmin.ToString
			//lblYAxisMax.Text = addataSpect.dblYMax.ToString
			if (mblnIsSetWv == false) {
				//'check for wavwlwngth flag 
				lblXAxis.Visible = false;
			} else {
				lblXAxis.Visible = true;
			}

			//Added By Pankaj 11 May 07 11 
			if ((lblXAxis.Visible == true)) {
				if (mblnIsSetWv == true) {
					//'format the input display
					txtXaxisMin.Text = Format(gobjInst.WavelengthCur, "0.0");
					//Format(SpectrumParameter.XaxisMin, "0.0")
					if ((SpectrumParameter.XaxisMax < (gobjInst.WavelengthCur + 10))) {
						txtXaxisMax.Text = Format((gobjInst.WavelengthCur + 10), "0.0");
					} else {
						txtXaxisMax.Text = Format(SpectrumParameter.XaxisMax, "0.0");
					}

					txtYaxisMin.Text = Format(SpectrumParameter.YaxisMin, "0.000");
					txtYaxisMax.Text = Format(SpectrumParameter.YaxisMax, "0.000");
					lblXAxis.Text = Format(SpectrumParameter.XaxisMin, "#0.0");
				} else {
					txtXaxisMax.Text = Format(SpectrumParameter.XaxisMax, "0.0");
					txtYaxisMin.Text = Format(SpectrumParameter.YaxisMin, "0.000");
					txtYaxisMax.Text = Format(SpectrumParameter.YaxisMax, "0.000");
					lblXAxis.Text = Format(SpectrumParameter.XaxisMin, "#0.0");
				}
			//Added by Pankaj 11 May 07 for setting default Settings for Analysis and DataFiles form
			} else {
				//Added By Pankaj Mon 21 May 07
				if ((lblXAxis.Visible == false)) {
					txtXaxisMin.MinimumRange = 0;
				}
				//---27.03.09
				//txtXaxisMin.Text = Format(SpectrumParameter.XaxisMin, "0.000")
				//txtXaxisMax.Text = Format(SpectrumParameter.XaxisMax, "0.000")

				//---27.03.09
				txtXaxisMin.Text = Format(SpectrumParameter.XaxisMin, "0.000");
				txtXaxisMax.Text = Format(SpectrumParameter.XaxisMax, "0.000");

				txtYaxisMin.Text = Format(SpectrumParameter.YaxisMin, "0.000");
				txtYaxisMax.Text = Format(SpectrumParameter.YaxisMax, "0.000");
			}
			//txtYaxisMax.DigitsAfterDecimalPoint = 2
			//txtYaxisMax.MaxLength = 6

			//'below set some validation rule.

			txtYaxisMax.RangeValidation = true;
			txtYaxisMax.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly;

			txtYaxisMin.RangeValidation = true;
			txtYaxisMin.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly;

			txtXaxisMax.RangeValidation = true;
			txtXaxisMax.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly;

			txtXaxisMin.RangeValidation = true;
			txtXaxisMin.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly;

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
		CWaitCursor objWait = new CWaitCursor();

		try {
			if (funcSetScale() == true) {
				//'function for setting a scale.
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
		double dblWvMin;
		double dblWvMax;
		try {
			if (mblnAvoidProcessing == true) {
				return false;
			}
			mblnAvoidProcessing = true;
			Application.DoEvents();

			//----- Condition added by pankaj on 10 May 07
			if (lblXAxis.Visible == true) {
				//'Added by praveen for null scale value

				if (((txtXaxisMin.Text) == "")) {
					txtXaxisMin.Text = 0;
				}

				if (((txtXaxisMax.Text) == "")) {
					txtXaxisMax.Text = 0;
				}
				//'ended by praveen

				//---27.03.09
				//dblWvMin = Format(CDbl(txtXaxisMin.Text), "0.0")
				//dblWvMax = Format(CDbl(txtXaxisMax.Text), "0.0")

				//---27.03.09
				dblWvMin = Format((double)txtXaxisMin.Text, "0.000");
				dblWvMax = Format((double)txtXaxisMax.Text, "0.000");

				if (mblnIsSetWv == true) {
					if (dblWvMin >= dblWvMax) {
						gobjMessageAdapter.ShowMessage(constWLMAXlessthanWLMIN);
						//gFuncShowMessage("Maximum wavelenth is less then minimum wavelength", Me.Text, modGlobalConstants.EnumMessageType.Information)
						return false;
					}
					Application.DoEvents();
					//---position wavelength drive to given value

					//---16.03.08
					if (gblnIsDemoWithRealData == false) {
						if (gobjCommProtocol.Wavelength_Position(dblWvMin, lblXAxis) == true) {
							gobjCommProtocol.mobjCommdll.subTime_Delay(100);
							//'delay
							Application.DoEvents();
							//'allow application to perfrom its panding work.
						}
					}

				} else {
					if (dblWvMin >= dblWvMax) {
						//gobjMessageAdapter.ShowMessage("X axis value should be minimum " & txtXaxisMax.MinimumRange & " to maximum " & txtXaxisMax.MaximumRange & "  range.", "X axis", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
						gobjMessageAdapter.ShowMessage("Maximum value is less than or equal to minimum value", "X axis", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage);
						//gFuncShowMessage("Maximum wavelenth is less then minimum wavelength", Me.Text, modGlobalConstants.EnumMessageType.Information)
						return false;
					}
				}
			} else {
				//Saurabh Commented for showing -ive values
				//Added By Pankaj Mon 21 May 07
				//If ((txtXaxisMin.Text) = "") Then
				//    txtXaxisMin.Text = 0
				//End If
				//Saurabh Commented for showing -ive values

			}
			//------------Added By Pankaj on 29 May 07
			//'Added by praveen for null scale value


			if (((txtYaxisMin.Text) == "")) {
				txtYaxisMin.Text = 0;
			}

			if (((txtYaxisMax.Text) == "")) {
				txtYaxisMax.Text = 0;
			}

			//'ended by praveen

			//---27.03.09
			//dblWvMin = Format(CDbl(txtYaxisMin.Text), "0.0")
			//dblWvMax = Format(CDbl(txtYaxisMax.Text), "0.0")

			//---27.03.09
			dblWvMin = Format((double)txtYaxisMin.Text, "0.000");
			dblWvMax = Format((double)txtYaxisMax.Text, "0.000");

			if (mblnIsSetWv == true) {
				if (dblWvMin >= dblWvMax) {
					gobjMessageAdapter.ShowMessage(constWLMAXlessthanWLMIN);
					//gFuncShowMessage("Maximum wavelenth is less then minimum wavelength", Me.Text, modGlobalConstants.EnumMessageType.Information)
					return false;
				}
			} else {
				if (dblWvMin >= dblWvMax) {
					//gobjMessageAdapter.ShowMessage("Y axis should be minimum " & txtXaxisMax.MinimumRange & " to maximum " & txtXaxisMax.MaximumRange & "  range.", "X axis", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
					gobjMessageAdapter.ShowMessage("Maximum value is less than or equal to minimum value", "Y axis", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage);
					//gFuncShowMessage("Maximum wavelenth is less then minimum wavelength", Me.Text, modGlobalConstants.EnumMessageType.Information)
					return false;
				}
			}
			//--------------
			//'Added by praveen for validate X-Axis on 15.08.07

			if (((txtXaxisMin.Text) == "")) {
				txtXaxisMin.Text = 0;
			}

			if (((txtXaxisMax.Text) == "")) {
				txtXaxisMax.Text = 0;
			}

			//---27.03.09
			//dblWvMin = Format(CDbl(txtXaxisMin.Text), "0.0")
			//dblWvMax = Format(CDbl(txtXaxisMax.Text), "0.0")
			//----

			//---27.03.09
			dblWvMin = Format((double)txtXaxisMin.Text, "0.000");
			dblWvMax = Format((double)txtXaxisMax.Text, "0.000");
			//----

			if (dblWvMin >= dblWvMax) {
				// gobjMessageAdapter.ShowMessage("x axis should be minimum " & txtXaxisMax.MinimumRange & " to maximum " & txtXaxisMax.MaximumRange & "  range.", "X axis", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
				gobjMessageAdapter.ShowMessage("Maximum value is less than or equal to minimum value", "X axis", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage);
				//gFuncShowMessage("Maximum wavelenth is less then minimum wavelength", Me.Text, modGlobalConstants.EnumMessageType.Information)
				return false;
			}

			//'ended by praveen
			SpectrumParameter.XaxisMin = (double)txtXaxisMin.Text;
			SpectrumParameter.XaxisMax = (double)txtXaxisMax.Text;
			SpectrumParameter.YaxisMin = (double)txtYaxisMin.Text;
			SpectrumParameter.YaxisMax = (double)txtYaxisMax.Text;
			Application.DoEvents();
			this.Close();
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
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();

		try {
			if (mblnAvoidProcessing == true) {
				//'check for flag to avoid a process.
				return;
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
		//'note:
		//'this is called when change scale form is loaded.

		try {
			funcfrmInitialise();
		//'function for initialisation
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
		//'this is used for setting a validation scale as per
		//'given calibration mode.
		int intMaxLength = 7;
		int intMinimumRangeX;
		int intMaximumRangeX;
		int intMinimumRangeY;
		int intMaximumRangeY;
		int intPlaceDecimalPoint = 1;

		intMinimumRangeX = -4;
		//Added By Pankaj Mon 21 May 07
		if ((lblXAxis.Visible == false)) {
			intMinimumRangeX = 0;
		}
		intMaximumRangeX = 1100;
		switch (ValMode) {
			//'set a validation as per calibration mode.
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
		txtXaxisMax.MaxLength = 6;
		txtXaxisMax.MinimumRange = intMinimumRangeX;
		txtXaxisMax.MaximumRange = intMaximumRangeX;
		txtXaxisMax.DigitsAfterDecimalPoint = 1;

		txtXaxisMin.MaxLength = 6;
		txtXaxisMin.MinimumRange = intMinimumRangeX;
		txtXaxisMin.MaximumRange = intMaximumRangeX;
		txtXaxisMin.DigitsAfterDecimalPoint = 1;
		//'this will set a digits after a decimal.
		txtYaxisMax.MaxLength = intMaxLength;
		//txtYaxisMax.MinimumRange = intMinimumRangeY
		//txtYaxisMax.MaximumRange = MaximumRangeY
		txtYaxisMax.DigitsAfterDecimalPoint = intPlaceDecimalPoint;

		txtYaxisMin.MaxLength = intMaxLength;
		//txtYaxisMin.MinimumRange = intMinimumRangeY
		//txtYaxisMin.MaximumRange = MaximumRangeY
		txtYaxisMin.DigitsAfterDecimalPoint = intPlaceDecimalPoint;

	}

}
