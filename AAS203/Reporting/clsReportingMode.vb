Option Explicit On 
Option Strict On
'Imports ColorAnalysis.Common

<Serializable()> Public Class clsReportingMode
    Implements IDisposable
    '**********************************************************************
    ' File Header       : clsReportingMode
    ' File Name 		: clsReportingMode.vb
    ' Author			: Mangesh Shardul
    ' Date/Time			: 20-Nov-2004 8:10 pm
    ' Description		: All the reporting functions are defined
    '**********************************************************************

#Region " Enums, Constants, Structurs And Other DataTypes "

    Public Structure structReportFormat
        Dim ReportFormatID As Long
        Dim ReportFormatName As String
        Dim IsDisplayCompanyLogo As Boolean
        Dim IsDisplayReportTitle As Boolean
        Dim IsDisplaySecondReportTitle As Boolean
        Dim IsDisplayReportDate As Boolean
        Dim IsDisplaySubsequentPageHeader As Boolean
        '//-----
        Dim IsDisplayReportHeader As Boolean
        '//-----
        Dim IsDisplayReportFooter As Boolean
        Dim LogoHeight As Double
        Dim LogoWidth As Double
        Dim LogoAlignment As Integer
        Dim LogoFileName As String
        Dim ReportTitleLine1 As String
        Dim ReportTitleLine2 As String
        Dim ReportTitleLine3 As String
        Dim SecondReportTitleLine1 As String
        Dim SecondReportTitleLine2 As String
        Dim SecondReportTitleLine3 As String
        Dim PageLeftMargin As Double
        Dim PageTopMargin As Double
        Dim PageBottomMargin As Double
        Dim ReportFooterLine1 As String
        Dim ReportFooterLine2 As String
        Dim ReportFooterLine3 As String
        '//-----
        Dim AnalystName As String
        Dim PrinterType As Boolean
        '//-----
    End Structure

#End Region

#Region " Private class variables "

    Private mobjHashTableRptSetting As Hashtable
    Private mobjstructReportFormat As structReportFormat

#End Region

#Region " Public Properties "
    'Public Property ReportFormats() As structReportFormat
    '    Get
    '        Return mobjstructReportFormat
    '    End Get
    '    Set(ByVal Value As structReportFormat)
    '        mobjstructReportFormat = Value
    '    End Set
    'End Property
#End Region

#Region " Garbage Collection "

    Private handle As IntPtr
    Private disposed As Boolean = False

    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        '**********************************************************************
        ' Procedure Header  : Dispose
        ' Author			: Mangesh Shardul
        ' Date/Time			: 20-Nov-2004 8:20 pm
        ' Description		: destructor for class
        '**********************************************************************
        Try
            Dispose(True)
            GC.SuppressFinalize(Me)

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

    Private Overloads Sub dispose(ByVal disposing As Boolean)
        '**********************************************************************
        ' Procedure Header  : Dispose
        ' Author			: Mangesh Shardul
        ' Date/Time			: 20-Nov-2004 8:20 pm
        ' Description		: destructor for class
        '**********************************************************************
        Try
            If Not Me.disposed Then
                If disposing Then
                    mobjHashTableRptSetting = Nothing
                    mobjstructReportFormat = Nothing
                End If
                CloseHandle(handle)
                handle = IntPtr.Zero
            End If
            disposed = True

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

    <System.Runtime.InteropServices.DllImport("kernel32")> _
    Private Shared Function CloseHandle(ByVal handle As IntPtr) As Boolean
    End Function

    Protected Overrides Sub finalize()
        '**********************************************************************
        ' Procedure Header  : Dispose
        ' Author			: Mangesh Shardul
        ' Date/Time			: 20-Nov-2004 8:20 pm
        ' Description		: destructor for class
        '**********************************************************************
        Try
            Dispose(False)
            MyBase.Finalize()

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

