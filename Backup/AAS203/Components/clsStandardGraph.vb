Imports AAS203.Common
Imports AAS203Library
Imports AAS203Library.Method
Imports AAS203Library.Method.clsQuantitativeData
'this are like header file.

Public Class clsStandardGraph
    '**********************************************************************
    ' File Header       
    ' File Name 		:   clsStandardGraph.vb
    ' Author			:   Mangesh Shardul
    ' Date/Time			:   18-Jan-2007 10:30 am
    ' Description		:   Class to draw the AAS Sample or Standard Working graph
    ' Assumptions       :	gobjNewMethod object should filled fullyand properly
    ' Dependencies      :   (gobjNewMethod.) A global object of AAS203Library.Method.clsMethod
    '                       in this AAS203 Project.
    '**********************************************************************

#Region " Private Class Member Variables "

    '#If STD_ADDN Then
    'BOOL stdaddn = FALSE;
    '#End If
    'int		N=1, No=3;
    'BOOL		rational=FALSE;
    'int		CalcUsedTotStd = 0;
    'Private stdaddn As Boolean
    'BOOL SampCurve = FALSE;
    'double	err[FIFTH_ORDER+1]={1000.0, 1000.0, 1000.0,1000.0, 1000.0, 1000.0};
    'typedef	double	DOUBLE[MAX][MAX];
    'Public [DOUBLE](,) As Double

    Private CalcUsedTotStd As Integer
    Private SampCurve As Boolean

    Private X(MAX - 1) As Double
    Private Y(MAX - 1) As Double

    Private MatX(,) As Double
    Private MatY(MAX - 1) As Double

    Private mintRunNumberIndex As Integer
    Private No As Integer = 3
    Private AbsMax As Double = -1.0

    Private mobjClsMethod As New clsMethod

#End Region

#Region " Public Class Member Variables "
    
    Public mblnIsStandardAddition As Boolean
    Public Rational As Boolean
    Public N As Integer = 1
    Public MatA(MAX - 1) As Double
    Public Curve_Status As Boolean = False
    'Public err() As Double = {1000.0, 1000.0, 1000.0, 1000.0, 1000.0, 1000.0}
    Public err() As Double = {0.0, 0.0, 0.0, 0.0, 0.0, 0.0}             'By pankaj on 25 Aug 07
    Public mblnSaturation As Boolean = False
#End Region

#Region " Public Constants, Enums, Structures .. "

    '#define	MAXSTD		15
    '#define	MAXSAMP		200
    '#define	MAXREPEAT	15
    '#define	MAXACC		8
    '#define	MAX		MAXSTD+1
    '#define	ZERO_PASSING	TRUE 

    Public Const MAXSTD As Integer = 15
    Public Const MAXSAMP As Integer = 200
    Public Const MAXREPEAT As Integer = 15
    Public Const MAXACC As Integer = 8
    Public Const MAX As Integer = MAXSTD + 1
    Public Const ZERO_PASSING As Boolean = True

#End Region

#Region " Constructors "

    Public Sub New()
        '=====================================================================
        ' Procedure Name        : New [Constructor]
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

