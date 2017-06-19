Option Explicit On 

Imports System.IO
Imports System.Collections
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters
Imports System.Runtime.Serialization.Formatters.Binary
Imports Microsoft.Win32
Imports AAS203Library.Instrument
Imports System.Diagnostics
Imports System.Runtime.InteropServices

Module modGlobalFunctions

    Public Declare Function Beep2 Lib "kernel32" Alias "Beep" _
    (ByVal freq As Integer, ByVal dir As Integer) _
    As Integer

    Public Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)


#Region " Public Global Functions "

    Public Function gFuncGetmv(ByVal intInVal As Integer) As Double
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   gFuncGetmv
        'Description            :   
        'Parameters             :   intInVal as integer
        'Time/Date              :   
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Deepak B. on 17.11.06
        '--------------------------------------------------------------------------------------
        '        double S4FUNC GetmV(int adval)
        '{
        'double mv=0.0;
        ' mv = ((double)adval-(double)2047.0)/(double)4096.0*(double)10000.0;
        ' return mv;
        '}
        '---------
        Try
            '---convert adc filter reading into millivolt by using 
            '---following formula
            gFuncGetmv = (CDbl(intInVal) - CDbl(4095.0)) / 8192.0 * 10000.0
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

    Public Function gFuncGetEmission(ByVal intInVal As Integer) As Double
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   gFuncGetEmission
        'Description            :   
        'Parameters             :   intInVal as integer
        'Time/Date              :   
        'Dependencies           :   ADC filter reading
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Deepak B. on 31.12.06
        '--------------------------------------------------------------------------------------
        Try
            ' Return Emission value from given integer value
            ' as adc filter reading
            Return (CDbl(intInVal) - 4095.0) / 8192.0 * 200.0

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

    Public Function gFuncGetEnergy(ByVal intInVal As Integer) As Double
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   gFuncGetEnergy
        'Description            :   
        'Parameters             :   intInVal as integer
        'Time/Date              :   
        'Dependencies           :     
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Deepak B. on 31.12.06
        '--------------------------------------------------------------------------------------
        Try
            ' Return Energy value from given integer value
            Return gFuncGetEmission(intInVal)

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

    Public Function gFuncGetAbs(ByVal intInVal As Integer) As Double
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   gFuncGetAbs
        'Description            :   
        'Parameters             :   intInVal as integer
        'Time/Date              :   
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Deepak B. on 31.12.06
        '--------------------------------------------------------------------------------------
        Try
            ' Return Abs value from given integer value
            'abs = ((double)adval-(double)2047.0)/(double)4096.0*(double)5.0;

            Return (CDbl(intInVal) - 4095.0) / 8192.0 * 5.0

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

    Public Function gFuncGetADConvertedToCurMode(ByVal intInVal As Integer) As Double
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   gFuncGetADConvertedToCurMode
        'Description            :   
        'Parameters             :   intInVal as integer
        'Time/Date              :   
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Deepak B. on 31.12.06
        '--------------------------------------------------------------------------------------
        Try
            ' Convert ADC Value into current calibration mode value
            Return gfuncGetADConvertedIntoMode(intInVal, gobjInst.Mode)

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

    Public Function gfuncGetADConvertedIntoMode(ByVal intInVal As Integer, ByVal mode As EnumCalibrationMode) As Double
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   gfuncGetADConvertedIntoMode
        'Description            :   
        'Parameters             :   intInVal as integer,mode as integer
        'Time/Date              :   
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Deepak B. on 31.12.06
        '--------------------------------------------------------------------------------------
        Dim dblVal As Double
        Dim str As String

        Try
            ' Convert ADC Value into given calibration mode
            Select Case mode
                '1.	If calibration mode is AA,AABGC,MABS,AABGCSR then return
                '(ADC filter reading - 4095.0) / 8192.0 * 5.0
                Case EnumCalibrationMode.AA, EnumCalibrationMode.AABGC, EnumCalibrationMode.MABS, EnumCalibrationMode.AABGCSR
                    ' Conver into ABS Mode
                    dblVal = gFuncGetAbs(intInVal)

                    '2.	If calibration mode is HCLE,D2E,Emission then return
                    '(ADC filter reading - 4095.0) / 8192.0 * 200.0
                Case EnumCalibrationMode.HCLE, EnumCalibrationMode.EMISSION, EnumCalibrationMode.D2E
                    ' Conver into Emission or Energy Mode
                    dblVal = gFuncGetEmission(intInVal)

                    '3.	If calibration mode is selftest then return
                    '(ADC filter reading - 4095.0) / 8192.0 * 10000.0
                Case EnumCalibrationMode.SELFTEST
                    ' Conver into Mv for Self Test Mode
                    dblVal = gFuncGetmv(intInVal)

            End Select

            Return dblVal

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

    Public Function gfuncGetADConvertedTo(ByVal intADValue As Integer, ByVal intOperationMode As EnumOperationMode) As Double
        '--------------------------------------------------------------------------------------
        'Procedure Name         :   gfuncGetADConvertedTo
        'Description            :   
        'Parameters             :   ADC Value as integer, Operation Mode as integer
        'Time/Date              :   11-Jan-2007 12:15 pm
        'Dependencies           :   
        'Author                 :   Mangesh Shardul
        'Revision               :   1
        'Revision by Person     :   Sachin Dokhale
        '--------------------------------------------------------------------------------------

        '*********************************************************************************
        '--- ORIGINAL CODE
        '*********************************************************************************
        'double	S4FUNC	GetADConvertedTo(int adval, int mode)
        '{
        'char	str[20]="";
        'double val=0;

        'if( GetInstrument() == AA202 )
        '{
        '            Switch(Mode)
        '	{
        '		case MODE_AA:
        '		case MODE_AABGC:
        '		case MODE_SPECT:
        '			val=GetAbs(adval);
        '			StoreAbsAccurate(val,str);
        '//			sprintf(str,"%-4.3f",val);
        '			val=(double) atof(str);
        '			break;

        '		case MODE_EMMISSION:
        '			val=GetEmission(adval);
        '			sprintf(str,"%-4.1f",val);
        '			val=(double) atof(str);
        '			break;
        '/*
        '		case MODE_SPECT:
        '			val=GetmV(adval);
        '			sprintf(str,"%-4.1f",val);
        '			val=(double) atof(str);
        '			break;  */
        '	}
        '}
        'else{
        '            Switch(Mode)
        '	{
        '		case	MODE_AA:
        '		case  MODE_AABGC:
        '	//	case  MODE_UVABS:
        '			val=GetAbs(adval);
        '//			sprintf(str,"%-4.3f",val);
        '			StoreAbsAccurate(val,str);
        '			val=(double) atof(str);
        '			break;

        '		case MODE_EMMISSION:
        '			val=GetEmission(adval);
        '			sprintf(str,"%-4.1f",val);
        '			val=(double) atof(str);
        '			break;

        '		case MODE_SPECT:
        '			val=GetmV(adval);
        '			sprintf(str,"%-4.1f",val);
        '			val=(double) atof(str);
        '			break;
        '	}
        '}
        'return val;
        '}
        '*********************************************************************************
        Dim dblNewADValue As Double

        Try
            ' Convert ADC Value into given Operation mode
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                Select Case intOperationMode
                    Case modGlobalConstants.EnumOperationMode.MODE_AA, _
                        modGlobalConstants.EnumOperationMode.MODE_AABGC, _
                        modGlobalConstants.EnumOperationMode.MODE_SPECT
                        'MODE_AA, MODE_AABGC

                        '---convert adc value to absorbance value
                        dblNewADValue = gFuncGetAbs(intADValue)
                        'StoreAbsAccurate(dblNewADValue)

                    Case modGlobalConstants.EnumOperationMode.MODE_EMMISSION
                        'MODE_EMMISSION

                        '---convert adc value to emission value
                        dblNewADValue = gFuncGetEmission(intADValue)

                        'Case modGlobalConstants.EnumOperationMode.MODE_SPECT
                        'MODE_SPECT
                        'dblNewADValue = gFuncGetmv(intADValue)
                End Select

            Else
                Select Case intOperationMode
                    Case modGlobalConstants.EnumOperationMode.MODE_AA, modGlobalConstants.EnumOperationMode.MODE_AABGC
                        'MODE_AA, MODE_AABGC

                        '---convert adc value to absorbance value
                        dblNewADValue = gFuncGetAbs(intADValue)
                        'StoreAbsAccurate(dblNewADValue)

                    Case modGlobalConstants.EnumOperationMode.MODE_EMMISSION
                        'MODE_EMMISSION

                        '---convert adc value to emission value
                        dblNewADValue = gFuncGetEmission(intADValue)

                    Case modGlobalConstants.EnumOperationMode.MODE_SPECT
                        'MODE_SPECT

                        '---convert adc value to millivolt
                        dblNewADValue = gFuncGetmv(intADValue)

                End Select
            End If

            Return dblNewADValue

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

    Public Function gfuncTurretStepsForLampTop(ByVal TurretPosition As Integer) As Int16
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   gfuncTurretStepsForLampTop
        'Description            :   
        'Parameters             :   TurretPosition as integer
        'Time/Date              :   
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Deepak B. on 31.12.06
        '--------------------------------------------------------------------------------------
        '   if (p1->lamp<2)   nosteps = TARRATIO*(3.0+(p1->lamp)*2.0/3.0);
        'else  nosteps = TARRATIO*((p1->lamp-2)*2.0+1.0)/3.0;
        '--------------------------------------------------------------------------------------

        Try
            '--To calculate Turret STeps required to set turret at top position to insert or remove lamp
            '---where TARRATIO = 700.0
            If (TurretPosition - 1) < 2 Then
                gfuncTurretStepsForLampTop = TARRATIO * (3.0 + (TurretPosition - 1) * 2 / 3)
            Else
                gfuncTurretStepsForLampTop = TARRATIO * (((TurretPosition - 1) - 2) * 2 + 1) / 3
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

    Public Function gfuncGetConvertToUVAbs(ByVal intSampleValue As Integer, ByVal RefValue As Integer) As Integer
        '=====================================================================
        ' Procedure Name        : gfuncGetConvertToUVAbs
        ' Parameters Passed     : ByVal intSampleValue, ByVal RefValue 
        ' Returns               : Integer
        ' Purpose               : Convert into Abs to the Sampel Value and Ref Value
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 03.12.06
        ' Revisions             : 
        '=====================================================================
        Dim intYnew As Integer = 0
        Dim dblCalAbs As Double = 0.0

        Try
            '            int	ynew=0;
            'double	k=0;
            '            If (refval! = 2047.0) Then
            '  k = ((double)sampval-(double)2047.0)/((double)refval-(double)2047.0)*(double)100.0;
            ' if (k>(double)0.0)
            '	 k = 2.0-log10(k);
            '                Else
            '	k=(double)0.0;
            ' k = (double) 2047.0+(k/(double)2.0)*((double)1638.4);
            ' ynew =(int) k;

            ' Convert into Abs to the Sampel Value and Ref Value
            If Not (RefValue = 2047) Then
                dblCalAbs = (CDbl(intSampleValue) - 2047) / (CDbl(RefValue) - 2047.0) * 100.0
            End If
            If dblCalAbs > 0.0 Then
                dblCalAbs = 2.0 - Math.Log10(dblCalAbs)
            Else
                dblCalAbs = 0.0
            End If
            dblCalAbs = 2047.0 + (dblCalAbs / 2.0) * (1638.4)
            intYnew = CInt(dblCalAbs)
            Return intYnew

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return 0
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
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

    Public Function gfuncGetValueInSpectrum(ByVal intValue As Integer, ByVal intMode As Integer) As Double
        '=====================================================================
        ' Procedure Name        : gfuncGetValueInSpectrum
        ' Parameters Passed     : Byval intValue , ByVal intMode 
        ' Returns               : Double
        ' Purpose               : Get the Ratio  of Fuel
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 03.12.06
        ' Revisions             : 
        '=====================================================================
        Dim dblAbs As Double = 0.0

        Try
            '//------------------
            'double	abs=0.0;
            '            If (!UVS) Then
            '	abs = GetADConvertedIntoMode(val, mode);
            ' else{
            '                If (UVABS) Then
            '		abs = GetADConvertedIntoMode(val, AA);
            '                Else
            '	abs = GetADConvertedIntoMode(val, D2E);
            '  }
            ' return abs;
            '//------------------
            ' Convert ADC Value into given calibration mode if not UVABS
            If Not (gblnUVS = True) Then
                dblAbs = gfuncGetADConvertedIntoMode(intValue, intMode)
            Else
                ' Convert ADC Value into Energy or Abs Mode  if UVABS
                If gblnUVABS = True Then
                    dblAbs = gfuncGetADConvertedIntoMode(intValue, modGlobalConstants.EnumCalibrationMode.AA)
                Else
                    dblAbs = gfuncGetADConvertedIntoMode(intValue, modGlobalConstants.EnumCalibrationMode.D2E)
                End If
            End If

            Return dblAbs

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return 0.0
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
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

    Public Function funcSaveAllMethods(ByVal obj As Object) As Boolean
        '=====================================================================
        ' Procedure Name        : funcSaveAllMethods
        ' Parameters Passed     : Object
        ' Returns               : True or False
        ' Purpose               : To serialize the clsMethodCollection object
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 13-Apr-2007
        ' Revisions             : 
        '=====================================================================
        Dim strFileName As String

        Try
            'following block of code is written by deepak on 29.07.07
            ' select the file location for Diff. instrument condition
            Select Case gstructSettings.AppMode
                Case EnumAppMode.DemoMode
                    strFileName = Application.StartupPath & "\" & ConstMethodsFileName
                Case EnumAppMode.FullVersion_203
                    strFileName = Application.StartupPath & "\" & ConstMethodsFileName
                Case EnumAppMode.FullVersion_203D
                    strFileName = Application.StartupPath & "\" & ConstDBMethodsFileName
                Case EnumAppMode.FullVersion_201
                    strFileName = Application.StartupPath & "\" & ConstMethodsFileName
                Case EnumAppMode.DemoMode_203D
                    strFileName = Application.StartupPath & "\" & ConstDBMethodsFileName
                Case EnumAppMode.DemoMode_201
                    strFileName = Application.StartupPath & "\" & ConstMethodsFileName
                Case Else
                    strFileName = Application.StartupPath & "\" & ConstMethodsFileName
            End Select

            'If gstructSettings.AppMode = EnumAppMode.FullVersion_203 Then
            '    strFileName = Application.StartupPath & "\" & ConstMethodsFileName
            'ElseIf gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
            '    strFileName = Application.StartupPath & "\" & ConstDBMethodsFileName
            'Else
            '    If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
            '        strFileName = Application.StartupPath & "\" & ConstMethodsFileName
            '    Else
            '        strFileName = Application.StartupPath & "\" & ConstMethodsFileName
            '    End If
            'End If
            ' Serialise the method collection data into filer system
            If funcSerialize(strFileName, obj) Then
                Return True
            Else
                Return False
            End If

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

    Public Function funcLoadAllMethods(ByRef obj As Object) As Boolean
        '=====================================================================
        ' Procedure Name        : funcLoadAllMethods
        ' Parameters Passed     : 
        ' Returns               : True or False
        ' Purpose               : To Deserialize the clsMethodCollection object
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 13-Apr-2007
        ' Revisions             : 
        '=====================================================================
        Dim strFileName As String

        Try
            'following block of code is written by deepak on 29.07.07
            ' select the file location for Diff. instrument condition
            Select Case gstructSettings.AppMode
                Case EnumAppMode.DemoMode
                    strFileName = Application.StartupPath & "\" & ConstMethodsFileName
                Case EnumAppMode.FullVersion_203
                    strFileName = Application.StartupPath & "\" & ConstMethodsFileName
                Case EnumAppMode.FullVersion_203D
                    strFileName = Application.StartupPath & "\" & ConstDBMethodsFileName
                Case EnumAppMode.FullVersion_201
                    strFileName = Application.StartupPath & "\" & ConstMethodsFileName
                Case EnumAppMode.DemoMode_203D
                    strFileName = Application.StartupPath & "\" & ConstDBMethodsFileName
                Case EnumAppMode.DemoMode_201
                    strFileName = Application.StartupPath & "\" & ConstMethodsFileName
                Case Else
                    strFileName = Application.StartupPath & "\" & ConstMethodsFileName
            End Select

            'If gstructSettings.AppMode = EnumAppMode.FullVersion_203 Then
            '    strFileName = Application.StartupPath & "\" & ConstMethodsFileName
            'ElseIf gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
            '    strFileName = Application.StartupPath & "\" & ConstDBMethodsFileName
            'Else
            '    If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
            '        strFileName = Application.StartupPath & "\" & ConstMethodsFileName
            '    Else
            '        strFileName = Application.StartupPath & "\" & ConstMethodsFileName
            '    End If
            'End If
            ' Deserialise the method collection data from filer system
            If File.Exists(strFileName) Then
                If funcDeSerialize(strFileName, obj) Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try
    End Function

    Public Function funcSaveInstStatus() As Boolean
        '=====================================================================
        ' Procedure Name        : funcSaveInstStatus
        ' Parameters Passed     : None
        ' Returns               : True or False
        ' Purpose               : To serialize the object gobjinst
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 18.11.06
        ' Revisions             : 
        '=====================================================================
        Dim strPath As String
        Try
            ' serialize the object gobjinst

            '---03.12.07 Deepak
            strPath = Application.StartupPath & "\" & ConstInstFileName

            'If funcSerialize(ConstInstFileName, gobjInst.Lamp) = True Then
            If funcSerialize(strPath, gobjInst.Lamp) = True Then
                Return True
            Else
                Return False
            End If

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

    Public Function funcLoadInstStatus() As Boolean
        '=====================================================================
        ' Procedure Name        : funcLoadInstStatus
        ' Parameters Passed     : None
        ' Returns               : True or False
        ' Purpose               : To deserialize the object gobjinst
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 18.11.06
        ' Revisions             : 
        '=====================================================================
        Try
            'deserialize the object gobjinst
            If File.Exists(Application.StartupPath & "\" & ConstInstFileName) = True Then
                ''If funcDeSerialize(ConstInstFileName, gobjInst.Lamp) = True Then
                If funcDeSerialize(Application.StartupPath & "\" & ConstInstFileName, gobjInst.Lamp) = True Then  '4.85  12.04.09
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If

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

    Public Function funcIsAllLampEmpty() As Boolean
        '=====================================================================
        ' Procedure Name        : funcIsAllLampEmpty
        ' Parameters Passed     : None
        ' Returns               : True or False
        ' Purpose               : To check whether all lamps are empty or not
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 18.11.06
        ' Revisions             : 
        '=====================================================================

        '---------------------------------------------------------------------
        '---16 Bit Software Code
        '---------------------------------------------------------------------
        '    BOOL	S4FUNC IsAllLampEmpty(void)
        '{
        'int	i;
        'BOOL flag=FALSE;

        ' for(i=0;i<6; i++)
        '	if (strcmpi(trim(ltrim(Inst.Lamp_par.lamp[i].elname)),"")!=0)
        '	  break;
        ' if (i==6)
        '	flag=TRUE;
        'return flag;
        '}
        '---------------------------------------------------------------------

        Dim intCount As Integer
        Dim flag As Boolean = False

        Try
            '---19.06.07 following condition is changed by Deepak
            ' Checking of all Lamps are presents
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                For intCount = 0 To 1
                    If Trim(gobjInst.Lamp.LampParametersCollection.item(intCount).ElementName) <> "" Then
                        Exit For
                    End If
                Next
            Else
                For intCount = 0 To 9
                    'If gobjInst.Lamp.LampParametersCollection.item(intCount).ElementName <> "" Then
                    If gobjInst.Lamp.LampParametersCollection.item(intCount).LampOptimizePosition <> 0 Then
                        Exit For
                    End If
                Next
            End If
            
            ' check condition for 201 instrument
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                If intCount = 2 Then
                    flag = True
                End If
            Else
                If intCount = 6 Then
                    flag = True
                End If
            End If

            Return flag

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

    'Private Function gfuncPeakValley()
    '    '=====================================================================
    '    ' Procedure Name        : gfuncPeakValley
    '    ' Parameters Passed     : None
    '    ' Returns               : True
    '    ' Purpose               : Get Peak and Valley
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Sachin Dokhale
    '    ' Created               : 25.11.06
    '    ' Revisions             : 
    '    '=====================================================================
    '    Try

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
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

    'Public Function gFuncGetIndexWv(ByVal dblWavelegth As Double, ByVal blnFlag As Boolean) As Integer
    '    '-----------------------------------  Procedure Header  -------------------------------
    '    'Procedure Name         :   gFuncGetIndexWv  
    '    'Description            :   To get the index wavelength
    '    'Parameters             :
    '    'Time/Date              :   10.32 22/10/03
    '    'Dependencies           :
    '    'Author                 :   Sachin Dokhale
    '    'Revision               :
    '    'Revision by Person     :
    '    '--------------------------------------------------------------------------------------
    '    gFuncGetIndexWv = 0

    '    Dim dblWvData As Double
    '    Dim intDAta As Integer
    '    'Dim dblWvOff As Double = 1900.0
    '    Dim dblWvOff As Double = 1
    '    Try


    '        ' return the index for Wavelength
    '        If blnFlag Then
    '            dblWvData = dblWavelegth
    '        Else
    '            dblWavelegth = gobjInst.WavelengthCur ' gdblCurrent_Wavelength
    '            dblWvData = dblWavelegth
    '        End If

    '        'If dblWavelegth >= gstructConfigurartionSetting.strucRangeX.dblMinimum_Normal_Wv Or dblWavelegth <= gstructConfigurartionSetting.strucRangeX.dblMaximum_Normal_Wv Then
    '        'dblWvData = (dblWvData * 10.0) + 0.05
    '        'dblWvData = (dblWvData * 10.0) + 40
    '        dblWvData = (dblWvData * 10.0) + 0.05
    '        intDAta = CInt(dblWvData)

    '        If intDAta <= 0 Then intDAta = 0
    '        If intDAta >= MAX_RANGE Then intDAta = MAX_RANGE - 1

    '        gFuncGetIndexWv = intDAta

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        'gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex)
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

    Public Function gfuncGetSelectedUVElementWavelength(ByVal objClsInstrumentParameters As AAS203Library.Method.clsInstrumentParameters, Optional ByVal OperationModeIn As EnumOperationMode = modGlobalConstants.EnumOperationMode.MODE_AA) As Double
        '=====================================================================
        ' Procedure Name        : gfuncGetSelectedElementWavelength
        ' Parameters Passed     : Instrument Parameter object of Method Setting
        ' Returns               : Currently Selected Wavelength
        ' Purpose               : To retrieve the currently selected Wavelength from the 
        '                         collection of Wavelengths for a Instrument.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 14-Jul-2007
        ' Revisions             : 
        '=====================================================================
        Dim dblWavelength As Double
        Try
            ' retrieve the currently selected Wavelength from the 
            ' collection of Wavelengths for a Instrument for UV mode
            If Not IsNothing(objClsInstrumentParameters.Wavelength) Then
                If Not IsNothing(objClsInstrumentParameters.Wavelength.Rows.Count > 0) Then
                    'For intRowCounter = 0 To objClsInstrumentParameters.Wavelength.Rows.Count - 1
                    'If CInt(objClsInstrumentParameters.Wavelength.Rows(intRowCounter).Item(ConstColumnAADetailsID)) = objClsInstrumentParameters.SelectedWavelengthID Then
                    dblWavelength = objClsInstrumentParameters.Wavelength.Rows(0).Item(ConstColumnWV)
                    'Exit For
                End If
            End If
            Return dblWavelength

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

    Public Function gfuncGetSelectedElementWavelength(ByVal objClsInstrumentParameters As AAS203Library.Method.clsInstrumentParameters) As Double
        '=====================================================================
        ' Procedure Name        : gfuncGetSelectedElementWavelength
        ' Parameters Passed     : Instrument Parameter object of Method Setting
        ' Returns               : Currently Selected Wavelength
        ' Purpose               : To retrieve the currently selected Wavelength from the 
        '                         collection of Wavelengths for a Instrument.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 14-Dec-2006
        ' Revisions             : 1
        '=====================================================================
        Dim intRowCounter As Integer
        Dim dblWavelength As Double
        Try
            ' retrieve the currently selected Wavelength from the 
            ' collection of Wavelengths for a Instrument.
            If Not IsNothing(objClsInstrumentParameters.Wavelength) Then
                For intRowCounter = 0 To objClsInstrumentParameters.Wavelength.Rows.Count - 1
                    If CInt(objClsInstrumentParameters.Wavelength.Rows(intRowCounter).Item(ConstColumnAADetailsID)) = objClsInstrumentParameters.SelectedWavelengthID Then
                        dblWavelength = objClsInstrumentParameters.Wavelength.Rows(intRowCounter).Item(ConstColumnWV)
                        Exit For
                    End If
                Next
            End If
            Return dblWavelength
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

    Public Function gfuncInit_Lamp_Par(ByRef objLamp As AAS203Library.Instrument.ClsLampParameters) As Boolean
        '=====================================================================
        ' Procedure Name        : gfuncInit_Lamp_Par
        ' Parameters Passed     : objLamp
        ' Returns               : 
        ' Purpose               : 
        ' Description           : To initiate the passed lamp parameters
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 15-Dec-2006
        ' Revisions             : 
        '=====================================================================
        '    void  	S4FUNC 	Init_Lamp_Par(LAMP_PAR *Lamp)
        '{
        '  Lamp->lamp_optpos=-1;
        '  Lamp->mel = FALSE;
        '  strcpy(Lamp->elname, "");
        '  Lamp->Atno =0;
        '  Lamp->cur = 0.0;
        '  Lamp->wv = 0.0;
        '  Lamp->slitwidth = 0.0;
        '  Lamp->mode = AA;
        '  Lamp->burner = TRUE;
        '}
        Try
            ' Init. lamp object parametres (Set default setting for Lamp object)
            objLamp.LampOptimizePosition = -1
            objLamp.Mel = False
            objLamp.ElementName = ""
            objLamp.AtomicNumber = 0
            objLamp.Current = 0.0
            objLamp.Wavelength = 0.0
            objLamp.SlitWidth = 0.0
            objLamp.Mode = 1
            objLamp.Burner = True
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

    Public Function gfuncSet_Lamp_Parameters(ByRef objLamp As AAS203Library.Instrument.ClsLampParameters, ByVal intPos As Integer) As Boolean
        '=====================================================================
        ' Procedure Name        : gfuncSet_Lamp_Parameters
        ' Parameters Passed     : objLamp,intPos
        ' Returns               : 
        ' Purpose               : 
        ' Description           : To set lamp parameters at selected position
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 15-Dec-2006
        ' Revisions             : 
        '=====================================================================
        'void  S4FUNC Set_Lamp_Parameters(LAMP_PAR *Par, int pos)
        '{

        'if (Par==NULL)
        '  return;
        'if (pos>=0 && pos<6){
        '  if (strcmpi(Par->elname,Inst.Lamp_par.lamp[pos].elname)!=0)
        '	Inst.Lamp_par.lamp[pos].lamp_optpos=-1;
        '  Inst.Lamp_par.lamp[pos].mel = Par->mel;
        '  strcpy(Inst.Lamp_par.lamp[pos].elname, Par->elname);
        '  Inst.Lamp_par.lamp[pos].Atno= Par->Atno;
        '  Inst.Lamp_par.lamp[pos].cur = Par->cur;
        '  Inst.Lamp_par.lamp[pos].wv = Par->wv;
        '  Inst.Lamp_par.lamp[pos].slitwidth = Par->slitwidth;
        '  Inst.Lamp_par.lamp[pos].mode = Par->mode ;
        '  Inst.Lamp_par.lamp[pos].burner = Par->burner;
        '  Save_Tuttet_Status();
        ' }
        '}    
        Try
            ' set lamp parameters of Inst. object at given position
            ' given position is "intPos"
            If Not objLamp Is Nothing Then
                If intPos >= 0 And intPos < 10 Then
                    If gobjInst.Lamp.LampParametersCollection.item(intPos).ElementName <> objLamp.ElementName Then
                        gobjInst.Lamp.LampParametersCollection.item(intPos).LampOptimizePosition = -1
                    End If
                    gobjInst.Lamp.LampParametersCollection.item(intPos).Mel = objLamp.Mel
                    gobjInst.Lamp.LampParametersCollection.item(intPos).ElementName = objLamp.ElementName
                    gobjInst.Lamp.LampParametersCollection.item(intPos).AtomicNumber = objLamp.AtomicNumber
                    gobjInst.Lamp.LampParametersCollection.item(intPos).Current = objLamp.Current
                    gobjInst.Lamp.LampParametersCollection.item(intPos).Wavelength = objLamp.Wavelength
                    gobjInst.Lamp.LampParametersCollection.item(intPos).SlitWidth = objLamp.SlitWidth
                    gobjInst.Lamp.LampParametersCollection.item(intPos).Mode = objLamp.Mode
                    gobjInst.Lamp.LampParametersCollection.item(intPos).Burner = objLamp.Burner
                    If gstructSettings.ExeToRun = EnumApplicationMode.AAS Then
                        funcSaveInstStatus()
                    End If
                End If
            End If

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

    Public Function gfuncLamp_connected(ByVal intPos As Integer) As Boolean
        '=====================================================================
        ' Procedure Name        : gfuncLamp_connected
        ' Parameters Passed     : intPos
        ' Returns               : 
        ' Purpose               : 
        ' Description           : To set lamp parameters property lamp optpos at selected position
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 15-Dec-2006
        ' Revisions             : 
        '=====================================================================
        '    void	S4FUNC Lamp_connected(int pos)
        '{
        'Inst.Lamp_par.lamp[pos].lamp_optpos = 0;
        '}
        Try
            ' set lamp parameters property lamp optpos at selected position
            gobjInst.Lamp.LampParametersCollection.item(intPos - 1).LampOptimizePosition = 0

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

    Public Function gfuncGet_Lamp_Parameters(ByRef objLamp As AAS203Library.Instrument.ClsLampParameters, ByVal intPos As Integer) As Boolean
        '=====================================================================
        ' Procedure Name        : gfuncGet_Lamp_Parameters
        ' Parameters Passed     : objLamp,intPos
        ' Returns               : 
        ' Purpose               : 
        ' Description           : To Get lamp parameters for selected position
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 15-Dec-2006
        ' Revisions             : 
        '=====================================================================
        '    void	S4FUNC Get_Lamp_Parameters(LAMP_PAR *Par, int pos)
        '{
        'if (pos>=0 && pos<6 && Par!=NULL){
        '  Par->mel = Inst.Lamp_par.lamp[pos].mel;
        '  strcpy(Par->elname, Inst.Lamp_par.lamp[pos].elname);
        '  Par->Atno = Inst.Lamp_par.lamp[pos].Atno;
        '  Par->cur = Inst.Lamp_par.lamp[pos].cur;
        '  Par->wv = Inst.Lamp_par.lamp[pos].wv ;
        '  Par->slitwidth = Inst.Lamp_par.lamp[pos].slitwidth ;
        '  Par->mode = Inst.Lamp_par.lamp[pos].mode;
        '  Par->burner = Inst.Lamp_par.lamp[pos].burner ;
        ' }
        '}
        Try
            ' Get lamp parameters for selected position from Inst. object
            If Not objLamp Is Nothing Then
                If intPos >= 0 And intPos < 10 Then
                    objLamp.Mel = gobjInst.Lamp.LampParametersCollection.item(intPos).Mel
                    objLamp.ElementName = gobjInst.Lamp.LampParametersCollection.item(intPos).ElementName
                    objLamp.AtomicNumber = gobjInst.Lamp.LampParametersCollection.item(intPos).AtomicNumber
                    objLamp.Current = gobjInst.Lamp.LampParametersCollection.item(intPos).Current
                    objLamp.Wavelength = gobjInst.Lamp.LampParametersCollection.item(intPos).Wavelength
                    objLamp.SlitWidth = gobjInst.Lamp.LampParametersCollection.item(intPos).SlitWidth
                    objLamp.Mode = gobjInst.Lamp.LampParametersCollection.item(intPos).Mode
                    objLamp.Burner = gobjInst.Lamp.LampParametersCollection.item(intPos).Burner
                End If
            End If

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

    Public Function CheckMethod() As Integer
        '=====================================================================
        ' Procedure Name        : CheckMethod
        ' Parameters Passed     : None
        ' Returns               : Status Value as Integer 
        ' Purpose               : Return Method Status
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        'int CheckMethod(void)
        '{
        '	if (AnaMethod.Nmet>=0 && (AnaMethod.QuantData!=NULL))
        '	{
        '	    if (GetTotStds(AnaMethod.QuantData->StdTopData, FALSE)>0)
        '		    return 2;
        '	}
        '   If (AnaMethod.Nmet > 0) Then
        '	    return 1;
        '	return 3;
        '}
        Try
            '---18.06.07
            ' Return Method Status
            If (gobjNewMethod.MethodID >= 0) Then
                'If gobjNewMethod.QuantitativeDataCollection.Count > 0 Then
                If clsStandardGraph.GetTotStds(gobjNewMethod.StandardDataCollection, False) > 0 Then
                    Return 2
                End If
                'End If
            End If

            If (gobjNewMethod.MethodID > 0) Then
                Return 1
            End If

            Return 3

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

    Public Function gfuncGetSelectedMethodRunNumberIndex(ByVal intSelectedMethodID As Integer, ByVal intSelectedRunNumber As Integer) As Integer
        '=====================================================================
        ' Procedure Name        : gfuncGetSelectedMethodRunNumber
        ' Parameters Passed     : None
        ' Returns               : Selected Index of QuantitativeData item
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 25-Feb-2007 02:25 pm
        ' Revisions             : 1
        '=====================================================================
        Dim intMethodCounter As Integer
        Dim intCounter As Integer
        Dim intRunNumberIndex As Integer

        Try
            'Selected Index of QuantitativeData item from given Method ID and Run Number

            intRunNumberIndex = -1

            For intMethodCounter = 0 To gobjMethodCollection.Count - 1
                If intSelectedMethodID = gobjMethodCollection.item(intMethodCounter).MethodID Then
                    For intCounter = 0 To gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Count - 1
                        If intSelectedRunNumber = CInt(gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Item(intCounter).RunNumber) Then
                            intRunNumberIndex = intCounter
                            Return intRunNumberIndex
                            Exit For
                        End If
                    Next
                End If
            Next intMethodCounter

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return -1
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

#Region " Private Function "

    Private Function gfuncGetPeakValley(ByVal i As Integer, ByVal blnIsPeak As Boolean)
        '=====================================================================
        ' Procedure Name        : gfuncGetPeakValley
        ' Parameters Passed     : None
        ' Returns               : True
        ' Purpose               : Get Peak and Valley
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 25.11.06
        ' Revisions             : 
        '=====================================================================
        Dim k As Integer
        Dim j As Integer
        Dim maxmin As Integer = 5000
        Try
            'int 	k;
            'int	j;
            'int	maxmin=5000;

            'if (peak)
            '  maxmin=-1;
            'j=i;
            'if (i>5 && i<addata.counter-5){
            '  for(k=i-5; k<i+5; k++){
            '	 if (peak){
            '		if (chanel0[k]>maxmin){
            '		  maxmin=chanel0[k];
            '		  j=k;
            '		}
            '	  }
            '	 else{
            '		if (chanel0[k]<maxmin){
            '		  maxmin=chanel0[k];
            '		  j=k;
            '		}
            '	 }
            '	}
            ' }
            ' i=j;
            ' if (i>5 && i<addata.counter-10){
            '	j=0;
            '	for(k=i; k<i+10; k++){
            '	  if (chanel0[k]==chanel0[k+1])
            '		 j++;
            '	  else
            '		 break;
            '	 }
            '	j=i+j/2;
            ' }
            'return j;
            '}
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function  'ByVal channel As channel,

    Private Function gfuncValidatePeakValley()
        '=====================================================================
        ' Procedure Name        : gfuncValidatePeakValley
        ' Parameters Passed     : None
        ' Returns               : True
        ' Purpose               : Validate Peak and Valley
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 25.11.06
        ' Revisions             : 
        '=====================================================================
        Try


        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
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

    Private Function gfuncGetMV()
        '=====================================================================
        ' Procedure Name        : gfuncGetMV
        ' Parameters Passed     : None
        ' Returns               : True
        ' Purpose               : Get M.Volt.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 25.11.06
        ' Revisions             : 
        '=====================================================================
        Try

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
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

    'Private Function gfuncGetPeakValley()
    '    '=====================================================================
    '    ' Procedure Name        : gfuncGetPeakValley
    '    ' Parameters Passed     : None
    '    ' Returns               : True
    '    ' Purpose               : Get Peak and Valley
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Sachin Dokhale
    '    ' Created               : 25.11.06
    '    ' Revisions             : 
    '    '=====================================================================
    '    Try

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
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

    'Private Function gfuncGetPeakValley()
    '    '=====================================================================
    '    ' Procedure Name        : gfuncGetPeakValley
    '    ' Parameters Passed     : None
    '    ' Returns               : True
    '    ' Purpose               : Get Peak and Valley
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Sachin Dokhale
    '    ' Created               : 25.11.06
    '    ' Revisions             : 
    '    '=====================================================================
    '    Try

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
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
    'Private Function gfuncGetPeakValley()
    '    '=====================================================================
    '    ' Procedure Name        : gfuncGetPeakValley
    '    ' Parameters Passed     : None
    '    ' Returns               : True
    '    ' Purpose               : Get Peak and Valley
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Sachin Dokhale
    '    ' Created               : 25.11.06
    '    ' Revisions             : 
    '    '=====================================================================
    '    Try

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
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
    'Private Function gfuncGetPeakValley()
    '    '=====================================================================
    '    ' Procedure Name        : gfuncGetPeakValley
    '    ' Parameters Passed     : None
    '    ' Returns               : True
    '    ' Purpose               : Get Peak and Valley
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Sachin Dokhale
    '    ' Created               : 25.11.06
    '    ' Revisions             : 
    '    '=====================================================================
    '    Try

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
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
    'Private Function gfuncGetPeakValley()
    '    '=====================================================================
    '    ' Procedure Name        : gfuncGetPeakValley
    '    ' Parameters Passed     : None
    '    ' Returns               : True
    '    ' Purpose               : Get Peak and Valley
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Sachin Dokhale
    '    ' Created               : 25.11.06
    '    ' Revisions             : 
    '    '=====================================================================
    '    Try

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
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

    '    int	GetPeak(int *chanel0, int i, BOOL peak)
    '{

    Private Function funcSerialize(ByVal strFileName As String, ByVal obj As Object) As Boolean
        '=====================================================================
        ' Procedure Name        : funcSerialize
        ' Parameters Passed     : Object
        ' Returns               : True or False
        ' Purpose               : To serialize the object
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 09.10.06
        ' Revisions             : 
        '=====================================================================
        Dim intCount As Integer
        Dim Formatter As BinaryFormatter
        Dim stream As Stream
        Dim strPath As String = ""
        Try
            Formatter = New BinaryFormatter
            stream = New FileStream(strFileName, FileMode.Create, FileAccess.ReadWrite, FileShare.None)

            Try
                Formatter.Serialize(stream, obj)

            Catch ex2 As Exception
                gobjErrorHandler.ErrorDescription = ex2.Message
                gobjErrorHandler.ErrorMessage = ex2.Message
                gobjErrorHandler.WriteErrorLog(ex2)
                gobjMessageAdapter.ShowMessage(constFailedToUpdateFile)
                Application.DoEvents()
                stream.Close()
            Finally
                stream.Close()
            End Try

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

    Public Function funcDeSerialize(ByVal strFileName As String, ByRef obj As Object) As Boolean
        '=====================================================================
        ' Procedure Name        : funcDeSerialize
        ' Parameters Passed     : 
        ' Returns               : True or False
        ' Purpose               : To Deserialize the object
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 09.10.06
        ' Revisions             : 
        '=====================================================================
        Dim Formatter As BinaryFormatter
        Dim fs As FileStream

        Try
            fs = New FileStream(strFileName, FileMode.Open)

            '// Added by Sachin Dokhale 
            If IsNothing(fs) Then
                Return False
            Else
                If fs.Length <= 0 Then
                    Return False
                End If
            End If
            '//-----

            Formatter = New BinaryFormatter
            obj = Formatter.Deserialize(fs)

            Return True

        Catch ex1 As SerializationException
            '---------------------------------------------------------
            'Error Handling and logging
            'gobjErrorHandler.ErrorDescription = ex1.Message
            'gobjErrorHandler.ErrorMessage = ex1.Message
            'gobjErrorHandler.WriteErrorLog(ex1)
            gobjMessageAdapter.ShowMessage(constFailedToLoadFile)
            Application.DoEvents()
            If Not fs Is Nothing Then
                fs.Close()
            End If
            Return False
        Catch ex As Exception
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            If Not fs Is Nothing Then
                fs.Close()
            End If
        End Try
    End Function

#End Region

#Region " Serialization function "

    Public Function gfuncDeSerializeObject(ByVal filepath As String, ByVal objtype As Int16) As Object
        '--- This function De-Serializes the Object as per the input Object Type passed to it.
        '=====================================================================
        ' Procedure Name        :   gfuncDeSerializeObject
        ' Description           :   Get the file from the user and load the
        '                           file data to the object as reqd. by the user.
        ' Purpose               :   To load the file in the object.
        ' Parameters Passed     :   FilePath and Object type.
        ' Returns               :   Object.
        ' Parameters Affected   :   File data is added to the object specified.
        ' Assumptions           :   None.
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale
        ' Created               :   08 Dec. 2006
        ' Revisions             :   
        '=====================================================================

        Dim fs As New FileStream(filepath, FileMode.Open, FileAccess.Read)
        Dim bf As New BinaryFormatter
        Try
            ' Deserialise the Spectrum objects for perticular Spectrum type
            Select Case (objtype)
                Case EnumDeserializeObjType.EnergySpectrum
                    'Dim objEnergyChannels As New SpectrumMode.Channel(True)
                    Dim objEnergyChannels As Spectrum.Channel
                    objEnergyChannels = CType(bf.Deserialize(fs), Spectrum.Channel)
                    Return objEnergyChannels
                Case EnumDeserializeObjType.UVSpectrum
                    'Dim objUVChannels As New SpectrumMode.Channel(False)
                    Dim objUVChannels As Spectrum.Channel
                    objUVChannels = CType(bf.Deserialize(fs), Spectrum.Channel)
                    Return objUVChannels
                Case EnumDeserializeObjType.UVSpectrumDB
                    Dim objUVChannelsDB As Spectrum.EnergyChannels
                    objUVChannelsDB = CType(bf.Deserialize(fs), Spectrum.EnergyChannels)
                    Return objUVChannelsDB
                Case EnumDeserializeObjType.EnergySpectrumDB
                    Dim objEnergyChannelsDB As Spectrum.EnergyChannels
                    objEnergyChannelsDB = CType(bf.Deserialize(fs), Spectrum.EnergyChannels)
                    Return objEnergyChannelsDB
            End Select
        Catch SerializeException As System.Runtime.Serialization.SerializationException
            'Error Handling
            'gobjMessageAdapter.ShowMessage(constFailedToLoadFile)
            gobjMessageAdapter.ShowMessage("Selected data file is mismatch", "Load file", MessageHandler.clsMessageHandler.enumMessageType.WarningMessage, False, False)
            Application.DoEvents()
            Return Nothing
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return Nothing
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log

            If Not fs Is Nothing Then
                fs.Close()
            End If
            fs = Nothing
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try

    End Function

    Public Function gfuncSerializeObject(ByVal filepath As String, ByVal objchannel As Spectrum.Channel) As Boolean
        '--- This function Serializes the Spectrum Channel Object
        '=====================================================================
        ' Procedure Name        :   gfuncSerializeObject
        ' Description           :   Get the Channels object and save it to the filename and path
        '                           specified by the user.
        ' Purpose               :   To Save the Channel Object in the Channel file.
        ' Parameters Passed     :   FilePath and Parameter Object.
        ' Returns               :   None.
        ' Parameters Affected   :   Adds a file the directory path specified.
        ' Assumptions           :   None.
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale
        ' Created               :   8 Dec. 2006
        ' Revisions             :
        '=====================================================================
        Dim fs As FileStream
        Dim bf As BinaryFormatter
        Try
            fs = New FileStream(filepath, FileMode.Create)
            bf = New BinaryFormatter
            'Serialise the Spectrum objects 
            gfuncSerializeObject = False
            bf.Serialize(fs, objchannel)
            fs.Close()
            gfuncSerializeObject = True
            'Catch FileException As System.io.FileLoadException
        Catch FileException As System.UnauthorizedAccessException
            'Catch FileException As System.SystemException
            gobjMessageAdapter.ShowMessage(constFailedToLoadFile)
            Application.DoEvents()
            If Not fs Is Nothing Then
                fs.Close()
            End If
            Return False
        Catch SerializeException As System.Runtime.Serialization.SerializationException
            'Error Handling
            gobjMessageAdapter.ShowMessage(constFailedToLoadFile)
            Application.DoEvents()
            If Not fs Is Nothing Then
                fs.Close()
            End If
            Return False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return False
        Finally
            '---------------------------------------------------------
            'fs.Close()
            fs = Nothing
            bf = Nothing
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try

    End Function

    Public Function gfuncSerializeObjectDB(ByVal filepath As String, ByVal objchannels As Spectrum.EnergyChannels) As Boolean
        '--- This function Serializes the Spectrum Channel Object
        '=====================================================================
        ' Procedure Name        :   gfuncSerializeObject
        ' Description           :   Get the Channels object and save it to the filename and path
        '                           specified by the user.
        ' Purpose               :   To Save the Channel Object in the Channel file.
        ' Parameters Passed     :   FilePath and Parameter Object.
        ' Returns               :   None.
        ' Parameters Affected   :   Adds a file the directory path specified.
        ' Assumptions           :   None.
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale
        ' Created               :   8 Dec. 2006
        ' Revisions             :
        '=====================================================================
        Dim fs As New FileStream(filepath, FileMode.Create)
        Dim bf As New BinaryFormatter
        Try
            'Serialise the Spectrum objects 
            gfuncSerializeObjectDB = False
            bf.Serialize(fs, objchannels)
            gfuncSerializeObjectDB = True
        Catch SerializeException As System.Runtime.Serialization.SerializationException
            'Error Handling
            gobjMessageAdapter.ShowMessage(constFailedToLoadFile)
            Application.DoEvents()
            Return False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return False
        Finally
            '---------------------------------------------------------
            If Not fs Is Nothing Then
                fs.Close()
            End If
            fs = Nothing
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try

    End Function

#End Region

#Region " Service Log-Book "

    '-----------------LOCBOOK Section---------------------------------------
    'Declaration of Database name for SpectraScan
    Public Const CONSTSTR_LOGERRORDATABASENAME As String = "Database\ServiceLogBook.mdb"
    Public Const CONSTSTR_USERINFORMATION As String = "Database\UserInfo.mdb"
    Public CONST_FILELOG_PATH As String = Application.StartupPath.ToString & "\FileLog"

    '--- Enum for SelectionTypes 
    Public Enum enum_LoggingDataFields
        UVSpectrum = 1
        EnergySpectrum = 2
    End Enum
    'enum for setting the time

    '-----------------LOGBOOK Section ends---------------------------------------

#End Region

#Region " General Functions "

    Public Function gfuncValidateGrid(ByVal txtVal As String, ByVal intDecPlace As Integer) As Boolean
        '=====================================================================
        ' Procedure Name        : gfuncValidateGrid
        ' Parameters Passed     : None
        ' Returns               : return True for validation
        ' Purpose               : Validate Grid Control 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 24.02.07
        ' Revisions             : 
        '=====================================================================
        Dim strWavelength As String
        Dim strSplit As String()
        Try
            ' Validate Grid Control for given no of decimal places
            strWavelength = txtVal
            ' Slit the object
            strSplit = strWavelength.Split(New [Char]() {"."})
            ' Check the decimal places
            If strSplit.Length > 1 Then
                If strSplit(1).Length > intDecPlace Then
                    If intDecPlace = 0 Then
                        'gFuncShowMessage("Invalid Input", "Enter integer values ", modConstants.EnumMessageType.Information)
                        gobjMessageAdapter.ShowMessage(constCheckValue)
                        Return False
                    Else
                        'gFuncShowMessage("Invalid Input", "Enter upto " & intDecPlace & " decimal points ", modConstants.EnumMessageType.Information)
                        gobjMessageAdapter.ShowMessage("Enter upto " & intDecPlace & " decimal points ", "Invalid Input", EnumMessageType.Information)
                        Return False
                    End If
                Else
                    Return True
                End If
            Else
                Return True
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

    Public Function gFuncLoadGlobals() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name	    :   gFuncLoadGlobals
        'Description	    :   To load the global variables required through out the system
        'Parameters 	    :   None
        'Time/Date  	    :   13.03.07
        'Dependencies	    :   
        'Author		        :   Sachin Dokhale
        'Revision		    :
        'Revision by Person	:
        '--------------------------------------------------------------------------------------
        Dim Status As Boolean
        Dim intBeamType As Integer
        Dim intIsInstReset As Integer

        Try
            '---Get Comm Port for AAS Instrument
            gintCommPortSelected = CInt(gFuncGetFromINI(SECTION_COMMSETTINGS, KEY_COMPORT, "0", INI_SETTINGS_PATH))
            gintCommPortSelectedForAutoSampler = CInt(gFuncGetFromINI(SECTION_AUTOSAMPLER, KEY_SERIALPORT, "0", INI_SETTINGS_PATH))
            '---Get Instrument Beam Type
            intBeamType = CInt(gFuncGetFromINI(SECTION_SYSTEMPARAMETERS, KEY_INSTRUMENT_BEAMTYPE, "0", INI_SETTINGS_PATH))
            If intBeamType = 0 Then
                gintInstrumentBeamType = enumInstrumentBeamType.SingleBeam
            ElseIf intBeamType = 2 Then
                gintInstrumentBeamType = enumInstrumentBeamType.DoubleBeam
            End If

            gstrCustomer = CStr(gFuncGetFromINI(SECTION_SYSTEMPARAMETERS, KEY_Customer, CONST_LabName, INI_SETTINGS_PATH))

            ' Set the Wavelength range
            Dim objDtWvRange As New DataTable
            objDtWvRange = gobjDataAccess.GetWavelengthRange(gstructSettings.AppMode)
            If Not objDtWvRange Is Nothing Then
                If objDtWvRange.Rows.Count > 0 Then
                    gstructSettings.WavelengthRange.WvLowerBound = objDtWvRange.Rows(0).Item("WvLowerBound")
                    gstructSettings.WavelengthRange.WvUpperBound = objDtWvRange.Rows(0).Item("WvUpperBound")
                End If
            End If
            'intIsInstReset = CInt(gFuncGetFromINI(SECTION_SYSTEMPARAMETERS, KEY_INSTRESET_CONTINUOUS, "0", INI_SETTINGS_PATH))
            'If intIsInstReset <= 0 Then
            '    gblnIsInstReset = False
            'Else
            '    gblnIsInstReset = True
            'End If
            '--- Load the inst. Reset continuous flag.
            Call gfuncGetInstReset_continuousFromINI()
            '//--- Added Sachin Dokhale for AA201  and AA203 Lamp count on 22.05.08
            Select Case gstructSettings.AppMode
                Case EnumAppMode.DemoMode_201, EnumAppMode.FullVersion_201
                    ConstInstFileName = ConstInstFileName_201
                    'Case EnumAppMode.DemoMode_204, EnumAppMode.FullVersion_204
                    'ConstInstFileName = ConstInstFileName_204
                Case Else
                    ConstInstFileName = ConstInstFileName_203
            End Select
            '//---

            gobjClsAAS203.funcLoad_Fuel_Conditions() '---30.04.10

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex)
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

    Public Function gfuncReturnstrCalMode(ByVal intCalMode As EnumCalibrationMode) As String
        '=====================================================================
        ' Procedure Name        : gfuncReturnstrCalMode
        ' Parameters Passed     : EnumCalibrationMode
        ' Returns               : string of Calibration mode
        ' Purpose               : Return Calibration mode in String format for display Mode
        '                         
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : Aug 02, 2007
        ' Revisions             : 1
        '=====================================================================
        Try
            ' return the Calibraiotn mode into string data type from given mode
            Select Case intCalMode
                Case modGlobalConstants.EnumCalibrationMode.AA
                    Return "AA"
                Case modGlobalConstants.EnumCalibrationMode.AABGC
                    Return "AABGC"
                Case modGlobalConstants.EnumCalibrationMode.AABGCSR
                    Return "AABGCSR"
                Case modGlobalConstants.EnumCalibrationMode.D2E
                    Return "D2E"
                Case modGlobalConstants.EnumCalibrationMode.EMISSION
                    Return "EMISSION"
                Case modGlobalConstants.EnumCalibrationMode.HCLE
                    Return "HCLE"
                Case modGlobalConstants.EnumCalibrationMode.MABS
                    Return "MABS"
                Case modGlobalConstants.EnumCalibrationMode.SELFTEST
                    Return "SELFTEST"
                Case Else
                    Return ""
            End Select
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return ""
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

    Public Function gfuncIsDBNull_Ext(ByVal InDBValue As Object) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name	    :   gfuncIsDBNull_Ext
        'Description	    :   To check the DB value with Null or empty value
        'Parameters 	    :   inDBValue as object
        'Return             :   Return True
        'Time/Date  	    :   13.03.07
        'Dependencies	    :   
        'Author		        :   Sachin Dokhale
        'Revision		    :
        'Revision by Person	:
        '--------------------------------------------------------------------------------------

        Try
            '---
            If IsDBNull(InDBValue) = True Then
                Return True
            ElseIf CStr(InDBValue) = "" Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function BlankAlert()
        Try
            Beep2(500, 100)
            Sleep(70)
            Beep2(500, 100)
            Sleep(70)
            Beep2(500, 100)
            Sleep(70)
            Beep2(500, 100)
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

    Public Function StandardAlert()
        Try
            Beep2(400, 100)
            Sleep(50)
            Beep2(500, 100)
            Sleep(50)
            Beep2(400, 100)
            Sleep(50)
            Beep2(500, 100)
            Sleep(50)
            Beep2(400, 100)
            Sleep(50)
            Beep2(500, 100)
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

    Public Function SampleAlert()
        Try
            Beep2(500, 100)
            Sleep(50)
            Beep2(400, 100)
            Sleep(50)
            Beep2(700, 100)
            Sleep(50)
            Beep2(500, 100)
            Sleep(50)
            Beep2(400, 100)
            Sleep(50)
            Beep2(700, 100)
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

End Module

