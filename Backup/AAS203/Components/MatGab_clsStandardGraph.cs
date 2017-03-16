using AAS203.Common;
using AAS203Library;
using AAS203Library.Method;
using AAS203Library.Method.clsQuantitativeData;
//this are like header file.

public class clsStandardGraph
{
	//**********************************************************************
	// File Header       
	// File Name 		:   clsStandardGraph.vb
	// Author			:   Mangesh Shardul
	// Date/Time			:   18-Jan-2007 10:30 am
	// Description		:   Class to draw the AAS Sample or Standard Working graph
	// Assumptions       :	gobjNewMethod object should filled fullyand properly
	// Dependencies      :   (gobjNewMethod.) A global object of AAS203Library.Method.clsMethod
	//                       in this AAS203 Project.
	//**********************************************************************

	#Region " Private Class Member Variables "

	//#If STD_ADDN Then
	//BOOL stdaddn = FALSE;
	//#End If
	//int		N=1, No=3;
	//BOOL		rational=FALSE;
	//int		CalcUsedTotStd = 0;
	//Private stdaddn As Boolean
	//BOOL SampCurve = FALSE;
	//double	err[FIFTH_ORDER+1]={1000.0, 1000.0, 1000.0,1000.0, 1000.0, 1000.0};
	//typedef	double	DOUBLE[MAX][MAX];
	//Public [DOUBLE](,) As Double

	private int CalcUsedTotStd;

	private bool SampCurve;
	private double[] X = new double[MAX - 2];

	private double[] Y = new double[MAX - 2];
	private double[,] MatX;

	private double[] MatY = new double[MAX - 2];
	private int mintRunNumberIndex;
	private int No = 3;

	private double AbsMax = -1.0;

	private clsMethod mobjClsMethod = new clsMethod();
	#End Region

	#Region " Public Class Member Variables "

	public bool mblnIsStandardAddition;
	public bool Rational;
	public int N = 1;
	public double[] MatA = new double[MAX - 2];
	public bool Curve_Status = false;
	//Public err() As Double = {1000.0, 1000.0, 1000.0, 1000.0, 1000.0, 1000.0}
	public double[] err = {
		0.0,
		0.0,
		0.0,
		0.0,
		0.0,
		0.0
		//By pankaj on 25 Aug 07
	};
		#End Region
	public bool mblnSaturation = false;

	#Region " Public Constants, Enums, Structures .. "

	//#define	MAXSTD		15
	//#define	MAXSAMP		200
	//#define	MAXREPEAT	15
	//#define	MAXACC		8
	//#define	MAX		MAXSTD+1
	//#define	ZERO_PASSING	TRUE 

	public const int MAXSTD = 15;
	public const int MAXSAMP = 200;
	public const int MAXREPEAT = 15;
	public const int MAXACC = 8;
	public const int MAX = MAXSTD + 1;

	public const bool ZERO_PASSING = true;
	#End Region

	#Region " Constructors "

	public clsStandardGraph()
	{
		//=====================================================================
		// Procedure Name        : New [Constructor]
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

	#Region " Public Functions "

	public bool Create_Standard_Sample_Curve(bool blnIsSampleIn, bool blnIsAnalysisModeIn, int intSelectedMethodID, int intSelectedRunNumber, ref clsMethod objNewMethod)
	{
		//=====================================================================
		// Procedure Name        : Create_Standard_Sample_Curve
		// Parameters Passed     : Flag to draw Standard or Sample Graph
		// Returns               : True or false
		// Purpose               : To show the Standard or Sample Graph
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================

		//*************************************************
		//--- ORIGINAL CODE
		//*************************************************
		//BOOL Create_Standard_Sample_Curve(HWND hpar, BOOL sampflag)
		//{
		//	DLGPROC  skp1;
		//	int		n1;
		//	int		lmode;
		//	BOOL		flag=FALSE;
		//	int		nstds;

		//	if (Method->QuantData==NULL)
		//		return FALSE;

		//#If STD_ADDN Then
		//		SetStdAddnFlag(Method->QuantData->Param.Std_Addn);
		//#End If

		//	if(!CheckValidStdAbsEntry(Method->QuantData->StdTopData))
		//	{
		//		Gerror_message_new("Abs of the standards are not in increasing order", "Std Error");
		//		return flag;
		//	}

		//	if ((GetTotStds(Method->QuantData->StdTopData, TRUE))>0)
		//	{
		//		n1 = GetTotStdAnalysed(Method->QuantData->StdTopData);

		//		if ( Method->QuantData->cMode < DIRECT ||  n1 != CalcUsedTotStd )
		//			Method->QuantData->cMode = GetBestFit();

		//		lmode=Method->QuantData->cMode;

		//		nstds = GetNoValidStdConcAbs(Method->QuantData->StdTopData);

		//		skp1 =(DLGPROC) MakeProcInstance((DLGPROC) CurveProc,hInst);

		//#If STD_ADDN Then
		//			if(Method->QuantData->Param.Std_Addn)
		//				SampCurve=FALSE;
		//			else
		//				SampCurve=sampflag;
		//#Else
		//			SampCurve=sampflag;
		//#End If

		//		DialogBox(hInst,"CURVE", hpar, skp1);
		//		FreeProcInstance(skp1);

		//		if (lmode!=Method->QuantData->cMode || nstds != GetNoValidStdConcAbs(Method->QuantData->StdTopData))
		//			flag=TRUE;

		//	}
		//   Else
		//		Gerror_message_new("No Standards", "STANDARD CURVE");

		//	return flag;
		//}
		//*************************************************
		frmStandardGraph objfrmStandardSampleGraph;
		int n1;
		int lmode;
		bool flag;
		int nstds;

		try {
			// Check process is under analysis to hold the method object.
			if (blnIsAnalysisModeIn) {
				mobjClsMethod = gobjNewMethod;
			} else {
				mobjClsMethod = objNewMethod.Clone;
			}

			// seek  the Run No.
			if (blnIsAnalysisModeIn) {
				if (IsNothing(mobjClsMethod)) {
					return false;
				}
				//---For Analysis Mode
				if (mobjClsMethod.QuantitativeDataCollection.Count > 0) {
					mintRunNumberIndex = mobjClsMethod.QuantitativeDataCollection.Count - 1;
				} else {
					mintRunNumberIndex = 0;
				}
			} else {
				//---For Data Files Mode
				mintRunNumberIndex = gfuncGetSelectedMethodRunNumberIndex(intSelectedMethodID, intSelectedRunNumber);
			}

			//Set  Standard Addition flag to this object
			if (mobjClsMethod.StandardAddition) {
				SetStdAddnFlag(mobjClsMethod.StandardAddition);
			}
			// Check the standard Abs entnty into increasing order and validate it else return it
			if (!CheckValidStdAbsEntry(mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection)) {
				//MessageBox.Show("Abs of the standards are not in increasing order", "Std Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
				return flag;
			}
			// Get the total no of standards
			if (GetTotStds(mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection, true) > 0) {
				// Get the total no of standards which is analysised
				n1 = GetTotStdAnalysed(mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection);

				//if ( Method->QuantData->cMode < DIRECT ||  n1 != CalcUsedTotStd )
				//   Method->QuantData->cMode = GetBestFit()
				//end if
				//lmode=Method->QuantData->cMode


				//If blnIsAnalysisModeIn Then
				// Set the best fitted calculation mode
				if ((mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).CalculationMode < enumCalculationMode.DIRECT | n1 != CalcUsedTotStd)) {
					mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).CalculationMode = GetBestFit(false);
				}
				//End If
				//29.04.08
				if (blnIsAnalysisModeIn == false) {
					if (gintCalcMode != 100) {
						mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).CalculationMode = gintCalcMode;
					}
				}



				lmode = mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).CalculationMode;
				// get no of valid std. conc. and Abs.
				nstds = GetNoValidStdConcAbs(mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection);
				//skp1 =(DLGPROC) MakeProcInstance((DLGPROC) CurveProc,hInst)

				//#if STD_ADDN
				if ((mobjClsMethod.StandardAddition)) {
					SampCurve = false;
				} else {
					SampCurve = blnIsSampleIn;
				}
				//#else
				//   SampCurve = sampflag
				//#End If

				//DialogBox(hInst,"CURVE", hpar, skp1)
				//FreeProcInstance(skp1)
				// Set the Std/Samp Graph  form.
				objfrmStandardSampleGraph = new frmStandardGraph(blnIsSampleIn, blnIsAnalysisModeIn, mobjClsMethod, intSelectedRunNumber);
				objfrmStandardSampleGraph.ShowDialog();
				Application.DoEvents();

