 // ERROR: Not supported in C#: OptionDeclaration
using BgThread;
using AAS203.Common;
using System.IO;

public class clsBgSpectrum : BgThread.IBgWorker
{

	#Region " Private Variables "


	private bool mblnIsDemoFileOpened = false;
	//Private mlblObjWV_ABS As System.Object
	//Private mlblObjAbs_RefBeam_ABS As System.Object
	//Private mlblObjABS_DoubleBeam As System.Object
	//Private mlblObjStatus As System.Object
	private Label mlblObjWV_ABS;
	private Label mlblObjAbs_RefBeam_ABS;
	private Label mlblObjABS_DoubleBeam;

	private Label mlblObjStatus;
	private bool mblnIsRefBeamSelected;
	private int mintMode;
	private int mintSpeed;
	private double mdblMinWavelength;
	private double mdblMaxWavelength;
	private double mdblYMaxValue;
	private double mdblYMinValue;
	private bool mbln_BaseLine;
	private double mdblAbsScanthldval;
	private bool mblnCheckMinAbsScanLmt;

	private bool mCheckAbsLimit = true;
	private IBgThread mobjThreadController;
	private double mdblLampCurrent;

	private int mintLampPosition;
	private bool mblnSpectrumWait = false;

	private bool mblnThTerminate = false;
	private const  const_Absorbance = "Absorbance: ";
	private const  const_Energy = "Energy: ";
	private const  const_Emission = "Emission: ";

	private const  const_Volt = "Volt(mv): ";
	private string mYValueLable = const_Absorbance;
	private string mXValueLable = "Wavelength (nm): ";
	private bool blnResetFilterData;
		#End Region
	bool mblnEndProcess = false;

	#Region " Public Property "

	public bool ThTerminate {
		get { return mblnThTerminate; }
		set {
			mblnThTerminate = Value;
			mblnSpectrumWait = Value;
		}
	}

	public bool SpectrumWait {
		get { return mblnSpectrumWait; }
		set { mblnSpectrumWait = Value; }
	}

	public bool EndProcess {
		get { return mblnEndProcess; }
		set { mblnEndProcess = Value; }
	}

	public bool CheckAbsLimit {
		get { return mCheckAbsLimit; }
		set { mCheckAbsLimit = Value; }
	}

	#End Region

	#Region " Public Events "

	public event  SpectrumStatus;

	#End Region

	#Region " Constructors "

	public clsBgSpectrum()
	{
		base.New();
		ThTerminate = false;
		SpectrumWait = false;
	}

	public clsBgSpectrum(ref System.Object lblObjStatusIn, ref System.Object lblObjWV_ABSIn, double dblXMax, double dblXMin, double dblYMax, double dblYMin, int intMode, double intSpeed, bool blnBaseLine = false)
	{
		//=====================================================================
		// Procedure Name        : New 
		// Parameters Passed     : dblXMax, dblXMin, dblYMax, dblYMin, intMode, intSpeed ,blnBaseLine
		// Parameter Affected    : lblObjStatusIn,lblObjWV_ABSIn
		// Returns               : None
		// Purpose               : New [Constructor]
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.12.06
		// Revisions             : 
		//=====================================================================
		base.New();
		mlblObjStatus = lblObjStatusIn;
		mlblObjWV_ABS = lblObjWV_ABSIn;
		mdblMaxWavelength = dblXMax;
		mdblMinWavelength = dblXMin;
		mdblYMinValue = dblYMin;
		mdblYMaxValue = dblYMax;
		mintMode = intMode;
		mintSpeed = intSpeed;
		mbln_BaseLine = blnBaseLine;
		ThTerminate = false;
		SpectrumWait = false;

		//added by deepak on 20.10.08
		mdblAbsScanthldval = gstructSettings.AbsThresholdValue;
		mblnCheckMinAbsScanLmt = gstructSettings.SetMinAbsLimit;

	}

	//--added new constructor by deepak on 20.07.07
	public clsBgSpectrum(ref Label lblObjStatusIn, ref Label lblObjWV_ABSIn, double dblXMax, double dblXMin, double dblYMax, double dblYMin, int intMode, double intSpeed, double intNothing, bool blnIsRef,
	bool blnBaseLine = false)
	{
		//=====================================================================
		// Procedure Name        : New 
		// Parameters Passed     : dblXMax, dblXMin, dblYMax, dblYMin, intMode, intSpeed,
		//                         blnIsRef, blnBaseLine
		// Parameter Affected    : lblObjStatusIn,lblObjWV_ABSIn
		// Returns               : None
		// Purpose               : New [Constructor]
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : deepak
		// Created               : 21.12.06
		// Revisions             : 
		//=====================================================================

		base.New();
		mlblObjStatus = lblObjStatusIn;
		mlblObjWV_ABS = lblObjWV_ABSIn;
		mdblMaxWavelength = dblXMax;
		mdblMinWavelength = dblXMin;
		mdblYMinValue = dblYMin;
		mdblYMaxValue = dblYMax;
		mintMode = intMode;
		mintSpeed = intSpeed;
		mbln_BaseLine = blnBaseLine;
		ThTerminate = false;
		SpectrumWait = false;
		mblnIsRefBeamSelected = blnIsRef;

		//added by deepak on 20.10.08
		mdblAbsScanthldval = gstructSettings.AbsThresholdValue;
		mblnCheckMinAbsScanLmt = gstructSettings.SetMinAbsLimit;

	}

	public clsBgSpectrum(ref Label lblObjStatusIn, ref Label lblObjWV_ABSIn, double dblXMax, double dblXMin, double dblYMax, double dblYMin, int intMode, double intSpeed, double dblAbsScanthldval, double blnCheckMinAbsScanLmt)
	{
		//=====================================================================
		// Procedure Name        : New 
		// Parameters Passed     : dblXMax, dblXMin, dblYMax, dblYMin, intMode, intSpeed,
		//                         blnIsRef, blnBaseLine
		// Parameter Affected    : lblObjStatusIn,lblObjWV_ABSIn
		// Returns               : None
		// Purpose               : New [Constructor]
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : deepak
		// Created               : 21.12.06
		// Revisions             : 
		//=====================================================================

		base.New();

		mlblObjStatus = lblObjStatusIn;
		mlblObjWV_ABS = lblObjWV_ABSIn;
		mdblMaxWavelength = dblXMax;
		mdblMinWavelength = dblXMin;
		mdblYMinValue = dblYMin;
		mdblYMaxValue = dblYMax;
		mintMode = intMode;
		mintSpeed = intSpeed;
		mbln_BaseLine = false;
		mdblAbsScanthldval = dblAbsScanthldval;
		mblnCheckMinAbsScanLmt = blnCheckMinAbsScanLmt;
		gintSpectrumMode = modGlobalDeclarations.EnumSpectrumMode.TimeScan;
		ThTerminate = false;
		SpectrumWait = false;

	}

	#End Region

	#Region " Public Functions "

	public void BgThread.IBgWorker.Initialize(BgThread.IBgThread Controller)
	{
		mobjThreadController = Controller;
	}

