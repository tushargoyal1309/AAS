using AAS203.Common;
using AAS203Library.Method;

public class frmUVQuantitativeAnalysis : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmUVQuantitativeAnalysis()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call

	}

	public frmUVQuantitativeAnalysis(int intMethodMode)
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
		OpenMethodMode = intMethodMode;

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
	internal System.Windows.Forms.Label lblUVQuantitativeAnalysis;
	internal System.Windows.Forms.GroupBox gbWorkingConditions;
	internal System.Windows.Forms.Label lblWavelength;
	internal System.Windows.Forms.Label Label1;
	internal NETXP.Controls.XPButton btnHelp;
	internal NETXP.Controls.XPButton btnOk;
	internal NETXP.Controls.XPButton btnCancel;
	internal NETXP.Controls.XPButton btnD2Peak;
	internal CodeIntellects.Office2003Controls.Office2003Header Office2003Header1;
	internal NumberValidator.NumberValidator txtWavelength;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmUVQuantitativeAnalysis));
		this.CustomPanel1 = new GradientPanel.CustomPanel();
		this.Office2003Header1 = new CodeIntellects.Office2003Controls.Office2003Header();
		this.btnD2Peak = new NETXP.Controls.XPButton();
		this.btnHelp = new NETXP.Controls.XPButton();
		this.btnOk = new NETXP.Controls.XPButton();
		this.btnCancel = new NETXP.Controls.XPButton();
		this.gbWorkingConditions = new System.Windows.Forms.GroupBox();
		this.txtWavelength = new NumberValidator.NumberValidator();
		this.Label1 = new System.Windows.Forms.Label();
		this.lblWavelength = new System.Windows.Forms.Label();
		this.lblUVQuantitativeAnalysis = new System.Windows.Forms.Label();
		this.CustomPanel1.SuspendLayout();
		this.gbWorkingConditions.SuspendLayout();
		this.SuspendLayout();
		//
		//CustomPanel1
		//
		this.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanel1.Controls.Add(this.Office2003Header1);
		this.CustomPanel1.Controls.Add(this.btnD2Peak);
		this.CustomPanel1.Controls.Add(this.btnHelp);
		this.CustomPanel1.Controls.Add(this.btnOk);
		this.CustomPanel1.Controls.Add(this.btnCancel);
		this.CustomPanel1.Controls.Add(this.gbWorkingConditions);
		this.CustomPanel1.Controls.Add(this.lblUVQuantitativeAnalysis);
		this.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanel1.Location = new System.Drawing.Point(0, 0);
		this.CustomPanel1.Name = "CustomPanel1";
		this.CustomPanel1.Size = new System.Drawing.Size(434, 199);
		this.CustomPanel1.TabIndex = 0;
		//
		//Office2003Header1
		//
		this.Office2003Header1.BackColor = System.Drawing.SystemColors.Control;
		this.Office2003Header1.Dock = System.Windows.Forms.DockStyle.Top;
		this.Office2003Header1.Location = new System.Drawing.Point(0, 0);
		this.Office2003Header1.Name = "Office2003Header1";
		this.Office2003Header1.Size = new System.Drawing.Size(434, 22);
		this.Office2003Header1.TabIndex = 21;
		this.Office2003Header1.TitleFont = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Office2003Header1.TitleText = "Quantitative Instrument Conditions - Molecular ABS Mode";
		//
		//btnD2Peak
		//
		this.btnD2Peak.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnD2Peak.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnD2Peak.Image = (System.Drawing.Image)resources.GetObject("btnD2Peak.Image");
		this.btnD2Peak.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnD2Peak.Location = new System.Drawing.Point(320, 137);
		this.btnD2Peak.Name = "btnD2Peak";
		this.btnD2Peak.Size = new System.Drawing.Size(86, 38);
		this.btnD2Peak.TabIndex = 4;
		this.btnD2Peak.Text = "D2 Peaks";
		this.btnD2Peak.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnHelp
		//
		this.btnHelp.Enabled = false;
		this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnHelp.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnHelp.Image = (System.Drawing.Image)resources.GetObject("btnHelp.Image");
		this.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnHelp.Location = new System.Drawing.Point(224, 137);
		this.btnHelp.Name = "btnHelp";
		this.btnHelp.Size = new System.Drawing.Size(86, 38);
		this.btnHelp.TabIndex = 3;
		this.btnHelp.Text = "Help";
		//
		//btnOk
		//
		this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOk.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnOk.Image = (System.Drawing.Image)resources.GetObject("btnOk.Image");
		this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOk.Location = new System.Drawing.Point(30, 137);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(86, 38);
		this.btnOk.TabIndex = 1;
		this.btnOk.Text = "OK";
		//
		//btnCancel
		//
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCancel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnCancel.Image = (System.Drawing.Image)resources.GetObject("btnCancel.Image");
		this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCancel.Location = new System.Drawing.Point(128, 137);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(86, 38);
		this.btnCancel.TabIndex = 2;
		this.btnCancel.Text = "Cancel";
		//
		//gbWorkingConditions
		//
		this.gbWorkingConditions.Controls.Add(this.txtWavelength);
		this.gbWorkingConditions.Controls.Add(this.Label1);
		this.gbWorkingConditions.Controls.Add(this.lblWavelength);
		this.gbWorkingConditions.Location = new System.Drawing.Point(40, 77);
		this.gbWorkingConditions.Name = "gbWorkingConditions";
		this.gbWorkingConditions.Size = new System.Drawing.Size(352, 48);
		this.gbWorkingConditions.TabIndex = 1;
		this.gbWorkingConditions.TabStop = false;
		this.gbWorkingConditions.Text = "Working Conditions";
		//
		//txtWavelength
		//
		this.txtWavelength.DigitsAfterDecimalPoint = 0;
		this.txtWavelength.ErrorColor = System.Drawing.Color.Empty;
		this.txtWavelength.ErrorMessage = null;
		this.txtWavelength.Location = new System.Drawing.Point(112, 18);
		this.txtWavelength.MaximumRange = 400;
		this.txtWavelength.MinimumRange = 190;
		this.txtWavelength.Name = "txtWavelength";
		this.txtWavelength.RangeValidation = false;
		this.txtWavelength.Size = new System.Drawing.Size(72, 21);
		this.txtWavelength.TabIndex = 0;
		this.txtWavelength.Text = "";
		this.txtWavelength.ValidationType = NumberValidator.NumberValidator.Validations.AlphaNumeric;
		//
		//Label1
		//
		this.Label1.Location = new System.Drawing.Point(192, 16);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(120, 24);
		this.Label1.TabIndex = 2;
		this.Label1.Text = "Range 190 - 400 nm";
		this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblWavelength
		//
		this.lblWavelength.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblWavelength.Location = new System.Drawing.Point(23, 16);
		this.lblWavelength.Name = "lblWavelength";
		this.lblWavelength.Size = new System.Drawing.Size(80, 24);
		this.lblWavelength.TabIndex = 0;
		this.lblWavelength.Text = "Wavelength";
		this.lblWavelength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblUVQuantitativeAnalysis
		//
		this.lblUVQuantitativeAnalysis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblUVQuantitativeAnalysis.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblUVQuantitativeAnalysis.Location = new System.Drawing.Point(96, 40);
		this.lblUVQuantitativeAnalysis.Name = "lblUVQuantitativeAnalysis";
		this.lblUVQuantitativeAnalysis.Size = new System.Drawing.Size(248, 23);
		this.lblUVQuantitativeAnalysis.TabIndex = 0;
		this.lblUVQuantitativeAnalysis.Text = "UV Quantitative Analysis";
		this.lblUVQuantitativeAnalysis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//frmUVQuantitativeAnalysis
		//
		this.AcceptButton = this.btnOk;
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.CancelButton = this.btnCancel;
		this.ClientSize = new System.Drawing.Size(434, 199);
		this.Controls.Add(this.CustomPanel1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmUVQuantitativeAnalysis";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Method";
		this.CustomPanel1.ResumeLayout(false);
		this.gbWorkingConditions.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Private Class Member Variables  "

	private int mintOpenMethodMode;

	private double Wavelength;
	#End Region

	#Region " Constants"

	private const  ConstFormLoad = "-Method-InstrumentConditions";

	private const  ConstParentFormLoad = "-Method";
	#End Region

	#Region " Private Properties "

	private EnumMethodMode OpenMethodMode {
		get { return mintOpenMethodMode; }
		set { mintOpenMethodMode = Value; }
	}

	#End Region

	#Region " Form Load And Event Handling Functions "

	private void  // ERROR: Handles clauses are not supported in C#
frmUVQuantitativeAnalysis_Load(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmUVQuantitativeAnalysis_Load
		// Parameters Passed     : object, eventArgs
		// Returns               : None
		// Purpose               : To load and initialize the form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 22-Jan-2007 04:35 pm
		// Revisions             : 1
		//=====================================================================


		//---- ORIGINAL CODE

		//hWv = GlobalAlloc(GHND, sizeof(double));
		//Chflag = cflag;
		//CheckInst();

		//wv = (double*) GlobalLock(hWv);
		//*wv = Inst->Wvcur;
		//if (inst && (inst->Wv>=200 && inst->Wv<=400))
		//	*wv = inst->Wv;
		//GlobalUnlock(hWv);

		DataTable objDtWv;
		//'object for the data structure.
		CWaitCursor objWait = new CWaitCursor();
		try {
			gobjMain.ShowProgressBar(gstrTitleInstrumentType + ConstFormLoad);
			//'show some info on progress bar.
			if (OpenMethodMode == modGlobalConstants.EnumMethodMode.NewMode) {
				//'get a type of method 
				//'either it is new or edit mode
				Wavelength = 200.0;
			} else {
				Wavelength = gobjInst.WavelengthCur;
			}
			if (!(gobjNewMethod.InstrumentCondition == null)) {
				//'get a wavelength and show it on screen.
				objDtWv = gobjNewMethod.InstrumentCondition.Wavelength();
				if (!(objDtWv == null)) {
					if (objDtWv.Rows.Count > 0) {
						Wavelength = objDtWv.Rows(0).Item(2);
					}
				}
			}

			txtWavelength.Text = Wavelength;

			if (!IsNothing(gobjInst)) {
				if ((gobjInst.WavelengthCur >= 200 & gobjInst.WavelengthCur <= 400)) {
					//'check a wavelength 
					//Wavelength = gobjInst.WavelengthCur
					txtWavelength.Text = Format(Wavelength, "#0.0");
				} else {
					//'set a format of wavwlength display
					txtWavelength.Text = Format(Wavelength, "#0.0");
				}
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
btnOk_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnOk_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               :to handle ok button event 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 22-Jan-2007 05:50 pm
		// Revisions             : 1
		//=====================================================================
		//'note:
		//'this is called when user click on OK button.
		DataTable objDtWv;
		try {
			//strcpy(inst->elName,"D2");
			//inst->Inst_Mode=D2E; 
			//inst->TurNo=0; 
			//inst->Cur = 0.0;
			//wv = (double*) GlobalLock(hWv);
			//inst->Wv = *wv;
			//inst->Slit = 2.0; 
			//inst->D2cur=300;
			//inst->Pmtv=Inst->d2Pmt;
			//GlobalUnlock(hWv);

			if (!IsNothing(gobjInst)) {
				//'set some default parameter
				gobjInst.ElementName = "D2";
				gobjInst.Mode = EnumCalibrationMode.D2E;
				gobjInst.TurretPosition = 0;
				gobjInst.Current = 0.0;
				gobjInst.SlitPosition = 2.0;
				gobjInst.D2Current = 300;
				gobjInst.PmtVoltage = gobjInst.D2Pmt;

				Wavelength = Val(txtWavelength.Text);
				//'get a wavwlength from wavelength text.
				if ((Wavelength >= 190.0 & Wavelength <= 400.0)) {
					//'check a wavelength range bet 190 to 400
					gobjInst.WavelengthCur = Wavelength;
				//'stroe a wavelength to data structure
				} else {
					gobjMessageAdapter.ShowMessage(constUVRange);
					//'show the validation mess
					Application.DoEvents();
					return;
				}
				Application.DoEvents();

				//Dim objUVInstrumentConditions As AAS203Library.Method.clsInstrumentParameters
				//objUVInstrumentConditions = New AAS203Library.Method.clsInstrumentParameters

				//objUVInstrumentConditions.Inst_Mode = EnumCalibrationMode.MABS

				int intElementID;
				int intCount;
				if (!IsNothing(gobjNewMethod)) {
					////----- Added by Sachin Dokhale 23.03.07
					//---if new method then set the selected element id for Emission
					//---update current and slit width and selected wavelength values of selected method id in 
					//---mobjInstrumentParaCollection object
					intElementID = 200;
					//cmbElementName.SelectedValue
					if (OpenMethodMode == modGlobalConstants.EnumMethodMode.NewMode) {
						//gobjNewMethod.SelectedElementID = intElementID
						gobjNewMethod.InstrumentCondition = new clsInstrumentParameters();
						gobjNewMethod.InstrumentCondition.ElementID = intElementID;
						gobjNewMethod.DateOfModification = System.DateTime.FromOADate(0.0);
						gobjNewMethod.DateOfLastUse = System.DateTime.FromOADate(0.0);
						gobjNewMethod.InstrumentCondition.Inst_Mode = EnumCalibrationMode.D2E;
					}

					objDtWv = gobjClsAAS203.funcGetElementWavelengths(intElementID);

					if (!(objDtWv == null)) {
						if (objDtWv.Rows.Count > 0) {
							objDtWv.Rows(0).Item(2) = gobjInst.WavelengthCur;
						} else {
							DataRow Rw;
							Rw = objDtWv.NewRow();
							objDtWv.Rows(0).Item(2) = gobjInst.WavelengthCur;
							objDtWv.Rows.Add(Rw);
						}
					}

					if (!(gobjNewMethod.InstrumentCondition == null)) {
						gobjNewMethod.InstrumentCondition.SlitWidth = gobjInst.SlitPosition;
						gobjNewMethod.InstrumentCondition.ExitSlitWidth = gobjInst.SlitPositionExit;
						gobjNewMethod.InstrumentCondition.Wavelength = objDtWv;
					}

					for (intCount = 0; intCount <= gobjMethodCollection.Count - 1; intCount++) {
						if (gobjMethodCollection.item(intCount).MethodID == gobjNewMethod.MethodID) {
							//gobjMethodCollection.item(intCount).InstrumentConditions = gobjNewMethod.InstrumentConditions.Clone
							gobjMethodCollection.item(intCount).InstrumentCondition = gobjNewMethod.InstrumentCondition.Clone();
							gobjNewMethod.DateOfModification = DateTime.Now;
							gobjMethodCollection.item(intCount).DateOfModification = gobjNewMethod.DateOfModification;
						}
					}
					//Added By Pankaj on 23 May 07 for adding method of inactive mode
					//gobjchkActiveMethod.fillInstruments = True  '27.07.07
					//If (gobjchkActiveMethod.fillInstruments = True And gobjchkActiveMethod.fillParameters = True And gobjchkActiveMethod.fillStdConcentration = True And gobjchkActiveMethod.CancelMethod = True And gobjchkActiveMethod.NewMethod = True) Then '27.07.07
					if ((gobjchkActiveMethod.fillStdConcentration == true & gobjchkActiveMethod.CancelMethod == true & gobjchkActiveMethod.NewMethod == true)) {
						gobjchkActiveMethod.NewMethod = false;
						gobjchkActiveMethod.CancelMethod = false;
						//gobjchkActiveMethod.fillInstruments = False '27.07.07
						//gobjchkActiveMethod.fillParameters = False  '27.07.07
						gobjchkActiveMethod.fillStdConcentration = false;
						gobjNewMethod.Status = true;
						gobjMethodCollection.Add(gobjNewMethod);
					}
					////-----
					//gobjNewMethod.InstrumentConditions.Add(objUVInstrumentConditions)
					//gobjNewMethod.InstrumentCondition = objUVInstrumentConditions.Clone()

					//Call funcSerialize(ConstMethodsFileName, gobjMethodCollection)
					funcSaveAllMethods(gobjMethodCollection);
					//'save the method to data structure

					gobjMain.MethodInstrumentSettingsChanged = true;
				}
				if (gstructSettings.ExeToRun == EnumApplicationMode.AAS) {
					funcSaveInstStatus();
				}
				//'save instrument current status to data structure
			}

			this.DialogResult = DialogResult.OK;
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
			objDtWv = null;
			//---------------------------------------------------------
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
btnCancel_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnCancel_Click
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : to handle cancel event
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		//'note:
		//'this is called when user click on cancel button.
		try {
			gobjchkActiveMethod.CancelMethod = true;
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

	private void  // ERROR: Handles clauses are not supported in C#
btnD2Peak_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnD2Peak_Click
		// Parameters Passed     : object, EventArgs
		// Returns               : None
		// Purpose               : To search the D2 Peak 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 24-Jan-2007 04:15 pm
		// Revisions             : 1
		//=====================================================================
		//'note:
		//'this is called when user clicked on D2 peak button.
		//'this will show a D2 peak dialog
		//'and start a D2 peak search routine.
		frmD2PeakSearch objfrmD2peak;

		try {
			objfrmD2peak = new frmD2PeakSearch();
			objfrmD2peak.ShowDialog();
			//'show dialog
			objfrmD2peak.Close();
			objfrmD2peak.Dispose();
			objfrmD2peak = null;

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

	private void  // ERROR: Handles clauses are not supported in C#
frmUVQuantitativeAnalysis_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmUVQuantitativeAnalysis_Closing
		// Parameters Passed     : object, EventArgs
		// Returns               : None
		// Purpose               : to close a dialog.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 24-Jan-2007 04:15 pm
		// Revisions             : 1
		//=====================================================================
		gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType + ConstParentFormLoad);
	}
}
