Option Explicit On 
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic

Public Class clsHardwareLock_USB
    '=====================================================================
    ' Module Name           :   clsHardwareLock
    ' Author                :   Sachin Ashtankar
    ' Created               :   25 August 2005
    ' Revisions             :   1
    '=====================================================================
    '---Note :
    '---Three memory locations of hardware lock i.e. Index 1=Month,2=Day and 3=Year are used for 
    '---storing installation DateTime. These memory locations should not be overriden 
    '---by some other value.

#Region "DLL's"

    <DllImport("sentrydll5.dll")> Private Shared Function win_xread_nt95( _
          ByRef rbuff As Int16, ByRef pass As Byte) As Integer                    'Long
    End Function

    <DllImport("sentrydll5.dll")> Private Shared Function win_xwrite_nt95( _
        ByRef rbuff As Int16, ByRef wbuff As Int16, ByRef pass As Byte) As Integer       'Long
    End Function

    <DllImport("sentrydll5.dll")> Private Shared Function win_read_rtctime_nt95( _
        ByRef rbuff As Int16, ByRef op As Byte) As Integer
    End Function

    <DllImport("sentrydll5.dll")> Private Shared Function win_set_rtctime_nt95( _
            ByRef rbuff As Int16, ByRef time As Byte) As Integer
    End Function

    <DllImport("sentrydll5.dll")> Private Shared Function win_write_val_nt95( _
            ByRef keybuff As Int16, ByVal index1 As Integer, ByVal value1 As Integer) As Integer
    End Function

    <DllImport("sentrydll5.dll")> Private Shared Function win_read_val_nt95( _
        ByRef keybuff As Int16, ByVal index1 As Integer) As Integer
    End Function

#End Region

#Region "Constructor"
    Public Sub New()
        Try
            Dim i As Integer = 0

            For i = 0 To 11
                rbuff(i) = 0
            Next i

            'Fill rbuff with your  key (refer keyxxxx.txt)
            rbuff(0) = 21334
            rbuff(1) = 13910
            rbuff(2) = 17232
            rbuff(3) = 18477
            rbuff(4) = 22097
            rbuff(5) = 14645
            rbuff(6) = 11600
            rbuff(7) = 13622
            rbuff(8) = 19274
            rbuff(9) = 13874
            rbuff(10) = 8224
            rbuff(11) = 8224

            ' Fill pass array with your password, which should be hex, refer keyxxxx.txt
            pass(0) = 78
            pass(1) = 80
            pass(2) = 67
            pass(3) = 72


        Catch ex As Exception
            MsgBox("ERROR : In Initialization " & ex.Message)
        End Try

    End Sub
#End Region

#Region "Private Variables"
    Private rbuff(11) As Int16
    Private pass(3) As Byte
#End Region