	public void BgThread.IBgWorker.StartWorkerThread()
	{
		//=====================================================================
		// Procedure Name        : StartWorkerThread
		// Parameters Passed     :  
		// Returns               : BgThread.IBgWorker.Start
		// Purpose               : Start to thread process.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.12.06
		// Revisions             : 
		//=====================================================================
		bool blnCancel = false;
		CWaitCursor objwait = new CWaitCursor();
		string strPreviousStatusMessage;
		//'note:
		//'this is a main function which called by thread.
		try {
			if (!IsNothing(gobjMain)) {
				strPreviousStatusMessage = gobjMain.StatusBarPanelInfo.Text;
			}
			ThTerminate = false;
			mblnEndProcess = true;
			while ((blnCancel == false)) {
				if (mobjThreadController.Running) {
					//funcThreadSpectrum(mdblLampCurrent, mintLampPosition)
					if (gintSpectrumMode == modGlobalDeclarations.EnumSpectrumMode.EnergySpectrum) {
						////----- Added by Sachin Dokhale on 25.03.07
						////----- To know the Status of Thread on Status Bar of MDI Main

						if (gblnShowThreadOnfrmMDIStatusBar) {
							if (!IsNothing(gobjMain)) {
								gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage + " *Energy Spec";
							}
							Application.DoEvents();
						}
						////-----
						if (gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam) {
							//added by deepak on 20.07.07

							//'check a cond for double beam.
							funcThreadDBEnergySpectrum_AccToBeamSelection(mlblObjStatus, mlblObjWV_ABS, mdblMaxWavelength, mdblMinWavelength, mdblYMaxValue, mdblYMinValue, mintMode, mintSpeed, 0, mblnIsRefBeamSelected);
						} else {
							funcThreadEnergySpectrum(mlblObjStatus, mlblObjWV_ABS, mdblMaxWavelength, mdblMinWavelength, mdblYMaxValue, mdblYMinValue, mintMode, mintSpeed, 0);

							//'this will start the energy as par given parameter
							//'for eg mintSpeed is for spectrum speed.
						}
						blnCancel = true;

					} else if (gintSpectrumMode == modGlobalDeclarations.EnumSpectrumMode.UVSpetrum) {
						////----- Added by Sachin Dokhale on 25.03.07
						////----- To know the Status of Thread on Status Bar of MDI Main
						if (gblnShowThreadOnfrmMDIStatusBar) {
							if (!IsNothing(gobjMain)) {
								gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage + " *UV Spec";
							}
							Application.DoEvents();
							//'allow application to perfrom its panding work between 
							//'the thread.
						}
						////-----
						funcThreadUVSpectrum(mlblObjStatus, mlblObjWV_ABS, mdblMaxWavelength, mdblMinWavelength, mdblYMaxValue, mdblYMinValue, mintMode, mintSpeed, 0, mbln_BaseLine);
						//'this will start a UV spectrum 

						//End If
						blnCancel = true;

					} else if (gintSpectrumMode == modGlobalDeclarations.EnumSpectrumMode.TimeScan) {
						////----- Added by Sachin Dokhale on 25.03.07
						////----- To know the Status of Thread on Status Bar of MDI Main
						if (gblnShowThreadOnfrmMDIStatusBar) {
							if (!IsNothing(gobjMain)) {
								gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage + " *TimeScan";
							}
							Application.DoEvents();
						}
						////-----
						blnResetFilterData = true;
						if (gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam) {
							funcThreadDBAbsTimeScan(mlblObjStatus, mlblObjWV_ABS, mdblMaxWavelength, mdblMinWavelength, mdblYMaxValue, mdblYMinValue, mintMode, mdblAbsScanthldval, mblnCheckMinAbsScanLmt);

						} else {
							funcThreadAbsTimeScan(mlblObjStatus, mlblObjWV_ABS, mdblMaxWavelength, mdblMinWavelength, mdblYMaxValue, mdblYMinValue, mintMode, mdblAbsScanthldval, mblnCheckMinAbsScanLmt);
						}
						blnCancel = true;
					}
				} else {
					//Client requested a cancel

					blnCancel = true;
					////----- Added by Sachin Dokhale on 25.03.07
					////----- To remove the Status of Thread on Status Bar of MDI Main
					if (gblnShowThreadOnfrmMDIStatusBar) {
						if (!IsNothing(gobjMain)) {
							gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage;
						}
						Application.DoEvents();
					}
					////-----
					return;
				}

			}
			blnCancel = true;
			if (mobjThreadController.Running == true) {
				////----- modified by Sachin Dokhale on 01.09.07
				if (gintSpectrumMode == modGlobalDeclarations.EnumSpectrumMode.UVSpetrum) {
					// Check the property for interuption from user to terminate the process
					if (ThTerminate == true) {
						mobjThreadController.Completed(false);
					} else {
						mobjThreadController.Completed(true);
					}
				} else {
					mobjThreadController.Completed(true);
				}
			////------
			} else {
			}
			////----- Added by Sachin Dokhale on 25.03.07
			////----- To remove the Status of Thread on Status Bar of MDI Main
			if (gblnShowThreadOnfrmMDIStatusBar) {
				if (!IsNothing(gobjMain)) {
					gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage;
				}
				Application.DoEvents();
				//'allow application to perfrom its panding work.
			}
		////-----
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			//mobjThreadController.Failed(ex)
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

	#Region " Private Functions "

	#Region " Sample Beam "
	private bool funcThreadEnergySpectrum(ref Label lblObjStatusIn, ref Label lblObjWV_ABSIn, double dblXMax, double dblXMin, double dblYMax, double dblYMin, int intMode, int intSpeed, int intCounter)
	{
		//------------------------------------------------------------------
		//Procedure Name         :   funcThreadEnergySpectrum
		//Description            :   To Start the Spectrum
		//Parameters             :   dblLampCurrent = current to be set to lamp
		//                           intLampPos = lamp position to which current to be set
		//Time/Date              :   5/10/06
		//Dependencies           :   
		//Author                 :   Sachin Dokhale.
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		//------------------------------------------------
		//        void		OnSpect(HWND	hwnd, BOOL BaseLine)
		//{
		//HDC	hdc;

		//WP1=-1;
		// addata.Saved=FALSE;;
		// disp_Cur_wv_abs(hwnd);
		// hdc= GetDC(hwnd);

		// Wavelength_Position(hdc,SpectGraph.Xmin, 20, 372 );
		// if (UVS){

		//	if (!UVABS){
		//	  UVABS=TRUE;
		//	  SpectGraph.Ymin = 0;
		//	  SpectGraph.Ymax = 1.0;
		//	  Scroll_Mode1(hwnd,IDC_MODE, -1 );
		//	 }

		//	if (Inst->d2Pmt==0){
		//		Adj_D2Gain(hwnd, TRUE, 15, 372);
		//		Wavelength_Position(hdc,SpectGraph.Xmin, 20, 372 );
		//	  }
		//	UvSpectReading(hwnd, hdc, BaseLine);
		//  }
		//                Else

		//	Transmit(CONNECT_SPL, (BYTE)0, (BYTE) 0, (BYTE) 0);
		//                    If (Recev(True)) Then
		//	{
		//	SpectReading(hwnd, hdc);
		//	Wavelength_Position(hdc,SpectGraph.Xmin, 20, 372 );
		//	}
		//	Transmit(CONNECT_REF, (BYTE)0, (BYTE) 0, (BYTE) 0);
		//                        If (Recev(True)) Then
		//	{
		//	  SpectReadingRef(hwnd, hdc);
		//	  Wavelength_Position(hdc,SpectGraph.Xmin, 20, 372 );
		//	  Transmit(CONNECT_SPL, (BYTE)0, (BYTE) 0, (BYTE) 0);
		//                            If (Recev(True)) Then
		//	  {
		//	  }
		//	}

		// ReleaseDC(hwnd,hdc);
		// disp_Cur_wv_abs(hwnd);
		//}
		//------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		double dblWv;
		double dblYNew;
		double dblYNew1;
		double blYasisReading;
		bool blnStartSpec;
		int intSpeedIncrease;
		int intIniMode;
		double dblCurrWv;
		int intSetpsPernm = 50;
		double dblWvMin;
		int intTimeDelay = 40;
		OpenFileDialog objOpenFile;
		//---16.03.08
		Spectrum.Channel objchannel;
		//---16.03.08
		try {
			CWaitCursor objWait1 = new CWaitCursor();
			Application.DoEvents();
			////----- 1  Set Wv '& Abs/En

			dblWvMin = dblXMin;
			mXValueLable = "Wavelength (nm): ";
			switch (gobjInst.Mode) {
				case EnumCalibrationMode.AA:
					mYValueLable = const_Absorbance;
				case EnumCalibrationMode.AA:
				case EnumCalibrationMode.AABGC:
				case EnumCalibrationMode.MABS:
					mYValueLable = "Absorbance : ";
				case EnumCalibrationMode.HCLE:
				case EnumCalibrationMode.D2E:
					mYValueLable = const_Energy;
				case EnumCalibrationMode.EMISSION:
					mYValueLable = const_Emission;
				case EnumCalibrationMode.SELFTEST:
					mYValueLable = const_Volt;
			}

			////----- Display Current Wavelength
			//16.03.08
			if (gblnIsDemoWithRealData == false) {
				if (gobjCommProtocol.funcGet_Current_Wv(dblCurrWv) == true) {
					//mobjThreadController.Display(dblCurrWv.ToString & "|" & "0.0")
					lblObjStatusIn.Text = mXValueLable + dblCurrWv.ToString;
					lblObjStatusIn.Refresh();
					lblObjWV_ABSIn.Text = mYValueLable + "0.0";
					lblObjWV_ABSIn.Refresh();
				} else {
					//mobjThreadController.Display("Error" & "|" & "0.0")
					lblObjStatusIn.Text = mXValueLable;
					lblObjStatusIn.Refresh();
					lblObjWV_ABSIn.Text = mYValueLable;
					lblObjWV_ABSIn.Refresh();
				}
			}

			////----------------
			// Set wv. position 
			//16.03.08
			if (gblnIsDemoWithRealData == false) {
				gobjCommProtocol.Wavelength_Position(dblWvMin, lblObjStatusIn);
			}
			//gobjCommProtocol.mobjCommdll.subTime_Delay(80)

			// Check the property for interuption from user to terminate the process
			if (ThTerminate == true) {
				goto ExitSpectrum;
			}

			//--- 3. Set the Speed
			intCounter = 0;
			////----- Set cal. Mode
			intIniMode = gobjInst.Mode;
			gobjInst.Mode = intMode;
			////---------------

			//16.03.08
			if (gblnIsDemoWithRealData == false) {
				//--- Display Current Wavelength
				if (gobjCommProtocol.funcGet_Current_Wv(dblCurrWv) == true) {
					//mobjThreadController.Display(dblCurrWv.ToString & "|" & "0.0")
					lblObjStatusIn.Text = mXValueLable + dblCurrWv.ToString;
					lblObjStatusIn.Refresh();
					lblObjWV_ABSIn.Text = mYValueLable + "0.0";
					lblObjWV_ABSIn.Refresh();
				} else {
					//mobjThreadController.Display("Error" & "|" & "0.0")
					lblObjStatusIn.Text = mXValueLable;
					lblObjStatusIn.Refresh();
					lblObjWV_ABSIn.Text = mYValueLable;
					lblObjWV_ABSIn.Refresh();
				}
				////----------------
			}

			//---4. Cal. Wv & Abs/En
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				intSetpsPernm = CONST_STEPS_PER_NM_AA201;
				//CONST_STEPS_PER_NM 
			} else {
				intSetpsPernm = CONST_STEPS_PER_NM;
			}

			//--- calculate Max Wv. stpes
			dblWv = dblXMax * (double)intSetpsPernm + 0.1;
			//--- Check Wv sptes is greater than sptes per NM 
			if (dblWv >= (double)intSpeed) {
				//dblWv =  dblXMax * intSetpsPernm + 0.1
				dblWv = dblXMax;

				if (gobjCommProtocol.funcReadADCFilter(10, dblYNew) == false) {
					return false;
				}
				//gobjCommProtocol.mobjCommdll.subTime_Delay(100)
				////----- Get Abs/ En Value
				//abs = GetADConvertedToCurMode(ynew);

				blYasisReading = gFuncGetADConvertedToCurMode(dblYNew);


				//---16.03.08
				if (gblnIsDemoWithRealData == true) {
					int intCount;
					string strSelectedElement;
					if (mblnIsDemoFileOpened == false) {
						objOpenFile = new OpenFileDialog();
						strSelectedElement = LCase(gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).ElementName);
						strSelectedElement = Application.StartupPath + "\\Spectrums\\" + strSelectedElement + ".ens";
						objOpenFile.FileName = strSelectedElement;
						if ((objOpenFile.CheckFileExists())) {
							objchannel = gfuncDeSerializeObject(objOpenFile.FileName, EnumDeserializeObjType.EnergySpectrum);
							mblnIsDemoFileOpened = true;
						}
					}

					if (!objchannel == null) {
						for (intCount = 0; intCount <= objchannel.Spectrums(0).Readings.Count - 1; intCount++) {
							if (dblXMin == objchannel.Spectrums(0).Readings.item(intCount).XaxisData) {
								dblYNew = objchannel.Spectrums(0).Readings.item(intCount).YaxisADCData;
								blYasisReading = objchannel.Spectrums(0).Readings.item(intCount).YaxisData;
								break; // TODO: might not be correct. Was : Exit For
							}
						}
					}
				}
				//---16.03.08


				//mobjThreadController.Display(dblXMin.ToString & "|" & blYasisReading.ToString)
				mobjThreadController.Display(dblXMin.ToString + "|" + blYasisReading.ToString + "|" + dblYNew.ToString);
				Application.DoEvents();
				//--- Check the property for interuption from user to terminate the process
				if (ThTerminate == true) {
					goto ExitSpectrum;
				}

				//--- Start to Spectrum
				//x1 = (wvnew * StepPerNm) + 0.1
				//i = CInt(x1)

				//bytLow = CByte(i And &HFF)
				//bytHigh = CByte(i >> 8)
				//SpectGraph.Xmax* (double) stepspernm+(double)0.1
				bool blnResumeNext = false;

				dblWv = dblXMax * (double)intSetpsPernm + 0.1;
				blnStartSpec = gobjCommProtocol.funcStartSpectrum(dblWv, intSpeed);
				if (blnStartSpec == true) {
					gblnInComm = false;
					while ((true)) {
						if ((mblnEndProcess == true)) {
							//AndAlso (clsRS232Main.gblnInCommProcess = False)
							//If gblnInComm = False Then
							//--- Received scan data 
							if (gobjCommProtocol.funcReceive_ScanData(0, dblYNew) == true) {
								//If (dblYNew = 6000) Then
								if ((dblYNew == 6000)) {
									break; // TODO: might not be correct. Was : Exit Do
								}

								//dblYNew = dblYNew1
								//--- For Demo Mode
								//#If DEMO Then
								//		ynew=ReadADCFilter();
								//#End If
								//If gstructSettings.AppMode = EnumAppMode.DemoMode Then
								if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
									gobjCommProtocol.funcReadADCFilter(gobjInst.Average, dblYNew);
								}
								////-----
								intSpeedIncrease += intSpeed;
								dblWv = dblXMin + (double)intSpeedIncrease / (double)intSetpsPernm;
								////----- Get Abs/ En Value
								//abs = GetADConvertedToCurMode(ynew); 
								blYasisReading = gFuncGetADConvertedToCurMode(dblYNew);
								//--- Send the data to the screen by '|' seperated

								//---16.03.08
								if (gblnIsDemoWithRealData == true) {
									int intCount;
									if (!objchannel == null) {
										for (intCount = 0; intCount <= objchannel.Spectrums(0).Readings.Count - 1; intCount++) {
											if (dblWv == objchannel.Spectrums(0).Readings.item(intCount).XaxisData) {
												dblYNew = objchannel.Spectrums(0).Readings.item(intCount).YaxisADCData;
												blYasisReading = objchannel.Spectrums(0).Readings.item(intCount).YaxisData;
												break; // TODO: might not be correct. Was : Exit For
											}
										}
									}
									if (dblWv > dblXMax) {
										break; // TODO: might not be correct. Was : Exit Do
									}
								}
								//---16.03.08

								mblnEndProcess = false;
								mobjThreadController.Display(dblWv.ToString + "|" + blYasisReading.ToString + "|" + dblYNew.ToString);
								Application.DoEvents();
								gobjCommProtocol.mobjCommdll.subTime_Delay(intTimeDelay);
								Application.DoEvents();
								funcThreadEnergySpectrum = true;

								//--- Check the property for interuption from user to terminate the process
								if (ThTerminate == true) {
									if (gobjMessageAdapter.ShowMessage(constExitEnergyScan) == true) {
										Application.DoEvents();
										if (gobjCommProtocol.funcBreakSpectrum() == false) {
											break; // TODO: might not be correct. Was : Exit Do
										} else {
											break; // TODO: might not be correct. Was : Exit Do
										}
									} else {
										Application.DoEvents();
										ThTerminate = false;
									}

								}

								//gobjCommProtocol.mobjCommdll.subTime_Delay(100)  
								//Application.DoEvents()
								//--- Send PC_END Command
								if (gobjCommProtocol.funcPC_END() == false) {
									break; // TODO: might not be correct. Was : Exit Do
								}

							//gobjCommProtocol.mobjCommdll.subTime_Delay(80)  
							//Application.DoEvents()
							//funcThreadEnergySpectrum = True
							} else {
								break; // TODO: might not be correct. Was : Exit Do
							}
							//Else
							//blnResumeNext = True

						}
						if (!mobjThreadController.Running) {
							break; // TODO: might not be correct. Was : Exit Do
						}

						//Application.DoEvents()
						//If (gstructSettings.AppMode = EnumAppMode.DemoMode) Then
						if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
							gobjCommProtocol.mobjCommdll.subTime_Delay(100);
							//Application.DoEvents()
						}

					}
				}
			}
			ExitSpectrum:


