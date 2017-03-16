Imports BgThread
Imports AAS203.Common
Imports AAS203Library.Instrument

Public Class clsBgZeroOrder_AA201
    Implements BgThread.IBgWorker

#Region " Constructors "

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal intLampPosition As Integer, ByRef lblSt1Zero As Label, ByRef lblSt2Zero As Label, ByRef lblSt3Zero As Label, ByRef objGraphZero As AAS203.AASGraph)
        '=====================================================================
        ' Procedure Name        : New
        ' Parameters Passed     : intLampPosition,lblSt1Zero,lblSt2Zero,lblSt3Zero,objGraphZero
        ' Returns               : None
        ' Purpose               : To initialize the object of this class
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 11-Apr-2007
        ' Revisions             : 
        '=====================================================================
        MyBase.New()

        Try
            '--- set reference of passed variables to module level variables
            mlblStatus1ZeroOrder = lblSt1Zero
            mlblStatus2ZeroOrder = lblSt2Zero
            mlblStatus3ZeroOrder = lblSt3Zero
            mObjGraphZeroOrder = objGraphZero
            mintLampPosition = intLampPosition

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
    Private mlblStatus1ZeroOrder, mlblStatus2ZeroOrder, mlblStatus3ZeroOrder As Label
    Private mlblStatus1Opt, mlblStatus2Opt, mlblStatus3Opt As Label
    Private mObjGraphZeroOrder As AASGraph
    Private mObjGraphOpt As AASGraph
    Private mintLampPosition As Integer

#End Region

#Region " Constants "

    Private Const Const_Initialize = "Initialising Please Wait  ......."

#End Region

