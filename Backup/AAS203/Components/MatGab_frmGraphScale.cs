public class frmGraphScale : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmGraphScale()
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
	internal GradientPanel.CustomPanel CustomPanelBackground;
	internal System.Windows.Forms.Label Label4;
	internal System.Windows.Forms.Label Label3;
	internal System.Windows.Forms.Label Label2;
	internal System.Windows.Forms.Label Label1;
	internal NETXP.Controls.XPButton btnOk;
	internal NumberValidator.NumberValidator NVYMin;
	internal NumberValidator.NumberValidator NVYMax;
	internal NumberValidator.NumberValidator NVXMin;
	internal NumberValidator.NumberValidator NVXMax;
	internal NumberValidator.NumberValidator NVZMax;
	internal NumberValidator.NumberValidator NVZMin;
	internal System.Windows.Forms.Label Label5;
	internal System.Windows.Forms.Label Label6;
	internal System.Windows.Forms.Panel PanelZAxis;
	internal System.Windows.Forms.DateTimePicker dtpXMin;
	internal System.Windows.Forms.DateTimePicker dtpXMax;
	internal System.Windows.Forms.Panel PanelDateXAxis;
	internal System.Windows.Forms.Label lblXminFormat;
	internal System.Windows.Forms.Label lblXMaxFormat;
	internal System.Windows.Forms.Label Label7;
	internal System.Windows.Forms.Label Label8;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmGraphScale));
		this.CustomPanelBackground = new GradientPanel.CustomPanel();
		this.PanelDateXAxis = new System.Windows.Forms.Panel();
		this.Label8 = new System.Windows.Forms.Label();
		this.Label7 = new System.Windows.Forms.Label();
		this.lblXMaxFormat = new System.Windows.Forms.Label();
		this.lblXminFormat = new System.Windows.Forms.Label();
		this.dtpXMin = new System.Windows.Forms.DateTimePicker();
		this.dtpXMax = new System.Windows.Forms.DateTimePicker();
		this.PanelZAxis = new System.Windows.Forms.Panel();
		this.NVZMax = new NumberValidator.NumberValidator();
		this.NVZMin = new NumberValidator.NumberValidator();
		this.Label5 = new System.Windows.Forms.Label();
		this.Label6 = new System.Windows.Forms.Label();
		this.NVXMax = new NumberValidator.NumberValidator();
		this.NVXMin = new NumberValidator.NumberValidator();
		this.NVYMax = new NumberValidator.NumberValidator();
		this.NVYMin = new NumberValidator.NumberValidator();
		this.btnOk = new NETXP.Controls.XPButton();
		this.Label4 = new System.Windows.Forms.Label();
		this.Label3 = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.Label1 = new System.Windows.Forms.Label();
		this.CustomPanelBackground.SuspendLayout();
		this.PanelDateXAxis.SuspendLayout();
		this.PanelZAxis.SuspendLayout();
		this.SuspendLayout();
		//
		//CustomPanelBackground
		//
		this.CustomPanelBackground.BackColor = System.Drawing.Color.Gainsboro;
		this.CustomPanelBackground.BackColor2 = System.Drawing.Color.White;
		this.CustomPanelBackground.Controls.Add(this.PanelDateXAxis);
		this.CustomPanelBackground.Controls.Add(this.PanelZAxis);
		this.CustomPanelBackground.Controls.Add(this.NVXMax);
		this.CustomPanelBackground.Controls.Add(this.NVXMin);
		this.CustomPanelBackground.Controls.Add(this.NVYMax);
		this.CustomPanelBackground.Controls.Add(this.NVYMin);
		this.CustomPanelBackground.Controls.Add(this.btnOk);
		this.CustomPanelBackground.Controls.Add(this.Label4);
		this.CustomPanelBackground.Controls.Add(this.Label3);
		this.CustomPanelBackground.Controls.Add(this.Label2);
		this.CustomPanelBackground.Controls.Add(this.Label1);
		this.CustomPanelBackground.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanelBackground.DockPadding.All = 1;
		this.CustomPanelBackground.GradientMode = GradientPanel.LinearGradientMode.Vertical;
		this.CustomPanelBackground.Location = new System.Drawing.Point(0, 0);
		this.CustomPanelBackground.Name = "CustomPanelBackground";
		this.CustomPanelBackground.Size = new System.Drawing.Size(402, 151);
		this.CustomPanelBackground.TabIndex = 14;
		//
		//PanelDateXAxis
		//
		this.PanelDateXAxis.Controls.Add(this.Label8);
		this.PanelDateXAxis.Controls.Add(this.Label7);
		this.PanelDateXAxis.Controls.Add(this.lblXMaxFormat);
		this.PanelDateXAxis.Controls.Add(this.lblXminFormat);
		this.PanelDateXAxis.Controls.Add(this.dtpXMin);
		this.PanelDateXAxis.Controls.Add(this.dtpXMax);
		this.PanelDateXAxis.Location = new System.Drawing.Point(20, 7);
		this.PanelDateXAxis.Name = "PanelDateXAxis";
		this.PanelDateXAxis.Size = new System.Drawing.Size(368, 55);
		this.PanelDateXAxis.TabIndex = 33;
		this.PanelDateXAxis.Visible = false;
		//
		//Label8
		//
		this.Label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label8.Location = new System.Drawing.Point(192, 10);
		this.Label8.Name = "Label8";
		this.Label8.Size = new System.Drawing.Size(64, 16);
		this.Label8.TabIndex = 36;
		this.Label8.Text = "X-Axis Max";
		//
		//Label7
		//
		this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label7.Location = new System.Drawing.Point(8, 11);
		this.Label7.Name = "Label7";
		this.Label7.Size = new System.Drawing.Size(64, 15);
		this.Label7.TabIndex = 35;
		this.Label7.Text = "X-Axis Min ";
		//
		//lblXMaxFormat
		//
		this.lblXMaxFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblXMaxFormat.Location = new System.Drawing.Point(200, 32);
		this.lblXMaxFormat.Name = "lblXMaxFormat";
		this.lblXMaxFormat.Size = new System.Drawing.Size(160, 16);
		this.lblXMaxFormat.TabIndex = 34;
		this.lblXMaxFormat.Text = "(dd-MMM HH:mm)";
		this.lblXMaxFormat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		//
		//lblXminFormat
		//
		this.lblXminFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblXminFormat.Location = new System.Drawing.Point(24, 32);
		this.lblXminFormat.Name = "lblXminFormat";
		this.lblXminFormat.Size = new System.Drawing.Size(152, 16);
		this.lblXminFormat.TabIndex = 33;
		this.lblXminFormat.Text = "(dd-MMM HH:mm)";
		this.lblXminFormat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		//
		//dtpXMin
		//
		this.dtpXMin.CustomFormat = "dd-MMM HH:mm";
		this.dtpXMin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
		this.dtpXMin.Location = new System.Drawing.Point(80, 8);
		this.dtpXMin.Name = "dtpXMin";
		this.dtpXMin.ShowUpDown = true;
		this.dtpXMin.Size = new System.Drawing.Size(96, 20);
		this.dtpXMin.TabIndex = 31;
		//
		//dtpXMax
		//
		this.dtpXMax.CustomFormat = "dd-MMM HH:mm";
		this.dtpXMax.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
		this.dtpXMax.Location = new System.Drawing.Point(264, 8);
		this.dtpXMax.Name = "dtpXMax";
		this.dtpXMax.ShowUpDown = true;
		this.dtpXMax.Size = new System.Drawing.Size(96, 20);
		this.dtpXMax.TabIndex = 32;
		//
		//PanelZAxis
		//
		this.PanelZAxis.Controls.Add(this.NVZMax);
		this.PanelZAxis.Controls.Add(this.NVZMin);
		this.PanelZAxis.Controls.Add(this.Label5);
		this.PanelZAxis.Controls.Add(this.Label6);
		this.PanelZAxis.Location = new System.Drawing.Point(24, 192);
		this.PanelZAxis.Name = "PanelZAxis";
		this.PanelZAxis.Size = new System.Drawing.Size(368, 40);
		this.PanelZAxis.TabIndex = 30;
		this.PanelZAxis.Visible = false;
		//
		//NVZMax
		//
		this.NVZMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.NVZMax.DigitsAfterDecimalPoint = 4;
		this.NVZMax.ErrorColor = System.Drawing.Color.FromArgb((byte)255, (byte)192, (byte)192);
		this.NVZMax.ErrorMessage = "";
		this.NVZMax.Location = new System.Drawing.Point(272, 8);
		this.NVZMax.MaximumRange = 9999;
		this.NVZMax.MaxLength = 8;
		this.NVZMax.MinimumRange = 0;
		this.NVZMax.Name = "NVZMax";
		this.NVZMax.RangeValidation = false;
		this.NVZMax.Size = new System.Drawing.Size(88, 20);
		this.NVZMax.TabIndex = 29;
		this.NVZMax.Text = "";
		this.NVZMax.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly;
		//
		//NVZMin
		//
		this.NVZMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.NVZMin.DigitsAfterDecimalPoint = 4;
		this.NVZMin.ErrorColor = System.Drawing.Color.FromArgb((byte)255, (byte)192, (byte)192);
		this.NVZMin.ErrorMessage = "";
		this.NVZMin.Location = new System.Drawing.Point(80, 8);
		this.NVZMin.MaximumRange = 9999;
		this.NVZMin.MaxLength = 8;
		this.NVZMin.MinimumRange = 0;
		this.NVZMin.Name = "NVZMin";
		this.NVZMin.RangeValidation = false;
		this.NVZMin.Size = new System.Drawing.Size(88, 20);
		this.NVZMin.TabIndex = 28;
		this.NVZMin.Text = "";
		this.NVZMin.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly;
		//
		//Label5
		//
		this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label5.Location = new System.Drawing.Point(192, 8);
		this.Label5.Name = "Label5";
		this.Label5.Size = new System.Drawing.Size(64, 16);
		this.Label5.TabIndex = 27;
		this.Label5.Text = "Z-Axis Max";
		//
		//Label6
		//
		this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label6.Location = new System.Drawing.Point(8, 8);
		this.Label6.Name = "Label6";
		this.Label6.Size = new System.Drawing.Size(64, 20);
		this.Label6.TabIndex = 26;
		this.Label6.Text = "Z-Axis Min";
		//
		//NVXMax
		//
		this.NVXMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.NVXMax.DigitsAfterDecimalPoint = 4;
		this.NVXMax.ErrorColor = System.Drawing.Color.FromArgb((byte)255, (byte)192, (byte)192);
		this.NVXMax.ErrorMessage = "";
		this.NVXMax.Location = new System.Drawing.Point(288, 16);
		this.NVXMax.MaximumRange = 10;
		this.NVXMax.MaxLength = 8;
		this.NVXMax.MinimumRange = 0.86;
		this.NVXMax.Name = "NVXMax";
		this.NVXMax.RangeValidation = false;
		this.NVXMax.Size = new System.Drawing.Size(88, 20);
		this.NVXMax.TabIndex = 25;
		this.NVXMax.Text = "";
		this.NVXMax.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly;
		//
		//NVXMin
		//
		this.NVXMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.NVXMin.DigitsAfterDecimalPoint = 4;
		this.NVXMin.ErrorColor = System.Drawing.Color.FromArgb((byte)255, (byte)192, (byte)192);
		this.NVXMin.ErrorMessage = "";
		this.NVXMin.Location = new System.Drawing.Point(96, 16);
		this.NVXMin.MaximumRange = 0;
		this.NVXMin.MaxLength = 8;
		this.NVXMin.MinimumRange = -0.15;
		this.NVXMin.Name = "NVXMin";
		this.NVXMin.RangeValidation = false;
		this.NVXMin.Size = new System.Drawing.Size(88, 20);
		this.NVXMin.TabIndex = 24;
		this.NVXMin.Text = "";
		this.NVXMin.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly;
		//
		//NVYMax
		//
		this.NVYMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.NVYMax.DigitsAfterDecimalPoint = 4;
		this.NVYMax.ErrorColor = System.Drawing.Color.FromArgb((byte)255, (byte)192, (byte)192);
		this.NVYMax.ErrorMessage = "";
		this.NVYMax.Location = new System.Drawing.Point(288, 73);
		this.NVYMax.MaximumRange = 10;
		this.NVYMax.MaxLength = 8;
		this.NVYMax.MinimumRange = 0.5;
		this.NVYMax.Name = "NVYMax";
		this.NVYMax.RangeValidation = false;
		this.NVYMax.Size = new System.Drawing.Size(88, 20);
		this.NVYMax.TabIndex = 23;
		this.NVYMax.Text = "";
		this.NVYMax.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly;
		//
		//NVYMin
		//
		this.NVYMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.NVYMin.DigitsAfterDecimalPoint = 4;
		this.NVYMin.ErrorColor = System.Drawing.Color.FromArgb((byte)255, (byte)192, (byte)192);
		this.NVYMin.ErrorMessage = "";
		this.NVYMin.Location = new System.Drawing.Point(96, 72);
		this.NVYMin.MaximumRange = 0;
		this.NVYMin.MaxLength = 8;
		this.NVYMin.MinimumRange = -0.05;
		this.NVYMin.Name = "NVYMin";
		this.NVYMin.RangeValidation = false;
		this.NVYMin.Size = new System.Drawing.Size(88, 20);
		this.NVYMin.TabIndex = 22;
		this.NVYMin.Text = "";
		this.NVYMin.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly;
		//
		//btnOk
		//
		this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOk.Image = (System.Drawing.Image)resources.GetObject("btnOk.Image");
		this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOk.Location = new System.Drawing.Point(160, 112);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(80, 24);
		this.btnOk.TabIndex = 21;
		this.btnOk.Text = "&Apply";
		//
		//Label4
		//
		this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label4.Location = new System.Drawing.Point(208, 73);
		this.Label4.Name = "Label4";
		this.Label4.Size = new System.Drawing.Size(72, 16);
		this.Label4.TabIndex = 16;
		this.Label4.Text = "Y-Axis Max";
		//
		//Label3
		//
		this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label3.Location = new System.Drawing.Point(24, 72);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(64, 20);
		this.Label3.TabIndex = 15;
		this.Label3.Text = "Y-Axis Min";
		//
		//Label2
		//
		this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label2.Location = new System.Drawing.Point(208, 18);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(64, 16);
		this.Label2.TabIndex = 14;
		this.Label2.Text = "X-Axis Max";
		//
		//Label1
		//
		this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label1.Location = new System.Drawing.Point(24, 19);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(64, 15);
		this.Label1.TabIndex = 13;
		this.Label1.Text = "X-Axis Min ";
		//
		//frmGraphScale
		//
		this.AcceptButton = this.btnOk;
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(402, 151);
		this.Controls.Add(this.CustomPanelBackground);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmGraphScale";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "  Change Scale";
		this.CustomPanelBackground.ResumeLayout(false);
		this.PanelDateXAxis.ResumeLayout(false);
		this.PanelZAxis.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Class Member Variables "

	private ErrorProvider err = new ErrorProvider();
	private bool blnXAxisWavelength;
	private bool blnIsSpaceDiagram;

	private bool blnIsCIEDiagram;
	private double constXMin = 0;
	private double constMin = -100;

	private double constMax = 1100;

	private bool mblnIsXAxisDateTime;
	#End Region

	#Region " Public Properties "

	public bool XAxisWavelength {
		get { return blnXAxisWavelength; }
		set { blnXAxisWavelength = Value; }
	}

	public bool IsColorSpaceDiagram {
		get { return blnIsSpaceDiagram; }
		set {
			blnIsSpaceDiagram = Value;
			if (blnIsSpaceDiagram == true) {
				this.PanelZAxis.Visible = true;
			}
		}
	}

	public bool IsCIEDiagram {
		get { return blnIsCIEDiagram; }
		set { blnIsCIEDiagram = Value; }
	}

	public bool IsXAxisDateTime {
		get { return mblnIsXAxisDateTime; }
		set {
			mblnIsXAxisDateTime = Value;
			if (mblnIsXAxisDateTime == true) {
				this.PanelDateXAxis.Visible = true;
			}
		}
	}

	#End Region

	#Region " Private Functions "

	private bool Addhandlers()
	{
		try {
			btnOk.Click += subbtnOk_Click;

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

	#Region " Form Load And Event Handling Functions "

	private void subbtnOk_Click(System.Object sender, System.EventArgs e)
	{
		try {
			//If Len(NVXMin.Text) <= 0 Then
			//    gobjMessageAdapter.ShowMessage(msgIDPlzEnterProperScaleLimits)
			//    Application.DoEvents()
			//    NVXMin.Focus()
			//    Exit Try
			//End If

			//If Len(NVXMax.Text) <= 0 Then
			//    gobjMessageAdapter.ShowMessage(msgIDPlzEnterProperScaleLimits)
			//    Application.DoEvents()
			//    NVXMax.Focus()
			//    Exit Try
			//End If

			//If Len(NVYMin.Text) <= 0 Then
			//    gobjMessageAdapter.ShowMessage(msgIDPlzEnterProperScaleLimits)
			//    Application.DoEvents()
			//    NVYMin.Focus()
			//    Exit Try
			//End If

			//If Len(NVYMax.Text) <= 0 Then
			//    gobjMessageAdapter.ShowMessage(msgIDPlzEnterProperScaleLimits)
			//    Application.DoEvents()
			//    NVYMax.Focus()
			//    Exit Try
			//End If

			if (blnIsCIEDiagram == true) {
				//If CDbl(NVXMin.Text) < -100 Then
				//    gobjMessageAdapter.ShowMessage(msgIDMinOfXAxisWavelengthCannotLessThanMinus100)
				//    Application.DoEvents()
				//    NVXMin.Focus()
				//    Exit Try
				//End If

				//If CDbl(NVXMax.Text) > 100 Then
				//    gobjMessageAdapter.ShowMessage(msgIDMaxOfXAxisCannotGreaterThan100)
				//    Application.DoEvents()
				//    NVXMax.Focus()
				//    Exit Try
				//End If

				//If CDbl(NVYMin.Text) < -100 Then
				//    gobjMessageAdapter.ShowMessage(msgIDMinOfYAxisCannotLessThanMinus100)
				//    Application.DoEvents()
				//    NVYMin.Focus()
				//    Exit Try
				//End If

				//If CDbl(NVYMax.Text) > 100 Then
				//    gobjMessageAdapter.ShowMessage(msgIDMaxOfYAxisCannotGreaterThan100)
				//    Application.DoEvents()
				//    NVYMax.Focus()
				//    Exit Try
				//End If

				this.DialogResult = DialogResult.OK;
				this.Close();
				break; // TODO: might not be correct. Was : Exit Try
			}

			if (blnIsSpaceDiagram == false) {
			//If blnXAxisWavelength = True Then
			//    If CDbl(NVXMin.Text) < 300 Then
			//        gobjMessageAdapter.ShowMessage(msgIDMinOfXAxisWavelengthCannotLessThan300)
			//        Application.DoEvents()
			//        NVXMin.Focus()
			//        Exit Try
			//    End If
			//Else
			//    If CDbl(NVXMin.Text) < constXMin Then
			//        gobjMessageAdapter.ShowMessage(msgIDMinOfXAxisCannotLessThanZero)
			//        Application.DoEvents()
			//        NVXMin.Focus()
			//        Exit Try
			//    End If
			//End If

			//If CDbl(NVYMin.Text) < constMin Then
			//    gobjMessageAdapter.ShowMessage(msgIDMinCannotLessThanMinus100)
			//    Application.DoEvents()
			//    NVYMin.Focus()
			//    Exit Try
			//End If

			//If CDbl(NVXMin.Text) >= CDbl(NVXMax.Text) Or _
			//        CDbl(NVYMin.Text) >= CDbl(NVYMax.Text) Then
			//    gobjMessageAdapter.ShowMessage(msgIDMinCannotGreaterThanMax)
			//    Application.DoEvents()
			//    Exit Try
			//End If

			//If CDbl(NVXMax.Text) > constMax Or CDbl(NVYMax.Text) > constMax Then
			//    gobjMessageAdapter.ShowMessage(msgIDMaxCannotGreaterThan1100)
			//    Application.DoEvents()
			//    Exit Try
			//End If
			} else {
				//If Len(NVZMin.Text) <= 0 Then
				//    gobjMessageAdapter.ShowMessage(msgIDPlzEnterProperScaleLimits)
				//    Application.DoEvents()
				//    NVZMin.Focus()
				//    Exit Try
				//End If

				//If Len(NVZMax.Text) <= 0 Then
				//    gobjMessageAdapter.ShowMessage(msgIDPlzEnterProperScaleLimits)
				//    Application.DoEvents()
				//    NVZMax.Focus()
				//    Exit Try
				//End If

				//If CDbl(NVXMin.Text) < -100 Then
				//    gobjMessageAdapter.ShowMessage(msgIDMinOfXAxisWavelengthCannotLessThanMinus100)
				//    Application.DoEvents()
				//    NVXMin.Focus()
				//    Exit Try
				//End If

				//If CDbl(NVXMax.Text) > 100 Then
				//    gobjMessageAdapter.ShowMessage(msgIDMaxOfXAxisCannotGreaterThan100)
				//    Application.DoEvents()
				//    NVXMax.Focus()
				//    Exit Try
				//End If

				//If CDbl(NVYMin.Text) < -100 Then
				//    gobjMessageAdapter.ShowMessage(msgIDMinOfYAxisCannotLessThanMinus100)
				//    Application.DoEvents()
				//    NVYMin.Focus()
				//    Exit Try
				//End If

				//If CDbl(NVYMax.Text) > 100 Then
				//    gobjMessageAdapter.ShowMessage(msgIDMaxOfYAxisCannotGreaterThan100)
				//    Application.DoEvents()
				//    NVYMax.Focus()
				//    Exit Try
				//End If

				//If CDbl(NVZMin.Text) < -100 Then
				//    gobjMessageAdapter.ShowMessage(msgIDMinOfZAxisCannotLessThanMinus100)
				//    Application.DoEvents()
				//    NVZMin.Focus()
				//    Exit Try
				//End If

				//If CDbl(NVZMax.Text) > 100 Then
				//    gobjMessageAdapter.ShowMessage(msgIDMaxOfZAxisCannotGreaterThan100)
				//    Application.DoEvents()
				//    NVZMax.Focus()
				//    Exit Try
				//End If

				//If CDbl(NVXMin.Text) >= 0 Or CDbl(NVXMax.Text) <= 0 Or _
				//        CDbl(NVYMin.Text) >= 0 Or CDbl(NVYMax.Text) <= 0 Or _
				//        CDbl(NVZMin.Text) >= 0 Or CDbl(NVZMax.Text) <= 0 Then
				//    gobjMessageAdapter.ShowMessage(msgIDMinMaxCannotGreaterLessThan1)
				//    Application.DoEvents()
				//    Exit Try
				//End If
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
			//---------------------------------------------------------
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
frmGraphScale_Load(System.Object sender, System.EventArgs e)
	{
		Addhandlers();
	}

	#End Region

	#Region " Validation Status Functions "

	private void  // ERROR: Handles clauses are not supported in C#
NVXMin_ValidationStatus(NumberValidator.NumberValidator.Status Status, string Msg)
	{
		//17.03.06 deepak 
		if (Status == NumberValidator.NumberValidator.Status.NotValidated) {
			NVXMin.Focus();
			btnOk.Enabled = false;
		} else {
			btnOk.Enabled = true;
		}
		err.SetError(NVXMin, Msg);
	}

	private void  // ERROR: Handles clauses are not supported in C#
NVXMax_ValidationStatus(NumberValidator.NumberValidator.Status Status, string Msg)
	{
		//17.03.06 deepak 
		if (Status == NumberValidator.NumberValidator.Status.NotValidated) {
			NVXMax.Focus();
			btnOk.Enabled = false;
		} else {
			btnOk.Enabled = true;
		}
		err.SetError(NVXMax, Msg);
	}

	private void  // ERROR: Handles clauses are not supported in C#
NVYMin_ValidationStatus(NumberValidator.NumberValidator.Status Status, string Msg)
	{
		//17.03.06 deepak 
		if (Status == NumberValidator.NumberValidator.Status.NotValidated) {
			NVYMin.Focus();
			btnOk.Enabled = false;
		} else {
			btnOk.Enabled = true;
		}
		err.SetError(NVYMin, Msg);
	}

	private void  // ERROR: Handles clauses are not supported in C#
NVYMax_ValidationStatus(NumberValidator.NumberValidator.Status Status, string Msg)
	{
		//17.03.06 deepak 
		if (Status == NumberValidator.NumberValidator.Status.NotValidated) {
			NVYMax.Focus();
			btnOk.Enabled = false;
		} else {
			btnOk.Enabled = true;
		}
		err.SetError(NVYMax, Msg);
	}

	#End Region

}
