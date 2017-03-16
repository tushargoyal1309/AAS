using AAS203.Common;
using AAS203Library.Method;
//'above are the supporting headers file for this class
//'this is a class behind the new method form

public class frmNewMethod : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmNewMethod()
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
	internal GradientPanel.CustomPanel CustomPanel1;
	internal System.Windows.Forms.Label Label1;
	internal CodeIntellects.Office2003Controls.Office2003Header Office2003Header1;
	internal System.Windows.Forms.Label Label2;
	internal System.Windows.Forms.Label Label4;
	internal System.Windows.Forms.Label Label5;
	internal NETXP.Controls.XPButton btnHelp;
	internal NETXP.Controls.XPButton btnCancel;
	internal NETXP.Controls.XPButton btnOk;
	internal System.Windows.Forms.TextBox txtComment;
	internal System.Windows.Forms.ComboBox cmbOperationMode;
	internal System.Windows.Forms.ToolTip ToolTip1;
	internal NumberValidator.NumberValidator txtMethodName;
	internal NumberValidator.NumberValidator txtUserName;
	internal System.Windows.Forms.Label Label3;
	internal System.Windows.Forms.CheckBox chkStdAddition;
	internal System.Windows.Forms.Panel Panel201Lamps;
	internal System.Windows.Forms.RadioButton rdD2Lamp;
	internal System.Windows.Forms.RadioButton rdSRLamp;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmNewMethod));
		this.CustomPanel1 = new GradientPanel.CustomPanel();
		this.Panel201Lamps = new System.Windows.Forms.Panel();
		this.rdSRLamp = new System.Windows.Forms.RadioButton();
		this.rdD2Lamp = new System.Windows.Forms.RadioButton();
		this.chkStdAddition = new System.Windows.Forms.CheckBox();
		this.txtUserName = new NumberValidator.NumberValidator();
		this.txtMethodName = new NumberValidator.NumberValidator();
		this.btnCancel = new NETXP.Controls.XPButton();
		this.btnOk = new NETXP.Controls.XPButton();
		this.txtComment = new System.Windows.Forms.TextBox();
		this.Label5 = new System.Windows.Forms.Label();
		this.Label4 = new System.Windows.Forms.Label();
		this.Label3 = new System.Windows.Forms.Label();
		this.cmbOperationMode = new System.Windows.Forms.ComboBox();
		this.Label2 = new System.Windows.Forms.Label();
		this.Office2003Header1 = new CodeIntellects.Office2003Controls.Office2003Header();
		this.Label1 = new System.Windows.Forms.Label();
		this.btnHelp = new NETXP.Controls.XPButton();
		this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
		this.CustomPanel1.SuspendLayout();
		this.Panel201Lamps.SuspendLayout();
		this.SuspendLayout();
		//
		//CustomPanel1
		//
		this.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanel1.Controls.Add(this.Panel201Lamps);
		this.CustomPanel1.Controls.Add(this.chkStdAddition);
		this.CustomPanel1.Controls.Add(this.txtUserName);
		this.CustomPanel1.Controls.Add(this.txtMethodName);
		this.CustomPanel1.Controls.Add(this.btnCancel);
		this.CustomPanel1.Controls.Add(this.btnOk);
		this.CustomPanel1.Controls.Add(this.txtComment);
		this.CustomPanel1.Controls.Add(this.Label5);
		this.CustomPanel1.Controls.Add(this.Label4);
		this.CustomPanel1.Controls.Add(this.Label3);
		this.CustomPanel1.Controls.Add(this.cmbOperationMode);
		this.CustomPanel1.Controls.Add(this.Label2);
		this.CustomPanel1.Controls.Add(this.Office2003Header1);
		this.CustomPanel1.Controls.Add(this.Label1);
		this.CustomPanel1.Controls.Add(this.btnHelp);
		this.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanel1.Location = new System.Drawing.Point(0, 0);
		this.CustomPanel1.Name = "CustomPanel1";
		this.CustomPanel1.Size = new System.Drawing.Size(378, 347);
		this.CustomPanel1.TabIndex = 0;
		//
		//Panel201Lamps
		//
		this.Panel201Lamps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.Panel201Lamps.Controls.Add(this.rdSRLamp);
		this.Panel201Lamps.Controls.Add(this.rdD2Lamp);
		this.Panel201Lamps.Location = new System.Drawing.Point(218, 106);
		this.Panel201Lamps.Name = "Panel201Lamps";
		this.Panel201Lamps.Size = new System.Drawing.Size(150, 38);
		this.Panel201Lamps.TabIndex = 12;
		this.Panel201Lamps.Visible = false;
		//
		//rdSRLamp
		//
		this.rdSRLamp.Font = new System.Drawing.Font("Arial", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.rdSRLamp.Location = new System.Drawing.Point(80, 4);
		this.rdSRLamp.Name = "rdSRLamp";
		this.rdSRLamp.Size = new System.Drawing.Size(56, 28);
		this.rdSRLamp.TabIndex = 1;
		this.rdSRLamp.Text = "With SR Lamp";
		//
		//rdD2Lamp
		//
		this.rdD2Lamp.Checked = true;
		this.rdD2Lamp.Font = new System.Drawing.Font("Arial", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.rdD2Lamp.Location = new System.Drawing.Point(8, 6);
		this.rdD2Lamp.Name = "rdD2Lamp";
		this.rdD2Lamp.Size = new System.Drawing.Size(60, 26);
		this.rdD2Lamp.TabIndex = 0;
		this.rdD2Lamp.TabStop = true;
		this.rdD2Lamp.Text = "With D2 Lamp";
		//
		//chkStdAddition
		//
		this.chkStdAddition.Location = new System.Drawing.Point(196, 116);
		this.chkStdAddition.Name = "chkStdAddition";
		this.chkStdAddition.Size = new System.Drawing.Size(20, 18);
		this.chkStdAddition.TabIndex = 2;
		this.chkStdAddition.Text = "CheckBox1";
		//
		//txtUserName
		//
		this.txtUserName.DigitsAfterDecimalPoint = 0;
		this.txtUserName.ErrorColor = System.Drawing.Color.Empty;
		this.txtUserName.ErrorMessage = null;
		this.txtUserName.Location = new System.Drawing.Point(198, 148);
		this.txtUserName.MaximumRange = 0;
		this.txtUserName.MaxLength = 40;
		this.txtUserName.MinimumRange = 0;
		this.txtUserName.Name = "txtUserName";
		this.txtUserName.RangeValidation = false;
		this.txtUserName.Size = new System.Drawing.Size(173, 21);
		this.txtUserName.TabIndex = 3;
		this.txtUserName.Text = "";
		this.txtUserName.ValidationType = NumberValidator.NumberValidator.Validations.AlphaNumeric;
		//
		//txtMethodName
		//
		this.txtMethodName.DigitsAfterDecimalPoint = 0;
		this.txtMethodName.ErrorColor = System.Drawing.Color.Empty;
		this.txtMethodName.ErrorMessage = null;
		this.txtMethodName.Location = new System.Drawing.Point(196, 50);
		this.txtMethodName.MaximumRange = 0;
		this.txtMethodName.MaxLength = 10;
		this.txtMethodName.MinimumRange = 0;
		this.txtMethodName.Name = "txtMethodName";
		this.txtMethodName.RangeValidation = false;
		this.txtMethodName.Size = new System.Drawing.Size(173, 21);
		this.txtMethodName.TabIndex = 0;
		this.txtMethodName.Text = "";
		this.txtMethodName.ValidationType = NumberValidator.NumberValidator.Validations.AlphaNumeric;
		//
		//btnCancel
		//
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCancel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnCancel.Image = (System.Drawing.Image)resources.GetObject("btnCancel.Image");
		this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCancel.Location = new System.Drawing.Point(277, 293);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(86, 34);
		this.btnCancel.TabIndex = 6;
		this.btnCancel.Text = "&Cancel";
		//
		//btnOk
		//
		this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOk.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnOk.Image = (System.Drawing.Image)resources.GetObject("btnOk.Image");
		this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOk.Location = new System.Drawing.Point(176, 293);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(86, 34);
		this.btnOk.TabIndex = 5;
		this.btnOk.Text = "&OK";
		//
		//txtComment
		//
		this.txtComment.Location = new System.Drawing.Point(21, 202);
		this.txtComment.Multiline = true;
		this.txtComment.Name = "txtComment";
		this.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtComment.Size = new System.Drawing.Size(342, 70);
		this.txtComment.TabIndex = 4;
		this.txtComment.Text = "Comments for new method.";
		//
		//Label5
		//
		this.Label5.Location = new System.Drawing.Point(16, 182);
		this.Label5.Name = "Label5";
		this.Label5.Size = new System.Drawing.Size(108, 16);
		this.Label5.TabIndex = 10;
		this.Label5.Text = "Comments";
		//
		//Label4
		//
		this.Label4.Location = new System.Drawing.Point(18, 152);
		this.Label4.Name = "Label4";
		this.Label4.Size = new System.Drawing.Size(76, 16);
		this.Label4.TabIndex = 8;
		this.Label4.Text = "User name";
		//
		//Label3
		//
		this.Label3.BackColor = System.Drawing.Color.Transparent;
		this.Label3.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label3.Location = new System.Drawing.Point(16, 116);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(156, 20);
		this.Label3.TabIndex = 6;
		this.Label3.Text = "Standard Addition";
		//
		//cmbOperationMode
		//
		this.cmbOperationMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbOperationMode.Items.AddRange(new object[] {
			"",
			"",
			""
		});
		this.cmbOperationMode.Location = new System.Drawing.Point(196, 80);
		this.cmbOperationMode.Name = "cmbOperationMode";
		this.cmbOperationMode.Size = new System.Drawing.Size(172, 23);
		this.cmbOperationMode.TabIndex = 1;
		//
		//Label2
		//
		this.Label2.Location = new System.Drawing.Point(16, 84);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(182, 18);
		this.Label2.TabIndex = 4;
		this.Label2.Text = "Method type(Mode of operation)";
		//
		//Office2003Header1
		//
		this.Office2003Header1.BackColor = System.Drawing.SystemColors.Control;
		this.Office2003Header1.Dock = System.Windows.Forms.DockStyle.Top;
		this.Office2003Header1.Location = new System.Drawing.Point(0, 0);
		this.Office2003Header1.Name = "Office2003Header1";
		this.Office2003Header1.Size = new System.Drawing.Size(378, 22);
		this.Office2003Header1.TabIndex = 3;
		this.Office2003Header1.TitleFont = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Office2003Header1.TitleText = "New Method";
		//
		//Label1
		//
		this.Label1.Location = new System.Drawing.Point(16, 53);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(166, 16);
		this.Label1.TabIndex = 1;
		this.Label1.Text = "Enter a new method name";
		//
		//btnHelp
		//
		this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnHelp.Image = (System.Drawing.Image)resources.GetObject("btnHelp.Image");
		this.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnHelp.Location = new System.Drawing.Point(278, 318);
		this.btnHelp.Name = "btnHelp";
		this.btnHelp.Size = new System.Drawing.Size(86, 34);
		this.btnHelp.TabIndex = 11;
		this.btnHelp.Text = "Help";
		this.btnHelp.Visible = false;
		//
		//frmNewMethod
		//
		this.AcceptButton = this.btnOk;
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.CancelButton = this.btnCancel;
		this.ClientSize = new System.Drawing.Size(378, 347);
		this.ControlBox = false;
		this.Controls.Add(this.CustomPanel1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmNewMethod";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Method";
		this.CustomPanel1.ResumeLayout(false);
		this.Panel201Lamps.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Private Constants"
	//this are the private constants which are used in new method creation

	private const  ConstFormLoad = "-Method-New";

	private const  ConstParentFormLoad = "-Method";
	#End Region

	#Region " Form Events"

	private void  // ERROR: Handles clauses are not supported in C#
frmNewMethod_Load(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmNewMethod_Load
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To initialize and load the form
		// Description           : this is called when form in loaded
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is called when form is loaded.
		DataTable objDtMethod = new DataTable();
		//'this is a object of DataTable data structur
		CWaitCursor objWait = new CWaitCursor();


		try {
			gobjMain.ShowProgressBar(gstrTitleInstrumentType + ConstFormLoad);
			//'it's shows the some instrument info on status bar
			SubAddHandlers();
			//'this add all the event or handler to control

			objDtMethod = gobjClsAAS203.funcGetMethodTypes();
			//'To get method types from database e.g. AA,AABGC,UV,Emission
			if (!IsNothing(objDtMethod)) {
				//'check is objDtMethod object is NULL or Not
				//'this is realted to method data structure
				//'here we are getting some method info from data structure
				cmbOperationMode.DataSource = objDtMethod;
				cmbOperationMode.ValueMember = objDtMethod.Columns(ConstColumnMethodTypeID).ColumnName;
				cmbOperationMode.DisplayMember = objDtMethod.Columns(ConstColumnMethodType).ColumnName;
			}
			//to bind objDtMethod datatable to the combobox
			txtMethodName.Focus();
			txtMethodName.Select();
			//Saurabh 10.07.07 To bring status form in front
			if (!IsInIQOQPQ) {
				//'IsInIQOQPQ is a flag for whatever IQOQPQ is to be shown or not
				gobjfrmStatus.Show();
			} else {
				//code added by : dinesh wagh on 15.2.2010
				//else condition added.
				chkStdAddition.Enabled = false;
			}
		//Saurabh

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
frmNewMethod_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmNewMethod_Closing
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================

		gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType + ConstParentFormLoad);

		//'this will called when we close the NewMethod window
	}

	#End Region

	#Region " Private Functions"

	private void SubAddHandlers()
	{
		//=====================================================================
		// Procedure Name        : SubAddHandlers
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To add handlers
		// Description           : to add a event to a control's
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 07.10.06
		// Revisions             : 
		//=====================================================================
		btnCancel.Click += btnCancel_Click;
		//'it means when we click on cancel button ,btnCancel_Click will called
		//'and so on....
		btnOk.Click += btnOk_Click;
		cmbOperationMode.SelectedIndexChanged += cmbOperationMode_SelectedIndexChanged;
	}

	private void btnCancel_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnCancel_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To cancel the form
		// Description           : this event is call when we click on cancel button
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

	private void btnOk_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnOk_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To send dialog result as ok
		// Description           : this event is called when we click OK button
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		string strMethodName;
		string strUserName;
		bool blnStdAddition;
		int intMethodTypeID;
		int intMethodID;
		string strComments;
		int intCounter;
		CWaitCursor objWait = new CWaitCursor();
		//'above are the temp variable for accumulate temp value
		//'for ex strMethodName will store methodname ect....

		try {
			//'check that method name and user name must be enterd properly
			//'test for the validation 
			if (Trim(txtMethodName.Text) == "" | Trim(txtUserName.Text) == "") {
				if (Trim(txtMethodName.Text) == "") {
					gobjMessageAdapter.ShowMessage(constEnterMethodName);
					//'prompt msg if method name or user name empty
					txtMethodName.Focus();
					Application.DoEvents();
				} else {
					gobjMessageAdapter.ShowMessage(constEnterUserName);
					//'prompt if user name is empty
					txtUserName.Focus();
					Application.DoEvents();
				}
				return;
			} else {
				//'make a counter of total method count to zero in step -1
				//'for getting total num of method in a data structur

				for (intCounter = gobjMethodCollection.Count - 1; intCounter >= 0; intCounter += -1) {
					//'check if method name already exit or not 
					if (Trim(gobjMethodCollection.item(intCounter).MethodName) == Trim(txtMethodName.Text)) {
						//'is yes then prompt message
						gobjMessageAdapter.ShowMessage(constMethodNameExists);
						txtMethodName.Focus();
						Application.DoEvents();
						//'allow application to perfrom its panding work.
						return;
					}
				}
			}

			//intMethodID = gobjMethodCollection.Count + 1
			intMethodID = getMaxMethodID() + 1;
			// Added By Pankaj on 25 MAy 07
			//'increment the method id by 1. and store in the data structure
			strMethodName = Trim(txtMethodName.Text);
			strUserName = Trim(txtUserName.Text);

			if (chkStdAddition.Checked == true) {
				blnStdAddition = true;
			//'blnStdAddition is a flag for std addition option
			//'if it is true then create a method with std addition option

			} else {
				blnStdAddition = false;
			}

			intMethodTypeID = cmbOperationMode.SelectedValue;
			strComments = Trim(txtComment.Text);

			gobjNewMethod = new clsMethod();
			//'clsMethod is a class(like data structure for method) which contains the all method info
			//'which will save as well as used in software

			//'below are the code by which we are sending all user defined method info to temp variable in method data structure
			//'for exa
			gobjNewMethod.MethodID = intMethodID;
			//'this will send a method id given by user  to method data structure.
			gobjNewMethod.MethodName = strMethodName;
			gobjNewMethod.OperationMode = intMethodTypeID;
			gobjNewMethod.StandardAddition = blnStdAddition;
			gobjNewMethod.UserName = strUserName;
			gobjNewMethod.Comments = strComments;
			gobjNewMethod.DateOfCreation = DateTime.Now;
			gobjNewMethod.Status = true;
			//gobjNewMethod.Status = False 'Added By Pankaj on 23 MAy 07
			gobjNewMethod.DateOfModification = System.DateTime.FromOADate(0.0);
			gobjNewMethod.DateOfLastUse = System.DateTime.FromOADate(0.0);

			//frmMethod.mintMethodMode = EnumMethodMode.NewMode
			this.DialogResult = DialogResult.OK;
			Application.DoEvents();

			//Saurabh on 28 MAy 2007
			//'check a cond for operation mode if mode is UVABS or not
			if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_UVABS) {
				//'if yes then do some validation on status form 
				if (gobjfrmStatus.lblTurretNo.Visible == true) {
					gobjfrmStatus.lblTurretNo.Visible = false;
				}
				if (gobjfrmStatus.lblElementName.Visible == true) {
					gobjfrmStatus.lblElementName.Visible = false;
				}
			} else if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_AA | gobjNewMethod.OperationMode == EnumOperationMode.MODE_AABGC) {
				if (gobjfrmStatus.lblTurretNo.Visible == false) {
					gobjfrmStatus.lblTurretNo.Visible = true;
					//'this will show the turretno in status window

				}
				if (gobjfrmStatus.lblElementName.Visible == false) {
					gobjfrmStatus.lblElementName.Visible = true;
				}
			}
			if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
				if (gobjfrmStatus.lblTurretNo.Visible == true) {
					gobjfrmStatus.lblTurretNo.Visible = false;
				}
				if (gobjfrmStatus.lblElementName.Visible == false) {
					gobjfrmStatus.lblElementName.Visible = true;
				}
				gobjfrmStatus.lblElementName.Text = "";
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

	private int getMaxMethodID()
	{
		//=====================================================================
		// Procedure Name        : getMaxMethodID
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : Select Max Id of Method No
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		int i;
		int iMax;
		//'note:
		//'this function is used for getting maximum method id.
		//'so that software can provide new ID to New Method

		try {
			iMax = 0;
			//'gobjMethodCollection.Count give the total count of method store in a data structure 
			for (i = 0; i <= gobjMethodCollection.Count - 1; i++) {
				if ((iMax < gobjMethodCollection.item(i).MethodID)) {
					iMax = gobjMethodCollection.item(i).MethodID;
				}

			}
			getMaxMethodID = iMax;
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

	private void cmbOperationMode_SelectedIndexChanged(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : cmbOperationMode_SelectedIndexChanged
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : changed a mode on a combo box
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		//gobjAAS203Library.mobjMethod.OperationMode = cmbOperationMode.SelectedIndex
		//Added By Pankaj on 30 May 07
		//'note;
		//'this is called when we changed a mode on a combbox
		//'here we made some validation onscreen as par mode selected


		try {
			if ((cmbOperationMode.Text == "AABGC Quantitative Mode")) {
				if ((gstructSettings.AppMode == EnumAppMode.FullVersion_201)) {
					Panel201Lamps.Visible = true;
				}
			} else {
				Panel201Lamps.Visible = false;
			}
		//------------
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
