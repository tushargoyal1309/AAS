using System.ComponentModel;

public class NumberValidator : System.Windows.Forms.TextBox
{

	//**********************************************************************
	// File Header       : NumberValidator
	// File Name 		: NumberValidator.vb
	// Author			: Deepak Bhati
	// Date/Time			: 01.10.04
	// Description		: This is a control for the validation of numbers.
	//                     This control can work in three validation type modes
	//                     1.AlphaNumeric (Default Mode)
	//                     2.Integer Only
	//                     3.Double Only
	//************************************************************************************************************

	#Region " Windows Form Designer generated code "

	public NumberValidator()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
		ValidationType = Validations.AlphaNumeric;
	}

	//UserControl overrides dispose to clean up the component list.
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
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		//
		//Validator
		//
		this.Name = "NumberValidator";
		this.Size = new System.Drawing.Size(80, 20);

	}

	#End Region

	#Region "Private Variables"
	private System.Drawing.Color mObjErrorColor = new System.Drawing.Color();
	private bool mBoolRangeValidation = false;
	private int mIntValidationType;
	private int mIntDigitsAfterDecimalPoint = 0;
	private double mDblMinLimit = 0;
	private double mDblMaxLimit = 0;
	private int mIntDecimalCount;
	private string mStrErrorMessage;
	public event  ValidationStatus;
		#End Region
	private bool mBoolValidated = true;

	#Region "Properties"
	//The property to set the errormessage
	[Description("Error Message Sent by NumberValidator"), Category("Action")]
	public string ErrorMessage {
		get { return mStrErrorMessage; }
		set { mStrErrorMessage = Value; }
	}

	//The property to set the errorcolor of the control
	[Description("Error Color to display on Error"), Category("Action")]
	public System.Drawing.Color ErrorColor {
		get { return mObjErrorColor; }
		set { mObjErrorColor = Value; }
	}

	//The property to set whether range validation is enabled ot not.

	[Description("To set range validation enable or disable"), Category("Action")]
	public bool RangeValidation {
		get { return mBoolRangeValidation; }
		set { mBoolRangeValidation = Value; }
	}

	//The Enumeration types
	public enum Validations
	{
		AlphaNumeric = 1,
		IntegerOnly = 2,
		DoubleOnly = 3
	}

	//The property to set the validation type
	[Description("To set the range validation type , default is Alphanumeric"), Category("Action")]
	public Validations ValidationType {
		get { return mIntValidationType; }
		set { mIntValidationType = Value; }
	}

	//The property to set the minimum range of number
	[Description("To set the minimum value for range validation"), Category("Action")]
	public double MinimumRange {
		get { return mDblMinLimit; }
		set { mDblMinLimit = Value; }
	}

	//The property to set the maximum range of number
	[Description("To set the maximum value for range validation"), Category("Action")]
	public double MaximumRange {
		get { return mDblMaxLimit; }
		set { mDblMaxLimit = Value; }
	}

	//The property to set the number of digits after decimal point.
	[Description("To set the number of digits after decimal point"), Category("Action")]
	public int DigitsAfterDecimalPoint {
		get { return mIntDigitsAfterDecimalPoint; }
		set { mIntDigitsAfterDecimalPoint = Value; }
	}

	public enum Status
	{
		Validated = 1,
		NotValidated = 2
	}

	#End Region

	#Region "Control Events"

	private void  // ERROR: Handles clauses are not supported in C#