#Region " Public Functions "

    Public Sub New()
        '**********************************************************************
        ' Procedure Header  :
        ' Author			: Mangesh Shardul
        ' Date/Time			: 20-Nov-2004 8:20 pm
        ' Description		: Constructor for class
        '**********************************************************************
        Try
            mobjHashTableRptSetting = New Hashtable
            mobjstructReportFormat = New structReportFormat

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

    Public Function funcGetReportFormatSettings(ByVal lngReportFormatIDIn As Long) As Hashtable
        '=====================================================================
        ' Procedure Name        : InitializeReportFormatStruct
        ' Parameters Passed     : Report format ID 
        ' Returns               : Hash Table
        ' Purpose               : To get the data from database
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : structure of ReportFormat
        ' Author                : Mangesh Shardul
        ' Created               : Sunday, November 21, 2004 8:25 pm
        ' Revisions             : 
        '=====================================================================
        Dim objDrReportFormatData As DataRow
        Dim objHtReportFormat As New Hashtable

        Try
            'objDrReportFormatData = gobjDataAccess.GetReportFormatData(lngReportFormatIDIn)

            If IsNothing(objDrReportFormatData) = False Then
                objHtReportFormat.Item("ReportFormatID") = CLng(objDrReportFormatData.Item("ReportFormatID"))
                objHtReportFormat.Item("ReportFormatName") = CStr(objDrReportFormatData.Item("ReportFormatName"))

                objHtReportFormat.Item("IsDisplayCompanyLogo") = CBool(objDrReportFormatData("IsDisplayCompanyLogo"))
                objHtReportFormat.Item("IsDisplayReportTitle") = CBool(objDrReportFormatData("IsDisplayReportTitle"))
                objHtReportFormat.Item("IsDisplaySecondReportTitle") = CBool(objDrReportFormatData("IsDisplaySecondReportTitle"))
                objHtReportFormat.Item("IsDisplayReportDate") = CBool(objDrReportFormatData("IsDisplayReportDate"))
                objHtReportFormat.Item("IsDisplaySubsequentPageHeader") = CBool(objDrReportFormatData("IsDisplaySubsequentPageHeader"))
                objHtReportFormat.Item("IsDisplayReportFooter") = CBool(objDrReportFormatData("IsDisplayReportFooter"))
                objHtReportFormat.Item("LogoHeight") = CDbl(objDrReportFormatData("LogoHeight"))
                objHtReportFormat.Item("LogoWidth") = CDbl(objDrReportFormatData("LogoWidth"))
                objHtReportFormat.Item("LogoAlignment") = CInt(objDrReportFormatData("LogoAlignment"))
                objHtReportFormat.Item("LogoFileName") = CStr(objDrReportFormatData("LogoFileName"))
                objHtReportFormat.Item("ReportTitleLine1") = CStr(objDrReportFormatData("ReportTitleLine1"))
                objHtReportFormat.Item("ReportTitleLine2") = CStr(objDrReportFormatData("ReportTitleLine2"))
                objHtReportFormat.Item("ReportTitleLine3") = CStr(objDrReportFormatData("ReportTitleLine3"))
                objHtReportFormat.Item("SecondReportTitleLine1") = CStr(objDrReportFormatData("SecondReportTitleLine1"))
                objHtReportFormat.Item("SecondReportTitleLine2") = CStr(objDrReportFormatData("SecondReportTitleLine2"))
                objHtReportFormat.Item("SecondReportTitleLine3") = CStr(objDrReportFormatData("SecondReportTitleLine3"))
                objHtReportFormat.Item("PageLeftMargin") = CDbl(objDrReportFormatData("PageLeftMargin"))
                objHtReportFormat.Item("PageTopMargin") = CDbl(objDrReportFormatData("PageTopMargin"))
                objHtReportFormat.Item("PageBottomMargin") = CDbl(objDrReportFormatData("PageBottomMargin"))
                objHtReportFormat.Item("ReportFooterLine1") = CStr(objDrReportFormatData("ReportFooterLine1"))
                objHtReportFormat.Item("ReportFooterLine2") = CStr(objDrReportFormatData("ReportFooterLine2"))
                objHtReportFormat.Item("ReportFooterLine3") = CStr(objDrReportFormatData("ReportFooterLine3"))
                objHtReportFormat.Item("AnalystName") = CStr(objDrReportFormatData("AnasystName"))
                objHtReportFormat.Item("PrinterType") = CBool(objDrReportFormatData("PrinterType"))

                Return objHtReportFormat
            Else
                Return Nothing
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return Nothing
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If

            objDrReportFormatData = Nothing
            objHtReportFormat = Nothing
            '---------------------------------------------------------
        End Try

    End Function

    Public Function funcGetReportFormats() As DataTable
        '=====================================================================
        ' Procedure Name        : funcGetReportFormats
        ' Parameters Passed     : None
        ' Returns               : DataTable
        ' Purpose               : To retrieve all the data from database
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : clsDataAccessLayer
        ' Author                : Mangesh Shardul At Machine SOFT1
        ' Created               : Sunday, January 30, 2005
        ' Revisions             : 1
        '=====================================================================
        Try
            'Return gobjDataAccess.GetReportFormatData()

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

    Public Function funcInitializeReportFormatStruct(ByVal lngReportFormatID As Long) As Boolean
        '=====================================================================
        ' Procedure Name        : InitializeReportFormatStruct
        ' Parameters Passed     : Report format ID 
        ' Returns               : True or false
        ' Purpose               : To get the data from database
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : structure of ReportFormat
        ' Author                : Mangesh Shardul
        ' Created               : Sunday, November 21, 2004 8:25 pm
        ' Revisions             : 
        '=====================================================================
        Dim objDrReportFormatData As DataRow

        Try
            'objDrReportFormatData = gobjDataAccess.GetReportFormatData(lngReportFormatID)

            If IsNothing(objDrReportFormatData) = False Then
                mobjstructReportFormat.ReportFormatID = CLng(objDrReportFormatData.Item("ReportFormatID"))
                mobjstructReportFormat.ReportFormatName = CStr(objDrReportFormatData.Item("ReportFormatName"))


                mobjstructReportFormat.IsDisplayCompanyLogo = CBool(objDrReportFormatData("IsDisplayCompanyLogo"))
                mobjstructReportFormat.IsDisplayReportTitle = CBool(objDrReportFormatData("IsDisplayReportTitle"))
                mobjstructReportFormat.IsDisplaySecondReportTitle = CBool(objDrReportFormatData("IsDisplaySecondReportTitle"))
                mobjstructReportFormat.IsDisplayReportDate = CBool(objDrReportFormatData("IsDisplayReportDate"))
                mobjstructReportFormat.IsDisplaySubsequentPageHeader = CBool(objDrReportFormatData("IsDisplaySubsequentPageHeader"))
                mobjstructReportFormat.IsDisplayReportFooter = CBool(objDrReportFormatData("IsDisplayReportFooter"))
                mobjstructReportFormat.LogoHeight = CDbl(objDrReportFormatData("LogoHeight"))
                mobjstructReportFormat.LogoWidth = CDbl(objDrReportFormatData("LogoWidth"))
                mobjstructReportFormat.LogoAlignment = CInt(objDrReportFormatData("LogoAlignment"))
                mobjstructReportFormat.LogoFileName = CStr(objDrReportFormatData("LogoFileName"))
                mobjstructReportFormat.ReportTitleLine1 = CStr(objDrReportFormatData("ReportTitleLine1"))
                mobjstructReportFormat.ReportTitleLine2 = CStr(objDrReportFormatData("ReportTitleLine2"))
                mobjstructReportFormat.ReportTitleLine3 = CStr(objDrReportFormatData("ReportTitleLine3"))
                mobjstructReportFormat.SecondReportTitleLine1 = CStr(objDrReportFormatData("SecondReportTitleLine1"))
                mobjstructReportFormat.SecondReportTitleLine2 = CStr(objDrReportFormatData("SecondReportTitleLine2"))
                mobjstructReportFormat.SecondReportTitleLine3 = CStr(objDrReportFormatData("SecondReportTitleLine3"))
                mobjstructReportFormat.PageLeftMargin = CDbl(objDrReportFormatData("PageLeftMargin"))
                mobjstructReportFormat.PageTopMargin = CDbl(objDrReportFormatData("PageTopMargin"))
                mobjstructReportFormat.PageBottomMargin = CDbl(objDrReportFormatData("PageBottomMargin"))
                mobjstructReportFormat.ReportFooterLine1 = CStr(objDrReportFormatData("ReportFooterLine1"))
                mobjstructReportFormat.ReportFooterLine2 = CStr(objDrReportFormatData("ReportFooterLine2"))
                mobjstructReportFormat.ReportFooterLine3 = CStr(objDrReportFormatData("ReportFooterLine3"))
                mobjstructReportFormat.PrinterType = CBool(objDrReportFormatData("PrinterType"))


                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If

            objDrReportFormatData = Nothing
            '---------------------------------------------------------
        End Try

    End Function

    'Public Function Print(ByVal intReportTypeIn As clsPrintDocument.enumReportType, _
    '                             ByVal strPageHeaderIn As String, ByVal strPageTextIn As String, _
    '                             Optional ByVal arrGraphControlsListIn As ArrayList = Nothing, _
    '                             Optional ByVal arrDtTablesListIn As ArrayList = Nothing, _
    '                             Optional ByVal objDtImagesListIn As DataTable = Nothing) As Boolean
    '    Dim objfrmReport As frmReportSettings
    '    Try
    '        objfrmReport = New frmReportSettings(mobjstructReportFormat, _
    '        strPageHeaderIn, strPageTextIn, arrGraphControlsListIn, arrDtTablesListIn, objDtImagesListIn, intReportTypeIn)

    '        If objfrmReport.ShowDialog() = (DialogResult.OK Or DialogResult.None) Then

    '            'gstructSettings.ReportFormatID = objfrmReport.SelectedReportFormatID
    '            If objfrmReport.IsDefaultReportFormat = True Then
    '                'Call funcSaveReportFormatIDToINIData()
    '            End If

    '            'Call funcInitializeReportFormatStruct(gstructSettings.ReportFormatID)

    '            objfrmReport.Close()
    '            objfrmReport.Dispose()
    '            objfrmReport = Nothing
    '            Return True
    '        End If

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        Return False
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '        'If Not cWait Is Nothing Then
    '        '    cWait.Dispose()
    '        'End If
    '    End Try

    'End Function

    Public Function funcGetLastReportFormatID() As Long
        'Return gobjDataAccess.GetIncrementedReportFormatID
    End Function

    Public Function AddNewReportFormatInDataBase(ByVal objHtRptSettingIn As Hashtable) As Boolean
        '=====================================================================
        ' Procedure Name        : AddNewReportFormatInDataBase
        ' Parameters Passed     : HashTable
        ' Returns               : True Or false
        ' Purpose               : To add new report format in Database
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : clsDataAccesLayer
        ' Author                : Mangesh Shardul At Machine SOFT1
        ' Created               : Monday, January 31, 2005
        ' Revisions             : 1
        '=====================================================================
        Try
            Dim objDrNewReportFormat As DataRow '= CType(gobjDataAccess.GetEmptyTableStructure("ReportFormat", True).NewRow, DataRow)

            objDrNewReportFormat.Item("ReportFormatID") = objHtRptSettingIn.Item("ReportFormatID")
            objDrNewReportFormat.Item("ReportFormatName") = objHtRptSettingIn.Item("ReportFormatName")
            objDrNewReportFormat.Item("ReportTitleLine1") = objHtRptSettingIn.Item("ReportTitleLine1")
            objDrNewReportFormat.Item("ReportTitleLine2") = objHtRptSettingIn.Item("ReportTitleLine2")
            objDrNewReportFormat.Item("ReportTitleLine3") = objHtRptSettingIn.Item("ReportTitleLine3")
            objDrNewReportFormat.Item("SecondReportTitleLine1") = objHtRptSettingIn.Item("SecondReportTitleLine1")
            objDrNewReportFormat.Item("SecondReportTitleLine2") = objHtRptSettingIn.Item("SecondReportTitleLine2")
            objDrNewReportFormat.Item("SecondReportTitleLine3") = objHtRptSettingIn.Item("SecondReportTitleLine3")
            objDrNewReportFormat.Item("ReportFooterLine1") = objHtRptSettingIn.Item("ReportFooterLine1")
            objDrNewReportFormat.Item("ReportFooterLine2") = objHtRptSettingIn.Item("ReportFooterLine2")
            objDrNewReportFormat.Item("ReportFooterLine3") = objHtRptSettingIn.Item("ReportFooterLine3")
            objDrNewReportFormat.Item("IsDisplayCompanyLogo") = objHtRptSettingIn.Item("IsDisplayCompanyLogo")
            objDrNewReportFormat.Item("IsDisplayReportDate") = objHtRptSettingIn.Item("IsDisplayReportDate")
            objDrNewReportFormat.Item("IsDisplayReportFooter") = objHtRptSettingIn.Item("IsDisplayReportFooter")
            objDrNewReportFormat.Item("IsDisplayReportTitle") = objHtRptSettingIn.Item("IsDisplayReportTitle")
            objDrNewReportFormat.Item("IsDisplaySecondReportTitle") = objHtRptSettingIn.Item("IsDisplaySecondReportTitle")
            objDrNewReportFormat.Item("IsDisplaySubsequentPageHeader") = objHtRptSettingIn.Item("IsDisplaySubsequentPageHeader")
            objDrNewReportFormat.Item("LogoAlignment") = objHtRptSettingIn.Item("LogoAlignment")
            objDrNewReportFormat.Item("LogoFileName") = objHtRptSettingIn.Item("LogoFileName")
            objDrNewReportFormat.Item("LogoWidth") = objHtRptSettingIn.Item("LogoWidth")
            objDrNewReportFormat.Item("LogoHeight") = objHtRptSettingIn.Item("LogoHeight")
            objDrNewReportFormat.Item("PageBottomMargin") = objHtRptSettingIn.Item("PageBottomMargin")
            objDrNewReportFormat.Item("PageLeftMargin") = objHtRptSettingIn.Item("PageLeftMargin")
            objDrNewReportFormat.Item("PageTopMargin") = objHtRptSettingIn.Item("PageTopMargin")
            objDrNewReportFormat.Item("PrinterType") = objHtRptSettingIn.Item("PrinterType")

            'Dim objDrNewReportFormat = CType(gobjDataAccess.GetEmptyTableStructure("ReportFormat", True).NewRow, DataRow)
            'If gobjDataAccess.AddNewReportFormatData(objDrNewReportFormat) Then
            '    Return True
            'Else
            '    Return False
            'End If

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
            objHtRptSettingIn = Nothing
            '---------------------------------------------------------
        End Try

    End Function

    Public Function UpdateReportFormatInDataBase(ByVal objHtRptSettingIn As Hashtable) As Boolean
        '=====================================================================
        ' Procedure Name        : UpdateReportFormatInDataBase
        ' Parameters Passed     : HashTable
        ' Returns               : True or false
        ' Purpose               : To update selected report format in database
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : clsDataAccessLayer
        ' Author                : Mangesh Shardul At Machine SOFT1
        ' Created               : Monday, January 31, 2005
        ' Revisions             : 1
        '=====================================================================
        Try
            Dim objDrNewReportFormat As DataRow '= CType(gobjDataAccess.GetEmptyTableStructure("ReportFormat", True).NewRow, DataRow)

            objDrNewReportFormat.Item("ReportFormatID") = objHtRptSettingIn.Item("ReportFormatID")
            objDrNewReportFormat.Item("ReportFormatName") = objHtRptSettingIn.Item("ReportFormatName")
            objDrNewReportFormat.Item("ReportTitleLine1") = objHtRptSettingIn.Item("ReportTitleLine1")
            objDrNewReportFormat.Item("ReportTitleLine2") = objHtRptSettingIn.Item("ReportTitleLine2")
            objDrNewReportFormat.Item("ReportTitleLine3") = objHtRptSettingIn.Item("ReportTitleLine3")
            objDrNewReportFormat.Item("SecondReportTitleLine1") = objHtRptSettingIn.Item("SecondReportTitleLine1")
            objDrNewReportFormat.Item("SecondReportTitleLine2") = objHtRptSettingIn.Item("SecondReportTitleLine2")
            objDrNewReportFormat.Item("SecondReportTitleLine3") = objHtRptSettingIn.Item("SecondReportTitleLine3")
            objDrNewReportFormat.Item("ReportFooterLine1") = objHtRptSettingIn.Item("ReportFooterLine1")
            objDrNewReportFormat.Item("ReportFooterLine2") = objHtRptSettingIn.Item("ReportFooterLine2")
            objDrNewReportFormat.Item("ReportFooterLine3") = objHtRptSettingIn.Item("ReportFooterLine3")
            objDrNewReportFormat.Item("IsDisplayCompanyLogo") = objHtRptSettingIn.Item("IsDisplayCompanyLogo")
            objDrNewReportFormat.Item("IsDisplayReportDate") = objHtRptSettingIn.Item("IsDisplayReportDate")
            objDrNewReportFormat.Item("IsDisplayReportFooter") = objHtRptSettingIn.Item("IsDisplayReportFooter")
            objDrNewReportFormat.Item("IsDisplayReportTitle") = objHtRptSettingIn.Item("IsDisplayReportTitle")
            objDrNewReportFormat.Item("IsDisplaySecondReportTitle") = objHtRptSettingIn.Item("IsDisplaySecondReportTitle")
            objDrNewReportFormat.Item("IsDisplaySubsequentPageHeader") = objHtRptSettingIn.Item("IsDisplaySubsequentPageHeader")
            objDrNewReportFormat.Item("LogoAlignment") = objHtRptSettingIn.Item("LogoAlignment")
            objDrNewReportFormat.Item("LogoFileName") = objHtRptSettingIn.Item("LogoFileName")
            objDrNewReportFormat.Item("LogoWidth") = objHtRptSettingIn.Item("LogoWidth")
            objDrNewReportFormat.Item("LogoHeight") = objHtRptSettingIn.Item("LogoHeight")
            objDrNewReportFormat.Item("PageBottomMargin") = objHtRptSettingIn.Item("PageBottomMargin")
            objDrNewReportFormat.Item("PageLeftMargin") = objHtRptSettingIn.Item("PageLeftMargin")
            objDrNewReportFormat.Item("PageTopMargin") = objHtRptSettingIn.Item("PageTopMargin")
            objDrNewReportFormat.Item("PrinterType") = objHtRptSettingIn.Item("PrinterType")

            'If gobjDataAccess.UpdateReportFormatData(objDrNewReportFormat) Then
            '    Return True
            'Else
            '    Return False
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
            objHtRptSettingIn = Nothing
            '---------------------------------------------------------
        End Try

    End Function

    'Public Function funcSaveReportFormatIDToINIData() As Boolean
    '    '=====================================================================
    '    ' Procedure Name        : funcSaveReportFormatIDToINIData
    '    ' Parameters Passed     : None
    '    ' Returns               : true if succesfull otherwise false
    '    ' Purpose               : to save Selected ReportFormatID to the IniData Table
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Mangesh Shardul
    '    ' Created               : 26-Feb-2005 5:15 pm
    '    ' Revisions             : 1
    '    '=====================================================================
    '    Dim objdtIniData As New DataTable
    '    Dim objdvIniData As DataView

    '    Try
    '        objdtIniData = gobjDataAccess.GetINIData(gIntActiveMethodID)
    '        objdvIniData = New DataView(objdtIniData)

    '        objdvIniData.RowFilter = "SectionName ='" & Const_ReportFormat_Section & "'"
    '        objdvIniData.Item(0).Item(Const_IniData_Value) = gstructSettings.ReportFormatID

    '        If gobjDataAccess.UpdateINIData(objdtIniData, gIntActiveMethodID) = True Then
    '            Return True
    '        Else
    '            Return False
    '        End If


    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        Return False
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        objdtIniData.Dispose()
    '        objdvIniData.Dispose()
    '        '---------------------------------------------------------
    '    End Try

    'End Function

    Public Shared Sub GetShadeColorImages(ByRef objDtImagesList As DataTable, ByVal strCaptionIn As String, _
            ByVal objColorIn As Color, Optional ByVal imgImageIn As System.Drawing.Image = Nothing, _
            Optional ByVal ImageWidth As Integer = 0, Optional ByVal ImageHeight As Integer = 0)
        '=====================================================================
        ' Procedure Name        : funcGetShadeColorImages
        ' Parameters Passed     : 1.Reference to DataTable in which image and caption is added,
        '                         2.String for Caption of Image
        '                         3.Color object if r,g,b values are known
        '                         4.Optional Image object from form's controls
        ' Returns               : DataTable with Image and ImageCaption
        ' Purpose               : To get bitmap image of the color shown in the ShapeControl
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 06-Apr-2005 1:50 pm
        ' Revisions             : 1
        '=====================================================================
        Dim objDrNewRow As DataRow
        Dim objColorImage As System.Drawing.Bitmap

        Dim intXCounter As Integer
        Dim intYCounter As Integer

        Try
            If Not IsNothing(objDtImagesList) = True Then
                If objDtImagesList.Rows.Count = 0 Then
                    objDtImagesList = New DataTable
                    objDtImagesList.Columns.Add("ImageCaption", GetType(String))
                    objDtImagesList.Columns.Add("Image", GetType(System.Drawing.Bitmap))
                Else
                    If objDtImagesList.Columns.Contains("ImageCaption") = False Or _
                       objDtImagesList.Columns.Contains("Image") = False Then
                        objDtImagesList.Columns.Clear()
                        objDtImagesList.Columns.Add("ImageCaption", GetType(String))
                        objDtImagesList.Columns.Add("Image", GetType(System.Drawing.Bitmap))
                    End If
                End If
            Else
                '---DataTable is nothing
                objDtImagesList = New DataTable
                objDtImagesList.Columns.Add("ImageCaption", GetType(String))
                objDtImagesList.Columns.Add("Image", GetType(System.Drawing.Bitmap))
            End If

            If objColorIn.Equals(Color.Empty) = False Then
                If ImageWidth = 0 And ImageHeight = 0 Then
                    objColorImage = New Bitmap(150, 40)
                Else
                    objColorImage = New Bitmap(ImageWidth, ImageHeight)
                End If

                For intXCounter = 0 To objColorImage.Width - 1
                    For intYCounter = 0 To objColorImage.Height - 1
                        objColorImage.SetPixel(intXCounter, intYCounter, objColorIn)
                    Next intYCounter
                Next intXCounter

            End If
            If IsNothing(imgImageIn) = False Then
                'objColorImage = New Bitmap(imgImageIn)
                objColorImage = CType(imgImageIn.Clone, System.Drawing.Bitmap)
            End If

            '---4.Add Image and ImageCaption in the DataTable
            If Not IsNothing(objColorImage) = True Then
                objDrNewRow = objDtImagesList.NewRow()
                objDrNewRow.Item("ImageCaption") = strCaptionIn
                objDrNewRow.Item("Image") = objColorImage
                objDtImagesList.Rows.Add(objDrNewRow)
            End If

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

    Public Function funcCookBookPrinting(ByRef objDtCookBook As DataTable, ByRef objDtElementWavelengths As DataTable) As Boolean
        '************************************************************************************************************
        ' Function Header   : btnPrintPreViewClick
        ' Author			: Sachin Dokhale
        ' Date/Time			: 08-Oct-2005 11:25 am
        ' Description		: To preview the report before printing
        '************************************************************************************************************
        Dim objclsPrintDocument As clsPrintDocument

        Try
            If (objDtCookBook Is Nothing) Or (objDtElementWavelengths Is Nothing) Then
                Return True
            End If

            'objclsPrintDocument = funcSetPrintDocument(mobjstructReportFormat, _
            '            mstrPageHeader, mstrPageText, _
            '            marrGraphControlsList, mobjarrDtTablesList, _
            '            mobjDtImagesList, mintReportType)
            'objclsPrintDocument()

            'objDtCookBook()

            If Not IsNothing(objclsPrintDocument) = True Then

                If objclsPrintDocument.PrintPreview() = True Then
                    objclsPrintDocument.Dispose()
                    objclsPrintDocument = Nothing
                End If

            End If
            Return True
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            If Not IsNothing(objclsPrintDocument) = True Then objclsPrintDocument.Dispose()
            '---------------------------------------------------------
        End Try

    End Function

#End Region

End Class
