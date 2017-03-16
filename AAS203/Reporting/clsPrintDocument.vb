Option Strict Off
Option Explicit On 
Imports System.Reflection
Imports System.Drawing.Printing
Imports System.Drawing.Printing.PrintDocument
Imports System.Collections
Imports System.Math
Imports AAS203.Common

Public Class clsPrintDocument
    Inherits System.Drawing.Printing.PrintDocument
    '*********************************************************************
    ' File Header        
    ' File Name 		: clsPrintDocument.vb
    ' Author			: Mangesh Shardul
    ' Date/Time			: 18-Feb-2005 8:00 pm
    ' Description		: To print the report 
    '**********************************************************************


#Region " Component Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        '//----- Set default initialise the of Report
        mobjstructReportFormat.PageBottomMargin = 0.5
        mobjstructReportFormat.PageLeftMargin = 0.32
        mobjstructReportFormat.PageTopMargin = 1.0
        '//-----

    End Sub

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(clsPrintDocument))
        Me.ToolbarImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.DefaultPageSettings = m_PageSetting
        '//----- Added by Sachin Dokhale 
        '//----- Set printer type as color or normal
        Me.DefaultPageSettings.Color = PrinterType  ' Set Default is Normal = Black & White

        '//-----
        '
        '
        'ToolbarImageList
        '
        Me.ToolbarImageList.ImageSize = New System.Drawing.Size(16, 16)
        Me.ToolbarImageList.ImageStream = CType(resources.GetObject("ToolbarImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ToolbarImageList.TransparentColor = System.Drawing.Color.Transparent

    End Sub

#End Region

#Region " Enums, Constants, ... "

    Public Enum enumReportLayoutType
        Portrate = 1
        Landscape = 2
    End Enum

    Public Enum enumReportType

        Others = 0
        CookBook = 1
        DataFile = 2
        StadardGraph = 3
        SampleGraph = 4
        PrintPeak_Valley = 5
        UVSpectrum = 6
        EnergySpectrum = 7
        Histograph = 8
        RepeatResults = 9
        D2Peak = 10
        TimescanGraph = 11
        'QCColorDifferenceNumerical = 2
        'QCColorDifferenceInterpretation = 3
        'QCColorDifferencePassFail = 4
        'QCColorDifferenceSpaceDiagram = 5
        'QCColorDifferenceMasterReport = 6

        'QCStrengthNumerical = 7
        'QCStrengthVisual = 8
        'QCStrengthInterpretation = 9
        'QCStrengthPassFail = 10
        'QCStrengthSpaceDiagram = 11
        'QCStrengthMasterReport = 12

        'QCTriStimulusResults = 13
        'QCTriStimulusCIEPlot = 14

        'QCIndices = 15
        'QCScales = 16
        'QCMetamerism = 17

        'QCColorOnScreen = 18
        'QCColorOnObject = 19

        'QCContrastRatio = 20

        'ColorAttributes = 21
        'RecipeDetails = 22
        'Shade555SortResults = 23

        'EditShade = 24
        'EditStandards = 25
        'EditColorants = 26
        ''//----- Added by Sachin Dokhale on 18.03.06
        'EditSubstrate = 31
        ''//-----
        'InstrumentRepeatability = 27

        'BatchCorrection = 28
        ''//----- Added by Sachinn Dokhle on 30.09.05
        'EditPigment = 29
        ''//-----
        'BatchCorrection_2Const = 30
        '//----- Last integer is 31

    End Enum

    Public Const lineSpacing As Single = 0.1

    Private Const ConstPageSettingOutofRange As Integer = 211
    'Private Const CONST_GraphHeight = 350
    'Private Const CONST_GraphWidth = 650
    Private CONST_GraphHeight As Integer = 350
    Private CONST_GraphWidth As Integer = 625

    Public Structure structCookBook
        Dim ElamentID As Integer
        Dim ElamenttName As String
        Dim ElamentAbrivation As String
        Dim ElamentATWT As String
        Dim StandardSolution As String
        Dim SolutionTech As String
        Dim InstumentLamp As String
        Dim InstumentFuel As String
        Dim InstumentSupport As String
        Dim InstumentFlame As Double
        Dim AbsNote As String
        Dim IsFlame As Boolean
        Dim FlameWavelength As Integer
        Dim FlameBandWidth As Integer
        Dim FlameFuel As String
        Dim FlameSupport As String
        Dim FlameNote As String
        Dim Interference As String

    End Structure

    Public Structure structCookBookDetals
        Dim ElamentID As Long
        Dim AbsWavelength As Integer
        Dim AbsSpectrulBand As Integer
        Dim AbsWorkingRange As String
    End Structure

    Public Structure struHeaderString
        Dim TextString As String
        Dim TextFormat As clsReportHeaderFormat
    End Structure


#End Region

#Region " Class Variables "

    Private mobjReportBrush As New SolidBrush(Color.Black)
    Private mobjReportBrushBlack As New SolidBrush(Color.Black)
    Private mobjReportBrushRed As New SolidBrush(Color.Red)
    Private mobjReportBrushBlue As New SolidBrush(Color.Blue)
    Dim mintNextPageCurrentRow As Integer
    Private mobjARPortrateReport As ActiveReport2
    'Private mobjARLandScapeReport As ARrptTablePropertiesLandScape
    Private rptPageTextReader As System.IO.StringReader
    Private npp As Integer
    Private NoOfPagesPreviewed As Integer
    Private CurRow, CurCol, CurLine As Integer
    Private NextFirstCol As Integer
    Private NoOfRowsPerPage As Integer

    Private mobjstructReportFormat As clsReportingMode.structReportFormat

    Private printFont As Font
    Private ColoumnFormat As StringFormat
    Private setColoumnFormat As Boolean = True
    Private headerFont As Font     '("Arial", 10, FontStyle.Bold)
    Private mstrPageHeader As String
    Private mstrPageFooter As String

    Private m_strPageHeader As struHeaderString
    Private m_strReportFooter As struHeaderString
    Private m_strSubPageHeader1 As struHeaderString
    Private m_strSubPageHeader2 As struHeaderString
    Private m_PrinterType As Boolean
    Private mstrPageText As String

    Private marrGraphControlsList As ArrayList

    Private mobjDvReportDataView As DataView
    Private mobjDtReportDataTable As DataTable

    Private mobjRptDataTblList As ArrayList

    Private mobjRptDtTextList As ArrayList

    Private mobjDtImageList As DataTable

    Private mintPageCount As Integer = 0
    Private mintReportTablesCount As Integer = 0
    Private mintReportTextTableCount As Integer = 0
    Private privReportTablesCount As Integer = 0

    Private printPreviewDialog As New PrintPreviewDialog
    Private printPreviewControl As New PrintPreviewControl


    Private mintReportType As enumReportType
    Private mintReportLayoutType As enumReportLayoutType

    Private mblnIsBeginPrint As Boolean = False

    Private objReportViewerToolBar As ToolBar
    Private AddedButtonsImageList As ImageList
    Private AddedButtons As ArrayList

    Friend WithEvents ToolbarImageList As System.Windows.Forms.ImageList
    Private components As System.ComponentModel.IContainer

    Private mintImageCounter As Integer
    Private mintReportGraphsCount As Integer
    Private mintCurrentImageRow As Integer = 0
    Public mintCurrentGraph As Integer = 0
    Dim mintPageFooterYPosotion As Integer = 0
    Private blnPageSettingMessage As Boolean = False

    Private mintTotalHeightOfPageText As Integer

    Private mElamentInfo As ArrayList
    Private mRepeatDatafile As ArrayList
    'Private mDtElamentDetails As DataTable

    Private objDtCookBookInfoRpt As DataTable

    Private objDtCookBookDetailRpt As DataTable

    Private blnFinishElamentInfo As Boolean
    Private blnFinishFlameEmission As Boolean
    Private blnFinishFlameEmissionNotes As Boolean
    Private blnFinishInterference As Boolean
    Private blnFinishStdSolutionTech As Boolean
    Private blnFinishWorkingConditionFixed As Boolean
    Private blnFinishWorkingConditionVariable As Boolean

    Private objDtDatafileRpt As DataTable

    Private objDtDatafileDetailRpt As DataTable
    '//----- for Repeat Result
    Private mMasterIdx As Integer
    '//-----
    Private blnEscapeHeader As Boolean
#End Region

#Region " Public Properties "

    Public marginLeft As Double
    Public marginTop As Double
    Public marginBottom As Double
    Private m_PageSetting As New PageSettings
    Private mobjReportParameter As AAS203Library.Method.clsReportParameters
    Public Property ReportFormat() As clsReportingMode.structReportFormat
        Get
            Return mobjstructReportFormat
        End Get
        Set(ByVal Value As clsReportingMode.structReportFormat)
            mobjstructReportFormat = Value
        End Set
    End Property

    Public Property DataFileReportParameter() As AAS203Library.Method.clsReportParameters
        Get
            Return mobjReportParameter
        End Get
        Set(ByVal Value As AAS203Library.Method.clsReportParameters)
            mobjReportParameter = Value
        End Set
    End Property

    Public Property DisplayFont() As Font
        Get
            Return printFont
        End Get
        Set(ByVal Value As Font)
            printFont = Value
        End Set
    End Property

    Public Property TableHeaderFont() As Font
        Get
            Return headerFont
        End Get
        Set(ByVal Value As Font)
            headerFont = Value
        End Set
    End Property

    Public Property SetTableColoumnFormat() As Boolean
        Get
            Return setColoumnFormat
        End Get
        Set(ByVal Value As Boolean)
            setColoumnFormat = Value
        End Set
    End Property

    'Public Property PageHeader() As String
    '    Get
    '        Return mstrPageHeader
    '    End Get
    '    Set(ByVal Value As String)
    '        mstrPageHeader = Value
    '    End Set
    'End Property

    Public Property PageHeader() As struHeaderString
        Get
            Return m_strPageHeader
        End Get
        Set(ByVal Value As struHeaderString)
            m_strPageHeader = Value
        End Set
    End Property
    Public Property PageSubHeader1() As struHeaderString
        Get
            Return m_strSubPageHeader1
        End Get
        Set(ByVal Value As struHeaderString)
            m_strSubPageHeader1 = Value
        End Set
    End Property
    Public Property PageSubHeader2() As struHeaderString
        Get
            Return m_strSubPageHeader2
        End Get
        Set(ByVal Value As struHeaderString)
            m_strSubPageHeader2 = Value
        End Set
    End Property
    Public Property ReportFooter() As struHeaderString
        Get
            Return m_strReportFooter
        End Get
        Set(ByVal Value As struHeaderString)
            m_strReportFooter = Value
        End Set
    End Property
    '//---- Set iss printer type as Normal or Color
    Public Property PrinterType() As Boolean
        Get
            Return m_PrinterType
        End Get
        Set(ByVal Value As Boolean)
            m_PrinterType = Value
            If Not (Me.DefaultPageSettings Is Nothing) Then
                Me.DefaultPageSettings.Color = m_PrinterType
            End If
        End Set
    End Property

    Public Property PageText() As String
        Get
            Return mstrPageText
        End Get
        Set(ByVal Value As String)
            mstrPageText = Value
        End Set
    End Property

    Public Property ReportGraphControls() As ArrayList
        Get
            Return marrGraphControlsList
        End Get
        Set(ByVal Value As ArrayList)
            marrGraphControlsList = Value
        End Set
    End Property

    Public Property ReportDataTables() As ArrayList
        Get
            Return mobjRptDataTblList
        End Get
        Set(ByVal Value As ArrayList)
            mobjRptDataTblList = Value
        End Set
    End Property

    Public Property ReportTextList() As ArrayList
        Get
            Return mobjRptDtTextList
        End Get
        Set(ByVal Value As ArrayList)
            mobjRptDtTextList = Value
        End Set
    End Property

    Public Property ReportImageList() As DataTable
        Get
            Return mobjDtImageList
        End Get
        Set(ByVal Value As DataTable)
            mobjDtImageList = Value
        End Set
    End Property

    Public Property ReportType() As enumReportType
        Get
            Return mintReportType
        End Get
        Set(ByVal Value As enumReportType)
            mintReportType = Value
        End Set
    End Property

    Public Property ReportLayoutType() As enumReportLayoutType
        Get
            Return mintReportLayoutType
        End Get
        Set(ByVal Value As enumReportLayoutType)
            mintReportLayoutType = Value

        End Set
    End Property

    Public Property ElamentInfo() As ArrayList
        Get
            ElamentInfo = mElamentInfo
        End Get
        Set(ByVal Value As ArrayList)
            mElamentInfo = Value
        End Set
    End Property

    Public Property RepeatDatafile() As ArrayList
        Get
            RepeatDatafile = mRepeatDatafile
        End Get
        Set(ByVal Value As ArrayList)
            mRepeatDatafile = Value
        End Set
    End Property

    Public Property PageSetting() As System.Drawing.Printing.PageSettings
        Get
            PageSetting = m_PageSetting
        End Get
        Set(ByVal Value As System.Drawing.Printing.PageSettings)
            m_PageSetting = Value
            Me.DefaultPageSettings = m_PageSetting
            Me.DefaultPageSettings.Color = PrinterType
            Me.PrinterSettings = Me.PageSetting.PrinterSettings
        End Set
    End Property

    'Public Property ElamentDetails() As DataTable
    '    Get
    '        ElamentDetails = mDtElamentDetails
    '    End Get
    '    Set(ByVal Value As DataTable)
    '        mDtElamentDetails = Value
    '    End Set
    'End Property

#End Region

#Region " Public Functions "

    Public Function PrintPreview() As Boolean
        Dim objWait As New CWaitCursor
        Try
            mblnIsBeginPrint = True

            Call subSetActiveReportProperties()

            If Not (mintReportType = enumReportType.CookBook) Then
                rptPageTextReader = New System.IO.StringReader(mstrPageText)
            Else
                If IsNothing(Me.ElamentInfo) = False Then
                    objDtCookBookInfoRpt = CType(Me.ElamentInfo.Item(0), DataTable).Copy
                    objDtCookBookDetailRpt = CType(Me.ElamentInfo.Item(1), DataTable).Copy
                End If
            End If

            Call subGetToolBarButtonClick()

            printPreviewDialog.Document = Me
            printPreviewDialog.PrintPreviewControl.Document = Me
            printPreviewDialog.PrintPreviewControl.Zoom = 1

            printPreviewDialog.FormBorderStyle = FormBorderStyle.Fixed3D
            printPreviewDialog.StartPosition = FormStartPosition.CenterScreen
            printPreviewDialog.WindowState = FormWindowState.Maximized

            '//-----
            mintCurrentGraph = 0
            mintCurrentImageRow = 0
            mintImageCounter = 0
            mintNextPageCurrentRow = 0
            mintPageFooterYPosotion = 0
            mintReportGraphsCount = 0
            CurRow = 0
            CurCol = 0
            blnPageSettingMessage = False
            mMasterIdx = 0
            blnEscapeHeader = False
            '//-----
            '//-----
            If mintReportType = enumReportType.CookBook Then
                blnFinishFlameEmission = False
                blnFinishElamentInfo = False
                blnFinishFlameEmissionNotes = False
                blnFinishInterference = False
                blnFinishStdSolutionTech = False
                blnFinishWorkingConditionFixed = False
                blnFinishWorkingConditionVariable = False
                'blnPageSettingMessage =
            End If
            '//-----

            If printPreviewDialog.ShowDialog() = (DialogResult.Cancel Or DialogResult.None) Then
                printPreviewDialog.Close()
            End If
            Application.DoEvents()

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
            printPreviewDialog.Close()
            printPreviewDialog.Dispose()
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            objWait = Nothing
            '---------------------------------------------------------
        End Try

    End Function

    Public Function PrintToPrinter() As Boolean
        Dim StrName As String
        Dim objWait As New CWaitCursor
        Try
            mblnIsBeginPrint = True
            Call subSetActiveReportProperties()

            rptPageTextReader = New System.IO.StringReader(mstrPageText)

            Dim objprintDialog As New PrintDialog
            objprintDialog.Document = Me
            objprintDialog.PrinterSettings = Me.PrinterSettings
            objprintDialog.AllowPrintToFile = False
            objprintDialog.AllowSelection = False
            objprintDialog.AllowSomePages = False
            objprintDialog.ShowHelp = True
            objprintDialog.ShowNetwork = True
            '//
            'mintCurrentGraph = 0
            'mintCurrentImageRow = 0
            'mintImageCounter = 0
            'mintNextPageCurrentRow = 0
            'mintPageFooterYPosotion = 0
            'mintReportGraphsCount = 0
            'CurRow = 0
            'CurCol = 0
            'mintPageCount = 0
            ''//----- Set the initialy PageTest height to 0
            'mintTotalHeightOfPageText = 0
            'blnPageSettingMessage = False
            'mMasterIdx = 0
            ''//-----
            'If mintReportType = enumReportType.CookBook Then
            '    blnFinishFlameEmission = False
            '    blnFinishElamentInfo = False
            '    blnFinishFlameEmissionNotes = False
            '    blnFinishInterference = False
            '    blnFinishStdSolutionTech = False
            '    blnFinishWorkingConditionFixed = False
            '    blnFinishWorkingConditionVariable = False
            '    'blnPageSettingMessage =
            'End If
            '//-----
            '//
            If objprintDialog.ShowDialog() = DialogResult.OK Then
                Dim printCopy As Integer = 0
                'For printCopy = 1 To objprintDialog.PrinterSettings.Copies  '---changed by Deepak on 30.08.09
                objWait = New CWaitCursor
                mblnIsBeginPrint = True
                mintCurrentGraph = 0
                mintCurrentImageRow = 0
                mintImageCounter = 0
                mintNextPageCurrentRow = 0
                mintPageFooterYPosotion = 0
                mintReportGraphsCount = 0
                CurRow = 0
                CurCol = 0
                mintPageCount = 0
                '//----- Set the initialy PageTest height to 0
                mintTotalHeightOfPageText = 0
                blnPageSettingMessage = False
                mMasterIdx = 0
                '//-----
                blnEscapeHeader = False
                If mintReportType = enumReportType.CookBook Then
                    blnFinishFlameEmission = False
                    blnFinishElamentInfo = False
                    blnFinishFlameEmissionNotes = False
                    blnFinishInterference = False
                    blnFinishStdSolutionTech = False
                    blnFinishWorkingConditionFixed = False
                    blnFinishWorkingConditionVariable = False
                    'blnPageSettingMessage =
                End If
                Me.Print()
                Application.DoEvents()
                'Next
                'Me.funcExportData()
            Else
                    mblnIsBeginPrint = False
            End If
            Application.DoEvents()
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try

    End Function

    Public Function SendExportData() As Boolean
        Try
            mblnIsBeginPrint = True
            Call subSetActiveReportProperties()

            rptPageTextReader = New System.IO.StringReader(mstrPageText)

            Dim objprintDialog As New PrintDialog
            objprintDialog.Document = Me
            objprintDialog.PrinterSettings = Me.PrinterSettings
            objprintDialog.AllowPrintToFile = True
            objprintDialog.AllowSelection = True
            objprintDialog.AllowSomePages = True
            objprintDialog.ShowHelp = True
            objprintDialog.ShowNetwork = True
            '//
            mintCurrentGraph = 0
            mintCurrentImageRow = 0
            mintImageCounter = 0
            mintNextPageCurrentRow = 0
            mintPageFooterYPosotion = 0
            mintReportGraphsCount = 0
            CurRow = 0
            CurCol = 0
            mintPageCount = 0
            '//----- Set the initialy PageTest height to 0
            mintTotalHeightOfPageText = 0
            blnPageSettingMessage = False
            mMasterIdx = 0
            '//-----
            If mintReportType = enumReportType.CookBook Then
                blnFinishFlameEmission = False
                blnFinishElamentInfo = False
                blnFinishFlameEmissionNotes = False
                blnFinishInterference = False
                blnFinishStdSolutionTech = False
                blnFinishWorkingConditionFixed = False
                blnFinishWorkingConditionVariable = False
                'blnPageSettingMessage =
            End If
            '//-----
            '//
            'If objprintDialog.ShowDialog() = DialogResult.OK Then
            Me.ExportData()

            'Else
            'mblnIsBeginPrint = False
            'End If
            Application.DoEvents()
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

    Private Function subGetToolBarButtonClick() As Boolean
        '=====================================================================
        ' Procedure Name        : GetToolBarButtonClick
        ' Parameters Passed     : None
        ' Returns               : True or false
        ' Purpose               : To reset the Toolbar of PrintPreviewDialog
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul At Machine SOFT1
        ' Created               : Sunday, February 06, 2005
        ' Revisions             : 1
        '=====================================================================
        Dim control As Windows.Forms.Control
        Dim objToolBarButtonCollection As Windows.Forms.ToolBar.ToolBarButtonCollection

        Try
            For Each control In printPreviewDialog.Controls
                If TypeOf control Is ToolBar Then
                    objReportViewerToolBar = CType(control, ToolBar)
                    objToolBarButtonCollection = objReportViewerToolBar.Buttons
                End If
            Next
            'AddedButtonsImageList = objReportViewerToolBar.ImageList

            'AddedButtonsImageList.Images.Add(Me.ToolbarImageList.Images(0))   '(Image.FromFile(Application.StartupPath & "\Resources\ExportData.bmp"))
            'AddedButtonsImageList.Images.Add(Me.ToolbarImageList.Images(1))   '(Image.FromFile(Application.StartupPath & "\Resources\SendMail.bmp"))

            'Dim btnExportData As New ToolBarButton
            'btnExportData.ToolTipText = "Exports Data"
            'btnExportData.Tag = 100
            'btnExportData.ImageIndex = 7
            'Dim btnMailData As New ToolBarButton
            'btnMailData.ToolTipText = "Sends Data via eMail"
            'btnMailData.Tag = 101
            'btnMailData.ImageIndex = 8

            'Dim btns(1) As ToolBarButton
            'btns(0) = btnExportData
            'btns(1) = btnMailData

            'Call subAddToolBarButtons(btns)
            'Call PrintToPrinter()
            'ExportData()
            'Call PrintPreview()
            '  objReportViewerToolBar.Buttons.bu
            'Dim MyButton As New Button()
            'MyButton.Name = "MyButton"
            If objReportViewerToolBar Is Nothing Then
                objReportViewerToolBar = New ToolBar()
            End If
            AddHandler objReportViewerToolBar.ButtonClick, AddressOf subToolBarButtonClick 'Manoj



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

    Private Sub subToolBarButtonClick(ByVal sender As Object, ByVal e As ToolBarButtonClickEventArgs)
        Try
            Select Case e.Button.ToolTipText
                Case "Print"
                    Call PrintToPrinter()

                    'Call funcExportData()
                Case "Zoom"
                    printPreviewDialog.PrintPreviewControl.AutoZoom = True

                Case "Sends Data via eMail"
                    ''Me.eMailData()

                Case "Exports Data"
                    'Me.ExportData()

            End Select
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

    Public Sub subAddToolBarButtons(ByVal Buttons() As System.Windows.Forms.ToolBarButton)
        Dim imgList As ImageList
        Dim i As Integer
        Dim intInitialImages As Integer

        Try
            imgList = New ImageList
            imgList = objReportViewerToolBar.ImageList
            intInitialImages = imgList.Images.Count

            AddedButtons = New ArrayList
            For i = 0 To AddedButtonsImageList.Images.Count - 1
                imgList.Images.Add(AddedButtonsImageList.Images.Item(i))
            Next

            Dim initw As Integer = 0
            For i = 0 To Buttons.GetLength(0) - 1
                AddedButtons.Add(Buttons(i))
                If Buttons(i).ImageIndex >= 0 Then
                    Buttons(i).ImageIndex += intInitialImages
                End If
                objReportViewerToolBar.Buttons.Add(Buttons(i))
                initw += objReportViewerToolBar.Buttons(objReportViewerToolBar.Buttons.Count - 1).Rectangle.Width
            Next
            Dim s As System.Drawing.Size = printPreviewDialog.MinimumSize
            s.Width += initw
            printPreviewDialog.MinimumSize = s
            Dim b As Button = funcGetCloseButton()
            b.Left += initw
            'If gstructSettings.DemoMode = 2 Then
            'Buttons(0).Enabled = False
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
            '---------------------------------------------------------
        End Try

    End Sub

    'Public Function funcSetPrintDocument(ByVal objstructReportFormatIn As clsReportingMode.structReportFormat, _
    '              ByVal objDtmElamentInfo As DataTable, _
    '              ByVal objDtElamentDetails As DataTable, _
    '              ByVal intReportTypeIn As clsPrintDocument.enumReportType) As clsPrintDocument
    '    '=====================================================================
    '    ' Procedure Name        : funcSetPrintDocument
    '    ' Parameters Passed     : As above
    '    ' Returns               : True or false
    '    ' Purpose               : To set the clsPrintDocument object
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Mangesh Shardul At Machine SOFT1
    '    ' Created               : Monday, January 31, 2005
    '    ' Revisions             : 1
    '    '=====================================================================
    '    Dim intCount As Integer
    '    Dim objDtTable2In As DataTable
    '    Dim objclsPrintDocument As New clsPrintDocument

    '    Dim FontStyles As System.Drawing.Font '= Me.DefaultFont
    '    Dim ReportHeaderFont As Font
    '    Try
    '        objstructReportFormatIn.IsDisplayCompanyLogo = True
    '        objstructReportFormatIn.IsDisplayReportDate = True
    '        objstructReportFormatIn.IsDisplayReportFooter = True
    '        objstructReportFormatIn.IsDisplayReportTitle = True
    '        objstructReportFormatIn.IsDisplaySecondReportTitle = True
    '        objstructReportFormatIn.IsDisplaySubsequentPageHeader = True
    '        objstructReportFormatIn.LogoAlignment = 1
    '        objstructReportFormatIn.PageBottomMargin = 0.5
    '        objstructReportFormatIn.PageLeftMargin = 0.32
    '        objstructReportFormatIn.PageTopMargin = 1
    '        objstructReportFormatIn.LogoFileName = "D:\ALDYS\AAS 203 Borland Windows SW\win203.5\BMP\BMP\CHEMITO.BMP"

    '        objclsPrintDocument.ReportFormat = objstructReportFormatIn
    '        objclsPrintDocument.PageHeader = strPageHeaderIn
    '        objclsPrintDocument.PageText = strPageTextIn
    '        objclsPrintDocument.DisplayFont = ReportHeaderFont
    '        objclsPrintDocument.TableHeaderFont = FontStyles
    '        objclsPrintDocument.ReportImageList = objDtImagesListIn
    '        objclsPrintDocument.ReportType = intReportTypeIn
    '        objclsPrintDocument.ReportLayoutType = clsPrintDocument.enumReportLayoutType.Portrate

    '        '---Set Property ReportDataTables
    '        If IsNothing(arrDtTablesListIn) = False Then
    '            objclsPrintDocument.ReportDataTables = New ArrayList

    '            'For intCount = 0 To arrDtTablesListIn.Count - 1
    '            '    objDtTable2In = arrDtTablesListIn.Item(intCount)
    '            '    If IsNothing(objDtTable2In) = False Then
    '            '        objclsPrintDocument.ReportDataTables.Add(objDtTable2In)
    '            '    End If
    '            'Next intCount
    '        End If

    '        '---Set Property ReportGraphControls
    '        If IsNothing(arrGraphControlsListIn) = False Then
    '            objclsPrintDocument.ReportGraphControls = New ArrayList
    '            For intCount = 0 To arrGraphControlsListIn.Count - 1
    '                If IsNothing(arrGraphControlsListIn.Item(intCount)) = False Then
    '                    objclsPrintDocument.ReportGraphControls.Add(arrGraphControlsListIn.Item(intCount))
    '                End If
    '            Next intCount
    '        End If

    '        funcGetCookBookStruct(objDtmElamentInfo, objDtElamentDetails)
    '        Return objclsPrintDocument

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        Return Nothing
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        If Not IsNothing(objclsPrintDocument) = True Then
    '            objclsPrintDocument.Dispose()
    '        End If
    '        '---------------------------------------------------------
    '    End Try

    'End Function

    Private Function funcGetCloseButton() As Button
        Dim objFieldInfo As FieldInfo
        Dim objButton As System.Windows.Forms.Button

        Try
            objFieldInfo = GetType(System.Windows.Forms.PrintPreviewDialog).GetField("closeButton", BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance)

            objButton = CType(objFieldInfo.GetValue(printPreviewDialog), System.Windows.Forms.Button)

            Return objButton

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

    Private Sub subSetActiveReportProperties()
        '=====================================================================
        ' Procedure Name 	: SetActiveReportProperties
        ' Author			: Mangesh Shardul
        ' Date/Time			: 28-Feb-2005 04:45 pm
        ' Description		: 
        '=====================================================================
        Try
            mobjARPortrateReport = New ActiveReport2

            'mobjARPortrateReport.PageSettings.PaperKind = Printing.PaperKind.A4
            'mobjARPortrateReport.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait
            'mobjARPortrateReport.PageSettings.PaperSource = Printing.PaperSourceKind.Custom

            ''//----- Added by Sachin Dokhale 
            'mobjARPortrateReport.PageSettings.Margins.Left = CSng(mobjstructReportFormat.PageLeftMargin * 100)
            'mobjARPortrateReport.PageSettings.Margins.Bottom = CSng(mobjstructReportFormat.PageBottomMargin * 100)
            'mobjARPortrateReport.PageSettings.Margins.Right = 50
            'mobjARPortrateReport.PageSettings.Margins.Top = CSng(mobjstructReportFormat.PageTopMargin * 100)
            ''//-----

            '//----- Added by Sachin Dokhale on 27.01.07

            mobjARPortrateReport.PageSettings.PaperKind = PageSetting.PaperSize.Kind    '  .PaperKind.A4
            'DataDynamics.ActiveReports.Document.PageOrientation.Portrait.
            Dim objPageOrientation As DataDynamics.ActiveReports.Document.PageOrientation
            If PageSetting.Landscape = True Then
                objPageOrientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape
            Else
                objPageOrientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape
            End If
            mobjARPortrateReport.PageSettings.Orientation = objPageOrientation

            mobjARPortrateReport.PageSettings.PaperSource = PageSetting.PaperSource.Kind    'Printing.PaperSourceKind.Custom

            mobjARPortrateReport.PageSettings.Margins.Left = PageSetting.Margins.Left  'CSng(mobjstructReportFormat.PageLeftMargin * 100)
            mobjARPortrateReport.PageSettings.Margins.Bottom = PageSetting.Margins.Bottom    'CSng(mobjstructReportFormat.PageBottomMargin * 100)
            mobjARPortrateReport.PageSettings.Margins.Right = PageSetting.Margins.Right ' 50
            mobjARPortrateReport.PageSettings.Margins.Top = PageSetting.Margins.Top   'CSng(mobjstructReportFormat.PageTopMargin * 100)
            '//--- Check for color printing setting
            PrinterType = gstructSettings.blnSelectColorPrinter

            '//-----
            'mobjARLandScapeReport = New ARrptTablePropertiesLandScape
            'mobjARLandScapeReport.PageSettings.PaperKind = Printing.PaperKind.A4
            'mobjARLandScapeReport.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape
            'mobjARLandScapeReport.PageSettings.PaperSource = Printing.PaperSourceKind.Custom

            '//----- Added by Sachin Dokhale 
            'mobjARLandScapeReport.PageSettings.Margins.Left = CSng(mobjstructReportFormat.PageLeftMargin * 100)
            'mobjARLandScapeReport.PageSettings.Margins.Bottom = CSng(mobjstructReportFormat.PageBottomMargin * 100)
            'mobjARLandScapeReport.PageSettings.Margins.Right = 50
            'mobjARLandScapeReport.PageSettings.Margins.Top = CSng(mobjstructReportFormat.PageTopMargin * 100)
            '//-----
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

#Region " Private Functions "

    Protected Overrides Sub OnBeginPrint(ByVal e As System.Drawing.Printing.PrintEventArgs)
        Try
            If mblnIsBeginPrint = True Then
                e.Cancel = False
            Else
                e.Cancel = True
                Call PrintToPrinter()
            End If

            MyBase.OnBeginPrint(e)
            mintPageCount = 0
            NextFirstCol = 0
            npp = 0
            CurRow = 0
            CurCol = 0
            mintReportTablesCount = 0
            mintReportTextTableCount = 0
            mintImageCounter = 0
            mintCurrentImageRow = 0
            mintReportGraphsCount = 0

            printFont = Me.DisplayFont
            headerFont = Me.TableHeaderFont
            'headerFont.Bold = Me.TableHeaderFont.Bold
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

    Protected Overrides Sub OnEndPrint(ByVal e As System.Drawing.Printing.PrintEventArgs)
        mblnIsBeginPrint = False
    End Sub

    Protected Overrides Sub OnQueryPageSettings(ByVal e As System.Drawing.Printing.QueryPageSettingsEventArgs)
        Dim objARLayoutReport As DataDynamics.ActiveReports.ActiveReport

        Try
            'e.PageSettings.Landscape = False
            'mintReportLayoutType = enumReportLayoutType.Portrate

            'Select Case mintReportLayoutType
            '    Case enumReportLayoutType.Portrate
            '        objARLayoutReport = mobjARPortrateReport

            '    Case enumReportLayoutType.Landscape
            '        'objARLayoutReport = mobjARLandScapeReport
            'End Select
            'e.PageSettings.Landscape = False
            If e.PageSettings.Landscape Then
                mintReportLayoutType = enumReportLayoutType.Portrate
            Else
                mintReportLayoutType = enumReportLayoutType.Portrate
            End If

            Select Case mintReportLayoutType
                Case enumReportLayoutType.Portrate
                    objARLayoutReport = mobjARPortrateReport

                Case enumReportLayoutType.Landscape
                    objARLayoutReport = mobjARPortrateReport    'mobjARLandScapeReport
            End Select


            e.PageSettings.Margins.Left = CInt(objARLayoutReport.PageSettings.Margins.Left)
            e.PageSettings.Margins.Right = CInt(objARLayoutReport.PageSettings.Margins.Right)
            e.PageSettings.Margins.Top = CInt(objARLayoutReport.PageSettings.Margins.Top)
            e.PageSettings.Margins.Bottom = CInt(objARLayoutReport.PageSettings.Margins.Bottom)

            'Dim intCount As Integer
            'For intCount = 0 To e.PageSettings.PrinterSettings.PaperSizes.Count - 1
            '    If e.PageSettings.PrinterSettings.PaperSizes.Item(intCount).Kind = PaperKind.A4 Then
            '        e.PageSettings.PaperSize = e.PageSettings.PrinterSettings.PaperSizes.Item(intCount)
            '        Exit For
            '    End If

            'Next intCount
            'e.PageSettings.PaperSize = e.PageSettings.PrinterSettings.PaperSizes.Item(intCount)
            e.PageSettings.PrinterSettings = PageSetting.PrinterSettings()  'objARLayoutReport.Document.Printer.PrinterSettings


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

    Protected Overrides Sub OnPrintPage(ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim yPosition As Single = 0
        Dim sngPageHeaderYPosition As Single

        Dim leftMargin As Single = e.MarginBounds.Left
        Dim topMargin As Single = e.MarginBounds.Top

        Dim BottomMargin As Single = e.MarginBounds.Bottom

        Try
            mintPageCount += 1
            '//----- Set the initialy PageTest height to 0
            mintTotalHeightOfPageText = 0
            '//-----
            Call MyBase.OnPrintPage(e)

            '---1.Draw the Report Logo Image
            ' Call funcDrawReportLogoImage(e.Graphics, leftMargin, topMargin)

            'If Not (mintReportType = enumReportType.CookBook) Then


            '---2.Draw the Report Header
            Call funcDrawReportHeader(e.Graphics, leftMargin, topMargin, sngPageHeaderYPosition, mintReportLayoutType)

            '---3.Draw the Page Header
            sngPageHeaderYPosition = funcDrawPageHeader(e.Graphics, leftMargin, topMargin, sngPageHeaderYPosition, mintReportLayoutType)
            'End If

            '---Draw Page Footer
            Call funcDrawPageFooter(e.Graphics, leftMargin, BottomMargin, mintReportLayoutType)

            '---2.Draw the Report Footer
            Call funcDrawReportFooter(e.Graphics, leftMargin, BottomMargin, mintReportLayoutType)


            e.HasMorePages = False
            yPosition = sngPageHeaderYPosition '+ lineSpacing + (4 * printFont.GetHeight(e.Graphics))


            '---4.Draw the Page Text for Cook Book
            If mintReportType = enumReportType.CookBook Then
                funcDrawPageText_CookBook(e, yPosition, leftMargin, topMargin, BottomMargin, mintReportLayoutType)
                yPosition += lineSpacing + printFont.GetHeight(e.Graphics)
                Call mobjReportBrush.Dispose()
                Exit Sub
            ElseIf mintReportType = enumReportType.DataFile Then
                funcDrawTextList(e, yPosition, leftMargin)

                If e.HasMorePages = False Then
                    yPosition += lineSpacing + printFont.GetHeight(e.Graphics)
                    Call funcDrawGridTables(e, yPosition, leftMargin)
                End If

                yPosition += lineSpacing + printFont.GetHeight(e.Graphics)
                Call mobjReportBrush.Dispose()
                Exit Sub
            ElseIf mintReportType = enumReportType.StadardGraph Then
                'funcDrawTextList(e, yPosition, leftMargin)
                'yPosition += lineSpacing + printFont.GetHeight(e.Graphics)
                funcDrawTextList(e, yPosition, leftMargin)

                If e.HasMorePages = False Then
                    Call funcDrawAllGraphs(e, yPosition, leftMargin)
                End If

                If e.HasMorePages = False Then
                    yPosition += lineSpacing + printFont.GetHeight(e.Graphics)
                    Call funcDrawPageText(e, leftMargin, yPosition, mintReportLayoutType)
                End If
                If e.HasMorePages = False Then
                    yPosition += lineSpacing + printFont.GetHeight(e.Graphics)
                    Call funcDrawGridTables(e, yPosition, leftMargin)
                End If
                yPosition += lineSpacing + printFont.GetHeight(e.Graphics)
                Call mobjReportBrush.Dispose()
                Exit Sub

            ElseIf mintReportType = enumReportType.PrintPeak_Valley Then


                'If e.HasMorePages = False Then
                '    yPosition += lineSpacing + printFont.GetHeight(e.Graphics)
                '    Call funcDrawPageText(e, leftMargin, yPosition, mintReportLayoutType)
                '    yPosition += lineSpacing + printFont.GetHeight(e.Graphics)
                'End If

                funcDrawTextList(e, yPosition, leftMargin)

                If e.HasMorePages = False Then
                    Call funcDrawAllGraphs(e, yPosition, leftMargin)
                End If

                If e.HasMorePages = False Then
                    yPosition += lineSpacing + printFont.GetHeight(e.Graphics)
                    Call funcDrawPageText(e, leftMargin, yPosition, mintReportLayoutType)
                End If
                'If e.HasMorePages = False Then
                '    yPosition += lineSpacing + printFont.GetHeight(e.Graphics)
                '    Call funcDrawGridTables(e, yPosition, leftMargin)
                'End If
                If e.HasMorePages = False Then
                    yPosition += lineSpacing + printFont.GetHeight(e.Graphics)
                    Call funcDrawPageText(e, leftMargin, yPosition, mintReportLayoutType)
                    yPosition += lineSpacing + printFont.GetHeight(e.Graphics)
                End If
                yPosition += lineSpacing + printFont.GetHeight(e.Graphics)
                Call mobjReportBrush.Dispose()

            ElseIf mintReportType = enumReportType.UVSpectrum Or _
                mintReportType = enumReportType.EnergySpectrum Or _
                mintReportType = enumReportType.Histograph Or _
                mintReportType = enumReportType.D2Peak Or _
                mintReportType = enumReportType.TimescanGraph Then

                'If e.HasMorePages = False Then
                '    yPosition += lineSpacing + printFont.GetHeight(e.Graphics)
                '    Call funcDrawPageText(e, leftMargin, yPosition, mintReportLayoutType)
                '    yPosition += lineSpacing + printFont.GetHeight(e.Graphics)
                'End If

                funcDrawTextList(e, yPosition, leftMargin)

                If e.HasMorePages = False Then
                    Call funcDrawAllGraphs(e, yPosition, leftMargin)
                End If


                'If e.HasMorePages = False Then
                '    yPosition += lineSpacing + printFont.GetHeight(e.Graphics)
                '    Call funcDrawGridTables(e, yPosition, leftMargin)
                'End If
                If e.HasMorePages = False Then
                    yPosition += lineSpacing + printFont.GetHeight(e.Graphics)
                    Call funcDrawPageText(e, leftMargin, yPosition, mintReportLayoutType)
                    yPosition += lineSpacing + printFont.GetHeight(e.Graphics)
                End If
                yPosition += lineSpacing + printFont.GetHeight(e.Graphics)
                Call mobjReportBrush.Dispose()
                Exit Sub
            ElseIf mintReportType = enumReportType.RepeatResults Then
                'funcDrawTextList(e, yPosition, leftMargin)
                ' funcDrawTextList(e, yPosition, leftMargin)

                funcDrawRepeatDataText(e, yPosition, leftMargin)
                'If e.HasMorePages = False Then
                '    yPosition += lineSpacing + printFont.GetHeight(e.Graphics)
                '    Call funcDrawGridTables(e, yPosition, leftMargin)
                'End If

                yPosition += lineSpacing + printFont.GetHeight(e.Graphics)
                Call mobjReportBrush.Dispose()
                Exit Sub
            Else

                Call funcDrawPageText(e, leftMargin, yPosition, mintReportLayoutType)
            End If


            ' e.HasMorePages = True
            '---DataGrid Printing
            yPosition += lineSpacing + printFont.GetHeight(e.Graphics)

            '---5.Draw the Grid Tables from DataTable
            If e.HasMorePages = False Then
                Call funcDrawGridTables(e, yPosition, leftMargin)
            End If

            '//----- Modified by Sachin Dokhale
            '---6.Graph Printing
            If e.HasMorePages = False Then
                'Call funcDrawAllGraphs(e, yPosition, leftMargin)
            End If
            '//-----

            '//----- Modified by Sachin Dokhale
            '---7.Images Printing
            '//----- Modified by Sachin Dokhale on 8.1.06
            'If mintReportType = enumReportType.Shade555SortResults Then

            '    Call funcDrawAllImages(e, yPosition, leftMargin)
            'Else
            '    '//-----
            '    If e.HasMorePages = False Then
            '        If funcDrawAllImages(e, yPosition, leftMargin) = True Then
            '            'e.HasMorePages = intIsPageReapate
            '        End If
            '    End If
            'End If
            '//-----

            'If mintCurrentImageRow <> 0 Or mintCurrentGraph <> 0 Then
            '    e.HasMorePages = True
            'End If

            '---8.Release resources used by Solid Brush object
            Call mobjReportBrush.Dispose()

            'Catch ex As Exception
            '    MessageBox.Show(ex.Message.ToString())
            'End Try
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

    Private Function funcDrawReportLogoImage(ByRef G As Graphics, ByVal sngLeftMarginIn As Single, ByVal sngTopMarginIn As Single) As Boolean
        'Draw the Report Logo Image
        Dim rectReportLogo As Drawing.RectangleF
        Dim imgReportLogoImage As Image
        Dim objARLayoutReport As DataDynamics.ActiveReports.ActiveReport

        Try
            If mintReportLayoutType = enumReportLayoutType.Portrate Then
                objARLayoutReport = mobjARPortrateReport
            ElseIf mintReportLayoutType = enumReportLayoutType.Landscape Then
                'objARLayoutReport = mobjARLandScapeReport
            End If
            If mobjstructReportFormat.IsDisplayCompanyLogo = True Then
                rectReportLogo = CType(objARLayoutReport.Sections("ReportHeader").Controls("pictLogo"), DataDynamics.ActiveReports.Picture).GetBounds
                '---All distances In Active Reports are in Inches
                '---And 1 inch. = 96 Pixels
                rectReportLogo.X = rectReportLogo.X * 96 + sngLeftMarginIn
                rectReportLogo.Y = rectReportLogo.Y * 96 + sngTopMarginIn

                rectReportLogo.Height = rectReportLogo.Height * 96
                rectReportLogo.Width = rectReportLogo.Width * 96

                If System.IO.File.Exists(mobjstructReportFormat.LogoFileName) = True Then
                    imgReportLogoImage = Image.FromFile(mobjstructReportFormat.LogoFileName)
                    G.DrawImage(imgReportLogoImage, rectReportLogo)
                Else
                    ''imgReportLogoImage = mobjstructReportFormat.DefaultLogoImage
                End If
            End If

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

    Private Function funcDrawReportHeader(ByRef G As Graphics, ByVal sngLeftMarginIn As Single, ByVal sngTopMarginIn As Single, ByRef sngReportHeaderLineY As Single, ByVal intReportLayoutType As enumReportLayoutType) As Boolean
        Dim rectReportHeader As Drawing.RectangleF
        Dim rectReportHeader2 As Drawing.RectangleF
        Dim rectReportHeader3 As Drawing.RectangleF
        Dim rectReportHeader4 As Drawing.RectangleF
        Dim ReportHeaderFont As Font
        Dim ReportHeaderFont2 As Font
        Dim ReportHeaderFont3 As Font
        Dim ReportHeaderFont4 As Font

        Dim ReportHeaderLineX1 As Single = 0.0
        Dim ReportHeaderLineY1 As Single = 0.0
        Dim ReportHeaderLineX2 As Single = 0.0
        Dim ReportHeaderLineY2 As Single = 0.0
        Dim strReportHeader As String
        Dim strReportHeader2 As String
        Dim strReportHeader3 As String
        Dim strReportHeader4 As String
        Dim strInstrumentName As String
        'Dim sngReportHeaderLineY As Single

        Dim objARLayoutReport As DataDynamics.ActiveReports.ActiveReport
        Try
            Select Case intReportLayoutType
                Case enumReportLayoutType.Portrate
                    objARLayoutReport = mobjARPortrateReport
                Case enumReportLayoutType.Landscape
                    'objARLayoutReport = mobjARLandScapeReport
            End Select
            sngReportHeaderLineY = sngTopMarginIn
            If mobjstructReportFormat.IsDisplayReportHeader = False Then
                Return True
            End If

            rectReportHeader = CType(objARLayoutReport.Sections("ReportHeader").Controls("lblReportHeader"), DataDynamics.ActiveReports.Label).GetBounds
            ReportHeaderFont = CType(objARLayoutReport.Sections("ReportHeader").Controls("lblReportHeader"), DataDynamics.ActiveReports.Label).Font

            rectReportHeader2 = CType(objARLayoutReport.Sections("ReportHeader").Controls("lblReportHeader2"), DataDynamics.ActiveReports.Label).GetBounds
            ReportHeaderFont2 = CType(objARLayoutReport.Sections("ReportHeader").Controls("lblReportHeader2"), DataDynamics.ActiveReports.Label).Font

            rectReportHeader3 = CType(objARLayoutReport.Sections("ReportHeader").Controls("lblReportHeader3"), DataDynamics.ActiveReports.Label).GetBounds
            ReportHeaderFont3 = CType(objARLayoutReport.Sections("ReportHeader").Controls("lblReportHeader3"), DataDynamics.ActiveReports.Label).Font

            rectReportHeader4 = CType(objARLayoutReport.Sections("ReportHeader").Controls("lblReportHeader4"), DataDynamics.ActiveReports.Label).GetBounds
            ReportHeaderFont4 = CType(objARLayoutReport.Sections("ReportHeader").Controls("lblReportHeader4"), DataDynamics.ActiveReports.Label).Font


            rectReportHeader.X = rectReportHeader.X * 96 + sngLeftMarginIn
            rectReportHeader.Y = rectReportHeader.Y * 96 + sngTopMarginIn
            rectReportHeader.Height = rectReportHeader.Height * 96
            rectReportHeader.Width = rectReportHeader.Width * 96

            rectReportHeader2.X = rectReportHeader2.X * 96 + sngLeftMarginIn
            rectReportHeader2.Y = rectReportHeader2.Y * 96 + sngTopMarginIn
            rectReportHeader2.Height = rectReportHeader2.Height * 96
            rectReportHeader2.Width = rectReportHeader2.Width * 96

            rectReportHeader3.X = rectReportHeader3.X * 96 + sngLeftMarginIn
            rectReportHeader3.Y = rectReportHeader3.Y * 96 + sngTopMarginIn
            rectReportHeader3.Height = rectReportHeader3.Height * 96
            rectReportHeader3.Width = rectReportHeader3.Width * 96

            rectReportHeader4.X = rectReportHeader4.X * 96 + sngLeftMarginIn
            rectReportHeader4.Y = rectReportHeader4.Y * 96 + sngTopMarginIn
            rectReportHeader4.Height = rectReportHeader4.Height * 96
            rectReportHeader4.Width = rectReportHeader4.Width * 96

            'strInstrumentName = "AAS 203"
            'strInstrumentName = m_strSubPageHeader2.TextString

            'strReportHeader = "Chemito Technologies Pvt. Ltd." & vbCrLf & "Satpur MIDC" & vbCrLf & "Nasik"
            strReportHeader = m_strPageHeader.TextString

            'strReportHeader2 = "AAS 203"
            strReportHeader2 = m_strSubPageHeader2.TextString

            'strReportHeader3 = "Instrument : " & strInstrumentName & vbCrLf & _
            '"Analyst Name : " & " "
            strReportHeader3 = m_strSubPageHeader2.TextString

            If mobjstructReportFormat.IsDisplayReportDate = True Then
                strReportHeader4 = "Date : " & Now.Date.ToLongDateString & vbCrLf & _
                    "Time : " & Format(Now(), "hh:mm tt")
            Else
                strReportHeader4 = ""
            End If

            Dim objBrush As Drawing.Brush
            objBrush = New Pen(mobjReportBrush.Color).Brush
            'Dim HeaderStringFormat As New StringFormat
            'HeaderStringFormat.Alignment = d
            Select Case m_strPageHeader.TextFormat.Alignment
                Case ContentAlignment.BottomCenter, ContentAlignment.MiddleCenter, ContentAlignment.TopCenter
                    rectReportHeader.X = CInt(Fix((rectReportHeader.X + rectReportHeader.Width) / 2)) - 100
                Case ContentAlignment.BottomLeft, ContentAlignment.MiddleLeft, ContentAlignment.TopLeft
                    rectReportHeader.X = CSng(Fix(sngLeftMarginIn))     'CSng(Fix(rectReportHeader.X))
                Case ContentAlignment.BottomRight, ContentAlignment.MiddleRight, ContentAlignment.TopRight
                    rectReportHeader.X = CSng((Me.PageSetting.PaperSize.Width * 100) - (rectReportHeader.Width + 10))
                Case Else

            End Select
            If Not strReportHeader = "" Then
                objBrush = New Pen(mobjReportBrush.Color).Brush
                G.DrawString(strReportHeader, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)
                sngReportHeaderLineY = rectReportHeader.Y + rectReportHeader.Height
            End If
            If Not strReportHeader2 = "" Then
                objBrush = New Pen(mobjReportBrush.Color).Brush
                G.DrawString(strReportHeader2, ReportHeaderFont2, objBrush, rectReportHeader2, New StringFormat)
                sngReportHeaderLineY = rectReportHeader2.Y + rectReportHeader2.Height
            End If
            If Not strReportHeader3 = "" Then
                objBrush = New Pen(mobjReportBrush.Color).Brush
                G.DrawString(strReportHeader3, ReportHeaderFont3, objBrush, rectReportHeader3, New StringFormat)
                sngReportHeaderLineY = rectReportHeader3.Y + rectReportHeader3.Height
            End If
            If Not strReportHeader4 = "" Then
                objBrush = New Pen(mobjReportBrush.Color).Brush
                G.DrawString(strReportHeader4, ReportHeaderFont4, objBrush, rectReportHeader4, New StringFormat)
                sngReportHeaderLineY = rectReportHeader4.Y + rectReportHeader4.Height
            End If

            ReportHeaderLineX1 = CType(objARLayoutReport.Sections("ReportHeader").Controls("ReportHeaderLine"), DataDynamics.ActiveReports.Line).X1 * 96 + sngLeftMarginIn
            'ReportHeaderLineY1 = CType(objARLayoutReport.Sections("ReportHeader").Controls("ReportHeaderLine"), DataDynamics.ActiveReports.Line).Y1 * 96 + sngTopMarginIn
            ReportHeaderLineX2 = CType(objARLayoutReport.Sections("ReportHeader").Controls("ReportHeaderLine"), DataDynamics.ActiveReports.Line).X2 * 96 + sngLeftMarginIn
            'ReportHeaderLineY2 = CType(objARLayoutReport.Sections("ReportHeader").Controls("ReportHeaderLine"), DataDynamics.ActiveReports.Line).Y2 * 96 + sngTopMarginIn
            ReportHeaderLineY1 = sngReportHeaderLineY
            ReportHeaderLineY2 = sngReportHeaderLineY

            G.DrawLine(New Pen(objBrush, 2.5), ReportHeaderLineX1, ReportHeaderLineY1, ReportHeaderLineX2, ReportHeaderLineY2)


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

    Private Function funcDrawReportFooter(ByRef G As Graphics, ByVal sngLeftMarginIn As Single, ByVal sngTopMarginIn As Single, ByVal intReportLayoutType As enumReportLayoutType) As Boolean
        Dim rectReportFooter As Drawing.RectangleF
        Dim rectReportHeader2 As Drawing.RectangleF
        Dim rectReportHeader3 As Drawing.RectangleF
        Dim rectReportHeader4 As Drawing.RectangleF
        Dim ReportFooterFont As Font
        Dim ReportHeaderFont2 As Font
        Dim ReportHeaderFont3 As Font
        Dim ReportHeaderFont4 As Font

        Dim ReportFooterLineX1 As Single = 0.0
        Dim ReportFooterLineY1 As Single = 0.0
        Dim ReportFooterLineX2 As Single = 0.0
        Dim ReportFooterLineY2 As Single = 0.0
        Dim strReportFooter As String
        Dim objBrush As Drawing.Brush


        Dim objARLayoutReport As DataDynamics.ActiveReports.ActiveReport
        Try
            Select Case intReportLayoutType
                Case enumReportLayoutType.Portrate
                    objARLayoutReport = mobjARPortrateReport
                Case enumReportLayoutType.Landscape
                    'objARLayoutReport = mobjARLandScapeReport
            End Select

            If mobjstructReportFormat.IsDisplayReportFooter = False Then
                Return True
            Else
                
            End If



            'rectReportHeader2 = CType(objARLayoutReport.Sections("ReportHeader").Controls("lblReportHeader2"), DataDynamics.ActiveReports.Label).GetBounds
            'ReportHeaderFont2 = CType(objARLayoutReport.Sections("ReportHeader").Controls("lblReportHeader2"), DataDynamics.ActiveReports.Label).Font

            'rectReportHeader3 = CType(objARLayoutReport.Sections("ReportHeader").Controls("lblReportHeader3"), DataDynamics.ActiveReports.Label).GetBounds
            'ReportHeaderFont3 = CType(objARLayoutReport.Sections("ReportHeader").Controls("lblReportHeader3"), DataDynamics.ActiveReports.Label).Font

            'rectReportHeader4 = CType(objARLayoutReport.Sections("ReportHeader").Controls("lblReportHeader4"), DataDynamics.ActiveReports.Label).GetBounds
            'ReportHeaderFont4 = CType(objARLayoutReport.Sections("ReportHeader").Controls("lblReportHeader4"), DataDynamics.ActiveReports.Label).Font

            ReportFooterLineX1 = CType(objARLayoutReport.Sections("ReportFooter").Controls("ReportFooterLine"), DataDynamics.ActiveReports.Line).X1 * 96 + sngLeftMarginIn
            ReportFooterLineY1 = CType(objARLayoutReport.Sections("ReportFooter").Controls("ReportFooterLine"), DataDynamics.ActiveReports.Line).Y1 * 96 + sngTopMarginIn
            'ReportFooterLineY1 = CType(objARLayoutReport.Sections("PageFooter").Controls("PageFooterLine"), DataDynamics.ActiveReports.Line).Y1 * 96 + sngTopMarginIn
            ReportFooterLineX2 = CType(objARLayoutReport.Sections("ReportFooter").Controls("ReportFooterLine"), DataDynamics.ActiveReports.Line).X2 * 96 + sngLeftMarginIn
            ReportFooterLineY2 = CType(objARLayoutReport.Sections("ReportFooter").Controls("ReportFooterLine"), DataDynamics.ActiveReports.Line).Y2 * 96 + sngTopMarginIn
            'ReportFooterLineY2 = CType(objARLayoutReport.Sections("PageFooter").Controls("PageFooterLine"), DataDynamics.ActiveReports.Line).Y2 * 96 + sngTopMarginIn

            objBrush = New Pen(mobjReportBrush.Color).Brush
            G.DrawLine(New Pen(objBrush, 2.5), ReportFooterLineX1, ReportFooterLineY1, ReportFooterLineX2, ReportFooterLineY2)

            rectReportFooter = CType(objARLayoutReport.Sections("ReportFooter").Controls("lblReportFooter"), DataDynamics.ActiveReports.Label).GetBounds
            ReportFooterFont = CType(objARLayoutReport.Sections("ReportFooter").Controls("lblReportFooter"), DataDynamics.ActiveReports.Label).Font

            rectReportFooter.Y = ReportFooterLineY2 + 6
            rectReportFooter.X = rectReportFooter.X * 96 + sngLeftMarginIn
            'rectReportFooter.Y = ReportFooterLineY2 * 96 + sngBottomMarginIn
            rectReportFooter.Height = rectReportFooter.Height * 96
            rectReportFooter.Width = rectReportFooter.Width * 96

            'strReportHeader = "Chemito Technologies Pvt. Ltd." & vbCrLf & "Satpur MIDC" & vbCrLf & "Nasik"
            If Not (m_strReportFooter.TextString Is Nothing) Then
                strReportFooter = m_strReportFooter.TextString

                'strReportHeader2 = "AAS 203"


                'strReportHeader3 = "Instrument : " & strInstrumentName & vbCrLf & _
                '"Analyst Name : " & " "

                'If mobjstructReportFormat.IsDisplayReportDate = True Then
                '    strReportHeader4 = "Date : " & Now.Date.ToLongDateString & vbCrLf & _
                '        "Time : " & Format(Now(), "hh:mm tt")
                'Else
                '    strReportHeader4 = ""
                'End If


                'Dim HeaderStringFormat As New StringFormat
                'HeaderStringFormat.Alignment = d
                Select Case m_strReportFooter.TextFormat.Alignment
                    Case ContentAlignment.BottomCenter, ContentAlignment.MiddleCenter, ContentAlignment.TopCenter
                        rectReportFooter.X = CInt(Fix((rectReportFooter.X + rectReportFooter.Width) / 2)) - 100
                    Case ContentAlignment.BottomLeft, ContentAlignment.MiddleLeft, ContentAlignment.TopLeft
                        rectReportFooter.X = CSng(Fix(rectReportFooter.X))
                    Case ContentAlignment.BottomRight, ContentAlignment.MiddleRight, ContentAlignment.TopRight
                        rectReportFooter.X = CSng((Me.PageSetting.PaperSize.Width * 100) - (rectReportFooter.Width + 10))
                End Select
                objBrush = New Pen(mobjReportBrush.Color).Brush
                G.DrawString(strReportFooter, ReportFooterFont, objBrush, rectReportFooter, New StringFormat)
            End If
            If ReportFooterLineY1 > 0 Then
                mintPageFooterYPosotion = CInt(ReportFooterLineY1)
            End If

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

    Private Function funcDrawReportHeader2(ByRef G As Graphics, ByVal sngLeftMarginIn As Single, ByVal sngTopMarginIn As Single, ByVal intReportLayoutType As enumReportLayoutType) As Boolean
        Dim rectReportHeader As Drawing.RectangleF
        Dim rectReportHeader2 As Drawing.RectangleF
        Dim rectReportHeader3 As Drawing.RectangleF
        Dim rectReportHeader4 As Drawing.RectangleF
        Dim ReportHeaderFont As Font
        Dim ReportHeaderFont2 As Font
        Dim ReportHeaderFont3 As Font
        Dim ReportHeaderFont4 As Font

        Dim ReportHeaderLineX1 As Single = 0.0
        Dim ReportHeaderLineY1 As Single = 0.0
        Dim ReportHeaderLineX2 As Single = 0.0
        Dim ReportHeaderLineY2 As Single = 0.0
        Dim strReportHeader As String
        Dim strReportHeader2 As String
        Dim strReportHeader3 As String
        Dim strReportHeader4 As String
        Dim strInstrumentName As String

        Dim objARLayoutReport As DataDynamics.ActiveReports.ActiveReport
        Try
            Select Case intReportLayoutType
                Case enumReportLayoutType.Portrate
                    objARLayoutReport = mobjARPortrateReport
                Case enumReportLayoutType.Landscape
                    'objARLayoutReport = mobjARLandScapeReport
            End Select

            rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("TextBox1"), DataDynamics.ActiveReports.TextBox).GetBounds
            ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("TextBox1"), DataDynamics.ActiveReports.TextBox).Font

            rectReportHeader2 = CType(objARLayoutReport.Sections("Detail").Controls("TextBox2"), DataDynamics.ActiveReports.TextBox).GetBounds
            ReportHeaderFont2 = CType(objARLayoutReport.Sections("Detail").Controls("TextBox2"), DataDynamics.ActiveReports.TextBox).Font

            rectReportHeader3 = CType(objARLayoutReport.Sections("Detail").Controls("Label1"), DataDynamics.ActiveReports.Label).GetBounds
            ReportHeaderFont3 = CType(objARLayoutReport.Sections("Detail").Controls("Label1"), DataDynamics.ActiveReports.Label).Font

            rectReportHeader.X = rectReportHeader.X * 96 + sngLeftMarginIn
            rectReportHeader.Y = rectReportHeader.Y * 96 + sngTopMarginIn
            rectReportHeader.Height = rectReportHeader.Height * 96
            rectReportHeader.Width = rectReportHeader.Width * 96

            rectReportHeader2.X = rectReportHeader2.X * 96 + sngLeftMarginIn
            rectReportHeader2.Y = rectReportHeader2.Y * 96 + sngTopMarginIn
            rectReportHeader2.Height = rectReportHeader2.Height * 96
            rectReportHeader2.Width = rectReportHeader2.Width * 96

            rectReportHeader3.X = rectReportHeader3.X * 96 + sngLeftMarginIn
            rectReportHeader3.Y = rectReportHeader3.Y * 96 + sngTopMarginIn
            rectReportHeader3.Height = rectReportHeader3.Height * 96
            rectReportHeader3.Width = rectReportHeader3.Width * 96

            strReportHeader = "adadadadad"
            strReportHeader2 = "adsadada"
            strReportHeader3 = "dgdgdgdgdgdg"

            Dim objBrush As Drawing.Brush
            objBrush = New Pen(mobjReportBrush.Color).Brush

            G.DrawString(strReportHeader, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)
            objBrush = New Pen(mobjReportBrush.Color).Brush
            G.DrawString(strReportHeader2, ReportHeaderFont2, objBrush, rectReportHeader2, New StringFormat)
            objBrush = New Pen(mobjReportBrush.Color).Brush
            G.DrawString(strReportHeader3, ReportHeaderFont3, objBrush, rectReportHeader3, New StringFormat)

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

    Private Function funcDrawPageHeader(ByRef G As Graphics, ByVal sngLeftMarginIn As Single, ByVal sngTopMarginIn As Single, ByRef sngReportHeaderLineY As Single, ByVal intReportLayoutType As enumReportLayoutType) As Single
        'Draw the Page Header
        Dim rectPageHeader As Drawing.RectangleF
        Dim PageHeaderFont As Font
        Dim sectionHeightReportHeader As Single = 0.0

        Dim objBrush As Drawing.Brush
        objBrush = New Pen(mobjReportBrush.Color).Brush

        Dim objARLayoutReport As DataDynamics.ActiveReports.ActiveReport
        Try
            Select Case intReportLayoutType
                Case enumReportLayoutType.Portrate
                    objARLayoutReport = mobjARPortrateReport
                Case enumReportLayoutType.Landscape
                    'objARLayoutReport = mobjARLandScapeReport
            End Select
            If mobjstructReportFormat.IsDisplayReportHeader = False Then
                Return 50
            End If
            '---if section changes then add previous sections Height to the Y-Position.
            'sectionHeightReportHeader = objARLayoutReport.Sections("ReportHeader").Height * 96
            sectionHeightReportHeader = objARLayoutReport.Sections("PageHeader").Height * 96

            'Draw the Page Header
            rectPageHeader = CType(objARLayoutReport.Sections("PageHeader").Controls("lblPageHeader"), DataDynamics.ActiveReports.Label).GetBounds
            PageHeaderFont = CType(objARLayoutReport.Sections("PageHeader").Controls("lblPageHeader"), DataDynamics.ActiveReports.Label).Font

            rectPageHeader.X = rectPageHeader.X * 96 + sngLeftMarginIn
            rectPageHeader.Y = sectionHeightReportHeader + sngTopMarginIn 'rectPageHeader.Y * 96 *
            rectPageHeader.Height = rectPageHeader.Height * 96 '* sectionHeightReportHeader
            rectPageHeader.Width = rectPageHeader.Width * 96

            'If Not mstrPageHeader = "" Then
            If Not mstrPageHeader = "" Then
                G.DrawString(mstrPageHeader, PageHeaderFont, objBrush, rectPageHeader, New StringFormat)
                'Return rectPageHeader.Bottom
                Return rectPageHeader.Bottom

            Else
                Return sngReportHeaderLineY
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return 0.0
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

    Private Function funcDrawPageFooter(ByRef G As Graphics, ByVal sngLeftMarginIn As Single, ByVal sngBottomMarginIn As Single, ByVal intReportLayoutTypeIn As enumReportLayoutType) As Boolean
        Dim rectPageFooter As Drawing.RectangleF
        Dim PageFooterFont As Font
        Dim rectPageNo As Drawing.RectangleF
        Dim PageNoFont As Font
        Dim PageFooterLineX1 As Single = 0.0
        Dim PageFooterLineY1 As Single = 0.0
        Dim PageFooterLineX2 As Single = 0.0
        Dim PageFooterLineY2 As Single = 0.0
        Dim strPageFooter As String = ""
        Dim strPageNo As String = ""
        Dim objBrush As Drawing.Brush

        objBrush = New Pen(mobjReportBrush.Color).Brush


        Try
            Dim objARLayoutReport As DataDynamics.ActiveReports.ActiveReport
            Select Case intReportLayoutTypeIn
                Case enumReportLayoutType.Portrate
                    objARLayoutReport = mobjARPortrateReport
                Case enumReportLayoutType.Landscape
                    'objARLayoutReport = mobjARLandScapeReport
            End Select
            If mobjstructReportFormat.IsDisplayReportFooter = True Then
                PageFooterLineX1 = CType(objARLayoutReport.Sections("PageFooter").Controls("PageFooterLine"), DataDynamics.ActiveReports.Line).X1 * 96 + sngLeftMarginIn
                PageFooterLineY1 = CType(objARLayoutReport.Sections("PageFooter").Controls("PageFooterLine"), DataDynamics.ActiveReports.Line).Y1 * 96 + sngBottomMarginIn
                'ReportFooterLineY2 = CType(objARLayoutReport.Sections("ReportFooter").Controls("ReportFooterLine"), DataDynamics.ActiveReports.Line).Y2 * 96 + sngTopMarginIn
                PageFooterLineX2 = CType(objARLayoutReport.Sections("PageFooter").Controls("PageFooterLine"), DataDynamics.ActiveReports.Line).X2 * 96 + sngLeftMarginIn
                PageFooterLineY2 = CType(objARLayoutReport.Sections("PageFooter").Controls("PageFooterLine"), DataDynamics.ActiveReports.Line).Y2 * 96 + sngBottomMarginIn
                'G.DrawLine(New Pen(objBrush, 2.5), PageFooterLineX1, PageFooterLineY1, PageFooterLineX2, PageFooterLineY2)
            Else
                PageFooterLineX1 = CType(objARLayoutReport.Sections("PageFooter").Controls("PageFooterLine"), DataDynamics.ActiveReports.Line).X1 * 96 + sngLeftMarginIn
                PageFooterLineY1 = CType(objARLayoutReport.Sections("PageFooter").Controls("PageFooterLine"), DataDynamics.ActiveReports.Line).Y1 * 96 + sngBottomMarginIn
                'ReportFooterLineY2 = CType(objARLayoutReport.Sections("ReportFooter").Controls("ReportFooterLine"), DataDynamics.ActiveReports.Line).Y2 * 96 + sngTopMarginIn
                PageFooterLineX2 = CType(objARLayoutReport.Sections("PageFooter").Controls("PageFooterLine"), DataDynamics.ActiveReports.Line).X2 * 96 + sngLeftMarginIn
                PageFooterLineY2 = CType(objARLayoutReport.Sections("PageFooter").Controls("PageFooterLine"), DataDynamics.ActiveReports.Line).Y2 * 96 + sngBottomMarginIn
                G.DrawLine(New Pen(objBrush, 2.5), PageFooterLineX1, PageFooterLineY1, PageFooterLineX2, PageFooterLineY2)
            End If

            rectPageFooter = CType(objARLayoutReport.Sections("PageFooter").Controls("lblPageFooter"), DataDynamics.ActiveReports.Label).GetBounds
            PageFooterFont = CType(objARLayoutReport.Sections("PageFooter").Controls("lblPageFooter"), DataDynamics.ActiveReports.Label).Font

            rectPageFooter.X = rectPageFooter.X * 96 + sngLeftMarginIn
            rectPageFooter.Y = PageFooterLineY2 + 6

            rectPageFooter.Height = rectPageFooter.Height * 96
            rectPageFooter.Width = rectPageFooter.Width * 96



            'strPageFooter = Now.ToLongDateString
            'G.DrawString(strPageFooter, PageFooterFont, objBrush, rectPageFooter, New StringFormat)

            rectPageNo = CType(objARLayoutReport.Sections("PageFooter").Controls("lblPageNo"), DataDynamics.ActiveReports.Label).GetBounds
            PageNoFont = CType(objARLayoutReport.Sections("PageFooter").Controls("lblPageNo"), DataDynamics.ActiveReports.Label).Font

            '//----- Add Page footer as Company Name Instrument Type and Ver info 
            Dim strInstInfos As String
            Dim strAppVersion As String
            strAppVersion = Application.ProductVersion
            ''get a application product version to string variable.
            strAppVersion = Mid(strAppVersion, 1, 4)
            'strInstInfos = "Thermo " & gstrTitleInstrumentType & "S/W Ver. " & strAppVersion ' commented by : dinesh wagh on 20.3.2009
            strInstInfos = "Thermo Scientific " & gstrTitleInstrumentType & Space(1) & "S/W Ver. " & strAppVersion ' added by : dinesh wggh on 20.3.2009

            'rectPageNo.X = rectPageNo.X * 96 + sngLeftMarginIn
            rectPageNo.X = m_PageSetting.Bounds.Width - ((PageNoFont.SizeInPoints * strInstInfos.Length))
            rectPageNo.Y = rectPageFooter.Y - 30
            rectPageNo.Height = rectPageNo.Height * 96 - 1
            'rectPageNo.Width = rectPageNo.Width * 96 - 1
            rectPageNo.Width = (PageNoFont.SizeInPoints * strInstInfos.Length)



            G.DrawString(strInstInfos, PageNoFont, objBrush, rectPageNo, New StringFormat)
            'rectPageFooter.Y += rectPageNo.Height
            '//-----
            rectPageNo = CType(objARLayoutReport.Sections("PageFooter").Controls("lblPageNo"), DataDynamics.ActiveReports.Label).GetBounds
            rectPageNo.X = rectPageNo.X * 96 + sngLeftMarginIn
            rectPageNo.Y = rectPageFooter.Y
            rectPageNo.Height = rectPageNo.Height * 96 - 1
            rectPageNo.Width = rectPageNo.Width * 96 - 1

            strPageNo = " Page No. " & mintPageCount.ToString

            G.DrawString(strPageNo, PageNoFont, objBrush, rectPageNo, New StringFormat)

            '//----- Added by Sachin Dokhale on 28.09.05
            mintPageFooterYPosotion = CInt(PageFooterLineY1)
            '//-----
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

    Private Function funcDrawPageText(ByRef EV As PrintPageEventArgs, ByVal sngXPositionIn As Single, ByRef sngYPositionIn As Single, ByVal intReportLayoutType As Integer) As Boolean
        Dim line As String = Nothing
        Dim intCount As Integer
        Dim linesPerPage As Integer
        Dim objBrush As Drawing.Brush
        Dim SetStringBold As Boolean
        Static intIsPageReapate As Boolean

        Try

            objBrush = New Pen(mobjReportBrush.Color).Brush
            ' Work out the number of lines per page, using the MarginBounds.
            linesPerPage = CInt(EV.MarginBounds.Height / printFont.GetHeight(EV.Graphics))
            'Iterate over the string using the StringReader, printing each line.
            'If (rptPageTextReader.ReadLine()) = True Then
            line = rptPageTextReader.ReadLine()
            'End If
            If line = "False" Then
                line = ""
            End If

            Dim prnFont As New Font(printFont.Name, printFont.Size, FontStyle.Bold)

            While intCount < linesPerPage And (Nothing <> line)
                ' calculate the next line position based on 
                ' the height of the font according to the printing device
                ''yPosition = topMargin + (count * printFont.GetHeight(EV.Graphics))
                sngYPositionIn += (lineSpacing + printFont.GetHeight(EV.Graphics))

                '//----- Added by Sachin Dokhale on 12.04.06 
                '//----- Page text Height count only for if Text line is one  else Page text Height is 0
                '//-----  'mintTotalHeightOfPageText' variable use in 'funcDrawShadeCardImages' function
                If intCount = 0 Then
                    mintTotalHeightOfPageText = CInt(printFont.GetHeight(EV.Graphics))
                Else
                    mintTotalHeightOfPageText = 0
                End If
                '//-----

                If sngYPositionIn >= mintPageFooterYPosotion Then
                    If intIsPageReapate = True Then
                        If blnPageSettingMessage = False Then
                            'Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
                            Application.DoEvents()
                            'cWait = New CWaitCursor
                        End If

                        EV.HasMorePages = False
                        EV.Cancel = True
                        Exit Function
                    End If

                    EV.HasMorePages = True
                    intIsPageReapate = True
                    Exit Function
                End If

                ' draw the next line in the rich edit control


                'EV.Graphics.DrawString(line, printFont, objBrush, sngXPositionIn, sngYPositionIn, New StringFormat)
                Dim StartString As String
                Dim LastString As String


                If Len(Trim(line)) > 0 Then
                    StartString = line.Substring(0, 2)

                    'StartString = New StartString(Filter(line, "<#", True, CompareMethod.Text))
                    If StartString = "<#" Then
                        SetStringBold = True
                        line = line.Substring(2, line.Length - 2)
                    End If

                    If SetStringBold = True Then
                        EV.Graphics.DrawString(line, prnFont, objBrush, sngXPositionIn, sngYPositionIn, New StringFormat)
                    Else
                        EV.Graphics.DrawString(line, printFont, objBrush, sngXPositionIn, sngYPositionIn, New StringFormat)
                    End If
                End If
                intCount += 1
                line = rptPageTextReader.ReadLine()
                intIsPageReapate = False
            End While

            If sngYPositionIn >= mintPageFooterYPosotion Then
                If intIsPageReapate = True Then
                    If blnPageSettingMessage = False Then
                        'Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
                        'Application.DoEvents()
                        'cWait = New CWaitCursor
                    End If

                    EV.HasMorePages = False
                    EV.Cancel = True
                    Exit Function
                End If

                EV.HasMorePages = True
                intIsPageReapate = True
                Exit Function
            End If

            intIsPageReapate = True
            If Not mstrPageText = "" Then
                sngYPositionIn += (lineSpacing + printFont.GetHeight(EV.Graphics))

            End If

            ' If there are more lines, print another page.
            If Not (line Is Nothing) Then
                EV.HasMorePages = True
            Else
                EV.HasMorePages = False
            End If

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

    Private Function funcDrawPageText_CookBook(ByRef EV As PrintPageEventArgs, ByRef sngYPositionIn As Single, _
        ByVal sngLeftMarginIn As Single, ByVal sngTopMarginIn As Single, ByVal sngBottomMarginIn As Single, ByVal intReportLayoutType As Integer) As Boolean
        Dim line As String = Nothing
        Dim intCount As Integer
        Dim linesPerPage As Integer
        Dim objBrush As Drawing.Brush
        Dim SetStringBold As Boolean
        Dim sngXPositionIn As Single
        Static intIsPageReapate As Boolean

        Try
            'Dim objDtExpRptTable As DataTable


            If (mintReportType = enumReportType.CookBook) Then
                rptPageTextReader = New System.IO.StringReader(mstrPageText)
            End If

            objBrush = New Pen(mobjReportBrush.Color).Brush
            ' Work out the number of lines per page, using the MarginBounds.
            linesPerPage = CInt(EV.MarginBounds.Height / printFont.GetHeight(EV.Graphics))
            'Iterate over the string using the StringReader, printing each line.
            'If (rptPageTextReader.ReadLine()) = True Then
            line = rptPageTextReader.ReadLine()
            'End If
            If line = "False" Then
                line = ""
            End If

            Dim prnFont As New Font(printFont.Name, printFont.Size, FontStyle.Bold)

            'While intCount < linesPerPage And (Nothing <> line)
            ' calculate the next line position based on 
            ' the height of the font according to the printing device
            ''yPosition = topMargin + (count * printFont.GetHeight(EV.Graphics))
            sngYPositionIn += (lineSpacing + printFont.GetHeight(EV.Graphics))

            '//----- Added by Sachin Dokhale on 12.04.06 
            '//----- Page text Height count only for if Text line is one  else Page text Height is 0
            '//-----  'mintTotalHeightOfPageText' variable use in 'funcDrawShadeCardImages' function
            'If intCount = 0 Then
            mintTotalHeightOfPageText = CInt(printFont.GetHeight(EV.Graphics))
            'Else
            'mintTotalHeightOfPageText = 0
            'End If
            '//-----

            If sngYPositionIn >= mintPageFooterYPosotion Then
                If intIsPageReapate = True Then
                    If blnPageSettingMessage = False Then
                        'Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
                        Application.DoEvents()
                        'cWait = New CWaitCursor
                    End If

                    EV.HasMorePages = False
                    'EV.Cancel = True
                    Exit Function
                End If

                EV.HasMorePages = True
                intIsPageReapate = True
                Exit Function
            End If

            ' draw the next line in the rich edit control


            'EV.Graphics.DrawString(line, printFont, objBrush, sngXPositionIn, sngYPositionIn, New StringFormat)
            Dim StartString As String
            Dim LastString As String

            intCount += 1

            'line = rptPageTextReader.ReadLine()

            intIsPageReapate = False
            If blnFinishElamentInfo = False Then
                If funcElamentInfo(EV, sngXPositionIn, sngYPositionIn) = False Then
                    EV.Cancel = True
                    Exit Function
                End If
            End If
            If blnFinishStdSolutionTech = False Then
                If funcStdSolutionTech(EV, sngXPositionIn, sngYPositionIn) = False Then
                    EV.Cancel = True
                    Exit Function
                End If
            End If
            If blnFinishWorkingConditionFixed = False Then
                If funcWorkingConditionFixed(EV, sngXPositionIn, sngYPositionIn) = False Then
                    EV.Cancel = True
                    Exit Function
                End If
            End If
            If blnFinishWorkingConditionVariable = False Then
                If funcWorkingConditionVariable(EV, sngXPositionIn, sngYPositionIn, sngLeftMarginIn) = False Then
                    EV.Cancel = True
                    Exit Function
                End If
            End If
            If blnFinishFlameEmission = False Or blnFinishFlameEmissionNotes = False Then
                If funcFlameEmission(EV, sngXPositionIn, sngYPositionIn) = False Then
                    EV.Cancel = True
                    Exit Function
                End If
            End If
            If EV.HasMorePages Then
                intIsPageReapate = True
                Exit Function
            End If
            If blnFinishInterference = False Then
                If funcInterference(EV, sngXPositionIn, sngYPositionIn) = False Then
                    EV.Cancel = True
                    Exit Function
                End If
            End If
            If blnFinishInterference = True And intIsPageReapate = False Then
                EV.HasMorePages = False
                'EV.Cancel = True
                Exit Function
            End If


            If sngYPositionIn >= mintPageFooterYPosotion Then
                If intIsPageReapate = True Then
                    If blnPageSettingMessage = False Then
                        'Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
                        'Application.DoEvents()
                        'cWait = New CWaitCursor
                    End If

                    EV.HasMorePages = False
                    'EV.Cancel = True
                    Exit Function
                End If

                EV.HasMorePages = True
                intIsPageReapate = True
                Exit Function
            End If

            intIsPageReapate = True
            'If Not mstrPageText = "" Then
            '    sngYPositionIn += (lineSpacing + printFont.GetHeight(EV.Graphics))
            'End If

            ' If there are more lines, print another page.
            'If Not (line Is Nothing) Then
            '    EV.HasMorePages = True
            'Else
            '    EV.HasMorePages = False
            'End If
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

    Private Function funcDrawPageText_DataFile(ByRef EV As PrintPageEventArgs, ByRef sngYPositionIn As Single, _
        ByVal sngLeftMarginIn As Single, ByVal sngTopMarginIn As Single, ByVal sngBottomMarginIn As Single, ByVal intReportLayoutType As Integer) As Boolean
        Dim line As String = Nothing
        Dim intCount As Integer
        Dim linesPerPage As Integer
        Dim objBrush As Drawing.Brush
        Dim SetStringBold As Boolean
        Dim sngXPositionIn As Single
        Static intIsPageReapate As Boolean

        Try
            'Dim objDtExpRptTable As DataTable


            If (mintReportType = enumReportType.DataFile) Then
                rptPageTextReader = New System.IO.StringReader(mstrPageText)
            End If

            objBrush = New Pen(mobjReportBrush.Color).Brush
            ' Work out the number of lines per page, using the MarginBounds.
            linesPerPage = CInt(EV.MarginBounds.Height / printFont.GetHeight(EV.Graphics))
            'Iterate over the string using the StringReader, printing each line.
            'If (rptPageTextReader.ReadLine()) = True Then
            line = rptPageTextReader.ReadLine()
            'End If
            If line = "False" Then
                line = ""
            End If

            Dim prnFont As New Font(printFont.Name, printFont.Size, FontStyle.Bold)

            'While intCount < linesPerPage And (Nothing <> line)
            ' calculate the next line position based on 
            ' the height of the font according to the printing device
            ''yPosition = topMargin + (count * printFont.GetHeight(EV.Graphics))
            sngYPositionIn += (lineSpacing + printFont.GetHeight(EV.Graphics))

            '//----- Added by Sachin Dokhale on 12.04.06 
            '//----- Page text Height count only for if Text line is one  else Page text Height is 0
            '//-----  'mintTotalHeightOfPageText' variable use in 'funcDrawShadeCardImages' function
            'If intCount = 0 Then
            mintTotalHeightOfPageText = CInt(printFont.GetHeight(EV.Graphics))
            'Else
            'mintTotalHeightOfPageText = 0
            'End If
            '//-----

            If sngYPositionIn >= mintPageFooterYPosotion Then
                If intIsPageReapate = True Then
                    If blnPageSettingMessage = False Then
                        'Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
                        Application.DoEvents()
                        'cWait = New CWaitCursor
                    End If

                    EV.HasMorePages = False
                    EV.Cancel = True
                    Exit Function
                End If

                EV.HasMorePages = True
                intIsPageReapate = True
                Exit Function
            End If

            ' draw the next line in the rich edit control


            'EV.Graphics.DrawString(line, printFont, objBrush, sngXPositionIn, sngYPositionIn, New StringFormat)
            Dim StartString As String
            Dim LastString As String

            intCount += 1

            'line = rptPageTextReader.ReadLine()

            intIsPageReapate = False
            If blnFinishElamentInfo = False Then
                'If funcDatafileElamentInfo(EV, sngXPositionIn, sngYPositionIn) = False Then
                '    EV.Cancel = True
                '    Exit Function
                'End If
            End If

            'If blnFinishStdSolutionTech = False Then
            '    If funcStdSolutionTech(EV, sngXPositionIn, sngYPositionIn) = False Then
            '        EV.Cancel = True
            '        Exit Function
            '    End If
            'End If
            'If blnFinishWorkingConditionFixed = False Then
            '    If funcWorkingConditionFixed(EV, sngXPositionIn, sngYPositionIn) = False Then
            '        EV.Cancel = True
            '        Exit Function
            '    End If
            'End If
            'If blnFinishWorkingConditionVariable = False Then
            '    If funcWorkingConditionVariable(EV, sngXPositionIn, sngYPositionIn, sngLeftMarginIn) = False Then
            '        EV.Cancel = True
            '        Exit Function
            '    End If
            'End If
            'If blnFinishFlameEmission = False Or blnFinishFlameEmissionNotes = False Then
            '    If funcFlameEmission(EV, sngXPositionIn, sngYPositionIn) = False Then
            '        EV.Cancel = True
            '        Exit Function
            '    End If
            'End If

            If EV.HasMorePages Then
                intIsPageReapate = True
                Exit Function
            End If
            If blnFinishInterference = False Then
                If funcInterference(EV, sngXPositionIn, sngYPositionIn) = False Then
                    EV.Cancel = True
                    Exit Function
                End If
            End If
            If blnFinishInterference = True And intIsPageReapate = False Then
                EV.HasMorePages = False
                EV.Cancel = True
                Exit Function
            End If


            If sngYPositionIn >= mintPageFooterYPosotion Then
                If intIsPageReapate = True Then
                    If blnPageSettingMessage = False Then
                        'Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
                        'Application.DoEvents()
                        'cWait = New CWaitCursor
                    End If

                    EV.HasMorePages = False
                    EV.Cancel = True
                    Exit Function
                End If

                EV.HasMorePages = True
                intIsPageReapate = True
                Exit Function
            End If

            intIsPageReapate = True
            'If Not mstrPageText = "" Then
            '    sngYPositionIn += (lineSpacing + printFont.GetHeight(EV.Graphics))
            'End If

            ' If there are more lines, print another page.
            'If Not (line Is Nothing) Then
            '    EV.HasMorePages = True
            'Else
            '    EV.HasMorePages = False
            'End If
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

    Private Function funcDrawPageText2(ByRef EV As PrintPageEventArgs, ByVal sngXPositionIn As Single, ByRef sngYPositionIn As Single, ByVal intReportLayoutType As Integer) As Boolean
        Dim line As String = Nothing
        Dim intCount As Integer
        Dim linesPerPage As Integer
        Dim objBrush As Drawing.Brush
        Dim SetStringBold As Boolean
        Static intIsPageReapate As Boolean
        Dim rectReportHeader As Drawing.RectangleF
        Dim rectReportHeader2 As Drawing.RectangleF
        Dim rectReportHeader3 As Drawing.RectangleF
        Dim rectReportHeader4 As Drawing.RectangleF
        Dim rectReportHeader5 As Drawing.RectangleF
        Dim rectReportHeader6 As Drawing.RectangleF
        Dim rectReportHeader7 As Drawing.RectangleF
        Dim rectReportHeader8 As Drawing.RectangleF
        Dim rectReportHeader9 As Drawing.RectangleF
        Dim rectReportHeader10 As Drawing.RectangleF
        Dim rectReportHeader11 As Drawing.RectangleF
        Dim rectReportHeader12 As Drawing.RectangleF
        Dim rectReportHeader13 As Drawing.RectangleF
        Dim rectReportHeader14 As Drawing.RectangleF
        Dim rectReportHeader15 As Drawing.RectangleF
        Dim rectReportHeader16 As Drawing.RectangleF
        Dim rectReportHeader17 As Drawing.RectangleF
        Dim rectReportHeader18 As Drawing.RectangleF
        Dim rectReportHeader19 As Drawing.RectangleF
        Dim rectReportHeader20 As Drawing.RectangleF
        Dim rectReportHeader21 As Drawing.RectangleF
        Dim rectReportHeader22 As Drawing.RectangleF
        Dim rectReportHeader23 As Drawing.RectangleF
        Dim rectReportHeader24 As Drawing.RectangleF
        Dim rectReportHeader25 As Drawing.RectangleF
        Dim rectReportHeader26 As Drawing.RectangleF
        Dim rectReportHeader27 As Drawing.RectangleF
        Dim rectReportHeader28 As Drawing.RectangleF
        Dim rectReportHeader29 As Drawing.RectangleF
        Dim rectReportHeader30 As Drawing.RectangleF
        Dim rectReportHeader31 As Drawing.RectangleF
        Dim rectReportHeader32 As Drawing.RectangleF
        Dim rectReportHeader33 As Drawing.RectangleF
        Dim rectReportHeader34 As Drawing.RectangleF
        Dim rectReportHeader35 As Drawing.RectangleF
        Dim rectReportHeader36 As Drawing.RectangleF
        Dim rectReportHeader37 As Drawing.RectangleF

        Dim ReportHeaderFont As Font
        Dim ReportHeaderFont2 As Font
        Dim ReportHeaderFont3 As Font
        Dim ReportHeaderFont4 As Font
        Dim ReportHeaderFont5 As Font
        Dim ReportHeaderFont6 As Font
        Dim ReportHeaderFont7 As Font
        Dim ReportHeaderFont8 As Font
        Dim ReportHeaderFont9 As Font
        Dim ReportHeaderFont10 As Font
        Dim ReportHeaderFont11 As Font
        Dim ReportHeaderFont12 As Font
        Dim ReportHeaderFont13 As Font
        Dim ReportHeaderFont14 As Font
        Dim ReportHeaderFont15 As Font
        Dim ReportHeaderFont16 As Font
        Dim ReportHeaderFont17 As Font
        Dim ReportHeaderFont18 As Font
        Dim ReportHeaderFont19 As Font
        Dim ReportHeaderFont20 As Font
        Dim ReportHeaderFont21 As Font
        Dim ReportHeaderFont22 As Font
        Dim ReportHeaderFont23 As Font
        Dim ReportHeaderFont24 As Font
        Dim ReportHeaderFont25 As Font
        Dim ReportHeaderFont26 As Font
        Dim ReportHeaderFont27 As Font
        Dim ReportHeaderFont28 As Font
        Dim ReportHeaderFont29 As Font
        Dim ReportHeaderFont30 As Font
        Dim ReportHeaderFont31 As Font
        Dim ReportHeaderFont32 As Font
        Dim ReportHeaderFont33 As Font
        Dim ReportHeaderFont34 As Font
        Dim ReportHeaderFont35 As Font
        Dim ReportHeaderFont36 As Font
        Dim ReportHeaderFont37 As Font

        Dim ReportHeaderLineX1 As Single = 0.0
        Dim ReportHeaderLineY1 As Single = 0.0
        Dim ReportHeaderLineX2 As Single = 0.0
        Dim ReportHeaderLineY2 As Single = 0.0
        Dim strReportHeader As String
        Dim strReportHeader2 As String
        Dim strReportHeader3 As String
        Dim strReportHeader4 As String
        Dim strReportHeader5 As String
        Dim strReportHeader6 As String
        Dim strReportHeader7 As String
        Dim strReportHeader8 As String
        Dim strReportHeader9 As String
        Dim strReportHeader10 As String
        Dim strReportHeader11 As String
        Dim strReportHeader12 As String
        Dim strReportHeader13 As String
        Dim strReportHeader14 As String
        Dim strReportHeader15 As String
        Dim strReportHeader16 As String
        Dim strReportHeader17 As String
        Dim strReportHeader18 As String
        Dim strReportHeader19 As String
        Dim strReportHeader20 As String
        Dim strReportHeader21 As String
        Dim strReportHeader22 As String
        Dim strReportHeader23 As String
        Dim strReportHeader24 As String
        Dim strReportHeader25 As String
        Dim strReportHeader26 As String
        Dim strReportHeader27 As String
        Dim strReportHeader28 As String
        Dim strReportHeader29 As String
        Dim strReportHeader30 As String
        Dim strReportHeader31 As String
        Dim strReportHeader32 As String
        Dim strReportHeader33 As String
        Dim strReportHeader34 As String
        Dim strReportHeader35 As String
        Dim strReportHeader36 As String
        Dim strReportHeader37 As String


        Dim strInstrumentName As String

        Dim objARLayoutReport As DataDynamics.ActiveReports.ActiveReport

        Try
            Select Case intReportLayoutType
                Case enumReportLayoutType.Portrate
                    objARLayoutReport = mobjARPortrateReport
                Case enumReportLayoutType.Landscape
                    'objARLayoutReport = mobjARLandScapeReport
            End Select

            objBrush = New Pen(mobjReportBrush.Color).Brush
            ' Work out the number of lines per page, using the MarginBounds.
            linesPerPage = CInt(EV.MarginBounds.Height / printFont.GetHeight(EV.Graphics))
            'Iterate over the string using the StringReader, printing each line.
1:          line = rptPageTextReader.ReadLine()
            If line = "False" Then
                line = ""
            End If

            Dim prnFont As New Font(printFont.Name, printFont.Size, FontStyle.Bold)

            While intCount < linesPerPage And (Nothing <> line)
                ' calculate the next line position based on 
                ' the height of the font according to the printing device
                sngYPositionIn += (lineSpacing + printFont.GetHeight(EV.Graphics))

                If intCount = 0 Then
                    mintTotalHeightOfPageText = CInt(printFont.GetHeight(EV.Graphics))
                Else
                    mintTotalHeightOfPageText = 0
                End If

                If sngYPositionIn >= mintPageFooterYPosotion Then
                    If intIsPageReapate = True Then
                        If blnPageSettingMessage = False Then
                            'Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
                        End If

                        EV.HasMorePages = False
                        EV.Cancel = True
                        Exit Function
                    End If

                    EV.HasMorePages = True
                    intIsPageReapate = True
                    Exit Function
                End If

                If Len(Trim(line)) > 0 Then

                    rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("lblElement"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("lblElement"), DataDynamics.ActiveReports.Label).Font

                    rectReportHeader2 = CType(objARLayoutReport.Sections("Detail").Controls("lblAtWt"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont2 = CType(objARLayoutReport.Sections("Detail").Controls("lblAtWt"), DataDynamics.ActiveReports.Label).Font

                    rectReportHeader3 = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader1"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont3 = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader1"), DataDynamics.ActiveReports.Label).Font

                    rectReportHeader4 = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont4 = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).Font

                    rectReportHeader5 = CType(objARLayoutReport.Sections("Detail").Controls("Label1"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont5 = CType(objARLayoutReport.Sections("Detail").Controls("Label1"), DataDynamics.ActiveReports.Label).Font

                    rectReportHeader6 = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader3"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont6 = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader3"), DataDynamics.ActiveReports.Label).Font

                    rectReportHeader7 = CType(objARLayoutReport.Sections("Detail").Controls("Label3"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont7 = CType(objARLayoutReport.Sections("Detail").Controls("Label3"), DataDynamics.ActiveReports.Label).Font

                    rectReportHeader8 = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader4"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont8 = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader4"), DataDynamics.ActiveReports.Label).Font

                    rectReportHeader9 = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader5"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont9 = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader5"), DataDynamics.ActiveReports.Label).Font

                    rectReportHeader10 = CType(objARLayoutReport.Sections("Detail").Controls("lblLampCurr"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont10 = CType(objARLayoutReport.Sections("Detail").Controls("lblLampCurr"), DataDynamics.ActiveReports.Label).Font

                    rectReportHeader11 = CType(objARLayoutReport.Sections("Detail").Controls("lblLampCurrVal"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont11 = CType(objARLayoutReport.Sections("Detail").Controls("lblLampCurrVal"), DataDynamics.ActiveReports.Label).Font

                    rectReportHeader12 = CType(objARLayoutReport.Sections("Detail").Controls("lblFuel"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont12 = CType(objARLayoutReport.Sections("Detail").Controls("lblFuel"), DataDynamics.ActiveReports.Label).Font

                    rectReportHeader13 = CType(objARLayoutReport.Sections("Detail").Controls("lblFuelVal"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont13 = CType(objARLayoutReport.Sections("Detail").Controls("lblFuelVal"), DataDynamics.ActiveReports.Label).Font

                    rectReportHeader14 = CType(objARLayoutReport.Sections("Detail").Controls("lblSupport"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont14 = CType(objARLayoutReport.Sections("Detail").Controls("lblSupport"), DataDynamics.ActiveReports.Label).Font

                    rectReportHeader15 = CType(objARLayoutReport.Sections("Detail").Controls("lblSupportVal"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont15 = CType(objARLayoutReport.Sections("Detail").Controls("lblSupportVal"), DataDynamics.ActiveReports.Label).Font

                    rectReportHeader16 = CType(objARLayoutReport.Sections("Detail").Controls("lblFlameSto"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont16 = CType(objARLayoutReport.Sections("Detail").Controls("lblFlameSto"), DataDynamics.ActiveReports.Label).Font

                    rectReportHeader17 = CType(objARLayoutReport.Sections("Detail").Controls("lblFlameStoVal"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont17 = CType(objARLayoutReport.Sections("Detail").Controls("lblFlameStoVal"), DataDynamics.ActiveReports.Label).Font

                    rectReportHeader18 = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader6"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont18 = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader6"), DataDynamics.ActiveReports.Label).Font

                    rectReportHeader19 = CType(objARLayoutReport.Sections("Detail").Controls("Label4"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont19 = CType(objARLayoutReport.Sections("Detail").Controls("Label4"), DataDynamics.ActiveReports.Label).Font

                    rectReportHeader20 = CType(objARLayoutReport.Sections("Detail").Controls("lblWorking"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont20 = CType(objARLayoutReport.Sections("Detail").Controls("lblWorking"), DataDynamics.ActiveReports.Label).Font

                    rectReportHeader21 = CType(objARLayoutReport.Sections("Detail").Controls("lblWorking1"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont21 = CType(objARLayoutReport.Sections("Detail").Controls("lblWorking1"), DataDynamics.ActiveReports.Label).Font

                    rectReportHeader22 = CType(objARLayoutReport.Sections("Detail").Controls("lblWavelength"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont22 = CType(objARLayoutReport.Sections("Detail").Controls("lblWavelength"), DataDynamics.ActiveReports.Label).Font

                    rectReportHeader23 = CType(objARLayoutReport.Sections("Detail").Controls("lblSpectral"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont23 = CType(objARLayoutReport.Sections("Detail").Controls("lblSpectral"), DataDynamics.ActiveReports.Label).Font

                    rectReportHeader24 = CType(objARLayoutReport.Sections("Detail").Controls("lblOptimumWorkingRange"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont24 = CType(objARLayoutReport.Sections("Detail").Controls("lblOptimumWorkingRange"), DataDynamics.ActiveReports.Label).Font

                    rectReportHeader25 = CType(objARLayoutReport.Sections("Detail").Controls("lblNote"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont25 = CType(objARLayoutReport.Sections("Detail").Controls("lblNote"), DataDynamics.ActiveReports.Label).Font

                    rectReportHeader26 = CType(objARLayoutReport.Sections("Detail").Controls("lblNoteVal"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont26 = CType(objARLayoutReport.Sections("Detail").Controls("lblNoteVal"), DataDynamics.ActiveReports.Label).Font

                    rectReportHeader27 = CType(objARLayoutReport.Sections("Detail").Controls("lblFlame"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont27 = CType(objARLayoutReport.Sections("Detail").Controls("lblFlame"), DataDynamics.ActiveReports.Label).Font

                    rectReportHeader28 = CType(objARLayoutReport.Sections("Detail").Controls("lblWavelength1"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont28 = CType(objARLayoutReport.Sections("Detail").Controls("lblWavelength1"), DataDynamics.ActiveReports.Label).Font

                    rectReportHeader29 = CType(objARLayoutReport.Sections("Detail").Controls("lblWavelength1Val"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont29 = CType(objARLayoutReport.Sections("Detail").Controls("lblWavelength1Val"), DataDynamics.ActiveReports.Label).Font

                    rectReportHeader30 = CType(objARLayoutReport.Sections("Detail").Controls("lblBandwidth"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont30 = CType(objARLayoutReport.Sections("Detail").Controls("lblBandwidth"), DataDynamics.ActiveReports.Label).Font

                    rectReportHeader31 = CType(objARLayoutReport.Sections("Detail").Controls("lblBandwidthVal"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont31 = CType(objARLayoutReport.Sections("Detail").Controls("lblBandwidthVal"), DataDynamics.ActiveReports.Label).Font

                    rectReportHeader32 = CType(objARLayoutReport.Sections("Detail").Controls("lblFuel1"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont32 = CType(objARLayoutReport.Sections("Detail").Controls("lblFuel1"), DataDynamics.ActiveReports.Label).Font

                    rectReportHeader33 = CType(objARLayoutReport.Sections("Detail").Controls("lblFuel1Val"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont33 = CType(objARLayoutReport.Sections("Detail").Controls("lblFuel1Val"), DataDynamics.ActiveReports.Label).Font

                    rectReportHeader34 = CType(objARLayoutReport.Sections("Detail").Controls("lblSupport1"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont34 = CType(objARLayoutReport.Sections("Detail").Controls("lblSupport1"), DataDynamics.ActiveReports.Label).Font

                    rectReportHeader35 = CType(objARLayoutReport.Sections("Detail").Controls("lblSupport1Val"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont35 = CType(objARLayoutReport.Sections("Detail").Controls("lblSupport1Val"), DataDynamics.ActiveReports.Label).Font

                    rectReportHeader36 = CType(objARLayoutReport.Sections("Detail").Controls("lblNote1"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont36 = CType(objARLayoutReport.Sections("Detail").Controls("lblNote1"), DataDynamics.ActiveReports.Label).Font

                    rectReportHeader37 = CType(objARLayoutReport.Sections("Detail").Controls("lblNote1Val"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont37 = CType(objARLayoutReport.Sections("Detail").Controls("lblNote1Val"), DataDynamics.ActiveReports.Label).Font

                    rectReportHeader.X = rectReportHeader.X * 96 + sngXPositionIn
                    rectReportHeader.Y = rectReportHeader.Y * 96 + sngYPositionIn
                    rectReportHeader.Height = rectReportHeader.Height * 96
                    rectReportHeader.Width = rectReportHeader.Width * 96

                    rectReportHeader2.X = rectReportHeader2.X * 96 + sngXPositionIn
                    rectReportHeader2.Y = rectReportHeader2.Y * 96 + sngYPositionIn
                    rectReportHeader2.Height = rectReportHeader2.Height * 96
                    rectReportHeader2.Width = rectReportHeader2.Width * 96

                    rectReportHeader3.X = rectReportHeader3.X * 96 + sngXPositionIn
                    rectReportHeader3.Y = rectReportHeader3.Y * 96 + sngYPositionIn
                    rectReportHeader3.Height = rectReportHeader3.Height * 96
                    rectReportHeader3.Width = rectReportHeader3.Width * 96

                    rectReportHeader4.X = rectReportHeader4.X * 96 + sngXPositionIn
                    rectReportHeader4.Y = rectReportHeader4.Y * 96 + sngYPositionIn
                    rectReportHeader4.Height = rectReportHeader4.Height * 96
                    rectReportHeader4.Width = rectReportHeader4.Width * 96

                    rectReportHeader5.X = rectReportHeader5.X * 96 + sngXPositionIn
                    rectReportHeader5.Y = rectReportHeader5.Y * 96 + sngYPositionIn
                    rectReportHeader5.Height = rectReportHeader5.Height * 96
                    rectReportHeader5.Width = rectReportHeader5.Width * 96

                    rectReportHeader6.X = rectReportHeader6.X * 96 + sngXPositionIn
                    rectReportHeader6.Y = rectReportHeader6.Y * 96 + sngYPositionIn
                    rectReportHeader6.Height = rectReportHeader6.Height * 96
                    rectReportHeader6.Width = rectReportHeader6.Width * 96

                    rectReportHeader7.X = rectReportHeader7.X * 96 + sngXPositionIn
                    rectReportHeader7.Y = rectReportHeader7.Y * 96 + sngYPositionIn
                    rectReportHeader7.Height = rectReportHeader7.Height * 96
                    rectReportHeader7.Width = rectReportHeader7.Width * 96


                    rectReportHeader8.X = rectReportHeader8.X * 96 + sngXPositionIn
                    rectReportHeader8.Y = rectReportHeader8.Y * 96 + sngYPositionIn
                    rectReportHeader8.Height = rectReportHeader8.Height * 96
                    rectReportHeader8.Width = rectReportHeader8.Width * 96

                    rectReportHeader9.X = rectReportHeader9.X * 96 + sngXPositionIn
                    rectReportHeader9.Y = rectReportHeader9.Y * 96 + sngYPositionIn
                    rectReportHeader9.Height = rectReportHeader9.Height * 96
                    rectReportHeader9.Width = rectReportHeader9.Width * 96

                    rectReportHeader10.X = rectReportHeader10.X * 96 + sngXPositionIn
                    rectReportHeader10.Y = rectReportHeader10.Y * 96 + sngYPositionIn
                    rectReportHeader10.Height = rectReportHeader10.Height * 96
                    rectReportHeader10.Width = rectReportHeader10.Width * 96

                    rectReportHeader11.X = rectReportHeader11.X * 96 + sngXPositionIn
                    rectReportHeader11.Y = rectReportHeader11.Y * 96 + sngYPositionIn
                    rectReportHeader11.Height = rectReportHeader11.Height * 96
                    rectReportHeader11.Width = rectReportHeader11.Width * 96

                    rectReportHeader12.X = rectReportHeader12.X * 96 + sngXPositionIn
                    rectReportHeader12.Y = rectReportHeader12.Y * 96 + sngYPositionIn
                    rectReportHeader12.Height = rectReportHeader12.Height * 96
                    rectReportHeader12.Width = rectReportHeader12.Width * 96

                    rectReportHeader13.X = rectReportHeader13.X * 96 + sngXPositionIn
                    rectReportHeader13.Y = rectReportHeader13.Y * 96 + sngYPositionIn
                    rectReportHeader13.Height = rectReportHeader13.Height * 96
                    rectReportHeader13.Width = rectReportHeader13.Width * 96

                    rectReportHeader14.X = rectReportHeader14.X * 96 + sngXPositionIn
                    rectReportHeader14.Y = rectReportHeader14.Y * 96 + sngYPositionIn
                    rectReportHeader14.Height = rectReportHeader14.Height * 96
                    rectReportHeader14.Width = rectReportHeader14.Width * 96

                    rectReportHeader15.X = rectReportHeader15.X * 96 + sngXPositionIn
                    rectReportHeader15.Y = rectReportHeader15.Y * 96 + sngYPositionIn
                    rectReportHeader15.Height = rectReportHeader15.Height * 96
                    rectReportHeader15.Width = rectReportHeader15.Width * 96

                    rectReportHeader16.X = rectReportHeader16.X * 96 + sngXPositionIn
                    rectReportHeader16.Y = rectReportHeader16.Y * 96 + sngYPositionIn
                    rectReportHeader16.Height = rectReportHeader16.Height * 96
                    rectReportHeader16.Width = rectReportHeader16.Width * 96

                    rectReportHeader17.X = rectReportHeader17.X * 96 + sngXPositionIn
                    rectReportHeader17.Y = rectReportHeader17.Y * 96 + sngYPositionIn
                    rectReportHeader17.Height = rectReportHeader17.Height * 96
                    rectReportHeader17.Width = rectReportHeader17.Width * 96

                    rectReportHeader18.X = rectReportHeader18.X * 96 + sngXPositionIn
                    rectReportHeader18.Y = rectReportHeader18.Y * 96 + sngYPositionIn
                    rectReportHeader18.Height = rectReportHeader18.Height * 96
                    rectReportHeader18.Width = rectReportHeader18.Width * 96

                    rectReportHeader19.X = rectReportHeader19.X * 96 + sngXPositionIn
                    rectReportHeader19.Y = rectReportHeader19.Y * 96 + sngYPositionIn
                    rectReportHeader19.Height = rectReportHeader19.Height * 96
                    rectReportHeader19.Width = rectReportHeader19.Width * 96

                    rectReportHeader20.X = rectReportHeader20.X * 96 + sngXPositionIn
                    rectReportHeader20.Y = rectReportHeader20.Y * 96 + sngYPositionIn
                    rectReportHeader20.Height = rectReportHeader20.Height * 96
                    rectReportHeader20.Width = rectReportHeader20.Width * 96

                    rectReportHeader21.X = rectReportHeader21.X * 96 + sngXPositionIn
                    rectReportHeader21.Y = rectReportHeader21.Y * 96 + sngYPositionIn
                    rectReportHeader21.Height = rectReportHeader21.Height * 96
                    rectReportHeader21.Width = rectReportHeader21.Width * 96

                    rectReportHeader22.X = rectReportHeader22.X * 96 + sngXPositionIn
                    rectReportHeader22.Y = rectReportHeader22.Y * 96 + sngYPositionIn
                    rectReportHeader22.Height = rectReportHeader22.Height * 96
                    rectReportHeader22.Width = rectReportHeader22.Width * 96

                    rectReportHeader23.X = rectReportHeader23.X * 96 + sngXPositionIn
                    rectReportHeader23.Y = rectReportHeader23.Y * 96 + sngYPositionIn
                    rectReportHeader23.Height = rectReportHeader23.Height * 96
                    rectReportHeader23.Width = rectReportHeader23.Width * 96

                    rectReportHeader24.X = rectReportHeader24.X * 96 + sngXPositionIn
                    rectReportHeader24.Y = rectReportHeader24.Y * 96 + sngYPositionIn
                    rectReportHeader24.Height = rectReportHeader24.Height * 96
                    rectReportHeader24.Width = rectReportHeader24.Width * 96

                    rectReportHeader25.X = rectReportHeader25.X * 96 + sngXPositionIn
                    rectReportHeader25.Y = rectReportHeader25.Y * 96 + sngYPositionIn
                    rectReportHeader25.Height = rectReportHeader25.Height * 96
                    rectReportHeader25.Width = rectReportHeader25.Width * 96

                    rectReportHeader26.X = rectReportHeader26.X * 96 + sngXPositionIn
                    rectReportHeader26.Y = rectReportHeader26.Y * 96 + sngYPositionIn
                    rectReportHeader26.Height = rectReportHeader26.Height * 96
                    rectReportHeader26.Width = rectReportHeader26.Width * 96

                    rectReportHeader27.X = rectReportHeader27.X * 96 + sngXPositionIn
                    rectReportHeader27.Y = rectReportHeader27.Y * 96 + sngYPositionIn
                    rectReportHeader27.Height = rectReportHeader27.Height * 96
                    rectReportHeader27.Width = rectReportHeader27.Width * 96

                    rectReportHeader28.X = rectReportHeader28.X * 96 + sngXPositionIn
                    rectReportHeader28.Y = rectReportHeader28.Y * 96 + sngYPositionIn
                    rectReportHeader28.Height = rectReportHeader28.Height * 96
                    rectReportHeader28.Width = rectReportHeader28.Width * 96

                    rectReportHeader29.X = rectReportHeader29.X * 96 + sngXPositionIn
                    rectReportHeader29.Y = rectReportHeader29.Y * 96 + sngYPositionIn
                    rectReportHeader29.Height = rectReportHeader29.Height * 96
                    rectReportHeader29.Width = rectReportHeader29.Width * 96

                    rectReportHeader30.X = rectReportHeader30.X * 96 + sngXPositionIn
                    rectReportHeader30.Y = rectReportHeader30.Y * 96 + sngYPositionIn
                    rectReportHeader30.Height = rectReportHeader30.Height * 96
                    rectReportHeader30.Width = rectReportHeader30.Width * 96

                    rectReportHeader31.X = rectReportHeader31.X * 96 + sngXPositionIn
                    rectReportHeader31.Y = rectReportHeader31.Y * 96 + sngYPositionIn
                    rectReportHeader31.Height = rectReportHeader31.Height * 96
                    rectReportHeader31.Width = rectReportHeader31.Width * 96

                    rectReportHeader32.X = rectReportHeader32.X * 96 + sngXPositionIn
                    rectReportHeader32.Y = rectReportHeader32.Y * 96 + sngYPositionIn
                    rectReportHeader32.Height = rectReportHeader32.Height * 96
                    rectReportHeader32.Width = rectReportHeader32.Width * 96

                    rectReportHeader33.X = rectReportHeader33.X * 96 + sngXPositionIn
                    rectReportHeader33.Y = rectReportHeader33.Y * 96 + sngYPositionIn
                    rectReportHeader33.Height = rectReportHeader33.Height * 96
                    rectReportHeader33.Width = rectReportHeader33.Width * 96

                    rectReportHeader34.X = rectReportHeader34.X * 96 + sngXPositionIn
                    rectReportHeader34.Y = rectReportHeader34.Y * 96 + sngYPositionIn
                    rectReportHeader34.Height = rectReportHeader34.Height * 96
                    rectReportHeader34.Width = rectReportHeader34.Width * 96

                    rectReportHeader35.X = rectReportHeader35.X * 96 + sngXPositionIn
                    rectReportHeader35.Y = rectReportHeader35.Y * 96 + sngYPositionIn
                    rectReportHeader35.Height = rectReportHeader35.Height * 96
                    rectReportHeader35.Width = rectReportHeader35.Width * 96

                    rectReportHeader36.X = rectReportHeader36.X * 96 + sngXPositionIn
                    rectReportHeader36.Y = rectReportHeader36.Y * 96 + sngYPositionIn
                    rectReportHeader36.Height = rectReportHeader36.Height * 96
                    rectReportHeader36.Width = rectReportHeader36.Width * 96

                    rectReportHeader37.X = rectReportHeader37.X * 96 + sngXPositionIn
                    rectReportHeader37.Y = rectReportHeader37.Y * 96 + sngYPositionIn
                    rectReportHeader37.Height = rectReportHeader37.Height * 96
                    rectReportHeader37.Width = rectReportHeader37.Width * 96

                    strReportHeader = "Ag (Silver)"
                    strReportHeader2 = "At.Wt. 120"
                    strReportHeader3 = "Preparation Of Standard Solution"
                    strReportHeader4 = "Recommended Standard"
                    strReportHeader5 = "Silver metal strip or wire 99.99%"
                    strReportHeader6 = "Solution Technique"
                    strReportHeader7 = "Dissolve 1.000 gram of Silver....."
                    strReportHeader8 = "RECOMEMDED INSTRUMENT"
                    strReportHeader9 = "Atomic Absorption"
                    strReportHeader10 = "Lamp"
                    strReportHeader11 = "4.0"
                    strReportHeader12 = "Fuel"
                    strReportHeader13 = "Acetylene"
                    strReportHeader14 = "Support"
                    strReportHeader15 = "Air"
                    strReportHeader16 = "Flame"
                    strReportHeader17 = "Oxidising"
                    strReportHeader18 = "INTERFERENCE"
                    strReportHeader19 = "asfgas dfasd fasfaf asfa  adfsdf asdf hdfh asdg hfahd fuhas dfiou dhfuh udfh au iodhf hdf uhdufhj sdhf jks dhfjh dsf dfhu ahf uhd fuhad uifh"
                    strReportHeader20 = "Working"
                    strReportHeader21 = "Working"
                    strReportHeader22 = "Wavelength"
                    strReportHeader23 = "Spectral"
                    strReportHeader24 = "Optimum Working Range"
                    strReportHeader25 = "Note :"
                    strReportHeader26 = "At.Wt. 120"
                    strReportHeader27 = "Flame"
                    strReportHeader28 = "Wavelength"
                    strReportHeader29 = "422.70 nm"
                    strReportHeader30 = "Bandwidth"
                    strReportHeader31 = "0.2 nm"
                    strReportHeader32 = "Fuel"
                    strReportHeader33 = "Acetylene"
                    strReportHeader34 = "Support"
                    strReportHeader35 = "Nitrous Oxide"
                    strReportHeader36 = "Note :"
                    strReportHeader37 = "At.Wt. 120"


                    objBrush = New Pen(mobjReportBrushBlack.Color).Brush
                    EV.Graphics.DrawString(strReportHeader, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)
                    objBrush = New Pen(mobjReportBrushBlack.Color).Brush
                    EV.Graphics.DrawString(strReportHeader2, ReportHeaderFont2, objBrush, rectReportHeader2, New StringFormat)
                    objBrush = New Pen(mobjReportBrushRed.Color).Brush
                    EV.Graphics.DrawString(strReportHeader3, ReportHeaderFont3, objBrush, rectReportHeader3, New StringFormat)
                    objBrush = New Pen(mobjReportBrushBlue.Color).Brush
                    EV.Graphics.DrawString(strReportHeader4, ReportHeaderFont4, objBrush, rectReportHeader4, New StringFormat)
                    objBrush = New Pen(mobjReportBrushBlack.Color).Brush
                    EV.Graphics.DrawString(strReportHeader5, ReportHeaderFont5, objBrush, rectReportHeader5, New StringFormat)
                    objBrush = New Pen(mobjReportBrushBlue.Color).Brush
                    EV.Graphics.DrawString(strReportHeader6, ReportHeaderFont6, objBrush, rectReportHeader6, New StringFormat)
                    objBrush = New Pen(mobjReportBrushBlack.Color).Brush
                    EV.Graphics.DrawString(strReportHeader7, ReportHeaderFont7, objBrush, rectReportHeader7, New StringFormat)
                    objBrush = New Pen(mobjReportBrushRed.Color).Brush
                    EV.Graphics.DrawString(strReportHeader8, ReportHeaderFont8, objBrush, rectReportHeader8, New StringFormat)
                    objBrush = New Pen(mobjReportBrushBlue.Color).Brush
                    EV.Graphics.DrawString(strReportHeader9, ReportHeaderFont9, objBrush, rectReportHeader9, New StringFormat)
                    EV.Graphics.DrawString(strReportHeader10, ReportHeaderFont10, objBrush, rectReportHeader10, New StringFormat)
                    objBrush = New Pen(mobjReportBrushBlack.Color).Brush
                    EV.Graphics.DrawString(strReportHeader11, ReportHeaderFont11, objBrush, rectReportHeader11, New StringFormat)
                    EV.Graphics.DrawString(strReportHeader13, ReportHeaderFont13, objBrush, rectReportHeader13, New StringFormat)
                    EV.Graphics.DrawString(strReportHeader15, ReportHeaderFont15, objBrush, rectReportHeader15, New StringFormat)
                    EV.Graphics.DrawString(strReportHeader17, ReportHeaderFont17, objBrush, rectReportHeader17, New StringFormat)
                    EV.Graphics.DrawString(strReportHeader19, ReportHeaderFont19, objBrush, rectReportHeader19, New StringFormat)
                    objBrush = New Pen(mobjReportBrushBlue.Color).Brush
                    EV.Graphics.DrawString(strReportHeader12, ReportHeaderFont12, objBrush, rectReportHeader12, New StringFormat)
                    EV.Graphics.DrawString(strReportHeader14, ReportHeaderFont14, objBrush, rectReportHeader14, New StringFormat)
                    EV.Graphics.DrawString(strReportHeader16, ReportHeaderFont16, objBrush, rectReportHeader16, New StringFormat)
                    objBrush = New Pen(mobjReportBrushRed.Color).Brush
                    EV.Graphics.DrawString(strReportHeader18, ReportHeaderFont18, objBrush, rectReportHeader18, New StringFormat)
                    objBrush = New Pen(mobjReportBrushBlack.Color).Brush
                    EV.Graphics.DrawString(strReportHeader20, ReportHeaderFont20, objBrush, rectReportHeader20, New StringFormat)
                    EV.Graphics.DrawString(strReportHeader21, ReportHeaderFont21, objBrush, rectReportHeader21, New StringFormat)
                    EV.Graphics.DrawString(strReportHeader22, ReportHeaderFont22, objBrush, rectReportHeader22, New StringFormat)
                    EV.Graphics.DrawString(strReportHeader23, ReportHeaderFont23, objBrush, rectReportHeader23, New StringFormat)
                    EV.Graphics.DrawString(strReportHeader24, ReportHeaderFont24, objBrush, rectReportHeader24, New StringFormat)
                    EV.Graphics.DrawString(strReportHeader25, ReportHeaderFont25, objBrush, rectReportHeader25, New StringFormat)
                    EV.Graphics.DrawString(strReportHeader26, ReportHeaderFont26, objBrush, rectReportHeader26, New StringFormat)
                    EV.Graphics.DrawString(strReportHeader27, ReportHeaderFont27, objBrush, rectReportHeader27, New StringFormat)
                    EV.Graphics.DrawString(strReportHeader28, ReportHeaderFont28, objBrush, rectReportHeader28, New StringFormat)
                    EV.Graphics.DrawString(strReportHeader29, ReportHeaderFont29, objBrush, rectReportHeader29, New StringFormat)
                    EV.Graphics.DrawString(strReportHeader30, ReportHeaderFont30, objBrush, rectReportHeader30, New StringFormat)
                    EV.Graphics.DrawString(strReportHeader31, ReportHeaderFont31, objBrush, rectReportHeader31, New StringFormat)
                    EV.Graphics.DrawString(strReportHeader32, ReportHeaderFont32, objBrush, rectReportHeader32, New StringFormat)
                    EV.Graphics.DrawString(strReportHeader33, ReportHeaderFont33, objBrush, rectReportHeader33, New StringFormat)
                    EV.Graphics.DrawString(strReportHeader34, ReportHeaderFont34, objBrush, rectReportHeader34, New StringFormat)
                    EV.Graphics.DrawString(strReportHeader35, ReportHeaderFont35, objBrush, rectReportHeader35, New StringFormat)
                    EV.Graphics.DrawString(strReportHeader36, ReportHeaderFont36, objBrush, rectReportHeader36, New StringFormat)
                    EV.Graphics.DrawString(strReportHeader37, ReportHeaderFont37, objBrush, rectReportHeader37, New StringFormat)

                End If
                intCount += 1
                line = rptPageTextReader.ReadLine()
                intIsPageReapate = False
            End While

            If sngYPositionIn >= mintPageFooterYPosotion Then
                If intIsPageReapate = True Then
                    If blnPageSettingMessage = False Then
                        'Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
                    End If

                    EV.HasMorePages = False
                    EV.Cancel = True
                    Exit Function
                End If

                EV.HasMorePages = True
                intIsPageReapate = True
                Exit Function
            End If

            intIsPageReapate = True
            If Not mstrPageText = "" Then
                sngYPositionIn += (lineSpacing + printFont.GetHeight(EV.Graphics))
            End If

            ' If there are more lines, print on another page.
            If Not (line Is Nothing) Then
                EV.HasMorePages = True
            Else
                EV.HasMorePages = False
            End If

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

    Private Function funcDrawGridTables(ByRef EV As PrintPageEventArgs, ByRef sngYPositionIn As Single, ByVal sngLeftMarginIn As Single) As Boolean
        Dim rectGridData As RectangleF
        Dim blnIsNextPage As Boolean
        Dim sngHeightPosition As Single
        Dim sngHeightOfTableData As Single
        Dim msngHeightOfHeader As Single
        Dim clrMangeta As Drawing.Color
        Dim FontColor As Drawing.Color
        Dim hfBrush As New SolidBrush(Color.Black)
        Dim objPrint_Font As Font
        objPrint_Font = printFont
        Try

            rectGridData.X += sngLeftMarginIn
            rectGridData.Y += sngYPositionIn
            '//----- Added & Modified by Sachin Dokhale on 28.09.05
            rectGridData.Height = EV.MarginBounds.Height - sngYPositionIn   '- mintPageFooterYPosotion

            rectGridData.Width = EV.MarginBounds.Width

            If IsNothing(Me.mobjRptDataTblList) = True Then
                EV.HasMorePages = False
                Exit Function
            End If
            '//-----
            If gstructSettings.blnSelectColorPrinter = False Then
                FontColor = clrMangeta.Black
            Else
                FontColor = clrMangeta.Magenta
            End If
            hfBrush.Color = FontColor
            Do While mintReportTablesCount < Me.mobjRptDataTblList.Count
                printFont = CType(mobjARPortrateReport.Sections("GrpHdrDatafile").Controls("lblHeader"), DataDynamics.ActiveReports.Label).Font
                'EV.Graphics.DrawString(CType(Me.mobjRptDataTblList.Item(mintReportTablesCount), DataTable).TableName, printFont, New Pen(Color.Black).Brush, rectGridData.X, rectGridData.Y)
                EV.Graphics.DrawString(CType(Me.mobjRptDataTblList.Item(mintReportTablesCount), DataTable).TableName, printFont, hfBrush, rectGridData.X, rectGridData.Y)
                rectGridData.Y += EV.Graphics.MeasureString(CType(Me.mobjRptDataTblList.Item(mintReportTablesCount), DataTable).TableName, printFont).Height

                Call DataGridPrintPage(EV, rectGridData, CType(Me.mobjRptDataTblList.Item(mintReportTablesCount), DataTable), mintReportType, blnIsNextPage, sngHeightPosition)

                '//----- Added & Modified by Sachin Dokhale on 28.09.05
                '---Increment GridRect Location 
                sngHeightOfTableData = funcGetDataTableHeight(EV.Graphics, CType(Me.mobjRptDataTblList.Item(mintReportTablesCount), DataTable), printFont, msngHeightOfHeader)

                'rectGridData.Y += sngHeightOfTableData + lineSpacing + printFont.GetHeight(EV.Graphics)
                rectGridData.Y += sngHeightPosition + lineSpacing + printFont.GetHeight(EV.Graphics)
                sngYPositionIn = rectGridData.Y

                'If EV.HasMorePages = False Then
                If blnIsNextPage = False And NextFirstCol > 0 Then
                    If Not mintReportTablesCount = Me.mobjRptDataTblList.Count Then
                        sngHeightOfTableData = funcGetDataTableHeight(EV.Graphics, CType(Me.mobjRptDataTblList.Item(mintReportTablesCount), DataTable), printFont, msngHeightOfHeader)
                        rectGridData.Y += 2 * (lineSpacing + printFont.GetHeight(EV.Graphics))
                        If (mintPageFooterYPosotion - rectGridData.Y) > (msngHeightOfHeader + lineSpacing + printFont.GetHeight(EV.Graphics)) Then

                            '---Continue printing on same page
                            EV.HasMorePages = False

                        Else

                            '---go to the new page

                            EV.HasMorePages = True
                            Return True
                            Exit Function
                        End If
                    End If
                ElseIf blnIsNextPage = False Then

                    '//-----
                    mintReportTablesCount += 1
                    NextFirstCol = 0
                    npp = 0
                    CurRow = 0
                    CurCol = 0
                    EV.HasMorePages = False
                    If Not mintReportTablesCount = Me.mobjRptDataTblList.Count Then
                        sngHeightOfTableData = funcGetDataTableHeight(EV.Graphics, CType(Me.mobjRptDataTblList.Item(mintReportTablesCount), DataTable), printFont, msngHeightOfHeader)
                        rectGridData.Y += 2 * (lineSpacing + printFont.GetHeight(EV.Graphics))
                        If (mintPageFooterYPosotion - rectGridData.Y) > (msngHeightOfHeader + lineSpacing + printFont.GetHeight(EV.Graphics)) Then

                            '---Continue printing on same page
                            EV.HasMorePages = False
                            If blnPageSettingMessage = True Then
                                EV.Cancel = True
                            End If
                        Else

                            '---go to the new page

                            EV.HasMorePages = True

                            Return True
                            Exit Function
                        End If
                    Else
                        If blnPageSettingMessage = True Then
                            EV.Cancel = True
                        End If
                    End If

                Else
                    '//----- Added & Modified by Sachin Dokhale on 28.09.05
                    EV.HasMorePages = blnIsNextPage
                    If blnPageSettingMessage = True Then
                        EV.Cancel = True
                    End If
                    Return True
                    '//-----
                End If
            Loop
            mintReportTablesCount = 0
            mintReportTextTableCount = -1
            EV.HasMorePages = False
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
            '--------------------------------------------------------
            printFont = objPrint_Font
        End Try
    End Function


    Private Function funcDrawTextList(ByRef EV As PrintPageEventArgs, ByRef sngYPositionIn As Single, ByVal sngLeftMarginIn As Single) As Boolean
        Dim rectGridData As RectangleF
        Dim blnIsNextPage As Boolean
        Dim sngHeightPosition As Single
        Dim sngHeightOfTableData As Single
        Dim msngHeightOfHeader As Single

        Try
            rectGridData.X += sngLeftMarginIn
            rectGridData.Y += sngYPositionIn
            '//----- Added & Modified by Sachin Dokhale on 28.09.05
            rectGridData.Height = EV.MarginBounds.Height - sngYPositionIn   '- mintPageFooterYPosotion

            rectGridData.Width = EV.MarginBounds.Width

            If IsNothing(Me.mobjRptDataTblList) = True Or (mintReportTextTableCount = -1) Then
                EV.HasMorePages = False
                Exit Function
            End If
            '//-----

            Do While mintReportTextTableCount < Me.mobjRptDtTextList.Count

                'EV.Graphics.DrawString(CType(Me.mobjRptDtTextList.Item(mintReportTablesCount), DataTable).TableName, printFont, New Pen(Color.Black).Brush, rectGridData.X, rectGridData.Y)
                'rectGridData.Y += EV.Graphics.MeasureString(CType(Me.mobjRptDtTextList.Item(mintReportTablesCount), DataTable).TableName, printFont).Height
                    Call TextListPrintPage(EV, rectGridData, CType(Me.mobjRptDtTextList.Item(mintReportTextTableCount), DataTable), mintReportType, blnIsNextPage, sngHeightPosition)

                '//----- Added & Modified by Sachin Dokhale on 28.09.05
                '---Increment GridRect Location 

                sngHeightOfTableData = funcGetDataTableHeight(EV.Graphics, CType(Me.mobjRptDtTextList.Item(mintReportTextTableCount), DataTable), printFont, msngHeightOfHeader)

                'rectGridData.Y += sngHeightOfTableData + lineSpacing + printFont.GetHeight(EV.Graphics)
                rectGridData.Y += sngHeightPosition '+ lineSpacing + printFont.GetHeight(EV.Graphics)
                sngYPositionIn = rectGridData.Y

                'If EV.HasMorePages = False Then
                If blnIsNextPage = False And NextFirstCol > 0 Then
                    If Not mintReportTextTableCount = Me.mobjRptDtTextList.Count Then
                        sngHeightOfTableData = funcGetDataTableHeight(EV.Graphics, CType(Me.mobjRptDtTextList.Item(mintReportTextTableCount), DataTable), printFont, msngHeightOfHeader)
                        rectGridData.Y += 1 * (lineSpacing + printFont.GetHeight(EV.Graphics))
                        If (mintPageFooterYPosotion - rectGridData.Y) > (msngHeightOfHeader + lineSpacing + printFont.GetHeight(EV.Graphics)) Then

                            '---Continue printing on same page
                            EV.HasMorePages = False
                        Else
                            '---go to the new page

                            EV.HasMorePages = True
                            Return True
                            Exit Function
                        End If
                    End If
                ElseIf blnIsNextPage = False Then
                    '//-----
                    mintReportTextTableCount += 1
                    NextFirstCol = 0
                    npp = 0
                    CurRow = 0
                    CurCol = 0
                    EV.HasMorePages = False
                    If Not mintReportTextTableCount = Me.mobjRptDtTextList.Count Then
                        sngHeightOfTableData = funcGetDataTableHeight(EV.Graphics, CType(Me.mobjRptDtTextList.Item(mintReportTextTableCount), DataTable), printFont, msngHeightOfHeader)
                        rectGridData.Y += 1 * (lineSpacing + printFont.GetHeight(EV.Graphics))
                        If (mintPageFooterYPosotion - rectGridData.Y) > (msngHeightOfHeader + lineSpacing + printFont.GetHeight(EV.Graphics)) Then

                            '---Continue printing on same page
                            EV.HasMorePages = False
                            If blnPageSettingMessage = True Then
                                EV.Cancel = True
                            End If
                        Else

                            '---go to the new page

                            EV.HasMorePages = True

                            Return True
                            Exit Function
                        End If
                    Else
                        If blnPageSettingMessage = True Then
                            EV.Cancel = True
                        End If
                    End If

                Else
                    '//----- Added & Modified by Sachin Dokhale on 28.09.05
                    EV.HasMorePages = blnIsNextPage
                    If blnPageSettingMessage = True Then
                        EV.Cancel = True
                    End If
                    Return True
                    Exit Function
                    '//-----
                End If
            Loop
            mintReportTablesCount = 0
            mintReportTextTableCount = -1
            EV.HasMorePages = False
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
    'If mintReportType = enumReportType.RepeatResults Then

    'end if
    Private Function funcDrawRepeatDataText(ByRef EV As PrintPageEventArgs, ByRef sngYPositionIn As Single, ByVal sngLeftMarginIn As Single) As Boolean
        Dim rectGridData As RectangleF
        Dim blnIsNextPage As Boolean
        Dim sngHeightPosition As Single
        Dim sngHeightOfTableData As Single
        Dim msngHeightOfHeader As Single

        Try
            rectGridData.X += sngLeftMarginIn
            rectGridData.Y += sngYPositionIn
            '//----- Added & Modified by Sachin Dokhale on 28.09.05
            rectGridData.Height = EV.MarginBounds.Height - sngYPositionIn   '- mintPageFooterYPosotion

            rectGridData.Width = EV.MarginBounds.Width

            If IsNothing(Me.mobjRptDataTblList) = True Or (mintReportTextTableCount = -1) Then
                EV.HasMorePages = False
                Exit Function
            End If
            '//-----

            'Do While mintReportTextTableCount < Me.mobjRptDtTextList.Count

            'EV.Graphics.DrawString(CType(Me.mobjRptDtTextList.Item(mintReportTablesCount), DataTable).TableName, printFont, New Pen(Color.Black).Brush, rectGridData.X, rectGridData.Y)
            'rectGridData.Y += EV.Graphics.MeasureString(CType(Me.mobjRptDtTextList.Item(mintReportTablesCount), DataTable).TableName, printFont).Height
            '//--- Print head only for 1 page for Repeat Result Ref. by CS on 29.05.08
            If blnEscapeHeader = False Then
                Call subDatafileInitInfo(EV, rectGridData, CType(RepeatDatafile.Item(2), DataTable), enumReportType.RepeatResults, sngYPositionIn)
                blnEscapeHeader = True
            End If
            '//---
            rectGridData.Y = sngYPositionIn
            Call DataFileTextListPrintPage(EV, rectGridData, CType(RepeatDatafile.Item(0), DataTable), CType(RepeatDatafile.Item(1), DataTable), mintReportType, blnIsNextPage, sngHeightPosition)

            '//----- Added & Modified by Sachin Dokhale on 28.09.05
            '---Increment GridRect Location 

            sngHeightOfTableData = funcGetDataTableHeight(EV.Graphics, CType(Me.RepeatDatafile.Item(mintReportTextTableCount), DataTable), printFont, msngHeightOfHeader)

            'rectGridData.Y += sngHeightOfTableData + lineSpacing + printFont.GetHeight(EV.Graphics)
            rectGridData.Y += sngHeightPosition '+ lineSpacing + printFont.GetHeight(EV.Graphics)
            sngYPositionIn = rectGridData.Y

            'If EV.HasMorePages = False Then
            If blnIsNextPage = False And NextFirstCol > 0 Then
                If Not mintReportTextTableCount = Me.RepeatDatafile.Count Then
                    sngHeightOfTableData = funcGetDataTableHeight(EV.Graphics, CType(Me.RepeatDatafile.Item(mintReportTextTableCount), DataTable), printFont, msngHeightOfHeader)
                    rectGridData.Y += 1 * (lineSpacing + printFont.GetHeight(EV.Graphics))
                    If (mintPageFooterYPosotion - rectGridData.Y) > (msngHeightOfHeader + lineSpacing + printFont.GetHeight(EV.Graphics)) Then

                        '---Continue printing on same page
                        EV.HasMorePages = False
                    Else
                        '---go to the new page

                        EV.HasMorePages = True
                        Return True
                    End If
                End If
            ElseIf blnIsNextPage = False Then
                '//-----
                mintReportTextTableCount += 1
                NextFirstCol = 0
                npp = 0
                CurRow = 0
                CurCol = 0
                EV.HasMorePages = False
                If Not mintReportTextTableCount = CType(Me.RepeatDatafile.Item(1), DataTable).Rows.Count Then
                    sngHeightOfTableData = funcGetDataTableHeight(EV.Graphics, CType(Me.RepeatDatafile.Item(mintReportTextTableCount), DataTable), printFont, msngHeightOfHeader)
                    rectGridData.Y += 1 * (lineSpacing + printFont.GetHeight(EV.Graphics))
                    If (mintPageFooterYPosotion - rectGridData.Y) > (msngHeightOfHeader + lineSpacing + printFont.GetHeight(EV.Graphics)) Then

                        '---Continue printing on same page
                        EV.HasMorePages = False
                        If blnPageSettingMessage = True Then
                            EV.Cancel = True
                        End If
                    Else

                        '---go to the new page

                        'EV.HasMorePages = True

                        Return True
                    End If
                Else
                    If blnPageSettingMessage = True Then
                        EV.Cancel = True
                    End If
                End If

            Else
                '//----- Added & Modified by Sachin Dokhale on 28.09.05
                EV.HasMorePages = blnIsNextPage
                If blnPageSettingMessage = True Then
                    EV.Cancel = True
                End If
                Return True
                '//-----
            End If
            'Loop
            mintReportTablesCount = 0
            mintReportTextTableCount = -1
            EV.HasMorePages = False
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

    Private Function funcDrawAllImages(ByRef EV As PrintPageEventArgs, ByRef sngYPositionIn As Single, ByVal sngLeftMarginIn As Single) As Boolean
        Dim objBitmapImage As Bitmap
        Dim rectImage As RectangleF
        Dim sngHeightOfImage As Single
        Dim sngWidthOfImage As Single
        Dim intRectImageYPosition As Integer

        Try
            'If mintReportType = enumReportType.Shade555SortResults Then
            '    sngLeftMarginIn = 400
            '    '//----- Commited by Sachin Dokhale on 8.1.06
            '    'sngYPositionIn = 220.5
            '    '//----- Added by Sachin Dokhale 
            '    sngYPositionIn = funcDrawPageHeader(EV.Graphics, EV.MarginBounds.Left, EV.MarginBounds.Top, mintReportLayoutType)
            '    '//-----
            'End If

            rectImage.X = sngLeftMarginIn
            rectImage.Y = sngYPositionIn
            rectImage.Y += 2 * (lineSpacing + printFont.GetHeight(EV.Graphics))
            rectImage.Height = (EV.MarginBounds.Height - sngYPositionIn) ' + (lineSpacing + printFont.GetHeight(EV.Graphics))
            'rectImage.Height = 4 * (lineSpacing + printFont.GetHeight(EV.Graphics))



            '//----- Added by Sachin Dokhale on 28.09.05
            If rectImage.Height > 0 Then
                intRectImageYPosition = CInt(rectImage.Y + rectImage.Height)
            Else
                intRectImageYPosition = CInt(rectImage.Y) + CInt(Math.Abs(rectImage.Height))   '(rectImage.Y)
            End If
            '//-----
            rectImage.Width = EV.MarginBounds.Width
            'rectImage.Y -= lineSpacing + printFont.GetHeight(EV.Graphics)

            If IsNothing(Me.mobjDtImageList) = True Then
                Exit Function
            End If
            '//----- Added by Sachin Dokhale on 28.09.05
            'If intrectImageYPosition >= mintPageFooterYPosotion Then
            '    EV.HasMorePages = True
            '    Exit Function
            'End If
            '//-----

            Select Case mintReportType
                'Case enumReportType.EditShade
                '    If funcDrawShadeCardImages(EV, rectImage, 4) = False Then
                '        Return False
                '    End If

                'Case enumReportType.QCStrengthVisual
                '    If funcDrawShadeCardImages(EV, rectImage, 3) = False Then
                '        Return False
                '    End If

                'Case enumReportType.QCColorOnObject
                '    If funcDrawShadeCardImages(EV, rectImage, 1) = False Then
                '        Return False
                '    End If

                'Case enumReportType.QCMetamerism
                '    If funcDrawShadeCardImages(EV, rectImage, 3) = False Then
                '        Return False
                '    End If

                'Case enumReportType.EditColorants, enumReportType.EditPigment, enumReportType.EditSubstrate
                '    If funcDrawShadeCardImages(EV, rectImage, mobjDtImageList.Rows.Count) = False Then
                '        Return False
                '    End If

                'Case enumReportType.BatchCorrection
                '    If funcDrawShadeCardImages(EV, rectImage, 3) = False Then
                '        Return False
                '    End If

            Case Else
                    If funcDrawShadeCardImages(EV, rectImage, 2) = False Then
                        Return False
                    End If

            End Select

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

    Private Function funcDrawShadeCardImages(ByRef EV As PrintPageEventArgs, ByVal rectAllImagesGrid As RectangleF, ByVal intNoOfColumnsPerPage As Integer) As Boolean
        '=====================================================================
        ' Procedure Name        : funcDrawShadeCardImages
        ' Parameters Passed     : PrintPageEventArgs, rectangleF
        ' Returns               : True or False
        ' Purpose               : To draw the images on report in rows and columns
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul 
        ' Created               : Friday 01 April 2005 10:45 am
        ' Revisions             : 2
        '=====================================================================
        Dim objBitmapImage As Bitmap
        Dim rectImage As RectangleF
        Dim sngHeightOfImage As Single
        Dim sngWidthOfImage As Single
        Dim sngLeftMargin As Single
        Dim sngYPosition As Single
        Dim intRowCounter As Integer
        Dim nrperpage As Integer
        Dim sngEachImageHeight As Single
        Dim strImageCaption As String
        Dim sngEachImageCaptionHeight As Single
        Dim objDtImagesPerPage As DataTable
        Dim objDrNewRow As DataRow
        Dim intTotalFreeSpaceHeightForAllImagesGrid As Integer
        Static intIsPageReapate As Boolean
        Try
            If IsNothing(Me.mobjDtImageList) = True Then
                Return True
                Exit Function
            End If
            '//----- Add By Sachin Dokhale 
            '//----- Exit when Current Count and total ImageList Count is Save
            '//----- means all Image is Printed 
            If (mintCurrentImageRow >= mobjDtImageList.Rows.Count) Then
                Return True
                Exit Function
            End If
            '//-----
            'intNoOfColumnsPerPage = 3

            sngLeftMargin = rectAllImagesGrid.X
            sngYPosition = rectAllImagesGrid.Y
            ''rectAllImagesGrid.Height -= 14

            '---Work out the number of pages
            sngEachImageHeight = CType(mobjDtImageList.Rows(0).Item("Image"), Bitmap).Height
            strImageCaption = CType(mobjDtImageList.Rows(0).Item("ImageCaption"), String)
            sngEachImageCaptionHeight = CSng(1.2 * (EV.Graphics.MeasureString(strImageCaption, printFont).Height))

            'nrperpage = CInt((rectAllImagesGrid.Height)) \ CInt((sngEachImageHeight + sngEachImageCaptionHeight))
            '//----- Added by Sachin Dokhale on 11.04.06
            '//----- Adjestate to the TextHeight

            intTotalFreeSpaceHeightForAllImagesGrid = CInt(rectAllImagesGrid.Height) - mintTotalHeightOfPageText
            nrperpage = intTotalFreeSpaceHeightForAllImagesGrid \ CInt((sngEachImageHeight + sngEachImageCaptionHeight))
            mintTotalHeightOfPageText = 0
            '//-----

            If nrperpage > 1 Then
                nrperpage -= 1
            ElseIf nrperpage = 2 Then
                nrperpage = 2
            ElseIf nrperpage = 1 Then
                nrperpage = 1
            ElseIf nrperpage = 0 Then
                If intIsPageReapate = True Then
                    If blnPageSettingMessage = False Then
                        'Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
                        'Application.DoEvents()
                        'cWait = New CWaitCursor
                        blnPageSettingMessage = True
                    End If
                    EV.HasMorePages = False
                    EV.Cancel = True
                    Return True
                    Exit Function
                End If
                nrperpage = 0
                intIsPageReapate = True
                EV.HasMorePages = True
                Return True
            End If
            If nrperpage > 14 Then
                nrperpage = 14
            End If
            '//----- Commented by Sachin Dokhale on 12.04.06
            'If nrperpage > 13 Then
            '    nrperpage = 13
            'End If
            '//-----

            '---Work out no. of pages considering no. of columns in each page
            nrperpage = nrperpage * intNoOfColumnsPerPage

            objDtImagesPerPage = New DataTable
            objDtImagesPerPage = mobjDtImageList.Clone

            For intRowCounter = mintCurrentImageRow To nrperpage + mintCurrentImageRow - 1
                If intRowCounter >= mobjDtImageList.Rows.Count Then
                    Exit For
                End If
                objDrNewRow = mobjDtImageList.DefaultView.Item(intRowCounter).Row
                objDtImagesPerPage.ImportRow(objDrNewRow)
            Next intRowCounter

            mintCurrentImageRow = intRowCounter

            If Me.ArrangeImagesInGrid(objDtImagesPerPage, EV.Graphics, intNoOfColumnsPerPage, sngLeftMargin, sngYPosition) = True Then
                'If we have more Images then print another page
                If (mintCurrentImageRow < mobjDtImageList.Rows.Count) Then
                    EV.HasMorePages = True
                    intIsPageReapate = True
                Else
                    '//----- Commented by Sachin Dikhale on 7.1.06
                    '//----- Not required to ev.HasMorePages = False
                    'If mintReportType = enumReportType.Shade555SortResults Then
                    '    'EV.HasMorePages = False
                    '    'mintCurrentImageRow = 0
                    '    intIsPageReapate = False
                    'Else
                    '    'EV.HasMorePages = False
                    '    'mintCurrentImageRow = 0
                    '    intIsPageReapate = False
                    'End If

                End If
            Else
                intIsPageReapate = False
            End If
            ' intIsPageReapate = False
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

    Private Sub DataGridPrintPage(ByRef ev As System.Drawing.Printing.PrintPageEventArgs, _
                                 ByVal rectGrid As Drawing.RectangleF, _
                                 ByVal objDtReportDataTableIn As DataTable, _
                                 ByVal intReportTypeIn As enumReportType, ByRef IsNextPage As Boolean, _
                                 ByRef YPosition As Single)

        NextFirstCol = 0
        npp += 1

        mobjDvReportDataView = objDtReportDataTableIn.DefaultView

        Dim lpp As Single = 0
        Dim yPos As Single = 0
        Dim count As Integer = 0
        Dim leftMargin As Single = rectGrid.Left
        Dim topMargin As Single = rectGrid.Top
        Dim line As String
        Dim rowHeight As Integer
        Dim headerHeight As Integer
        Dim i, j, w, l As Integer
        Dim divPen As New Pen(Color.Black)  'mobjReportDataGrid.GridLineColor)
        Dim hfpen As New Pen(Color.Black)   'mobjReportDataGrid.HeaderForeColor)
        Dim hbBrush As New SolidBrush(Color.White)  'mobjReportDataGrid.HeaderBackColor)
        Dim hfBrush As New SolidBrush(Color.Black)  'mobjReportDataGrid.HeaderForeColor)
        Dim CellSize As SizeF
        Static PrevRowCount As Integer
        Static blnPrevRow As Boolean
        Static intIsPageReapate As Boolean

        Try

            '//----- Added & Modified by Sachin Dokhale on 28.09.05
            lpp = rectGrid.Height / printFont.GetHeight(ev.Graphics)
            'rowHeight = 14 'PreferredRowHeight
            rowHeight = CInt(printFont.GetHeight(ev.Graphics)) + 1
            headerHeight = 18
            If rectGrid.Y >= mintPageFooterYPosotion Then
                If intIsPageReapate = True Then
                    If blnPageSettingMessage = False Then
                        'Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
                        'Application.DoEvents()
                        'cWait = New CWaitCursor
                        blnPageSettingMessage = True
                    End If

                    IsNextPage = False
                    Exit Try
                End If
                IsNextPage = True
                intIsPageReapate = True
                Exit Try
            End If
            rectGrid.Height = (mintPageFooterYPosotion - 15) - rectGrid.Y
            If rectGrid.Height <= rowHeight Then
                If intIsPageReapate = True Then
                    If blnPageSettingMessage = False Then
                        'Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
                        'cWait = New CWaitCursor
                        blnPageSettingMessage = True
                    End If
                    IsNextPage = False
                    Exit Try
                End If
                IsNextPage = True
                intIsPageReapate = True
                Exit Try
            End If
            NoOfRowsPerPage = ((CInt(rectGrid.Height) \ rowHeight) - (headerHeight \ rowHeight) - 1)   '(CInt(rectGrid.Y) \ rowHeight) '- (headerHeight \ rowHeight) '- PrevRowCount
            '//-----

            l = CInt(topMargin)
            w = CInt(leftMargin)
            Dim sngCellHeight As Single = 0.0
            Dim MaxCellHeight As Single = 0.0


            For j = CurCol To objDtReportDataTableIn.Columns.Count - 1

                CellSize = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, j)
                CellSize.Height += 10
                Dim sngColumnWidth As Single = CellSize.Width

                If w + sngColumnWidth >= rectGrid.Right And j <> CurCol Then
                    NextFirstCol = j
                    Exit For
                End If
                If sngColumnWidth = 0 Then GoTo continuefor

                'Dim r As New Rectangle(w, l, CInt(sngColumnWidth + 1), headerHeight)
                Dim r As New Rectangle(New Point(w, l), CellSize.ToSize)

                Dim rf As New Drawing.RectangleF(w, l, r.Width, r.Height)

                'headerFont = CType(mobjARPortrateReport.Sections("GrpHdrStadGraph").Controls("Txt1"), DataDynamics.ActiveReports.Label).Font
                headerFont = CType(mobjARPortrateReport.Sections("GrpHdrDatafile").Controls("Txt1"), DataDynamics.ActiveReports.Label).Font
                If objDtReportDataTableIn.Columns(j).Caption = "" Then
                    ev.Graphics.DrawString(objDtReportDataTableIn.Columns(j).Caption, headerFont, hfBrush, rf)
                Else
                    Call PaintHeaderCell(ev.Graphics, objDtReportDataTableIn.Columns(j).Caption, _
                                                    headerFont, hfBrush, r, 1, 1)
                End If


                ev.Graphics.DrawLine(divPen, r.X, r.Y, r.Right, r.Y)


                ''ev.Graphics.DrawLine(divPen, r.X, r.Bottom + 5, r.Right, r.Y + r.Height + 5) 'commented on 27.3.2009
                ev.Graphics.DrawLine(divPen, r.X, r.Bottom + 20, r.Right, r.Y + r.Height + 20) ' code added on : 27.3.2009

                w += CInt(sngColumnWidth)

                ''headerHeight = r.Height + 5 'commented on 27.3.2009
                headerHeight = r.Height + 20 ' code added on 27.3.2009

continuefor:
            Next j
            'l += r.Height 'CellSize.ToSize.Height   'headerHeight
            l += headerHeight
            NoOfRowsPerPage = ((CInt(rectGrid.Height) \ rowHeight) - (headerHeight \ rowHeight) - 1)   '(CInt(rectGrid.Y) \ rowHeight) '- (headerHeight \ rowHeight) '- PrevRowCount
            'aa = CurRow
            printFont = CType(mobjARPortrateReport.Sections("GrpHdrDatafile").Controls("TxtLable1"), DataDynamics.ActiveReports.Label).Font
            For i = CurRow To NoOfRowsPerPage + CurRow - 1
                If i >= mobjDvReportDataView.Count Then Exit For
                w = CInt(leftMargin)

                For j = CurCol To objDtReportDataTableIn.Columns.Count - 1
                    If IsNothing(ColoumnFormat) Then
                        ColoumnFormat = New StringFormat
                    End If
                    Dim sngColumnWidth As Single = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, j).Width

                    If w + sngColumnWidth >= rectGrid.Right And j <> CurCol Then Exit For
                    If sngColumnWidth = 0 Then GoTo continuefor2

                    'Dim r As New Rectangle(w, l, CInt(sngColumnWidth + 0.75), rowHeight)


                    If IsNumeric(mobjDvReportDataView.Item(i).Item(j).ToString()) Then
                        Dim r As New Rectangle(w, l, CInt(sngColumnWidth - 10), rowHeight)
                        Dim rf As New Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height)

                        If SetTableColoumnFormat = True Then
                            If j = 0 Then
                                'ColoumnFormat.Alignment = StringAlignment.Near
                                ColoumnFormat.Alignment = StringAlignment.Center
                            Else
                                'ColoumnFormat.Alignment = StringAlignment.Far
                                ColoumnFormat.Alignment = StringAlignment.Center
                            End If
                        End If
                        ev.Graphics.DrawString(mobjDvReportDataView.Item(i).Item(j).ToString(), printFont, Drawing.Brushes.Black, rf, ColoumnFormat)

                    Else
                        Dim r As New Rectangle(w, l, CInt(sngColumnWidth - 3), rowHeight)
                        Dim rf As New Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height)
                        If SetTableColoumnFormat = True Then
                            If j = 0 Then
                                'ColoumnFormat.Alignment = StringAlignment.Near
                                ColoumnFormat.Alignment = StringAlignment.Center
                            Else
                                'ColoumnFormat.Alignment = StringAlignment.Near
                                ColoumnFormat.Alignment = StringAlignment.Center
                            End If
                        End If
                        ev.Graphics.DrawString(mobjDvReportDataView.Item(i).Item(j).ToString(), printFont, Drawing.Brushes.Black, rf, ColoumnFormat)
                    End If
                    'ev.Graphics.DrawString(mobjDvReportDataView.Item(i).Item(j).ToString(), printFont, Drawing.Brushes.Black, rf)

                    w += CInt(sngColumnWidth)
continuefor2:
                Next

                l += rowHeight
            Next
            CurRow = i
            PrevRowCount = i

            Dim sngXPos As Single = leftMargin
            Dim intTotalGridHeight As Integer
            intTotalGridHeight = l - CInt(topMargin) + 10

            ev.Graphics.DrawLine(New Pen(Color.Black), leftMargin, topMargin, sngXPos, topMargin + intTotalGridHeight)
            For j = CurCol To objDtReportDataTableIn.Columns.Count - 1
                Dim sngColumnWidth As Single

                If NextFirstCol > 0 And j >= NextFirstCol Then
                    Exit For
                End If
                sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, j).Width
                sngXPos += sngColumnWidth
                ev.Graphics.DrawLine(New Pen(Color.Black), sngXPos, topMargin, sngXPos, topMargin + intTotalGridHeight)
            Next j
            ev.Graphics.DrawLine(New Pen(Color.Black), leftMargin, topMargin + intTotalGridHeight, sngXPos, topMargin + intTotalGridHeight)
            ev.Graphics.DrawLine(New Pen(Color.Black), sngXPos, topMargin, sngXPos, topMargin + intTotalGridHeight)
            ev.Graphics.DrawLine(New Pen(Color.Black), leftMargin, topMargin + intTotalGridHeight, sngXPos, topMargin + intTotalGridHeight)

            '//----- Added & Modified by Sachin Dokhale on 28.09.05
            YPosition = CSng(intTotalGridHeight)
            '//-----
            If npp >= NoOfPagesPreviewed Then
                'ev.HasMorePages = True
                'IsNextPage = True
                npp -= NoOfPagesPreviewed
            End If
            'If we have more lines then print another page
            If (CurRow < mobjDvReportDataView.Count) Then
                'ev.HasMorePages = True
                IsNextPage = True
            Else

                If NextFirstCol = 0 Then
                    'ev.HasMorePages = False
                    IsNextPage = False
                Else
                    CurRow = 0
                    CurCol = NextFirstCol
                    'ev.HasMorePages = True
                    'IsNextPage = True
                End If
            End If
            intIsPageReapate = False
            divPen.Dispose()
            hfpen.Dispose()
            hbBrush.Dispose()
            hfBrush.Dispose()

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

    Private Sub TextListPrintPage(ByRef ev As System.Drawing.Printing.PrintPageEventArgs, _
                                 ByVal rectGrid As Drawing.RectangleF, _
                                 ByVal objDtReportDataTableIn As DataTable, _
                                 ByVal intReportTypeIn As enumReportType, ByRef IsNextPage As Boolean, _
                                 ByRef YPosition As Single)

        NextFirstCol = 0
        npp += 1

        mobjDvReportDataView = objDtReportDataTableIn.DefaultView

        Dim lpp As Single = 0
        Dim yPos As Single = 0
        Dim count As Integer = 0
        Dim leftMargin As Single = rectGrid.Left
        Dim topMargin As Single = rectGrid.Top
        Dim line As String
        Dim rowHeight As Integer
        Dim headerHeight As Integer
        Dim i, j, w, l As Integer
        Dim divPen As New Pen(Color.Black)  'mobjReportDataGrid.GridLineColor)
        Dim hfpen As New Pen(Color.Black)   'mobjReportDataGrid.HeaderForeColor)
        Dim hbBrush As New SolidBrush(Color.White)  'mobjReportDataGrid.HeaderBackColor)
        Dim hfBrush As New SolidBrush(Color.Black)  'mobjReportDataGrid.HeaderForeColor)
        Dim CellSize As SizeF
        Dim sngColumnWidth As Single

        Static PrevRowCount As Integer
        Static blnPrevRow As Boolean
        Static intIsPageReapate As Boolean

        Try

            '//----- Added & Modified by Sachin Dokhale on 28.09.05
            lpp = rectGrid.Height / printFont.GetHeight(ev.Graphics)
            'rowHeight = 14 'PreferredRowHeight
            rowHeight = CInt(printFont.GetHeight(ev.Graphics)) + 1
            headerHeight = 18
            If rectGrid.Y >= mintPageFooterYPosotion Then
                If intIsPageReapate = True Then
                    If blnPageSettingMessage = False Then
                        'Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
                        'Application.DoEvents()
                        'cWait = New CWaitCursor
                        blnPageSettingMessage = True
                    End If

                    IsNextPage = False
                    Exit Try
                End If
                IsNextPage = True
                intIsPageReapate = True
                Exit Try
            End If
            rectGrid.Height = (mintPageFooterYPosotion - 15) - rectGrid.Y
            If rectGrid.Height <= rowHeight Then
                If intIsPageReapate = True Then
                    If blnPageSettingMessage = False Then
                        'Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
                        'cWait = New CWaitCursor
                        blnPageSettingMessage = True
                    End If
                    IsNextPage = False
                    Exit Try
                End If
                IsNextPage = True
                intIsPageReapate = True
                Exit Try
            End If
            NoOfRowsPerPage = ((CInt(rectGrid.Height) \ rowHeight) - (headerHeight \ rowHeight) - 1)   '(CInt(rectGrid.Y) \ rowHeight) '- (headerHeight \ rowHeight) '- PrevRowCount
            '//-----

            l = CInt(topMargin)
            w = CInt(leftMargin)
            Dim sngCellHeight As Single = 0.0
            Dim MaxCellHeight As Single = 0.0


            '            For j = CurCol To objDtReportDataTableIn.Columns.Count - 1
            '                CellSize = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, j)

            '                sngColumnWidth = CellSize.Width

            '                If w + sngColumnWidth >= rectGrid.Right And j <> CurCol Then
            '                    NextFirstCol = j
            '                    Exit For
            '                End If
            '                If sngColumnWidth = 0 Then GoTo continuefor

            '                'Dim r As New Rectangle(w, l, CInt(sngColumnWidth + 1), headerHeight)
            '                Dim r As New Rectangle(New Point(w, l), CellSize.ToSize)

            '                Dim rf As New Drawing.RectangleF(w, l, r.Width, r.Height)

            '                If objDtReportDataTableIn.Columns(j).Caption = "" Then
            '                    ev.Graphics.DrawString(objDtReportDataTableIn.Columns(j).Caption, headerFont, hfBrush, rf)
            '                Else
            '                    Call PaintHeaderCell(ev.Graphics, objDtReportDataTableIn.Columns(j).Caption, _
            '                                                    headerFont, hfBrush, r, 1, 1)
            '                End If


            '                ev.Graphics.DrawLine(divPen, r.X, r.Y, r.Right, r.Y)
            '                ev.Graphics.DrawLine(divPen, r.X, r.Bottom, r.Right, r.Y + r.Height)

            '                w += CInt(sngColumnWidth)

            '                headerHeight = r.Height

            'continuefor:
            '            Next j


            'l += r.Height 'CellSize.ToSize.Height   'headerHeight
            l += headerHeight
            Dim blnIsLeft As Boolean = False
            Dim ReportHeader1Font As Font
            Dim ReportHeaderFont As Font
            Dim ReportText1Font As Font
            Dim ReportHeader2Font As Font
            Dim ReportText2Font As Font
            Dim rectReportHeader As Drawing.RectangleF
            Dim r As Rectangle
            Dim rf As Drawing.RectangleF
            Dim sizStringSize As SizeF
            Dim newStringFormat As New StringFormat
            Dim intLineHeigt As Integer
            Dim clrMangeta As Drawing.Color
            Dim FontColor As Drawing.Color
            NoOfRowsPerPage = ((CInt(rectGrid.Height) \ rowHeight) - (headerHeight \ rowHeight) - 1)   '(CInt(rectGrid.Y) \ rowHeight) '- (headerHeight \ rowHeight) '- PrevRowCount


            ReportHeaderFont = CType(mobjARPortrateReport.Sections("GrpHdrDatafile").Controls("lblHeader"), DataDynamics.ActiveReports.Label).Font
            ReportHeader1Font = CType(mobjARPortrateReport.Sections("GrpHdrDatafile").Controls("TxtLable1"), DataDynamics.ActiveReports.Label).Font
            ReportText1Font = CType(mobjARPortrateReport.Sections("GrpHdrDatafile").Controls("Txt1"), DataDynamics.ActiveReports.Label).Font
            ReportHeader2Font = CType(mobjARPortrateReport.Sections("GrpHdrDatafile").Controls("TxtLable2"), DataDynamics.ActiveReports.Label).Font
            ReportText2Font = CType(mobjARPortrateReport.Sections("GrpHdrDatafile").Controls("Txt2"), DataDynamics.ActiveReports.Label).Font
            rectReportHeader = CType(mobjARPortrateReport.Sections("GrpHdrDatafile").Controls("Txt2"), DataDynamics.ActiveReports.Label).GetBounds

            If PrinterType = False Then
                FontColor = clrMangeta.Black
            Else
                FontColor = clrMangeta.Magenta
            End If

            w = CInt(leftMargin)

            rowHeight = CInt(ReportText1Font.GetHeight(ev.Graphics)) + 1
            'If Not objDtReportDataTableIn.Rows.Item(0).Item(0).ToString = "" Then
            If Not objDtReportDataTableIn.Columns(j).Caption = "" Then
                'sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, j).Width
                sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 4).Width

                r = New Rectangle(w, l, CInt(sngColumnWidth + 50), rowHeight)
                rf = New Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height)

                hfBrush.Color = FontColor
                ev.Graphics.DrawString(objDtReportDataTableIn.Columns(j).Caption, ReportHeaderFont, hfBrush, rf)
                hfBrush.Color = clrMangeta.Black
                If Not objDtReportDataTableIn.Rows.Item(0).Item(0).ToString = "" Then

                    r = New Rectangle(w + 200, l, CInt(sngColumnWidth - 3), rowHeight)
                    rf = New Drawing.RectangleF(w + 205, l + 2, r.Width, r.Height)

                    hfBrush.Color = FontColor
                    ev.Graphics.DrawString(objDtReportDataTableIn.Rows.Item(0).Item(0).ToString, ReportHeaderFont, hfBrush, rf)
                    hfBrush.Color = clrMangeta.Black
                End If
                l += r.Height + 10
            End If
            'rowHeight = CInt(rectReportHeader.Height)

            'aa = CurRow
            '= funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, j).Width
            'For i = CurLine To NoOfRowsPerPage + CurLine - 1

            'If i >= mobjDvReportDataView.Count Then Exit For

            j = 1


            'For j = CurRow To objDtReportDataTableIn.Rows.Count - 1
            'hfBrush.Color = clrMangeta.Magenta
            Do While j <= objDtReportDataTableIn.Columns.Count - 1
                '    Dim sngColumnWidth As Single = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, j).Width

                '   If w + sngColumnWidth >= rectGrid.Right And j <> CurCol Then Exit For
                '  If sngColumnWidth = 0 Then GoTo continuefor2

                'Dim r As New Rectangle(w, l, CInt(sngColumnWidth + 0.75), rowHeight)


                'If IsNumeric(mobjDvReportDataView.Item(i).Item(j).ToString()) Then
                '    Dim r As New Rectangle(w, l, CInt(sngColumnWidth - 10), rowHeight)
                '    Dim rf As New Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height)


                '    If IsNothing(ColoumnFormat) Then
                '        ColoumnFormat = New StringFormat
                '    End If
                '    If SetTableColoumnFormat = True Then
                '        ColoumnFormat.Alignment = StringAlignment.Far
                '    End If
                '    ev.Graphics.DrawString(mobjDvReportDataView.Item(i).Item(j).ToString(), printFont, Drawing.Brushes.Black, rf, ColoumnFormat)

                'Else
                '    Dim r As New Rectangle(w, l, CInt(sngColumnWidth - 3), rowHeight)
                '    Dim rf As New Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height)
                '    If IsNothing(ColoumnFormat) Then
                '        ColoumnFormat = New StringFormat
                '    End If
                '    If SetTableColoumnFormat = True Then
                '        ColoumnFormat.Alignment = StringAlignment.Near
                '    End If
                '    ev.Graphics.DrawString(mobjDvReportDataView.Item(i).Item(j).ToString(), printFont, Drawing.Brushes.Black, rf, ColoumnFormat)
                'End If

                'Dim sngColumnWidth As Single = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, j).Width

                If IsNumeric(mobjDvReportDataView.Item(i).Item(j).ToString()) Then

                    If IsNothing(ColoumnFormat) Then
                        ColoumnFormat = New StringFormat
                    End If
                    If SetTableColoumnFormat = True Then
                        ColoumnFormat.Alignment = StringAlignment.Near
                    End If
                Else
                    If IsNothing(ColoumnFormat) Then
                        ColoumnFormat = New StringFormat
                    End If
                    If SetTableColoumnFormat = True Then
                        ColoumnFormat.Alignment = StringAlignment.Near
                    End If
                End If

                CurRow = 1
                newStringFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft
                newStringFormat.Alignment = StringAlignment.Near

                If blnIsLeft = False Then


                    sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 0).Width
                    sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Columns(j).Caption, ReportHeader1Font, CInt(sngColumnWidth), newStringFormat)
                    rowHeight = CInt(sizStringSize.Height)

                    r = New Rectangle(w, l, CInt(sngColumnWidth - 3), rowHeight)
                    rf = New Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height)

                    ev.Graphics.DrawString(objDtReportDataTableIn.Columns(j).Caption, ReportHeader1Font, hfBrush, rf)
                    intLineHeigt = l + r.Height

                    sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 1).Width
                    If Not (objDtReportDataTableIn.Rows.Item(i).Item(j).ToString = "") Then
                        sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Rows.Item(i).Item(j).ToString, ReportText1Font, CInt(sngColumnWidth), newStringFormat)
                        rowHeight = CInt(sizStringSize.Height)

                        r = New Rectangle(w, l, CInt(sngColumnWidth - 3), rowHeight)
                        w += CInt(CType(mobjARPortrateReport.Sections("GrpHdrDatafile").Controls("Txt1"), DataDynamics.ActiveReports.Label).Left) * 72

                        rf = New Drawing.RectangleF(w, l + 2, r.Width, r.Height)

                        ev.Graphics.DrawString(objDtReportDataTableIn.Rows.Item(i).Item(j).ToString, ReportText1Font, Drawing.Brushes.Black, rf, ColoumnFormat)
                    End If
                    blnIsLeft = True
                Else
                    sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 2).Width
                    sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Columns(j).Caption, ReportHeader2Font, CInt(sngColumnWidth), newStringFormat)
                    rowHeight = CInt(sizStringSize.Height)

                    w += CInt(CType(mobjARPortrateReport.Sections("GrpHdrDatafile").Controls("TxtLable2"), DataDynamics.ActiveReports.Label).Left * 72) - 100
                    r = New Rectangle(w, l, CInt(sngColumnWidth - 3), rowHeight)

                    rf = New Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height)
                    blnIsLeft = False
                    ev.Graphics.DrawString(objDtReportDataTableIn.Columns(j).Caption, ReportHeader2Font, hfBrush, rf)
                    If Not (objDtReportDataTableIn.Rows.Item(i).Item(j).ToString = "") Then
                        sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 3).Width
                        sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Rows.Item(i).Item(j).ToString, ReportText2Font, CInt(sngColumnWidth), newStringFormat)
                        rowHeight = CInt(sizStringSize.Height)
                        r = New Rectangle(w, l, CInt(sngColumnWidth - 3), rowHeight)
                        rf = New Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height)

                        w += CInt(CType(mobjARPortrateReport.Sections("GrpHdrDatafile").Controls("Txt2"), DataDynamics.ActiveReports.Label).Left) * 72 - 300
                        rf = New Drawing.RectangleF(w, l + 2, r.Width, r.Height)

                        ev.Graphics.DrawString(objDtReportDataTableIn.Rows.Item(i).Item(j).ToString, ReportText2Font, Drawing.Brushes.Black, rf, ColoumnFormat)
                    End If
                    '
                    w = CInt(leftMargin)
                    l += r.Height
                End If
continuefor2:
                j += 1
            Loop
            'hfBrush.Color = clrMangeta.Black
            If intLineHeigt > l Then
                l = intLineHeigt
            End If
            If blnIsLeft = True Then
                l += r.Height
            End If
            '   l += rowHeight
            'Next

            'CurRow = i
            PrevRowCount = i

            Dim sngXPos As Single = leftMargin
            Dim intTotalGridHeight As Integer

            'intTotalGridHeight = CInt(rectGrid.Width)
            intTotalGridHeight = l - CInt(topMargin) + 10

            ev.Graphics.DrawLine(New Pen(Color.Black), leftMargin, topMargin + intTotalGridHeight, sngXPos, topMargin + intTotalGridHeight)

            For j = CurCol To objDtReportDataTableIn.Columns.Count - 1
                ' Dim sngColumnWidth As Single

                If NextFirstCol > 0 And j >= NextFirstCol Then
                    Exit For
                End If
                sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, j).Width
                sngXPos += sngColumnWidth
                'ev.Graphics.DrawLine(New Pen(Color.Black), sngXPos, topMargin, sngXPos, topMargin + intTotalGridHeight)
            Next j

            'ev.Graphics.DrawLine(New Pen(Color.Black), leftMargin, topMargin + intTotalGridHeight, sngXPos, topMargin + intTotalGridHeight)
            'ev.Graphics.DrawLine(New Pen(Color.Black), sngXPos, topMargin, sngXPos, topMargin + intTotalGridHeight)

            sngXPos = CInt(rectGrid.Right)
            ev.Graphics.DrawLine(New Pen(Color.Black), leftMargin, topMargin + intTotalGridHeight, sngXPos, topMargin + intTotalGridHeight)

            '//----- Added & Modified by Sachin Dokhale on 28.09.05
            YPosition = CSng(intTotalGridHeight)
            '//-----
            If npp >= NoOfPagesPreviewed Then
                'ev.HasMorePages = True
                'IsNextPage = True
                npp -= NoOfPagesPreviewed
            End If
            'If we have more lines then print another page
            If (CurRow < mobjDvReportDataView.Count) Then
                'ev.HasMorePages = True
                IsNextPage = True
            Else

                If NextFirstCol = 0 Then
                    'ev.HasMorePages = False
                    IsNextPage = False
                Else
                    CurRow = 0
                    CurCol = NextFirstCol
                    'ev.HasMorePages = True
                    'IsNextPage = True
                End If
            End If
            intIsPageReapate = False
            divPen.Dispose()
            hfpen.Dispose()
            hbBrush.Dispose()
            hfBrush.Dispose()

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

    Private Sub DataFileTextListPrintPage(ByRef ev As System.Drawing.Printing.PrintPageEventArgs, _
                                     ByVal rectGrid As Drawing.RectangleF, _
                                     ByVal objDtReportDataTableIn As DataTable, _
                                     ByVal objDtReportDetailsDataTableIn As DataTable, _
                                     ByVal intReportTypeIn As enumReportType, ByRef IsNextPage As Boolean, _
                                     ByRef YPosition As Single)

        NextFirstCol = 0
        npp += 1

        mobjDvReportDataView = objDtReportDataTableIn.DefaultView

        Dim lpp As Single = 0
        Dim yPos As Single = 0
        Dim count As Integer = 0
        Dim leftMargin As Single = rectGrid.Left
        Dim topMargin As Single = rectGrid.Top
        Dim line As String
        Dim rowHeight As Integer
        Dim headerHeight As Integer
        Dim i, j, w, l As Integer
        Dim divPen As New Pen(Color.Black)  'mobjReportDataGrid.GridLineColor)
        Dim hfpen As New Pen(Color.Black)   'mobjReportDataGrid.HeaderForeColor)
        Dim hbBrush As New SolidBrush(Color.White)  'mobjReportDataGrid.HeaderBackColor)
        Dim hfBrush As New SolidBrush(Color.Black)  'mobjReportDataGrid.HeaderForeColor)
        Dim CellSize As SizeF
        Dim sngColumnWidth As Single

        Static PrevRowCount As Integer
        Static blnPrevRow As Boolean
        Static intIsPageReapate As Boolean

        Try

            '//----- Added & Modified by Sachin Dokhale on 28.09.05
            lpp = rectGrid.Height / printFont.GetHeight(ev.Graphics)
            'rowHeight = 14 'PreferredRowHeight
            rowHeight = CInt(printFont.GetHeight(ev.Graphics)) + 1
            headerHeight = 18
            If rectGrid.Y >= mintPageFooterYPosotion Then
                If intIsPageReapate = True Then
                    If blnPageSettingMessage = False Then
                        'Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
                        'Application.DoEvents()
                        'cWait = New CWaitCursor
                        blnPageSettingMessage = True
                    End If

                    IsNextPage = False
                    Exit Try
                End If
                IsNextPage = True
                intIsPageReapate = True
                Exit Try
            End If
            rectGrid.Height = (mintPageFooterYPosotion - 15) - rectGrid.Y
            If rectGrid.Height <= rowHeight Then
                If intIsPageReapate = True Then
                    If blnPageSettingMessage = False Then
                        'Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
                        'cWait = New CWaitCursor
                        blnPageSettingMessage = True
                    End If
                    IsNextPage = False
                    Exit Try
                End If
                IsNextPage = True
                intIsPageReapate = True
                Exit Try
            End If
            'NoOfRowsPerPage = ((CInt(rectGrid.Height) \ rowHeight) - (headerHeight \ rowHeight) - 1)   '(CInt(rectGrid.Y) \ rowHeight) '- (headerHeight \ rowHeight) '- PrevRowCount
            '//-----

            l = CInt(topMargin)
            w = CInt(leftMargin)
            Dim sngCellHeight As Single = 0.0
            Dim MaxCellHeight As Single = 0.0

            'l += r.Height 'CellSize.ToSize.Height   'headerHeight

            l += headerHeight
            Dim blnIsLeft As Boolean = False
            Dim ReportHeader1Font As Font
            Dim ReportHeaderFont As Font
            Dim ReportText1Font As Font
            Dim ReportHeader2Font As Font
            Dim ReportText2Font As Font
            Dim rectReportHeader As Drawing.RectangleF
            Dim r As Rectangle
            Dim rf As Drawing.RectangleF
            Dim sizStringSize As SizeF
            Dim newStringFormat As New StringFormat
            Dim intLineHeigt As Integer
            intIsPageReapate = False
            'NoOfRowsPerPage = ((CInt(rectGrid.Height) \ rowHeight) - (headerHeight \ rowHeight) - 1)   '(CInt(rectGrid.Y) \ rowHeight) '- (headerHeight \ rowHeight) '- PrevRowCount
            NoOfRowsPerPage = ((CInt(rectGrid.Height) \ rowHeight) - (headerHeight \ rowHeight) - 1)   '(CInt(rectGrid.Y) \ rowHeight) '- (headerHeight \ rowHeight) '- PrevRowCount

            ReportHeaderFont = CType(mobjARPortrateReport.Sections("GrpHdrRepeatResults").Controls("TxtStdSamp"), DataDynamics.ActiveReports.Label).Font
            ReportHeader1Font = CType(mobjARPortrateReport.Sections("GrpHdrRepeatResults").Controls("StdSampName"), DataDynamics.ActiveReports.Label).Font
            ReportText1Font = CType(mobjARPortrateReport.Sections("GrpHdrRepeatResults").Controls("TxtStdSampName"), DataDynamics.ActiveReports.Label).Font
            ReportHeader2Font = CType(mobjARPortrateReport.Sections("GrpHdrRepeatResults").Controls("Abso"), DataDynamics.ActiveReports.Label).Font
            ReportText2Font = CType(mobjARPortrateReport.Sections("GrpHdrRepeatResults").Controls("TxtAbso"), DataDynamics.ActiveReports.Label).Font
            rectReportHeader = CType(mobjARPortrateReport.Sections("GrpHdrRepeatResults").Controls("lblDtlInfo"), DataDynamics.ActiveReports.Label).GetBounds

            w = CInt(leftMargin)

            

            rowHeight = CInt(ReportText1Font.GetHeight(ev.Graphics)) + 1
            'If Not objDtReportDataTableIn.Columns(j).Caption = "" Then
            '    sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 4).Width
            '    r = New Rectangle(w, l, CInt(sngColumnWidth + 50), rowHeight)
            '    rf = New Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height)
            '    ev.Graphics.DrawString(objDtReportDataTableIn.Columns(j).Caption, ReportHeaderFont, hfBrush, rf)
            '    If Not objDtReportDataTableIn.Rows.Item(0).Item(0).ToString = "" Then
            '        r = New Rectangle(w + 200, l, CInt(sngColumnWidth - 3), rowHeight)
            '        rf = New Drawing.RectangleF(w + 205, l + 2, r.Width, r.Height)
            '        ev.Graphics.DrawString(objDtReportDataTableIn.Rows.Item(0).Item(0).ToString, ReportHeaderFont, hfBrush, rf)
            '    End If
            '    l += r.Height + 10
            'End If
            j = 0
            Dim MasterIdx As Integer = 0
            Dim lLimit As Integer
            Static intAddConcLimit As Integer = 0
            'MasterIdx = mMasterIdx
            'objDtReportDataTableIn As DataTable, _
            'objDtReportDetailsDataTableIn As DataTable, _

            lLimit = l
            For MasterIdx = mMasterIdx To objDtReportDataTableIn.Rows.Count - 1
                '--- If any probelm in printng during lines of printting change follow eq. in if conditions 
                'If (rectGrid.Height <= (l + ((rowHeight - 5) * 12))) Then

                If (rectGrid.Height <= ((l - lLimit) + ((rowHeight) * 14) + intAddConcLimit)) Then
                    If intIsPageReapate = True Then
                        If blnPageSettingMessage = False Then
                            'Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
                            'cWait = New CWaitCursor
                            blnPageSettingMessage = True
                        End If
                        IsNextPage = False
                        Exit Try
                    End If
                    mMasterIdx = MasterIdx
                    IsNextPage = True
                    intIsPageReapate = True
                    Exit Try
                End If
                If IsNothing(ColoumnFormat) Then
                    ColoumnFormat = New StringFormat
                End If
                If SetTableColoumnFormat = True Then
                    ColoumnFormat.Alignment = StringAlignment.Near
                End If

                newStringFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft
                newStringFormat.Alignment = StringAlignment.Near
                '//----- Std Samp #No
                'sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 0).Width
                'sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Columns(j).Caption, ReportHeader1Font, CInt(sngColumnWidth), newStringFormat)
                'rowHeight = CInt(sizStringSize.Height)

                'r = New Rectangle(w, l, CInt(sngColumnWidth - 3), rowHeight)
                'rf = New Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height)
                'ev.Graphics.DrawString(objDtReportDataTableIn.Columns(MasterIdx).Caption, ReportHeader1Font, hfBrush, rf)
                'intLineHeigt = l + r.Height
                'l += r.Height
                '//----- Std Name
                sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 1).Width
                If Not (objDtReportDataTableIn.Rows.Item(MasterIdx).Item(2).ToString = "") Then
                    sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Rows.Item(MasterIdx).Item(2).ToString, ReportText1Font, CInt(sngColumnWidth), newStringFormat)
                    rowHeight = CInt(sizStringSize.Height)
                    w = CInt(leftMargin)
                    r = New Rectangle(w, l, CInt(sngColumnWidth - 3), rowHeight)
                    w += CInt(CType(mobjARPortrateReport.Sections("GrpHdrRepeatResults").Controls("TxtStdSamp"), DataDynamics.ActiveReports.Label).Left) * 72

                    rf = New Drawing.RectangleF(w, l + 2, r.Width, r.Height)
                    ev.Graphics.DrawString(objDtReportDataTableIn.Rows.Item(MasterIdx).Item(2).ToString, ReportText1Font, Drawing.Brushes.Black, rf, ColoumnFormat)
                End If
                l += r.Height
                '//----- Name
                sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 2).Width


                Dim blnIsStd As Boolean
                blnIsStd = objDtReportDataTableIn.Rows.Item(MasterIdx).Item(6)

                ' code added by :dinesh wagh on 27.3.2009
                ' code start
                If blnIsStd = True Then
                    sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Columns(3).Caption, ReportHeader1Font, CInt(sngColumnWidth), newStringFormat)
                Else
                    sizStringSize = ev.Graphics.MeasureString("Name :", ReportHeader1Font, CInt(sngColumnWidth), newStringFormat)
                End If
                ' code ends

                'sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Columns(3).Caption, ReportHeader1Font, CInt(sngColumnWidth), newStringFormat) ' code commented by : dinesh wagh on 27.3.2009


                rowHeight = CInt(sizStringSize.Height)
                w = CInt(leftMargin)
                w += CInt(CType(mobjARPortrateReport.Sections("GrpHdrRepeatResults").Controls("StdSampName"), DataDynamics.ActiveReports.Label).Left) * 72
                r = New Rectangle(w, l, CInt(sngColumnWidth - 3), rowHeight)

                rf = New Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height) ' code added by: dinesh wagh on 27.3.2009
                'rf = New Drawing.RectangleF(w, l + 2, r.Width, r.Height) ' code commented by : dinesh wagh on 27.3.2009


                'ev.Graphics.DrawString(objDtReportDataTableIn.Columns(3).Caption, ReportHeader1Font, hfBrush, rf) ' code commented by : dinesh wagh on 27.3.2009

                ' code added by : dinesh wagh on 27.3.2009
                ' code start
                If blnIsStd = True Then
                    ev.Graphics.DrawString(objDtReportDataTableIn.Columns(3).Caption, ReportHeader1Font, hfBrush, rf)
                Else
                    ev.Graphics.DrawString("Name :", ReportHeader1Font, hfBrush, rf)
                End If
                'code ends

                intLineHeigt = l + r.Height

                If Not (objDtReportDataTableIn.Rows.Item(MasterIdx).Item(3).ToString = "") Then
                    sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Rows.Item(MasterIdx).Item(3).ToString, ReportText1Font, CInt(sngColumnWidth), newStringFormat)
                    rowHeight = CInt(sizStringSize.Height)

                    r = New Rectangle(w, l, CInt(sngColumnWidth - 3), rowHeight)
                    w += CInt(CType(mobjARPortrateReport.Sections("GrpHdrRepeatResults").Controls("TxtStdSampName"), DataDynamics.ActiveReports.Label).Left) * 72

                    rf = New Drawing.RectangleF(w, l + 2, r.Width, r.Height)
                    ev.Graphics.DrawString(objDtReportDataTableIn.Rows.Item(MasterIdx).Item(3).ToString, ReportText1Font, Drawing.Brushes.Black, rf, ColoumnFormat)
                End If
                l += r.Height
                '//----- Abs
                w = CInt(leftMargin)
                sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 4).Width
                sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Columns(4).Caption, ReportHeader1Font, CInt(sngColumnWidth), newStringFormat)
                rowHeight = CInt(sizStringSize.Height)

                r = New Rectangle(w, l, CInt(sngColumnWidth - 3), rowHeight)

                rf = New Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height) ' code added by : dinesh wagh on 27.3.2009
                'rf = New Drawing.RectangleF(w, l + 2, r.Width, r.Height) ' code commented by : dinesh wagh on 27.3.2009

                ev.Graphics.DrawString(objDtReportDataTableIn.Columns(4).Caption, ReportHeader1Font, hfBrush, rf)
                intLineHeigt = l + r.Height

                If Not (objDtReportDataTableIn.Rows.Item(MasterIdx).Item(4).ToString = "") Then
                    sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Rows.Item(MasterIdx).Item(4).ToString, ReportText1Font, CInt(sngColumnWidth), newStringFormat)
                    rowHeight = CInt(sizStringSize.Height)
                    w += CInt(CType(mobjARPortrateReport.Sections("GrpHdrRepeatResults").Controls("TxtAbso"), DataDynamics.ActiveReports.Label).Left) * 72
                    r = New Rectangle(w, l, CInt(sngColumnWidth - 3), rowHeight)
                    rf = New Drawing.RectangleF(w, l + 2, r.Width, r.Height)
                    ev.Graphics.DrawString(objDtReportDataTableIn.Rows.Item(MasterIdx).Item(4).ToString, ReportText1Font, Drawing.Brushes.Black, rf, ColoumnFormat)
                End If
                l += r.Height
                '//----- Conc
                If CType(objDtReportDataTableIn.Rows.Item(MasterIdx).Item(6), Boolean) = False Then
                    w = CInt(leftMargin)
                    sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 4).Width
                    sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Columns(5).Caption, ReportHeader1Font, CInt(sngColumnWidth), newStringFormat)
                    rowHeight = CInt(sizStringSize.Height)

                    r = New Rectangle(w, l, CInt(sngColumnWidth - 3), rowHeight)
                    rf = New Drawing.RectangleF(w, l + 2, r.Width, r.Height)
                    ev.Graphics.DrawString(objDtReportDataTableIn.Columns(5).Caption, ReportHeader1Font, hfBrush, rf)
                    intLineHeigt = l + r.Height

                    If Not (objDtReportDataTableIn.Rows.Item(MasterIdx).Item(5).ToString = "") Then
                        sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Rows.Item(MasterIdx).Item(4).ToString, ReportText1Font, CInt(sngColumnWidth), newStringFormat)
                        rowHeight = CInt(sizStringSize.Height)
                        r = New Rectangle(w, l, CInt(sngColumnWidth - 3), rowHeight)
                        w += CInt(CType(mobjARPortrateReport.Sections("GrpHdrRepeatResults").Controls("TxtConc"), DataDynamics.ActiveReports.Label).Left) * 72

                        rf = New Drawing.RectangleF(w, l + 2, r.Width, r.Height)
                        ev.Graphics.DrawString(objDtReportDataTableIn.Rows.Item(MasterIdx).Item(5).ToString, ReportText1Font, Drawing.Brushes.Black, rf, ColoumnFormat)
                    End If
                    l += r.Height
                End If
                '//------ Details
                Dim IsLeftMargin As Boolean
                Dim intDtlIdx As Integer
                Dim intRowStart As Integer
                For intDtlIdx = 0 To objDtReportDetailsDataTableIn.Rows.Count - 1
                    If CType(objDtReportDataTableIn.Rows.Item(MasterIdx).Item(1), Integer) = _
                        CType(objDtReportDetailsDataTableIn.Rows.Item(intDtlIdx).Item(1), Integer) Then
                        If CType(objDtReportDataTableIn.Rows.Item(MasterIdx).Item(6), Boolean) = False Then
                            IsLeftMargin = True

                        End If
                        If CType(objDtReportDetailsDataTableIn.Rows.Item(intDtlIdx).Item(0), String) = "Statistics on Conc" Then
                            IsLeftMargin = True
                            l = intRowStart
                            w = CInt(leftMargin) + 400
                        Else
                            IsLeftMargin = False
                            w = CInt(leftMargin) + 100
                            l += r.Height
                            intRowStart = l
                        End If
                        sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 4).Width
                        'r = New Rectangle(w, l, CInt(sngColumnWidth + 50), rowHeight)
                        'rf = New Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height)
                        'ev.Graphics.DrawString(objDtReportDataTableIn.Columns(j).Caption, ReportHeaderFont, hfBrush, rf)
                        sizStringSize = ev.Graphics.MeasureString(objDtReportDetailsDataTableIn.Columns(j).Caption, ReportHeader1Font, CInt(sngColumnWidth), newStringFormat)
                        rowHeight = CInt(sizStringSize.Height)
                        If Not objDtReportDetailsDataTableIn.Rows.Item(intDtlIdx).Item(0).ToString = "" Then
                            'l += r.Height
                            r = New Rectangle(w + 200, l, CInt(sngColumnWidth - 3), rowHeight)
                            rf = New Drawing.RectangleF(w - 70, l + 2, r.Width, r.Height)
                            ev.Graphics.DrawString(objDtReportDetailsDataTableIn.Rows.Item(intDtlIdx).Item(0).ToString, ReportHeaderFont, hfBrush, rf)
                        End If
                        l += r.Height + 10
                        For j = 2 To objDtReportDetailsDataTableIn.Columns.Count - 2
                            If IsLeftMargin = False Then
                                'w = CInt(leftMargin) + 100
                                w = CInt(leftMargin)
                                w += CInt(CType(mobjARPortrateReport.Sections("GrpHdrRepeatResults").Controls("TxtStdSampName"), DataDynamics.ActiveReports.Label).Left) * 72
                            Else
                                w = CInt(leftMargin) + 400
                            End If

                            sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 7).Width
                            sizStringSize = ev.Graphics.MeasureString(objDtReportDetailsDataTableIn.Columns(j).Caption, ReportHeader1Font, CInt(sngColumnWidth), newStringFormat)
                            rowHeight = CInt(sizStringSize.Height)

                            r = New Rectangle(w, l, CInt(sngColumnWidth - 3), rowHeight)
                            rf = New Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height) ' code added by : dinesh wagh on 27.3.2009
                            'rf = New Drawing.RectangleF(w, l + 2, r.Width, r.Height)'code commented by : dinesh wagh on 27.3.2009
                            ev.Graphics.DrawString(objDtReportDetailsDataTableIn.Columns(j).Caption, ReportHeader1Font, hfBrush, rf)
                            intLineHeigt = l + r.Height

                            If Not (objDtReportDetailsDataTableIn.Rows.Item(intDtlIdx).Item(j).ToString = "") Then
                                sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 8).Width
                                sizStringSize = ev.Graphics.MeasureString(objDtReportDetailsDataTableIn.Rows.Item(intDtlIdx).Item(j).ToString, ReportText1Font, CInt(sngColumnWidth), newStringFormat)
                                rowHeight = CInt(sizStringSize.Height)
                                w += CInt(CType(mobjARPortrateReport.Sections("GrpHdrRepeatResults").Controls("TxtDtlInfo"), DataDynamics.ActiveReports.Label).Left) * 50   '72
                                r = New Rectangle(w, l, CInt(sngColumnWidth - 3), rowHeight)
                                rf = New Drawing.RectangleF(w, l + 2, r.Width, r.Height)
                                ev.Graphics.DrawString(objDtReportDetailsDataTableIn.Rows.Item(intDtlIdx).Item(j).ToString, ReportText1Font, Drawing.Brushes.Black, rf, ColoumnFormat)
                            End If
                            l += r.Height
                        Next
                    End If
                Next
                mMasterIdx = MasterIdx

                '----------------------------------- commented by : dinesh wagh on 10.2.2010
                ''If (Not objDtReportDataTableIn.Rows.Item(MasterIdx) Is Nothing) And (intAddConcLimit = 0) Then
                ''    If (CType(objDtReportDataTableIn.Rows.Item(MasterIdx + 1).Item(6), Boolean) = False) Then
                ''        intAddConcLimit = 55
                ''    End If
                ''End If
                '-------------------------------------------------

                'code added by ; dinesh wagh on 10.2.2010
                '----------------------------------------------------------------
                If (Not objDtReportDataTableIn.Rows.Item(MasterIdx) Is Nothing) And (intAddConcLimit = 0) Then
                    If (CType(objDtReportDataTableIn.Rows.Item(MasterIdx).Item(6), Boolean) = False) Then
                        intAddConcLimit = 55
                    End If
                End If
                '----------------------------------------------------------

            Next
            '//-----

            '            Do While j <= objDtReportDataTableIn.Columns.Count - 1

            '                If IsNumeric(mobjDvReportDataView.Item(i).Item(j).ToString()) Then

            '                    If IsNothing(ColoumnFormat) Then
            '                        ColoumnFormat = New StringFormat
            '                    End If
            '                    If SetTableColoumnFormat = True Then
            '                        ColoumnFormat.Alignment = StringAlignment.Near
            '                    End If
            '                Else
            '                    If IsNothing(ColoumnFormat) Then
            '                        ColoumnFormat = New StringFormat
            '                    End If
            '                    If SetTableColoumnFormat = True Then
            '                        ColoumnFormat.Alignment = StringAlignment.Near
            '                    End If
            '                End If

            '                CurRow = 1
            '                newStringFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft
            '                newStringFormat.Alignment = StringAlignment.Near

            '                If blnIsLeft = False Then


            '                    sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 0).Width
            '                    sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Columns(j).Caption, ReportHeader1Font, CInt(sngColumnWidth), newStringFormat)
            '                    rowHeight = CInt(sizStringSize.Height)

            '                    r = New Rectangle(w, l, CInt(sngColumnWidth - 3), rowHeight)
            '                    rf = New Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height)
            '                    ev.Graphics.DrawString(objDtReportDataTableIn.Columns(j).Caption, ReportHeader1Font, hfBrush, rf)
            '                    intLineHeigt = l + r.Height

            '                    sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 1).Width
            '                    If Not (objDtReportDataTableIn.Rows.Item(i).Item(j).ToString = "") Then
            '                        sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Rows.Item(i).Item(j).ToString, ReportText1Font, CInt(sngColumnWidth), newStringFormat)
            '                        rowHeight = CInt(sizStringSize.Height)

            '                        r = New Rectangle(w, l, CInt(sngColumnWidth - 3), rowHeight)
            '                        w += CInt(CType(mobjARPortrateReport.Sections("GrpHdrDatafile").Controls("Txt1"), DataDynamics.ActiveReports.Label).Left) * 72

            '                        rf = New Drawing.RectangleF(w, l + 2, r.Width, r.Height)
            '                        ev.Graphics.DrawString(objDtReportDataTableIn.Rows.Item(i).Item(j).ToString, ReportText1Font, Drawing.Brushes.Black, rf, ColoumnFormat)
            '                    End If
            '                    blnIsLeft = True
            '                Else
            '                    sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 2).Width
            '                    sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Columns(j).Caption, ReportHeader2Font, CInt(sngColumnWidth), newStringFormat)
            '                    rowHeight = CInt(sizStringSize.Height)

            '                    w += CInt(CType(mobjARPortrateReport.Sections("GrpHdrDatafile").Controls("TxtLable2"), DataDynamics.ActiveReports.Label).Left * 72) - 100
            '                    r = New Rectangle(w, l, CInt(sngColumnWidth - 3), rowHeight)
            '                    rf = New Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height)
            '                    blnIsLeft = False
            '                    ev.Graphics.DrawString(objDtReportDataTableIn.Columns(j).Caption, ReportHeader2Font, hfBrush, rf)
            '                    If Not (objDtReportDataTableIn.Rows.Item(i).Item(j).ToString = "") Then
            '                        sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 3).Width
            '                        sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Rows.Item(i).Item(j).ToString, ReportText2Font, CInt(sngColumnWidth), newStringFormat)
            '                        rowHeight = CInt(sizStringSize.Height)
            '                        r = New Rectangle(w, l, CInt(sngColumnWidth - 3), rowHeight)
            '                        rf = New Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height)

            '                        w += CInt(CType(mobjARPortrateReport.Sections("GrpHdrDatafile").Controls("Txt2"), DataDynamics.ActiveReports.Label).Left) * 72 - 300
            '                        rf = New Drawing.RectangleF(w, l + 2, r.Width, r.Height)
            '                        ev.Graphics.DrawString(objDtReportDataTableIn.Rows.Item(i).Item(j).ToString, ReportText2Font, Drawing.Brushes.Black, rf, ColoumnFormat)
            '                    End If
            '                    '
            '                    w = CInt(leftMargin)
            '                    l += r.Height
            '                End If
            'continuefor2:
            '                j += 1
            '            Loop

            If intLineHeigt > l Then
                l = intLineHeigt
            End If
            If blnIsLeft = True Then
                l += r.Height
            End If
            '   l += rowHeight
            'Next

            'CurRow = i
            PrevRowCount = i

            Dim sngXPos As Single = leftMargin
            Dim intTotalGridHeight As Integer

            'intTotalGridHeight = CInt(rectGrid.Width)
            intTotalGridHeight = l - CInt(topMargin) + 10

            ev.Graphics.DrawLine(New Pen(Color.Black), leftMargin, topMargin + intTotalGridHeight, sngXPos, topMargin + intTotalGridHeight)

            For j = CurCol To objDtReportDataTableIn.Columns.Count - 1
                ' Dim sngColumnWidth As Single

                If NextFirstCol > 0 And j >= NextFirstCol Then
                    Exit For
                End If
                sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, j).Width
                sngXPos += sngColumnWidth
                'ev.Graphics.DrawLine(New Pen(Color.Black), sngXPos, topMargin, sngXPos, topMargin + intTotalGridHeight)
            Next j

            'ev.Graphics.DrawLine(New Pen(Color.Black), leftMargin, topMargin + intTotalGridHeight, sngXPos, topMargin + intTotalGridHeight)
            'ev.Graphics.DrawLine(New Pen(Color.Black), sngXPos, topMargin, sngXPos, topMargin + intTotalGridHeight)

            sngXPos = CInt(rectGrid.Right)
            ' ev.Graphics.DrawLine(New Pen(Color.Black), leftMargin, topMargin + intTotalGridHeight, sngXPos, topMargin + intTotalGridHeight)

            '//----- Added & Modified by Sachin Dokhale on 28.09.05
            YPosition = CSng(intTotalGridHeight)
            '//-----
            If npp >= NoOfPagesPreviewed Then
                'ev.HasMorePages = True
                'IsNextPage = True
                npp -= NoOfPagesPreviewed
            End If
            'If we have more lines then print another page
            If (CurRow < mobjDvReportDataView.Count) Then
                'ev.HasMorePages = True
                IsNextPage = False
            Else

                If NextFirstCol = 0 Then
                    'ev.HasMorePages = False
                    IsNextPage = False
                Else
                    CurRow = 0
                    CurCol = NextFirstCol
                    'ev.HasMorePages = True
                    'IsNextPage = True
                End If
            End If
            intIsPageReapate = False
            divPen.Dispose()
            hfpen.Dispose()
            hbBrush.Dispose()
            hfBrush.Dispose()

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

    Private Sub PaintHeaderCell(ByVal g As Graphics, ByVal Sentence As String, ByVal F As Font, ByVal br As Brush, ByRef Bounds As Rectangle, ByVal offsetx As Integer, ByVal offsety As Integer)

        Dim protNRowsInCaption As Integer
        Dim blnSpace As Boolean
        Try
            protNRowsInCaption = 3

            Dim strs(protNRowsInCaption - 1), tt() As String
            tt = Sentence.Split(" "c)
            Dim i, j, n As Integer
            j = 0
            Dim s As String = ""
            Dim os As String
            os = s
            For i = 0 To protNRowsInCaption - 1
                strs(i) = ""
            Next
            For i = 0 To tt.Length - 1
                If s <> "" Then
                    s &= " " & tt(i)
                Else
                    s = tt(i)
                    os = s
                End If
                Dim w As Integer = CInt(g.MeasureString(s, F).Width)
                If w >= Bounds.Width Then
                    strs(j) = os
                    If s <> tt(i) Then
                        s = tt(i)
                        os = tt(i)
                    Else
                        s = ""
                        os = ""
                    End If
                    If j = protNRowsInCaption - 1 And i <= tt.Length - 1 Then
                        strs(j) = "..."
                        Exit For
                    End If
                    j += 1
                Else
                    os = s
                End If
                If i = tt.Length - 1 And j <> protNRowsInCaption Then
                    strs(j) = s
                End If
            Next
            n = protNRowsInCaption - 1
            Dim h As Integer = (Bounds.Height Mod F.Height) \ 2
            Dim intWordCount As Integer = 0
            h = F.Height
            For i = 0 To n
                Dim w As Integer = CInt(g.MeasureString(strs(i), F).Width)
                If w < Bounds.Width Then
                    w = (Bounds.Width - w) \ 2
                    Bounds.Height = h
                Else
                    If Bounds.Width > 0 Then
                        While w >= Bounds.Width
                            strs(i) = strs(i).Substring(0, strs(i).Length - 1)
                            w = CInt(g.MeasureString(strs(i), F).Width)
                        End While
                    Else
                        Return
                    End If
                    w = 0
                End If
                g.DrawString(strs(i), F, br, Bounds.X + w + offsetx, Bounds.Y + h + offsety)

                If Not (strs(i) = "") Then
                    intWordCount += 1
                    'Bounds.Height = ((intWordCount) * F.Height) + 5
                End If
                h += F.Height
            Next
            'If intWordCount > 1 Then
            '    Bounds.Height = Bounds.Height - F.Height
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Function funcGetDataTableHeight(ByVal G As Drawing.Graphics, ByVal objDtTableIn As DataTable, ByVal objPrintFont As Font, ByRef sngHeightOfHeader As Single) As Single
        Dim intCount As Integer
        Dim sngHeightOfDataTable As Single

        Dim sngHeightOfOneRow As Single
        Dim intColumnCount As Integer
        Dim intOneRowLength As Integer
        Dim strOneRowString As String

        Dim arrTemp As New ArrayList
        Dim sngMAXHeightOfOneRow As Single
        Dim intCounter As Integer
        Dim j As Integer
        Dim headerHeight As Integer
        Dim CellSize As SizeF

        Try
            sngHeightOfHeader = G.MeasureString(objDtTableIn.Columns(1).Caption, objPrintFont).Height
            ''''''''''''''''''''''''''' height of Header 
            For j = CurCol To objDtTableIn.Columns.Count - 1
                'CellSize = funcGetColumnWidth(enumReportType.EditPigment, enumReportLayoutType.Portrate, j)
                CellSize = funcGetColumnWidth(ReportType, enumReportLayoutType.Portrate, j)

                Dim sngColumnWidth As Single = CellSize.Width

                'If w + sngColumnWidth >= rectGrid.Right And j <> CurCol Then
                '    NextFirstCol = j
                '    Exit For
                'End If
                If sngColumnWidth = 0 Then GoTo continuefor

                'Dim r As New Rectangle(w, l, CInt(sngColumnWidth + 1), headerHeight)
                ' Dim r As New Rectangle(New Point(w, l), CellSize.ToSize)

                'Dim rf As New Drawing.RectangleF(w, l, r.Width, r.Height)




                'ev.Graphics.DrawLine(divPen, r.X, r.Y, r.Right, r.Y)
                'ev.Graphics.DrawLine(divPen, r.X, r.Bottom, r.Right, r.Y + r.Height)
                'w += CInt(sngColumnWidth)
                headerHeight = CInt(CellSize.Height)
continuefor:
            Next j
            'l += r.Height 'CellSize.ToSize.Height   'headerHeight
            sngHeightOfHeader = headerHeight
            ''''''''''''''''''''''''''''''''''''''''''''''''

            For intCount = 0 To objDtTableIn.Rows.Count - (mintNextPageCurrentRow + 1) 'objDtTableIn.Rows.Count - 1
                ''''NoOfRowsPerPage + CurRow - 1 '
                arrTemp.Add(0)
                For intColumnCount = 0 To objDtTableIn.Columns.Count - 1
                    If IsDBNull(objDtTableIn.Rows.Item(intCount).Item(intColumnCount)) = True Then
                        strOneRowString = ""
                    Else
                        strOneRowString = CStr(objDtTableIn.Rows.Item(intCount).Item(intColumnCount))
                        sngHeightOfOneRow = G.MeasureString(strOneRowString, objPrintFont).Height
                        arrTemp.Add(sngHeightOfOneRow)
                    End If
                Next intColumnCount

                'To Find the Max Height of One Row 
                sngMAXHeightOfOneRow = CSng(arrTemp.Item(0))
                For intCounter = 0 To arrTemp.Count - 1
                    If sngMAXHeightOfOneRow < CSng(arrTemp.Item(intCounter)) Then
                        sngMAXHeightOfOneRow = CSng(arrTemp.Item(intCounter))
                    End If
                Next
                arrTemp.Clear()

                sngHeightOfDataTable = sngHeightOfDataTable + sngMAXHeightOfOneRow
            Next intCount

            sngHeightOfDataTable += sngHeightOfHeader
            mintNextPageCurrentRow = CurRow
            Return sngHeightOfDataTable

        Catch ex As Exception
            MessageBox.Show(ex.Message)
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

    Private Function funcGetColumnWidth(ByVal intReportTypeIn As enumReportType, _
                                        ByVal intReportLayoutType As enumReportLayoutType, _
                                        ByVal intColumnNumberIn As Integer) As SizeF  'Single

        Dim strReportTypeName As String = ""
        Dim sngColumnWidth As Single = 0.0
        Dim sngCellHeight As Single = 0.0
        Dim ColumnCellSize As SizeF

        Try

            Select Case intReportTypeIn
                Case enumReportType.CookBook
                    strReportTypeName = "GrpHdrWorkCondition"
                Case enumReportType.DataFile
                    'mintReportTablesCount = 4 Then
                    If mintReportTextTableCount >= 0 Then
                        strReportTypeName = "GrpHdrDatafile"
                    Else
                        strReportTypeName = "GrpHdrDatafileTable"
                    End If
                Case enumReportType.StadardGraph
                    strReportTypeName = "GrpHdrStadGraph"
                Case enumReportType.SampleGraph
                    strReportTypeName = "GrpHdrSampleGraph"
                Case enumReportType.PrintPeak_Valley
                    If mintReportTextTableCount >= 0 Then
                        strReportTypeName = "GrpHdrSpectrum"
                    Else
                        strReportTypeName = "GrpHdrPeakValley"
                    End If
                    'strReportTypeName = "GrpHdrDatafile"
                Case enumReportType.EnergySpectrum, _
                     enumReportType.UVSpectrum, _
                      enumReportType.Histograph, _
                    enumReportType.Histograph, _
                    enumReportType.Histograph

                    'If mintReportTextTableCount >= 0 Then
                    strReportTypeName = "GrpHdrSpectrum"
                    'Else
                    'strReportTypeName = "GrpHdrPeakValley"
                    'End If
                Case enumReportType.RepeatResults
                    strReportTypeName = "GrpHdrRepeatResults"

                Case Else
                    strReportTypeName = ""
            End Select

            Dim intColumnLablesCount As Integer
            If Not strReportTypeName = "" Then

                Select Case intReportLayoutType
                    Case enumReportLayoutType.Portrate
                        intColumnLablesCount = mobjARPortrateReport.Sections(strReportTypeName).Controls.Count - 1

                        If intColumnNumberIn <= intColumnLablesCount Then
                            sngColumnWidth = CType(mobjARPortrateReport.Sections(strReportTypeName).Controls(intColumnNumberIn), DataDynamics.ActiveReports.Label).Width * 96
                            sngCellHeight = CType(mobjARPortrateReport.Sections(strReportTypeName).Controls(intColumnNumberIn), DataDynamics.ActiveReports.Label).Height * 96
                            If SetTableColoumnFormat = False Then
                                If Not (ColoumnFormat Is Nothing) Then
                                    'ColoumnFormat.Alignment = StringAlignment.Near
                                    ColoumnFormat.Alignment = IIf(CType(mobjARPortrateReport.Sections(strReportTypeName).Controls(intColumnNumberIn), DataDynamics.ActiveReports.Label).Alignment() = DataDynamics.ActiveReports.TextAlignment.Justify, StringAlignment.Near, CType(CType(mobjARPortrateReport.Sections(strReportTypeName).Controls(intColumnNumberIn), DataDynamics.ActiveReports.Label).Alignment(), StringAlignment))
                                End If
                            End If
                        Else
                            sngColumnWidth = CType(mobjARPortrateReport.Sections(strReportTypeName).Controls(intColumnLablesCount), DataDynamics.ActiveReports.Label).Width * 96
                            sngCellHeight = CType(mobjARPortrateReport.Sections(strReportTypeName).Controls(intColumnLablesCount), DataDynamics.ActiveReports.Label).Height * 96
                            If SetTableColoumnFormat = False Then
                                If Not (ColoumnFormat Is Nothing) Then
                                    'ColoumnFormat.Alignment = StringAlignment.Near
                                    ColoumnFormat.Alignment = IIf(CType(mobjARPortrateReport.Sections(strReportTypeName).Controls(intColumnLablesCount), DataDynamics.ActiveReports.Label).Alignment() = DataDynamics.ActiveReports.TextAlignment.Justify, StringAlignment.Near, CInt(CType(mobjARPortrateReport.Sections(strReportTypeName).Controls(intColumnLablesCount), DataDynamics.ActiveReports.Label).Alignment()))
                                End If
                            End If
                        End If
                        ColumnCellSize.Width = sngColumnWidth
                        ColumnCellSize.Height = sngCellHeight

                    Case enumReportLayoutType.Landscape
                        ''intColumnLablesCount = mobjARLandScapeReport.Sections(strReportTypeName).Controls.Count - 1
                        ''If intColumnNumberIn <= intColumnLablesCount Then
                        ''    sngColumnWidth = CType(mobjARLandScapeReport.Sections(strReportTypeName).Controls(intColumnNumberIn), DataDynamics.ActiveReports.Label).Width * 96
                        ''    sngCellHeight = CType(mobjARLandScapeReport.Sections(strReportTypeName).Controls(intColumnNumberIn), DataDynamics.ActiveReports.Label).Height * 96
                        ''Else
                        ''    sngColumnWidth = CType(mobjARLandScapeReport.Sections(strReportTypeName).Controls(intColumnLablesCount), DataDynamics.ActiveReports.Label).Width * 96
                        ''    'sngCellHeight = CType(mobjARLandScapeReport.Sections(strReportTypeName).Controls(intColumnNumberIn), DataDynamics.ActiveReports.Label).Height * 96
                        ''    sngCellHeight = CType(mobjARLandScapeReport.Sections(strReportTypeName).Controls(intColumnLablesCount), DataDynamics.ActiveReports.Label).Height * 96
                        ''End If
                        ''ColumnCellSize.Width = sngColumnWidth
                        ''ColumnCellSize.Height = sngCellHeight
                End Select
            Else
                sngColumnWidth = 0
                sngCellHeight = 0


            End If
            'ColoumnFormat = New StringFormat

            
            Return ColumnCellSize

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return SizeF.Empty
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

    Private Function ExportData() As Boolean
        '=====================================================================
        ' Procedure Name        : ExportData
        ' Parameters Passed     : 
        ' Returns               : 
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul At Machine SOFT1
        ' Created               : Friday, March 04, 2005
        ' Revisions             : 1
        '=====================================================================
        Dim objDtExpRptTable As DataTable
        Dim strReportHeader As String
        Dim strReportFooter As String
        Dim objDS As DataSet
        Dim objDSText As DataSet
        Dim blnResult As Boolean
        Dim strReportName As String
        Dim strGraphImageFilePath As String
        Dim strSpaceDiagramImageFilePath As String
        Dim objGraphImage As Bitmap
        Dim objSpaceDiagramImage As Bitmap
        Dim objReportImage As Bitmap
        Dim intTableCounter As Integer
        Dim arrReportImageList As ArrayList
        Dim intImageCounter As Integer
        Dim arrReportImageCaptionList As ArrayList
        Dim objReportParameter As AAS203Library.Method.clsReportParameters
        'Dim cWait As CWaitCursor

        Try
            blnResult = False

            strReportName = Me.ReportType.ToString
            objDS = New DataSet(strReportName)
            objDSText = New DataSet(strReportName)

            strReportHeader = mobjstructReportFormat.ReportTitleLine1 & vbCrLf & _
                         mobjstructReportFormat.ReportTitleLine2 & vbCrLf & _
                         mobjstructReportFormat.ReportTitleLine3
            strReportFooter = mobjstructReportFormat.ReportFooterLine1

            If IsNothing(Me.ReportDataTables) = False Then
                For intTableCounter = 0 To Me.ReportDataTables.Count - 1
                    objDtExpRptTable = CType(Me.ReportDataTables.Item(intTableCounter), DataTable).Copy
                    objDS.Tables.Add(objDtExpRptTable)
                Next intTableCounter
            End If

            objDtExpRptTable = New DataTable
            If IsNothing(Me.ReportTextList) = False Then
                For intTableCounter = 0 To Me.ReportTextList.Count - 1
                    objDtExpRptTable = CType(Me.ReportTextList.Item(intTableCounter), DataTable).Copy
                    objDSText.Tables.Add(objDtExpRptTable)
                Next intTableCounter
            End If

            arrReportImageList = New ArrayList
            arrReportImageCaptionList = New ArrayList

            Dim intCount As Integer
            If IsNothing(marrGraphControlsList) = False Then
                For intCount = 0 To marrGraphControlsList.Count - 1
                    If IsNothing(marrGraphControlsList.Item(intCount)) = False Then
                        ''If TypeOf marrGraphControlsList.Item(intCount) Is AldysGraph.AldysGraph Then
                        ''    Dim objGraph As AldysGraph.AldysGraph = CType(marrGraphControlsList.Item(intCount), AldysGraph.AldysGraph)
                        ''    objGraphImage = objGraph.GraphImage
                        ''    arrReportImageList.Add(objGraphImage)
                        ''    arrReportImageCaptionList.Add(objGraph.AldysPane.Title)
                        ''End If
                        ''If TypeOf marrGraphControlsList.Item(intCount) Is ColorSpaceDiagram.ColorSpaceDiagram Then
                        ''    Dim objGraph As ColorSpaceDiagram.ColorSpaceDiagram = CType(marrGraphControlsList.Item(intCount), ColorSpaceDiagram.ColorSpaceDiagram)
                        ''    objGraphImage = objGraph.GraphImage
                        ''    arrReportImageList.Add(objGraphImage)
                        ''    arrReportImageCaptionList.Add(objGraph.AldysPane.Title)
                        ''End If
                    End If
                Next intCount
            End If

            If IsNothing(mobjDtImageList) = False Then
                For intImageCounter = 0 To mobjDtImageList.Rows.Count - 1
                    objReportImage = CType(mobjDtImageList.Rows(intImageCounter).Item("Image"), Bitmap)
                    arrReportImageList.Add(objReportImage)
                    arrReportImageCaptionList.Add(CStr(mobjDtImageList.Rows(intImageCounter).Item("ImageCaption")))
                Next intImageCounter
            End If

            ''dlgResult = MessageBox.Show("Select Report Format: Yes For Html  Or No For Text Report", "Export Report", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            'blnResult = gobjMessageAdapter.ShowMessage(msgIDSelectReportFormat)
            'Application.DoEvents()
            'cWait = New CWaitCursor

            Select Case blnResult
                Case True
                    '---Html File
                    'clsDataSetExport.ExportHtml(strReportName, objDS, strReportHeader, mstrPageHeader, mstrPageText, arrReportImageList, arrReportImageCaptionList)

                Case False
                    '---Text File
                    If Me.ReportType = enumReportType.Others Then
                        clsDataSetExport.ExportRTF(strReportName, objDSText, objDS, strReportHeader, mstrPageHeader, mstrPageText)
                    ElseIf Me.ReportType = enumReportType.DataFile Then
                        clsDataSetExport.funcExportData(strReportName, objDSText, objDS, strReportHeader, Me.PageHeader.TextString, mstrPageText, Me.ReportFooter.TextString, DataFileReportParameter)
                    End If
                    'clsDataSetExport.funcExportData(strReportName, objDSText, objDS, strReportHeader, mstrPageHeader, mstrPageText, strReportFooter, DataFileReportParameter)
                    'clsDataSetExport.funcExportData(strReportName, objDSText, objDS, strReportHeader, Me.PageHeader.TextString, mstrPageText, Me.ReportFooter.TextString, DataFileReportParameter)
            End Select

            Return True

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
            'If Not cWait Is Nothing Then
            '    cWait.Dispose()
            'End If
        End Try

    End Function

    Private Function eMailData() As Boolean
        '=====================================================================
        ' Procedure Name        : eMailData
        ' Parameters Passed     : 
        ' Returns               : 
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul At Machine SOFT1
        ' Created               : Friday, March 04, 2005
        ' Revisions             : 1
        '=====================================================================
        Dim objDtExpRptTable As DataTable
        Dim strReportHeader As String
        Dim objDS As DataSet
        Dim intTableCounter As Integer

        Try
            strReportHeader = mobjstructReportFormat.ReportTitleLine1 & vbCrLf & _
                        mobjstructReportFormat.ReportTitleLine2 & vbCrLf & _
                        mobjstructReportFormat.ReportTitleLine3

            If IsNothing(Me.ReportDataTables) = False Then
                For intTableCounter = 0 To Me.ReportDataTables.Count - 1
                    objDtExpRptTable = CType(Me.ReportDataTables.Item(intTableCounter), DataTable).Copy
                    objDS.Tables.Add(objDtExpRptTable)
                Next intTableCounter
            End If

            ''clsDataSetExport.SendEMail(objDS)

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

    Private Function ArrangeImagesInGrid(ByVal objDtImageListIn As DataTable, ByRef G As Graphics, ByVal ColumnCount As Integer, ByVal LeftMargin As Single, ByVal YPosition As Single) As Boolean
        '=====================================================================
        ' Procedure Name        : ArrangeImagesInGrid
        ' Parameters Passed     : Images List with Captions as DataTable
        ' Returns               : true or false
        ' Purpose               : To show the layout with Images on the report
        ' Description           : if single row grid is set the 
        '                         columncount = number of Images otherwise divide total 
        '                         number of controls by the column count set the user
        '                         and arrange all the Images by using horizontal and 
        '                         vertical spacing and size of the Images
        '
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : Thursday, April 07, 2005
        ' Revisions             : 
        '=====================================================================
        '---if single row grid is set the columncount = number of Images
        '---otherwise divide total number of images by the column count set the user
        '---and arrange all the images by using horizontal and vertical spacing 
        '---and size of the images
        Dim colObjects As Integer
        Dim rowCounter, ColCounter As Integer
        Dim ObjIndex As Integer = 0
        Dim RowCount As Double
        Dim unEvenObjectsCount As Integer
        Dim unEvenObjectsCounter As Integer = 0
        Dim CheckForUnEvenObjects As Boolean

        Dim objBitmapImage As Bitmap
        Dim rectImage() As RectangleF
        Dim rectImageCaption As RectangleF

        Dim ControlVSpacing As Single = 10
        Dim ControlHSpacing As Single = 10
        Dim sngYHeight As Single
        Dim sngYHeight2 As Single

        Try
            If objDtImageListIn.Rows.Count = 1 Then
                ColumnCount = objDtImageListIn.Rows.Count
            End If

            If ColumnCount > objDtImageListIn.Rows.Count Then
                Return False
            ElseIf ColumnCount <= 0 Then
                Return False
            Else

                ReDim rectImage(objDtImageListIn.Rows.Count - 1)

                Select Case ColumnCount
                    Case 1
                        sngYHeight = 0
                        sngYHeight2 = YPosition
                        For colObjects = 0 To objDtImageListIn.Rows.Count - 1
                            objBitmapImage = CType(objDtImageListIn.Rows(colObjects).Item("Image"), Bitmap)
                            rectImage(colObjects).Height = objBitmapImage.Height
                            rectImage(colObjects).Width = objBitmapImage.Width

                            '//-----
                            'sngYHeight = YPosition + rectImage(colObjects).Height

                            'If sngYHeight >= mintPageFooterYPosotion Then
                            'CheckForUnEvenObjects = True
                            'Return False
                            'End If

                            'sngYHeight = sngYHeight2 + objBitmapImage.Height
                            'If (sngYHeight + (lineSpacing + rectImageCaption.Height)) >= mintPageFooterYPosotion Then
                            '    CheckForUnEvenObjects = True
                            '    Return True
                            'End If
                            '//-----
                            If colObjects = 0 Then
                                '---Set First Location
                                rectImage(colObjects).Location = New PointF(LeftMargin, YPosition)
                            Else
                                '---Set Each Incremental Locations
                                rectImage(colObjects).Location = New PointF(rectImage(colObjects - 1).Location.X, rectImage(colObjects - 1).Location.Y + rectImage(colObjects - 1).Height + ControlVSpacing)
                            End If

                            '=====================================================================
                            ' Description explaining the steps followed: 
                            '--- Draw Image and Image Caption 
                            '=====================================================================
                            Call G.DrawImage(objBitmapImage, rectImage(colObjects))

                            Dim strImageCaption As String = CType(objDtImageListIn.Rows(colObjects).Item("ImageCaption"), String)
                            rectImageCaption.Height = G.MeasureString(strImageCaption, printFont).Height
                            rectImageCaption.Width = rectImage(colObjects).Width
                            rectImageCaption.Y = rectImage(colObjects).Y + rectImage(colObjects).Height
                            rectImageCaption.X = rectImage(colObjects).X

                            Call G.DrawString(strImageCaption, printFont, New Pen(Color.Black).Brush, rectImageCaption)

                            rectImage(colObjects).Height += rectImageCaption.Height
                            '=====================================================================
                            '//-----
                            sngYHeight2 = sngYHeight
                            '//-----
                        Next colObjects

                    Case Is > 1
                        RowCount = (objDtImageListIn.Rows.Count) / ColumnCount

                        unEvenObjectsCount = (objDtImageListIn.Rows.Count) - CInt((Fix(RowCount) * ColumnCount))
                        '---Decide UnEven or Even no. of Columns 
                        If unEvenObjectsCount > 0 Then
                            RowCount = Fix(RowCount) + 1
                            CheckForUnEvenObjects = True
                        Else
                            CheckForUnEvenObjects = False
                        End If
                        sngYHeight = 0
                        sngYHeight2 = YPosition

                        For rowCounter = 0 To CInt(Fix(RowCount) - 1)


                            For ColCounter = 0 To ColumnCount - 1

                                objBitmapImage = CType(objDtImageListIn.Rows(ObjIndex).Item("Image"), Bitmap)
                                rectImage(ObjIndex).Height = objBitmapImage.Height
                                rectImage(ObjIndex).Width = objBitmapImage.Width

                                ''sngYHeight = sngYHeight2 + objBitmapImage.Height + (lineSpacing + rectImageCaption.Height)
                                'sngYHeight = sngYHeight2 + rectImage(ObjIndex).Height + (lineSpacing + rectImageCaption.Height)
                                ''sngYHeight = (lineSpacing + rectImageCaption.Height + rectImageCaption.Y)

                                'If (sngYHeight) >= mintPageFooterYPosotion Then
                                '    CheckForUnEvenObjects = True
                                '    Return True
                                'End If



                                If rowCounter = 0 Then
                                    If ColCounter = 0 Then
                                        '---Set First Location
                                        rectImage(ObjIndex).Location = New PointF(LeftMargin, YPosition)
                                    Else
                                        '---Set Each Next Location
                                        rectImage(ObjIndex).Location = New PointF(rectImage(ObjIndex - 1).Location.X + rectImage(ObjIndex - 1).Width + ControlHSpacing, rectImage(ObjIndex - 1).Location.Y)
                                    End If
                                Else
                                    If unEvenObjectsCount > 0 Then
                                        If rowCounter = Int(Fix(RowCount) - 1) Then
                                            unEvenObjectsCounter = unEvenObjectsCounter + 1
                                        End If
                                    End If

                                    If ColCounter = 0 Then
                                        '---Set First Location
                                        rectImage(ObjIndex).Location = New PointF(rectImage(ObjIndex - (ColumnCount - 1)).Location.X - rectImage(ObjIndex - 1).Width - ControlHSpacing, rectImage(ObjIndex - 1).Location.Y + rectImage(ObjIndex - 1).Height + ControlVSpacing)
                                    Else
                                        '---Set Each Next Location
                                        rectImage(ObjIndex).Location = New PointF(rectImage(ObjIndex - 1).Location.X + rectImage(ObjIndex - 1).Width + ControlHSpacing, rectImage(ObjIndex - 1).Location.Y)
                                    End If
                                End If

                                If Not objDtImageListIn.Rows(ObjIndex).Item("Image") Is Nothing Then
                                    '---Draw Image
                                    '=====================================================================
                                    ' Description explaining the steps followed: 
                                    '--- Draw Image and Image Caption 
                                    '=====================================================================
                                    Call G.DrawImage(objBitmapImage, rectImage(ObjIndex))

                                    Dim strImageCaption As String = CType(objDtImageListIn.Rows(ObjIndex).Item("ImageCaption"), String)
                                    rectImageCaption.Height = G.MeasureString(strImageCaption, printFont).Height
                                    rectImageCaption.Width = rectImage(ObjIndex).Width
                                    rectImageCaption.Y = rectImage(ObjIndex).Y + rectImage(ObjIndex).Height
                                    rectImageCaption.X = rectImage(ObjIndex).X

                                    Call G.DrawString(strImageCaption, printFont, New Pen(Color.Black).Brush, rectImageCaption)

                                    rectImage(ObjIndex).Height += rectImageCaption.Height
                                    '=====================================================================

                                End If

                                ObjIndex = ObjIndex + 1

                                If CheckForUnEvenObjects = True Then
                                    If unEvenObjectsCounter = unEvenObjectsCount Then
                                        Exit For
                                    End If
                                End If
                            Next

                        Next

                End Select

            End If

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

    Private Function funcDrawAllGraphs(ByRef EV As PrintPageEventArgs, ByRef sngYPositionIn As Single, ByVal sngLeftMarginIn As Single) As Boolean

        Dim rectGraph As RectangleF
        Dim sngHeightOfGraph As Single
        Dim objGraphCtrl As AldysGraph.AldysGraph
        'Dim objSpaceGraphCtrl As ColorSpaceDiagram.ColorSpaceDiagram
        Dim arrGraphsPerPage As ArrayList
        Dim intGraphCtrlCounter As Integer
        Dim intEachGraphHeight As Integer
        Dim nrperpage As Integer
        Dim intNoOfGraphsPerPage As Integer
        Dim intColumnsPerPage As Integer
        Dim intRectGraphYPosition As Integer
        'Dim cWait As CWaitCursor
        Static intIsPageReapate As Boolean

        Try
            rectGraph.X += sngLeftMarginIn
            rectGraph.Y += sngYPositionIn
            rectGraph.Height = EV.MarginBounds.Height - sngYPositionIn
            rectGraph.Width = EV.MarginBounds.Width

            If IsNothing(Me.ReportGraphControls) = True Then
                Exit Function
            End If


            sngYPositionIn += (lineSpacing + printFont.GetHeight(EV.Graphics))
            rectGraph.Y = sngYPositionIn

            '---Work out the number of pages
            intNoOfGraphsPerPage = 1
            intEachGraphHeight = CType(marrGraphControlsList.Item(0), Control).Height

            '//----- Added by Sachin Dokhale on 28.09.05
            If rectGraph.Height > 0 Then
                intRectGraphYPosition = CInt(rectGraph.Y + intEachGraphHeight)
            Else
                intRectGraphYPosition = CInt(rectGraph.Y) '(rectImage.Y)
            End If

            If intRectGraphYPosition >= mintPageFooterYPosotion Then
                If intIsPageReapate = True Then
                    If blnPageSettingMessage = False Then
                        'Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
                        'Application.DoEvents()
                        'cWait = New CWaitCursor
                    End If

                    EV.HasMorePages = False
                    EV.Cancel = True
                    Exit Function
                End If

                EV.HasMorePages = True
                intIsPageReapate = True
                Exit Function
            End If

            '//-----

            If mintReportLayoutType = enumReportLayoutType.Portrate Then
                intColumnsPerPage = 1
            Else
                intColumnsPerPage = 2
            End If

            nrperpage = CInt(rectGraph.Height) \ intEachGraphHeight
            If nrperpage = 0 Then
                If intIsPageReapate = True Then
                    If blnPageSettingMessage = False Then
                        'Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
                        'Application.DoEvents()
                        'cWait = New CWaitCursor

                        blnPageSettingMessage = True
                    End If
                    EV.HasMorePages = False
                    EV.Cancel = True
                    Return True
                End If
                intIsPageReapate = True
                EV.HasMorePages = True
                Return True
            End If

            '---Work out no. of pages considering no. of columns in each page
            nrperpage = nrperpage * intColumnsPerPage 'intNoOfGraphsPerPage

            arrGraphsPerPage = New ArrayList
            Dim intRemMod As Integer
            Dim intGraphCounter As Integer
            Dim intGraphCount As Integer
            Dim IntHigherHight1 As Integer
            Dim IntHigherHight2 As Integer
            Dim blnNextHeight As Boolean = False
            intGraphCounter = mintCurrentGraph
            For intGraphCtrlCounter = mintCurrentGraph To nrperpage + mintCurrentGraph - 1
                If intGraphCtrlCounter >= marrGraphControlsList.Count Then
                    Exit For
                End If
                arrGraphsPerPage.Add(marrGraphControlsList.Item(intGraphCtrlCounter))

            Next intGraphCtrlCounter


            If ArrangeGraphsInGrid(arrGraphsPerPage, EV.Graphics, intColumnsPerPage, sngLeftMarginIn, sngYPositionIn) Then
                For intGraphCount = 0 To intGraphCtrlCounter - mintCurrentGraph  'nrperpage + mintCurrentGraph - 1

                    If intGraphCount >= (intGraphCtrlCounter - mintCurrentGraph) Then 'marrGraphControlsList.Count Then
                        Exit For
                    End If
                    '//----- Added by Sachin Dokhale on 02.09.07
                    '//----- Print Graph with Constant Size
                    'intPrevious_Height = CType(arrGraphsPerPage.Item(intGraphCount), Control).Height
                    'CType(arrGraphsPerPage.Item(intGraphCount), Control).Height = CONST_Height

                    'intPrevious_Width = CType(arrGraphsPerPage.Item(intGraphCount), Control).Width
                    'CType(arrGraphsPerPage.Item(intGraphCount), Control).Width = CONST_Width
                    '//-----

                    If mintReportLayoutType = enumReportLayoutType.Portrate Then
                        'sngYPositionIn += CType(arrGraphsPerPage.Item(intGraphCount), Control).Height
                        sngYPositionIn += CONST_GraphHeight
                        sngYPositionIn += (lineSpacing + printFont.GetHeight(EV.Graphics))
                    Else
                        intRemMod = CInt(intGraphCount Mod 2)
                        'intRemMod = a Mod 2
                        If intRemMod = 0 Then
                            'IntHigherHight1 = CType(arrGraphsPerPage.Item(intGraphCount), Control).Height
                            IntHigherHight1 = CONST_GraphHeight
                            IntHigherHight2 = 0
                            blnNextHeight = True
                        ElseIf intRemMod = 1 Then
                            'IntHigherHight2 = CType(arrGraphsPerPage.Item(intGraphCount), Control).Height
                            IntHigherHight2 = CONST_GraphHeight
                            blnNextHeight = False
                        End If

                        If IntHigherHight1 > IntHigherHight2 Then
                            If blnNextHeight = True Then
                                sngYPositionIn += IntHigherHight1
                                sngYPositionIn += (lineSpacing + printFont.GetHeight(EV.Graphics))
                            End If
                        Else
                            sngYPositionIn += IntHigherHight2 - IntHigherHight1
                            sngYPositionIn += (lineSpacing + printFont.GetHeight(EV.Graphics))
                        End If
                    End If
                    '//----- Added by Sachin Dokhale on 02.09.07
                    '//----- Set original Graph size
                    'CType(arrGraphsPerPage.Item(intGraphCount), Control).Height = intPrevious_Height
                    'CType(arrGraphsPerPage.Item(intGraphCount), Control).Width = intPrevious_Width
                    '//-----
                Next intGraphCount

                mintCurrentGraph = intGraphCtrlCounter
                intIsPageReapate = False
                'If we have more Graphs then print another page
                If (mintCurrentGraph < marrGraphControlsList.Count) Then
                    EV.HasMorePages = True
                    intGraphCount = 0
                    intGraphCounter = 0
                Else
                    EV.HasMorePages = False
                    'mintCurrentGraph = 0
                End If
            End If
            intIsPageReapate = False
            Return True

            Exit Function

            Do While mintReportGraphsCount < marrGraphControlsList.Count
                '---For CommonGraphControl and CieGraphControl
                If TypeOf marrGraphControlsList.Item(mintReportGraphsCount) Is AldysGraph.AldysGraph Then
                    objGraphCtrl = CType(marrGraphControlsList.Item(mintReportGraphsCount), AldysGraph.AldysGraph)
                    rectGraph.Height = objGraphCtrl.Height

                    If TypeOf (objGraphCtrl) Is AldysGraph.AldysGraph Then
                        rectGraph.Width = CSng(objGraphCtrl.Height * 1.75)
                    ElseIf TypeOf (objGraphCtrl) Is AldysGraph.AldysGraph Then
                        rectGraph.Width = CSng(objGraphCtrl.Height * 1.5)
                    End If
                    Dim strGraphTitle As String
                    strGraphTitle = "Graph of " & objGraphCtrl.AldysPane.XAxis.Title & " Vs. " & objGraphCtrl.AldysPane.YAxis.Title
                    'commented by deepak on 24.08.07
                    'objGraphCtrl.AldysPane.Title = strGraphTitle
                    objGraphCtrl.AldysPane.Title = ""
                    '---Draw Common Graph
                    Call objGraphCtrl.DrawGraphOnGraphics(EV.Graphics, CInt(rectGraph.X), CInt(rectGraph.Y), CInt(rectGraph.Width), CInt(rectGraph.Height))
                    objGraphCtrl.AldysPane.Title = ""
                End If

                '---For ColorSpaceDiagramGraphControl 
                'If TypeOf marrGraphControlsList.Item(mintReportGraphsCount) Is ColorSpaceDiagram.ColorSpaceDiagram Then
                '    objSpaceGraphCtrl = CType(marrGraphControlsList.Item(mintReportGraphsCount), ColorSpaceDiagram.ColorSpaceDiagram)
                '    rectGraph.Height = objSpaceGraphCtrl.Height
                '    rectGraph.Width = CSng(objSpaceGraphCtrl.Height * 1.75)

                '    Dim strGraphTitle As String
                '    If objSpaceGraphCtrl.AldysPane.IsDCDH = True Then
                '        strGraphTitle = " DC/DH Plot "
                '    Else
                '        strGraphTitle = " DA/DB Plot "
                '    End If
                '    If objSpaceGraphCtrl.AldysPane.IsLABCH = True Then
                '        strGraphTitle = " LABCH Plot "
                '    End If
                '    objSpaceGraphCtrl.AldysPane.Title = strGraphTitle
                '    objSpaceGraphCtrl.DrawGraphOnGraphics(EV.Graphics, CInt(rectGraph.X), CInt(rectGraph.Y), CInt(rectGraph.Width), CInt(rectGraph.Height))
                '    objSpaceGraphCtrl.AldysPane.Title = ""
                'End If

                '---Increment GridRect Location 
                If mintReportLayoutType = enumReportLayoutType.Portrate Then
                    sngYPositionIn += (lineSpacing + printFont.GetHeight(EV.Graphics))
                    sngYPositionIn += CType(Me.ReportGraphControls.Item(mintReportGraphsCount), Control).Height

                    rectGraph.X = sngLeftMarginIn
                    rectGraph.Y = sngYPositionIn
                ElseIf mintReportLayoutType = enumReportLayoutType.Landscape Then
                    rectGraph.X = sngLeftMarginIn + rectGraph.Width + lineSpacing + printFont.GetHeight(EV.Graphics)
                    rectGraph.Y = sngYPositionIn
                End If

                sngYPositionIn = rectGraph.Y

                If EV.HasMorePages = False Then
                    mintReportGraphsCount += 1
                    If Not mintReportGraphsCount = Me.marrGraphControlsList.Count Then
                        sngHeightOfGraph = CType(Me.marrGraphControlsList.Item(mintReportGraphsCount), Control).Height

                        If (EV.MarginBounds.Height - rectGraph.Y) > (sngHeightOfGraph + lineSpacing + printFont.GetHeight(EV.Graphics)) Then
                            '---Continue printing on same page
                            EV.HasMorePages = False
                        Else
                            '---go to the new page
                            EV.HasMorePages = True
                            Exit Function
                        End If
                    End If
                Else
                    Exit Function
                End If

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
            'If Not cWait Is Nothing Then
            'cWait.Dispose()
            'End If
        End Try
    End Function

    Private Function ArrangeGraphsInGrid(ByVal arrGraphListIn As ArrayList, ByRef G As Graphics, ByVal ColumnCount As Integer, ByVal LeftMargin As Single, ByVal YPosition As Single) As Boolean
        '=====================================================================
        ' Procedure Name        : ArrangeGraphsInGrid
        ' Parameters Passed     : 
        ' Returns               : true or false
        ' Purpose               : To show the layout with Graphs on the report
        ' Description           : if single row grid is set the 
        '                         columncount = number of Graphs otherwise divide total 
        '                         number of controls by the column count set the user
        '                         and arrange all the Graphs by using horizontal and 
        '                         vertical spacing and size of the Graphs
        '
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : Wednesday, April 20, 2005
        ' Revisions             : 
        '=====================================================================
        '---if single row grid is set the columncount = number of Graphs
        '---otherwise divide total number of Graphs by the column count set the user
        '---and arrange all the Graphs by using horizontal and vertical spacing 
        '---and size of the Graphs
        Dim colObjects As Integer
        Dim rowCounter, ColCounter As Integer
        Dim ObjIndex As Integer = 0
        Dim RowCount As Double
        Dim unEvenObjectsCount As Integer
        Dim unEvenObjectsCounter As Integer = 0
        Dim CheckForUnEvenObjects As Boolean

        Dim rectGraph() As RectangleF

        Dim ControlVSpacing As Single = 10
        Dim ControlHSpacing As Single = 10
        'Static CONST_Height = 350
        'Static CONST_Width = 550
        Dim intPrevious_Height As Integer
        Dim intPrevious_Width As Integer

        Try
            If arrGraphListIn.Count = 1 Then
                ColumnCount = arrGraphListIn.Count
            End If

            If ColumnCount > arrGraphListIn.Count Then
                Return False
            ElseIf ColumnCount <= 0 Then
                Return False
            Else

                ReDim rectGraph(arrGraphListIn.Count - 1)

                Select Case ColumnCount
                    Case 1
                        For colObjects = 0 To arrGraphListIn.Count - 1
                            Dim objGraphCtrl As AldysGraph.AldysGraph
                            'Dim objSpaceGraphCtrl As ColorSpaceDiagram.ColorSpaceDiagram
                            '---For CommonGraphControl and CieGraphControl
                            If TypeOf arrGraphListIn.Item(colObjects) Is AldysGraph.AldysGraph Then
                                objGraphCtrl = CType(arrGraphListIn.Item(colObjects), AldysGraph.AldysGraph)

                                '//----- Modified by Sachin Dokhale on 03.09.07
                                '//----- To print the fix size of graph 
                                'rectGraph(colObjects).Height = objGraphCtrl.Height
                                'rectGraph(colObjects).Width = objGraphCtrl.Width
                                'If TypeOf (objGraphCtrl) Is AldysGraph.AldysGraph Then
                                '    rectGraph(colObjects).Width = CSng(objGraphCtrl.Height * 1.75)
                                'ElseIf TypeOf (objGraphCtrl) Is AldysGraph.AldysGraph Then
                                '    rectGraph(colObjects).Width = CSng(objGraphCtrl.Height * 1.5)
                                'End If
                                rectGraph(colObjects).Height = CONST_GraphHeight
                                rectGraph(colObjects).Width = CONST_GraphWidth
                                '//-----
                            End If
                            'If TypeOf arrGraphListIn.Item(colObjects) Is ColorSpaceDiagram.ColorSpaceDiagram Then
                            '    objSpaceGraphCtrl = CType(arrGraphListIn.Item(colObjects), ColorSpaceDiagram.ColorSpaceDiagram)
                            '    rectGraph(colObjects).Height = objSpaceGraphCtrl.Height
                            '    rectGraph(colObjects).Width = CSng(objSpaceGraphCtrl.Height * 1.75)
                            'End If

                            If colObjects = 0 Then
                                '---Set First Location
                                rectGraph(colObjects).Location = New PointF(LeftMargin, YPosition)
                            Else
                                '---Set Each Incremental Locations
                                rectGraph(colObjects).Location = New PointF(rectGraph(colObjects - 1).Location.X, rectGraph(colObjects - 1).Location.Y + rectGraph(colObjects - 1).Height + ControlVSpacing)
                            End If
                            '=====================================================================
                            ' Description explaining the steps followed: 
                            '--- Draw Common Graph 
                            '=====================================================================
                            Dim strGraphTitle As String
                            If Not IsNothing(objGraphCtrl) = True Then
                                strGraphTitle = "Graph of " & objGraphCtrl.AldysPane.XAxis.Title & " Vs. " & objGraphCtrl.AldysPane.YAxis.Title
                                'objGraphCtrl.AldysPane.Title = strGraphTitle
                                'commented by deepak on 24.08.07
                                objGraphCtrl.AldysPane.Title = ""
                                Call objGraphCtrl.DrawGraphOnGraphics(G, CInt(rectGraph(colObjects).X), CInt(rectGraph(colObjects).Y), CInt(rectGraph(colObjects).Width), CInt(rectGraph(colObjects).Height))
                                objGraphCtrl.AldysPane.Title = ""
                            End If
                            'objGraphCtrl.Dispose()
                            objGraphCtrl = Nothing

                            '---Color Space Diagram
                            'If Not IsNothing(objSpaceGraphCtrl) = True Then
                            '    If objSpaceGraphCtrl.AldysPane.IsDCDH = True Then
                            '        strGraphTitle = " DC/DH Plot "
                            '    Else
                            '        strGraphTitle = " DA/DB Plot "
                            '    End If
                            '    If objSpaceGraphCtrl.AldysPane.IsLABCH = True Then
                            '        strGraphTitle = " LABCH Plot "
                            '    End If
                            '    objSpaceGraphCtrl.AldysPane.Title = strGraphTitle
                            '    objSpaceGraphCtrl.DrawGraphOnGraphics(G, CInt(rectGraph(colObjects).X), CInt(rectGraph(colObjects).Y), CInt(rectGraph(colObjects).Width), CInt(rectGraph(colObjects).Height))
                            '    objSpaceGraphCtrl.AldysPane.Title = ""
                            'End If
                            ''objSpaceGraphCtrl.Dispose()
                            'objSpaceGraphCtrl = Nothing
                            '=====================================================================
                        Next colObjects

                    Case Is > 1
                        RowCount = arrGraphListIn.Count / ColumnCount

                        unEvenObjectsCount = (arrGraphListIn.Count) - CInt((Fix(RowCount) * ColumnCount))
                        '---Decide UnEven or Even no. of Columns 
                        If unEvenObjectsCount > 0 Then
                            RowCount = Fix(RowCount) + 1
                            CheckForUnEvenObjects = True
                        Else
                            CheckForUnEvenObjects = False
                        End If

                        For rowCounter = 0 To CInt(Fix(RowCount) - 1)
                            For ColCounter = 0 To ColumnCount - 1
                                Dim objGraphCtrl As AldysGraph.AldysGraph
                                'Dim objSpaceGraphCtrl As ColorSpaceDiagram.ColorSpaceDiagram

                                If TypeOf arrGraphListIn.Item(ObjIndex) Is AldysGraph.AldysGraph Then
                                    objGraphCtrl = CType(arrGraphListIn.Item(ObjIndex), AldysGraph.AldysGraph)
                                    '//----- Modified by Sachin Dokhale on 03.09.07
                                    '//----- To print the fix size of graph 
                                    'rectGraph(ObjIndex).Height = objGraphCtrl.Height
                                    'rectGraph(ObjIndex).Width = objGraphCtrl.Width
                                    'If TypeOf (objGraphCtrl) Is AldysGraph.AldysGraph Then
                                    '    rectGraph(ObjIndex).Width = CSng(objGraphCtrl.Height * 1.75)
                                    'ElseIf TypeOf (objGraphCtrl) Is AldysGraph.AldysGraph Then
                                    '    rectGraph(ObjIndex).Width = CSng(objGraphCtrl.Height * 1.5)
                                    'End If
                                    rectGraph(ObjIndex).Height = CONST_GraphHeight
                                    rectGraph(ObjIndex).Width = CONST_GraphWidth
                                    '//-----
                                End If
                                'If TypeOf arrGraphListIn.Item(ObjIndex) Is ColorSpaceDiagram.ColorSpaceDiagram Then
                                '    objSpaceGraphCtrl = CType(arrGraphListIn.Item(ObjIndex), ColorSpaceDiagram.ColorSpaceDiagram)
                                '    rectGraph(ObjIndex).Height = objSpaceGraphCtrl.Height
                                '    rectGraph(ObjIndex).Width = CSng(objSpaceGraphCtrl.Height * 1.75)
                                'End If

                                If rowCounter = 0 Then
                                    If ColCounter = 0 Then
                                        '---Set First Location
                                        rectGraph(ObjIndex).Location = New PointF(LeftMargin, YPosition)
                                    Else
                                        '---Set Each Next Location
                                        rectGraph(ObjIndex).Location = New PointF(rectGraph(ObjIndex - 1).Location.X + rectGraph(ObjIndex - 1).Width + ControlHSpacing, rectGraph(ObjIndex - 1).Location.Y)
                                    End If
                                Else
                                    If unEvenObjectsCount > 0 Then
                                        If rowCounter = Int(Fix(RowCount) - 1) Then
                                            unEvenObjectsCounter = unEvenObjectsCounter + 1
                                        End If
                                    End If

                                    If ColCounter = 0 Then
                                        '---Set First Location
                                        rectGraph(ObjIndex).Location = New PointF(rectGraph(ObjIndex - (ColumnCount - 1)).Location.X - rectGraph(ObjIndex - 1).Width - ControlHSpacing, rectGraph(ObjIndex - 1).Location.Y + rectGraph(ObjIndex - 1).Height + ControlVSpacing)
                                    Else
                                        '---Set Each Next Location
                                        rectGraph(ObjIndex).Location = New PointF(rectGraph(ObjIndex - 1).Location.X + rectGraph(ObjIndex - 1).Width + ControlHSpacing, rectGraph(ObjIndex - 1).Location.Y)
                                    End If
                                End If

                                If Not arrGraphListIn.Item(ObjIndex) Is Nothing Then
                                    '=====================================================================
                                    ' Description explaining the steps followed: 
                                    '--- Draw Common Graph And CIE Graph
                                    '=====================================================================
                                    Dim strGraphTitle As String
                                    If Not IsNothing(objGraphCtrl) = True Then
                                        strGraphTitle = "Graph of " & objGraphCtrl.AldysPane.XAxis.Title & " Vs. " & objGraphCtrl.AldysPane.YAxis.Title
                                        'commented by deepak on 24.08.07
                                        'objGraphCtrl.AldysPane.Title = strGraphTitle
                                        objGraphCtrl.AldysPane.Title = strGraphTitle
                                        Call objGraphCtrl.DrawGraphOnGraphics(G, CInt(rectGraph(ObjIndex).X), CInt(rectGraph(ObjIndex).Y), CInt(rectGraph(ObjIndex).Width), CInt(rectGraph(ObjIndex).Height))
                                        objGraphCtrl.AldysPane.Title = ""
                                    End If
                                    'objGraphCtrl.Dispose()
                                    objGraphCtrl = Nothing

                                    '--- Draw Color Space Diagram
                                    'If Not IsNothing(objSpaceGraphCtrl) = True Then
                                    '    If objSpaceGraphCtrl.AldysPane.IsDCDH = True Then
                                    '        strGraphTitle = " DC/DH Plot "
                                    '    Else
                                    '        strGraphTitle = " DA/DB Plot "
                                    '    End If
                                    '    If objSpaceGraphCtrl.AldysPane.IsLABCH = True Then
                                    '        strGraphTitle = " LABCH Plot "
                                    '    End If
                                    '    objSpaceGraphCtrl.AldysPane.Title = strGraphTitle
                                    '    objSpaceGraphCtrl.DrawGraphOnGraphics(G, CInt(rectGraph(ObjIndex).X), CInt(rectGraph(ObjIndex).Y), CInt(rectGraph(ObjIndex).Width), CInt(rectGraph(ObjIndex).Height))
                                    '    objSpaceGraphCtrl.AldysPane.Title = ""
                                    'End If
                                    ''objSpaceGraphCtrl.Dispose()
                                    'objSpaceGraphCtrl = Nothing
                                    '=====================================================================
                                End If

                                ObjIndex = ObjIndex + 1

                                If CheckForUnEvenObjects = True Then
                                    If unEvenObjectsCounter = unEvenObjectsCount Then
                                        Exit For
                                    End If
                                End If
                            Next
                        Next

                End Select

            End If

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

#Region "CookBook Procedure"
    Private Function funcElamentInfo(ByRef EV As PrintPageEventArgs, ByVal sngXPositionIn As Single, ByRef sngYPositionIn As Single) As Boolean
        '=====================================================================
        ' Procedure Name        : funcElamentInfo
        ' Parameters Passed     : 
        ' Returns               : true or false
        ' Purpose               : To show the Elament Information on the report
        ' Description           : 
        '
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : Tuesday, Octomber 10, 2006
        ' Revisions             : 
        '=====================================================================



        Dim objBrush As Drawing.Brush
        Dim SetStringBold As Boolean
        Static intIsPageReapate As Boolean
        Dim rectReportHeader As Drawing.RectangleF
        Dim ReportHeaderFont As Font
        Dim strELE_Abriv As String
        Dim strELE_Name As String

        Try

            '    '//----- Added by Sachin Dokhale on 28.09.05
            '    mintPageFooterYPosotion = CInt(PageFooterLineY1)
            '//-----
            'System.Drawing.Printing.PageSettings()
            Dim objARLayoutReport As DataDynamics.ActiveReports.ActiveReport

            objARLayoutReport = mobjARPortrateReport
            objBrush = New Pen(mobjReportBrushBlack.Color).Brush
            'objBrush = New Pen(mobjReportBrushRed.Color).Brush


            rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("lblElement"), DataDynamics.ActiveReports.Label).GetBounds
            ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("lblElement"), DataDynamics.ActiveReports.Label).Font
            strELE_Name = CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("NAME")) & " " & CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("ELE_NAME"))

            'rectReportHeader.X = ((objARLayoutReport.PageSettings.PaperWidth * 100) / 2) - ((Len(strELE_Name) * ReportHeaderFont.SizeInPoints) / 2)   'rectReportHeader.X * 96 + sngXPositionIn
            sngXPositionIn = rectReportHeader.X * 100
            rectReportHeader.X = rectReportHeader.X * 96 + sngXPositionIn
            rectReportHeader.Y = rectReportHeader.Y * 96 + sngYPositionIn
            rectReportHeader.Height = rectReportHeader.Height * 96
            rectReportHeader.Width = (rectReportHeader.Width * 72) * strELE_Name.Length 'rectReportHeader.Width * 96 
            EV.Graphics.DrawString(strELE_Name, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)

            strELE_Name = "At. Wt.      " & CStr(Format(objDtCookBookInfoRpt.Rows.Item(0).Item("ATWT"), "#0.000"))

            'sngYPositionIn += rectReportHeader.Height + (lineSpacing + printFont.GetHeight(EV.Graphics))

            'rectReportHeader.X = ((objARLayoutReport.PageSettings.PaperWidth * 100) / 2) - ((Len(strELE_Name) * ReportHeaderFont.SizeInPoints) / 2)   'rectReportHeader.X * 96 + sngXPositionIn
            rectReportHeader.X = (objARLayoutReport.PageSettings.PaperWidth * 100) - ((Len(strELE_Name) * (ReportHeaderFont.SizeInPoints)) + 30)
            rectReportHeader.Y = sngYPositionIn
            rectReportHeader.Height = rectReportHeader.Height * 96
            rectReportHeader.Width = rectReportHeader.Width * 96
            EV.Graphics.DrawString(strELE_Name, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)
            sngYPositionIn += (lineSpacing + printFont.GetHeight(EV.Graphics))
            blnFinishElamentInfo = True
            Return True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
            Return False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
            'If Not cWait Is Nothing Then
            'cWait.Dispose()
            'End If
        End Try
    End Function

    Private Function funcStdSolutionTech(ByRef EV As PrintPageEventArgs, ByVal sngXPositionIn As Single, ByRef sngYPositionIn As Single) As Boolean
        '=====================================================================
        ' Procedure Name        : funcStdSolutionTech
        ' Parameters Passed     : 
        ' Returns               : true or false
        ' Purpose               : To show the Elament Information on the report
        ' Description           : 
        '
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : Tuesday, Octomber 10, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objBrush As Drawing.Brush
        Dim SetStringBold As Boolean
        Static intIsPageReapate As Boolean
        Dim rectReportHeader As Drawing.RectangleF
        Dim ReportHeaderFont As Font
        Dim strELE_Abriv As String
        Dim strPrintText As String
        Dim chrSplitChar As Char
        Dim arrPrintTestList() As String
        Dim intArrIndex As Integer
        Dim blnSetIsSetYPosition As Boolean = False
        Const ConstHeader1 As String = "PREPARATION OF STANDARD SOLUTION"
        Const ConstSubHeader1 As String = "Recommended Standard Materials"
        Const ConstSubHeader2 As String = "Solution Technique"

        Try
            Dim objARLayoutReport As DataDynamics.ActiveReports.ActiveReport

            objARLayoutReport = mobjARPortrateReport

            '//---- Header 1
            rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader1"), DataDynamics.ActiveReports.Label).GetBounds
            ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader1"), DataDynamics.ActiveReports.Label).Font
            strPrintText = ConstHeader1
            objBrush = New Pen(mobjReportBrushBlack.Color).Brush

            'strELE_Name = CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("NAME")) & " " & CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("ELE_NAME"))
            'rectReportHeader.X = ((objARLayoutReport.PageSettings.PaperWidth * 100) / 2) - ((Len(strELE_Name) * ReportHeaderFont.SizeInPoints) / 2)   'rectReportHeader.X * 96 + sngXPositionIn
            sngXPositionIn = rectReportHeader.X * 100
            rectReportHeader.X = rectReportHeader.X * 96 + sngXPositionIn
            rectReportHeader.Y = rectReportHeader.Y * 50 + sngYPositionIn
            rectReportHeader.Height = rectReportHeader.Height * 96
            rectReportHeader.Width = rectReportHeader.Width * 96

            EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)

            '//---- Header 2
            'strELE_Name = "At. Wt.      " & CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("ATWT"))
            sngYPositionIn += rectReportHeader.Height + (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 10   'rectReportHeader.Height 

            If Not IsDBNull(objDtCookBookInfoRpt.Rows.Item(0).Item("STD_METRL")) = True Then ' Nothing Then
                If Not CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("STD_METRL")) = "" Then

                    rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).Font

                    strPrintText = ConstSubHeader1
                    rectReportHeader.X = rectReportHeader.X * 96 + sngXPositionIn
                    rectReportHeader.Y = sngYPositionIn
                    sngXPositionIn = rectReportHeader.X
                    rectReportHeader.Height = rectReportHeader.Height * 96
                    rectReportHeader.Width = rectReportHeader.Width * 96
                    'sngYPositionIn += rectReportHeader.Height
                    EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)

                    sngYPositionIn += (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 10

                    'sngYPositionIn += rectReportHeader.Height + +(lineSpacing + printFont.GetHeight(EV.Graphics))

                    'rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).GetBounds
                    'ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).Font
                    'sngYPositionIn += rectReportHeader.Height + (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics))

                    strPrintText = CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("STD_METRL"))

                    chrSplitChar = CChar(";")
                    arrPrintTestList = strPrintText.Split(chrSplitChar)
                    rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("Label1"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("Label1"), DataDynamics.ActiveReports.Label).Font
                    sngYPositionIn += rectReportHeader.Y

                    For intArrIndex = 0 To UBound(arrPrintTestList)
                        strPrintText = Trim(arrPrintTestList(intArrIndex))
                        rectReportHeader.Y = sngYPositionIn
                        'rectReportHeader.Y = sngYPositionIn
                        rectReportHeader.X = rectReportHeader.X * 96 + sngXPositionIn
                        'rectReportHeader.Y = sngYPositionIn
                        rectReportHeader.Height = rectReportHeader.Height * 60
                        rectReportHeader.Width = rectReportHeader.Width * 96
                        EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)
                        sngYPositionIn += lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)
                        rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("Label1"), DataDynamics.ActiveReports.Label).GetBounds
                        ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("Label1"), DataDynamics.ActiveReports.Label).Font
                    Next

                    '//---- Header 2 "Solution Technique

                    sngYPositionIn += rectReportHeader.Height + (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics))  'rectReportHeader.Height 
                    blnSetIsSetYPosition = True
                    'strELE_Name = "At. Wt.      " & CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("ATWT"))
                End If
            End If


            rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).GetBounds
            ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).Font

            If Not IsDBNull(objDtCookBookInfoRpt.Rows.Item(0).Item("SOLN_TECH")) = True Then

                If Not CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("SOLN_TECH")) = "" Then
                    If blnSetIsSetYPosition = False Then
                        sngYPositionIn += rectReportHeader.Height + (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics))  'rectReportHeader.Height 
                    End If
                    strPrintText = ConstSubHeader2

                    sngXPositionIn = rectReportHeader.X * 100

                    rectReportHeader.X = rectReportHeader.X * 96 + sngXPositionIn
                    rectReportHeader.Y = sngYPositionIn
                    sngXPositionIn = rectReportHeader.X
                    rectReportHeader.Height = rectReportHeader.Height * 96
                    rectReportHeader.Width = rectReportHeader.Width * 96
                    'sngYPositionIn += rectReportHeader.Height
                    EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)

                    sngYPositionIn += (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 10

                    '//----- 

                    strPrintText = CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("SOLN_TECH"))



                    'arrPrintTestList = strPrintText.Split(chrSplitChar)
                    rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("Label1"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("Label1"), DataDynamics.ActiveReports.Label).Font
                    sngYPositionIn += rectReportHeader.Y

                    'For intArrIndex = 0 To UBound(arrPrintTestList)
                    'strPrintText = Trim(arrPrintTestList(intArrIndex))
                    rectReportHeader.Y = sngYPositionIn
                    'rectReportHeader.Y = sngYPositionIn
                    rectReportHeader.X = rectReportHeader.X * 96 + sngXPositionIn
                    'rectReportHeader.Y = sngYPositionIn
                    rectReportHeader.Height = rectReportHeader.Height * 120 '60  '27.10.09
                    rectReportHeader.Width = rectReportHeader.Width * 102 '96 '27.10.09
                    EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)

                    sngYPositionIn += lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)
                End If
            End If
            blnFinishStdSolutionTech = True

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
            'If Not cWait Is Nothing Then
            'cWait.Dispose()
            'End If
        End Try
    End Function

    Private Function funcWorkingConditionFixed(ByRef EV As PrintPageEventArgs, ByVal sngXPositionIn As Single, ByRef sngYPositionIn As Single) As Boolean
        '=====================================================================
        ' Procedure Name        : funcWorkingConditionFixed
        ' Parameters Passed     : 
        ' Returns               : true or false
        ' Purpose               : To show the Elament Information on the report
        ' Description           : 
        '
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : Tuesday, Octomber 10, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objBrush As Drawing.Brush
        Dim SetStringBold As Boolean
        Static intIsPageReapate As Boolean
        Dim rectReportHeader As Drawing.RectangleF
        Dim ReportHeaderFont As Font
        Dim strELE_Abriv As String
        Dim strPrintText As String
        Const ConstHeader1 As String = "RECOMMENDED INSTRUMENT PARAMETERS"
        Const ConstSubHeader1 As String = "Atomic Absorption"
        Const ConstSubHeader2 As String = "Working Conditions (fixed)"
        Const ConstSubHeader3 As String = "Lamp Current"
        Const ConstSubHeader4 As String = "Fuel"
        Const ConstSubHeader5 As String = "Support"
        Const ConstSubHeader6 As String = "Flame Stoichiometry"
        Const ConstSubHeader7 As String = "Working Conditions (variable)"
        Try
            Dim objARLayoutReport As DataDynamics.ActiveReports.ActiveReport
            objARLayoutReport = mobjARPortrateReport

            '//---- Header 1
            rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader1"), DataDynamics.ActiveReports.Label).GetBounds
            ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader1"), DataDynamics.ActiveReports.Label).Font
            strPrintText = ConstHeader1
            objBrush = New Pen(mobjReportBrushBlack.Color).Brush
            'objBrush = New Pen(mobjReportBrushRed.Color).Brush

            'strELE_Name = CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("NAME")) & " " & CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("ELE_NAME"))
            'rectReportHeader.X = ((objARLayoutReport.PageSettings.PaperWidth * 100) / 2) - ((Len(strELE_Name) * ReportHeaderFont.SizeInPoints) / 2)   'rectReportHeader.X * 96 + sngXPositionIn
            sngXPositionIn = rectReportHeader.X * 100
            rectReportHeader.X = rectReportHeader.X * 96 + sngXPositionIn
            rectReportHeader.Y = rectReportHeader.Y * 60 + sngYPositionIn
            rectReportHeader.Height = rectReportHeader.Height * 96
            rectReportHeader.Width = rectReportHeader.Width * 96

            EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)

            '//---- sub Header 1
            'strELE_Name = "At. Wt.      " & CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("ATWT"))
            sngYPositionIn += rectReportHeader.Height + (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 15   'rectReportHeader.Height 

            rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).GetBounds
            ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).Font

            strPrintText = ConstSubHeader1
            rectReportHeader.X = rectReportHeader.X * 96 + sngXPositionIn
            rectReportHeader.Y = sngYPositionIn
            sngXPositionIn = rectReportHeader.X
            rectReportHeader.Height = rectReportHeader.Height * 96
            rectReportHeader.Width = rectReportHeader.Width * 96
            'sngYPositionIn += rectReportHeader.Height
            EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)

            '//---- sub Header 2
            'strELE_Name = "At. Wt.      " & CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("ATWT"))
            'sngYPositionIn += rectReportHeader.Height + (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 15   'rectReportHeader.Height 
            sngYPositionIn += (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 15    'rectReportHeader.Height 
            rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).GetBounds
            ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).Font

            strPrintText = ConstSubHeader2
            rectReportHeader.X = rectReportHeader.X * 96 + sngXPositionIn + 5
            rectReportHeader.Y = sngYPositionIn
            sngXPositionIn = rectReportHeader.X
            rectReportHeader.Height = rectReportHeader.Height * 96
            rectReportHeader.Width = rectReportHeader.Width * 96
            'sngYPositionIn += rectReportHeader.Height
            EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)

            '//---- sub Header 3
            'strELE_Name = "At. Wt.      " & CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("ATWT"))
            'sngYPositionIn += rectReportHeader.Height + (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 15   'rectReportHeader.Height 
            sngYPositionIn += (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 15    'rectReportHeader.Height 


            rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).GetBounds
            ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).Font

            strPrintText = ConstSubHeader3
            'sngXPositionIn = rectReportHeader.X * 100
            'rectReportHeader.X = sngXPositionIn 'rectReportHeader.X * 96 + sngXPositionIn + 5
            rectReportHeader.X = rectReportHeader.X * 96 + 66
            rectReportHeader.Y = sngYPositionIn
            sngXPositionIn = rectReportHeader.X
            rectReportHeader.Height = rectReportHeader.Height * 96
            rectReportHeader.Width = rectReportHeader.Width * 96
            'sngYPositionIn += rectReportHeader.Height
            EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)

            '//---- detals 1
            strPrintText = CStr(Format(objDtCookBookInfoRpt.Rows.Item(0).Item("CURRENT"), "#0.0")) & " mA"

            rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).GetBounds
            ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("Label1"), DataDynamics.ActiveReports.Label).Font
            rectReportHeader.X = rectReportHeader.X * 96 + 300
            'rectReportHeader.X = rectReportHeader.X * 96 + sngXPositionIn
            rectReportHeader.Y = sngYPositionIn + CSng(0.5)
            sngXPositionIn = rectReportHeader.X
            rectReportHeader.Height = rectReportHeader.Height * 96
            rectReportHeader.Width = rectReportHeader.Width * 96
            EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)

            '//---- sub Header 3
            'strELE_Name = "At. Wt.      " & CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("ATWT"))
            'sngYPositionIn += rectReportHeader.Height + (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 15   'rectReportHeader.Height 
            sngYPositionIn += (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 15    'rectReportHeader.Height 

            rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).GetBounds
            ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).Font

            strPrintText = ConstSubHeader4
            'sngXPositionIn = rectReportHeader.X * 100
            'rectReportHeader.X = sngXPositionIn 'rectReportHeader.X * 96 + sngXPositionIn + 5
            rectReportHeader.X = rectReportHeader.X * 96 + 66
            rectReportHeader.Y = sngYPositionIn
            sngXPositionIn = rectReportHeader.X
            rectReportHeader.Height = rectReportHeader.Height * 96
            rectReportHeader.Width = rectReportHeader.Width * 96
            'sngYPositionIn += rectReportHeader.Height
            EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)

            '//---- detals 2
            If CBool(objDtCookBookInfoRpt.Rows.Item(0).Item("FUEL")) = False Then
                strPrintText = "Acetylene"
            Else
                strPrintText = "None" 'CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("FUEL"))
            End If


            rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).GetBounds
            ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("Label1"), DataDynamics.ActiveReports.Label).Font
            'rectReportHeader.X = rectReportHeader.X * 96 + sngXPositionIn + 200
            rectReportHeader.X = rectReportHeader.X * 96 + 300
            rectReportHeader.Y = sngYPositionIn + CSng(0.5)
            sngXPositionIn = rectReportHeader.X
            rectReportHeader.Height = rectReportHeader.Height * 96
            rectReportHeader.Width = rectReportHeader.Width * 96
            EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)

            '//---- sub Header 3
            'strELE_Name = "At. Wt.      " & CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("ATWT"))
            'sngYPositionIn += rectReportHeader.Height + (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 15   'rectReportHeader.Height 
            sngYPositionIn += (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 15    'rectReportHeader.Height 

            rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).GetBounds
            ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).Font

            strPrintText = ConstSubHeader5
            'sngXPositionIn = rectReportHeader.X * 100
            'rectReportHeader.X = sngXPositionIn 'rectReportHeader.X * 96 + sngXPositionIn + 5
            rectReportHeader.X = rectReportHeader.X * 96 + 66
            rectReportHeader.Y = sngYPositionIn
            sngXPositionIn = rectReportHeader.X
            rectReportHeader.Height = rectReportHeader.Height * 96
            rectReportHeader.Width = rectReportHeader.Width * 96
            'sngYPositionIn += rectReportHeader.Height
            EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)

            '//---- detals 3
            'strPrintText = ConstSubHeader4
            If CBool(objDtCookBookInfoRpt.Rows.Item(0).Item("SUPPORT")) = False Then
                strPrintText = "Air"
            Else
                strPrintText = "Nitrous Oxide" 'CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("FUEL"))
            End If

            'strPrintText = CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("SUPPORT"))

            rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).GetBounds
            ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("Label1"), DataDynamics.ActiveReports.Label).Font
            rectReportHeader.X = rectReportHeader.X * 96 + 300
            'rectReportHeader.X = rectReportHeader.X * 96 + sngXPositionIn
            rectReportHeader.Y = sngYPositionIn + CSng(0.5)
            sngXPositionIn = rectReportHeader.X
            rectReportHeader.Height = rectReportHeader.Height * 96
            rectReportHeader.Width = rectReportHeader.Width * 96
            EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)

            '//---- sub Header 3
            'strELE_Name = "At. Wt.      " & CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("ATWT"))
            'sngYPositionIn += rectReportHeader.Height + (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 15   'rectReportHeader.Height 
            sngYPositionIn += (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 15    'rectReportHeader.Height 

            rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).GetBounds
            ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).Font

            strPrintText = ConstSubHeader6
            'sngXPositionIn = rectReportHeader.X * 100
            'rectReportHeader.X = sngXPositionIn 'rectReportHeader.X * 96 + sngXPositionIn + 5
            rectReportHeader.X = rectReportHeader.X * 96 + 66
            rectReportHeader.Y = sngYPositionIn
            sngXPositionIn = rectReportHeader.X
            rectReportHeader.Height = rectReportHeader.Height * 96
            rectReportHeader.Width = rectReportHeader.Width * 96
            'sngYPositionIn += rectReportHeader.Height
            EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)

            '//---- detals 4
            'strPrintText = ConstSubHeader4
            strPrintText = CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("FLAME_STO"))
            rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).GetBounds
            ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("Label1"), DataDynamics.ActiveReports.Label).Font
            rectReportHeader.X = rectReportHeader.X * 96 + 300
            'rectReportHeader.X = rectReportHeader.X * 96 + sngXPositionIn
            rectReportHeader.Y = sngYPositionIn + CSng(0.5)
            sngXPositionIn = rectReportHeader.X
            rectReportHeader.Height = rectReportHeader.Height * 128 '96 ''27.10.09
            rectReportHeader.Width = rectReportHeader.Width * 96
            EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)

            'sngYPositionIn += (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics))    'rectReportHeader.Height 
            blnFinishWorkingConditionFixed = True
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
            'If Not cWait Is Nothing Then
            'cWait.Dispose()
            'End If
        End Try
    End Function

    Private Function funcWorkingConditionVariable(ByRef EV As PrintPageEventArgs, ByVal sngXPositionIn As Single, ByRef sngYPositionIn As Single, ByVal sngLeftMarginIn As Single) As Boolean
        '=====================================================================
        ' Procedure Name        : funcWorkingConditionVariable
        ' Parameters Passed     : 
        ' Returns               : true or false
        ' Purpose               : To show the Elament Information on the report
        ' Description           : 
        '
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : Tuesday, Octomber 10, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objBrush As Drawing.Brush
        Dim SetStringBold As Boolean
        Static intIsPageReapate As Boolean
        Dim rectReportHeader As Drawing.RectangleF
        Dim ReportHeaderFont As Font
        Dim strELE_Abriv As String
        Dim strPrintText As String
        'Const ConstHeader1 As String = "RECOMMENDED INSTRUMENT PARAMETERS"
        'Const ConstSubHeader1 As String = "Atomic Absorption"
        Const ConstSubHeader1 As String = "Working Conditions (variable)"
        Const ConstSubHeader2 As String = "Notes "

        Try

            Dim objARLayoutReport As DataDynamics.ActiveReports.ActiveReport
            objARLayoutReport = mobjARPortrateReport

            '//---- sub Header 2
            'strELE_Name = "At. Wt.      " & CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("ATWT"))
            'sngYPositionIn += rectReportHeader.Height + (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 15   'rectReportHeader.Height 
            'sngYPositionIn += (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 15    'rectReportHeader.Height 
            objBrush = New Pen(mobjReportBrushBlack.Color).Brush

            strPrintText = ConstSubHeader1
            rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).GetBounds
            ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).Font


            sngXPositionIn = rectReportHeader.X * 100
            rectReportHeader.X = rectReportHeader.X * 96 + (sngXPositionIn * 2)

            sngYPositionIn += (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 10    'rectReportHeader.Height 

            'rectReportHeader.X = rectReportHeader.X * 96 + 5
            rectReportHeader.Y = sngYPositionIn
            sngXPositionIn = rectReportHeader.X
            rectReportHeader.Height = rectReportHeader.Height * 96
            rectReportHeader.Width = rectReportHeader.Width * 96
            'sngYPositionIn += rectReportHeader.Height
            EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)

            sngYPositionIn += lineSpacing + printFont.GetHeight(EV.Graphics) + 10

            '---5.Draw the Grid Tables from DataTable
            If EV.HasMorePages = False Then
                Call funcDrawGridTables(EV, sngYPositionIn, sngLeftMarginIn)
            End If


            If Not (IsDBNull(objDtCookBookInfoRpt.Rows.Item(0).Item("NOTES_AA")) = True) Then
                If Not (CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("NOTES_AA")) = "") Then
                    strPrintText = ConstSubHeader2
                    Dim sngSubHeaderWidth As Single
                    rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).Font

                    sngYPositionIn += (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 10    'rectReportHeader.Height 
                    rectReportHeader.X = rectReportHeader.X * 96 + sngXPositionIn
                    'rectReportHeader.X = rectReportHeader.X * 96 + 5
                    rectReportHeader.Y = sngYPositionIn
                    sngXPositionIn = rectReportHeader.X
                    rectReportHeader.Height = rectReportHeader.Height * 96
                    rectReportHeader.Width = rectReportHeader.Width * 96
                    sngSubHeaderWidth = ReportHeaderFont.Size * strPrintText.Length * 72  ' (EV.Graphics)'(EV.Graphics))    'rectReportHeader.Width

                    'sngYPositionIn += rectReportHeader.Height
                    EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)

                    strPrintText = CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("NOTES_AA"))

                    rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("Label1"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("Label1"), DataDynamics.ActiveReports.Label).Font

                    'sngYPositionIn += (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 10    'rectReportHeader.Height 
                    rectReportHeader.X = rectReportHeader.X * 96 + sngXPositionIn + 30
                    'rectReportHeader.X = rectReportHeader.X * 96 + 5
                    rectReportHeader.Y = sngYPositionIn
                    sngXPositionIn = rectReportHeader.X
                    rectReportHeader.Height = rectReportHeader.Height * 96
                    rectReportHeader.Width = rectReportHeader.Width * 96
                    sngYPositionIn += rectReportHeader.Height
                    EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)
                End If
            End If
            'sngYPositionIn += (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 10    'rectReportHeader.Height 
            blnFinishWorkingConditionVariable = True
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
            'If Not cWait Is Nothing Then
            'cWait.Dispose()
            'End If
        End Try
    End Function

    Private Function funcFlameEmission(ByRef EV As PrintPageEventArgs, ByVal sngXPositionIn As Single, ByRef sngYPositionIn As Single) As Boolean
        '=====================================================================
        ' Procedure Name        : funcFlameEmission
        ' Parameters Passed     : 
        ' Returns               : true or false
        ' Purpose               : To show the Elament Information on the report
        ' Description           : 
        '
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : Tuesday, Octomber 10, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objBrush As Drawing.Brush
        Dim SetStringBold As Boolean
        Static blnIsPageReapate As Boolean
        Dim rectReportHeader As Drawing.RectangleF
        Dim ReportHeaderFont As Font
        Dim strELE_Abriv As String
        Dim strPrintText As String
        'Dim divPen As Pen
        Dim divPen As New Pen(Color.Black)  'mobjReportDataGrid.GridLineColor)
        Dim hfpen As New Pen(Color.Black)   'mobjReportDataGrid.HeaderForeColor)
        Const ConstSubHeader1 As String = "Flame Emission"
        Const ConstSubHeader2 As String = "Notes "
        Const ConstSubHeader3 As String = "Wavelength"
        Const ConstSubHeader4 As String = "Bandwidth"
        Const ConstSubHeader5 As String = "Fuel"
        Const ConstSubHeader6 As String = "Support"

        Dim sngFlameBoxHeight As Single
        Dim lineFlameEmi As Drawing.Region
        Dim leftMargin As Single '= rectGrid.Left
        Dim topMargin As Single '= rectGrid.Top

        Dim w, l As Integer
        'Dim hfpen As New Pen(Color.Black)   'mobjReportDataGrid.HeaderForeColor)
        Dim hbBrush As New SolidBrush(Color.White)  'mobjReportDataGrid.HeaderBackColor)
        Dim hfBrush As New SolidBrush(Color.Black)  'mobjReportDataGrid.HeaderForeColor)
        Dim CellSize As SizeF
        Dim sngFrameBottomYPosition As Single
        Dim sngXEMSPosition As Single
        Dim sngLastWordLen As Single
        Try
            If IsDBNull(objDtCookBookInfoRpt.Rows.Item(0).Item("WVEMS")) = True Then

                blnFinishFlameEmission = True
                blnFinishFlameEmissionNotes = True
                Return True
            End If
            If CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("WVEMS")) = "0" Then
                blnFinishFlameEmission = True
                blnFinishFlameEmissionNotes = True
                Return True
            End If
            Dim objARLayoutReport As DataDynamics.ActiveReports.ActiveReport
            objARLayoutReport = mobjARPortrateReport
            rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("FlameShape"), DataDynamics.ActiveReports.Shape).GetBounds
            ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).Font

            If blnFinishFlameEmission = False Then


                sngFlameBoxHeight = sngYPositionIn + (rectReportHeader.Height * 72) + ((lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) * 2) + 10


                If sngFlameBoxHeight >= mintPageFooterYPosotion Then
                    If blnIsPageReapate = True Then
                        If blnPageSettingMessage = False Then
                            'Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
                            Application.DoEvents()
                            'cWait = New CWaitCursor
                        End If

                        EV.HasMorePages = False
                        EV.Cancel = True
                        blnFinishFlameEmission = True
                        Return False
                        'Exit Function
                    End If

                    EV.HasMorePages = True
                    blnIsPageReapate = True
                    blnFinishFlameEmission = False
                    Return True
                    'Exit Function

                ElseIf sngYPositionIn >= mintPageFooterYPosotion Then
                    If blnIsPageReapate = True Then
                        If blnPageSettingMessage = False Then
                            'Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
                            Application.DoEvents()
                            'cWait = New CWaitCursor
                        End If

                        EV.HasMorePages = False
                        EV.Cancel = True
                        blnFinishFlameEmission = True
                        'Exit Function
                        Return True

                    End If

                    EV.HasMorePages = True
                    blnIsPageReapate = True
                    blnFinishFlameEmission = False
                    Return True
                    'Exit Function
                End If

                strPrintText = ConstSubHeader1
                objBrush = New Pen(mobjReportBrushBlack.Color).Brush

                rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).GetBounds
                ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).Font

                'sngYPositionIn += (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 10    'rectReportHeader.Height 
                sngXPositionIn = rectReportHeader.X * 96 + sngXPositionIn + 5

                rectReportHeader.X = sngXPositionIn + 10 'rectReportHeader.X * 96 + sngXPositionIn + 5
                'rectReportHeader.X = rectReportHeader.X * 96 + 5
                rectReportHeader.Y = sngYPositionIn

                'sngXPositionIn = rectReportHeader.X
                rectReportHeader.Height = rectReportHeader.Height * 96
                rectReportHeader.Width = rectReportHeader.Width * 96
                'sngYPositionIn += rectReportHeader.Height
                EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)
                sngYPositionIn += rectReportHeader.Height

                '//////////---------------------




                sngXPositionIn = 50
                CellSize.Width = CType(objARLayoutReport.Sections("Detail").Controls("FlameShape"), DataDynamics.ActiveReports.Shape).Width * 96
                CellSize.Height = CType(objARLayoutReport.Sections("Detail").Controls("FlameShape"), DataDynamics.ActiveReports.Shape).Height * 96
                l = CInt(sngYPositionIn) 'CInt(CType(objARLayoutReport.Sections("Detail").Controls("FlameShape"), DataDynamics.ActiveReports.Shape).Left)
                w = CInt(sngXPositionIn) 'CInt(CType(objARLayoutReport.Sections("Detail").Controls("FlameShape"), DataDynamics.ActiveReports.Shape).Width)

                Dim r As New Rectangle(New Point(w, l), CellSize.ToSize)

                Dim rf As New Drawing.RectangleF(w, l, r.Width, r.Height)
                EV.Graphics.DrawLine(divPen, r.X, r.Y, r.Right, r.Y)
                EV.Graphics.DrawLine(divPen, r.X, r.Bottom, r.Right, r.Y + r.Height)
                'EV.Graphics.DrawLine(New Pen(Color.Black), r.X, r.Y, r.X, r.Y + r.Height)
                'EV.Graphics.DrawLine(New Pen(Color.Black), r.Width + r.X, r.Y, r.Width + r.X, r.Y + r.Height)
                EV.Graphics.DrawLine(divPen, r.X, r.Y, r.X, r.Y + r.Height)
                EV.Graphics.DrawLine(divPen, r.Width + r.X, r.Y, r.Width + r.X, r.Y + r.Height)
                '//----- Calulate Frame Bottom Y position
                sngFrameBottomYPosition = r.Y + r.Height

                '//---- sub Header 2
                'strELE_Name = "At. Wt.      " & CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("ATWT"))
                'sngYPositionIn += rectReportHeader.Height + (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 15   'rectReportHeader.Height 
                'sngYPositionIn += (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 15    'rectReportHeader.Height 



                'rectFlameEmi(0) = CType(objARLayoutReport.Sections("Detail").Controls("FlameShape"), DataDynamics.ActiveReports.Shape).GetBounds
                'rectFlameEmi(0).Y = sngYPositionIn

                'EV.Graphics.DrawRectangles(New Pen(objBrush, 2.5), rectFlameEmi)
                'EV.Graphics.DrawLine(New Pen(objBrush, 2.5))



                'rectReportReactangle = CType(objARLayoutReport.Sections("Detail").Controls("FlameShape"), DataDynamics.ActiveReports.Shape).GetBounds
                'ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).Font
                'CType(objARLayoutReport.Sections("Detail").Controls("FlameShape"), DataDynamics.ActiveReports.Line).Draw()


                'ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).Font

                sngXEMSPosition = sngXPositionIn
                '//----- Wavelength
                strPrintText = ConstSubHeader3
                objBrush = New Pen(mobjReportBrushBlack.Color).Brush

                rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).GetBounds
                ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).Font

                sngYPositionIn += (ReportHeaderFont.GetHeight(EV.Graphics))      'rectReportHeader.Height 
                rectReportHeader.X = rectReportHeader.X * 96 + sngXEMSPosition + 5
                sngXPositionIn = rectReportHeader.X
                'rectReportHeader.X = rectReportHeader.X * 96 + 5
                rectReportHeader.Y = sngYPositionIn '- 5
                sngXEMSPosition = rectReportHeader.X
                rectReportHeader.Height = rectReportHeader.Height * 96
                'rectReportHeader.Width = (ReportHeaderFont.GetHeight(EV.Graphics)) 'rectReportHeader.Width * 96
                rectReportHeader.Width = strPrintText.Length * (ReportHeaderFont.Size)
                'sngLastWordLen = strPrintText.Length * (ReportHeaderFont.Size)
                sngLastWordLen = 112.5
                'sngYPositionIn += rectReportHeader.Height
                EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)
                'sngYPositionIn += rectReportHeader.Height
                sngYPositionIn = rectReportHeader.Y

                '//-------Text

                'strPrintText = ""
                'Else
                strPrintText = CStr(Format(objDtCookBookInfoRpt.Rows.Item(0).Item("WVEMS"), "#0.00")) & " nm"
                objBrush = New Pen(mobjReportBrushBlack.Color).Brush

                rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("Label1"), DataDynamics.ActiveReports.Label).GetBounds
                ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("Label1"), DataDynamics.ActiveReports.Label).Font

                'sngYPositionIn += (ReportHeaderFont.GetHeight(EV.Graphics))      'rectReportHeader.Height 
                rectReportHeader.X = rectReportHeader.X * 96 + sngXEMSPosition + 100
                'rectReportHeader.X = rectReportHeader.X * 96 + 5
                rectReportHeader.Y = sngYPositionIn '- 5
                'sngXEMSPosition = rectReportHeader.X
                rectReportHeader.Height = rectReportHeader.Height * 96
                'rectReportHeader.Width = (ReportHeaderFont.GetHeight(EV.Graphics)) 'rectReportHeader.Width * 96
                rectReportHeader.Width = strPrintText.Length * (ReportHeaderFont.Size)
                'sngLastWordLen = strPrintText.Length * (ReportHeaderFont.Size)
                'sngYPositionIn += rectReportHeader.Height
                EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)
                'sngYPositionIn += rectReportHeader.Height
                'sngYPositionIn = rectReportHeader.Y

                '//----- Bandwidth
                strPrintText = ConstSubHeader4
                objBrush = New Pen(mobjReportBrushBlack.Color).Brush

                rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).GetBounds
                ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).Font

                'sngYPositionIn += (ReportHeaderFont.GetHeight(EV.Graphics))      'rectReportHeader.Height 
                'sngXPositionIn = rectReportHeader.X * 96 + sngXPositionIn + 5
                rectReportHeader.X = sngXEMSPosition + sngLastWordLen + 250
                rectReportHeader.Y = sngYPositionIn
                'sngXPositionIn = rectReportHeader.X
                rectReportHeader.Height = rectReportHeader.Height * 96
                'rectReportHeader.Width = rectReportHeader.Width * 96
                rectReportHeader.Width = strPrintText.Length * (ReportHeaderFont.Size)
                'sngYPositionIn += rectReportHeader.Height
                EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)
                sngXEMSPosition = rectReportHeader.X
                sngLastWordLen = strPrintText.Length * (ReportHeaderFont.Size)

                '//-------Text
                If Not CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("SLITEMS")) = "0" Then
                    strPrintText = CStr(Format(objDtCookBookInfoRpt.Rows.Item(0).Item("SLITEMS"), "0.0")) & " nm."

                    objBrush = New Pen(mobjReportBrushBlack.Color).Brush

                    rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("Label1"), DataDynamics.ActiveReports.Label).GetBounds
                    ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("Label1"), DataDynamics.ActiveReports.Label).Font

                    'sngYPositionIn += (ReportHeaderFont.GetHeight(EV.Graphics))      'rectReportHeader.Height 
                    'rectReportHeader.X = rectReportHeader.X * 96 + sngXEMSPosition + 30
                    rectReportHeader.X = sngXEMSPosition + sngLastWordLen + 90
                    rectReportHeader.Y = sngYPositionIn '- 5
                    'sngXEMSPosition = rectReportHeader.X
                    rectReportHeader.Height = rectReportHeader.Height * 96
                    'rectReportHeader.Width = (ReportHeaderFont.GetHeight(EV.Graphics)) 'rectReportHeader.Width * 96
                    rectReportHeader.Width = strPrintText.Length * (ReportHeaderFont.Size)
                    'sngLastWordLen = strPrintText.Length * (ReportHeaderFont.Size)
                    'sngYPositionIn += rectReportHeader.Height
                    EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)
                    'sngYPositionIn += rectReportHeader.Height
                    'sngYPositionIn = rectReportHeader.Y
                End If

                sngYPositionIn += lineSpacing + (ReportHeaderFont.GetHeight(EV.Graphics))

                '//----- Fuel
                strPrintText = ConstSubHeader5

                objBrush = New Pen(mobjReportBrushBlack.Color).Brush

                rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).GetBounds
                ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).Font

                sngXEMSPosition = sngXPositionIn
                sngYPositionIn += (ReportHeaderFont.GetHeight(EV.Graphics))      'rectReportHeader.Height 
                rectReportHeader.X = sngXEMSPosition 'rectReportHeader.X * 96 + sngXPositionIn + 5
                'rectReportHeader.X = rectReportHeader.X * 96 + 5
                rectReportHeader.Y = sngYPositionIn '- 5
                'sngXEMSPosition = rectReportHeader.X
                rectReportHeader.Height = rectReportHeader.Height * 96
                rectReportHeader.Width = rectReportHeader.Width * 96
                'sngYPositionIn += rectReportHeader.Height
                EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)
                sngYPositionIn = rectReportHeader.Y
                '//------------
                'strPrintText = CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("FUELEMS"))
                If CBool(objDtCookBookInfoRpt.Rows.Item(0).Item("FUELEMS")) = False Then
                    strPrintText = "Acetylene" 'CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("FUELEMS"))
                Else
                    strPrintText = "None"
                    'strPrintText = CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("FUELEMS"))
                End If


                objBrush = New Pen(mobjReportBrushBlack.Color).Brush

                rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("Label1"), DataDynamics.ActiveReports.Label).GetBounds
                ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("Label1"), DataDynamics.ActiveReports.Label).Font

                'sngYPositionIn += (ReportHeaderFont.GetHeight(EV.Graphics))      'rectReportHeader.Height 
                rectReportHeader.X = rectReportHeader.X * 96 + sngXEMSPosition + 100
                'rectReportHeader.X = rectReportHeader.X * 96 + 5
                rectReportHeader.Y = sngYPositionIn '- 5
                'sngXEMSPosition = rectReportHeader.X
                rectReportHeader.Height = rectReportHeader.Height * 96
                'rectReportHeader.Width = (ReportHeaderFont.GetHeight(EV.Graphics)) 'rectReportHeader.Width * 96
                rectReportHeader.Width = strPrintText.Length * (ReportHeaderFont.Size)
                'sngLastWordLen = strPrintText.Length * (ReportHeaderFont.Size)
                'sngYPositionIn += rectReportHeader.Height
                EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)

                '//----- Support
                strPrintText = ConstSubHeader6
                objBrush = New Pen(mobjReportBrushBlack.Color).Brush

                rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).GetBounds
                ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).Font

                'sngYPositionIn += (ReportHeaderFont.GetHeight(EV.Graphics))      'rectReportHeader.Height 
                'sngXPositionIn = rectReportHeader.X * 96 + sngXPositionIn + 5
                rectReportHeader.X = sngXEMSPosition + sngLastWordLen + 260
                'rectReportHeader.X = rectReportHeader.X * 96 + 5
                rectReportHeader.Y = sngYPositionIn
                'sngXPositionIn = rectReportHeader.X
                rectReportHeader.Height = rectReportHeader.Height * 96
                'rectReportHeader.Width = rectReportHeader.Width * 96
                rectReportHeader.Width = strPrintText.Length * (ReportHeaderFont.Size)
                'sngYPositionIn += rectReportHeader.Height
                EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)
                sngXEMSPosition = rectReportHeader.X

                'sngYPositionIn += rectReportHeader.Height
                '//-------Text

                'strPrintText = CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("SUPPORTEMS"))
                If CBool(objDtCookBookInfoRpt.Rows.Item(0).Item("SUPPORTEMS")) = False Then
                    strPrintText = "Air" 'CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("FUELEMS"))
                Else
                    strPrintText = "Nitrous Oxide"
                    'strPrintText = CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("FUELEMS"))
                End If

                objBrush = New Pen(mobjReportBrushBlack.Color).Brush

                rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("Label1"), DataDynamics.ActiveReports.Label).GetBounds
                ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("Label1"), DataDynamics.ActiveReports.Label).Font

                'sngYPositionIn += (ReportHeaderFont.GetHeight(EV.Graphics))      'rectReportHeader.Height 
                'rectReportHeader.X = rectReportHeader.X * 96 + sngXEMSPosition + 30
                rectReportHeader.X = sngXEMSPosition + sngLastWordLen + 90
                rectReportHeader.Y = sngYPositionIn '- 5
                'sngXEMSPosition = rectReportHeader.X
                rectReportHeader.Height = rectReportHeader.Height * 96
                'rectReportHeader.Width = (ReportHeaderFont.GetHeight(EV.Graphics)) 'rectReportHeader.Width * 96
                rectReportHeader.Width = strPrintText.Length * (ReportHeaderFont.Size)
                'sngLastWordLen = strPrintText.Length * (ReportHeaderFont.Size)
                'sngYPositionIn += rectReportHeader.Height
                EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)
                'sngYPositionIn += rectReportHeader.Height
                'sngYPositionIn = rectReportHeader.Y
                'End If
                sngYPositionIn += lineSpacing + (ReportHeaderFont.GetHeight(EV.Graphics))

                sngXEMSPosition = sngXPositionIn
                sngYPositionIn = sngFlameBoxHeight
            Else

                'sngYPositionIn = sngFlameBoxHeight
            End If

            If (sngFrameBottomYPosition + lineSpacing + (ReportHeaderFont.GetHeight(EV.Graphics))) >= mintPageFooterYPosotion Then
                EV.HasMorePages = True
                blnIsPageReapate = True

                blnFinishFlameEmission = True
                blnFinishFlameEmissionNotes = False
                Return True
            End If

            Dim blnCheckFlameEmissionNotes As Boolean
            blnCheckFlameEmissionNotes = IsDBNull(objDtCookBookInfoRpt.Rows.Item(0).Item("NOTES_EMS"))

            'If (objDtCookBookInfoRpt.Rows.Item(0).Item("NOTES_EMS")) IsDBNull Then
            If blnCheckFlameEmissionNotes = True Then
                blnFinishFlameEmissionNotes = True
                Return True
            End If

            If Not (CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("NOTES_EMS")) = "") Then


                strPrintText = ConstSubHeader2
                Dim sngSubHeaderWidth As Single
                rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).GetBounds
                ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).Font
                objBrush = New Pen(mobjReportBrushBlack.Color).Brush
                If blnFinishFlameEmission = True And blnFinishFlameEmissionNotes = False Then
                    'sngYPositionIn += sngYPositionIn
                    sngYPositionIn += sngFrameBottomYPosition + lineSpacing + (ReportHeaderFont.GetHeight(EV.Graphics))
                    'sngXPositionIn = rectReportHeader.X * 100
                    sngXEMSPosition = 15
                Else
                    sngYPositionIn = sngFrameBottomYPosition + lineSpacing + (ReportHeaderFont.GetHeight(EV.Graphics))
                End If
                'sngYPositionIn += (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 10    'rectReportHeader.Height 

                rectReportHeader.X = rectReportHeader.X * 96 + sngXEMSPosition

                'rectReportHeader.X = rectReportHeader.X * 96 + 5
                rectReportHeader.Y = sngYPositionIn
                sngXEMSPosition = rectReportHeader.X
                rectReportHeader.Height = rectReportHeader.Height * 96
                rectReportHeader.Width = rectReportHeader.Width * 96
                sngSubHeaderWidth = ReportHeaderFont.Size * strPrintText.Length * 72  ' (EV.Graphics)'(EV.Graphics))    'rectReportHeader.Width

                'sngYPositionIn += rectReportHeader.Height
                EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)

                strPrintText = CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("NOTES_EMS"))

                rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("Label1"), DataDynamics.ActiveReports.Label).GetBounds
                ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("Label1"), DataDynamics.ActiveReports.Label).Font

                'sngYPositionIn += (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 10    'rectReportHeader.Height 
                rectReportHeader.X = rectReportHeader.X * 96 + sngXEMSPosition + 30
                'rectReportHeader.X = rectReportHeader.X * 96 + 5
                rectReportHeader.Y = sngYPositionIn
                sngXPositionIn = rectReportHeader.X
                rectReportHeader.Height = rectReportHeader.Height * 96
                rectReportHeader.Width = rectReportHeader.Width * 96
                sngYPositionIn += rectReportHeader.Height
                EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)
                blnFinishFlameEmissionNotes = True
            Else
                blnFinishFlameEmissionNotes = True
            End If
            '//--------------
            'sngYPositionIn = sngFlameBoxHeight
            blnFinishFlameEmission = True
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
            'If Not cWait Is Nothing Then
            'cWait.Dispose()
            'End If
        End Try
    End Function

    Private Function funcInterference(ByRef EV As PrintPageEventArgs, ByVal sngXPositionIn As Single, ByRef sngYPositionIn As Single) As Boolean
        '=====================================================================
        ' Procedure Name        : ArrangeGraphsInGrid
        ' Parameters Passed     : 
        ' Returns               : true or false
        ' Purpose               : To show the Elament Information on the report
        ' Description           : 
        '
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : Tuesday, Octomber 10, 2006
        ' Revisions             : 
        '=====================================================================

        Dim objBrush As Drawing.Brush
        Dim SetStringBold As Boolean
        Static blnIsPageReapate As Boolean
        Dim rectReportHeader As Drawing.RectangleF
        Dim ReportHeaderFont As Font

        Dim strPrintText As String
        'Dim divPen As Pen


        Const ConstSubHeader1 As String = "Interferance"

        Dim sngYPosInterference As Single

        Try
            If sngYPositionIn >= mintPageFooterYPosotion Then
                If blnIsPageReapate = True Then
                    If blnPageSettingMessage = False Then
                        'Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
                        'Application.DoEvents()
                        'cWait = New CWaitCursor
                    End If

                    EV.HasMorePages = False
                    EV.Cancel = True
                    Exit Function
                End If

                EV.HasMorePages = True
                blnIsPageReapate = True
                Exit Function
            End If

            Dim objARLayoutReport As DataDynamics.ActiveReports.ActiveReport
            objARLayoutReport = mobjARPortrateReport
            strPrintText = CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("INTERFEREN"))
            'objBrush = New Pen(mobjReportBrushBlack.Color).Brush

            'rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("Label1"), DataDynamics.ActiveReports.Label).GetBounds
            'ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("Label1"), DataDynamics.ActiveReports.Label).Font

            rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("Label1"), DataDynamics.ActiveReports.Label).GetBounds
            ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("Label1"), DataDynamics.ActiveReports.Label).Font

            'sngYPositionIn += (ReportHeaderFont.GetHeight(EV.Graphics))      'rectReportHeader.Height 
            'sngYPosInterference = sngYPositionIn + lineSpacing + ((ReportHeaderFont.GetHeight(EV.Graphics)) * 4)      'rectReportHeader.Height 
            sngYPosInterference = sngYPositionIn + lineSpacing + (ReportHeaderFont.GetHeight(EV.Graphics)) + 10

            'sngYPosInterference = sngYPositionIn + lineSpacing + ((rectReportHeader.Height) * 4)       'rectReportHeader.Height 


            sngYPosInterference += ((strPrintText.Length) * ReportHeaderFont.Size) / (rectReportHeader.Width * (ReportHeaderFont.Size - 2)) + 10
            sngYPosInterference += (ReportHeaderFont.GetHeight(EV.Graphics))
            'rectReportHeader.X = rectReportHeader.X * 96 + sngXPositionIn + 5
            'rectReportHeader.X = rectReportHeader.X * 96 + 5
            'rectReportHeader.Y = sngYPositionIn - 5
            'sngXPositionIn = rectReportHeader.X
            'rectReportHeader.Height = rectReportHeader.Height * 96

            If sngYPosInterference >= mintPageFooterYPosotion Then
                If blnIsPageReapate = True Then
                    If blnPageSettingMessage = False Then
                        'Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
                        Application.DoEvents()
                        'cWait = New CWaitCursor
                    End If

                    EV.HasMorePages = False
                    EV.Cancel = True
                    blnFinishInterference = True
                    Return False
                    'Exit Function
                End If

                EV.HasMorePages = True
                blnIsPageReapate = True
                blnFinishInterference = False
                Return True
                'Exit Function

            ElseIf sngYPositionIn >= mintPageFooterYPosotion Then
                If blnIsPageReapate = True Then
                    If blnPageSettingMessage = False Then
                        'Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
                        Application.DoEvents()
                        'cWait = New CWaitCursor
                    End If

                    EV.HasMorePages = False
                    EV.Cancel = True
                    blnFinishInterference = False
                    'Exit Function
                    Return True

                End If

                EV.HasMorePages = True
                blnIsPageReapate = True
                blnFinishInterference = False
                Return True
                'Exit Function
            End If

            strPrintText = ConstSubHeader1
            objBrush = New Pen(mobjReportBrushBlack.Color).Brush

            rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).GetBounds
            ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).Font

            sngYPositionIn += (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 10    'rectReportHeader.Height 
            sngXPositionIn = rectReportHeader.X * 96 + 5
            rectReportHeader.X = sngXPositionIn + 10 'rectReportHeader.X * 96 + sngXPositionIn + 5
            'rectReportHeader.X = rectReportHeader.X * 96 + 5
            rectReportHeader.Y = sngYPositionIn

            'sngXPositionIn = rectReportHeader.X
            rectReportHeader.Height = rectReportHeader.Height * 96
            rectReportHeader.Width = rectReportHeader.Width * 96
            'sngYPositionIn += rectReportHeader.Height

            EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)

            sngYPositionIn += rectReportHeader.Height


            '//----- Details

            strPrintText = CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("INTERFEREN"))
            objBrush = New Pen(mobjReportBrushBlack.Color).Brush

            rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("Label1"), DataDynamics.ActiveReports.Label).GetBounds
            ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("Label1"), DataDynamics.ActiveReports.Label).Font

            'sngYPositionIn += (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 10    'rectReportHeader.Height 
            sngXPositionIn = rectReportHeader.X * 96 + sngXPositionIn + 5
            rectReportHeader.X = sngXPositionIn + 10 'rectReportHeader.X * 96 + sngXPositionIn + 5
            'rectReportHeader.X = rectReportHeader.X * 96 + 5
            rectReportHeader.Y = sngYPositionIn

            'sngXPositionIn = rectReportHeader.X

            'rectReportHeader.Height = rectReportHeader.Height * 96
            'RptHi = rectReportHeader.Height * 96
            rectReportHeader.Height = ((strPrintText.Length) * ReportHeaderFont.Size) / (rectReportHeader.Width * (ReportHeaderFont.Size - 2)) + 10 ' * 96 
            rectReportHeader.Width = rectReportHeader.Width * 96
            'sngYPositionIn += rectReportHeader.Height
            EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)
            sngYPositionIn += rectReportHeader.Height
            '//-----


            blnFinishInterference = True
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
            'If Not cWait Is Nothing Then
            'cWait.Dispose()
            'End If
        End Try
    End Function

    Private Function funcGetCookBookStruct(ByRef DtmElamentInfo As DataTable, ByVal DtElamentDetails As DataTable) As Boolean

        'mElamentInfo.ElamentAbrivation = DtmElamentInfo.Rows.Item(0).Item(0)
        'mDtElamentDetails()


    End Function

#End Region

#Region "Data file Report Procedure"

    Private Function funcDatafileElamentInfo(ByRef EV As PrintPageEventArgs, ByVal sngXPositionIn As Single, ByRef sngYPositionIn As Single, ByVal mintMethodID As Integer, ByVal mintRunNo As Integer) As Boolean
        '=====================================================================
        ' Procedure Name        : funcDatafileElamentInfo
        ' Parameters Passed     : 
        ' Returns               : true or false
        ' Purpose               : To show the Quantitative Information on the report
        ' Description           : 
        '
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : Sunday, Feb 25, 2007
        ' Revisions             : 
        '=====================================================================



        Dim objBrush As Drawing.Brush
        Dim SetStringBold As Boolean
        Static intIsPageReapate As Boolean
        Dim rectReportHeader As Drawing.RectangleF
        Dim ReportHeaderFont As Font
        Dim strELE_Abriv As String
        Dim strELE_Name As String
        Const Const_QuantitativeReportFor As String = "Quantitative Report for"
        Const Const_RunNO As String = "Rune No: "
        Const Const_Analysed As String = "Analysed On :"

        Dim strText As String
        Try

            '    '//----- Added by Sachin Dokhale on 28.09.05
            '    mintPageFooterYPosotion = CInt(PageFooterLineY1)
            '//-----
            'System.Drawing.Printing.PageSettings()
            Dim objARLayoutReport As DataDynamics.ActiveReports.ActiveReport


            objARLayoutReport = mobjARPortrateReport
            objBrush = New Pen(mobjReportBrushBlack.Color).Brush
            'objBrush = New Pen(mobjReportBrushRed.Color).Brush


            rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("lblElement"), DataDynamics.ActiveReports.Label).GetBounds
            ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("lblElement"), DataDynamics.ActiveReports.Label).Font

            'strELE_Name = CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("ELE_NAME"))

            rectReportHeader.X = 100 '((objARLayoutReport.PageSettings.PaperWidth * 100) / 2) - ((Len(strELE_Name) * ReportHeaderFont.SizeInPoints) / 2)   'rectReportHeader.X * 96 + sngXPositionIn
            rectReportHeader.Y = rectReportHeader.Y * 96 + sngYPositionIn
            rectReportHeader.Height = rectReportHeader.Height * 96
            rectReportHeader.Width = (rectReportHeader.Width * 72) * Const_QuantitativeReportFor.Length  'rectReportHeader.Width * 96 

            EV.Graphics.DrawString(Const_QuantitativeReportFor, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)


            'sngYPositionIn += rectReportHeader.Height + (lineSpacing + printFont.GetHeight(EV.Graphics))
            rectReportHeader.X = ((objARLayoutReport.PageSettings.PaperWidth * 100) / 2) - ((Len(strELE_Name) * ReportHeaderFont.SizeInPoints) / 2)   'rectReportHeader.X * 96 + sngXPositionIn
            rectReportHeader.Y = sngYPositionIn
            rectReportHeader.Height = rectReportHeader.Height * 96
            rectReportHeader.Width = rectReportHeader.Width * 96

            'strELE_Name = "      " & CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("ELE_NAME"))
            strELE_Name = "      " & gobjMethodCollection.item(mintMethodID).InstrumentCondition.ElementID ' QuantitativeDataCollection(mintRunNo).  

            'mintMethodID()

            EV.Graphics.DrawString(strELE_Name, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)

            rectReportHeader.X = ((objARLayoutReport.PageSettings.PaperWidth * 100) / 2) - ((Len(strELE_Name) * ReportHeaderFont.SizeInPoints) / 4)   'rectReportHeader.X * 96 + sngXPositionIn
            rectReportHeader.Y = sngYPositionIn
            rectReportHeader.Height = rectReportHeader.Height * 96
            rectReportHeader.Width = rectReportHeader.Width * 96

            strText = Const_RunNO & CStr(objDtDatafileRpt.Rows.Item(0).Item("RUNNO"))

            EV.Graphics.DrawString(strText, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)

            rectReportHeader.X = ((objARLayoutReport.PageSettings.PaperWidth * 100) / 2) - ((Len(strELE_Name) * ReportHeaderFont.SizeInPoints) / 4)   'rectReportHeader.X * 96 + sngXPositionIn
            rectReportHeader.Y = sngYPositionIn
            rectReportHeader.Height = rectReportHeader.Height * 96
            rectReportHeader.Width = rectReportHeader.Width * 96

            strText = Const_Analysed  'CStr(objDtDatafileRpt.Rows.Item(0).Item("RUNNO"))

            EV.Graphics.DrawString(strText, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)

            rectReportHeader.X = ((objARLayoutReport.PageSettings.PaperWidth * 100) / 2) - ((Len(strELE_Name) * ReportHeaderFont.SizeInPoints) / 4)   'rectReportHeader.X * 96 + sngXPositionIn
            rectReportHeader.Y = sngYPositionIn
            rectReportHeader.Height = rectReportHeader.Height * 96
            rectReportHeader.Width = rectReportHeader.Width * 96

            strText = Const_Analysed  'CStr(objDtDatafileRpt.Rows.Item(0).Item("RUNNO"))

            EV.Graphics.DrawString(strText, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)

            rectReportHeader.X = ((objARLayoutReport.PageSettings.PaperWidth * 100) / 2) - ((Len(strELE_Name) * ReportHeaderFont.SizeInPoints) / 4)   'rectReportHeader.X * 96 + sngXPositionIn
            rectReportHeader.Y = sngYPositionIn
            rectReportHeader.Height = rectReportHeader.Height * 96
            rectReportHeader.Width = rectReportHeader.Width * 96

            strText = CStr(objDtDatafileRpt.Rows.Item(0).Item("ANALYSEDON"))
            EV.Graphics.DrawString(strText, ReportHeaderFont, objBrush, rectReportHeader, New StringFormat)

            sngYPositionIn += (lineSpacing + printFont.GetHeight(EV.Graphics))

            blnFinishElamentInfo = True
            Return True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
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

    Private Sub subDatafileInitInfo(ByRef ev As System.Drawing.Printing.PrintPageEventArgs, _
                                ByVal rectGrid As Drawing.RectangleF, _
                                ByVal objDtReportDataTableIn As DataTable, _
                                ByVal intReportTypeIn As enumReportType, _
                                ByRef YPosition As Single)
        '=====================================================================
        ' Procedure Name        :   subDatafileInitInfo
        ' Parameters Passed     :   rectGrid is Drawing.RectangleF, objDtReportDataTableIn As DataTable
        '                       :   intReportTypeIn is the  enumReportType data type
        ' Parameters Affected   :   ev is the System.Drawing.Printing.PrintPageEventArgs
        '                       :   YPosition is the Y axis postion of the report
        ' Returns               :   None
        ' Purpose               :   Print the data of report data file header
        ' Description           :   Print the data of report data file header
        ' Assumptions           :   None
        ' Dependencies          :   None
        ' Author                :   Sachin Dokhale
        ' Created               : 
        ' Revisions             : 
        '=====================================================================

        Dim blnIsLeft As Boolean = False
        Dim ReportHeader1Font As Font
        Dim ReportHeaderFont As Font
        Dim ReportText1Font As Font
        Dim ReportHeader2Font As Font
        Dim ReportText2Font As Font
        Dim sngColumnWidth As Single
        Dim r As Rectangle
        Dim rf As Drawing.RectangleF
        Dim sizStringSize As SizeF
        Dim newStringFormat As New StringFormat
        Dim intLineHeigt As Integer
        Dim clrMangeta As Drawing.Color
        Dim FontColor As Drawing.Color
        Dim i, j, w, l As Integer
        Dim leftMargin As Single = rectGrid.Left
        Dim rowHeight As Integer
        Dim hfBrush As New SolidBrush(Color.Black)

        Try
            rectGrid.Y = YPosition
            Dim topMargin As Single = rectGrid.Top
            l = CInt(topMargin)
            'l += headerHeight

            w = CInt(leftMargin)
            If Not (objDtReportDataTableIn.TableName = "Quantitative Report") Then
                Exit Sub
            End If
            ReportText1Font = CType(mobjARPortrateReport.Sections("GrpHdrRepeatResults").Controls("TxtAbso"), DataDynamics.ActiveReports.Label).Font
            ReportHeaderFont = CType(mobjARPortrateReport.Sections("GrpHdrDatafile").Controls("lblHeader"), DataDynamics.ActiveReports.Label).Font
            ReportHeader1Font = CType(mobjARPortrateReport.Sections("GrpHdrRepeatResults").Controls("Abso"), DataDynamics.ActiveReports.Label).Font
            ReportHeader2Font = CType(mobjARPortrateReport.Sections("GrpHdrRepeatResults").Controls("Abso"), DataDynamics.ActiveReports.Label).Font
            ReportText2Font = CType(mobjARPortrateReport.Sections("GrpHdrRepeatResults").Controls("TxtAbso"), DataDynamics.ActiveReports.Label).Font


            'rowHeight = CInt(ReportText1Font.GetHeight(ev.Graphics)) + 1
            rowHeight = CInt(ReportHeaderFont.GetHeight(ev.Graphics)) + 1
            l += rowHeight
            'If Not objDtReportDataTableIn.Rows.Item(0).Item(0).ToString = "" Then
            If Not objDtReportDataTableIn.Columns(j).Caption = "" Then

                'sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, j).Width
                sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 4).Width
                w = sngColumnWidth / 2
                r = New Rectangle(w, l, CInt(sngColumnWidth), rowHeight)
                rf = New Drawing.RectangleF(w, l + 2, r.Width, r.Height)
                ev.Graphics.DrawString(objDtReportDataTableIn.Columns(j).Caption, ReportHeaderFont, hfBrush, rf)
                hfBrush.Color = clrMangeta.Black
                l += r.Height + 10

                sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 4).Width
                w = CInt(leftMargin)
                r = New Rectangle(w, l, CInt(sngColumnWidth), rowHeight)
                rf = New Drawing.RectangleF(w, l + 2, r.Width, r.Height)
                ev.Graphics.DrawString(objDtReportDataTableIn.Columns(1).Caption, ReportHeaderFont, hfBrush, rf)

                If Not objDtReportDataTableIn.Rows.Item(0).Item(1).ToString = "" Then

                    r = New Rectangle(w + 200, l, CInt(sngColumnWidth - 30), rowHeight)
                    rf = New Drawing.RectangleF(w + 205, l + 2, r.Width, r.Height)

                    ev.Graphics.DrawString(objDtReportDataTableIn.Rows.Item(0).Item(1).ToString, ReportHeaderFont, hfBrush, rf)
                    hfBrush.Color = clrMangeta.Black
                End If
                l += r.Height + 10
            End If

            j = 2

            Do While j <= objDtReportDataTableIn.Columns.Count - 1


                If IsNumeric(objDtReportDataTableIn.Rows(i).Item(j).ToString()) Then

                    If IsNothing(ColoumnFormat) Then
                        ColoumnFormat = New StringFormat
                    End If
                    If SetTableColoumnFormat = True Then
                        ColoumnFormat.Alignment = StringAlignment.Near
                    End If
                Else
                    If IsNothing(ColoumnFormat) Then
                        ColoumnFormat = New StringFormat
                    End If
                    If SetTableColoumnFormat = True Then
                        ColoumnFormat.Alignment = StringAlignment.Near
                    End If
                End If

                CurRow = 1
                newStringFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft
                newStringFormat.Alignment = StringAlignment.Near

                If blnIsLeft = False Then


                    sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 0).Width
                    sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Columns(j).Caption, ReportHeader1Font, CInt(sngColumnWidth), newStringFormat)
                    rowHeight = CInt(sizStringSize.Height)

                    r = New Rectangle(w, l, CInt(sngColumnWidth - 3), rowHeight)
                    rf = New Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height)

                    ev.Graphics.DrawString(objDtReportDataTableIn.Columns(j).Caption, ReportHeader1Font, hfBrush, rf)
                    intLineHeigt = l + r.Height

                    'sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 1).Width
                    sngColumnWidth = 200
                    If Not (objDtReportDataTableIn.Rows.Item(i).Item(j).ToString = "") Then
                        sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Rows.Item(i).Item(j).ToString, ReportText1Font, CInt(sngColumnWidth), newStringFormat)
                        rowHeight = CInt(sizStringSize.Height)

                        r = New Rectangle(w, l, CInt(sngColumnWidth - 3), rowHeight)
                        'w += CInt(CType(mobjARPortrateReport.Sections("GrpHdrRepeatResults").Controls("TxtStdSampName"), DataDynamics.ActiveReports.Label).Left) * 72
                        w += CInt(CType(mobjARPortrateReport.Sections("GrpHdrRepeatResults").Controls("TxtAbso"), DataDynamics.ActiveReports.Label).Left) * 72

                        rf = New Drawing.RectangleF(w, l + 2, r.Width, r.Height)

                        ev.Graphics.DrawString(objDtReportDataTableIn.Rows.Item(i).Item(j).ToString, ReportText1Font, Drawing.Brushes.Black, rf, ColoumnFormat)
                    End If
                    blnIsLeft = True
                Else
                    sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 2).Width
                    'sngColumnWidth = 200
                    sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Columns(j).Caption, ReportHeader2Font, CInt(sngColumnWidth), newStringFormat)
                    rowHeight = CInt(sizStringSize.Height)

                    w += CInt(CType(mobjARPortrateReport.Sections("GrpHdrDatafile").Controls("TxtLable2"), DataDynamics.ActiveReports.Label).Left * 72) - 100
                    r = New Rectangle(w, l, CInt(sngColumnWidth - 3), rowHeight)

                    rf = New Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height)
                    blnIsLeft = False
                    ev.Graphics.DrawString(objDtReportDataTableIn.Columns(j).Caption, ReportHeader2Font, hfBrush, rf)
                    If Not (objDtReportDataTableIn.Rows.Item(i).Item(j).ToString = "") Then
                        'sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 3).Width
                        sngColumnWidth = 200
                        sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Rows.Item(i).Item(j).ToString, ReportText2Font, CInt(sngColumnWidth), newStringFormat)
                        rowHeight = CInt(sizStringSize.Height)
                        r = New Rectangle(w, l, CInt(sngColumnWidth - 3), rowHeight)
                        rf = New Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height)

                        w += CInt(CType(mobjARPortrateReport.Sections("GrpHdrDatafile").Controls("Txt2"), DataDynamics.ActiveReports.Label).Left) * 72 - 300
                        rf = New Drawing.RectangleF(w, l + 2, r.Width, r.Height)

                        ev.Graphics.DrawString(objDtReportDataTableIn.Rows.Item(i).Item(j).ToString, ReportText2Font, Drawing.Brushes.Black, rf, ColoumnFormat)
                    End If
                    '
                    w = CInt(leftMargin)
                    l += r.Height
                End If
continuefor2:
                j += 1
            Loop
            l += r.Height
            'Draw line after report header detalis
            ev.Graphics.DrawLine(New Pen(Color.Black), leftMargin, l, leftMargin + rectGrid.Width, l)

            YPosition = l
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

#End Region

End Class

Public Class clsReportHeaderFormat
    '*********************************************************************
    ' File Header       : clsReportHeaderFormat 
    ' File Name 		: clsPrintDocument.vb
    ' Author			: Sachin Dokhale
    ' Date/Time			: 22 Jan 07
    ' Description		: To set the Header format
    '**********************************************************************

#Region " Private Variable"
    Dim m_Alignment As System.Drawing.ContentAlignment
#End Region

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        'InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        '//----- Set default initialise the of Report
        '//-----
        m_Alignment = ContentAlignment.MiddleLeft
    End Sub

    Public Property Alignment() As System.Drawing.ContentAlignment
        Get
            Alignment = m_Alignment
        End Get
        Set(ByVal Value As System.Drawing.ContentAlignment)
            m_Alignment = Value
        End Set
    End Property



End Class
