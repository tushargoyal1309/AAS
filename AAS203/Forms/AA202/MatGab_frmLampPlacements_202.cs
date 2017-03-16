using AAS203.Common;
using AAS203Library.Method;
using AAS203Library.Instrument;

public class frmLampPlacements_202 : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmLampPlacements_202()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
		mblnIsOperated = false;
	}

	public frmLampPlacements_202(int intSelectedTurretNum, int intOpenMethodMode)
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
	internal System.Windows.Forms.TextBox txt1;
	internal System.Windows.Forms.TextBox txt2;
	internal NETXP.Controls.XPButton btnInsertLamp;
	internal NETXP.Controls.XPButton btnRemoveLamp;
	internal NETXP.Controls.XPButton btnHelp;
	internal NETXP.Controls.XPButton btnOk;
	internal NETXP.Controls.XPButton btnCancel;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmLampPlacements_202));
		this.CustomPanelMain = new GradientPanel.CustomPanel();
		this.btnHelp = new NETXP.Controls.XPButton();
		this.btnOk = new NETXP.Controls.XPButton();
		this.btnCancel = new NETXP.Controls.XPButton();
		this.btnRemoveLamp = new NETXP.Controls.XPButton();
		this.btnInsertLamp = new NETXP.Controls.XPButton();
		this.txt2 = new System.Windows.Forms.TextBox();
		this.txt1 = new System.Windows.Forms.TextBox();
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
		this.CustomPanelMain.Controls.Add(this.txt2);
		this.CustomPanelMain.Controls.Add(this.txt1);
		this.CustomPanelMain.Controls.Add(this.lbl2);
		this.CustomPanelMain.Controls.Add(this.lbl1);
		this.CustomPanelMain.Controls.Add(this.lblElementName);
		this.CustomPanelMain.Controls.Add(this.lblTurretNo);
		this.CustomPanelMain.Controls.Add(this.Label1);
		this.CustomPanelMain.Controls.Add(this.HeaderTop);
		this.CustomPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanelMain.Location = new System.Drawing.Point(0, 0);
		this.CustomPanelMain.Name = "CustomPanelMain";
		this.CustomPanelMain.Size = new System.Drawing.Size(314, 187);
		this.CustomPanelMain.TabIndex = 0;
		//
		//btnHelp
		//
		this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnHelp.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnHelp.Image = (System.Drawing.Image)resources.GetObject("btnHelp.Image");
		this.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnHelp.Location = new System.Drawing.Point(288, 182);
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
		this.btnOk.Location = new System.Drawing.Point(213, 31);
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
		this.btnCancel.Location = new System.Drawing.Point(213, 89);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(86, 34);
		this.btnCancel.TabIndex = 7;
		this.btnCancel.Text = "&Cancel";
		//
		//btnRemoveLamp
		//
		this.btnRemoveLamp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnRemoveLamp.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnRemoveLamp.Image = (System.Drawing.Image)resources.GetObject("btnRemoveLamp.Image");
		this.btnRemoveLamp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnRemoveLamp.Location = new System.Drawing.Point(156, 140);
		this.btnRemoveLamp.Name = "btnRemoveLamp";
		this.btnRemoveLamp.Size = new System.Drawing.Size(132, 38);
		this.btnRemoveLamp.TabIndex = 10;
		this.btnRemoveLamp.Text = "&Remove Lamp";
		//
		//btnInsertLamp
		//
		this.btnInsertLamp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnInsertLamp.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnInsertLamp.Image = (System.Drawing.Image)resources.GetObject("btnInsertLamp.Image");
		this.btnInsertLamp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnInsertLamp.Location = new System.Drawing.Point(20, 140);
		this.btnInsertLamp.Name = "btnInsertLamp";
		this.btnInsertLamp.Size = new System.Drawing.Size(124, 38);
		this.btnInsertLamp.TabIndex = 9;
		this.btnInsertLamp.Text = "&Insert Lamp";
		//
		//txt2
		//
		this.txt2.BackColor = System.Drawing.Color.White;
		this.txt2.Location = new System.Drawing.Point(96, 94);
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
		this.txt1.Location = new System.Drawing.Point(96, 65);
		this.txt1.Name = "txt1";
		this.txt1.ReadOnly = true;
		this.txt1.Size = new System.Drawing.Size(89, 20);
		this.txt1.TabIndex = 0;
		this.txt1.Tag = "1";
		this.txt1.Text = "";
		this.txt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		//
		//lbl2
		//
		this.lbl2.Location = new System.Drawing.Point(35, 97);
		this.lbl2.Name = "lbl2";
		this.lbl2.Size = new System.Drawing.Size(36, 15);
		this.lbl2.TabIndex = 5;
		this.lbl2.Text = "2";
		this.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lbl1
		//
		this.lbl1.Location = new System.Drawing.Point(35, 68);
		this.lbl1.Name = "lbl1";
		this.lbl1.Size = new System.Drawing.Size(36, 15);
		this.lbl1.TabIndex = 4;
		this.lbl1.Text = "1";
		this.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblElementName
		//
		this.lblElementName.Location = new System.Drawing.Point(95, 39);
		this.lblElementName.Name = "lblElementName";
		this.lblElementName.Size = new System.Drawing.Size(89, 16);
		this.lblElementName.TabIndex = 3;
		this.lblElementName.Text = "Element Name";
		this.lblElementName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblTurretNo
		//
		this.lblTurretNo.Location = new System.Drawing.Point(21, 41);
		this.lblTurretNo.Name = "lblTurretNo";
		this.lblTurretNo.Size = new System.Drawing.Size(64, 13);
		this.lblTurretNo.TabIndex = 2;
		this.lblTurretNo.Text = "Turret No.";
		this.lblTurretNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//Label1
		//
		this.Label1.BackColor = System.Drawing.Color.Transparent;
		this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.Label1.Location = new System.Drawing.Point(13, 30);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(189, 98);
		this.Label1.TabIndex = 1;
		//
		//HeaderTop
		//
		this.HeaderTop.BackColor = System.Drawing.SystemColors.Control;
		this.HeaderTop.Dock = System.Windows.Forms.DockStyle.Top;
		this.HeaderTop.Location = new System.Drawing.Point(0, 0);
		this.HeaderTop.Name = "HeaderTop";
		this.HeaderTop.Size = new System.Drawing.Size(314, 20);
		this.HeaderTop.TabIndex = 0;
		this.HeaderTop.TitleFont = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.HeaderTop.TitleText = "Insert/Remove Lamp";
		//
		//frmLampPlacements_202
		//
		this.AcceptButton = this.btnOk;
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.CancelButton = this.btnCancel;
		this.ClientSize = new System.Drawing.Size(314, 187);
		this.Controls.Add(this.CustomPanelMain);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmLampPlacements_202";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Lamp Placements AA 202";
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
	#End Region

	#Region " Private Constants "

	private const  ConstFormLoad = "AAS203-Method-InstrumentParameters-LampPlacements";

	private const  ConstParentFormLoad = "AAS203-Method-InstrumentParameters";
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
frmLampPlacements_202_Load(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmLampPlacements_202_Load
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To Add event handlers and to initialize the form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			gobjMain.ShowProgressBar(ConstFormLoad);
			AddHandlers();
			funcInitialise();

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
frmLampPlacements_202_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		gobjMain.ShowRunTimeInfo(ConstParentFormLoad);
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
			txt1.Enter += GetTurretPosition;
			txt2.Enter += GetTurretPosition;

			//AddHandler txt3.Enter, AddressOf GetTurretPosition
			//AddHandler txt4.Enter, AddressOf GetTurretPosition
			//AddHandler txt5.Enter, AddressOf GetTurretPosition
			//AddHandler txt6.Enter, AddressOf GetTurretPosition

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
			if (objfrmCookBook.ShowDialog() == DialogResult.OK) {
				mblnIsOperated = true;
				Application.DoEvents();
				objwait1 = new CWaitCursor();

				if (objfrmCookBook.ElementID != 0) {
					objDtElement = gobjClsAAS203.funcGetElement(objfrmCookBook.ElementID);
					objDtElementWvs = gobjClsAAS203.funcGetElementWavelengths(objfrmCookBook.ElementID);

					if (!IsNothing(objDtElement) & objDtElement.Rows.Count > 0) {
						mobjInstrumentParameters = new clsInstrumentParameters();
						mobjInstrumentParameters.ElementID = (int)objDtElement.Rows(0).Item(ConstColumnElementID);
						mobjInstrumentParameters.ElementName = objDtElement.Rows(0).Item(ConstColumnElementName);
						mobjInstrumentParameters.LampCurrent = (double)objDtElement.Rows(0).Item(ConstColumnCurrent);
						mobjInstrumentParameters.TurretNumber = (int)TurretPosition;
						if (!IsNothing(objDtElementWvs) & objDtElementWvs.Rows.Count > 0) {
							mobjInstrumentParameters.SlitWidth = (double)objDtElementWvs.Rows(0).Item("SLIT");
							mobjInstrumentParameters.Wavelength = objDtElementWvs;
						}
					}

					//---Getting Lamp No. ## for replacement .... Please Wait
					gobjMessageAdapter.ShowStatusMessageBox("Getting Lamp No. " + TurretPosition + " for replacement...Please Wait", "Lamp Replacement", EnumMessageType.Information, 0);
					Application.DoEvents();

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

						if (gfuncSet_Lamp_Parameters(objLampPar, TurretPosition) == true) {
							if (gobjCommProtocol.gFuncTurret_Home()) {
								nosteps = gfuncTurretStepsForLampTop(TurretPosition);
								if (gobjCommProtocol.funcRotate_Steps_Tur_Clock(nosteps)) {
									gobjMessageAdapter.CloseStatusMessageBox();
									Application.DoEvents();
									//---Insert Cu Lamp in turret No. 3 and click OK button                       
									if (gobjMessageAdapter.ShowMessage("Insert " + objLampPar.ElementName + " lamp in turret No. " + TurretPosition + " and click OK button", "Lamp Replacement", EnumMessageType.Information)) {
										Application.DoEvents();
										CWaitCursor objwait2 = new CWaitCursor();
										//---Initializing .... Please Wait
										Application.DoEvents();
										gobjMessageAdapter.ShowStatusMessageBox("Initializing .... Please Wait", "Lamp Replacement", EnumMessageType.Information, 0);
										Application.DoEvents();
										gobjCommProtocol.gFuncTurret_Home();
										mintLatestTurretPosition = TurretPosition;
										//objClsInstrumentParameters.TurretNumber
										gfuncLamp_connected(TurretPosition);
										gobjMessageAdapter.CloseStatusMessageBox();
										Application.DoEvents();
										funcInitiliaze_Lamps();
										if (LampReplaced != null) {
											LampReplaced();
										}
									}
								}
							}
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
			//If Not IsNothing(mobjInstrumentParameters) Then
			//    If mobjInstrumentParameters.TurretNumber = TurretPosition Then
			//        mobjInstrumentParameters = New clsInstrumentParameters
			//    End If
			//Else
			//    Exit Try
			//End If
			//gobjNewMethod.InstrumentCondition = mobjInstrumentParameters

			//For intCount = 0 To gobjMethodCollection.Count - 1
			//    If gobjMethodCollection.item(intCount).OperationMode = EnumOperationMode.MODE_AA Or _
			//    gobjMethodCollection.item(intCount).OperationMode = EnumOperationMode.MODE_AABGC Then
			//        gobjMethodCollection.item(intCount).InstrumentCondition = gobjNewMethod.InstrumentCondition.Clone
			//    End If
			//Next
			//Call funcSerialize(ConstMethodsFileName, gobjMethodCollection)

			strLampName = gobjInst.Lamp.LampParametersCollection.item(TurretPosition - 1).ElementName;
			//---Getting Lamp No. ## for replacement .... Please Wait
			gobjMessageAdapter.ShowStatusMessageBox("Getting Lamp No. " + TurretPosition + " for replacement...Please Wait", "Lamp Replacement", EnumMessageType.Information, 0);
			Application.DoEvents();

			if (gfuncInit_Lamp_Par(objLamp) == true) {
				if (gfuncSet_Lamp_Parameters(objLamp, TurretPosition) == true) {
					if (gobjCommProtocol.gFuncTurret_Home()) {
						nosteps = gfuncTurretStepsForLampTop(TurretPosition);
						if (gobjCommProtocol.funcRotate_Steps_Tur_Clock(nosteps)) {
							//---Insert Cu Lamp in turret No. 3 and click OK button
							gobjMessageAdapter.CloseStatusMessageBox();
							Application.DoEvents();
							gobjMessageAdapter.ShowMessage("Remove " + strLampName + " lamp in turret No. " + TurretPosition + " and click OK button", "Lamp Replacement", EnumMessageType.Information);
							Application.DoEvents();
							CWaitCursor objwait1 = new CWaitCursor();
							gfuncLamp_connected(TurretPosition);
							Application.DoEvents();
							gobjMessageAdapter.ShowStatusMessageBox("Initializing .... Please Wait", "Lamp Replacement", EnumMessageType.Information, 0);
							Application.DoEvents();
							gobjCommProtocol.gFuncTurret_Home();
							gobjMessageAdapter.CloseStatusMessageBox();
							funcInitiliaze_Lamps();
							if (LampRemoved != null) {
								LampRemoved();
							}
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
		CWaitCursor objWait = new CWaitCursor();

		try {
			Application.DoEvents();

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
			objWait.Dispose();
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
			//If Not IsNothing(objInstrumentParameters) Then
			//    mobjInstrumentParameters = objInstrumentParameters.Clone()
			//End If

			//Dim intCtrlCounter As Integer
			//Dim ctrl As Control

			//If Not IsNothing(mobjInstrumentParameters) Then
			//    intTurret = mobjInstrumentParameters.TurretNumber
			//    strElementName = mobjInstrumentParameters.ElementName

			//    Select Case intTurret
			//        Case 1
			//            txt1.Text = strElementName
			//        Case 2
			//            txt2.Text = strElementName
			//        Case 3
			//            txt3.Text = strElementName
			//        Case 4
			//            txt4.Text = strElementName
			//        Case 5
			//            txt5.Text = strElementName
			//        Case 6
			//            txt6.Text = strElementName
			//    End Select
			//End If

			//Select Case intSelectedTurretPosition
			//    Case 1
			//        txt1.Select()
			//    Case 2
			//        txt2.Select()
			//    Case 3
			//        txt3.Select()
			//    Case 4
			//        txt4.Select()
			//    Case 5
			//        txt5.Select()
			//    Case 6
			//        txt6.Select()
			//End Select

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
		// Purpose               : To initialize the form by bringing turret to hotme position
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		int intCount;
		string strelementname;

		try {
			//---To get currect turret position first get turret home position
			HeaderTop.TitleText = "Insert-Remove Lamp for AA 202";

			for (intCount = 0; intCount <= gobjInst.Lamp.LampParametersCollection.Count - 1; intCount++) {
				strelementname = gobjInst.Lamp.LampParametersCollection.item(intCount).ElementName;
				switch (intCount + 1) {
					case 1:
						txt1.Text = strelementname;
					case 2:

						txt2.Text = strelementname;
					//Case 3
					//    txt3.Text = strelementname
					//Case 4
					//    txt4.Text = strelementname
					//Case 5
					//    txt5.Text = strelementname
					//Case 6
					//    txt6.Text = strelementname

				}
			}

			return gobjCommProtocol.gFuncTurret_Home();

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

				//Case 3
				//    txt3.Text = strElementName
				//    'txt3.Select()
				//    'txt3.Refresh()
				//Case 4
				//    txt4.Text = strElementName
				//    'txt4.Select()
				//    'txt4.Refresh()
				//Case 5
				//    txt5.Text = strElementName
				//    'txt5.Select()
				//    'txt5.Refresh()
				//Case 6
				//    txt6.Text = strElementName
				//    'txt6.Select()
				//    'txt6.Refresh()

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
			for (intCount = 1; intCount <= gobjClsAAS203.funcGetMaxLamp(); intCount++) {
				gfuncGet_Lamp_Parameters(objLampPar, intCount);
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
