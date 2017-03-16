public class ValueEditor : System.Windows.Forms.UserControl
{
	//************************************************************************************************************
	// File Header
	// File Name 		: ValueEditor.vb
	// Author			: Deepak Bhati
	// Date/Time			: 30.03.07
	// Description		: This component is used to set value with increment and decrement button provided
	//                     to change the set value.
	//************************************************************************************************************

	#Region " Windows Form Designer generated code "

	public ValueEditor()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call

		InitializeErrorHandlerObject();

	}

	//UserControl1 overrides dispose to clean up the component list.
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
	internal System.Windows.Forms.Panel PnlBtn;
	internal System.Windows.Forms.Panel pnlScroll;
	internal NETXP.Controls.XPButton Btn;
	internal NETXP.Controls.XPButton BtnUp;
	internal NETXP.Controls.XPButton BtnDn;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		this.PnlBtn = new System.Windows.Forms.Panel();
		this.Btn = new NETXP.Controls.XPButton();
		this.pnlScroll = new System.Windows.Forms.Panel();
		this.BtnDn = new NETXP.Controls.XPButton();
		this.BtnUp = new NETXP.Controls.XPButton();
		this.PnlBtn.SuspendLayout();
		this.pnlScroll.SuspendLayout();
		this.SuspendLayout();
		//
		//PnlBtn
		//
		this.PnlBtn.Controls.Add(this.Btn);
		this.PnlBtn.Dock = System.Windows.Forms.DockStyle.Fill;
		this.PnlBtn.Location = new System.Drawing.Point(0, 0);
		this.PnlBtn.Name = "PnlBtn";
		this.PnlBtn.Size = new System.Drawing.Size(48, 24);
		this.PnlBtn.TabIndex = 3;
		//
		//Btn
		//
		this.Btn.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Btn.Location = new System.Drawing.Point(0, 0);
		this.Btn.Name = "Btn";
		this.Btn.Size = new System.Drawing.Size(48, 24);
		this.Btn.TabIndex = 0;
		//
		//pnlScroll
		//
		this.pnlScroll.Controls.Add(this.BtnDn);
		this.pnlScroll.Controls.Add(this.BtnUp);
		this.pnlScroll.Dock = System.Windows.Forms.DockStyle.Right;
		this.pnlScroll.Location = new System.Drawing.Point(48, 0);
		this.pnlScroll.Name = "pnlScroll";
		this.pnlScroll.Size = new System.Drawing.Size(24, 24);
		this.pnlScroll.TabIndex = 2;
		//
		//BtnDn
		//
		this.BtnDn.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.BtnDn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.BtnDn.Font = new System.Drawing.Font("Marlett", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)2);
		this.BtnDn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.BtnDn.Location = new System.Drawing.Point(0, 12);
		this.BtnDn.Name = "BtnDn";
		this.BtnDn.Size = new System.Drawing.Size(24, 12);
		this.BtnDn.TabIndex = 5;
		this.BtnDn.TabStop = false;
		this.BtnDn.Text = "6";
		//
		//BtnUp
		//
		this.BtnUp.Dock = System.Windows.Forms.DockStyle.Top;
		this.BtnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.BtnUp.Font = new System.Drawing.Font("Marlett", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)2);
		this.BtnUp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.BtnUp.Location = new System.Drawing.Point(0, 0);
		this.BtnUp.Name = "BtnUp";
		this.BtnUp.Size = new System.Drawing.Size(24, 12);
		this.BtnUp.TabIndex = 4;
		this.BtnUp.TabStop = false;
		this.BtnUp.Text = "5";
		//
		//ValueEditor
		//
		this.Controls.Add(this.PnlBtn);
		this.Controls.Add(this.pnlScroll);
		this.Name = "ValueEditor";
		this.Size = new System.Drawing.Size(72, 24);
		this.PnlBtn.ResumeLayout(false);
		this.pnlScroll.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region "Public Events"
	public event  ValueEditorClick;
	public event  ValueEditorValueChanged;
	#End Region

	#Region "Constants"
	private const  CONST_CREATE_EXECUTION_LOG = 0;
	public enum EnumValueEditorButtons
	{
		MainButton = 1,
		UpButton = 2,
		DownButton = 3
	}

	#End Region

	#Region "Private Variables"
	private ErrorHandler.ErrorHandler gobjErrorHandler = new ErrorHandler.ErrorHandler();
	private double mdblValue;
	private double mdblMinValue;
	private double mdblMaxValue;
	private double mdblChangeFactor;
	private int mintDecimalPlace;
	private bool mblnIsReverseOperation;
	private int mintButtonClicked = 1;
	private bool mblnIsUpDownButtonToBeDisabledOnValuechange;
	private string mstrText;
	private bool mblnAvoidProcessing;
	private bool mblnIsUpDownEnable;
		#End Region
	private bool mblnIsBtnEnable;

	#Region "Public Properties"

	public double Value {
		get { return mdblValue; }

		set {
			//If Value <= MaxValue And Value >= MinValue Then
			if (Val <= MaxValue & Val >= MinValue) {
				//mdblValue = Val
				mdblValue = funcSetDecimalPlace(Val);
				//Btn.Text = mdblValue
				mstrText = mdblValue;
				if (ValueEditorValueChanged != null) {
					ValueEditorValueChanged(mdblValue);
				}
				Btn.Text = mdblValue;

			}

		}
	}

	public int DecimalPlace {
		get { return mintDecimalPlace; }
			//If Value <= MaxValue And Value >= MinValue Then
			//    mdblValue = Val
			//    Btn.Text = Value
			//    RaiseEvent ValueEditorValueChanged(Value)
			//End If


		set { mintDecimalPlace = Val; }
	}

	public Color BackgroundColor {
		get { return this.BackColor; }
		set {
			this.BackColor = Value;
			Btn.BackColor = Value;
			BtnUp.BackColor = Value;
			BtnDn.BackColor = Value;
		}
	}

	public Color ForegroundColor {
		get { return this.ForeColor; }
		set {
			this.ForeColor = Value;
			Btn.ForeColor = Value;
			BtnUp.ForeColor = Value;
			BtnDn.ForeColor = Value;
		}
	}

	public double MinValue {
		get { return mdblMinValue; }
		set { mdblMinValue = Value; }
	}

	public double MaxValue {
		get { return mdblMaxValue; }
		set { mdblMaxValue = Value; }
	}

	public double ChangeFactor {
		get { return mdblChangeFactor; }
		set { mdblChangeFactor = Value; }
	}

	public bool ValueEditorEnabled {
		get { return this.Enabled; }

		set { this.Enabled = Value; }
	}

	public string UpButtonText {
		get { return BtnUp.Text; }
		set { BtnUp.Text = Value; }
	}

	public string DnButtonText {
		get { return BtnDn.Text; }
		set { BtnDn.Text = Value; }
	}
	public override string Text {
		get { return mstrText; }
		set {
			mstrText = Value;
			Btn.Text = mstrText;
		}
	}

	public Font ValueEditorFont {
		get { return Btn.Font; }
		set { Btn.Font = Value; }
	}

	public bool IsReverseOperation {
		get { return mblnIsReverseOperation; }
		set { mblnIsReverseOperation = Val; }
	}

	public bool IsUpDownButtonToBeDisabledOnValueChange {
		get { return mblnIsUpDownButtonToBeDisabledOnValuechange; }
		set { mblnIsUpDownButtonToBeDisabledOnValuechange = Val; }
	}

	public EnumValueEditorButtons ButtonClicked {
		get { return mintButtonClicked; }
		set { mintButtonClicked = Val; }
	}

	public bool IsUpDownEnable {
		get { return mblnIsUpDownEnable; }
		set {
			mblnIsUpDownEnable = Val;

			BtnUp.Enabled = Val;
			BtnDn.Enabled = Val;
		}
	}

	public bool IsButtonEnable {
		get { return mblnIsBtnEnable; }
		set {
			mblnIsBtnEnable = Val;

			if (Val == true) {
				BtnUp.Click += BtnUp_Click;
				BtnDn.Click += BtnDn_Click;
				Btn.Click += Btn_Click;
			} else {
				BtnUp.Click -= BtnUp_Click;
				BtnDn.Click -= BtnDn_Click;
				Btn.Click -= Btn_Click;
			}
			//BtnUp.Enabled = Val
			//BtnDn.Enabled = Val
			//Btn.Enabled = Val
		}
	}

	#End Region

	#Region "Private Events"
	private void Btn_Click(System.Object sender, System.EventArgs e)
	{
		if (mblnAvoidProcessing == true) {
			return;
		}
		try {
			mblnAvoidProcessing = true;
			if (!BtnUp == null) {
				BtnUp.Enabled = false;
			}
			if (!BtnDn == null) {
				BtnDn.Enabled = false;
			}
			ButtonClicked = EnumValueEditorButtons.MainButton;
			if (ValueEditorClick != null) {
				ValueEditorClick();
			}
			if (!BtnUp == null) {
				BtnUp.Enabled = true;
			}
			if (!BtnDn == null) {
				BtnDn.Enabled = true;
			}
			mblnAvoidProcessing = false;
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

	private void BtnUp_Click(System.Object sender, System.EventArgs e)
	{
		double dblVal;
		try {
			ButtonClicked = EnumValueEditorButtons.UpButton;
			if (IsUpDownButtonToBeDisabledOnValueChange == true) {
				BtnUp.Enabled = false;
			}

			dblVal = Value;

			if (IsReverseOperation == true) {
				if (dblVal > MinValue) {
					dblVal = dblVal - ChangeFactor;
					if (dblVal <= MaxValue & dblVal >= MinValue) {
						Value = dblVal;
					}
				}
			} else {
				if (dblVal <= MaxValue & dblVal >= MinValue) {
					dblVal = dblVal + ChangeFactor;
					if (dblVal <= MaxValue & dblVal >= MinValue) {
						Value = dblVal;
					}
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
			if (IsUpDownButtonToBeDisabledOnValueChange == true) {
				BtnUp.Enabled = true;
			}
			//---------------------------------------------------------
		}
	}

	private void BtnDn_Click(System.Object sender, System.EventArgs e)
	{
		double dblVal;
		try {
			ButtonClicked = EnumValueEditorButtons.DownButton;
			if (IsUpDownButtonToBeDisabledOnValueChange == true) {
				BtnDn.Enabled = false;
			}

			dblVal = Value;

			if (IsReverseOperation == true) {
				if (dblVal < MaxValue) {
					dblVal = dblVal + ChangeFactor;
					if (dblVal <= MaxValue & dblVal >= MinValue) {
						Value = dblVal;
					}
				}
			} else {
				if (dblVal <= MaxValue & dblVal >= MinValue) {
					dblVal = dblVal - ChangeFactor;
					if (dblVal <= MaxValue & dblVal >= MinValue) {
						Value = dblVal;
					}
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
			if (IsUpDownButtonToBeDisabledOnValueChange == true) {
				BtnDn.Enabled = true;
			}
			//---------------------------------------------------------
		}
	}

	#End Region

	#Region "Functions"

	public void InitializeErrorHandlerObject()
	{
		try {
			gobjErrorHandler.ErrorLogFolder = "ErrorLogs";
			gobjErrorHandler.ErrorLogFileName = CurDir() + "\\" + gobjErrorHandler.ErrorLogFolder + "\\ValueEditorErrorHandler.txt";
			gobjErrorHandler.CompanyName = "Aldys Technologies Pvt. Ltd.";
			gobjErrorHandler.ProductName = "AAS203";
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

	private double funcSetDecimalPlace(double dblValue)
	{
		//=====================================================================
		// Procedure Name        : funcSetDecimalPlace
		// Parameters Passed     : dblValue As Double
		// Returns               : Double
		// Purpose               : 
		// Description           : Set Decimal place
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 03.04.07
		// Revisions             : 
		//=====================================================================
		int i;
		double dblValue1;
		long lngValue;
		long DecimalFactor = 1;
		try {
			funcSetDecimalPlace = dblValue;
			if (DecimalPlace > 0) {
				//lngValue = dblValue
				for (i = 1; i <= DecimalPlace; i++) {
					DecimalFactor = DecimalFactor * 10;
				}
				lngValue = (long)dblValue * DecimalFactor;
				dblValue = lngValue / DecimalFactor;
			} else {
				//lngValue = dblValue
				lngValue = (long)dblValue * DecimalFactor;
				dblValue = lngValue;
			}
			funcSetDecimalPlace = dblValue;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return funcSetDecimalPlace;
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
ValueEditor_Load(object sender, System.EventArgs e)
	{
		BtnUp.Click += BtnUp_Click;
		BtnDn.Click += BtnDn_Click;
		Btn.Click += Btn_Click;
	}

}