#Region " Public Functions "

    Public Function Create_Standard_Sample_Curve(ByVal blnIsSampleIn As Boolean, ByVal blnIsAnalysisModeIn As Boolean, _
                                                 ByVal intSelectedMethodID As Integer, ByVal intSelectedRunNumber As Integer, ByRef objNewMethod As clsMethod) As Boolean
        '=====================================================================
        ' Procedure Name        : Create_Standard_Sample_Curve
        ' Parameters Passed     : Flag to draw Standard or Sample Graph
        ' Returns               : True or false
        ' Purpose               : To show the Standard or Sample Graph
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================

        '*************************************************
        '--- ORIGINAL CODE
        '*************************************************
        'BOOL Create_Standard_Sample_Curve(HWND hpar, BOOL sampflag)
        '{
        '	DLGPROC  skp1;
        '	int		n1;
        '	int		lmode;
        '	BOOL		flag=FALSE;
        '	int		nstds;

        '	if (Method->QuantData==NULL)
        '		return FALSE;

        '#If STD_ADDN Then
        '		SetStdAddnFlag(Method->QuantData->Param.Std_Addn);
        '#End If

        '	if(!CheckValidStdAbsEntry(Method->QuantData->StdTopData))
        '	{
        '		Gerror_message_new("Abs of the standards are not in increasing order", "Std Error");
        '		return flag;
        '	}

        '	if ((GetTotStds(Method->QuantData->StdTopData, TRUE))>0)
        '	{
        '		n1 = GetTotStdAnalysed(Method->QuantData->StdTopData);

        '		if ( Method->QuantData->cMode < DIRECT ||  n1 != CalcUsedTotStd )
        '			Method->QuantData->cMode = GetBestFit();

        '		lmode=Method->QuantData->cMode;

        '		nstds = GetNoValidStdConcAbs(Method->QuantData->StdTopData);

        '		skp1 =(DLGPROC) MakeProcInstance((DLGPROC) CurveProc,hInst);

        '#If STD_ADDN Then
        '			if(Method->QuantData->Param.Std_Addn)
        '				SampCurve=FALSE;
        '			else
        '				SampCurve=sampflag;
        '#Else
        '			SampCurve=sampflag;
        '#End If

        '		DialogBox(hInst,"CURVE", hpar, skp1);
        '		FreeProcInstance(skp1);

        '		if (lmode!=Method->QuantData->cMode || nstds != GetNoValidStdConcAbs(Method->QuantData->StdTopData))
        '			flag=TRUE;

        '	}
        '   Else
        '		Gerror_message_new("No Standards", "STANDARD CURVE");

        '	return flag;
        '}
        '*************************************************
        Dim objfrmStandardSampleGraph As frmStandardGraph
        Dim n1 As Integer
        Dim lmode As Integer
        Dim flag As Boolean
        Dim nstds As Integer

        Try
            ' Check process is under analysis to hold the method object.
            If blnIsAnalysisModeIn Then
                mobjClsMethod = gobjNewMethod
            Else
                mobjClsMethod = objNewMethod.Clone
            End If

            ' seek  the Run No.
            If blnIsAnalysisModeIn Then
                If IsNothing(mobjClsMethod) Then
                    Return False
                End If
                '---For Analysis Mode
                If mobjClsMethod.QuantitativeDataCollection.Count > 0 Then
                    mintRunNumberIndex = mobjClsMethod.QuantitativeDataCollection.Count - 1
                Else
                    mintRunNumberIndex = 0
                End If
            Else
                '---For Data Files Mode
                mintRunNumberIndex = gfuncGetSelectedMethodRunNumberIndex(intSelectedMethodID, intSelectedRunNumber)
            End If

            'Set  Standard Addition flag to this object
            If mobjClsMethod.StandardAddition Then
                Call SetStdAddnFlag(mobjClsMethod.StandardAddition)
            End If
            ' Check the standard Abs entnty into increasing order and validate it else return it
            If Not CheckValidStdAbsEntry(mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection) Then
                'MessageBox.Show("Abs of the standards are not in increasing order", "Std Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return flag
            End If
            ' Get the total no of standards
            If GetTotStds(mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection, True) > 0 Then
                ' Get the total no of standards which is analysised
                n1 = GetTotStdAnalysed(mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection)

                'if ( Method->QuantData->cMode < DIRECT ||  n1 != CalcUsedTotStd )
                '   Method->QuantData->cMode = GetBestFit()
                'end if
                'lmode=Method->QuantData->cMode


                'If blnIsAnalysisModeIn Then
                ' Set the best fitted calculation mode
                If (mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).CalculationMode < enumCalculationMode.DIRECT Or n1 <> CalcUsedTotStd) Then
                    mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).CalculationMode = GetBestFit(False)
                End If
                'End If
                If blnIsAnalysisModeIn = False Then   '29.04.08
                    If gintCalcMode <> 100 Then
                        mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).CalculationMode = gintCalcMode
                    End If
                End If



                lmode = mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).CalculationMode
                ' get no of valid std. conc. and Abs.
                nstds = GetNoValidStdConcAbs(mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection)
                'skp1 =(DLGPROC) MakeProcInstance((DLGPROC) CurveProc,hInst)

                '#if STD_ADDN
                If (mobjClsMethod.StandardAddition) Then
                    SampCurve = False
                Else
                    SampCurve = blnIsSampleIn
                End If
                '#else
                '   SampCurve = sampflag
                '#End If

                'DialogBox(hInst,"CURVE", hpar, skp1)
                'FreeProcInstance(skp1)
                ' Set the Std/Samp Graph  form.
                objfrmStandardSampleGraph = New frmStandardGraph(blnIsSampleIn, blnIsAnalysisModeIn, mobjClsMethod, intSelectedRunNumber)
                objfrmStandardSampleGraph.ShowDialog()
                Application.DoEvents()

                Dim intMethodCounter As Integer
                For intMethodCounter = gobjMethodCollection.Count - 1 To 0 Step -1
                    If intSelectedMethodID = gobjMethodCollection.item(intMethodCounter).MethodID Then
                        gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection(mintRunNumberIndex).CalculationMode = objfrmStandardSampleGraph.mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).CalculationMode
                        If blnIsAnalysisModeIn Then
                            gobjNewMethod.QuantitativeDataCollection(mintRunNumberIndex).CalculationMode = objfrmStandardSampleGraph.mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).CalculationMode
                        Else
                            objNewMethod.QuantitativeDataCollection(mintRunNumberIndex).CalculationMode = objfrmStandardSampleGraph.mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).CalculationMode
                            gintCalcMode = objfrmStandardSampleGraph.mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).CalculationMode  '29.04.08
                        End If
                        Exit For
                    End If
                Next
                objfrmStandardSampleGraph.Close()
                objfrmStandardSampleGraph.Dispose()
                objfrmStandardSampleGraph = Nothing
                '//----- Added by Sachin Dokhale


                '//-----
                'if (lmode!=Method->QuantData->cMode || nstds != GetNoValidStdConcAbs(Method->QuantData->StdTopData))
                '   flag=TRUE
                'end if
            Else
                Call gobjMessageAdapter.ShowMessage(constNoStandards)
                Application.DoEvents()
            End If

            Return flag

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

    Public Function GetNoValidStdConcAbs(ByVal objStandardData As Method.clsAnalysisStdParametersCollection) As Integer
        '=====================================================================
        ' Procedure Name        : GetNoValidStdConcAbs
        ' Parameters Passed     : Standard Data Collection 
        ' Returns               : No. of Valid Total Standards
        ' Purpose               : Return Valid standards
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================

        '********************************************************************
        '--- ORIGINAL CODE
        '********************************************************************
        'int S4FUNC	GetNoValidStdConcAbs(STDDATA   *StdTop)
        '{
        '	STDDATA   *tempk=NULL;
        '	int		 tot=0;

        '	tempk =StdTop;
        '   While (tempk! = NULL)
        '	{
        '		if (tempk->Data.Used)
        '			tot++;
        '		tempk=tempk->next;
        '	}
        '	return tot;
        '}
        '********************************************************************
        Dim intTotalStandards As Integer
        Dim intCounter As Integer

        Try
            ' Return total no of valid standards 
            For intCounter = 0 To objStandardData.Count - 1
                If objStandardData.item(intCounter).Used Then
                    intTotalStandards += 1
                End If
            Next intCounter

            Return intTotalStandards

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

    Public Function Get_Conc(ByVal y1 As Double, ByVal xinitial As Double) As Double
        '=====================================================================
        ' Procedure Name        : Get_Conc
        ' Parameters Passed     : Y-Value as double, Initial X-Value
        ' Returns               : Conc. Value in Double
        ' Purpose               : Return Conc. value
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 03-Feb-2007 02:25 pm
        ' Revisions             : 1
        '=====================================================================

        '*****************************************************
        '---- ORIGINAL CODE
        '*****************************************************
        'E4FUNC  double	S4FUNC  Get_Conc(double y1, double xinitial) //, int acc)
        '{
        '	//char	str[80]="";
        '	double x1=0.0;
        '        If (!Curve_Status) Then
        '		return -1.0;
        '	if (N==0)
        '		x1=Calc_ConcDirect(y1);
        '            ElseIf (rational) Then
        '		x1=GetConcRational(y1);
        '            Else
        '		x1= Regula_falsei(y1, xinitial, X[No-1]);//xmax);
        '		//x1 = GetResultAccurate(x1, acc);
        '	/*--------------------------
        '	//following condition removed by sss on dt 27.12.2K for storing the actual conc of the sample if sample goes out off scale
        '                If (y1 > AbsMax + AbsMax * 0.05) Then
        '		x1=(double) 0.0;
        '	----------------------------	*/
        '	if (x1<(double) 0)
        '		x1=(double) 0.0;
        '	return x1;
        '}
        '*****************************************************
        Dim x1 As Double

        Try
            ' Return the concentration value into the respect of X value(Abs).
            If Not (Curve_Status) Then
                Return -1.0
            End If

            '---changed by Deepak on 19.10.10 to solve a bug (different conc for same abs reported by vck)
            y1 = FormatNumber(y1, 3)
            '-----------------------

            If (N = 0) Then
                x1 = Calc_ConcDirect(y1)
            ElseIf (Rational) Then
                x1 = GetConcRational(y1)
            Else
                x1 = Regula_falsei(y1, xinitial, X(No - 1))
            End If

            If (x1 < 0) Then
                x1 = 0.0
            End If

            Return x1

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

    Public Sub Calculate_Std_Curve()
        '=====================================================================
        ' Procedure Name        : Calculate_Std_Curve
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : Calculate Standard Curve
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 18-Jan-2007 03:45 pm
        ' Revisions             : 1
        '=====================================================================

        '************************************************************
        '---- ORIGINAL CODE
        '************************************************************
        'void(Calculate_Std_Curve(void))
        '{
        '	double 	*abs=NULL;
        '	double 	*conc=NULL;
        '	int		i;
        '	STDDATA	*tempk;

        '	CalcUsedTotStd = GetTotStds(Method->QuantData->StdTopData, TRUE);
        '	abs = (double *) malloc(sizeof(double) *(CalcUsedTotStd+1));

        '	if (abs==NULL)
        '		return;
        '	conc= (double *) malloc(sizeof(double) *(CalcUsedTotStd+1));

        '	if (conc==NULL)
        '	{
        '		free(abs); abs=NULL; return;
        '	}
        '	i=0;
        '	tempk = Method->QuantData->StdTopData;

        '                While (tempk)
        '	{
        '                    If (i < CalcUsedTotStd) Then
        '		{
        '			if (tempk->Data.Used)
        '			{
        '				abs[i]=tempk->Data.Abs;
        '				conc[i]=tempk->Data.Conc;
        '				i++;
        '			}
        '		}
        '		tempk=tempk->next;
        '	}

        '#If STD_ADDN Then
        '		if(Method->QuantData->Param.Std_Addn)
        '			Calculate_Curve(abs, conc,CalcUsedTotStd, Method->QuantData->cMode, !ZERO_PASSING);
        '		else
        '			Calculate_Curve(abs, conc,CalcUsedTotStd, Method->QuantData->cMode, ZERO_PASSING);
        '#Else
        '		Calculate_Curve(abs, conc,CalcUsedTotStd, Method->QuantData->cMode, ZERO_PASSING);
        '#End If

        '	free(abs);
        '	abs=NULL;
        '	free(conc);
        '	conc=NULL;
        '	CalcSampValues();
        '}
        '************************************************************
        'double 	*abs=NULL;
        'double 	*conc=NULL;
        'int		i;
        'STDDATA	*tempk;
        Dim abs() As Double
        Dim conc() As Double
        Dim i As Integer

        Try
            'get total std. from std. collection object
            CalcUsedTotStd = GetTotStds(mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection, True)
            'abs = (double *) malloc(sizeof(double) *(CalcUsedTotStd+1));
            ReDim abs(CalcUsedTotStd + 1)
            REM ReDim abs(CalcUsedTotStd) 'By Sachin on 18.09.07

            If IsNothing(abs) Then Return

            'conc= (double *) malloc(sizeof(double) *(CalcUsedTotStd+1));
            ReDim conc(CalcUsedTotStd + 1)
            REM ReDim conc(CalcUsedTotStd) 'By Sachin on 18.09.07

            If IsNothing(conc) Then
                abs = Nothing
                Return
            End If
            i = 0
            Dim j As Integer = 0
            '   Fill the array for Abs and Conc.
            For i = 0 To mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count - 1
                If j < CalcUsedTotStd Then
                    If mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(i).Used Then
                        abs(j) = mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(i).Abs
                        conc(j) = mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(i).Concentration
                        j += 1
                    End If
                End If
            Next

            '#If STD_ADDN Then
            '   if(Method->QuantData->Param.Std_Addn)
            '	    Calculate_Curve(abs, conc,CalcUsedTotStd, Method->QuantData->cMode, !ZERO_PASSING);
            '	else
            '	    Calculate_Curve(abs, conc,CalcUsedTotStd, Method->QuantData->cMode, ZERO_PASSING);
            '#Else
            '	    Calculate_Curve(abs, conc,CalcUsedTotStd, Method->QuantData->cMode, ZERO_PASSING);
            '#End If
            ' Calculate curve for given calculation mode on standards
            If mobjClsMethod.StandardAddition Then
                Call Calculate_Curve(abs, conc, CalcUsedTotStd, mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).CalculationMode, (Not ZERO_PASSING))
            Else
                Call Calculate_Curve(abs, conc, CalcUsedTotStd, mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).CalculationMode, (ZERO_PASSING))
            End If
            ' Calculate the sample value on measured curve 
            Call CalcSampValues(mobjClsMethod.StandardAddition)

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

    Public Sub CalcSampValues(ByVal blnIsSTD_ADDN As Boolean)
        '=====================================================================
        ' Procedure Name        : CalcSampValues
        ' Parameters Passed     : Standard Addition Flag
        ' Returns               : None
        ' Purpose               : Calculate Sample values
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 18-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================

        '**********************************************************
        '---- ORIGINAL CODE
        '**********************************************************
        '#If STD_ADDN Then
        'extern SAMPDATA	*CurSamp;

        'void	CalcSampValues(void)
        '{
        '	SAMPDATA	*tempk1;
        '	tempk1 = Method->QuantData->SampTopData;
        '	if( Method->QuantData->Param.Std_Addn)
        '	{
        '		if(tempk1)
        '		{
        '			tempk1->Data.Conc = GetRawStdAddnConc();
        '			tempk1->Data.Abs = 0.0;
        '			tempk1->Data.Used = TRUE;
        '			tempk1=tempk1->next;
        '			CurSamp = NULL;
        '		}
        '		while(tempk1)
        '		{
        '			tempk1->Data.Conc=Get_Conc(tempk1->Data.Abs, 0.0);
        '			tempk1=tempk1->next;
        '		}
        '	}
        '	else
        '	{
        '		while(tempk1)
        '		{
        '			tempk1->Data.Conc=Get_Conc(tempk1->Data.Abs, 0.0);
        '			/*		if (tempk1->Data.Conc>0 &&tempk1->Data.Abs>-0.1)
        '			tempk1->Data.Used=TRUE;*/
        '			tempk1=tempk1->next;
        '		}
        '	}
        '}
        '#Else

        'void(CalcSampValues(void))
        '{
        '	SAMPDATA	*tempk1;
        '	tempk1 = Method->QuantData->SampTopData;
        '        While (tempk1)
        '	{
        '		tempk1->Data.Conc=Get_Conc(tempk1->Data.Abs, 0.0);
        '		/*	if (tempk1->Data.Conc>0 &&tempk1->Data.Abs>-0.1)
        '			tempk1->Data.Used=TRUE;*/
        '		tempk1=tempk1->next;
        '	}
        '}
        '#End If

        '**********************************************************
        Dim intCounter As Integer

        Try
            'Calculate the sample value on standard value
            'Check for Stanard Addition flag
            If blnIsSTD_ADDN Then
                If (mobjClsMethod.StandardAddition) Then
                    If mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count > 0 Then
                        If Not IsNothing(mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(0)) Then
                            mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(0).Conc = GetRawStdAddnConc(mobjClsMethod.StandardAddition)
                            mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(0).Abs = 0.0
                            mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(0).Used = True
                        End If
                    End If
                    ' Get Conc. value
                    For intCounter = 1 To mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count - 1
                        mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Conc = Get_Conc(mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Abs, 0.0)
                    Next intCounter
                Else
                    ' Get Conc. value
                    For intCounter = 0 To mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count - 1
                        mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Conc = Get_Conc(mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Abs, 0.0)
                    Next intCounter
                End If
            Else
                ' Get Conc. value
                For intCounter = 0 To mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count - 1
                    mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Conc = Get_Conc(mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Abs, 0.0)
                Next intCounter
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

    Public Function IsStdCurve() As Boolean
        '=====================================================================
        ' Procedure Name        : IsStdCurve
        ' Parameters Passed     : None
        ' Returns               : Return Curve status 
        ' Purpose               : Return Curve status
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 31-Jan-2007 04:50 pm
        ' Revisions             : 1
        '=====================================================================

        '*****************************************************
        '---- ORIGINAL CODE
        '*****************************************************
        'E4FUNC  BOOL	S4FUNC  IsStdCurve(void)
        '{
        '   return Curve_Status;
        '}
        '*****************************************************
        Try
            'return Curve status of selected curve (it is Standard Addition/not)
            Return Curve_Status

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

    Public Function Get_Abs(ByVal x As Double) As Double
        '=====================================================================
        ' Procedure Name        : Get_Abs
        ' Parameters Passed     : x
        ' Returns               : Return Abs value
        ' Purpose               : Return Abs value
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 03-Feb-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================

        '******************************************
        '---- ORIGINAL CODE
        '******************************************
        '#if STD_ADDN  
        'E4FUNC  double	S4FUNC  Get_Abs(double x)
        '{
        '	double y=0.0;
        '	int 	i;
        '   If (!Curve_Status) Then
        '	    return -1.0;
        '   If (x > 1.0) Then
        '	    i=0;
        '	if (N==0)
        '	{
        '		y=Calc_AbsDirect(x);
        '	}
        '   Else
        '	{
        '       If (rational) Then
        '		    y = Calculte_Rat(x);
        '       Else
        '		{
        '			if (x==(double)0.0 & !stdaddn)
        '				y= MatA[0];
        '           Else
        '				for(i=0; i<N; i++)
        '				{
        '					if( i == 0 )
        '						y+=(MatA[i]* 1.0);
        '                   Else
        '						y+=(MatA[i]* pow(x,i));
        '				}
        '		}
        '	}
        '	return y;
        '}
        '#else
        'E4FUNC  double	S4FUNC  Get_Abs(double x)
        '{
        '	double y=0.0;
        '	int 	i;

        '        If (!Curve_Status) Then
        '		return -1.0;

        '            If (x > 1.0) Then
        '		i=0;

        '	if (N==0)
        '	{
        '		y=Calc_AbsDirect(x);
        '	}
        '                Else
        '	{
        '                    If (rational) Then
        '			y = Calculte_Rat(x);
        '                    Else
        '		{
        '			if (x==(double)0.0)
        '				y= MatA[0];
        '                        Else
        '				for(i=0; i<N; i++)
        '					y+=(MatA[i]* pow(x,i));
        '		}
        '	}
        '	return y;
        '}
        '#end If
        '******************************************
        Try
            ' Get the abs value
            If mblnIsStandardAddition Then
                Dim dbly As Double
                Dim i As Integer

                If Not (Curve_Status) Then
                    Return -1.0
                End If

                If (x > 1.0) Then
                    i = 0
                End If

                If (N = 0) Then
                    dbly = Calc_AbsDirect(x)
                Else
                    If (Rational) Then
                        dbly = Calculte_Rat(x)
                    Else

                        If (x = 0.0 And Not mblnIsStandardAddition) Then
                            dbly = MatA(0)
                        Else
                            For i = 0 To N - 1
                                If (i = 0) Then
                                    dbly += (MatA(i) * 1.0)
                                Else
                                    dbly += (MatA(i) * Math.Pow(x, i))
                                End If
                            Next
                        End If

                    End If
                End If

                Return dbly

            Else
                '----
                Dim dbly As Double
                Dim i As Integer

                If Not (Curve_Status) Then
                    Return -1.0
                End If

                If (x > 1.0) Then
                    i = 0
                End If

                If (N = 0) Then
                    dbly = Calc_AbsDirect(x)
                Else
                    If (Rational) Then
                        dbly = Calculte_Rat(x)
                    Else
                        If (x = 0.0) Then
                            dbly = MatA(0)
                        Else
                            For i = 0 To N - 1
                                dbly += (MatA(i) * Math.Pow(x, i))
                            Next
                        End If
                    End If
                End If

                Return dbly
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
    End Function

    Public Function GetInterval(ByVal Max As Double, ByVal Min As Double, _
                             ByVal TotData As Integer, ByVal flag As Boolean) As Double
        '=====================================================================
        ' Procedure Name        : GetInterval
        ' Parameters Passed     : Max,Min,TotData, flag
        ' Returns               : Return Intervals
        ' Purpose               : Return Interval
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 31-Jan-2007 05:00 pm
        ' Revisions             : 1
        '=====================================================================

        '************************************************************
        '----- ORIGINAL CODE
        '************************************************************
        'E4FUNC  double		S4FUNC GetInterval(double Max, double Min, int TotData, BOOL flag)
        '{
        '	double  x1;
        '	int i;

        '	for (i=1; i<=4; i++)
        '	{
        '		x1= GetInterval_val(Max, Min, i, TotData, flag);
        '		if (x1 != (double) -1.0)
        '			break;
        '	}

        '	if (x1 == (double) -1.0)
        '		x1 = ((Max - Min)/(double)10.0);

        '	return x1;
        '}
        '************************************************************
        Dim x1 As Double
        Dim i As Integer

        Try
            'Get the interval
            For i = 1 To 4
                x1 = GetInterval_val(Max, Min, i, TotData, flag)
                If (x1 <> -1.0) Then
                    Exit For
                End If
            Next

            If (x1 = -1.0) Then
                x1 = (Max - Min) / 10.0
            End If

            Return x1

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

    Public Sub subSaveAbsConcValue(ByVal objClsMethod As clsMethod, ByVal intRunNumberIndex As Integer)
        '=====================================================================
        ' Procedure Name        : subSaveAbsConcValue
        ' Parameters Passed     : Current Method object and Run Number 
        ' Returns               : None
        ' Purpose               : Save the Abs and Concentration into the collection object
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 11-May-2007 04:35 pm
        ' Revisions             : 1
        '=====================================================================
        Dim n1 As Integer

        Try
            ' Save the Abs and Concentration into the collection object
            If GetTotStds(objClsMethod.QuantitativeDataCollection.Item(intRunNumberIndex).StandardDataCollection, True) > 0 Then
                n1 = GetTotStdAnalysed(objClsMethod.QuantitativeDataCollection.Item(intRunNumberIndex).StandardDataCollection)

                If (objClsMethod.QuantitativeDataCollection.Item(intRunNumberIndex).CalculationMode < enumCalculationMode.DIRECT Or n1 <> CalcUsedTotStd) Then
                    objClsMethod.QuantitativeDataCollection.Item(intRunNumberIndex).CalculationMode = GetBestFit(True)
                End If
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

