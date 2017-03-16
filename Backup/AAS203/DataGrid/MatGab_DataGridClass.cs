using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text;
//Imports ColorAnalysis.Common

public class DataGridClass : IDisposable
{
	//****************************************************************************
	// File Name 		:   DataGridClass
	// Author			:   M.Kamal      
	// Date/Time			:   03-Sept-2004
	// Description		:   Class is used for setting the column and Grid Style
	//****************************************************************************

	#Region " Public Enums, Structures, ... "

	public enum ColumnDataType
	{
		Text = 1,
		Color = 2
	}

	public enum enumColumnType
	{
		TextBoxColumn = 1,
		BoolColumn = 2
	}

	public enum enumControl
	{
		None = 0,
		TextBox = 1,
		CheckBox = 2,
		ComboBox = 3,
		RadioButton = 4,
		DatePicker = 5,
		DataGrid = 6,
		ProgressBar = 7,
		Label = 8
	}

	#End Region

	#Region " Class Variables "

	private IntPtr Handle;
	// Other managed resource this class uses.
	private component component = new component();
	// Track whether Dispose has been called.
	private bool disposed = false;
	private bool mblnAllowNew;
	private DataView mobjDataView = new DataView();
	private bool mblnAdjustRowWidth;
	private DataGridTextBoxColumn mobjTextColumn;
	private clsDataGridTextBoxColumn mobjClsDataGridTextBoxColumn;

	private DataGridBoolColumn mobjBoolColumn;
	//Private Shared mintColumnIndicesToBeValidated() As Integer

	private static structValidationData[] mobjValidationData;
	private struct structValidationData
	{
		public int intColumnIndex;
		public enumValidationType intColumnDataType;
	}

	public enum enumValidationType
	{
		Number,
		Text
	}


	public DataGridTableStyle SetDataGridTableStyle;
	#End Region

	#Region " Constructors "

