public class frmTurretElements : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmTurretElements()
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
	internal System.Windows.Forms.Label lblLamp1;
	internal System.Windows.Forms.Label lblLamp2;
	internal System.Windows.Forms.Label lblLamp3;
	internal System.Windows.Forms.Label lblLamp4;
	internal System.Windows.Forms.Label lblLamp5;
	internal System.Windows.Forms.Label lblLamp6;
	internal System.Windows.Forms.Button Button1;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		this.lblLamp1 = new System.Windows.Forms.Label();
		this.lblLamp2 = new System.Windows.Forms.Label();
		this.lblLamp3 = new System.Windows.Forms.Label();
		this.lblLamp4 = new System.Windows.Forms.Label();
		this.lblLamp5 = new System.Windows.Forms.Label();
		this.lblLamp6 = new System.Windows.Forms.Label();
		this.Button1 = new System.Windows.Forms.Button();
		this.SuspendLayout();
		//
		//lblLamp1
		//
		this.lblLamp1.BackColor = System.Drawing.Color.Gainsboro;
		this.lblLamp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblLamp1.Location = new System.Drawing.Point(82, 34);
		this.lblLamp1.Name = "lblLamp1";
		this.lblLamp1.Size = new System.Drawing.Size(64, 24);
		this.lblLamp1.TabIndex = 0;
		this.lblLamp1.Text = "1-Cu";
		this.lblLamp1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblLamp2
		//
		this.lblLamp2.BackColor = System.Drawing.Color.Gainsboro;
		this.lblLamp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblLamp2.Location = new System.Drawing.Point(148, 78);
		this.lblLamp2.Name = "lblLamp2";
		this.lblLamp2.Size = new System.Drawing.Size(64, 24);
		this.lblLamp2.TabIndex = 1;
		this.lblLamp2.Text = "2-Al";
		this.lblLamp2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblLamp3
		//
		this.lblLamp3.BackColor = System.Drawing.Color.Gainsboro;
		this.lblLamp3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblLamp3.ForeColor = System.Drawing.Color.LimeGreen;
		this.lblLamp3.Location = new System.Drawing.Point(148, 130);
		this.lblLamp3.Name = "lblLamp3";
		this.lblLamp3.Size = new System.Drawing.Size(64, 24);
		this.lblLamp3.TabIndex = 2;
		this.lblLamp3.Text = "3-Multi";
		this.lblLamp3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblLamp4
		//
		this.lblLamp4.BackColor = System.Drawing.Color.Gainsboro;
		this.lblLamp4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblLamp4.Location = new System.Drawing.Point(82, 166);
		this.lblLamp4.Name = "lblLamp4";
		this.lblLamp4.Size = new System.Drawing.Size(64, 24);
		this.lblLamp4.TabIndex = 3;
		this.lblLamp4.Text = "4-Cu";
		this.lblLamp4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblLamp5
		//
		this.lblLamp5.BackColor = System.Drawing.Color.Gainsboro;
		this.lblLamp5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblLamp5.Location = new System.Drawing.Point(12, 131);
		this.lblLamp5.Name = "lblLamp5";
		this.lblLamp5.Size = new System.Drawing.Size(64, 24);
		this.lblLamp5.TabIndex = 4;
		this.lblLamp5.Text = "5-Pb";
		this.lblLamp5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblLamp6
		//
		this.lblLamp6.BackColor = System.Drawing.Color.Gainsboro;
		this.lblLamp6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblLamp6.Location = new System.Drawing.Point(12, 77);
		this.lblLamp6.Name = "lblLamp6";
		this.lblLamp6.Size = new System.Drawing.Size(64, 24);
		this.lblLamp6.TabIndex = 5;
		this.lblLamp6.Text = "6-As";
		this.lblLamp6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//Button1
		//
		this.Button1.Location = new System.Drawing.Point(100, 100);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(24, 24);
		this.Button1.TabIndex = 7;
		this.Button1.Text = "X";
		//
		//frmTurretElements
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.BackColor = System.Drawing.Color.Gainsboro;
		this.ClientSize = new System.Drawing.Size(225, 225);
		this.Controls.Add(this.Button1);
		this.Controls.Add(this.lblLamp6);
		this.Controls.Add(this.lblLamp5);
		this.Controls.Add(this.lblLamp4);
		this.Controls.Add(this.lblLamp3);
		this.Controls.Add(this.lblLamp2);
		this.Controls.Add(this.lblLamp1);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmTurretElements";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.TransparencyKey = System.Drawing.Color.Gainsboro;
		this.ResumeLayout(false);

	}

	private void  // ERROR: Handles clauses are not supported in C#
frmTurretElements_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmTurretElements_Paint
		// Parameters Passed     : object,paint event args
		// Returns               : 
		// Purpose               : to draw the form in circular shape
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 09.09.08
		// Revisions             : 
		//=====================================================================
		System.Drawing.Graphics gr = this.CreateGraphics;
		gr.FillEllipse(System.Drawing.Brushes.Gainsboro, 0, 0, this.ClientSize.Width - 5, this.ClientSize.Height - 5);
	}

	#End Region

	#Region "Form Events"

	private void  // ERROR: Handles clauses are not supported in C#
frmTurretElements_Load(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmTurretElements_Load
		// Parameters Passed     : object,event args
		// Returns               : 
		// Purpose               : to display lamp positions in turret
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 09.09.08
		// Revisions             : 
		//=====================================================================
		try {
			int intCount;
			Control ctrl;
			foreach ( ctrl in this.Controls) {
				if (ctrl is Label) {
					((Label)ctrl).ForeColor = Color.Black;
				}
			}
			for (intCount = 0; intCount <= gobjInst.Lamp.LampParametersCollection.Count - 1; intCount++) {
				if (gobjInst.Lamp_Position == intCount + 1) {
					switch (intCount + 1) {
						case 1:
							//Color.LimeGreen  
							lblLamp1.ForeColor = Color.PaleVioletRed;
						case 2:
							//Color.LimeGreen  
							lblLamp2.ForeColor = Color.PaleVioletRed;
						case 3:
							//Color.LimeGreen  
							lblLamp3.ForeColor = Color.PaleVioletRed;
						case 4:
							//Color.LimeGreen  
							lblLamp4.ForeColor = Color.PaleVioletRed;
						case 5:
							//Color.LimeGreen  
							lblLamp5.ForeColor = Color.PaleVioletRed;
						case 6:
							//Color.LimeGreen  
							lblLamp6.ForeColor = Color.PaleVioletRed;
					}
				}
				switch (intCount + 1) {
					case 1:
						lblLamp1.Text = "1-" + gobjInst.Lamp.LampParametersCollection(intCount).ElementName;
					case 2:
						lblLamp2.Text = "2-" + gobjInst.Lamp.LampParametersCollection(intCount).ElementName;
					case 3:
						lblLamp3.Text = "3-" + gobjInst.Lamp.LampParametersCollection(intCount).ElementName;
					case 4:
						lblLamp4.Text = "4-" + gobjInst.Lamp.LampParametersCollection(intCount).ElementName;
					case 5:
						lblLamp5.Text = "5-" + gobjInst.Lamp.LampParametersCollection(intCount).ElementName;
					case 6:
						lblLamp6.Text = "6-" + gobjInst.Lamp.LampParametersCollection(intCount).ElementName;
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
Button1_Click(System.Object sender, System.EventArgs e)
	{
		try {
			this.Close();
			this.Dispose();
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
