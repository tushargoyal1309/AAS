Imports AAS203.Common
Imports AAS203Library
Imports AAS203Library.Method
Imports AAS203Library.Instrument
Imports AAS203Library.Analysis
Imports System.IO
Imports AAS203.FuelConditions
''these are like header files
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters
Imports System.Runtime.Serialization.Formatters.Binary

Imports System.Runtime.InteropServices

Public Class ClsAAS203''class behind the class
    Inherits MarshalByRefObject

#Region " Private Menber Varaibles "

    '//----- Private Variable
    Private mEmsZero As Double = 0.0
    ''for atroing a Emission zero value.
    Private intTimeConst As Integer = 2

    Private m_intXoldt, m_intYoldt As Integer
    Private m_blnFilterFlag As Boolean = False
    ''this is a flag for filter flag'
    ''this is used for checking a filter cond.
    Private blnResetFilterData As Boolean
    ''this is used for checking that whatever filter data should be reset or not.
    '//------
    'Private tmr As Timer
    'Private m_tmr_tick_count As Integer = 0
    'Dim objfrmTimeScan As New frmTimeScanDBMode

#End Region

#Region " Public Constants, Enums, Structures... "

    Public Enum enumIgniteType
        ''this is a enum for holding a ignite type.
        Blue = 0
        Yellow = 1
        Red = 2
        Green = 3
    End Enum
    Public Enum enumChangeAxis 'Pankaj 09 May 07 11 for track axis change
        xAxis = 0
        yAxis = 1
        xyAxis = 2
    End Enum

    <DllImport("user32.dll")> Public Shared Function ExitWindows( _
    ByVal dwReserved As Long, ByVal uReturnCode As Long) As Long
    End Function

    <DllImport("user32.dll")> Public Shared Function SendMessage( _
        ByVal hwnd As Long, ByVal wMsg As Long, ByVal wParam As Long, ByVal lParam As Long) As Long
    End Function

    Public Const HWND_BROADCAST = &HFFFF&
    Public Const WM_COMMAND = &H111
    Public Const WM_DESTROY = &H2

#End Region

    Public Function funcGetElement(ByVal intElementID As Integer) As DataTable
        '=====================================================================
        ' Procedure Name        : funcGetElement
        ' Parameters Passed     : intElementID
        ' Returns               : table holding a element info
        ' Purpose               : Toget element details from cookBook
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak B.
        ' Created               : 08.11.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''here we have element id as parameter.
        ''then we connect with database.
        ''and get all element info as per given elementID.
        ''by sending a query
        Dim objDtElement As New DataTable
        Try
            objDtElement = gobjDataAccess.GetCookBookData(intElementID)
            ''gobjDataAccess is a object of dataaccesslayer
            Return objDtElement
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
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcGetElement_AtomicNo(ByVal intElementID As Integer) As DataTable
        '=====================================================================
        ' Procedure Name        : funcGetElement
        ' Parameters Passed     : intElementID
        ' Returns               : 
        ' Purpose               : Toget element details from cookBook
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak B.
        ' Created               : 08.11.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''here we have to a pass element id as parameter.
        ''then we connect with database.
        ''and get a element atomicno  as per given elementID.
        ''by sending a query
        Dim objDtElement As New DataTable
        Try
            objDtElement = gobjDataAccess.GetCookBookData_AtomicNo(intElementID)
            'here gobjDataAccess is object of data access layer.
            Return objDtElement

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
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcGetElementID(ByVal intAtomicNumber As Integer) As Integer
        '=====================================================================
        ' Procedure Name        : funcGetElementID
        ' Parameters Passed     : intAtomicNumber
        ' Returns               : Element ID
        ' Purpose               : Toget element ID from cookBook
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak B.
        ' Created               : 27.03.07
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''here we have to pass a element AtomicNumber as parameter.
        ''then we connect with database.
        ''and get a elementID  as per given element AtomicNum.
        ''by sending a query
        Dim intElementID As Integer
        Try
            intElementID = gobjDataAccess.GetCookBookElementID(intAtomicNumber)
            'here gobjDataAccess is object of data access layer.
            Return intElementID
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return 0
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

    Public Function funcGetElementWavelengths(ByVal intElementID As Integer) As DataTable
        '=====================================================================
        ' Procedure Name        : funcGetElementWavelengths
        ' Parameters Passed     : intElementID
        ' Returns               : returan a data table holding a info
        ' Purpose               : To get element wavelength details from cookBook
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak B.
        ' Created               : 08.11.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''here we have to pass a element ElementID  as parameter.
        ''then we connect with database.
        ''and get a element wavwlengths  as per given elemenID.
        ''by sending a query
        Dim objDtElement As New DataTable

        Try
            objDtElement = gobjDataAccess.GetElementWavelengths(intElementID)
            'here gobjDataAccess is object of data access layer.
            Return objDtElement

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
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcGetSensitiveWavelengthID(ByVal objDtWv As DataTable) As Integer
        '=====================================================================
        ' Procedure Name        : funcGetSensitiveWavelengthID
        ' Parameters Passed     : datatable ,holding all wavwlength value.
        ' Returns               : Sensitive wv id
        ' Purpose               : To get sensitive wavelength ID
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : database connection
        ' Author                : Deepak B.
        ' Created               : 07.1.07
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''here we have to pass a datatable holding all wavelwngth value as parameter.
        ''then we connect with database.
        ''and get a sensitivewavelength  from a given data table.
        ''by sending a query


        Dim intCount As Integer
        Dim intSensitiveWvID As Integer
        ''this will hold a return value.
        Dim blnIsSensitiveWv As Boolean = False
        Dim dblWv As Double = 0.0
        Try
            For intCount = 0 To objDtWv.Rows.Count - 1
                ''make a counter up last row a data table.
                If objDtWv.Rows.Item(intCount).Item("Sensitive_WV") = True Then
                    ''if sensitivity wavelength has been got then store it. 
                    intSensitiveWvID = objDtWv.Rows.Item(intCount).Item("AADetails_ID")
                    blnIsSensitiveWv = True
                    ''set a flag true after finding a sensitivewavelength
                    Exit For
                End If
            Next
            ''else follow the same step
            If blnIsSensitiveWv = False Then
                ''if blnIsSensitiveWv  is false ,it means we did't find a sensitive wavelwngth
                ''then
                If objDtWv.Rows.Count > 0 Then
                    dblWv = objDtWv.Rows.Item(0).Item("WV")
                    'now get a wavelength in dblWv 
                End If
                For intCount = 0 To objDtWv.Rows.Count - 1
                    If objDtWv.Rows.Item(intCount).Item("WV") >= dblWv Then
                        ''check for dblWv value
                        intSensitiveWvID = objDtWv.Rows.Item(intCount).Item("AADetails_ID")
                        ''store the value in sensitive wavelength
                    End If
                Next
            End If
            Return intSensitiveWvID
            ''return a sensitive wavelength.

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return 0
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

    Public Function funcGetMethodTypes() As DataTable
        '=====================================================================
        ' Procedure Name        : funcGetMethodTypes
        ' Parameters Passed     : none
        ' Returns               : datatable with mwthod type.
        ' Purpose               : To get method types from database
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : database connection 
        ' Author                : Deepak B.
        ' Created               : 08.11.06
        ' Revisions             : Mangesh on 14-Apr-2007 for Double Beam Changes
        '                         praveen  
        '=====================================================================
        ''note:
        ''this will get a all method type.
        ''like AA mode,emission mode etc.
        ''and store a datatable object.
        ''which used later in a software through this datatable object
        Dim objDtMethod As DataTable
        Dim objDtDBMethodTypes As DataTable
        Dim objDrNewRow As DataRow
        Dim intRowsCounter As Integer
        Dim IsAA301 As Boolean = False
        Try

            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then   '---21.07.09
                If gstructSettings.NewModelName = True Then
                    IsAA301 = True
                End If
            End If

            objDtMethod = gobjDataAccess.GetMethodTypes(0, IsAA301)
            ''here gobjDataAccess is a object of dataaccesslayer.

            If Not IsNothing(objDtMethod) Then
                If objDtMethod.Rows.Count > 0 Then
                    ''start commented code not in used.

                    '***********************************************************
                    '---Added by Mangesh on 14-Apr-2007
                    '***********************************************************
                    'Commented If & Else by Saurabh 0n 14-May-2007
                    'If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then

                    '    objDtDBMethodTypes = objDtMethod.Clone()
                    '    For intRowsCounter = 0 To objDtMethod.Rows.Count - 1
                    '        If CInt(objDtMethod.Rows(intRowsCounter).Item("MethodTypeID")) = EnumOperationMode.MODE_AA _
                    '                                   Or CInt(objDtMethod.Rows(intRowsCounter).Item("MethodTypeID")) = EnumOperationMode.MODE_AABGC Then

                    '            objDrNewRow = objDtDBMethodTypes.NewRow()
                    '            objDrNewRow.Item("MethodTypeID") = objDtMethod.Rows(intRowsCounter).Item("MethodTypeID")
                    '            objDrNewRow.Item("MethodType") = objDtMethod.Rows(intRowsCounter).Item("MethodType")
                    '            objDtDBMethodTypes.Rows.Add(objDrNewRow)

                    '        End If
                    '    Next intRowsCounter
                    '    Return objDtDBMethodTypes
                    'Else
                    ''End commented code not in used.
                    Return objDtMethod
                    'End If
                    '***********************************************************

                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If

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
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcGetMethodType(ByVal intMethodTypeId As Integer) As DataRow
        '=====================================================================
        ' Procedure Name        : funcGetMethodType
        ' Parameters Passed     : intMethodTypeId
        ' Returns               : return a data row holding method type.
        ' Purpose               : To get method type details from database
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : database connection
        ' Author                : Deepak B.
        ' Created               : 08.11.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        'this is used to get a method type name as per method type ID.
        Dim objDtMethod As New DataTable
        Try
            objDtMethod = gobjDataAccess.GetMethodTypes(intMethodTypeId)
            ''dataaccesslayer function for getting info from database
            If Not objDtMethod Is Nothing Then
                If objDtMethod.Rows.Count > 0 Then
                    ''cack if datatable holding any value.
                    ''if yes then it will be method type.
                    ''return that row.
                    Return objDtMethod.Rows(0)
                End If
            End If
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
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcGetUnits() As DataTable
        '=====================================================================
        ' Procedure Name        : funcGetUnits
        ' Parameters Passed     : none
        ' Returns               : data table holding a Units info
        ' Purpose               : To get units from database
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : database connection.
        ' Author                : Deepak B.
        ' Created               : 08.11.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is used to get a all unitsType from a database.
        Dim objDtUnits As New DataTable

        Try
            objDtUnits = gobjDataAccess.GetUnits
            ''get a data of unit type from database 
            Return objDtUnits
            ''return all units in the datatable
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
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcGetMeasurementMode() As DataTable
        '=====================================================================
        ' Procedure Name        : funcGetMeasurementMode
        ' Parameters Passed     : none
        ' Returns               : data table holding a mode.
        ' Purpose               : To get measurement modes from database
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : database Connection
        ' Author                : Deepak B.
        ' Created               : 08.11.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is used to get a different type of measurementMode from the database.
        Dim objDtMeasurementMode As New DataTable
        ''temp datatable object for holding mode info.
        Try
            objDtMeasurementMode = gobjDataAccess.GetMeasurementModes
            ''database function for getting a value.
            Return objDtMeasurementMode
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
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function


    '============Functions of \Service Utility\Service Routine\frmTurret===================================

    Public Function funcbtnTurretPosition(ByVal intTurretPosition As Integer) As Boolean
        '=====================================================================
        ' Procedure Name        : funcbtnTurretPosition
        ' Parameters Passed     : intTurretPosition
        ' Returns               : True or False
        ' Purpose               : To position the Turret at given position from current position 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : instrument should be connected
        ' Author                : Saurabh S
        ' Created               : 21.11.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is used to set a turrert at a given positon 
        ''for this we used serial communication function
        ''for sending proper protocol to instrument.
        Dim objWait As New CWaitCursor
        Try
            If gobjCommProtocol.gFuncTurret_Position(intTurretPosition, True) = True Then
                ''serial communicaation function for setting turrert position.
                Return True
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try

    End Function

    Public Function funcbtnTurretHome() As Boolean
        '=====================================================================
        ' Procedure Name        : funcbtnTurretHome
        ' Parameters Passed     : none
        ' Returns               : True or False
        ' Purpose               : To position the Turret at its Home position.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : instrument should be connected
        ' Author                : Saurabh S
        ' Created               : 21.11.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is used to set turrert at home position. 
        Dim objWait As New CWaitCursor
        Try
            If gobjCommProtocol.gFuncTurret_Home() = True Then
                ''serial communication function for setting turrert at home position.
                Return True
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcbtnAllLampOFF() As Boolean
        '=====================================================================
        ' Procedure Name        : funcbtnAllLampOFF
        ' Parameters Passed     : 
        ' Returns               : True or False
        ' Purpose               : To turn all the Lamp OFF 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : instrument should be connected
        ' Author                : Saurabh S
        ' Created               : 21.11.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is used to turn off all the lamp .

        Dim objWait As New CWaitCursor
        Try
            If gobjCommProtocol.funcAll_Lamp_Off = True Then
                ''serial communication function for setting all lamp off protocol.
                Return True
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcbtnHCLCurrent(ByVal dblCurrent As Double, ByVal intTurret As Integer) As Boolean
        '=====================================================================
        ' Procedure Name        : funcbtnHCLCurrent
        ' Parameters Passed     : dblCurrent,intTurret
        ' Returns               : bool
        ' Purpose               : 
        ' Description           : To set given HCL current to the turret position.
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 21.11.06
        ' Revisions             : praveen
        '=====================================================================
        'note:
        ''this is used to set given HCL current to the turret position.
        ''by using a serial communication function
        Dim objWait As New CWaitCursor
        Try
            If gobjCommProtocol.funcSet_HCL_Cur(dblCurrent, intTurret) = True Then
                ''serial communication function for setting all lamp off
                Return True
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcbtnD2Current(ByVal d2Cur As Double) As Boolean
        '=====================================================================
        ' Procedure Name        : funcbtnD2Current
        ' Parameters Passed     : d2Cur 
        ' Returns               : True if success
        ' Purpose               : To set D2 Current
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : instrument 
        ' Author                : Saurabh S
        ' Created               : 04.12.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is used to set a D2 current.

        Dim objWait As New CWaitCursor
        Try
            If gobjCommProtocol.funcSetD2Cur(d2Cur) = True Then
                ''serial communication function for setting D2 current
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcbtnD2ONOFF(ByVal Flag As Integer, ByRef Flag1 As Integer) As Boolean
        '=====================================================================
        ' Procedure Name        : funcbtnD2ONOFF
        ' Parameters Passed     : Flag
        ' Parameters Affected   : Flag1
        ' Returns               : True or False
        ' Purpose               : To put the D2 Current ON or OFF.

        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : instrument connection.
        ' Author                : Saurabh S
        ' Created               : 04.12.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is used to set D2 lamp on or off as per given cond.
        Dim objWait As New CWaitCursor
        Try
            If Flag = 0 Then
                If gobjCommProtocol.D2_ON() = True Then
                    'serial communication for setting D2 lamp on 
                    '--- If D2 lamp is ON successfully then flag1 is set to 1. And return true
                    Flag1 = 1
                    Return True
                Else
                    gobjMessageAdapter.MessageTextAlignment = ContentAlignment.MiddleLeft
                    gobjMessageAdapter.ShowMessage(constCommError)
                End If
            Else
                If gobjCommProtocol.D2_OFF() = True Then
                    ''serial communication for setting D2 off.
                    '--- If D2 lamp is OFF successfully then flag1 is set to 0. And return true
                    Flag1 = 0
                    Return True
                Else
                    gobjMessageAdapter.MessageTextAlignment = ContentAlignment.MiddleLeft
                    gobjMessageAdapter.ShowMessage(constCommError)
                End If
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    '=============== By Sachin Dokhale ========================================

    Public Function funcGet_SlitWidth(Optional ByRef intInstrumentSlitType As Integer = 0) As Double
        '=====================================================================
        ' Procedure Name        : funcGet_SlitWidth
        ' Parameters Passed     : intInstrumentSlitType,it is a slit type
        ' Parameters affected   : intInstrumentSlitType.
        ' Returns               : Double,slit width
        ' Purpose               : Get the Slit width
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : global data structure,instrument connection.
        ' Author                : Sachin Dokhale
        ' Created               : 25.11.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is used to get slit width value
        ''from the value of global data structure
        ''as per the slitType.
        Dim dblSWidth As Double

        Try
            '  sw = ((double)80.0-(double) Inst.Slitpos)/(double)40.0;
            If intInstrumentSlitType = 0 Then
                ''check a cond as per instrument slit type.
                dblSWidth = (80.0 - CDbl(gobjInst.SlitPosition)) / 40
            ElseIf intInstrumentSlitType = 1 Then
                dblSWidth = (80.0 - CDbl(gobjInst.SlitPositionExit)) / 40
            End If
            funcGet_SlitWidth = dblSWidth
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            funcGet_SlitWidth = -1
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

    Public Function funcDecr_Height() As Boolean
        '=====================================================================
        ' Procedure Name        : funcDecr_Height
        ' Parameters Passed     : None
        ' Returns               : Boolean
        ' Purpose               : Decrease the burner Height
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 25.11.06
        ' Revisions             : praveen
        ' =====================================================================
        ''note:
        ''this is used to decrement the burner height 
        ''first get a current burner position 
        ''convert it in to step.
        ''check the cond for burner step
        ''and now decrement the burner heigth by roating it in anti clock wise direction.


        'void     S4FUNC Decr_Height()
        '{
        ' Get_BH_Pos();
        'If (Inst.Bhstep >= BHSTEP) Then
        'BH_RotateAnticlock_Steps(BHSTEP);
        '}
        Try
            funcDecr_Height = False
            If gobjCommProtocol.func_Get_BH_Pos() = True Then
                If gobjInst.BhStep >= BHSTEP Then
                    ''here BHSTEP is a constant=44.0
                    ''serial communication function for roating a burner in a anti clock direction
                    Call gobjCommProtocol.func_BHRotateAntiClock_Steps(BHSTEP)
                End If
                funcDecr_Height = True
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return False
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

    Public Function funcIncr_Height() As Boolean
        '=====================================================================
        ' Procedure Name        : funcIncr_Height
        ' Parameters Passed     : None
        ' Returns               : Boolean
        ' Purpose               : Increase the burner Height
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 25.11.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is used to Increment the burner height 
        ''first get a current burner position 
        ''convert it in to step.
        ''check the cond for burner step
        ''and now decrement the burner heigth by roating it in clock wise direction.

        Dim dblSWidth As Double

        Try
            funcIncr_Height = False
            If gobjCommProtocol.func_Get_BH_Pos() = True Then
                ''for getting burner current position.
                If gobjInst.BhStep <= (MAXBHHOME - BHSTEP) Then
                    ''serial communication function for roating burner height in a clock wise direction for step.
                    Call gobjCommProtocol.func_BHRotateClock_Steps(BHSTEP)
                End If
                funcIncr_Height = True
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return False
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

    Public Function funcBurner_Type() As Boolean
        '=====================================================================
        ' Procedure Name        : funcBurner_Type
        ' Parameters Passed     : none
        ' Returns               : Boolean
        ' Purpose               : to get a burner type
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : instrument 
        ' Author                : Sachin Dokhale
        ' Created               : 25.11.06
        ' Revisions             : praveen
        '=====================================================================
        ''note;
        ''get a burner parameter from instrument.
        ''and return a true or false as per.

        Dim bytBUR_PAR As Byte
        Try

            '//---------------
            '           BYTE st1;

            'st1 = CHECK_BUR_PAR();
            '           If (st1 & AA_CONNECTED) Then
            'return TRUE; // 100 mm Burner
            '           Else
            'return FALSE;
            '//--------------
            ''To check Burner parameters
            If gobjCommProtocol.funcCheckBurnerParameters(bytBUR_PAR) = True Then
                ''bytBUR_PAR,bdata as byte
                '---following line is code is changed by Deepak on 09.12.08
                'If (bytBUR_PAR & EnumErrorStatus.AA_CONNECTED) Then
                If (bytBUR_PAR And EnumErrorStatus.AA_CONNECTED) Then
                    Return True     '//---- 100 mm Burner
                Else
                    Return False
                End If
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

    Public Function funcGetMaxLamp() As Integer
        '=====================================================================
        ' Procedure Name        : funcGetMaxLamp
        ' Parameters Passed     : None
        ' Returns               : Integer
        ' Purpose               : Get max no of lamps.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : instrument connection.
        ' Author                : Sachin Dokhale
        ' Created               : 25.11.06
        ' Revisions             : praveen
        '=====================================================================

        ''note;
        ''this is used to get max no of lamp ,that can be connected to instrument'
        ''as per application mode.

        '//---------------
        'if( InstType == AA202 )
        '	return 2;
        'else
        '	return 6;
        '//--------------

        Try
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or _
                gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then
                Return 2
                ''2 for 201
            Else
                Return 6
                ''for other
            End If

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

    Public Function funcReadBurnerHeight() As Double
        '=====================================================================
        ' Procedure Name        : funcReadBurnerHeight
        ' Parameters Passed     : None
        ' Returns               : double
        ' Purpose               : Read the burner Height
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : instrument connection.
        ' Author                : Sachin Dokhale
        ' Created               : 25.11.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is used to get burner height as per burner step.
        ''for it we used global inst object, for getting a burnerstep.
        Dim dblBH As Double = 0.0

        Try
            'double	bh=0.0;
            'bh=  ConvertToBurnerHeight(Inst.Bhstep);
            If gobjInst.BhStep > -1 Then
                dblBH = funcConvertToBurnerHeight(gobjInst.BhStep)
                ''function for converting burner step in to height
            End If

            Return dblBH
            ''return a burner height.

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

    Public Function funcAdj_D2Gain(ByVal blnSetWvFlag As Boolean, Optional ByRef lblWvStatus As Object = Nothing)
        '=====================================================================
        ' Procedure Name        : funcAdj_D2Gain
        ' Parameters Passed     : blnSetWvFlag,lblWvStatus
        ' Returns               : None
        ' Purpose               : Adj D2 Gain  
        ' Description           : this is called for adjusting a D2gain
        ' Assumptions           : 
        ' Dependencies          : instrument connection.
        ' Author                : Sachin Dokhale
        ' Created               : 25.11.06
        ' Revisions             : 
        '=====================================================================
        Dim dblIniWv As Double = 0.0

        Try
            dblIniWv = gobjInst.WavelengthCur
            ''gobjInst is a global object which contain a instrument parameter
            If gobjCommProtocol.Wavelength_Position(CDbl(UVGAINWV), lblWvStatus) = True Then
                ''this is bool function which position the wavelength and return true
                Call gobjCommProtocol.funcSet_PMT(220.0)
                ''this is a serial communication function for setting a given pmt value to
                ''instrument
                If gobjCommProtocol.funcAdj_Pmt_ForValue((4600.0 * 100.0 / 5000.0), 700.0, True) Then
                    ''To adjust pmt voltage to obtain maximum energy
                    gobjInst.D2Pmt = CInt(gobjInst.PmtVoltage)
                End If
            End If

            If blnSetWvFlag = True Then
                Call gobjCommProtocol.Wavelength_Position(CDbl(dblIniWv), lblWvStatus)
                'communication function for position the wavelength
            End If
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

    '======================================================================================================


    '============Functions of \Service Utility\Service Routine\frmAnalog===================================

    Public Function funcbtnSet_PMT(ByVal dblPMT As Double) As Boolean
        '=====================================================================
        ' Procedure Name        : funcbtnSet_PMT
        ' Parameters Passed     : dblPMT
        ' Returns               : True or False
        ' Purpose               : To Set the PMT voltage.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 21.11.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is called when user click on set PMT.
        ''this will used a serial communication and set a given PMT to instrument.
        Dim objWait As New CWaitCursor
        Try
            If gobjCommProtocol.funcSet_PMT(dblPMT) = True Then
                ''serial communication function for setting pmt
                Return True
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try

    End Function

    Public Function funcbtnADCNonFilter(ByRef dblmv As Double) As Boolean
        '=====================================================================
        ' Procedure Name        : funcbtnADCNonFilter
        ' Parameters Passed     : dblmv
        ' Returns               : True or False
        ' Purpose               : To get the value of ADC Non Filter.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 21.11.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is called when user click on ADC non Filter button.
        ''here [OUT] intAvgInmv : avg. of ADC count return =dblmv
        'Dim objWait As New CWaitCursor
        Try
            If gobjCommProtocol.funcReadADCNonFilter(dblmv) = True Then
                ''serial communication function for reading a ADC Non filter
                Return True
            End If
            Return False
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

    Public Function funcbtnADCFilter(ByVal intAvgFactor As Integer, ByRef dblmv As Double) As Boolean
        '=====================================================================
        ' Procedure Name        : funcbtnADCNonFilter
        ' Parameters Passed     : intAvgFactor,dblmv
        ' Returns               : True or False
        ' Purpose               : To get th value of ADC Filter.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 21.11.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is called when user click on ADC filter button
        ''this is used to read a ADC filter.
        'Dim objWait As New CWaitCursor
        Try
            If gobjCommProtocol.funcReadADCFilter(intAvgFactor, dblmv) = True Then
                ''serial communication function for reading ADC filter
                Return True
            End If
            Return False
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
            'If Not objWait Is Nothing Then
            '    objWait.Dispose()
            'End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcbtnSetMode(ByVal byteSetMode As Byte) As Boolean
        '=====================================================================
        ' Procedure Name        : funcbtnSetMode
        ' Parameters Passed     : byteSetMode 
        ' Returns               : True or False
        ' Purpose               : To set instrument mode.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : instrument connection.
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is called when user click on set mode button
        ''this is used to set a given mode 
        Dim objWait As New CWaitCursor
        Try
            If gobjCommProtocol.funcCalibrationMode(byteSetMode) = True Then
                ''serial communication for setting calibration mode to instrument
                Return True
            End If

            Return False
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    '======================================================================================================


    '============Functions of \Service Utility\Service Routine\frmMonochromator============================

    Public Function funcbtnWvHome(Optional ByRef objWv As Label = Nothing) As Boolean
        '=====================================================================
        ' Procedure Name        : funcbtnWvHome
        ' Parameters Passed     : objWv,it is a label for showing a status.
        ' Returns               : True or False
        ' Purpose               : To position the wavelength at its Home position.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : instrument connection.
        ' Author                : Saurabh S
        ' Created               : 21.11.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is called when user clicked on wave length home button.
        ''this is use for setting a wavelength at home position.
        Dim objWait As New CWaitCursor

        Try
            If gobjCommProtocol.gFuncWavelength_Home(objWv) = True Then
                ''serial communication function for setting wavelength home from the given posotion
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcbtnSlitHome() As Boolean
        '=====================================================================
        ' Procedure Name        : funcbtnSlitHome
        ' Parameters Passed     : none
        ' Returns               : True or False
        ' Purpose               : To position the slit at its Home position
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : instrument connection.
        ' Author                : Saurabh S
        ' Created               : 21.11.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is called when user clicked on slit home buttton.
        ''this is used to set slit at home position.
        Dim objWait As New CWaitCursor
        Try
            If gobjCommProtocol.gFuncSlit_Home() = True Then
                ''serial communication function for setting slit at HOME position
                Return True
            End If
            'End If
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try

    End Function

    Public Function funcbtnWvPosition(ByVal dblWvPosition As Double, Optional ByRef lblWvRec As Object = Nothing) As Boolean
        '=====================================================================
        ' Procedure Name        : funcbtnWvPosition
        ' Parameters Passed     : dblWvPosition,lblWvRec
        ' Returns               : True or False
        ' Purpose               : To position the Wavelength at said position from current position 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this is called when user clicked on wavelength position button.
        ''this is used to set a wavelength at given position.
        Dim objWait As New CWaitCursor
        Try
            If gobjCommProtocol.Wavelength_Position(dblWvPosition, lblWvRec) = True Then
                ''serial communication function for setting wavelength.
                ''here lblWvRec is a status label.
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcbtnSlitWidth(ByVal dblSlitWidth As Double) As Boolean
        '=====================================================================
        ' Procedure Name        : funcbtnSlitWidth
        ' Parameters Passed     : dblSlitWidth
        ' Returns               : True or False
        ' Purpose               : To set the slit width
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : instrument connection.
        ' Author                : Saurabh S
        ' Created               : 21.11.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is used to slit width 
        Dim objWait As New CWaitCursor
        Try
            If gobjCommProtocol.funcSet_SlitWidth(dblSlitWidth) = True Then
                ''serial communication function for setting given slit width to instrument
                Return True
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    '======================================================================================================


    '============Functions of \Service Utility\Service Routine\frmManualIgnition===========================

    Public Function funcbtnAIRONOFF(ByVal blnAir As Boolean, ByRef blnAir1 As Boolean) As Boolean
        '=====================================================================
        ' Procedure Name        : funcbtnAIRONOFF
        ' Parameters Passed     : blnAir,blnAir1
        ' Returns               : True or False
        ' Purpose               : To put the AIt pressure ON or OFF.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : instrument connection.
        ' Author                : Saurabh S
        ' Created               : 27.11.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is to put air ON/OFF as per given flag. 
        Dim objWait As New CWaitCursor
        Try
            If blnAir = False Then
                
                If gobjCommProtocol.funcAir_OFF() = True Then
                    ''serial communication function for setting airoff.
                    'gobjMessageAdapter.ShowMessage(constCongratsOFFAir)
                    blnAir1 = True
                    Return True
                End If
            Else
                If gobjCommProtocol.funcAir_ON() = True Then
                    ''serial communicatioin for setting air ON.
                    'gobjMessageAdapter.ShowMessage(constCongratsONAir)
                    blnAir1 = False
                    Return True
                End If
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcbtnN2OONOFF(ByVal blnN2O As Boolean, ByRef blnN2O1 As Boolean) As Boolean
        '=====================================================================
        ' Procedure Name        : funcbtnN2OONOFF
        ' Parameters Passed     : blnN2O,blnN2O1
        ' Returns               : True or False
        ' Purpose               : To put the N2O pressure ON or OFF.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 27.11.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''''this is used to set N2 ON/OFF as per given flag.
        Dim objWait As New CWaitCursor
        Try
            If blnN2O = False Then

                If gobjCommProtocol.func_N2O_OFF() = True Then
                    ''serial communication function for setting N2O OFF
                    blnN2O1 = True
                    Return True
                End If
            Else
                If gobjCommProtocol.func_N2O_ON() = True Then
                    ''serial communication function for setting N2O ON
                    blnN2O1 = False
                    Return True
                End If
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcbtnFUELONOFF(ByVal blnFUEL As Boolean, ByRef blnFUEL1 As Boolean) As Boolean
        '=====================================================================
        ' Procedure Name        : funcbtnFUELONOFF
        ' Parameters Passed     : blnFUEL,blnFUEL1
        ' Returns               : True or False
        ' Purpose               : To put the FUEL ON or OFF.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : instrument connection.
        ' Author                : Saurabh S
        ' Created               : 27.11.06
        ' Revisions             : praveen
        '=====================================================================

        ''note:
        ''this is used to set fuel ON/OFF as per given falg value.
        Dim objWait As New CWaitCursor
        Try
            If blnFUEL = False Then
                If gobjCommProtocol.func_FUEL_OFF() = True Then
                    ''serial communication for setting fuel OFF

                    blnFUEL1 = True
                    Return True
                End If
                'End If
            Else
                If gobjCommProtocol.func_FUEL_ON() = True Then

                    ''serial communication for setting fuel ON
                    blnFUEL1 = False
                    Return True
                End If
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcbtnIGNITEONOFF(ByVal strIgnite As String, ByRef strIgnite1 As String) As Boolean
        '=====================================================================
        ' Procedure Name        : funcbtnIGNITEONOFF
        ' Parameters Passed     : strIgnite,strIgnite1
        ' Returns               : True or False
        ' Purpose               : To put the IGNITE ON or OFF.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : instrument connection.
        ' Author                : Saurabh S
        ' Created               : 29.11.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is used to set ignite on/off as per given flag value
        Dim objWait As New CWaitCursor
        Try
            If strIgnite = "YES" Then
                '--- Set Ignition off
                If gobjCommProtocol.func_IGNITE_OFF() = True Then

                    strIgnite1 = "NO"
                    'gobjInst.Aaf = False
                    Return True
                End If
            Else
                '--- Ignition on
                If gobjCommProtocol.func_IGNITE_ON() = True Then

                    ''serial communication function for 
                    'gobjMessageAdapter.ShowMessage(constCongratsONIGNITE)
                    'Application.DoEvents()
                    strIgnite1 = "YES"
                    'gobjInst.Aaf = True
                    Return True
                End If
                'End If
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try

    End Function

    '======================================================================================================

    Public Function funcGetCookBookDetailRow(ByVal intDetailsID As Integer) As DataRow
        '=====================================================================
        ' Procedure Name        : funcGetCookBookDetailRow
        ' Parameters Passed     : intDetailsID
        ' Returns               : DataRow
        ' Purpose               : To get cook book details row
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : database connection.
        ' Author                : Deepak B.
        ' Created               : 15.12.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''here info is come from the database.
        Dim objDr As DataRow
        Try
            '--- Get the data row of Element from given element ID
            objDr = gobjDataAccess.GetCookBookDetailRow(intDetailsID)
            '--- Return Data row
            Return objDr
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
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    '============================================================================
    Public Sub ReInitInstParameters()
        '=====================================================================
        ' Procedure Name        : ReInitInstParameters
        ' Parameters Passed     : none
        ' Returns               : None
        ' Purpose               : this is used to set warmupcurrent to warmup lamp if any else set current to lamp.
        '                         the set a PMT'and validate a D2 lamp.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : serial communication 
        ' Author                : 
        ' Created               : 15.12.06
        ' Revisions             : Deepak on 23.01.08 removed bug
        '=====================================================================
        'int i,dcur;
        'double lampcur,warmupcur;

        '                            If (!Commflag) Then
        '	return;
        'if(Inst.Lamp_pos>=1 && Inst.Lamp_pos<=6) {
        '  if (Inst.Mode==AA || Inst.Mode ==HCLE || Inst.Mode==AABGC ||Inst.Mode==AABGCSR){
        '		lampcur=Inst.Cur;
        '		warmupcur=Inst.Lamp_par.lamp[Inst.Lamp_warm-1].cur;
        '	  for(i=1;i<=6;i++){
        '		  if( (i == Inst.Lamp_pos) || ((Inst.Lamp_warm>0 && Inst.Lamp_warm<7) && (i == Inst.Lamp_warm))){
        '			  if(i == Inst.Lamp_warm)
        '				  Set_HCL_Cur(warmupcur,Inst.Lamp_warm);
        '                                                Else
        '				  Set_HCL_Cur(lampcur,Inst.Lamp_pos);
        '		  }
        '		  else
        '			  Set_HCL_Cur(0,i);
        '	  }
        '	  Inst.Cur=lampcur;
        '	  Inst.Lamp_par.lamp[Inst.Lamp_warm-1].cur=warmupcur;
        '  }
        '  Set_PMT(Inst.Pmtv);
        '                                                    If (Inst.D2cur > 100) Then
        '	 Set_D2_Cur(Inst.D2cur);
        '  else{
        '	 dcur=100;
        '	 Transmit(D2CUR, (BYTE)(dcur), (BYTE) (dcur>>8), 0);
        '#If NEWHANDSHAKE Then
        '	 Recev(TRUE);
        '#End If
        '	 D2_OFF();
        '  }
        '}

        Dim i, dcur As Integer
        ''here i used for counter
        Dim lampcur, warmupcur As Double
        Dim intMaxLamp As Integer
        Try
            intMaxLamp = funcGetMaxLamp()

            If gobjCommProtocol.mobjCommdll.gFuncResumeProcess = True Then   '10.12.07
                'If (gobjInst.Lamp_Position >= 1 And gobjInst.Lamp_Position <= 6) Then
                If (gobjInst.Lamp_Position >= 1 And gobjInst.Lamp_Position <= intMaxLamp) Then
                    'checking a lamp position for lamp betw1 to 6.

                    ReInitLampInstParameters = True
                    'If (gobjInst.Lamp_Warm > 0) And (gobjInst.Lamp_Warm < 7) Then
                    ''checking for warmup lamp position 
                    If (gobjInst.Mode = EnumCalibrationMode.AA Or gobjInst.Mode = EnumCalibrationMode.HCLE Or gobjInst.Mode = EnumCalibrationMode.AABGC Or gobjInst.Mode = EnumCalibrationMode.AABGCSR) Then
                        ''setting current as par selected mode

                        'changed by Deepak on 07.12.07
                        'lampcur = gobjInst.Current
                        'lampcur = gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).Current
                        'changed by Sachin Dokhaler on 14.02.08
                        lampcur = gobjInst.Current
                        ''for eg here we are storing gobjInst.Current value in to temp valiable 

                        'If (gobjInst.Lamp_Warm > 0) And (gobjInst.Lamp_Warm < 7) Then
                        If (gobjInst.Lamp_Warm > 0) And (gobjInst.Lamp_Warm <= intMaxLamp) Then
                            warmupcur = gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Warm - 1).Current
                        End If
                        '
                        'For i = 1 To 6
                        For i = 1 To intMaxLamp
                            'If ((i = gobjInst.Lamp_Position) Or ((gobjInst.Lamp_Warm > 0 And gobjInst.Lamp_Warm < 7) And (i = gobjInst.Lamp_Warm))) Then
                            If ((i = gobjInst.Lamp_Position) Or ((gobjInst.Lamp_Warm > 0 And gobjInst.Lamp_Warm <= intMaxLamp) And (i = gobjInst.Lamp_Warm))) Then
                                If (i = gobjInst.Lamp_Warm) Then
                                    ''if lamp is warmup then
                                    'If (gobjInst.Lamp_Warm > 0) And (gobjInst.Lamp_Warm < 7) Then
                                    If (gobjInst.Lamp_Warm > 0) And (gobjInst.Lamp_Warm <= intMaxLamp) Then
                                        gobjCommProtocol.funcSet_HCL_Cur(warmupcur, gobjInst.Lamp_Warm)
                                    End If
                                    ''serial communication function for setting HCL current for warmmup lamp
                                Else
                                    ''else
                                    gobjCommProtocol.funcSet_HCL_Cur(lampcur, gobjInst.Lamp_Position)
                                End If
                            Else
                                gobjCommProtocol.funcSet_HCL_Cur(0, i)
                                ''otherwise set a lamp current 0.
                            End If
                        Next
                        gobjInst.Current = lampcur
                        '
                        'If (gobjInst.Lamp_Warm > 0) And (gobjInst.Lamp_Warm < 7) Then
                        If (gobjInst.Lamp_Warm > 0) And (gobjInst.Lamp_Warm <= intMaxLamp) Then
                            gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Warm - 1).Current = warmupcur
                        End If

                        ''store current vale of lampcurrent and warmup lamp current
                    End If
                    'End If

                    gobjCommProtocol.funcSet_PMT(gobjInst.PmtVoltage)
                    ''set a pmt value
                    If (gobjInst.D2Current > 100) Then
                        ''check for D2 current
                        gobjCommProtocol.funcSetD2Cur(gobjInst.D2Current)
                    Else
                        ''else put D2 lamp off.
                        dcur = 100

                        'gobjCommProtocol.mobjCommdll.gFuncTransmitCommand(EnumAAS203Protocol.D2CUR, CByte(dcur), CByte(dcur >> 8), 0)


                        ''gobjCommProtocol.funcSetD2Cur(dcur)     '---27.05.09

                        '---'---27.05.09 DB
                        If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                            If gstructSettings.NewModelName = True Then
                                If Not gobjNewMethod Is Nothing Then
                                    If Not gobjNewMethod.OperationMode = EnumOperationMode.MODE_AA And Not gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
                                        gobjCommProtocol.funcSetD2Cur(dcur)     '10.12.07
                                    End If
                                Else
                                    gobjCommProtocol.funcSetD2Cur(dcur)     '10.12.07
                                End If
                            Else
                                gobjCommProtocol.funcSetD2Cur(dcur)     '10.12.07
                            End If
                        Else
                            gobjCommProtocol.funcSetD2Cur(dcur)     '10.12.07
                        End If
                        '---'---27.05.09


                        '#If NEWHANDSHAKE Then
                        '	 Recev(TRUE);
                        '#End If
                        gobjCommProtocol.D2_OFF()
                    End If
                    ReInitLampInstParameters = False
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

    Public Function funcInstReset() As Boolean
        '=====================================================================
        ' Procedure Name        : ReInitInstParameters
        ' Parameters Passed     : none
        ' Returns               : None
        ' Purpose               : this is used to set warmupcurrent to warmup lamp if any else set current to lamp.
        '                         the set a PMT'and validate a D2 lamp.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : serial communication 
        ' Author                : Sachin Dokhale
        ' Created               : 15.1.08
        ' Revisions             : 
        '=====================================================================
        ' if(Resetcont){
        ' Resetcont=0;
        ' MessageBox(NULL,"Instrument Continuous Reset Flag Cleared","Information",MB_OK);
        '}
        'else{
        ' Resetcont=1;
        ' MessageBox(NULL,"Instrument Continuous Reset Flag Enabled","Information",MB_OK);
        '}
        Try
            If gblnIsInstReset = True Then
                gblnIsInstReset = False
                'm_tmr_tick_count = 0
                'If Not tmr Is Nothing Then
                '    RemoveHandler tmr.Tick, AddressOf tmr_tick
                '    tmr.Enabled = False
                '    tmr.Dispose()
                'End If
                gobjMessageAdapter.ShowMessage("Instrument Continuous Reset Flag Cleared", "Information", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
            Else
                gblnIsInstReset = True
                gobjMessageAdapter.ShowMessage("Instrument Continuous Reset Flag Enabled", "Information", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                '---to call function for alt R
                'funcAlt_R()
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

    'Public Function funcAlt_R() As Boolean
    '    '=====================================================================
    '    ' Procedure Name        : funcAlt_R
    '    ' Parameters Passed     : none
    '    ' Returns               : None
    '    ' Purpose               : For shortcut alt R
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : serial communication 
    '    ' Author                : Deepak Bhati
    '    ' Created               : 23.01.08
    '    ' Revisions             : 
    '    '=====================================================================
    '    Try
    '        tmr = New Timer
    '        tmr.Interval = 1000
    '        AddHandler tmr.Tick, AddressOf tmr_tick
    '        tmr.Enabled = True

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        tmr.Enabled = False
    '        Return False
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

    'Private Sub tmr_tick(ByVal sender As Object, ByVal e As EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : tmr_tick
    '    ' Parameters Passed     : 
    '    ' Returns               : None
    '    ' Purpose               : For shortcut alt R
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : serial communication 
    '    ' Author                : Deepak Bhati
    '    ' Created               : 23.01.08
    '    ' Revisions             : 
    '    '=====================================================================
    '    Dim dbltime_sec, dbltime_min As Double
    '    Try
    '        m_tmr_tick_count = m_tmr_tick_count + 1
    '        dbltime_sec = m_tmr_tick_count * (tmr.Interval / 1000)
    '        dbltime_min = dbltime_sec / 60

    '        If dbltime_min <= 1 Then
    '            If clsRS232Main.IsInCommu = False Then
    '                If gintCommPortSelected > 0 Then
    '                    Application.DoEvents()
    '                    If gblnIsInstReset = True Then
    '                        gobjClsAAS203.ReInitInstParameters()
    '                    End If
    '                End If
    '            End If
    '        Else
    '            m_tmr_tick_count = 0
    '            RemoveHandler tmr.Tick, AddressOf tmr_tick
    '            tmr.Enabled = False
    '            tmr.Dispose()
    '            gblnIsInstReset = False
    '        End If

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try
    'End Sub

    Public Function funcAutoZeroAbsMode() As Boolean
        '=====================================================================
        ' Procedure Name        : funcAutoZeroAbsMode
        ' Parameters Passed     :  
        ' Returns               : True or False
        ' Purpose               : To set Auto zero for abs mode
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 19.12.06
        ' Revisions             : praveen 
        '=====================================================================
        ''note:
        '-- this is used to call auto zero function.

        Try
            '    BOOL 	S4FUNC 	AutoZeroAbsMode(HWND hpar)
            '{
            '  Cal_Mode(AA);
            '  return Adj_PMT_forvalue(hpar, (double) 0.0 , (double)600);
            '}
            If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                ''check for 203D

                Return funcAutoZeroAbsModeDB()
                ''for 203D
            Else
                'Return gobjCommProtocol.funcAdj_Pmt_ForValue(0.0, 600, True)
                Return funcAutoZeroAbsModeSB()
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

    Public Function funcAutoZeroAbsModeSB() As Boolean
        '=====================================================================
        ' Procedure Name        : funcAutoZeroAbsModeSB
        ' Parameters Passed     :  
        ' Returns               : True or False
        ' Purpose               : To set Auto zero for abs mode, Single mode
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 19.12.06
        ' Revisions             : praveen
        '=====================================================================
        ''note
        ''this is a auto zero function for single beam.
        Try
            '    BOOL 	S4FUNC 	AutoZeroAbsMode(HWND hpar)
            '{
            '  Cal_Mode(AA);
            '  return Adj_PMT_forvalue(hpar, (double) 0.0 , (double)600);
            '}
            gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.AA)
            ''serial communication function
            ''set the calibration mode as AA
            Return gobjCommProtocol.funcAdj_Pmt_ForValue(0.0, 600, True)
            ''adjust a PMT voltage.

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

    Public Function funcAutoZeroAbsModeDB() As Boolean
        '=====================================================================
        ' Procedure Name        : funcAutoZeroAbsModeDB
        ' Parameters Passed     :  None
        ' Returns               : True or False
        ' Purpose               : To set Auto zero for abs mode.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 19.12.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        'this will call a autozero function for double beam.
        Try
            '    BOOL 	S4FUNC 	AutoZeroAbsMode(HWND hpar)
            '{
            '  Cal_Mode(AA);
            '  return Adj_PMT_forvalue(hpar, (double) 0.0 , (double)600);
            '}
            gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.AA)
            ''serial communication for setting a calibration mode.

            If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam Then
                ''set a PMT for SingleBeam
                Return gobjCommProtocol.funcAdj_Pmt_ForValue(0.0, 600, True)
                ''for adjusting PMT 
            ElseIf gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.ReferenceBeam Then
                ''set a PMT for ReferenceBeam
                Return gobjCommProtocol.funcAdj_Pmt_ForValue_Ref(0.0, 600, True)
                ''for adjusting PMT 
            ElseIf gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
                ''set a PMT for DoubleBeam
                If gobjCommProtocol.funcAdj_Pmt_ForValue_Ref(0.0, 600, True) = True Then
                    ''for adjusting PMT 
                    gobjCommProtocol.funcAdj_Pmt_ForValue(0.0, 600, True)
                    Call gobjCommProtocol.funcGetRefBaseVal()
                    ''for getting reference baseline.
                    Return True
                End If
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

    Public Function funcBgc_Zero(ByVal blnFlag As Boolean) As Boolean
        '=====================================================================
        ' Procedure Name        : funcBgc_Zero
        ' Parameters Passed     :  blnFlag
        ' Returns               : True or False
        ' Purpose               : To set Auto zero for BGC mode
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 19.12.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this will call a function for Auto zero of BGC mode.
        Try
            ' BOOL	S4FUNC 	Bgc_Zero(HWND hpar, BOOL flag1)
            '{
            ' return(Bgc_Zero1(hpar, flag1, 3000.0));
            '}
            '--- To set Auto zero for BGC mode
            Return funcBgc_Zero1(blnFlag, 3000.0)

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

    Private Function funcBgc_Zero1(ByVal flag1 As Boolean, ByVal Value As Double) As Boolean
        '=====================================================================
        ' Procedure Name        : funcBgc_Zero1
        ' Parameters Passed     :  flag1,Value
        ' Returns               : True or False
        ' Purpose               : To set Auto zero for BGC mode 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 19.12.06
        ' Revisions             : praveen
        '=====================================================================

        Try
            '           BOOL	S4FUNC 	Bgc_Zero1(HWND hpar, BOOL  flag1, double value)
            '{
            ' if (ReadIniForD2Gain()|| ReadIniForMesh())
            '	  return Bgc_Zero3(hpar, flag1, value);
            '            Else
            '	  return Bgc_Zero2(hpar, flag1, value);
            '}

            '--- To set Auto zero for BGC mode when Mesh is used or D2 Gain is used
            If (gstructSettings.D2Gain = True) Or (gstructSettings.Mesh = True) Then
                ''check for a D2 gain and Mesh
                If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                    ''for 203D 

                    '    If gintInstrumentBeamType = enumInstrumentBeamType.DoubleBeam Then
                    '        If funcBgc_Zero3_RefBeam(flag1, Value) Then
                    '            funcBgc_Zero3(flag1, Value)
                    '            Call gobjCommProtocol.funcGetRefBaseVal()
                    '            Return True
                    '        End If
                    '    ElseIf gintInstrumentBeamType = enumInstrumentBeamType.ReferenceBeam Then
                    '        Return funcBgc_Zero3_RefBeam(flag1, Value)
                    '    ElseIf gintInstrumentBeamType = enumInstrumentBeamType.SingleBeam Then
                    '        Return funcBgc_Zero3(flag1, Value)
                    '    End If
                    Return funcBgc_Zero3(flag1, Value)      'Added by Saurabh
                Else
                    ''for other 201,203
                    Return funcBgc_Zero3(flag1, Value)
                End If
            Else
                If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                    'Commented by Saurabh
                    'If gintInstrumentBeamType = enumInstrumentBeamType.DoubleBeam Then
                    '    If funcBgc_Zero2_RefBeam(flag1, Value) Then
                    '        funcBgc_Zero2(flag1, Value)
                    '        Call gobjCommProtocol.funcGetRefBaseVal()
                    '        Return True
                    '    End If
                    'ElseIf gintInstrumentBeamType = enumInstrumentBeamType.ReferenceBeam Then
                    '    Return funcBgc_Zero2_RefBeam(flag1, Value)
                    'ElseIf gintInstrumentBeamType = enumInstrumentBeamType.SingleBeam Then
                    '    Return funcBgc_Zero2(flag1, Value)
                    'End If
                    'Commented by Saurabh
                    ''for 203
                    Return funcBgc_Zero2(flag1, Value)  'Added by Saurabh
                Else
                    ''for other instrument
                    Return funcBgc_Zero2(flag1, Value)
                End If
                'Return funcBgc_Zero2(flag1, Value)
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

    Private Function funcBgc_Zero2(ByVal flag1 As Boolean, ByVal dblvalue As Double) As Boolean
        '===========================================================s==========
        ' Procedure Name        : funcBgc_Zero2
        ' Parameters Passed     : flag1, value
        ' Returns               : True or False
        ' Purpose               : To set Auto zero for BGC mode
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 19.12.06
        ' Revisions             : praveen
        '=====================================================================
        Dim intXmode, chnew As Integer
        Dim a, b As Integer
        Dim MaxD2Cur, MinD2Cur As Integer
        Dim intD2cur As Integer
        Dim objfrmSettingPMT As New frmPMT
        ''this is a object for form pmt Setting dialog box.
        Dim x1 As Double
        Dim addf As Integer = 1
        Dim chIdx As Integer
        ''this is "chIdx" for index counter
        Dim Flag As Boolean = True

        a = 0
        b = 0
        MaxD2Cur = 300
        MinD2Cur = 100
        ''intialise the variables
        Try
            '//------
            'Set_D2_Cur(d2cur);
            '		if(GetInstrument() == AA203 ){
            '		 Set_HCL_Cur(Inst->Cur,Inst->Lamp_pos);
            '		 Set_PMT(Inst->Pmtv);
            '	  }
            '	 for(i=0; i<4; i++)
            '		chnew = ReadADCFilter();
            '	 strcpy(line1,"");
            '	 x1 = (chnew-2047.0)/4096.0*10000.0;
            '                    If (GetSRLamp()) Then
            '		sprintf(line1,"SRCur.:%d mA  Energy: %4.1f   ",d2cur, (100.0/value)*x1);
            '                    Else
            '		sprintf(line1,"D2Cur.:%d mA  Energy: %4.1f   ",d2cur, (100.0/value)*x1);
            '	 SetText(hwnd, IDC_STATUS1,line1);
            '	 if (x1<=(value+20.0) && x1>=(value-20.0)) break;
            '	 if (x1>(value+1000.0))  addf=-10;
            '	 else if (x1>(value+200.0))  addf=-5;
            '	 else if (x1>(value+20.0)) { addf=-1; a++;
            '			 if (b>10) b=1; }
            '	 if (x1<(value-1000.0)) addf=10;
            '	 else if (x1<(value-200.0)) addf=5;
            '	 else if (x1<(value-20.0)) { addf=1; b++;}
            '	 d2cur+=addf;
            '	 if ( x1>(value+200.0) && d2cur<=MinD2Cur) {
            '		 if (value==3000)       Gerror_message_new(" Increase HCL Current and retry ", "AABGC ZERO");
            '		 else Gerror_message_new("Error in FULL SCALE SET", "AABGC ZERO");
            '		 pc_delay(5000);
            '		 flag = FALSE; d2cur=MinD2Cur; break;}
            '	 if ( x1<(value-200.0) && d2cur>=MaxD2Cur) {
            '		 if (value==3000)  Gerror_message_new(" Reduce HCL Current and retry again ", "AABGC ZERO");
            '		 else Gerror_message_new("Error in FULL SCALE SET", "AABGC ZERO");
            '		 pc_delay(5000);
            '		 flag = FALSE; d2cur=MaxD2Cur;break;}
            '                                                        If (a > 10) Then
            '		{ if (b>10)  break;
            '		 else a =0;
            '		}
            '	 if (CheckMsg(hwnd, &msg)) if (WP==IDCANCEL)
            '		break;
            '	}
            '//-------

            If gobjCommProtocol.SRLamp Then
                ''check for SR lamp.
                MaxD2Cur = 600
                MinD2Cur = 100
            Else
                MaxD2Cur = 300
                MinD2Cur = 100
            End If

            intXmode = gobjInst.Mode
            ''get instrument current mode in a intXmode

            If (flag1) Then
                ''this is a flag pass by user

                'objfrmSettingPMT.Show()
                gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.AA)
                ''set a calibration mode
                '--- adjusting PMT to the 0.0 range and max Pmt volt limit is 700, 
                '--- and Set 'True' flag for setting autozero
                gobjCommProtocol.funcAdj_Pmt_ForValue(0.0, 700.0, True)

                'objfrmSettingPMT.Close()
            End If
            Application.DoEvents()
            ''allow application to perfrom its panding work.
            objfrmSettingPMT = New frmPMT
            objfrmSettingPMT.Text = "BGC ZERO"
            objfrmSettingPMT.Refresh()
            Application.DoEvents()
            ''allow application to perfrom its panding work.
            If gobjCommProtocol.SRLamp Then
                ''check for SR lamp.
                'SetText(hwnd, IDC_STATUS,"Setting SRCURRENT :");
                objfrmSettingPMT.lblTitle.Text = "Setting SRCURRENT :"
                ''set a dialog title. 
            Else
                'SetText(hwnd, IDC_STATUS,"Setting D2CURRENT :");
                objfrmSettingPMT.lblTitle.Text = "Setting D2CURRENT :"
            End If
            objfrmSettingPMT.lblTitle.Refresh()

            objfrmSettingPMT.Show()
            ''show pmt dialog box
            objfrmSettingPMT.BringToFront()
            ''show the dialog of PMT 
            Application.DoEvents()
            ''allow application to perfrom its panding work.
            gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.D2E)
            ''set a calibration mode to D2E

            'if( GetInstrument() == AA202 ){
            '              If (GetSRLamp()) Then
            'd2cur = d2cur;
            '              Else
            'd2cur=Inst->D2cur;
            '}
            'else
            ' d2cur=Inst->D2cur;

            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                ''check for 201
                'If (GetSRLamp()) Then
                If gobjCommProtocol.SRLamp = True Then
                    ''check for SR lamp in 201
                    intD2cur = intD2cur
                Else
                    intD2cur = gobjInst.D2Current
                End If
            Else
                intD2cur = gobjInst.D2Current
            End If
            'intD2cur = gobjInst.D2Current

            '//
            Do While (True)
                ''loop start

                'Set_D2_Cur(d2cur);
                '		if(GetInstrument() == AA203 ){
                '		 Set_HCL_Cur(Inst->Cur,Inst->Lamp_pos);
                '		 Set_PMT(Inst->Pmtv);
                '	  }
                gobjCommProtocol.funcSetD2Cur(intD2cur)
                ''set a D2 current as per passed value.
                'if(GetInstrument() = AA203 ) then
                gobjCommProtocol.funcSet_HCL_Cur(gobjInst.Current, gobjInst.Lamp_Position)
                ''set a HCL current at given lamp position.
                gobjCommProtocol.funcSet_PMT(gobjInst.PmtVoltage)
                ''set a PMT
                'end if

                For chIdx = 0 To 3 '5    '02.08.07
                    'for(i=0; i<4; i++)
                    'chnew = ReadADCFilter();
                    Call gobjCommProtocol.funcReadADCFilter(gobjInst.Average, chnew)
                    'read a ADC filter value.
                Next
                'x1 = (chnew-2047.0)/4096.0*10000.0;
                x1 = (chnew - 2047.0) / 4096.0 * 10000.0
                ''get X1 as per chnew 

                'If (GetSRLamp()) Then
                'sprintf(line1,"SRCur.:%d mA  Energy: %4.1f   ",d2cur, (100.0/value)*x1);
                '              Else
                'sprintf(line1,"D2Cur.:%d mA  Energy: %4.1f   ",d2cur, (100.0/value)*x1);

                If gobjCommProtocol.SRLamp Then
                    ''draw a PMT setting dialog as per SR lamp.

                    'SetText(hwnd, IDC_STATUS,"Setting SRCURRENT :");
                    objfrmSettingPMT.lblMsg.Text = "SRCURRENT. : " & intD2cur.ToString & " mA " _
                                        & "Energy. : " & CStr(Format(((100.0 / dblvalue) * x1), "#0.00"))
                Else
                    'SetText(hwnd, IDC_STATUS,"Setting D2CURRENT :");
                    objfrmSettingPMT.lblMsg.Text = "D2CURRENT : " & intD2cur.ToString & " mA " _
                                        & "Energy. : " & CStr(Format(((100.0 / dblvalue) * x1), "#0.00"))
                End If
                objfrmSettingPMT.lblMsg.Refresh()
                Application.DoEvents()

                ''allow application to perfrom its panding work.


                '	 if (x1<=(value+20.0) && x1>=(value-20.0)) break;
                '	 if (x1>(value+1000.0))  addf=-10;
                '	 else if (x1>(value+200.0))  addf=-5;
                '	 else if (x1>(value+20.0)) { addf=-1; a++;
                '			 if (b>10) b=1; }
                '	 if (x1<(value-1000.0)) addf=10;
                '	 else if (x1<(value-200.0)) addf=5;
                '	 else if (x1<(value-20.0)) { addf=1; b++;}
                '	 d2cur+=addf;

                If (x1 <= (dblvalue + 20.0) And x1 >= (dblvalue - 20.0)) Then     '02.08.07
                    Exit Do
                End If

                'If (x1 <= (dblvalue + 10.0) And x1 >= (dblvalue - 10.0)) Then     '02.08.07
                '    Exit Do
                'End If

                '//
                'if (x1>(value+1000.0))  addf=-10;
                'else if (x1>(value+200.0))  addf=-5;
                'else if (x1>(value+20.0)) { addf=-1; a++;
                'if (b>10) b=1; }
                '//

                If (x1 > (dblvalue + 1000.0)) Then
                    addf = -10
                ElseIf (x1 > (dblvalue + 200.0)) Then
                    addf = -5
                ElseIf (x1 > (dblvalue + 20.0)) Then
                    addf = -1
                    a += 1
                    If (b > 10) Then b = 1
                End If

                'if (x1<(value-1000.0)) addf=10;
                'else if (x1<(value-200.0)) addf=5;
                'else if (x1<(value-20.0)) { addf=1; b++;}
                If (x1 < (dblvalue - 1000.0)) Then
                    addf = 10
                ElseIf (x1 < (dblvalue - 200.0)) Then
                    addf = 5
                ElseIf (x1 < (dblvalue - 20.0)) Then
                    addf = 1
                    b += 1
                End If

                'd2cur+=addf;
                intD2cur += addf
                '          if ( x1>(value+200.0) && d2cur<=MinD2Cur) {
                ' if (value==3000)       Gerror_message_new(" Increase HCL Current and retry ", "AABGC ZERO");
                ' else Gerror_message_new("Error in FULL SCALE SET", "AABGC ZERO");
                ' pc_delay(5000);
                ' flag = FALSE; d2cur=MinD2Cur; break;}

                'if ( x1<(value-200.0) && d2cur>=MaxD2Cur) {
                ' if (value==3000)  Gerror_message_new(" Reduce HCL Current and retry again ", "AABGC ZERO");
                ' else Gerror_message_new("Error in FULL SCALE SET", "AABGC ZERO");
                ' pc_delay(5000);
                ' flag = FALSE; d2cur=MaxD2Cur;break;}
                '                              If (a > 10) Then
                '{ if (b>10)  break;
                ' else a =0;
                '}

                If (x1 > (dblvalue + 200.0) And intD2cur <= MinD2Cur) Then
                    If (dblvalue = 3000) Then
                        'Gerror_message_new(" Increase HCL Current and retry ", "AABGC ZERO")
                        'gobjMessageAdapter.ShowMessage(constReduceHCL)
                        gobjMessageAdapter.ShowMessage(constIncreaseHCl)
                    Else
                        'Gerror_message_new("Error in FULL SCALE SET", "AABGC ZERO");
                        gobjMessageAdapter.ShowMessage(constErrorFULLSCALE)
                    End If

                    'pc_delay(5000);
                    gobjCommProtocol.mobjCommdll.subTime_Delay(50)
                    ''communication delay
                    intD2cur = MinD2Cur
                    Flag = False
                    Exit Do
                End If
                If (x1 < (dblvalue - 200.0) And intD2cur >= MaxD2Cur) Then
                    If (dblvalue = 3000) Then
                        'Gerror_message_new(" Reduce HCL Current and retry again ", "AABGC ZERO");
                        gobjMessageAdapter.ShowMessage(constReduceHCL)
                    Else
                        'Gerror_message_new("Error in FULL SCALE SET", "AABGC ZERO");
                        gobjMessageAdapter.ShowMessage(constErrorFULLSCALE)
                    End If
                    'pc_delay(5000);
                    gobjCommProtocol.mobjCommdll.subTime_Delay(50)
                    intD2cur = MaxD2Cur
                    Flag = False
                    Exit Do
                End If
                ';break;}

                If (a > 10) Then
                    If (b > 10) Then
                        Exit Do
                    Else
                        a = 0
                    End If
                End If
                '//-

                If objfrmSettingPMT.mCancelProcess = True Then
                    Exit Do
                End If
                objfrmSettingPMT.BringToFront()
                objfrmSettingPMT.Refresh()
                Application.DoEvents()
            Loop

            'if ( d2cur<MinD2Cur) d2cur = MinD2Cur;
            'if ( d2cur>MaxD2Cur) d2cur = MaxD2Cur;
            'Set_D2_Cur(d2cur);
            'if(GetInstrument() == AA203 ){
            ' Set_HCL_Cur(Inst->Cur,Inst->Lamp_pos);
            ' Set_PMT(Inst->Pmtv);
            '}

            If (intD2cur < MinD2Cur) Then
                intD2cur = MinD2Cur
            End If

            If (intD2cur > MaxD2Cur) Then
                intD2cur = MaxD2Cur
            End If
            Call gobjCommProtocol.funcSetD2Cur(intD2cur)
            ''serial communication for setting D2 current.

            'if(GetInstrument() == AA203 ){
            Call gobjCommProtocol.funcSet_HCL_Cur(gobjInst.Current, gobjInst.Lamp_Position)
            ''set a HCL current at given position
            Call gobjCommProtocol.funcSet_PMT(gobjInst.PmtVoltage)
            ''for setting given pmt voltage.
            '}
            objfrmSettingPMT.Close()
            ''close the PMT voltage form
            Application.DoEvents()
            'Cal_Mode(xmode);
            gobjCommProtocol.funcCalibrationMode(intXmode)
            ''set a calibration mode
            funcBgc_Zero2 = Flag
            '//---

            '//

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
            If Not (objfrmSettingPMT Is Nothing) Then
                objfrmSettingPMT.Dispose()
            End If
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Private Function funcBgc_Zero3(ByVal flag1 As Boolean, ByVal dblvalue As Double) As Boolean
        '=====================================================================
        ' Procedure Name        : funcBgc_Zero3
        ' Parameters Passed     :  flag1, value
        ' Returns               : True or False
        ' Purpose               : To set Auto zero for BGC mode
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 19.12.06
        ' Revisions             : praveen
        '=====================================================================
        'int 		d2cur;
        'double   x1=0;
        'int     addf=1,i;
        'char    line1[80]="";
        'BOOL	  flag=TRUE;
        'int     xmode, chnew, a=0, b=0;
        'int	gtry=0;
        'BOOL	Micro=FALSE;
        'BOOL	Gain=FALSE;
        'int MaxD2Cur=300,MinD2Cur = 100;
        '//-----
        Dim intd2cur As Integer
        Dim dblx1 As Double = 0
        Dim intaddf As Integer = 1
        Dim inti As Integer
        'char    line1[80]="";
        Dim blnflag As Boolean = True
        Dim intxmode, intchnew As Integer
        Dim a As Integer = 0
        Dim b As Integer = 0
        Dim intgtry As Integer = 0
        Dim blnMicro As Boolean = False
        Dim blnGain As Boolean = False
        Dim MaxD2Cur As Integer = 300
        Dim MinD2Cur As Integer = 100
        Dim objfrmSettingPMT As New frmPMT
        ''this is a object for PMT setting dialog.
        Dim chIdx As Integer
        '//-----
        Try
            'if( GetSRLamp() ){
            '	MaxD2Cur = 600;
            '	MinD2Cur = 100;
            '}
            'else{
            '	MaxD2Cur = 300;
            '	MinD2Cur = 100;
            '}
            '  GainX10Off();
            '  SetMicroOff();
            '  WaitForAdc();
            '  xmode = Inst->Mode;

            '  if(GetInstrument() == AA202 ){
            '	 if( GetSRLamp()){
            '		d2cur=Inst->D2cur;
            '                        If (d2cur <= 100) Then
            '			d2cur = 101;
            '		Set_D2_Cur(d2cur);
            '	 }
            '  }
            '  if (flag1) {
            '	 Cal_Mode(AA);
            '	 Adj_PMT_forvalue(hpar, (double) 0.0 , (double)700.0);
            '	 }
            '  hwnd= CreateWindowPeak(hpar, "BGC ZERO","PMTADJ", 0);
            '                                If (GetSRLamp()) Then
            '	  SetText(hwnd, IDC_STATUS,"Setting SRCURRENT :");
            '                                Else
            '	  SetText(hwnd, IDC_STATUS,"Setting D2CURRENT :");
            '  Cal_Mode(D2E);

            '  if( GetInstrument() == AA202 ){
            '                                        If (GetSRLamp()) Then
            '		d2cur = d2cur;
            '                                        Else
            '		d2cur=Inst->D2cur;
            '  }
            '  else
            '	  d2cur=Inst->D2cur;

            '  while(flag){
            '	 Set_D2_Cur(d2cur);
            '	 if(GetInstrument() == AA203 ){
            '		 Set_HCL_Cur(Inst->Cur,Inst->Lamp_pos);
            '		 Set_PMT(Inst->Pmtv);
            '	 }
            '	 for(i=0; i<4; i++)
            '		chnew = ReadADCFilter();
            '	 strcpy(line1,"");
            '	 x1 = (chnew-2047.0)/4096.0*10000.0;

            '                                                        If (GetSRLamp()) Then
            '		 sprintf(line1,"SRCur.:%d mA  Energy: %4.1f   ",d2cur, (100.0/value)*x1);
            '                                                        Else
            '		 sprintf(line1,"D2Cur.:%d mA  Energy: %4.1f   ",d2cur, (100.0/value)*x1);

            '	 SetText(hwnd, IDC_STATUS1,line1);
            '	 if (x1<=(value+20.0) && x1>=(value-20.0)) break;
            '	 if (x1>(value+1000.0))  addf=-10;
            '	 else if (x1>(value+200.0))  addf=-5;
            '	 else if (x1>(value+20.0)) { addf=-1; a++;
            '			 if (b>10) b=1; }
            '	 if (x1<(value-1000.0)) addf=10;
            '	 else if (x1<(value-200.0)) addf=5;
            '	 else if (x1<(value-20.0)) { addf=1; b++;}
            '	 d2cur+=addf;
            '	 if (d2cur<=MinD2Cur ){
            '		d2cur=MinD2Cur;
            '		Set_D2_Cur(d2cur);

            '		if(GetInstrument() == AA203 ){
            '		 Set_HCL_Cur(Inst->Cur,Inst->Lamp_pos);
            '		 Set_PMT(Inst->Pmtv);
            '		}

            '	 TryNextMode(hwnd, &Gain, &Micro, &gtry, d2cur, value);
            '	  }
            '	 if ( d2cur>=MaxD2Cur ){// || (x1<(value-200.0) && d2cur>=300)) {
            '//		d2cur=MinD2Cur;
            '		d2cur=101;//MaxD2Cur;
            '		Set_D2_Cur(d2cur);
            '		if(GetInstrument() == AA203 ){
            '		 Set_HCL_Cur(Inst->Cur,Inst->Lamp_pos);
            '		 Set_PMT(Inst->Pmtv);
            '		}
            '		TryNextMode(hwnd, &Gain, &Micro, &gtry, d2cur,value);
            '		}
            '	 if (gtry==4){
            '		if (value==3000)
            '		  Gerror_message_new(" Reduce HCL Current and retry ","AABGC ZERO");
            '                                                                                                Else
            '		  Gerror_message_new("Error in FULL SCALE SET", "AABGC ZERO");
            '		pc_delay(5000);
            '		flag = FALSE; d2cur=MinD2Cur; break;
            '	  }
            '	 if (a>10)	{
            '		 if (b>10)  break;
            '		 else a =0;
            '		}
            '	 if (CheckMsg(hwnd, &msg)) if (WP==IDCANCEL)
            '		break;
            '	}
            '  if ( d2cur<MinD2Cur) d2cur = MinD2Cur;
            '  if ( d2cur>MaxD2Cur) d2cur = MaxD2Cur;
            '  if (!flag){
            '	 GainX10Off();
            '	 SetMicroOff();
            '	 Gain = FALSE;
            '	}

            '  if ( d2cur<MinD2Cur) d2cur = MinD2Cur;
            '  if ( d2cur>MaxD2Cur) d2cur = MaxD2Cur;
            '  Set_D2_Cur(d2cur);
            '  if(GetInstrument() == AA203 ){
            '	Set_HCL_Cur(Inst->Cur,Inst->Lamp_pos);
            '	  Set_PMT(Inst->Pmtv);
            '  }
            '  DestroyWindowPeak(hwnd, hpar);
            '  Cal_Mode(xmode);
            '                                                                                                                                        If (Gain) Then
            '	 GainX10On();
            ' return flag;
            '}
            'If (GetSRLamp()) Then
            '	MaxD2Cur = 600;
            '	MinD2Cur = 100;
            '}
            'else{
            '	MaxD2Cur = 300;
            '	MinD2Cur = 100;
            '}  

            '======================================

            If gobjCommProtocol.SRLamp Then
                ''as per the SR lamp set the D2 current.
                MaxD2Cur = 600
                MinD2Cur = 100
            Else
                MaxD2Cur = 300
                MinD2Cur = 100
            End If

            intxmode = gobjInst.Mode
            Call gobjCommProtocol.funcGain10X_OFF()
            ''to set Gain10x off
            Call gobjCommProtocol.funcSetMICRO_OFF()
            ''to set Micro off
            Call subWaitForAdc()
            ''wait for ADC.
            'xmode = Inst->Mode;
            intxmode = gobjInst.Mode
            ''get a mode in to temp variable

            '//----- for AA202 
            'if(GetInstrument() == AA202 ){
            'if( GetSRLamp()){
            'd2cur=Inst->D2cur;
            '                  If (d2cur <= 100) Then
            '	d2cur = 101;
            'Set_D2_Cur(d2cur);
            '}
            '}
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                ''check for 201
                'If (GetSRLamp()) Then
                If gobjCommProtocol.SRLamp = True Then
                    ''check for SR lamp in 201
                    'intd2cur = intd2cur
                    intd2cur = gobjInst.D2Current
                    If intd2cur <= 100 Then
                        intd2cur = 101
                    End If
                    gobjCommProtocol.funcSetD2Cur(intd2cur)
                    ''set as D2 current as per the passed value.
                End If
            End If
            'if (flag1) {
            'Cal_Mode(AA);
            'Adj_PMT_forvalue(hpar, (double) 0.0 , (double)700.0);
            '}
            If (flag1) = True Then
                ''flag passed by user as parameter

                'objfrmSettingPMT.Show()
                Call gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.AA)
                ''set the calibration mode.

                '--- adjusting PMT to the 0.0 range, max Pmt volt limit is 700, 
                '--- and Set 'True' flag for setting autozero
                Call gobjCommProtocol.funcAdj_Pmt_ForValue(0.0, 700.0, True)

                ''objfrmSettingPMT.Close()
            End If

            'hwnd= CreateWindowPeak(hpar, "BGC ZERO","PMTADJ", 0);
            '          If (GetSRLamp()) Then
            ' SetText(hwnd, IDC_STATUS,"Setting SRCURRENT :");
            '          Else
            ' SetText(hwnd, IDC_STATUS,"Setting D2CURRENT :");
            'Cal_Mode(D2E);

            Application.DoEvents()

            objfrmSettingPMT = New frmPMT
            objfrmSettingPMT.Text = "BGC ZERO"
            objfrmSettingPMT.Refresh()
            ''initialise the  objfrmSettingPMT form object.

            If gobjCommProtocol.SRLamp Then
                ''for SR lamp
                'SetText(hwnd, IDC_STATUS,"Setting SRCURRENT :");
                'objfrmSettingPMT.lblTitle.Text = "Setting SRCURRENT :"
                objfrmSettingPMT.lblTitle.Text = "Setting SRCURRENT : "

            Else
                'SetText(hwnd, IDC_STATUS,"Setting D2CURRENT :");
                objfrmSettingPMT.lblTitle.Text = "Setting D2CURRENT : "
            End If
            objfrmSettingPMT.lblTitle.Refresh()

            objfrmSettingPMT.Show()
            Application.DoEvents()
            ''show the dialog and allow application to perfrom its panding work.
            gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.D2E)
            ''set a calibration mode to D2E

            'if( GetInstrument() == AA202 ){
            '              If (GetSRLamp()) Then
            'd2cur = d2cur;
            '              Else
            'd2cur=Inst->D2cur;
            '}
            'else
            ' d2cur=Inst->D2cur;

            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                ''check for 201
                'If (GetSRLamp()) Then
                If gobjCommProtocol.SRLamp = True Then
                    ''check for SR lamp.
                    'intd2cur = intd2cur
                    intd2cur = intd2cur
                Else
                    intd2cur = gobjInst.D2Current
                End If
            Else
                intd2cur = gobjInst.D2Current
            End If
            'intd2cur = gobjInst.D2Current

            Do While (True)
                ''start loop
                gobjCommProtocol.funcSetD2Cur(intd2cur)
                ''set the D2 current
                'if(GetInstrument() = AA203 ) then
                gobjCommProtocol.funcSet_HCL_Cur(gobjInst.Current, gobjInst.Lamp_Position)
                ''set a given HCL current at given position

                gobjCommProtocol.funcSet_PMT(gobjInst.PmtVoltage)
                ''for setting given pmt voltage


                'for(i=0; i<4; i++)
                'chnew = ReadADCFilter();
                'strcpy(line1,"");

                For chIdx = 0 To 4
                    'for(i=0; i<4; i++)
                    'chnew = ReadADCFilter();
                    Call gobjCommProtocol.funcReadADCFilter(gobjInst.Average, intchnew)
                    ''function for reading a adc FLITER
                Next

                '--- Calculate the Abs value
                'x1 = (chnew-2047.0)/4096.0*10000.0;
                dblx1 = (intchnew - 2047.0) / 4096.0 * 10000.0

                'If (GetSRLamp()) Then
                ' sprintf(line1,"SRCur.:%d mA  Energy: %4.1f   ",d2cur, (100.0/value)*x1);
                '              Else
                ' sprintf(line1,"D2Cur.:%d mA  Energy: %4.1f   ",d2cur, (100.0/value)*x1);

                'SetText(hwnd, IDC_STATUS1,line1);
                If gobjCommProtocol.SRLamp Then
                    ''for SR lamp
                    'SetText(hwnd, IDC_STATUS,"Setting SRCURRENT :");
                    objfrmSettingPMT.lblMsg.Text = "SRCURRENT. : " & intd2cur.ToString & " mA " _
                                    & "Energy. : " & CStr(Format(((100.0 / dblvalue) * dblx1), "#0.00"))
                    'objfrmSettingPMT.lblMsg.Text = "Energy. : " & CStr(((100.0 / dblvalue) * dblx1))
                Else
                    'SetText(hwnd, IDC_STATUS,"Setting D2CURRENT :");
                    objfrmSettingPMT.lblMsg.Text = "D2CURRENT : " & intd2cur.ToString & " mA " _
                                            & " Energy. : " & CStr(Format(((100.0 / dblvalue) * dblx1), "#0.00"))
                    'objfrmSettingPMT.lblMsg.Text = "Energy. : " & CStr(((100.0 / dblvalue) * dblx1))
                End If

                objfrmSettingPMT.lblMsg.Refresh()
                Application.DoEvents()
                ''allow application to perfrom its panding work.

                'if (x1<=(value+20.0) && x1>=(value-20.0)) break;
                If (dblx1 <= (dblvalue + 20.0) And dblx1 >= (dblvalue - 20.0)) Then
                    Exit Do
                End If
                'if (x1>(value+1000.0))  addf=-10;
                '	 else if (x1>(value+200.0))  addf=-5;
                '	 else if (x1>(value+20.0)) { addf=-1; a++;
                '			 if (b>10) b=1; }

                If (dblx1 > (dblvalue + 1000.0)) Then
                    intaddf = -10
                ElseIf (dblx1 > (dblvalue + 200.0)) Then
                    intaddf = -5
                ElseIf (dblx1 > (dblvalue + 20.0)) Then
                    intaddf = -1
                    a += 1
                    If (b > 10) Then b = 1
                End If

                '	 if (x1<(value-1000.0)) addf=10;
                '	 else if (x1<(value-200.0)) addf=5;
                '	 else if (x1<(value-20.0)) { addf=1; b++;}
                If (dblx1 < (dblvalue - 1000.0)) Then
                    intaddf = 10
                ElseIf (dblx1 < (dblvalue - 200.0)) Then
                    intaddf = 5
                ElseIf (dblx1 < (dblvalue - 20.0)) Then
                    intaddf = 1
                    b += 1
                End If
                'd2cur+=addf;
                intd2cur += intaddf

                'if (d2cur<=MinD2Cur ){
                'd2cur=MinD2Cur;
                'Set_D2_Cur(d2cur);

                'if(GetInstrument() == AA203 ){
                ' Set_HCL_Cur(Inst->Cur,Inst->Lamp_pos);
                ' Set_PMT(Inst->Pmtv);
                '}

                'TryNextMode(hwnd, &Gain, &Micro, &gtry, d2cur, value);
                ' }
                If (intd2cur <= MinD2Cur) Then
                    intd2cur = MinD2Cur
                    gobjCommProtocol.funcSetD2Cur(intd2cur)
                    ''for setting D2 current

                    'If (GetInstrument() = AA203) Then
                    gobjCommProtocol.funcSet_HCL_Cur(gobjInst.Current, gobjInst.Lamp_Position)
                    ''set the current at given position
                    gobjCommProtocol.funcSet_PMT(gobjInst.PmtVoltage)
                    ''set a PMT voltage.
                    'End If
                    subTryNextMode(blnGain, blnMicro, intgtry, intd2cur, dblvalue)
                End If
                'if (gtry==4){
                'if (value==3000)
                '  Gerror_message_new(" Reduce HCL Current and retry ","AABGC ZERO");
                '                  Else
                '  Gerror_message_new("Error in FULL SCALE SET", "AABGC ZERO");
                'pc_delay(5000);
                'flag = FALSE; d2cur=MinD2Cur; break;
                ' }
                If (intgtry = 4) Then
                    If (dblvalue = 3000) Then
                        gobjMessageAdapter.ShowMessage(constReduceHCL)
                    Else
                        gobjMessageAdapter.ShowMessage(constErrorFULLSCALE)
                    End If
                    'pc_delay(5000)
                    gobjCommProtocol.mobjCommdll.subTime_Delay(50)
                    ''function for delay
                    blnflag = False
                    intd2cur = MinD2Cur
                    'break()
                    Exit Do
                End If
                '              if (a>10)	{
                ' if (b>10)  break;
                ' else a =0;
                '}
                If (a > 10) Then
                    If (b > 10) Then
                        Exit Do
                    Else
                        a = 0
                    End If
                End If
                '//=-=---- Define by Sachin Dokhale
                '//----- Set the interupt for exit 
                'if (CheckMsg(hwnd, &msg)) if (WP==IDCANCEL)
                'break;
                If objfrmSettingPMT.mCancelProcess = True Then
                    Exit Do
                End If
                '//-----
                objfrmSettingPMT.BringToFront()
                objfrmSettingPMT.Refresh()
                Application.DoEvents()
                ''show the dialog and allow application to perfrom its panding work.
            Loop
            'if ( d2cur<MinD2Cur) d2cur = MinD2Cur;
            '  if ( d2cur>MaxD2Cur) d2cur = MaxD2Cur;
            '  if (!flag){
            '	 GainX10Off();
            '	 SetMicroOff();
            '	 Gain = FALSE;
            '	}
            '--- Set the Min or Max D2 Current if it out of limits 
            If (intd2cur < MinD2Cur) Then intd2cur = MinD2Cur
            If (intd2cur > MaxD2Cur) Then intd2cur = MaxD2Cur

            If Not (blnflag = True) Then
                Call gobjCommProtocol.funcGain10X_OFF()
                ''put off the Gain10X
                Call gobjCommProtocol.funcSetMICRO_OFF()
                ''put off the MICRO
                blnGain = False
            End If
            'if ( d2cur<MinD2Cur) d2cur = MinD2Cur;
            ' if ( d2cur>MaxD2Cur) d2cur = MaxD2Cur;
            ' Set_D2_Cur(d2cur);
            ' if(GetInstrument() == AA203 ){
            'Set_HCL_Cur(Inst->Cur,Inst->Lamp_pos);
            '  Set_PMT(Inst->Pmtv);
            ' }
            '--- Set the Min or Max D2 Current if it out of limits 
            If (intd2cur < MinD2Cur) Then intd2cur = MinD2Cur
            If (intd2cur > MaxD2Cur) Then intd2cur = MaxD2Cur
            Call gobjCommProtocol.funcSetD2Cur(intd2cur)
            ''for setting D2 current.
            'if(GetInstrument() = AA203 ) then
            gobjCommProtocol.funcSet_HCL_Cur(gobjInst.Current, gobjInst.Lamp_Position)
            ''setting HCL current at given position 
            gobjCommProtocol.funcSet_PMT(gobjInst.PmtVoltage)
            ''setting PMT voltage.
            'end if
            'DestroyWindowPeak(hwnd, hpar);
            'Cal_Mode(xmode);

            objfrmSettingPMT.Close()
            Application.DoEvents()
            ''close the PMT form and allow application to perfrom its panding work.
            gobjCommProtocol.funcCalibrationMode(intxmode)
            ''for setting calibration mode.
            'If (Gain) Then
            'GainX10On();
            'return flag;
            If (blnGain = True) Then
                gobjCommProtocol.funcGain10X_ON()
                ''put Gain10X on
            End If
            Return blnflag
            ''it will return true if succed.


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
            If Not (objfrmSettingPMT) Is Nothing Then
                objfrmSettingPMT.Dispose()
            End If
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Private Function funcBgc_Zero2_RefBeam(ByVal flag1 As Boolean, ByVal dblvalue As Double) As Boolean
        '===========================================================s==========
        ' Procedure Name        : funcBgc_Zero2
        ' Parameters Passed     : flag1, value
        ' Returns               : True or False
        ' Purpose               : To set Auto zero for BGC mode
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 19.12.06
        ' Revisions             : praveen
        '=====================================================================
        Dim intXmode, chnew As Integer
        Dim a, b As Integer
        Dim MaxD2Cur, MinD2Cur As Integer
        Dim intD2cur As Integer
        Dim objfrmSettingPMT As New frmPMT
        ''object for PMT from.
        Dim x1 As Double
        Dim addf As Integer = 1
        Dim chIdx As Integer
        Dim Flag As Boolean = True

        a = 0
        b = 0
        MaxD2Cur = 300
        MinD2Cur = 100

        Try
            '//------
            'Set_D2_Cur(d2cur);
            '		if(GetInstrument() == AA203 ){
            '		 Set_HCL_Cur(Inst->Cur,Inst->Lamp_pos);
            '		 Set_PMT(Inst->Pmtv);
            '	  }
            '	 for(i=0; i<4; i++)
            '		chnew = ReadADCFilter();
            '	 strcpy(line1,"");
            '	 x1 = (chnew-2047.0)/4096.0*10000.0;
            '                    If (GetSRLamp()) Then
            '		sprintf(line1,"SRCur.:%d mA  Energy: %4.1f   ",d2cur, (100.0/value)*x1);
            '                    Else
            '		sprintf(line1,"D2Cur.:%d mA  Energy: %4.1f   ",d2cur, (100.0/value)*x1);
            '	 SetText(hwnd, IDC_STATUS1,line1);
            '	 if (x1<=(value+20.0) && x1>=(value-20.0)) break;
            '	 if (x1>(value+1000.0))  addf=-10;
            '	 else if (x1>(value+200.0))  addf=-5;
            '	 else if (x1>(value+20.0)) { addf=-1; a++;
            '			 if (b>10) b=1; }
            '	 if (x1<(value-1000.0)) addf=10;
            '	 else if (x1<(value-200.0)) addf=5;
            '	 else if (x1<(value-20.0)) { addf=1; b++;}
            '	 d2cur+=addf;
            '	 if ( x1>(value+200.0) && d2cur<=MinD2Cur) {
            '		 if (value==3000)       Gerror_message_new(" Increase HCL Current and retry ", "AABGC ZERO");
            '		 else Gerror_message_new("Error in FULL SCALE SET", "AABGC ZERO");
            '		 pc_delay(5000);
            '		 flag = FALSE; d2cur=MinD2Cur; break;}
            '	 if ( x1<(value-200.0) && d2cur>=MaxD2Cur) {
            '		 if (value==3000)  Gerror_message_new(" Reduce HCL Current and retry again ", "AABGC ZERO");
            '		 else Gerror_message_new("Error in FULL SCALE SET", "AABGC ZERO");
            '		 pc_delay(5000);
            '		 flag = FALSE; d2cur=MaxD2Cur;break;}
            '                                                        If (a > 10) Then
            '		{ if (b>10)  break;
            '		 else a =0;
            '		}
            '	 if (CheckMsg(hwnd, &msg)) if (WP==IDCANCEL)
            '		break;
            '	}
            '//-------

            If gobjCommProtocol.SRLamp Then
                ''check for SR lamp.
                MaxD2Cur = 600
                MinD2Cur = 100
            Else
                MaxD2Cur = 300
                MinD2Cur = 100
            End If

            intXmode = gobjInst.Mode
            ''get a current mode
            If (flag1) Then
                ''flag set by user
                'objfrmSettingPMT.Show()
                gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.AA)
                ''set a calibration mode
                gobjCommProtocol.funcAdj_Pmt_ForValue(0.0, 700.0, True)
                ''adjust the PMT in given range.
                'objfrmSettingPMT.Close()
            End If
            Application.DoEvents()
            ''allow application to perfrom its panding work.
            objfrmSettingPMT = New frmPMT
            objfrmSettingPMT.Text = "Balancing Beam"
            objfrmSettingPMT.Refresh()
            ''initialise the objfrmSettingPMT object.
            Application.DoEvents()
            ''allow application to perfrom its panding work.
            If gobjCommProtocol.SRLamp Then
                ''set for SR lamp.
                'SetText(hwnd, IDC_STATUS,"Setting SRCURRENT :");
                objfrmSettingPMT.lblTitle.Text = "Setting SRCURRENT :"

            Else
                'SetText(hwnd, IDC_STATUS,"Setting D2CURRENT :");
                objfrmSettingPMT.lblTitle.Text = "Setting D2CURRENT :"
            End If
            objfrmSettingPMT.lblTitle.Refresh()

            objfrmSettingPMT.Show()
            objfrmSettingPMT.BringToFront()
            Application.DoEvents()
            ''show the dialog and allow application to perfrom its panding work.
            gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.D2E)
            ''set a calibration mode to D3E

            'if( GetInstrument() == AA202 ){
            '              If (GetSRLamp()) Then
            'd2cur = d2cur;
            '              Else
            'd2cur=Inst->D2cur;
            '}
            'else
            ' d2cur=Inst->D2cur;
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                ''check for 201
                'If (GetSRLamp()) Then
                If gobjCommProtocol.SRLamp = True Then
                    ''check for SR lamp in 201
                    intD2cur = intD2cur
                Else
                    intD2cur = gobjInst.D2Current
                End If
            Else
                intD2cur = gobjInst.D2Current
            End If
            'intD2cur = gobjInst.D2Current

            '//
            Do While (True)
                ''start loop
                gobjCommProtocol.funcSetD2Cur(intD2cur)
                ''set D2 current
                'if(GetInstrument() = AA203 ) then
                gobjCommProtocol.funcSet_HCL_Cur(gobjInst.Current, gobjInst.Lamp_Position)
                ''set a HCL curr at given position.
                gobjCommProtocol.funcSet_PMTReferenceBeam(gobjInst.PmtVoltageReference)
                ''set a PMT for reference beam.
                'end if

                For chIdx = 0 To 5
                    'for(i=0; i<4; i++)
                    'chnew = ReadADCFilter();
                    Call gobjCommProtocol.funcReadADCFilter_ReferenceBeam(gobjInst.Average, chnew)
                    ''read a ADC filter
                Next
                'x1 = (chnew-2047.0)/4096.0*10000.0;
                x1 = (chnew - 2047.0) / 4096.0 * 10000.0

                'If (GetSRLamp()) Then
                'sprintf(line1,"SRCur.:%d mA  Energy: %4.1f   ",d2cur, (100.0/value)*x1);
                '              Else
                'sprintf(line1,"D2Cur.:%d mA  Energy: %4.1f   ",d2cur, (100.0/value)*x1);

                If gobjCommProtocol.SRLamp Then
                    ''set for the SR lamp.
                    'SetText(hwnd, IDC_STATUS,"Setting SRCURRENT :");
                    objfrmSettingPMT.lblMsg.Text = "SRCURRENT. : " & intD2cur.ToString & " mA " _
                                        & "Energy. : " & CStr(Format(((100.0 / dblvalue) * x1), "###0.00"))
                Else
                    'SetText(hwnd, IDC_STATUS,"Setting D2CURRENT :");
                    objfrmSettingPMT.lblMsg.Text = "D2CURRENT : " & intD2cur.ToString & " mA " _
                                        & "Energy. : " & CStr(Format(((100.0 / dblvalue) * x1), "###0.00"))
                End If
                objfrmSettingPMT.lblMsg.Refresh()
                Application.DoEvents()
                ''allow application to perfrom its panding work.

                'If (x1 <= (dblvalue + 20.0) And x1 >= (dblvalue - 20.0)) Then
                '    Exit Do
                'End If
                If (x1 <= (dblvalue + 10.0) And x1 >= (dblvalue - 10.0)) Then
                    Exit Do
                End If

                '//
                'if (x1>(value+1000.0))  addf=-10;
                'else if (x1>(value+200.0))  addf=-5;
                'else if (x1>(value+20.0)) { addf=-1; a++;
                'if (b>10) b=1; }
                '//

                If (x1 > (dblvalue + 1000.0)) Then
                    addf = -10
                ElseIf (x1 > (dblvalue + 200.0)) Then
                    addf = -5
                ElseIf (x1 > (dblvalue + 20.0)) Then
                    addf = -1
                    a += 1
                    If (b > 10) Then b = 1
                End If

                'if (x1<(value-1000.0)) addf=10;
                'else if (x1<(value-200.0)) addf=5;
                'else if (x1<(value-20.0)) { addf=1; b++;}
                If (x1 < (dblvalue - 1000.0)) Then
                    addf = 10
                ElseIf (x1 < (dblvalue - 200.0)) Then
                    addf = 5
                ElseIf (x1 < (dblvalue - 20.0)) Then
                    addf = 1
                    b += 1
                End If

                'd2cur+=addf;
                intD2cur += addf
                '          if ( x1>(value+200.0) && d2cur<=MinD2Cur) {
                ' if (value==3000)       Gerror_message_new(" Increase HCL Current and retry ", "AABGC ZERO");
                ' else Gerror_message_new("Error in FULL SCALE SET", "AABGC ZERO");
                ' pc_delay(5000);
                ' flag = FALSE; d2cur=MinD2Cur; break;}
                'if ( x1<(value-200.0) && d2cur>=MaxD2Cur) {
                ' if (value==3000)  Gerror_message_new(" Reduce HCL Current and retry again ", "AABGC ZERO");
                ' else Gerror_message_new("Error in FULL SCALE SET", "AABGC ZERO");
                ' pc_delay(5000);
                ' flag = FALSE; d2cur=MaxD2Cur;break;}
                '                              If (a > 10) Then
                '{ if (b>10)  break;
                ' else a =0;
                '}

                If (x1 > (dblvalue + 200.0) And intD2cur <= MinD2Cur) Then
                    If (dblvalue = 3000) Then
                        'Gerror_message_new(" Increase HCL Current and retry ", "AABGC ZERO")
                        'gobjMessageAdapter.ShowMessage(constReduceHCL)
                        gobjMessageAdapter.ShowMessage(constIncreaseHCl)
                    Else
                        'Gerror_message_new("Error in FULL SCALE SET", "AABGC ZERO");
                        gobjMessageAdapter.ShowMessage(constErrorFULLSCALE)
                    End If

                    'pc_delay(5000);
                    gobjCommProtocol.mobjCommdll.subTime_Delay(50)
                    ''communication delay
                    intD2cur = MinD2Cur
                    Flag = False
                    Exit Do
                End If
                If (x1 < (dblvalue - 200.0) And intD2cur >= MaxD2Cur) Then
                    If (dblvalue = 3000) Then
                        'Gerror_message_new(" Reduce HCL Current and retry again ", "AABGC ZERO");
                        gobjMessageAdapter.ShowMessage(constReduceHCL)
                    Else
                        'Gerror_message_new("Error in FULL SCALE SET", "AABGC ZERO");
                        gobjMessageAdapter.ShowMessage(constErrorFULLSCALE)
                    End If
                    'pc_delay(5000);
                    gobjCommProtocol.mobjCommdll.subTime_Delay(50)
                    intD2cur = MaxD2Cur
                    Flag = False
                    Exit Do
                End If
                ';break;}

                If (a > 10) Then
                    If (b > 10) Then
                        Exit Do
                    Else
                        a = 0
                    End If
                End If
                '//-

                If objfrmSettingPMT.mCancelProcess = True Then
                    Exit Do
                End If
                objfrmSettingPMT.BringToFront()
                objfrmSettingPMT.Refresh()
                Application.DoEvents()
                ''show the PMT dialog and allow application to perfrom its panding work.
            Loop

            'if ( d2cur<MinD2Cur) d2cur = MinD2Cur;
            'if ( d2cur>MaxD2Cur) d2cur = MaxD2Cur;
            'Set_D2_Cur(d2cur);
            'if(GetInstrument() == AA203 ){
            ' Set_HCL_Cur(Inst->Cur,Inst->Lamp_pos);
            ' Set_PMT(Inst->Pmtv);
            '}

            '--- Set the Min or Max D2 Current if it out of limits 
            If (intD2cur < MinD2Cur) Then
                intD2cur = MinD2Cur
            End If

            If (intD2cur > MaxD2Cur) Then
                intD2cur = MaxD2Cur
            End If
            Call gobjCommProtocol.funcSetD2Cur(intD2cur)
            ''SERIAL COMMUNICATION FOR setting given D2 current.

            'if(GetInstrument() == AA203 ){
            Call gobjCommProtocol.funcSet_HCL_Cur(gobjInst.Current, gobjInst.Lamp_Position)
            ''set the HCL current
            Call gobjCommProtocol.funcSet_PMTReferenceBeam(gobjInst.PmtVoltageReference)
            ''set a PMT for reference beam
            '}
            objfrmSettingPMT.Close()
            Application.DoEvents()
            ''close the form and allow application to perfrom its panding work.
            'Cal_Mode(xmode);
            gobjCommProtocol.funcCalibrationMode(intXmode)
            ''set a calibration mode
            funcBgc_Zero2_RefBeam = Flag
            '//---

            '//

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
            If Not (objfrmSettingPMT Is Nothing) Then
                objfrmSettingPMT.Dispose()
            End If
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Private Function funcBgc_Zero3_RefBeam(ByVal flag1 As Boolean, ByVal dblvalue As Double) As Boolean
        '=====================================================================
        ' Procedure Name        : funcBgc_Zero3
        ' Parameters Passed     :  flag1, value
        ' Returns               : True or False
        ' Purpose               : To set Auto zero for BGC mode
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 19.12.06
        ' Revisions             : praveen
        '=====================================================================
        'int 		d2cur;
        'double   x1=0;
        'int     addf=1,i;
        'char    line1[80]="";
        'BOOL	  flag=TRUE;
        'int     xmode, chnew, a=0, b=0;
        'int	gtry=0;
        'BOOL	Micro=FALSE;
        'BOOL	Gain=FALSE;
        'int MaxD2Cur=300,MinD2Cur = 100;
        '//-----
        Dim intd2cur As Integer
        Dim dblx1 As Double = 0
        Dim intaddf As Integer = 1
        Dim inti As Integer
        'char    line1[80]="";
        Dim blnflag As Boolean = True
        Dim intxmode, intchnew As Integer
        Dim a As Integer = 0
        Dim b As Integer = 0
        Dim intgtry As Integer = 0
        Dim blnMicro As Boolean = False
        Dim blnGain As Boolean = False
        Dim MaxD2Cur As Integer = 300
        Dim MinD2Cur As Integer = 100
        Dim objfrmSettingPMT As New frmPMT
        Dim chIdx As Integer
        '//-----
        Try
            'if( GetSRLamp() ){
            '	MaxD2Cur = 600;
            '	MinD2Cur = 100;
            '}
            'else{
            '	MaxD2Cur = 300;
            '	MinD2Cur = 100;
            '}
            '  GainX10Off();
            '  SetMicroOff();
            '  WaitForAdc();
            '  xmode = Inst->Mode;

            '  if(GetInstrument() == AA202 ){
            '	 if( GetSRLamp()){
            '		d2cur=Inst->D2cur;
            '                        If (d2cur <= 100) Then
            '			d2cur = 101;
            '		Set_D2_Cur(d2cur);
            '	 }
            '  }
            '  if (flag1) {
            '	 Cal_Mode(AA);
            '	 Adj_PMT_forvalue(hpar, (double) 0.0 , (double)700.0);
            '	 }
            '  hwnd= CreateWindowPeak(hpar, "BGC ZERO","PMTADJ", 0);
            '                                If (GetSRLamp()) Then
            '	  SetText(hwnd, IDC_STATUS,"Setting SRCURRENT :");
            '                                Else
            '	  SetText(hwnd, IDC_STATUS,"Setting D2CURRENT :");
            '  Cal_Mode(D2E);

            '  if( GetInstrument() == AA202 ){
            '                                        If (GetSRLamp()) Then
            '		d2cur = d2cur;
            '                                        Else
            '		d2cur=Inst->D2cur;
            '  }
            '  else
            '	  d2cur=Inst->D2cur;

            '  while(flag){
            '	 Set_D2_Cur(d2cur);
            '	 if(GetInstrument() == AA203 ){
            '		 Set_HCL_Cur(Inst->Cur,Inst->Lamp_pos);
            '		 Set_PMT(Inst->Pmtv);
            '	 }
            '	 for(i=0; i<4; i++)
            '		chnew = ReadADCFilter();
            '	 strcpy(line1,"");
            '	 x1 = (chnew-2047.0)/4096.0*10000.0;

            '                                                        If (GetSRLamp()) Then
            '		 sprintf(line1,"SRCur.:%d mA  Energy: %4.1f   ",d2cur, (100.0/value)*x1);
            '                                                        Else
            '		 sprintf(line1,"D2Cur.:%d mA  Energy: %4.1f   ",d2cur, (100.0/value)*x1);

            '	 SetText(hwnd, IDC_STATUS1,line1);
            '	 if (x1<=(value+20.0) && x1>=(value-20.0)) break;
            '	 if (x1>(value+1000.0))  addf=-10;
            '	 else if (x1>(value+200.0))  addf=-5;
            '	 else if (x1>(value+20.0)) { addf=-1; a++;
            '			 if (b>10) b=1; }
            '	 if (x1<(value-1000.0)) addf=10;
            '	 else if (x1<(value-200.0)) addf=5;
            '	 else if (x1<(value-20.0)) { addf=1; b++;}
            '	 d2cur+=addf;
            '	 if (d2cur<=MinD2Cur ){
            '		d2cur=MinD2Cur;
            '		Set_D2_Cur(d2cur);

            '		if(GetInstrument() == AA203 ){
            '		 Set_HCL_Cur(Inst->Cur,Inst->Lamp_pos);
            '		 Set_PMT(Inst->Pmtv);
            '		}

            '	 TryNextMode(hwnd, &Gain, &Micro, &gtry, d2cur, value);
            '	  }
            '	 if ( d2cur>=MaxD2Cur ){// || (x1<(value-200.0) && d2cur>=300)) {
            '//		d2cur=MinD2Cur;
            '		d2cur=101;//MaxD2Cur;
            '		Set_D2_Cur(d2cur);
            '		if(GetInstrument() == AA203 ){
            '		 Set_HCL_Cur(Inst->Cur,Inst->Lamp_pos);
            '		 Set_PMT(Inst->Pmtv);
            '		}
            '		TryNextMode(hwnd, &Gain, &Micro, &gtry, d2cur,value);
            '		}
            '	 if (gtry==4){
            '		if (value==3000)
            '		  Gerror_message_new(" Reduce HCL Current and retry ","AABGC ZERO");
            '                                                                                                Else
            '		  Gerror_message_new("Error in FULL SCALE SET", "AABGC ZERO");
            '		pc_delay(5000);
            '		flag = FALSE; d2cur=MinD2Cur; break;
            '	  }
            '	 if (a>10)	{
            '		 if (b>10)  break;
            '		 else a =0;
            '		}
            '	 if (CheckMsg(hwnd, &msg)) if (WP==IDCANCEL)
            '		break;
            '	}
            '  if ( d2cur<MinD2Cur) d2cur = MinD2Cur;
            '  if ( d2cur>MaxD2Cur) d2cur = MaxD2Cur;
            '  if (!flag){
            '	 GainX10Off();
            '	 SetMicroOff();
            '	 Gain = FALSE;
            '	}

            '  if ( d2cur<MinD2Cur) d2cur = MinD2Cur;
            '  if ( d2cur>MaxD2Cur) d2cur = MaxD2Cur;
            '  Set_D2_Cur(d2cur);
            '  if(GetInstrument() == AA203 ){
            '	Set_HCL_Cur(Inst->Cur,Inst->Lamp_pos);
            '	  Set_PMT(Inst->Pmtv);
            '  }
            '  DestroyWindowPeak(hwnd, hpar);
            '  Cal_Mode(xmode);
            '                                                                                                                                        If (Gain) Then
            '	 GainX10On();
            ' return flag;
            '}
            'If (GetSRLamp()) Then
            '	MaxD2Cur = 600;
            '	MinD2Cur = 100;
            '}
            'else{
            '	MaxD2Cur = 300;
            '	MinD2Cur = 100;
            '}  

            '======================================

            If gobjCommProtocol.SRLamp Then
                ''for checking SR lamp
                MaxD2Cur = 600
                MinD2Cur = 100
            Else
                MaxD2Cur = 300
                MinD2Cur = 100
            End If

            intxmode = gobjInst.Mode
            Call gobjCommProtocol.funcGain10X_OFF()
            ''for gain 10 off
            Call gobjCommProtocol.funcSetMICRO_OFF()
            ''for micro offf
            Call subWaitForAdc()
            'xmode = Inst->Mode;
            intxmode = gobjInst.Mode
            ''get a mode.

            '//----- for AA202 
            'if(GetInstrument() == AA202 ){
            'if( GetSRLamp()){
            'd2cur=Inst->D2cur;
            '                  If (d2cur <= 100) Then
            '	d2cur = 101;
            'Set_D2_Cur(d2cur);
            '}
            '}
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                ''check for 201
                'If (GetSRLamp()) Then
                If gobjCommProtocol.SRLamp = True Then
                    ''for SR lamp
                    'intd2cur = intd2cur
                    intd2cur = gobjInst.D2Current
                    If intd2cur <= 100 Then
                        intd2cur = 101
                    End If
                    gobjCommProtocol.funcSetD2Cur(intd2cur)
                    ''for setting D2 current
                    ''function for setting D2 current
                End If
            End If
            'if (flag1) {
            'Cal_Mode(AA);
            'Adj_PMT_forvalue(hpar, (double) 0.0 , (double)700.0);
            '}
            If (flag1) = True Then
                'objfrmSettingPMT.Show()
                Call gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.AA)
                ''check a calibration mode.
                Call gobjCommProtocol.funcAdj_Pmt_ForValue_Ref(0.0, 700.0, True)
                ''for adjust a PMT for given range.
                'objfrmSettingPMT.Close()
            End If



            'hwnd= CreateWindowPeak(hpar, "BGC ZERO","PMTADJ", 0);
            '          If (GetSRLamp()) Then
            ' SetText(hwnd, IDC_STATUS,"Setting SRCURRENT :");
            '          Else
            ' SetText(hwnd, IDC_STATUS,"Setting D2CURRENT :");
            'Cal_Mode(D2E);

            Application.DoEvents()
            ''allow application to perfrom its panding work
            objfrmSettingPMT = New frmPMT
            objfrmSettingPMT.Text = "BGC ZERO"
            objfrmSettingPMT.Refresh()

            If gobjCommProtocol.SRLamp Then
                ''set for SR lamp
                'SetText(hwnd, IDC_STATUS,"Setting SRCURRENT :");
                'objfrmSettingPMT.lblTitle.Text = "Setting SRCURRENT :"
                objfrmSettingPMT.lblTitle.Text = "Setting SRCURRENT : "

            Else
                'SetText(hwnd, IDC_STATUS,"Setting D2CURRENT :");
                objfrmSettingPMT.lblTitle.Text = "Setting D2CURRENT : "
            End If
            objfrmSettingPMT.lblTitle.Refresh()

            objfrmSettingPMT.Show()
            Application.DoEvents()
            ''show the form and allow application to perfrom its panding work.
            gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.D2E)
            ''set a calibration mode to D2E
            ''set a given calibration mode.

            'if( GetInstrument() == AA202 ){
            '              If (GetSRLamp()) Then
            'd2cur = d2cur;
            '              Else
            'd2cur=Inst->D2cur;
            '}
            'else
            ' d2cur=Inst->D2cur;
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                ''check for 201
                'If (GetSRLamp()) Then
                If gobjCommProtocol.SRLamp = True Then
                    'intd2cur = intd2cur
                    intd2cur = intd2cur
                Else
                    intd2cur = gobjInst.D2Current
                End If
            Else
                intd2cur = gobjInst.D2Current
            End If
            'intd2cur = gobjInst.D2Current

            Do While (True)

                gobjCommProtocol.funcSetD2Cur(intd2cur)
                ''set a D2 curr
                'if(GetInstrument() = AA203 ) then
                gobjCommProtocol.funcSet_HCL_Cur(gobjInst.Current, gobjInst.Lamp_Position)
                ''set a HCL current at given position.
                gobjCommProtocol.funcSet_PMTReferenceBeam(gobjInst.PmtVoltageReference)
                ''for setting PMT of reference beam 
                'end if

                'for(i=0; i<4; i++)
                'chnew = ReadADCFilter();
                'strcpy(line1,"");

                For chIdx = 0 To 4
                    'for(i=0; i<4; i++)
                    'chnew = ReadADCFilter();
                    Call gobjCommProtocol.funcReadADCFilter_ReferenceBeam(gobjInst.Average, intchnew)
                    ''for read a ADC filter
                Next
                'x1 = (chnew-2047.0)/4096.0*10000.0;
                dblx1 = (intchnew - 2047.0) / 4096.0 * 10000.0

                'If (GetSRLamp()) Then
                ' sprintf(line1,"SRCur.:%d mA  Energy: %4.1f   ",d2cur, (100.0/value)*x1);
                '              Else
                ' sprintf(line1,"D2Cur.:%d mA  Energy: %4.1f   ",d2cur, (100.0/value)*x1);

                'SetText(hwnd, IDC_STATUS1,line1);
                If gobjCommProtocol.SRLamp Then

                    ''check for SR lamp.

                    'SetText(hwnd, IDC_STATUS,"Setting SRCURRENT :");
                    objfrmSettingPMT.lblMsg.Text = "SRCURRENT. : " & intd2cur.ToString & " mA " _
                                    & "Energy. : " & CStr(Format(((100.0 / dblvalue) * dblx1), "###0.00"))
                    'objfrmSettingPMT.lblMsg.Text = "Energy. : " & CStr(((100.0 / dblvalue) * dblx1))
                Else
                    'SetText(hwnd, IDC_STATUS,"Setting D2CURRENT :");
                    objfrmSettingPMT.lblMsg.Text = "D2CURRENT : " & intd2cur.ToString & " mA " _
                                            & " Energy. : " & CStr(Format(((100.0 / dblvalue) * dblx1), "###0.00"))
                    'objfrmSettingPMT.lblMsg.Text = "Energy. : " & CStr(((100.0 / dblvalue) * dblx1))
                End If

                objfrmSettingPMT.lblMsg.Refresh()
                Application.DoEvents()
                ''allow application to perfrom its panding work

                'if (x1<=(value+20.0) && x1>=(value-20.0)) break;
                If (dblx1 <= (dblvalue + 20.0) And dblx1 >= (dblvalue - 20.0)) Then
                    Exit Do
                End If
                'if (x1>(value+1000.0))  addf=-10;
                '	 else if (x1>(value+200.0))  addf=-5;
                '	 else if (x1>(value+20.0)) { addf=-1; a++;
                '			 if (b>10) b=1; }

                If (dblx1 > (dblvalue + 1000.0)) Then
                    intaddf = -10
                ElseIf (dblx1 > (dblvalue + 200.0)) Then
                    intaddf = -5
                ElseIf (dblx1 > (dblvalue + 20.0)) Then
                    intaddf = -1
                    a += 1
                    If (b > 10) Then b = 1
                End If

                '	 if (x1<(value-1000.0)) addf=10;
                '	 else if (x1<(value-200.0)) addf=5;
                '	 else if (x1<(value-20.0)) { addf=1; b++;}
                If (dblx1 < (dblvalue - 1000.0)) Then
                    intaddf = 10
                ElseIf (dblx1 < (dblvalue - 200.0)) Then
                    intaddf = 5
                ElseIf (dblx1 < (dblvalue - 20.0)) Then
                    intaddf = 1
                    b += 1
                End If
                'd2cur+=addf;
                intd2cur += intaddf

                'if (d2cur<=MinD2Cur ){
                'd2cur=MinD2Cur;
                'Set_D2_Cur(d2cur);

                'if(GetInstrument() == AA203 ){
                ' Set_HCL_Cur(Inst->Cur,Inst->Lamp_pos);
                ' Set_PMT(Inst->Pmtv);
                '}

                'TryNextMode(hwnd, &Gain, &Micro, &gtry, d2cur, value);
                ' }
                If (intd2cur <= MinD2Cur) Then
                    intd2cur = MinD2Cur
                    gobjCommProtocol.funcSetD2Cur(intd2cur)
                    ''for setting D2 current
                    'If (GetInstrument() = AA203) Then
                    gobjCommProtocol.funcSet_HCL_Cur(gobjInst.Current, gobjInst.Lamp_Position)
                    ''set a HCL current at given turreart position
                    gobjCommProtocol.funcSet_PMTReferenceBeam(gobjInst.PmtVoltageReference)
                    ''for setting PMT of reference beam.
                    'End If
                    subTryNextMode(blnGain, blnMicro, intgtry, intd2cur, dblvalue)
                End If
                'if (gtry==4){
                'if (value==3000)
                '  Gerror_message_new(" Reduce HCL Current and retry ","AABGC ZERO");
                '                  Else
                '  Gerror_message_new("Error in FULL SCALE SET", "AABGC ZERO");
                'pc_delay(5000);
                'flag = FALSE; d2cur=MinD2Cur; break;
                ' }
                If (intgtry = 4) Then
                    If (dblvalue = 3000) Then
                        gobjMessageAdapter.ShowMessage(constReduceHCL)
                    Else
                        gobjMessageAdapter.ShowMessage(constErrorFULLSCALE)
                    End If
                    'pc_delay(5000)
                    gobjCommProtocol.mobjCommdll.subTime_Delay(50)
                    ''for delay
                    blnflag = False
                    intd2cur = MinD2Cur
                    'break()
                    Exit Do
                End If
                '              if (a>10)	{
                ' if (b>10)  break;
                ' else a =0;
                '}
                If (a > 10) Then
                    If (b > 10) Then
                        Exit Do
                    Else
                        a = 0
                    End If
                End If
                '//=-=---- Define by Sachin Dokhale
                '//----- Set the interupt for exit 
                'if (CheckMsg(hwnd, &msg)) if (WP==IDCANCEL)
                'break;
                If objfrmSettingPMT.mCancelProcess = True Then
                    ''exit if true.
                    Exit Do
                End If
                '//-----
                objfrmSettingPMT.BringToFront()
                objfrmSettingPMT.Refresh()
                Application.DoEvents()
                ''allow application to perfrom its panding work bet loop
            Loop
            'if ( d2cur<MinD2Cur) d2cur = MinD2Cur;
            '  if ( d2cur>MaxD2Cur) d2cur = MaxD2Cur;
            '  if (!flag){
            '	 GainX10Off();
            '	 SetMicroOff();
            '	 Gain = FALSE;
            '	}

            '--- Set the Min or Max D2 Current if it out of limits 
            If (intd2cur < MinD2Cur) Then intd2cur = MinD2Cur
            If (intd2cur > MaxD2Cur) Then intd2cur = MaxD2Cur

            If Not (blnflag = True) Then
                Call gobjCommProtocol.funcGain10X_OFF()
                ''put Gain10 off
                Call gobjCommProtocol.funcSetMICRO_OFF()
                ''put MICRO off
                blnGain = False
            End If
            'if ( d2cur<MinD2Cur) d2cur = MinD2Cur;
            ' if ( d2cur>MaxD2Cur) d2cur = MaxD2Cur;
            ' Set_D2_Cur(d2cur);
            ' if(GetInstrument() == AA203 ){
            'Set_HCL_Cur(Inst->Cur,Inst->Lamp_pos);
            '  Set_PMT(Inst->Pmtv);
            ' }

            '--- Set the Min or Max D2 Current if it out of limits 
            If (intd2cur < MinD2Cur) Then intd2cur = MinD2Cur
            If (intd2cur > MaxD2Cur) Then intd2cur = MaxD2Cur
            Call gobjCommProtocol.funcSetD2Cur(intd2cur)
            ''for setting D2 Curr

            'if(GetInstrument() = AA203 ) then
            gobjCommProtocol.funcSet_HCL_Cur(gobjInst.Current, gobjInst.Lamp_Position)
            ''for setting HCL current at given position 
            gobjCommProtocol.funcSet_PMTReferenceBeam(gobjInst.PmtVoltageReference)
            ''for setting PMT of reference beam
            'end if
            'DestroyWindowPeak(hwnd, hpar);
            'Cal_Mode(xmode);

            objfrmSettingPMT.Close()
            Application.DoEvents()
            ''close the from and allow application to perfrom its panding work
            gobjCommProtocol.funcCalibrationMode(intxmode)
            ''for setting calibration mode.
            'If (Gain) Then
            'GainX10On();
            'return flag;
            If (blnGain = True) Then
                gobjCommProtocol.funcGain10X_ON()
                ''put on the Gain10x on.
            End If
            Return blnflag
            'Return gobjCommProtocol.funcAdj_Pmt_ForValue(0.0, 600, True)

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
            If Not (objfrmSettingPMT) Is Nothing Then
                objfrmSettingPMT.Dispose()
            End If
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Private Sub subTryNextMode(ByRef Gain As Boolean, ByRef Micro As Boolean, ByRef gtry As Integer, _
                                ByVal intd2cur As Integer, ByVal dblvalue As Double)
        '=====================================================================
        ' Procedure Name        : subTryNextMode
        ' Parameters Passed     :  Gain,Micro,gtry,intd2cur,dblvalue
        ' Returns               :  None
        ' Purpose               : 
        ' Description           : Try Next Mode
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 03.01.07
        ' Revisions             : praveen
        '=====================================================================
        Dim intchnew, inti As Integer
        Dim dblx1 As Integer = 0
        Try
            'if (ReadIniForD2Gain() && Re0adIniForMesh()){
            ' if (*gtry==0){
            ' if (*Gain || *Micro){
            '	if (*Gain){
            '	  *Gain=FALSE;
            '	  GainX10Off();
            '	  WaitForAdc();
            '	 }
            '	if (*Micro){
            '	  SetMicroOff();
            '	  *Micro=FALSE;
            '	  WaitForAdc();
            '	 }
            '	}
            ' else{
            '	*gtry=1;
            '	SetMicroOn();
            '	*Micro=TRUE;
            '	WaitForAdc();
            '  }
            '}
            ' else if (*gtry==1){
            ' SetMicroOff();
            ' *Micro=FALSE;
            ' GainX10On();
            ' *Gain=TRUE;
            ' WaitForAdc();
            ' *gtry=2;
            '}
            ' else if (*gtry==2){
            ' GainX10On(); *Gain=TRUE;
            ' SetMicroOn();*Micro=TRUE;
            ' WaitForAdc();
            ' *gtry=3;
            '}
            ' else if (*gtry==3){
            ' *gtry=4;
            '}
            ' }
            'else  if (ReadIniForD2Gain()){
            'if (*gtry==0){
            '	*gtry=1;
            '	GainX10On();
            '	*Gain=TRUE;
            '	WaitForAdc();
            ' }
            'else if (*gtry==1)
            ' *gtry=4;
            ' }
            'else if  (ReadIniForMesh()){
            ' if (*gtry==0){
            '	*gtry=1;
            '	SetMicroOn();
            '	*Micro=TRUE;
            '	WaitForAdc();
            '  }
            ' else if (*gtry==1)
            '	*gtry=4;
            '}

            'If (ReadIniForD2Gain() And ReadIniForMesh()) Then
            If (gstructSettings.D2Gain And gstructSettings.Mesh) Then
                ''check for D2 gain and MESH
                If (gtry = 0) Then
                    If (Gain Or Micro) Then
                        If (Gain = True) Then
                            Gain = False
                            Call gobjCommProtocol.funcGain10X_OFF()
                            ''for putting Gain10X off 
                            subWaitForAdc()
                            ''set wait for ADC filter
                        End If
                        If (Micro) Then
                            Call gobjCommProtocol.funcSetMICRO_OFF()
                            ''for putting micro off 
                            Micro = False
                            Call subWaitForAdc()
                            ''wait for ADC
                        End If
                    Else
                        gtry = 1
                        gobjCommProtocol.funcSetMICRO_ON()
                        ''set ON micro
                        Micro = True
                        ''make true the micro flag 
                        Call subWaitForAdc()
                        ''wait for ADC
                    End If

                ElseIf (gtry = 1) Then
                    Call gobjCommProtocol.funcSetMICRO_OFF()
                    ''set micro OFF
                    Micro = False
                    ''set flag false
                    gobjCommProtocol.funcGain10X_ON()
                    ''on the gain
                    Gain = True
                    Call subWaitForAdc()
                    ''wait for ADC
                    gtry = 2

                ElseIf (gtry = 2) Then
                    gobjCommProtocol.funcGain10X_ON()
                    ''on the gain
                    Gain = True
                    'SetMicroOn()
                    gobjCommProtocol.funcSetMICRO_ON()
                    ''set micro on
                    Micro = True
                    Call subWaitForAdc()
                    ''wait for ADC
                    gtry = 3

                ElseIf (gtry = 3) Then
                    gtry = 4
                End If

            ElseIf (gstructSettings.D2Gain = True) Then
                If (gtry = 0) Then
                    gtry = 1
                    Call gobjCommProtocol.funcGain10X_ON()
                    ''put on gain
                    Gain = True
                    Call subWaitForAdc()
                    ''wait for ADC
                Else
                    If (gtry = 1) Then
                        gtry = 4
                    End If
                End If
            ElseIf (gstructSettings.Mesh) Then
                If (gtry = 0) Then
                    gtry = 1
                    gobjCommProtocol.funcSetMICRO_ON()
                    ''set on micro
                    Micro = True
                    Call subWaitForAdc()
                    ''wait for ADC reading
                    '' To set some wait time in ADC reading.
                ElseIf (gtry = 1) Then
                    gtry = 4
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

    Public Function funcReadFilterSetting() As Boolean
        '=====================================================================
        ' Procedure Name        : funcReadFilterSetting
        ' Parameters Passed     :  none
        ' Returns               : True if success
        ' Purpose               : Read Filter Setting
        ' Description           : 
        ' Assumptions           : gstructSettings is initiated
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 19.12.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is used for reading a filter setting.
        ''set gintTimeConstant here.
        Try
            Select Case gstructSettings.TimeConstant
                ''set a gintTimeConstant  as par case for the fliter setting 
            Case Is >= 10
                    gintTimeConstant = 0
                Case Is >= 5.0
                    gintTimeConstant = 1
                Case Is >= 2.0
                    gintTimeConstant = 2
                Case Is >= 1.0
                    gintTimeConstant = 3
                Case Is >= 0.2
                    gintTimeConstant = 4
                Case Is >= 0.1
                    gintTimeConstant = 5
                Case Else
                    gintTimeConstant = 2
            End Select

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

    Public Function funcGetAbsScanX() As Double
        '=====================================================================
        ' Procedure Name        : funcGetAbsScanX
        ' Parameters Passed     :  None
        ' Returns               : double
        ' Purpose               : To Get Abs value from ADC
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 19.12.06
        ' Revisions             : praveen
        '=====================================================================
        Dim dblAbsdata As Double
        Dim intadval As Integer
        Try
            'Application.DoEvents()
            Call gobjCommProtocol.funcReadADCFilter(gobjInst.Average, intadval)
            ''get a current ADC value in to intadval

            dblAbsdata = gFuncGetADConvertedToCurMode(intadval)
            If (gobjInst.Mode = EnumCalibrationMode.EMISSION) Then
                dblAbsdata -= funcGet_Emission_Zero()
            End If
            Return dblAbsdata
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

    Public Function funcGetAbsScanX_RefBeam() As Double
        '=====================================================================
        ' Procedure Name        : funcGetAbsScanX
        ' Parameters Passed     : none 
        ' Returns               : double
        ' Purpose               : To Get Abs value from ADC for Ref. Beam
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 07.04.07
        ' Revisions             : praveen
        '=====================================================================

        Try
            'double	GetAbsScanX(void)
            '{
            Dim dblAbsdata As Double
            Dim intadval As Integer
            'Application.DoEvents()
            Call gobjCommProtocol.funcReadADCFilter_ReferenceBeam(gobjInst.Average, intadval)
            ''function for reading ADC filter reading for reference beam
            'data = (double) GetADConvertedToCurMode(adval);
            dblAbsdata = gFuncGetADConvertedToCurMode(intadval)
            ''get ADC converted in to mode.
            If (gobjInst.Mode = EnumCalibrationMode.EMISSION) Then
                ''for emission mode
                '--- Set Abs value for Emission mode
                dblAbsdata -= funcGet_Emission_Zero()
            End If
            'Application.DoEvents()
            Return dblAbsdata
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

    Public Function funcGetAbsScanX_DoubleBeam() As Double
        '=====================================================================
        ' Procedure Name        : funcGetAbsScanX_DoubleBeam
        ' Parameters Passed     :  None
        ' Returns               : double,Abs value
        ' Purpose               : To Get Abs value from ADC for Duoble Beam
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 07.04.07
        ' Revisions             : praveen
        '=====================================================================

        Try
            'double	GetAbsScanX(void)
            '{
            Dim dblAbsdata As Double
            Dim intadval As Integer
            'Application.DoEvents()
            Call gobjCommProtocol.funcReadADCFilter_DoubleBeam(gobjInst.Average, intadval)
            ''for reading a ADC filter
            'data = (double) GetADConvertedToCurMode(adval);
            dblAbsdata = gFuncGetADConvertedToCurMode(intadval)
            ''convert ADC to mode
            'dblAbsdata = intadval
            If (gobjInst.Mode = EnumCalibrationMode.EMISSION) Then
                ''for emission
                '--- Set Abs value for Emission mode
                dblAbsdata -= funcGet_Emission_Zero()
            End If
            'Application.DoEvents()
            Return dblAbsdata
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

    Public Function funcGet_Emission_Zero() As Double
        '=====================================================================
        ' Procedure Name        : funcGet_Emission_Zero
        ' Parameters Passed     :  None
        ' Returns               : double
        ' Purpose               : To Get Autozero for Emission
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 19.12.06
        ' Revisions             : praveen
        '=====================================================================
        Try
            Return mEmsZero
            ''it will return a emission zero value.

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

    Public Function Auto_blank_Emission(ByVal blnFlag As Boolean) As Boolean
        '=====================================================================
        ' Procedure Name        : Auto_blank_Emission
        ' Parameters Passed     : blnFlag   
        ' Returns               : True or false
        ' Purpose               : To Get Auto Blank to Emission
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 19.12.06
        ' Revisions             : praveen
        '=====================================================================

        Try
            Auto_blank_Emission = False
            '    BOOL 	S4FUNC 	Auto_blank_Emission(HWND hwnd, BOOL flag)
            '{
            'char  line1[80]="";
            Dim intadval As Integer
            Dim blnflag1 As Boolean = False
            If Not (gobjInst.Mode = EnumCalibrationMode.EMISSION) Then
                Return False
            End If
            If (blnFlag = True) Then
                'if(GetInstrument() == AA202 )
                'Check_Ignite_AA202(hwnd);
                'Else

                If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                    ''check for 201
                    blnflag1 = funcCheck_Ignite_AA201()
                Else
                    ''for other instrument
                    blnflag1 = funcCheck_Ignite()
                End If

                If blnflag1 = True Then
                    'funcCheck_Ignite_AA202()
                    'sprintf(line1," Auto Blank Program  for %s",Inst->Lamp_par.lamp[Inst->Lamp_pos-1].elname);
                    '	  SetText(hwnd, IDC_STATUS1,line1);
                    '	  Blink_MessageBox(hwnd, "Aspirate Blank and Press OK", " AUTO BLANK", 0);
                    '//	  MessageBox(hwnd, "Aspirate Blank and Press OK", " AUTO BLANK", MB_OK);
                    '	  pc_delay(1000);
                    '	  adval = ReadADCFilter();
                    '	  EmsZero= (double) GetADConvertedTo(adval, MODE_EMISSION);
                    'MessageBox(hwnd, "Aspirate Blank and Press OK", " AUTO BLANK", MB_OK);

                    'Call gobjMessageAdapter.ShowMessage(constAspirate_Blank) 'commented by pankaj on 1 Dec 07 for unnecessary showing message box on analysis
                    ''show the Aspirate blank message
                    gobjCommProtocol.mobjCommdll.subTime_Delay(10)
                    ''dely of 10
                    Call gobjCommProtocol.funcReadADCFilter(gobjInst.Average, intadval)
                    ''for reading a ADC filter
                    'mEmsZero =  gobjCommProtocol. funcGetADConvertedTo(adval, MODE_EMISSION);
                    mEmsZero = gfuncGetADConvertedIntoMode(intadval, modGlobalConstants.EnumCalibrationMode.EMISSION)
                    ''convert ADC in to mode.
                Else
                    Return False
                End If
            Else
                gobjCommProtocol.mobjCommdll.subTime_Delay(10)
                ''for delay
                Call gobjCommProtocol.funcReadADCFilter(gobjInst.Average, intadval)
                ''for reading a ADC filter
                'mEmsZero =  gobjCommProtocol. funcGetADConvertedTo(adval, MODE_EMISSION);
                mEmsZero = gfuncGetADConvertedIntoMode(intadval, modGlobalConstants.EnumCalibrationMode.EMISSION)
                ''convert ADC into mode.
            End If

            Return True


            ' if (flag){
            '	if(GetInstrument() == AA202 )
            '		Check_Ignite_AA202(hwnd);
            '                    Else
            '		Check_Ignite();
            '	if (flag1)   {
            '	  sprintf(line1," Auto Blank Program  for %s",Inst->Lamp_par.lamp[Inst->Lamp_pos-1].elname);
            '	  SetText(hwnd, IDC_STATUS1,line1);
            '	  Blink_MessageBox(hwnd, "Aspirate Blank and Press OK", " AUTO BLANK", 0);
            '//	  MessageBox(hwnd, "Aspirate Blank and Press OK", " AUTO BLANK", MB_OK);
            '	  pc_delay(1000);
            '	  adval = ReadADCFilter();
            '	  EmsZero= (double) GetADConvertedTo(adval, MODE_EMISSION);
            '	}
            '                        Else
            '		return FALSE;
            '  }
            ' else{
            '	 pc_delay(1000);
            '	 adval = ReadADCFilter();
            '	 EmsZero= (double) GetADConvertedTo(adval, MODE_EMISSION);
            '	}
            'return TRUE;
            '}
            '{


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

    Public Function Auto_blank_Emission_DoubleBeam(ByVal blnFlag As Boolean) As Boolean
        '=====================================================================
        ' Procedure Name        : Auto_blank_Emission
        ' Parameters Passed     : blnFlag 
        ' Returns               : True / False
        ' Purpose               : To Get Auto Blank to Emission
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 19.12.06
        ' Revisions             : praveen
        '=====================================================================
        Dim intadval As Integer
        Dim blnflag1 As Boolean = False
        Try
            Auto_blank_Emission_DoubleBeam = False
            '    BOOL 	S4FUNC 	Auto_blank_Emission(HWND hwnd, BOOL flag)
            '{
            'char  line1[80]="";
            If Not (gobjInst.Mode = EnumCalibrationMode.EMISSION) Then
                Return False
            End If
            '--- Check tha flag for Ignite condition
            If (blnFlag = True) Then
                'if(GetInstrument() == AA202 )
                'Check_Ignite_AA202(hwnd);
                'Else

                If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                    ''check for 201
                    blnflag1 = funcCheck_Ignite_AA201()
                Else
                    blnflag1 = funcCheck_Ignite()
                End If

                If blnflag1 = True Then
                    'funcCheck_Ignite_AA202()
                    'sprintf(line1," Auto Blank Program  for %s",Inst->Lamp_par.lamp[Inst->Lamp_pos-1].elname);
                    '	  SetText(hwnd, IDC_STATUS1,line1);
                    '	  Blink_MessageBox(hwnd, "Aspirate Blank and Press OK", " AUTO BLANK", 0);
                    '//	  MessageBox(hwnd, "Aspirate Blank and Press OK", " AUTO BLANK", MB_OK);
                    '	  pc_delay(1000);
                    '	  adval = ReadADCFilter();
                    '	  EmsZero= (double) GetADConvertedTo(adval, MODE_EMISSION);
                    'MessageBox(hwnd, "Aspirate Blank and Press OK", " AUTO BLANK", MB_OK);

                    Call gobjMessageAdapter.ShowMessage(constAspirate_Blank)
                    ''set a aspirate blank mess
                    gobjCommProtocol.mobjCommdll.subTime_Delay(10)
                    ''delay
                    Call gobjCommProtocol.funcReadADCFilter(gobjInst.Average, intadval)
                    ''read ADC filter
                    'mEmsZero =  gobjCommProtocol. funcGetADConvertedTo(adval, MODE_EMISSION);
                    mEmsZero = gfuncGetADConvertedIntoMode(intadval, modGlobalConstants.EnumCalibrationMode.EMISSION)
                    ''convert ADC in to mode.
                Else
                    Return False
                End If
            Else
                gobjCommProtocol.mobjCommdll.subTime_Delay(10)
                ''delay
                Call gobjCommProtocol.funcReadADCFilter(gobjInst.Average, intadval)
                ''read ADC filter
                'mEmsZero =  gobjCommProtocol. funcGetADConvertedTo(adval, MODE_EMISSION);
                mEmsZero = gfuncGetADConvertedIntoMode(intadval, modGlobalConstants.EnumCalibrationMode.EMISSION)
                ''convert ADC in to mode
            End If

            Return True


            ' if (flag){
            '	if(GetInstrument() == AA202 )
            '		Check_Ignite_AA202(hwnd);
            '                    Else
            '		Check_Ignite();
            '	if (flag1)   {
            '	  sprintf(line1," Auto Blank Program  for %s",Inst->Lamp_par.lamp[Inst->Lamp_pos-1].elname);
            '	  SetText(hwnd, IDC_STATUS1,line1);
            '	  Blink_MessageBox(hwnd, "Aspirate Blank and Press OK", " AUTO BLANK", 0);
            '//	  MessageBox(hwnd, "Aspirate Blank and Press OK", " AUTO BLANK", MB_OK);
            '	  pc_delay(1000);
            '	  adval = ReadADCFilter();
            '	  EmsZero= (double) GetADConvertedTo(adval, MODE_EMISSION);
            '	}
            '                        Else
            '		return FALSE;
            '  }
            ' else{
            '	 pc_delay(1000);
            '	 adval = ReadADCFilter();
            '	 EmsZero= (double) GetADConvertedTo(adval, MODE_EMISSION);
            '	}
            'return TRUE;
            '}
            '{


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

    'Public Function funcCheck_Ignite_sachin() As Boolean
    '    '=====================================================================
    '    ' Procedure Name        : funcCheck_Ignite
    '    ' Parameters Passed     : None
    '    ' Returns               : 
    '    ' Purpose               : 
    '    ' Description           : not in used
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Sachin Dokhale
    '    ' Created               : 21.12.06
    '    ' Revisions             : 
    '    '=====================================================================
    '    Dim str As String
    '    'char 		str[80]="";
    '    Dim aa, ps1, ps2, ps3 As Integer
    '    Dim flag As Boolean = True
    '    'int   	aa, ps1, ps2, ps3, flag = TRUE;
    '    Dim data As Byte
    '    'BYTE  	data;
    '    Dim count As Integer = 1
    '    'int   	count=1;
    '    Dim bData As Byte
    '    Dim blnFlame_Present As Boolean = False

    '    '        BOOL 		S4FUNC Check_Ignite()
    '    '{
    '    '#If DEMO Then
    '    ' return TRUE;
    '    '#Else
    '    'char 		str[80]="";
    '    'int   	aa, ps1, ps2, ps3, flag = TRUE;
    '    'BYTE  	data;
    '    'int   	count=1;
    '    'HWND hpar=NULL;
    '    '	hpar = GetTopWindow(NULL);
    '    ' if(!Flame_Present(FALSE))  {
    '    '	ps1 = ps2 = ps3 = ON;
    '    '	data = CHECK_BUR_PAR();
    '    '	if (data & AA_CONNECTED) aa = ON;
    '    '	else aa = OFF;
    '    '	data  = CHECK_PS();
    '    '	if (data & AIR_NOK)  ps1 = OFF;
    '    '	if (data & N2O_NOK)  ps2 = OFF;
    '    '	if (data & FUEL_NOK) ps3 = OFF;
    '    '	if (ps1==OFF) {
    '    '	  Gerror_message_new("Low Air Pressure Switch on Tank and RETRY "," ***PNEUMATICS ERROR *** ");
    '    '	  flag=FALSE;
    '    '	 }
    '    '	if (aa!=ON && ps2==OFF) {
    '    '		Gerror_message_new("Low Nitrous Oxide Pressure Switch on N2O Tank and RETRY "," ***PNEUMATICS ERROR *** ");
    '    '		flag = FALSE;
    '    '	  }
    '    '	if (ps3==OFF) {
    '    '	  Gerror_message_new("Low Fuel Pressure Switch on Fuel Tank and RETRY "," ***PNEUMATICS ERROR *** ");
    '    '	  flag = FALSE;
    '    '	 }
    '    '	strcpy (str,"");
    '    '	if (Ignite_Test()!=GREEN)
    '    '	 flag=FALSE;
    '    '	if (aa) strcpy(str," Ready for Air-Acetelyne Flame ..  IGNITE ?");
    '    '	else strcpy(str," Ready for N2o-Acetelyne Flame ..  IGNITE ?");
    '    '	if (flag){
    '    '		  if (MessageBox(NULL, str , " AUTO IGNITION ", MB_YESNO)==IDYES)
    '    '//	  if (MessageBox(hpar, str , " AUTO IGNITION ", MB_YESNO)==IDYES)
    '    '		 Ignite(TRUE);
    '    '	}
    '    '	while(!Flame_Present(FALSE)&&count<3)	{
    '    '	  count++;
    '    '                                                            If (flag) Then
    '    '//		  if (MessageBox(NULL, " Flame not Ignited . Retry ? ", " AUTO IGNITION ", MB_YESNO)==IDYES)
    '    '		  if (MessageBox(hpar, " Flame not Ignited . Retry ? ", " AUTO IGNITION ", MB_YESNO)==IDYES)
    '    '			 Ignite(TRUE);
    '    '	  }
    '    '  }
    '    '                                                                    If (Flame_Present(False)) Then
    '    '	return TRUE;
    '    '                                                                    Else
    '    '	return FALSE;
    '    '#End If
    '    '}
    '    Try
    '        ' if(!Flame_Present(FALSE))  {
    '        '	ps1 = ps2 = ps3 = ON;
    '        '	data = CHECK_BUR_PAR();
    '        '	if (data & AA_CONNECTED) aa = ON;
    '        '	else aa = OFF;
    '        '	data  = CHECK_PS();
    '        '	if (data & AIR_NOK)  ps1 = OFF;
    '        '	if (data & N2O_NOK)  ps2 = OFF;
    '        '	if (data & FUEL_NOK) ps3 = OFF;
    '        If Not funcFlame_Present(False) Then
    '            '  ps1 = ps2 = ps3 = ON
    '            'ps1 = True
    '            'ps2 = True
    '            'ps3 = True

    '            If gobjCommProtocol.gFuncPneumatics() Then
    '            End If

    '            gobjCommProtocol.funcCheckBurnerParameters(bData)
    '            ''for checking a burner parameter.

    '            If (bData And EnumErrorStatus.AA_CONNECTED) Then
    '                aa = True
    '            Else
    '                aa = False
    '            End If

    '            If Not funcIgnite_Test() = enumIgniteType.Green Then
    '                flag = False
    '            End If

    '            If aa Then
    '                str = "Ready for Air-Acetelyne Flame ..  IGNITE ?"
    '            Else
    '                str = "Ready for N2O-Acetelyne Flame ..  IGNITE ?"
    '            End If

    '            If flag Then
    '                'If MessageBox.Show(str, "AUTO IGNITION", MessageBoxButtons.YesNo) = DialogResult.Yes Then
    '                '    Ignite(True)
    '                'End If
    '                gobjMessageAdapter.ShowMessage(str, "AUTO IGNITION", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
    '                funcIgnite(True)
    '            End If

    '            'if (flag){
    '            '	  if (MessageBox(NULL, str , " AUTO IGNITION ", MB_YESNO)==IDYES)
    '            '//	  if (MessageBox(hpar, str , " AUTO IGNITION ", MB_YESNO)==IDYES)
    '            '		 Ignite(TRUE);
    '            '	}
    '            blnFlame_Present = funcFlame_Present(False)

    '            While (Not blnFlame_Present) And count < 3
    '                count += 1
    '                If flag Then
    '                    'If MessageBox.Show("Flame not Ignited. Retry?", "AUTO IGNITION", MessageBoxButtons.YesNo) = DialogResult.Yes Then
    '                    If gobjMessageAdapter.ShowMessage(constFlameRetry) = True Then
    '                        Application.DoEvents()
    '                        funcIgnite(True)
    '                    End If
    '                End If
    '            End While
    '        End If

    '        If funcFlame_Present(False) Then
    '            Return True
    '        Else
    '            Return False
    '        End If

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        '---------------------------------------------------------
    '        Return False
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try
    'End Function

    Public Function funcCheck_Ignite() As Boolean
        '=====================================================================
        ' Procedure Name        : funcCheck_Ignite
        ' Parameters Passed     : None
        ' Returns               : boolean
        ' Purpose               : for checking a ignition setting.like air , fuel , N2o etc.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin 
        ' Created               : 09.03.07
        ' Revisions             : modified by deepak on 09.03.07
        '=====================================================================
        'BOOL 		S4FUNC Check_Ignite()
        '{
        '#If DEMO Then
        ' return TRUE;
        '#Else
        'char 		str[80]="";
        'int   	aa, ps1, ps2, ps3, flag = TRUE;
        'BYTE  	data;
        'int   	count=1;
        'HWND hpar=NULL;

        '	hpar = GetTopWindow(NULL);
        ' if(!Flame_Present(FALSE))  { //0
        '	ps1 = ps2 = ps3 = ON;
        '	data = CHECK_BUR_PAR();
        '	if (data & AA_CONNECTED) aa = ON;
        '	else aa = OFF;
        '	data  = CHECK_PS();
        '	if (data & AIR_NOK)  ps1 = OFF;
        '	if (data & N2O_NOK)  ps2 = OFF;
        '	if (data & FUEL_NOK) ps3 = OFF;
        '	if (ps1==OFF) { //1
        '	  Gerror_message_new("Low Air Pressure Switch on Tank and RETRY "," ***PNEUMATICS ERROR *** ");
        '	  flag=FALSE;
        '	 } //1
        '	if (aa!=ON && ps2==OFF) {//2
        '		Gerror_message_new("Low Nitrous Oxide Pressure Switch on N2O Tank and RETRY "," ***PNEUMATICS ERROR *** ");
        '		flag = FALSE;
        '	  }//2
        '	if (ps3==OFF) {//3
        '	  Gerror_message_new("Low Fuel Pressure Switch on Fuel Tank and RETRY "," ***PNEUMATICS ERROR *** ");
        '	  flag = FALSE;
        '	 }//3
        '	strcpy (str,"");
        '	if (Ignite_Test()!=GREEN)
        '	 flag=FALSE;
        '	if (aa) strcpy(str," Ready for Air-Acetelyne Flame ..  IGNITE ?");
        '	else strcpy(str," Ready for N2o-Acetelyne Flame ..  IGNITE ?");
        '	if (flag){//4
        '		  if (MessageBox(NULL, str , " AUTO IGNITION ", MB_YESNO)==IDYES)
        '		 Ignite(TRUE);
        '	}//4
        '	while(!Flame_Present(FALSE)&&count<3)	{//5
        '	  count++;
        '   If (flag) Then
        '		  if (MessageBox(hpar, " Flame not Ignited . Retry ? ", " AUTO IGNITION ", MB_YESNO)==IDYES)
        '			 Ignite(TRUE);
        '	  }//5
        '  }//0
        'If (Flame_Present(False)) Then
        '	return TRUE;
        'Else
        '	return FALSE;
        '#End If
        '}

        Dim str As String
        Dim aa, ps1, ps2, ps3 As Boolean
        Dim flag As Boolean = True
        'Dim data As Byte
        Dim count As Integer = 1
        Dim bData As Byte
        Dim blnFlame_Present As Boolean = False

        Try
            'If gstructSettings.AppMode = EnumAppMode.DemoMode Then
            If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                ''always return true for demo mode
                Return True
            End If

            If Not funcFlame_Present(False) Then
                ''check for a flame present
                ps1 = True  ' To check for Air pressure 
                ps2 = True  ' To check for N2O pressure 
                ps3 = True  ' To check for Fuel pressure 

                gobjCommProtocol.funcCheckBurnerParameters(bData)
                ''check a burner parameter
                If (bData And EnumErrorStatus.AA_CONNECTED) Then
                    ''check a cond
                    aa = True
                Else
                    aa = False
                End If

                gobjCommProtocol.funcPressSensorStatus(bData)
                ''get a pressSensor status
                If (bData And EnumErrorStatus.AIR_NOK) Then
                    ''check Air nok flag.
                    ps1 = False
                End If
                If (bData And EnumErrorStatus.N2O_NOK) Then
                    ''check N2O nok flag.
                    ps2 = False
                End If
                If (bData And EnumErrorStatus.FUEL_NOK) Then
                    ''ckeck FUEL nok
                    ps3 = False
                End If

                If ps1 = False Then
                    'MessageBox.Show("Low Air Pressure Switch on Tank and RETRY", "PNEUMATICS ERROR")
                    gobjMessageAdapter.ShowMessage(constLowAirPressureRetry)
                    flag = False
                End If

                If (aa <> True And ps2 = False) Then
                    gobjMessageAdapter.ShowMessage(constLowNitrousPressureRetry)
                    flag = False
                End If

                If ps3 = False Then
                    gobjMessageAdapter.ShowMessage(constLowFuelPressureRetry)
                    flag = False
                End If

                str = ""
                '--- Modified function of funcIgnite_Test by Sachin Dokhale on 04.02.07
                'If Not funcIgnite_Test() = enumIgniteType.Green Then
                '    ''test the ignition by color
                '    flag = False
                'End If
                Dim intIgnite_Test As enumIgniteType
                If Not funcIgnite_Test(intIgnite_Test) Then
                    If intIgnite_Test = enumIgniteType.Green Then
                        flag = False
                    End If
                End If
                '---

                If aa = True Then
                    ''prompt a mess as per cond
                    str = "Ready for Air-Acetelyne Flame ..  IGNITE ?"
                Else
                    str = "Ready for N2O-Acetelyne Flame ..  IGNITE ?"
                End If

                If flag Then
                    If gobjMessageAdapter.ShowMessage(str, "AUTO IGNITION", MessageHandler.clsMessageHandler.enumMessageType.QuestionMessage) = True Then
                        Application.DoEvents()
                        ''allow application to perfrom its panding work
                        Call funcIgnite(True)
                        ''ignite the flame
                    End If
                End If
                Application.DoEvents()
                ''allow application to perfrom its panding work.
                While (Not funcFlame_Present(False) And count < 3)
                    ''start loop
                    count += 1
                    If flag Then
                        If gobjMessageAdapter.ShowMessage(constFlameRetry) = True Then
                            Application.DoEvents()
                            ''allow application to perfrom its panding work 
                            ''and ignite a flame.
                            Call funcIgnite(True)
                        End If
                    End If
                    Application.DoEvents()
                    ''allow application to perfrom its panding work.

                End While
            End If
            Application.DoEvents()
            ''allow application to perfrom its panding work.
            If funcFlame_Present(False) Then
                ''if flame is not present
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

    Public Function funcCheck_Ignite_AA201() As Boolean
        '=====================================================================
        ' Procedure Name        : funcCheck_Ignite_AA201
        ' Parameters Passed     : bool
        ' Returns               : 
        ' Purpose               : for checking ignition setting for 201
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.12.06
        ' Revisions             : praveen
        '=====================================================================
        Dim str As String
        'char 		str[80]="";
        Dim aa, ps1, ps2, ps3 As Integer
        Dim flag As Boolean = True
        'int   	aa, ps1, ps2, ps3, flag = TRUE;
        Dim data As Byte
        'BYTE  	data;
        Dim count As Integer = 1
        'int   	count=1;
        Dim bData As Byte
        Dim blnFlame_Present As Boolean = False
        Dim blnFlagCheckIgnite As Boolean = False   'Saurabh----22.06.2007

        Try
            '//-----()
            'BOOL 		S4FUNC Check_Ignite_AA202(HWND hwnd)
            '{
            '#If DEMO Then
            ' return TRUE;
            '#Else
            'char 		str[80]="";
            'int   	aa, ps1, ps2, ps3, flag = TRUE;
            'BYTE  	data;
            'int   	count=1;

            ' if(!Flame_Present(FALSE))  {
            '	ps1 = ps2 = ps3 = ON;
            '	data = CHECK_BUR_PAR();
            '	if (data & AA_CONNECTED) aa = ON;
            '	else aa = OFF;
            '	data  = CHECK_PS();
            '	if (data & AIR_NOK)  ps1 = OFF;
            '	if (data & N2O_NOK)  ps2 = OFF;
            '	if (data & FUEL_NOK) ps3 = OFF;
            '	if (ps1==OFF) {
            '	  Gerror_message_new("Low Air Pressure Switch on Tank and RETRY "," ***PNEUMATICS ERROR *** ");
            '	  flag=FALSE;
            '	 }
            '	if (aa!=ON && ps2==OFF) {
            '		Gerror_message_new("Low Nitrous Oxide Pressure Switch on N2O Tank and RETRY "," ***PNEUMATICS ERROR *** ");
            '		flag = FALSE;
            '	  }
            '	if (ps3==OFF) {
            '	  Gerror_message_new("Low Fuel Pressure Switch on Fuel Tank and RETRY "," ***PNEUMATICS ERROR *** ");
            '	  flag = FALSE;
            '	 }
            '	strcpy (str,"");
            '	if (Ignite_Test()!=GREEN)
            '	 flag=FALSE;
            '	if (aa) strcpy(str," Ready for Air-Acetelyne Flame ..  IGNITE ?");
            '	else strcpy(str," Ready for N2o-Acetelyne Flame ..  IGNITE ?");
            '	if (flag){
            '//	  if (MessageBox(NULL, str , " MANUAL IGNITION ", MB_YESNO)==IDYES)
            '	  if (MessageBox(hwnd, str , " MANUAL IGNITION ", MB_YESNO)==IDYES)
            '			Manual_Init(hwnd);
            '	}
            '	while(!Flame_Present(FALSE)&&count<3)	{
            '	  count++;
            '                                                                If (flag) Then
            '//		  if (MessageBox(NULL, " Flame not Ignited . Retry ? ", " MANUAL IGNITION ", MB_YESNO)==IDYES)
            '		  if (MessageBox(hwnd, " Flame not Ignited . Retry ? ", " MANUAL IGNITION ", MB_YESNO)==IDYES)
            '			 Manual_Init(hwnd);
            '	  }
            '  }
            '                                                                        If (Flame_Present(False)) Then
            '	return TRUE;
            '                                                                        Else
            '	return FALSE;
            '#End If
            '}

            '//-----

            'If gstructSettings.AppMode = EnumAppMode.DemoMode Then
            If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                'always return true for demo mode.
                Return True
            End If

            If Not funcFlame_Present(False) Then
                'check for flame present
                '  ps1 = ps2 = ps3 = ON

                If gobjCommProtocol.gFuncPneumatics() Then
                    'check for pneumatics setting

                End If

                gobjCommProtocol.funcCheckBurnerParameters(bData)
                'check burner parameter
                '--- Assign flag of AA burner connection
                If (bData And EnumErrorStatus.AA_CONNECTED) Then
                    aa = True
                Else
                    aa = False
                End If

                '--- Check the Ignite test for green color type for analysis
                '--- Modified function of funcIgnite_Test by Sachin Dokhale on 04.02.07
                'If Not funcIgnite_Test() = enumIgniteType.Green Then
                '    'check a ignite with respect to color
                '    flag = False
                'End If
                Dim intIgnite_Test As enumIgniteType
                If Not funcIgnite_Test(intIgnite_Test) Then
                    If intIgnite_Test = enumIgniteType.Green Then
                        flag = False
                    End If
                End If
                '---

                If aa Then
                    str = "Ready for Air-Acetelyne Flame ..  IGNITE ?"
                Else
                    str = "Ready for N2O-Acetelyne Flame ..  IGNITE ?"
                End If

                '****************Commented by Saurabh--22.06.07
                'If flag Then
                '    'If MessageBox.Show(str, "AUTO IGNITION", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                '    '    Ignite(True)
                '    'End If
                '    gobjMessageAdapter.ShowMessage(str, "MANUAL IGNITION", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                '    '//----- To be required change for manual Ignition of AA201
                '    'funcIgnite(True)

                'End If

                ''if (flag){
                ''	  if (MessageBox(NULL, str , " AUTO IGNITION ", MB_YESNO)==IDYES)
                ''//	  if (MessageBox(hpar, str , " AUTO IGNITION ", MB_YESNO)==IDYES)
                ''		 Ignite(TRUE);
                ''	}
                'blnFlame_Present = funcFlame_Present(False)

                'While (Not blnFlame_Present) And count < 3
                '    count += 1
                '    If flag Then
                '        If gobjMessageAdapter.ShowMessage(constFlameRetry) = True Then
                '            '    funcIgnite(True)

                '        End If
                '    End If
                'End While
                '****************Commented by Saurabh--22.06.07

                'Saurabh----22.06.07
                If flag Then
                    If gobjMessageAdapter.ShowMessage(str, "MANUAL IGNITION", MessageHandler.clsMessageHandler.enumMessageType.QuestionMessage) = True Then
                        Dim objfrmManualIgnition As New frmManualIgnition

                        ' code added by : dinesh wagh on 22.3.2009
                        ' code start
                        If gstructSettings.AppMode = EnumAppMode.DemoMode_201 Or _
                            gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                            objfrmManualIgnition.Width = objfrmManualIgnition.Width - 175
                            objfrmManualIgnition.StartPosition = FormStartPosition.CenterScreen
                        End If
                        '........code ends.

                        objfrmManualIgnition.ShowDialog()
                        ''if flag is true then show manualignition dialog
                    Else
                        If gobjMessageAdapter.ShowMessage(constFlameRetry) = True Then
                            Dim objfrmManualIgnition As New frmManualIgnition
                            ' code added by : dinesh wagh on 22.3.2009
                            ' code start
                            If gstructSettings.AppMode = EnumAppMode.DemoMode_201 Or _
                                gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                                objfrmManualIgnition.Width = objfrmManualIgnition.Width - 175
                                objfrmManualIgnition.StartPosition = FormStartPosition.CenterScreen
                            End If
                            '........code ends.

                            objfrmManualIgnition.ShowDialog()
                            'show the manualIgnition dialog.
                            'Else

                        End If
                    End If
                End If
                blnFlame_Present = funcFlame_Present(False)
                ''set a value for blnFlame_Present  flag.

                While (Not blnFlame_Present) And count < 2
                    count += 1
                    If flag Then
                        If gobjMessageAdapter.ShowMessage(constFlameRetry) = True Then
                            Dim objfrmManualIgnition As New frmManualIgnition
                            ' code added by : dinesh wagh on 22.3.2009
                            ' code start
                            If gstructSettings.AppMode = EnumAppMode.DemoMode_201 Or _
                                gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                                objfrmManualIgnition.Width = objfrmManualIgnition.Width - 175
                                objfrmManualIgnition.StartPosition = FormStartPosition.CenterScreen
                            End If
                            '........code ends.

                            objfrmManualIgnition.ShowDialog()
                            'show the manualIgnition dialog.
                        End If
                    End If
                End While
                'Saurabh----22.06.07

            End If
            '--- Check the flame for it's presenty and it is the return true
            If funcFlame_Present(False) Then
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

    Public Function funcIgnite_Test() As enumIgniteType
        '=====================================================================
        ' Procedure Name        : Check_Ignite
        ' Parameters Passed     : None
        ' Returns               : enumIgniteType
        ' Purpose               : for ignite status display
        '                         
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.12.06
        ' Revisions             : praveen
        '=====================================================================
        '#define    ON  1
        '#define    OFF 0

        'int S4FUNC Ignite_Test()
        '{
        '   BYTE st, st1;
        '   BOOL  ps1, ps2, ps3,aa,tr, dr;
        '   int	 flag = 0;

        '   if (!Inst.Aaf && !Inst.N2of) 
        '   {
        '       ps1 = ps2 = ps3 = ON;
        '	    st  = CHECK_PS();
        '	    if (st & AIR_NOK) ps1 = OFF;
        '	    if (st & N2O_NOK) ps2 = OFF;
        '	    if (st & FUEL_NOK) ps3 = OFF;
        '	    st1 = CHECK_BUR_PAR();
        '	    if (st1 & AA_CONNECTED) aa=ON;	// N2O/AA
        '	        else aa=OFF;
        '	    if (st1 & TRAP_NOK) tr=OFF;
        '	        else tr=ON;
        '	    if (st1 &DOOR_NOK) dr=OFF;
        '	        else dr=ON;
        '	    if (!ps3) flag=2;
        '	    if (!ps1) flag = 3;
        '	    if (!aa) if (!ps2) flag = 4;
        '	    if (!dr) flag=5;
        '	    if (!tr) flag=6;
        '   }
        '   else 
        '   {
        '       Check_Flame();
        '	    st = CHECK_PS();
        '	    if ((st&YELLOW_OK) ==YELLOW_OK) flag=-2;
        '	    else  if ((st&BLUE_OK)==BLUE_OK)  flag=-1;
        '	    else if ((st & FLAME_OK)==FLAME_OK) flag=-1;
        '   }
        '   #If DEMO Then
        '       flag = random(8)-2;
        '   #End If

        '   if (flag==-1)
        '	    return BLUE;
        '   if (flag==-2)
        '       return YELLOW;

        '   If (flag) Then
        '       return RED;
        '   Else
        '	    return GREEN;
        '}

        Dim st, st1 As Byte
        Dim ps1, ps2, ps3, aa, tr, dr As Boolean
        Dim flag As Integer = 0

        Const const_ON = 1
        Const const_OFF = 0

        Try

            '----------------------------------------
            'If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
            '    Application.DoEvents()
            '    Call funcCheck_Flame()
            '    If gobjCommProtocol.funcPressSensorStatus(st, False) Then
            '        ''check a presssensor status
            '        If ((st And EnumErrorStatus.YELLOW_OK) = EnumErrorStatus.YELLOW_OK) Then
            '            flag = -2
            '            gobjInst.Aaf = True
            '        ElseIf ((st And EnumErrorStatus.BLUE_OK) = EnumErrorStatus.BLUE_OK) Then
            '            flag = -1
            '            gobjInst.Aaf = True
            '        ElseIf ((st And EnumErrorStatus.FLAME_OK) = EnumErrorStatus.FLAME_OK) Then
            '            flag = -1
            '            gobjInst.Aaf = True
            '        Else
            '            gobjInst.Aaf = False
            '        End If
            '    End If
            'End If
            '----------------------------------------

            Application.DoEvents()
            ''allow application to perfrom its panding work
            If (Not (gobjInst.Aaf = True)) And (Not (gobjInst.N2of = True)) Then
                'ps1 = ps2 = ps3 = ON;
                ps1 = True  ' To check for Air pressure 
                ps2 = True  ' To check for N2O pressure 
                ps3 = True  ' To check for Fuel pressure 

                If gobjCommProtocol.funcPressSensorStatus(st, False) Then
                    ''check a presssensor status
                    If (st And EnumErrorStatus.AIR_NOK) Then
                        ps1 = False
                    End If
                    If (st And EnumErrorStatus.N2O_NOK) Then
                        ps2 = False
                    End If
                    If (st And EnumErrorStatus.FUEL_NOK) Then
                        ps3 = False
                    End If
                End If

                If gobjCommProtocol.funcCheckBurnerParameters(st1, False) Then
                    ''check for burner parameter

                    'if (st1 and  EnumErrorStatus.AA_CONNECTED) aa=ON;	// N2O/AA
                    'else aa=OFF;
                    If (st1 And EnumErrorStatus.AA_CONNECTED) Then
                        aa = True
                    Else
                        aa = False
                    End If
                    'if (st1 & TRAP_NOK) tr=OFF;
                    'else tr=ON;
                    If (st1 And EnumErrorStatus.TRAP_NOK) Then
                        tr = False
                    Else
                        tr = True
                    End If

                    'if (st1 &DOOR_NOK) dr=OFF;
                    'else dr=ON;
                    If (st1 And EnumErrorStatus.DOOR_NOK) Then
                        ''check for door
                        dr = False
                    Else
                        dr = True
                    End If
                End If

                If Not (ps3) Then flag = 2
                If Not (ps1) Then flag = 3
                If Not (aa) Then If Not (ps2) Then flag = 4
                If Not (dr) Then flag = 5
                If Not (tr) Then flag = 6
                'if (!ps3) flag=2;
                'if (!ps1) flag = 3;
                'if (!aa) if (!ps2) flag = 4;
                'if (!dr) flag=5;
                'if (!tr) flag=6;

            Else
                Call funcCheck_Flame()
                ''for checking flame.
                'st = CHECK_PS();
                '--- Get the info. of pressor sensor from instrument
                If gobjCommProtocol.funcPressSensorStatus(st, False) Then
                    If ((st And EnumErrorStatus.YELLOW_OK) = EnumErrorStatus.YELLOW_OK) Then
                        flag = -2
                    ElseIf ((st And EnumErrorStatus.BLUE_OK) = EnumErrorStatus.BLUE_OK) Then
                        flag = -1
                    ElseIf ((st And EnumErrorStatus.FLAME_OK) = EnumErrorStatus.FLAME_OK) Then
                        flag = -1
                    End If
                Else

                End If
                'if ((st&YELLOW_OK) ==YELLOW_OK) flag=-2;
                'else  if ((st&BLUE_OK)==BLUE_OK)  flag=-1;
                'else if ((st & FLAME_OK)==FLAME_OK) flag=-1;
            End If
            '#If DEMO Then
            ' flag = random(8)-2;
            '#End If

            'if (flag == -1)
            '   return BLUE;
            'if (flag == -2)
            '   return YELLOW;

            'If (flag) Then
            '   return RED;
            'Else
            '   return GREEN;
            '}
            'Dim nRandom As New Random
            '#If DEMO Then
            '   intflag = nRandom.Next(8) -2
            '#End If

            If (flag = -1) Then
                ''set a igniteType as per flag.
                Return enumIgniteType.Blue
            End If

            If (flag = -2) Then
                ''set a igniteType as per flag.
                Return enumIgniteType.Yellow
            End If

            If (flag) Then
                ''set a igniteType as per flag.
                Return enumIgniteType.Red
            Else
                Return enumIgniteType.Green
            End If
            Application.DoEvents()
            ''allow application to perfrom its panding work
        Catch threadex As Threading.ThreadAbortException
            '---Do Nothing
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

    Public Function funcIgnite_Test(ByRef InIgniteType As enumIgniteType) As Boolean
        '=====================================================================
        ' Procedure Name        : Check_Ignite
        ' Parameters Passed     : None
        ' Returns               : enumIgniteType
        ' Purpose               : for ignite status display
        '                         
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.12.06
        ' Revisions             : praveen
        '=====================================================================
        '#define    ON  1
        '#define    OFF 0

        'int S4FUNC Ignite_Test()
        '{
        '   BYTE st, st1;
        '   BOOL  ps1, ps2, ps3,aa,tr, dr;
        '   int	 flag = 0;

        '   if (!Inst.Aaf && !Inst.N2of) 
        '   {
        '       ps1 = ps2 = ps3 = ON;
        '	    st  = CHECK_PS();
        '	    if (st & AIR_NOK) ps1 = OFF;
        '	    if (st & N2O_NOK) ps2 = OFF;
        '	    if (st & FUEL_NOK) ps3 = OFF;
        '	    st1 = CHECK_BUR_PAR();
        '	    if (st1 & AA_CONNECTED) aa=ON;	// N2O/AA
        '	        else aa=OFF;
        '	    if (st1 & TRAP_NOK) tr=OFF;
        '	        else tr=ON;
        '	    if (st1 &DOOR_NOK) dr=OFF;
        '	        else dr=ON;
        '	    if (!ps3) flag=2;
        '	    if (!ps1) flag = 3;
        '	    if (!aa) if (!ps2) flag = 4;
        '	    if (!dr) flag=5;
        '	    if (!tr) flag=6;
        '   }
        '   else 
        '   {
        '       Check_Flame();
        '	    st = CHECK_PS();
        '	    if ((st&YELLOW_OK) ==YELLOW_OK) flag=-2;
        '	    else  if ((st&BLUE_OK)==BLUE_OK)  flag=-1;
        '	    else if ((st & FLAME_OK)==FLAME_OK) flag=-1;
        '   }
        '   #If DEMO Then
        '       flag = random(8)-2;
        '   #End If

        '   if (flag==-1)
        '	    return BLUE;
        '   if (flag==-2)
        '       return YELLOW;

        '   If (flag) Then
        '       return RED;
        '   Else
        '	    return GREEN;
        '}

        Dim st, st1 As Byte
        Dim ps1, ps2, ps3, aa, tr, dr As Boolean
        Dim flag As Integer = 0

        Const const_ON = 1
        Const const_OFF = 0

        Try

            '----------------------------------------
            'If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
            '    Application.DoEvents()

            '    Call funcCheck_Flame()
            '    If gobjCommProtocol.funcPressSensorStatus(st, False) Then
            '        ''check a presssensor status
            '        If ((st And EnumErrorStatus.YELLOW_OK) = EnumErrorStatus.YELLOW_OK) Then
            '            flag = -2
            '            'gobjInst.Aaf = True
            '        ElseIf ((st And EnumErrorStatus.BLUE_OK) = EnumErrorStatus.BLUE_OK) Then
            '            flag = -1
            '            'gobjInst.Aaf = True
            '        ElseIf ((st And EnumErrorStatus.FLAME_OK) = EnumErrorStatus.FLAME_OK) Then
            '            flag = -1
            '            'gobjInst.Aaf = True
            '        Else
            '            gobjInst.Aaf = False
            '        End If
            '    Else
            '        Return False
            '    End If
            'End If
            '----------------------------------------

            Application.DoEvents()
            ''allow application to perfrom its panding work
            If (Not (gobjInst.Aaf = True)) And (Not (gobjInst.N2of = True)) Then
                'ps1 = ps2 = ps3 = ON;
                ps1 = True  ' To check for Air pressure 
                ps2 = True  ' To check for N2O pressure 
                ps3 = True  ' To check for Fuel pressure 
                If gobjCommProtocol.funcPressSensorStatus(st, False) Then
                    ''check a presssensor status
                    If (st And EnumErrorStatus.AIR_NOK) Then
                        ps1 = False
                    End If
                    If (st And EnumErrorStatus.N2O_NOK) Then
                        ps2 = False
                    End If
                    If (st And EnumErrorStatus.FUEL_NOK) Then
                        ps3 = False
                    End If
                Else
                    Return False
                End If
                If gobjCommProtocol.funcCheckBurnerParameters(st1, False) Then
                    ''check for burner parameter

                    'if (st1 and  EnumErrorStatus.AA_CONNECTED) aa=ON;	// N2O/AA
                    'else aa=OFF;
                    If (st1 And EnumErrorStatus.AA_CONNECTED) Then
                        aa = True
                    Else
                        aa = False
                    End If
                    'if (st1 & TRAP_NOK) tr=OFF;
                    'else tr=ON;
                    If (st1 And EnumErrorStatus.TRAP_NOK) Then
                        tr = False
                    Else
                        tr = True
                    End If

                    '---Burner Head Confirmation    'added on 30.03.09
                    '---------------------------------------------------------
                    If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                        If gstructSettings.NewModelName = True Then   '---changed for ver 6.89
                            If (st1 And EnumErrorStatus.BurnerHead_Present) Then
                                gblnBurnerMsg = False
                            Else
                                gobjCommProtocol.func_N2O_OFF()
                                gobjCommProtocol.func_FUEL_OFF()
                                If gblnBurnerMsg = False Then
                                    'Call gobjMessageAdapter.ShowMessage("Burner Head/Tether not present", "Warning", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                                    gobjMessageAdapter.ShowMessage(constBurnerHeadMsg)
                                    gblnBurnerMsg = True
                                End If
                            End If
                        End If
                    End If
                    '---------------------------------------------------------

                    'if (st1 &DOOR_NOK) dr=OFF;
                    'else dr=ON;
                    If (st1 And EnumErrorStatus.DOOR_NOK) Then
                        ''check for door
                        dr = False
                    Else
                        dr = True
                    End If
                Else
                    Return False
                End If

                If Not (ps3) Then flag = 2
                If Not (ps1) Then flag = 3
                If Not (aa) Then If Not (ps2) Then flag = 4
                If Not (dr) Then flag = 5
                If Not (tr) Then flag = 6
                'if (!ps3) flag=2;
                'if (!ps1) flag = 3;
                'if (!aa) if (!ps2) flag = 4;
                'if (!dr) flag=5;
                'if (!tr) flag=6;

            Else
                'Call funcCheck_Flame()
                If funcCheck_Flame() = False Then
                    Return False
                End If
                ''for checking flame.
                'st = CHECK_PS();
                '--- Get the info. of pressor sensor from instrument
                If gobjCommProtocol.funcPressSensorStatus(st, False) Then
                    If ((st And EnumErrorStatus.YELLOW_OK) = EnumErrorStatus.YELLOW_OK) Then
                        flag = -2
                    ElseIf ((st And EnumErrorStatus.BLUE_OK) = EnumErrorStatus.BLUE_OK) Then
                        flag = -1
                    ElseIf ((st And EnumErrorStatus.FLAME_OK) = EnumErrorStatus.FLAME_OK) Then
                        flag = -1
                    End If
                Else
                    Return False
                End If
                'if ((st&YELLOW_OK) ==YELLOW_OK) flag=-2;
                'else  if ((st&BLUE_OK)==BLUE_OK)  flag=-1;
                'else if ((st & FLAME_OK)==FLAME_OK) flag=-1;
            End If
            '#If DEMO Then
            ' flag = random(8)-2;
            '#End If

            'if (flag == -1)
            '   return BLUE;
            'if (flag == -2)
            '   return YELLOW;

            'If (flag) Then
            '   return RED;
            'Else
            '   return GREEN;
            '}
            Dim nRandom As New Random
            If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                flag = nRandom.Next(8) - 2
            End If

            If (flag = -1) Then
                ''set a igniteType as per flag.
                'Return enumIgniteType.Blue
                InIgniteType = enumIgniteType.Blue
                Return True
            End If

            If (flag = -2) Then
                ''set a igniteType as per flag.
                'Return enumIgniteType.Yellow
                InIgniteType = enumIgniteType.Yellow
                Return True
            End If

            If (flag) Then
                ''set a igniteType as per flag.
                'Return enumIgniteType.Red
                InIgniteType = enumIgniteType.Red
                Return True
            Else
                'Return enumIgniteType.Green
                InIgniteType = enumIgniteType.Green
                Return True
            End If
            ''allow application to perfrom its panding work
            'Catch threadex As Threading.ThreadAbortException
            '---Do Nothing
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

    Public Function funcIgnite(ByVal blnFlameIgniteOn As Boolean) As Integer 'Line No.2917
        '=====================================================================
        ' Procedure Name        : funcIgnite
        ' Parameters Passed     : blnFlameIgniteOn
        ' Returns               : Integer
        ' Purpose               : used for Ignite a flame or off a flame as per parameter
        '                         
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh 
        ' Created               : 09.03.07
        ' Revisions             : modified by Deepak B.
        '=====================================================================
        Dim flag As Boolean = True
        Dim count As Integer = 0
        Dim bData As Byte
        Dim aa As Boolean
        Dim ch As Integer
        Dim objfrmFlameStatusDisplayIn As frmFlameStatusDisplay
        ''this is a object of form status

        'void 	S4FUNC 	Ignite(BOOL flag1)
        '{
        'BOOL 		flag=TRUE, count =0;
        'BYTE    	data, aa;
        'HWND		hwnd;
        'int   	ch;
        'HWND     hpar=NULL;
        'hpar = GetTopWindow(NULL);

        'If (!Commflag) Then
        '	return;

        'if( InstType == AA202)
        '   hwnd = Create_Window_Pneum("AA-202  AA FLAME");
        'Else
        '   hwnd = Create_Window_Pneum("AA-203  AA FLAME");

        'StHwnd=hwnd;
        'ReinitInstParameters();

        'do 
        '{ //0
        '   count++;
        '	Status_Disp();
        '	if (flag && count==5) 
        '   { //1
        '	    flag = FALSE;
        '	    if (!flag1)	  
        '       { //2
        '		    if (!Flame_Off())
        '           {//3
        '		        Beep(); Gerror_message_new(" Already Flame is Extinguished"," AUTOEXTINGUISH");
        '		    }//3
        '	    }//2
        '	    else
        '       { //4
        '		    data = CHECK_BUR_PAR();
        '		    if (data & AA_CONNECTED) aa = ON;
        '		    else aa = OFF;
        '		    if (aa) 
        '           {//5
        '			    if (!Inst.Aaf) Inst.Aaf = AA_FLAME_ON();
        '			    else {Beep(); Gerror_message(" Already in AA-Flame");}
        '			}//5
        '		    else
        '           { //6
        '			    ch=MessageBox(hpar,"    Ready for flame    Click \n Yes for AA flame \n No for NA flame ", "AA AUTO-IGNITION ", MB_YESNOCANCEL);
        '			    if (ch==IDYES)
        '               { //7
        '				    if (!Inst.Aaf) Inst.Aaf = AA_FLAME_ON();
        '				    else 
        '                   {
        '                       Beep(); 
        '                       Gerror_message_new(" Already in AA-Flame"," AUTOIGNITION");
        '                   }
        '                   #If DEMO Then
        '				        Inst.Aaf=TRUE;
        '                   #End If
        '			    }//7
        '			    else if (ch==IDNO)
        '               { //8
        '				    if (!Inst.N2of) Inst.N2of = N2_FLAME_ON();
        '				    else {Beep(); Gerror_message_new(" Already in nA-Flame"," AUTOIGNITION");}
        '			    }//8
        '		    }//6
        '       }//4
        '   }//1
        '} while(count<15); //0

        'Close_Window(hwnd, NULL);
        'ReinitInstParameters();
        'StHwnd=NULL;
        '}

        Try
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                ''for 201
                Exit Function
            End If
            If Not gobjCommProtocol.mobjCommdll.gFuncIsPortOpen = True Then
                ''for checking a comm port
                Exit Function
            End If

            'Call ReInitInstParameters()
            '''for reinitialise the instrument
            objfrmFlameStatusDisplayIn = New frmFlameStatusDisplay
            objfrmFlameStatusDisplayIn.StartPosition = FormStartPosition.Manual
            objfrmFlameStatusDisplayIn.Location = New Point(10, 50)
            Call Status_Disp(objfrmFlameStatusDisplayIn)
            objfrmFlameStatusDisplayIn.Show()
            Application.DoEvents()
            ''show the status display form and allow application to perfrom its panding work
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                ''check for 201
                If gstructSettings.NewModelName = False Then  '---21.07.09
                    objfrmFlameStatusDisplayIn.Text = "AA-201  AA FLAME"
                Else
                    objfrmFlameStatusDisplayIn.Text = "AA-301  AA FLAME"
                End If
            Else
                'else
                If gstructSettings.NewModelName = False Then  '---21.07.09
                    objfrmFlameStatusDisplayIn.Text = "AA-203  AA FLAME"
                Else
                    objfrmFlameStatusDisplayIn.Text = "AA-303  AA FLAME"
                End If
            End If

            Call ReInitInstParameters()
            ''for reinitialise the instrument

            Do
                count += 1
                Call Status_Disp(objfrmFlameStatusDisplayIn)
                ''call this function for status display.
                'If (flag And count = 5) Then
                If (flag And count = 1) Then
                    flag = False

                    '--- Set flame OFF when flame ignition is ON
                    If Not blnFlameIgniteOn Then
                        If Not gobjCommProtocol.funcFlame_OFF() Then
                            ''check the flag if not then put flame off
                            Call Beep()
                            ''noise a beep
                            Call gobjMessageAdapter.ShowMessage(constFlameAlreadyExtinguish)
                            ''show a already Extinguish the flame message.
                            Application.DoEvents()
                            ''allow application to perfrom it panding work.
                        End If
                    Else
                        '--- Set flame On when flame ignition is OFF
                        '--- Check the burner parameter
                        Call gobjCommProtocol.funcCheckBurnerParameters(bData)
                        'check for burner parameter 
                        If (bData And EnumErrorStatus.AA_CONNECTED) Then
                            aa = True
                        Else
                            aa = False
                        End If

                        If aa = True Then
                            If Not gobjInst.Aaf = True Then
                                gobjInst.Aaf = gobjCommProtocol.func_AA_FLAME_ON()
                                'for AA flame on
                            Else
                                Beep()
                                Call gobjMessageAdapter.ShowMessage(constAlreadyAAFlame)
                            End If
                        Else
                            '//----- Added by Sachin on 03.03.08
                            Dim objfrmMessageFlame As New frmMessageFlame
                            Dim intDialogResult As DialogResult
                            'If gobjMessageAdapter.ShowMessage(constReadyforFlame) = True Then
                            intDialogResult = objfrmMessageFlame.ShowDialog
                            If intDialogResult = DialogResult.Yes Then
                                Application.DoEvents()
                                If Not gobjInst.Aaf Then
                                    gobjInst.Aaf = gobjCommProtocol.func_AA_FLAME_ON()
                                    ''set AA flame on and set a flag.
                                Else
                                    Beep()
                                    Call gobjMessageAdapter.ShowMessage(constAlreadyAAFlame)
                                    Application.DoEvents()
                                    ''allow application to perfrom its panding work.
                                End If
                                'Else
                            ElseIf intDialogResult = DialogResult.No Then
                                If Not gobjInst.N2of Then

                                    gobjInst.N2of = gobjCommProtocol.func_N2_FLAME_ON()
                                Else
                                    Beep()
                                    Call gobjMessageAdapter.ShowMessage(constAlreadyNAFlame)
                                    Application.DoEvents()
                                    ''allow application to perfrom its panding work
                                End If
                            ElseIf intDialogResult = DialogResult.Cancel Then '---03.05.10
                                If Not objfrmMessageFlame Is Nothing Then
                                    objfrmMessageFlame.Dispose()
                                End If
                                Application.DoEvents()
                            End If
                            If Not objfrmMessageFlame Is Nothing Then
                                objfrmMessageFlame.Dispose()
                            End If
                            Application.DoEvents()
                            'objfrmMessageFlame.Dispose()
                            'objfrmMessageFlame = Nothing
                            'Application.DoEvents()
                        End If
                    End If
                End If
                'Loop While count < 15
            Loop While count < 5

            Call ReInitInstParameters()
            ''reinitialise the instrument.

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
            If Not IsNothing(objfrmFlameStatusDisplayIn) Then
                objfrmFlameStatusDisplayIn.Close()
                objfrmFlameStatusDisplayIn.Dispose()
                objfrmFlameStatusDisplayIn = Nothing
            End If
            '---------------------------------------------------------
        End Try
    End Function

    'Public Function Status_Disp(ByRef objFrmManualIgnitionIn As frmManualIgnition) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        : Status_Disp
    '    ' Parameters Passed     : objFrmManualIgnitionIn 
    '    ' Returns               : None
    '    ' Purpose               : To set the parameters on form load.
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Mangesh Shardul
    '    ' Created               : 23-Mar-2007
    '    ' Revisions             : 1
    '    '=====================================================================
    '    Dim line1 As String
    '    Dim status, st, st1 As Byte
    '    Dim flag As Boolean = True

    '    Try
    '        status = gobjCommProtocol.funcGet_Pneum_Status()
    '        gobjCommProtocol.funcPressSensorStatus(st, False)
    '        gobjCommProtocol.funcCheckBurnerParameters(st1)

    '        If (st And EnumErrorStatus.AIR_NOK) Then
    '            flag = False
    '            objFrmManualIgnitionIn.pbPressureAir.Image = Image.FromFile("images\ERROR.BMP")
    '        Else
    '            objFrmManualIgnitionIn.pbPressureAir.Image = Image.FromFile("images\OK.BMP")
    '        End If

    '        If (st And EnumErrorStatus.N2O_NOK) Then
    '            flag = False
    '            objFrmManualIgnitionIn.pbPressureN2O.Image = Image.FromFile("images\ERROR.BMP")
    '        Else
    '            objFrmManualIgnitionIn.pbPressureN2O.Image = Image.FromFile("images\OK.BMP")
    '        End If

    '        If (st And EnumErrorStatus.FUEL_NOK) Then
    '            flag = False
    '            objFrmManualIgnitionIn.pbPressureFuel.Image = Image.FromFile("images\ERROR.BMP")
    '        Else
    '            objFrmManualIgnitionIn.pbPressureFuel.Image = Image.FromFile("images\OK.BMP")
    '        End If

    '        If (status And EnumErrorStatus.SAIR_NON) Then
    '            flag = False
    '            objFrmManualIgnitionIn.pbStatusAir.Image = Image.FromFile("images\close.BMP")
    '        Else
    '            objFrmManualIgnitionIn.pbStatusAir.Image = Image.FromFile("images\open.BMP")
    '        End If

    '        If (status And EnumErrorStatus.SN2O_NON) Then
    '            objFrmManualIgnitionIn.pbStatusN2O.Image = Image.FromFile("images\open.BMP")
    '        Else
    '            flag = False
    '            objFrmManualIgnitionIn.pbStatusN2O.Image = Image.FromFile("images\close.BMP")
    '        End If

    '        If (status And EnumErrorStatus.SFUEL_ON) Then
    '            objFrmManualIgnitionIn.pbStatusFuel.Image = Image.FromFile("images\open.BMP")
    '        Else
    '            flag = False
    '            objFrmManualIgnitionIn.pbStatusFuel.Image = Image.FromFile("images\close.BMP")
    '        End If

    '        If (st1 And EnumErrorStatus.AA_CONNECTED) Then
    '            objFrmManualIgnitionIn.pbBurnerType.Image = Image.FromFile("images\BTAA.bmp")
    '        Else
    '            objFrmManualIgnitionIn.pbBurnerType.Image = Image.FromFile("images\BTNA.bmp")
    '        End If

    '        If (st1 And EnumErrorStatus.TRAP_NOK) Then
    '            flag = False
    '            objFrmManualIgnitionIn.pbSafetyControlsTrap.Image = Image.FromFile("images\topen.bmp")
    '        Else
    '            objFrmManualIgnitionIn.pbSafetyControlsTrap.Image = Image.FromFile("images\OK.BMP")
    '        End If

    '        If (st1 And EnumErrorStatus.DOOR_NOK) Then
    '            flag = False
    '            objFrmManualIgnitionIn.pbSafetyControlsDoor.Image = Image.FromFile("images\DOPEN.bmp")
    '        Else
    '            objFrmManualIgnitionIn.pbSafetyControlsDoor.Image = Image.FromFile("images\DCLOSE.bmp")
    '        End If

    '        If (st And EnumErrorStatus.YELLOW_OK) = EnumErrorStatus.YELLOW_OK Then
    '            objFrmManualIgnitionIn.pbFlameType.Image = Image.FromFile("images\YELLOW.BMP")

    '        ElseIf (st And EnumErrorStatus.BLUE_OK) = EnumErrorStatus.BLUE_OK Then
    '            objFrmManualIgnitionIn.pbFlameType.Image = Image.FromFile("images\BLUE.BMP")

    '        ElseIf (st And EnumErrorStatus.FLAME_OK) = EnumErrorStatus.FLAME_OK Then
    '            objFrmManualIgnitionIn.pbFlameType.Image = Image.FromFile("images\BYELLOW.BMP")

    '        ElseIf flag Then
    '            objFrmManualIgnitionIn.pbFlameType.Image = Image.FromFile("images\GREEN.BMP")
    '        Else
    '            objFrmManualIgnitionIn.pbFlameType.Image = Image.FromFile("images\RED.BMP")
    '        End If

    '        gobjCommProtocol.funcGet_NV_Pos()

    '        objFrmManualIgnitionIn.lblFRatio.Text = Format(gobjClsAAS203.funcRead_Fuel(), "0.00")

    '        gobjCommProtocol.func_Get_BH_Pos()
    '        objFrmManualIgnitionIn.lblBHeight.Text = Format(gobjClsAAS203.funcReadBurnerHeight(), "0.00")

    '        objFrmManualIgnitionIn.lblNVStep.Text = "NV : " & gobjInst.NvStep & ""

    '        objFrmManualIgnitionIn.Refresh()

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
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

    Public Function Status_Disp(ByRef objfrmFlameStatusDisplayIn As frmFlameStatusDisplay) As Boolean
        '=====================================================================
        ' Procedure Name        : Status_Disp
        ' Parameters Passed     : objfrmFlameStatusDisplayIn
        ' Returns               : True/False
        ' Purpose               : to set a status of status form..
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 24-Mar-2007
        ' Revisions             : 1
        '=====================================================================
        ''note:
        ''this is used for display a current status of application
        ''at status disply form.
        ''here we are setting a image as per current status



        Dim line1 As String
        Dim status, st, st1 As Byte
        Dim flag As Boolean = True

        Try
            status = gobjCommProtocol.funcGet_Pneum_Status()
            ''get pneumentics setting of instrument.
            Call gobjCommProtocol.funcPressSensorStatus(st, False)
            ''check a pressure sensor status
            Call gobjCommProtocol.funcCheckBurnerParameters(st1)
            ''check for burner parameter
            If (st And EnumErrorStatus.AIR_NOK) Then
                ''check for air nok
                flag = False
                objfrmFlameStatusDisplayIn.pbPressureAir.Image = Image.FromFile(Application.StartupPath & "\" & "images\ERROR.BMP")
            Else
                objfrmFlameStatusDisplayIn.pbPressureAir.Image = Image.FromFile(Application.StartupPath & "\" & "images\OK.BMP")
            End If

            If (st And EnumErrorStatus.N2O_NOK) Then
                ''check for N2O nok.
                flag = False
                objfrmFlameStatusDisplayIn.pbPressureN2O.Image = Image.FromFile(Application.StartupPath & "\" & "images\ERROR.BMP")
            Else
                objfrmFlameStatusDisplayIn.pbPressureN2O.Image = Image.FromFile(Application.StartupPath & "\" & "images\OK.BMP")
            End If

            If (st And EnumErrorStatus.FUEL_NOK) Then
                ''check for FUEL nok.
                flag = False
                objfrmFlameStatusDisplayIn.pbPressureFuel.Image = Image.FromFile(Application.StartupPath & "\" & "images\ERROR.BMP")
            Else
                objfrmFlameStatusDisplayIn.pbPressureFuel.Image = Image.FromFile(Application.StartupPath & "\" & "images\OK.BMP")
            End If

            If (status And EnumErrorStatus.SAIR_NON) Then
                flag = False
                objfrmFlameStatusDisplayIn.pbStatusAir.Image = Image.FromFile(Application.StartupPath & "\" & "images\close.BMP")
            Else
                objfrmFlameStatusDisplayIn.pbStatusAir.Image = Image.FromFile(Application.StartupPath & "\" & "images\open.BMP")
            End If

            If (status And EnumErrorStatus.SN2O_NON) Then
                objfrmFlameStatusDisplayIn.pbStatusN2O.Image = Image.FromFile(Application.StartupPath & "\" & "images\open.BMP")
            Else
                flag = False
                objfrmFlameStatusDisplayIn.pbStatusN2O.Image = Image.FromFile(Application.StartupPath & "\" & "images\close.BMP")
            End If

            If (status And EnumErrorStatus.SFUEL_ON) Then
                objfrmFlameStatusDisplayIn.pbStatusFuel.Image = Image.FromFile(Application.StartupPath & "\" & "images\open.BMP")
            Else
                flag = False
                objfrmFlameStatusDisplayIn.pbStatusFuel.Image = Image.FromFile(Application.StartupPath & "\" & "images\close.BMP")
            End If

            If (st1 And EnumErrorStatus.AA_CONNECTED) Then
                ''set a image as per cond
                objfrmFlameStatusDisplayIn.pbBurnerType.Image = Image.FromFile(Application.StartupPath & "\" & "images\BTAA.bmp")
            Else
                objfrmFlameStatusDisplayIn.pbBurnerType.Image = Image.FromFile(Application.StartupPath & "\" & "images\BTNA.bmp")
            End If

            If (st1 And EnumErrorStatus.TRAP_NOK) Then
                ''set a image as per cond
                flag = False
                objfrmFlameStatusDisplayIn.pbSafetyControlsTrap.Image = Image.FromFile(Application.StartupPath & "\" & "images\topen.bmp")
            Else
                objfrmFlameStatusDisplayIn.pbSafetyControlsTrap.Image = Image.FromFile(Application.StartupPath & "\" & "images\OK.BMP")
            End If

            If (st1 And EnumErrorStatus.DOOR_NOK) Then
                ''set a image as per cond
                ''check for door_nok
                flag = False
                objfrmFlameStatusDisplayIn.pbSafetyControlsDoor.Image = Image.FromFile(Application.StartupPath & "\" & "images\DOPEN.bmp")
            Else
                objfrmFlameStatusDisplayIn.pbSafetyControlsDoor.Image = Image.FromFile(Application.StartupPath & "\" & "images\DCLOSE.bmp")
            End If

            If (st And EnumErrorStatus.YELLOW_OK) = EnumErrorStatus.YELLOW_OK Then
                objfrmFlameStatusDisplayIn.pbFlameType.Image = Image.FromFile(Application.StartupPath & "\" & "images\YELLOW.BMP")

            ElseIf (st And EnumErrorStatus.BLUE_OK) = EnumErrorStatus.BLUE_OK Then
                objfrmFlameStatusDisplayIn.pbFlameType.Image = Image.FromFile(Application.StartupPath & "\" & "images\BLUE.BMP")

            ElseIf (st And EnumErrorStatus.FLAME_OK) = EnumErrorStatus.FLAME_OK Then
                objfrmFlameStatusDisplayIn.pbFlameType.Image = Image.FromFile(Application.StartupPath & "\" & "images\BYELLOW.BMP")

            ElseIf flag Then
                objfrmFlameStatusDisplayIn.pbFlameType.Image = Image.FromFile(Application.StartupPath & "\" & "images\GREEN.BMP")
            Else
                objfrmFlameStatusDisplayIn.pbFlameType.Image = Image.FromFile(Application.StartupPath & "\" & "images\RED.BMP")
            End If

            Call gobjCommProtocol.funcGet_NV_Pos()
            ''for getting NV position
            objfrmFlameStatusDisplayIn.lblFRatio.Text = Format(gobjClsAAS203.funcRead_Fuel(), "0.00")

            Call gobjCommProtocol.func_Get_BH_Pos()
            ''for getting burner position
            objfrmFlameStatusDisplayIn.lblBHeight.Text = Format(gobjClsAAS203.funcReadBurnerHeight(), "0.00")

            objfrmFlameStatusDisplayIn.Refresh()

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

    Public Function funcSetLastFuel(ByVal intNVS As Integer) As Boolean
        '=====================================================================
        ' Procedure Name        : funcSetLastFuel
        ' Parameters Passed     :  intNVS
        ' Returns               : Boolean
        ' Purpose               : for setting last fuel
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.12.06
        ' Revisions             : parveen
        '=====================================================================

        Try
            '            void SetLastFuel( int nvs )
            '{
            'int	k;
            'Get_NV_Pos();
            '            If (Inst.Nvstep < nvs) Then
            '  NV_RotateAnticlock_Steps(abs(nvs-Inst.Nvstep));
            '            Else
            '  NV_RotateClock_Steps(abs(Inst.Nvstep-nvs));
            ' Get_NV_Pos();
            '}

            Call gobjCommProtocol.funcGet_NV_Pos()
            ''for gettin NV setting
            If (gobjInst.NvStep < intNVS) Then
                Call gobjCommProtocol.funcNV_RotateAntiClock_Steps(Math.Abs(intNVS - gobjInst.NvStep))
                ''for rotating a NV at anti clock wise direction 
            Else
                Call gobjCommProtocol.funcNV_RotateClock_Steps(Math.Abs(gobjInst.NvStep - intNVS))
                ''for rotating a NV at  clock wise direction 

                Call gobjCommProtocol.funcGet_NV_Pos()
                ''now get NV current position
            End If

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

    'Public Function funcGetFiltData(ByVal ADCVolt As Double) As Double
    '    '=====================================================================
    '    ' Procedure Name        : funcGetFiltData
    '    ' Parameters Passed     :  ADCVolts
    '    ' Returns               : Boolean
    '    ' Purpose               : To Check Ignite position
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Sachin Dokhale
    '    ' Created               : 21.12.06
    '    ' Revisions             : 
    '    '=====================================================================

    '    Try
    '        '            int TimeConst=2;
    '        'double 	S4FUNC	GetFiltData( double ADCVolt )
    '        '{
    '        'double xcoeff1002[6][3] ={
    '        '					{0.067455,0.134911,0.067455}, //0.131106,0.262213,0.131106, 	 // fc = 10 Hz, fs = 100 Hz, O = 2
    '        '					{0.020083,0.040167,0.020083}, // fc = 5 Hz, fs = 100 Hz, O = 2
    '        '					{0.003622,0.007243,0.003622}, //fc = 2 Hz fs = 100 Hz, O = 2
    '        '					{0.000945,0.001889,0.000945}, // fc = 1 Hz fs = 100 Hz O = 2
    '        '					{0.000039,0.000078,0.000039}, // fc = 0.2 Hz fs = 100 Hz O = 2
    '        '					{0.000010,0.000020,0.000010}
    '        '				 }; // fc = 0.1 Hz fs = 100 Hz O = 2
    '        'double ycoeff1002[6][2] ={
    '        '					{1.14298,-0.412802},  // 0.747789,-0.272215, 	// fc = 10 Hz, fs = 100 Hz, O = 2
    '        '					{1.56102,-0.641352},		 // fc = 5 Hz, fs = 100 Hz, O = 2
    '        '					{1.8227,-0.837182},		// fc = 2 Hz, fs = 100 Hz, O = 2
    '        '					{1.9112,-0.914976},		// fc = 1 hz fs = 100 O Hz O = 2
    '        '					{1.98223,-0.982385},       // fc = 0.2 Hz fs = 100 Hz O = 2
    '        '					{1.99111,-0.991154}};		// fc = 0.1 Hz fs = 100 Hz O = 2
    '        '//-----butterworth filter Order = 2 Sampling Freq = 100Hz ------------
    '        'static	double Xn_2=0,Xn_1=0,Yn_1=0,Yn_2=0,filtdata=0;

    '        '			filtdata  = xcoeff1002[TimeConst][0]*ADCVolt;
    '        '			filtdata += xcoeff1002[TimeConst][1]*Xn_1;
    '        '			filtdata += xcoeff1002[TimeConst][2]*Xn_2;
    '        '			filtdata += ycoeff1002[TimeConst][0]*Yn_1;
    '        '			filtdata += ycoeff1002[TimeConst][1]*Yn_2;
    '        '			Xn_2 = Xn_1;
    '        '			Xn_1 = ADCVolt;
    '        '			Yn_2 = Yn_1;
    '        '			Yn_1 = filtdata;
    '        'return filtdata;
    '        '}
    '        '//----- Start from here
    '        'Dim intTimeConst As Integer = 2
    '        Dim xcoeff1002(,) As Double = {{0.067455, 0.134911, 0.067455}, {0.020083, 0.040167, 0.020083}, {0.003622, 0.007243, 0.003622}, {0.000945, 0.001889, 0.000945}, {0.000039, 0.000078, 0.000039}, {0.00001, 0.00002, 0.00001}}
    '        '}; // fc = 0.1 Hz fs = 100 Hz O = 2
    '        Dim ycoeff1002(,) As Double = { _
    '             {1.14298, -0.412802}, {1.56102, -0.641352}, {1.8227, -0.837182}, {1.9112, -0.914976}, {1.98223, -0.982385}, {1.99111, -0.991154}}

    '        '//-----butterworth filter Order = 2 Sampling Freq = 100Hz ------------
    '        'static	double Xn_2=0,Xn_1=0,Yn_1=0,Yn_2=0,filtdata=0;
    '        Static Dim Xn_2 As Double = 0
    '        Static Dim Xn_1 As Double = 0
    '        Static Dim Yn_1 As Double = 0
    '        Static Dim Yn_2 As Double = 0
    '        Static Dim filtdata As Double = 0
    '        Static intCal_Mode As Integer

    '        If Not (intCal_Mode = gobjInst.Mode) Or (blnResetFilterData = True) Then
    '            intCal_Mode = gobjInst.Mode
    '            Xn_2 = 0
    '            Xn_1 = 0
    '            Yn_1 = 0
    '            Yn_2 = 0
    '            filtdata = 0
    '            blnResetFilterData = False
    '        End If


    '        filtdata = xcoeff1002(gintTimeConstant, 0) * ADCVolt
    '        filtdata += xcoeff1002(gintTimeConstant, 1) * Xn_1
    '        filtdata += xcoeff1002(gintTimeConstant, 2) * Xn_2
    '        filtdata += ycoeff1002(gintTimeConstant, 0) * Yn_1
    '        filtdata += ycoeff1002(gintTimeConstant, 1) * Yn_2
    '        Xn_2 = Xn_1
    '        Xn_1 = ADCVolt
    '        Yn_2 = Yn_1
    '        Yn_1 = filtdata

    '        Return filtdata
    '        '}

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        Return 0.0
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

    Public Function funcCheck_Flame() As Boolean
        '=====================================================================
        ' Procedure Name        : funcCheck_Flame
        ' Parameters Passed     :  none.
        ' Returns               : Boolean
        ' Purpose               : To Check Flame
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 22.12.06
        ' Revisions             : 
        '=====================================================================
        Try
            'BYTE 		st;
            'BOOL 	ps1, ps2, ps3, flag=0;

            'if (Inst.Aaf || Inst.N2of) {
            '	ps1 = ps2 = ps3 = ON;
            '	st  = CHECK_PS();
            '	if (st & AIR_NOK) ps1 = OFF;
            '	if (st & N2O_NOK) ps2 = OFF;
            '	if (st & FUEL_NOK) ps3 = OFF;
            '#If HYRD_MODE Then
            '	if (!HydrideMode){
            '#Else
            '	if (!Inst.Hydride){
            '#End If
            '	  if ((st&FLAME_OK) !=FLAME_OK ) flag=1;
            '	  }
            '	if (!ps3) flag=2;
            '	if (Inst.Aaf) if (!ps1) flag = 3;
            '	if (Inst.N2of) if (!ps2) flag = 4;
            '#If DEMO Then
            '		flag=FALSE;
            '#End If

            '	if (flag){
            '	  Flame_Off();
            '	  switch(flag) {
            '		 case 1 : Inst.Nvstep-= (5*NVSTEP);Save_NV_Pos();
            '					 Gerror_message(" **FLAME ERROR *** \n Flame OFF "); break;
            '		 case 2 : Gerror_message(" **FLAME ERROR *** \n Fuel not enough "); break;
            '		 case 3 : Gerror_message(" **FLAME ERROR *** \n Air  not enough "); break;
            '		 case 4 : Gerror_message(" **FLAME ERROR *** \n N2o  not enough "); break;
            '	  }
            '	}
            ' }
            '}

            Dim bdata As Byte
            Dim ps1, ps2, ps3 As Boolean
            Dim intflag As Integer = 0

            'if (Inst.Aaf || Inst.N2of) {
            '	ps1 = ps2 = ps3 = ON;
            If ((gobjInst.Aaf) Or (gobjInst.N2of)) Then
                'if true
                ps1 = True  ' To check for Air pressure 
                ps2 = True  ' To check for N2O pressure 
                ps3 = True  ' To check for Fuel pressure 

                If gobjCommProtocol.funcPressSensorStatus(bdata) Then
                    ''get a presssensor status
                    If (bdata And EnumErrorStatus.AIR_NOK) Then
                        ''check for air nok
                        ps1 = False
                    End If
                    If (bdata And EnumErrorStatus.N2O_NOK) Then
                        ''check for n2o nok
                        ps2 = False
                    End If
                    If (bdata And EnumErrorStatus.FUEL_NOK) Then
                        ''check for fuel nok
                        ps3 = False
                    End If
                    'End If

                    '#If HYRD_MODE Then
                    '	if (!HydrideMode){
                    '#Else
                    '	if (!Inst.Hydride){
                    '#End If
                    '	  if ((st&FLAME_OK) !=FLAME_OK ) flag=1;
                    '	  }

                    If gstructSettings.HydrideMode Then

                        ''check for hydride mode
                        If Not HydrideMode Then
                            If (Not (bdata And EnumErrorStatus.FLAME_OK) = EnumErrorStatus.FLAME_OK) Then
                                intflag = 1
                            End If
                        End If
                    Else
                        If Not (gobjInst.Hydride) Then
                            If (Not (bdata And EnumErrorStatus.FLAME_OK) = EnumErrorStatus.FLAME_OK) Then
                                intflag = 1
                            End If
                        End If
                    End If

                    '	if (!ps3) flag=2;
                    '	if (Inst.Aaf) if (!ps1) flag = 3;
                    '	if (Inst.N2of) if (!ps2) flag = 4;

                    If Not (ps3) Then
                        intflag = 2
                    End If

                    If (gobjInst.Aaf) Then
                        If Not (ps1) Then
                            intflag = 3
                        End If
                    End If

                    If (gobjInst.N2of) Then
                        If Not (ps2) Then
                            intflag = 4
                        End If
                    End If

                    '#If DEMO Then
                    '		flag=FALSE;
                    '#endif
                    'If gstructSettings.AppMode = EnumAppMode.DemoMode Then
                    If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                        (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                        (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                        intflag = False
                    End If

                    If (intflag) Then
                        Call gobjCommProtocol.funcFlame_OFF()
                        ''for flame off
                        '//--- check the flame status for AA201 03.10.08
                        If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then

                            '---added on 30.03.09
                            gobjCommProtocol.func_N2O_OFF()
                            gobjCommProtocol.func_FUEL_OFF()
                            '-------------

                            '//--- Set the Fuel volve off  when flame is not present
                            If gobjCommProtocol.func_FUEL_OFF() = True Then
                            End If
                            '//--- Set the N2O volve off when flame is not present
                            If (gobjInst.N2of) Then
                                If gobjCommProtocol.func_N2O_OFF() = True Then
                                End If
                            End If
                        End If
                        '//---
                        Select Case intflag
                            ''select case as per flag
                        Case 1
                                '//--- check the flame status for AA201 03.10.08
                                If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                                    '---added on 30.03.09
                                    gobjCommProtocol.func_N2O_OFF()
                                    gobjCommProtocol.func_FUEL_OFF()
                                    '-------------

                                    Call gobjMessageAdapter.ShowMessage("Flame is off", "Flame Off", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                                Else
                                    gobjInst.NvStep -= (5 * NVSTEP)
                                    '**************************************************************************
                                    '---Added function by Mangesh on 23-Apr-2007
                                    '**************************************************************************
                                    Call gobjCommProtocol.funcSave_NV_Pos()
                                    ''for saving a NV position
                                    '**************************************************************************
                                    Call gobjMessageAdapter.ShowMessage(constFlameErrorFlameOff)
                                    'break;
                                End If
                                '//---
                            Case 2

                                '----added on 30.03.09 to close the valve before message display '30.03.09
                                If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                                    '---added on 30.03.09
                                    gobjCommProtocol.func_N2O_OFF()
                                    gobjCommProtocol.func_FUEL_OFF()
                                    '-------------                                    
                                End If
                                '---------

                                ' Gerror_message(" **FLAME ERROR *** \n Fuel not enough "); break;
                                Call gobjMessageAdapter.ShowMessage(constFlameErrorFuelOff)

                            Case 3
                                If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                                    '---added on 30.03.09
                                    gobjCommProtocol.func_N2O_OFF()
                                    gobjCommProtocol.func_FUEL_OFF()
                                    '-------------
                                End If

                                ' Gerror_message(" **FLAME ERROR *** \n Air  not enough "); break;
                                Call gobjMessageAdapter.ShowMessage(constFlameErrorAirOff)
                            Case 4
                                '----added on 30.03.09 to close the valve before message display '30.03.09
                                If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                                    '---added on 30.03.09
                                    gobjCommProtocol.func_N2O_OFF()
                                    gobjCommProtocol.func_FUEL_OFF()
                                    '-------------                                    
                                End If
                                '--------------

                                ' Gerror_message(" **FLAME ERROR *** \n N2o  not enough "); break;
                                Call gobjMessageAdapter.ShowMessage(constFlameErrorN2OOff)
                        End Select
                    End If
                End If
            End If

            funcCheck_Flame = True

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

    Public Function funcCheck_Flame(ByRef flag As Boolean) As Boolean
        '=====================================================================
        ' Procedure Name        : funcCheck_Flame
        ' Parameters Passed     :  none.
        ' Returns               : Boolean
        ' Purpose               : To Check Flame
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 22.12.06
        ' Revisions             : 
        '=====================================================================
        Try
            'BYTE 		st;
            'BOOL 	ps1, ps2, ps3, flag=0;

            'if (Inst.Aaf || Inst.N2of) {
            '	ps1 = ps2 = ps3 = ON;
            '	st  = CHECK_PS();
            '	if (st & AIR_NOK) ps1 = OFF;
            '	if (st & N2O_NOK) ps2 = OFF;
            '	if (st & FUEL_NOK) ps3 = OFF;
            '#If HYRD_MODE Then
            '	if (!HydrideMode){
            '#Else
            '	if (!Inst.Hydride){
            '#End If
            '	  if ((st&FLAME_OK) !=FLAME_OK ) flag=1;
            '	  }
            '	if (!ps3) flag=2;
            '	if (Inst.Aaf) if (!ps1) flag = 3;
            '	if (Inst.N2of) if (!ps2) flag = 4;
            '#If DEMO Then
            '		flag=FALSE;
            '#End If

            '	if (flag){
            '	  Flame_Off();
            '	  switch(flag) {
            '		 case 1 : Inst.Nvstep-= (5*NVSTEP);Save_NV_Pos();
            '					 Gerror_message(" **FLAME ERROR *** \n Flame OFF "); break;
            '		 case 2 : Gerror_message(" **FLAME ERROR *** \n Fuel not enough "); break;
            '		 case 3 : Gerror_message(" **FLAME ERROR *** \n Air  not enough "); break;
            '		 case 4 : Gerror_message(" **FLAME ERROR *** \n N2o  not enough "); break;
            '	  }
            '	}
            ' }
            '}

            Dim bdata As Byte
            Dim ps1, ps2, ps3 As Boolean
            Dim intflag As Integer = 0

            'if (Inst.Aaf || Inst.N2of) {
            '	ps1 = ps2 = ps3 = ON;
            'If ((gobjInst.Aaf) Or (gobjInst.N2of)) Then
            'if true
            ps1 = True  ' To check for Air pressure 
            ps2 = True  ' To check for N2O pressure 
            ps3 = True  ' To check for Fuel pressure 

            If gobjCommProtocol.funcPressSensorStatus(bdata) Then
                ''get a presssensor status
                If (bdata And EnumErrorStatus.AIR_NOK) Then
                    ''check for air nok
                    ps1 = False
                End If
                If (bdata And EnumErrorStatus.N2O_NOK) Then
                    ''check for n2o nok
                    ps2 = False
                End If
                If (bdata And EnumErrorStatus.FUEL_NOK) Then
                    ''check for fuel nok
                    ps3 = False
                End If
                'End If

                '#If HYRD_MODE Then
                '	if (!HydrideMode){
                '#Else
                '	if (!Inst.Hydride){
                '#End If
                '	  if ((st&FLAME_OK) !=FLAME_OK ) flag=1;
                '	  }

                If gstructSettings.HydrideMode Then

                    ''check for hydride mode
                    If Not HydrideMode Then
                        If (Not (bdata And EnumErrorStatus.FLAME_OK) = EnumErrorStatus.FLAME_OK) Then
                            intflag = 1
                        End If
                    End If
                Else
                    If Not (gobjInst.Hydride) Then
                        If (Not (bdata And EnumErrorStatus.FLAME_OK) = EnumErrorStatus.FLAME_OK) Then
                            intflag = 1
                        End If
                    End If
                End If

                '	if (!ps3) flag=2;
                '	if (Inst.Aaf) if (!ps1) flag = 3;
                '	if (Inst.N2of) if (!ps2) flag = 4;

                If Not (ps3) Then
                    intflag = 2
                End If

                If (gobjInst.Aaf) Then
                    If Not (ps1) Then
                        intflag = 3
                    End If
                End If

                If (gobjInst.N2of) Then
                    If Not (ps2) Then
                        intflag = 4
                    End If
                End If

                '#If DEMO Then
                '		flag=FALSE;
                '#endif
                'If gstructSettings.AppMode = EnumAppMode.DemoMode Then
                If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                    (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                    (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                    intflag = False
                End If

                If (intflag) Then
                    Call gobjCommProtocol.funcFlame_OFF()
                    ''for flame off
                    '//--- check the flame status for AA201 03.10.08
                    If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                        '//--- Set the Fuel volve off  when flame is not present
                        If gobjCommProtocol.func_FUEL_OFF() = True Then
                        End If
                        '//--- Set the N2O volve off when flame is not present
                        If (gobjInst.N2of) Then
                            If gobjCommProtocol.func_N2O_OFF() = True Then
                            End If
                        End If
                    End If
                    '//---
                    Select Case intflag
                        ''select case as per flag
                    Case 1
                            '//--- check the flame status for AA201 03.10.08
                            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                                Call gobjMessageAdapter.ShowMessage("Flame is off", "Flame Off", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                            Else
                                gobjInst.NvStep -= (5 * NVSTEP)
                                '**************************************************************************
                                '---Added function by Mangesh on 23-Apr-2007
                                '**************************************************************************
                                Call gobjCommProtocol.funcSave_NV_Pos()
                                ''for saving a NV position
                                '**************************************************************************
                                Call gobjMessageAdapter.ShowMessage(constFlameErrorFlameOff)
                                'break;
                                flag = False  '29.12.08
                            End If
                            '//---
                        Case 2
                            flag = False  '29.12.08
                            ' Gerror_message(" **FLAME ERROR *** \n Fuel not enough "); break;
                            Call gobjMessageAdapter.ShowMessage(constFlameErrorFuelOff)

                        Case 3
                            flag = False  '29.12.08
                            ' Gerror_message(" **FLAME ERROR *** \n Air  not enough "); break;
                            Call gobjMessageAdapter.ShowMessage(constFlameErrorAirOff)
                        Case 4
                            flag = False  '29.12.08
                            ' Gerror_message(" **FLAME ERROR *** \n N2o  not enough "); break;
                            Call gobjMessageAdapter.ShowMessage(constFlameErrorN2OOff)
                    End Select
                End If
            End If
            'End If

            funcCheck_Flame = True

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

    Public Sub funcSetInstrumentCondns(ByVal flag As Boolean, Optional ByRef lblElementName As Label = Nothing, _
                                       Optional ByRef lblLampCurrent As Label = Nothing, Optional ByRef lblWavelength As Label = Nothing, _
                                       Optional ByRef lblSlitWidth As Label = Nothing, Optional ByRef lblFlameBurner As Label = Nothing)
        '=====================================================================
        ' Procedure Name        : funcSetInstrumentCondns
        ' Parameters Passed     :  flag,lblElementName rest are the optional
        ' Returns               : 
        ' Purpose               : To set the instrument cond 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 22.12.06
        ' Revisions             : Deepak on 17.02.07
        '=====================================================================
        '--------ORIGINAL CODE
        '''char	str[40]="";
        '''        If (flag) Then
        '''	sprintf(str, "%s ",Inst->Lamp_par.lamp[Inst->Lamp_pos-1].elname);
        '''        Else
        '''	sprintf(str, "%s ",Inst->Lamp_par.Ems.elname);
        ''' SetWindowText(GetDlgItem(hwnd, IDC_TELNAME), str);
        '''            If (flag) Then
        '''	sprintf(str, "Cur : %-3.1f mA",Inst->Lamp_par.lamp[Inst->Lamp_pos-1].cur);
        ''' else strcpy(str,"");
        ''' SetWindowText(GetDlgItem(hwnd, IDC_TCUR), str);
        '''                If (flag) Then
        '''	sprintf(str, "Wv : %-5.2f nm",Inst->Lamp_par.lamp[Inst->Lamp_pos-1].wv);
        '''                Else
        '''	sprintf(str, "Wv : %-5.2f nm",Inst->Lamp_par.Ems.wv);
        ''' SetWindowText(GetDlgItem(hwnd, IDC_TWV), str);
        '''                    If (flag) Then
        '''	sprintf(str, "Slit : %-2.1f nm",Inst->Lamp_par.lamp[Inst->Lamp_pos-1]. slitwidth);
        '''                    Else
        '''	sprintf(str, "Slit : %-2.1f nm",Inst->Lamp_par.Ems.slitwidth);
        ''' SetWindowText(GetDlgItem(hwnd, IDC_TSLIT), str);
        ''' if (flag){
        '''	if (Inst->Lamp_par.lamp[Inst->Lamp_pos-1].burner)
        '''		strcpy(str, "Flame : AA");
        '''                            Else
        '''		strcpy(str, "Flame : NA");
        '''	 }
        '''  else strcpy(str,"");
        ''' SetWindowText(GetDlgItem(hwnd, IDC_TFUEL), str);

        '******************************************************************
        '--- CODE BY MANGESH 
        '******************************************************************
        Dim str As String = ""

        Try
            If (flag) Then
                str = gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).ElementName
                ''for setting element name
            Else
                str = gobjInst.Lamp.EMSCondition.ElementName
            End If
            If Not IsNothing(lblElementName) Then lblElementName.Text = str

            If (flag) Then
                str = "Current : " & gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).Current & " mA"
                ''setting lamp current
            Else
                str = ""
            End If
            If Not IsNothing(lblLampCurrent) Then lblLampCurrent.Text = str

            If (flag) Then
                str = "Wavelength : " & gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).Wavelength & " nm"
                ''for setting wavelength
            Else
                str = "Wavelength : " & gobjInst.Lamp.EMSCondition.Wavelength & " nm"
            End If
            If Not IsNothing(lblWavelength) Then lblWavelength.Text = str

            If (flag) Then
                str = "Slit Width : " & gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).SlitWidth & " nm"
                ''for setting slit width
            Else
                str = "Slit Width : " & gobjInst.Lamp.EMSCondition.SlitWidth & " nm"
            End If
            If Not IsNothing(lblSlitWidth) Then lblSlitWidth.Text = str

            If (flag) Then
                ''for setting flame as per the burner
                If (gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).Burner) Then
                    str = "Flame : AA "
                Else
                    str = "Flame : NA "
                End If
            Else
                str = ""
            End If
            If Not IsNothing(lblFlameBurner) Then lblFlameBurner.Text = str

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

    Public Sub subWaitForAdc()
        '=====================================================================
        ' Procedure Name        : subWaitForAdc
        ' Parameters Passed     : None 
        ' Returns               : None
        ' Purpose               : To set some wait time in ADC reading.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 22.12.06
        ' Revisions             : praveen
        '=====================================================================
        '{
        'int	ad;
        ' for(ad=0;ad<10; ad++)
        '	ReadADCFilter();
        '}
        Dim intad As Integer
        Dim intAvgValue As Integer
        For intad = 0 To 10
            gobjCommProtocol.funcReadADCFilter(1, intAvgValue)
            ''wait for ADC and Read ADC filter.
        Next

    End Sub

    'Private blnUVFlag As Boolean = False

    Public Function funcSetRest_uvs_Condn(ByVal WvNew As Double, ByVal blnflag As Boolean, ByRef lblUVWavelength As Label, ByRef blnUVFlag As Boolean) As Boolean
        '=====================================================================
        ' Procedure Name        : funcSetRest_uvs_Condn
        ' Parameters Passed     :  WvNew,blnflag,lblUVWavelength,blnUVFlag
        ' Returns               : Boolean
        ' Purpose               : to set a cond forUV mode
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 22.12.06
        ' Revisions             : praveen
        '=====================================================================
        Try
            'void	S4FUNC 	SetRest_uvs_Condn(HWND hwnd, double wvnew, BOOL flag,int x, int y)
            '{
            '//char *ell=NULL;
            'static	int	sp=0;
            'HDC		hdc;
            '#If !GRAPHITE Then
            ' if (!uvflag)
            '  Flame_Off();
            '// if (Flame_Present()) Ignite(FALSE);
            ' if(GetInstrument() == AA202)
            '	 AIR_ON();
            ' else
            '	 AIR_OFF();
            '#End If
            ' if (!uvflag){
            '                If (flag) Then
            '	  Blink_MessageBox(hwnd,"REMOVE BURNER and INSERT CUVETTE HOLDER \n then PRESS OK BUTTON ", "UV Mode",0);
            '//	  MessageBox(hwnd,"REMOVE BURNER and INSERT CUVETTE HOLDER \n                     then PRESS OK BUTTON ", "UV Mode",MB_OK);
            '	Set_lamp(FALSE);
            '	Cal_Mode(D2E);
            '	sp =Inst->Slitpos;
            '	Slit_Home();
            '	Set_D2_Cur(300);
            '	if (Inst->d2Pmt==0)
            '	  Adj_D2Gain(hwnd, FALSE, x, y);
            '	Set_PMT(Inst->d2Pmt);
            '	hdc=GetDC(hwnd);
            '	Wavelength_Position(hdc, wvnew,x, y);
            '	ReleaseDC(hwnd, hdc);
            '	}
            '  else{
            '  Cal_Mode(AA);
            '                        If (flag) Then
            '	 Blink_MessageBox(hwnd,"REMOVE CUVETTE HOLDER and INSERT  BURNER \n then PRESS OK BUTTON ", "UVS Node",0);
            '//    MessageBox(hwnd,"REMOVE CUVETTE HOLDER and INSERT  BURNER \n                     then PRESS OK BUTTON ", "UVS Node",MB_OK);
            '  Set_lamp(TRUE);
            '#If !GRAPHITE Then
            ' if(GetInstrument() != AA202 )
            '  AIR_ON();
            '#End If
            '  Set_D2_Cur(100); D2_OFF();
            '  Position_Slit(sp);
            '  }
            ' uvflag^=1;
            '}

            Static Dim intsp As Integer = 0
            ''static variable
            funcSetRest_uvs_Condn = False
            ''flag for function
            '#If !GRAPHITE Then
            ' if (!uvflag)
            '  Flame_Off();

            ' if(GetInstrument() == AA202)
            '	 AIR_ON();
            ' else
            '	 AIR_OFF();
            '#End If
            ' Check the condition for Flame off when Graphite not set and UV setting is not seted
            If Not (Graphite = True) Then
                If (blnUVFlag) = False Then
                    Call gobjCommProtocol.funcFlame_OFF()
                    ''if blnUVFlag is false then put flame off
                End If


                'If (GetInstrument() = AA202) Then
                '   AIR_ON()
                'Else
                If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                    ''check for 201
                    Call gobjCommProtocol.funcAir_ON()
                    ''for putting air on
                Else
                    Call gobjCommProtocol.funcAir_OFF()
                    ''for putting air off
                End If
            End If
            'End If
            '#End If

            'if (!uvflag){
            'If (flag) Then
            'Blink_MessageBox(hwnd,"REMOVE BURNER and INSERT CUVETTE HOLDER \n then PRESS OK BUTTON ", "UV Mode",0);
            If (blnUVFlag = False) Then
                If (blnflag = True) Then
                    'Blink_MessageBox(hwnd,"REMOVE BURNER and INSERT CUVETTE HOLDER \n then PRESS OK BUTTON ", "UV Mode",0);
                    gobjMessageAdapter.ShowMessage(constRemoveBurner)
                    Application.DoEvents()
                    ''show the mess and allow application to perfrom its panding work.
                End If

                '//----- Set all lamp tobe off
                'Set_lamp(FALSE);
                Call gobjCommProtocol.funcSet_Lamp(False, 0, 0)
                ''for setting lamp
                'Cal_Mode(D2E);
                Call gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.D2E)
                ''for setting calibration mode
                '//----- Restore the Slit Position and move to Home position
                'sp =Inst->Slitpos;
                intsp = gobjInst.SlitPosition
                Call gobjCommProtocol.gFuncSlit_Home()
                ''for making a clit home
                Call gobjCommProtocol.funcSetD2Cur(300)
                ''for setting D2 current
                'if (Inst->d2Pmt==0)
                'Adj_D2Gain(hwnd, FALSE, x, y);
                If (gobjInst.D2Pmt = 0) Then
                    'Call gobjCommProtocol.func Adj_D2Gain(False)
                    Call funcAdj_D2Gain(False, lblUVWavelength)
                    ''for adjusting a D2 gain.
                End If

                'Set_PMT(Inst->d2Pmt);
                Call gobjCommProtocol.funcSet_PMT(gobjInst.D2Pmt)
                ''for setting PMT
                'Wavelength_Position(hdc, wvnew,x, y);
                Call gobjCommProtocol.Wavelength_Position(WvNew, lblUVWavelength)
                ''for position the wavelength
            Else
                'Cal_Mode(AA);
                Call gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.AA)
                '---for setting calibration mode
                'If (flag) Then
                'Blink_MessageBox(hwnd,"REMOVE CUVETTE HOLDER and INSERT  BURNER \n then PRESS OK BUTTON ", "UVS Node",0);
                If (blnflag = True) Then
                    gobjMessageAdapter.ShowMessage(constRemoveCuvette)
                    Application.DoEvents()
                    ''for allowing application to perfrom its panding work
                End If

                'Set_lamp(True);
                Call gobjCommProtocol.funcSet_Lamp(True)
                '--- function for setting lamp true.
                '#If !GRAPHITE Then
                ' if(GetInstrument() != AA202 )
                '  AIR_ON();
                '#End If
                If Not (Graphite = True) Then
                    If Not (gstructSettings.AppMode = EnumAppMode.FullVersion_201) Then
                        Call gobjCommProtocol.funcAir_ON()
                        '--- for air on
                    End If
                End If

                Call gobjCommProtocol.funcSetD2Cur(100)
                '--- for setting D2 curr
                Call gobjCommProtocol.D2_OFF()
                '--- for setting D2 off
                '  Position_Slit(sp);
                Call gobjCommProtocol.funcPosition_Slit_Entry(intsp)
                '--- for position slit entry
                '  }
                ' uvflag^=1;
                '}
            End If

            blnUVFlag = blnUVFlag Xor 1

            funcSetRest_uvs_Condn = True

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

#Region " Functions Related to Analysis Mode "

    '--- Enumarator for Sample type
    Public Enum enumSampleType
        ''this is a enum for sampler type
        BLANK = 0
        STANDARD = 1
        SAMPLE = 2
    End Enum

    '#define	BLANKCOLOR		RGB(0, 127,128)
    '#define	STDCOLOR		RGB(255, 0,0)
    '#define	SAMPCOLOR		RGB(0, 0, 255)
    Public Shared BLANKCOLOR As Color = Color.FromArgb(0, 127, 128)
    Public Shared STDCOLOR As Color = Color.FromArgb(255, 0, 0)
    Public Shared SAMPCOLOR As Color = Color.FromArgb(0, 0, 255)
    Public Shared BLACKCOLOR As Color = Color.FromArgb(0, 0, 0)
    Public Shared GREEN As Color = Color.Green   ' FromArgb(0, 0, 0)
    Public Shared YELLOW As Color = Color.Yellow        'FromArgb(0, 0, 0)


    '--- For Emission Peak 
    'double	 EmsZero=(double) 0.0;
    Private EmsZero As Double = 0.0

    'Public Sub GetValueIsString(ByVal dblValue As Double, ByVal intMode As Integer, ByRef ValueInString As String)
    '    'void GetValInString(double val, char *str, int mode)
    '    '{
    '    ' switch(mode){
    '    '	case	MODE_AA:
    '    '	case  MODE_AABGC:
    '    '	case	MODE_UVABS:
    '    '			StoreAbsAccurate(val,str);
    '    '		break;
    '    '	case MODE_EMMISSION:
    '    '	case MODE_SPECT:
    '    '		sprintf(str,"%-4.1f",val);
    '    '		break;
    '    '	}
    '    '}

    '    '********************************************
    '    '---CODE BY MANGESH 
    '    '********************************************

    '    Select Case (intMode)
    '        Case EnumOperationMode.MODE_AA
    '        Case EnumOperationMode.MODE_AABGC
    '        Case EnumOperationMode.MODE_UVABS
    '            'StoreAbsAccurate(dblValue, ValueInString)

    '        Case EnumOperationMode.MODE_EMMISSION
    '        Case EnumOperationMode.MODE_SPECT
    '            ValueInString = dblValue '"%-4.1f",  
    '    End Select


    'End Sub

    Public Function Get_Reading(ByVal intSampleType As enumSampleType, _
                                ByVal CurStd As AAS203Library.Method.clsAnalysisStdParameters, _
                                ByVal blnIsForFilter As Boolean, _
                                ByVal CurSample As AAS203Library.Method.clsAnalysisSampleParameters) As Double

        '=====================================================================
        ' Procedure Name        : Get_Reading
        ' Parameters Passed     : sampler type,STD,flag for fliter ,current sampler 
        ' Returns               : double
        ' Purpose               : to get a reading in analysis

        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 22.12.06
        ' Revisions             : 
        '=====================================================================
        'double  Get_Reading(void)
        '{
        'int	adval;
        'double data=0.0;
        'adval = adcscan();
        'data = (double) GetADConvertedTo(adval, Method->Mode);
        'if (Method->Mode==MODE_EMISSION)
        '   data-= Get_Emission_Zero();
        '#If GRAPHITE Then
        '	if (ReadGrRawFile(&data))
        '	    data=500.0;
        '#End If

        '#If QDEMO Then
        '	data = GetDataFromDemo(data);
        '#End If

        'if(checkmindetect)
        '  {
        '	data=CheckForMinAbsLevel(data);  
        '  }
        'return data;
        '}

        '****************************************
        '---CODE BY MANGESH 
        '****************************************
        Dim intADCValue As Integer
        Dim dblAbsorbanceReading As Double = 0.0

        Try
            'If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
            If Not ((gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                (gstructSettings.AppMode = EnumAppMode.DemoMode_203D)) Then
                intADCValue = ADCScan(blnIsForFilter, intSampleType)
                dblAbsorbanceReading = gfuncGetADConvertedTo(intADCValue, gobjNewMethod.OperationMode)
            End If

            If (gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION) Then
                dblAbsorbanceReading -= funcGet_Emission_Zero()
            End If

            '#If GRAPHITE Then
            '	if (ReadGrRawFile(&data))
            '	    data=500.0;
            '#End If

            'If gstructSettings.AppMode = EnumAppMode.DemoMode Then
            If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                dblAbsorbanceReading = GetDataFromDemo(intSampleType, dblAbsorbanceReading, CurStd, CurSample)
            End If

            If (gstructSettings.SetMinAbsLimit) Then
                dblAbsorbanceReading = CheckForMinAbsLevel(dblAbsorbanceReading)
            End If

            Return dblAbsorbanceReading

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

    Public Function ADCScan(ByVal blnIsForFilter As Boolean, ByVal intSampleType As enumSampleType) As Integer
        '=====================================================================
        ' Procedure Name        : ADCScan
        ' Parameters Passed     : Is filter or not flag,sampler type
        ' Returns               : ADC Count
        ' Purpose               : To read the ADC Count as Reading
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        'int ADCScan(void)
        '{
        '   #If QDEMO Then
        '	    return  adcscan1();
        '   #Else
        '       int	adval;
        '       if (InstType==AADEMO)
        '	        return  adcscan1();

        '       If (Filter_flag) Then
        '	        adval = ReadADCforFilter();
        '       Else
        '	        adval = ReadADCFilter();

        '       return adval;
        '   #End If
        '}
        '**********************************
        '----CODE BY MANGESH 
        '**********************************
        Dim intADCValue As Long

        Try
            Select Case gintInstrumentBeamType
                Case enumInstrumentBeamType.SingleBeam
                    If (blnIsForFilter) Then
                        intADCValue = gobjCommProtocol.ReadADCforFilter()
                    Else
                        Call gobjCommProtocol.funcReadADCFilter(gobjInst.Average, intADCValue)
                    End If

                Case enumInstrumentBeamType.DoubleBeam
                    If gobjInst.Mode = EnumCalibrationMode.AA Then
                        If (blnIsForFilter) Then
                            intADCValue = gobjCommProtocol.funcReadADCforFilter_DoubleBeam()
                        Else
                            Call gobjCommProtocol.funcReadADCFilter_DoubleBeam(gobjInst.Average, intADCValue)
                        End If
                    Else
                        If (blnIsForFilter) Then
                            intADCValue = gobjCommProtocol.ReadADCforFilter()
                        Else
                            Call gobjCommProtocol.funcReadADCFilter(gobjInst.Average, intADCValue)
                        End If
                    End If
            End Select

            Return intADCValue

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

    Public Function GetDataFromDemo(ByVal SampType As enumSampleType, ByVal data As Double, _
                                    ByVal CurStd As Method.clsAnalysisStdParameters, _
                                    ByVal CurSample As Method.clsAnalysisSampleParameters) As Double
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   GetDataFromDemo
        'Description            :   
        'Parameters             :   None
        'Time/Date              :   27/9/06
        'Dependencies           :   
        'Author                 :   
        'Revision               :
        'Revision by Person     :
        '-----------------------------------------------

        'typedef  struct absxonc{
        '   double	abs;
        '   double conc;
        '}
        'AbsConc;

        'double	GetDataFromDemo(double data)
        '{
        '   AbsConc	abs1[]={
        '		{0.103, 20.0},
        '		{0.157, 40.0},
        '		{0.241, 60.0},
        '		{0.306, 80.0},
        '		{0.352, 100.0},
        '		{0.152 ,1.0},
        '		{0.125 ,2.0},
        '		{0.125 ,7.0},
        '		{0.005 ,5.0},
        '		{0.772 ,6.0},
        '		{0, 0}
        '	};
        '   double	data1 = data;
        '   double	conc = 0.0;
        '   int	i;
        '   if (SampType==STD && CurStd)
        '   {
        '	    conc = CurStd->Data.Conc;
        '	    i=0;
        '	    while (abs1[i].abs!=(double) 0.0 && abs1[i].conc!=(double) 0.0 )
        '       {
        '	        if (conc==abs1[i].conc)
        '           {
        '		        data1= abs1[i].abs;
        '		        break;
        '		    }
        '	        i++;
        '       }
        '	    data1 += (double) (random(50)/(double)10000.0);
        '   }
        '   return data1;
        '}


        '*********************************************
        '---CODE BY MANEGSH 
        '*********************************************
        Dim abs1() As AbsConc = {New AbsConc(0.142, 20.0) _
                               , New AbsConc(0.265, 40.0) _
                               , New AbsConc(0.378, 60.0) _
                               , New AbsConc(0.426, 80.0) _
                               , New AbsConc(0.562, 100.0) _
                               , New AbsConc(0.682, 1.0) _
                               , New AbsConc(0.725, 2.0) _
                               , New AbsConc(0.825, 3.0) _
                               , New AbsConc(0.805, 4.0) _
                               , New AbsConc(0.972, 5.0) _
                               , New AbsConc(0, 0)}


        Dim data1 As Double = data
        Dim conc As Double = 0.0
        Dim i As Integer
        Dim objRandom As New Random
        Try
            If SampType = enumSampleType.STANDARD Then
                If Not IsNothing(CurStd) Then
                    conc = CurStd.Concentration
                    i = 0
                    While (abs1(i).ABS <> 0.0 And abs1(i).CONC <> 0.0)
                        If (conc = abs1(i).CONC) Then
                            data1 = abs1(i).ABS
                            Exit While
                        End If
                        i += 1
                    End While
                    data1 += (objRandom.Next(50) / 1000.0)
                End If

            ElseIf SampType = enumSampleType.BLANK Then
                data1 = 0.0

            ElseIf SampType = enumSampleType.SAMPLE Then
                If Not IsNothing(CurSample) Then
                    conc = CurSample.Conc
                    i = 0
                    While (abs1(i).ABS <> 0.0 And abs1(i).CONC <> 0.0)
                        If (conc = abs1(i).CONC) Then
                            data1 = abs1(i).ABS
                            Exit While
                        End If
                        i += 1
                    End While
                    data1 += (objRandom.Next(50) / 1000.0)
                End If

            End If

            Return data1
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
            objRandom = Nothing
        End Try
    End Function

    Public Function CheckForMinAbsLevel(ByVal ABSTP As Double) As Double

        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   CheckForMinAbsLevel
        'Description            :   for checking min abs level
        'Parameters             :   None
        'Time/Date              :   
        'Dependencies           :   
        'Author                 :   
        'Revision               :
        'Revision by Person     :
        '-----------------------------------------------
        '//----mdf by sk on 24/5/2001 for locking min detect level of abs
        'double CheckForMinAbsLevel(double abstp)
        '{
        ' /*
        '  this func checks if abs is less than 0.008(by default) then it is locked to 0
        '  since our minimum detection of absorbance is 0.005
        '  and it can change with respect to parameters and lamp.
        ' */

        '	if(abstp < absthldval) // 0.008 mdf by sk on 3/6/2001
        '	  return 0.0;
        '        Else
        '	  return abstp;
        '}


        '**************************************************
        '---CODE BY MANGESH 
        '**************************************************
        '---for locking min detect level of abs
        '  this func checks if abs is less than 0.008(by default) then it is locked to 0
        '  since our minimum detection of absorbance is 0.005
        '  and it can change with respect to parameters and lamp.

        If (ABSTP < gstructSettings.AbsThresholdValue) Then
            Return 0.0
        Else
            Return ABSTP
        End If


    End Function

    '//----- Added by Sachin Dokhale
    '//----- Fuel control function

    Public Function funcIncr_Fuel() As Boolean
        '=====================================================================
        ' Procedure Name        : funcIncr_Fuel
        ' Parameters Passed     : None
        ' Returns               : Boolean
        ' Purpose               : Increase the Fuel
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 25.11.06
        ' Revisions             : 
        '=====================================================================
        Dim dblSWidth As Double

        Try
            funcIncr_Fuel = False
            If gobjCommProtocol.funcGet_NV_Pos = True Then

                If gobjInst.NvStep >= NVSTEP Then
                    Call gobjCommProtocol.funcNV_RotateClock_Steps(NVSTEP)
                End If
                Call gobjCommProtocol.funcGet_NV_Pos()
                funcIncr_Fuel = True
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return False
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

    Public Function funcDecr_Fuel() As Boolean
        '=====================================================================
        ' Procedure Name        : funcDecr_Fuel
        ' Parameters Passed     : None
        ' Returns               : Boolean
        ' Purpose               : Decrease the Fuel
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 25.11.06
        ' Revisions             : 
        '=====================================================================

        Dim Indr_Idx As Integer
        Try
            '//=------ Original Func

            'void	S4FUNC Decr_Fuel()
            '{
            'int k;
            ' Get_NV_Pos();
            '// if (Inst.Aaf|| Inst.N2of) {
            '            If (Inst.Nvstep <= (NVRED * MAXNVHOME - NVSTEP)) Then
            '	  for (k=1; k<=NVSTEP; k++){
            '		if (!Flame_Present(FALSE)) {
            '			NV_RotateClock();
            '			pc_delay(200);
            '			break;
            '		  }
            '		NV_RotateAnticlock();
            '	}
            '#If DEMO Then
            '	 NVpos+=NVSTEP;
            '#End If
            '// }
            ' Get_NV_Pos();
            '}
            '//------
            funcDecr_Fuel = False
            If gobjCommProtocol.funcGet_NV_Pos = True Then
                If gobjInst.NvStep <= (NVRED * MAXNVHOME - NVSTEP) Then
                    For Indr_Idx = 1 To NVSTEP
                        If gobjClsAAS203.funcFlame_Present(False) = False Then
                            If gobjCommProtocol.funcNV_Rotate_Clock() = False Then
                                ''for roating NV in clock wise
                                '    'PC Delay(200) '2MS
                                Exit For
                            End If
                            Exit For
                        End If
                        Call gobjCommProtocol.funcNV_Rotate_AntiClock() 'BY Pankaj bamb on 22 Jan 08
                    Next
                    'Call gobjCommProtocol.funcNV_Rotate_AntiClock()'commented BY Pankaj bamb on 22 Jan 08
                End If
                Call gobjCommProtocol.funcGet_NV_Pos()
                ''for getting NV position
                funcDecr_Fuel = True
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return False
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

    Public Function funcFlame_Present(ByVal blnFlag_Flame_Present As Boolean) As Boolean
        '=====================================================================
        ' Procedure Name        : funcFlame_Present
        ' Parameters Passed     : blnFlag_Flame_Present
        ' Returns               : Boolean
        ' Purpose               : Set the status of Flame presence
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 25.11.06
        ' Revisions             : 
        '=====================================================================
        Dim bytPS As Byte
        Dim blnFlagFlamePresent As Boolean = False
        Try
            'blnFlag_Flame_Present = False
            '//---------------
            'BYTE st;
            ' if (Inst.Aaf || Inst.N2of) {
            '	st = CHECK_PS();
            '	if ((st&FLAME_OK) ==FLAME_OK)
            '		return TRUE;
            '                Else
            '		return FALSE;
            '  }
            ' else {
            '                    If (flag1) Then
            '	  return TRUE;
            '                    Else
            '	  return FALSE;
            '	}
            '//--------------

            If (gobjInst.Aaf = True) Or (gobjInst.N2of = True) Then
                'bytPS = funcCHECK_PS()
                If gobjCommProtocol.funcPressSensorStatus(bytPS) = True Then
                    If ((bytPS And CONST_FLAME_OK) = CONST_FLAME_OK) Then
                        blnFlagFlamePresent = True
                    Else
                        blnFlagFlamePresent = False
                    End If
                End If
            Else
                If blnFlag_Flame_Present = True Then
                    blnFlagFlamePresent = True
                Else
                    blnFlagFlamePresent = False
                End If
            End If

            Return blnFlagFlamePresent
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return False
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

    Public Function funcGet_Fuel_Ratio(ByVal blnFlag_Fuel As Boolean) As Double
        '=====================================================================
        ' Procedure Name        : funcGet_Fuel_Ratio
        ' Parameters Passed     : blnFlag_Flame_Present
        ' Returns               : Boolean
        ' Purpose               : Get the Ratio  of Fuel
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 25.11.06
        ' Revisions             : 
        '=====================================================================
        Dim bytPS As Byte
        Try
            If blnFlag_Fuel = True Then
                Return funcRead_Fuel()
            Else
                If funcFlame_Present(True) Then
                    Return funcRead_Fuel()
                End If
                Return 0.0
            End If
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return -1.0
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

    Public Function funcRead_Fuel() As Double
        '=====================================================================
        ' Procedure Name        : funcRead_Fuel
        ' Parameters Passed     : 
        ' Returns               : Double
        ' Purpose               : Read fuel
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 25.11.06
        ' Revisions             : 
        '=====================================================================
        Dim dblFuel As Double
        Dim lngFuel As Long
        Try

            dblFuel = 0.0
            If gobjCommProtocol.funcGet_NV_Pos = True Then
                dblFuel = funcConvertToFuel(gobjInst.NvStep)
            End If
            '//----- Fuel Ratio is required 2 decimal point 
            lngFuel = dblFuel * 100
            dblFuel = lngFuel / 100
            '//-----
            Return dblFuel

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

    Public Function funcRead_Fuel_Ratio() As Double
        '=====================================================================
        ' Procedure Name        : funcRead_Fuel
        ' Parameters Passed     : 
        ' Returns               : Double
        ' Purpose               : Read fuel
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 16.12.06
        ' Revisions             : 
        '=====================================================================
        Dim dblFuel As Double
        Dim lngFuel As Long
        Try

            dblFuel = 0.0
            'If gobjCommProtocol.funcGet_NV_Pos = True Then
            dblFuel = funcConvertToFuel(gobjInst.NvStep)
            'End If
            '//----- Fuel Ratio is required 2 decimal point 
            lngFuel = dblFuel * 100
            dblFuel = lngFuel / 100
            '//-----

            If dblFuel < 0.0 Then
                ''setting some validation
                dblFuel = 0.0
            Else
                dblFuel = Format(dblFuel, "#0.00")
            End If

            Return dblFuel

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

    'Public Function funcOptimise_Fuel_Auto(ByRef AASGraphs As AASGraph) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcOptimise_Fuel_Auto
    '    ' Description           :   Optimese  the auto fuel
    '    ' Purpose               :   
    '    '                           
    '    ' Parameters Passed     :   None
    '    ' Returns               :   True
    '    ' Parameters Affected   :   
    '    ' Assumptions           :   
    '    ' Dependencies          :   None.
    '    ' Author                :   Sachin Dokhale 
    '    ' Created               :   25.12.06
    '    ' Revisions             :
    '    '=====================================================================

    '    '        BOOL	  Optimise_Fuel_Auto(HWND hpar)
    '    '//void	Lamp_optimize(boolean oflag)
    '    '{
    '    'double	txmin=0.0, txmax=0.0;
    '    'double   abs=0.0, max_abs= 0;
    '    'double	xfuel=0;
    '    'int		xval=0, max_fuel=0, xvalmax, xvalmin, adval;
    '    'BOOL		pflag=FALSE;
    '    'int 		i;
    '    'HWND		hwnd;
    '    'HDC		hdc;
    '    'char     line1[80]="";
    '    'unsigned	tout;
    '    'int		lMode;
    '    'int		txold, tyold;

    '    '  if (GetInstrument()==AA202)
    '    '	return TRUE;
    '    '            If (!Flame_Present(False)) Then
    '    '	return FALSE;
    '    '                If (!ReadAndSetFuelScanConditions(hpar)) Then
    '    '	return FALSE;
    '    '                    If (!CheckNvPos()) Then
    '    '	return FALSE;
    '    ' GetXoldYold(&txold, &tyold);
    '    ' txmin= PeakGraph.Xmin;
    '    ' txmax	= PeakGraph.Xmax;
    '    ' Blink_MessageBox(hpar,"Aspirate Max. Standard and Click OK","Fuel optimisation", 0);
    '    '// MessageBox(hpar, "Aspirate Max. Standard and Click OK","Fuel optimisation", MB_OK);
    '    ' hwnd= CreateWindowPeak(hpar, " FUEL OPTIMISATION ","SKCK2",0 );
    '    ' if (hwnd ){
    '    '	PeakGraph.Xmax=txmin ;
    '    '	PeakGraph.Xmin= txmax;
    '    '	PeakGraph.Ymin= 0.0;//GetEnergy(2047);
    '    '	PeakGraph.Ymax= 1.0;//GetEnergy(2047.0+409.6*4);
    '    '	SetInstrumentCondns(hwnd, TRUE);
    '    '	xvalmax = ConvertToNvPos(PeakGraph.Xmax) ;
    '    '	abs = ConvertToFuel(xvalmax) ;
    '    '	xvalmin = ConvertToNvPos(PeakGraph.Xmin) ;
    '    '	abs = ConvertToFuel(xvalmin) ;
    '    '	i= (int )  ((xvalmax-xvalmin)/NVSCANSTEP);
    '    '	i = abs(i);
    '    '	strcpy(PYaxis,"ABS"); strcpy(PXaxis,"Fuel ratio");
    '    '	Show_Peak_Param(hwnd, i);
    '    '	PeakGraph.Xmax=txmin ;
    '    '	PeakGraph.Xmin= txmax;
    '    '	SetFocus(hwnd);
    '    '	hdc= GetDC(hwnd);
    '    '	SetBkColor(hdc, RGB(192, 192, 192));
    '    '	SetText(hwnd, IDC_STATUS,"INITIALISING Please Wait  ....... ");
    '    '	strcpy(line1,""); sprintf(line1, " Setting Fuel from %4.2f to %4.2f ", ConvertToFuel(Inst->Nvstep) , PeakGraph.Xmax);
    '    '	SetText(hwnd, IDC_STATUS1,line1);
    '    '	SetFuel(PeakGraph.Xmax);
    '    '	strcpy(line1,"");
    '    '	lMode=Inst->Mode;
    '    '	Cal_Mode(AA);
    '    '	SetScanning(TRUE);
    '    '	sprintf(line1, " Fuel Optimisation");
    '    '	SetText(hwnd, IDC_STATUS1,line1);
    '    '	SetText(hwnd, IDC_STATUS,"");
    '    '	Transmit(NVSCAN, (BYTE)(xvalmin), (BYTE) (xvalmin>>8), (BYTE) NVSCANSTEP);
    '    '	xval= xvalmax;
    '    '	i=1;
    '    '	tout = GetTimeOut();
    '    '	SetTimeOut(VERY_LONG_DEALY);
    '    '	while(1){
    '    '                                If (Recev(False)) Then
    '    '		adval= GetParam2()*256 + GetParam1();
    '    '                                Else
    '    '		break;
    '    '                                    If (adval >= 6000) Then
    '    '		break;
    '    '#If QDEMO Then
    '    '	  adval = 2100+random(20);
    '    '#End If
    '    '	  abs = GetADConvertedToCurMode(adval);
    '    '	  if (abs > max_abs)    {
    '    '		 max_abs=abs;
    '    '		 max_fuel=xval;
    '    '		 pflag=TRUE;
    '    '		}
    '    '	  xfuel=ConvertToFuel(xval);
    '    '	  sprintf(line1,"(%4.2f, %4.3f) %d (%d-%d)",xfuel, abs, xval, xvalmin, xvalmax);
    '    '	  SetText(hwnd, IDC_STATUS,line1);
    '    '	  if (i==1)
    '    '		 GPlotInit(hdc, xfuel, abs);
    '    '                                            Else
    '    '		 GPlot(hdc,xfuel, abs);
    '    '	  xval+=NVSCANSTEP;
    '    '/*	  if (xval> xvalmin)
    '    '		 break;*/
    '    '	  i++;
    '    '		if (!Transmit(PC_END, (BYTE)0, (BYTE) 0, (BYTE) 0))
    '    '			break;
    '    '	 }
    '    '	SetTimeOut(tout);
    '    '	if (pflag){
    '    '	  sprintf(line1,"Optimised at (%4.2f, %4.3f)",ConvertToFuel(max_fuel),  max_abs);
    '    '	  SetText(hwnd, IDC_STATUS1,line1);
    '    '#If QDEMO Then
    '    '		Get_NV_Pos();
    '    '#End If
    '    '	  GShowPeak(hdc,ConvertToFuel(max_fuel),  max_abs, NULL);
    '    '	  strcpy(line1,""); sprintf(line1," Positioning to Optimised Position ...");
    '    '	  SetText(hwnd, IDC_STATUS,line1);
    '    '#If EMU Then
    '    ' Wait_For_Some_Msg(5);
    '    '#End If
    '    '	  SetFuel(ConvertToFuel(max_fuel));
    '    '	  }
    '    '	Cal_Mode(lMode);
    '    '	ReleaseDC(hwnd, hdc);
    '    '	DestroyWindowPeak(hwnd,hpar);
    '    '  }
    '    ' pc_delay(1500);
    '    ' SetScanning(FALSE);
    '    ' SetXoldYold(txold, tyold);
    '    ' return TRUE;
    '    '}
    '    Dim txmin As Double = 0.0
    '    Dim txmax As Double = 0.0
    '    Dim abs As Double = 0.0
    '    Dim max_abs As Double = 0.0
    '    Dim xfuel As Double = 0.0
    '    Dim xval As Integer = 0
    '    Dim max_fuel As Integer = 0
    '    Dim xvalmax, xvalmin, adval As Integer
    '    Dim pflag As Boolean = False
    '    Dim i As Integer

    '    Dim line1 As String
    '    'unsigned	tout;
    '    Dim tout As Integer
    '    Dim intlMode As Integer
    '    Dim inttxold, inttyold As Integer
    '    Try
    '        'if (GetInstrument()=AA202) then
    '        'return TRUE
    '        'If (!Flame_Present(False)) Then
    '        'return FALSE;
    '        '           If (!ReadAndSetFuelScanConditions(hpar)) Then
    '        'return FALSE;
    '        '               If (!CheckNvPos()) Then
    '        'return FALSE;
    '        If (gstructSettings.AppMode = EnumAppMode.FullVersion_201) Then
    '            Return True
    '        End If

    '        If Not (gobjClsAAS203.funcFlame_Present(False)) Then
    '            Return False
    '        End If
    '        'If Not (funcReadAndSetFuelScanConditions()) Then
    '        '    Return False
    '        'End If
    '        If (Not funcCheckNvPos()) Then
    '            Return False
    '        End If

    '        'GetXoldYold(&txold, &tyold);
    '        subGetXoldYold(inttxold, inttyold)
    '        Dim dblGraphXmin, dblGraphXMax As Double
    '        Dim blnFuelOptim As Boolean
    '        blnFuelOptim = gobjMessageAdapter.ShowMessage("Aspirate Max. Standard and Click OK", "Fuel optimisation", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)

    '        'PeakGraph.Xmax=txmin ;
    '        'PeakGraph.Xmin= txmax;
    '        'PeakGraph.Ymin= 0.0;//GetEnergy(2047);
    '        'PeakGraph.Ymax= 1.0;//GetEnergy(2047.0+409.6*4);
    '        'mobjParameters.XaxisMax = txmax
    '        'mobjParameters.XaxisMin = txmin
    '        'mobjParameters.YaxisMax = 0.0
    '        'mobjParameters.YaxisMin = 1
    '        AASGraphs.XAxisMax = txmax
    '        AASGraphs.XAxisMin = txmin
    '        AASGraphs.YAxisMax = 0.0
    '        AASGraphs.YAxisMin = 1.0
    '        AASGraphs.Refresh()


    '        'SetInstrumentCondns(hwnd, TRUE);
    '        'xvalmax = ConvertToNvPos(PeakGraph.Xmax) ;
    '        'abs = ConvertToFuel(xvalmax) ;
    '        'xvalmin = ConvertToNvPos(PeakGraph.Xmin) ;
    '        'abs = ConvertToFuel(xvalmin) ;

    '        Call gobjClsAAS203.funcSetInstrumentCondns(True)


    '        'xvalmax = funcConvertToNvPos(mobjParameters.XaxisMin)
    '        xvalmax = funcConvertToNvPos(AASGraphs.XAxisMin)

    '        abs = funcConvertToFuel(xvalmax)
    '        'xvalmin = funcConvertToNvPos(mobjParameters.XaxisMax)
    '        xvalmin = funcConvertToNvPos(AASGraphs.XAxisMax)
    '        abs = funcConvertToFuel(xvalmin)

    '        'i= (int )  ((xvalmax-xvalmin)/NVSCANSTEP);
    '        'i = abs(i)
    '        i = ((xvalmax - xvalmin) / CONST_NVSCANSTEP)
    '        i = Math.Abs(i)

    '        'strcpy(PYaxis,"ABS"); strcpy(PXaxis,"Fuel ratio");
    '        'Show_Peak_Param(hwnd, i);
    '        'PeakGraph.Xmax=txmin ;
    '        'PeakGraph.Xmin= txmax;
    '        AASGraphs.XAxisMax = txmax
    '        AASGraphs.XAxisMin = txmin

    '        'SetFocus(hwnd);
    '        'hdc= GetDC(hwnd);
    '        'SetBkColor(hdc, RGB(192, 192, 192));
    '        'SetText(hwnd, IDC_STATUS,"INITIALISING Please Wait  ....... ");

    '        'strcpy(line1,""); sprintf(line1, " Setting Fuel from %4.2f to %4.2f ", ConvertToFuel(Inst->Nvstep) , PeakGraph.Xmax);
    '        'SetText(hwnd, IDC_STATUS1,line1);
    '        gobjMessageAdapter.ShowStatusMessageBox("Setting Fuel from " & funcConvertToFuel(gobjInst.NvStep) & " to " & txmax, "", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 0)
    '        'SetFuel(PeakGraph.Xmax);
    '        '//----- Set here Fuel to auto
    '        'Call funcSetFuelParameter(dblXmax)
    '        '//-----

    '        Dim lMode As Integer
    '        'strcpy(line1,"");
    '        lMode = gobjInst.Mode
    '        'Cal_Mode(AA);
    '        gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.AA)

    '        'SetScanning(TRUE);
    '        'sprintf(line1, " Fuel Optimisation");
    '        'SetText(hwnd, IDC_STATUS1,line1);
    '        'SetText(hwnd, IDC_STATUS,"");
    '        gobjMessageAdapter.CloseStatusMessageBox()
    '        gobjMessageAdapter.ShowStatusMessageBox("Fuel Optimisation", "", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 0)
    '        Call gobjCommProtocol.funcNVScanSteps(xvalmin)
    '        xval = xvalmax
    '        i = 1
    '        'tout = GetTimeOut();
    '        'SetTimeOut(VERY_LONG_DEALY);
    '        Do While (True)
    '            'If (Recev(False)) Then
    '            '		adval= GetParam2()*256 + GetParam1();
    '            '                Else
    '            '		break;
    '            '                    If (adval >= 6000) Then
    '            '		break;
    '            '#If QDEMO Then
    '            '	  adval = 2100+random(20);
    '            '#End If
    '            If gobjCommProtocol.funcReceive_ScanData(0, adval) = True Then
    '                'adval = GetParam2() * 256 + GetParam1()
    '                'Else


    '                If (adval >= 6000) Then
    '                    Exit Do
    '                End If

    '                '//----- For Demo Mode
    '                '#If QDEMO Then
    '                '	  adval = 2100+random(20);
    '                '#End If
    '                If gstructSettings.AppMode = EnumAppMode.DemoMode Then
    '                    adval = 2100 + gRandom.Next(20)
    '                End If
    '                'abs = GetADConvertedToCurMode(adval);
    '                abs = gFuncGetADConvertedToCurMode(adval)
    '                '                  if (abs > max_abs)    {
    '                ' max_abs=abs;
    '                ' max_fuel=xval;
    '                ' pflag=TRUE;
    '                '}
    '                If (abs > max_abs) Then
    '                    max_abs = abs
    '                    max_fuel = xval
    '                    pflag = True
    '                End If
    '                'xfuel=ConvertToFuel(xval);
    '                xfuel = funcConvertToFuel(xval)
    '                'sprintf(line1,"(%4.2f, %4.3f) %d (%d-%d)",xfuel, abs, xval, xvalmin, xvalmax);
    '                'SetText(hwnd, IDC_STATUS,line1);
    '                gobjMessageAdapter.ShowStatusMessageBox(xfuel.ToString & " " & abs.ToString & " " & xval.ToString & " " & xvalmin.ToString & " " & xvalmax.ToString, " ", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 0)
    '                '//----- Plot graph 
    '                '                 if (i==1)
    '                'GPlotInit(hdc, xfuel, abs);
    '                '                 Else
    '                'GPlot(hdc,xfuel, abs);
    '                xval += CONST_NVSCANSTEP
    '                'i++;
    '                i += 1
    '                'if (!Transmit(PC_END, (BYTE)0, (BYTE) 0, (BYTE) 0))
    '                '	break;

    '                If gobjCommProtocol.funcPC_END Then
    '                    Exit Do
    '                End If

    '            Else
    '                Exit Do
    '            End If
    '        Loop
    '        'SetTimeOut(tout);
    '        'if (pflag){
    '        'sprintf(line1,"Optimised at (%4.2f, %4.3f)",ConvertToFuel(max_fuel),  max_abs);

    '        gobjMessageAdapter.CloseStatusMessageBox()
    '        gobjMessageAdapter.ShowStatusMessageBox("Optimised at " & funcConvertToFuel(max_fuel).ToString & " " & max_abs.ToString, "", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 0)
    '        '#If QDEMO Then
    '        '		Get_NV_Pos();
    '        '#End If
    '        If gstructSettings.AppMode = EnumAppMode.DemoMode Then
    '            Call gobjCommProtocol.funcGet_NV_Pos()
    '        End If

    '        '//----- Show the peak on graph
    '        'GShowPeak(hdc,ConvertToFuel(max_fuel),  max_abs, NULL);
    '        '//-----

    '        'strcpy(line1,""); sprintf(line1," Positioning to Optimised Position ...");
    '        'SetText(hwnd, IDC_STATUS,line1);
    '        gobjMessageAdapter.CloseStatusMessageBox()
    '        gobjMessageAdapter.ShowStatusMessageBox(" Positioning to Optimised Position ...", "", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 0)
    '        '#If EMU Then
    '        ' Wait_For_Some_Msg(5);
    '        '#End If
    '        'SetFuel(ConvertToFuel(max_fuel));
    '        funcSetFuel(funcConvertToFuel(max_fuel))
    '        'Cal_Mode(lMode);
    '        gobjCommProtocol.funcCalibrationMode(lMode)

    '        'pc_delay(1500);
    '        ' SetScanning(FALSE);
    '        ' SetXoldYold(txold, tyold);
    '        Call gobjCommProtocol.mobjCommdll.subTime_Delay(15)
    '        Call subSetXoldYold(inttxold, inttyold)
    '        Call gobjMessageAdapter.CloseStatusMessageBox()
    '        Return True
    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        Return False
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

    Public Function funcCheckNvPos() As Boolean
        '=====================================================================
        ' Procedure Name        : funcCheckNvPos
        ' Parameters Passed     : To check the NV Position
        ' Returns               : True/False
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 26.012.06
        ' Revisions             : 
        '=====================================================================

        Try
            '        BOOL	S4FUNC CheckNvPos()
            '{
            ' Get_NV_Pos();
            '            If (Inst.Nvstep < 0) Then
            '	NV_HOME();
            '                If (Inst.Nvstep < 0) Then
            '	return FALSE;
            ' return TRUE;
            '}    

            Call gobjCommProtocol.funcGet_NV_Pos()
            ''serial communication function for getting NV position
            If (gobjInst.NvStep < 0) Then
                Call gobjCommProtocol.funcSetNV_HOME()
                ''set NV to home 
            End If
            If (gobjInst.NvStep < 0) Then
                Return False
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

    Public Function funcConvertToNvPos(ByVal dblFuel As Double) As Integer
        '=====================================================================
        ' Procedure Name        : funcConvertToNvPos
        ' Parameters Passed     : dblfuel
        ' Returns               : True/False
        ' Purpose               : To convert to fuel to NV Position
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 26.12.06
        ' Revisions             : 
        '=====================================================================
        Dim dblNVS As Double
        Dim intNVSteps As Integer
        Try
            'int	S4FUNC	ConvertToNvPos(double fuel)
            '{
            'double nvs;
            'int	nvsteps;

            '            If (Burner_Type()) Then
            '	 nvs = (double) MAXNVHOME+(double)0.1561 - fuel*(double)0.6733;
            '	else                    
            '	nvs = (double) MAXNVHOME  +(double)0.1732 - fuel*(double)0.7232;
            '  nvsteps= (int) ((double) NVRED *nvs);
            ' return nvsteps;
            '}
            If gobjClsAAS203.funcBurner_Type() = True Then
                '	 nvs = (double) MAXNVHOME+(double)0.1561 - fuel*(double)0.6733;
                dblNVS = MAXNVHOME + 0.1561 - (dblFuel * 0.6733)
                '//	 fuel = (fuel+(double)0.1561)/(double)0.6733;
            Else                    '// 50 mm Burner
                'nvs = (double) MAXNVHOME  +(double)0.1732 - fuel*(double)0.7232;
                dblNVS = MAXNVHOME + 0.1732 - (dblFuel * 0.7232)
            End If
            '//	  fuel = (fuel+(double)0.1732)/(double)0.7232;
            intNVSteps = CInt((CDbl(NVRED) * dblNVS))
            Return intNVSteps

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return 0
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

    Public Function funcConvertToFuel(ByVal intNVSteps As Integer) As Double
        '=====================================================================
        ' Procedure Name        : funcConvertToFuel
        ' Parameters Passed     : intNVSteps
        ' Returns               : 
        ' Purpose               : to convert NV step in to a Fuel.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : 
        ' Created               : 08.11.06
        ' Revisions             : 
        '=====================================================================
        Dim dblFuel As Double = 0.0
        Try
            'double  S4FUNC ConvertToFuel(int nvsteps)
            '{
            'double fuel = (double)0.0;

            '            If (nvsteps < 0) Then
            '	return 0.0;
            '  fuel = (double) MAXNVHOME*(double)1.0-((double)nvsteps/(double)(NVRED));
            '                If (Burner_Type()) Then
            '	 fuel = (fuel+(double)0.1561)/(double)0.6733;
            '	else                    // 50 mm Burner
            '	  fuel = (fuel+(double)0.1732)/(double)0.7232;
            ' return fuel;
            '}
            If (intNVSteps < 0) Then
                Return 0.0
            End If
            dblFuel = MAXNVHOME * 1.0 - (intNVSteps / (NVRED))
            If (gobjClsAAS203.funcBurner_Type) Then
                dblFuel = (dblFuel + 0.1561) / 0.6733
            Else                    '// 50 mm Burner
                dblFuel = (dblFuel + 0.1732) / 0.7232
            End If
            Return dblFuel
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
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcSetFuel_old(ByVal dblFuel As Double) As Boolean
        '=====================================================================
        ' Procedure Name        : funcSetFuel
        ' Parameters Passed     : fuel to be set.
        ' Returns               : True/False
        ' Purpose               : for setting fuel.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 26.12.06
        ' Revisions             : 
        '=====================================================================
        Dim intk As Integer
        Dim intNVStep As Integer
        Try
            '            void		S4FUNC	SetFuel(double fuel)
            '{  //0
            'int	k;
            'int	nvstep =ConvertToNvPos(fuel);
            ' Get_NV_Pos();
            'if (Inst.Nvstep>nvstep){  //1
            '	 nvstep=Inst.Nvstep-nvstep;
            '	 NV_RotateClock_Steps(nvstep);
            '	} //1
            ' else if (Inst.Nvstep<nvstep) {  //2
            'if (nvstep<=(NVRED*MAXNVHOME))
            '	  for (k=Inst.Nvstep; k<nvstep+2; k++){ //3
            '		 if ( !Flame_Present(FALSE)) {  //4
            '			NV_RotateClock();
            '			pc_delay(200);
            '			break;
            '		  } //4
            '		NV_RotateAnticlock();
            '#If QDEMO Then
            '	 Get_NV_Pos();
            '#End If
            '	  } //3
            '	if (k==nvstep+2)
            '	  for (k=0; k<2; k++){ //5
            '		 NV_RotateClock();
            '			pc_delay(200);
            '	  } //5
            '  } //2
            ' Get_NV_Pos();
            '} //0
            '-------------------------------------------------------

            intNVStep = funcConvertToNvPos(dblFuel)

            Call gobjCommProtocol.funcGet_NV_Pos()
            If (gobjInst.NvStep > intNVStep) Then
                If intNVStep >= 0 Then
                    intNVStep = gobjInst.NvStep - intNVStep
                    Call gobjCommProtocol.funcNV_RotateClock_Steps(intNVStep)
                End If

            ElseIf (gobjInst.NvStep < intNVStep) Then  ''2
                'if (nvstep<=(NVRED*MAXNVHOME))
                '	  for (k=Inst.Nvstep; k<nvstep+2; k++){ //3
                '		 if ( !Flame_Present(FALSE)) {  //4
                '			NV_RotateClock();
                '			pc_delay(200);
                '			break;
                '		  } //4
                '		NV_RotateAnticlock();
                '#If QDEMO Then
                '	 Get_NV_Pos();
                '#End If
                '	  } //3

                If (intNVStep <= (NVRED * MAXNVHOME)) Then  '---02.09.07
                    'For intk = gobjInst.NvStep To intNVStep + 2
                    For intk = gobjInst.NvStep To intNVStep + 1   '---02.09.07
                        If Not (gobjClsAAS203.funcFlame_Present(False)) Then
                            If Not gobjInst.NvStep = 0 Then
                                'gobjCommProtocol.funcNV_Rotate_Clock()
                                Call gobjCommProtocol.funcGet_NV_Pos()
                                Exit For
                            Else
                                Call gobjCommProtocol.funcGet_NV_Pos()
                                Exit For
                            End If

                            'gobjCommProtocol.mobjCommdll.subTime_Delay(50)
                            'break;
                            'Exit For
                        End If
                        Call gobjCommProtocol.funcNV_Rotate_AntiClock()
                        '#If QDEMO Then
                        '	 Get_NV_Pos()
                        '#End If
                        If gstructSettings.AppMode = EnumAppMode.DemoMode Then
                            Call gobjCommProtocol.funcGet_NV_Pos()
                        End If
                    Next
                End If
                If (intk = intNVStep + 2) Then
                    'For intk = 0 To 2
                    For intk = 0 To 1
                        gobjCommProtocol.funcNV_Rotate_Clock()
                        'gobjCommProtocol.mobjCommdll.subTime_Delay(20)
                    Next
                End If
            End If
            Call gobjCommProtocol.funcGet_NV_Pos()
            '//----- Added by Sachin Dokhale on 04.07.07
            Call gobjCommProtocol.funcSave_NV_Pos()
            '//-----
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

    Public Function funcLoadLastOptimizedConditions(ByVal Is_AA_Flame As Boolean) As Boolean
        '=====================================================================
        ' Procedure Name        : funcLoadLastOptimizedConditions
        ' Parameters Passed     : None
        ' Returns               : True/False
        ' Purpose               : to read and implement last optimized conditions
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 29.04.10
        ' Revisions             : 
        '=====================================================================    
        Dim intBHSteps, intCount, intNvs As Integer
        Dim intPresentElementAtomicNumber As Integer
        Try
            intPresentElementAtomicNumber = gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).AtomicNumber

            If Not gobjFuelDataCollection Is Nothing Then
                For intCount = 0 To gobjFuelDataCollection.Count - 1
                    If gobjFuelDataCollection.item(intCount).AtomicNumber = intPresentElementAtomicNumber Then
                        '---set burner height 
                        intBHSteps = gobjFuelDataCollection.item(intCount).BurnerHeight
                        If Not intBHSteps = -1 Then
                            If intBHSteps <= 0 Or intBHSteps > MAXBHHOME Then
                                If gobjCommProtocol.funcSetBH_HOME() = False Then
                                    Return False
                                End If
                            Else
                                If intBHSteps > 0 Or intBHSteps <= MAXBHHOME Then
                                    If gobjCommProtocol.func_SetLastBhPos(intBHSteps) = False Then
                                        Return False
                                    End If
                                End If
                            End If
                        End If
                        '---set fuel ratio
                        intNvs = gobjFuelDataCollection.item(intCount).NVStep
                        gobjCommProtocol.mobjCommdll.subTime_Delay(50)

                        If Is_AA_Flame Then
                            If gobjCommProtocol.funcSet_Last_Fuel(intNvs) = False Then
                                Return False
                            End If
                        Else
                            'if nvs<3.0*NVRED then
                            If gobjCommProtocol.funcSet_Last_Fuel(intNvs) = False Then
                                Return False
                            End If
                        End If

                        'If intNvs < (3.5 * NVRED) And intNvs > NVRED Then                        
                        'End If

                    End If
                Next
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

    Public Function funcCheckPresenceOfLastFuelConditions() As Boolean
        '=====================================================================
        ' Procedure Name        : funcCheckPresenceOfLastFuelConditions
        ' Parameters Passed     : None
        ' Returns               : True/False
        ' Purpose               : to check the presence of last optimized conditions
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 29.04.10
        ' Revisions             : 
        '=====================================================================
        Dim objFuelData As clsFuelData
        Dim intCount As Integer
        Dim intPresentElementAtomicNumber As Integer
        Dim Formatter As BinaryFormatter
        Dim stream As Stream
        Dim strPath As String = ""
        Try
            intPresentElementAtomicNumber = gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).AtomicNumber

            If Not gobjFuelDataCollection Is Nothing Then
                For intCount = 0 To gobjFuelDataCollection.Count - 1
                    If gobjFuelDataCollection.item(intCount).AtomicNumber = intPresentElementAtomicNumber Then
                        Return True
                    End If
                Next
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

    Public Function funcSave_Fuel_Conditions() As Boolean
        '=====================================================================
        ' Procedure Name        : funcSave_Fuel_Conditions
        ' Parameters Passed     : None
        ' Returns               : True/False
        ' Purpose               : to save fuel conditions in file
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 29.04.10
        ' Revisions             : 
        '=====================================================================
        Dim objFuelData As clsFuelData
        Dim intCount As Integer
        Dim intPresentElementAtomicNumber As Integer
        Dim Formatter As BinaryFormatter
        Dim stream As Stream
        Dim strPath As String = ""
        Dim blnIsAddNew As Boolean = True
        Try

            Dim intIgniteType As Integer '---25.08.11
            Dim intIgnite_Test As ClsAAS203.enumIgniteType
            If gobjClsAAS203.funcIgnite_Test(intIgnite_Test) Then
                intIgniteType = intIgnite_Test
            End If '-----

            If intIgniteType = enumIgniteType.Blue Or intIgniteType = enumIgniteType.Yellow Then

                intPresentElementAtomicNumber = gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).AtomicNumber

                If Not gobjFuelDataCollection Is Nothing Then
                    If gobjFuelDataCollection.Count > 0 Then
                        For intCount = 0 To gobjFuelDataCollection.Count - 1
                            If gobjFuelDataCollection.item(intCount).AtomicNumber = intPresentElementAtomicNumber Then
                                blnIsAddNew = False
                                gobjFuelDataCollection.item(intCount).ElementName = gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).AtomicNumber 'gobjInst.ElementName
                                gobjFuelDataCollection.item(intCount).BurnerHeight = gobjInst.BhStep
                                gobjFuelDataCollection.item(intCount).NVStep = gobjInst.NvStep
                                gobjFuelDataCollection.item(intCount).IsAAFlame = gobjInst.Aaf
                            End If
                        Next
                    End If

                    If blnIsAddNew Then
                        objFuelData = New clsFuelData
                        objFuelData.AtomicNumber = gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).AtomicNumber
                        objFuelData.ElementName = gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).ElementName  'gobjInst.ElementName
                        objFuelData.BurnerHeight = gobjInst.BhStep
                        objFuelData.NVStep = gobjInst.NvStep
                        objFuelData.IsAAFlame = gobjInst.Aaf
                        gobjFuelDataCollection.Add(objFuelData)
                    End If
                End If

                Formatter = New BinaryFormatter
                stream = New FileStream(CONST_FUEL_CONDITIONS_FILE, FileMode.Create, FileAccess.ReadWrite, FileShare.None)

                Formatter.Serialize(stream, gobjFuelDataCollection)
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

    Public Function funcLoad_Fuel_Conditions() As Boolean
        '=====================================================================
        ' Procedure Name        : funcLoad_Fuel_Conditions
        ' Parameters Passed     : None
        ' Returns               : True/False
        ' Purpose               : to load the fuel conditions in object from file
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 29.04.10
        ' Revisions             : 
        '=====================================================================
        Dim Formatter As BinaryFormatter
        Dim fs As FileStream
        Dim fileLastOpt As File
        Try
            If (fileLastOpt.Exists(Application.StartupPath & "\" & CONST_FUEL_CONDITIONS_FILE)) Then
                fs = New FileStream(CONST_FUEL_CONDITIONS_FILE, FileMode.Open)

                If IsNothing(fs) Then
                    Return False
                Else
                    If fs.Length <= 0 Then
                        Return False
                    End If
                End If

                Formatter = New BinaryFormatter
                gobjFuelDataCollection = Formatter.Deserialize(fs)

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


    Public Function funcSetFuel(ByVal dblFuel As Double) As Boolean
        '=====================================================================
        ' Procedure Name        : funcSetFuel
        ' Parameters Passed     : fuel to be set
        ' Returns               : True/False
        ' Purpose               : for setting fuel.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 26.12.06
        ' Revisions             : 02.09.07
        '=====================================================================
        Dim intk As Integer
        Dim intNVStep As Integer
        Try
            '            void		S4FUNC	SetFuel(double fuel)
            '{  //0
            'int	k;
            'int	nvstep =ConvertToNvPos(fuel);
            ' Get_NV_Pos();
            'if (Inst.Nvstep>nvstep){  //1
            '	 nvstep=Inst.Nvstep-nvstep;
            '	 NV_RotateClock_Steps(nvstep);
            '	} //1
            ' else if (Inst.Nvstep<nvstep) {  //2
            'if (nvstep<=(NVRED*MAXNVHOME))
            '	  for (k=Inst.Nvstep; k<nvstep+2; k++){ //3
            '		 if ( !Flame_Present(FALSE)) {  //4
            '			NV_RotateClock();
            '			pc_delay(200);
            '			break;
            '		  } //4
            '		NV_RotateAnticlock();
            '#If QDEMO Then
            '	 Get_NV_Pos();
            '#End If
            '	  } //3
            '	if (k==nvstep+2)
            '	  for (k=0; k<2; k++){ //5
            '		 NV_RotateClock();
            '			pc_delay(200);
            '	  } //5
            '  } //2
            ' Get_NV_Pos();
            '} //0
            '-------------------------------------------------------
            If gobjInst.Aaf = True Or gobjInst.N2of = True Then
                intNVStep = funcConvertToNvPos(dblFuel)
                ''convert fuel in to a NV step.
                Call gobjCommProtocol.funcGet_NV_Pos()
                If (gobjInst.NvStep > intNVStep) Then
                    If intNVStep >= 0 Then
                        intNVStep = gobjInst.NvStep - intNVStep
                        Call gobjCommProtocol.funcNV_RotateClock_Steps(intNVStep)
                    End If

                ElseIf (gobjInst.NvStep < intNVStep) Then  ''2
                    'if (nvstep<=(NVRED*MAXNVHOME))
                    '	  for (k=Inst.Nvstep; k<nvstep+2; k++){ //3
                    '		 if ( !Flame_Present(FALSE)) {  //4
                    '			NV_RotateClock();
                    '			pc_delay(200);
                    '			break;
                    '		  } //4
                    '		NV_RotateAnticlock();
                    '#If QDEMO Then
                    '	 Get_NV_Pos();
                    '#End If
                    '	  } //3

                    If (intNVStep <= (NVRED * MAXNVHOME)) Then
                        For intk = gobjInst.NvStep To intNVStep + 1
                            If Not (gobjClsAAS203.funcFlame_Present(False)) Then
                                gobjCommProtocol.funcNV_Rotate_Clock()
                                gobjCommProtocol.mobjCommdll.subTime_Delay(50)
                                Exit For
                            End If
                            Call gobjCommProtocol.funcNV_Rotate_AntiClock()
                            'If gstructSettings.AppMode = EnumAppMode.DemoMode Then
                            If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                                (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                                (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                                Call gobjCommProtocol.funcGet_NV_Pos()
                            End If
                        Next
                    End If

                    '	if (k==nvstep+2)
                    '	  for (k=0; k<2; k++){ //5
                    '		 NV_RotateClock();
                    '			pc_delay(200);
                    '	  } //5
                    '  } //2

                    If (intk = intNVStep + 2) Then
                        For intk = 0 To 1
                            gobjCommProtocol.funcNV_Rotate_Clock()
                            gobjCommProtocol.mobjCommdll.subTime_Delay(50)
                        Next
                    End If
                End If

                Call gobjCommProtocol.funcGet_NV_Pos()
            End If
            ''for getting NV posotion
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

    ''//----- Burner Height
    Public Function funcReadAndSetBHScanConditions() As Boolean
        '=====================================================================
        ' Procedure Name        : funcReadAndSetBHScanConditions
        ' Parameters Passed     : 
        ' Returns               : True/False
        ' Purpose               : for scanning a burner height cond.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 26.12.06
        ' Revisions             : 
        '=====================================================================

        Try

            'string1	Cap[2];
            'string1	Str[2];
            'int		Len[3]={5,5,-1};

            ' strcpy(Cap[0], "Burner Height Scan Start(0-6mm)");
            ' sprintf(Str[0],"1");
            ' strcpy(Cap[1], "Burner Height Scan End(0-6mm)");
            ' sprintf(Str[1],"6");
            ' if (GetValues(hwnd, Cap, Str, Len)){
            '	PeakGraph.Ymin= 0.0;//GetEnergy(2047);
            '	PeakGraph.Ymax= 1.0;//GetEnergy(2047.0+409.6*4);
            '	PeakGraph.Xmin= atof(Str[0]);
            '	PeakGraph.Xmax= atof(Str[1]);
            '	if (PeakGraph.Xmin< PeakGraph.Xmax &&
            '	 ValidateHt(PeakGraph.Xmin) && ValidateHt(PeakGraph.Xmax))
            '	 return TRUE;
            '  }
            ' return FALSE;
            'Show the getValues Windows

            Return True
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
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcCheckBHPos() As Boolean
        '=====================================================================
        ' Procedure Name        : funcCheckBHPos
        ' Parameters Passed     : To check the BH Position
        ' Returns               : True/False
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 26.012.06
        ' Revisions             : 
        '=====================================================================

        Try
            '            BOOL	S4FUNC CheckBhPos()
            '{
            ' Get_BH_Pos();
            '            If (Inst.Bhstep < 0) Then
            '	BH_HOME();
            '                If (Inst.Bhstep < 0) Then
            '	return FALSE;
            ' return TRUE;
            '}

            Call gobjCommProtocol.func_Get_BH_Pos()
            ''serial communication for getting burner height position

            If (gobjInst.BhStep < 0) Then
                Call gobjCommProtocol.funcSetBH_HOME()
                ''set burner to home position
            End If

            If (gobjInst.NvStep < 0) Then
                Return False
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

    Public Function funcConvertToBHPos(ByVal dblBH As Double) As Integer
        '=====================================================================
        ' Procedure Name        : funcConvertToBHPos
        ' Parameters Passed     : dblBH 
        ' Returns               : Integer
        ' Purpose               : for converting burner height in to position
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 26.12.06
        ' Revisions             : 
        '=====================================================================

        Dim intBHSteps As Integer = 0
        Try

            'int	S4FUNC	ConvertToBhPos(double bh)
            '{
            'int	bhsteps=0;
            '// bh = bhstep/(200.0*BHRATIO);
            ' bhsteps=(int) (bh*(200.0*BHRATIO));
            ' return bhsteps;
            '}
            intBHSteps = CInt(dblBH * (200.0 * BHRATIO))
            Return intBHSteps

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return 0
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

    Public Function funcConvertToBurnerHeight(ByVal intBHStep As Integer) As Double
        '=====================================================================
        ' Procedure Name        : funcConvertToBurnerHeight
        ' Parameters Passed     : intBHStep
        ' Returns               : 
        ' Purpose               : function for converting a burner step in height
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : 
        ' Created               : 08.11.06
        ' Revisions             : 
        '=====================================================================
        Dim dblBH As Double = 0.0
        Try
            'double	S4FUNC ConvertToBurnerHeight(int steps)
            '{
            'double	bh=0.0;
            ' bh = steps/(200.0*BHRATIO);
            'return bh;
            '}

            dblBH = intBHStep / (200.0 * BHRATIO)
            Return dblBH

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

    Public Function funcSetBHPos(ByVal dblBH As Double) As Boolean
        '=====================================================================
        ' Procedure Name        : funcSetBHPos
        ' Parameters Passed     : burner height
        ' Returns               : True/False
        ' Purpose               : for setting burner position as par burner height
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 26.12.06
        ' Revisions             : 
        '=====================================================================
        Dim intk As Integer
        Dim intBHStep As Integer
        Try
            '            int	bhstep =ConvertToBhPos(bh);
            ' Get_BH_Pos();
            ' if (Inst.Bhstep>bhstep){
            '	 bhstep = Inst.Bhstep-bhstep;
            '	 BH_RotateAnticlock_Steps(bhstep);
            '	}
            'else if (Inst.Bhstep<bhstep){
            '	 bhstep-=Inst.Bhstep;
            '	 BH_RotateClock_Steps(bhstep);
            '  }

            intBHStep = funcConvertToBHPos(dblBH)
            ''function for converting burner height in to burner position

            gobjCommProtocol.func_Get_BH_Pos()
            ''get burner position

            If (gobjInst.BhStep > intBHStep) And (intBHStep >= 0) Then
                '	 bhstep = Inst.Bhstep-bhstep;
                '	 BH_RotateAnticlock_Steps(bhstep);
                intBHStep = gobjInst.BhStep - intBHStep
                Call gobjCommProtocol.func_BHRotateAntiClock_Steps(intBHStep)
                ''for roating burner in anticlock step.

            ElseIf (gobjInst.BhStep < intBHStep) And (intBHStep <= MAXBHHOME) Then
                '   bhstep-=Inst.Bhstep;
                '   BH_RotateClock_Steps(bhstep);
                intBHStep -= gobjInst.BhStep
                Call gobjCommProtocol.func_BHRotateClock_Steps(intBHStep)
                'for roating burner in clockwise step.
            End If
            '//-------------
            '//----- Added by Sachin Dokhale on 04.07.07
            'Call gobjCommProtocol.funcSave_BH_Pos()
            '//-----
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

    Public Function funcValidateHt(ByVal dblBH As Double) As Boolean
        '=====================================================================
        ' Procedure Name        : funcValidateHt
        ' Parameters Passed     : dblBH
        ' Returns               : True/False
        ' Purpose               : this is used to validate Burner Height.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 26.12.06
        ' Revisions             : 
        '=====================================================================
        Dim intk As Integer
        Dim intBHStep As Integer
        Try
            '            BOOL	ValidateHt(double bh)
            '{
            ' if (bh>=0 && bh<=6.0)
            '  return TRUE;
            'return FALSE;
            '}

            If (dblBH >= 0 And dblBH <= 6.0) Then
                Return True
            End If
            '//-------------
            Return False
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

    '//-----
    Public Sub subSetXoldYold(ByVal intXoldt As Integer, ByVal intYoldt As Integer)
        '=====================================================================
        ' Procedure Name        : funcSetXoldYold
        ' Parameters Passed     : intElementID
        ' Returns               : 
        ' Purpose               : to set x,y old value
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 26.12.06
        ' Revisions             : 
        '=====================================================================

        Try
            'E4FUNC  void	 S4FUNC SetXoldYold(int Xoldt, int Yoldt)
            '{
            'Xold=Xoldt;
            'Yold= Yoldt;
            '}
            '//---------------

            m_intXoldt = intXoldt
            m_intYoldt = intYoldt

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

    Public Sub subGetXoldYold(ByRef intXoldt As Integer, ByRef intYoldt As Integer)
        '=====================================================================
        ' Procedure Name        : subGetXoldYold
        ' Parameters Passed     : intXoldt, intYoldt
        ' Returns               : 
        ' Purpose               : to get x,y old value
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 26.12.06
        ' Revisions             : 
        '=====================================================================

        Try
            'E4FUNC  void	 S4FUNC GetXoldYold(int *Xoldt, int *Yoldt)
            '{
            '*Xoldt=Xold;
            '*Yoldt= Yold;

            '}
            intXoldt = m_intXoldt
            intYoldt = m_intYoldt

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

    '//----- Time Scan object function
    Public Function funcReadAndSetFuelScanConditions(ByVal frmobjArrlist As ArrayList) As Boolean
        '=====================================================================
        ' Procedure Name        : ReadAndSetFuelScanConditions
        ' Parameters Passed     : 
        ' Returns               : True/False
        ' Purpose               : used for scanning fuel condi
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 26.12.06
        ' Revisions             : 
        '=====================================================================
        Dim intCount As Integer
        Try
            '---Set Property ReportGraphControls
            If IsNothing(frmobjArrlist) = False Then
                'objclsPrintDocument.ReportGraphControls = New ArrayList
                Dim objBH() As Object

                For intCount = 0 To frmobjArrlist.Count - 1
                    If IsNothing(frmobjArrlist.Item(intCount)) = False Then
                        ' objclsPrintDocument.ReportGraphControls.Add(arrGraphControlsListIn.Item(intCount))
                    End If
                Next intCount
            End If
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
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Sub AbsorbanceScan()
        '=====================================================================
        ' Procedure Name        : AbsorbanceScan
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To show the window for Manual Optimization
        '                         i.e. Continuous TimeScan Mode
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 09-Jan-2007
        ' Revisions             : 1
        '=====================================================================
        Try
            'code added by : dinesh wagh on 28.3.2010
            '----------------------------------------------
            If (gstructSettings.Enable21CFR = True) Then
                If Not funcCheckActivityAuthentication(enumActivityAuthentication.Time_Scan, gstructUserDetails.Access) Then
                    Exit Sub
                End If
                gfuncInsertActivityLog(EnumModules.TimeScan, "Energy Spectrum Mode->TimeScan_Mode Accessed")
            End If
            '-----------------------------------------------

            gintSpectrumMode = modGlobalDeclarations.EnumSpectrumMode.TimeScan

            If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then

                If gintInstrumentBeamType = enumInstrumentBeamType.SingleBeam Or _
                   gintInstrumentBeamType = enumInstrumentBeamType.ReferenceBeam Then
                    Dim objfrmTimeScan As New frmTimeScanDBMode
                    Call objfrmTimeScan.ShowDialog()
                    Application.DoEvents()
                    objfrmTimeScan.Close()
                    objfrmTimeScan.Dispose()
                    Application.DoEvents()
                    objfrmTimeScan = Nothing
                Else
                    Dim objfrmTimeScan As New frmTimeScanDBMode
                    Call objfrmTimeScan.ShowDialog()
                    Application.DoEvents()
                    objfrmTimeScan.Close()
                    objfrmTimeScan.Dispose()
                    Application.DoEvents()
                    objfrmTimeScan = Nothing
                End If
            Else
                Dim objfrmTimeScan As New frmTimeScanMode
                Call objfrmTimeScan.ShowDialog()
                Application.DoEvents()
                objfrmTimeScan.Close()
                objfrmTimeScan.Dispose()
                Application.DoEvents()
                objfrmTimeScan = Nothing
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

        'gobjMessageAdapter.ShowMessage(constWorkUnderProcess)

        'E4FUNC  void	S4FUNC 	AbsorbanceScan(HWND hpar)
        '{
        'double	tval=0.0;
        'char		str[100]="";
        'HWND		hwnd=NULL;
        'MSG		msg;
        'double	xtime1=0, abs=0;
        'clock_t	CEnd, CEnd1;
        'HDC		hdc;
        'BOOL		Smooth=TRUE; // new changes
        ' DLGPROC  skp1 =(DLGPROC) MakeProcInstance((DLGPROC) OnAbsScanProc,hInst);
        '  ReinitInstParameters();
        ' Inst =  GetInstData();
        ' if (GetInstrument()==AA202)
        '  hwnd = CreateDialog(hInst,"ABSSCAN202", hpar, skp1);
        '        Else
        ' hwnd = CreateDialog(hInst,"ABSSCAN", hpar, skp1);
        ' WP1=-1;
        ' /*CheckInst();*/
        ' Inst =  GetInstData();
        ' ReadFilterSetting();   // new changes
        ' Afirst=TRUE;
        ' if (hwnd){
        '	UpdateWindow(hwnd);
        '	hdc= GetDC(hwnd);
        '	CEnd1=CEnd=clock();
        '	xtime1= ((CEnd-CEnd1)/(double) CLK_TCK);
        '	SetWindowText(GetDlgItem(hwnd,IDC_FILT),"Filt");
        '	do  {
        '	  if (CheckMsg(hwnd, &msg)){
        '		 if (WP1==IDC_FILT){ // new changes
        '			Smooth ^= TRUE;
        '                            If (Smooth) Then
        '			  SetWindowText(GetDlgItem(hwnd,IDC_FILT),"Filt");
        '                            Else
        '			  SetWindowText(GetDlgItem(hwnd,IDC_FILT),"No Filt");

        '			WP1=-1;
        '		  }
        '		 if (WP1==IDC_RET){
        '			pc_delay(1000);
        '			ReleaseDC(hwnd, hdc);
        '			DestroyWindow(hwnd);
        '			break;
        '		  }
        '		}
        '                                    If (IsInAltProcess()) Then
        '		 continue;
        '	  abs = GetAbsScanX();
        '	  if (Smooth)          	// new changes
        '		  abs = GetFiltData(abs);

        '		//---mdf by sk on 3/6/2001
        '                                            If (CheckMinAbsScanLmt) Then
        '		 {
        '		  if(abs<Absscanthldval) //0.008 mdf by sk on 3/6/2001
        '         abs=0.0;
        '		 }
        '      //---mdf by sk on 3/6/2001

        '	  CEnd=clock();
        '	  if (CEnd!=CEnd1 ){
        '		 xtime1 += ( ((double)(CEnd-CEnd1)/(double) CLK_TCK));
        '		 CEnd1 = CEnd;
        '		 GetWvAndDataInString(abs, str);
        '		 SetDlgItemText(hwnd,IDC_QAABS, str);
        '		 if (xtime1>=AbsGraph.Xmax){
        '			tval =(AbsGraph.Xmax-AbsGraph.Xmin);
        '			AbsGraph.Xmin = AbsGraph.Xmax;//(double)5.0;
        '			AbsGraph.Xmax +=tval;// (double)5.0;
        '			Calculate_Abs_Scan_Param(&AbsGraph);
        '			Afirst=TRUE;
        '			InvalidateRect(hwnd, NULL, TRUE); //AbsGraph.RC, TRUE);
        '			UpdateWindow(hwnd);
        '			CEnd1 = clock();
        '//			CStart += (CEnd1-CEnd);
        '		  }
        '		 if (Afirst){
        '			PlotInit(hdc, xtime1, abs, AbsGraph.RC, &AbsGraph);
        '			Afirst=FALSE;
        '		  }
        '                                                            Else
        '			Plotg(hdc, xtime1, abs, AbsGraph.RC, &AbsGraph);
        '		}
        '	  }
        '	 while(1);

        '  }
        ' FreeProcInstance(skp1);
        '  WP1=-1;
        ' ReinitInstParameters();
        '}
    End Sub

    Public Sub AbsorbanceScan_Testing() '09.05.08
        '=====================================================================
        ' Procedure Name        : AbsorbanceScan
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To show the window for Manual Optimization
        '                         i.e. Continuous TimeScan Mode
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 09-Jan-2007
        ' Revisions             : 1
        '=====================================================================
        Try
            gintSpectrumMode = modGlobalDeclarations.EnumSpectrumMode.TimeScan

            If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then

                If gintInstrumentBeamType = enumInstrumentBeamType.SingleBeam Or _
                   gintInstrumentBeamType = enumInstrumentBeamType.ReferenceBeam Then
                    Dim objfrmTimeScan As New frmTimeScanDBMode
                    'Call objfrmTimeScan.ShowDialog()
                    '---------------------------  '09.05.08
                    Call objfrmTimeScan.Show()
                    Application.DoEvents()
                    gobjMain.Visible = False
                    objfrmTimeScan.btnAutoZero.Focus()
                    Dim lblTime As New Label
                    Dim lblYValue As New Label
                    Call gobjCommProtocol.funcGetRefBaseVal()
                    objfrmTimeScan.funcOnSpect(False, lblTime, lblYValue)
                    '---------------------------

                    'objfrmTimeScan.Close()
                    'objfrmTimeScan.Dispose()
                    'Application.DoEvents()
                    'objfrmTimeScan = Nothing
                Else
                    Dim objfrmTimeScan As New frmTimeScanDBMode
                    'Call objfrmTimeScan.ShowDialog()
                    '---------------------------  '09.05.08
                    Call objfrmTimeScan.Show()
                    Application.DoEvents()
                    gobjMain.Visible = False
                    objfrmTimeScan.btnAutoZero.Focus()
                    Dim lblTime As New Label
                    Dim lblYValue As New Label
                    Call gobjCommProtocol.funcGetRefBaseVal()
                    objfrmTimeScan.funcOnSpect(False, lblTime, lblYValue)
                    '---------------------------

                    'Application.DoEvents()
                    'objfrmTimeScan.Close()
                    'objfrmTimeScan.Dispose()
                    'Application.DoEvents()
                    'objfrmTimeScan = Nothing
                End If
            Else
                Dim objfrmTimeScan As New frmTimeScanMode
                Call objfrmTimeScan.ShowDialog()
                Application.DoEvents()
                objfrmTimeScan.Close()
                objfrmTimeScan.Dispose()
                Application.DoEvents()
                objfrmTimeScan = Nothing
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

        'gobjMessageAdapter.ShowMessage(constWorkUnderProcess)

        'E4FUNC  void	S4FUNC 	AbsorbanceScan(HWND hpar)
        '{
        'double	tval=0.0;
        'char		str[100]="";
        'HWND		hwnd=NULL;
        'MSG		msg;
        'double	xtime1=0, abs=0;
        'clock_t	CEnd, CEnd1;
        'HDC		hdc;
        'BOOL		Smooth=TRUE; // new changes
        ' DLGPROC  skp1 =(DLGPROC) MakeProcInstance((DLGPROC) OnAbsScanProc,hInst);
        '  ReinitInstParameters();
        ' Inst =  GetInstData();
        ' if (GetInstrument()==AA202)
        '  hwnd = CreateDialog(hInst,"ABSSCAN202", hpar, skp1);
        '        Else
        ' hwnd = CreateDialog(hInst,"ABSSCAN", hpar, skp1);
        ' WP1=-1;
        ' /*CheckInst();*/
        ' Inst =  GetInstData();
        ' ReadFilterSetting();   // new changes
        ' Afirst=TRUE;
        ' if (hwnd){
        '	UpdateWindow(hwnd);
        '	hdc= GetDC(hwnd);
        '	CEnd1=CEnd=clock();
        '	xtime1= ((CEnd-CEnd1)/(double) CLK_TCK);
        '	SetWindowText(GetDlgItem(hwnd,IDC_FILT),"Filt");
        '	do  {
        '	  if (CheckMsg(hwnd, &msg)){
        '		 if (WP1==IDC_FILT){ // new changes
        '			Smooth ^= TRUE;
        '                            If (Smooth) Then
        '			  SetWindowText(GetDlgItem(hwnd,IDC_FILT),"Filt");
        '                            Else
        '			  SetWindowText(GetDlgItem(hwnd,IDC_FILT),"No Filt");

        '			WP1=-1;
        '		  }
        '		 if (WP1==IDC_RET){
        '			pc_delay(1000);
        '			ReleaseDC(hwnd, hdc);
        '			DestroyWindow(hwnd);
        '			break;
        '		  }
        '		}
        '                                    If (IsInAltProcess()) Then
        '		 continue;
        '	  abs = GetAbsScanX();
        '	  if (Smooth)          	// new changes
        '		  abs = GetFiltData(abs);

        '		//---mdf by sk on 3/6/2001
        '                                            If (CheckMinAbsScanLmt) Then
        '		 {
        '		  if(abs<Absscanthldval) //0.008 mdf by sk on 3/6/2001
        '         abs=0.0;
        '		 }
        '      //---mdf by sk on 3/6/2001

        '	  CEnd=clock();
        '	  if (CEnd!=CEnd1 ){
        '		 xtime1 += ( ((double)(CEnd-CEnd1)/(double) CLK_TCK));
        '		 CEnd1 = CEnd;
        '		 GetWvAndDataInString(abs, str);
        '		 SetDlgItemText(hwnd,IDC_QAABS, str);
        '		 if (xtime1>=AbsGraph.Xmax){
        '			tval =(AbsGraph.Xmax-AbsGraph.Xmin);
        '			AbsGraph.Xmin = AbsGraph.Xmax;//(double)5.0;
        '			AbsGraph.Xmax +=tval;// (double)5.0;
        '			Calculate_Abs_Scan_Param(&AbsGraph);
        '			Afirst=TRUE;
        '			InvalidateRect(hwnd, NULL, TRUE); //AbsGraph.RC, TRUE);
        '			UpdateWindow(hwnd);
        '			CEnd1 = clock();
        '//			CStart += (CEnd1-CEnd);
        '		  }
        '		 if (Afirst){
        '			PlotInit(hdc, xtime1, abs, AbsGraph.RC, &AbsGraph);
        '			Afirst=FALSE;
        '		  }
        '                                                            Else
        '			Plotg(hdc, xtime1, abs, AbsGraph.RC, &AbsGraph);
        '		}
        '	  }
        '	 while(1);

        '  }
        ' FreeProcInstance(skp1);
        '  WP1=-1;
        ' ReinitInstParameters();
        '}
    End Sub

    Public Function IsFilter() As Boolean
        '=====================================================================
        ' Procedure Name        : IsFilter
        ' Parameters Passed     : None
        ' Returns               : True/False
        ' Purpose               : return Filter condition
        ' Description           : check for filter
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 23.Jan.2007
        ' Revisions             : 
        '=====================================================================
        Try

            IsFilter = m_blnFilterFlag

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

    Public Function funcEnableDisableFilter(ByVal blnFilterFlag As Boolean) As Boolean
        '=====================================================================
        ' Procedure Name        : EnableDisableFilter
        ' Parameters Passed     : True/False
        ' Returns               : True/False
        ' Purpose               : for enable disable a filter
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 23.Jan.2007
        ' Revisions             : 
        '=====================================================================
        Try

            m_blnFilterFlag = blnFilterFlag

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

    Public Function Find_Analytical_Peak(ByVal intLampNo As Integer, ByRef dblWvOptIn As Double, _
                            Optional ByRef lblOptimizedWavelengthIn As Label = Nothing) As Boolean
        '=====================================================================
        ' Procedure Name        : Find_Analytical_Peak
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : this is used to find analytical peak.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        ''BOOL	S4FUNC 	Find_Analytical_Peak(HWND hpar, int intLampNo)
        ''{
        ''HWND		hwnd;
        ''HDC		hdc;
        ''double   	cur=0.0, wvnew=0.0;
        ''BOOL		flag= TRUE;
        ''char     line1[80]="";

        '**********************************************
        '---STEP 1
        '**********************************************
        ''#ifndef FINAL
        ''  Get_Instrument_Parameters(&Inst);
        ''#End If
        '' Inst =  GetInstData();
        '' if (intLampNo<0 || intLampNo>(GetMaxLamp()-1)) //5
        ''	return FALSE;

        '**********************************************
        '---STEP 2
        '**********************************************
        ''  wvnew = Inst->Lamp_par.lamp[intLampNo].wv;

        ''  if (strcmp(trim(Inst->Lamp_par.lamp[intLampNo].elname),"")==0){
        ''	 if( GetInstrument() == AA202)
        ''		 Gerror_message_new(" No Lamp in Mesurement Holder Position ...", "PEAK SEARCH");
        ''                            Else
        ''		 Gerror_message_new(" No Lamp in Turret Position ...", "PEAK SEARCH");
        ''	 return FALSE;
        ''	}

        '**********************************************
        '---STEP 3
        '**********************************************
        '' if(GetInstrument() != AA202 )
        ''	 AIR_OFF();

        '**********************************************
        '---STEP 4
        '**********************************************
        '' if((intLampNo+1) !=Inst->Lamp_pos){
        ''      strcpy(line1,"");        
        '' if (!Position_Turret(hpar, intLampNo+1,TRUE)){
        ''      if(GetInstrument() != AA202 )
        ''	        AIR_ON();
        ''	    if( GetInstrument() == AA202)
        ''	        Gerror_message_new("Error in Lamp Position ..", "LAMP");
        ''      Else
        ''	        Gerror_message_new("Error in Turret Module ..", "TURRET");
        ''	return FALSE;
        ''	}
        ''  }

        '**********************************************
        '---STEP 5
        '**********************************************
        '' wvnew = Inst->Lamp_par.lamp[Inst->Lamp_pos-1].wv;
        '' All_Lamp_Off();

        '**********************************************
        '---STEP 6 and 7
        '**********************************************
        '' if (Inst->Lamp_warm>0) 
        '' {
        ''      if (strcmp(trim(Inst->Lamp_par.lamp[Inst->Lamp_warm-1].elname),"")!=0)
        ''      {
        ''          cur = Inst->Lamp_par.lamp[Inst->Lamp_warm-1].cur;
        ''          If (cur > 0) Then        
        '' 	            Set_HCL_Cur(cur,Inst->Lamp_warm);
        ''      }
        '' }

        '**********************************************
        '---STEP 8 
        '**********************************************
        '' cur = Inst->Lamp_par.lamp[Inst->Lamp_pos-1].cur;
        '' if (cur==0)
        ''      Gerror_message_new("Current is 0.0 nm ", "WARNING");

        '**********************************************
        '---STEP 9 
        '**********************************************
        '' if( GetInstrument() == AA202)
        ''      Set_HCL_Cur(cur,Inst->Lamp_pos);
        '' Else
        ''      Set_HCL_Cur(cur,Inst->Lamp_pos);

        '**********************************************
        '---STEP 10 
        '**********************************************
        ''  if (Inst->Cur==(double) 0.0){        
        ''	    Inst->Cur=cur;
        ''	}

        ''#If !DEMO Then
        '' if(GetInstrument() == AA202 )
        ''#End If

        '**********************************************
        '---STEP 11 
        '**********************************************
        '' Inst->Lamp_par.lamp[Inst->Lamp_pos-1].lamp_optpos = 1;

        '**********************************************
        '---STEP 12
        '**********************************************
        '' if ( Inst->Lamp_par.lamp[Inst->Lamp_pos-1].lamp_optpos != 0 &&
        ''      Inst->Lamp_par.lamp[Inst->Lamp_pos-1].lamp_optpos != -1)
        '' {
        '**********************************************
        '---STEP 13
        '**********************************************
        ''      if (wvnew>=190.0 && wvnew<=900.0)
        ''      {

        '**********************************************
        '---STEP 14
        '**********************************************
        '' 	        hwnd= CreateWindowPeak(hpar, " ANALYTICAL LINE ","SKCK2",0 );
        '' 	        if (hwnd )
        ''          {

        '**********************************************
        '---STEP 15
        '**********************************************
        '' 		        SetInstrumentCondns(hwnd, TRUE);
        '' 		        cur=Inst->Lamp_par.lamp[Inst->Lamp_pos-1].slitwidth;
        '' 		        if (cur==0)
        '' 			        Gerror_message_new("Slitwidth is is 0.0 nm ", "WARNING");

        '**********************************************
        '---STEP 16
        '**********************************************
        '' 		        Set_SlitWidth(cur);

        '**********************************************
        '---STEP 17
        '**********************************************
        '' 		        pc_delay (200);

        '' 		        hdc= GetDC(hwnd);
        '' 		        SetBkColor(hdc, RGB(192, 192, 192));
        '' 		        SetText(hwnd, IDC_STATUS,"INITIALISING Please Wait  ....... ");

        '**********************************************
        '---STEP 18
        '**********************************************
        '' 		        wvnew = Inst->Lamp_par.lamp[Inst->Lamp_pos-1].wv- (double) ( (int) Inst->Lamp_par.lamp[Inst->Lamp_pos-1].wv);
        ''              If (wvnew < 0.5) Then
        ''	 		        wvnew= (double) ( (int) Inst->Lamp_par.lamp[Inst->Lamp_pos-1].wv);
        ''              Else
        ''			        wvnew= (double) ( (int) Inst->Lamp_par.lamp[Inst->Lamp_pos-1].wv)+(double) 0.5; //floor

        '**********************************************
        '---STEP 19
        '**********************************************
        ''		        strcpy(line1,""); sprintf(line1, " Setting wavelength from %6.2f nm to %6.2f nm", Inst->Wvcur, wvnew);
        ''		        SetText(hwnd, IDC_STATUS1,line1);
        ''		        Wavelength_Position(hdc, wvnew,5, 150);

        '**********************************************
        '---STEP 20
        '**********************************************
        ''		        strcpy(line1,"");
        ''		        sprintf(line1, " Optimizing %s  for Analytical Peak. ", Inst->Lamp_par.lamp[Inst->Lamp_pos-1].elname);
        ''		        SetText(hwnd, IDC_STATUS1,line1);

        '**********************************************
        '---STEP 21
        '**********************************************
        '' 		        if (!Analytical_Peak(hwnd , hdc, TRUE)) {
        '' 			        Gerror_message_new("Analytical Peak not found", "Analytical Peak");
        '' 			        pc_delay(300);
        '' 			        flag = FALSE;
        '' 		        }
        '' 		        else{
        ''			        wvopt = Inst->Wvcur;
        '' 			        flag=TRUE;
        ''		        }
        '' 		    } //hwnd
        '' 	        ReleaseDC(hwnd, hdc);
        '' 	        DestroyWindowPeak(hwnd,hpar);
        ''      } // wv 190-1000.0
        ''      else
        ''		{
        ''			Gerror_message_new("Wavelength Range 190.0..900.0 Only ","PEAK SEARCH");
        ''			flag = FALSE;
        ''		}
        ''	} // lamp-present
        ''  else
        ''	{
        ''		if(GetInstrument() == AA202)
        ''			Gerror_message_new("Lamp Not Optimised ..", "PEAK SEARCH");
        ''                                                                                                    Else
        ''			Gerror_message_new("Turret Not Optimised ..", "PEAK SEARCH");
        ''			//pc_sound(1000,2);;pc_sound(1000,1) ;pc_sound(1000,2);
        ''		pc_delay(3000);  flag = FALSE;
        ''	}
        ''  strcpy(line1,"");
        ''  Cal_Mode(Inst->Lamp_par.lamp[Inst->Lamp_pos-1].mode);
        ''  if (flag){
        ''	    if (MessageBox(hpar, " Do you want manual Optimisation ?", "INSTRUMENT CONDITIONS", MB_YESNO)==IDYES)
        ''		    AbsorbanceScan(hpar);
        ''	}
        ''  pc_delay(1500);
        ''  return flag;        
        '' }


        '*********************************************************
        '----Code By Mangesh S.
        '*********************************************************
        Dim cur As Double = 0.0
        Dim blnIsLampOptimized As Boolean
        Dim wvnew As Double = 0.0
        Dim objInstTemp As New AAS203Library.Instrument.ClsInstrument
        Dim intCount As Integer
        Try



            '**********************************************
            '---STEP 1 : Get Instrument Settings and Check 
            '---         lamp present or not. 
            '**********************************************
            ''#ifndef FINAL
            'Get_Instrument_Parameters(Inst)
            ''#End If
            'Inst = GetInstData()

            If (intLampNo < 1 Or intLampNo > (gobjClsAAS203.funcGetMaxLamp())) Then
                Return False
            End If

            '**********************************************
            '---STEP 2 : Get Wavelength of the selected lamp
            '---Check lamp present or not; if not give error message
            '**********************************************
            ''  if (strcmp(trim(Inst->Lamp_par.lamp[intLampNo].elname),"")==0){
            ''	 if( GetInstrument() == AA202)
            ''		 Gerror_message_new(" No Lamp in Mesurement Holder Position ...", "PEAK SEARCH");
            ''                            Else
            ''		 Gerror_message_new(" No Lamp in Turret Position ...", "PEAK SEARCH");
            ''	 return FALSE;
            ''	}
            wvnew = gobjInst.Lamp.LampParametersCollection(intLampNo - 1).Wavelength

            If Trim(gobjInst.Lamp.LampParametersCollection(intLampNo - 1).ElementName) = "" Then
                'gobjMessageAdapter.ShowMessage(" No Lamp in Turret Position ...", "PEAK SEARCH", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
                'gobjMessageAdapter.ShowMessage(constNoLamp)
                'Return False
                If (gstructSettings.AppMode = EnumAppMode.FullVersion_201) Then
                    'Gerror_message_new(" No Lamp in Mesurement Holder Position ...", "PEAK SEARCH");
                    Call gobjMessageAdapter.ShowMessage(constNoLampMeasurement)
                    Call Application.DoEvents()
                Else
                    'Gerror_message_new(" No Lamp in Turret Position ...", "PEAK SEARCH");
                    Call gobjMessageAdapter.ShowMessage(constNoLamp)
                    Call Application.DoEvents()
                End If

                Return False
            End If

            If gobjInst.Lamp.LampParametersCollection(intLampNo - 1).LampOptimizePosition = -1 Then
                If (gstructSettings.AppMode = EnumAppMode.FullVersion_201) Then
                    'Call gobjMessageAdapter.ShowMessage(constNoLampMeasurement)
                    'Call Application.DoEvents()
                Else
                    '//----- Commented and added by Sachin Dokhale for message
                    'Call gobjMessageAdapter.ShowMessage("Turret is not optimized.")
                    Call gobjMessageAdapter.ShowMessage("Turret is not optimized.", "Lamp Oprimization", MessageHandler.clsMessageHandler.enumMessageType.WarningMessage)
                    '//-----
                    Call Application.DoEvents()
                End If


                Return False
            End If

            '**********************************************
            '---STEP 3 : Sets Air OFF
            '**********************************************
            If Not (gstructSettings.AppMode = EnumAppMode.FullVersion_201) Then
                gobjCommProtocol.funcAir_OFF()
            End If

            '**********************************************
            '---STEP 4 : Sets Position of lamp turret to the 
            '---current lamp position; if not give error message.
            '**********************************************

            '---commented for ver 4.85 10.04.09
            ''If ((intLampNo) <> gobjInst.Lamp_Position) Then
            ''    If Not (gobjCommProtocol.gFuncTurret_Position(intLampNo, True)) Then
            ''        If Not (gstructSettings.AppMode = EnumAppMode.FullVersion_201) Then
            ''            Call gobjCommProtocol.funcAir_ON()
            ''        End If
            ''        If (gstructSettings.AppMode = EnumAppMode.FullVersion_201) Then
            ''            gobjMessageAdapter.ShowMessage(constErrorLampPosition)
            ''        Else
            ''            gobjMessageAdapter.ShowMessage(constErrorTurret)
            ''        End If
            ''        Call Application.DoEvents()
            ''        Return False
            ''    End If
            ''End If
            '-----------------

            '---written for ver 4.85 10.04.09
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or _
            gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then
                gobjInst.Lamp_Position = intLampNo
            Else
                If ((intLampNo) <> gobjInst.Lamp_Position) Then
                    If Not (gobjCommProtocol.gFuncTurret_Position(intLampNo, True)) Then
                        If Not (gstructSettings.AppMode = EnumAppMode.FullVersion_201) Then
                            Call gobjCommProtocol.funcAir_ON()
                        End If
                        If (gstructSettings.AppMode = EnumAppMode.FullVersion_201) Then
                            gobjMessageAdapter.ShowMessage(constErrorLampPosition)
                        Else
                            gobjMessageAdapter.ShowMessage(constErrorTurret)
                        End If
                        Call Application.DoEvents()
                        Return False
                    End If
                End If
            End If
            '------------------------------

            wvnew = gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).Wavelength


            '**********************************************
            '---STEP 5 : Set Lamps OFF (Lamp Current is 0.0 amp)
            '**********************************************
            Call gobjCommProtocol.funcAll_Lamp_Off()

            '**********************************************
            '---STEP 6 and 7 : Get WarmUp Lamp's Position and Current in Amp
            '--- and set that warmup lamp on (Glow it)
            '**********************************************
            If (gobjInst.Lamp_Warm > 0) Then
                If Trim(gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Warm - 1).ElementName) = "" Then
                    cur = gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Warm - 1).Current
                    If (cur > 0) Then
                        'Set_HCL_Cur(cur,Inst->Lamp_warm);
                        Call gobjCommProtocol.funcSet_HCL_Cur(cur, gobjInst.Lamp_Warm)
                    End If
                End If
            End If

            '**********************************************
            '---STEP 8 : Get Current Value of selected measurement
            '--- lamp; if it is zero give warning message.
            '**********************************************
            cur = gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).Current

            If (cur = 0) Then
                'gobjMessageAdapter.ShowMessage("Current is 0.0 nm ", "WARNING", MessageHandler.clsMessageHandler.enumMessageType.WarningMessage)
                gobjMessageAdapter.ShowMessage(constCurrent)
            End If

            '**********************************************
            '---STEP 9 : Set that Measurement lamp on and set the
            '**********************************************
            Call gobjCommProtocol.funcSet_HCL_Cur(cur, gobjInst.Lamp_Position)

            '**********************************************
            '---STEP 10 : Set taht Lamp Current value to Instrument Settings
            '**********************************************
            If (gobjInst.Current = 0.0) Then
                'gobjMessageAdapter.ShowMessage("Current is  0.0", "Warning", MessageHandler.clsMessageHandler.enumMessageType.WarningMessage)
                gobjMessageAdapter.ShowMessage(constCurrent)
                gobjInst.Current = cur
            End If

            '**********************************************
            '---STEP 11 : Sets Lamp Optimized Position as 1
            '**********************************************
            'Inst->Lamp_par.lamp[Inst->Lamp_pos-1].lamp_optpos = 1
            gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).LampOptimizePosition = 1

            '**********************************************
            '---STEP 12 : Check Lamp Optimized Position as 0 or -1
            '**********************************************
            If (gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).LampOptimizePosition <> 0 _
                And gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).LampOptimizePosition <> -1) Then

                '**********************************************
                '---STEP 13 : Check Wavelength is between 190.0 to 900.0 nm
                '**********************************************

                'commented and added by deepak on 24.07.07
                'If (wvnew >= 190.0 And wvnew <= 900.0) Then
                If (wvnew >= gstructSettings.WavelengthRange.WvLowerBound And wvnew <= gstructSettings.WavelengthRange.WvUpperBound) Then
                    '**********************************************
                    '---STEP 14 : Show Window for Analytical Peak
                    '**********************************************
                    Dim objfrmLampOptimisation As frmLampOptimisation
                    objfrmLampOptimisation = New frmLampOptimisation(True)
                    '---------------------------------------------------------------------------------
                    '---Steps No. from 15 to 17 are in the clsBgLampOptimization.
                    '---------------------------------------------------------------------------------
                    Call objfrmLampOptimisation.ShowDialog()

                    If Not (objfrmLampOptimisation.IsLampOptimized) Then
                        'gobjMessageAdapter.ShowMessage("Analytical Peak not found", "Analytical Peak", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                        gobjMessageAdapter.ShowMessage(constAnalyticalPeak)
                        Application.DoEvents()
                        blnIsLampOptimized = False
                    Else
                        dblWvOptIn = gobjInst.WavelengthCur
                        If Not IsNothing(lblOptimizedWavelengthIn) Then
                            lblOptimizedWavelengthIn.Text = "Optimized Wavelength : " & FormatNumber(objfrmLampOptimisation.OptimizedWavelength, 2) & " nm"
                        End If
                        blnIsLampOptimized = True
                    End If

                    '// wv 190-1000.0
                Else
                    'gobjMessageAdapter.ShowMessage("Wavelength Range 190.0..900.0 Only ", "PEAK SEARCH", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                    gobjMessageAdapter.ShowMessage(constWavelengthRange)
                    blnIsLampOptimized = False
                End If
                ' // lamp-present
            Else
                'if(GetInstrument() == AA202)
                ''			Gerror_message_new("Lamp Not Optimised ..", "PEAK SEARCH");
                ''                                                                                                    Else
                ''			Gerror_message_new("Turret Not Optimised ..", "PEAK SEARCH");

                'gobjMessageAdapter.ShowMessage("Turret Not Optimised ..", "PEAK SEARCH", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                'gobjMessageAdapter.ShowMessage(constTurretNotOptimised)
                If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                    gobjMessageAdapter.ShowMessage(constLampNotOptimised)
                Else
                    gobjMessageAdapter.ShowMessage(constTurretNotOptimised)
                End If
                '//pc_sound(1000,2);;pc_sound(1000,1) ;pc_sound(1000,2);
                gobjCommProtocol.mobjCommdll.subTime_Delay(30)
                blnIsLampOptimized = False
            End If
            '---------------------------------------------------------------------------------

            '---Changed by Mangesh on 08-Jan-2007
            ''Cal_Mode(Inst->Lamp_par.lamp[Inst->Lamp_pos-1].mode)
            If Not IsNothing(gobjNewMethod) Then
                Select Case gobjNewMethod.OperationMode
                    Case EnumOperationMode.MODE_AA
                        gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).Mode = EnumCalibrationMode.AA
                    Case EnumOperationMode.MODE_AABGC
                        gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).Mode = EnumCalibrationMode.AABGC
                    Case EnumOperationMode.MODE_EMMISSION
                        gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).Mode = EnumCalibrationMode.EMISSION
                End Select
            End If

            Call gobjCommProtocol.funcCalibrationMode(gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).Mode)

            '====================================================
            If File.Exists(Application.StartupPath & "\" & ConstInstFileName) = True Then
                ''If funcDeSerialize(ConstInstFileName, objInstTemp.Lamp) = True Then
                If funcDeSerialize(Application.StartupPath & "\" & ConstInstFileName, objInstTemp.Lamp) = True Then  '4.85  12.04.09
                    For intCount = 0 To objInstTemp.Lamp.LampParametersCollection.Count - 1
                        gobjInst.Lamp.LampParametersCollection.item(intCount).LampOptimizePosition = objInstTemp.Lamp.LampParametersCollection.item(intCount).LampOptimizePosition
                    Next
                End If
            End If
            '====================================================

            If (blnIsLampOptimized) Then

                '---written by Deepak on 03.05.10
                If IsInIQOQPQ Then
                    Application.DoEvents()
                    Call AbsorbanceScan()
                Else
                    If (gobjMessageAdapter.ShowMessage(constWantManualOptimisation) = True) Then
                        Application.DoEvents()
                        '---Manual Optimization or Instrument Setup
                        Call AbsorbanceScan()
                    End If
                End If
                Application.DoEvents()

                '---commented by Deepak on 03.05.10
                '''code commented by ; dinesh wagh on 8.4.2010
                '''------------------------------------------------------
                '''If (gobjMessageAdapter.ShowMessage(constWantManualOptimisation) = True) Then
                '''    Application.DoEvents()
                '''    '---Manual Optimization or Instrument Setup
                '''    Call AbsorbanceScan()
                '''End If
                '''-------------------------------------------------------

                '''code added by ; dinesh wagh on 8.4.2010
                '''removes the message.
                '''------------------------
                ''Application.DoEvents()
                ''Call AbsorbanceScan()
                '''------------------------------
                ''Application.DoEvents()
            End If

            gobjCommProtocol.mobjCommdll.subTime_Delay(15)
            Application.DoEvents()

            Return blnIsLampOptimized

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

    Public Function Find_Emmission_Peak() As Boolean
        '=====================================================================
        ' Procedure Name        : Find_Emmission_Peak
        ' Parameters Passed     : None
        ' Returns               : Boolean
        ' Purpose               : Finds Emmision Peak
        ' Description           : Finds Emmision Peak
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 08-Jan-2007 3:45 pm
        ' Revisions             : 
        '=====================================================================

        '*********************************************************
        '--- ORIGINAL  CODE
        '*********************************************************
        'BOOL	S4FUNC 	Find_Emmission_Peak(HWND hpar) //, double wv, double sw)
        '{
        'double	wvemis=0.0;
        'HWND	hwnd;
        'HDC	hdc;
        'BOOL	flag=FALSE,flag1=FALSE;
        'char  line1[180]="";
        ' if (strcmpi(trim(ltrim(Inst->Lamp_par.Ems.elname)),"")==0)
        '	return FALSE;
        ' if (Inst->Lamp_par.Ems.wv<190 || Inst->Lamp_par.Ems.wv>900)
        '	return FALSE;
        ' hwnd= CreateWindowPeak(hpar, " EMISSION LINE ","SKCK2",0 );
        ' EmsZero=(double) 0.0;
        ' if (hwnd){
        '	SetInstrumentCondns(hwnd, FALSE);
        '	hdc= GetDC(hwnd);
        '	SetBkColor(hdc, RGB(192, 192, 192));
        '	strcpy(line1,"");
        '	Cal_Mode(EMISSION);
        '	SetText(hwnd, IDC_STATUS,"INITIALISING Please Wait  ....... ");
        '	All_Lamp_Off();
        '	Set_D2_Cur(100);D2_OFF();
        '	Set_SlitWidth(Inst->Lamp_par.Ems.slitwidth);// pos_slit(slit);
        '	wvemis = Inst->Lamp_par.Ems.wv- (double) ( (int) Inst->Lamp_par.Ems.wv);
        '                    If (wvemis < 0.5) Then
        '	  wvemis = (double) ( (int) Inst->Lamp_par.Ems.wv);
        '                    Else
        '	  wvemis = (double) ( (int) Inst->Lamp_par.Ems.wv)+(double) 0.5; //floor
        '	strcpy(line1,""); sprintf(line1, " Setting wavelength from %6.2f nm to %6.2f nm", Inst->Wvcur, wvemis);
        '	SetText(hwnd, IDC_STATUS1,line1);
        '	Wavelength_Position(hdc, wvemis ,5, 150);
        '	strcpy(line1,""); sprintf(line1, " Optimizing %s  for Emission Peak.          ",Inst->El);
        '	SetText(hwnd, IDC_STATUS, line1);
        '	if(GetInstrument() == AA202)
        '	  flag1 =  Check_Ignite_AA202(hwnd);
        '                        Else
        '		flag1 =  Check_Ignite();
        '	if (flag1) {
        '	  if (MessageBox(hwnd, "Press YES for flame optimization\nPress No for emission line lacthing\n[Note:-If flame is not ignited it can not lacth on emission line]", "EMMISION PEAK", MB_YESNO)==IDYES)
        '		AbsorbanceScan(hpar);
        '	  Blink_MessageBox(hwnd, "Aspirate MAXIMUM STD. and Press OK", "EMMISION PEAK", 0);
        '//	  MessageBox(hwnd, "Aspirate MAXIMUM STD. and Press OK", "EMMISION PEAK", MB_OK);
        '	  ShowWindow(hwnd,SW_SHOW);
        '	  pc_delay(1000);
        '	  if (!Analytical_Peak(hwnd , hdc, FALSE)){
        '		 Gerror_message_new("Emission Peak not found","PEAK SEARCH");
        '		 pc_delay(300);
        '		 SetFocus(hwnd);
        '		}
        '	  else{
        '		 flag=TRUE;
        '		  Auto_blank_Emission(hwnd, TRUE);
        '		 }
        '/*	  else{
        '		wvopt = wvcur;
        '		if (button(20, 12, " Modify Analysis Parameters ? (Y/N) ", FALSE)) Parameters();

        '       If (Button(20, 12, " Do you want manual optimization ?", False)) Then
        '		    abs_scan();
        '		emmision();
        '		}*/
        '	}
        '  ReleaseDC(hwnd, hdc);
        '  DestroyWindowPeak(hwnd,hpar);
        '  if (flag && MessageBox(hpar, " Do you want manual Optimisation ?", "INSTRUMENT CONDITIONS", MB_YESNO)==IDYES)
        '	AbsorbanceScan(hpar);

        ' }
        'return flag;
        '}
        '*********************************************************
        Dim blnIsLampOptimized As Boolean
        Dim objfrmLampOptimisation As frmLampOptimisation

        Try
            '*********************************************************
            '--- CODE BY MANGESH
            '*********************************************************
            If Trim(gobjInst.Lamp.EMSCondition.ElementName) = "" Then
                Return False
            End If

            If (gobjInst.Lamp.EMSCondition.Wavelength < gstructSettings.WavelengthRange.WvLowerBound _
                Or gobjInst.Lamp.EMSCondition.Wavelength > gstructSettings.WavelengthRange.WvUpperBound) Then
                Return False
            End If

            objfrmLampOptimisation = New frmLampOptimisation(False)

            objfrmLampOptimisation.ShowDialog()

            blnIsLampOptimized = objfrmLampOptimisation.IsLampOptimized

            objfrmLampOptimisation.Close()
            objfrmLampOptimisation.Dispose()
            objfrmLampOptimisation = Nothing

            EmsZero = 0.0

            If (blnIsLampOptimized) Then
                If (gobjMessageAdapter.ShowMessage(constWantManualOptimisation) = True) Then
                    Application.DoEvents()
                    Call gobjClsAAS203.AbsorbanceScan()
                End If
            Else
                Application.DoEvents()
            End If

            Return blnIsLampOptimized

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

    Public Function SaveQuantResults(ByRef objMethodInfo As Method.clsMethod, ByVal A1() As Double, ByVal reprocess As Boolean, Optional ByVal ShowMessages As Boolean = True) As Boolean
        '=====================================================================
        ' Procedure Name        : SaveQuantResults
        ' Parameters Passed     : objMethodInfo, A1(),reprocess,ShowMessages
        ' Returns               : Boolean
        ' Purpose               : Save Quantitative data into method object
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        Dim objWaitCursor As New CWaitCursor
        Dim nmetc As Double = 0.0
        Dim ninst As Double
        Dim nrep As Double
        Dim nparam As Double

        Dim intRunNumberIndex As Integer
        Dim intMethodCounter As Integer

        Try
            '***************************************************************
            'DATA4  	*mthdata=NULL,*aadata=NULL;
            'DATA4  	*aainstdata=NULL,*aarepdata=NULL;
            'DATA4  	*aaparamdata=NULL,*stdinfodata=NULL;
            'DATA4  	*sampinfodata=NULL,*methstddata=NULL;
            'DATA4  	*methsampdata=NULL,*aastatdata=NULL,*aaresultdata=NULL;
            'INDEX4  *mthidx=NULL,*aaidx=NULL;
            'INDEX4  *aainstidx=NULL,*aarepidx=NULL;
            'INDEX4  *aaparamidx=NULL,*stdinfoidx=NULL;
            'INDEX4  *sampinfoidx=NULL,*methstdidx=NULL;
            'INDEX4  *methsampidx=NULL,*aastatidx=NULL, *aaresultidx=NULL;

            'DLGPROC skp1=NULL;
            'char		fname[80]="";
            'char		rsultfname[80]="";

            'If (!temp) Then return FALSE;
            '--- Check if objMethodInfo object is nothing then exit from function
            If IsNothing(objMethodInfo) Then Return False

            '--- Set the last index No of QuantitativeDataCollection object
            'if (!temp->QuantData) return FALSE;
            If gobjNewMethod.QuantitativeDataCollection.Count > 0 Then
                intRunNumberIndex = gobjNewMethod.QuantitativeDataCollection.Count - 1
            Else
                intRunNumberIndex = 0
            End If
            '--- Check if StandardDataCollection object is nothing then exit from function
            '--- Check if SampleDataCollection object is nothing then exit from function
            If IsNothing(objMethodInfo.QuantitativeDataCollection.Item(intRunNumberIndex).StandardDataCollection) Then Return False
            If IsNothing(objMethodInfo.QuantitativeDataCollection.Item(intRunNumberIndex).SampleDataCollection) Then Return False

            'GetInstrumentData(&(temp->Aas));

            'if (GetAnalysedStandards(temp->QuantData->StdTopData)<1)
            '   return FALSE;
            'If GetAnalysedStandards(objMethodInfo.StdParametersCollection) < 1 Then
            '    Return False
            'End If

            If Not reprocess Then
                '--- Check if instrument contion is not valid then exit from function
                If Not (CheckValidInstConditions(objMethodInfo.InstrumentCondition)) Then
                    Return False
                End If
            End If

            'if (!QDIopen("METHOD",&mthdata, &mthidx))
            '	return  FALSE;

            'if (!QDIopen("AAMETHOD",&aadata, &aaidx))
            '{
            '	d4close_all(cb);
            '	return  FALSE;
            '}
            'if (!QDIopen("AAINST",&aainstdata, &aainstidx))
            '{
            '	d4close_all(cb);
            '	return  FALSE;
            '}
            'if (!QDIopen("AAREPORT",&aarepdata, &aarepidx))
            '{
            '	d4close_all(cb);
            '	return  FALSE;
            '}
            'if (!QDIopen("AAPARAM",&aaparamdata, &aaparamidx))
            '{
            '	d4close_all(cb);
            '	return  FALSE;
            '}
            'if (!QDIopen("STDINFO",&stdinfodata, &stdinfoidx))
            '{
            '	d4close_all(cb);
            '	return  FALSE;
            '}
            'if (!QDIopen("METHSTD",&methstddata, &methstdidx))
            '{
            '	d4close_all(cb);
            '	return  FALSE;
            '}
            'if (!QDIopen("SAMPINFO",&sampinfodata, &sampinfoidx))
            '{
            '	d4close_all(cb);
            '	return  FALSE;
            '}
            'if (!QDIopen("METHSAMP",&methsampdata, &methsampidx))
            '{
            '	d4close_all(cb);
            '	return  FALSE;
            '}
            'if (!QDIopen("AASTAT",&aastatdata, &aastatidx))
            '{
            '	d4close_all(cb);
            '	return  FALSE;
            '}
            'if (!QDIopen("AARESULT",&aaresultdata, &aaresultidx))
            '{
            'd4close_all(cb);
            'return  FALSE;
            '}

            If Not (reprocess) Then
                'SaveInstrumentData(aainstdata,  temp->Aas)
            End If
            '--- Set the saving messages
            If ShowMessages = True Then
                gobjMessageAdapter.ShowStatusMessageBox("Updating Results", "QUANTITATIVE RESULTS", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 1000)
                Application.DoEvents()
            End If

            'If NOT (reprocess) Then
            '	AppendAndCopyAAParam( aaparamdata,mthdata, mthidx, &(temp->QuantData->Param));
            'end if

            'AppendAndCopyAAReport(aarepdata, mthdata, mthidx,&(temp->QuantData->RepData));

            'If NOT (reprocess) Then
            '	AppendandCopyAAInstFile(aainstdata, mthdata,mthidx,  &(temp->Aas));
            'end if

            '--- Set the saving messages
            If ShowMessages = True Then
                Call gobjMessageAdapter.UpdateStatusMessageBox("Updating Method ...", "QUANTITATIVE RESULTS")
                Application.DoEvents()
                gobjCommProtocol.mobjCommdll.subTime_Delay(50)
            End If

            'AppendandCopyMethodFile(mthdata, temp->NmetC, temp->Nmet, temp->Aas.nInst, temp->QuantData->Param.nParam,temp->QuantData->RepData.nRep);

            'AppendandAARESULTS(aaresultdata, temp,A1);

            '--- Set the saving messages
            If ShowMessages = True Then
                Call gobjMessageAdapter.UpdateStatusMessageBox("Creating Reports for standards ...", "QUANTITATIVE RESULTS")
                Application.DoEvents()
                gobjCommProtocol.mobjCommdll.subTime_Delay(50)
            End If

            'if ( temp->NmetC>0 && temp->QuantData->StdTopData )
            '	AppendStandardsFile(methstddata, methstdidx, mthdata, stdinfodata, aastatdata, temp->NmetC, (temp->QuantData->StdTopData), TRUE, NULL);
            'end if

            '--- Set the saving messages
            If ShowMessages = True Then
                Call gobjMessageAdapter.UpdateStatusMessageBox("Creating Reports for samples ...", "QUANTITATIVE RESULTS")
                Application.DoEvents()
                gobjCommProtocol.mobjCommdll.subTime_Delay(50)
            End If

            'if (temp->NmetC>0 && temp->QuantData->SampTopData )
            '   AppendSamplesFile(methsampdata, methsampidx, mthdata,sampinfodata,aastatdata, temp->NmetC, (temp->QuantData->SampTopData), temp, TRUE,NULL);
            'end if

            '--- Set the saving messages
            If ShowMessages = True Then
                Call gobjMessageAdapter.UpdateStatusMessageBox("Storing RawData File ...", "QUANTITATIVE RESULTS")
                Application.DoEvents()
                gobjCommProtocol.mobjCommdll.subTime_Delay(50)
            End If

            'strcpy(fname,Data_Dir.rawdir);

            'if (fname[strlen(fname)-1]!='\\')
            '	strcat(fname,"\\");
            'end if

            'sprintf(rsultfname,"%08.0f.dat",temp->QuantData->Fname );
            'strcat(fname, rsultfname);
            'If (RawDataSaveFn) Then
            '    (*RawDataSaveFn) (fname); 
            'end if

            '--- Set the saving messages
            If ShowMessages = True Then
                Call gobjMessageAdapter.UpdateStatusMessageBox("Updating Method File ...", "QUANTITATIVE RESULTS")
                Application.DoEvents()
                gobjCommProtocol.mobjCommdll.subTime_Delay(200)
            End If
            '--- save the method info into method object 
            Dim intRunNoIdx As Integer
            intRunNoIdx = objMethodInfo.QuantitativeDataCollection.Count - 1
            For intMethodCounter = 0 To gobjMethodCollection.Count - 1
                If gobjMethodCollection.item(intMethodCounter).MethodID = objMethodInfo.MethodID Then
                    objMethodInfo.QuantitativeDataCollection.Item(intRunNoIdx).InstrumentParameterForRunNumber = New clsInstrumentParameters
                    objMethodInfo.QuantitativeDataCollection.Item(intRunNoIdx).InstrumentParameterForRunNumber = objMethodInfo.InstrumentCondition.Clone
                    objMethodInfo.QuantitativeDataCollection.Item(intRunNoIdx).InstrumentParameterForRunNumber.D2Current = gobjInst.D2Current
                    objMethodInfo.QuantitativeDataCollection.Item(intRunNoIdx).InstrumentParameterForRunNumber.SlitWidth = funcGet_SlitWidth()
                    objMethodInfo.QuantitativeDataCollection.Item(intRunNoIdx).InstrumentParameterForRunNumber.ExitSlitWidth = funcGet_SlitWidth(1)
                    objMethodInfo.QuantitativeDataCollection.Item(intRunNoIdx).InstrumentParameterForRunNumber.PmtVoltage = gobjInst.PmtVoltage
                    objMethodInfo.QuantitativeDataCollection.Item(intRunNoIdx).InstrumentParameterForRunNumber.RefPmtVoltage = gobjInst.PmtVoltageReference
                    objMethodInfo.QuantitativeDataCollection.Item(intRunNoIdx).InstrumentParameterForRunNumber.FuelRatio = funcRead_Fuel_Ratio() 'funcGet_Fuel_Ratio(False)
                    objMethodInfo.QuantitativeDataCollection.Item(intRunNoIdx).InstrumentParameterForRunNumber.LampCurrent = gobjInst.Current
                    objMethodInfo.QuantitativeDataCollection.Item(intRunNoIdx).InstrumentParameterForRunNumber.LampNumber = gobjInst.Lamp_Position
                    objMethodInfo.QuantitativeDataCollection.Item(intRunNoIdx).InstrumentParameterForRunNumber.TurretNumber = objMethodInfo.InstrumentCondition.TurretNumber
                    objMethodInfo.QuantitativeDataCollection.Item(intRunNoIdx).InstrumentParameterForRunNumber.BurnerHeight = funcReadBurnerHeight()
                    objMethodInfo.DateOfLastUse = Now()

                    '--- Make the clone object of Method into Method collection object
                    '--- Assign object of clsInstrumentParameters into Method collection object
                    gobjMethodCollection.item(intMethodCounter) = objMethodInfo.Clone()
                    gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection(intRunNoIdx).InstrumentParameterForRunNumber = objMethodInfo.QuantitativeDataCollection.Item(intRunNoIdx).InstrumentParameterForRunNumber.Clone  '4.85 12.04.09
                    Exit For
                End If
            Next
            'Call funcSerialize(ConstMethodsFileName, gobjMethodCollection)
            '--- Save the method collection object into file system
            Call funcSaveAllMethods(gobjMethodCollection)

            'nmetc = temp->NmetC
            'nparam = temp->QuantData->Param.nParam
            'nrep = temp->QuantData->RepData.nRep
            'ninst= temp->Aas.nInst
            'temp->RepReady=FALSE

            If Not (reprocess) Then
                'AppendMethod(temp, QALL)
            End If

            If ShowMessages = True Then
                Call gobjMessageAdapter.UpdateStatusMessageBox("Completed", "QUANTITATIVE RESULTS")
                Application.DoEvents()
                gobjCommProtocol.mobjCommdll.subTime_Delay(50)
            End If

            If ShowMessages = True Then
                gobjMessageAdapter.CloseStatusMessageBox()
                Application.DoEvents()
            End If

            'temp->RepReady=TRUE;

            Return True
            '***************************************************************

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
            If ShowMessages = True Then
                gobjMessageAdapter.CloseStatusMessageBox()
                Application.DoEvents()
            End If
            objWaitCursor.Dispose()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function ReadRawDataFile(ByVal strFullFileName As String, ByRef dblMinXTime As Double, _
                                    ByRef dblMaxXTime As Double, ByRef objAnalysisRawData As Analysis.clsRawDataCollection) As Boolean
        '=====================================================================
        ' Procedure Name        : ReadRawDataFile
        ' Parameters Passed     : File Name,, which is to be read.
        '                       : dblMinXTime,dblMaxXTime,objAnalysisRawData
        ' Returns               : True/False
        ' Purpose               : for reading a row data file.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 24-Feb-2007 02:55 pm
        ' Revisions             : 1
        '=====================================================================
        Dim fs As IO.FileStream
        Dim sr As IO.StreamReader
        Dim intSampleType As Analysis.clsRawData.enumSampleType
        Dim intSampleID As Integer
        Dim strSampleName As String
        Dim intNoOfReadings As Integer
        Dim dblXTime As Double
        Dim dblAbsorbance As Double
        Dim objRawData As Analysis.clsRawData
        Dim blnIsFirstTime As Boolean = True

        Try
            '--- for reading a row data file.
            If Not IO.File.Exists(strFullFileName) Then
                Exit Function
            End If

            fs = New IO.FileStream(strFullFileName, IO.FileMode.Open, IO.FileAccess.Read)
            ''open a file for reading
            sr = New IO.StreamReader(fs)

            Dim strLine As String
            Dim strArrHeader() As String
            Dim strArrValues() As String

            If Not IsNothing(sr) Then
                dblMinXTime = 0.0
                objAnalysisRawData = New Analysis.clsRawDataCollection
                '''object for raw data collection.

                Do While (True)
                    strLine = sr.ReadLine()
                    If Not IsNothing(strLine) Then
                        If strLine.Length = 0 Then
                            '---Empty line.. Do Nothing...
                        Else
                            strArrHeader = strLine.Split(";"c)
                            If strArrHeader.Length > 3 Then
                                If Trim(strArrHeader(0)) = "BLANK" Then
                                    intSampleType = ClsAAS203.enumSampleType.BLANK
                                ElseIf Trim(strArrHeader(0)) = "STANDARD" Then
                                    intSampleType = ClsAAS203.enumSampleType.STANDARD
                                ElseIf Trim(strArrHeader(0)) = "SAMPLE" Then
                                    intSampleType = ClsAAS203.enumSampleType.SAMPLE
                                End If
                                intSampleID = Val(strArrHeader(1))
                                strSampleName = Trim(strArrHeader(2))
                                intNoOfReadings = Val(strArrHeader(3))

                                objRawData = New Analysis.clsRawData
                                objRawData.SampleType = intSampleType
                                objRawData.SampleID = intSampleID
                                objRawData.SampleName = strSampleName
                                If Not IsNothing(objRawData) Then
                                    objAnalysisRawData.Add(objRawData)
                                End If
                            End If

                            strArrValues = strLine.Split(","c)
                            If strArrValues.Length > 1 Then
                                dblXTime = Val(strArrValues(0))
                                dblAbsorbance = Val(strArrValues(1))
                                objRawData.AddReadings(dblXTime, dblAbsorbance)

                                If blnIsFirstTime = True Then
                                    dblMinXTime = dblXTime
                                    blnIsFirstTime = False
                                End If
                                dblMaxXTime += dblXTime
                            End If
                        End If
                    Else
                        Exit Do
                    End If
                Loop

            End If

            If Not IsNothing(objAnalysisRawData) Then
                If objAnalysisRawData.Count > 0 Then
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
            If Not IsNothing(sr) Then sr.Close() : sr = Nothing
            If Not IsNothing(fs) Then fs.Close() : fs = Nothing
            '---------------------------------------------------------
        End Try
    End Function

    Public Sub subShowGraphPreview(ByRef PreviewGraph As AASGraph, ByRef objPreviewCurve As AldysGraph.CurveItem, ByVal strRunNumber As String, ByVal objclsMethod As clsMethod)
        '=====================================================================
        ' Procedure Name        : subShowGraphPreview
        ' Parameters Passed     : PreviewGraph,objPreviewCurve,strRunNumber,objclsMethod
        ' Returns               : None
        ' Purpose               : To plot graph of Time Vs. Absorbance
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 25-Feb-2007 03:05 pm
        ' Revisions             : 1
        '=====================================================================
        Dim strRunNumberFileName As String
        Dim dblXMin As Double
        Dim dblXMax As Double
        Dim objAnalysisRawData As AAS203Library.Analysis.clsRawDataCollection
        Dim intCounter As Integer
        Dim intReadingsCounter As Integer
        Dim dblXTime As Double
        Dim dblAbsorbance As Double
        Dim curveColor As Color
        Dim blnIsFirstTime As Boolean
        Dim intRunNumberCounter As Integer

        Try
            '--- To plot graph of Time Vs. Absorbance
            For intRunNumberCounter = 0 To objclsMethod.QuantitativeDataCollection.Count - 1
                If objclsMethod.QuantitativeDataCollection.Item(intRunNumberCounter).RunNumber = strRunNumber Then
                    objAnalysisRawData = objclsMethod.QuantitativeDataCollection(intRunNumberCounter).AnalysisRawData
                End If
            Next

            If Not IsNothing(objAnalysisRawData) Then
                If objAnalysisRawData.Count > 0 Then
                    blnIsFirstTime = True
                    objPreviewCurve = Nothing
                    PreviewGraph.AldysPane.CurveList.Clear()

                    PreviewGraph.XAxisMin = 0.0
                    PreviewGraph.XAxisMax = 100.0
                    'PreviewGraph.YAxisMin = -0.2
                    'PreviewGraph.YAxisMax = 1.1

                    PreviewGraph.Invalidate()
                    PreviewGraph.Refresh()
                    Application.DoEvents()

                    For intCounter = 0 To objAnalysisRawData.Count - 1
                        For intReadingsCounter = 0 To objAnalysisRawData.item(intCounter).Readings.Count - 1
                            dblXTime = objAnalysisRawData.item(intCounter).Readings.item(intReadingsCounter).XTime
                            dblAbsorbance = objAnalysisRawData.item(intCounter).Readings.item(intReadingsCounter).Absorbance

                            Select Case objAnalysisRawData.item(intCounter).SampleType
                                Case clsRawData.enumSampleType.BLANK
                                    curveColor = ClsAAS203.BLANKCOLOR
                                Case clsRawData.enumSampleType.STANDARD
                                    curveColor = ClsAAS203.STDCOLOR
                                Case clsRawData.enumSampleType.SAMPLE
                                    curveColor = ClsAAS203.SAMPCOLOR
                            End Select

                            If blnIsFirstTime Then
                                objPreviewCurve = PreviewGraph.StartOnlineGraph(strRunNumber, Color.Red, AldysGraph.SymbolType.NoSymbol, True)
                                blnIsFirstTime = False
                                PreviewGraph.PlotPoint(objPreviewCurve, dblXTime, dblAbsorbance)
                            Else
                                objPreviewCurve.CL.Add(curveColor)
                                PreviewGraph.PlotPoint(objPreviewCurve, dblXTime, dblAbsorbance)
                            End If
                        Next
                    Next
                    PreviewGraph.AldysPane.Legend.IsVisible = False
                    PreviewGraph.IsShowGrid = False
                Else
                    objPreviewCurve = Nothing
                    PreviewGraph.AldysPane.CurveList.Clear()
                End If
            Else
                objPreviewCurve = Nothing
                PreviewGraph.AldysPane.CurveList.Clear()
            End If

            PreviewGraph.Invalidate()
            PreviewGraph.Refresh()
            Application.DoEvents()

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

    '//----- Auto Zero
    Public Sub subAutoZero(ByVal Flag As Boolean)
        '=====================================================================
        ' Procedure Name        :   subAutoZero
        ' Description           :   To set Auto Zero for AA,BGC and Emission Mode
        ' Purpose               :   
        '                           
        ' Parameters Passed     :   Boolean Flag
        ' Returns               :   None
        ' Parameters Affected   :   
        ' Assumptions           :   
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale 
        ' Created               :   10.12.06
        ' Revisions             :
        '=====================================================================
        Try
            '       Auto_Zero(hwnd, TRUE);

            '//-----------------

            ' ReinitInstParameters();
            ' Inst = GetInstData();
            ' if (Inst->Mode==AA) {
            '	AutoZeroAbsMode(hwnd);
            '	if (flag){
            '#If !IN203DLL Then
            '		Get_Instrument_Parameters(&Inst);
            '#End If
            '	  Scroll_Pmt(hwnd,IDC_PMT, -1);
            '	 }
            '	}
            ' else if (Inst->Mode==AABGC) {
            '	  ReinitInstParameters();
            '	  Bgc_Zero(hwnd, TRUE);
            '	  ReinitInstParameters();
            '#If !IN203DLL Then
            '		Get_Instrument_Parameters(&Inst);
            '#End If
            '	  if (flag){
            '		 Scroll_Cur(hwnd,IDC_CUR, -1 );
            '		 Scroll_D2Cur(hwnd,IDC_D2CUR, -1 );
            '		 Scroll_Pmt(hwnd,IDC_PMT, -1);
            '		}
            '	}
            '  else if (Inst->Mode==EMISSION){
            '	  ReinitInstParameters();
            '	  Auto_blank_Emission(hwnd, FALSE);
            '     ReinitInstParameters();
            '	}
            ' ReinitInstParameters();
            ' }

            'if(ReadIniForD2Gain()){
            '           If (IsD2GainOn()) Then
            '		SetWindowText(GetDlgItem(hwnd,IDC_PBD2GAIN),"D2 Gain OFF");
            '           Else
            '		SetWindowText(GetDlgItem(hwnd,IDC_PBD2GAIN),"D2 Gain ON");
            '}
            Application.DoEvents()
            gobjCommProtocol.mobjCommdll.subTime_Delay(100)
            Application.DoEvents()
            gobjClsAAS203.ReInitInstParameters()
            Select Case gobjInst.Mode
                Case EnumCalibrationMode.AA
                    Call gobjClsAAS203.funcAutoZeroAbsMode()
                    Application.DoEvents()
                    blnResetFilterData = True
                Case EnumCalibrationMode.AABGC
                    'gobjClsAAS203.ReInitInstParameters()
                    gobjClsAAS203.funcBgc_Zero(True)
                    Application.DoEvents()
                    'gobjClsAAS203.ReInitInstParameters()
                    blnResetFilterData = True
                Case EnumCalibrationMode.EMISSION
                    gobjClsAAS203.Auto_blank_Emission(False)
                    Application.DoEvents()
                    'Call gobjCommProtocol.funcGetRefBaseVal()
                    blnResetFilterData = True
                    'gobjClsAAS203.ReInitInstParameters()
            End Select
            Application.DoEvents()
            gobjClsAAS203.ReInitInstParameters()

            Application.DoEvents()
            gobjCommProtocol.mobjCommdll.subTime_Delay(100)
            Application.DoEvents()
            '	
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
    '//-----

    Public Function funcReadLampPosition() As Integer
        '=====================================================================
        ' Procedure Name        :   funcReadLampPosition
        ' Description           :   
        ' Purpose               :   to return default lamp position as 0.
        '                           
        ' Parameters Passed     :   None
        ' Returns               :   an integer holding lamp position
        ' Parameters Affected   :   
        ' Assumptions           :   
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale 
        ' Created               :   04.03.07
        ' Revisions             :
        '=====================================================================
        'FILE *fptr = NULL;
        'int lamppos;
        'fptr = fopen("lstlamp.pos","rt");
        'if( fptr ){
        '	fscanf(fptr,"%d",&lamppos);
        '	fclose(fptr);
        '	return lamppos;
        '}
        '        Else
        '	return 1;
        '}
        Try

            Return 0

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return 0
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

#Region " Functions for Double Beam "

    Public Sub subSetInstrumentBeamType(ByVal intInstrumentBeamType As enumInstrumentBeamType, Optional ByVal blnIsWriteToIni As Boolean = True)  ', ByRef blnIsSingleBeam As Boolean)
        '=====================================================================
        ' Procedure Name        : subSetInstrumentBeamType
        ' Parameters Passed     : enumInstrumentBeamType datatype of intInstrumentBeamType for Double or Single Beam
        ' Returns               : None
        ' Purpose               : To set the Instrument Beam Type
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 06-Apr-2007 06:45 pm
        ' Revisions             : 1
        '=====================================================================
        Dim intBeamType As Integer

        Try
            '--- To set the Instrument Beam Type
            Select Case intInstrumentBeamType
                Case enumInstrumentBeamType.SingleBeam
                    intBeamType = 0
                    gintInstrumentBeamType = enumInstrumentBeamType.SingleBeam

                Case enumInstrumentBeamType.ReferenceBeam
                    intBeamType = 1
                    gintInstrumentBeamType = enumInstrumentBeamType.ReferenceBeam

                Case enumInstrumentBeamType.DoubleBeam
                    intBeamType = 2
                    gintInstrumentBeamType = enumInstrumentBeamType.DoubleBeam

            End Select

            If blnIsWriteToIni = True Then
                '---Save the User Selected value of Instrument Beam Type in AAS.ini file
                Call gFuncWriteToINI(SECTION_SYSTEMPARAMETERS, KEY_INSTRUMENT_BEAMTYPE, intBeamType.ToString, INI_SETTINGS_PATH)
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

    Public Function funcSelectDoubleBeamType(ByVal blnIsDoubleBeamType As Boolean) As Boolean
        '=====================================================================
        ' Procedure Name        : funcSelectDoubleBeamType
        ' Parameters Passed     : None
        ' Returns               : True or false
        ' Purpose               : To set the Instrument Beam Type
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 06-Apr-2007 06:45 pm
        ' Revisions             : 1
        '=====================================================================
        'Dim blnIsDoubleBeamType As Boolean
        Dim blnIsAA203DNOTFound As Boolean

        Try
            'blnIsDoubleBeamType = gobjMessageAdapter.ShowMessage("Select Instrument Beam Type." & vbCrLf & "Press YES For Double Beam" & vbCrLf & "Press NO For Single Beam", "Select Beam Type", MessageHandler.clsMessageHandler.enumMessageType.QuestionMessage)
            'Call Application.DoEvents()
            ''---Set Beam Type to Instrument
            If blnIsDoubleBeamType Then
                Call subSetInstrumentBeamType(enumInstrumentBeamType.DoubleBeam)
            Else
                Call subSetInstrumentBeamType(enumInstrumentBeamType.SingleBeam)
            End If

            ''---Set Beam Type to Instrument
            'If Not gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.SELFTEST) Then
            '    blnIsAA203DNOTFound = True
            'Else
            '    blnIsAA203DNOTFound = False
            'End If
            'If blnIsAA203DNOTFound Then
            '    Call gobjMessageAdapter.ShowMessage("The AA 203D (Double Beam Instrument) not found." & vbCrLf & "Application will now exit.", "AAS203D Not Found", MessageHandler.clsMessageHandler.enumMessageType.UnExpectedMessage)
            '    Call Application.DoEvents()
            '    Return False
            'End If

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

    Public Function Calculate_Analysis_Graph_Param(ByRef Curve As AASGraph, ByVal GraphAxis As enumChangeAxis) As Double
        '=====================================================================
        ' Procedure Name        : Calculate_Analysis_Graph_Param
        ' Parameters Passed     : AASGraph Reference
        ' Returns               : Double value
        ' Purpose               : for calculate a graph parameter
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Pankaj Bamb
        ' Created               : 09-May-2007 011:05 am
        ' Revisions             : 1
        '=====================================================================
        Dim FrqIntv As Double = 0.0
        Dim xmax1 As Double = 0
        Dim xmin1 As Double = 0
        Dim Fmin As Double = 0
        Dim Fmax As Double = 0
        Dim Fx As Double = 0
        Dim fn, tot1 As Integer

        Try
            If IsNothing(Curve) Then
                ''if there is nothing curve.
                Return 0.0
            End If

            xmax1 = Curve.YAxisMax
            xmin1 = Curve.YAxisMin
            tot1 = (xmax1 - xmin1) * 60

            FrqIntv = gobjclsStandardGraph.GetInterval(xmax1, xmin1, tot1, True)
            'FrqIntv = 100

            fn = (xmax1 / FrqIntv)
            Fmax = CDbl(fn * FrqIntv)
            If xmax1 > Fmax Then
                Fmax = Fmax + FrqIntv
            End If
            fn = CInt(xmin1 / FrqIntv)
            Fmin = CDbl(fn * FrqIntv)

            If (xmin1 < Fmin) Then
                Fmin = Fmin - FrqIntv
            End If

            If (Fmin > xmin1) And (FrqIntv <> -1.0) Then
                While (Fmin > xmin1)
                    Fmax -= FrqIntv
                End While
            End If

            If (Fmax < xmax1 And FrqIntv <> -1.0) Then
                While (Fmax < xmax1)
                    Fmax += FrqIntv
                End While
            End If

            If (GraphAxis = enumChangeAxis.xyAxis Or GraphAxis = enumChangeAxis.yAxis) Then
                Curve.YAxisMin = Fmin
                Curve.YAxisMax = Fmax
                Curve.YAxisStep = FrqIntv
            End If


            xmax1 = Curve.XAxisMax
            xmin1 = Curve.XAxisMin
            tot1 = 60
            Fx = gobjclsStandardGraph.GetInterval(xmax1, xmin1, tot1, True)

            If (Fx > 0) Then
                fn = xmax1 / Fx
            Else
                fn = 0
            End If

            Fmax = fn * Fx
            If (xmax1 > Fmax) Then
                Fmax += Fx
            End If

            If (GraphAxis = enumChangeAxis.xyAxis Or GraphAxis = enumChangeAxis.xAxis) Then
                Curve.XAxisMin = xmin1
                Curve.XAxisMax = Fmax
                Curve.XAxisStep = gobjclsStandardGraph.GetInterval(Curve.XAxisMax, Curve.XAxisMin, tot1, True)
            End If
            Curve.IsShowGrid = True
            Return FrqIntv

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

    'Public Function Status_Disp_To_Check_Flame() As Boolean
    '    '=====================================================================
    '    ' Procedure Name        : Status_Disp
    '    ' Parameters Passed     : None
    '    ' Returns               : None
    '    ' Purpose               : To set gobjInst.Aaf = False is Flame goes OFF
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Saurabh
    '    ' Created               : 20-June-2007
    '    ' Revisions             : 1
    '    '=====================================================================
    '    Dim line1 As String
    '    Dim status, st, st1 As Byte
    '    Dim flag As Boolean = True

    '    Try
    '        status = gobjCommProtocol.funcGet_Pneum_Status()

    '        If (status And EnumErrorStatus.SFUEL_ON) Then
    '            flag = True
    '            gobjInst.Aaf = True
    '        Else
    '            flag = False
    '            gobjInst.Aaf = False
    '        End If

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
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

    'Public Function LoadMethod_IQOQPQ_Test_Attachment() As Boolean
    '    '=====================================================================
    '    ' Procedure Name        : LoadMethod_IQOQPQ_Test_Attachment
    '    ' Parameters Passed     : None
    '    ' Returns               : None
    '    ' Purpose               : To Load method for IQOQPQ
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Saurabh S
    '    ' Created               : 04.07.07
    '    ' Revisions             : 
    '    '=====================================================================
    '    Dim objWait As New CWaitCursor
    '    Dim objDtMethodNames As New DataTable
    '    Dim intCounter As Integer
    '    Dim objRow As DataRow
    '    Dim objAllMethodsCollection As AAS203Library.Method.clsMethodCollection

    '    Try
    '        '*********************LoadMethods*****************************
    '        If funcLoadAllMethods(objAllMethodsCollection) Then
    '            If Not IsNothing(objAllMethodsCollection) Then
    '                gobjMethodCollection = Nothing
    '                gobjMethodCollection = New clsMethodCollection
    '                For intCounter = 0 To objAllMethodsCollection.Count - 1
    '                    'If objAllMethodsCollection.item(intCounter).InstrumentBeamType = gintInstrumentBeamType Then
    '                    gobjMethodCollection.Add(objAllMethodsCollection.item(intCounter))
    '                    'End If
    '                Next
    '                Return True
    '            Else
    '                Return False
    '            End If
    '        Else
    '            Return False
    '        End If
    '        '*********************LoadMethods*****************************
    '        objDtMethodNames.Columns.Add(ConstColumnMethodID)
    '        objDtMethodNames.Columns.Add(ConstColumnMethodName)

    '        For intCounter = 0 To gobjMethodCollection.Count - 1
    '            objRow = objDtMethodNames.NewRow
    '            objRow.Item(ConstColumnMethodID) = gobjMethodCollection.item(intCounter).MethodID
    '            objRow.Item(ConstColumnMethodName) = gobjMethodCollection.item(intCounter).MethodName
    '            objDtMethodNames.Rows.Add(objRow)
    '        Next
    '        lstMethodName.DataSource = objDtMethodNames
    '        lstMethodName.DisplayMember = ConstColumnMethodName
    '        lstMethodName.ValueMember = ConstColumnMethodID


    '        Call lstMethodName_SelectedIndexChanged(lstMethodName, EventArgs.Empty)

    '        AddHandler lstMethodName.SelectedIndexChanged, AddressOf lstMethodName_SelectedIndexChanged

    '        Call funcLoadElementsList()
    '        '----Added By Pankaj 11 May 07
    '        rbMethodName.Checked = True
    '        rbMethodName_CheckedChanged2(sender, e)

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        If Not objWait Is Nothing Then
    '            objWait.Dispose()
    '        End If
    '        gobjMain.HideProgressBar()
    '        '---------------------------------------------------------
    '    End Try

    'End Function

    Public Function CheckValidInstConditions(ByVal objMethod_Instrument_Conditions As clsInstrumentParameters) As Boolean
        '=====================================================================
        ' Procedure Name        : CheckValidInstConditions
        ' Parameters Passed     : None
        ' Returns               : True or False
        ' Purpose               : To validation Instrument parameters
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 01.08.07
        ' Revisions             : praveen
        '=====================================================================
        'BOOL CheckValidInstConditions(HWND hwnd,AAINST *temp)
        Try
            '{
            '   char buf[200]="";
            '   if(!strcmpi(temp->elName,""))
            '       {
            '           if(MessageBox(hwnd,"ELEMENT NAME IS BLANK\nDo you want to save the report?","WARNING",MB_ICONQUESTION | MB_YESNO) == IDNO)
            '	        return FALSE;
            '       }
            'Dim buf() As String
            If Not (objMethod_Instrument_Conditions.ElementName = "") Then
                'check for element name
                If gobjMessageAdapter.ShowMessage("ELEMENT NAME IS BLANK. Do you want to save the report?", "WARNING", MessageHandler.clsMessageHandler.enumMessageType.QuestionMessage) = False Then
                    Return False
                Else
                    Return True
                End If
            End If
            '//if( temp->Inst_Mode >= 1 &&
            '   if(GetInstrument() == AA202){
            '  if(temp->TurNo < 1 || temp->TurNo > 2){
            '	 sprintf(buf,"LAMP NUMBER %d IS INVALID\nDo you want to save the report?",(int)temp->TurNo);
            '	 if(MessageBox(hwnd,buf,"WARNING",MB_ICONQUESTION | MB_YESNO) == IDNO)
            '		return FALSE;
            '	}
            '}
            'else{
            '	if(temp->TurNo < 1 || temp->TurNo > 6){
            '	  sprintf(buf,"TURRET NUMBER %d IS INVALID\nDo you want to save the report?",(int)temp->TurNo);
            '	  if(MessageBox(hwnd,buf,"WARNING",MB_ICONQUESTION | MB_YESNO) == IDNO)
            '		return FALSE;
            '	}
            '}
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                'checking a turrert num as per 201
                If objMethod_Instrument_Conditions.TurretNumber < 1 Or objMethod_Instrument_Conditions.TurretNumber > 2 Then
                    If gobjMessageAdapter.ShowMessage("LAMP NUMBER " & objMethod_Instrument_Conditions.TurretNumber & " IS INVALID." & vbCrLf & "Do you want to save the report?", "WARNING", MessageHandler.clsMessageHandler.enumMessageType.QuestionMessage) = False Then
                        Return False
                    Else
                        Return True
                    End If
                End If
            Else
                If objMethod_Instrument_Conditions.TurretNumber < 1 Or objMethod_Instrument_Conditions.TurretNumber > 6 Then
                    'checking a turrert num as per other
                    If gobjMessageAdapter.ShowMessage("LAMP NUMBER " & objMethod_Instrument_Conditions.TurretNumber & " IS INVALID." & vbCrLf & "Do you want to save the report?", "WARNING", MessageHandler.clsMessageHandler.enumMessageType.QuestionMessage) = False Then
                        Return False
                    Else
                        Return True
                    End If
                End If
            End If
            'if( temp->Cur <= 0.0 || temp->Cur > 25.0 ){
            '	sprintf(buf,"LAMP CURRENT IS %0.2f mA\nDo you want to save the report?",(float)temp->Cur);
            '	if(MessageBox(hwnd,buf,"WARNING",MB_ICONQUESTION | MB_YESNO) == IDNO)
            '		return FALSE;
            '}
            If objMethod_Instrument_Conditions.LampCurrent <= 0.0 Or objMethod_Instrument_Conditions.LampCurrent > 25.0 Then
                ''check for lamp current bet 0 to 25.
                If gobjMessageAdapter.ShowMessage("LAMP CURRENT IS " & gobjInst.Current & "mA. " & vbCrLf & "Do you want to save the report?", "WARNING", MessageHandler.clsMessageHandler.enumMessageType.QuestionMessage) = False Then
                    Return False
                Else
                    Return True
                End If
            End If
            'if( temp->Wv <= 0.0 ){
            '  if(MessageBox(hwnd,"WAVELENGTH IS 0.0 nm\nDo you want to save the report?","WARNING",MB_ICONQUESTION | MB_YESNO) == IDNO)
            '	  return FALSE;
            '}
            If gobjInst.WavelengthCur <= 0.0 Then
                ''check for wavelength
                If gobjMessageAdapter.ShowMessage("WAVELENGTH IS 0.0 nm. " & vbCrLf & "Do you want to save the report?", "WARNING", MessageHandler.clsMessageHandler.enumMessageType.QuestionMessage) = False Then
                    Return False
                Else
                    Return True
                End If
            End If
            'if( temp->Slit <= 0.0 || temp->Slit > 2.0 ){
            '  sprintf(buf,"SLIT IS %0.2f nm\nDo you want to save the report?",(float)temp->Slit);
            '  if(MessageBox(hwnd,buf,"WARNING",MB_ICONQUESTION | MB_YESNO) == IDNO)
            '	  return FALSE;
            '}
            If objMethod_Instrument_Conditions.SlitWidth <= 0.0 Or objMethod_Instrument_Conditions.SlitWidth > 2.0 Then
                ''check for slit width bet 0.0 to 2.0
                If gobjMessageAdapter.ShowMessage("SLIT IS " & objMethod_Instrument_Conditions.SlitWidth & "nm. " & vbCrLf & "Do you want to save the report?", "WARNING", MessageHandler.clsMessageHandler.enumMessageType.QuestionMessage) = False Then
                    Return False
                Else
                    Return True
                End If
            End If
            'if( temp->D2cur < 100.0 || temp->D2cur >= 300.0 ){
            '  sprintf(buf,"PMT VOLTAGE IS %0.2f V\nDo you want to save the report?",(float)temp->Pmtv);
            '  if(MessageBox(hwnd,buf,"WARNING",MB_ICONQUESTION | MB_YESNO) == IDNO)
            '	  return FALSE;
            '}
            If objMethod_Instrument_Conditions.D2Current < 100.0 Or objMethod_Instrument_Conditions.D2Current >= 300.0 Then
                ''check for D2 current.
                Return True  'added by ; dinesh wagh on 29.1.2010
                'code commented by ;dinesh wagh on 29.1.2010
                '-------------------------------------------
                ''If gobjMessageAdapter.ShowMessage("PMT VOLTAGE IS " & objMethod_Instrument_Conditions.PmtVoltage & "V. " & vbCrLf & "Do you want to save the report?", "WARNING", MessageHandler.clsMessageHandler.enumMessageType.QuestionMessage) = False Then
                ''    Return False
                ''Else
                ''    Return True
                ''End If
                '-------------------------------------------
            End If
            'if( temp->Pmtv <= 0.0 || temp->Pmtv > 1000.0 ){
            '  sprintf(buf,"PMT VOLTAGE IS %0.2f V\nDo you want to save the report?",(float)temp->Pmtv);
            '  if(MessageBox(hwnd,buf,"WARNING",MB_ICONQUESTION | MB_YESNO) == IDNO)
            '	  return FALSE;
            '}
            If objMethod_Instrument_Conditions.PmtVoltage <= 0.0 Or objMethod_Instrument_Conditions.PmtVoltage > 1000.0 Then
                ''check for PMT voltage
                If gobjMessageAdapter.ShowMessage("PMT VOLTAGE IS " & objMethod_Instrument_Conditions.PmtVoltage & "V" & vbCrLf & "Do you want to save the report?", "WARNING", MessageHandler.clsMessageHandler.enumMessageType.QuestionMessage) = False Then
                    Return False
                Else
                    Return True
                End If
            End If
            'return TRUE;
            Return True
            '}

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
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcExitWindows() As Boolean
        '=====================================================================
        ' Procedure Name        : funcExitWindows
        ' Parameters Passed     : None
        ' Returns               : True or False
        ' Purpose               : To exit from windows
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 19.08.07
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this is called whenexit from window.
        Try
            SendMessage(HWND_BROADCAST, WM_COMMAND, 51, 0L)
            SendMessage(HWND_BROADCAST, WM_DESTROY, 0L, 0L)

            ExitWindows(0, 0)
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

End Class

