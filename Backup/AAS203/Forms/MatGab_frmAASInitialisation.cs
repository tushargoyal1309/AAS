using AAS203Library;
using AAS203Library.Instrument;

public class frmAASInitialisation : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmAASInitialisation()
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
	public System.Windows.Forms.ImageList ImgInit;
	internal System.Windows.Forms.Label lblInstrumentType;
	internal System.Windows.Forms.PictureBox PictureBox2;
	internal System.Windows.Forms.Label Label3;
	internal System.Windows.Forms.Panel pnlStepList;
	internal System.Windows.Forms.Label lblStep7;
	internal System.Windows.Forms.PictureBox PictureBox1;
	internal System.Windows.Forms.Label lblStep6;
	internal System.Windows.Forms.Label lblStep5;
	internal System.Windows.Forms.Label lblStep4;
	internal System.Windows.Forms.Label lblStep3;
	internal System.Windows.Forms.Label lblStep2;
	internal System.Windows.Forms.Label lblStep1;
	internal System.Windows.Forms.Label lblStatus1;
	internal System.Windows.Forms.Label lblStatus2;
	internal System.Windows.Forms.Label lblStatus3;
	internal System.Windows.Forms.Label lblStatus4;
	internal System.Windows.Forms.Label lblStatus5;
	internal System.Windows.Forms.Label lblStatus6;
	internal System.Windows.Forms.Label lblTitle;
	internal System.Windows.Forms.Label lblStatus7;
	internal System.Windows.Forms.Label lblStatus8;
	internal System.Windows.Forms.Label lblStep8;
	internal System.Windows.Forms.PictureBox PictureBox3_DB;
	internal System.Windows.Forms.Label lbltitle_DB;
	internal System.Windows.Forms.Label lbl21CFR;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmAASInitialisation));
		this.ImgInit = new System.Windows.Forms.ImageList(this.components);
		this.lblInstrumentType = new System.Windows.Forms.Label();
		this.PictureBox2 = new System.Windows.Forms.PictureBox();
		this.Label3 = new System.Windows.Forms.Label();
		this.pnlStepList = new System.Windows.Forms.Panel();
		this.lblStatus8 = new System.Windows.Forms.Label();
		this.lblStep8 = new System.Windows.Forms.Label();
		this.lblStatus7 = new System.Windows.Forms.Label();
		this.lblTitle = new System.Windows.Forms.Label();
		this.lblStatus6 = new System.Windows.Forms.Label();
		this.lblStatus5 = new System.Windows.Forms.Label();
		this.lblStatus4 = new System.Windows.Forms.Label();
		this.lblStatus3 = new System.Windows.Forms.Label();
		this.lblStatus2 = new System.Windows.Forms.Label();
		this.lblStatus1 = new System.Windows.Forms.Label();
		this.lblStep7 = new System.Windows.Forms.Label();
		this.PictureBox1 = new System.Windows.Forms.PictureBox();
		this.lblStep6 = new System.Windows.Forms.Label();
		this.lblStep5 = new System.Windows.Forms.Label();
		this.lblStep4 = new System.Windows.Forms.Label();
		this.lblStep3 = new System.Windows.Forms.Label();
		this.lblStep2 = new System.Windows.Forms.Label();
		this.lblStep1 = new System.Windows.Forms.Label();
		this.PictureBox3_DB = new System.Windows.Forms.PictureBox();
		this.lbltitle_DB = new System.Windows.Forms.Label();
		this.lbl21CFR = new System.Windows.Forms.Label();
		this.pnlStepList.SuspendLayout();
		this.SuspendLayout();
		//
		//ImgInit
		//
		this.ImgInit.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
		this.ImgInit.ImageSize = new System.Drawing.Size(16, 15);
		this.ImgInit.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ImgInit.ImageStream");
		this.ImgInit.TransparentColor = System.Drawing.Color.Empty;
		//
		//lblInstrumentType
		//
		this.lblInstrumentType.BackColor = System.Drawing.Color.Transparent;
		this.lblInstrumentType.Font = new System.Drawing.Font("Arial", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblInstrumentType.ForeColor = System.Drawing.Color.MidnightBlue;
		this.lblInstrumentType.Location = new System.Drawing.Point(183, 65);
		this.lblInstrumentType.Name = "lblInstrumentType";
		this.lblInstrumentType.Size = new System.Drawing.Size(456, 27);
		this.lblInstrumentType.TabIndex = 12;
		this.lblInstrumentType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//PictureBox2
		//
		this.PictureBox2.BackgroundImage = (System.Drawing.Image)resources.GetObject("PictureBox2.BackgroundImage");
		this.PictureBox2.Location = new System.Drawing.Point(0, -3);
		this.PictureBox2.Name = "PictureBox2";
		this.PictureBox2.Size = new System.Drawing.Size(146, 408);
		this.PictureBox2.TabIndex = 14;
		this.PictureBox2.TabStop = false;
		//
		//Label3
		//
		this.Label3.BackColor = System.Drawing.Color.Transparent;
		this.Label3.Font = new System.Drawing.Font("Arial", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label3.ForeColor = System.Drawing.Color.MidnightBlue;
		this.Label3.Location = new System.Drawing.Point(183, 39);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(456, 27);
		this.Label3.TabIndex = 13;
		this.Label3.Text = "Atomic Absorption Spectrometer ";
		this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//pnlStepList
		//
		this.pnlStepList.BackColor = System.Drawing.Color.Transparent;
		this.pnlStepList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pnlStepList.Controls.Add(this.lblStatus8);
		this.pnlStepList.Controls.Add(this.lblStep8);
		this.pnlStepList.Controls.Add(this.lblStatus7);
		this.pnlStepList.Controls.Add(this.lblTitle);
		this.pnlStepList.Controls.Add(this.lblStatus6);
		this.pnlStepList.Controls.Add(this.lblStatus5);
		this.pnlStepList.Controls.Add(this.lblStatus4);
		this.pnlStepList.Controls.Add(this.lblStatus3);
		this.pnlStepList.Controls.Add(this.lblStatus2);
		this.pnlStepList.Controls.Add(this.lblStatus1);
		this.pnlStepList.Controls.Add(this.lblStep7);
		this.pnlStepList.Controls.Add(this.PictureBox1);
		this.pnlStepList.Controls.Add(this.lblStep6);
		this.pnlStepList.Controls.Add(this.lblStep5);
		this.pnlStepList.Controls.Add(this.lblStep4);
		this.pnlStepList.Controls.Add(this.lblStep3);
		this.pnlStepList.Controls.Add(this.lblStep2);
		this.pnlStepList.Controls.Add(this.lblStep1);
		this.pnlStepList.Location = new System.Drawing.Point(156, 117);
		this.pnlStepList.Name = "pnlStepList";
		this.pnlStepList.Size = new System.Drawing.Size(510, 266);
		this.pnlStepList.TabIndex = 11;
		//
		//lblStatus8
		//
		this.lblStatus8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblStatus8.Location = new System.Drawing.Point(338, 216);
		this.lblStatus8.Name = "lblStatus8";
		this.lblStatus8.Size = new System.Drawing.Size(150, 24);
		this.lblStatus8.TabIndex = 24;
		this.lblStatus8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblStep8
		//
		this.lblStep8.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblStep8.ForeColor = System.Drawing.Color.MidnightBlue;
		this.lblStep8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblStep8.ImageIndex = 0;
		this.lblStep8.ImageList = this.ImgInit;
		this.lblStep8.Location = new System.Drawing.Point(28, 216);
		this.lblStep8.Name = "lblStep8";
		this.lblStep8.Size = new System.Drawing.Size(302, 24);
		this.lblStep8.TabIndex = 23;
		this.lblStep8.Tag = "7";
		this.lblStep8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblStep8.Visible = false;
		//
		//lblStatus7
		//
		this.lblStatus7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblStatus7.Location = new System.Drawing.Point(338, 192);
		this.lblStatus7.Name = "lblStatus7";
		this.lblStatus7.Size = new System.Drawing.Size(150, 24);
		this.lblStatus7.TabIndex = 22;
		this.lblStatus7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblTitle
		//
		this.lblTitle.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblTitle.ForeColor = System.Drawing.Color.MidnightBlue;
		this.lblTitle.Location = new System.Drawing.Point(52, 6);
		this.lblTitle.Name = "lblTitle";
		this.lblTitle.Size = new System.Drawing.Size(418, 18);
		this.lblTitle.TabIndex = 21;
		this.lblTitle.Text = "Self Diagnosis";
		this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblStatus6
		//
		this.lblStatus6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblStatus6.Location = new System.Drawing.Point(338, 168);
		this.lblStatus6.Name = "lblStatus6";
		this.lblStatus6.Size = new System.Drawing.Size(150, 24);
		this.lblStatus6.TabIndex = 20;
		this.lblStatus6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblStatus5
		//
		this.lblStatus5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblStatus5.Location = new System.Drawing.Point(338, 144);
		this.lblStatus5.Name = "lblStatus5";
		this.lblStatus5.Size = new System.Drawing.Size(150, 24);
		this.lblStatus5.TabIndex = 19;
		this.lblStatus5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblStatus4
		//
		this.lblStatus4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblStatus4.Location = new System.Drawing.Point(338, 120);
		this.lblStatus4.Name = "lblStatus4";
		this.lblStatus4.Size = new System.Drawing.Size(150, 24);
		this.lblStatus4.TabIndex = 18;
		this.lblStatus4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblStatus3
		//
		this.lblStatus3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblStatus3.Location = new System.Drawing.Point(338, 96);
		this.lblStatus3.Name = "lblStatus3";
		this.lblStatus3.Size = new System.Drawing.Size(150, 24);
		this.lblStatus3.TabIndex = 17;
		this.lblStatus3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblStatus2
		//
		this.lblStatus2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblStatus2.Location = new System.Drawing.Point(338, 72);
		this.lblStatus2.Name = "lblStatus2";
		this.lblStatus2.Size = new System.Drawing.Size(150, 24);
		this.lblStatus2.TabIndex = 16;
		this.lblStatus2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblStatus1
		//
		this.lblStatus1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblStatus1.Location = new System.Drawing.Point(338, 48);
		this.lblStatus1.Name = "lblStatus1";
		this.lblStatus1.Size = new System.Drawing.Size(150, 24);
		this.lblStatus1.TabIndex = 15;
		this.lblStatus1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblStep7
		//
		this.lblStep7.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblStep7.ForeColor = System.Drawing.Color.MidnightBlue;
		this.lblStep7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblStep7.ImageIndex = 0;
		this.lblStep7.ImageList = this.ImgInit;
		this.lblStep7.Location = new System.Drawing.Point(28, 192);
		this.lblStep7.Name = "lblStep7";
		this.lblStep7.Size = new System.Drawing.Size(302, 24);
		this.lblStep7.TabIndex = 14;
		this.lblStep7.Tag = "7";
		this.lblStep7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblStep7.Visible = false;
		//
		//PictureBox1
		//
		this.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.PictureBox1.Location = new System.Drawing.Point(-2, 26);
		this.PictureBox1.Name = "PictureBox1";
		this.PictureBox1.Size = new System.Drawing.Size(524, 2);
		this.PictureBox1.TabIndex = 0;
		this.PictureBox1.TabStop = false;
		//
		//lblStep6
		//
		this.lblStep6.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblStep6.ForeColor = System.Drawing.Color.MidnightBlue;
		this.lblStep6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblStep6.ImageIndex = 0;
		this.lblStep6.ImageList = this.ImgInit;
		this.lblStep6.Location = new System.Drawing.Point(28, 168);
		this.lblStep6.Name = "lblStep6";
		this.lblStep6.Size = new System.Drawing.Size(302, 24);
		this.lblStep6.TabIndex = 7;
		this.lblStep6.Tag = "6";
		this.lblStep6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblStep6.Visible = false;
		//
		//lblStep5
		//
		this.lblStep5.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblStep5.ForeColor = System.Drawing.Color.MidnightBlue;
		this.lblStep5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblStep5.ImageIndex = 0;
		this.lblStep5.ImageList = this.ImgInit;
		this.lblStep5.Location = new System.Drawing.Point(28, 144);
		this.lblStep5.Name = "lblStep5";
		this.lblStep5.Size = new System.Drawing.Size(302, 24);
		this.lblStep5.TabIndex = 6;
		this.lblStep5.Tag = "5";
		this.lblStep5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblStep5.Visible = false;
		//
		//lblStep4
		//
		this.lblStep4.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblStep4.ForeColor = System.Drawing.Color.MidnightBlue;
		this.lblStep4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblStep4.ImageIndex = 0;
		this.lblStep4.ImageList = this.ImgInit;
		this.lblStep4.Location = new System.Drawing.Point(28, 120);
		this.lblStep4.Name = "lblStep4";
		this.lblStep4.Size = new System.Drawing.Size(302, 24);
		this.lblStep4.TabIndex = 5;
		this.lblStep4.Tag = "4";
		this.lblStep4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblStep4.Visible = false;
		//
		//lblStep3
		//
		this.lblStep3.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblStep3.ForeColor = System.Drawing.Color.MidnightBlue;
		this.lblStep3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblStep3.ImageIndex = 0;
		this.lblStep3.ImageList = this.ImgInit;
		this.lblStep3.Location = new System.Drawing.Point(28, 96);
		this.lblStep3.Name = "lblStep3";
		this.lblStep3.Size = new System.Drawing.Size(302, 24);
		this.lblStep3.TabIndex = 4;
		this.lblStep3.Tag = "3";
		this.lblStep3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblStep3.Visible = false;
		//
		//lblStep2
		//
		this.lblStep2.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblStep2.ForeColor = System.Drawing.Color.MidnightBlue;
		this.lblStep2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblStep2.ImageIndex = 0;
		this.lblStep2.ImageList = this.ImgInit;
		this.lblStep2.Location = new System.Drawing.Point(28, 72);
		this.lblStep2.Name = "lblStep2";
		this.lblStep2.Size = new System.Drawing.Size(302, 24);
		this.lblStep2.TabIndex = 3;
		this.lblStep2.Tag = "2";
		this.lblStep2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblStep2.Visible = false;
		//
		//lblStep1
		//
		this.lblStep1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblStep1.ForeColor = System.Drawing.Color.MidnightBlue;
		this.lblStep1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblStep1.ImageIndex = 0;
		this.lblStep1.ImageList = this.ImgInit;
		this.lblStep1.Location = new System.Drawing.Point(28, 48);
		this.lblStep1.Name = "lblStep1";
		this.lblStep1.Size = new System.Drawing.Size(302, 24);
		this.lblStep1.TabIndex = 2;
		this.lblStep1.Tag = "1";
		this.lblStep1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblStep1.Visible = false;
		//
		//PictureBox3_DB
		//
		this.PictureBox3_DB.BackgroundImage = (System.Drawing.Image)resources.GetObject("PictureBox3_DB.BackgroundImage");
		this.PictureBox3_DB.Image = (System.Drawing.Image)resources.GetObject("PictureBox3_DB.Image");
		this.PictureBox3_DB.Location = new System.Drawing.Point(0, -3);
		this.PictureBox3_DB.Name = "PictureBox3_DB";
		this.PictureBox3_DB.Size = new System.Drawing.Size(146, 408);
		this.PictureBox3_DB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.PictureBox3_DB.TabIndex = 15;
		this.PictureBox3_DB.TabStop = false;
		this.PictureBox3_DB.Visible = false;
		//
		//lbltitle_DB
		//
		this.lbltitle_DB.BackColor = System.Drawing.Color.Transparent;
		this.lbltitle_DB.Font = new System.Drawing.Font("Arial", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lbltitle_DB.ForeColor = System.Drawing.Color.MidnightBlue;
		this.lbltitle_DB.Location = new System.Drawing.Point(183, 12);
		this.lbltitle_DB.Name = "lbltitle_DB";
		this.lbltitle_DB.Size = new System.Drawing.Size(456, 27);
		this.lbltitle_DB.TabIndex = 16;
		this.lbltitle_DB.Text = "Double Beam";
		this.lbltitle_DB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.lbltitle_DB.Visible = false;
		//
		//lbl21CFR
		//
		this.lbl21CFR.BackColor = System.Drawing.Color.Transparent;
		this.lbl21CFR.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lbl21CFR.ForeColor = System.Drawing.Color.MidnightBlue;
		this.lbl21CFR.Location = new System.Drawing.Point(218, 96);
		this.lbl21CFR.Name = "lbl21CFR";
		this.lbl21CFR.Size = new System.Drawing.Size(386, 16);
		this.lbl21CFR.TabIndex = 17;
		this.lbl21CFR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//frmAASInitialisation
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.BackColor = System.Drawing.Color.White;
		this.ClientSize = new System.Drawing.Size(688, 403);
		this.ControlBox = false;
		this.Controls.Add(this.lbl21CFR);
		this.Controls.Add(this.lbltitle_DB);
		this.Controls.Add(this.Label3);
		this.Controls.Add(this.pnlStepList);
		this.Controls.Add(this.lblInstrumentType);
		this.Controls.Add(this.PictureBox3_DB);
		this.Controls.Add(this.PictureBox2);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MaximizeBox = false;
		this.Name = "frmAASInitialisation";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.pnlStepList.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Form Load and Event Handling functions "

	private void  // ERROR: Handles clauses are not supported in C#
frmAASInitialisation_Load(object sender, System.EventArgs e)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   frmAASInitialisation_Load
		//Description            :   This is called when initialisation form is loaded       
		//Parameters             :   None from user.
		//Time/Date              :   25/9/06
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :praveen
		//--------------------------------------------------------------------------------------
		//'note:
		//'this is called when the form is loaded 
		//'this will perfrom some initialisation step here.
		string strAppVersion;

		strAppVersion = Application.ProductVersion;
		//'get a application product version to string variable.
		strAppVersion = Mid(strAppVersion, 1, 3);

		switch (gstructSettings.AppMode) {
			//'set a instrumentaType as per applwication mode.
			case EnumAppMode.FullVersion_201:
				//--4.85  14.04.09
				if (gstructSettings.NewModelName == false) {
					gstrTitleInstrumentType = "AA 201";
				} else {
					gstrTitleInstrumentType = "AA 301";
				}
			//--4.85  14.04.09


			case EnumAppMode.FullVersion_203:
				//--4.85  14.04.09
				if (gstructSettings.NewModelName == false) {
					gstrTitleInstrumentType = "AA 203";
				} else {
					gstrTitleInstrumentType = "AA 303";
				}
			//--4.85  14.04.09

			case EnumAppMode.FullVersion_203D:
				//--4.85  14.04.09
				if (gstructSettings.NewModelName == false) {
					gstrTitleInstrumentType = "AA 203D";
				} else {
					gstrTitleInstrumentType = "AA 303D";
				}
				//--4.85  14.04.09

				lbltitle_DB.Visible = true;
				//Added by pankaj on 29 Jan 08
				PictureBox3_DB.Visible = true;
				//Added by pankaj on 29 Jan 08
				//Added by pankaj on 29 Jan 08
				PictureBox2.Visible = false;

			case EnumAppMode.DemoMode:

				gstrTitleInstrumentType = "AA DEMO";
		}

		//---commented by Deepak on 25.08.10
		//18.4.2010  by dinesh wagh
		//---------
		//If gstructSettings.Enable21CFR = True Then
		//    lbl21CFR.Text = "21CFR part 11"
		//Else
		//    lblInstrumentType.Location = New Point(lblInstrumentType.Location.X, lblInstrumentType.Location.Y + 10)
		//End If
		//----------

		//---written by Deepak on 25.08.10
		if (gstructSettings.CFR21Installation == true & gstructSettings.EnableIQOQPQ == false) {
			lbl21CFR.Text = "21CFR Part 11";
		} else if (gstructSettings.CFR21Installation == false & gstructSettings.EnableIQOQPQ == true) {
			lbl21CFR.Text = "IQOQPQ";
		} else if (gstructSettings.CFR21Installation == true & gstructSettings.EnableIQOQPQ == true) {
			lbl21CFR.Text = "IQOQPQ / 21CFR Part 11";
		} else {
			lblInstrumentType.Location = new Point(lblInstrumentType.Location.X, lblInstrumentType.Location.Y + 10);
		}
		//---------------------------


		lblInstrumentType.Text = gstrTitleInstrumentType + " Software Version : " + strAppVersion;
		Application.DoEvents();
		//'show the current status
		//'and allow application to perfrom its panding work.

	}

	#End Region

	#Region " Private Functions "

	private void subDisplayIntializationSteps_203()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   subDisplayIntializationSteps_203
		//Description            :   To display initialisation steps of AAS on screen        
		//Parameters             :   None
		//Time/Date              :   25/9/06
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Praveen
		//--------------------------------------------------------------------------------------
		try {
			//'note:
			//'this is used to display a 6 step one by one.

			lblStep1.Visible = true;
			lblStep1.Text = Space(7) + "Initializing 6-Position Turret Mechanism";
			lblStep1.Refresh();

			lblStep2.Visible = true;
			lblStep2.Text = Space(7) + "Initializing Wavelength Drive";
			lblStep2.Refresh();

			lblStep3.Visible = true;
			lblStep3.Text = Space(7) + "Initializing Slit Assembly";
			lblStep3.Refresh();

			lblStep4.Visible = true;
			lblStep4.Text = Space(7) + "Initializing Pneumatic Assembly";
			lblStep4.Refresh();

			lblStep5.Visible = true;
			lblStep5.Text = Space(7) + "Analog Self Test";
			lblStep5.Refresh();

			lblStep6.Visible = true;
			lblStep6.Text = Space(7) + "Setting up Optimum Parameters .... ";
			lblStep6.Refresh();

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
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private void subDisplayIntializationSteps_203D()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   subDisplayIntializationSteps_203D
		//Description            :   To display initialisation steps of AAS on screen        
		//Parameters             :   None
		//Time/Date              :   12-Apr-2007
		//Dependencies           :   
		//Author                 :   Mangesh Shardul
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		try {
			//'note:
			//'this is used to display a initialise step for 203D instrument.
			lblStep1.Visible = true;
			lblStep1.Text = Space(7) + "Initializing 6-Position Turret Mechanism";
			lblStep1.Refresh();

			lblStep2.Visible = true;
			lblStep2.Text = Space(7) + "Initializing Wavelength Drive";
			lblStep2.Refresh();

			lblStep3.Visible = true;
			lblStep3.Text = Space(7) + "Initializing Entrance Slit Assembly";
			lblStep3.Refresh();

			lblStep4.Visible = true;
			lblStep4.Text = Space(7) + "Initializing Exit Slit Assembly";
			lblStep4.Refresh();

			lblStep5.Visible = true;
			lblStep5.Text = Space(7) + "Initializing Pneumatic Assembly";
			lblStep5.Refresh();

			lblStep6.Visible = true;
			lblStep6.Text = Space(7) + "Analog Self Test Sample Beam";
			lblStep6.Refresh();

			lblStep7.Visible = true;
			lblStep7.Text = Space(7) + "Analog Self Test Reference Beam";
			lblStep7.Refresh();

			lblStep8.Visible = true;
			lblStep8.Text = Space(7) + "Setting up Optimum Parameters .... ";
			lblStep8.Refresh();

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
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private void subDisplayIntializationSteps_AAS201()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   subDisplayIntializationSteps_AAS201
		//Description            :   To display initialisation steps of AAS 201 on screen        
		//Parameters             :   None
		//Time/Date              :   10-Apr-2007
		//Dependencies           :   
		//Author                 :   Mangesh Shardul
		//Revision               :
		//Revision by Person     :   Praveen
		//--------------------------------------------------------------------------------------

		try {
			//'note;
			//'this is used to show initialse step for 201
			lblStep1.Visible = false;
			//lblStep1.Text = Space(7) & "Initializing 6-Position Turret Mechanism"
			//lblStep1.Refresh()

			lblStep2.Visible = true;
			lblStep2.Text = Space(7) + "Initializing Wavelength Drive";
			lblStep2.Refresh();

			lblStep3.Visible = true;
			lblStep3.Text = Space(7) + "Initializing Slit Assembly";
			lblStep3.Refresh();

			lblStep4.Visible = true;
			lblStep4.Text = Space(7) + "Initializing Pneumatic Line";
			lblStep4.Refresh();

			lblStep5.Visible = true;
			lblStep5.Text = Space(7) + "Analog Self Test";
			lblStep5.Refresh();

			lblStep6.Visible = true;
			lblStep6.Text = Space(7) + "Setting up Optimum Parameters .... ";
			lblStep6.Refresh();

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
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private bool funcInitialization_AAS203()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name	    :   funcInitialization_AAS203
		//Description	    :   To do the initialization routines  (global.c Initialise)
		//Parameters 	    :   
		//Time/Date  	    :   26/9/2006
		//Dependencies	    :   
		//Author		        :   Rahul B.
		//Revision		    :
		//Revision by Person	:   Deepak B. on 20.11.06 major modifications done   
		//Revision by Person	:   Mangesh S. on 06-Apr-2007 Double Beam Changes
		//--------------------------------------------------------------------------------------
		bool blnFlag = false;
		int intCount;
		double dblPVTvalue;
		int a;

		try {
			gobjClsAAS203.subSetInstrumentBeamType(enumInstrumentBeamType.SingleBeam);
			//'for setting instrument beam type as single beam
			//-----Set All lamp off
			if (!gobjCommProtocol.funcAll_Lamp_Off()) {
			}
			Application.DoEvents();
			//'allow application to perfrom its panding work
			//-----Set PMT to Zero 
			//---For Single Beam (Sample)
			gobjCommProtocol.funcSet_PMT(0.0);
			//'for setting PMT to given value.
			Application.DoEvents();
			//'allow application to perfrom its panding work

			//--- Initialize turret to Home
			if (gobjCommProtocol.gFuncTurret_Home()) {
				//'make a turrert at home position 
				lblStep1.Text = lblStep1.Text;
				lblStatus1.Text = " OK LAMP1";
				lblStatus1.ForeColor = Color.Green;
				lblStatus1.Refresh();
				lblStep1.ImageIndex = 1;
				lblStep1.Refresh();
			//'display a current status
			} else {
				lblStep1.Text = lblStep1.Text;
				lblStatus1.Text = " ERROR";
				lblStatus1.ForeColor = Color.Red;
				lblStatus1.Refresh();
				lblStep1.ImageIndex = 2;
				lblStep1.Refresh();
			}
			Application.DoEvents();
			//'allow application to perfrom its pending work.

			//--- Initialize Wavelength to Home
			if (gobjCommProtocol.gFuncWavelength_Home()) {
				lblStep2.Text = lblStep2.Text;
				lblStatus2.Text = " OK 0.00 nm";
				lblStatus2.ForeColor = Color.Green;
				lblStatus2.Refresh();
				lblStep2.ImageIndex = 1;
				lblStep2.Refresh();
			//'display a status on screen.
			} else {
				//'else display a error on screen.
				lblStep2.Text = lblStep2.Text;
				lblStatus2.Text = " ERROR";
				lblStatus2.ForeColor = Color.Red;
				lblStatus2.Refresh();
				lblStep2.ImageIndex = 2;
				lblStep2.Refresh();
			}
			Application.DoEvents();

			//--- Initialize Slit to Home 
			//---For Single Beam (Sample)
			if (gobjCommProtocol.gFuncSlit_Home()) {
				lblStep3.Text = lblStep3.Text;
				lblStatus3.Text = " OK 2.0 nm";
				lblStatus3.ForeColor = Color.Green;
				lblStatus3.Refresh();
				lblStep3.ImageIndex = 1;
				lblStep3.Refresh();
			//'display a current status on screen 
			} else {
				//'display a error on screen
				lblStep3.Text = lblStep3.Text;
				lblStatus3.Text = " ERROR";
				lblStatus3.ForeColor = Color.Red;
				lblStatus3.Refresh();
				lblStep3.ImageIndex = 2;
				lblStep3.Refresh();
			}
			Application.DoEvents();

			//--- Initialize Pneumatic
			if (gobjCommProtocol.gFuncPneumatics()) {
				lblStep4.Text = lblStep4.Text;
				lblStatus4.Text = " OK";
				lblStatus4.ForeColor = Color.Green;
				lblStatus4.Refresh();
				lblStep4.ImageIndex = 1;
				lblStep4.Refresh();
			//'display current status on screen
			} else {
				//'else display error on screen
				lblStep4.Text = lblStep4.Text;
				lblStatus4.Text = " ERROR";
				lblStatus4.ForeColor = Color.Red;
				lblStatus4.Refresh();
				lblStep4.ImageIndex = 2;
				lblStep4.Refresh();
			}
			Application.DoEvents();
			//'allow application to perfrom its pending work.

			//---Perform Analog self test
			//---For Single Beam (Sample)
			if (gobjCommProtocol.gFuncAnalogSelfTest(gobjInst.Average, dblPVTvalue)) {
				lblStep5.Text = lblStep5.Text;
				lblStatus5.Text = " OK " + Format((gFuncGetmv(dblPVTvalue) / 1000), "0.00") + " V";
				lblStatus5.ForeColor = Color.Green;
				lblStatus5.Refresh();
				lblStep5.ImageIndex = 1;
				lblStep5.Refresh();
			//'display a current status onscreen
			} else {
				//'else show a error on screen.
				lblStep5.Text = lblStep5.Text;
				lblStatus5.Text = " ERROR";
				lblStatus5.ForeColor = Color.Red;
				lblStatus5.Refresh();
				lblStep5.ImageIndex = 2;
				lblStep5.Refresh();
			}
			Application.DoEvents();

			lblStep6.Text = lblStep6.Text;
			lblStatus6.Text = " Wait";
			lblStatus6.ForeColor = Color.Green;
			lblStep6.Refresh();
			lblStatus6.Refresh();
			Application.DoEvents();

			//--- this function is written by deepak b on 16.11.06 for BH
			gobjCommProtocol.funcBH_File_read();
			Application.DoEvents();

			//Read Lamp Position if saved in file and load turret status
			//else search for lamp if present find wavelength home and optimise turret position for that lamp
			if (funcLoadInstStatus() == false) {
				for (intCount = 0; intCount <= 5; intCount++) {
					if (gobjInst.Lamp.LampParametersCollection.item(intCount).ElementName != "") {
						break; // TODO: might not be correct. Was : Exit For
					}
				}
				if (intCount == 6) {
					//OnLampPlace

					//----Added by Mangesh on 11-Apr-2007 

					frmLampPlacements objfrmLampPlacements;
					objfrmLampPlacements = new frmLampPlacements();
					if (objfrmLampPlacements.ShowDialog() == DialogResult.OK) {
						if (!IsNothing(objfrmLampPlacements.mobjInstrumentParameters)) {
							int intLastLastPositionInLampPlacement = objfrmLampPlacements.mobjInstrumentParameters.TurretNumber;
							double dblCurrent = objfrmLampPlacements.mobjInstrumentParameters.LampCurrent;
							//set current to lamp
							gobjCommProtocol.funcSet_Lamp(true, dblCurrent, intLastLastPositionInLampPlacement);
							gobjCommProtocol.funcOptimise_Turret_Position(dblCurrent, intLastLastPositionInLampPlacement);
							//optimise turret position
							Application.DoEvents();
						}
					} else {
						return false;
					}


				} else {
					gobjInst.Lamp_Position = intCount + 1;
					gobjCommProtocol.funcOptimise_Turret_Position(gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).Current, gobjInst.Lamp_Position);
					//OnOptimiseTurPos
					if (gstructSettings.ExeToRun == EnumApplicationMode.AAS) {
						funcSaveInstStatus();
					}
				}
			} else {
				for (intCount = 0; intCount <= 5; intCount++) {
					if (gobjInst.Lamp.LampParametersCollection.item(intCount).ElementName != "") {
						break; // TODO: might not be correct. Was : Exit For
					}
				}
				if (gobjCommProtocol.funcFind_Wavelength_Home()) {
					if (gobjCommProtocol.gFuncTurret_Position(intCount + 1, true)) {
					}

				} else {
				}
				Application.DoEvents();
			}

			//D2 file Read
			gobjInst.D2Pmt = gstructSettings.D2Pmt;

			//if (Read INI for D2 gain) then
			if (gstructSettings.D2Gain == true) {
				if (gobjCommProtocol.funcGain10X_OFF()) {
				} else {
				}
				Application.DoEvents();
			}

			if (gstructSettings.Mesh == true) {
				if (gobjCommProtocol.funcSetMICRO_OFF()) {
				} else {
				}
				Application.DoEvents();
			}

			if (!IsNothing(gobjfrmStatus)) {
				gobjfrmStatus.TurretNumber = gobjInst.Lamp_Position;
				if (gobjInst.Lamp_Position >= 1) {
					gobjfrmStatus.ElementName = gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).ElementName;
				}
				gobjfrmStatus.Refresh();
			}
			gobjfrmStatus.Show();
			Application.DoEvents();

			//gobjfrmStatus.lblElementName.Text = gobjInst.Lamp.LampParametersCollection(0).ElementName()

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
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private bool funcInitialization_AAS203D()
	{
		//-------------------------------------------------------------------------
		//Procedure Name	    :   funcInitialization_AAS203D
		//Description	    :   To do the initialization routines  (global.c Initialise)
		//Parameters 	    :   
		//Time/Date  	    :   26/9/2006
		//Dependencies	    :   
		//Author		        :   Rahul B.
		//Revision		    :
		//Revision by Person	:   Deepak B. on 20.11.06 major modifications done   
		//Revision by Person	:   Mangesh S. on 06-Apr-2007 Double Beam Changes
		//-------------------------------------------------------------------------
		bool blnFlag = false;
		int intCount;
		double dblPVTvalue;
		int a;

		try {
			gobjClsAAS203.subSetInstrumentBeamType(enumInstrumentBeamType.DoubleBeam, false);

			//-----Set All lamp off
			gobjCommProtocol.funcAll_Lamp_Off();
			Application.DoEvents();

			//-----Set PMT to Zero 
			//
			gobjCommProtocol.funcSet_PMT(0.0);

			if (gintInstrumentBeamType == enumInstrumentBeamType.DoubleBeam) {
				//---For Double Beam (Reference)
				if (!gobjCommProtocol.funcSet_PMTReferenceBeam(0.0)) {
					gobjMessageAdapter.ShowMessage(constPMTRange);
					Application.DoEvents();
				}
			}
			Application.DoEvents();

			//--- Initialize turret to Home
			if (gobjCommProtocol.gFuncTurret_Home()) {
				lblStep1.Text = lblStep1.Text;
				lblStatus1.Text = " OK LAMP1";
				lblStatus1.ForeColor = Color.Green;
				lblStatus1.Refresh();
				lblStep1.ImageIndex = 1;
				lblStep1.Refresh();
			} else {
				lblStep1.Text = lblStep1.Text;
				lblStatus1.Text = " ERROR";
				lblStatus1.ForeColor = Color.Red;
				lblStatus1.Refresh();
				lblStep1.ImageIndex = 2;
				lblStep1.Refresh();
			}
			Application.DoEvents();

			//--- Initialize Wavelength to Home
			if (gobjCommProtocol.gFuncWavelength_Home()) {
				lblStep2.Text = lblStep2.Text;
				lblStatus2.Text = " OK 0.00 nm";
				lblStatus2.ForeColor = Color.Green;
				lblStatus2.Refresh();
				lblStep2.ImageIndex = 1;
				lblStep2.Refresh();
			} else {
				lblStep2.Text = lblStep2.Text;
				lblStatus2.Text = " ERROR";
				lblStatus2.ForeColor = Color.Red;
				lblStatus2.Refresh();
				lblStep2.ImageIndex = 2;
				lblStep2.Refresh();
			}
			Application.DoEvents();

			//--- Initialize Slit to Home 
			// 
			if (gobjCommProtocol.gFuncSlit_Home()) {
				lblStep3.Text = lblStep3.Text;
				lblStatus3.Text = " OK 2.0 nm";
				lblStatus3.ForeColor = Color.Green;
				lblStatus3.Refresh();
				lblStep3.ImageIndex = 1;
				lblStep3.Refresh();
			} else {
				lblStep3.Text = lblStep3.Text;
				lblStatus3.Text = " ERROR ";
				lblStatus3.ForeColor = Color.Red;
				lblStatus3.Refresh();
				lblStep3.ImageIndex = 2;
				lblStep3.Refresh();
			}
			Application.DoEvents();

			//---For Double Beam (Reference)
			if (gintInstrumentBeamType == enumInstrumentBeamType.DoubleBeam) {
				if (!gobjCommProtocol.funcExitSlit_Home()) {
					Application.DoEvents();
					lblStep4.Text = lblStep4.Text;
					lblStatus4.Text = " ERROR ";
					lblStatus4.ForeColor = Color.Red;
					lblStatus4.Refresh();
					lblStep4.ImageIndex = 2;
					lblStep4.Refresh();
				} else {
					lblStep4.Text = lblStep4.Text;
					lblStatus4.Text = " OK 2.0 nm";
					lblStatus4.ForeColor = Color.Green;
					lblStatus4.Refresh();
					lblStep4.ImageIndex = 1;
					lblStep3.Refresh();
				}
			}
			Application.DoEvents();
			//--- Initialize Pneumatic
			if (gobjCommProtocol.gFuncPneumatics()) {
				lblStep5.Text = lblStep5.Text;
				lblStatus5.Text = " OK";
				lblStatus5.ForeColor = Color.Green;
				lblStatus5.Refresh();
				lblStep5.ImageIndex = 1;
				lblStep5.Refresh();
			} else {
				lblStep5.Text = lblStep5.Text;
				lblStatus5.Text = " ERROR";
				lblStatus5.ForeColor = Color.Red;
				lblStatus5.Refresh();
				lblStep5.ImageIndex = 2;
				lblStep5.Refresh();
			}
			Application.DoEvents();

			//---Perform Analog self test
			//---For Single Beam (Sample)
			if (gobjCommProtocol.gFuncAnalogSelfTest(gobjInst.Average, dblPVTvalue)) {
				lblStep6.Text = lblStep6.Text;
				lblStatus6.Text = " OK " + Format((gFuncGetmv(dblPVTvalue) / 1000), "0.00") + " V";
				lblStatus6.ForeColor = Color.Green;
				lblStatus6.Refresh();
				lblStep6.ImageIndex = 1;
				lblStep6.Refresh();
			} else {
				lblStep6.Text = lblStep6.Text;
				lblStatus6.Text = " ERROR";
				lblStatus6.ForeColor = Color.Red;
				lblStatus6.Refresh();
				lblStep6.ImageIndex = 2;
				lblStep6.Refresh();
			}
			Application.DoEvents();

			//---Perform Analog self test
			//---For 203D (Reference Beam)

			if (gobjCommProtocol.gFuncAnalogSelfTest_ReferenceBeam(gobjInst.Average, dblPVTvalue)) {
				lblStep7.Text = lblStep7.Text;
				lblStatus7.Text = " OK " + Format((gFuncGetmv(dblPVTvalue) / 1000), "0.00") + " V";
				lblStatus7.ForeColor = Color.Green;
				lblStatus7.Refresh();
				lblStep7.ImageIndex = 1;
				lblStep7.Refresh();
			} else {
				lblStep7.Text = lblStep7.Text;
				lblStatus7.Text = " ERROR";
				lblStatus7.ForeColor = Color.Red;
				lblStatus7.Refresh();
				lblStep7.ImageIndex = 2;
				lblStep7.Refresh();
			}
			Application.DoEvents();

			lblStep8.Text = lblStep8.Text;
			lblStatus8.Text = " Wait";
			lblStatus8.ForeColor = Color.Green;
			lblStep8.Refresh();
			lblStatus8.Refresh();
			Application.DoEvents();

			//--- this function is written by deepak b on 16.11.06 for BH
			gobjCommProtocol.funcBH_File_read();
			Application.DoEvents();

			//Read Lamp Position if saved in file and load turret status
			//else search for lamp if present find wavelength home and optimise turret position for that lamp
			if (funcLoadInstStatus() == false) {
				for (intCount = 0; intCount <= 5; intCount++) {
					if (gobjInst.Lamp.LampParametersCollection.item(intCount).ElementName != "") {
						break; // TODO: might not be correct. Was : Exit For
					}
				}

				if (intCount == 6) {
					//OnLampPlace
					//if lamp not present in global object then ask for lamp at initialization
					//----Added by Mangesh on 11-Apr-2007 

					frmLampPlacements objfrmLampPlacements;
					objfrmLampPlacements = new frmLampPlacements();
					if (objfrmLampPlacements.ShowDialog() == DialogResult.OK) {
						if (!IsNothing(objfrmLampPlacements.mobjInstrumentParameters)) {
							int intLastLastPositionInLampPlacement = objfrmLampPlacements.mobjInstrumentParameters.TurretNumber;
							double dblCurrent = objfrmLampPlacements.mobjInstrumentParameters.LampCurrent;
							gobjCommProtocol.funcSet_Lamp(true, dblCurrent, intLastLastPositionInLampPlacement);
							gobjCommProtocol.funcOptimise_Turret_Position(dblCurrent, intLastLastPositionInLampPlacement);
							Application.DoEvents();
						}
					} else {
						return false;
					}
				//****************************************************************************************************************************
				} else {
					gobjInst.Lamp_Position = intCount + 1;
					gobjCommProtocol.funcOptimise_Turret_Position(gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).Current, gobjInst.Lamp_Position);
					//OnOptimiseTurPos
					if (gstructSettings.ExeToRun == EnumApplicationMode.AAS) {
						funcSaveInstStatus();
					}
				}
			} else {
				for (intCount = 0; intCount <= 5; intCount++) {
					if (gobjInst.Lamp.LampParametersCollection.item(intCount).ElementName != "") {
						break; // TODO: might not be correct. Was : Exit For
					}
				}
				if (gobjCommProtocol.funcFind_Wavelength_Home()) {
					if (gobjCommProtocol.gFuncTurret_Position(intCount + 1, true)) {
					}

				} else {
				}
				Application.DoEvents();
			}

			//D2 file Read
			gobjInst.D2Pmt = gstructSettings.D2Pmt;

			//if (Read INI for D2 gain) then
			if (gstructSettings.D2Gain == true) {
				if (gobjCommProtocol.funcGain10X_OFF()) {
				} else {
				}
				Application.DoEvents();
			}

			if (gstructSettings.Mesh == true) {
				if (gobjCommProtocol.funcSetMICRO_OFF()) {
				} else {
				}
				Application.DoEvents();
			}

			//---Set Beam Type to Instrument
			//Call gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.SELFTEST)

			if (!IsNothing(gobjfrmStatus)) {
				gobjfrmStatus.TurretNumber = gobjInst.Lamp_Position;
				if (gobjInst.Lamp_Position >= 1) {
					gobjfrmStatus.ElementName = gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).ElementName;
				}
				gobjfrmStatus.Refresh();
			}
			gobjfrmStatus.Show();
			Application.DoEvents();

			//---changed on 20.03.08 to make beam type selection permanent
			int intBeamType;
			intBeamType = (int)gFuncGetFromINI(SECTION_SYSTEMPARAMETERS, KEY_INSTRUMENT_BEAMTYPE, "0", INI_SETTINGS_PATH);
			if (intBeamType == 0) {
				gintInstrumentBeamType = enumInstrumentBeamType.SingleBeam;
			} else if (intBeamType == 2) {
				gintInstrumentBeamType = enumInstrumentBeamType.DoubleBeam;
			}
			//-----------------------------------

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
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private bool funcInitialization_AAS201()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name	    :   funcInitialization_AAS201
		//Description	    :   To do the initialization routines  (global.c Initialise)
		//Parameters 	    :   
		//Time/Date  	    :   26/9/2006
		//Dependencies	    :   
		//Author		        :   Rahul B.
		//Revision		    :
		//Revision by Person	:   Deepak B. on 20.11.06 major modifications done   
		//Revision by Person	:   Mangesh S. on 10-Apr-2007 AA201 Changes
		//--------------------------------------------------------------------------------------
		bool blnFlag = false;
		int intCount;
		double dblPVTvalue;
		int a;

		try {
			gobjClsAAS203.subSetInstrumentBeamType(enumInstrumentBeamType.SingleBeam);

			//-----Set All lamp off
			if (!gobjCommProtocol.funcAll_Lamp_Off()) {
			}
			Application.DoEvents();

			//-----Set PMT to Zero 
			//---For Single Beam (Sample)
			gobjCommProtocol.funcSet_PMT(0.0);
			Application.DoEvents();

			//--- Initialize Wavelength to Home
			if (gobjCommProtocol.gFuncWavelength_Home()) {
				lblStep2.Text = lblStep2.Text;
				lblStatus2.Text = " OK 0.00 nm";
				lblStatus2.ForeColor = Color.Green;
				lblStatus2.Refresh();
				lblStep2.ImageIndex = 1;
				lblStep2.Refresh();
			} else {
				lblStep2.Text = lblStep2.Text;
				lblStatus2.Text = " ERROR";
				lblStatus2.ForeColor = Color.Red;
				lblStatus2.Refresh();
				lblStep2.ImageIndex = 2;
				lblStep2.Refresh();
			}
			Application.DoEvents();

			//--- Initialize Slit to Home 
			if (gobjCommProtocol.gFuncSlit_Home()) {
				lblStep3.Text = lblStep3.Text;
				lblStatus3.Text = " OK 2.0 nm";
				lblStatus3.ForeColor = Color.Green;
				lblStatus3.Refresh();
				lblStep3.ImageIndex = 1;
				lblStep3.Refresh();
			} else {
				lblStep3.Text = lblStep3.Text;
				lblStatus3.Text = " ERROR";
				lblStatus3.ForeColor = Color.Red;
				lblStatus3.Refresh();
				lblStep3.ImageIndex = 2;
				lblStep3.Refresh();
			}
			Application.DoEvents();

			//--- Initialize Pneumatic
			if (gobjCommProtocol.gFuncPneumatics()) {
				lblStep4.Text = lblStep4.Text;
				lblStatus4.Text = " OK";
				lblStatus4.ForeColor = Color.Green;
				lblStatus4.Refresh();
				lblStep4.ImageIndex = 1;
				lblStep4.Refresh();
			} else {
				lblStep4.Text = lblStep4.Text;
				lblStatus4.Text = " ERROR";
				lblStatus4.ForeColor = Color.Red;
				lblStatus4.Refresh();
				lblStep4.ImageIndex = 2;
				lblStep4.Refresh();
			}
			Application.DoEvents();

			//---Perform Analog self test for AAS 201
			if (gobjCommProtocol.gFuncAnalogSelfTest_AA201(gobjInst.Average, dblPVTvalue)) {
				lblStep5.Text = lblStep5.Text;
				lblStatus5.Text = " OK " + Format((gFuncGetmv(dblPVTvalue) / 1000), "0.00") + " V";
				lblStatus5.ForeColor = Color.Green;
				lblStatus5.Refresh();
				lblStep5.ImageIndex = 1;
				lblStep5.Refresh();
			} else {
				lblStep5.Text = lblStep5.Text;
				lblStatus5.Text = " ERROR";
				lblStatus5.ForeColor = Color.Red;
				lblStatus5.Refresh();
				lblStep5.ImageIndex = 2;
				lblStep5.Refresh();
			}
			Application.DoEvents();

			lblStep6.Text = lblStep6.Text;
			lblStatus6.Text = " Wait ... ";
			lblStatus6.ForeColor = Color.Green;
			lblStep6.Refresh();
			lblStatus6.Refresh();
			Application.DoEvents();

			//--- this function is written by deepak b on 16.11.06 for BH
			gobjCommProtocol.funcBH_File_read();
			Application.DoEvents();

			//Read Lamp Position if saved in file and load turret status
			//else search for lamp if present find wavelength home and optimise turret position for that lamp

			if (!funcLoadInstStatus()) {
				for (intCount = 0; intCount <= 1; intCount++) {
					if (gobjInst.Lamp.LampParametersCollection.item(intCount).ElementName != "") {
						break; // TODO: might not be correct. Was : Exit For
					}
				}
				if (intCount == 2) {
					//OnLampPlace
					// if lamp is not found ask user for lamp
					frmLampPlacements_201 objfrmLampPlacements201;
					objfrmLampPlacements201 = new frmLampPlacements_201();
					if (objfrmLampPlacements201.ShowDialog() == DialogResult.OK) {
						if (!IsNothing(objfrmLampPlacements201.mobjInstrumentParameters)) {
							int intLastLastPositionInLampPlacement = objfrmLampPlacements201.mobjInstrumentParameters.TurretNumber;
							double dblCurrent = objfrmLampPlacements201.mobjInstrumentParameters.LampCurrent;
							//set current to the lamp
							gobjCommProtocol.funcSet_Lamp(true, dblCurrent, intLastLastPositionInLampPlacement);
							gobjCommProtocol.funcOptimise_Turret_Position(dblCurrent, intLastLastPositionInLampPlacement);

							if (gobjMessageAdapter.ShowMessage(constManualLampOptimisation)) {
								Application.DoEvents();
								gobjClsAAS203.AbsorbanceScan();
							}
							Application.DoEvents();

						}
					} else {
						return false;
					}
				} else {
					gobjInst.Lamp_Position = intCount + 1;
					gobjCommProtocol.funcOptimise_Turret_Position(gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).Current, gobjInst.Lamp_Position);
					//OnOptimiseTurPos
					if (gstructSettings.ExeToRun == EnumApplicationMode.AAS) {
						funcSaveInstStatus();
					}
				}
			} else {
				for (intCount = 0; intCount <= 5; intCount++) {
					if (gobjInst.Lamp.LampParametersCollection.item(intCount).ElementName != "") {
						break; // TODO: might not be correct. Was : Exit For
					}
				}
				if (gobjCommProtocol.funcFind_Wavelength_Home()) {
					if (gobjCommProtocol.gFuncTurret_Position(intCount + 1, true)) {
					}

				} else {
				}
				Application.DoEvents();
			}

			//D2 file Read
			gobjInst.D2Pmt = gstructSettings.D2Pmt;

			//if (Read INI for D2 gain) then
			if (gstructSettings.D2Gain == true) {
				gobjCommProtocol.funcGain10X_OFF();
				Application.DoEvents();
			}

			if (gstructSettings.Mesh == true) {
				gobjCommProtocol.funcSetMICRO_OFF();
				Application.DoEvents();
			}

			if (!IsNothing(gobjfrmStatus)) {
				gobjfrmStatus.TurretNumber = gobjInst.Lamp_Position;
				if (gobjInst.Lamp_Position >= 1) {
					gobjfrmStatus.ElementName = gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).ElementName;
				}
				gobjfrmStatus.Refresh();
			}
			gobjfrmStatus.Show();
			Application.DoEvents();

			//gobjfrmStatus.lblElementName.Text = gobjInst.Lamp.LampParametersCollection(0).ElementName()

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
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	#End Region

	#Region " Public Functions "

	public bool funcInstrumentInitialization()
	{
		//-----------------------------------------------------------------
		//Procedure Name         :   funcInstrumentInitialization
		//Description            :   To display initialisation procedure of AAS on screen        
		//Parameters             :   None
		//Time/Date              :   25/9/06
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Praveen
		//-----------------------------------------------------------------
		string strInstrument_Type;
		bool blnFlag;

		try {
			this.Refresh();

			switch (gstructSettings.AppMode) {
				//'this will called a initialisation function as per application mode.
				case EnumAppMode.FullVersion_201:
					//'for 201

					subDisplayIntializationSteps_AAS201();
				case EnumAppMode.FullVersion_203:
					//'for 203

					subDisplayIntializationSteps_203();
				case EnumAppMode.FullVersion_203D:
					//'for 203D 

					subDisplayIntializationSteps_203D();
			}

			this.Refresh();
			Application.DoEvents();
			//allow application to perfrom its panding work.

			//--- Start the Initialization of the system
			blnFlag = gobjCommProtocol.funcInitInstrument();

			if (blnFlag) {
				//'set a initialise flag as per application mode.
				switch (gstructSettings.AppMode) {
					case EnumAppMode.FullVersion_203:
						//---Initialise to the AAS 203

						blnFlag = funcInitialization_AAS203();
					case EnumAppMode.FullVersion_203D:
						//---Initialise to the AAS 203D (Double Beam) 

						blnFlag = funcInitialization_AAS203D();
					case EnumAppMode.FullVersion_201:
						//---Initialise to the AAS 202 

						blnFlag = funcInitialization_AAS201();
				}

			}

			return blnFlag;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			return false;
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
