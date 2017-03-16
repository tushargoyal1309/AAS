using AAS203.Common;
using AAS203Library.Method;
using AAS203Library.Instrument;

public class frmLampPlacements : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmLampPlacements()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
		mblnIsOperated = false;
	}

	public frmLampPlacements(int intSelectedTurretNum, int intOpenMethodMode)
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call

		subInit(intSelectedTurretNum, intOpenMethodMode);

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
	internal CodeIntellects.Office2003Controls.Office2003Header HeaderTop;
	internal System.Windows.Forms.Label Label1;
	internal System.Windows.Forms.Label lblTurretNo;
	internal System.Windows.Forms.Label lblElementName;
	internal System.Windows.Forms.Label lbl1;
	internal System.Windows.Forms.Label lbl2;
	internal System.Windows.Forms.Label lbl3;
	internal System.Windows.Forms.Label lbl4;
	internal System.Windows.Forms.Label lbl5;
	internal System.Windows.Forms.Label lbl6;
	internal System.Windows.Forms.TextBox txt1;
	internal System.Windows.Forms.TextBox txt3;
	internal System.Windows.Forms.TextBox txt4;
	internal System.Windows.Forms.TextBox txt5;
	internal System.Windows.Forms.TextBox txt6;
	internal System.Windows.Forms.TextBox txt2;
	internal NETXP.Controls.XPButton btnInsertLamp;
	internal NETXP.Controls.XPButton btnRemoveLamp;
	internal NETXP.Controls.XPButton btnHelp;
	internal NETXP.Controls.XPButton btnOk;
	internal NETXP.Controls.XPButton btnCancel;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmLampPlacements));
		this.CustomPanelMain = new GradientPanel.CustomPanel();
		this.btnHelp = new NETXP.Controls.XPButton();
		this.btnOk = new NETXP.Controls.XPButton();
		this.btnCancel = new NETXP.Controls.XPButton();
		this.btnRemoveLamp = new NETXP.Controls.XPButton();
		this.btnInsertLamp = new NETXP.Controls.XPButton();
		this.txt6 = new System.Windows.Forms.TextBox();
		this.txt5 = new System.Windows.Forms.TextBox();
		this.txt4 = new System.Windows.Forms.TextBox();
		this.txt3 = new System.Windows.Forms.TextBox();
		this.txt2 = new System.Windows.Forms.TextBox();
		this.txt1 = new System.Windows.Forms.TextBox();
		this.lbl6 = new System.Windows.Forms.Label();
		this.lbl5 = new System.Windows.Forms.Label();
		this.lbl4 = new System.Windows.Forms.Label();
		this.lbl3 = new System.Windows.Forms.Label();
		this.lbl2 = new System.Windows.Forms.Label();
		this.lbl1 = new System.Windows.Forms.Label();
		this.lblElementName = new System.Windows.Forms.Label();
		this.lblTurretNo = new System.Windows.Forms.Label();
		this.Label1 = new System.Windows.Forms.Label();
		this.HeaderTop = new CodeIntellects.Office2003Controls.Office2003Header();
		this.CustomPanelMain.SuspendLayout();
		this.SuspendLayout();
		//
		//CustomPanelMain
		//
		this.CustomPanelMain.BackColor = System.Drawing.Color.Transparent;
		this.CustomPanelMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.CustomPanelMain.Controls.Add(this.btnHelp);
		this.CustomPanelMain.Controls.Add(this.btnOk);
		this.CustomPanelMain.Controls.Add(this.btnCancel);
		this.CustomPanelMain.Controls.Add(this.btnRemoveLamp);
		this.CustomPanelMain.Controls.Add(this.btnInsertLamp);
		this.CustomPanelMain.Controls.Add(this.txt6);
		this.CustomPanelMain.Controls.Add(this.txt5);
		this.CustomPanelMain.Controls.Add(this.txt4);
		this.CustomPanelMain.Controls.Add(this.txt3);
		this.CustomPanelMain.Controls.Add(this.txt2);
		this.CustomPanelMain.Controls.Add(this.txt1);
		this.CustomPanelMain.Controls.Add(this.lbl6);
		this.CustomPanelMain.Controls.Add(this.lbl5);
		this.CustomPanelMain.Controls.Add(this.lbl4);
		this.CustomPanelMain.Controls.Add(this.lbl3);
		this.CustomPanelMain.Controls.Add(this.lbl2);
		this.CustomPanelMain.Controls.Add(this.lbl1);
		this.CustomPanelMain.Controls.Add(this.lblElementName);
		this.CustomPanelMain.Controls.Add(this.lblTurretNo);
		this.CustomPanelMain.Controls.Add(this.Label1);
		this.CustomPanelMain.Controls.Add(this.HeaderTop);
		this.CustomPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanelMain.Location = new System.Drawing.Point(0, 0);
		this.CustomPanelMain.Name = "CustomPanelMain";
		this.CustomPanelMain.Size = new System.Drawing.Size(338, 327);
		this.CustomPanelMain.TabIndex = 0;
		//
		//btnHelp
		//
		this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnHelp.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnHelp.Image = (System.Drawing.Image)resources.GetObject("btnHelp.Image");
		this.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnHelp.Location = new System.Drawing.Point(240, 216);
		this.btnHelp.Name = "btnHelp";
		this.btnHelp.Size = new System.Drawing.Size(86, 34);
		this.btnHelp.TabIndex = 8;
		this.btnHelp.Text = "&Help";
		this.btnHelp.Visible = false;
		//
		//btnOk
		//
		this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOk.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnOk.Image = (System.Drawing.Image)resources.GetObject("btnOk.Image");
		this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOk.Location = new System.Drawing.Point(240, 66);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(86, 34);
		this.btnOk.TabIndex = 6;
		this.btnOk.Text = "&OK";
		//
		//btnCancel
		//
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCancel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnCancel.Image = (System.Drawing.Image)resources.GetObject("btnCancel.Image");
		this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCancel.Location = new System.Drawing.Point(240, 141);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(86, 34);
		this.btnCancel.TabIndex = 7;
		this.btnCancel.Text = "&Cancel";
		this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//btnRemoveLamp
		//
		this.btnRemoveLamp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnRemoveLamp.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnRemoveLamp.Image = (System.Drawing.Image)resources.GetObject("btnRemoveLamp.Image");
		this.btnRemoveLamp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnRemoveLamp.Location = new System.Drawing.Point(171, 280);
		this.btnRemoveLamp.Name = "btnRemoveLamp";
		this.btnRemoveLamp.Size = new System.Drawing.Size(128, 38);
		this.btnRemoveLamp.TabIndex = 10;
		this.btnRemoveLamp.Text = "&Remove Lamp";
		this.btnRemoveLamp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//btnInsertLamp
		//
		this.btnInsertLamp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnInsertLamp.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnInsertLamp.Image = (System.Drawing.Image)resources.GetObject("btnInsertLamp.Image");
		this.btnInsertLamp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnInsertLamp.Location = new System.Drawing.Point(27, 280);
		this.btnInsertLamp.Name = "btnInsertLamp";
		this.btnInsertLamp.Size = new System.Drawing.Size(128, 38);
		this.btnInsertLamp.TabIndex = 9;
		this.btnInsertLamp.Text = "&Insert Lamp";
		this.btnInsertLamp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//txt6
		//
		this.txt6.BackColor = System.Drawing.Color.White;
		this.txt6.Location = new System.Drawing.Point(96, 238);
		this.txt6.Name = "txt6";
		this.txt6.ReadOnly = true;
		this.txt6.Size = new System.Drawing.Size(89, 20);
		this.txt6.TabIndex = 5;
		this.txt6.Tag = "6";
		this.txt6.Text = "";
		this.txt6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		//
		//txt5
		//
		this.txt5.BackColor = System.Drawing.Color.White;
		this.txt5.Location = new System.Drawing.Point(96, 206);
		this.txt5.Name = "txt5";
		this.txt5.ReadOnly = true;
		this.txt5.Size = new System.Drawing.Size(89, 20);
		this.txt5.TabIndex = 4;
		this.txt5.Tag = "5";
		this.txt5.Text = "";
		this.txt5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		//
		//txt4
		//
		this.txt4.BackColor = System.Drawing.Color.White;
		this.txt4.Location = new System.Drawing.Point(96, 174);
		this.txt4.Name = "txt4";
		this.txt4.ReadOnly = true;
		this.txt4.Size = new System.Drawing.Size(89, 20);
		this.txt4.TabIndex = 3;
		this.txt4.Tag = "4";
		this.txt4.Text = "";
		this.txt4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		//
		//txt3
		//
		this.txt3.BackColor = System.Drawing.Color.White;
		this.txt3.Location = new System.Drawing.Point(96, 142);
		this.txt3.Name = "txt3";
		this.txt3.ReadOnly = true;
		this.txt3.Size = new System.Drawing.Size(89, 20);
		this.txt3.TabIndex = 2;
		this.txt3.Tag = "3";
		this.txt3.Text = "";
		this.txt3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		//
		//txt2
		//
		this.txt2.BackColor = System.Drawing.Color.White;
		this.txt2.Location = new System.Drawing.Point(96, 110);
		this.txt2.Name = "txt2";
		this.txt2.ReadOnly = true;
		this.txt2.Size = new System.Drawing.Size(89, 20);
		this.txt2.TabIndex = 1;
		this.txt2.Tag = "2";
		this.txt2.Text = "";
		this.txt2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		//
		//txt1
		//
		this.txt1.BackColor = System.Drawing.Color.White;
		this.txt1.Location = new System.Drawing.Point(96, 78);
		this.txt1.Name = "txt1";
		this.txt1.ReadOnly = true;
		this.txt1.Size = new System.Drawing.Size(89, 20);
		this.txt1.TabIndex = 0;
		this.txt1.Tag = "1";
		this.txt1.Text = "";
		this.txt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		//
		//lbl6
		//
		this.lbl6.Location = new System.Drawing.Point(35, 234);
		this.lbl6.Name = "lbl6";
		this.lbl6.Size = new System.Drawing.Size(36, 20);
		this.lbl6.TabIndex = 9;
		this.lbl6.Text = "6";
		this.lbl6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lbl5
		//
		this.lbl5.Location = new System.Drawing.Point(35, 202);
		this.lbl5.Name = "lbl5";
		this.lbl5.Size = new System.Drawing.Size(36, 20);
		this.lbl5.TabIndex = 8;
		this.lbl5.Text = "5";
		this.lbl5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lbl4
		//
		this.lbl4.Location = new System.Drawing.Point(35, 170);
		this.lbl4.Name = "lbl4";
		this.lbl4.Size = new System.Drawing.Size(36, 20);
		this.lbl4.TabIndex = 7;
		this.lbl4.Text = "4";
		this.lbl4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lbl3
		//
		this.lbl3.Location = new System.Drawing.Point(35, 138);
		this.lbl3.Name = "lbl3";
		this.lbl3.Size = new System.Drawing.Size(36, 20);
		this.lbl3.TabIndex = 6;
		this.lbl3.Text = "3";
		this.lbl3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lbl2
		//
		this.lbl2.Location = new System.Drawing.Point(35, 106);
		this.lbl2.Name = "lbl2";
		this.lbl2.Size = new System.Drawing.Size(36, 20);
		this.lbl2.TabIndex = 5;
		this.lbl2.Text = "2";
		this.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lbl1
		//
		this.lbl1.Location = new System.Drawing.Point(35, 74);
		this.lbl1.Name = "lbl1";
		this.lbl1.Size = new System.Drawing.Size(36, 20);
		this.lbl1.TabIndex = 4;
		this.lbl1.Text = "1";
		this.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblElementName
		//
		this.lblElementName.Location = new System.Drawing.Point(95, 38);
		this.lblElementName.Name = "lblElementName";
		this.lblElementName.Size = new System.Drawing.Size(89, 23);
		this.lblElementName.TabIndex = 3;
		this.lblElementName.Text = "Element Name";
		this.lblElementName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblTurretNo
		//
		this.lblTurretNo.Location = new System.Drawing.Point(22, 38);
		this.lblTurretNo.Name = "lblTurretNo";
		this.lblTurretNo.Size = new System.Drawing.Size(64, 23);
		this.lblTurretNo.TabIndex = 2;
		this.lblTurretNo.Text = "Turret No.";
		this.lblTurretNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//Label1
		//
		this.Label1.BackColor = System.Drawing.Color.Transparent;
		this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.Label1.Location = new System.Drawing.Point(15, 32);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(211, 236);
		this.Label1.TabIndex = 1;
		//
		//HeaderTop
		//
		this.HeaderTop.BackColor = System.Drawing.SystemColors.Control;
		this.HeaderTop.Dock = System.Windows.Forms.DockStyle.Top;
		this.HeaderTop.Location = new System.Drawing.Point(0, 0);
		this.HeaderTop.Name = "HeaderTop";
		this.HeaderTop.Size = new System.Drawing.Size(338, 20);
		this.HeaderTop.TabIndex = 0;
		this.HeaderTop.TitleFont = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.HeaderTop.TitleText = "Insert/Remove Lamp";
		//
		//frmLampPlacements
		//
		this.AcceptButton = this.btnOk;
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.CancelButton = this.btnCancel;
		this.ClientSize = new System.Drawing.Size(338, 327);
		this.Controls.Add(this.CustomPanelMain);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmLampPlacements";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Lamp Placements";
		this.CustomPanelMain.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Public Variables, Events, Constants "

	public clsInstrumentParameters mobjInstrumentParameters;
	public event  LampReplaced;
	public event  LampRemoved;

	#End Region

	#Region " Private Class Member Variables "

	private int mintTurretPosition = 0;
	private int mintLatestTurretPosition = 0;
	private int mintOpenMethodMode = 0;
	public bool mblnIsOperated = false;

	private bool mblnIsSetTurret_Home;
	#End Region

	#Region " Private Constants "

	private const  ConstFormLoad = "-Method-InstrumentParameters-LampPlacements";

	private const  ConstParentFormLoad = "-Method-InstrumentParameters";
	#End Region

	#Region " Private Properties "

	public int TurretPosition {
		get { return mintTurretPosition; }
		set { mintTurretPosition = Value; }
	}

	private EnumMethodMode OpenMethodMode {
		get { return mintOpenMethodMode; }
		set { mintOpenMethodMode = Value; }
	}

	#End Region

	#Region " Form Events "

	private void  // ERROR: Handles clauses are not supported in C#
