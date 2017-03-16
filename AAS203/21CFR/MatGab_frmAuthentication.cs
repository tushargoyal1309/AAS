using System.Data;
using System.Data.OleDb;
using AAS203.Signature;

public class frmAuthentication : System.Windows.Forms.Form
{

	#Region "Module level Declarations "

	//Private mstrFileName As String
	//Private mobjDigitalSignature As DigitalSignature
	//Dim blncancelFlag As Boolean = False
		#End Region
	bool blnRBFileOptionCheck = false;

	#Region " Windows Form Designer generated code "

	//--- User Defined Constructor
	public frmAuthentication()
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
	internal System.Windows.Forms.PictureBox PictureBox4;
	internal System.Windows.Forms.TextBox txtPassword;
	internal System.Windows.Forms.Label lblPassword;
	internal System.Windows.Forms.Label Label2;
	internal System.Windows.Forms.PictureBox PictureBox3;
	internal System.Windows.Forms.Panel pnlPassword;
	internal System.Windows.Forms.RadioButton RBFile;
	internal System.Windows.Forms.RadioButton RBLogin;
	internal System.Windows.Forms.TextBox txtUserName;
	internal System.Windows.Forms.Label lblUserName;
	internal System.Windows.Forms.PictureBox PictureBox2;
	internal System.Windows.Forms.Label Label1;
	internal System.Windows.Forms.PictureBox PictureBox1;
	internal System.Windows.Forms.Panel pnlAuthentication;
	internal System.Windows.Forms.PictureBox PictureBox5;
	internal NETXP.Controls.XPButton btnOk;
	internal NETXP.Controls.XPButton cmdCancel;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmAuthentication));
		this.pnlPassword = new System.Windows.Forms.Panel();
		this.PictureBox4 = new System.Windows.Forms.PictureBox();
		this.txtPassword = new System.Windows.Forms.TextBox();
		this.lblPassword = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.PictureBox3 = new System.Windows.Forms.PictureBox();
		this.pnlAuthentication = new System.Windows.Forms.Panel();
		this.RBFile = new System.Windows.Forms.RadioButton();
		this.RBLogin = new System.Windows.Forms.RadioButton();
		this.txtUserName = new System.Windows.Forms.TextBox();
		this.lblUserName = new System.Windows.Forms.Label();
		this.PictureBox2 = new System.Windows.Forms.PictureBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.PictureBox1 = new System.Windows.Forms.PictureBox();
		this.PictureBox5 = new System.Windows.Forms.PictureBox();
		this.btnOk = new NETXP.Controls.XPButton();
		this.cmdCancel = new NETXP.Controls.XPButton();
		this.pnlPassword.SuspendLayout();
		this.pnlAuthentication.SuspendLayout();
		this.SuspendLayout();
		//
		//pnlPassword
		//
		this.pnlPassword.Controls.Add(this.PictureBox4);
		this.pnlPassword.Controls.Add(this.txtPassword);
		this.pnlPassword.Controls.Add(this.lblPassword);
		this.pnlPassword.Controls.Add(this.Label2);
		this.pnlPassword.Controls.Add(this.PictureBox3);
		this.pnlPassword.Location = new System.Drawing.Point(2, 127);
		this.pnlPassword.Name = "pnlPassword";
		this.pnlPassword.Size = new System.Drawing.Size(401, 99);
		this.pnlPassword.TabIndex = 0;
		//
		//PictureBox4
		//
		this.PictureBox4.Image = (System.Drawing.Image)resources.GetObject("PictureBox4.Image");
		this.PictureBox4.Location = new System.Drawing.Point(30, 42);
		this.PictureBox4.Name = "PictureBox4";
		this.PictureBox4.Size = new System.Drawing.Size(32, 32);
		this.PictureBox4.TabIndex = 38;
		this.PictureBox4.TabStop = false;
		//
		//txtPassword
		//
		this.txtPassword.AutoSize = false;
		this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtPassword.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtPassword.Location = new System.Drawing.Point(194, 45);
		this.txtPassword.Name = "txtPassword";
		this.txtPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42);
		this.txtPassword.Size = new System.Drawing.Size(174, 24);
		this.txtPassword.TabIndex = 0;
		this.txtPassword.Text = "";
		//
		//lblPassword
		//
		this.lblPassword.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPassword.Location = new System.Drawing.Point(105, 48);
		this.lblPassword.Name = "lblPassword";
		this.lblPassword.Size = new System.Drawing.Size(80, 18);
		this.lblPassword.TabIndex = 1;
		this.lblPassword.Text = "Password";
		//
		//Label2
		//
		this.Label2.BackColor = System.Drawing.Color.Transparent;
		this.Label2.Location = new System.Drawing.Point(16, 17);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(84, 15);
		this.Label2.TabIndex = 2;
		this.Label2.Text = "Personilize";
		//
		//PictureBox3
		//
		this.PictureBox3.BackColor = System.Drawing.Color.Gray;
		this.PictureBox3.Location = new System.Drawing.Point(72, 26);
		this.PictureBox3.Name = "PictureBox3";
		this.PictureBox3.Size = new System.Drawing.Size(400, 1);
		this.PictureBox3.TabIndex = 34;
		this.PictureBox3.TabStop = false;
		//
		//pnlAuthentication
		//
		this.pnlAuthentication.Controls.Add(this.RBFile);
		this.pnlAuthentication.Controls.Add(this.RBLogin);
		this.pnlAuthentication.Controls.Add(this.txtUserName);
		this.pnlAuthentication.Controls.Add(this.lblUserName);
		this.pnlAuthentication.Controls.Add(this.PictureBox2);
		this.pnlAuthentication.Controls.Add(this.Label1);
		this.pnlAuthentication.Controls.Add(this.PictureBox1);
		this.pnlAuthentication.Location = new System.Drawing.Point(0, 0);
		this.pnlAuthentication.Name = "pnlAuthentication";
		this.pnlAuthentication.Size = new System.Drawing.Size(426, 120);
		this.pnlAuthentication.TabIndex = 1;
		//
		//RBFile
		//
		this.RBFile.Location = new System.Drawing.Point(110, 91);
		this.RBFile.Name = "RBFile";
		this.RBFile.Size = new System.Drawing.Size(208, 24);
		this.RBFile.TabIndex = 3;
		this.RBFile.Text = "Save as Private Authentication";
		//
		//RBLogin
		//
		this.RBLogin.Location = new System.Drawing.Point(110, 61);
		this.RBLogin.Name = "RBLogin";
		this.RBLogin.Size = new System.Drawing.Size(208, 24);
		this.RBLogin.TabIndex = 2;
		this.RBLogin.Text = "Save as Login Authentication";
		//
		//txtUserName
		//
		this.txtUserName.AutoSize = false;
		this.txtUserName.BackColor = System.Drawing.Color.White;
		this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtUserName.Cursor = System.Windows.Forms.Cursors.Default;
		this.txtUserName.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtUserName.Location = new System.Drawing.Point(195, 27);
		this.txtUserName.Name = "txtUserName";
		this.txtUserName.ReadOnly = true;
		this.txtUserName.Size = new System.Drawing.Size(176, 24);
		this.txtUserName.TabIndex = 1;
		this.txtUserName.Text = "";
		//
		//lblUserName
		//
		this.lblUserName.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblUserName.Location = new System.Drawing.Point(110, 31);
		this.lblUserName.Name = "lblUserName";
		this.lblUserName.Size = new System.Drawing.Size(80, 17);
		this.lblUserName.TabIndex = 0;
		this.lblUserName.Text = "User Name";
		//
		//PictureBox2
		//
		this.PictureBox2.BackColor = System.Drawing.Color.Gray;
		this.PictureBox2.Location = new System.Drawing.Point(107, 14);
		this.PictureBox2.Name = "PictureBox2";
		this.PictureBox2.Size = new System.Drawing.Size(374, 1);
		this.PictureBox2.TabIndex = 31;
		this.PictureBox2.TabStop = false;
		//
		//Label1
		//
		this.Label1.BackColor = System.Drawing.Color.Transparent;
		this.Label1.Location = new System.Drawing.Point(22, 5);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(84, 15);
		this.Label1.TabIndex = 0;
		this.Label1.Text = "Authentication";
		//
		//PictureBox1
		//
		this.PictureBox1.Image = (System.Drawing.Image)resources.GetObject("PictureBox1.Image");
		this.PictureBox1.Location = new System.Drawing.Point(34, 37);
		this.PictureBox1.Name = "PictureBox1";
		this.PictureBox1.Size = new System.Drawing.Size(32, 32);
		this.PictureBox1.TabIndex = 29;
		this.PictureBox1.TabStop = false;
		//
		//PictureBox5
		//
		this.PictureBox5.BackColor = System.Drawing.Color.Gray;
		this.PictureBox5.Location = new System.Drawing.Point(1, 223);
		this.PictureBox5.Name = "PictureBox5";
		this.PictureBox5.Size = new System.Drawing.Size(400, 1);
		this.PictureBox5.TabIndex = 36;
		this.PictureBox5.TabStop = false;
		//
		//btnOk
		//
		this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOk.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnOk.Image = (System.Drawing.Image)resources.GetObject("btnOk.Image");
		this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOk.Location = new System.Drawing.Point(141, 232);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(100, 30);
		this.btnOk.TabIndex = 37;
		this.btnOk.Text = "&OK";
		//
		//cmdCancel
		//
		this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cmdCancel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.cmdCancel.Image = (System.Drawing.Image)resources.GetObject("cmdCancel.Image");
		this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.cmdCancel.Location = new System.Drawing.Point(268, 232);
		this.cmdCancel.Name = "cmdCancel";
		this.cmdCancel.Size = new System.Drawing.Size(100, 30);
		this.cmdCancel.TabIndex = 38;
		this.cmdCancel.Text = "&Cancel";
		//
		//frmAuthentication
		//
		this.AcceptButton = this.btnOk;
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.CancelButton = this.cmdCancel;
		this.ClientSize = new System.Drawing.Size(402, 269);
		this.ControlBox = false;
		this.Controls.Add(this.cmdCancel);
		this.Controls.Add(this.btnOk);
		this.Controls.Add(this.PictureBox5);
		this.Controls.Add(this.pnlAuthentication);
		this.Controls.Add(this.pnlPassword);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		this.Name = "frmAuthentication";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Authentication";
		this.pnlPassword.ResumeLayout(false);
		this.pnlAuthentication.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region "Form Events"

	private void  // ERROR: Handles clauses are not supported in C#
