public class frmAboutUs : System.Windows.Forms.Form
{


	#Region " Windows Form Designer generated code "

	public frmAboutUs()
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
	internal NETXP.Controls.XPButton btnOK;
	internal ValueEditor.ValueEditor ValueEditor1;
	internal System.Windows.Forms.NumericUpDown NumericUpDown1;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmAboutUs));
		this.btnOK = new NETXP.Controls.XPButton();
		this.ValueEditor1 = new ValueEditor.ValueEditor();
		this.NumericUpDown1 = new System.Windows.Forms.NumericUpDown();
		((System.ComponentModel.ISupportInitialize)this.NumericUpDown1).BeginInit();
		this.SuspendLayout();
		//
		//btnOK
		//
		this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnOK.Image = (System.Drawing.Image)resources.GetObject("btnOK.Image");
		this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOK.Location = new System.Drawing.Point(450, 388);
		this.btnOK.Name = "btnOK";
		this.btnOK.Size = new System.Drawing.Size(86, 32);
		this.btnOK.TabIndex = 0;
		this.btnOK.Text = "&OK";
		//
		//ValueEditor1
		//
		this.ValueEditor1.BackColor = System.Drawing.Color.Gray;
		this.ValueEditor1.BackgroundColor = System.Drawing.Color.Gray;
		this.ValueEditor1.ButtonClicked = ValueEditor.ValueEditor.EnumValueEditorButtons.MainButton;
		this.ValueEditor1.ChangeFactor = 0.1;
		this.ValueEditor1.DecimalPlace = 0;
		this.ValueEditor1.DnButtonText = "";
		this.ValueEditor1.ForeColor = System.Drawing.SystemColors.ControlText;
		this.ValueEditor1.ForegroundColor = System.Drawing.SystemColors.ControlText;
		this.ValueEditor1.IsReverseOperation = false;
		this.ValueEditor1.IsUpDownButtonToBeDisabledOnValueChange = false;
		this.ValueEditor1.Location = new System.Drawing.Point(62, 50);
		this.ValueEditor1.MaxValue = 1000;
		this.ValueEditor1.MinValue = 0;
		this.ValueEditor1.Name = "ValueEditor1";
		this.ValueEditor1.Size = new System.Drawing.Size(102, 16);
		this.ValueEditor1.TabIndex = 1;
		this.ValueEditor1.UpButtonText = "";
		this.ValueEditor1.Value = 0;
		this.ValueEditor1.ValueEditorEnabled = true;
		this.ValueEditor1.ValueEditorFont = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		//
		//NumericUpDown1
		//
		this.NumericUpDown1.Increment = new decimal(new int[] {
			1,
			0,
			0,
			65536
		});
		this.NumericUpDown1.Location = new System.Drawing.Point(80, 150);
		this.NumericUpDown1.Name = "NumericUpDown1";
		this.NumericUpDown1.Size = new System.Drawing.Size(68, 20);
		this.NumericUpDown1.TabIndex = 2;
		//
		//frmAboutUs
		//
		this.AcceptButton = this.btnOK;
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.BackColor = System.Drawing.Color.FromArgb((byte)224, (byte)224, (byte)224);
		this.CancelButton = this.btnOK;
		this.ClientSize = new System.Drawing.Size(550, 478);
		this.Controls.Add(this.NumericUpDown1);
		this.Controls.Add(this.ValueEditor1);
		this.Controls.Add(this.btnOK);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmAboutUs";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "About Us";
		this.TransparencyKey = System.Drawing.Color.FromArgb((byte)255, (byte)128, (byte)0);
		((System.ComponentModel.ISupportInitialize)this.NumericUpDown1).EndInit();
		this.ResumeLayout(false);

	}

	#End Region

	frmEditValues obj = new frmEditValues();
	private Point MouseOffset;

	private bool isMouseDown = false;
	private void  // ERROR: Handles clauses are not supported in C#
frmAboutUs_Load(System.Object sender, System.EventArgs e)
	{
		//-----------------------------------------------------------------
		//Procedure Name         :   frmAboutUs_Load
		//Description            :   do some initialisation here for form load.        
		//Parameters             :   None
		//Time/Date              :   25/9/06
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Praveen
		//-----------------------------------------------------------------
		System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Red);
		System.Drawing.Graphics formGraphics;
		try {
			if (!designmode) {
				formGraphics = this.CreateGraphics();
				formGraphics.DrawLine(myPen, 150, 150, 200, 200);

				myPen.Dispose();
				formGraphics.Dispose();
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
XpButton1_Click(System.Object sender, System.EventArgs e)
	{
		//-----------------------------------------------------------------
		//Procedure Name         :   XpButton1_Click
		//Description            :   to close the form       
		//Parameters             :   None
		//Time/Date              :   25/9/06
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Praveen
		//-----------------------------------------------------------------
		this.Close();
	}

	private void  // ERROR: Handles clauses are not supported in C#
Form3_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
	{
		//-----------------------------------------------------------------
		//Procedure Name         :   Form3_MouseDown
		//Description            :   handle a mouse down event.    
		//Parameters             :   None
		//Time/Date              :   25/9/06
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Praveen
		//-----------------------------------------------------------------
		int xOffset;
		int yOffset;
		try {
			if (e.Button == MouseButtons.Left) {
				xOffset = -e.X - SystemInformation.FrameBorderSize.Width;
				yOffset = -e.Y - SystemInformation.CaptionHeight - SystemInformation.FrameBorderSize.Height;
				MouseOffset = new Point(xOffset, yOffset);
				isMouseDown = true;
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
Form3_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
	{
		//-----------------------------------------------------------------
		//Procedure Name         :   Form3_MouseDown
		//Description            :   handle a mouse move event.    
		//Parameters             :   None
		//Time/Date              :   25/9/06
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Praveen
		//-----------------------------------------------------------------
		try {
			if (isMouseDown) {
				Point mousePos = Control.MousePosition;
				mousePos.Offset(MouseOffset.X, MouseOffset.Y);
				Location = mousePos;
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
Form3_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
	{
		//-----------------------------------------------------------------
		//Procedure Name         :   Form3_MouseUp
		//Description            :   handle a mouse up event.    
		//Parameters             :   None
		//Time/Date              :   25/9/06
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Praveen
		//-----------------------------------------------------------------
		try {
			if (e.Button == MouseButtons.Left) {
				isMouseDown = false;
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
ValueEditor1_click()
	{
		//-----------------------------------------------------------------
		//Procedure Name         :   ValueEditor1_click
		//Description            :   handle a value editor click event.    
		//Parameters             :   None
		//Time/Date              :   25/9/06
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Praveen
		//-----------------------------------------------------------------
		try {
			if (obj.ShowDialog() == DialogResult.Cancel) {
				return;
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

	//Handles obj.ReturnValue
	private void mobjfrmEditValues_ReturnValue(double dblValue, int intValue1)
	{
		//-----------------------------------------------------------------
		//Procedure Name         :   mobjfrmEditValues_ReturnValue
		//Description            :   this will set a return value for EDIT value form.   
		//Parameters             :   None
		//Time/Date              :   25/9/06
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Praveen
		//-----------------------------------------------------------------
		try {
			ValueEditor1.Value = dblValue;
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
ValueEditor1_click(double a)
	{
	}


}
