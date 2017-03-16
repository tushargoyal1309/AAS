using AAS203.Common;
using AAS203Library.Method;
//'this is a supporting files like header files
//'class behind the form
public class frmMethodAnalysisParameters : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmMethodAnalysisParameters()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call

	}


	public frmMethodAnalysisParameters(int intMethodMode, int intNoOfSamples = 0)
	{
		//constructor modified by ;dinesh on 2.2.2010
		//Purpose to set the noOf samples.

		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
		OpenMethodMode = intMethodMode;

		mintNoOfSamples = intNoOfSamples;
		//added by ; dinesh wagh on 2.2.2010
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
	internal GradientPanel.CustomPanel CustomPanelMain;
	internal GradientPanel.CustomPanel CustomPanelRightBottom;
	internal GradientPanel.CustomPanel CustomPanelLeft;
	internal GradientPanel.CustomPanel CustomPanelBottom;
	internal NETXP.Controls.XPButton btnHelp;
	internal NETXP.Controls.XPButton btnOk;
	internal NETXP.Controls.XPButton btnCancel;
	internal GradientPanel.CustomPanel CustomPanelTop;
	internal CodeIntellects.Office2003Controls.Office2003Header Office2003Header1;
	internal System.Windows.Forms.Label lblAnalystName;
	internal System.Windows.Forms.Label lblLabName;
	internal System.Windows.Forms.GroupBox gbMeasurementMode;
	internal System.Windows.Forms.Label lblIntegrationTime;
	internal System.Windows.Forms.Label lblNumofSamples;
	internal System.Windows.Forms.Label lblNumofSampRepeat;
	internal System.Windows.Forms.Label Label4;
	internal System.Windows.Forms.GroupBox gbUnit;
	internal System.Windows.Forms.Label Label2;
	internal System.Windows.Forms.Label Label1;
	internal System.Windows.Forms.Label Label3;
	internal System.Windows.Forms.Label Label5;
	internal System.Windows.Forms.Label Label6;
	internal System.Windows.Forms.Label lblMethodInformation;
	internal System.Windows.Forms.CheckBox chkBlankAfter;
	internal System.Windows.Forms.NumericUpDown nudNumDecimalPlaces;
	internal System.Windows.Forms.NumericUpDown nudNumStdRepeat;
	internal System.Windows.Forms.NumericUpDown nudNumSampRepeat;
	internal System.Windows.Forms.NumericUpDown nudNumofSamples;
	internal System.Windows.Forms.NumericUpDown nudIntegrationTime;
	internal System.Windows.Forms.ComboBox cmbUnits;
	internal System.Windows.Forms.ComboBox cmbMeasurementMode;
	internal NumberValidator.NumberValidator txtAnalystName;
	internal NumberValidator.NumberValidator txtLabName;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMethodAnalysisParameters));
		this.CustomPanelMain = new GradientPanel.CustomPanel();
		this.CustomPanelRightBottom = new GradientPanel.CustomPanel();
		this.gbUnit = new System.Windows.Forms.GroupBox();
		this.cmbUnits = new System.Windows.Forms.ComboBox();
		this.gbMeasurementMode = new System.Windows.Forms.GroupBox();
		this.cmbMeasurementMode = new System.Windows.Forms.ComboBox();
		this.chkBlankAfter = new System.Windows.Forms.CheckBox();
		this.CustomPanelLeft = new GradientPanel.CustomPanel();
		this.Label6 = new System.Windows.Forms.Label();
		this.nudNumDecimalPlaces = new System.Windows.Forms.NumericUpDown();
		this.lblMethodInformation = new System.Windows.Forms.Label();
		this.Label5 = new System.Windows.Forms.Label();
		this.Label3 = new System.Windows.Forms.Label();
		this.Label1 = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.nudNumStdRepeat = new System.Windows.Forms.NumericUpDown();
		this.nudNumSampRepeat = new System.Windows.Forms.NumericUpDown();
		this.nudNumofSamples = new System.Windows.Forms.NumericUpDown();
		this.nudIntegrationTime = new System.Windows.Forms.NumericUpDown();
		this.Label4 = new System.Windows.Forms.Label();
		this.lblNumofSampRepeat = new System.Windows.Forms.Label();
		this.lblNumofSamples = new System.Windows.Forms.Label();
		this.lblIntegrationTime = new System.Windows.Forms.Label();
		this.CustomPanelBottom = new GradientPanel.CustomPanel();
		this.btnOk = new NETXP.Controls.XPButton();
		this.btnCancel = new NETXP.Controls.XPButton();
		this.btnHelp = new NETXP.Controls.XPButton();
		this.CustomPanelTop = new GradientPanel.CustomPanel();
		this.txtLabName = new NumberValidator.NumberValidator();
		this.txtAnalystName = new NumberValidator.NumberValidator();
		this.lblLabName = new System.Windows.Forms.Label();
		this.lblAnalystName = new System.Windows.Forms.Label();
		this.Office2003Header1 = new CodeIntellects.Office2003Controls.Office2003Header();
		this.CustomPanelMain.SuspendLayout();
		this.CustomPanelRightBottom.SuspendLayout();
		this.gbUnit.SuspendLayout();
		this.gbMeasurementMode.SuspendLayout();
		this.CustomPanelLeft.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.nudNumDecimalPlaces).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.nudNumStdRepeat).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.nudNumSampRepeat).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.nudNumofSamples).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.nudIntegrationTime).BeginInit();
		this.CustomPanelBottom.SuspendLayout();
		this.CustomPanelTop.SuspendLayout();
		this.SuspendLayout();
		//
		//CustomPanelMain
		//
		this.CustomPanelMain.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanelMain.BackColor2 = System.Drawing.Color.AliceBlue;
		this.CustomPanelMain.Controls.Add(this.CustomPanelRightBottom);
		this.CustomPanelMain.Controls.Add(this.CustomPanelLeft);
		this.CustomPanelMain.Controls.Add(this.CustomPanelBottom);
		this.CustomPanelMain.Controls.Add(this.CustomPanelTop);
		this.CustomPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanelMain.Location = new System.Drawing.Point(0, 22);
		this.CustomPanelMain.Name = "CustomPanelMain";
		this.CustomPanelMain.Size = new System.Drawing.Size(552, 367);
		this.CustomPanelMain.TabIndex = 12;
		//
		//CustomPanelRightBottom
		//
		this.CustomPanelRightBottom.BackColor = System.Drawing.Color.Transparent;
		this.CustomPanelRightBottom.BackColor2 = System.Drawing.Color.Transparent;
		this.CustomPanelRightBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.CustomPanelRightBottom.Controls.Add(this.gbUnit);
		this.CustomPanelRightBottom.Controls.Add(this.gbMeasurementMode);
		this.CustomPanelRightBottom.Controls.Add(this.chkBlankAfter);
		this.CustomPanelRightBottom.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanelRightBottom.Location = new System.Drawing.Point(280, 72);
		this.CustomPanelRightBottom.Name = "CustomPanelRightBottom";
		this.CustomPanelRightBottom.Size = new System.Drawing.Size(272, 223);
		this.CustomPanelRightBottom.TabIndex = 2;
		//
		//gbUnit
		//
		this.gbUnit.Controls.Add(this.cmbUnits);
		this.gbUnit.Location = new System.Drawing.Point(8, 16);
		this.gbUnit.Name = "gbUnit";
		this.gbUnit.Size = new System.Drawing.Size(256, 56);
		this.gbUnit.TabIndex = 0;
		this.gbUnit.TabStop = false;
		this.gbUnit.Text = "Unit for Results";
		//
		//cmbUnits
		//
		this.cmbUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbUnits.Location = new System.Drawing.Point(40, 24);
		this.cmbUnits.Name = "cmbUnits";
		this.cmbUnits.Size = new System.Drawing.Size(168, 23);
		this.cmbUnits.TabIndex = 0;
		//
		//gbMeasurementMode
		//
		this.gbMeasurementMode.Controls.Add(this.cmbMeasurementMode);
		this.gbMeasurementMode.Location = new System.Drawing.Point(8, 82);
		this.gbMeasurementMode.Name = "gbMeasurementMode";
		this.gbMeasurementMode.Size = new System.Drawing.Size(256, 62);
		this.gbMeasurementMode.TabIndex = 1;
		this.gbMeasurementMode.TabStop = false;
		this.gbMeasurementMode.Text = "Measurement Mode";
		//
		//cmbMeasurementMode
		//
		this.cmbMeasurementMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbMeasurementMode.Location = new System.Drawing.Point(40, 24);
		this.cmbMeasurementMode.Name = "cmbMeasurementMode";
		this.cmbMeasurementMode.Size = new System.Drawing.Size(168, 23);
		this.cmbMeasurementMode.TabIndex = 0;
		//
		//chkBlankAfter
		//
		this.chkBlankAfter.Location = new System.Drawing.Point(24, 158);
		this.chkBlankAfter.Name = "chkBlankAfter";
		this.chkBlankAfter.Size = new System.Drawing.Size(192, 24);
		this.chkBlankAfter.TabIndex = 2;
		this.chkBlankAfter.Text = "Blank After Every Sample/Std";
		//
		//CustomPanelLeft
		//
		this.CustomPanelLeft.BackColor = System.Drawing.Color.Transparent;
		this.CustomPanelLeft.BackColor2 = System.Drawing.Color.Transparent;
		this.CustomPanelLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.CustomPanelLeft.Controls.Add(this.Label6);
		this.CustomPanelLeft.Controls.Add(this.nudNumDecimalPlaces);
		this.CustomPanelLeft.Controls.Add(this.lblMethodInformation);
		this.CustomPanelLeft.Controls.Add(this.Label5);
		this.CustomPanelLeft.Controls.Add(this.Label3);
		this.CustomPanelLeft.Controls.Add(this.Label1);
		this.CustomPanelLeft.Controls.Add(this.Label2);
		this.CustomPanelLeft.Controls.Add(this.nudNumStdRepeat);
		this.CustomPanelLeft.Controls.Add(this.nudNumSampRepeat);
		this.CustomPanelLeft.Controls.Add(this.nudNumofSamples);
		this.CustomPanelLeft.Controls.Add(this.nudIntegrationTime);
		this.CustomPanelLeft.Controls.Add(this.Label4);
		this.CustomPanelLeft.Controls.Add(this.lblNumofSampRepeat);
		this.CustomPanelLeft.Controls.Add(this.lblNumofSamples);
		this.CustomPanelLeft.Controls.Add(this.lblIntegrationTime);
		this.CustomPanelLeft.Dock = System.Windows.Forms.DockStyle.Left;
		this.CustomPanelLeft.Location = new System.Drawing.Point(0, 72);
		this.CustomPanelLeft.Name = "CustomPanelLeft";
		this.CustomPanelLeft.Size = new System.Drawing.Size(280, 223);
		this.CustomPanelLeft.TabIndex = 1;
		//
		//Label6
		//
		this.Label6.Enabled = false;
		this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label6.Location = new System.Drawing.Point(221, 161);
		this.Label6.Name = "Label6";
		this.Label6.Size = new System.Drawing.Size(56, 18);
		this.Label6.TabIndex = 32;
		this.Label6.Text = "0..8 only";
		this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//nudNumDecimalPlaces
		//
		this.nudNumDecimalPlaces.Location = new System.Drawing.Point(164, 160);
		this.nudNumDecimalPlaces.Maximum = new decimal(new int[] {
			8,
			0,
			0,
			0
		});
		this.nudNumDecimalPlaces.Name = "nudNumDecimalPlaces";
		this.nudNumDecimalPlaces.Size = new System.Drawing.Size(52, 21);
		this.nudNumDecimalPlaces.TabIndex = 4;
		//
		//lblMethodInformation
		//
		this.lblMethodInformation.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblMethodInformation.Location = new System.Drawing.Point(9, 161);
		this.lblMethodInformation.Name = "lblMethodInformation";
		this.lblMethodInformation.Size = new System.Drawing.Size(156, 16);
		this.lblMethodInformation.TabIndex = 30;
		this.lblMethodInformation.Text = "No. of decimal places";
		//
		//Label5
		//
		this.Label5.Enabled = false;
		this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label5.Location = new System.Drawing.Point(219, 128);
		this.Label5.Name = "Label5";
		this.Label5.Size = new System.Drawing.Size(56, 18);
		this.Label5.TabIndex = 29;
		this.Label5.Text = "1..15 only";
		this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//Label3
		//
		this.Label3.Enabled = false;
		this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label3.Location = new System.Drawing.Point(219, 93);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(56, 18);
		this.Label3.TabIndex = 28;
		this.Label3.Text = "1..15 only";
		this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//Label1
		//
		this.Label1.Enabled = false;
		this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label1.Location = new System.Drawing.Point(219, 56);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(56, 18);
		this.Label1.TabIndex = 27;
		this.Label1.Text = "1..200 ";
		this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//Label2
		//
		this.Label2.Enabled = false;
		this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label2.Location = new System.Drawing.Point(217, 16);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(56, 18);
		this.Label2.TabIndex = 26;
		this.Label2.Text = "1..99 sec";
		this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//nudNumStdRepeat
		//
		this.nudNumStdRepeat.Location = new System.Drawing.Point(165, 128);
		this.nudNumStdRepeat.Maximum = new decimal(new int[] {
			15,
			0,
			0,
			0
		});
		this.nudNumStdRepeat.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0
		});
		this.nudNumStdRepeat.Name = "nudNumStdRepeat";
		this.nudNumStdRepeat.Size = new System.Drawing.Size(51, 21);
		this.nudNumStdRepeat.TabIndex = 3;
		this.nudNumStdRepeat.Value = new decimal(new int[] {
			1,
			0,
			0,
			0
		});
		//
		//nudNumSampRepeat
		//
		this.nudNumSampRepeat.Location = new System.Drawing.Point(165, 91);
		this.nudNumSampRepeat.Maximum = new decimal(new int[] {
			15,
			0,
			0,
			0
		});
		this.nudNumSampRepeat.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0
		});
		this.nudNumSampRepeat.Name = "nudNumSampRepeat";
		this.nudNumSampRepeat.Size = new System.Drawing.Size(51, 21);
		this.nudNumSampRepeat.TabIndex = 2;
		this.nudNumSampRepeat.Value = new decimal(new int[] {
			1,
			0,
			0,
			0
		});
		//
		//nudNumofSamples
		//
		this.nudNumofSamples.Location = new System.Drawing.Point(165, 56);
		this.nudNumofSamples.Maximum = new decimal(new int[] {
			200,
			0,
			0,
			0
		});
		this.nudNumofSamples.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0
		});
		this.nudNumofSamples.Name = "nudNumofSamples";
		this.nudNumofSamples.Size = new System.Drawing.Size(51, 21);
		this.nudNumofSamples.TabIndex = 1;
		this.nudNumofSamples.Value = new decimal(new int[] {
			1,
			0,
			0,
			0
		});
		//
		//nudIntegrationTime
		//
		this.nudIntegrationTime.Location = new System.Drawing.Point(165, 16);
		this.nudIntegrationTime.Maximum = new decimal(new int[] {
			99,
			0,
			0,
			0
		});
		this.nudIntegrationTime.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0
		});
		this.nudIntegrationTime.Name = "nudIntegrationTime";
		this.nudIntegrationTime.Size = new System.Drawing.Size(51, 21);
		this.nudIntegrationTime.TabIndex = 0;
		this.nudIntegrationTime.Value = new decimal(new int[] {
			1,
			0,
			0,
			0
		});
		//
		//Label4
		//
		this.Label4.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label4.Location = new System.Drawing.Point(8, 127);
		this.Label4.Name = "Label4";
		this.Label4.Size = new System.Drawing.Size(152, 16);
		this.Label4.TabIndex = 9;
		this.Label4.Text = "No. of STD Repeats";
		//
		//lblNumofSampRepeat
		//
		this.lblNumofSampRepeat.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblNumofSampRepeat.Location = new System.Drawing.Point(8, 90);
		this.lblNumofSampRepeat.Name = "lblNumofSampRepeat";
		this.lblNumofSampRepeat.Size = new System.Drawing.Size(152, 16);
		this.lblNumofSampRepeat.TabIndex = 8;
		this.lblNumofSampRepeat.Text = "No. of Samp Repeats";
		//
		//lblNumofSamples
		//
		this.lblNumofSamples.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblNumofSamples.Location = new System.Drawing.Point(8, 53);
		this.lblNumofSamples.Name = "lblNumofSamples";
		this.lblNumofSamples.Size = new System.Drawing.Size(152, 16);
		this.lblNumofSamples.TabIndex = 7;
		this.lblNumofSamples.Text = "No. of Samples";
		//
		//lblIntegrationTime
		//
		this.lblIntegrationTime.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblIntegrationTime.Location = new System.Drawing.Point(8, 16);
		this.lblIntegrationTime.Name = "lblIntegrationTime";
		this.lblIntegrationTime.Size = new System.Drawing.Size(152, 16);
		this.lblIntegrationTime.TabIndex = 6;
		this.lblIntegrationTime.Text = "Integration Time";
		//
		//CustomPanelBottom
		//
		this.CustomPanelBottom.BackColor = System.Drawing.Color.Transparent;
		this.CustomPanelBottom.BackColor2 = System.Drawing.Color.Transparent;
		this.CustomPanelBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.CustomPanelBottom.Controls.Add(this.btnOk);
		this.CustomPanelBottom.Controls.Add(this.btnCancel);
		this.CustomPanelBottom.Controls.Add(this.btnHelp);
		this.CustomPanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.CustomPanelBottom.Location = new System.Drawing.Point(0, 295);
		this.CustomPanelBottom.Name = "CustomPanelBottom";
		this.CustomPanelBottom.Size = new System.Drawing.Size(552, 72);
		this.CustomPanelBottom.TabIndex = 3;
		//
		//btnOk
		//
		this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOk.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnOk.Image = (System.Drawing.Image)resources.GetObject("btnOk.Image");
		this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOk.Location = new System.Drawing.Point(360, 24);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(86, 34);
		this.btnOk.TabIndex = 0;
		this.btnOk.Text = "&OK";
		//
		//btnCancel
		//
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCancel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnCancel.Image = (System.Drawing.Image)resources.GetObject("btnCancel.Image");
		this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCancel.Location = new System.Drawing.Point(456, 24);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(86, 34);
		this.btnCancel.TabIndex = 1;
		this.btnCancel.Text = "&Cancel";
		//
		//btnHelp
		//
		this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnHelp.Image = (System.Drawing.Image)resources.GetObject("btnHelp.Image");
		this.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnHelp.Location = new System.Drawing.Point(456, 48);
		this.btnHelp.Name = "btnHelp";
		this.btnHelp.Size = new System.Drawing.Size(86, 34);
		this.btnHelp.TabIndex = 13;
		this.btnHelp.Text = "Help";
		this.btnHelp.Visible = false;
		//
		//CustomPanelTop
		//
		this.CustomPanelTop.BackColor = System.Drawing.Color.Transparent;
		this.CustomPanelTop.BackColor2 = System.Drawing.Color.Transparent;
		this.CustomPanelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.CustomPanelTop.Controls.Add(this.txtLabName);
		this.CustomPanelTop.Controls.Add(this.txtAnalystName);
		this.CustomPanelTop.Controls.Add(this.lblLabName);
		this.CustomPanelTop.Controls.Add(this.lblAnalystName);
		this.CustomPanelTop.Dock = System.Windows.Forms.DockStyle.Top;
		this.CustomPanelTop.Location = new System.Drawing.Point(0, 0);
		this.CustomPanelTop.Name = "CustomPanelTop";
		this.CustomPanelTop.Size = new System.Drawing.Size(552, 72);
		this.CustomPanelTop.TabIndex = 0;
		//
		//txtLabName
		//
		this.txtLabName.DigitsAfterDecimalPoint = 0;
		this.txtLabName.ErrorColor = System.Drawing.Color.Empty;
		this.txtLabName.ErrorMessage = null;
		this.txtLabName.Location = new System.Drawing.Point(168, 40);
		this.txtLabName.MaximumRange = 0;
		this.txtLabName.MaxLength = 80;
		this.txtLabName.MinimumRange = 0;
		this.txtLabName.Name = "txtLabName";
		this.txtLabName.RangeValidation = false;
		this.txtLabName.Size = new System.Drawing.Size(328, 21);
		this.txtLabName.TabIndex = 1;
		this.txtLabName.Text = "";
		this.txtLabName.ValidationType = NumberValidator.NumberValidator.Validations.AlphaNumeric;
		//
		//txtAnalystName
		//
		this.txtAnalystName.DigitsAfterDecimalPoint = 0;
		this.txtAnalystName.ErrorColor = System.Drawing.Color.Empty;
		this.txtAnalystName.ErrorMessage = null;
		this.txtAnalystName.Location = new System.Drawing.Point(168, 8);
		this.txtAnalystName.MaximumRange = 0;
		this.txtAnalystName.MaxLength = 40;
		this.txtAnalystName.MinimumRange = 0;
		this.txtAnalystName.Name = "txtAnalystName";
		this.txtAnalystName.RangeValidation = false;
		this.txtAnalystName.Size = new System.Drawing.Size(248, 21);
		this.txtAnalystName.TabIndex = 0;
		this.txtAnalystName.Text = "";
		this.txtAnalystName.ValidationType = NumberValidator.NumberValidator.Validations.AlphaNumeric;
		//
		//lblLabName
		//
		this.lblLabName.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblLabName.Location = new System.Drawing.Point(8, 41);
		this.lblLabName.Name = "lblLabName";
		this.lblLabName.Size = new System.Drawing.Size(152, 16);
		this.lblLabName.TabIndex = 14;
		this.lblLabName.Text = "Laboratory Name";
		//
		//lblAnalystName
		//
		this.lblAnalystName.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblAnalystName.Location = new System.Drawing.Point(8, 8);
		this.lblAnalystName.Name = "lblAnalystName";
		this.lblAnalystName.Size = new System.Drawing.Size(152, 16);
		this.lblAnalystName.TabIndex = 12;
		this.lblAnalystName.Text = "Name of the Analyst";
		//
		//Office2003Header1
		//
		this.Office2003Header1.BackColor = System.Drawing.SystemColors.Control;
		this.Office2003Header1.Dock = System.Windows.Forms.DockStyle.Top;
		this.Office2003Header1.Location = new System.Drawing.Point(0, 0);
		this.Office2003Header1.Name = "Office2003Header1";
		this.Office2003Header1.Size = new System.Drawing.Size(552, 22);
		this.Office2003Header1.TabIndex = 13;
		this.Office2003Header1.TitleFont = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Office2003Header1.TitleText = "Analysis Parameters";
		//
		//frmMethodAnalysisParameters
		//
		this.AcceptButton = this.btnOk;
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.CancelButton = this.btnCancel;
		this.ClientSize = new System.Drawing.Size(552, 389);
		this.ControlBox = false;
		this.Controls.Add(this.CustomPanelMain);
		this.Controls.Add(this.Office2003Header1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmMethodAnalysisParameters";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Method ";
		this.CustomPanelMain.ResumeLayout(false);
		this.CustomPanelRightBottom.ResumeLayout(false);
		this.gbUnit.ResumeLayout(false);
		this.gbMeasurementMode.ResumeLayout(false);
		this.CustomPanelLeft.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.nudNumDecimalPlaces).EndInit();
		((System.ComponentModel.ISupportInitialize)this.nudNumStdRepeat).EndInit();
		((System.ComponentModel.ISupportInitialize)this.nudNumSampRepeat).EndInit();
		((System.ComponentModel.ISupportInitialize)this.nudNumofSamples).EndInit();
		((System.ComponentModel.ISupportInitialize)this.nudIntegrationTime).EndInit();
		this.CustomPanelBottom.ResumeLayout(false);
		this.CustomPanelTop.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Class Member Variables "

	private int mintOpenMethodMode;
		//by dinesh wagh on 2.2.2010
	private int mintNoOfSamples;

	#End Region

	#Region " Private Properties "

	private EnumMethodMode OpenMethodMode {
		get { return mintOpenMethodMode; }
		set { mintOpenMethodMode = Value; }
	}

	#End Region

	#Region " Private Constants"

	private const int ConstDefaultNoOfDecimalPlaces = 2;
	//+ Added by Amit 26/03/09 ################################################
	private const int ConstDefaultNoOfDecimalPlacesPPB = 4;
	//- Added by Amit 26/03/09 ################################################
	private const int ConstDefaultNoOfSamples = 25;
	private const int ConstDefaultIntegrationTime = 3;
	private const  ConstParentFormLoad = "-Method";

	private const  ConstFormLoad = "-Method-AnalysisParameters ";
	#End Region

	#Region " Form Load and Events Handling functions "

	private void  // ERROR: Handles clauses are not supported in C#
