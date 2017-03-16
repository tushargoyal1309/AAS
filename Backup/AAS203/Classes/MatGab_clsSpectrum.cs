using AAS203.Signature;
using System.IO;
using Microsoft.VisualBasic;
using AAS203Library;

namespace Spectrum
{

	public class clsSpectrum
	{

		#Region " Private Declaration "
		private struct _Data
		{
			bool mGraphPlot;
			int mXaxisData;
			int mYaxisData;
		}
		_Data Data;
		public struct PeakValley
		{
			double Abs;
			double Wv;
				//True for Peak and False for valley
			bool Nature;
		}
			#End Region
		int m_MaxPeakValley = 0;

		#Region " Property "
		public int PeakValleyCount {
			get { return m_MaxPeakValley; }
		}

		#End Region

		#Region " Methos "

		public bool funcAddSpecDataToChannel(Readings objSrcReadings, ref Readings objDestReadings)
		{
			//=====================================================================
			// Procedure Name        :   gfuncAddSpecDataToChannel
			// Description           :   Add the Spectrum data to the readings object
			//                           with the readings collection as MAX_RANGE
			// Purpose               :   To populate the readings collection to max range(9910)
			// Parameters Passed     :   None.
			// Returns               :   True, if successful.
			// Parameters Affected   :   None.
			// Assumptions           :   None.
			// Dependencies          :   None. 
			// Author                :   Sachin Dokhale
			// Created               :   13.12.06
			// Revisions             :
			//=====================================================================
			try {
				long lngCounter;
				double dblWaveLength;
				long lngIndex;

				// Me.Cursor = Cursors.WaitCursor
				//--- Initialize the array of max range
				dblWaveLength = 0.0;


				//--- Get the data from the source and add to the destination collection
				for (lngCounter = 0; lngCounter <= objSrcReadings.Count - 1; lngCounter++) {
					//--- Get the wavelength from the source collection and 
					//--- calculate the index and assign the espective value
					//--- in the collection
					//lngIndex = gFuncGetIndexWv(objSrcReadings.item(lngCounter).XaxisData, True)
					//--- Check for the index value less than the min and greater than
					//--- the max
					if (objDestReadings.Count - 1 < lngCounter) {
						Data objData = new Data();
						//objData.XaxisData = Format(dblWaveLength, "#000.0")
						objData.XaxisData = objSrcReadings.item(lngCounter).XaxisData;
						objData.YaxisData = objSrcReadings.item(lngCounter).YaxisData;
						objData.YaxisADCData = objSrcReadings.item(lngCounter).YaxisADCData;
						objData.GraphPloted = true;
						objDestReadings.Add(objData);
					} else {
						//objDestReadings.item(lngCounter).XaxisData = Format(dblWaveLength, "#000.0")
						//objDestReadings.item(lngCounter).YaxisData = 0.0
						objDestReadings.item(lngCounter).XaxisData = objSrcReadings.item(lngCounter).XaxisData;
						objDestReadings.item(lngCounter).YaxisData = objSrcReadings.item(lngCounter).YaxisData;
						objDestReadings.item(lngCounter).YaxisADCData = objSrcReadings.item(lngCounter).YaxisADCData;
						objDestReadings.item(lngCounter).GraphPloted = true;
					}

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

		public Channel funcCloneUVSChannel(Channel inobjChanel)
		{
			//=====================================================================
			// Procedure Name        :   gfuncCloneChannel
			// Description           :   Add the channel data to the Channels object
			//                           with the readings collection as MAX_RANGE
			// Purpose               :   
			// Parameters Passed     :   inobjChanel as channel.
			// Returns               :   channel.
			// Parameters Affected   :   None.
			// Assumptions           :   None.
			// Dependencies          :   None. 
			// Author                :   Sachin Dokhale
			// Created               :   13.12.06
			// Revisions             :
			//===s==================================================================
			try {
				Spectrum.Channel objCloneChanel = new Spectrum.Channel(false);
				int intSpectrumCol;
				int intReadingsCol;

				//----------------------Clonong  parameter object ----------------------------------
				//objCloneChanel.UVParameter.AnalysisDate = inobjChanel.UVParameter.AnalysisDate
				//objCloneChanel.UVParameter.Cal_Mode = inobjChanel.UVParameter.Cal_Mode
				//objCloneChanel.UVParameter.Comments = inobjChanel.UVParameter.Comments
				//objCloneChanel.UVParameter.D2Curr = inobjChanel.UVParameter.D2Curr
				//objCloneChanel.UVParameter.ScanSpeed = inobjChanel.UVParameter.ScanSpeed
				//objCloneChanel.UVParameter.SlitWidth = inobjChanel.UVParameter.SlitWidth
				//objCloneChanel.UVParameter.SpectrumName = inobjChanel.UVParameter.SpectrumName
				//objCloneChanel.UVParameter.XaxisMax = inobjChanel.UVParameter.XaxisMax
				//objCloneChanel.UVParameter.XaxisMin = inobjChanel.UVParameter.XaxisMin
				//objCloneChanel.UVParameter.YaxisMax = inobjChanel.UVParameter.YaxisMax
				//objCloneChanel.UVParameter.YaxisMin = inobjChanel.UVParameter.YaxisMin
				objCloneChanel.UVParameter = funcCloneUVParameter(inobjChanel.UVParameter);

				//----------------------Clonong  parameter object ends -----------------------------

				//----------------------Cloning  spectrum object ----------------------------------

				for (intSpectrumCol = 0; intSpectrumCol <= inobjChanel.Spectrums.Count - 1; intSpectrumCol++) {
					//----------------------Cloning  spectrumData object ----------------------------------
					SpectrumData objCloneSpectrumData = new SpectrumData();
					objCloneChanel.Spectrums.Add(objCloneSpectrumData);
					objCloneSpectrumData.SpectrumColor = objCloneChanel.Spectrums.item(intSpectrumCol).SpectrumColor;
					objCloneSpectrumData.SpectrumName = objCloneChanel.Spectrums.item(intSpectrumCol).SpectrumName;

					//----------------------Cloning  readings object ----------------------------------

					for (intReadingsCol = 0; intReadingsCol <= inobjChanel.Spectrums.item(intSpectrumCol).Readings.Count - 1; intReadingsCol++) {
						//----------------------Cloning  Data object ----------------------------------

						Data objCloneData = new Data();
						objCloneSpectrumData.Readings.Add(objCloneData);
						objCloneData.XaxisData = inobjChanel.Spectrums.item(intSpectrumCol).Readings.item(intReadingsCol).XaxisData;
						objCloneData.YaxisData = inobjChanel.Spectrums.item(intSpectrumCol).Readings.item(intReadingsCol).YaxisData;
						objCloneData.YaxisADCData = inobjChanel.Spectrums.item(intSpectrumCol).Readings.item(intReadingsCol).YaxisADCData;

						//----------------------Clonong Data object ends -----------------------------

					}
					//----------------------Cloning  readings object ends----------------------------------
					//----------------------------Cloning  spectrumData object ends----------------------------------
				}
				//----------------------Cloning  spectrum object ends----------------------------------

				//----------------------Cloning  Channel object ----------------------------------
				objCloneChanel.ChannelNo = inobjChanel.ChannelNo;
				objCloneChanel.IsEnergySpectrum = false;
				//objCloneChanel.Parameter.ChannelName = inobjChanel.Parameter.ChannelName
				//objCloneChanel.Parameter.AnalysisDate = inobjChanel.Parameter.AnalysisDate
				//objCloneChanel.Parameter.AnalystName = inobjChanel.Parameter.AnalystName
				//----------------------Cloning  Channel object ends -----------------------------

				//--- Clone the digital signature object
				//objCloneChanel.DigitalSignature.ActivityType = inobjChanel.DigitalSignature.ActivityType
				//objCloneChanel.DigitalSignature.FileName = inobjChanel.DigitalSignature.FileName
				//objCloneChanel.DigitalSignature.FilePassword = inobjChanel.DigitalSignature.FilePassword
				//objCloneChanel.DigitalSignature.LoginPassword = inobjChanel.DigitalSignature.LoginPassword
				//objCloneChanel.DigitalSignature.SaveDate = inobjChanel.DigitalSignature.SaveDate
				//objCloneChanel.DigitalSignature.UserID = inobjChanel.DigitalSignature.UserID
				//objCloneChanel.DigitalSignature.UserName = inobjChanel.DigitalSignature.UserName

				return objCloneChanel;

			} catch (Exception ex) {
				//---------------------------------------------------------
				//Error Handling and logging
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = ex.Message;
				gobjErrorHandler.WriteErrorLog(ex);
				return null;
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

		public Channel funcCloneESChannel(Channel inobjChanel)
		{
			//=====================================================================
			// Procedure Name        :   gfuncCloneChannel
			// Description           :   Add the channel data to the Channels object
			//                           with the readings collection as MAX_RANGE
			// Purpose               :   
			// Parameters Passed     :   inobjChanel As Channel
			// Returns               :   Channel
			// Parameters Affected   :   None.
			// Assumptions           :   None.
			// Dependencies          :   None. 
			// Author                :   Sachin Dokhale
			// Created               :   13.12.06
			// Revisions             :
			//=====================================================================
			try {
				Spectrum.Channel objCloneChanel = new Spectrum.Channel(true);
				int intSpectrumCol;
				int intReadingsCol;

				//----------------------Clonong  parameter object ----------------------------------
				//objCloneChanel.EnegryParameter.AnalysisDate = inobjChanel.EnegryParameter.AnalysisDate
				//objCloneChanel.EnegryParameter.BurnerHeight = inobjChanel.EnegryParameter.BurnerHeight
				//objCloneChanel.EnegryParameter.Cal_Mode = inobjChanel.EnegryParameter.Cal_Mode
				//objCloneChanel.EnegryParameter.Comments = inobjChanel.EnegryParameter.Comments
				//objCloneChanel.EnegryParameter.D2Curr = inobjChanel.EnegryParameter.D2Curr
				//objCloneChanel.EnegryParameter.FualRatio = inobjChanel.EnegryParameter.FualRatio
				//objCloneChanel.EnegryParameter.HCLCurr = inobjChanel.EnegryParameter.HCLCurr
				//objCloneChanel.EnegryParameter.LampEle = inobjChanel.EnegryParameter.LampEle
				//objCloneChanel.EnegryParameter.LampTurrNo = inobjChanel.EnegryParameter.LampTurrNo
				//objCloneChanel.EnegryParameter.PMTV = inobjChanel.EnegryParameter.PMTV
				//objCloneChanel.EnegryParameter.ScanSpeed = inobjChanel.EnegryParameter.ScanSpeed
				//objCloneChanel.EnegryParameter.SlitWidth = inobjChanel.EnegryParameter.SlitWidth
				//objCloneChanel.EnegryParameter.SpectrumName = inobjChanel.EnegryParameter.SpectrumName
				//objCloneChanel.EnegryParameter.XaxisMax = inobjChanel.EnegryParameter.XaxisMax
				//objCloneChanel.EnegryParameter.XaxisMin = inobjChanel.EnegryParameter.XaxisMin
				//objCloneChanel.EnegryParameter.YaxisMax = inobjChanel.EnegryParameter.YaxisMax
				//objCloneChanel.EnegryParameter.YaxisMin = inobjChanel.EnegryParameter.YaxisMin

				objCloneChanel.EnegryParameter = funcCloneESParameter(inobjChanel.EnegryParameter);
				//----------------------Clonong  parameter object ends -----------------------------

				//----------------------Cloning  spectrum object ----------------------------------

				for (intSpectrumCol = 0; intSpectrumCol <= inobjChanel.Spectrums.Count - 1; intSpectrumCol++) {
					//----------------------Cloning  spectrumData object ----------------------------------
					SpectrumData objCloneSpectrumData = new SpectrumData();
					objCloneChanel.Spectrums.Add(objCloneSpectrumData);
					objCloneSpectrumData.SpectrumColor = objCloneChanel.Spectrums.item(intSpectrumCol).SpectrumColor;
					objCloneSpectrumData.SpectrumName = objCloneChanel.Spectrums.item(intSpectrumCol).SpectrumName;

					//----------------------Cloning  readings object ----------------------------------

					for (intReadingsCol = 0; intReadingsCol <= inobjChanel.Spectrums.item(intSpectrumCol).Readings.Count - 1; intReadingsCol++) {
						//----------------------Cloning  Data object ----------------------------------

						Data objCloneData = new Data();
						objCloneSpectrumData.Readings.Add(objCloneData);
						objCloneData.XaxisData = inobjChanel.Spectrums.item(intSpectrumCol).Readings.item(intReadingsCol).XaxisData;
						objCloneData.YaxisData = inobjChanel.Spectrums.item(intSpectrumCol).Readings.item(intReadingsCol).YaxisData;
						objCloneData.YaxisADCData = inobjChanel.Spectrums.item(intSpectrumCol).Readings.item(intReadingsCol).YaxisADCData;

						//----------------------Clonong Data object ends -----------------------------

					}
					//----------------------Cloning  readings object ends----------------------------------
					//----------------------------Cloning  spectrumData object ends----------------------------------
				}
				//----------------------Cloning  spectrum object ends----------------------------------

				//----------------------Cloning  Channel object ----------------------------------
				objCloneChanel.ChannelNo = inobjChanel.ChannelNo;
				objCloneChanel.IsEnergySpectrum = true;
				//objCloneChanel.Parameter.ChannelName = inobjChanel.Parameter.ChannelName
				//objCloneChanel.Parameter.AnalysisDate = inobjChanel.Parameter.AnalysisDate
				//objCloneChanel.Parameter.AnalystName = inobjChanel.Parameter.AnalystName
				//----------------------Cloning  Channel object ends -----------------------------

				//--- Clone the digital signature object
				//objCloneChanel.DigitalSignature.ActivityType = inobjChanel.DigitalSignature.ActivityType
				//objCloneChanel.DigitalSignature.FileName = inobjChanel.DigitalSignature.FileName
				//objCloneChanel.DigitalSignature.FilePassword = inobjChanel.DigitalSignature.FilePassword
				//objCloneChanel.DigitalSignature.LoginPassword = inobjChanel.DigitalSignature.LoginPassword
				//objCloneChanel.DigitalSignature.SaveDate = inobjChanel.DigitalSignature.SaveDate
				//objCloneChanel.DigitalSignature.UserID = inobjChanel.DigitalSignature.UserID
				//objCloneChanel.DigitalSignature.UserName = inobjChanel.DigitalSignature.UserName

				return objCloneChanel;

			} catch (Exception ex) {
				//---------------------------------------------------------
				//Error Handling and logging
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = ex.Message;
				gobjErrorHandler.WriteErrorLog(ex);
				return null;
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

		public Spectrum.UVSpectrumParameter funcCloneUVParameter(Spectrum.UVSpectrumParameter inobjparamter)
		{
			try {
				UVSpectrumParameter objCloneParameter = new UVSpectrumParameter();
				//----------------------Cloning  parameter object ----------------------------------
				objCloneParameter.AnalysisDate = inobjparamter.AnalysisDate;
				objCloneParameter.Cal_Mode = inobjparamter.Cal_Mode;
				objCloneParameter.Comments = inobjparamter.Comments;
				objCloneParameter.D2Curr = inobjparamter.D2Curr;
				objCloneParameter.PMTV = inobjparamter.PMTV;
				objCloneParameter.PMTV_Ref = inobjparamter.PMTV_Ref;
				objCloneParameter.ScanSpeed = inobjparamter.ScanSpeed;
				objCloneParameter.SlitWidth = inobjparamter.SlitWidth;
				objCloneParameter.SlitWidth_Ref = inobjparamter.SlitWidth_Ref;
				objCloneParameter.SpectrumName = inobjparamter.SpectrumName;
				objCloneParameter.XaxisMax = inobjparamter.XaxisMax;
				objCloneParameter.XaxisMin = inobjparamter.XaxisMin;
				objCloneParameter.YaxisMax = inobjparamter.YaxisMax;
				objCloneParameter.YaxisMin = inobjparamter.YaxisMin;

				//----------------------Clonong  parameter object ends -----------------------------
				return objCloneParameter;

			} catch (Exception ex) {
				//---------------------------------------------------------
				//Error Handling and logging
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = ex.Message;
				gobjErrorHandler.WriteErrorLog(ex);
			//gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex)
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

		public Spectrum.EnergySpectrumParameter funcCloneESParameter(Spectrum.EnergySpectrumParameter inobjparamter)
		{
			//=====================================================================
			// Procedure Name        :   funcCloneESParameter
			// Description           :    
			// Purpose               :    
			//                           
			// Parameters Passed     :   None.
			// Returns               :   True, if successful.
			// Parameters Affected   :   None.
			// Assumptions           :
			// Dependencies          :
			// Author                :   Sachin Dokhale
			// Created               :   22.12.07
			// Revisions             :
			//=====================================================================
			try {
				EnergySpectrumParameter objCloneParameter = new EnergySpectrumParameter();
				//----------------------Cloning  parameter object ----------------------------------
				objCloneParameter.AnalysisDate = inobjparamter.AnalysisDate;
				objCloneParameter.BurnerHeight = inobjparamter.BurnerHeight;
				objCloneParameter.FualRatio = inobjparamter.FualRatio;
				objCloneParameter.HCLCurr = inobjparamter.HCLCurr;
				objCloneParameter.LampEle = inobjparamter.LampEle;
				objCloneParameter.LampTurrNo = inobjparamter.LampTurrNo;
				objCloneParameter.Cal_Mode = inobjparamter.Cal_Mode;
				objCloneParameter.Comments = inobjparamter.Comments;
				objCloneParameter.D2Curr = inobjparamter.D2Curr;
				objCloneParameter.PMTV = inobjparamter.PMTV;
				objCloneParameter.PMTV_Ref = inobjparamter.PMTV_Ref;
				objCloneParameter.ScanSpeed = inobjparamter.ScanSpeed;
				objCloneParameter.SlitWidth = inobjparamter.SlitWidth;
				objCloneParameter.SlitWidthRef = inobjparamter.SlitWidthRef;
				objCloneParameter.SpectrumName = inobjparamter.SpectrumName;
				objCloneParameter.XaxisMax = inobjparamter.XaxisMax;
				objCloneParameter.XaxisMin = inobjparamter.XaxisMin;
				objCloneParameter.YaxisMax = inobjparamter.YaxisMax;
				objCloneParameter.YaxisMin = inobjparamter.YaxisMin;

				//----------------------Clonong  parameter object ends -----------------------------
				return objCloneParameter;

			} catch (Exception ex) {
				//---------------------------------------------------------
				//Error Handling and logging
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = ex.Message;
				gobjErrorHandler.WriteErrorLog(ex);
			//gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex)
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

		public bool funcPeaks_1(Channel PeakChannel, ref PeakValley[] structPeak)
		{
			//=====================================================================
			// Procedure Name        :   funcPeaks
			// Description           :   
			// Purpose               :   
			// Parameters Passed     :   Channel
			// Returns               :   True, if successful.
			// Parameters Affected   :   structPeak() As PeakValley
			// Assumptions           :   None.
			// Dependencies          :   None. 
			// Author                :   Sachin Dokhale
			// Created               :   13.12.06
			// Revisions             :
			//=====================================================================

			//double       ymx=0;
			//int         i, j;
			//int	    	x1, k;
			//int         step, inr=0;

			try {
				//int         *chanel1=NULL;
				//int         *chanel0=NULL;

				Channel chanel1;
				Channel chanel0;
				////--------]
				int Steps;
				int x1;
				int intPickCount;
				int j;
				int k;
				int i = 0;
				int inr;
				double dblYmaxMin;
				object objParameter;
				////---------

				////----- Refresh to Peak structure
				for (i = 0; i <= 100; i++) {
					structPeak(i).Wv = 0.0;
					structPeak(i).Abs = 0.0;
					structPeak(i).Nature = false;
				}
				////-----


				//chanel0 = &addata.ad[0];
				if (gintSpectrumMode == modGlobalDeclarations.EnumSpectrumMode.UVSpetrum) {
					chanel0 = funcCloneUVSChannel(PeakChannel);
					//'function for clonning.
					chanel1 = funcCloneUVSChannel(PeakChannel);
					Steps = PeakChannel.UVParameter.Cal_Mode();
					objParameter = PeakChannel.UVParameter;
				} else if (gintSpectrumMode == modGlobalDeclarations.EnumSpectrumMode.EnergySpectrum) {
					chanel0 = funcCloneESChannel(PeakChannel);
					chanel1 = funcCloneESChannel(PeakChannel);
					objParameter = PeakChannel.EnegryParameter;
				}
				if (chanel0.Spectrums.Count <= 0) {
					return;
				}
				m_MaxPeakValley = 0;
				//step = addata.mode
				//Steps = gobjInst.Mode
				Steps = objParameter.Cal_Mode;

				funcSmooth1(chanel1, 0);
				//diff_chanel(chanel0 , chanel1, addata.counter);

				//if (SpectGraph.Xmax-SpectGraph.Xmin>5.0)   {
				//	  if (step<=5) inr = 8;
				//		 else if(step<=25) inr=4;
				//		 else inr=1;
				//	 }
				if ((objParameter.XaxisMax - objParameter.XaxisMin > 5.0)) {
					if ((Steps <= 5)) {
						inr = 8;
					//inr = 1
					} else if ((Steps <= 25)) {
						inr = 4;
					} else {
						inr = 1;
					}
				} else {
					inr = 2;
				}
				i = inr;
				x1 = 1;


				//ymx = GetmV(chanel1[0]);
				dblYmaxMin = gFuncGetmv(chanel1.Spectrums.item(0).Readings.item(0).YaxisData);

				//While (i < (adData.counter - inr))
				while ((i < (chanel1.Spectrums.item(0).Readings.Count - inr))) {
					// For k = -(inr) To k <= inr
					for (k = -(inr); k <= inr; k++) {
						if (i + k + 1 > (chanel1.Spectrums.item(0).Readings.Count)) {
							break; // TODO: might not be correct. Was : Exit For
						}
						if ((k < 0)) {
							if ((chanel1.Spectrums.item(0).Readings.item(i + k).YaxisData <= chanel1.Spectrums.item(0).Readings.item(i + k + 1).YaxisData)) {
							//continue()
							} else {
								break; // TODO: might not be correct. Was : Exit For
							}

						} else {
							if ((chanel1.Spectrums.item(0).Readings.item(i + k).YaxisData >= chanel1.Spectrums.item(0).Readings.item(i + k + 1).YaxisData)) {
							//continue()
							} else {
								break; // TODO: might not be correct. Was : Exit For
							}
						}
					}

					//j++
					for (j = -(inr); j <= inr; j++) {
						if (i + j + 1 > (chanel1.Spectrums.item(0).Readings.Count)) {
							break; // TODO: might not be correct. Was : Exit For
						}
						if ((j < 0)) {
							if ((chanel1.Spectrums.item(0).Readings.item(i + j).YaxisData >= chanel1.Spectrums.item(0).Readings.item(i + j + 1).YaxisData)) {
							//continue;
							} else {
								break; // TODO: might not be correct. Was : Exit For
							}

						} else {
							if ((chanel1.Spectrums.item(0).Readings.item(i + j).YaxisData <= chanel1.Spectrums.item(0).Readings.item(i + j + 1).YaxisData)) {
							//continue;
							} else {
								break; // TODO: might not be correct. Was : Exit For
							}
						}
					}

					if ((k > inr)) {
						//if (peak[x1-1].wv!=i-1 && peakvalid(chanel0, &ymx, i, inr, TRUE)){
						if (((structPeak(x1 - 1).Wv != i - 1) & funcPeakValid(chanel0, dblYmaxMin, i, inr))) {
							//i= GetPeak(chanel0, i, TRUE);
							i = funcGetPeak(chanel0, i);
							structPeak(x1).Abs = chanel0.Spectrums.item(0).Readings.item(i).YaxisData;
							structPeak(x1).Wv = i;
							//chanel0.Spectrums.item(0).Readings.item(i).YaxisData
							//structPeak(x1).Wv = chanel0.Spectrums.item(0).Readings.item(i).XaxisData
							structPeak(x1).Nature = true;
							x1 += 1;
							intPickCount += 1;
							if ((x1 > 100)) {
								x1 = 100;
								i += inr;
							}

						} else {
							i += inr;
						}

					} else if ((j > inr)) {
						if (((structPeak(x1 - 1).Wv != i - 1) & funcValleyValid(chanel0, dblYmaxMin, i, inr))) {
							i = funcGetPeak(chanel0, i);
							structPeak(x1).Abs = chanel0.Spectrums.item(0).Readings.item(i).YaxisData;
							structPeak(x1).Wv = i;
							//chanel0.Spectrums.item(0).Readings.item(i).YaxisData
							//structPeak(x1).Wv = chanel0.Spectrums.item(0).Readings.item(i).XaxisData
							structPeak(x1).Nature = false;
							x1 += 1;
							intPickCount += 1;
							if ((x1 > 100)) {
								x1 = 100;
								i += inr;
							}
						} else {
							i += inr;
						}
					} else {
						i += 1;
					}
					//Next
				}

				k = 0;
				m_MaxPeakValley = intPickCount;

				// if (chanel1 != NULL) {
				//	chanel0 = &addata.ad[0];
				////	SpectGraph.Xmin= addata.wv1;  XMAX = addata.wv2;
				//	step = addata.mode;  i=0;
				//	diff_chanel(chanel0 , chanel1, addata.counter);

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

		public bool funcPeaks(Channel PeakChannel, ref PeakValley[] structPeak)
		{
			//=====================================================================
			// Procedure Name        :   funcPeaks
			// Description           :   
			// Purpose               :   
			// Parameters Passed     :   Channel.
			// Returns               :   True, if successful.
			// Parameters Affected   :   structPeak() As PeakValley.
			// Assumptions           :   None.
			// Dependencies          :   None. 
			// Author                :   Sachin Dokhale
			// Created               :   13.12.06
			// Revisions             :
			//=====================================================================




			try {
				Channel chanel1;
				Channel chanel0;
				////--------]
				int Steps;
				int x1;
				int intPickCount;
				int j;
				int k;
				int i = 0;
				int inr;
				double dblYmaxMin;
				object objParameter;
				////---------

				////----- Refresh to Peak structure
				for (i = 0; i <= 100; i++) {
					structPeak(i).Wv = 0.0;
					structPeak(i).Abs = 0.0;
					structPeak(i).Nature = false;
				}
				////-----



				// copy Data with struncure into channel object for internal use in this function
				if (gintSpectrumMode == modGlobalDeclarations.EnumSpectrumMode.UVSpetrum) {
					chanel0 = funcCloneUVSChannel(PeakChannel);
					chanel1 = funcCloneUVSChannel(PeakChannel);
					Steps = PeakChannel.UVParameter.Cal_Mode();
					objParameter = PeakChannel.UVParameter;
				} else if (gintSpectrumMode == modGlobalDeclarations.EnumSpectrumMode.EnergySpectrum) {
					chanel0 = funcCloneESChannel(PeakChannel);
					chanel1 = funcCloneESChannel(PeakChannel);
					objParameter = PeakChannel.EnegryParameter;
				}
				if (chanel0.Spectrums.Count <= 0) {
					return;
				}
				m_MaxPeakValley = 0;

				// Set the Steps from calibration mode
				Steps = objParameter.Cal_Mode;


				//smooth the data into channle object
				funcSmooth1(chanel1, 0);


				//if (SpectGraph.Xmax-SpectGraph.Xmin>5.0)   {
				//	  if (step<=5) inr = 8;
				//		 else if(step<=25) inr=4;
				//		 else inr=1;
				//	 }
				// Detects peaks and valles
				if ((objParameter.XaxisMax - objParameter.XaxisMin > 5.0)) {
					if ((Steps <= 5)) {
						inr = 8;
					//inr = 1
					} else if ((Steps <= 25)) {
						inr = 4;
					} else {
						inr = 1;
					}
				} else {
					inr = 2;
				}
				i = inr;
				x1 = 1;


				//ymx = GetmV(chanel1[0]);
				dblYmaxMin = gFuncGetmv(chanel1.Spectrums.item(0).Readings.item(0).YaxisADCData);
				//dblYmaxMin = chanel1.Spectrums.item(0).Readings.item(0).YaxisData


				//While (i < (adData.counter - inr))
				//For i = gFuncGetIndexWv(chanel1.UVParameter.XaxisMin, False) To gFuncGetIndexWv(chanel1.UVParameter.XaxisMax, False) - inr
				//For i = inr To chanel1.Spectrums.item(0).Readings.Count - inr - 1
				while ((i < (chanel1.Spectrums.item(0).Readings.Count - inr))) {
					// For k = -(inr) To k <= inr
					for (k = -(inr); k <= inr; k++) {
						if (i + k + 1 > (chanel1.Spectrums.item(0).Readings.Count)) {
							break; // TODO: might not be correct. Was : Exit For
						}
						if ((k < 0)) {
							//If (k > 0) Then
							if ((chanel1.Spectrums.item(0).Readings.item(i + k).YaxisADCData <= chanel1.Spectrums.item(0).Readings.item(i + k + 1).YaxisADCData)) {
							//continue()
							} else {
								break; // TODO: might not be correct. Was : Exit For
							}

						} else {
							if ((chanel1.Spectrums.item(0).Readings.item(i + k).YaxisADCData >= chanel1.Spectrums.item(0).Readings.item(i + k + 1).YaxisADCData)) {
							//If (chanel1.Spectrums.item(0).Readings.item(i + k).YaxisADCData > chanel1.Spectrums.item(0).Readings.item(i + k + 1).YaxisADCData) Then
							//continue()
							} else {
								break; // TODO: might not be correct. Was : Exit For
							}
						}
					}

					//j++
					for (j = -(inr); j <= inr; j++) {
						if (i + j + 1 > (chanel1.Spectrums.item(0).Readings.Count)) {
							break; // TODO: might not be correct. Was : Exit For
						}
						if ((j < 0)) {
							//If (j > 0) Then
							if ((chanel1.Spectrums.item(0).Readings.item(i + j).YaxisADCData >= chanel1.Spectrums.item(0).Readings.item(i + j + 1).YaxisADCData)) {
							//continue;
							} else {
								break; // TODO: might not be correct. Was : Exit For
							}

						} else {
							if ((chanel1.Spectrums.item(0).Readings.item(i + j).YaxisADCData <= chanel1.Spectrums.item(0).Readings.item(i + j + 1).YaxisADCData)) {
							//continue;
							} else {
								break; // TODO: might not be correct. Was : Exit For
							}
						}
					}

					if ((k > inr)) {
						//if (peak[x1-1].wv!=i-1 && peakvalid(chanel0, &ymx, i, inr, TRUE)){
						if (((structPeak(x1 - 1).Wv != i - 1) & funcPeakValid(chanel0, dblYmaxMin, i, inr))) {
							//i= GetPeak(chanel0, i, TRUE);
							i = funcGetPeak(chanel0, i);
							structPeak(x1).Abs = chanel0.Spectrums.item(0).Readings.item(i).YaxisADCData;
							structPeak(x1).Wv = i;
							//chanel0.Spectrums.item(0).Readings.item(i).YaxisData
							//structPeak(x1).Wv = chanel0.Spectrums.item(0).Readings.item(i).XaxisData
							structPeak(x1).Nature = true;
							x1 += 1;
							intPickCount += 1;
							if ((x1 > 100)) {
								x1 = 100;
								i += inr;
							}

						} else {
							i += inr;
						}

					} else if ((j > inr)) {
						if (((structPeak(x1 - 1).Wv != i - 1) & funcValleyValid(chanel0, dblYmaxMin, i, inr))) {
							//i = funcGetPeak(chanel0, i)
							i = funcGetPeak(chanel0, i);
							structPeak(x1).Abs = chanel0.Spectrums.item(0).Readings.item(i).YaxisADCData;
							structPeak(x1).Wv = i;
							//chanel0.Spectrums.item(0).Readings.item(i).YaxisData
							//structPeak(x1).Wv = chanel0.Spectrums.item(0).Readings.item(i).XaxisData
							structPeak(x1).Nature = false;
							x1 += 1;
							intPickCount += 1;
							if ((x1 > 100)) {
								x1 = 100;
								i += inr;
							}
						} else {
							i += inr;
						}
					} else {
						i += 1;
					}
					//Next
				}

				k = 0;
				m_MaxPeakValley = intPickCount;

				// return by Ref to structure of Peak and valley 
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

		public bool funcSmooth1(ref Channel DestChannel, int intCount)
		{
			//=====================================================================
			// Procedure Name        :   funcSmooth1
			// Description           :   
			// Purpose               :   
			// Parameters Passed     :   intCount as integer
			// Returns               :   True, if successful.
			// Parameters Affected   :   Destination channel
			// Assumptions           :   None.
			// Dependencies          :   None. 
			// Author                :   Sachin Dokhale
			// Created               :   13.12.06
			// Revisions             :
			//=====================================================================
			double adsum = 0;
			int i;
			int j;
			int spts;
			int intStartWvIdx;
			int intLastWvIdx;

			try {
				////-------------
				//        void  smooth1(int  arr[], int n)
				//{
				// double  adsum = 0;
				// int 	i,j,spts;

				// spts = 2;
				// for (i=spts; i< n-1; i++)  {
				//	adsum = 0;
				//	for(j=1; j<=spts; j++)
				//	  if (j==1) adsum += (arr[i-j]*0.7+arr[i+j]*0.7);
				//	  else  adsum += (arr[i-j]*0.3+arr[i+j]*0.3);
				//	arr[i] = (adsum+arr[i])/(spts+1.0);
				//  }
				//}
				////-------------
				spts = 2;
				//If DestChannel.IsEnergySpectrum = False Then
				//    intStartWvIdx = gFuncGetIndexWv(DestChannel.UVParameter.XaxisMin, False)
				//    intLastWvIdx = gFuncGetIndexWv(DestChannel.UVParameter.XaxisMax, False)
				//Else
				//    intStartWvIdx = gFuncGetIndexWv(DestChannel.EnegryParameter.XaxisMin, False)
				//    intLastWvIdx = gFuncGetIndexWv(DestChannel.EnegryParameter.XaxisMax, False)
				//End If

				for (i = spts; i <= DestChannel.Spectrums.item(0).Readings.Count - 3; i++) {
					adsum = 0;
					for (j = 1; j <= spts; j++) {
						if ((j == 1)) {
							//	  if (j==1) adsum += (arr[i-j]*0.7+arr[i+j]*0.7);
							adsum += (DestChannel.Spectrums.item(0).Readings.item(i - j).YaxisData * 0.7 + DestChannel.Spectrums.item(0).Readings.item(i + j).YaxisData * 0.7);
						} else {
							//	  else  adsum += (arr[i-j]*0.3+arr[i+j]*0.3);
							adsum += (DestChannel.Spectrums.item(0).Readings.item(i - j).YaxisData * 0.3 + DestChannel.Spectrums.item(0).Readings.item(i + j).YaxisData * 0.3);
						}
					}
					//arr[i] = (adsum+arr[i])/(spts+1.0);
					DestChannel.Spectrums.item(0).Readings.item(i).YaxisData = (adsum + DestChannel.Spectrums.item(0).Readings.item(i).YaxisData) / (spts + 1.0);
				}
				////----- Added by Sachin Dokhale
				adsum = 0;
				for (i = spts; i <= DestChannel.Spectrums.item(0).Readings.Count - 3; i++) {
					adsum = 0;
					for (j = 1; j <= spts; j++) {
						if ((j == 1)) {
							//	  if (j==1) adsum += (arr[i-j]*0.7+arr[i+j]*0.7);
							adsum += (DestChannel.Spectrums.item(0).Readings.item(i - j).YaxisADCData * 0.7 + DestChannel.Spectrums.item(0).Readings.item(i + j).YaxisADCData * 0.7);
						} else {
							//	  else  adsum += (arr[i-j]*0.3+arr[i+j]*0.3);
							adsum += (DestChannel.Spectrums.item(0).Readings.item(i - j).YaxisADCData * 0.3 + DestChannel.Spectrums.item(0).Readings.item(i + j).YaxisADCData * 0.3);
						}
					}
					//arr[i] = (adsum+arr[i])/(spts+1.0);
					DestChannel.Spectrums.item(0).Readings.item(i).YaxisADCData = (adsum + DestChannel.Spectrums.item(0).Readings.item(i).YaxisADCData) / (spts + 1.0);
				}
				if (DestChannel.IsEnergySpectrum == true) {
					if (!(DestChannel.EnegryParameter == null)) {
						for (i = 0; i <= DestChannel.Spectrums.item(0).Readings.Count - 1; i++) {
							DestChannel.Spectrums.item(0).Readings.item(i).YaxisData = gfuncGetValueInSpectrum(DestChannel.Spectrums.item(0).Readings.item(i).YaxisADCData, DestChannel.EnegryParameter.Cal_Mode);
						}
					}
				}
				////-----
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

		public bool funcGetDataPeakPickResults(ref DataTable objDataTable, ref PeakValley[] structPeak, long lngPeakValleyCount, Channel objChannel)
		{
			//=====================================================================
			// Procedure Name        :   funcGetDataPeakPickResults
			// Description           :   this is used to get peak result in to a data table.
			// Purpose               :   
			// Parameters Passed     :   channel,lngPeakValleyCount
			// Returns               :   True, if successful.
			// Parameters Affected   :   objDataTable As DataTable, structPeak() As PeakValley is structure
			// Assumptions           :   None.
			// Dependencies          :   None. 
			// Author                :   Sachin Dokhale
			// Created               :   13.12.06
			// Revisions             :
			//=====================================================================

			long lngRowCounter;
			long lngCounter;
			long lngPeakCounter;
			long lngValleyCounter;
			double dblToY_Peak;
			double dblToY_Valley;
			DataRow objDataRow;
			object objSpectrumParameter;
			string strNumberFormat;
			try {
				if (objChannel.IsEnergySpectrum == true) {
					objSpectrumParameter = objChannel.EnegryParameter;
				} else {
					objSpectrumParameter = objChannel.UVParameter;
				}
				objDataTable.Columns.Clear();
				objDataTable.Rows.Clear();

				//--- Add columns to the data table
				objDataTable.Columns.Add("Peak (SrNo.)");
				objDataTable.Columns.Add("Peak (Wv)");

				//--- Check for the scan mode
				switch (objSpectrumParameter.Cal_Mode) {
					case EnumCalibrationMode.AA:
					case EnumCalibrationMode.D2E:
					case EnumCalibrationMode.AABGC:
						//objDataTable.Columns.Add("Peak (Abs)")
						if (gblnUVABS == true) {
							objDataTable.Columns.Add("Peak (Abs)");
							strNumberFormat = "#0.000";
						} else {
							objDataTable.Columns.Add("Peak (%T)");
							strNumberFormat = "#0.0";
						}
					case EnumCalibrationMode.EMISSION:
						objDataTable.Columns.Add("Peak (%T)");
						strNumberFormat = "#0.0";
					case EnumCalibrationMode.HCLE:
					case EnumCalibrationMode.D2E:
					case EnumCalibrationMode.AABGC:
						objDataTable.Columns.Add("Peak (Energy)");
						strNumberFormat = "#0.0";
				}

				objDataTable.Columns.Add("Valley (SrNo.)");
				objDataTable.Columns.Add("Valley (Wv)");
				//--- Check for the scan mode
				switch (objSpectrumParameter.Cal_Mode) {
					case EnumCalibrationMode.AA:
					case EnumCalibrationMode.D2E:
					case EnumCalibrationMode.AABGC:
						if (gblnUVABS == true) {
							objDataTable.Columns.Add("Valley (Abs)");
							strNumberFormat = "#0.000";
						} else {
							objDataTable.Columns.Add("Valley (%T)");
							strNumberFormat = "#0.0";
						}
					case EnumCalibrationMode.EMISSION:
						objDataTable.Columns.Add("Valley (%T)");
						strNumberFormat = "#0.0";
					case EnumCalibrationMode.HCLE:
					case EnumCalibrationMode.D2E:
					case EnumCalibrationMode.AABGC:
						objDataTable.Columns.Add("Valley (Energy)");
						strNumberFormat = "#0.0";
				}

				//'--- Get the peak and valley data from the structure
				//'--- passed by arguments
				//--- Get the peak and valley data from the structure
				//--- passed by arguments
				lngRowCounter = 0;
				lngPeakCounter = 0;
				lngValleyCounter = 0;

				for (lngCounter = 1; lngCounter <= lngPeakValleyCount; lngCounter++) {
					dblToY_Peak = 0.0;
					dblToY_Valley = 0.0;
					if (structPeak(lngCounter).Wv > 0 & structPeak(lngCounter).Wv < objChannel.Spectrums(0).Readings.item((objChannel.Spectrums(0).Readings.Count - 1)).XaxisData) {
						//--- Check for Peak 
						if (structPeak(lngCounter).Nature == true) {
							//--- Logic for Peak
							//--- If We get Peak add to Peak counter
							lngPeakCounter += 1;
							if (lngPeakCounter > lngRowCounter) {
								lngRowCounter += 1;
								//--- Add the row to the data table
								objDataRow = objDataTable.NewRow;
								objDataTable.Rows.Add(objDataRow);
							}
							objDataTable.Rows.Item(lngPeakCounter - 1).Item(0) = lngPeakCounter;
							objDataTable.Rows.Item(lngPeakCounter - 1).Item(1) = Format(objChannel.Spectrums(0).Readings(structPeak(lngCounter).Wv).XaxisData, "#000.0");

							//--- Check for the scan mode
							switch (objSpectrumParameter.Cal_Mode) {
								case EnumCalibrationMode.AA:
								case EnumCalibrationMode.D2E:
								case EnumCalibrationMode.AABGC:
									dblToY_Peak = gfuncGetValueInSpectrum(structPeak(lngCounter).Abs, objSpectrumParameter.Cal_Mode);
									objDataTable.Rows.Item(lngPeakCounter - 1).Item(2) = Format(dblToY_Peak, strNumberFormat);
								case EnumCalibrationMode.EMISSION:
								case EnumCalibrationMode.HCLE:
								case EnumCalibrationMode.AABGC:
									//dblToY_Peak = gfuncGetValueInSpectrum(structPeak(lngCounter).Abs, gobjInst.Mode)
									//dblToY_Peak = structPeak(lngCounter).Abs
									dblToY_Peak = gfuncGetValueInSpectrum(structPeak(lngCounter).Abs, objSpectrumParameter.Cal_Mode);
									objDataTable.Rows.Item(lngPeakCounter - 1).Item(2) = Format(dblToY_Peak, strNumberFormat);
							}

						} else {
							//--- Logic for Valley
							lngValleyCounter += 1;
							if (lngValleyCounter > lngRowCounter) {
								lngRowCounter += 1;
								objDataRow = objDataTable.NewRow;
								objDataTable.Rows.Add(objDataRow);
							}
							objDataTable.Rows.Item(lngValleyCounter - 1).Item(3) = lngValleyCounter;
							objDataTable.Rows.Item(lngValleyCounter - 1).Item(4) = Format(objChannel.Spectrums(0).Readings(structPeak(lngCounter).Wv).XaxisData, "#000.0");

							//--- Check for the scan mode
							switch (objSpectrumParameter.Cal_Mode) {
								case EnumCalibrationMode.AA:
								case EnumCalibrationMode.D2E:
								case EnumCalibrationMode.AABGC:
									//objDataTable.Rows.Item(lngValleyCounter - 1).Item(5) = Format(structPeak(lngCounter).Abs, "#0.000")
									dblToY_Valley = gfuncGetValueInSpectrum(structPeak(lngCounter).Abs, objSpectrumParameter.Cal_Mode);
									objDataTable.Rows.Item(lngValleyCounter - 1).Item(5) = Format(dblToY_Valley, strNumberFormat);
								case EnumCalibrationMode.EMISSION:
								case EnumCalibrationMode.HCLE:
								case EnumCalibrationMode.AABGC:
									//objDataTable.Rows.Item(lngValleyCounter - 1).Item(5) = Format(structPeak(lngCounter).Abs, "#0.0")
									//dblToY_Valley = gfuncGetValueInSpectrum(structPeak(lngCounter).Abs, gobjInst.Mode)
									dblToY_Valley = dblToY_Valley == gfuncGetValueInSpectrum(structPeak(lngCounter).Abs, objSpectrumParameter.Cal_Mode);
									//structPeak(lngCounter).Abs
									objDataTable.Rows.Item(lngValleyCounter - 1).Item(5) = Format(dblToY_Valley, strNumberFormat);
							}
						}
					}
				}

				//--- logic for taking out the NULL
				int lngColCounter = 0;
				lngRowCounter = 0;

				for (lngRowCounter = 0; lngRowCounter <= objDataTable.Rows.Count - 1; lngRowCounter++) {
					for (lngColCounter = 0; lngColCounter <= objDataTable.Columns.Count - 1; lngColCounter++) {
						if (IsDBNull(objDataTable.Rows.Item(lngRowCounter).Item(lngColCounter)) == true) {
							objDataTable.Rows.Item(lngRowCounter).Item(lngColCounter) = "";
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
				//---------------------------------------------------------
				return false;
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

		#Region " Private Function "

		private bool funcPeakValid(Channel chanel, ref double dblYMax, int i, int inr)
		{
			//=====================================================================
			// Procedure Name        :   funcPeakValid
			// Description           :   here chanel is a data structure
			// Purpose               :   check the peak for valid range to validate
			// Parameters Passed     :   Channel,i,inr.
			// Parameters Affected   :   dblYMax As Double
			// Returns               :   True, if successful.
			// Parameters Affected   :   None.
			// Assumptions           :   None.
			// Dependencies          :   None. 
			// Author                :   Sachin Dokhale
			// Created               :   13.12.06
			// Revisions             :
			//=====================================================================

			double dblY;
			bool flag1 = false;
			try {
				//--- Check the peak for valid range to validate
				if ((i - inr >= 0)) {
					dblY = gFuncGetmv(chanel.Spectrums(0).Readings.item(i).YaxisADCData);
					//if ( (ymax-(*ymaxmin)) >=100.0) {
					//		 flag1=TRUE;
					//		 *ymaxmin = ymax;
					//		}
					//If ((dblY - (dblYMax)) >= 100.0) Then
					if ((Math.Abs((dblY - (dblYMax))) >= 50.0)) {
						//If ((dblY - (dblYMax)) >= 100.0) Then
						flag1 = true;
						dblYMax = dblY;
					}
				}
				return flag1;
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

		private bool funcValleyValid(Channel chanel, ref double dblYMin, int i, int inr)
		{
			//=====================================================================
			// Procedure Name        :   funcValleyValid
			// Description           :   
			// Purpose               :   Validate the Valley value
			// Parameters Passed     :   Channel,i,inr.
			// Parameters Affected   :   dblYMax As Double
			// Returns               :   True, if successful.
			// Assumptions           :   None.
			// Dependencies          :   Channel data structure must be loaded. 
			// Author                :   Sachin Dokhale
			// Created               :   13.12.06
			// Revisions             :
			//=====================================================================

			double dblY;
			bool flag1 = false;
			try {
				//--- Check the valley for valid range to validate
				if ((i - inr >= 0)) {
					dblY = gFuncGetmv(chanel.Spectrums(0).Readings.item(i).YaxisADCData);

					//else if ((*ymaxmin-ymax)>=50.0) {
					//flag1=TRUE;
					//*ymaxmin = ymax;
					if ((Math.Abs(dblYMin - dblY) >= 50.0)) {
						//If ((dblYMin - dblY) >= 50.0) Then
						flag1 = true;
						dblYMin = dblY;
					}
				}

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
				//---------------------------------------------------------
			}
		}

		private int funcGetPeak(Channel Peakchannel, int i)
		{
			//peakvalid(chanel0, &ymx, i, inr, TRUE))
			//=====================================================================
			// Procedure Name        :   funcGetPeak
			// Description           :   for getting peak from channel object.
			// Purpose               :   
			// Parameters Passed     :   Channel,i.
			// Returns               :   Integer
			// Parameters Affected   :   None.
			// Assumptions           :   Channel must be not empty.
			// Dependencies          :   None. 
			// Author                :   Sachin Dokhale
			// Created               :   13.12.06
			// Revisions             :
			//=====================================================================
			try {
				int k;
				int j;
				//Dim maxmin As Integer = 5000
				int maxmin = -1;
				j = i;
				if ((i > 5 & i < Peakchannel.Spectrums.item(0).Readings.Count - 5)) {
					for (k = i - 5; k <= k < i + 5; k++) {
						//if (peak){ for Peak
						if ((Peakchannel.Spectrums.item(0).Readings(k).YaxisADCData > maxmin)) {
							//maxmin=chanel0[k];
							//j=k;
							maxmin = Peakchannel.Spectrums.item(0).Readings(k).YaxisADCData();
							j = k;
						}
					}
				}
				i = j;
				//if (i>5 && i<addata.counter-10){
				//j=0;
				//for(k=i; k<i+10; k++){
				//if (chanel0[k]==chanel0[k+1])
				//j++;
				//Else
				//break;
				//}
				//j=i+j/2;
				//}
				//Return j
				if ((i > 5 & i < Peakchannel.Spectrums.item(0).Readings.Count - 10)) {
					j = 0;
					for (k = i; k <= k <= 10; k++) {
						if (Peakchannel.Spectrums.item(0).Readings.item(k).YaxisADCData == Peakchannel.Spectrums.item(0).Readings.item(k + 1).YaxisADCData) {
							j += 1;
						} else {
							break; // TODO: might not be correct. Was : Exit For
						}
					}
					j = i + j / 2;
				}
				return j;

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
				//---------------------------------------------------------
			}
		}

		private int funcGetValley(Channel Valleychanel, ref double dblYMin, int i, int inr)
		{
			//=====================================================================
			// Procedure Name        :   funcGetValley
			// Description           :   for getting vally count from channel object.
			// Purpose               :   
			// Parameters Passed     :   Valleychanel As Channel, i,inr as integer
			// Returns               :   Integer
			// Parameters Affected   :   dblYMin.
			// Assumptions           :   None.
			// Dependencies          :   None. 
			// Author                :   Sachin Dokhale
			// Created               :   13.12.06
			// Revisions             :
			//=====================================================================
			try {
				int k;
				int j;
				int maxmin = 5000;
				//Dim maxmin As Integer = -1
				j = i;
				if ((i > 5 & i < Valleychanel.Spectrums.item(0).Readings.Count - 5)) {
					for (k = i - 5; k <= k < i + 5; k++) {
						//if (peak){ for Peak
						if ((Valleychanel.Spectrums.item(0).Readings(k).YaxisADCData < maxmin)) {
							//maxmin=chanel0[k];
							//j=k;
							maxmin = Valleychanel.Spectrums.item(0).Readings(k).YaxisADCData();
							j = k;
						}
					}
				}
				i = j;
				//if (i>5 && i<addata.counter-10){
				//j=0;
				//for(k=i; k<i+10; k++){
				//if (chanel0[k]==chanel0[k+1])
				//j++;
				//Else
				//break;
				//}
				//j=i+j/2;
				//}
				//Return j
				if ((i > 5 & i < Valleychanel.Spectrums.item(0).Readings.Count - 10)) {
					j = 0;
					for (k = i; k <= k <= 10; k++) {
						if (Valleychanel.Spectrums.item(0).Readings.item(k).YaxisADCData == Valleychanel.Spectrums.item(0).Readings.item(k + 1).YaxisADCData) {
							j += 1;
						} else {
							break; // TODO: might not be correct. Was : Exit For
						}
					}
					j = i + j / 2;
				}
				return j;

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
	//--- Channel is the object to hold the entire property of sepctrum.
	[Serializable()]
	public class Channel
	{
		UVSpectrumParameter mobjUVSpectrumParameter;
		EnergySpectrumParameter mobjEnergySpectrumParameter;
		Spectrums mobjSpectrums = new Spectrums();
		int mintChannelNo;
		bool bln_IsEnergySpectrum = true;
		DigitalSignature mobjDigitalSignature = new DigitalSignature();

		private Instrument.enumInstrumentBeamType mintInstrumentBeamType;
		//--- Digital Signature object
		private DigitalSignature DigitalSignature {
			get { return mobjDigitalSignature; }
			set { mobjDigitalSignature = Value; }
		}

		//--- Parameter object
		private EnergySpectrumParameter EnegryParameter {
			get { return mobjEnergySpectrumParameter; }
			set { mobjEnergySpectrumParameter = Value; }
		}

		private UVSpectrumParameter UVParameter {
			get { return mobjUVSpectrumParameter; }
			set { mobjUVSpectrumParameter = Value; }
		}

		//--- Spectrums collection (col of SpectrumData object)
		private Spectrums Spectrums {
			get { return mobjSpectrums; }
			set { mobjSpectrums = Value; }
		}

		//--- Channel No
		private int ChannelNo {
			get { return mintChannelNo; }
			set { mintChannelNo = Value; }
		}

		// Check Spectrum for energy
		private bool IsEnergySpectrum {
			get { return bln_IsEnergySpectrum; }
			set { bln_IsEnergySpectrum = Value; }
		}

		public Channel(bool blnEnergySpectrum)
		{
			if (blnEnergySpectrum == true) {
				mobjEnergySpectrumParameter = new EnergySpectrumParameter();
				bln_IsEnergySpectrum = true;
			} else {
				mobjUVSpectrumParameter = new UVSpectrumParameter();
				bln_IsEnergySpectrum = false;
			}
			mintInstrumentBeamType = Instrument.enumInstrumentBeamType.SingleBeam;
		}

		private Instrument.enumInstrumentBeamType InstrumentBeamType {

			get { return mintInstrumentBeamType; }
			set { mintInstrumentBeamType = Value; }
		}

	}

	//--- This Energy channel object is holds detalis of energy spectrum
	[Serializable()]
	public class EnergyChannels : System.Collections.CollectionBase
	{

		private DigitalSignature mobjDigitalSignature = new DigitalSignature();
		//--- Item property sets or return a Channel object
		private Channel this[int index] {
			get { return innerlist.Item(index); }
			set { innerlist.Item(index) = Value; }
		}

		//--- you can add only Channel object to this collection
		private void Add(Channel value)
		{
			innerlist.Add(value);
		}

		//--- Digital Signature object
		private DigitalSignature DigitalSignature {
			get { return mobjDigitalSignature; }
			set { mobjDigitalSignature = Value; }
		}

	}

	//--- This channels object is the collection of the channels
	[Serializable()]
	public class Channels : System.Collections.CollectionBase
	{


		//--- Item property sets or return a Channel object
		private Channel this[int index] {
			get { return innerlist.Item(index); }
			set { innerlist.Item(index) = Value; }
		}

		//--- you can add only Channel object to this collection
		private void Add(Channel value)
		{
			innerlist.Add(value);
		}

	}

	//--- This Readings object is the collection of Data objects
	[Serializable()]
	public class Readings : System.Collections.CollectionBase
	{

		//--- Item property sets or return a data object
		private Data this[int index] {
			get { return innerlist.Item(index); }
			set { innerlist.Item(index) = Value; }
		}

		//--- you can add only data object to this collection
		private void Add(Data value)
		{
			innerlist.Add(value);
		}
	}

	//--- This SpectrumData object is holds the detalis of the Readings object
	[Serializable()]
	public class SpectrumData
	{

		long mlngSpectrumColor;
		string mstrSpectrumName;

		Readings mobjReadings = new Readings();
		private long SpectrumColor {
			get { return mlngSpectrumColor; }
			set { mlngSpectrumColor = Value; }
		}

		private string SpectrumName {
			get { return mstrSpectrumName; }
			set { mstrSpectrumName = Value; }
		}

		//--- Readings collection stores the data for the spectrum.
		private Readings Readings {
			get { return mobjReadings; }
			set { mobjReadings = Value; }
		}
	}

	//--- This Spectrum object is collection of SpectrumData object 
	[Serializable()]
	public class Spectrums : System.Collections.CollectionBase
	{
		//--- Item property sets or return a SpectrumData object
		private SpectrumData this[int index] {
			get { return innerlist.Item(index); }
			set { innerlist.Item(index) = Value; }
		}

		//--- you can add only SpectrumData object to this collection
		private void Add(SpectrumData value)
		{
			innerlist.Add(value);
		}

	}

	//--- This EnergySpectrumParameter object is holds the details of energy spectrum parameter. 
	//--- i.s. Inst. setting details of that energy spectrum
	[Serializable()]
	public class EnergySpectrumParameter
	{
		//Dim mintSacnMode As Integer
		double mintScanSpeed;
		double mdblPmtV;
		double mdblPmtV_Ref;
		double mdblHCLCurr;
		int mintD2Curr;
		double mdblSlitWidth;
		double mdblSlitWidth_Ref;
		double mintFualRatio;
		double mdblBurnerHeight;
		int mintLampTurrNo;
		string mstrLampEle;
		EnumCalibrationMode mintCal_Mode;
		double mdblXaxisMin = 0;
		double mdblXaxisMax = 0;
		double mdblYaxisMin = 0;
		double mdblYaxisMax = 0;
		DigitalSignature mobjDigitalSignature = new DigitalSignature();
		string mstrChannelName = "";
		string mstrAnalysisDate = "";

		string mstrComments = "";

		//--- Channel name    
		private string SpectrumName {
			get { return mstrChannelName; }
			set { mstrChannelName = Value; }
		}

		//--- Analysis date        
		private string AnalysisDate {
			get { return mstrAnalysisDate; }
			set { mstrAnalysisDate = Value; }
		}

		//--- Digital Signature object
		private DigitalSignature DigitalSignature {
			get { return mobjDigitalSignature; }
			set { mobjDigitalSignature = Value; }
		}


		private int Cal_Mode {
			get { return mintCal_Mode; }
			set { mintCal_Mode = Value; }
		}

		private double ScanSpeed {
			get { return mintScanSpeed; }
			set { mintScanSpeed = Value; }
		}


		private double XaxisMin {
			get { return mdblXaxisMin; }
			set { mdblXaxisMin = Value; }
		}

		private double XaxisMax {
			get { return mdblXaxisMax; }
			set { mdblXaxisMax = Value; }
		}

		private double YaxisMin {
			get { return mdblYaxisMin; }
			set { mdblYaxisMin = Value; }
		}

		private double YaxisMax {
			get { return mdblYaxisMax; }
			set { mdblYaxisMax = Value; }
		}

		private double PMTV {
			get { return mdblPmtV; }
			set { mdblPmtV = Value; }
		}

		private double PMTV_Ref {
			get { return mdblPmtV_Ref; }
			set { mdblPmtV_Ref = Value; }
		}

		private double HCLCurr {
			get { return mdblHCLCurr; }
			set { mdblHCLCurr = Value; }
		}

		private int D2Curr {
			get { return mintD2Curr; }
			set { mintD2Curr = Value; }
		}

		private double SlitWidth {
			get { return mdblSlitWidth; }
			set { mdblSlitWidth = Value; }
		}

		private double SlitWidthRef {
			get { return mdblSlitWidth_Ref; }
			set { mdblSlitWidth_Ref = Value; }
		}

		private int FualRatio {
			get { return mintFualRatio; }
			set { mintFualRatio = Value; }
		}

		private double BurnerHeight {
			get { return mdblBurnerHeight; }
			set { mdblBurnerHeight = Value; }
		}

		private int LampTurrNo {
			get { return mintLampTurrNo; }
			set { mintLampTurrNo = Value; }
		}

		private string LampEle {
			get { return mstrLampEle; }
			set { mstrLampEle = Value; }
		}

		private string Comments {
			get { return mstrComments; }
			set { mstrComments = Value; }
		}

	}

	//--- This UVSpectrumParameter object is holds the details of UV spectrum parameter. 
	//--- i.s. Inst. setting details of that UV spectrum
	[Serializable()]
	public class UVSpectrumParameter
	{
		double mintScanSpeed;
		double mdblPmtV;
		double mdblPmtV_Ref;
		int mintD2Curr;
		double mdblSlitWidth;
		double mdblSlitWidth_Ref;
		EnumCalibrationMode mintCal_Mode;
		double mdblXaxisMin = 0;
		double mdblXaxisMax = 0;
		double mdblYaxisMin = 0;
		double mdblYaxisMax = 0;
		DigitalSignature mobjDigitalSignature = new DigitalSignature();
		string mstrChannelName = "";
		string mstrAnalysisDate = "";
		string mstrComments = "";
		bool mblnUVABS = true;

		bool mblnIsBaseline = false;


		//--- Channel name    
		private string SpectrumName {
			get { return mstrChannelName; }
			set { mstrChannelName = Value; }
		}

		//--- Analysis date        
		private string AnalysisDate {
			get { return mstrAnalysisDate; }
			set { mstrAnalysisDate = Value; }
		}

		//--- Digital Signature object
		private DigitalSignature DigitalSignature {
			get { return mobjDigitalSignature; }
			set { mobjDigitalSignature = Value; }
		}

		private int Cal_Mode {
			get { return mintCal_Mode; }
			set { mintCal_Mode = Value; }
		}

		private double ScanSpeed {
			get { return mintScanSpeed; }
			set { mintScanSpeed = Value; }
		}


		private double XaxisMin {
			get { return mdblXaxisMin; }
			set { mdblXaxisMin = Value; }
		}

		private double XaxisMax {
			get { return mdblXaxisMax; }
			set { mdblXaxisMax = Value; }
		}

		private double YaxisMin {
			get { return mdblYaxisMin; }
			set { mdblYaxisMin = Value; }
		}

		private double YaxisMax {
			get { return mdblYaxisMax; }
			set { mdblYaxisMax = Value; }
		}

		private double PMTV {
			get { return mdblPmtV; }
			set { mdblPmtV = Value; }
		}

		private double PMTV_Ref {
			get { return mdblPmtV_Ref; }
			set { mdblPmtV_Ref = Value; }
		}


		private int D2Curr {
			get { return mintD2Curr; }
			set { mintD2Curr = Value; }
		}

		private double SlitWidth {
			get { return mdblSlitWidth; }
			set { mdblSlitWidth = Value; }
		}

		private double SlitWidth_Ref {
			get { return mdblSlitWidth_Ref; }
			set { mdblSlitWidth_Ref = Value; }
		}



		private string Comments {
			get { return mstrComments; }
			set { mstrComments = Value; }
		}

		private bool UVABS {
			get { return mblnUVABS; }
			set { mblnUVABS = Value; }
		}

		private bool IsBaseline {
			get { return mblnIsBaseline; }
			set { mblnIsBaseline = Value; }
		}

	}

	//--- This Data object is holds the reading details of the instrument
	[Serializable()]
	public class Data
	{
		double mdblXaxisData;
		double mdblYaxisData;
		double mdblYaxisADCData;

		bool mblnGraphPlotted = false;
		private bool GraphPloted {
			get { return mblnGraphPlotted; }
			set { mblnGraphPlotted = Value; }
		}

		private double XaxisData {
			get { return mdblXaxisData; }
			set { mdblXaxisData = Value; }
		}

		private double YaxisData {
			get { return mdblYaxisData; }
			set { mdblYaxisData = Value; }
		}

		private double YaxisADCData {
			get { return mdblYaxisADCData; }
			set { mdblYaxisADCData = Value; }
		}
	}

}






