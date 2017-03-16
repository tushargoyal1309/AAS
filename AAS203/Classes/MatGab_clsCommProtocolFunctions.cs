using AAS203.Common;
using AAS203Library.Instrument;
/// <summary>
/// clss Comm Protocol Functions
/// </summary>

public class clsCommProtocolFunctions
{

	#Region " Class Member Variables "
	private frmZeroOrder mobjfrmZeroOrder;

	private frmTurretOptimisation mobjfrmturretOptimisation;

	private ClsInstrument mobjClsInstrument;
	private bool mblnSRLamp;

	private int mintSSGain;
	//---Public Object for Serial Comm DLL
	//Public WithEvents mobjCommdll As RS232SerialComm.clsRS232Main
	public clsRS232Main mobjCommdll;
	//Public mobjCommdll As VCRS232SERIALCOMMLib.clsRS232MainClass
	//Public mobjCommdll As New CSerial
	//Public WithEvents mobjCommdllAutoSampler As RS232SerialComm.clsRS232Main

	public clsRS232Main mobjCommdllAutoSampler;
	//Public gblnHydrideMode As Boolean = False
	System.Random bytRandom = new System.Random();
	int mintNVpos = 0;
	private int mintFirstDisp;
	//Private Commflag As Boolean = False
	#End Region

	#Region " Public Properties  "

	public bool SRLamp {
		get { return mblnSRLamp; }
		set { mblnSRLamp = Value; }
	}

	#End Region

	#Region " Constructors and Destructors "


	public clsCommProtocolFunctions()
	{
		mobjfrmZeroOrder = new frmZeroOrder();
		//mobjCommdll = New VCRS232SERIALCOMMLib.clsRS232MainClass
		//mobjCommdll = New RS232SerialComm.clsRS232Main(9600, 0, 1, 8)
		//mobjCommdllAutoSampler = New RS232SerialComm.clsRS232Main(9600, 0, 1, 8)

		mobjCommdll = new clsRS232Main(9600, 0, 1, 8);
		mobjCommdllAutoSampler = new clsRS232Main(9600, 0, 1, 8);

		mblnSRLamp = false;
		mintSSGain = 0x0;

	}

	protected override void Finalize()
	{
		base.Finalize();
	}

	#End Region

	#Region " Private Functions "

	private bool Wav_Pos(double dblWvNew, ref Label lblUVWavelengthStatus = null)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   Wav_Pos
		//Description            :   To position the wavelength
		//Parameters             :   new wavelength to position
		//Time/Date              :   08.11.06
		//Dependencies           :   communication
		//Author                 :   Deepak Bhati
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		//void 	Wav_Pos(HDC hdc, double wvnew, int x, int y)
		//{
		//   double    x1;
		//   unsigned i,ch, j;
		//   hold = Load_Curs();
		//   Inst.Wvcur = Get_Cur_Wv();
		//   if (Inst.Wvcur!=wvnew){ //1
		//       if (wvnew>=0 && wvnew <=1000.0){ //2
		//	        x1 = (wvnew * (double)StepPerNm)+(double)0.1;
		//	        i =(unsigned) x1;
		//	        Transmit(WVSET, (BYTE) i, (BYTE) (i>>8), 0);
		//	        if (Inst.Wvcur> wvnew)  i = (unsigned) ((Inst.Wvcur-wvnew)*(double)1.0);
		//	        else{ //3
		//		        i = (unsigned) ((wvnew-Inst.Wvcur)*(double)1.0);
		//		        Inst.Wvcur = wvnew;
		//		    }//3
		//	        for (j=1; j<=i;j++){ //4
		//		        if (Recev(TRUE)){//5
		//		            ch = Param2*256+Param1;
		//		            if (hdc!=NULL){//6
		//		                if( InstType == AA202 ){//7
		//			                Wprintf(hdc, x, y, "%-5.2f nm  ",(double) (ch/StepPerNm));
		//		                }//7
		//                       Else
		//			                Wprintf(hdc, x, y, "%-5.2f nm  ",Inst.Wvcur - (double) (ch/StepPerNm));
		//		            }//6
		//		        }//5
		//               else
		//	                break;
		//           }//4
		//       } //2
		//	    else {//8
		//	        wvnew = -1;
		//	        Beep();Beep();
		//	        Gerror_message(" Monochromator error \n **ERROR*** out of range");
		//	    }//8
		//	    if( InstType == AA202 ){//9
		//		    pc_delay(10000);pc_delay(10000);pc_delay(10000);pc_delay(10000);pc_delay(10000);
		//		    pc_delay(10000);pc_delay(10000);pc_delay(10000);pc_delay(10000);pc_delay(10000);
		//		    pc_delay(10000);pc_delay(10000);pc_delay(10000);pc_delay(10000);pc_delay(10000);
		//		    pc_delay(10000);pc_delay(10000);pc_delay(10000);pc_delay(10000);pc_delay(10000);
		//		    pc_delay(10000);pc_delay(10000);pc_delay(10000);pc_delay(10000);pc_delay(10000);
		//	    }//9
		//	    Inst.Wvcur = Get_Cur_Wv();
		//	    if( InstType == AA202 )
		//		    wvnew = Inst.Wvcur;
		//       If (Inst.Wvcur != wvnew) Then
		//	        Gerror_message("Error in Monochromator");
		//   }//1
		//   SetCursor(hold);
		//}

		//Dim objWait As New CWaitCursor
		byte[] bytArray = new byte[6];
		double dblx1;
		byte bytLow;
		byte bytHigh;
		Int32 Int_I;
		Int32 IntCh;
		Int32 IntJ;
		bool blnIsReceiveBloc = false;


		//'Dim StepPerNm As Double = 50.0

		try {
			funcGet_Current_Wv(gobjInst.WavelengthCur);


			if (gobjInst.WavelengthCur != dblWvNew) {

				if ((dblWvNew >= 0 & dblWvNew <= 1000.0)) {
					//---Commented by Mangesh on 17-Apr-2007 for AA201 
					//'dblx1 = (dblWvNew * StepPerNm) + 0.1
					//---Commented by Mangesh on 17-Apr-2007 for AA201 

					//**********************************************************
					//---Added and Changed by Mangesh on 17-Apr-2007 for AA201 
					//**********************************************************
					if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
						dblx1 = (dblWvNew * CONST_STEPS_PER_NM_AA201) + 0.1;
					} else {
						dblx1 = (dblWvNew * CONST_STEPS_PER_NM) + 0.1;
					}
					//**********************************************************

					Int_I = Fix(dblx1);

					bytLow = (byte)Int_I & 0xff;
					bytHigh = (byte)Int_I >> 8;
					// gblnInComm = True          '10.12.07
					//10.12.07
					if (mobjCommdll.gFuncResumeProcess == true) {
						mobjCommdll.IsNeedReceive = false;
						//12.02.08
						if (FuncTransmitCommand(EnumAAS203Protocol.WVSET, bytLow, bytHigh, 0)) {
							if (gobjInst.WavelengthCur > dblWvNew) {
								Int_I = Fix((gobjInst.WavelengthCur - dblWvNew) * 1.0);
							} else {
								Int_I = Fix((dblWvNew - gobjInst.WavelengthCur) * 1.0);
								gobjInst.WavelengthCur = dblWvNew;
							}
							////----- Commeted by Sachin Dokhale on 25.04.08
							//clsRS232Main.gblnInCommProcess = False  '12.02.08
							////-----
							for (IntJ = 1; IntJ <= Int_I; IntJ++) {
								if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
									if (bytArray(1) == 1) {
										IntCh = (bytArray(3) * 256) + bytArray(2);
										////----- Added by Sachin Dokhale
										if (!IsNothing(lblUVWavelengthStatus)) {
											//if( InstType == AA202 )//7
											//{
											//   Wprintf(hdc, x, y, "%-5.2f nm  ",(double) (ch/StepPerNm));
											//}//7
											//Else
											//   Wprintf(hdc, x, y, "%-5.2f nm  ",Inst.Wvcur-(double) (ch/StepPerNm));
											if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
												lblUVWavelengthStatus.Text = "Wavelength (nm): " + (IntCh / CONST_STEPS_PER_NM_AA201);
											} else if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
												////--- Modified by Sachin Dokhale on 13.02.08
												lblUVWavelengthStatus.Text = "Wavelength (nm): " + gobjInst.WavelengthCur - (IntCh / CONST_STEPS_PER_NM);
											//lblUVWavelengthStatus.Text = "Wavelength (nm): " & FormatNumber(gobjInst.WavelengthCur - (IntCh / CONST_STEPS_PER_NM), 0)
											} else {
												lblUVWavelengthStatus.Text = "Wavelength (nm): " + gobjInst.WavelengthCur - (IntCh / CONST_STEPS_PER_NM);
												//lblUVWavelengthStatus.Text = "Wavelength (nm): " & FormatNumber(gobjInst.WavelengthCur - (IntCh / CONST_STEPS_PER_NM), 0)
											}

											lblUVWavelengthStatus.Refresh();
										}
									////-----
									} else {
										break; // TODO: might not be correct. Was : Exit For
									}
								}
								blnIsReceiveBloc = true;
							}
							////----- Added by Sachin Dokhale on 25.04.08
							if (blnIsReceiveBloc == false) {
								clsRS232Main.gblnInCommProcess = false;
							}
							////-----
						}
						mobjCommdll.IsNeedReceive = true;
						//12.02.08
					}
				} else {
					dblWvNew = -1;
					Beep();
					Beep();
					if (gstructSettings.AppMode == EnumAppMode.FullVersion_201 | gstructSettings.AppMode == EnumAppMode.FullVersion_203 | gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
						gobjMessageAdapter.ShowMessage(constMonochromatorError);
					}
				}
				gblnInComm = false;
				////----- Added by Sachin Dokhale on 03.10.07
				if (gstructSettings.AppMode == EnumAppMode.FullVersion_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
					gobjCommProtocol.mobjCommdll.subTime_Delay(50);
				}
				////-----
				gblnInComm = false;
				funcGet_Current_Wv(gobjInst.WavelengthCur);
				//if( InstType == AA202 )
				//   wvnew = Inst.Wvcur;
				if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
					dblWvNew = gobjInst.WavelengthCur;
				}

				if (gobjInst.WavelengthCur != dblWvNew) {
					if (gstructSettings.AppMode == EnumAppMode.FullVersion_201 | gstructSettings.AppMode == EnumAppMode.FullVersion_203 | gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
						gobjMessageAdapter.ShowMessage(constMonochromatorError);
					}
				} else {
					lblUVWavelengthStatus.Text = "Wavelength (nm): " + gobjInst.WavelengthCur;
				}
			} else {
				lblUVWavelengthStatus.Text = "Wavelength (nm): " + gobjInst.WavelengthCur;
				lblUVWavelengthStatus.Refresh();
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
			//objWait.Dispose()
			gblnInComm = false;
			//Application.DoEvents()
			//---------------------------------------------------------
		}
	}

	private bool FuncTransmitCommand(int intCommand, int intPar1, int intPar2, int intPar3)
	{
		try {
			if (gstructSettings.AppMode == EnumAppMode.DemoMode | gstructSettings.AppMode == EnumAppMode.DemoMode_203D | gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
				return true;

			} else {
				return mobjCommdll.gFuncTransmitCommand(intCommand, intPar1, intPar2, intPar3);
			}

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

	private bool FuncReceiveData(ref byte[] BytArray, long lngTimeOut)
	{
		try {
			if (gstructSettings.AppMode == EnumAppMode.DemoMode | gstructSettings.AppMode == EnumAppMode.DemoMode_203D | gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
				//---todo send random data code here
				//If (flag) Then
				//  flag1=TRUE;
				//flag1=TRUE;
				//  Command = Block[1];
				//  Param1 = 1;
				//  Param2 = random(256);
				//  Param3 = random(256);
				//  Block[0]='2'; 		// Start of Block
				//  Block[1]=command;
				//  Block[2]=para1;
				//  Block[3]=para2;
				//  Block[4]=para3;
				//  Block[5]=0;			/* Checksum	    */
				//  Block[6]=' ';		/* Blank Spcae 	*/
				//  Block[7]='4';		/* End of Block */
				//  Block[8]='\0';
				BytArray(0) = 0x32;
				BytArray(1) = 0x1;
				BytArray(2) = (byte)bytRandom.Next(256);
				BytArray(3) = (byte)bytRandom.Next(256);
				BytArray(4) = (byte)bytRandom.Next(256);
				BytArray(5) = 1;
				BytArray(6) = 0x20;
				BytArray(7) = 0x34;
				return true;

			} else {
				return mobjCommdll.gFuncReceiveData(BytArray, lngTimeOut);
			}


		} catch (Threading.ThreadAbortException threadex) {
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

	private bool FuncTransmitCommand2(int intCommand)
	{
		try {
			//If gstructSettings.AppMode = EnumAppMode.DemoMode Then
			if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
				return true;
			} else {
				//Return mobjCommdllAutoSampler.gFuncTransmitByte2(intCommand)
				return mobjCommdllAutoSampler.gFuncTransmitByte2(intCommand);
			}

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

	private bool FuncReceiveData2(ref byte BytArray, long lngTimeOut)
	{
		try {
			//If gstructSettings.AppMode = EnumAppMode.DemoMode Then
			if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
				//---todo send random data code here
				//If (flag) Then
				//  flag1=TRUE;
				//flag1=TRUE;
				//  Command = Block[1];
				//  Param1 = 1;
				//  Param2 = random(256);
				//  Param3 = random(256);
				//  Block[0]='2'; 		// Start of Block
				//  Block[1]=command;
				//  Block[2]=para1;
				//  Block[3]=para2;
				//  Block[4]=para3;
				//  Block[5]=0;			/* Checksum	    */
				//  Block[6]=' ';		/* Blank Spcae 	*/
				//  Block[7]='4';		/* End of Block */
				//  Block[8]='\0';
				//BytArray(0) = &H32
				//BytArray(1) = &H1
				//BytArray(2) = CByte(bytRandom.Next(256))
				//BytArray(3) = CByte(bytRandom.Next(256))
				//BytArray(4) = CByte(bytRandom.Next(256))
				//BytArray(5) = 1
				//BytArray(6) = &H20
				//BytArray(7) = &H34
				BytArray = 0x34;
				return true;
			} else {
				return mobjCommdllAutoSampler.gFuncReceiveByte2(BytArray, lngTimeOut);
				//Return mobjCommdll.gFuncReceiveData(BytArray, lngTimeOut)
			}


		} catch (Threading.ThreadAbortException threadex) {
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

	#Region " Public Functions "

	public bool funcInitInstrument()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name	    :   gFuncInitInstrument
		//Description	    :   to open the COM port and to go though initialization routines 
		//Parameters 	    :   None 
		//Return             :   Bool. if true success
		//Time/Date  	    :   10.51 31/10/03
		//Dependencies	    :   
		//Author		        :   Mandar
		//Revision		    :   name changed from gFuncInitUV2600 to gFuncInitInstrument
		//Revision by Person	:   Rahul B. 25/9/06
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		funcInitInstrument = false;
		Int16 intCount;
		long lngtime1;
		long lngtime2;
		//Dim intInstrument_Type As Integer

		frmCommPorts_Selection frmCommPorts_Selection = new frmCommPorts_Selection();
		bool blnFlag = false;


		try {
			//to open the COM port and to go though initialization routines
			mobjCommdll.gFuncOpenCommPort(gintCommPortSelected, false);

			if (gblnTestAutoSampler == true) {
				if (!gintCommPortSelectedForAutoSampler == 0) {
					//mobjCommdllAutoSampler.gFuncOpenCommPort2(gintCommPortSelectedForAutoSampler, 9600, 0, 1, 8) ''comment by Pankaj for autosampler on 10Sep 07
				}
			}

			if (mobjCommdll.gFuncIsPortOpen()) {
				funcInitInstrument = true;
			} else {
				funcInitInstrument = false;
				gobjMessageAdapter.ShowMessage(constComPortBusy);
				Application.DoEvents();
				//lngtime1 = System.DateTime.Now.Ticks / 10000

				while ((true)) {
					frmCommPorts_Selection.ShowDialog();
					//--- there is no com port available so select one from this 
					Application.DoEvents();

					// if comm port selection is cancelled
					if (gintCommPortSelected == 0) {
						funcInitInstrument = false;
						return;
						//-- -End the Communication loop
					}

					if (mobjCommdll.gFuncIsPortOpen()) {
						funcInitInstrument = true;
						break; // TODO: might not be correct. Was : Exit Do
						//-- -End the Communication loop
					} else {
						funcInitInstrument = false;
					}

				}
				//frmCommPorts_Selection.Dispose()
				Application.DoEvents();
			}
			AgnComm:

			for (intCount = 1; intCount <= 2; intCount++) {
				//--------check communication with Instrument by sending reset command
				blnFlag = funcResetInstrument();
				if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
					if (blnFlag) {
						blnFlag = funcResetReferenceBeam();
					}
				}
				if (blnFlag) {
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			if (blnFlag == false) {
				funcInitInstrument = false;
				gobjMessageAdapter.MessageTextAlignment = ContentAlignment.MiddleLeft;
				gobjMessageAdapter.ShowMessage(constCommError);
				Application.DoEvents();
				//lngtime1 = System.DateTime.Now.Ticks / 10000

				while ((true)) {
					frmCommPorts_Selection.ShowDialog();
					//--- there is no com port available so select one from this 
					Application.DoEvents();
					if (gintCommPortSelected == 0) {
						funcInitInstrument = false;
						return;
						//-- -End the Communication loop
					}

					if (mobjCommdll.gFuncIsPortOpen()) {
						funcInitInstrument = true;
						goto AgnComm;
					// communicate again with the instrument by sending reset command
					} else {
						funcInitInstrument = false;
						gobjMessageAdapter.ShowMessage(constComPortBusy);
					}

				}
				frmCommPorts_Selection.Close();
				frmCommPorts_Selection.Dispose();
				Application.DoEvents();
			}


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
			if (!(frmCommPorts_Selection == null)) {
				frmCommPorts_Selection.Dispose();
			}
			objWait.Dispose();
			//---------------------------------------------------------
		}
	}

	public bool gFuncTurret_Home()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   gFuncTurret_Home,this also acts as Sample_Turret_Home
		//Description            :   To make the Turret indicater home        
		//Parameters             :   None
		//Time/Date              :   25/9/06
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Deepak B. on 24.11.06
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];
		bool blnflag = false;
		//====================================================================================
		//        BOOL	S4FUNC Find_Turret_Home(HWND hwnd)
		//{
		//BOOL	flag=FALSE;
		//unsigned  oldTout;

		// if (GetInstrument()==AA202)
		//	return TRUE;

		// oldTout=Tout;
		// Tout=LONG_DEALY;
		// hold = Load_Curs();
		// Transmit(TARHOME, 0,0 , 0);
		//            If (Recev(True)) Then
		//	 flag=(BOOL)Param1;
		// SetCursor(hold);
		// Tout=oldTout;
		// if (flag) {
		//	Inst.Lamp_old = Inst.Lamp_pos = 0;
		//	flag =Position_Turret(hwnd,1, TRUE);
		//  }
		// else {
		//	 Gerror_message(" Turret controller error \n Check Turret connections");
		//	 Inst.Lamp_old = -1;
		//	}
		// return flag;
		//}
		//====================================================================================
		try {
			//If gblnInComm = True Then
			//    Return False
			//End If

			// gblnInComm = True          '10.12.07

			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				return true;
			}
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			// Set Turret home position TURHOME(5)
			if (FuncTransmitCommand(EnumAAS203Protocol.TURHOME, 0, 0, 0)) {
				if (FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY)) {
					//1.	If Receive True then turret postion to 1
					if (bytArray(1) != 1) {
						gobjInst.Lamp_Old = -1;
						gFuncTurret_Home = false;
						//gobjMessageAdapter.ShowMessage(constErrorPosnTurretHome)
						gobjMessageAdapter.ShowMessage(constTurretPositionError);
						Application.DoEvents();
					} else {
						blnflag = bytArray(2);
						//true '04.12.07 Deepak
					}
				} else {
					gFuncTurret_Home = false;
					gobjInst.Lamp_Old = -1;
					gobjMessageAdapter.ShowMessage(constErrorPosnTurretHome);
					Application.DoEvents();
				}
			} else {
				gFuncTurret_Home = false;
				gobjInst.Lamp_Old = -1;
				gobjMessageAdapter.ShowMessage(constErrorPosnTurretHome);
				Application.DoEvents();
			}
			gblnInComm = false;
			if (blnflag == true) {
				gobjInst.Lamp_Old = 0;
				gobjInst.Lamp_Position = 0;
				// Set Turent position to the 1 lamp position
				blnflag = gFuncTurret_Position(1, true);
			} else {
				//Saurabh 25-MAY-2007
				gobjMessageAdapter.ShowMessage(constTurretPositionError);
				//Saurabh
				gobjInst.Lamp_Old = -1;
			}

			return blnflag;

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
			objWait.Dispose();
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool gFuncTurret_Position(Int16 intEndPosition, bool blnShowTurretElement = false)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   gFuncTurret_Position
		//Description            :   To position the Turret at said position from current position        
		//Parameters             :   End Position is the integer parameter to set the new position
		//                           BlnShowTurretyElement is the boolean parameter when true shows turret position sttus window.
		//Return                 : BOol. True if success
		//Time/Date              :   26/9/06
		//Dependencies           :   
		//Author                 :   Deepak B.
		//Revision               :
		//Revision by Person     :   Sachin Dokhale on 04.03.07
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();

		byte[] bytArray = new byte[6];
		int intCounter = 0;
		int intStartPosition;
		bool blnFlag = true;
		int intDemoPosition;
		//--------------------------------------------
		//        BOOL	S4FUNC Position_Turret(HWND hwnd, int end, BOOL first)
		//{
		//int 	i,start;
		//BOOL 	flag = TRUE;
		//char tmsg[100]="";
		// if (GetInstrument()==AA202){
		//	if(firstdisp){
		//		Inst.Lamp_pos = end;
		//		Inst.Lamp_old =Inst.Lamp_pos;
		//		sprintf(tmsg," Insert / Confirm %s Lamp# %d In Mesurement Hoder ",Inst.Lamp_par.lamp[Inst.Lamp_pos-1].elname, end);//--mdf by sk on 22/1/2002
		//		MessageBox(hwnd,tmsg,"Lamp Placement",MB_OK);
		//	}
		//	firstdisp = 1;
		//	return TRUE;
		// }
		// hold = Load_Curs();

		// start=Inst.Lamp_pos;

		// if (start>=0 && start <=6 && end >=1 && end<=6 && start!=end) {  //1
		//	Inst.Tpos = 0;
		//	Transmit (TARPOS, (BYTE) start,(BYTE) end , 0);
		//	if (start >end) {i=start; start = end; end = i; }
		//	for (i=start+1; i<=end; i++){  //2
		//		if (Recev(TRUE)){ //3
		//		  Beep();
		//		  Inst.Lamp_pos = Param1;;
		//#If DEMO Then
		//		  Inst.Lamp_pos = i;
		//#End If
		//		  if(first){ //4
		//                                    If (OnShowTurretElement) Then
		//			  (*OnShowTurretElement) (NULL); //	 ShowTurretElement(NULL);
		//			 } //4
		//		 } //3
		//		else { //5
		//		  Gerror_message(" Error While positioning Turret \n Check Turret connections");
		//		  flag = FALSE;
		//		  break;
		//		 } //5
		//	} //2

		// if (flag && Inst.Lamp_pos>0 && Inst.Lamp_pos<6) { //6
		//	Inst.Lamp_old =Inst.Lamp_pos;
		//	if (Inst.Lamp_par.lamp[Inst.Lamp_pos-1].lamp_optpos >0 &&
		//		 Inst.Lamp_par.lamp[Inst.Lamp_pos-1].lamp_optpos <=100){ //7
		//		 for (i=1; i<=RANGEH+10; i++){ //8
		//			Rotate_Anticlock_Tur();
		//			pc_delay(250);
		//		  } //8
		//		 for (i=1; i <= (Inst.Lamp_par.lamp[Inst.Lamp_pos-1].lamp_optpos)+10; i++){ //9
		//			Rotate_Clock_Tur();
		//			pc_delay(250);
		//		  } //9
		//		 } //7
		//  } //6
		// } //1

		// SetCursor(hold);
		// return flag;
		//}
		//--------------------------------------------
		try {
			intDemoPosition = intEndPosition;
			//---16.03.08
			// gblnInComm = True          '10.12.07

			////----- Added by Sachin Dokhale for AA 201 on 04.03.07
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				if (mintFirstDisp) {
					gobjInst.Lamp_Position = intEndPosition;
					gobjInst.Lamp_Old = gobjInst.Lamp_Position;
					gobjMessageAdapter.ShowMessage("Insert / Confirm " + gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).ElementName + " Lamp# " + gobjInst.Lamp_Position + " In Measurement Holder.", "Lamp Placement", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage);
					Application.DoEvents();
				}
				mintFirstDisp = 1;
				return true;
				return;
			}
			////-----

			// start=Inst.Lamp_pos;

			// if (start>=0 && start <=6 && end >=1 && end<=6 && start!=end) {  //1
			//	Inst.Tpos = 0;
			//	Transmit (TARPOS, (BYTE) start,(BYTE) end , 0);
			//	if (start >end) {i=start; start = end; end = i; }

			intStartPosition = gobjInst.Lamp_Position;

			//Validate lamp current Inst.Lamp_Position & end position within limits of 0 to 6.
			if ((intStartPosition >= 0 & intStartPosition <= 6 & intEndPosition >= 1 & intEndPosition <= 6 & intStartPosition != intEndPosition)) {
				//init Set Turret Position of Inst struct to 0
				gobjInst.TurretPosition = 0;

				//---03.12.07  Deepak
				//---On element change reference pmt should be zero (for double beam instrument).
				if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
					 // ERROR: Not supported in C#: WithStatement

				}
				bool blnIsReceiveBloc = false;
				//10.12.07
				if (mobjCommdll.gFuncResumeProcess == false) {
					return false;
				}
				// Transmit the Command to instrument 
				//EnumTURPOS (6); StartPosition; EndPosition.
				if (FuncTransmitCommand(EnumAAS203Protocol.TURPOS, (byte)intStartPosition, (byte)intEndPosition, 0)) {
					//Check StartPosition is greater the End position then interchange value of each
					if (intStartPosition > intEndPosition) {
						intCounter = intStartPosition;
						intStartPosition = intEndPosition;
						intEndPosition = intCounter;
					}
					//clsRS232Main.gblnInCommProcess = False

					//	for (i=start+1; i<=end; i++){  //2
					//		if (Recev(TRUE)){ //3
					//		  Beep();
					//		  Inst.Lamp_pos = Param1;;
					//#If DEMO Then
					//		  Inst.Lamp_pos = i;
					//#End If
					//		  if(first){ //4
					//                                    If (OnShowTurretElement) Then
					//			  (*OnShowTurretElement) (NULL); //	 ShowTurretElement(NULL);
					//			 } //4
					//		 } //3
					//		else { //5
					//		  Gerror_message(" Error While positioning Turret \n Check Turret connections");
					//		  flag = FALSE;
					//		  break;
					//		 } //5
					//	} //2
					// Increment positoon by one from start position +1 to end position
					for (intCounter = intStartPosition + 1; intCounter <= intEndPosition; intCounter++) {
						// Receive Byte Array  
						if (FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY)) {
							//Receive Byte Array(1) is not one the it has some error in Comm. and exit from function
							if (bytArray(1) != 1) {
								gobjMessageAdapter.ShowMessage(constErrorPosnTurret);
								Application.DoEvents();
								blnFlag = false;
								break; // TODO: might not be correct. Was : Exit For
							} else {
								//Receive Byte Array(1) is one then
								//lamp position is getting from byte array (2) 
								gobjInst.Lamp_Position = (int)bytArray(2);

								// if it is demo mode then simply set the lamp position with for loop counter
								//If gstructSettings.AppMode = EnumAppMode.DemoMode Then
								if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
									//gobjInst.Lamp_Position = intCounter
									gobjInst.Lamp_Position = intDemoPosition;
									//---16.03.08
								}
								// follow the process for to show the turret position on frmStatus window 
								if (blnShowTurretElement == true) {
									if (!gobjfrmStatus == null) {
										gobjfrmStatus.TurretNumber = gobjInst.Lamp_Position;
										if (gobjInst.Lamp_Position >= 1) {
											gobjfrmStatus.ElementName = gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).ElementName;
										}
										gobjfrmStatus.Refresh();
									}
									gobjfrmStatus.Show();
									Application.DoEvents();
								}
							}
						} else {
							//Error when Receive byte arry function has return false 
							gobjMessageAdapter.ShowMessage(constErrorPosnTurret);
							Application.DoEvents();
							blnFlag = false;
						}
						blnIsReceiveBloc = true;
					}

					if (blnIsReceiveBloc == false) {
						clsRS232Main.gblnInCommProcess = false;
					}
					gblnInComm = false;

					// if (flag && Inst.Lamp_pos>0 && Inst.Lamp_pos<6) { //6
					//	Inst.Lamp_old =Inst.Lamp_pos;
					//	if (Inst.Lamp_par.lamp[Inst.Lamp_pos-1].lamp_optpos >0 &&
					//		 Inst.Lamp_par.lamp[Inst.Lamp_pos-1].lamp_optpos <=100){ //7
					//		 for (i=1; i<=RANGEH+10; i++){ //8
					//			Rotate_Anticlock_Tur();
					//			pc_delay(250);
					//		  } //8
					//		 for (i=1; i <= (Inst.Lamp_par.lamp[Inst.Lamp_pos-1].lamp_optpos)+10; i++){ //9
					//			Rotate_Clock_Tur();
					//			pc_delay(250);
					//		  } //9
					//		 } //7
					//  } //6
					// } //1

					//MessageBox.Show("LampPosition  " + gobjInst.Lamp_Position.ToString)  '21.04.08
					//MessageBox.Show("OptPos  " + gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).LampOptimizePosition.ToString)  '21.04.08

					//Set the optimised position of Selected turret lamp position 
					if (blnFlag == true & gobjInst.Lamp_Position > 0 & gobjInst.Lamp_Position < 6) {
						gobjInst.Lamp_Old = gobjInst.Lamp_Position;
						//'gobjInst.Lamp.LampParametersCollection' in this object its stored for each turret lamp position into steps 
						if (gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).LampOptimizePosition > 0 & gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).LampOptimizePosition <= 100) {
							for (intCounter = 1; intCounter <= RANGEH + 10; intCounter++) {
								funcRotate_Anticlock_Tur();
								//MessageBox.Show("TPos  " + gobjInst.TurretPosition.ToString)  '21.04.08
								//MessageBox.Show("TPos  " + gobjInst.TurretPosition.ToString)  '21.04.08
								objWait = new CWaitCursor();
								mobjCommdll.subTime_Delay(5);
							}
							for (intCounter = 1; intCounter <= gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).LampOptimizePosition + 10; intCounter++) {
								funcRotate_Clock_Tur();
								//MessageBox.Show("TPos  " + gobjInst.TurretPosition.ToString)   '21.04.08
								objWait = new CWaitCursor();
								mobjCommdll.subTime_Delay(5);
							}
						}
					}
				} else {
					blnFlag = false;
					//gobjMessageAdapter.ShowMessage(constErrorPosnTurret)
					//Application.DoEvents()
					return false;
				}
			}

			return blnFlag;
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
			objWait.Dispose();
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcRotate_Steps_Tur_Clock(int intSteps)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcRotate_Steps_Tur_Clock
		//Description            :   To Rotate turret clockwise by given steps        
		//Parameters             :   intSteps : turret to be rotate by this num 
		// Retrutn               :   Bool True if success
		//Time/Date              :   28/9/06
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Deepak B on 26.11.06
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];
		byte bytLow;
		byte bytHigh;

		try {
			//If gblnInComm = True Then
			//    Return False
			//End If

			// gblnInComm = True          '10.12.07

			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				return true;
			}

			gFunclongtobyte(intSteps, bytLow, bytHigh);
			//bytLow = intSteps And &HFF
			//bytHigh = CByte(intSteps >> 8)

			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			//Send Command EnumTURROTSTEPCLK (58), with high byte and low byte of steps 
			if (FuncTransmitCommand(EnumAAS203Protocol.TURROTSTEPCLK, bytHigh, bytLow, 0)) {
				if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						funcRotate_Steps_Tur_Clock = false;
						gobjMessageAdapter.ShowMessage(constRotateStepsTurClkError);
						Application.DoEvents();
					} else {
						//if  receive byte is one then decrease the turret position by that steps 
						//gobjInst.TurretPosition -= intSteps
						gobjInst.TurretPosition = gobjInst.TurretPosition - intSteps;
						//MessageBox.Show(gobjInst.TurretPosition.ToString)
						funcRotate_Steps_Tur_Clock = true;
					}

				} else {
					funcRotate_Steps_Tur_Clock = false;
					gobjMessageAdapter.ShowMessage(constRotateStepsTurClkError);
					Application.DoEvents();
				}
			} else {
				funcRotate_Steps_Tur_Clock = false;
				//gobjMessageAdapter.ShowMessage(constRotateStepsTurClkError)
				//Application.DoEvents()
			}

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
			objWait.Dispose();
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcRotate_Steps_Tur_AntiClock(int intSteps)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcRotate_Steps_Tur_AntiClock
		//Description            :   To Rotate turret anticlockwise by given steps        
		//Parameters             :   intSteps : turret to be rotate by this num 
		// Retrutn               :   Bool True if success
		//Time/Date              :   10.02.08
		//Dependencies           :   
		//Author                 :   Deepak B.
		//Revision               :
		//Revision by Person     :   
		//--------------------------------------------------------------------------------------
		//        void  S4FUNC Rotate_Steps_Tur_AntiClock(int steps)
		//{
		//unsigned  oldTout;

		// if (GetInstrument()==AA202)
		//	return ;

		// oldTout=Tout;
		// Tout=LONG_DEALY;
		// hold = Load_Curs();

		// Transmit(TURROTSTEPANTI, (BYTE) (steps>>8), (BYTE) (steps), 0);
		// Recev(TRUE); 
		// Inst.Tpos+=steps;
		// SetCursor(hold);
		// Tout=oldTout;
		//}
		//--------------------------------------------------------------------------------------

		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];
		byte bytLow;
		byte bytHigh;


		try {
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				return true;
			}

			gFunclongtobyte(intSteps, bytLow, bytHigh);

			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}

			if (FuncTransmitCommand(EnumAAS203Protocol.TURROTSTEPANTI, bytHigh, bytLow, 0)) {
				if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						funcRotate_Steps_Tur_AntiClock = false;
					//gobjMessageAdapter.ShowMessage(constRotateStepsTurClkError)
					//Application.DoEvents()
					} else {
						//if  receive byte is one then decrease the turret position by that steps 
						gobjInst.TurretPosition = gobjInst.TurretPosition + intSteps;
						funcRotate_Steps_Tur_AntiClock = true;
					}
				} else {
					funcRotate_Steps_Tur_AntiClock = false;
					gobjMessageAdapter.ShowMessage(constRotateStepsTurClkError);
					Application.DoEvents();
				}
			} else {
				funcRotate_Steps_Tur_AntiClock = false;
			}

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
			objWait.Dispose();
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcRotate_Anticlock_Tur()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcRotate_Anticlock_Tur
		//Description            :   To Rotate turret Anticlockwise. Here turret rotates by only one step        
		//Parameters             :   None
		// Return                :   Bool, True if success
		//Time/Date              :   28/9/06
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Deepak B. on 16.11.06 minor changes
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];

		try {
			//If gblnInComm = True Then
			//    Return False
			//End If
			// gblnInComm = True          '10.12.07
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			//Send Command EnumTARHANTI (16), with 0 parameter
			if (FuncTransmitCommand(EnumAAS203Protocol.TARHANTI, 0, 0, 0)) {
				if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						gobjMessageAdapter.ShowMessage(constRotateAntiTurClkError);
						Application.DoEvents();
						return false;
					} else {
						//if  receive byte is one then increase the turret position by one steps 
						gobjInst.TurretPosition = gobjInst.TurretPosition + 1;
						//MessageBox.Show(gobjInst.TurretPosition.ToString)
						return true;
					}
				} else {
					gobjMessageAdapter.ShowMessage(constRotateAntiTurClkError);
					Application.DoEvents();
					return false;
				}
			} else {
				//gobjMessageAdapter.ShowMessage(constRotateAntiTurClkError)
				//Application.DoEvents()
				return false;
			}

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
			objWait.Dispose();
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcRotate_Clock_Tur()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcRotate_Clock_Tur
		//Description            :   To Rotate turret clockwise. Here turret rotates by only one step        
		//Parameters             :   None
		// Return                :   Bool, True if success
		//Time/Date              :   28/9/06
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   deepak B. on 16.11.06 minor changes
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];

		try {
			//If gblnInComm = True Then
			//    Return False
			//End If

			// gblnInComm = True          '10.12.07
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			//Send Command EnumTARHCLK (17), with 0 parameter
			if (FuncTransmitCommand(EnumAAS203Protocol.TARHCLK, 0, 0, 0)) {
				if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						gobjMessageAdapter.ShowMessage(constRotateTurClkError);
						Application.DoEvents();
						funcRotate_Clock_Tur = false;
					} else {
						//if  receive byte is one then decrease the turret position by one steps 
						gobjInst.TurretPosition = gobjInst.TurretPosition - 1;
						//MessageBox.Show(gobjInst.TurretPosition.ToString)
						return true;
					}
				} else {
					gobjMessageAdapter.ShowMessage(constRotateTurClkError);
					Application.DoEvents();
					funcRotate_Clock_Tur = false;
				}
			} else {
				//gobjMessageAdapter.ShowMessage(constRotateTurClkError)
				//Application.DoEvents()
				funcRotate_Clock_Tur = false;
			}

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
			objWait.Dispose();
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcOptimise_Turret_Position(double dblLampCurrent, int intLampPos)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcOptimise_Turret_Position
		//Description            :   To optimise Turret position 
		//Parameters             :   dblLampCurrent = current to be set to lamp
		//                           intLampPos = lamp position to which current to be set
		//Return                 :   True if success
		//Time/Date              :   5/10/06
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Deepak B. on 18.11.06 major modifications
		//Revision by Person     :   Mangesh S. on 11-Apr-2007 major modifications for AA201
		//--------------------------------------------------------------------------------------
		//void	S4FUNC 	Optimize_Turret_Position( HWND hpar, BOOL aLamps)
		//{
		//   if( GetInstrument() == AA202 )
		//       if (Inst->Lamp_par.wvzero==100.0 || aLamps)
		//       {
		//	        if(Inst->Lamp_par.lamp[0].lamp_optpos==0)
		//		        pos=0;
		//           Else
		//		        pos=1;
		//	        Optimize_Zero_order_AA202(hpar,pos);
		//	        Save_Tuttet_Status();
		//       }
		//	    return;
		//   else {
		//       if (Inst->Lamp_par.wvzero==100.0 || aLamps) {
		//		    Optimize_Zero_order(hpar);
		//		    Save_Tuttet_Status();
		//	    }
		//       Else
		//	        Turret_Optimise(hpar);
		//   }
		//}
		//---------------------------------
		CWaitCursor objWait = new CWaitCursor();

		try {
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				//***************************************************************
				//----Added by Mangesh on 11-Apr-2007 for AA201 changes
				//***************************************************************
				int intLampPosition = 0;
				if ((gobjInst.Lamp.WavelengthZero == 100.0 | funcIsAllLampEmpty())) {
					//commented by Deepak on 01.09.09
					//If (gobjInst.Lamp.LampParametersCollection.item(0).LampOptimizePosition = 0) Then
					//    intLampPosition = 0
					//Else
					//    intLampPosition = 1
					//End If
					///''''''''''''''''''

					//written by Deepak on 01.09.09
					if (!(Trim(gobjInst.Lamp.LampParametersCollection.item(0).ElementName) == "")) {
						intLampPosition = 1;
					} else if (!(Trim(gobjInst.Lamp.LampParametersCollection.item(1).ElementName) == "")) {
						intLampPosition = 2;
					} else {
						intLampPosition = 0;
					}
					///'''''''''''''''''''

					frmZeroOrder_201 objfrmZeroOrder201;
					objfrmZeroOrder201 = new frmZeroOrder_201();
					objfrmZeroOrder201.StartPosition = FormStartPosition.CenterScreen;
					objfrmZeroOrder201.Location = new Point(ZeroOrderThreadWindowLocationX, ZeroOrderThreadWindowLocationY);
					objfrmZeroOrder201.StartOptimizeTread(intLampPosition);
					if (objfrmZeroOrder201.ShowDialog() == DialogResult.OK) {
						if (gstructSettings.ExeToRun == EnumApplicationMode.AAS) {
							funcSaveInstStatus();
						}
						objfrmZeroOrder201.Close();
						objfrmZeroOrder201.Dispose();
						objfrmZeroOrder201 = null;
					}
				}
				//***************************************************************
				return true;
			}
			//optimise the turret for 203
			if (gobjInst.Lamp.WavelengthZero == 100 | funcIsAllLampEmpty() == true) {
				frmZeroOrder mobjfrmZeroOrder;
				mobjfrmZeroOrder = new frmZeroOrder();
				mobjfrmZeroOrder.StartPosition = FormStartPosition.Manual;
				mobjfrmZeroOrder.Location = new Point(ZeroOrderThreadWindowLocationX, ZeroOrderThreadWindowLocationY);
				mobjfrmZeroOrder.StartOptimizeTread();
				if (mobjfrmZeroOrder.ShowDialog() == DialogResult.OK) {
					if (gstructSettings.ExeToRun == EnumApplicationMode.AAS) {
						funcSaveInstStatus();
					}
					mobjfrmZeroOrder.Close();
					mobjfrmZeroOrder.Dispose();
				}
			} else {
				frmTurretOptimisation mobjfrmturretOptimisation;
				mobjfrmturretOptimisation = new frmTurretOptimisation(dblLampCurrent, intLampPos);
				mobjfrmturretOptimisation.StartOptimizeTread();
				if (mobjfrmturretOptimisation.ShowDialog() == DialogResult.OK) {
					mobjfrmturretOptimisation.Close();
					mobjfrmturretOptimisation.Dispose();
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
			objWait.Dispose();
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public int funcTur_Pre_Opt(ref object lblStatus1 = null, ref object lblStatus2 = null, ref object lblStatus3 = null)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcTur_Pre_Opt
		//Description            :   To optimise Turret 
		//Parameters             :   lblStatus1 as form Object, lblStatus2 as form Object,
		//                           lblStatus3 as form Object
		//Return                 :   integer position of turret.
		// Affected parameter    :   show status on lblStatus3 and lblStatus2
		//Time/Date              :   5/10/06
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Deepak B. on 17.11.06 major modifications
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		int intCounter;
		int chNew;
		int max_int;
		//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		//        int  Tur_pre_opt(HWND hwnd)
		//{
		//int 	i;
		//int 	in_pos,  max_int, chnew;
		//char 	line1[80]="";

		//  Set_PMT((double)150.0);
		//  Adj_pmt_NearZeroWv(hwnd);
		//  Show_Pmt(hwnd, Inst->Pmtv);
		//  for (i=1; i<=RANGEH+10; i++){
		//	  Rotate_Anticlock_Tur();
		//	 }
		//  for (i=1; i<=10; i++)  {
		//	 Rotate_Clock_Tur();  
		//	}
		//  in_pos = 1;  max_int = 0;
		//  for (i=1; i<=RANGE; i++)  {
		//	 Rotate_Clock_Tur();
		//	 chnew = ReadADCFilter();
		//	 if (chnew > max_int && i!=1){
		//		max_int = chnew;
		//		in_pos =i;
		//	 }
		//	sprintf(line1," Turpos : %d  Aprox.Peak %d  Energy %5.0f mV ", i, in_pos, GetmV(chnew));
		//	SetText(hwnd, IDC_STATUS1, line1);
		//  }
		//  for (i=1; i <= RANGE+10; i++) {
		//	 Rotate_Anticlock_Tur();
		//	}
		//  for (i=1; i <= in_pos+10; i++){
		//	 Rotate_Clock_Tur();
		//	}
		//  SetText(hwnd, IDC_STATUS1, "");
		// return in_pos;
		//}
		//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		int int_pos;


		try {

			funcTur_Pre_Opt = false;

			//1.	Set PMT voltage 150.0.

			funcSet_PMT(150.0);

			funcAdj_Pmt_NearZeroWV(lblStatus1, lblStatus2, lblStatus3);

			if (!lblStatus1 == null) {
				((Windows.Forms.Label)lblStatus1).Text = "PMT : -" + gobjInst.PmtVoltage;
			}

			//3.	Rotate turret anticlockwise 50 (RangeH) +10 times(i.e. 60 times).

			for (intCounter = 1; intCounter <= RANGEH + 10; intCounter++) {
				funcRotate_Anticlock_Tur();
			}

			//4.	Rotate turret clockwise 10 times.

			for (intCounter = 1; intCounter <= 10; intCounter++) {
				funcRotate_Clock_Tur();
			}

			int_pos = 1;
			max_int = 0;
			for (intCounter = 1; intCounter <= WVRANGE; intCounter++) {
				//6.	Rotate turret clockwise.
				funcRotate_Clock_Tur();
				//7.	Read ADC filter.
				funcReadADCFilter(gobjInst.Average, chNew);
				//8.	Memorize highest ADC filter reading throughout 100 steps.
				//9.	Memorize counter number for highest ADC filter reading.
				if (((chNew > max_int) & (intCounter != 1))) {
					max_int = chNew;
					int_pos = intCounter;
				}
				if (!lblStatus2 == null) {
					((Windows.Forms.Label)lblStatus2).Text = "Turpos : " + Format(intCounter, "000") + "  Aprox.Peak " + Format(int_pos, "000") + "  Energy " + Format(gFuncGetmv(chNew), "#0.00") + " mV ";
				}
			}

			//10.	Rotate Turret anticlockwise 100 (WVRange) + 10 times.
			for (intCounter = 1; intCounter <= WVRANGE + 10; intCounter++) {
				funcRotate_Anticlock_Tur();
			}

			//11.	Rotate turret clockwise for (counter number for 
			//highest ADC filter reading + 10 ) times.

			for (intCounter = 1; intCounter <= int_pos + 10; intCounter++) {
				funcRotate_Clock_Tur();
			}

			((Windows.Forms.Label)lblStatus2).Text = "";

			//12.	Return counter number for highest ADC 
			//filter reading to calling routine.

			return int_pos;
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
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcTurret_Optimise(double dblLampCurrent, int intLampPos, ref object lblStatus1 = null, ref object lblStatus2 = null, ref object lblStatus3 = null, ref object ObjGraph = null, object ObjThreadController = null, ref Label lblWvStatus = null)
	{
		//------------------------------------------------------------------
		//Procedure Name         :   funcThreadTurret_Optimise
		//Description            :   To optimise Turret position 
		//Parameters             :   dblLampCurrent,intLampPos
		//Return                 :   
		//Affected parameter     :   lblStatus1, lblStatus2,lblStatus3, ObjGraph, lblWvStatus
		//Time/Date              :   8/11/06
		//Dependencies           :   
		//Author                 :   Deepak B.
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		//Optimise Turret Steps:
		//1. Set Air Off
		//2. Find wv home
		//3. Turret Home
		//4. Position Turret to selected Turret No.
		//5. Set All Lamp Off
		//6. Set Current to HCL lamp selected.
		//7. Test if Lamp present then optimise turret
		//8. Set Air ON
		CWaitCursor objWait = new CWaitCursor();
		int i;
		int pos;
		string strMsg;
		double dbllmp_current = 0.0;
		int intlmp_position;
		int k;
		int intK = 0;

		//--------------------
		//        void 		S4FUNC 	Turret_Optimise(HWND hpar)
		//{
		//HWND	hwnd=NULL;
		//double	lmp_cur=0.0;
		//HDC	hdc;
		//char line1[80]="";
		//char line7[80]="";
		//int  i, pos;

		//#ifndef FINAL
		//  Get_Instrument_Parameters(&Inst);
		//#End If
		// Inst =  GetInstData();

		// for (i=0; i<6; i++)
		// {
		//  if (Inst->Lamp_par.lamp[i].lamp_optpos != 0) continue;
		//  else break;
		// }

		//  if (i<6)  {
		//  if(GetInstrument() != AA202 )
		//	  AIR_OFF();
		//  hwnd= CreateWindowPeak(hpar, " TURRET OPTIMISATION","SKCK1",0 );
		//  if (hwnd){  // hwnd start
		//	hdc= GetDC(hwnd);
		//	SetBkColor(hdc, RGB(192, 192, 192));
		//	SetText(hwnd, IDC_STATUS,"Initialising Please Wait  .......");
		//	if(Find_Wavelength_Home(hdc, 5, 150)){ // wavelength start
		//	  ShowTurretElement(hwnd);
		//	  for (pos = i+1; pos<=6; pos++){ //loop start
		//		 if (strcmp(trim(Inst->Lamp_par.lamp[pos-1].elname),"")==0)
		//		 continue;
		//		 if ( Inst->Lamp_par.lamp[pos-1].lamp_optpos != 0) continue;
		//		 if(Inst->Lamp_old!=pos){
		//			 sprintf(line1, " Setting Lamp from %d to %d position.     ",Inst->Lamp_old, pos);
		//			 SetText(hwnd, IDC_STATUS1,line1);
		//                                                If (!Position_Turret(hpar, pos, True)) Then
		//				 break;
		//			 SetText(hwnd, IDC_STATUS1,"");
		//		 }
		//		All_Lamp_Off();
		//		lmp_cur = Inst->Lamp_par.lamp[Inst->Lamp_pos-1].cur;
		//		Set_HCL_Cur(lmp_cur,Inst->Lamp_pos);
		//		if (Inst->Cur==(double) 0.0){
		//			Inst->Cur=lmp_cur;
		//		  }
		//          If (Test_Lamp_Presence(hwnd)) Then
		//			Tur_Opt(hwnd, hdc);
		//	  } // for loop end
		//	} // wavelength end
		//	ReleaseDC(hwnd, hdc);
		//	DestroyWindowPeak(hwnd,hpar);
		//  } // hwnd end
		//  if(GetInstrument() != AA202 )
		//	  AIR_ON();
		// } // if already optimised
		// Save_Tuttet_Status();

		//}
		////-------------------------------------

		//--------------------
		//System.Threading.Monitor.Enter(ObjThreadController)
		try {
			//Added by pankaj on 21 Jan 08
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
				funcSet_PMTReferenceBeam(0);
			}
			//---for setting ref. pmt to zero

			if (!lblStatus3 == null) {
				((Windows.Forms.Label)lblStatus3).Text = "Initialising Please Wait  .......";
			}

			//            For i = 0 To 5
			//                If gobjInst.Lamp.LampParametersCollection.item(i).LampOptimizePosition <> 0 Then
			//                    GoTo EndOfLoop
			//                Else
			//                    Exit For
			//                End If
			//EndOfLoop:  Next

			for (i = 0; i <= 5; i++) {
				if (gobjInst.Lamp.LampParametersCollection.item(i).LampOptimizePosition == 0) {
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			if (i < 6) {
				//1.	Check instrument type. If instrument type is not 201 then make air off.
				if (!(gstructSettings.AppMode == EnumAppMode.FullVersion_201)) {
					funcAir_OFF();
				}

				if (!lblStatus3 == null) {
					((Windows.Forms.Label)lblStatus3).Text = "Initialising Please Wait  .......";
				}

				//Saurabh 06-06-2007
				//if funcFind_Wavelength_Home() then
				//2.	Set Wavelength to Home position.
				if (gFuncWavelength_Home(lblWvStatus)) {
					//Saurabh 06-06-2007
					//+++++ToDo later
					//ShowTurretElement(hwnd);
					//+++++ToDo
					for (pos = i + 1; pos <= 6; pos++) {
						//If gobjInst.Lamp.LampParametersCollection.item(pos - 1).ElementName = "" Then
						//    GoTo EndOfLoop1
						//End If
						if (gobjInst.Lamp.LampParametersCollection.item(pos - 1).ElementName != "") {
							//GoTo EndOfLoop1
							//End If
							if (gobjInst.Lamp.LampParametersCollection.item(pos - 1).LampOptimizePosition == 0) {
								//GoTo EndOfLoop1
								//End If
								//If gobjInst.Lamp.LampParametersCollection.item(pos - 1).ElementName <> "" Then
								//If gobjInst.Lamp.LampParametersCollection.item(pos - 1).LampOptimizePosition <> 0 Then
								//GoTo EndOfLoop1
								//End If
								//If gobjInst.Lamp.LampParametersCollection.item(pos - 1).LampOptimizePosition = 0 Then

								//the following line is changed on 15.05.07
								//3.	If lamp, which is to be optimized, is not in current turret position then position turret to that location.
								if (gobjInst.Lamp_Old != pos) {
									//If gobjInst.Lamp_Position <> pos Then

									if (!lblStatus2 == null) {
										//the following line is changed on 15.05.07
										((Windows.Forms.Label)lblStatus2).Text = "Setting Lamp from " + gobjInst.Lamp_Old + " to " + pos + " position.";
										//CType(lblStatus2, Windows.Forms.Label).Text = "Setting Lamp from " & gobjInst.Lamp_Position & " to " & pos & " position."
									}

									if (gFuncTurret_Position(pos, true) == false) {
										//--take lamp current from inst parameters and set it
										break; // TODO: might not be correct. Was : Exit For
									}
									if (!lblStatus2 == null) {
										((Windows.Forms.Label)lblStatus2).Text = " ";
									}
								}

								//4.	Set all lamps off.
								funcAll_Lamp_Off();

								//---21.01.08 deepak
								////----- commented by Sachin Dokhale on 24.04.08
								////----- It's set wrong current for turret opt.
								//gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).Current = dblLampCurrent
								dbllmp_current = gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).Current;
								//---21.01.08 deepak

								intlmp_position = gobjInst.Lamp_Position;

								//5.	Set HCL current to the current turret position.
								if (funcSet_HCL_Cur(dbllmp_current, intlmp_position) == false) {
									gobjMessageAdapter.ShowMessage(constSetHCLCurError);
									Application.DoEvents();
								}

								objWait = new CWaitCursor();

								if (gobjInst.Current == 0.0) {
									////----- Uncommentd and commented by Sachin Dokhale on 24.04.08
									////----- It sets all lamp current by set pass param. value, due to loop
									gobjInst.Current = dbllmp_current;
									//gobjInst.Current = dblLampCurrent
								}

								if (funcTestLampPresence(lblStatus1, lblStatus2, lblStatus3)) {
									intK += 1;
									if (funcTur_Opt_New(lblStatus1, lblStatus2, lblStatus3, ObjGraph, ObjThreadController, intK)) {
									} else {
									}
								}
							}
						}
						//EndOfLoop1:         Next
					}
				} else {
					//MessageBox.Show("Wavelength Home Error")
				}
				//wavelength home end

				objWait = new CWaitCursor();
				//8.	If instrument type is not 201 then Set Air ON.
				if (!(gstructSettings.AppMode == EnumAppMode.FullVersion_201)) {
					funcAir_ON();
				}
			}
			// if i<6 condition end
			//9.	Save lamp position status.
			if (gstructSettings.ExeToRun == EnumApplicationMode.AAS) {
				funcSaveInstStatus();
			}

			//Dim intCounter As Integer
			//For intCounter = 0 To gobjInst.Lamp.LampParametersCollection.Count - 1
			//    gobjInst.Lamp.LampParametersCollection.item(intCounter).LampOptimizePosition = 0
			//Next

			mobjCommdll.subTime_Delay(1000);

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
			objWait.Dispose();
			Application.DoEvents();
			//System.Threading.Monitor.Exit(ObjThreadController)
			//---------------------------------------------------------
		}
	}

	public bool funcTur_Opt_New(ref object lblStatus1 = null, ref object lblStatus2 = null, ref object lblStatus3 = null, ref object ObjGraph = null, object ObjThreadController = null, int intOccurence = 1)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcTur_Opt_New
		//Description            :   To optimise turret
		//Parameters             :   
		//Affected parameter     :   lblStatus1,lblStatus2, lblStatus3, ObjGraph, ObjThreadController,intOccurence
		// Return                :   True if success
		//Time/Date              :   17.11.06
		//Dependencies           :   
		//Author                 :   Deepak B.
		//Revision               :
		//Revision by Person     :   
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		int rPOs;
		int intCounter;
		int chNew;
		int max_int;
		int in_pos;
		double dblEnergy;
		string strData;
		//---------------------------------------------------
		//        void	Tur_Opt(HWND hwnd, HDC hdc)
		//{
		//int    chnew, i;
		//int    in_pos, max_int, rpos;
		//char line7[80]="";

		// SetFocus(hwnd);
		// if( GetInstrument() == AA202)
		//	 SetText(hwnd, IDC_STATUS, "Lamp Optimization");
		//        Else
		//	 SetText(hwnd, IDC_STATUS, "Turret Optimization");
		// Cal_Mode(HCLE);
		// rpos = Tur_pre_opt(hwnd);

		//#If !NEWZERO Then
		//  Adj_PMT_forvalue(hwnd, (double) 3500.0, (double)350);
		//#Else
		//  Adj_PMT_forvalue(hwnd, (double)(3500.0*100.0/5000.0 ), (double)350.0);
		//#End If
		// Show_Pmt(hwnd, Inst->Pmtv);
		// pc_delay (200);
		// for (i=1; i<=rpos+10; i++)  {
		//	Rotate_Anticlock_Tur();
		//	}
		// for (i=1; i<=10; i++) {
		//	Rotate_Clock_Tur();
		//  }
		// if(GetInstrument() == AA202)
		//	 SetWindowText(hwnd,"OPTIMISING LAMP");
		//                    Else
		//	 SetWindowText(hwnd,"OPTIMISING TURRET");
		// PeakGraph.Xmin= 1; PeakGraph.Xmax= RANGE;
		// PeakGraph.Ymin= GetEnergy(2047);
		// PeakGraph.Ymax= GetEnergy(2047.0+409.6*4);
		// strcpy(PYaxis,"ENERGY"); strcpy(PXaxis,"TURRET STEP");
		// Show_Peak_Param(hwnd, RANGE);
		// if( GetInstrument() == AA202 )
		//   SetText(hwnd, IDC_STATUS1, "Scanning for Optimal Lamp Position");
		//                        Else
		//	 SetText(hwnd, IDC_STATUS1, "Scanning for Optimal Turret Position");
		// in_pos = 1;
		// max_int = 0;
		// ReadADCFilter();
		// for (i=1; i<=RANGE; i++) {
		//	Rotate_Clock_Tur();
		//	pc_delay(100);
		//	chnew = ReadADCFilter();
		//	if (chnew > max_int) {
		//	  max_int = chnew;
		//	  in_pos =i;
		//	 }
		//  if (i==1)
		//		GPlotInit(hdc, (double) i, GetEnergy(chnew));
		//                                    Else
		//		GPlot(hdc, (double) i, GetEnergy(chnew));
		// }
		// GShowPeak(hdc,(double) in_pos,  GetEnergy(max_int),NULL);
		// SetText(hwnd, IDC_STATUS," Positioning Please Wait  .......        ");
		//#If EMU Then
		// Wait_For_Some_Msg(5);
		//#End If
		// for (i=1; i <= RANGE+10; i++) 	Rotate_Anticlock_Tur();
		// for (i=1; i <= 10+in_pos; i++)  {
		//	Rotate_Clock_Tur();	
		//	}
		//Inst->Lamp_par.lamp[Inst->Lamp_pos-1].lamp_optpos = in_pos;	
		//for(i=0;i<500; i++)
		// pc_delay(10000);
		//}

		//---------------------------------------------------
		double dblYMin;
		double dblYMax;


		try {
			if (!lblStatus3 == null) {
				if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
					((Windows.Forms.Label)lblStatus3).Text = "Lamp Optimization";
				} else {
					((Windows.Forms.Label)lblStatus3).Text = "Turret Optimization";
				}

			}

			//1.	Set calibration mode to HCLE.

			if (funcCalibrationMode(EnumCalibrationMode.HCLE) == false) {
				gobjMessageAdapter.ShowMessage(constCalibrationMode);
				Application.DoEvents();
			}

			rPOs = funcTur_Pre_Opt(lblStatus1, lblStatus2, lblStatus3);

			if (funcAdj_Pmt_ForValue((double)70.0, (double)350.0, true) == false) {
				gobjMessageAdapter.ShowMessage(constPMTVolt);
				Application.DoEvents();
			}

			if (!lblStatus1 == null) {
				((Windows.Forms.Label)lblStatus1).Text = "PMT : -" + Format(gobjInst.PmtVoltage, "###");
				((Windows.Forms.Label)lblStatus1).Refresh();
			}

			objWait = new CWaitCursor();

			//mobjCommdll.subTime_Delay(200)
			//4.	Rotate turret anticlockwise (pre optimize turret position + 10) times.
			for (intCounter = 1; intCounter <= rPOs + 10; intCounter++) {
				funcRotate_Anticlock_Tur();
			}

			//5.	Rotate turret 10 times clockwise.
			for (intCounter = 1; intCounter <= 10; intCounter++) {
				funcRotate_Clock_Tur();
			}

			objWait = new CWaitCursor();

			dblYMin = 0;
			//CInt(FormatNumber(gFuncGetEnergy(2047), 1))
			dblYMax = (int)FormatNumber(gFuncGetEnergy(2047.0 + 409.6 * 4), 1);

			if (!ObjGraph == null) {
				((AASGraph)ObjGraph).XAxisMin = 0;
				((AASGraph)ObjGraph).XAxisMax = WVRANGE;
				((AASGraph)ObjGraph).YAxisMin = dblYMin;
				((AASGraph)ObjGraph).YAxisMax = dblYMax;
				((AASGraph)ObjGraph).XAxisLabel = "TURRET STEP";
				((AASGraph)ObjGraph).YAxisLabel = "ENERGY";
				((AASGraph)ObjGraph).AldysPane.AxisChange();
				((AASGraph)ObjGraph).Invalidate();
				((AASGraph)ObjGraph).Refresh();
			}

			if (!lblStatus2 == null) {
				if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
					((Windows.Forms.Label)lblStatus2).Text = "Scanning for Optimal Lamp Position";
				} else {
					((Windows.Forms.Label)lblStatus2).Text = "Scanning for Optimal Turret Position";
				}
			}

			objWait = new CWaitCursor();
			in_pos = 1;
			max_int = 0;
			//6.	Read ADC filter.
			funcReadADCFilter(gobjInst.Average, chNew);

			//---todo to be checked
			((AAS203.AASGraph)ObjGraph).AldysPane.CurveList.Clear();
			((AAS203.AASGraph)ObjGraph).AldysPane.AxisChange();
			((AAS203.AASGraph)ObjGraph).RemoveHighPeakLineLabel();
			((AAS203.AASGraph)ObjGraph).Refresh();
			Application.DoEvents();
			//---todo to be checked

			for (intCounter = 1; intCounter <= WVRANGE; intCounter++) {
				//8.	Rotate turret clockwise.
				funcRotate_Clock_Tur();
				//mobjCommdll.subTime_Delay(100)
				//9.	Read ADC filter.
				funcReadADCFilter(gobjInst.Average, chNew);

				//12.	During these 100 ADC readings memorize highest 
				//ADC filter reading and counter number of it.

				if (chNew > max_int) {
					max_int = chNew;
					in_pos = intCounter;
				}
				//10.	Convert ADC filter reading to millivolt.
				dblEnergy = gFuncGetEnergy(chNew);
				strData = "";
				strData = intCounter + "," + dblEnergy + "," + intOccurence;
				//11.	Plot this energy point on graph.
				if (!ObjThreadController == null) {
					((BgThread.IBgThread)ObjThreadController).Display(strData);
				}
				((AASGraph)ObjGraph).Refresh();
			}
			//GShowPeak(hdc,(double) in_pos,  GetEnergy(max_int),NULL);  todo later

			if (!lblStatus2 == null) {
				((Windows.Forms.Label)lblStatus2).Text = "Positioning Please Wait  .......        ";
			}

			//13.	Rotate turret anticlockwise 110 times.
			for (intCounter = 1; intCounter <= WVRANGE + 10; intCounter++) {
				funcRotate_Anticlock_Tur();
			}

			objWait = new CWaitCursor();
			//14.    Rotate turret clockwise (highest ADC counter number + 10) times.
			for (intCounter = 1; intCounter <= 10 + in_pos; intCounter++) {
				funcRotate_Clock_Tur();
			}

			gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).LampOptimizePosition = in_pos;

			if (!lblStatus2 == null) {
				((Windows.Forms.Label)lblStatus2).Text = "Finished. ";
			}

			if (!ObjThreadController == null) {
				((BgThread.IBgThread)ObjThreadController).Completed(false);
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
			objWait.Dispose();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	//Private Function funcOptimise_Zero_Order(Optional ByRef lblStatus1 As Object = Nothing, _
	//                                         Optional ByRef lblStatus2 As Object = Nothing, _
	//                                         Optional ByRef lblStatus3 As Object = Nothing) As Boolean
	//    '-------------------------------------------------------------------------------------------
	//    'Procedure Name         :   funcTurret_Optimise
	//    'Description            :   To optimise Turret position 
	//    'Parameters             :   dblLampCurrent = current to be set to lamp
	//    '                           intLampPos = lamp position to which current to be set
	//    'Time/Date              :   5/10/06
	//    'Dependencies           :   
	//    'Author                 :   Deepak B.
	//    'Revision               :
	//    'Revision by Person     :   Deepak B. on 26.11.06
	//    '-------------------------------------------------------------------------------------------
	//    '-------------------------------------
	//    '        void	S4FUNC 	Optimize_Zero_order(HWND hpar)
	//    '{
	//    ' double   cur=0.0;
	//    ' HWND		hwnd, hwnd1;
	//    ' HDC		hdc, hdc1;
	//    ' BOOL		flag= TRUE, zero = FALSE;
	//    ' char    line1[80]="";
	//    ' int     pos;

	//    '#ifndef FINAL
	//    '  Get_Instrument_Parameters(&Inst);
	//    '#End If

	//    '  MessageBox(hwnd, "Plz select whether you want to skip zero order or not", "AAS203", MB_OK);

	//    ' if (MessageBox(hwnd, "Do you want to perform zero order", "Confirmation", MB_YESNO)==IDYES)
	//    ' {

	//    ' Inst =  GetInstData();
	//    ' if(GetInstrument() != AA202 )
	//    '	 AIR_OFF();
	//    ' hwnd1= CreateWindowPeak(hpar, " TURRET OPTIMISATION","SKCK1",2 );
	//    ' hwnd= CreateWindowPeak(hpar, " ZERO ORDER ","SKCK1",1 );
	//    ' if (hwnd && hwnd1){
	//    '	hdc= GetDC(hwnd);
	//    '	SetBkColor(hdc, RGB(192, 192, 192));
	//    '	hdc1= GetDC(hwnd1);
	//    '	SetBkColor(hdc1, RGB(192, 192, 192));
	//    '	SetText(hwnd, IDC_STATUS,"Initialising Please Wait  .......");
	//    '	for (pos = 0; pos<6; pos++)
	//    '	  Inst->Lamp_par.lamp[pos].lamp_optpos=0;
	//    '	Inst->Lamp_par.wvzero = 100.0;
	//    '	if (Find_Turret_Home(hpar)){
	//    '	  if(Find_Wavelength_Home(hdc, 5, 150)){
	//    '		 ShowTurretElement(hwnd);
	//    '		 if (Slit_Home()){
	//    '		  for (pos = 1; pos<=6; pos++){
	//    '			 if (strcmp(trim(Inst->Lamp_par.lamp[pos-1].elname),"")==0)
	//    '				continue;
	//    '			 if(Inst->Lamp_old!=pos){
	//    '				strcpy(line1,"");
	//    '				sprintf(line1, " Setting Lamp from %d to %d position. ",Inst->Lamp_old, pos);
	//    '				SetText(hwnd, IDC_STATUS,line1);
	//    '				if (!Position_Turret(hpar, pos,TRUE)){
	//    '					Gerror_message_new("Error in Turret Module ..", "TURRET");
	//    '					break;
	//    '				  }
	//    '			  }
	//    '			 SetText(hwnd, IDC_STATUS,"Initialising Please Wait  .......        ");
	//    '//	       disp_el(); disp_data( 5, 1, 65, lamp_pos-1);	  pc_sound(500,1);
	//    '			 All_Lamp_Off();
	//    '			 cur = Inst->Lamp_par.lamp[Inst->Lamp_pos-1].cur;
	//    '			 Set_HCL_Cur(cur,Inst->Lamp_pos);
	//    '			 if (Inst->Cur==(double) 0.0){
	//    '//				Gerror_message_new("cur is  0.0", "Warning");
	//    '				Inst->Cur=cur;
	//    '			  }

	//    '			 flag=Test_Lamp_Presence(hwnd);
	//    '			 if (flag){
	//    '				if (!zero){
	//    '				  InitGraphParam(hwnd);SetFocus(hwnd);
	//    '				  zero = Zero_Order(hwnd, hdc);
	//    '				  if (!zero) {
	//    '					 Gerror_message_new("ZERO-ORDER Peak not found", "ZERO ORDER");
	//    '					 Beep();//pc_sound(1000,2);;pc_sound(1000,2); pc_sound(1000,2);
	//    '					 flag=FALSE;
	//    '					}
	//    '				  InitGraphParam(hwnd1);
	//    '				 }//!zero
	//    '			  if (flag){
	//    '				 SetFocus(hwnd1);
	//    '				 Tur_Opt(hwnd1, hdc1);
	//    '				 }
	//    '			  else break;
	//    '			}//if flag
	//    '		 } //for
	//    '		} //slit home
	//    '	  } // find_mech_zero
	//    '	 } //turret home
	//    '	ReleaseDC(hwnd, hdc);
	//    '	DestroyWindowPeak(hwnd,hpar);
	//    '	ReleaseDC(hwnd1, hdc1);
	//    '	DestroyWindowPeak(hwnd1,hpar);
	//    '  if(GetInstrument() != AA202 )
	//    '	  AIR_ON();
	//    ' }  // if oflag
	//    ' } //messagebox if condition true
	//    '       ReleaseDC(hwnd, hdc);
	//    'DestroyWindowPeak(hwnd,hpar);
	//    ' if(GetInstrument() != AA202 )
	//    ' AIR_ON();
	//    '-------------------------------------
	//    Dim objWait As New CWaitCursor
	//    Dim intCounter As Integer
	//    Dim blnFlag As Boolean
	//    Dim blnZeroOrder As Boolean
	//    Dim intPos As Integer
	//    Dim dbllmp_current As Double
	//    Dim intlmp_position As Integer

	//    Try
	//        If Not (gstructSettings.AppMode = EnumAppMode.FullVersion_201) Then
	//            Call funcAir_OFF()
	//        End If


	//        If Not lblStatus1 Is Nothing Then
	//            CType(lblStatus1, Windows.Forms.Label).Text = "Initialising Please Wait  ......."
	//        End If

	//        For intPos = 0 To 5
	//            gobjInst.Lamp.LampParametersCollection.item(intPos).LampOptimizePosition = 0
	//        Next
	//        gobjInst.Lamp.WavelengthZero = 100.0

	//        If gFuncTurret_Home() Then
	//            If funcFind_Wavelength_Home() Then
	//                '-ShowTurretElement todo for flame
	//                If gFuncSlit_Home() Then
	//                    For intPos = 1 To 6
	//                        If gobjInst.Lamp.LampParametersCollection.item(intPos - 1).ElementName <> "" Then
	//                            If gobjInst.Lamp_Old <> intPos Then
	//                                If Not lblStatus2 Is Nothing Then
	//                                    CType(lblStatus2, Windows.Forms.Label).Text = "Setting Lamp from " & gobjInst.Lamp_Old & " to " & intPos & " position."
	//                                End If
	//                                If gobjCommProtocol.gFuncTurret_Position(intPos, True) = False Then
	//                                    Exit For
	//                                End If
	//                            End If
	//                        End If

	//                        If Not lblStatus2 Is Nothing Then
	//                            CType(lblStatus2, Windows.Forms.Label).Text = "Initialising Please Wait  ......."
	//                        End If

	//                        Call funcAll_Lamp_Off()

	//                        dbllmp_current = gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).Current
	//                        intlmp_position = gobjInst.Lamp_Position

	//                        If gobjCommProtocol.funcSet_HCL_Cur(dbllmp_current, intlmp_position) = True Then
	//                            '--- Do Nothing
	//                        Else
	//                            'MessageBox.Show("Error in setting HCL current")
	//                            gobjMessageAdapter.ShowMessage(constSetHCLCurError)
	//                            Application.DoEvents()
	//                        End If

	//                        If gobjInst.Current = 0.0 Then
	//                            gobjInst.Current = dbllmp_current
	//                        End If

	//                        blnFlag = funcTestLampPresence()

	//                        If blnFlag Then
	//                            If Not blnZeroOrder Then
	//                                blnZeroOrder = funcZero_Order()
	//                                If Not blnZeroOrder Then
	//                                    gobjMessageAdapter.ShowMessage(constZeroOrderPeakNotFound)
	//                                    Application.DoEvents()
	//                                    blnFlag = False
	//                                End If
	//                            End If
	//                            If blnFlag Then
	//                                If funcTur_Opt_New() Then
	//                                    'do nothing
	//                                End If
	//                            Else
	//                                Exit For
	//                            End If
	//                        End If 'blnflag
	//                    Next 'for loop
	//                End If ' slit home 
	//            End If ' wv zero
	//        End If ' turret home
	//        If Not (gstructSettings.AppMode = EnumAppMode.FullVersion_201) Then
	//            Call funcAir_ON()
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
	//        objWait.Dispose()
	//        '---------------------------------------------------------
	//    End Try
	//End Function

	//Private Function funcZero_Order(Optional ByRef lblStatus1 As Object = Nothing, _
	//                               Optional ByRef lblStatus2 As Object = Nothing, _
	//                               Optional ByRef lblStatus3 As Object = Nothing) As Boolean
	//    '------------------------------------------------------------------
	//    'Procedure Name         :   funcZero_Order
	//    'Description            :   To optimise turret
	//    'Parameters             :   None
	//    'Time/Date              :   5/10/06
	//    'Dependencies           :   
	//    'Author                 :   Deepak B.
	//    'Revision               :
	//    'Revision by Person     :   Deepak B. on 26.11.06
	//    '------------------------------------------------------------------
	//    Dim objWait As New CWaitCursor
	//    Dim rPOs As Integer
	//    Dim intCounter As Integer
	//    Dim chNew, chBase As Integer
	//    Dim max_int As Integer
	//    Dim in_pos As Integer
	//    Dim blnFlag As Boolean = False

	//    Try
	//        If funcCalibrationMode(EnumCalibrationMode.HCLE) = False Then
	//            'MessageBox.Show("Error in setting calibration mode")
	//            gobjMessageAdapter.ShowMessage(constCalibrationMode)
	//            Application.DoEvents()
	//        End If

	//        If Not lblStatus2 Is Nothing Then
	//            CType(lblStatus2, Windows.Forms.Label).Text = "ZERO-ORDER Peak Search"
	//        End If

	//        rPOs = funcSearch_Approc_WV_Peak(WVZERORANGE, 120.0)

	//        '---to confirm from 16 bit code
	//        funcAdj_Pmt_ForValue(CDbl(3500.0), CDbl(350), False)
	//        '------

	//        If Not lblStatus1 Is Nothing Then
	//            CType(lblStatus1, Windows.Forms.Label).Text = "PMT : -" & gobjInst.PmtVoltage.ToString
	//        End If

	//        'PeakGraph.Ymin= GetEnergy(2047);
	//        'PeakGraph.Ymax= GetEnergy(2047.0+409.6*5);

	//        max_int = 3000
	//        blnFlag = False
	//        intCounter = 1

	//        For intCounter = 1 To rPOs + STEPS_PER_NM
	//            Call funcRotate_Anticlock_Wv()
	//        Next

	//        For intCounter = 1 To STEPS_PER_NM
	//            Call funcRotate_Clock_Wv()
	//        Next

	//        If funcGet_Current_Wv(gobjInst.WavelengthCur) Then
	//            'MessageBox.Show("Error in setting current wavelength")
	//            gobjMessageAdapter.ShowMessage(constSetCurWvError)
	//            Application.DoEvents()
	//        End If

	//        'PeakGraph.Xmin= Inst->Wvcur;
	//        'PeakGraph.Xmax= Inst->Wvcur+WVZERORANGE/(double) stepspernm;

	//        'Show_Peak_Param(hwnd, WVZERORANGE); to confirm

	//        If Not lblStatus3 Is Nothing Then
	//            CType(lblStatus3, Windows.Forms.Label).Text = "ZERO-ORDER  peak Search  Range ( " & gobjInst.WavelengthCur & "nm - " & (gobjInst.WavelengthCur + WVZERORANGE) / STEPS_PER_NM & "nm)"
	//        End If

	//        in_pos = 1
	//        max_int = 0

	//        Call funcReadADCFilter(gobjInst.Average, chBase)

	//        For intCounter = 1 To WVZERORANGE
	//            Call funcRotate_Clock_Wv()
	//            Call funcReadADCFilter(gobjInst.Average, chNew)

	//            If chNew > max_int Then
	//                max_int = chNew
	//                in_pos = intCounter
	//                If max_int - chBase > 210 Then
	//                    blnFlag = True
	//                End If
	//            End If

	//            If intCounter = 1 Then
	//                'GPlotInit(hdc, Inst->Wvcur+(double)i/(double) stepspernm, GetEnergy( chnew));
	//            Else
	//                'GPlot(hdc, Inst->Wvcur+(double)i/(double) stepspernm, GetEnergy(chnew));
	//            End If
	//        Next

	//        'GShowPeak(hdc,Inst->Wvcur+(double)in_pos/(double) stepspernm,  GetEnergy(max_int),NULL);
	//        'SetText(hwnd, IDC_STATUS1," Positioning to 0.00 nm Please Wait ..... ");

	//        If Not lblStatus3 Is Nothing Then
	//            CType(lblStatus3, Windows.Forms.Label).Text = " Positioning to 0.00 nm Please Wait ..... "
	//        End If

	//        For intCounter = 1 To WVZERORANGE + STEPS_PER_NM
	//            Call funcRotate_Anticlock_Wv()
	//        Next

	//        For intCounter = 1 To in_pos + STEPS_PER_NM
	//            Call funcRotate_Clock_Wv()
	//        Next

	//        If funcGet_Current_Wv(gobjInst.WavelengthCur) Then
	//            'MessageBox.Show("Error in setting current wavelength")
	//            gobjMessageAdapter.ShowMessage(constSetCurWvError)
	//            Application.DoEvents()
	//        End If

	//        gobjInst.Lamp.WavelengthZero = gobjInst.WavelengthCur
	//        gobjInst.WavelengthCur = 0.0

	//        funcSet_Current_Wv(gobjInst.WavelengthCur)

	//        funcSet_SlitWidth(0.3)

	//        'mobjCommdll.subTime_Delay(200)

	//        Return blnFlag

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
	//        objWait.Dispose()
	//        '---------------------------------------------------------
	//    End Try
	//End Function

	public int funcSearch_Approc_WV_Peak(int intSteps, double dblPmtv, ref object lblStatus1 = null, ref object lblStatus2 = null, ref object lblStatus3 = null)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcSearch_Approc_WV_Peak
		//Description            :   To optimise Turret 
		//Parameters             :   intSteps,dblPmtv, 
		//Affected Parameter     :   lblStatus1,lblStatus2, lblStatus3
		//Return                 :   Return Highest ADC filter reading counter numbe
		//Time/Date              :   26.11.06
		//Dependencies           :   
		//Author                 :   Deepak B.
		//Revision               :
		//Revision by Person     :   
		//-------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		int intCounter;
		int intCounter1;
		int chNew;
		int n_pos = 1;
		int max_int = -1;
		int int_pos;

		//int Search_Approc_wv_Peak(HWND hwnd, int steps, double	pmt)
		//{
		//   // returns the rough peak value
		//   int 	i, in_pos, chnew;
		//   char 	line1[80]="";
		//   #If !DEMO Then
		//       int   npos=1, j, max_int=-1;
		//   #End If
		//   float stepspernm=50.0;
		//   if (GetInstrument()==AA202){
		//       stepspernm = STEPS_PER_NM_AA202;
		//   }
		//   else{
		//       stepspernm = STEPS_PER_NM;
		//   }

		//   strcpy(line1,"");
		//   Set_PMT(pmt);
		//   Adj_pmt_NearZeroWv(hwnd);
		//   Show_Pmt(hwnd, Inst->Pmtv);
		//   Inst->Wvcur = Get_Cur_Wv();
		//   if (Inst->Wvcur<10)
		//	    sprintf(line1," Positioning to  -2.0 nm Wait ..... "); 
		//   Else
		//	    sprintf(line1," Positioning to  %-5.2f nm Wait ..... ",
		//		Inst->Wvcur-(steps/(double) (stepspernm*(float)2.0)) ); //100.0));

		//   SetText(hwnd, IDC_STATUS1,line1);
		//   for (i=1; i<=(steps/(float)2.0)+stepspernm; i++)   {
		//	    Rotate_Anticlock_Wv(	);
		//	}
		//   for (i=1; i<=stepspernm; i++)  {
		//	    Rotate_Clock_Wv(); 
		//	}
		//   Inst->Wvcur = Get_Cur_Wv();
		//   in_pos = 1;  

		//   for (i=1; i<=steps; i++) {
		//	    Rotate_Clock_Wv();	
		//	    chnew = ReadADCFilter();
		//       #If !DEMO Then
		//	        if ( ((chnew-2047.0)/4096.0*10000.0)>=4900.0)    
		//           {
		//		        SetText(hwnd, IDC_STATUS1, " FULL SCALE RESET  Please Wait ..... ");
		//		        npos++;
		//		        if (npos>2)
		//		            break;
		//		        Adj_pmt_NearZeroWv(hwnd);
		//		        Show_Pmt(hwnd, Inst->Pmtv);
		//		        for (j=1; j<=i+stepspernm; j++)  {
		//		            Rotate_Anticlock_Wv();
		//		        }
		//		        for (j=1; j<=stepspernm; j++) {
		//		            Rotate_Clock_Wv();
		//		        }
		//		        i=0; in_pos = 1;  max_int = 0; chnew=0;
		//		        Inst->Wvcur = Get_Cur_Wv();
		//	        }
		//	        if (chnew > max_int && i!=1) {
		//	            max_int = chnew;
		//	            in_pos =i;
		//	        }
		//       #End If
		//       sprintf(line1," Wv : %5.2f nm  Aprox.Peak %5.2f  Energy %5.0f ",
		//	    Inst->Wvcur+i/(double)stepspernm,
		//		Inst->Wvcur+in_pos/(double)stepspernm,
		//		(double) GetmV(chnew));
		//       SetText(hwnd, IDC_STATUS1,line1);
		//   }

		//   Inst->Wvcur = Get_Cur_Wv();
		//   SetText(hwnd, IDC_STATUS,"Positioning Please Wait  .......");

		//   for (i=1; i <= steps+stepspernm; i++)  {
		//	    Rotate_Anticlock_Wv(); 
		//	}
		//   for (i=1; i <= in_pos+stepspernm; i++) {
		//	    Rotate_Clock_Wv();
		//	}
		//   Inst->Wvcur = Get_Cur_Wv();
		//   chnew = ReadADCFilter();
		//   sprintf(line1," Wv : %5.2f nm  Aprox.Peak %5.2f  Energy %5.0f ", Inst->Wvcur+i/(double)stepspernm,
		//			Inst->Wvcur+in_pos/(double)stepspernm, (double)GetmV(chnew));
		//   SetText(hwnd, IDC_STATUS1,line1);
		//   SetText(hwnd, IDC_STATUS1,"");
		//   return in_pos;
		//}

		try {
			//1.	Set pmt voltage.

			if (funcSet_PMT(dblPmtv) == false) {
				//---12.02.08
				Application.DoEvents();
				//If funcSet_PMT(dblPmtv) = False Then
				//End If
			}

			//2.	Adjust pmt near zero wavelength.
			if (funcAdj_Pmt_NearZeroWV(lblStatus1, lblStatus2, lblStatus3) == false) {
				gobjMessageAdapter.ShowMessage(constErrorSettingPMT);
				Application.DoEvents();
			}

			if (!lblStatus1 == null) {
				((Windows.Forms.Label)lblStatus1).Text = "PMT : -" + Format(gobjInst.PmtVoltage, "###");
			}

			//mobjCommdll.subTime_Delay(2000) '''''  extradelay

			//3.	Get Current Wavelength from instrument.
			if (funcGet_Current_Wv(gobjInst.WavelengthCur) == false) {
				gobjMessageAdapter.ShowMessage(constSetCurWvError);
				Application.DoEvents();
			}

			//If funcGet_Current_Wv(gobjInst.WavelengthCur) = False Then    '''''''' extradelay
			//    gobjMessageAdapter.ShowMessage(constSetCurWvError)
			//    Application.DoEvents()
			//End If


			if (gobjInst.WavelengthCur < 10) {
				if (!lblStatus2 == null) {
					((Windows.Forms.Label)lblStatus2).Text = "Positioning to  -2.0 nm Wait ..... ";
				}
			} else {
				if (!lblStatus2 == null) {
					((Windows.Forms.Label)lblStatus2).Text = "Positioning to  " + gobjInst.WavelengthCur - (intSteps / (CONST_STEPS_PER_NM * 2.0)) + " nm Wait ..... ";
				}
			}

			//4.	If instrument type is 201 then rotate wavelength  
			//drive anticlockwise ((WVZERORANGE / 2.0 ) + 25) times.

			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				for (intCounter = 1; intCounter <= (intSteps / 2.0) + CONST_STEPS_PER_NM_AA201; intCounter++) {
					funcRotate_Anticlock_Wv();
				}

				//5.	If instrument type is 201 then rotate wavelength  drive clockwise (25) times.

				for (intCounter = 1; intCounter <= CONST_STEPS_PER_NM_AA201; intCounter++) {
					funcRotate_Clock_Wv();
				}
			} else {
				//6.	If instrument type is not 201 then rotate wavelength  
				//drive anticlockwise ((WVZERORANGE / 2.0 ) + 50) times.

				for (intCounter = 1; intCounter <= (intSteps / 2.0) + CONST_STEPS_PER_NM; intCounter++) {
					funcRotate_Anticlock_Wv();
				}

				//7.	If instrument type is not 201 then rotate wavelength  drive clockwise (50) times.

				for (intCounter = 1; intCounter <= CONST_STEPS_PER_NM; intCounter++) {
					funcRotate_Clock_Wv();
				}
			}

			//8.	Get Current Wavelength from instrument.

			if (funcGet_Current_Wv(gobjInst.WavelengthCur) == false) {
				gobjMessageAdapter.ShowMessage(constSetCurWvError);
				Application.DoEvents();
			}

			int_pos = 1;

			//9.	Repeat following steps for WVZERORANGE times.
			for (intCounter = 1; intCounter <= intSteps; intCounter++) {
				//10.	Rotate Wavelength drive clockwise.
				funcRotate_Clock_Wv();
				//mobjCommdll.subTime_Delay(500) ''''  extradelay
				//11.	Read ADC filter.
				funcReadADCFilter(gobjInst.Average, chNew);

				//mobjCommdll.subTime_Delay(500) ''''  extradelay

				//-if not demo
				//12.	Calculate (ADC Filter reading - 2047) / 4096 * 10000
				if (((chNew - 2047.0) / 4096.0 * 10000.0) >= 4900.0) {
					if (!lblStatus2 == null) {
						((Windows.Forms.Label)lblStatus2).Text = "FULL SCALE RESET  Please Wait ..... ";
						((Windows.Forms.Label)lblStatus2).Refresh();
					}

					n_pos += 1;

					//---following condition is changed to 3 from 2
					//---as suggested by mr. VCK on 05.02.08
					if (n_pos > 3) {
						break; // TODO: might not be correct. Was : Exit For
					}
					//14.	Adjust pmt near zero wavelength.
					if (funcAdj_Pmt_NearZeroWV(lblStatus1, lblStatus2, lblStatus3) == false) {
						gobjMessageAdapter.ShowMessage(constErrorSettingPMT);
						Application.DoEvents();
					}

					if (!lblStatus1 == null) {
						((Windows.Forms.Label)lblStatus1).Text = "PMT : -" + Format(gobjInst.PmtVoltage, "###");
					}

					//***************************************************
					//---Added by Mangesh on 12-Apr-2007 for AA201
					//***************************************************
					//15.	If instrument type is 201 then rotate wavelength 
					//drive anticlockwise (Counter number + 25 ) times.
					if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
						for (intCounter1 = 1; intCounter1 <= intCounter + CONST_STEPS_PER_NM_AA201; intCounter1++) {
							funcRotate_Anticlock_Wv();
						}
						//16.	If instrument type is 201 then rotate wavelength drive clockwise ( 25 ) times.
						for (intCounter1 = 1; intCounter1 <= CONST_STEPS_PER_NM_AA201; intCounter1++) {
							funcRotate_Clock_Wv();
						}
					//***************************************************
					} else {
						//17.	If instrument type is not 201 then rotate wavelength 
						//drive anticlockwise ( Counter number + 50 ) times.
						for (intCounter1 = 1; intCounter1 <= intCounter + CONST_STEPS_PER_NM; intCounter1++) {
							funcRotate_Anticlock_Wv();
						}
						//18.	If instrument type is not 201 then rotate wavelength 
						//drive clockwise ( 50 ) times.
						for (intCounter1 = 1; intCounter1 <= CONST_STEPS_PER_NM; intCounter1++) {
							funcRotate_Clock_Wv();
						}
					}

					intCounter = 0;
					int_pos = 1;
					max_int = 0;
					chNew = 0;
					//19.	Get current Wavelength.
					if (funcGet_Current_Wv(gobjInst.WavelengthCur) == false) {
						gobjMessageAdapter.ShowMessage(constSetCurWvError);
						Application.DoEvents();
					}
				}
				//20.	Memorize highest ADC filter reading throughout iterations and its counter number.
				if ((chNew > max_int) & (intCounter != 1)) {
					max_int = chNew;
					int_pos = intCounter;
				}

				if (!IsNothing(lblStatus2)) {
					//***************************************************
					//---Added by Mangesh on 12-Apr-2007 for AA201
					//***************************************************
					if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
						((Windows.Forms.Label)lblStatus2).Text = "Wavelength : " + Format(gobjInst.WavelengthCur + intCounter / CONST_STEPS_PER_NM_AA201, "0.00") + " nm " + "Approx.Peak : " + Format(gobjInst.WavelengthCur + int_pos / CONST_STEPS_PER_NM_AA201, "0.00") + " Energy : " + Format(gFuncGetmv(chNew), "#0.00");
					//***************************************************
					} else {
						((Windows.Forms.Label)lblStatus2).Text = "Wavelength : " + Format(gobjInst.WavelengthCur + intCounter / CONST_STEPS_PER_NM, "0.00") + " nm " + "Approx.Peak : " + Format(gobjInst.WavelengthCur + int_pos / CONST_STEPS_PER_NM, "0.00") + " Energy : " + Format(gFuncGetmv(chNew), "#0.00");
					}

				}

			}
			//21.	Get current Wavelength.
			if (funcGet_Current_Wv(gobjInst.WavelengthCur) == false) {
				gobjMessageAdapter.ShowMessage(constSetCurWvError);
				Application.DoEvents();
			}

			if (!lblStatus3 == null) {
				((Windows.Forms.Label)lblStatus3).Text = "Positioning Please Wait  .......";
			}

			//***************************************************
			//---Added by Mangesh on 12-Apr-2007 for AA201
			//***************************************************
			//22.	If instrument type is 201 then rotate wavelength 
			//drive anticlockwise (WVZERORANGE + 25 ) times.
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				for (intCounter = 1; intCounter <= intSteps + CONST_STEPS_PER_NM_AA201; intCounter++) {
					funcRotate_Anticlock_Wv();
				}
				//23.	If instrument type is 201 then rotate wavelength drive clockwise ( 25 ) times.
				for (intCounter = 1; intCounter <= int_pos + CONST_STEPS_PER_NM_AA201; intCounter++) {
					funcRotate_Clock_Wv();
				}
			//***************************************************

			} else {
				//24.	If instrument type is not 201 then rotate wavelength 
				//drive anticlockwise (WVZERORANGE + 50 ) times.
				for (intCounter = 1; intCounter <= intSteps + CONST_STEPS_PER_NM; intCounter++) {
					funcRotate_Anticlock_Wv();
				}
				//25.	If instrument type is not 201 then rotate wavelength drive clockwise ( 50 ) times.
				for (intCounter = 1; intCounter <= int_pos + CONST_STEPS_PER_NM; intCounter++) {
					funcRotate_Clock_Wv();
				}
			}
			//26.	Get current Wavelength.
			if (funcGet_Current_Wv(gobjInst.WavelengthCur) == false) {
				gobjMessageAdapter.ShowMessage(constSetCurWvError);
				Application.DoEvents();
			}
			//27.	Read ADC Filter.
			funcReadADCFilter(gobjInst.Average, chNew);

			if (!IsNothing(lblStatus2)) {
				//***************************************************
				//---Added by Mangesh on 12-Apr-2007 for AA201
				//***************************************************
				if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
					((Windows.Forms.Label)lblStatus2).Text = "Wavelength : " + Format(gobjInst.WavelengthCur + intCounter / CONST_STEPS_PER_NM_AA201, "0.00") + " nm " + "Approx.Peak : " + Format((gobjInst.WavelengthCur + int_pos / CONST_STEPS_PER_NM_AA201), "0.00") + " Energy : " + Format(gFuncGetmv(chNew), "#0.00");
				//***************************************************
				} else {
					((Windows.Forms.Label)lblStatus2).Text = "Wavelength : " + Format(gobjInst.WavelengthCur + intCounter / CONST_STEPS_PER_NM, "0.00") + " nm " + "Approx.Peak : " + Format((gobjInst.WavelengthCur + int_pos / CONST_STEPS_PER_NM), "0.00") + " Energy : " + Format(gFuncGetmv(chNew), "#0.00");
				}

			}

			if (!IsNothing(lblStatus2)) {
				((Windows.Forms.Label)lblStatus2).Text = "";
				((Windows.Forms.Label)lblStatus2).Refresh();
			}
			//28.	Return Highest ADC filter reading counter number.
			return int_pos;

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
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcAdj_Pmt_NearZeroWV(ref object lblStatus1 = null, ref object lblStatus2 = null, ref object lblStatus3 = null)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcAdj_Pmt_NearZeroWV
		//Description            :   To adjust PMT near zero wv
		//Affected parameter     :   lblStatus1,lblStatus2,lblStatus3
		//return                 :   true if success
		//Parameters             :   None
		//Time/Date              :   6/10/06
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Deepak B. on 17.11.06 major changes
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		int chNew;
		double dblPmtv = 0.0;
		int intAvgMV;
		//+++++++++++++++++++++++++++++++++++
		//        void  Adj_pmt_NearZeroWv(HWND hpar)
		//{
		//int 	chnew;
		//double	pmtv=(double)0.0;

		//  chnew = ReadADCFilter();
		//  pmtv=Inst->Pmtv;
		//        If (((chNew - 2047.0) / 4096.0 * 10000.0) >= 2000.0) Then
		//	do  {
		//		pmtv-=(double)5.0;   Set_PMT(pmtv);
		//		Show_Pmt(hpar, Inst->Pmtv);
		//		pc_delay(1000);pc_delay(1000);pc_delay(1000);
		//		chnew = ReadADCFilter();
		//		if ( ((chnew-2047.0)/4096.0*10000.0)<2000.0) break;
		//		if (pmtv>(double)700) {Gerror_message_new("PMT Too high","PMT"); break;}
		//		if (pmtv<(double)50)  {Gerror_message_new("PMT Too low","PMT"); break;}
		//		pc_delay(1000);pc_delay(1000);pc_delay(1000);
		//	 }
		//	while (1);
		//  else  if (((chnew-2047.0)/4096.0*10000.0)< 100.0)
		//  do{
		//	 pmtv++;   Set_PMT(pmtv);
		//	 Show_Pmt(hpar, Inst->Pmtv);
		//	 pc_delay(1000);pc_delay(1000);pc_delay(1000);
		//	 chnew = ReadADCFilter();
		//	 pc_delay(1000);pc_delay(1000);pc_delay(1000);
		//	 if ( ((chnew-2047.0)/4096.0*10000.0)>100.0) break;
		//	 if (pmtv>(double)700) {Gerror_message_new("PMT Too high","PMT"); break;}
		//	 if (pmtv<(double)50) {Gerror_message_new("PMT Too low","PMT"); break;}
		//	}
		//	while (1);
		//}
		//+++++++++++++++++++++++++++++++++++

		try {
			//1.	Read ADC filter

			funcReadADCFilter(gobjInst.Average, chNew);

			dblPmtv = gobjInst.PmtVoltage;

			//2.	Calculate ((ADC filter Reading - 2047.0) / 4096.0 * 10000.0)

			if (((chNew - 2047.0) / 4096.0 * 10000.0) >= 2000.0) {
				do {
					//6.	pmt voltage = pmt voltage � 5.0

					dblPmtv -= (double)5.0;

					//7.	set pmt voltage

					funcSet_PMT(dblPmtv);
					if (!lblStatus1 == null) {
						((Windows.Forms.Label)lblStatus1).Text = "PMT : -" + gobjInst.PmtVoltage;
					}

					//mobjCommdll.subTime_Delay(2000) '''''''' extradelay
					//8.	Read ADC filter

					funcReadADCFilter(gobjInst.Average, chNew);
					if (((chNew - 2047.0) / 4096.0 * 10000.0) < 2000.0) {
						break; // TODO: might not be correct. Was : Exit Do
					}
					if (dblPmtv > (double)700) {
						gobjMessageAdapter.ShowMessage(constPMT2High);
						//MessageBox.Show("PMT Too high", "PMT")
						Application.DoEvents();
						break; // TODO: might not be correct. Was : Exit Do
					}

					if (dblPmtv < (double)50) {
						gobjMessageAdapter.ShowMessage(constPMT2Low);
						//MessageBox.Show("PMT Too low", "PMT")
						Application.DoEvents();
						break; // TODO: might not be correct. Was : Exit Do
					}

				//mobjCommdll.subTime_Delay(2000) ''''''''''   extradelay

				} while ((1));


			} else if (((chNew - 2047.0) / 4096.0 * 10000.0) < 100.0) {
				do {
					//14.	pmt voltage = pmt voltage + 1

					dblPmtv += 1;
					//15.	set pmt voltage

					funcSet_PMT(dblPmtv);
					if (!lblStatus1 == null) {
						((Windows.Forms.Label)lblStatus1).Text = "PMT : -" + gobjInst.PmtVoltage;
					}

					//mobjCommdll.subTime_Delay(2000) '''''''''' extradelay

					//16.	Read ADC filter

					funcReadADCFilter(gobjInst.Average, chNew);

					//mobjCommdll.subTime_Delay(2000) '''''''''''' extradelay

					if (((chNew - 2047.0) / 4096.0 * 10000.0) > 100.0) {
						break; // TODO: might not be correct. Was : Exit Do
					}
					if (dblPmtv > (double)700) {
						gobjMessageAdapter.ShowMessage(constPMT2High);
						//MessageBox.Show("PMT Too high", "PMT")
						Application.DoEvents();
						break; // TODO: might not be correct. Was : Exit Do
					}

					if (dblPmtv < (double)50) {
						gobjMessageAdapter.ShowMessage(constPMT2Low);
						//MessageBox.Show("PMT Too low", "PMT")
						Application.DoEvents();
						break; // TODO: might not be correct. Was : Exit Do
					}
				} while ((1));
			}

			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
			return false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			objWait.Dispose();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcAdj_Pmt_ForValue(double dblValue, double dblMaxPmt, bool blnNewZero)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcAdj_Pmt_ForValue
		//Description            :   To adjust pmt voltage to obtain maximum energy
		//Parameters             :   dblValue : 
		//                           dblMaxPmt : max pmt to be set
		//                           blnNewZero : 
		//Return                 :   True if success
		//Time/Date              :   25/9/06
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Deepak B. on 17.11.06 major changes
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		int chNew;
		int intPmtv = 0;
		int intAvgMV;
		int intCounter = 0;
		double dblCurMode = 0.0;
		double dbltol = 0.0;
		double dblmulf = 0.0;
		int addf;
		int avgt;
		EnumCalibrationMode mode;
		int intCounterA;
		int intCounterB;
		int intCounterC;
		string strEnergy;
		string strEnergyStatus;
		frmPMT ObjFrmPmt = new frmPMT();
		string Strline1;

		try {
			mode = gobjInst.Mode;
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
				ObjFrmPmt.Text = "Setting PMT of Sample";
			}
			// Check when adj. not zero value
			if (blnNewZero == false) {
				ObjFrmPmt.Show();
				ObjFrmPmt.BringToFront();
				Application.DoEvents();

				avgt = gobjInst.Average;
				gobjInst.Average = 10;

				if (mode == EnumCalibrationMode.AA | mode == EnumCalibrationMode.AABGC) {
					dbltol = 5.0;
					dblmulf = 2.0;
				} else {
					if (dblValue == 0) {
						return false;
					}
					dbltol = 100.0;
					dblmulf = 0.6;
				}


				if (mode == EnumCalibrationMode.HCLE | mode == EnumCalibrationMode.D2E | mode == EnumCalibrationMode.EMISSION) {
					ObjFrmPmt.lblTitle.Text = "Setting FULL SCALE ";
					ObjFrmPmt.lblTitle.Refresh();
				} else {
					ObjFrmPmt.lblTitle.Text = "AUTO ZERO ";
					ObjFrmPmt.lblTitle.Refresh();
				}

				if (gobjInst.PmtVoltage > 690) {
					gobjInst.PmtVoltage = 400;
				}
				if (gobjInst.PmtVoltage < 50) {
					gobjInst.PmtVoltage = 51;
				}

				intPmtv = (int)(gobjInst.PmtVoltage * (double)4095.0) / (double)1000.0;

				do {
					intCounter = 0;
					//4.85 14.04.09
					if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
						do {
							ObjFrmPmt.lblBlink.Text = "X";
							ObjFrmPmt.lblBlink.Refresh();
							funcReadADCFilter(gobjInst.Average, chNew);
							ObjFrmPmt.lblBlink.Text = "";
							ObjFrmPmt.lblBlink.Refresh();
							intCounter += 1;
						} while ((intCounter < 5));
					} else {
						do {
							ObjFrmPmt.lblBlink.Text = "X";
							ObjFrmPmt.lblBlink.Refresh();
							funcReadADCFilter(gobjInst.Average, chNew);
							ObjFrmPmt.lblBlink.Text = "";
							ObjFrmPmt.lblBlink.Refresh();
							intCounter += 1;
						} while ((intCounter < 10));
					}


					// Read ADC value with filter 
					funcReadADCFilter(gobjInst.Average, chNew);

					dblCurMode = ((chNew - 2047.0) / 4096.0) * 10000.0;
					// Show the energy status
					if (mode == EnumCalibrationMode.HCLE | mode == EnumCalibrationMode.D2E | mode == EnumCalibrationMode.EMISSION) {
						strEnergyStatus = "PMT " + Format(gobjInst.PmtVoltage, "###") + " V, Energy : " + Format(dblCurMode, "###") + " % (" + Format(dbltol, "###.0") + "%)";
					} else {
						//sprintf(line1,"PMT -%3.0f V, Abs : %4.3f  ",Inst->Pmtv, x2/2000.0);
						strEnergyStatus = "PMT " + Format(gobjInst.PmtVoltage, "###") + " V, Abs : " + Format(dblCurMode / 2000, "####.00") + " % ";
					}

					ObjFrmPmt.lblMsg.Text = strEnergyStatus;
					ObjFrmPmt.lblMsg.Refresh();
					// Adj. the PMT intervals
					if (dblCurMode >= (dblValue + dbltol)) {
						intCounterA += 1;
						if (dblCurMode > (dblValue + dbltol * 12.0 * dblmulf)) {
							addf = 35;
						} else if (dblCurMode > (dblValue + dbltol * 5.0 * dblmulf)) {
							addf = 10;
						} else if (dblCurMode > (dblValue + dbltol * 4.0 * dblmulf)) {
							addf = 7;
						} else if (dblCurMode > (dblValue + dbltol * 3.0 * dblmulf)) {
							addf = 3;
						} else {
							addf = 1;
						}
						if (mode == EnumCalibrationMode.HCLE | mode == EnumCalibrationMode.D2E | mode == EnumCalibrationMode.EMISSION) {
							intPmtv -= addf;
						} else {
							intPmtv += addf;
						}
						// Set PMT into minor steps
						funcSet_PMT_Bit(intPmtv);
					} else if (dblCurMode <= (dblValue - dbltol)) {
						intCounterB += 1;
						if (dblCurMode < (dblValue - dbltol * 12.0 * dblmulf)) {
							addf = 80;
						} else if (dblCurMode < (dblValue - dbltol * 8.0 * dblmulf)) {
							addf = 30;
						} else if (dblCurMode < (dblValue - dbltol * 5.0 * dblmulf)) {
							addf = 25;
						} else if (dblCurMode < (dblValue - dbltol * 4.0 * dblmulf)) {
							addf = 12;
						} else if (dblCurMode < (dblValue - dbltol * 3.0 * dblmulf)) {
							addf = 5;
						} else {
							addf = 1;
						}
						if (mode == EnumCalibrationMode.HCLE | mode == EnumCalibrationMode.D2E | mode == EnumCalibrationMode.EMISSION) {
							intPmtv += addf;
						} else {
							intPmtv -= addf;
						}
						// Set PMT into minor steps
						funcSet_PMT_Bit(intPmtv);
					} else {
						if (dblCurMode == dblValue) {
							break; // TODO: might not be correct. Was : Exit Do
						} else {
							intCounterC += 1;
						}
						if (intCounterC > 2) {
							break; // TODO: might not be correct. Was : Exit Do
						}
					}

					// this block is use to be not in continues loop the process
					if (intCounterA > 10) {
						if (intCounterB > 10) {
							if (mode == EnumCalibrationMode.HCLE | mode == EnumCalibrationMode.D2E | mode == EnumCalibrationMode.EMISSION) {
								intPmtv -= addf;
							} else {
								intPmtv += addf;
							}
							funcSet_PMT_Bit(intPmtv);
							break; // TODO: might not be correct. Was : Exit Do
						} else {
							intCounterA = 0;
						}
					}

					if (ObjFrmPmt.mCancelProcess == true) {
						break; // TODO: might not be correct. Was : Exit Do
					}

					//--pmtv goes beyond maxpmt passed as second argument then give error message or warning
					if (gobjInst.PmtVoltage > dblMaxPmt) {
						gobjMessageAdapter.ShowMessage(constRequireGreaterPMT);
						Application.DoEvents();
						break; // TODO: might not be correct. Was : Exit Do
					}

					//--pmtv goes below 50 then give error message or warning
					if (gobjInst.PmtVoltage < (double)50 | gobjInst.PmtVoltage < (double)0) {
						gobjMessageAdapter.ShowMessage(constPMTLessthan50);
						Application.DoEvents();
						break; // TODO: might not be correct. Was : Exit Do
					}
					ObjFrmPmt.Refresh();
					ObjFrmPmt.BringToFront();
					Application.DoEvents();

				} while ((1));

				ObjFrmPmt.Close();
				ObjFrmPmt.Dispose();
				gobjInst.Average = avgt;

			} else {
				//+++++++++++++++++++++++++++++++++++++++++++++++++++++++
				//        BOOL		Adj_PMT_forvalue(HWND hpar, double value, double	maxpmt)
				//{
				//HWND	hwnd;
				//MSG		msg;
				//double  	x2=0.0, tol=0.0;
				//int   	ch, i;
				//int   	pmt, addf;
				//int  		a=0, b=0, c=0, avgt;
				//char 		line1[80]="";
				//char     str[40]="";
				//int		mode;

				// Inst = GetInstData();
				// mode=Inst->Mode;

				//hwnd= CreateWindowPeak(hpar, "SETTING PMT","PMTADJ", 0);
				//if (mode==AA || mode==HCLE || mode==D2E || mode==AABGC || mode==EMISSION) {//0
				//  avgt = Inst->Avg;
				//  Inst->Avg =10;
				//  if(mode==HCLE || mode == D2E|| mode == EMISSION )
				//	SetText(hwnd, IDC_STATUS," Setting FULL SCALE ");
				//            Else
				//  SetText(hwnd, IDC_STATUS," AUTO ZERO ");
				//  if (Inst->Pmtv>(double)690) Inst->Pmtv = (double)400;
				//  if (Inst->Pmtv<(double)50) Inst->Pmtv = (double)51;

				//  pmt = (int) ( (Inst->Pmtv*(double)4095.0)/(double)1000.0);
				//  do  {//1
				//	 i = 0;
				//	 do {//2
				//		SetText(hwnd, IDC_BLINK,"X");
				//		ch=ReadADCFilter();
				//		SetText(hwnd, IDC_BLINK," ");
				//		i++;
				//	  } while (i<10); //2
				//	 ch=ReadADCFilter();
				//	 x2 = GetADConvertedToCurMode(ch);

				//	 if (mode==AA || mode==AABGC ) {//3
				//		if (fabs(x2-value) <0.005){//4
				//		  Set_PMT_Bit(pmt);
				//		  break;
				//		 }//4
				//	  }//3

				//	 strcpy(line1,"");
				//	 if (value!=(double) 0.0)
				//	  tol = x2/value*100.0;
				//                                        Else
				//	  tol = (x2+1.0)/(value+1.0)*100.0;

				//	  if(mode==HCLE || mode ==D2E || mode == EMISSION)   
				//     sprintf(line1,"PMT -%3.0f V, Energy:%3.0f %% (%3.1f%%)",Inst->Pmtv,x2 ,tol);
				//		else{ //5
				//		sprintf(line1,"PMT -%3.0f V, Abs:",Inst->Pmtv);
				//		StoreAbsAccurate(x2,str);
				//		strcat(line1,str);
				//		sprintf(str," (%3.1f %%) ",tol);
				//		strcat(line1,str);
				//	 }//5

				//	 SetText(hwnd, IDC_STATUS1,line1);

				//	 if (tol>99.5 && tol<100.5)
				//		break;

				//	 else if (tol>100.0){//6
				//		a++;
				//		if (tol>=200.0) addf = 120;
				//		if (tol>150.0) addf = 60;
				//		else if (tol>120.0) addf = 20;
				//		else  if (tol>110.0) addf = 12;
				//		else if (tol>105) addf = 5;
				//		else if (tol>103) addf = 3;
				//		else	addf =1;
				//		if(mode==HCLE|| mode==D2E|| mode == EMISSION)
				//		  pmt-=addf;
				//         Else
				//		  pmt+=addf;
				//		 Set_PMT_Bit(pmt);
				//	  } //6

				//	 else if (tol<100.0) {//7
				//		b++;
				//		if (tol<30.0) addf = 100;
				//		else if (tol<50.0) addf = 60;
				//		else if (tol<65.0) addf = 30;
				//		else if (tol<80.0) addf = 20;
				//		else if (tol<90.0) addf = 12;
				//		else if (tol<95.0) addf = 5;
				//		else if (tol<97.0) addf = 3;
				//      Else
				//		  addf = 1;
				//		if(mode==HCLE|| mode==D2E|| mode == EMISSION) 
				//       pmt+=addf;
				//		else pmt-=addf;
				//		Set_PMT_Bit(pmt);
				//	  } //7

				//	 else  { //8
				//		if(tol==100.0)
				//		  break;
				//		else { //9
				//		  c++; if(c>2)
				//		  break;
				//		 } //9
				//	  } //8

				//	 if (a>5){ //10
				//		if (b>5)  { //11
				//		  if(mode==HCLE|| mode==D2E|| mode == EMISSION) pmt-=addf;
				//		  else pmt+=addf; Set_PMT_Bit(pmt);
				//		  break;
				//		 } //11
				//		else a =0;
				//	  } //10

				//	 if (CheckMsg(hwnd, &msg)) if (WP==IDCANCEL)
				//		break;

				//	 if (Inst->Pmtv > maxpmt){ //12
				//#If REMOVE_INST_MSG Then
				//		MessageBox(hwnd," Warning Requires Greater PMT Volts ", "PMT",MB_ICONASTERISK | MB_OK);
				//#Else
				//		Gerror_message_new(" Warning Requires Greater PMT Volts ", "PMT");
				//#End If
				//		break;
				//	  } //12

				//	 if (Inst->Pmtv < (double)50 || Inst->Pmtv < (double)0) { //13
				//		Gerror_message_new(" Cannot adjust PMT less than 50 Volts ", "PMT");
				//		break;
				//	  } //13
				//	} while(1); //1
				//  DestroyWindowPeak(hwnd, NULL); 
				//  Inst->Avg = avgt;
				// } //0
				//return TRUE;
				//}
				////--------------------------------------------
				//+++++++++++++++++++++++++++++++++++++++++++++++++++++++

				ObjFrmPmt.Show();
				ObjFrmPmt.BringToFront();
				Application.DoEvents();

				//1.	Perform following steps for any of these modes (HCLE/D2E/Emission/AABGC/AA).

				if (mode == EnumCalibrationMode.HCLE | mode == EnumCalibrationMode.D2E | mode == EnumCalibrationMode.EMISSION | mode == EnumCalibrationMode.AABGC | mode == EnumCalibrationMode.AA) {
					avgt = gobjInst.Average;
					//2.	Set average as 10 instead of 300 in data structure variable.
					gobjInst.Average = 10;

					if (mode == EnumCalibrationMode.HCLE | mode == EnumCalibrationMode.D2E | mode == EnumCalibrationMode.EMISSION) {
						ObjFrmPmt.lblTitle.Text = "Setting FULL SCALE ";
						ObjFrmPmt.lblTitle.Refresh();
					} else {
						//ObjFrmPmt.lblTitle.Text = "AUTO ZERO "
						if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
							if (gintInstrumentBeamType == enumInstrumentBeamType.DoubleBeam) {
								ObjFrmPmt.Text = "Setting PMT of sample beam";
								ObjFrmPmt.lblTitle.Text = "Balancing Beam";
							} else {
								ObjFrmPmt.lblTitle.Text = "AUTO ZERO ";
							}
						} else {
							ObjFrmPmt.lblTitle.Text = "AUTO ZERO ";
						}

						ObjFrmPmt.lblTitle.Refresh();
					}

					//3.	If pmt voltage is greater than 690 then set it as 400 in variable which holds pmt.
					if (gobjInst.PmtVoltage > 690) {
						gobjInst.PmtVoltage = 400;
					}

					//4.	If pmt voltage is less than 50 then set it as 51 in variable which holds pmt.
					if (gobjInst.PmtVoltage < 50) {
						gobjInst.PmtVoltage = 51;
					}

					Application.DoEvents();
					//5.	Calculate (PmtVoltage * 4095.0 / 1000.0) in a local variable.
					intPmtv = (int)gobjInst.PmtVoltage * (double)4095.0 / (double)1000.0;

					do {
						intCounter = 0;

						//4.85 14.04.09
						if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
							do {
								ObjFrmPmt.lblBlink.Text = "X";
								ObjFrmPmt.lblBlink.Refresh();
								//7.	Read ADC filter 10 times with average of 10.
								funcReadADCFilter(gobjInst.Average, chNew);
								ObjFrmPmt.lblBlink.Text = "";
								ObjFrmPmt.lblBlink.Refresh();
								intCounter += 1;
							} while ((intCounter < 5));
						} else {
							do {
								ObjFrmPmt.lblBlink.Text = "X";
								ObjFrmPmt.lblBlink.Refresh();
								//7.	Read ADC filter 10 times with average of 10.
								funcReadADCFilter(gobjInst.Average, chNew);
								ObjFrmPmt.lblBlink.Text = "";
								ObjFrmPmt.lblBlink.Refresh();
								intCounter += 1;
							} while ((intCounter < 10));
						}

						//8.	Read ADC filter once more.
						funcReadADCFilter(gobjInst.Average, chNew);
						//9.	Convert ADC filter reading to calibration mode value.
						dblCurMode = gFuncGetADConvertedToCurMode(chNew);

						//10.If mode is AA or AABGC and (Output of step no. 9 
						//� MinVal) is less than 0.005 then set pmt as output of step no. 5.

						if (mode == EnumCalibrationMode.AA | mode == EnumCalibrationMode.AABGC) {
							if (Math.Abs(dblCurMode - dblValue) < 0.005) {
								funcSet_PMT_Bit(intPmtv);
								break; // TODO: might not be correct. Was : Exit Do
							}
						}

						//12.	Calculate percent pmt by using formula Output Of 
						//step number 9 / MinVal * 100.0

						Strline1 = "";
						if (dblValue != (double)0.0) {
							dbltol = dblCurMode / dblValue * 100.0;
						} else {
							dbltol = (dblCurMode + 1.0) / (dblValue + 1.0) * 100.0;
						}

						if (mode == EnumCalibrationMode.HCLE | mode == EnumCalibrationMode.D2E | mode == EnumCalibrationMode.EMISSION) {
							Strline1 = "PMT " + Format(gobjInst.PmtVoltage, "###") + " V, Energy : " + Format(dblCurMode, "0.00") + " % (" + Format(dbltol, "0.0#") + " %)";
						} else {
							Strline1 = "PMT " + Format(gobjInst.PmtVoltage, "###") + " V, Abs : " + Format(dblCurMode, "0.000") + " (" + Format(dbltol, "0.00") + ")";
						}

						ObjFrmPmt.lblMsg.Text = Strline1;
						ObjFrmPmt.lblMsg.Refresh();

						//13.if output of step 12 > 99.5 and it is < 100.5
						//then Come out of the loop which has stated from step number 6 else continue with following.

						if (dbltol > 99.5 & dbltol < 100.5) {
							break; // TODO: might not be correct. Was : Exit Do

						//14.if output of step 12 > 100 then
						//if output of step 12 >= 200 then AddAmount=120
						//if output of step 12 > 150 then AddAmount=60
						//if output of step 12 > 120 then AddAmount=20
						//if output of step 12 > 110 then AddAmount=12
						//if output of step 12 > 105 then AddAmount=5
						//if output of step 12 > 103 then AddAmount=3 else AddAmount=1

						} else if (dbltol > 100.0) {
							intCounterA += 1;
							if (dbltol >= 200.0) {
								addf = 120;
							}
							if (dbltol > 150.0) {
								addf = 60;
							} else if (dbltol > 120.0) {
								addf = 20;
							} else if (dbltol > 110.0) {
								addf = 12;
							} else if (dbltol > 105) {
								addf = 5;
							} else if (dbltol > 103) {
								addf = 3;
							} else {
								addf = 1;
							}

							//15.if mode is HCLE or D2E or Emission then
							//Output of step 15 = Output of step 5 � AddAmount
							//Else
							//Output of step 15 = Output of step 5 + AddAmount

							if (mode == EnumCalibrationMode.HCLE | mode == EnumCalibrationMode.D2E | mode == EnumCalibrationMode.EMISSION) {
								intPmtv -= addf;
							} else {
								intPmtv += addf;
							}
							//16.	Set pmt as Output of step 15.
							funcSet_PMT_Bit(intPmtv);

						//17.if output of step 12 < 100 then
						//if output of step 12 < 30 then AddAmount=100
						//if output of step 12 < 50 then AddAmount=60
						//if output of step 12 < 65 then AddAmount=30
						//if output of step 12 < 80 then AddAmount=20
						//if output of step 12 < 90 then AddAmount=12
						//if output of step 12 < 95 then AddAmount=5 
						//if output of step 12 < 97 then AddAmount=3 else AddAmount=1

						} else if (dbltol < 100.0) {
							intCounterB += 1;
							if (dbltol < 30.0) {
								addf = 100;
							} else if (dbltol < 50.0) {
								addf = 60;
							} else if (dbltol < 65.0) {
								addf = 30;
							} else if (dbltol < 80.0) {
								addf = 20;
							} else if (dbltol < 90.0) {
								addf = 12;
							} else if (dbltol < 95.0) {
								addf = 5;
							} else if (dbltol < 97.0) {
								addf = 3;
							} else {
								addf = 1;
							}

							//18.if mode is HCLE or D2E or Emission then
							//Output of step 18 = Output of step 5 + AddAmount
							//                        Else
							//Output of step 18 = Output of step 5 - AddAmount

							if (mode == EnumCalibrationMode.HCLE | mode == EnumCalibrationMode.D2E | mode == EnumCalibrationMode.EMISSION) {
								intPmtv += addf;
							} else {
								intPmtv -= addf;
							}
							//19.	Set pmt as Output of step 18.
							funcSet_PMT_Bit(intPmtv);


						} else {
							//20.if output of step 12 = 100 then come out of loop 
							//which has started from step 6 else if occurrence of this step is more than 2 then exit out of loop.

							if (dbltol == 100.0) {
								break; // TODO: might not be correct. Was : Exit Do
							} else {
								intCounterC += 1;
								if ((intCounterC > 2)) {
									break; // TODO: might not be correct. Was : Exit Do
								}
							}
						}

						//21.if occurrence of step 14 and step 17 is more than 
						//5 then execute step number 15 and 16 and come out of the loop.

						if (intCounterA > 5) {
							if (intCounterB > 5) {
								if (mode == EnumCalibrationMode.HCLE | mode == EnumCalibrationMode.D2E | mode == EnumCalibrationMode.EMISSION) {
									intPmtv -= addf;
								} else {
									intPmtv += addf;
								}
								funcSet_PMT_Bit(intPmtv);
								break; // TODO: might not be correct. Was : Exit Do
							} else {
								intCounterA = 0;
							}
						}
						// User wants to terminate the job 
						if (ObjFrmPmt.mCancelProcess == true) {
							break; // TODO: might not be correct. Was : Exit Do
						}

						//22.If pmt is greater than MaxVal then come out of 
						//the loop.

						if (gobjInst.PmtVoltage > dblMaxPmt) {
							gobjMessageAdapter.ShowMessage(constRequireGreaterPMT);
							Application.DoEvents();

							if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
								funcSet_PMT(0);
								funcSet_PMTReferenceBeam(0);
							//---02.06.09 to set pmt to zero
							} else if (gstructSettings.AppMode == EnumAppMode.FullVersion_203 | gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
								funcSet_PMT(0);
							}
							//-------
							break; // TODO: might not be correct. Was : Exit Do
						}

						//23.	If pmt is less than 50 or less than 0 then come 
						//out of the loop.

						if (gobjInst.PmtVoltage < (double)50 | gobjInst.PmtVoltage < (double)0) {
							gobjMessageAdapter.ShowMessage(constPMTLessthan50);
							Application.DoEvents();
							break; // TODO: might not be correct. Was : Exit Do
						}

						ObjFrmPmt.Refresh();
						ObjFrmPmt.BringToFront();
						Application.DoEvents();
					//24.	End of loop.
					} while ((1));

					ObjFrmPmt.Close();
					ObjFrmPmt.Dispose();
					gobjInst.Average = avgt;

				}
			}

			Application.DoEvents();

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
			objWait.Dispose();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcAdj_Pmt_ForValue_Ref(double dblValue, double dblMaxPmt, bool blnNewZero)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcAdj_Pmt_ForValue_Ref
		//Description            :   To adjust pmt voltage to obtain maximum energy
		//Parameters             :   dblValue : 
		//                           dblMaxPmt : max pmt to be set
		//                           blnNewZero : 
		//Return                 :   True if success
		//Time/Date              :   25/9/06
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Deepak B. on 17.11.06 major changes
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		int chNew;
		int intPmtv = 0;
		int intAvgMV;
		int intCounter = 0;
		double dblCurMode = 0.0;
		double dbltol = 0.0;
		double dblmulf = 0.0;
		int addf;
		int avgt;
		EnumCalibrationMode mode;
		int intCounterA;
		int intCounterB;
		int intCounterC;
		string strEnergy;
		string strEnergyStatus;
		frmPMT ObjFrmPmt = new frmPMT();
		string Strline1;

		try {
			//---temporarily it is set here later it should be set from somewhere else
			//gobjInst.Mode = modGlobalConstants.EnumCalibrationMode.HCLE
			//---------------
			mode = gobjInst.Mode;

			if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
				ObjFrmPmt.Text = "Setting PMT of Ref. beam";
			}
			// Check when adj. not zero value

			if (blnNewZero == false) {
				ObjFrmPmt.Show();
				ObjFrmPmt.BringToFront();
				Application.DoEvents();

				avgt = gobjInst.Average;
				gobjInst.Average = 10;

				if (mode == EnumCalibrationMode.AA | mode == EnumCalibrationMode.AABGC) {
					dbltol = 5.0;
					dblmulf = 2.0;
				} else {
					if (dblValue == 0) {
						return false;
					}
					dbltol = 100.0;
					dblmulf = 0.6;
				}
				if (mode == EnumCalibrationMode.HCLE | mode == EnumCalibrationMode.D2E | mode == EnumCalibrationMode.EMISSION) {
					ObjFrmPmt.lblTitle.Text = "Setting FULL SCALE ";
					ObjFrmPmt.lblTitle.Refresh();
				} else {
					////----------
					if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
						if (gintInstrumentBeamType == enumInstrumentBeamType.DoubleBeam) {
							ObjFrmPmt.Text = "Setting PMT of Reference beam";
							ObjFrmPmt.lblTitle.Text = "Balancing Beam";
						} else {
							ObjFrmPmt.lblTitle.Text = "AUTO ZERO ";
						}
					} else {
						ObjFrmPmt.lblTitle.Text = "AUTO ZERO ";

					}
					ObjFrmPmt.lblTitle.Refresh();
					////----------
				}

				if (gobjInst.PmtVoltageReference > 690) {
					gobjInst.PmtVoltageReference = 400;
				}
				if (gobjInst.PmtVoltageReference < 50) {
					gobjInst.PmtVoltageReference = 51;
				}

				intPmtv = (int)(gobjInst.PmtVoltageReference * (double)4095.0) / (double)1000.0;

				do {
					intCounter = 0;
					do {
						ObjFrmPmt.lblBlink.Text = "X";
						ObjFrmPmt.lblBlink.Refresh();
						funcReadADCFilter_ReferenceBeam(gobjInst.Average, chNew);
						ObjFrmPmt.lblBlink.Text = "";
						ObjFrmPmt.lblBlink.Refresh();
						intCounter += 1;
					} while ((intCounter < 10));
					// Read ADC value with filter and Cal. Energy
					funcReadADCFilter_ReferenceBeam(gobjInst.Average, chNew);
					dblCurMode = ((chNew - 2047.0) / 4096.0) * 10000.0;

					// Show the energy status
					if (mode == EnumCalibrationMode.HCLE | mode == EnumCalibrationMode.D2E | mode == EnumCalibrationMode.EMISSION) {
						strEnergyStatus = "PMT " + Format(gobjInst.PmtVoltageReference, "###") + " V, Energy : " + Format(dblCurMode, "###") + " % (" + Format(dbltol, "##0.0") + "%)";
					} else {
						//sprintf(line1,"PMT -%3.0f V, Abs : %4.3f  ",Inst->Pmtv, x2/2000.0);
						strEnergyStatus = "PMT " + Format(gobjInst.PmtVoltageReference, "###") + " V, Abs : " + Format(dblCurMode / 2000, "###0.00") + " % ";
					}

					ObjFrmPmt.lblMsg.Text = strEnergyStatus;
					ObjFrmPmt.lblMsg.Refresh();
					// Adj. the PMT interval
					if (dblCurMode >= (dblValue + dbltol)) {
						intCounterA += 1;
						if (dblCurMode > (dblValue + dbltol * 12.0 * dblmulf)) {
							addf = 35;
						} else if (dblCurMode > (dblValue + dbltol * 5.0 * dblmulf)) {
							addf = 10;
						} else if (dblCurMode > (dblValue + dbltol * 4.0 * dblmulf)) {
							addf = 7;
						} else if (dblCurMode > (dblValue + dbltol * 3.0 * dblmulf)) {
							addf = 3;
						} else {
							addf = 1;
						}
						if (mode == EnumCalibrationMode.HCLE | mode == EnumCalibrationMode.D2E | mode == EnumCalibrationMode.EMISSION) {
							intPmtv -= addf;
						} else {
							intPmtv += addf;
						}
						// Set PMT into minor steps
						funcSet_PMT_Ref_Bit(intPmtv);
					} else if (dblCurMode <= (dblValue - dbltol)) {
						intCounterB += 1;
						if (dblCurMode < (dblValue - dbltol * 12.0 * dblmulf)) {
							addf = 80;
						} else if (dblCurMode < (dblValue - dbltol * 8.0 * dblmulf)) {
							addf = 30;
						} else if (dblCurMode < (dblValue - dbltol * 5.0 * dblmulf)) {
							addf = 25;
						} else if (dblCurMode < (dblValue - dbltol * 4.0 * dblmulf)) {
							addf = 12;
						} else if (dblCurMode < (dblValue - dbltol * 3.0 * dblmulf)) {
							addf = 5;
						} else {
							addf = 1;
						}
						if (mode == EnumCalibrationMode.HCLE | mode == EnumCalibrationMode.D2E | mode == EnumCalibrationMode.EMISSION) {
							intPmtv += addf;
						} else {
							intPmtv -= addf;
						}
						// Set PMT into minor steps
						funcSet_PMT_Ref_Bit(intPmtv);
					} else {
						if (dblCurMode == dblValue) {
							break; // TODO: might not be correct. Was : Exit Do
						} else {
							intCounterC += 1;
						}
						if (intCounterC > 2) {
							break; // TODO: might not be correct. Was : Exit Do
						}
					}
					// this block is use to validate contineous loop process
					if (intCounterA > 10) {
						if (intCounterB > 10) {
							if (mode == EnumCalibrationMode.HCLE | mode == EnumCalibrationMode.D2E | mode == EnumCalibrationMode.EMISSION) {
								intPmtv -= addf;
							} else {
								intPmtv += addf;
							}
							funcSet_PMT_Ref_Bit(intPmtv);
							break; // TODO: might not be correct. Was : Exit Do
						} else {
							intCounterA = 0;
						}
					}

					// User wants to terminate the job 
					if (ObjFrmPmt.mCancelProcess == true) {
						break; // TODO: might not be correct. Was : Exit Do
					}

					//--pmtv goes beyond maxpmt passed as second argument then give error message or warning
					if (gobjInst.PmtVoltageReference > dblMaxPmt) {
						gobjMessageAdapter.ShowMessage(constRequireGreaterPMT);
						Application.DoEvents();
						break; // TODO: might not be correct. Was : Exit Do
					}

					//--pmtv goes below 50 then give error message or warning
					if (gobjInst.PmtVoltageReference < (double)50 | gobjInst.PmtVoltageReference < (double)0) {
						gobjMessageAdapter.ShowMessage(constPMTLessthan50);
						Application.DoEvents();
						break; // TODO: might not be correct. Was : Exit Do
					}
					ObjFrmPmt.Refresh();
					ObjFrmPmt.BringToFront();
					Application.DoEvents();
				} while ((1));
				ObjFrmPmt.Close();
				ObjFrmPmt.Dispose();
				gobjInst.Average = avgt;
			} else {
				//+++++++++++++++++++++++++++++++++++++++++++++++++++++++
				//        BOOL		Adj_PMT_forvalue(HWND hpar, double value, double	maxpmt)
				//{
				//HWND	hwnd;
				//MSG		msg;
				//double  	x2=0.0, tol=0.0;
				//int   	ch, i;
				//int   	pmt, addf;
				//int  		a=0, b=0, c=0, avgt;
				//char 		line1[80]="";
				//char     str[40]="";
				//int		mode;

				// Inst = GetInstData();
				// mode=Inst->Mode;

				//hwnd= CreateWindowPeak(hpar, "SETTING PMT","PMTADJ", 0);
				//if (mode==AA || mode==HCLE || mode==D2E || mode==AABGC || mode==EMISSION) {//0
				//  avgt = Inst->Avg;
				//  Inst->Avg =10;
				//  if(mode==HCLE || mode == D2E|| mode == EMISSION )
				//	SetText(hwnd, IDC_STATUS," Setting FULL SCALE ");
				//            Else
				//  SetText(hwnd, IDC_STATUS," AUTO ZERO ");
				//  if (Inst->Pmtv>(double)690) Inst->Pmtv = (double)400;
				//  if (Inst->Pmtv<(double)50) Inst->Pmtv = (double)51;

				//  pmt = (int) ( (Inst->Pmtv*(double)4095.0)/(double)1000.0);
				//  do  {//1
				//	 i = 0;
				//	 do {//2
				//		SetText(hwnd, IDC_BLINK,"X");
				//		ch=ReadADCFilter();
				//		SetText(hwnd, IDC_BLINK," ");
				//		i++;
				//	  } while (i<10); //2
				//	 ch=ReadADCFilter();
				//	 x2 = GetADConvertedToCurMode(ch);

				//	 if (mode==AA || mode==AABGC ) {//3
				//		if (fabs(x2-value) <0.005){//4
				//		  Set_PMT_Bit(pmt);
				//		  break;
				//		 }//4
				//	  }//3

				//	 strcpy(line1,"");
				//	 if (value!=(double) 0.0)
				//	  tol = x2/value*100.0;
				//                                        Else
				//	  tol = (x2+1.0)/(value+1.0)*100.0;

				//	  if(mode==HCLE || mode ==D2E || mode == EMISSION)   
				//     sprintf(line1,"PMT -%3.0f V, Energy:%3.0f %% (%3.1f%%)",Inst->Pmtv,x2 ,tol);
				//		else{ //5
				//		sprintf(line1,"PMT -%3.0f V, Abs:",Inst->Pmtv);
				//		StoreAbsAccurate(x2,str);
				//		strcat(line1,str);
				//		sprintf(str," (%3.1f %%) ",tol);
				//		strcat(line1,str);
				//	 }//5

				//	 SetText(hwnd, IDC_STATUS1,line1);

				//	 if (tol>99.5 && tol<100.5)
				//		break;

				//	 else if (tol>100.0){//6
				//		a++;
				//		if (tol>=200.0) addf = 120;
				//		if (tol>150.0) addf = 60;
				//		else if (tol>120.0) addf = 20;
				//		else  if (tol>110.0) addf = 12;
				//		else if (tol>105) addf = 5;
				//		else if (tol>103) addf = 3;
				//		else	addf =1;
				//		if(mode==HCLE|| mode==D2E|| mode == EMISSION)
				//		  pmt-=addf;
				//         Else
				//		  pmt+=addf;
				//		 Set_PMT_Bit(pmt);
				//	  } //6

				//	 else if (tol<100.0) {//7
				//		b++;
				//		if (tol<30.0) addf = 100;
				//		else if (tol<50.0) addf = 60;
				//		else if (tol<65.0) addf = 30;
				//		else if (tol<80.0) addf = 20;
				//		else if (tol<90.0) addf = 12;
				//		else if (tol<95.0) addf = 5;
				//		else if (tol<97.0) addf = 3;
				//      Else
				//		  addf = 1;
				//		if(mode==HCLE|| mode==D2E|| mode == EMISSION) 
				//       pmt+=addf;
				//		else pmt-=addf;
				//		Set_PMT_Bit(pmt);
				//	  } //7

				//	 else  { //8
				//		if(tol==100.0)
				//		  break;
				//		else { //9
				//		  c++; if(c>2)
				//		  break;
				//		 } //9
				//	  } //8

				//	 if (a>5){ //10
				//		if (b>5)  { //11
				//		  if(mode==HCLE|| mode==D2E|| mode == EMISSION) pmt-=addf;
				//		  else pmt+=addf; Set_PMT_Bit(pmt);
				//		  break;
				//		 } //11
				//		else a =0;
				//	  } //10

				//	 if (CheckMsg(hwnd, &msg)) if (WP==IDCANCEL)
				//		break;

				//	 if (Inst->Pmtv > maxpmt){ //12
				//#If REMOVE_INST_MSG Then
				//		MessageBox(hwnd," Warning Requires Greater PMT Volts ", "PMT",MB_ICONASTERISK | MB_OK);
				//#Else
				//		Gerror_message_new(" Warning Requires Greater PMT Volts ", "PMT");
				//#End If
				//		break;
				//	  } //12

				//	 if (Inst->Pmtv < (double)50 || Inst->Pmtv < (double)0) { //13
				//		Gerror_message_new(" Cannot adjust PMT less than 50 Volts ", "PMT");
				//		break;
				//	  } //13
				//	} while(1); //1
				//  DestroyWindowPeak(hwnd, NULL); 
				//  Inst->Avg = avgt;
				// } //0
				//return TRUE;
				//}
				////--------------------------------------------
				//+++++++++++++++++++++++++++++++++++++++++++++++++++++++
				// Check when adj. zero value
				ObjFrmPmt.Show();
				ObjFrmPmt.BringToFront();
				Application.DoEvents();

				if (mode == EnumCalibrationMode.HCLE | mode == EnumCalibrationMode.D2E | mode == EnumCalibrationMode.EMISSION | mode == EnumCalibrationMode.AABGC | mode == EnumCalibrationMode.AA) {
					avgt = gobjInst.Average;
					gobjInst.Average = 10;

					if (mode == EnumCalibrationMode.HCLE | mode == EnumCalibrationMode.D2E | mode == EnumCalibrationMode.EMISSION) {
						ObjFrmPmt.lblTitle.Text = "Setting FULL SCALE ";
						ObjFrmPmt.lblTitle.Refresh();
					} else {
						if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
							if (gintInstrumentBeamType == enumInstrumentBeamType.DoubleBeam) {
								ObjFrmPmt.lblTitle.Text = "Balancing Beam";
							} else {
								ObjFrmPmt.lblTitle.Text = "AUTO ZERO ";
							}
						} else {
							ObjFrmPmt.lblTitle.Text = "AUTO ZERO ";
						}
						ObjFrmPmt.lblTitle.Refresh();
					}

					if (gobjInst.PmtVoltageReference > 690) {
						gobjInst.PmtVoltageReference = 400;
					}

					if (gobjInst.PmtVoltageReference < 50) {
						gobjInst.PmtVoltageReference = 51;
					}
					Application.DoEvents();
					intPmtv = (int)gobjInst.PmtVoltageReference * (double)4095.0 / (double)1000.0;

					do {
						intCounter = 0;
						do {
							ObjFrmPmt.lblBlink.Text = "X";
							ObjFrmPmt.lblBlink.Refresh();
							funcReadADCFilter_ReferenceBeam(gobjInst.Average, chNew);
							ObjFrmPmt.lblBlink.Text = "";
							ObjFrmPmt.lblBlink.Refresh();
							intCounter += 1;
						} while ((intCounter < 10));

						// Read ADC value with filter for Ref. beam
						funcReadADCFilter_ReferenceBeam(gobjInst.Average, chNew);
						dblCurMode = gFuncGetADConvertedToCurMode(chNew);


						if (mode == EnumCalibrationMode.AA | mode == EnumCalibrationMode.AABGC) {
							// validate the current value is nearer to given Value and exit from loop. 
							if (Math.Abs(dblCurMode - dblValue) < 0.005) {
								// Set PMT into minor steps
								funcSet_PMT_Ref_Bit(intPmtv);
								break; // TODO: might not be correct. Was : Exit Do
							}
						}

						Strline1 = "";
						if (dblValue != (double)0.0) {
							dbltol = dblCurMode / dblValue * 100.0;
						} else {
							dbltol = (dblCurMode + 1.0) / (dblValue + 1.0) * 100.0;
						}

						// Show the Abs. status
						if (mode == EnumCalibrationMode.HCLE | mode == EnumCalibrationMode.D2E | mode == EnumCalibrationMode.EMISSION) {
							Strline1 = "PMT " + Format(gobjInst.PmtVoltageReference, "###") + " V, Energy : " + Format(dblCurMode, "###0.00") + " % (" + Format(dbltol, "0.0#") + " %)";
						} else {
							Strline1 = "PMT " + Format(gobjInst.PmtVoltageReference, "###") + " V, Abs : " + Format(dblCurMode, "0.000") + " (" + Format(dbltol, "###0.00") + ")";
						}

						ObjFrmPmt.lblMsg.Text = Strline1;
						ObjFrmPmt.lblMsg.Refresh();

						// Adj. the PMT interval
						if (dbltol > 99.5 & dbltol < 100.5) {
							break; // TODO: might not be correct. Was : Exit Do
						} else if (dbltol > 100.0) {
							intCounterA += 1;
							if (dbltol >= 200.0) {
								addf = 120;
							}
							if (dbltol > 150.0) {
								addf = 60;
							} else if (dbltol > 120.0) {
								addf = 20;
							} else if (dbltol > 110.0) {
								addf = 12;
							} else if (dbltol > 105) {
								addf = 5;
							} else if (dbltol > 103) {
								addf = 3;
							} else {
								addf = 1;
							}
							if (mode == EnumCalibrationMode.HCLE | mode == EnumCalibrationMode.D2E | mode == EnumCalibrationMode.EMISSION) {
								intPmtv -= addf;
							} else {
								intPmtv += addf;
							}
							// Set PMT into minor steps
							funcSet_PMT_Ref_Bit(intPmtv);

						} else if (dbltol < 100.0) {
							intCounterB += 1;
							if (dbltol < 30.0) {
								addf = 100;
							} else if (dbltol < 50.0) {
								addf = 60;
							} else if (dbltol < 65.0) {
								addf = 30;
							} else if (dbltol < 80.0) {
								addf = 20;
							} else if (dbltol < 90.0) {
								addf = 12;
							} else if (dbltol < 95.0) {
								addf = 5;
							} else if (dbltol < 97.0) {
								addf = 3;
							} else {
								addf = 1;
							}
							if (mode == EnumCalibrationMode.HCLE | mode == EnumCalibrationMode.D2E | mode == EnumCalibrationMode.EMISSION) {
								intPmtv += addf;
							} else {
								intPmtv -= addf;
							}
							// Set PMT into minor steps
							funcSet_PMT_Ref_Bit(intPmtv);

						} else {
							if (dbltol == 100.0) {
								break; // TODO: might not be correct. Was : Exit Do
							} else {
								intCounterC += 1;
								if ((intCounterC > 2)) {
									break; // TODO: might not be correct. Was : Exit Do
								}
							}
						}
						// this block is use to validate contineous loop process
						if (intCounterA > 5) {
							if (intCounterB > 5) {
								if (mode == EnumCalibrationMode.HCLE | mode == EnumCalibrationMode.D2E | mode == EnumCalibrationMode.EMISSION) {
									intPmtv -= addf;
								} else {
									intPmtv += addf;
								}
								funcSet_PMT_Ref_Bit(intPmtv);
								break; // TODO: might not be correct. Was : Exit Do
							} else {
								intCounterA = 0;
							}
						}

						// User wants to terminate the job 
						if (ObjFrmPmt.mCancelProcess == true) {
							break; // TODO: might not be correct. Was : Exit Do
						}

						// pmtv goes beyond maxpmt passed as second argument then give error message or warning
						if (gobjInst.PmtVoltageReference > dblMaxPmt) {
							gobjMessageAdapter.ShowMessage(constRequireGreaterPMT);

							Application.DoEvents();

							break; // TODO: might not be correct. Was : Exit Do
						}

						// pmtv goes below 50 then give error message or warning
						if (gobjInst.PmtVoltageReference < (double)50 | gobjInst.PmtVoltageReference < (double)0) {
							gobjMessageAdapter.ShowMessage(constPMTLessthan50);
							Application.DoEvents();
							break; // TODO: might not be correct. Was : Exit Do
						}
						ObjFrmPmt.Refresh();
						ObjFrmPmt.BringToFront();
						Application.DoEvents();
					} while ((1));
					ObjFrmPmt.Close();
					ObjFrmPmt.Dispose();
					gobjInst.Average = avgt;
				}
			}
			Application.DoEvents();
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
			objWait.Dispose();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcTestLampPresence(ref object lblStatus1 = null, ref object lblStatus2 = null, ref object lblStatus3 = null)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcTestLampPresence
		//Description            :   To test if lamp is present at turret position
		//Affected parameter     :   lblStatus1,lblStatus2,lblStatus3
		//Return                 :   True if success
		//Time/Date              :   3/10/06
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Deepak B. on 17.11.06 Almost entire function is changed
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		int intAvgInMV;
		int intCounter;
		bool blnFlag = false;
		//----------------------------------------------
		//        BOOL	Test_Lamp_Presence(HWND hwnd)
		//{
		//int  	ch1;
		//BOOL	flag = FALSE;
		//	Slit_Home();
		//	Cal_Mode(HCLE);
		//	Set_PMT((double)200.0);
		//	ch1 = 0;
		//	SetText(hwnd, IDC_STATUS1,"PMT -200 V");
		//	do{
		//	  SetText(hwnd, IDC_STATUS1,"Testing for Lamp Presence ... : X  ");
		//	  ReadADCFilter();
		//	  SetText(hwnd, IDC_STATUS1,"Testing for Lamp Presence ... :     ");
		//	  ch1++; if (ch1>10) break;
		//	} while(1);
		//	pc_delay(2000);
		//	if( GetInstrument() == AA202 ){
		//		if (ReadADCFilter()> 2090){
		//		  flag =TRUE;
		//		  SetText(hwnd, IDC_STATUS1,"Testing for Lamp Presence ... : OK  ");
		//		 }
		//		else {
		//		  flag =FALSE;
		//		  SetText(hwnd, IDC_STATUS1,"Testing for Lamp Presence ... : ERROR");
		//		 }
		//	}
		//	else{
		//		if (GetmV(ReadADCFilter())> 1900.0) { //2846){
		//		  flag =TRUE;
		//		  SetText(hwnd, IDC_STATUS1,"Testing for Lamp Presence ... : OK  ");
		//		 }
		//		else {
		//		  flag =FALSE;
		//		  SetText(hwnd, IDC_STATUS1,"Testing for Lamp Presence ... : ERROR");
		//		 }
		//	}
		//	Set_SlitWidth(0.3);
		//	pc_delay(2000);
		//	if (!flag){
		//		Inst = GetInstData();
		//		Inst->Lamp_par.lamp[Inst->Lamp_pos-1].lamp_optpos = -1;
		//#If REMOVE_INST_MSG Then
		//		MessageBox(hwnd,"Lamp not connected ....", "Lamp Test",MB_ICONASTERISK | MB_OK);
		//#Else
		//		Gerror_message_new("Lamp not connected ....", "Lamp Test");
		//#End If
		//		pc_delay(3000);
		//	 }
		// return flag;
		//}
		//----------------------------------------------
		try {
			//1.	Set Slit to Home Position.
			if (gFuncSlit_Home() == false) {
				gobjMessageAdapter.ShowMessage(constErrorSlitHome);
				Application.DoEvents();
			}

			//*******************************************************
			//----Added by Mangesh on 13-Apr-2007
			//*******************************************************
			//2.	If instrument type is 203D then Set Exit slit to Home position.
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
				if (funcExitSlit_Home() == false) {
					gobjMessageAdapter.ShowMessage(constExitSlitHome);
					Application.DoEvents();
				}
			}
			//*******************************************************

			//3.	Set HCLE calibration Mode.
			if (funcCalibrationMode(EnumCalibrationMode.HCLE) == false) {
				gobjMessageAdapter.ShowMessage(constCalibrationMode);
				Application.DoEvents();
			}

			//4.	Set pmt as 200.0 volt.
			if (funcSet_PMT(200.0) == false) {
				gobjMessageAdapter.ShowMessage(constPMTVolt);
				Application.DoEvents();
			}

			if (!lblStatus1 == null) {
				((Windows.Forms.Label)lblStatus1).Text = "PMT : -200 V";
			}

			//5.	Read ADC Filter reading for 11 times.
			intCounter = 0;
			do {
				if (!lblStatus2 == null) {
					((Windows.Forms.Label)lblStatus2).Text = "Testing for Lamp Presence ... : X  ";
				}

				funcReadADCFilter(gobjInst.Average, intAvgInMV);

				if (!lblStatus2 == null) {
					((Windows.Forms.Label)lblStatus2).Text = "Testing for Lamp Presence ... :    ";
				}

				intCounter += 1;
				if (intCounter > 10) {
					break; // TODO: might not be correct. Was : Exit Do
				}
			} while ((1));

			mobjCommdll.subTime_Delay(10);
			//6.	Read ADC Filter reading once more.
			funcReadADCFilter(gobjInst.Average, intAvgInMV);
			//if( GetInstrument() == AA202 ){
			//		if (ReadADCFilter()> 2090){
			//		  flag =TRUE;
			//		  SetText(hwnd, IDC_STATUS1,"Testing for Lamp Presence ... : OK  ");
			//		 }
			//		else {
			//		  flag =FALSE;
			//		  SetText(hwnd, IDC_STATUS1,"Testing for Lamp Presence ... : ERROR");
			//		 }
			//	}

			//7.	If instrument type is 201 and ADC filter reading is more than 2090 then declare 
			//lamp presence OK. If ADC filter reading is less than 2090 then Declare lamp presence Error.

			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				if (intAvgInMV > 2090) {
					blnFlag = true;
					if (!lblStatus2 == null) {
						((Windows.Forms.Label)lblStatus2).Text = "Testing for Lamp Presence ... : OK  ";
					}
				} else {
					blnFlag = false;
					if (!lblStatus2 == null) {
						((Windows.Forms.Label)lblStatus2).Text = "Testing for Lamp Presence ... : ERROR";
					}
				}
			} else {
				//8.	If instrument type is 203/203D then convert ADC filter reading to 
				//millivolt. If ADC filter reading converted to millivolt is more than 1900 then 
				//Declare lamp presence OK. If ADC filter reading converted to millivolt is less 
				//than 1900 then Declare lamp presence Error.
				if (gFuncGetmv(intAvgInMV) > 1900.0) {
					blnFlag = true;
					if (!lblStatus2 == null) {
						((Windows.Forms.Label)lblStatus2).Text = "Testing for Lamp Presence ... : OK  ";
					}
				} else {
					blnFlag = false;
					if (!lblStatus2 == null) {
						((Windows.Forms.Label)lblStatus2).Text = "Testing for Lamp Presence ... : ERROR";
					}
				}
			}

			//*******************************************************
			//----Added by Mangesh on 13-Apr-2007
			//*******************************************************

			//9.	If instrument type is 203D then position both slits to 0.5 nm. 
			//Else position entry slit to 0.3.

			if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
				//If funcSet_SlitWidth(0.5, enumInstrumentBeamType.DoubleBeam) = False Then
				if (funcSet_SlitWidth(0.5, 2) == false) {
					gobjMessageAdapter.ShowMessage(constSlitWidthError);
					Application.DoEvents();
				}
			} else {
				if (funcSet_SlitWidth(0.3) == false) {
					gobjMessageAdapter.ShowMessage(constSlitWidthError);
					Application.DoEvents();
				}
			}

			//mobjCommdll.subTime_Delay(2000)

			if (blnFlag == false) {
				gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).LampOptimizePosition = -1;
				//MessageBox.Show("Lamp not connected ....", "Lamp Test")
				gobjMessageAdapter.ShowMessage(constLampNotConnected);
				Application.DoEvents();
				//mobjCommdll.subTime_Delay(3000)
			}

			return blnFlag;

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
			objWait.Dispose();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcSet_Lamp(bool blnFlag, double dblLampCurrent, int intLampPos)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcSet_Lamp
		//Description            :   To set current to the lamp
		//Parameters             :   flag = if true set current else not set current
		//                           dblLampCurrent = current to be set to lamp
		//                           intLampPos = lamp position to which current to be set
		//Return                 :   True if success
		//Time/Date              :   29/9/06
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();


		try {
			// init Set all lamp current is off
			if (funcAll_Lamp_Off()) {
				if (blnFlag == true) {
					//--take lamp current from inst parameters and set it
					if (funcSet_HCL_Cur(dblLampCurrent, intLampPos)) {
						funcSet_Lamp = true;
					} else {
						funcSet_Lamp = false;
					}
				} else {
					funcSet_Lamp = true;
				}

			} else {
				funcSet_Lamp = false;
			}


		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
			return false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			objWait.Dispose();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcSet_Lamp(bool blnFlag)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcSet_Lamp
		//Description            :   To set current to the lamp
		//Parameters             :   flag = if true set current else not set current
		//Return                 :   True if success
		//Time/Date              :   29/9/06
		//Dependencies           :   
		//Author                 :   Sachin Dokhale
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		//           E4FUNC  void	S4FUNC 	Set_lamp(BOOL flag)
		//{
		//double lmp_cur=0.0;
		// CheckInst();
		// All_Lamp_Off();
		// if (flag){
		//	lmp_cur = Inst->Lamp_par.lamp[Inst->Lamp_pos-1].cur;
		//	Set_HCL_Cur(lmp_cur,Inst->Lamp_pos);
		//	if (Inst->Lamp_warm>0) {
		//	  lmp_cur = Inst->Lamp_par.lamp[Inst->Lamp_warm-1].cur;
		//	  Set_HCL_Cur(lmp_cur,Inst->Lamp_warm);
		//	 }
		//  }

		//}
		CWaitCursor objWait = new CWaitCursor();
		double dbllmp_cur = 0.0;

		try {
			// init Set all lamp current is off
			if (funcAll_Lamp_Off()) {
				if (blnFlag == true) {
					//lmp_cur = Inst->Lamp_par.lamp[Inst->Lamp_pos-1].cur;
					// Get current of set lamp position from Inst object which is store into lamp parameter collection
					dbllmp_cur = gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).Current;
					//gobjInst.Lamp.LampParametersCollection()
					//--take lamp current from inst parameters and set it
					funcSet_HCL_Cur(dbllmp_cur, gobjInst.Lamp_Position);
					//if (Inst->Lamp_warm>0) {
					//lmp_cur = Inst->Lamp_par.lamp[Inst->Lamp_warm-1].cur;
					//Set_HCL_Cur(lmp_cur,Inst->Lamp_warm);
					//}
					//set the Current of warmup lamp from Inst lamp collection object
					if ((gobjInst.Lamp_Warm > 0)) {
						dbllmp_cur = gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Warm - 1).Current;
						if (funcSet_HCL_Cur(dbllmp_cur, gobjInst.Lamp_Warm)) {
							funcSet_Lamp = true;
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
			return false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			objWait.Dispose();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcSet_HCL_Cur(double dblLampCur, int intLampPos)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcSet_HCL_Cur
		//Description            :   To set current to the lamp
		//Parameters             :   dblLampCur = current to be set to lamp
		//                           intLampPos = lamp position to which current to be set
		//Return                 :   True if success.
		//Time/Date              :   29/9/06
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Deepak B. on 23.11.06
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];
		byte bytLow;
		byte bytHigh;
		//--------------
		//        void S4FUNC Set_HCL_Cur(double cur , BYTE pos)
		//{
		//BYTE	a;

		// Inst.Cur = cur;
		// a = (BYTE) (cur*(double)10.0);
		// if(GetInstrument() == AA202 ){
		//	pos = pos-1;
		//            If (pos < 0) Then
		//		pos = 0;
		// }
		// Transmit(HCLCUR, a, pos, 0);
		//#If NEWHANDSHAKE Then
		// Recev(TRUE);
		//#End If
		//}
		//--------------
		try {
			//If gblnInComm = True Then
			//    Return False
			//End If
			// gblnInComm = True          '10.12.07

			//gobjInst.Current = dblLampCur  '10.12.07

			bytLow = (byte)dblLampCur * (double)10.0;

			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				intLampPos = intLampPos - 1;
				if ((intLampPos < 0)) {
					intLampPos = 0;
				}
			}

			//
			bytHigh = (byte)intLampPos;
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			//Send Command EnumTARHCLK (17), with Low byte , High byte parameter of Lamp current
			if (FuncTransmitCommand(EnumAAS203Protocol.HCLCUR, bytLow, bytHigh, 0)) {
				if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						funcSet_HCL_Cur = false;
						gobjMessageAdapter.ShowMessage(constSetHCLCurError);
						Application.DoEvents();
					} else {
						gobjInst.Current = dblLampCur;
						funcSet_HCL_Cur = true;
					}
				} else {
					funcSet_HCL_Cur = false;
					gobjMessageAdapter.ShowMessage(constSetHCLCurError);
					Application.DoEvents();
				}
			} else {
				funcSet_HCL_Cur = false;
				//gobjMessageAdapter.ShowMessage(constSetHCLCurError)
				//Application.DoEvents()
			}

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
			objWait.Dispose();
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcFind_Wavelength_Home()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcFind_Wavelength_Home
		//Description            :   To find Home wavelength position
		//Parameters             :   None
		//Return                 :   True if success
		//Time/Date              :   25/9/06
		//Dependencies           :   PC must communicate with Instrument through COM port
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Deepak B. on 18.11.06
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];

		//------------
		//BOOL    S4FUNC Find_Wavelength_Home(HDC hdc, int x, int y)
		//{
		//unsigned  ch, oldTout;
		//int       i, j;
		//BYTE		oParam1;

		// Inst.Wvcur = Get_Cur_Wv();
		// oldTout=Tout;
		// Tout=LONG_DEALY;
		// hold = Load_Curs();
		// Transmit(WVHOME, 0, 0, 0);
		//  if (Recev(TRUE)&& Param1==1){
		//	 do{
		//                If (!Recev(True)) Then
		//		  break;
		//		ch = Param2*256+Param1;
		//                    If (hdc! = NULL) Then
		//		 Wprintf(hdc,x, y, "%5.2f nm  ",ch/StepPerNm);
		//                        If (ch < StepPerNm) Then
		//		  break;
		//	  } while(1);
		//	}
		// Tout=VERY_LONG_DEALY ; 
		// do {
		//                                If (!Recev(True)) Then
		//	  break;
		//	if (Param1==6 || Param1==5) {
		//	  Beep();
		//	  Beep();
		//	  continue;
		//	 }
		//                                    Else
		//	 break;
		//  } while(1);
		// Tout =oldTout;
		// SetCursor(hold);
		// switch(Param1)  {
		//	case 1:  Inst.Wvcur = 0; break;
		//	case 2: Gerror_message(" Monochromator error \n MECH.HOME Sensor");
		//				break;
		//	case 3: Gerror_message(" Monochromator error \n Opto (COURSE Sensor)");
		//				break;
		//	case 4: Gerror_message(" Monochromator error \n Opto (FINE  Sensor  )");
		//				break;
		//	}
		// oParam1=Param1;
		//if( GetInstrument() != AA202 ){
		// if (Inst.Lamp_par.wvzero != 100.0 && Param1==1)  {
		//	j = (int) (Inst.Lamp_par.wvzero*(double)StepPerNm);
		//	if (j<0) j= -j;
		//	if (Inst.Lamp_par.wvzero<0){
		//		for (i= 1; i<=j+StepPerNm; i++) {
		//		  Rotate_Anticlock_Wv();
		//		  pc_delay(200);
		//		 }
		//		for (i= 1; i<=StepPerNm; i++) {
		//		  Rotate_Clock_Wv();
		//		  pc_delay(200);
		//		 }
		//	 }
		//	else  for (i= 1; i<=j; i++) {
		//		Rotate_Clock_Wv();
		//		pc_delay(200);
		//	  }
		//}
		//	Inst.Wvcur= Get_Cur_Wv();
		//	Inst.Wvcur = 0;
		//	Set_Cur_Wv();
		//#If DEMO Then
		//	wvcur=0;
		//#End If
		//  }
		// if (oParam1==1) return TRUE;
		// else return FALSE;
		//}
		//------------
		try {
			if (gFuncWavelength_Home()) {
				return true;
			} else {
				return false;
			}

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
			objWait.Dispose();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcRotate_Anticlock_Wv()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcRotate_Anticlock_Wv
		//Description            :   To Rotate turret Anticlockwise. Here turret rotates by only one step        
		//Parameters             :   None
		//Return                 :   True if success
		//Time/Date              :   28/9/06
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];

		try {
			//If gblnInComm = True Then
			//    Return False
			//End If
			// gblnInComm = True          '10.12.07
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			//Send Command EnumWVANTI (21), with 0 parameter
			if (FuncTransmitCommand(EnumAAS203Protocol.WVANTI, 0, 0, 0)) {
				if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						gobjMessageAdapter.ShowMessage(constRotateWvAntiClkError);
						Application.DoEvents();
						funcRotate_Anticlock_Wv = false;
					} else {
						//mobjCommdll.subTime_Delay(200)
						// Rotate the Anti Clock wise wavelength with one step
						funcRotate_Anticlock_Wv = true;
					}
				} else {
					//gobjMessageAdapter.ShowMessage(constRotateWvAntiClkError)
					Application.DoEvents();
					funcRotate_Anticlock_Wv = false;
				}
			} else {
				//gobjMessageAdapter.ShowMessage(constRotateWvAntiClkError)
				//Application.DoEvents()
				funcRotate_Anticlock_Wv = false;
			}

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
			objWait.Dispose();
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcRotate_Clock_Wv()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcRotate_Clock_Tur
		//Description            :   To Rotate turret clockwise. Here turret rotates by only one step        
		//Parameters             :   None
		//Return                 :   True if succsess
		//Time/Date              :   28/9/06
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];

		try {
			//If gblnInComm = True Then
			//    Return False
			//End If
			// gblnInComm = True          '10.12.07
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			//Send Command EnumWVCLK (20), with 0 parameter
			if (FuncTransmitCommand(EnumAAS203Protocol.WVCLK, 0, 0, 0)) {
				if (FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						gobjMessageAdapter.ShowMessage(constRotateWvClkError);
						Application.DoEvents();
						funcRotate_Clock_Wv = false;
					} else {
						// Rotate the Clock wise wavelength with one step
						funcRotate_Clock_Wv = true;
					}
				} else {
					//gobjMessageAdapter.ShowMessage(constRotateWvClkError)
					Application.DoEvents();
					funcRotate_Clock_Wv = false;
				}
			} else {
				//gobjMessageAdapter.ShowMessage(constRotateWvClkError)
				//Application.DoEvents()
				funcRotate_Clock_Wv = false;
			}

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
			objWait.Dispose();
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcGet_Current_Wv(ref double dblCurWv)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcGet_Current_Wv
		//Description            :   To get the current wavelength
		//Parameters             :   [OUT]dblCurWv : returns current wavelength in this variable
		//Return                 :   True if success
		//Time/Date              :   29/9/06
		//Dependencies           :   obviously PC must communicate with Instrument through COM port
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Deepak B. on 21.11.06
		//--------------------------------------------------------------------------------------

		//-------------------------------------------------------
		//double S4FUNC Get_Cur_Wv()
		//{
		//   double    x=0;
		//   #If DEMO Then
		//	    x = Inst.Wvcur = wvcur;
		//	    return x;
		//   #Else
		//       unsigned ch;
		//       int      ch1;
		//       Transmit(GETCURWV, 0, 0, 0);
		//       if (Recev(TRUE)){
		//           ch = Param2 *256 + Param1;
		//	        if (ch > 50000u) {
		//	            ch1 = ch;
		//	            x = (double) (ch1/StepPerNm);
		//	        }
		//           Else
		//	            x = (double) (ch/StepPerNm);
		//	    Inst.Wvcur = x;
		//       }
		//       return x;
		//   #End If
		//}
		//-------------------------------------------------------
		//Dim objWait As New CWaitCursor
		byte[] bytArray = new byte[6];
		UInt32 uintCurWv;
		Int32 intCurWv;
		double dblTempCurrWv = 0;

		try {
			// gblnInComm = True          '10.12.07
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			// Send the Commnad to get the cuurent Wv
			if (FuncTransmitCommand(EnumAAS203Protocol.GETCURWV, 0, 0, 0)) {
				//mobjCommdll.subTime_Delay(500)
				if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						gobjMessageAdapter.ShowMessage(constGetCurWvError);
						Application.DoEvents();
						funcGet_Current_Wv = false;
					} else {
						//store byte array (3) and byte array (2) into unsign integer
						uintCurWv = Convert.ToUInt32((bytArray(3) * 256) + bytArray(2));

						//if (ch > 50000u) {
						//	ch1 = ch;
						//	x = (double) (ch1/StepPerNm);
						//}
						//Else
						//   x = (double) (ch/StepPerNm);
						// check Unsign integere of 50000 integer value with greater than 0
						if (uintCurWv.CompareTo(UInt32.Parse(50000)) > 0) {
							intCurWv = Convert.ToInt32(uintCurWv) - 65536;

							//***************************************************
							//---Added by Mangesh on 12-Apr-2007 for AA201
							//***************************************************
							if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
								dblTempCurrWv = (double)intCurWv / CONST_STEPS_PER_NM_AA201;
							//***************************************************
							} else {
								dblTempCurrWv = (double)intCurWv / CONST_STEPS_PER_NM;
							}

						} else {
							////----- Added by Sachin Dokhale on 29.12.06
							////----- Store uintCurWv into intcurWv
							intCurWv = Convert.ToInt32(uintCurWv);

							//***************************************************
							//---Added by Mangesh on 12-Apr-2007 for AA201
							//***************************************************
							// intCurWv is total nmo steps so diveide to total no. steps for per NM
							if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
								dblTempCurrWv = (double)intCurWv / CONST_STEPS_PER_NM_AA201;
							//***************************************************
							} else {
								dblTempCurrWv = (double)intCurWv / CONST_STEPS_PER_NM;
							}

						}

						dblCurWv = dblTempCurrWv;
						funcGet_Current_Wv = true;
					}
				} else {
					//gobjMessageAdapter.ShowMessage(constGetCurWvError)
					//Application.DoEvents()
					//Return False
				}
			} else {
				//gobjMessageAdapter.ShowMessage(constGetCurWvError)
				//Application.DoEvents()
				//Return False
			}

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
			gblnInComm = false;
			//objWait.Dispose()
			//Application.DoEvents()
			//---------------------------------------------------------
		}
	}

	public bool funcSet_Current_Wv(ref double dblCurWv)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcSet_Current_Wv
		//Description            :   To Set the current wavelength
		//Parameters             :   [OUT]dblCurWv : returns current wavelength in this variable
		//Return                 :   True if success
		//Time/Date              :   29/9/06
		//Dependencies           :   obviously PC must communicate with Instrument through COM port
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Deepak B. on 21.11.06
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];
		byte bytLow;
		byte bytHigh;
		//Dim uintCurWv As Short
		int intCurWv;
		//------------------------------------------------
		//        void   S4FUNC Set_Cur_Wv()
		//{
		//double    x;
		//unsigned i;
		//BYTE     data, data1;
		// x = Inst.Wvcur*(double)StepPerNm;
		//  i =(unsigned) x;
		//  data =(BYTE) i;
		//  i=i>>8;
		//  data1 =(BYTE) i;
		// Transmit(SETWV, data, data1, 0);
		// Recev(TRUE);
		//  Get_Cur_Wv();
		//}

		//------------------------------------------------
		//Dim intX, intI As Integer
		double dblX;
		UInt32 intI;
		byte data;
		byte data1;

		try {
			//***************************************************
			//---Added by Mangesh on 12-Apr-2007 for AA201
			//***************************************************
			// dblX is Total no of steps 
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				dblX = dblCurWv * CONST_STEPS_PER_NM_AA201;
			//***************************************************
			} else {
				dblX = dblCurWv * CONST_STEPS_PER_NM;
			}
			// convert dblX to Unsign integer intI
			intI = UInt32.Parse(dblX.ToString);
			// Convrt unsign integer iniI into high byte and low byte
			data = (byte)Convert.ToInt32(intI);
			intI = UInt32.Parse((string)Convert.ToInt32(intI.ToString) >> 8);
			data1 = (byte)Convert.ToInt32(intI);

			//intI = CInt(intX)
			//bytLow = CByte(intI)
			//intI = CByte(intI >> 8)
			//bytHigh = CByte(intI)
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			if (FuncTransmitCommand(EnumAAS203Protocol.SETWV, data, data1, 0)) {
				if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						gobjMessageAdapter.ShowMessage(constSetCurWvError);
						Application.DoEvents();
						funcSet_Current_Wv = false;
					} else {
						gblnInComm = false;
						//after to set Wv get current Wv. 
						if (funcGet_Current_Wv(dblCurWv)) {
							funcSet_Current_Wv = true;
						} else {
							gobjMessageAdapter.ShowMessage(constGetCurWvError);
							Application.DoEvents();
							funcSet_Current_Wv = false;
						}
					}
				} else {
					gobjMessageAdapter.ShowMessage(constSetCurWvError);
					Application.DoEvents();
					funcSet_Current_Wv = false;
				}
			} else {
				//gobjMessageAdapter.ShowMessage(constSetCurWvError)
				//Application.DoEvents()
				funcSet_Current_Wv = false;
			}

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
			objWait.Dispose();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool gFuncWavelength_Home(ref Windows.Forms.Label lblUVWavelengthStatus = null)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   gFuncWavelength_Home
		//Description            :   To make the Wavelength indicater home        
		//Parameters             :   None
		//Affected Parameter     :   lblUVWavelengthStatus as Form Label
		//Return                 :   True if success
		//Time/Date              :   26.11.06
		//Dependencies           :   obviously PC must communicate with Instrument through COM port
		//Author                 :   Deepak B.
		//Revision               :
		//Revision by Person     :   Deepak B. on 13.1.07
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];
		int intWv;
		byte BParam2;
		int intJ;
		int intCount;
		double dblWV;

		//------------
		//BOOL    S4FUNC Find_Wavelength_Home(HDC hdc, int x, int y)
		//{
		//unsigned  ch, oldTout;
		//int       i, j;
		//BYTE		oParam1;

		// Inst.Wvcur = Get_Cur_Wv();
		// oldTout=Tout;
		// Tout=LONG_DEALY;
		// hold = Load_Curs();
		// Transmit(WVHOME, 0, 0, 0);
		//  if (Recev(TRUE)&& Param1==1){ //1
		//	 do{ //2
		//                If (!Recev(True)) Then
		//		  break;
		//		ch = Param2*256+Param1;
		//                    If (hdc! = NULL) Then
		//		 Wprintf(hdc,x, y, "%5.2f nm  ",ch/StepPerNm);
		//                        If (ch < StepPerNm) Then
		//		  break;
		//	  } while(1);//2
		//	}//1
		// Tout=VERY_LONG_DEALY ; 
		// do {//3
		//                                If (!Recev(True)) Then
		//	  break;
		//	if (Param1==6 || Param1==5) {//4
		//	  Beep();
		//	  Beep();
		//	  continue;
		//	 }//4
		//                                    Else
		//	 break;
		//  } while(1);//3
		// Tout =oldTout;
		// SetCursor(hold);
		// switch(Param1)  {//5
		//	case 1:  Inst.Wvcur = 0; break;
		//	case 2: Gerror_message(" Monochromator error \n MECH.HOME Sensor");
		//				break;
		//	case 3: Gerror_message(" Monochromator error \n Opto (COURSE Sensor)");
		//				break;
		//	case 4: Gerror_message(" Monochromator error \n Opto (FINE  Sensor  )");
		//				break;
		//	}//5
		// oParam1=Param1;
		//if( GetInstrument() != AA202 ){//6
		// if (Inst.Lamp_par.wvzero != 100.0 && Param1==1)  {//7
		//	j = (int) (Inst.Lamp_par.wvzero*(double)StepPerNm);
		//	if (j<0) j= -j;
		//	if (Inst.Lamp_par.wvzero<0){ //8
		//		for (i= 1; i<=j+StepPerNm; i++) {//9
		//		  Rotate_Anticlock_Wv();
		//		  pc_delay(200);
		//		 }//9
		//		for (i= 1; i<=StepPerNm; i++) {//10
		//		  Rotate_Clock_Wv();
		//		  pc_delay(200);
		//		 }//10
		//	 }//8
		//	else  for (i= 1; i<=j; i++) {//11
		//		Rotate_Clock_Wv();
		//		pc_delay(200);
		//	  }//11
		//}//7
		//	Inst.Wvcur= Get_Cur_Wv();
		//	Inst.Wvcur = 0;
		//	Set_Cur_Wv();
		//#If DEMO Then
		//	wvcur=0;
		//#End If
		//  }//6
		// if (oParam1==1) return TRUE;
		// else return FALSE;
		//}
		//------------
		try {
			//before set Wv. Home command Get the current Wv. position
			if (funcGet_Current_Wv(gobjInst.WavelengthCur) == true) {
				//' gblnInComm = True          '10.12.07
				//10.12.07
				if (mobjCommdll.gFuncResumeProcess == false) {
					return false;
				}
				// Send Wv. Mode Command WVHOME (11)
				if (FuncTransmitCommand(EnumAAS203Protocol.WVHOME, 0, 0, 0) == true) {
					if (FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY) == true & bytArray(2) == 1) {
						do {
							if (FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY) == false) {
								break; // TODO: might not be correct. Was : Exit Do
							}

							intWv = (bytArray(3) * 256) + bytArray(2);

							//***************************************************
							//---Added by Mangesh on 12-Apr-2007 for AA201
							//***************************************************
							if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
								if (!IsNothing(lblUVWavelengthStatus)) {
									lblUVWavelengthStatus.Text = "Wavelength (nm): " + FormatNumber((intWv / CONST_STEPS_PER_NM_AA201), 2);
									lblUVWavelengthStatus.Refresh();
								}
								if (intWv < CONST_STEPS_PER_NM_AA201) {
									break; // TODO: might not be correct. Was : Exit Do
								}
							//***************************************************
							} else {
								if (!IsNothing(lblUVWavelengthStatus)) {
									lblUVWavelengthStatus.Text = "Wavelength (nm): " + FormatNumber((intWv / CONST_STEPS_PER_NM), 2);
									lblUVWavelengthStatus.Refresh();
								}
								if (intWv < CONST_STEPS_PER_NM) {
									break; // TODO: might not be correct. Was : Exit Do
								}
							}

						} while ((1));

					}

					do {
						if (FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY) == false) {
							break; // TODO: might not be correct. Was : Exit Do
						}
						if (bytArray(2) == EnumErrorMessage.SHOME_ERROR | bytArray(2) == EnumErrorMessage.COMM_ERROR) {
							Beep();
							Beep();
							goto EndOfLoop;
						} else {
							break; // TODO: might not be correct. Was : Exit Do
						}
						EndOfLoop:

						switch (bytArray(2)) {
							case EnumErrorMessage.NO_ERROR:
								gobjInst.WavelengthCur = 0;
								break; // TODO: might not be correct. Was : Exit Select

							case EnumErrorMessage.LOBYTE_ERROR:
								gobjMessageAdapter.ShowMessage(constMechWVHomeError);
								Application.DoEvents();
								break; // TODO: might not be correct. Was : Exit Select

							case EnumErrorMessage.COARSEHOME_ERROR:
								gobjMessageAdapter.ShowMessage(constCoarseWVHomeError);
								Application.DoEvents();
								break; // TODO: might not be correct. Was : Exit Select

							case EnumErrorMessage.FINEHOME_ERROR:
								gobjMessageAdapter.ShowMessage(constFineWVHomeError);
								Application.DoEvents();
								break; // TODO: might not be correct. Was : Exit Select

						}

						BParam2 = bytArray(2);

						if (gobjInst.Lamp.WavelengthZero != 100.0 & bytArray(2) == 1) {
							Application.DoEvents();

							//***************************************************
							//---Added by Mangesh on 12-Apr-2007 for AA201
							//***************************************************
							if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
								intJ = (int)gobjInst.Lamp.WavelengthZero * CONST_STEPS_PER_NM_AA201;
							} else {
								intJ = (int)gobjInst.Lamp.WavelengthZero * CONST_STEPS_PER_NM;
							}
							//***************************************************

							if (intJ < 0) {
								intJ = -intJ;
							}

							if (gobjInst.Lamp.WavelengthZero < 0) {
								//***************************************************
								//---Changed and Added by Mangesh on 12-Apr-2007 for AA201
								//***************************************************
								if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
									for (intCount = 1; intCount <= intJ + CONST_STEPS_PER_NM_AA201; intCount++) {
										funcRotate_Anticlock_Wv();
									}
									for (intCount = 1; intCount <= CONST_STEPS_PER_NM_AA201; intCount++) {
										funcRotate_Clock_Wv();
									}
								} else {
									for (intCount = 1; intCount <= intJ + CONST_STEPS_PER_NM; intCount++) {
										funcRotate_Anticlock_Wv();
									}
									for (intCount = 1; intCount <= CONST_STEPS_PER_NM; intCount++) {
										funcRotate_Clock_Wv();
									}
								}
							//***************************************************

							} else {
								for (intCount = 1; intCount <= intJ; intCount++) {
									funcRotate_Clock_Wv();
								}
							}
						}

						if (funcGet_Current_Wv(gobjInst.WavelengthCur) == true) {
							gobjInst.WavelengthCur = 0;
							funcSet_Current_Wv(gobjInst.WavelengthCur);
						}

						if (BParam2 == 1) {
							return true;
						} else {
							return false;
						}
					} while (true);
					//gobjMessageAdapter.ShowMessage(constWVHomeError)
					//Application.DoEvents()
					gFuncWavelength_Home = false;
				}
			} else {
				//gobjMessageAdapter.ShowMessage(constGetCurWvError)
				//Application.DoEvents()
				gFuncWavelength_Home = false;
			}

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
			objWait.Dispose();
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool gFuncSlit_Home()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   gFuncSlit_Home
		//Description            :   To make the Slit indicater home        
		//Parameters             :   None
		//Return                 :   True if success
		//Time/Date              :   25/9/06
		//Dependencies           :   obviously PC must communicate with Instrument through COM port
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Deepak B. on 17.11.06 as some part of code was left behind by rahul
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];
		int intErrorSlitHome;
		try {
			//send the Slit Home Command
			//SLITHOME (14)
			if (gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam) {
				intErrorSlitHome = constErrorSlitHome;
			} else {
				intErrorSlitHome = constErrorEntrySlitHome;
			}
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			if (FuncTransmitCommand(EnumAAS203Protocol.SLITHOME, 0, 0, 0)) {
				if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						gFuncSlit_Home = false;
						//gobjMessageAdapter.ShowMessage(constErrorSlitHome)
						gobjMessageAdapter.ShowMessage(intErrorSlitHome);
					} else {
						//when byte array (2) is not 0 then set slit position is set to 0
						if (bytArray(2)) {
							gobjInst.SlitPosition = 0;
							return true;
						} else {
							//gobjMessageAdapter.ShowMessage(constErrorSlitHome)
							gobjMessageAdapter.ShowMessage(intErrorSlitHome);
						}
						//If bytArray(2) Then
						//Return True
						//End If
					}
				} else {
					gFuncSlit_Home = false;
					//gobjMessageAdapter.ShowMessage(constErrorSlitHome)
					gobjMessageAdapter.ShowMessage(intErrorSlitHome);
					//gFuncShowMessage("Error...", "Error setting Slit Home.", EnumMessageType.Information)
				}
			} else {
				gFuncSlit_Home = false;
				//gobjMessageAdapter.ShowMessage(constErrorSlitHome)
				//gobjMessageAdapter.ShowMessage(intErrorSlitHome)
				//gFuncShowMessage("Error...", "Error setting Slit Home.", EnumMessageType.Information)
			}

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
			objWait.Dispose();
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	//Public Function funcSet_SlitWidth(ByVal dblSlitWidth As Double, Optional ByVal intInstrumentBeamTypeIn As enumInstrumentBeamType = enumInstrumentBeamType.SingleBeam) As Boolean
	//    '-----------------------------------  Procedure Header  -------------------------------
	//    'Procedure Name         :   funcSet_SlitWidth
	//    'Description            :   To set the slit width
	//    'Parameters             :   dblSlitWidth : width for slit to be set
	//    'Time/Date              :   28/9/06
	//    'Dependencies           :   obviously PC must communicate with Instrument through COM port
	//    'Author                 :   Rahul B.
	//    'Revision               :
	//    'Revision by Person     :   Deepak B. on 17.11.06
	//    '--------------------------------------------------------------------------------------
	//    Dim objWait As New CWaitCursor
	//    Dim dblS1 As Double = 0.0
	//    Dim intSlit As Integer
	//    Dim blnIsSlitWidthSet As Boolean
	//    '--------------------
	//    '        void   S4FUNC Set_SlitWidth(double sw)
	//    '{
	//    'double s1=0;
	//    'int slit;
	//    '  s1 = sw* (double) 40.0;
	//    '  slit = (int)s1 ;
	//    '  slit=80-slit;
	//    '  Position_Slit(slit);
	//    '}
	//    '--------------------
	//    Try
	//        dblS1 = dblSlitWidth * CDbl(40.0)
	//        intSlit = CInt(dblS1)
	//        intSlit = 80 - intSlit

	//        Select Case intInstrumentBeamTypeIn

	//            Case enumInstrumentBeamType.SingleBeam
	//                If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
	//                    '---For 203D instrument in single beam Mode 
	//                    '---operate both entry & exit slits
	//                    blnIsSlitWidthSet = funcPosition_Slit_EntryExit(intSlit)

	//                ElseIf gstructSettings.AppMode = EnumAppMode.FullVersion_203 Then
	//                    '---For 203 instrument in single beam Mode 
	//                    '---operate only entry slit
	//                    blnIsSlitWidthSet = funcPosition_Slit_Entry(intSlit)

	//                ElseIf gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
	//                    '---For 202 instrument in single beam Mode 
	//                    blnIsSlitWidthSet = funcPosition_Slit_Entry(intSlit)

	//                End If

	//            Case enumInstrumentBeamType.ReferenceBeam
	//                blnIsSlitWidthSet = funcPosition_Slit_Entry(intSlit)

	//            Case enumInstrumentBeamType.DoubleBeam
	//                blnIsSlitWidthSet = funcPosition_Slit_EntryExit(intSlit)

	//        End Select

	//        If blnIsSlitWidthSet Then
	//            Return True
	//        Else
	//            Return False
	//        End If

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
	//        objWait.Dispose()
	//        Application.DoEvents()
	//        '---------------------------------------------------------
	//    End Try
	//End Function

	public bool funcSet_SlitWidth(double dblSlitWidth, int intSlitType = 0)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcSet_SlitWidth
		//Description            :   To set the slit width
		//Parameters             :   intSlitType : width for slit to be set
		//Return                 :   True if success
		//Time/Date              :   08.04.07
		//Dependencies           :   obviously PC must communicate with Instrument through COM port
		//Author                 :   Sachin Dokhale
		//Revision               :
		//Revision by Person     :   
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		double dblS1 = 0.0;
		int intSlit;
		bool blnIsSlitWidthSet;
		//--------------------
		//        void   S4FUNC Set_SlitWidth(double sw)
		//{
		//double s1=0;
		//int slit;
		//  s1 = sw* (double) 40.0;
		//  slit = (int)s1 ;
		//  slit=80-slit;
		//  Position_Slit(slit);
		//}
		//--------------------
		try {
			dblS1 = dblSlitWidth * (double)40.0;
			intSlit = (int)dblS1;
			intSlit = 80 - intSlit;

			//intSlitType int variable is use for 203D whe it is set 
			if (intSlitType == 1) {
				//---For 203 instrument in single beam Mode 
				blnIsSlitWidthSet = funcPosition_Slit_Exit(intSlit);

			} else if (intSlitType == 2) {
				//---For 203D instrument in single beam Mode 
				//---operate only Entry and Exit slit
				blnIsSlitWidthSet = funcPosition_Slit_EntryExit(intSlit);
			} else {
				//---For 203 instrument in single beam Mode 
				//---operate only entry slit
				blnIsSlitWidthSet = funcPosition_Slit_Entry(intSlit);
			}

			if (blnIsSlitWidthSet) {
				return true;
			} else {
				return false;
			}

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
			objWait.Dispose();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcPosition_Slit_Entry(int intSlit)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcPosition_Slit_Entry
		//Description            :   To position the slit at the said width
		//Parameters             :   intSlit : position at which slit to be adjusted
		//Return                 :   True if Success
		//Time/Date              :   28/9/06
		//Dependencies           :   obviously PC must communicate with Instrument through COM port
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Deepak B. on 17.11.06
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];
		byte bytSlitWidth1;
		int intSlitWidthError;
		//------------------------
		//        void   S4FUNC Position_Slit(int sw)
		//{
		//BYTE  sw1;
		//hold = Load_Curs();
		// if (Inst.Slitpos!=sw) {
		//	 sw1 = (BYTE) sw;
		//	 Transmit(SLITPOS, sw1, 0 , 0);
		//	 Inst.Slitpos =sw;
		//	 Recev(TRUE);
		// }
		//SetCursor(hold);
		//}
		//------------------------

		try {
			if (gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam) {
				intSlitWidthError = constSlitWidthError;
			} else {
				intSlitWidthError = constEntrySlitWidthError;
			}

			// use new Slit position is not = with  Inst object Lsit position
			if (gobjInst.SlitPosition != intSlit) {
				bytSlitWidth1 = (byte)intSlit;
				//10.12.07
				if (mobjCommdll.gFuncResumeProcess == false) {
					return false;
				}
				//send command for slit position SLITPOS(15)
				if (FuncTransmitCommand(EnumAAS203Protocol.SLITPOS, bytSlitWidth1, 0, 0)) {
					if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
						if (bytArray(1) != 1) {
							gobjMessageAdapter.ShowMessage(intSlitWidthError);
							Application.DoEvents();
							return false;
						} else {
							//Set the slit postion to Inst object when byte array(1) is 1
							gobjInst.SlitPosition = intSlit;
							return true;
						}
					} else {
						gobjMessageAdapter.ShowMessage(intSlitWidthError);
						Application.DoEvents();
						return false;
					}
				} else {
					//gobjMessageAdapter.ShowMessage(intSlitWidthError)
					//Application.DoEvents()
					return false;
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
			objWait.Dispose();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool gFuncPneumatics()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   gFuncPneumatics
		//Description            :   To check pneumatics like Burner parameters and pressure sensors        
		//Parameters             :   None
		//Return                 :   True if success
		//Time/Date              :   25/9/06
		//Dependencies           :   obviously PC must communicate with Instrument through COM port
		//                           and one more thing is that if we wont wait for 10 sec in slit home 
		//                           it returns error code... GOD knows why this happens
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     : deepak b on 16.11.06
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];
		byte bData;
		bool ps1;
		bool ps2;
		bool ps3;
		bool aa;
		bool flag = true;
		int intCount = 0;

		try {
			//funcSetBH_HOME()
			//If funcSetNV_HOME() Then
			//    If funcCheckBurnerParameters() Then
			//If funcPressSensorStatus() Then
			//    gFuncPneumatics = True
			//Else
			//    gFuncPneumatics = False
			//End If
			//    Else
			//        gFuncPneumatics = False
			//    End If
			//Else
			//    gFuncPneumatics = False
			//End If

			// Set Burner height position to home position
			funcSetBH_HOME();
			//Set Needle Valve Position to Home position
			if (funcSetNV_HOME()) {
				do {
					//ps1 is use for Air pressure
					//ps2 is use for N2O pressure
					//ps3 is use for FUEL pressure
					ps1 = true;
					ps2 = true;
					ps3 = true;
					flag = true;

					//bData ref.  parameter in byte for Burner parameter whether AA bur. or N2O
					funcCheckBurnerParameters(bData);
					//if AA Bur is conneted the set aa to true
					if ((bData & EnumErrorStatus.AA_CONNECTED)) {
						aa = true;
					} else {
						aa = false;
					}
					// bData ref.  parameter in byte for pressure sensor status
					if (funcPressSensorStatus(bData)) {
						//check byte param. and AIR_NOK (128)
						if ((bData & EnumErrorStatus.AIR_NOK)) {
							ps1 = false;
						}
						//check byte param. and N2O_NOK (64)
						if ((bData & EnumErrorStatus.N2O_NOK)) {
							ps2 = false;
						}
						//check byte param. and FUEL_NOK(32)
						if ((bData & EnumErrorStatus.FUEL_NOK)) {
							ps3 = false;
						}

						if (ps1 == false) {
							gobjMessageAdapter.ShowMessage(constLowAirPressureRetry);
							Application.DoEvents();
							flag = false;
						}

						if (aa == false & ps2 == false) {
							gobjMessageAdapter.ShowMessage(constLowNitrousPressureRetry);
							Application.DoEvents();
							flag = false;
						}
						if (ps3 == false) {
							gobjMessageAdapter.ShowMessage(constLowFuelPressureRetry);
							Application.DoEvents();
							flag = false;
						}
						intCount += 1;
					}

				} while ((flag == false & intCount < 2));
				//loop untill senssor flag is not set and untill loop count is less than 2  
				return flag;
			} else {
				gFuncPneumatics = false;
			}

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
			objWait.Dispose();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcCheckBurnerParameters(ref byte bdata, bool blnShowErrorMessages = true)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcCheckBurnerParameters
		//Description            :   To check Burner parameters
		//Parameters             :   bdata as byte, blnShowErrorMessages as bool 
		//Return                 :   True if success
		//Time/Date              :  16.11.06 
		//Dependencies           :   
		//Author                 :   Deepak
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		//Dim objWait As New CWaitCursor
		byte[] bytArray = new byte[6];

		try {
			//If gblnInComm = True Then
			//    Return False
			//End If
			// gblnInComm = True          '10.12.07
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			//check Burner parameters for AA bur. or N2O Bur. 
			if (FuncTransmitCommand(EnumAAS203Protocol.CHKBURNER, 0, 0, 0)) {
				if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						//Return False
						if (blnShowErrorMessages == true) {
							gobjMessageAdapter.ShowMessage(constBurnerCheckError);
							Application.DoEvents();
						}
						return false;
					} else {
						//return value of array of byte from received block
						bdata = bytArray(2);
						return true;
					}
				} else {
					return false;
					//If blnShowErrorMessages = True Then
					//    gobjMessageAdapter.ShowMessage(constBurnerCheckError)
					//    Application.DoEvents()
					//End If
				}
			} else {
				return false;
				//If blnShowErrorMessages = True Then
				//    'gobjMessageAdapter.ShowMessage(constBurnerCheckError)
				//    Application.DoEvents()
				//End If
			}

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
			//objWait.Dispose()
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcPressSensorStatus(ref byte bData, bool blnShowErrorMessages = true)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcPressSensorStatus
		//Description            :   To check pressure sensors for AIR, N2O, Fuel etc.
		//Parameters             :   bdata as byte, blnShowErrorMessages as bool to show message of not
		//Return                 :   True if success
		//Time/Date              :   16.11.06
		//Dependencies           :   
		//Author                 :   Deepak B.
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		//Dim objWait As New CWaitCursor
		byte[] bytArray = new byte[6];

		try {
			//If gblnInComm = True Then
			//    Return False
			//End If

			// gblnInComm = True          '10.12.07
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			//check pressure sensor parameters  
			if (FuncTransmitCommand(EnumAAS203Protocol.PSSTATUS, 0, 0, 0)) {
				if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
					//return value of array of byte from received block
					bData = bytArray(2);
					if (bytArray(1) == 1) {
						return true;
					} else {
						return false;
					}
				} else {
					if (blnShowErrorMessages == true) {
						gobjMessageAdapter.ShowMessage(constPressureSensorError);
						Application.DoEvents();
					}
					return false;
				}
			} else {
				//If blnShowErrorMessages = True Then
				//    gobjMessageAdapter.ShowMessage(constLowFuelPressure)
				//    Application.DoEvents()
				//End If
				return false;
			}

		} catch (Threading.ThreadAbortException threadex) {
			//---Do Nothing
			return false;
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
			// objWait.Dispose()
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool gFuncAnalogSelfTest(int intAvgOfADCReadings, ref double dblADCValue = 0.0)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   gFuncAnalogSelfTest
		//Description            :   To perform a test for ADC count and voltage. if voltage comes 
		//                           around 3000 mv then test is successful else test fails
		//Parameters             :   intAvgOfADCReadings,dblADCValue
		//Return                 :   True if success
		//Time/Date              :   25/9/06
		//Dependencies           :   obviously PC must communicate with Instrument through COM port
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Deepak B. on 22.11.06
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		int intADCFmv = 0;

		try {
			//Set Calibration mode to the Self Test mode. SELFTEST(6)
			if (funcCalibrationMode(EnumCalibrationMode.SELFTEST, enumInstrumentBeamType.SingleBeam)) {
				// Avg of ADC Readings is 1 then 
				//ADC filter voltage is check with 5000 then true

				if (intAvgOfADCReadings == 1) {
					if (funcReadADCNonFilter(intADCFmv)) {
						if (intADCFmv == 5000) {
							gFuncAnalogSelfTest = false;
							gobjMessageAdapter.ShowMessage(constADCNonFilter);
							Application.DoEvents();
						} else {
							gFuncAnalogSelfTest = true;
						}
					} else {
						gFuncAnalogSelfTest = false;
					}
				} else {
					// Avg of ADC Readings is not 1 then 
					//ADC filter voltage should be rage of > 3255 and less than 3296
					mobjCommdll.subTime_Delay(50);
					if (funcReadADCFilter(intAvgOfADCReadings, intADCFmv)) {
						if (intADCFmv > 3255 & intADCFmv < 3296) {
							dblADCValue = intADCFmv;
							gFuncAnalogSelfTest = true;
						} else {
							gFuncAnalogSelfTest = false;
							gobjMessageAdapter.ShowMessage(constADCFilter);
							Application.DoEvents();
						}
					} else {
						gFuncAnalogSelfTest = false;
					}
				}
			} else {
				gFuncAnalogSelfTest = false;
			}

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
			objWait.Dispose();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	//#######################################################
	//TODO Later Name change this function to funcSetBeamAndCalibrationMode
	//#######################################################
	//Public Function funcCalibrationMode(ByVal bytCalibMode As Byte, Optional ByVal intInstrumentBeamType As enumInstrumentBeamType = enumInstrumentBeamType.SingleBeam) As Boolean
	//    '---------------------------------------------------------------------------------------
	//    'Procedure Name         :   funcSetBeamAndCalibrationMode
	//    'Description            :   To set instrument Beam mode and Calibration Mode
	//    'Parameters             :   bytCalibMode : mode in which inst. to be set
	//    '                       :   intInstrumentBeamType as enumInstrumentBeamType
	//    'Return                 :   True if success   
	//    'Time/Date              :   26/9/06
	//    'Dependencies           :   obviously PC must communicate with Instrument through COM port
	//    'Author                 :   Rahul B.
	//    'Revision               :   3
	//    'Revision by Person     :   Deepak B. on 17.11.06 as some part of code was left behind by rahul
	//    'Revision by Person     :   Mangesh S. on 06-Apr-2007 To set Beam type of Instrument as per
	//    '                           selected Single Beam or Double Beam.
	//    '--------------------------------------------------------------------------------------
	//    Dim objWait As New CWaitCursor
	//    Dim bytArray(7) As Byte
	//    Dim intMode As Integer

	//    Try
	//        If intInstrumentBeamType = enumInstrumentBeamType.SingleBeam Then
	//            ' Set Calibration mode for Diff. operation mode and instrument type 
	//            If gintInstrumentBeamType = enumInstrumentBeamType.SingleBeam Then
	//                intMode = EnumAAS203Protocol.MODE
	//            ElseIf gintInstrumentBeamType = enumInstrumentBeamType.DoubleBeam Then
	//                'Select Case gobjInst.Mode
	//                Select Case bytCalibMode
	//                    Case EnumCalibrationMode.AA
	//                        intMode = EnumAAS203Protocol.SETMODE_DB
	//                    Case Else
	//                        intMode = EnumAAS203Protocol.MODE
	//                End Select
	//                ' Set the protocol for double beam
	//                'intMode = EnumAAS203Protocol.SETMODE_DB  '31.07.07
	//            ElseIf gintInstrumentBeamType = enumInstrumentBeamType.ReferenceBeam Then
	//                intMode = EnumAAS203Protocol.SETMODE_RB
	//            Else
	//                intMode = EnumAAS203Protocol.MODE
	//            End If
	//        Else
	//            'If intInstrumentBeamType = enumInstrumentBeamType.SingleBeam Then
	//            '    intMode = EnumAAS203Protocol.MODE
	//            If intInstrumentBeamType = enumInstrumentBeamType.DoubleBeam Then
	//                'Select Case gobjInst.Mode
	//                Select Case bytCalibMode
	//                    Case EnumCalibrationMode.AA
	//                        intMode = EnumAAS203Protocol.SETMODE_DB
	//                    Case Else
	//                        intMode = EnumAAS203Protocol.MODE
	//                End Select
	//                ' Set the protocol for double beam
	//                'intMode = EnumAAS203Protocol.SETMODE_DB  '31.07.07
	//            ElseIf intInstrumentBeamType = enumInstrumentBeamType.ReferenceBeam Then
	//                intMode = EnumAAS203Protocol.SETMODE_RB
	//            Else
	//                intMode = EnumAAS203Protocol.MODE
	//            End If
	//        End If
	//        If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
	//            Return False
	//        End If
	//        ' Send command for Calibration Setting 
	//        If FuncTransmitCommand(intMode, bytCalibMode, 0, 0) Then
	//            If FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY) Then
	//                If bytArray(1) <> 1 Then
	//                    Call gobjMessageAdapter.ShowMessage(constCalibrationMode)
	//                    Call Application.DoEvents()
	//                    Return False
	//                Else
	//                    '---this else block of code is added by deepak on 15.11.06
	//                    gobjInst.Mode = bytCalibMode
	//                    ' check condition for 201 Inst.
	//                    If Not (gstructSettings.AppMode = EnumAppMode.FullVersion_201) Then
	//                        If mintSSGain > &H0 Then

	//                            If gstructSettings.D2Gain = False Then
	//                                Return True
	//                            Else
	//                                If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
	//                                    Return False
	//                                End If
	//                                If FuncTransmitCommand(EnumAAS203Protocol.GAINX10_ON, 0, 0, 0) Then
	//                                    Array.Clear(bytArray, 0, 8)
	//                                    If FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY) Then
	//                                        If bytArray(1) <> 1 Then
	//                                            Call gobjMessageAdapter.ShowMessage(constCalibrationMode)
	//                                            Call Application.DoEvents()
	//                                            Return False
	//                                        End If
	//                                    End If
	//                                End If
	//                            End If

	//                        End If
	//                    End If
	//                    Return True
	//                End If
	//            Else
	//                Call gobjMessageAdapter.ShowMessage(constCalibrationMode)
	//                Call Application.DoEvents()
	//                Return False
	//            End If
	//        Else
	//            'Call gobjMessageAdapter.ShowMessage(constCalibrationMode)
	//            'Call Application.DoEvents()
	//            Return False
	//        End If

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
	//        objWait.Dispose()
	//        Application.DoEvents()
	//        '---------------------------------------------------------
	//    End Try
	//End Function
	//#######################################################

	public bool funcCalibrationMode(byte bytCalibMode, enumInstrumentBeamType intInstrumentBeamType = enumInstrumentBeamType.SingleBeam)
	{
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];
		int intMode;
		//---this function is modified on 05.09.08
		try {
			//If intInstrumentBeamType = enumInstrumentBeamType.SingleBeam Then
			//    ' Set Calibration mode for Diff. operation mode and instrument type 
			//    If gintInstrumentBeamType = enumInstrumentBeamType.SingleBeam Then
			//        intMode = EnumAAS203Protocol.MODE
			//    ElseIf gintInstrumentBeamType = enumInstrumentBeamType.DoubleBeam Then
			//        'Select Case gobjInst.Mode
			//        Select Case bytCalibMode
			//            Case EnumCalibrationMode.AA
			//                intMode = EnumAAS203Protocol.SETMODE_DB
			//            Case Else
			//                intMode = EnumAAS203Protocol.MODE
			//        End Select
			//        ' Set the protocol for double beam
			//        'intMode = EnumAAS203Protocol.SETMODE_DB  '31.07.07
			//    ElseIf gintInstrumentBeamType = enumInstrumentBeamType.ReferenceBeam Then
			//        intMode = EnumAAS203Protocol.SETMODE_RB
			//    Else
			//        intMode = EnumAAS203Protocol.MODE
			//    End If
			//Else
			//    'If intInstrumentBeamType = enumInstrumentBeamType.SingleBeam Then
			//    '    intMode = EnumAAS203Protocol.MODE
			//    If intInstrumentBeamType = enumInstrumentBeamType.DoubleBeam Then
			//        'Select Case gobjInst.Mode
			//        Select Case bytCalibMode
			//            Case EnumCalibrationMode.AA
			//                intMode = EnumAAS203Protocol.SETMODE_DB
			//            Case Else
			//                intMode = EnumAAS203Protocol.MODE
			//        End Select
			//        ' Set the protocol for double beam
			//        'intMode = EnumAAS203Protocol.SETMODE_DB  '31.07.07
			//    ElseIf intInstrumentBeamType = enumInstrumentBeamType.ReferenceBeam Then
			//        intMode = EnumAAS203Protocol.SETMODE_RB
			//    Else
			//        intMode = EnumAAS203Protocol.MODE
			//    End If
			//End If

			if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
				intMode = EnumAAS203Protocol.SETMODE_DB;
			} else {
				intMode = EnumAAS203Protocol.MODE;
			}

			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			// Send command for Calibration Setting 
			if (FuncTransmitCommand(intMode, bytCalibMode, 0, 0)) {
				if (FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						gobjMessageAdapter.ShowMessage(constCalibrationMode);
						Application.DoEvents();
						return false;
					} else {
						//---this else block of code is added by deepak on 15.11.06
						gobjInst.Mode = bytCalibMode;
						// check condition for 201 Inst.
						if (!(gstructSettings.AppMode == EnumAppMode.FullVersion_201)) {

							if (mintSSGain > 0x0) {
								if (gstructSettings.D2Gain == false) {
									return true;
								} else {
									//10.12.07
									if (mobjCommdll.gFuncResumeProcess == false) {
										return false;
									}
									if (FuncTransmitCommand(EnumAAS203Protocol.GAINX10_ON, 0, 0, 0)) {
										Array.Clear(bytArray, 0, 8);
										if (FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY)) {
											if (bytArray(1) != 1) {
												gobjMessageAdapter.ShowMessage(constCalibrationMode);
												Application.DoEvents();
												return false;
											}
										}
									}
								}

							}
						}
						return true;
					}
				} else {
					gobjMessageAdapter.ShowMessage(constCalibrationMode);
					Application.DoEvents();
					return false;
				}
			} else {
				//Call gobjMessageAdapter.ShowMessage(constCalibrationMode)
				//Call Application.DoEvents()
				return false;
			}

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
			objWait.Dispose();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcReadADCFilter(int intNumOfReadingsForAvg, ref int intAvgInMv)
	{
		//--------------------------------------------------------------------------------------
		//Procedure Name         :   funcReadADCFilter
		//Description            :   to read ADC count for filtered data.
		//Parameters             :   intNumOfReadingsForAvg : no of readings taken for averaging
		//                           [OUT] intAvgInmv : avg. of ADC count return
		//Return                 :   True if success
		//Time/Date              :   26/9/06
		//Dependencies           :   obviously PC must communicate with Instrument through COM port
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Deepak B. on 17.11.06 minor modifications
		//--------------------------------------------------------------------------------------
		//Dim objWait As New CWaitCursor
		byte[] bytArray = new byte[6];
		byte bytLow;
		byte bytHigh;
		//++++++++++++++++++++++++++
		//int	S4FUNC ReadADCFilter()
		//{
		//int  i=5000;

		// if (Inst.Avg==1)
		//	return ReadADC();

		// Transmit(ADCF, (BYTE) Inst.Avg, (BYTE) (Inst.Avg>>8), 0);
		//            If (Recev(True)) Then
		//	i = Param2*256 + Param1;
		//#If DEMO Then
		//  pc_delay(10000);   pc_delay(10000);
		//  pc_delay(10000);  pc_delay(10000);
		//	i= pmtAd()+random(10);
		//#End If
		//#If QDEMO Then
		//	i= pmtAd()+random(100);
		//#End If
		// if (i==5000)
		//  Gerror_message_new("ADC Error ","System Error");
		//return(i);
		//}
		//++++++++++++++++++++++++++

		try {
			//If gblnInComm = True Then
			//    Return False
			//End If
			gFunclongtobyte(intNumOfReadingsForAvg, bytLow, bytHigh);

			if (gobjInst.Average == 1) {
				return funcReadADCNonFilter(intAvgInMv);
			}
			// gblnInComm = True          '10.12.07
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			// Send  ADC Filter commnad for ADCF(2) value
			if (FuncTransmitCommand(EnumAAS203Protocol.ADCF, bytLow, bytHigh, 0)) {
				if (FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						funcReadADCFilter = false;
						gobjMessageAdapter.ShowMessage(constADCFilter);
						Application.DoEvents();
					} else {
						//Calculate ADC voltage from byte array.
						intAvgInMv = bytArray(2) + (bytArray(3) * 256);
						////----- Added by Sachin Dokhale for Demo mode
						//#If DEMO Then
						//	i= pmtAd()+random(10);
						//#End If
						// use ramdom function for Adcf with funcpmtAd for Demo mode then use 
						//If gstructSettings.AppMode = EnumAppMode.DemoMode Then
						if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
							intAvgInMv = funcpmtAd() + bytRandom.Next(10);
						}
						////-----
						if (intAvgInMv == 5000) {
							gobjMessageAdapter.ShowMessage(constADCError);
						}
						funcReadADCFilter = true;
					}
				} else {
					funcReadADCFilter = false;
					gobjMessageAdapter.ShowMessage(constADCFilter);
					Application.DoEvents();
				}
			} else {
				funcReadADCFilter = false;
				//gobjMessageAdapter.ShowMessage(constADCFilter)
				//Application.DoEvents()
			}

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
			//objWait.Dispose()
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcReadADCNonFilter(ref int intAvgInMv)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcReadADCNonFilter
		//Description            :   to read ADC count for non filtered data.
		//Parameters             :   [OUT] intAvgInmv : avg. of ADC count return
		//Return                 :   True if success
		//Time/Date              :   26/9/06
		//Dependencies           :   obviously PC must communicate with Instrument through COM port
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		//Dim objWait As New CWaitCursor
		byte[] bytArray = new byte[6];
		//++++++++++++++++++++++
		//        int	S4FUNC ReadADC()
		//{
		//int	i=5000;
		// Transmit(ADCNF, 0, 0, 0);
		//        If (Recev(True)) Then
		//	i = Param2*256 + Param1;
		//#If DEMO Then
		//	i= pmtAd()+random(10);
		//#End If
		// if (i==5000)
		//	Gerror_message_new("ADC Error ","System Error");
		//return(i);
		//}
		//++++++++++++++++++++++
		try {
			//If gblnInComm = True Then
			//    Return False
			//End If
			// gblnInComm = True          '10.12.07
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			if (FuncTransmitCommand(EnumAAS203Protocol.ADCNF, 0, 0, 0)) {
				if (FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						funcReadADCNonFilter = false;
						//gFuncShowMessage("Error...", "Error Reading ADC Non Filter Data.", EnumMessageType.Information)
						gobjMessageAdapter.ShowMessage(constADCNonFilter);
						Application.DoEvents();
					} else {
						intAvgInMv = bytArray(2) + (bytArray(3) * 256);
						////----- Added by Sachin Dokhale for Demo mode
						//#If DEMO Then
						//	i= pmtAd()+random(10);
						//#End If
						//If gstructSettings.AppMode = EnumAppMode.DemoMode Then
						if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
							intAvgInMv = funcpmtAd() + bytRandom.Next(10);
						}
						////-----
						funcReadADCNonFilter = true;
					}
				} else {
					funcReadADCNonFilter = false;
					//gFuncShowMessage("Error...", "Error Reading ADC Non Filter Data.", EnumMessageType.Information)
					gobjMessageAdapter.ShowMessage(constADCNonFilter);
					Application.DoEvents();
				}
			} else {
				funcReadADCNonFilter = false;
				//gFuncShowMessage("Error...", "Error Reading ADC Non Filter Data.", EnumMessageType.Information)
				//gobjMessageAdapter.ShowMessage(constADCNonFilter)
				//Application.DoEvents()
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
			return false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//objWait.Dispose()
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcResetInstrument()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcResetInstrument
		//Description            :   To Reset the Instrument
		//Parameters             :   none
		//Return                 :   True if success
		//Time/Date              :   24/9/06
		//Dependencies           :   COM Port must be opened
		//Author                 :   Rahul B.
		//Revision               :   
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];

		try {
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			mobjCommdll.IsNeedReceive = false;
			if (FuncTransmitCommand(EnumAAS203Protocol.RESET, 0, 0, 0)) {
				if (FuncReceiveData(bytArray, CONST_DELAY)) {
					return true;
				} else {
					return false;
				}
			} else {
				return false;
			}

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
			objWait.Dispose();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcAll_Lamp_Off()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcAll_Lamp_Off
		//Description            :   To set all lamps to off position (global.c All_Lamp_Off)
		//Parameters             :   None
		//Return                 :   True if success
		//Time/Date              :   27/9/06
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Deepak B. on 20.11.06
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];

		try {
			// gblnInComm = True          '10.12.07
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			//Send command for All lamp off HCLOFF(7)
			if (FuncTransmitCommand(EnumAAS203Protocol.HCLOFF, 0, 0, 0)) {
				if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						funcAll_Lamp_Off = false;
						gobjMessageAdapter.ShowMessage(constAllLampOff);
						Application.DoEvents();
					} else {
						funcAll_Lamp_Off = true;
					}
				//timeout
				} else {
					funcAll_Lamp_Off = false;
					gobjMessageAdapter.ShowMessage(constAllLampOff);
					Application.DoEvents();
				}
			} else {
				funcAll_Lamp_Off = false;
				//gobjMessageAdapter.ShowMessage(constAllLampOff)
				//Application.DoEvents()
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
			return false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			objWait.Dispose();
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcSet_PMT(double dblPMT)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcSet_PMT
		//Description            :   To set PMT voltage
		//Parameters             :   dblPMT : pmt voltage to be set
		//Return                 :   True if success
		//Time/Date              :   27/9/06
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Deepak B. on 17.11.06 for some modifications
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];
		double dbly1;
		int inty;
		byte bytLow;
		byte bytHigh;
		int intPMT;
		//++++++++++++++++++++++++++++++++++++++++++++++
		//void	S4FUNC Set_PMT(double pmt) 
		//{
		//double	y1;
		//int	y;

		// Inst.Pmtv = pmt;
		// y1 = (double) ( (double) Inst.Pmtv*(double)4095.0/(double)1000.0);
		// y = (int) y1;
		// y = y & 0x0fff;
		// Transmit(PMT, (BYTE) y, (BYTE) (y>>8), 0);
		// pc_delay(1000);
		// Recev(TRUE);
		//}
		//++++++++++++++++++++++++++++++++++++++++++++++
		double dblPMTTemp;

		try {
			//If gblnInComm = True Then
			//    Return False
			//End If

			// gblnInComm = True          '10.12.07
			//If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
			//    Return False
			//End If
			//gobjInst.PmtVoltage = dblPMT       '10.12.07
			//dbly1 = gobjInst.PmtVoltage * 4095.0 / 1000.0
			//inty = CInt(dbly1)
			//inty = inty And &HFFF

			dblPMTTemp = dblPMT;
			dblPMTTemp = dblPMTTemp * 4095.0 / 1000.0;
			intPMT = (int)dblPMTTemp;
			intPMT = (int)intPMT & 0xfff;
			// Convert integer value of PMT into High byte and low byte
			gFunclongtobyte(intPMT, bytLow, bytHigh);

			//bytLow = CByte(inty)
			//bytHigh = CByte(inty >> 8)
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			//Send command to set PMT(4) with param low byte and high byte
			if (FuncTransmitCommand(EnumAAS203Protocol.PMT, bytLow, bytHigh, 0)) {
				if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
					//if byte array(1) is one then PMT is set properly
					if (bytArray(1) != 1) {
						funcSet_PMT = false;
						gobjMessageAdapter.ShowMessage(constPMTVolt);
						Application.DoEvents();
					} else {
						gobjInst.PmtVoltage = dblPMT;
						//10.12.07
						funcSet_PMT = true;
					}
				} else {
					funcSet_PMT = false;
					gobjMessageAdapter.ShowMessage(constPMTVolt);
					Application.DoEvents();
				}
			} else {
				funcSet_PMT = false;
				//gobjMessageAdapter.ShowMessage(constPMTVolt)
				//Application.DoEvents()
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
			objWait.Dispose();
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcSet_PMT_Bit(int intPMT)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcSet_PMT_Bit
		//Description            :   To set pmt
		//Parameters             :   intPMT : 
		//Return                 :   True if success
		//Time/Date              :   3/10/06
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Deepak B. on 17.11.06
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];
		double dblPMTTemp;
		byte bytLow;
		byte bytHigh;
		//------------------------------------------------
		//        void    S4FUNC  Set_PMT_Bit(int y)
		//{

		// if (y>=0) {
		//  Transmit(PMT, (BYTE) (y), (BYTE) (y>>8), 0);
		//  pc_delay(1000);
		//  Recev(TRUE);
		//  Inst.Pmtv = ((double)y*(double)1000.0/(double)4095.0);
		// }
		//}
		//------------------------------------------------
		try {
			//If gblnInComm = True Then
			//    Return False
			//End If
			// gblnInComm = True          '10.12.07

			// Convert integer value of PMT into High byte and low byte
			if (intPMT >= 0) {
				gFunclongtobyte(intPMT, bytLow, bytHigh);
			}

			//bytLow = CByte(intPMT And &HFF)
			//bytHigh = CByte(intPMT >> 8)

			if (intPMT > 0) {
				//10.12.07
				if (mobjCommdll.gFuncResumeProcess == false) {
					return false;
				}
				//Send command to set PMT(4) with param low byte and high byte
				if (FuncTransmitCommand(EnumAAS203Protocol.PMT, bytLow, bytHigh, 0)) {
					if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
						if (bytArray(1) != 1) {
							funcSet_PMT_Bit = false;
							gobjMessageAdapter.ShowMessage(constPMTBit);
							Application.DoEvents();
						} else {
							//if byte array(1) is one then PMT is set Inst object of PmtVoltage 
							gobjInst.PmtVoltage = ((double)intPMT * (double)1000.0 / (double)4095.0);
							funcSet_PMT_Bit = true;
						}
					} else {
						funcSet_PMT_Bit = false;
						gobjMessageAdapter.ShowMessage(constPMTBit);
						Application.DoEvents();
					}
				} else {
					funcSet_PMT_Bit = false;
					//gobjMessageAdapter.ShowMessage(constPMTBit)
					//Application.DoEvents()
				}
			}

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
			objWait.Dispose();
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcSet_PMT_Ref_Bit(int intPMT)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcSet_PMT_Bit
		//Description            :   To set pmt
		//Parameters             :   intPMT : 
		//Return                 :   True if success
		//Time/Date              :   3/10/06
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Deepak B. on 17.11.06
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];
		double dblPMTTemp;
		byte bytLow;
		byte bytHigh;
		//------------------------------------------------
		//        void    S4FUNC  Set_PMT_Bit(int y)
		//{

		// if (y>=0) {
		//  Transmit(PMT, (BYTE) (y), (BYTE) (y>>8), 0);
		//  pc_delay(1000);
		//  Recev(TRUE);
		//  Inst.Pmtv = ((double)y*(double)1000.0/(double)4095.0);
		// }
		//}
		//------------------------------------------------
		try {
			//If ' gblnInComm = True          '10.12.07 Then
			//    Return False
			//End If
			gblnInComm = true;
			// Convert integer value of PMT into High byte and low byte
			if (intPMT >= 0) {
				gFunclongtobyte(intPMT, bytLow, bytHigh);
			}

			//bytLow = CByte(intPMT And &HFF)
			//bytHigh = CByte(intPMT >> 8)
			//Send command to set Ref. beam PMT(4) with param low byte and high byte
			if (intPMT > 0) {
				//10.12.07
				if (mobjCommdll.gFuncResumeProcess == false) {
					return false;
				}
				if (FuncTransmitCommand(EnumAAS203Protocol.SETPMT_RB, bytLow, bytHigh, 0)) {
					if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
						if (bytArray(1) != 1) {
							funcSet_PMT_Ref_Bit = false;
							gobjMessageAdapter.ShowMessage(constPMTBit);
							Application.DoEvents();
						} else {
							//if byte array(1) is one then PMT is set Inst object of PmtVoltage 
							gobjInst.PmtVoltageReference = ((double)intPMT * (double)1000.0 / (double)4095.0);
							funcSet_PMT_Ref_Bit = true;
						}
					} else {
						funcSet_PMT_Ref_Bit = false;
						gobjMessageAdapter.ShowMessage(constPMTBit);
						Application.DoEvents();
					}
				} else {
					funcSet_PMT_Ref_Bit = false;
					//gobjMessageAdapter.ShowMessage(constPMTBit)
					//Application.DoEvents()
				}
			}

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
			objWait.Dispose();
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcSetBH_HOME()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcSetBH_HOME
		//Description            :   To set burner to home position
		//Parameters             :   None
		//Return                 :   True if success
		//Time/Date              :   27/9/06
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];

		//        BOOL  S4FUNC BH_HOME()
		//{
		//unsigned oldt;

		// if (GetInstrument()==AA202)
		//	return TRUE;

		// oldt=Tout;
		// Tout=LONG_DEALY;
		// hold = Load_Curs();
		// Transmit(BHHOME, 0,0, 0);
		// if (Recev(TRUE)){
		//                If (!Param1) Then
		//	  Gerror_message(" ***PNEMATICS ERROR*** \n Error encountered while \n initialising Burner Up/Dn assembly");
		//  }
		// SetCursor(hold);
		// Tout=oldt;
		// return Param1;
		//}

		try {
			//If gblnInComm = True Then
			//    Return False
			//End If
			// gblnInComm = True          '10.12.07
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			//Send command to set Burner height home BHHOME(24) with param 0
			if (FuncTransmitCommand(EnumAAS203Protocol.BHHOME, 0, 0, 0)) {
				if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						funcSetBH_HOME = false;
						gobjMessageAdapter.ShowMessage(constBHHome);
						Application.DoEvents();
					} else {
						if (bytArray(2) == 0) {
							gobjMessageAdapter.ShowMessage(constBHHome);
						} else {
							funcSetBH_HOME = true;
						}
					}
				} else {
					funcSetBH_HOME = false;
					gobjMessageAdapter.ShowMessage(constBHHome);
					Application.DoEvents();
				}
			} else {
				funcSetBH_HOME = false;
				//gobjMessageAdapter.ShowMessage(constBHHome)
				//Application.DoEvents()
			}

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
			objWait.Dispose();
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcSetNV_HOME()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcSetNV_HOME
		//Description            :   To set NV home position       
		//Parameters             :   None
		//Return                 :   True if success
		//Time/Date              :   27/9/06
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];

		try {
			//If gblnInComm = True Then
			//    Return False
			//End If

			// gblnInComm = True          '10.12.07
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}

			//Send command to set needle valve home NVHOME(23) with param  low byte and high byte is 0
			if (FuncTransmitCommand(EnumAAS203Protocol.NVHOME, 0, 0, 0)) {
				if (FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						funcSetNV_HOME = false;
						gobjMessageAdapter.ShowMessage(constNVHome);
						Application.DoEvents();
					} else {
						// show message when NV HOme set
						if (bytArray(2) == 0) {
							gobjMessageAdapter.ShowMessage(constNVHome);
						} else {
							// Get NV Position from  instrument if byte array(2) is not 0
							if (funcGet_NV_Pos() == true) {
								funcSetNV_HOME = true;
							}
						}
					}
				} else {
					funcSetNV_HOME = false;
					gobjMessageAdapter.ShowMessage(constNVHome);
					Application.DoEvents();
				}
			} else {
				funcSetNV_HOME = false;
				//gobjMessageAdapter.ShowMessage(constNVHome)
				//Application.DoEvents()
			}

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
			objWait.Dispose();
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcGain10X_OFF()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcGain10X_OFF
		//Description            :   to set Gain10x off 
		//Parameters             :   None
		//Retrun                 :   True if success
		//Time/Date              :   27/9/06
		//Dependencies           :   obviously PC must communicate with Instrument through COM port
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];

		try {
			//If gblnInComm = True Then
			//    Return False
			//End If
			// gblnInComm = True          '10.12.07

			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				return true;
			}
			//if D2 Gain flag is seted in INI Setting
			if (gstructSettings.D2Gain == true) {
				//10.12.07
				if (mobjCommdll.gFuncResumeProcess == false) {
					return false;
				}
				//Send command to set GAINX10_OFF(57) with 0
				if (FuncTransmitCommand(EnumAAS203Protocol.GAINX10_OFF, 0, 0, 0)) {
					if (FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY)) {
						if (bytArray(1) != 1) {
							funcGain10X_OFF = false;
							//gFuncShowMessage("Error...", "Error setting Gain10X OFF .", EnumMessageType.Information)
							gobjMessageAdapter.ShowMessage(constGain10XOFF);
							Application.DoEvents();
						} else {
							mintSSGain = 0x0;
							funcGain10X_OFF = true;
						}
					} else {
						funcGain10X_OFF = false;
						//gFuncShowMessage("Error...", "Error setting Gain10X OFF .", EnumMessageType.Information)
						gobjMessageAdapter.ShowMessage(constGain10XOFF);
						Application.DoEvents();
					}
				} else {
					funcGain10X_OFF = false;
					//gFuncShowMessage("Error...", "Error setting Gain10X OFF .", EnumMessageType.Information)
					//gobjMessageAdapter.ShowMessage(constGain10XOFF)
					//Application.DoEvents()
				}
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
			return false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			objWait.Dispose();
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcGain10X_ON()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcGain10X_ON
		//Description            :   to set Gain10x on 
		//Parameters             :   None
		//Return                 :   True if success
		//Time/Date              :   19.12.06
		//Dependencies           :   obviously PC must communicate with Instrument through COM port
		//Author                 :   Sachin Dokhale
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];

		try {
			//If gblnInComm = True Then
			//    Return False
			//End If
			// gblnInComm = True          '10.12.07

			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				return true;
			}
			//if D2 Gain flag is seted in INI Setting
			if (gstructSettings.D2Gain == true) {
				//10.12.07
				if (mobjCommdll.gFuncResumeProcess == false) {
					return false;
				}
				//Send command to set GAINX10_ON(56) with param is 0
				if (FuncTransmitCommand(EnumAAS203Protocol.GAINX10_ON, 0, 0, 0)) {
					if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
						if (bytArray(1) != 1) {
							funcGain10X_ON = false;
							gobjMessageAdapter.ShowMessage(constGain10XOFF);
							Application.DoEvents();
						} else {
							mintSSGain = 0x1;
							funcGain10X_ON = true;
						}
					} else {
						funcGain10X_ON = false;
						gobjMessageAdapter.ShowMessage(constGain10XOFF);
						Application.DoEvents();
					}
				} else {
					funcGain10X_ON = false;
					//gFuncShowMessage("Error...", "Error setting Gain10X OFF .", EnumMessageType.Information)
					//gobjMessageAdapter.ShowMessage(constGain10XOFF)
					//Application.DoEvents()
				}
			}

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
			objWait.Dispose();
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcSetMICRO_OFF()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcSetMICRO_OFF
		//Description            :   To set MICRO OFF
		//Parameters             :   None
		//Return                 :   True if success
		//Time/Date              :   27/9/06
		//Dependencies           :   obviously PC must communicate with Instrument through COM port
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];

		try {
			//If gblnInComm = True Then
			//    Return False
			//End If

			// gblnInComm = True          '10.12.07

			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				return true;
			}
			//if Mesh flag is seted in INI Setting
			if (gstructSettings.Mesh == true) {
				//10.12.07
				if (mobjCommdll.gFuncResumeProcess == false) {
					return false;
				}
				//Send command to set MICROOFF(55) with 0
				if (FuncTransmitCommand(EnumAAS203Protocol.MICROOFF, 0, 0, 0)) {
					if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
						if (bytArray(1) != 1) {
							funcSetMICRO_OFF = false;
							gobjMessageAdapter.ShowMessage(constMicroOFF);
							Application.DoEvents();
						} else {
							funcSetMICRO_OFF = true;
						}
					} else {
						funcSetMICRO_OFF = false;
						gobjMessageAdapter.ShowMessage(constMicroOFF);
						Application.DoEvents();
					}
				} else {
					funcSetMICRO_OFF = false;
					//gobjMessageAdapter.ShowMessage(constMicroOFF)
					//Application.DoEvents()
				}
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
			return false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			objWait.Dispose();
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcSetMICRO_ON()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcSetMICRO_ON
		//Description            :   To set MICRO ON
		//Parameters             :   None
		//Retrun                 :   True if success
		//Time/Date              :   03/01/07
		//Dependencies           :   obviously PC must communicate with Instrument through COM port
		//Author                 :   Sachin Dokhale.
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];

		try {
			//If gblnInComm = True Then
			//    Return False
			//End If
			// gblnInComm = True          '10.12.07

			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				return true;
			}
			//if Mesh  flag is seted in INI Setting
			if (gstructSettings.Mesh == true) {
				//10.12.07
				if (mobjCommdll.gFuncResumeProcess == false) {
					return false;
				}
				//Send command to set MICROON(54) with 0
				if (FuncTransmitCommand(EnumAAS203Protocol.MICROON, 0, 0, 0)) {
					if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
						if (bytArray(1) != 1) {
							funcSetMICRO_ON = false;
							//gFuncShowMessage("Error...", "Error setting MICRO OFF .", EnumMessageType.Information)
							gobjMessageAdapter.ShowMessage(constMicroON);
							Application.DoEvents();
						} else {
							funcSetMICRO_ON = true;
						}
					} else {
						funcSetMICRO_ON = false;
						//gFuncShowMessage("Error...", "Error setting MICRO OFF .", EnumMessageType.Information)
						gobjMessageAdapter.ShowMessage(constMicroON);
						Application.DoEvents();
					}
				} else {
					funcSetMICRO_ON = false;
					//gFuncShowMessage("Error...", "Error setting MICRO OFF .", EnumMessageType.Information)
					//gobjMessageAdapter.ShowMessage(constMicroON)
					//Application.DoEvents()
				}
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
			return false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			objWait.Dispose();
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcAir_OFF()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcAir_OFF
		//Description            :   To set AIR off
		//Parameters             :   None
		//Return                 :   True if success
		//Time/Date              :   29/9/06
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];

		try {
			//If gblnInComm = True Then
			//    Return False
			//End If
			// Before Air off make flame off first
			funcFlame_OFF();

			// gblnInComm = True          '10.12.07
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			//Send command to set AIR OFF(30) with 0
			if (FuncTransmitCommand(EnumAAS203Protocol.AIROFF, 0, 0, 0)) {
				if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						funcAir_OFF = false;
						gobjMessageAdapter.ShowMessage(constAirOFF);
						Application.DoEvents();
					} else {
						//if Array of byte(1) is 1 then function return true for air gets off
						funcAir_OFF = true;
					}

				} else {
					funcAir_OFF = false;
					gobjMessageAdapter.ShowMessage(constAirOFF);
					Application.DoEvents();
				}
			} else {
				funcAir_OFF = false;
				//gobjMessageAdapter.ShowMessage(constAirOFF)
				//Application.DoEvents()
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
			return false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			objWait.Dispose();
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcAir_ON()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcAir_ON
		//Description            :   To set AIR on
		//Parameters             :   None
		//Return                 :   True if success
		//Time/Date              :   29/9/06
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		//Dim objWait As New CWaitCursor
		byte[] bytArray = new byte[6];

		try {
			//If gblnInComm = True Then
			//    Return False
			//End If
			// gblnInComm = True          '10.12.07
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			//Send command to set AIR OFF(30) with 0
			if (FuncTransmitCommand(EnumAAS203Protocol.AIRON, 0, 0, 0)) {
				if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						funcAir_ON = false;
						gobjMessageAdapter.ShowMessage(constAirOn);
						Application.DoEvents();
					} else {
						//if Array of byte(1) is 1 then function return true for air gets On
						funcAir_ON = true;
					}
				} else {
					funcAir_ON = false;
					// Show error is "Error setting Air ON."
					gobjMessageAdapter.ShowMessage(constAirOn);
					Application.DoEvents();
				}
			} else {
				funcAir_ON = false;
				// Show error is "Error setting Air ON."
				//gobjMessageAdapter.ShowMessage(constAirOn)
				//Application.DoEvents()
			}

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
			//objWait.Dispose()
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcFlame_OFF()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcFlame_OFF
		//Description            :   To set Flame off
		//Parameters             :   None
		//Return                 :   True if success
		//Time/Date              :   25/9/06
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];

		//BOOL	S4FUNC Flame_Off()
		//{
		//        If (Inst.N2of) Then
		//	Inst.N2of = N2_FLAME_OFF();
		//        ElseIf (Inst.Aaf) Then
		//	 Inst.Aaf = AA_FLAME_OFF();
		//        Else
		//	return FALSE;
		// return TRUE;
		//}

		try {
			// Make the flame off any N2o or AA flame 
			// as per checking setting from Inst object
			if (gobjInst.N2of == true) {
				if (func_N2_FLAME_OFF() == false) {
					gobjInst.N2of = false;
				}
			} else if (gobjInst.Aaf == true) {
				if (func_AA_FLAME_OFF() == true) {
					gobjInst.Aaf = false;
				}
			} else {
				return false;
			}

			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
			return false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			objWait.Dispose();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcStartSpectrum(double dblWv, int intSpeed)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcStartSpectrum
		//Description            :   to Start Spectrum .
		//Parameters             :   dblWv as Destination Wv., intSpeed is speed of Scan    
		//Retrun                 :   True if success
		//Time/Date              :   26/9/06
		//Dependencies           :   obviously PC must communicate with Instrument through COM port
		//Author                 :   Sachin Dokhale
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];
		byte bytLow;
		byte bytHigh;
		byte bytSpeed;
		int intWv;


		try {
			// gblnInComm = True          '10.12.07

			//Convert Wv. parameter into Low Byte and High byte 
			intWv = (int)dblWv;
			bytLow = (byte)intWv & 0xff;
			//bytLow = CByte(dblWv)
			bytHigh = (byte)dblWv >> 8;

			//Convert speed parameter into third byte parameter 
			bytSpeed = (byte)intSpeed;
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}

			//Send the command for Sectrum SPECT(48) with param low byte and high byte is Wv. to be achive 
			//and third param is the speed of process of spectrum
			//Transmit(SPECT, (BYTE)(j), (BYTE) (j>>8), (BYTE) speed);
			mobjCommdll.IsNeedReceive = false;
			if (FuncTransmitCommand(EnumAAS203Protocol.SPECT, bytLow, bytHigh, bytSpeed)) {
				//If FuncTransmitCommand(EnumAAS203Protocol.SPECTRUM_RB, bytLow, bytHigh, bytSpeed) Then

				clsRS232Main.gblnInCommProcess = false;
				funcStartSpectrum = true;
			} else {
				funcStartSpectrum = false;
				// on Error of command show message is "Error Reading ADC Filter Data."
				//gobjMessageAdapter.ShowMessage(constErrorSpectrum)
				//Application.DoEvents()
			}

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
			objWait.Dispose();
			Application.DoEvents();
			//gblnInComm = False
			//---------------------------------------------------------
		}
	}

	public bool funcStartSpectrum_ReferenceBeam(double dblWv, int intSpeed)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcStartSpectrum_ReferenceBeam
		//Description            :   to Start Spectrum for Reference Beam.
		//Parameters             :   param: dblWv is the achiving Wv. param: intSpeed is Speed of spectrum
		//                           return True if process run successful and without exception
		//Time/Date              :   07.04.07
		//Dependencies           :   obviously PC must communicate with Instrument through COM port
		//Author                 :   Sachin Dokhale
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		//Dim objWait As New CWaitCursor
		byte[] bytArray = new byte[6];
		byte bytLow;
		byte bytHigh;
		byte bytSpeed;
		int intWv;

		try {
			// gblnInComm = True          '10.12.07

			//Convert Wv. parameter into Low Byte and High byte 
			intWv = (int)dblWv;
			bytLow = (byte)intWv & 0xff;
			bytHigh = (byte)dblWv >> 8;

			//Convert speed parameter into third byte parameter 
			bytSpeed = (byte)intSpeed;
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			//Send the command for Sectrum SPECT(48) with param low byte and high byte is Wv. to be achive 
			//and third param is the speed of process of spectrum
			//Transmit(SPECT, (BYTE)(j), (BYTE) (j>>8), (BYTE) speed);
			mobjCommdll.IsNeedReceive = false;
			if (FuncTransmitCommand(EnumAAS203Protocol.SPECTRUM_RB, bytLow, bytHigh, bytSpeed)) {
				//    If FuncTransmitCommand(EnumAAS203Protocol.SPECT, bytLow, bytHigh, bytSpeed) Then
				clsRS232Main.gblnInCommProcess = false;
				funcStartSpectrum_ReferenceBeam = true;
			} else {
				funcStartSpectrum_ReferenceBeam = false;
				// on Error of command show message is "Error Reading ADC Filter Data."
				//gobjMessageAdapter.ShowMessage(constErrorSpectrum)
				//Application.DoEvents()
			}

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
			//gblnInComm = False
			//---------------------------------------------------------
		}
	}

	public bool funcBreakSpectrum()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcBreakSpectrum
		//Description            :   to break or stop the Spectrum .
		//Parameters             :   None    
		//Return                 :   True if success
		//Time/Date              :   07/11/06
		//Dependencies           :   obviously PC must communicate with Instrument through COM port
		//Author                 :   Sachin Dokhale
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];
		byte bytLow;
		byte bytHigh;
		byte bytSpeed;
		byte bytLast;

		try {
			// gblnInComm = True          '10.12.07

			//Transmit(SPECT, (BYTE)(j), (BYTE) (j>>8), (BYTE) speed);
			//bytLow = CByte(intNumOfReadingsForAvg)
			//bytHigh = CByte(intNumOfReadingsForAvg >> 8)

			bytLow = 0;
			bytHigh = 0;
			//CByte(dblWv >> 8)
			bytLast = 0;
			//CByte(intSpeed)
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			// Send command to break spectrum SPBREAK(101)
			if (FuncTransmitCommand(EnumAAS203Protocol.SPBREAK, bytLow, bytHigh, bytLast)) {
				funcBreakSpectrum = true;
			} else {
				funcBreakSpectrum = false;
				//gFuncShowMessage("Error...", "Error Reading ADC Filter Data.", EnumMessageType.Information)
				//gobjMessageAdapter.ShowMessage(constErrorSpectrum)
				//Application.DoEvents()
			}
			clsRS232Main.gblnInCommProcess = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
			return false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			objWait.Dispose();
			gblnInComm = false;
			//Application.DoEvents()
			//---------------------------------------------------------
		}
	}

	public bool funcPC_END()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcPC_END
		//Description            :   to PC End.
		//Parameters             :   None
		//Return                 :   true when success
		//Time/Date              :   07/11/06
		//Dependencies           :   obviously PC must communicate with Instrument through COM port
		//Author                 :   Sachin Dokhale
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];
		byte bytLow;
		byte bytHigh;
		byte bytSpeed;
		byte bytLast;

		try {
			// gblnInComm = True          '10.12.07

			//Transmit(SPECT, (BYTE)(j), (BYTE) (j>>8), (BYTE) speed);
			//bytLow = CByte(intNumOfReadingsForAvg)
			//bytHigh = CByte(intNumOfReadingsForAvg >> 8)

			bytLow = 0;
			bytHigh = 0;
			//CByte(dblWv >> 8)
			bytLast = 0;
			//CByte(intSpeed)
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return true;
			}
			// Send command to PC End
			if (FuncTransmitCommand(EnumAAS203Protocol.PC_END, bytLow, bytHigh, bytLast)) {
				funcPC_END = true;
			} else {
				funcPC_END = false;
				//gobjMessageAdapter.ShowMessage(constErrorSpectrum)
				//Application.DoEvents()
			}

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
			objWait.Dispose();
			gblnInComm = false;
			//Application.DoEvents()
			//---------------------------------------------------------
		}
	}

	public bool funcReceive_ScanData(ref int inIndex, ref double dblScanData)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   gFuncReceive_ScanData  
		//Description            :   To receive the data from the Input buffer
		//Parameters             :   Byref intindex,dbldata,intflag and dblLData
		//Retutn                 :   True if success
		//Time/Date              :   12.06 
		//Dependencies           :   
		//Author                 :   Sachin Dokhale 07.11.06
		//Revision               :   
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		funcReceive_ScanData = false;
		bool blnFlag = false;
		byte[] bytArray = new byte[6];

		try {
			//If gblnInComm = True Then
			//    Return True
			//End If

			if (FuncReceiveData(bytArray, CONST_DELAY)) {
				mobjCommdll.IsNeedReceive = false;
				if (bytArray(1) != 1) {
					funcReceive_ScanData = false;
					Application.DoEvents();
				} else {
					dblScanData = bytArray(3) * 256 + bytArray(2);
					funcReceive_ScanData = true;
				}
			} else {
				funcReceive_ScanData = false;
				Application.DoEvents();
			}
			clsRS232Main.gblnInCommProcess = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
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
			objWait.Dispose();
			gblnInComm = false;
			//Application.DoEvents()
			//---------------------------------------------------------
		}
	}

	public bool Wavelength_Position(double wvnew, ref Label lblUVWavelengthStatus = null)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   Wavelength_Position
		//Description            :   To position the wavelength
		//Parameters             :   new wavelength to position
		//Affected Parameter     :   lblUVWavelengthStatus Show label
		//Return                 :   True if success
		//Time/Date              :   08.11.06
		//Dependencies           :   communication
		//Author                 :   Deepak Bhati
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		//void S4FUNC Wavelength_Position(HDC hdc , double wvnew, int x, int y)
		//{
		//#If DEMO Then
		//	MoveTo(hdc, x, y);
		//	wvcur=wvnew;
		//#Else
		//double temp;

		//if (wvnew<=0) Find_Wavelength_Home(hdc, x, y);
		//else if (wvnew<Inst.Wvcur) {
		//	hold = Load_Curs();
		//	temp  = wvnew;
		//	wvnew = wvnew-(double)1.0;
		//	Wav_Pos(hdc,wvnew, x, y);
		//	wvnew = temp;
		//	Wav_Pos(hdc,wvnew, x, y);
		//	SetCursor(hold);
		//  }
		//else{
		//  Wav_Pos(hdc,wvnew, x, y);

		//}
		//#End If
		//}
		CWaitCursor objWait = new CWaitCursor();
		double temp;

		try {
			// check if new Wv. is less than or equel to (<=) 0 then use Wavelength Home position, if not
			// check if New Wv. is less than (<) current Wv. then 
			// for correct Wv tobe achive 
			// first restore the New Wv into temp location 
			// minus one Wv. from new Wv. then position to Wavelength
			// again restore original Wv. and position to Wavelenth.
			// check above condition is not there the simply position to Wavelenth.


			if (wvnew <= 0) {
				gFuncWavelength_Home(lblUVWavelengthStatus);

			} else if (wvnew < gobjInst.WavelengthCur) {
				temp = wvnew;
				wvnew = wvnew - 1.0;

				if (Wav_Pos(wvnew, lblUVWavelengthStatus) == true) {
					wvnew = temp;
					if (Wav_Pos(wvnew, lblUVWavelengthStatus) == false) {
						return false;
					}
				} else {
					return false;
				}
			} else {
				if (Wav_Pos(wvnew, lblUVWavelengthStatus) == false) {
					return false;
				}
			}

			return true;

		//if (wvnew<=0) Find_Wavelength_Home(hdc, x, y);
		//else if (wvnew<Inst.Wvcur) {
		//	hold = Load_Curs();
		//	temp  = wvnew;
		//	wvnew = wvnew-(double)1.0;
		//	Wav_Pos(hdc,wvnew, x, y);
		//	wvnew = temp;
		//	Wav_Pos(hdc,wvnew, x, y);
		//	SetCursor(hold);
		//  }
		//else{
		//  Wav_Pos(hdc,wvnew, x, y);
		//}

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
			objWait.Dispose();
			//Application.DoEvents()
			//---------------------------------------------------------
		}
	}

	//'Public Function GetSRLamp() As Boolean
	//'    Return mintSRLamp
	//'End Function

	//'Public Function SetSRLamp(ByVal intSRLamp As Boolean) As Boolean
	//'    '=====================================================================
	//'    ' Procedure Name        : gfuncSetSRLamp
	//'    ' Parameters Passed     : intSRLamp
	//'    ' Returns               : Boolean
	//'    ' Purpose               : Set the SR Lamp
	//'    ' Description           : 
	//'    ' Assumptions           : 
	//'    ' Dependencies          : 
	//'    ' Author                : Sachin Dokahle
	//'    ' Created               : 25.11.06
	//'    ' Revisions             : 
	//'    '=====================================================================
	//'    Try
	//'        mintSRLamp = intSRLamp

	//'    Catch ex As Exception
	//'        '---------------------------------------------------------
	//'        'Error Handling and logging
	//'        gobjErrorHandler.ErrorDescription = ex.Message
	//'        gobjErrorHandler.ErrorMessage = ex.Message
	//'        gobjErrorHandler.WriteErrorLog(ex)
	//'        Return False
	//'        'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
	//'        '---------------------------------------------------------
	//'    Finally
	//'        '---------------------------------------------------------
	//'        'Writing Execution log
	//'        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//'            gobjErrorHandler.WriteExecutionLog()
	//'        End If
	//'        '---------------------------------------------------------
	//'    End Try
	//'End Function

	public bool D2_OFF()
	{
		//=====================================================================
		// Procedure Name        : D2_OFF
		// Parameters Passed     : None
		// Returns               : True of False 
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh
		// Created               : 
		// Revisions             : By Deepak
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];

		try {
			//If gblnInComm = True Then
			//    Return False
			//End If
			// gblnInComm = True          '10.12.07
			//check SRLamp flag Set SR Lamp
			if (this.SRLamp()) {
				//10.12.07
				if (mobjCommdll.gFuncResumeProcess == false) {
					return false;
				}
				if (FuncTransmitCommand(SMHCLDIS, 0, 0, 0)) {
					if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
						if (bytArray(1) != 1) {
							return false;
						} else {
							return true;
						}
					}
				}
			} else {
				//10.12.07
				if (mobjCommdll.gFuncResumeProcess == false) {
					return false;
				}
				//Send the command for D2 Lamp Off
				if (FuncTransmitCommand(EnumAAS203Protocol.D2OFF, 0, 0, 0)) {
					if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
						if (bytArray(1) != 1) {
							return false;
						} else {
							return true;
						}
					}
				}
			}

		//If mobjCommdll.gFuncReceiveData(bytArray, CONST_LONG_DELAY) Then
		//If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
		//    If bytArray(1) <> 1 Then
		//        Return False
		//    Else
		//        Return True
		//    End If
		//End If

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
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
			objWait.Dispose();
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool D2_ON()
	{
		//=====================================================================
		// Procedure Name        : D2_ON
		// Parameters Passed     : None
		// Returns               : True or False
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh
		// Created               : 
		// Revisions             : By Deepak
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];

		try {
			//If gblnInComm = True Then
			//    Return False
			//End If
			// gblnInComm = True          '10.12.07

			//check SRLamp flag Set SR Lamp
			if (SRLamp()) {
				//
				//    If Inst.Lamp_pos = 0x02 Then
				//    Transmit(SMHCLENB, 1, 0, 0)
				//If mobjCommdll.gFuncTransmitCommand(EnumAAS203Protocol.SMHCLENB, 1, 0, 0) Then
				//End If
				//Else
				//    Transmit(SMHCLENB, 2, 0, 0)
				//If mobjCommdll.gFuncTransmitCommand(EnumAAS203Protocol.SMHCLENB, 2, 0, 0) Then
				//End If
				//End If
				// Require to be check below commands
				if (gobjInst.Lamp_Position == 0x2) {
					//10.12.07
					if (mobjCommdll.gFuncResumeProcess == false) {
						return false;
					}
					if (FuncTransmitCommand(SMHCLENB, 1, 0, 0)) {
						if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
							if (bytArray(1) != 1) {
								return false;
							} else {
								return true;
							}
						}
					}
				} else {
					//10.12.07
					if (mobjCommdll.gFuncResumeProcess == false) {
						return false;
					}
					if (FuncTransmitCommand(SMHCLENB, 2, 0, 0)) {
						if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
							if (bytArray(1) != 1) {
								return false;
							} else {
								return true;
							}
						}
					}
				}
			} else {
				//Send the command for D2 Lamp On
				//'Transmit(D2ON, 0, 0, 0)
				//If mobjCommdll.gFuncTransmitCommand(EnumAAS203Protocol.D2ON, 0, 0, 0) Then
				//10.12.07
				if (mobjCommdll.gFuncResumeProcess == false) {
					return false;
				}
				if (FuncTransmitCommand(EnumAAS203Protocol.D2ON, 0, 0, 0)) {
					if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
						if (bytArray(1) != 1) {
							return false;
						} else {
							return true;
						}
					}
				}
			}

		//If mobjCommdll.gFuncReceiveData(bytArray, CONST_LONG_DELAY) Then

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
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
			objWait.Dispose();
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private bool gFunclongtobyte(long lngparameter, ref byte bytParameter1, ref byte bytParameter2)
	{
		//-----------------------------------  Function Header  -------------------------------
		//Function Name          :   gFunclongtobyte 
		//Description            :   Long to bytes conversion     
		//Parameters             :   lngparameter as long
		//Affected Parameter     :   byte_parameter1 as byte , byte2_parameter2 as byte
		//Return Type		    :   True if success
		//Time/Date              :   17 Oct 2003,10:40 Hrs
		//Dependencies           :   
		//Author                 :   Nilesh Shirode
		//Revision               :   
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		long data = lngparameter;
		long[] multfact = new long[4];
		int i;
		byte[] longtobyte = new byte[3];

		try {
			// Convert long integer into Byte data type
			gFunclongtobyte = false;
			multfact(0) = 0;
			multfact(1) = (Math.Pow(16, 1)) * 15 + 15;
			multfact(2) = (Math.Pow(16, 3)) * 15 + (Math.Pow(16, 2)) * 15;
			multfact(3) = (Math.Pow(16, 5)) * 15 + (Math.Pow(16, 4)) * 15;
			multfact(4) = (Math.Pow(16, 7)) * 15 + (Math.Pow(16, 6)) * 15;
			for (i = 1; i <= 4; i++) {
				longtobyte(i - 1) = (data & multfact(i)) / (multfact(i - 1) + 1);
			}
			bytParameter1 = longtobyte(0);
			bytParameter2 = longtobyte(1);

			gFunclongtobyte = true;

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
			objWait.Dispose();
			//---------------------------------------------------------
		}

	}
	//429

	public bool funcGet_NV_Pos()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   FuncGet_NV_Pos
		//Description            :   To get NV  position       
		//Parameters             :   None
		//Return                 :   True if success
		//Time/Date              :   15.11.06
		//Dependencies           :   
		//Author                 :   Deepak B.
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		//Dim objWait As New CWaitCursor
		byte[] bytArray = new byte[6];
		//----------------------------------------
		//    void	S4FUNC Get_NV_Pos()
		//{
		// if (GetInstrument()==AA202)
		//	return ;

		//  Transmit(GETNV, 0,0, 0);
		//  if (Recev(TRUE))
		//	 Inst.Nvstep = Param2*256+Param1;
		//#If DEMO Then
		//	 Inst.Nvstep = NVpos;
		//#End If

		//}
		//----------------------------------------
		try {
			//If gblnInComm = True Then
			//    Return False
			//End If

			// gblnInComm = True          '10.12.07

			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				return true;
			}
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return true;
			}
			if (FuncTransmitCommand(EnumAAS203Protocol.GETNV, 0, 0, 0)) {
				if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						funcGet_NV_Pos = false;
						gobjMessageAdapter.ShowMessage(constNVHome);
						Application.DoEvents();
					} else {
						//gobjInst.NvStep = (bytArray(3) * 256) + bytArray(2)
						//If gstructSettings.AppMode = EnumAppMode.DemoMode Then
						if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
							gobjInst.NvStep = gintNV_POS;
						} else {
							// Set the needle valve stpes from byte array 
							gobjInst.NvStep = (bytArray(3) * 256) + bytArray(2);
						}
						funcGet_NV_Pos = true;
					}
				} else {
					funcGet_NV_Pos = false;
					gobjMessageAdapter.ShowMessage(constNVHome);
					Application.DoEvents();
				}
			} else {
				funcGet_NV_Pos = false;
				//gobjMessageAdapter.ShowMessage(constNVHome)
				//Application.DoEvents()
			}

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
			//objWait.Dispose()
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool func_BHRotateAntiClock_Steps(int intSteps)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   func_BHRotateAntiClock_Steps
		//Description            :   To Rotate Burner Height Anticlockwise. 
		//Parameters             :   intSteps as integer
		//Return                 :   True if success
		//Time/Date              :   16.11.06
		//Dependencies           :   
		//Author                 :   Deepak B.
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];
		byte bytLow;
		byte bytHigh;
		//    void  BH_RotateAnticlock_Steps(int steps)
		//{
		// unsigned  oldTout;

		//  if (GetInstrument()==AA202)
		//	return ;

		// oldTout=Tout;
		// Tout=VERY_LONG_DEALY;
		// hold = Load_Curs();

		// Transmit(BHANTISTEPS, (BYTE) (steps>>8), (BYTE) (steps), 0);
		// Recev(TRUE); // new addition   1
		// Get_BH_Pos();
		// SetCursor(hold);
		// Tout=oldTout;
		//}
		try {
			//If gblnInComm = True Then
			//    Return False
			//End If
			// gblnInComm = True          '10.12.07
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			gFunclongtobyte(intSteps, bytLow, bytHigh);
			//Send  command for Buener Hight Anti steps high and low byte are the steps 
			if (FuncTransmitCommand(EnumAAS203Protocol.BHANTISTEPS, bytHigh, bytLow, 0)) {
				if (FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						func_BHRotateAntiClock_Steps = false;
						//gobjMessageAdapter.ShowMessage("Error")
						Application.DoEvents();
					} else {
						// get and restore steps of burner hight into Inst object for burner position
						func_Get_BH_Pos();
						gblnInComm = false;
						func_BHRotateAntiClock_Steps = true;
					}
				} else {
					func_BHRotateAntiClock_Steps = false;
					//gobjMessageAdapter.ShowMessage("Error")
					Application.DoEvents();
				}
			} else {
				func_BHRotateAntiClock_Steps = false;
				//gobjMessageAdapter.ShowMessage("Error")
				//Application.DoEvents()
			}

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
			objWait.Dispose();
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool func_BHRotateClock_Steps(int intSteps)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   func_BHRotateClock_Steps
		//Description            :   To Rotate Burner Height Clockwise. 
		//Parameters             :   intSteps into No of Steps
		//Return                 :   if success
		//Time/Date              :   16.11.06
		//Dependencies           :   
		//Author                 :   Deepak B.
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];
		byte bytLow;
		byte bytHigh;

		//    void  BH_RotateClock_Steps(int steps)
		//{
		// unsigned  oldTout;
		//  if (GetInstrument()==AA202)
		//	return ;

		// oldTout=Tout;
		// Tout=VERY_LONG_DEALY;
		// hold = Load_Curs();

		// Transmit(BHCLKSTEPS, (BYTE) (steps>>8), (BYTE) (steps), 0);
		// Recev(TRUE); // new addition   1
		// Get_BH_Pos();
		// SetCursor(hold);
		// Tout=oldTout;
		//}
		try {
			//If gblnInComm = True Then
			//    Return False
			//End If

			// gblnInComm = True          '10.12.07
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			//Send Command EnumBHCLKSTEPS (62), with  parameter High byte and low byte
			gFunclongtobyte(intSteps, bytLow, bytHigh);
			if (FuncTransmitCommand(EnumAAS203Protocol.BHCLKSTEPS, bytHigh, bytLow, 0)) {
				if (FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						func_BHRotateClock_Steps = false;
						//gobjMessageAdapter.ShowMessage("Error")
						Application.DoEvents();
					} else {
						func_Get_BH_Pos();
						gblnInComm = false;
						func_BHRotateClock_Steps = true;
					}
				} else {
					func_BHRotateClock_Steps = false;
					//gobjMessageAdapter.ShowMessage("Error")
					Application.DoEvents();
				}
			} else {
				func_BHRotateClock_Steps = false;
				//gobjMessageAdapter.ShowMessage("Error")
				//Application.DoEvents()
			}

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
			objWait.Dispose();
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcBH_File_read()
	{
		//---------------------- Procedure Header  -------------------------------
		//Procedure Name         :   funcBH_File_read
		//Description            :   To Read the Burner height file.
		//Parameters             :   None
		//Return                 :   True if success
		//Time/Date              :   16.11.06
		//Dependencies           :   
		//Author                 :   Deepak B.
		//Revision               :
		//Revision by Person     :
		//-------------------------------------------------------------------------

		//    void   S4FUNC BH_File_read()
		//{
		//#If !GRAPHITE Then
		//FILE 	*fptr=NULL;

		//  if ((fptr = fopen("burner.pos", "rt")) != NULL){
		//	 fscanf(fptr, "%d\n",&Inst.Bhstep);
		//	}
		//  fclose(fptr);
		// if (Commflag){
		//	if (Inst.Bhstep<=0||Inst.Bhstep>MAXBHHOME)
		//	  BH_HOME();
		//	else{
		//	  SetLastBhPos(Inst.Bhstep);
		//	  Set_BH_Pos();
		//	}
		//	}
		//#End If
		//}

		CWaitCursor objWait = new CWaitCursor();
		//---commented and added following line of code by deepak on 09.07.07
		//Dim file As New System.IO.StreamReader(Application.StartupPath & "\Burner.pos")
		System.IO.StreamReader file = new System.IO.StreamReader(Application.StartupPath + "\\bh.bhp");
		string words = file.ReadToEnd();

		//Saruabh for checking BH file Blank value 11.07.07
		if (Trim(words) == "") {
			gobjInst.BhStep = 0;
		} else {
			gobjInst.BhStep = (int)Trim(words);
		}
		//gobjInst.BhStep = CInt(Trim(words))
		//Saruabh for checking BH file Blank value 11.07.07

		file.Close();


		try {

			if (Graphite == false) {
				if (mobjCommdll.gFuncIsPortOpen == true) {
					if (gobjInst.BhStep <= 0 | gobjInst.BhStep > MAXBHHOME) {
						funcSetBH_HOME();
					} else {
						func_SetLastBhPos(gobjInst.BhStep);
						func_Set_BH_POS();
					}
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
			objWait.Dispose();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool func_SetLastBhPos(int intBHStep)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   func_SetLastBhPos
		//Description            :   To set last bh position
		//Parameters             :   intBHStep as integer
		//Return                 :   True if success
		//Time/Date              :   16.11.06
		//Dependencies           :   
		//Author                 :   Deepak B.
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		//    void  SetLastBhPos( int bhstep )
		//{
		// Get_BH_Pos();
		// if (Inst.Bhstep>bhstep){
		//	 bhstep = Inst.Bhstep-bhstep;
		//	 BH_RotateAnticlock_Steps(bhstep);
		//	}
		//else if (Inst.Bhstep<bhstep){
		//	 bhstep-=Inst.Bhstep;
		//	 BH_RotateClock_Steps(bhstep);
		//  }
		//}
		CWaitCursor objWait = new CWaitCursor();


		try {
			//to get the current burner position
			func_Get_BH_Pos();
			//check if current burner steps are greater then New buer steps then
			// Rotate the burner height steps to the anticlockwise , if not then
			// check if current burner steps are less then New buer steps then
			// Rotate the burner height steps to the clockwise , if not then
			// Rotating steps are only in bt'n  current burner steps and  new steps
			if (gobjInst.BhStep > intBHStep) {
				intBHStep = gobjInst.BhStep - intBHStep;
				func_BHRotateAntiClock_Steps(intBHStep);
			} else if (gobjInst.BhStep < intBHStep) {
				intBHStep = intBHStep - gobjInst.BhStep;
				func_BHRotateClock_Steps(intBHStep);
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
			objWait.Dispose();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool func_Get_BH_Pos()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   func_Get_BH_Pos
		//Description            :   To get bh position
		//Parameters             :   None
		//Return                 :   True if success.
		//Time/Date              :   16.11.06
		//Dependencies           :   
		//Author                 :   Deepak B.
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		//Dim objWait As New CWaitCursor
		byte[] bytArray = new byte[6];
		//Line No.2208
		//    void	S4FUNC Get_BH_Pos()
		//{
		// if (GetInstrument()==AA202)
		//	return ;

		// Transmit(GETBH, 0,0, 0);
		// if (Recev(TRUE))
		//	Inst.Bhstep = Param2*256+Param1;
		//}
		try {
			//If gblnInComm = True Then
			//    Return False
			//End If
			// gblnInComm = True          '10.12.07
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return true;
			}
			// Send the command for to get Burner heitht position GETBH(50). it is in setps
			if (FuncTransmitCommand(EnumAAS203Protocol.GETBH, 0, 0, 0)) {
				if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						func_Get_BH_Pos = false;
						//gobjMessageAdapter.ShowMessage("Error")
						gobjMessageAdapter.ShowMessage(constErrorGettingBurnerHeight);
						Application.DoEvents();
					} else {
						// Restore the stpes into Inst object fro byre array 
						gobjInst.BhStep = (int)bytArray(3) * 256 + bytArray(2);
						func_Get_BH_Pos = true;
					}
				} else {
					func_Get_BH_Pos = false;
					//gobjMessageAdapter.ShowMessage("Error")
					gobjMessageAdapter.ShowMessage(constErrorRecivedBlockBurner);
					Application.DoEvents();
				}
			} else {
				func_Get_BH_Pos = false;
				//gobjMessageAdapter.ShowMessage("Error")
				//gobjMessageAdapter.ShowMessage(constErrorTransmitBlockBurner)
				//Application.DoEvents()
			}


		} catch (Threading.ThreadAbortException threadex) {
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
			//objWait.Dispose()
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool func_Set_BH_POS()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   func_Set_BH_POS
		//Description            :   To set bh position
		//Parameters             :   None
		//Return                 :   True if success
		//Time/Date              :   16.11.06
		//Dependencies           :   
		//Author                 :   Deepak B.
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		//Line No.2219
		//void S4FUNC Set_BH_Pos()
		//{
		// if (GetInstrument()==AA202)
		//	return ;
		// hold = Load_Curs();

		// Transmit(SETBH, (BYTE) Inst.Bhstep,(BYTE) (Inst.Bhstep>>8) , 0);
		//#If NEWHANDSHAKE Then
		// Recev(TRUE);
		//#End If
		// SetCursor(hold);
		//}
		CWaitCursor objWait = new CWaitCursor();
		byte bytLow;
		byte bytHigh;
		byte[] bytArray = new byte[6];

		try {
			//If gblnInComm = True Then
			//    Return False
			//End If
			// gblnInComm = True          '10.12.07
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			gFunclongtobyte(gobjInst.BhStep, bytLow, bytHigh);
			// Send the command for to set Burner heitht position GETBH(52). it is in setps
			if (FuncTransmitCommand(EnumAAS203Protocol.SETBH, bytLow, bytHigh, 0)) {
				if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						func_Set_BH_POS = false;
						//gobjMessageAdapter.ShowMessage("Error")
						gobjMessageAdapter.ShowMessage(constErrorSettingBurnerHeight);
						Application.DoEvents();
					} else {
						func_Set_BH_POS = true;
					}
				} else {
					func_Set_BH_POS = false;
					//gobjMessageAdapter.ShowMessage("Error")
					gobjMessageAdapter.ShowMessage(constErrorRecivedBlockBurner);
					Application.DoEvents();
				}
			} else {
				func_Set_BH_POS = false;
				//gobjMessageAdapter.ShowMessage("Error")
				//gobjMessageAdapter.ShowMessage(constErrorTransmitBlockBurner)
				//Application.DoEvents()
			}

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
			objWait.Dispose();
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool func_SetParameters()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   func_SetParameters
		//Description            :   To set other parameters
		//Parameters             :   None
		//Return                 :   True if success
		//Time/Date              :   16.11.06
		//Dependencies           :   
		//Author                 :   Deepak B.
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		//void	SetParameters(HDC hdc, int x, int y)
		//{
		//int	i;

		// Wprintf(hdc,RLEFT+10, (RTOP+40)+5*20, " Setting up Optimum Parameters .... Wait");
		// BH_File_read();
		// if (!Load_Tuttet_Status()){
		//	for (i=0; i<6; i++)
		//	  if (strcmpi(trim(ltrim(Inst.Lamp_par.lamp[i].elname)),"")!=0)
		//		 break;
		//	if (i==6){
		//                        If (OnLampPlace) Then
		//		 (*OnLampPlace)(NULL); //	  OnLampPlacement(NULL);
		//	  }
		//	else {
		//                            If (OnOptimiseTurPos) Then
		//		(*OnOptimiseTurPos)( NULL, TRUE);//	  Optimize_Turret_Position( NULL, TRUE);
		//	  Save_Tuttet_Status();
		//	 }
		//  }
		// else  {
		//	for (i=0; i<6; i++)
		//	  if (strcmpi(trim(ltrim(Inst.Lamp_par.lamp[i].elname)),"")!=0)
		//		 break;
		//	  Find_Wavelength_Home(hdc, x, y);
		//	  Position_Turret(NULL, i+1, TRUE);
		//	 }
		// D2File_Read();
		//                                        If (ReadIniForD2Gain()) Then
		//	GainX10Off();
		//                                            If (ReadIniForMesh()) Then
		//	 SetMicroOff();
		//}

		CWaitCursor objWait = new CWaitCursor();

		try {
			funcBH_File_read();

			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
			return false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			objWait.Dispose();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool func_N2_FLAME_OFF()
	{
		//------------------------------------------------------------------
		//Procedure Name         :   func_N2_FLAME_OFF
		//Description            :   To set N2 Flame off
		//Parameters             :   None
		//Return                 :   True if successed received byte from communication
		//Time/Date              :   17.11.06
		//Dependencies           :   
		//Author                 :   Deepak B.
		//Revision               :   2
		//Revision by Person     :   Mangesh on 23-Apr-2007
		//------------------------------------------------------------------
		//Dim objWait As New CWaitCursor
		byte[] bytArray = new byte[6];

		//BOOL(N2_FLAME_OFF())
		//{
		//   Transmit(NAOFF, 0,0, 0);
		//   Recev(TRUE);
		//   If (Param1) Then
		//	    Save_NV_Pos();

		//   If (Param1) Then
		//	    return 	OFF;
		//   Else
		//	    return 	ON;
		//}

		try {
			// gblnInComm = True          '10.12.07
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			//Send the command for N2O Flame Off
			if (FuncTransmitCommand(EnumAAS203Protocol.NAOFF, 0, 0, 0)) {
				if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						gobjMessageAdapter.ShowMessage(constErrorFlameOFF);
						return false;
					} else {
						////----- Commented & Added by Sachin Dokhale
						//func_N2_FLAME_OFF = True
						//If (Param1) Then
						//	return 	OFF;
						//Else
						//	return 	ON;

						//If (Param1) Then
						//   Save_NV_Pos();
						//**************************************************************************
						//---Added by Mangesh on 23-Apr-2007
						//**************************************************************************
						// when flame gets off successfully restore the position of Needale Valve.
						if (bytArray(2) == 1) {
							funcSave_NV_Pos();
						}
						//**************************************************************************

						if (bytArray(2) == 1) {
							return false;
						} else {
							return true;
						}

					}

				} else {
					gobjMessageAdapter.ShowMessage(constErrorFlameOFF);
					return false;
				}
			} else {
				//Call gobjMessageAdapter.ShowMessage(constErrorFlameOFF)
				return false;
			}

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
			//objWait.Dispose()
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool func_N2_FLAME_ON()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   func_N2_FLAME_ON
		//Description            :   To set N2 Flame On
		//Parameters             :   None
		//Return                 :   True if successed received byte from communication
		//Time/Date              :   21.12.06
		//Dependencies           :   
		//Author                 :   Sachin Dokhale
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];

		int intnvs;
		bool flag1 = false;
		bool intflag2 = false;
		//-------------------------------------------
		//        BOOL(N2_FLAME_ON())
		//{
		////		NA BURNER NOT CONNECTED   	09
		////    N2O PRESSURE ERROR	  		10
		//unsigned oldTout;
		//HWND	hwnd;
		//HDC	hdc;
		//int 	nvs;//, i;
		//BOOL flag1= FALSE;
		//int  flag2=0;

		// if (GetInstrument()==AA202)
		//  return TRUE;
		// if (Ignite_Test()!=GREEN)
		//	 return FALSE;
		// if(InstType == AA202)
		//	 hwnd = Create_Window(NULL, 250, 100, "AA-202  NA FLAME");
		//                Else
		//	 hwnd = Create_Window(NULL, 250, 100, "AA-203  NA FLAME");
		// hdc=GetDC(hwnd);
		// Wprintf(hdc, 21, 19, "Setting NA Flame ....");
		// Get_NV_Pos();
		// if (Inst.Nvstep>5000){
		//  NV_HOME();
		//  Get_NV_Pos();
		// }
		// if (Inst.Nvstep<NVRED || Inst.Nvstep> ((int ) (1.5* (double) (NVRED))) )  {
		//	Wprintf(hdc, 21, 20, " Setting Fuel Please  Wait ....");
		//                            If (Inst.Nvstep < NVRED) Then
		//	  NV_RotateAnticlock_Steps(abs(NVRED-Inst.Nvstep));
		//                            Else
		//	  NV_RotateClock_Steps(abs(NVRED-Inst.Nvstep));
		//  }
		// Wprintf(hdc, 21, 20, "        NA IGNITION                       ");
		// Transmit(NAON, 0,0, 0);
		// oldTout=Tout;
		// Tout=VERY_LONG_DEALY; //200;
		// Recev(TRUE);
		// Tout=oldTout;
		// Beep();Beep();
		// switch(Param1)  {
		//	case 1 : Gerror_message(" NAFLAME ERROR \n NA BURNER NOT CONNECTED "); break;
		//	case 2 : Gerror_message(" NAFLAME ERROR \n FILL WATER IN TRAP AND RETRY "); break;
		//	case 3 : Gerror_message(" NAFLAME ERROR \n DOOR NOT CLOSED "); break;
		//	case 4 : Gerror_message(" NAFLAME ERROR \n AIR PRESSURE LOW "); break;
		//	case 5 : Gerror_message(" NAFLAME ERROR \n FUEL PRESSURE LOW  "); break;
		//	case 6 : Gerror_message(" NAFLAME ERROR \n AUTO IGNITION ERROR "); break;
		//	case 7 : if(!HydrideMode)
		//					Gerror_message(" NAFLAME ERROR \n YELLOW FLAME NOT OBTAINABLE ");
		//				else{
		//					flag1 = TRUE;
		//				}
		//	break;
		//	case 8 : if(!HydrideMode)
		//					Gerror_message(" NAFLAME ERROR \n BLUE FLAME NOT OBTAINABLE ");
		//				else{
		//					flag1 = TRUE;
		//				}
		//	break;
		//	case 9:  Gerror_message(" NAFLAME ERROR \n NA BURNER NOT CONNECTED  "); break;
		//	case 10: Gerror_message(" NAFLAME ERROR \n N2O PRESSURE LOW "); break;
		//	case 11: Gerror_message(" NAFLAME ERROR \n Error while setting max. fuel ");
		//				break;
		//	case 0 : Wprintf(hdc, 21, 19, " NA  FLAME SET ......");
		//				flag1 = TRUE; break;
		//  }
		// nvs = Load_NV_Pos();
		// Get_NV_Pos();
		//                                        If (flag1) Then
		//		flag2=TRUE;
		// if(flag2){
		//	 switch(CheckNvBurFiles()){
		//		case 1:if(MessageBox(hwnd,"Do you want to load the last optimised fuel conditions from the method?","Optimisation",MB_ICONQUESTION | MB_YESNO) == IDNO )
		//					 flag2 = FALSE;
		//		break;
		//		case 2:if(MessageBox(hwnd,"Do you want to load the last optimised burner position from the method?","Optimisation",MB_ICONQUESTION | MB_YESNO) == IDNO )
		//					 flag2 = FALSE;
		//		break;
		//		case 3:if(MessageBox(hwnd,"Do you want to load the last optimised fuel condition and burner position from the method?","Optimisation",MB_ICONQUESTION | MB_YESNO) == IDNO )
		//					 flag2 = FALSE;
		//		break;
		//	 }
		// }
		// if (flag2){
		//	 Wprintf(hdc, 21, 20, " Setting Last conditions   .......       ");
		//	 pc_delay(10000);    pc_delay(10000);    pc_delay(10000);
		////---------added by sss for setting last bh conditions on dt 23/11/2000--------
		//#If !GRAPHITE Then
		//	 if(Load_BH_Pos()!=-1){
		//		 if (Commflag){
		//			if (Inst.Bhstep<=0||Inst.Bhstep>MAXBHHOME)
		//			  BH_HOME();
		//			else
		//			  SetLastBhPos(Inst.Bhstep);
		//		 }
		//	 }
		//#End If
		////---------------end of set bh logic---------

		// if (flag2&& nvs<3.0*NVRED){
		//	Wprintf(hdc, 21, 20, " Setting Last conditions   ........     ");
		//	SetLastFuel(nvs);
		//  }
		// }
		// ReleaseDC(hwnd, hdc);
		// Close_Window(hwnd, NULL);
		// return flag1;
		//}
		//-------------------------------------------
		try {
			// if (GetInstrument()==AA202)
			//  return TRUE;
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
				return true;
			}

			// if (Ignite_Test()!=GREEN)
			//	 return FALSE;
			// check the Ignition status of instrument if it is not green then return false

			//--- Modified function of funcIgnite_Test by Sachin Dokhale on 04.02.07
			//If Not (gobjClsAAS203.funcIgnite_Test() = ClsAAS203.enumIgniteType.Green) Then
			//    Return False
			//End If
			ClsAAS203.enumIgniteType intIgnite_Test;
			//--- 22.02.08
			gobjCommProtocol.mobjCommdll.subTime_Delay(100);
			//---
			if (gobjClsAAS203.funcIgnite_Test(intIgnite_Test)) {
				if (!(intIgnite_Test == ClsAAS203.enumIgniteType.Green)) {
					return false;
				}
			}
			Application.DoEvents();
			//---
			//Call gobjMessageAdapter.ShowMessage("N2o First", "N2o First", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)  '22.02.08
			//Application.DoEvents()

			string strNAFlameMessageCaption;
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_203 | gstructSettings.AppMode == EnumAppMode.DemoMode) {
				//---21.07.09
				if (gstructSettings.NewModelName == false) {
					strNAFlameMessageCaption = "AA-203  NA FLAME";
				} else {
					strNAFlameMessageCaption = "AA-303  NA FLAME";
				}
			} else if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D | gstructSettings.AppMode == EnumAppMode.DemoMode_203D) {
				//---21.07.09
				if (gstructSettings.NewModelName == false) {
					strNAFlameMessageCaption = "AA-203D  NA FLAME";
				} else {
					strNAFlameMessageCaption = "AA-303D  NA FLAME";
				}
			}

			//gobjMessageAdapter.
			//hwnd = Create_Window(NULL, 250, 100, "AA-203  NA FLAME");
			//hdc=GetDC(hwnd);
			//Wprintf(hdc, 21, 19, "Setting NA Flame ....");
			//show the message status of NV Flame "Setting NV Flame "

			gobjMessageAdapter.ShowStatusMessageBox("Setting NV Flame .....", strNAFlameMessageCaption, MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 1000, true);
			Application.DoEvents();
			// Get the NV position from instrument to Inst object
			funcGet_NV_Pos();
			//// BH_HOME();  // set bur home

			//check NV steps if steps are grater then 5000
			//Set NV steps to home position and get current NV position
			if ((gobjInst.NvStep > 5000)) {
				funcSetNV_HOME();
				funcGet_NV_Pos();
			}


			////----
			// validate NV steps and set NV Position
			if (((gobjInst.NvStep < NVRED) | gobjInst.NvStep > (int)1.5 * NVRED)) {
				//Wprintf(hdc, 21, 20, " Setting Fuel Please  Wait ....");
				gobjMessageAdapter.UpdateStatusMessageBox("Setting Fuel Please  Wait ....", strNAFlameMessageCaption);

				if ((gobjInst.NvStep < NVRED)) {
					funcNV_RotateAntiClock_Steps(Math.Abs(NVRED - gobjInst.NvStep));
				} else {
					funcNV_RotateClock_Steps(Math.Abs(NVRED - gobjInst.NvStep));
				}
			}

			// gblnInComm = True          '10.12.07
			// Wprintf(hdc, 21, 20, "        NA IGNITION                       ");
			//Call gobjMessageAdapter.ShowStatusMessageBox("        NA IGNITION               ", strNAFlameMessageCaption, MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 1000, True)
			gobjMessageAdapter.UpdateStatusMessageBox("        NA IGNITION               ", strNAFlameMessageCaption);
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				gobjMessageAdapter.CloseStatusMessageBox();
				return false;
			}
			// Send the N2O ignition On Command to the instument
			if (FuncTransmitCommand(EnumAAS203Protocol.NAON, 0, 0, 0)) {
				if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						func_N2_FLAME_ON = false;
						gobjMessageAdapter.ShowMessage(constErrorFlameOFF);
					} else {
						switch (bytArray(2)) {
							case 1:
								//case 1 : Gerror_message(" NAFLAME ERROR \n NA BURNER NOT CONNECTED "); break;
								gobjMessageAdapter.ShowMessage(constNABurnerNotConnected);
							case 2:
								//case 2 : Gerror_message(" NAFLAME ERROR \n FILL WATER IN TRAP AND RETRY "); break;
								gobjMessageAdapter.ShowMessage(constFillWaterInTrap);
							case 3:
								//case 3 : Gerror_message(" NAFLAME ERROR \n DOOR NOT CLOSED "); break;
								gobjMessageAdapter.ShowMessage(constDoorNotClosed);
							case 4:
								//	case 4 : Gerror_message(" NAFLAME ERROR \n AIR PRESSURE LOW "); break;
								gobjMessageAdapter.ShowMessage(constAirPressureLow);
							case 5:
								//	case 5 : Gerror_message(" NAFLAME ERROR \n FUEL PRESSURE LOW  "); break;
								gobjMessageAdapter.ShowMessage(constFuelPressureLow);
							case 6:
								//case 6 : Gerror_message(" NAFLAME ERROR \n AUTO IGNITION ERROR "); break;
								gobjMessageAdapter.ShowMessage(constErrorAutoIgnition);
							case 7:
								//                        Case 7 : If (!HydrideMode) Then
								//	Gerror_message(" NAFLAME ERROR \n YELLOW FLAME NOT OBTAINABLE ");
								//else{
								//	flag1 = TRUE;
								//}
								//If Not (gblnHydrideMode) Then

								if (!(HydrideMode == true)) {
									gobjMessageAdapter.ShowMessage(constYellowFlameNotObtainable);
								} else {
									flag1 = true;
								}
							case 8:
								//                        Case 8 : If (!HydrideMode) Then
								//	Gerror_message(" NAFLAME ERROR \n BLUE FLAME NOT OBTAINABLE ");
								//else{
								//	flag1 = TRUE;
								//}
								//If Not (gblnHydrideMode) Then
								if (!(HydrideMode == true)) {
									gobjMessageAdapter.ShowMessage(constBlueFlameNotObtainable);
								} else {
									flag1 = true;
								}
							case 9:
								//case 9:  Gerror_message(" NAFLAME ERROR \n NA BURNER NOT CONNECTED  "); break;
								gobjMessageAdapter.ShowMessage(constNABurnerNotConnected);
							case 10:
								//	case 10: Gerror_message(" NAFLAME ERROR \n N2O PRESSURE LOW "); break;
								gobjMessageAdapter.ShowMessage(constN2OPressureLow);
							case 11:
								//	case 11: Gerror_message(" NAFLAME ERROR \n Error while setting max. fuel ");
								gobjMessageAdapter.ShowMessage(constErrorSettingMaxFuel);
							case 0:
								//case 0 : Wprintf(hdc, 21, 19, " NA  FLAME SET ......");
								//gobjMessageAdapter.ShowMessage("NA BURNER NOT CONNECTED", "NAFLAME ERROR ", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
								//gobjMessageAdapter.ShowStatusMessageBox("NA  FLAME SET ......", "NAFLAME", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 0)
								gobjMessageAdapter.UpdateStatusMessageBox("NA  FLAME SET ......", "NAFLAME");
								flag1 = true;
						}

						//nvs = Load_NV_Pos();
						//Get_NV_Pos();
						//If (flag1) Then
						//	flag2=TRUE;
						gblnInComm = false;

						// Get the NV Stpes position
						int nvSteps;
						int intBHSteps;

						nvSteps = gobjInst.NvStep();
						nvSteps = funcLoad_NV_Pos();
						gobjCommProtocol.funcGet_NV_Pos();
						if (flag1 == true) {
							intflag2 = true;
						}
						////
						//if(flag2){
						// switch(CheckNvBurFiles()){
						//	case 1:if(MessageBox(hwnd,"Do you want to load the last optimised fuel conditions from the method?","Optimisation",MB_ICONQUESTION | MB_YESNO) == IDNO )
						//				 flag2 = FALSE;
						//	break;
						//	case 2:if(MessageBox(hwnd,"Do you want to load the last optimised burner position from the method?","Optimisation",MB_ICONQUESTION | MB_YESNO) == IDNO )
						//				 flag2 = FALSE;
						//	break;
						//	case 3:if(MessageBox(hwnd,"Do you want to load the last optimised fuel condition and burner position from the method?","Optimisation",MB_ICONQUESTION | MB_YESNO) == IDNO )
						//				 flag2 = FALSE;
						//	break;
						// }
						//}

						// check flag2 to chack NV Burner setting
						if (intflag2) {
							//chack NV Burner setting and ask for to load previous optimised condition on appropriate instrument condition
							//---commented on 30.04.10
							//'Select Case funcCheckNVBurFiles()
							//'    Case 1
							//'        If (gobjMessageAdapter.ShowMessage(constLoadLastOptimisedFuelConditions) = False) Then
							//'            intflag2 = False
							//'        End If
							//'    Case 2
							//'        If (gobjMessageAdapter.ShowMessage(constLoadLastOptimisedBurnerConditions) = False) Then
							//'            intflag2 = False
							//'        End If
							//'    Case 3
							//'        If (gobjMessageAdapter.ShowMessage(constLoadLastOptimisedFuelNBurnerConditions) = False) Then
							//'            intflag2 = False
							//'        End If
							//'End Select
							//'Application.DoEvents()

							//---written on 30.04.10
							if (gobjClsAAS203.funcCheckPresenceOfLastFuelConditions() == true) {
								if (gobjMessageAdapter.ShowMessage(constLoadLastOptimisedFuelNBurnerConditions) == false) {
									intflag2 = false;
								}
								Application.DoEvents();
							} else {
								intflag2 = false;
							}
						}
						////-----
						gblnInComm = false;
						gobjMessageAdapter.CloseStatusMessageBox();
						if ((intflag2)) {
							//---21.07.09
							if (gstructSettings.NewModelName == false) {
								gobjMessageAdapter.ShowStatusMessageBox("Setting Last conditions   .......       ", "AA-203  NA FLAME", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 0);
							} else {
								gobjMessageAdapter.ShowStatusMessageBox("Setting Last conditions   .......       ", "AA-303  NA FLAME", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 0);
							}

							//gobjCommProtocol.mobjCommdll.subTime_Delay(3000)
							//#If !GRAPHITE Then
							//	 if(Load_BH_Pos()!=-1){
							//		 if (Commflag){
							//			if (Inst.Bhstep<=0||Inst.Bhstep>MAXBHHOME)
							//			  BH_HOME();
							//			else
							//			  SetLastBhPos(Inst.Bhstep);
							//		 }
							//	 }
							//#End If
							mobjCommdll.subTime_Delay(100);
							//check for (not) Graphite setting  for burner height setting

							//---commented by Deepak on 30.04.10
							//'If Not Graphite Then
							//'    intBHSteps = FuncLoad_BH_Pos()
							//'    If Not intBHSteps = -1 Then
							//'        'gobjInst.BhStep = intBHPosition
							//'        If gobjInst.BhStep <= 0 Or gobjInst.BhStep > MAXBHHOME Then
							//'            funcSetBH_HOME()
							//'        Else
							//'            If intBHSteps > 0 Or intBHSteps <= MAXBHHOME Then
							//'                func_SetLastBhPos(intBHSteps)
							//'            End If
							//'        End If
							//'    End If
							//'End If

							//---written on 30.04.10
							gobjClsAAS203.funcLoadLastOptimizedConditions(false);
							func_N2_FLAME_ON = flag1;
							gobjMessageAdapter.CloseStatusMessageBox();
							Application.DoEvents();

							//---commented by Deepak on 30.04.10
							//'mobjCommdll.subTime_Delay(100)
							//'gobjMessageAdapter.CloseStatusMessageBox()


							//---code from 16 bit software
							//if (flag2&& nvs<3.0*NVRED){
							//	Wprintf(hdc, 21, 20, " Setting Last conditions   ........     ");
							////	NV_RotateAnticlock_Steps(abs(nvs-Inst.Nvstep));
							//	SetLastFuel(nvs);
							//If (intflag2 And nvSteps < 3.0 * NVRED) Then
							// Sets the steps for last saving fuel setting 
							//---------------------------------------

							//---commented by Deepak on 30.04.10
							///If nvSteps < 3.5 * NVRED And nvSteps > NVRED Then
							///    'Wprintf(hdc, 21, 20, " Setting Last conditions   ........     ");
							///    gobjMessageAdapter.ShowStatusMessageBox(" Setting Last conditions   ........     ", strNAFlameMessageCaption, MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 0)
							///    Call gobjClsAAS203.funcSetLastFuel(nvSteps)
							///    'If intnvs < 3.5 * NVRED And intnvs > NVRED Then
							///    'funcSet_Last_Fuel(intnvs)
							///    'End If
							///    func_N2_FLAME_ON = flag1
							///    'gobjMessageAdapter.ShowMessage(constErrorFlameOFF)
							///    'gFuncShowMessage("Error...", "Error setting Flame OFF.", EnumMessageType.Information)
							///    'Else

							///    '  func_N2_FLAME_ON = True
							///    'End If
							///    Call gobjMessageAdapter.CloseStatusMessageBox()
							///    Application.DoEvents()
							///End If

						}
						////------------------------

						//If intnvs < 3.5 * NVRED And intnvs > NVRED Then
						//    funcSet_Last_Fuel(intnvs)
						//End If


						////------------------------
					}

				} else {
					func_N2_FLAME_ON = false;
					gobjMessageAdapter.ShowMessage(constErrorFlameOFF);
					//gFuncShowMessage("Error...", "Error setting Flame OFF.", EnumMessageType.Information)
				}
			} else {
				func_N2_FLAME_ON = false;
				//gobjMessageAdapter.ShowMessage(constErrorFlameOFF)
				//gFuncShowMessage("Error...", "Error setting Flame OFF.", EnumMessageType.Information)
			}
			gobjMessageAdapter.CloseStatusMessageBox();
			Application.DoEvents();
			return flag1;
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
			objWait.Dispose();
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool func_AA_FLAME_OFF()
	{
		//--------------------------------------------------------------------------
		//Procedure Name         :   func_AA_FLAME_OFF
		//Description            :   To set AA Flame off
		//Parameters             :   None
		//Retrun                 :   True if successed received byte from communication
		//Time/Date              :   17.11.06
		//Dependencies           :   
		//Author                 :   Deepak B.
		//Revision               :   2
		//Revision by Person     :   Mangesh on 23-Apr-2007
		//--------------------------------------------------------------------------
		//Dim objWait As New CWaitCursor
		byte[] bytArray = new byte[6];

		//BOOL(AA_FLAME_OFF())
		//{
		//   Save_NV_Pos();
		//   Transmit(AAOFF, 0,0, 0);
		//   #If NEWHANDSHAKE Then
		//       Recev(TRUE);
		//   #End If
		//   return OFF;
		//}

		try {
			// gblnInComm = True          '10.12.07

			mobjCommdll.subTime_Delay(1000);
			Application.DoEvents();

			//***************************************
			//---Added by Mangesh on 23-Apr-2007
			//***************************************
			//before make AA Falme off Save the NV position 
			funcSave_NV_Pos();
			//***************************************
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			//send the command for AA Flae off AAOFF(44)
			if (FuncTransmitCommand(EnumAAS203Protocol.AAOFF, 0, 0, 0)) {
				if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						gobjMessageAdapter.ShowMessage(constErrorFlameOFF);
						return false;
					} else {
						return true;
					}
				} else {
					gobjMessageAdapter.ShowMessage(constErrorFlameOFF);
					return false;
				}
			} else {
				return false;
				//gobjMessageAdapter.ShowMessage(constErrorFlameOFF)
			}

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
			//objWait.Dispose()
			gblnInComm = false;
			mobjCommdll.subTime_Delay(1000);
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	//Public Function func_AA_FLAME_ON_1() As Boolean
	//    '-----------------------------------  Procedure Header  -------------------------------
	//    'Procedure Name         :   func_AA_FLAME_OFF
	//    'Description            :   To set AA Flame off
	//    'Parameters             :   None
	//    'Time/Date              :   21.12.06
	//    'Dependencies           :   
	//    'Author                 :   Sachin Dokhale
	//    'Revision               :
	//    'Revision by Person     :
	//    '--------------------------------------------------------------------------------------
	//    Dim objwait As New CWaitCursor
	//    Dim bytArray(7) As Byte
	//    func_AA_FLAME_ON = False
	//    '     

	//    'BOOL(AA_FLAME_ON())
	//    '{
	//    'HWND			hwnd;
	//    'unsigned    oldTout;
	//    'HDC			hdc;
	//    'BOOL 			flag1= FALSE,flag2=FALSE;
	//    'int   		nvs;
	//    'double     bh=0.0;
	//    ' if (GetInstrument()==AA202)
	//    '	return TRUE;

	//    '#ifndef	DEMO
	//    ' if (Ignite_Test()!=GREEN)
	//    '	 return FALSE;
	//    '#End If


	//    ' if( InstType == AA202)
	//    '	 hwnd = Create_Window(NULL, 250, 100, "AA-202  AA FLAME");
	//    '                Else
	//    '	 hwnd = Create_Window(NULL, 250, 100, "AA-203  AA FLAME");
	//    ' hdc=GetDC(hwnd);
	//    ' Get_NV_Pos();
	//    ' if (Inst.Nvstep>4000){
	//    '  NV_HOME();
	//    '  Get_NV_Pos();
	//    ' }
	//    ' if (Inst.Nvstep< ( (int) (2.0* (double) (NVRED)) ) || Inst.Nvstep> ( (int) (2.5* (double) (NVRED))) ) {
	//    '	Wprintf(hdc, 21, 20, " Setting Fuel Please  Wait ....");
	//    '                            If (Inst.Nvstep < 2 * NVRED) Then
	//    '		NV_RotateAnticlock_Steps(abs(NVRED*2-Inst.Nvstep));
	//    '                            Else
	//    '	  NV_RotateClock_Steps(abs(Inst.Nvstep-NVRED*2));
	//    '  }
	//    ' else
	//    '	Wprintf(hdc, 21, 20, " Setting Optimised AA  flame ...");
	//    ' Wprintf(hdc, 21, 20, "       AA IGNITION                       ");
	//    ' Transmit(AAON, 0,0, 0);
	//    ' oldTout=Tout;
	//    ' Tout=VERY_LONG_DEALY; 
	//    ' Recev(TRUE);
	//    ' Tout=oldTout;
	//    ' Beep();Beep();
	//    ' switch(Param1)  {
	//    '	case 0 : Wprintf(hdc, 21, 20, "       Blue FLAME SET  ........");
	//    '				flag1 = TRUE; break;
	//    '	case 1 : Gerror_message(" AAFLAME ERROR \n AA BURNER NOT CONNECTED "); break;
	//    '	case 2 : Gerror_message(" AAFLAME ERROR \n FILL WATER IN TRAP AND RETRY "); break;
	//    '	case 3 : Gerror_message(" AAFLAME ERROR \n DOOR NOT CLOSED "); break;
	//    '	case 4 : Gerror_message(" AAFLAME ERROR \n AIR PRESSURE LOW "); break;
	//    '	case 5 : Gerror_message(" AAFLAME ERROR \n FUEL PRESSURE LOW  "); break;
	//    '	case 6 : Gerror_message(" AAFLAME ERROR \n AUTO IGNITION ERROR "); break;
	//    '	case 7 : if(!HydrideMode){
	//    '					Gerror_message(" AAFLAME ERROR \n YELLOW FLAME NOT OBTAINABLE ");
	//    '				}
	//    '                                Else
	//    '					flag1 = TRUE;
	//    '				 break;
	//    '	case 8 : if(!HydrideMode){
	//    '					Gerror_message(" AAFLAME ERROR \n BLUE FLAME NOT OBTAINABLE ");
	//    '				}
	//    '                                    Else
	//    '				 flag1 = TRUE;
	//    '				 break;
	//    '	case 11: Gerror_message(" AAFLAME ERROR \n Error while setting max. fuel ");
	//    '				break;
	//    '  }

	//    ' nvs=Load_NV_Pos();
	//    ' Get_NV_Pos();
	//    '#If DEMO Then
	//    '	flag1=TRUE;
	//    '#End If
	//    'If (flag1) Then
	//    '		flag2=TRUE;
	//    ' if(flag2){
	//    '	 switch(CheckNvBurFiles()){
	//    '		case 1:if(MessageBox(hwnd,"Do you want to load the last optimised fuel conditions from the method?","Optimisation",MB_ICONQUESTION | MB_YESNO) == IDNO )
	//    '					 flag2 = FALSE;
	//    '		break;
	//    '		case 2:if(MessageBox(hwnd,"Do you want to load the last optimised burner position from the method?","Optimisation",MB_ICONQUESTION | MB_YESNO) == IDNO )
	//    '					 flag2 = FALSE;
	//    '		break;
	//    '		case 3:if(MessageBox(hwnd,"Do you want to load the last optimised fuel condition and burner position from the method?","Optimisation",MB_ICONQUESTION | MB_YESNO) == IDNO )
	//    '					 flag2 = FALSE;
	//    '		break;
	//    '	 }
	//    ' }
	//    ' if (flag2){
	//    '	 Wprintf(hdc, 21, 20, " Setting Last conditions   .......       ");
	//    '	 pc_delay(10000);    pc_delay(10000);    pc_delay(10000);

	//    '#If !GRAPHITE Then
	//    '	 if(Load_BH_Pos()!=-1){
	//    '		 if (Commflag){
	//    '			if (Inst.Bhstep<=0||Inst.Bhstep>MAXBHHOME)
	//    '			  BH_HOME();
	//    '			else{
	//    '			  SetLastBhPos(Inst.Bhstep);
	//    '			}
	//    '		}
	//    '	 }
	//    '#End If

	//    '	 if (nvs<3.5*NVRED && nvs>NVRED){ //MAXNVHOME*NVRED
	//    '		  SetLastFuel(nvs);   
	//    '	  }
	//    '	}
	//    ' ReleaseDC(hwnd, hdc);
	//    ' Close_Window(hwnd, NULL);
	//    ' return flag1;
	//    '}

	//    Try
	//        '//------ Tobe required perform
	//        'If mobjCommdll.gFuncTransmitCommand(EnumAAS203Protocol.AAON, 0, 0, 0) Then
	//        If FuncTransmitCommand(EnumAAS203Protocol.AAON, 0, 0, 0) Then

	//            'mobjCommdll.subTime_Delay(5000)
	//            'If mobjCommdll.gFuncReceiveData(bytArray, CONST_LONG_DELAY) Then
	//            If FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY) Then
	//                If bytArray(1) <> 1 Then
	//                    func_AA_FLAME_ON = False
	//                    gobjMessageAdapter.ShowMessage(constErrorFlameON)
	//                    'gFuncShowMessage("Error...", "Error setting Flame OFF.", EnumMessageType.Information)
	//                Else
	//                    func_AA_FLAME_ON = True
	//                End If

	//            Else
	//                func_AA_FLAME_ON = False
	//                gobjMessageAdapter.ShowMessage(constErrorFlameON)
	//                'gFuncShowMessage("Error...", "Error setting Flame OFF.", EnumMessageType.Information)
	//            End If
	//        Else
	//            func_AA_FLAME_ON = False
	//            gobjMessageAdapter.ShowMessage(constErrorFlameON)
	//            'gFuncShowMessage("Error...", "Error setting Flame OFF.", EnumMessageType.Information)
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
	//        Return False
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        objwait.Dispose()
	//        '---------------------------------------------------------
	//    End Try
	//End Function

	public bool func_AA_FLAME_ON()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   func_AA_FLAME_ON
		//Description            :   To set AA flame ON
		//Parameters             :   None
		//Return                 :   True if success
		//Time/Date              :   16.02.07
		//Dependencies           :   
		//Author                 :   Deepak B.
		//Revision               :
		//Revision by Person     :   Mangesh on 16.02.07
		//--------------------------------------------------------------------------------------
		CWaitCursor objwait = new CWaitCursor();
		byte[] bytArray = new byte[6];
		func_AA_FLAME_ON = false;
		bool flag1 = false;
		bool flag2 = false;
		int intNvs;
		double bh = 0.0;
		//BOOL(AA_FLAME_ON())
		//{
		//HWND			hwnd;
		//unsigned    oldTout;
		//HDC			hdc;
		//BOOL 			flag1= FALSE,flag2=FALSE;
		//int   		nvs;
		//double     bh=0.0;
		// if (GetInstrument()==AA202)
		//	return TRUE;

		//#ifndef	DEMO
		// if (Ignite_Test()!=GREEN)
		//	 return FALSE;
		//#End If

		// if( InstType == AA202)
		//	 hwnd = Create_Window(NULL, 250, 100, "AA-202  AA FLAME");
		//                Else
		//	 hwnd = Create_Window(NULL, 250, 100, "AA-203  AA FLAME");

		// hdc=GetDC(hwnd);
		// Get_NV_Pos();
		// if (Inst.Nvstep>4000){
		//  NV_HOME();
		//  Get_NV_Pos();
		// }
		// if (Inst.Nvstep< ( (int) (2.0* (double) (NVRED)) ) || Inst.Nvstep> ( (int) (2.5* (double) (NVRED))) ) {
		//	Wprintf(hdc, 21, 20, " Setting Fuel Please  Wait ....");
		//                            If (Inst.Nvstep < 2 * NVRED) Then
		//		NV_RotateAnticlock_Steps(abs(NVRED*2-Inst.Nvstep));
		//                            Else
		//	  NV_RotateClock_Steps(abs(Inst.Nvstep-NVRED*2));
		//  }
		// else
		//	Wprintf(hdc, 21, 20, " Setting Optimised AA  flame ...");
		// Wprintf(hdc, 21, 20, "       AA IGNITION                       ");
		// Transmit(AAON, 0,0, 0);
		// oldTout=Tout;
		// Tout=VERY_LONG_DEALY; 
		// Recev(TRUE);
		// Tout=oldTout;
		// Beep();Beep();

		// switch(Param1)  {
		//	case 0 : Wprintf(hdc, 21, 20, "       Blue FLAME SET  ........");
		//				flag1 = TRUE; break;
		//	case 1 : Gerror_message(" AAFLAME ERROR \n AA BURNER NOT CONNECTED "); break;
		//	case 2 : Gerror_message(" AAFLAME ERROR \n FILL WATER IN TRAP AND RETRY "); break;
		//	case 3 : Gerror_message(" AAFLAME ERROR \n DOOR NOT CLOSED "); break;
		//	case 4 : Gerror_message(" AAFLAME ERROR \n AIR PRESSURE LOW "); break;
		//	case 5 : Gerror_message(" AAFLAME ERROR \n FUEL PRESSURE LOW  "); break;
		//	case 6 : Gerror_message(" AAFLAME ERROR \n AUTO IGNITION ERROR "); break;
		//	case 7 : if(!HydrideMode){
		//					Gerror_message(" AAFLAME ERROR \n YELLOW FLAME NOT OBTAINABLE ");
		//				}
		//                                Else
		//					flag1 = TRUE;
		//				 break;
		//	case 8 : if(!HydrideMode){
		//					Gerror_message(" AAFLAME ERROR \n BLUE FLAME NOT OBTAINABLE ");
		//				}
		//                                    Else
		//				 flag1 = TRUE;
		//				 break;
		//	case 11: Gerror_message(" AAFLAME ERROR \n Error while setting max. fuel ");
		//				break;
		//  }

		// nvs=Load_NV_Pos();
		// Get_NV_Pos();
		//#If DEMO Then
		//	flag1=TRUE;
		//#End If
		//If (flag1) Then
		//		flag2=TRUE;
		// if(flag2){
		//	 switch(CheckNvBurFiles()){
		//		case 1:if(MessageBox(hwnd,"Do you want to load the last optimised fuel conditions from the method?","Optimisation",MB_ICONQUESTION | MB_YESNO) == IDNO )
		//					 flag2 = FALSE;
		//		break;
		//		case 2:if(MessageBox(hwnd,"Do you want to load the last optimised burner position from the method?","Optimisation",MB_ICONQUESTION | MB_YESNO) == IDNO )
		//					 flag2 = FALSE;
		//		break;
		//		case 3:if(MessageBox(hwnd,"Do you want to load the last optimised fuel condition and burner position from the method?","Optimisation",MB_ICONQUESTION | MB_YESNO) == IDNO )
		//					 flag2 = FALSE;
		//		break;
		//	 }
		// }
		// if (flag2){
		//	 Wprintf(hdc, 21, 20, " Setting Last conditions   .......       ");
		//	 pc_delay(10000);    pc_delay(10000);    pc_delay(10000);

		//#If !GRAPHITE Then
		//	 if(Load_BH_Pos()!=-1){
		//		 if (Commflag){
		//			if (Inst.Bhstep<=0||Inst.Bhstep>MAXBHHOME)
		//			  BH_HOME();
		//			else{
		//			  SetLastBhPos(Inst.Bhstep);
		//			}
		//		}
		//	 }
		//#End If

		//	 if (nvs<3.5*NVRED && nvs>NVRED){ //MAXNVHOME*NVRED
		//		  SetLastFuel(nvs);   
		//	  }
		//	}
		// ReleaseDC(hwnd, hdc);
		// Close_Window(hwnd, NULL);
		// return flag1;
		//}

		///Dm objFrmManualIgnition As New frmManualIgnition

		try {
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				return true;
			}

			if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
				ClsAAS203.enumIgniteType intIgnite_Test;
				if (gobjClsAAS203.funcIgnite_Test(intIgnite_Test)) {
					if (intIgnite_Test == ClsAAS203.enumIgniteType.Green) {
						return false;
					}
				}
			}

			gblnInComm = false;
			// Get the NV Steps
			funcGet_NV_Pos();
			//check Inst object NV steps for garbage value when steps are grater than 4000
			// then Set Needle valve to home position
			// then get Needle valve positions
			if (gobjInst.NvStep > 4000) {
				funcSetNV_HOME();
				funcGet_NV_Pos();
			}

			//Dim strAAFlameMessageCaption As String  '05.11.09
			//If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
			//    If gstructSettings.NewModelName = False Then  '---21.07.09
			//        strAAFlameMessageCaption = "AA-201  AA FLAME"
			//    Else
			//        strAAFlameMessageCaption = "AA-301  AA FLAME"
			//    End If
			//Else
			//    If gstructSettings.NewModelName = False Then  '---21.07.09
			//        strAAFlameMessageCaption = "AA-203  AA FLAME"
			//    Else
			//        strAAFlameMessageCaption = "AA-303  AA FLAME"
			//    End If
			//End If


			string strAAFlameMessageCaption;
			//05.11.09
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				//---21.07.09
				if (gstructSettings.NewModelName == false) {
					strAAFlameMessageCaption = "AA-201  AA FLAME";
				} else {
					strAAFlameMessageCaption = "AA-301  AA FLAME";
				}
			} else if (gstructSettings.AppMode == EnumAppMode.FullVersion_203) {
				//---21.07.09
				if (gstructSettings.NewModelName == false) {
					strAAFlameMessageCaption = "AA-203  AA FLAME";
				} else {
					strAAFlameMessageCaption = "AA-303  AA FLAME";
				}
			} else {
				if (gstructSettings.NewModelName == false) {
					strAAFlameMessageCaption = "AA-203D  AA FLAME";
				} else {
					strAAFlameMessageCaption = "AA-303D  AA FLAME";
				}
			}

			// if (Inst.Nvstep< ( (int) (2.0* (double) (NVRED)) ) || Inst.Nvstep> ( (int) (2.5* (double) (NVRED))) ) {
			//	Wprintf(hdc, 21, 20, " Setting Fuel Please  Wait ....");
			//                            If (Inst.Nvstep < 2 * NVRED) Then
			//		NV_RotateAnticlock_Steps(abs(NVRED*2-Inst.Nvstep));
			//                            Else
			//	  NV_RotateClock_Steps(abs(Inst.Nvstep-NVRED*2));
			//  }

			// Validate the NV Steps
			if ((gobjInst.NvStep < (int)2.0 * NVRED) | (gobjInst.NvStep > (int)2.5 * NVRED)) {
				gobjMessageAdapter.ShowStatusMessageBox("Setting Fuel Please  Wait ....", strAAFlameMessageCaption, MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 1000, true);
				Application.DoEvents();

				if (gobjInst.NvStep < (2 * NVRED)) {
					funcNV_RotateAntiClock_Steps(Math.Abs((NVRED * 2) - gobjInst.NvStep));
				} else {
					funcNV_RotateClock_Steps(Math.Abs(gobjInst.NvStep - (NVRED * 2)));
				}
			} else {
				gobjMessageAdapter.UpdateStatusMessageBox("Setting Optimised AA  flame ...", strAAFlameMessageCaption);
				Application.DoEvents();
			}

			gobjMessageAdapter.UpdateStatusMessageBox("  AA Ignition  ", strAAFlameMessageCaption);

			Application.DoEvents();

			// gblnInComm = True          '10.12.07
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == true) {
				// after optimise steps for NV Send the command for AA On
				if (FuncTransmitCommand(EnumAAS203Protocol.AAON, 0, 0, 0)) {
					gobjCommProtocol.mobjCommdll.subTime_Delay(50);
					if (FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY)) {
						if (bytArray(1) != 1) {
							func_AA_FLAME_ON = false;
							gobjMessageAdapter.ShowMessage(constErrorFlameON);

						} else {
							//Call gobjMessageAdapter.CloseStatusMessageBox()
							// Check for flame setting and if not get success the display proper message
							switch (bytArray(2)) {
								case 0:
									//gobjMessageAdapter.ShowMessage(constBlueFlameSet)
									gobjfrmStatus.FlameType = ClsAAS203.enumIgniteType.Blue;
									gobjMessageAdapter.UpdateStatusMessageBox("Blue FLAME SET  ........", strAAFlameMessageCaption);
									Application.DoEvents();
									gobjCommProtocol.mobjCommdll.subTime_Delay(600);
									flag1 = true;
								case 1:
									gobjMessageAdapter.ShowMessage(constAABurnerNotConnected);

									Application.DoEvents();
								case 2:
									gobjMessageAdapter.ShowMessage(constFillWaterTrap);

									Application.DoEvents();
								case 3:
									gobjMessageAdapter.ShowMessage(constAADoorNotCLosed);

									Application.DoEvents();
								case 4:
									gobjMessageAdapter.ShowMessage(constAAAirPressureLow);

									Application.DoEvents();
								case 5:
									gobjMessageAdapter.ShowMessage(constAAFuelPressureLow);

									Application.DoEvents();
								case 6:
									gobjMessageAdapter.ShowMessage(constAAAutoIgnitionError);

									Application.DoEvents();
								case 7:
									if (gobjInst.Hydride == false) {
										gobjMessageAdapter.ShowMessage(constAAYellowFlameNotObtainable);
										Application.DoEvents();
									} else {
										flag1 = true;

									}
								case 8:
									if (gobjInst.Hydride == false) {
										gobjMessageAdapter.ShowMessage(constAABlueFlameNotObtainable);
										Application.DoEvents();
									} else {
										flag1 = true;

									}
								case 11:
									gobjMessageAdapter.ShowMessage(constAAErrorSettingMaxFuel);
									Application.DoEvents();
								case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
11:
									flag1 = false;
								default:
								//****************************************************
								//---Case Else Added by Mangesh as sometimes it is 
								//---returning value of  greater then 11 
								//****************************************************
								//flag1 = True  'commented by deepak on 28.12.08
								//****************************************************
							}

							gblnInComm = false;

							//---Added by deepak on 29.12.08
							gobjClsAAS203.funcCheck_Flame();
							//------------

							//gobjCommProtocol.mobjCommdll.subTime_Delay(500)
							gobjMessageAdapter.CloseStatusMessageBox();
							// after flame setting get the NV steps from instrument
							intNvs = funcLoad_NV_Pos();
							funcGet_NV_Pos();
							gobjMessageAdapter.CloseStatusMessageBox();
							//If gstructSettings.AppMode = EnumAppMode.DemoMode Then
							if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
								flag1 = true;
							}

							if (flag1 == true) {
								flag2 = true;
							}

							//---------29.12.08
							gobjCommProtocol.mobjCommdll.subTime_Delay(100);
							gobjClsAAS203.funcCheck_Flame(flag2);
							gobjCommProtocol.mobjCommdll.subTime_Delay(100);
							//---------

							// Check NV Burner setting when flame gets proper On 
							// display message
							if (flag2 == true) {
								// ask for to load previous condition

								//---commented on 30.04.10
								//'Select Case funcCheckNVBurFiles()
								//'    Case 1
								//'        If gobjMessageAdapter.ShowMessage(constLoadLastOptimisedFuelConditions) = False Then
								//'            flag2 = False
								//'        End If
								//'        Application.DoEvents()
								//'        Exit Select
								//'    Case 2
								//'        If gobjMessageAdapter.ShowMessage(constLoadLastOptimisedBurnerConditions) = False Then
								//'            flag2 = False
								//'        End If
								//'        Application.DoEvents()
								//'        Exit Select
								//'    Case 3
								//'        If gobjMessageAdapter.ShowMessage(constLoadLastOptimisedFuelNBurnerConditions) = False Then
								//'            flag2 = False
								//'        End If
								//'        Application.DoEvents()
								//'        Exit Select
								//'End Select

								//---written on 30.04.10
								if (gobjClsAAS203.funcCheckPresenceOfLastFuelConditions() == true) {
									if (gobjMessageAdapter.ShowMessage(constLoadLastOptimisedFuelNBurnerConditions) == false) {
										flag2 = false;
									}
									Application.DoEvents();
								} else {
									flag2 = false;
								}
							}

							int intBHSteps;
							int intNVSteps;

							if (flag2) {
								//Check and follow the steps for Setting Last conditions   
								gobjMessageAdapter.ShowStatusMessageBox("Setting Last conditions   .......       ", strAAFlameMessageCaption, MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 1000);
								mobjCommdll.subTime_Delay(100);

								//---commented on 30.04.10
								//'If Not Graphite Then
								//'    intBHSteps = FuncLoad_BH_Pos()
								//'    If Not intBHSteps = -1 Then
								//'        'gobjInst.BhStep = intBHPosition
								//'        If gobjInst.BhStep <= 0 Or gobjInst.BhStep > MAXBHHOME Then
								//'            funcSetBH_HOME()
								//'        Else
								//'            If intBHSteps > 0 Or intBHSteps <= MAXBHHOME Then
								//'                func_SetLastBhPos(intBHSteps)
								//'            End If
								//'        End If
								//'    End If
								//'End If
								//'mobjCommdll.subTime_Delay(50)
								//'If intNvs < (3.5 * NVRED) And intNvs > NVRED Then
								//'    funcSet_Last_Fuel(intNvs)
								//'End If

								//---written on 30.04.10
								gobjClsAAS203.funcLoadLastOptimizedConditions(true);


								gobjMessageAdapter.CloseStatusMessageBox();
							}
						}
					} else {
						func_AA_FLAME_ON = false;
						gobjMessageAdapter.ShowMessage(constErrorFlameON);
						Application.DoEvents();
					}
				} else {
					func_AA_FLAME_ON = false;
					//gobjMessageAdapter.ShowMessage(constErrorFlameON)
					//Application.DoEvents()
				}
			}
			gobjMessageAdapter.CloseStatusMessageBox();
			Application.DoEvents();

			return flag1;

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
			objwait.Dispose();
			//If Not objFrmManualIgnition Is Nothing Then
			//    objFrmManualIgnition.Close()
			//    objFrmManualIgnition.Dispose()
			//End If
			gblnInComm = false;
			gobjMessageAdapter.CloseStatusMessageBox();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool func_N2O_ON()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   func_N2O_ON
		//Description            :   To set N2O on
		//Parameters             :   None
		//Return                 :   True if successed received byte from communication
		//Time/Date              :   28-11-06
		//Dependencies           :   
		//Author                 :   Saurabh S
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		CWaitCursor objwait = new CWaitCursor();
		byte[] bytArray = new byte[6];

		try {
			//If gblnInComm = True Then
			//    gblnInComm = False
			//End If
			// gblnInComm = True          '10.12.07
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			// Send the command for N2O fuel On N2OON(31)
			if (FuncTransmitCommand(EnumAAS203Protocol.N2OON, 0, 0, 0)) {
				if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						func_N2O_ON = false;
						gobjMessageAdapter.ShowMessage(constN2O_ON);
						Application.DoEvents();
					} else {
						func_N2O_ON = true;
					}
				} else {
					func_N2O_ON = false;
					gobjMessageAdapter.ShowMessage(constN2O_ON);
					Application.DoEvents();
				}
			} else {
				func_N2O_ON = false;
				//gobjMessageAdapter.ShowMessage(constN2O_ON)
				//Application.DoEvents()
			}

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
			objwait.Dispose();
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool func_N2O_OFF()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   func_N2O_OFF
		//Description            :   To set N2O off
		//Parameters             :   None
		//Return                 :   True if successed received byte from communication
		//Time/Date              :   28-11-06
		//Dependencies           :   
		//Author                 :   Saurabh S.
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		//Dim objwait As New CWaitCursor
		byte[] bytArray = new byte[6];

		try {
			//If gblnInComm = True Then
			//    gblnInComm = False
			//End If
			// gblnInComm = True          '10.12.07
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			// Send the command for N2O fuel Off N2OON(31)
			if (FuncTransmitCommand(EnumAAS203Protocol.N2OOFF, 0, 0, 0)) {
				if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						func_N2O_OFF = false;
						gobjMessageAdapter.ShowMessage(constN2O_OFF);
						Application.DoEvents();
					} else {
						if (bytArray(2) == 0) {
							//func_N2O_OFF = False
							return false;
						} else {
							//func_N2O_OFF = True
							return true;
						}
					}
				} else {
					//func_N2O_OFF = False
					return false;
					gobjMessageAdapter.ShowMessage(constN2O_OFF);
					Application.DoEvents();
				}
			} else {
				//func_N2O_OFF = False
				return false;
				//gobjMessageAdapter.ShowMessage(constN2O_OFF)
				//Application.DoEvents()
			}

		} catch (Threading.ThreadAbortException threadex) {
			return false;
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
			//objwait.Dispose()
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool func_FUEL_ON()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   func_FUEL_ON
		//Description            :   To set FUEL ON
		//Parameters             :   None
		//Return                 :   True if successed received byte from communication
		//Time/Date              :   29-11-06
		//Dependencies           :   
		//Author                 :   Saurabh S.
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];

		try {
			//If gblnInComm = True Then
			//    Return False
			//End If
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			// gblnInComm = True          '10.12.07
			// Send the command for Fuel On FUELON(35)
			if (FuncTransmitCommand(EnumAAS203Protocol.FUELON, 0, 0, 0)) {
				if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						func_FUEL_ON = false;
						gobjMessageAdapter.ShowMessage(constFUEL_ON);
						Application.DoEvents();
					} else {
						func_FUEL_ON = true;
					}
				} else {
					func_FUEL_ON = false;
					gobjMessageAdapter.ShowMessage(constFUEL_ON);
					Application.DoEvents();
				}
			} else {
				func_FUEL_ON = false;
				//gobjMessageAdapter.ShowMessage(constFUEL_ON)
				//Application.DoEvents()
			}

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
			if (!objWait == null) {
				objWait.Dispose();
			}
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool func_FUEL_OFF()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   func_FUEL_OFF
		//Description            :   To set FUEL OFF
		//Parameters             :   None
		//Return                 :   True if successed received byte from communication
		//Time/Date              :   29-11-06
		//Dependencies           :   
		//Author                 :   Saurabh S.
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		//Dim objWait As New CWaitCursor
		byte[] bytArray = new byte[6];

		try {
			//If gblnInComm = True Then
			//    Return False
			//End If
			// gblnInComm = True          '10.12.07
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			// Send the command for Fuel Off FUELOFF(36)
			if (FuncTransmitCommand(EnumAAS203Protocol.FUELOFF, 0, 0, 0)) {
				if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						func_FUEL_OFF = false;
						gobjMessageAdapter.ShowMessage(constFUEL_OFF);
						Application.DoEvents();
					} else {
						func_FUEL_OFF = true;
					}
				} else {
					func_FUEL_OFF = false;
					gobjMessageAdapter.ShowMessage(constFUEL_OFF);
					Application.DoEvents();
				}
			} else {
				func_FUEL_OFF = false;
				//gobjMessageAdapter.ShowMessage(constFUEL_OFF)
				//Application.DoEvents()
			}

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
			//If Not objWait Is Nothing Then
			//    objWait.Dispose()
			//End If
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool func_IGNITE_ON()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   func_IGNITE_ON
		//Description            :   To IGNITE ON
		//Parameters             :   None
		//Return                 :   True if successed received byte from communication
		//Time/Date              :   29-11-06
		//Dependencies           :   
		//Author                 :   Saurabh S.
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];

		try {
			//If gblnInComm = True Then
			//    Return False
			//End If

			// gblnInComm = True          '10.12.07
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			// Send the command for Ignition On IGNITEON(39)
			if (FuncTransmitCommand(EnumAAS203Protocol.IGNITEON, 0, 0, 0)) {
				if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						func_IGNITE_ON = false;
						gobjMessageAdapter.ShowMessage(constIGNITE_ON);
						Application.DoEvents();
					} else {
						func_IGNITE_ON = true;
					}
				} else {
					func_IGNITE_ON = false;
					gobjMessageAdapter.ShowMessage(constIGNITE_ON);
					Application.DoEvents();
				}
			} else {
				func_IGNITE_ON = false;
				//gobjMessageAdapter.ShowMessage(constIGNITE_ON)
				//Application.DoEvents()
			}

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
			if (!objWait == null) {
				objWait.Dispose();
			}
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool func_IGNITE_OFF()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   func_IGNITE_OFF
		//Description            :   To IGNITE OFF
		//Parameters             :   None
		//Return                 :   True if successed received byte from communication
		//Time/Date              :   29-11-06
		//Dependencies           :   
		//Author                 :   Saurabh S.
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];

		try {
			//If gblnInComm = True Then
			//    Return False
			//End If
			// gblnInComm = True          '10.12.07
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			// Send the command for Ignition Off IGNITEOFF(40)
			if (FuncTransmitCommand(EnumAAS203Protocol.IGNITEOFF, 0, 0, 0)) {
				if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						func_IGNITE_OFF = false;
						gobjMessageAdapter.ShowMessage(constIGNITE_OFF);
						Application.DoEvents();
					} else {
						func_IGNITE_OFF = true;
					}
				} else {
					func_IGNITE_OFF = false;
					gobjMessageAdapter.ShowMessage(constIGNITE_OFF);
					Application.DoEvents();
				}
			} else {
				func_IGNITE_OFF = false;
				//gobjMessageAdapter.ShowMessage(constIGNITE_OFF)
				//Application.DoEvents()
			}

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
			if (!objWait == null) {
				objWait.Dispose();
			}
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcSetD2Cur(int intD2Cur)
	{
		//=====================================================================
		// Procedure Name        : funcSet_D2_Cur
		// Parameters Passed     : intD2Cur
		// Returns               : Boolean
		// Purpose               : Set the D2 Current 
		//Return                 : True if successed received byte from communication  
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokahle
		// Created               : 25.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		byte bytLow;
		byte bytHigh;
		byte[] bytArray = new byte[6];

		try {
			//If gblnInComm = True Then
			//    Return False
			//End If

			// if (dcur>=100 && dcur<=300){
			//	 Inst.D2cur=dcur;
			//	 D2_ON();
			//	 Transmit(D2CUR, (BYTE)(Inst.D2cur), (BYTE) (Inst.D2cur>>8), 0);
			//#If NEWHANDSHAKE Then
			//	  Recev(TRUE);
			//#End If
			////  c = D2CUR;  trans(c);  c = d2cur;  trans(c);  c = d2cur>>8;  trans(c);
			//	 if (dcur==100)
			//		D2_OFF();
			//	}
			//Validate to the parameter value from 100 to 300 current   
			//If (intD2Cur >= 100) And (intD2Cur <= 300) Then  '---02.06.09 'on 100 ma d2 curr relay sound was coming
			//---02.06.09
			if ((intD2Cur > 100) & (intD2Cur <= 300)) {
				gobjInst.D2Current = intD2Cur;
				gobjCommProtocol.D2_ON();
				// gblnInComm = True          '10.12.07
				gFunclongtobyte(intD2Cur, bytHigh, bytLow);

				//10.12.07
				if (mobjCommdll.gFuncResumeProcess == false) {
					return false;
				}
				//If mobjCommdll.gFuncTransmitCommand(EnumAAS203Protocol.D2CUR, bytHigh, bytLow, 0) Then
				// Send the Command for D2 current with high byte and low byte
				if (FuncTransmitCommand(EnumAAS203Protocol.D2CUR, bytHigh, bytLow, 0)) {
					//If mobjCommdll.gFuncReceiveData(bytArray, CONST_LONG_DELAY) Then
					if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
						if (bytArray(1) != 1) {
							funcSetD2Cur = false;
							//MessageBox.Show("error")
							gobjMessageAdapter.ShowMessage(constErrorSettingD2Current);
							Application.DoEvents();
						} else {
							funcSetD2Cur = true;
						}
					} else {
						gobjMessageAdapter.ShowMessage(constErrorSettingD2Current);
						//MessageBox.Show("error: funcSetD2Cur in Receive Data")
						Application.DoEvents();
					}
				} else {
					//gobjMessageAdapter.ShowMessage(constErrorSettingD2Current)
					//MessageBox.Show("error: funcSetD2Cur in Transmit")
					Application.DoEvents();
				}
				gblnInComm = false;
				// Check for D2 current for 100 if it is then makes D2 Off for 100 
				if ((intD2Cur == 100)) {
					gobjCommProtocol.D2_OFF();
				}
			}

			//---02.06.09    'on 100 ma d2 curr relay sound was coming
			if ((intD2Cur == 100)) {
				gobjCommProtocol.D2_OFF();
			}

			return funcSetD2Cur;

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
			objWait.Dispose();
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcNV_RotateClock_Steps(int intNVSteps)
	{
		//=====================================================================
		// Procedure Name        : funcSet_D2_Cur
		// Parameters Passed     : intD2Cur
		// Returns               : Boolean
		// Purpose               : Rotate NV to Clockwise no of Steps
		// Return                : True if successed received byte from communication
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokahle
		// Created               : 25.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		byte bytLow;
		byte bytHigh;
		byte[] bytArray = new byte[6];

		try {
			//If gblnInComm = True Then
			//    Return False
			//End If
			// gblnInComm = True          '10.12.07
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			gFunclongtobyte(intNVSteps, bytLow, bytHigh);
			// Rotate needle valve to Anticlock Steps for given stpes NVCLKSTEPS(61)
			if (FuncTransmitCommand(EnumAAS203Protocol.NVCLKSTEPS, bytHigh, bytLow, 0)) {
				if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
					funcNV_RotateClock_Steps = true;
				}
			} else {
				//MessageBox.Show("error: NV_RotateClock_Steps in Transmit")
				//Application.DoEvents()
			}
			gblnInComm = false;
			gobjCommProtocol.funcGet_NV_Pos();

			return funcNV_RotateClock_Steps;

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
			objWait.Dispose();
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcNV_Rotate_Clock()
	{
		//=====================================================================
		// Procedure Name        : funcNV_Rotate_Clock
		// Parameters Passed     : None
		// Returns               : True if successed received byte from communication
		// Purpose               : 
		// Description           : Rotate NV to Clockwise for a step
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokahle
		// Created               : 25.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];

		try {
			//If gblnInComm = True Then
			//    Return False
			//End If
			// gblnInComm = True          '10.12.07
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			// Rotate needle valve to Anticlock Step NVCLOCK(26)
			if (FuncTransmitCommand(EnumAAS203Protocol.NVCLOCK, 0, 0, 0)) {
				if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
					funcNV_Rotate_Clock = true;
				}
			} else {
				//MessageBox.Show("error: funcNV_Rotate_Clock in Transmit")
				//Application.DoEvents()
				return false;
			}

			return funcNV_Rotate_Clock;

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
			objWait.Dispose();
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcNV_Rotate_AntiClock()
	{
		//=====================================================================
		// Procedure Name        : funcNV_Rotate_AntiClock
		// Parameters Passed     : None
		// Returns               : True if successed received byte from communication
		// Purpose               : Rotate NV to Anticlockwise for a step
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokahle
		// Created               : 25.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];

		try {
			//If gblnInComm = True Then
			//    Return False
			//End If
			// gblnInComm = True          '10.12.07
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			// Rotate needle valve to Anticlock Step NVANTI(25)
			if (FuncTransmitCommand(EnumAAS203Protocol.NVANTI, 0, 0, 0)) {
				if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
					funcNV_Rotate_AntiClock = true;
				}
			} else {
				//MessageBox.Show("error: funcNV_Rotate_AntiClock in Transmit")
				//Application.DoEvents()
				return false;
			}

			return funcNV_Rotate_AntiClock;

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
			objWait.Dispose();
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcNV_RotateAntiClock_Steps(int intNVSteps)
	{
		//=====================================================================
		// Procedure Name        : funcNV_Rotate_AntiClock
		// Parameters Passed     : None
		// Returns               : True if successed received byte from communication
		// Purpose               : Rotate NV to Anticlockwise Steps
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokahle
		// Created               : 25.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];
		byte bytLow;
		byte bytHigh;

		try {
			// Transmit(NVANTISTEPS, (BYTE) (steps>>8), (BYTE) (steps), 0);
			// Recev(TRUE);
			//#If DEMO Then
			//	 NVpos+=steps;
			//#End If
			// Get_NV_Pos();

			//If gblnInComm = True Then
			//    Return False
			//End If
			// gblnInComm = True          '10.12.07
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			gFunclongtobyte(intNVSteps, bytLow, bytHigh);
			// Rotate needle valve to Anticlock Steps for given no of steps NVANTISTEPS(60)
			if (FuncTransmitCommand(EnumAAS203Protocol.NVANTISTEPS, bytHigh, bytLow, 0)) {
				if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
					funcNV_RotateAntiClock_Steps = true;
				}
			} else {
				//---ToDo change message box
				//MessageBox.Show("error: funcNV_RotateAntiClock_Steps in Transmit")
				//Application.DoEvents()
				return false;
			}
			gblnInComm = false;
			// Get the NV position
			gobjCommProtocol.funcGet_NV_Pos();

			return funcNV_RotateAntiClock_Steps;

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
			objWait.Dispose();
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public int funcIsD2GainOn()
	{
		//=====================================================================
		// Procedure Name        : funcIsD2GainOn
		// Parameters Passed     : None
		// Returns               : Integer
		// Purpose               : 
		// Description           : Return the D2 Gain status
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokahle
		// Created               : 19.12.06
		// Revisions             : 
		//=====================================================================
		try {
			//Return the D2 Gain status
			return mintSSGain;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return 0x0;
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

	public bool funcNVScanSteps(int intNVScanSteps)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcNVScanSteps
		//Description            :   To Optimise the Fuel        
		//Parameters             :   intSteps : turret to be rotate by this num 
		//Return                 :   True if successed transmit data
		//Time/Date              :   25.12.06
		//Dependencies           :   
		//Author                 :   Sachin Dokhale 
		//Revision               :
		//Revision by Person     :   
		//--------------------------------------------------------------------------------------
		//Dim objWait As New CWaitCursor
		byte[] bytArray = new byte[6];
		byte bytLow;
		byte bytHigh;
		byte bytNVSCANSTEP;

		try {
			//If gblnInComm = True Then
			//    Return False
			//End If
			// gblnInComm = True          '10.12.07

			gFunclongtobyte(intNVScanSteps, bytHigh, bytLow);
			//bytLow = intSteps And &HFF
			//bytHigh = CByte(intSteps >> 8)
			bytNVSCANSTEP = (byte)CONST_NVSCANSTEP;

			////-------------- For Temp Purpose
			//Transmit(BHSCAN, (BYTE)(xvalmax), (BYTE) (xvalmax>>8), (BYTE) BHSCANSTEP);
			//gobjCommProtocol.gFunclongtobyte(intBHScanSteps, bytHigh, bytLow)
			//'bytLow = intSteps And &HFF
			//'bytHigh = CByte(intSteps >> 8)
			//bytNVSCANSTEP = CByte(CONST_NVSCANSTEP)

			//If FuncTransmitCommand(EnumAAS203Protocol.BHSCAN, bytHigh, bytLow, bytNVSCANSTEP) Then
			////---------------
			//	Transmit(NVSCAN, (BYTE)(xvalmin), (BYTE) (xvalmin>>8), (BYTE) NVSCANSTEP);
			//If mobjCommdll.gFuncTransmitCommand(EnumAAS203Protocol.NVSCAN, bytHigh, bytLow, bytNVSCANSTEP) Then
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			mobjCommdll.IsNeedReceive = false;
			// Send the command for Optimise the Fuel NVSCAN (65)
			if (FuncTransmitCommand(EnumAAS203Protocol.NVSCAN, bytHigh, bytLow, bytNVSCANSTEP)) {
				clsRS232Main.gblnInCommProcess = false;
				//If mobjCommdll.gFuncTransmitCommand(EnumAAS203Protocol.SPECT, bytLow, bytHigh, bytSpeed) Then
				funcNVScanSteps = true;
			//gobjMessageAdapter.ShowMessage(constRotateStepsTurClkError)
			} else {
				funcNVScanSteps = false;
				//gobjMessageAdapter.ShowMessage(constRotateStepsTurClkError)
				//Application.DoEvents()
			}

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
			gblnInComm = false;
			Application.DoEvents();
			//objWait.Dispose()
			//---------------------------------------------------------
		}
	}

	public bool funcBHSCAN(int intBHScanSteps)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcBHSCAN
		//Description            :   To Optimise burner height        
		//Parameters             :   intBHScanSteps : turret to be rotate by this num 
		//Return                 :   True if successed, transmit data.
		//Time/Date              :   25.12.06
		//Dependencies           :   
		//Author                 :   Sachin Dokhale 
		//Revision               :
		//Revision by Person     :   
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];
		byte bytLow;
		byte bytHigh;
		byte bytNVSCANSTEP;

		try {
			//If gblnInComm = True Then
			//    Return False
			//End If
			// gblnInComm = True          '10.12.07

			gFunclongtobyte(intBHScanSteps, bytHigh, bytLow);

			//bytLow = intSteps And &HFF
			//bytHigh = CByte(intSteps >> 8)
			bytNVSCANSTEP = (byte)CONST_BHSCANSTEP;
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			mobjCommdll.IsNeedReceive = false;
			// send the command for Optimise burner height BHSCAN(64)
			if (FuncTransmitCommand(EnumAAS203Protocol.BHSCAN, bytHigh, bytLow, bytNVSCANSTEP)) {
				clsRS232Main.gblnInCommProcess = false;
				funcBHSCAN = true;
				//gobjMessageAdapter.ShowMessage(constRotateStepsTurClkError)
				Application.DoEvents();
			} else {
				funcBHSCAN = false;
				//gobjMessageAdapter.ShowMessage(constRotateStepsTurClkError)
				//Application.DoEvents()
			}

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
			gblnInComm = false;
			objWait.Dispose();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcRotate_Wv_Clock_Steps(int intWvNo_steps)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcRotate_Wv_Clock_Steps
		//Description            :   To Rotate Wv to clock wise
		//Parameters             :   intWvNo_steps : no of Wv Steps to be rotate by this num 
		//Return                 :   True if success
		//Time/Date              :   10.01.07
		//Dependencies           :   
		//Author                 :   Sachin Dokhale 
		//Revision               :
		//Revision by Person     :   
		//--------------------------------------------------------------------------------------

		//===========================
		//void	S4FUNC Rotate_Wv_Clock_Steps(int no_steps)
		//{
		//int	i;
		// for(i=0; i<no_steps; i++){
		//	Rotate_Clock_Wv();
		//	pc_delay(200);
		//	}
		//}
		CWaitCursor objWait = new CWaitCursor();
		int intIndex;

		try {
			// Rorate the clock wise Wv for given stpes
			for (intIndex = 0; intIndex <= intWvNo_steps - 1; intIndex++) {
				funcRotate_Clock_Wv();
				//pc_delay(200);
				//mobjCommdll.subTime_Delay(20)
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
			objWait.Dispose();
			//gblnInComm = False
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public byte funcGet_Pneum_Status()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcGet_Pneum_Status
		//Description            :   To get the pnueumatics status
		//Parameters             :   None
		//Return                 :   Byte if successed received byte from communication
		//Time/Date              :   01.02.07
		//Dependencies           :   
		//Author                 :   Deepak B.
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		//Dim objWait As New CWaitCursor
		byte[] bytArray = new byte[6];
		//    BYTE	GET_PNEUM_STATUS()
		//{
		//  Transmit(PNEMSTATUS, 0, 0 , 0);
		// Recev(TRUE);
		//return Param1;
		//}
		try {
			//If gblnInComm = True Then
			//    Exit Function
			//End If
			// gblnInComm = True          '10.12.07
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			//send the command for the pnueumatics status PNEMSTATUS(41)
			if (FuncTransmitCommand(EnumAAS203Protocol.PNEMSTATUS, 0, 0, 0)) {
				if (FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY)) {
					if (bytArray(1) != 1) {
					//---ToDo Message 
					//gobjMessageAdapter.ShowMessage(constAirOn)
					//Application.DoEvents()
					} else {
						return bytArray(2);
					}
				} else {
					//---ToDo Message 
					//gobjMessageAdapter.ShowMessage(constAirOn)
					//Application.DoEvents()
				}
			} else {
				//---ToDo Message 
				//gobjMessageAdapter.ShowMessage(constAirOn)
				//Application.DoEvents()
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
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	////----- This fucntion is use for Demo Mode
	public int funcpmtAd()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcGet_Pneum_Status
		//Description            :   This function is use for Demo mode to read PMT
		//Parameters             :   None
		//Time/Date              :   03.02.07
		//Dependencies           :   
		//Author                 :   Sachin Dokhale
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();

		try {
			//#If DEMO Then
			//int	pmtAd(void)
			//{
			//double	abs=0;
			//int	ad;
			//	 abs = (Inst.Pmtv)*1.0/500.0;
			// ad = (int) ((double)2047.0+ abs*(double)4096.0/(double)5.0);
			// ad+=random(100);
			//return ad;
			//}
			//#End If

			double dblabs = 0;
			int intad;
			// Add the ramdomely value of PMT
			dblabs = (gobjInst.PmtVoltage) * 1.0 / 500.0;
			intad = (int)2047.0 + dblabs * 4096.0 / 5.0;
			intad += bytRandom.Next(100);

			return intad;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return 0;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			objWait.Dispose();
			Application.DoEvents();
			//---------------------------------------------------------
		}
		////-----

	}
	////-----

	private int funcLoad_NV_Pos()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcLoad_NV_Pos
		//Description            :   To load needle valve position 
		//Parameters             :   None
		//Return                 :   integer Get from file system
		//Time/Date              :   04.02.07
		//Dependencies           :   
		//Author                 :   
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		//int Load_NV_Pos()
		//{
		//FILE    *stream;
		//char    fname[20];
		//int	  NV;
		//char line7[80];

		//sprintf(fname,"%s.nvp",mname); 

		//stream = fopen(fname, "rb");
		//   if (stream !=NULL){
		//       if (fread(&NV , sizeof(NV), 1, stream)==0)
		//	        NV=0;
		//	    fclose(stream);
		//}
		//return NV;
		//}
		int intNV;
		CWaitCursor objWait = new CWaitCursor();
		System.IO.StreamReader file;
		string words;

		try {
			// Load needle valve position value from file system
			file = new System.IO.StreamReader(Application.StartupPath + "\\nv.nvp");
			words = file.ReadToEnd();
			intNV = (int)Trim(words);
			return intNV;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return 0;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			file.Close();
			objWait.Dispose();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcSave_NV_Pos()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcSave_NV_Pos
		//Description            :   To save needle valve position value
		//Parameters             :   None
		//Return                 :   True if successed Write into file system
		//Time/Date              :   23-Apr-2007
		//Dependencies           :   
		//Author                 :   Mangesh Shardul
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------

		//*********************************************************************
		//---- ORIGINAL CODE
		//*********************************************************************
		//void Save_NV_Pos()
		//{
		//	FILE    *stream;
		//	char    fname[20];

		//   If (!strcmpi(mname, "")) Then
		//	    return;

		//   If (Inst.Nvstep < NVRED) Then
		//		return;

		//	//sprintf(fname,"NV%-s.pos",Inst.El);
		//	sprintf(fname,"%s.nvp",mname); // removed by sss for storing the nv pos against method dt 23/11/2000
		//	stream = fopen(fname, "wb");
		//	if (stream != NULL)
		//	{
		//		fwrite(&Inst.Nvstep, sizeof(Inst.Nvstep), 1, stream);
		//		fclose(stream);
		//	}
		//}
		//*********************************************************************
		CWaitCursor objWait = new CWaitCursor();
		System.IO.StreamWriter file;

		try {
			// save needle valve position value into file system
			if ((gobjInst.NvStep < NVRED)) {
				return false;
			}

			file = new System.IO.StreamWriter(Application.StartupPath + "\\nv.nvp", false);
			file.Write(gobjInst.NvStep);

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
			if (!(file == null)) {
				file.Close();
			}
			file = null;
			objWait.Dispose();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcSave_BH_Pos()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcSave_BH_Pos
		//Description            :   To save burner height position value
		//Parameters             :   None
		//Return                 :   True if successed Write into file system
		//Time/Date              :   04-Jul-2007
		//Dependencies           :   
		//Author                 :   Sachin Dokhale
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------

		//*********************************************************************
		//---- ORIGINAL CODE
		//*********************************************************************
		//        void S4FUNC Save_BH_Pos()
		//{
		//#If !GRAPHITE Then
		//FILE    *stream;
		//char    fname[20];
		// if(!strcmpi(mname,""))
		//	return;
		// if (Inst.Bhstep>MAXBHHOME)
		//	 return ;
		// sprintf(fname,"%s.bhp",mname);
		// stream = fopen(fname, "wb");
		// if (stream != NULL){
		//	fwrite(&Inst.Bhstep, sizeof(Inst.Bhstep), 1, stream);
		//	fclose(stream);
		//  }
		//#End If
		//}
		//*********************************************************************
		CWaitCursor objWait = new CWaitCursor();
		System.IO.StreamWriter file;

		try {
			file = new System.IO.StreamWriter(Application.StartupPath + "\\bh.bhp", false);
			//code added by dinesh wagh on 22.3.2009

			// save burner height position value into file system
			if (gobjInst.BhStep > MAXBHHOME) {
				return true;
			}

			//file = New System.IO.StreamWriter(Application.StartupPath & "\bh.bhp", False) 'code commented by dinesh wagh on 22.3.2009
			file.Write(gobjInst.BhStep);

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
			if (!file == null) {
				file.Close();
				file = null;
			}
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	private int funcCheckNVBurFiles()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcCheckNVBurFiles
		//Description            :   To check nv and bhp files
		//Parameters             :   None
		//Return                 :   Integer 
		//Time/Date              :   04.02.07
		//Dependencies           :   
		//Author                 :   
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		//Int(CheckNvBurFiles(void))
		//{
		//FILE  *stream=NULL;
		//char  fname[20];
		//int   flag=0;
		//sprintf(fname,"%s.nvp",mname);
		//stream = fopen(fname, "rb");
		//if(stream){
		//	flag = 1;
		//	fclose(stream);
		//	stream=NULL;
		//}
		//sprintf(fname,"%s.bhp",mname);
		//stream = fopen(fname, "rb");
		//if(stream){
		//                If (flag) Then
		//	  flag = 3;
		//                Else
		//	  flag = 2;
		//	fclose(stream);
		//	stream=NULL;
		//}
		//return flag;
		//}

		int intFlag;
		CWaitCursor objWait = new CWaitCursor();
		System.IO.File f;
		System.IO.FileStream flStream;

		try {
			// Get NV position from file system
			flStream = f.Open(Application.StartupPath + "\\nv.nvp", IO.FileMode.Open);

			if (!object.ReferenceEquals(flStream, "")) {
				intFlag = 1;
				flStream.Close();
			}
			// Get BH position from file system and set flag
			flStream = f.Open(Application.StartupPath + "\\bh.bhp", IO.FileMode.Open);

			if (!object.ReferenceEquals(flStream, "")) {
				if (intFlag) {
					intFlag = 3;
				} else {
					intFlag = 2;
				}
				flStream.Close();
			}

			return intFlag;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return 0;
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

	private int FuncLoad_BH_Pos()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   FuncLoad_BH_Pos
		//Description            :   To Read Burner height from file system
		//Parameters             :   None
		//Return                 :   Integer
		//Time/Date              :   04.02.07
		//Dependencies           :   
		//Author                 :   Deepak Bhati
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		//int Load_BH_Pos()
		//{
		//FILE    *stream;
		//char    fname[20];
		//int	  BH=-1;

		// sprintf(fname,"%s.bhp",mname);
		// stream = fopen(fname, "rb");
		// if (stream !=NULL){
		//  if(fread(&BH, sizeof(BH), 1, stream)==0)
		//	  BH=-1;
		//            Else
		//	  Inst.Bhstep = BH;
		//  fclose(stream);
		// }
		//return BH;
		//}
		int intBH;
		CWaitCursor objWait = new CWaitCursor();
		System.IO.StreamReader file;
		string words;

		try {
			// Read Burner height from file system
			intBH = -1;
			file = new System.IO.StreamReader(Application.StartupPath + "\\bh.bhp");
			words = file.ReadToEnd();

			if (!Trim(words) == "") {
				intBH = Val(Trim(words));
			} else {
				intBH = -1;
			}

			return intBH;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return -1;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			file.Close();
			objWait.Dispose();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcSet_Last_Fuel(int intNvs)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   FuncLoad_BH_Pos
		//Description            :   To Set Fuel conditions for given steps
		//Parameters             :   intNvs as NV steps
		//Return                 :   True if success
		//Time/Date              :   04.02.07
		//Dependencies           :   
		//Author                 :   Deepak Bhati
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		//void SetLastFuel( int nvs )
		//{
		//int	k;
		//Get_NV_Pos();
		//        If (Inst.Nvstep < nvs) Then
		//  NV_RotateAnticlock_Steps(abs(nvs-Inst.Nvstep));
		//        Else
		//  NV_RotateClock_Steps(abs(Inst.Nvstep-nvs));
		// Get_NV_Pos();
		//}
		int intK;
		Common.CWaitCursor objWait = new Common.CWaitCursor();

		try {
			// Set Fuel conditions for given steps
			funcGet_NV_Pos();

			if (gobjInst.NvStep < intNvs) {
				funcNV_RotateAntiClock_Steps(Math.Abs(intNvs - gobjInst.NvStep));
			} else {
				funcNV_RotateClock_Steps(Math.Abs(gobjInst.NvStep - intNvs));
			}

			funcGet_NV_Pos();

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
			objWait.Dispose();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private bool FuncAIR_N2O()
	{
		//=====================================================================
		// Procedure Name        : FuncAIR_N2O
		// Parameters Passed     : None
		// Returns               : True if success
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 19.08.07
		// Revisions             : 
		//=====================================================================
		//        BOOL(AIR_N2O())
		//{
		// if (GetInstrument()==AA202){
		//	AIR_OFF();
		//	return TRUE;
		//	}
		// else{

		// Transmit(AIRN2O, 0,0, 0);
		//#If NEWHANDSHAKE Then
		// Recev(TRUE);
		//#End If
		// }
		// return ON;
		//}
		byte[] bytArray = new byte[6];
		try {
			// Send the comm. for Air N2O AIRN2O(37)
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				funcAir_OFF();
				return true;
			} else {
				// gblnInComm = True          '10.12.07
				//10.12.07
				if (mobjCommdll.gFuncResumeProcess == false) {
					return false;
				}
				if (FuncTransmitCommand(EnumAAS203Protocol.AIRN2O, 0, 0, 0)) {
					//clsRS232Main.gblnInCommProcess = False

					if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
					}
					clsRS232Main.gblnInCommProcess = false;

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
			gblnInComm = false;
		}
	}

	private bool FuncN2O_AIR()
	{
		//=====================================================================
		// Procedure Name        : FuncN2O_AIR
		// Parameters Passed     : None
		// Returns               : True if success
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 19.08.07
		// Revisions             : 
		//=====================================================================
		//        BOOL(N2O_AIR())
		//{
		// if (GetInstrument()==AA202){
		//	AIR_ON();
		//	return TRUE;
		//  }
		//Transmit(N2OAIR, 0,0, 0);
		//#If NEWHANDSHAKE Then
		// Recev(TRUE);
		//#End If
		// return ON;
		//}
		byte[] bytArray = new byte[6];
		try {
			//Set Air on for 201
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				funcAir_ON();
				return true;
			}
			// gblnInComm = True          '10.12.07
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			// Send command for N2O Air (N2OAIR 38)
			if (FuncTransmitCommand(EnumAAS203Protocol.N2OAIR, 0, 0, 0)) {
				//clsRS232Main.gblnInCommProcess = False

				if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
				}
				clsRS232Main.gblnInCommProcess = false;
			} else {
				return false;
				//10.12.07
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
			gblnInComm = false;
			//---------------------------------------------------------
		}
	}

	public bool funcSwitchOver()
	{
		//=====================================================================
		// Procedure Name        : funcSwitchOver
		// Parameters Passed     : None
		// Returns               : True if success
		// Purpose               : To Switch to N20 Flame
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 19.08.07
		// Revisions             : 
		//=====================================================================
		//        int    S4FUNC Switch_Over()
		//{
		//if (Inst.N2of) {
		//  if (Inst.Na) { AIR_N2O(); Inst.Na = OFF; }
		//  else { N2O_AIR(); Inst.Na = ON;}
		// }
		//else Gerror_message(" Available only for N-A FLAME");
		//return TRUE;
		//}
		try {
			// Switch over from Air to N2O or visa. vasa.
			if (gobjInst.N2of == true) {
				if (gobjInst.Na == true) {
					gobjCommProtocol.FuncAIR_N2O();
					gobjInst.Na = false;
				} else {
					gobjCommProtocol.FuncN2O_AIR();
					gobjInst.Na = true;
				}
			} else {
				gobjMessageAdapter.ShowMessage("Available only for N-A FLAME", "Warning", MessageHandler.clsMessageHandler.enumMessageType.WarningMessage);
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

	#Region " Analysis Related Communication Functions "

	public int ReadADCforFilter()
	{
		//=====================================================================
		// Procedure Name        : ReadADCforFilter
		// Parameters Passed     : None
		// Returns               : Integer value of ADCount
		// Purpose               : Read ADC value from instrument.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 11-Jan-2007
		// Revisions             : 1
		//=====================================================================
		//*******************************************************
		//---ORIGINAL CODE
		//*******************************************************
		//int	S4FUNC ReadADCforFilter()
		//{
		//   int	avg, adval;
		//   avg = Inst.Avg;
		//   Inst.Avg = 5;
		//   adval = ReadADCFilter();
		//#If DEMO Then
		//	adval = pmtAd()+random(10);
		//#End If
		//   Inst.Avg = avg;
		//   return adval;
		//}
		//*******************************************************
		CWaitCursor objWait = new CWaitCursor();
		int intAverage;
		int intADCValue;

		try {
			// Read ADC Value
			intAverage = gobjInst.Average;

			gobjInst.Average = 5;

			funcReadADCFilter(gobjInst.Average, intADCValue);

			//#If DEMO Then
			//	adval = pmtAd() + random(10);
			//#End If

			gobjInst.Average = intAverage;

			return intADCValue;

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

	//Public Function ReadADCFilter() As Integer
	//    '=====================================================================
	//    ' Procedure Name        : ReadADCFilter
	//    ' Parameters Passed     : None
	//    ' Returns               : Integer value of ADCount
	//    ' Purpose               : 
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Mangesh Shardul
	//    ' Created               : 11-Jan-2007
	//    ' Revisions             : 1
	//    '=====================================================================

	//    Try

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

	#End Region

	#End Region

	#Region " Communication Error Handling Functions "

	//Private Sub mobjCommdll_CommError(ByVal intErrorCode As RS232SerialComm.clsRS232Main.CommErrorCode) Handles mobjCommdll.CommError
	//    Dim objWait As New CWaitCursor
	//    Try
	//        Select Case intErrorCode
	//            Case RS232SerialComm.clsRS232Main.CommErrorCode.CommNotOpen
	//                gobjMessageAdapter.ShowMessage(constCommPortError)
	//                Application.DoEvents()
	//                'Commflag = False
	//        End Select

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
	//        Application.DoEvents()
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	#End Region

	#Region " AutoSampler Utility Functions "

	public bool funcAutoSamplerHome()
	{
		//=====================================================================
		// Procedure Name        : funcNV_Rotate_AntiClock
		// Parameters Passed     : None
		// Returns               : Boolean
		// Purpose               : Rotate NV to Anticlock
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokahle
		// Created               : 25.11.06
		// Revisions             : 
		//=====================================================================
		//funcAutoSamplerHome = False
		//Dim bytx As Byte
		//Try
		//    'To add the code for sampler home
		//    ' gstructAutoSampler.blnCommunication = True

		//    gFuncTransmitByte2(Asc("H"))
		//    gFuncReceiveByte2(bytx, glng_LongDelay)
		//    If bytx = Asc("1") Then
		//        'gstructAutoSampler.intCoordinateX = 0
		//        'gstructAutoSampler.intCoordinateY = 0
		//        funcAutoSamplerHome = True
		//    End If

		byte bytRecievedData;

		try {
			// gblnInComm = True          '10.12.07
			Application.DoEvents();
			if (FuncTransmitCommand2(EnumAutoSampler.Home)) {
				if (FuncReceiveData2(bytRecievedData, CONST_LONG_DELAY)) {
					gstructAutoSampler.intCoordinateX = 0;
					gstructAutoSampler.intCoordinateY = 0;
					return true;
				}
			} else {
				MessageBox.Show("error: funcAutoSamplerHome in Transmit");
				Application.DoEvents();
				return false;
			}

			return false;

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
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	internal bool funcAutoSamplerGoTo(byte bytX, byte bytY, structAutoSampler structAutoSamplerIn)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name	    :gfuncAutoSamplerGoTo
		//Description	    :To Position the sampler to spesified Position 
		//Parameters 	    :None
		//Time/Date  	    :23.02.07
		//Dependencies	    :
		//Author		        :Sachin Dokhale
		//Revision		    :
		//Revision by Person	:
		//--------------------------------------------------------------------------------------
		byte bytRecievedData;

		try {
			// gblnInComm = True          '10.12.07

			//To add the code for sampler home
			Application.DoEvents();
			if (structAutoSamplerIn.intCoordinateX == bytX & structAutoSamplerIn.intCoordinateY == bytY) {
				funcAutoSamplerGoTo = true;
				return;
			}

			//gFuncTransmitByte2(Asc("G"))

			if (FuncTransmitCommand2(EnumAutoSampler.GoToXY)) {
				//subTime_Delay(100)
				//Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
				gobjCommProtocol.mobjCommdllAutoSampler.subTime_Delay(100);
				//added by pankaj on 25 Mar 08
				//If bytX > 9 Then
				FuncTransmitCommand2(bytX + Asc("0"));
				//subTime_Delay(100)
				//Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
				gobjCommProtocol.mobjCommdllAutoSampler.subTime_Delay(100);
				//added by pankaj on 25 Mar 08
				//Else
				//    gFuncTransmitByte2(Asc(bytX.ToString))
				//    subTime_Delay(100)
				//End If

				FuncTransmitCommand2(Asc(bytY.ToString));
				//subTime_Delay(100)
				//Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
				gobjCommProtocol.mobjCommdllAutoSampler.subTime_Delay(100);
				//added by pankaj on 25 Mar 08
				//gFuncReceiveByte2(bytRecievedData, glng_LongDelay)
				if (FuncReceiveData2(bytRecievedData, CONST_LONG_DELAY)) {
					if (bytRecievedData == Asc("1")) {
						//gstructAutoSampler.intCoordinateX = bytX
						//gstructAutoSampler.intCoordinateY = bytY
						funcAutoSamplerGoTo = true;
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
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcAutoSamplerProbeDown()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name	    :gfuncAutoSamplerProbeDown
		//Description	    :
		//Parameters 	    :None
		//Time/Date  	    :23.02.07
		//Dependencies	    :
		//Author		        :Sachin Dokhale
		//Revision		    :
		//Revision by Person	:
		//--------------------------------------------------------------------------------------
		byte bytRecievedData;

		try {
			// gblnInComm = True          '10.12.07

			//To add the code for sampler home
			//gFuncTransmitByte2(Asc("D"))
			//gFuncReceiveByte2(bytRecievedData, glng_LongDelay)
			//'Timedelay is provided for keeping
			//'the probe down for Provided Time
			//'subTime_Delay(gstructAutoSampler.intProbeTime * 1000)
			//Call gobjCommProtocol.mobjCommdll.subTime_Delay(gstructAutoSampler.intProbeTime * 1000)
			//If bytRecievedData = Asc("1") Then
			//    funcAutoSamplerProbeDown = True
			//End If

			if (FuncTransmitCommand2(EnumAutoSampler.ProbeDown)) {
				//Call gobjCommProtocol.mobjCommdll.subTime_Delay(gstructAutoSampler.intProbeTime * 1000)
				gobjCommProtocol.mobjCommdllAutoSampler.subTime_Delay(gstructAutoSampler.intProbeTime * 1000);
				//added by pankaj on 25 Mar 08
				if (FuncReceiveData2(bytRecievedData, CONST_LONG_DELAY)) {
					if (bytRecievedData == Asc("1")) {
						funcAutoSamplerProbeDown = true;
					}
				}
			} else {
				MessageBox.Show("error: funcAutoSamplerProbeDown in Transmit");
				Application.DoEvents();
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
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcAutoSamplerProbeUp()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name	    :gfuncAutoSamplerProbeUp
		//Description	    :To Position the sampler Probe to upward Position 
		//Parameters 	    :None
		//Time/Date  	    :23.02.07
		//Dependencies	    :
		//Author		        :Sachin Dokhale
		//Revision		    :
		//Revision by Person	:
		//--------------------------------------------------------------------------------------
		byte bytRecievedData;

		try {
			// gblnInComm = True          '10.12.07

			//To add the code for sampler home
			//gFuncTransmitByte2(Asc("U"))
			//gFuncReceiveByte2(bytRecievedData, glng_LongDelay)
			//If bytRecievedData = Asc("1") Then
			//    funcAutoSamplerProbeUp = True
			//End If


			if (FuncTransmitCommand2(EnumAutoSampler.ProbeUp)) {
				if (FuncReceiveData2(bytRecievedData, CONST_LONG_DELAY)) {
					funcAutoSamplerProbeUp = true;
				}
			} else {
				MessageBox.Show("error: funcAutoSamplerProbeUp  in Transmit");
				Application.DoEvents();
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
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcAutoSamplerPumpOFF()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name	    :gfuncAutoSamplerPumpOFF
		//Description	    :
		//Parameters 	    :None
		//Time/Date  	    :23.02.07
		//Dependencies	    :
		//Author		        :Sachin Dokhale
		//Revision		    :
		//Revision by Person	:
		//--------------------------------------------------------------------------------------
		byte bytRecievedData;

		try {
			// gblnInComm = True          '10.12.07

			//To add the code for sampler home
			//gFuncTransmitByte2(Asc("F"))
			//gFuncReceiveByte2(bytRecievedData, glng_LongDelay)
			//If bytRecievedData = Asc("1") Then
			//    funcAutoSamplerPumpOFF = True
			//End If

			if (FuncTransmitCommand2(EnumAutoSampler.PumpOFF)) {
				if (FuncReceiveData2(bytRecievedData, CONST_LONG_DELAY)) {
					if (bytRecievedData == Asc("1")) {
						funcAutoSamplerPumpOFF = true;
					}
				}
			} else {
				MessageBox.Show("error: funcAutoSamplerPumpOFF in Transmit");
				Application.DoEvents();
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
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcAutoSamplerPumpON()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name	    :gfuncAutoSamplerPumpON
		//Description	    :
		//Parameters 	    :None
		//Time/Date  	    :23.02.07
		//Dependencies	    :
		//Author		        :Sachin Dokhale
		//Revision		    :
		//Revision by Person	:
		//--------------------------------------------------------------------------------------
		byte bytRecievedData;

		try {
			// gblnInComm = True          '10.12.07

			//To add the code for sampler home
			//gFuncTransmitByte2(Asc("O"))
			//gFuncReceiveByte2(bytRecievedData, glng_LongDelay)
			//If bytRecievedData = Asc("1") Then
			//    funcAutoSamplerPumpON = True
			//End If

			if (FuncTransmitCommand2(EnumAutoSampler.PumpON)) {
				if (FuncReceiveData2(bytRecievedData, CONST_LONG_DELAY)) {
					if (bytRecievedData == Asc("1")) {
						funcAutoSamplerPumpON = true;
					}
				}
			} else {
				MessageBox.Show("error: funcAutoSamplerPumpON  in Transmit");
				Application.DoEvents();
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
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcAutoSamplerPumpONRev()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name	    :gfuncAutoSamplerPumpONRev
		//Description	    :
		//Parameters 	    :None
		//Time/Date  	    :23.02.07
		//Dependencies	    :
		//Author		        :Sachin Dokhale
		//Revision		    :
		//Revision by Person	:
		//--------------------------------------------------------------------------------------
		byte bytRecievedData;
		try {
			// gblnInComm = True          '10.12.07

			//To add the code for sampler home
			//gFuncTransmitByte2(Asc("V"))
			//gFuncReceiveByte2(bytRecievedData, glng_LongDelay)
			//If bytRecievedData = Asc("1") Then
			//    funcAutoSamplerPumpONRev = True
			//End If

			if (FuncTransmitCommand2(EnumAutoSampler.PumpONRev)) {
				if (FuncReceiveData2(bytRecievedData, CONST_LONG_DELAY)) {
					if (bytRecievedData == Asc("1")) {
						funcAutoSamplerPumpONRev = true;
					}
				}
			} else {
				MessageBox.Show("error: funcAutoSamplerPumpONRev in Transmit");
				Application.DoEvents();
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
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	#End Region

	#Region " Functions for Double Beam "

	public bool gFuncAnalogSelfTest_ReferenceBeam(int intAvgOfADCReadings, ref double dblADCValue = 0.0)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   gFuncAnalogSelfTest_ReferenceBeam
		//Description            :   To perform a test for ADC count and voltage. if voltage comes 
		//                           around 3000 mv then test is successful else test fails
		//Parameters             :   intAvgOfADCReadings,dblADCValue
		//Return                 :   True if success
		//Time/Date              :   14-Apr-2007
		//Dependencies           :   obviously PC must communicate with Instrument through COM port
		//Author                 :   Mangesh Shardul
		//Revision               :
		//Revision by Person     :   
		//--------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		int intADCFmv = 0;

		try {
			if (funcCalibrationMode(EnumCalibrationMode.SELFTEST, enumInstrumentBeamType.ReferenceBeam)) {
				if (intAvgOfADCReadings == 1) {
					if (funcReadADCFilter_ReferenceBeam(intAvgOfADCReadings, intADCFmv)) {
						if (intADCFmv == 5000) {
							return false;
							gobjMessageAdapter.ShowMessage(constADCNonFilter);
							Application.DoEvents();
						} else {
							return true;
						}
					} else {
						return false;
					}
				} else {
					if (funcReadADCFilter_ReferenceBeam(intAvgOfADCReadings, intADCFmv)) {
						if (intADCFmv > 3255 & intADCFmv < 3296) {
							dblADCValue = intADCFmv;
							return true;
						} else {
							return false;
							gobjMessageAdapter.ShowMessage(constADCFilter);
							Application.DoEvents();
						}
					} else {
						return false;
					}
				}
			} else {
				return false;
			}

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
			objWait.Dispose();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcSet_PMTReferenceBeam(double dblReferencePMTVoltage)
	{
		//------------------------------------------------------------------
		//Procedure Name         :   funcSet_PMTReferenceBeam
		//Description            :   To set PMT voltage for Reference Beam
		//Parameters             :   dblPMT : Reference PMT voltage to be set
		//Return                 :   True if success
		//Time/Date              :   06-Apr-2007
		//Dependencies           :   
		//Author                 :   Mangesh S.
		//Revision               :
		//Revision by Person     :   
		//------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];
		double dbly1;
		int inty;
		byte bytLow;
		byte bytHigh;
		int intPMT;
		//++++++++++++++++++++++++++++++++++++++++++++++
		//void	S4FUNC Set_PMT(double pmt) 
		//{
		//double	y1;
		//int	y;
		// Inst.Pmtv = pmt;
		// y1 = (double) ( (double) Inst.Pmtv*(double)4095.0/(double)1000.0);
		// y = (int) y1;
		// y = y & 0x0fff;
		// Transmit(PMT, (BYTE) y, (BYTE) (y>>8), 0);
		// pc_delay(1000);
		// Recev(TRUE);
		//}
		//++++++++++++++++++++++++++++++++++++++++++++++
		double dblPMTTemp;

		try {
			//gobjInst.PmtVoltageReference = dblReferencePMTVoltage  '10.12.07

			dblPMTTemp = dblReferencePMTVoltage;
			dblPMTTemp = dblPMTTemp * 4095.0 / 1000.0;
			intPMT = (int)dblPMTTemp;
			intPMT = (int)intPMT & 0xfff;

			gFunclongtobyte(intPMT, bytLow, bytHigh);
			//bytLow = CByte(inty)
			//bytHigh = CByte(inty >> 8)
			// gblnInComm = True          '10.12.07
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			if (FuncTransmitCommand(EnumAAS203Protocol.SETPMT_RB, bytLow, bytHigh, 0)) {
				if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						gobjMessageAdapter.ShowMessage(constPMTVolt);
						Application.DoEvents();
					} else {
						gobjInst.PmtVoltageReference = dblReferencePMTVoltage;
						//10.12.07
						return true;
					}
				} else {
					gobjMessageAdapter.ShowMessage(constPMTVolt);
					Application.DoEvents();
				}
			} else {
				//gobjMessageAdapter.ShowMessage(constPMTVolt)
				Application.DoEvents();
			}

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
			gblnInComm = false;
			objWait.Dispose();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcExitSlit_Home()
	{
		//------------------------------------------------------------------
		//Procedure Name         :   funcExitSlit_Home
		//Description            :   To make the Exit Slit indicater home        
		//Parameters             :   None
		//Return                 :   True if success
		//Time/Date              :   06-Apr-2007
		//Dependencies           :   
		//Author                 :   Mangesh S.
		//Revision               :
		//Revision by Person     :   
		//------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];
		int intErrorSlitHome;
		try {
			if (gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam) {
				intErrorSlitHome = constErrorSlitHome;
			} else {
				intErrorSlitHome = constErrorExitSlitHome;
			}
			// gblnInComm = True          '10.12.07

			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}

			if (FuncTransmitCommand(EnumAAS203Protocol.SLIT_HOME_EXIT, 0, 0, 0)) {
				if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						//Call gobjMessageAdapter.ShowMessage(constErrorSlitHome)
						gobjMessageAdapter.ShowMessage(intErrorSlitHome);
						Application.DoEvents();
					} else {
						if (bytArray(2)) {
							gobjInst.SlitPositionExit = 0;
							return true;
						} else {
							//Call gobjMessageAdapter.ShowMessage(constErrorSlitHome)
							gobjMessageAdapter.ShowMessage(intErrorSlitHome);
							Application.DoEvents();
							return false;
						}
					}
				} else {
					//Call gobjMessageAdapter.ShowMessage(constErrorSlitHome)
					gobjMessageAdapter.ShowMessage(intErrorSlitHome);
					Application.DoEvents();
					return false;
				}
			} else {
				//Call gobjMessageAdapter.ShowMessage(constErrorSlitHome)
				//Call gobjMessageAdapter.ShowMessage(intErrorSlitHome)
				return false;
			}

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
			gblnInComm = false;
			objWait.Dispose();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcEntryExitSlit_Home()
	{
		//------------------------------------------------------------------
		//Procedure Name         :   funcEntryExitSlit_Home
		//Description            :   To make the both Entry and Exit Slit indicater home        
		//Parameters             :   None
		//Return                 :   True if success
		//Time/Date              :   07-Apr-2007
		//Dependencies           :   
		//Author                 :   Mangesh S.
		//Revision               :
		//Revision by Person     :   
		//------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];

		try {
			// gblnInComm = True          '10.12.07
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			if (FuncTransmitCommand(EnumAAS203Protocol.SLIT_HOME_DB, 0, 0, 0)) {
				if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						gobjMessageAdapter.ShowMessage(constErrorSlitHome);
					} else {
						if (bytArray(2)) {
							gobjInst.SlitPositionExit = 0;
							return true;
						} else {
							gobjMessageAdapter.ShowMessage(constErrorSlitHome);
							Application.DoEvents();
							return false;
						}
					}
				} else {
					gobjMessageAdapter.ShowMessage(constErrorSlitHome);
					Application.DoEvents();
					return false;
				}
			} else {
				//Call gobjMessageAdapter.ShowMessage(constErrorSlitHome)
				return false;
			}

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
			gblnInComm = false;
			objWait.Dispose();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcReadADCFilter_ReferenceBeam(int intNumOfReadingsForAvg, ref int intAvgInMv)
	{
		//--------------------------------------------------------------------------------------
		//Procedure Name         :   funcReadADCFilter_ReferenceBeam
		//Description            :   to read ADC count for filtered data for Reference Beam
		//Parameters             :   intNumOfReadingsForAvg : no of readings taken for averaging
		//                           [OUT] intAvgInmv : avg. of ADC count return
		//Return                 :   True if success
		//Time/Date              :   06-Apr-2007
		//Dependencies           :   obviously PC must communicate with Instrument through COM port
		//Author                 :   Mangesh Shardul
		//Revision               :
		//Revision by Person     :   
		//--------------------------------------------------------------------------------------
		byte[] bytArray = new byte[6];
		byte bytLow;
		byte bytHigh;
		//++++++++++++++++++++++++++
		//int	S4FUNC ReadADCFilter()
		//{
		//int  i=5000;

		// if (Inst.Avg==1)
		//	return ReadADC();

		// Transmit(ADCF, (BYTE) Inst.Avg, (BYTE) (Inst.Avg>>8), 0);
		//            If (Recev(True)) Then
		//	i = Param2*256 + Param1;
		//#If DEMO Then
		//  pc_delay(10000);   pc_delay(10000);
		//  pc_delay(10000);  pc_delay(10000);
		//	i= pmtAd()+random(10);
		//#End If
		//#If QDEMO Then
		//	i= pmtAd()+random(100);
		//#End If
		// if (i==5000)
		//  Gerror_message_new("ADC Error ","System Error");
		//return(i);
		//}
		//++++++++++++++++++++++++++

		try {
			gFunclongtobyte(intNumOfReadingsForAvg, bytLow, bytHigh);

			//If gobjInst.Average = 1 Then
			//    Return funcReadADCNonFilter_ReferenceBeam(intAvgInMv)
			//End If
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			if (FuncTransmitCommand(EnumAAS203Protocol.ADCFILTER_RB, bytLow, bytHigh, 0)) {
				if (FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						return false;
						gobjMessageAdapter.ShowMessage(constADCFilter);
						Application.DoEvents();
					} else {
						intAvgInMv = bytArray(2) + (bytArray(3) * 256);
						////----- Added by Sachin Dokhale for Demo mode
						//#If DEMO Then
						//	i= pmtAd()+random(10);
						//#End If
						//If gstructSettings.AppMode = EnumAppMode.DemoMode Then
						if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
							intAvgInMv = funcpmtAd() + bytRandom.Next(10);
						}
						////-----
						if (intAvgInMv == 5000) {
							//MessageBox.Show("ADC Error", "System Error")
							gobjMessageAdapter.ShowMessage(constADCFilter);
						}
						return true;
					}
				} else {
					return false;
					//gobjMessageAdapter.ShowMessage(constADCFilter) '28.09.07
					//Application.DoEvents()                         '28.09.07
				}
			} else {
				return false;
				//gobjMessageAdapter.ShowMessage(constADCFilter) '28.09.07
				//Application.DoEvents()                         '28.09.07
			}

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

	public bool funcReadADCFilter_DoubleBeam(int intNumOfReadingsForAvg, ref int intAvgInMv)
	{
		//--------------------------------------------------------------------------------------
		//Procedure Name         :   funcReadADCFilter_DoubleBeam
		//Description            :   to read ADC count for filtered data for Double Beam
		//Parameters             :   intNumOfReadingsForAvg : no of readings taken for averaging
		//                           [OUT] intAvgInmv : avg. of ADC count return
		//Return                 :   True if success
		//Time/Date              :   07-Apr-2007
		//Dependencies           :   obviously PC must communicate with Instrument through COM port
		//Author                 :   Mangesh Shardul
		//Revision               :
		//Revision by Person     :   
		//--------------------------------------------------------------------------------------
		byte[] bytArray = new byte[6];
		byte bytLow;
		byte bytHigh;
		//++++++++++++++++++++++++++
		//int	S4FUNC ReadADCFilter()
		//{
		//int  i=5000;

		// if (Inst.Avg==1)
		//	return ReadADC();

		// Transmit(ADCF, (BYTE) Inst.Avg, (BYTE) (Inst.Avg>>8), 0);
		//            If (Recev(True)) Then
		//	i = Param2*256 + Param1;
		//#If DEMO Then
		//  pc_delay(10000);   pc_delay(10000);
		//  pc_delay(10000);  pc_delay(10000);
		//	i= pmtAd()+random(10);
		//#End If
		//#If QDEMO Then
		//	i= pmtAd()+random(100);
		//#End If
		// if (i==5000)
		//  Gerror_message_new("ADC Error ","System Error");
		//return(i);
		//}
		//++++++++++++++++++++++++++

		try {
			gFunclongtobyte(intNumOfReadingsForAvg, bytLow, bytHigh);

			//If gobjInst.Average = 1 Then
			//    Return funcReadADCNonFilter_ReferenceBeam(intAvgInMv)
			//End If
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			if (FuncTransmitCommand(EnumAAS203Protocol.ADCFILTER_DB, bytLow, bytHigh, 0)) {
				if (FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						return false;
						gobjMessageAdapter.ShowMessage(constADCFilter);
						Application.DoEvents();
					} else {
						intAvgInMv = bytArray(2) + (bytArray(3) * 256);
						////----- Added by Sachin Dokhale for Demo mode
						//#If DEMO Then
						//	i= pmtAd()+random(10);
						//#End If
						//If gstructSettings.AppMode = EnumAppMode.DemoMode Then
						if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
							intAvgInMv = funcpmtAd() + bytRandom.Next(10);
						}
						////-----
						if (intAvgInMv == 5000) {
							//MessageBox.Show("ADC Error", "System Error")
							gobjMessageAdapter.ShowMessage(constADCFilter);

						}
						return true;
					}
				} else {
					return false;
					gobjMessageAdapter.ShowMessage(constADCFilter);
					Application.DoEvents();
				}
			} else {
				return false;
				//gobjMessageAdapter.ShowMessage(constADCFilter)
				//Application.DoEvents()
			}

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

	public int funcReadADCforFilter_DoubleBeam()
	{
		//=====================================================================
		// Procedure Name        : funcReadADCforFilter_DoubleBeam
		// Parameters Passed     : None
		// Returns               : Integer value of ADCount
		// Purpose               : Read ADC filter value for Double beam
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 07-Apr-2007
		// Revisions             : 1
		//=====================================================================
		//*******************************************************
		//---ORIGINAL CODE
		//*******************************************************
		//int	S4FUNC ReadADCforFilter()
		//{
		//   int	avg, adval;
		//   avg = Inst.Avg;
		//   Inst.Avg = 5;
		//   adval = ReadADCFilter();
		//#If DEMO Then
		//	adval = pmtAd()+random(10);
		//#End If
		//   Inst.Avg = avg;
		//   return adval;
		//}
		//*******************************************************
		CWaitCursor objWait = new CWaitCursor();
		int intAverage;
		int intADCValue;

		try {
			intAverage = gobjInst.Average;

			gobjInst.Average = 5;

			funcReadADCFilter_DoubleBeam(gobjInst.Average, intADCValue);

			gobjInst.Average = intAverage;

			return intADCValue;

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
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcGetAbsOffset()
	{
		//=====================================================================
		// Procedure Name        : funcGetAbsOffset
		// Parameters Passed     : None
		// Returns               : True or false
		// Purpose               : Set Abs offset 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 07-Apr-2007 04:25 pm
		// Revisions             : 1
		//=====================================================================
		byte[] bytArray = new byte[6];

		try {
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			if (FuncTransmitCommand(EnumAAS203Protocol.GET_Absoffset, 0, 0, 0)) {
				if (FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						gobjMessageAdapter.ShowMessage(constErrorGettingAbsOffset);
						Application.DoEvents();
						return false;
					} else {
						return true;
					}
				} else {
					gobjMessageAdapter.ShowMessage(constErrorAbsReceiving);
					Application.DoEvents();
					return false;
				}
			} else {
				//Call gobjMessageAdapter.ShowMessage(constErrorAbsTransmit)
				//Call Application.DoEvents()
				return false;
			}

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

	public bool funcGetRefBaseVal()
	{
		//=====================================================================
		// Procedure Name        : funcGetRefBaseVal
		// Parameters Passed     : None
		// Returns               : True or false
		// Purpose               : Get the Ref. base value.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 07-Apr-2007 05:15 pm
		// Revisions             : 1
		//=====================================================================
		byte[] bytArray = new byte[6];

		try {
			// gblnInComm = True          '10.12.07
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			if (FuncTransmitCommand(EnumAAS203Protocol.Get_RefBaseVal, 0, 0, 0)) {
				if (FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						gobjMessageAdapter.ShowMessage(constErrorGettingAbsOffset);
						Application.DoEvents();
						return false;
					} else {
						return true;
					}
				} else {
					gobjMessageAdapter.ShowMessage(constErrorAbsReceiving);
					Application.DoEvents();
					return false;
				}
			} else {
				//Call gobjMessageAdapter.ShowMessage(constErrorAbsTransmit)
				//Call Application.DoEvents()
				return false;
			}

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
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcResetReferenceBeam()
	{
		//=====================================================================
		// Procedure Name        : funcResetReferenceBeam
		// Parameters Passed     : None
		// Returns               : True or false
		// Purpose               : To initialise refernce beam monitoring controller
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 07-Apr-2007 05:15 pm
		// Revisions             : 1
		//=====================================================================
		byte[] bytArray = new byte[6];

		try {
			//10.12.07
			if (mobjCommdll.gFuncResumeProcess == false) {
				return false;
			}
			mobjCommdll.IsNeedReceive = false;
			if (FuncTransmitCommand(EnumAAS203Protocol.RESET_RB, 0, 0, 0)) {
				if (FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY)) {
					if (bytArray(1) != 1) {
						//blnIsSingleBeam = True
						gobjMessageAdapter.ShowMessage(constErrorInitRefBeam);
						Application.DoEvents();
						return false;
					} else {
						//blnIsSingleBeam = False
						return true;
					}
				} else {
					gobjMessageAdapter.ShowMessage(constErrorAbsReceiving);
					Application.DoEvents();
					return false;
				}
			} else {
				//Call gobjMessageAdapter.ShowMessage(constErrorAbsTransmit)
				//Call Application.DoEvents()
				return false;
			}

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

	public bool funcPosition_Slit_Exit(int intSlit)
	{
		//------------------------------------------------------------------
		//Procedure Name         :   funcPosition_Slit_Exit
		//Description            :   To position the slit at the said width
		//Parameters             :   intSlit : position at which slit to be adjusted
		//Return                 :   True if success
		//Time/Date              :   07-Apr-2007
		//Dependencies           :   obviously PC must communicate with Instrument through COM port
		//Author                 :   Mangesh Shardul
		//Revision               :
		//Revision by Person     :   
		//------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];
		byte bytSlitWidth1;
		int intSlitWidthError;
		//------------------------
		//void   S4FUNC Position_Slit(int sw)
		//{
		//BYTE  sw1;
		//hold = Load_Curs();
		// if (Inst.Slitpos!=sw) {
		//	 sw1 = (BYTE) sw;
		//	 Transmit(SLITPOS, sw1, 0 , 0);
		//	 Inst.Slitpos =sw;
		//	 Recev(TRUE);
		// }
		//SetCursor(hold);
		//}
		//------------------------
		try {
			if (gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam) {
				intSlitWidthError = constSlitWidthError;
			} else {
				intSlitWidthError = constExitSlitWidthError;
			}

			if (gobjInst.SlitPositionExit != intSlit) {
				bytSlitWidth1 = (byte)intSlit;
				// gblnInComm = True          '10.12.07
				//10.12.07
				if (mobjCommdll.gFuncResumeProcess == false) {
					return false;
				}
				if (FuncTransmitCommand(EnumAAS203Protocol.SLIT_POS_EXIT, bytSlitWidth1, 0, 0)) {
					if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
						if (bytArray(1) != 1) {
							gobjMessageAdapter.ShowMessage(intSlitWidthError);
							Application.DoEvents();
							return false;
						} else {
							gobjInst.SlitPositionExit = intSlit;
							return true;
						}
					} else {
						gobjMessageAdapter.ShowMessage(intSlitWidthError);
						Application.DoEvents();
						return false;
					}
				} else {
					//gobjMessageAdapter.ShowMessage(intSlitWidthError)
					//Application.DoEvents()
					return false;
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
			gblnInComm = false;
			objWait.Dispose();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public bool funcPosition_Slit_EntryExit(int intSlit)
	{
		//---------------------------------------------------------------------------
		//Procedure Name         :   funcPosition_Slit_EntryExit
		//Description            :   To position the slit at the said width
		//Parameters             :   intSlit : position at which slit to be adjusted
		//Return                 :   True if success
		//Time/Date              :   07-Apr-2007
		//Dependencies           :   obviously PC must communicate with Instrument through COM port
		//Author                 :   Mangesh Shardul
		//Revision               :
		//Revision by Person     :   
		//---------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		byte[] bytArray = new byte[6];
		byte bytSlitWidth1;
		//------------------------
		//void   S4FUNC Position_Slit(int sw)
		//{
		//BYTE  sw1;
		//hold = Load_Curs();
		// if (Inst.Slitpos!=sw) {
		//	 sw1 = (BYTE) sw;
		//	 Transmit(SLITPOS, sw1, 0 , 0);
		//	 Inst.Slitpos =sw;
		//	 Recev(TRUE);
		// }
		//SetCursor(hold);
		//}
		//------------------------
		try {
			if (gobjInst.SlitPosition != intSlit) {
				bytSlitWidth1 = (byte)intSlit;
				// gblnInComm = True          '10.12.07
				//10.12.07
				if (mobjCommdll.gFuncResumeProcess == false) {
					return false;
				}
				if (FuncTransmitCommand(EnumAAS203Protocol.SLIT_POS_DB, bytSlitWidth1, 0, 0)) {
					if (FuncReceiveData(bytArray, CONST_LONG_DELAY)) {
						if (bytArray(1) != 1) {
							gobjMessageAdapter.ShowMessage(constSlitWidthError);
							Application.DoEvents();
							return false;
						} else {
							gobjInst.SlitPosition = intSlit;
							gobjInst.SlitPositionExit = intSlit;
							return true;
						}
					} else {
						gobjMessageAdapter.ShowMessage(constSlitWidthError);
						Application.DoEvents();
						return false;
					}
				} else {
					//gobjMessageAdapter.ShowMessage(constSlitWidthError)
					//Application.DoEvents()
					return false;
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
			gblnInComm = false;
			objWait.Dispose();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	#End Region

	#Region " Functions for AAS 201 "

	public bool gFuncAnalogSelfTest_AA201(int intAvgOfADCReadings, ref double dblADCValue = 0.0)
	{
		//---------------------------------------------------------------------------------------
		//Procedure Name         :   gFuncAnalogSelfTest_AA201
		//Description            :   To perform a test for ADC count and voltage. if voltage comes 
		//                           around 3000 mv then test is successful else test fails
		//Parameters             :   intAvgOfADCReadings,dblADCValue
		//Retrun                 :   True if Comm. success
		//Time/Date              :   11-Apr-2007
		//Dependencies           :   obviously PC must communicate with Instrument through COM port
		//Author                 :   Mangesh Shardul
		//Revision               :
		//Revision by Person     :   
		//---------------------------------------------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		int intADCFmv = 0;

		try {
			if (funcCalibrationMode(EnumCalibrationMode.SELFTEST)) {
				if (intAvgOfADCReadings == 1) {
					if (funcReadADCNonFilter(intADCFmv)) {
						if (intADCFmv == 5000) {
							return false;
							gobjMessageAdapter.ShowMessage(constADCNonFilter);
							Application.DoEvents();
						} else {
							return true;
						}
					} else {
						return false;
					}
				} else {
					if (funcReadADCFilter(intAvgOfADCReadings, intADCFmv)) {
						if (intADCFmv > 3000 & intADCFmv < 3296) {
							dblADCValue = intADCFmv;
							return true;
						} else {
							return false;
							gobjMessageAdapter.ShowMessage(constADCFilter);
							Application.DoEvents();
						}
					} else {
						return false;
					}
				}
			} else {
				return false;
			}

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
			objWait.Dispose();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}


	#End Region

}
