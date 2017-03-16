Option Explicit On 

Module mGeneralConstants

    '--- Constant to configure the execution log creation
    '   Public Const CONST_CREATE_EXECUTION_LOG = 1

    Public Const CONST_IQOQPQ_DATABASENAME As String = "IQOQPQ"

    Public Const CONST_CREATE_EXECUTION_LOG = 0

    '--- Constants for the screen width and Slider width
    Public Const CONST_SLIDER_WIDTH As Long = 192
    Public Const CONST_SCREEN_WIDTH As Long = 500

    Public Enum ENUM_IQOQPQ_STATUS
        IQ = 1
        OQ = 2
        PQ = 3
    End Enum

    Public Enum ENUM_IQ_Modes
        IQ_CustomerDetails = 11
        IQ_EquipmentList = 12
        IQ_ManualList = 13
        IQ_Approval = 14
        IQ_Specifications = 15
        IQ_Tests = 16
        IQ_Deficiency = 17
    End Enum

    Public Enum ENUM_OQ_Modes
        OQ_Approval = 21
        OQ_EquipmentList = 22
        OQ_Test1 = 23
        OQ_Test2 = 24
        OQ_UserTraining = 25
        OQ_Deficiency = 26
    End Enum

    Public Enum ENUM_PQ_Modes
        PQ_Approval = 31
        PQ_EquipmentList = 32
        PQ_Test = 33
        PQ_Attachment1 = 34
        PQ_Attachment2 = 35
        PQ_Attachment3 = 36
        'PQ_Attachment4 = 37
        'PQ_Attachment5 = 38
        'PQ_Attachment6 = 39
        'PQ_Attachment7 = 40
        'PQ_Attachment8 = 41
        'PQ_Attachment9 = 42

        'PQ_Deficiency = 43 '---commented on 29.11.10
        'PQ_Warranty = 44 '---commented on 29.11.10
        PQ_Deficiency = 37 '---changed on 29.11.10
        PQ_Warranty = 38 '---changed on 29.11.10

    End Enum

    '--- Constant for the PQ test
    Public Enum enumPQTest
        PQ_Test1 = 1
        PQ_Test2 = 2
        PQ_Test3 = 3
        PQ_Test4 = 4
        PQ_Test5 = 5
        PQ_Test6 = 6
        PQ_Test7 = 7
        PQ_Test8 = 8
        PQ_Test9 = 9
    End Enum

    Public Enum ENUM_TestNos
        TestNo1 = 1
        TestNo2 = 2
        TestNo3 = 3
    End Enum
#Region " Message Interface Constants"

    Public Const constErrorLockingModeStatus = 139

#End Region

End Module

