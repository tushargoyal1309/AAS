Option Explicit On 
Imports AAS203.Signature
Imports System.IO
Imports Microsoft.VisualBasic
Imports AAS203Library

Namespace Spectrum

    Public Class clsSpectrum

#Region " Private Declaration "
        Private Structure _Data
            Dim mGraphPlot As Boolean
            Dim mXaxisData As Integer
            Dim mYaxisData As Integer
        End Structure
        Dim Data As _Data
        Public Structure PeakValley
            Dim Abs As Double
            Dim Wv As Double
            Dim Nature As Boolean   'True for Peak and False for valley
        End Structure
        Dim m_MaxPeakValley As Integer = 0
#End Region

#Region " Property "
        Public ReadOnly Property PeakValleyCount() As Integer
            Get
                Return m_MaxPeakValley
            End Get

        End Property
#End Region

#Region " Methos "

        Public Function funcAddSpecDataToChannel(ByVal objSrcReadings As Readings, _
                                                    ByRef objDestReadings As Readings) As Boolean
            '=====================================================================
            ' Procedure Name        :   gfuncAddSpecDataToChannel
            ' Description           :   Add the Spectrum data to the readings object
            '                           with the readings collection as MAX_RANGE
            ' Purpose               :   To populate the readings collection to max range(9910)
            ' Parameters Passed     :   None.
            ' Returns               :   True, if successful.
            ' Parameters Affected   :   None.
            ' Assumptions           :   None.
            ' Dependencies          :   None. 
            ' Author                :   Sachin Dokhale
            ' Created               :   13.12.06
            ' Revisions             :
            '=====================================================================
            Try
                Dim lngCounter As Long
                Dim dblWaveLength As Double
                Dim lngIndex As Long

                ' Me.Cursor = Cursors.WaitCursor
                '--- Initialize the array of max range
                dblWaveLength = 0.0


                '--- Get the data from the source and add to the destination collection
                For lngCounter = 0 To objSrcReadings.Count - 1
                    '--- Get the wavelength from the source collection and 
                    '--- calculate the index and assign the espective value
                    '--- in the collection
                    'lngIndex = gFuncGetIndexWv(objSrcReadings.item(lngCounter).XaxisData, True)
                    '--- Check for the index value less than the min and greater than
                    '--- the max
                    If objDestReadings.Count - 1 < lngCounter Then
                        Dim objData As New Data
                        'objData.XaxisData = Format(dblWaveLength, "#000.0")
                        objData.XaxisData = objSrcReadings.item(lngCounter).XaxisData
                        objData.YaxisData = objSrcReadings.item(lngCounter).YaxisData
                        objData.YaxisADCData = objSrcReadings.item(lngCounter).YaxisADCData
                        objData.GraphPloted = True
                        objDestReadings.Add(objData)
                    Else
                        'objDestReadings.item(lngCounter).XaxisData = Format(dblWaveLength, "#000.0")
                        'objDestReadings.item(lngCounter).YaxisData = 0.0
                        objDestReadings.item(lngCounter).XaxisData = objSrcReadings.item(lngCounter).XaxisData
                        objDestReadings.item(lngCounter).YaxisData = objSrcReadings.item(lngCounter).YaxisData
                        objDestReadings.item(lngCounter).YaxisADCData = objSrcReadings.item(lngCounter).YaxisADCData
                        objDestReadings.item(lngCounter).GraphPloted = True
                    End If

                Next

                Return True
            Catch ex As Exception
                '---------------------------------------------------------
                'Error Handling and logging
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = ex.Message
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            Finally
                '---------------------------------------------------------
                'Writing Execution log
                If CONST_CREATE_EXECUTION_LOG = 1 Then
                    gobjErrorHandler.WriteExecutionLog()
                End If
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcCloneUVSChannel(ByVal inobjChanel As Channel) As Channel
            '=====================================================================
            ' Procedure Name        :   gfuncCloneChannel
            ' Description           :   Add the channel data to the Channels object
            '                           with the readings collection as MAX_RANGE
            ' Purpose               :   
            ' Parameters Passed     :   inobjChanel as channel.
            ' Returns               :   channel.
            ' Parameters Affected   :   None.
            ' Assumptions           :   None.
            ' Dependencies          :   None. 
            ' Author                :   Sachin Dokhale
            ' Created               :   13.12.06
            ' Revisions             :
            '===s==================================================================
            Try
                Dim objCloneChanel As New Spectrum.Channel(False)
                Dim intSpectrumCol, intReadingsCol As Integer

                '----------------------Clonong  parameter object ----------------------------------
                'objCloneChanel.UVParameter.AnalysisDate = inobjChanel.UVParameter.AnalysisDate
                'objCloneChanel.UVParameter.Cal_Mode = inobjChanel.UVParameter.Cal_Mode
                'objCloneChanel.UVParameter.Comments = inobjChanel.UVParameter.Comments
                'objCloneChanel.UVParameter.D2Curr = inobjChanel.UVParameter.D2Curr
                'objCloneChanel.UVParameter.ScanSpeed = inobjChanel.UVParameter.ScanSpeed
                'objCloneChanel.UVParameter.SlitWidth = inobjChanel.UVParameter.SlitWidth
                'objCloneChanel.UVParameter.SpectrumName = inobjChanel.UVParameter.SpectrumName
                'objCloneChanel.UVParameter.XaxisMax = inobjChanel.UVParameter.XaxisMax
                'objCloneChanel.UVParameter.XaxisMin = inobjChanel.UVParameter.XaxisMin
                'objCloneChanel.UVParameter.YaxisMax = inobjChanel.UVParameter.YaxisMax
                'objCloneChanel.UVParameter.YaxisMin = inobjChanel.UVParameter.YaxisMin
                objCloneChanel.UVParameter = funcCloneUVParameter(inobjChanel.UVParameter)

                '----------------------Clonong  parameter object ends -----------------------------

                '----------------------Cloning  spectrum object ----------------------------------
                For intSpectrumCol = 0 To inobjChanel.Spectrums.Count - 1

                    '----------------------Cloning  spectrumData object ----------------------------------
                    Dim objCloneSpectrumData As New SpectrumData
                    objCloneChanel.Spectrums.Add(objCloneSpectrumData)
                    objCloneSpectrumData.SpectrumColor = objCloneChanel.Spectrums.item(intSpectrumCol).SpectrumColor
                    objCloneSpectrumData.SpectrumName = objCloneChanel.Spectrums.item(intSpectrumCol).SpectrumName

                    '----------------------Cloning  readings object ----------------------------------
                    For intReadingsCol = 0 To inobjChanel.Spectrums.item(intSpectrumCol).Readings.Count - 1

                        '----------------------Cloning  Data object ----------------------------------

                        Dim objCloneData As New Data
                        objCloneSpectrumData.Readings.Add(objCloneData)
                        objCloneData.XaxisData = inobjChanel.Spectrums.item(intSpectrumCol).Readings.item(intReadingsCol).XaxisData
                        objCloneData.YaxisData = inobjChanel.Spectrums.item(intSpectrumCol).Readings.item(intReadingsCol).YaxisData
                        objCloneData.YaxisADCData = inobjChanel.Spectrums.item(intSpectrumCol).Readings.item(intReadingsCol).YaxisADCData

                        '----------------------Clonong Data object ends -----------------------------

                    Next intReadingsCol   '----------------------Cloning  readings object ends----------------------------------
                    '----------------------------Cloning  spectrumData object ends----------------------------------
                Next intSpectrumCol   '----------------------Cloning  spectrum object ends----------------------------------

                '----------------------Cloning  Channel object ----------------------------------
                objCloneChanel.ChannelNo = inobjChanel.ChannelNo
                objCloneChanel.IsEnergySpectrum = False
                'objCloneChanel.Parameter.ChannelName = inobjChanel.Parameter.ChannelName
                'objCloneChanel.Parameter.AnalysisDate = inobjChanel.Parameter.AnalysisDate
                'objCloneChanel.Parameter.AnalystName = inobjChanel.Parameter.AnalystName
                '----------------------Cloning  Channel object ends -----------------------------

                '--- Clone the digital signature object
                'objCloneChanel.DigitalSignature.ActivityType = inobjChanel.DigitalSignature.ActivityType
                'objCloneChanel.DigitalSignature.FileName = inobjChanel.DigitalSignature.FileName
                'objCloneChanel.DigitalSignature.FilePassword = inobjChanel.DigitalSignature.FilePassword
                'objCloneChanel.DigitalSignature.LoginPassword = inobjChanel.DigitalSignature.LoginPassword
                'objCloneChanel.DigitalSignature.SaveDate = inobjChanel.DigitalSignature.SaveDate
                'objCloneChanel.DigitalSignature.UserID = inobjChanel.DigitalSignature.UserID
                'objCloneChanel.DigitalSignature.UserName = inobjChanel.DigitalSignature.UserName

                Return objCloneChanel

            Catch ex As Exception
                '---------------------------------------------------------
                'Error Handling and logging
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = ex.Message
                gobjErrorHandler.WriteErrorLog(ex)
                Return Nothing
                '---------------------------------------------------------
            Finally
                '---------------------------------------------------------
                'Writing Execution log
                If CONST_CREATE_EXECUTION_LOG = 1 Then
                    gobjErrorHandler.WriteExecutionLog()
                End If
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcCloneESChannel(ByVal inobjChanel As Channel) As Channel
            '=====================================================================
            ' Procedure Name        :   gfuncCloneChannel
            ' Description           :   Add the channel data to the Channels object
            '                           with the readings collection as MAX_RANGE
            ' Purpose               :   
            ' Parameters Passed     :   inobjChanel As Channel
            ' Returns               :   Channel
            ' Parameters Affected   :   None.
            ' Assumptions           :   None.
            ' Dependencies          :   None. 
            ' Author                :   Sachin Dokhale
            ' Created               :   13.12.06
            ' Revisions             :
            '=====================================================================
            Try
                Dim objCloneChanel As New Spectrum.Channel(True)
                Dim intSpectrumCol, intReadingsCol As Integer

                '----------------------Clonong  parameter object ----------------------------------
                'objCloneChanel.EnegryParameter.AnalysisDate = inobjChanel.EnegryParameter.AnalysisDate
                'objCloneChanel.EnegryParameter.BurnerHeight = inobjChanel.EnegryParameter.BurnerHeight
                'objCloneChanel.EnegryParameter.Cal_Mode = inobjChanel.EnegryParameter.Cal_Mode
                'objCloneChanel.EnegryParameter.Comments = inobjChanel.EnegryParameter.Comments
                'objCloneChanel.EnegryParameter.D2Curr = inobjChanel.EnegryParameter.D2Curr
                'objCloneChanel.EnegryParameter.FualRatio = inobjChanel.EnegryParameter.FualRatio
                'objCloneChanel.EnegryParameter.HCLCurr = inobjChanel.EnegryParameter.HCLCurr
                'objCloneChanel.EnegryParameter.LampEle = inobjChanel.EnegryParameter.LampEle
                'objCloneChanel.EnegryParameter.LampTurrNo = inobjChanel.EnegryParameter.LampTurrNo
                'objCloneChanel.EnegryParameter.PMTV = inobjChanel.EnegryParameter.PMTV
                'objCloneChanel.EnegryParameter.ScanSpeed = inobjChanel.EnegryParameter.ScanSpeed
                'objCloneChanel.EnegryParameter.SlitWidth = inobjChanel.EnegryParameter.SlitWidth
                'objCloneChanel.EnegryParameter.SpectrumName = inobjChanel.EnegryParameter.SpectrumName
                'objCloneChanel.EnegryParameter.XaxisMax = inobjChanel.EnegryParameter.XaxisMax
                'objCloneChanel.EnegryParameter.XaxisMin = inobjChanel.EnegryParameter.XaxisMin
                'objCloneChanel.EnegryParameter.YaxisMax = inobjChanel.EnegryParameter.YaxisMax
                'objCloneChanel.EnegryParameter.YaxisMin = inobjChanel.EnegryParameter.YaxisMin

                objCloneChanel.EnegryParameter = funcCloneESParameter(inobjChanel.EnegryParameter)
                '----------------------Clonong  parameter object ends -----------------------------

                '----------------------Cloning  spectrum object ----------------------------------
                For intSpectrumCol = 0 To inobjChanel.Spectrums.Count - 1

                    '----------------------Cloning  spectrumData object ----------------------------------
                    Dim objCloneSpectrumData As New SpectrumData
                    objCloneChanel.Spectrums.Add(objCloneSpectrumData)
                    objCloneSpectrumData.SpectrumColor = objCloneChanel.Spectrums.item(intSpectrumCol).SpectrumColor
                    objCloneSpectrumData.SpectrumName = objCloneChanel.Spectrums.item(intSpectrumCol).SpectrumName

                    '----------------------Cloning  readings object ----------------------------------
                    For intReadingsCol = 0 To inobjChanel.Spectrums.item(intSpectrumCol).Readings.Count - 1

                        '----------------------Cloning  Data object ----------------------------------

                        Dim objCloneData As New Data
                        objCloneSpectrumData.Readings.Add(objCloneData)
                        objCloneData.XaxisData = inobjChanel.Spectrums.item(intSpectrumCol).Readings.item(intReadingsCol).XaxisData
                        objCloneData.YaxisData = inobjChanel.Spectrums.item(intSpectrumCol).Readings.item(intReadingsCol).YaxisData
                        objCloneData.YaxisADCData = inobjChanel.Spectrums.item(intSpectrumCol).Readings.item(intReadingsCol).YaxisADCData

                        '----------------------Clonong Data object ends -----------------------------

                    Next intReadingsCol   '----------------------Cloning  readings object ends----------------------------------
                    '----------------------------Cloning  spectrumData object ends----------------------------------
                Next intSpectrumCol   '----------------------Cloning  spectrum object ends----------------------------------

                '----------------------Cloning  Channel object ----------------------------------
                objCloneChanel.ChannelNo = inobjChanel.ChannelNo
                objCloneChanel.IsEnergySpectrum = True
                'objCloneChanel.Parameter.ChannelName = inobjChanel.Parameter.ChannelName
                'objCloneChanel.Parameter.AnalysisDate = inobjChanel.Parameter.AnalysisDate
                'objCloneChanel.Parameter.AnalystName = inobjChanel.Parameter.AnalystName
                '----------------------Cloning  Channel object ends -----------------------------

                '--- Clone the digital signature object
                'objCloneChanel.DigitalSignature.ActivityType = inobjChanel.DigitalSignature.ActivityType
                'objCloneChanel.DigitalSignature.FileName = inobjChanel.DigitalSignature.FileName
                'objCloneChanel.DigitalSignature.FilePassword = inobjChanel.DigitalSignature.FilePassword
                'objCloneChanel.DigitalSignature.LoginPassword = inobjChanel.DigitalSignature.LoginPassword
                'objCloneChanel.DigitalSignature.SaveDate = inobjChanel.DigitalSignature.SaveDate
                'objCloneChanel.DigitalSignature.UserID = inobjChanel.DigitalSignature.UserID
                'objCloneChanel.DigitalSignature.UserName = inobjChanel.DigitalSignature.UserName

                Return objCloneChanel

            Catch ex As Exception
                '---------------------------------------------------------
                'Error Handling and logging
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = ex.Message
                gobjErrorHandler.WriteErrorLog(ex)
                Return Nothing
                '---------------------------------------------------------
            Finally
                '---------------------------------------------------------
                'Writing Execution log
                If CONST_CREATE_EXECUTION_LOG = 1 Then
                    gobjErrorHandler.WriteExecutionLog()
                End If
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcCloneUVParameter(ByVal inobjparamter As Spectrum.UVSpectrumParameter) As Spectrum.UVSpectrumParameter
            Try
                Dim objCloneParameter As New UVSpectrumParameter
                '----------------------Cloning  parameter object ----------------------------------
                objCloneParameter.AnalysisDate = inobjparamter.AnalysisDate
                objCloneParameter.Cal_Mode = inobjparamter.Cal_Mode
                objCloneParameter.Comments = inobjparamter.Comments
                objCloneParameter.D2Curr = inobjparamter.D2Curr
                objCloneParameter.PMTV = inobjparamter.PMTV
                objCloneParameter.PMTV_Ref = inobjparamter.PMTV_Ref
                objCloneParameter.ScanSpeed = inobjparamter.ScanSpeed
                objCloneParameter.SlitWidth = inobjparamter.SlitWidth
                objCloneParameter.SlitWidth_Ref = inobjparamter.SlitWidth_Ref
                objCloneParameter.SpectrumName = inobjparamter.SpectrumName
                objCloneParameter.XaxisMax = inobjparamter.XaxisMax
                objCloneParameter.XaxisMin = inobjparamter.XaxisMin
                objCloneParameter.YaxisMax = inobjparamter.YaxisMax
                objCloneParameter.YaxisMin = inobjparamter.YaxisMin

                '----------------------Clonong  parameter object ends -----------------------------
                Return objCloneParameter

            Catch ex As Exception
                '---------------------------------------------------------
                'Error Handling and logging
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = ex.Message
                gobjErrorHandler.WriteErrorLog(ex)
                'gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex)
                '---------------------------------------------------------
            Finally
                '---------------------------------------------------------
                'Writing Execution log
                If CONST_CREATE_EXECUTION_LOG = 1 Then
                    gobjErrorHandler.WriteExecutionLog()
                End If
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcCloneESParameter(ByVal inobjparamter As Spectrum.EnergySpectrumParameter) As Spectrum.EnergySpectrumParameter
            '=====================================================================
            ' Procedure Name        :   funcCloneESParameter
            ' Description           :    
            ' Purpose               :    
            '                           
            ' Parameters Passed     :   None.
            ' Returns               :   True, if successful.
            ' Parameters Affected   :   None.
            ' Assumptions           :
            ' Dependencies          :
            ' Author                :   Sachin Dokhale
            ' Created               :   22.12.07
            ' Revisions             :
            '=====================================================================
            Try
                Dim objCloneParameter As New EnergySpectrumParameter
                '----------------------Cloning  parameter object ----------------------------------
                objCloneParameter.AnalysisDate = inobjparamter.AnalysisDate
                objCloneParameter.BurnerHeight = inobjparamter.BurnerHeight
                objCloneParameter.FualRatio = inobjparamter.FualRatio
                objCloneParameter.HCLCurr = inobjparamter.HCLCurr
                objCloneParameter.LampEle = inobjparamter.LampEle
                objCloneParameter.LampTurrNo = inobjparamter.LampTurrNo
                objCloneParameter.Cal_Mode = inobjparamter.Cal_Mode
                objCloneParameter.Comments = inobjparamter.Comments
                objCloneParameter.D2Curr = inobjparamter.D2Curr
                objCloneParameter.PMTV = inobjparamter.PMTV
                objCloneParameter.PMTV_Ref = inobjparamter.PMTV_Ref
                objCloneParameter.ScanSpeed = inobjparamter.ScanSpeed
                objCloneParameter.SlitWidth = inobjparamter.SlitWidth
                objCloneParameter.SlitWidthRef = inobjparamter.SlitWidthRef
                objCloneParameter.SpectrumName = inobjparamter.SpectrumName
                objCloneParameter.XaxisMax = inobjparamter.XaxisMax
                objCloneParameter.XaxisMin = inobjparamter.XaxisMin
                objCloneParameter.YaxisMax = inobjparamter.YaxisMax
                objCloneParameter.YaxisMin = inobjparamter.YaxisMin

                '----------------------Clonong  parameter object ends -----------------------------
                Return objCloneParameter

            Catch ex As Exception
                '---------------------------------------------------------
                'Error Handling and logging
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = ex.Message
                gobjErrorHandler.WriteErrorLog(ex)
                'gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex)
                '---------------------------------------------------------
            Finally
                '---------------------------------------------------------
                'Writing Execution log
                If CONST_CREATE_EXECUTION_LOG = 1 Then
                    gobjErrorHandler.WriteExecutionLog()
                End If
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcPeaks_1(ByVal PeakChannel As Channel, ByRef structPeak() As PeakValley) As Boolean
            '=====================================================================
            ' Procedure Name        :   funcPeaks
            ' Description           :   
            ' Purpose               :   
            ' Parameters Passed     :   Channel
            ' Returns               :   True, if successful.
            ' Parameters Affected   :   structPeak() As PeakValley
            ' Assumptions           :   None.
            ' Dependencies          :   None. 
            ' Author                :   Sachin Dokhale
            ' Created               :   13.12.06
            ' Revisions             :
            '=====================================================================

            'double       ymx=0;
            'int         i, j;
            'int	    	x1, k;
            'int         step, inr=0;

            Try
                'int         *chanel1=NULL;
                'int         *chanel0=NULL;

                Dim chanel1 As Channel
                Dim chanel0 As Channel
                '//--------]
                Dim Steps, x1, intPickCount As Integer
                Dim j, k As Integer
                Dim i As Integer = 0
                Dim inr As Integer
                Dim dblYmaxMin As Double
                Dim objParameter As Object
                '//---------

                '//----- Refresh to Peak structure
                For i = 0 To 100
                    structPeak(i).Wv = 0.0
                    structPeak(i).Abs = 0.0
                    structPeak(i).Nature = False
                Next
                '//-----


                'chanel0 = &addata.ad[0];
                If gintSpectrumMode = modGlobalDeclarations.EnumSpectrumMode.UVSpetrum Then
                    chanel0 = funcCloneUVSChannel(PeakChannel)
                    ''function for clonning.
                    chanel1 = funcCloneUVSChannel(PeakChannel)
                    Steps = PeakChannel.UVParameter.Cal_Mode()
                    objParameter = PeakChannel.UVParameter
                ElseIf gintSpectrumMode = modGlobalDeclarations.EnumSpectrumMode.EnergySpectrum Then
                    chanel0 = funcCloneESChannel(PeakChannel)
                    chanel1 = funcCloneESChannel(PeakChannel)
                    objParameter = PeakChannel.EnegryParameter
                End If
                If chanel0.Spectrums.Count <= 0 Then
                    Exit Function
                End If
                m_MaxPeakValley = 0
                'step = addata.mode
                'Steps = gobjInst.Mode
                Steps = objParameter.Cal_Mode

                funcSmooth1(chanel1, 0)
                'diff_chanel(chanel0 , chanel1, addata.counter);

                'if (SpectGraph.Xmax-SpectGraph.Xmin>5.0)   {
                '	  if (step<=5) inr = 8;
                '		 else if(step<=25) inr=4;
                '		 else inr=1;
                '	 }
                If (objParameter.XaxisMax - objParameter.XaxisMin > 5.0) Then
                    If (Steps <= 5) Then
                        inr = 8
                        'inr = 1
                    ElseIf (Steps <= 25) Then
                        inr = 4
                    Else
                        inr = 1
                    End If
                Else
                    inr = 2
                End If
                i = inr
                x1 = 1


                'ymx = GetmV(chanel1[0]);
                dblYmaxMin = gFuncGetmv(chanel1.Spectrums.item(0).Readings.item(0).YaxisData)

                'While (i < (adData.counter - inr))
                While (i < (chanel1.Spectrums.item(0).Readings.Count - inr))
                    ' For k = -(inr) To k <= inr
                    For k = -(inr) To inr
                        If i + k + 1 > (chanel1.Spectrums.item(0).Readings.Count) Then
                            Exit For
                        End If
                        If (k < 0) Then
                            If (chanel1.Spectrums.item(0).Readings.item(i + k).YaxisData <= chanel1.Spectrums.item(0).Readings.item(i + k + 1).YaxisData) Then
                                'continue()
                            Else
                                Exit For
                            End If

                        Else
                            If (chanel1.Spectrums.item(0).Readings.item(i + k).YaxisData >= chanel1.Spectrums.item(0).Readings.item(i + k + 1).YaxisData) Then
                                'continue()
                            Else
                                Exit For
                            End If
                        End If
                    Next

                    For j = -(inr) To inr  'j++
                        If i + j + 1 > (chanel1.Spectrums.item(0).Readings.Count) Then
                            Exit For
                        End If
                        If (j < 0) Then
                            If (chanel1.Spectrums.item(0).Readings.item(i + j).YaxisData >= chanel1.Spectrums.item(0).Readings.item(i + j + 1).YaxisData) Then
                                'continue;
                            Else
                                Exit For
                            End If

                        Else
                            If (chanel1.Spectrums.item(0).Readings.item(i + j).YaxisData <= chanel1.Spectrums.item(0).Readings.item(i + j + 1).YaxisData) Then
                                'continue;
                            Else
                                Exit For
                            End If
                        End If
                    Next

                    If (k > inr) Then
                        'if (peak[x1-1].wv!=i-1 && peakvalid(chanel0, &ymx, i, inr, TRUE)){
                        If ((structPeak(x1 - 1).Wv <> i - 1) And funcPeakValid(chanel0, dblYmaxMin, i, inr)) Then
                            'i= GetPeak(chanel0, i, TRUE);
                            i = funcGetPeak(chanel0, i)
                            structPeak(x1).Abs = chanel0.Spectrums.item(0).Readings.item(i).YaxisData
                            structPeak(x1).Wv = i   'chanel0.Spectrums.item(0).Readings.item(i).YaxisData
                            'structPeak(x1).Wv = chanel0.Spectrums.item(0).Readings.item(i).XaxisData
                            structPeak(x1).Nature = True
                            x1 += 1
                            intPickCount += 1
                            If (x1 > 100) Then
                                x1 = 100
                                i += inr
                            End If

                        Else
                            i += inr
                        End If
                    ElseIf (j > inr) Then

                        If ((structPeak(x1 - 1).Wv <> i - 1) And funcValleyValid(chanel0, dblYmaxMin, i, inr)) Then
                            i = funcGetPeak(chanel0, i)
                            structPeak(x1).Abs = chanel0.Spectrums.item(0).Readings.item(i).YaxisData
                            structPeak(x1).Wv = i   'chanel0.Spectrums.item(0).Readings.item(i).YaxisData
                            'structPeak(x1).Wv = chanel0.Spectrums.item(0).Readings.item(i).XaxisData
                            structPeak(x1).Nature = False
                            x1 += 1
                            intPickCount += 1
                            If (x1 > 100) Then
                                x1 = 100
                                i += inr
                            End If
                        Else
                            i += inr
                        End If
                    Else
                        i += 1
                    End If
                    'Next
                End While

                k = 0
                m_MaxPeakValley = intPickCount

                ' if (chanel1 != NULL) {
                '	chanel0 = &addata.ad[0];
                '//	SpectGraph.Xmin= addata.wv1;  XMAX = addata.wv2;
                '	step = addata.mode;  i=0;
                '	diff_chanel(chanel0 , chanel1, addata.counter);

                Return True
            Catch ex As Exception
                '---------------------------------------------------------
                'Error Handling and logging
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = ex.Message
                gobjErrorHandler.WriteErrorLog(ex)
                Return False
                '---------------------------------------------------------
            Finally
                '---------------------------------------------------------
                'Writing Execution log
                If CONST_CREATE_EXECUTION_LOG = 1 Then
                    gobjErrorHandler.WriteExecutionLog()
                End If
                '---------------------------------------------------------
            End Try
        End Function

        Public Function funcPeaks(ByVal PeakChannel As Channel, ByRef structPeak() As PeakValley) As Boolean
            '=====================================================================
            ' Procedure Name        :   funcPeaks
            ' Description           :   
            ' Purpose               :   
            ' Parameters Passed     :   Channel.
            ' Returns               :   True, if successful.
            ' Parameters Affected   :   structPeak() As PeakValley.
            ' Assumptions           :   None.
            ' Dependencies          :   None. 
            ' Author                :   Sachin Dokhale
            ' Created               :   13.12.06
            ' Revisions             :
            '=====================================================================



            Try

                Dim chanel1 As Channel
                Dim chanel0 As Channel
                '//--------]
                Dim Steps, x1, intPickCount As Integer
                Dim j, k As Integer
                Dim i As Integer = 0
                Dim inr As Integer
                Dim dblYmaxMin As Double
                Dim objParameter As Object
                '//---------

                '//----- Refresh to Peak structure
                For i = 0 To 100
                    structPeak(i).Wv = 0.0
                    structPeak(i).Abs = 0.0
                    structPeak(i).Nature = False
                Next
                '//-----



                ' copy Data with struncure into channel object for internal use in this function
                If gintSpectrumMode = modGlobalDeclarations.EnumSpectrumMode.UVSpetrum Then
                    chanel0 = funcCloneUVSChannel(PeakChannel)
                    chanel1 = funcCloneUVSChannel(PeakChannel)
                    Steps = PeakChannel.UVParameter.Cal_Mode()
                    objParameter = PeakChannel.UVParameter
                ElseIf gintSpectrumMode = modGlobalDeclarations.EnumSpectrumMode.EnergySpectrum Then
                    chanel0 = funcCloneESChannel(PeakChannel)
                    chanel1 = funcCloneESChannel(PeakChannel)
                    objParameter = PeakChannel.EnegryParameter
                End If
                If chanel0.Spectrums.Count <= 0 Then
                    Exit Function
                End If
                m_MaxPeakValley = 0

                ' Set the Steps from calibration mode
                Steps = objParameter.Cal_Mode


                'smooth the data into channle object
                funcSmooth1(chanel1, 0)


                'if (SpectGraph.Xmax-SpectGraph.Xmin>5.0)   {
                '	  if (step<=5) inr = 8;
                '		 else if(step<=25) inr=4;
                '		 else inr=1;
                '	 }
                ' Detects peaks and valles
                If (objParameter.XaxisMax - objParameter.XaxisMin > 5.0) Then
                    If (Steps <= 5) Then
                        inr = 8
                        'inr = 1
                    ElseIf (Steps <= 25) Then
                        inr = 4
                    Else
                        inr = 1
                    End If
                Else
                    inr = 2
                End If
                i = inr
                x1 = 1


                'ymx = GetmV(chanel1[0]);
                dblYmaxMin = gFuncGetmv(chanel1.Spectrums.item(0).Readings.item(0).YaxisADCData)
                'dblYmaxMin = chanel1.Spectrums.item(0).Readings.item(0).YaxisData


                'While (i < (adData.counter - inr))
                'For i = gFuncGetIndexWv(chanel1.UVParameter.XaxisMin, False) To gFuncGetIndexWv(chanel1.UVParameter.XaxisMax, False) - inr
                'For i = inr To chanel1.Spectrums.item(0).Readings.Count - inr - 1
                While (i < (chanel1.Spectrums.item(0).Readings.Count - inr))
                    ' For k = -(inr) To k <= inr
                    For k = -(inr) To inr
                        If i + k + 1 > (chanel1.Spectrums.item(0).Readings.Count) Then
                            Exit For
                        End If
                        If (k < 0) Then
                            'If (k > 0) Then
                            If (chanel1.Spectrums.item(0).Readings.item(i + k).YaxisADCData <= chanel1.Spectrums.item(0).Readings.item(i + k + 1).YaxisADCData) Then
                                'continue()
                            Else
                                Exit For
                            End If

                        Else
                            If (chanel1.Spectrums.item(0).Readings.item(i + k).YaxisADCData >= chanel1.Spectrums.item(0).Readings.item(i + k + 1).YaxisADCData) Then
                                'If (chanel1.Spectrums.item(0).Readings.item(i + k).YaxisADCData > chanel1.Spectrums.item(0).Readings.item(i + k + 1).YaxisADCData) Then
                                'continue()
                            Else
                                Exit For
                            End If
                        End If
                    Next

                    For j = -(inr) To inr  'j++
                        If i + j + 1 > (chanel1.Spectrums.item(0).Readings.Count) Then
                            Exit For
                        End If
                        If (j < 0) Then
                            'If (j > 0) Then
                            If (chanel1.Spectrums.item(0).Readings.item(i + j).YaxisADCData >= chanel1.Spectrums.item(0).Readings.item(i + j + 1).YaxisADCData) Then
                                'continue;
                            Else
                                Exit For
                            End If

                        Else
                            If (chanel1.Spectrums.item(0).Readings.item(i + j).YaxisADCData <= chanel1.Spectrums.item(0).Readings.item(i + j + 1).YaxisADCData) Then
                                'continue;
                            Else
                                Exit For
                            End If
                        End If
                    Next

                    If (k > inr) Then
                        'if (peak[x1-1].wv!=i-1 && peakvalid(chanel0, &ymx, i, inr, TRUE)){
                        If ((structPeak(x1 - 1).Wv <> i - 1) And funcPeakValid(chanel0, dblYmaxMin, i, inr)) Then
                            'i= GetPeak(chanel0, i, TRUE);
                            i = funcGetPeak(chanel0, i)
                            structPeak(x1).Abs = chanel0.Spectrums.item(0).Readings.item(i).YaxisADCData
                            structPeak(x1).Wv = i   'chanel0.Spectrums.item(0).Readings.item(i).YaxisData
                            'structPeak(x1).Wv = chanel0.Spectrums.item(0).Readings.item(i).XaxisData
                            structPeak(x1).Nature = True
                            x1 += 1
                            intPickCount += 1
                            If (x1 > 100) Then
                                x1 = 100
                                i += inr
                            End If

                        Else
                            i += inr
                        End If
                    ElseIf (j > inr) Then

                        If ((structPeak(x1 - 1).Wv <> i - 1) And funcValleyValid(chanel0, dblYmaxMin, i, inr)) Then
                            'i = funcGetPeak(chanel0, i)
                            i = funcGetPeak(chanel0, i)
                            structPeak(x1).Abs = chanel0.Spectrums.item(0).Readings.item(i).YaxisADCData
                            structPeak(x1).Wv = i   'chanel0.Spectrums.item(0).Readings.item(i).YaxisData
                            'structPeak(x1).Wv = chanel0.Spectrums.item(0).Readings.item(i).XaxisData
                            structPeak(x1).Nature = False
                            x1 += 1
                            intPickCount += 1
                            If (x1 > 100) Then
                                x1 = 100
                                i += inr
                            End If
                        Else
                            i += inr
                        End If
                    Else
                        i += 1
                    End If
                    'Next
                End While

                k = 0
                m_MaxPeakValley = intPickCount

                ' return by Ref to structure of Peak and valley 
                Return True
            Catch ex As Exception
                '---------------------------------------------------------
                'Error Handling and logging
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = ex.Message
                gobjErrorHandler.WriteErrorLog(ex)
                Return False
                '---------------------------------------------------------
            Finally
                '---------------------------------------------------------
                'Writing Execution log
                If CONST_CREATE_EXECUTION_LOG = 1 Then
                    gobjErrorHandler.WriteExecutionLog()
                End If
                '---------------------------------------------------------
            End Try
        End Function

        Public Function funcSmooth1(ByRef DestChannel As Channel, ByVal intCount As Integer) As Boolean
            '=====================================================================
            ' Procedure Name        :   funcSmooth1
            ' Description           :   
            ' Purpose               :   
            ' Parameters Passed     :   intCount as integer
            ' Returns               :   True, if successful.
            ' Parameters Affected   :   Destination channel
            ' Assumptions           :   None.
            ' Dependencies          :   None. 
            ' Author                :   Sachin Dokhale
            ' Created               :   13.12.06
            ' Revisions             :
            '=====================================================================
            Dim adsum As Double = 0
            Dim i, j, spts As Integer
            Dim intStartWvIdx As Integer
            Dim intLastWvIdx As Integer

            Try
                '//-------------
                '        void  smooth1(int  arr[], int n)
                '{
                ' double  adsum = 0;
                ' int 	i,j,spts;

                ' spts = 2;
                ' for (i=spts; i< n-1; i++)  {
                '	adsum = 0;
                '	for(j=1; j<=spts; j++)
                '	  if (j==1) adsum += (arr[i-j]*0.7+arr[i+j]*0.7);
                '	  else  adsum += (arr[i-j]*0.3+arr[i+j]*0.3);
                '	arr[i] = (adsum+arr[i])/(spts+1.0);
                '  }
                '}
                '//-------------
                spts = 2
                'If DestChannel.IsEnergySpectrum = False Then
                '    intStartWvIdx = gFuncGetIndexWv(DestChannel.UVParameter.XaxisMin, False)
                '    intLastWvIdx = gFuncGetIndexWv(DestChannel.UVParameter.XaxisMax, False)
                'Else
                '    intStartWvIdx = gFuncGetIndexWv(DestChannel.EnegryParameter.XaxisMin, False)
                '    intLastWvIdx = gFuncGetIndexWv(DestChannel.EnegryParameter.XaxisMax, False)
                'End If

                For i = spts To DestChannel.Spectrums.item(0).Readings.Count - 3
                    adsum = 0
                    For j = 1 To spts
                        If (j = 1) Then
                            '	  if (j==1) adsum += (arr[i-j]*0.7+arr[i+j]*0.7);
                            adsum += (DestChannel.Spectrums.item(0).Readings.item(i - j).YaxisData * 0.7 + DestChannel.Spectrums.item(0).Readings.item(i + j).YaxisData * 0.7)
                        Else
                            '	  else  adsum += (arr[i-j]*0.3+arr[i+j]*0.3);
                            adsum += (DestChannel.Spectrums.item(0).Readings.item(i - j).YaxisData * 0.3 + DestChannel.Spectrums.item(0).Readings.item(i + j).YaxisData * 0.3)
                        End If
                    Next
                    'arr[i] = (adsum+arr[i])/(spts+1.0);
                    DestChannel.Spectrums.item(0).Readings.item(i).YaxisData = (adsum + DestChannel.Spectrums.item(0).Readings.item(i).YaxisData) / (spts + 1.0)
                Next
                '//----- Added by Sachin Dokhale
                adsum = 0
                For i = spts To DestChannel.Spectrums.item(0).Readings.Count - 3
                    adsum = 0
                    For j = 1 To spts
                        If (j = 1) Then
                            '	  if (j==1) adsum += (arr[i-j]*0.7+arr[i+j]*0.7);
                            adsum += (DestChannel.Spectrums.item(0).Readings.item(i - j).YaxisADCData * 0.7 + DestChannel.Spectrums.item(0).Readings.item(i + j).YaxisADCData * 0.7)
                        Else
                            '	  else  adsum += (arr[i-j]*0.3+arr[i+j]*0.3);
                            adsum += (DestChannel.Spectrums.item(0).Readings.item(i - j).YaxisADCData * 0.3 + DestChannel.Spectrums.item(0).Readings.item(i + j).YaxisADCData * 0.3)
                        End If
                    Next
                    'arr[i] = (adsum+arr[i])/(spts+1.0);
                    DestChannel.Spectrums.item(0).Readings.item(i).YaxisADCData = (adsum + DestChannel.Spectrums.item(0).Readings.item(i).YaxisADCData) / (spts + 1.0)
                Next
                If DestChannel.IsEnergySpectrum = True Then
                    If Not (DestChannel.EnegryParameter Is Nothing) Then
                        For i = 0 To DestChannel.Spectrums.item(0).Readings.Count - 1
                            DestChannel.Spectrums.item(0).Readings.item(i).YaxisData = gfuncGetValueInSpectrum(DestChannel.Spectrums.item(0).Readings.item(i).YaxisADCData, DestChannel.EnegryParameter.Cal_Mode)
                        Next
                    End If
                End If
                '//-----
                Return True
            Catch ex As Exception
                '---------------------------------------------------------
                'Error Handling and logging
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = ex.Message
                gobjErrorHandler.WriteErrorLog(ex)
                Return False
                '---------------------------------------------------------
            Finally
                '---------------------------------------------------------
                'Writing Execution log
                If CONST_CREATE_EXECUTION_LOG = 1 Then
                    gobjErrorHandler.WriteExecutionLog()
                End If
                '---------------------------------------------------------
            End Try
        End Function

        Public Function funcGetDataPeakPickResults(ByRef objDataTable As DataTable, _
                                            ByRef structPeak() As PeakValley, _
                                            ByVal lngPeakValleyCount As Long, _
                                            ByVal objChannel As Channel) As Boolean
            '=====================================================================
            ' Procedure Name        :   funcGetDataPeakPickResults
            ' Description           :   this is used to get peak result in to a data table.
            ' Purpose               :   
            ' Parameters Passed     :   channel,lngPeakValleyCount
            ' Returns               :   True, if successful.
            ' Parameters Affected   :   objDataTable As DataTable, structPeak() As PeakValley is structure
            ' Assumptions           :   None.
            ' Dependencies          :   None. 
            ' Author                :   Sachin Dokhale
            ' Created               :   13.12.06
            ' Revisions             :
            '=====================================================================

            Dim lngRowCounter As Long
            Dim lngCounter As Long
            Dim lngPeakCounter As Long
            Dim lngValleyCounter As Long
            Dim dblToY_Peak As Double
            Dim dblToY_Valley As Double
            Dim objDataRow As DataRow
            Dim objSpectrumParameter As Object
            Dim strNumberFormat As String
            Try
                If objChannel.IsEnergySpectrum = True Then
                    objSpectrumParameter = objChannel.EnegryParameter
                Else
                    objSpectrumParameter = objChannel.UVParameter
                End If
                objDataTable.Columns.Clear()
                objDataTable.Rows.Clear()

                '--- Add columns to the data table
                objDataTable.Columns.Add("Peak (SrNo.)")
                objDataTable.Columns.Add("Peak (Wv)")

                '--- Check for the scan mode
                Select Case objSpectrumParameter.Cal_Mode
                    Case EnumCalibrationMode.AA, EnumCalibrationMode.D2E, EnumCalibrationMode.AABGC
                        'objDataTable.Columns.Add("Peak (Abs)")
                        If gblnUVABS = True Then
                            objDataTable.Columns.Add("Peak (Abs)")
                            strNumberFormat = "#0.000"
                        Else
                            objDataTable.Columns.Add("Peak (%T)")
                            strNumberFormat = "#0.0"
                        End If
                    Case EnumCalibrationMode.EMISSION
                        objDataTable.Columns.Add("Peak (%T)")
                        strNumberFormat = "#0.0"
                    Case EnumCalibrationMode.HCLE, EnumCalibrationMode.D2E, EnumCalibrationMode.AABGC
                        objDataTable.Columns.Add("Peak (Energy)")
                        strNumberFormat = "#0.0"
                End Select

                objDataTable.Columns.Add("Valley (SrNo.)")
                objDataTable.Columns.Add("Valley (Wv)")
                '--- Check for the scan mode
                Select Case objSpectrumParameter.Cal_Mode
                    Case EnumCalibrationMode.AA, EnumCalibrationMode.D2E, EnumCalibrationMode.AABGC
                        If gblnUVABS = True Then
                            objDataTable.Columns.Add("Valley (Abs)")
                            strNumberFormat = "#0.000"
                        Else
                            objDataTable.Columns.Add("Valley (%T)")
                            strNumberFormat = "#0.0"
                        End If
                    Case EnumCalibrationMode.EMISSION
                        objDataTable.Columns.Add("Valley (%T)")
                        strNumberFormat = "#0.0"
                    Case EnumCalibrationMode.HCLE, EnumCalibrationMode.D2E, EnumCalibrationMode.AABGC
                        objDataTable.Columns.Add("Valley (Energy)")
                        strNumberFormat = "#0.0"
                End Select

                ''--- Get the peak and valley data from the structure
                ''--- passed by arguments
                '--- Get the peak and valley data from the structure
                '--- passed by arguments
                lngRowCounter = 0
                lngPeakCounter = 0
                lngValleyCounter = 0

                For lngCounter = 1 To lngPeakValleyCount
                    dblToY_Peak = 0.0
                    dblToY_Valley = 0.0
                    If structPeak(lngCounter).Wv > 0 And structPeak(lngCounter).Wv < objChannel.Spectrums(0).Readings.item((objChannel.Spectrums(0).Readings.Count - 1)).XaxisData Then
                        '--- Check for Peak 
                        If structPeak(lngCounter).Nature = True Then
                            '--- Logic for Peak
                            '--- If We get Peak add to Peak counter
                            lngPeakCounter += 1
                            If lngPeakCounter > lngRowCounter Then
                                lngRowCounter += 1
                                '--- Add the row to the data table
                                objDataRow = objDataTable.NewRow
                                objDataTable.Rows.Add(objDataRow)
                            End If
                            objDataTable.Rows.Item(lngPeakCounter - 1).Item(0) = lngPeakCounter
                            objDataTable.Rows.Item(lngPeakCounter - 1).Item(1) = Format(objChannel.Spectrums(0).Readings(structPeak(lngCounter).Wv).XaxisData, "#000.0")

                            '--- Check for the scan mode
                            Select Case objSpectrumParameter.Cal_Mode
                                Case EnumCalibrationMode.AA, EnumCalibrationMode.D2E, EnumCalibrationMode.AABGC
                                    dblToY_Peak = gfuncGetValueInSpectrum(structPeak(lngCounter).Abs, objSpectrumParameter.Cal_Mode)
                                    objDataTable.Rows.Item(lngPeakCounter - 1).Item(2) = Format(dblToY_Peak, strNumberFormat)
                                Case EnumCalibrationMode.EMISSION, EnumCalibrationMode.HCLE, EnumCalibrationMode.AABGC
                                    'dblToY_Peak = gfuncGetValueInSpectrum(structPeak(lngCounter).Abs, gobjInst.Mode)
                                    'dblToY_Peak = structPeak(lngCounter).Abs
                                    dblToY_Peak = gfuncGetValueInSpectrum(structPeak(lngCounter).Abs, objSpectrumParameter.Cal_Mode)
                                    objDataTable.Rows.Item(lngPeakCounter - 1).Item(2) = Format(dblToY_Peak, strNumberFormat)
                            End Select

                        Else
                            '--- Logic for Valley
                            lngValleyCounter += 1
                            If lngValleyCounter > lngRowCounter Then
                                lngRowCounter += 1
                                objDataRow = objDataTable.NewRow
                                objDataTable.Rows.Add(objDataRow)
                            End If
                            objDataTable.Rows.Item(lngValleyCounter - 1).Item(3) = lngValleyCounter
                            objDataTable.Rows.Item(lngValleyCounter - 1).Item(4) = Format(objChannel.Spectrums(0).Readings(structPeak(lngCounter).Wv).XaxisData, "#000.0")

                            '--- Check for the scan mode
                            Select Case objSpectrumParameter.Cal_Mode
                                Case EnumCalibrationMode.AA, EnumCalibrationMode.D2E, EnumCalibrationMode.AABGC
                                    'objDataTable.Rows.Item(lngValleyCounter - 1).Item(5) = Format(structPeak(lngCounter).Abs, "#0.000")
                                    dblToY_Valley = gfuncGetValueInSpectrum(structPeak(lngCounter).Abs, objSpectrumParameter.Cal_Mode)
                                    objDataTable.Rows.Item(lngValleyCounter - 1).Item(5) = Format(dblToY_Valley, strNumberFormat)
                                Case EnumCalibrationMode.EMISSION, EnumCalibrationMode.HCLE, EnumCalibrationMode.AABGC
                                    'objDataTable.Rows.Item(lngValleyCounter - 1).Item(5) = Format(structPeak(lngCounter).Abs, "#0.0")
                                    'dblToY_Valley = gfuncGetValueInSpectrum(structPeak(lngCounter).Abs, gobjInst.Mode)
                                    dblToY_Valley = dblToY_Valley = gfuncGetValueInSpectrum(structPeak(lngCounter).Abs, objSpectrumParameter.Cal_Mode) 'structPeak(lngCounter).Abs
                                    objDataTable.Rows.Item(lngValleyCounter - 1).Item(5) = Format(dblToY_Valley, strNumberFormat)
                            End Select
                        End If
                    End If
                Next

                '--- logic for taking out the NULL
                Dim lngColCounter As Integer = 0
                lngRowCounter = 0

                For lngRowCounter = 0 To objDataTable.Rows.Count - 1
                    For lngColCounter = 0 To objDataTable.Columns.Count - 1
                        If IsDBNull(objDataTable.Rows.Item(lngRowCounter).Item(lngColCounter)) = True Then
                            objDataTable.Rows.Item(lngRowCounter).Item(lngColCounter) = ""
                        End If
                    Next
                Next
                Return True

            Catch ex As Exception
                '---------------------------------------------------------
                'Error Handling and logging
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = ex.Message
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
                Return False
            Finally
                '---------------------------------------------------------
                'Writing Execution log
                If CONST_CREATE_EXECUTION_LOG = 1 Then
                    gobjErrorHandler.WriteExecutionLog()
                End If
                '---------------------------------------------------------
            End Try

        End Function

