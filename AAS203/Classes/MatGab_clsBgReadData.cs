using BgThread;
using AAS203.Common;
using AAS203Library;
using AAS203Library.Analysis;

public class clsBgReadData : BgThread.IBgWorker
{

	#Region " Private Member Variables "

	private clsRawData objAnalysisRawData;
	private IBgThread mobjThreadController;
	private Method.clsAnalysisSampleParameters mobjCurrentSample;
	private Method.clsAnalysisStdParameters mobjCurrentStandard;
	private double Xtime;
	private double Xtime_temp = 0;
	private Analysis.clsRawData.enumSampleType mintSampleType;
	private double mdblUVAbsorbance;

	private int mintRunNumberIndex;
	#End Region

	#Region "Private Member Variables"

	public int CStart;
	public int CEndTime;
	public bool Filter_flag;
	public int lPipe = 0;
	public int Wlen = 801;
	public const  FILTMAX = 1001;
	public double[] FiltPipe = new double[FILTMAX - 1];
	public event  AbsorbanceValueChanged;
	public event  AspirationMessageChanged;

	public bool IsAlt_S_Pressed;
	#End Region

	#Region " Public Properties "

	public Analysis.clsRawData.enumSampleType SampleType {
		get { return mintSampleType; }
		set { mintSampleType = Value; }
	}

	public double UVAbsorbance {
		get { return mdblUVAbsorbance; }
		set { mdblUVAbsorbance = Value; }
	}

	#End Region

	#Region " Constructors "

