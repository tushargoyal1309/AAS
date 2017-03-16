Imports BgThread
Imports AAS203.Common
Imports AAS203Library.Instrument

Public Class clsBgTurretOptimization
    Implements BgThread.IBgWorker

#Region " Constructors "

    Public Sub New()
        MyBase.New()

    End Sub

    Public Sub New(ByRef lblSt1 As Object, ByRef lblSt2 As Object, ByRef lblSt3 As Object, ByVal dblLampCurrent As Double, ByVal intLampPos As Integer, Optional ByRef objGraph As Object = Nothing, Optional ByRef lblWvStatus As Label = Nothing)
        '=====================================================================
        ' Procedure Name        : New
        ' Parameters Passed     : lblSt1,lblSt2,lblSt3,dblLampCurrent ,intLampPos,objGraph
        ' Returns               : 
        ' Purpose               : 
        ' Description           : To set the references of passed variables to module
        '                         level variables
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak B.
        ' Created               : 29.11.06
        ' Revisions             : 
        '=====================================================================
        MyBase.New()

        Try
            mdblLampCurrent = dblLampCurrent
            mintLampPosition = intLampPos
            mlblStatus1 = lblSt1
            mlblStatus2 = lblSt2
            mlblStatus3 = lblSt3
            mObjGraph = objGraph
            mlblWvStatus = lblWvStatus

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

    Private mobjThreadController As IBgThread
    Private mdblLampCurrent As Double
    Private mintLampPosition As Integer
    Private mlblStatus1, mlblStatus2, mlblStatus3 As Object
    Private mlblWvStatus As Label
    Private mObjGraph As Object

#End Region

#Region " Public Functions "

    Public Sub Initialize(ByVal Controller As BgThread.IBgThread) Implements BgThread.IBgWorker.Initialize
        '=====================================================================
        ' Procedure Name        : Initialize
        ' Parameters Passed     : Controller
        ' Returns               : 
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
        ' Parameters Passed     : 
        ' Returns               : 
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
            '--- Added by Sachin Dokhale on 25.03.07
            '--- To know the Status of Thread on Status Bar of MDI Main
            Dim strPreviousStatusMessage As String
            If gblnShowThreadOnfrmMDIStatusBar Then
                strPreviousStatusMessage = gobjMain.StatusBar1.Text
                gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage & " *Turret Opti"
                Application.DoEvents()
            End If
            '---
            If mobjThreadController.Running Then
                '---optimise turret
                If funcThreadTurret_Optimise(mdblLampCurrent, mintLampPosition, mlblStatus1, mlblStatus2, mlblStatus3, mObjGraph, mobjThreadController, mlblWvStatus) = True Then
                    mobjThreadController.Completed(True)
                End If
            Else
                mobjThreadController.Completed(True)
                '--- Added by Sachin Dokhale on 25.03.07
                '--- To remove the Status of Thread on Status Bar of MDI Main
                If gblnShowThreadOnfrmMDIStatusBar Then
                    gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage
                End If
                '---
                Application.DoEvents()
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

    Private Function funcThreadTurret_Optimise(ByVal dblLampCurrent As Double, ByVal intLampPos As Integer, Optional ByRef lblStatus1 As Object = Nothing, Optional ByRef lblStatus2 As Object = Nothing, Optional ByRef lblStatus3 As Object = Nothing, Optional ByRef ObjGraph As Object = Nothing, Optional ByVal ObjThreadController As Object = Nothing, Optional ByRef lblWvStatus As Label = Nothing) As Boolean
        '------------------------------------------------------------------
        'Procedure Name         :   funcThreadTurret_Optimise
        'Description            :   To optimise Turret position 
        'Parameters             :   dblLampCurrent,intLampPos, ObjThreadController as thread Control
        'Parameters affected    :   lblStatus,lblStatus1,lblStatus2,lblStatus3 as label object
        '                       :   ObjGraph   
        'Return                 :   True if success
        'Time/Date              :   8/11/06
        'Dependencies           :   Serial Communication
        'Author                 :   Deepak B.
        'Revision               :
        'Revision by Person     :   15.12.06
        '--------------------------------------------------------------------------------------
        Try
            '---Saruabh 06-06-2007 added parameter lblWvStatus
            'Return gobjCommProtocol.funcTurret_Optimise(dblLampCurrent, intLampPos, lblStatus1, lblStatus2, lblStatus3, ObjGraph, ObjThreadController)
            Return gobjCommProtocol.funcTurret_Optimise(dblLampCurrent, intLampPos, lblStatus1, lblStatus2, lblStatus3, ObjGraph, ObjThreadController, lblWvStatus)

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
