public class frmAutoSampPosn : System.Windows.Forms.Form
{
	//Dim mobjDataTable As New DataTable("AutoSamplerPosition")
	//Dim mobjGridTableStyle As New DataGridTableStyle
	//Dim mdataView As New DataView

	DataTable mobjDataTable;
	#Region " Windows Form Designer generated code "

	public frmAutoSampPosn(ref DataTable objDataTable)
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();
		mobjDataTable = objDataTable;
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
	internal System.Windows.Forms.Label lblInfo;
	internal System.Windows.Forms.ImageList ImageList1;
	internal System.Windows.Forms.GroupBox GroupBox2;
	internal System.Windows.Forms.Button btnTimings;
	internal System.Windows.Forms.Button btnHome;
	internal System.Windows.Forms.Button btnOk;
	internal System.Windows.Forms.Button btnCancel;
	internal System.Windows.Forms.DataGrid dgSamplerPosition;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmAutoSampPosn));
		this.lblInfo = new System.Windows.Forms.Label();
		this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
		this.GroupBox2 = new System.Windows.Forms.GroupBox();
		this.btnHome = new System.Windows.Forms.Button();
		this.btnTimings = new System.Windows.Forms.Button();
		this.btnOk = new System.Windows.Forms.Button();
		this.btnCancel = new System.Windows.Forms.Button();
		this.dgSamplerPosition = new System.Windows.Forms.DataGrid();
		this.GroupBox2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dgSamplerPosition).BeginInit();
		this.SuspendLayout();
		//
		//lblInfo
		//
		this.lblInfo.Image = (System.Drawing.Image)resources.GetObject("lblInfo.Image");
		this.lblInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblInfo.Location = new System.Drawing.Point(8, 0);
		this.lblInfo.Name = "lblInfo";
		this.lblInfo.Size = new System.Drawing.Size(280, 24);
		this.lblInfo.TabIndex = 0;
		this.lblInfo.Text = "Note : Enter position between 2 and 65 only ";
		this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//ImageList1
		//
		this.ImageList1.ImageSize = new System.Drawing.Size(16, 16);
		this.ImageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ImageList1.ImageStream");
		this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
		//
		//GroupBox2
		//
		this.GroupBox2.Controls.Add(this.btnHome);
		this.GroupBox2.Controls.Add(this.btnTimings);
		this.GroupBox2.Location = new System.Drawing.Point(0, 328);
		this.GroupBox2.Name = "GroupBox2";
		this.GroupBox2.Size = new System.Drawing.Size(272, 72);
		this.GroupBox2.TabIndex = 2;
		this.GroupBox2.TabStop = false;
		//
		//btnHome
		//
		this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.btnHome.Location = new System.Drawing.Point(144, 24);
		this.btnHome.Name = "btnHome";
		this.btnHome.Size = new System.Drawing.Size(112, 32);
		this.btnHome.TabIndex = 2;
		this.btnHome.Text = "&Home";
		//
		//btnTimings
		//
		this.btnTimings.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.btnTimings.Location = new System.Drawing.Point(16, 24);
		this.btnTimings.Name = "btnTimings";
		this.btnTimings.Size = new System.Drawing.Size(112, 32);
		this.btnTimings.TabIndex = 1;
		this.btnTimings.Text = "&Change Timings";
		//
		//btnOk
		//
		this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.btnOk.Image = (System.Drawing.Image)resources.GetObject("btnOk.Image");
		this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOk.Location = new System.Drawing.Point(120, 408);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(72, 24);
		this.btnOk.TabIndex = 0;
		this.btnOk.Text = "&Ok";
		//
		//btnCancel
		//
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.btnCancel.Image = (System.Drawing.Image)resources.GetObject("btnCancel.Image");
		this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCancel.Location = new System.Drawing.Point(200, 408);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(72, 24);
		this.btnCancel.TabIndex = 4;
		this.btnCancel.Text = "&Cancel";
		this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		//
		//dgSamplerPosition
		//
		this.dgSamplerPosition.AlternatingBackColor = System.Drawing.Color.AliceBlue;
		this.dgSamplerPosition.BackColor = System.Drawing.Color.AliceBlue;
		this.dgSamplerPosition.BackgroundColor = System.Drawing.Color.AliceBlue;
		this.dgSamplerPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.dgSamplerPosition.CaptionBackColor = System.Drawing.Color.AliceBlue;
		this.dgSamplerPosition.CaptionForeColor = System.Drawing.Color.FloralWhite;
		this.dgSamplerPosition.CaptionVisible = false;
		this.dgSamplerPosition.DataMember = "";
		this.dgSamplerPosition.HeaderBackColor = System.Drawing.Color.FloralWhite;
		this.dgSamplerPosition.HeaderForeColor = System.Drawing.SystemColors.ControlText;
		this.dgSamplerPosition.LinkColor = System.Drawing.Color.FloralWhite;
		this.dgSamplerPosition.Location = new System.Drawing.Point(24, 32);
		this.dgSamplerPosition.Name = "dgSamplerPosition";
		this.dgSamplerPosition.ParentRowsBackColor = System.Drawing.Color.FloralWhite;
		this.dgSamplerPosition.PreferredColumnWidth = 100;
		this.dgSamplerPosition.RowHeadersVisible = false;
		this.dgSamplerPosition.SelectionBackColor = System.Drawing.Color.FloralWhite;
		this.dgSamplerPosition.Size = new System.Drawing.Size(227, 280);
		this.dgSamplerPosition.TabIndex = 5;
		//
		//frmAutoSampPosn
		//
		this.AcceptButton = this.btnOk;
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.ClientSize = new System.Drawing.Size(274, 439);
		this.Controls.Add(this.dgSamplerPosition);
		this.Controls.Add(this.btnCancel);
		this.Controls.Add(this.btnOk);
		this.Controls.Add(this.GroupBox2);
		this.Controls.Add(this.lblInfo);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmAutoSampPosn";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Auto Sampler Positions";
		this.GroupBox2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dgSamplerPosition).EndInit();
		this.ResumeLayout(false);

	}

	#End Region

	private void  // ERROR: Handles clauses are not supported in C#