#End Region

#Region " Public Shared Functions "

    Public Shared Function GetTotStds(ByVal objStandardData As Method.clsAnalysisStdParametersCollection, ByVal blnIsCheckUsed As Boolean) As Integer
        '=====================================================================
        ' Procedure Name        : GetTotStds
        ' Parameters Passed     : Standard Data Collection, boolean flag
        ' Returns               : No. of Valid Total Standards
        ' Purpose               : getting a total num of std.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================

        '********************************************************************
        '--- ORIGINAL CODE
        '********************************************************************
        'int		S4FUNC	GetTotStds(STDDATA   *StdTop, BOOL flag)
        '{
        'STDDATA   *tempk=NULL;
        'int		 tot=0;
        ' tempk =StdTop;
        ' while(tempk!=NULL){
        '	 if (flag){
        '		if (tempk->Data.Used)
        '		 tot++;
        '	  }
        '                Else
        '	  tot++;
        '	 tempk=tempk->next;
        '  }
        ' return tot;
        '}
        '********************************************************************
        Dim intTotalStandards As Integer
        Dim intCounter As Integer

        Try
            For intCounter = 0 To objStandardData.Count - 1
                If blnIsCheckUsed Then
                    If objStandardData.item(intCounter).Used Then
                        ''data structure for std.
                        intTotalStandards += 1
                    End If
                Else
                    intTotalStandards += 1
                End If
            Next intCounter

            Return intTotalStandards

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

    Public Shared Function GetTotStdAnalysed(ByVal objStandardData As Method.clsAnalysisStdParametersCollection) As Integer
        '=====================================================================
        ' Procedure Name        : GetTotStdAnalysed
        ' Parameters Passed     : Standard Data Collection
        ' Returns               : No. of Analysed Total Standards
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================

        '********************************************************************
        '--- ORIGINAL CODE
        '********************************************************************
        'int		S4FUNC	GetTotStdAnalysed(STDDATA   *StdTop)
        '{
        'STDDATA   *tempk=NULL;
        'int		 tot=0;

        ' tempk =StdTop;
        ' while(tempk!=NULL){
        '	 if (tempk->Data.Abs>=-0.2)
        '	   tot++;
        '	 tempk=tempk->next;
        ' }
        ' return tot;
        '}
        '********************************************************************
        Dim intTotalStandards As Integer
        Dim intCounter As Integer

        Try
            For intCounter = 0 To objStandardData.Count - 1
                If (objStandardData.item(intCounter).Abs >= -0.2) Then
                    intTotalStandards += 1
                End If
            Next intCounter

            Return intTotalStandards

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

    Public Shared Function FindSamplesAnalysed(ByVal objClsMethod As clsMethod, ByVal intSelectedRunNumberIndex As Integer) As Integer
        '=====================================================================
        ' Procedure Name        : FindSamplesAnalysed
        ' Parameters Passed     : clsMethod, intSelectedRunNumberIndex
        ' Returns               : Integer
        ' Purpose               : Total No sample
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 09-Mar-2007 07:55 pm
        ' Revisions             : 1
        '=====================================================================

        '**************************************************************
        '----ORIGINAL CODE
        '**************************************************************
        'int FindSamplesAnalysed(void)
        '{
        '	int	  samples=0;
        '	STDDATA 		*curstd=NULL;
        '	SAMPDATA 	*cursamp=NULL;

        '	curstd  =	Method->QuantData->StdTopData;
        '	cursamp = Method->QuantData->SampTopData;

        '   If (CurStd! = NULL) Then
        '	{
        '       While (curstd)
        '		{
        '			if (curstd==CurStd)
        '				break;
        '			if (curstd->Data.Used)
        '				samples++;
        '			curstd=curstd->next;
        '		}
        '	}
        '   Else
        '		samples = GetTotStdAnalysed(curstd);
        '	if(Method->QuantData->Param.Std_Addn)
        '	{
        '       If (cursamp) Then
        '		{
        '           If (cursamp! = CurSamp) Then
        '			{
        '				if (cursamp->Data.Used)
        '					samples++;
        '			}
        '		}
        '	}
        '   Else
        '	{
        '       While (cursamp)
        '		{
        '			if (cursamp==CurSamp)
        '				break;
        '			if (cursamp->Data.Used)
        '				samples++;
        '			cursamp=cursamp->next;
        '		}
        '	}
        '	return samples;
        '}
        '**************************************************************
        Dim samples As Integer = 0
        Dim curstd As AAS203Library.Method.clsAnalysisStdParametersCollection
        Dim cursamp As AAS203Library.Method.clsAnalysisSampleParametersCollection
        Dim intCounter As Integer

        Try
            ' Validate the total no Samples from given Sample collection
            curstd = objClsMethod.QuantitativeDataCollection.Item(intSelectedRunNumberIndex).StandardDataCollection.Clone
            cursamp = objClsMethod.QuantitativeDataCollection.Item(intSelectedRunNumberIndex).SampleDataCollection.Clone

            If Not IsNothing(curstd) Then 'IsNothing(gobjNewMethod.QuantitativeDataCollection(gobjNewMethod.QuantitativeDataCollection.Count - 1).StandardDataCollection) Then
                For intCounter = 0 To curstd.Count - 1
                    'If (curstd Is gobjNewMethod.QuantitativeDataCollection(gobjNewMethod.QuantitativeDataCollection.Count - 1).StandardDataCollection) Then
                    '    Exit For
                    'End If
                    If curstd.item(intCounter).Used Then
                        samples += 1
                    End If
                Next
            Else
                samples = GetTotStdAnalysed(curstd)
            End If

            If (objClsMethod.StandardAddition) Then
                If Not IsNothing(cursamp) Then
                    ''If (cursamp != CurSamp) Then
                    'If (cursamp.item(0).Used) Then
                    '    samples += 1
                    'End If
                    ''end if 
                End If
            Else
                If Not IsNothing(cursamp) Then
                    For intCounter = 0 To cursamp.Count - 1
                        'If (cursamp Is gobjNewMethod.QuantitativeDataCollection(gobjNewMethod.QuantitativeDataCollection.Count - 1).SampleDataCollection) Then
                        '    Exit For
                        'End If
                        If cursamp.item(intCounter).Used Then
                            samples += 1
                        End If
                    Next
                End If
            End If

            Return samples

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

    Public Shared Function FindMaxStdConc(ByVal objStandardData As AAS203Library.Method.clsAnalysisStdParametersCollection) As Double
        '=====================================================================
        ' Procedure Name        : FindMaxStdConc
        ' Parameters Passed     : clsAnalysisStdParametersCollection
        ' Returns               : double
        ' Purpose               : Find the Maximum standard Conc. from given object
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 31-Jan-2007 05:35 pm
        ' Revisions             : 1
        '=====================================================================

        '**********************************************************
        '----- ORIGINAL CODE
        '**********************************************************
        'double	S4FUNC	FindMaxStdConc(STDDATA   *StdTop)
        '{
        '   double	max=-1000.0;
        '	STDDATA   *tempk=NULL;
        '	tempk =StdTop;
        '   While (tempk! = NULL)
        '	{
        '	    if (max<tempk->Data.Conc)
        '		    max = tempk->Data.Conc;
        '		tempk=tempk->next;
        '	}
        '	return max;
        '}
        '**********************************************************
        Dim max As Double = -1000.0
        Dim intCounter As Integer

        Try
            ' Search the Maximum standard Conc. from given object
            For intCounter = 0 To objStandardData.Count - 1
                If max < objStandardData.item(intCounter).Concentration Then
                    max = objStandardData.item(intCounter).Concentration
                End If
            Next intCounter

            Return max

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

    Public Shared Function FindMaxStdAbs(ByVal objStandardData As AAS203Library.Method.clsAnalysisStdParametersCollection) As Double
        '=====================================================================
        ' Procedure Name        : FindMaxStdAbs
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : Find the Maximum standard ABS. from given object
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 31-Jan-2007 05:35 pm
        ' Revisions             : 1
        '=====================================================================

        '**********************************************************
        '----- ORIGINAL CODE
        '**********************************************************
        'double	S4FUNC	FindMaxStdAbs(STDDATA   *StdTop)
        '{
        '   double	max=-1000.0;
        '	STDDATA   *tempk=NULL;
        '	tempk =StdTop;
        '   While (tempk! = NULL)
        '	{
        '	    if (max<tempk->Data.Abs)
        '		    max = tempk->Data.Abs;
        '		tempk=tempk->next;
        '	}
        '	return max;
        '}
        '**********************************************************
        Dim max As Double = -1000.0
        Dim intCounter As Integer

        Try
            ' Searchthe Maximum standard Abs. from given object
            For intCounter = 0 To objStandardData.Count - 1
                If max < objStandardData.item(intCounter).Abs Then
                    max = objStandardData.item(intCounter).Abs
                End If
            Next intCounter

            Return max

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

    Public Shared Function GetTotStdsInBetweenConc(ByVal conc1 As Double, ByVal conc2 As Double, _
                                         ByVal objStandardData As AAS203Library.Method.clsAnalysisStdParametersCollection, _
                                         ByVal blnCheckUsed As Boolean) As Integer
        '=====================================================================
        ' Procedure Name        : GetTotStdsInBetweenConc
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : to find a total num of std in bet the passed conc.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================

        '*******************************************************
        '---- ORIGINAL CODE
        '*******************************************************
        'int S4FUNC GetTotStdsInBetweenConc(double conc1, double conc2, STDDATA   *StdTop, BOOL flag)
        '{
        '	STDDATA   *tempk=NULL;
        '	int		 tot=0;

        '	tempk =StdTop;
        '        While (tempk! = NULL)
        '	{
        '            If (flag) Then
        '		{
        '			if (tempk->Data.Used)
        '			{
        '				if (tempk->Data.Conc>=conc1 && tempk->Data.Conc<=conc2)
        '					tot++;
        '			}
        '		}
        '		else if (tempk->Data.Conc>=conc1 && tempk->Data.Conc<=conc2)
        '			tot++;
        '		tempk=tempk->next;
        '	}
        '	return tot;
        '}
        '*******************************************************
        Dim intTotalStandards As Integer
        Dim intCounter As Integer

        Try
            For intCounter = 0 To objStandardData.Count - 1

                If blnCheckUsed Then
                    If (objStandardData.item(intCounter).Used) Then
                        If (objStandardData.item(intCounter).Concentration >= conc1 And _
                            objStandardData.item(intCounter).Concentration <= conc2) Then
                            intTotalStandards += 1
                        End If
                    End If

                ElseIf (objStandardData.item(intCounter).Concentration >= conc1 And _
                         objStandardData.item(intCounter).Concentration <= conc2) Then
                    intTotalStandards += 1
                End If

            Next

            Return intTotalStandards

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

    Public Shared Function CheckValidStdAbsEntry(ByVal objStandardData As Method.clsAnalysisStdParametersCollection) As Boolean
        '=====================================================================
        ' Procedure Name        : CheckValidStdAbsEntry
        ' Parameters Passed     : objStandardData
        ' Returns               : None
        ' Purpose               : for validation of std abs .
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        'BOOL CheckValidStdAbsEntry( STDDATA *std) // this fn added by sss for checking the valid std used or not dt 30/11/2K
        '{
        'double abs=0.0;
        'BOOL   flag = TRUE;
        'if(std){
        '	if(std->Data.Used==1){
        '		abs = std->Data.Abs;
        '		std = std=std->next;
        '	}
        '}
        'while(std){
        '	  if(std->Data.Used==1){
        '		  if( std->Data.Abs <= abs ){
        '				flag = FALSE;
        '				Gerror_message_new("Abs of the standard is less than or equal to the previous standard", "Standards");
        '				return flag;
        '		  }
        '		  abs = std->Data.Abs;
        '	  }
        '	  std=std->next;
        '}
        'return flag;
        '}

        '*****************************
        '---CODE BY MANGESH
        '*****************************
        Dim abs As Double = 0.0
        Dim flag As Boolean = True
        Dim intCounter As Integer
        Dim FirstUsed As Boolean = False

        Try
            
            For intCounter = 0 To objStandardData.Count - 1
                If (objStandardData(intCounter).Used = True) Then
                    'Added By Pankaj on 07 Jun 07
                    If (FirstUsed = False) Then
                        abs = objStandardData(intCounter).Abs
                        FirstUsed = True
                    Else
                        '---------------------
                        If (objStandardData(intCounter).Abs <= abs) Then
                            flag = False
                            Call gobjMessageAdapter.ShowMessage(constStandardAbsorbance)
                            ''show the mess
                            Call Application.DoEvents()
                            ''allow application to perfrom it panding work.
                            Return False
                        End If
                        abs = objStandardData(intCounter).Abs
                    End If
                End If
            Next

            Return flag
            ''return flag as true or false.

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

    Public Shared Function CheckValidStdAbsEntry(ByVal objStandardData As Method.clsAnalysisStdParameters) As Boolean
        '=====================================================================
        ' Procedure Name        : CheckValidStdAbsEntry
        ' Parameters Passed     : objStandardData
        ' Returns               : None
        ' Purpose               : for validation of std abs .
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        'BOOL CheckValidStdAbsEntry( STDDATA *std) // this fn added by sss for checking the valid std used or not dt 30/11/2K
        '{
        'double abs=0.0;
        'BOOL   flag = TRUE;
        'if(std){
        '	if(std->Data.Used==1){
        '		abs = std->Data.Abs;
        '		std = std=std->next;
        '	}
        '}
        'while(std){
        '	  if(std->Data.Used==1){
        '		  if( std->Data.Abs <= abs ){
        '				flag = FALSE;
        '				Gerror_message_new("Abs of the standard is less than or equal to the previous standard", "Standards");
        '				return flag;
        '		  }
        '		  abs = std->Data.Abs;
        '	  }
        '	  std=std->next;
        '}
        'return flag;
        '}

        '*****************************
        '---CODE BY MANGESH
        '*****************************
        Dim abs As Double = 0.0
        Dim flag As Boolean = True
        Dim intCounter As Integer

        Try
            'For intCounter = 0 To objStandardData.Count - 1
            '    If (objStandardData(intCounter).Used = True) Then
            '        If (objStandardData(intCounter).Abs <= abs) Then
            '            flag = False
            '            Call gobjMessageAdapter.ShowMessage("Abs of the standard is less than or equal to the previous standard", "Standards", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
            '            Call Application.DoEvents()
            '            Return False
            '        End If
            '        abs = objStandardData(intCounter).Abs
            '    End If
            'Next

            '---this function is written by deepak on 02.04.07

            If (objStandardData.Used = True) Then
                If (objStandardData.Abs <= abs) Then
                    flag = False
                    Call gobjMessageAdapter.ShowMessage(constStandardAbsorbance)
                    Call Application.DoEvents()
                    Return False
                End If
                abs = objStandardData.Abs
            End If

            Return flag

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

    Public Shared Function CheckValidSampAbsEntry(ByVal objStandardData As Method.clsAnalysisStdParametersCollection, ByVal dblSampConc As Double) As Boolean
        '=====================================================================
        ' Procedure Name        : CheckValidSampAbsEntry
        ' Parameters Passed     : objSampleData
        ' Returns               : None
        ' Purpose               : for validation of sample abs .
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 04.02.09
        '=====================================================================
        'BOOL CheckValidSampAbsEntry( STDDATA *std,double sampconc) 
        '{
        'double abs=0.0;
        'BOOL   flag = TRUE;
        'abs=GetMaxStdAbs(std);
        'If ((abs) < sampconc) Then
        'flag = FALSE;
        'return flag;
        '}
        '=====================================================================
        Dim abs As Double = 0.0
        Dim flag As Boolean = True
        Try
            abs = FindMaxStdAbs(objStandardData)

            If (FormatNumber(CDbl(abs), 3) < CDbl(dblSampConc)) Then '---type cast and format on 03.07.09
                flag = False
            End If

            Return flag
            ''return a flag for true or false
            ''for validation state.

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

    Public Shared Function CheckValidSampAbsEntry(ByVal objSampleData As Method.clsAnalysisSampleParametersCollection, ByVal dblSampConc As Double) As Boolean
        '=====================================================================
        ' Procedure Name        : CheckValidSampAbsEntry
        ' Parameters Passed     : objSampleData
        ' Returns               : None
        ' Purpose               : for validation of sample abs .
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 
        '=====================================================================
        'BOOL CheckValidSampAbsEntry( STDDATA *std,double sampconc) 
        '{
        'double abs=0.0;
        'BOOL   flag = TRUE;
        'abs=GetMaxStdAbs(std);
        'If ((abs) < sampconc) Then
        'flag = FALSE;
        'return flag;
        '}
        '=====================================================================
        Dim abs As Double = 0.0
        Dim flag As Boolean = True

        Try
            abs = GetMaxSampleAbs(objSampleData)

            If ((abs) < dblSampConc) Then
                flag = False
            End If

            Return flag
            ''return a flag for true or false
            ''for validation state.

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

    Public Shared Function CheckValidSampAbsEntry(ByVal objSampleData As Method.clsAnalysisSampleParameters, ByVal dblSampConc As Double) As Boolean
        '=====================================================================
        ' Procedure Name        : CheckValidSampAbsEntry
        ' Parameters Passed     : objSampleData
        ' Returns               : None
        ' Purpose               : for validation of sample abs .
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        'the function is written by deepak on 02.05.07
        Dim abs As Double = 0.0
        Dim flag As Boolean = True

        Try
            abs = GetMaxSampleAbs(objSampleData)

            If ((abs) < dblSampConc) Then
                flag = False
            End If

            Return flag

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

    Public Shared Function GetMaxSampleAbs(ByVal objSampleData As Method.clsAnalysisSampleParametersCollection) As Double
        '=====================================================================
        ' Procedure Name        : GetMaxSampleAbs
        ' Parameters Passed     : clsAnalysisSampleParameters
        ' Returns               : double
        ' Purpose               : Find the Maximum standard Conc. from given object
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 31-Jan-2007 05:35 pm
        ' Revisions             : 1
        '=====================================================================

        'double GetMaxStdAbs(STDDATA *std)
        '{
        'double Abs=0.0;
        'while(std){
        '	  if(std->Data.Used==1){
        '		  if( std->Data.Abs >= Abs )
        '				Abs = std->Data.Abs;
        '	  }
        '	  std=std->next;
        '}
        'return Abs;
        '}

        '********************
        '---CODE BY MANGESH 
        '********************
        Dim Abs As Double
        Dim intCounter As Integer

        Try
            For intCounter = 0 To objSampleData.Count - 1
                If (objSampleData.item(intCounter).Used = 1) Then
                    If (objSampleData.item(intCounter).Abs >= Abs) Then
                        Abs = objSampleData.item(intCounter).Abs
                    End If
                End If
            Next

            Return Abs

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

    Public Shared Function GetMaxSampleAbs(ByVal objSampleData As Method.clsAnalysisSampleParameters) As Double
        '=====================================================================
        ' Procedure Name        : GetMaxSampleAbs
        ' Parameters Passed     : clsAnalysisSampleParameters
        ' Returns               : double
        ' Purpose               : Find the Maximum standard Conc. from given object
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 31-Jan-2007 05:35 pm
        ' Revisions             : 1
        '=====================================================================
        'double GetMaxStdAbs(STDDATA *std)
        '{
        'double Abs=0.0;
        'while(std){
        '	  if(std->Data.Used==1){
        '		  if( std->Data.Abs >= Abs )
        '				Abs = std->Data.Abs;
        '	  }
        '	  std=std->next;
        '}
        'return Abs;
        '}
        'the function is sritten by deepak on 02.05.07
        Dim Abs As Double
        Dim intCounter As Integer

        Try
            If (objSampleData.Used = 1) Then
                If (objSampleData.Abs >= Abs) Then
                    Abs = objSampleData.Abs
                End If
            End If

            Return Abs

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

