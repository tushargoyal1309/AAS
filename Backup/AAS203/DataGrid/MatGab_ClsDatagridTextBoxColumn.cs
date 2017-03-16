
 // ERROR: Not supported in C#: OptionDeclaration
public class clsDataGridTextBoxColumn : System.Windows.Forms.DataGridTextBoxColumn
{
	//****************************************************************************************
	// File Header
	// File Name 		: ClsDatagridTextBoxColumn.vb
	// Author			: Deepak Bhati
	// Date/Time			: Wednesday, November 24, 2004
	// Description		: This component is used to validate a required column 
	//****************************************************************************************

	#Region " Class Variables "
	private bool mblnAlignToRight = false;
	private ColDataType mColumnDataType;
	private HorizontalAlignment mTextAlignment = HorizontalAlignment.Left;
	private StringFormat mDrawText = new StringFormat();
	private int mIntNumberOfCharacters;
	private ArrayList mArrDataSource = new ArrayList();
	private System.Drawing.Color mSeparator;
	private DataTable mdtDataSource = new DataTable();
	private DataView mdvDataSource = new DataView();
	private int mintDataSourceType;
	private bool mblnGroups;
	private ArrayList mArrGroups = new ArrayList();
	private bool mblnCheckNumberOfCharacters = false;
		#End Region
	private bool mblnIsNumericValidationRequired = false;

	#Region " Public Enums, Structures, .. "

	public enum ColDataType
	{
		Text = 1,
		Color = 2
	}

	public enum SourceType
	{
		ArrayList = 1,
		Datatable = 2,
		DataView = 3
	}

	#End Region

	#Region " Public Properties "
	public int NumberOfCharacters {
		get { return mIntNumberOfCharacters; }
		set { mIntNumberOfCharacters = Value; }
	}

	public HorizontalAlignment DataAlignment {
		get { return mTextAlignment; }
		set {
			mTextAlignment = Value;
			if (mTextAlignment == HorizontalAlignment.Center) {
				mDrawText.Alignment = StringAlignment.Center;
			} else if (mTextAlignment == HorizontalAlignment.Right) {
				mDrawText.Alignment = StringAlignment.Far;
			} else {
				mDrawText.Alignment = StringAlignment.Near;
			}
		}
	}

	public ColDataType ColumnDataType {
		get { return mColumnDataType; }
		set { mColumnDataType = Value; }
	}

	public System.Drawing.Color SeparatorColor {
		get { return mSeparator; }
		set { mSeparator = Value; }
	}

	public SourceType DataSourceType {
		get { return mintDataSourceType; }
		set { mintDataSourceType = Value; }
	}

	#End Region

	#Region " Constructors "

	public clsDataGridTextBoxColumn(int intNumberOfCharacters, bool blnCheckNumberOfCharacters, bool BlnNumericValidationRequired, bool AlignToRight, bool blnNothing)
	{
		mblnAlignToRight = AlignToRight;
		NumberOfCharacters = intNumberOfCharacters;
		mblnCheckNumberOfCharacters = blnCheckNumberOfCharacters;
		mblnIsNumericValidationRequired = BlnNumericValidationRequired;
	}

	public clsDataGridTextBoxColumn(string headerText, string mappingName, int width, ArrayList DataSource, ColDataType ColDataTypeIn, bool AlignToRight = false)
	{
		base.HeaderText = headerText;
		base.MappingName = mappingName;
		base.Width = width;
		mArrDataSource = DataSource;
		ColumnDataType = ColDataTypeIn;
		SeparatorColor = System.Drawing.Color.White;
		DataSourceType = SourceType.ArrayList;
		mblnAlignToRight = AlignToRight;

	}

	public clsDataGridTextBoxColumn(string headerText, string mappingName, int width, DataTable DataSource, ColDataType ColDataTypeIn, bool AlignToRight = false)
	{
		base.HeaderText = headerText;
		base.MappingName = mappingName;
		base.Width = width;
		mdtDataSource = DataSource;
		ColumnDataType = ColDataTypeIn;
		SeparatorColor = System.Drawing.Color.LightGray;
		DataSourceType = SourceType.Datatable;
		mblnAlignToRight = AlignToRight;
		//Me.HeaderText = Me.HeaderText & Space(1)

	}

	public clsDataGridTextBoxColumn(string headerText, string mappingName, int width, ColDataType ColDataTypeIn, bool AlignToRight = false)
	{
		base.HeaderText = headerText;
		base.MappingName = mappingName;
		base.Width = width;
		ColumnDataType = ColDataTypeIn;
		SeparatorColor = System.Drawing.Color.LightGray;
		DataSourceType = 0;
		mblnAlignToRight = AlignToRight;
		//Me.HeaderText = Me.HeaderText & Space(1)

	}

	#End Region

	#Region " Overriden Private Functions "

	protected override void Edit(System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Rectangle bounds, bool isReadOnly, string instantText, bool cellIsVisible)
	{
		base.Edit(source, rowNum, bounds, ReadOnly, instantText, cellIsVisible);
		base.TextBox.TextAlign = mTextAlignment;
		base.TextBox.CharacterCasing = CharacterCasing.Normal;
		if (mblnCheckNumberOfCharacters == true) {
			base.TextBox.MaxLength = NumberOfCharacters;
		}

	}

	protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Brush backBrush, System.Drawing.Brush foreBrush, bool alignToRight)
	{
		//=====================================================================
		// Procedure Name        : Paint
		// Parameters Passed     : graphics object,bounds ,source, rowNum,backBrush, foreBrush ,alignToRight 
		// Returns               : None
		// Purpose               : To paint the given column with given set of colors
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : Wednesday, November 24, 2004
		// Revisions             : 
		//=====================================================================
		int intRowCount;
		Color objColor = new Color();
		string objText;
		Brush bgBrush;
		Brush fgBrush;


		try {
			if (this.DataGridTableStyle.DataGrid.IsSelected(rowNum)) {
				bgBrush = new SolidBrush(this.DataGridTableStyle.SelectionBackColor);
				fgBrush = new SolidBrush(this.DataGridTableStyle.SelectionForeColor);
			} else {
				bgBrush = new SolidBrush(this.DataGridTableStyle.BackColor);
				fgBrush = new SolidBrush(this.DataGridTableStyle.ForeColor);
			}

			g.FillRectangle(bgBrush, bounds);

			if (IsDBNull(this.GetColumnValueAtRow(source, rowNum))) {
				objText = " ";
			} else {
				objText = this.GetColumnValueAtRow(source, rowNum);
			}

			Rectangle r = bounds;
			r.Inflate(0, -1);

			switch (mDrawText.Alignment) {
				case StringAlignment.Far:
					g.DrawString(objText, base.TextBox.Font, foreBrush, r.X + r.Width, r.Y, mDrawText);
				case StringAlignment.Center:
					g.DrawString(objText, base.TextBox.Font, foreBrush, r.X + (r.Width / 2), r.Y, mDrawText);
				default:
					g.DrawString(objText, base.TextBox.Font, foreBrush, r.X, r.Y, mDrawText);
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

}
