Imports BgThread
Imports AAS203.Common
Imports AAS203.AASGraph
Imports AAS203Library.Instrument
''this are like a header file.
Public Class clsBgBurnerOptimization ''class for burner optimization
    Implements BgThread.IBgWorker ''interface for thread class.

#Region " Constructors "

    Public Sub New()
        MyBase.New()

    End Sub

    Public Sub New(ByRef lblSt1 As Object, ByRef lblSt2 As Object, ByRef lblSt3 As Object, ByVal dblLampCurrent As Double, ByVal intLampPos As Integer, Optional ByRef objGraph As Object = Nothing)
        '=====================================================================
        ' Procedure Name        : New(constructor)
        ' Parameters Passed     : lblSt1,lblSt2,lblSt3,dblLampCurrent ,intLampPos,objGraph
        ' Returns               : 
        ' Purpose               : to initialise the burnerthread object
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 29.12.06
        ' Revisions             : praveen
        '=====================================================================
        MyBase.New()
        ''note:
        ''this is used to initialise the object with current value
        '' like cblLampCurrent gives a curretn LampCurrent 
        Try
            mdblLampCurrent = dblLampCurrent
            mintLampPosition = intLampPos
            mlblStatus1 = lblSt1
            mlblStatus2 = lblSt2
            mlblStatus3 = lblSt3
            mObjGraph = objGraph
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

#Region " Private Variables "
    ''this are the private variables
    Private mobjThreadController As IBgThread
    ''object for a thread
    Private mdblLampCurrent As Double
    Private mintLampPosition As Integer
    Private mlblStatus1, mlblStatus2, mlblStatus3 As Object
    ''this are the object for lable where we have to show the status
    Private mObjGraph As Object
    ''
    Private mblnThTerminate As Boolean = False
    ''flag for controling a thread.
    Private objRandom As New System.Random

#End Region

#Region " Public Property "

    Public Property ThTerminate() As Boolean
        ''this property will hold a flag for terminate a burner thread
        Get
            ThTerminate = mblnThTerminate
        End Get
        Set(ByVal Value As Boolean)
            mblnThTerminate = Value
        End Set
    End Property

#End Region

#Region " Public Functions "

    Public Sub Initialize(ByVal Controller As BgThread.IBgThread) Implements BgThread.IBgWorker.Initialize
        '=====================================================================
        ' Procedure Name        : Initialize
        ' Parameters Passed     : Controller
        ' Returns               : 
        ' Purpose               : To Initialize the thread
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 29.11.06
        ' Revisions             : praveen
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

    Public Sub StartWorkerThread() Implements BgThread.IBgWorker.Start
        '=====================================================================
        ' Procedure Name        : StartWorkerThread
        ' Parameters Passed     : none
        ' Returns               : IBgWorker.Start as Implements object
        ' Purpose               : To Start the worker thread
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 29.11.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is main function which is called for starting a burner optimization thread.

        Dim objwait As New CWaitCursor
        Dim strPreviousStatusMessage As String
        Try
            Do While (True)
                ''start a while loop for thread.
                If mobjThreadController.Running Then
                    ''check whatever a thread is started or not.

                    'funcThreadTurret_Optimise(mdblLampCurrent, mintLampPosition, mlblStatus1, mlblStatus2, mlblStatus3, mObjGraph, mobjThreadController)
                    If gintOptimisation = modGlobalDeclarations.EnumBH_FP_Opimisation.BurnerHeight Then
                        ''check for a gintOptimisation  flag for burner optimisation

                        '//----- Added by Sachin Dokhale on 25.03.07
                        '//----- To know the Status of Thread on Status Bar of MDI Main

                        If gblnShowThreadOnfrmMDIStatusBar Then
                            ''show the current status message.
                            strPreviousStatusMessage = gobjMain.StatusBarPanelInfo.Text
                            gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage & " *Burner Height"
                            Application.DoEvents()
                            ''allow application to perfrom its panding work.
                        End If
                        '//-----

                        funcOptimise_BurnerHeight_Auto(mlblStatus1, mlblStatus2, mlblStatus3, mObjGraph)
                        ''call a function for optimise the burner height as per given parameter.
                    ElseIf gintOptimisation = modGlobalDeclarations.EnumBH_FP_Opimisation.FuelPresure Then
                        '//----- Added by Sachin Dokhale on 25.03.07
                        '//----- To know the Status of Thread on Status Bar of MDI Main
                        If gblnShowThreadOnfrmMDIStatusBar Then
                            ''show a current status on status bar
                            strPreviousStatusMessage = gobjMain.StatusBar1.Text
                            gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage & " *Fuel Presure"
                            Application.DoEvents()
                        End If
                        '//-----
                        funcOptimise_Fuel_Auto(mlblStatus1, mlblStatus2, mlblStatus3, mObjGraph)
                        ''optimise the fuel 
                    End If

                    'If mobjThreadController.Running Then
                    mobjThreadController.Completed(True)
                    ''set flag for completion of thread.
                    'End If

                    Application.DoEvents()
                    ''allow application to perfrom its panding work.
                    Exit Do
                Else
                    'If mobjThreadController.Running Then
                    mobjThreadController.Completed(True)
                    'End If
                    '//----- Added by Sachin Dokhale on 25.03.07
                    '//----- To remove the Status of Thread on Status Bar of MDI Main
                    If gblnShowThreadOnfrmMDIStatusBar Then
                        gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage
                    End If
                    '//-----
                    Application.DoEvents()
                    '---allow application to perfrom its panding work.
                    Exit Sub
                End If
                gobjCommProtocol.mobjCommdll.subTime_Delay(10)
                ''this is for communication delay during a thread.
            Loop
            '//----- Added by Sachin Dokhale on 25.03.07
            '//----- To remove the Status of Thread on Status Bar of MDI Main
            If gblnShowThreadOnfrmMDIStatusBar Then
                gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage
            End If
            Application.DoEvents()
            ''allow application to perfrom its panding work.
            '//-----
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

