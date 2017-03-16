using System;
using System.IO;
using System.Text;

class modAutoSampler
{

	#Region "AutoSampler General Functions"
	public object gfuncInitialiseGlobalValues(ref structAutoSampler structAutoSamplerIn, ref structAutoSamplerPosition structAutoSamplerPosIn)
	{
		try {
			structAutoSamplerIn.intBaudRate = 9600;
			structAutoSamplerIn.intComPort = 2;
			structAutoSamplerIn.blnCommunication = false;
			structAutoSamplerIn.intCoordinateX = -1;
			structAutoSamplerIn.intCoordinateY = -1;
			structAutoSamplerIn.intIntakeTime = 20;
			structAutoSamplerIn.intWashTime = 20;
			structAutoSamplerIn.intWaitingTime = 10;
			structAutoSamplerIn.intProbeTime = 15;
			structAutoSamplerIn.blnAutoSamplerInitialised = false;
			structAutoSamplerIn.blnHome = false;
			structAutoSamplerIn.blnProbe = false;
			structAutoSamplerIn.blnPump = false;
			structAutoSamplerIn.blnPumpPrev = false;
			structAutoSamplerPosIn.intSpectrumPosition = 0;
			structAutoSamplerPosIn.intTimeScanPosition = 0;
			structAutoSamplerPosIn.intQuantPosition = 0;
			structAutoSamplerPosIn.intPhotometryPosition = 0;
			structAutoSamplerPosIn.intKineticPosition = 0;
			structAutoSamplerPosIn.intMultiPosition = 0;
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
	public object gfuncReadSamplerParameterFromINI(ref structAutoSampler structAutoSamplerIn)
	{
		try {
			structAutoSamplerIn.intComPort = (int)gFuncGetFromINI(SECTION_AUTOSAMPLER, KEY_SERIALPORT, "2", INI_SETTINGS_PATH);
			structAutoSamplerIn.intBaudRate = (int)gFuncGetFromINI(SECTION_AUTOSAMPLER, KEY_SAMPLERBAUDRATE, "9600", INI_SETTINGS_PATH);
			structAutoSamplerIn.intIntakeTime = (int)gFuncGetFromINI(SECTION_AUTOSAMPLER, KEY_INTAKETIME, "10", INI_SETTINGS_PATH);
			structAutoSamplerIn.intWashTime = (int)gFuncGetFromINI(SECTION_AUTOSAMPLER, KEY_WashTime, "10", INI_SETTINGS_PATH);
			structAutoSamplerIn.intWaitingTime = (int)gFuncGetFromINI(SECTION_AUTOSAMPLER, KEY_MeasurementTime, "10", INI_SETTINGS_PATH);
			structAutoSamplerIn.intProbeTime = (int)gFuncGetFromINI(SECTION_AUTOSAMPLER, KEY_ProbeWaitTime, "15", INI_SETTINGS_PATH);

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
	public object gfuncWriteSamplerParametersToINI(ref structAutoSampler structAutoSamplerIn)
	{
		try {
			gFuncWriteToINI(SECTION_AUTOSAMPLER, KEY_SERIALPORT, structAutoSamplerIn.intComPort.ToString, INI_SETTINGS_PATH);
			gFuncWriteToINI(SECTION_AUTOSAMPLER, KEY_SAMPLERBAUDRATE, structAutoSamplerIn.intBaudRate.ToString, INI_SETTINGS_PATH);
			gFuncWriteToINI(SECTION_AUTOSAMPLER, KEY_INTAKETIME, structAutoSamplerIn.intIntakeTime.ToString, INI_SETTINGS_PATH);
			gFuncWriteToINI(SECTION_AUTOSAMPLER, KEY_WashTime, structAutoSamplerIn.intWashTime.ToString, INI_SETTINGS_PATH);
			gFuncWriteToINI(SECTION_AUTOSAMPLER, KEY_MeasurementTime, structAutoSamplerIn.intWaitingTime.ToString, INI_SETTINGS_PATH);
			gFuncWriteToINI(SECTION_AUTOSAMPLER, KEY_ProbeWaitTime, structAutoSamplerIn.intProbeTime.ToString, INI_SETTINGS_PATH);

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
	public bool gfuncEditSamplerPosition(ref int intAutoSamplerPosn, string strSampleName, int intMaxSample, int intMaxStandard, ref structAutoSampler structAutoSamplerIn)
	{
		DataTable mobjDataTable = new DataTable("AutoSamplerPosition");
		frmAutoSampPosn objAutoSamplerPosition = new frmAutoSampPosn(mobjDataTable);
		DataGridTableStyle mobjGridTableStyle = new DataGridTableStyle();
		DataView mdataView = new DataView();
		int intRowCounter = 0;
		ArrayList arrAutoSamplerIn = new ArrayList();
		int intCounter = 0;
		try {
			gfuncCreateDataTableOfSamplerPosition(mobjDataTable, intAutoSamplerPosn, strSampleName, intMaxSample, intMaxStandard, structAutoSamplerIn);
			gfuncFormatDataGridofSamplerPosition(mobjDataTable, mobjGridTableStyle, mdataView, objAutoSamplerPosition);
			for (intCounter = 0; intCounter <= structAutoSamplerIn.arrAutoSamplerPosition.Count - 1; intCounter++) {
				arrAutoSamplerIn.Add(structAutoSamplerIn.arrAutoSamplerPosition.Item(intCounter));
			}
			//    Dim objAutoSamplerPosition As New frmAutoSampPosn(mobjDataTable)
			objAutoSamplerPosition.ShowDialog();
			if (objAutoSamplerPosition.DialogResult == DialogResult.OK) {
				structAutoSamplerIn.arrAutoSamplerPosition.Clear();
				for (intCounter = 0; intCounter <= intAutoSamplerPosn - 1; intCounter++) {
					structAutoSamplerIn.arrAutoSamplerPosition.Add(arrAutoSamplerIn.Item(intCounter));
				}
				while (objAutoSamplerPosition.dgSamplerPosition.Item(intRowCounter, 1) != 0) {
					structAutoSamplerIn.arrAutoSamplerPosition.Add(objAutoSamplerPosition.dgSamplerPosition.Item(intRowCounter, 1));
					intRowCounter += 1;
					if (intRowCounter == intMaxSample + intMaxStandard - intAutoSamplerPosn) {
						break; // TODO: might not be correct. Was : Exit While
					}
				}

				return true;
			} else {
				return false;
			}
			objAutoSamplerPosition.Dispose();
			return true;
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
	public object gfuncFormatDataGridofSamplerPosition(ref DataTable mobjDataTable, ref DataGridTableStyle mobjGridTableStyle, ref DataView mdataView, ref frmAutoSampPosn objAutoSamplerPosition)
	{
		DataGridTextBoxColumn objTextColumn;
		DataGridTextBoxColumn objTextColumn1;
		try {
			// Dim objAutoSamplerPosition As New frmAutoSampPosn(mobjDataTable)

			objAutoSamplerPosition.dgSamplerPosition.TableStyles.Clear();
			objAutoSamplerPosition.dgSamplerPosition.DataSource = mdataView;
			objAutoSamplerPosition.dgSamplerPosition.ReadOnly = false;
			mdataView.Table = mobjDataTable;
			mdataView.AllowNew = false;


			mobjGridTableStyle.RowHeadersVisible = false;
			mobjGridTableStyle.BackColor = Color.FloralWhite;
			mobjGridTableStyle.GridLineColor = Color.SandyBrown;
			mobjGridTableStyle.HeaderBackColor = Color.FloralWhite;
			mobjGridTableStyle.HeaderForeColor = Color.Black;
			mobjGridTableStyle.AlternatingBackColor = Color.FloralWhite;
			mobjGridTableStyle.AllowSorting = false;
			mobjGridTableStyle.MappingName = "AutoSamplerPosition";

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "SampleID";
			objTextColumn.HeaderText = "SampleID";
			objTextColumn.Width = 90;
			objTextColumn.ReadOnly = true;
			objTextColumn.NullText = " ";
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn1 = new DataGridTextBoxColumn();
			objTextColumn1.MappingName = "SamplerPosition";
			objTextColumn1.HeaderText = "Sampler Position";
			objTextColumn1.Width = 105;
			objTextColumn1.ReadOnly = false;
			objTextColumn1.NullText = " ";
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn1);

			mobjGridTableStyle.GridLineColor = Color.Black;
			objAutoSamplerPosition.dgSamplerPosition.TableStyles.Add(mobjGridTableStyle);
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
	public object gfuncCreateDataTableOfSamplerPosition(ref DataTable mobjDataTable, ref int intAutoSamplerPosn, string strSampleName, int intMaxSample, int intMaxStandard, ref structAutoSampler structAutoSamplerIn)
	{
		DataRow objDataRow;
		int j;
		try {
			mobjDataTable.Columns.Add(new DataColumn("SampleID", typeof(string)));
			mobjDataTable.Columns.Add(new DataColumn("SamplerPosition", typeof(string)));
			switch (OPERATION_MODE) {
				case EnumService_Mode.Quantitative:
				case EnumService_Mode.Multiomponent:
					gfuncSetSamplerPositionForQuant(intAutoSamplerPosn, intMaxSample, objDataRow, mobjDataTable, intMaxStandard, strSampleName, gstructAutoSampler);
				case EnumService_Mode.TimeScan:
				case EnumService_Mode.Kinetics:
					gfuncSetSamplerPositionForKinetics(intAutoSamplerPosn, intMaxSample, objDataRow, mobjDataTable, structAutoSamplerIn);
				default:
					//photmetry & spectrum
					gfuncSetSamplerPosition(intAutoSamplerPosn, intMaxSample, objDataRow, mobjDataTable, structAutoSamplerIn);
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
	public object gfuncSetSamplerPosition(int intCurrentposition, int IntMax, ref DataRow objDataRow, ref DataTable objDataTable, ref structAutoSampler structAutoSamplerIn)
	{
		int temp_cnt;
		try {

			for (temp_cnt = intCurrentposition + 1; temp_cnt <= IntMax; temp_cnt++) {
				//If temp_cnt <= 10 Then
				if (intCurrentposition == 0 & structAutoSamplerIn.arrAutoSamplerPosition.Count == 0) {
					if (temp_cnt <= 10) {
						objDataRow = objDataTable.NewRow;
						objDataRow("SamplerPosition") = (temp_cnt + 1);
						objDataRow("SampleID") = "Sample # " + temp_cnt;
						objDataTable.Rows.Add(objDataRow);
					} else {
						objDataRow = objDataTable.NewRow;
						objDataRow("SamplerPosition") = 0;
						objDataRow("SampleID") = "Sample # " + temp_cnt;
						objDataTable.Rows.Add(objDataRow);
					}

				} else if (intCurrentposition == 0 & structAutoSamplerIn.arrAutoSamplerPosition.Count != 0) {
					if (structAutoSamplerIn.arrAutoSamplerPosition.Count >= temp_cnt) {
						objDataRow = objDataTable.NewRow;
						objDataRow("SamplerPosition") = structAutoSamplerIn.arrAutoSamplerPosition.Item(temp_cnt - 1);
						objDataRow("SampleID") = "Sample # " + temp_cnt;
						objDataTable.Rows.Add(objDataRow);
					} else {
						objDataRow = objDataTable.NewRow;
						objDataRow("SamplerPosition") = 0;
						objDataRow("SampleID") = "Sample # " + temp_cnt;
						objDataTable.Rows.Add(objDataRow);
					}
				} else {
					//if loop added & code commented by sns on 200404 
					if (structAutoSamplerIn.arrAutoSamplerPosition.Count >= temp_cnt) {
						objDataRow = objDataTable.NewRow;
						objDataRow("SamplerPosition") = structAutoSamplerIn.arrAutoSamplerPosition.Item(temp_cnt - 1);
						objDataRow("SampleID") = "Sample # " + temp_cnt;
						objDataTable.Rows.Add(objDataRow);
					} else {
						objDataRow = objDataTable.NewRow;
						objDataRow("SamplerPosition") = 0;
						objDataRow("SampleID") = "Sample # " + temp_cnt;
						objDataTable.Rows.Add(objDataRow);
					}
					//objDataRow = objDataTable.NewRow
					//objDataRow("SamplerPosition") = 0
					//objDataRow("SampleID") = "Sample # " & temp_cnt
					//objDataTable.Rows.Add(objDataRow)

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

	public object gfuncSetSamplerPositionForKinetics(int intCurrentposition, int IntMax, ref DataRow objDataRow, ref DataTable objDataTable, ref structAutoSampler structAutoSamplerIn)
	{
		int temp_cnt;
		try {

			for (temp_cnt = intCurrentposition + 1; temp_cnt <= IntMax; temp_cnt++) {
				//If temp_cnt <= 10 Then
				if (intCurrentposition == 0 & structAutoSamplerIn.arrAutoSamplerPosition.Count == 0) {
					if (temp_cnt <= 10) {
						objDataRow = objDataTable.NewRow;
						objDataRow("SamplerPosition") = (temp_cnt + 1);
						objDataRow("SampleID") = "Sample # " + temp_cnt;
						objDataTable.Rows.Add(objDataRow);
					} else {
						objDataRow = objDataTable.NewRow;
						objDataRow("SamplerPosition") = 0;
						objDataRow("SampleID") = "Sample # " + temp_cnt;
						objDataTable.Rows.Add(objDataRow);
					}

				} else if (intCurrentposition >= 0 & structAutoSamplerIn.arrAutoSamplerPosition.Count != 0) {
					//ElseIf intCurrentposition = 0 And structAutoSamplerIn.arrAutoSamplerPosition.Count <> 0 Then
					if (structAutoSamplerIn.arrAutoSamplerPosition.Count >= temp_cnt) {
						objDataRow = objDataTable.NewRow;
						objDataRow("SamplerPosition") = structAutoSamplerIn.arrAutoSamplerPosition.Item(temp_cnt - 1);
						objDataRow("SampleID") = "Sample # " + temp_cnt;
						objDataTable.Rows.Add(objDataRow);
					} else {
						objDataRow = objDataTable.NewRow;
						objDataRow("SamplerPosition") = 0;
						objDataRow("SampleID") = "Sample # " + temp_cnt;
						objDataTable.Rows.Add(objDataRow);
					}
				} else {
					objDataRow = objDataTable.NewRow;
					objDataRow("SamplerPosition") = 0;
					objDataRow("SampleID") = "Sample # " + temp_cnt;
					objDataTable.Rows.Add(objDataRow);

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


	public object gfuncSetSamplerPositionForQuant(int intCurrentposition, int IntMax, ref DataRow objDataRow, ref DataTable objDataTable, int intNoStd, string strName, ref structAutoSampler structAutoSamplerIn)
	{
		int temp_cnt;
		try {
			for (temp_cnt = intCurrentposition + 1; temp_cnt <= IntMax + intNoStd; temp_cnt++) {
				if (temp_cnt <= intNoStd) {
					if (intCurrentposition == 0 & structAutoSamplerIn.arrAutoSamplerPosition.Count == 0) {
						objDataRow = objDataTable.NewRow;
						objDataRow("SamplerPosition") = (temp_cnt + 1);
						objDataRow("SampleID") = "STD # " + temp_cnt;
						objDataTable.Rows.Add(objDataRow);
					} else if (intCurrentposition == 0 & structAutoSamplerIn.arrAutoSamplerPosition.Count != 0) {
						if (structAutoSamplerIn.arrAutoSamplerPosition.Count >= temp_cnt) {
							objDataRow = objDataTable.NewRow;
							objDataRow("SamplerPosition") = structAutoSamplerIn.arrAutoSamplerPosition.Item(temp_cnt - 1);
							objDataRow("SampleID") = "STD # " + temp_cnt;
							objDataTable.Rows.Add(objDataRow);
						} else {
							objDataRow = objDataTable.NewRow;
							objDataRow("SamplerPosition") = 0;
							//(temp_cnt + 1)
							objDataRow("SampleID") = "STD # " + temp_cnt;
							objDataTable.Rows.Add(objDataRow);
						}
					} else {
						objDataRow = objDataTable.NewRow;
						objDataRow("SamplerPosition") = 0;
						//(temp_cnt + 1)
						objDataRow("SampleID") = "STD # " + temp_cnt;
						objDataTable.Rows.Add(objDataRow);
					}

				} else {
					objDataRow = objDataTable.NewRow;

					if (temp_cnt <= 10 & intCurrentposition == 0 & structAutoSamplerIn.arrAutoSamplerPosition.Count == 0) {
						objDataRow("SamplerPosition") = temp_cnt + 1;

					} else if (intCurrentposition == 0 & structAutoSamplerIn.arrAutoSamplerPosition.Count != 0) {
						if (structAutoSamplerIn.arrAutoSamplerPosition.Count >= temp_cnt) {
							objDataRow("SamplerPosition") = structAutoSamplerIn.arrAutoSamplerPosition.Item(temp_cnt - 1);
						} else {
							objDataRow("SamplerPosition") = 0;
						}
					} else {
						objDataRow("SamplerPosition") = 0;
					}
					if (strName == "") {
						objDataRow("SampleID") = "Sample # " + temp_cnt - intNoStd;
					} else {
						objDataRow("SampleID") = strName + temp_cnt - intNoStd;
					}
					objDataTable.Rows.Add(objDataRow);

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
	public bool gfuncOpenCommunicationForAutoSampler(ref structAutoSampler structAutoSamplerIn)
	{


		try {
			if (structAutoSamplerIn.blnAutoSamplerInitialised) {
				//  If gintCommPortSelected2 = cboPort_Selection.SelectedIndex + 1 Then
				if (gobjCommProtocol.mobjCommdll.gFuncIsPortOpen2()) {
					//                    gFuncShowMessage("Port Already Open", "The selected port is in use, try with other ports", EnumMessageType.Information)
					gobjMessageAdapter.ShowMessage(constComPortBusy);
					return false;
					return;
				}
				//End If
			}

			if (gobjCommProtocol.mobjCommdll.gFuncIsPortOpen2()) {
				gobjCommProtocol.mobjCommdll.gFuncCloseComm2();
			}

			//  gintCommPortSelected2 = cboPort_Selection.SelectedIndex + 1


			if (!gobjCommProtocol.mobjCommdll.gFuncISPortAvailable(gintCommPortSelected2)) {
				gobjMessageAdapter.ShowMessage(constComPortBusy);
				gintCommPortSelected2 = 0;
				return false;

			} else {

				if (!gobjCommProtocol.mobjCommdll.gFuncOpenCommPort2(gintCommPortSelected2, structAutoSamplerIn.intBaudRate, 0, 1, 8)) {
					gobjMessageAdapter.ShowMessage(constComPortBusy);
					structAutoSamplerIn.blnCommunication = false;
					return false;
				} else {
					structAutoSamplerIn.blnCommunication = true;
					//--- write the port to ini 
					gFuncWriteToINI(SECTION_AUTOSAMPLER, KEY_SERIALPORT, (string)gintCommPortSelected2, INI_SETTINGS_PATH);
				}
				//      Call gFuncInitSampler(gstructAutoSampler)
				//     Me.Close()
			}
			return true;

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

	#Region "AutoSampler Functions by Pankaj Bamb"

	public bool gfuncLoadAutoSamplerFlag()
	{
		//int i=1;
		//FILE *fptr=NULL;
		//fptr=fopen("asampler.pos","rt");
		//       If (fptr! = NULL) Then
		// {
		//fscanf(fptr,"%d\n",&i);
		//fclose(fptr);
		// Autosampler=FALSE;
		// if(i==1)
		// Autosampler=TRUE;
		// }
		gfuncLoadAutoSamplerFlag = false;
		try {
			int i;
			FileStream fs;
			string path = Application.StartupPath + "\\asampler.pos";
			if (File.Exists(path) == false) {
				return false;
			}
			fs = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryReader r = new BinaryReader(fs);
			i = r.ReadInt32();
			if ((i == 1)) {
				gstructAutoSampler.blnAutoSamplerInitialised = true;
			}
			r.Close();
			fs.Close();

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
	public bool gfuncWriteAutoSamplerFlag()
	{

		try {
			int i;
			FileStream fs;
			string path = Application.StartupPath + "\\asampler.pos";
			if (File.Exists(path) == false) {
				File.Create(path);
			}
			fs = new FileStream(path, FileMode.Open, FileAccess.Write);
			BinaryWriter r = new BinaryWriter(fs);
			if (gstructAutoSampler.blnAutoSamplerInitialised == true) {
				i = 1;
				r.Write(i);
			} else {
				i = 0;
				r.Write(i);
			}
			r.Close();
			fs.Close();

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

	#Region "AutoSampler UtilityFunctions"
	public bool gFuncInitSampler(ref structAutoSampler structAutoSamplerIn)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name	    :   gFuncInitSampler
		//Description	    :   To initalize the sampler 
		//Parameters 	    :   None
		//Time/Date  	    :   12:34 7/04/2004
		//Dependencies	    :   Sampler unit and second com Port    
		//Author		        :   M.Kamal
		//Revision		    :
		//Revision by Person	:
		//--------------------------------------------------------------------------------------
		bool blnFlag = false;
		frmAutoSamplerComPort objfrmComPort = new frmAutoSamplerComPort();
		try {
			structAutoSamplerIn.blnAutoSamplerInitialised = false;
			//--- Make the Autosampler Home 
			//blnFlag = gFuncAutoSamplerHome()
			gfuncInitialiseGlobalValues(gstructAutoSampler, gstructAutoSamplerPosition);
			gfuncReadSamplerParameterFromINI(structAutoSamplerIn);
			gintCommPortSelected2 = structAutoSamplerIn.intComPort;
			Cursor.Current = Cursors.WaitCursor;

			if (!gfuncOpenCommunicationForAutoSampler(structAutoSamplerIn)) {
				blnFlag = false;
			} else {
				if (gobjCommProtocol.funcAutoSamplerHome()) {
					structAutoSamplerIn.blnHome = true;
					structAutoSamplerIn.blnCommunication = true;
					structAutoSamplerIn.intCoordinateX = 0;
					structAutoSamplerIn.intCoordinateY = 0;
					blnFlag = true;
				} else {
					blnFlag = false;
				}
			}
			Cursor.Current = Cursors.Default;
			if (blnFlag) {
				//gFuncShowMessage(" RS232C OK", "AutoSampler connected to COM" & gstructAutoSampler.intComPort & " port", EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage("AutoSampler connected to COM" + gstructAutoSampler.intComPort + " port", "RS232C OK", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage);
				structAutoSamplerIn.blnAutoSamplerInitialised = true;
				////----- Add by Sachn Dokhale on 14.12.05
				if (!objfrmComPort == null) {
					objfrmComPort.Dispose();
				}
				////-----

				gFuncInitSampler = true;
			} else {
				//gFuncShowMessage(" RS232C ERROR", "Error reading communication port " & vbCrLf & "either instrument is swithed OFF" & vbCrLf & "or connect Autosampler to COM" & gstructAutoSampler.intComPort & " port and retry", EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage("Error reading communication port " + vbCrLf + "either instrument is swithed OFF" + vbCrLf + "or connect Autosampler to COM" + gstructAutoSampler.intComPort + " port and retry", "RS232C ERROR", EnumMessageType.Information);
				gFuncInitSampler = false;
				gobjCommProtocol.mobjCommdll.gFuncCloseComm2();
				structAutoSamplerIn.blnCommunication = false;
				objfrmComPort.ShowDialog();
				objfrmComPort.Dispose();
			}
			////----- Add by Sachin Dokhale on 14.12.05
			if (!objfrmComPort == null) {
				objfrmComPort.Dispose();
			}
		////-----

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
			Cursor.Current = Cursors.Default;
		}

	}
	#End Region

	#Region "AutoSampler Working Functions Like Washing , Cleaning etc"

	public bool gfuncSetAutoSampler(ref System.Object objLabel, ref structAutoSampler structAutoSamplerIN, ref int intPosition, bool blnFlag)
	{

		try {
			if (structAutoSamplerIN.blnCommunication == false) {
				return false;
			}

			if (blnFlag) {
				objLabel.Text = "Sampler => " + intPosition;
				gfuncAutoSamplerStartStatus(intPosition, objLabel, structAutoSamplerIN);
			} else {
				objLabel.Text = "Resetting Sampler";
				gfuncAutoSamplerEndStatus(objLabel, structAutoSamplerIN);
			}
			return true;

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


	public object gfuncAutoSamplerReadyStatus(int intx, int inty, bool blnFlag, Label objLabel, ref structAutoSampler structAutoSamplerIn)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name	    :   gfuncAutoSamplerReadyStatus
		//Description	    :   To prepare sampler for working 
		//Parameters 	    :   None
		//Time/Date  	    :   12:34 7/04/2004
		//Dependencies	    :  gstructAutoSampler.intposition
		//Author		        :   M.Kamal
		//Revision		    :
		//Revision by Person	:
		//--------------------------------------------------------------------------------------
		try {
			if (blnFlag) {
				objLabel.Text = "Sampler =>  " + structAutoSamplerIn.intPosition;
			} else {
				objLabel.Text = "Washing ...     ";
			}
			//If gfuncAutoSamplerGoTo(intx, inty, structAutoSamplerIn) Then
			if (gobjCommProtocol.funcAutoSamplerGoTo(intx, inty, structAutoSamplerIn)) {
				structAutoSamplerIn.intCoordinateX = intx;
				structAutoSamplerIn.intCoordinateY = inty;

			}
			gobjCommProtocol.funcAutoSamplerProbeDown();
			gobjCommProtocol.funcAutoSamplerPumpON();
			if (blnFlag) {
				objLabel.Text = "Sample is flowing     ";
				//Wait while intaking
				//subTime_Delay(structAutoSamplerIn.intIntakeTime * 1000)
				//Call gobjCommProtocol.mobjCommdll.subTime_Delay(structAutoSamplerIn.intIntakeTime * 1000)
				gobjCommProtocol.mobjCommdllAutoSampler.subTime_Delay(structAutoSamplerIn.intIntakeTime * 1000);
				//added by pankaj on 25 Mar 08
			} else {
				objLabel.Text = "Washing ...     ";
				//wait till wash time 
				//subTime_Delay(structAutoSamplerIn.intWashTime * 1000)
				//Call gobjCommProtocol.mobjCommdll.subTime_Delay(structAutoSamplerIn.intWashTime * 1000)
				gobjCommProtocol.mobjCommdllAutoSampler.subTime_Delay(structAutoSamplerIn.intWashTime * 1000);
				//added by pankaj on 25 Mar 08
			}
			gobjCommProtocol.funcAutoSamplerPumpOFF();
			////----- Added by Sachin Dokhale on 30.12.05
			if (!blnFlag) {
				gobjCommProtocol.funcAutoSamplerProbeUp();
			}
			////-----

			if (blnFlag) {
				objLabel.Text = "Measuring ...  ";
				//wait till waiting time
				//subTime_Delay(structAutoSamplerIn.intWaitingTime * 1000)
				//Call gobjCommProtocol.mobjCommdll.subTime_Delay(structAutoSamplerIn.intWaitingTime * 1000)
				gobjCommProtocol.mobjCommdllAutoSampler.subTime_Delay(structAutoSamplerIn.intWaitingTime * 1000);
				//added by pankaj on 25 Mar 08
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

	public int gfuncAutoSamplerStartStatus(int intPosition, Label objLabel, ref structAutoSampler structAutoSamplerIn)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name	    :   gfuncAutoSamplerStartStatus
		//Description	    :   To start the sampler for accessing 
		//Parameters 	    :   None
		//Time/Date  	    :   12:34 7/04/2004
		//Dependencies	    :   gstructAutoSampler.intPosition  
		//Author		        :   M.Kamal
		//Revision		    :
		//Revision by Person	:
		//--------------------------------------------------------------------------------------

		int intx;
		int inty;

		try {
			//intx = intPosition / 5 
			intx = Int(intPosition / 5);
			//'by Pankaj for checking max position on 01 OCT 07

			inty = intPosition % 5;

			if (intPosition != 0 & inty == 0) {
				inty = 5;
				intx -= 1;
			}
			//by Pankaj for checking max position on 01 OCT 07
			if ((intx > 12)) {
				intx = 12;
			}
			//by Pankaj for checking max position on 01 OCT 07
			if ((inty > 5)) {
				intx = 5;
			}
			structAutoSamplerIn.intPosition = intPosition;
			gfuncAutoSamplerReadyStatus(intx, inty, true, objLabel, structAutoSamplerIn);
			return 1;

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

	public int gfuncAutoSamplerDrainStatus(Label objLabel, ref structAutoSampler structAutoSamplerIn)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name	    :   gfuncAutoSamplerDrainStatus
		//Description	    :   To Drain the sampler 
		//Parameters 	    :   None
		//Time/Date  	    :   12:34 7/04/2004
		//Dependencies	    :   
		//Author		        :   M.Kamal
		//Revision		    :
		//Revision by Person	:
		//--------------------------------------------------------------------------------------
		try {
			gobjCommProtocol.funcAutoSamplerPumpOFF();
			gobjCommProtocol.funcAutoSamplerProbeUp();
			objLabel.Text = "Draining ...     ";
			if (gobjCommProtocol.funcAutoSamplerGoTo(0, 1, structAutoSamplerIn)) {
				structAutoSamplerIn.intCoordinateX = 0;
				structAutoSamplerIn.intCoordinateY = 1;
			}
			gobjCommProtocol.funcAutoSamplerProbeDown();
			gobjCommProtocol.funcAutoSamplerPumpONRev();
			//Wait while WashTime
			//Call subTime_Delay(structAutoSamplerIn.intWashTime * 1000)
			//Call gobjCommProtocol.mobjCommdll.subTime_Delay(structAutoSamplerIn.intWashTime * 1000)
			gobjCommProtocol.mobjCommdllAutoSampler.subTime_Delay(structAutoSamplerIn.intWashTime * 1000);
			//added by pankaj on 25 Mar 08
			return 1;

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

	public int gfuncAutoSamplerEndStatus(Label objLabel, ref structAutoSampler structAutoSamplerIn)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name	    :   gfuncAutoSamplerEndStatus
		//Description	    :   To ending the process of the sampler 
		//Parameters 	    :   None
		//Time/Date  	    :   12:34 7/04/2004
		//Dependencies	    :       
		//Author		        :   M.Kamal
		//Revision		    :
		//Revision by Person	:
		//--------------------------------------------------------------------------------------
		try {
			gfuncAutoSamplerDrainStatus(objLabel, structAutoSamplerIn);
			objLabel.Text = "Washing ...  ";
			gobjCommProtocol.funcAutoSamplerPumpOFF();
			gobjCommProtocol.funcAutoSamplerProbeUp();
			gfuncAutoSamplerCleanStatus(objLabel, structAutoSamplerIn);
			gfuncAutoSamplerDrainStatus(objLabel, structAutoSamplerIn);

			gobjCommProtocol.funcAutoSamplerPumpOFF();
			gobjCommProtocol.funcAutoSamplerProbeUp();
			if (gobjCommProtocol.funcAutoSamplerGoTo(structAutoSamplerIn.intCoordinateX, 1, structAutoSamplerIn)) {
				structAutoSamplerIn.intCoordinateY = 1;
			}
			return 1;
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

	public object gfuncAutoSamplerCleanStatus(Label objLabel, ref structAutoSampler structAutoSamplerIn)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name	    :   gfuncAutoSamplerCleanStatus
		//Description	    :   To Clean the sampler 
		//Parameters 	    :   None
		//Time/Date  	    :   12:34 7/04/2004
		//Dependencies	    :   
		//Author		        :   M.Kamal
		//Revision		    :
		//Revision by Person	:
		//--------------------------------------------------------------------------------------
		try {
			gfuncAutoSamplerReadyStatus(0, 0, false, objLabel, structAutoSamplerIn);
			gobjCommProtocol.funcAutoSamplerPumpOFF();
			gobjCommProtocol.funcAutoSamplerProbeUp();
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

	public bool gfuncCheckAutoSampler(ref structAutoSampler structAutoSamplerIn)
	{
		frmAutoSamplerComPort objfrmComport;
		try {
			gobjCommProtocol.funcAutoSamplerPumpOFF();
			if (structAutoSamplerIn.blnCommunication == false) {
				if (gobjMessageAdapter.ShowMessage(constAutoSamplerConnectionLost) == true) {
					objfrmComport.ShowDialog();
					objfrmComport.Dispose();
				}
			}
			return structAutoSamplerIn.blnCommunication;

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
