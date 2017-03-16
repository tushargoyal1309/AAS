Imports BgThread
Imports AAS203.Common
Imports AAS203Library
Imports AAS203Library.Analysis

Public Class clsBgReadData
    Implements BgThread.IBgWorker

#Region " Private Member Variables "

    Private objAnalysisRawData As clsRawData
    Private mobjThreadController As IBgThread
    Private mobjCurrentSample As Method.clsAnalysisSampleParameters
    Private mobjCurrentStandard As Method.clsAnalysisStdParameters
    Private Xtime As Double
    Private Xtime_temp As Double = 0
    Private mintSampleType As Analysis.clsRawData.enumSampleType
    Private mdblUVAbsorbance As Double
    Private mintRunNumberIndex As Integer

#End Region

#Region "Private Member Variables"

    Public CStart As Integer
    Public CEndTime As Integer
    Public Filter_flag As Boolean
    Public lPipe As Integer = 0
    Public Wlen As Integer = 801
    Public Const FILTMAX = 1001
    Public FiltPipe(FILTMAX) As Double
    Public Event AbsorbanceValueChanged(ByVal dblAbs As Double)
    Public Event AspirationMessageChanged(ByVal strNewMessage As String, ByVal blnIsBlink As Boolean)
    Public IsAlt_S_Pressed As Boolean

#End Region

#Region " Public Properties "

    Public Property SampleType() As Analysis.clsRawData.enumSampleType
        Get
            Return mintSampleType
        End Get
        Set(ByVal Value As Analysis.clsRawData.enumSampleType)
            mintSampleType = Value
        End Set
    End Property

    Public Property UVAbsorbance() As Double
        Get
            Return mdblUVAbsorbance
        End Get
        Set(ByVal Value As Double)
            mdblUVAbsorbance = Value
        End Set
    End Property

#End Region

#Region " Constructors "

    Public Sub New()
        '=====================================================================
        ' Procedure Name        : New 
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To initialize the class instance
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 18-Jan-2007 10:30 am
        ' Revisions             : 1
        '=====================================================================
        Try
            If gobjNewMethod.QuantitativeDataCollection.Count > 0 Then
                mintRunNumberIndex = gobjNewMethod.QuantitativeDataCollection.Count - 1
            Else
                mintRunNumberIndex = 0
            End If

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
    End Sub

    Public Sub New(ByVal intStartTime As Integer, ByVal intEndTime As Integer, ByVal intSampleType As clsRawData.enumSampleType, _
                   ByVal objCurStd As Method.clsAnalysisStdParameters, _
                   ByVal objCurSample As Method.clsAnalysisSampleParameters)
        '=====================================================================
        ' Procedure Name        : New 
        ' Parameters Passed     : intStartTime,intEndTime,intSampleType
        '                         objCurStd,objCurSample
        ' Returns               : None
        ' Purpose               : To initialize the class instance
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 18-Jan-2007 10:30 am
        ' Revisions             : 1
        '=====================================================================
        Try
            If gobjNewMethod.QuantitativeDataCollection.Count > 0 Then
                mintRunNumberIndex = gobjNewMethod.QuantitativeDataCollection.Count - 1
            Else
                mintRunNumberIndex = 0
            End If

            mintSampleType = intSampleType
            mobjCurrentStandard = objCurStd
            mobjCurrentSample = objCurSample

            '--- Added by Sachin Dokhale on 08.05.07
            CEndTime = intEndTime
            CStart = intStartTime
            '---

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
    End Sub

#End Region