RBFile_CheckedChanged(System.Object sender, System.EventArgs e)
	{
		try {
			if ((RBFile.Checked)) {
				pnlPassword.Visible = true;
				txtPassword.Focus();
				blnRBFileOptionCheck = true;
			} else {
				pnlPassword.Visible = false;
				blnRBFileOptionCheck = false;
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
			//objWait.Dispose()
			//---------------------------------------------------------
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
RBLogin_CheckedChanged(System.Object sender, System.EventArgs e)
	{
		try {
			if ((RBFile.Checked)) {
				pnlPassword.Visible = true;
				txtPassword.Focus();
				blnRBFileOptionCheck = true;
			} else {
				pnlPassword.Visible = false;
				blnRBFileOptionCheck = false;
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
			//objWait.Dispose()
			//---------------------------------------------------------
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
frmAuthentication_Load(object sender, System.EventArgs e)
	{
		txtPassword.Focus();
	}

	#End Region

	#Region "Private functions"

	//--------------------------------------------------------
	//    General functions used for Authentication/Digital Signature.
	//--- funcInitialize  - To Initialize the form and ask user for input parameters.
	//--- funcSaveNewUser - To Save Newly Created User.
	//--- funcSaveSignatureData - To Save the Records as Digital Signature in a class.

	public void subInitialize(DigitalSignature objDigitalSig)
	{
		//=====================================================================
		// Procedure Name        :   funcInitialize
		// Description           :   To Initialize the form and ask user for input parameters.
		// Purpose               :   To Initialize the form and ask user for input parameters.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh
		// Created               :   February, 2003 
		// Revisions             :
		//=====================================================================
		try {
			txtUserName.Text = objDigitalSig.UserName;
			//mobjDigitalSignature = objDigitalSig
			if (objDigitalSig.ActivityType == ENUM_ActivityType.FileAuthentication) {
				txtPassword.Focus();
				RBFile.Checked = true;
			// RBLogin.Checked = True
			} else {
				txtPassword.Focus();
				RBLogin.Checked = true;
				pnlPassword.Visible = false;
			}

			txtPassword.Text = "";


		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
		//gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
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

	//Private Function funcSaveSignatureData() As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcSaveSignatureData
	//    ' Description           :   To Save the Records as Digital Signature in a class.
	//    ' Purpose               :   To Save the Records as Digital Signature in a class.
	//    ' Parameters Passed     :   None.
	//    ' Returns               :   None.
	//    ' Parameters Affected   :   None.
	//    ' Assumptions           :
	//    ' Dependencies          :
	//    ' Author                :   Gitesh
	//    ' Created               :   February, 2003 
	//    ' Revisions             :
	//    '=====================================================================

	//    Dim intType As Integer

	//    Try
	//        If (RBLogin.Checked) Then
	//            intType = ENUM_ActivityType.LoginAuthentication
	//        End If
	//        If (RBFile.Checked) Then
	//            intType = ENUM_ActivityType.FileAuthentication
	//        End If

	//        mobjDigitalSignature.UserName = gstructUserDetails.UserName
	//        mobjDigitalSignature.UserID = gstructUserDetails.UserID
	//        mobjDigitalSignature.LoginPassword = gstructUserDetails.UserPassword

	//        mobjDigitalSignature.SaveDate = DateTime.Today
	//        mobjDigitalSignature.ActivityType = intType
	//        mobjDigitalSignature.FileName = mstrFileName

	//        If (intType = ENUM_ActivityType.LoginAuthentication) Then
	//            mobjDigitalSignature.FilePassword = ""
	//        Else
	//            mobjDigitalSignature.FilePassword = txtPassword.Text
	//        End If

	//        Return True
	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        '---------------------------------------------------------
	//        Return False
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try

	//End Function

	#End Region

	#Region "Global Function"

	//Private Function funcGetDigitalSignatureDetails() As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcGetDigitalSignatureDetails
	//    ' Description           :   To Display form and ask user for input parameters before saving a file.
	//    ' Purpose               :   To Display form and ask user for input parameters before saving a file.
	//    ' Parameters Passed     :   None.
	//    ' Returns               :   None.
	//    ' Parameters Affected   :   None.
	//    ' Assumptions           :
	//    ' Dependencies          :
	//    ' Author                :   Gitesh
	//    ' Created               :   February, 2003 
	//    ' Revisions             :
	//    '=====================================================================
	//    Dim objDS As New DigitalSignature

	//    Try
	//        Dim frmAuthentication As New frmAuthentication
	//        frmAuthentication.ShowDialog()
	//        If (frmAuthentication.DialogResult = DialogResult.OK) Then
	//            objDS = frmAuthentication.mobjDigitalSignature
	//            Return True
	//        Else
	//            Return False
	//        End If
	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
	//        '---------------------------------------------------------
	//        Return False
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try

	//End Function

	#End Region

	private void  // ERROR: Handles clauses are not supported in C#
txtPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
	{
		//If blncancelFlag = False And blnRBFileOptionCheck = True Then
		//    If txtPassword.Text = "" Then
		//        gobjMessageAdapter.ShowMessage("Password field cannot be Blank", "Note !", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
		//    End If
		//End If
	}

	private void  // ERROR: Handles clauses are not supported in C#
RBLogin_Click(object sender, System.EventArgs e)
	{
		blnRBFileOptionCheck = false;
	}

	private void  // ERROR: Handles clauses are not supported in C#
RBFile_Click(object sender, System.EventArgs e)
	{
		blnRBFileOptionCheck = true;
	}

	private void  // ERROR: Handles clauses are not supported in C#
btnOk_Click(System.Object sender, System.EventArgs e)
	{
		try {
			if (blnRBFileOptionCheck == true) {
				if (txtPassword.Text == "") {
					btnOk.DialogResult = DialogResult.None;
					gobjMessageAdapter.ShowMessage(constPasswordCannotBlank);
					return;
				}
			}
		//funcSaveSignatureData()
		//btnOk.DialogResult = DialogResult.OK

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
			//objWait.Dispose()
			//---------------------------------------------------------
		}

	}

	private void  // ERROR: Handles clauses are not supported in C#
cmdCancel_Click(System.Object sender, System.EventArgs e)
	{
		try {
			//If blnRBFileOptionCheck = True Then
			//If txtPassword.Text = "" Then
			cmdCancel.DialogResult = DialogResult.Cancel;
		//gobjMessageAdapter.ShowMessage("Note !", "Password field cannot be blank", modGlobalConstants.EnumMessageType.Information)



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
			//objWait.Dispose()
			//---------------------------------------------------------
		}

	}

}
