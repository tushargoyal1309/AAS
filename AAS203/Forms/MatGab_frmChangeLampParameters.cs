using AAS203.Common;

//class behind the form
public class frmChangeLampParameters : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmChangeLampParameters()
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
	internal System.Windows.Forms.Label Label2;
	internal System.Windows.Forms.Label Label3;
	internal System.Windows.Forms.Label Label4;
	internal NETXP.Controls.XPButton btnOk;
	internal NETXP.Controls.XPButton btnCancel;
	internal System.Windows.Forms.ComboBox cmbTurrEle;
	internal NumberValidator.NumberValidator txtHCLCurr;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmChangeLampParameters));
		this.CustomPanel1 = new GradientPanel.CustomPanel();
		this.txtHCLCurr = new NumberValidator.NumberValidator();
		this.btnOk = new NETXP.Controls.XPButton();
		this.btnCancel = new NETXP.Controls.XPButton();
		this.Label4 = new System.Windows.Forms.Label();
		this.Label3 = new System.Windows.Forms.Label();
		this.cmbTurrEle = new System.Windows.Forms.ComboBox();
		this.Label2 = new System.Windows.Forms.Label();
		this.Label1 = new System.Windows.Forms.Label();
		this.CustomPanel1.SuspendLayout();
		this.SuspendLayout();
		//
		//CustomPanel1
		//
		this.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanel1.Controls.Add(this.txtHCLCurr);
		this.CustomPanel1.Controls.Add(this.btnOk);
		this.CustomPanel1.Controls.Add(this.btnCancel);
		this.CustomPanel1.Controls.Add(this.Label4);
		this.CustomPanel1.Controls.Add(this.Label3);
		this.CustomPanel1.Controls.Add(this.cmbTurrEle);
		this.CustomPanel1.Controls.Add(this.Label2);
		this.CustomPanel1.Controls.Add(this.Label1);
		this.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanel1.Location = new System.Drawing.Point(0, 0);
		this.CustomPanel1.Name = "CustomPanel1";
		this.CustomPanel1.Size = new System.Drawing.Size(296, 199);
		this.CustomPanel1.TabIndex = 0;
		//
		//txtHCLCurr
		//
		this.txtHCLCurr.BackColor = System.Drawing.Color.White;
		this.txtHCLCurr.DigitsAfterDecimalPoint = 1;
		this.txtHCLCurr.ErrorColor = System.Drawing.Color.Empty;
		this.txtHCLCurr.ErrorMessage = null;
		this.txtHCLCurr.Location = new System.Drawing.Point(120, 78);
		this.txtHCLCurr.MaximumRange = 25;
		this.txtHCLCurr.MaxLength = 4;
		this.txtHCLCurr.MinimumRange = 0;
		this.txtHCLCurr.Name = "txtHCLCurr";
		this.txtHCLCurr.RangeValidation = true;
		this.txtHCLCurr.ReadOnly = true;
		this.txtHCLCurr.Size = new System.Drawing.Size(56, 21);
		this.txtHCLCurr.TabIndex = 2;
		this.txtHCLCurr.Text = "";
		this.txtHCLCurr.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly;
		//
		//btnOk
		//
		this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOk.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnOk.Image = (System.Drawing.Image)resources.GetObject("btnOk.Image");
		this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOk.Location = new System.Drawing.Point(48, 144);
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
		this.btnCancel.Location = new System.Drawing.Point(168, 144);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(86, 34);
		this.btnCancel.TabIndex = 4;
		this.btnCancel.Text = "&Cancel";
		//
		//Label4
		//
		this.Label4.BackColor = System.Drawing.Color.AliceBlue;
		this.Label4.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label4.Location = new System.Drawing.Point(184, 72);
		this.Label4.Name = "Label4";
		this.Label4.Size = new System.Drawing.Size(64, 24);
		this.Label4.TabIndex = 5;
		this.Label4.Text = "0 - 25 mA";
		this.Label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
		//
		//Label3
		//
		this.Label3.BackColor = System.Drawing.Color.AliceBlue;
		this.Label3.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label3.Location = new System.Drawing.Point(24, 80);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(88, 16);
		this.Label3.TabIndex = 3;
		this.Label3.Text = "HCL Current";
		//
		//cmbTurrEle
		//
		this.cmbTurrEle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbTurrEle.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.cmbTurrEle.Location = new System.Drawing.Point(120, 27);
		this.cmbTurrEle.Name = "cmbTurrEle";
		this.cmbTurrEle.Size = new System.Drawing.Size(120, 23);
		this.cmbTurrEle.TabIndex = 1;
		//
		//Label2
		//
		this.Label2.BackColor = System.Drawing.Color.AliceBlue;
		this.Label2.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label2.Location = new System.Drawing.Point(24, 32);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(104, 16);
		this.Label2.TabIndex = 1;
		this.Label2.Text = "Turret, Element";
		//
		//Label1
		//
		this.Label1.BackColor = System.Drawing.Color.AliceBlue;
		this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.Label1.Location = new System.Drawing.Point(16, 16);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(264, 104);
		this.Label1.TabIndex = 0;
		//
		//frmChangeLampParameters
		//
		this.AcceptButton = this.btnOk;
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.CancelButton = this.btnCancel;
		this.ClientSize = new System.Drawing.Size(296, 199);
		this.Controls.Add(this.CustomPanel1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmChangeLampParameters";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Change Lamp Parameters";
		this.CustomPanel1.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region "Variables"
	private int mintNewTurretPosition = 0;
	static double mdblNewHCLCurrent;
	DataTable mobjdtLampParameters;
	static int mintLampNumber = 0;
		#End Region
	int mintTurretNumber;

	#Region "Constants"
	private const  ConstColumnLampNumber = "LampNumber";
	private const  ConstColumnTurretNumber = "TurretNumber";
	private const  ConstColumnElement = "Element";
		#End Region
	private const  ConstColumnDisplayElement = "DisplayElement";

	#Region "Form Events"
	private void  // ERROR: Handles clauses are not supported in C#
frmChangeLampParameters_Load(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmChangeLampParameters_Load
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : Load the form Object
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 02.12.06
		// Revisions             : Deepak on 14.08.07
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			//---call function initialize
			funcInitialise();
		//added by Pankaj on 04 Jun 07
		//If cmbTurrEle.SelectedIndex > -1 Then
		//    'mintNewTurretPosition = cmbTurrEle.SelectedIndex + 1
		//    'intTurrNO = CInt(Strings.Left(Trim(cmbTurrEle.SelectedItem), 1))      ' cmbTurrEle.SelectedIndex()
		//    mintNewTurretPosition = CInt(Strings.Left(Trim(cmbTurrEle.SelectedItem), 1))    ' cmbTurrEle.SelectedIndex()
		//    txtHCLCurr.Text = mdblNewHCLCurrent
		//End If
		//--------------
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

	#Region "Private functions"

	private object funcInitialise()
	{
		//=====================================================================
		// Procedure Name        : funcInitialise
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : Initialise the form Object
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 02.12.06
		// Revisions             : Deepak on 14.08.07
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		int intLampIdx;
		try {
			//If gobjInst.Lamp.LampParametersCollection.Count > 0 Then
			//    For intLampIdx = 0 To gobjInst.Lamp.LampParametersCollection.Count - 1
			//        If Not gobjInst.Lamp.LampParametersCollection(intLampIdx).ElementName = "" Then
			//            cmbTurrEle.Items.Add((intLampIdx + 1).ToString & ", " & gobjInst.Lamp.LampParametersCollection(intLampIdx).ElementName)
			//        End If
			//    Next
			//    If cmbTurrEle.Items.Count > 0 Then
			//        btnOk.Enabled = True
			//    Else
			//        btnOk.Enabled = False
			//    End If

			//    'If gobjInst.Lamp_Position > 0 Then
			//    '    If cmbTurrEle.Items.Count > 0 Then
			//    '        cmbTurrEle.SelectedIndex = 0
			//    '    End If
			//    'End If
			//    If (gintSelectedLampParameter > 0) Then
			//        cmbTurrEle.SelectedIndex = gintSelectedLampParameter
			//    End If
			//    'txtHCLCurr.Text = gobjInst.Current
			//End If

			mobjdtLampParameters = new DataTable();
			DataRow objRow;
			int intLampNumber = 0;
			mobjdtLampParameters.Columns.Add(ConstColumnLampNumber);
			mobjdtLampParameters.Columns.Add(ConstColumnTurretNumber);
			mobjdtLampParameters.Columns.Add(ConstColumnElement);
			mobjdtLampParameters.Columns.Add(ConstColumnDisplayElement);

			//---add turret number and element name to the combo box.
			if (gobjInst.Lamp.LampParametersCollection.Count > 0) {
				for (intLampIdx = 0; intLampIdx <= gobjInst.Lamp.LampParametersCollection.Count - 1; intLampIdx++) {
					if (!gobjInst.Lamp.LampParametersCollection(intLampIdx).ElementName == "") {
						intLampNumber = intLampNumber + 1;
						objRow = mobjdtLampParameters.NewRow;
						objRow.Item(ConstColumnLampNumber) = intLampNumber;
						objRow.Item(ConstColumnTurretNumber) = intLampIdx + 1;
						objRow.Item(ConstColumnElement) = gobjInst.Lamp.LampParametersCollection(intLampIdx).ElementName;
						objRow.Item(ConstColumnDisplayElement) = intLampIdx + 1 + " , " + gobjInst.Lamp.LampParametersCollection(intLampIdx).ElementName;
						mobjdtLampParameters.Rows.Add(objRow);
					}
				}
				cmbTurrEle.DataSource = mobjdtLampParameters;
				cmbTurrEle.DisplayMember = ConstColumnDisplayElement;
				cmbTurrEle.ValueMember = ConstColumnLampNumber;
			}

			if (mobjdtLampParameters.Rows.Count > 0) {
				for (intLampIdx = 0; intLampIdx <= mobjdtLampParameters.Rows.Count - 1; intLampIdx++) {
					if (mobjdtLampParameters.Rows.Item(intLampIdx).Item(ConstColumnTurretNumber) == gobjInst.Lamp_Position) {
						mintLampNumber = mobjdtLampParameters.Rows.Item(intLampIdx).Item(ConstColumnLampNumber);
						cmbTurrEle.SelectedValue = mintLampNumber;
						cmbTurrEle_SelectedIndexChanged(this, new EventArgs());
					}
				}

				btnOk.Enabled = true;
			} else {
				btnOk.Enabled = false;
			}

			AddHandlers();
		//'for adding a event to a control
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

	private object funcIniObject()
	{
		//=====================================================================
		// Procedure Name        : funcIniObject
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : Initialise the form Object
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 02.12.06
		// Revisions             : praveen 
		//=====================================================================
		DataTable dtTrretEle;
		int TurrAllIndx;
		int TurrIndx;

		try {
			DataColumn DtCol = new DataColumn();
			TurrIndx = 0;
			dtTrretEle = new DataTable();
			for (TurrAllIndx = 0; TurrAllIndx <= gobjClsAAS203.funcGetMaxLamp() - 1; TurrAllIndx++) {
				//'make a counter for max num of lamp.
				if (!(LTrim(Trim(gobjInst.Lamp.LampParametersCollection(TurrAllIndx).ElementName)) == "")) {
					cmbTurrEle.Items.Insert(TurrIndx, gobjInst.Lamp_Position.ToString + " " + (LTrim(Trim(gobjInst.Lamp.LampParametersCollection(TurrAllIndx).ElementName))));
					TurrIndx += 1;
				}
			}


			if (gobjInst.Lamp_Position > 0) {
				cmbTurrEle.SelectedIndex = gobjInst.Lamp_Position - 1;
				//gobjInst.Lamp.LampParametersCollection(0).ElementName
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
		// Author                : Sachin Dokhale
		// Created               : 15.11.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is called for adding a event to a control
		//'this is called durong a initialisation 
		try {
			btnOk.Click += btnOk_Click;
			//'for eg, if user clicked on OK button then btnOk_Click will called.
			btnCancel.Click += btnCancel_Click;
			cmbTurrEle.SelectedIndexChanged += cmbTurrEle_SelectedIndexChanged;
		//

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

	private void btnOk_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnOk_Click
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 02.12.06
		// Revisions             : Deepak on 14.08.07
		//=====================================================================
		//'note:
		//'this is called when user clicked on OK button
		//'this is used to handle a OK cleck event.
		CWaitCursor objWait = new CWaitCursor();
		double dblCurrent;
		try {
			//' funcPosition_Turret (hwnd, pos, TRUE);
			//'Set_HCL_Cur(cur , (BYTE) pos);
			//'added by Pankaj on 04 Jun 07
			//gintSelectedLampParameter = cmbTurrEle.SelectedIndex
			//If cmbTurrEle.SelectedIndex > -1 Then
			//    'mintNewTurretPosition = cmbTurrEle.SelectedIndex + 1
			//    'intTurrNO = CInt(Strings.Left(Trim(cmbTurrEle.SelectedItem), 1))      ' cmbTurrEle.SelectedIndex()
			//    mintNewTurretPosition = CInt(Strings.Left(Trim(cmbTurrEle.SelectedItem), 1))    ' cmbTurrEle.SelectedIndex()
			//End If

			//---position turret to given location
			if (mintTurretNumber > 0) {
				gobjCommProtocol.gFuncTurret_Position(mintTurretNumber, true);
			}

			if (!Trim(txtHCLCurr.Text) == "") {
				//'get a HCL current to temp variable.
				dblCurrent = (double)txtHCLCurr.Text;
			}

			//---set hcl current to the given lamp
			if (!(dblCurrent == gobjInst.Current)) {
				gobjCommProtocol.funcSet_HCL_Cur(dblCurrent, gobjInst.Lamp_Position);
				//'function for setting HCL current at given position.
				gobjInst.Current = dblCurrent;
			}

			//Application.DoEvents()
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

	private void btnCancel_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnCancel_Click
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : this is called when user click on cancel button.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 02.12.06
		// Revisions             : Deepak on 14.08.07
		//=====================================================================
		this.DialogResult = DialogResult.Cancel;
	}

	private void cmbTurrEle_SelectedIndexChanged(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : cmbTurrEle_SelectedIndexChanged
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 02.12.06
		// Revisions             : Deepak on 14.08.07
		//=====================================================================
		//'note;
		//'this is a event realted to combo box.
		//'this is called when user change the turrert element.
		CWaitCursor objWait = new CWaitCursor();
		int intTurrNO;
		int intCount;
		int intLampNumber;
		try {
			//If cmbTurrEle.SelectedIndex > -1 Then
			//    'mintNewTurretPosition = cmbTurrEle.SelectedIndex + 1
			//    'intTurrNO = CInt(Strings.Left(Trim(cmbTurrEle.SelectedItem), 1))      ' cmbTurrEle.SelectedIndex()
			//    mintNewTurretPosition = CInt(Strings.Left(Trim(cmbTurrEle.SelectedItem), 1))    ' cmbTurrEle.SelectedIndex()
			//    'txtHCLCurr.Text = gobjInst.Current
			//End If

			//---display current of selected lamp element
			intLampNumber = cmbTurrEle.SelectedValue;
			for (intCount = 0; intCount <= mobjdtLampParameters.Rows.Count - 1; intCount++) {
				if (intLampNumber == mobjdtLampParameters.Rows.Item(intCount).Item(ConstColumnLampNumber)) {
					mintTurretNumber = mobjdtLampParameters.Rows.Item(intCount).Item(ConstColumnTurretNumber);
				}
			}
			txtHCLCurr.Text = gobjInst.Current;

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

}