#Region " Private Functions "

    Private Function funcOptimise_BurnerHeight_Auto(Optional ByRef lblStatus1 As Object = Nothing, Optional ByRef lblStatus2 As Object = Nothing, Optional ByRef lblStatus3 As Object = Nothing, Optional ByRef AASGraphs As Object = Nothing) As Boolean  'AASGraph  
        '=====================================================================
        ' Procedure Name        :   funcOptimise_Height_Auto
        ' Description           :   Optimese , the auto Height of burner.
        ' Purpose               :   
        '                           
        ' Parameters Passed     :   lblStatus1,lblStatus2,lblStatus3,AASGraphs
        ' Returns               :   bool
        ' Parameters Affected   :   
        ' Assumptions           :   
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale 
        ' Created               :   25.12.06
        ' Revisions             :   praveen
        '=====================================================================

        ''note:
        ''this is used to optimise the burner height
        ''this called during the burner optimise thread.

        'double	txmin=0.0, txmax=0.0;
        'double   abs=0.0, max_abs= 0;
        'int		xval=0, max_bh=0, xvalmax, xvalmin, adval;
        'int 		i;
        'HWND		hwnd;
        'HDC		hdc;
        'char     line1[80]="";
        'unsigned	tout;
        'BOOL		pflag=FALSE;
        'int	lMode=0;
        'int		txold, tyold;

        '  if (GetInstrument()==AA202)
        '	return TRUE;

        '            If (!ReadAndSetBHScanConditions(hpar)) Then
        '	return FALSE;
        '                If (!CheckBhPos()) Then
        '	return FALSE;
        ' GetXoldYold(&txold, &tyold);
        ' txmin= PeakGraph.Xmin;
        ' txmax	= PeakGraph.Xmax;
        ' Blink_MessageBox(hpar,"Aspirate Max. Standard and Click OK","Height optimisation", 0);
        '// MessageBox(hpar, "Aspirate Max. Standard and Click OK","Height optimisation", MB_OK);
        ' hwnd= CreateWindowPeak(hpar, " BURNER OPTIMISATION ","SKCK2",0 );

        ' if (hwnd ){
        '	PeakGraph.Xmin=  txmin;
        '	PeakGraph.Xmax = txmax;
        '	PeakGraph.Ymin= 0.0;//GetEnergy(2047);
        '	PeakGraph.Ymax= 1.0;//GetEnergy(2047.0+409.6*4);
        '	SetInstrumentCondns(hwnd, TRUE);
        '	xvalmax = ConvertToBhPos(PeakGraph.Xmax) ;
        '	xvalmin = ConvertToBhPos(PeakGraph.Xmin) ;
        '	i= (int )  ((xvalmax-xvalmin)/BHSCANSTEP);
        '	i = abs(i);
        '	strcpy(PYaxis,"ABS"); strcpy(PXaxis,"Burner Height");
        '	Show_Peak_Param(hwnd, i);
        '	PeakGraph.Xmin=txmin ;
        '	PeakGraph.Xmax = txmax;

        '	SetFocus(hwnd);
        '	hdc= GetDC(hwnd);
        '	SetBkColor(hdc, RGB(192, 192, 192));
        '	SetText(hwnd, IDC_STATUS,"INITIALISING Please Wait  ....... ");
        '	strcpy(line1,""); sprintf(line1, " Setting Height from %3.1f mm to %3.1f mm ", ConvertToBurnerHeight(Inst->Bhstep), PeakGraph.Xmin);
        '	SetText(hwnd, IDC_STATUS1,line1);
        '	SetBhPos(PeakGraph.Xmin);
        '	strcpy(line1,"");
        '	sprintf(line1, " Burner Height Optimisation");
        '	SetText(hwnd, IDC_STATUS1,line1);
        '	SetText(hwnd, IDC_STATUS,"");
        '	lMode=Inst->Mode;
        '	Cal_Mode(AA);
        '	SetScanning(TRUE);
        '	Transmit(BHSCAN, (BYTE)(xvalmax), (BYTE) (xvalmax>>8), (BYTE) BHSCANSTEP);
        '	xval= xvalmin;
        '	tout = GetTimeOut();
        '	SetTimeOut(LONG_DEALY);
        '	i=1;
        '	while(1){
        '                            If (Recev(False)) Then
        '		adval= GetParam2()*256 + GetParam1();
        '                            Else
        '		break;
        '                                If (adval >= 6000) Then
        '		break;
        '#If QDEMO Then
        '	  adval=2100+random(20);
        '#End If
        '	  abs = GetADConvertedToCurMode(adval);
        '	  if (abs > max_abs)    {
        '		 max_abs=abs;
        '		 max_bh=xval;
        '		 pflag=TRUE;
        '		}
        '	  sprintf(line1,"(%4.2f, %4.3f) %d (%d-%d)",ConvertToBurnerHeight(xval), abs, xval, xvalmin, xvalmax);
        '	  SetText(hwnd, IDC_STATUS,line1);
        '	  if (i==1)
        '		 GPlotInit(hdc, ConvertToBurnerHeight(xval), abs);
        '                                        Else
        '		 GPlot(hdc,ConvertToBurnerHeight(xval), abs);
        '	  xval+=BHSCANSTEP;
        '	  i++;
        '	 if (!Transmit(PC_END, (BYTE)0, (BYTE) 0, (BYTE) 0))
        '		break;
        '	 }
        '	SetTimeOut(tout);
        '	if (pflag){
        '	  sprintf(line1,"Optimised at (%4.2f, %4.3f)",ConvertToBurnerHeight(max_bh),  max_abs);
        '	  SetText(hwnd, IDC_STATUS1,line1);
        '	  GShowPeak(hdc,ConvertToBurnerHeight(max_bh),  max_abs, NULL);
        '	  strcpy(line1,""); sprintf(line1," Positioning to Optimised Position ...");
        '	  SetText(hwnd, IDC_STATUS,line1);
        '#If EMU Then
        ' Wait_For_Some_Msg(5);
        '#End If
        '	  SetBhPos(ConvertToBurnerHeight(max_bh));
        '	 }
        '	Cal_Mode(lMode);
        '	ReleaseDC(hwnd, hdc);
        '	DestroyWindowPeak(hwnd,hpar);
        '  }
        ' SetScanning(FALSE);
        ' SetXoldYold(txold, tyold);
        ' pc_delay(1500);
        ' return TRUE;
        '}


        Dim txmin As Double = 0.0
        Dim txmax As Double = 0.0
        Dim abs As Double = 0.0
        Dim max_abs As Double = 0.0
        Dim xfuel As Double = 0.0
        Dim xval As Integer = 0
        Dim max_fuel As Integer = 0
        Dim xvalmax, xvalmin, adval As Integer
        Dim max_bh As Integer = 0
        Dim pflag As Boolean = False
        Dim i As Integer
        Dim blnStartSpec As Boolean
        Dim line1 As String
        'unsigned	tout;
        'Dim tout As Integer
        Dim intlMode As Integer
        Dim inttxold, inttyold As Integer
        Dim blnBHOptim As Boolean = True
        Dim lMode As Integer
        Dim tempxval As Integer  '---Mrutunjaya

        Try
            If (gstructSettings.AppMode = EnumAppMode.FullVersion_201) Then
                ''return true for 201
                Return True
            End If

            '           If (!ReadAndSetFuelScanConditions(hpar)) Then
            'return FALSE;
            lblStatus1.Text = " INITIALISING Please Wait  ....... "
            lblStatus1.Refresh()
            '" Setting Height from " & gobjClsAAS203.funcConvertToBurnerHeight(gobjInst.BhStep) & " mm to " & txmin & " mm", "Burner Height", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 0)
            lblStatus2.Text = "Setting Height from " & Format(gobjClsAAS203.funcConvertToBurnerHeight(gobjInst.BhStep), "#0.00") & " mm to " & Format(txmin, "#0.00") & " mm"
            lblStatus2.Refresh()
            ''set a status label.

            '---to get burner height position.
            If (Not gobjClsAAS203.funcCheckBHPos()) Then
                ''for checking burner position
                Return False
            End If

            'GetXoldYold(&txold, &tyold);
            gobjClsAAS203.subGetXoldYold(inttxold, inttyold)
            ''for getting X, Y value for graph.

            'Dim dblGraphXmin, dblGraphXMax As Double
            'txmin = dblGraphXmin    'PeakGraph.Xmin
            'txmax = dblGraphXmax    'PeakGraph.Xmax

            txmin = AASGraphs.XAxisMin
            txmax = AASGraphs.XAxisMax


            'blnBHOptim = gobjMessageAdapter.ShowMessage("Aspirate Max. Standard and Click OK", "Height optimisation", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)

            'PeakGraph.Xmax=txmin ;
            'PeakGraph.Xmin= txmax;
            'PeakGraph.Ymin= 0.0;//GetEnergy(2047);
            'PeakGraph.Ymax= 1.0;//GetEnergy(2047.0+409.6*4);
            'mobjParameters.XaxisMax = txmax
            'mobjParameters.XaxisMin = txmin
            'mobjParameters.YaxisMax = 0.0
            'mobjParameters.YaxisMin = 1
            'AASGraphs.XAxisMax = txmax
            'AASGraphs.XAxisMin = txmin
            ' AASGraphs.YAxisMax = 1.0
            'AASGraphs.YAxisMin = 0.0

            Call AASGraphs.AldysPane.XAxis.PickScale(AASGraphs.XAxisMin, AASGraphs.XAxisMax)
            ''for setting a XAxis scale
            Call AASGraphs.AldysPane.YAxis.PickScale(AASGraphs.YAxisMin, AASGraphs.YAxisMax)
            ''for setting a YAxis scale
            AASGraphs.AldysPane.AxisChange()
            ''call the Axis change function for setting X,Y scale
            AASGraphs.Invalidate()
            AASGraphs.Refresh()
            Application.DoEvents()
            ''now allow application to perfrom its panding work.

            '//-----------------------------------------

            '//------------------------------------------
            'SetInstrumentCondns(hwnd, TRUE);
            'xvalmax = ConvertToNvPos(PeakGraph.Xmax) ;
            'abs = ConvertToFuel(xvalmax) ;
            'xvalmin = ConvertToNvPos(PeakGraph.Xmin) ;
            'abs = ConvertToFuel(xvalmin) ;
            If blnBHOptim = True Then
                ''check for burner optmization flag.
                '---To display instrument conditions 
                Call gobjClsAAS203.funcSetInstrumentCondns(True)
                'xvalmax = funcConvertToBHPos(mobjParameters.XaxisMax)
                'xvalmin = funcConvertToBHPos(mobjParameters.XaxisMin)

                '---to convert x-axis max value to burner height steps
                xvalmax = gobjClsAAS203.funcConvertToBHPos(AASGraphs.XAxisMax)
                '---to convert x-axis min value to burner height steps
                xvalmin = gobjClsAAS203.funcConvertToBHPos(AASGraphs.XAxisMin)
                i = ((xvalmax - xvalmin) / CONST_BHSCANSTEP)
                i = Math.Abs(i)

                'gobjMessageAdapter.ShowStatusMessageBox("INITIALISING Please Wait  ....... " & vbNewLine & _
                '" Setting Height from " & gobjClsAAS203.funcConvertToBurnerHeight(gobjInst.BhStep) & " mm to " & txmin & " mm", "Burner Height", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 0)

                ' Check the property for interuption from user to terminate the process
                If ThTerminate = True Then
                    'If gobjCommProtocol.funcBreakSpectrum() = False Then
                    'Exit Do
                    'End If
                    GoTo ExitScan
                End If

                '---Set burner height position.
                gobjClsAAS203.funcSetBHPos(txmin)
                'gobjMessageAdapter.CloseStatusMessageBox()
                'gobjMessageAdapter.ShowStatusMessageBox("Burner Height Optimisation", "Burner Height", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 0)
                lblStatus1.Text = "Burner Height Optimisation"
                lblStatus1.Refresh()
                Application.DoEvents()
                ''allow application to perfrom its panding work.

                lMode = gobjInst.Mode
                '---set calibration mode as aa
                gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.AA)
                Application.DoEvents()
                Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
                ''this is for communication delay
                '---to can burner height
                blnStartSpec = gobjCommProtocol.funcBHSCAN(xvalmax)
                xval = xvalmin
                'tout = GetTimeOut();
                'SetTimeOut(LONG_DEALY);
                i = 1
                If blnStartSpec Then
                    gblnInComm = False
                    Do While True
                        If gblnInComm = False Then
                            '---to receive burner height scan data.
                            If gobjCommProtocol.funcReceive_ScanData(0, adval) = True Then

                            Else
                                Exit Do
                            End If
                            'adval = GetParam2() * 256 + GetParam1()
                            'Else
                            If (adval >= 12000) Then 'As we discussed with Satish made changes from 6000 to 12000'
                                Exit Do
                            End If
                            'If ThTerminate = True Then
                            '    Exit Do
                            'End If
                            '//----- For Demo Mode
                            '#If QDEMO Then
                            '	  adval=2100+random(20);
                            '#End If
                            '-- in case of demo mode  convert value to random value
                            'If gstructSettings.AppMode = EnumAppMode.DemoMode Then
                            If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                                (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                                (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                                adval = 2100 + objRandom.Next(20)
                            End If
                            '//-----
                            'abs = GetADConvertedToCurMode(adval)
                            '---convert scan data to calibration mode value
                            abs = gFuncGetADConvertedToCurMode(adval)
                            ''this will convert an ADC value in to abs

                            'if (abs > max_abs)    {
                            ' max_abs=abs;
                            ' max_bh=xval;
                            ' pflag=TRUE;
                            '}
                            If (abs > max_abs) Then
                                max_abs = abs
                                max_bh = xval
                                pflag = True
                            End If
                            'sprintf(lsine1,"(%4.2f, %4.3f) %d (%d-%d)",ConvertToBurnerHeight(xval), abs, xval, xvalmin, xvalmax);
                            lblStatus2.Text = "Setting Height " & Format(gobjClsAAS203.funcConvertToBurnerHeight(xval), "#0.00") & " mm " & _
                            "Abs " & Format(abs, "#0.000").ToString & " " & "Steps " & Format(xval, "####0.00").ToString & " " & Format(xvalmin, "#####0.00").ToString & " to " & Format(xvalmax, "####0.00").ToString
                            ''display a status

                            'lblStatus2.Text = "Setting Height from " & Format(gobjClsAAS203.funcConvertToBurnerHeight(gobjInst.BhStep).ToString, "#.00") & " mm to " & Format(txmin, "#.00") & " mm"
                            lblStatus2.Refresh()
                            'Start to plot the graph
                            'if (i==1)
                            'GPlotInit(hdc, ConvertToBurnerHeight(xval), abs);
                            'Else
                            'GPlot(hdc,ConvertToBurnerHeight(xval), abs);


                            '---display scanned value on graph
                            mobjThreadController.Display(gobjClsAAS203.funcConvertToBurnerHeight(xval).ToString & "|" & abs.ToString)
                            tempxval = xval  ' -- Mrutunjaya
                            xval += CONST_BHSCANSTEP
                            i += 1
                            'If Not (gobjCommProtocol.funcPC_END) Then ' -- original code
                            If (tempxval = xvalmax) Then '-- Mrutunjaya
                                ''serial communication function for PC ens.
                                Exit Do
                            End If
                        End If
                            Application.DoEvents()
                        ''allow apllication to perfrom ita panding work
                    Loop
                End If

            End If

ExitScan:
            '----called ExitScan routine
            Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
            If pflag = True Then
                lblStatus2.Text = "Optimised at " & Format(gobjClsAAS203.funcConvertToBurnerHeight(max_bh), "####0.00").ToString & _
                "  " & Format(max_abs, "#0.000").ToString
                lblStatus2.Refresh()
                lblStatus3.Text = "Positioning to optimised Position ..."
                lblStatus3.Refresh()
                'Show the peak
                'GShowPeak(hdc,ConvertToBurnerHeight(max_bh),  max_abs, NULL);

                'strcpy(line1,""); sprintf(line1," Positioning to Optimised Position ...");
                'SetText(hwnd, IDC_STATUS,line1);
                Application.DoEvents()
                'SetBhPos(ConvertToBurnerHeight(max_bh));
                '---set burner to optimized burner height position.
                gobjClsAAS203.funcSetBHPos(gobjClsAAS203.funcConvertToBurnerHeight(max_bh))
                Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
                lblStatus3.Text = "Position is optimised"
                lblStatus3.Refresh()
            End If

            'gobjMessageAdapter.CloseStatusMessageBox()
            gobjCommProtocol.funcCalibrationMode(lMode)
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
            gblnInComm = False
            '---------------------------------------------------------
        End Try
    End Function

    Private Function funcOptimise_Fuel_Auto(Optional ByRef lblStatus1 As Object = Nothing, Optional ByRef lblStatus2 As Object = Nothing, Optional ByRef lblStatus3 As Object = Nothing, Optional ByRef AASGraphs As Object = Nothing) As Boolean  'AASGraph  
        '=====================================================================
        ' Procedure Name        :   funcOptimise_Fuel_Auto
        ' Description           :   Optimese  the auto fuel
        ' Purpose               :   to Optimise fuel conditions
        ' Parameters Passed     :   lblStatus1,lblStatus2,lblStatus3,AASGraphs
        ' Returns               :   bool
        ' Assumptions           :   
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale 
        ' Created               :   25.12.06
        ' Revisions             :   praveen
        '=====================================================================

        Dim txmin As Double = 0.0
        Dim txmax As Double = 0.0
        Dim abs As Double = 0.0
        Dim max_abs As Double = 0.0
        Dim xfuel As Double = 0.0
        Dim xval As Integer = 0
        Dim max_fuel As Integer = 0
        Dim xvalmax, xvalmin, adval As Integer
        Dim pflag As Boolean = False
        Dim i As Integer

        Dim line1 As String
        'unsigned	tout;
        Dim tout As Integer
        Dim intlMode As Integer
        Dim inttxold, inttyold As Integer
        Dim blnBHOptim As Boolean = True
        Dim lMode As Integer
        Dim blnStartSpec As Boolean
        Try
            'if (GetInstrument()=AA202) then
            'return TRUE
            If (gstructSettings.AppMode = EnumAppMode.FullVersion_201) Then
                ''return true for 201
                Return True
            End If
            '           If (!ReadAndSetFuelScanConditions(hpar)) Then
            'return FALSE;
            lblStatus1.Text = " INITIALISING Please Wait  ....... "
            lblStatus1.Refresh()
            ''show the label status

            '" Setting Height from " & gobjClsAAS203.funcConvertToBurnerHeight(gobjInst.BhStep) & " mm to " & txmin & " mm", "Burner Height", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 0)
            'lblStatus2.Text = "Setting Fuel from" & Format(gobjClsAAS203.funcConvertToBurnerHeight(gobjInst.NvStep), "#.00") & " mm to " & Format(txmax, "#.00") & " mm"
            'strcpy(line1,""); sprintf(line1, " Setting Fuel from %4.2f to %4.2f ", ConvertToFuel(Inst->Nvstep) , PeakGraph.Xmax);
            'lblStatus2.Refresh()


            'If (!Flame_Present(False)) Then
            'return FALSE;
            '               If (!CheckNvPos()) Then
            'return FALSE;

            '---to check flame is present or not
            If Not (gobjClsAAS203.funcFlame_Present(False)) Then
                ''check for flame present
                lblStatus1.Text = ""
                lblStatus1.Refresh()
                Return False
            End If
            'If Not (funcReadAndSetFuelScanConditions()) Then
            '    Return False
            'End If
            '---to get current nv position.
            If (Not gobjClsAAS203.funcCheckNvPos()) Then
                ''check for NV position
                lblStatus1.Text = ""
                lblStatus1.Refresh()
                Return False
            End If

            'GetXoldYold(&txold, &tyold);
            'Dim dblGraphXmin, dblGraphXMax As Double
            gobjClsAAS203.subGetXoldYold(inttxold, inttyold)
            ''for setting X,Y old value

            'Dim dblGraphXmin, dblGraphXMax As Double
            'txmin = dblGraphXmin    'PeakGraph.Xmin
            'txmax = dblGraphXmax    'PeakGraph.Xmax

            txmin = AASGraphs.XAxisMin
            txmax = AASGraphs.XAxisMax
            ''get a X axis min and max.

            'strcpy(line1,""); sprintf(line1, " Setting Fuel from %4.2f to %4.2f ", ConvertToFuel(Inst->Nvstep) , PeakGraph.Xmax);
            lblStatus2.Text = "Setting Fuel from" & Format(gobjClsAAS203.funcConvertToBurnerHeight(gobjInst.NvStep), "####0.00") & " mm to " & Format(txmax, "####0.00") & " mm"
            lblStatus2.Refresh()
            ''show status on label

            'blnBHOptim = gobjMessageAdapter.ShowMessage("Aspirate Max. Standard and Click OK", "Height optimisation", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)

            'PeakGraph.Xmax=txmin ;
            'PeakGraph.Xmin= txmax;
            'PeakGraph.Ymin= 0.0;//GetEnergy(2047);
            'PeakGraph.Ymax= 1.0;//GetEnergy(2047.0+409.6*4);
            'mobjParameters.XaxisMax = txmax
            'mobjParameters.XaxisMin = txmin
            'mobjParameters.YaxisMax = 0.0
            'mobjParameters.YaxisMin = 1
            'AASGraphs.XAxisMax = txmax
            'AASGraphs.XAxisMin = txmin
            ' AASGraphs.YAxisMax = 1.0
            'AASGraphs.YAxisMin = 0.0

            Call AASGraphs.AldysPane.XAxis.PickScale(AASGraphs.XAxisMin, AASGraphs.XAxisMax)
            Call AASGraphs.AldysPane.YAxis.PickScale(AASGraphs.YAxisMin, AASGraphs.YAxisMax)
            ''for picking X,Y scale from the graph object.
            AASGraphs.XAxisMax = txmax
            AASGraphs.XAxisMin = txmin

            AASGraphs.AldysPane.AxisChange()
            ''change the axis 
            AASGraphs.Invalidate()
            AASGraphs.Refresh()
            Application.DoEvents()
            ''allow application to perfrom it panding work.
            '//-----------------------------------------

            '//------------------------------------------
            'SetInstrumentCondns(hwnd, TRUE);
            'xvalmax = ConvertToNvPos(PeakGraph.Xmax) ;
            'abs = ConvertToFuel(xvalmax) ;
            'xvalmin = ConvertToNvPos(PeakGraph.Xmin) ;
            'abs = ConvertToFuel(xvalmin) ;
            If blnBHOptim = True Then
                ''check for burner optimization flag.
                '---to set instrument conditions
                Call gobjClsAAS203.funcSetInstrumentCondns(True)
                'xvalmax = funcConvertToNvPos(mobjParameters.XaxisMin)
                '---convert x axis max value to nv position.
                xvalmax = gobjClsAAS203.funcConvertToNvPos(AASGraphs.XAxisMax)
                '---convert value to fuel
                abs = gobjClsAAS203.funcConvertToFuel(xvalmax)
                'xvalmin = funcConvertToNvPos(mobjParameters.XaxisMax)
                '---convert x axis min value to nv position.
                xvalmin = gobjClsAAS203.funcConvertToNvPos(AASGraphs.XAxisMin)
                '---convert value to fuel
                abs = gobjClsAAS203.funcConvertToFuel(xvalmin)

                'i= (int )  ((xvalmax-xvalmin)/NVSCANSTEP);
                'i = abs(i)
                i = Fix((xvalmax - xvalmin) / CONST_NVSCANSTEP)
                i = Math.Abs(i)
                'strcpy(PYaxis,"ABS"); strcpy(PXaxis,"Fuel ratio");
                'Show_Peak_Param(hwnd, i);
                'PeakGraph.Xmax=txmin ;
                'PeakGraph.Xmin= txmax;
                'AASGraphs.XAxisMax = txmin
                'AASGraphs.XAxisMin = txmax



                'gobjClsAAS203.funcSetBHPos(txmin)
                'gobjMessageAdapter.CloseStatusMessageBox()
                'gobjMessageAdapter.ShowStatusMessageBox("Burner Height Optimisation", "Burner Height", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 0)
                'lblStatus1.Text = "Burner height optimisation"
                'lblStatus1.Refresh()
                lblStatus1.Text = "Fuel optimisation"
                lblStatus1.Refresh()
                ''show the status on label.
                ' Check the property for interuption from user to terminate the process
                If ThTerminate = True Then
                    'If gobjCommProtocol.funcBreakSpectrum() = False Then
                    'Exit Do
                    'End If
                    ''if terminate flag is true then exit scan.
                    GoTo ExitScan
                End If

                '--- to set fuel   
                gobjClsAAS203.funcSetFuel(txmax)
                ''for setting a fuel.
                Application.DoEvents()
                ''allow application to perfrom its panding
                lMode = gobjInst.Mode
                '---set calibration mode as AA.
                gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.AA)
                Application.DoEvents()
                ''set the calibration mode to AA and allow application to perfrom its panding work.
                Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
                ''communication function for delay
                Application.DoEvents()
                '---convert value to nv scan steps.
                blnStartSpec = gobjCommProtocol.funcNVScanSteps(xvalmin)
                'Procedure Name         :   funcNVScanSteps
                'Description            :   To Optimise the Fuel        
                'Parameters             :   intSteps : turret to be rotate by this num 
                Call gobjCommProtocol.mobjCommdll.subTime_Delay(50)
                ''delay
                xval = xvalmax
                i = 1
                'tout = GetTimeOut();
                'SetTimeOut(VERY_LONG_DEALY);
                If blnStartSpec = True Then
                    gblnInComm = False
                    Do While True
                        If gblnInComm = False Then
                            'If (Recev(False)) Then
                            '		adval= GetParam2()*256 + GetParam1();
                            '                Else
                            '		break;
                            '                    If (adval >= 6000) Then
                            '		break;
                            '#If QDEMO Then
                            '	  adval = 2100+random(20);
                            '#End If

                            '---to receive scanned data.
                            If gobjCommProtocol.funcReceive_ScanData(0, adval) = True Then
                                ''for receiving a scan data
                                'adval = GetParam2() * 256 + GetParam1()
                                'Else
                                'Exit Do

                                'adval = GetParam2() * 256 + GetParam1()
                                'Else
                                If (adval >= 6000) Then
                                    Exit Do
                                End If

                                '--- For Demo Mode
                                '#If QDEMO Then
                                '	  adval = 2100+random(20);
                                '#End If
                                'If gstructSettings.AppMode = EnumAppMode.DemoMode Then
                                If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                                    (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                                    (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                                    ''for demo mode.
                                    adval = 2100 + objRandom.Next(20)
                                End If

                                'abs = GetADConvertedToCurMode(adval);
                                '---convert scanned value to calibration mode value.
                                abs = gFuncGetADConvertedToCurMode(adval)

                                'if (abs > max_abs)    {
                                ' max_abs=abs;
                                ' max_fuel=xval;
                                ' pflag=TRUE;
                                '}
                                If (abs > max_abs) Then
                                    max_abs = abs
                                    max_fuel = xval
                                    pflag = True
                                End If
                                'xfuel=ConvertToFuel(xval);
                                '---convert value to fuel
                                xfuel = gobjClsAAS203.funcConvertToFuel(xval)
                                'sprintf(line1,"(%4.2f, %4.3f) %d (%d-%d)",xfuel, abs, xval, xvalmin, xvalmax);
                                'SetText(hwnd, IDC_STATUS,line1);
                                lblStatus2.Text = "Setting fuel " & Format(xfuel, "####0.00").ToString & " " & Format(abs, "#0.000").ToString & " " & Format(xval, "#0.00").ToString & " " & Format(xvalmin, "#0.00").ToString & " to " & Format(xvalmax, "####0.00").ToString
                                lblStatus2.Refresh()

                                'Start to plot the graph
                                'if (i==1)
                                'GPlotInit(hdc, ConvertToBurnerHeight(xval), abs);
                                'Else
                                'GPlot(hdc,ConvertToBurnerHeight(xval), abs);

                                '---plot a graph of these values
                                mobjThreadController.Display(xfuel & "|" & abs.ToString)

                                xval += CONST_NVSCANSTEP
                                'i++;
                                i += 1
                                If Not (gobjCommProtocol.funcPC_END) Then
                                    Exit Do
                                End If
                            Else
                                Exit Do
                            End If
                        End If
                        Application.DoEvents()
                    Loop
                End If

            End If
ExitScan:
            Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
            If pflag = True Then
                '#If QDEMO Then
                '		Get_NV_Pos();
                '#End If

                lblStatus2.Text = "Optimised at " & Format(gobjClsAAS203.funcConvertToFuel(max_fuel), "####0.00").ToString & " " & Format(max_abs, "#0.000").ToString
                lblStatus2.Refresh()
                lblStatus3.Text = "Positioning to optimised position ..."
                lblStatus3.Refresh()
                Application.DoEvents()
                '//----- Show the peak on graph
                'GShowPeak(hdc,ConvertToFuel(max_fuel),  max_abs, NULL);
                '//-----


                '#If EMU Then
                ' Wait_For_Some_Msg(5);
                '#End If
                'SetFuel(ConvertToFuel(max_fuel));
                '---position nv to optimized fuel condition.
                gobjClsAAS203.funcSetFuel(gobjClsAAS203.funcConvertToFuel(max_fuel))
                lblStatus3.Text = "Position is optimised "
                lblStatus3.Refresh()
            End If
            'Cal_Mode(lMode);
            '---set calibration mode
            gobjCommProtocol.funcCalibrationMode(lMode)

            Application.DoEvents()
            'pc_delay(1500);
            ' SetScanning(FALSE);
            ' SetXoldYold(txold, tyold);
            Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
            Call gobjClsAAS203.subSetXoldYold(inttxold, inttyold)
            Call gobjMessageAdapter.CloseStatusMessageBox()
            Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)

            'gobjMessageAdapter.CloseStatusMessageBox()
            gobjCommProtocol.funcCalibrationMode(lMode)
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
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

#End Region

End Class
