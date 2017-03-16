using AAS203.Common;
public class frmEditValues : System.Windows.Forms.Form
{
	//Dim m_intfrmNo As EnumButtonIndex


	#Region " Windows Form Designer generated code "

	public frmEditValues()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call

	}

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
	internal System.Windows.Forms.Label lblText;
	internal NETXP.Controls.XPButton btnOk;
	internal NETXP.Controls.XPButton btnCancel;
	internal System.Windows.Forms.Label lblText1;
	internal System.Windows.Forms.Panel CustomPanelHide;
	internal NumberValidator.NumberValidator txtValue1;
	internal NumberValidator.NumberValidator txtValue2;
	internal NumberValidator.NumberValidator txtValue;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmEditValues));
		this.CustomPanel1 = new GradientPanel.CustomPanel();
		this.txtValue = new NumberValidator.NumberValidator();
		this.txtValue1 = new NumberValidator.NumberValidator();
		this.txtValue2 = new NumberValidator.NumberValidator();
		this.CustomPanelHide = new System.Windows.Forms.Panel();
		this.lblText1 = new System.Windows.Forms.Label();
		this.lblText = new System.Windows.Forms.Label();
		this.btnCancel = new NETXP.Controls.XPButton();
		this.btnOk = new NETXP.Controls.XPButton();
		this.CustomPanel1.SuspendLayout();
		this.SuspendLayout();
		//
		//CustomPanel1
		//
		this.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanel1.Controls.Add(this.txtValue);
		this.CustomPanel1.Controls.Add(this.txtValue1);
		this.CustomPanel1.Controls.Add(this.txtValue2);
		this.CustomPanel1.Controls.Add(this.CustomPanelHide);
		this.CustomPanel1.Controls.Add(this.lblText1);
		this.CustomPanel1.Controls.Add(this.lblText);
		this.CustomPanel1.Controls.Add(this.btnCancel);
		this.CustomPanel1.Controls.Add(this.btnOk);
		this.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanel1.Location = new System.Drawing.Point(0, 0);
		this.CustomPanel1.Name = "CustomPanel1";
		this.CustomPanel1.Size = new System.Drawing.Size(290, 79);
		this.CustomPanel1.TabIndex = 0;
		//
		//txtValue
		//
		this.txtValue.DigitsAfterDecimalPoint = 0;
		this.txtValue.ErrorColor = System.Drawing.Color.Empty;
		this.txtValue.ErrorMessage = null;
		this.txtValue.Location = new System.Drawing.Point(215, 16);
		this.txtValue.MaximumRange = 1;
		this.txtValue.MinimumRange = 0;
		this.txtValue.Name = "txtValue";
		this.txtValue.RangeValidation = false;
		this.txtValue.Size = new System.Drawing.Size(60, 20);
		this.txtValue.TabIndex = 0;
		this.txtValue.Text = "";
		this.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.AlphaNumeric;
		//
		//txtValue1
		//
		this.txtValue1.DigitsAfterDecimalPoint = 0;
		this.txtValue1.ErrorColor = System.Drawing.Color.Empty;
		this.txtValue1.ErrorMessage = null;
		this.txtValue1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtValue1.Location = new System.Drawing.Point(215, 48);
		this.txtValue1.MaximumRange = 6;
		this.txtValue1.MaxLength = 1;
		this.txtValue1.MinimumRange = 1;
		this.txtValue1.Name = "txtValue1";
		this.txtValue1.RangeValidation = true;
		this.txtValue1.Size = new System.Drawing.Size(60, 21);
		this.txtValue1.TabIndex = 14;
		this.txtValue1.Text = "1";
		this.txtValue1.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly;
		this.txtValue1.Visible = false;
		//
		//txtValue2
		//
		this.txtValue2.BackColor = System.Drawing.Color.White;
		this.txtValue2.DigitsAfterDecimalPoint = 0;
		this.txtValue2.ErrorColor = System.Drawing.Color.Empty;
		this.txtValue2.ErrorMessage = null;
		this.txtValue2.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtValue2.Location = new System.Drawing.Point(232, 48);
		this.txtValue2.MaximumRange = 1000;
		this.txtValue2.MaxLength = 4;
		this.txtValue2.MinimumRange = 0;
		this.txtValue2.Name = "txtValue2";
		this.txtValue2.RangeValidation = false;
		this.txtValue2.Size = new System.Drawing.Size(16, 21);
		this.txtValue2.TabIndex = 0;
		this.txtValue2.Text = "";
		this.txtValue2.ValidationType = NumberValidator.NumberValidator.Validations.AlphaNumeric;
		this.txtValue2.Visible = false;
		//
		//CustomPanelHide
		//
		this.CustomPanelHide.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanelHide.Location = new System.Drawing.Point(292, 3);
		this.CustomPanelHide.Name = "CustomPanelHide";
		this.CustomPanelHide.Size = new System.Drawing.Size(80, 72);
		this.CustomPanelHide.TabIndex = 12;
		//
		//lblText1
		//
		this.lblText1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblText1.Location = new System.Drawing.Point(16, 48);
		this.lblText1.Name = "lblText1";
		this.lblText1.Size = new System.Drawing.Size(144, 16);
		this.lblText1.TabIndex = 10;
		//
		//lblText
		//
		this.lblText.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblText.Location = new System.Drawing.Point(8, 19);
		this.lblText.Name = "lblText";
		this.lblText.Size = new System.Drawing.Size(208, 16);
		this.lblText.TabIndex = 0;
		//
		//btnCancel
		//
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCancel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnCancel.Image = (System.Drawing.Image)resources.GetObject("btnCancel.Image");
		this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCancel.Location = new System.Drawing.Point(294, 38);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(76, 32);
		this.btnCancel.TabIndex = 9;
		this.btnCancel.Text = "Cancel";
		//
		//btnOk
		//
		this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOk.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnOk.Image = (System.Drawing.Image)resources.GetObject("btnOk.Image");
		this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOk.Location = new System.Drawing.Point(294, 7);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(76, 29);
		this.btnOk.TabIndex = 8;
		this.btnOk.Text = "OK";
		//
		//frmEditValues
		//
		this.AcceptButton = this.btnOk;
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.CancelButton = this.btnCancel;
		this.ClientSize = new System.Drawing.Size(290, 79);
		this.Controls.Add(this.CustomPanel1);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.KeyPreview = true;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmEditValues";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Edit Values";
		this.TopMost = true;
		this.CustomPanel1.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Variables"
	private int mintValue;
	private string mstrLabelText;
	//Private mintTextValue As Integer
	public event  ReturnValue;
	#End Region

	#Region " Properties"

	public string LabelText {
		get { return mstrLabelText; }
		set {
			mstrLabelText = Value;

			lblText.Text = LabelText;
			lblText.Refresh();

		}
	}

	private double TextValue {
		get { return mintValue; }
		set { mintValue = Value; }
	}

	private int TextValue1 {
		get { return mintValue; }
		set { mintValue = Value; }
	}

	#End Region

	#Region " Enum Declaration"

	//--- Enum for the Form Button indices
	public enum EnumButtonIndex
	{
		TurretPosition = 1,
		D2Current = 2,
		PMT = 3,
		MODE = 4,
		AvgValue = 5,
		WvPosition = 6,
		SlitPos = 7,
		WvRepeats = 8,
		SlitRepeats = 9
	}

	#End Region

	#Region " Form Events"

	private void  // ERROR: Handles clauses are not supported in C#
