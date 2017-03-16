Option Strict Off
Imports BgThread
Imports AAS203.Common
Imports System.IO

Public Class clsBgSpectrum
    Implements BgThread.IBgWorker

#Region " Private Variables "

    Private mblnIsDemoFileOpened As Boolean = False

    'Private mlblObjWV_ABS As System.Object
    'Private mlblObjAbs_RefBeam_ABS As System.Object
    'Private mlblObjABS_DoubleBeam As System.Object
    'Private mlblObjStatus As System.Object
    Private mlblObjWV_ABS As Label
    Private mlblObjAbs_RefBeam_ABS As Label
    Private mlblObjABS_DoubleBeam As Label
    Private mlblObjStatus As Label

    Private mblnIsRefBeamSelected As Boolean
    Private mintMode As Integer
    Private mintSpeed As Integer
    Private mdblMinWavelength As Double
    Private mdblMaxWavelength As Double
    Private mdblYMaxValue As Double
    Private mdblYMinValue As Double
    Private mbln_BaseLine As Boolean
    Private mdblAbsScanthldval As Double
    Private mblnCheckMinAbsScanLmt As Boolean
    Private mCheckAbsLimit As Boolean = True

    Private mobjThreadController As IBgThread
    Private mdblLampCurrent As Double
    Private mintLampPosition As Integer

    Private mblnSpectrumWait As Boolean = False
    Private mblnThTerminate As Boolean = False

    Private Const const_Absorbance = "Absorbance: "
    Private Const const_Energy = "Energy: "
    Private Const const_Emission = "Emission: "
    Private Const const_Volt = "Volt(mv): "

    Private mYValueLable As String = const_Absorbance
    Private mXValueLable As String = "Wavelength (nm): "
    Private blnResetFilterData As Boolean
    Dim mblnEndProcess As Boolean = False
#End Region

#Region " Public Property "

    Public Property ThTerminate() As Boolean
        Get
            Return mblnThTerminate
        End Get
        Set(ByVal Value As Boolean)
            mblnThTerminate = Value
            mblnSpectrumWait = Value
        End Set
    End Property

    Public Property SpectrumWait() As Boolean
        Get
            Return mblnSpectrumWait
        End Get
        Set(ByVal Value As Boolean)
            mblnSpectrumWait = Value
        End Set
    End Property

    Public Property EndProcess() As Boolean
        Get
            Return mblnEndProcess
        End Get
        Set(ByVal Value As Boolean)
            mblnEndProcess = Value
        End Set
    End Property

    Public Property CheckAbsLimit() As Boolean
        Get
            Return mCheckAbsLimit
        End Get
        Set(ByVal Value As Boolean)
            mCheckAbsLimit = Value
        End Set
    End Property

#End Region

#Region " Public Events "

    Public Event SpectrumStatus(ByVal strLine1 As String)

#End Region

#Region " Constructors "

    Public Sub New()
        MyBase.New()
        ThTerminate = False
        SpectrumWait = False
    End Sub

    Public Sub New(ByRef lblObjStatusIn As System.Object, ByRef lblObjWV_ABSIn As System.Object, _
                   ByVal dblXMax As Double, ByVal dblXMin As Double, _
                   ByVal dblYMax As Double, ByVal dblYMin As Double, _
                   ByVal intMode As Integer, ByVal intSpeed As Double, _
                   Optional ByVal blnBaseLine As Boolean = False)
        '=====================================================================
        ' Procedure Name        : New 
        ' Parameters Passed     : dblXMax, dblXMin, dblYMax, dblYMin, intMode, intSpeed ,blnBaseLine
        ' Parameter Affected    : lblObjStatusIn,lblObjWV_ABSIn
        ' Returns               : None
        ' Purpose               : New [Constructor]
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.12.06
        ' Revisions             : 
        '=====================================================================
        MyBase.New()
        mlblObjStatus = lblObjStatusIn
        mlblObjWV_ABS = lblObjWV_ABSIn
        mdblMaxWavelength = dblXMax
        mdblMinWavelength = dblXMin
        mdblYMinValue = dblYMin
        mdblYMaxValue = dblYMax
        mintMode = intMode
        mintSpeed = intSpeed
        mbln_BaseLine = blnBaseLine
        ThTerminate = False
        SpectrumWait = False

        'added by deepak on 20.10.08
        mdblAbsScanthldval = gstructSettings.AbsThresholdValue
        mblnCheckMinAbsScanLmt = gstructSettings.SetMinAbsLimit

    End Sub

    '--added new constructor by deepak on 20.07.07
    Public Sub New(ByRef lblObjStatusIn As Label, ByRef lblObjWV_ABSIn As Label, _
                  ByVal dblXMax As Double, ByVal dblXMin As Double, _
                  ByVal dblYMax As Double, ByVal dblYMin As Double, _
                  ByVal intMode As Integer, ByVal intSpeed As Double, _
                  ByVal intNothing As Double, ByVal blnIsRef As Boolean, Optional ByVal blnBaseLine As Boolean = False)
        '=====================================================================
        ' Procedure Name        : New 
        ' Parameters Passed     : dblXMax, dblXMin, dblYMax, dblYMin, intMode, intSpeed,
        '                         blnIsRef, blnBaseLine
        ' Parameter Affected    : lblObjStatusIn,lblObjWV_ABSIn
        ' Returns               : None
        ' Purpose               : New [Constructor]
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : deepak
        ' Created               : 21.12.06
        ' Revisions             : 
        '=====================================================================

        MyBase.New()
        mlblObjStatus = lblObjStatusIn
        mlblObjWV_ABS = lblObjWV_ABSIn
        mdblMaxWavelength = dblXMax
        mdblMinWavelength = dblXMin
        mdblYMinValue = dblYMin
        mdblYMaxValue = dblYMax
        mintMode = intMode
        mintSpeed = intSpeed
        mbln_BaseLine = blnBaseLine
        ThTerminate = False
        SpectrumWait = False
        mblnIsRefBeamSelected = blnIsRef

        'added by deepak on 20.10.08
        mdblAbsScanthldval = gstructSettings.AbsThresholdValue
        mblnCheckMinAbsScanLmt = gstructSettings.SetMinAbsLimit

    End Sub

    Public Sub New(ByRef lblObjStatusIn As Label, ByRef lblObjWV_ABSIn As Label, _
                   ByVal dblXMax As Double, ByVal dblXMin As Double, _
                   ByVal dblYMax As Double, ByVal dblYMin As Double, _
                   ByVal intMode As Integer, ByVal intSpeed As Double, _
                   ByVal dblAbsScanthldval As Double, ByVal blnCheckMinAbsScanLmt As Double)
        '=====================================================================
        ' Procedure Name        : New 
        ' Parameters Passed     : dblXMax, dblXMin, dblYMax, dblYMin, intMode, intSpeed,
        '                         blnIsRef, blnBaseLine
        ' Parameter Affected    : lblObjStatusIn,lblObjWV_ABSIn
        ' Returns               : None
        ' Purpose               : New [Constructor]
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : deepak
        ' Created               : 21.12.06
        ' Revisions             : 
        '=====================================================================

        MyBase.New()

        mlblObjStatus = lblObjStatusIn
        mlblObjWV_ABS = lblObjWV_ABSIn
        mdblMaxWavelength = dblXMax
        mdblMinWavelength = dblXMin
        mdblYMinValue = dblYMin
        mdblYMaxValue = dblYMax
        mintMode = intMode
        mintSpeed = intSpeed
        mbln_BaseLine = False
        mdblAbsScanthldval = dblAbsScanthldval
        mblnCheckMinAbsScanLmt = blnCheckMinAbsScanLmt
        gintSpectrumMode = modGlobalDeclarations.EnumSpectrumMode.TimeScan
        ThTerminate = False
        SpectrumWait = False

    End Sub

#End Region

#Region " Public Functions "

    Public Sub Initialize(ByVal Controller As BgThread.IBgThread) Implements BgThread.IBgWorker.Initialize
        mobjThreadController = Controller
    End Sub

    Public Sub StartWorkerThread() Implements BgThread.IBgWorker.Start
        '=====================================================================
        ' Procedure Name        : StartWorkerThread
        ' Parameters Passed     :  
        ' Returns               : BgThread.IBgWorker.Start
        ' Purpose               : Start to thread process.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.12.06
        ' Revisions             : 
        '=====================================================================
        Dim blnCancel As Boolean = False
        Dim objwait As New CWaitCursor
        Dim strPreviousStatusMessage As String
        ''note:
        ''this is a main function which called by thread.
        Try
            If Not IsNothing(gobjMain) Then
                strPreviousStatusMessage = gobjMain.StatusBarPanelInfo.Text
            End If
            ThTerminate = False
            mblnEndProcess = True
            Do While (blnCancel = False)
                If mobjThreadController.Running Then
                    'funcThreadSpectrum(mdblLampCurrent, mintLampPosition)
                    If gintSpectrumMode = modGlobalDeclarations.EnumSpectrumMode.EnergySpectrum Then
                        '//----- Added by Sachin Dokhale on 25.03.07
                        '//----- To know the Status of Thread on Status Bar of MDI Main

                        If gblnShowThreadOnfrmMDIStatusBar Then
                            If Not IsNothing(gobjMain) Then
                                gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage & " *Energy Spec"
                            End If
                            Application.DoEvents()
                        End If
                        '//-----
                        If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
                            'added by deepak on 20.07.07

                            ''check a cond for double beam.
                            funcThreadDBEnergySpectrum_AccToBeamSelection(mlblObjStatus, mlblObjWV_ABS, mdblMaxWavelength, _
                                                                                               mdblMinWavelength, mdblYMaxValue, mdblYMinValue, _
                                                                                               mintMode, mintSpeed, 0, mblnIsRefBeamSelected)
                        Else
                            funcThreadEnergySpectrum(mlblObjStatus, mlblObjWV_ABS, mdblMaxWavelength, _
                                       mdblMinWavelength, mdblYMaxValue, mdblYMinValue, _
                                       mintMode, mintSpeed, 0)

                            ''this will start the energy as par given parameter
                            ''for eg mintSpeed is for spectrum speed.
                        End If
                        blnCancel = True

                    ElseIf gintSpectrumMode = modGlobalDeclarations.EnumSpectrumMode.UVSpetrum Then
                        '//----- Added by Sachin Dokhale on 25.03.07
                        '//----- To know the Status of Thread on Status Bar of MDI Main
                        If gblnShowThreadOnfrmMDIStatusBar Then
                            If Not IsNothing(gobjMain) Then
                                gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage & " *UV Spec"
                            End If
                            Application.DoEvents()
                            ''allow application to perfrom its panding work between 
                            ''the thread.
                        End If
                        '//-----
                        funcThreadUVSpectrum(mlblObjStatus, mlblObjWV_ABS, mdblMaxWavelength, _
                                       mdblMinWavelength, mdblYMaxValue, mdblYMinValue, _
                                       mintMode, mintSpeed, 0, mbln_BaseLine)
                        ''this will start a UV spectrum 

                        'End If
                        blnCancel = True

                    ElseIf gintSpectrumMode = modGlobalDeclarations.EnumSpectrumMode.TimeScan Then
                        '//----- Added by Sachin Dokhale on 25.03.07
                        '//----- To know the Status of Thread on Status Bar of MDI Main
                        If gblnShowThreadOnfrmMDIStatusBar Then
                            If Not IsNothing(gobjMain) Then
                                gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage & " *TimeScan"
                            End If
                            Application.DoEvents()
                        End If
                        '//-----
                        blnResetFilterData = True
                        If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
                            funcThreadDBAbsTimeScan(mlblObjStatus, mlblObjWV_ABS, mdblMaxWavelength, _
                                           mdblMinWavelength, mdblYMaxValue, mdblYMinValue, _
                                           mintMode, mdblAbsScanthldval, mblnCheckMinAbsScanLmt)
                        Else

                            funcThreadAbsTimeScan(mlblObjStatus, mlblObjWV_ABS, mdblMaxWavelength, _
                                           mdblMinWavelength, mdblYMaxValue, mdblYMinValue, _
                                           mintMode, mdblAbsScanthldval, mblnCheckMinAbsScanLmt)
                        End If
                        blnCancel = True
                    End If
                Else
                    'Client requested a cancel

                    blnCancel = True
                    '//----- Added by Sachin Dokhale on 25.03.07
                    '//----- To remove the Status of Thread on Status Bar of MDI Main
                    If gblnShowThreadOnfrmMDIStatusBar Then
                        If Not IsNothing(gobjMain) Then
                            gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage
                        End If
                        Application.DoEvents()
                    End If
                    '//-----
                    Exit Sub
                End If

            Loop
            blnCancel = True
            If mobjThreadController.Running = True Then
                '//----- modified by Sachin Dokhale on 01.09.07
                If gintSpectrumMode = modGlobalDeclarations.EnumSpectrumMode.UVSpetrum Then
                    ' Check the property for interuption from user to terminate the process
                    If ThTerminate = True Then
                        mobjThreadController.Completed(False)
                    Else
                        mobjThreadController.Completed(True)
                    End If
                Else
                    mobjThreadController.Completed(True)
                End If
                '//------
            Else
            End If
            '//----- Added by Sachin Dokhale on 25.03.07
            '//----- To remove the Status of Thread on Status Bar of MDI Main
            If gblnShowThreadOnfrmMDIStatusBar Then
                If Not IsNothing(gobjMain) Then
                    gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage
                End If
                Application.DoEvents()
                ''allow application to perfrom its panding work.
            End If
            '//-----
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            'mobjThreadController.Failed(ex)
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

#Region " Private Functions "

