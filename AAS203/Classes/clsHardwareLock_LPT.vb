Option Explicit On 
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic
Public Class clsHardwareLock_LPT

#Region "DLL's"
    <DllImport("sentrydll5.dll")> Private Shared Function win_xread_nt95( _
          ByRef rbuff As Int16, ByRef pass As Byte) As Integer                'Long
    End Function
    <DllImport("sentrydll5.dll")> Private Shared Function win_xwrite_nt95( _
        ByRef rbuff As Int16, ByRef wbuff As Int16, ByRef pass As Byte) As Integer       'Long
    End Function
#End Region

#Region "Public Functions"

    Public Function WriteHardwareKey(ByVal strKey As String) As Boolean
        Dim rbuff(11) As Int16
        Dim int16Signature(11) As Int16
        Dim int32TempSignature As Int32

        Dim temp As Int32
        Dim pass(3) As Byte
        Dim stat As Integer
        Dim strTemp(20) As Byte
        Dim strString As String
        Dim strSignature(23) As String

        Dim chrKey(23) As Char

        Dim i As Integer
        Dim intCounter As Integer

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

        pass(0) = 78
        pass(1) = 80
        pass(2) = 67
        pass(3) = 72

        For i = 0 To 11
            rbuff(i) = 0
        Next i

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

        stat = win_xwrite_nt95(rbuff(0), int16Signature(0), pass(0))
        Select Case stat
            Case 0
                '            Text5.Text = "Lock Found! Data written Successfully, the one assigned to Signature varibale!!!"
                gobjMessageAdapter.ShowMessage("Lock Found! Key set successfully!!!", "Hardware Lock Check", EnumMessageType.Information)
                Return True
            Case -1
                ' Text5.Text = "Sentry Hardware Lock NOT installed OR the one installed is not bearing proper identity"
                'gFuncShowMessage("Hardware Lock Error", "Hardware lock not installed OR " & vbCrLf & " The installed one is not having proper identity", modConstants.EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage("Hardware lock not installed OR " & vbCrLf & " The installed one is not having proper identity", "Hardware Lock Error", EnumMessageType.Information)
                Return False
            Case -2
                'Text5.Text = "The Password you have issued is not matching with the one assigned for the Lock attached !"
                'gFuncShowMessage("Hardware Lock Error", "The Password you have issued is not matching with the one assigned for the Lock attached !", modConstants.EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage("The Password you have issued is not matching with the one assigned for the Lock attached !", "Hardware Lock Error", EnumMessageType.Information)
                Return False
            Case -3
                'Text5.Text = "Sentrymsp.vxd is not found in the current path  "
                'gFuncShowMessage("Hardware Lock Error", "Sentrymsp.vxd is not found in the current path  ", modConstants.EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage("Sentrymsp.vxd is not found in the current path  ", "Hardware Lock Error", EnumMessageType.Information)
                Return False
            Case -5
                'Text5.Text = "Sentry.sys is not started or not installed on the Win NT/2000 machine!"
                'gFuncShowMessage("Hardware Lock Error", "Sentry.sys is not started or not installed on the Win NT/2000 machine!", modConstants.EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage("Sentry.sys is not started or not installed on the Win NT/2000 machine!", "Hardware Lock Error", EnumMessageType.Information)
                Return False
            Case -6
                'Text5.Text = " Sentry.sys could not close its operations on the Win NT/2000 machine!"
                'gFuncShowMessage("Hardware Lock Error", " Sentry.sys could not close its operations on the Win NT/2000 machine!", modConstants.EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage(" Sentry.sys could not close its operations on the Win NT/2000 machine!", "Hardware Lock Error", EnumMessageType.Information)
                Return False
            Case -7
                'Text5.Text = " The memory location index entered is out of range (0-29)!"
                'gFuncShowMessage("Hardware Lock Error", " The memory location index entered is out of range (0-29)!", modConstants.EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage(" The memory location index entered is out of range (0-29)!", "Hardware Lock Error", EnumMessageType.Information)
                Return False
            Case -8
                'Text5.Text = " The Sentrymsp.vxd or sentry.sys found belongs to earlier  version, Update with the latest !"
                'gFuncShowMessage("Hardware Lock Error", " The Sentrymsp.vxd or sentry.sys found belongs to earlier  version, Update with the latest !", modConstants.EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage(" The Sentrymsp.vxd or sentry.sys found belongs to earlier  version, Update with the latest !", "Hardware Lock Error", EnumMessageType.Information)
                Return False
            Case -9
                'Text5.Text = " Cannot work on Win3.1!"
                'gFuncShowMessage("Hardware Lock Error", " Cannot work on Win3.1!", modConstants.EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage(" Cannot work on Win3.1!", "Hardware Lock Error", EnumMessageType.Information)
                Return False
            Case -10
                'Text5.Text = " The KEY passed with this function is not made for the lock attached to the machine !"
                'gFuncShowMessage("Hardware Lock Error", " The KEY passed with this function is not made for the lock attached to the machine !", modConstants.EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage(" The KEY passed with this function is not made for the lock attached to the machine !", "Hardware Lock Error", EnumMessageType.Information)
                Return False
        End Select

    End Function

    Public Function ReadHardwareKey(ByVal strKey As String) As Boolean
        Dim rbuff(11) As Int16
        Dim int16Signature(11) As Int16
        Dim int32TempSignature As Int32

        Dim temp As Int32
        Dim pass(3) As Byte
        Dim stat As Integer   'eger 'Long
        Dim strTemp(20) As Byte
        Dim strString As String
        Dim strSignature(23) As String

        Dim chrKey(23) As Char

        Dim i As Integer
        Dim intCounter As Integer

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

        ' Fill pass array with your password, which should be hex, refer keyxxxx.txt

        pass(0) = 78
        pass(1) = 80
        pass(2) = 67
        pass(3) = 72

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

        stat = win_xread_nt95(rbuff(0), pass(0))

        Select Case stat
            Case 0

                For i = 0 To 11
                    If (rbuff(i) <> int16Signature(i)) Then
                        i = 0
                        Exit For
                    End If
                Next i
                If (i < 11) Then
                    'gFuncShowMessage("Hardware Lock Error", "Lock Found! Data read from the lock is not matching with the one assigned to hardware key!", modConstants.EnumMessageType.Information)
                    gobjMessageAdapter.ShowMessage("Lock Found! Data read from the lock is not matching with the one assigned to hardware key!", "Hardware Lock Error", EnumMessageType.Information)
                    Return False
                Else
                    ' gFuncShowMessage("Hardware Lock", "Lock Found! Data Read from the lock is matching with the one assigned to Signature varibale!!!", modConstants.EnumMessageType.Information)
                    Return True
                End If

            Case -1
                ' Text5.Text = "Sentry Hardware Lock NOT installed OR the one installed is not bearing proper identity"
                'gFuncShowMessage("Hardware Lock Error", "Hardware Lock not installed OR the installed one is not bearing proper identity", modConstants.EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage("Hardware Lock not installed OR the installed one is not bearing proper identity", "Hardware Lock Error", EnumMessageType.Information)
                Return False
            Case -2
                'Text5.Text = "The Password you have issued is not matching with the one assigned for the Lock attached !"
                'gFuncShowMessage("Hardware Lock Error", "The Password you have issued is not matching with the one assigned for the Lock attached !", modConstants.EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage("The Password you have issued is not matching with the one assigned for the Lock attached !", "Hardware Lock Error", EnumMessageType.Information)
                Return False
            Case -3
                'Text5.Text = "Sentrymsp.vxd is not found in the current path  "
                'gFuncShowMessage("Hardware Lock Error", "Sentrymsp.vxd is not found in the current path  ", modConstants.EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage("Sentrymsp.vxd is not found in the current path  ", "Hardware Lock Error", EnumMessageType.Information)
                Return False
            Case -5
                'Text5.Text = "Sentry.sys is not started or not installed on the Win NT/2000 machine!"
                'gFuncShowMessage("Hardware Lock Error", "Sentry.sys is not started or not installed on the Win NT/2000 machine!", modConstants.EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage("Sentry.sys is not started or not installed on the Win NT/2000 machine!", "Hardware Lock Error", EnumMessageType.Information)
                Return False
            Case -6
                'Text5.Text = " Sentry.sys could not close its operations on the Win NT/2000 machine!"
                'gFuncShowMessage("Hardware Lock Error", " Sentry.sys could not close its operations on the Win NT/2000 machine!", modConstants.EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage(" Sentry.sys could not close its operations on the Win NT/2000 machine!", "Hardware Lock Error", EnumMessageType.Information)
                Return False
            Case -7
                'Text5.Text = " The memory location index entered is out of range (0-29)!"
                'gFuncShowMessage("Hardware Lock Error", " The memory location index entered is out of range (0-29)!", modConstants.EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage(" The memory location index entered is out of range (0-29)!", "Hardware Lock Error", EnumMessageType.Information)
                Return False
            Case -8
                'Text5.Text = " The Sentrymsp.vxd or sentry.sys found belongs to earlier  version, Update with the latest !"
                'gFuncShowMessage("Hardware Lock Error", " The Sentrymsp.vxd or sentry.sys found belongs to earlier  version, Update with the latest !", modConstants.EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage(" The Sentrymsp.vxd or sentry.sys found belongs to earlier  version, Update with the latest !", "Hardware Lock Error", EnumMessageType.Information)
                Return False
            Case -9
                'Text5.Text = " Cannot work on Win3.1!"
                'gFuncShowMessage("Hardware Lock Error", " Cannot work on Win3.1!", modConstants.EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage(" Cannot work on Win3.1!", "Hardware Lock Error", EnumMessageType.Information)
                Return False
            Case -10
                'Text5.Text = " The KEY passed with this function is not made for the lock attached to the machine !"
                'gFuncShowMessage("Hardware Lock Error", " The KEY passed with this function is not made for the lock attached to the machine !", modConstants.EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage(" The KEY passed with this function is not made for the lock attached to the machine !", "Hardware Lock Error", EnumMessageType.Information)
                Return False
        End Select


    End Function


#End Region


End Class