#Region " Background Thread Worker functions "

    Public Sub Initialize(ByVal Controller As BgThread.IBgThread) Implements BgThread.IBgWorker.Initialize
        '=====================================================================
        ' Procedure Name        : Initialize
        ' Parameters Passed     : Controller As BgThread.IBgThread
        ' Returns               : None
        ' Purpose               : To Initialize the worker thread
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 26-Dec-2006
        ' Revisions             : 1
        '=====================================================================
        Try
            mobjThreadController = Controller

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
    End Sub

    Public Sub Work() Implements BgThread.IBgWorker.Start
        '=====================================================================
        ' Procedure Name        : Work
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To work the process in background thread
        ' Description           : Implements Start Method of IBgWorker interface
        '                         to actually place the BgThread Process.
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 26-Dec-2006
        ' Revisions             : 1
        '=====================================================================
        Dim strPreviousStatusMessage As String
        Try
            If gblnShowThreadOnfrmMDIStatusBar Then
                strPreviousStatusMessage = gobjMain.StatusBar1.Text
                gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage & " Reading Data.. Please Wait.."
                Application.DoEvents()
            End If

            If gintInstrumentBeamType = Instrument.enumInstrumentBeamType.DoubleBeam Then
                '---In blank aspiration the values are to be manipulated so that it shows zero.
                '---For every blank aspiration stage a very first command 
                '---to be given to instrument is "GET_Absoffset"
                If gobjInst.Mode = EnumCalibrationMode.AA Then
                    If Me.SampleType = clsRawData.enumSampleType.BLANK Then
                        Call gobjCommProtocol.funcGetAbsOffset()
                    End If
                End If
            End If

            If (gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS) Then
                '---Read data from UV Mode
                Call Read_Quant_Data_UV_Mode(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.IntegrationTime)
            Else
                If (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.MeasurementMode = enumMeasurementMode.Integrate) Then
                    '---Read data for Measurement Mode is Integration
                    '---Wait for analysis for perticulor time.
                    If Not (Filter_flag) Then
                        Call Wait_For_Analysis(2)
                    Else
                        Call Wait_For_Analysis(2)
                    End If
                    Call Read_Quant_Data_Integration_Mode(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.IntegrationTime)
                ElseIf (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.MeasurementMode = enumMeasurementMode.PeakArea Or _
                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.MeasurementMode = enumMeasurementMode.PeakHeight) Then
                    '---Read data for Measurement Mode is peak height or peak area.
                    Call Read_Quant_Data_PkHt_Area_Mode(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.IntegrationTime)
                End If
            End If

            If mobjThreadController.Running = True Then
                mobjThreadController.Completed(False)
            Else
                mobjThreadController.Completed(True)
            End If
            Application.DoEvents()

            If gblnShowThreadOnfrmMDIStatusBar Then
                gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage
                Application.DoEvents()
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            mobjThreadController.Failed(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

#End Region

#Region " Private functions "

    Private Sub Wait_For_Analysis(ByVal intWaitTime As Integer)
        '=====================================================================
        ' Procedure Name        : Wait_For_Analysis
        ' Parameters Passed     : intWaitTime in integer
        ' Returns               : None
        ' Purpose               : Wait for analysis
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 26-Dec-2006
        ' Revisions             : 1
        '=====================================================================
        'void	Wait_For_Analysis(HWND hwnd, int time)
        '{
        '   char	str[40]="";
        '   double	abs=0.0;
        '   int		t=0;
        '   clock_t	CStart, CEnd;
        '   CStart=CEnd=clock();
        '   ShowAspMessage("Waiting for Stability");
        '   do
        '   {
        '	    t++;
        '	    if (t%500==0)
        '       {
        '	        abs = Get_Reading();
        '	        GetValInString(abs, str, Method->Mode);
        '	        SetDlgItemText(hwnd,IDC_QAABS, str);
        '       }
        '	    CEnd = clock();
        '	    if ((CEnd-CStart) >= (time * CLK_TCK))
        '	        break;
        '   } while (1);
        '   ShowAspMessage("Reading Wait ...");
        '}

        Dim str As String = ""
        Dim dblabs As Double = 0.0
        Dim int_t As Integer = 0
        Dim lngCStart, lngCEnd As Long

        Try
            '--- init time variable
            lngCStart = 0
            lngCEnd = 0
            '--- Raise event to show the message for "Waiting for Stability"
            RaiseEvent AspirationMessageChanged("Waiting for Stability", False)

            '---delay added before readdata as suggested by mr. vck
            '---by deepak on 29.01.08
            Call gobjCommProtocol.mobjCommdll.subTime_Delay(2700)
            Call Application.DoEvents()

            Do
                int_t += 1
                If ((int_t Mod 500) = 0) Then
                    dblabs = gobjClsAAS203.Get_Reading(SampleType, mobjCurrentStandard, Filter_flag, mobjCurrentSample)
                    RaiseEvent AbsorbanceValueChanged(dblabs)
                End If

                lngCEnd += 50
                '--- Exit from time event
                If ((lngCEnd - CStart) >= (intWaitTime * 1000)) Then
                    Exit Do
                End If
                '--- Set delay for time
                Call gobjCommProtocol.mobjCommdll.subTime_Delay(intWaitTime)
            Loop While (1)

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
    End Sub

    Private Function Read_Quant_Data_Integration_Mode(ByVal intIntegrationTimeIn As Integer) As Boolean
        '=====================================================================
        ' Procedure Name        : Read_Quant_Data_Integration_Mode
        ' Parameters Passed     : intIntegrationTimeIn as inetgration time in integer
        ' Returns               : return true if success.
        ' Purpose               : Read the data from instument in integration mode
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 26-Dec-2006
        ' Revisions             : 1
        '=====================================================================
        'void	Read_Quant_Data_Integration_Mode(HWND hwnd, HDC hdc, CURVEDATA *AnaGraph)
        '{
        '   double	xtime1=0;
        '   char	str[40]="";
        '   RAW_DATA_NODE   DataNode;
        '   RAW_DATA_STRUCT Data;
        '   double	abs=0.0,asum =0.0;
        '   int		aread_count=0; 
        '   int		CEndTime;
        '   clock_t	CStart, CEnd, CEnd1,CEnd2;
        '   InitRawDataNode(&DataNode);
        '   DataNode.SampType=SampType;
        '   if (SampType==STD)
        '   {
        '	    if (CurStd!=NULL)
        '       {
        '	        DataNode.Nstd = CurStd->Data.StdNo;
        '	        strcpy(DataNode.SampName,CurStd->Data.Std_Name);
        '	    }
        '   }
        '   else if (SampType==SAMP)
        '   {
        '	    if (CurSamp!=NULL)
        '       {
        '		    DataNode.Nstd =CurSamp->Data.SampNo;
        '		    strcpy(DataNode.SampName,CurSamp->Data.Samp_Name);
        '	    }
        '   }
        '   AddRawData(&DataNode);
        '   xtime1 = Xtime;
        '   if (Filter_flag)
        '   {
        '	    FiltRead();
        '	    InitSmooth(hwnd);
        '   }
        '   CEndTime = (int) ((double) Method->QuantData->Param.Int_Time * (double) CLK_TCK);
        '   CEnd2=CEnd1=CStart=CEnd=clock();
        '   do
        '   {
        '       abs = Get_Reading();
        '	    if (Filter_flag)
        '       {
        '	        abs=Get_Filtered(abs);
        '           If (checkmindetect) Then
        '	        {
        '	            abs = CheckForMinAbsLevel(abs); 
        '	        }
        '	        aread_count=0;
        '       }
        '	    else
        '       {
        '	        asum += abs;
        '	        aread_count++;
        '	    }
        '	    CEnd=clock();
        '	    if (CEnd != CEnd1 )
        '       {
        '           If (aread_count > 0) Then
        '		        abs = asum/aread_count;
        '           aread_count=0;
        '	        asum=0;
        '           If (checkmindetect) Then
        '	        {        
        '	            abs=CheckForMinAbsLevel(abs); 
        '	        }
        '	        Xtime += ( ((double)(CEnd-CEnd1)/(double) CLK_TCK));
        '	        CEnd1 = CEnd;
        '	        InitRawDataStruct(&Data);
        '	        Data.Xval = Xtime; 
        '           Data.Abs  = abs;
        '	        AddRawDataItems(&Data);
        '	        if (Xtime>=AnaGraph->Xmax)
        '           {
        '		        AnaGraph->Xmin += Method->QuantData->Param.Int_Time;
        '		        AnaGraph->Xmax += Method->QuantData->Param.Int_Time;
        '		        Calculate_Analysis_Graph_Param(AnaGraph);
        '		        InvalidateRect(hwnd, NULL, FALSE);
        '		        UpdateWindow(hwnd);
        '		        Afirst=TRUE;
        '		        Xoldt=-1;Yoldt=-1;
        '		        CEnd1 = clock();
        '		        CStart += (CEnd1-CEnd);
        '		    }
        '	        if (Afirst)
        '           {
        '		        PlotInit(hdc, Xtime, abs, AnaGraph->RC, AnaGraph);
        '		        Afirst=FALSE;
        '		    }
        '           Else
        '		        Plotg(hdc, Xtime, abs, AnaGraph->RC, AnaGraph);
        '       }
        '	    if ( (CEnd-CStart) % (Method->QuantData->Param.Int_Time) == 0 && CEnd2 != CEnd1)
        '       {
        '	        CEnd2=CEnd1;
        '	        GetValInString(abs, str, Method->Mode);
        '	        SetDlgItemText(hwnd,IDC_QAABS, str);
        '	    }
        '       CEnd = clock();
        '       If ((CEnd - CStart) >= CEndTime) Then
        '	        break;
        '   } while (1);
        '   Xtime = xtime1 + (double) Method->QuantData->Param.Int_Time;
        '}

        Dim xtime1 As Double
        Dim str As String
        Dim abs, asum As Double
        Dim aread_count As Integer
        Dim intEndTime As Integer
        Dim CStart, CEnd, CEnd1, CEnd2 As Long
        Dim strData As String
        Dim objRawDataReading As Analysis.clsRawDataReadings.RAW_DATA
        Dim avgabs As Double
        Dim blnIsFirstRead As Boolean = True
        Try
            objAnalysisRawData = New clsRawData

            '---Set X time
            Xtime = Me.CEndTime
            xtime1 = Xtime
            '---Check Flter Setting for fliter Reading and init. smoothing data
            If (Filter_flag) Then
                FiltRead()
                InitSmooth()
            End If
            '---Reading wait for a time
            RaiseEvent AspirationMessageChanged("Reading Wait ...", False)

            '---delay added before readdata as suggested by mr. vck
            '---by deepak on 29.01.08
            'Call gobjCommProtocol.mobjCommdll.subTime_Delay(1350)
            'Call Application.DoEvents()

            intEndTime = intIntegrationTimeIn * 1000

            CEnd2 = 0
            CEnd1 = 0
            CStart = 0
            CEnd = 0

            Do
                objRawDataReading = New Analysis.clsRawDataReadings.RAW_DATA

                '---Read Abs Value from instrument 
                abs = gobjClsAAS203.Get_Reading(mintSampleType, mobjCurrentStandard, Filter_flag, mobjCurrentSample)
                '---Check for filter settng for abs.
                If (Filter_flag) Then
                    abs = Get_Filtered(abs)
                    '---Validate abs value
                    If (gstructSettings.SetMinAbsLimit) Then
                        abs = gobjClsAAS203.CheckForMinAbsLevel(abs)
                    End If
                    aread_count = 0
                Else
                    asum += abs
                    aread_count += 1
                End If

                CEnd += 50

                '---Check timer
                If (CEnd <> CEnd1) Then
                    If (aread_count > 0) Then
                        abs = asum / aread_count
                    End If
                    aread_count = 0
                    asum = 0
                    '---Validate abs value
                    If (gstructSettings.SetMinAbsLimit) Then
                        abs = gobjClsAAS203.CheckForMinAbsLevel(abs)
                    End If

                    Xtime += (CEnd - CEnd1) / 1000

                    CEnd1 = CEnd

                    strData = ""
                    strData = Xtime & "," & abs
                    
                    objRawDataReading.Absorbance = abs
                    objAnalysisRawData.Readings.Add(objRawDataReading)

                    Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
                    Call Application.DoEvents()
                End If
                

                '---get average of raw data
                avgabs = GetAvgValOfAnalysis(objAnalysisRawData)
                If blnIsFirstRead = True Then
                    'strData = Me.CEndTime & "," & avgabs
                    Call mobjThreadController.Display(Me.CEndTime & "," & abs & "," & avgabs)
                    blnIsFirstRead = False
                End If

                strData = strData & "," & avgabs
                Call mobjThreadController.Display(strData)

                If ((CEnd - CStart) Mod (intIntegrationTimeIn) = 0 And CEnd2 <> CEnd1) Then
                    CEnd2 = CEnd1
                    RaiseEvent AbsorbanceValueChanged(abs)
                End If

                CEnd += 100

                If ((CEnd - CStart) >= intEndTime) Then
                    RaiseEvent AspirationMessageChanged("Reading Completed ...", True)
                    Exit Do
                End If

            Loop While True

            Xtime = xtime1 + intIntegrationTimeIn
            '--- Added by Sachin Dokhale 
            strData = ""
            strData = Xtime & "," & avgabs & "," & avgabs
            'strData = strData & "," & avgabs
            Call mobjThreadController.Display(strData)
            '---
            Me.CEndTime = Xtime
            Application.DoEvents()
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

    Private Sub InitSmooth()
        '=====================================================================
        ' Procedure Name        : InitSmooth
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : Init data for smoothing
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 26-Dec-2006
        ' Revisions             : 1
        '=====================================================================
        'void	InitSmooth(HWND hwnd)
        '{
        'char		str[15]="";
        'double  	abs1=0.0;
        'int		count, count1;
        '#define	IVAL	3

        'ShowAspMessage("Waiting for Stability");
        'lPipe=0;

        'for(count=0;count<Wlen-1; count+=IVAL)
        '{
        '   abs1 = Get_Reading();
        '	for(count1=0; count1<IVAL; count1++)
        '   {
        '	    FiltPipe[lPipe++]=abs1;
        '       If (lPipe >= Wlen - 1) Then
        '		    break;
        '	}
        '	GetValInString(abs1, str, Method->Mode);
        '	SetDlgItemText(hwnd,IDC_QAABS, str);
        '   If (lPipe >= Wlen - 1) Then
        '	    break;
        '}
        'ShowAspMessage("Reading Wait ...");
        '}

        Dim str As String = ""
        Dim dblabs1 As Double = 0.0
        Dim intcount, intcount1 As Integer
        Const IVAL = 3
        Try
            lPipe = 0
            intcount = 0
            Do While (True)
                dblabs1 = gobjClsAAS203.Get_Reading(mintSampleType, mobjCurrentStandard, Filter_flag, mobjCurrentSample)

                For intcount1 = 0 To IVAL - 1
                    FiltPipe(lPipe + 1) = dblabs1
                    lPipe += 1
                    If (lPipe >= Wlen - 1) Then
                        Exit For
                    End If
                Next intcount1

                RaiseEvent AbsorbanceValueChanged(dblabs1)

                If (lPipe >= Wlen - 1) Then
                    Exit Do
                End If

                intcount += IVAL
                If intcount >= Wlen - 1 Then Exit Do
            Loop
            Application.DoEvents()

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
    End Sub

    Private Sub FiltRead()
        '=====================================================================
        ' Procedure Name        : FiltRead
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : Read the filter setting
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 26-Dec-2006
        ' Revisions             : 1
        '=====================================================================
        'void(FiltRead(void))
        '{
        'char	str[128];
        'GetProfileStringFromIniFile("Filter Setting", "Filter Window Size" ,"201", str, "aas.ini");
        'Wlen = atoi(str)
        'if (Wlen<20 || Wlen>FILTMAX-1)
        'Wlen=201;
        '}

        Try
            '---get filter window size
            Wlen = gstructSettings.Filter_Window_Size

            '---validate filter window size
            If (Wlen < 20 Or Wlen > FILTMAX - 1) Then
                Wlen = 201
            End If
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
    End Sub

    Private Function Get_Filtered(ByVal Y1 As Double) As Double
        '=====================================================================
        ' Procedure Name        : Get_Filtered
        ' Parameters Passed     : Y1 axis data 
        ' Returns               : Double
        ' Purpose               : return the filtered data
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 26-Dec-2006
        ' Revisions             : 1
        '=====================================================================
        'double Get_Filtered(double y1)
        '{
        'int	i;
        'double  sy=0, sc=0, y2=0.0, tol=0.09;
        'sy=y1;
        'if (lPipe<Wlen-1)
        '{
        '   FiltPipe[lPipe]=y1;
        '	lPipe++;
        '}
        'else
        '{
        '   if (lPipe>Wlen+99)
        '   {
        '	    sy=0;
        '		for(i=0; i<Wlen-1; i++)
        '		    sy+= FiltPipe[i];
        '		 sy/=(double) i;
        '		 if (Method->Mode==MODE_AA || Method->Mode==MODE_AABGC)
        '		    tol=(double) 0.09;
        '		 else if (Method->Mode==MODE_EMISSION)
        '		    tol=(double) 8.0;
        '		 if (fabs(sy-y1)>tol)
        '        {
        '		    lPipe=0;
        '		 	return y1;
        '		 }
        '	}
        '	sy=0.0;
        '	for(i=0; i<Wlen-2; i++)
        '	    FiltPipe[i]=FiltPipe[i+1];
        '	FiltPipe[i] =y1;
        '	for(i=0; i<Wlen-1; i++)
        '   {
        '	    y2 = FnHamming(i);
        '		sy+= (y2*FiltPipe[Wlen-i-1]);
        '		sc+=y2;
        '	}
        '   If (sc! = 0.0) Then
        '	    sy/=sc;
        '	lPipe++;
        '}
        'sy  = GetValConvertedTo( sy, Method->Mode);
        'return sy;
        '}

        Dim i As Integer
        Dim sy As Double = 0
        Dim sc As Double = 0
        Dim y2 As Double = 0.0
        Dim tol As Double = 0.09
        Try
            sy = Y1

            If (lPipe < Wlen - 1) Then
                FiltPipe(lPipe) = Y1
                lPipe += 1
            Else
                If (lPipe > Wlen + 99) Then
                    sy = 0
                    'For i = 0 To i < Wlen - 1
                    For i = 0 To Wlen - 2
                        sy += FiltPipe(i)
                    Next i
                    sy /= i
                    If (gobjNewMethod.OperationMode = EnumOperationMode.MODE_AA Or _
                        gobjNewMethod.OperationMode = EnumOperationMode.MODE_AABGC) Then
                        tol = 0.09
                    ElseIf (gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION) Then
                        tol = 8.0
                        'If (Math.Abs(sy - Y1) > tol) Then
                        '    lPipe = 0
                        '    Return Y1
                        'End If
                    End If
                    If (Math.Abs(sy - Y1) > tol) Then
                        lPipe = 0
                        Return Y1
                    End If

                    sy = 0.0
                End If
                'For i = 0 To i < Wlen - 2
                For i = 0 To Wlen - 3
                    FiltPipe(i) = FiltPipe(i + 1)
                Next i

                FiltPipe(i) = Y1
                'For i = 0 To i < Wlen - 1
                For i = 0 To Wlen - 2
                    y2 = FnHamming(i)
                    sy += (y2 * FiltPipe(Wlen - i - 1))
                    sc += y2
                Next i
                If (sc <> 0.0) Then
                    sy /= sc
                End If
                lPipe += 1
            End If
            
            Return sy
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

    Private Function FnHamming(ByVal n As Integer) As Double
        '=====================================================================
        ' Procedure Name        : FnHamming
        ' Parameters Passed     : n as integer
        ' Returns               : Double
        ' Purpose               : Get calculated value
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 26-Dec-2006
        ' Revisions             : 1
        '=====================================================================
        'double	FnHamming(int	n)
        '{
        'double val=0.0;
        ' val = (double)0.54-(double)0.46* cos((double)(2.0* M_PI * (double)n/ (double)(Wlen-1)));
        ' return val;
        '}

        Dim val As Double = 0.0
        Try
            'val = (double)0.54-(double)0.46* cos((double)(2.0 * M_PI * (double)n/ (double)(Wlen-1)));
            val = 0.54 - 0.46 * Math.Cos((2.0 * Math.PI * n / (Wlen - 1)))
            Return val
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return 0.0
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

    Private Function Read_Quant_Data_UV_Mode(ByVal intIntegrationTimeIn As Integer) As Boolean
        '=====================================================================
        ' Procedure Name        : Read_Quant_Data_UV_Mode
        ' Parameters Passed     : intIntegrationTimeIn as inetgration time in integer
        ' Returns               : return true if success.
        ' Purpose               : Read the data from instument in integration mode
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 24-Jan-2007 06:25 pm
        ' Revisions             : 1
        '=====================================================================
        'void	Read_Quant_Data_UV_Mode(HWND hwnd)
        '{
        '   char		str[80]="";
        '	char        str1[20]="";
        '	double		abs=0.0,asum =0.0, blankabs;
        '	int			aread_count=0; 
        '	int		    CEndTime;
        '	clock_t		CStart, CEnd, CEnd1,CEnd2;
        '	static		int	 Blankval=2047;
        '	int			sampval;

        '	CEndTime = (int) ((double) Method->QuantData->Param.Int_Time * (double) CLK_TCK);
        '	CEnd2=CEnd1=CStart=CEnd=clock();

        '   Do
        '	{
        '		sampval = adcscan();
        '       #If QDEMO Then
        '		    if (SampType==BLANK)
        '			    sampval=4000+random(20);
        '       #End If
        '		abs = GetEnergy(sampval); 
        '		if (SampType==BLANK)
        '		    Blankval = sampval;
        '		blankabs = GetEnergy(Blankval);
        '		if (blankabs!= (double) 0.0)
        '			abs = abs*(double) 100.0/blankabs;
        '		if (abs> (double) 0.0 && abs<(double) 300.0)
        '		{
        '			abs = 2.0 -log10(abs);
        '			asum += abs;
        '			aread_count++;
        '		}
        '		CEnd=clock();
        '       If (CEnd != CEnd1) Then
        '		{
        '           If (aread_count > 0) Then
        '				abs = asum/aread_count;

        '           If (checkmindetect) Then
        '				abs = CheckForMinAbsLevel(abs);

        '			CEnd1 = CEnd;
        '			strcpy(str,"Abs ");
        '			StoreAbsAccurate(abs,str1);
        '			strcat(str,str1);
        '			SetWindowText(GetDlgItem(hwnd, IDC_UVABS), str);
        '		}
        '		if ( (CEnd-CStart) % (Method->QuantData->Param.Int_Time)==0 && CEnd2!=CEnd1)
        '		{
        '			CEnd2=CEnd1;
        '			GetValInString(abs, str, Method->Mode);
        '			SetDlgItemText(hwnd,IDC_QAABS, str);
        '		}
        '		CEnd = clock();
        '       If ((CEnd - CStart) >= CEndTime) Then
        '			break;
        '	}
        '	while (1);
        '   If (aread_count > 0) Then
        '	{
        '	    abs = asum/aread_count;

        '       If (checkmindetect) Then
        '		    abs = CheckForMinAbsLevel(abs);
        '		StoreCalculateDisplayQuantValueUvMode(hwnd, abs);
        '	}
        '}
        '************************************************************
        Dim abs, asum, blankabs As Double
        Dim aread_count, sampval As Integer
        Static Blankval As Integer = 2047
        Dim intCEndTime As Integer
        Dim CStart, CEnd, CEnd1, CEnd2 As Long

        Try
            '---Read the data for UV quant data
            '---Set Time variable with integration time
            intCEndTime = intIntegrationTimeIn * 1000

            CEnd2 = 0
            CEnd1 = 0
            CStart = 0
            CEnd = 0

            Do While (True)
                If mobjThreadController.Running Then
                    'If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
                    If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                        (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                        (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                        '---pass the Filter flag and Sample data type to the analysis data read (scan) function
                        '//--- modified by Sachin Dokhale 06.06.08
                        'sampval = gobjClsAAS203.ADCScan(Filter_flag, SampleType)
                        Dim objRamdom As New Random(20)
                        sampval = 4000 + objRamdom.Next(5, 100)
                        '//---
                    Else
                        '//--- modified by Sachin Dokhale 06.06.08
                        'Dim objRamdom As New Random(20)
                        'sampval = 4000 + objRamdom.Next(5, 100)
                        sampval = gobjClsAAS203.ADCScan(Filter_flag, SampleType)
                        '//---
                    End If

                    '#If QDEMO Then
                    'If (SampleType = clsRawData.enumSampleType.BLANK) Then
                    'Dim objRamdom As New Random(20)
                    'sampval = 4000 + objRamdom.Next(5, 100)   'Rnd(20)
                    'End If
                    '#End If

                    '---Convert sample value (ADC) to the Energy
                    abs = gFuncGetEnergy(sampval)

                    If (SampleType = clsRawData.enumSampleType.BLANK) Then
                        Blankval = sampval
                    End If

                    '---Convert blank value (ADC) to then Energy
                    blankabs = gFuncGetEnergy(Blankval)
                    '---Cal. actual energy
                    If (blankabs <> 0.0) Then
                        abs = abs * 100.0 / blankabs
                    End If

                    If (abs > 0.0 And abs < 300.0) Then
                        abs = 2.0 - Math.Log10(abs)
                        asum += abs
                        aread_count += 1
                    End If

                    CEnd += 50

                    If (CEnd <> CEnd1) Then
                        If (aread_count > 0) Then
                            abs = asum / aread_count
                        End If
                        If (gstructSettings.SetMinAbsLimit) Then
                            abs = gobjClsAAS203.CheckForMinAbsLevel(abs)
                        End If
                        CEnd1 = CEnd
                        'StoreAbsAccurate(abs,str1);
                        'strcat(str,str1);
                        'SetWindowText(GetDlgItem(hwnd, IDC_UVABS), str);
                        '---display absorbance value
                        mobjThreadController.Display(abs)
                        gobjCommProtocol.mobjCommdll.subTime_Delay(50)
                        Application.DoEvents()
                    End If

                    If ((CEnd - CStart) Mod (intIntegrationTimeIn) = 0 And CEnd2 <> CEnd1) Then
                        CEnd2 = CEnd1
                        'GetValInString(abs, str, Method->Mode);
                        'SetDlgItemText(hwnd,IDC_QAABS, str);
                        '---Raise event to display data on label
                        RaiseEvent AbsorbanceValueChanged(abs)
                    End If

                    CEnd += 50
                    '---Exit from loop when time is expired
                    If ((CEnd - CStart) >= intCEndTime) Then
                        Exit Do
                    End If
                Else
                    RaiseEvent AspirationMessageChanged("Reading failed ...", True)
                    Exit Do
                End If
            Loop

            If (aread_count > 0) Then
                abs = asum / aread_count
                If (gstructSettings.SetMinAbsLimit) Then
                    abs = gobjClsAAS203.CheckForMinAbsLevel(abs)
                End If

                '---Store, Calculate and Display Quantitative Value in UV Mode.
                mdblUVAbsorbance = abs

            End If

            RaiseEvent AspirationMessageChanged("Reading Completed ...", True)

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

    Private Sub Read_Quant_Data_PkHt_Area_Mode(ByVal intIntegrationTimeIn As Integer)
        '=====================================================================
        ' Procedure Name        : Read_Quant_Data_PkHt_Area_Mode
        ' Parameters Passed     : intIntegrationTimeIn as inetgration time in integer
        ' Returns               : 
        ' Purpose               : Read the data from instument for peak height mode
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 24-Jan-2007 06:25 pm
        ' Revisions             : 1
        '=====================================================================
        'void	Read_Quant_Data_PkHt_Area_Mode(HWND hwnd, HDC hdc, CURVEDATA *AnaGraph)
        '{
        'double	         absold=0.0, abu=0.0, abl=0.0;
        'char            str[40]="";
        'RAW_DATA_NODE   DataNode;
        'RAW_DATA_STRUCT Data;
        'double			 abs=0.0;
        'BOOL			 peakd = FALSE;
        'clock_t		 CStart, CEnd, CEnd1,CEnd2;
        'MSG			 msg;

        '#If QDEMO Then
        '   int	no=0;
        '#End If

        'InitRawDataNode(&DataNode);
        'DataNode.SampType=SampType;
        'if (SampType==STD){
        '   if (CurStd!=NULL){
        '	    DataNode.Nstd = CurStd->Data.StdNo;
        '	    strcpy(DataNode.SampName,CurStd->Data.Std_Name);
        '   }
        '}
        'else if (SampType==SAMP){
        '   if (CurSamp!=NULL){
        '	    DataNode.Nstd =CurSamp->Data.SampNo;
        '		strcpy(DataNode.SampName,CurSamp->Data.Samp_Name);
        '   }
        '}
        'AddRawData(&DataNode);
        'CEnd2=CEnd1=CStart=CEnd=clock();
        'for(lPipe=0; lPipe<8; lPipe++);
        '   absold=Get_Reading();
        'abu=absold+0.01;
        'abl=absold-0.01;
        'for(lPipe=0; lPipe<8; lPipe++){
        '   abs = Get_Reading();
        '	FiltPipe[lPipe+1]=abs;//ORG
        '}

        'do {
        '   #If !QDEMO Then
        '       abs =  Get_Reading();
        '   	if (abs>200)
        '	        break;
        '       abs =  Get_Smooth_Data_inPkHt_Area(abs);
        '   #End If
        '   CEnd=clock();
        '   if (CEnd!=CEnd1 ){
        '       #If QDEMO Then
        '	        abs =  Get_Reading();
        '   	    if (abs>200)
        '	    	    break;
        '	        abs =  Get_Smooth_Data_inPkHt_Area(abs);
        '      #End If
        '       Xtime += ( ((double)(CEnd-CEnd1)/(double) CLK_TCK));
        '   	CEnd1 = CEnd;
        '	    InitRawDataStruct(&Data);
        '	    Data.Xval=Xtime; Data.Abs=abs;
        '	    AddRawDataItems(&Data);
        '	    //--mdf by sk on 3/8/2001
        '	    //peakd= TestPeakValue(hwnd); //org commented
        '	    peakd= TestPeakValue(hwnd,AnaGraph);
        '       #If QDEMO Then
        '	        no++;
        '          if (no>1100)
        '	            break;
        '      #End If
        '       if (peakd){
        '	        if (absold>abs && (abs<=abu && abs>=abl))
        '		        break;
        '       }
        '       if (Xtime>=AnaGraph->Xmax){
        '	        AnaGraph->Xmin += Method->QuantData->Param.Int_Time;
        '		    AnaGraph->Xmax += Method->QuantData->Param.Int_Time;
        '		    Calculate_Analysis_Graph_Param(AnaGraph);
        '		    InvalidateRect(hwnd, NULL, FALSE); //AnaGraph->RC, TRUE);
        '		    UpdateWindow(hwnd);
        '		    Afirst=TRUE;
        '		    Xoldt=-1;Yoldt=-1;
        '		    CEnd1 = clock();
        '		    CStart += (CEnd1-CEnd);
        '       }
        '	    if (Afirst){
        '	        PlotInit(hdc, Xtime, abs, AnaGraph->RC, AnaGraph);
        '		    Afirst=FALSE;
        '	    }
        '       Else
        '	        Plotg(hdc, Xtime, abs, AnaGraph->RC, AnaGraph);
        '   }
        '   if ( (CEnd-CStart) % (Method->QuantData->Param.Int_Time)==0 && CEnd2!=CEnd1)  //param.itime
        '   {
        '       CEnd2=CEnd1;
        '       GetValInString(abs, str, Method->Mode);
        '	    SetDlgItemText(hwnd,IDC_QAABS, str);
        '   }
        '   CEnd = clock();
        '   CheckMsg(NULL, &msg);
        '   If (IsAlt_S_Pressed()) Then
        '       break;
        '}  while (1);
        '//  Xtime= xtime1+(double) Method->QuantData->Param.Int_Time;
        'lPipe=0;
        '}
        '*************************************************************
        Dim absold, abu, abl As Double
        Dim abs As Double
        Dim peakd As Boolean
        Dim DataNode As Analysis.clsRawData
        Dim Data As Analysis.clsRawDataReadings.RAW_DATA
        Dim no As Integer
        Dim CStart, CEnd, CEnd1, CEnd2 As Long

        Try
            Xtime = Me.CEndTime

            CEnd2 = 0
            CEnd1 = 0
            CStart = 0
            CEnd = 0

            'If gstructSettings.AppMode = EnumAppMode.DemoMode Then
            If Not ((gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                    (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                    (gstructSettings.AppMode = EnumAppMode.DemoMode_203D)) Then
                no = 0
            End If

            For lPipe = 0 To 8 - 1
                absold = gobjClsAAS203.Get_Reading(SampleType, mobjCurrentStandard, Filter_flag, mobjCurrentSample)
            Next

            abu = absold + 0.01
            abl = absold - 0.01

            For lPipe = 0 To 8 - 1
                abs = gobjClsAAS203.Get_Reading(SampleType, mobjCurrentStandard, Filter_flag, mobjCurrentSample)
                FiltPipe(lPipe + 1) = abs
            Next

            Do
                'If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
                If Not ((gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                        (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                        (gstructSettings.AppMode = EnumAppMode.DemoMode_203D)) Then

                    abs = gobjClsAAS203.Get_Reading(SampleType, mobjCurrentStandard, Filter_flag, mobjCurrentSample)
                    If (abs > 200) Then
                        Exit Do
                    End If
                    abs = Get_Smooth_Data_inPkHt_Area(abs)
                End If

                CEnd += 50

                If (CEnd <> CEnd1) Then
                    'If gstructSettings.AppMode = EnumAppMode.DemoMode Then
                    If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                            (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                            (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                        abs = gobjClsAAS203.Get_Reading(SampleType, mobjCurrentStandard, Filter_flag, mobjCurrentSample)
                        If (abs > 200) Then
                            Exit Do
                        End If
                        abs = Get_Smooth_Data_inPkHt_Area(abs)
                    End If

                    Xtime += (CEnd - CEnd1) / 1000
                    CEnd1 = CEnd

                    '############################################################
                    'TODO function to find Peak Area or Height 
                    '############################################################
                    'peakd= TestPeakValue(hwnd,AnaGraph);
                    'peakd = TestPeakValue()
                    '############################################################

                    'If gstructSettings.AppMode = EnumAppMode.DemoMode Then
                    If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                        (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                        (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                        no += 1
                        If (no > 1100) Then
                            Exit Do
                        End If
                    End If

                    If (peakd) Then
                        If (absold > abs And (abs <= abu And abs >= abl)) Then
                            Exit Do
                        End If
                    End If

                    Dim strData As String
                    strData = ""
                    strData = Xtime & "," & abs
                    '---Display Reading
                    mobjThreadController.Display(strData)
                    Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
                    Application.DoEvents()
                End If

                If ((CEnd - CStart) Mod (intIntegrationTimeIn) = 0 And CEnd2 <> CEnd1) Then
                    CEnd2 = CEnd1
                    RaiseEvent AbsorbanceValueChanged(abs)
                End If

                CEnd += 50

                If (IsAlt_S_Pressed) Then
                    Exit Do
                End If

            Loop While True

            lPipe = 0

            Me.CEndTime = Xtime

            RaiseEvent AspirationMessageChanged("Reading Completed ...", True)
            mobjThreadController.Completed(False)

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
    End Sub

    Private Function Get_Smooth_Data_inPkHt_Area(ByVal data As Double) As Double
        '=====================================================================
        ' Procedure Name        : Get_Smooth_Data_inPkHt_Area
        ' Parameters Passed     : data as double
        ' Returns               : Double value
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 15-Jan-2007 08:15 pm
        ' Revisions             : 1
        '=====================================================================
        'double	Get_Smooth_Data_inPkHt_Area(double data)
        '{
        '	double	sav=0.0;
        '	int		i; //, tpts;

        '	i = lPipe; //read_count;
        '        If (i >= 8) Then
        '	{
        '		for(i=0;i<8; i++)
        '			FiltPipe[i]=FiltPipe[i+1];
        '		FiltPipe[i]=data;
        '		sav = (double)-21.0*(FiltPipe[i-8]+ FiltPipe[i]) +
        '				(double) 14.0*(FiltPipe[i-7]+ FiltPipe[i-1])+
        '				(double) 39.0*(FiltPipe[i-6]+ FiltPipe[i-2])+
        '				(double) 54.0*(FiltPipe[i-5]+ FiltPipe[i-3])+
        '				(double) 59.0*FiltPipe[i-4];
        '		sav = sav/(double)231.0;
        '		sav = GetValConvertedTo( sav, Method->Mode);
        '	}
        '	return sav;
        '}
        '=====================================================================
        Dim sav As Double = 0.0
        Dim i As Integer

        Try
            i = lPipe

            If (i >= 8) Then

                For i = 0 To 8 - 1
                    FiltPipe(i) = FiltPipe(i + 1)
                Next

                FiltPipe(i) = data
                sav = -21.0 * (FiltPipe(i - 8) + FiltPipe(i)) + _
                      14.0 * (FiltPipe(i - 7) + FiltPipe(i - 1)) + _
                      39.0 * (FiltPipe(i - 6) + FiltPipe(i - 2)) + _
                      54.0 * (FiltPipe(i - 5) + FiltPipe(i - 3)) + _
                      59.0 * FiltPipe(i - 4)

                sav = sav / 231.0

            End If

            Return sav

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

    'Public Function TestPeakValue() As Boolean
    '    '=====================================================================
    '    ' Procedure Name        : TestPeakValue
    '    ' Parameters Passed     : None
    '    ' Returns               : True or false
    '    ' Purpose               : 
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Mangesh Shardul
    '    ' Created               : 04-Apr-2007 04:25 pm
    '    ' Revisions             : 1
    '    '=====================================================================

    '    '********************************************************************
    '    '---- ORIGINAL CODE
    '    '********************************************************************
    '    'BOOL TestPeakValue(HWND hwnd, CURVEDATA *AnaGraph)
    '    '{
    '    '	double			slope=1000.0, maxval=-1000.0;
    '    '	double			*values=NULL;
    '    '	RAW_DATA_LINKS *tempk=NULL;
    '    '	int				i,tot;
    '    '	double			xval=0;//, yval=0;;

    '    '	if (!Raw->RawDataCur)
    '    '		return FALSE;
    '    '	tempk =Raw->RawDataCur->Data.TopRawData;
    '    '	tot = GetTotalSamples(tempk);
    '    '	values = (double *) malloc(sizeof(double) * (NO_OF_PK_PTS+2));
    '    '   If (values) Then
    '    '	{
    '    '		InitBuffer(values, NO_OF_PK_PTS+1);
    '    '                If (tot > NO_OF_PK_PTS + 1) Then
    '    '		{
    '    '			tempk = GoToSample(Raw->RawDataCur->Data.TopRawData, tot-(NO_OF_PK_PTS+1));
    '    '			i=0;
    '    '			while(tempk!=NULL && i<(NO_OF_PK_PTS+1))
    '    '			{
    '    '				values[i]= tempk->Data.Abs;
    '    '				if (maxval<values[i])
    '    '					maxval=values[i];
    '    '				if (i==(NO_OF_PK_PTS/2))
    '    '				{
    '    '					xval = tempk->Data.Xval;
    '    '				}
    '    '				i++;
    '    '				tempk=tempk->next;
    '    '			}
    '    '			slope = GetPeakSlopeAt(values);
    '    '		}
    '    '       If (maxval > 0.01) Then
    '    '			maxval/=11.0;
    '    '       Else
    '    '			maxval=1.0;
    '    '		if (slope>100 || slope<-100)
    '    '			slope=-100;
    '    '       ElseIf (maxval! = 0.0) Then
    '    '		{
    '    '			if (slope >(0.01/maxval) && slope<(.1/maxval))
    '    '				ShowStart(hwnd, xval, 0, AnaGraph); //yval,
    '    '			else if (slope>(-.01/maxval) && slope<(0.01/maxval))
    '    '				ShowStart(hwnd, xval,  1, AnaGraph); //values[11],
    '    '			else if (slope<(-.01/maxval) && slope>(-.1/maxval))
    '    '				ShowStart(hwnd, xval, 2, AnaGraph); //yval,
    '    '		}
    '    '		free(values); values=NULL;
    '    '	}
    '    '	if (slope > -0.01 && slope < 0.01)
    '    '		return TRUE;
    '    '   Else
    '    '		return FALSE;
    '    '}
    '    '********************************************************************
    '    Dim slope As Double = 1000.0
    '    Dim maxval As Double = -1000.0
    '    Dim values() As Double
    '    Dim i, tot As Integer
    '    Dim xval As Double
    '    Dim tempk As clsRawData

    '    '#define		NO_OF_PK_PTS		4 //10
    '    Const NO_OF_PK_PTS = 4

    '    Try
    '        Select Case Me.SampleType
    '            Case ClsAAS203.enumSampleType.BLANK
    '                tempk = mobjBlankRawData.Clone()

    '            Case ClsAAS203.enumSampleType.STANDARD
    '                tempk = mobjStandardRawData.Clone()

    '            Case ClsAAS203.enumSampleType.SAMPLE
    '                tempk = mobjSampleRawData.Clone()

    '        End Select

    '        If IsNothing(tempk) Then
    '            Return False
    '        End If

    '        'tempk =Raw->RawDataCur->Data.TopRawData

    '        'tot = GetTotalSamples(tempk)
    '        tot = tempk.Readings.Count - 1

    '        'values = (double *) malloc(sizeof(double) * (NO_OF_PK_PTS+2));
    '        ReDim values(NO_OF_PK_PTS + 2)

    '        If Not IsNothing(values) Then
    '            'InitBuffer(values, NO_OF_PK_PTS+1);
    '            If (tot > NO_OF_PK_PTS + 1) Then
    '                'tempk = GoToSample(Raw->RawDataCur->Data.TopRawData, tot-(NO_OF_PK_PTS+1))
    '                i = 0
    '                While (Not IsNothing(tempk) And i < (NO_OF_PK_PTS + 1))
    '                    'values(i)= tempk->Data.Abs
    '                    'values(i) = tempk.Readings.item(i).Absorbance
    '                    If (maxval < values(i)) Then
    '                        maxval = values(i)
    '                    End If
    '                    If (i = (NO_OF_PK_PTS / 2)) Then
    '                        'xval = tempk->Data.Xval
    '                        xval = tempk.Readings.item(0).XTime
    '                    End If
    '                    i += 1
    '                End While
    '                'slope = GetPeakSlopeAt(values)
    '            End If

    '            'If (maxval > 0.01) Then
    '            '	maxval/=11.0;
    '            'Else
    '            '   maxval=1.0;

    '            'if (slope>100 || slope<-100)
    '            '	    slope=-100;
    '            '   ElseIf (maxval! = 0.0) Then
    '            '   {
    '            '	    if (slope >(0.01/maxval) && slope<(.1/maxval))
    '            '		    ShowStart(hwnd, xval, 0, AnaGraph); 
    '            '		else if (slope>(-.01/maxval) && slope<(0.01/maxval))
    '            '			ShowStart(hwnd, xval,  1, AnaGraph); 
    '            '		else if (slope<(-.01/maxval) && slope>(-.1/maxval))
    '            '			ShowStart(hwnd, xval, 2, AnaGraph); 
    '            '	}
    '            '	free(values); 
    '            '   values=NULL;
    '        End If

    '        If (slope > -0.01 And slope < 0.01) Then
    '            Return True
    '        Else
    '            Return False
    '        End If

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        Return False
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try
    'End Function

    'Private Function GetTotalSamples(ByVal Top As clsRawDataCollection) As Integer
    '    '=====================================================================
    '    ' Procedure Name        : GetTotalSamples
    '    ' Parameters Passed     : object od clsRawData
    '    ' Returns               : no. of samples
    '    ' Purpose               : 
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Mangesh Shardul
    '    ' Created               : 04-Apr-2007 05:35 pm
    '    ' Revisions             : 1
    '    '=====================================================================
    '    Dim tot As Integer
    '    Dim intCounter As Integer

    '    Try
    '        'While (tempk != NULL)
    '        '    tot += 1
    '        '    'tempk=tempk->next;
    '        'End While
    '        For intCounter = 0 To Top.Count - 1
    '            tot += 1
    '        Next

    '        Return tot

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try
    'End Function

    Private Function GetAvgValOfAnalysis(ByVal objAnalysisRawData As clsRawData) As Double
        '=====================================================================
        ' Procedure Name        : GetAvgValOfAnalysis
        ' Parameters Passed     : Row data object for store Avg. count
        ' Returns               : Double
        ' Purpose               : return double
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 26-Dec-2006
        ' Revisions             : 1
        '=====================================================================
        Dim dblAbsorbance As Double
        Dim intTotal As Integer
        Dim objRawDataReading As Analysis.clsRawDataReadings.RAW_DATA
        Dim intCounter As Integer

        Try
            intTotal = 0

            If Not IsNothing(objAnalysisRawData) Then
                '---calculate the Avg value from data object
                For intCounter = 0 To objAnalysisRawData.Readings.Count - 1
                    objRawDataReading = objAnalysisRawData.Readings.item(intCounter)
                    dblAbsorbance += objRawDataReading.Absorbance
                    intTotal += 1
                Next intCounter

                If (intTotal > 0) Then
                    dblAbsorbance = dblAbsorbance / intTotal
                End If
            End If

            Return dblAbsorbance

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
