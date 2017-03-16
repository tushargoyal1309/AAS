Imports AAS203Library
Imports AAS203Library.Method
Imports AAS203Library.Analysis
'---these are like the headers files.


Public Class clsBasicStatistics

#Region " Public Shared Functions "

    Public Shared Function CalculateBasicStats(ByRef objAbsRepeat As Method.clsAbsRepeat) As Boolean
        '=====================================================================
        ' Procedure Name        : CalculateBasicStats
        ' Parameters Passed     : objAbsRepeat
        ' Returns               : bool
        ' Purpose               : To calculate basic statistics
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak B.
        ' Created               : 08.11.06
        ' Revisions             : 
        '=====================================================================
        'void CalculateBasicStats(ABSREPEAT	*AbsRepeat)
        '{
        '   if (AbsRepeat==NULL)
        '       return;
        '   CalculateAvg(AbsRepeat);
        '   CalculateSigma(AbsRepeat);
        '   CalCulateMinMax(AbsRepeat);
        '}
        Dim intRepCount, intRepCounter As Integer
        Try
            If IsNothing(objAbsRepeat) Then
                '---check for objAbsRepeat object.
                Return False
            End If
            If IsNothing(objAbsRepeat.AbsRepeatData) Then
                '---check for AbsRepeatData
                Return False
            End If

            '---to calculate average
            Call CalculateAvg(objAbsRepeat)
            '---To Calculate CV,Variance, and standard deviation
            Call CalculateSigma(objAbsRepeat)
            '---to calculate min and max
            Call CalculateMinMax(objAbsRepeat)

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

