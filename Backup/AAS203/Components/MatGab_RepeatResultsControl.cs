using AAS203Library;
using AAS203Library.Method;

public class RepeatResultsControl : System.Windows.Forms.UserControl
{
	//**********************************************************************
	// File Header       
	// File Name 		:   RepeatResultsControl.vb
	// Author			:   Mangesh Shardul
	// Date/Time			:   10-Mar-2007 11:00 am
	// Description		:   Class to show the repeat results of Standard and Sample
	// Assumptions       :	
	// Dependencies      :   
	// Revisions         :   Deepak Bhati on 22.07.07
	//**********************************************************************

	#Region " Windows Form Designer generated code "

	public RepeatResultsControl()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call

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
	internal GradientPanel.CustomPanel CustomPanel1;
	internal System.Windows.Forms.Label lblStandardName;
	internal System.Windows.Forms.Label lblStandardNo;
	internal System.Windows.Forms.ListBox lstConcStats;
	internal System.Windows.Forms.ListBox lstAbsStats;
	internal System.Windows.Forms.TextBox TextBox15;
	internal System.Windows.Forms.TextBox TextBox14;
	internal System.Windows.Forms.TextBox TextBox13;
	internal System.Windows.Forms.TextBox TextBox10;
	internal System.Windows.Forms.TextBox TextBox9;
	internal System.Windows.Forms.TextBox TextBox8;
	internal System.Windows.Forms.TextBox TextBox7;
	internal System.Windows.Forms.TextBox TextBox6;
	internal System.Windows.Forms.TextBox TextBox5;
	internal System.Windows.Forms.TextBox TextBox4;
	internal System.Windows.Forms.TextBox TextBox3;
	internal System.Windows.Forms.TextBox TextBox2;
	internal System.Windows.Forms.TextBox TextBox1;
	internal System.Windows.Forms.Label lblConc;
	internal System.Windows.Forms.Label lblAbs;
	internal System.Windows.Forms.Label lblAbsStats;
	internal System.Windows.Forms.Label lblConcStats;
	internal NETXP.Controls.XPCheckBox RemoveOption;
	internal System.Windows.Forms.TextBox TextBoxConc15;
	internal System.Windows.Forms.TextBox TextBoxConc14;
	internal System.Windows.Forms.TextBox TextBoxConc13;
	internal System.Windows.Forms.TextBox TextBoxConc12;
	internal System.Windows.Forms.TextBox TextBoxConc11;
	internal System.Windows.Forms.TextBox TextBoxConc10;
	internal System.Windows.Forms.TextBox TextBoxConc9;
	internal System.Windows.Forms.TextBox TextBoxConc8;
	internal System.Windows.Forms.TextBox TextBoxConc7;
	internal System.Windows.Forms.TextBox TextBoxConc6;
	internal System.Windows.Forms.TextBox TextBoxConc5;
	internal System.Windows.Forms.TextBox TextBoxConc4;
	internal System.Windows.Forms.TextBox TextBoxConc3;
	internal System.Windows.Forms.TextBox TextBoxConc2;
	internal System.Windows.Forms.TextBox TextBoxConc1;
	internal System.Windows.Forms.TextBox TextBox11;