btnHome_Click(System.Object sender, System.EventArgs e)
	{
		if (gobjCommProtocol.funcAutoSamplerHome()) {
			gstructAutoSampler.blnHome = true;
			gstructAutoSampler.blnCommunication = true;
			gstructAutoSampler.intCoordinateX = 0;
			gstructAutoSampler.intCoordinateY = 0;
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
btnTimings_Click(System.Object sender, System.EventArgs e)
	{
		frmTimings objfrmTimings = new frmTimings();
		objfrmTimings.ShowDialog();
		objfrmTimings.Dispose();
	}


	//Public Function funcFormatDataGrid()
	//    Dim objTextColumn As DataGridTextBoxColumn

	//    dgSamplerPosition.TableStyles.Clear()
	//    mdataView.Table = mobjDataTable
	//    mdataView.AllowNew = False

	//    dgSamplerPosition.DataSource = mdataView
	//    dgSamplerPosition.ReadOnly = False

	//    mobjGridTableStyle.RowHeadersVisible = False
	//    mobjGridTableStyle.BackColor = Color.FloralWhite
	//    mobjGridTableStyle.GridLineColor = Color.SandyBrown
	//    mobjGridTableStyle.HeaderBackColor = Color.FloralWhite
	//    mobjGridTableStyle.HeaderForeColor = Color.Black
	//    mobjGridTableStyle.AlternatingBackColor = Color.FloralWhite
	//    mobjGridTableStyle.AllowSorting = False
	//    mobjGridTableStyle.MappingName = "AutoSamplerPosition"

	//    objTextColumn = New DataGridTextBoxColumn
	//    objTextColumn.MappingName = "SampleID"
	//    objTextColumn.HeaderText = "SampleID"
	//    objTextColumn.Width = 90
	//    objTextColumn.ReadOnly = True
	//    objTextColumn.NullText = " "
	//    mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

	//    objTextColumn = New DataGridTextBoxColumn
	//    objTextColumn.MappingName = "SamplerPosition"
	//    objTextColumn.HeaderText = "Sampler Position"
	//    objTextColumn.Width = 105
	//    objTextColumn.ReadOnly = False
	//    objTextColumn.NullText = " "
	//    mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

	//    mobjGridTableStyle.GridLineColor = Color.Black
	//    dgSamplerPosition.TableStyles.Add(mobjGridTableStyle)
	//End Function

	private void funcFormInitialise()
	{
		// funcCreateDataTable()
		//subFormatDataGrid()
	}

	//Public Function funcCreateDataTable(ByRef structAutoSamplerPosn As structAutoSamplerPosition, ByVal strSampleName As String, ByVal intMaxSample As Integer, ByVal intMaxStandard As Integer, ByVal enumMode As EnumService_Mode)
	//    Dim NoOfChannels, temp_cnt, rec_cnt As Integer
	//    Dim objDataRow As DataRow
	//    Dim j As Integer
	//    mobjDataTable.Columns.Add(New DataColumn("SampleID", GetType(String)))
	//    mobjDataTable.Columns.Add(New DataColumn("SamplerPosition", GetType(String)))



	//    For temp_cnt = gstructAutoSamplerPosition.intSpectrumPosition + 1 To 100

	//        If temp_cnt <= 10 Then
	//            If gstructAutoSamplerPosition.intSpectrumPosition = 0 Then
	//                objDataRow = mobjDataTable.NewRow
	//                objDataRow("SamplerPosition") = (temp_cnt + 1)
	//                objDataRow("SampleID") = "Sample # " & temp_cnt
	//                mobjDataTable.Rows.Add(objDataRow)
	//            Else
	//                objDataRow = mobjDataTable.NewRow
	//                objDataRow("SamplerPosition") = 0
	//                objDataRow("SampleID") = "Sample # " & temp_cnt
	//                mobjDataTable.Rows.Add(objDataRow)
	//            End If
	//        Else
	//            objDataRow = mobjDataTable.NewRow
	//            objDataRow("SamplerPosition") = 0
	//            objDataRow("SampleID") = "Sample # " & temp_cnt
	//            mobjDataTable.Rows.Add(objDataRow)
	//        End If

	//    Next

	//End Function

	private void  // ERROR: Handles clauses are not supported in C#
frmAutoSampPosn_Load(System.Object sender, System.EventArgs e)
	{
		dgSamplerPosition.DataSource = mobjDataTable;
		dgSamplerPosition.Refresh();
	}

	private void  // ERROR: Handles clauses are not supported in C#
btnOk_Click(System.Object sender, System.EventArgs e)
	{
		int intCounter = 0;
		ArrayList arrAutoSamplerIn = new ArrayList();
		//gstructAutoSampler.arrAutoSamplerPosition = New ArrayList
		// For intCounter = 0 To mobjDataTable.Rows.Count - 1
		try {
			for (intCounter = 0; intCounter <= gstructAutoSampler.arrAutoSamplerPosition.Count - 1; intCounter++) {
				arrAutoSamplerIn.Add(gstructAutoSampler.arrAutoSamplerPosition.Item(intCounter));
			}
			if (!funcValidateSamplerPosition(mobjDataTable)) {
				this.DialogResult = DialogResult.None;
			} else {
				//While dgSamplerPosition.Item(intCounter, 1) <> 0
				//    gstructAutoSampler.arrAutoSamplerPosition.Add(dgSamplerPosition.Item(intCounter, 1))
				//    intCounter += 1
				//End While
				//  Call funcSavePosition(gstructAutoSamplerPosition, gstructAutoSampler.arrAutoSamplerPosition.Count)
				// gstructAutoSamplerPosition.intSpectrumPosition = gstructAutoSamplerPosition.intSpectrumPosition + gstructAutoSampler.arrAutoSamplerPosition.Count
				this.DialogResult = DialogResult.OK;
			}

		//added and commented by kamal on 19March2004
		//----------------------------
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

	public bool funcValidateSamplerPosition(DataTable objDataTable)
	{

		int intRowCounter;
		int intColCounter;
		int intCurrentCol;
		int intCurrentRow;
		bool blnFlag;

		try {
			//--- checking for invalid data entered in the
			//--- Grid and invoke the Error Message
			intCurrentCol = dgSamplerPosition.CurrentCell.ColumnNumber;
			intCurrentRow = dgSamplerPosition.CurrentCell.RowNumber;
			for (intRowCounter = 0; intRowCounter <= objDataTable.Rows.Count - 1; intRowCounter++) {
				intColCounter = intRowCounter;
				if (IsNumeric(dgSamplerPosition.Item(intRowCounter, 1))) {
					if (!gfuncValidateGrid(dgSamplerPosition.Item(intRowCounter, 1), 0)) {
						dgSamplerPosition.Focus();
						return false;
					}
					if (dgSamplerPosition.Item(0, 1) == 0) {
						//gFuncShowMessage("Invalid Input", "Enter sampler position for analysis", EnumMessageType.Information)
						gobjMessageAdapter.ShowMessage(constAutoSamplerPosition);
						dgSamplerPosition.Focus();
						return false;
					}
					if (dgSamplerPosition.Item(intRowCounter, 1) != 0) {
						if (dgSamplerPosition.Item(intRowCounter, 1) < 2 | dgSamplerPosition.Item(intRowCounter, 1) > 65) {
							//gFuncShowMessage("Invalid Input", "Enter sampler positions between 2 and 65 ", EnumMessageType.Information)
							gobjMessageAdapter.ShowMessage(constAutoSamplerBetween2and65);
							dgSamplerPosition.Focus();
							return false;
						}
					} else {
						if (intRowCounter <= objDataTable.Rows.Count - 2) {
							if (dgSamplerPosition.Item(intColCounter + 1, 1) != 0 | dgSamplerPosition.Item(intColCounter + 1, 1) == "") {
								//gFuncShowMessage("Invalid Input", "Enter sampler positions between 2 and 65 ", EnumMessageType.Information)
								gobjMessageAdapter.ShowMessage(constAutoSamplerBetween2and65);
								dgSamplerPosition.Focus();
								return false;
							}
						}
					}
				} else {
					if (dgSamplerPosition.Item(intRowCounter, 1) == "") {
						//gFuncShowMessage("Invalid Input", "Do not leave blank positions for intermediate samples! ", EnumMessageType.Information)
						gobjMessageAdapter.ShowMessage(constAutoSamplerBlankPositions);
						dgSamplerPosition.Focus();
						return false;
					} else {
						//gFuncShowMessage("Invalid Input", "Please enter  numeric values ! ", EnumMessageType.Information)
						gobjMessageAdapter.ShowMessage(constAutoSamplerNumericValues);
						dgSamplerPosition.Focus();
						return false;
					}
				}
			}

			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
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
btnCancel_Click(System.Object sender, System.EventArgs e)
	{
		this.Close();
	}

	private object funcSavePosition(ref structAutoSamplerPosition structAutoSamplerPosn, int intRowCounter)
	{
		//**************  To be do ******************
		//Select Case OPERATION_MODE
		//    Case EnumService_Mode.Spectrum
		//        structAutoSamplerPosn.intSpectrumPosition = structAutoSamplerPosn.intSpectrumPosition + intRowCounter
		//    Case EnumService_Mode.Photometry
		//        structAutoSamplerPosn.intPhotometryPosition = structAutoSamplerPosn.intPhotometryPosition + intRowCounter
		//    Case EnumService_Mode.Quantitative
		//        structAutoSamplerPosn.intQuantPosition = structAutoSamplerPosn.intQuantPosition + intRowCounter
		//    Case EnumService_Mode.Multiomponent
		//        structAutoSamplerPosn.intMultiPosition = structAutoSamplerPosn.intMultiPosition + intRowCounter
		//    Case EnumService_Mode.Kinetics
		//        structAutoSamplerPosn.intKineticPosition = structAutoSamplerPosn.intKineticPosition + intRowCounter
		//    Case EnumService_Mode.TimeScan
		//        structAutoSamplerPosn.intTimeScanPosition = structAutoSamplerPosn.intTimeScanPosition + intRowCounter
		//    Case Else
		//        structAutoSamplerPosn.intSpectrumPosition = structAutoSamplerPosn.intSpectrumPosition + intRowCounter
		//        'structAutoSamplerPosn.intQuantPosition = structAutoSamplerPosn.intQuantPosition + intRowCounter

		//End Select

	}

}
