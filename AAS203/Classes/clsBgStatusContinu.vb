Imports BgThread
Imports AAS203.Common

Public Class clsBgFlameStatus
    Implements BgThread.IBgWorker

#Region " Private Variable"
    Private mobjThreadController As IBgThread
    Private mblnStatusWait As Boolean
    'Private mblnStatusEnable As Boolean
    Private mblnThreadTerminate As Boolean


    Dim mlblObjStatus As System.Object
#End Region

#Region " Public Properties "

    Public Property blnPropStatusWait() As Boolean
        Get
            blnPropStatusWait = mblnStatusWait
        End Get
        Set(ByVal Value As Boolean)
            mblnStatusWait = Value
        End Set
    End Property

    'Public Property blnPropStatusEnable() As Boolean
    '    Get
    '        StatusEnable = mblnStatusEnable
    '    End Get
    '    Set(ByVal Value As Boolean)
    '        mblnStatusEnable = Value
    '    End Set
    'End Property

    Public Property blnPropThreadTerminate() As Boolean
        Get
            blnPropThreadTerminate = mblnThreadTerminate
        End Get
        Set(ByVal Value As Boolean)
            mblnThreadTerminate = Value
        End Set
    End Property

#End Region

#Region " Constructors "

    Public Sub New()
        MyBase.New()
        blnPropStatusWait = False
        blnPropThreadTerminate = False
        Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
    End Sub

#End Region

#Region " Public Functions "

    Public Sub Initialize(ByVal Controller As BgThread.IBgThread) Implements BgThread.IBgWorker.Initialize
        Try
            mobjThreadController = Controller
            ' mblnStatusWait = False
            ' mblnThreadTerminate = False
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

    Public Sub Start() Implements BgThread.IBgWorker.Start
        '=====================================================================
        ' Procedure Name        : Start
        ' Parameters Passed     : None
        ' Returns               : BgThread.IBgWorker.Start
        ' Purpose               : to start the process
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale 
        ' Created               : 19.03.07
        ' Revisions             : 
        '=====================================================================
        Dim blnCancel As Boolean = False

        Try
            If mobjThreadController.Running Then
                If blnPropThreadTerminate = False Then
                    If funcDisplayFlame() = True Then
                    Else
                    End If
                End If
            Else
                'Client requested a cancel
                mobjThreadController.Completed(True)
                Exit Sub
            End If

            mobjThreadController.Completed(True)

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
            blnPropThreadTerminate = False
            '---------------------------------------------------------
        End Try
    End Sub

    'Public Sub TerminateThread()
    '    '=====================================================================
    '    ' Procedure Name        : TerminateThread
    '    ' Parameters Passed     : None
    '    ' Returns               : None
    '    ' Purpose               : to terminate the process
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Sachin Dokhale 
    '    ' Created               : 19.03.07
    '    ' Revisions             : 
    '    '=====================================================================
    '    Try

    '        Do While True '(blnCancel = False)
    '            If mobjThreadController.Running Then
    '                blnPropThreadTerminate = True
    '            Else
    '                'Client requested a cancel
    '                mobjThreadController.Completed(False)
    '                Exit Sub
    '            End If
    '            'gobjCommProtocol.mobjCommdll.subTime_Delay(100)
    '            Application.DoEvents()
    '        Loop

    '        'If mobjThreadController.Running = True Then
    '        '    mobjThreadController.Completed(True)
    '        'Else
    '        '    mobjThreadController.Completed(False)
    '        'End If

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        mobjThreadController.Failed(ex)
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

#End Region

#Region " Private Functions "

    Private Function funcDisplayFlame() As Boolean
        '=====================================================================
        ' Procedure Name        : funcDisplayFlame
        ' Parameters Passed     : None
        ' Returns               : Boolean
        ' Purpose               : to Display Flame status
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale 
        ' Created               : 19.03.07
        ' Revisions             : 
        '=====================================================================
        Dim mintIgniteType As Integer
        Dim blnReturnValue As Boolean

        Try
            If gstructSettings.AppMode = EnumAppMode.FullVersion Then
                blnReturnValue = True

                Do While (blnPropThreadTerminate = False)
                    If mobjThreadController.Running Then
                        If blnPropStatusWait = False Then
                            If gblnInComm = False Then
                                mintIgniteType = gobjClsAAS203.funcIgnite_Test()
                                mobjThreadController.Display(mintIgniteType)
                            End If
                        End If
                        Application.DoEvents()
                    Else
                        blnPropThreadTerminate = True
                        Exit Do
                    End If
                    'Call gobjCommProtocol.mobjCommdll.subTime_Delay(1000)
                    Threading.Thread.Sleep(1000)
                    Application.DoEvents()
                Loop
            End If

            Return True

        Catch threadex As Threading.ThreadAbortException

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            mobjThreadController.Failed(ex)
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
