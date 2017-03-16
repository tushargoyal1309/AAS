namespace RS232SerialComm
{


	class modGeneralFunctions
	{

		#Region " General Functions "

		public bool gFuncShowMessage(string strMessageLabel, string strMessage, EnumMessageType MessageType)
		{
			//-----------------------------------  Procedure Header  -------------------------------
			//Procedure Name	    :   gFuncShowMessage
			//Description	    :   to show the formated message 
			//Parameters 	    :   strMessageLabel and Message
			//Time/Date  	    :   12.41 11/01/04
			//Dependencies	    :   
			//Author		        :   Mandar
			//Revision		    :
			//Revision by Person	:
			//--------------------------------------------------------------------------------------
			frmMessage1 objfrmMessage = new frmMessage1();
			bool blnFalg = false;

			try {
				gFuncShowMessage = false;
				objfrmMessage.lblMessage.Text = strMessage;
				objfrmMessage.Text = strMessageLabel;
				//objfrmMessage.lblMessageLabel.Text = strMessageLabel

				switch (MessageType) {
					case EnumMessageType.Information:
						objfrmMessage.picMessage.Image = objfrmMessage.ImgLstMessage.Images(0);
						objfrmMessage.cmdOk.Visible = true;
						objfrmMessage.cmdYes.Visible = false;
						objfrmMessage.cmdNo.Visible = false;
						//Application.DoEvents()
						//Application.DoEvents()
						if (objfrmMessage.ShowDialog() == objfrmMessage.DialogResult.OK) {
							blnFalg = true;
						} else {
							blnFalg = false;

						}
					case EnumMessageType.Question:
						objfrmMessage.picMessage.Image = objfrmMessage.ImgLstMessage.Images(1);
						objfrmMessage.cmdOk.Visible = false;
						objfrmMessage.cmdYes.Visible = true;
						objfrmMessage.cmdNo.Visible = true;

						if (objfrmMessage.ShowDialog == objfrmMessage.DialogResult.Yes) {
							blnFalg = true;
						} else {
							blnFalg = false;
						}
				}
				//Application.DoEvents()
				objfrmMessage.Dispose();
				objfrmMessage = null;
				//Application.DoEvents()
				gFuncShowMessage = blnFalg;

			} catch (Exception ex) {
				//---------------------------------------------------------
				//Error Handling and logging
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = ex.Message;
				gobjErrorHandler.WriteErrorLog(ex);
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

		#End Region

		#Region " .ini file Operations "

		//--- API declarations for reading the data from the INI file.

 // ERROR: Not supported in C#: DeclareDeclaration
		public string gFuncGetFromINI(string strSection, string strKeyValue, string strDefaultString, string StrINIFilePath)
		{
			//-----------------------------------  Procedure Header  -------------------------------
			//Procedure Name:    gFuncGetFromINI
			//Description:   To retrieve the key vale of a specified Section From INI
			//Parameters :   Section, Key , DefaultKeyValue, strFullPath of the INI
			//Time/Date  :   5/9/06
			//Dependencies:  INI File Should exist
			//Author:        Rahul B.
			//Revision: 
			//Revision by Person:
			//--------------------------------------------------------------------------------------
			Int32 intBffer = 255;
			string strReturnString = Space(intBffer);
			gFuncGetFromINI = "";

			try {
				//--- To get the specified key value
				GetPrivateProfileString(Trim(strSection), Trim(strKeyValue), Trim(strDefaultString), strReturnString, intBffer, Trim(StrINIFilePath));
				strReturnString = (string)Replace(Trim(strReturnString), Chr(0), "") + "";
				gFuncGetFromINI = strReturnString;

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
				//---------------------------------------------------------
			}

		}

		#End Region

	}
}