#End Region

#Region " Private Function "

        Private Function funcPeakValid(ByVal chanel As Channel, ByRef dblYMax As Double, ByVal i As Integer, ByVal inr As Integer) As Boolean
            '=====================================================================
            ' Procedure Name        :   funcPeakValid
            ' Description           :   here chanel is a data structure
            ' Purpose               :   check the peak for valid range to validate
            ' Parameters Passed     :   Channel,i,inr.
            ' Parameters Affected   :   dblYMax As Double
            ' Returns               :   True, if successful.
            ' Parameters Affected   :   None.
            ' Assumptions           :   None.
            ' Dependencies          :   None. 
            ' Author                :   Sachin Dokhale
            ' Created               :   13.12.06
            ' Revisions             :
            '=====================================================================

            Dim dblY As Double
            Dim flag1 As Boolean = False
            Try
                '--- Check the peak for valid range to validate
                If (i - inr >= 0) Then
                    dblY = gFuncGetmv(chanel.Spectrums(0).Readings.item(i).YaxisADCData)
                    'if ( (ymax-(*ymaxmin)) >=100.0) {
                    '		 flag1=TRUE;
                    '		 *ymaxmin = ymax;
                    '		}
                    'If ((dblY - (dblYMax)) >= 100.0) Then
                    If (Math.Abs((dblY - (dblYMax))) >= 50.0) Then
                        'If ((dblY - (dblYMax)) >= 100.0) Then
                        flag1 = True
                        dblYMax = dblY
                    End If
                End If
                Return flag1
            Catch ex As Exception
                '---------------------------------------------------------
                'Error Handling and logging
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = ex.Message
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            Finally
                '---------------------------------------------------------
                'Writing Execution log
                If CONST_CREATE_EXECUTION_LOG = 1 Then
                    gobjErrorHandler.WriteExecutionLog()
                End If
                '---------------------------------------------------------
            End Try
        End Function

        Private Function funcValleyValid(ByVal chanel As Channel, ByRef dblYMin As Double, ByVal i As Integer, ByVal inr As Integer) As Boolean
            '=====================================================================
            ' Procedure Name        :   funcValleyValid
            ' Description           :   
            ' Purpose               :   Validate the Valley value
            ' Parameters Passed     :   Channel,i,inr.
            ' Parameters Affected   :   dblYMax As Double
            ' Returns               :   True, if successful.
            ' Assumptions           :   None.
            ' Dependencies          :   Channel data structure must be loaded. 
            ' Author                :   Sachin Dokhale
            ' Created               :   13.12.06
            ' Revisions             :
            '=====================================================================

            Dim dblY As Double
            Dim flag1 As Boolean = False
            Try
                '--- Check the valley for valid range to validate
                If (i - inr >= 0) Then
                    dblY = gFuncGetmv(chanel.Spectrums(0).Readings.item(i).YaxisADCData)

                    'else if ((*ymaxmin-ymax)>=50.0) {
                    'flag1=TRUE;
                    '*ymaxmin = ymax;
                    If (Math.Abs(dblYMin - dblY) >= 50.0) Then
                        'If ((dblYMin - dblY) >= 50.0) Then
                        flag1 = True
                        dblYMin = dblY
                    End If
                End If

                Return flag1
            Catch ex As Exception
                '---------------------------------------------------------
                'Error Handling and logging
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = ex.Message
                gobjErrorHandler.WriteErrorLog(ex)
                Return False
                '---------------------------------------------------------
            Finally
                '---------------------------------------------------------
                'Writing Execution log
                If CONST_CREATE_EXECUTION_LOG = 1 Then
                    gobjErrorHandler.WriteExecutionLog()
                End If
                '---------------------------------------------------------
            End Try
        End Function

        Private Function funcGetPeak(ByVal Peakchannel As Channel, ByVal i As Integer) As Integer
            'peakvalid(chanel0, &ymx, i, inr, TRUE))
            '=====================================================================
            ' Procedure Name        :   funcGetPeak
            ' Description           :   for getting peak from channel object.
            ' Purpose               :   
            ' Parameters Passed     :   Channel,i.
            ' Returns               :   Integer
            ' Parameters Affected   :   None.
            ' Assumptions           :   Channel must be not empty.
            ' Dependencies          :   None. 
            ' Author                :   Sachin Dokhale
            ' Created               :   13.12.06
            ' Revisions             :
            '=====================================================================
            Try
                Dim k As Integer
                Dim j As Integer
                'Dim maxmin As Integer = 5000
                Dim maxmin As Integer = -1
                j = i
                If (i > 5 And i < Peakchannel.Spectrums.item(0).Readings.Count - 5) Then
                    For k = i - 5 To k < i + 5
                        'if (peak){ for Peak
                        If (Peakchannel.Spectrums.item(0).Readings(k).YaxisADCData > maxmin) Then
                            'maxmin=chanel0[k];
                            'j=k;
                            maxmin = Peakchannel.Spectrums.item(0).Readings(k).YaxisADCData()
                            j = k
                        End If
                    Next
                End If
                i = j
                'if (i>5 && i<addata.counter-10){
                'j=0;
                'for(k=i; k<i+10; k++){
                'if (chanel0[k]==chanel0[k+1])
                'j++;
                'Else
                'break;
                '}
                'j=i+j/2;
                '}
                'Return j
                If (i > 5 And i < Peakchannel.Spectrums.item(0).Readings.Count - 10) Then
                    j = 0
                    For k = i To k <= 10
                        If Peakchannel.Spectrums.item(0).Readings.item(k).YaxisADCData = Peakchannel.Spectrums.item(0).Readings.item(k + 1).YaxisADCData Then
                            j += 1
                        Else
                            Exit For
                        End If
                    Next
                    j = i + j / 2
                End If
                Return j

            Catch ex As Exception
                '---------------------------------------------------------
                'Error Handling and logging
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = ex.Message
                gobjErrorHandler.WriteErrorLog(ex)
                Return 0
                '---------------------------------------------------------
            Finally
                '---------------------------------------------------------
                'Writing Execution log
                If CONST_CREATE_EXECUTION_LOG = 1 Then
                    gobjErrorHandler.WriteExecutionLog()
                End If
                '---------------------------------------------------------
            End Try
        End Function

        Private Function funcGetValley(ByVal Valleychanel As Channel, ByRef dblYMin As Double, ByVal i As Integer, ByVal inr As Integer) As Integer
            '=====================================================================
            ' Procedure Name        :   funcGetValley
            ' Description           :   for getting vally count from channel object.
            ' Purpose               :   
            ' Parameters Passed     :   Valleychanel As Channel, i,inr as integer
            ' Returns               :   Integer
            ' Parameters Affected   :   dblYMin.
            ' Assumptions           :   None.
            ' Dependencies          :   None. 
            ' Author                :   Sachin Dokhale
            ' Created               :   13.12.06
            ' Revisions             :
            '=====================================================================
            Try
                Dim k As Integer
                Dim j As Integer
                Dim maxmin As Integer = 5000
                'Dim maxmin As Integer = -1
                j = i
                If (i > 5 And i < Valleychanel.Spectrums.item(0).Readings.Count - 5) Then
                    For k = i - 5 To k < i + 5
                        'if (peak){ for Peak
                        If (Valleychanel.Spectrums.item(0).Readings(k).YaxisADCData < maxmin) Then
                            'maxmin=chanel0[k];
                            'j=k;
                            maxmin = Valleychanel.Spectrums.item(0).Readings(k).YaxisADCData()
                            j = k
                        End If
                    Next
                End If
                i = j
                'if (i>5 && i<addata.counter-10){
                'j=0;
                'for(k=i; k<i+10; k++){
                'if (chanel0[k]==chanel0[k+1])
                'j++;
                'Else
                'break;
                '}
                'j=i+j/2;
                '}
                'Return j
                If (i > 5 And i < Valleychanel.Spectrums.item(0).Readings.Count - 10) Then
                    j = 0
                    For k = i To k <= 10
                        If Valleychanel.Spectrums.item(0).Readings.item(k).YaxisADCData = Valleychanel.Spectrums.item(0).Readings.item(k + 1).YaxisADCData Then
                            j += 1
                        Else
                            Exit For
                        End If
                    Next
                    j = i + j / 2
                End If
                Return j

            Catch ex As Exception
                '---------------------------------------------------------
                'Error Handling and logging
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = ex.Message
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            Finally
                '---------------------------------------------------------
                'Writing Execution log
                If CONST_CREATE_EXECUTION_LOG = 1 Then
                    gobjErrorHandler.WriteExecutionLog()
                End If
                '---------------------------------------------------------
            End Try
        End Function

