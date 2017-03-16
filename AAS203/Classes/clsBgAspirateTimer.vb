Imports System
Imports BgThread

Namespace AspirateMessage

    Friend Class clsBgAspirateTimer
        Implements BgThread.IBgWorker

#Region " Constructors "

        Public Sub New()
            MyBase.New()

        End Sub

        Public Sub New(ByRef lblSt1 As Object)
            '=====================================================================
            ' Procedure Name        : New
            ' Parameters Passed     : lblSt1 as form object
            ' Returns               : 
            ' Purpose               : New [Constuctor]
            ' Description           : 
            ' Assumptions           : 
            ' Dependencies          : 
            ' Author                : Sachin Dokhale
            ' Created               : 29.11.06
            ' Revisions             : 
            '=====================================================================
            MyBase.New()

            Try

                mlblStatus1 = lblSt1

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

        Private mlblStatus1 As Object

        Private mintAspirationTimerCounter As Integer
        Private mblnIsBlinkMessage As Boolean = True
        Private mstrAspirationMessage As String
        Private mIsThreadStared As Boolean = False

#End Region

#Region " Public Property "

        Public Property AspirationMessage() As String
            Get
                Return mstrAspirationMessage
            End Get
            Set(ByVal Value As String)
                mstrAspirationMessage = Value
            End Set
        End Property

        Public Property IsBlinkMessage() As Boolean
            Get
                Return mblnIsBlinkMessage
            End Get
            Set(ByVal Value As Boolean)
                mblnIsBlinkMessage = Value
            End Set
        End Property
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
            ' Author                : Sachin Dokhale
            ' Created               : 
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
            ' Parameters Passed     : None
            ' Returns               : IBgWorker.Start
            ' Purpose               : To Start the worker thread
            ' Description           : 
            ' Assumptions           : 
            ' Dependencies          : 
            ' Author                : Sachin Dokhale
            ' Created               : 29.11.06
            ' Revisions             : 
            '=====================================================================

            Try
                '//----- Added by Sachin Dokhale on 25.03.07
                '//----- To know the Status of Thread on Status Bar of MDI Main
                'Dim strPreviousStatusMessage As String
                'If gblnShowThreadOnfrmMDIStatusBar Then
                '    strPreviousStatusMessage = gobjMain.StatusBar1.Text
                '    gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage & " *Turret Opti"
                '    Application.DoEvents()
                'End If
                '//-----
                Application.DoEvents()
                'If mIsThreadStared = True Then
                '    Exit Sub
                'End If
                mIsThreadStared = True
                If mobjThreadController.Running Then
                    'SyncLock Me
                    If funcThreadAspirateMsg(mlblStatus1) = True Then
                        'mobjThreadController.Completed(True)
                        mIsThreadStared = False
                    End If
                    'End SyncLock
                Else
                    'mobjThreadController.Completed(False)
                    '//----- Added by Sachin Dokhale on 25.03.07
                    Application.DoEvents()
                    mIsThreadStared = False
                    Exit Sub
                End If
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

        Private Function funcThreadAspirateMsg(ByRef lblStatus1 As Object) As Boolean
            '------------------------------------------------------------------
            'Procedure Name         :   funcThreadTurret_Optimise
            'Description            :   To optimise Turret position 
            'Parameters             :   dblLampCurrent,intLampPos 
            'Return                 :   True if success
            'Time/Date              :   8/11/06
            'Dependencies           :   
            'Author                 :   Deepak B.
            'Revision               :
            'Revision by Person     :   15.12.06
            '--------------------------------------------------------------------------------------
            'Saruabh 06-06-2007 added parameter lblWvStatus
            'Return gobjCommProtocol.funcTurret_Optimise(dblLampCurrent, intLampPos, lblStatus1, lblStatus2, lblStatus3, ObjGraph, ObjThreadController)

            Try
                ' Application.DoEvents()
                Do While (True)
                    Application.DoEvents()
                    If mobjThreadController.Running = False Then
                        Exit Do
                        Application.DoEvents()
                    End If
                    gobjCommProtocol.mobjCommdll.subTime_Delay(500)
                    Application.DoEvents()
                    mintAspirationTimerCounter += 1
                    If (mintAspirationTimerCounter > 1000) Then
                        mintAspirationTimerCounter = 1
                    End If

                    If (mintAspirationTimerCounter Mod 3 = 0) Then
                        If mblnIsBlinkMessage Then
                            Call ShowAspirationMessages(False, lblStatus1)
                        Else
                            Call ShowAspirationMessages(True, lblStatus1)
                        End If
                        'Application.DoEvents()
                    Else
                        Call ShowAspirationMessages(True, lblStatus1)
                        'Application.DoEvents()
                    End If
                    Application.DoEvents()
                Loop
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






        Private Sub ShowAspirationMessages(ByVal blnIsShow As Boolean, ByRef lblStatus1 As Object)
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False 'Manoj
            '=====================================================================
            ' Procedure Name        : ShowAspirationMessages
            ' Parameters Passed     : Flag to Set or Clear the Message.
            ' Returns               : None
            ' Purpose               : 
            ' Description           : 
            ' Assumptions           : 
            ' Dependencies          : 
            ' Author                : Mangesh Shardul
            ' Created               : 17-Jan-2007 03:25 pm
            ' Revisions             : 1
            '=====================================================================
            'void	ShowAspMessage(BOOL	flag)
            '{
            '   char str[128]="";
            '   int t=0;
            '   if (flag)
            '   {
            '       GetDlgItemText(Mhwnd, IDC_TASP, str, 120);
            '	    ltrim(trim(str));
            '	    t = Ignite_Test();
            '	    if( (Method->Mode != MODE_UVABS && !GetHydrideModeStatus()) && (t == GREEN || t == RED) )  // mdf by sss for showing the flame error message
            '       {
            '		    SetDlgItemText(Mhwnd, IDC_TASP, "  Flame is OFF  ");
            '	    }
            '   	else
            '       {
            '   		if (strcmpi(str,Aspiratemsg)!=0)
            '		     SetDlgItemText(Mhwnd, IDC_TASP, Aspiratemsg);
            '	    }
            '   }
            '   Else
            '       SetDlgItemText(Mhwnd, IDC_TASP, "");
            '}

            '****************************************************************
            '---CODE BY MANGESH
            '****************************************************************
            Dim intIgniteType As ClsAAS203.enumIgniteType
            Dim strAspMessage As String
            Dim strTest As String
            Try
                'Application.DoEvents()
                If (blnIsShow) Then
                    strAspMessage = Trim(lblStatus1.Text)

                    If gstructSettings.AppMode = EnumAppMode.DemoMode Then
                        'intIgniteType = ClsAAS203.enumIgniteType.Blue
                    Else
                        'intIgniteType = gobjClsAAS203.funcIgnite_Test()
                    End If

                    'If ((gobjNewMethod.OperationMode <> EnumOperationMode.MODE_UVABS And Not gobjInst.Hydride) _
                    '    And (intIgniteType = ClsAAS203.enumIgniteType.Green Or intIgniteType = ClsAAS203.enumIgniteType.Red)) Then
                    'intIgniteType = gobjMain.IgniteType

                    'code added by : dinesh wagh on 9.2.2010
                    'Purpose : if gobjNewMethod is nothing then throws exception.
                    '---------------------------------
                    If gobjNewMethod Is Nothing Then
                        Exit Sub
                    End If
                    '-----------------------------------

                    If ((gobjNewMethod.OperationMode <> EnumOperationMode.MODE_UVABS And Not gobjInst.Hydride) _
                        And (gobjMain.IgniteType = ClsAAS203.enumIgniteType.Green Or gobjMain.IgniteType = ClsAAS203.enumIgniteType.Red)) Then

                        'for showing the flame error message
                        lblStatus1.Text = "  Flame is OFF  "
                    Else
                        If String.Compare(strAspMessage, AspirationMessage) <> 0 Then
                            lblStatus1.Text = AspirationMessage
                            'lblStatus1.Invoke(New Action(lblStatus1.Text = AspirationMessage))



                            strTest = AspirationMessage.TrimStart().Substring(0, 8)
                            If String.Compare(strTest, "Aspirate") = 0 Then
                                FuncAlert()
                            End If
                            'lblStatus1.Refresh()
                        End If
                    End If

                Else
                    lblStatus1.Text = ""
                    'lblStatus1.Refresh()
                End If
                'Application.DoEvents()
                'If btnReadData.Enabled Then
                '    btnReadData.Focus()
                '    btnReadData.Refresh()
                'End If
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
                Application.DoEvents()
                '---------------------------------------------------------
            End Try
        End Sub

        Private Function FuncAlert()
            Select Case gintAspirationType
                Case 1
                    BlankAlert()
                Case 2
                    StandardAlert()
                Case 3
                    SampleAlert()
            End Select
        End Function