#Region " Private Functions "

    Private Function Calc_ConcDirect(ByVal dblY As Double) As Double
        '=====================================================================
        ' Procedure Name        : Calc_ConcDirect
        ' Parameters Passed     : Y-Value
        ' Returns               : Conc. Value in double
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 03-Feb-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================

        '****************************************************
        '---- ORIGINAL CODE
        '****************************************************
        'double	Calc_ConcDirect(double y)
        '{
        '	double x1=0.0, y1=0.0;
        '	double x2=0.0, y2=0.0, x=0;
        '	int	i;

        '	if (y>Y[No-1])
        '		return -1.0;

        '	for(i=0;i<No; i++)
        '		if (y==Y[i])
        '		{
        '			x=X[i];
        '			break;
        '		}
        '                    If (i >= No) Then
        '		{
        '			if (Find_Between_Pts(0.0, y, &x1, &y1, &x2, &y2, TRUE))
        '                            If (y2! = y1) Then
        '					x = x1+ (x2-x1)*(y-y1)/(y2-y1);
        '		}
        '	return x;
        '}
        '****************************************************
        Dim x1, y1 As Double
        Dim x2, y2, dblX As Double
        Dim i As Integer

        Try
            If (dblY > Y(No - 1)) Then
                Return -1.0
            End If
            '//----- Commented by Sachin Dokhale on 16.09.07
            'For i = 0 To No - 1
            '    If (dblY = Y(i)) Then
            '        dblX = X(i)
            '        Exit For
            '    End If
            '    If (i >= No) Then
            '        If (Find_Between_Pts(0.0, dblY, x1, y1, x2, y2, True)) Then
            '            If (y2 <> y1) Then
            '                dblX = x1 + (x2 - x1) * (dblY - y1) / (y2 - y1)
            '            End If
            '        End If
            '    End If
            'Next
            '//-----
            For i = 0 To No - 1
                If (dblY = Y(i)) Then
                    'Return dblX = X(i)
                    Return X(i)
                    'Exit For
                End If
            Next

            If (i >= No) Then
                'If (dblY <= Y(i)) Then
                If (Find_Between_Pts(0.0, dblY, x1, y1, x2, y2, True)) Then
                    If (y2 <> y1) Then
                        dblX = x1 + (x2 - x1) * (dblY - y1) / (y2 - y1)
                    End If
                End If
            End If

            Return dblX

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

    Private Function GetConcRational(ByVal y1 As Double) As Double
        '=====================================================================
        ' Procedure Name        : GetConcRational
        ' Parameters Passed     : Y1 as double
        ' Returns               : Conc. value in Double 
        ' Purpose               : used for getting a conc rational.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 03-Feb-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================

        '********************************************************
        '---- ORIGINAL CODE
        '********************************************************
        'double  GetConcRational(double	y1)
        '{
        '	double	x1=0.0;
        '	x1=(MatA[0]+MatA[1]*y1+MatA[2]*y1*y1);
        '        If (x1! = 0.0) Then
        '		x1 = y1/x1;
        '        Else
        '		x1=0.0;
        '	return x1;
        '}
        '********************************************************
        Dim x1 As Double

        Try
            x1 = (MatA(0) + MatA(1) * y1 + MatA(2) * y1 * y1)

            If (x1 <> 0.0) Then
                x1 = y1 / x1
            Else
                x1 = 0.0
            End If

            Return x1

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

    Private Function Regula_falsei(ByVal y11 As Double, ByVal xinitial As Double, ByVal xmax As Double) As Double
        '=====================================================================
        ' Procedure Name        : Regula_falsei
        ' Parameters Passed     : y1, Initial X, XMax values
        ' Returns               : Conc in Double
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 03-Feb-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================

        '***********************************************************
        '----- ORIGINAL CODE
        '***********************************************************
        'double	Regula_falsei(double y11, double xinitial, double xmax)
        '{
        '	double 	eps=0.000001, x1=-10000.0, x2=10000.0;
        '	double	x3=0.0, y1=0.0, y2=0.0, y3=0.0,dx=0.0;
        '	int		k, max=200;
        '	BOOL		sat=FALSE;

        '	if (!Return_InitalValue(y11, &x1, &x2))
        '		return Get_Conc1(y11, xinitial, xmax);

        '	y1 = Fn(x1, y11);
        '	y2 = Fn(x2, y11);

        '	for(k=1;k<max; k++)
        '	{
        '		if ((y2-y1) !=(double) 0.0)
        '			dx = y2*(x2-x1)/(y2-y1);
        '                Else
        '			dx=0.0;
        '		x3 = x2-dx;
        '		y3 = Fn(x3, y11);
        '		if (y3==(double) 0.0)
        '			sat=TRUE;
        '		else if (sign(y2)==sign(y3))
        '		{
        '			x2=x3;
        '			y2=y3;
        '		}
        '                    Else
        '		{
        '			x1=x3;
        '			y1=y3;
        '		}
        '		if (fabs(y3)<eps) //fabs(dx)<delta&&
        '			sat=TRUE;
        '                            If (sat) Then
        '			break;
        '	}
        '	return x3;
        '}
        '***********************************************************
        Dim eps As Double
        Dim x1 As Double
        Dim x2 As Double
        Dim x3, y1, y2, y3, dx As Double
        Dim k, max As Integer
        Dim sat As Boolean

        Try
            eps = 0.000001
            x1 = -10000.0
            x2 = 10000.0
            max = 200

            If Not (Return_InitalValue(y11, x1, x2)) Then
                Return Get_Conc1(y11, xinitial, xmax)
            End If

            y1 = Fn(x1, y11)
            y2 = Fn(x2, y11)

            For k = 1 To max - 1
                If ((y2 - y1) <> 0.0) Then
                    dx = y2 * (x2 - x1) / (y2 - y1)
                Else
                    dx = 0.0
                End If

                x3 = x2 - dx
                y3 = Fn(x3, y11)

                If (y3 = 0.0) Then
                    sat = True
                ElseIf (sign(y2) = sign(y3)) Then
                    x2 = x3
                    y2 = y3
                Else
                    x1 = x3
                    y1 = y3
                End If
                If (Math.Abs(y3) < eps) Then
                    sat = True
                    If (sat) Then
                        Exit For
                    End If
                End If
            Next

            Return x3

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

    Private Function GetInterval_val(ByVal Max As Double, ByVal Min As Double, _
                                     ByVal Kv As Double, ByVal TotData As Integer, ByVal flag As Boolean) As Double
        '=====================================================================
        ' Procedure Name        : GetInterval_val
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : get a interval bet given parameter.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 31-Jan-2007 05:15 pm
        ' Revisions             : 1
        '=====================================================================

        '********************************************************
        '---- ORIGINAL CODE
        '********************************************************
        'double	GetInterval_val(double Max, double Min, int Kv, int TotData,BOOL flag)
        '{
        '   double	offa[]={ 0.001,  0.002,  0.005, 0.01, 0.02, 0.05, 0.1,   0.2,   0.5,
        '					  1.0,    2.0,    5.0,   10.0, 20.0, 50.0, 100.0, 200.0, 500.0,
        '					  1000.0, 2000.0, 5000.0, 10000.0, 20000.0, 50000.0};

        '	#define MAXEN	24
        '	#define INTST	9

        '	double	x=0.0;
        '	int i, k, NClass;

        '	if (TotData==0)
        '		return (double) 1.0;

        '	x = (double)1.0 + (double)3.322 * log10((double)TotData);

        '	NClass = (int) floor(x + (double)0.5);

        '            If (flag) Then
        '		i = 0;
        '            Else
        '		i = INTST;

        '	for(; i<MAXEN; i++)
        '	{
        '		x =  (Max-Min);
        '		k = (int) (x / offa[i]);

        '		if (k >= NClass-Kv && k <= NClass+Kv)
        '			break;
        '	}

        '                        If (i < MAXEN) Then
        '		x = offa[i];
        '                        Else
        '		x = (double)-1.0;
        '	return x;
        '}
        '********************************************************
        Dim offa() As Double = {0.001, 0.002, 0.005, 0.01, 0.02, 0.05, 0.1, 0.2, 0.5, _
                                1.0, 2.0, 5.0, 10.0, 20.0, 50.0, 100.0, 200.0, 500.0, _
                                1000.0, 2000.0, 5000.0, 10000.0, 20000.0, 50000.0}

        Const MAXEN = 24
        Const INTST = 9

        Dim x As Double = 0.0
        Dim i, k, NClass As Integer

        Try
            '//----- Added by Sachin DOkhale on 21.05.07
            'If (TotData = 0) Then
            '    Return 1.0
            'End If
            If (TotData <= 0) Then
                Return 1.0
            End If
            '//-----

            x = 1.0 + 3.322 * Math.Log10(TotData)

            NClass = CInt(Math.Floor(x + 0.5))

            If (flag) Then
                i = 0
            Else
                i = INTST
            End If

            For i = 0 To MAXEN - 1
                x = Max - Min
                k = CInt(x / offa(i))
                If (k >= NClass - Kv And k <= NClass + Kv) Then
                    Exit For
                End If
            Next

            If (i < MAXEN) Then
                x = offa(i)
            Else
                x = -1.0
            End If

            Return x

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

    Private Sub SetStdAddnFlag(ByVal flag As Boolean)
        '=====================================================================
        ' Procedure Name        : SetStdAddnFlag
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : to get a std addtion flag.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 31-Jan-2007 05:15 pm
        ' Revisions             : 1
        '=====================================================================
        'E4FUNC void S4FUNC SetStdAddnFlag(BOOL flag)
        '{
        'stdaddn = flag;
        '        If (flag) Then
        '	rational=FALSE;
        '}
        Try
            mblnIsStandardAddition = flag

            If flag Then
                Rational = False
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

    Private Function GetBestFit(ByVal blnIsSilent As Boolean) As enumCalculationMode
        '=====================================================================
        ' Procedure Name        : GetBestFit
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : for getting a best fit curve
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================

        '***********************************************************
        '---- ORIGINAL CODE
        '***********************************************************
        'int GetBestFit (void)
        '{
        '	double 	*abs=NULL;
        '	double 	*conc=NULL;
        '	int		i;
        '	STDDATA	*tempk;
        '	HWND		hwnd;
        '	HDC		hdc;
        '	HCURSOR	curs;

        '	curs = Load_Curs();

        '	hwnd = Create_Window(NULL, 250, 100, " Automatic Curve fit");
        '	hdc= GetDC(hwnd);

        '	SetTextColor(hdc, RGB(192,192,192));
        '	Gprintf(hdc,10, 10," Wait ... Automatically ");
        '	Gprintf(hdc,10, 25," Generating Best ");
        '	Gprintf(hdc,10, 40," Standard Working graph ...");

        '	ReleaseDC(hwnd, hdc);

        '	CalcUsedTotStd = GetTotStds(Method->QuantData->StdTopData, TRUE);

        '	abs = (double *) malloc(sizeof(double) *(CalcUsedTotStd+1));

        '	if (abs==NULL)
        '		return DIRECT;

        '	conc= (double *) malloc(sizeof(double) *(CalcUsedTotStd+1));

        '	if (conc==NULL)
        '	{
        '		free(abs);
        '		abs=NULL;
        '		return DIRECT;
        '	}

        '	i=0;
        '	tempk = Method->QuantData->StdTopData;

        '                While (tempk)
        '	{
        '                    If (i < CalcUsedTotStd) Then
        '		{
        '			if (tempk->Data.Used)
        '			{
        '				abs[i]=tempk->Data.Abs;
        '				conc[i]=tempk->Data.Conc;
        '				i++;
        '			}
        '		}
        '		tempk=tempk->next;
        '	}
        '#If STD_ADDN Then
        '		if( Method->QuantData->Param.Std_Addn)
        '			i = LINEAR;
        '		else
        '			i = Get_Best_Out_Of_Curve(abs, conc,CalcUsedTotStd);
        '#Else
        '		i = Get_Best_Out_Of_Curve(abs, conc,CalcUsedTotStd);
        '#End If

        '	free(abs);
        '	abs=NULL;
        '	free(conc);
        '	conc=NULL;

        '	Close_Window(hwnd, NULL);
        '	SetCursor(curs);

        '	return i;
        '}
        '***********************************************************
        Dim objWaitCursor As New CWaitCursor
        Dim abs(), conc() As Double
        Dim intCount As Integer
        'STDDATA	*tempk;
        'HWND		hwnd;
        'HDC		hdc;
        'HCURSOR	curs;

        Try
            'curs = Load_Curs();
            'hwnd = Create_Window(NULL, 250, 100, " Automatic Curve fit");
            'hdc= GetDC(hwnd);
            'SetTextColor(hdc, RGB(192,192,192));
            'Gprintf(hdc,10, 10," Wait ... Automatically ");
            'Gprintf(hdc,10, 25," Generating Best ");
            'Gprintf(hdc,10, 40," Standard Working graph ...");
            'ReleaseDC(hwnd, hdc);

            Dim strWaitMessage As String
            strWaitMessage = " Please Wait..." & ""
            strWaitMessage &= vbCrLf & " Automatically Generating the"
            strWaitMessage &= vbCrLf & " Best Standard Working graph..."
            ''set a strinf to be displayed during process
            If Not blnIsSilent Then
                gobjMessageAdapter.ShowStatusMessageBox(strWaitMessage, "Automatic Curve fit", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 1000)
                ''show a mess of automaticllay curve fitting.
            End If

            CalcUsedTotStd = GetTotStds(mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection, True)
            ''for getting a total number of std.
            'abs = (double *) malloc(sizeof(double) *(CalcUsedTotStd+1));
            ReDim abs(CalcUsedTotStd + 1)

            If IsNothing(abs) Then Return enumCalculationMode.DIRECT

            'conc= (double *) malloc(sizeof(double) *(CalcUsedTotStd+1));
            ReDim conc(CalcUsedTotStd + 1)

            If IsNothing(conc) Then
                abs = Nothing
                Return enumCalculationMode.DIRECT
            End If

            For intCount = 0 To mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count - 1
                ''check a data structure
                If intCount < CalcUsedTotStd Then
                    If mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Used Then
                        ''get all value of abs and conc.
                        abs(intCount) = mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Abs
                        conc(intCount) = mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Concentration
                    End If
                End If
            Next intCount

            '#If STD_ADDN Then
            '   if( Method->QuantData->Param.Std_Addn)
            '	    i = LINEAR;
            '	else
            '		i = Get_Best_Out_Of_Curve(abs, conc,CalcUsedTotStd);
            '#Else
            '	i = Get_Best_Out_Of_Curve(abs, conc,CalcUsedTotStd);
            '#End If

            If (mobjClsMethod.StandardAddition) Then
                intCount = enumCalculationMode.LINEAR
            Else
                ''pass the value of abs and conc to function which we calculated above.
                intCount = Get_Best_Out_Of_Curve(abs, conc, CalcUsedTotStd)
            End If

            'abs = Nothing
            'conc = Nothing

            'Close_Window(hwnd, NULL);
            'SetCursor(curs);

            'If Not blnIsSilent Then
            '    Call gobjMessageAdapter.CloseStatusMessageBox()
            'End If

            Return intCount

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
            If Not blnIsSilent Then
                Call gobjMessageAdapter.CloseStatusMessageBox()
                Application.DoEvents()
            End If
            objWaitCursor.Dispose()
            '---------------------------------------------------------
        End Try
    End Function

    Private Function Get_Best_Out_Of_Curve(ByRef abs() As Double, ByRef conc() As Double, ByVal nStd As Integer) As enumCalculationMode
        '=====================================================================
        ' Procedure Name        : Get_Best_Out_Of_Curve
        ' Parameters Passed     : Abs Values array, Conc. Values array, No. of Standard
        ' Returns               : integer
        ' Purpose               : 
        ' Description           : for ploting a curve.
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 04-Feb-2007 01:40 pm
        ' Revisions             : 1
        '=====================================================================

        '*******************************************************
        '---- ORIGINAL CODE
        '*******************************************************
        'E4FUNC int S4FUNC Get_Best_Out_Of_Curve(double *abs, double *conc,int nStd)
        '{
        '	double	conc1=0.0, err1=0.0, averr=0.0;
        '	int	cmode, i, acount;
        '	BOOL	flag=FALSE;

        '	for(cmode=RATIONAL; cmode<=FIFTH_ORDER; cmode++)
        '		err[cmode]=1000.0;

        '	for(cmode=RATIONAL; cmode<=FIFTH_ORDER; cmode++)
        '	{
        '                If (Calculate_Curve(abs, conc, nStd, cmode, ZERO_PASSING)) Then
        '		{
        '			flag=TRUE;
        '			averr=0.0; acount=0; conc1=0;
        '			conc1 = Get_Conc(0.0, conc1);//, 8);
        '			err1= fabs(conc1)*100.0;
        '			averr+=err1;
        '			acount++;
        '			for(i=0;i<nStd; i++)
        '			{
        '				conc1 = Get_Conc(abs[i], conc1);//, 8);
        '				err1= fabs(conc1-conc[i])*100.0;
        '				if (conc[i]!=0.0)
        '					err1 /= (conc[i]);
        '				averr+=err1;
        '				acount++;
        '			}
        '                            If (acount > 0) Then
        '				averr /=(acount);
        '			err[cmode]=averr;
        '		}
        '	}
        '                                If (flag) Then
        '	{
        '		err1=2000.0; cmode=DIRECT;
        '		for(i=RATIONAL; i<=FIFTH_ORDER; i++)
        '			if (err1>err[i])
        '			{
        '				cmode=i;
        '				err1  = err[i];
        '			}
        '	}
        '   If (flag) Then
        '	{
        '		Calculate_Curve(abs, conc, nStd, cmode,TRUE);
        '		return cmode;
        '	}
        '   Else
        '		return DIRECT;
        '}
        '*******************************************************
        Dim conc1, err1, averr As Double
        Dim cmode, i, acount As Integer
        Dim flag As Boolean

        Try
            For cmode = enumCalculationMode.RATIONAL To enumCalculationMode.FIFTH_ORDER
                err(cmode) = 1000.0
            Next

            For cmode = enumCalculationMode.RATIONAL To enumCalculationMode.FIFTH_ORDER
                If (Calculate_Curve(abs, conc, nStd, cmode, ZERO_PASSING)) Then
                    flag = True
                    averr = 0.0
                    acount = 0
                    conc1 = 0
                    conc1 = Get_Conc(0.0, conc1)
                    err1 = Math.Abs(conc1) * 100.0
                    averr += err1
                    acount += 1
                    '			for(i=0;i<nStd; i++)
                    '			{
                    '				conc1 = Get_Conc(abs[i], conc1);//, 8);
                    '				err1= fabs(conc1-conc[i])*100.0;
                    '				if (conc[i]!=0.0)
                    '					err1 /= (conc[i]);
                    '				averr+=err1;
                    '				acount++;
                    '			}
                    For i = 0 To nStd - 1
                        conc1 = Get_Conc(abs(i), conc1)
                        err1 = Math.Abs(conc1 - conc(i)) * 100.0
                        If (conc(i) <> 0.0) Then
                            err1 /= conc(i)
                        End If
                        averr += err1
                        acount += 1
                    Next
                    If (acount > 0) Then
                        averr /= (acount)
                    End If
                    err(cmode) = averr
                End If
            Next

            '                                If (flag) Then
            '	{
            '		err1=2000.0; cmode=DIRECT;
            '		for(i=RATIONAL; i<=FIFTH_ORDER; i++)
            '			if (err1>err[i])
            '			{
            '				cmode=i;
            '				err1  = err[i];
            '			}
            '	}
            If (flag) Then
                err1 = 2000.0
                cmode = enumCalculationMode.DIRECT
                For i = enumCalculationMode.RATIONAL To enumCalculationMode.FIFTH_ORDER
                    If (err1 > err(i)) Then
                        cmode = i
                        err1 = err(i)
                    End If
                Next
            End If

            If (flag) Then
                Calculate_Curve(abs, conc, nStd, cmode, True)
                Return cmode
            Else
                Return enumCalculationMode.DIRECT
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
    End Function

    Private Function Calculate_Curve(ByRef Abs() As Double, ByRef Conc() As Double, _
                            ByVal nStd As Integer, ByVal nDegree As Integer, ByVal zflag As Boolean) As Boolean
        '=====================================================================
        ' Procedure Name        : Calculate_Curve
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : calculating a curve as par given value of Abs and Conc.
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 31-Jan-2007 10:35 pm
        ' Revisions             : 1
        '=====================================================================

        '***********************************************************
        '---- ORIGINAL CODE
        '***********************************************************
        'E4FUNC  BOOL	S4FUNC  Calculate_Curve(double *Abs, double *Conc, int nStd, int nDegree, BOOL zflag)
        '{
        '	double	ty=0.0;
        '	int		i;

        '	FindMaxAbs(Abs,  nStd);
        '	Curve_Status=FALSE;
        '	InitMatrixData();

        '	No = nStd;
        '	N =nDegree;
        '	rational=FALSE;
        '	if (N==0){ 
        '            If (nStd < 2) Then
        '			return FALSE;
        '		rational=TRUE;
        '		Copy_Matrix_Row(X, Conc, No, TRUE);
        '		Copy_Matrix_Row(Y, Abs,  No, TRUE);
        '		for(i=0; i<No; i++){
        '			ty=Y[i];
        '			if (X[i]==(double) 0.0)
        '				Y[i]=0.0;
        '                    Else
        '				Y[i]=Y[i]/X[i];
        '			X[i] =ty;
        '		}
        '		N=2;
        '	}
        '	else{
        '		Copy_Matrix_Row(X, Conc, No, !zflag);
        '		Copy_Matrix_Row(Y, Abs,  No, !zflag);
        '                        If (zflag) Then
        '			No++;
        '	}
        '	if (No<N) //+1)
        '		return FALSE;
        '	N++;
        '	if (N>1){
        '		Contruct_matrix();
        '		Calculate_BestFit();
        '	}
        '	Curve_Status=TRUE;
        '	return TRUE;
        '}
        '***********************************************************
        Dim ty As Double = 0.0
        Dim i As Integer

        Try
            ' Calculate the curve
            Call FindMaxAbs(Abs, nStd)
            ''to find max of abs
            Curve_Status = False
            Call InitMatrixData()
            'for initialization of matrix data.

            No = nStd
            N = nDegree
            Rational = False

            If (N = 0) Then
                If (nStd < 2) Then
                    Return False
                End If
                Rational = True

                Copy_Matrix_Row(X, Conc, No, True)
                ''for copy a matrix row.
                Copy_Matrix_Row(Y, Abs, No, True)
                ''for copy a matrix row.
                For i = 0 To No - 1
                    ty = Y(i)
                    If X(i) = 0.0 Then
                        Y(i) = 0.0
                    Else
                        Y(i) = Y(i) / X(i)
                    End If
                    X(i) = ty
                Next
                N = 2

            Else
                '//----- commented by Sachin Dokhale
                Copy_Matrix_Row(X, Conc, No, (Not zflag))
                ''for copy a matrix row.
                Copy_Matrix_Row(Y, Abs, No, (Not zflag))
                ''for copy a matrix row.
                '//----- Added by Sachin Dokhale 
                'Copy_Matrix_Row(X, Conc, No, (zflag))
                'Copy_Matrix_Row(Y, Abs, No, (zflag))
                '//-----

                If (zflag) Then
                    No += 1
                End If
            End If

            If (No < N) Then
                Return False
            End If

            N += 1
            If (N > 1) Then
                Contruct_matrix()
                ''for constructing a matrix

                Calculate_BestFit()
                ''for calculate a base fit.
            End If

            Curve_Status = True
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

    Private Sub Calculate_BestFit()
        '=====================================================================
        ' Procedure Name        : Calculate_BestFit
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : for calculating a base fit.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 31-Jan-2007 02:10 pm
        ' Revisions             : 1
        '=====================================================================

        '*************************************************************
        '---- ORIGINAL CODE
        '*************************************************************
        'void Calculate_BestFit()
        '{
        '	double	x=0.0;
        '	int 		i, I, n;
        '	int  		j, J;

        '	for(i=0; i<N; i++)
        '		for(j=0; j<N; j++)
        '			if (i!=0 || j!=0)
        '				MatX[i][j]=0;

        '	for (i=0; i<N;i++)
        '		MatY[i]=0.0;

        '	for (I=0; I<N; I++)
        '	{
        '		for(J=0; J<N; J++)
        '		{
        '			if ( (I!=0 || J!=0) )
        '			{
        '				for(i=0; i<No; i++)
        '				{
        '					x = pow(X[i],(double) (I+J));
        '					MatX[I][J] += x;
        '				}
        '			}
        '		}
        '	}

        '	for (I=0; I<N; I++)
        '		for(i=0; i<No; i++)
        '		{
        '                                                If (I! = 0) Then
        '			{
        '				if (X[i]!=0.0)
        '					x = pow(X[i],(double) (I));
        '                                                    Else
        '					x=0;
        '			}
        '			else
        '				x=1;
        '			x *=  Y[i];
        '			MatY[I] += x;
        '		}
        '	n=N;
        '	Inverse(&MatX,&MatX, &n);
        '	MatMultS(&MatX, MatY, MatA,  n,  &n);

        '	for(i=0; i<N; i++)
        '	{
        '		if (fabs(MatA[i])<(double) 0.00001 && fabs(MatA[i])>(double) 0.0)
        '			MatA[i] =(double) 0.0;
        '	}
        '}
        '*************************************************************
        Dim dblX As Double = 0.0
        Dim i, I1, intN As Integer
        Dim j, J1 As Integer

        Try
            'Calculate the Curve fitting
            For i = 0 To N - 1
                For j = 0 To N - 1
                    If (i <> 0 Or j <> 0) Then
                        MatX(i, j) = 0
                    End If
                Next
            Next

            For i = 0 To N - 1
                MatY(i) = 0.0
            Next

            For I1 = 0 To N - 1
                For J1 = 0 To N - 1
                    If ((I1 <> 0 Or J1 <> 0)) Then
                        For i = 0 To No - 1
                            dblX = Math.Pow(X(i), (I1 + J1))
                            MatX(I1, J1) += dblX
                        Next
                    End If
                Next
            Next

            For I1 = 0 To N - 1
                For i = 0 To No - 1
                    If (I1 <> 0) Then
                        If (X(i) <> 0.0) Then
                            dblX = Math.Pow(X(i), I1)
                        Else
                            dblX = 0
                        End If
                    Else
                        dblX = 1
                    End If
                    dblX *= Y(i)
                    MatY(I1) += dblX
                Next
            Next

            intN = N

            Call Inverse(MatX, MatX, intN)
            'MatX = MatrixOperations.FindInverseMatrix(MatX)
            ''inverse the matrix.
            Call MatMultS(MatX, MatY, MatA, intN, intN)

            For i = 0 To N - 1
                If (Math.Abs(MatA(i)) < 0.00001 And Math.Abs(MatA(i)) > 0.0) Then
                    MatA(i) = 0.0
                End If
            Next

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

    Private Function Calc_AbsDirect(ByVal dblX As Double) As Double
        '=====================================================================
        ' Procedure Name        : Calc_AbsDirect
        ' Parameters Passed     : X Value in Doub 
        ' Returns               : Abs in double
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 03-Feb-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================

        '****************************************************
        '---- ORIGINAL CODE
        '****************************************************
        'double	Calc_AbsDirect(double x)
        '{
        '	double x1=0.0, y1=0.0;
        '	double x2=0.0, y2=0.0, y=0;
        '	int	i;

        '	if (x>X[No-1])
        '		return -1;
        '	for(i=0;i<No; i++)
        '		if (x==X[i])
        '		{
        '			y=Y[i];
        '			break;
        '		}
        '                    If (i >= No) Then
        '	{
        '		if (Find_Between_Pts(x, 0.0, &x1, &y1,	&x2, &y2, FALSE))
        '                            If (X > 12) Then
        '				i=0;
        '                                If (x2! = x1) Then
        '				y = y1+ (y2-y1)*(x-x1)/(x2-x1);
        '	}
        '	return y;
        '}
        '****************************************************
        Dim x1, y1 As Double
        Dim x2, y2, dblY As Double
        Dim i As Integer

        Try
            x1 = 0.0
            y1 = 0.0
            x2 = 0.0
            y2 = 0.0
            dblY = 0

            If (dblX > X(No - 1)) Then
                Return -1
            End If

            For i = 0 To No - 1
                If (dblX = X(i)) Then
                    dblY = Y(i)
                    Exit For
                End If
            Next

            If (i >= No) Then
                If (Find_Between_Pts(dblX, 0.0, x1, y1, x2, y2, False)) Then
                    If (dblX > 12) Then
                        i = 0
                    End If
                End If
                If (x2 <> x1) Then
                    dblY = y1 + (y2 - y1) * (dblX - x1) / (x2 - x1)
                End If
            End If

            Return dblY

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

    Private Function Get_Conc1(ByVal y1 As Double, ByVal x11 As Double, ByVal xmax As Double) As Double
        '=====================================================================
        ' Procedure Name        : Get_Conc1
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 03-Feb-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================

        '********************************************************
        '---- ORIGINAL CODE
        '********************************************************
        'double	 Get_Conc1(double y1, double x11, double xmax)
        '{
        '	double x1=x11, y2=0.0;
        '        While (x1 < xmax)
        '	{
        '		y2 = Get_Abs(x1);
        '		if (y2<y1+0.0005 && y2>y1-0.0005 )
        '			break;
        '		x1+=(double) 0.0001;
        '	}
        '	return x1;
        '}
        '********************************************************
        Dim x1 As Double
        Dim y2 As Double

        Try
            x1 = x11

            While (x1 < xmax)
                y2 = Get_Abs(x1)
                If (y2 < y1 + 0.0005 And y2 > y1 - 0.0005) Then
                    Exit While
                End If
                x1 += 0.0001
            End While

            Return x1

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

    Private Function Return_InitalValue(ByVal y1 As Double, ByRef x1 As Double, ByRef x2 As Double) As Boolean
        '=====================================================================
        ' Procedure Name        : Return_InitalValue
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 03-Feb-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================

        '*********************************************************************
        '----- ORIGINAL CODE
        '*********************************************************************
        'BOOL Return_InitalValue(double y1, double *x1, double *x2)
        '{
        '	int	i,j, k;
        '	j=k=-1;
        '	for(i=0;i<No; i++)
        '	{
        '		if (y1>=Y[i])
        '		{
        '			j=i;
        '			break;
        '		}
        '	}
        '	for(i=0;i<No; i++)
        '	{
        '		if (y1<=Y[i])
        '		{
        '			k=i;
        '			break;
        '		}
        '	}
        '                        If (j >= 0) Then
        '		*x1=X[j];
        '                        Else
        '		*x1=0.0;
        '                            If (k >= 0) Then
        '		*x2=X[k];
        '                            Else
        '		*x2=X[No-1]+X[No-1]*0.2;

        '	if (*x1==*x2)
        '	{
        '                                    If (j < No - 1) Then
        '			*x2=X[j+1];
        '                                    Else
        '			return FALSE;
        '	}
        '	return TRUE;
        '}
        '*********************************************************************
        Dim i, j, k As Integer

        Try
            k = -1
            j = -1

            For i = 0 To No - 1
                If (y1 >= Y(i)) Then
                    j = i
                    Exit For
                End If
            Next

            For i = 0 To No - 1
                If (y1 <= Y(i)) Then
                    k = i
                    Exit For
                End If
            Next

            If (j >= 0) Then
                x1 = X(j)
            Else
                x1 = 0.0
            End If

            If (k >= 0) Then
                x2 = X(k)
            Else
                x2 = X(No - 1) + X(No - 1) * 0.2
            End If

            If (x1 = x2) Then
                If (j < No - 1) Then
                    x2 = X(j + 1)
                Else
                    Return False
                End If
            End If

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

    Private Sub FindMaxAbs(ByVal Abs() As Double, ByVal nStd As Integer)
        '=====================================================================
        ' Procedure Name        : FindMaxAbs
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : to find maximum of abs.
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 31-Jan-2007 11:00 am
        ' Revisions             : 1
        '=====================================================================

        '*****************************************************
        '---- ORIGINAL CODE
        '*****************************************************
        'void	FindMaxAbs(double *Abs,  int nStd)
        '{
        '	int	i;
        '	AbsMax=-1.0;
        '	for (i=0;i<nStd; i++){
        '		if (Abs[i]>AbsMax)
        '		AbsMax= Abs[i];
        '	}
        '}
        '*****************************************************
        Dim i As Integer

        Try
            AbsMax = -1.0

            For i = 0 To nStd - 1
                If (Abs(i) > AbsMax) Then
                    AbsMax = Abs(i)
                End If
            Next

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

    Private Sub InitMatrixData()
        '=====================================================================
        ' Procedure Name        : InitMatrixData
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : for initialization of matrix data.
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 31-Jan-2007 11:15 pm
        ' Revisions             : 1
        '=====================================================================

        '************************************************************
        '---- ORIGINAL CODE
        '************************************************************
        'void(InitMatrixData(void))
        '{
        '	int i;
        '	InitBufferMatrix(&MatX);
        '	for(i=0; i<MAX; i++)
        '		MatA[i]=MatY[i]=X[i]=Y[i]=(double) 0.0;;
        '}
        '************************************************************
        Dim i As Integer

        Try
            Call InitBufferMatrix(MatX)

            For i = 0 To MAX - 1
                'MatA[i]=MatY[i]=X[i]=Y[i]= 0.0;
                MatA(i) = 0.0
                MatY(i) = 0.0
                X(i) = 0.0
                Y(i) = 0.0
            Next

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

    Private Sub InitBufferMatrix(ByRef mt(,) As Double)
        '=====================================================================
        ' Procedure Name        : InitBufferMatrix
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 31-Jan-2007 11:15 pm
        ' Revisions             : 1
        '=====================================================================

        '************************************************************
        '---- ORIGINAL CODE
        '************************************************************
        'void InitBufferMatrix(DOUBLE *mt)
        '{
        '	int i,j;
        '	/* MatX[0][0]=9.0; MatX[0][1]=9.0;
        '	MatX[1][0]=8.0; MatX[1][1]=8.0;
        '	MatX[7][MAX-1]=7.0; MatX[7][MAX-2]=7.0;*/

        '   If (mt! = NULL) Then
        '	    for(i=0;i<MAX; i++)
        '		    for(j=0;j<MAX; j++)
        '			    mt[0][i][j]=(double) 0.0;
        '}
        '************************************************************
        Dim intCounter As Integer
        Dim arrValues As ArrayList
        Dim intTotalMatrixLength As Integer
        Dim i, j As Integer

        Try
            ReDim mt(MAX - 1, MAX - 1)

            'If Not IsNothing(mt) Then
            '    For i = 0 To MAX - 1
            '        For j = 0 To MAX - 1
            '            mt(i, j) = 0.0
            '        Next j
            '    Next i
            'End If

            ''arrValues = New ArrayList
            ''intTotalMatrixLength = MAX * MAX
            ''For intCounter = 0 To intTotalMatrixLength - 1
            ''    arrValues.Add(0.0)
            ''Next intCounter
            ''mt = MatrixOperations.GetMatrix(MAX, MAX, arrValues)

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

    Private Sub Copy_Matrix_Row(ByRef md() As Double, ByVal ms() As Double, _
                                       ByVal n As Integer, ByVal flag As Boolean)
        '=====================================================================
        ' Procedure Name        : Copy_Matrix_Row
        ' Parameters Passed     : 
        ' Returns               : None
        ' Purpose               : 
        ' Description           : for copy a matrix row.
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 31-Jan-2007 02:00 pm
        ' Revisions             : 1
        '=====================================================================

        '************************************************************
        '---- ORIGINAL CODE
        '************************************************************
        'void	Copy_Matrix_Row(double md[MAX], double ms[MAX], int n, BOOL flag)
        '{
        '   int i;
        '	for(i=0; i<n; i++)
        '       If (flag) Then
        '		    md[i]=ms[i];
        '       Else
        '		    md[i+1]=ms[i];
        '}
        '************************************************************
        Dim i As Integer

        Try
            For i = 0 To ms.Length - 1  'n - 1
                If flag Then
                    md(i) = ms(i)
                Else
                    md(i + 1) = ms(i)
                End If
            Next i

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

    Private Sub Contruct_matrix()
        '=====================================================================
        ' Procedure Name        : Contruct_matrix
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : for constructing a matrix
        ' Description           :
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 31-Jan-2007 02:10 pm
        ' Revisions             : 1
        '=====================================================================

        '*************************************************************
        '---- ORIGINAL CODE
        '*************************************************************
        'void(Contruct_matrix())
        '{
        '	int	i, j;

        '	for(i=0; i<N; i++)
        '	{
        '		for(j=0; j<N; j++)
        '			if (i==0 && j==0)
        '				MatX[i][0]=(double) No;

        '		MatX[i][j]=(double) i+j;
        '	}
        '	for(i=0; i<N; i++)
        '		MatA[i]= MatY[i] = i;
        '}
        '*************************************************************
        Dim i, j As Integer

        Try
            For i = 0 To N - 1
                For j = 0 To N - 1
                    If (i = 0 And j = 0) Then
                        MatX(i, 0) = No
                    End If
                Next
                MatX(i, j) = i + j
            Next

            For i = 0 To N - 1
                MatA(i) = i
                MatY(i) = i
            Next

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

    Private Sub MatMultS(ByVal mt1(,) As Double, ByVal mt2() As Double, _
                         ByRef mt3() As Double, ByVal n1 As Integer, ByRef n As Integer)
        '=====================================================================
        ' Procedure Name        : MatMultS
        ' Parameters Passed     : 
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 31-Jan-2007 03:15 pm
        ' Revisions             : 1
        '=====================================================================

        '***********************************************************
        '---- ORIGINAL CODE
        '***********************************************************
        'void MatMultS(DOUBLE *mt1, double mt2[MAX], double mt3[MAX], int n1,  int *n)
        '{
        '	double 	t=0.0;
        '	double 	tm[MAX];
        '	int   	i,k;

        '	for(i=0;i<MAX; i++)
        '		tm[i] = (double) 0.0;

        '	for (i=0; i<n1; i++)
        '	{
        '		t=0;
        '		for(k=0; k<n1; k++)
        '			t += (mt1[0][i][k])* mt2[k];

        '		tm[i] = t;
        '	}

        '	*n=n1;

        '	for(i=0; i<n1; i++)
        '		mt3[i]=tm[i];
        '}
        '***********************************************************
        Dim t As Double = 0.0
        Dim tm(MAX) As Double
        Dim i, k As Integer

        Try
            For i = 0 To MAX - 1
                tm(i) = 0.0
            Next

            For i = 0 To n1 - 1
                t = 0
                For k = 0 To n1 - 1
                    t += mt1(i, k) * mt2(k)
                Next
                tm(i) = t
            Next

            n = n1

            For i = 0 To n1 - 1
                mt3(i) = tm(i)
            Next

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

    Private Function sign(ByVal x As Double) As Boolean
        '=====================================================================
        ' Procedure Name        : sign
        ' Parameters Passed     : X co-ordinate
        ' Returns               : True or false
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 03-Feb-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        'BOOL sign(double x)
        '{
        '	if (x>=(double) 0.0)
        '		return TRUE;
        '	return FALSE;
        '}
        Try
            If (x >= 0.0) Then
                Return True
            End If

            Return False

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

    Private Function Fn(ByVal x1 As Double, ByVal y1 As Double) As Double
        '=====================================================================
        ' Procedure Name        : Fn
        ' Parameters Passed     : None
        ' Returns               : x1, y1 as Double
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 03-Feb-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        'double	Fn(double x1,double y1)
        '{
        'double y;
        ' y = Get_Abs(x1);
        ' y-=y1;
        'return y;
        '}

        Dim dblY As Double

        Try
            dblY = Get_Abs(x1)
            dblY -= y1

            Return dblY

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

    Private Function Calculte_Rat(ByVal dblX As Double) As Double
        '=====================================================================
        ' Procedure Name        : Calculte_Rat
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 03-Feb-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================

        '********************************************************
        '---- ORIGINAL CODE
        '********************************************************
        'double	Calculte_Rat(double x)
        '{
        '	double A=0.0, B=0.0,C=0.0, y=0.0;//, y1=0.0;
        '	if (x==0)
        '		return y;

        '	A = MatA[2];
        '	C = MatA[0];

        '	if (x!=(double) 0)
        '		B= MatA[1]-1.0/x;

        '	if (A!=(double) 0 && (B*B-4.0*A*C)>0)
        '	{
        '		y = (-B - sqrt(B*B-4.0*A*C))/(2.0*A);
        '		//y1= (-B + sqrt(B*B-4.0*A*C))/(2.0*A);
        '	}
        '                Else
        '#If STD_ADDN Then
        '			y = -1.0;
        '#Else
        '			y = 0;
        '#End If
        '	return y;
        '}
        '********************************************************
        Dim A, B, C, dblY As Double
        Try
            mblnSaturation = False
            If (dblX = 0) Then
                mblnSaturation = True
                Return dblY
            End If

            A = MatA(2)
            C = MatA(0)

            If (dblX <> 0) Then
                B = MatA(1) - 1.0 / dblX
            End If

            If (A <> 0 And (B * B - 4.0 * A * C) > 0) Then
                dblY = (-B - Math.Sqrt(B * B - 4.0 * A * C)) / (2.0 * A)

            Else
                If mblnIsStandardAddition Then
                    dblY = -1.0
                    mblnSaturation = True
                Else
                    dblY = 0
                    mblnSaturation = True
                End If
            End If

            Return dblY

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

    Private Function Find_Between_Pts(ByVal x As Double, ByVal y As Double, _
                                      ByRef x1 As Double, ByRef y1 As Double, _
                                      ByRef x2 As Double, ByRef y2 As Double, ByVal abs As Boolean) As Boolean
        '=====================================================================
        ' Procedure Name        : Find_Between_Pts
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 03-Feb-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================

        '************************************************************
        '----- ORIGINAL CODE
        '************************************************************
        'BOOL Find_Between_Pts(double x, double y, double *x1, double *y1, double *x2, double *y2, BOOL abs)
        '{
        '	int	i,j,k;
        '	j=k=-1;
        '	for(i=0;i<No; i++)
        '	{
        '       If (abs) Then
        '	    {
        '		    if (y<Y[i])
        '			{
        '				j=i-1;
        '				break;
        '			}
        '		}
        '       Else
        '		{
        '		    if (x<X[i])
        '			{
        '				j=i-1;
        '				break;
        '			}
        '		}
        '	}
        '	for(i=No-1;i>=0; i--)
        '	{
        '       If (abs) Then
        '		{
        '		    if (y>Y[i])
        '			{
        '				k=i+1;
        '				break;
        '			}
        '		}
        '       Else
        '		{
        '		    if (x>X[i])
        '			{
        '				k=i+1;
        '				break;
        '			}
        '		}
        '	}
        '   If (j >= 0) Then
        '	{
        '       If (x1) Then
        '		    *x1=X[j];
        '       If (y1) Then
        '		    *y1=Y[j];
        '   }
        '   Else
        '	{
        '       If (x1) Then
        '		    *x1=0.0;
        '       If (y1) Then
        '		    *y1=0.0;
        '   }
        '   If (k >= 0) Then
        '	{
        '       If (x2) Then
        '		    *x2=X[k];
        '       If (y2) Then
        '		    *y2=Y[k];
        '   }
        '   Else
        '	{
        '		k=No-1;
        '		if (x<X[0])
        '			k=0;
        '       If (x2) Then
        '			*x2=X[k]; //+100.0;
        '       If (y2) Then
        '			*y2=Y[k]; //+100.0;
        '	}
        '	if ( (abs && *x1==*x2) || (*y1==*y2))
        '	{
        '       If (j < No - 1) Then
        '		{
        '       If (x2) Then
        '				*x2=X[j+1];
        '       If (y2) Then
        '				*y2=Y[j+1];
        '		}
        '       Else
        '			return FALSE;
        '	}
        '	return TRUE;
        '}
        '************************************************************
        Dim i, j, k As Integer

        Try
            j = -1
            k = -1

            For i = 0 To No - 1
                If (abs) Then
                    If (y < Me.Y(i)) Then
                        j = i - 1
                        Exit For
                    End If
                Else
                    If (x < Me.X(i)) Then
                        j = i - 1
                        Exit For
                    End If
                End If
            Next

            For i = No - 1 To 0 Step -1
                If (abs) Then
                    If (y > Me.Y(i)) Then
                        k = i + 1
                        Exit For
                    End If
                Else
                    If (x > Me.X(i)) Then
                        k = i + 1
                        Exit For
                    End If
                End If
            Next

            'If (j >= 0) Then
            '    If (x1) Then
            '        x1 = Me.X(j)
            '    End If
            '    If (y1) Then
            '        y1 = Me.Y(j)
            '    End If
            'Else
            '    If (x1) Then
            '        x1 = 0.0
            '    End If
            '    If (y1) Then
            '        y1 = 0.0
            '    End If
            'End If

            'If (k >= 0) Then
            '    If (x2) Then
            '        x2 = Me.X(k)
            '    End If
            '    If (y2) Then
            '        y2 = Me.Y(k)
            '    End If
            'Else
            '    k = Me.No - 1
            '    If (x < Me.X(0)) Then
            '        k = 0
            '    End If
            '    If (x2) Then
            '        x2 = Me.X(k)
            '    End If
            '    If (y2) Then
            '        y2 = Me.Y(k)
            '    End If
            'End If
            '//----- Modified by Sachin on 18.09.07
            If (j >= 0) Then

                x1 = Me.X(j)


                y1 = Me.Y(j)
            Else

                x1 = 0.0


                y1 = 0.0

            End If

            If (k >= 0) Then

                x2 = Me.X(k)


                y2 = Me.Y(k)

            Else
                k = Me.No - 1
                If (x < Me.X(0)) Then
                    k = 0
                End If

                x2 = Me.X(k)

                y2 = Me.Y(k)

            End If
            '//-----

            If ((abs And x1 = x2) Or (y1 = y2)) Then
                If (j < Me.No - 1) Then
                    '//----- Modified by Sachin on 18.09.07
                    'If (x2) Then
                    '    x2 = Me.X(j + 1)
                    'End If
                    'If (y2) Then
                    '    y2 = Me.Y(j + 1)
                    'End If

                    x2 = Me.X(j + 1)
                    y2 = Me.Y(j + 1)

                    '//-----
                Else
                    Return False
                End If
            End If

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

    Private Function GetRawStdAddnConc(ByVal blnIsStandardAddition As Boolean) As Double
        '=====================================================================
        ' Procedure Name        : GetRawStdAddnConc
        ' Parameters Passed     : blnIsStandardAddition
        ' Returns               : Raw Standard Addition Conc.
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 04-Feb-2007 01:20 pm
        ' Revisions             : 1
        '=====================================================================

        '*******************************************************************
        '---- ORIGINAL CODE
        '*******************************************************************
        '#If STD_ADDN Then
        'E4FUNC double S4FUNC GetRawStdAddnConc( void )
        '{
        '	double c=0.0;
        '	if(MatA[1])
        '	{
        '		c = MatA[0]/MatA[1];
        '	}
        '	if( c < 0.0 )
        '		c = c * -1.0;
        '	return c;
        '}
        '#End If
        '*******************************************************************
        Dim dblConc As Double = 0.0

        Try
            If blnIsStandardAddition Then
                If (MatA(1)) Then
                    dblConc = MatA(0) / MatA(1)
                End If

                If (dblConc < 0.0) Then
                    dblConc = dblConc * -1.0
                End If

                Return dblConc
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
    End Function

    Private Function Inverse(ByRef mt As Double(,), ByRef tm As Double(,), ByRef n As Integer) As Double
        '=====================================================================
        ' Procedure Name        : Inverse
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 14-Feb-2007 06:05 pm
        ' Revisions             : 1
        '=====================================================================

        '*****************************************************
        '---- ORIGINAL CODE
        '*****************************************************
        'double Inverse(DOUBLE *mt, DOUBLE *tm, int *n)
        '{
        '	int 		i, j;
        '	double	val=1.0;
        '	DOUBLE 	*t=NULL;

        '	t = Allocate_Double();
        '	val = Inverse1(mt, t, *n);

        '	for(i=0; i<*n; i++)
        '		for(j=0; j<*n; j++)
        '			tm[0][i][j] = t[0][i][j];

        '	t =Free_Double(t);
        '	return val;
        '}
        '*****************************************************
        Dim i, j As Integer
        Dim val As Double = 1.0
        Dim t As Double(,)
        ' Use inverse matrix opration 
        Try
            Call InitBufferMatrix(t)

            val = Inverse1(mt, t, n)

            For i = 0 To n - 1
                For j = 0 To n - 1
                    tm(i, j) = t(i, j)
                Next
            Next

            't =Free_Double(t)
            t = Nothing

            Return val

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

    Private Function Inverse1(ByRef mt As Double(,), ByRef tm As Double(,), ByVal n As Integer) As Double
        '=====================================================================
        ' Procedure Name        : Inverse
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 14-Feb-2007 06:05 pm
        ' Revisions             : 1
        '=====================================================================

        '*****************************************************
        '---- ORIGINAL CODE
        '*****************************************************
        'double	Inverse1(DOUBLE *mt,DOUBLE *tm, int n)
        '{
        '	double 	val=0;
        '	int 	i, j;
        '	DOUBLE 	*t=NULL;

        '	t = Allocate_Double();
        '	val = Detm(mt, n);
        '	Adjoint(mt, t, n);

        '	if (val!=(double) 0)
        '		for (i=0; i<n; i++)
        '			for (j=0; j<n; j++)
        '			{
        '				tm[0][i][j] = t[0][i][j]/val;
        '			}
        '	t =Free_Double(t);
        '	return val;
        '}
        '*****************************************************
        Dim i, j As Integer
        Dim val As Double = 1.0
        Dim t As Double(,)

        Try
            Call InitBufferMatrix(t)

            val = Detm(mt, n)

            Call Adjoint(mt, t, n)

            If (val <> 0) Then
                For i = 0 To n - 1
                    For j = 0 To n - 1
                        tm(i, j) = t(i, j) / val
                    Next
                Next
            End If

            't =Free_Double(t);
            t = Nothing

            Return val

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

    Private Function Detm(ByRef mt(,) As Double, ByVal n As Integer) As Double
        '=====================================================================
        ' Procedure Name        : Detm
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 14-Feb-2007 06:20 pm
        ' Revisions             : 1
        '=====================================================================

        '*****************************************************
        '---- ORIGINAL CODE
        '*****************************************************
        'double 	Detm(DOUBLE *mt, int n )
        '{
        '	return Detm1(mt, n);
        '}
        '*****************************************************
        Try
            Return Detm1(mt, n)

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

    Private Function Detm1(ByVal mt(,) As Double, ByVal n As Integer) As Double
        '=====================================================================
        ' Procedure Name        : Detm1
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 14-Feb-2007 06:20 pm
        ' Revisions             : 1
        '=====================================================================

        '*****************************************************
        '---- ORIGINAL CODE
        '*****************************************************
        'double 	Detm1(DOUBLE  *mt, int n )
        '{
        '	int   	i;
        '	double 	sum=0;
        '	DOUBLE 	*t=NULL;

        '	if (n==1) return mt[0][0][0];
        '	else if (n==2) return(Det2(mt));
        '        Else
        '	{
        '		t = Allocate_Double();
        '            If (t! = NULL) Then
        '		{
        '			for (i=0; i<n; i++)
        '			{
        '				Make_minor(mt, t, 0, i, n, NULL);
        '				sum +=( one(i,0)* (mt[0][0][i]) * Detm1(t, n-1));
        '			}
        '			t = Free_Double(t);
        '		}
        '		else
        '			ErrorMsg();
        '	}
        '	return sum;
        '}
        '*****************************************************
        Dim i As Integer
        Dim sum As Double = 0
        Dim t(,) As Double

        Try
            If (n = 1) Then
                Return mt(0, 0)
            ElseIf (n = 2) Then
                Return Det2(mt)
            Else
                Call InitBufferMatrix(t)

                If Not IsNothing(t) Then
                    For i = 0 To n - 1
                        Make_minor(mt, t, 0, i, n, Nothing)
                        sum += (one(i, 0) * (mt(0, i)) * Detm1(t, n - 1))
                    Next
                    t = Nothing
                Else
                    'ErrorMsg();
                    'MessageBox(hpar, "floating point error", "ERROR", MB_OK);
                    MessageBox.Show("floating point error", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

            Return sum

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

    Private Sub Adjoint(ByVal mt(,) As Double, ByRef tm(,) As Double, ByVal n As Integer)
        '=====================================================================
        ' Procedure Name        : Adjoint
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 14-Feb-2007 06:20 pm
        ' Revisions             : 1
        '=====================================================================

        '*****************************************************
        '---- ORIGINAL CODE
        '*****************************************************
        'void  	Adjoint(DOUBLE *mt, DOUBLE *tm, int n)
        '{
        '	double	 val=0.0;
        '	DOUBLE 	*t=NULL;
        '	DOUBLE 	*t1=NULL;
        '	int 		i, j, n1;

        '	t = Allocate_Double();
        '	t1 = Allocate_Double();

        '	for (i=0; i<n; i++)
        '		for (j=0; j<n; j++)
        '			t1[0][i][j]= mt[0][i][j];

        '	for (i=0; i<n; i++)
        '		for (j=0; j<n; j++)
        '		{
        '			Make_minor(t1, t, i, j, n, &n1);
        '           If (n1! = 1) Then
        '			{
        '				val=Detm(t, n1);
        '				tm[0][i][j]=one(i, j)*val;
        '			}
        '           Else
        '				tm[0][i][j]=one(i, j)* (t[0][0][0]);
        '			val = 0.0;
        '		}

        '	for (i=0; i<n; i++)
        '		for (j=i; j<n; j++)
        '		{
        '			if (i==j) continue;
        '			val= tm[0][i][j];
        '			tm[0][i][j]=tm[0][j][i];
        '			tm[0][j][i]=val;
        '		}

        '	t = Free_Double(t);
        '	t1 =Free_Double(t1);
        '}
        '*****************************************************
        Dim val As Double = 0.0
        Dim t(,) As Double
        Dim t1(,) As Double
        Dim i, j, n1 As Integer

        Try
            Call InitBufferMatrix(t)
            Call InitBufferMatrix(t1)

            For i = 0 To n - 1
                For j = 0 To n - 1
                    t1(i, j) = mt(i, j)
                Next
            Next

            For i = 0 To n - 1
                For j = 0 To n - 1
                    Call Make_minor(t1, t, i, j, n, n1)
                    If (n1 <> 1) Then
                        val = Detm(t, n1)
                        tm(i, j) = one(i, j) * val
                    Else
                        tm(i, j) = one(i, j) * t(0, 0)
                    End If
                    val = 0.0
                Next
            Next

            For i = 0 To n - 1
                For j = i To n - 1
                    If (i = j) Then GoTo Continue
                    val = tm(i, j)
                    tm(i, j) = tm(j, i)
                    tm(j, i) = val
Continue:
                Next
            Next

            t = Nothing
            t1 = Nothing

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

    Private Function one(ByVal i As Integer, ByVal j As Integer) As Double
        '=====================================================================
        ' Procedure Name        : one
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 14-Feb-2007 06:59 pm
        ' Revisions             : 1
        '=====================================================================
        'double  	one(int i, int j)
        '{
        '	int k;
        '	double val=-1.0;

        '	for (k=0; k<=i+j; k++)
        '		val *= (double) -1.0;

        '	return val;
        '}

        Dim k As Integer
        Dim val As Double = -1.0

        Try
            For k = 0 To i + j
                val *= -1.0
            Next

            Return val

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

    Private Sub Make_minor(ByVal mt(,) As Double, ByRef t(,) As Double, _
                           ByVal i As Integer, ByVal j As Integer, _
                           ByVal n As Integer, ByRef n1 As Integer)
        '=====================================================================
        ' Procedure Name        : Make_minor
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 14-Feb-2007 06:59 pm
        ' Revisions             : 1
        '=====================================================================

        '*********************************************************
        '---- ORIGINAL CODE
        '*********************************************************
        'void Make_minor(DOUBLE *mt, DOUBLE *t,int i, int j, int n, int *n1)
        '{
        '	int k, l, a, b;
        '	for (k=0,a=0; k<n; k++,a++)
        '		for (l=0, b=0; l<n; l++, b++)
        '		{
        '			if (k==i) k++;
        '			if (l==j) l++;
        '			if (l<n && k<n)
        '				t[0][a][b] = mt[0][k][l];
        '		}

        '   If (n1! = NULL) Then
        '		*n1=n-1;
        '}
        '*********************************************************
        Dim k, l, a, b As Integer

        Try
            a = 0
            For k = 0 To n - 1
                b = 0
                For l = 0 To n - 1
                    If (k = i) Then k += 1
                    If (l = j) Then l += 1
                    If (l < n And k < n) Then
                        t(a, b) = mt(k, l)
                    End If
                    b += 1
                Next l
                a += 1
            Next k

            If Not IsNothing(n1) Then
                n1 = n - 1
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

    Private Function Det2(ByRef mt(,) As Double) As Double
        '=====================================================================
        ' Procedure Name        : Det2
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 14-Feb-2007 06:59 pm
        ' Revisions             : 1
        '=====================================================================

        '*******************************************************
        '----- ORIGINAL CODE
        '*******************************************************
        'double  Det2(DOUBLE *mt)
        '{
        '	double val=0, temp=0;;
        '	val= (mt[0][0][0]);
        '	val*= (mt[0][1][1]);
        '	temp= (mt[0][1][0]);
        '	temp*= (mt[0][0][1]);
        '	val-=temp;
        '	return val;
        '}
        '*******************************************************
        Dim val As Double = 0
        Dim temp As Double = 0

        Try
            val = mt(0, 0)
            val *= mt(1, 1)
            temp = mt(1, 0)
            temp *= mt(0, 1)
            val -= temp

            Return val

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
