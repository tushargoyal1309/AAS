using System;
using System.Web;
using System.Web.Mail;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports.ViewerObjectModel;


public class clsDataSetExport
{
	//**********************************************************************
	// File Header        
	// File Name 		: clsDataSetExport.vb
	// Author			: Mangesh Shardul
	// Date/Time			: 01-Mar-2005 8:00 pm
	// Description		: To export the report to Text or Htmal Format
	//**********************************************************************

	////-----
	////----

	#Region " Public Constants "

	public const string constWebReportExportFilePath = "\\WebReports";

	public const string constImagesFilePath = constWebReportExportFilePath + "\\Images";

	public const string constTextReportExportFilePath = "\\TextReports";
	public const string constHTMLFileExt = ".html";
	public const string constTEXTFileExt = ".txt";

	public const string constGraphImageFileExt = ".jpg";
	private const string constRowBGColor_SkyBlue = "#cde1fa";
	private const string constRowBGColor_LightBlue = "#e6efff";
	private const string constRowBGColor_DarkBlue = "#000080";

	private const string constRowBGColor_White = "#ffffff";
	#End Region

	////----- Private varailable 
	//Private mobjDataSet As DataSet1    'DataSet

	#Region " Public Shared Functions "


	public static void Export(DataSet ds)
	{
		System.Windows.Forms.SaveFileDialog objSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
		objSaveFileDialog.Filter = "File Xml (*.xml)|*.xml|File Html (*.htm)|*.htm|All Files (*.*)|*.*";
		objSaveFileDialog.Title = "Export Dataset";
		if (objSaveFileDialog.ShowDialog() == DialogResult.OK) {
			try {
				if (Right(objSaveFileDialog.FileName, 3).ToLower == "xml") {
					ExportXml(objSaveFileDialog.FileName, ds);
				} else {
					ExportHtml(objSaveFileDialog.FileName, ds);
				}
			} catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}
		}
		objSaveFileDialog.Dispose();
		objSaveFileDialog = null;
		GC.Collect();

	}


	public static void ExportXml(string strfileName, DataSet objDS)
	{
		objDS.WriteXml(strfileName);

	}


	public static void ExportHtml(string strReportNameIn, DataSet ds, string strReportHeaderIn = "", string strPageHeaderIn = "", string strPageTextIn = "", ArrayList objReportImageList = null, ArrayList arrImageCaptionListIn = null)
	{
		string strReportFilePath;
		System.IO.StreamWriter sw;
		System.IO.FileStream fs;
		int intCount;
		string[] strImgFilePaths;
		frmWebReportViewer objfrmWebReportViewer;

		try {
			strReportFilePath = Application.StartupPath + constWebReportExportFilePath;
			//--- Check for the folders if not create the folders
			if (!System.IO.Directory.Exists(strReportFilePath)) {
				//--- Create the folder
				System.IO.Directory.CreateDirectory(strReportFilePath);
			}
			strReportFilePath = strReportFilePath + "\\" + strReportNameIn;

			strReportFilePath = strReportFilePath + constHTMLFileExt;
			if (System.IO.File.Exists(strReportFilePath) == true) {
				System.IO.File.Delete(strReportFilePath);
			}

			fs = new System.IO.FileStream(strReportFilePath, IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);

			sw = funcDrawStartHtml(fs, ds.DataSetName);

			subDrawHtmlReportPageHeader(sw, strReportHeaderIn, strPageHeaderIn, strPageTextIn);

			subDrawHtmlTables(sw, ds);

			//---Save Bitmap objects to a file 
			 // ERROR: Not supported in C#: ReDimStatement

			for (intCount = 0; intCount <= objReportImageList.Count - 1; intCount++) {
				Image objReportImage = objReportImageList.Item(intCount);
				if (!IsNothing(objReportImage)) {
					//---Save Image and Add Images Path to show them on HTML Page
					strImgFilePaths(intCount) = funcSaveReportImages(objReportImage, strReportNameIn + intCount.ToString);
				}
			}

			if (!strImgFilePaths == null) {
				if (!strImgFilePaths.Length == 0) {
					subDrawHtmlImages(sw, strImgFilePaths, arrImageCaptionListIn);
				}
			}

			subDrawENDHtml(sw);

			//---To Show the Html Report in Web Browser
			objfrmWebReportViewer = new frmWebReportViewer(strReportFilePath);
			objfrmWebReportViewer.ShowDialog();
			objfrmWebReportViewer.Close();
			objfrmWebReportViewer.Dispose();
			objfrmWebReportViewer = null;

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

			objReportImageList = null;
			ds.Dispose();
			ds = null;
			sw = null;
			fs.Close();
			fs = null;
			//---------------------------------------------------------
		}

	}

	//Public Shared Sub SendEMail(ByVal ds As DataSet)

	//    Dim str As String
	//    str = InputBox("Insert Destination e-Mail Address", "Send e-Mail", "user@site.com")

	//    If str Is Nothing Or str = "" Then Return
	//    SendEMail("anonymous@anonymous.com", str, ds)

	//End Sub
	//Public Shared Sub SendEMail(ByVal FromAddress As String, ByVal ToAddress As String, ByVal ds As DataSet)
	//    Try
	//        Dim mail As New MailMessage
	//        mail.From = FromAddress
	//        mail.To = ToAddress
	//        mail.Subject = "Report"
	//        mail.Body = "The exported tables contained in the attachment."
	//        mail.BodyFormat = MailFormat.Text

	//        Dim fileName As String = System.IO.Path.GetTempPath() & "default.htm"

	//        Call ExportHtml(fileName, ds)

	//        Dim ma As New MailAttachment(fileName)
	//        mail.Attachments.Add(ma)
	//        SmtpMail.Send(mail)
	//        System.IO.File.Delete(fileName)

	//    Catch ex As Exception
	//        'CustomControls.InformationMessage("Errore nell'invio della Mail")
	//        MessageBox.Show(ex.Message)
	//    End Try

	//End Sub

	public static void ExportRTF(string strReportNameIn, DataSet dsText, DataSet ds, string strReportHeaderIn, string strPageHeaderIn, string strPageTextIn)
	{
		//=====================================================================
		// Procedure Name        : ExportRTF
		// Parameters Passed     : 
		// Returns               : 
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul At Machine SOFT1
		// Created               : Friday, March 04, 2005
		// Revisions             : 1
		//=====================================================================
		System.IO.FileStream fs;
		System.IO.BufferedStream bs;
		System.IO.StreamWriter sw;
		string strReportFilePath;

		try {
			strReportFilePath = Application.StartupPath + constTextReportExportFilePath;
			//--- Check for the folders if not create the folders
			if (!System.IO.Directory.Exists(strReportFilePath)) {
				//--- Create the folder
				System.IO.Directory.CreateDirectory(strReportFilePath);
			}
			strReportFilePath = strReportFilePath + "\\" + strReportNameIn;

			strReportFilePath = strReportFilePath + constTEXTFileExt;
			if (System.IO.File.Exists(strReportFilePath) == true) {
				System.IO.File.Delete(strReportFilePath);
			}

			fs = new System.IO.FileStream(strReportFilePath, IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
			bs = new System.IO.BufferedStream(fs);
			sw = new System.IO.StreamWriter(bs);

			//WriteLine(1, "Zone 1", TAB(), "Zone 2")     ' Print in two print zones.
			//WriteLine(1, "Hello", " ", "World")     ' Separate strings with space.
			sw.WriteLine("-----------------------------------------------------------------------------");
			sw.WriteLine(Space(10) + strReportHeaderIn + Space(10));
			sw.WriteLine("-----------------------------------------------------------------------------");
			sw.WriteLine(strPageHeaderIn);
			sw.WriteLine(strPageTextIn);
			sw.WriteLine("-----------------------------------------------------------------------------");
			sw.WriteLine();

			int i;
			int r;
			int c;
			int[] arrColSpace;
			int intSpaceBetweenColumns;
			////------  Text list
			for (i = 0; i <= dsText.Tables.Count - 1; i++) {
				//sw.WriteLine(Space(10) & dsText.Tables(i).TableName & Space(10))
				if (dsText.Tables(i).Rows.Count > 0) {
					sw.Write("{0}", dsText.Tables(i).Columns(0).Caption);
					intSpaceBetweenColumns = ((string)dsText.Tables(i).Columns(0).Caption).Length;
					sw.Write(Space(25 - intSpaceBetweenColumns));
					sw.Write("{0}", dsText.Tables(i).Rows(0).Item(0));
				} else {
					sw.WriteLine(Space(10) + ds.Tables(i).TableName + Space(10));
				}
				sw.WriteLine();
				sw.WriteLine("-----------------------------------------------------------------------------");
				for (r = 0; r <= dsText.Tables(i).Rows.Count - 1; r++) {
					//'sw.WriteLine("")
					for (c = 1; c <= dsText.Tables(i).Columns.Count - 1; c++) {
						sw.Write(Space(5));
						sw.Write("{0}", dsText.Tables(i).Columns(c).Caption);
						intSpaceBetweenColumns = ((string)dsText.Tables(i).Columns(c).Caption).Length;
						sw.Write(Space(25 - intSpaceBetweenColumns));
						sw.Write("{0}", dsText.Tables(i).Rows(r).Item(c));

						sw.WriteLine();
						//sw.Write("{0}", ds.Tables(i).Rows(r).Item(c))
						if (!IsDBNull(dsText.Tables(i).Rows(r).Item(c))) {
							intSpaceBetweenColumns = dsText.Tables(i).Columns.Item(c).ColumnName.Length - ((string)dsText.Tables(i).Rows(r).Item(c)).Length;
						} else {
							intSpaceBetweenColumns = dsText.Tables(i).Columns.Item(c).ColumnName.Length;
						}
						//If arrColSpace(c) > 5 Then
						//    intSpaceBetweenColumns = arrColSpace(c) - CStr(dsText.Tables(i).Rows(r).Item(c)).Length - 5
						//End If

						//If Not intSpaceBetweenColumns < 0 Then
						//    sw.Write(Space(intSpaceBetweenColumns))
						//End If

						//sw.Write(Space(5))
					}
					sw.WriteLine();
				}
				sw.WriteLine();
			}
			////------  Text list


			intSpaceBetweenColumns = 0;
			for (i = 0; i <= ds.Tables.Count - 1; i++) {
				sw.WriteLine(Space(10) + ds.Tables(i).TableName + Space(10));
				sw.WriteLine("-----------------------------------------------------------------------------");
				for (c = 0; c <= ds.Tables(i).Columns.Count - 1; c++) {
					sw.Write("{0}", ds.Tables(i).Columns(c).Caption);
					//sw.Write(Space(10)) 'Saurabh Changed from (5) to (10)
					if (c == 0) {
						intSpaceBetweenColumns = ds.Tables(i).Columns(c).Caption.Length + 9;
						//Saurabh Changed from (5) to (9)
					//intSpaceBetweenColumns = 12 - intSpaceBetweenColumns
					} else {
						intSpaceBetweenColumns = ds.Tables(i).Columns(c).Caption.Length + 12;
						//Saurabh Changed from (5) to (9)
						if (intSpaceBetweenColumns < 15) {
							intSpaceBetweenColumns = ds.Tables(i).Columns(c).Caption.Length;
							// intSpaceBetweenColumns
						} else {
							intSpaceBetweenColumns = (13 - ds.Tables(i).Columns(c).Caption.Length) + ds.Tables(i).Columns(c).Caption.Length;
							// intSpaceBetweenColumns
						}
					}
					//sw.Write(Space(intSpaceBetweenColumns - 15))
					Array.Resize(ref arrColSpace, c + 2);
					if (intSpaceBetweenColumns > 5) {
						sw.Write(Space(intSpaceBetweenColumns - 11));
						arrColSpace(c) = intSpaceBetweenColumns - 10;
					} else {
						sw.Write(Space((5 - intSpaceBetweenColumns) + 5));
						//arrColSpace(c) = 5
						arrColSpace(c) = ((7 - intSpaceBetweenColumns) + 5);
					}
				}
				sw.WriteLine();
				sw.WriteLine("-----------------------------------------------------------------------------");
				for (r = 0; r <= ds.Tables(i).Rows.Count - 1; r++) {
					//'sw.WriteLine("")
					for (c = 0; c <= ds.Tables(i).Columns.Count - 1; c++) {
						sw.Write("{0}", ds.Tables(i).Rows(r).Item(c));

						if (c == 0) {
							intSpaceBetweenColumns = 20 - ((string)ds.Tables(i).Rows(r).Item(c)).Length;
						} else {
							if (!IsDBNull(ds.Tables(i).Rows(r).Item(c))) {
								intSpaceBetweenColumns = ds.Tables(i).Columns.Item(c).ColumnName.Length - ((string)ds.Tables(i).Rows(r).Item(c)).Length;
								if (arrColSpace(c) > 5) {
									intSpaceBetweenColumns = arrColSpace(c) - ((string)ds.Tables(i).Rows(r).Item(c)).Length;
								}
							} else {
								intSpaceBetweenColumns = ds.Tables(i).Columns.Item(c).ColumnName.Length;
								if (arrColSpace(c) > 5) {
									intSpaceBetweenColumns = arrColSpace(c) - ds.Tables(i).Columns.Item(c).ColumnName.Length - 5;
								}
							}
						}

						if (!intSpaceBetweenColumns < 0) {
							sw.Write(Space(intSpaceBetweenColumns));
						} else {
							sw.Write(Space(arrColSpace(c) + intSpaceBetweenColumns));
						}

						//sw.Write(Space(5))
						//sw.Write(Space(arrColSpace(c)))

					}
					sw.WriteLine();
				}
				sw.WriteLine();
			}
			sw.WriteLine("-----------------------------------------------------------------------------");
			sw.WriteLine();

			sw.Close();

			//---To Show the Html Report in Web Browser
			frmTextReportViewer objfrmTextReportViewer;
			objfrmTextReportViewer = new frmTextReportViewer();
			objfrmTextReportViewer.ReportFilePath = strReportFilePath;

			objfrmTextReportViewer.ShowDialog();
			objfrmTextReportViewer.Close();
			objfrmTextReportViewer.Dispose();
			objfrmTextReportViewer = null;

		} catch (Exception ex) {
			//------------------------------------------------------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			sw.Close();
			bs.Close();
			fs.Close();
			ds.Dispose();
		//------------------------------------------------------------------------------------------------------
		} finally {
			//------------------------------------------------------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			sw.Close();
			bs.Close();
			fs.Close();
			ds.Dispose();
			//------------------------------------------------------------------------------------------------------
		}
	}

	public static void DatafileReportExportRTF(string strReportNameIn, DataSet dsText, DataSet ds, string strReportHeaderIn, string strPageHeaderIn, string strPageTextIn, string strReportFooterIn)
	{
		//=====================================================================
		// Procedure Name        : ExportRTF
		// Parameters Passed     : 
		// Returns               : 
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul At Machine SOFT1
		// Created               : Friday, March 04, 2005
		// Revisions             : 1
		//=====================================================================
		System.IO.FileStream fs;
		System.IO.BufferedStream bs;
		System.IO.StreamWriter sw;
		AAS203Library.Method.clsReportParameters objReportParameter = new AAS203Library.Method.clsReportParameters();
		string strReportFilePath;

		try {
			funcExportData(strReportNameIn, dsText, ds, strReportHeaderIn, strPageHeaderIn, strPageTextIn, strReportFooterIn, objReportParameter);
			return;
			strReportFilePath = Application.StartupPath + constTextReportExportFilePath;
			//--- Check for the folders if not create the folders
			if (!System.IO.Directory.Exists(strReportFilePath)) {
				//--- Create the folder
				System.IO.Directory.CreateDirectory(strReportFilePath);
			}
			strReportFilePath = strReportFilePath + "\\" + strReportNameIn;

			strReportFilePath = strReportFilePath + constTEXTFileExt;
			if (System.IO.File.Exists(strReportFilePath) == true) {
				System.IO.File.Delete(strReportFilePath);
			}

			fs = new System.IO.FileStream(strReportFilePath, IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
			bs = new System.IO.BufferedStream(fs);
			sw = new System.IO.StreamWriter(bs);

			//WriteLine(1, "Zone 1", TAB(), "Zone 2")     ' Print in two print zones.
			//WriteLine(1, "Hello", " ", "World")     ' Separate strings with space.
			sw.WriteLine("-------------------------------------------------------------------------------------------------");
			sw.WriteLine(Space(10) + strReportHeaderIn + Space(10));
			sw.WriteLine("-------------------------------------------------------------------------------------------------");
			sw.WriteLine(strPageHeaderIn);
			sw.WriteLine(strPageTextIn);
			sw.WriteLine("-------------------------------------------------------------------------------------------------");
			sw.WriteLine();

			int i;
			int r;
			int c;
			int[] arrColSpace;
			int intSpaceBetweenColumns;
			////------  Text list
			for (i = 0; i <= dsText.Tables.Count - 1; i++) {
				//sw.WriteLine(Space(10) & dsText.Tables(i).TableName & Space(10))
				if (dsText.Tables(i).Rows.Count > 0) {
					sw.Write("{0}", dsText.Tables(i).Columns(0).Caption);
					intSpaceBetweenColumns = ((string)dsText.Tables(i).Columns(0).Caption).Length;
					sw.Write(Space(25 - intSpaceBetweenColumns));
					sw.Write("{0}", dsText.Tables(i).Rows(0).Item(0));
				} else {
					sw.WriteLine(Space(10) + ds.Tables(i).TableName + Space(10));
				}
				sw.WriteLine();
				sw.WriteLine("-------------------------------------------------------------------------------------------------");
				for (r = 0; r <= dsText.Tables(i).Rows.Count - 1; r++) {
					//'sw.WriteLine("")
					for (c = 1; c <= dsText.Tables(i).Columns.Count - 1; c++) {
						sw.Write(Space(5));
						sw.Write("{0}", dsText.Tables(i).Columns(c).Caption);
						intSpaceBetweenColumns = ((string)dsText.Tables(i).Columns(c).Caption).Length;
						sw.Write(Space(25 - intSpaceBetweenColumns));
						sw.Write("{0}", dsText.Tables(i).Rows(r).Item(c));

						sw.WriteLine();
						//sw.Write("{0}", ds.Tables(i).Rows(r).Item(c))
						if (!IsDBNull(dsText.Tables(i).Rows(r).Item(c))) {
							intSpaceBetweenColumns = dsText.Tables(i).Columns.Item(c).ColumnName.Length - ((string)dsText.Tables(i).Rows(r).Item(c)).Length;
						} else {
							intSpaceBetweenColumns = dsText.Tables(i).Columns.Item(c).ColumnName.Length;
						}
						//If arrColSpace(c) > 5 Then
						//    intSpaceBetweenColumns = arrColSpace(c) - CStr(dsText.Tables(i).Rows(r).Item(c)).Length - 5
						//End If

						//If Not intSpaceBetweenColumns < 0 Then
						//    sw.Write(Space(intSpaceBetweenColumns))
						//End If

						//sw.Write(Space(5))
					}
					sw.WriteLine();
				}
				sw.WriteLine();
			}
			////------  Text list

			string[] ColsRow1;
			string[] ColsRow2;

			intSpaceBetweenColumns = 0;
			for (i = 0; i <= ds.Tables.Count - 1; i++) {
				sw.WriteLine(Space(10) + ds.Tables(i).TableName + Space(10));
				sw.WriteLine("-------------------------------------------------------------------------------------------------");
				 // ERROR: Not supported in C#: ReDimStatement

				 // ERROR: Not supported in C#: ReDimStatement

				int x;
				for (c = 0; c <= ds.Tables(i).Columns.Count - 1; c++) {
					for (x = 0; x <= 1; x++) {
						if (x == 0) {

							if (ds.Tables(i).Columns(c).Caption.Length > 12) {

							} else {
								//ColsRow1()
							}

						} else {
						}



					}
					//sw.Write("{0}", ds.Tables(i).Columns(c).Caption)
					//sw.Write(Space(10)) 'Saurabh Changed from (5) to (10)

					//If c = 0 Then
					//    If ds.Tables(i).Columns(c).Caption.Length > 12 Then

					//    End If

					//    intSpaceBetweenColumns = ds.Tables(i).Columns(c).Caption.Length + 10 'Saurabh Changed from (5) to (9)

					//Else
					//    intSpaceBetweenColumns = ds.Tables(i).Columns(c).Caption.Length + 12 'Saurabh Changed from (5) to (9)
					//    If intSpaceBetweenColumns < 15 Then
					//        intSpaceBetweenColumns = ds.Tables(i).Columns(c).Caption.Length ' intSpaceBetweenColumns
					//    Else
					//        intSpaceBetweenColumns = (13 - ds.Tables(i).Columns(c).Caption.Length) + ds.Tables(i).Columns(c).Caption.Length ' intSpaceBetweenColumns
					//    End If
					//End If
					//'sw.Write(Space(intSpaceBetweenColumns - 15))
					//ReDim Preserve arrColSpace(c + 1)
					//If intSpaceBetweenColumns > 5 Then
					//    sw.Write(Space(intSpaceBetweenColumns - 11))
					//    arrColSpace(c) = intSpaceBetweenColumns - 11
					//Else
					//    sw.Write(Space((5 - intSpaceBetweenColumns) + 5))
					//    'arrColSpace(c) = 5
					//    arrColSpace(c) = ((5 - intSpaceBetweenColumns) + 5)
					//End If
				}

				sw.WriteLine();
				sw.WriteLine("-------------------------------------------------------------------------------------------------");
				for (r = 0; r <= ds.Tables(i).Rows.Count - 1; r++) {
					//'sw.WriteLine("")
					for (c = 0; c <= ds.Tables(i).Columns.Count - 1; c++) {
						sw.Write("{0}", ds.Tables(i).Rows(r).Item(c));


						if (!IsDBNull(ds.Tables(i).Rows(r).Item(c))) {
							intSpaceBetweenColumns = ds.Tables(i).Columns.Item(c).ColumnName.Length - ((string)ds.Tables(i).Rows(r).Item(c)).Length;
							if (arrColSpace(c) > 5) {
								intSpaceBetweenColumns = arrColSpace(c) - ((string)ds.Tables(i).Rows(r).Item(c)).Length - 5;
							}
						} else {
							intSpaceBetweenColumns = ds.Tables(i).Columns.Item(c).ColumnName.Length;
							if (arrColSpace(c) > 5) {
								intSpaceBetweenColumns = arrColSpace(c) - ds.Tables(i).Columns.Item(c).ColumnName.Length - 5;
							}
						}


						if (!intSpaceBetweenColumns < 0) {
							sw.Write(Space(intSpaceBetweenColumns));
						}

						sw.Write(Space(5));
					}
					sw.WriteLine();
				}
				sw.WriteLine();
			}
			sw.WriteLine("-------------------------------------------------------------------------------------------------");
			sw.WriteLine();

			sw.Close();

			//---To Show the Html Report in Web Browser
			frmTextReportViewer objfrmTextReportViewer;
			objfrmTextReportViewer = new frmTextReportViewer();
			objfrmTextReportViewer.ReportFilePath = strReportFilePath;

			objfrmTextReportViewer.ShowDialog();
			objfrmTextReportViewer.Close();
			objfrmTextReportViewer.Dispose();
			objfrmTextReportViewer = null;

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
			if (!(sw == null))
				sw.Close();
			if (!(bs == null))
				bs.Close();
			if (!(fs == null))
				fs.Close();
			if (!(ds == null))
				ds.Dispose();
			//---------------------------------------------------------
		}
	}


	public static void ExportText(string strfileName, DataSet dsText, DataSet ds, string strReportHeaderIn = "", string strPageHeaderIn = "", string strPageTextIn = "")
	{
		try {
			ExportRTF(strfileName, ds, dsText, strReportHeaderIn, strPageHeaderIn, strPageTextIn);

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

	public static bool funcExportData(string strReportNameIn, DataSet dsText, DataSet ds, string strReportHeaderIn, string strPageHeaderIn, string strPageTextIn, string strReportFooterIn, AAS203Library.Method.clsReportParameters objReportParameter)
	{
		//Dim objDataSet As DataSet

		DataRptExport objDatafileExportCryReport = new DataRptExport();
		string strInstInfos;
		TextObject TxtPageFooter;
		string strAppVersion;
		//aa = objCryReport.Section3.ReportObjects("Text1").Name

		//--- Initialising Connection 

		DataSet1 mobjDataSet;
		//DataSet
		DataTable mobjDt;
		int intCount;
		int intColCount;
		DataSet1.StdSampInfoRow objDrCDNewRow;
		SaveFileDialog objSaveFileDlg = new SaveFileDialog();
		bool blnIsEmiMode = false;
		bool blnIsUnitinPPM = true;
		TextObject TxtAbs;
		TextObject TxtConcinUnit;
		//Dim gobjDataSet As New DataSet

		//// Connect to, fetch data, and disconnect from database 
		try {
			mobjDataSet = new DataSet1();
			mobjDt = new DataTable();
			mobjDt = gobjDataAccess.GetStdSampInfo;
			for (intCount = 0; intCount <= ds.Tables(0).Rows.Count - 1; intCount++) {
				objDrCDNewRow = mobjDataSet.StdSampInfo.NewStdSampInfoRow;
				for (intColCount = 0; intColCount <= ds.Tables(0).Rows(intCount).ItemArray.Length - 1; intColCount++) {
					if (intColCount == 0) {
						objDrCDNewRow.Item(intColCount) = ds.Tables(0).Rows(intCount).Item(intColCount);
					} else {
						if (IsNumeric(ds.Tables(0).Rows(intCount).Item(intColCount))) {
							objDrCDNewRow.Item(intColCount) = ds.Tables(0).Rows(intCount).Item(intColCount);
						} else {
							objDrCDNewRow.Item(intColCount) = 0.0;
						}
					}
				}
				//gobjDataSet.CustomerDetails.AddCustomerDetailsRow(objDrCDNewRow)
				mobjDataSet.StdSampInfo.AddStdSampInfoRow(objDrCDNewRow);
			}
			//mobjDataSet.
			//objDatafileExportCryReport.SetDataSource(objDataSet)
			objDatafileExportCryReport.SetDataSource(mobjDataSet);
			//objCryReport.Section2.SectionFormat.EnableSuppress = True
			////---------------------------------------------------
			////------  Text list

			string[] ColsRow1;
			string[] ColsRow2;
			int inttbIdx;
			int intColIdx;
			TextObject objSec1Hdr1;
			TextObject objTxtRunNo;
			TextObject objTxtAnalysedOn;
			bool blnIsShowMethodDefinition;
			bool blnIsShowAnalysisParameters;
			bool blnIsShowInstrumentConditions;
			TextObject TxtReportHeader;
			TextObject TxtReportFooter;
			bool blnIsUVMethod;

			//intSpaceBetweenColumns = 0
			for (inttbIdx = 0; inttbIdx <= dsText.Tables.Count - 1; inttbIdx++) {
				//ReDim ColsRow1(ds.Tables(i).Columns.Count)
				//ReDim ColsRow2(ds.Tables(i).Columns.Count)
				//Dim x As Integer
				if (dsText.Tables(inttbIdx).TableName == "Quantitative Report") {
					for (intColIdx = 0; intColIdx <= dsText.Tables(inttbIdx).Columns.Count - 1; intColIdx++) {
						//Quantitative Report for
						if (intColIdx == 0) {

							objSec1Hdr1 = objDatafileExportCryReport.Section14.ReportObjects("Sec1Hdr1");
							objSec1Hdr1.Text = dsText.Tables(inttbIdx).Columns(0).Caption() + vbTab + dsText.Tables(inttbIdx).Rows.Item(0).Item(0);
						}
						//Run No
						if (intColIdx == 1) {

							objTxtRunNo = objDatafileExportCryReport.Section14.ReportObjects("TxtRunNo");
							objTxtRunNo.Text = dsText.Tables(inttbIdx).Columns(1).Caption() + vbTab + dsText.Tables(inttbIdx).Rows.Item(0).Item(1);
						}
						//Analysed On
						if (intColIdx == 2) {
							objTxtAnalysedOn = objDatafileExportCryReport.Section14.ReportObjects("TxtAnalysedOn");
							//objDatafileExportCryReport.s()
							objTxtAnalysedOn.Text = dsText.Tables(inttbIdx).Columns(2).Caption() + vbTab + dsText.Tables(inttbIdx).Rows.Item(0).Item(2);
						}
					}
				}
				if (dsText.Tables(inttbIdx).TableName == "MethodDefination") {
					blnIsShowMethodDefinition = true;
					TextObject TxtMethodDefinition;
					TextObject TxtMethodDefinitionDetals1;
					TextObject TxtMethodDefinitionDetals2;
					TextObject TxtCreatedby;
					TextObject TxtChanged;
					TextObject TxtComments;
					TextObject TxtCreatedon;
					TextObject TxtLastusedon;


					for (intColIdx = 0; intColIdx <= dsText.Tables(inttbIdx).Columns.Count - 1; intColIdx++) {
						//Method Title
						if (intColIdx == 0) {
							TxtMethodDefinition = objDatafileExportCryReport.Section15.ReportObjects("TxtMethodDefinition");
							//    TxtMethodDefinition = dsText.Tables(inttbIdx).Columns("MethodDefination").Caption & vbTab & dsText.Tables(inttbIdx).Rows.Item(0).Item(0)
							TxtMethodDefinition.Text = dsText.Tables(inttbIdx).Columns(0).Caption + vbTab + dsText.Tables(inttbIdx).Rows.Item(0).Item(0);
						}
						if (UCase(dsText.Tables(inttbIdx).Rows.Item(0).Item(0)) == "UV MODE") {
							blnIsUVMethod = true;
						}
						if (UCase(dsText.Tables(inttbIdx).Rows.Item(0).Item(0)) == "EMISSION MODE") {
							blnIsEmiMode = true;
						}

						//Method Name
						if (intColIdx == 1) {
							TxtMethodDefinitionDetals1 = objDatafileExportCryReport.Section15.ReportObjects("TxtMethodDefinitionDetails1");
							TxtMethodDefinitionDetals1.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(1);
						}
						//Status
						if (intColIdx == 2) {
							TxtMethodDefinitionDetals2 = objDatafileExportCryReport.Section15.ReportObjects("TxtMethodDefinitionDetails2");
							TxtMethodDefinitionDetals2.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(2);
						}
						//Created by
						if (intColIdx == 3) {
							TxtCreatedby = objDatafileExportCryReport.Section15.ReportObjects("TxtCreated");
							//TxtMethodDefinitionDetals2 = objDatafileExportCryReport.Section2.ReportObjects("TxtCreatedby")
							TxtCreatedby.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(3);
						}
						//Created on
						if (intColIdx == 4) {
							TxtChanged = objDatafileExportCryReport.Section15.ReportObjects("TxtCreatedon");
							//TxtMethodDefinitionDetals2 = objDatafileExportCryReport.Section2.ReportObjects("TxtCreatedby")
							TxtChanged.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(4);
						}
						//changed on
						if (intColIdx == 5) {
							TxtChanged = objDatafileExportCryReport.Section15.ReportObjects("TxtChanged");
							//TxtMethodDefinitionDetals2 = objDatafileExportCryReport.Section2.ReportObjects("TxtCreatedby")
							TxtChanged.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(5);
						}
						//Last used on
						if (intColIdx == 6) {
							TxtLastusedon = objDatafileExportCryReport.Section15.ReportObjects("TxtLastusedon");
							//TxtMethodDefinitionDetals2 = objDatafileExportCryReport.Section2.ReportObjects("TxtCreatedby")
							TxtLastusedon.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(6);
						}

						//Commented
						if (intColIdx == 7) {
							TxtComments = objDatafileExportCryReport.Section15.ReportObjects("TxtComments");
							//TxtMethodDefinitionDetals2 = objDatafileExportCryReport.Section2.ReportObjects("TxtCreatedby")
							TxtComments.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(7);
						}
					}

				}
				if (dsText.Tables(inttbIdx).TableName == "AnalysisParameters") {
					blnIsShowAnalysisParameters = true;
					TextObject TxtAnalysisParameters;
					TextObject TxtAnalysisParametersDetails1;
					TextObject TxtAnalysisParametersDetails2;
					TextObject TxtMeasurement;
					TextObject TxtIntegrationTime;
					TextObject TxtNoofSample;
					TextObject TxtBlankEverySample;
					TextObject TxtResultAccuracy;
					TextObject TxtUnitofresults;
					TextObject TxtStandardAddition;

					for (intColIdx = 0; intColIdx <= dsText.Tables(inttbIdx).Columns.Count - 1; intColIdx++) {
						//If intColIdx = 0 Then   'Method Title
						//    TxtAnalysisParameters = objDatafileExportCryReport.Section7.ReportObjects("TxtAnalysisParametersDetails1")
						//    TxtAnalysisParameters = dsText.Tables(inttbIdx).Columns("Method Definition").Caption & vbTab & dsText.Tables(inttbIdx).Rows.Item(0).Item(0)
						//End If
						//Analys't Name
						if (intColIdx == 1) {
							TxtAnalysisParametersDetails1 = objDatafileExportCryReport.Section16.ReportObjects("TxtAnalysisParametersDetails1");
							TxtAnalysisParametersDetails1.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(1) + " ";
						}
						//Lab Name
						if (intColIdx == 2) {
							TxtAnalysisParametersDetails2 = objDatafileExportCryReport.Section16.ReportObjects("TxtAnalysisParametersDetails2");
							TxtAnalysisParametersDetails2.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(2);
						}
						//Measurement
						if (intColIdx == 3) {
							TxtMeasurement = objDatafileExportCryReport.Section16.ReportObjects("TxtMeasurement");
							//TxtMethodDefinitionDetals2 = objDatafileExportCryReport.Section2.ReportObjects("TxtCreatedby")
							TxtMeasurement.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(3);
						}
						//Result Accuracy 
						if (intColIdx == 4) {
							TxtResultAccuracy = objDatafileExportCryReport.Section16.ReportObjects("TxtResultAccuracy");
							//TxtMethodDefinitionDetals2 = objDatafileExportCryReport.Section2.ReportObjects("TxtCreatedby")
							TxtResultAccuracy.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(4);
						}
						//Integration Time
						if (intColIdx == 5) {
							TxtIntegrationTime = objDatafileExportCryReport.Section16.ReportObjects("TxtIntegrationTime");
							TxtIntegrationTime.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(5);
						}
						//Unit of Result
						if (intColIdx == 6) {
							TxtUnitofresults = objDatafileExportCryReport.Section16.ReportObjects("TxtUnitofresults");
							//TxtMethodDefinitionDetals2 = objDatafileExportCryReport.Section2.ReportObjects("TxtCreatedby")
							TxtUnitofresults.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(6);
						}
						// No. of Sample
						if (intColIdx == 7) {
							TxtNoofSample = objDatafileExportCryReport.Section16.ReportObjects("TxtNoofSample");
							//TxtMethodDefinitionDetals2 = objDatafileExportCryReport.Section2.ReportObjects("TxtCreatedby")
							TxtNoofSample.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(7);
						}
						//Standard Addition 
						if (intColIdx == 8) {
							TxtStandardAddition = objDatafileExportCryReport.Section16.ReportObjects("TxtStandardAddition");
							//TxtMethodDefinitionDetals2 = objDatafileExportCryReport.Section2.ReportObjects("TxtCreatedby")
							TxtStandardAddition.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(8);
						}
						//Blank after every Sample
						if (intColIdx == 9) {
							TxtBlankEverySample = objDatafileExportCryReport.Section16.ReportObjects("TxtBlankEverySample");
							//TxtMethodDefinitionDetals2 = objDatafileExportCryReport.Section2.ReportObjects("TxtCreatedby")
							TxtBlankEverySample.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(9);
						}
					}
				}

				if (dsText.Tables(inttbIdx).TableName == "Instrument Condition") {
					blnIsShowInstrumentConditions = true;
					TextObject TxtInstrumentCondition;
					TextObject TxtInstrumentConditionDetails1;
					TextObject TxtInstrumentConditionDetails2;
					TextObject TxtCurrent;
					TextObject TxtD2Cur;
					TextObject TxtPMT;
					TextObject TxtRefPMT;
					TextObject TxtFuel;
					TextObject TxtBurner;
					TextObject TxtSlit;
					TextObject TxtExitSlit;
					TextObject lblInstrument1;
					string strlblInstrument1;

					//lblInstrument1 = objDatafileExportCryReport.Section8.ReportObjects("lblInstrument1")
					//strlblInstrument1 = lblInstrument1.Text
					//strlblInstrument1 = strlblInstrument1.Substring(0, strlblInstrument1.Length - Len("Ref. PMT (v)"))
					//lblInstrument1.Text = strlblInstrument1
					objDatafileExportCryReport.Refresh();
					if (blnIsUVMethod == true) {
						objDatafileExportCryReport.Section19.SectionFormat.EnableSuppress = false;
						objDatafileExportCryReport.Section18.SectionFormat.EnableSuppress = true;


						for (intColIdx = 0; intColIdx <= dsText.Tables(inttbIdx).Columns.Count - 1; intColIdx++) {
							//Instrument Conditions for 
							if (intColIdx == 0) {
								TxtInstrumentCondition = objDatafileExportCryReport.Section19.ReportObjects("TxtInstrumentConditions1");
								TxtInstrumentCondition.Text = dsText.Tables(inttbIdx).Columns(0).Caption + vbTab + dsText.Tables(inttbIdx).Rows.Item(0).Item(0);
							}

							if (intColIdx == 1) {
								TxtInstrumentConditionDetails1 = objDatafileExportCryReport.Section19.ReportObjects("TxtInstrumentConditionsDetails3");
								TxtInstrumentConditionDetails1.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(1);
							}
							//Wavelength (nm)
							if (intColIdx == 2) {
								TxtInstrumentConditionDetails2 = objDatafileExportCryReport.Section19.ReportObjects("TxtInstrumentConditionsDetails4");
								TxtInstrumentConditionDetails2.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(2);
							}
							//Current (mA)
							if (intColIdx == 3) {
								TxtSlit = objDatafileExportCryReport.Section19.ReportObjects("TxtSlit1");
								TxtSlit.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(3);
							}
							//Fuel (Litre/min)
							if (intColIdx == 4) {
								TxtD2Cur = objDatafileExportCryReport.Section19.ReportObjects("TxtD2Cur1");
								TxtD2Cur.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(4);
							}
							//D2 Cur (mA)
							if (intColIdx == 5) {
								TxtPMT = objDatafileExportCryReport.Section19.ReportObjects("TxtPMT1");
								TxtPMT.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(5);
							}
						}
					} else {
						objDatafileExportCryReport.Section19.SectionFormat.EnableSuppress = true;
						objDatafileExportCryReport.Section18.SectionFormat.EnableSuppress = false;

						for (intColIdx = 0; intColIdx <= dsText.Tables(inttbIdx).Columns.Count - 1; intColIdx++) {
							//Instrument Conditions for 
							if (intColIdx == 0) {
								TxtInstrumentCondition = objDatafileExportCryReport.Section18.ReportObjects("TxtInstrumentConditions");
								TxtInstrumentCondition.Text = dsText.Tables(inttbIdx).Columns(0).Caption + vbTab + dsText.Tables(inttbIdx).Rows.Item(0).Item(0);
							}

							//Turret No
							if (intColIdx == 1) {
								TxtInstrumentConditionDetails1 = objDatafileExportCryReport.Section18.ReportObjects("TxtInstrumentConditionsDetails1");
								TxtInstrumentConditionDetails1.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(1);
							}
							//Wavelength (nm)
							if (intColIdx == 2) {
								TxtInstrumentConditionDetails2 = objDatafileExportCryReport.Section18.ReportObjects("TxtInstrumentConditionsDetails2");
								TxtInstrumentConditionDetails2.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(2);
							}
							//Current (mA)
							if (intColIdx == 3) {
								TxtCurrent = objDatafileExportCryReport.Section18.ReportObjects("TxtCurrent");
								TxtCurrent.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(3);
							}
							//Fuel (Litre/min)
							if (intColIdx == 4) {
								TxtFuel = objDatafileExportCryReport.Section18.ReportObjects("TxtFuel");
								TxtFuel.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(4);
							}
							//D2 Cur (mA)
							if (intColIdx == 5) {
								TxtD2Cur = objDatafileExportCryReport.Section18.ReportObjects("TxtD2Cur");
								TxtD2Cur.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(5);
							}
							//Burner Height (mm)
							if (intColIdx == 6) {
								TxtBurner = objDatafileExportCryReport.Section18.ReportObjects("TxtBurner");
								TxtBurner.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(6);
							}
							//PMT (v)
							if (intColIdx == 7) {
								TxtPMT = objDatafileExportCryReport.Section18.ReportObjects("TxtPMT");
								TxtPMT.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(7);
							}
							//Slit (nm)
							if (intColIdx == 8) {
								TxtSlit = objDatafileExportCryReport.Section18.ReportObjects("TxtSlit");
								TxtSlit.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(8);
							}
							//Ref. PMT (v)
							if (intColIdx == 9) {
								TxtRefPMT = objDatafileExportCryReport.Section18.ReportObjects("TxtRefPMT");
								TxtRefPMT.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(9);
							}
							//Exit Slit (nm)
							if (intColIdx == 10) {
								TxtExitSlit = objDatafileExportCryReport.Section18.ReportObjects("TxtExitSlit");
								TxtExitSlit.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(10);
							}
						}
					}
				}
				if (dsText.Tables(inttbIdx).TableName == "Calculation Mode") {
					TextObject TxtCalculationMode;
					for (intColIdx = 0; intColIdx <= dsText.Tables(inttbIdx).Columns.Count - 1; intColIdx++) {
						//Calculation Mode
						if (intColIdx == 0) {
							TxtCalculationMode = objDatafileExportCryReport.Section20.ReportObjects("TxtCalculationMode");
							TxtCalculationMode.Text = dsText.Tables(inttbIdx).Columns(1).Caption + vbTab + dsText.Tables(inttbIdx).Rows.Item(0).Item(1);
						}
					}
				}
			}

			inttbIdx = 0;

			if (blnIsEmiMode == true) {
				TxtAbs = objDatafileExportCryReport.Section10.ReportObjects("TxtAbs");
				//TxtAbs.Text = "%Emission"
				TxtAbs.Text = Space(4) + "%E";
				// Added by Deepak Bhati with ref. to VCK/Ramesh on 26.07.09
			}

			//code commented by : dinesh wagh on 27.3.2009
			//......
			//'If blnIsUnitinPPM = False Then
			//'    TxtConcinUnit = objDatafileExportCryReport.Section10.ReportObjects("TxtConcinUnit")
			//'    'DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Conc.in Unit"
			//'    TxtConcinUnit.Text = "Conc. (%)"
			//'End If
			//.....

			//-----------------------------------
			TextObject TxtUnit;
			TextObject TxtConc;


			TxtUnit = objDatafileExportCryReport.Section16.ReportObjects("TxtUnitofresults");

			TxtConcinUnit = objDatafileExportCryReport.Section10.ReportObjects("TxtConcinUnit");
			//by dinesh wagh on 27.3.2009


			// code commented by : dinesh wagh on 27.3.2009
			//'If TxtUnit.Text = "ppm" Then
			//'    TxtConc = objDatafileExportCryReport.Section10.ReportObjects("TxtConc")
			//'    TxtConc.Text = "Conc. (ppm)"
			//'Else
			//'    TxtConc = objDatafileExportCryReport.Section10.ReportObjects("TxtConc")
			//'    TxtConc.Text = "Conc. (%)"
			//'End If
			//............

			// code added by : dinesh wagh on 27.3.2009
			//...code start

			if (TxtUnit.Text == "ppm") {
				TxtConc = objDatafileExportCryReport.Section10.ReportObjects("TxtConc");
				TxtConc.Text = "Conc. (ppm)";
				TxtConcinUnit.Text = "Conc. in Sample (ppm)";
			} else if ((TxtUnit.Text == "ppb")) {
				TxtConc = objDatafileExportCryReport.Section10.ReportObjects("TxtConc");
				TxtConc.Text = "Conc. (ppb)";
				TxtConcinUnit.Text = "Conc. in Sample (ppb)";
			//'lblConc = objDatafileExportCryReport.Section3.ReportObjects("FldConc")
			} else {
				TxtConc = objDatafileExportCryReport.Section10.ReportObjects("TxtConc");
				//TxtConc.Text = "Conc. (%)"
				TxtConc.Text = "Conc. (ppm)";
				// added after discussion.
				TxtConcinUnit.Text = "Conc. in Sample (%)";
			}
			//---code ends

			////-------------------------------------------------------
			if (blnIsShowMethodDefinition == false) {
				objDatafileExportCryReport.Section15.SectionFormat.EnableSuppress = true;
			}
			if (blnIsShowAnalysisParameters == false) {
				objDatafileExportCryReport.Section16.SectionFormat.EnableSuppress = true;
			}
			if (blnIsShowInstrumentConditions == false) {
				objDatafileExportCryReport.Section18.SectionFormat.EnableSuppress = true;
				objDatafileExportCryReport.Section19.SectionFormat.EnableSuppress = true;
			}
			if (objReportParameter.IsReportHeaderAndFooter == false) {
				objDatafileExportCryReport.Section1.SectionFormat.EnableSuppress = true;
				//objDatafileExportCryReport.Section4.SectionFormat.EnableSuppress = True
				objDatafileExportCryReport.Section13.SectionFormat.EnableSuppress = true;
			} else {
				TxtReportHeader = objDatafileExportCryReport.Section1.ReportObjects("TxtReportHeader");
				TxtReportHeader.Text = strPageHeaderIn;

				//TxtReportFooter = objDatafileExportCryReport.Section4.ReportObjects("TxtReportFooter")
				//TxtReportFooter.Text = strReportFooterIn
				TxtReportFooter = objDatafileExportCryReport.Section13.ReportObjects("TxtReportFooter");
				TxtReportFooter.Text = strReportFooterIn;
			}

			int intLeftPoint;
			if (objReportParameter.IsWeightVolumeDilution == false) {
				//objDatafileExportCryReport.Section10.SectionFormat.EnableSuppress = True
				intLeftPoint = objDatafileExportCryReport.Section10.ReportObjects("TxtWeight").Left;
				objDatafileExportCryReport.Section10.ReportObjects("TxtAbs").Left = intLeftPoint;
				intLeftPoint = objDatafileExportCryReport.Section10.ReportObjects("TxtVolume").Left;
				objDatafileExportCryReport.Section10.ReportObjects("TxtConc").Left = intLeftPoint;
				intLeftPoint = objDatafileExportCryReport.Section10.ReportObjects("TxtDilution").Left;
				objDatafileExportCryReport.Section10.ReportObjects("TxtConcinUnit").Left = intLeftPoint;

				//intLeftPoint = objDatafileExportCryReport.Section10.ReportObjects("TxtWeight").Left
				objDatafileExportCryReport.Section10.ReportObjects("TxtWeight").ObjectFormat.EnableSuppress = true;
				objDatafileExportCryReport.Section10.ReportObjects("TxtVolume").ObjectFormat.EnableSuppress = true;
				objDatafileExportCryReport.Section10.ReportObjects("TxtDilution").ObjectFormat.EnableSuppress = true;
			}
			intLeftPoint = objDatafileExportCryReport.Section10.ReportObjects("TxtAbs").Left;

			//'objDatafileExportCryReport.Section10.ReportObjects("TxtAbs").Left()
			if (objReportParameter.IsAbsorbance == false) {
				intLeftPoint = objDatafileExportCryReport.Section10.ReportObjects("TxtConc").Left;
				objDatafileExportCryReport.Section10.ReportObjects("TxtConcinUnit").Left = intLeftPoint;
				intLeftPoint = objDatafileExportCryReport.Section10.ReportObjects("TxtAbs").Left;
				objDatafileExportCryReport.Section10.ReportObjects("TxtConc").Left = intLeftPoint;
			} else {
			}

			//objDatafileExportCryReport.Section10.ReportObjects("TxtConc").Left = intLeftPoint
			//intLeftPoint = objDatafileExportCryReport.Section10.ReportObjects("TxtAbs").Width + 8
			//objDatafileExportCryReport.Section10.ReportObjects("TxtConcinUnit").Left = intLeftPoint

			if (objReportParameter.IsReportHeaderAndFooter == false) {
				objDatafileExportCryReport.Section1.SectionFormat.EnableSuppress = true;
			}

			if (objReportParameter.IsReportHeaderAndFooter == false) {
				objDatafileExportCryReport.Section1.SectionFormat.EnableSuppress = true;
			}

			strAppVersion = Application.ProductVersion;
			//'get a application product version to string variable.
			strAppVersion = Mid(strAppVersion, 1, 4);

			//strInstInfos = "Thermo " & gstrTitleInstrumentType & "S/W Ver. " & strAppVersion 'COMMENTED BY : DINESH WAGH on 20.3.2009
			strInstInfos = "Thermo Scientific " + gstrTitleInstrumentType + Space(1) + "S/W Ver. " + strAppVersion;
			//added by :dinesh wagh on 20.3.2009  '4.85 14.04.09


			TxtPageFooter = objDatafileExportCryReport.Section5.ReportObjects("TxtPageFooter");
			TxtPageFooter.Text = strInstInfos;


			objDatafileExportCryReport.Refresh();
			////----- Export to Doc File
			//'

			objSaveFileDlg = new SaveFileDialog();

			objSaveFileDlg.Filter = "Text File (*.Doc)|*.Doc|All Files (*.*)|*.*";

			if (objSaveFileDlg.ShowDialog == DialogResult.OK) {
				objDatafileExportCryReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.WordForWindows, objSaveFileDlg.FileName);
			}
			objSaveFileDlg.Dispose();




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
			mobjDataSet = null;
			objSaveFileDlg = null;
			objDrCDNewRow = null;
			//---------------------------------------------------------
		}
	}
	#End Region

	#Region " Private Functions "

	private static IO.StreamWriter funcDrawStartHtml(System.IO.FileStream objFileStreamIn, string strTitleName)
	{

		System.IO.BufferedStream bs = new System.IO.BufferedStream(objFileStreamIn);
		System.IO.StreamWriter objStreamWriterIn = new System.IO.StreamWriter(bs);

		objStreamWriterIn.AutoFlush = true;
		objStreamWriterIn.WriteLine("<html>");
		objStreamWriterIn.WriteLine("<head>");
		objStreamWriterIn.WriteLine("<title>");
		objStreamWriterIn.WriteLine(strTitleName);
		objStreamWriterIn.WriteLine("</title>");
		objStreamWriterIn.WriteLine("</head>");
		objStreamWriterIn.WriteLine("<body>");

		objStreamWriterIn.WriteLine("<TABLE style='WIDTH: 100%' cellSpacing=0 ");
		objStreamWriterIn.WriteLine("cellPadding=1 width='100%' align=center border=0>");

		return objStreamWriterIn;

	}

	private static void subDrawENDHtml(ref System.IO.StreamWriter objStreamWriterIn)
	{
		objStreamWriterIn.WriteLine("</TABLE>");
		objStreamWriterIn.WriteLine("</body>");
		objStreamWriterIn.WriteLine("</html>");
		objStreamWriterIn.Close();
	}


	private static void subDrawHtmlReportPageHeader(ref System.IO.StreamWriter objStreamWriterIn, string strReportHeaderIn, string strPageHeaderIn, string strPageTextIn)
	{
		objStreamWriterIn.WriteLine("<TR><TD>");
		objStreamWriterIn.WriteLine("<TABLE style='WIDTH: 100%' cellSpacing=0 cellPadding=1 width='100%' align=center borderColor=white bgColor='" + constRowBGColor_SkyBlue + "' border=0 style='FONT-SIZE: smaller; FONT-STYLE: normal; FONT-FAMILY: Arial'>");
		objStreamWriterIn.WriteLine("<TR><TD valign=middle bgcolor='" + constRowBGColor_SkyBlue + "' style='padding-bottom:5px;'><STRONG>{0}</STRONG></TD></TR>", strReportHeaderIn);
		objStreamWriterIn.WriteLine("<TR><TD bgcolor='" + constRowBGColor_LightBlue + "'>{0}</TD></TR>", strPageHeaderIn);
		objStreamWriterIn.WriteLine("<TR><TD bgcolor='" + constRowBGColor_LightBlue + "'>{0}</TD></TR>", strPageTextIn);
		objStreamWriterIn.WriteLine("</TABLE>");
		objStreamWriterIn.WriteLine("</TD></TR>");

	}


	private static void subDrawHtmlTables(ref System.IO.StreamWriter objStreamWriterIn, DataSet objDsTablesList)
	{
		int i;
		int r;
		int c;

		for (i = 0; i <= objDsTablesList.Tables.Count - 1; i++) {
			objStreamWriterIn.WriteLine("<table border=1 cellSpacing=0 cellPadding=2  width='100%' borderColor='" + constRowBGColor_White + "' style='FONT-SIZE: smaller; FONT-STYLE: normal; FONT-FAMILY: Arial'>");
			objStreamWriterIn.WriteLine("<TR bgcolor='" + constRowBGColor_SkyBlue + "'>");
			objStreamWriterIn.WriteLine("<TD colspan=10><STRONG>");
			objStreamWriterIn.WriteLine("{0}", objDsTablesList.Tables(i).TableName);
			objStreamWriterIn.WriteLine("<STRONG></td></tr>");

			objStreamWriterIn.WriteLine("<tr bgColor='" + constRowBGColor_DarkBlue + "' style='FONT-SIZE:12;FONT-FAMILY: Arial;color:White;'>");
			for (c = 0; c <= objDsTablesList.Tables(i).Columns.Count - 1; c++) {
				objStreamWriterIn.Write("<td style='padding-left: 5px;'><STRONG>{0}</STRONG></td>", objDsTablesList.Tables(i).Columns(c).ColumnName);
			}
			objStreamWriterIn.WriteLine("</tr>");

			for (r = 0; r <= objDsTablesList.Tables(i).Rows.Count - 1; r++) {
				if (Math.IEEERemainder(r, 2) == 0) {
					objStreamWriterIn.WriteLine("<tr bgcolor='" + constRowBGColor_SkyBlue + "'>");
				} else {
					objStreamWriterIn.WriteLine("<tr bgcolor='" + constRowBGColor_LightBlue + "'>");
				}

				for (c = 0; c <= objDsTablesList.Tables(i).Columns.Count - 1; c++) {
					objStreamWriterIn.WriteLine("<td style='padding-left: 5px;'>{0}</td>", objDsTablesList.Tables(i).Rows(r).Item(c));
				}
				objStreamWriterIn.WriteLine("</tr>");
			}
			objStreamWriterIn.WriteLine("</table>");
			objStreamWriterIn.WriteLine("</hr>");
		}
		objStreamWriterIn.WriteLine("</TD></TR>");

	}


	private static void subDrawHtmlImages(ref System.IO.StreamWriter objStreamWriterIn, string[] strImageFilePaths, ArrayList arrImageCaptionList)
	{
		string strGraphImagefileName;
		int intImageCounter;
		int intImageCaptionsCounter;

		if (arrImageCaptionList == null) {
			//ReDim strImageCaptions(strImageFilePaths.Length - 1)
		}

		//---the following lines are commented ny deepak on 22.05.06
		//---to solve the error related to printing

		//objStreamWriterIn.WriteLine("<TR><TD align=center bgcolor='" & constRowBGColor_LightBlue & "'>")
		//objStreamWriterIn.WriteLine("<IMG SRC='file://" & strImageFilePaths(0) & "'")
		//objStreamWriterIn.WriteLine("border=0> ")
		//objStreamWriterIn.WriteLine("</TD></TR>")

		objStreamWriterIn.WriteLine("<Table>");
		for (intImageCounter = 0; intImageCounter <= strImageFilePaths.Length - 1; intImageCounter++) {
			if (Math.IEEERemainder(intImageCounter, 2) == 0) {
				if (arrImageCaptionList(intImageCaptionsCounter) == null) {
					arrImageCaptionList(intImageCaptionsCounter) = "";
				}

				objStreamWriterIn.WriteLine("<TD>" + arrImageCaptionList(intImageCaptionsCounter) + " </TD>");
				objStreamWriterIn.WriteLine("<TD bgcolor='" + constRowBGColor_SkyBlue + "'>");
				objStreamWriterIn.WriteLine("<IMG SRC='file://" + strImageFilePaths(intImageCounter) + "'");
				objStreamWriterIn.WriteLine("border=0> ");
				objStreamWriterIn.WriteLine("</TD>");
				objStreamWriterIn.WriteLine("</TR>");

				intImageCaptionsCounter += 1;
			} else {
				objStreamWriterIn.WriteLine("<TR>");
				objStreamWriterIn.WriteLine("<TD>" + arrImageCaptionList(intImageCaptionsCounter) + " </TD>");
				objStreamWriterIn.WriteLine("<TD bgcolor='" + constRowBGColor_LightBlue + "'>");
				objStreamWriterIn.WriteLine("<IMG SRC='file://" + strImageFilePaths(intImageCounter) + "'");
				objStreamWriterIn.WriteLine("border=0> ");
				objStreamWriterIn.WriteLine("</TD>");
				objStreamWriterIn.WriteLine("</TR>");

				intImageCaptionsCounter += 1;
			}
			//'objStreamWriterIn.WriteLine("<TR><TD align=center bgcolor='" & constRowBGColor_LightBlue & "'>")
			//'objStreamWriterIn.WriteLine("<IMG SRC='file://" & strImageFilePaths(intImageCounter) & "'")
			//'objStreamWriterIn.WriteLine("border=0> ")
			//'objStreamWriterIn.WriteLine("</TD></TR>")
		}
		objStreamWriterIn.WriteLine("</Table>");

	}

	private static string funcSaveReportImages(Bitmap objGraphImage, string strImageName)
	{
		string strFilePath;
		string strGraphImageFilePath;
		string strSpaceDiagramImageFilePath;
		try {
			strGraphImageFilePath = Application.StartupPath + constImagesFilePath;

			//--- Check for the folders if not create the folders
			if (!System.IO.Directory.Exists(strGraphImageFilePath)) {
				//--- Create the folder
				System.IO.Directory.CreateDirectory(strGraphImageFilePath);
			}

			strGraphImageFilePath = strGraphImageFilePath + "\\" + strImageName;
			strGraphImageFilePath = strGraphImageFilePath + constGraphImageFileExt;

			if (System.IO.File.Exists(strGraphImageFilePath) == true) {
				System.IO.File.Delete(strGraphImageFilePath);
			}

			objGraphImage.Save(strGraphImageFilePath, Drawing.Imaging.ImageFormat.Jpeg);

			return strGraphImageFilePath;

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

	private DataSet1 funcDatafileReport(string strFileName)
	{
		//Dim objDataRptExport As New DataRptExport
		//Dim objOleDBconnection As New OleDbConnection
		DataTable mobjDt;
		int intCount;
		int intColCount;
		try {
		//--- Initialising Connection String
		//gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

		//--- Initialising Connection 
		//objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)
		//gobjDataAdapter = New OleDbDataAdapter("SELECT * from CustomerDetails where CustomerID = 1", objOleDBconnection)
		//gobjDataSet = New dtsetExportAll

		//// Connect to, fetch data, and disconnect from database 
		//gobjDataAdapter.Fill(gobjDataSet, "CustomerDetails")
		//Dim objDrCDNewRow As dtsetExportAll.CustomerDetailsRow

		//gobjDataSet.Tables.Add(gobjDataAccess.GetCustomerDetails())
		//PrintDocument1.Print()
		//objDataRptExport.SetDataSource(gobjDataSet)


		//rptCustomerDetail.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
		//rptCustomerDetail.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
		//    gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
		//    gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
		//    gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)

		//Else
		//objDataRptExport.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)

		//End If


		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex);
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