				int intMethodCounter;
				for (intMethodCounter = gobjMethodCollection.Count - 1; intMethodCounter >= 0; intMethodCounter += -1) {
					if (intSelectedMethodID == gobjMethodCollection.item(intMethodCounter).MethodID) {
						gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection(mintRunNumberIndex).CalculationMode = objfrmStandardSampleGraph.mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).CalculationMode;
						if (blnIsAnalysisModeIn) {
							gobjNewMethod.QuantitativeDataCollection(mintRunNumberIndex).CalculationMode = objfrmStandardSampleGraph.mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).CalculationMode;
						} else {
							objNewMethod.QuantitativeDataCollection(mintRunNumberIndex).CalculationMode = objfrmStandardSampleGraph.mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).CalculationMode;
							gintCalcMode = objfrmStandardSampleGraph.mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).CalculationMode;
							//29.04.08
						}
						break; // TODO: might not be correct. Was : Exit For
					}
				}
				objfrmStandardSampleGraph.Close();
				objfrmStandardSampleGraph.Dispose();
				objfrmStandardSampleGraph = null;
			////----- Added by Sachin Dokhale


			////-----
			//if (lmode!=Method->QuantData->cMode || nstds != GetNoValidStdConcAbs(Method->QuantData->StdTopData))
			//   flag=TRUE
			//end if
			} else {
				gobjMessageAdapter.ShowMessage(constNoStandards);
				Application.DoEvents();
			}

			return flag;

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

	public int GetNoValidStdConcAbs(Method.clsAnalysisStdParametersCollection objStandardData)
	{
		//=====================================================================
		// Procedure Name        : GetNoValidStdConcAbs
		// Parameters Passed     : Standard Data Collection 
		// Returns               : No. of Valid Total Standards
		// Purpose               : Return Valid standards
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================

		//********************************************************************
		//--- ORIGINAL CODE
		//********************************************************************
		//int S4FUNC	GetNoValidStdConcAbs(STDDATA   *StdTop)
		//{
		//	STDDATA   *tempk=NULL;
		//	int		 tot=0;

		//	tempk =StdTop;
		//   While (tempk! = NULL)
		//	{
		//		if (tempk->Data.Used)
		//			tot++;
		//		tempk=tempk->next;
		//	}
		//	return tot;
		//}
		//********************************************************************
		int intTotalStandards;
		int intCounter;

		try {
			// Return total no of valid standards 
			for (intCounter = 0; intCounter <= objStandardData.Count - 1; intCounter++) {
				if (objStandardData.item(intCounter).Used) {
					intTotalStandards += 1;
				}
			}

			return intTotalStandards;

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

	public double Get_Conc(double y1, double xinitial)
	{
		//=====================================================================
		// Procedure Name        : Get_Conc
		// Parameters Passed     : Y-Value as double, Initial X-Value
		// Returns               : Conc. Value in Double
		// Purpose               : Return Conc. value
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 03-Feb-2007 02:25 pm
		// Revisions             : 1
		//=====================================================================

		//*****************************************************
		//---- ORIGINAL CODE
		//*****************************************************
		//E4FUNC  double	S4FUNC  Get_Conc(double y1, double xinitial) //, int acc)
		//{
		//	//char	str[80]="";
		//	double x1=0.0;
		//        If (!Curve_Status) Then
		//		return -1.0;
		//	if (N==0)
		//		x1=Calc_ConcDirect(y1);
		//            ElseIf (rational) Then
		//		x1=GetConcRational(y1);
		//            Else
		//		x1= Regula_falsei(y1, xinitial, X[No-1]);//xmax);
		//		//x1 = GetResultAccurate(x1, acc);
		//	/*--------------------------
		//	//following condition removed by sss on dt 27.12.2K for storing the actual conc of the sample if sample goes out off scale
		//                If (y1 > AbsMax + AbsMax * 0.05) Then
		//		x1=(double) 0.0;
		//	----------------------------	*/
		//	if (x1<(double) 0)
		//		x1=(double) 0.0;
		//	return x1;
		//}
		//*****************************************************
		double x1;

		try {
			// Return the concentration value into the respect of X value(Abs).
			if (!(Curve_Status)) {
				return -1.0;
			}

			//---changed by Deepak on 19.10.10 to solve a bug (different conc for same abs reported by vck)
			y1 = FormatNumber(y1, 3);
			//-----------------------

			if ((N == 0)) {
				x1 = Calc_ConcDirect(y1);
			} else if ((Rational)) {
				x1 = GetConcRational(y1);
			} else {
				x1 = Regula_falsei(y1, xinitial, X(No - 1));
			}

			if ((x1 < 0)) {
				x1 = 0.0;
			}

			return x1;

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

	public void Calculate_Std_Curve()
	{
		//=====================================================================
		// Procedure Name        : Calculate_Std_Curve
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : Calculate Standard Curve
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 18-Jan-2007 03:45 pm
		// Revisions             : 1
		//=====================================================================

		//************************************************************
		//---- ORIGINAL CODE
		//************************************************************
		//void(Calculate_Std_Curve(void))
		//{
		//	double 	*abs=NULL;
		//	double 	*conc=NULL;
		//	int		i;
		//	STDDATA	*tempk;

		//	CalcUsedTotStd = GetTotStds(Method->QuantData->StdTopData, TRUE);
		//	abs = (double *) malloc(sizeof(double) *(CalcUsedTotStd+1));

		//	if (abs==NULL)
		//		return;
		//	conc= (double *) malloc(sizeof(double) *(CalcUsedTotStd+1));

		//	if (conc==NULL)
		//	{
		//		free(abs); abs=NULL; return;
		//	}
		//	i=0;
		//	tempk = Method->QuantData->StdTopData;

		//                While (tempk)
		//	{
		//                    If (i < CalcUsedTotStd) Then
		//		{
		//			if (tempk->Data.Used)
		//			{
		//				abs[i]=tempk->Data.Abs;
		//				conc[i]=tempk->Data.Conc;
		//				i++;
		//			}
		//		}
		//		tempk=tempk->next;
		//	}

		//#If STD_ADDN Then
		//		if(Method->QuantData->Param.Std_Addn)
		//			Calculate_Curve(abs, conc,CalcUsedTotStd, Method->QuantData->cMode, !ZERO_PASSING);
		//		else
		//			Calculate_Curve(abs, conc,CalcUsedTotStd, Method->QuantData->cMode, ZERO_PASSING);
		//#Else
		//		Calculate_Curve(abs, conc,CalcUsedTotStd, Method->QuantData->cMode, ZERO_PASSING);
		//#End If

		//	free(abs);
		//	abs=NULL;
		//	free(conc);
		//	conc=NULL;
		//	CalcSampValues();
		//}
		//************************************************************
		//double 	*abs=NULL;
		//double 	*conc=NULL;
		//int		i;
		//STDDATA	*tempk;
		double[] abs;
		double[] conc;
		int i;

		try {
			//get total std. from std. collection object
			CalcUsedTotStd = GetTotStds(mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection, true);
			//abs = (double *) malloc(sizeof(double) *(CalcUsedTotStd+1));
			 // ERROR: Not supported in C#: ReDimStatement

			// ReDim abs(CalcUsedTotStd) 'By Sachin on 18.09.07

			if (IsNothing(abs))
				return;

			//conc= (double *) malloc(sizeof(double) *(CalcUsedTotStd+1));
			 // ERROR: Not supported in C#: ReDimStatement

			// ReDim conc(CalcUsedTotStd) 'By Sachin on 18.09.07

			if (IsNothing(conc)) {
				abs = null;
				return;
			}
			i = 0;
			int j = 0;
			//   Fill the array for Abs and Conc.
			for (i = 0; i <= mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count - 1; i++) {
				if (j < CalcUsedTotStd) {
					if (mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(i).Used) {
						abs(j) = mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(i).Abs;
						conc(j) = mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(i).Concentration;
						j += 1;
					}
				}
			}

			//#If STD_ADDN Then
			//   if(Method->QuantData->Param.Std_Addn)
			//	    Calculate_Curve(abs, conc,CalcUsedTotStd, Method->QuantData->cMode, !ZERO_PASSING);
			//	else
			//	    Calculate_Curve(abs, conc,CalcUsedTotStd, Method->QuantData->cMode, ZERO_PASSING);
			//#Else
			//	    Calculate_Curve(abs, conc,CalcUsedTotStd, Method->QuantData->cMode, ZERO_PASSING);
			//#End If
			// Calculate curve for given calculation mode on standards
			if (mobjClsMethod.StandardAddition) {
				Calculate_Curve(abs, conc, CalcUsedTotStd, mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).CalculationMode, (!ZERO_PASSING));
			} else {
				Calculate_Curve(abs, conc, CalcUsedTotStd, mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).CalculationMode, (ZERO_PASSING));
			}
			// Calculate the sample value on measured curve 
			CalcSampValues(mobjClsMethod.StandardAddition);

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

	public void CalcSampValues(bool blnIsSTD_ADDN)
	{
		//=====================================================================
		// Procedure Name        : CalcSampValues
		// Parameters Passed     : Standard Addition Flag
		// Returns               : None
		// Purpose               : Calculate Sample values
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 18-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================

		//**********************************************************
		//---- ORIGINAL CODE
		//**********************************************************
		//#If STD_ADDN Then
		//extern SAMPDATA	*CurSamp;

		//void	CalcSampValues(void)
		//{
		//	SAMPDATA	*tempk1;
		//	tempk1 = Method->QuantData->SampTopData;
		//	if( Method->QuantData->Param.Std_Addn)
		//	{
		//		if(tempk1)
		//		{
		//			tempk1->Data.Conc = GetRawStdAddnConc();
		//			tempk1->Data.Abs = 0.0;
		//			tempk1->Data.Used = TRUE;
		//			tempk1=tempk1->next;
		//			CurSamp = NULL;
		//		}
		//		while(tempk1)
		//		{
		//			tempk1->Data.Conc=Get_Conc(tempk1->Data.Abs, 0.0);
		//			tempk1=tempk1->next;
		//		}
		//	}
		//	else
		//	{
		//		while(tempk1)
		//		{
		//			tempk1->Data.Conc=Get_Conc(tempk1->Data.Abs, 0.0);
		//			/*		if (tempk1->Data.Conc>0 &&tempk1->Data.Abs>-0.1)
		//			tempk1->Data.Used=TRUE;*/
		//			tempk1=tempk1->next;
		//		}
		//	}
		//}
		//#Else

		//void(CalcSampValues(void))
		//{
		//	SAMPDATA	*tempk1;
		//	tempk1 = Method->QuantData->SampTopData;
		//        While (tempk1)
		//	{
		//		tempk1->Data.Conc=Get_Conc(tempk1->Data.Abs, 0.0);
		//		/*	if (tempk1->Data.Conc>0 &&tempk1->Data.Abs>-0.1)
		//			tempk1->Data.Used=TRUE;*/
		//		tempk1=tempk1->next;
		//	}
		//}
		//#End If

		//**********************************************************
		int intCounter;

		try {
			//Calculate the sample value on standard value
			//Check for Stanard Addition flag
			if (blnIsSTD_ADDN) {
				if ((mobjClsMethod.StandardAddition)) {
					if (mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count > 0) {
						if (!IsNothing(mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(0))) {
							mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(0).Conc = GetRawStdAddnConc(mobjClsMethod.StandardAddition);
							mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(0).Abs = 0.0;
							mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(0).Used = true;
						}
					}
					// Get Conc. value
					for (intCounter = 1; intCounter <= mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count - 1; intCounter++) {
						mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Conc = Get_Conc(mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Abs, 0.0);
					}
				} else {
					// Get Conc. value
					for (intCounter = 0; intCounter <= mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count - 1; intCounter++) {
						mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Conc = Get_Conc(mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Abs, 0.0);
					}
				}
			} else {
				// Get Conc. value
				for (intCounter = 0; intCounter <= mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count - 1; intCounter++) {
					mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Conc = Get_Conc(mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Abs, 0.0);
				}
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

	public bool IsStdCurve()
	{
		//=====================================================================
		// Procedure Name        : IsStdCurve
		// Parameters Passed     : None
		// Returns               : Return Curve status 
		// Purpose               : Return Curve status
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 31-Jan-2007 04:50 pm
		// Revisions             : 1
		//=====================================================================

		//*****************************************************
		//---- ORIGINAL CODE
		//*****************************************************
		//E4FUNC  BOOL	S4FUNC  IsStdCurve(void)
		//{
		//   return Curve_Status;
		//}
		//*****************************************************
		try {
			//return Curve status of selected curve (it is Standard Addition/not)
			return Curve_Status;

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

	public double Get_Abs(double x)
	{
		//=====================================================================
		// Procedure Name        : Get_Abs
		// Parameters Passed     : x
		// Returns               : Return Abs value
		// Purpose               : Return Abs value
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 03-Feb-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================

		//******************************************
		//---- ORIGINAL CODE
		//******************************************
		//#if STD_ADDN  
		//E4FUNC  double	S4FUNC  Get_Abs(double x)
		//{
		//	double y=0.0;
		//	int 	i;
		//   If (!Curve_Status) Then
		//	    return -1.0;
		//   If (x > 1.0) Then
		//	    i=0;
		//	if (N==0)
		//	{
		//		y=Calc_AbsDirect(x);
		//	}
		//   Else
		//	{
		//       If (rational) Then
		//		    y = Calculte_Rat(x);
		//       Else
		//		{
		//			if (x==(double)0.0 & !stdaddn)
		//				y= MatA[0];
		//           Else
		//				for(i=0; i<N; i++)
		//				{
		//					if( i == 0 )
		//						y+=(MatA[i]* 1.0);
		//                   Else
		//						y+=(MatA[i]* pow(x,i));
		//				}
		//		}
		//	}
		//	return y;
		//}
		//#else
		//E4FUNC  double	S4FUNC  Get_Abs(double x)
		//{
		//	double y=0.0;
		//	int 	i;

		//        If (!Curve_Status) Then
		//		return -1.0;

		//            If (x > 1.0) Then
		//		i=0;

		//	if (N==0)
		//	{
		//		y=Calc_AbsDirect(x);
		//	}
		//                Else
		//	{
		//                    If (rational) Then
		//			y = Calculte_Rat(x);
		//                    Else
		//		{
		//			if (x==(double)0.0)
		//				y= MatA[0];
		//                        Else
		//				for(i=0; i<N; i++)
		//					y+=(MatA[i]* pow(x,i));
		//		}
		//	}
		//	return y;
		//}
		//#end If
		//******************************************
		try {
			// Get the abs value
			if (mblnIsStandardAddition) {
				double dbly;
				int i;

				if (!(Curve_Status)) {
					return -1.0;
				}

				if ((x > 1.0)) {
					i = 0;
				}

				if ((N == 0)) {
					dbly = Calc_AbsDirect(x);
				} else {
					if ((Rational)) {
						dbly = Calculte_Rat(x);

					} else {
						if ((x == 0.0 & !mblnIsStandardAddition)) {
							dbly = MatA(0);
						} else {
							for (i = 0; i <= N - 1; i++) {
								if ((i == 0)) {
									dbly += (MatA(i) * 1.0);
								} else {
									dbly += (MatA(i) * Math.Pow(x, i));
								}
							}
						}

					}
				}

				return dbly;

			} else {
				//----
				double dbly;
				int i;

				if (!(Curve_Status)) {
					return -1.0;
				}

				if ((x > 1.0)) {
					i = 0;
				}

				if ((N == 0)) {
					dbly = Calc_AbsDirect(x);
				} else {
					if ((Rational)) {
						dbly = Calculte_Rat(x);
					} else {
						if ((x == 0.0)) {
							dbly = MatA(0);
						} else {
							for (i = 0; i <= N - 1; i++) {
								dbly += (MatA(i) * Math.Pow(x, i));
							}
						}
					}
				}

				return dbly;
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

	public double GetInterval(double Max, double Min, int TotData, bool flag)
	{
		//=====================================================================
		// Procedure Name        : GetInterval
		// Parameters Passed     : Max,Min,TotData, flag
		// Returns               : Return Intervals
		// Purpose               : Return Interval
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 31-Jan-2007 05:00 pm
		// Revisions             : 1
		//=====================================================================

		//************************************************************
		//----- ORIGINAL CODE
		//************************************************************
		//E4FUNC  double		S4FUNC GetInterval(double Max, double Min, int TotData, BOOL flag)
		//{
		//	double  x1;
		//	int i;

		//	for (i=1; i<=4; i++)
		//	{
		//		x1= GetInterval_val(Max, Min, i, TotData, flag);
		//		if (x1 != (double) -1.0)
		//			break;
		//	}

		//	if (x1 == (double) -1.0)
		//		x1 = ((Max - Min)/(double)10.0);

		//	return x1;
		//}
		//************************************************************
		double x1;
		int i;

		try {
			//Get the interval
			for (i = 1; i <= 4; i++) {
				x1 = GetInterval_val(Max, Min, i, TotData, flag);
				if ((x1 != -1.0)) {
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			if ((x1 == -1.0)) {
				x1 = (Max - Min) / 10.0;
			}

			return x1;

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

	public void subSaveAbsConcValue(clsMethod objClsMethod, int intRunNumberIndex)
	{
		//=====================================================================
		// Procedure Name        : subSaveAbsConcValue
		// Parameters Passed     : Current Method object and Run Number 
		// Returns               : None
		// Purpose               : Save the Abs and Concentration into the collection object
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 11-May-2007 04:35 pm
		// Revisions             : 1
		//=====================================================================
		int n1;

		try {
			// Save the Abs and Concentration into the collection object
			if (GetTotStds(objClsMethod.QuantitativeDataCollection.Item(intRunNumberIndex).StandardDataCollection, true) > 0) {
				n1 = GetTotStdAnalysed(objClsMethod.QuantitativeDataCollection.Item(intRunNumberIndex).StandardDataCollection);

				if ((objClsMethod.QuantitativeDataCollection.Item(intRunNumberIndex).CalculationMode < enumCalculationMode.DIRECT | n1 != CalcUsedTotStd)) {
					objClsMethod.QuantitativeDataCollection.Item(intRunNumberIndex).CalculationMode = GetBestFit(true);
				}
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

	#End Region

	#Region " Public Shared Functions "

	public static int GetTotStds(Method.clsAnalysisStdParametersCollection objStandardData, bool blnIsCheckUsed)
	{
		//=====================================================================
		// Procedure Name        : GetTotStds
		// Parameters Passed     : Standard Data Collection, boolean flag
		// Returns               : No. of Valid Total Standards
		// Purpose               : getting a total num of std.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================

		//********************************************************************
		//--- ORIGINAL CODE
		//********************************************************************
		//int		S4FUNC	GetTotStds(STDDATA   *StdTop, BOOL flag)
		//{
		//STDDATA   *tempk=NULL;
		//int		 tot=0;
		// tempk =StdTop;
		// while(tempk!=NULL){
		//	 if (flag){
		//		if (tempk->Data.Used)
		//		 tot++;
		//	  }
		//                Else
		//	  tot++;
		//	 tempk=tempk->next;
		//  }
		// return tot;
		//}
		//********************************************************************
		int intTotalStandards;
		int intCounter;

		try {
			for (intCounter = 0; intCounter <= objStandardData.Count - 1; intCounter++) {
				if (blnIsCheckUsed) {
					if (objStandardData.item(intCounter).Used) {
						//'data structure for std.
						intTotalStandards += 1;
					}
				} else {
					intTotalStandards += 1;
				}
			}

			return intTotalStandards;

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

	public static int GetTotStdAnalysed(Method.clsAnalysisStdParametersCollection objStandardData)
	{
		//=====================================================================
		// Procedure Name        : GetTotStdAnalysed
		// Parameters Passed     : Standard Data Collection
		// Returns               : No. of Analysed Total Standards
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================

		//********************************************************************
		//--- ORIGINAL CODE
		//********************************************************************
		//int		S4FUNC	GetTotStdAnalysed(STDDATA   *StdTop)
		//{
		//STDDATA   *tempk=NULL;
		//int		 tot=0;

		// tempk =StdTop;
		// while(tempk!=NULL){
		//	 if (tempk->Data.Abs>=-0.2)
		//	   tot++;
		//	 tempk=tempk->next;
		// }
		// return tot;
		//}
		//********************************************************************
		int intTotalStandards;
		int intCounter;

		try {
			for (intCounter = 0; intCounter <= objStandardData.Count - 1; intCounter++) {
				if ((objStandardData.item(intCounter).Abs >= -0.2)) {
					intTotalStandards += 1;
				}
			}

			return intTotalStandards;

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

	public static int FindSamplesAnalysed(clsMethod objClsMethod, int intSelectedRunNumberIndex)
	{
		//=====================================================================
		// Procedure Name        : FindSamplesAnalysed
		// Parameters Passed     : clsMethod, intSelectedRunNumberIndex
		// Returns               : Integer
		// Purpose               : Total No sample
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 09-Mar-2007 07:55 pm
		// Revisions             : 1
		//=====================================================================

		//**************************************************************
		//----ORIGINAL CODE
		//**************************************************************
		//int FindSamplesAnalysed(void)
		//{
		//	int	  samples=0;
		//	STDDATA 		*curstd=NULL;
		//	SAMPDATA 	*cursamp=NULL;

		//	curstd  =	Method->QuantData->StdTopData;
		//	cursamp = Method->QuantData->SampTopData;

		//   If (CurStd! = NULL) Then
		//	{
		//       While (curstd)
		//		{
		//			if (curstd==CurStd)
		//				break;
		//			if (curstd->Data.Used)
		//				samples++;
		//			curstd=curstd->next;
		//		}
		//	}
		//   Else
		//		samples = GetTotStdAnalysed(curstd);
		//	if(Method->QuantData->Param.Std_Addn)
		//	{
		//       If (cursamp) Then
		//		{
		//           If (cursamp! = CurSamp) Then
		//			{
		//				if (cursamp->Data.Used)
		//					samples++;
		//			}
		//		}
		//	}
		//   Else
		//	{
		//       While (cursamp)
		//		{
		//			if (cursamp==CurSamp)
		//				break;
		//			if (cursamp->Data.Used)
		//				samples++;
		//			cursamp=cursamp->next;
		//		}
		//	}
		//	return samples;
		//}
		//**************************************************************
		int samples = 0;
		AAS203Library.Method.clsAnalysisStdParametersCollection curstd;
		AAS203Library.Method.clsAnalysisSampleParametersCollection cursamp;
		int intCounter;

		try {
			// Validate the total no Samples from given Sample collection
			curstd = objClsMethod.QuantitativeDataCollection.Item(intSelectedRunNumberIndex).StandardDataCollection.Clone;
			cursamp = objClsMethod.QuantitativeDataCollection.Item(intSelectedRunNumberIndex).SampleDataCollection.Clone;

			//IsNothing(gobjNewMethod.QuantitativeDataCollection(gobjNewMethod.QuantitativeDataCollection.Count - 1).StandardDataCollection) Then
			if (!IsNothing(curstd)) {
				for (intCounter = 0; intCounter <= curstd.Count - 1; intCounter++) {
					//If (curstd Is gobjNewMethod.QuantitativeDataCollection(gobjNewMethod.QuantitativeDataCollection.Count - 1).StandardDataCollection) Then
					//    Exit For
					//End If
					if (curstd.item(intCounter).Used) {
						samples += 1;
					}
				}
			} else {
				samples = GetTotStdAnalysed(curstd);
			}

			if ((objClsMethod.StandardAddition)) {
				if (!IsNothing(cursamp)) {
					//'If (cursamp != CurSamp) Then
					//If (cursamp.item(0).Used) Then
					//    samples += 1
					//End If
					//'end if 
				}
			} else {
				if (!IsNothing(cursamp)) {
					for (intCounter = 0; intCounter <= cursamp.Count - 1; intCounter++) {
						//If (cursamp Is gobjNewMethod.QuantitativeDataCollection(gobjNewMethod.QuantitativeDataCollection.Count - 1).SampleDataCollection) Then
						//    Exit For
						//End If
						if (cursamp.item(intCounter).Used) {
							samples += 1;
						}
					}
				}
			}

			return samples;

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

	public static double FindMaxStdConc(AAS203Library.Method.clsAnalysisStdParametersCollection objStandardData)
	{
		//=====================================================================
		// Procedure Name        : FindMaxStdConc
		// Parameters Passed     : clsAnalysisStdParametersCollection
		// Returns               : double
		// Purpose               : Find the Maximum standard Conc. from given object
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 31-Jan-2007 05:35 pm
		// Revisions             : 1
		//=====================================================================

		//**********************************************************
		//----- ORIGINAL CODE
		//**********************************************************
		//double	S4FUNC	FindMaxStdConc(STDDATA   *StdTop)
		//{
		//   double	max=-1000.0;
		//	STDDATA   *tempk=NULL;
		//	tempk =StdTop;
		//   While (tempk! = NULL)
		//	{
		//	    if (max<tempk->Data.Conc)
		//		    max = tempk->Data.Conc;
		//		tempk=tempk->next;
		//	}
		//	return max;
		//}
		//**********************************************************
		double max = -1000.0;
		int intCounter;

		try {
			// Search the Maximum standard Conc. from given object
			for (intCounter = 0; intCounter <= objStandardData.Count - 1; intCounter++) {
				if (max < objStandardData.item(intCounter).Concentration) {
					max = objStandardData.item(intCounter).Concentration;
				}
			}

			return max;

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

	public static double FindMaxStdAbs(AAS203Library.Method.clsAnalysisStdParametersCollection objStandardData)
	{
		//=====================================================================
		// Procedure Name        : FindMaxStdAbs
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : Find the Maximum standard ABS. from given object
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 31-Jan-2007 05:35 pm
		// Revisions             : 1
		//=====================================================================

		//**********************************************************
		//----- ORIGINAL CODE
		//**********************************************************
		//double	S4FUNC	FindMaxStdAbs(STDDATA   *StdTop)
		//{
		//   double	max=-1000.0;
		//	STDDATA   *tempk=NULL;
		//	tempk =StdTop;
		//   While (tempk! = NULL)
		//	{
		//	    if (max<tempk->Data.Abs)
		//		    max = tempk->Data.Abs;
		//		tempk=tempk->next;
		//	}
		//	return max;
		//}
		//**********************************************************
		double max = -1000.0;
		int intCounter;

		try {
			// Searchthe Maximum standard Abs. from given object
			for (intCounter = 0; intCounter <= objStandardData.Count - 1; intCounter++) {
				if (max < objStandardData.item(intCounter).Abs) {
					max = objStandardData.item(intCounter).Abs;
				}
			}

			return max;

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

	public static int GetTotStdsInBetweenConc(double conc1, double conc2, AAS203Library.Method.clsAnalysisStdParametersCollection objStandardData, bool blnCheckUsed)
	{
		//=====================================================================
		// Procedure Name        : GetTotStdsInBetweenConc
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : to find a total num of std in bet the passed conc.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================

		//*******************************************************
		//---- ORIGINAL CODE
		//*******************************************************
		//int S4FUNC GetTotStdsInBetweenConc(double conc1, double conc2, STDDATA   *StdTop, BOOL flag)
		//{
		//	STDDATA   *tempk=NULL;
		//	int		 tot=0;

		//	tempk =StdTop;
		//        While (tempk! = NULL)
		//	{
		//            If (flag) Then
		//		{
		//			if (tempk->Data.Used)
		//			{
		//				if (tempk->Data.Conc>=conc1 && tempk->Data.Conc<=conc2)
		//					tot++;
		//			}
		//		}
		//		else if (tempk->Data.Conc>=conc1 && tempk->Data.Conc<=conc2)
		//			tot++;
		//		tempk=tempk->next;
		//	}
		//	return tot;
		//}
		//*******************************************************
		int intTotalStandards;
		int intCounter;

		try {

			for (intCounter = 0; intCounter <= objStandardData.Count - 1; intCounter++) {
				if (blnCheckUsed) {
					if ((objStandardData.item(intCounter).Used)) {
						if ((objStandardData.item(intCounter).Concentration >= conc1 & objStandardData.item(intCounter).Concentration <= conc2)) {
							intTotalStandards += 1;
						}
					}

				} else if ((objStandardData.item(intCounter).Concentration >= conc1 & objStandardData.item(intCounter).Concentration <= conc2)) {
					intTotalStandards += 1;
				}

			}

			return intTotalStandards;

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

	public static bool CheckValidStdAbsEntry(Method.clsAnalysisStdParametersCollection objStandardData)
	{
		//=====================================================================
		// Procedure Name        : CheckValidStdAbsEntry
		// Parameters Passed     : objStandardData
		// Returns               : None
		// Purpose               : for validation of std abs .
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		//BOOL CheckValidStdAbsEntry( STDDATA *std) // this fn added by sss for checking the valid std used or not dt 30/11/2K
		//{
		//double abs=0.0;
		//BOOL   flag = TRUE;
		//if(std){
		//	if(std->Data.Used==1){
		//		abs = std->Data.Abs;
		//		std = std=std->next;
		//	}
		//}
		//while(std){
		//	  if(std->Data.Used==1){
		//		  if( std->Data.Abs <= abs ){
		//				flag = FALSE;
		//				Gerror_message_new("Abs of the standard is less than or equal to the previous standard", "Standards");
		//				return flag;
		//		  }
		//		  abs = std->Data.Abs;
		//	  }
		//	  std=std->next;
		//}
		//return flag;
		//}

		//*****************************
		//---CODE BY MANGESH
		//*****************************
		double abs = 0.0;
		bool flag = true;
		int intCounter;
		bool FirstUsed = false;

		try {

			for (intCounter = 0; intCounter <= objStandardData.Count - 1; intCounter++) {
				if ((objStandardData(intCounter).Used == true)) {
					//Added By Pankaj on 07 Jun 07
					if ((FirstUsed == false)) {
						abs = objStandardData(intCounter).Abs;
						FirstUsed = true;
					} else {
						//---------------------
						if ((objStandardData(intCounter).Abs <= abs)) {
							flag = false;
							gobjMessageAdapter.ShowMessage(constStandardAbsorbance);
							//'show the mess
							Application.DoEvents();
							//'allow application to perfrom it panding work.
							return false;
						}
						abs = objStandardData(intCounter).Abs;
					}
				}
			}

			return flag;
		//'return flag as true or false.

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

	public static bool CheckValidStdAbsEntry(Method.clsAnalysisStdParameters objStandardData)
	{
		//=====================================================================
		// Procedure Name        : CheckValidStdAbsEntry
		// Parameters Passed     : objStandardData
		// Returns               : None
		// Purpose               : for validation of std abs .
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		//BOOL CheckValidStdAbsEntry( STDDATA *std) // this fn added by sss for checking the valid std used or not dt 30/11/2K
		//{
		//double abs=0.0;
		//BOOL   flag = TRUE;
		//if(std){
		//	if(std->Data.Used==1){
		//		abs = std->Data.Abs;
		//		std = std=std->next;
		//	}
		//}
		//while(std){
		//	  if(std->Data.Used==1){
		//		  if( std->Data.Abs <= abs ){
		//				flag = FALSE;
		//				Gerror_message_new("Abs of the standard is less than or equal to the previous standard", "Standards");
		//				return flag;
		//		  }
		//		  abs = std->Data.Abs;
		//	  }
		//	  std=std->next;
		//}
		//return flag;
		//}

		//*****************************
		//---CODE BY MANGESH
		//*****************************
		double abs = 0.0;
		bool flag = true;
		int intCounter;

		try {
			//For intCounter = 0 To objStandardData.Count - 1
			//    If (objStandardData(intCounter).Used = True) Then
			//        If (objStandardData(intCounter).Abs <= abs) Then
			//            flag = False
			//            Call gobjMessageAdapter.ShowMessage("Abs of the standard is less than or equal to the previous standard", "Standards", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
			//            Call Application.DoEvents()
			//            Return False
			//        End If
			//        abs = objStandardData(intCounter).Abs
			//    End If
			//Next

			//---this function is written by deepak on 02.04.07

			if ((objStandardData.Used == true)) {
				if ((objStandardData.Abs <= abs)) {
					flag = false;
					gobjMessageAdapter.ShowMessage(constStandardAbsorbance);
					Application.DoEvents();
					return false;
				}
				abs = objStandardData.Abs;
			}

			return flag;

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

	public static bool CheckValidSampAbsEntry(Method.clsAnalysisStdParametersCollection objStandardData, double dblSampConc)
	{
		//=====================================================================
		// Procedure Name        : CheckValidSampAbsEntry
		// Parameters Passed     : objSampleData
		// Returns               : None
		// Purpose               : for validation of sample abs .
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 04.02.09
		//=====================================================================
		//BOOL CheckValidSampAbsEntry( STDDATA *std,double sampconc) 
		//{
		//double abs=0.0;
		//BOOL   flag = TRUE;
		//abs=GetMaxStdAbs(std);
		//If ((abs) < sampconc) Then
		//flag = FALSE;
		//return flag;
		//}
		//=====================================================================
		double abs = 0.0;
		bool flag = true;
		try {
			abs = FindMaxStdAbs(objStandardData);

			//---type cast and format on 03.07.09
			if ((FormatNumber((double)abs, 3) < (double)dblSampConc)) {
				flag = false;
			}

			return flag;
		//'return a flag for true or false
		//'for validation state.

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

	public static bool CheckValidSampAbsEntry(Method.clsAnalysisSampleParametersCollection objSampleData, double dblSampConc)
	{
		//=====================================================================
		// Procedure Name        : CheckValidSampAbsEntry
		// Parameters Passed     : objSampleData
		// Returns               : None
		// Purpose               : for validation of sample abs .
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 
		//=====================================================================
		//BOOL CheckValidSampAbsEntry( STDDATA *std,double sampconc) 
		//{
		//double abs=0.0;
		//BOOL   flag = TRUE;
		//abs=GetMaxStdAbs(std);
		//If ((abs) < sampconc) Then
		//flag = FALSE;
		//return flag;
		//}
		//=====================================================================
		double abs = 0.0;
		bool flag = true;

		try {
			abs = GetMaxSampleAbs(objSampleData);

			if (((abs) < dblSampConc)) {
				flag = false;
			}

			return flag;
		//'return a flag for true or false
		//'for validation state.

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

	public static bool CheckValidSampAbsEntry(Method.clsAnalysisSampleParameters objSampleData, double dblSampConc)
	{
		//=====================================================================
		// Procedure Name        : CheckValidSampAbsEntry
		// Parameters Passed     : objSampleData
		// Returns               : None
		// Purpose               : for validation of sample abs .
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		//the function is written by deepak on 02.05.07
		double abs = 0.0;
		bool flag = true;

		try {
			abs = GetMaxSampleAbs(objSampleData);

			if (((abs) < dblSampConc)) {
				flag = false;
			}

			return flag;

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

	public static double GetMaxSampleAbs(Method.clsAnalysisSampleParametersCollection objSampleData)
	{
		//=====================================================================
		// Procedure Name        : GetMaxSampleAbs
		// Parameters Passed     : clsAnalysisSampleParameters
		// Returns               : double
		// Purpose               : Find the Maximum standard Conc. from given object
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 31-Jan-2007 05:35 pm
		// Revisions             : 1
		//=====================================================================

		//double GetMaxStdAbs(STDDATA *std)
		//{
		//double Abs=0.0;
		//while(std){
		//	  if(std->Data.Used==1){
		//		  if( std->Data.Abs >= Abs )
		//				Abs = std->Data.Abs;
		//	  }
		//	  std=std->next;
		//}
		//return Abs;
		//}

		//********************
		//---CODE BY MANGESH 
		//********************
		double Abs;
		int intCounter;

		try {
			for (intCounter = 0; intCounter <= objSampleData.Count - 1; intCounter++) {
				if ((objSampleData.item(intCounter).Used == 1)) {
					if ((objSampleData.item(intCounter).Abs >= Abs)) {
						Abs = objSampleData.item(intCounter).Abs;
					}
				}
			}

			return Abs;

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

	public static double GetMaxSampleAbs(Method.clsAnalysisSampleParameters objSampleData)
	{
		//=====================================================================
		// Procedure Name        : GetMaxSampleAbs
		// Parameters Passed     : clsAnalysisSampleParameters
		// Returns               : double
		// Purpose               : Find the Maximum standard Conc. from given object
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 31-Jan-2007 05:35 pm
		// Revisions             : 1
		//=====================================================================
		//double GetMaxStdAbs(STDDATA *std)
		//{
		//double Abs=0.0;
		//while(std){
		//	  if(std->Data.Used==1){
		//		  if( std->Data.Abs >= Abs )
		//				Abs = std->Data.Abs;
		//	  }
		//	  std=std->next;
		//}
		//return Abs;
		//}
		//the function is sritten by deepak on 02.05.07
		double Abs;
		int intCounter;

		try {
			if ((objSampleData.Used == 1)) {
				if ((objSampleData.Abs >= Abs)) {
					Abs = objSampleData.Abs;
				}
			}

			return Abs;

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

	#Region " Private Functions "

	private double Calc_ConcDirect(double dblY)
	{
		//=====================================================================
		// Procedure Name        : Calc_ConcDirect
		// Parameters Passed     : Y-Value
		// Returns               : Conc. Value in double
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 03-Feb-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================

		//****************************************************
		//---- ORIGINAL CODE
		//****************************************************
		//double	Calc_ConcDirect(double y)
		//{
		//	double x1=0.0, y1=0.0;
		//	double x2=0.0, y2=0.0, x=0;
		//	int	i;

		//	if (y>Y[No-1])
		//		return -1.0;

		//	for(i=0;i<No; i++)
		//		if (y==Y[i])
		//		{
		//			x=X[i];
		//			break;
		//		}
		//                    If (i >= No) Then
		//		{
		//			if (Find_Between_Pts(0.0, y, &x1, &y1, &x2, &y2, TRUE))
		//                            If (y2! = y1) Then
		//					x = x1+ (x2-x1)*(y-y1)/(y2-y1);
		//		}
		//	return x;
		//}
		//****************************************************
		double x1;
		double y1;
		double x2;
		double y2;
		double dblX;
		int i;

		try {
			if ((dblY > Y(No - 1))) {
				return -1.0;
			}
			////----- Commented by Sachin Dokhale on 16.09.07
			//For i = 0 To No - 1
			//    If (dblY = Y(i)) Then
			//        dblX = X(i)
			//        Exit For
			//    End If
			//    If (i >= No) Then
			//        If (Find_Between_Pts(0.0, dblY, x1, y1, x2, y2, True)) Then
			//            If (y2 <> y1) Then
			//                dblX = x1 + (x2 - x1) * (dblY - y1) / (y2 - y1)
			//            End If
			//        End If
			//    End If
			//Next
			////-----
			for (i = 0; i <= No - 1; i++) {
				if ((dblY == Y(i))) {
					//Return dblX = X(i)
					return X(i);
					//Exit For
				}
			}

			if ((i >= No)) {
				//If (dblY <= Y(i)) Then
				if ((Find_Between_Pts(0.0, dblY, x1, y1, x2, y2, true))) {
					if ((y2 != y1)) {
						dblX = x1 + (x2 - x1) * (dblY - y1) / (y2 - y1);
					}
				}
			}

			return dblX;

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

	private double GetConcRational(double y1)
	{
		//=====================================================================
		// Procedure Name        : GetConcRational
		// Parameters Passed     : Y1 as double
		// Returns               : Conc. value in Double 
		// Purpose               : used for getting a conc rational.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 03-Feb-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================

		//********************************************************
		//---- ORIGINAL CODE
		//********************************************************
		//double  GetConcRational(double	y1)
		//{
		//	double	x1=0.0;
		//	x1=(MatA[0]+MatA[1]*y1+MatA[2]*y1*y1);
		//        If (x1! = 0.0) Then
		//		x1 = y1/x1;
		//        Else
		//		x1=0.0;
		//	return x1;
		//}
		//********************************************************
		double x1;

		try {
			x1 = (MatA(0) + MatA(1) * y1 + MatA(2) * y1 * y1);

			if ((x1 != 0.0)) {
				x1 = y1 / x1;
			} else {
				x1 = 0.0;
			}

			return x1;

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

	private double Regula_falsei(double y11, double xinitial, double xmax)
	{
		//=====================================================================
		// Procedure Name        : Regula_falsei
		// Parameters Passed     : y1, Initial X, XMax values
		// Returns               : Conc in Double
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 03-Feb-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================

		//***********************************************************
		//----- ORIGINAL CODE
		//***********************************************************
		//double	Regula_falsei(double y11, double xinitial, double xmax)
		//{
		//	double 	eps=0.000001, x1=-10000.0, x2=10000.0;
		//	double	x3=0.0, y1=0.0, y2=0.0, y3=0.0,dx=0.0;
		//	int		k, max=200;
		//	BOOL		sat=FALSE;

		//	if (!Return_InitalValue(y11, &x1, &x2))
		//		return Get_Conc1(y11, xinitial, xmax);

		//	y1 = Fn(x1, y11);
		//	y2 = Fn(x2, y11);

		//	for(k=1;k<max; k++)
		//	{
		//		if ((y2-y1) !=(double) 0.0)
		//			dx = y2*(x2-x1)/(y2-y1);
		//                Else
		//			dx=0.0;
		//		x3 = x2-dx;
		//		y3 = Fn(x3, y11);
		//		if (y3==(double) 0.0)
		//			sat=TRUE;
		//		else if (sign(y2)==sign(y3))
		//		{
		//			x2=x3;
		//			y2=y3;
		//		}
		//                    Else
		//		{
		//			x1=x3;
		//			y1=y3;
		//		}
		//		if (fabs(y3)<eps) //fabs(dx)<delta&&
		//			sat=TRUE;
		//                            If (sat) Then
		//			break;
		//	}
		//	return x3;
		//}
		//***********************************************************
		double eps;
		double x1;
		double x2;
		double x3;
		double y1;
		double y2;
		double y3;
		double dx;
		int k;
		int max;
		bool sat;

		try {
			eps = 1E-06;
			x1 = -10000.0;
			x2 = 10000.0;
			max = 200;

			if (!(Return_InitalValue(y11, x1, x2))) {
				return Get_Conc1(y11, xinitial, xmax);
			}

			y1 = Fn(x1, y11);
			y2 = Fn(x2, y11);

			for (k = 1; k <= max - 1; k++) {
				if (((y2 - y1) != 0.0)) {
					dx = y2 * (x2 - x1) / (y2 - y1);
				} else {
					dx = 0.0;
				}

				x3 = x2 - dx;
				y3 = Fn(x3, y11);

				if ((y3 == 0.0)) {
					sat = true;
				} else if ((sign(y2) == sign(y3))) {
					x2 = x3;
					y2 = y3;
				} else {
					x1 = x3;
					y1 = y3;
				}
				if ((Math.Abs(y3) < eps)) {
					sat = true;
					if ((sat)) {
						break; // TODO: might not be correct. Was : Exit For
					}
				}
			}

			return x3;

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

	private double GetInterval_val(double Max, double Min, double Kv, int TotData, bool flag)
	{
		//=====================================================================
		// Procedure Name        : GetInterval_val
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : get a interval bet given parameter.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 31-Jan-2007 05:15 pm
		// Revisions             : 1
		//=====================================================================

		//********************************************************
		//---- ORIGINAL CODE
		//********************************************************
		//double	GetInterval_val(double Max, double Min, int Kv, int TotData,BOOL flag)
		//{
		//   double	offa[]={ 0.001,  0.002,  0.005, 0.01, 0.02, 0.05, 0.1,   0.2,   0.5,
		//					  1.0,    2.0,    5.0,   10.0, 20.0, 50.0, 100.0, 200.0, 500.0,
		//					  1000.0, 2000.0, 5000.0, 10000.0, 20000.0, 50000.0};

		//	#define MAXEN	24
		//	#define INTST	9

		//	double	x=0.0;
		//	int i, k, NClass;

		//	if (TotData==0)
		//		return (double) 1.0;

		//	x = (double)1.0 + (double)3.322 * log10((double)TotData);

		//	NClass = (int) floor(x + (double)0.5);

		//            If (flag) Then
		//		i = 0;
		//            Else
		//		i = INTST;

		//	for(; i<MAXEN; i++)
		//	{
		//		x =  (Max-Min);
		//		k = (int) (x / offa[i]);

		//		if (k >= NClass-Kv && k <= NClass+Kv)
		//			break;
		//	}

		//                        If (i < MAXEN) Then
		//		x = offa[i];
		//                        Else
		//		x = (double)-1.0;
		//	return x;
		//}
		//********************************************************
		double[] offa = {
			0.001,
			0.002,
			0.005,
			0.01,
			0.02,
			0.05,
			0.1,
			0.2,
			0.5,
			1.0,
			2.0,
			5.0,
			10.0,
			20.0,
			50.0,
			100.0,
			200.0,
			500.0,
			1000.0,
			2000.0,
			5000.0,
			10000.0,
			20000.0,
			50000.0
		};

		const object MAXEN = 24;
		const object INTST = 9;

		double x = 0.0;
		int i;
		int k;
		int NClass;

		try {
			////----- Added by Sachin DOkhale on 21.05.07
			//If (TotData = 0) Then
			//    Return 1.0
			//End If
			if ((TotData <= 0)) {
				return 1.0;
			}
			////-----

			x = 1.0 + 3.322 * Math.Log10(TotData);

			NClass = (int)Math.Floor(x + 0.5);

			if ((flag)) {
				i = 0;
			} else {
				i = INTST;
			}

			for (i = 0; i <= MAXEN - 1; i++) {
				x = Max - Min;
				k = (int)x / offa(i);
				if ((k >= NClass - Kv & k <= NClass + Kv)) {
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			if ((i < MAXEN)) {
				x = offa(i);
			} else {
				x = -1.0;
			}

			return x;

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

	private void SetStdAddnFlag(bool flag)
	{
		//=====================================================================
		// Procedure Name        : SetStdAddnFlag
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : to get a std addtion flag.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 31-Jan-2007 05:15 pm
		// Revisions             : 1
		//=====================================================================
		//E4FUNC void S4FUNC SetStdAddnFlag(BOOL flag)
		//{
		//stdaddn = flag;
		//        If (flag) Then
		//	rational=FALSE;
		//}
		try {
			mblnIsStandardAddition = flag;

			if (flag) {
				Rational = false;
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

	private enumCalculationMode GetBestFit(bool blnIsSilent)
	{
		//=====================================================================
		// Procedure Name        : GetBestFit
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : for getting a best fit curve
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================

		//***********************************************************
		//---- ORIGINAL CODE
		//***********************************************************
		//int GetBestFit (void)
		//{
		//	double 	*abs=NULL;
		//	double 	*conc=NULL;
		//	int		i;
		//	STDDATA	*tempk;
		//	HWND		hwnd;
		//	HDC		hdc;
		//	HCURSOR	curs;

		//	curs = Load_Curs();

		//	hwnd = Create_Window(NULL, 250, 100, " Automatic Curve fit");
		//	hdc= GetDC(hwnd);

		//	SetTextColor(hdc, RGB(192,192,192));
		//	Gprintf(hdc,10, 10," Wait ... Automatically ");
		//	Gprintf(hdc,10, 25," Generating Best ");
		//	Gprintf(hdc,10, 40," Standard Working graph ...");

		//	ReleaseDC(hwnd, hdc);

		//	CalcUsedTotStd = GetTotStds(Method->QuantData->StdTopData, TRUE);

		//	abs = (double *) malloc(sizeof(double) *(CalcUsedTotStd+1));

		//	if (abs==NULL)
		//		return DIRECT;

		//	conc= (double *) malloc(sizeof(double) *(CalcUsedTotStd+1));

		//	if (conc==NULL)
		//	{
		//		free(abs);
		//		abs=NULL;
		//		return DIRECT;
		//	}

		//	i=0;
		//	tempk = Method->QuantData->StdTopData;

		//                While (tempk)
		//	{
		//                    If (i < CalcUsedTotStd) Then
		//		{
		//			if (tempk->Data.Used)
		//			{
		//				abs[i]=tempk->Data.Abs;
		//				conc[i]=tempk->Data.Conc;
		//				i++;
		//			}
		//		}
		//		tempk=tempk->next;
		//	}
		//#If STD_ADDN Then
		//		if( Method->QuantData->Param.Std_Addn)
		//			i = LINEAR;
		//		else
		//			i = Get_Best_Out_Of_Curve(abs, conc,CalcUsedTotStd);
		//#Else
		//		i = Get_Best_Out_Of_Curve(abs, conc,CalcUsedTotStd);
		//#End If

		//	free(abs);
		//	abs=NULL;
		//	free(conc);
		//	conc=NULL;

		//	Close_Window(hwnd, NULL);
		//	SetCursor(curs);

		//	return i;
		//}
		//***********************************************************
		CWaitCursor objWaitCursor = new CWaitCursor();
		double[] abs;
		double[] conc;
		int intCount;
		//STDDATA	*tempk;
		//HWND		hwnd;
		//HDC		hdc;
		//HCURSOR	curs;

		try {
			//curs = Load_Curs();
			//hwnd = Create_Window(NULL, 250, 100, " Automatic Curve fit");
			//hdc= GetDC(hwnd);
			//SetTextColor(hdc, RGB(192,192,192));
			//Gprintf(hdc,10, 10," Wait ... Automatically ");
			//Gprintf(hdc,10, 25," Generating Best ");
			//Gprintf(hdc,10, 40," Standard Working graph ...");
			//ReleaseDC(hwnd, hdc);

			string strWaitMessage;
			strWaitMessage = " Please Wait..." + "";
			strWaitMessage += vbCrLf + " Automatically Generating the";
			strWaitMessage += vbCrLf + " Best Standard Working graph...";
			//'set a strinf to be displayed during process
			if (!blnIsSilent) {
				gobjMessageAdapter.ShowStatusMessageBox(strWaitMessage, "Automatic Curve fit", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 1000);
				//'show a mess of automaticllay curve fitting.
			}

			CalcUsedTotStd = GetTotStds(mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection, true);
			//'for getting a total number of std.
			//abs = (double *) malloc(sizeof(double) *(CalcUsedTotStd+1));
			 // ERROR: Not supported in C#: ReDimStatement


			if (IsNothing(abs))
				return enumCalculationMode.DIRECT;

			//conc= (double *) malloc(sizeof(double) *(CalcUsedTotStd+1));
			 // ERROR: Not supported in C#: ReDimStatement


			if (IsNothing(conc)) {
				abs = null;
				return enumCalculationMode.DIRECT;
			}

			for (intCount = 0; intCount <= mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count - 1; intCount++) {
				//'check a data structure
				if (intCount < CalcUsedTotStd) {
					if (mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Used) {
						//'get all value of abs and conc.
						abs(intCount) = mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Abs;
						conc(intCount) = mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Concentration;
					}
				}
			}

			//#If STD_ADDN Then
			//   if( Method->QuantData->Param.Std_Addn)
			//	    i = LINEAR;
			//	else
			//		i = Get_Best_Out_Of_Curve(abs, conc,CalcUsedTotStd);
			//#Else
			//	i = Get_Best_Out_Of_Curve(abs, conc,CalcUsedTotStd);
			//#End If

			if ((mobjClsMethod.StandardAddition)) {
				intCount = enumCalculationMode.LINEAR;
			} else {
				//'pass the value of abs and conc to function which we calculated above.
				intCount = Get_Best_Out_Of_Curve(abs, conc, CalcUsedTotStd);
			}

			//abs = Nothing
			//conc = Nothing

			//Close_Window(hwnd, NULL);
			//SetCursor(curs);

			//If Not blnIsSilent Then
			//    Call gobjMessageAdapter.CloseStatusMessageBox()
			//End If

			return intCount;

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
			if (!blnIsSilent) {
				gobjMessageAdapter.CloseStatusMessageBox();
				Application.DoEvents();
			}
			objWaitCursor.Dispose();
			//---------------------------------------------------------
		}
	}

	private enumCalculationMode Get_Best_Out_Of_Curve(ref double[] abs, ref double[] conc, int nStd)
	{
		//=====================================================================
		// Procedure Name        : Get_Best_Out_Of_Curve
		// Parameters Passed     : Abs Values array, Conc. Values array, No. of Standard
		// Returns               : integer
		// Purpose               : 
		// Description           : for ploting a curve.
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 04-Feb-2007 01:40 pm
		// Revisions             : 1
		//=====================================================================

		//*******************************************************
		//---- ORIGINAL CODE
		//*******************************************************
		//E4FUNC int S4FUNC Get_Best_Out_Of_Curve(double *abs, double *conc,int nStd)
		//{
		//	double	conc1=0.0, err1=0.0, averr=0.0;
		//	int	cmode, i, acount;
		//	BOOL	flag=FALSE;

		//	for(cmode=RATIONAL; cmode<=FIFTH_ORDER; cmode++)
		//		err[cmode]=1000.0;

		//	for(cmode=RATIONAL; cmode<=FIFTH_ORDER; cmode++)
		//	{
		//                If (Calculate_Curve(abs, conc, nStd, cmode, ZERO_PASSING)) Then
		//		{
		//			flag=TRUE;
		//			averr=0.0; acount=0; conc1=0;
		//			conc1 = Get_Conc(0.0, conc1);//, 8);
		//			err1= fabs(conc1)*100.0;
		//			averr+=err1;
		//			acount++;
		//			for(i=0;i<nStd; i++)
		//			{
		//				conc1 = Get_Conc(abs[i], conc1);//, 8);
		//				err1= fabs(conc1-conc[i])*100.0;
		//				if (conc[i]!=0.0)
		//					err1 /= (conc[i]);
		//				averr+=err1;
		//				acount++;
		//			}
		//                            If (acount > 0) Then
		//				averr /=(acount);
		//			err[cmode]=averr;
		//		}
		//	}
		//                                If (flag) Then
		//	{
		//		err1=2000.0; cmode=DIRECT;
		//		for(i=RATIONAL; i<=FIFTH_ORDER; i++)
		//			if (err1>err[i])
		//			{
		//				cmode=i;
		//				err1  = err[i];
		//			}
		//	}
		//   If (flag) Then
		//	{
		//		Calculate_Curve(abs, conc, nStd, cmode,TRUE);
		//		return cmode;
		//	}
		//   Else
		//		return DIRECT;
		//}
		//*******************************************************
		double conc1;
		double err1;
		double averr;
		int cmode;
		int i;
		int acount;
		bool flag;

		try {
			for (cmode = enumCalculationMode.RATIONAL; cmode <= enumCalculationMode.FIFTH_ORDER; cmode++) {
				err(cmode) = 1000.0;
			}

			for (cmode = enumCalculationMode.RATIONAL; cmode <= enumCalculationMode.FIFTH_ORDER; cmode++) {
				if ((Calculate_Curve(abs, conc, nStd, cmode, ZERO_PASSING))) {
					flag = true;
					averr = 0.0;
					acount = 0;
					conc1 = 0;
					conc1 = Get_Conc(0.0, conc1);
					err1 = Math.Abs(conc1) * 100.0;
					averr += err1;
					acount += 1;
					//			for(i=0;i<nStd; i++)
					//			{
					//				conc1 = Get_Conc(abs[i], conc1);//, 8);
					//				err1= fabs(conc1-conc[i])*100.0;
					//				if (conc[i]!=0.0)
					//					err1 /= (conc[i]);
					//				averr+=err1;
					//				acount++;
					//			}
					for (i = 0; i <= nStd - 1; i++) {
						conc1 = Get_Conc(abs(i), conc1);
						err1 = Math.Abs(conc1 - conc(i)) * 100.0;
						if ((conc(i) != 0.0)) {
							err1 /= conc(i);
						}
						averr += err1;
						acount += 1;
					}
					if ((acount > 0)) {
						averr /= (acount);
					}
					err(cmode) = averr;
				}
			}

			//                                If (flag) Then
			//	{
			//		err1=2000.0; cmode=DIRECT;
			//		for(i=RATIONAL; i<=FIFTH_ORDER; i++)
			//			if (err1>err[i])
			//			{
			//				cmode=i;
			//				err1  = err[i];
			//			}
			//	}
			if ((flag)) {
				err1 = 2000.0;
				cmode = enumCalculationMode.DIRECT;
				for (i = enumCalculationMode.RATIONAL; i <= enumCalculationMode.FIFTH_ORDER; i++) {
					if ((err1 > err(i))) {
						cmode = i;
						err1 = err(i);
					}
				}
			}

			if ((flag)) {
				Calculate_Curve(abs, conc, nStd, cmode, true);
				return cmode;
			} else {
				return enumCalculationMode.DIRECT;
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

	private bool Calculate_Curve(ref double[] Abs, ref double[] Conc, int nStd, int nDegree, bool zflag)
	{
		//=====================================================================
		// Procedure Name        : Calculate_Curve
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : calculating a curve as par given value of Abs and Conc.
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 31-Jan-2007 10:35 pm
		// Revisions             : 1
		//=====================================================================

		//***********************************************************
		//---- ORIGINAL CODE
		//***********************************************************
		//E4FUNC  BOOL	S4FUNC  Calculate_Curve(double *Abs, double *Conc, int nStd, int nDegree, BOOL zflag)
		//{
		//	double	ty=0.0;
		//	int		i;

		//	FindMaxAbs(Abs,  nStd);
		//	Curve_Status=FALSE;
		//	InitMatrixData();

		//	No = nStd;
		//	N =nDegree;
		//	rational=FALSE;
		//	if (N==0){ 
		//            If (nStd < 2) Then
		//			return FALSE;
		//		rational=TRUE;
		//		Copy_Matrix_Row(X, Conc, No, TRUE);
		//		Copy_Matrix_Row(Y, Abs,  No, TRUE);
		//		for(i=0; i<No; i++){
		//			ty=Y[i];
		//			if (X[i]==(double) 0.0)
		//				Y[i]=0.0;
		//                    Else
		//				Y[i]=Y[i]/X[i];
		//			X[i] =ty;
		//		}
		//		N=2;
		//	}
		//	else{
		//		Copy_Matrix_Row(X, Conc, No, !zflag);
		//		Copy_Matrix_Row(Y, Abs,  No, !zflag);
		//                        If (zflag) Then
		//			No++;
		//	}
		//	if (No<N) //+1)
		//		return FALSE;
		//	N++;
		//	if (N>1){
		//		Contruct_matrix();
		//		Calculate_BestFit();
		//	}
		//	Curve_Status=TRUE;
		//	return TRUE;
		//}
		//***********************************************************
		double ty = 0.0;
		int i;

		try {
			// Calculate the curve
			FindMaxAbs(Abs, nStd);
			//'to find max of abs
			Curve_Status = false;
			InitMatrixData();
			//for initialization of matrix data.

			No = nStd;
			N = nDegree;
			Rational = false;

			if ((N == 0)) {
				if ((nStd < 2)) {
					return false;
				}
				Rational = true;

				Copy_Matrix_Row(X, Conc, No, true);
				//'for copy a matrix row.
				Copy_Matrix_Row(Y, Abs, No, true);
				//'for copy a matrix row.
				for (i = 0; i <= No - 1; i++) {
					ty = Y(i);
					if (X(i) == 0.0) {
						Y(i) = 0.0;
					} else {
						Y(i) = Y(i) / X(i);
					}
					X(i) = ty;
				}
				N = 2;

			} else {
				////----- commented by Sachin Dokhale
				Copy_Matrix_Row(X, Conc, No, (!zflag));
				//'for copy a matrix row.
				Copy_Matrix_Row(Y, Abs, No, (!zflag));
				//'for copy a matrix row.
				////----- Added by Sachin Dokhale 
				//Copy_Matrix_Row(X, Conc, No, (zflag))
				//Copy_Matrix_Row(Y, Abs, No, (zflag))
				////-----

				if ((zflag)) {
					No += 1;
				}
			}

			if ((No < N)) {
				return false;
			}

			N += 1;
			if ((N > 1)) {
				Contruct_matrix();
				//'for constructing a matrix

				Calculate_BestFit();
				//'for calculate a base fit.
			}

			Curve_Status = true;
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

	private void Calculate_BestFit()
	{
		//=====================================================================
		// Procedure Name        : Calculate_BestFit
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : for calculating a base fit.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 31-Jan-2007 02:10 pm
		// Revisions             : 1
		//=====================================================================

		//*************************************************************
		//---- ORIGINAL CODE
		//*************************************************************
		//void Calculate_BestFit()
		//{
		//	double	x=0.0;
		//	int 		i, I, n;
		//	int  		j, J;

		//	for(i=0; i<N; i++)
		//		for(j=0; j<N; j++)
		//			if (i!=0 || j!=0)
		//				MatX[i][j]=0;

		//	for (i=0; i<N;i++)
		//		MatY[i]=0.0;

		//	for (I=0; I<N; I++)
		//	{
		//		for(J=0; J<N; J++)
		//		{
		//			if ( (I!=0 || J!=0) )
		//			{
		//				for(i=0; i<No; i++)
		//				{
		//					x = pow(X[i],(double) (I+J));
		//					MatX[I][J] += x;
		//				}
		//			}
		//		}
		//	}

		//	for (I=0; I<N; I++)
		//		for(i=0; i<No; i++)
		//		{
		//                                                If (I! = 0) Then
		//			{
		//				if (X[i]!=0.0)
		//					x = pow(X[i],(double) (I));
		//                                                    Else
		//					x=0;
		//			}
		//			else
		//				x=1;
		//			x *=  Y[i];
		//			MatY[I] += x;
		//		}
		//	n=N;
		//	Inverse(&MatX,&MatX, &n);
		//	MatMultS(&MatX, MatY, MatA,  n,  &n);

		//	for(i=0; i<N; i++)
		//	{
		//		if (fabs(MatA[i])<(double) 0.00001 && fabs(MatA[i])>(double) 0.0)
		//			MatA[i] =(double) 0.0;
		//	}
		//}
		//*************************************************************
		double dblX = 0.0;
		int i;
		int I1;
		int intN;
		int j;
		int J1;

		try {
			//Calculate the Curve fitting
			for (i = 0; i <= N - 1; i++) {
				for (j = 0; j <= N - 1; j++) {
					if ((i != 0 | j != 0)) {
						MatX(i, j) = 0;
					}
				}
			}

			for (i = 0; i <= N - 1; i++) {
				MatY(i) = 0.0;
			}

			for (I1 = 0; I1 <= N - 1; I1++) {
				for (J1 = 0; J1 <= N - 1; J1++) {
					if (((I1 != 0 | J1 != 0))) {
						for (i = 0; i <= No - 1; i++) {
							dblX = Math.Pow(X(i), (I1 + J1));
							MatX(I1, J1) += dblX;
						}
					}
				}
			}

			for (I1 = 0; I1 <= N - 1; I1++) {
				for (i = 0; i <= No - 1; i++) {
					if ((I1 != 0)) {
						if ((X(i) != 0.0)) {
							dblX = Math.Pow(X(i), I1);
						} else {
							dblX = 0;
						}
					} else {
						dblX = 1;
					}
					dblX *= Y(i);
					MatY(I1) += dblX;
				}
			}

			intN = N;

			Inverse(MatX, MatX, intN);
			//MatX = MatrixOperations.FindInverseMatrix(MatX)
			//'inverse the matrix.
			MatMultS(MatX, MatY, MatA, intN, intN);

			for (i = 0; i <= N - 1; i++) {
				if ((Math.Abs(MatA(i)) < 1E-05 & Math.Abs(MatA(i)) > 0.0)) {
					MatA(i) = 0.0;
				}
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

	private double Calc_AbsDirect(double dblX)
	{
		//=====================================================================
		// Procedure Name        : Calc_AbsDirect
		// Parameters Passed     : X Value in Doub 
		// Returns               : Abs in double
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 03-Feb-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================

		//****************************************************
		//---- ORIGINAL CODE
		//****************************************************
		//double	Calc_AbsDirect(double x)
		//{
		//	double x1=0.0, y1=0.0;
		//	double x2=0.0, y2=0.0, y=0;
		//	int	i;

		//	if (x>X[No-1])
		//		return -1;
		//	for(i=0;i<No; i++)
		//		if (x==X[i])
		//		{
		//			y=Y[i];
		//			break;
		//		}
		//                    If (i >= No) Then
		//	{
		//		if (Find_Between_Pts(x, 0.0, &x1, &y1,	&x2, &y2, FALSE))
		//                            If (X > 12) Then
		//				i=0;
		//                                If (x2! = x1) Then
		//				y = y1+ (y2-y1)*(x-x1)/(x2-x1);
		//	}
		//	return y;
		//}
		//****************************************************
		double x1;
		double y1;
		double x2;
		double y2;
		double dblY;
		int i;

		try {
			x1 = 0.0;
			y1 = 0.0;
			x2 = 0.0;
			y2 = 0.0;
			dblY = 0;

			if ((dblX > X(No - 1))) {
				return -1;
			}

			for (i = 0; i <= No - 1; i++) {
				if ((dblX == X(i))) {
					dblY = Y(i);
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			if ((i >= No)) {
				if ((Find_Between_Pts(dblX, 0.0, x1, y1, x2, y2, false))) {
					if ((dblX > 12)) {
						i = 0;
					}
				}
				if ((x2 != x1)) {
					dblY = y1 + (y2 - y1) * (dblX - x1) / (x2 - x1);
				}
			}

			return dblY;

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

	private double Get_Conc1(double y1, double x11, double xmax)
	{
		//=====================================================================
		// Procedure Name        : Get_Conc1
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 03-Feb-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================

		//********************************************************
		//---- ORIGINAL CODE
		//********************************************************
		//double	 Get_Conc1(double y1, double x11, double xmax)
		//{
		//	double x1=x11, y2=0.0;
		//        While (x1 < xmax)
		//	{
		//		y2 = Get_Abs(x1);
		//		if (y2<y1+0.0005 && y2>y1-0.0005 )
		//			break;
		//		x1+=(double) 0.0001;
		//	}
		//	return x1;
		//}
		//********************************************************
		double x1;
		double y2;

		try {
			x1 = x11;

			while ((x1 < xmax)) {
				y2 = Get_Abs(x1);
				if ((y2 < y1 + 0.0005 & y2 > y1 - 0.0005)) {
					break; // TODO: might not be correct. Was : Exit While
				}
				x1 += 0.0001;
			}

			return x1;

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

	private bool Return_InitalValue(double y1, ref double x1, ref double x2)
	{
		//=====================================================================
		// Procedure Name        : Return_InitalValue
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 03-Feb-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================

		//*********************************************************************
		//----- ORIGINAL CODE
		//*********************************************************************
		//BOOL Return_InitalValue(double y1, double *x1, double *x2)
		//{
		//	int	i,j, k;
		//	j=k=-1;
		//	for(i=0;i<No; i++)
		//	{
		//		if (y1>=Y[i])
		//		{
		//			j=i;
		//			break;
		//		}
		//	}
		//	for(i=0;i<No; i++)
		//	{
		//		if (y1<=Y[i])
		//		{
		//			k=i;
		//			break;
		//		}
		//	}
		//                        If (j >= 0) Then
		//		*x1=X[j];
		//                        Else
		//		*x1=0.0;
		//                            If (k >= 0) Then
		//		*x2=X[k];
		//                            Else
		//		*x2=X[No-1]+X[No-1]*0.2;

		//	if (*x1==*x2)
		//	{
		//                                    If (j < No - 1) Then
		//			*x2=X[j+1];
		//                                    Else
		//			return FALSE;
		//	}
		//	return TRUE;
		//}
		//*********************************************************************
		int i;
		int j;
		int k;

		try {
			k = -1;
			j = -1;

			for (i = 0; i <= No - 1; i++) {
				if ((y1 >= Y(i))) {
					j = i;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = 0; i <= No - 1; i++) {
				if ((y1 <= Y(i))) {
					k = i;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			if ((j >= 0)) {
				x1 = X(j);
			} else {
				x1 = 0.0;
			}

			if ((k >= 0)) {
				x2 = X(k);
			} else {
				x2 = X(No - 1) + X(No - 1) * 0.2;
			}

			if ((x1 == x2)) {
				if ((j < No - 1)) {
					x2 = X(j + 1);
				} else {
					return false;
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

	private void FindMaxAbs(double[] Abs, int nStd)
	{
		//=====================================================================
		// Procedure Name        : FindMaxAbs
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : to find maximum of abs.
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 31-Jan-2007 11:00 am
		// Revisions             : 1
		//=====================================================================

		//*****************************************************
		//---- ORIGINAL CODE
		//*****************************************************
		//void	FindMaxAbs(double *Abs,  int nStd)
		//{
		//	int	i;
		//	AbsMax=-1.0;
		//	for (i=0;i<nStd; i++){
		//		if (Abs[i]>AbsMax)
		//		AbsMax= Abs[i];
		//	}
		//}
		//*****************************************************
		int i;

		try {
			AbsMax = -1.0;

			for (i = 0; i <= nStd - 1; i++) {
				if ((Abs(i) > AbsMax)) {
					AbsMax = Abs(i);
				}
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

	private void InitMatrixData()
	{
		//=====================================================================
		// Procedure Name        : InitMatrixData
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : for initialization of matrix data.
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 31-Jan-2007 11:15 pm
		// Revisions             : 1
		//=====================================================================

		//************************************************************
		//---- ORIGINAL CODE
		//************************************************************
		//void(InitMatrixData(void))
		//{
		//	int i;
		//	InitBufferMatrix(&MatX);
		//	for(i=0; i<MAX; i++)
		//		MatA[i]=MatY[i]=X[i]=Y[i]=(double) 0.0;;
		//}
		//************************************************************
		int i;

		try {
			InitBufferMatrix(MatX);

			for (i = 0; i <= MAX - 1; i++) {
				//MatA[i]=MatY[i]=X[i]=Y[i]= 0.0;
				MatA(i) = 0.0;
				MatY(i) = 0.0;
				X(i) = 0.0;
				Y(i) = 0.0;
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

	private void InitBufferMatrix(ref double[,] mt)
	{
		//=====================================================================
		// Procedure Name        : InitBufferMatrix
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 31-Jan-2007 11:15 pm
		// Revisions             : 1
		//=====================================================================

		//************************************************************
		//---- ORIGINAL CODE
		//************************************************************
		//void InitBufferMatrix(DOUBLE *mt)
		//{
		//	int i,j;
		//	/* MatX[0][0]=9.0; MatX[0][1]=9.0;
		//	MatX[1][0]=8.0; MatX[1][1]=8.0;
		//	MatX[7][MAX-1]=7.0; MatX[7][MAX-2]=7.0;*/

		//   If (mt! = NULL) Then
		//	    for(i=0;i<MAX; i++)
		//		    for(j=0;j<MAX; j++)
		//			    mt[0][i][j]=(double) 0.0;
		//}
		//************************************************************
		int intCounter;
		ArrayList arrValues;
		int intTotalMatrixLength;
		int i;
		int j;

		try {
			 // ERROR: Not supported in C#: ReDimStatement


		//If Not IsNothing(mt) Then
		//    For i = 0 To MAX - 1
		//        For j = 0 To MAX - 1
		//            mt(i, j) = 0.0
		//        Next j
		//    Next i
		//End If

		//'arrValues = New ArrayList
		//'intTotalMatrixLength = MAX * MAX
		//'For intCounter = 0 To intTotalMatrixLength - 1
		//'    arrValues.Add(0.0)
		//'Next intCounter
		//'mt = MatrixOperations.GetMatrix(MAX, MAX, arrValues)

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

	private void Copy_Matrix_Row(ref double[] md, double[] ms, int n, bool flag)
	{
		//=====================================================================
		// Procedure Name        : Copy_Matrix_Row
		// Parameters Passed     : 
		// Returns               : None
		// Purpose               : 
		// Description           : for copy a matrix row.
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 31-Jan-2007 02:00 pm
		// Revisions             : 1
		//=====================================================================

		//************************************************************
		//---- ORIGINAL CODE
		//************************************************************
		//void	Copy_Matrix_Row(double md[MAX], double ms[MAX], int n, BOOL flag)
		//{
		//   int i;
		//	for(i=0; i<n; i++)
		//       If (flag) Then
		//		    md[i]=ms[i];
		//       Else
		//		    md[i+1]=ms[i];
		//}
		//************************************************************
		int i;

		try {
			//n - 1
			for (i = 0; i <= ms.Length - 1; i++) {
				if (flag) {
					md(i) = ms(i);
				} else {
					md(i + 1) = ms(i);
				}
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

	private void Contruct_matrix()
	{
		//=====================================================================
		// Procedure Name        : Contruct_matrix
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : for constructing a matrix
		// Description           :
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 31-Jan-2007 02:10 pm
		// Revisions             : 1
		//=====================================================================

		//*************************************************************
		//---- ORIGINAL CODE
		//*************************************************************
		//void(Contruct_matrix())
		//{
		//	int	i, j;

		//	for(i=0; i<N; i++)
		//	{
		//		for(j=0; j<N; j++)
		//			if (i==0 && j==0)
		//				MatX[i][0]=(double) No;

		//		MatX[i][j]=(double) i+j;
		//	}
		//	for(i=0; i<N; i++)
		//		MatA[i]= MatY[i] = i;
		//}
		//*************************************************************
		int i;
		int j;

		try {
			for (i = 0; i <= N - 1; i++) {
				for (j = 0; j <= N - 1; j++) {
					if ((i == 0 & j == 0)) {
						MatX(i, 0) = No;
					}
				}
				MatX(i, j) = i + j;
			}

			for (i = 0; i <= N - 1; i++) {
				MatA(i) = i;
				MatY(i) = i;
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

	private void MatMultS(double[,] mt1, double[] mt2, ref double[] mt3, int n1, ref int n)
	{
		//=====================================================================
		// Procedure Name        : MatMultS
		// Parameters Passed     : 
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 31-Jan-2007 03:15 pm
		// Revisions             : 1
		//=====================================================================

		//***********************************************************
		//---- ORIGINAL CODE
		//***********************************************************
		//void MatMultS(DOUBLE *mt1, double mt2[MAX], double mt3[MAX], int n1,  int *n)
		//{
		//	double 	t=0.0;
		//	double 	tm[MAX];
		//	int   	i,k;

		//	for(i=0;i<MAX; i++)
		//		tm[i] = (double) 0.0;

		//	for (i=0; i<n1; i++)
		//	{
		//		t=0;
		//		for(k=0; k<n1; k++)
		//			t += (mt1[0][i][k])* mt2[k];

		//		tm[i] = t;
		//	}

		//	*n=n1;

		//	for(i=0; i<n1; i++)
		//		mt3[i]=tm[i];
		//}
		//***********************************************************
		double t = 0.0;
		double[] tm = new double[MAX - 1];
		int i;
		int k;

		try {
			for (i = 0; i <= MAX - 1; i++) {
				tm(i) = 0.0;
			}

			for (i = 0; i <= n1 - 1; i++) {
				t = 0;
				for (k = 0; k <= n1 - 1; k++) {
					t += mt1(i, k) * mt2(k);
				}
				tm(i) = t;
			}

			n = n1;

			for (i = 0; i <= n1 - 1; i++) {
				mt3(i) = tm(i);
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

	private bool sign(double x)
	{
		//=====================================================================
		// Procedure Name        : sign
		// Parameters Passed     : X co-ordinate
		// Returns               : True or false
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 03-Feb-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		//BOOL sign(double x)
		//{
		//	if (x>=(double) 0.0)
		//		return TRUE;
		//	return FALSE;
		//}
		try {
			if ((x >= 0.0)) {
				return true;
			}

			return false;

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

	private double Fn(double x1, double y1)
	{
		//=====================================================================
		// Procedure Name        : Fn
		// Parameters Passed     : None
		// Returns               : x1, y1 as Double
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 03-Feb-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		//double	Fn(double x1,double y1)
		//{
		//double y;
		// y = Get_Abs(x1);
		// y-=y1;
		//return y;
		//}

		double dblY;

		try {
			dblY = Get_Abs(x1);
			dblY -= y1;

			return dblY;

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

	private double Calculte_Rat(double dblX)
	{
		//=====================================================================
		// Procedure Name        : Calculte_Rat
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 03-Feb-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================

		//********************************************************
		//---- ORIGINAL CODE
		//********************************************************
		//double	Calculte_Rat(double x)
		//{
		//	double A=0.0, B=0.0,C=0.0, y=0.0;//, y1=0.0;
		//	if (x==0)
		//		return y;

		//	A = MatA[2];
		//	C = MatA[0];

		//	if (x!=(double) 0)
		//		B= MatA[1]-1.0/x;

		//	if (A!=(double) 0 && (B*B-4.0*A*C)>0)
		//	{
		//		y = (-B - sqrt(B*B-4.0*A*C))/(2.0*A);
		//		//y1= (-B + sqrt(B*B-4.0*A*C))/(2.0*A);
		//	}
		//                Else
		//#If STD_ADDN Then
		//			y = -1.0;
		//#Else
		//			y = 0;
		//#End If
		//	return y;
		//}
		//********************************************************
		double A;
		double B;
		double C;
		double dblY;
		try {
			mblnSaturation = false;
			if ((dblX == 0)) {
				mblnSaturation = true;
				return dblY;
			}

			A = MatA(2);
			C = MatA(0);

			if ((dblX != 0)) {
				B = MatA(1) - 1.0 / dblX;
			}

			if ((A != 0 & (B * B - 4.0 * A * C) > 0)) {
				dblY = (-B - Math.Sqrt(B * B - 4.0 * A * C)) / (2.0 * A);

			} else {
				if (mblnIsStandardAddition) {
					dblY = -1.0;
					mblnSaturation = true;
				} else {
					dblY = 0;
					mblnSaturation = true;
				}
			}

			return dblY;

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

	private bool Find_Between_Pts(double x, double y, ref double x1, ref double y1, ref double x2, ref double y2, bool abs)
	{
		//=====================================================================
		// Procedure Name        : Find_Between_Pts
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 03-Feb-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================

		//************************************************************
		//----- ORIGINAL CODE
		//************************************************************
		//BOOL Find_Between_Pts(double x, double y, double *x1, double *y1, double *x2, double *y2, BOOL abs)
		//{
		//	int	i,j,k;
		//	j=k=-1;
		//	for(i=0;i<No; i++)
		//	{
		//       If (abs) Then
		//	    {
		//		    if (y<Y[i])
		//			{
		//				j=i-1;
		//				break;
		//			}
		//		}
		//       Else
		//		{
		//		    if (x<X[i])
		//			{
		//				j=i-1;
		//				break;
		//			}
		//		}
		//	}
		//	for(i=No-1;i>=0; i--)
		//	{
		//       If (abs) Then
		//		{
		//		    if (y>Y[i])
		//			{
		//				k=i+1;
		//				break;
		//			}
		//		}
		//       Else
		//		{
		//		    if (x>X[i])
		//			{
		//				k=i+1;
		//				break;
		//			}
		//		}
		//	}
		//   If (j >= 0) Then
		//	{
		//       If (x1) Then
		//		    *x1=X[j];
		//       If (y1) Then
		//		    *y1=Y[j];
		//   }
		//   Else
		//	{
		//       If (x1) Then
		//		    *x1=0.0;
		//       If (y1) Then
		//		    *y1=0.0;
		//   }
		//   If (k >= 0) Then
		//	{
		//       If (x2) Then
		//		    *x2=X[k];
		//       If (y2) Then
		//		    *y2=Y[k];
		//   }
		//   Else
		//	{
		//		k=No-1;
		//		if (x<X[0])
		//			k=0;
		//       If (x2) Then
		//			*x2=X[k]; //+100.0;
		//       If (y2) Then
		//			*y2=Y[k]; //+100.0;
		//	}
		//	if ( (abs && *x1==*x2) || (*y1==*y2))
		//	{
		//       If (j < No - 1) Then
		//		{
		//       If (x2) Then
		//				*x2=X[j+1];
		//       If (y2) Then
		//				*y2=Y[j+1];
		//		}
		//       Else
		//			return FALSE;
		//	}
		//	return TRUE;
		//}
		//************************************************************
		int i;
		int j;
		int k;

		try {
			j = -1;
			k = -1;

			for (i = 0; i <= No - 1; i++) {
				if ((abs)) {
					if ((y < this.Y(i))) {
						j = i - 1;
						break; // TODO: might not be correct. Was : Exit For
					}
				} else {
					if ((x < this.X(i))) {
						j = i - 1;
						break; // TODO: might not be correct. Was : Exit For
					}
				}
			}

			for (i = No - 1; i >= 0; i += -1) {
				if ((abs)) {
					if ((y > this.Y(i))) {
						k = i + 1;
						break; // TODO: might not be correct. Was : Exit For
					}
				} else {
					if ((x > this.X(i))) {
						k = i + 1;
						break; // TODO: might not be correct. Was : Exit For
					}
				}
			}

			//If (j >= 0) Then
			//    If (x1) Then
			//        x1 = Me.X(j)
			//    End If
			//    If (y1) Then
			//        y1 = Me.Y(j)
			//    End If
			//Else
			//    If (x1) Then
			//        x1 = 0.0
			//    End If
			//    If (y1) Then
			//        y1 = 0.0
			//    End If
			//End If

			//If (k >= 0) Then
			//    If (x2) Then
			//        x2 = Me.X(k)
			//    End If
			//    If (y2) Then
			//        y2 = Me.Y(k)
			//    End If
			//Else
			//    k = Me.No - 1
			//    If (x < Me.X(0)) Then
			//        k = 0
			//    End If
			//    If (x2) Then
			//        x2 = Me.X(k)
			//    End If
			//    If (y2) Then
			//        y2 = Me.Y(k)
			//    End If
			//End If
			////----- Modified by Sachin on 18.09.07

			if ((j >= 0)) {
				x1 = this.X(j);


				y1 = this.Y(j);

			} else {
				x1 = 0.0;


				y1 = 0.0;

			}


			if ((k >= 0)) {
				x2 = this.X(k);


				y2 = this.Y(k);

			} else {
				k = this.No - 1;
				if ((x < this.X(0))) {
					k = 0;
				}

				x2 = this.X(k);

				y2 = this.Y(k);

			}
			////-----

			if (((abs & x1 == x2) | (y1 == y2))) {
				if ((j < this.No - 1)) {
					////----- Modified by Sachin on 18.09.07
					//If (x2) Then
					//    x2 = Me.X(j + 1)
					//End If
					//If (y2) Then
					//    y2 = Me.Y(j + 1)
					//End If

					x2 = this.X(j + 1);
					y2 = this.Y(j + 1);

				////-----
				} else {
					return false;
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

	private double GetRawStdAddnConc(bool blnIsStandardAddition)
	{
		//=====================================================================
		// Procedure Name        : GetRawStdAddnConc
		// Parameters Passed     : blnIsStandardAddition
		// Returns               : Raw Standard Addition Conc.
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 04-Feb-2007 01:20 pm
		// Revisions             : 1
		//=====================================================================

		//*******************************************************************
		//---- ORIGINAL CODE
		//*******************************************************************
		//#If STD_ADDN Then
		//E4FUNC double S4FUNC GetRawStdAddnConc( void )
		//{
		//	double c=0.0;
		//	if(MatA[1])
		//	{
		//		c = MatA[0]/MatA[1];
		//	}
		//	if( c < 0.0 )
		//		c = c * -1.0;
		//	return c;
		//}
		//#End If
		//*******************************************************************
		double dblConc = 0.0;

		try {
			if (blnIsStandardAddition) {
				if ((MatA(1))) {
					dblConc = MatA(0) / MatA(1);
				}

				if ((dblConc < 0.0)) {
					dblConc = dblConc * -1.0;
				}

				return dblConc;
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

	private double Inverse(ref double[,] mt, ref double[,] tm, ref int n)
	{
		//=====================================================================
		// Procedure Name        : Inverse
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 14-Feb-2007 06:05 pm
		// Revisions             : 1
		//=====================================================================

		//*****************************************************
		//---- ORIGINAL CODE
		//*****************************************************
		//double Inverse(DOUBLE *mt, DOUBLE *tm, int *n)
		//{
		//	int 		i, j;
		//	double	val=1.0;
		//	DOUBLE 	*t=NULL;

		//	t = Allocate_Double();
		//	val = Inverse1(mt, t, *n);

		//	for(i=0; i<*n; i++)
		//		for(j=0; j<*n; j++)
		//			tm[0][i][j] = t[0][i][j];

		//	t =Free_Double(t);
		//	return val;
		//}
		//*****************************************************
		int i;
		int j;
		double val = 1.0;
		double[,] t;
		// Use inverse matrix opration 
		try {
			InitBufferMatrix(t);

			val = Inverse1(mt, t, n);

			for (i = 0; i <= n - 1; i++) {
				for (j = 0; j <= n - 1; j++) {
					tm(i, j) = t(i, j);
				}
			}

			//t =Free_Double(t)
			t = null;

			return val;

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

	private double Inverse1(ref double[,] mt, ref double[,] tm, int n)
	{
		//=====================================================================
		// Procedure Name        : Inverse
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 14-Feb-2007 06:05 pm
		// Revisions             : 1
		//=====================================================================

		//*****************************************************
		//---- ORIGINAL CODE
		//*****************************************************
		//double	Inverse1(DOUBLE *mt,DOUBLE *tm, int n)
		//{
		//	double 	val=0;
		//	int 	i, j;
		//	DOUBLE 	*t=NULL;

		//	t = Allocate_Double();
		//	val = Detm(mt, n);
		//	Adjoint(mt, t, n);

		//	if (val!=(double) 0)
		//		for (i=0; i<n; i++)
		//			for (j=0; j<n; j++)
		//			{
		//				tm[0][i][j] = t[0][i][j]/val;
		//			}
		//	t =Free_Double(t);
		//	return val;
		//}
		//*****************************************************
		int i;
		int j;
		double val = 1.0;
		double[,] t;

		try {
			InitBufferMatrix(t);

			val = Detm(mt, n);

			Adjoint(mt, t, n);

			if ((val != 0)) {
				for (i = 0; i <= n - 1; i++) {
					for (j = 0; j <= n - 1; j++) {
						tm(i, j) = t(i, j) / val;
					}
				}
			}

			//t =Free_Double(t);
			t = null;

			return val;

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

	private double Detm(ref double[,] mt, int n)
	{
		//=====================================================================
		// Procedure Name        : Detm
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 14-Feb-2007 06:20 pm
		// Revisions             : 1
		//=====================================================================

		//*****************************************************
		//---- ORIGINAL CODE
		//*****************************************************
		//double 	Detm(DOUBLE *mt, int n )
		//{
		//	return Detm1(mt, n);
		//}
		//*****************************************************
		try {
			return Detm1(mt, n);

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

	private double Detm1(double[,] mt, int n)
	{
		//=====================================================================
		// Procedure Name        : Detm1
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 14-Feb-2007 06:20 pm
		// Revisions             : 1
		//=====================================================================

		//*****************************************************
		//---- ORIGINAL CODE
		//*****************************************************
		//double 	Detm1(DOUBLE  *mt, int n )
		//{
		//	int   	i;
		//	double 	sum=0;
		//	DOUBLE 	*t=NULL;

		//	if (n==1) return mt[0][0][0];
		//	else if (n==2) return(Det2(mt));
		//        Else
		//	{
		//		t = Allocate_Double();
		//            If (t! = NULL) Then
		//		{
		//			for (i=0; i<n; i++)
		//			{
		//				Make_minor(mt, t, 0, i, n, NULL);
		//				sum +=( one(i,0)* (mt[0][0][i]) * Detm1(t, n-1));
		//			}
		//			t = Free_Double(t);
		//		}
		//		else
		//			ErrorMsg();
		//	}
		//	return sum;
		//}
		//*****************************************************
		int i;
		double sum = 0;
		double[,] t;

		try {
			if ((n == 1)) {
				return mt(0, 0);
			} else if ((n == 2)) {
				return Det2(mt);
			} else {
				InitBufferMatrix(t);

				if (!IsNothing(t)) {
					for (i = 0; i <= n - 1; i++) {
						Make_minor(mt, t, 0, i, n, null);
						sum += (one(i, 0) * (mt(0, i)) * Detm1(t, n - 1));
					}
					t = null;
				} else {
					//ErrorMsg();
					//MessageBox(hpar, "floating point error", "ERROR", MB_OK);
					MessageBox.Show("floating point error", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

			return sum;

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

	private void Adjoint(double[,] mt, ref double[,] tm, int n)
	{
		//=====================================================================
		// Procedure Name        : Adjoint
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 14-Feb-2007 06:20 pm
		// Revisions             : 1
		//=====================================================================

		//*****************************************************
		//---- ORIGINAL CODE
		//*****************************************************
		//void  	Adjoint(DOUBLE *mt, DOUBLE *tm, int n)
		//{
		//	double	 val=0.0;
		//	DOUBLE 	*t=NULL;
		//	DOUBLE 	*t1=NULL;
		//	int 		i, j, n1;

		//	t = Allocate_Double();
		//	t1 = Allocate_Double();

		//	for (i=0; i<n; i++)
		//		for (j=0; j<n; j++)
		//			t1[0][i][j]= mt[0][i][j];

		//	for (i=0; i<n; i++)
		//		for (j=0; j<n; j++)
		//		{
		//			Make_minor(t1, t, i, j, n, &n1);
		//           If (n1! = 1) Then
		//			{
		//				val=Detm(t, n1);
		//				tm[0][i][j]=one(i, j)*val;
		//			}
		//           Else
		//				tm[0][i][j]=one(i, j)* (t[0][0][0]);
		//			val = 0.0;
		//		}

		//	for (i=0; i<n; i++)
		//		for (j=i; j<n; j++)
		//		{
		//			if (i==j) continue;
		//			val= tm[0][i][j];
		//			tm[0][i][j]=tm[0][j][i];
		//			tm[0][j][i]=val;
		//		}

		//	t = Free_Double(t);
		//	t1 =Free_Double(t1);
		//}
		//*****************************************************
		double val = 0.0;
		double[,] t;
		double[,] t1;
		int i;
		int j;
		int n1;

		try {
			InitBufferMatrix(t);
			InitBufferMatrix(t1);

			for (i = 0; i <= n - 1; i++) {
				for (j = 0; j <= n - 1; j++) {
					t1(i, j) = mt(i, j);
				}
			}

			for (i = 0; i <= n - 1; i++) {
				for (j = 0; j <= n - 1; j++) {
					Make_minor(t1, t, i, j, n, n1);
					if ((n1 != 1)) {
						val = Detm(t, n1);
						tm(i, j) = one(i, j) * val;
					} else {
						tm(i, j) = one(i, j) * t(0, 0);
					}
					val = 0.0;
				}
			}

			for (i = 0; i <= n - 1; i++) {
				for (j = i; j <= n - 1; j++) {
					if ((i == j))
						goto ;
					val = tm(i, j);
					tm(i, j) = tm(j, i);
					tm(j, i) = val;
					continue;
				}
			}

			t = null;
			t1 = null;

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

	private double one(int i, int j)
	{
		//=====================================================================
		// Procedure Name        : one
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 14-Feb-2007 06:59 pm
		// Revisions             : 1
		//=====================================================================
		//double  	one(int i, int j)
		//{
		//	int k;
		//	double val=-1.0;

		//	for (k=0; k<=i+j; k++)
		//		val *= (double) -1.0;

		//	return val;
		//}

		int k;
		double val = -1.0;

		try {
			for (k = 0; k <= i + j; k++) {
				val *= -1.0;
			}

			return val;

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

	private void Make_minor(double[,] mt, ref double[,] t, int i, int j, int n, ref int n1)
	{
		//=====================================================================
		// Procedure Name        : Make_minor
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 14-Feb-2007 06:59 pm
		// Revisions             : 1
		//=====================================================================

		//*********************************************************
		//---- ORIGINAL CODE
		//*********************************************************
		//void Make_minor(DOUBLE *mt, DOUBLE *t,int i, int j, int n, int *n1)
		//{
		//	int k, l, a, b;
		//	for (k=0,a=0; k<n; k++,a++)
		//		for (l=0, b=0; l<n; l++, b++)
		//		{
		//			if (k==i) k++;
		//			if (l==j) l++;
		//			if (l<n && k<n)
		//				t[0][a][b] = mt[0][k][l];
		//		}

		//   If (n1! = NULL) Then
		//		*n1=n-1;
		//}
		//*********************************************************
		int k;
		int l;
		int a;
		int b;

		try {
			a = 0;
			for (k = 0; k <= n - 1; k++) {
				b = 0;
				for (l = 0; l <= n - 1; l++) {
					if ((k == i))
						k += 1;
					if ((l == j))
						l += 1;
					if ((l < n & k < n)) {
						t(a, b) = mt(k, l);
					}
					b += 1;
				}
				a += 1;
			}

			if (!IsNothing(n1)) {
				n1 = n - 1;
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

	private double Det2(ref double[,] mt)
	{
		//=====================================================================
		// Procedure Name        : Det2
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 14-Feb-2007 06:59 pm
		// Revisions             : 1
		//=====================================================================

		//*******************************************************
		//----- ORIGINAL CODE
		//*******************************************************
		//double  Det2(DOUBLE *mt)
		//{
		//	double val=0, temp=0;;
		//	val= (mt[0][0][0]);
		//	val*= (mt[0][1][1]);
		//	temp= (mt[0][1][0]);
		//	temp*= (mt[0][0][1]);
		//	val-=temp;
		//	return val;
		//}
		//*******************************************************
		double val = 0;
		double temp = 0;

		try {
			val = mt(0, 0);
			val *= mt(1, 1);
			temp = mt(1, 0);
			temp *= mt(0, 1);
			val -= temp;

			return val;

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
