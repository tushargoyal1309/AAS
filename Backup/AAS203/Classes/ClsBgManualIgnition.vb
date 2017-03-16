Option Strict Off
Imports BgThread
Imports AAS203.Common

Public Class ClsBgManualIgnition
    Implements BgThread.IBgWorker

#Region " Private Variables "
    Private mblnIgnitionWait As Boolean = False
    Private mblnThTerminate As Boolean = False
    Dim mblnEndProcess As Boolean = False
    Private mobjThreadController As IBgThread
#End Region

#Region " Public Property "

    Public Property ThTerminate() As Boolean
        ''this is public property for setting a terminating a thread 
        Get
            Return mblnThTerminate
        End Get
        Set(ByVal Value As Boolean)
            mblnThTerminate = Value
            mblnIgnitionWait = Value
        End Set
    End Property

    Public Property IgnitionWait() As Boolean
        ''flag for Ignition wait.
        Get
            Return mblnIgnitionWait
        End Get
        Set(ByVal Value As Boolean)
            mblnIgnitionWait = Value
        End Set
    End Property

#End Region

#Region " Public Events "

    Public Event ManualIgnition(ByRef IsContinue As Boolean)

#End Region

#Region " Constructors "

    Public Sub New()
        MyBase.New()
        ThTerminate = False
        mblnIgnitionWait = False
    End Sub

#End Region

#Region " Public Functions "

    Public Sub Initialize(ByVal Controller As BgThread.IBgThread) Implements BgThread.IBgWorker.Initialize
        '=====================================================================
        ' Procedure Name        : Initialize
        ' Parameters Passed     : Controller As BgThread.IBgThread
        ' Returns               : None
        ' Purpose               : To Initialize the worker thread
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 26-Dec-2006
        ' Revisions             : 1
        '=====================================================================
        mobjThreadController = Controller
    End Sub

    Public Sub StartWorkerThread() Implements BgThread.IBgWorker.Start
        '=====================================================================
        ' Procedure Name        : StartWorkerThread
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : to Start the thread
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale 
        ' Created               : 19.03.07
        ' Revisions             : 
        '=====================================================================
        Dim blnCancel As Boolean = False
        Dim objwait As New CWaitCursor
        Try
            mblnEndProcess = True
            Do While (blnCancel = False)
                If mobjThreadController.Running Then
                    '---check  thread is either running or not. 
                    If mblnThTerminate = True Then
                        ''---this is a flag for terminating a thread.
                        blnCancel = True
                    Else
                        If mblnIgnitionWait = False Then
                            RaiseEvent ManualIgnition(Not (blnCancel))
                            '--call a event for manual ignition
                        End If
                    End If
                Else
                    '---Client requested a cancel
                    blnCancel = True
                    Exit Do
                End If
            Loop
            blnCancel = True
            If mobjThreadController.Running = True Then
                mobjThreadController.Completed(True)
                '---complete the thread.
            End If

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

End Class
