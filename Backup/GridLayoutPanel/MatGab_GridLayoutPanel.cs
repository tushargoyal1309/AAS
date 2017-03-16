
//************************************************************************************************************
// File Header
// File Name 		: GridLayoutPanel.vb
// Author			: Deepak Bhati
// Date/Time			: Thursday, December 02, 2004
// Description		: This component is used to set the grid layout with the
//                     specified number of columns and arranges the controls array
//                     accordingly.
//************************************************************************************************************

 // ERROR: Not supported in C#: OptionDeclaration
public class GridLayoutPanel : Panel
{

	#Region " Component Designer generated code "

	public GridLayoutPanel(System.ComponentModel.IContainer Container)
	{
		 // ERROR: Not supported in C#: ClassReferenceExpression
.New();

		//Required for Windows.Forms Class Composition Designer support
		Container.Add(this);
		InitializeSetting();
	}

	public GridLayoutPanel()
	{
		base.New();

		//This call is required by the Component Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call

	}

	//Component overrides dispose to clean up the component list.
	protected override void Dispose(bool disposing)
	{
		if (disposing) {
			if (!(components == null)) {
				components.Dispose();
			}
		}
		base.Dispose(disposing);
	}

	//Required by the Component Designer

	private System.ComponentModel.IContainer components;
	//NOTE: The following procedure is required by the Component Designer
	//It can be modified using the Component Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		components = new System.ComponentModel.Container();
	}

	#End Region

	#Region " Private Class Member Variables "

	private int mintColumnCount;

	private string mstrErrorText = "";
	private Control[] mControls;
	private int mintControlHSpacing = DefaultControlHSpacing;
	private int mintControlVSpacing = DefaultControlVSpacing;
	private ErrorProvider mobjErr = new ErrorProvider();
	private bool mblnShowError = false;
	private bool mblnSingleRowGrid = false;
	private long mlngStandardId;

	private string mstrSelectedSampleNo;
	#End Region

	#Region " Public Events, Structures, Enums, Constants... "

	public event  ControlClicked;
	public event  ControlMouseEntered;

	#End Region

	#Region " Private Constants "

	private const string ControlCollectionLengthOverflowError = "Column Count Can't Be More than the Objects Collection";
	private const string ControlCollectionLengthZeroError = "Column Count Can't Be Zero";
	private const int DefaultControlHSpacing = 10;

	private const int DefaultControlVSpacing = 10;
	#End Region

	#Region " Public Properties "

	public int ColumnCount {
		get { return mintColumnCount; }
		set { mintColumnCount = Value; }
	}

	public bool SingleRowGrid {
		get { return mblnSingleRowGrid; }
		set { mblnSingleRowGrid = Value; }
	}

	public string ErrorText {
		get { return mstrErrorText; }
		set { mstrErrorText = Value; }
	}

	public int ControlHSpacing {
		get { return mintControlHSpacing; }
		set { mintControlHSpacing = Value; }
	}

	public int ControlVSpacing {
		get { return mintControlVSpacing; }
		set { mintControlVSpacing = Value; }
	}

	public bool ShowError {
		get { return mblnShowError; }
		set { mblnShowError = Value; }
	}

	int mintSelectedIndex;
	public int SelectedIndex {
		get { return mintSelectedIndex; }
		set { mintSelectedIndex = Value; }
	}
	#End Region

	#Region " Public Functions "



	public Control GetCurrentControls(Control[] objControls, string strTag)
	{
		//Public Function GetCurrentControls() As Control
		//=====================================================================
		// Procedure Name        : GetControls
		// Parameters Passed     : controls array
		// Returns               : true or false
		// Purpose               : to assign the controls array to the component
		// Description           : 
		// Assumptions           : 
		// Dependencies          : control array
		// Author                : Sachin Dokhale
		// Created               : Thursday, December 02, 2004
		// Revisions             : 
		//=====================================================================
		Control objCntrl;
		int intControlIndex;

		try {
			if (!IsNothing(mControls)) {
				intControlIndex = 0;
				foreach ( objCntrl in mControls) {
					if (!IsNothing(objCntrl)) {
						//If objControls Is objCntrl Then
						//If CType(objCntrl, RepeatResultsControl).AnalysisParameter = strTag Then
						//If CType(objCntrl, me.ControlCollection).AnalysisParameter.SampNumber = strTag Then
						return objCntrl;

					}
				}
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return null;
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

	public bool GetControls(Control[] objControls)
	{
		//=====================================================================
		// Procedure Name        : GetControls
		// Parameters Passed     : controls array
		// Returns               : true or false
		// Purpose               : to assign the controls array to the component
		// Description           : 
		// Assumptions           : 
		// Dependencies          : control array
		// Author                : Deepak Bhati
		// Created               : Thursday, December 02, 2004
		// Revisions             : 
		//=====================================================================
		Control objCntrl;
		int intControlIndex;

		try {
			mControls = objControls;

			if (!IsNothing(mControls)) {
				intControlIndex = 0;
				foreach ( objCntrl in mControls) {
					if (!IsNothing(objCntrl)) {
						objCntrl.Tag = intControlIndex;
						this.Tag = objCntrl.Tag;
						SelectedIndex = intControlIndex;
						objCntrl.Click += subControlClicked;
						objCntrl.MouseEnter += subControlMouseEntered;
						//AddHandler objCntrl.Click, AddressOf objRepeatResultsControl_RepeatResultClick
						intControlIndex += 1;
					}
				}
			}

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
			//---------------------------------------------------------
		}

	}

	public bool RemoveControls()
	{
		//=====================================================================
		// Procedure Name        : GetControls
		// Parameters Passed     : controls array
		// Returns               : true or false
		// Purpose               : to assign the controls array to the component
		// Description           : 
		// Assumptions           : 
		// Dependencies          : control array
		// Author                : Sachin Dokhale
		// Created               : Thursday, December 02, 2004
		// Revisions             : 
		//=====================================================================
		Control objCntrl;
		int intControlIndex;

		try {
			if (!IsNothing(mControls)) {
				intControlIndex = 0;
				foreach ( objCntrl in mControls) {
					if (!IsNothing(objCntrl)) {
						// If objControls Is objCntrl Then
						objCntrl.Visible = false;
						//End If
					}
				}
			}

			mControls = null;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return null;
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

	public bool ShowGrid()
	{
		//=====================================================================
		// Procedure Name        : ShowGrid
		// Parameters Passed     : None
		// Returns               : true or false
		// Purpose               : To show the layout with controls on the panel
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : Thursday, December 02, 2004
		// Revisions             : 
		//=====================================================================
		try {
			if (!mControls == null) {
				if (ArrangeControls(mControls) == true) {
					return true;
				} else {
					return false;
				}
			}

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

	public bool ArrangeControls(Control[] objCtrl)
	{
		//=====================================================================
		// Procedure Name        : ArrangeControls
		// Parameters Passed     : None
		// Returns               : true or false
		// Purpose               : To show the layout with controls on the panel
		// Description           : if single row grid is set the set the 
		//                         columncount =number of controls otherwise divide total 
		//                         number of controls by the column count set the user
		//                         and arrange all the controls by using horizontal and 
		//                         vertical spacing and size of the controls
		//
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : Thursday, December 02, 2004
		// Revisions             : 
		//=====================================================================
		//---if single row grid is set the set the columncount =number of controls
		//---otherwise divide total number of controls by the column count set the user
		//---and arrange all the controls by using horizontal and vertical spacing 
		//---and size of the controls
		int colObjects;
		int rowCounter;
		int ColCounter;
		int ObjIndex = 0;
		double RowCount;
		int unEvenObjectsCount;
		int unEvenObjectsCounter = 0;
		bool CheckForUnEvenObjects;

		try {
			if (SingleRowGrid == true) {
				ColumnCount = objCtrl.Length;
			}

			if (ColumnCount > objCtrl.Length) {
				ErrorText = ControlCollectionLengthOverflowError;
				if (ShowError == true) {
					mobjErr.SetError(this, ControlCollectionLengthOverflowError);
					this.BorderStyle = BorderStyle.FixedSingle;
				}
				return false;

			} else if (ColumnCount <= 0) {
				ErrorText = ControlCollectionLengthZeroError;
				if (ShowError == true) {
					mobjErr.SetError(this, ControlCollectionLengthZeroError);
					this.BorderStyle = BorderStyle.FixedSingle;
				}
				return false;

			} else {
				switch (ColumnCount) {
					case 1:
						for (colObjects = 0; colObjects <= objCtrl.Length - 1; colObjects++) {
							if (colObjects == 0) {
								if (!objCtrl(colObjects) == null) {
									objCtrl(colObjects).Location = new Point(0, 0);
								}
							} else {
								if (!objCtrl(colObjects) == null) {
									objCtrl(colObjects).Location = new Point(objCtrl(colObjects - 1).Location.X, objCtrl(colObjects - 1).Location.Y + objCtrl(colObjects - 1).Height + ControlVSpacing);
								}
							}
							if (!objCtrl(colObjects) == null) {
								this.SuspendLayout();
								this.Controls.Add(objCtrl(colObjects));
								this.ResumeLayout();
							}

						}

					case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
1:

						RowCount = (objCtrl.Length) / ColumnCount;

						unEvenObjectsCount = (objCtrl.Length) - (Fix(RowCount) * ColumnCount);

						if (unEvenObjectsCount > 0) {
							RowCount = Fix(RowCount) + 1;
							CheckForUnEvenObjects = true;
						} else {
							CheckForUnEvenObjects = false;
						}

						for (rowCounter = 0; rowCounter <= Fix(RowCount) - 1; rowCounter++) {
							for (ColCounter = 0; ColCounter <= ColumnCount - 1; ColCounter++) {
								//If Trim(CType(objCtrl(ObjIndex), ShadeControl.ShadeControl).ShadeLabel) = "211G30Y-5010" Then
								//MessageBox.Show("")
								//End If
								if (rowCounter == 0) {
									if (ColCounter == 0) {
										if (!objCtrl(ObjIndex) == null) {
											objCtrl(ObjIndex).Location = new Point(0, 0);
										}
									} else {
										if (!objCtrl(ObjIndex) == null) {
											objCtrl(ObjIndex).Location = new Point(objCtrl(ObjIndex - 1).Location.X + objCtrl(ObjIndex - 1).Width + ControlHSpacing, objCtrl(ObjIndex - 1).Location.Y);
										}
									}
								} else {
									if (unEvenObjectsCount > 0) {
										if (rowCounter == Int(Fix(RowCount) - 1)) {
											unEvenObjectsCounter = unEvenObjectsCounter + 1;
										}
									}

									if (ColCounter == 0) {
										if (!objCtrl(ObjIndex) == null) {
											objCtrl(ObjIndex).Location = new Point(objCtrl(ObjIndex - (ColumnCount - 1)).Location.X - objCtrl(ObjIndex - 1).Width - ControlHSpacing, objCtrl(ObjIndex - 1).Location.Y + objCtrl(ObjIndex - 1).Height + ControlVSpacing);
										}
									} else {
										if (!objCtrl(ObjIndex) == null) {
											objCtrl(ObjIndex).Location = new Point(objCtrl(ObjIndex - 1).Location.X + objCtrl(ObjIndex - 1).Width + ControlHSpacing, objCtrl(ObjIndex - 1).Location.Y);
										}
									}

								}

								if (!objCtrl(ObjIndex) == null) {
									this.SuspendLayout();
									this.Controls.Add(objCtrl(ObjIndex));
									this.ResumeLayout();
								}

								ObjIndex = ObjIndex + 1;
								if (CheckForUnEvenObjects == true) {
									if (unEvenObjectsCounter == unEvenObjectsCount) {
										break; // TODO: might not be correct. Was : Exit For
									}
								}
							}

						}

				}

			}

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
			//---------------------------------------------------------
		}

	}

	#End Region

	#Region " Private Functions "

	private void subControlClicked(object sender, EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : subControlClicked
		// Parameters Passed     : Object, EventArgs 
		// Returns               : None
		// Purpose               : to raise to the parent of this component
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : Tuesday, December 14, 2004
		// Revisions             : 
		//=====================================================================
		int intControlIndex;

		try {
			intControlIndex = (int)((Control)sender).Tag;
			SelectedIndex = intControlIndex;
			if (ControlClicked != null) {
				ControlClicked(intControlIndex);
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

	private void subControlMouseEntered(object sender, EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : subControlMouseEntered
		// Parameters Passed     : Object, EventArgs 
		// Returns               : None
		// Purpose               : to raise to the parent of this component
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : Tuesday, December 14, 2004
		// Revisions             : 
		//=====================================================================
		int intControlIndex;

		try {
			intControlIndex = (int)((Control)sender).Tag;
			SelectedIndex = intControlIndex;
			if (ControlMouseEntered != null) {
				ControlMouseEntered(intControlIndex);
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

	private void objRepeatResultsControl_RepeatResultClick()
	{
		mstrSelectedSampleNo = SelectedIndex;
	}
	#End Region

}