#Region "Public Functions"

    Public Function WriteHardwareKey(ByVal strKey As String) As Integer
        Dim int16Signature(11) As Int16
        Dim int32TempSignature As Int32
        Dim temp As Int32
        Dim stat As Integer
        Dim strTemp(20) As Byte
        Dim strString As String
        Dim strSignature(23) As String
        Dim chrKey(23) As Char

        Dim i As Integer
        Dim intCounter As Integer
        Try
            For intCounter = 0 To 23
                chrKey(intCounter) = strKey.Chars(intCounter)
            Next

            For intCounter = 0 To 23 Step 2
                strSignature(intCounter / 2) = "&H" & Hex(Asc(chrKey(intCounter))) & Hex(Asc(chrKey(intCounter + 1)))
                int32TempSignature = CType(strSignature(intCounter / 2), Int32)

                If int32TempSignature > 32767 Then
                    int16Signature(intCounter / 2) = int32TempSignature - 65536
                Else
                    int16Signature(intCounter / 2) = int32TempSignature
                End If
            Next



            stat = win_xwrite_nt95(rbuff(0), int16Signature(0), pass(0))
            Select Case stat
                Case 0
                    '            Text5.Text = "Lock Found! Data written Successfully, the one assigned to Signature varibale!!!"
                    gobjMessageAdapter.ShowMessage("Lock Found! Key set successfully!!!", "Hardware Lock Check", EnumMessageType.Information)
                    Return 1
                Case -1
                    ' Text5.Text = "Sentry Hardware Lock NOT installed OR the one installed is not bearing proper identity"
                    gobjMessageAdapter.ShowMessage("Hardware lock not installed OR " & vbCrLf & " The installed one is not having proper identity", "Hardware Lock Error", EnumMessageType.Information)
                    Return stat
                Case -2
                    'Text5.Text = "The Password you have issued is not matching with the one assigned for the Lock attached !"
                    gobjMessageAdapter.ShowMessage("The Password you have issued is not matching with the one assigned for the Lock attached !", "Hardware Lock Error", EnumMessageType.Information)
                    Return stat
                Case -3
                    'Text5.Text = "Sentrymsp.vxd is not found in the current path  "
                    gobjMessageAdapter.ShowMessage("Sentrymsp.vxd is not found in the current path  ", "Hardware Lock Error", EnumMessageType.Information)
                    Return stat
                Case -5
                    'Text5.Text = "Sentry.sys is not started or not installed on the Win NT/2000 machine!"
                    gobjMessageAdapter.ShowMessage("Sentry.sys is not started or not installed on the Win NT/2000 machine!", "Hardware Lock Error", EnumMessageType.Information)
                    Return stat
                Case -6
                    'Text5.Text = " Sentry.sys could not close its operations on the Win NT/2000 machine!"
                    gobjMessageAdapter.ShowMessage(" Sentry.sys could not close its operations on the Win NT/2000 machine!", "Hardware Lock Error", EnumMessageType.Information)
                    Return stat
                Case -7
                    'Text5.Text = " The memory location index entered is out of range (0-29)!"
                    gobjMessageAdapter.ShowMessage(" The memory location index entered is out of range (0-29)!", "Hardware Lock Error", EnumMessageType.Information)
                    Return stat
                Case -8
                    'Text5.Text = " The Sentrymsp.vxd or sentry.sys found belongs to earlier  version, Update with the latest !"
                    gobjMessageAdapter.ShowMessage(" The Sentrymsp.vxd or sentry.sys found belongs to earlier  version, Update with the latest !", "Hardware Lock Error", EnumMessageType.Information)
                    Return stat
                Case -9
                    'Text5.Text = " Cannot work on Win3.1!"
                    gobjMessageAdapter.ShowMessage(" Cannot work on Win3.1!", "Hardware Lock Error", EnumMessageType.Information)
                    Return stat
                Case -10
                    'Text5.Text = " The KEY passed with this function is not made for the lock attached to the machine !"
                    gobjMessageAdapter.ShowMessage(" The KEY passed with this function is not made for the lock attached to the machine !", "Hardware Lock Error", EnumMessageType.Information)
                    Return stat
                Case Else
                    If stat < 0 Then
                        Return stat
                    End If
            End Select
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
            Return 0
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function ReadHardwareKey(ByVal strKey As String) As Integer
        Dim int16Signature(11) As Int16
        Dim int32TempSignature As Int32
        Dim temp As Int32
        Dim stat As Integer   'eger 'Long
        Dim strTemp(20) As Byte
        Dim strString As String
        Dim strSignature(23) As String

        Dim chrKey(23) As Char

        Dim Brbuff(11) As Int16
        Dim i As Integer
        Dim intCounter As Integer
        Try
            For intCounter = 0 To 23
                chrKey(intCounter) = strKey.Chars(intCounter)
            Next

            For intCounter = 0 To 23 Step 2
                strSignature(intCounter / 2) = "&H" & Hex(Asc(chrKey(intCounter))) & Hex(Asc(chrKey(intCounter + 1)))
                int32TempSignature = CType(strSignature(intCounter / 2), Int32)

                If int32TempSignature > 32767 Then
                    int16Signature(intCounter / 2) = int32TempSignature - 65536
                Else
                    int16Signature(intCounter / 2) = int32TempSignature
                End If
            Next


            For i = 0 To 11
                Brbuff(i) = 0
            Next i

            'Fill rbuff with your  key (refer keyxxxx.txt)
            Brbuff(0) = 21334
            Brbuff(1) = 13910
            Brbuff(2) = 17232
            Brbuff(3) = 18477
            Brbuff(4) = 22097
            Brbuff(5) = 14645
            Brbuff(6) = 11600
            Brbuff(7) = 13622
            Brbuff(8) = 19274
            Brbuff(9) = 13874
            Brbuff(10) = 8224
            Brbuff(11) = 8224

            stat = win_xread_nt95(Brbuff(0), pass(0))

            Select Case stat
                Case 0

                    For i = 0 To 11
                        If (Brbuff(i) <> int16Signature(i)) Then
                            i = 0
                            Exit For
                        End If
                    Next i
                    If (i < 11) Then
                        gobjMessageAdapter.ShowMessage("Lock Found! Data read from the lock is not matching with the one assigned to hardware key!", "Hardware Lock Error", EnumMessageType.Information)
                        Return 0
                    Else
                        ' gFuncShowMessage("Hardware Lock", "Lock Found! Data Read from the lock is matching with the one assigned to Signature varibale!!!", modConstants.EnumMessageType.Information)
                        Return 1
                    End If

                Case -1
                    ' Text5.Text = "Sentry Hardware Lock NOT installed OR the one installed is not bearing proper identity"
                    gobjMessageAdapter.ShowMessage("Hardware Lock not installed OR the installed one is not bearing proper identity", "Hardware Lock Error", EnumMessageType.Information)
                    Return stat
                Case -2
                    'Text5.Text = "The Password you have issued is not matching with the one assigned for the Lock attached !"
                    'gFuncShowMessage("Hardware Lock Error", "The Password you have issued is not matching with the one assigned for the Lock attached !", modConstants.EnumMessageType.Information)
                    Return stat
                Case -3
                    'Text5.Text = "Sentrymsp.vxd is not found in the current path  "
                    'gFuncShowMessage("Hardware Lock Error", "Sentrymsp.vxd is not found in the current path  ", modConstants.EnumMessageType.Information)
                    Return stat
                Case -5
                    'Text5.Text = "Sentry.sys is not started or not installed on the Win NT/2000 machine!"
                    'gFuncShowMessage("Hardware Lock Error", "Sentry.sys is not started or not installed on the Win NT/2000 machine!", modConstants.EnumMessageType.Information)
                    Return stat
                Case -6
                    'Text5.Text = " Sentry.sys could not close its operations on the Win NT/2000 machine!"
                    'gFuncShowMessage("Hardware Lock Error", " Sentry.sys could not close its operations on the Win NT/2000 machine!", modConstants.EnumMessageType.Information)
                    Return stat
                Case -7
                    'Text5.Text = " The memory location index entered is out of range (0-29)!"
                    'gFuncShowMessage("Hardware Lock Error", " The memory location index entered is out of range (0-29)!", modConstants.EnumMessageType.Information)
                    Return stat
                Case -8
                    'Text5.Text = " The Sentrymsp.vxd or sentry.sys found belongs to earlier  version, Update with the latest !"
                    'gFuncShowMessage("Hardware Lock Error", " The Sentrymsp.vxd or sentry.sys found belongs to earlier  version, Update with the latest !", modConstants.EnumMessageType.Information)
                    Return stat
                Case -9
                    'Text5.Text = " Cannot work on Win3.1!"
                    'gFuncShowMessage("Hardware Lock Error", " Cannot work on Win3.1!", modConstants.EnumMessageType.Information)
                    Return stat
                Case -10
                    'Text5.Text = " The KEY passed with this function is not made for the lock attached to the machine !"
                    'gFuncShowMessage("Hardware Lock Error", " The KEY passed with this function is not made for the lock attached to the machine !", modConstants.EnumMessageType.Information)
                    Return stat
                Case Else
                    If stat < 0 Then
                        Return stat
                    End If
            End Select
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            'gobjErrorHandler.ErrorDescription = ex.Message
            'gobjErrorHandler.ErrorMessage = ex.Message
            'gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
            Return 0
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            'If CONST_CREATE_EXECUTION_LOG = 1 Then
            '    gobjErrorHandler.WriteExecutionLog()
            'End If
            '---------------------------------------------------------
        End Try

    End Function

    Public Function GetRTCDateTime(ByRef RTCDateTime As DateTime) As Integer
        'Public Function GetRTCDateTime() As DateTime
        Dim time(8) As Byte
        Dim stat As Integer   'eger 'Long
        Dim i As Integer
        Dim intCounter As Integer
        Try
            stat = win_read_rtctime_nt95(rbuff(0), time(0))
            Select Case stat
                Case 0
                    Dim dtRTCDate As System.DateTime
                    dtRTCDate = New System.DateTime(CInt("200" & CStr(time(6))), CInt(CStr(time(4))), CInt(CStr(time(3))), CInt(CStr(time(2))), CInt(CStr(time(1))), CInt(CStr(time(0))))
                    RTCDateTime = dtRTCDate
                    Return 1
                Case -1
                    ' Text5.Text = "Sentry Hardware Lock NOT installed OR the one installed is not bearing proper identity"
                    'gFuncShowMessage("Hardware Lock Error", "Hardware Lock not installed OR the installed one is not bearing proper identity", modConstants.EnumMessageType.Information)
                    Return stat
                Case -2
                    'Text5.Text = "The Password you have issued is not matching with the one assigned for the Lock attached !"
                    'gFuncShowMessage("Hardware Lock Error", "The Password you have issued is not matching with the one assigned for the Lock attached !", modConstants.EnumMessageType.Information)
                    Return stat
                Case -3
                    'Text5.Text = "Sentrymsp.vxd is not found in the current path  "
                    'gFuncShowMessage("Hardware Lock Error", "Sentrymsp.vxd is not found in the current path  ", modConstants.EnumMessageType.Information)
                    Return stat
                Case -5
                    'Text5.Text = "Sentry.sys is not started or not installed on the Win NT/2000 machine!"
                    'gFuncShowMessage("Hardware Lock Error", "Sentry.sys is not started or not installed on the Win NT/2000 machine!", modConstants.EnumMessageType.Information)
                    Return stat
                Case -6
                    'Text5.Text = " Sentry.sys could not close its operations on the Win NT/2000 machine!"
                    'gFuncShowMessage("Hardware Lock Error", " Sentry.sys could not close its operations on the Win NT/2000 machine!", modConstants.EnumMessageType.Information)
                    Return stat
                Case -7
                    'Text5.Text = " The memory location index entered is out of range (0-29)!"
                    'gFuncShowMessage("Hardware Lock Error", " The memory location index entered is out of range (0-29)!", modConstants.EnumMessageType.Information)
                    Return stat
                Case -8
                    'Text5.Text = " The Sentrymsp.vxd or sentry.sys found belongs to earlier  version, Update with the latest !"
                    'gFuncShowMessage("Hardware Lock Error", " The Sentrymsp.vxd or sentry.sys found belongs to earlier  version, Update with the latest !", modConstants.EnumMessageType.Information)
                    Return stat
                Case -9
                    'Text5.Text = " Cannot work on Win3.1!"
                    'gFuncShowMessage("Hardware Lock Error", " Cannot work on Win3.1!", modConstants.EnumMessageType.Information)
                    Return stat
                Case -10
                    'Text5.Text = " The KEY passed with this function is not made for the lock attached to the machine !"
                    'gFuncShowMessage("Hardware Lock Error", " The KEY passed with this function is not made for the lock attached to the machine !", modConstants.EnumMessageType.Information)
                    Return stat
                Case Else
                    If stat < 0 Then
                        Return stat
                    End If

            End Select
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            'gobjErrorHandler.ErrorDescription = ex.Message
            'gobjErrorHandler.ErrorMessage = ex.Message
            'gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
            Return 0
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            'If CONST_CREATE_EXECUTION_LOG = 1 Then
            '    gobjErrorHandler.WriteExecutionLog()
            'End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function SetRTCDateTime(ByVal RTCDateTime As DateTime) As Integer
        Dim time(8) As Byte
        Dim stat As Integer   'eger 'Long
        Try
            Dim strYear As String

            strYear = RTCDateTime.Year.ToString

            time(0) = RTCDateTime.Second '&H22 'Seconds
            time(1) = RTCDateTime.Minute  '&H2 'minutes
            time(2) = RTCDateTime.Hour ' &H1  'hours
            time(3) = RTCDateTime.Day '&HA 'Date of  month     hex 11 means 17 decimal
            time(4) = RTCDateTime.Month '&H2 'Month of year
            time(5) = RTCDateTime.DayOfWeek  '&H6 'Day of Week
            time(6) = CInt(Microsoft.VisualBasic.Mid(strYear, 3)) '&H3  'Year
            time(7) = 0


            stat = win_set_rtctime_nt95(rbuff(0), time(0))
            Select Case stat
                Case 0
                    Return 1

                Case -1
                    ' Text5.Text = "Sentry Hardware Lock NOT installed OR the one installed is not bearing proper identity"
                    'gFuncShowMessage("Hardware Lock Error", "Hardware Lock not installed OR the installed one is not bearing proper identity", modConstants.EnumMessageType.Information)
                    Return stat
                Case -2
                    'Text5.Text = "The Password you have issued is not matching with the one assigned for the Lock attached !"
                    'gFuncShowMessage("Hardware Lock Error", "The Password you have issued is not matching with the one assigned for the Lock attached !", modConstants.EnumMessageType.Information)
                    Return stat
                Case -3
                    'Text5.Text = "Sentrymsp.vxd is not found in the current path  "
                    'gFuncShowMessage("Hardware Lock Error", "Sentrymsp.vxd is not found in the current path  ", modConstants.EnumMessageType.Information)
                    Return stat
                Case -5
                    'Text5.Text = "Sentry.sys is not started or not installed on the Win NT/2000 machine!"
                    'gFuncShowMessage("Hardware Lock Error", "Sentry.sys is not started or not installed on the Win NT/2000 machine!", modConstants.EnumMessageType.Information)
                    Return stat
                Case -6
                    'Text5.Text = " Sentry.sys could not close its operations on the Win NT/2000 machine!"
                    'gFuncShowMessage("Hardware Lock Error", " Sentry.sys could not close its operations on the Win NT/2000 machine!", modConstants.EnumMessageType.Information)
                    Return stat
                Case -7
                    'Text5.Text = " The memory location index entered is out of range (0-29)!"
                    'gFuncShowMessage("Hardware Lock Error", " The memory location index entered is out of range (0-29)!", modConstants.EnumMessageType.Information)
                    Return stat
                Case -8
                    'Text5.Text = " The Sentrymsp.vxd or sentry.sys found belongs to earlier  version, Update with the latest !"
                    'gFuncShowMessage("Hardware Lock Error", " The Sentrymsp.vxd or sentry.sys found belongs to earlier  version, Update with the latest !", modConstants.EnumMessageType.Information)Return stat
                    Return stat
                Case -9
                    'Text5.Text = " Cannot work on Win3.1!"
                    'gFuncShowMessage("Hardware Lock Error", " Cannot work on Win3.1!", modConstants.EnumMessageType.Information)
                    Return stat
                Case -10
                    'Text5.Text = " The KEY passed with this function is not made for the lock attached to the machine !"
                    'gFuncShowMessage("Hardware Lock Error", " The KEY passed with this function is not made for the lock attached to the machine !", modConstants.EnumMessageType.Information)
                    Return stat
                Case Else
                    If stat < 0 Then
                        Return stat
                    End If
            End Select
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            'gobjErrorHandler.ErrorDescription = ex.Message
            'gobjErrorHandler.ErrorMessage = ex.Message
            'gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
            Return 0
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            'If CONST_CREATE_EXECUTION_LOG = 1 Then
            '    gobjErrorHandler.WriteExecutionLog()
            'End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function SetValue(ByVal intIndex As Integer, ByVal intValue As Integer) As Boolean
        Dim stat As Integer   'eger 'Long
        Try
            stat = win_write_val_nt95(rbuff(0), intIndex, intValue)
            If stat >= 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            'gobjErrorHandler.ErrorDescription = ex.Message
            'gobjErrorHandler.ErrorMessage = ex.Message
            'gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            'If CONST_CREATE_EXECUTION_LOG = 1 Then
            '    gobjErrorHandler.WriteExecutionLog()
            'End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function GetValue(ByVal intIndex As Integer) As Integer
        Dim stat As Integer   'eger 'Long
        Try
            stat = win_read_val_nt95(rbuff(0), intIndex)
            Return stat
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            'gobjErrorHandler.ErrorDescription = ex.Message
            'gobjErrorHandler.ErrorMessage = ex.Message
            'gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            'If CONST_CREATE_EXECUTION_LOG = 1 Then
            '    gobjErrorHandler.WriteExecutionLog()
            'End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function WriteCurrentDateTime() As Boolean
        '---Note :
        '---Three memory locations of hardware lock i.e. Index 1,2 and 3 are used for 
        '---storing installation DateTime. 
        '---This function writes the current DateTime in Real Time Clock of Hardware Lock and 
        '---in above three memory  locations.
        Try
            Dim CurrentDate As New DateTime
            Dim blnSet As Boolean = False
            CurrentDate = System.DateTime.Now()
            If SetRTCDateTime(CurrentDate) > 0 Then
                '---Set same date into following mem locations
                '--- Memory Location 1 = Month of CurrentDate
                blnSet = SetValue(1, CurrentDate.Month)
                If blnSet = True Then
                    '--- Memory Location 2 = Day of CurrentDate
                    blnSet = SetValue(2, CurrentDate.Day)
                    If blnSet = True Then
                        '--- Memory Location 3 = Year of CurrentDate
                        blnSet = SetValue(3, CurrentDate.Year)
                        Return blnSet
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
            Return False
        Finally

        End Try
    End Function

    Public Function GetMemoryDate() As DateTime
        '//--- return the Memorise date, Stored into hardware lock. 
        Try
            Dim intDay As Integer = 0
            Dim intMonth As Integer = 0
            Dim intYear As Integer = 0

            '---Getting month part
            intMonth = GetValue(1)
            If intMonth > 0 Then
                '---Getting day part
                intDay = GetValue(2)
                If intDay > 0 Then
                    '---Getting year part
                    intYear = GetValue(3)
                    Return New DateTime(intYear, intMonth, intDay)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        Finally

        End Try
    End Function

    Public Function GetDifference(ByRef RTCTimeDifference As Integer) As Boolean
        '//----- Modified by Sachin Dokhale

        '--- This function Calculate the difference between the installation Date And
        '--- Current Real time Clock Date in no. of days.
        Try
            Dim MemoryDate As New DateTime
            Dim RTCDate As New DateTime
            Dim intGetRTCStatus As Integer

            '---Installation Date
            MemoryDate = GetMemoryDate()
            '---Real Time Date
            'RTCDate = GetRTCDateTime()
            intGetRTCStatus = GetRTCDateTime(RTCDate)

            'Return RTCDate.Subtract(MemoryDate).Days
            If intGetRTCStatus > 0 Then
                RTCTimeDifference = RTCDate.Subtract(MemoryDate).Days
                Return True
            Else
                Return False
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally

        End Try
    End Function
#End Region

End Class