Validator_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
	{
		//=====================================================================
		// Procedure Name        : NumberValidator_KeyPress
		// Parameters Passed     : Object,KeyPressEventArgs
		// Returns               : 
		// Purpose               : to validate the control for integer and double only types
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 01-Oct-2004 3:00 pm
		// Revisions             : 1
		//=====================================================================
		string mStrPressedKey;
		//Dim decimalerr As Boolean = False
		string strSelectedText;

		try {
			strSelectedText = this.SelectedText;
			if (strSelectedText.Length > 0) {
				this.SelectedText = "";
			}

			mStrPressedKey = e.KeyChar.ToString;
			switch (mIntValidationType) {
				case 1:
					//Alphnumeric Validation (Default)

					//Do nothing
					ErrorMessage = "";
					mBoolValidated = true;
					if (ValidationStatus != null) {
						ValidationStatus(Status.Validated, ErrorMessage);

					}

				case 2:
					// integer only validation 

					if ((Asc(e.KeyChar) >= 48 & Asc(e.KeyChar) <= 57) | Asc(e.KeyChar) == 8 | Asc(e.KeyChar) == 13 | Asc(e.KeyChar) == 45) {
						if ((IsMinusPresent() == true & Asc(e.KeyChar) == 45) | (TotalDigitsCount() != 0 & Asc(e.KeyChar) == 45)) {
							ErrorMessage = "Not allowed";
							mBoolValidated = false;
							if (ValidationStatus != null) {
								ValidationStatus(Status.NotValidated, ErrorMessage);
							}
						} else {
							ErrorMessage = "";
							mBoolValidated = true;
							if (ValidationStatus != null) {
								ValidationStatus(Status.Validated, ErrorMessage);
							}
						}
					} else {
						ErrorMessage = "'" + e.KeyChar + "'" + " is Not an Integer value.";
						mBoolValidated = false;
						if (ValidationStatus != null) {
							ValidationStatus(Status.NotValidated, ErrorMessage);
						}

					}
				case 3:
					// double only validation

					if ((Asc(e.KeyChar) >= 48 & Asc(e.KeyChar) <= 57) | Asc(e.KeyChar) == 8 | Asc(e.KeyChar) == 46 | Asc(e.KeyChar) == 13 | Asc(e.KeyChar) == 45) {
						//If (IsDecimalPointPresent() = True And Asc(e.KeyChar) = 46) Or (Trim(Me.Text) = "" And Asc(e.KeyChar) = 46) Or (IsMinusPresent() = True And Asc(e.KeyChar) = 45) Or (TotalDigitsCount() <> 0 And Asc(e.KeyChar) = 45) Then
						if ((IsDecimalPointPresent() == true & Asc(e.KeyChar) == 46) | (IsMinusPresent() == true & Asc(e.KeyChar) == 45) | (TotalDigitsCount() != 0 & Asc(e.KeyChar) == 45)) {
							mBoolValidated = false;
							ErrorMessage = "Not a double value";
							if (ValidationStatus != null) {
								ValidationStatus(Status.NotValidated, ErrorMessage);
							}
						} else if (DigitsAfterDecimalCount() == DigitsAfterDecimalPoint) {
							//decimalerr = True
							if (Asc(e.KeyChar) == 8 | Trim(this.Text) == "") {
								mBoolValidated = true;
								ErrorMessage = "";
								if (ValidationStatus != null) {
									ValidationStatus(Status.Validated, ErrorMessage);
								}
							} else {
								mBoolValidated = false;
								ErrorMessage = "Not Allowed";
								if (ValidationStatus != null) {
									ValidationStatus(Status.NotValidated, ErrorMessage);
								}
							}
						} else {
							ErrorMessage = "";
							mBoolValidated = true;
							if (ValidationStatus != null) {
								ValidationStatus(Status.Validated, ErrorMessage);
							}
						}
					} else {
						ErrorMessage = "'" + e.KeyChar + "'" + " is Not an Double value.";
						mBoolValidated = false;
						if (ValidationStatus != null) {
							ValidationStatus(Status.NotValidated, ErrorMessage);
						}

					}
				//If decimalerr = True Then
				//    mBoolValidated = False
				//End If

			}

			if (mBoolValidated == true) {
				this.ReadOnly = false;
				this.BackColor = System.Drawing.Color.White;
			} else {
				this.ReadOnly = true;
				this.BackColor = mObjErrorColor;
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
Validator_Leave(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : NumberValidator_Leave
		// Parameters Passed     : Object,EventArgs
		// Returns               : 
		// Purpose               : To refresh the control
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 01-Oct-2004 5:00 pm
		// Revisions             : 1
		//=====================================================================
		try {
			if (mBoolValidated == true) {
				this.ReadOnly = false;
				this.BackColor = System.Drawing.Color.White;
				if (ValidationStatus != null) {
					ValidationStatus(Status.Validated, ErrorMessage);
				}
			} else {
				this.ReadOnly = true;
				this.BackColor = mObjErrorColor;
				if (ValidationStatus != null) {
					ValidationStatus(Status.NotValidated, ErrorMessage);
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
Validator_Keyup(object sender, System.Windows.Forms.KeyEventArgs e)
	{
		//=====================================================================
		// Procedure Name        : Validator_Keyup
		// Parameters Passed     : Object,KeyEventArgs
		// Returns               : None
		// Purpose               : to validate the control for range
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : Tuesday, December 21, 2004
		// Revisions             : 
		//=====================================================================
		int min = 0;
		int max = 0;
		double mDblEnteredValue = 0;
		try {
			min = Fix(MinimumRange);
			max = Fix(MaximumRange);
			if (RangeValidation == true) {
				if (!(Trim(this.Text) == "" | Trim(this.Text) == ".")) {
					if (!Trim(this.Text) == ".") {
						if (!Trim(this.Text) == "-") {
							mDblEnteredValue = (double)Trim(this.Text);
						}
					}

					if (!(mDblEnteredValue >= MinimumRange & mDblEnteredValue <= MaximumRange)) {
						mBoolValidated = false;
						if (Asc(e.KeyCode) == 8) {
							this.ReadOnly = false;
						}
						if (ValidationType == Validations.DoubleOnly) {
							ErrorMessage = "Value Not Within The Range " + MinimumRange + " To " + MaximumRange;
						}
						if (ValidationType == Validations.IntegerOnly) {
							ErrorMessage = "Value Not Within The Range " + min + " To " + max;
						}
						if (ValidationStatus != null) {
							ValidationStatus(Status.NotValidated, ErrorMessage);
						}
					} else {
						mBoolValidated = true;
						ErrorMessage = "";
						if (ValidationStatus != null) {
							ValidationStatus(Status.Validated, ErrorMessage);
						}
					}
				}
			}

			if (mBoolValidated == true) {
				this.ReadOnly = false;
				this.BackColor = System.Drawing.Color.White;
			} else {
				this.ReadOnly = true;
				this.BackColor = mObjErrorColor;
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

	#End Region

	#Region "Private Functions"

	private int DigitsAfterDecimalCount()
	{
		//=====================================================================
		// Procedure Name        : DigitsAfterDecimalCount
		// Parameters Passed     : Nothing
		// Returns               : Integer value
		// Purpose               : To return the number of digits after decimal point
		// Description           : This function is used to return the number of digits after decimal point.
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 09-Sep-2004 5:10 pm
		// Revisions             : 1
		//=====================================================================

		int intFullTextLength;
		int intPlaceOfDecimalPoint;

		try {
			if (IsDecimalPointPresent() == true) {
				intFullTextLength = this.Text.Length;
				intPlaceOfDecimalPoint = (int)this.Text.IndexOf(".") + 1;
				mIntDecimalCount = intFullTextLength - intPlaceOfDecimalPoint;
				return mIntDecimalCount;
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

	private bool IsDecimalPointPresent()
	{
		//=====================================================================
		// Procedure Name        : IsDecimalPointPresent
		// Parameters Passed     : Nothing
		// Returns               : Boolean value
		// Purpose               : To check whether decimal point is there in the textbox or not
		// Description           : This function is used to check the presence of decimal point
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 09-Sep-2004 5:00 pm
		// Revisions             : 1
		//=====================================================================
		int intFullTextLength;
		int intCount;
		try {
			intFullTextLength = this.Text.Length;
			for (intCount = 0; intCount <= intFullTextLength - 1; intCount++) {
				if (this.Text.Chars(intCount) == ".") {
					return true;
				}
			}
			return false;

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

	private bool IsMinusPresent()
	{
		//=====================================================================
		// Procedure Name        : IsMinusPresent
		// Parameters Passed     : Nothing
		// Returns               : Boolean value
		// Purpose               : To check whether decimal point is there in the textbox or not
		// Description           : This function is used to check the presence of decimal point
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 09-Sep-2004 5:00 pm
		// Revisions             : 1
		//=====================================================================
		int intFullTextLength;
		int intCount;
		try {
			intFullTextLength = this.Text.Length;
			for (intCount = 0; intCount <= intFullTextLength - 1; intCount++) {
				if (this.Text.Chars(intCount) == "-") {
					return true;
				}
			}
			return false;

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

	private int TotalDigitsCount()
	{
		//=====================================================================
		// Procedure Name        : TotalDigitsCount
		// Parameters Passed     : Nothing
		// Returns               : Integer value
		// Purpose               : To return the total number of digits 
		// Description           : This function is used to return the number of digits 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 21-Dec-2004 5:10 pm
		// Revisions             : 1
		//=====================================================================
		try {
			return (int)Trim(this.Text).Length();
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
