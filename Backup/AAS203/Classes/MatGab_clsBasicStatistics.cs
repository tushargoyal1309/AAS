using AAS203Library;
using AAS203Library.Method;
using AAS203Library.Analysis;
//---these are like the headers files.


public class clsBasicStatistics
{

	#Region " Public Shared Functions "

	public static bool CalculateBasicStats(ref Method.clsAbsRepeat objAbsRepeat)
	{
		//=====================================================================
		// Procedure Name        : CalculateBasicStats
		// Parameters Passed     : objAbsRepeat
		// Returns               : bool
		// Purpose               : To calculate basic statistics
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak B.
		// Created               : 08.11.06
		// Revisions             : 
		//=====================================================================
		//void CalculateBasicStats(ABSREPEAT	*AbsRepeat)
		//{
		//   if (AbsRepeat==NULL)
		//       return;
		//   CalculateAvg(AbsRepeat);
		//   CalculateSigma(AbsRepeat);
		//   CalCulateMinMax(AbsRepeat);
		//}
		int intRepCount;
		int intRepCounter;
		try {
			if (IsNothing(objAbsRepeat)) {
				//---check for objAbsRepeat object.
				return false;
			}
			if (IsNothing(objAbsRepeat.AbsRepeatData)) {
				//---check for AbsRepeatData
				return false;
			}

			//---to calculate average
			CalculateAvg(objAbsRepeat);
			//---To Calculate CV,Variance, and standard deviation
			CalculateSigma(objAbsRepeat);
			//---to calculate min and max
			CalculateMinMax(objAbsRepeat);

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

	#End Region

	#Region " Private Shared Functions "

	private static void CalculateAvg(ref Method.clsAbsRepeat objAbsRepeat)
	{
		//=====================================================================
		// Procedure Name        : CalculateAvg
		// Parameters Passed     : objAbsRepeat
		// Returns               : bool
		// Purpose               : To calculate Avg
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh
		// Created               : 08.11.06
		// Revisions             : Deepak B.
		//=====================================================================
		//void(CalculateAvg(ABSREPEAT * tempk))
		//{
		//ABSREPEATDATA	*temp1=NULL;
		//double   		x=0;
		//int 				tot=0;

		//  tempk->Data.Zavg[0]=tempk->Data.Zavg[1] = (double) 0.0;
		//  tot=0;
		//  temp1=tempk->RptDataTop;
		//  while(temp1 !=NULL){
		//	 x = ReadDataVal(temp1, TRUE);
		//	 (tempk->Data.Zavg[0]) +=x;
		//	 x = ReadDataVal(temp1, FALSE);
		//	 (tempk->Data.Zavg[1]) +=x;
		//	 tot++;
		//	 temp1 = temp1->next;
		//	}
		// tempk->Data.TotData[0]= tempk->Data.TotData[1]=tot;
		//  if (tot!=0){
		//	 (tempk->Data.Zavg[0]) /= (double) tot;
		//	 (tempk->Data.Zavg[1]) /= (double) tot;
		//	}
		//}

		double dblX;
		int intCounter;
		int intRowCounter;
		try {
			objAbsRepeat.BasicStat.ZAvg(0) = 0.0;
			objAbsRepeat.BasicStat.ZAvg(1) = 0.0;
			intCounter = 0;

			for (intRowCounter = 0; intRowCounter <= objAbsRepeat.AbsRepeatData.Count - 1; intRowCounter++) {
				//---make a counter upto number of repeats
				//---if this repeat number is used in edit data then 
				if (objAbsRepeat.AbsRepeatData.item(intRowCounter).Used == true) {
					//---check a condition , if true then store in a temp variable.
					dblX = objAbsRepeat.AbsRepeatData.item(intRowCounter).Abs;
					objAbsRepeat.BasicStat.ZAvg(0) += dblX;

					dblX = objAbsRepeat.AbsRepeatData.item(intRowCounter).Concentration;
					objAbsRepeat.BasicStat.ZAvg(1) += dblX;
					intCounter += 1;
				}
			}

			objAbsRepeat.BasicStat.TotData(0) = intCounter;
			objAbsRepeat.BasicStat.TotData(1) = intCounter;

			if ((intCounter != 0)) {
				objAbsRepeat.BasicStat.ZAvg(0) /= intCounter;
				objAbsRepeat.BasicStat.ZAvg(1) /= intCounter;
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

	private static void CalculateSigma(ref Method.clsAbsRepeat objAbsRepeat)
	{
		//=====================================================================
		// Procedure Name        : CalculateSigma
		// Parameters Passed     : objAbsRepeat
		// Returns               : bool
		// Purpose               : to calculate Sigma
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh
		// Created               : 08.11.06
		// Revisions             : Removed some calculation mistakes by Deepak B.
		//=====================================================================
		//void CalculateSigma(ABSREPEAT * tempk)
		//{
		//   ABSREPEATDATA   *temp1  = NULL;
		//   double   	    x       = 0;
		//   int 			tot     = 0;
		//   for(tot=0;tot<2; tot++)
		//	    tempk->Data.Zsigma[tot] = tempk->Data.CV[tot]=tempk->Data.Var[tot]=(double)0.0;
		//   tot=0;
		//   temp1=tempk->RptDataTop;
		//   while(temp1 !=NULL)
		//   {
		//	    x = ReadDataVal(temp1,TRUE);
		//	    tempk->Data.Zsigma[0] += sqr(x-tempk->Data.Zavg[0]);
		//	    x = ReadDataVal(temp1,FALSE);
		//	    tempk->Data.Zsigma[1] += sqr(x-tempk->Data.Zavg[1]);
		//	    tot++;
		//	    temp1 = temp1->next;
		//   }
		//   if (tot>1)
		//   {
		//	    tempk->Data.Zsigma[0] /= (double) (tot-1);
		//	    tempk->Data.Zsigma[1] /= (double) (tot-1);
		//	}
		//   tempk->Data.Var[0] = tempk->Data.Zsigma[0];
		//   tempk->Data.Var[1] = tempk->Data.Zsigma[1];
		//   tempk->Data.Zsigma[0] = sqrt(tempk->Data.Zsigma[0]);
		//   tempk->Data.Zsigma[1] = sqrt(tempk->Data.Zsigma[1]);
		//   if (tot>0)
		//   {
		//	    if (tempk->Data.Zavg[0] != (double) 0.0)
		//		    tempk->Data.CV[0] = (tempk->Data.Zsigma[0]*(double) 100.0)/tempk->Data.Zavg[0];
		//	    if (tempk->Data.Zavg[1] != (double) 0.0)
		//	        tempk->Data.CV[1] = (tempk->Data.Zsigma[1]*(double) 100.0)/tempk->Data.Zavg[1];
		//   }
		//}

		double dblX;
		int intTot;
		int intCounter;
		int intRowCounter;

		try {
			for (intTot = 0; intTot <= 2 - 1; intTot++) {
				//---initialise  variables
				objAbsRepeat.BasicStat.ZSigma(intTot) = 0.0;
				objAbsRepeat.BasicStat.CV(intTot) = 0.0;
				objAbsRepeat.BasicStat.Var(intTot) = 0.0;
			}

			intTot = 0;

			//   temp1=tempk->RptDataTop;
			//   while(temp1 !=NULL)
			//   {
			//	    x = ReadDataVal(temp1,TRUE);
			//	    tempk->Data.Zsigma[0] += sqr(x-tempk->Data.Zavg[0]);
			//	    x = ReadDataVal(temp1,FALSE);
			//	    tempk->Data.Zsigma[1] += sqr(x-tempk->Data.Zavg[1]);
			//	    tot++;
			//	    temp1 = temp1->next;
			//   }

			intCounter = 0;
			for (intRowCounter = 0; intRowCounter <= objAbsRepeat.AbsRepeatData.Count - 1; intRowCounter++) {
				//---make a counter upto number of repeats
				if (objAbsRepeat.AbsRepeatData.item(intRowCounter).Used == true) {
					//---check a above cond ,if true then store it in a temp variable.
					dblX = objAbsRepeat.AbsRepeatData.item(intRowCounter).Abs;
					objAbsRepeat.BasicStat.ZSigma(0) += Math.Pow(dblX - objAbsRepeat.BasicStat.ZAvg(0), 2);

					dblX = objAbsRepeat.AbsRepeatData.item(intRowCounter).Concentration;
					objAbsRepeat.BasicStat.ZSigma(1) += Math.Pow(dblX - objAbsRepeat.BasicStat.ZAvg(1), 2);
					intCounter += 1;
					//---added by deepak on 22.07.07
					intTot += 1;
				}
			}

			//   if (tot>1)
			//   {
			//	    tempk->Data.Zsigma[0] /= (double) (tot-1);
			//	    tempk->Data.Zsigma[1] /= (double) (tot-1);
			//	}

			//If (tot > 1) Then
			//    objAbsRepeat.BasicStat.ZSigma(0) /= (intCounter - 1)
			//    objAbsRepeat.BasicStat.ZSigma(1) /= (intCounter - 1)
			//End If

			if ((intTot > 1)) {
				objAbsRepeat.BasicStat.ZSigma(0) /= (intTot - 1);
				objAbsRepeat.BasicStat.ZSigma(1) /= (intTot - 1);
			}

			//   tempk->Data.Var[0] = tempk->Data.Zsigma[0];
			//   tempk->Data.Var[1] = tempk->Data.Zsigma[1];
			//   tempk->Data.Zsigma[0] = sqrt(tempk->Data.Zsigma[0]);
			//   tempk->Data.Zsigma[1] = sqrt(tempk->Data.Zsigma[1]);

			//---variance
			objAbsRepeat.BasicStat.Var(0) = objAbsRepeat.BasicStat.ZSigma(0);
			objAbsRepeat.BasicStat.Var(1) = objAbsRepeat.BasicStat.ZSigma(1);

			//----standard deviation formula
			objAbsRepeat.BasicStat.ZSigma(0) = Math.Sqrt(objAbsRepeat.BasicStat.ZSigma(0));
			objAbsRepeat.BasicStat.ZSigma(1) = Math.Sqrt(objAbsRepeat.BasicStat.ZSigma(1));

			//   if (tot>0)
			//   {
			//	    if (tempk->Data.Zavg[0] != (double) 0.0)
			//		    tempk->Data.CV[0] = (tempk->Data.Zsigma[0]*(double) 100.0)/tempk->Data.Zavg[0];
			//	    if (tempk->Data.Zavg[1] != (double) 0.0)
			//	        tempk->Data.CV[1] = (tempk->Data.Zsigma[1]*(double) 100.0)/tempk->Data.Zavg[1];
			//   }

			//-----calculate coefficient of variance
			if ((intTot > 0)) {
				if ((objAbsRepeat.BasicStat.ZAvg(0) != 0.0)) {
					objAbsRepeat.BasicStat.CV(0) = (objAbsRepeat.BasicStat.ZSigma(0) * 100.0) / objAbsRepeat.BasicStat.ZAvg(0);
				}
				if ((objAbsRepeat.BasicStat.ZAvg(1) != 0.0)) {
					objAbsRepeat.BasicStat.CV(1) = (objAbsRepeat.BasicStat.ZSigma(1) * 100.0) / objAbsRepeat.BasicStat.ZAvg(1);
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

	private static void CalculateMinMax(ref Method.clsAbsRepeat objAbsRepeat)
	{
		//=====================================================================
		// Procedure Name        : CalculateMinMax
		// Parameters Passed     : objAbsRepeat
		// Returns               : bool
		// Purpose               : to calculate Min and Max.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh
		// Created               : 08.11.06
		// Revisions             : Deepak B.
		//=====================================================================

		//void(CalCulateMinMax(ABSREPEAT * tempk))
		//{
		//ABSREPEATDATA	*temp1=NULL;
		//double   		x=0;

		//  tempk->Data.Min[0] = tempk->Data.Min[1] =(double) 1000000.0;
		//  tempk->Data.Max[0] = tempk->Data.Max[1] =(double)  -1.0;
		//  temp1=tempk->RptDataTop;
		//  while(temp1 !=NULL){
		//	 x = ReadDataVal(temp1,TRUE);
		//	 if (x>tempk->Data.Max[0])
		//	  tempk->Data.Max[0] = x;
		//	 if (x<tempk->Data.Min[0])
		//		  tempk->Data.Min[0] =x;
		//	 x = ReadDataVal(temp1,FALSE);
		//	 if (x>tempk->Data.Max[1])
		//	  tempk->Data.Max[1] = x;
		//	 if (x<tempk->Data.Min[1])
		//		  tempk->Data.Min[1] =x;
		//	 temp1 = temp1->next;
		//	}
		////  tempk->Zrange= fabs(tempk->Max-tempk->Min);
		//}

		double dblX;
		int intCounter;
		int intRowCounter;
		try {
			//---Initialize variables
			objAbsRepeat.BasicStat.Min(0) = 1000000.0;
			objAbsRepeat.BasicStat.Min(1) = 1000000.0;

			objAbsRepeat.BasicStat.Max(0) = -1.0;
			objAbsRepeat.BasicStat.Max(1) = -1.0;

			for (intRowCounter = 0; intRowCounter <= objAbsRepeat.AbsRepeatData.Count - 1; intRowCounter++) {
				//----if this repeat number is used in edit data then
				if (objAbsRepeat.AbsRepeatData.item(intRowCounter).Used == true) {
					//---check a cond if true then store a temp value.
					dblX = objAbsRepeat.AbsRepeatData.item(intRowCounter).Abs;
					if ((dblX > objAbsRepeat.BasicStat.Max(0))) {
						objAbsRepeat.BasicStat.Max(0) = dblX;
					}
					if ((dblX < objAbsRepeat.BasicStat.Min(0))) {
						objAbsRepeat.BasicStat.Min(0) = dblX;
					}

					//---changed by deepak on 22.07.07
					//---x = objAbsRepeat.AbsRepeatData.item(intRowCounter).Abs
					dblX = objAbsRepeat.AbsRepeatData.item(intRowCounter).Concentration;
					if ((dblX > objAbsRepeat.BasicStat.Max(1))) {
						objAbsRepeat.BasicStat.Max(1) = dblX;
					}
					if ((dblX < objAbsRepeat.BasicStat.Min(1))) {
						objAbsRepeat.BasicStat.Min(1) = dblX;
					}
					intCounter += 1;
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

}