frmEditValues_Load(object sender, System.EventArgs e)
	{
		CWaitCursor objwait = new CWaitCursor();
		try {
			txtValue.SelectAll();
			Addhandlers();

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
			if (!objwait == null) {
				objwait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	#End Region

	#Region " Private Functions"

	private void Addhandlers()
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

		try {
			btnOk.Click += btnOk_Click;
			btnCancel.Click += btnCancel_Click;

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

	private void btnCancel_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnCancel_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To cancel the form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
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
			//---------------------------------------------------------
		}
	}

	private void btnOk_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnOk_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To send dialog result as ok
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		double dblValue;
		int intValue1;
		try {
			if (txtValue.Text == "") {
				gobjMessageAdapter.ShowMessage(constInputProperData);
				Application.DoEvents();
				return;
			}
			if (IsNumeric(txtValue.Text)) {
				dblValue = (double)txtValue.Text;
			} else {
				txtValue1.Text = (double)0;
			}
			//'Added by praveen for validation

			if (IsNumeric(txtValue.Text)) {
				intValue1 = txtValue.Text;
				if (intValue1 < txtValue.MinimumRange) {
					intValue1 = txtValue.MinimumRange;
				} else if (intValue1 > txtValue.MaximumRange) {
					intValue1 = txtValue.MaximumRange;
				} else {
					intValue1 = txtValue.Text;
				}
			} else {
				intValue1 = txtValue.MinimumRange;
			}
			//'Ended by praveen
			intValue1 = (double)txtValue1.Text;
			if (ReturnValue != null) {
				ReturnValue(dblValue, intValue1);
			}

			//If m_intfrmNo = 1 Then
			//    Application.DoEvents()
			//End If

			this.DialogResult = DialogResult.OK;
			this.Close();
		//Me.Dispose()

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
