
Public Class clsTimer
    Implements IConfirmable

#Region " Private Class Member Variables "

    Private intInterval As Integer
    Private mblnOtherEvent As Boolean
    Private mblnTimerCompleted As Boolean
    Private mblnTimerStop As Boolean
    Private tmr_AutoZero As System.Timers.Timer
    Private stbrStatus As System.Object

    '--- Constant used for the index of the status bar panel
    '--- to display current date and time.
    Private Const CONST_CURR_DATE_TIME = 2

#End Region

#Region " Constructors "

    Public Sub New(ByRef objStatusBar As System.Object, ByVal intTimerIntervalMiliSecond As Integer)
        '----------------------------------------------------------------------------
        'Procedure Name	    :   New
        'Description	    :   TO start and instanciate the object
        'Parameters 	    :   label and timer interval
        'Time/Date  	    :   21/01/05
        'Dependencies	    :   
        'Author		        :   M.Kamal
        'Revision		    :  
        'Revision by Person	: 
        '----------------------------------------------------------------------------
        Try
            intInterval = 1000
            mblnOtherEvent = False
            mblnTimerCompleted = True
            mblnTimerStop = False
            tmr_AutoZero = New System.Timers.Timer(intInterval)

            stbrStatus = objStatusBar

            '--- Display current date and time
            Call subDisplayCurrDateTime()

            AddHandler tmr_AutoZero.Elapsed, AddressOf tmr_AutoZero_Elasped

            If intTimerIntervalMiliSecond > 0 Then
                intInterval = intTimerIntervalMiliSecond
            End If
            tmr_AutoZero.Start()

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        End Try
    End Sub

#End Region

#Region " Private functions "

    Private Sub subDisplayCurrDateTime()
        '--- Procedure to display the current date and time
        '--- on the screen

        Try
            'check if form objects passed is nothing, if so exit timer application 
            If IsNothing(stbrStatus) Then
                Exit Sub
            Else
                If IsNothing(stbrStatus.Panels) Then
                    Exit Sub
                End If
            End If

            'stbrStatus.Panels.Item(CONST_CURR_DATE_TIME).Text = Format(Now, "dd-MMM-yyyy").ToString & ", " & FormatDateTime(Now, DateFormat.LongTime).ToString
            If stbrStatus.Panels.count > 0 Then
                If (stbrStatus.Panels.count - 1) >= CONST_CURR_DATE_TIME Then
                    stbrStatus.Panels.Item(CONST_CURR_DATE_TIME).Text = Format(Now, "dd-MMM-yyyy").ToString & ", " & FormatDateTime(Now, DateFormat.LongTime).ToString
                End If
            End If
            '----------------------------

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        End Try
    End Sub

    Private Property TimerInterval() As Integer
        Get
            Return intInterval
        End Get
        Set(ByVal Value As Integer)
            intInterval = Value
        End Set
    End Property

#End Region