	public clsBgReadData()
	{
		//=====================================================================
		// Procedure Name        : New 
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To initialize the class instance
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 18-Jan-2007 10:30 am
		// Revisions             : 1
		//=====================================================================
		try {
			if (gobjNewMethod.QuantitativeDataCollection.Count > 0) {
				mintRunNumberIndex = gobjNewMethod.QuantitativeDataCollection.Count - 1;
			} else {
				mintRunNumberIndex = 0;
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

	public clsBgReadData(int intStartTime, int intEndTime, clsRawData.enumSampleType intSampleType, Method.clsAnalysisStdParameters objCurStd, Method.clsAnalysisSampleParameters objCurSample)
	{
		//=====================================================================
		// Procedure Name        : New 
		// Parameters Passed     : intStartTime,intEndTime,intSampleType
		//                         objCurStd,objCurSample
		// Returns               : None
		// Purpose               : To initialize the class instance
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 18-Jan-2007 10:30 am
		// Revisions             : 1
		//=====================================================================
		try {
			if (gobjNewMethod.QuantitativeDataCollection.Count > 0) {
				mintRunNumberIndex = gobjNewMethod.QuantitativeDataCollection.Count - 1;
			} else {
				mintRunNumberIndex = 0;
			}

			mintSampleType = intSampleType;
			mobjCurrentStandard = objCurStd;
			mobjCurrentSample = objCurSample;

			//--- Added by Sachin Dokhale on 08.05.07
			CEndTime = intEndTime;
			CStart = intStartTime;
		//---

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

	#Region " Background Thread Worker functions "

	public void BgThread.IBgWorker.Initialize(BgThread.IBgThread Controller)
	{
		//=====================================================================
		// Procedure Name        : Initialize
		// Parameters Passed     : Controller As BgThread.IBgThread
		// Returns               : None
		// Purpose               : To Initialize the worker thread
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 26-Dec-2006
		// Revisions             : 1
		//=====================================================================
		try {
			mobjThreadController = Controller;

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

	public void BgThread.IBgWorker.Work()
	{
		//=====================================================================
		// Procedure Name        : Work
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To work the process in background thread
		// Description           : Implements Start Method of IBgWorker interface
		//                         to actually place the BgThread Process.
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 26-Dec-2006
		// Revisions             : 1
		//=====================================================================
		string strPreviousStatusMessage;
		try {
			if (gblnShowThreadOnfrmMDIStatusBar) {
				strPreviousStatusMessage = gobjMain.StatusBar1.Text;
				gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage + " Reading Data.. Please Wait..";
				Application.DoEvents();
			}

			if (gintInstrumentBeamType == Instrument.enumInstrumentBeamType.DoubleBeam) {
				//---In blank aspiration the values are to be manipulated so that it shows zero.
				//---For every blank aspiration stage a very first command 
				//---to be given to instrument is "GET_Absoffset"
				if (gobjInst.Mode == EnumCalibrationMode.AA) {
					if (this.SampleType == clsRawData.enumSampleType.BLANK) {
						gobjCommProtocol.funcGetAbsOffset();
					}
				}
			}

			if ((gobjNewMethod.OperationMode == EnumOperationMode.MODE_UVABS)) {
				//---Read data from UV Mode
				Read_Quant_Data_UV_Mode(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.IntegrationTime);
			} else {
				if ((gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.MeasurementMode == enumMeasurementMode.Integrate)) {
					//---Read data for Measurement Mode is Integration
					//---Wait for analysis for perticulor time.
					if (!(Filter_flag)) {
						Wait_For_Analysis(2);
					} else {
						Wait_For_Analysis(2);
					}
					Read_Quant_Data_Integration_Mode(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.IntegrationTime);
				} else if ((gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.MeasurementMode == enumMeasurementMode.PeakArea | gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.MeasurementMode == enumMeasurementMode.PeakHeight)) {
					//---Read data for Measurement Mode is peak height or peak area.
					Read_Quant_Data_PkHt_Area_Mode(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.IntegrationTime);
				}
			}

			if (mobjThreadController.Running == true) {
				mobjThreadController.Completed(false);
			} else {
				mobjThreadController.Completed(true);
			}
			Application.DoEvents();

			if (gblnShowThreadOnfrmMDIStatusBar) {
				gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage;
				Application.DoEvents();
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			mobjThreadController.Failed(ex);
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

	#Region " Private functions "

	private void Wait_For_Analysis(int intWaitTime)
	{
		//=====================================================================
		// Procedure Name        : Wait_For_Analysis
		// Parameters Passed     : intWaitTime in integer
		// Returns               : None
		// Purpose               : Wait for analysis
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 26-Dec-2006
		// Revisions             : 1
		//=====================================================================
		//void	Wait_For_Analysis(HWND hwnd, int time)
		//{
		//   char	str[40]="";
		//   double	abs=0.0;
		//   int		t=0;
		//   clock_t	CStart, CEnd;
		//   CStart=CEnd=clock();
		//   ShowAspMessage("Waiting for Stability");
		//   do
		//   {
		//	    t++;
		//	    if (t%500==0)
		//       {
		//	        abs = Get_Reading();
		//	        GetValInString(abs, str, Method->Mode);
		//	        SetDlgItemText(hwnd,IDC_QAABS, str);
		//       }
		//	    CEnd = clock();
		//	    if ((CEnd-CStart) >= (time * CLK_TCK))
		//	        break;
		//   } while (1);
		//   ShowAspMessage("Reading Wait ...");
		//}

		string str = "";
		double dblabs = 0.0;
		int int_t = 0;
		long lngCStart;
		long lngCEnd;

		try {
			//--- init time variable
			lngCStart = 0;
			lngCEnd = 0;
			//--- Raise event to show the message for "Waiting for Stability"
			if (AspirationMessageChanged != null) {
				AspirationMessageChanged("Waiting for Stability", false);
			}

			//---delay added before readdata as suggested by mr. vck
			//---by deepak on 29.01.08
			gobjCommProtocol.mobjCommdll.subTime_Delay(2700);
			Application.DoEvents();

			do {
				int_t += 1;
				if (((int_t % 500) == 0)) {
					dblabs = gobjClsAAS203.Get_Reading(SampleType, mobjCurrentStandard, Filter_flag, mobjCurrentSample);
					if (AbsorbanceValueChanged != null) {
						AbsorbanceValueChanged(dblabs);
					}
				}

				lngCEnd += 50;
				//--- Exit from time event
				if (((lngCEnd - CStart) >= (intWaitTime * 1000))) {
					break; // TODO: might not be correct. Was : Exit Do
				}
				//--- Set delay for time
				gobjCommProtocol.mobjCommdll.subTime_Delay(intWaitTime);
			} while ((1));

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

	private bool Read_Quant_Data_Integration_Mode(int intIntegrationTimeIn)
	{
		//=====================================================================
		// Procedure Name        : Read_Quant_Data_Integration_Mode
		// Parameters Passed     : intIntegrationTimeIn as inetgration time in integer
		// Returns               : return true if success.
		// Purpose               : Read the data from instument in integration mode
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 26-Dec-2006
		// Revisions             : 1
		//=====================================================================
		//void	Read_Quant_Data_Integration_Mode(HWND hwnd, HDC hdc, CURVEDATA *AnaGraph)
		//{
		//   double	xtime1=0;
		//   char	str[40]="";
		//   RAW_DATA_NODE   DataNode;
		//   RAW_DATA_STRUCT Data;
		//   double	abs=0.0,asum =0.0;
		//   int		aread_count=0; 
		//   int		CEndTime;
		//   clock_t	CStart, CEnd, CEnd1,CEnd2;
		//   InitRawDataNode(&DataNode);
		//   DataNode.SampType=SampType;
		//   if (SampType==STD)
		//   {
		//	    if (CurStd!=NULL)
		//       {
		//	        DataNode.Nstd = CurStd->Data.StdNo;
		//	        strcpy(DataNode.SampName,CurStd->Data.Std_Name);
		//	    }
		//   }
		//   else if (SampType==SAMP)
		//   {
		//	    if (CurSamp!=NULL)
		//       {
		//		    DataNode.Nstd =CurSamp->Data.SampNo;
		//		    strcpy(DataNode.SampName,CurSamp->Data.Samp_Name);
		//	    }
		//   }
		//   AddRawData(&DataNode);
		//   xtime1 = Xtime;
		//   if (Filter_flag)
		//   {
		//	    FiltRead();
		//	    InitSmooth(hwnd);
		//   }
		//   CEndTime = (int) ((double) Method->QuantData->Param.Int_Time * (double) CLK_TCK);
		//   CEnd2=CEnd1=CStart=CEnd=clock();
		//   do
		//   {
		//       abs = Get_Reading();
		//	    if (Filter_flag)
		//       {
		//	        abs=Get_Filtered(abs);
		//           If (checkmindetect) Then
		//	        {
		//	            abs = CheckForMinAbsLevel(abs); 
		//	        }
		//	        aread_count=0;
		//       }
		//	    else
		//       {
		//	        asum += abs;
		//	        aread_count++;
		//	    }
		//	    CEnd=clock();
		//	    if (CEnd != CEnd1 )
		//       {
		//           If (aread_count > 0) Then
		//		        abs = asum/aread_count;
		//           aread_count=0;
		//	        asum=0;
		//           If (checkmindetect) Then
		//	        {        
		//	            abs=CheckForMinAbsLevel(abs); 
		//	        }
		//	        Xtime += ( ((double)(CEnd-CEnd1)/(double) CLK_TCK));
		//	        CEnd1 = CEnd;
		//	        InitRawDataStruct(&Data);
		//	        Data.Xval = Xtime; 
		//           Data.Abs  = abs;
		//	        AddRawDataItems(&Data);
		//	        if (Xtime>=AnaGraph->Xmax)
		//           {
		//		        AnaGraph->Xmin += Method->QuantData->Param.Int_Time;
		//		        AnaGraph->Xmax += Method->QuantData->Param.Int_Time;
		//		        Calculate_Analysis_Graph_Param(AnaGraph);
		//		        InvalidateRect(hwnd, NULL, FALSE);
		//		        UpdateWindow(hwnd);
		//		        Afirst=TRUE;
		//		        Xoldt=-1;Yoldt=-1;
		//		        CEnd1 = clock();
		//		        CStart += (CEnd1-CEnd);
		//		    }
		//	        if (Afirst)
		//           {
		//		        PlotInit(hdc, Xtime, abs, AnaGraph->RC, AnaGraph);
		//		        Afirst=FALSE;
		//		    }
		//           Else
		//		        Plotg(hdc, Xtime, abs, AnaGraph->RC, AnaGraph);
		//       }
		//	    if ( (CEnd-CStart) % (Method->QuantData->Param.Int_Time) == 0 && CEnd2 != CEnd1)
		//       {
		//	        CEnd2=CEnd1;
		//	        GetValInString(abs, str, Method->Mode);
		//	        SetDlgItemText(hwnd,IDC_QAABS, str);
		//	    }
		//       CEnd = clock();
		//       If ((CEnd - CStart) >= CEndTime) Then
		//	        break;
		//   } while (1);
		//   Xtime = xtime1 + (double) Method->QuantData->Param.Int_Time;
		//}

		double xtime1;
		string str;
		double abs;
		double asum;
		int aread_count;
		int intEndTime;
		long CStart;
		long CEnd;
		long CEnd1;
		long CEnd2;
		string strData;
		Analysis.clsRawDataReadings.RAW_DATA objRawDataReading;
		double avgabs;
		bool blnIsFirstRead = true;
		try {
			objAnalysisRawData = new clsRawData();

			//---Set X time
			Xtime = this.CEndTime;
			xtime1 = Xtime;
			//---Check Flter Setting for fliter Reading and init. smoothing data
			if ((Filter_flag)) {
				FiltRead();
				InitSmooth();
			}
			//---Reading wait for a time
			if (AspirationMessageChanged != null) {
				AspirationMessageChanged("Reading Wait ...", false);
			}

			//---delay added before readdata as suggested by mr. vck
			//---by deepak on 29.01.08
			//Call gobjCommProtocol.mobjCommdll.subTime_Delay(1350)
			//Call Application.DoEvents()

			intEndTime = intIntegrationTimeIn * 1000;

			CEnd2 = 0;
			CEnd1 = 0;
			CStart = 0;
			CEnd = 0;

			do {
				objRawDataReading = new Analysis.clsRawDataReadings.RAW_DATA();

				//---Read Abs Value from instrument 
				abs = gobjClsAAS203.Get_Reading(mintSampleType, mobjCurrentStandard, Filter_flag, mobjCurrentSample);
				//---Check for filter settng for abs.
				if ((Filter_flag)) {
					abs = Get_Filtered(abs);
					//---Validate abs value
					if ((gstructSettings.SetMinAbsLimit)) {
						abs = gobjClsAAS203.CheckForMinAbsLevel(abs);
					}
					aread_count = 0;
				} else {
					asum += abs;
					aread_count += 1;
				}

				CEnd += 50;

				//---Check timer
				if ((CEnd != CEnd1)) {
					if ((aread_count > 0)) {
						abs = asum / aread_count;
					}
					aread_count = 0;
					asum = 0;
					//---Validate abs value
					if ((gstructSettings.SetMinAbsLimit)) {
						abs = gobjClsAAS203.CheckForMinAbsLevel(abs);
					}

					Xtime += (CEnd - CEnd1) / 1000;

					CEnd1 = CEnd;

					strData = "";
					strData = Xtime + "," + abs;

					objRawDataReading.Absorbance = abs;
					objAnalysisRawData.Readings.Add(objRawDataReading);

					gobjCommProtocol.mobjCommdll.subTime_Delay(100);
					Application.DoEvents();
				}


				//---get average of raw data
				avgabs = GetAvgValOfAnalysis(objAnalysisRawData);
				if (blnIsFirstRead == true) {
					//strData = Me.CEndTime & "," & avgabs
					mobjThreadController.Display(this.CEndTime + "," + abs + "," + avgabs);
					blnIsFirstRead = false;
				}

				strData = strData + "," + avgabs;
				mobjThreadController.Display(strData);

				if (((CEnd - CStart) % (intIntegrationTimeIn) == 0 & CEnd2 != CEnd1)) {
					CEnd2 = CEnd1;
					if (AbsorbanceValueChanged != null) {
						AbsorbanceValueChanged(abs);
					}
				}

				CEnd += 100;

				if (((CEnd - CStart) >= intEndTime)) {
					if (AspirationMessageChanged != null) {
						AspirationMessageChanged("Reading Completed ...", true);
					}
					break; // TODO: might not be correct. Was : Exit Do
				}

			} while (true);

			Xtime = xtime1 + intIntegrationTimeIn;
			//--- Added by Sachin Dokhale 
			strData = "";
			strData = Xtime + "," + avgabs + "," + avgabs;
			//strData = strData & "," & avgabs
			mobjThreadController.Display(strData);
			//---
			this.CEndTime = Xtime;
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
		}
	}

	private void InitSmooth()
	{
		//=====================================================================
		// Procedure Name        : InitSmooth
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : Init data for smoothing
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 26-Dec-2006
		// Revisions             : 1
		//=====================================================================
		//void	InitSmooth(HWND hwnd)
		//{
		//char		str[15]="";
		//double  	abs1=0.0;
		//int		count, count1;
		//#define	IVAL	3

		//ShowAspMessage("Waiting for Stability");
		//lPipe=0;

		//for(count=0;count<Wlen-1; count+=IVAL)
		//{
		//   abs1 = Get_Reading();
		//	for(count1=0; count1<IVAL; count1++)
		//   {
		//	    FiltPipe[lPipe++]=abs1;
		//       If (lPipe >= Wlen - 1) Then
		//		    break;
		//	}
		//	GetValInString(abs1, str, Method->Mode);
		//	SetDlgItemText(hwnd,IDC_QAABS, str);
		//   If (lPipe >= Wlen - 1) Then
		//	    break;
		//}
		//ShowAspMessage("Reading Wait ...");
		//}

		string str = "";
		double dblabs1 = 0.0;
		int intcount;
		int intcount1;
		const object IVAL = 3;
		try {
			lPipe = 0;
			intcount = 0;
			while ((true)) {
				dblabs1 = gobjClsAAS203.Get_Reading(mintSampleType, mobjCurrentStandard, Filter_flag, mobjCurrentSample);

				for (intcount1 = 0; intcount1 <= IVAL - 1; intcount1++) {
					FiltPipe(lPipe + 1) = dblabs1;
					lPipe += 1;
					if ((lPipe >= Wlen - 1)) {
						break; // TODO: might not be correct. Was : Exit For
					}
				}

				if (AbsorbanceValueChanged != null) {
					AbsorbanceValueChanged(dblabs1);
				}

				if ((lPipe >= Wlen - 1)) {
					break; // TODO: might not be correct. Was : Exit Do
				}

				intcount += IVAL;
				if (intcount >= Wlen - 1)
					break; // TODO: might not be correct. Was : Exit Do
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
			//---------------------------------------------------------
		}
	}

	private void FiltRead()
	{
		//=====================================================================
		// Procedure Name        : FiltRead
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : Read the filter setting
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 26-Dec-2006
		// Revisions             : 1
		//=====================================================================
		//void(FiltRead(void))
		//{
		//char	str[128];
		//GetProfileStringFromIniFile("Filter Setting", "Filter Window Size" ,"201", str, "aas.ini");
		//Wlen = atoi(str)
		//if (Wlen<20 || Wlen>FILTMAX-1)
		//Wlen=201;
		//}

		try {
			//---get filter window size
			Wlen = gstructSettings.Filter_Window_Size;

			//---validate filter window size
			if ((Wlen < 20 | Wlen > FILTMAX - 1)) {
				Wlen = 201;
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

	private double Get_Filtered(double Y1)
	{
		//=====================================================================
		// Procedure Name        : Get_Filtered
		// Parameters Passed     : Y1 axis data 
		// Returns               : Double
		// Purpose               : return the filtered data
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 26-Dec-2006
		// Revisions             : 1
		//=====================================================================
		//double Get_Filtered(double y1)
		//{
		//int	i;
		//double  sy=0, sc=0, y2=0.0, tol=0.09;
		//sy=y1;
		//if (lPipe<Wlen-1)
		//{
		//   FiltPipe[lPipe]=y1;
		//	lPipe++;
		//}
		//else
		//{
		//   if (lPipe>Wlen+99)
		//   {
		//	    sy=0;
		//		for(i=0; i<Wlen-1; i++)
		//		    sy+= FiltPipe[i];
		//		 sy/=(double) i;
		//		 if (Method->Mode==MODE_AA || Method->Mode==MODE_AABGC)
		//		    tol=(double) 0.09;
		//		 else if (Method->Mode==MODE_EMISSION)
		//		    tol=(double) 8.0;
		//		 if (fabs(sy-y1)>tol)
		//        {
		//		    lPipe=0;
		//		 	return y1;
		//		 }
		//	}
		//	sy=0.0;
		//	for(i=0; i<Wlen-2; i++)
		//	    FiltPipe[i]=FiltPipe[i+1];
		//	FiltPipe[i] =y1;
		//	for(i=0; i<Wlen-1; i++)
		//   {
		//	    y2 = FnHamming(i);
		//		sy+= (y2*FiltPipe[Wlen-i-1]);
		//		sc+=y2;
		//	}
		//   If (sc! = 0.0) Then
		//	    sy/=sc;
		//	lPipe++;
		//}
		//sy  = GetValConvertedTo( sy, Method->Mode);
		//return sy;
		//}

		int i;
		double sy = 0;
		double sc = 0;
		double y2 = 0.0;
		double tol = 0.09;
		try {
			sy = Y1;

			if ((lPipe < Wlen - 1)) {
				FiltPipe(lPipe) = Y1;
				lPipe += 1;
			} else {
				if ((lPipe > Wlen + 99)) {
					sy = 0;
					//For i = 0 To i < Wlen - 1
					for (i = 0; i <= Wlen - 2; i++) {
						sy += FiltPipe(i);
					}
					sy /= i;
					if ((gobjNewMethod.OperationMode == EnumOperationMode.MODE_AA | gobjNewMethod.OperationMode == EnumOperationMode.MODE_AABGC)) {
						tol = 0.09;
					} else if ((gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION)) {
						tol = 8.0;
						//If (Math.Abs(sy - Y1) > tol) Then
						//    lPipe = 0
						//    Return Y1
						//End If
					}
					if ((Math.Abs(sy - Y1) > tol)) {
						lPipe = 0;
						return Y1;
					}

					sy = 0.0;
				}
				//For i = 0 To i < Wlen - 2
				for (i = 0; i <= Wlen - 3; i++) {
					FiltPipe(i) = FiltPipe(i + 1);
				}

				FiltPipe(i) = Y1;
				//For i = 0 To i < Wlen - 1
				for (i = 0; i <= Wlen - 2; i++) {
					y2 = FnHamming(i);
					sy += (y2 * FiltPipe(Wlen - i - 1));
					sc += y2;
				}
				if ((sc != 0.0)) {
					sy /= sc;
				}
				lPipe += 1;
			}

			return sy;
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

	private double FnHamming(int n)
	{
		//=====================================================================
		// Procedure Name        : FnHamming
		// Parameters Passed     : n as integer
		// Returns               : Double
		// Purpose               : Get calculated value
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 26-Dec-2006
		// Revisions             : 1
		//=====================================================================
		//double	FnHamming(int	n)
		//{
		//double val=0.0;
		// val = (double)0.54-(double)0.46* cos((double)(2.0* M_PI * (double)n/ (double)(Wlen-1)));
		// return val;
		//}

		double val = 0.0;
		try {
			//val = (double)0.54-(double)0.46* cos((double)(2.0 * M_PI * (double)n/ (double)(Wlen-1)));
			val = 0.54 - 0.46 * Math.Cos((2.0 * Math.PI * n / (Wlen - 1)));
			return val;
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

	private bool Read_Quant_Data_UV_Mode(int intIntegrationTimeIn)
	{
		//=====================================================================
		// Procedure Name        : Read_Quant_Data_UV_Mode
		// Parameters Passed     : intIntegrationTimeIn as inetgration time in integer
		// Returns               : return true if success.
		// Purpose               : Read the data from instument in integration mode
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 24-Jan-2007 06:25 pm
		// Revisions             : 1
		//=====================================================================
		//void	Read_Quant_Data_UV_Mode(HWND hwnd)
		//{
		//   char		str[80]="";
		//	char        str1[20]="";
		//	double		abs=0.0,asum =0.0, blankabs;
		//	int			aread_count=0; 
		//	int		    CEndTime;
		//	clock_t		CStart, CEnd, CEnd1,CEnd2;
		//	static		int	 Blankval=2047;
		//	int			sampval;

		//	CEndTime = (int) ((double) Method->QuantData->Param.Int_Time * (double) CLK_TCK);
		//	CEnd2=CEnd1=CStart=CEnd=clock();

		//   Do
		//	{
		//		sampval = adcscan();
		//       #If QDEMO Then
		//		    if (SampType==BLANK)
		//			    sampval=4000+random(20);
		//       #End If
		//		abs = GetEnergy(sampval); 
		//		if (SampType==BLANK)
		//		    Blankval = sampval;
		//		blankabs = GetEnergy(Blankval);
		//		if (blankabs!= (double) 0.0)
		//			abs = abs*(double) 100.0/blankabs;
		//		if (abs> (double) 0.0 && abs<(double) 300.0)
		//		{
		//			abs = 2.0 -log10(abs);
		//			asum += abs;
		//			aread_count++;
		//		}
		//		CEnd=clock();
		//       If (CEnd != CEnd1) Then
		//		{
		//           If (aread_count > 0) Then
		//				abs = asum/aread_count;

		//           If (checkmindetect) Then
		//				abs = CheckForMinAbsLevel(abs);

		//			CEnd1 = CEnd;
		//			strcpy(str,"Abs ");
		//			StoreAbsAccurate(abs,str1);
		//			strcat(str,str1);
		//			SetWindowText(GetDlgItem(hwnd, IDC_UVABS), str);
		//		}
		//		if ( (CEnd-CStart) % (Method->QuantData->Param.Int_Time)==0 && CEnd2!=CEnd1)
		//		{
		//			CEnd2=CEnd1;
		//			GetValInString(abs, str, Method->Mode);
		//			SetDlgItemText(hwnd,IDC_QAABS, str);
		//		}
		//		CEnd = clock();
		//       If ((CEnd - CStart) >= CEndTime) Then
		//			break;
		//	}
		//	while (1);
		//   If (aread_count > 0) Then
		//	{
		//	    abs = asum/aread_count;

		//       If (checkmindetect) Then
		//		    abs = CheckForMinAbsLevel(abs);
		//		StoreCalculateDisplayQuantValueUvMode(hwnd, abs);
		//	}
		//}
		//************************************************************
		double abs;
		double asum;
		double blankabs;
		int aread_count;
		int sampval;
		static int Blankval = 2047;
		int intCEndTime;
		long CStart;
		long CEnd;
		long CEnd1;
		long CEnd2;

		try {
			//---Read the data for UV quant data
			//---Set Time variable with integration time
			intCEndTime = intIntegrationTimeIn * 1000;

			CEnd2 = 0;
			CEnd1 = 0;
			CStart = 0;
			CEnd = 0;

			while ((true)) {
				if (mobjThreadController.Running) {
					//If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
					if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
						//---pass the Filter flag and Sample data type to the analysis data read (scan) function
						////--- modified by Sachin Dokhale 06.06.08
						//sampval = gobjClsAAS203.ADCScan(Filter_flag, SampleType)
						Random objRamdom = new Random(20);
						sampval = 4000 + objRamdom.Next(5, 100);
					////---
					} else {
						////--- modified by Sachin Dokhale 06.06.08
						//Dim objRamdom As New Random(20)
						//sampval = 4000 + objRamdom.Next(5, 100)
						sampval = gobjClsAAS203.ADCScan(Filter_flag, SampleType);
						////---
					}

					//#If QDEMO Then
					//If (SampleType = clsRawData.enumSampleType.BLANK) Then
					//Dim objRamdom As New Random(20)
					//sampval = 4000 + objRamdom.Next(5, 100)   'Rnd(20)
					//End If
					//#End If

					//---Convert sample value (ADC) to the Energy
					abs = gFuncGetEnergy(sampval);

					if ((SampleType == clsRawData.enumSampleType.BLANK)) {
						Blankval = sampval;
					}

					//---Convert blank value (ADC) to then Energy
					blankabs = gFuncGetEnergy(Blankval);
					//---Cal. actual energy
					if ((blankabs != 0.0)) {
						abs = abs * 100.0 / blankabs;
					}

					if ((abs > 0.0 & abs < 300.0)) {
						abs = 2.0 - Math.Log10(abs);
						asum += abs;
						aread_count += 1;
					}

					CEnd += 50;

					if ((CEnd != CEnd1)) {
						if ((aread_count > 0)) {
							abs = asum / aread_count;
						}
						if ((gstructSettings.SetMinAbsLimit)) {
							abs = gobjClsAAS203.CheckForMinAbsLevel(abs);
						}
						CEnd1 = CEnd;
						//StoreAbsAccurate(abs,str1);
						//strcat(str,str1);
						//SetWindowText(GetDlgItem(hwnd, IDC_UVABS), str);
						//---display absorbance value
						mobjThreadController.Display(abs);
						gobjCommProtocol.mobjCommdll.subTime_Delay(50);
						Application.DoEvents();
					}

					if (((CEnd - CStart) % (intIntegrationTimeIn) == 0 & CEnd2 != CEnd1)) {
						CEnd2 = CEnd1;
						//GetValInString(abs, str, Method->Mode);
						//SetDlgItemText(hwnd,IDC_QAABS, str);
						//---Raise event to display data on label
						if (AbsorbanceValueChanged != null) {
							AbsorbanceValueChanged(abs);
						}
					}

					CEnd += 50;
					//---Exit from loop when time is expired
					if (((CEnd - CStart) >= intCEndTime)) {
						break; // TODO: might not be correct. Was : Exit Do
					}
				} else {
					if (AspirationMessageChanged != null) {
						AspirationMessageChanged("Reading failed ...", true);
					}
					break; // TODO: might not be correct. Was : Exit Do
				}
			}

			if ((aread_count > 0)) {
				abs = asum / aread_count;
				if ((gstructSettings.SetMinAbsLimit)) {
					abs = gobjClsAAS203.CheckForMinAbsLevel(abs);
				}

				//---Store, Calculate and Display Quantitative Value in UV Mode.
				mdblUVAbsorbance = abs;

			}

			if (AspirationMessageChanged != null) {
				AspirationMessageChanged("Reading Completed ...", true);
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

	private void Read_Quant_Data_PkHt_Area_Mode(int intIntegrationTimeIn)
	{
		//=====================================================================
		// Procedure Name        : Read_Quant_Data_PkHt_Area_Mode
		// Parameters Passed     : intIntegrationTimeIn as inetgration time in integer
		// Returns               : 
		// Purpose               : Read the data from instument for peak height mode
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 24-Jan-2007 06:25 pm
		// Revisions             : 1
		//=====================================================================
		//void	Read_Quant_Data_PkHt_Area_Mode(HWND hwnd, HDC hdc, CURVEDATA *AnaGraph)
		//{
		//double	         absold=0.0, abu=0.0, abl=0.0;
		//char            str[40]="";
		//RAW_DATA_NODE   DataNode;
		//RAW_DATA_STRUCT Data;
		//double			 abs=0.0;
		//BOOL			 peakd = FALSE;
		//clock_t		 CStart, CEnd, CEnd1,CEnd2;
		//MSG			 msg;

		//#If QDEMO Then
		//   int	no=0;
		//#End If

		//InitRawDataNode(&DataNode);
		//DataNode.SampType=SampType;
		//if (SampType==STD){
		//   if (CurStd!=NULL){
		//	    DataNode.Nstd = CurStd->Data.StdNo;
		//	    strcpy(DataNode.SampName,CurStd->Data.Std_Name);
		//   }
		//}
		//else if (SampType==SAMP){
		//   if (CurSamp!=NULL){
		//	    DataNode.Nstd =CurSamp->Data.SampNo;
		//		strcpy(DataNode.SampName,CurSamp->Data.Samp_Name);
		//   }
		//}
		//AddRawData(&DataNode);
		//CEnd2=CEnd1=CStart=CEnd=clock();
		//for(lPipe=0; lPipe<8; lPipe++);
		//   absold=Get_Reading();
		//abu=absold+0.01;
		//abl=absold-0.01;
		//for(lPipe=0; lPipe<8; lPipe++){
		//   abs = Get_Reading();
		//	FiltPipe[lPipe+1]=abs;//ORG
		//}

		//do {
		//   #If !QDEMO Then
		//       abs =  Get_Reading();
		//   	if (abs>200)
		//	        break;
		//       abs =  Get_Smooth_Data_inPkHt_Area(abs);
		//   #End If
		//   CEnd=clock();
		//   if (CEnd!=CEnd1 ){
		//       #If QDEMO Then
		//	        abs =  Get_Reading();
		//   	    if (abs>200)
		//	    	    break;
		//	        abs =  Get_Smooth_Data_inPkHt_Area(abs);
		//      #End If
		//       Xtime += ( ((double)(CEnd-CEnd1)/(double) CLK_TCK));
		//   	CEnd1 = CEnd;
		//	    InitRawDataStruct(&Data);
		//	    Data.Xval=Xtime; Data.Abs=abs;
		//	    AddRawDataItems(&Data);
		//	    //--mdf by sk on 3/8/2001
		//	    //peakd= TestPeakValue(hwnd); //org commented
		//	    peakd= TestPeakValue(hwnd,AnaGraph);
		//       #If QDEMO Then
		//	        no++;
		//          if (no>1100)
		//	            break;
		//      #End If
		//       if (peakd){
		//	        if (absold>abs && (abs<=abu && abs>=abl))
		//		        break;
		//       }
		//       if (Xtime>=AnaGraph->Xmax){
		//	        AnaGraph->Xmin += Method->QuantData->Param.Int_Time;
		//		    AnaGraph->Xmax += Method->QuantData->Param.Int_Time;
		//		    Calculate_Analysis_Graph_Param(AnaGraph);
		//		    InvalidateRect(hwnd, NULL, FALSE); //AnaGraph->RC, TRUE);
		//		    UpdateWindow(hwnd);
		//		    Afirst=TRUE;
		//		    Xoldt=-1;Yoldt=-1;
		//		    CEnd1 = clock();
		//		    CStart += (CEnd1-CEnd);
		//       }
		//	    if (Afirst){
		//	        PlotInit(hdc, Xtime, abs, AnaGraph->RC, AnaGraph);
		//		    Afirst=FALSE;
		//	    }
		//       Else
		//	        Plotg(hdc, Xtime, abs, AnaGraph->RC, AnaGraph);
		//   }
		//   if ( (CEnd-CStart) % (Method->QuantData->Param.Int_Time)==0 && CEnd2!=CEnd1)  //param.itime
		//   {
		//       CEnd2=CEnd1;
		//       GetValInString(abs, str, Method->Mode);
		//	    SetDlgItemText(hwnd,IDC_QAABS, str);
		//   }
		//   CEnd = clock();
		//   CheckMsg(NULL, &msg);
		//   If (IsAlt_S_Pressed()) Then
		//       break;
		//}  while (1);
		////  Xtime= xtime1+(double) Method->QuantData->Param.Int_Time;
		//lPipe=0;
		//}
		//*************************************************************
		double absold;
		double abu;
		double abl;
		double abs;
		bool peakd;
		Analysis.clsRawData DataNode;
		Analysis.clsRawDataReadings.RAW_DATA Data;
		int no;
		long CStart;
		long CEnd;
		long CEnd1;
		long CEnd2;

		try {
			Xtime = this.CEndTime;

			CEnd2 = 0;
			CEnd1 = 0;
			CStart = 0;
			CEnd = 0;

			//If gstructSettings.AppMode = EnumAppMode.DemoMode Then
			if (!((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D))) {
				no = 0;
			}

			for (lPipe = 0; lPipe <= 8 - 1; lPipe++) {
				absold = gobjClsAAS203.Get_Reading(SampleType, mobjCurrentStandard, Filter_flag, mobjCurrentSample);
			}

			abu = absold + 0.01;
			abl = absold - 0.01;

			for (lPipe = 0; lPipe <= 8 - 1; lPipe++) {
				abs = gobjClsAAS203.Get_Reading(SampleType, mobjCurrentStandard, Filter_flag, mobjCurrentSample);
				FiltPipe(lPipe + 1) = abs;
			}

			do {
				//If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then

				if (!((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D))) {
					abs = gobjClsAAS203.Get_Reading(SampleType, mobjCurrentStandard, Filter_flag, mobjCurrentSample);
					if ((abs > 200)) {
						break; // TODO: might not be correct. Was : Exit Do
					}
					abs = Get_Smooth_Data_inPkHt_Area(abs);
				}

				CEnd += 50;

				if ((CEnd != CEnd1)) {
					//If gstructSettings.AppMode = EnumAppMode.DemoMode Then
					if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
						abs = gobjClsAAS203.Get_Reading(SampleType, mobjCurrentStandard, Filter_flag, mobjCurrentSample);
						if ((abs > 200)) {
							break; // TODO: might not be correct. Was : Exit Do
						}
						abs = Get_Smooth_Data_inPkHt_Area(abs);
					}

					Xtime += (CEnd - CEnd1) / 1000;
					CEnd1 = CEnd;

					//############################################################
					//TODO function to find Peak Area or Height 
					//############################################################
					//peakd= TestPeakValue(hwnd,AnaGraph);
					//peakd = TestPeakValue()
					//############################################################

					//If gstructSettings.AppMode = EnumAppMode.DemoMode Then
					if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
						no += 1;
						if ((no > 1100)) {
							break; // TODO: might not be correct. Was : Exit Do
						}
					}

					if ((peakd)) {
						if ((absold > abs & (abs <= abu & abs >= abl))) {
							break; // TODO: might not be correct. Was : Exit Do
						}
					}

					string strData;
					strData = "";
					strData = Xtime + "," + abs;
					//---Display Reading
					mobjThreadController.Display(strData);
					gobjCommProtocol.mobjCommdll.subTime_Delay(100);
					Application.DoEvents();
				}

				if (((CEnd - CStart) % (intIntegrationTimeIn) == 0 & CEnd2 != CEnd1)) {
					CEnd2 = CEnd1;
					if (AbsorbanceValueChanged != null) {
						AbsorbanceValueChanged(abs);
					}
				}

				CEnd += 50;

				if ((IsAlt_S_Pressed)) {
					break; // TODO: might not be correct. Was : Exit Do
				}

			} while (true);

			lPipe = 0;

			this.CEndTime = Xtime;

			if (AspirationMessageChanged != null) {
				AspirationMessageChanged("Reading Completed ...", true);
			}
			mobjThreadController.Completed(false);

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

	private double Get_Smooth_Data_inPkHt_Area(double data)
	{
		//=====================================================================
		// Procedure Name        : Get_Smooth_Data_inPkHt_Area
		// Parameters Passed     : data as double
		// Returns               : Double value
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 15-Jan-2007 08:15 pm
		// Revisions             : 1
		//=====================================================================
		//double	Get_Smooth_Data_inPkHt_Area(double data)
		//{
		//	double	sav=0.0;
		//	int		i; //, tpts;

		//	i = lPipe; //read_count;
		//        If (i >= 8) Then
		//	{
		//		for(i=0;i<8; i++)
		//			FiltPipe[i]=FiltPipe[i+1];
		//		FiltPipe[i]=data;
		//		sav = (double)-21.0*(FiltPipe[i-8]+ FiltPipe[i]) +
		//				(double) 14.0*(FiltPipe[i-7]+ FiltPipe[i-1])+
		//				(double) 39.0*(FiltPipe[i-6]+ FiltPipe[i-2])+
		//				(double) 54.0*(FiltPipe[i-5]+ FiltPipe[i-3])+
		//				(double) 59.0*FiltPipe[i-4];
		//		sav = sav/(double)231.0;
		//		sav = GetValConvertedTo( sav, Method->Mode);
		//	}
		//	return sav;
		//}
		//=====================================================================
		double sav = 0.0;
		int i;

		try {
			i = lPipe;


			if ((i >= 8)) {
				for (i = 0; i <= 8 - 1; i++) {
					FiltPipe(i) = FiltPipe(i + 1);
				}

				FiltPipe(i) = data;
				sav = -21.0 * (FiltPipe(i - 8) + FiltPipe(i)) + 14.0 * (FiltPipe(i - 7) + FiltPipe(i - 1)) + 39.0 * (FiltPipe(i - 6) + FiltPipe(i - 2)) + 54.0 * (FiltPipe(i - 5) + FiltPipe(i - 3)) + 59.0 * FiltPipe(i - 4);

				sav = sav / 231.0;

			}

			return sav;

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

	//Public Function TestPeakValue() As Boolean
	//    '=====================================================================
	//    ' Procedure Name        : TestPeakValue
	//    ' Parameters Passed     : None
	//    ' Returns               : True or false
	//    ' Purpose               : 
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Mangesh Shardul
	//    ' Created               : 04-Apr-2007 04:25 pm
	//    ' Revisions             : 1
	//    '=====================================================================

	//    '********************************************************************
	//    '---- ORIGINAL CODE
	//    '********************************************************************
	//    'BOOL TestPeakValue(HWND hwnd, CURVEDATA *AnaGraph)
	//    '{
	//    '	double			slope=1000.0, maxval=-1000.0;
	//    '	double			*values=NULL;
	//    '	RAW_DATA_LINKS *tempk=NULL;
	//    '	int				i,tot;
	//    '	double			xval=0;//, yval=0;;

	//    '	if (!Raw->RawDataCur)
	//    '		return FALSE;
	//    '	tempk =Raw->RawDataCur->Data.TopRawData;
	//    '	tot = GetTotalSamples(tempk);
	//    '	values = (double *) malloc(sizeof(double) * (NO_OF_PK_PTS+2));
	//    '   If (values) Then
	//    '	{
	//    '		InitBuffer(values, NO_OF_PK_PTS+1);
	//    '                If (tot > NO_OF_PK_PTS + 1) Then
	//    '		{
	//    '			tempk = GoToSample(Raw->RawDataCur->Data.TopRawData, tot-(NO_OF_PK_PTS+1));
	//    '			i=0;
	//    '			while(tempk!=NULL && i<(NO_OF_PK_PTS+1))
	//    '			{
	//    '				values[i]= tempk->Data.Abs;
	//    '				if (maxval<values[i])
	//    '					maxval=values[i];
	//    '				if (i==(NO_OF_PK_PTS/2))
	//    '				{
	//    '					xval = tempk->Data.Xval;
	//    '				}
	//    '				i++;
	//    '				tempk=tempk->next;
	//    '			}
	//    '			slope = GetPeakSlopeAt(values);
	//    '		}
	//    '       If (maxval > 0.01) Then
	//    '			maxval/=11.0;
	//    '       Else
	//    '			maxval=1.0;
	//    '		if (slope>100 || slope<-100)
	//    '			slope=-100;
	//    '       ElseIf (maxval! = 0.0) Then
	//    '		{
	//    '			if (slope >(0.01/maxval) && slope<(.1/maxval))
	//    '				ShowStart(hwnd, xval, 0, AnaGraph); //yval,
	//    '			else if (slope>(-.01/maxval) && slope<(0.01/maxval))
	//    '				ShowStart(hwnd, xval,  1, AnaGraph); //values[11],
	//    '			else if (slope<(-.01/maxval) && slope>(-.1/maxval))
	//    '				ShowStart(hwnd, xval, 2, AnaGraph); //yval,
	//    '		}
	//    '		free(values); values=NULL;
	//    '	}
	//    '	if (slope > -0.01 && slope < 0.01)
	//    '		return TRUE;
	//    '   Else
	//    '		return FALSE;
	//    '}
	//    '********************************************************************
	//    Dim slope As Double = 1000.0
	//    Dim maxval As Double = -1000.0
	//    Dim values() As Double
	//    Dim i, tot As Integer
	//    Dim xval As Double
	//    Dim tempk As clsRawData

	//    '#define		NO_OF_PK_PTS		4 //10
	//    Const NO_OF_PK_PTS = 4

	//    Try
	//        Select Case Me.SampleType
	//            Case ClsAAS203.enumSampleType.BLANK
	//                tempk = mobjBlankRawData.Clone()

	//            Case ClsAAS203.enumSampleType.STANDARD
	//                tempk = mobjStandardRawData.Clone()

	//            Case ClsAAS203.enumSampleType.SAMPLE
	//                tempk = mobjSampleRawData.Clone()

	//        End Select

	//        If IsNothing(tempk) Then
	//            Return False
	//        End If

	//        'tempk =Raw->RawDataCur->Data.TopRawData

	//        'tot = GetTotalSamples(tempk)
	//        tot = tempk.Readings.Count - 1

	//        'values = (double *) malloc(sizeof(double) * (NO_OF_PK_PTS+2));
	//        ReDim values(NO_OF_PK_PTS + 2)

	//        If Not IsNothing(values) Then
	//            'InitBuffer(values, NO_OF_PK_PTS+1);
	//            If (tot > NO_OF_PK_PTS + 1) Then
	//                'tempk = GoToSample(Raw->RawDataCur->Data.TopRawData, tot-(NO_OF_PK_PTS+1))
	//                i = 0
	//                While (Not IsNothing(tempk) And i < (NO_OF_PK_PTS + 1))
	//                    'values(i)= tempk->Data.Abs
	//                    'values(i) = tempk.Readings.item(i).Absorbance
	//                    If (maxval < values(i)) Then
	//                        maxval = values(i)
	//                    End If
	//                    If (i = (NO_OF_PK_PTS / 2)) Then
	//                        'xval = tempk->Data.Xval
	//                        xval = tempk.Readings.item(0).XTime
	//                    End If
	//                    i += 1
	//                End While
	//                'slope = GetPeakSlopeAt(values)
	//            End If

	//            'If (maxval > 0.01) Then
	//            '	maxval/=11.0;
	//            'Else
	//            '   maxval=1.0;

	//            'if (slope>100 || slope<-100)
	//            '	    slope=-100;
	//            '   ElseIf (maxval! = 0.0) Then
	//            '   {
	//            '	    if (slope >(0.01/maxval) && slope<(.1/maxval))
	//            '		    ShowStart(hwnd, xval, 0, AnaGraph); 
	//            '		else if (slope>(-.01/maxval) && slope<(0.01/maxval))
	//            '			ShowStart(hwnd, xval,  1, AnaGraph); 
	//            '		else if (slope<(-.01/maxval) && slope>(-.1/maxval))
	//            '			ShowStart(hwnd, xval, 2, AnaGraph); 
	//            '	}
	//            '	free(values); 
	//            '   values=NULL;
	//        End If

	//        If (slope > -0.01 And slope < 0.01) Then
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
	//        '---------------------------------------------------------
	//    End Try
	//End Function

	//Private Function GetTotalSamples(ByVal Top As clsRawDataCollection) As Integer
	//    '=====================================================================
	//    ' Procedure Name        : GetTotalSamples
	//    ' Parameters Passed     : object od clsRawData
	//    ' Returns               : no. of samples
	//    ' Purpose               : 
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Mangesh Shardul
	//    ' Created               : 04-Apr-2007 05:35 pm
	//    ' Revisions             : 1
	//    '=====================================================================
	//    Dim tot As Integer
	//    Dim intCounter As Integer

	//    Try
	//        'While (tempk != NULL)
	//        '    tot += 1
	//        '    'tempk=tempk->next;
	//        'End While
	//        For intCounter = 0 To Top.Count - 1
	//            tot += 1
	//        Next

	//        Return tot

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

	private double GetAvgValOfAnalysis(clsRawData objAnalysisRawData)
	{
		//=====================================================================
		// Procedure Name        : GetAvgValOfAnalysis
		// Parameters Passed     : Row data object for store Avg. count
		// Returns               : Double
		// Purpose               : return double
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 26-Dec-2006
		// Revisions             : 1
		//=====================================================================
		double dblAbsorbance;
		int intTotal;
		Analysis.clsRawDataReadings.RAW_DATA objRawDataReading;
		int intCounter;

		try {
			intTotal = 0;

			if (!IsNothing(objAnalysisRawData)) {
				//---calculate the Avg value from data object
				for (intCounter = 0; intCounter <= objAnalysisRawData.Readings.Count - 1; intCounter++) {
					objRawDataReading = objAnalysisRawData.Readings.item(intCounter);
					dblAbsorbance += objRawDataReading.Absorbance;
					intTotal += 1;
				}

				if ((intTotal > 0)) {
					dblAbsorbance = dblAbsorbance / intTotal;
				}
			}

			return dblAbsorbance;

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