#Region " Sample Beam "
    Private Function funcThreadEnergySpectrum(ByRef lblObjStatusIn As Label, _
                                        ByRef lblObjWV_ABSIn As Label, _
                                        ByVal dblXMax As Double, _
                                        ByVal dblXMin As Double, _
                                        ByVal dblYMax As Double, _
                                        ByVal dblYMin As Double, _
                                        ByVal intMode As Integer, _
                                        ByVal intSpeed As Integer, _
                                        ByVal intCounter As Integer) As Boolean
        '------------------------------------------------------------------
        'Procedure Name         :   funcThreadEnergySpectrum
        'Description            :   To Start the Spectrum
        'Parameters             :   dblLampCurrent = current to be set to lamp
        '                           intLampPos = lamp position to which current to be set
        'Time/Date              :   5/10/06
        'Dependencies           :   
        'Author                 :   Sachin Dokhale.
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        '------------------------------------------------
        '        void		OnSpect(HWND	hwnd, BOOL BaseLine)
        '{
        'HDC	hdc;

        'WP1=-1;
        ' addata.Saved=FALSE;;
        ' disp_Cur_wv_abs(hwnd);
        ' hdc= GetDC(hwnd);

        ' Wavelength_Position(hdc,SpectGraph.Xmin, 20, 372 );
        ' if (UVS){

        '	if (!UVABS){
        '	  UVABS=TRUE;
        '	  SpectGraph.Ymin = 0;
        '	  SpectGraph.Ymax = 1.0;
        '	  Scroll_Mode1(hwnd,IDC_MODE, -1 );
        '	 }

        '	if (Inst->d2Pmt==0){
        '		Adj_D2Gain(hwnd, TRUE, 15, 372);
        '		Wavelength_Position(hdc,SpectGraph.Xmin, 20, 372 );
        '	  }
        '	UvSpectReading(hwnd, hdc, BaseLine);
        '  }
        '                Else

        '	Transmit(CONNECT_SPL, (BYTE)0, (BYTE) 0, (BYTE) 0);
        '                    If (Recev(True)) Then
        '	{
        '	SpectReading(hwnd, hdc);
        '	Wavelength_Position(hdc,SpectGraph.Xmin, 20, 372 );
        '	}
        '	Transmit(CONNECT_REF, (BYTE)0, (BYTE) 0, (BYTE) 0);
        '                        If (Recev(True)) Then
        '	{
        '	  SpectReadingRef(hwnd, hdc);
        '	  Wavelength_Position(hdc,SpectGraph.Xmin, 20, 372 );
        '	  Transmit(CONNECT_SPL, (BYTE)0, (BYTE) 0, (BYTE) 0);
        '                            If (Recev(True)) Then
        '	  {
        '	  }
        '	}

        ' ReleaseDC(hwnd,hdc);
        ' disp_Cur_wv_abs(hwnd);
        '}
        '------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim dblWv As Double
        Dim dblYNew As Double
        Dim dblYNew1 As Double
        Dim blYasisReading As Double
        Dim blnStartSpec As Boolean
        Dim intSpeedIncrease As Integer
        Dim intIniMode As Integer
        Dim dblCurrWv As Double
        Dim intSetpsPernm As Integer = 50
        Dim dblWvMin As Double
        Dim intTimeDelay As Integer = 40
        Dim objOpenFile As OpenFileDialog  '---16.03.08
        Dim objchannel As Spectrum.Channel  '---16.03.08
        Try
            Dim objWait1 As New CWaitCursor
            Application.DoEvents()
            '//----- 1  Set Wv '& Abs/En

            dblWvMin = dblXMin
            mXValueLable = "Wavelength (nm): "
            Select Case gobjInst.Mode
                Case EnumCalibrationMode.AA
                    mYValueLable = const_Absorbance
                Case EnumCalibrationMode.AA, EnumCalibrationMode.AABGC, EnumCalibrationMode.MABS
                    mYValueLable = "Absorbance : "
                Case EnumCalibrationMode.HCLE, EnumCalibrationMode.D2E
                    mYValueLable = const_Energy
                Case EnumCalibrationMode.EMISSION
                    mYValueLable = const_Emission
                Case EnumCalibrationMode.SELFTEST
                    mYValueLable = const_Volt
            End Select

            '//----- Display Current Wavelength
            If gblnIsDemoWithRealData = False Then   '16.03.08
                If gobjCommProtocol.funcGet_Current_Wv(dblCurrWv) = True Then
                    'mobjThreadController.Display(dblCurrWv.ToString & "|" & "0.0")
                    lblObjStatusIn.Text = mXValueLable & dblCurrWv.ToString
                    lblObjStatusIn.Refresh()
                    lblObjWV_ABSIn.Text = mYValueLable & "0.0"
                    lblObjWV_ABSIn.Refresh()
                Else
                    'mobjThreadController.Display("Error" & "|" & "0.0")
                    lblObjStatusIn.Text = mXValueLable
                    lblObjStatusIn.Refresh()
                    lblObjWV_ABSIn.Text = mYValueLable
                    lblObjWV_ABSIn.Refresh()
                End If
            End If

            '//----------------
            ' Set wv. position 
            If gblnIsDemoWithRealData = False Then   '16.03.08
                gobjCommProtocol.Wavelength_Position(dblWvMin, lblObjStatusIn)
            End If
            'gobjCommProtocol.mobjCommdll.subTime_Delay(80)

            ' Check the property for interuption from user to terminate the process
            If ThTerminate = True Then
                GoTo ExitSpectrum
            End If

            '--- 3. Set the Speed
            intCounter = 0
            '//----- Set cal. Mode
            intIniMode = gobjInst.Mode
            gobjInst.Mode = intMode
            '//---------------

            If gblnIsDemoWithRealData = False Then   '16.03.08
                '--- Display Current Wavelength
                If gobjCommProtocol.funcGet_Current_Wv(dblCurrWv) = True Then
                    'mobjThreadController.Display(dblCurrWv.ToString & "|" & "0.0")
                    lblObjStatusIn.Text = mXValueLable & dblCurrWv.ToString
                    lblObjStatusIn.Refresh()
                    lblObjWV_ABSIn.Text = mYValueLable & "0.0"
                    lblObjWV_ABSIn.Refresh()
                Else
                    'mobjThreadController.Display("Error" & "|" & "0.0")
                    lblObjStatusIn.Text = mXValueLable
                    lblObjStatusIn.Refresh()
                    lblObjWV_ABSIn.Text = mYValueLable
                    lblObjWV_ABSIn.Refresh()
                End If
                '//----------------
            End If
            
            '---4. Cal. Wv & Abs/En
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                intSetpsPernm = CONST_STEPS_PER_NM_AA201       'CONST_STEPS_PER_NM 
            Else
                intSetpsPernm = CONST_STEPS_PER_NM
            End If

            '--- calculate Max Wv. stpes
            dblWv = dblXMax * CDbl(intSetpsPernm) + 0.1
            '--- Check Wv sptes is greater than sptes per NM 
            If dblWv >= CDbl(intSpeed) Then
                'dblWv =  dblXMax * intSetpsPernm + 0.1
                dblWv = dblXMax

                If gobjCommProtocol.funcReadADCFilter(10, dblYNew) = False Then
                    Return False
                End If
                'gobjCommProtocol.mobjCommdll.subTime_Delay(100)
                '//----- Get Abs/ En Value
                'abs = GetADConvertedToCurMode(ynew);

                blYasisReading = gFuncGetADConvertedToCurMode(dblYNew)


                If gblnIsDemoWithRealData = True Then   '---16.03.08
                    Dim intCount As Integer
                    Dim strSelectedElement As String
                    If mblnIsDemoFileOpened = False Then
                        objOpenFile = New OpenFileDialog
                        strSelectedElement = LCase(gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).ElementName)
                        strSelectedElement = Application.StartupPath & "\Spectrums\" & strSelectedElement & ".ens"
                        objOpenFile.FileName = strSelectedElement
                        If (objOpenFile.CheckFileExists()) Then
                            objchannel = gfuncDeSerializeObject(objOpenFile.FileName, EnumDeserializeObjType.EnergySpectrum)
                            mblnIsDemoFileOpened = True
                        End If
                    End If

                    If Not objchannel Is Nothing Then
                        For intCount = 0 To objchannel.Spectrums(0).Readings.Count - 1
                            If dblXMin = objchannel.Spectrums(0).Readings.item(intCount).XaxisData Then
                                dblYNew = objchannel.Spectrums(0).Readings.item(intCount).YaxisADCData
                                blYasisReading = objchannel.Spectrums(0).Readings.item(intCount).YaxisData
                                Exit For
                            End If
                        Next
                    End If
                End If   '---16.03.08


                'mobjThreadController.Display(dblXMin.ToString & "|" & blYasisReading.ToString)
                mobjThreadController.Display(dblXMin.ToString & "|" & blYasisReading.ToString & "|" & dblYNew.ToString)
                Application.DoEvents()
                '--- Check the property for interuption from user to terminate the process
                If ThTerminate = True Then
                    GoTo ExitSpectrum
                End If

                '--- Start to Spectrum
                'x1 = (wvnew * StepPerNm) + 0.1
                'i = CInt(x1)

                'bytLow = CByte(i And &HFF)
                'bytHigh = CByte(i >> 8)
                'SpectGraph.Xmax* (double) stepspernm+(double)0.1
                Dim blnResumeNext As Boolean = False

                dblWv = dblXMax * CDbl(intSetpsPernm) + 0.1
                blnStartSpec = gobjCommProtocol.funcStartSpectrum(dblWv, intSpeed)
                If blnStartSpec = True Then
                    gblnInComm = False
                    Do While (True)
                        If (mblnEndProcess = True) Then
                            'AndAlso (clsRS232Main.gblnInCommProcess = False)
                            'If gblnInComm = False Then
                            '--- Received scan data 
                            If gobjCommProtocol.funcReceive_ScanData(0, dblYNew) = True Then
                                'If (dblYNew = 6000) Then
                                If (dblYNew = 6000) Then
                                    Exit Do
                                End If

                                'dblYNew = dblYNew1
                                '--- For Demo Mode
                                '#If DEMO Then
                                '		ynew=ReadADCFilter();
                                '#End If
                                'If gstructSettings.AppMode = EnumAppMode.DemoMode Then
                                If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                                    (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                                    (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                                    Call gobjCommProtocol.funcReadADCFilter(gobjInst.Average, dblYNew)
                                End If
                                '//-----
                                intSpeedIncrease += intSpeed
                                dblWv = dblXMin + CDbl(intSpeedIncrease) / CDbl(intSetpsPernm)
                                '//----- Get Abs/ En Value
                                'abs = GetADConvertedToCurMode(ynew); 
                                blYasisReading = gFuncGetADConvertedToCurMode(dblYNew)
                                '--- Send the data to the screen by '|' seperated

                                If gblnIsDemoWithRealData = True Then   '---16.03.08
                                    Dim intCount As Integer
                                    If Not objchannel Is Nothing Then
                                        For intCount = 0 To objchannel.Spectrums(0).Readings.Count - 1
                                            If dblWv = objchannel.Spectrums(0).Readings.item(intCount).XaxisData Then
                                                dblYNew = objchannel.Spectrums(0).Readings.item(intCount).YaxisADCData
                                                blYasisReading = objchannel.Spectrums(0).Readings.item(intCount).YaxisData
                                                Exit For
                                            End If
                                        Next
                                    End If
                                    If dblWv > dblXMax Then
                                        Exit Do
                                    End If
                                End If   '---16.03.08

                                mblnEndProcess = False
                                mobjThreadController.Display(dblWv.ToString & "|" & blYasisReading.ToString & "|" & dblYNew.ToString)
                                Application.DoEvents()
                                gobjCommProtocol.mobjCommdll.subTime_Delay(intTimeDelay)
                                Application.DoEvents()
                                funcThreadEnergySpectrum = True

                                '--- Check the property for interuption from user to terminate the process
                                If ThTerminate = True Then
                                    If gobjMessageAdapter.ShowMessage(constExitEnergyScan) = True Then
                                        Application.DoEvents()
                                        If gobjCommProtocol.funcBreakSpectrum() = False Then
                                            Exit Do
                                        Else
                                            Exit Do
                                        End If
                                    Else
                                        Application.DoEvents()
                                        ThTerminate = False
                                    End If

                                End If

                                'gobjCommProtocol.mobjCommdll.subTime_Delay(100)  
                                'Application.DoEvents()
                                '--- Send PC_END Command
                                If gobjCommProtocol.funcPC_END() = False Then
                                    Exit Do
                                End If

                                'gobjCommProtocol.mobjCommdll.subTime_Delay(80)  
                                'Application.DoEvents()
                                'funcThreadEnergySpectrum = True
                            Else
                                Exit Do
                            End If
                            'Else
                            'blnResumeNext = True

                        End If
                        If Not mobjThreadController.Running Then
                            Exit Do
                        End If

                        'Application.DoEvents()
                        'If (gstructSettings.AppMode = EnumAppMode.DemoMode) Then
                        If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                            (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                            (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                            gobjCommProtocol.mobjCommdll.subTime_Delay(100)
                            'Application.DoEvents()
                        End If

                    Loop
                End If
            End If

ExitSpectrum:

            '//-----   Set Wv '& Abs/En
            'Wavelength_Position(hdc, SpectGraph.Xmin, 20, 372)
            gobjCommProtocol.mobjCommdll.subTime_Delay(20)
            Application.DoEvents()
            If gblnIsDemoWithRealData = False Then   '16.03.08
                gobjCommProtocol.Wavelength_Position(dblWvMin, lblObjStatusIn)
            End If
            gobjCommProtocol.mobjCommdll.subTime_Delay(20)
            '--- Display Current Wavelength
            gobjCommProtocol.mobjCommdll.subTime_Delay(20)
            If gblnIsDemoWithRealData = False Then   '16.03.08
                If gobjCommProtocol.funcGet_Current_Wv(dblCurrWv) = True Then

                    lblObjStatusIn.Text = mXValueLable & dblCurrWv.ToString
                    lblObjStatusIn.Refresh()
                    lblObjWV_ABSIn.Text = mYValueLable & "0.0"
                    lblObjWV_ABSIn.Refresh()
                Else

                    lblObjStatusIn.Text = mXValueLable
                    lblObjStatusIn.Refresh()
                    lblObjWV_ABSIn.Text = mYValueLable
                    lblObjWV_ABSIn.Refresh()
                End If
            End If
            '//----------------
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
            SpectrumWait = False
        End Try
    End Function

    Private Function funcThreadUVSpectrum(ByRef lblObjStatusIn As System.Object, _
                                        ByRef lblObjWV_ABSIn As System.Object, _
                                        ByVal dblXMax As Double, _
                                        ByVal dblXMin As Double, _
                                        ByVal dblYMax As Double, _
                                        ByVal dblYMin As Double, _
                                        ByVal intMode As Integer, _
                                        ByVal intSpeed As Integer, _
                                        ByVal intCounter As Integer, _
                                        ByVal bln_BaseLine As Boolean) As Boolean
        '------------------------------------------------------------------
        'Procedure Name         :   funcThreadUVSpectrum
        'Description            :   Start the process for UV Spectrum
        'Affected Parameters    :   lblObjStatusIn,lblObjWV_ABSIn as label on form
        'Parameters             :   As Above
        'Return                 :   True if success.
        'Time/Date              :   5/10/06
        'Dependencies           :   
        'Author                 :   Sachin Dokhale.
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------

        Dim objWait As New CWaitCursor
        Dim dblWv As Double
        Dim dblMaxWv As Double
        Dim dblYNew As Double
        Dim blYasisReading As Double
        Dim blYasisADCReading As Double

        Dim blnStartSpec As Boolean
        Dim intSpeedIncrease As Integer
        Dim intIniMode As Integer
        Dim dblCurrWv As Double
        Dim MAXSIZE As Integer
        Dim intsamp_adcCounter As Integer
        Dim dblWvMin As Double
        Dim strMsg As String
        Dim intTimeDelay As Integer = 20

        Try

            Application.DoEvents()

            Dim objWait1 As New CWaitCursor
            '//----- 1  Set Wv '& Abs/En
            'Wavelength_Position(hdc, SpectGraph.Xmin, 20, 372)

            dblWvMin = dblXMin
            mXValueLable = "Wavelength (nm): "
            Select Case gobjInst.Mode
                Case EnumCalibrationMode.AA, EnumCalibrationMode.AABGC, EnumCalibrationMode.MABS
                    mYValueLable = const_Absorbance
                Case EnumCalibrationMode.HCLE, EnumCalibrationMode.D2E
                    mYValueLable = const_Energy
                Case EnumCalibrationMode.EMISSION
                    mYValueLable = const_Emission
                Case EnumCalibrationMode.SELFTEST
                    mYValueLable = const_Volt
            End Select

            '//----- Display Current Wavelength
            If gobjCommProtocol.funcGet_Current_Wv(dblCurrWv) = True Then
                lblObjStatusIn.text = mXValueLable & dblCurrWv.ToString
                lblObjStatusIn.refresh()
                lblObjWV_ABSIn.text = mYValueLable & "0.0"
                lblObjWV_ABSIn.refresh()
            Else
                lblObjStatusIn.text = mXValueLable
                lblObjStatusIn.refresh()
                lblObjWV_ABSIn.text = mYValueLable
                lblObjWV_ABSIn.refresh()
            End If
            '//----------------
            gobjCommProtocol.Wavelength_Position(dblWvMin, lblObjStatusIn)
            ''position the wavelength
            'gobjCommProtocol.mobjCommdll.subTime_Delay(100)
            ''delay
            '--- Check the property for interuption from user to terminate the process
            If ThTerminate = True Then
                GoTo ExitSpectrum
            End If


            '--- 2. Set the Steps
            Dim intSetpsPernm As Integer = 50
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                intSetpsPernm = CONST_STEPS_PER_NM_AA201
            Else
                intSetpsPernm = CONST_STEPS_PER_NM
            End If

            '--- 3. Set the Speed
            intCounter = 0
            If (intSpeed = 0) Then
                intSpeed = CONST_STEPS_PER_NM
            End If
            '--- Set cal. Mode

            intIniMode = gobjInst.Mode
            gobjInst.Mode = intMode
            gblnUVABS = True

            '//---------------
            '//----- Calculate the size of Ref Adc value
            'MAXSIZE = (unsigned)  (  (((SpectGraph.Xmax-SpectGraph.Xmin)*stepspernm)/ (double) speed) +1.0 );
            'MAXSIZE = CInt((((dblXMax - dblXMin) * CONST_STEPS_PER_NM) / CDbl(intSpeed)) + 1.0)
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                MAXSIZE = CInt((((dblXMax - dblXMin) * CONST_STEPS_PER_NM_AA201) / CDbl(intSpeed)) + 1.0)
            Else
                MAXSIZE = CInt((((dblXMax - dblXMin) * CONST_STEPS_PER_NM) / CDbl(intSpeed)) + 1.0)
            End If

            '--- Check array for Baseline to reset
            If bln_BaseLine = True Then
                Erase gintSample_adc
                gintSample_adc = Nothing
                ReDim gintSample_adc(MAXSIZE)
            End If

            intsamp_adcCounter = 0
            '--- Display Current Wavelength
            If gobjCommProtocol.funcGet_Current_Wv(dblCurrWv) = True Then
                lblObjStatusIn.text = mXValueLable & dblCurrWv.ToString
                lblObjStatusIn.refresh()
                lblObjWV_ABSIn.text = mYValueLable & "0.0"
                lblObjWV_ABSIn.refresh()
            Else
                lblObjStatusIn.text = mXValueLable
                lblObjStatusIn.refresh()
                lblObjWV_ABSIn.text = mYValueLable
                lblObjWV_ABSIn.refresh()
            End If
            '//----------------
            '---4. Cal. Wv & Abs/En
            dblMaxWv = dblXMax * CDbl(intSetpsPernm) + 0.1
            gobjCommProtocol.mobjCommdll.subTime_Delay(intTimeDelay)
            Application.DoEvents()
            If dblMaxWv >= CDbl(intSpeed) Then
                'dblWv =  dblXMax * intSetpsPernm + 0.1
                dblWv = dblXMax
                'If gobjCommProtocol.funcReadADCFilter(10, dblYNew) = False Then
                If gobjCommProtocol.funcReadADCFilter(5, dblYNew) = False Then
                    ''read the ADC value.
                    Return False
                End If
                '--- Get Abs/ En Value
                'abs = GetADConvertedToCurMode(ynew); 

                '--- Check spectrum value for Baseline
                If bln_BaseLine = True Then
                    If IsNothing(gintSample_adc) = False Then
                        If (gintSample_adc.Length > 0) And (gintSample_adc.Length > intsamp_adcCounter) Then
                            gintSample_adc(intsamp_adcCounter) = dblYNew
                        End If
                    End If
                    blYasisReading = gfuncGetConvertToUVAbs(dblYNew, dblYNew)
                    intsamp_adcCounter += 1
                Else
                    If IsNothing(gintSample_adc) = False Then
                        If gintSample_adc.Length > 0 And (gintSample_adc.Length > intsamp_adcCounter) Then
                            blYasisReading = gfuncGetConvertToUVAbs(dblYNew, gintSample_adc(intsamp_adcCounter))
                            intsamp_adcCounter += 1
                        End If
                    Else
                        GoTo ExitSpectrum
                    End If
                End If


                If bln_BaseLine Then
                    strMsg = constExitBaseLine
                Else
                    strMsg = constExitUV
                End If
                ' Check the property for interuption from user to terminate the process
                If ThTerminate = True Then
                    GoTo ExitSpectrum
                End If
                'blYasisReading = gFuncGetADConvertedToCurMode(dblYNew)
                mobjThreadController.Display(dblXMin.ToString & "|" & blYasisReading.ToString & "|" & blYasisReading.ToString)

                '//---- Start to Spectrum
                'x1 = (wvnew * StepPerNm) + 0.1
                'i = CInt(x1)

                'bytLow = CByte(i And &HFF)
                'bytHigh = CByte(i >> 8)
                'SpectGraph.Xmax* (double) stepspernm+(double)0.1

                'dblWv = dblXMax * CDbl(intSetpsPernm) + 0.1
                blnStartSpec = gobjCommProtocol.funcStartSpectrum(dblMaxWv, intSpeed)

                If blnStartSpec = True Then
                    gblnInComm = False
                    Do While (True)
                        If mblnEndProcess = True And gblnInComm = False Then
                            If gobjCommProtocol.funcReceive_ScanData(0, dblYNew) = True Then
                                '//----- For Demo Mode
                                '#If DEMO Then
                                '		ynew = random(4096);
                                '#End If
                                'If gstructSettings.AppMode = EnumAppMode.DemoMode Then
                                If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                                    (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                                    (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                                    dblYNew = gRandom.Next(4096)
                                End If

                                If (dblYNew = 6000) Then
                                    Exit Do
                                End If

                                '//----- For Demo Mode
                                '#If DEMO Then
                                '		ynew=ReadADCFilter();
                                '#End If
                                'If gstructSettings.AppMode = EnumAppMode.DemoMode Then
                                '    Call gobjCommProtocol.funcReadADCFilter(gobjInst.Average, dblYNew)
                                'End If
                                '//-----

                                intSpeedIncrease += intSpeed
                                dblWv = dblXMin + CDbl(intSpeedIncrease) / CDbl(intSetpsPernm)

                                '//----- For Demo Mode
                                '#If DEMO Then
                                '		if (wv>=SpectGraph.Xmax ||addata.counter>= MAXSIZE)
                                '		  break;
                                '#End If
                                'If gstructSettings.AppMode = EnumAppMode.DemoMode Then
                                If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                                    (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                                    (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                                    If ((dblWv >= mdblMaxWavelength) Or (dblWv <= mdblMinWavelength)) Then
                                        Exit Do
                                    End If
                                    Call gobjCommProtocol.funcReadADCFilter(gobjInst.Average, dblYNew)
                                End If

                                If (dblYNew = 4095) Then
                                    'Gerror_message_new("Full scale overflow, Reduce PMT/D2cur", "UV SPECTRUM");
                                    'PostMessage(hwnd, WM_COMMAND, IDC_START, 0);
                                    gobjInst.D2Pmt = 0
                                End If

                                '//----- Get Abs/ En Value
                                ' Check spectrum value for Baseline
                                If bln_BaseLine = True Then
                                    If gintSample_adc.Length > 0 Then
                                        gintSample_adc(intsamp_adcCounter) = dblYNew
                                    End If
                                    blYasisReading = gfuncGetConvertToUVAbs(dblYNew, dblYNew)
                                    intsamp_adcCounter += 1
                                Else
                                    If gintSample_adc.Length > 0 Then
                                        blYasisReading = gfuncGetConvertToUVAbs(dblYNew, gintSample_adc(intsamp_adcCounter))
                                        intsamp_adcCounter += 1
                                    End If
                                    'if (addata.ad && addata.counter<MAXSIZE)
                                    '    addata.ad[addata.counter++]=ynew;
                                End If
                                mblnEndProcess = False
                                '--- Send the data to the screen by '|' seperated
                                'mobjThreadController.Display(dblWv.ToString & "|" & blYasisReading.ToString)
                                'commented by deepak on 04.09.07 and added following line
                                mobjThreadController.Display(dblWv.ToString & "|" & blYasisReading.ToString & "|" & blYasisReading.ToString) '04.09.07
                                'Saurabh
                                gobjCommProtocol.mobjCommdll.subTime_Delay(intTimeDelay)
                                ' Check the property for interuption from user to terminate the process
                                If ThTerminate = True Then
                                    If gobjMessageAdapter.ShowMessage(strMsg) = True Then
                                        Application.DoEvents()
                                        If gobjCommProtocol.funcBreakSpectrum() = False Then
                                            Exit Do
                                        Else
                                            Exit Do
                                        End If
                                    Else
                                        Application.DoEvents()
                                        ThTerminate = False
                                    End If
                                End If
                                'Saurabh

                                'gobjCommProtocol.mobjCommdll.subTime_Delay(80)
                                ' Send the PC_END protocol
                                If gobjCommProtocol.funcPC_END() = False Then
                                    Exit Do
                                End If
                                gobjCommProtocol.mobjCommdll.subTime_Delay(intTimeDelay)
                                Application.DoEvents()
                                'Application.DoEvents()
                                funcThreadUVSpectrum = True
                            Else
                                Exit Do
                            End If
                        End If
                        If Not mobjThreadController.Running Then
                            Exit Do
                        End If

                        'If (gstructSettings.AppMode = EnumAppMode.DemoMode) Then
                        If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                            (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                            (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                            gobjCommProtocol.mobjCommdll.subTime_Delay(100)
                            Application.DoEvents()
                        End If
                    Loop
                End If
            End If

ExitSpectrum:
            '//-----   Set Wv '& Abs/En
            'Wavelength_Position(hdc, SpectGraph.Xmin, 20, 372)
            
            gobjCommProtocol.Wavelength_Position(dblWvMin, lblObjStatusIn)
            gobjCommProtocol.mobjCommdll.subTime_Delay(intTimeDelay)
            Application.DoEvents()
            intsamp_adcCounter = 0
            '//----- Display Current Wavelength
            If gobjCommProtocol.funcGet_Current_Wv(dblCurrWv) = True Then
                lblObjStatusIn.text = mXValueLable & dblCurrWv.ToString
                lblObjStatusIn.refresh()
                lblObjWV_ABSIn.text = mYValueLable & "0.0"
                lblObjWV_ABSIn.refresh()
            Else

                lblObjStatusIn.text = mXValueLable
                lblObjStatusIn.refresh()
                lblObjWV_ABSIn.text = mYValueLable
                lblObjWV_ABSIn.refresh()
            End If
            '//----------------
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
            'ThTerminate = False
            SpectrumWait = False
        End Try
    End Function

    Private Function funcThreadAbsTimeScan(ByRef lblObjStatusIn As System.Object, _
                                        ByRef lblObjWV_ABSIn As System.Object, _
                                        ByVal dblXMax As Double, _
                                        ByVal dblXMin As Double, _
                                        ByVal dblYMax As Double, _
                                        ByVal dblYMin As Double, _
                                        ByVal intMode As Integer, _
                                        ByVal dblAbsScanthldval As Double, _
                                        ByVal blnCheckMinAbsScanLmt As Boolean) As Boolean
        '------------------------------------------------------------------
        'Procedure Name         :   funcThreadAbsTimeScan
        'Description            :   Start the process for Timescan
        'Affected Parameters    :   lblObjStatusIn,lblObjWV_ABSIn as label on form
        'Parameters             :   As Above
        'Return                 :   True if success.
        'Time/Date              :   5/10/06
        'Dependencies           :   
        'Author                 :   Sachin Dokhale.
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        '------------------------------------------------

        '------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim CEnd1, CEnd As Long
        'Dim ConstManipulate As Long = 1000
        Dim ConstManipulate As Long = 10000000
        Dim dblAbs As Double

        Dim dblXaxisTime1 As Double
        '//----- Data Filter DEclearation
        Static Dim Xn_2 As Double = 0
        Static Dim Xn_1 As Double = 0
        Static Dim Yn_1 As Double = 0
        Static Dim Yn_2 As Double = 0
        Static Dim filtdata As Double = 0
        Static intCal_Mode As Integer
        Dim xcoeff1002(,) As Double = {{0.067455, 0.134911, 0.067455}, {0.020083, 0.040167, 0.020083}, {0.003622, 0.007243, 0.003622}, {0.000945, 0.001889, 0.000945}, {0.000039, 0.000078, 0.000039}, {0.00001, 0.00002, 0.00001}}
        Dim ycoeff1002(,) As Double = {{1.14298, -0.412802}, {1.56102, -0.641352}, {1.8227, -0.837182}, {1.9112, -0.914976}, {1.98223, -0.982385}, {1.99111, -0.991154}}
        '//-----
        Try

            Application.DoEvents()

            Dim objWait1 As New CWaitCursor
            '//----- 1  Set Wv '& Abs/En
            lblObjStatusIn.text = mXValueLable & dblXMax.ToString
            lblObjStatusIn.refresh()
            lblObjWV_ABSIn.text = mYValueLable & "0.0"
            lblObjWV_ABSIn.refresh()
            '//----------------
            gobjClsAAS203.ReInitInstParameters()
            CEnd1 = System.DateTime.Now.Ticks

            mblnEndProcess = True
            Do While (Not ThTerminate = True)
                If Not SpectrumWait = True Then
                    If Not (CEnd = CEnd1) Then
                        Application.DoEvents()
                        '--- Read Abs. Data
                        If Not SpectrumWait = True Then
                            dblAbs = gobjClsAAS203.funcGetAbsScanX
                        End If
                        '--- Smooth the ADC data
                        If (gblnSmoothFilter = True) Then
                            filtdata = xcoeff1002(gintTimeConstant, 0) * dblAbs
                            filtdata += xcoeff1002(gintTimeConstant, 1) * Xn_1
                            filtdata += xcoeff1002(gintTimeConstant, 2) * Xn_2
                            filtdata += ycoeff1002(gintTimeConstant, 0) * Yn_1
                            filtdata += ycoeff1002(gintTimeConstant, 1) * Yn_2
                            Xn_2 = Xn_1
                            Xn_1 = dblAbs
                            Yn_2 = Yn_1
                            Yn_1 = filtdata
                            dblAbs = filtdata
                        End If
                        '--- Check the Min Absorbance limits
                        If blnCheckMinAbsScanLmt = True Then
                            If (dblAbs < dblAbsScanthldval) Then
                                dblAbs = 0.0
                            End If
                        End If
                        '--- Read Time clock
                        CEnd = System.DateTime.Now.Ticks
                        dblXaxisTime1 = ((CEnd - CEnd1) / ConstManipulate)


                        If mblnEndProcess = True Then
                            mblnEndProcess = False
                            mobjThreadController.Display(dblXaxisTime1.ToString & "|" & dblAbs.ToString)
                            gobjClsAAS203.funcCheck_Flame() '30.12.08
                        End If
                        '--- Check for Demo Mode
                        'If (gstructSettings.AppMode = EnumAppMode.DemoMode) Then
                        If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                            (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                            (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                            gobjCommProtocol.mobjCommdll.subTime_Delay(200)
                            'Application.DoEvents()
                        End If
                    Else
                        '--- Read Time clock
                        CEnd = System.DateTime.Now.Ticks
                        'Application.DoEvents()
                    End If
                Else
                    '--- Read Time clock
                    CEnd = System.DateTime.Now.Ticks
                End If
            Loop

            lblObjStatusIn.text = mXValueLable & Format(dblXaxisTime1, "###0.0##").ToString
            lblObjStatusIn.refresh()
            lblObjWV_ABSIn.text = mYValueLable & "0.0"
            lblObjWV_ABSIn.refresh()
            funcThreadAbsTimeScan = True
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
            SpectrumWait = False
            Application.DoEvents()
        End Try
    End Function

#End Region

#Region " Double  Beam "
    '//----- Not in use funcThreadDBEnergySpectrum
    Private Function funcThreadDBEnergySpectrum(ByRef lblObjStatusIn As System.Object, _
                                        ByRef lblObjWV_ABSIn As System.Object, _
                                        ByVal dblXMax As Double, _
                                        ByVal dblXMin As Double, _
                                        ByVal dblYMax As Double, _
                                        ByVal dblYMin As Double, _
                                        ByVal intMode As Integer, _
                                        ByVal intSpeed As Integer, _
                                        ByVal intCounter As Integer) As Boolean
        '------------------------------------------------------------------
        'Procedure Name         :   funcThreadDBEnergySpectrum
        'Description            :   Start the process for Energy Spectrum of bouble beam
        'Affected Parameters    :   lblObjStatusIn,lblObjWV_ABSIn as label on form
        'Parameters             :   dblXMax,dblXMin,dblYMax,dblYMin,intMode,intSpeed,intCounter
        'Return                 :   True if success.
        'Time/Date              :   06.04.07
        'Dependencies           :   
        'Author                 :   Sachin Dokhale.
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------

        Dim objWait As New CWaitCursor
        Dim dblWv As Double
        Dim dblYNew As Double
        Dim blYasisReading As Double
        Dim blnStartSpec As Boolean
        Dim intSpeedIncrease As Integer
        Dim intIniMode As Integer
        Dim dblCurrWv As Double
        Dim intSetpsPernm As Integer = 50
        Dim dblWvMin As Double
        Try

            Application.DoEvents()

            Dim objWait1 As New CWaitCursor
            '//----- 1  Set Wv '& Abs/En
            'Wavelength_Position(hdc, SpectGraph.Xmin, 20, 372)

            dblWvMin = dblXMin
            mXValueLable = "Wavelength (nm): "
            Select Case gobjInst.Mode
                ''set a y-axis label as par calibration mode
            Case EnumCalibrationMode.AA
                    mYValueLable = const_Absorbance
                Case EnumCalibrationMode.AA, EnumCalibrationMode.AABGC, EnumCalibrationMode.MABS
                    mYValueLable = "Absorbance : "
                Case EnumCalibrationMode.HCLE, EnumCalibrationMode.D2E
                    mYValueLable = const_Energy
                Case EnumCalibrationMode.EMISSION
                    mYValueLable = const_Emission
                Case EnumCalibrationMode.SELFTEST
                    mYValueLable = const_Volt
            End Select

            '//----- Display Current Wavelength
            If gobjCommProtocol.funcGet_Current_Wv(dblCurrWv) = True Then
                'mobjThreadController.Display(dblCurrWv.ToString & "|" & "0.0")
                lblObjStatusIn.text = mXValueLable & dblCurrWv.ToString
                lblObjStatusIn.refresh()
                lblObjWV_ABSIn.text = mYValueLable & "0.0"
                lblObjWV_ABSIn.refresh()
            Else
                'mobjThreadController.Display("Error" & "|" & "0.0")
                lblObjStatusIn.text = mXValueLable
                lblObjStatusIn.refresh()
                lblObjWV_ABSIn.text = mYValueLable
                lblObjWV_ABSIn.refresh()
            End If
            '//----------------

            gobjCommProtocol.Wavelength_Position(dblWvMin, lblObjStatusIn)
            gobjCommProtocol.mobjCommdll.subTime_Delay(100)
            '//----- 2. Set the Steps


            '//----- 3. Set the Speed
            intCounter = 0
            '//----- Set cal. Mode
            intIniMode = gobjInst.Mode
            gobjInst.Mode = intMode

            '//---------------
            '//----- Display Current Wavelength
            If gobjCommProtocol.funcGet_Current_Wv(dblCurrWv) = True Then
                'mobjThreadController.Display(dblCurrWv.ToString & "|" & "0.0")
                lblObjStatusIn.text = mXValueLable & dblCurrWv.ToString
                lblObjStatusIn.refresh()
                lblObjWV_ABSIn.text = mYValueLable & "0.0"
                lblObjWV_ABSIn.refresh()
            Else
                'mobjThreadController.Display("Error" & "|" & "0.0")
                lblObjStatusIn.text = mXValueLable
                lblObjStatusIn.refresh()
                lblObjWV_ABSIn.text = mYValueLable
                lblObjWV_ABSIn.refresh()
            End If

            '// Terminate if ThTerminate is true
            If ThTerminate = True Then
                GoTo ExitSpectrum
            End If

            '//----------------
            '---4. Cal. Wv & Abs/En
            Dim dblMaxWv As Double
            'dblWv = dblXMax * CDbl(intSetpsPernm) + 0.1
            dblMaxWv = dblXMax * CDbl(intSetpsPernm) + 0.1
            If dblMaxWv >= CDbl(intSpeed) Then
                If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Or _
                   gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.ReferenceBeam Then
                    'mobjThreadController.Display("Reference" & "|" & "0.0")
                    dblWv = dblXMax
                    If gobjCommProtocol.funcReadADCFilter_ReferenceBeam(10, dblYNew) = False Then
                        Return False
                    End If
                    gobjCommProtocol.mobjCommdll.subTime_Delay(100)
                    '//----- Get Abs/ En Value
                    'abs = GetADConvertedToCurMode(ynew);

                    blYasisReading = gFuncGetADConvertedToCurMode(dblYNew)
                    mobjThreadController.Display(dblXMin.ToString & "|" & blYasisReading.ToString)
                    If ThTerminate = True Then
                        GoTo ExitSpectrum
                    End If

                    '//---- Start to Spectrum
                    'x1 = (wvnew * StepPerNm) + 0.1
                    'i = CInt(x1)

                    'bytLow = CByte(i And &HFF)
                    'bytHigh = CByte(i >> 8)
                    'SpectGraph.Xmax* (double) stepspernm+(double)0.1

                    dblWv = dblXMax * CDbl(intSetpsPernm) + 0.1
                    blnStartSpec = gobjCommProtocol.funcStartSpectrum_ReferenceBeam(dblWv, intSpeed)
                    'gobjCommProtocol.mobjCommdll.subTime_Delay(500)
                    If blnStartSpec = True Then
                        Do While (True)
                            If mblnEndProcess = True Then
                                If gobjCommProtocol.funcReceive_ScanData(0, dblYNew) = True Then
                                    If (dblYNew = 6000) Then
                                        Exit Do
                                    End If
                                    '//----- For Demo Mode
                                    '#If DEMO Then
                                    '		ynew=ReadADCFilter();
                                    '#End If
                                    'If gstructSettings.AppMode = EnumAppMode.DemoMode Then
                                    If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                                        (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                                        (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                                        Call gobjCommProtocol.funcReadADCFilter_ReferenceBeam(gobjInst.Average, dblYNew)
                                    End If
                                    '//-----
                                    intSpeedIncrease += intSpeed
                                    dblWv = dblXMin + CDbl(intSpeedIncrease) / CDbl(intSetpsPernm)
                                    '//----- Get Abs/ En Value
                                    'abs = GetADConvertedToCurMode(ynew); 
                                    blYasisReading = gFuncGetADConvertedToCurMode(dblYNew)
                                    mblnEndProcess = False
                                    '--- Send the data to the screen by '|' seperated
                                    mobjThreadController.Display(dblWv.ToString & "|" & blYasisReading.ToString)

                                    If ThTerminate = True Then
                                        If gobjMessageAdapter.ShowMessage(constExitEnergyScan) = True Then
                                            If gobjCommProtocol.funcBreakSpectrum() = False Then
                                                Exit Do
                                            Else
                                                Exit Do
                                            End If
                                        Else
                                            ThTerminate = False
                                        End If
                                    End If
                                    Application.DoEvents()
                                    gobjCommProtocol.mobjCommdll.subTime_Delay(80)
                                    If gobjCommProtocol.funcPC_END() = False Then
                                        Exit Do
                                    End If
                                    'Application.DoEvents()
                                    funcThreadDBEnergySpectrum = True
                                Else
                                    Exit Do
                                End If
                            End If
                            If Not mobjThreadController.Running Then
                                Exit Do
                            End If
                            'Application.DoEvents()
                            'If (gstructSettings.AppMode = EnumAppMode.DemoMode) Then
                            If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                                (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                                (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                                gobjCommProtocol.mobjCommdll.subTime_Delay(100)
                                Application.DoEvents()
                            End If
                        Loop
                    End If
                End If

                '//--------------- Sart for Sample Beam ------------------------------------
                '***************************************************************************
                'gobjCommProtocol.mobjCommdll.subTime_Delay(100)


                If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Or _
                   gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam Then
                    If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
                        mobjThreadController.Display("Sample" & "|" & "0.0")
                        gobjCommProtocol.Wavelength_Position(dblWvMin, lblObjStatusIn)
                        intSpeedIncrease = 0
                        gobjCommProtocol.mobjCommdll.subTime_Delay(80)
                        '//----- Display Current Wavelength
                        If gobjCommProtocol.funcGet_Current_Wv(dblCurrWv) = True Then
                            'mobjThreadController.Display(dblCurrWv.ToString & "|" & "0.0")
                            lblObjStatusIn.text = mXValueLable & dblCurrWv.ToString
                            lblObjStatusIn.refresh()
                            lblObjWV_ABSIn.text = mYValueLable & "0.0"
                            lblObjWV_ABSIn.refresh()
                        Else
                            'mobjThreadController.Display("Error" & "|" & "0.0")
                            lblObjStatusIn.text = mXValueLable
                            lblObjStatusIn.refresh()
                            lblObjWV_ABSIn.text = mYValueLable
                            lblObjWV_ABSIn.refresh()
                        End If

                    End If

                    'mobjThreadController.Display("Sample" & "|" & "0.0")
                    dblWv = dblXMax
                    If gobjCommProtocol.funcReadADCFilter(10, dblYNew) = False Then
                        Return False
                    End If
                    gobjCommProtocol.mobjCommdll.subTime_Delay(80)
                    '//----- Get Abs/ En Value
                    'abs = GetADConvertedToCurMode(ynew);

                    blYasisReading = gFuncGetADConvertedToCurMode(dblYNew)
                    mobjThreadController.Display(dblXMin.ToString & "|" & blYasisReading.ToString)
                    If ThTerminate = True Then
                        GoTo ExitSpectrum
                    End If

                    dblWv = dblXMax * CDbl(intSetpsPernm) + 0.1
                    blnStartSpec = gobjCommProtocol.funcStartSpectrum(dblWv, intSpeed)
                    If blnStartSpec = True Then
                        Do While (True)
                            If gobjCommProtocol.funcReceive_ScanData(0, dblYNew) = True Then
                                If (dblYNew = 6000) Then
                                    Exit Do
                                End If
                                '//----- For Demo Mode
                                '#If DEMO Then
                                '		ynew=ReadADCFilter();
                                '#End If
                                'If gstructSettings.AppMode = EnumAppMode.DemoMode Then
                                If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                                    (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                                    (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                                    Call gobjCommProtocol.funcReadADCFilter(gobjInst.Average, dblYNew)
                                End If
                                '//-----
                                intSpeedIncrease += intSpeed
                                dblWv = dblXMin + CDbl(intSpeedIncrease) / CDbl(intSetpsPernm)
                                '//----- Get Abs/ En Value
                                'abs = GetADConvertedToCurMode(ynew); 
                                blYasisReading = gFuncGetADConvertedToCurMode(dblYNew)
                                '--- Send the data to the screen by '|' seperated
                                mobjThreadController.Display(dblWv.ToString & "|" & blYasisReading.ToString)
                                If ThTerminate = True Then
                                    If gobjMessageAdapter.ShowMessage(constExitEnergyScan) = True Then
                                        If gobjCommProtocol.funcBreakSpectrum() = False Then
                                            Exit Do
                                        Else
                                            Exit Do
                                        End If
                                    Else
                                        ThTerminate = False
                                    End If
                                End If

                                gobjCommProtocol.mobjCommdll.subTime_Delay(80)
                                If gobjCommProtocol.funcPC_END() = False Then
                                    Exit Do
                                End If
                                'Application.DoEvents()
                                funcThreadDBEnergySpectrum = True
                            Else
                                Exit Do
                            End If
                            If Not mobjThreadController.Running Then
                                Exit Do
                            End If
                            Application.DoEvents()
                        Loop
                    End If
                End If
            End If


ExitSpectrum:

            '//-----   Set Wv '& Abs/En
            'Wavelength_Position(hdc, SpectGraph.Xmin, 20, 372)
            Application.DoEvents()
            gobjCommProtocol.Wavelength_Position(dblWvMin, lblObjStatusIn)
            gobjCommProtocol.mobjCommdll.subTime_Delay(50)
            '//----- Display Current Wavelength
            If gobjCommProtocol.funcGet_Current_Wv(dblCurrWv) = True Then

                lblObjStatusIn.text = mXValueLable & dblCurrWv.ToString
                lblObjStatusIn.refresh()
                lblObjWV_ABSIn.text = mYValueLable & "0.0"
                lblObjWV_ABSIn.refresh()
            Else

                lblObjStatusIn.text = mXValueLable
                lblObjStatusIn.refresh()
                lblObjWV_ABSIn.text = mYValueLable
                lblObjWV_ABSIn.refresh()
            End If
            '//----------------

            'Application.DoEvents()
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
            SpectrumWait = False
        End Try
    End Function
    '//----- Not in use of funcThreadDBEnergySpectrum
    Private Function funcThreadDBEnergySpectrum_AccToBeamSelection(ByRef lblObjStatusIn As System.Object, _
                                        ByRef lblObjWV_ABSIn As System.Object, _
                                        ByVal dblXMax As Double, _
                                        ByVal dblXMin As Double, _
                                        ByVal dblYMax As Double, _
                                        ByVal dblYMin As Double, _
                                        ByVal intMode As Integer, _
                                        ByVal intSpeed As Integer, _
                                        ByVal intCounter As Integer, _
                                        ByVal blnIsRefBeamSelected As Boolean) As Boolean
        '------------------------------------------------------------------
        'Procedure Name         :   funcThreadDBEnergySpectrum_AccToBeamSelection
        'Description            :   Start the process for Energy Spectrum of bouble beam
        'Affected Parameters    :   lblObjStatusIn,lblObjWV_ABSIn as label on form
        'Parameters             :   dblXMax,dblXMin,dblYMax,dblYMin,intMode,intSpeed,intCounter,blnIsRefBeamSelected
        'Return                 :   True if success.
        'Time/Date              :   06.04.07
        'Dependencies           :   
        'Author                 :   Sachin Dokhale.
        'Revision               :
        'Revision by Person     :   Deepak Bhati on 20.07.07 added a flag to know whether sample or ref beam is 
        '                           selected
        '--------------------------------------------------------------------------------------

        Dim objWait As New CWaitCursor
        Dim dblWv As Double
        Dim dblYNew As Double
        Dim blYasisReading As Double
        Dim blnStartSpec As Boolean
        Dim intSpeedIncrease As Integer
        Dim intIniMode As Integer
        Dim dblCurrWv As Double
        Dim intSetpsPernm As Integer = 50
        Dim dblWvMin As Double
        Dim intTimeDelay As Integer = 20
        Dim objOpenFile As OpenFileDialog  '---16.03.08
        Dim objchannel As Spectrum.Channel  '---16.03.08
        Try

            Application.DoEvents()

            '//----- 1  Set Wv '& Abs/En
            'Wavelength_Position(hdc, SpectGraph.Xmin, 20, 372)

            dblWvMin = dblXMin
            mXValueLable = "Wavelength (nm): "
            Select Case gobjInst.Mode
                Case EnumCalibrationMode.AA
                    mYValueLable = const_Absorbance
                Case EnumCalibrationMode.AA, EnumCalibrationMode.AABGC, EnumCalibrationMode.MABS
                    mYValueLable = "Absorbance : "
                Case EnumCalibrationMode.HCLE, EnumCalibrationMode.D2E
                    mYValueLable = const_Energy
                Case EnumCalibrationMode.EMISSION
                    mYValueLable = const_Emission
                Case EnumCalibrationMode.SELFTEST
                    mYValueLable = const_Volt
            End Select

            '//----- Display Current Wavelength
            If gblnIsDemoWithRealData = False Then   '16.03.08
                If gobjCommProtocol.funcGet_Current_Wv(dblCurrWv) = True Then
                    'mobjThreadController.Display(dblCurrWv.ToString & "|" & "0.0")
                    lblObjStatusIn.text = mXValueLable & dblCurrWv.ToString
                    lblObjStatusIn.refresh()
                    lblObjWV_ABSIn.text = mYValueLable & "0.0"
                    lblObjWV_ABSIn.refresh()
                Else
                    'mobjThreadController.Display("Error" & "|" & "0.0")
                    lblObjStatusIn.text = mXValueLable
                    lblObjStatusIn.refresh()
                    lblObjWV_ABSIn.text = mYValueLable
                    lblObjWV_ABSIn.refresh()
                End If
            End If
            
            '//----------------
            If gblnIsDemoWithRealData = False Then   '16.03.08
                gobjCommProtocol.Wavelength_Position(dblWvMin, lblObjStatusIn)
            End If
            'gobjCommProtocol.mobjCommdll.subTime_Delay(80)
            '//----- 2. Set the Steps


            '//----- 3. Set the Speed
            intCounter = 0
            '//----- Set cal. Mode
            intIniMode = gobjInst.Mode
            gobjInst.Mode = intMode

            '//---------------
            '--- Display Current Wavelength
            If gblnIsDemoWithRealData = False Then   '16.03.08
                If gobjCommProtocol.funcGet_Current_Wv(dblCurrWv) = True Then
                    'mobjThreadController.Display(dblCurrWv.ToString & "|" & "0.0")
                    lblObjStatusIn.text = mXValueLable & dblCurrWv.ToString
                    lblObjStatusIn.refresh()
                    lblObjWV_ABSIn.text = mYValueLable & "0.0"
                    lblObjWV_ABSIn.refresh()
                Else
                    'mobjThreadController.Display("Error" & "|" & "0.0")
                    lblObjStatusIn.text = mXValueLable
                    lblObjStatusIn.refresh()
                    lblObjWV_ABSIn.text = mYValueLable
                    lblObjWV_ABSIn.refresh()
                End If
            End If
            

            '--- Check the property for interuption from user to terminate the process
            If ThTerminate = True Then
                GoTo ExitSpectrum
            End If

            '//----------------
            '---4. Cal. Wv & Abs/En
            Dim dblMaxWv As Double
            'dblWv = dblXMax * CDbl(intSetpsPernm) + 0.1
            dblMaxWv = dblXMax * CDbl(intSetpsPernm) + 0.1
            If dblMaxWv >= CDbl(intSpeed) Then
                '---the following condition is added by deepak on 20.07.07
                If blnIsRefBeamSelected = True Then
                    If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Or _
                       gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.ReferenceBeam Then
                        'mobjThreadController.Display("Reference" & "|" & "0.0")
                        gobjCommProtocol.mobjCommdll.subTime_Delay(intTimeDelay)
                        Application.DoEvents()
                        dblWv = dblXMax
                        If gobjCommProtocol.funcReadADCFilter_ReferenceBeam(10, dblYNew) = False Then
                            Return False
                        End If
                        'gobjCommProtocol.mobjCommdll.subTime_Delay(50)
                        '//----- Get Abs/ En Value
                        'abs = GetADConvertedToCurMode(ynew);

                        blYasisReading = gFuncGetADConvertedToCurMode(dblYNew)

                        If gblnIsDemoWithRealData = True Then   '---16.03.08
                            Dim intCount As Integer
                            Dim strSelectedElement As String
                            If mblnIsDemoFileOpened = False Then
                                objOpenFile = New OpenFileDialog
                                strSelectedElement = LCase(gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).ElementName)
                                strSelectedElement = Application.StartupPath & "\Spectrums\" & strSelectedElement & ".ens"
                                objOpenFile.FileName = strSelectedElement
                                If (objOpenFile.CheckFileExists()) Then
                                    objchannel = gfuncDeSerializeObject(objOpenFile.FileName, EnumDeserializeObjType.EnergySpectrum)
                                    mblnIsDemoFileOpened = True
                                End If
                            End If

                            If Not objchannel Is Nothing Then
                                For intCount = 0 To objchannel.Spectrums(0).Readings.Count - 1
                                    If dblXMin = objchannel.Spectrums(0).Readings.item(intCount).XaxisData Then
                                        dblYNew = objchannel.Spectrums(0).Readings.item(intCount).YaxisADCData
                                        blYasisReading = objchannel.Spectrums(0).Readings.item(intCount).YaxisData
                                        Exit For
                                    End If
                                Next
                            End If
                        End If   '---16.03.08

                        'mobjThreadController.Display(dblXMin.ToString & "|" & blYasisReading.ToString)
                        mobjThreadController.Display(dblXMin.ToString & "|" & blYasisReading.ToString & "|" & dblYNew.ToString)
                        ' Check the property for interuption from user to terminate the process
                        If ThTerminate = True Then
                            GoTo ExitSpectrum
                        End If

                        '//---- Start to Spectrum
                        'x1 = (wvnew * StepPerNm) + 0.1
                        'i = CInt(x1)

                        'bytLow = CByte(i And &HFF)
                        'bytHigh = CByte(i >> 8)
                        'SpectGraph.Xmax* (double) stepspernm+(double)0.1

                        dblWv = dblXMax * CDbl(intSetpsPernm) + 0.1
                        blnStartSpec = gobjCommProtocol.funcStartSpectrum_ReferenceBeam(dblWv, intSpeed)
                        gblnInComm = False
                        'gobjCommProtocol.mobjCommdll.subTime_Delay(500)
                        If blnStartSpec = True Then
                            Do While (True)
                                'Application.DoEvents()
                                If mblnEndProcess = True Then
                                    'Me.SpectrumWait = False 
                                    If gblnInComm = False Then
                                        If gobjCommProtocol.funcReceive_ScanData(0, dblYNew) = True Then

                                            If (dblYNew = 6000) Then
                                                Exit Do

                                            End If
                                            'mblnEndProcess = False
                                            '//----- For Demo Mode
                                            '#If DEMO Then
                                            '		ynew=ReadADCFilter();
                                            '#End If
                                            gobjCommProtocol.mobjCommdll.subTime_Delay(intTimeDelay)
                                            '--- Modified for speed Issue
                                            If ThTerminate = True Then
                                                If gobjMessageAdapter.ShowMessage(constExitEnergyScan) = True Then
                                                    Application.DoEvents()
                                                    If gobjCommProtocol.funcBreakSpectrum() = False Then
                                                        Exit Do
                                                    Else
                                                        Exit Do
                                                    End If
                                                Else
                                                    Application.DoEvents()
                                                    ThTerminate = False
                                                End If
                                            End If
                                            If gobjCommProtocol.funcPC_END() = False Then
                                                Exit Do
                                            End If
                                            gobjCommProtocol.mobjCommdll.subTime_Delay(intTimeDelay)

                                            '---
                                            'If gstructSettings.AppMode = EnumAppMode.DemoMode Then
                                            If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                                                (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                                                (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                                                Call gobjCommProtocol.funcReadADCFilter_ReferenceBeam(gobjInst.Average, dblYNew)
                                            End If

                                            '//-----
                                            intSpeedIncrease += intSpeed
                                            dblWv = dblXMin + CDbl(intSpeedIncrease) / CDbl(intSetpsPernm)
                                            '//----- Get Abs/ En Value
                                            'abs = GetADConvertedToCurMode(ynew); 
                                            blYasisReading = gFuncGetADConvertedToCurMode(dblYNew)

                                            mblnEndProcess = False
                                            Application.DoEvents()
                                            If gblnIsDemoWithRealData = True Then   '---16.03.08
                                                Dim intCount As Integer
                                                If Not objchannel Is Nothing Then
                                                    For intCount = 0 To objchannel.Spectrums(0).Readings.Count - 1
                                                        If dblWv = objchannel.Spectrums(0).Readings.item(intCount).XaxisData Then
                                                            dblYNew = objchannel.Spectrums(0).Readings.item(intCount).YaxisADCData
                                                            blYasisReading = objchannel.Spectrums(0).Readings.item(intCount).YaxisData
                                                            Exit For
                                                        End If
                                                    Next
                                                End If
                                                If dblWv > dblXMax Then
                                                    Exit Do
                                                End If
                                            End If   '---16.03.08

                                            '--- Send the data to the screen by '|' seperated
                                            'mobjThreadController.Display(dblWv.ToString & "|" & blYasisReading.ToString)
                                            mobjThreadController.Display(dblWv.ToString & "|" & blYasisReading.ToString & "|" & dblYNew.ToString)
                                            ' Check the property for interuption from user to terminate the process
                                            '--- Modified for speed Issue
                                            'If ThTerminate = True Then
                                            '    If gobjMessageAdapter.ShowMessage(constExitEnergyScan) = True Then
                                            '        If gobjCommProtocol.funcBreakSpectrum() = False Then
                                            '            Exit Do
                                            '        Else
                                            '            Exit Do
                                            '        End If
                                            '    Else
                                            '        ThTerminate = False
                                            '    End If
                                            'End If
                                            'gobjCommProtocol.mobjCommdll.subTime_Delay(intTimeDelay)
                                            'Application.DoEvents()
                                            'If gobjCommProtocol.funcPC_END() = False Then
                                            '    Exit Do
                                            'End If
                                            'Application.DoEvents()
                                            funcThreadDBEnergySpectrum_AccToBeamSelection = True
                                        Else
                                            Exit Do
                                        End If
                                    End If
                                End If
                                If Not mobjThreadController.Running Then
                                    Exit Do
                                End If
                                Application.DoEvents()
                                'If (gstructSettings.AppMode = EnumAppMode.DemoMode) Then
                                If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                                    (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                                    (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                                    gobjCommProtocol.mobjCommdll.subTime_Delay(100)
                                    Application.DoEvents()
                                End If
                            Loop
                        End If
                    End If
                Else

                    '//--------------- Sart for Sample Beam ------------------------------------
                    '***************************************************************************
                    'gobjCommProtocol.mobjCommdll.subTime_Delay(30)


                    If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Or _
                       gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam Then
                        If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
                            mobjThreadController.Display("Sample" & "|" & "0.0")

                            If gblnIsDemoWithRealData = False Then   '16.03.08
                                gobjCommProtocol.Wavelength_Position(dblWvMin, lblObjStatusIn)
                            End If

                            intSpeedIncrease = 0
                            'gobjCommProtocol.mobjCommdll.subTime_Delay(80)
                            '//----- Display Current Wavelength
                            If gblnIsDemoWithRealData = False Then   '16.03.08
                                If gobjCommProtocol.funcGet_Current_Wv(dblCurrWv) = True Then
                                    'mobjThreadController.Display(dblCurrWv.ToString & "|" & "0.0")
                                    lblObjStatusIn.text = mXValueLable & dblCurrWv.ToString
                                    lblObjStatusIn.refresh()
                                    lblObjWV_ABSIn.text = mYValueLable & "0.0"
                                    lblObjWV_ABSIn.refresh()
                                Else
                                    'mobjThreadController.Display("Error" & "|" & "0.0")
                                    lblObjStatusIn.text = mXValueLable
                                    lblObjStatusIn.refresh()
                                    lblObjWV_ABSIn.text = mYValueLable
                                    lblObjWV_ABSIn.refresh()
                                End If
                            End If
                        End If
                        gobjCommProtocol.mobjCommdll.subTime_Delay(intTimeDelay)
                        Application.DoEvents()
                        'mobjThreadController.Display("Sample" & "|" & "0.0")
                        dblWv = dblXMax
                        If gobjCommProtocol.funcReadADCFilter(10, dblYNew) = False Then
                            Return False
                        End If
                        'gobjCommProtocol.mobjCommdll.subTime_Delay(50)
                        '//----- Get Abs/ En Value
                        'abs = GetADConvertedToCurMode(ynew);

                        blYasisReading = gFuncGetADConvertedToCurMode(dblYNew)


                        If gblnIsDemoWithRealData = True Then   '---16.03.08
                            Dim intCount As Integer
                            Dim strSelectedElement As String
                            If mblnIsDemoFileOpened = False Then
                                objOpenFile = New OpenFileDialog
                                strSelectedElement = LCase(gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).ElementName)
                                strSelectedElement = Application.StartupPath & "\Spectrums\" & strSelectedElement & ".ens"
                                objOpenFile.FileName = strSelectedElement
                                If (objOpenFile.CheckFileExists()) Then
                                    objchannel = gfuncDeSerializeObject(objOpenFile.FileName, EnumDeserializeObjType.EnergySpectrum)
                                    mblnIsDemoFileOpened = True
                                End If
                            End If

                            If Not objchannel Is Nothing Then
                                For intCount = 0 To objchannel.Spectrums(0).Readings.Count - 1
                                    If dblXMin = objchannel.Spectrums(0).Readings.item(intCount).XaxisData Then
                                        dblYNew = objchannel.Spectrums(0).Readings.item(intCount).YaxisADCData
                                        blYasisReading = objchannel.Spectrums(0).Readings.item(intCount).YaxisData
                                        Exit For
                                    End If
                                Next
                            End If
                        End If   '---16.03.08


                        'mobjThreadController.Display(dblXMin.ToString & "|" & blYasisReading.ToString)
                        mobjThreadController.Display(dblXMin.ToString & "|" & blYasisReading.ToString & "|" & dblYNew.ToString)
                        ' Check the property for interuption from user to terminate the process
                        If ThTerminate = True Then
                            GoTo ExitSpectrum
                        End If

                        dblWv = dblXMax * CDbl(intSetpsPernm) + 0.1
                        'gobjCommProtocol.mobjCommdll.subTime_Delay(50)
                        blnStartSpec = gobjCommProtocol.funcStartSpectrum(dblWv, intSpeed)
                        If blnStartSpec = True Then
                            'gblnInComm = False
                            Do While (True)
                                If mblnEndProcess = True Then
                                    'Me.SpectrumWait = False 
                                    If gblnInComm = False Then
                                        If gobjCommProtocol.funcReceive_ScanData(0, dblYNew) = True Then
                                            If (dblYNew = 6000) Then
                                                Exit Do
                                            End If
                                            '//----- For Demo Mode
                                            '#If DEMO Then
                                            '		ynew=ReadADCFilter();
                                            '#End If
                                            gobjCommProtocol.mobjCommdll.subTime_Delay(intTimeDelay)
                                            ' Check the property for interuption from user to terminate the process
                                            If ThTerminate = True Then
                                                If gobjMessageAdapter.ShowMessage(constExitEnergyScan) = True Then
                                                    Application.DoEvents()
                                                    'If Me.SpectrumWait = False Then
                                                    If gobjCommProtocol.funcBreakSpectrum() = False Then
                                                        Exit Do
                                                    Else
                                                        Exit Do
                                                    End If
                                                    'End If
                                                Else
                                                    Application.DoEvents()
                                                    ThTerminate = False
                                                End If
                                            End If
                                            'If gstructSettings.AppMode = EnumAppMode.DemoMode Then
                                            If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                                                (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                                                (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                                                Call gobjCommProtocol.funcReadADCFilter(gobjInst.Average, dblYNew)
                                            End If
                                            'gobjCommProtocol.mobjCommdll.subTime_Delay(intTimeDelay)
                                            'Application.DoEvents()
                                            'If Me.SpectrumWait = False Then
                                            If gobjCommProtocol.funcPC_END() = False Then
                                                Exit Do
                                            End If
                                            'End If
                                            gobjCommProtocol.mobjCommdll.subTime_Delay(intTimeDelay)
                                            Application.DoEvents()
                                            '//-----
                                            intSpeedIncrease += intSpeed
                                            dblWv = dblXMin + CDbl(intSpeedIncrease) / CDbl(intSetpsPernm)
                                            '//----- Get Abs/ En Value
                                            'abs = GetADConvertedToCurMode(ynew); 
                                            blYasisReading = gFuncGetADConvertedToCurMode(dblYNew)
                                            '--- Send the data to the screen by '|' seperated
                                            mblnEndProcess = False


                                            If gblnIsDemoWithRealData = True Then   '---16.03.08
                                                Dim intCount As Integer
                                                If Not objchannel Is Nothing Then
                                                    For intCount = 0 To objchannel.Spectrums(0).Readings.Count - 1
                                                        If dblWv = objchannel.Spectrums(0).Readings.item(intCount).XaxisData Then
                                                            dblYNew = objchannel.Spectrums(0).Readings.item(intCount).YaxisADCData
                                                            blYasisReading = objchannel.Spectrums(0).Readings.item(intCount).YaxisData
                                                            Exit For
                                                        End If
                                                    Next
                                                End If
                                                If dblWv > dblXMax Then
                                                    Exit Do
                                                End If
                                            End If   '---16.03.08

                                            'mobjThreadController.Display(dblWv.ToString & "|" & blYasisReading.ToString)
                                            mobjThreadController.Display(dblWv.ToString & "|" & blYasisReading.ToString & "|" & dblYNew)
                                            '--- Commented for speed issue
                                            '' Check the property for interuption from user to terminate the process
                                            'If ThTerminate = True Then
                                            '    If gobjMessageAdapter.ShowMessage(constExitEnergyScan) = True Then
                                            '        If Me.SpectrumWait = False Then
                                            '            If gobjCommProtocol.funcBreakSpectrum() = False Then
                                            '                Exit Do
                                            '            Else
                                            '                Exit Do
                                            '            End If
                                            '        End If
                                            '    Else
                                            '        ThTerminate = False
                                            '    End If
                                            'End If
                                            'Application.DoEvents()
                                            'gobjCommProtocol.mobjCommdll.subTime_Delay(intTimeDelay)

                                            'If Me.SpectrumWait = False Then
                                            '    If gobjCommProtocol.funcPC_END() = False Then
                                            '        Exit Do
                                            '    End If
                                            'End If
                                            Application.DoEvents()
                                            funcThreadDBEnergySpectrum_AccToBeamSelection = True
                                        Else
                                            Exit Do
                                        End If
                                    End If
                                End If
                                If Not mobjThreadController.Running Then
                                    Exit Do
                                End If
                                Application.DoEvents()
                            Loop
                        End If
                    End If
                End If
            End If


ExitSpectrum:

            '//-----   Set Wv '& Abs/En
            'Wavelength_Position(hdc, SpectGraph.Xmin, 20, 372)
            'gobjCommProtocol.mobjCommdll.subTime_Delay(50)
            Application.DoEvents()
            If gblnIsDemoWithRealData = False Then    '---16.03.08
                gobjCommProtocol.Wavelength_Position(dblWvMin, lblObjStatusIn)
            End If
            'gobjCommProtocol.mobjCommdll.subTime_Delay(50)
            '//----- Display Current Wavelength
            If gblnIsDemoWithRealData = False Then    '---16.03.08
                If gobjCommProtocol.funcGet_Current_Wv(dblCurrWv) = True Then
                    lblObjStatusIn.text = mXValueLable & dblCurrWv.ToString
                    lblObjStatusIn.refresh()
                    lblObjWV_ABSIn.text = mYValueLable & "0.0"
                    lblObjWV_ABSIn.refresh()
                Else
                    lblObjStatusIn.text = mXValueLable
                    lblObjStatusIn.refresh()
                    lblObjWV_ABSIn.text = mYValueLable
                    lblObjWV_ABSIn.refresh()
                End If
            End If
            '//----------------

            'Application.DoEvents()
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
            objWait = Nothing
            ThTerminate = False
            SpectrumWait = False
        End Try
    End Function

    Private Function funcThreadDBUVSpectrum(ByRef lblObjStatusIn As System.Object, _
                                        ByRef lblObjWV_ABSIn As System.Object, _
                                        ByVal dblXMax As Double, _
                                        ByVal dblXMin As Double, _
                                        ByVal dblYMax As Double, _
                                        ByVal dblYMin As Double, _
                                        ByVal intMode As Integer, _
                                        ByVal intSpeed As Integer, _
                                        ByVal intCounter As Integer, _
                                        ByVal bln_BaseLine As Boolean) As Boolean
        '------------------------------------------------------------------
        'Procedure Name         :   funcThreadDBUVSpectrum
        'Description            :   Start the process for UV Spectrum of bouble beam
        'Affected Parameters    :   lblObjStatusIn,lblObjWV_ABSIn as label on form
        'Parameters             :   dblXMax,dblXMin,dblYMax,dblYMin,intMode,intSpeed,intCounter,bln_BaseLine
        'Return                 :   True if success.
        'Time/Date              :   5/10/06
        'Dependencies           :   
        'Author                 :   Sachin Dokhale.
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        '------------------------------------------------

        '------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim dblWv As Double
        Dim dblMaxWv As Double
        Dim dblYNew As Double
        Dim blYasisReading As Double
        Dim blnStartSpec As Boolean
        Dim intSpeedIncrease As Integer
        Dim intIniMode As Integer
        Dim dblCurrWv As Double
        Dim MAXSIZE As Integer
        Dim intsamp_adcCounter As Integer
        Dim dblWvMin As Double
        Dim intSetpsPernm As Integer
        Dim intTimeDelay As Integer = 20
        Try
            Dim objWait1 As New CWaitCursor
            Application.DoEvents()


            '//----- 1  Set Wv '& Abs/En
            'Wavelength_Position(hdc, SpectGraph.Xmin, 20, 372)

            dblWvMin = dblXMin
            mXValueLable = "Wavelength (nm): "
            Select Case gobjInst.Mode
                Case EnumCalibrationMode.AA, EnumCalibrationMode.AABGC, EnumCalibrationMode.MABS
                    mYValueLable = const_Absorbance
                Case EnumCalibrationMode.HCLE, EnumCalibrationMode.D2E
                    mYValueLable = const_Energy
                Case EnumCalibrationMode.EMISSION
                    mYValueLable = const_Emission
                Case EnumCalibrationMode.SELFTEST
                    mYValueLable = const_Volt
            End Select

            '//----- Display Current Wavelength
            If gobjCommProtocol.funcGet_Current_Wv(dblCurrWv) = True Then
                'mobjThreadController.Display(dblCurrWv.ToString & "|" & "0.0")
                lblObjStatusIn.text = mXValueLable & dblCurrWv.ToString
                lblObjStatusIn.refresh()
                lblObjWV_ABSIn.text = mYValueLable & "0.0"
                lblObjWV_ABSIn.refresh()
            Else
                'mobjThreadController.Display("Error" & "|" & "0.0")
                lblObjStatusIn.text = mXValueLable
                lblObjStatusIn.refresh()
                lblObjWV_ABSIn.text = mYValueLable
                lblObjWV_ABSIn.refresh()
            End If
            '//----------------

            gobjCommProtocol.Wavelength_Position(dblWvMin, lblObjStatusIn)
            'gobjCommProtocol.mobjCommdll.subTime_Delay(100)
            gobjCommProtocol.mobjCommdll.subTime_Delay(intTimeDelay)
            Application.DoEvents()
            ' Check the property for interuption from user to terminate the process
            If ThTerminate = True Then
                GoTo ExitSpectrum
            End If


            '//----- 2. Set the Steps
            intSetpsPernm = 50

            '//----- 3. Set the Speed
            intCounter = 0
            If (intSpeed = 0) Then
                intSpeed = CONST_STEPS_PER_NM
            End If
            '//----- Set cal. Mode

            intIniMode = gobjInst.Mode
            gobjInst.Mode = intMode
            gblnUVABS = True

            '//---------------
            '//----- Calculate the size of Ref Adc value
            'MAXSIZE = (unsigned)  (  (((SpectGraph.Xmax-SpectGraph.Xmin)*stepspernm)/ (double) speed) +1.0 );
            MAXSIZE = CInt((((dblXMax - dblXMin) * CONST_STEPS_PER_NM) / CDbl(intSpeed)) + 1.0)

            If bln_BaseLine = True Then
                Erase gintSample_adc
                ReDim gintSample_adc(MAXSIZE)

                Erase gintSample_adc_RefBeam
                ReDim gintSample_adc_RefBeam(MAXSIZE)
            End If

            intsamp_adcCounter = 0
            '//----- Display Current Wavelength
            If gobjCommProtocol.funcGet_Current_Wv(dblCurrWv) = True Then
                'mobjThreadController.Display(dblCurrWv.ToString & "|" & "0.0")
                lblObjStatusIn.text = mXValueLable & dblCurrWv.ToString
                lblObjStatusIn.refresh()
                lblObjWV_ABSIn.text = mYValueLable & "0.0"
                lblObjWV_ABSIn.refresh()
            Else
                'mobjThreadController.Display("Error" & "|" & "0.0")
                lblObjStatusIn.text = mXValueLable
                lblObjStatusIn.refresh()
                lblObjWV_ABSIn.text = mYValueLable
                lblObjWV_ABSIn.refresh()
            End If
            '//----------------

            '---4. Cal. Wv & Abs/En
            dblMaxWv = dblXMax * CDbl(intSetpsPernm) + 0.1

            If dblMaxWv >= CDbl(intSpeed) Then
                'dblWv =  dblXMax * intSetpsPernm + 0.1
                '//------------- Start Sample Spectrum
                '//********************************************************************
                gobjCommProtocol.Wavelength_Position(dblWvMin, lblObjStatusIn)
                'gobjCommProtocol.mobjCommdll.subTime_Delay(100)
                gobjCommProtocol.mobjCommdll.subTime_Delay(intTimeDelay)
                Application.DoEvents()
                '//----- Display Current Wavelength
                intsamp_adcCounter = 0
                dblWv = dblXMax
                'If gobjCommProtocol.funcReadADCFilter(10, dblYNew) = False Then
                If gobjCommProtocol.funcReadADCFilter(5, dblYNew) = False Then
                    Return False
                End If
                'gobjCommProtocol.mobjCommdll.subTime_Delay(100)
                '//----- Get Abs/ En Value
                'abs = GetADConvertedToCurMode(ynew); 

                '--- Check spectrum value for Baseline
                If bln_BaseLine = True Then
                    gintSample_adc(intsamp_adcCounter) = dblYNew
                    blYasisReading = gfuncGetConvertToUVAbs(dblYNew, dblYNew)
                    intsamp_adcCounter += 1
                Else
                    If IsNothing(gintSample_adc) = False Then
                        If gintSample_adc.Length > 0 Then
                            blYasisReading = gfuncGetConvertToUVAbs(dblYNew, gintSample_adc(intsamp_adcCounter))
                            intsamp_adcCounter += 1
                        End If
                    Else
                        Return False
                    End If
                End If
                Dim strMsg As String
                If bln_BaseLine Then
                    strMsg = constExitBaseLine
                Else
                    strMsg = constExitUV
                End If
                ' Check the property for interuption from user to terminate the process
                If ThTerminate = True Then
                    GoTo ExitSpectrum
                End If
                'blYasisReading = gFuncGetADConvertedToCurMode(dblYNew)
                'mobjThreadController.Display(dblXMin.ToString & "|" & blYasisReading.ToString)
                mobjThreadController.Display(dblXMin.ToString & "|" & blYasisReading.ToString & "|" & blYasisReading.ToString)

                '//---- Start to Spectrum
                blnStartSpec = gobjCommProtocol.funcStartSpectrum(dblMaxWv, intSpeed)
                mblnEndProcess = True
                If blnStartSpec = True Then
                    gblnInComm = False
                    Do While (ThTerminate = False)
                        If mblnEndProcess = True And gblnInComm = False Then
                            If gobjCommProtocol.funcReceive_ScanData(0, dblYNew) = True Then
                                '//----- For Demo Mode
                                '#If DEMO Then
                                '		ynew = random(4096);
                                '#End If
                                'If gstructSettings.AppMode = EnumAppMode.DemoMode Then
                                If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                                    (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                                    (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                                    dblYNew = gRandom.Next(4096)
                                End If

                                If (dblYNew = 6000) Then
                                    Exit Do
                                End If

                                '--- For Demo Mode
                                '#If DEMO Then
                                '		ynew=ReadADCFilter();
                                '#End If
                                'If gstructSettings.AppMode = EnumAppMode.DemoMode Then
                                If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                                    (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                                    (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                                    Call gobjCommProtocol.funcReadADCFilter(gobjInst.Average, dblYNew)
                                End If
                                '//-----

                                intSpeedIncrease += intSpeed
                                dblWv = dblXMin + CDbl(intSpeedIncrease) / CDbl(intSetpsPernm)

                                '//----- For Demo Mode
                                '#If DEMO Then
                                '		if (wv>=SpectGraph.Xmax ||addata.counter>= MAXSIZE)
                                '		  break;
                                '#End If
                                'If gstructSettings.AppMode = EnumAppMode.DemoMode Then
                                If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                                    (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                                    (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                                    If ((dblWv >= mdblMaxWavelength) Or (dblWv <= mdblMinWavelength)) Then
                                        Exit Do
                                    End If
                                End If

                                If (dblYNew = 4095) Then
                                    'Gerror_message_new("Full scale overflow, Reduce PMT/D2cur", "UV SPECTRUM");
                                    'PostMessage(hwnd, WM_COMMAND, IDC_START, 0);
                                    gobjInst.D2Pmt = 0
                                End If

                                '//----- Get Abs/ En Value
                                '--- Check spectrum value for Baseline
                                If bln_BaseLine = True Then
                                    If gintSample_adc.Length > 0 Then
                                        gintSample_adc(intsamp_adcCounter) = dblYNew
                                    End If
                                    blYasisReading = gfuncGetConvertToUVAbs(dblYNew, dblYNew)
                                    intsamp_adcCounter += 1
                                Else
                                    If gintSample_adc.Length > 0 Then
                                        blYasisReading = gfuncGetConvertToUVAbs(dblYNew, gintSample_adc(intsamp_adcCounter))
                                        intsamp_adcCounter += 1
                                    End If
                                    'if (addata.ad && addata.counter<MAXSIZE)
                                    '    addata.ad[addata.counter++]=ynew;
                                End If
                                mblnEndProcess = False
                                '--- Send the data to the screen by '|' seperated
                                'mobjThreadController.Display(dblWv.ToString & "|" & blYasisReading.ToString)
                                mobjThreadController.Display(dblWv.ToString & "|" & blYasisReading.ToString & "|" & blYasisReading.ToString)
                                gobjCommProtocol.mobjCommdll.subTime_Delay(intTimeDelay)

                                ' Check the property for interuption from user to terminate the process
                                If ThTerminate = True Then
                                    If gobjMessageAdapter.ShowMessage(strMsg) = True Then
                                        Application.DoEvents()
                                        If gobjCommProtocol.funcBreakSpectrum() = False Then
                                            Exit Do
                                        Else
                                            Exit Do
                                        End If
                                    Else
                                        Application.DoEvents()
                                        ThTerminate = False
                                    End If

                                End If


                                If gobjCommProtocol.funcPC_END() = False Then
                                    Exit Do
                                End If
                                gobjCommProtocol.mobjCommdll.subTime_Delay(intTimeDelay)
                                Application.DoEvents()
                                funcThreadDBUVSpectrum = True
                            Else
                                Exit Do
                            End If
                        End If
                        If Not mobjThreadController.Running Then
                            Exit Do
                        End If
                        'Application.DoEvents()
                    Loop
                End If
                'End If
                '//*******************************************************************
            End If

ExitSpectrum:
            '//-----   Set Wv '& Abs/En
            'Wavelength_Position(hdc, SpectGraph.Xmin, 20, 372)
            Application.DoEvents()
            gobjCommProtocol.Wavelength_Position(dblWvMin, lblObjStatusIn)
            gobjCommProtocol.mobjCommdll.subTime_Delay(50)
            intsamp_adcCounter = 0
            '//----- Display Current Wavelength
            If gobjCommProtocol.funcGet_Current_Wv(dblCurrWv) = True Then

                lblObjStatusIn.text = mXValueLable & dblCurrWv.ToString
                lblObjStatusIn.refresh()
                lblObjWV_ABSIn.text = mYValueLable & "0.0"
                lblObjWV_ABSIn.refresh()
            Else

                lblObjStatusIn.text = mXValueLable
                lblObjStatusIn.refresh()
                lblObjWV_ABSIn.text = mYValueLable
                lblObjWV_ABSIn.refresh()
            End If
            '//----------------

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
            'ThTerminate = False
            SpectrumWait = False
        End Try
    End Function

    Private Function funcThreadDBAbsTimeScan(ByRef lblObjStatusIn As System.Object, _
                                        ByRef lblObjWV_ABSIn As System.Object, _
                                        ByVal dblXMax As Double, _
                                        ByVal dblXMin As Double, _
                                        ByVal dblYMax As Double, _
                                        ByVal dblYMin As Double, _
                                        ByVal intMode As Integer, _
                                        ByVal dblAbsScanthldval As Double, _
                                        ByVal blnCheckMinAbsScanLmt As Boolean) As Boolean
        '------------------------------------------------------------------
        'Procedure Name         :   funcThreadDBAbsTimeScan
        'Description            :   Start the process for UV Spectrum of bouble beam
        'Affected Parameters    :   lblObjStatusIn,lblObjWV_ABSIn as label on form
        'Parameters             :   dblXMax,dblXMin,dblYMax,dblYMin,intMode,dblAbsScanthldval,blnCheckMinAbsScanLmt
        'Return                 :   True if success.
        'Time/Date              :   5/10/06
        'Dependencies           :   
        'Author                 :   Sachin Dokhale.
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        '------------------------------------------------

        '------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim CEnd1, CEnd As Long
        'Dim ConstManipulate As Long = 1000
        Dim ConstManipulate As Long = 10000000
        Dim dblAbs As Double
        Dim dblAbs_RefBeam As Double
        Dim dblAbs_DoubleBeam As Double
        Dim dblXaxisTime1 As Double
        Try

            Application.DoEvents()

            Dim objWait1 As New CWaitCursor
            '//----- 1  Set Wv '& Abs/En
            lblObjStatusIn.text = mXValueLable & dblXMax.ToString
            lblObjStatusIn.refresh()
            lblObjWV_ABSIn.text = mYValueLable & "0.0"

            If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
                lblObjWV_ABSIn.Visible = True
            ElseIf gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.ReferenceBeam Then
                lblObjWV_ABSIn.Visible = False
            ElseIf gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam Then
                lblObjWV_ABSIn.Visible = True
            End If

            lblObjWV_ABSIn.refresh()

            '//----------------
            gobjClsAAS203.ReInitInstParameters()
            '--- Read Start time stamp
            CEnd1 = System.DateTime.Now.Ticks

            ' Start to Reading and sending data
            Do While (Not ThTerminate = True)
                If Not SpectrumWait = True Then
                    If Not (CEnd = CEnd1) Then
                        '--- Check calibration mode 
                        If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
                            If gobjInst.Mode = EnumCalibrationMode.AA Then
                                If gstructSettings.IsCustomerDisplayMode = False Then
                                    '--- Read Sample ADC count 
                                    If Not SpectrumWait = True Then
                                        dblAbs = gobjClsAAS203.funcGetAbsScanX()
                                    End If
                                    '--- Read Sample Abs scan
                                    If Not SpectrumWait = True Then
                                        dblAbs_RefBeam = gobjClsAAS203.funcGetAbsScanX_RefBeam()
                                    End If
                                    '--- Read Double (Drift) Abs scan
                                    If Not SpectrumWait = True Then
                                        dblAbs_DoubleBeam = gobjClsAAS203.funcGetAbsScanX_DoubleBeam()
                                    End If
                                Else

                                    '--- Read Double (Drift) Abs scan
                                    If Not SpectrumWait = True Then
                                        dblAbs_DoubleBeam = gobjClsAAS203.funcGetAbsScanX_DoubleBeam()
                                    End If
                                End If
                            Else
                                '--- Read Sample Abs scan
                                If Not SpectrumWait = True Then
                                    dblAbs = gobjClsAAS203.funcGetAbsScanX()
                                End If
                            End If
                            '--- Filter the data
                            If (gblnSmoothFilter = True) Then
                                dblAbs = funcGetFiltData(dblAbs)
                                dblAbs_RefBeam = funcGetFiltData_RefBeam(dblAbs_RefBeam)
                                dblAbs_DoubleBeam = funcGetFiltData_DoubleBeam(dblAbs_DoubleBeam)
                            End If
                        ElseIf gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.ReferenceBeam Then
                            '--- Read Sample Abs scan
                            If Not SpectrumWait = True Then
                                dblAbs_RefBeam = gobjClsAAS203.funcGetAbsScanX_RefBeam()
                            End If
                            '--- Filter the data
                            If (gblnSmoothFilter = True) Then
                                dblAbs_RefBeam = funcGetFiltData_RefBeam(dblAbs_RefBeam)
                            End If
                        ElseIf gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam Then
                            '--- Read Sample Abs scan
                            If Not SpectrumWait = True Then
                                dblAbs = gobjClsAAS203.funcGetAbsScanX()
                            End If
                            '--- Filter the data
                            If (gblnSmoothFilter = True) Then
                                dblAbs = funcGetFiltData(dblAbs)
                            End If
                        End If
                        '---- Check the Abs Scan min. limits
                        If blnCheckMinAbsScanLmt = True Then
                            If (dblAbs < dblAbsScanthldval) Then
                                dblAbs = 0.0
                            End If
                            If (dblAbs_RefBeam < dblAbsScanthldval) Then
                                dblAbs_RefBeam = 0.0
                            End If
                            If (dblAbs_DoubleBeam < dblAbsScanthldval) Then
                                dblAbs_DoubleBeam = 0.0
                            End If
                        End If
                        '--- Read the current time stamp
                        CEnd = System.DateTime.Now.Ticks
                        dblXaxisTime1 = ((CEnd - CEnd1) / ConstManipulate)
                        '--- Check for running state of thread control
                        If mobjThreadController.Running = True Then
                            '--- Check for application lavel evnts process is finished
                            If mblnEndProcess = True Then
                                mblnEndProcess = False
                                '--- implements thread control to display data
                                mobjThreadController.Display(dblXaxisTime1.ToString & "|" & _
                                        dblAbs.ToString & "|" & dblAbs_RefBeam.ToString & "|" & dblAbs_DoubleBeam & "|" & gintInstrumentBeamType.ToString)
                                gobjClsAAS203.funcCheck_Flame() '30.12.08
                            End If
                        End If
                        'If (gstructSettings.AppMode = EnumAppMode.DemoMode) Then
                        If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                            (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                            (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                            gobjCommProtocol.mobjCommdll.subTime_Delay(100)
                            Application.DoEvents()
                        End If
                    End If
                Else
                    CEnd = System.DateTime.Now.Ticks
                    'Application.DoEvents()
                End If
                Application.DoEvents()
            Loop
            lblObjStatusIn.text = mXValueLable & Format(dblXaxisTime1, "#0.0##").ToString
            lblObjStatusIn.refresh()
            lblObjWV_ABSIn.text = mYValueLable & "0.0"
            lblObjWV_ABSIn.refresh()
            funcThreadDBAbsTimeScan = True
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
            SpectrumWait = False
            'Application.DoEvents()
        End Try
    End Function

#End Region


    Private Function funcGetFiltData(ByVal ADCVolt As Double) As Double
        '=====================================================================
        ' Procedure Name        : funcGetFiltData
        ' Parameters Passed     :  ADCVolts
        ' Returns               : Double Returns filtered data
        ' Purpose               : for fliter the data , used in time scan mode
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.12.06
        ' Revisions             : 
        '=====================================================================
        Static Dim Xn_2 As Double = 0
        Static Dim Xn_1 As Double = 0
        Static Dim Yn_1 As Double = 0
        Static Dim Yn_2 As Double = 0
        Static Dim filtdata As Double = 0
        Static intCal_Mode As Integer
        Dim xcoeff1002(,) As Double = {{0.067455, 0.134911, 0.067455}, {0.020083, 0.040167, 0.020083}, {0.003622, 0.007243, 0.003622}, {0.000945, 0.001889, 0.000945}, {0.000039, 0.000078, 0.000039}, {0.00001, 0.00002, 0.00001}}
        Dim ycoeff1002(,) As Double = {{1.14298, -0.412802}, {1.56102, -0.641352}, {1.8227, -0.837182}, {1.9112, -0.914976}, {1.98223, -0.982385}, {1.99111, -0.991154}}
        Try
            '            int TimeConst=2;
            'double 	S4FUNC	GetFiltData( double ADCVolt )
            '{
            'double xcoeff1002[6][3] ={
            '					{0.067455,0.134911,0.067455}, //0.131106,0.262213,0.131106, 	 // fc = 10 Hz, fs = 100 Hz, O = 2
            '					{0.020083,0.040167,0.020083}, // fc = 5 Hz, fs = 100 Hz, O = 2
            '					{0.003622,0.007243,0.003622}, //fc = 2 Hz fs = 100 Hz, O = 2
            '					{0.000945,0.001889,0.000945}, // fc = 1 Hz fs = 100 Hz O = 2
            '					{0.000039,0.000078,0.000039}, // fc = 0.2 Hz fs = 100 Hz O = 2
            '					{0.000010,0.000020,0.000010}
            '				 }; // fc = 0.1 Hz fs = 100 Hz O = 2
            'double ycoeff1002[6][2] ={
            '					{1.14298,-0.412802},  // 0.747789,-0.272215, 	// fc = 10 Hz, fs = 100 Hz, O = 2
            '					{1.56102,-0.641352},		 // fc = 5 Hz, fs = 100 Hz, O = 2
            '					{1.8227,-0.837182},		// fc = 2 Hz, fs = 100 Hz, O = 2
            '					{1.9112,-0.914976},		// fc = 1 hz fs = 100 O Hz O = 2
            '					{1.98223,-0.982385},       // fc = 0.2 Hz fs = 100 Hz O = 2
            '					{1.99111,-0.991154}};		// fc = 0.1 Hz fs = 100 Hz O = 2
            '//-----butterworth filter Order = 2 Sampling Freq = 100Hz ------------
            'static	double Xn_2=0,Xn_1=0,Yn_1=0,Yn_2=0,filtdata=0;

            '			filtdata  = xcoeff1002[TimeConst][0]*ADCVolt;
            '			filtdata += xcoeff1002[TimeConst][1]*Xn_1;
            '			filtdata += xcoeff1002[TimeConst][2]*Xn_2;
            '			filtdata += ycoeff1002[TimeConst][0]*Yn_1;
            '			filtdata += ycoeff1002[TimeConst][1]*Yn_2;
            '			Xn_2 = Xn_1;
            '			Xn_1 = ADCVolt;
            '			Yn_2 = Yn_1;
            '			Yn_1 = filtdata;
            'return filtdata;
            '}
            '//----- Start from here
            'Dim intTimeConst As Integer = 2

            '}; // fc = 0.1 Hz fs = 100 Hz O = 2


            '//-----butterworth filter Order = 2 Sampling Freq = 100Hz ------------
            'static	double Xn_2=0,Xn_1=0,Yn_1=0,Yn_2=0,filtdata=0;
            filtdata = xcoeff1002(gintTimeConstant, 0) * ADCVolt
            filtdata += xcoeff1002(gintTimeConstant, 1) * Xn_1
            filtdata += xcoeff1002(gintTimeConstant, 2) * Xn_2
            filtdata += ycoeff1002(gintTimeConstant, 0) * Yn_1
            filtdata += ycoeff1002(gintTimeConstant, 1) * Yn_2
            Xn_2 = Xn_1
            Xn_1 = ADCVolt
            Yn_2 = Yn_1
            Yn_1 = filtdata
            Return filtdata

            '}

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

    Private Function funcGetFiltData_RefBeam(ByVal ADCVolt As Double) As Double
        '=====================================================================
        ' Procedure Name        : funcGetFiltData_RefBeam
        ' Parameters Passed     :  ADCVolts
        ' Returns               : Double Returns Filtered data
        ' Purpose               : for getting fliter data for ref beam.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 07.04.07
        ' Revisions             : 
        '=====================================================================
        Static Dim Xn_2 As Double = 0
        Static Dim Xn_1 As Double = 0
        Static Dim Yn_1 As Double = 0
        Static Dim Yn_2 As Double = 0
        Static Dim filtdata As Double = 0
        Static intCal_Mode As Integer
        Dim xcoeff1002(,) As Double = {{0.067455, 0.134911, 0.067455}, {0.020083, 0.040167, 0.020083}, {0.003622, 0.007243, 0.003622}, {0.000945, 0.001889, 0.000945}, {0.000039, 0.000078, 0.000039}, {0.00001, 0.00002, 0.00001}}
        Dim ycoeff1002(,) As Double = {{1.14298, -0.412802}, {1.56102, -0.641352}, {1.8227, -0.837182}, {1.9112, -0.914976}, {1.98223, -0.982385}, {1.99111, -0.991154}}
        Try
            '            int TimeConst=2;
            'double 	S4FUNC	GetFiltData( double ADCVolt )
            '{
            'double xcoeff1002[6][3] ={
            '					{0.067455,0.134911,0.067455}, //0.131106,0.262213,0.131106, 	 // fc = 10 Hz, fs = 100 Hz, O = 2
            '					{0.020083,0.040167,0.020083}, // fc = 5 Hz, fs = 100 Hz, O = 2
            '					{0.003622,0.007243,0.003622}, //fc = 2 Hz fs = 100 Hz, O = 2
            '					{0.000945,0.001889,0.000945}, // fc = 1 Hz fs = 100 Hz O = 2
            '					{0.000039,0.000078,0.000039}, // fc = 0.2 Hz fs = 100 Hz O = 2
            '					{0.000010,0.000020,0.000010}
            '				 }; // fc = 0.1 Hz fs = 100 Hz O = 2
            'double ycoeff1002[6][2] ={
            '					{1.14298,-0.412802},  // 0.747789,-0.272215, 	// fc = 10 Hz, fs = 100 Hz, O = 2
            '					{1.56102,-0.641352},		 // fc = 5 Hz, fs = 100 Hz, O = 2
            '					{1.8227,-0.837182},		// fc = 2 Hz, fs = 100 Hz, O = 2
            '					{1.9112,-0.914976},		// fc = 1 hz fs = 100 O Hz O = 2
            '					{1.98223,-0.982385},       // fc = 0.2 Hz fs = 100 Hz O = 2
            '					{1.99111,-0.991154}};		// fc = 0.1 Hz fs = 100 Hz O = 2
            '//-----butterworth filter Order = 2 Sampling Freq = 100Hz ------------
            'static	double Xn_2=0,Xn_1=0,Yn_1=0,Yn_2=0,filtdata=0;

            '			filtdata  = xcoeff1002[TimeConst][0]*ADCVolt;
            '			filtdata += xcoeff1002[TimeConst][1]*Xn_1;
            '			filtdata += xcoeff1002[TimeConst][2]*Xn_2;
            '			filtdata += ycoeff1002[TimeConst][0]*Yn_1;
            '			filtdata += ycoeff1002[TimeConst][1]*Yn_2;
            '			Xn_2 = Xn_1;
            '			Xn_1 = ADCVolt;
            '			Yn_2 = Yn_1;
            '			Yn_1 = filtdata;
            'return filtdata;
            '}
            '//----- Start from here
            'Dim intTimeConst As Integer = 2

            '}; // fc = 0.1 Hz fs = 100 Hz O = 2


            '//-----butterworth filter Order = 2 Sampling Freq = 100Hz ------------
            'static	double Xn_2=0,Xn_1=0,Yn_1=0,Yn_2=0,filtdata=0;

            filtdata = xcoeff1002(gintTimeConstant, 0) * ADCVolt
            filtdata += xcoeff1002(gintTimeConstant, 1) * Xn_1
            filtdata += xcoeff1002(gintTimeConstant, 2) * Xn_2
            filtdata += ycoeff1002(gintTimeConstant, 0) * Yn_1
            filtdata += ycoeff1002(gintTimeConstant, 1) * Yn_2
            Xn_2 = Xn_1
            Xn_1 = ADCVolt
            Yn_2 = Yn_1
            Yn_1 = filtdata
            Return filtdata

            '}

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

    Private Function funcGetFiltData_DoubleBeam(ByVal ADCVolt As Double) As Double
        '=====================================================================
        ' Procedure Name        : funcGetFiltData_DoubleBeam
        ' Parameters Passed     :  ADCVolts
        ' Returns               : Returns Filtered data
        ' Purpose               : for getting fliter data for double beam.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 07.04.07
        ' Revisions             : 
        '=====================================================================
        Static Dim Xn_2 As Double = 0
        Static Dim Xn_1 As Double = 0
        Static Dim Yn_1 As Double = 0
        Static Dim Yn_2 As Double = 0
        Static Dim filtdata As Double = 0
        Static intCal_Mode As Integer
        Dim xcoeff1002(,) As Double = {{0.067455, 0.134911, 0.067455}, {0.020083, 0.040167, 0.020083}, {0.003622, 0.007243, 0.003622}, {0.000945, 0.001889, 0.000945}, {0.000039, 0.000078, 0.000039}, {0.00001, 0.00002, 0.00001}}
        Dim ycoeff1002(,) As Double = {{1.14298, -0.412802}, {1.56102, -0.641352}, {1.8227, -0.837182}, {1.9112, -0.914976}, {1.98223, -0.982385}, {1.99111, -0.991154}}
        Try
            '            int TimeConst=2;
            'double 	S4FUNC	GetFiltData( double ADCVolt )
            '{
            'double xcoeff1002[6][3] ={
            '					{0.067455,0.134911,0.067455}, //0.131106,0.262213,0.131106, 	 // fc = 10 Hz, fs = 100 Hz, O = 2
            '					{0.020083,0.040167,0.020083}, // fc = 5 Hz, fs = 100 Hz, O = 2
            '					{0.003622,0.007243,0.003622}, //fc = 2 Hz fs = 100 Hz, O = 2
            '					{0.000945,0.001889,0.000945}, // fc = 1 Hz fs = 100 Hz O = 2
            '					{0.000039,0.000078,0.000039}, // fc = 0.2 Hz fs = 100 Hz O = 2
            '					{0.000010,0.000020,0.000010}
            '				 }; // fc = 0.1 Hz fs = 100 Hz O = 2
            'double ycoeff1002[6][2] ={
            '					{1.14298,-0.412802},  // 0.747789,-0.272215, 	// fc = 10 Hz, fs = 100 Hz, O = 2
            '					{1.56102,-0.641352},		 // fc = 5 Hz, fs = 100 Hz, O = 2
            '					{1.8227,-0.837182},		// fc = 2 Hz, fs = 100 Hz, O = 2
            '					{1.9112,-0.914976},		// fc = 1 hz fs = 100 O Hz O = 2
            '					{1.98223,-0.982385},       // fc = 0.2 Hz fs = 100 Hz O = 2
            '					{1.99111,-0.991154}};		// fc = 0.1 Hz fs = 100 Hz O = 2
            '//-----butterworth filter Order = 2 Sampling Freq = 100Hz ------------
            'static	double Xn_2=0,Xn_1=0,Yn_1=0,Yn_2=0,filtdata=0;

            '			filtdata  = xcoeff1002[TimeConst][0]*ADCVolt;
            '			filtdata += xcoeff1002[TimeConst][1]*Xn_1;
            '			filtdata += xcoeff1002[TimeConst][2]*Xn_2;
            '			filtdata += ycoeff1002[TimeConst][0]*Yn_1;
            '			filtdata += ycoeff1002[TimeConst][1]*Yn_2;
            '			Xn_2 = Xn_1;
            '			Xn_1 = ADCVolt;
            '			Yn_2 = Yn_1;
            '			Yn_1 = filtdata;
            'return filtdata;
            '}
            '//----- Start from here
            'Dim intTimeConst As Integer = 2

            '}; // fc = 0.1 Hz fs = 100 Hz O = 2

            '//-----butterworth filter Order = 2 Sampling Freq = 100Hz ------------
            'static	double Xn_2=0,Xn_1=0,Yn_1=0,Yn_2=0,filtdata=0;


            filtdata = xcoeff1002(gintTimeConstant, 0) * ADCVolt
            filtdata += xcoeff1002(gintTimeConstant, 1) * Xn_1
            filtdata += xcoeff1002(gintTimeConstant, 2) * Xn_2
            filtdata += ycoeff1002(gintTimeConstant, 0) * Yn_1
            filtdata += ycoeff1002(gintTimeConstant, 1) * Yn_2
            Xn_2 = Xn_1
            Xn_1 = ADCVolt
            Yn_2 = Yn_1
            Yn_1 = filtdata
            Return filtdata

            '}

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

#End Region

End Class