#Region " Public Functions "

    Public Sub Initialize(ByVal Controller As BgThread.IBgThread) Implements BgThread.IBgWorker.Initialize
        '=====================================================================
        ' Procedure Name        : Initialize
        ' Parameters Passed     : Controller
        ' Returns               : None
        ' Purpose               : To Initialize the thread
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 11-Apr-2007
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
        ' Returns               : None
        ' Purpose               : To Start the worker thread
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 11-Apr-2007
        ' Revisions             : 
        '=====================================================================
        Dim objwait As New CWaitCursor
        Dim strPreviousStatusMessage As String
        Try
            '--- Added by Sachin Dokhale on 25.03.07
            '--- To know the Status of Thread on Status Bar of MDI Main
            If gblnShowThreadOnfrmMDIStatusBar Then
                strPreviousStatusMessage = gobjMain.StatusBar1.Text
                gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage & " *ZeroOrder"
                Application.DoEvents()
            End If
            '---

            If mobjThreadController.Running Then
                '--- perform zero order for 201
                If funcOptimise_Zero_Order_201(mlblStatus1ZeroOrder, mlblStatus2ZeroOrder, mlblStatus3ZeroOrder, _
                        mlblStatus1Opt, mlblStatus2Opt, mlblStatus3Opt, mObjGraphZeroOrder, mObjGraphOpt, mobjThreadController) = True Then
                    mobjThreadController.Completed(False)
                    Application.DoEvents()
                End If
            Else
                mobjThreadController.Completed(True)
                Application.DoEvents()
                '--- Added by Sachin Dokhale on 25.03.07
                '--- To remove the Status of Thread on Status Bar of MDI Main
                If gblnShowThreadOnfrmMDIStatusBar Then
                    gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage
                    Application.DoEvents()
                End If
                '---
                Exit Sub
            End If

            '--- Added by Sachin Dokhale on 25.03.07
            '--- To remove the Status of Thread on Status Bar of MDI Main
            If gblnShowThreadOnfrmMDIStatusBar Then
                gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage
                Application.DoEvents()
            End If
            '---

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

    Private Function funcOptimise_Zero_Order_201(Optional ByRef lblSt1Zero As Label = Nothing, Optional ByRef lblSt2Zero As Label = Nothing, Optional ByRef lblSt3Zero As Label = Nothing, _
                                                 Optional ByRef lblSt1Opt As Label = Nothing, Optional ByRef lblSt2Opt As Label = Nothing, Optional ByRef lblSt3Opt As Label = Nothing, _
                                                 Optional ByRef objGraphZero As AASGraph = Nothing, Optional ByRef objGraphOpt As Object = Nothing, _
                                                 Optional ByVal objController As BgThread.IBgThread = Nothing) As Boolean
        '---------------------------------------------------------------------------------------
        'Procedure Name         :   funcOptimise_Zero_Order_201
        'Description            :   To optimise Turret position 
        'Parameters             :   objController as Thread controler
        'Parameters affected    :   lblSt1Zero,lblSt1Opt,lblSt2Zero,lblSt3Zero,lblSt2Opt,lblSt3Opt as label object
        '                           objGraphZero,objGraphOpt as AASGraph
        'Return                 :   True if success
        'Time/Date              :   11-Apr-2007
        'Dependencies           :   parameter objects must be passed
        'Author                 :   Mangesh Shardul
        'Revision               :
        'Revision by Person     :   
        '--------------------------------------------------------------------------------------
        '--------------------------------------------------------------------------------------
        'void	Optimize_Zero_order_AA202(HWND hpar,int pos)
        '{
        '	double   cur=0.0;
        '	HWND		hwnd;
        '	HDC		hdc;
        '	BOOL		flag= TRUE, zero = FALSE;
        '   #ifndef FINAL
        '	    Get_Instrument_Parameters(&Inst);
        '   #End If
        '	Inst =  GetInstData();

        '	if(GetInstrument() != AA202 )
        '		AIR_OFF();

        '	hwnd= CreateWindowPeak(hpar, " ZERO ORDER ","SKCK1",0 );
        '   If (hwnd) Then
        '	{
        '		hdc= GetDC(hwnd);
        '		SetBkColor(hdc, RGB(192, 192, 192));
        '		SetText(hwnd, IDC_STATUS,"Initialising Please Wait  .......");
        '		Inst->Lamp_par.lamp[pos].lamp_optpos=1;//0;
        '		Inst->Lamp_par.wvzero = 100.0;
        '       If (Find_Wavelength_Home(hdc, 5, 150)) Then
        '		{
        '			ShowTurretElement(hwnd);
        '           If (Slit_Home()) Then
        '			{
        '				//All_Lamp_Off(); //--mdf by sk on 24/10/2001
        '				cur = Inst->Lamp_par.lamp[pos].cur;
        '				Set_HCL_Cur(cur,pos);
        '				flag=Test_Lamp_Presence(hwnd);
        '               If (flag) Then
        '				{
        '                   If (!zero) Then
        '					{
        '						InitGraphParam(hwnd);SetFocus(hwnd);
        '						zero = Zero_Order(hwnd, hdc);
        '                       If (!zero) Then
        '						{
        '							Gerror_message_new("ZERO-ORDER Peak not found", "ZERO ORDER");
        '							Beep();//pc_sound(1000,2);;pc_sound(1000,2); pc_sound(1000,2);
        '							flag=FALSE;
        '						}
        '					}//!zero
        '				}//if flag
        '			} //slit home
        '		} // find_mech_zero
        '		ReleaseDC(hwnd, hdc);
        '		DestroyWindowPeak(hwnd,hpar);

        '		if(GetInstrument() != AA202 )
        '			AIR_ON();
        '	}  // if oflag
        '}
        '--------------------------------------------------------------------------------------
        Dim intCounter As Integer
        Dim blnFlag As Boolean
        Dim blnZeroOrder As Boolean
        Dim intPos As Integer
        Dim dbllmp_current As Double
        Dim intlmp_position As Integer

        Try
            '---make air off is instrument type is not 201
            If Not (gstructSettings.AppMode = EnumAppMode.FullVersion_201) Then
                Call gobjCommProtocol.funcAir_OFF()
            End If

            If Not IsNothing(lblSt3Zero) Then
                lblSt3Zero.Text = Const_Initialize
                lblSt3Zero.Refresh()
            End If

            gobjInst.Lamp.LampParametersCollection.item(mintLampPosition).LampOptimizePosition = 1
            gobjInst.Lamp.WavelengthZero = 100.0

            '---find wavelength home 
            If gobjCommProtocol.funcFind_Wavelength_Home() Then
                '---set slit to home position
                If gobjCommProtocol.gFuncSlit_Home() Then
                    '--- Get current and slit position of lamp 

                    '---commented on 11.09.09
                    'dbllmp_current = gobjInst.Lamp.LampParametersCollection.item(mintLampPosition).Current
                    '---added on 11.09.09
                    dbllmp_current = gobjInst.Lamp.LampParametersCollection.item(mintLampPosition - 1).Current

                    gobjInst.Lamp_Position = mintLampPosition

                    '---set hcl current to turret
                    If Not gobjCommProtocol.funcSet_HCL_Cur(dbllmp_current, mintLampPosition) Then
                        Call gobjMessageAdapter.ShowMessage(constSetHCLCurError)
                        Call Application.DoEvents()
                    End If

                    If gobjInst.Current = 0.0 Then
                        gobjInst.Current = dbllmp_current
                    End If

                    '---test for lamp presence
                    blnFlag = gobjCommProtocol.funcTestLampPresence(lblSt1Zero, lblSt2Zero, lblSt3Zero)

                    If blnFlag Then
                        If Not blnZeroOrder Then
                            '---perform zero order
                            blnZeroOrder = funcZero_Order_201(lblSt1Zero, lblSt2Zero, lblSt3Zero, objGraphZero, objController)
                            If Not blnZeroOrder Then
                                Call gobjMessageAdapter.ShowMessage(constZeroOrderPeakNotFound)
                                Call Application.DoEvents()
                                blnFlag = False
                            End If '---Not blnZeroOrder 
                        End If '---blnZeroOrder 
                    End If '---blnflag
                End If '---slit home 
            End If '---wv zero

            '---set air on if instrument type is not 201
            If Not (gstructSettings.AppMode = EnumAppMode.FullVersion_201) Then
                Call gobjCommProtocol.funcAir_ON()
            End If

            Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)

            Call Application.DoEvents()

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

    Private Function funcZero_Order_201(Optional ByRef lblSt1Zero As Label = Nothing, _
                                        Optional ByRef lblSt2Zero As Label = Nothing, Optional ByRef lblSt3Zero As Label = Nothing, _
                                        Optional ByRef objGraphZero As AASGraph = Nothing, Optional ByVal objController As BgThread.IBgThread = Nothing) As Boolean
        '---------------------------------------------------------------------------
        'Procedure Name         :   funcZero_Order_201
        'Description            :   To set zero order
        'Parameters             :   lblSt1Zero,lblSt2Zero,lblSt3Zero,objGraphZero,objController
        'Time/Date              :   11-Apr-2007
        'Dependencies           :   Serial communication
        'Author                 :   Mangesh Shardul
        'Revision               :
        'Revision by Person     :   
        '---------------------------------------------------------------------------
        'BOOL	Zero_Order(HWND hwnd, HDC hdc)
        '{
        'int		chnew, chbase;
        'int		in_pos, i,max_int,  rpos;
        'BOOL		flag = FALSE;
        'char    	line1[80]="";
        'float stepspernm=50.0;

        'if (GetInstrument()==AA202)
        '   stepspernm = STEPS_PER_NM_AA202;
        'Else
        '   stepspernm = STEPS_PER_NM;

        ' Cal_Mode(HCLE);
        ' SetText(hwnd, IDC_STATUS, "ZERO-ORDER Peak Search");
        ' pc_delay (200);
        ' rpos = Search_Approc_wv_Peak(hwnd, WVZERORANGE, (double) 120.0);
        '#If !NEWZERO Then
        ' Adj_PMT_forvalue(hwnd, (double)4000.0, (double)350);
        '#Else
        ' Adj_PMT_forvalue(hwnd, (4000.0/5000.0 *100.0), 350);
        '#End If
        ' Show_Pmt(hwnd, Inst->Pmtv);
        ' PeakGraph.Ymin= GetEnergy(2047);
        ' PeakGraph.Ymax= GetEnergy(2047.0+409.6*5);
        ' max_int = 3000;   flag = FALSE;
        ' i=1;
        ' for (i=1; i<=rpos+stepspernm; i++)   {
        '		Rotate_Anticlock_Wv();     
        '	}
        ' for (i=1; i<=stepspernm; i++)  {
        '	Rotate_Clock_Wv();    
        '	}
        ' Inst->Wvcur = Get_Cur_Wv();
        ' strcpy(line1,""); sprintf(line1, "ZERO-ORDER  peak Search  Range ( %5.2fnm - %5.2fnm)",
        '		Inst->Wvcur,Inst->Wvcur+WVZERORANGE/(double)stepspernm);
        ' PeakGraph.Xmin= Inst->Wvcur;
        ' PeakGraph.Xmax= Inst->Wvcur+WVZERORANGE/(double) stepspernm;
        '  strcpy(PYaxis,"ENERGY"); strcpy(PXaxis,"Wv(nm)");
        ' Show_Peak_Param(hwnd, WVZERORANGE);

        ' SetText(hwnd, IDC_STATUS1,line1);
        ' in_pos = 1;
        ' max_int = 0;
        ' chbase = ReadADCFilter();
        ' for (i=1; i<=WVZERORANGE; i++) {
        '	Rotate_Clock_Wv();// pc_delay(100);
        '	chnew = ReadADCFilter();
        '	if (chnew > max_int)	 {
        '	  max_int = chnew;
        '	  in_pos =i;
        '	  if (max_int - chbase > 210) flag = TRUE;
        '	 }
        '	if (i==1)
        '	  GPlotInit(hdc, Inst->Wvcur+(double)i/(double) stepspernm, GetEnergy( chnew));
        '                                Else
        '	  GPlot(hdc, Inst->Wvcur+(double)i/(double) stepspernm, GetEnergy(chnew));
        '  }
        '  GShowPeak(hdc,Inst->Wvcur+(double)in_pos/(double) stepspernm,  GetEnergy(max_int),NULL);
        '  SetText(hwnd, IDC_STATUS1," Positioning to 0.00 nm Please Wait ..... ");
        '#If EMU Then
        ' Wait_For_Some_Msg(5);
        '#End If
        '  for (i=1; i <= WVZERORANGE+stepspernm; i++) {
        '	 Rotate_Anticlock_Wv();	 //  pc_delay(400);
        '	 }
        '  for (i=1; i <= in_pos+stepspernm; i++)   {
        '	 Rotate_Clock_Wv();	//	 pc_delay(400);
        '	}
        '  Inst->Wvcur = Get_Cur_Wv();
        '  Inst->Lamp_par.wvzero = Inst->Wvcur;
        '  Inst->Wvcur = (double) 0.0;
        '  Set_Cur_Wv();        

        '  Set_SlitWidth((double)0.3);
        '  pc_delay(200);
        ' return(flag);
        '}
        '---------------------------------------------------------------------------
        Dim rPOs As Integer
        Dim intCounter As Integer
        Dim chNew, chBase As Integer
        Dim max_int As Integer
        Dim in_pos As Integer
        Dim blnFlag As Boolean = False
        Dim dblStepsPerNM As Double = 50.0
        Dim dblXval, dblYval As Double
        Dim strValue As String = ""
        Try
            '--- set steps per nm for 201
            dblStepsPerNM = CONST_STEPS_PER_NM_AA201

            '---set calibration mode as HCLE
            If gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.HCLE) = False Then
                gobjMessageAdapter.ShowMessage(constCalibrationMode)
                Application.DoEvents()
            End If

            If Not IsNothing(lblSt3Zero) Then
                lblSt3Zero.Text = "ZERO-ORDER Peak Search"
                lblSt3Zero.Refresh()
            End If

            '---search for approximate wavelength peak
            '---where WVZERORANGE=300
            rPOs = gobjCommProtocol.funcSearch_Approc_WV_Peak(WVZERORANGE, 120.0, lblSt1Zero, lblSt2Zero, lblSt3Zero)

            '---adjust pmt between 80-350
            Call gobjCommProtocol.funcAdj_Pmt_ForValue(80, 350, True)

            If Not IsNothing(lblSt1Zero) Then
                lblSt1Zero.Text = "PMT : -" & Format(gobjInst.PmtVoltage, "000")
            End If

            '---set graph properties
            objGraphZero.YAxisMin = gFuncGetEnergy(2047)
            objGraphZero.YAxisMax = gFuncGetEnergy(2047.0 + 409.6 * 5)
            objGraphZero.Refresh()
            Application.DoEvents()

            max_int = 3000
            blnFlag = False
            intCounter = 1

            '---rotate wavelength drive anticlockwise
            '---approximate wavelength peak + 25 times.
            For intCounter = 1 To rPOs + CONST_STEPS_PER_NM_AA201
                Call gobjCommProtocol.funcRotate_Anticlock_Wv()
            Next

            '---rotate wavelength drive clockwise
            '---25 times.
            For intCounter = 1 To CONST_STEPS_PER_NM_AA201
                Call gobjCommProtocol.funcRotate_Clock_Wv()
            Next

            '---get current wavelength
            If gobjCommProtocol.funcGet_Current_Wv(gobjInst.WavelengthCur) = False Then
                Call gobjMessageAdapter.ShowMessage(constGetCurWvError)
                Call Application.DoEvents()
            End If

            '--- Set zero order peak search range
            If Not IsNothing(lblSt2Zero) Then
                lblSt2Zero.Text = "ZERO-ORDER  Peak Search  Range ( " & gobjInst.WavelengthCur & "nm - " & FormatNumber(gobjInst.WavelengthCur + WVZERORANGE / CONST_STEPS_PER_NM_AA201, 2) & "nm)"
                lblSt2Zero.Refresh()
            End If

            '--- Set graph properties
            objGraphZero.XAxisMin = CInt(gobjInst.WavelengthCur)
            objGraphZero.XAxisMax = CInt(gobjInst.WavelengthCur + WVZERORANGE / CONST_STEPS_PER_NM_AA201)
            objGraphZero.YAxisLabel = "ENERGY"
            objGraphZero.XAxisLabel = "WAVELENGTH (nm)"
            objGraphZero.Refresh()

            in_pos = 1
            max_int = 0

            '---read ADC filter
            Call gobjCommProtocol.funcReadADCFilter(gobjInst.Average, chBase)

            '---iterate 300 times 
            '---where WVZERORANGE=300
            For intCounter = 1 To WVZERORANGE
                strValue = ""
                '---rotate wavelength clockwise
                Call gobjCommProtocol.funcRotate_Clock_Wv()
                '---read ADC filter.
                Call gobjCommProtocol.funcReadADCFilter(gobjInst.Average, chNew)
                If chNew > max_int Then
                    '---memorize highest ADC filter reading and its position
                    max_int = chNew
                    in_pos = intCounter
                    If max_int - chBase > 210 Then
                        blnFlag = True
                    End If
                End If
                dblXval = FormatNumber(gobjInst.WavelengthCur + intCounter / CONST_STEPS_PER_NM_AA201, 4)
                dblYval = gFuncGetEnergy(chNew)
                strValue = dblXval & "," & dblYval
                If Not objController Is Nothing Then
                    '---send x,y axis data to plot graph 
                    Call objController.Display(strValue)
                End If
            Next

            If Not IsNothing(lblSt2Zero) Then
                lblSt2Zero.Text = "Positioning to 0.00 nm Please Wait ..... "
                lblSt2Zero.Refresh()
            End If

            '---rotate wavelength drive anticlockwise 300 +25 times
            For intCounter = 1 To WVZERORANGE + CONST_STEPS_PER_NM_AA201
                Call gobjCommProtocol.funcRotate_Anticlock_Wv()
            Next

            '---rotate wavelength drive clockwise  highest ADC filter reading counter +25 times
            For intCounter = 1 To in_pos + CONST_STEPS_PER_NM_AA201
                Call gobjCommProtocol.funcRotate_Clock_Wv()
            Next

            '---get current wavelength
            If gobjCommProtocol.funcGet_Current_Wv(gobjInst.WavelengthCur) = False Then
                Call gobjMessageAdapter.ShowMessage(constSetCurWvError)
                Call Application.DoEvents()
            End If

            gobjInst.Lamp.WavelengthZero = gobjInst.WavelengthCur
            gobjInst.WavelengthCur = 0.0

            '---set current wavelength
            Call gobjCommProtocol.funcSet_Current_Wv(gobjInst.WavelengthCur)

            '---set slit width as 0.3
            Call gobjCommProtocol.funcSet_SlitWidth(0.3)

            Return blnFlag

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