#Region " Private Shared Functions "

    Private Shared Sub CalculateAvg(ByRef objAbsRepeat As Method.clsAbsRepeat)
        '=====================================================================
        ' Procedure Name        : CalculateAvg
        ' Parameters Passed     : objAbsRepeat
        ' Returns               : bool
        ' Purpose               : To calculate Avg
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh
        ' Created               : 08.11.06
        ' Revisions             : Deepak B.
        '=====================================================================
        'void(CalculateAvg(ABSREPEAT * tempk))
        '{
        'ABSREPEATDATA	*temp1=NULL;
        'double   		x=0;
        'int 				tot=0;

        '  tempk->Data.Zavg[0]=tempk->Data.Zavg[1] = (double) 0.0;
        '  tot=0;
        '  temp1=tempk->RptDataTop;
        '  while(temp1 !=NULL){
        '	 x = ReadDataVal(temp1, TRUE);
        '	 (tempk->Data.Zavg[0]) +=x;
        '	 x = ReadDataVal(temp1, FALSE);
        '	 (tempk->Data.Zavg[1]) +=x;
        '	 tot++;
        '	 temp1 = temp1->next;
        '	}
        ' tempk->Data.TotData[0]= tempk->Data.TotData[1]=tot;
        '  if (tot!=0){
        '	 (tempk->Data.Zavg[0]) /= (double) tot;
        '	 (tempk->Data.Zavg[1]) /= (double) tot;
        '	}
        '}

        Dim dblX As Double
        Dim intCounter As Integer
        Dim intRowCounter As Integer
        Try
            objAbsRepeat.BasicStat.ZAvg(0) = 0.0
            objAbsRepeat.BasicStat.ZAvg(1) = 0.0
            intCounter = 0

            For intRowCounter = 0 To objAbsRepeat.AbsRepeatData.Count - 1
                '---make a counter upto number of repeats
                '---if this repeat number is used in edit data then 
                If objAbsRepeat.AbsRepeatData.item(intRowCounter).Used = True Then
                    '---check a condition , if true then store in a temp variable.
                    dblX = objAbsRepeat.AbsRepeatData.item(intRowCounter).Abs
                    objAbsRepeat.BasicStat.ZAvg(0) += dblX

                    dblX = objAbsRepeat.AbsRepeatData.item(intRowCounter).Concentration
                    objAbsRepeat.BasicStat.ZAvg(1) += dblX
                    intCounter += 1
                End If
            Next

            objAbsRepeat.BasicStat.TotData(0) = intCounter
            objAbsRepeat.BasicStat.TotData(1) = intCounter

            If (intCounter <> 0) Then
                objAbsRepeat.BasicStat.ZAvg(0) /= intCounter
                objAbsRepeat.BasicStat.ZAvg(1) /= intCounter
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

    Private Shared Sub CalculateSigma(ByRef objAbsRepeat As Method.clsAbsRepeat)
        '=====================================================================
        ' Procedure Name        : CalculateSigma
        ' Parameters Passed     : objAbsRepeat
        ' Returns               : bool
        ' Purpose               : to calculate Sigma
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh
        ' Created               : 08.11.06
        ' Revisions             : Removed some calculation mistakes by Deepak B.
        '=====================================================================
        'void CalculateSigma(ABSREPEAT * tempk)
        '{
        '   ABSREPEATDATA   *temp1  = NULL;
        '   double   	    x       = 0;
        '   int 			tot     = 0;
        '   for(tot=0;tot<2; tot++)
        '	    tempk->Data.Zsigma[tot] = tempk->Data.CV[tot]=tempk->Data.Var[tot]=(double)0.0;
        '   tot=0;
        '   temp1=tempk->RptDataTop;
        '   while(temp1 !=NULL)
        '   {
        '	    x = ReadDataVal(temp1,TRUE);
        '	    tempk->Data.Zsigma[0] += sqr(x-tempk->Data.Zavg[0]);
        '	    x = ReadDataVal(temp1,FALSE);
        '	    tempk->Data.Zsigma[1] += sqr(x-tempk->Data.Zavg[1]);
        '	    tot++;
        '	    temp1 = temp1->next;
        '   }
        '   if (tot>1)
        '   {
        '	    tempk->Data.Zsigma[0] /= (double) (tot-1);
        '	    tempk->Data.Zsigma[1] /= (double) (tot-1);
        '	}
        '   tempk->Data.Var[0] = tempk->Data.Zsigma[0];
        '   tempk->Data.Var[1] = tempk->Data.Zsigma[1];
        '   tempk->Data.Zsigma[0] = sqrt(tempk->Data.Zsigma[0]);
        '   tempk->Data.Zsigma[1] = sqrt(tempk->Data.Zsigma[1]);
        '   if (tot>0)
        '   {
        '	    if (tempk->Data.Zavg[0] != (double) 0.0)
        '		    tempk->Data.CV[0] = (tempk->Data.Zsigma[0]*(double) 100.0)/tempk->Data.Zavg[0];
        '	    if (tempk->Data.Zavg[1] != (double) 0.0)
        '	        tempk->Data.CV[1] = (tempk->Data.Zsigma[1]*(double) 100.0)/tempk->Data.Zavg[1];
        '   }
        '}

        Dim dblX As Double
        Dim intTot As Integer
        Dim intCounter As Integer
        Dim intRowCounter As Integer

        Try
            For intTot = 0 To 2 - 1
                '---initialise  variables
                objAbsRepeat.BasicStat.ZSigma(intTot) = 0.0
                objAbsRepeat.BasicStat.CV(intTot) = 0.0
                objAbsRepeat.BasicStat.Var(intTot) = 0.0
            Next intTot

            intTot = 0

            '   temp1=tempk->RptDataTop;
            '   while(temp1 !=NULL)
            '   {
            '	    x = ReadDataVal(temp1,TRUE);
            '	    tempk->Data.Zsigma[0] += sqr(x-tempk->Data.Zavg[0]);
            '	    x = ReadDataVal(temp1,FALSE);
            '	    tempk->Data.Zsigma[1] += sqr(x-tempk->Data.Zavg[1]);
            '	    tot++;
            '	    temp1 = temp1->next;
            '   }

            intCounter = 0
            For intRowCounter = 0 To objAbsRepeat.AbsRepeatData.Count - 1
                '---make a counter upto number of repeats
                If objAbsRepeat.AbsRepeatData.item(intRowCounter).Used = True Then
                    '---check a above cond ,if true then store it in a temp variable.
                    dblX = objAbsRepeat.AbsRepeatData.item(intRowCounter).Abs
                    objAbsRepeat.BasicStat.ZSigma(0) += Math.Pow(dblX - objAbsRepeat.BasicStat.ZAvg(0), 2)

                    dblX = objAbsRepeat.AbsRepeatData.item(intRowCounter).Concentration
                    objAbsRepeat.BasicStat.ZSigma(1) += Math.Pow(dblX - objAbsRepeat.BasicStat.ZAvg(1), 2)
                    intCounter += 1
                    '---added by deepak on 22.07.07
                    intTot += 1
                End If
            Next intRowCounter

            '   if (tot>1)
            '   {
            '	    tempk->Data.Zsigma[0] /= (double) (tot-1);
            '	    tempk->Data.Zsigma[1] /= (double) (tot-1);
            '	}

            'If (tot > 1) Then
            '    objAbsRepeat.BasicStat.ZSigma(0) /= (intCounter - 1)
            '    objAbsRepeat.BasicStat.ZSigma(1) /= (intCounter - 1)
            'End If

            If (intTot > 1) Then
                objAbsRepeat.BasicStat.ZSigma(0) /= (intTot - 1)
                objAbsRepeat.BasicStat.ZSigma(1) /= (intTot - 1)
            End If

            '   tempk->Data.Var[0] = tempk->Data.Zsigma[0];
            '   tempk->Data.Var[1] = tempk->Data.Zsigma[1];
            '   tempk->Data.Zsigma[0] = sqrt(tempk->Data.Zsigma[0]);
            '   tempk->Data.Zsigma[1] = sqrt(tempk->Data.Zsigma[1]);

            '---variance
            objAbsRepeat.BasicStat.Var(0) = objAbsRepeat.BasicStat.ZSigma(0)
            objAbsRepeat.BasicStat.Var(1) = objAbsRepeat.BasicStat.ZSigma(1)

            '----standard deviation formula
            objAbsRepeat.BasicStat.ZSigma(0) = Math.Sqrt(objAbsRepeat.BasicStat.ZSigma(0))
            objAbsRepeat.BasicStat.ZSigma(1) = Math.Sqrt(objAbsRepeat.BasicStat.ZSigma(1))

            '   if (tot>0)
            '   {
            '	    if (tempk->Data.Zavg[0] != (double) 0.0)
            '		    tempk->Data.CV[0] = (tempk->Data.Zsigma[0]*(double) 100.0)/tempk->Data.Zavg[0];
            '	    if (tempk->Data.Zavg[1] != (double) 0.0)
            '	        tempk->Data.CV[1] = (tempk->Data.Zsigma[1]*(double) 100.0)/tempk->Data.Zavg[1];
            '   }

            '-----calculate coefficient of variance
            If (intTot > 0) Then
                If (objAbsRepeat.BasicStat.ZAvg(0) <> 0.0) Then
                    objAbsRepeat.BasicStat.CV(0) = (objAbsRepeat.BasicStat.ZSigma(0) * 100.0) / objAbsRepeat.BasicStat.ZAvg(0)
                End If
                If (objAbsRepeat.BasicStat.ZAvg(1) <> 0.0) Then
                    objAbsRepeat.BasicStat.CV(1) = (objAbsRepeat.BasicStat.ZSigma(1) * 100.0) / objAbsRepeat.BasicStat.ZAvg(1)
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

    Private Shared Sub CalculateMinMax(ByRef objAbsRepeat As Method.clsAbsRepeat)
        '=====================================================================
        ' Procedure Name        : CalculateMinMax
        ' Parameters Passed     : objAbsRepeat
        ' Returns               : bool
        ' Purpose               : to calculate Min and Max.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh
        ' Created               : 08.11.06
        ' Revisions             : Deepak B.
        '=====================================================================

        'void(CalCulateMinMax(ABSREPEAT * tempk))
        '{
        'ABSREPEATDATA	*temp1=NULL;
        'double   		x=0;

        '  tempk->Data.Min[0] = tempk->Data.Min[1] =(double) 1000000.0;
        '  tempk->Data.Max[0] = tempk->Data.Max[1] =(double)  -1.0;
        '  temp1=tempk->RptDataTop;
        '  while(temp1 !=NULL){
        '	 x = ReadDataVal(temp1,TRUE);
        '	 if (x>tempk->Data.Max[0])
        '	  tempk->Data.Max[0] = x;
        '	 if (x<tempk->Data.Min[0])
        '		  tempk->Data.Min[0] =x;
        '	 x = ReadDataVal(temp1,FALSE);
        '	 if (x>tempk->Data.Max[1])
        '	  tempk->Data.Max[1] = x;
        '	 if (x<tempk->Data.Min[1])
        '		  tempk->Data.Min[1] =x;
        '	 temp1 = temp1->next;
        '	}
        '//  tempk->Zrange= fabs(tempk->Max-tempk->Min);
        '}

        Dim dblX As Double
        Dim intCounter As Integer
        Dim intRowCounter As Integer
        Try
            '---Initialize variables
            objAbsRepeat.BasicStat.Min(0) = 1000000.0
            objAbsRepeat.BasicStat.Min(1) = 1000000.0

            objAbsRepeat.BasicStat.Max(0) = -1.0
            objAbsRepeat.BasicStat.Max(1) = -1.0

            For intRowCounter = 0 To objAbsRepeat.AbsRepeatData.Count - 1
                '----if this repeat number is used in edit data then
                If objAbsRepeat.AbsRepeatData.item(intRowCounter).Used = True Then
                    '---check a cond if true then store a temp value.
                    dblX = objAbsRepeat.AbsRepeatData.item(intRowCounter).Abs
                    If (dblX > objAbsRepeat.BasicStat.Max(0)) Then
                        objAbsRepeat.BasicStat.Max(0) = dblX
                    End If
                    If (dblX < objAbsRepeat.BasicStat.Min(0)) Then
                        objAbsRepeat.BasicStat.Min(0) = dblX
                    End If

                    '---changed by deepak on 22.07.07
                    '---x = objAbsRepeat.AbsRepeatData.item(intRowCounter).Abs
                    dblX = objAbsRepeat.AbsRepeatData.item(intRowCounter).Concentration
                    If (dblX > objAbsRepeat.BasicStat.Max(1)) Then
                        objAbsRepeat.BasicStat.Max(1) = dblX
                    End If
                    If (dblX < objAbsRepeat.BasicStat.Min(1)) Then
                        objAbsRepeat.BasicStat.Min(1) = dblX
                    End If
                    intCounter += 1
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

#End Region

End Class
