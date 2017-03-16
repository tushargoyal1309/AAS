public class frmCoordinatePositions : System.Windows.Forms.Form
{
	public int mintXCoordinate;

	public int mintYCoordinate;
	#Region " Windows Form Designer generated code "

	public frmCoordinatePositions(int mintx, int minty)
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();
		mintXCoordinate = mintx;
		mintYCoordinate = minty;
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
	internal System.Windows.Forms.GroupBox GroupBox1;
	internal System.Windows.Forms.Label lblXAxis;
	internal System.Windows.Forms.Label lblYAxis;
	internal System.Windows.Forms.Button btnOk;
	internal System.Windows.Forms.Button btnCancel;
	internal NumberValidator.NumberValidator txtYCoordinate;
	internal NumberValidator.NumberValidator txtXCoordinate;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmCoordinatePositions));
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.txtXCoordinate = new NumberValidator.NumberValidator();
		this.txtYCoordinate = new NumberValidator.NumberValidator();
		this.lblYAxis = new System.Windows.Forms.Label();
		this.lblXAxis = new System.Windows.Forms.Label();
		this.btnOk = new System.Windows.Forms.Button();
		this.btnCancel = new System.Windows.Forms.Button();
		this.GroupBox1.SuspendLayout();
		this.SuspendLayout();
		//
		//GroupBox1
		//
		this.GroupBox1.Controls.Add(this.txtXCoordinate);
		this.GroupBox1.Controls.Add(this.txtYCoordinate);
		this.GroupBox1.Controls.Add(this.lblYAxis);
		this.GroupBox1.Controls.Add(this.lblXAxis);
		this.GroupBox1.Location = new System.Drawing.Point(0, 0);
		this.GroupBox1.Name = "GroupBox1";
		this.GroupBox1.Size = new System.Drawing.Size(272, 136);
		this.GroupBox1.TabIndex = 0;
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = "Coordinates";
		//
		//txtXCoordinate
		//
		this.txtXCoordinate.DigitsAfterDecimalPoint = 0;
		this.txtXCoordinate.ErrorColor = System.Drawing.Color.Empty;
		this.txtXCoordinate.ErrorMessage = null;
		this.txtXCoordinate.Location = new System.Drawing.Point(161, 36);
		this.txtXCoordinate.MaximumRange = 0;
		this.txtXCoordinate.MinimumRange = 0;
		this.txtXCoordinate.Name = "txtXCoordinate";
		this.txtXCoordinate.RangeValidation = false;
		this.txtXCoordinate.Size = new System.Drawing.Size(80, 21);
		this.txtXCoordinate.TabIndex = 5;
		this.txtXCoordinate.Text = "";
		this.txtXCoordinate.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly;
		//
		//txtYCoordinate
		//
		this.txtYCoordinate.DigitsAfterDecimalPoint = 0;
		this.txtYCoordinate.ErrorColor = System.Drawing.Color.Empty;
		this.txtYCoordinate.ErrorMessage = null;
		this.txtYCoordinate.Location = new System.Drawing.Point(161, 92);
		this.txtYCoordinate.MaximumRange = 0;
		this.txtYCoordinate.MinimumRange = 0;
		this.txtYCoordinate.Name = "txtYCoordinate";
		this.txtYCoordinate.RangeValidation = false;
		this.txtYCoordinate.Size = new System.Drawing.Size(80, 21);
		this.txtYCoordinate.TabIndex = 4;
		this.txtYCoordinate.Text = "";
		this.txtYCoordinate.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly;
		//
		//lblYAxis
		//
		this.lblYAxis.Location = new System.Drawing.Point(38, 88);
		this.lblYAxis.Name = "lblYAxis";
		this.lblYAxis.Size = new System.Drawing.Size(108, 24);
		this.lblYAxis.TabIndex = 1;
		this.lblYAxis.Text = "Enter Y Position :";
		this.lblYAxis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblXAxis
		//
		this.lblXAxis.Location = new System.Drawing.Point(38, 32);
		this.lblXAxis.Name = "lblXAxis";
		this.lblXAxis.Size = new System.Drawing.Size(108, 24);
		this.lblXAxis.TabIndex = 0;
		this.lblXAxis.Text = "Enter X Position :";
		this.lblXAxis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//btnOk
		//
		this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.btnOk.Image = (System.Drawing.Image)resources.GetObject("btnOk.Image");
		this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOk.Location = new System.Drawing.Point(112, 144);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(72, 32);
		this.btnOk.TabIndex = 1;
		this.btnOk.Text = "&Ok";
		//
		//btnCancel
		//
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.btnCancel.Image = (System.Drawing.Image)resources.GetObject("btnCancel.Image");
		this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCancel.Location = new System.Drawing.Point(192, 144);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(72, 32);
		this.btnCancel.TabIndex = 2;
		this.btnCancel.Text = "&Cancel";
		this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		//
		//frmCoordinatePositions
		//
		this.AcceptButton = this.btnOk;
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.ClientSize = new System.Drawing.Size(274, 183);
		this.Controls.Add(this.btnCancel);
		this.Controls.Add(this.btnOk);
		this.Controls.Add(this.GroupBox1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmCoordinatePositions";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "frmCoordinatePositions";
		this.GroupBox1.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	//Private Sub txtXCoordinate_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtXCoordinate.KeyUp
	//    mfuncAceptInteger(txtXCoordinate, e)
	//End Sub

	//Private Sub txtYCoordinate_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtYCoordinate.KeyUp
	//    mfuncAceptInteger(txtYCoordinate, e)
	//End Sub

	private void  // ERROR: Handles clauses are not supported in C#
frmCoordinatePositions_Load(System.Object sender, System.EventArgs e)
	{
		txtXCoordinate.Text = mintXCoordinate.ToString;
		txtYCoordinate.Text = mintYCoordinate.ToString;
	}
	private object funcValidation()
	{
		try {
			if (Val(txtXCoordinate.Text) > 12 | Val(txtXCoordinate.Text) < 0) {
				//gFuncShowMessage("Invalid X-Coordinate", "Enter the X coordinate between 0 and 12", EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage(constAutoSamplerXaxisValue);
				txtXCoordinate.Focus();
				return false;
			}
			if (Val(txtYCoordinate.Text) > 5 | Val(txtYCoordinate.Text) < 0) {
				//gFuncShowMessage("Invalid Y-Coordinate", "Enter the Y coordinate between 0 and 5", EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage(constAutoSamplerYaxisValue);
				txtYCoordinate.Focus();
				return false;
			}
			return true;

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
btnOk_Click(System.Object sender, System.EventArgs e)
	{
		if (!funcValidation()) {
			this.DialogResult = DialogResult.None;
		} else {
			mintXCoordinate = Val(txtXCoordinate.Text);
			mintYCoordinate = Val(txtYCoordinate.Text);
			this.DialogResult = DialogResult.OK;
			// Me.Close()
		}

	}
}