#Region " Continuous Communication Timer "

    Private Sub tmr_AutoZero_Elasped(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs)
        '---------------------------------------------------------------------------
        'Procedure Name	    :   tmr_AutoZero_Elasped
        'Description	    :   To get the Current time
        'Parameters 	    :   
        'Time/Date  	    :   21/01/05
        'Dependencies	    :   
        'Author		        :   M.Kamal
        'Revision		    :   
        'Revision by Person	: 
        '---------------------------------------------------------------------------
        Dim intAdc As Integer
        Dim dblCompensatedAdcValue As Double
        Dim dblADCValue As Double

        Try
            'check if form objects passed is nothing, if so exit timer application 
            If stbrStatus Is Nothing Then
                If tmr_AutoZero.Enabled = True Then
                    'tmr_AutoZero.Stop()
                End If
                'tmr_AutoZero.Stop()
                mblnTimerCompleted = True
                Exit Sub
            End If
            'tmr_AutoZero.Stop()
            '--- 2. Explicitly called to start other event
            If mblnOtherEvent = True Then
                'If tmr_AutoZero.Enabled = True Then
                '    tmr_AutoZero.Stop()
                'End If
                'tmr_AutoZero.Stop()
                mblnTimerCompleted = True
                Exit Sub
            End If

            '--- 1. If timer is still running and second timer instance calls again 
            If mblnTimerCompleted = False Then
                Exit Sub
            End If

            mblnTimerCompleted = False

            '--- Display current date and time
            Call subDisplayCurrDateTime()

            '--- call the interface to set the variable
            Call Confirm()

            mblnTimerCompleted = True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        End Try

    End Sub

    Public Sub subTimerStop()
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name	    :   subTimerStop
        'Description	    :   To stop the clock
        'Parameters 	    :   
        'Time/Date  	    :   21/01/05
        'Dependencies	    :   
        'Author		        :   M.Kamal
        'Revision		    :
        'Revision by Person	:
        '--------------------------------------------------------------------------------------
        Dim lngTimer1 As Long, lngTimer2 As Long

        Try
            Application.DoEvents()
            mblnOtherEvent = True
            lngTimer1 = System.DateTime.Now.Ticks / 10000
            Do Until mblnTimerCompleted = True 'Or mblnTimerStop = True
                '--- check for the time interval if greater than 500 mseconds then exit
                Application.DoEvents()
                lngTimer2 = System.DateTime.Now.Ticks / 10000

                If ((lngTimer2 - lngTimer1) > 60000) Or mblnTimerCompleted = True Then
                    Exit Do
                End If
                Application.DoEvents()
            Loop
            Application.DoEvents()
            tmr_AutoZero.Stop()
            tmr_AutoZero.Enabled = False
            Application.DoEvents()
            tmr_AutoZero.Enabled = False

        Catch ex As Exception
            '---------------------------------------------------------
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        End Try
    End Sub

    Public Sub subTimerStart(ByRef objStatusBar As System.Object)
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name	    :   subTimerStart
        'Description	    :   Start the Timer routine again
        'Parameters 	    :   None 
        'Time/Date  	    :   21/01/05
        'Dependencies	    :   
        'Author		        :   M.kamal
        'Revision		    :
        'Revision by Person	:
        '--------------------------------------------------------------------------------------
        Try
            mblnOtherEvent = False
            'mblnTimerStop = False

            '------ modified by Rahul B. 29/03/06------
            '------ On main screen actual time wont get updated. object of status
            '------ bar gets destroyed somewhere so reinitialise object of status 
            '------ bar with main screen status bar.
            If Not objStatusBar Is Nothing Then
                stbrStatus = objStatusBar
                '------ modified by Rahul B. 29/03/06------
                If tmr_AutoZero.Enabled = False Then
                    mblnTimerStop = False
                    tmr_AutoZero.Interval = intInterval
                    tmr_AutoZero.Start()
                End If
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        End Try

    End Sub

#End Region
#Region " Public property "
    Public ReadOnly Property TimerStatus() As Boolean
        Get
            If Not tmr_AutoZero Is Nothing Then
                Return tmr_AutoZero.Enabled
            End If
        End Get

    End Property


#End Region
#Region " Public functions "

    Public Sub Confirm() Implements IConfirmable.Confirm
        '--- Interface object 
        Try
            mblnTimerCompleted = True
            Application.DoEvents()
            '----------------------------

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        End Try

    End Sub

    Public Sub subTime_Delay(ByVal lngTimeInMSeconds As Long)
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name:    subTime_Delay
        'Description:       To generate delay between two successive REad or Write Oerations
        'Parameters :       Time in MiliSeconds, ConstManipulate = 10000 to get time in milliseconds
        'Time/Date  :       3.33 13 oct 2003
        'Dependencies:      Its all depend On God ... if he supplies ticks, delay works else we have manipulated it to make it work
        'Author:            Mandar
        'Revision:
        'Revision by Person:Santosh
        '--------------------------------------------------------------------------------------
        Dim lngTimeDelay As Long
        Dim lng As Long
        Dim lng1 As Long
        Dim intCount As Int16
        Dim ConstManipulate As Long = 10000 ' this will manipulate tick count for each mili second

        'Note: Ticks are being calculated at the interval of 100 nano seconds hence calculated the factor to be devided as 10000

        Try
            lngTimeDelay = CLng(System.DateTime.Now.Ticks) / ConstManipulate
            lngTimeInMSeconds = lngTimeDelay + lngTimeInMSeconds

            Do While lngTimeDelay < lngTimeInMSeconds
                '--- This loop will execute until the delay condition gets satisfied
                'For intCount = 1 To 100
                'intCount = intCount + 1
                'Next
                Application.DoEvents()
                lngTimeDelay = CLng(System.DateTime.Now.Ticks) / ConstManipulate
                'lng1 = lngTimeInMSeconds - GetTickCount()
                Application.DoEvents()
            Loop
            'added and commented by kamal on 19March2004
            '----------------------------
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

Public Interface IConfirmable
    Sub Confirm()
End Interface