frmLampPlacements_Load(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmLampPlacements_Load
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To Add event handlers and to initialize the form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 05.10.06
		// Revisions             : praveen
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		//'note:

		try {
			//---to load the form by adding handlers and by initializing
			AddHandlers();
			//'for adding a event to a control.
			funcInitialise();
			//'do some initialisation.
			btnInsertLamp.Focus();

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
			objWait.Dispose();
			//---------------------------------------------------------
		}
	}

	#End Region

	#Region " Functions "

	private void AddHandlers()
	{
		//=====================================================================
		// Procedure Name        : AddHandlers
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To Add event handlers 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();

		try {
			//to add handlers
			txt1.Enter += GetTurretPosition;
			txt2.Enter += GetTurretPosition;
			txt3.Enter += GetTurretPosition;
			txt4.Enter += GetTurretPosition;
			txt5.Enter += GetTurretPosition;
			txt6.Enter += GetTurretPosition;

			btnInsertLamp.Click += btnInsertLamp_Click;
			btnRemoveLamp.Click += btnRemoveLamp_Click;
			btnOk.Click += btnOk_Click;
			btnCancel.Click += btnCancel_Click;

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

	private void btnInsertLamp_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnInsertLamp_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To insert lamp 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak, Rahul
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		//Steps:
		//Open CookBook View to select the element
		//After selection of element perform necessary instrument operations
		//Get the object of clsInstrumentParameters
		//Add this object to the object collection
		CWaitCursor objWait = new CWaitCursor();
		DataTable objDtElement = new DataTable();
		DataTable objDtElementWvs = new DataTable();
		frmCookBook objfrmCookBook = new frmCookBook();
		clsInstrumentParameters objClsInstrumentParameters;
		int intRowCounter;
		double dblWV;
		Int16 nosteps;
		AAS203Library.Instrument.ClsLampParameters objLampPar = new AAS203Library.Instrument.ClsLampParameters();
		CWaitCursor objwait1 = new CWaitCursor();
		int intCount;

		try {
			//---set turret to home position
			//---10.02.08
			//If mblnIsSetTurret_Home = False Then
			//    Call gobjCommProtocol.gFuncTurret_Home()
			//    mblnIsSetTurret_Home = True
			//End If

			DialogResult dlgResult = new DialogResult();

			//Added By Pankaj on 26 Aug 07 
			//---to show cook book form for inserting lamp
			if ((ISCookBookShown() == "")) {
				dlgResult = objfrmCookBook.ShowDialog();
			} else {
				if ((TurretPosition > 0)) {
					objfrmCookBook.ElementID = gobjDataAccess.GetCookBookElementID(gobjInst.Lamp.LampParametersCollection.item(TurretPosition - 1).AtomicNumber);
				} else {
					objfrmCookBook.ElementID = gobjDataAccess.GetCookBookElementID(gobjInst.Lamp.LampParametersCollection.item(0).AtomicNumber);
				}
				dlgResult = DialogResult.OK;
			}

			//Added By pankaj on 26 Aug 07
			if (dlgResult == DialogResult.OK) {
				mblnIsOperated = true;
				Application.DoEvents();
				objwait1 = new CWaitCursor();

				if (objfrmCookBook.ElementID != 0) {
					//---get selected element details
					objDtElement = gobjClsAAS203.funcGetElement(objfrmCookBook.ElementID);
					//---get wavelengths of selected element
					objDtElementWvs = gobjClsAAS203.funcGetElementWavelengths(objfrmCookBook.ElementID);

					//---set element details to object variables
					if (!IsNothing(objDtElement) & objDtElement.Rows.Count > 0) {
						mobjInstrumentParameters = new clsInstrumentParameters();
						mobjInstrumentParameters.ElementID = (int)objDtElement.Rows(0).Item(ConstColumnElementID);
						mobjInstrumentParameters.ElementName = objDtElement.Rows(0).Item(ConstColumnElementName);
						mobjInstrumentParameters.LampCurrent = (double)objDtElement.Rows(0).Item(ConstColumnCurrent);
						mobjInstrumentParameters.TurretNumber = (int)TurretPosition;

						if (!IsNothing(objDtElementWvs)) {
							if (objDtElementWvs.Rows.Count > 0) {
								mobjInstrumentParameters.SlitWidth = (double)objDtElementWvs.Rows(0).Item("SLIT");
								mobjInstrumentParameters.Wavelength = objDtElementWvs;
							}
						}
						//Saurabh on 28 May 2007
					}

					//---Getting Lamp No. ## for replacement .... Please Wait
					gobjMessageAdapter.ShowStatusMessageBox("Getting Lamp No. " + TurretPosition + " for replacement...Please Wait", "Lamp Replacement", EnumMessageType.Information, 0);
					Application.DoEvents();
					gobjfrmStatus.lblTurretNo.Visible = true;
					//Added by Saurabh

					//---initialize lamp parameters
					if (gfuncInit_Lamp_Par(objLampPar) == true) {
						if (!objDtElement == null) {
							if (objDtElement.Rows.Count > 0) {
								objLampPar.ElementName = (string)objDtElement.Rows(0).Item(ConstColumnElementName);
								objLampPar.Current = (double)objDtElement.Rows(0).Item("CURRENT");
								objLampPar.AtomicNumber = (int)objDtElement.Rows(0).Item("ATNO");
								if (!objDtElementWvs == null) {
									if (objDtElementWvs.Rows.Count > 0) {
										objLampPar.SlitWidth = (double)objDtElementWvs.Rows(0).Item("SLIT");
										objLampPar.Wavelength = (double)objDtElementWvs.Rows(0).Item("WV");
									}
								}
							}
						}

						//---set details of lamp selected in instrument object
						if (gfuncSet_Lamp_Parameters(objLampPar, TurretPosition - 1) == true) {
							//--- set turret to home position
							//---10.02.08
							//If gobjCommProtocol.gFuncTurret_Home() Then
							//---calculate steps to reach turret at top
							nosteps = gfuncTurretStepsForLampTop(TurretPosition);
							//---rotate turret clockwise with above mentioned steps
							if (gobjCommProtocol.funcRotate_Steps_Tur_Clock(nosteps)) {
								gobjMessageAdapter.CloseStatusMessageBox();
								Application.DoEvents();
								//---Insert Cu Lamp in turret No. 3 and click OK button                       
								if (gobjMessageAdapter.ShowMessage("Insert " + objLampPar.ElementName + " lamp in turret No. " + TurretPosition + " and click OK button", "Lamp Replacement", EnumMessageType.Information)) {
									Application.DoEvents();
									CWaitCursor objwait2 = new CWaitCursor();
									//---Initializing .... Please Wait
									Application.DoEvents();

									//sprintf(tmsg,"Initialising .... Please Wait ");
									//SetDlgItemText(hwnd,100,tmsg);
									//UpdateWindow(hwnd);
									//Rotate_Steps_Tur_AntiClock(nosteps+10);
									//Rotate_Steps_Tur_Clock(10);

									gobjMessageAdapter.ShowStatusMessageBox("Initializing .... Please Wait", "Lamp Replacement", EnumMessageType.Information, 0);
									Application.DoEvents();
									//---position turret to home position
									//---10.02.08
									gobjCommProtocol.funcRotate_Steps_Tur_AntiClock(nosteps + 10);
									gobjCommProtocol.funcRotate_Steps_Tur_Clock(10);
									//---10.02.08
									//gobjCommProtocol.gFuncTurret_Home()
									mintLatestTurretPosition = TurretPosition;
									//objClsInstrumentParameters.TurretNumber
									//---set lamp as connected in instrument object
									gfuncLamp_connected(TurretPosition);
									gobjMessageAdapter.CloseStatusMessageBox();
									Application.DoEvents();
									//---display all inserted/removed lamps on screen
									funcInitiliaze_Lamps();
									if (LampReplaced != null) {
										LampReplaced();
									}
								}
							}
							//End If
						}
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			gobjMessageAdapter.CloseStatusMessageBox();
			//---------------------------------------------------------
		}
	}

	private string ISCookBookShown()
	{
		//=====================================================================
		// Procedure Name        : ISCookBookShown
		// Parameters Passed     : 
		// Returns               : True or False
		// Purpose               : To Check that CookBook Should be show or not
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Praveen S Deshmukh
		// Created               : 14.08.07
		// Revisions             : not in used.
		//=====================================================================
		string txtElementName;
		try {
			//---check whether lamp is present in given position or not
			switch (TurretPosition) {
				case 1:
					txtElementName = txt1.Text;
				case 2:
					txtElementName = txt2.Text;
				case 3:
					txtElementName = txt3.Text;
				case 4:
					txtElementName = txt4.Text;
				case 5:
					txtElementName = txt5.Text;
				case 6:
					txtElementName = txt6.Text;
				default:
					txtElementName = "";
			}
			return txtElementName.Trim();
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			txtElementName = "";
			return "";
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

	private void btnRemoveLamp_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnRemoveLamp_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To remove lamp
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 05.10.06
		// Revisions             : 15.12.06 by Deepak B.
		//=====================================================================
		// void	RemoveLamp(HWND hwnd, int lamp, char *elname)
		//{
		//LAMP_PAR   tLamp;
		// Init_Lamp_Par(&tLamp);
		// Set_Lamp_Parameters(&tLamp, lamp);
		// SetLampToTop(hwnd, lamp, elname, FALSE);
		// Lamp_connected(lamp);
		// Initiliaze_Lamps(hwnd);
		//}
		int intObjCount;
		CWaitCursor objWait = new CWaitCursor();
		int nosteps;
		AAS203Library.Instrument.ClsLampParameters objLamp = new AAS203Library.Instrument.ClsLampParameters();
		string strLampName;
		int intCount;

		try {
			mblnIsOperated = true;
			////----- Added by Sachin Dokhale on 31.08.07 to init. Turret Home 
			//---set turret to home position

			//---10.02.08
			//If mblnIsSetTurret_Home = False Then
			//    Call gobjCommProtocol.gFuncTurret_Home()
			//    mblnIsSetTurret_Home = True
			//End If

			////-----

			strLampName = gobjInst.Lamp.LampParametersCollection.item(TurretPosition - 1).ElementName;
			//Added By pankaj on 25 aug 07 
			if ((strLampName == "")) {
				return;
			}
			//---Getting Lamp No. ## for replacement .... Please Wait
			gobjMessageAdapter.ShowStatusMessageBox("Getting Lamp No. " + TurretPosition + " for replacement...Please Wait", "Lamp Replacement", EnumMessageType.Information, 0);
			Application.DoEvents();

			//---initialize instrument object for removal of lamp
			if (gfuncInit_Lamp_Par(objLamp) == true) {
				//---set lamp parameters
				if (gfuncSet_Lamp_Parameters(objLamp, TurretPosition - 1) == true) {
					//---set turret to home position
					//---10.02.08
					//If gobjCommProtocol.gFuncTurret_Home() Then
					//---calculate steps required to bring turret to top
					nosteps = gfuncTurretStepsForLampTop(TurretPosition);
					//---rotate turret clockwise with above mentioned steps
					if (gobjCommProtocol.funcRotate_Steps_Tur_Clock(nosteps)) {
						//---Insert Cu Lamp in turret No. 3 and click OK button
						gobjMessageAdapter.CloseStatusMessageBox();
						Application.DoEvents();
						gobjMessageAdapter.ShowMessage("Remove " + strLampName + " lamp in turret No. " + TurretPosition + " and click OK button", "Lamp Replacement", EnumMessageType.Information);
						Application.DoEvents();
						CWaitCursor objwait1 = new CWaitCursor();
						//---update instrument object after removal of lamp
						gfuncLamp_connected(TurretPosition);
						Application.DoEvents();
						gobjMessageAdapter.ShowStatusMessageBox("Initializing .... Please Wait", "Lamp Replacement", EnumMessageType.Information, 0);
						Application.DoEvents();
						//---bring turret to home position

						//---10.02.08
						//gobjCommProtocol.gFuncTurret_Home()
						gobjCommProtocol.funcRotate_Steps_Tur_AntiClock(nosteps + 10);
						gobjCommProtocol.funcRotate_Steps_Tur_Clock(10);

						gobjMessageAdapter.CloseStatusMessageBox();
						//---display inserted/removed lamps
						funcInitiliaze_Lamps();
						if (LampRemoved != null) {
							LampRemoved();
						}
					}
					//End If
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			gobjMessageAdapter.CloseStatusMessageBox();
			//---------------------------------------------------------
		}
	}

	private void btnOk_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnOk_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To send dialog result ok
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		int intCounter;
		CWaitCursor objWait = new CWaitCursor();
		try {
			Application.DoEvents();
			//'allow application to perfrom its panding work.
			if (mblnIsOperated == false) {
				this.DialogResult = DialogResult.Cancel;
			} else {
				this.DialogResult = DialogResult.OK;
			}
			Application.DoEvents();
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
			//---------------------------------------------------------
		}
	}

	private void btnCancel_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnCancel_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To send dialog result cancel
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		try {
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

	private void subInit(int intSelectedTurretPosition, int intOpenMethodMode)
	{
		//=====================================================================
		// Procedure Name        : subInit
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To initialize the form with lamp positions
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		int intObjCount;
		int intTurret;
		string strElementName;

		try {
			mblnIsOperated = false;

			//---set initial turret position
			TurretPosition = intSelectedTurretPosition;
			OpenMethodMode = intOpenMethodMode;

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

	private void GetTurretPosition(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : GetTurretPosition
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To set the turret position
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		try {
			//---set turret position according to the mouse clicked
			TurretPosition = ((System.Windows.Forms.TextBox)sender).Tag();

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

	private bool funcInitialise()
	{
		//=====================================================================
		// Procedure Name        : funcInitialise
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To initialize the form by displaying all inserted lamps
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();

		try {
			//---10.02.08
			gobjCommProtocol.gFuncTurret_Home();
			Application.DoEvents();

			//---display all elements from instrument object 
			HeaderTop.TitleText = "Insert-Remove Lamp";
			int intCount;
			string strelementname;
			for (intCount = 0; intCount <= gobjInst.Lamp.LampParametersCollection.Count - 1; intCount++) {
				strelementname = gobjInst.Lamp.LampParametersCollection.item(intCount).ElementName;
				switch (intCount + 1) {
					case 1:
						txt1.Text = strelementname;
					case 2:
						txt2.Text = strelementname;
					case 3:
						txt3.Text = strelementname;
					case 4:
						txt4.Text = strelementname;
					case 5:
						txt5.Text = strelementname;
					case 6:
						txt6.Text = strelementname;
				}
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

	private bool funcAddOrRemoveLampAtGivenPosition(int intTurrPos, string strElementName)
	{
		//=====================================================================
		// Procedure Name        : funcAddOrRemoveLampAtGivenPosition
		// Parameters Passed     : intTurrPos,strElementName
		// Returns               : True or False
		// Purpose               : To add or remove element name at given turret position
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 15.12.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();

		try {
			switch (intTurrPos) {
				case 1:
					txt1.Text = strElementName;
					//txt1.Select()
					txt1.Refresh();
				case 2:
					txt2.Text = strElementName;
				//txt2.Select()
				//txt2.Refresh()
				case 3:
					txt3.Text = strElementName;
				//txt3.Select()
				//txt3.Refresh()
				case 4:
					txt4.Text = strElementName;
				//txt4.Select()
				//txt4.Refresh()
				case 5:
					txt5.Text = strElementName;
				//txt5.Select()
				//txt5.Refresh()
				case 6:
					txt6.Text = strElementName;
				//txt6.Select()
				//txt6.Refresh()
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

	private bool funcInitiliaze_Lamps()
	{
		//=====================================================================
		// Procedure Name        : funcInitiliaze_Lamps
		// Parameters Passed     : 
		// Returns               : True or False
		// Purpose               : To add or remove element name at given turret position
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 15.12.06
		// Revisions             : 
		//=====================================================================
		//            void	Initiliaze_Lamps(HWND hwnd)
		//{
		//LAMP_PAR   tLamp;
		//int			i;
		//for(i=0;i<GetMaxLamp(); i++){ //6
		//  Get_Lamp_Parameters(&tLamp, i);
		//  SetDlgItemText(hwnd, IDC_LAMP+i,tLamp.elname);
		// }
		//}
		AAS203Library.Instrument.ClsLampParameters objLampPar = new AAS203Library.Instrument.ClsLampParameters();
		int intCount;
		CWaitCursor objWait = new CWaitCursor();

		try {
			//---display inserted or removed lamps 
			for (intCount = 1; intCount <= gobjClsAAS203.funcGetMaxLamp(); intCount++) {
				gfuncGet_Lamp_Parameters(objLampPar, intCount - 1);
				//'for gettin a lamp parameter.
				funcAddOrRemoveLampAtGivenPosition(intCount, objLampPar.ElementName);
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

	#End Region

}
