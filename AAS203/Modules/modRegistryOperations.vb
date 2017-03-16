Option Explicit On 
Imports Microsoft.Win32

Module modRegistryOperations

    Private strRegKeyValueNames() As String
    Private mstrDeviceSerialComm() As Integer

    Public Function gFuncGetAvailbleCommPorts() As Integer
        '----------------------------------------------------------------------------
        'Procedure Name:    gFuncGetAvailbleCommPorts
        'Description:       To get the Number of Comports Availble in the System
        'Time/Date  :       4.13 14 Oct'2003
        'Dependencies:      Registry Should Contain the Settings of hardware
        'Author:            Sachin Dokhale
        'Revision:           
        'Revision by Person: 
        '----------------------------------------------------------------------------
        Dim Regkey As RegistryKey
        Dim strAvailableCommPorts As String()
        Dim strAvailableCommPorts1 As String
        Dim intCommSerial As Integer
        Dim strCommport As String
        Dim strRegKeyValueName As String
        Dim intCommCount As Integer = 1

        Try
            '--- Open the Key To Check number of Comm Ports Supported By the System
            Regkey = Registry.LocalMachine.OpenSubKey("HARDWARE\DEVICEMAP\SERIALCOMM")


            If Regkey.ValueCount > 0 Then
                '--- Send the no of Comm ports Available
                ReDim mstrDeviceSerialComm(CInt(Regkey.ValueCount - 1))
                ReDim gintCommPort(CInt(Regkey.ValueCount) - 1)
                ReDim strRegKeyValueNames(CInt(Regkey.ValueCount) - 1)
            Else
                ReDim mstrDeviceSerialComm(0)
                ReDim gintCommPort(0)
                gintCommPort(0) = 0
            End If

            If Regkey.ValueCount > 0 Then
                strRegKeyValueNames = Regkey.GetValueNames()
                Call Array.Sort(strRegKeyValueNames)
                For intCommSerial = 0 To Regkey.ValueCount - 1
                    strRegKeyValueName = strRegKeyValueNames(intCommSerial)
                    strCommport = (Regkey.GetValue(strRegKeyValueName))
                    gintCommPort(intCommSerial) = CInt(Mid(strCommport, 4))
                Next
            End If

            intCommCount = Regkey.ValueCount

            Return intCommCount

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
            'Close the Key 
            Regkey.Close()
            '---------------------------------------------------------
        End Try
    End Function

End Module