frmMethodAnalysisParameters_Load(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmMethodAnalysisParameters_Load
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To initialize and load the form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 28.07.07
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		//'note:
		//'this is called when form is loaded
		//'this call two function
		//'for initialization and for adding all the event.

		try {
			gobjMain.ShowProgressBar(gstrTitleInstrumentType + ConstFormLoad);
			funcLoadInitialData();
			//'for load initial data 
			//that methos info and other
			AddHandlers();
			//'add a event to a control
			btnOk.Focus();
			if (!IsInIQOQPQ) {
				gobjfrmStatus.Show();
				//'show the status form
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			gobjMain.HideProgressBar();
			//---------------------------------------------------------
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
frmMethodAnalysisParameters_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmMethodAnalysisParameters_Closing
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               :  this is called when user closed the form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 07.09.06
		// Revisions             : 
		//=====================================================================
		//'this is called when user closed the form
		try {
			gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType + ConstParentFormLoad);
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

			gobjMain.HideProgressBar();
			//---------------------------------------------------------
		}
	}

	private void btnCancel_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnCancel_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To send dialog result as cancel
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 07.09.06
		// Revisions             : 
		//=====================================================================

		//'note:
		//' this is called when user click on cancel button

		try {
			if (OpenMethodMode == modGlobalConstants.EnumMethodMode.NewMode) {
				//'check for new method cond

				if (!gobjNewMethod.AnalysisParameters == null) {
					gobjNewMethod.AnalysisParameters = null;
				}
			}
			//gobjchkActiveMethod.CancelMethod = True 'Added By Pankaj 23 May 07 
			//Me.Close()
			this.DialogResult = DialogResult.Cancel;
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

	public object updateSampleParameter(int intNoOfSamples, int intUnitID, bool blnIsDelete = false)
	{
		//=====================================================================
		// Procedure Name        : updateSampleParameter
		// Parameters Passed     : 
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Pankaj Bamb 
		// Created               : 29.05.07
		// Revisions             : Deepak on 28.07.07
		//=====================================================================
		//'note:
		//'this is used to update the sampler parameter
		//'like how many sampler is being used
		//'make a data structure for storing sampler no ,sampler name 
		//'whatever it is repeated or not.
		//'get a input ,no of sampler from user and save it to data structure



		try {
			clsAnalysisSampleParameters objClsSampleParameters;
			clsAnalysisSampleParametersCollection objSamplesCollection;
			//'this is  a object ot samplere data structure
			int i;

			objSamplesCollection = new clsAnalysisSampleParametersCollection();

			if (!gobjNewMethod.SampleDataCollection == null) {
				for (i = 0; i <= intNoOfSamples - 1; i++) {
					//'loop for a no of sample present
					objClsSampleParameters = new clsAnalysisSampleParameters();
					if (gobjNewMethod.SampleDataCollection.Count > i) {
						if (!gobjNewMethod.SampleDataCollection.item(i) == null) {
							objClsSampleParameters.SampNumber = gobjNewMethod.SampleDataCollection.item(i).SampNumber;
							objClsSampleParameters.SampleName = gobjNewMethod.SampleDataCollection.item(i).SampleName;
							if (blnIsDelete == true) {
								objClsSampleParameters.Weight = 1.0;
								if ((intUnitID == 1)) {
									objClsSampleParameters.Volume = 1;
								} else {
									//objClsSampleParameters.Volume = 100
									//---changed as per document recived from app. lab on 30.01.09
									objClsSampleParameters.Volume = 1;
								}
							} else {
								objClsSampleParameters.Weight = gobjNewMethod.SampleDataCollection.item(i).Weight;
								objClsSampleParameters.Volume = gobjNewMethod.SampleDataCollection.item(i).Volume;
							}
						}
					} else {
						objClsSampleParameters.SampNumber = i + 1;
						objClsSampleParameters.SampleName = "Sample " + i + 1;
						objClsSampleParameters.Weight = 1.0;
						if ((intUnitID == 1)) {
							objClsSampleParameters.Volume = 1;
						} else {
							//objClsSampleParameters.Volume = 100
							//---changed as per document received from app.lab on 30.01.09
							objClsSampleParameters.Volume = 1;
						}
					}
					//update sample parameters
					if (gobjNewMethod.SampleDataCollection.Count > i) {
						if (!gobjNewMethod.SampleDataCollection.item(i) == null) {
							objClsSampleParameters.Abs = gobjNewMethod.SampleDataCollection.item(i).Abs;
							objClsSampleParameters.AbsRepeat = gobjNewMethod.SampleDataCollection.item(i).AbsRepeat;
							objClsSampleParameters.Conc = gobjNewMethod.SampleDataCollection.item(i).Conc;
							objClsSampleParameters.Used = gobjNewMethod.SampleDataCollection.item(i).Used;
							if (blnIsDelete == true) {
								objClsSampleParameters.DilutionFactor = 1.0;
							} else {
								objClsSampleParameters.DilutionFactor = gobjNewMethod.SampleDataCollection.item(i).DilutionFactor;
							}
						}
					} else {
						objClsSampleParameters.DilutionFactor = 1.0;
					}
					objSamplesCollection.Add(objClsSampleParameters);
				}
			} else {
				for (i = 0; i <= intNoOfSamples - 1; i++) {
					objClsSampleParameters = new clsAnalysisSampleParameters();
					objClsSampleParameters.SampNumber = i + 1;
					objClsSampleParameters.SampleName = "Sample " + i + 1;
					objClsSampleParameters.Weight = 1;
					if ((intUnitID == 1)) {
						objClsSampleParameters.Volume = 1;
					} else {
						//objClsSampleParameters.Volume = 100
						//---changed as per document recived from app. lab on 30.01.09
						objClsSampleParameters.Volume = 1;
					}
					objClsSampleParameters.DilutionFactor = 1;
					objSamplesCollection.Add(objClsSampleParameters);
				}
			}

			if (!gobjNewMethod.SampleDataCollection == null) {
				gobjNewMethod.SampleDataCollection.Clear();
			} else {
				gobjNewMethod.SampleDataCollection = new clsAnalysisSampleParametersCollection();
			}

			gobjNewMethod.SampleDataCollection = objSamplesCollection.Clone();

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

	private void btnOk_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmMethodAnalysisParameters_Load
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To send dialog result as ok
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 28.07.07
		// Revisions             : 
		//=====================================================================
		//'note:
		//'This is called when user clicked on OK button
		//'algorith is that accept the parameter from user ,store it  in a temp variable
		//'and then bound it to data structure 
		//'with proper method name.



		string strLabName;
		string strAnalystName;
		int intIntegrationTime;
		int intNoOfSamples;
		int intNoOfSampleRepeats;
		int intNoOfStdRepeats;
		int intNoOfDecimalPlaces;
		int intUnitID;
		int intMeasurementID;
		bool blnBlankAfter = false;
		int intCount;
		bool blnDialogResult;
		int intOldNoOfSamples;

		try {
			//---------------------------------------------------
			//1. validate all entered values
			//2. if ok then update all values to object
			//3. if previous value of number of samples and new value of the same differs then 
			//   display a message and update sample parameters.
			//4. if value of unit changes then update sample parameters
			//5. update method collection object
			//---------------------------------------------------

			//1. validate all entered values
			if (nudIntegrationTime.Text == "" | nudNumofSamples.Text == "" | nudNumSampRepeat.Text == "" | nudNumStdRepeat.Text == "" | nudNumDecimalPlaces.Text == "") {
				gobjMessageAdapter.ShowMessage(constFieldsRequired);
				Application.DoEvents();
			} else {
				//2. if ok then update all values to object
				strLabName = Trim(txtLabName.Text);
				strAnalystName = Trim(txtAnalystName.Text);
				intIntegrationTime = nudIntegrationTime.Value;
				intNoOfSamples = nudNumofSamples.Value;
				intNoOfSampleRepeats = nudNumSampRepeat.Value;
				intNoOfStdRepeats = nudNumStdRepeat.Value;
				intNoOfDecimalPlaces = nudNumDecimalPlaces.Value;
				intUnitID = cmbUnits.SelectedValue;
				intMeasurementID = cmbMeasurementMode.SelectedValue;
				if (chkBlankAfter.Checked == true) {
					blnBlankAfter = true;
				} else {
					blnBlankAfter = false;
				}


				//3. if previous value of number of samples and new value of the same differs then 
				//   display a message and update sample parameters.

				if (!gobjNewMethod.AnalysisParameters == null) {
					if (gobjNewMethod.AnalysisParameters.Unit != intUnitID) {
						updateSampleParameter(intNoOfSamples, intUnitID, true);
						gobjNewMethod.AnalysisParameters.Unit = intUnitID;
					}

					if (gobjNewMethod.AnalysisParameters.NumOfSamples != 0) {
						if (gobjNewMethod.AnalysisParameters.NumOfSamples != intNoOfSamples) {
							blnDialogResult = gobjMessageAdapter.ShowMessage(constSamplesChanged);
							Application.DoEvents();

							//4. if value of unit changes then update sample parameters
							//If Not gobjNewMethod.AnalysisParameters.Unit = 0 Then
							//If gobjNewMethod.AnalysisParameters.Unit <> intUnitID Then
							updateSampleParameter(intNoOfSamples, intUnitID, blnDialogResult);
							gobjNewMethod.AnalysisParameters.NumOfSamples = intNoOfSamples;
							gobjNewMethod.AnalysisParameters.Unit = intUnitID;
							//End If
							//End If

							if (blnDialogResult == true) {
								frmSampleParameters objfrmSampleParameters = new frmSampleParameters();
								objfrmSampleParameters.EnableBtnCancel = false;
								objfrmSampleParameters.ShowDialog();
							} else {
								//updateSampleParameter(intNoOfSamples, intUnitID)
								//Dim objfrmSampleParameters As New frmSampleParameters
								//objfrmSampleParameters.EnableBtnCancel = False
								//objfrmSampleParameters.ShowDialog()
							}
						}
					}
				}

				if (!gobjNewMethod == null) {
					gobjNewMethod.UserName = strAnalystName;
					if (!gobjNewMethod.AnalysisParameters == null) {
						gobjNewMethod.AnalysisParameters.LabName = strLabName;
						gobjNewMethod.AnalysisParameters.AnalystName = strAnalystName;
						gobjNewMethod.AnalysisParameters.IntegrationTime = intIntegrationTime;
						gobjNewMethod.AnalysisParameters.NumOfDecimalPlaces = intNoOfDecimalPlaces;
						gobjNewMethod.AnalysisParameters.NumOfSampleRepeats = intNoOfSampleRepeats;
						//gobjNewMethod.AnalysisParameters.NumOfSamples = intNoOfSamples
						gobjNewMethod.AnalysisParameters.NumOfStdRepeats = intNoOfStdRepeats;
						//gobjNewMethod.AnalysisParameters.Unit = intUnitID
						gobjNewMethod.AnalysisParameters.MeasurementMode = intMeasurementID;
						gobjNewMethod.AnalysisParameters.IsBlankAfterEverySampleOrStd = blnBlankAfter;
					}
				}

				//5. update method collection object
				for (intCount = gobjMethodCollection.Count - 1; intCount >= 0; intCount += -1) {
					if (gobjMethodCollection.item(intCount).MethodID == gobjNewMethod.MethodID) {
						gobjMethodCollection.item(intCount).AnalysisParameters = gobjNewMethod.AnalysisParameters.Clone;
						gobjMethodCollection.item(intCount).SampleDataCollection = gobjNewMethod.SampleDataCollection.Clone;
						//Addded By Pankaj 29 May 07 
						gobjMethodCollection.item(intCount).DateOfModification = DateTime.Now;
						funcSaveAllMethods(gobjMethodCollection);
						break; // TODO: might not be correct. Was : Exit For
					}
				}
			}

			this.DialogResult = DialogResult.OK;

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

	//+ Added by Amit 26/03/09 ################################################
	private void cmbUnits_SelectedIndexChanged(object sender, System.EventArgs e)
	{
		if (cmbUnits.SelectedIndex == 2) {
			nudNumDecimalPlaces.Value = ConstDefaultNoOfDecimalPlacesPPB;
		} else {
			nudNumDecimalPlaces.Value = ConstDefaultNoOfDecimalPlaces;
		}
	}
	//- Added by Amit 26/03/09 ################################################

	#End Region

	#Region " Private Functions "

	private void AddHandlers()
	{
		//=====================================================================
		// Procedure Name        : AddHandlers
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To add the handlers
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 04.10.06
		// Revisions             : 
		//=====================================================================
		try {
			//'this will bind all the event to a control 
			btnOk.Click += btnOk_Click;
			btnCancel.Click += btnCancel_Click;
			//+ Added by Amit 26/03/09 ################################################
			cmbUnits.SelectedIndexChanged += cmbUnits_SelectedIndexChanged;
		//- Added by Amit 26/03/09 ################################################
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

	private bool funcLoadInitialData()
	{
		//=====================================================================
		// Procedure Name        : funcLoadInitialData
		// Parameters Passed     : None
		// Returns               : True or False
		// Purpose               : To load the initial data
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 28.07.07
		// Revisions             : 0
		//=====================================================================
		DataTable objDtUnits = new DataTable();
		DataTable objDtMeasurementMode = new DataTable();
		try {
			//-----------------------------------------------------------------
			//1. set mode type
			//2. if new mode then load initial data else load data from object
			//-----------------------------------------------------------------

			//1. set mode type
			if (gobjNewMethod.AnalysisParameters == null) {
				OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode;
				gobjNewMethod.AnalysisParameters = new clsAnalysisParameters();

				//gobjNewMethod.AnalysisParameters.NumOfSamples = 25 'commented by : dinesh wagh on 2.2.2010

				//added by ; dinesh wagh on 2.2.2010
				//---------------------------------------
				if (mintNoOfSamples != 0) {
					gobjNewMethod.AnalysisParameters.NumOfSamples = mintNoOfSamples;
				} else {
					gobjNewMethod.AnalysisParameters.NumOfSamples = 25;
				}
			//-------------------------------------


			} else {
				OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode;
			}

			//2. if new mode then load initial data else load data from object
			objDtUnits = gobjClsAAS203.funcGetUnits();
			objDtMeasurementMode = gobjClsAAS203.funcGetMeasurementMode();

			if (!objDtUnits == null) {
				cmbUnits.DataSource = objDtUnits;
				cmbUnits.DisplayMember = objDtUnits.Columns(ConstColumnUnit).ColumnName;
				cmbUnits.ValueMember = objDtUnits.Columns(ConstColumnUnitID).ColumnName;
			}

			if (!objDtMeasurementMode == null) {
				cmbMeasurementMode.DataSource = objDtMeasurementMode;
				cmbMeasurementMode.DisplayMember = objDtMeasurementMode.Columns(ConstColumnMeasurementMode).ColumnName;
				cmbMeasurementMode.ValueMember = objDtMeasurementMode.Columns(ConstColumnMeasurementModeID).ColumnName;
			}

			switch (OpenMethodMode) {
				case modGlobalConstants.EnumMethodMode.NewMode:
					SubShowDefaultData();
				case modGlobalConstants.EnumMethodMode.EditMode:
					SubShowDataFromParametersObject();
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

	private void  // ERROR: Handles clauses are not supported in C#
nudNumofSamples_LostFocus(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : nudNumofSamples_LostFocus
		// Parameters Passed     : None
		// Returns               : Validate nudNumofSamples
		// Purpose               :  
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 28.07.07
		// Revisions             : 0
		//=====================================================================
		try {
			if (nudNumofSamples.Value < 0 | nudNumofSamples.Value > 200) {
				gobjMessageAdapter.ShowMessage(constCheckValue);
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
nudIntegrationTime_LostFocus(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : nudIntegrationTime_LostFocus
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : validate nudIntegrationTime
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 28.07.07
		// Revisions             : 0
		// Revision By           : 
		//=====================================================================
		try {
			if (nudIntegrationTime.Value < 1) {
				nudIntegrationTime.Value = 1;
			} else if (nudIntegrationTime.Value > 99) {
				nudIntegrationTime.Value = 99;
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
nudNumSampRepeat_LostFocus(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : nudNumSampRepeat_LostFocus
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : validate  nudNumSampRepeat
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 28.07.07
		// Revisions             : 0
		// Revision By           : 
		//=====================================================================
		try {
			if (nudNumSampRepeat.Value < 1) {
				nudNumSampRepeat.Value = 1;
			} else if (nudNumSampRepeat.Value > 15) {
				nudNumSampRepeat.Value = 15;
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
nudNumStdRepeat_LostFocus(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : nudNumStdRepeat_LostFocus
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               :  Validate nudNumStdRepeat control
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 28.07.07
		// Revisions             : 0
		// Revision By           : 
		//=====================================================================
		try {
			if (nudNumStdRepeat.Value < 1) {
				nudNumStdRepeat.Value = 1;
			} else if (nudNumStdRepeat.Value > 15) {
				nudNumStdRepeat.Value = 15;
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
nudNumDecimalPlaces_LostFocus(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : nudNumDecimalPlaces_LostFocus
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               :  validate nudNumDecimalPlaces values
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 28.07.07
		// Revisions             : 0
		// Revision By           : 
		//=====================================================================
		try {
			if (nudNumDecimalPlaces.Value < 0) {
				nudNumDecimalPlaces.Value = 0;
			} else if (nudNumDecimalPlaces.Value > 8) {
				nudNumDecimalPlaces.Value = 8;
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

	private void SubShowDefaultData()
	{
		//=====================================================================
		// Procedure Name        : SubSetDefaultData
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To load the default data
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 28.07.07
		// Revisions             : 0
		// Revision By           : 
		//=====================================================================

		//'note;
		//'this is called during the loading of a form 
		//'this will load some default value of all parameter on the screen



		try {
			//--16.03.08
			if (gblnIsDemoWithRealData == true) {
				txtLabName.Text = CONST_LabName1;
			} else {
				txtLabName.Text = gstrCustomer;
			}

			if (!gobjNewMethod == null) {
				txtAnalystName.Text = gobjNewMethod.UserName;
			}
			nudIntegrationTime.Value = ConstDefaultIntegrationTime;
			nudNumDecimalPlaces.Value = ConstDefaultNoOfDecimalPlaces;
			chkBlankAfter.Checked = true;



			//---03.08.09
			if (gobjNewMethod.StandardAddition == true) {
				nudNumSampRepeat.Enabled = false;
			}

			//nudNumofSamples.Value = ConstDefaultNoOfSamples 'code commented by : dinesh wagh on 2.2.2010

			//code added by ; dinesh wagh on 2.2.2010
			//-------------------------------------
			if (mintNoOfSamples != 0) {
				nudNumofSamples.Value = mintNoOfSamples;
			} else {
				nudNumofSamples.Value = ConstDefaultNoOfSamples;
			}
		//------------------------------------

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

	private void SubShowDataFromParametersObject()
	{
		//=====================================================================
		// Procedure Name        : SubShowDataFromParametersObject
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To load the parameters data
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 28.07.07
		// Revisions             : 0
		// Revision By           : 
		//=====================================================================

		//'note:
		//'this function will set the data from data structure object to
		//'the screen
		//'eg method name , method mode etc

		try {
			if (!gobjNewMethod == null) {
				txtAnalystName.Text = gobjNewMethod.UserName;
				if (!gobjNewMethod.AnalysisParameters == null) {
					txtLabName.Text = gobjNewMethod.AnalysisParameters.LabName;
					nudIntegrationTime.Value = gobjNewMethod.AnalysisParameters.IntegrationTime;
					nudNumDecimalPlaces.Value = gobjNewMethod.AnalysisParameters.NumOfDecimalPlaces;
					nudNumofSamples.Value = gobjNewMethod.AnalysisParameters.NumOfSamples;
					nudNumSampRepeat.Value = gobjNewMethod.AnalysisParameters.NumOfSampleRepeats;
					nudNumStdRepeat.Value = gobjNewMethod.AnalysisParameters.NumOfStdRepeats;
					chkBlankAfter.Checked = gobjNewMethod.AnalysisParameters.IsBlankAfterEverySampleOrStd;
					cmbUnits.SelectedValue = gobjNewMethod.AnalysisParameters.Unit;
					cmbMeasurementMode.SelectedValue = gobjNewMethod.AnalysisParameters.MeasurementMode;
				}
			}
			//---03.08.09
			if (gobjNewMethod.StandardAddition == true) {
				nudNumSampRepeat.Enabled = false;
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

	#Region "Commented Code"
	//Private Sub frmMethodAnalysisParameters_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	//    '=====================================================================
	//    ' Procedure Name        : frmMethodAnalysisParameters_Load
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : To initialize and load the form
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Deepak Bhati
	//    ' Created               : 03.10.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    Dim objWait As New CWaitCursor

	//    Try
	//        Call gobjMain.ShowProgressBar(ConstFormLoad)

	//        If funcLoadInitialData() = False Then
	//            '---display error message
	//        End If

	//        Call AddHandlers()
	//        btnOk.Focus()
	//        'Saurabh 10.07.07 To bring status form in front
	//        If Not IsInIQOQPQ Then
	//            gobjfrmStatus.Show()
	//        End If
	//        'Saurabh


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
	//        objWait.Dispose()
	//        gobjMain.HideProgressBar()
	//        '---------------------------------------------------------
	//    End Try
	//End Sub '28.07.07

	//Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : frmMethodAnalysisParameters_Load
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : To send dialog result as ok
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Deepak Bhati
	//    ' Created               : 03.10.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    Dim strLabName As String
	//    Dim strAnalystName As String
	//    Dim intIntegrationTime, intNoOfSamples, intNoOfSampleRepeats, intNoOfStdRepeats, intNoOfDecimalPlaces As Integer
	//    Dim intUnitID, intMeasurementID As Integer
	//    Dim blnBlankAfter As Boolean = False
	//    Dim intCount As Integer
	//    Dim blnDlgRst As Boolean
	//    Dim intOldNoOfSamples As Integer

	//    Try
	//        If nudIntegrationTime.Text = "" Or nudNumofSamples.Text = "" Or nudNumSampRepeat.Text = "" Or nudNumStdRepeat.Text = "" Or nudNumDecimalPlaces.Text = "" Then
	//            gobjMessageAdapter.ShowMessage(constFieldsRequired)
	//            Application.DoEvents()
	//        Else
	//            strLabName = Trim(txtLabName.Text)
	//            strAnalystName = Trim(txtAnalystName.Text)
	//            intIntegrationTime = nudIntegrationTime.Value
	//            intNoOfSamples = nudNumofSamples.Value
	//            intNoOfSampleRepeats = nudNumSampRepeat.Value
	//            intNoOfStdRepeats = nudNumStdRepeat.Value
	//            intNoOfDecimalPlaces = nudNumDecimalPlaces.Value
	//            intUnitID = cmbUnits.SelectedValue
	//            intMeasurementID = cmbMeasurementMode.SelectedValue

	//            '---By Saurabh------
	//            '"Edit the Sample parameters form from Analysis parameters
	//            If OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode Then
	//                '---------Added By Pankaj 28 May 07
	//                If (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit <> intUnitID) Then
	//                    Call updateSampleParameter(mintRunNumberIndex, intNoOfSamples, intUnitID)
	//                    'Dim objfrmSampleParameters As New frmSampleParameters(modGlobalConstants.EnumMethodMode.NewMode)
	//                    'objfrmSampleParameters.ShowDialog()
	//                End If
	//                '--------
	//                If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSamples <> intNoOfSamples Then
	//                    blnDlgRst = gobjMessageAdapter.ShowMessage(constSamplesChanged)

	//                    'dlgRst = MsgBox("No. of Samples has been changed. Do you want to delete old Sample parameters?", MsgBoxStyle.YesNo, "Confirmation required")
	//                    'If dlgRst = DialogResult.Yes Then
	//                    '    Dim objfrmSampleParameters As New frmSampleParameters(EnumMethodMode.NewMode, intNoOfSamples)
	//                    '    objfrmSampleParameters.ShowDialog()
	//                    'Else
	//                    '    Dim objfrmSampleParameters As New frmSampleParameters(EnumMethodMode.EditMode, intNoOfSamples)
	//                    '    objfrmSampleParameters.ShowDialog()
	//                    'End If
	//                End If
	//            ElseIf (gobjchkActiveMethod.CancelMethod = True And gobjchkActiveMethod.NewMethod = True) And OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode Then
	//                '---------Added By Pankaj 28 May 07
	//                If (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit <> intUnitID) Then
	//                    Call updateSampleParameter(mintRunNumberIndex, intNoOfSamples, intUnitID)
	//                    'Dim objfrmSampleParameters As New frmSampleParameters(modGlobalConstants.EnumMethodMode.NewMode)
	//                    'objfrmSampleParameters.ShowDialog()
	//                End If
	//            End If
	//            '====================

	//            If chkBlankAfter.Checked = True Then
	//                blnBlankAfter = True
	//            Else
	//                blnBlankAfter = False
	//            End If

	//            If Not strLabName = "" Then
	//                If Not strAnalystName = "" Then
	//                    'gobjNewMethod.AnalysisParameters.AnalystName = strAnalystName
	//                    'gobjNewMethod.AnalysisParameters.LabName = strLabName
	//                    'gobjNewMethod.AnalysisParameters.IntegrationTime = intIntegrationTime
	//                    'gobjNewMethod.AnalysisParameters.NumOfDecimalPlaces = intNoOfDecimalPlaces
	//                    'gobjNewMethod.AnalysisParameters.NumOfSampleRepeats = intNoOfSampleRepeats
	//                    'gobjNewMethod.AnalysisParameters.NumOfSamples = intNoOfSamples
	//                    'gobjNewMethod.AnalysisParameters.NumOfStdRepeats = intNoOfStdRepeats
	//                    'gobjNewMethod.AnalysisParameters.Unit = intUnitID
	//                    'gobjNewMethod.AnalysisParameters.MeasurementMode = intMeasurementID
	//                    'gobjNewMethod.AnalysisParameters.IsBlankAfterEverySampleOrStd = blnBlankAfter
	//                    intOldNoOfSamples = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSamples  '------Saurabh


	//                    'gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.AnalystName = strAnalystName
	//                    gobjNewMethod.UserName = strAnalystName
	//                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.LabName = strLabName
	//                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.IntegrationTime = intIntegrationTime
	//                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces = intNoOfDecimalPlaces
	//                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats = intNoOfSampleRepeats
	//                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSamples = intNoOfSamples
	//                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats = intNoOfStdRepeats
	//                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit = intUnitID
	//                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.MeasurementMode = intMeasurementID
	//                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.IsBlankAfterEverySampleOrStd = blnBlankAfter
	//                    'gobjNewMethod.DateOfModification = DateTime.Now
	//                Else
	//                    '---display error message
	//                End If
	//                '---display error message
	//            End If
	//            For intCount = 0 To gobjMethodCollection.Count - 1
	//                If gobjMethodCollection.item(intCount).MethodID = gobjNewMethod.MethodID Then
	//                    'gobjMethodCollection.item(intCount).AnalysisParameters = gobjNewMethod.AnalysisParameters.Clone
	//                    gobjMethodCollection.item(intCount).QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Clone
	//                    gobjMethodCollection.item(intCount).QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Clone 'Addded By Pankaj 29 May 07 
	//                    gobjMethodCollection.item(intCount).DateOfModification = DateTime.Now
	//                End If
	//            Next

	//            'Call funcSerialize(ConstMethodsFileName, gobjMethodCollection)
	//            'Added By Pankaj on 23 May 07 for adding method of inactive mode
	//            gobjchkActiveMethod.fillParameters = True
	//            If (gobjchkActiveMethod.fillInstruments = True And gobjchkActiveMethod.fillParameters = True And gobjchkActiveMethod.fillStdConcentration = True And gobjchkActiveMethod.CancelMethod = True And gobjchkActiveMethod.NewMethod = True) Then
	//                gobjchkActiveMethod.NewMethod = False
	//                gobjchkActiveMethod.CancelMethod = False
	//                gobjchkActiveMethod.fillInstruments = False
	//                gobjchkActiveMethod.fillParameters = False
	//                gobjchkActiveMethod.fillStdConcentration = False
	//                gobjNewMethod.Status = True
	//                gobjMethodCollection.Add(gobjNewMethod)
	//            End If
	//            Call funcSaveAllMethods(gobjMethodCollection)

	//            '....Continued
	//            If OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode Then
	//                If blnDlgRst = True Then
	//                    Dim objfrmSampleParameters As New frmSampleParameters(EnumMethodMode.NewMode)
	//                    objfrmSampleParameters.EnableBtnCancel = False
	//                    objfrmSampleParameters.ShowDialog()
	//                ElseIf blnDlgRst = False Then
	//                    If intOldNoOfSamples <> intNoOfSamples Then
	//                        Dim objfrmSampleParameters As New frmSampleParameters(EnumMethodMode.EditMode)
	//                        objfrmSampleParameters.EnableBtnCancel = False
	//                        objfrmSampleParameters.ShowDialog()
	//                    End If
	//                End If
	//            End If


	//            Me.DialogResult = DialogResult.OK

	//        End If

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

	//Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)   '28.07.07
	//    '=====================================================================
	//    ' Procedure Name        : frmMethodAnalysisParameters_Load
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : To send dialog result as ok
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Deepak Bhati
	//    ' Created               : 03.10.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    Dim strLabName As String
	//    Dim strAnalystName As String
	//    Dim intIntegrationTime, intNoOfSamples, intNoOfSampleRepeats, intNoOfStdRepeats, intNoOfDecimalPlaces As Integer
	//    Dim intUnitID, intMeasurementID As Integer
	//    Dim blnBlankAfter As Boolean = False
	//    Dim intCount As Integer
	//    Dim blnDlgRst As Boolean
	//    Dim intOldNoOfSamples As Integer

	//    '---18.06.07
	//    Try
	//        If nudIntegrationTime.Text = "" Or nudNumofSamples.Text = "" Or nudNumSampRepeat.Text = "" Or nudNumStdRepeat.Text = "" Or nudNumDecimalPlaces.Text = "" Then
	//            gobjMessageAdapter.ShowMessage(constFieldsRequired)
	//            Application.DoEvents()
	//        Else
	//            strLabName = Trim(txtLabName.Text)
	//            strAnalystName = Trim(txtAnalystName.Text)
	//            intIntegrationTime = nudIntegrationTime.Value
	//            intNoOfSamples = nudNumofSamples.Value
	//            intNoOfSampleRepeats = nudNumSampRepeat.Value
	//            intNoOfStdRepeats = nudNumStdRepeat.Value
	//            intNoOfDecimalPlaces = nudNumDecimalPlaces.Value
	//            intUnitID = cmbUnits.SelectedValue
	//            intMeasurementID = cmbMeasurementMode.SelectedValue

	//            '---By Saurabh------
	//            '"Edit the Sample parameters form from Analysis parameters
	//            If OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode Then
	//                '---------Added By Pankaj 28 May 07
	//                If (gobjNewMethod.AnalysisParameters.Unit <> intUnitID) Then
	//                    Call updateSampleParameter(intNoOfSamples, intUnitID)
	//                    'Dim objfrmSampleParameters As New frmSampleParameters(modGlobalConstants.EnumMethodMode.NewMode)
	//                    'objfrmSampleParameters.ShowDialog()
	//                End If
	//                '--------
	//                If gobjNewMethod.AnalysisParameters.NumOfSamples <> 0 Then
	//                    If gobjNewMethod.AnalysisParameters.NumOfSamples <> intNoOfSamples Then
	//                        blnDlgRst = gobjMessageAdapter.ShowMessage(constSamplesChanged)
	//                        Application.DoEvents()
	//                        'dlgRst = MsgBox("No. of Samples has been changed. Do you want to delete old Sample parameters?", MsgBoxStyle.YesNo, "Confirmation required")
	//                        'If dlgRst = DialogResult.Yes Then
	//                        '    Dim objfrmSampleParameters As New frmSampleParameters(EnumMethodMode.NewMode, intNoOfSamples)
	//                        '    objfrmSampleParameters.ShowDialog()
	//                        'Else
	//                        '    Dim objfrmSampleParameters As New frmSampleParameters(EnumMethodMode.EditMode, intNoOfSamples)
	//                        '    objfrmSampleParameters.ShowDialog()
	//                        'End If
	//                    End If
	//                End If
	//            ElseIf gobjchkActiveMethod.CancelMethod = True And gobjchkActiveMethod.NewMethod = True And OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode Then
	//                '---------Added By Pankaj 28 May 07
	//                If (gobjNewMethod.AnalysisParameters.Unit <> intUnitID) Then
	//                    Call updateSampleParameter(intNoOfSamples, intUnitID)
	//                    'Dim objfrmSampleParameters As New frmSampleParameters(modGlobalConstants.EnumMethodMode.NewMode)
	//                    'objfrmSampleParameters.ShowDialog()
	//                End If
	//            End If
	//            '====================

	//            If chkBlankAfter.Checked = True Then
	//                blnBlankAfter = True
	//            Else
	//                blnBlankAfter = False
	//            End If

	//            If Not strLabName = "" Then
	//                If Not strAnalystName = "" Then
	//                    intOldNoOfSamples = gobjNewMethod.AnalysisParameters.NumOfSamples  '------Saurabh

	//                    gobjNewMethod.UserName = strAnalystName
	//                    gobjNewMethod.AnalysisParameters.LabName = strLabName
	//                    gobjNewMethod.AnalysisParameters.IntegrationTime = intIntegrationTime
	//                    gobjNewMethod.AnalysisParameters.NumOfDecimalPlaces = intNoOfDecimalPlaces
	//                    gobjNewMethod.AnalysisParameters.NumOfSampleRepeats = intNoOfSampleRepeats
	//                    gobjNewMethod.AnalysisParameters.NumOfSamples = intNoOfSamples
	//                    gobjNewMethod.AnalysisParameters.NumOfStdRepeats = intNoOfStdRepeats
	//                    gobjNewMethod.AnalysisParameters.Unit = intUnitID
	//                    gobjNewMethod.AnalysisParameters.MeasurementMode = intMeasurementID
	//                    gobjNewMethod.AnalysisParameters.IsBlankAfterEverySampleOrStd = blnBlankAfter
	//                    'gobjNewMethod.DateOfModification = DateTime.Now
	//                Else
	//                    '---display error message
	//                End If
	//                '---display error message
	//            End If
	//            For intCount = 0 To gobjMethodCollection.Count - 1
	//                If gobjMethodCollection.item(intCount).MethodID = gobjNewMethod.MethodID Then
	//                    'gobjMethodCollection.item(intCount).AnalysisParameters = gobjNewMethod.AnalysisParameters.Clone
	//                    gobjMethodCollection.item(intCount).AnalysisParameters = gobjNewMethod.AnalysisParameters.Clone
	//                    gobjMethodCollection.item(intCount).SampleDataCollection = gobjNewMethod.SampleDataCollection.Clone 'Addded By Pankaj 29 May 07 
	//                    gobjMethodCollection.item(intCount).DateOfModification = DateTime.Now
	//                End If
	//            Next

	//            'Call funcSerialize(ConstMethodsFileName, gobjMethodCollection)
	//            'Added By Pankaj on 23 May 07 for adding method of inactive mode
	//            gobjchkActiveMethod.fillParameters = True '27.07.07
	//            'If (gobjchkActiveMethod.fillInstruments = True And gobjchkActiveMethod.fillParameters = True And gobjchkActiveMethod.fillStdConcentration = True And gobjchkActiveMethod.CancelMethod = True And gobjchkActiveMethod.NewMethod = True) Then
	//            If (gobjchkActiveMethod.fillParameters = True And gobjchkActiveMethod.fillStdConcentration = True And gobjchkActiveMethod.CancelMethod = True And gobjchkActiveMethod.NewMethod = True) Then
	//                gobjchkActiveMethod.NewMethod = False
	//                gobjchkActiveMethod.CancelMethod = False
	//                'gobjchkActiveMethod.fillInstruments = False  '27.07.07
	//                gobjchkActiveMethod.fillParameters = False
	//                gobjchkActiveMethod.fillStdConcentration = False
	//                gobjNewMethod.Status = True
	//                gobjMethodCollection.Add(gobjNewMethod)
	//            End If
	//            Call funcSaveAllMethods(gobjMethodCollection)

	//            '....Continued
	//            If OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode Then
	//                If gobjNewMethod.AnalysisParameters.NumOfSamples <> 0 Then
	//                    If blnDlgRst = True Then
	//                        Dim objfrmSampleParameters As New frmSampleParameters(EnumMethodMode.NewMode)
	//                        objfrmSampleParameters.EnableBtnCancel = False
	//                        objfrmSampleParameters.ShowDialog()
	//                    ElseIf blnDlgRst = False Then
	//                        If intOldNoOfSamples <> intNoOfSamples Then
	//                            Dim objfrmSampleParameters As New frmSampleParameters(EnumMethodMode.EditMode)
	//                            objfrmSampleParameters.EnableBtnCancel = False
	//                            objfrmSampleParameters.ShowDialog()
	//                        End If
	//                    End If
	//                End If
	//            End If

	//            Me.DialogResult = DialogResult.OK

	//        End If

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

	//Public Function updateSampleParameter(ByVal mintRunNumberIndex As Integer, ByVal intNoOfSamples As Integer, ByVal intUnitID As Integer)
	//    '=====================================================================
	//    ' Procedure Name        : updateSampleParameter
	//    ' Parameters Passed     : 
	//    ' Returns               : None
	//    ' Purpose               : 
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Pankaj Bamb 
	//    ' Created               : 29.05.07
	//    ' Revisions             : 
	//    '=====================================================================
	//    'If gobjNewMethod.QuantitativeDataCollection.Count > 0 Then
	//    '    mintRunNumberIndex = gobjNewMethod.QuantitativeDataCollection.Count - 1

	//    'ElseIf gobjNewMethod.QuantitativeDataCollection.Count = 0 Then
	//    '    mintRunNumberIndex = 0
	//    'End If
	//    Try
	//        Dim objClsSampleParameters As clsAnalysisSampleParameters
	//        Dim objSamplesCollection As clsAnalysisSampleParametersCollection
	//        Dim i As Integer

	//        objSamplesCollection = New clsAnalysisSampleParametersCollection
	//        If (OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode) And ((gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count > 0)) Then
	//            For i = 0 To intNoOfSamples - 1
	//                objClsSampleParameters = New clsAnalysisSampleParameters
	//                objClsSampleParameters.SampNumber = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(i).SampNumber
	//                objClsSampleParameters.SampleName = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(i).SampleName
	//                objClsSampleParameters.Weight = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(i).Weight
	//                If (intUnitID = 1) Then
	//                    objClsSampleParameters.Volume = 1
	//                Else
	//                    objClsSampleParameters.Volume = 100
	//                End If
	//                '//----- Added by Sachin Dokhale
	//                objClsSampleParameters.Abs = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(i).Abs
	//                objClsSampleParameters.AbsRepeat = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(i).AbsRepeat
	//                objClsSampleParameters.Conc = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(i).Conc
	//                objClsSampleParameters.Used = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(i).Used
	//                '//-----

	//                objClsSampleParameters.DilutionFactor = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(i).DilutionFactor
	//                objSamplesCollection.Add(objClsSampleParameters)
	//            Next
	//        Else
	//            For i = 0 To intNoOfSamples - 1
	//                objClsSampleParameters = New clsAnalysisSampleParameters
	//                objClsSampleParameters.SampNumber = i
	//                objClsSampleParameters.SampleName = "Sample " & i + 1
	//                objClsSampleParameters.Weight = 1
	//                If (intUnitID = 1) Then
	//                    objClsSampleParameters.Volume = 1
	//                Else
	//                    objClsSampleParameters.Volume = 100
	//                End If
	//                objClsSampleParameters.DilutionFactor = 1
	//                objSamplesCollection.Add(objClsSampleParameters)
	//            Next
	//        End If


	//        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Clear()
	//        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection = objSamplesCollection.Clone()

	//        'For i As Integer = 0 To intNoOfSamples - 1
	//        '    If (intUnitID = 1) Then
	//        '        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(i).Volume = 1
	//        '    Else
	//        '        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(i).Volume = 100
	//        '    End If
	//        'Next
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
	//End Function

	//Public Function updateSampleParameter(ByVal intNoOfSamples As Integer, ByVal intUnitID As Integer)
	//    '=====================================================================
	//    ' Procedure Name        : updateSampleParameter
	//    ' Parameters Passed     : 
	//    ' Returns               : None
	//    ' Purpose               : 
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Pankaj Bamb 
	//    ' Created               : 29.05.07
	//    ' Revisions             : 
	//    '=====================================================================
	//    Try
	//        Dim objClsSampleParameters As clsAnalysisSampleParameters
	//        Dim objSamplesCollection As clsAnalysisSampleParametersCollection
	//        Dim i As Integer

	//        objSamplesCollection = New clsAnalysisSampleParametersCollection
	//        If (OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode) And ((gobjNewMethod.SampleDataCollection.Count > 0)) Then
	//            For i = 0 To intNoOfSamples - 1
	//                objClsSampleParameters = New clsAnalysisSampleParameters
	//                objClsSampleParameters.SampNumber = gobjNewMethod.SampleDataCollection.item(i).SampNumber
	//                objClsSampleParameters.SampleName = gobjNewMethod.SampleDataCollection.item(i).SampleName
	//                objClsSampleParameters.Weight = gobjNewMethod.SampleDataCollection.item(i).Weight
	//                If (intUnitID = 1) Then
	//                    objClsSampleParameters.Volume = 1
	//                Else
	//                    objClsSampleParameters.Volume = 100
	//                End If
	//                '//----- Added by Sachin Dokhale
	//                objClsSampleParameters.Abs = gobjNewMethod.SampleDataCollection.item(i).Abs
	//                objClsSampleParameters.AbsRepeat = gobjNewMethod.SampleDataCollection.item(i).AbsRepeat
	//                objClsSampleParameters.Conc = gobjNewMethod.SampleDataCollection.item(i).Conc
	//                objClsSampleParameters.Used = gobjNewMethod.SampleDataCollection.item(i).Used
	//                '//-----

	//                objClsSampleParameters.DilutionFactor = gobjNewMethod.SampleDataCollection.item(i).DilutionFactor
	//                objSamplesCollection.Add(objClsSampleParameters)
	//            Next
	//        Else
	//            For i = 0 To intNoOfSamples - 1
	//                objClsSampleParameters = New clsAnalysisSampleParameters
	//                objClsSampleParameters.SampNumber = i
	//                objClsSampleParameters.SampleName = "Sample " & i + 1
	//                objClsSampleParameters.Weight = 1
	//                If (intUnitID = 1) Then
	//                    objClsSampleParameters.Volume = 1
	//                Else
	//                    objClsSampleParameters.Volume = 100
	//                End If
	//                objClsSampleParameters.DilutionFactor = 1
	//                objSamplesCollection.Add(objClsSampleParameters)
	//            Next
	//        End If


	//        gobjNewMethod.SampleDataCollection.Clear()
	//        gobjNewMethod.SampleDataCollection = objSamplesCollection.Clone()

	//        'For i As Integer = 0 To intNoOfSamples - 1
	//        '    If (intUnitID = 1) Then
	//        '        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(i).Volume = 1
	//        '    Else
	//        '        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(i).Volume = 100
	//        '    End If
	//        'Next
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
	//End Function

	//Private Function funcLoadInitialData() As Boolean
	//    '=====================================================================
	//    ' Procedure Name        : funcLoadInitialData
	//    ' Parameters Passed     : None
	//    ' Returns               : True or False
	//    ' Purpose               : To load the initial data
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Deepak Bhati
	//    ' Created               : 04.10.06
	//    ' Revisions             : 2
	//    ' Revision By           : Mangesh S. on 28-Jan-2007
	//    ' Revision for          : Changes in AAS203Library
	//    ' Revision for          : Changes in AAS203Library By Deepak 18.06.07
	//    '=====================================================================
	//    Dim objDtUnits As New DataTable
	//    Dim objDtMeasurementMode As New DataTable

	//    Try
	//        txtLabName.Text = CONST_LabName
	//        txtAnalystName.Text = gobjNewMethod.UserName
	//        nudIntegrationTime.Value = ConstDefaultIntegrationTime
	//        nudNumDecimalPlaces.Value = ConstDefaultNoOfDecimalPlaces
	//        chkBlankAfter.Checked = True
	//        nudNumofSamples.Value = ConstDefaultNoOfSamples

	//        objDtUnits = gobjClsAAS203.funcGetUnits()
	//        objDtMeasurementMode = gobjClsAAS203.funcGetMeasurementMode()

	//        cmbUnits.DataSource = objDtUnits
	//        cmbUnits.DisplayMember = objDtUnits.Columns(ConstColumnUnit).ColumnName
	//        cmbUnits.ValueMember = objDtUnits.Columns(ConstColumnUnitID).ColumnName

	//        cmbMeasurementMode.DataSource = objDtMeasurementMode
	//        cmbMeasurementMode.DisplayMember = objDtMeasurementMode.Columns(ConstColumnMeasurementMode).ColumnName
	//        cmbMeasurementMode.ValueMember = objDtMeasurementMode.Columns(ConstColumnMeasurementModeID).ColumnName

	//        If OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode Then
	//            gobjNewMethod.AnalysisParameters = New AAS203Library.Method.clsAnalysisParameters
	//        End If

	//        If Not gobjNewMethod.AnalysisParameters.Unit = 0 Then
	//            cmbUnits.SelectedValue = gobjNewMethod.AnalysisParameters.Unit
	//        End If

	//        If Not gobjNewMethod.AnalysisParameters.MeasurementMode = 0 Then
	//            cmbMeasurementMode.SelectedValue = gobjNewMethod.AnalysisParameters.MeasurementMode
	//        End If

	//        If OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode Then
	//            txtAnalystName.Text = gobjNewMethod.UserName
	//            txtLabName.Text = gobjNewMethod.AnalysisParameters.LabName
	//            nudIntegrationTime.Value = gobjNewMethod.AnalysisParameters.IntegrationTime
	//            nudNumDecimalPlaces.Value = gobjNewMethod.AnalysisParameters.NumOfDecimalPlaces
	//            nudNumofSamples.Value = gobjNewMethod.AnalysisParameters.NumOfSamples
	//            nudNumSampRepeat.Value = gobjNewMethod.AnalysisParameters.NumOfSampleRepeats
	//            nudNumStdRepeat.Value = gobjNewMethod.AnalysisParameters.NumOfStdRepeats
	//            chkBlankAfter.Checked = gobjNewMethod.AnalysisParameters.IsBlankAfterEverySampleOrStd
	//        End If

	//        Return True

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        Return False
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try
	//End Function  '28.07.07

	#End Region



}