	public DataGridClass(string FileName)
	{
		//=====================================================================
		// Procedure Name        : new Constructor
		// Parameters Passed     : FileName 
		// Returns               : 
		// Purpose               : To read the default properties from the File
		// Description           : To read the default properties from the File
		//                          To Assign Default properties to the the Grid
		// Assumptions           : 1. If file is not present it will Set default 
		//                           properties set at design time
		// Dependencies          : 
		// Author                : M.Kamal
		// Created               : 18-Sept-2004 08:23 PM
		// Revisions             : 
		//=====================================================================
		//-----1. Assign AllowNew to true as default Value
		//-----2. Assign AdjustColumnWidth to False as default Value
		//-----3. Read The Properties from the file and assign it to SetDataGridTableStyle

		try {
			//-----1. Assign AllowNew to False as default Value
			mblnAllowNew = false;

			//-----2. Assign AdjustColumnWidth to False as default Value
			mblnAdjustRowWidth = false;

			//-----3. Read The Properties from the file and assign it to SetDataGridTableStyle
			this.ReadDataGridProperties(FileName);

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

	#Region " Dispose and Garbage Collector Code "

	public void IDisposable.Dispose()
	{
		Dispose(true);
		// This object will be cleaned up by the Dispose method.
		// Therefore, you should call GC.SupressFinalize to
		// take this object off the finalization queue 
		// and prevent finalization code for this object
		// from executing a second time.

		// GC.SuppressFinalize(Me)

	}

	// Dispose(bool disposing) executes in two distinct scenarios.
	// If disposing equals true, the method has been called directly
	// or indirectly by a user's code. Managed and unmanaged resources
	// can be disposed.
	// If disposing equals false, the method has been called by the 
	// runtime from inside the finalizer and you should not reference 
	// other objects. Only unmanaged resources can be disposed.
	private void Dispose(bool disposing)
	{
		// Check to see if Dispose has already been called.
		if (!this.disposed) {
			// If disposing equals true, dispose all managed 
			// and unmanaged resources.
			if (disposing) {
				// Dispose managed resources.
				component.Dispose();

			}

			// Call the appropriate methods to clean up 
			// unmanaged resources here.
			// If disposing is false, 
			// only the following code is executed.
			CloseHandle(Handle);
			Handle = IntPtr.Zero;
		}
		disposed = true;
	}
	[System.Runtime.InteropServices.DllImport("Kernel32")]
	private static Boolean CloseHandle(IntPtr handle)
	{
	}

	// This finalizer will run only if the Dispose method 
	// does not get called.
	// It gives your base class the opportunity to finalize.
	// Do not provide finalize methods in types derived from this class.
	protected override void Finalize()
	{
		// Do not re-create Dispose clean-up code here.
		// Calling Dispose(false) is optimal in terms of
		// readability and maintainability.
		Dispose(false);
		base.Finalize();
	}

	#End Region

	#Region " Private Functions "

	private void ReadDataGridProperties(string FileName)
	{
		//=====================================================================
		// Procedure Name        : ReadDataGridProperties
		// Parameters Passed     : FileName
		// Returns               : 
		// Purpose               : Reads the Default properties from the File
		// Description           :
		//---- 1. Check for the existance of the file and then open it
		//---- 2. Read the file line by line and assign it to TableStyle
		// Assumptions           :
		// Dependencies          : 
		// Author                : M.Kamal
		// Created               : 18-Sept-2004 08:23 PM
		// Revisions             : 
		//=====================================================================
		//---- 1. Check for the existance of the file and then open it
		//---- 2. Read the file line by line and assign it to TableStyle
		try {
			string strFileString;
			string[] strProperty;
			string[] strRGBValues;

			SetDataGridTableStyle = new DataGridTableStyle();

			//---- 1. Check for the existance of the file and then open it
			if (File.Exists(Application.StartupPath + "\\" + FileName) == true) {
				FileOpen(1, Application.StartupPath + "\\" + FileName, OpenMode.Input);

				while (!EOF(1)) {
					//---- 2. Read the file line by line and assign it to TableStyle
					strFileString = LineInput(1);
					strProperty = strFileString.Split("=");
					switch (strProperty(0).Trim) {
						case "AllowSorting":
							SetDataGridTableStyle.AllowSorting = (bool)strProperty(1).Trim;
						case "AlternatingBackColor":
							try {
								SetDataGridTableStyle.AlternatingBackColor = Color.FromName(strProperty(1).Trim);
							} catch (ArgumentException ex) {
								strRGBValues = strProperty(1).Split(",");
								SetDataGridTableStyle.AlternatingBackColor = Color.FromArgb((int)strRGBValues(0).Trim, (int)strRGBValues(1).Trim, (int)strRGBValues(2).Trim);
							}
						case "BackColor":
							//SetDataGridTableStyle.BackColor = Color.FromName(strProperty(1).Trim)
							try {
								SetDataGridTableStyle.BackColor = Color.FromName(strProperty(1).Trim);
							} catch (ArgumentException ex) {
								strRGBValues = strProperty(1).Split(",");
								SetDataGridTableStyle.BackColor = Color.FromArgb((int)strRGBValues(0).Trim, (int)strRGBValues(1).Trim, (int)strRGBValues(2).Trim);
							}
						case "HeaderBackColor":
							//SetDataGridTableStyle.HeaderBackColor = Color.FromName(strProperty(1).Trim)
							try {
								SetDataGridTableStyle.HeaderBackColor = Color.FromName(strProperty(1).Trim);
							} catch (ArgumentException ex) {
								strRGBValues = strProperty(1).Split(",");
								SetDataGridTableStyle.HeaderBackColor = Color.FromArgb((int)strRGBValues(0).Trim, (int)strRGBValues(1).Trim, (int)strRGBValues(2).Trim);
							}
						case "HeaderForeColor":
							//SetDataGridTableStyle.HeaderForeColor = Color.FromName(strProperty(1).Trim)
							try {
								SetDataGridTableStyle.HeaderForeColor = Color.FromName(strProperty(1).Trim);
							} catch (ArgumentException ex) {
								strRGBValues = strProperty(1).Split(",");
								SetDataGridTableStyle.HeaderForeColor = Color.FromArgb((int)strRGBValues(0).Trim, (int)strRGBValues(1).Trim, (int)strRGBValues(2).Trim);
							}
						case "ReadOnly":
							SetDataGridTableStyle.ReadOnly = (bool)strProperty(1).Trim;
						case "RowHeadersVisible":
							SetDataGridTableStyle.RowHeadersVisible = (bool)strProperty(1).Trim;
						case "SelectionBackColor":
							//SetDataGridTableStyle.SelectionBackColor = Color.FromName(strProperty(1).Trim)
							try {
								SetDataGridTableStyle.SelectionBackColor = Color.FromName(strProperty(1).Trim);
							} catch (ArgumentException ex) {
								strRGBValues = strProperty(1).Split(",");
								SetDataGridTableStyle.SelectionBackColor = Color.FromArgb((int)strRGBValues(0).Trim, (int)strRGBValues(1).Trim, (int)strRGBValues(2).Trim);
							}
						case "SelectionForeColor":
							//SetDataGridTableStyle.SelectionForeColor = Color.FromName(strProperty(1).Trim)
							try {
								SetDataGridTableStyle.SelectionForeColor = Color.FromName(strProperty(1).Trim);
							} catch (ArgumentException ex) {
								strRGBValues = strProperty(1).Split(",");
								SetDataGridTableStyle.SelectionForeColor = Color.FromArgb((int)strRGBValues(0).Trim, (int)strRGBValues(1).Trim, (int)strRGBValues(2).Trim);
							}
						case "GridLineColor":
							//SetDataGridTableStyle.GridLineColor = Color.FromName(strProperty(1).Trim)
							try {
								SetDataGridTableStyle.GridLineColor = Color.FromName(strProperty(1).Trim);
							} catch (ArgumentException ex) {
								strRGBValues = strProperty(1).Split(",");
								SetDataGridTableStyle.GridLineColor = Color.FromArgb((int)strRGBValues(0).Trim, (int)strRGBValues(1).Trim, (int)strRGBValues(2).Trim);
							}
						case "ForeColor":
							//SetDataGridTableStyle.ForeColor = Color.FromName(strProperty(1).Trim)
							try {
								SetDataGridTableStyle.ForeColor = Color.FromName(strProperty(1).Trim);
							} catch (ArgumentException ex) {
								strRGBValues = strProperty(1).Split(",");
								SetDataGridTableStyle.ForeColor = Color.FromArgb((int)strRGBValues(0).Trim, (int)strRGBValues(1).Trim, (int)strRGBValues(2).Trim);
							}
						case "ColumnHeadersVisible":
							SetDataGridTableStyle.ColumnHeadersVisible = (bool)strProperty(1).Trim;
					}
				}
				FileClose(1);
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			FileClose(1);
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

	#Region " Public Properties "

	public bool AdjustColumnWidthToGrid {
		//=====================================================================
		// Procedure Name        : AdjustColumnWidthToGrid
		// Parameters Passed     : 
		// Returns               : 
		// Purpose               : To set the Width 
		// Description           : To set the width of each column 
		//                         According to the Width of the Grid
		// Assumptions           : 
		// Dependencies          : 
		// Author                : M.Kamal
		// Created               : 18-Sept-2004 08:23 PM
		// Revisions             : 
		//=====================================================================
		get { return mblnAdjustRowWidth; }
		set { mblnAdjustRowWidth = Value; }
	}

	public bool AllowNew {
		//=====================================================================
		// Procedure Name        : AllowNew
		// Parameters Passed     : 
		// Returns               : 
		// Purpose               : To allow the creation of new Row  
		// Description           : To allow the creation of new Row
		//                         
		// Assumptions           : By default it is False
		// Dependencies          : 
		// Author                : M.Kamal
		// Created               : 18-Sept-2004 08:23 PM
		// Revisions             : 
		//=====================================================================
		get { return mblnAllowNew; }
		set { mblnAllowNew = Value; }
	}

	#End Region

	#Region " Public  Functions "

	public void SetDataGridProperties(ref DataGrid DataGrid, ref DataView DataSource)
	{
		//=====================================================================
		// Procedure Name        : SetDataGridProperties
		// Parameters Passed     : DataGrid , DataSource 
		// Returns               : 
		// Purpose               : Sets the properties to the DataGrid
		// Description           :
		//1. Assign DataSource and allownew property to the dataGrid
		//2. Assign AdjustColumnWidth property to the Grid
		//3. Assign Table Style to the DataGrid

		// Assumptions           :This function should be called after allthe properties are set 
		// Dependencies          : 
		// Author                : M.Kamal
		// Created               : 18-Sept-2004 08:23 PM
		// Revisions             : 
		//=====================================================================


		//---1. Assign DataSource and allownew property to the dataGrid
		//---2. Assign AdjustColumnWidth property to the Grid
		//---3. Assign Table Style to the DataGrid

		try {
			//---1. Assign DataSource and allownew property to the dataGrid
			if (DataSource.Table.TableName == "") {
				DataSource.Table.TableName = "Table";
			}

			DataGrid.TableStyles.Clear();
			// DataSource.AllowNew = mblnAllowNew

			DataGrid.DataSource = DataSource;
			//mobjDataView
			SetDataGridTableStyle.MappingName = DataSource.Table.TableName;
			//---2. Assign AdjustColumnWidth property to the Grid
			if (mblnAdjustRowWidth == true) {
				if (SetDataGridTableStyle.RowHeadersVisible == true) {
					if (DataGrid.VisibleRowCount >= DataSource.Table.Rows.Count) {
						SetDataGridTableStyle.PreferredColumnWidth = ((DataGrid.Width - DataGrid.RowHeaderWidth) / DataSource.Table.Columns.Count) - 2;
					} else {
						SetDataGridTableStyle.PreferredColumnWidth = ((DataGrid.Width - DataGrid.RowHeaderWidth) / DataSource.Table.Columns.Count) - 11;
					}
				} else {
					if (DataSource.Table.Rows.Count > 0) {
						if (DataGrid.VisibleRowCount >= DataSource.Table.Rows.Count) {
							SetDataGridTableStyle.PreferredColumnWidth = (DataGrid.Width / DataSource.Table.Columns.Count) - 1;
						} else {
							SetDataGridTableStyle.PreferredColumnWidth = (DataGrid.Width / DataSource.Table.Columns.Count) - 10;
						}
					}
				}
			}

			//---3. Assign Table Style to the DataGrid
			DataGrid.TableStyles.Add(SetDataGridTableStyle);

			//=====================================================================
			// Added BY Mangesh Shardul on 02-May-2005
			//=====================================================================
			//---4. Numerically Validate DataGrid
			int intColumnCounter = 0;
			structValidationData[] objValidationData;
			int intIndexCounter;

			 // ERROR: Not supported in C#: ReDimStatement

			intIndexCounter = 0;

			for (intColumnCounter = 0; intColumnCounter <= SetDataGridTableStyle.GridColumnStyles.Count - 1; intColumnCounter++) {

				if (!SetDataGridTableStyle.GridColumnStyles(intColumnCounter).ReadOnly == true) {
					string strColumnName = SetDataGridTableStyle.GridColumnStyles(intColumnCounter).MappingName;

					switch (Type.GetTypeCode(DataSource.Table.Columns(strColumnName).DataType)) {
						case TypeCode.Decimal:
						case TypeCode.Double:
						case TypeCode.Int32:
						case TypeCode.Int64:
						case TypeCode.Single:

							objValidationData(intIndexCounter).intColumnIndex = intColumnCounter;
							objValidationData(intIndexCounter).intColumnDataType = enumValidationType.Number;

							intIndexCounter += 1;
						case TypeCode.String:
						case TypeCode.Char:
							objValidationData(intIndexCounter).intColumnIndex = intColumnCounter;
							objValidationData(intIndexCounter).intColumnDataType = enumValidationType.Text;

							intIndexCounter += 1;
					}

				}
			}

			if (objValidationData.Length > 0) {
				Array.Resize(ref objValidationData, intIndexCounter);
				this.NumericValidateGrid(DataGrid, objValidationData);
			}
		//=====================================================================

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

	//, ByRef DataGridStyle As DataGridTableStyle)
	public void SetDataGridProperties(ref DataGrid DataGrid, ref DataTable DataSource)
	{
		//=====================================================================
		// Procedure Name        : SetDataGridProperties
		// Parameters Passed     : DataGrid , DataSource 
		// Returns               : 
		// Purpose               : Sets the properties to the DataGrid
		// Description           : 1. Assign DataSource and allownew property to the dataGrid
		//                         2. Assign AdjustColumnWidth property to the Grid
		//                         3. Assign Table Style to the DataGrid
		//                         4. Numerically Validate DataGrid
		// Assumptions           : This function should be called after 
		//                           all the properties are set 
		// Dependencies          : 
		// Author                : M.Kamal
		// Created               : 18-Sept-2004 08:23 PM
		// Revisions             : 2
		// Revision By           : Mangesh S. on 02-May-2005
		// Revisison For         : Added 4th Step of description
		//=====================================================================
		//---1. Assign DataSource and allownew property to the dataGrid
		//---2. Assign AdjustColumnWidth property to the Grid
		//---3. Assign Table Style to the DataGrid
		//---4. Numerically Validate DataGrid

		try {
			//---1. Assign DataSource and allownew property to the dataGrid
			if (DataSource.TableName == "") {
				DataSource.TableName = "Table";
			}

			DataGrid.TableStyles.Clear();
			mobjDataView.Table = DataSource;
			mobjDataView.AllowNew = mblnAllowNew;
			DataGrid.DataSource = mobjDataView;
			SetDataGridTableStyle.MappingName = DataSource.TableName;

			//---2. Assign AdjustColumnWidth property to the Grid
			if (mblnAdjustRowWidth == true) {
				if (SetDataGridTableStyle.RowHeadersVisible == true) {
					if (DataGrid.VisibleRowCount >= DataSource.Rows.Count) {
						SetDataGridTableStyle.PreferredColumnWidth = ((DataGrid.Width - DataGrid.RowHeaderWidth) / DataSource.Columns.Count) - 2;
					} else {
						SetDataGridTableStyle.PreferredColumnWidth = ((DataGrid.Width - DataGrid.RowHeaderWidth) / DataSource.Columns.Count) - 11;
					}
				} else {
					if (DataGrid.VisibleRowCount >= DataSource.Rows.Count) {
						SetDataGridTableStyle.PreferredColumnWidth = (DataGrid.Width / DataSource.Columns.Count) - 1;
					} else {
						SetDataGridTableStyle.PreferredColumnWidth = (DataGrid.Width / DataSource.Columns.Count) - 10;
					}
				}
			}

			//---3. Assign Table Style to the DataGrid
			DataGrid.TableStyles.Add(SetDataGridTableStyle);

			//=====================================================================
			// Added BY Mangesh Shardul on 02-May-2005
			//=====================================================================
			//---4. Numerically Validate DataGrid
			int intColumnCounter = 0;
			//Dim arrColumnIndices As New ArrayList
			//Dim intColumnIndices() As Integer

			structValidationData[] objValidationData;
			int intIndexCounter;

			 // ERROR: Not supported in C#: ReDimStatement

			intIndexCounter = 0;

			for (intColumnCounter = 0; intColumnCounter <= SetDataGridTableStyle.GridColumnStyles.Count - 1; intColumnCounter++) {

				if (!SetDataGridTableStyle.GridColumnStyles(intColumnCounter).ReadOnly == true) {
					string strColumnName = SetDataGridTableStyle.GridColumnStyles(intColumnCounter).MappingName;

					switch (Type.GetTypeCode(DataSource.Columns(strColumnName).DataType)) {
						case TypeCode.Decimal:
						case TypeCode.Double:
						case TypeCode.Int32:
						case TypeCode.Int64:
						case TypeCode.Single:

							//arrColumnIndices.Add(intColumnCounter)
							objValidationData(intIndexCounter).intColumnIndex = intColumnCounter;
							objValidationData(intIndexCounter).intColumnDataType = enumValidationType.Number;

							intIndexCounter += 1;
						case TypeCode.String:
						case TypeCode.Char:
							objValidationData(intIndexCounter).intColumnIndex = intColumnCounter;
							objValidationData(intIndexCounter).intColumnDataType = enumValidationType.Text;

							intIndexCounter += 1;
					}

				}
			}

			//If Not arrColumnIndices.Count = 0 Then
			//    ReDim intColumnIndices(arrColumnIndices.Count - 1)
			//    intColumnIndices = arrColumnIndices.ToArray(GetType(Integer))
			//    Call Me.NumericValidateGrid(DataGrid, intColumnIndices)
			//End If
			if (objValidationData.Length > 0) {
				Array.Resize(ref objValidationData, intIndexCounter);
				this.NumericValidateGrid(DataGrid, objValidationData);
			}
		//=====================================================================

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


	public void AddDataGridColumnStyle(string ColumnName, ref DataGrid DataGrid, ref DataView DataSource, enumColumnType ColumnType, System.Windows.Forms.HorizontalAlignment Alignment, string ColumnHeaderCaption, int Width, bool blnReadOnly)
	{
		//=====================================================================
		// Procedure Name        : AddDataGridColumnStyle
		// Parameters Passed     : ColumnName,DataGrid,DataSource,ColumnType,Alignment,ColumnHeaderCaption,Width,blnReadOnly 
		// Returns               : 
		// Purpose               : Sets the properties to the Column Style
		// Description           :Assign ColumnProperty and add The Column property to the TableStyle
		// Assumptions           :This function should be called after allthe properties are set 
		// Dependencies          : 
		// Author                : M.Kamal
		// Created               : 18-Sept-2004 08:23 PM
		// Revisions             : 
		//=====================================================================

		try {
			//---- Assign ColumnProperty and add The Column property to the TableStyle
			switch (ColumnType) {
				case enumColumnType.BoolColumn:
					mobjBoolColumn = new DataGridBoolColumn();
					mobjBoolColumn.Alignment = Alignment;
					mobjBoolColumn.HeaderText = ColumnHeaderCaption;
					mobjBoolColumn.MappingName = ColumnName;
					mobjBoolColumn.NullText = false;
					mobjBoolColumn.ReadOnly = blnReadOnly;
					if (mblnAdjustRowWidth == false) {
						mobjBoolColumn.Width = Width;
					} else {
						if (SetDataGridTableStyle.RowHeadersVisible == true) {
							mobjBoolColumn.Width = ((DataGrid.Width - DataGrid.RowHeaderWidth) / DataSource.Table.Columns.Count) - 2;
						} else {
							mobjBoolColumn.Width = (DataGrid.Width / DataSource.Table.Columns.Count) - 1;
						}
					}
					SetDataGridTableStyle.GridColumnStyles.Add(mobjBoolColumn);
				case enumColumnType.TextBoxColumn:
					mobjTextColumn = new DataGridTextBoxColumn();
					mobjTextColumn.Alignment = Alignment;
					mobjTextColumn.HeaderText = ColumnHeaderCaption;
					mobjTextColumn.MappingName = ColumnName;
					mobjTextColumn.NullText = " ";
					mobjTextColumn.ReadOnly = blnReadOnly;
					if (mblnAdjustRowWidth == false) {
						mobjTextColumn.Width = Width;
					} else {
						if (SetDataGridTableStyle.RowHeadersVisible == true) {
							mobjTextColumn.Width = ((DataGrid.Width - DataGrid.RowHeaderWidth) / DataSource.Table.Columns.Count) - 2;
						} else {
							mobjTextColumn.Width = (DataGrid.Width / DataSource.Table.Columns.Count) - 1;
						}
					}
					SetDataGridTableStyle.GridColumnStyles.Add(mobjTextColumn);
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

	public void AddDataGridColumnStyle(string ColumnName, ref DataGrid DataGrid, ref DataView DataSource, enumColumnType ColumnType, System.Windows.Forms.HorizontalAlignment Alignment, string ColumnHeaderCaption, int Width, bool blnReadOnly, int ColumnCount)
	{
		//=====================================================================
		// Procedure Name        : AddDataGridColumnStyle
		// Parameters Passed     : ColumnName,DataGrid,DataSource,ColumnType,Alignment,ColumnHeaderCaption,Width,blnReadOnly ,ColumnCount 
		// Returns               : 
		// Purpose               : Sets the properties to the Column Style
		// Description           :Assign ColumnProperty and add The Column property to the TableStyle
		// Assumptions           :This function should be called after allthe properties are set 
		// Dependencies          : 
		// Author                : M.Kamal
		// Created               : 18-Sept-2004 08:23 PM
		// Revisions             : 
		//=====================================================================
		try {
			//---- Assign ColumnProperty and add The Column property to the TableStyle
			switch (ColumnType) {
				case enumColumnType.BoolColumn:
					mobjBoolColumn = new DataGridBoolColumn();
					mobjBoolColumn.Alignment = Alignment;
					mobjBoolColumn.HeaderText = ColumnHeaderCaption;
					mobjBoolColumn.MappingName = ColumnName;
					mobjBoolColumn.NullText = false;
					mobjBoolColumn.ReadOnly = blnReadOnly;
					if (mblnAdjustRowWidth == false) {
						mobjBoolColumn.Width = Width;
					} else {
						if (SetDataGridTableStyle.RowHeadersVisible == true) {
							mobjBoolColumn.Width = ((DataGrid.Width - DataGrid.RowHeaderWidth) / ColumnCount) - 2;
						} else {
							mobjBoolColumn.Width = (DataGrid.Width / ColumnCount) - 1;
						}
					}
					SetDataGridTableStyle.GridColumnStyles.Add(mobjBoolColumn);
				case enumColumnType.TextBoxColumn:
					mobjTextColumn = new DataGridTextBoxColumn();
					mobjTextColumn.Alignment = Alignment;
					mobjTextColumn.HeaderText = ColumnHeaderCaption;
					mobjTextColumn.MappingName = ColumnName;
					mobjTextColumn.NullText = " ";
					mobjTextColumn.ReadOnly = blnReadOnly;
					if (mblnAdjustRowWidth == false) {
						mobjTextColumn.Width = Width;

					} else {
						if (SetDataGridTableStyle.RowHeadersVisible == true) {
							mobjTextColumn.Width = ((DataGrid.Width - DataGrid.RowHeaderWidth) / ColumnCount) - 2;
						} else {
							mobjTextColumn.Width = (DataGrid.Width / ColumnCount) - 1;
						}
					}
					SetDataGridTableStyle.GridColumnStyles.Add(mobjTextColumn);
			}
		//DataGrid.TableStyles.Add(mobjDataGridStyle)

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

	public void AddDataGridColumnStyle(string ColumnName, ref DataGrid DataGrid, ref DataView DataSource, enumColumnType ColumnType, System.Windows.Forms.HorizontalAlignment Alignment, string ColumnHeaderCaption, bool blnReadOnly)
	{
		//=====================================================================
		// Procedure Name        : AddDataGridColumnStyle
		// Parameters Passed     : ColumnName,DataGrid,DataSource,ColumnType,Alignment,ColumnHeaderCaption,Width,blnReadOnly
		// Returns               : 
		// Purpose               : Sets the properties to the Column Style
		// Description           :Assign ColumnProperty and add The Column property to the TableStyle
		// Assumptions           :This function should be called after allthe properties are set 
		// Dependencies          : 
		// Author                : M.Kamal
		// Created               : 18-Sept-2004 08:23 PM
		// Revisions             : 
		//=====================================================================

		try {
			//---- Assign ColumnProperty and add The Column property to the TableStyle
			switch (ColumnType) {
				case enumColumnType.BoolColumn:
					mobjBoolColumn = new DataGridBoolColumn();
					mobjBoolColumn.Alignment = Alignment;
					mobjBoolColumn.HeaderText = ColumnHeaderCaption;
					mobjBoolColumn.MappingName = ColumnName;
					mobjBoolColumn.NullText = false;
					mobjBoolColumn.ReadOnly = blnReadOnly;
					if (SetDataGridTableStyle.RowHeadersVisible == true) {
						mobjBoolColumn.Width = ((DataGrid.Width - DataGrid.RowHeaderWidth) / DataSource.Table.Columns.Count) - 2;
					} else {
						mobjBoolColumn.Width = (DataGrid.Width / DataSource.Table.Columns.Count) - 1;
					}
					SetDataGridTableStyle.GridColumnStyles.Add(mobjBoolColumn);
				case enumColumnType.TextBoxColumn:
					mobjTextColumn = new DataGridTextBoxColumn();
					mobjTextColumn.Alignment = Alignment;
					mobjTextColumn.HeaderText = ColumnHeaderCaption;
					mobjTextColumn.MappingName = ColumnName;
					mobjTextColumn.NullText = " ";
					mobjTextColumn.ReadOnly = blnReadOnly;

					if (SetDataGridTableStyle.RowHeadersVisible == true) {
						mobjTextColumn.Width = ((DataGrid.Width - DataGrid.RowHeaderWidth) / DataSource.Table.Columns.Count) - 2;
					} else {
						mobjTextColumn.Width = (DataGrid.Width / DataSource.Table.Columns.Count) - 1;
					}
					SetDataGridTableStyle.GridColumnStyles.Add(mobjTextColumn);
			}
		//  DataGrid.TableStyles.Add(mobjDataGridStyle)

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

	public void AddDataGridColumnStyle(string ColumnName, ref DataGrid DataGrid, ref DataTable DataSource, enumColumnType ColumnType, System.Windows.Forms.HorizontalAlignment Alignment, string ColumnHeaderCaption, int Width, bool blnReadOnly)
	{
		//=====================================================================
		// Procedure Name        : AddDataGridColumnStyle
		// Parameters Passed     : ColumnName,DataGrid,DataSource,ColumnType,Alignment,ColumnHeaderCaption,Width,blnReadOnly
		// Returns               : 
		// Purpose               : Sets the properties to the Column Style
		// Description           :Assign ColumnProperty and add The Column property to the TableStyle
		// Assumptions           :This function should be called after allthe properties are set 
		// Dependencies          : 
		// Author                : M.Kamal
		// Created               : 18-Sept-2004 08:23 PM
		// Revisions             : 
		//=====================================================================
		try {
			//---- Assign ColumnProperty and add The Column property to the TableStyle
			switch (ColumnType) {
				case enumColumnType.BoolColumn:
					mobjBoolColumn = new DataGridBoolColumn();
					mobjBoolColumn.Alignment = Alignment;
					mobjBoolColumn.HeaderText = ColumnHeaderCaption;
					mobjBoolColumn.MappingName = ColumnName;
					mobjBoolColumn.NullText = false;
					mobjBoolColumn.ReadOnly = blnReadOnly;
					if (mblnAdjustRowWidth == false) {
						mobjBoolColumn.Width = Width;
					} else {
						if (SetDataGridTableStyle.RowHeadersVisible == true) {
							mobjBoolColumn.Width = ((DataGrid.Width - DataGrid.RowHeaderWidth) / DataSource.Columns.Count) - 2;
						} else {
							mobjBoolColumn.Width = (DataGrid.Width / DataSource.Columns.Count) - 1;
						}
					}
					SetDataGridTableStyle.GridColumnStyles.Add(mobjBoolColumn);
				case enumColumnType.TextBoxColumn:
					mobjTextColumn = new DataGridTextBoxColumn();

					//If mobjTextColumn.DataGridTableStyle.DataGrid.CurrentRowIndex = -1 Then
					//    mobjTextColumn.Alignment = HorizontalAlignment.Center
					//Else
					//    mobjTextColumn.Alignment = HorizontalAlignment.Right
					//End If
					mobjTextColumn.Alignment = Alignment;
					//mobjTextColumn.Alignment = HorizontalAlignment.Center
					mobjTextColumn.HeaderText = ColumnHeaderCaption;
					mobjTextColumn.MappingName = ColumnName;
					mobjTextColumn.NullText = " ";
					mobjTextColumn.ReadOnly = blnReadOnly;
					if (mblnAdjustRowWidth == false) {
						mobjTextColumn.Width = Width;

					} else {
						if (SetDataGridTableStyle.RowHeadersVisible == true) {
							mobjTextColumn.Width = ((DataGrid.Width - DataGrid.RowHeaderWidth) / DataSource.Columns.Count) - 2;
						} else {
							mobjTextColumn.Width = (DataGrid.Width / DataSource.Columns.Count) - 1;
						}
					}
					SetDataGridTableStyle.GridColumnStyles.Add(mobjTextColumn);
			}
		//DataGrid.TableStyles.Add(mobjDataGridStyle)

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

	public void AddDataGridColumnStyle(string ColumnName, ref DataGrid DataGrid, ref DataTable DataSource, enumColumnType ColumnType, System.Windows.Forms.HorizontalAlignment Alignment, string ColumnHeaderCaption, int Width, bool blnReadOnly, ColumnDataType ColDataType, HorizontalAlignment AlignData)
	{
		//=====================================================================
		// Procedure Name        : AddDataGridColumnStyle
		// Parameters Passed     : ColumnName,DataGrid,DataSource,ColumnType,Alignment,ColumnHeaderCaption,Width,blnReadOnly
		// Returns               : 
		// Purpose               : Sets the properties to the Column Style and display Header text and data in required alignment
		// Description           :Assign ColumnProperty and add The Column property to the TableStyle
		// Assumptions           :This function should be called after allthe properties are set 
		// Dependencies          : 
		// Author                : Deepak B.
		// Created               : 2/4/06
		// Revisions             : 
		//=====================================================================
		try {
			//---- Assign ColumnProperty and add The Column property to the TableStyle
			switch (ColumnType) {
				case enumColumnType.BoolColumn:
					mobjBoolColumn = new DataGridBoolColumn();
					mobjBoolColumn.Alignment = Alignment;
					mobjBoolColumn.HeaderText = ColumnHeaderCaption;
					mobjBoolColumn.MappingName = ColumnName;
					mobjBoolColumn.NullText = false;
					mobjBoolColumn.ReadOnly = blnReadOnly;
					if (mblnAdjustRowWidth == false) {
						mobjBoolColumn.Width = Width;
					} else {
						if (SetDataGridTableStyle.RowHeadersVisible == true) {
							mobjBoolColumn.Width = ((DataGrid.Width - DataGrid.RowHeaderWidth) / DataSource.Columns.Count) - 2;
						} else {
							mobjBoolColumn.Width = (DataGrid.Width / DataSource.Columns.Count) - 1;
						}
					}
					SetDataGridTableStyle.GridColumnStyles.Add(mobjBoolColumn);
				case enumColumnType.TextBoxColumn:
					mobjClsDataGridTextBoxColumn = new clsDataGridTextBoxColumn(ColumnHeaderCaption, ColumnName, Width, DataSource, ColDataType);
					//mobjTextColumn = New DataGridTextBoxColumn

					mobjClsDataGridTextBoxColumn.Alignment = Alignment;
					//mobjTextColumn.Alignment = HorizontalAlignment.Center
					mobjClsDataGridTextBoxColumn.HeaderText = ColumnHeaderCaption;
					mobjClsDataGridTextBoxColumn.MappingName = ColumnName;
					mobjClsDataGridTextBoxColumn.NullText = " ";
					mobjClsDataGridTextBoxColumn.ReadOnly = blnReadOnly;
					mobjClsDataGridTextBoxColumn.DataAlignment = AlignData;
					if (mblnAdjustRowWidth == false) {
						mobjClsDataGridTextBoxColumn.Width = Width;

					} else {
						if (SetDataGridTableStyle.RowHeadersVisible == true) {
							mobjClsDataGridTextBoxColumn.Width = ((DataGrid.Width - DataGrid.RowHeaderWidth) / DataSource.Columns.Count) - 2;
						} else {
							mobjClsDataGridTextBoxColumn.Width = (DataGrid.Width / DataSource.Columns.Count) - 1;
						}
					}
					SetDataGridTableStyle.GridColumnStyles.Add(mobjClsDataGridTextBoxColumn);
			}
		//DataGrid.TableStyles.Add(mobjDataGridStyle)

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

	public void AddDataGridColumnStyle(string ColumnName, ref DataGrid DataGrid, ref DataTable DataSource, enumColumnType ColumnType, System.Windows.Forms.HorizontalAlignment Alignment, string ColumnHeaderCaption, int Width, bool blnReadOnly, ColumnDataType ColDataType, HorizontalAlignment AlignData,
	int intNumberOfCharacters, bool blnCheckNumberOfCharacters, bool blnIsNumericValidationRequired)
	{
		//=====================================================================
		// Procedure Name        : AddDataGridColumnStyle
		// Parameters Passed     : ColumnName,DataGrid,DataSource,ColumnType,Alignment,ColumnHeaderCaption,Width,blnReadOnly
		// Returns               : 
		// Purpose               : Sets the properties to the Column Style and display Header text and data in required alignment
		// Description           :Assign ColumnProperty and add The Column property to the TableStyle
		// Assumptions           :This function should be called after allthe properties are set 
		// Dependencies          : 
		// Author                : Deepak B.
		// Created               : 16.08.07
		// Revisions             : 
		//=====================================================================
		try {
			//---- Assign ColumnProperty and add The Column property to the TableStyle
			switch (ColumnType) {
				case enumColumnType.BoolColumn:
					mobjBoolColumn = new DataGridBoolColumn();
					mobjBoolColumn.Alignment = Alignment;
					mobjBoolColumn.HeaderText = ColumnHeaderCaption;
					mobjBoolColumn.MappingName = ColumnName;
					mobjBoolColumn.NullText = false;
					mobjBoolColumn.ReadOnly = blnReadOnly;
					if (mblnAdjustRowWidth == false) {
						mobjBoolColumn.Width = Width;
					} else {
						if (SetDataGridTableStyle.RowHeadersVisible == true) {
							mobjBoolColumn.Width = ((DataGrid.Width - DataGrid.RowHeaderWidth) / DataSource.Columns.Count) - 2;
						} else {
							mobjBoolColumn.Width = (DataGrid.Width / DataSource.Columns.Count) - 1;
						}
					}
					SetDataGridTableStyle.GridColumnStyles.Add(mobjBoolColumn);
				case enumColumnType.TextBoxColumn:
					//mobjClsDataGridTextBoxColumn = New clsDataGridTextBoxColumn(ColumnHeaderCaption, ColumnName, Width, DataSource, ColDataType)
					mobjClsDataGridTextBoxColumn = new clsDataGridTextBoxColumn(intNumberOfCharacters, blnCheckNumberOfCharacters, blnIsNumericValidationRequired, false, false);
					//mobjTextColumn = New DataGridTextBoxColumn

					mobjClsDataGridTextBoxColumn.Alignment = Alignment;
					//mobjTextColumn.Alignment = HorizontalAlignment.Center
					mobjClsDataGridTextBoxColumn.HeaderText = ColumnHeaderCaption;
					mobjClsDataGridTextBoxColumn.MappingName = ColumnName;
					mobjClsDataGridTextBoxColumn.NullText = " ";
					mobjClsDataGridTextBoxColumn.ReadOnly = blnReadOnly;
					mobjClsDataGridTextBoxColumn.DataAlignment = AlignData;
					if (mblnAdjustRowWidth == false) {
						mobjClsDataGridTextBoxColumn.Width = Width;

					} else {
						if (SetDataGridTableStyle.RowHeadersVisible == true) {
							mobjClsDataGridTextBoxColumn.Width = ((DataGrid.Width - DataGrid.RowHeaderWidth) / DataSource.Columns.Count) - 2;
						} else {
							mobjClsDataGridTextBoxColumn.Width = (DataGrid.Width / DataSource.Columns.Count) - 1;
						}
					}
					SetDataGridTableStyle.GridColumnStyles.Add(mobjClsDataGridTextBoxColumn);
			}
		//DataGrid.TableStyles.Add(mobjDataGridStyle)

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

	//Public Sub AddDataGridColumnStyle(ByVal ColumnName As String, ByRef DataGrid1 As DataGrid, ByRef DataSource As DataTable, ByVal ColumnType As enumColumnType, ByVal Alignment As System.Windows.Forms.HorizontalAlignment, ByVal ColumnHeaderCaption As String, ByVal Width As Integer, ByVal blnReadOnly As Boolean, ByRef control As System.Windows.Forms.Control)

	//    '---- Assign ColumnProperty and add The Column property to the TableStyle
	//    Select Case ColumnType
	//        Case enumColumnType.BoolColumn
	//            mobjBoolColumn = New DataGridBoolColumn
	//            mobjBoolColumn.Alignment = Alignment
	//            mobjBoolColumn.HeaderText = ColumnHeaderCaption
	//            mobjBoolColumn.MappingName = ColumnName
	//            mobjBoolColumn.NullText = False
	//            mobjBoolColumn.ReadOnly = blnReadOnly
	//            If mblnAdjustRowWidth = False Then
	//                mobjBoolColumn.Width = Width
	//            Else
	//                If SetDataGridTableStyle.RowHeadersVisible = True Then
	//                    mobjBoolColumn.Width = ((DataGrid1.Width - DataGrid1.RowHeaderWidth) / DataSource.Columns.Count) - 2
	//                Else
	//                    mobjBoolColumn.Width = (DataGrid1.Width / DataSource.Columns.Count) - 1
	//                End If
	//            End If
	//            SetDataGridTableStyle.GridColumnStyles.Add(mobjBoolColumn)
	//        Case enumColumnType.TextBoxColumn
	//            mobjTextColumn = New DataGridTextBoxColumn
	//            mobjTextColumn.Alignment = Alignment
	//            mobjTextColumn.HeaderText = ColumnHeaderCaption
	//            mobjTextColumn.MappingName = ColumnName
	//            mobjTextColumn.NullText = " "
	//            mobjTextColumn.ReadOnly = blnReadOnly
	//            If mblnAdjustRowWidth = False Then
	//                mobjTextColumn.Width = Width

	//            Else
	//                If SetDataGridTableStyle.RowHeadersVisible = True Then
	//                    mobjTextColumn.Width = ((DataGrid1.Width - DataGrid1.RowHeaderWidth) / DataSource.Columns.Count) - 2
	//                Else
	//                    mobjTextColumn.Width = (DataGrid1.Width / DataSource.Columns.Count) - 1
	//                End If
	//            End If
	//            mobjTextColumn.TextBox.Controls.Add(control)
	//            mobjTextColumn.TextBox.Focus()
	//            'Dim hit As DataGrid.HitTestInfo
	//            'AddHandler DataGrid1.MouseDown, AddressOf func

	//            '   control.Text = DataSource.Rows(row).Item(col)
	//            'DataSource.Rows(0).Item(2) = control.Text
	//            control.Dock = DockStyle.Fill
	//            control.BringToFront()
	//            SetDataGridTableStyle.GridColumnStyles.Add(mobjTextColumn)
	//    End Select
	//    'DataGrid.TableStyles.Add(mobjDataGridStyle)
	//End Sub

	public void AddDataGridColumnStyle(string ColumnName, ref DataGrid DataGrid, ref DataTable DataSource, enumColumnType ColumnType, System.Windows.Forms.HorizontalAlignment Alignment, string ColumnHeaderCaption, bool blnReadOnly)
	{
		//=====================================================================
		// Procedure Name        : AddDataGridColumnStyle
		// Parameters Passed     : ColumnName,DataGrid,DataSource,ColumnType,Alignment,ColumnHeaderCaption,blnReadOnly
		// Returns               : 
		// Purpose               : Sets the properties to the Column Style
		// Description           :Assign ColumnProperty and add The Column property to the TableStyle
		// Assumptions           :This function should be called after allthe properties are set 
		// Dependencies          : 
		// Author                : M.Kamal
		// Created               : 18-Sept-2004 08:23 PM
		// Revisions             : 
		//=====================================================================
		try {
			//---- Assign ColumnProperty and add The Column property to the TableStyle
			switch (ColumnType) {
				case enumColumnType.BoolColumn:
					mobjBoolColumn = new DataGridBoolColumn();
					mobjBoolColumn.Alignment = Alignment;
					mobjBoolColumn.HeaderText = ColumnHeaderCaption;
					mobjBoolColumn.MappingName = ColumnName;
					mobjBoolColumn.NullText = false;
					mobjBoolColumn.ReadOnly = blnReadOnly;
					if (SetDataGridTableStyle.RowHeadersVisible == true) {
						mobjBoolColumn.Width = ((DataGrid.Width - DataGrid.RowHeaderWidth) / DataSource.Columns.Count) - 2;
					} else {
						mobjBoolColumn.Width = (DataGrid.Width / DataSource.Columns.Count) - 1;
					}
					SetDataGridTableStyle.GridColumnStyles.Add(mobjBoolColumn);
				case enumColumnType.TextBoxColumn:
					mobjTextColumn = new DataGridTextBoxColumn();
					mobjTextColumn.Alignment = Alignment;
					mobjTextColumn.HeaderText = ColumnHeaderCaption;
					mobjTextColumn.MappingName = ColumnName;
					mobjTextColumn.NullText = " ";
					mobjTextColumn.ReadOnly = blnReadOnly;

					if (mblnAdjustRowWidth == false) {
					//mobjTextColumn.Width = Width
					} else {
						if (SetDataGridTableStyle.RowHeadersVisible == true) {
							mobjTextColumn.Width = ((DataGrid.Width - DataGrid.RowHeaderWidth) / DataSource.Columns.Count) - 2;
						} else {
							mobjTextColumn.Width = (DataGrid.Width / DataSource.Columns.Count) - 1;
						}
					}

					SetDataGridTableStyle.GridColumnStyles.Add(mobjTextColumn);
			}
		//  DataGrid.TableStyles.Add(mobjDataGridStyle)

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

	//Public Sub AddDataGridColumnStyle(ByVal ColumnName As String, ByRef DataGrid As DataGrid, ByVal DataSource As ArrayList, ByVal Alignment As System.Windows.Forms.HorizontalAlignment, ByVal ColumnHeaderCaption As String, ByVal Width As Integer, ByVal blnReadOnly As Boolean, ByVal ColDataType As ColumnDataType, Optional ByVal AlignToRight As Boolean = False)
	//    '=====================================================================
	//    ' Procedure Name        : AddDataGridColumnStyle
	//    ' Parameters Passed     : ColumnName,DataGrid,DataSource,Alignment,ColumnHeaderCaption,Width,blnReadOnly 
	//    ' Returns               : 
	//    ' Purpose               : Sets the properties to the Column Style
	//    ' Description           : Assign ColumnProperty and add The Column property to the TableStyle
	//    ' Assumptions           :
	//    ' Dependencies          : 
	//    ' Author                : Deepak Bhati
	//    ' Created               : 24-Nov-2004 05:23 PM
	//    ' Revisions             : 
	//    '=====================================================================
	//    Try
	//        '---- Assign ColumnProperty and add The Column property to the TableStyle
	//        mobjClsDataGridTextBoxColumn = New clsDataGridTextBoxColumn(ColumnHeaderCaption, ColumnName, Width, DataSource, ColDataType, AlignToRight)
	//        'mobjClsDataGridTextBoxColumn = New clsDataGridTextBoxColumn(ColumnHeaderCaption, ColumnName, Width, ColDataType, AlignToRight)
	//        mobjClsDataGridTextBoxColumn.Alignment = Alignment
	//        mobjClsDataGridTextBoxColumn.NullText = " "
	//        mobjClsDataGridTextBoxColumn.ReadOnly = blnReadOnly

	//        If mblnAdjustRowWidth = False Then
	//            mobjClsDataGridTextBoxColumn.Width = Width
	//        End If

	//        SetDataGridTableStyle.GridColumnStyles.Add(mobjClsDataGridTextBoxColumn)

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------           
	//    End Try
	//End Sub

	public void AddDataGridColumnStyle(string ColumnName, ref DataGrid DataGrid, DataTable DataSource, System.Windows.Forms.HorizontalAlignment Alignment, string ColumnHeaderCaption, int Width, bool blnReadOnly, ColumnDataType ColDataType, bool AlignToRight = false)
	{
		//=====================================================================
		// Procedure Name        : AddDataGridColumnStyle
		// Parameters Passed     : ColumnName,DataGrid,DataSource,Alignment,ColumnHeaderCaption,Width,blnReadOnly 
		// Returns               : 
		// Purpose               : Sets the properties to the Column Style
		// Description           : Assign ColumnProperty and add The Column property to the TableStyle
		// Assumptions           :
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 24-Nov-2004 05:23 PM
		// Revisions             : 
		//=====================================================================

		try {
			//---- Assign ColumnProperty and add The Column property to the TableStyle
			mobjClsDataGridTextBoxColumn = new clsDataGridTextBoxColumn(ColumnHeaderCaption, ColumnName, Width, DataSource, ColDataType, AlignToRight);
			//mobjClsDataGridTextBoxColumn = New clsDataGridTextBoxColumn(intNumberOfCharacters)
			mobjClsDataGridTextBoxColumn.Alignment = Alignment;
			mobjClsDataGridTextBoxColumn.NullText = " ";
			mobjClsDataGridTextBoxColumn.ReadOnly = blnReadOnly;
			if (mblnAdjustRowWidth == false) {
				mobjClsDataGridTextBoxColumn.Width = Width;
			}

			SetDataGridTableStyle.GridColumnStyles.Add(mobjClsDataGridTextBoxColumn);

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

	public void AddDataGridColumnStyle(string ColumnName, ref DataGrid DataGrid, DataTable DataSource, System.Windows.Forms.HorizontalAlignment Alignment, string ColumnHeaderCaption, int Width, bool blnReadOnly, ColumnDataType ColDataType, HorizontalAlignment AlignData)
	{
		//=====================================================================
		// Procedure Name        : AddDataGridColumnStyle
		// Parameters Passed     : ColumnName,DataGrid,DataSource,Alignment,ColumnHeaderCaption,Width,blnReadOnly 
		// Returns               : 
		// Purpose               : Sets the properties to the Column Style and display Header text and data in required alignment
		// Description           : Assign ColumnProperty and add The Column property to the TableStyle
		// Assumptions           :
		// Dependencies          : 
		// Author                : Deepak B.
		// Created               : 2-April-2006 
		// Revisions             : 
		//=====================================================================

		try {
			//---- Assign ColumnProperty and add The Column property to the TableStyle
			mobjClsDataGridTextBoxColumn = new clsDataGridTextBoxColumn(ColumnHeaderCaption, ColumnName, Width, DataSource, ColDataType);
			//mobjClsDataGridTextBoxColumn = New clsDataGridTextBoxColumn(intNumberOfCharacters)
			mobjClsDataGridTextBoxColumn.Alignment = Alignment;
			mobjClsDataGridTextBoxColumn.NullText = " ";
			mobjClsDataGridTextBoxColumn.ReadOnly = blnReadOnly;
			mobjClsDataGridTextBoxColumn.DataAlignment = AlignData;
			if (mblnAdjustRowWidth == false) {
				mobjClsDataGridTextBoxColumn.Width = Width;
			}

			SetDataGridTableStyle.GridColumnStyles.Add(mobjClsDataGridTextBoxColumn);

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

	public void AddDataGridColumnStyle(string ColumnName, ref DataGrid DataGrid, DataView DataSource, System.Windows.Forms.HorizontalAlignment Alignment, string ColumnHeaderCaption, int Width, bool blnReadOnly, ColumnDataType ColDataType, HorizontalAlignment AlignData)
	{
		//=====================================================================
		// Procedure Name        : AddDataGridColumnStyle
		// Parameters Passed     : ColumnName,DataGrid,DataSource,Alignment,ColumnHeaderCaption,Width,blnReadOnly 
		// Returns               : 
		// Purpose               : Sets the properties to the Column Style and display Header text and data in required alignment
		// Description           : Assign ColumnProperty and add The Column property to the TableStyle
		// Assumptions           :
		// Dependencies          : 
		// Author                : Rahul B.
		// Created               : 2-April-2006 
		// Revisions             : 
		//=====================================================================

		try {
			//---- Assign ColumnProperty and add The Column property to the TableStyle
			mobjClsDataGridTextBoxColumn = new clsDataGridTextBoxColumn(ColumnHeaderCaption, ColumnName, Width, ColDataType);
			//mobjClsDataGridTextBoxColumn = New clsDataGridTextBoxColumn(intNumberOfCharacters)
			mobjClsDataGridTextBoxColumn.Alignment = Alignment;
			mobjClsDataGridTextBoxColumn.NullText = " ";
			mobjClsDataGridTextBoxColumn.ReadOnly = blnReadOnly;
			mobjClsDataGridTextBoxColumn.DataAlignment = AlignData;
			if (mblnAdjustRowWidth == false) {
				mobjClsDataGridTextBoxColumn.Width = Width;
			}

			SetDataGridTableStyle.GridColumnStyles.Add(mobjClsDataGridTextBoxColumn);

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

	#Region " Public/Private Shared Functions "

	//ByVal ColumnIndicesToBeValidated() As Integer)
	private static void NumericValidateGrid(ref DataGrid objDataGridIn, structValidationData[] objValidationDataIn)
	{
		//=====================================================================
		// Procedure Name        : NumericValidateGrid
		// Purpose               : To bind Event Handler of DataGrid for CurrentCellChanged
		// Author                : Mangesh Shardul
		// Created               : 30-April-2005
		// Revisions             : 1
		//=====================================================================
		try {
			objDataGridIn.CurrentCellChanged -= subCurrentCellChanged;

			mobjValidationData = objValidationDataIn;

			objDataGridIn.CurrentCellChanged += subCurrentCellChanged;

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

	private static void subCurrentCellChanged(object sender, EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : subCurrentCellChanged
		// Purpose               : To handle the Current Cell Changed Event
		// Author                : Mangesh Shardul
		// Created               : 30-April-2005
		// Revisions             : 1
		//=====================================================================
		int intCount;
		int intColumnIndexToBeValidated;
		structValidationData objValidationData;

		try {
			((DataGrid)sender).CurrentCellChanged -= subCurrentCellChanged;

			for (intCount = 0; intCount <= mobjValidationData.Length - 1; intCount++) {
				objValidationData = mobjValidationData(intCount);

				if (objValidationData.intColumnDataType == enumValidationType.Number) {
					GridCellNumberValidator((DataGrid)sender, objValidationData.intColumnIndex, objValidationData.intColumnDataType);
				} else if (objValidationData.intColumnDataType == enumValidationType.Text) {
					GridCellTextValidator((DataGrid)sender, objValidationData.intColumnIndex, objValidationData.intColumnDataType);
				}

			}

			((DataGrid)sender).CurrentCellChanged += subCurrentCellChanged;

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

	private static bool GridCellNumberValidator(ref Windows.forms.DataGrid DataGrid, int intColumnIndexToBeValidated, enumValidationType intValidationType)
	{
		//=====================================================================
		// Procedure Name        : GridCellNumberValidator
		// Parameters Passed     : DataGrid by Reference, index of Column 
		// Returns               : True or False
		// Purpose               : To validate the data entered in the cell of DataGrid
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul 
		// Created               : Saturday 30 April 2005 05:15 pm
		// Revisions             : 1
		//=====================================================================
		try {
			if (intValidationType == enumValidationType.Text) {
				return;
			}

			///---Validation For Forward Navigation
			if (!DataGrid.CurrentCell.RowNumber == 0) {
				if (!IsDBNull(DataGrid.Item(DataGrid.CurrentCell.RowNumber - 1, intColumnIndexToBeValidated))) {
					if (IsNumeric(DataGrid.Item(DataGrid.CurrentCell.RowNumber - 1, intColumnIndexToBeValidated)) == false) {
						gobjMessageAdapter.ShowMessage(constEnterOnlyNos);
						Application.DoEvents();
						DataGrid.CurrentCell = new DataGridCell(DataGrid.CurrentCell.RowNumber - 1, intColumnIndexToBeValidated);
						return true;
					}
				}
			}

			//---Validation For Backward Navigation
			if (DataGrid.CurrentCell.RowNumber < ((DataView)DataGrid.DataSource).Count - 1) {
				if (!IsDBNull(DataGrid.Item(DataGrid.CurrentCell.RowNumber + 1, intColumnIndexToBeValidated))) {
					if (IsNumeric(DataGrid.Item(DataGrid.CurrentCell.RowNumber + 1, intColumnIndexToBeValidated)) == false) {
						//MessageBox.Show("Enter only numbers.")170
						gobjMessageAdapter.ShowMessage(constEnterOnlyNos);
						Application.DoEvents();
						DataGrid.CurrentCell = new DataGridCell(DataGrid.CurrentCell.RowNumber + 1, intColumnIndexToBeValidated);
						return true;
					}
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

	private static bool GridCellTextValidator(ref Windows.forms.DataGrid objDataGrid, int intColumnIndexToBeValidated, enumValidationType intValidationType)
	{
		//=====================================================================
		// Procedure Name        : GridCellTextValidator
		// Parameters Passed     : DataGrid by Reference, index of Column 
		// Returns               : True or False
		// Purpose               : To validate the data entered in the cell of DataGrid
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul 
		// Created               : Tuesday 27-Mar-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		string strText;
		DataTable objDtDataSource;
		int intRowCounter;
		bool blnIsTextDuplicate;

		try {
			if (intValidationType == enumValidationType.Number) {
				return;
			}

			///---Validation For Forward Navigation
			if (!objDataGrid.CurrentCell.RowNumber == 0) {
				if (!IsDBNull(objDataGrid.Item(objDataGrid.CurrentCell.RowNumber - 1, intColumnIndexToBeValidated))) {
					//Saruabh 17.07.07
					//blnIsTextDuplicate = funcCheckDuplicateText(objDataGrid, intColumnIndexToBeValidated, objDataGrid.CurrentCell.RowNumber - 1)
					//If blnIsTextDuplicate Then
					//    'gobjMessageAdapter.ShowMessage("This text is already entered", "Unique Validation", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
					//    Application.DoEvents()
					//    objDataGrid.CurrentCell = New DataGridCell(objDataGrid.CurrentCell.RowNumber - 1, intColumnIndexToBeValidated)
					//    Return True
					//End If
					//Saruabh 17.07.07
				}
			}

			//---Validation For Backward Navigation
			if (objDataGrid.CurrentCell.RowNumber < ((DataView)objDataGrid.DataSource).Count - 1) {
				if (!IsDBNull(objDataGrid.Item(objDataGrid.CurrentCell.RowNumber + 1, intColumnIndexToBeValidated))) {
					//Saruabh 17.07.07
					//blnIsTextDuplicate = funcCheckDuplicateText(objDataGrid, intColumnIndexToBeValidated, objDataGrid.CurrentCell.RowNumber + 1)
					//If blnIsTextDuplicate Then
					//    'gobjMessageAdapter.ShowMessage("This text is already entered", "Unique Validation", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
					//    Application.DoEvents()
					//    objDataGrid.CurrentCell = New DataGridCell(objDataGrid.CurrentCell.RowNumber + 1, intColumnIndexToBeValidated)
					//    Return True
					//End If
					//Saruabh 17.07.07
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

	private static bool funcCheckDuplicateText(DataGrid objDataGrid, int intColumnIndexToBeValidated, int intRowIndexToBeValidated)
	{
		//=====================================================================
		// Procedure Name        : funcCheckDuplicateText
		// Parameters Passed     : DataGrid, ColumnIndex, Navigation Direction
		// Returns               : True or false
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 27-Mar-2007 03:45 pm
		// Revisions             : 1
		//=====================================================================
		DataTable objDtDataSource;
		string strText;
		bool blnIsTextDuplicate;
		int intRowCounter;

		try {
			//If Not IsDBNull(objDataGrid.Item(intRowIndexToBeValidated, intColumnIndexToBeValidated)) Then
			strText = objDataGrid.Item(intRowIndexToBeValidated, intColumnIndexToBeValidated);
			//Else
			//strText = ""
			//End If

			blnIsTextDuplicate = false;

			if (objDataGrid.DataSource is DataTable) {
				objDtDataSource = (DataTable)objDataGrid.DataSource;
			} else if (objDataGrid.DataSource is DataView) {
				objDtDataSource = ((DataView)objDataGrid.DataSource).Table;
			}

			for (intRowCounter = 0; intRowCounter <= objDtDataSource.Rows.Count - 1; intRowCounter++) {
				if (!intRowCounter == intRowIndexToBeValidated) {
					//---Perform Case Insensitive String comparison

					//Added by Saurabh on 22 May 2007
					if (!IsDBNull(objDtDataSource.Rows(intRowCounter).Item(intColumnIndexToBeValidated))) {
						//objDtDataSource.Rows(intRowCounter).Item(intColumnIndexToBeValidated) = ""
						//And condition added by pankaj on 26 MAy 07  And strText.Trim() <> "" 
						if (UCase((string)objDtDataSource.Rows(intRowCounter).Item(intColumnIndexToBeValidated)) == UCase(strText) & strText.Trim() != "") {
							//---entered text data already present in the DataGrid
							blnIsTextDuplicate = true;
						}
					}
				}

			}

			return blnIsTextDuplicate;

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

}


