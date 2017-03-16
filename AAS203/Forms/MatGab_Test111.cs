public class Test111 : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public Test111()
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
	internal GradientPanel.CustomPanel CustomPanelTop;
	internal System.Windows.Forms.Label lblYValue;
	internal System.Windows.Forms.Label lblWvPos;
	internal NETXP.Controls.XPButton cmdChangeScale;
	internal System.Windows.Forms.Label lblSlitWidthnm;
	internal System.Windows.Forms.Label lblPMTVolts;
	internal System.Windows.Forms.Label lblD2CurmA;
	internal System.Windows.Forms.ComboBox cmbModes;
	internal System.Windows.Forms.Label lblModes;
	internal System.Windows.Forms.Label lblSpeed;
	internal System.Windows.Forms.ComboBox cmbSpeed;
	internal System.Windows.Forms.Label lblSlitWidth;
	internal System.Windows.Forms.NumericUpDown nudSlit;
	internal System.Windows.Forms.NumericUpDown nudD2Cur;
	internal System.Windows.Forms.Label lblD2Cur;
	internal System.Windows.Forms.Label lblPMT;
	internal System.Windows.Forms.NumericUpDown nudPMT;
	internal System.Windows.Forms.Button Button1;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		this.CustomPanelTop = new GradientPanel.CustomPanel();
		this.lblYValue = new System.Windows.Forms.Label();
		this.lblWvPos = new System.Windows.Forms.Label();
		this.cmdChangeScale = new NETXP.Controls.XPButton();
		this.lblSlitWidthnm = new System.Windows.Forms.Label();
		this.lblPMTVolts = new System.Windows.Forms.Label();
		this.lblD2CurmA = new System.Windows.Forms.Label();
		this.cmbModes = new System.Windows.Forms.ComboBox();
		this.lblModes = new System.Windows.Forms.Label();
		this.lblSpeed = new System.Windows.Forms.Label();
		this.cmbSpeed = new System.Windows.Forms.ComboBox();
		this.lblSlitWidth = new System.Windows.Forms.Label();
		this.nudSlit = new System.Windows.Forms.NumericUpDown();
		this.nudD2Cur = new System.Windows.Forms.NumericUpDown();
		this.lblD2Cur = new System.Windows.Forms.Label();
		this.lblPMT = new System.Windows.Forms.Label();
		this.nudPMT = new System.Windows.Forms.NumericUpDown();
		this.Button1 = new System.Windows.Forms.Button();
		this.CustomPanelTop.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.nudSlit).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.nudD2Cur).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.nudPMT).BeginInit();
		this.SuspendLayout();
		//
		//CustomPanelTop
		//
		this.CustomPanelTop.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanelTop.Controls.Add(this.lblYValue);
		this.CustomPanelTop.Controls.Add(this.lblWvPos);
		this.CustomPanelTop.Controls.Add(this.cmdChangeScale);
		this.CustomPanelTop.Controls.Add(this.lblSlitWidthnm);
		this.CustomPanelTop.Controls.Add(this.lblPMTVolts);
		this.CustomPanelTop.Controls.Add(this.lblD2CurmA);
		this.CustomPanelTop.Controls.Add(this.cmbModes);
		this.CustomPanelTop.Controls.Add(this.lblModes);
		this.CustomPanelTop.Controls.Add(this.lblSpeed);
		this.CustomPanelTop.Controls.Add(this.cmbSpeed);
		this.CustomPanelTop.Controls.Add(this.lblSlitWidth);
		this.CustomPanelTop.Controls.Add(this.nudSlit);
		this.CustomPanelTop.Controls.Add(this.nudD2Cur);
		this.CustomPanelTop.Controls.Add(this.lblD2Cur);
		this.CustomPanelTop.Controls.Add(this.lblPMT);
		this.CustomPanelTop.Controls.Add(this.nudPMT);
		this.CustomPanelTop.Dock = System.Windows.Forms.DockStyle.Left;
		this.CustomPanelTop.Location = new System.Drawing.Point(0, 0);
		this.CustomPanelTop.Name = "CustomPanelTop";
		this.CustomPanelTop.Size = new System.Drawing.Size(208, 493);
		this.CustomPanelTop.TabIndex = 2;
		//
		//lblYValue
		//
		this.lblYValue.BackColor = System.Drawing.Color.White;
		this.lblYValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblYValue.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblYValue.ForeColor = System.Drawing.Color.Blue;
		this.lblYValue.Location = new System.Drawing.Point(9, 322);
		this.lblYValue.Name = "lblYValue";
		this.lblYValue.Size = new System.Drawing.Size(187, 20);
		this.lblYValue.TabIndex = 45;
		this.lblYValue.Text = "";
		//
		//lblWvPos
		//
		this.lblWvPos.AutoSize = true;
		this.lblWvPos.BackColor = System.Drawing.Color.White;
		this.lblWvPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblWvPos.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblWvPos.ForeColor = System.Drawing.Color.Blue;
		this.lblWvPos.Location = new System.Drawing.Point(9, 280);
		this.lblWvPos.Name = "lblWvPos";
		this.lblWvPos.Size = new System.Drawing.Size(114, 20);
		this.lblWvPos.TabIndex = 44;
		this.lblWvPos.Text = "Wavelength (nm) :";
		//
		//cmdChangeScale
		//
		this.cmdChangeScale.Enabled = false;
		this.cmdChangeScale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cmdChangeScale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.cmdChangeScale.Location = new System.Drawing.Point(84, 220);
		this.cmdChangeScale.Name = "cmdChangeScale";
		this.cmdChangeScale.Size = new System.Drawing.Size(106, 30);
		this.cmdChangeScale.TabIndex = 31;
		this.cmdChangeScale.Text = "Change &Scale";
		//
		//lblSlitWidthnm
		//
		this.lblSlitWidthnm.Enabled = false;
		this.lblSlitWidthnm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSlitWidthnm.Location = new System.Drawing.Point(142, 108);
		this.lblSlitWidthnm.Name = "lblSlitWidthnm";
		this.lblSlitWidthnm.Size = new System.Drawing.Size(24, 18);
		this.lblSlitWidthnm.TabIndex = 28;
		this.lblSlitWidthnm.Text = "nm";
		this.lblSlitWidthnm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblPMTVolts
		//
		this.lblPMTVolts.Enabled = false;
		this.lblPMTVolts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPMTVolts.Location = new System.Drawing.Point(142, 40);
		this.lblPMTVolts.Name = "lblPMTVolts";
		this.lblPMTVolts.Size = new System.Drawing.Size(32, 18);
		this.lblPMTVolts.TabIndex = 27;
		this.lblPMTVolts.Text = "volts";
		this.lblPMTVolts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblD2CurmA
		//
		this.lblD2CurmA.Enabled = false;
		this.lblD2CurmA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblD2CurmA.Location = new System.Drawing.Point(142, 74);
		this.lblD2CurmA.Name = "lblD2CurmA";
		this.lblD2CurmA.Size = new System.Drawing.Size(22, 18);
		this.lblD2CurmA.TabIndex = 26;
		this.lblD2CurmA.Text = "mA";
		this.lblD2CurmA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//cmbModes
		//
		this.cmbModes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbModes.Enabled = false;
		this.cmbModes.Items.AddRange(new object[] {
			"D2E",
			"HCLE",
			"AA",
			"SELFTEST",
			"MABS",
			"AABGC",
			"EMISSION"
		});
		this.cmbModes.Location = new System.Drawing.Point(84, 182);
		this.cmbModes.Name = "cmbModes";
		this.cmbModes.Size = new System.Drawing.Size(82, 21);
		this.cmbModes.TabIndex = 4;
		this.cmbModes.Visible = false;
		//
		//lblModes
		//
		this.lblModes.Location = new System.Drawing.Point(32, 182);
		this.lblModes.Name = "lblModes";
		this.lblModes.Size = new System.Drawing.Size(48, 20);
		this.lblModes.TabIndex = 8;
		this.lblModes.Text = "Modes";
		this.lblModes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblSpeed
		//
		this.lblSpeed.Location = new System.Drawing.Point(24, 146);
		this.lblSpeed.Name = "lblSpeed";
		this.lblSpeed.Size = new System.Drawing.Size(50, 24);
		this.lblSpeed.TabIndex = 7;
		this.lblSpeed.Text = "Speed";
		this.lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		//
		//cmbSpeed
		//
		this.cmbSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbSpeed.Enabled = false;
		this.cmbSpeed.Items.AddRange(new object[] {
			"FAST",
			"MEDIUM",
			"SLOW"
		});
		this.cmbSpeed.Location = new System.Drawing.Point(84, 148);
		this.cmbSpeed.Name = "cmbSpeed";
		this.cmbSpeed.Size = new System.Drawing.Size(82, 21);
		this.cmbSpeed.TabIndex = 3;
		this.cmbSpeed.Visible = false;
		//
		//lblSlitWidth
		//
		this.lblSlitWidth.Location = new System.Drawing.Point(18, 106);
		this.lblSlitWidth.Name = "lblSlitWidth";
		this.lblSlitWidth.Size = new System.Drawing.Size(66, 28);
		this.lblSlitWidth.TabIndex = 5;
		this.lblSlitWidth.Text = "Slit Width";
		this.lblSlitWidth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//nudSlit
		//
		this.nudSlit.DecimalPlaces = 1;
		this.nudSlit.Enabled = false;
		this.nudSlit.Increment = new decimal(new int[] {
			1,
			0,
			0,
			65536
		});
		this.nudSlit.Location = new System.Drawing.Point(86, 110);
		this.nudSlit.Maximum = new decimal(new int[] {
			20,
			0,
			0,
			65536
		});
		this.nudSlit.Name = "nudSlit";
		this.nudSlit.Size = new System.Drawing.Size(56, 20);
		this.nudSlit.TabIndex = 2;
		this.nudSlit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.nudSlit.Visible = false;
		//
		//nudD2Cur
		//
		this.nudD2Cur.Enabled = false;
		this.nudD2Cur.Location = new System.Drawing.Point(86, 74);
		this.nudD2Cur.Maximum = new decimal(new int[] {
			300,
			0,
			0,
			0
		});
		this.nudD2Cur.Minimum = new decimal(new int[] {
			100,
			0,
			0,
			0
		});
		this.nudD2Cur.Name = "nudD2Cur";
		this.nudD2Cur.Size = new System.Drawing.Size(56, 20);
		this.nudD2Cur.TabIndex = 1;
		this.nudD2Cur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.nudD2Cur.Value = new decimal(new int[] {
			100,
			0,
			0,
			0
		});
		this.nudD2Cur.Visible = false;
		//
		//lblD2Cur
		//
		this.lblD2Cur.Location = new System.Drawing.Point(40, 70);
		this.lblD2Cur.Name = "lblD2Cur";
		this.lblD2Cur.Size = new System.Drawing.Size(44, 28);
		this.lblD2Cur.TabIndex = 2;
		this.lblD2Cur.Text = "D2 Cur";
		this.lblD2Cur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblPMT
		//
		this.lblPMT.Location = new System.Drawing.Point(46, 36);
		this.lblPMT.Name = "lblPMT";
		this.lblPMT.Size = new System.Drawing.Size(36, 28);
		this.lblPMT.TabIndex = 1;
		this.lblPMT.Text = "PMT";
		this.lblPMT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		//
		//nudPMT
		//
		this.nudPMT.Enabled = false;
		this.nudPMT.Increment = new decimal(new int[] {
			5,
			0,
			0,
			0
		});
		this.nudPMT.Location = new System.Drawing.Point(86, 40);
		this.nudPMT.Maximum = new decimal(new int[] {
			700,
			0,
			0,
			0
		});
		this.nudPMT.Name = "nudPMT";
		this.nudPMT.Size = new System.Drawing.Size(56, 20);
		this.nudPMT.TabIndex = 0;
		this.nudPMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.nudPMT.Visible = false;
		//
		//Button1
		//
		this.Button1.Location = new System.Drawing.Point(240, 160);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(72, 72);
		this.Button1.TabIndex = 3;
		this.Button1.Text = "Button1";
		//
		//Test111
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(352, 493);
		this.Controls.Add(this.Button1);
		this.Controls.Add(this.CustomPanelTop);
		this.Name = "Test111";
		this.Text = "Test111";
		this.CustomPanelTop.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.nudSlit).EndInit();
		((System.ComponentModel.ISupportInitialize)this.nudD2Cur).EndInit();
		((System.ComponentModel.ISupportInitialize)this.nudPMT).EndInit();
		this.ResumeLayout(false);

	}

	#End Region

	private void  // ERROR: Handles clauses are not supported in C#
Button1_Click(System.Object sender, System.EventArgs e)
	{
		// Create and display a modless about dialog box.
		TestForm about = new TestForm();
		about.Show();

		// Draw a blue square on the form.
		// NOTE: This is not a persistent object, it will no longer be
		// visible after the next call to OnPaint. To make it persistent, 
		// override the OnPaint method and draw the square there 
		Graphics g = about.CreateGraphics();
		g.FillRectangle(Brushes.Blue, 10, 10, 200, 200);
	}
}