#End Region

    End Class

    Public Class clsMassageController
        Inherits System.Windows.Forms.Form
        Implements BgThread.Iclient

#Region " Private Variables "
        Private lblAspirationMessage As Object
        Private mMsgController As clsBgThread
        Private mobjBgMsgAspirate As clsBgAspirateTimer
        Private mblnIsBlinkMessage As Boolean
        Private mstrAspirationMessage As String
        Private mblnIsMessageRunning As Boolean = False
#End Region

#Region " Constructors "

        Public Sub New()
            MyBase.New()

        End Sub

        Public Sub New(ByRef lblSt1 As Object)
            '=====================================================================
            ' Procedure Name        : New
            ' Parameters Passed     : lblSt1,lblSt2,lblSt3,dblLampCurrent ,intLampPos,objGraph
            ' Returns               : 
            ' Purpose               : To put the IGNITE ON or OFF.
            ' Description           : 
            ' Assumptions           : 
            ' Dependencies          : 
            ' Author                : Sachin Dokhale
            ' Created               : 29.11.06
            ' Revisions             : 
            '=====================================================================
            MyBase.New()

            Try

                lblAspirationMessage = lblSt1
                mMsgController = New clsBgThread(Me)
                mobjBgMsgAspirate = New clsBgAspirateTimer(lblAspirationMessage)
                mobjBgMsgAspirate.Initialize(mMsgController)
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


