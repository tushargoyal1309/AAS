Imports BgThread
Imports AAS203.Common
Imports AAS203Library.Instrument

Public Class clsBgOptimizeAll
    Implements BgThread.IBgWorker

#Region " Constructors "

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByRef lblSt1Opt As Label, ByRef lblSt2Opt As Label, ByRef lblSt3Opt As Label, ByRef objGraphOpt As Object)
        '=====================================================================
        ' Procedure Name        : New
        ' Parameters Passed     : lblSt1,lblSt2,lblSt3,dblLampCurrent ,intLampPos,objGraph
        ' Returns               : 
        ' Purpose               : To initialize the object
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak B.
        ' Created               : 29.11.06
        ' Revisions             : 
        '=====================================================================
        MyBase.New()

        Try
            mlblStatus1Opt = lblSt1Opt
            mlblStatus2Opt = lblSt2Opt
            mlblStatus3Opt = lblSt3Opt
            mObjGraphOpt = objGraphOpt

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

    Private mController As clsBgThread
    Private mobjThreadController As IBgThread
    Private mlblStatus1Opt, mlblStatus2Opt, mlblStatus3Opt As Label
    Private mObjGraphOpt As Object

#End Region

#Region " Public Functions "

    Public Sub Initialize(ByVal Controller As BgThread.IBgThread) Implements BgThread.IBgWorker.Initialize
        '=====================================================================
        ' Procedure Name        : Initialize
        ' Parameters Passed     : Controller
        ' Returns               : IBgWorker.Initialize as implements
        ' Purpose               : To Initialize the thread
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak B.
        ' Created               : 29.11.06
        ' Revisions             : 
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
        ' Parameters Passed     : None
        ' Returns               : IBgWorker.Start as Implements
        ' Purpose               : To Start the worker thread
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak B.
        ' Created               : 29.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objwait As New CWaitCursor
        Try
            '//----- Added by Sachin Dokhale on 25.03.07
            '//----- To know the Status of Thread on Status Bar of MDI Main
            Dim strPreviousStatusMessage As String
            If gblnShowThreadOnfrmMDIStatusBar Then
                strPreviousStatusMessage = gobjMain.StatusBar1.Text
                gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage & " *Opti All Turret"
                Application.DoEvents()
                '---show a status and allow application to perfrom its panding work.
            End If
            '//-----
            If mobjThreadController.Running Then
                If funcTur_Opt_Zero(mlblStatus1Opt, mlblStatus2Opt, mlblStatus3Opt, mObjGraphOpt, mobjThreadController) = True Then
                    ''this is main function for turrert optmization.
                    mobjThreadController.Completed(True)
                    'Application.DoEvents()
                End If
            Else
                mobjThreadController.Completed(True)
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
            'gobjCommProtocol.mobjCommdll.subTime_Delay(100)
            '//----- Added by Sachin Dokhale on 25.03.07
            '//----- To remove the Status of Thread on Status Bar of MDI Main
            If gblnShowThreadOnfrmMDIStatusBar Then
                gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage
                '---show a info opn status bar.
                Application.DoEvents()
                '---allow application to perfrom its panding work.
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

    Public Function funcTur_Opt_Zero(Optional ByRef lblStatus1 As Object = Nothing, Optional ByRef lblStatus2 As Object = Nothing, Optional ByRef lblStatus3 As Object = Nothing, Optional ByRef ObjGraph As Object = Nothing, Optional ByVal ObjThreadController As Object = Nothing) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcTur_OptThread
        'Description            :   To optimise turret
        'Parameters             :   lblStatus1,lblStatus2,lblStatus3 as label,ObjGraph  as AASGraph
        'Parameter Affected     :   ObjThreadController as thread controller
        'Returns                :   True if success
        'Time/Date              :   17.11.06
        'Dependencies           :   
        'Author                 :   Deepak B.
        'Revision               :
        'Revision by Person     :   
        '--------------------------------------------------------------------------------------
        Dim rPOs As Integer
        Dim intCounter As Integer
        Dim chNew As Integer
        Dim max_int As Integer
        Dim in_pos As Integer
        Dim dblEnergy As Double
        Dim strData As String
        '---------------------------------------------------
        '        void	Tur_Opt(HWND hwnd, HDC hdc)
        '{
        'int    chnew, i;
        'int    in_pos, max_int, rpos;
        'char line7[80]="";

        ' SetFocus(hwnd);
        ' if( GetInstrument() == AA202)
        '	 SetText(hwnd, IDC_STATUS, "Lamp Optimization");
        '        Else
        '	 SetText(hwnd, IDC_STATUS, "Turret Optimization");
        ' Cal_Mode(HCLE);
        ' rpos = Tur_pre_opt(hwnd);

        '#If !NEWZERO Then
        '  Adj_PMT_forvalue(hwnd, (double) 3500.0, (double)350);
        '#Else
        '  Adj_PMT_forvalue(hwnd, (double)(3500.0*100.0/5000.0 ), (double)350.0);
        '#End If
        ' Show_Pmt(hwnd, Inst->Pmtv);
        ' pc_delay (200);
        ' for (i=1; i<=rpos+10; i++)  {
        '	Rotate_Anticlock_Tur();
        '	}
        ' for (i=1; i<=10; i++) {
        '	Rotate_Clock_Tur();
        '  }
        ' if(GetInstrument() == AA202)
        '	 SetWindowText(hwnd,"OPTIMISING LAMP");
        '                    Else
        '	 SetWindowText(hwnd,"OPTIMISING TURRET");
        ' PeakGraph.Xmin= 1; PeakGraph.Xmax= RANGE;
        ' PeakGraph.Ymin= GetEnergy(2047);
        ' PeakGraph.Ymax= GetEnergy(2047.0+409.6*4);
        ' strcpy(PYaxis,"ENERGY"); strcpy(PXaxis,"TURRET STEP");
        ' Show_Peak_Param(hwnd, RANGE);
        ' if( GetInstrument() == AA202 )
        '   SetText(hwnd, IDC_STATUS1, "Scanning for Optimal Lamp Position");
        '                        Else
        '	 SetText(hwnd, IDC_STATUS1, "Scanning for Optimal Turret Position");
        ' in_pos = 1;
        ' max_int = 0;
        ' ReadADCFilter();
        ' for (i=1; i<=RANGE; i++) {
        '	Rotate_Clock_Tur();
        '	pc_delay(100);
        '	chnew = ReadADCFilter();
        '	if (chnew > max_int) {
        '	  max_int = chnew;
        '	  in_pos =i;
        '	 }
        '  if (i==1)
        '		GPlotInit(hdc, (double) i, GetEnergy(chnew));
        '                                    Else
        '		GPlot(hdc, (double) i, GetEnergy(chnew));
        ' }
        ' GShowPeak(hdc,(double) in_pos,  GetEnergy(max_int),NULL);
        ' SetText(hwnd, IDC_STATUS," Positioning Please Wait  .......        ");
        '#If EMU Then
        ' Wait_For_Some_Msg(5);
        '#End If
        ' for (i=1; i <= RANGE+10; i++) 	Rotate_Anticlock_Tur();
        ' for (i=1; i <= 10+in_pos; i++)  {
        '	Rotate_Clock_Tur();	
        '	}
        'Inst->Lamp_par.lamp[Inst->Lamp_pos-1].lamp_optpos = in_pos;	
        'for(i=0;i<500; i++)
        ' pc_delay(10000);
        '}

        '---------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim dblYMin, dblYMax As Double

        Try
            funcTur_Opt_Zero = False
            'if( GetInstrument() == AA202)
            '	 SetText(hwnd, IDC_STATUS, "Lamp Optimization");
            '        Else
            '	 SetText(hwnd, IDC_STATUS, "Turret Optimization");
            If Not lblStatus3 Is Nothing Then
                If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                    CType(lblStatus3, Windows.Forms.Label).Text = "Lamp Optimization"
                Else
                    CType(lblStatus3, Windows.Forms.Label).Text = "Turret Optimization"
                End If

            End If
            'Added by pankaj on 21 Jan 08
            If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                gobjCommProtocol.funcSet_PMTReferenceBeam(0) 'Added by pankaj on 21 Jan 08
            End If
            '------------

            '---Set calibration mode as HCLE
            If gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.HCLE) = False Then
                'MessageBox.Show("Error in setting calibration mode")
                gobjMessageAdapter.ShowMessage(constCalibrationMode)
                Application.DoEvents()
            End If

            '---pre optimize turret
            rPOs = gobjCommProtocol.funcTur_Pre_Opt(lblStatus1, lblStatus2, lblStatus3)

            '---adjust pmt between 70-350
            If gobjCommProtocol.funcAdj_Pmt_ForValue(CDbl(70.0), CDbl(350.0), True) = False Then
                'MessageBox.Show("Error in adjusting pmt for value")
                gobjMessageAdapter.ShowMessage(constPMTVolt)
                Application.DoEvents()
            End If

            If Not lblStatus1 Is Nothing Then
                CType(lblStatus1, Windows.Forms.Label).Text = "PMT : -" & Format(gobjInst.PmtVoltage, "###")
                CType(lblStatus1, Windows.Forms.Label).Refresh()
            End If

            objWait = New CWaitCursor

            'gobjCommProtocol.mobjCommdll.subTime_Delay(200)

            '---rotate turret anticlockwise preoptimize position + 10 times.
            For intCounter = 1 To rPOs + 10
                gobjCommProtocol.funcRotate_Anticlock_Tur()
            Next

            '---rotate turret clockwise preoptimize 10 times.
            For intCounter = 1 To 10
                gobjCommProtocol.funcRotate_Clock_Tur()
            Next

            objWait = New CWaitCursor

            dblYMin = -1 'Cint(FormatNumber(gFuncGetEnergy(4095), 1))
            dblYMax = CInt(FormatNumber(gFuncGetEnergy(2047.0 + 409.6 * 4), 1))

            If Not ObjGraph Is Nothing Then
                CType(ObjGraph, AASGraph).XAxisMin = 0
                CType(ObjGraph, AASGraph).XAxisMax = WVRANGE
                CType(ObjGraph, AASGraph).YAxisMin = dblYMin
                CType(ObjGraph, AASGraph).YAxisMax = dblYMax

                CType(ObjGraph, AASGraph).AldysPane.XAxis.PickScale(1, WVRANGE)
                CType(ObjGraph, AASGraph).AldysPane.XAxis.MinorStepAuto = True
                CType(ObjGraph, AASGraph).AldysPane.XAxis.StepAuto = True
                CType(ObjGraph, AASGraph).Refresh()

                CType(ObjGraph, AASGraph).AldysPane.YAxis.PickScale(dblYMin, dblYMax)
                CType(ObjGraph, AASGraph).AldysPane.YAxis.MinorStepAuto = True
                CType(ObjGraph, AASGraph).AldysPane.YAxis.StepAuto = True
                CType(ObjGraph, AASGraph).Refresh()

                CType(ObjGraph, AASGraph).XAxisLabel = "TURRET STEP"
                CType(ObjGraph, AASGraph).YAxisLabel = "ENERGY"
                CType(ObjGraph, AASGraph).AldysPane.AxisChange()
                CType(ObjGraph, AASGraph).Invalidate()
                CType(ObjGraph, AASGraph).Refresh()
            End If

            If Not lblStatus2 Is Nothing Then
                'CType(lblStatus2, Windows.Forms.Label).Text = "Scanning for Optimal Turret Position"
                If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                    CType(lblStatus2, Windows.Forms.Label).Text = "Scanning for Optimal Lamp Position"
                Else
                    CType(lblStatus2, Windows.Forms.Label).Text = "Scanning for Optimal Turret Position"
                End If
                '   SetText(hwnd, IDC_STATUS1, "Scanning for Optimal Lamp Position");
                '                        Else
                '	 SetText(hwnd, IDC_STATUS1, "Scanning for Optimal Turret Position");
            End If

            objWait = New CWaitCursor
            in_pos = 1
            max_int = 0
            '---read adc filter value
            gobjCommProtocol.funcReadADCFilter(gobjInst.Average, chNew)

            For intCounter = 1 To WVRANGE
                '---rotate turret clockwise
                gobjCommProtocol.funcRotate_Clock_Tur()
                'gobjCommProtocol.mobjCommdll.subTime_Delay(100)
                '---read adc filter.
                gobjCommProtocol.funcReadADCFilter(gobjInst.Average, chNew)
                If chNew > max_int Then
                    max_int = chNew
                    in_pos = intCounter
                End If
                '---get energy
                dblEnergy = gFuncGetEnergy(chNew)
                strData = ""
                strData = intCounter & "," & dblEnergy
                If Not ObjThreadController Is Nothing Then
                    CType(ObjThreadController, BgThread.IBgThread).Display(strData)
                End If
                CType(ObjGraph, AASGraph).Refresh()
            Next
            'GShowPeak(hdc,(double) in_pos,  GetEnergy(max_int),NULL);  todo later

            If Not lblStatus2 Is Nothing Then
                CType(lblStatus2, Windows.Forms.Label).Text = "Positioning Please Wait  .......        "
            End If

            '---rotate turret anticlockwise 110 times.
            For intCounter = 1 To WVRANGE + 10
                gobjCommProtocol.funcRotate_Anticlock_Tur()
            Next

            objWait = New CWaitCursor

            '---rotate turret 10 + in_pos times.
            For intCounter = 1 To 10 + in_pos
                gobjCommProtocol.funcRotate_Clock_Tur()
            Next

            '---store lamp optimize position.
            gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).LampOptimizePosition = in_pos

            '---save instrument conditions status.
            If gstructSettings.ExeToRun = EnumApplicationMode.AAS Then
                funcSaveInstStatus()
            End If

            If Not lblStatus2 Is Nothing Then
                CType(lblStatus2, Windows.Forms.Label).Text = "Finished. "
            End If

            If Not ObjThreadController Is Nothing Then
                CType(ObjThreadController, BgThread.IBgThread).Completed(False)
            End If

            gobjCommProtocol.mobjCommdll.subTime_Delay(1500)

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

#End Region

End Class