#End Region

    End Class
    '--- Channel is the object to hold the entire property of sepctrum.
    <Serializable()> Public Class Channel
        Dim mobjUVSpectrumParameter As UVSpectrumParameter
        Dim mobjEnergySpectrumParameter As EnergySpectrumParameter
        Dim mobjSpectrums As New Spectrums
        Dim mintChannelNo As Integer
        Dim bln_IsEnergySpectrum As Boolean = True
        Dim mobjDigitalSignature As New DigitalSignature
        Private mintInstrumentBeamType As Instrument.enumInstrumentBeamType

        '--- Digital Signature object
        Property DigitalSignature() As DigitalSignature
            Get
                Return mobjDigitalSignature
            End Get
            Set(ByVal Value As DigitalSignature)
                mobjDigitalSignature = Value
            End Set
        End Property

        '--- Parameter object
        Property EnegryParameter() As EnergySpectrumParameter
            Get
                Return mobjEnergySpectrumParameter
            End Get
            Set(ByVal Value As EnergySpectrumParameter)
                mobjEnergySpectrumParameter = Value
            End Set
        End Property

        Property UVParameter() As UVSpectrumParameter
            Get
                Return mobjUVSpectrumParameter
            End Get
            Set(ByVal Value As UVSpectrumParameter)
                mobjUVSpectrumParameter = Value
            End Set
        End Property

        '--- Spectrums collection (col of SpectrumData object)
        Property Spectrums() As Spectrums
            Get
                Return mobjSpectrums
            End Get
            Set(ByVal Value As Spectrums)
                mobjSpectrums = Value
            End Set
        End Property

        '--- Channel No
        Property ChannelNo() As Integer
            Get
                Return mintChannelNo
            End Get
            Set(ByVal Value As Integer)
                mintChannelNo = Value
            End Set
        End Property

        ' Check Spectrum for energy
        Property IsEnergySpectrum() As Boolean
            Get
                Return bln_IsEnergySpectrum
            End Get
            Set(ByVal Value As Boolean)
                bln_IsEnergySpectrum = Value
            End Set
        End Property

        Public Sub New(ByVal blnEnergySpectrum As Boolean)
            If blnEnergySpectrum = True Then
                mobjEnergySpectrumParameter = New EnergySpectrumParameter
                bln_IsEnergySpectrum = True
            Else
                mobjUVSpectrumParameter = New UVSpectrumParameter
                bln_IsEnergySpectrum = False
            End If
            mintInstrumentBeamType = Instrument.enumInstrumentBeamType.SingleBeam
        End Sub

        Property InstrumentBeamType() As Instrument.enumInstrumentBeamType
            Get
                Return mintInstrumentBeamType

            End Get
            Set(ByVal Value As Instrument.enumInstrumentBeamType)
                mintInstrumentBeamType = Value
            End Set
        End Property

    End Class

    '--- This Energy channel object is holds detalis of energy spectrum
    <Serializable()> Public Class EnergyChannels
        Inherits System.Collections.CollectionBase
        Private mobjDigitalSignature As New DigitalSignature

        '--- Item property sets or return a Channel object
        Default Property item(ByVal index As Integer) As Channel
            Get
                Return innerlist.Item(index)
            End Get
            Set(ByVal Value As Channel)
                innerlist.Item(index) = Value
            End Set
        End Property

        '--- you can add only Channel object to this collection
        Sub Add(ByVal value As Channel)
            innerlist.Add(value)
        End Sub

        '--- Digital Signature object
        Property DigitalSignature() As DigitalSignature
            Get
                Return mobjDigitalSignature
            End Get
            Set(ByVal Value As DigitalSignature)
                mobjDigitalSignature = Value
            End Set
        End Property

    End Class

    '--- This channels object is the collection of the channels
    <Serializable()> Public Class Channels
        Inherits System.Collections.CollectionBase


        '--- Item property sets or return a Channel object
        Default Property item(ByVal index As Integer) As Channel
            Get
                Return innerlist.Item(index)
            End Get
            Set(ByVal Value As Channel)
                innerlist.Item(index) = Value
            End Set
        End Property

        '--- you can add only Channel object to this collection
        Sub Add(ByVal value As Channel)
            innerlist.Add(value)
        End Sub

    End Class

    '--- This Readings object is the collection of Data objects
    <Serializable()> Public Class Readings
        Inherits System.Collections.CollectionBase

        '--- Item property sets or return a data object
        Default Property item(ByVal index As Integer) As Data
            Get
                Return innerlist.Item(index)
            End Get
            Set(ByVal Value As Data)
                innerlist.Item(index) = Value
            End Set
        End Property

        '--- you can add only data object to this collection
        Sub Add(ByVal value As Data)
            innerlist.Add(value)
        End Sub
    End Class

    '--- This SpectrumData object is holds the detalis of the Readings object
    <Serializable()> Public Class SpectrumData

        Dim mlngSpectrumColor As Long
        Dim mstrSpectrumName As String
        Dim mobjReadings As New Readings

        Property SpectrumColor() As Long
            Get
                Return mlngSpectrumColor
            End Get
            Set(ByVal Value As Long)
                mlngSpectrumColor = Value
            End Set
        End Property

        Property SpectrumName() As String
            Get
                Return mstrSpectrumName
            End Get
            Set(ByVal Value As String)
                mstrSpectrumName = Value
            End Set
        End Property

        '--- Readings collection stores the data for the spectrum.
        Property Readings() As Readings
            Get
                Return mobjReadings
            End Get
            Set(ByVal Value As Readings)
                mobjReadings = Value
            End Set
        End Property
    End Class

    '--- This Spectrum object is collection of SpectrumData object 
    <Serializable()> Public Class Spectrums
        Inherits System.Collections.CollectionBase
        '--- Item property sets or return a SpectrumData object
        Default Property item(ByVal index As Integer) As SpectrumData
            Get
                Return innerlist.Item(index)
            End Get
            Set(ByVal Value As SpectrumData)
                innerlist.Item(index) = Value
            End Set
        End Property

        '--- you can add only SpectrumData object to this collection
        Sub Add(ByVal value As SpectrumData)
            innerlist.Add(value)
        End Sub

    End Class

    '--- This EnergySpectrumParameter object is holds the details of energy spectrum parameter. 
    '--- i.s. Inst. setting details of that energy spectrum
    <Serializable()> Public Class EnergySpectrumParameter
        'Dim mintSacnMode As Integer
        Dim mintScanSpeed As Double
        Dim mdblPmtV As Double
        Dim mdblPmtV_Ref As Double
        Dim mdblHCLCurr As Double
        Dim mintD2Curr As Integer
        Dim mdblSlitWidth As Double
        Dim mdblSlitWidth_Ref As Double
        Dim mintFualRatio As Double
        Dim mdblBurnerHeight As Double
        Dim mintLampTurrNo As Integer
        Dim mstrLampEle As String
        Dim mintCal_Mode As EnumCalibrationMode
        Dim mdblXaxisMin As Double = 0
        Dim mdblXaxisMax As Double = 0
        Dim mdblYaxisMin As Double = 0
        Dim mdblYaxisMax As Double = 0
        Dim mobjDigitalSignature As New DigitalSignature
        Dim mstrChannelName As String = ""
        Dim mstrAnalysisDate As String = ""
        Dim mstrComments As String = ""


        '--- Channel name    
        Property SpectrumName() As String
            Get
                Return mstrChannelName
            End Get
            Set(ByVal Value As String)
                mstrChannelName = Value
            End Set
        End Property

        '--- Analysis date        
        Property AnalysisDate() As String
            Get
                Return mstrAnalysisDate
            End Get
            Set(ByVal Value As String)
                mstrAnalysisDate = Value
            End Set
        End Property

        '--- Digital Signature object
        Property DigitalSignature() As DigitalSignature
            Get
                Return mobjDigitalSignature
            End Get
            Set(ByVal Value As DigitalSignature)
                mobjDigitalSignature = Value
            End Set
        End Property


        Property Cal_Mode() As Integer
            Get
                Return mintCal_Mode
            End Get
            Set(ByVal Value As Integer)
                mintCal_Mode = Value
            End Set
        End Property

        Property ScanSpeed() As Double
            Get
                Return mintScanSpeed
            End Get
            Set(ByVal Value As Double)
                mintScanSpeed = Value
            End Set
        End Property


        Property XaxisMin() As Double
            Get
                Return mdblXaxisMin
            End Get
            Set(ByVal Value As Double)
                mdblXaxisMin = Value
            End Set
        End Property

        Property XaxisMax() As Double
            Get
                Return mdblXaxisMax
            End Get
            Set(ByVal Value As Double)
                mdblXaxisMax = Value
            End Set
        End Property

        Property YaxisMin() As Double
            Get
                Return mdblYaxisMin
            End Get
            Set(ByVal Value As Double)
                mdblYaxisMin = Value
            End Set
        End Property

        Property YaxisMax() As Double
            Get
                Return mdblYaxisMax
            End Get
            Set(ByVal Value As Double)
                mdblYaxisMax = Value
            End Set
        End Property

        Property PMTV() As Double
            Get
                Return mdblPmtV
            End Get
            Set(ByVal Value As Double)
                mdblPmtV = Value
            End Set
        End Property

        Property PMTV_Ref() As Double
            Get
                Return mdblPmtV_Ref
            End Get
            Set(ByVal Value As Double)
                mdblPmtV_Ref = Value
            End Set
        End Property

        Property HCLCurr() As Double
            Get
                Return mdblHCLCurr
            End Get
            Set(ByVal Value As Double)
                mdblHCLCurr = Value
            End Set
        End Property

        Property D2Curr() As Integer
            Get
                Return mintD2Curr
            End Get
            Set(ByVal Value As Integer)
                mintD2Curr = Value
            End Set
        End Property

        Property SlitWidth() As Double
            Get
                Return mdblSlitWidth
            End Get
            Set(ByVal Value As Double)
                mdblSlitWidth = Value
            End Set
        End Property

        Property SlitWidthRef() As Double
            Get
                Return mdblSlitWidth_Ref
            End Get
            Set(ByVal Value As Double)
                mdblSlitWidth_Ref = Value
            End Set
        End Property

        Property FualRatio() As Integer
            Get
                Return mintFualRatio
            End Get
            Set(ByVal Value As Integer)
                mintFualRatio = Value
            End Set
        End Property

        Property BurnerHeight() As Double
            Get
                Return mdblBurnerHeight
            End Get
            Set(ByVal Value As Double)
                mdblBurnerHeight = Value
            End Set
        End Property

        Property LampTurrNo() As Integer
            Get
                Return mintLampTurrNo
            End Get
            Set(ByVal Value As Integer)
                mintLampTurrNo = Value
            End Set
        End Property

        Property LampEle() As String
            Get
                Return mstrLampEle
            End Get
            Set(ByVal Value As String)
                mstrLampEle = Value
            End Set
        End Property

        Property Comments() As String
            Get
                Return mstrComments
            End Get
            Set(ByVal Value As String)
                mstrComments = Value
            End Set
        End Property

    End Class

    '--- This UVSpectrumParameter object is holds the details of UV spectrum parameter. 
    '--- i.s. Inst. setting details of that UV spectrum
    <Serializable()> Public Class UVSpectrumParameter
        Dim mintScanSpeed As Double
        Dim mdblPmtV As Double
        Dim mdblPmtV_Ref As Double
        Dim mintD2Curr As Integer
        Dim mdblSlitWidth As Double
        Dim mdblSlitWidth_Ref As Double
        Dim mintCal_Mode As EnumCalibrationMode
        Dim mdblXaxisMin As Double = 0
        Dim mdblXaxisMax As Double = 0
        Dim mdblYaxisMin As Double = 0
        Dim mdblYaxisMax As Double = 0
        Dim mobjDigitalSignature As New DigitalSignature
        Dim mstrChannelName As String = ""
        Dim mstrAnalysisDate As String = ""
        Dim mstrComments As String = ""
        Dim mblnUVABS As Boolean = True
        Dim mblnIsBaseline As Boolean = False



        '--- Channel name    
        Property SpectrumName() As String
            Get
                Return mstrChannelName
            End Get
            Set(ByVal Value As String)
                mstrChannelName = Value
            End Set
        End Property

        '--- Analysis date        
        Property AnalysisDate() As String
            Get
                Return mstrAnalysisDate
            End Get
            Set(ByVal Value As String)
                mstrAnalysisDate = Value
            End Set
        End Property

        '--- Digital Signature object
        Property DigitalSignature() As DigitalSignature
            Get
                Return mobjDigitalSignature
            End Get
            Set(ByVal Value As DigitalSignature)
                mobjDigitalSignature = Value
            End Set
        End Property

        Property Cal_Mode() As Integer
            Get
                Return mintCal_Mode
            End Get
            Set(ByVal Value As Integer)
                mintCal_Mode = Value
            End Set
        End Property

        Property ScanSpeed() As Double
            Get
                Return mintScanSpeed
            End Get
            Set(ByVal Value As Double)
                mintScanSpeed = Value
            End Set
        End Property


        Property XaxisMin() As Double
            Get
                Return mdblXaxisMin
            End Get
            Set(ByVal Value As Double)
                mdblXaxisMin = Value
            End Set
        End Property

        Property XaxisMax() As Double
            Get
                Return mdblXaxisMax
            End Get
            Set(ByVal Value As Double)
                mdblXaxisMax = Value
            End Set
        End Property

        Property YaxisMin() As Double
            Get
                Return mdblYaxisMin
            End Get
            Set(ByVal Value As Double)
                mdblYaxisMin = Value
            End Set
        End Property

        Property YaxisMax() As Double
            Get
                Return mdblYaxisMax
            End Get
            Set(ByVal Value As Double)
                mdblYaxisMax = Value
            End Set
        End Property

        Property PMTV() As Double
            Get
                Return mdblPmtV
            End Get
            Set(ByVal Value As Double)
                mdblPmtV = Value
            End Set
        End Property

        Property PMTV_Ref() As Double
            Get
                Return mdblPmtV_Ref
            End Get
            Set(ByVal Value As Double)
                mdblPmtV_Ref = Value
            End Set
        End Property


        Property D2Curr() As Integer
            Get
                Return mintD2Curr
            End Get
            Set(ByVal Value As Integer)
                mintD2Curr = Value
            End Set
        End Property

        Property SlitWidth() As Double
            Get
                Return mdblSlitWidth
            End Get
            Set(ByVal Value As Double)
                mdblSlitWidth = Value
            End Set
        End Property

        Property SlitWidth_Ref() As Double
            Get
                Return mdblSlitWidth_Ref
            End Get
            Set(ByVal Value As Double)
                mdblSlitWidth_Ref = Value
            End Set
        End Property



        Property Comments() As String
            Get
                Return mstrComments
            End Get
            Set(ByVal Value As String)
                mstrComments = Value
            End Set
        End Property

        Property UVABS() As Boolean
            Get
                Return mblnUVABS
            End Get
            Set(ByVal Value As Boolean)
                mblnUVABS = Value
            End Set
        End Property

        Property IsBaseline() As Boolean
            Get
                Return mblnIsBaseline
            End Get
            Set(ByVal Value As Boolean)
                mblnIsBaseline = Value
            End Set
        End Property

    End Class

    '--- This Data object is holds the reading details of the instrument
    <Serializable()> Public Class Data
        Dim mdblXaxisData As Double
        Dim mdblYaxisData As Double
        Dim mdblYaxisADCData As Double
        Dim mblnGraphPlotted As Boolean = False

        Property GraphPloted() As Boolean
            Get
                Return mblnGraphPlotted
            End Get
            Set(ByVal Value As Boolean)
                mblnGraphPlotted = Value
            End Set
        End Property

        Property XaxisData() As Double
            Get
                Return mdblXaxisData
            End Get
            Set(ByVal Value As Double)
                mdblXaxisData = Value
            End Set
        End Property

        Property YaxisData() As Double
            Get
                Return mdblYaxisData
            End Get
            Set(ByVal Value As Double)
                mdblYaxisData = Value
            End Set
        End Property

        Property YaxisADCData() As Double
            Get
                Return mdblYaxisADCData
            End Get
            Set(ByVal Value As Double)
                mdblYaxisADCData = Value
            End Set
        End Property
    End Class

End Namespace