	internal System.Windows.Forms.TextBox TextBox12;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		this.CustomPanel1 = new GradientPanel.CustomPanel();
		this.RemoveOption = new NETXP.Controls.XPCheckBox();
		this.TextBoxConc15 = new System.Windows.Forms.TextBox();
		this.TextBoxConc14 = new System.Windows.Forms.TextBox();
		this.TextBoxConc13 = new System.Windows.Forms.TextBox();
		this.TextBoxConc12 = new System.Windows.Forms.TextBox();
		this.TextBoxConc11 = new System.Windows.Forms.TextBox();
		this.TextBoxConc10 = new System.Windows.Forms.TextBox();
		this.TextBoxConc9 = new System.Windows.Forms.TextBox();
		this.TextBoxConc8 = new System.Windows.Forms.TextBox();
		this.TextBoxConc7 = new System.Windows.Forms.TextBox();
		this.TextBoxConc6 = new System.Windows.Forms.TextBox();
		this.TextBoxConc5 = new System.Windows.Forms.TextBox();
		this.TextBoxConc4 = new System.Windows.Forms.TextBox();
		this.TextBoxConc3 = new System.Windows.Forms.TextBox();
		this.TextBoxConc2 = new System.Windows.Forms.TextBox();
		this.TextBoxConc1 = new System.Windows.Forms.TextBox();
		this.TextBox15 = new System.Windows.Forms.TextBox();
		this.TextBox14 = new System.Windows.Forms.TextBox();
		this.TextBox13 = new System.Windows.Forms.TextBox();
		this.TextBox10 = new System.Windows.Forms.TextBox();
		this.TextBox9 = new System.Windows.Forms.TextBox();
		this.TextBox8 = new System.Windows.Forms.TextBox();
		this.TextBox7 = new System.Windows.Forms.TextBox();
		this.TextBox6 = new System.Windows.Forms.TextBox();
		this.TextBox5 = new System.Windows.Forms.TextBox();
		this.TextBox4 = new System.Windows.Forms.TextBox();
		this.TextBox3 = new System.Windows.Forms.TextBox();
		this.TextBox2 = new System.Windows.Forms.TextBox();
		this.TextBox1 = new System.Windows.Forms.TextBox();
		this.lblConc = new System.Windows.Forms.Label();
		this.lblAbs = new System.Windows.Forms.Label();
		this.lblStandardName = new System.Windows.Forms.Label();
		this.lblStandardNo = new System.Windows.Forms.Label();
		this.lblAbsStats = new System.Windows.Forms.Label();
		this.lblConcStats = new System.Windows.Forms.Label();
		this.lstConcStats = new System.Windows.Forms.ListBox();
		this.lstAbsStats = new System.Windows.Forms.ListBox();
		this.TextBox11 = new System.Windows.Forms.TextBox();
		this.TextBox12 = new System.Windows.Forms.TextBox();
		this.CustomPanel1.SuspendLayout();
		this.SuspendLayout();
		//
		//CustomPanel1
		//
		this.CustomPanel1.BorderColor = System.Drawing.SystemColors.InfoText;
		this.CustomPanel1.Controls.Add(this.TextBox12);
		this.CustomPanel1.Controls.Add(this.TextBox11);
		this.CustomPanel1.Controls.Add(this.RemoveOption);
		this.CustomPanel1.Controls.Add(this.TextBoxConc15);
		this.CustomPanel1.Controls.Add(this.TextBoxConc14);
		this.CustomPanel1.Controls.Add(this.TextBoxConc13);
		this.CustomPanel1.Controls.Add(this.TextBoxConc12);
		this.CustomPanel1.Controls.Add(this.TextBoxConc11);
		this.CustomPanel1.Controls.Add(this.TextBoxConc10);
		this.CustomPanel1.Controls.Add(this.TextBoxConc9);
		this.CustomPanel1.Controls.Add(this.TextBoxConc8);
		this.CustomPanel1.Controls.Add(this.TextBoxConc7);
		this.CustomPanel1.Controls.Add(this.TextBoxConc6);
		this.CustomPanel1.Controls.Add(this.TextBoxConc5);
		this.CustomPanel1.Controls.Add(this.TextBoxConc4);
		this.CustomPanel1.Controls.Add(this.TextBoxConc3);
		this.CustomPanel1.Controls.Add(this.TextBoxConc2);
		this.CustomPanel1.Controls.Add(this.TextBoxConc1);
		this.CustomPanel1.Controls.Add(this.TextBox15);
		this.CustomPanel1.Controls.Add(this.TextBox14);
		this.CustomPanel1.Controls.Add(this.TextBox13);
		this.CustomPanel1.Controls.Add(this.TextBox10);
		this.CustomPanel1.Controls.Add(this.TextBox9);
		this.CustomPanel1.Controls.Add(this.TextBox8);
		this.CustomPanel1.Controls.Add(this.TextBox7);
		this.CustomPanel1.Controls.Add(this.TextBox6);
		this.CustomPanel1.Controls.Add(this.TextBox5);
		this.CustomPanel1.Controls.Add(this.TextBox4);
		this.CustomPanel1.Controls.Add(this.TextBox3);
		this.CustomPanel1.Controls.Add(this.TextBox2);
		this.CustomPanel1.Controls.Add(this.TextBox1);
		this.CustomPanel1.Controls.Add(this.lblConc);
		this.CustomPanel1.Controls.Add(this.lblAbs);
		this.CustomPanel1.Controls.Add(this.lblStandardName);
		this.CustomPanel1.Controls.Add(this.lblStandardNo);
		this.CustomPanel1.Controls.Add(this.lblAbsStats);
		this.CustomPanel1.Controls.Add(this.lblConcStats);
		this.CustomPanel1.Controls.Add(this.lstConcStats);
		this.CustomPanel1.Controls.Add(this.lstAbsStats);
		this.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanel1.Location = new System.Drawing.Point(0, 0);
		this.CustomPanel1.Name = "CustomPanel1";
		this.CustomPanel1.Size = new System.Drawing.Size(768, 160);
		this.CustomPanel1.TabIndex = 0;
		//
		//RemoveOption
		//
		this.RemoveOption.BackColor = System.Drawing.Color.Transparent;
		this.RemoveOption.Location = new System.Drawing.Point(656, 120);
		this.RemoveOption.Name = "RemoveOption";
		this.RemoveOption.Size = new System.Drawing.Size(104, 32);
		this.RemoveOption.TabIndex = 172;
		this.RemoveOption.Text = "&Remove";
		this.RemoveOption.Visible = false;
		//
		//TextBoxConc15
		//
		this.TextBoxConc15.Location = new System.Drawing.Point(700, 54);
		this.TextBoxConc15.Name = "TextBoxConc15";
		this.TextBoxConc15.ReadOnly = true;
		this.TextBoxConc15.Size = new System.Drawing.Size(45, 21);
		this.TextBoxConc15.TabIndex = 171;
		this.TextBoxConc15.Tag = "15";
		this.TextBoxConc15.Text = "";
		//
		//TextBoxConc14
		//
		this.TextBoxConc14.Location = new System.Drawing.Point(655, 54);
		this.TextBoxConc14.Name = "TextBoxConc14";
		this.TextBoxConc14.ReadOnly = true;
		this.TextBoxConc14.Size = new System.Drawing.Size(45, 21);
		this.TextBoxConc14.TabIndex = 170;
		this.TextBoxConc14.Tag = "14";
		this.TextBoxConc14.Text = "";
		//
		//TextBoxConc13
		//
		this.TextBoxConc13.Location = new System.Drawing.Point(610, 54);
		this.TextBoxConc13.Name = "TextBoxConc13";
		this.TextBoxConc13.ReadOnly = true;
		this.TextBoxConc13.Size = new System.Drawing.Size(45, 21);
		this.TextBoxConc13.TabIndex = 169;
		this.TextBoxConc13.Tag = "13";
		this.TextBoxConc13.Text = "";
		//
		//TextBoxConc12
		//
		this.TextBoxConc12.Location = new System.Drawing.Point(565, 54);
		this.TextBoxConc12.Name = "TextBoxConc12";
		this.TextBoxConc12.ReadOnly = true;
		this.TextBoxConc12.Size = new System.Drawing.Size(45, 21);
		this.TextBoxConc12.TabIndex = 168;
		this.TextBoxConc12.Tag = "12";
		this.TextBoxConc12.Text = "";
		//
		//TextBoxConc11
		//
		this.TextBoxConc11.Location = new System.Drawing.Point(520, 54);
		this.TextBoxConc11.Name = "TextBoxConc11";
		this.TextBoxConc11.ReadOnly = true;
		this.TextBoxConc11.Size = new System.Drawing.Size(45, 21);
		this.TextBoxConc11.TabIndex = 167;
		this.TextBoxConc11.Tag = "11";
		this.TextBoxConc11.Text = "";
		//
		//TextBoxConc10
		//
		this.TextBoxConc10.Location = new System.Drawing.Point(475, 54);
		this.TextBoxConc10.Name = "TextBoxConc10";
		this.TextBoxConc10.ReadOnly = true;
		this.TextBoxConc10.Size = new System.Drawing.Size(45, 21);
		this.TextBoxConc10.TabIndex = 166;
		this.TextBoxConc10.Tag = "10";
		this.TextBoxConc10.Text = "";
		//
		//TextBoxConc9
		//
		this.TextBoxConc9.Location = new System.Drawing.Point(430, 54);
		this.TextBoxConc9.Name = "TextBoxConc9";
		this.TextBoxConc9.ReadOnly = true;
		this.TextBoxConc9.Size = new System.Drawing.Size(45, 21);
		this.TextBoxConc9.TabIndex = 165;
		this.TextBoxConc9.Tag = "9";
		this.TextBoxConc9.Text = "";
		//
		//TextBoxConc8
		//
		this.TextBoxConc8.Location = new System.Drawing.Point(385, 54);
		this.TextBoxConc8.Name = "TextBoxConc8";
		this.TextBoxConc8.ReadOnly = true;
		this.TextBoxConc8.Size = new System.Drawing.Size(45, 21);
		this.TextBoxConc8.TabIndex = 164;
		this.TextBoxConc8.Tag = "8";
		this.TextBoxConc8.Text = "";
		//
		//TextBoxConc7
		//
		this.TextBoxConc7.Location = new System.Drawing.Point(340, 54);
		this.TextBoxConc7.Name = "TextBoxConc7";
		this.TextBoxConc7.ReadOnly = true;
		this.TextBoxConc7.Size = new System.Drawing.Size(45, 21);
		this.TextBoxConc7.TabIndex = 163;
		this.TextBoxConc7.Tag = "7";
		this.TextBoxConc7.Text = "";
		//
		//TextBoxConc6
		//
		this.TextBoxConc6.Location = new System.Drawing.Point(295, 54);
		this.TextBoxConc6.Name = "TextBoxConc6";
		this.TextBoxConc6.ReadOnly = true;
		this.TextBoxConc6.Size = new System.Drawing.Size(45, 21);
		this.TextBoxConc6.TabIndex = 162;
		this.TextBoxConc6.Tag = "6";
		this.TextBoxConc6.Text = "";
		//
		//TextBoxConc5
		//
		this.TextBoxConc5.Location = new System.Drawing.Point(250, 54);
		this.TextBoxConc5.Name = "TextBoxConc5";
		this.TextBoxConc5.ReadOnly = true;
		this.TextBoxConc5.Size = new System.Drawing.Size(45, 21);
		this.TextBoxConc5.TabIndex = 161;
		this.TextBoxConc5.Tag = "5";
		this.TextBoxConc5.Text = "";
		//
		//TextBoxConc4
		//
		this.TextBoxConc4.Location = new System.Drawing.Point(205, 54);
		this.TextBoxConc4.Name = "TextBoxConc4";
		this.TextBoxConc4.ReadOnly = true;
		this.TextBoxConc4.Size = new System.Drawing.Size(45, 21);
		this.TextBoxConc4.TabIndex = 160;
		this.TextBoxConc4.Tag = "4";
		this.TextBoxConc4.Text = "";
		//
		//TextBoxConc3
		//
		this.TextBoxConc3.Location = new System.Drawing.Point(160, 54);
		this.TextBoxConc3.Name = "TextBoxConc3";
		this.TextBoxConc3.ReadOnly = true;
		this.TextBoxConc3.Size = new System.Drawing.Size(45, 21);
		this.TextBoxConc3.TabIndex = 159;
		this.TextBoxConc3.Tag = "3";
		this.TextBoxConc3.Text = "";
		//
		//TextBoxConc2
		//
		this.TextBoxConc2.Location = new System.Drawing.Point(115, 54);
		this.TextBoxConc2.Name = "TextBoxConc2";
		this.TextBoxConc2.ReadOnly = true;
		this.TextBoxConc2.Size = new System.Drawing.Size(45, 21);
		this.TextBoxConc2.TabIndex = 158;
		this.TextBoxConc2.Tag = "2";
		this.TextBoxConc2.Text = "";
		//
		//TextBoxConc1
		//
		this.TextBoxConc1.Location = new System.Drawing.Point(70, 54);
		this.TextBoxConc1.Name = "TextBoxConc1";
		this.TextBoxConc1.ReadOnly = true;
		this.TextBoxConc1.Size = new System.Drawing.Size(45, 21);
		this.TextBoxConc1.TabIndex = 157;
		this.TextBoxConc1.Tag = "1";
		this.TextBoxConc1.Text = "";
		//
		//TextBox15
		//
		this.TextBox15.Location = new System.Drawing.Point(700, 30);
		this.TextBox15.Name = "TextBox15";
		this.TextBox15.ReadOnly = true;
		this.TextBox15.Size = new System.Drawing.Size(45, 21);
		this.TextBox15.TabIndex = 156;
		this.TextBox15.Tag = "15";
		this.TextBox15.Text = "";
		//
		//TextBox14
		//
		this.TextBox14.Location = new System.Drawing.Point(655, 30);
		this.TextBox14.Name = "TextBox14";
		this.TextBox14.ReadOnly = true;
		this.TextBox14.Size = new System.Drawing.Size(45, 21);
		this.TextBox14.TabIndex = 155;
		this.TextBox14.Tag = "14";
		this.TextBox14.Text = "";
		//
		//TextBox13
		//
		this.TextBox13.Location = new System.Drawing.Point(610, 30);
		this.TextBox13.Name = "TextBox13";
		this.TextBox13.ReadOnly = true;
		this.TextBox13.Size = new System.Drawing.Size(45, 21);
		this.TextBox13.TabIndex = 154;
		this.TextBox13.Tag = "13";
		this.TextBox13.Text = "";
		//
		//TextBox10
		//
		this.TextBox10.Location = new System.Drawing.Point(475, 30);
		this.TextBox10.Name = "TextBox10";
		this.TextBox10.ReadOnly = true;
		this.TextBox10.Size = new System.Drawing.Size(45, 21);
		this.TextBox10.TabIndex = 151;
		this.TextBox10.Tag = "10";
		this.TextBox10.Text = "";
		//
		//TextBox9
		//
		this.TextBox9.Location = new System.Drawing.Point(430, 30);
		this.TextBox9.Name = "TextBox9";
		this.TextBox9.ReadOnly = true;
		this.TextBox9.Size = new System.Drawing.Size(45, 21);
		this.TextBox9.TabIndex = 150;
		this.TextBox9.Tag = "9";
		this.TextBox9.Text = "";
		//
		//TextBox8
		//
		this.TextBox8.Location = new System.Drawing.Point(385, 30);
		this.TextBox8.Name = "TextBox8";
		this.TextBox8.ReadOnly = true;
		this.TextBox8.Size = new System.Drawing.Size(45, 21);
		this.TextBox8.TabIndex = 149;
		this.TextBox8.Tag = "8";
		this.TextBox8.Text = "";
		//
		//TextBox7
		//
		this.TextBox7.Location = new System.Drawing.Point(340, 30);
		this.TextBox7.Name = "TextBox7";
		this.TextBox7.ReadOnly = true;
		this.TextBox7.Size = new System.Drawing.Size(45, 21);
		this.TextBox7.TabIndex = 148;
		this.TextBox7.Tag = "7";
		this.TextBox7.Text = "";
		//
		//TextBox6
		//
		this.TextBox6.Location = new System.Drawing.Point(295, 30);
		this.TextBox6.Name = "TextBox6";
		this.TextBox6.ReadOnly = true;
		this.TextBox6.Size = new System.Drawing.Size(45, 21);
		this.TextBox6.TabIndex = 147;
		this.TextBox6.Tag = "6";
		this.TextBox6.Text = "";
		//
		//TextBox5
		//
		this.TextBox5.Location = new System.Drawing.Point(250, 30);
		this.TextBox5.Name = "TextBox5";
		this.TextBox5.ReadOnly = true;
		this.TextBox5.Size = new System.Drawing.Size(45, 21);
		this.TextBox5.TabIndex = 146;
		this.TextBox5.Tag = "5";
		this.TextBox5.Text = "";
		//
		//TextBox4
		//
		this.TextBox4.Location = new System.Drawing.Point(205, 30);
		this.TextBox4.Name = "TextBox4";
		this.TextBox4.ReadOnly = true;
		this.TextBox4.Size = new System.Drawing.Size(45, 21);
		this.TextBox4.TabIndex = 145;
		this.TextBox4.Tag = "4";
		this.TextBox4.Text = "";
		//
		//TextBox3
		//
		this.TextBox3.Location = new System.Drawing.Point(160, 30);
		this.TextBox3.Name = "TextBox3";
		this.TextBox3.ReadOnly = true;
		this.TextBox3.Size = new System.Drawing.Size(45, 21);
		this.TextBox3.TabIndex = 144;
		this.TextBox3.Tag = "3";
		this.TextBox3.Text = "";
		//
		//TextBox2
		//
		this.TextBox2.Location = new System.Drawing.Point(115, 30);
		this.TextBox2.Name = "TextBox2";
		this.TextBox2.ReadOnly = true;
		this.TextBox2.Size = new System.Drawing.Size(45, 21);
		this.TextBox2.TabIndex = 143;
		this.TextBox2.Tag = "2";
		this.TextBox2.Text = "";
		//
		//TextBox1
		//
		this.TextBox1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.TextBox1.Location = new System.Drawing.Point(70, 30);
		this.TextBox1.Name = "TextBox1";
		this.TextBox1.ReadOnly = true;
		this.TextBox1.Size = new System.Drawing.Size(45, 21);
		this.TextBox1.TabIndex = 142;
		this.TextBox1.Tag = "1";
		this.TextBox1.Text = "0.0000";
		//
		//lblConc
		//
		this.lblConc.Location = new System.Drawing.Point(4, 56);
		this.lblConc.Name = "lblConc";
		this.lblConc.Size = new System.Drawing.Size(60, 16);
		this.lblConc.TabIndex = 140;
		this.lblConc.Text = "Conc";
		//
		//lblAbs
		//
		this.lblAbs.Location = new System.Drawing.Point(4, 32);
		this.lblAbs.Name = "lblAbs";
		this.lblAbs.Size = new System.Drawing.Size(60, 16);
		this.lblAbs.TabIndex = 139;
		this.lblAbs.Text = "Abs";
		//
		//lblStandardName
		//
		this.lblStandardName.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblStandardName.Location = new System.Drawing.Point(72, 8);
		this.lblStandardName.Name = "lblStandardName";
		this.lblStandardName.Size = new System.Drawing.Size(140, 16);
		this.lblStandardName.TabIndex = 138;
		this.lblStandardName.Text = "Standard Name";
		//
		//lblStandardNo
		//
		this.lblStandardNo.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblStandardNo.Location = new System.Drawing.Point(5, 5);
		this.lblStandardNo.Name = "lblStandardNo";
		this.lblStandardNo.Size = new System.Drawing.Size(50, 16);
		this.lblStandardNo.TabIndex = 137;
		this.lblStandardNo.Text = "Std No.";
		//
		//lblAbsStats
		//
		this.lblAbsStats.Location = new System.Drawing.Point(40, 80);
		this.lblAbsStats.Name = "lblAbsStats";
		this.lblAbsStats.Size = new System.Drawing.Size(208, 16);
		this.lblAbsStats.TabIndex = 136;
		this.lblAbsStats.Text = "Statistics on Abs";
		//
		//lblConcStats
		//
		this.lblConcStats.Location = new System.Drawing.Point(296, 80);
		this.lblConcStats.Name = "lblConcStats";
		this.lblConcStats.Size = new System.Drawing.Size(160, 16);
		this.lblConcStats.TabIndex = 135;
		this.lblConcStats.Text = "Statistics on Concentration";
		//
		//lstConcStats
		//
		this.lstConcStats.ItemHeight = 15;
		this.lstConcStats.Location = new System.Drawing.Point(298, 100);
		this.lstConcStats.Name = "lstConcStats";
		this.lstConcStats.Size = new System.Drawing.Size(254, 49);
		this.lstConcStats.TabIndex = 134;
		//
		//lstAbsStats
		//
		this.lstAbsStats.ItemHeight = 15;
		this.lstAbsStats.Location = new System.Drawing.Point(40, 100);
		this.lstAbsStats.Name = "lstAbsStats";
		this.lstAbsStats.Size = new System.Drawing.Size(248, 49);
		this.lstAbsStats.TabIndex = 133;
		//
		//TextBox11
		//
		this.TextBox11.Location = new System.Drawing.Point(520, 30);
		this.TextBox11.Name = "TextBox11";
		this.TextBox11.ReadOnly = true;
		this.TextBox11.Size = new System.Drawing.Size(45, 21);
		this.TextBox11.TabIndex = 173;
		this.TextBox11.Tag = "10";
		this.TextBox11.Text = "";
		//
		//TextBox12
		//
		this.TextBox12.Location = new System.Drawing.Point(565, 30);
		this.TextBox12.Name = "TextBox12";
		this.TextBox12.ReadOnly = true;
		this.TextBox12.Size = new System.Drawing.Size(45, 21);
		this.TextBox12.TabIndex = 174;
		this.TextBox12.Tag = "10";
		this.TextBox12.Text = "";
		//
		//RepeatResultsControl
		//
		this.AutoScroll = true;
		this.Controls.Add(this.CustomPanel1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Name = "RepeatResultsControl";
		this.Size = new System.Drawing.Size(768, 160);
		this.CustomPanel1.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region "Private Variables"
	private Method.clsAnalysisSampleParameters mAnalysisSampleParameters;
	private Method.clsAnalysisStdParameters mAnalysisStdParameters;
	private double mRemoveAbs;
	private int mintRepeatNumber;
		#End Region
	private bool mblnIsStandard;

	#Region "Public Events"
	public event  RepeatItemClick;
	#End Region

	#Region " Public Properties "

	public int RepeatNumber {
		get { return mintRepeatNumber; }
		set { mintRepeatNumber = Value; }
	}

	public int StandardNumber {
		get { return (int)lblStandardNo.Text; }
		set { lblStandardNo.Text = Value; }
	}

	public bool IsStandard {
		get { return mblnIsStandard; }
		set { mblnIsStandard = Value; }
	}

	public string StandardName {
		get { return lblStandardName.Text; }
		set { lblStandardName.Text = Value; }
	}

	public double RemoveAbs {
		get { return mRemoveAbs; }
		set { mRemoveAbs = Value; }
	}

	public Method.clsAnalysisSampleParameters AnalysisParameter {
		get { return mAnalysisSampleParameters; }
		set { mAnalysisSampleParameters = Value; }
	}

	public Method.clsAnalysisStdParameters StandardAnalysisParameter {
		get { return mAnalysisStdParameters; }
		set { mAnalysisStdParameters = Value; }
	}

	#End Region

	#Region " Public functions "

	public void FindNSetValueInControl(string strValue, int intControlNumber)
	{
		Control cntrl;
		try {
			foreach ( cntrl in CustomPanel1.Controls) {
				if (cntrl is TextBox) {
					if (cntrl.Name == "TextBox" + intControlNumber) {
						cntrl.Text = strValue;
						RemoveAbs = strValue;
						cntrl.Visible = true;
						break; // TODO: might not be correct. Was : Exit For
					}
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

	public void FindNSet2ndValueInControl(string strValue, int intControlNumber, int intDecimal)
	{
		Control cntrl;
		try {
			foreach ( cntrl in CustomPanel1.Controls) {
				if (cntrl is TextBox) {
					if (cntrl.Name == "TextBoxConc" + intControlNumber) {
						cntrl.Text = FormatNumber(strValue, intDecimal);
						//---08.03.09
						//RemoveAbs = strValue
						cntrl.Visible = true;
						break; // TODO: might not be correct. Was : Exit For
					}
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

	public void FindNSetControlVisible(int intControlNumber, bool blnIsVisible)
	{
		Control cntrl;
		try {
			foreach ( cntrl in CustomPanel1.Controls) {
				if (cntrl is TextBox) {
					if (cntrl.Name == "TextBox" + intControlNumber) {
						cntrl.Visible = blnIsVisible;
						cntrl.Refresh();
						break; // TODO: might not be correct. Was : Exit For
					}
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

	public void FindNSet2ndControlVisible(int intControlNumber, bool blnIsVisible)
	{
		Control cntrl;
		try {
			foreach ( cntrl in CustomPanel1.Controls) {
				if (cntrl is TextBox) {
					if (cntrl.Name == "TextBoxConc" + intControlNumber) {
						cntrl.Visible = blnIsVisible;
						cntrl.Refresh();
						break; // TODO: might not be correct. Was : Exit For
					}
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

	public void ShowStatistic(clsBasicStat basic, bool blnIsStandard, bool blnIsConcStats)
	{
		//=====================================================================
		// Procedure Name        : ShowStatistic
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 10-Mar-2007 02:50 pm
		// Revisions             : 1
		//=====================================================================

		//****************************************************************
		//---- ORIGINAL CODE
		//****************************************************************
		//void	 ShowStatistic(HWND hpar, BASIC_STAT *basic, int i, BOOL flag)
		//{
		//   HWND    hwnd;
		//   int		j;
		//   If (flag) Then
		//   {
		//	    hwnd = GetDlgItem(hpar, IDC_SAMPNAME+i*NOOFITEMS+35);
		//	    j=0;
		//   }
		//   Else
		//   {
		//	    hwnd = GetDlgItem(hpar, IDC_SAMPNAME+i*NOOFITEMS+37);
		//	    j=1;
		//   }
		//   ShowWindow1(hwnd, TRUE);
		//   SendMessage(hwnd, LB_RESETCONTENT, 0, 0L);
		//   show_basic_val( hwnd, "Valid Observations ",(double) basic->TotData[j], FALSE);
		//   show_basic_val( hwnd, "Process Mean ", basic->Zavg[j], TRUE);
		//   show_basic_val( hwnd, "Standard Deviation ", basic->Zsigma[j], TRUE);
		//   show_basic_val( hwnd, "Variance ", basic->Var[j], TRUE);
		//   show_basic_val( hwnd, "Coeff. of Variance", basic->CV[j], TRUE);
		//   show_basic_val( hwnd, "Minimum value", basic->Min[j], TRUE);
		//   show_basic_val( hwnd, "Maximum value ", basic->Max[j], TRUE);
		//   show_basic_val( hwnd, "Range ", basic->Max[j]-basic->Min[j], TRUE);
		//}
		//****************************************************************
		int j;

		try {
			//commented and added the following code by deepak on 22.07.07

			//'If (blnIsStandard) Then
			//'    '---For Standards
			//'    j = 0
			//'Else
			//'    '---For Samples
			//'    j = 1
			//'End If


			if (blnIsConcStats) {
				j = 1;
			} else {
				j = 0;
			}

			if (blnIsConcStats) {
				show_basic_val(lstConcStats, basic, j);
			} else {
				show_basic_val(lstAbsStats, basic, j);
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

	public void SetVisibleRemoveOption(bool VisibleValueIn = true)
	{
		RemoveOption.Visible = VisibleValueIn;
	}

	private void show_basic_val(ref ListBox lstStats, Method.clsBasicStat basic, int j)
	{
		//---changed by deepak on 22.07.07
		lstStats.Items.Clear();
		lstStats.Items.Add("Valid Observations : " + FormatNumber(basic.TotData(j), 0));
		lstStats.Items.Add("Process Mean       : " + FormatNumber(basic.ZAvg(j), 5));
		lstStats.Items.Add("Standard Deviation : " + FormatNumber(basic.ZSigma(j), 5));
		lstStats.Items.Add("Variance           : " + FormatNumber(basic.Var(j), 5));
		lstStats.Items.Add("Coeff. of Variance : " + FormatNumber(basic.CV(j), 5));
		lstStats.Items.Add("Minimum value      : " + FormatNumber(basic.Min(j), 5));
		lstStats.Items.Add("Maximum value      : " + FormatNumber(basic.Max(j), 5));
		lstStats.Items.Add("Range              : " + FormatNumber(basic.Max(j) - basic.Min(j), 5));
	}

	#End Region

	#Region "Commented Code"
	//Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus
	//    mRemoveAbs = TextBox1.Text
	//    'RaiseEvent RepeatResultClick(Me.StandardNumber)
	//End Sub

	//Private Sub TextBox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.GotFocus
	//    mRemoveAbs = TextBox2.Text
	//    'RaiseEvent RepeatResultClick(Me.StandardNumber)
	//End Sub

	//Private Sub TextBox3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.GotFocus
	//    mRemoveAbs = TextBox3.Text
	//    'RaiseEvent RepeatResultClick(Me.StandardNumber)
	//End Sub

	//Private Sub RepeatResultsControl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click

	//RaiseEvent RepeatResultClick(Me.StandardNumber)
	//End Sub

	//Private Sub CustomPanel1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CustomPanel1.Click
	//    'RaiseEvent RepeatResultClick(Me.StandardNumber)
	//End Sub
	#End Region

	#Region "Form Events"
	private void  // ERROR: Handles clauses are not supported in C#
RepeatResultsControl_Load(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : RepeatResultsControl_Load
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the control
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 22.07.07
		// Revisions             : 
		//=====================================================================
		int intCtrlCount;
		try {
			for (intCtrlCount = 0; intCtrlCount <= this.CustomPanel1.Controls.Count - 1; intCtrlCount++) {
				if (this.CustomPanel1.Controls(intCtrlCount) is System.Windows.Forms.TextBox) {
					if (this.CustomPanel1.Controls(intCtrlCount).Tag != null) {
						this.CustomPanel1.Controls(intCtrlCount).Click += SubGetRepeatNumber;
					}
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
	#End Region

	#Region "Private Functions"
	private void SubGetRepeatNumber(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : SubGetRepeatNumber
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To get the repeat number
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 22.07.07
		// Revisions             : 
		//=====================================================================
		try {
			//following routine of code is called two times purposely to solve a bug
			RepeatNumber = (int)((System.Windows.Forms.TextBox)sender).Tag;
			if (RepeatItemClick != null) {
				RepeatItemClick(StandardNumber, RepeatNumber, IsStandard, this.CustomPanel1.Controls);
			}
			RepeatNumber = (int)((System.Windows.Forms.TextBox)sender).Tag;
			if (RepeatItemClick != null) {
				RepeatItemClick(StandardNumber, RepeatNumber, IsStandard, this.CustomPanel1.Controls);
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
