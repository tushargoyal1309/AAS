Imports BgThread
Imports AAS203.Common

Public Class clsBgFlameStatus
    Implements BgThread.IBgWorker

#Region " Private Variable "

    Private mobjThreadController As IBgThread
    '---object ot thread class

#End Region

#Region " Constructors "

    Public Sub New()
        MyBase.New()
        Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
        '---communication delay
    End Sub

#End Region

#Region " Public Functions "

    Public Sub Initialize(ByVal Controller As BgThread.IBgThread) Implements BgThread.IBgWorker.Initialize
        '=====================================================================
        ' Procedure Name        : Initialize
        ' Parameters Passed     : Controller as BgThread.IBgThread
        ' Returns               : None
        ' Purpose               : To Initialize the worker thread
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 26-Dec-2006
        ' Revisions             : 1
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
        Dim strPreviousStatusMessage As String
        Try
            '--- Added by Sachin Dokhale on 25.03.07
            '--- To know the Status of Thread on Status Bar of MDI Main
            If gblnShowThreadOnfrmMDIStatusBar Then
                strPreviousStatusMessage = gobjMain.StatusBarPanelInfo.Text
                gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage & " *Flame Status"
            End If
            '---
            If Not (gobjfrmStatus Is Nothing) Then
                gobjfrmStatus.TopMost = True
            End If
            '---To display flame status
            Call funcDisplayFlame()

            '--- Added by Sachin Dokhale on 25.03.07
            '--- To remove the Status of Thread on Status Bar of MDI Main
            If gblnShowThreadOnfrmMDIStatusBar Then
                gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage
                Application.DoEvents()
                ''---allow application to perfrom its panding work.
            End If
            '---

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
        Try
            If gstructSettings.AppMode = EnumAppMode.FullVersion_203 _
               Or gstructSettings.AppMode = EnumAppMode.FullVersion_203D _
               Or gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                '---check a application mode.
                Do While (True)
                    If Not mobjThreadController.Running Then
                        '---Client requested a cancel
                        mobjThreadController.Completed(True)
                        Exit Do
                    End If

                    'If gblnInCommProcess = False and = Then
                    If clsRS232Main.IsInCommu = False Then
                        'Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
                        If gintCommPortSelected > 0 Then
                            Application.DoEvents()
                            '---to check flame type 

                            'mintIgniteType = gobjClsAAS203.funcIgnite_Test()
                            Dim intIgnite_Test As ClsAAS203.enumIgniteType
                            If gobjClsAAS203.funcIgnite_Test(intIgnite_Test) Then
                                mintIgniteType = intIgnite_Test
                            End If
                            '---
                            If Not mobjThreadController.Running Then
                                '---Client requested a cancel
                                mobjThreadController.Completed(True)
                                Exit Do
                            End If
                            If gblnIsInstReset = True Then
                                Call gobjCommProtocol.mobjCommdll.subTime_Delay(30)
                                'If gobjCommProtocol.mobjCommdll.gFuncResumeProcess = True Then   '10.12.07
                                Application.DoEvents()
                                If Not mobjThreadController.Running Then
                                    '---Client requested a cancel
                                    mobjThreadController.Completed(True)
                                    Exit Do
                                End If
                                gobjClsAAS203.ReInitInstParameters()
                                'End If
                                'gobjClsAAS203.ReInitInstParameters()
                            End If

                            '---display flame type
                            mobjThreadController.Display(mintIgniteType)
                            Application.DoEvents()
                            '--- Added by Sachin Dokhale on 07.01.08
                            'If gblnIsInstReset = True Then
                            '    gobjClsAAS203.ReInitInstParameters()
                            'End If
                        Else
                            'No Communication (No comm port is selected)
                            mobjThreadController.Completed(True)
                            Exit Do
                        End If
                    End If

                    If Not mobjThreadController.Running Then
                        '---Client requested a cancel
                        mobjThreadController.Completed(True)
                        Exit Do
                    End If
                    If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                        Call gobjCommProtocol.mobjCommdll.subTime_Delay(500)
                    Else
                        Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
                    End If
                    '---communication delay
                    Application.DoEvents()
                    '---allow application to perfrom its panding work.
                Loop
            End If

            ''---16.03.08
            'If gstructSettings.AppMode = EnumAppMode.DemoMode _
            '   Or gstructSettings.AppMode = EnumAppMode.DemoMode_201 _
            '   Or gstructSettings.AppMode = EnumAppMode.DemoMode_203D Then
            '    '---check a application mode.
            '    Do While (True)
            '        If Not mobjThreadController.Running Then
            '            '---Client requested a cancel
            '            mobjThreadController.Completed(True)
            '            Exit Do
            '        End If

            '        If clsRS232Main.IsInCommu = False Then
            '            If gintCommPortSelected > 0 Then
            '                Application.DoEvents()
            '                '---display flame type
            '                mobjThreadController.Display(6)
            '                Application.DoEvents()
            '            Else
            '                'No Communication (No comm port is selected)
            '                mobjThreadController.Completed(True)
            '                Exit Do
            '            End If
            '        End If

            '        If Not mobjThreadController.Running Then
            '            '---Client requested a cancel
            '            mobjThreadController.Completed(True)
            '            Exit Do
            '        End If

            '        Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
            '        '---communication delay
            '        Application.DoEvents()
            '        '---allow application to perfrom its panding work.
            '    Loop
            'End If
            ''---16.03.08

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
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function
#End Region

End Class