#Region " Public Property "

        Public Property AspirationMessage() As String
            Get
                Return mstrAspirationMessage
            End Get
            Set(ByVal Value As String)
                mstrAspirationMessage = Value
                mobjBgMsgAspirate.AspirationMessage = Value
            End Set
        End Property

        Public Property IsBlinkMessage() As Boolean
            Get
                Return mblnIsBlinkMessage
            End Get
            Set(ByVal Value As Boolean)
                mblnIsBlinkMessage = Value
                mobjBgMsgAspirate.IsBlinkMessage = Value
            End Set
        End Property

        Public Property IsMessageRunning() As Boolean
            Get
                Return mblnIsMessageRunning
            End Get
            Set(ByVal Value As Boolean)
                mblnIsMessageRunning = Value
            End Set
        End Property
#End Region

#Region " Public Functions"
        Public Function Cancel()
            Try
                mMsgController.Cancel()
                IsMessageRunning = False
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
        Public Function Start()
            Try

                mMsgController.Cancel()
                mblnIsMessageRunning = True
                mMsgController.Start(mobjBgMsgAspirate)
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

        Public Sub Completed(ByVal Cancelled As Boolean) Implements BgThread.Iclient.Completed
            IsMessageRunning = False
        End Sub

        Public Sub Display(ByVal Text As String) Implements BgThread.Iclient.Display

        End Sub

        Public Sub Failed(ByVal e As System.Exception) Implements BgThread.Iclient.Failed
            IsMessageRunning = False
        End Sub

        Private Sub Start1(ByVal clsBgThread As BgThread.clsBgThread) Implements BgThread.Iclient.Start

        End Sub

    End Class
End Namespace
