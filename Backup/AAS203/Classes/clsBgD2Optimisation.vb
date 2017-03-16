Imports BgThread
Imports AAS203.Common

Public Class clsBgD2Optimisation
    Implements BgThread.IBgWorker

#Region " Private member Variables "

    Private mobjThreadController As IBgThread
    Private mdblLampCurrent As Double
    Private mintLampPosition As Integer
    Private mlblObjWV_ABS As System.Object
    Private mlblObjStatus As System.Object
    Private mdblMinWavelength As Double
    Private mdblMaxWavelength As Double
    Private mdblYMaxValue As Double
    Private mdblYMinValue As Double
    Private mIsPeak486Performed As Boolean = False
    Private mIsPeak656Performed As Boolean = False
    Private mblnUVFlag As Boolean = False
    Private mblnThTerminate As Boolean = False

#End Region

#Region " Public Property "

    Public Property ThTerminate() As Boolean
        ''---this is hold terminate flag.
        Get
            Return mblnThTerminate
        End Get
        Set(ByVal Value As Boolean)
            mblnThTerminate = Value
        End Set
    End Property

    Public ReadOnly Property IsPeak486Performed() As Boolean
        Get
            Return mIsPeak486Performed
        End Get
    End Property

    Public ReadOnly Property IsPeak656Performed() As Boolean
        Get
            Return mIsPeak656Performed
        End Get
    End Property

#End Region

#Region " Constructors "

    Public Sub New()
        MyBase.New()

    End Sub

    Public Sub New(ByRef lblObjStatusIn As System.Object, ByRef lblObjWV_ABSIn As System.Object)
        MyBase.New()
        mlblObjStatus = lblObjStatusIn
        mlblObjWV_ABS = lblObjWV_ABSIn
    End Sub

#End Region

#Region " Public Events, Constants .. "

    Public Event SpectrumStatus(ByVal strLine1 As String)

#End Region

