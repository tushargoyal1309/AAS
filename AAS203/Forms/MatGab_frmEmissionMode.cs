using AAS203.Common;
using AAS203Library.Method;

public class frmEmissionMode : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmEmissionMode()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call

	}

	public frmEmissionMode(int intMethodMode)
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
	internal System.Windows.Forms.GroupBox GroupBox1;
	internal System.Windows.Forms.Label Label1;
	internal System.Windows.Forms.Label Label2;
	internal System.Windows.Forms.GroupBox GroupBox2;
	internal System.Windows.Forms.Label Label3;
	internal System.Windows.Forms.Label Label4;
	internal System.Windows.Forms.Label Label5;
	internal System.Windows.Forms.Label Label6;
	internal NETXP.Controls.XPButton btnHelp;
	internal NETXP.Controls.XPButton btnOk;
	internal NETXP.Controls.XPButton btnCancel;
	internal System.Windows.Forms.ComboBox cmbElementName;
	internal CodeIntellects.Office2003Controls.Office2003Header Office2003Header1;
	internal NumberValidator.NumberValidator nudSlitWidth;
	internal NumberValidator.NumberValidator nudWavelength;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmEmissionMode));
		this.CustomPanel1 = new GradientPanel.CustomPanel();
		this.Office2003Header1 = new CodeIntellects.Office2003Controls.Office2003Header();
		this.btnHelp = new NETXP.Controls.XPButton();
		this.btnOk = new NETXP.Controls.XPButton();
		this.btnCancel = new NETXP.Controls.XPButton();
		this.GroupBox2 = new System.Windows.Forms.GroupBox();
		this.nudWavelength = new NumberValidator.NumberValidator();
		this.nudSlitWidth = new NumberValidator.NumberValidator();
		this.Label6 = new System.Windows.Forms.Label();
		this.Label5 = new System.Windows.Forms.Label();
		this.Label4 = new System.Windows.Forms.Label();
		this.Label3 = new System.Windows.Forms.Label();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.cmbElementName = new System.Windows.Forms.ComboBox();
		this.Label2 = new System.Windows.Forms.Label();
		this.Label1 = new System.Windows.Forms.Label();
		this.CustomPanel1.SuspendLayout();
		this.GroupBox2.SuspendLayout();
		this.GroupBox1.SuspendLayout();
		this.SuspendLayout();
		//
		//CustomPanel1
		//
		this.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanel1.Controls.Add(this.Office2003Header1);
		this.CustomPanel1.Controls.Add(this.btnHelp);
		this.CustomPanel1.Controls.Add(this.btnOk);
		this.CustomPanel1.Controls.Add(this.btnCancel);
		this.CustomPanel1.Controls.Add(this.GroupBox2);
		this.CustomPanel1.Controls.Add(this.GroupBox1);
		this.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanel1.Location = new System.Drawing.Point(0, 0);
		this.CustomPanel1.Name = "CustomPanel1";
		this.CustomPanel1.Size = new System.Drawing.Size(394, 239);
		this.CustomPanel1.TabIndex = 0;
		//
		//Office2003Header1
		//
		this.Office2003Header1.BackColor = System.Drawing.SystemColors.Control;
		this.Office2003Header1.Dock = System.Windows.Forms.DockStyle.Top;
		this.Office2003Header1.Location = new System.Drawing.Point(0, 0);
		this.Office2003Header1.Name = "Office2003Header1";
		this.Office2003Header1.Size = new System.Drawing.Size(394, 22);
		this.Office2003Header1.TabIndex = 14;
		this.Office2003Header1.TitleFont = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Office2003Header1.TitleText = "Quantitative Instrument Conditions - Emission Mode";
		//
		//btnHelp
		//
		this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnHelp.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnHelp.Image = (System.Drawing.Image)resources.GetObject("btnHelp.Image");
		this.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnHelp.Location = new System.Drawing.Point(246, 184);
		this.btnHelp.Name = "btnHelp";
		this.btnHelp.Size = new System.Drawing.Size(86, 34);
		this.btnHelp.TabIndex = 6;
		this.btnHelp.Text = "&Help";
		this.btnHelp.Visible = false;
		//
		//btnOk
		//
		this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOk.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnOk.Image = (System.Drawing.Image)resources.GetObject("btnOk.Image");
		this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOk.Location = new System.Drawing.Point(46, 184);
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
		this.btnCancel.Location = new System.Drawing.Point(146, 184);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(86, 34);
		this.btnCancel.TabIndex = 5;
		this.btnCancel.Text = "&Cancel";
		//
		//GroupBox2
		//
		this.GroupBox2.Controls.Add(this.nudWavelength);
		this.GroupBox2.Controls.Add(this.nudSlitWidth);
		this.GroupBox2.Controls.Add(this.Label6);
		this.GroupBox2.Controls.Add(this.Label5);
		this.GroupBox2.Controls.Add(this.Label4);
		this.GroupBox2.Controls.Add(this.Label3);
		this.GroupBox2.Location = new System.Drawing.Point(21, 106);
		this.GroupBox2.Name = "GroupBox2";
		this.GroupBox2.Size = new System.Drawing.Size(352, 72);
		this.GroupBox2.TabIndex = 1;
		this.GroupBox2.TabStop = false;
		this.GroupBox2.Text = "Working Conditions";
		//
		//nudWavelength
		//
		this.nudWavelength.DigitsAfterDecimalPoint = 0;
		this.nudWavelength.ErrorColor = System.Drawing.Color.Empty;
		this.nudWavelength.ErrorMessage = null;
		this.nudWavelength.Location = new System.Drawing.Point(88, 16);
		this.nudWavelength.MaximumRange = 0;
		this.nudWavelength.MinimumRange = 0;
		this.nudWavelength.Name = "nudWavelength";
		this.nudWavelength.RangeValidation = false;
		this.nudWavelength.Size = new System.Drawing.Size(64, 21);
		this.nudWavelength.TabIndex = 2;
		this.nudWavelength.Text = "";
		this.nudWavelength.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly;
		//
		//nudSlitWidth
		//
		this.nudSlitWidth.DigitsAfterDecimalPoint = 0;
		this.nudSlitWidth.ErrorColor = System.Drawing.Color.Empty;
		this.nudSlitWidth.ErrorMessage = null;
		this.nudSlitWidth.Location = new System.Drawing.Point(88, 40);
		this.nudSlitWidth.MaximumRange = 0;
		this.nudSlitWidth.MinimumRange = 0;
		this.nudSlitWidth.Name = "nudSlitWidth";
		this.nudSlitWidth.RangeValidation = false;
		this.nudSlitWidth.Size = new System.Drawing.Size(64, 21);
		this.nudSlitWidth.TabIndex = 3;
		this.nudSlitWidth.Text = "";
		this.nudSlitWidth.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly;
		//
		//Label6
		//
		this.Label6.Location = new System.Drawing.Point(163, 40);
		this.Label6.Name = "Label6";
		this.Label6.Size = new System.Drawing.Size(164, 16);
		this.Label6.TabIndex = 5;
		this.Label6.Text = "Range 0 - 2.0 nm in steps of 0.1";
		//
		//Label5
		//
		this.Label5.Location = new System.Drawing.Point(163, 19);
		this.Label5.Name = "Label5";
		this.Label5.Size = new System.Drawing.Size(128, 16);
		this.Label5.TabIndex = 4;
		this.Label5.Text = "Range 185 - 950 nm";
		this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//Label4
		//
		this.Label4.Location = new System.Drawing.Point(8, 40);
		this.Label4.Name = "Label4";
		this.Label4.Size = new System.Drawing.Size(64, 16);
		this.Label4.TabIndex = 1;
		this.Label4.Text = "Slit Width";
		//
		//Label3
		//
		this.Label3.Location = new System.Drawing.Point(8, 19);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(72, 16);
		this.Label3.TabIndex = 0;
		this.Label3.Text = "Wavelength";
		//
		//GroupBox1
		//
		this.GroupBox1.Controls.Add(this.cmbElementName);
		this.GroupBox1.Controls.Add(this.Label2);
		this.GroupBox1.Controls.Add(this.Label1);
		this.GroupBox1.Location = new System.Drawing.Point(21, 32);
		this.GroupBox1.Name = "GroupBox1";
		this.GroupBox1.Size = new System.Drawing.Size(352, 72);
		this.GroupBox1.TabIndex = 0;
		this.GroupBox1.TabStop = false;
		//
		//cmbElementName
		//
		this.cmbElementName.BackColor = System.Drawing.Color.White;
		this.cmbElementName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbElementName.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.cmbElementName.Location = new System.Drawing.Point(155, 43);
		this.cmbElementName.Name = "cmbElementName";
		this.cmbElementName.Size = new System.Drawing.Size(112, 24);
		this.cmbElementName.TabIndex = 1;
		//
		//Label2
		//
		this.Label2.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label2.Location = new System.Drawing.Point(43, 41);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(104, 24);
		this.Label2.TabIndex = 1;
		this.Label2.Text = "Element Name";
		this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//Label1
		//
		this.Label1.BackColor = System.Drawing.Color.Transparent;
		this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.Label1.Font = new System.Drawing.Font("Arial", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label1.Location = new System.Drawing.Point(10, 10);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(326, 22);
		this.Label1.TabIndex = 0;
		this.Label1.Text = "Emission Measurement Conditions";
		this.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		//
		//frmEmissionMode
		//
		this.AcceptButton = this.btnOk;
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.CancelButton = this.btnCancel;
		this.ClientSize = new System.Drawing.Size(394, 239);
		this.Controls.Add(this.CustomPanel1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmEmissionMode";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Method";
		this.CustomPanel1.ResumeLayout(false);
		this.GroupBox2.ResumeLayout(false);
		this.GroupBox1.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Class Member Variables "


	private DataTable mobjdtEmissionMode;
	private int mintTurretNumber;

	private bool mblnIsValid;
	private frmLampPlacements objfrmLampPlacements;
	private clsInstrumentParametersCollection mobjInstrumentParaCollection = new clsInstrumentParametersCollection();

	private int mintOpenMethodMode = 0;

	private int mintWavelengthID;
	private const  ConstIntMinWavelength = 190.0;
	private const  ConstIntMaxWavelength = 900.0;
	private const  ConstIntMinSlitWidthLimit = 0.1;
		#End Region
	private const  ConstIntMaxSlitWidthLimit = 2.0;

	#Region " Public Constants, Structures, Events.. "

	public event  MethodInstrumentSettingsChanged;

	#End Region

	#Region " Constants"

	private const  ConstFormLoad = "-Method-InstrumentConditions";

	private const  ConstParentFormLoad = "-Method";
	#End Region

	#Region " Private Properties "

	private EnumMethodMode OpenMethodMode {
		//'for getting or setting a method mode.
		get { return mintOpenMethodMode; }
		set { mintOpenMethodMode = Value; }
	}

	#End Region

	#Region " Form Load and Event Handling Functions "

	private void  // ERROR: Handles clauses are not supported in C#
frmEmissionMode_Load(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmEmissionMode_Load
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To initialize the form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S.
		// Created               : 07.10.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is called when a form is loaded.
		//'do some initialisation here.
		DataTable objDtElements = new DataTable("Elements");
		int intObjCount;
		DataRow objRow;
		DataView objDvElementsList;
		CWaitCursor objWait = new CWaitCursor();

		//---- ORIGINAL CODE from INSTDLL::Inst.c

		//if (inst && (strcmpi(Inst->Lamp_par.Ems.elname,"") == 0 ||
		//				 strcmpi(Inst->Lamp_par.Ems.elname,inst->elName) != 0 ))
		//{
		//	if (strcmpi(ltrim(trim(inst->elName)),"")!=0)
		//	{
		//		strcpy(Inst->Lamp_par.Ems.elname,inst->elName);
		//		Inst->Lamp_par.Ems.wv = inst->Wv ;
		//		Inst->Lamp_par.Ems.slitwidth = inst->Slit ;
		//	}
		//}

		try {
			if (!gstructSettings.EnableServiceUtility) {
				//'check for service.
				gobjMain.ShowProgressBar(gstrTitleInstrumentType + ConstFormLoad);
			} else {
				gobjService.ShowProgressBar(gstrTitleInstrumentType + ConstFormLoad);
			}
			//---get emission data from datatbase
			mobjdtEmissionMode = gobjDataAccess.EmissionData(gstructSettings.AppMode);

			//---bind datatable to the combobox.
			if (!mobjdtEmissionMode == null) {
				cmbElementName.SelectedIndexChanged -= cmbElementName_SelectedIndexChanged;
				cmbElementName.DataSource = mobjdtEmissionMode;
				cmbElementName.ValueMember = mobjdtEmissionMode.Columns(ConstColumnElementID).ColumnName;
				cmbElementName.DisplayMember = mobjdtEmissionMode.Columns(ConstColumnElementName).ColumnName;
				cmbElementName.SelectedIndexChanged += cmbElementName_SelectedIndexChanged;
			}

			cmbElementName.SelectedValue = gobjNewMethod.InstrumentCondition.ElementID;
			gobjInst.Lamp.EMSCondition.ElementName = gobjNewMethod.InstrumentCondition.ElementName;
			gobjInst.Lamp.EMSCondition.SlitWidth = gobjNewMethod.InstrumentCondition.SlitWidth;
			gobjInst.Lamp.EMSCondition.Wavelength = gobjNewMethod.InstrumentCondition.EmmWavelength;

			//---display data according to mode type selected
			if (OpenMethodMode == modGlobalConstants.EnumMethodMode.NewMode) {
				cmbElementName_SelectedIndexChanged(sender, e);
			} else if (OpenMethodMode == modGlobalConstants.EnumMethodMode.EditMode) {
				//cmbElementName.Text = gobjInst.Lamp.EMSCondition.ElementName
				nudWavelength.Text = gobjInst.Lamp.EMSCondition.Wavelength;
				nudSlitWidth.Text = FormatNumber(gobjInst.Lamp.EMSCondition.SlitWidth, 1);
				//FormatNumber(gobjInst.SlitPosition, 1)
			}
			subSetTextValidation();
			//'for setting text validation.
			cmbElementName.Focus();
			//---add event handlers
			nudSlitWidth.ValidationStatus += nudSlitWidth_ValidationStatus;
			nudWavelength.ValidationStatus += nudWavelength_ValidationStatus;

		//added by deepak on 24.07.07
		//Dim strWvRange As String
		//strWvRange = "Range " & gstructSettings.WavelengthRange.WvLowerBound & " - " & gstructSettings.WavelengthRange.WvUpperBound & "nm"
		//Label5.Text = strWvRange

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

	private void  // ERROR: Handles clauses are not supported in C#
btnOk_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnOk_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To set the instrument information to the object
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S.
		// Created               : 07.10.06
		// Revisions             : 
		//=====================================================================
		int intCount;
		int intElementID;
		CWaitCursor objWait = new CWaitCursor();


		//---- ORIGINAL CODE

		//If (inst) Then
		//{
		//	strcpy(inst->elName,Inst->Lamp_par.Ems.elname);
		//	inst->Inst_Mode=EMISSION; //, Inst->Lamp_par.lamp[LampNo].elaneme);
		//	inst->TurNo=0; //LampNo+1;
		//	inst->Cur = 0.0;
		//	inst->Wv = Inst->Lamp_par.Ems.wv;
		//	inst->Slit = Inst->Lamp_par.Ems.slitwidth;
		//	//inst->D2cur=
		//	//inst->Pmtv=
		//}

		//case IDOK:
		//case SKOK:
		//   GetDlgItemText(hwnd, IDC_WV,str, 10);
		//   tempk=atof(str);
		//   flag=TRUE;
		//   if (tempk<190.0 || tempk >900)
		//	    flag=FALSE;
		//   Else
		//   {
		//	    Inst->Lamp_par.Ems.wv= tempk;
		//	    GetDlgItemText(hwnd, IDC_SW,str, 10);
		//	    tempk=atof(str);
		//	    if (tempk<=0.0 || tempk >2.0)
		//		    flag=FALSE;
		//       Else
		//		    Inst->Lamp_par.Ems.slitwidth=tempk;
		//   }
		//   if (!flag)
		//       break;
		//   #if	!IN203DLL
		//	    Set_Ems_Instrument_Parameters(&(Inst->Lamp_par.Ems));
		//   #End If
		//	Save_Tuttet_Status();
		//	EndDialog(hwnd, 1);
		//   break;
		//*******************************************************
		double dblWavelength;
		double dblSlitWidth;
		long lngElementID;
		bool flag;

		try {
			//---validate emission setup
			Validate_EmnSetup();
			if (nudWavelength.Text == "" | nudSlitWidth.Text == "") {
				//'check for null value.
				gobjMessageAdapter.ShowMessage(constFieldsRequired);
				return;
				//Saurabh
				Application.DoEvents();
				//'allow application to perfrom its panding work.
			}

			//---get wavelength and slit width
			dblWavelength = Val(nudWavelength.Text);
			dblSlitWidth = Val(nudSlitWidth.Text);

			flag = true;

			gobjInst.Lamp.EMSCondition.ElementName = cmbElementName.Text;

			//---validate wavelength and slit width
			if ((dblWavelength < 190.0 | dblWavelength > 900.0)) {
				flag = false;
			} else {
				gobjInst.Lamp.EMSCondition.Wavelength = dblWavelength;
				if ((dblSlitWidth <= 0.0 | dblSlitWidth > 2.0)) {
					flag = false;
				} else {
					gobjInst.Lamp.EMSCondition.SlitWidth = dblSlitWidth;
				}
			}

			//---set data to method and instrument object.
			if ((flag)) {
				if (!IsNothing(gobjInst)) {
					gobjInst.ElementName = gobjInst.Lamp.EMSCondition.ElementName;
					gobjInst.Mode = EnumCalibrationMode.EMISSION;
					gobjInst.TurretPosition = 0;
					gobjInst.Current = 0.0;
					gobjInst.WavelengthCur = gobjInst.Lamp.EMSCondition.Wavelength;
					gobjInst.SlitPosition = gobjInst.Lamp.EMSCondition.SlitWidth;

					AAS203Library.Method.clsInstrumentParameters objEmsInstrumentConditions;
					gobjNewMethod.InstrumentCondition = new AAS203Library.Method.clsInstrumentParameters();
					gobjNewMethod.InstrumentCondition.ElementID = cmbElementName.SelectedValue;
					gobjNewMethod.InstrumentCondition.Inst_Mode = EnumCalibrationMode.EMISSION;
					gobjNewMethod.InstrumentCondition.ElementName = gobjInst.Lamp.EMSCondition.ElementName;
					gobjNewMethod.InstrumentCondition.SlitWidth = dblSlitWidth;
					gobjNewMethod.InstrumentCondition.EmmWavelength = dblWavelength;

					if (!IsNothing(gobjNewMethod)) {
						//---if new method then set the selected element id for Emission
						//---update current and slit width and selected wavelength values of selected method id in 
						//---mobjInstrumentParaCollection object
						lngElementID = cmbElementName.SelectedValue;
						if (OpenMethodMode == modGlobalConstants.EnumMethodMode.NewMode) {
							gobjNewMethod.InstrumentCondition.ElementID = lngElementID;
							gobjNewMethod.DateOfModification = System.DateTime.FromOADate(0.0);
							gobjNewMethod.DateOfLastUse = System.DateTime.FromOADate(0.0);
						}
						//---update information to method collection
						for (intCount = 0; intCount <= gobjMethodCollection.Count - 1; intCount++) {
							if (gobjMethodCollection.item(intCount).MethodID == gobjNewMethod.MethodID) {
								gobjMethodCollection.item(intCount).InstrumentCondition = gobjNewMethod.InstrumentCondition.Clone();
								gobjNewMethod.DateOfModification = DateTime.Now;
								gobjMethodCollection.item(intCount).DateOfModification = gobjNewMethod.DateOfModification;
								//gobjNewMethod.DateOfModification
							}
						}
					}

					if ((gobjchkActiveMethod.fillStdConcentration == true & gobjchkActiveMethod.CancelMethod == true & gobjchkActiveMethod.NewMethod == true)) {
						gobjchkActiveMethod.NewMethod = false;
						gobjchkActiveMethod.CancelMethod = false;
						gobjchkActiveMethod.fillStdConcentration = false;
						gobjNewMethod.Status = true;
						gobjMethodCollection.Add(gobjNewMethod);
					}

					//---save all methods
					funcSaveAllMethods(gobjMethodCollection);

					if (!gstructSettings.EnableServiceUtility) {
						//'check for service.
						gobjMain.MethodInstrumentSettingsChanged = true;
					}

				}
				//---save instrument setting information
				if (gstructSettings.ExeToRun == EnumApplicationMode.AAS) {
					funcSaveInstStatus();
				}
			}

			//---kept for service mode
			gblnIsInstrumentConditionsActive = false;

			this.DialogResult = DialogResult.OK;
			this.Close();
			this.Dispose();

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

	private void  // ERROR: Handles clauses are not supported in C#
btnCancel_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnCancel_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To close the form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S.
		// Created               : 07.10.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is called when user click on cancel button 

		try {
			//---to close the form
			gobjchkActiveMethod.CancelMethod = true;
			this.Close();
			this.Dispose();

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
cmbElementName_SelectedIndexChanged(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : cmbElementName_SelectedIndexChanged
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To set the values of selected element. 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S.
		// Created               : 07.10.06
		// Revisions             : praveen
		//=====================================================================
		//'note
		//'this event is called when user change a element name
		CWaitCursor objWait = new CWaitCursor();
		long lngElementID;
		long intObjCount;
		int intAtomicNumber;

		try {
			//---validate emission setup
			Validate_EmnSetup();

			if (cmbElementName.SelectedIndex > -1) {
				lngElementID = cmbElementName.SelectedValue();

				//---get data of selected element
				for (intObjCount = 0; intObjCount <= mobjdtEmissionMode.Rows.Count - 1; intObjCount++) {
					if (mobjdtEmissionMode.Rows.Item(intObjCount).Item(ConstColumnElementID) == lngElementID) {
						intAtomicNumber = mobjdtEmissionMode.Rows.Item(intObjCount).Item("ATNO");
						nudWavelength.Text = mobjdtEmissionMode.Rows.Item(intObjCount).Item("WVEMS");
						nudSlitWidth.Text = mobjdtEmissionMode.Rows.Item(intObjCount).Item("SLITEMS");
						break; // TODO: might not be correct. Was : Exit For
					}
				}
			}


			//----ORIGINAL CODE

			//Validate_EmnSetup(hwnd);
			//case IDC_ELNAME:
			//   if (HIWORD(lParam)==CBN_SELCHANGE)
			//	{
			//	    i= (WORD) SendMessage(GetDlgItem(hwnd, wParam),
			//		    CB_GETCURSEL, 0, 0L);
			//		SendMessage(GetDlgItem(hwnd, wParam), CB_GETLBTEXT,i,(DWORD) (LPSTR) str);
			//		strcpy(Inst->Lamp_par.Ems.elname, str);
			//		Inst->Lamp_par.Ems.wv=0.0;
			//		Inst->Lamp_par.Ems.Atno=0;
			//		Inst->Lamp_par.Ems.slitwidth=0.0;
			//       #If !IN203DLL Then
			//		    SetEmissionElements(hwnd, & (Inst->Lamp_par.Ems),
			//		    IDC_ELNAME, IDC_WV, IDC_SW, FALSE);
			//       #Else
			//           If (SetEmsElements! = NULL) Then
			//			    (*SetEmsElements)(hwnd, & (Inst->Lamp_par.Ems),
			//				    IDC_ELNAME, IDC_WV, IDC_SW, FALSE);
			//       #End If
			//	}
			//	break;

			//---set selected element data to the object
			gobjInst.Lamp.EMSCondition.ElementName = Trim(cmbElementName.Text);
			gobjInst.Lamp.EMSCondition.Wavelength = Val(nudWavelength.Text);
			gobjInst.Lamp.EMSCondition.AtomicNumber = intAtomicNumber;
			gobjInst.Lamp.EMSCondition.SlitWidth = Val(nudSlitWidth.Text);

			gobjfrmStatus.ElementName = Trim(cmbElementName.Text);
			//Added by Saurabh
			gobjfrmStatus.lblTurretNo.Visible = false;
			//Added by Saurabh

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

	#Region " Private functions "

	private bool Validate_EmnSetup()
	{
		//=====================================================================
		// Procedure Name        : Validate_EmnSetup
		// Parameters Passed     : None
		// Returns               : True or false
		// Purpose               : 
		// Description           : To validate emission setup data
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 22-Jan-2007 07:15 pm
		// Revisions             : 1
		//=====================================================================


		//---- ORIGINAL CODE

		//BOOL	Validate_EmnSetup(HWND hwnd)
		//{
		//   double	tempk=0;
		//	int	i;
		//	BOOL	flag=TRUE;
		//	char	str[80]="";

		//	i= (WORD) SendMessage(GetDlgItem(hwnd, IDC_ELNAME), CB_GETCURSEL, 0, 0L);
		//	SendMessage(GetDlgItem(hwnd, IDC_ELNAME), CB_GETLBTEXT,i, (DWORD) (LPSTR) str);

		//	if (strcmpi(ltrim(trim(str)),"")==0)
		//		flag=FALSE;

		//   If (flag) Then
		//	{
		//	    GetDlgItemText(hwnd, IDC_WV,str, 10);
		//		tempk=atof(str);
		//		if (tempk<190.0 || tempk >900)
		//			flag=FALSE;
		//       If (flag) Then
		//		{
		//			GetDlgItemText(hwnd, IDC_SW,str, 10);
		//			tempk=atof(str);
		//			if (tempk<=0.0 || tempk >2.0)
		//				flag=FALSE;
		//		}
		//	}
		//	EnableWindow(GetDlgItem(hwnd, SKOK), FALSE);

		//   If (flag) Then
		//		EnableWindow(GetDlgItem(hwnd, SKOK), TRUE);

		//	return flag;
		//}

		double dblWavelength;
		double dblSlitWidth;
		string strSelectedWavelength;
		bool flag;

		try {
			flag = true;
			strSelectedWavelength = "";

			strSelectedWavelength = Trim(cmbElementName.Text);
			if (strSelectedWavelength == "") {
				flag = false;
			}

			//---validate wavelength and slit width
			if ((flag)) {
				dblWavelength = Val(nudWavelength.Text);
				if ((dblWavelength < 190.0 | dblWavelength > 900)) {
					flag = false;
				}
				if ((flag)) {
					dblSlitWidth = Val(nudSlitWidth.Text);
					if ((dblSlitWidth <= 0.0 | dblSlitWidth > 2.0)) {
						flag = false;
					}
				}
			}

			//btnOk.Enabled = False

			if ((flag)) {
				btnOk.Enabled = true;
			}

			return flag;

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
			//---------------------------------------------------------
		}
	}

	private void subSetTextValidation()
	{
		//=====================================================================
		// Procedure Name        : subSetTextValidation
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To validate text boxes
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is uaed to set a validation range for text box.
		try {
			//---set properties to validate number validator
			nudSlitWidth.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly;
			nudSlitWidth.DigitsAfterDecimalPoint = 1;
			nudSlitWidth.RangeValidation = true;
			nudSlitWidth.MinimumRange = ConstIntMinSlitWidthLimit;
			nudSlitWidth.MaximumRange = ConstIntMaxSlitWidthLimit;
			nudSlitWidth.ErrorColor = Color.Gainsboro;

			nudWavelength.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly;
			nudWavelength.DigitsAfterDecimalPoint = 2;
			nudWavelength.RangeValidation = true;
			nudWavelength.MinimumRange = ConstIntMinWavelength;
			nudWavelength.MaximumRange = ConstIntMaxWavelength;
			nudWavelength.ErrorColor = Color.Gainsboro;


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

	private void nudSlitWidth_ValidationStatus(NumberValidator.NumberValidator.Status Status, string Msg)
	{
		//=====================================================================
		// Procedure Name        : nudSlitWidth_ValidationStatus
		// Parameters Passed     : Status as NumberValidator.Status,Msg
		// Returns               : None
		// Purpose               :  Set the validation status
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 
		// Revisions             : praveen
		//=====================================================================
		//---set ok button enable/disable on validation status
		try {
			if (Status == NumberValidator.NumberValidator.Status.NotValidated) {
				nudSlitWidth.Focus();
				btnOk.Enabled = false;
			} else {
				btnOk.Enabled = true;
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

	private void nudWavelength_ValidationStatus(NumberValidator.NumberValidator.Status Status, string Msg)
	{
		//=====================================================================
		// Procedure Name        : nudWavelength_ValidationStatus
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               :  Set the validation status
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//---set ok button enable/disable on validation status
		try {
			if (Status == NumberValidator.NumberValidator.Status.NotValidated) {
				nudWavelength.Focus();
				btnOk.Enabled = false;
			} else {
				btnOk.Enabled = true;
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
frmEmissionMode_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmEmissionMode_Closing
		// Parameters Passed     : Object,CancelEventArgs
		// Returns               : None
		// Purpose               :  Close the form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//---to show status bar information
		try {
			if (!gstructSettings.EnableServiceUtility) {
				gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType + ConstParentFormLoad);
			} else {
				gobjService.ShowRunTimeInfo(gstrTitleInstrumentType + ConstParentFormLoad);
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

}