			////-----   Set Wv '& Abs/En
			//Wavelength_Position(hdc, SpectGraph.Xmin, 20, 372)
			gobjCommProtocol.mobjCommdll.subTime_Delay(20);
			Application.DoEvents();
			//16.03.08
			if (gblnIsDemoWithRealData == false) {
				gobjCommProtocol.Wavelength_Position(dblWvMin, lblObjStatusIn);
			}
			gobjCommProtocol.mobjCommdll.subTime_Delay(20);
			//--- Display Current Wavelength
			gobjCommProtocol.mobjCommdll.subTime_Delay(20);
			//16.03.08
			if (gblnIsDemoWithRealData == false) {

				if (gobjCommProtocol.funcGet_Current_Wv(dblCurrWv) == true) {
					lblObjStatusIn.Text = mXValueLable + dblCurrWv.ToString;
					lblObjStatusIn.Refresh();
					lblObjWV_ABSIn.Text = mYValueLable + "0.0";
					lblObjWV_ABSIn.Refresh();

				} else {
					lblObjStatusIn.Text = mXValueLable;
					lblObjStatusIn.Refresh();
					lblObjWV_ABSIn.Text = mYValueLable;
					lblObjWV_ABSIn.Refresh();
				}
			}
			////----------------
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
			ThTerminate = false;
			SpectrumWait = false;
		}
	}

	private bool funcThreadUVSpectrum(ref System.Object lblObjStatusIn, ref System.Object lblObjWV_ABSIn, double dblXMax, double dblXMin, double dblYMax, double dblYMin, int intMode, int intSpeed, int intCounter, bool bln_BaseLine)
	{
		//------------------------------------------------------------------
		//Procedure Name         :   funcThreadUVSpectrum
		//Description            :   Start the process for UV Spectrum
		//Affected Parameters    :   lblObjStatusIn,lblObjWV_ABSIn as label on form
		//Parameters             :   As Above
		//Return                 :   True if success.
		//Time/Date              :   5/10/06
		//Dependencies           :   
		//Author                 :   Sachin Dokhale.
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------

		CWaitCursor objWait = new CWaitCursor();
		double dblWv;
		double dblMaxWv;
		double dblYNew;
		double blYasisReading;
		double blYasisADCReading;

		bool blnStartSpec;
		int intSpeedIncrease;
		int intIniMode;
		double dblCurrWv;
		int MAXSIZE;
		int intsamp_adcCounter;
		double dblWvMin;
		string strMsg;
		int intTimeDelay = 20;


		try {
			Application.DoEvents();

			CWaitCursor objWait1 = new CWaitCursor();
			////----- 1  Set Wv '& Abs/En
			//Wavelength_Position(hdc, SpectGraph.Xmin, 20, 372)

			dblWvMin = dblXMin;
			mXValueLable = "Wavelength (nm): ";
			switch (gobjInst.Mode) {
				case EnumCalibrationMode.AA:
				case EnumCalibrationMode.AABGC:
				case EnumCalibrationMode.MABS:
					mYValueLable = const_Absorbance;
				case EnumCalibrationMode.HCLE:
				case EnumCalibrationMode.D2E:
					mYValueLable = const_Energy;
				case EnumCalibrationMode.EMISSION:
					mYValueLable = const_Emission;
				case EnumCalibrationMode.SELFTEST:
					mYValueLable = const_Volt;
			}

			////----- Display Current Wavelength
			if (gobjCommProtocol.funcGet_Current_Wv(dblCurrWv) == true) {
				lblObjStatusIn.text = mXValueLable + dblCurrWv.ToString;
				lblObjStatusIn.refresh();
				lblObjWV_ABSIn.text = mYValueLable + "0.0";
				lblObjWV_ABSIn.refresh();
			} else {
				lblObjStatusIn.text = mXValueLable;
				lblObjStatusIn.refresh();
				lblObjWV_ABSIn.text = mYValueLable;
				lblObjWV_ABSIn.refresh();
			}
			////----------------
			gobjCommProtocol.Wavelength_Position(dblWvMin, lblObjStatusIn);
			//'position the wavelength
			//gobjCommProtocol.mobjCommdll.subTime_Delay(100)
			//'delay
			//--- Check the property for interuption from user to terminate the process
			if (ThTerminate == true) {
				goto ExitSpectrum;
			}


			//--- 2. Set the Steps
			int intSetpsPernm = 50;
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				intSetpsPernm = CONST_STEPS_PER_NM_AA201;
			} else {
				intSetpsPernm = CONST_STEPS_PER_NM;
			}

			//--- 3. Set the Speed
			intCounter = 0;
			if ((intSpeed == 0)) {
				intSpeed = CONST_STEPS_PER_NM;
			}
			//--- Set cal. Mode

			intIniMode = gobjInst.Mode;
			gobjInst.Mode = intMode;
			gblnUVABS = true;

			////---------------
			////----- Calculate the size of Ref Adc value
			//MAXSIZE = (unsigned)  (  (((SpectGraph.Xmax-SpectGraph.Xmin)*stepspernm)/ (double) speed) +1.0 );
			//MAXSIZE = CInt((((dblXMax - dblXMin) * CONST_STEPS_PER_NM) / CDbl(intSpeed)) + 1.0)
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				MAXSIZE = (int)(((dblXMax - dblXMin) * CONST_STEPS_PER_NM_AA201) / (double)intSpeed) + 1.0;
			} else {
				MAXSIZE = (int)(((dblXMax - dblXMin) * CONST_STEPS_PER_NM) / (double)intSpeed) + 1.0;
			}

			//--- Check array for Baseline to reset
			if (bln_BaseLine == true) {
				gintSample_adc = null;
				gintSample_adc = null;
				 // ERROR: Not supported in C#: ReDimStatement

			}

			intsamp_adcCounter = 0;
			//--- Display Current Wavelength
			if (gobjCommProtocol.funcGet_Current_Wv(dblCurrWv) == true) {
				lblObjStatusIn.text = mXValueLable + dblCurrWv.ToString;
				lblObjStatusIn.refresh();
				lblObjWV_ABSIn.text = mYValueLable + "0.0";
				lblObjWV_ABSIn.refresh();
			} else {
				lblObjStatusIn.text = mXValueLable;
				lblObjStatusIn.refresh();
				lblObjWV_ABSIn.text = mYValueLable;
				lblObjWV_ABSIn.refresh();
			}
			////----------------
			//---4. Cal. Wv & Abs/En
			dblMaxWv = dblXMax * (double)intSetpsPernm + 0.1;
			gobjCommProtocol.mobjCommdll.subTime_Delay(intTimeDelay);
			Application.DoEvents();
			if (dblMaxWv >= (double)intSpeed) {
				//dblWv =  dblXMax * intSetpsPernm + 0.1
				dblWv = dblXMax;
				//If gobjCommProtocol.funcReadADCFilter(10, dblYNew) = False Then
				if (gobjCommProtocol.funcReadADCFilter(5, dblYNew) == false) {
					//'read the ADC value.
					return false;
				}
				//--- Get Abs/ En Value
				//abs = GetADConvertedToCurMode(ynew); 

				//--- Check spectrum value for Baseline
				if (bln_BaseLine == true) {
					if (IsNothing(gintSample_adc) == false) {
						if ((gintSample_adc.Length > 0) & (gintSample_adc.Length > intsamp_adcCounter)) {
							gintSample_adc(intsamp_adcCounter) = dblYNew;
						}
					}
					blYasisReading = gfuncGetConvertToUVAbs(dblYNew, dblYNew);
					intsamp_adcCounter += 1;
				} else {
					if (IsNothing(gintSample_adc) == false) {
						if (gintSample_adc.Length > 0 & (gintSample_adc.Length > intsamp_adcCounter)) {
							blYasisReading = gfuncGetConvertToUVAbs(dblYNew, gintSample_adc(intsamp_adcCounter));
							intsamp_adcCounter += 1;
						}
					} else {
						goto ExitSpectrum;
					}
				}


				if (bln_BaseLine) {
					strMsg = constExitBaseLine;
				} else {
					strMsg = constExitUV;
				}
				// Check the property for interuption from user to terminate the process
				if (ThTerminate == true) {
					goto ExitSpectrum;
				}
				//blYasisReading = gFuncGetADConvertedToCurMode(dblYNew)
				mobjThreadController.Display(dblXMin.ToString + "|" + blYasisReading.ToString + "|" + blYasisReading.ToString);

				////---- Start to Spectrum
				//x1 = (wvnew * StepPerNm) + 0.1
				//i = CInt(x1)

				//bytLow = CByte(i And &HFF)
				//bytHigh = CByte(i >> 8)
				//SpectGraph.Xmax* (double) stepspernm+(double)0.1

				//dblWv = dblXMax * CDbl(intSetpsPernm) + 0.1
				blnStartSpec = gobjCommProtocol.funcStartSpectrum(dblMaxWv, intSpeed);

				if (blnStartSpec == true) {
					gblnInComm = false;
					while ((true)) {
						if (mblnEndProcess == true & gblnInComm == false) {
							if (gobjCommProtocol.funcReceive_ScanData(0, dblYNew) == true) {
								////----- For Demo Mode
								//#If DEMO Then
								//		ynew = random(4096);
								//#End If
								//If gstructSettings.AppMode = EnumAppMode.DemoMode Then
								if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
									dblYNew = gRandom.Next(4096);
								}

								if ((dblYNew == 6000)) {
									break; // TODO: might not be correct. Was : Exit Do
								}

								////----- For Demo Mode
								//#If DEMO Then
								//		ynew=ReadADCFilter();
								//#End If
								//If gstructSettings.AppMode = EnumAppMode.DemoMode Then
								//    Call gobjCommProtocol.funcReadADCFilter(gobjInst.Average, dblYNew)
								//End If
								////-----

								intSpeedIncrease += intSpeed;
								dblWv = dblXMin + (double)intSpeedIncrease / (double)intSetpsPernm;

								////----- For Demo Mode
								//#If DEMO Then
								//		if (wv>=SpectGraph.Xmax ||addata.counter>= MAXSIZE)
								//		  break;
								//#End If
								//If gstructSettings.AppMode = EnumAppMode.DemoMode Then
								if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
									if (((dblWv >= mdblMaxWavelength) | (dblWv <= mdblMinWavelength))) {
										break; // TODO: might not be correct. Was : Exit Do
									}
									gobjCommProtocol.funcReadADCFilter(gobjInst.Average, dblYNew);
								}

								if ((dblYNew == 4095)) {
									//Gerror_message_new("Full scale overflow, Reduce PMT/D2cur", "UV SPECTRUM");
									//PostMessage(hwnd, WM_COMMAND, IDC_START, 0);
									gobjInst.D2Pmt = 0;
								}

								////----- Get Abs/ En Value
								// Check spectrum value for Baseline
								if (bln_BaseLine == true) {
									if (gintSample_adc.Length > 0) {
										gintSample_adc(intsamp_adcCounter) = dblYNew;
									}
									blYasisReading = gfuncGetConvertToUVAbs(dblYNew, dblYNew);
									intsamp_adcCounter += 1;
								} else {
									if (gintSample_adc.Length > 0) {
										blYasisReading = gfuncGetConvertToUVAbs(dblYNew, gintSample_adc(intsamp_adcCounter));
										intsamp_adcCounter += 1;
									}
									//if (addata.ad && addata.counter<MAXSIZE)
									//    addata.ad[addata.counter++]=ynew;
								}
								mblnEndProcess = false;
								//--- Send the data to the screen by '|' seperated
								//mobjThreadController.Display(dblWv.ToString & "|" & blYasisReading.ToString)
								//commented by deepak on 04.09.07 and added following line
								mobjThreadController.Display(dblWv.ToString + "|" + blYasisReading.ToString + "|" + blYasisReading.ToString);
								//04.09.07
								//Saurabh
								gobjCommProtocol.mobjCommdll.subTime_Delay(intTimeDelay);
								// Check the property for interuption from user to terminate the process
								if (ThTerminate == true) {
									if (gobjMessageAdapter.ShowMessage(strMsg) == true) {
										Application.DoEvents();
										if (gobjCommProtocol.funcBreakSpectrum() == false) {
											break; // TODO: might not be correct. Was : Exit Do
										} else {
											break; // TODO: might not be correct. Was : Exit Do
										}
									} else {
										Application.DoEvents();
										ThTerminate = false;
									}
								}
								//Saurabh

								//gobjCommProtocol.mobjCommdll.subTime_Delay(80)
								// Send the PC_END protocol
								if (gobjCommProtocol.funcPC_END() == false) {
									break; // TODO: might not be correct. Was : Exit Do
								}
								gobjCommProtocol.mobjCommdll.subTime_Delay(intTimeDelay);
								Application.DoEvents();
								//Application.DoEvents()
								funcThreadUVSpectrum = true;
							} else {
								break; // TODO: might not be correct. Was : Exit Do
							}
						}
						if (!mobjThreadController.Running) {
							break; // TODO: might not be correct. Was : Exit Do
						}

						//If (gstructSettings.AppMode = EnumAppMode.DemoMode) Then
						if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
							gobjCommProtocol.mobjCommdll.subTime_Delay(100);
							Application.DoEvents();
						}
					}
				}
			}
			ExitSpectrum:

			////-----   Set Wv '& Abs/En
			//Wavelength_Position(hdc, SpectGraph.Xmin, 20, 372)

			gobjCommProtocol.Wavelength_Position(dblWvMin, lblObjStatusIn);
			gobjCommProtocol.mobjCommdll.subTime_Delay(intTimeDelay);
			Application.DoEvents();
			intsamp_adcCounter = 0;
			////----- Display Current Wavelength
			if (gobjCommProtocol.funcGet_Current_Wv(dblCurrWv) == true) {
				lblObjStatusIn.text = mXValueLable + dblCurrWv.ToString;
				lblObjStatusIn.refresh();
				lblObjWV_ABSIn.text = mYValueLable + "0.0";
				lblObjWV_ABSIn.refresh();

			} else {
				lblObjStatusIn.text = mXValueLable;
				lblObjStatusIn.refresh();
				lblObjWV_ABSIn.text = mYValueLable;
				lblObjWV_ABSIn.refresh();
			}
			////----------------
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
			//---------------------------------------------------------
			//ThTerminate = False
			SpectrumWait = false;
		}
	}

	private bool funcThreadAbsTimeScan(ref System.Object lblObjStatusIn, ref System.Object lblObjWV_ABSIn, double dblXMax, double dblXMin, double dblYMax, double dblYMin, int intMode, double dblAbsScanthldval, bool blnCheckMinAbsScanLmt)
	{
		//------------------------------------------------------------------
		//Procedure Name         :   funcThreadAbsTimeScan
		//Description            :   Start the process for Timescan
		//Affected Parameters    :   lblObjStatusIn,lblObjWV_ABSIn as label on form
		//Parameters             :   As Above
		//Return                 :   True if success.
		//Time/Date              :   5/10/06
		//Dependencies           :   
		//Author                 :   Sachin Dokhale.
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		//------------------------------------------------

		//------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		long CEnd1;
		long CEnd;
		//Dim ConstManipulate As Long = 1000
		long ConstManipulate = 10000000;
		double dblAbs;

		double dblXaxisTime1;
		////----- Data Filter DEclearation
		static double Xn_2 = 0;
		static double Xn_1 = 0;
		static double Yn_1 = 0;
		static double Yn_2 = 0;
		static double filtdata = 0;
		static int intCal_Mode;
		double[,] xcoeff1002 = {
			{
				0.067455,
				0.134911,
				0.067455
			},
			{
				0.020083,
				0.040167,
				0.020083
			},
			{
				0.003622,
				0.007243,
				0.003622
			},
			{
				0.000945,
				0.001889,
				0.000945
			},
			{
				3.9E-05,
				7.8E-05,
				3.9E-05
			},
			{
				1E-05,
				2E-05,
				1E-05
			}
		};
		double[,] ycoeff1002 = {
			{
				1.14298,
				-0.412802
			},
			{
				1.56102,
				-0.641352
			},
			{
				1.8227,
				-0.837182
			},
			{
				1.9112,
				-0.914976
			},
			{
				1.98223,
				-0.982385
			},
			{
				1.99111,
				-0.991154
			}
		};
		////-----

		try {
			Application.DoEvents();

			CWaitCursor objWait1 = new CWaitCursor();
			////----- 1  Set Wv '& Abs/En
			lblObjStatusIn.text = mXValueLable + dblXMax.ToString;
			lblObjStatusIn.refresh();
			lblObjWV_ABSIn.text = mYValueLable + "0.0";
			lblObjWV_ABSIn.refresh();
			////----------------
			gobjClsAAS203.ReInitInstParameters();
			CEnd1 = System.DateTime.Now.Ticks;

			mblnEndProcess = true;
			while ((!ThTerminate == true)) {
				if (!SpectrumWait == true) {
					if (!(CEnd == CEnd1)) {
						Application.DoEvents();
						//--- Read Abs. Data
						if (!SpectrumWait == true) {
							dblAbs = gobjClsAAS203.funcGetAbsScanX;
						}
						//--- Smooth the ADC data
						if ((gblnSmoothFilter == true)) {
							filtdata = xcoeff1002(gintTimeConstant, 0) * dblAbs;
							filtdata += xcoeff1002(gintTimeConstant, 1) * Xn_1;
							filtdata += xcoeff1002(gintTimeConstant, 2) * Xn_2;
							filtdata += ycoeff1002(gintTimeConstant, 0) * Yn_1;
							filtdata += ycoeff1002(gintTimeConstant, 1) * Yn_2;
							Xn_2 = Xn_1;
							Xn_1 = dblAbs;
							Yn_2 = Yn_1;
							Yn_1 = filtdata;
							dblAbs = filtdata;
						}
						//--- Check the Min Absorbance limits
						if (blnCheckMinAbsScanLmt == true) {
							if ((dblAbs < dblAbsScanthldval)) {
								dblAbs = 0.0;
							}
						}
						//--- Read Time clock
						CEnd = System.DateTime.Now.Ticks;
						dblXaxisTime1 = ((CEnd - CEnd1) / ConstManipulate);


						if (mblnEndProcess == true) {
							mblnEndProcess = false;
							mobjThreadController.Display(dblXaxisTime1.ToString + "|" + dblAbs.ToString);
							gobjClsAAS203.funcCheck_Flame();
							//30.12.08
						}
						//--- Check for Demo Mode
						//If (gstructSettings.AppMode = EnumAppMode.DemoMode) Then
						if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
							gobjCommProtocol.mobjCommdll.subTime_Delay(200);
							//Application.DoEvents()
						}
					} else {
						//--- Read Time clock
						CEnd = System.DateTime.Now.Ticks;
						//Application.DoEvents()
					}
				} else {
					//--- Read Time clock
					CEnd = System.DateTime.Now.Ticks;
				}
			}

			lblObjStatusIn.text = mXValueLable + Format(dblXaxisTime1, "###0.0##").ToString;
			lblObjStatusIn.refresh();
			lblObjWV_ABSIn.text = mYValueLable + "0.0";
			lblObjWV_ABSIn.refresh();
			funcThreadAbsTimeScan = true;
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
			ThTerminate = false;
			SpectrumWait = false;
			Application.DoEvents();
		}
	}

	#End Region

	#Region " Double  Beam "
	////----- Not in use funcThreadDBEnergySpectrum
	private bool funcThreadDBEnergySpectrum(ref System.Object lblObjStatusIn, ref System.Object lblObjWV_ABSIn, double dblXMax, double dblXMin, double dblYMax, double dblYMin, int intMode, int intSpeed, int intCounter)
	{
		//------------------------------------------------------------------
		//Procedure Name         :   funcThreadDBEnergySpectrum
		//Description            :   Start the process for Energy Spectrum of bouble beam
		//Affected Parameters    :   lblObjStatusIn,lblObjWV_ABSIn as label on form
		//Parameters             :   dblXMax,dblXMin,dblYMax,dblYMin,intMode,intSpeed,intCounter
		//Return                 :   True if success.
		//Time/Date              :   06.04.07
		//Dependencies           :   
		//Author                 :   Sachin Dokhale.
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------

		CWaitCursor objWait = new CWaitCursor();
		double dblWv;
		double dblYNew;
		double blYasisReading;
		bool blnStartSpec;
		int intSpeedIncrease;
		int intIniMode;
		double dblCurrWv;
		int intSetpsPernm = 50;
		double dblWvMin;

		try {
			Application.DoEvents();

			CWaitCursor objWait1 = new CWaitCursor();
			////----- 1  Set Wv '& Abs/En
			//Wavelength_Position(hdc, SpectGraph.Xmin, 20, 372)

			dblWvMin = dblXMin;
			mXValueLable = "Wavelength (nm): ";
			switch (gobjInst.Mode) {
				//'set a y-axis label as par calibration mode
				case EnumCalibrationMode.AA:
					mYValueLable = const_Absorbance;
				case EnumCalibrationMode.AA:
				case EnumCalibrationMode.AABGC:
				case EnumCalibrationMode.MABS:
					mYValueLable = "Absorbance : ";
				case EnumCalibrationMode.HCLE:
				case EnumCalibrationMode.D2E:
					mYValueLable = const_Energy;
				case EnumCalibrationMode.EMISSION:
					mYValueLable = const_Emission;
				case EnumCalibrationMode.SELFTEST:
					mYValueLable = const_Volt;
			}

			////----- Display Current Wavelength
			if (gobjCommProtocol.funcGet_Current_Wv(dblCurrWv) == true) {
				//mobjThreadController.Display(dblCurrWv.ToString & "|" & "0.0")
				lblObjStatusIn.text = mXValueLable + dblCurrWv.ToString;
				lblObjStatusIn.refresh();
				lblObjWV_ABSIn.text = mYValueLable + "0.0";
				lblObjWV_ABSIn.refresh();
			} else {
				//mobjThreadController.Display("Error" & "|" & "0.0")
				lblObjStatusIn.text = mXValueLable;
				lblObjStatusIn.refresh();
				lblObjWV_ABSIn.text = mYValueLable;
				lblObjWV_ABSIn.refresh();
			}
			////----------------

			gobjCommProtocol.Wavelength_Position(dblWvMin, lblObjStatusIn);
			gobjCommProtocol.mobjCommdll.subTime_Delay(100);
			////----- 2. Set the Steps


			////----- 3. Set the Speed
			intCounter = 0;
			////----- Set cal. Mode
			intIniMode = gobjInst.Mode;
			gobjInst.Mode = intMode;

			////---------------
			////----- Display Current Wavelength
			if (gobjCommProtocol.funcGet_Current_Wv(dblCurrWv) == true) {
				//mobjThreadController.Display(dblCurrWv.ToString & "|" & "0.0")
				lblObjStatusIn.text = mXValueLable + dblCurrWv.ToString;
				lblObjStatusIn.refresh();
				lblObjWV_ABSIn.text = mYValueLable + "0.0";
				lblObjWV_ABSIn.refresh();
			} else {
				//mobjThreadController.Display("Error" & "|" & "0.0")
				lblObjStatusIn.text = mXValueLable;
				lblObjStatusIn.refresh();
				lblObjWV_ABSIn.text = mYValueLable;
				lblObjWV_ABSIn.refresh();
			}

			//// Terminate if ThTerminate is true
			if (ThTerminate == true) {
				goto ExitSpectrum;
			}

			////----------------
			//---4. Cal. Wv & Abs/En
			double dblMaxWv;
			//dblWv = dblXMax * CDbl(intSetpsPernm) + 0.1
			dblMaxWv = dblXMax * (double)intSetpsPernm + 0.1;
			if (dblMaxWv >= (double)intSpeed) {
				if (gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam | gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.ReferenceBeam) {
					//mobjThreadController.Display("Reference" & "|" & "0.0")
					dblWv = dblXMax;
					if (gobjCommProtocol.funcReadADCFilter_ReferenceBeam(10, dblYNew) == false) {
						return false;
					}
					gobjCommProtocol.mobjCommdll.subTime_Delay(100);
					////----- Get Abs/ En Value
					//abs = GetADConvertedToCurMode(ynew);

					blYasisReading = gFuncGetADConvertedToCurMode(dblYNew);
					mobjThreadController.Display(dblXMin.ToString + "|" + blYasisReading.ToString);
					if (ThTerminate == true) {
						goto ExitSpectrum;
					}

					////---- Start to Spectrum
					//x1 = (wvnew * StepPerNm) + 0.1
					//i = CInt(x1)

					//bytLow = CByte(i And &HFF)
					//bytHigh = CByte(i >> 8)
					//SpectGraph.Xmax* (double) stepspernm+(double)0.1

					dblWv = dblXMax * (double)intSetpsPernm + 0.1;
					blnStartSpec = gobjCommProtocol.funcStartSpectrum_ReferenceBeam(dblWv, intSpeed);
					//gobjCommProtocol.mobjCommdll.subTime_Delay(500)
					if (blnStartSpec == true) {
						while ((true)) {
							if (mblnEndProcess == true) {
								if (gobjCommProtocol.funcReceive_ScanData(0, dblYNew) == true) {
									if ((dblYNew == 6000)) {
										break; // TODO: might not be correct. Was : Exit Do
									}
									////----- For Demo Mode
									//#If DEMO Then
									//		ynew=ReadADCFilter();
									//#End If
									//If gstructSettings.AppMode = EnumAppMode.DemoMode Then
									if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
										gobjCommProtocol.funcReadADCFilter_ReferenceBeam(gobjInst.Average, dblYNew);
									}
									////-----
									intSpeedIncrease += intSpeed;
									dblWv = dblXMin + (double)intSpeedIncrease / (double)intSetpsPernm;
									////----- Get Abs/ En Value
									//abs = GetADConvertedToCurMode(ynew); 
									blYasisReading = gFuncGetADConvertedToCurMode(dblYNew);
									mblnEndProcess = false;
									//--- Send the data to the screen by '|' seperated
									mobjThreadController.Display(dblWv.ToString + "|" + blYasisReading.ToString);

									if (ThTerminate == true) {
										if (gobjMessageAdapter.ShowMessage(constExitEnergyScan) == true) {
											if (gobjCommProtocol.funcBreakSpectrum() == false) {
												break; // TODO: might not be correct. Was : Exit Do
											} else {
												break; // TODO: might not be correct. Was : Exit Do
											}
										} else {
											ThTerminate = false;
										}
									}
									Application.DoEvents();
									gobjCommProtocol.mobjCommdll.subTime_Delay(80);
									if (gobjCommProtocol.funcPC_END() == false) {
										break; // TODO: might not be correct. Was : Exit Do
									}
									//Application.DoEvents()
									funcThreadDBEnergySpectrum = true;
								} else {
									break; // TODO: might not be correct. Was : Exit Do
								}
							}
							if (!mobjThreadController.Running) {
								break; // TODO: might not be correct. Was : Exit Do
							}
							//Application.DoEvents()
							//If (gstructSettings.AppMode = EnumAppMode.DemoMode) Then
							if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
								gobjCommProtocol.mobjCommdll.subTime_Delay(100);
								Application.DoEvents();
							}
						}
					}
				}

				////--------------- Sart for Sample Beam ------------------------------------
				//***************************************************************************
				//gobjCommProtocol.mobjCommdll.subTime_Delay(100)


				if (gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam | gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam) {
					if (gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam) {
						mobjThreadController.Display("Sample" + "|" + "0.0");
						gobjCommProtocol.Wavelength_Position(dblWvMin, lblObjStatusIn);
						intSpeedIncrease = 0;
						gobjCommProtocol.mobjCommdll.subTime_Delay(80);
						////----- Display Current Wavelength
						if (gobjCommProtocol.funcGet_Current_Wv(dblCurrWv) == true) {
							//mobjThreadController.Display(dblCurrWv.ToString & "|" & "0.0")
							lblObjStatusIn.text = mXValueLable + dblCurrWv.ToString;
							lblObjStatusIn.refresh();
							lblObjWV_ABSIn.text = mYValueLable + "0.0";
							lblObjWV_ABSIn.refresh();
						} else {
							//mobjThreadController.Display("Error" & "|" & "0.0")
							lblObjStatusIn.text = mXValueLable;
							lblObjStatusIn.refresh();
							lblObjWV_ABSIn.text = mYValueLable;
							lblObjWV_ABSIn.refresh();
						}

					}

					//mobjThreadController.Display("Sample" & "|" & "0.0")
					dblWv = dblXMax;
					if (gobjCommProtocol.funcReadADCFilter(10, dblYNew) == false) {
						return false;
					}
					gobjCommProtocol.mobjCommdll.subTime_Delay(80);
					////----- Get Abs/ En Value
					//abs = GetADConvertedToCurMode(ynew);

					blYasisReading = gFuncGetADConvertedToCurMode(dblYNew);
					mobjThreadController.Display(dblXMin.ToString + "|" + blYasisReading.ToString);
					if (ThTerminate == true) {
						goto ExitSpectrum;
					}

					dblWv = dblXMax * (double)intSetpsPernm + 0.1;
					blnStartSpec = gobjCommProtocol.funcStartSpectrum(dblWv, intSpeed);
					if (blnStartSpec == true) {
						while ((true)) {
							if (gobjCommProtocol.funcReceive_ScanData(0, dblYNew) == true) {
								if ((dblYNew == 6000)) {
									break; // TODO: might not be correct. Was : Exit Do
								}
								////----- For Demo Mode
								//#If DEMO Then
								//		ynew=ReadADCFilter();
								//#End If
								//If gstructSettings.AppMode = EnumAppMode.DemoMode Then
								if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
									gobjCommProtocol.funcReadADCFilter(gobjInst.Average, dblYNew);
								}
								////-----
								intSpeedIncrease += intSpeed;
								dblWv = dblXMin + (double)intSpeedIncrease / (double)intSetpsPernm;
								////----- Get Abs/ En Value
								//abs = GetADConvertedToCurMode(ynew); 
								blYasisReading = gFuncGetADConvertedToCurMode(dblYNew);
								//--- Send the data to the screen by '|' seperated
								mobjThreadController.Display(dblWv.ToString + "|" + blYasisReading.ToString);
								if (ThTerminate == true) {
									if (gobjMessageAdapter.ShowMessage(constExitEnergyScan) == true) {
										if (gobjCommProtocol.funcBreakSpectrum() == false) {
											break; // TODO: might not be correct. Was : Exit Do
										} else {
											break; // TODO: might not be correct. Was : Exit Do
										}
									} else {
										ThTerminate = false;
									}
								}

								gobjCommProtocol.mobjCommdll.subTime_Delay(80);
								if (gobjCommProtocol.funcPC_END() == false) {
									break; // TODO: might not be correct. Was : Exit Do
								}
								//Application.DoEvents()
								funcThreadDBEnergySpectrum = true;
							} else {
								break; // TODO: might not be correct. Was : Exit Do
							}
							if (!mobjThreadController.Running) {
								break; // TODO: might not be correct. Was : Exit Do
							}
							Application.DoEvents();
						}
					}
				}
			}
			ExitSpectrum:



			////-----   Set Wv '& Abs/En
			//Wavelength_Position(hdc, SpectGraph.Xmin, 20, 372)
			Application.DoEvents();
			gobjCommProtocol.Wavelength_Position(dblWvMin, lblObjStatusIn);
			gobjCommProtocol.mobjCommdll.subTime_Delay(50);
			////----- Display Current Wavelength

			if (gobjCommProtocol.funcGet_Current_Wv(dblCurrWv) == true) {
				lblObjStatusIn.text = mXValueLable + dblCurrWv.ToString;
				lblObjStatusIn.refresh();
				lblObjWV_ABSIn.text = mYValueLable + "0.0";
				lblObjWV_ABSIn.refresh();

			} else {
				lblObjStatusIn.text = mXValueLable;
				lblObjStatusIn.refresh();
				lblObjWV_ABSIn.text = mYValueLable;
				lblObjWV_ABSIn.refresh();
			}
			////----------------

			//Application.DoEvents()
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
			ThTerminate = false;
			SpectrumWait = false;
		}
	}
	////----- Not in use of funcThreadDBEnergySpectrum
	private bool funcThreadDBEnergySpectrum_AccToBeamSelection(ref System.Object lblObjStatusIn, ref System.Object lblObjWV_ABSIn, double dblXMax, double dblXMin, double dblYMax, double dblYMin, int intMode, int intSpeed, int intCounter, bool blnIsRefBeamSelected)
	{
		//------------------------------------------------------------------
		//Procedure Name         :   funcThreadDBEnergySpectrum_AccToBeamSelection
		//Description            :   Start the process for Energy Spectrum of bouble beam
		//Affected Parameters    :   lblObjStatusIn,lblObjWV_ABSIn as label on form
		//Parameters             :   dblXMax,dblXMin,dblYMax,dblYMin,intMode,intSpeed,intCounter,blnIsRefBeamSelected
		//Return                 :   True if success.
		//Time/Date              :   06.04.07
		//Dependencies           :   
		//Author                 :   Sachin Dokhale.
		//Revision               :
		//Revision by Person     :   Deepak Bhati on 20.07.07 added a flag to know whether sample or ref beam is 
		//                           selected
		//--------------------------------------------------------------------------------------

		CWaitCursor objWait = new CWaitCursor();
		double dblWv;
		double dblYNew;
		double blYasisReading;
		bool blnStartSpec;
		int intSpeedIncrease;
		int intIniMode;
		double dblCurrWv;
		int intSetpsPernm = 50;
		double dblWvMin;
		int intTimeDelay = 20;
		OpenFileDialog objOpenFile;
		//---16.03.08
		Spectrum.Channel objchannel;
		//---16.03.08

		try {
			Application.DoEvents();

			////----- 1  Set Wv '& Abs/En
			//Wavelength_Position(hdc, SpectGraph.Xmin, 20, 372)

			dblWvMin = dblXMin;
			mXValueLable = "Wavelength (nm): ";
			switch (gobjInst.Mode) {
				case EnumCalibrationMode.AA:
					mYValueLable = const_Absorbance;
				case EnumCalibrationMode.AA:
				case EnumCalibrationMode.AABGC:
				case EnumCalibrationMode.MABS:
					mYValueLable = "Absorbance : ";
				case EnumCalibrationMode.HCLE:
				case EnumCalibrationMode.D2E:
					mYValueLable = const_Energy;
				case EnumCalibrationMode.EMISSION:
					mYValueLable = const_Emission;
				case EnumCalibrationMode.SELFTEST:
					mYValueLable = const_Volt;
			}

			////----- Display Current Wavelength
			//16.03.08
			if (gblnIsDemoWithRealData == false) {
				if (gobjCommProtocol.funcGet_Current_Wv(dblCurrWv) == true) {
					//mobjThreadController.Display(dblCurrWv.ToString & "|" & "0.0")
					lblObjStatusIn.text = mXValueLable + dblCurrWv.ToString;
					lblObjStatusIn.refresh();
					lblObjWV_ABSIn.text = mYValueLable + "0.0";
					lblObjWV_ABSIn.refresh();
				} else {
					//mobjThreadController.Display("Error" & "|" & "0.0")
					lblObjStatusIn.text = mXValueLable;
					lblObjStatusIn.refresh();
					lblObjWV_ABSIn.text = mYValueLable;
					lblObjWV_ABSIn.refresh();
				}
			}

			////----------------
			//16.03.08
			if (gblnIsDemoWithRealData == false) {
				gobjCommProtocol.Wavelength_Position(dblWvMin, lblObjStatusIn);
			}
			//gobjCommProtocol.mobjCommdll.subTime_Delay(80)
			////----- 2. Set the Steps


			////----- 3. Set the Speed
			intCounter = 0;
			////----- Set cal. Mode
			intIniMode = gobjInst.Mode;
			gobjInst.Mode = intMode;

			////---------------
			//--- Display Current Wavelength
			//16.03.08
			if (gblnIsDemoWithRealData == false) {
				if (gobjCommProtocol.funcGet_Current_Wv(dblCurrWv) == true) {
					//mobjThreadController.Display(dblCurrWv.ToString & "|" & "0.0")
					lblObjStatusIn.text = mXValueLable + dblCurrWv.ToString;
					lblObjStatusIn.refresh();
					lblObjWV_ABSIn.text = mYValueLable + "0.0";
					lblObjWV_ABSIn.refresh();
				} else {
					//mobjThreadController.Display("Error" & "|" & "0.0")
					lblObjStatusIn.text = mXValueLable;
					lblObjStatusIn.refresh();
					lblObjWV_ABSIn.text = mYValueLable;
					lblObjWV_ABSIn.refresh();
				}
			}


			//--- Check the property for interuption from user to terminate the process
			if (ThTerminate == true) {
				goto ExitSpectrum;
			}

			////----------------
			//---4. Cal. Wv & Abs/En
			double dblMaxWv;
			//dblWv = dblXMax * CDbl(intSetpsPernm) + 0.1
			dblMaxWv = dblXMax * (double)intSetpsPernm + 0.1;
			if (dblMaxWv >= (double)intSpeed) {
				//---the following condition is added by deepak on 20.07.07
				if (blnIsRefBeamSelected == true) {
					if (gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam | gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.ReferenceBeam) {
						//mobjThreadController.Display("Reference" & "|" & "0.0")
						gobjCommProtocol.mobjCommdll.subTime_Delay(intTimeDelay);
						Application.DoEvents();
						dblWv = dblXMax;
						if (gobjCommProtocol.funcReadADCFilter_ReferenceBeam(10, dblYNew) == false) {
							return false;
						}
						//gobjCommProtocol.mobjCommdll.subTime_Delay(50)
						////----- Get Abs/ En Value
						//abs = GetADConvertedToCurMode(ynew);

						blYasisReading = gFuncGetADConvertedToCurMode(dblYNew);

						//---16.03.08
						if (gblnIsDemoWithRealData == true) {
							int intCount;
							string strSelectedElement;
							if (mblnIsDemoFileOpened == false) {
								objOpenFile = new OpenFileDialog();
								strSelectedElement = LCase(gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).ElementName);
								strSelectedElement = Application.StartupPath + "\\Spectrums\\" + strSelectedElement + ".ens";
								objOpenFile.FileName = strSelectedElement;
								if ((objOpenFile.CheckFileExists())) {
									objchannel = gfuncDeSerializeObject(objOpenFile.FileName, EnumDeserializeObjType.EnergySpectrum);
									mblnIsDemoFileOpened = true;
								}
							}

							if (!objchannel == null) {
								for (intCount = 0; intCount <= objchannel.Spectrums(0).Readings.Count - 1; intCount++) {
									if (dblXMin == objchannel.Spectrums(0).Readings.item(intCount).XaxisData) {
										dblYNew = objchannel.Spectrums(0).Readings.item(intCount).YaxisADCData;
										blYasisReading = objchannel.Spectrums(0).Readings.item(intCount).YaxisData;
										break; // TODO: might not be correct. Was : Exit For
									}
								}
							}
						}
						//---16.03.08

						//mobjThreadController.Display(dblXMin.ToString & "|" & blYasisReading.ToString)
						mobjThreadController.Display(dblXMin.ToString + "|" + blYasisReading.ToString + "|" + dblYNew.ToString);
						// Check the property for interuption from user to terminate the process
						if (ThTerminate == true) {
							goto ExitSpectrum;
						}

						////---- Start to Spectrum
						//x1 = (wvnew * StepPerNm) + 0.1
						//i = CInt(x1)

						//bytLow = CByte(i And &HFF)
						//bytHigh = CByte(i >> 8)
						//SpectGraph.Xmax* (double) stepspernm+(double)0.1

						dblWv = dblXMax * (double)intSetpsPernm + 0.1;
						blnStartSpec = gobjCommProtocol.funcStartSpectrum_ReferenceBeam(dblWv, intSpeed);
						gblnInComm = false;
						//gobjCommProtocol.mobjCommdll.subTime_Delay(500)
						if (blnStartSpec == true) {
							while ((true)) {
								//Application.DoEvents()
								if (mblnEndProcess == true) {
									//Me.SpectrumWait = False 
									if (gblnInComm == false) {

										if (gobjCommProtocol.funcReceive_ScanData(0, dblYNew) == true) {
											if ((dblYNew == 6000)) {
												break; // TODO: might not be correct. Was : Exit Do

											}
											//mblnEndProcess = False
											////----- For Demo Mode
											//#If DEMO Then
											//		ynew=ReadADCFilter();
											//#End If
											gobjCommProtocol.mobjCommdll.subTime_Delay(intTimeDelay);
											//--- Modified for speed Issue
											if (ThTerminate == true) {
												if (gobjMessageAdapter.ShowMessage(constExitEnergyScan) == true) {
													Application.DoEvents();
													if (gobjCommProtocol.funcBreakSpectrum() == false) {
														break; // TODO: might not be correct. Was : Exit Do
													} else {
														break; // TODO: might not be correct. Was : Exit Do
													}
												} else {
													Application.DoEvents();
													ThTerminate = false;
												}
											}
											if (gobjCommProtocol.funcPC_END() == false) {
												break; // TODO: might not be correct. Was : Exit Do
											}
											gobjCommProtocol.mobjCommdll.subTime_Delay(intTimeDelay);

											//---
											//If gstructSettings.AppMode = EnumAppMode.DemoMode Then
											if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
												gobjCommProtocol.funcReadADCFilter_ReferenceBeam(gobjInst.Average, dblYNew);
											}

											////-----
											intSpeedIncrease += intSpeed;
											dblWv = dblXMin + (double)intSpeedIncrease / (double)intSetpsPernm;
											////----- Get Abs/ En Value
											//abs = GetADConvertedToCurMode(ynew); 
											blYasisReading = gFuncGetADConvertedToCurMode(dblYNew);

											mblnEndProcess = false;
											Application.DoEvents();
											//---16.03.08
											if (gblnIsDemoWithRealData == true) {
												int intCount;
												if (!objchannel == null) {
													for (intCount = 0; intCount <= objchannel.Spectrums(0).Readings.Count - 1; intCount++) {
														if (dblWv == objchannel.Spectrums(0).Readings.item(intCount).XaxisData) {
															dblYNew = objchannel.Spectrums(0).Readings.item(intCount).YaxisADCData;
															blYasisReading = objchannel.Spectrums(0).Readings.item(intCount).YaxisData;
															break; // TODO: might not be correct. Was : Exit For
														}
													}
												}
												if (dblWv > dblXMax) {
													break; // TODO: might not be correct. Was : Exit Do
												}
											}
											//---16.03.08

											//--- Send the data to the screen by '|' seperated
											//mobjThreadController.Display(dblWv.ToString & "|" & blYasisReading.ToString)
											mobjThreadController.Display(dblWv.ToString + "|" + blYasisReading.ToString + "|" + dblYNew.ToString);
											// Check the property for interuption from user to terminate the process
											//--- Modified for speed Issue
											//If ThTerminate = True Then
											//    If gobjMessageAdapter.ShowMessage(constExitEnergyScan) = True Then
											//        If gobjCommProtocol.funcBreakSpectrum() = False Then
											//            Exit Do
											//        Else
											//            Exit Do
											//        End If
											//    Else
											//        ThTerminate = False
											//    End If
											//End If
											//gobjCommProtocol.mobjCommdll.subTime_Delay(intTimeDelay)
											//Application.DoEvents()
											//If gobjCommProtocol.funcPC_END() = False Then
											//    Exit Do
											//End If
											//Application.DoEvents()
											funcThreadDBEnergySpectrum_AccToBeamSelection = true;
										} else {
											break; // TODO: might not be correct. Was : Exit Do
										}
									}
								}
								if (!mobjThreadController.Running) {
									break; // TODO: might not be correct. Was : Exit Do
								}
								Application.DoEvents();
								//If (gstructSettings.AppMode = EnumAppMode.DemoMode) Then
								if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
									gobjCommProtocol.mobjCommdll.subTime_Delay(100);
									Application.DoEvents();
								}
							}
						}
					}

				} else {
					////--------------- Sart for Sample Beam ------------------------------------
					//***************************************************************************
					//gobjCommProtocol.mobjCommdll.subTime_Delay(30)


					if (gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam | gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam) {
						if (gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam) {
							mobjThreadController.Display("Sample" + "|" + "0.0");

							//16.03.08
							if (gblnIsDemoWithRealData == false) {
								gobjCommProtocol.Wavelength_Position(dblWvMin, lblObjStatusIn);
							}

							intSpeedIncrease = 0;
							//gobjCommProtocol.mobjCommdll.subTime_Delay(80)
							////----- Display Current Wavelength
							//16.03.08
							if (gblnIsDemoWithRealData == false) {
								if (gobjCommProtocol.funcGet_Current_Wv(dblCurrWv) == true) {
									//mobjThreadController.Display(dblCurrWv.ToString & "|" & "0.0")
									lblObjStatusIn.text = mXValueLable + dblCurrWv.ToString;
									lblObjStatusIn.refresh();
									lblObjWV_ABSIn.text = mYValueLable + "0.0";
									lblObjWV_ABSIn.refresh();
								} else {
									//mobjThreadController.Display("Error" & "|" & "0.0")
									lblObjStatusIn.text = mXValueLable;
									lblObjStatusIn.refresh();
									lblObjWV_ABSIn.text = mYValueLable;
									lblObjWV_ABSIn.refresh();
								}
							}
						}
						gobjCommProtocol.mobjCommdll.subTime_Delay(intTimeDelay);
						Application.DoEvents();
						//mobjThreadController.Display("Sample" & "|" & "0.0")
						dblWv = dblXMax;
						if (gobjCommProtocol.funcReadADCFilter(10, dblYNew) == false) {
							return false;
						}
						//gobjCommProtocol.mobjCommdll.subTime_Delay(50)
						////----- Get Abs/ En Value
						//abs = GetADConvertedToCurMode(ynew);

						blYasisReading = gFuncGetADConvertedToCurMode(dblYNew);


						//---16.03.08
						if (gblnIsDemoWithRealData == true) {
							int intCount;
							string strSelectedElement;
							if (mblnIsDemoFileOpened == false) {
								objOpenFile = new OpenFileDialog();
								strSelectedElement = LCase(gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).ElementName);
								strSelectedElement = Application.StartupPath + "\\Spectrums\\" + strSelectedElement + ".ens";
								objOpenFile.FileName = strSelectedElement;
								if ((objOpenFile.CheckFileExists())) {
									objchannel = gfuncDeSerializeObject(objOpenFile.FileName, EnumDeserializeObjType.EnergySpectrum);
									mblnIsDemoFileOpened = true;
								}
							}

							if (!objchannel == null) {
								for (intCount = 0; intCount <= objchannel.Spectrums(0).Readings.Count - 1; intCount++) {
									if (dblXMin == objchannel.Spectrums(0).Readings.item(intCount).XaxisData) {
										dblYNew = objchannel.Spectrums(0).Readings.item(intCount).YaxisADCData;
										blYasisReading = objchannel.Spectrums(0).Readings.item(intCount).YaxisData;
										break; // TODO: might not be correct. Was : Exit For
									}
								}
							}
						}
						//---16.03.08


						//mobjThreadController.Display(dblXMin.ToString & "|" & blYasisReading.ToString)
						mobjThreadController.Display(dblXMin.ToString + "|" + blYasisReading.ToString + "|" + dblYNew.ToString);
						// Check the property for interuption from user to terminate the process
						if (ThTerminate == true) {
							goto ExitSpectrum;
						}

						dblWv = dblXMax * (double)intSetpsPernm + 0.1;
						//gobjCommProtocol.mobjCommdll.subTime_Delay(50)
						blnStartSpec = gobjCommProtocol.funcStartSpectrum(dblWv, intSpeed);
						if (blnStartSpec == true) {
							//gblnInComm = False
							while ((true)) {
								if (mblnEndProcess == true) {
									//Me.SpectrumWait = False 
									if (gblnInComm == false) {
										if (gobjCommProtocol.funcReceive_ScanData(0, dblYNew) == true) {
											if ((dblYNew == 6000)) {
												break; // TODO: might not be correct. Was : Exit Do
											}
											////----- For Demo Mode
											//#If DEMO Then
											//		ynew=ReadADCFilter();
											//#End If
											gobjCommProtocol.mobjCommdll.subTime_Delay(intTimeDelay);
											// Check the property for interuption from user to terminate the process
											if (ThTerminate == true) {
												if (gobjMessageAdapter.ShowMessage(constExitEnergyScan) == true) {
													Application.DoEvents();
													//If Me.SpectrumWait = False Then
													if (gobjCommProtocol.funcBreakSpectrum() == false) {
														break; // TODO: might not be correct. Was : Exit Do
													} else {
														break; // TODO: might not be correct. Was : Exit Do
													}
												//End If
												} else {
													Application.DoEvents();
													ThTerminate = false;
												}
											}
											//If gstructSettings.AppMode = EnumAppMode.DemoMode Then
											if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
												gobjCommProtocol.funcReadADCFilter(gobjInst.Average, dblYNew);
											}
											//gobjCommProtocol.mobjCommdll.subTime_Delay(intTimeDelay)
											//Application.DoEvents()
											//If Me.SpectrumWait = False Then
											if (gobjCommProtocol.funcPC_END() == false) {
												break; // TODO: might not be correct. Was : Exit Do
											}
											//End If
											gobjCommProtocol.mobjCommdll.subTime_Delay(intTimeDelay);
											Application.DoEvents();
											////-----
											intSpeedIncrease += intSpeed;
											dblWv = dblXMin + (double)intSpeedIncrease / (double)intSetpsPernm;
											////----- Get Abs/ En Value
											//abs = GetADConvertedToCurMode(ynew); 
											blYasisReading = gFuncGetADConvertedToCurMode(dblYNew);
											//--- Send the data to the screen by '|' seperated
											mblnEndProcess = false;


											//---16.03.08
											if (gblnIsDemoWithRealData == true) {
												int intCount;
												if (!objchannel == null) {
													for (intCount = 0; intCount <= objchannel.Spectrums(0).Readings.Count - 1; intCount++) {
														if (dblWv == objchannel.Spectrums(0).Readings.item(intCount).XaxisData) {
															dblYNew = objchannel.Spectrums(0).Readings.item(intCount).YaxisADCData;
															blYasisReading = objchannel.Spectrums(0).Readings.item(intCount).YaxisData;
															break; // TODO: might not be correct. Was : Exit For
														}
													}
												}
												if (dblWv > dblXMax) {
													break; // TODO: might not be correct. Was : Exit Do
												}
											}
											//---16.03.08

											//mobjThreadController.Display(dblWv.ToString & "|" & blYasisReading.ToString)
											mobjThreadController.Display(dblWv.ToString + "|" + blYasisReading.ToString + "|" + dblYNew);
											//--- Commented for speed issue
											//' Check the property for interuption from user to terminate the process
											//If ThTerminate = True Then
											//    If gobjMessageAdapter.ShowMessage(constExitEnergyScan) = True Then
											//        If Me.SpectrumWait = False Then
											//            If gobjCommProtocol.funcBreakSpectrum() = False Then
											//                Exit Do
											//            Else
											//                Exit Do
											//            End If
											//        End If
											//    Else
											//        ThTerminate = False
											//    End If
											//End If
											//Application.DoEvents()
											//gobjCommProtocol.mobjCommdll.subTime_Delay(intTimeDelay)

											//If Me.SpectrumWait = False Then
											//    If gobjCommProtocol.funcPC_END() = False Then
											//        Exit Do
											//    End If
											//End If
											Application.DoEvents();
											funcThreadDBEnergySpectrum_AccToBeamSelection = true;
										} else {
											break; // TODO: might not be correct. Was : Exit Do
										}
									}
								}
								if (!mobjThreadController.Running) {
									break; // TODO: might not be correct. Was : Exit Do
								}
								Application.DoEvents();
							}
						}
					}
				}
			}
			ExitSpectrum:



			////-----   Set Wv '& Abs/En
			//Wavelength_Position(hdc, SpectGraph.Xmin, 20, 372)
			//gobjCommProtocol.mobjCommdll.subTime_Delay(50)
			Application.DoEvents();
			//---16.03.08
			if (gblnIsDemoWithRealData == false) {
				gobjCommProtocol.Wavelength_Position(dblWvMin, lblObjStatusIn);
			}
			//gobjCommProtocol.mobjCommdll.subTime_Delay(50)
			////----- Display Current Wavelength
			//---16.03.08
			if (gblnIsDemoWithRealData == false) {
				if (gobjCommProtocol.funcGet_Current_Wv(dblCurrWv) == true) {
					lblObjStatusIn.text = mXValueLable + dblCurrWv.ToString;
					lblObjStatusIn.refresh();
					lblObjWV_ABSIn.text = mYValueLable + "0.0";
					lblObjWV_ABSIn.refresh();
				} else {
					lblObjStatusIn.text = mXValueLable;
					lblObjStatusIn.refresh();
					lblObjWV_ABSIn.text = mYValueLable;
					lblObjWV_ABSIn.refresh();
				}
			}
			////----------------

			//Application.DoEvents()
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
			objWait = null;
			ThTerminate = false;
			SpectrumWait = false;
		}
	}

	private bool funcThreadDBUVSpectrum(ref System.Object lblObjStatusIn, ref System.Object lblObjWV_ABSIn, double dblXMax, double dblXMin, double dblYMax, double dblYMin, int intMode, int intSpeed, int intCounter, bool bln_BaseLine)
	{
		//------------------------------------------------------------------
		//Procedure Name         :   funcThreadDBUVSpectrum
		//Description            :   Start the process for UV Spectrum of bouble beam
		//Affected Parameters    :   lblObjStatusIn,lblObjWV_ABSIn as label on form
		//Parameters             :   dblXMax,dblXMin,dblYMax,dblYMin,intMode,intSpeed,intCounter,bln_BaseLine
		//Return                 :   True if success.
		//Time/Date              :   5/10/06
		//Dependencies           :   
		//Author                 :   Sachin Dokhale.
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		//------------------------------------------------

		//------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		double dblWv;
		double dblMaxWv;
		double dblYNew;
		double blYasisReading;
		bool blnStartSpec;
		int intSpeedIncrease;
		int intIniMode;
		double dblCurrWv;
		int MAXSIZE;
		int intsamp_adcCounter;
		double dblWvMin;
		int intSetpsPernm;
		int intTimeDelay = 20;
		try {
			CWaitCursor objWait1 = new CWaitCursor();
			Application.DoEvents();


			////----- 1  Set Wv '& Abs/En
			//Wavelength_Position(hdc, SpectGraph.Xmin, 20, 372)

			dblWvMin = dblXMin;
			mXValueLable = "Wavelength (nm): ";
			switch (gobjInst.Mode) {
				case EnumCalibrationMode.AA:
				case EnumCalibrationMode.AABGC:
				case EnumCalibrationMode.MABS:
					mYValueLable = const_Absorbance;
				case EnumCalibrationMode.HCLE:
				case EnumCalibrationMode.D2E:
					mYValueLable = const_Energy;
				case EnumCalibrationMode.EMISSION:
					mYValueLable = const_Emission;
				case EnumCalibrationMode.SELFTEST:
					mYValueLable = const_Volt;
			}

			////----- Display Current Wavelength
			if (gobjCommProtocol.funcGet_Current_Wv(dblCurrWv) == true) {
				//mobjThreadController.Display(dblCurrWv.ToString & "|" & "0.0")
				lblObjStatusIn.text = mXValueLable + dblCurrWv.ToString;
				lblObjStatusIn.refresh();
				lblObjWV_ABSIn.text = mYValueLable + "0.0";
				lblObjWV_ABSIn.refresh();
			} else {
				//mobjThreadController.Display("Error" & "|" & "0.0")
				lblObjStatusIn.text = mXValueLable;
				lblObjStatusIn.refresh();
				lblObjWV_ABSIn.text = mYValueLable;
				lblObjWV_ABSIn.refresh();
			}
			////----------------

			gobjCommProtocol.Wavelength_Position(dblWvMin, lblObjStatusIn);
			//gobjCommProtocol.mobjCommdll.subTime_Delay(100)
			gobjCommProtocol.mobjCommdll.subTime_Delay(intTimeDelay);
			Application.DoEvents();
			// Check the property for interuption from user to terminate the process
			if (ThTerminate == true) {
				goto ExitSpectrum;
			}


			////----- 2. Set the Steps
			intSetpsPernm = 50;

			////----- 3. Set the Speed
			intCounter = 0;
			if ((intSpeed == 0)) {
				intSpeed = CONST_STEPS_PER_NM;
			}
			////----- Set cal. Mode

			intIniMode = gobjInst.Mode;
			gobjInst.Mode = intMode;
			gblnUVABS = true;

			////---------------
			////----- Calculate the size of Ref Adc value
			//MAXSIZE = (unsigned)  (  (((SpectGraph.Xmax-SpectGraph.Xmin)*stepspernm)/ (double) speed) +1.0 );
			MAXSIZE = (int)(((dblXMax - dblXMin) * CONST_STEPS_PER_NM) / (double)intSpeed) + 1.0;

			if (bln_BaseLine == true) {
				gintSample_adc = null;
				 // ERROR: Not supported in C#: ReDimStatement


				gintSample_adc_RefBeam = null;
				 // ERROR: Not supported in C#: ReDimStatement

			}

			intsamp_adcCounter = 0;
			////----- Display Current Wavelength
			if (gobjCommProtocol.funcGet_Current_Wv(dblCurrWv) == true) {
				//mobjThreadController.Display(dblCurrWv.ToString & "|" & "0.0")
				lblObjStatusIn.text = mXValueLable + dblCurrWv.ToString;
				lblObjStatusIn.refresh();
				lblObjWV_ABSIn.text = mYValueLable + "0.0";
				lblObjWV_ABSIn.refresh();
			} else {
				//mobjThreadController.Display("Error" & "|" & "0.0")
				lblObjStatusIn.text = mXValueLable;
				lblObjStatusIn.refresh();
				lblObjWV_ABSIn.text = mYValueLable;
				lblObjWV_ABSIn.refresh();
			}
			////----------------

			//---4. Cal. Wv & Abs/En
			dblMaxWv = dblXMax * (double)intSetpsPernm + 0.1;

			if (dblMaxWv >= (double)intSpeed) {
				//dblWv =  dblXMax * intSetpsPernm + 0.1
				////------------- Start Sample Spectrum
				////********************************************************************
				gobjCommProtocol.Wavelength_Position(dblWvMin, lblObjStatusIn);
				//gobjCommProtocol.mobjCommdll.subTime_Delay(100)
				gobjCommProtocol.mobjCommdll.subTime_Delay(intTimeDelay);
				Application.DoEvents();
				////----- Display Current Wavelength
				intsamp_adcCounter = 0;
				dblWv = dblXMax;
				//If gobjCommProtocol.funcReadADCFilter(10, dblYNew) = False Then
				if (gobjCommProtocol.funcReadADCFilter(5, dblYNew) == false) {
					return false;
				}
				//gobjCommProtocol.mobjCommdll.subTime_Delay(100)
				////----- Get Abs/ En Value
				//abs = GetADConvertedToCurMode(ynew); 

				//--- Check spectrum value for Baseline
				if (bln_BaseLine == true) {
					gintSample_adc(intsamp_adcCounter) = dblYNew;
					blYasisReading = gfuncGetConvertToUVAbs(dblYNew, dblYNew);
					intsamp_adcCounter += 1;
				} else {
					if (IsNothing(gintSample_adc) == false) {
						if (gintSample_adc.Length > 0) {
							blYasisReading = gfuncGetConvertToUVAbs(dblYNew, gintSample_adc(intsamp_adcCounter));
							intsamp_adcCounter += 1;
						}
					} else {
						return false;
					}
				}
				string strMsg;
				if (bln_BaseLine) {
					strMsg = constExitBaseLine;
				} else {
					strMsg = constExitUV;
				}
				// Check the property for interuption from user to terminate the process
				if (ThTerminate == true) {
					goto ExitSpectrum;
				}
				//blYasisReading = gFuncGetADConvertedToCurMode(dblYNew)
				//mobjThreadController.Display(dblXMin.ToString & "|" & blYasisReading.ToString)
				mobjThreadController.Display(dblXMin.ToString + "|" + blYasisReading.ToString + "|" + blYasisReading.ToString);

				////---- Start to Spectrum
				blnStartSpec = gobjCommProtocol.funcStartSpectrum(dblMaxWv, intSpeed);
				mblnEndProcess = true;
				if (blnStartSpec == true) {
					gblnInComm = false;
					while ((ThTerminate == false)) {
						if (mblnEndProcess == true & gblnInComm == false) {
							if (gobjCommProtocol.funcReceive_ScanData(0, dblYNew) == true) {
								////----- For Demo Mode
								//#If DEMO Then
								//		ynew = random(4096);
								//#End If
								//If gstructSettings.AppMode = EnumAppMode.DemoMode Then
								if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
									dblYNew = gRandom.Next(4096);
								}

								if ((dblYNew == 6000)) {
									break; // TODO: might not be correct. Was : Exit Do
								}

								//--- For Demo Mode
								//#If DEMO Then
								//		ynew=ReadADCFilter();
								//#End If
								//If gstructSettings.AppMode = EnumAppMode.DemoMode Then
								if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
									gobjCommProtocol.funcReadADCFilter(gobjInst.Average, dblYNew);
								}
								////-----

								intSpeedIncrease += intSpeed;
								dblWv = dblXMin + (double)intSpeedIncrease / (double)intSetpsPernm;

								////----- For Demo Mode
								//#If DEMO Then
								//		if (wv>=SpectGraph.Xmax ||addata.counter>= MAXSIZE)
								//		  break;
								//#End If
								//If gstructSettings.AppMode = EnumAppMode.DemoMode Then
								if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
									if (((dblWv >= mdblMaxWavelength) | (dblWv <= mdblMinWavelength))) {
										break; // TODO: might not be correct. Was : Exit Do
									}
								}

								if ((dblYNew == 4095)) {
									//Gerror_message_new("Full scale overflow, Reduce PMT/D2cur", "UV SPECTRUM");
									//PostMessage(hwnd, WM_COMMAND, IDC_START, 0);
									gobjInst.D2Pmt = 0;
								}

								////----- Get Abs/ En Value
								//--- Check spectrum value for Baseline
								if (bln_BaseLine == true) {
									if (gintSample_adc.Length > 0) {
										gintSample_adc(intsamp_adcCounter) = dblYNew;
									}
									blYasisReading = gfuncGetConvertToUVAbs(dblYNew, dblYNew);
									intsamp_adcCounter += 1;
								} else {
									if (gintSample_adc.Length > 0) {
										blYasisReading = gfuncGetConvertToUVAbs(dblYNew, gintSample_adc(intsamp_adcCounter));
										intsamp_adcCounter += 1;
									}
									//if (addata.ad && addata.counter<MAXSIZE)
									//    addata.ad[addata.counter++]=ynew;
								}
								mblnEndProcess = false;
								//--- Send the data to the screen by '|' seperated
								//mobjThreadController.Display(dblWv.ToString & "|" & blYasisReading.ToString)
								mobjThreadController.Display(dblWv.ToString + "|" + blYasisReading.ToString + "|" + blYasisReading.ToString);
								gobjCommProtocol.mobjCommdll.subTime_Delay(intTimeDelay);

								// Check the property for interuption from user to terminate the process
								if (ThTerminate == true) {
									if (gobjMessageAdapter.ShowMessage(strMsg) == true) {
										Application.DoEvents();
										if (gobjCommProtocol.funcBreakSpectrum() == false) {
											break; // TODO: might not be correct. Was : Exit Do
										} else {
											break; // TODO: might not be correct. Was : Exit Do
										}
									} else {
										Application.DoEvents();
										ThTerminate = false;
									}

								}


								if (gobjCommProtocol.funcPC_END() == false) {
									break; // TODO: might not be correct. Was : Exit Do
								}
								gobjCommProtocol.mobjCommdll.subTime_Delay(intTimeDelay);
								Application.DoEvents();
								funcThreadDBUVSpectrum = true;
							} else {
								break; // TODO: might not be correct. Was : Exit Do
							}
						}
						if (!mobjThreadController.Running) {
							break; // TODO: might not be correct. Was : Exit Do
						}
						//Application.DoEvents()
					}
				}
				//End If
				////*******************************************************************
			}
			ExitSpectrum:

			////-----   Set Wv '& Abs/En
			//Wavelength_Position(hdc, SpectGraph.Xmin, 20, 372)
			Application.DoEvents();
			gobjCommProtocol.Wavelength_Position(dblWvMin, lblObjStatusIn);
			gobjCommProtocol.mobjCommdll.subTime_Delay(50);
			intsamp_adcCounter = 0;
			////----- Display Current Wavelength

			if (gobjCommProtocol.funcGet_Current_Wv(dblCurrWv) == true) {
				lblObjStatusIn.text = mXValueLable + dblCurrWv.ToString;
				lblObjStatusIn.refresh();
				lblObjWV_ABSIn.text = mYValueLable + "0.0";
				lblObjWV_ABSIn.refresh();

			} else {
				lblObjStatusIn.text = mXValueLable;
				lblObjStatusIn.refresh();
				lblObjWV_ABSIn.text = mYValueLable;
				lblObjWV_ABSIn.refresh();
			}
			////----------------

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
			//---------------------------------------------------------
			//ThTerminate = False
			SpectrumWait = false;
		}
	}

	private bool funcThreadDBAbsTimeScan(ref System.Object lblObjStatusIn, ref System.Object lblObjWV_ABSIn, double dblXMax, double dblXMin, double dblYMax, double dblYMin, int intMode, double dblAbsScanthldval, bool blnCheckMinAbsScanLmt)
	{
		//------------------------------------------------------------------
		//Procedure Name         :   funcThreadDBAbsTimeScan
		//Description            :   Start the process for UV Spectrum of bouble beam
		//Affected Parameters    :   lblObjStatusIn,lblObjWV_ABSIn as label on form
		//Parameters             :   dblXMax,dblXMin,dblYMax,dblYMin,intMode,dblAbsScanthldval,blnCheckMinAbsScanLmt
		//Return                 :   True if success.
		//Time/Date              :   5/10/06
		//Dependencies           :   
		//Author                 :   Sachin Dokhale.
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		//------------------------------------------------

		//------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		long CEnd1;
		long CEnd;
		//Dim ConstManipulate As Long = 1000
		long ConstManipulate = 10000000;
		double dblAbs;
		double dblAbs_RefBeam;
		double dblAbs_DoubleBeam;
		double dblXaxisTime1;

		try {
			Application.DoEvents();

			CWaitCursor objWait1 = new CWaitCursor();
			////----- 1  Set Wv '& Abs/En
			lblObjStatusIn.text = mXValueLable + dblXMax.ToString;
			lblObjStatusIn.refresh();
			lblObjWV_ABSIn.text = mYValueLable + "0.0";

			if (gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam) {
				lblObjWV_ABSIn.Visible = true;
			} else if (gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.ReferenceBeam) {
				lblObjWV_ABSIn.Visible = false;
			} else if (gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam) {
				lblObjWV_ABSIn.Visible = true;
			}

			lblObjWV_ABSIn.refresh();

			////----------------
			gobjClsAAS203.ReInitInstParameters();
			//--- Read Start time stamp
			CEnd1 = System.DateTime.Now.Ticks;

			// Start to Reading and sending data
			while ((!ThTerminate == true)) {
				if (!SpectrumWait == true) {
					if (!(CEnd == CEnd1)) {
						//--- Check calibration mode 
						if (gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam) {
							if (gobjInst.Mode == EnumCalibrationMode.AA) {
								if (gstructSettings.IsCustomerDisplayMode == false) {
									//--- Read Sample ADC count 
									if (!SpectrumWait == true) {
										dblAbs = gobjClsAAS203.funcGetAbsScanX();
									}
									//--- Read Sample Abs scan
									if (!SpectrumWait == true) {
										dblAbs_RefBeam = gobjClsAAS203.funcGetAbsScanX_RefBeam();
									}
									//--- Read Double (Drift) Abs scan
									if (!SpectrumWait == true) {
										dblAbs_DoubleBeam = gobjClsAAS203.funcGetAbsScanX_DoubleBeam();
									}

								} else {
									//--- Read Double (Drift) Abs scan
									if (!SpectrumWait == true) {
										dblAbs_DoubleBeam = gobjClsAAS203.funcGetAbsScanX_DoubleBeam();
									}
								}
							} else {
								//--- Read Sample Abs scan
								if (!SpectrumWait == true) {
									dblAbs = gobjClsAAS203.funcGetAbsScanX();
								}
							}
							//--- Filter the data
							if ((gblnSmoothFilter == true)) {
								dblAbs = funcGetFiltData(dblAbs);
								dblAbs_RefBeam = funcGetFiltData_RefBeam(dblAbs_RefBeam);
								dblAbs_DoubleBeam = funcGetFiltData_DoubleBeam(dblAbs_DoubleBeam);
							}
						} else if (gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.ReferenceBeam) {
							//--- Read Sample Abs scan
							if (!SpectrumWait == true) {
								dblAbs_RefBeam = gobjClsAAS203.funcGetAbsScanX_RefBeam();
							}
							//--- Filter the data
							if ((gblnSmoothFilter == true)) {
								dblAbs_RefBeam = funcGetFiltData_RefBeam(dblAbs_RefBeam);
							}
						} else if (gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam) {
							//--- Read Sample Abs scan
							if (!SpectrumWait == true) {
								dblAbs = gobjClsAAS203.funcGetAbsScanX();
							}
							//--- Filter the data
							if ((gblnSmoothFilter == true)) {
								dblAbs = funcGetFiltData(dblAbs);
							}
						}
						//---- Check the Abs Scan min. limits
						if (blnCheckMinAbsScanLmt == true) {
							if ((dblAbs < dblAbsScanthldval)) {
								dblAbs = 0.0;
							}
							if ((dblAbs_RefBeam < dblAbsScanthldval)) {
								dblAbs_RefBeam = 0.0;
							}
							if ((dblAbs_DoubleBeam < dblAbsScanthldval)) {
								dblAbs_DoubleBeam = 0.0;
							}
						}
						//--- Read the current time stamp
						CEnd = System.DateTime.Now.Ticks;
						dblXaxisTime1 = ((CEnd - CEnd1) / ConstManipulate);
						//--- Check for running state of thread control
						if (mobjThreadController.Running == true) {
							//--- Check for application lavel evnts process is finished
							if (mblnEndProcess == true) {
								mblnEndProcess = false;
								//--- implements thread control to display data
								mobjThreadController.Display(dblXaxisTime1.ToString + "|" + dblAbs.ToString + "|" + dblAbs_RefBeam.ToString + "|" + dblAbs_DoubleBeam + "|" + gintInstrumentBeamType.ToString);
								gobjClsAAS203.funcCheck_Flame();
								//30.12.08
							}
						}
						//If (gstructSettings.AppMode = EnumAppMode.DemoMode) Then
						if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
							gobjCommProtocol.mobjCommdll.subTime_Delay(100);
							Application.DoEvents();
						}
					}
				} else {
					CEnd = System.DateTime.Now.Ticks;
					//Application.DoEvents()
				}
				Application.DoEvents();
			}
			lblObjStatusIn.text = mXValueLable + Format(dblXaxisTime1, "#0.0##").ToString;
			lblObjStatusIn.refresh();
			lblObjWV_ABSIn.text = mYValueLable + "0.0";
			lblObjWV_ABSIn.refresh();
			funcThreadDBAbsTimeScan = true;
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
			ThTerminate = false;
			SpectrumWait = false;
			//Application.DoEvents()
		}
	}

	#End Region


	private double funcGetFiltData(double ADCVolt)
	{
		//=====================================================================
		// Procedure Name        : funcGetFiltData
		// Parameters Passed     :  ADCVolts
		// Returns               : Double Returns filtered data
		// Purpose               : for fliter the data , used in time scan mode
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.12.06
		// Revisions             : 
		//=====================================================================
		static double Xn_2 = 0;
		static double Xn_1 = 0;
		static double Yn_1 = 0;
		static double Yn_2 = 0;
		static double filtdata = 0;
		static int intCal_Mode;
		double[,] xcoeff1002 = {
			{
				0.067455,
				0.134911,
				0.067455
			},
			{
				0.020083,
				0.040167,
				0.020083
			},
			{
				0.003622,
				0.007243,
				0.003622
			},
			{
				0.000945,
				0.001889,
				0.000945
			},
			{
				3.9E-05,
				7.8E-05,
				3.9E-05
			},
			{
				1E-05,
				2E-05,
				1E-05
			}
		};
		double[,] ycoeff1002 = {
			{
				1.14298,
				-0.412802
			},
			{
				1.56102,
				-0.641352
			},
			{
				1.8227,
				-0.837182
			},
			{
				1.9112,
				-0.914976
			},
			{
				1.98223,
				-0.982385
			},
			{
				1.99111,
				-0.991154
			}
		};
		try {
			//            int TimeConst=2;
			//double 	S4FUNC	GetFiltData( double ADCVolt )
			//{
			//double xcoeff1002[6][3] ={
			//					{0.067455,0.134911,0.067455}, //0.131106,0.262213,0.131106, 	 // fc = 10 Hz, fs = 100 Hz, O = 2
			//					{0.020083,0.040167,0.020083}, // fc = 5 Hz, fs = 100 Hz, O = 2
			//					{0.003622,0.007243,0.003622}, //fc = 2 Hz fs = 100 Hz, O = 2
			//					{0.000945,0.001889,0.000945}, // fc = 1 Hz fs = 100 Hz O = 2
			//					{0.000039,0.000078,0.000039}, // fc = 0.2 Hz fs = 100 Hz O = 2
			//					{0.000010,0.000020,0.000010}
			//				 }; // fc = 0.1 Hz fs = 100 Hz O = 2
			//double ycoeff1002[6][2] ={
			//					{1.14298,-0.412802},  // 0.747789,-0.272215, 	// fc = 10 Hz, fs = 100 Hz, O = 2
			//					{1.56102,-0.641352},		 // fc = 5 Hz, fs = 100 Hz, O = 2
			//					{1.8227,-0.837182},		// fc = 2 Hz, fs = 100 Hz, O = 2
			//					{1.9112,-0.914976},		// fc = 1 hz fs = 100 O Hz O = 2
			//					{1.98223,-0.982385},       // fc = 0.2 Hz fs = 100 Hz O = 2
			//					{1.99111,-0.991154}};		// fc = 0.1 Hz fs = 100 Hz O = 2
			////-----butterworth filter Order = 2 Sampling Freq = 100Hz ------------
			//static	double Xn_2=0,Xn_1=0,Yn_1=0,Yn_2=0,filtdata=0;

			//			filtdata  = xcoeff1002[TimeConst][0]*ADCVolt;
			//			filtdata += xcoeff1002[TimeConst][1]*Xn_1;
			//			filtdata += xcoeff1002[TimeConst][2]*Xn_2;
			//			filtdata += ycoeff1002[TimeConst][0]*Yn_1;
			//			filtdata += ycoeff1002[TimeConst][1]*Yn_2;
			//			Xn_2 = Xn_1;
			//			Xn_1 = ADCVolt;
			//			Yn_2 = Yn_1;
			//			Yn_1 = filtdata;
			//return filtdata;
			//}
			////----- Start from here
			//Dim intTimeConst As Integer = 2

			//}; // fc = 0.1 Hz fs = 100 Hz O = 2


			////-----butterworth filter Order = 2 Sampling Freq = 100Hz ------------
			//static	double Xn_2=0,Xn_1=0,Yn_1=0,Yn_2=0,filtdata=0;
			filtdata = xcoeff1002(gintTimeConstant, 0) * ADCVolt;
			filtdata += xcoeff1002(gintTimeConstant, 1) * Xn_1;
			filtdata += xcoeff1002(gintTimeConstant, 2) * Xn_2;
			filtdata += ycoeff1002(gintTimeConstant, 0) * Yn_1;
			filtdata += ycoeff1002(gintTimeConstant, 1) * Yn_2;
			Xn_2 = Xn_1;
			Xn_1 = ADCVolt;
			Yn_2 = Yn_1;
			Yn_1 = filtdata;
			return filtdata;

		//}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return 0.0;
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

	private double funcGetFiltData_RefBeam(double ADCVolt)
	{
		//=====================================================================
		// Procedure Name        : funcGetFiltData_RefBeam
		// Parameters Passed     :  ADCVolts
		// Returns               : Double Returns Filtered data
		// Purpose               : for getting fliter data for ref beam.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 07.04.07
		// Revisions             : 
		//=====================================================================
		static double Xn_2 = 0;
		static double Xn_1 = 0;
		static double Yn_1 = 0;
		static double Yn_2 = 0;
		static double filtdata = 0;
		static int intCal_Mode;
		double[,] xcoeff1002 = {
			{
				0.067455,
				0.134911,
				0.067455
			},
			{
				0.020083,
				0.040167,
				0.020083
			},
			{
				0.003622,
				0.007243,
				0.003622
			},
			{
				0.000945,
				0.001889,
				0.000945
			},
			{
				3.9E-05,
				7.8E-05,
				3.9E-05
			},
			{
				1E-05,
				2E-05,
				1E-05
			}
		};
		double[,] ycoeff1002 = {
			{
				1.14298,
				-0.412802
			},
			{
				1.56102,
				-0.641352
			},
			{
				1.8227,
				-0.837182
			},
			{
				1.9112,
				-0.914976
			},
			{
				1.98223,
				-0.982385
			},
			{
				1.99111,
				-0.991154
			}
		};
		try {
			//            int TimeConst=2;
			//double 	S4FUNC	GetFiltData( double ADCVolt )
			//{
			//double xcoeff1002[6][3] ={
			//					{0.067455,0.134911,0.067455}, //0.131106,0.262213,0.131106, 	 // fc = 10 Hz, fs = 100 Hz, O = 2
			//					{0.020083,0.040167,0.020083}, // fc = 5 Hz, fs = 100 Hz, O = 2
			//					{0.003622,0.007243,0.003622}, //fc = 2 Hz fs = 100 Hz, O = 2
			//					{0.000945,0.001889,0.000945}, // fc = 1 Hz fs = 100 Hz O = 2
			//					{0.000039,0.000078,0.000039}, // fc = 0.2 Hz fs = 100 Hz O = 2
			//					{0.000010,0.000020,0.000010}
			//				 }; // fc = 0.1 Hz fs = 100 Hz O = 2
			//double ycoeff1002[6][2] ={
			//					{1.14298,-0.412802},  // 0.747789,-0.272215, 	// fc = 10 Hz, fs = 100 Hz, O = 2
			//					{1.56102,-0.641352},		 // fc = 5 Hz, fs = 100 Hz, O = 2
			//					{1.8227,-0.837182},		// fc = 2 Hz, fs = 100 Hz, O = 2
			//					{1.9112,-0.914976},		// fc = 1 hz fs = 100 O Hz O = 2
			//					{1.98223,-0.982385},       // fc = 0.2 Hz fs = 100 Hz O = 2
			//					{1.99111,-0.991154}};		// fc = 0.1 Hz fs = 100 Hz O = 2
			////-----butterworth filter Order = 2 Sampling Freq = 100Hz ------------
			//static	double Xn_2=0,Xn_1=0,Yn_1=0,Yn_2=0,filtdata=0;

			//			filtdata  = xcoeff1002[TimeConst][0]*ADCVolt;
			//			filtdata += xcoeff1002[TimeConst][1]*Xn_1;
			//			filtdata += xcoeff1002[TimeConst][2]*Xn_2;
			//			filtdata += ycoeff1002[TimeConst][0]*Yn_1;
			//			filtdata += ycoeff1002[TimeConst][1]*Yn_2;
			//			Xn_2 = Xn_1;
			//			Xn_1 = ADCVolt;
			//			Yn_2 = Yn_1;
			//			Yn_1 = filtdata;
			//return filtdata;
			//}
			////----- Start from here
			//Dim intTimeConst As Integer = 2

			//}; // fc = 0.1 Hz fs = 100 Hz O = 2


			////-----butterworth filter Order = 2 Sampling Freq = 100Hz ------------
			//static	double Xn_2=0,Xn_1=0,Yn_1=0,Yn_2=0,filtdata=0;

			filtdata = xcoeff1002(gintTimeConstant, 0) * ADCVolt;
			filtdata += xcoeff1002(gintTimeConstant, 1) * Xn_1;
			filtdata += xcoeff1002(gintTimeConstant, 2) * Xn_2;
			filtdata += ycoeff1002(gintTimeConstant, 0) * Yn_1;
			filtdata += ycoeff1002(gintTimeConstant, 1) * Yn_2;
			Xn_2 = Xn_1;
			Xn_1 = ADCVolt;
			Yn_2 = Yn_1;
			Yn_1 = filtdata;
			return filtdata;

		//}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return 0.0;
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

	private double funcGetFiltData_DoubleBeam(double ADCVolt)
	{
		//=====================================================================
		// Procedure Name        : funcGetFiltData_DoubleBeam
		// Parameters Passed     :  ADCVolts
		// Returns               : Returns Filtered data
		// Purpose               : for getting fliter data for double beam.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 07.04.07
		// Revisions             : 
		//=====================================================================
		static double Xn_2 = 0;
		static double Xn_1 = 0;
		static double Yn_1 = 0;
		static double Yn_2 = 0;
		static double filtdata = 0;
		static int intCal_Mode;
		double[,] xcoeff1002 = {
			{
				0.067455,
				0.134911,
				0.067455
			},
			{
				0.020083,
				0.040167,
				0.020083
			},
			{
				0.003622,
				0.007243,
				0.003622
			},
			{
				0.000945,
				0.001889,
				0.000945
			},
			{
				3.9E-05,
				7.8E-05,
				3.9E-05
			},
			{
				1E-05,
				2E-05,
				1E-05
			}
		};
		double[,] ycoeff1002 = {
			{
				1.14298,
				-0.412802
			},
			{
				1.56102,
				-0.641352
			},
			{
				1.8227,
				-0.837182
			},
			{
				1.9112,
				-0.914976
			},
			{
				1.98223,
				-0.982385
			},
			{
				1.99111,
				-0.991154
			}
		};
		try {
			//            int TimeConst=2;
			//double 	S4FUNC	GetFiltData( double ADCVolt )
			//{
			//double xcoeff1002[6][3] ={
			//					{0.067455,0.134911,0.067455}, //0.131106,0.262213,0.131106, 	 // fc = 10 Hz, fs = 100 Hz, O = 2
			//					{0.020083,0.040167,0.020083}, // fc = 5 Hz, fs = 100 Hz, O = 2
			//					{0.003622,0.007243,0.003622}, //fc = 2 Hz fs = 100 Hz, O = 2
			//					{0.000945,0.001889,0.000945}, // fc = 1 Hz fs = 100 Hz O = 2
			//					{0.000039,0.000078,0.000039}, // fc = 0.2 Hz fs = 100 Hz O = 2
			//					{0.000010,0.000020,0.000010}
			//				 }; // fc = 0.1 Hz fs = 100 Hz O = 2
			//double ycoeff1002[6][2] ={
			//					{1.14298,-0.412802},  // 0.747789,-0.272215, 	// fc = 10 Hz, fs = 100 Hz, O = 2
			//					{1.56102,-0.641352},		 // fc = 5 Hz, fs = 100 Hz, O = 2
			//					{1.8227,-0.837182},		// fc = 2 Hz, fs = 100 Hz, O = 2
			//					{1.9112,-0.914976},		// fc = 1 hz fs = 100 O Hz O = 2
			//					{1.98223,-0.982385},       // fc = 0.2 Hz fs = 100 Hz O = 2
			//					{1.99111,-0.991154}};		// fc = 0.1 Hz fs = 100 Hz O = 2
			////-----butterworth filter Order = 2 Sampling Freq = 100Hz ------------
			//static	double Xn_2=0,Xn_1=0,Yn_1=0,Yn_2=0,filtdata=0;

			//			filtdata  = xcoeff1002[TimeConst][0]*ADCVolt;
			//			filtdata += xcoeff1002[TimeConst][1]*Xn_1;
			//			filtdata += xcoeff1002[TimeConst][2]*Xn_2;
			//			filtdata += ycoeff1002[TimeConst][0]*Yn_1;
			//			filtdata += ycoeff1002[TimeConst][1]*Yn_2;
			//			Xn_2 = Xn_1;
			//			Xn_1 = ADCVolt;
			//			Yn_2 = Yn_1;
			//			Yn_1 = filtdata;
			//return filtdata;
			//}
			////----- Start from here
			//Dim intTimeConst As Integer = 2

			//}; // fc = 0.1 Hz fs = 100 Hz O = 2

			////-----butterworth filter Order = 2 Sampling Freq = 100Hz ------------
			//static	double Xn_2=0,Xn_1=0,Yn_1=0,Yn_2=0,filtdata=0;


			filtdata = xcoeff1002(gintTimeConstant, 0) * ADCVolt;
			filtdata += xcoeff1002(gintTimeConstant, 1) * Xn_1;
			filtdata += xcoeff1002(gintTimeConstant, 2) * Xn_2;
			filtdata += ycoeff1002(gintTimeConstant, 0) * Yn_1;
			filtdata += ycoeff1002(gintTimeConstant, 1) * Yn_2;
			Xn_2 = Xn_1;
			Xn_1 = ADCVolt;
			Yn_2 = Yn_1;
			Yn_1 = filtdata;
			return filtdata;

		//}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return 0.0;
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