#Region " Public Functions "

    Public Sub Initialize(ByVal Controller As BgThread.IBgThread) Implements BgThread.IBgWorker.Initialize
        '=====================================================================
        ' Procedure Name        : Initialize
        ' Parameters Passed     : 
        ' Returns               : 
        ' Purpose               : To Initialize the worker thread
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 26-Dec-2006
        ' Revisions             : 1
        '=====================================================================
        mobjThreadController = Controller
    End Sub

    Public Sub StartWorkerThread() Implements BgThread.IBgWorker.Start
        '=====================================================================
        ' Procedure Name        : StartWorkerThread
        ' Parameters Passed     : 
        ' Returns               : 
        ' Purpose               : To Start the worker thread
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 29.11.06
        ' Revisions             : 
        '=====================================================================
        Dim blnCancel As Boolean = False
        Dim objwait As New CWaitCursor
        Try
            '//----- Added by Sachin Dokhale on 25.03.07
            '//----- To know the Status of Thread on Status Bar of MDI Main
            Dim strPreviousStatusMessage As String
            If gblnShowThreadOnfrmMDIStatusBar Then
                strPreviousStatusMessage = gobjMain.StatusBar1.Text
                gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage & " *D2 Opti"
                Application.DoEvents()
            End If
            '//-----
            Do While (blnCancel = False)
                If mobjThreadController.Running Then
                    'funcThreadSpectrum(mdblLampCurrent, mintLampPosition)

                    funcThreadD2Peak(mlblObjStatus, mlblObjWV_ABS, mblnUVFlag)
                    gobjCommProtocol.mobjCommdll.subTime_Delay(100)
                    blnCancel = True

                    'End If
                Else
                    'Client requested a cancel

                    blnCancel = True
                    mobjThreadController.Completed(True)
                    '//----- Added by Sachin Dokhale on 25.03.07
                    '//----- To remove the Status of Thread on Status Bar of MDI Main
                    If gblnShowThreadOnfrmMDIStatusBar Then
                        gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage
                        Application.DoEvents()
                    End If
                    '//-----
                    Exit Sub
                End If

                'gobjCommProtocol.mobjCommdll.subTime_Delay(100)
            Loop
            blnCancel = True
            If mobjThreadController.Running = True Then
                mobjThreadController.Completed(True)
            Else
                mobjThreadController.Completed(False)
            End If
            '//----- Added by Sachin Dokhale on 25.03.07
            '//----- To remove the Status of Thread on Status Bar of MDI Main
            If gblnShowThreadOnfrmMDIStatusBar Then
                gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage
                Application.DoEvents()
            End If
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

    Private Function funcThreadD2Peak(ByRef lblObjStatusIn As System.Object, _
                                      ByRef lblObjWV_ABSIn As System.Object, _
                                      ByVal blnUVFlag As Boolean) As Boolean
        '------------------------------------------------------------------
        'Procedure Name         :   funcThreadD2Peak
        'Description            :   search D2 Peak
        'Parameters             :   blnUVFlag check UV bool flag
        'Parameters Affected    :   lblObjStatusIn ,lblObjWV_ABSIn as label
        'Time/Date              :   5/10/06
        'Dependencies           :   
        'Author                 :   Sachin Dokhale.
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        '------------------------------------------------

        '------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim dblYNew As Double
        Dim blYasisReading As Double
        Dim blnStartSpec As Boolean
        Dim intIniMode As Integer
        Dim MAXSIZE As Integer
        Dim intsamp_adcCounter As Integer
        '//----- Added new 
        Dim blnFlag As Boolean = False
        'Dim blnUVFlag As Boolean = False
        Try

            Application.DoEvents()

            Dim objWait1 As New CWaitCursor
            '//----- 1  Set Wv '& Abs/En
            gobjInst.D2Pmt = 0
            lblObjStatusIn.Text = "Wavelength Positioning : "
            lblObjStatusIn.Refresh()
            ' set UV Spectrum contions for 480nm.
            gobjClsAAS203.funcSetRest_uvs_Condn(480.0, False, lblObjWV_ABSIn, blnUVFlag)
            ' Check the property for interuption from user to terminate the process
            If ThTerminate = True Then
                funcThreadD2Peak = True
                Exit Function
            End If
            Application.DoEvents()
            'Start to detect D2 peak for 480
            blnFlag = funcGetD2Peaks(480.0, 490.0, blnUVFlag, lblObjWV_ABSIn)
            'Application.DoEvents()
            gobjCommProtocol.mobjCommdll.subTime_Delay(100)
            'Send the flag for changeing peak from 480nm  to 565nm.
            mobjThreadController.Display(CStr(0) & "|" & CStr(0) & "|" & CInt(1).ToString & "|" & CInt(1).ToString)
            'Application.DoEvents()
            ' Terminate the process if user interupts 
            If ThTerminate = True Then
                funcThreadD2Peak = True
                Exit Function
            End If
            If (blnFlag = True) Then
                mIsPeak486Performed = True
                'Application.DoEvents()
                'Start to detect D2 peak for 656nm when 480nm peak is detect.
                blnFlag = funcGetD2Peaks(650.0, 660.0, blnUVFlag, lblObjWV_ABSIn)
            End If


            If (blnFlag = False) Then
                'gobjMessageAdapter.ShowMessage(constD2Peak)
            Else
                mIsPeak656Performed = True
                'gobjMessageAdapter.ShowMessage("D2 peaks found", "D2 Peaks", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
            End If

            'Application.DoEvents()
            'gobjCommProtocol.mobjCommdll.subTime_Delay(50)

            ' set UV Spectrum contions for 200nm.
            gobjClsAAS203.funcSetRest_uvs_Condn(200.0, False, lblObjWV_ABSIn, blnUVFlag)
            Application.DoEvents()
            '========================================================================

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
            ThTerminate = False
            Application.DoEvents()
        End Try
    End Function

    Private Function funcGetD2Peaks(ByVal dblXMin As Double, _
                                    ByVal dblXMax As Double, ByVal blnUVFlag As Boolean, _
                                    ByRef lblWv As Object, Optional ByRef lblobjStatus As Object = Nothing _
                                    ) As Boolean

        '------------------------------------------------------------------
        'Procedure Name         :   funcGetD2Peaks
        'Description            :   Detect D2 peak for desire wavelength  
        'Parameters             :   Min X and max X value is Wv., lblWv is text object to display status,
        'Return                 :   Return true value if success or false when Terminate
        'Time/Date              :   5/10/06
        'Dependencies           :   
        'Author                 :   Sachin Dokhale.
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------

        'BOOL	GetD2Peaks(HWND hwnd, double xmin, double xmax, int type)
        '{
        'HDC		hdc;
        '#If !D2PRINT Then
        'int		*arr;
        '#End If
        'int		i, n,tavg=0;
        'int		ymin, ymax, ioff;
        'BOOL		flag=FALSE;
        'char		str[40]="";
        'float stepspernm=50.0;
        'if (GetInstrument()==AA202)
        ' stepspernm = STEPS_PER_NM_AA202;
        '        Else
        ' stepspernm = STEPS_PER_NM;

        ' hdc = GetDC(hwnd);
        ' InitGraphParam1(hwnd, type);
        ' SetText(hwnd, IDC_STATUS," D2 Peak search ...");
        ' strcpy(PYaxis,"Energy");
        ' strcpy(PXaxis,"Wv");
        ' Cal_Mode(D2E);
        ' Wavelength_Position(hdc, xmin,5, 150);

        ' PeakGraph.Xmin=xmin;
        ' PeakGraph.Xmax=xmax;
        ' if (GetInstrument()==AA202)
        '//n = (xmax-xmin)*(stepspernm/SLOWSTEP_AA202)+1;
        '  n = (xmax-xmin)*(stepspernm)+1;
        '            Else
        '  n = (xmax-xmin)*(stepspernm/SLOWSTEP)+1;
        ' Calculate_Peak_Param(&PeakGraph, n);
        ' Display_Peak_Graph_Param1(hdc, &PeakGraph, type);
        '#If D2PRINT Then
        ' if(type)
        '  arr1 = (int *) malloc(sizeof(int)*n);
        ' else
        ' arr = (int *) malloc(sizeof(int)*n);
        '#Else
        ' arr = (int *) malloc(sizeof(int)*n);
        '#End If
        ' if(GetInstrument() == AA202 ){
        '	 tavg = Inst->Avg;
        '	 Inst->Avg = 100;
        ' }
        ' if (arr !=NULL) {
        '  arr[0] = ReadADCFilter();
        '  ymin = 4096;
        '  ymax=0;
        '  for (i=1; i<n; i++)  {
        '	  if (GetInstrument()==AA202){
        '//		 Rotate_Wv_Clock_Steps(SLOWSTEP_AA202); // for (j=1; j<=5; j++)    rotate_clock();
        '		Rotate_Clock_Wv();
        '	  }
        '                            Else
        '		 Rotate_Wv_Clock_Steps(SLOWSTEP); // for (j=1; j<=5; j++)    rotate_clock();

        '	 arr[i] = ReadADCFilter();
        '	 if(GetInstrument()==AA202)
        '		 sprintf(str,"%4.3f ,%4.2f", PeakGraph.Xmin+(double)i*(double)SLOWSTEP_AA202/(double)stepspernm,GetEnergy(arr[i]));
        '                                Else
        '	 sprintf(str,"%4.3f ,%4.2f", PeakGraph.Xmin+(double)i*(double)SLOWSTEP/(double)stepspernm,GetEnergy(arr[i]));
        '	 SetText(hwnd, IDC_STATUS1,str);
        '	}
        '	for (i=0; i<n; i++){
        '	  if (arr[i]>ymax) {
        '		  ymax = arr[i];
        '		  ioff=i;
        '		  flag=TRUE;
        '		  }
        '	  if (arr[i]<ymin) ymin = arr[i];
        '		 }
        '	PeakGraph.Ymax=  GetEnergy(ymax+8.192);
        '	PeakGraph.Ymin=  GetEnergy(ymin-4.096);
        '	for (i=0; i<n; i++)  {
        '	 if (i==0){
        '		if (GetInstrument()==AA202)
        '			 GPlotInit(hdc, PeakGraph.Xmin+( (double)((i+1)*SLOWSTEP_AA202)/(double) stepspernm),
        '			 GetEnergy(arr[i]));
        '                                                        Else
        '			 GPlotInit(hdc, PeakGraph.Xmin+( (double)((i+1)*SLOWSTEP)/(double) stepspernm),
        '			 GetEnergy(arr[i]));

        '	 }
        '	 else{
        '		if (GetInstrument()==AA202)
        '			GPlot(hdc, PeakGraph.Xmin+ (((double)(i+1)*SLOWSTEP_AA202)/(double) stepspernm),
        '				GetEnergy(arr[i]));
        '                                                            Else
        '			GPlot(hdc, PeakGraph.Xmin+ (((double)(i+1)*SLOWSTEP)/(double) stepspernm),
        '				GetEnergy(arr[i]));
        '	 }
        '	 }
        '	if (flag){
        '	  if (GetInstrument()==AA202)
        '		 GShowPeak(hdc,PeakGraph.Xmin+ ( ((double)(ioff+1)*SLOWSTEP_AA202)/(double) stepspernm),
        '					GetEnergy(ymax),NULL);
        '                                                                    Else
        '		 GShowPeak(hdc,PeakGraph.Xmin+ ( ((double)(ioff+1)*SLOWSTEP)/(double) stepspernm),
        '					GetEnergy(ymax),NULL);

        '	}
        '#If !D2PRINT Then
        '	free(arr); arr=NULL; // removed by sss for printing the d2 peaks
        '#End If
        '  }
        ' ReleaseDC(hwnd, hdc);
        ' if(GetInstrument() == AA202 )
        '	 Inst->Avg= tavg;
        '#If D2PRINT Then
        ' OnD2Print();
        ' if(arr){
        ' free(arr); arr=NULL;
        ' }
        ' if(arr1){
        ' free(arr1); arr1=NULL;
        ' }
        '#End If
        ' return flag;
        '}
        '//---------
        Dim lngN_Wv As Long
        Dim intTmpAvg As Integer = 0.0
        Dim dblReadWv As Double
        Dim dblReadYValue As Double
        Dim intTimeDelay As Integer = 20
        '         if (GetInstrument()==AA202)
        '//n = (xmax-xmin)*(stepspernm/SLOWSTEP_AA202)+1;
        '  n = (xmax-xmin)*(stepspernm)+1;
        '        Else
        lblWv.Text = "Wavelength Positioning "
        lblWv.Refresh()
        'Set the D2E Calibration Mode
        gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.D2E)
        ' Set Wv. position with X min (Wv.) value
        gobjCommProtocol.Wavelength_Position(dblXMin, lblWv)

        lblWv.Text = ""
        lblWv.Refresh()
        ' Calculate total diff. of steps bt'n from X(Wv.) min and X(Wv.) max 
        If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
            lngN_Wv = (dblXMax - dblXMin) * (CONST_STEPS_PER_NM_AA201 / CONST_SLOWStep_AA201) + 1
        Else
            lngN_Wv = (dblXMax - dblXMin) * (CONST_STEPS_PER_NM / CONST_SLOWStep) + 1
        End If


        'if(GetInstrument() == AA202 ){
        ' tavg = Inst->Avg;
        ' Inst->Avg = 100;
        '}
        'Set instrument  Avg count is set to 100 for 201
        If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
            intTmpAvg = gobjInst.Average
            gobjInst.Average = 100
        End If

        'if (arr !=NULL) {
        Dim lngWvIndex As Long
        If (lngN_Wv > 0) Then
            'arr[0] = ReadADCFilter();
            'mobjThreadController.Display(dblXaxisTime1.ToString & "|" & dblAbs.ToString)
            'ymin = 4096;
            'ymax=0;


            Application.DoEvents()
            '//----- Move Wv position tilllngN_Wv
            For lngWvIndex = 0 To lngN_Wv - 1
                '                if (GetInstrument()==AA202){
                '//		 Rotate_Wv_Clock_Steps(SLOWSTEP_AA202); // for (j=1; j<=5; j++)    rotate_clock();
                '		Rotate_Clock_Wv();
                '	  }
                '                Else
                ''		 Rotate_Wv_Clock_Steps(SLOWSTEP); // for (j=1; j<=5; j++)    rotate_clock();
                '//----- Commented by Sachin Dokhale on 03.02.07
                'Call gobjCommProtocol.funcRotate_Wv_Clock_Steps(CONST_SLOWStep)
                '//-----
                'sprintf(str,"%4.3f ,%4.2f", PeakGraph.Xmin+(double)i*(double)SLOWSTEP/(double)stepspernm,GetEnergy(arr[i]));
                'dblReadWv = dblXMin + (lngWvIndex * CONST_SLOWStep / CONST_STEPS_PER_NM)
                ' Check the property for interuption from user to terminate the process
                If ThTerminate = True Then
                    Exit For
                End If
                ' Calulate the Wv. steps for 201
                If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                    ' Move the Wv. postion to the lock wise with slow steps for 201
                    Call gobjCommProtocol.funcRotate_Wv_Clock_Steps(CONST_SLOWStep_AA201)
                    ' Calculate the Wv for next steps
                    dblReadWv = dblXMin + (lngWvIndex * CONST_SLOWStep_AA201 / CONST_STEPS_PER_NM_AA201)
                Else
                    ' Calulate the Wv. steps for not 201
                    ' Move the Wv. postion to the lock wise with slow steps 
                    Call gobjCommProtocol.funcRotate_Wv_Clock_Steps(CONST_SLOWStep)
                    ' Calculate the Wv for next steps
                    dblReadWv = dblXMin + (lngWvIndex * CONST_SLOWStep / CONST_STEPS_PER_NM)
                End If

                'gobjCommProtocol.mobjCommdll.subTime_Delay(1)
                'Call gobjCommProtocol.funcReadADCFilter(10, dblReadYValue)
                Call gobjCommProtocol.mobjCommdll.subTime_Delay(intTimeDelay)
                ' Read ADC Filter value from Inst. and return to main program.
                Call gobjCommProtocol.funcReadADCFilter(gobjInst.Average, dblReadYValue)
                mobjThreadController.Display(dblReadWv.ToString & "|" & dblReadYValue.ToString & "|" & CInt(mIsPeak486Performed).ToString & "|" & CInt(mIsPeak656Performed).ToString)
                'Application.DoEvents()
            Next

        End If
        'Set Inst. Avg. count with previousely stored value 
        If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
            gobjInst.Average = intTmpAvg
        End If

        Return True
    End Function

#End Region

End Class
