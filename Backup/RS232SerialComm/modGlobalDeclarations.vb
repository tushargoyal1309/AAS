
Module modGlobalDeclarations

#Region " Global Variables and Objects "

    '---Object for RS232 communication
    Public mrs232 As New clsRS232
    'Public mrs232 As New clsRS232vc 'by Pankaj for vc dll on 12 Sep 07
    '---Error Initialization
    Public gobjErrorHandler As New ErrorHandler.ErrorHandler
    '---Path for the Settings.ini
    Public INI_SETTINGS_PATH As String

    Public Commflag As Boolean = True

#End Region


#Region " Public Enums, Constants, Structures... "

    '--- Communication Settings 
    Public Const SECTION_SETTINGS = "CommSettings"
    Public Const KEY_COMPORT = "ComPort"
    Public Const KEY_BAUDRATE = "BaudRate"
    Public Const KEY_PARITY = "Parity"
    Public Const KEY_DATABITS = "DataBits"
    Public Const KEY_STOPBITS = "StopBits"

    Public Const CONST_CREATE_EXECUTION_LOG = 0

    Public Enum EnumMessageType
        Information = 1
        Question = 2
    End Enum

#End Region

End Module
