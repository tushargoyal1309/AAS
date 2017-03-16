Imports AAS203Library.Method
Imports System.Drawing


Public Class clsDataFileReport

#Region " Private Class Member Variables "

    Private mintSelectedMethodID As Integer
    Private mlngSelectedRunNumber As Long
    Private mlngSelectedRunIndex As Long
    Private mFontStyle As System.Drawing.Font
    Dim intMethodsIdxId As Integer
#End Region

#Region " Public Properties "

    Public Property MethodID() As Integer
        Get
            Return mintSelectedMethodID
        End Get
        Set(ByVal Value As Integer)
            mintSelectedMethodID = Value
        End Set
    End Property

    Public Property RunNumber() As Long
        Get
            Return mlngSelectedRunNumber
        End Get
        Set(ByVal Value As Long)
            mlngSelectedRunNumber = Value
        End Set
    End Property

    Public Property DefaultFont() As System.Drawing.Font
        Get
            Return mFontStyle
        End Get
        Set(ByVal Value As System.Drawing.Font)
            mFontStyle = Value
        End Set
    End Property

#End Region

#Region " Public Functions "

    Public Function funcDatafilePrint() As Boolean
        '=====================================================================
        ' Procedure Name        : funcDatafilePrint
        ' Parameters Passed     : None
        ' Returns               : return true if success
        ' Purpose               : print data file report of entire analysis
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 
        ' Revisions             : 
        '=====================================================================

        Dim objclsPrintDocument As New clsPrintDocument
        Dim objDtImagesList As New DataTable
        Dim arrGraphControlsList As New ArrayList
        Dim objstructReportFormatIn As New clsReportingMode.structReportFormat
        Dim strPageHeader As New clsPrintDocument.struHeaderString  ' = ""    '" Test Page Header "
        Dim strPageFooter As New clsPrintDocument.struHeaderString  ' = ""    '" Test Page Footer "
        Dim strPageText As String = "   "
        Dim objarrMoreTextListData As New ArrayList
        Dim objarrMoreTabularData As New ArrayList
        Dim blnGetHeaderFooter As Boolean
        Try
            'Seting Report format and text
            strPageHeader.TextString = ""
            strPageHeader.TextFormat = New clsReportHeaderFormat
            strPageHeader.TextFormat.Alignment = ContentAlignment.MiddleLeft

            objstructReportFormatIn.PageBottomMargin = 0.5
            objstructReportFormatIn.PageLeftMargin = 0.5
            objstructReportFormatIn.PageTopMargin = 0.5
            If funcSetDatafileTable(objarrMoreTabularData, objarrMoreTextListData, blnGetHeaderFooter) = False Then
                Return False
            End If
            If blnGetHeaderFooter = True Then
                strPageHeader.TextString = ""
                strPageFooter.TextString = ""
            End If
            objclsPrintDocument = funcSetPrintDocument(objstructReportFormatIn, strPageHeader, strPageText,
                        blnGetHeaderFooter, arrGraphControlsList, objarrMoreTabularData,
                       objDtImagesList, objarrMoreTextListData, clsPrintDocument.enumReportType.DataFile)

            ' See the print preview
            If Not IsNothing(objclsPrintDocument) = True Then
                If objclsPrintDocument.PrintPreview() = True Then
                    'If objclsPrintDocument.PrintToPrinter() = True Then
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
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcDatafilePrintForMethod() As Boolean
        '=====================================================================
        ' Procedure Name        : funcDatafilePrint
        ' Parameters Passed     : None
        ' Returns               : return true if success
        ' Purpose               : print data file report from method
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Pankaj bamb
        ' Created               : 21Feb08
        ' Revisions             : 
        '=====================================================================

        Dim objclsPrintDocument As New clsPrintDocument
        Dim objDtImagesList As New DataTable
        Dim arrGraphControlsList As New ArrayList
        Dim objstructReportFormatIn As New clsReportingMode.structReportFormat
        Dim strPageHeader As New clsPrintDocument.struHeaderString  ' = ""    '" Test Page Header "
        Dim strPageFooter As New clsPrintDocument.struHeaderString  ' = ""    '" Test Page Footer "
        Dim strPageText As String = "   "
        Dim objarrMoreTextListData As New ArrayList
        Dim objarrMoreTabularData As New ArrayList
        Dim blnGetHeaderFooter As Boolean
        Try
            'Seting Report format and text
            strPageHeader.TextString = ""
            strPageHeader.TextFormat = New clsReportHeaderFormat
            strPageHeader.TextFormat.Alignment = ContentAlignment.MiddleLeft

            objstructReportFormatIn.PageBottomMargin = 0.5
            objstructReportFormatIn.PageLeftMargin = 0.5
            objstructReportFormatIn.PageTopMargin = 0.5
            If funcSetDatafileTableForMethod(objarrMoreTabularData, objarrMoreTextListData, blnGetHeaderFooter) = False Then
                Return False
            End If
            If blnGetHeaderFooter = True Then
                strPageHeader.TextString = ""
                strPageFooter.TextString = ""
            End If
            objclsPrintDocument = funcSetPrintDocument(objstructReportFormatIn, strPageHeader, strPageText,
                        blnGetHeaderFooter, arrGraphControlsList, objarrMoreTabularData,
                       objDtImagesList, objarrMoreTextListData, clsPrintDocument.enumReportType.DataFile)

            ' See the print preview
            If Not IsNothing(objclsPrintDocument) = True Then
                If objclsPrintDocument.PrintPreview() = True Then
                    'If objclsPrintDocument.PrintToPrinter() = True Then
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
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcDatafileExport(ByVal objDataFileReportParameterIn As AAS203Library.Method.clsReportParameters) As Boolean
        '=====================================================================
        ' Procedure Name        : funcDatafileExport
        ' Parameters Passed     : AAS203Library.Method.clsReportParameters
        ' Returns               : Boolean True if success
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 18.07.07
        ' Revisions             : 
        '=====================================================================

        Dim objclsPrintDocument As New clsPrintDocument
        Dim objDtImagesList As New DataTable
        Dim arrGraphControlsList As New ArrayList
        Dim objstructReportFormatIn As New clsReportingMode.structReportFormat
        Dim strPageHeader As New clsPrintDocument.struHeaderString  ' = ""    '" Test Page Header "
        Dim strPageFooter As New clsPrintDocument.struHeaderString
        Dim strPageText As String = "   "
        Dim objarrMoreTextListData As New ArrayList
        Dim objarrMoreTabularData As New ArrayList
        Dim GetHeaderFooter As Boolean

        Try
            '--- Seting Report format and text

            objstructReportFormatIn.PageBottomMargin = 0.5
            objstructReportFormatIn.PageLeftMargin = 0.5
            objstructReportFormatIn.PageTopMargin = 0.5
            If funcSetDatafileTable(objarrMoreTabularData, objarrMoreTextListData) = False Then
                Return False
            End If

            objclsPrintDocument = funcSetPrintDocument(objstructReportFormatIn, strPageHeader, strPageText,
            GetHeaderFooter, arrGraphControlsList, objarrMoreTabularData,
            objDtImagesList, objarrMoreTextListData, clsPrintDocument.enumReportType.DataFile)

            GetHeaderFooter = gobjMethodCollection.item(intMethodsIdxId).ReportParameters.IsReportHeaderAndFooter
            If GetHeaderFooter = True Then
                strPageHeader.TextString = ""
                strPageHeader.TextFormat = New clsReportHeaderFormat
                strPageHeader.TextFormat.Alignment = ContentAlignment.MiddleLeft
                strPageFooter.TextString = ""
                strPageFooter.TextFormat = New clsReportHeaderFormat
                strPageFooter.TextFormat.Alignment = ContentAlignment.MiddleCenter

                strPageHeader.TextString = gobjMethodCollection.item(intMethodsIdxId).ReportParameters.ReportHeader
                strPageFooter.TextString = gobjMethodCollection.item(intMethodsIdxId).ReportParameters.ReportFooter
                objclsPrintDocument.PageHeader = strPageHeader
                objclsPrintDocument.ReportFooter = strPageFooter
            End If

            ' Send the data report to the export option
            If Not IsNothing(objclsPrintDocument) = True Then
                objclsPrintDocument.DataFileReportParameter = objDataFileReportParameterIn
                If objclsPrintDocument.SendExportData() = True Then
                    'If objclsPrintDocument.PrintToPrinter() = True Then
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
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcDatafileExportForMethod(ByVal objDataFileReportParameterIn As AAS203Library.Method.clsReportParameters) As Boolean
        '=====================================================================
        ' Procedure Name        : funcDatafileExportforMethod
        ' Parameters Passed     : AAS203Library.Method.clsReportParameters
        ' Returns               : Boolean True if success
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Pankaj
        ' Created               : 21.02.08
        ' Revisions             : 
        '=====================================================================

        Dim objclsPrintDocument As New clsPrintDocument
        Dim objDtImagesList As New DataTable
        Dim arrGraphControlsList As New ArrayList
        Dim objstructReportFormatIn As New clsReportingMode.structReportFormat
        Dim strPageHeader As New clsPrintDocument.struHeaderString  ' = ""    '" Test Page Header "
        Dim strPageFooter As New clsPrintDocument.struHeaderString
        Dim strPageText As String = "   "
        Dim objarrMoreTextListData As New ArrayList
        Dim objarrMoreTabularData As New ArrayList
        Dim GetHeaderFooter As Boolean

        Try
            '--- Seting Report format and text

            objstructReportFormatIn.PageBottomMargin = 0.5
            objstructReportFormatIn.PageLeftMargin = 0.5
            objstructReportFormatIn.PageTopMargin = 0.5
            If funcSetDatafileTableForMethod(objarrMoreTabularData, objarrMoreTextListData) = False Then
                Return False
            End If

            objclsPrintDocument = funcSetPrintDocument(objstructReportFormatIn, strPageHeader, strPageText,
            GetHeaderFooter, arrGraphControlsList, objarrMoreTabularData,
            objDtImagesList, objarrMoreTextListData, clsPrintDocument.enumReportType.DataFile)

            GetHeaderFooter = gobjMethodCollection.item(intMethodsIdxId).ReportParameters.IsReportHeaderAndFooter
            If GetHeaderFooter = True Then
                strPageHeader.TextString = ""
                strPageHeader.TextFormat = New clsReportHeaderFormat
                strPageHeader.TextFormat.Alignment = ContentAlignment.MiddleLeft
                strPageFooter.TextString = ""
                strPageFooter.TextFormat = New clsReportHeaderFormat
                strPageFooter.TextFormat.Alignment = ContentAlignment.MiddleCenter

                strPageHeader.TextString = gobjMethodCollection.item(intMethodsIdxId).ReportParameters.ReportHeader
                strPageFooter.TextString = gobjMethodCollection.item(intMethodsIdxId).ReportParameters.ReportFooter
                objclsPrintDocument.PageHeader = strPageHeader
                objclsPrintDocument.ReportFooter = strPageFooter
            End If

            ' Send the data report to the export option
            If Not IsNothing(objclsPrintDocument) = True Then
                objclsPrintDocument.DataFileReportParameter = objDataFileReportParameterIn
                If objclsPrintDocument.SendExportData() = True Then
                    'If objclsPrintDocument.PrintToPrinter() = True Then
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
            '---------------------------------------------------------
        End Try
    End Function




    Public Function funcStandardGraphPrint(ByVal PrintGraph As AAS203.AASGraph, ByVal strEquation As String, ByVal mobjclsMethod As clsMethod) As Boolean
        '=====================================================================
        ' Procedure Name        : funcStandardGraphPrint
        ' Parameters Passed     : AAS203.AASGraph, strEquation as String,clsMethod
        ' Returns               : Boolean True if success
        ' Purpose               : 
        ' Description           : Print the Stadard Graph
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.02.07
        ' Revisions             : 1
        '=====================================================================

        Dim objclsPrintDocument As New clsPrintDocument
        Dim objDtImagesList As New DataTable
        Dim arrGraphControlsList As New ArrayList
        Dim objstructReportFormatIn As New clsReportingMode.structReportFormat
        Dim strPageHeader As New clsPrintDocument.struHeaderString  ' = ""    '" Test Page Header "
        Dim strPageText As String = "   "
        Dim objarrMoreTextListData As New ArrayList
        Dim objarrMoreTabularData As New ArrayList
        Dim DtStdSampleData As DataTable
        Dim DtReportData As DataTable
        Dim objDtElements As DataTable
        Dim intInstID As Integer
        Dim intCount As Integer
        Dim strElementName As String
        Dim dtRow As DataRow
        Dim GetHeaderFooter As Boolean
        Dim intStdUsedIndex As Integer
        Dim blnFoundStd As Boolean = False
        Dim intCounter As Integer
        Dim TmpFont As Font
        Try
            '--- Seting Report format and text
            strPageHeader.TextString = ""
            strPageHeader.TextFormat = New clsReportHeaderFormat
            strPageHeader.TextFormat.Alignment = ContentAlignment.MiddleLeft

            objstructReportFormatIn.PageBottomMargin = 0.5
            objstructReportFormatIn.PageLeftMargin = 0.5
            objstructReportFormatIn.PageTopMargin = 0.5

            Dim ReportHeader1 As New DataColumn("HeaderDefination", GetType(String))
            Dim ReportDtCol01 As New DataColumn("Col01", GetType(String))
            Dim ReportDtCol02 As New DataColumn("Col02", GetType(String))
            Dim ReportDtCol03 As New DataColumn("Col03", GetType(String))

            '--- Search Element ID
            If mobjclsMethod.MethodID = mintSelectedMethodID Then
                intInstID = intCount
            End If

            For intCounter = 0 To mobjclsMethod.QuantitativeDataCollection.Count - 1
                If mobjclsMethod.QuantitativeDataCollection(intCounter).RunNumber = mlngSelectedRunNumber Then
                    mlngSelectedRunIndex = intCounter
                    Exit For
                End If
            Next

            objDtElements = gobjDataAccess.GetCookBookData(mobjclsMethod.InstrumentCondition.ElementID)
            If Not objDtElements Is Nothing Then
                If objDtElements.Rows.Count > 0 Then
                    strElementName = objDtElements.Rows(0).Item(ConstColumnElementName)
                End If
                objDtElements = Nothing
            End If



            DtReportData = New DataTable
            DtReportData.TableName = "Standard Graph "

            DtReportData.Columns.Add(ReportHeader1)
            DtReportData.Columns.Item(0).Caption = "Standard Graph Report"

            DtReportData.Columns.Add(ReportDtCol02)
            DtReportData.Columns.Item(1).Caption = "Element Name "

            DtReportData.Columns.Add(ReportDtCol01)
            DtReportData.Columns.Item(2).Caption = "Run No: "

            DtReportData.Columns.Add(ReportDtCol03)
            DtReportData.Columns.Item(3).Caption = "Analysed On"

            dtRow = DtReportData.NewRow()

            dtRow(1) = strElementName
            dtRow(2) = CStr(mobjclsMethod.QuantitativeDataCollection(mlngSelectedRunIndex).RunNumber)     '  ""

            'code added by ; dinesh wagh on 24.2.2010
            'Without disturbing main code if in iqoqpq then.
            '-----------------------------------------------------------
            If IsInIQOQPQ Then
                dtRow(3) = CStr(Format(mobjclsMethod.AnalysisParameters.Analysis_Date, "dd-MMM-yyyy hh:mm tt"))
            Else
                '-----------------------------------------------------------------------------
                dtRow(3) = CStr(Format(mobjclsMethod.DateOfLastUse, "dd-MMM-yyyy hh:mm tt"))   '  ""
            End If



            DtReportData.Rows.Add(dtRow)
            Call objarrMoreTextListData.Add(DtReportData)

            strPageText = strEquation
            '//**********

            For intStdUsedIndex = 0 To mobjclsMethod.QuantitativeDataCollection.Item(mlngSelectedRunIndex).StandardDataCollection.Count - 1
                If mobjclsMethod.QuantitativeDataCollection.Item(mlngSelectedRunIndex).StandardDataCollection(intStdUsedIndex).Used = True Then
                    blnFoundStd = True
                    Exit For
                End If
            Next
            'Pankaj Uncomment on 25 Aug 07
            If blnFoundStd = True Then
                If mobjclsMethod.QuantitativeDataCollection.Item(mlngSelectedRunIndex).StandardDataCollection.Count > 0 Then


                    Dim StdSampleDtCol01 As New DataColumn("Col01", GetType(String))
                    Dim StdSampleDtCol02 As New DataColumn("Col02", GetType(String))
                    Dim StdSampleDtCol03 As New DataColumn("Col03", GetType(String))
                    Dim StdSampleDtCol04 As New DataColumn("Col04", GetType(String))
                    DtStdSampleData = New DataTable

                    DtStdSampleData.Columns.Add(StdSampleDtCol01)
                    DtStdSampleData.Columns.Item(0).Caption = "Std. Name"

                    DtStdSampleData.Columns.Add(StdSampleDtCol02)
                    '//----- Added by Sachin Dokhale on 9.09.07
                    'DtStdSampleData.Columns.Item(1).Caption = "Abs"
                    Select Case mobjclsMethod.OperationMode

                        Case EnumOperationMode.MODE_EMMISSION
                            DtStdSampleData.Columns.Item(1).Caption = "%E"
                        Case Else
                            DtStdSampleData.Columns.Item(1).Caption = "Abs"
                    End Select
                    '//-----

                    DtStdSampleData.Columns.Add(StdSampleDtCol03)

                    '---commented on 27.03.09
                    '''DtStdSampleData.Columns.Item(2).Caption = "Conc. (ppm)"
                    '-----------

                    '---written on 27.03.09
                    If mobjclsMethod.QuantitativeDataCollection.Item(mlngSelectedRunIndex).AnalysisParameters.Unit = enumUnit.PPB Then
                        DtStdSampleData.Columns.Item(2).Caption = "Conc. (ppb)"
                    Else
                        DtStdSampleData.Columns.Item(2).Caption = "Conc. (ppm)"
                    End If
                    '---------------

                    DtStdSampleData.Columns.Add(StdSampleDtCol04)
                    DtStdSampleData.Columns.Item(3).Caption = "Cons. in Unit"
                    intCount = 0

                    Do While intCount < mobjclsMethod.QuantitativeDataCollection.Item(mlngSelectedRunIndex).StandardDataCollection.Count
                        If mobjclsMethod.QuantitativeDataCollection.Item(mlngSelectedRunIndex).StandardDataCollection(intCount).Used = True Then
                            dtRow = DtStdSampleData.NewRow()
                            dtRow(0) = CStr(mobjclsMethod.QuantitativeDataCollection.Item(mlngSelectedRunIndex).StandardDataCollection.item(intCount).StdName)
                            'dtRow(1) = CStr(Format(mobjclsMethod.QuantitativeDataCollection.Item(mlngSelectedRunIndex).StandardDataCollection.item(intCount).Abs, "###0.000"))
                            Select Case mobjclsMethod.OperationMode
                                Case EnumOperationMode.MODE_EMMISSION
                                    dtRow(1) = CStr(Format(mobjclsMethod.QuantitativeDataCollection.Item(mlngSelectedRunIndex).StandardDataCollection.item(intCount).Abs, "###0."))
                                Case Else
                                    dtRow(1) = CStr(Format(mobjclsMethod.QuantitativeDataCollection.Item(mlngSelectedRunIndex).StandardDataCollection.item(intCount).Abs, "###0.000"))
                            End Select

                            dtRow(2) = CStr(Format(mobjclsMethod.QuantitativeDataCollection.Item(mlngSelectedRunIndex).StandardDataCollection.item(intCount).Concentration, "####0.000"))
                            dtRow(3) = CStr(Format(mobjclsMethod.QuantitativeDataCollection.Item(mlngSelectedRunIndex).StandardDataCollection.item(intCount).Concentration, "###0.000"))
                            DtStdSampleData.Rows.Add(dtRow)
                        End If
                        intCount += 1
                    Loop
                    Call objarrMoreTabularData.Add(DtStdSampleData)
                End If
            End If
            'End pankaj
            arrGraphControlsList = New ArrayList

            arrGraphControlsList.Add(PrintGraph)
            TmpFont = Me.DefaultFont
            Me.DefaultFont = New Font(Me.DefaultFont.Name, 10, FontStyle.Regular)
            objclsPrintDocument = funcSetPrintDocument(objstructReportFormatIn, strPageHeader, strPageText,
                       GetHeaderFooter, arrGraphControlsList, objarrMoreTabularData,
                       objDtImagesList, objarrMoreTextListData, clsPrintDocument.enumReportType.StadardGraph)
            ' See the print preview
            If Not IsNothing(objclsPrintDocument) = True Then
                If objclsPrintDocument.PrintPreview() = True Then
                    'If objclsPrintDocument.PrintToPrinter() = True Then
                    objclsPrintDocument.Dispose()
                    objclsPrintDocument = Nothing
                End If
            End If
            Me.DefaultFont = TmpFont
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

            If Not (objDtElements Is Nothing) Then
                objDtElements = Nothing
            End If
            If Not (DtReportData Is Nothing) Then
                DtReportData = Nothing
            End If
            If Not (DtStdSampleData Is Nothing) Then
                DtStdSampleData = Nothing
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcSampleGraphPrint(ByVal PrintGraph As AAS203.AASGraph, ByVal strEquation As String, ByVal mobjclsMethod As clsMethod) As Boolean
        '=====================================================================
        ' Procedure Name        : funcSampleGraphPrint
        ' Parameters Passed     : AAS203.AASGraph, strEquation as String,clsMethod
        ' Returns               : Return if success
        ' Purpose               : Print the report of the Sample graph
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 
        ' Revisions             : 
        '=====================================================================

        Dim objclsPrintDocument As New clsPrintDocument
        Dim objDtImagesList As New DataTable
        Dim arrGraphControlsList As New ArrayList
        Dim objstructReportFormatIn As New clsReportingMode.structReportFormat
        Dim strPageHeader As New clsPrintDocument.struHeaderString  ' = ""    '" Test Page Header "
        Dim strPageText As String = "   "
        Dim objarrMoreTextListData As New ArrayList
        Dim objarrMoreTabularData As New ArrayList
        Dim objDtElements As DataTable
        Dim DtReportData As DataTable
        Dim intCount As Integer
        Dim dtRow As DataRow
        Dim strElementName As String
        Dim intInstID As Integer
        Dim GetHeaderFooter As Boolean
        Dim intCounter As Integer
        Dim intStdUsedIndex As Integer
        Dim blnFoundStd As Boolean = False
        Dim TmpFont As Font
        Try
            'Seting Report format and text
            strPageHeader.TextString = ""
            strPageHeader.TextFormat = New clsReportHeaderFormat
            strPageHeader.TextFormat.Alignment = ContentAlignment.MiddleLeft

            objstructReportFormatIn.PageBottomMargin = 0.5
            objstructReportFormatIn.PageLeftMargin = 0.5
            objstructReportFormatIn.PageTopMargin = 0.5

            Dim ReportHeader1 As New DataColumn("HeaderDefination", GetType(String))
            Dim ReportDtCol01 As New DataColumn("Col01", GetType(String))
            Dim ReportDtCol02 As New DataColumn("Col02", GetType(String))
            Dim ReportDtCol03 As New DataColumn("Col03", GetType(String))

            '//----- Search Element ID
            'For intCount = 0 To gobjMethodCollection.Count - 1
            '    If gobjMethodCollection.item(intCount).MethodID = mintSelectedMethodID Then
            '        'If gobjMethodCollection(intCount).SelectedElementID = gobjMethodCollection(intCount).InstrumentCondition.ElementID Then
            '        intInstID = intCount
            '        Exit For
            '        'End If
            '    End If
            'Next


            For intCounter = 0 To mobjclsMethod.QuantitativeDataCollection.Count - 1
                If mobjclsMethod.QuantitativeDataCollection(intCounter).RunNumber = mlngSelectedRunNumber Then
                    mlngSelectedRunIndex = intCounter
                    Exit For
                End If
            Next


            objDtElements = gobjDataAccess.GetCookBookData(mobjclsMethod.InstrumentCondition.ElementID)
            If Not objDtElements Is Nothing Then
                If objDtElements.Rows.Count > 0 Then
                    strElementName = objDtElements.Rows(0).Item(ConstColumnElementName)
                End If
                objDtElements = Nothing
            End If

            DtReportData = New DataTable
            DtReportData.TableName = "Sample Graph "

            DtReportData.Columns.Add(ReportHeader1)
            DtReportData.Columns.Item(0).Caption = "Sample Graph Report"

            DtReportData.Columns.Add(ReportDtCol02)
            DtReportData.Columns.Item(1).Caption = "Element Name "

            DtReportData.Columns.Add(ReportDtCol01)
            DtReportData.Columns.Item(2).Caption = "Run No: "

            DtReportData.Columns.Add(ReportDtCol03)
            DtReportData.Columns.Item(3).Caption = "Analysed On"

            dtRow = DtReportData.NewRow()

            dtRow(1) = strElementName
            dtRow(2) = CStr(mobjclsMethod.QuantitativeDataCollection(mlngSelectedRunIndex).RunNumber)     '  ""
            dtRow(3) = CStr(Format(mobjclsMethod.DateOfLastUse, "dd-MMM-yyyy hh:mm tt"))   '  ""


            DtReportData.Rows.Add(dtRow)
            Call objarrMoreTextListData.Add(DtReportData)

            strPageText = strEquation
            '//***********


            For intStdUsedIndex = 0 To mobjclsMethod.QuantitativeDataCollection.Item(mlngSelectedRunIndex).SampleDataCollection.Count - 1
                If mobjclsMethod.QuantitativeDataCollection.Item(mlngSelectedRunIndex).SampleDataCollection(intStdUsedIndex).Used = True Then
                    blnFoundStd = True
                    Exit For
                End If
            Next
            arrGraphControlsList = New ArrayList
            arrGraphControlsList.Add(PrintGraph)
            TmpFont = Me.DefaultFont
            Me.DefaultFont = New Font(Me.DefaultFont.Name, 10, FontStyle.Regular)

            objclsPrintDocument = funcSetPrintDocument(objstructReportFormatIn, strPageHeader, strPageText,
                       GetHeaderFooter, arrGraphControlsList, objarrMoreTabularData,
                       objDtImagesList, objarrMoreTextListData, clsPrintDocument.enumReportType.StadardGraph)

            '--- View the print preview
            If Not IsNothing(objclsPrintDocument) = True Then
                If objclsPrintDocument.PrintPreview() = True Then
                    objclsPrintDocument.Dispose()
                    objclsPrintDocument = Nothing
                End If
            End If
            Me.DefaultFont = TmpFont
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
            If Not (objDtElements Is Nothing) Then
                objDtElements = Nothing
            End If
            If Not (DtReportData Is Nothing) Then
                DtReportData = Nothing
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcEditDataRepeatResult(ByVal objclsMethodIn As clsMethod) As Boolean
        '=====================================================================
        ' Procedure Name        : funcEditDataRepeatResult
        ' Parameters Passed     : objclsMethodIn as clsMethod 
        ' Returns               : Boolean Return true if success
        ' Purpose               : Fill the Data to the Print Document
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 03.08.07
        ' Revisions             : 
        '=====================================================================

        Dim objclsPrintDocument As New clsPrintDocument
        Dim objstructReportFormatIn As New clsReportingMode.structReportFormat
        Dim strPageHeader As New clsPrintDocument.struHeaderString  ' = ""    '" Test Page Header "
        Dim strPageText As String = "   "
        Dim objarrMoreTextListData As New ArrayList
        Dim objarrMoreTabularData As New ArrayList
        Dim DtReportData As DataTable
        Dim DtReportData_InitInfo As DataTable
        Dim DtReportDataStatistics As DataTable
        Dim intCount As Integer
        Dim dtRow As DataRow
        Dim intInstID As Integer
        Dim GetHeaderFooter As Boolean
        Dim intCounter As Integer
        Dim intSerNo As Integer = 0
        Dim intStdIdx As Integer
        Dim intSampIdx As Integer
        Dim intAbsRepeat As Integer
        Dim strlblStatistics_1 As String
        Dim strlblStatistics_2 As String
        Dim strAbsRepeat As String
        Dim strConcRepeat As String
        Dim strElementName As String
        Dim objDtElements As DataTable

        '------------------ '---05.03.09
        Dim dblConc As Double
        Dim strConcUnit As String
        Dim intUnit As Integer
        '------------------

        'Print the data of Repeat result
        Try
            '--- Seting Report format and text
            strPageHeader.TextString = "Data Print"
            strPageHeader.TextFormat = New clsReportHeaderFormat
            strPageHeader.TextFormat.Alignment = ContentAlignment.MiddleLeft

            objstructReportFormatIn.PageBottomMargin = 0.5
            objstructReportFormatIn.PageLeftMargin = 0.5
            objstructReportFormatIn.PageTopMargin = 0.5


            '//----- Search Element ID
            'For intCount = 0 To gobjMethodCollection.Count - 1
            '    If gobjMethodCollection.item(intCount).MethodID = mintSelectedMethodID Then
            '        intInstID = intCount
            '        Exit For
            '    End If
            'Next


            'For intCounter = 0 To objclsMethodIn.QuantitativeDataCollection.Count - 1
            '    If objclsMethodIn.QuantitativeDataCollection(intCounter).RunNumber = mlngSelectedRunNumber Then
            '        mlngSelectedRunIndex = intCounter
            '        Exit For
            '    End If
            'Next
            mlngSelectedRunIndex = -1
            intMethodsIdxId = -1
            '//----- Search Element ID
            'objclsMethodIn
            'For intCount = 0 To gobjMethodCollection.Count - 1
            'If gobjMethodCollection.item(intCount).MethodID = mintSelectedMethodID Then
            'intMethodsIdxId = intCount

            'For intCounter = 0 To gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Count - 1
            For intCounter = 0 To objclsMethodIn.QuantitativeDataCollection.Count - 1
                'If gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection(intCounter).RunNumber = mlngSelectedRunNumber Then
                If objclsMethodIn.QuantitativeDataCollection(intCounter).RunNumber = mlngSelectedRunNumber Then
                    mlngSelectedRunIndex = intCounter
                    Exit For
                End If
            Next
            'End If
            'Next

            If mlngSelectedRunIndex = -1 Then
                Return False
            End If


            'With gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection(mlngSelectedRunIndex)
            With objclsMethodIn.QuantitativeDataCollection(mlngSelectedRunIndex)

                ' Set the object for titel " Report" 
                objDtElements = gobjDataAccess.GetCookBookData(objclsMethodIn.InstrumentCondition.ElementID)
                If Not objDtElements Is Nothing Then
                    If objDtElements.Rows.Count > 0 Then
                        strElementName = objDtElements.Rows(0).Item(ConstColumnElementName)
                    End If
                    objDtElements = Nothing
                End If

                Dim ReportHeader_1 As New DataColumn("HeaderDefination", GetType(String))
                Dim ReportHeader_2 As New DataColumn("HeaderDefination1", GetType(String))
                Dim ReportDtCol01 As New DataColumn("Col01", GetType(String))
                Dim ReportDtCol02 As New DataColumn("Col02", GetType(String))

                DtReportData_InitInfo = New DataTable
                DtReportData_InitInfo.TableName = "Quantitative Report"

                DtReportData_InitInfo.Columns.Add(ReportHeader_1)
                DtReportData_InitInfo.Columns.Item(0).Caption = "Repeat & Statistics Print"

                DtReportData_InitInfo.Columns.Add(ReportHeader_2)
                DtReportData_InitInfo.Columns.Item(1).Caption = "Element Name: "

                DtReportData_InitInfo.Columns.Add(ReportDtCol01)
                DtReportData_InitInfo.Columns.Item(2).Caption = "Run No: "

                DtReportData_InitInfo.Columns.Add(ReportDtCol02)
                DtReportData_InitInfo.Columns.Item(3).Caption = "Analysed On"

                dtRow = DtReportData_InitInfo.NewRow()


                dtRow(1) = strElementName   '  ""
                dtRow(2) = objclsMethodIn.QuantitativeDataCollection(intCounter).RunNumber

                'If (gobjMethodCollection.item(intMethodsIdxId).AnalysisParameters.Analysis_Date) > Convert.ToDateTime("1/1/1900") Then
                If (objclsMethodIn.AnalysisParameters.Analysis_Date) > Convert.ToDateTime("1/1/1900") Then

                    dtRow(3) = CStr(Format(.AnalysisParameters.Analysis_Date, "dd-MMM-yyyy hh:mm tt"))       '  ""   ' code commented by : dinesh wagh on 9.4.2009
                    'dtRow(3) = CStr(Format(objclsMethodIn.DateOfLastUse, "dd-MMM-yyyy hh:mm tt")) ' code added by : dinesh wagh on 9.4.2009


                Else
                    dtRow(3) = ""
                End If
                DtReportData_InitInfo.Rows.Add(dtRow)
            End With
            '---


            '//----- Master Table
            Dim ReportHeader1 As New DataColumn("HeaderDefination", GetType(String))
            Dim ReportCol01 As New DataColumn("SerNo", GetType(Integer))
            Dim ReportCol02 As New DataColumn("StdSampSerNo", GetType(String))
            Dim ReportCol03 As New DataColumn("StdSampName", GetType(String))
            Dim ReportCol04 As New DataColumn("Abso", GetType(String))
            Dim ReportCol05 As New DataColumn("Conc", GetType(String))
            Dim ReportCol06 As New DataColumn("StdSamp", GetType(Boolean))
            '//----- Details Table
            Dim ReportDtlHeader1 As New DataColumn("HeaderDefination", GetType(String))
            Dim ReportDtlCol01 As New DataColumn("SerNo", GetType(Integer))
            Dim ReportDtlCol02 As New DataColumn("Observation", GetType(String))
            Dim ReportDtlCol03 As New DataColumn("ProcessMean", GetType(String))
            Dim ReportDtlCol04 As New DataColumn("StdDivation", GetType(String))
            Dim ReportDtlCol05 As New DataColumn("Variance", GetType(String))
            Dim ReportDtlCol06 As New DataColumn("CoeffVariance", GetType(String))
            Dim ReportDtlCol07 As New DataColumn("MinValue", GetType(String))
            Dim ReportDtlCol08 As New DataColumn("MaxValue", GetType(String))
            Dim ReportDtlCol09 As New DataColumn("Range", GetType(String))
            Dim ReportDtlCol10 As New DataColumn("IsAbs", GetType(Boolean))


            'commented on 27.03.09
            '--------------------- '---05.03.09
            ''intUnit = objclsMethodIn.QuantitativeDataCollection(mlngSelectedRunIndex).AnalysisParameters.Unit
            ''If intUnit = 1 Then
            ''    strConcUnit = "Conc. (ppm)"
            ''Else
            ''    strConcUnit = "Conc. (%)"
            ''End If
            '---------------------


            '----written on 27.03.09
            intUnit = objclsMethodIn.QuantitativeDataCollection(mlngSelectedRunIndex).AnalysisParameters.Unit
            If intUnit = enumUnit.PPM Then
                strConcUnit = "Conc. (ppm)"
            ElseIf intUnit = enumUnit.Percent Then
                strConcUnit = "Conc. (ppm)"    '---19.04.09
            ElseIf intUnit = enumUnit.PPB Then
                strConcUnit = "Conc. (ppb)"
            End If
            '----------------


            DtReportData = New DataTable
            DtReportData.TableName = "Master Statics"

            DtReportData.Columns.Add(ReportHeader1)
            DtReportData.Columns.Item(0).Caption = "Master Statistic"

            DtReportData.Columns.Add(ReportCol01)
            DtReportData.Columns.Item(1).Caption = "Ser No."

            DtReportData.Columns.Add(ReportCol02)
            DtReportData.Columns.Item(2).Caption = "Std Samp Ser No."

            DtReportData.Columns.Add(ReportCol03)

            '---commented on 27.03.09
            ''DtReportData.Columns.Item(3).Caption = "Name : "
            '-----

            '---written on 27.03.09
            DtReportData.Columns.Item(3).Caption = strConcUnit & Space(1) & " :"  '---03.06.09
            '-----


            DtReportData.Columns.Add(ReportCol04)
            DtReportData.Columns.Item(4).Caption = "Abs"

            DtReportData.Columns.Add(ReportCol05)
            DtReportData.Columns.Item(5).Caption = "Conc"

            DtReportData.Columns.Add(ReportCol06)
            DtReportData.Columns.Item(6).Caption = "IsStd"

            '//----- Details Table
            DtReportDataStatistics = New DataTable
            DtReportDataStatistics.TableName = "Details Statics"
            DtReportDataStatistics.Columns.Add(ReportDtlHeader1)
            DtReportDataStatistics.Columns.Item(0).Caption = "Details Statistic"

            DtReportDataStatistics.Columns.Add(ReportDtlCol01)
            DtReportDataStatistics.Columns.Item(1).Caption = "Ser No."

            DtReportDataStatistics.Columns.Add(ReportDtlCol02)
            DtReportDataStatistics.Columns.Item(2).Caption = "Valid Observation"

            DtReportDataStatistics.Columns.Add(ReportDtlCol03)
            DtReportDataStatistics.Columns.Item(3).Caption = "Process Mean"

            DtReportDataStatistics.Columns.Add(ReportDtlCol04)
            DtReportDataStatistics.Columns.Item(4).Caption = "Standard Deviation"

            DtReportDataStatistics.Columns.Add(ReportDtlCol05)
            DtReportDataStatistics.Columns.Item(5).Caption = "Variance"

            DtReportDataStatistics.Columns.Add(ReportDtlCol06)
            DtReportDataStatistics.Columns.Item(6).Caption = "Coeff. of  Variance"

            DtReportDataStatistics.Columns.Add(ReportDtlCol07)
            DtReportDataStatistics.Columns.Item(7).Caption = "Minimum Value"

            DtReportDataStatistics.Columns.Add(ReportDtlCol08)
            DtReportDataStatistics.Columns.Item(8).Caption = "Maximun Value"

            DtReportDataStatistics.Columns.Add(ReportDtlCol09)
            DtReportDataStatistics.Columns.Item(9).Caption = "Range"

            DtReportDataStatistics.Columns.Add(ReportDtlCol10)
            DtReportDataStatistics.Columns.Item(10).Caption = "IsAbs"

            If objclsMethodIn.OperationMode = EnumOperationMode.MODE_EMMISSION Then
                strlblStatistics_1 = "Statistics on Emission"
            Else
                strlblStatistics_1 = "Statistics on Abs"
            End If


            strlblStatistics_2 = "Statistics on Conc"
            Dim blnIsStartRepeat As Boolean = False
            With objclsMethodIn.QuantitativeDataCollection(mlngSelectedRunIndex)
                If .StandardDataCollection.Count > 0 Then

                    For intStdIdx = 0 To .StandardDataCollection.Count - 1
                        blnIsStartRepeat = False
                        If .StandardDataCollection(intStdIdx).Used = True Then
                            strAbsRepeat = ""
                            For intAbsRepeat = 0 To .StandardDataCollection(intStdIdx).AbsRepeat.AbsRepeatData.Count - 1
                                If .StandardDataCollection(intStdIdx).AbsRepeat.AbsRepeatData(intAbsRepeat).Used = True Then
                                    'If intAbsRepeat = 0 Then '.StandardDataCollection(intStdIdx).AbsRepeat.AbsRepeatData.Count - 1 Then
                                    If blnIsStartRepeat = False Then

                                        strAbsRepeat = Format(.StandardDataCollection(intStdIdx).AbsRepeat.AbsRepeatData(intAbsRepeat).Abs, "#0.000")
                                    Else

                                        strAbsRepeat = strAbsRepeat & ", " & Format(.StandardDataCollection(intStdIdx).AbsRepeat.AbsRepeatData(intAbsRepeat).Abs, "#0.000")
                                    End If
                                    blnIsStartRepeat = True
                                End If
                            Next

                            intSerNo += 1
                            dtRow = DtReportData.NewRow()
                            dtRow(0) = "Standard Statistic"
                            dtRow(1) = intSerNo.ToString          '1 -Ser No.
                            dtRow(2) = "Std # " & (intStdIdx + 1).ToString  '2 - "Std Samp Ser No."

                            '---commented on 27.03.09
                            '''dtRow(3) = .StandardDataCollection(intStdIdx).StdName      '3 - "Std Samp Name"  
                            '----

                            '---written on 27.03.09
                            If intUnit = enumUnit.PPB Then
                                dtRow(3) = Space(2) & FormatNumber(.StandardDataCollection(intStdIdx).Concentration, 4)   '---03.06.09
                            Else
                                dtRow(3) = Space(2) & FormatNumber(.StandardDataCollection(intStdIdx).Concentration, 2)   '---03.06.09
                            End If
                            '-----

                            dtRow(4) = Space(2) & strAbsRepeat 'Format(.StandardDataCollection(intStdIdx).AbsRepeat. , "#0.00000")      '4 - "Abs"   '---03.06.09
                            dtRow(5) = ""  'Format(.StandardDataCollection(intStdIdx).Concentration, "#0.00000")      '5    -   "Conc"
                            dtRow(6) = True
                            DtReportData.Rows.Add(dtRow)

                            dtRow = DtReportDataStatistics.NewRow()
                            dtRow(0) = strlblStatistics_1
                            dtRow(1) = intSerNo         '1  -   "Ser No."
                            dtRow(2) = FormatNumber(.StandardDataCollection(intStdIdx).AbsRepeat.BasicStat.TotData(0), 0) '2 - "Observation"
                            dtRow(3) = FormatNumber(.StandardDataCollection(intStdIdx).AbsRepeat.BasicStat.ZAvg(0), 5)  '3 - "Process Mean"
                            dtRow(4) = FormatNumber(.StandardDataCollection(intStdIdx).AbsRepeat.BasicStat.ZSigma(0), 5)      '4 - "Standard Divation"
                            dtRow(5) = FormatNumber(.StandardDataCollection(intStdIdx).AbsRepeat.BasicStat.Var(0), 5)      '5 - "Variance"
                            dtRow(6) = FormatNumber(.StandardDataCollection(intStdIdx).AbsRepeat.BasicStat.CV(0), 5)      '6 - "Coeff.of Varaince"
                            dtRow(7) = FormatNumber(.StandardDataCollection(intStdIdx).AbsRepeat.BasicStat.Min(0), 5)      '7 - "Minimum Value"
                            dtRow(8) = FormatNumber(.StandardDataCollection(intStdIdx).AbsRepeat.BasicStat.Max(0), 5)      '8 - "Maximun Value"
                            dtRow(9) = FormatNumber(.StandardDataCollection(intStdIdx).AbsRepeat.BasicStat.Max(0) - .StandardDataCollection(intStdIdx).AbsRepeat.BasicStat.Min(0), 5)       '9 - "Range"
                            dtRow(10) = True    ' 10 - "Range"
                            DtReportDataStatistics.Rows.Add(dtRow)
                        End If
                    Next
                End If

                Dim intAbsLen, intConcLen, intMaxLen, intNumberOfSpacesForAbs As Integer '---03.07.09
                Dim intNumberOfCharForAbs, intNumberOfCharForConc, intNumberOfSpacesForConc As Integer '---03.07.09

                '//------ Sample Data
                If .SampleDataCollection.Count > 0 Then
                    For intSampIdx = 0 To .SampleDataCollection.Count - 1
                        strAbsRepeat = ""
                        strConcRepeat = ""
                        blnIsStartRepeat = False

                        If .SampleDataCollection(intSampIdx).Used = True Then

                            For intAbsRepeat = 0 To .SampleDataCollection(intSampIdx).AbsRepeat.AbsRepeatData.Count - 1

                                If .SampleDataCollection(intSampIdx).AbsRepeat.AbsRepeatData(intAbsRepeat).Used = True Then

                                    intAbsLen = 0  '---03.07.09
                                    intConcLen = 0  '---03.07.09
                                    intMaxLen = 0  '---03.07.09


                                    'If intAbsRepeat = 0 Then '.StandardDataCollection(intStdIdx).AbsRepeat.AbsRepeatData.Count - 1 Then
                                    If blnIsStartRepeat = False Then
                                        strAbsRepeat = Format(.SampleDataCollection(intSampIdx).AbsRepeat.AbsRepeatData(intAbsRepeat).Abs, "#0.000")


                                        intAbsLen = strAbsRepeat.Length  '---03.07.09


                                        strConcRepeat = FormatNumber(.SampleDataCollection(intSampIdx).AbsRepeat.AbsRepeatData(intAbsRepeat).Concentration, objclsMethodIn.AnalysisParameters.NumOfDecimalPlaces) ' code added by : dinesh wagh on 8.3.2009

                                        intConcLen = strConcRepeat.Length  '---03.07.09


                                        If intAbsLen > intConcLen Then  '---03.07.09
                                            intMaxLen = intAbsLen
                                        Else
                                            intMaxLen = intConcLen
                                        End If

                                        intNumberOfCharForAbs = intMaxLen - intAbsLen   '---03.07.09
                                        intNumberOfCharForConc = intMaxLen - intConcLen

                                        intNumberOfSpacesForAbs = intNumberOfCharForAbs * 2
                                        intNumberOfSpacesForConc = intNumberOfCharForConc * 2

                                        'strConcRepeat = Format(.SampleDataCollection(intSampIdx).AbsRepeat.AbsRepeatData(intAbsRepeat).Concentration, "#0.000") ' commented by : dinesh wagh on 8.3.2009
                                    Else
                                        strAbsRepeat = strAbsRepeat & Space(intNumberOfSpacesForAbs) & ", " & Format(.SampleDataCollection(intSampIdx).AbsRepeat.AbsRepeatData(intAbsRepeat).Abs, "#0.000")  '---03.06.09

                                        'strAbsRepeat = strAbsRepeat & ", " & Format(.SampleDataCollection(intSampIdx).AbsRepeat.AbsRepeatData(intAbsRepeat).Abs, "#0.000")  '---03.06.09

                                        'strConcRepeat = strConcRepeat & ", " & Format(.SampleDataCollection(intSampIdx).AbsRepeat.AbsRepeatData(intAbsRepeat).Concentration, "#0.000")' commented by : dinesh wagh on 8.3.2009

                                        strConcRepeat = strConcRepeat & Space(intNumberOfSpacesForConc) & ", " & FormatNumber(.SampleDataCollection(intSampIdx).AbsRepeat.AbsRepeatData(intAbsRepeat).Concentration, objclsMethodIn.AnalysisParameters.NumOfDecimalPlaces) ' code added by : dinesh wagh on 8.3.2009   '---03.06.09

                                        'strConcRepeat = strConcRepeat & ", " & FormatNumber(.SampleDataCollection(intSampIdx).AbsRepeat.AbsRepeatData(intAbsRepeat).Concentration, objclsMethodIn.AnalysisParameters.NumOfDecimalPlaces)  '---03.06.09
                                    End If
                                    blnIsStartRepeat = True
                                End If
                            Next

                            intSerNo += 1
                            dtRow = DtReportData.NewRow()
                            dtRow(0) = " "
                            dtRow(1) = intSerNo         '1 - "Ser No."
                            dtRow(2) = "Samp # " & (intSampIdx + 1).ToString  '2 - "Std Samp Ser No."
                            dtRow(3) = .SampleDataCollection(intSampIdx).SampleName       '3 - "Std Samp Name"
                            dtRow(4) = strAbsRepeat     'Format(.SampleDataCollection(intSampIdx).AbsRepeat.AbsRepeatData(intRepeatIdx).Abs, "#0.00000")          '4 - "Abs"
                            dtRow(5) = strConcRepeat    'Format(.SampleDataCollection(intSampIdx).AbsRepeat.AbsRepeatData(intRepeatIdx).Concentration, "#0.00000")       '5 - "Conc"
                            dtRow(6) = False
                            '//----- Statistics Data
                            '//----- Statistics of Abs
                            DtReportData.Rows.Add(dtRow)
                            dtRow = DtReportDataStatistics.NewRow()
                            dtRow(0) = strlblStatistics_1
                            dtRow(1) = intSerNo         '1 - "Ser No."
                            dtRow(2) = FormatNumber(.SampleDataCollection(intSampIdx).AbsRepeat.BasicStat.TotData(0), 0) '2 "Observation"
                            dtRow(3) = FormatNumber(.SampleDataCollection(intSampIdx).AbsRepeat.BasicStat.ZAvg(0), 5)  '3 - "Process Mean"
                            dtRow(4) = FormatNumber(.SampleDataCollection(intSampIdx).AbsRepeat.BasicStat.ZSigma(0), 5)      '4 "Standard Divation"
                            dtRow(5) = FormatNumber(.SampleDataCollection(intSampIdx).AbsRepeat.BasicStat.Var(0), 5)      '5 - "Variance"
                            dtRow(6) = FormatNumber(.SampleDataCollection(intSampIdx).AbsRepeat.BasicStat.CV(0), 5)      '6 - "Coeff.of Varaince"
                            dtRow(7) = FormatNumber(.SampleDataCollection(intSampIdx).AbsRepeat.BasicStat.Min(0), 5)      '7 - "Minimum Value"
                            dtRow(8) = FormatNumber(.SampleDataCollection(intSampIdx).AbsRepeat.BasicStat.Max(0), 5)      '8 - "Maximun Value"
                            dtRow(9) = FormatNumber(.SampleDataCollection(intSampIdx).AbsRepeat.BasicStat.Max(0) - .SampleDataCollection(intSampIdx).AbsRepeat.BasicStat.Min(0), 5)       '9 - "Range"
                            dtRow(10) = True    '10 - "IsAbs"
                            DtReportDataStatistics.Rows.Add(dtRow)

                            '//----- Statistics of Conc
                            'DtReportData.Rows.Add(dtRow)
                            dtRow = DtReportDataStatistics.NewRow()
                            dtRow(0) = strlblStatistics_2
                            dtRow(1) = intSerNo         '1 - "Ser No."
                            dtRow(2) = FormatNumber(.SampleDataCollection(intSampIdx).AbsRepeat.BasicStat.TotData(1), 0) '2 - "Observation"
                            dtRow(3) = FormatNumber(.SampleDataCollection(intSampIdx).AbsRepeat.BasicStat.ZAvg(1), 5)  '3 - "Process Mean"
                            dtRow(4) = FormatNumber(.SampleDataCollection(intSampIdx).AbsRepeat.BasicStat.ZSigma(1), 5)      '4 - "Standard Divation"
                            dtRow(5) = FormatNumber(.SampleDataCollection(intSampIdx).AbsRepeat.BasicStat.Var(1), 5)      '5 - "Variance"
                            dtRow(6) = FormatNumber(.SampleDataCollection(intSampIdx).AbsRepeat.BasicStat.CV(1), 5)      ' 6 - "Coeff.of Varaince"
                            dtRow(7) = FormatNumber(.SampleDataCollection(intSampIdx).AbsRepeat.BasicStat.Min(1), 5)      '7 - "Minimum Value"
                            dtRow(8) = FormatNumber(.SampleDataCollection(intSampIdx).AbsRepeat.BasicStat.Max(1), 5)      '8 - "Maximun Value"
                            dtRow(9) = FormatNumber(.SampleDataCollection(intSampIdx).AbsRepeat.BasicStat.Max(1) - .SampleDataCollection(intSampIdx).AbsRepeat.BasicStat.Min(1), 5)       '9 - "Range"
                            dtRow(10) = False   '10 - "IsAbs"
                            DtReportDataStatistics.Rows.Add(dtRow)
                            '//-----
                        End If
                        'Next
                    Next
                End If
            End With

            Call objarrMoreTextListData.Add(DtReportData)
            Call objarrMoreTextListData.Add(DtReportDataStatistics)
            Call objarrMoreTextListData.Add(DtReportData_InitInfo)

            strPageText = ""
            '//***********
            Dim intStdUsedIndex As Integer
            Dim blnFoundStd As Boolean = False

            For intStdUsedIndex = 0 To objclsMethodIn.QuantitativeDataCollection.Item(mlngSelectedRunIndex).SampleDataCollection.Count - 1
                If objclsMethodIn.QuantitativeDataCollection.Item(mlngSelectedRunIndex).SampleDataCollection(intStdUsedIndex).Used = True Then
                    blnFoundStd = True
                    Exit For
                End If
            Next

            objclsPrintDocument.DisplayFont = Me.DefaultFont
            GetHeaderFooter = True
            objclsPrintDocument = funcSetPrintDocument(objstructReportFormatIn, strPageHeader, strPageText,
                       GetHeaderFooter, objarrMoreTabularData,
                       objarrMoreTextListData, clsPrintDocument.enumReportType.RepeatResults)

            ' See the print preview
            If Not IsNothing(objclsPrintDocument) = True Then
                If GetHeaderFooter = True Then
                    strPageHeader.TextString = ""
                    strPageHeader.TextFormat = New clsReportHeaderFormat
                    strPageHeader.TextFormat.Alignment = ContentAlignment.MiddleLeft

                    strPageHeader.TextString = "Data Print" 'gobjMethodCollection.item(intMethodsIdxId).ReportParameters.ReportHeader
                    'strPageFooter.TextString = gobjMethodCollection.item(intMethodsIdxId).ReportParameters.ReportFooter
                    objclsPrintDocument.PageHeader = strPageHeader
                    'objclsPrintDocument.ReportFooter = strPageFooter
                End If

                If objclsPrintDocument.PrintPreview() = True Then
                    'If objclsPrintDocument.PrintToPrinter() = True Then
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

            If Not (DtReportData Is Nothing) Then
                DtReportData = Nothing
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcHistographPrint(ByVal PrintGraph As AAS203.AASGraph, ByVal mobjclsMethod As clsMethod) As Boolean
        '=====================================================================
        ' Procedure Name        : funcHistographPrint
        ' Parameters Passed     : AAS203.AASGraph, clsMethod
        ' Returns               : Return if success
        ' Purpose               : 
        ' Description           : Print the Histograph
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.02.07
        ' Revisions             : 1
        '=====================================================================

        Dim objclsPrintDocument As New clsPrintDocument
        Dim objDtImagesList As New DataTable
        Dim arrGraphControlsList As New ArrayList
        Dim objstructReportFormatIn As New clsReportingMode.structReportFormat
        Dim strPageHeader As New clsPrintDocument.struHeaderString  ' = ""    '" Test Page Header "
        Dim strPageText As String = "  "
        Dim objarrMoreTextListData As New ArrayList
        Dim objarrMoreTabularData As New ArrayList
        Dim DtReportData As DataTable
        Dim objDtElements As DataTable
        Dim intInstID As Integer
        Dim intCount As Integer
        Dim strElementName As String
        Dim dtRow As DataRow
        Dim GetHeaderFooter As Boolean
        Dim intCounter As Integer

        Try
            'Seting Report format and text
            strPageHeader.TextString = ""
            strPageHeader.TextFormat = New clsReportHeaderFormat
            strPageHeader.TextFormat.Alignment = ContentAlignment.MiddleLeft

            objstructReportFormatIn.PageBottomMargin = 0.5
            objstructReportFormatIn.PageLeftMargin = 0.5
            objstructReportFormatIn.PageTopMargin = 0.5


            Dim ReportHeader1 As New DataColumn("HeaderDefination", GetType(String))
            Dim ReportDtCol01 As New DataColumn("Col01", GetType(String))
            Dim ReportDtCol02 As New DataColumn("Col02", GetType(String))
            Dim ReportDtCol03 As New DataColumn("Col03", GetType(String))

            '//----- Search Element ID
            If mobjclsMethod.MethodID = mintSelectedMethodID Then
                intInstID = intCount
            End If

            For intCounter = 0 To mobjclsMethod.QuantitativeDataCollection.Count - 1
                If mobjclsMethod.QuantitativeDataCollection(intCounter).RunNumber = mlngSelectedRunNumber Then
                    mlngSelectedRunIndex = intCounter
                    Exit For
                End If
            Next

            objDtElements = gobjDataAccess.GetCookBookData(mobjclsMethod.InstrumentCondition.ElementID)
            If Not objDtElements Is Nothing Then
                If objDtElements.Rows.Count > 0 Then
                    strElementName = objDtElements.Rows(0).Item(ConstColumnElementName)
                End If
                objDtElements = Nothing
            End If



            DtReportData = New DataTable
            DtReportData.TableName = "Histogram Print"

            DtReportData.Columns.Add(ReportHeader1)
            DtReportData.Columns.Item(0).Caption = "Histogram Print"

            DtReportData.Columns.Add(ReportDtCol02)
            DtReportData.Columns.Item(1).Caption = "Element Name "

            DtReportData.Columns.Add(ReportDtCol01)
            DtReportData.Columns.Item(2).Caption = "Run No: "

            DtReportData.Columns.Add(ReportDtCol03)
            DtReportData.Columns.Item(3).Caption = "Analysed On"

            dtRow = DtReportData.NewRow()

            'dtRow(0) = strElementName   'CStr(gobjMethodCollection.item(mintSelectedMethodID).InstrumentConditions(0).ElementName)     '  ""
            dtRow(1) = strElementName
            If (mobjclsMethod.QuantitativeDataCollection(mlngSelectedRunIndex).RunNumber > 0) Then
                dtRow(2) = CStr(mobjclsMethod.QuantitativeDataCollection(mlngSelectedRunIndex).RunNumber)     '  ""
            Else
                dtRow(2) = CStr(" ")
            End If
            dtRow(3) = CStr(Format(mobjclsMethod.DateOfLastUse, "dd-MMM-yyyy hh:mm tt"))   '  ""


            DtReportData.Rows.Add(dtRow)
            Call objarrMoreTextListData.Add(DtReportData)

            '//**********
            Dim intStdUsedIndex As Integer
            Dim blnFoundStd As Boolean = False

            For intStdUsedIndex = 0 To mobjclsMethod.QuantitativeDataCollection.Item(mlngSelectedRunIndex).StandardDataCollection.Count - 1
                If mobjclsMethod.QuantitativeDataCollection.Item(mlngSelectedRunIndex).StandardDataCollection(intStdUsedIndex).Used = True Then
                    blnFoundStd = True
                    Exit For
                End If
            Next
            arrGraphControlsList = New ArrayList

            arrGraphControlsList.Add(PrintGraph)

            objclsPrintDocument = funcSetPrintDocument(objstructReportFormatIn, strPageHeader, strPageText,
                       GetHeaderFooter, arrGraphControlsList, objarrMoreTabularData,
                       objDtImagesList, objarrMoreTextListData, clsPrintDocument.enumReportType.Histograph)

            ' See the print preview
            If Not IsNothing(objclsPrintDocument) = True Then
                If objclsPrintDocument.PrintPreview() = True Then
                    'If objclsPrintDocument.PrintToPrinter() = True Then
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

            If Not (objDtElements Is Nothing) Then
                objDtElements = Nothing
            End If
            If Not (DtReportData Is Nothing) Then
                DtReportData = Nothing
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcPeakValleyPrintUV(ByVal PrintGraph As AAS203.AASGraph, ByVal objDataTable_PeakValley As DataTable, ByVal objInstrumentParameter As Spectrum.UVSpectrumParameter, ByVal strEquation As String) As Boolean
        '=====================================================================
        ' Procedure Name        : funcPeakValleyPrintUV
        ' Parameters Passed     : AAS203.AASGraph,DataTable, Spectrum.UVSpectrumParameter,
        '                       : strEquation As String
        ' Returns               : True if success
        ' Purpose               : Print report of Peak Valley for UV Abs.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 
        ' Revisions             : 
        '=====================================================================

        Dim objclsPrintDocument As New clsPrintDocument
        Dim objDtImagesList As New DataTable
        Dim arrGraphControlsList As New ArrayList
        Dim objstructReportFormatIn As New clsReportingMode.structReportFormat
        Dim strPageHeader As New clsPrintDocument.struHeaderString  ' = ""    '" Test Page Header "
        Dim strPageText As String = "   "
        Dim objarrMoreTextListData As New ArrayList
        Dim objarrMoreTabularData As New ArrayList
        Dim DtReportData As DataTable
        Dim intCount As Integer
        Dim dtRow As DataRow
        Dim intInstID As Integer
        Dim GetHeaderFooter As Boolean

        Try
            '--- Seting Report format and text
            strPageHeader.TextString = ""
            strPageHeader.TextFormat = New clsReportHeaderFormat
            strPageHeader.TextFormat.Alignment = ContentAlignment.MiddleLeft

            objstructReportFormatIn.PageBottomMargin = 0.5
            objstructReportFormatIn.PageLeftMargin = 0.5
            objstructReportFormatIn.PageTopMargin = 0.5

            Dim ReportHeader1 As New DataColumn("HeaderDefination", GetType(String))
            Dim ReportDtCol01 As New DataColumn("Col01", GetType(String))
            Dim ReportDtCol02 As New DataColumn("Col02", GetType(String))
            Dim ReportDtCol03 As New DataColumn("Col03", GetType(String))
            Dim ReportDtCol04 As New DataColumn("Col04", GetType(String))
            Dim ReportDtCol05 As New DataColumn("Col05", GetType(String))
            Dim ReportDtCol06 As New DataColumn("Col06", GetType(String))
            Dim ReportDtCol07 As New DataColumn("Col07", GetType(String))

            '//----- Search Element ID
            For intCount = 0 To gobjMethodCollection.Count - 1
                If gobjMethodCollection.item(intCount).MethodID = mintSelectedMethodID Then
                    intInstID = intCount
                    Exit For
                End If
            Next

            '//----- Print Page Header Text
            strPageText = "<# Spectrum Print"

            DtReportData = New DataTable
            DtReportData.TableName = "Sample Graph "

            DtReportData.Columns.Add(ReportHeader1)
            DtReportData.Columns.Item(0).Caption = " INSTRUMENT CONDITIONS"

            DtReportData.Columns.Add(ReportDtCol02)
            DtReportData.Columns.Item(1).Caption = "Sample : "

            DtReportData.Columns.Add(ReportDtCol01)
            DtReportData.Columns.Item(2).Caption = "Date : "

            DtReportData.Columns.Add(ReportDtCol03)
            DtReportData.Columns.Item(3).Caption = "PMT : "

            DtReportData.Columns.Add(ReportDtCol04)
            DtReportData.Columns.Item(4).Caption = "D2 Cur : "

            DtReportData.Columns.Add(ReportDtCol05)
            DtReportData.Columns.Item(5).Caption = "Slit : "

            DtReportData.Columns.Add(ReportDtCol06)
            DtReportData.Columns.Item(6).Caption = "Speed : "

            DtReportData.Columns.Add(ReportDtCol07)
            DtReportData.Columns.Item(7).Caption = "Mode : "



            dtRow = DtReportData.NewRow()

            'dtRow(0) = strElementName   'CStr(gobjMethodCollection.item(mintSelectedMethodID).InstrumentConditions(0).ElementName)     '  ""
            'dtRow(1) = "  " 'intObjCount
            If objInstrumentParameter.SpectrumName = "" Or objInstrumentParameter.SpectrumName Is Nothing Then
                objInstrumentParameter.SpectrumName = "       "
            End If
            dtRow(1) = objInstrumentParameter.SpectrumName
            'dtRow(2) = objInstrumentParameter.AnalysisDate     'strElementName
            dtRow(2) = CStr(Format(DateTime.Now, "dd-MMM-yyyy hh:mm tt"))   ' Added by Pankaj on 06 Sep 07
            dtRow(3) = Format(objInstrumentParameter.PMTV, " #0.0").ToString & " Volts"
            dtRow(4) = objInstrumentParameter.D2Curr & " mA"
            dtRow(5) = Format(objInstrumentParameter.SlitWidth, "0.0").ToString & " nm"



            Dim strSpeed As String

            'Pankaj for 201
            If (gstructSettings.AppMode = EnumAppMode.FullVersion_201) Or
                (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Then
                If objInstrumentParameter.ScanSpeed = CONST_FASTStep_AA201 Then
                    strSpeed = "Fast" 'strSpeed = "Slow" 'By Pankaj correcting wrongly written condn
                ElseIf objInstrumentParameter.ScanSpeed = CONST_MEDIUMStep_AA201 Then
                    strSpeed = "Medium"
                ElseIf objInstrumentParameter.ScanSpeed = CONST_SLOWStep_AA201 Then
                    strSpeed = "Slow"
                End If
            Else
                If objInstrumentParameter.ScanSpeed = CONST_FASTStep Then
                    strSpeed = "Fast" 'strSpeed = "Slow" 'By Pankaj correcting wrongly written condn
                ElseIf objInstrumentParameter.ScanSpeed = CONST_MEDIUMStep Then
                    strSpeed = "Medium"
                ElseIf objInstrumentParameter.ScanSpeed = CONST_SLOWStep Then
                    strSpeed = "Slow"
                End If
            End If
            'End
            dtRow(6) = strSpeed
            dtRow(7) = gfuncReturnstrCalMode(objInstrumentParameter.Cal_Mode)


            DtReportData.Rows.Add(dtRow)
            Call objarrMoreTextListData.Add(DtReportData)
            strPageText = Trim("Comments : " & objInstrumentParameter.Comments)


            arrGraphControlsList = New ArrayList
            arrGraphControlsList.Add(PrintGraph)
            objDataTable_PeakValley.TableName = gstrTitleInstrumentType & " SPECTRUM PEAKS AND VALLEYS"

            objarrMoreTabularData.Add(objDataTable_PeakValley)

            GetHeaderFooter = True
            objclsPrintDocument = funcSetPrintDocument(objstructReportFormatIn, strPageHeader, strPageText,
                       GetHeaderFooter, arrGraphControlsList, objarrMoreTabularData,
                       objDtImagesList, objarrMoreTextListData, clsPrintDocument.enumReportType.PrintPeak_Valley)

            strPageHeader.TextString = "Spectrum Print"
            objclsPrintDocument.PageHeader = strPageHeader
            ' See the print preview
            If Not IsNothing(objclsPrintDocument) = True Then
                If objclsPrintDocument.PrintPreview() = True Then
                    'If objclsPrintDocument.PrintToPrinter() = True Then
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
            If Not (DtReportData Is Nothing) Then
                DtReportData = Nothing
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcPeakValleyPrintEnergy(ByVal PrintGraph As AAS203.AASGraph, ByVal objDataTable_PeakValley As DataTable, ByVal objInstrumentParameter As Spectrum.EnergySpectrumParameter, ByVal strEquation As String) As Boolean
        '=====================================================================
        ' Procedure Name        : funcPeakValleyPrintEnergy
        ' Parameters Passed     : AAS203.AASGraph,DataTable, Spectrum.EnergySpectrumParameter,
        '                       : strEquation As String
        ' Returns               : True if success
        ' Purpose               : Print report of Peak Valley for Energy
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 
        ' Revisions             : 
        '=====================================================================

        Dim objclsPrintDocument As New clsPrintDocument
        Dim objDtImagesList As New DataTable
        Dim arrGraphControlsList As New ArrayList
        Dim objstructReportFormatIn As New clsReportingMode.structReportFormat
        Dim strPageHeader As New clsPrintDocument.struHeaderString  ' = ""    '" Test Page Header "
        Dim strPageText As String = "   "
        Dim objarrMoreTextListData As New ArrayList
        Dim objarrMoreTabularData As New ArrayList
        Dim DtReportData As DataTable
        Dim dtRow As DataRow
        Dim GetHeaderFooter As Boolean
        Dim strSpeed As String
        Try
            '--- Ini page header for clsPrintDocument object
            strPageHeader.TextString = ""
            strPageHeader.TextFormat = New clsReportHeaderFormat
            strPageHeader.TextFormat.Alignment = ContentAlignment.MiddleLeft

            objstructReportFormatIn.PageBottomMargin = 0.5
            objstructReportFormatIn.PageLeftMargin = 0.5
            objstructReportFormatIn.PageTopMargin = 0.5

            Dim ReportHeader1 As New DataColumn("HeaderDefination", GetType(String))
            Dim ReportDtCol01 As New DataColumn("Col01", GetType(String))
            Dim ReportDtCol02 As New DataColumn("Col02", GetType(String))
            Dim ReportDtCol03 As New DataColumn("Col03", GetType(String))
            Dim ReportDtCol04 As New DataColumn("Col04", GetType(String))
            Dim ReportDtCol05 As New DataColumn("Col05", GetType(String))
            Dim ReportDtCol06 As New DataColumn("Col06", GetType(String))
            Dim ReportDtCol07 As New DataColumn("Col07", GetType(String))

            '//----- Print Page Header Text
            strPageText = "<# Spectrum Print"

            DtReportData = New DataTable
            DtReportData.TableName = "Sample Graph "

            DtReportData.Columns.Add(ReportHeader1)
            DtReportData.Columns.Item(0).Caption = " INSTRUMENT CONDITIONS"

            DtReportData.Columns.Add(ReportDtCol02)
            DtReportData.Columns.Item(1).Caption = "Turret No. :"

            DtReportData.Columns.Add(ReportDtCol01)
            DtReportData.Columns.Item(2).Caption = "Element : "

            DtReportData.Columns.Add(ReportDtCol03)
            DtReportData.Columns.Item(3).Caption = "PMT :"

            DtReportData.Columns.Add(ReportDtCol04)
            DtReportData.Columns.Item(4).Caption = "D2 Cur : "

            DtReportData.Columns.Add(ReportDtCol05)
            DtReportData.Columns.Item(5).Caption = "Slit : "

            DtReportData.Columns.Add(ReportDtCol06)
            DtReportData.Columns.Item(6).Caption = "Speed : "

            DtReportData.Columns.Add(ReportDtCol07)
            DtReportData.Columns.Item(7).Caption = "Mode : "


            dtRow = DtReportData.NewRow()


            dtRow(1) = objInstrumentParameter.LampTurrNo
            dtRow(2) = objInstrumentParameter.LampEle     'strElementName
            dtRow(3) = Format(objInstrumentParameter.PMTV, " #0.0").ToString & " Volts"
            dtRow(4) = objInstrumentParameter.D2Curr & " mA"
            dtRow(5) = Format(objInstrumentParameter.SlitWidth, "0.0").ToString & " nm"



            'Pankaj for 201
            If (gstructSettings.AppMode = EnumAppMode.FullVersion_201) Or
                (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Then
                If objInstrumentParameter.ScanSpeed = CONST_FASTStep_AA201 Then
                    strSpeed = "Fast" 'strSpeed = "Slow" 'By Pankaj correcting wrongly written condn
                ElseIf objInstrumentParameter.ScanSpeed = CONST_MEDIUMStep_AA201 Then
                    strSpeed = "Medium"
                ElseIf objInstrumentParameter.ScanSpeed = CONST_SLOWStep_AA201 Then
                    strSpeed = "Slow"
                End If

            Else
                If objInstrumentParameter.ScanSpeed = CONST_FASTStep Then
                    strSpeed = "Fast" 'strSpeed = "Slow" 'By Pankaj correcting wrongly written condn
                ElseIf objInstrumentParameter.ScanSpeed = CONST_MEDIUMStep Then
                    strSpeed = "Medium"
                ElseIf objInstrumentParameter.ScanSpeed = CONST_SLOWStep Then
                    strSpeed = "Slow"
                End If
            End If
            'End
            dtRow(6) = strSpeed
            dtRow(7) = gfuncReturnstrCalMode(objInstrumentParameter.Cal_Mode)


            DtReportData.Rows.Add(dtRow)
            Call objarrMoreTextListData.Add(DtReportData)

            '--- "Comments" field is disable in Energy report
            'strPageText = Trim("Comments : " & objInstrumentParameter.Comments)
            strPageText = ""

            arrGraphControlsList = New ArrayList
            arrGraphControlsList.Add(PrintGraph)
            objDataTable_PeakValley.TableName = gstrTitleInstrumentType & " SPECTRUM PEAKS AND VALLEYS"

            objarrMoreTabularData.Add(objDataTable_PeakValley)

            GetHeaderFooter = True
            objclsPrintDocument = funcSetPrintDocument(objstructReportFormatIn, strPageHeader, strPageText,
                       GetHeaderFooter, arrGraphControlsList, objarrMoreTabularData,
                       objDtImagesList, objarrMoreTextListData, clsPrintDocument.enumReportType.PrintPeak_Valley)


            strPageHeader.TextString = "Spectrum Print"
            objclsPrintDocument.PageHeader = strPageHeader
            '--- View the print preview
            If Not IsNothing(objclsPrintDocument) = True Then
                If objclsPrintDocument.PrintPreview() = True Then
                    'If objclsPrintDocument.PrintToPrinter() = True Then
                    objclsPrintDocument.Dispose()
                    objclsPrintDocument = Nothing
                End If
            End If
            Return True
        Catch ex As Exception
            '----s-----------------------------------------------------
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
            If Not (DtReportData Is Nothing) Then
                DtReportData = Nothing
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcPrintEnergy(ByVal PrintGraph As AAS203.AASGraph, ByVal objInstrumentParameter As Spectrum.EnergySpectrumParameter, ByVal strEquation As String) As Boolean
        '=====================================================================
        ' Procedure Name        : funcPrintEnergy
        ' Parameters Passed     : AAS203.AASGraph, Spectrum.EnergySpectrumParameter, strEquation As String
        ' Returns               : True if success
        ' Purpose               : Print report of Energy graph
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 
        ' Revisions             : 
        '=====================================================================

        Dim objclsPrintDocument As New clsPrintDocument
        Dim objDtImagesList As New DataTable
        Dim arrGraphControlsList As New ArrayList
        Dim objstructReportFormatIn As New clsReportingMode.structReportFormat
        Dim strPageHeader As New clsPrintDocument.struHeaderString   ' = ""    '" Test Page Header "
        Dim strPageText As String = "   "
        Dim objarrMoreTextListData As New ArrayList
        Dim objarrMoreTabularData As New ArrayList
        Dim DtMethosDefination As DataTable
        Dim objDtElements As DataTable
        Dim DtReportData As DataTable
        Dim intCount As Integer
        Dim dtRow As DataRow
        Dim DtStdSampleData As DataTable
        Dim strElementName As String
        Dim intInstID As Integer
        Dim GetHeaderFooter As Boolean

        Try
            strPageHeader.TextString = ""
            strPageHeader.TextFormat = New clsReportHeaderFormat
            strPageHeader.TextFormat.Alignment = ContentAlignment.MiddleLeft

            objstructReportFormatIn.PageBottomMargin = 0.5
            objstructReportFormatIn.PageLeftMargin = 0.5
            objstructReportFormatIn.PageTopMargin = 0.5
            'If funcSetDatafieTable(objarrMoreTabularData, objarrMoreTextListData) = False Then
            '    Return False
            'End If


            Dim ReportHeader1 As New DataColumn("HeaderDefination", GetType(String))
            Dim ReportDtCol01 As New DataColumn("Col01", GetType(String))
            Dim ReportDtCol02 As New DataColumn("Col02", GetType(String))
            Dim ReportDtCol03 As New DataColumn("Col03", GetType(String))
            Dim ReportDtCol04 As New DataColumn("Col04", GetType(String))
            Dim ReportDtCol05 As New DataColumn("Col05", GetType(String))
            Dim ReportDtCol06 As New DataColumn("Col06", GetType(String))
            Dim ReportDtCol07 As New DataColumn("Col07", GetType(String))
            Dim ReportDtCol08 As New DataColumn("Col08", GetType(String))

            '//----- Search Element ID
            'For intCount = 0 To gobjMethodCollection.Count - 1
            '    If gobjMethodCollection.item(intCount).MethodID = mintSelectedMethodID Then
            '        'If gobjMethodCollection(intCount).SelectedElementID = gobjMethodCollection(intCount).InstrumentCondition.ElementID Then
            '        intInstID = intCount
            '        Exit For
            '        'End If
            '    End If
            'Next

            'objDtElements = gobjDataAccess.GetCookBookData(gobjMethodCollection.item(MethodID).InstrumentCondition.ElementID)
            'If Not objDtElements Is Nothing Then
            '    If objDtElements.Rows.Count > 0 Then
            '        strElementName = objDtElements.Rows(0).Item(ConstColumnElementName)
            '    End If
            '    objDtElements = Nothing
            'End If
            '//----- Print Page Header Text
            strPageText = "<# Spectrum Print"

            DtReportData = New DataTable
            DtReportData.TableName = "Sample Graph "

            DtReportData.Columns.Add(ReportHeader1)
            DtReportData.Columns.Item(0).Caption = " INSTRUMENT CONDITIONS"

            DtReportData.Columns.Add(ReportDtCol02)
            DtReportData.Columns.Item(1).Caption = "Turret No. :"

            DtReportData.Columns.Add(ReportDtCol01)
            DtReportData.Columns.Item(2).Caption = "Element : "

            DtReportData.Columns.Add(ReportDtCol03)
            DtReportData.Columns.Item(3).Caption = "PMT :"

            DtReportData.Columns.Add(ReportDtCol04)
            DtReportData.Columns.Item(4).Caption = "D2 Cur : "

            DtReportData.Columns.Add(ReportDtCol05)
            DtReportData.Columns.Item(5).Caption = "Slit : "

            DtReportData.Columns.Add(ReportDtCol06)
            DtReportData.Columns.Item(6).Caption = "Speed : "

            DtReportData.Columns.Add(ReportDtCol07)
            DtReportData.Columns.Item(7).Caption = "Mode : "

            DtReportData.Columns.Add(ReportDtCol08)
            DtReportData.Columns.Item(8).Caption = "Analysed On : "

            Dim intObjCount As Integer

            'For intObjCount = 0 To gobjInst.Lamp.LampParametersCollection.Count - 1
            '    Dim intSearchEleId As Integer
            '    intSearchEleId = gobjDataAccess.GetCookBookElementID(gobjInst.Lamp.LampParametersCollection.item(intObjCount).AtomicNumber)
            '    If intSearchEleId = gobjMethodCollection.item(MethodID).InstrumentCondition.ElementID Then
            '        'If funcShowElementInfo(gobjInst.Lamp.LampParametersCollection.item(intObjCount), intObjCount + 1) = True Then
            '        intObjCount = intObjCount + 1
            '        Exit For
            '        'End If
            '    End If
            'Next

            dtRow = DtReportData.NewRow()

            'dtRow(0) = strElementName   'CStr(gobjMethodCollection.item(mintSelectedMethodID).InstrumentConditions(0).ElementName)     '  ""

            'dtRow(1) = intObjCount
            dtRow(1) = objInstrumentParameter.LampTurrNo
            dtRow(2) = objInstrumentParameter.LampEle     'strElementName
            dtRow(3) = Format(objInstrumentParameter.PMTV, " #0.0").ToString & " Volts"
            dtRow(4) = objInstrumentParameter.D2Curr & " mA"
            dtRow(5) = Format(objInstrumentParameter.SlitWidth, "0.0").ToString & " nm"
            Dim strSpeed As String
            'If objInstrumentParameter.ScanSpeed = CONST_FASTStep Or _
            '        objInstrumentParameter.ScanSpeed = CONST_FASTStep_AA201 Then
            '    strSpeed = "Slow"
            'ElseIf objInstrumentParameter.ScanSpeed = CONST_MEDIUMStep Or _
            '        objInstrumentParameter.ScanSpeed = CONST_MEDIUMStep_AA201 Then
            '    strSpeed = "Medium"
            'ElseIf objInstrumentParameter.ScanSpeed = CONST_SLOWStep Or _
            '        objInstrumentParameter.ScanSpeed = CONST_SLOWStep_AA201 Then
            '    strSpeed = "Fast"
            'End If
            If objInstrumentParameter.ScanSpeed = CONST_FASTStep Then
                strSpeed = "Fast" 'strSpeed = "Slow" 'By Pankaj correcting wrongly written condn
            ElseIf objInstrumentParameter.ScanSpeed = CONST_MEDIUMStep Then
                strSpeed = "Medium"
            ElseIf objInstrumentParameter.ScanSpeed = CONST_SLOWStep Then
                strSpeed = "Slow"
            End If
            'Pankaj for 201
            If (gstructSettings.AppMode = EnumAppMode.FullVersion_201) Then
                If objInstrumentParameter.ScanSpeed = CONST_FASTStep_AA201 Then
                    strSpeed = "Fast" 'strSpeed = "Slow" 'By Pankaj correcting wrongly written condn
                ElseIf objInstrumentParameter.ScanSpeed = CONST_MEDIUMStep_AA201 Then
                    strSpeed = "Medium"
                ElseIf objInstrumentParameter.ScanSpeed = CONST_SLOWStep_AA201 Then
                    strSpeed = "Slow"
                End If

            End If
            'End
            dtRow(6) = strSpeed
            dtRow(7) = gfuncReturnstrCalMode(objInstrumentParameter.Cal_Mode)
            dtRow(8) = CStr(Format(DateTime.Now, "dd-MMM-yyyy hh:mm tt"))    '  ""



            DtReportData.Rows.Add(dtRow)
            Call objarrMoreTextListData.Add(DtReportData)
            '--- "Comments" field is disable in Energy report
            'strPageText = Trim("Comments : " & objInstrumentParameter.Comments)
            strPageText = ""

            arrGraphControlsList = New ArrayList
            arrGraphControlsList.Add(PrintGraph)
            'objDataTable_PeakValley.TableName = gstrTitleInstrumentType & " SPECTRUM PEAKS AND VALLEYS"

            'objarrMoreTabularData.Add(objDataTable_PeakValley)
            'objclsPrintDocument.PageHeader.TextFormat.Alignment = ContentAlignment.MiddleCenter
            GetHeaderFooter = True
            objclsPrintDocument = funcSetPrintDocument(objstructReportFormatIn, strPageHeader, strPageText,
                       GetHeaderFooter, arrGraphControlsList, objarrMoreTabularData,
                       objDtImagesList, objarrMoreTextListData, clsPrintDocument.enumReportType.EnergySpectrum)

            strPageHeader.TextString = "Spectrum Print"
            objclsPrintDocument.PageHeader = strPageHeader

            ' See the print preview
            If Not IsNothing(objclsPrintDocument) = True Then
                If objclsPrintDocument.PrintPreview() = True Then
                    'If objclsPrintDocument.PrintToPrinter() = True Then
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
            If Not (DtMethosDefination Is Nothing) Then
                DtMethosDefination = Nothing
            End If
            If Not (objDtElements Is Nothing) Then
                objDtElements = Nothing
            End If
            If Not (DtReportData Is Nothing) Then
                DtReportData = Nothing
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcPrintD2Peak(ByVal PrintGraph_486Peak As AAS203.AASGraph, ByVal PrintGraph_656Peak As AAS203.AASGraph) As Boolean
        '=====================================================================
        ' Procedure Name        : funcPrintD2Peak
        ' Parameters Passed     : PrintGraph_486Peak  and PrintGraph_656Peak as AAS203.AASGraph
        ' Returns               : True if success
        ' Purpose               : Print report of D2 Peak
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 
        ' Revisions             : 
        '=====================================================================

        Dim objclsPrintDocument As New clsPrintDocument
        Dim objDtImagesList As New DataTable
        Dim arrGraphControlsList As New ArrayList
        Dim objstructReportFormatIn As New clsReportingMode.structReportFormat
        Dim strPageHeader As New clsPrintDocument.struHeaderString  ' = ""    '" Test Page Header "
        Dim strPageText As String = "   "
        Dim objarrMoreTextListData As New ArrayList
        Dim objarrMoreTabularData As New ArrayList
        Dim DtMethosDefination As DataTable
        Dim objDtElements As DataTable
        Dim DtReportData As DataTable
        Dim intCount As Integer
        Dim dtRow As DataRow
        Dim DtStdSampleData As DataTable
        Dim strElementName As String
        Dim intInstID As Integer
        Dim GetHeaderFooter As Boolean

        Try
            strPageHeader.TextString = ""
            strPageHeader.TextFormat = New clsReportHeaderFormat
            strPageHeader.TextFormat.Alignment = ContentAlignment.MiddleLeft

            objstructReportFormatIn.PageBottomMargin = 0.5
            objstructReportFormatIn.PageLeftMargin = 0.5
            objstructReportFormatIn.PageTopMargin = 0.5
            'If funcSetDatafieTable(objarrMoreTabularData, objarrMoreTextListData) = False Then
            '    Return False
            'End If


            Dim ReportHeader1 As New DataColumn("HeaderDefination", GetType(String))
            Dim ReportDtCol01 As New DataColumn("Col01", GetType(String))

            '//----- Print Page Header Text
            strPageText = " " '"<# D2 Peak Print"

            DtReportData = New DataTable
            DtReportData.TableName = "D2 Graph "

            DtReportData.Columns.Add(ReportHeader1)
            DtReportData.Columns.Item(0).Caption = " "

            DtReportData.Columns.Add(ReportDtCol01)
            DtReportData.Columns.Item(1).Caption = "Analysed On : "
            dtRow = DtReportData.NewRow()
            dtRow(0) = " "
            dtRow(1) = CStr(Format(DateTime.Now, "dd-MMM-yyyy hh:mm tt"))
            DtReportData.Rows.Add(dtRow)
            Call objarrMoreTextListData.Add(DtReportData)
            '--- "Comments" field is disable in Energy report
            'strPageText = Trim("Comments : " & objInstrumentParameter.Comments)
            'strPageText = ""

            arrGraphControlsList = New ArrayList
            arrGraphControlsList.Add(PrintGraph_486Peak)
            arrGraphControlsList.Add(PrintGraph_656Peak)
            'objDataTable_PeakValley.TableName = gstrTitleInstrumentType & " SPECTRUM PEAKS AND VALLEYS"

            'objarrMoreTabularData.Add(objDataTable_PeakValley)
            'objclsPrintDocument.PageHeader.TextFormat.Alignment = ContentAlignment.MiddleCenter
            GetHeaderFooter = True
            objclsPrintDocument = funcSetPrintDocument(objstructReportFormatIn, strPageHeader, strPageText,
                       GetHeaderFooter, arrGraphControlsList, objarrMoreTabularData,
                       objDtImagesList, objarrMoreTextListData, clsPrintDocument.enumReportType.EnergySpectrum)

            strPageHeader.TextString = "D2 Peak Print"
            objclsPrintDocument.PageHeader = strPageHeader
            objclsPrintDocument.DisplayFont = Me.DefaultFont
            ' See the print preview
            If Not IsNothing(objclsPrintDocument) = True Then
                PrintGraph_486Peak.AldysPane.Legend.IsVisible = True
                PrintGraph_656Peak.AldysPane.Legend.IsVisible = True

                If objclsPrintDocument.PrintPreview() = True Then
                    'If objclsPrintDocument.PrintToPrinter() = True Then
                    objclsPrintDocument.Dispose()
                    objclsPrintDocument = Nothing
                End If
                PrintGraph_486Peak.AldysPane.Legend.IsVisible = False
                PrintGraph_656Peak.AldysPane.Legend.IsVisible = False
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
            If Not (DtMethosDefination Is Nothing) Then
                DtMethosDefination = Nothing
            End If
            If Not (objDtElements Is Nothing) Then
                objDtElements = Nothing
            End If
            If Not (DtReportData Is Nothing) Then
                DtReportData = Nothing
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcPrintTimescan(ByVal PrintGraph_Timescan As AAS203.AASGraph) As Boolean
        '=====================================================================
        ' Procedure Name        : funcPrintTimescan
        ' Parameters Passed     : PrintGraph_Timescan as AAS203.AASGraph, mobjclsMethod As clsMethod
        ' Returns               : True if success
        ' Purpose               : Print report of Time Sacan
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 05.12.2007
        ' Revisions             : 
        '=====================================================================

        Dim objclsPrintDocument As New clsPrintDocument
        Dim objDtImagesList As New DataTable
        Dim arrGraphControlsList As New ArrayList
        Dim objstructReportFormatIn As New clsReportingMode.structReportFormat
        Dim strPageHeader As New clsPrintDocument.struHeaderString  ' = ""    '" Test Page Header "
        Dim strPageText As String = "   "
        Dim objarrMoreTextListData As New ArrayList
        Dim objarrMoreTabularData As New ArrayList
        Dim DtMethosDefination As DataTable
        Dim objDtElements As DataTable
        Dim DtReportData As DataTable
        Dim intCount As Integer
        Dim dtRow As DataRow
        Dim DtStdSampleData As DataTable
        Dim strElementName As String
        Dim intInstID As Integer
        Dim GetHeaderFooter As Boolean
        Dim mdblFuelRatio As Double
        '--- Column defination 
        Dim ReportHeader1 As New DataColumn("HeaderDefination", GetType(String))
        Dim ReportDtCol01 As New DataColumn("Col01", GetType(String))
        Dim ReportDtCol01_1 As New DataColumn("Col01_1", GetType(String))
        Dim ReportDtCol02 As New DataColumn("Col02", GetType(String))
        Dim ReportDtCol03 As New DataColumn("Col03", GetType(String))
        Dim ReportDtCol04 As New DataColumn("Col04", GetType(String))
        Dim ReportDtCol04_1 As New DataColumn("Col04_1", GetType(String))
        Dim ReportDtCol05 As New DataColumn("Col05", GetType(String))
        Dim ReportDtCol06 As New DataColumn("Col06", GetType(String))
        Dim ReportDtCol07 As New DataColumn("Col07", GetType(String))
        Dim ReportDtCol08 As New DataColumn("Col08", GetType(String))
        Dim ReportDtCol09 As New DataColumn("Col09", GetType(String))
        '----
        Dim ColIndex As Integer

        Try
            strPageHeader.TextString = ""
            strPageHeader.TextFormat = New clsReportHeaderFormat
            strPageHeader.TextFormat.Alignment = ContentAlignment.MiddleLeft

            objstructReportFormatIn.PageBottomMargin = 0.5
            objstructReportFormatIn.PageLeftMargin = 0.5
            objstructReportFormatIn.PageTopMargin = 0.5
            'If funcSetDatafieTable(objarrMoreTabularData, objarrMoreTextListData) = False Then
            '    Return False
            'End If

            DtReportData = New DataTable
            DtReportData.TableName = "Timescan"

            DtReportData.Columns.Add(ReportHeader1)
            DtReportData.Columns.Item(ColIndex).Caption = "TIMESCAN"
            ColIndex += 1

            DtReportData.Columns.Add(ReportDtCol01)
            If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam Then
                DtReportData.Columns.Item(ColIndex).Caption = "PMT :"
            Else
                DtReportData.Columns.Item(ColIndex).Caption = "Sample PMT :"
            End If

            ColIndex += 1
            DtReportData.Columns.Add(ReportDtCol02)
            DtReportData.Columns.Item(ColIndex).Caption = "Date : "
            ColIndex += 1

            If Not gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam Then
                DtReportData.Columns.Add(ReportDtCol01_1)
                DtReportData.Columns.Item(ColIndex).Caption = "Ref. PMT :"
                ColIndex += 1
            Else
                ReportDtCol01_1 = Nothing
            End If

            DtReportData.Columns.Add(ReportDtCol03)
            DtReportData.Columns.Item(ColIndex).Caption = "Current : "
            ColIndex += 1

            DtReportData.Columns.Add(ReportDtCol04)
            If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
                DtReportData.Columns.Item(ColIndex).Caption = "Entry Slit : "
            Else
                DtReportData.Columns.Item(ColIndex).Caption = "Slit : "
            End If
            ColIndex += 1

            DtReportData.Columns.Add(ReportDtCol05)
            DtReportData.Columns.Item(ColIndex).Caption = "D2 Cur : "
            ColIndex += 1

            If Not gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam Then
                DtReportData.Columns.Add(ReportDtCol04_1)
                DtReportData.Columns.Item(ColIndex).Caption = "Exit Slit : "
                ColIndex += 1
            Else
                ReportDtCol04_1 = Nothing
            End If

            DtReportData.Columns.Add(ReportDtCol06)
            DtReportData.Columns.Item(ColIndex).Caption = "Mode : "
            ColIndex += 1

            DtReportData.Columns.Add(ReportDtCol07)
            DtReportData.Columns.Item(ColIndex).Caption = "Fuel Ratio : "
            ColIndex += 1

            DtReportData.Columns.Add(ReportDtCol08)
            DtReportData.Columns.Item(ColIndex).Caption = "Wavelength : "
            ColIndex += 1

            DtReportData.Columns.Add(ReportDtCol09)
            DtReportData.Columns.Item(ColIndex).Caption = "Burner Ht. : "
            ColIndex += 1

            Dim intObjCount As Integer

            dtRow = DtReportData.NewRow()

            ColIndex = 1
            '1  PMT
            dtRow(ColIndex) = CStr(Format(gobjInst.PmtVoltage, "#0.0"))

            ColIndex += 1
            '2 current Date
            dtRow(ColIndex) = CStr(Format(DateTime.Now, "dd-MMM-yyyy hh:mm tt"))

            '3  Ref PMT
            If Not gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam Then
                '1.1
                ColIndex += 1
                dtRow(ColIndex) = CStr(Format(gobjInst.PmtVoltageReference, "#0.0"))
            End If

            ColIndex += 1
            dtRow(ColIndex) = Format(gobjInst.Current, " #0.0").ToString

            ColIndex += 1
            '4  Entry Slit 
            dtRow(ColIndex) = Format(gobjClsAAS203.funcGet_SlitWidth(), "0.0").ToString

            ColIndex += 1
            '5 D2 Current
            If gobjInst.D2Current <= 100 Then
                dtRow(ColIndex) = "D2 Off"
            Else
                dtRow(ColIndex) = gobjInst.D2Current
            End If


            If Not gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam Then
                ColIndex += 1
                '4.1    Exit slit
                dtRow(ColIndex) = gobjClsAAS203.funcGet_SlitWidth(1)
            End If

            ColIndex += 1
            '6 Inst Mode
            dtRow(ColIndex) = gfuncReturnstrCalMode(gobjInst.Mode)
            'mdblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(True) '10.12.07
            mdblFuelRatio = gobjClsAAS203.funcRead_Fuel_Ratio()     '10.12.07
            If mdblFuelRatio < 0.0 Then
                mdblFuelRatio = 0.0
            End If
            ColIndex += 1
            '7  Fuel Ratio
            dtRow(ColIndex) = Format(mdblFuelRatio, "0.00").ToString

            ColIndex += 1
            '8  Wavelength
            dtRow(ColIndex) = Format(gobjInst.WavelengthCur, "0.0").ToString

            ColIndex += 1
            '9  Burner Height
            dtRow(ColIndex) = Format(gobjClsAAS203.funcConvertToBurnerHeight(gobjInst.BhStep), "0.0").ToString

            '//----- Print Page Header Text

            DtReportData.Rows.Add(dtRow)
            Call objarrMoreTextListData.Add(DtReportData)
            '--- "Comments" field is disable in Energy report
            'strPageText = Trim("Comments : " & objInstrumentParameter.Comments)
            'strPageText = ""

            arrGraphControlsList = New ArrayList
            arrGraphControlsList.Add(PrintGraph_Timescan)

            'objDataTable_PeakValley.TableName = gstrTitleInstrumentType & " SPECTRUM PEAKS AND VALLEYS"

            'objarrMoreTabularData.Add(objDataTable_PeakValley)
            'objclsPrintDocument.PageHeader.TextFormat.Alignment = ContentAlignment.MiddleCenter
            GetHeaderFooter = True
            objclsPrintDocument = funcSetPrintDocument(objstructReportFormatIn, strPageHeader, strPageText,
                       GetHeaderFooter, arrGraphControlsList, objarrMoreTabularData,
                       objDtImagesList, objarrMoreTextListData, clsPrintDocument.enumReportType.EnergySpectrum)

            strPageHeader.TextString = "Timescan Print"
            objclsPrintDocument.PageHeader = strPageHeader
            objclsPrintDocument.DisplayFont = Me.DefaultFont
            ' See the print preview
            If Not IsNothing(objclsPrintDocument) = True Then
                If objclsPrintDocument.PrintPreview() = True Then
                    'If objclsPrintDocument.PrintToPrinter() = True Then
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
            If Not (DtMethosDefination Is Nothing) Then
                DtMethosDefination = Nothing
            End If
            If Not (objDtElements Is Nothing) Then
                objDtElements = Nothing
            End If
            If Not (DtReportData Is Nothing) Then
                DtReportData = Nothing
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcPrintUV(ByVal PrintGraph As AAS203.AASGraph, ByVal objInstrumentParameter As Spectrum.UVSpectrumParameter, ByVal strEquation As String) As Boolean
        '=====================================================================
        ' Procedure Name        : funcPrintUV
        ' Parameters Passed     : AAS203.AASGraph,Spectrum.UVSpectrumParameter,strEquation As String
        ' Returns               : True if success
        ' Purpose               : Print report of UV Abs.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 
        ' Revisions             : 
        '=====================================================================
        Dim objclsPrintDocument As New clsPrintDocument
        Dim objDtImagesList As New DataTable
        Dim arrGraphControlsList As New ArrayList
        Dim objstructReportFormatIn As New clsReportingMode.structReportFormat
        Dim strPageHeader As New clsPrintDocument.struHeaderString  ' = ""    '" Test Page Header "
        Dim strPageText As String = "  "
        Dim objarrMoreTextListData As New ArrayList
        Dim objarrMoreTabularData As New ArrayList
        Dim DtReportData As DataTable
        Dim dtRow As DataRow
        Dim GetHeaderFooter As Boolean

        Try
            strPageHeader.TextString = ""
            strPageHeader.TextFormat = New clsReportHeaderFormat
            strPageHeader.TextFormat.Alignment = ContentAlignment.MiddleLeft

            objstructReportFormatIn.PageBottomMargin = 0.5
            objstructReportFormatIn.PageLeftMargin = 0.5
            objstructReportFormatIn.PageTopMargin = 0.5

            Dim ReportHeader1 As New DataColumn("HeaderDefination", GetType(String))
            Dim ReportDtCol01 As New DataColumn("Col01", GetType(String))
            Dim ReportDtCol02 As New DataColumn("Col02", GetType(String))
            Dim ReportDtCol03 As New DataColumn("Col03", GetType(String))
            Dim ReportDtCol04 As New DataColumn("Col04", GetType(String))
            Dim ReportDtCol05 As New DataColumn("Col05", GetType(String))
            Dim ReportDtCol06 As New DataColumn("Col06", GetType(String))
            Dim ReportDtCol07 As New DataColumn("Col07", GetType(String))

            '//----- Print Page Header Text
            DtReportData = New DataTable
            DtReportData.TableName = "Sample Graph "

            DtReportData.Columns.Add(ReportHeader1)
            DtReportData.Columns.Item(0).Caption = " INSTRUMENT CONDITIONS"

            DtReportData.Columns.Add(ReportDtCol02)
            DtReportData.Columns.Item(1).Caption = "Sample : "

            DtReportData.Columns.Add(ReportDtCol01)
            DtReportData.Columns.Item(2).Caption = "Date : "

            DtReportData.Columns.Add(ReportDtCol03)
            DtReportData.Columns.Item(3).Caption = "PMT : "

            DtReportData.Columns.Add(ReportDtCol04)
            DtReportData.Columns.Item(4).Caption = "D2 Cur : "

            DtReportData.Columns.Add(ReportDtCol05)
            DtReportData.Columns.Item(5).Caption = "Slit : "

            DtReportData.Columns.Add(ReportDtCol06)
            DtReportData.Columns.Item(6).Caption = "Speed : "

            DtReportData.Columns.Add(ReportDtCol07)
            DtReportData.Columns.Item(7).Caption = "Mode : "



            dtRow = DtReportData.NewRow()
            If objInstrumentParameter.SpectrumName = "" Or objInstrumentParameter.SpectrumName Is Nothing Then
                objInstrumentParameter.SpectrumName = "       "
            End If
            'dtRow(0) = strElementName   'CStr(gobjMethodCollection.item(mintSelectedMethodID).InstrumentConditions(0).ElementName)     '  ""
            dtRow(1) = objInstrumentParameter.SpectrumName '' Added by Pankaj on 06 Sep 07" " 'intObjCount '
            'dtRow(2) = objInstrumentParameter.AnalysisDate     'strElementName' Comment by pankaj on 06 Sep 07

            dtRow(2) = CStr(Format(DateTime.Now, "dd-MMM-yyyy hh:mm tt"))   ' Added by Pankaj on 06 Sep 07
            dtRow(3) = Format(objInstrumentParameter.PMTV, " #0.0").ToString & " Volts"
            dtRow(4) = objInstrumentParameter.D2Curr & " mA"
            dtRow(5) = Format(objInstrumentParameter.SlitWidth, "0.0").ToString & " nm"
            Dim strSpeed As String
            If objInstrumentParameter.ScanSpeed = CONST_FASTStep Then
                'Or _
                'objInstrumentParameter.ScanSpeed = CONST_FASTStep_AA201 Then
                strSpeed = "Fast" 'strSpeed = "Slow" 'By Pankaj correcting wrongly written condn
            ElseIf objInstrumentParameter.ScanSpeed = CONST_MEDIUMStep Then 'Or _
                'objInstrumentParameter.ScanSpeed = CONST_MEDIUMStep_AA201 Then
                strSpeed = "Medium"
            ElseIf objInstrumentParameter.ScanSpeed = CONST_SLOWStep Then 'Or _
                'objInstrumentParameter.ScanSpeed = CONST_SLOWStep_AA201 Then 'By Pankaj correcting wrongly written condn
                strSpeed = "Slow"
            End If
            'Pankaj for 201
            If (gstructSettings.AppMode = EnumAppMode.FullVersion_201) Then
                If objInstrumentParameter.ScanSpeed = CONST_FASTStep_AA201 Then
                    strSpeed = "Fast" 'strSpeed = "Slow" 'By Pankaj correcting wrongly written condn
                ElseIf objInstrumentParameter.ScanSpeed = CONST_MEDIUMStep_AA201 Then
                    strSpeed = "Medium"
                ElseIf objInstrumentParameter.ScanSpeed = CONST_SLOWStep_AA201 Then
                    strSpeed = "Slow"
                End If

            End If
            'End
            dtRow(6) = strSpeed
            dtRow(7) = gfuncReturnstrCalMode(objInstrumentParameter.Cal_Mode)


            DtReportData.Rows.Add(dtRow)
            Call objarrMoreTextListData.Add(DtReportData)
            strPageText = Trim("Comments : " & objInstrumentParameter.Comments)


            arrGraphControlsList = New ArrayList
            arrGraphControlsList.Add(PrintGraph)
            '
            GetHeaderFooter = True
            objclsPrintDocument = funcSetPrintDocument(objstructReportFormatIn, strPageHeader, strPageText,
                    GetHeaderFooter, arrGraphControlsList, objarrMoreTabularData,
                    objDtImagesList, objarrMoreTextListData, clsPrintDocument.enumReportType.UVSpectrum)
            strPageHeader.TextString = "Spectrum Print"
            objclsPrintDocument.PageHeader = strPageHeader

            ' See the print preview
            If Not IsNothing(objclsPrintDocument) = True Then
                If objclsPrintDocument.PrintPreview() = True Then
                    'If objclsPrintDocument.PrintToPrinter() = True Then
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
            If Not (DtReportData Is Nothing) Then
                DtReportData = Nothing
            End If
            arrGraphControlsList = Nothing
            objarrMoreTextListData = Nothing
            objarrMoreTabularData = Nothing
            dtRow = Nothing
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcMultiReport(ByVal arrRunNoList(,) As Integer) As Boolean
        '=====================================================================
        ' Procedure Name        : funcMultiReport
        ' Parameters Passed     : arrRunNoList as integer array
        ' Returns               : TRUE if success
        ' Purpose               : Print report of Multiple analysis
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 
        ' Revisions             : 
        '=====================================================================

        Dim objclsPrintDocument As New clsPrintDocument
        Dim objDtImagesList As New DataTable
        Dim arrGraphControlsList As New ArrayList
        Dim objstructReportFormatIn As New clsReportingMode.structReportFormat
        Dim strPageHeader As New clsPrintDocument.struHeaderString  ' = ""    '" Test Page Header "
        Dim strPageText As String = "   "
        Dim objarrMoreTextListData As New ArrayList
        Dim objarrMoreTabularData As New ArrayList
        Dim GetHeaderFooter As Boolean
        Try
            strPageHeader.TextString = ""
            strPageHeader.TextFormat = New clsReportHeaderFormat
            strPageHeader.TextFormat.Alignment = ContentAlignment.MiddleCenter

            objstructReportFormatIn.PageBottomMargin = 0.5
            objstructReportFormatIn.PageLeftMargin = 0.5
            objstructReportFormatIn.PageTopMargin = 0.5
            If funcSetMultiReport(arrRunNoList, objarrMoreTabularData, objarrMoreTextListData) = False Then
                Return False
            End If

            objclsPrintDocument = funcSetPrintDocument(objstructReportFormatIn, strPageHeader, strPageText,
                       GetHeaderFooter, arrGraphControlsList, objarrMoreTabularData,
                       objDtImagesList, objarrMoreTextListData, clsPrintDocument.enumReportType.Others)


            '--- View the print preview
            If Not IsNothing(objclsPrintDocument) = True Then
                If objclsPrintDocument.SendExportData() = True Then
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
            '---------------------------------------------------------
        End Try
    End Function

#End Region

#Region " Private Functions "

    Private Function funcSetDatafileTable(ByRef ArrListMoreTabularData As ArrayList, ByRef DtArrDatafile As ArrayList, Optional ByRef blnGetHeaderFooter As Boolean = False) As Boolean
        '=====================================================================
        ' Procedure Name        :   funcSetDatafileTable
        ' Parameters Passed     : 
        ' Parameters Affected   : ArrListMoreTabularData As ArrayList,DtArrDatafile As ArrayList,
        '                       : blnGetHeaderFooter
        ' Returns               : True if success
        ' Purpose               : Set data file results into array object to the print object
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                :   Sachin Dokhale
        ' Created               : 
        ' Revisions             : 
        '=====================================================================

        Dim strMethodMode As String
        Dim strStatus As String
        Dim strIsBlank As String
        Dim strD2Curr As String
        Dim strCalculationMode As String
        Dim strElementName As String

        Dim intCount As Integer
        Dim DtMethosDefination As DataTable
        Dim DtAnalysisParam As DataTable
        Dim DtInstCondition As DataTable
        Dim DtStdSampleData As DataTable
        Dim DtReportData As DataTable
        Dim DtCalculationMode As DataTable
        Dim objDtElements As DataTable
        Dim blnWvFound As Boolean
        Dim intNoOfDecimalPlaces As Integer
        Dim dblConcInPpm As Double
        Dim intCounter As Integer
        Try
            funcSetDatafileTable = False
            If mlngSelectedRunNumber = 0 Then
                Return False
            End If
            '--- Data table property declaration
            Dim ReportHeader1 As New DataColumn("HeaderDefination", GetType(String))
            Dim ReportDtCol01 As New DataColumn("Col01", GetType(String))
            Dim ReportDtCol02 As New DataColumn("Col02", GetType(String))


            Dim CalculationModeHeader As New DataColumn("HeaderDefination", GetType(String))
            Dim CalculationModeDtCol01 As New DataColumn("Col01", GetType(String))

            Dim Header1 As New DataColumn("HeaderDefination", GetType(String))
            Dim DtCol01 As New DataColumn("Col01", GetType(String))
            Dim DtCol02 As New DataColumn("Col02", GetType(String))
            Dim DtCol03 As New DataColumn("Col03", GetType(String))
            Dim DtCol04 As New DataColumn("Col04", GetType(String))
            Dim DtCol05 As New DataColumn("Col05", GetType(String))
            Dim DtCol06 As New DataColumn("Col06", GetType(String))
            Dim DtCol07 As New DataColumn("Col07", GetType(String))
            Dim DtCol08 As New DataColumn("Col08", GetType(String))
            Dim DtCol09 As New DataColumn("Col09", GetType(String))
            Dim DtCol10 As New DataColumn("Col10", GetType(String))
            '--- Data row 
            Dim dtRow As DataRow


            '//----- Search Element ID
            For intCount = 0 To gobjMethodCollection.Count - 1
                If gobjMethodCollection.item(intCount).MethodID = mintSelectedMethodID Then
                    intMethodsIdxId = intCount
                    For intCounter = 0 To gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Count - 1
                        If gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection(intCounter).RunNumber = mlngSelectedRunNumber Then
                            mlngSelectedRunIndex = intCounter
                            Exit For
                        End If
                    Next
                End If
            Next

            If mlngSelectedRunIndex = -1 Then
                Return False
            End If
            '--- Detect Enement name from data table
            objDtElements = gobjDataAccess.GetCookBookData(gobjMethodCollection.item(intMethodsIdxId).InstrumentCondition.ElementID)
            If Not objDtElements Is Nothing Then
                If objDtElements.Rows.Count > 0 Then
                    strElementName = objDtElements.Rows(0).Item(ConstColumnElementName)
                End If
                objDtElements = Nothing
            End If

            If gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Count <= 0 Then
                Return True
            End If

            With gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection(mlngSelectedRunIndex)
                ' Set the object for titel "Quantitative Report" 
                intNoOfDecimalPlaces = CInt(gobjMethodCollection.item(intMethodsIdxId).AnalysisParameters.NumOfDecimalPlaces)
                DtReportData = New DataTable
                DtReportData.TableName = "Quantitative Report"

                DtReportData.Columns.Add(ReportHeader1)
                DtReportData.Columns.Item(0).Caption = "Quantitative Report for"

                DtReportData.Columns.Add(ReportDtCol01)
                DtReportData.Columns.Item(1).Caption = "Run No: "


                DtReportData.Columns.Add(ReportDtCol02)
                DtReportData.Columns.Item(2).Caption = "Analysed On"

                dtRow = DtReportData.NewRow()

                dtRow(0) = strElementName
                dtRow(1) = CStr(.RunNumber)   '  ""
                If (gobjMethodCollection.item(intMethodsIdxId).DateOfLastUse) > Convert.ToDateTime("1/1/1900") Then
                    dtRow(2) = CStr(Format(gobjMethodCollection.item(intMethodsIdxId).DateOfLastUse, "dd-MMM-yyyy hh:mm tt"))   '  ""
                Else
                    dtRow(2) = ""
                End If


                DtReportData.Rows.Add(dtRow)
                Call DtArrDatafile.Add(DtReportData)

                '//**********
                ' Set the object for "Method Definition"
                If gobjMethodCollection.item(intMethodsIdxId).ReportParameters.IsMethodInfo = True Then  '---4.85  12.04.09
                    'If gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection(mlngSelectedRunIndex).ReportParameters.IsMethodInfo = True Then  '---4.85  12.04.09

                    DtMethosDefination = New DataTable
                    DtMethosDefination.TableName = "MethodDefination"

                    DtMethosDefination.Columns.Add(Header1)
                    DtMethosDefination.Columns.Item(0).Caption = "Method Definition"

                    DtMethosDefination.Columns.Add(DtCol01)
                    DtMethosDefination.Columns.Item(1).Caption = "Method Name"

                    DtMethosDefination.Columns.Add(DtCol02)
                    DtMethosDefination.Columns.Item(2).Caption = "Status"

                    DtMethosDefination.Columns.Add(DtCol03)
                    DtMethosDefination.Columns.Item(3).Caption = "Created by"

                    DtMethosDefination.Columns.Add(DtCol04)
                    DtMethosDefination.Columns.Item(4).Caption = "Created on"

                    DtMethosDefination.Columns.Add(DtCol05)
                    DtMethosDefination.Columns.Item(5).Caption = "Changed on"

                    DtMethosDefination.Columns.Add(DtCol06)
                    DtMethosDefination.Columns.Item(6).Caption = "Last used on"

                    DtMethosDefination.Columns.Add(DtCol07)
                    DtMethosDefination.Columns.Item(7).Caption = "Comments"


                    If gobjMethodCollection.item(intMethodsIdxId).OperationMode = EnumOperationMode.MODE_AA Then
                        strMethodMode = "AA Mode"
                    ElseIf gobjMethodCollection.item(intMethodsIdxId).OperationMode = EnumOperationMode.MODE_AABGC Then
                        strMethodMode = "AABGC Mode"
                    ElseIf gobjMethodCollection.item(intMethodsIdxId).OperationMode = EnumOperationMode.MODE_EMMISSION Then
                        strMethodMode = "EMISSION Mode"
                    ElseIf gobjMethodCollection.item(intMethodsIdxId).OperationMode = EnumOperationMode.MODE_UVABS Or
                    gobjMethodCollection.item(intMethodsIdxId).OperationMode = EnumOperationMode.MODE_UVSPECT Then
                        strMethodMode = "UV Mode"
                    End If

                    If gobjMethodCollection.item(intMethodsIdxId).Status = True Then
                        strStatus = "Active"
                    Else
                        strStatus = "Inactive"
                    End If
                    Dim strDateOfModification, strDateOfLastUse As String
                    If Not gobjMethodCollection.item(intMethodsIdxId).DateOfModification = Date.FromOADate(0.0) Then
                        strDateOfModification = Format(gobjMethodCollection.item(intMethodsIdxId).DateOfModification, "dd-MMM-yyyy hh:mm tt")
                    Else
                        strDateOfModification = CStr(Format(gobjMethodCollection.item(intMethodsIdxId).DateOfCreation, "dd-MMM-yyyy hh:mm tt")) '  ""
                    End If
                    If Not gobjMethodCollection.item(intMethodsIdxId).DateOfLastUse = Date.FromOADate(0.0) Then
                        strDateOfLastUse = Format(gobjMethodCollection.item(intMethodsIdxId).DateOfLastUse, "dd-MMM-yyyy hh:mm tt")
                    End If

                    dtRow = DtMethosDefination.NewRow()

                    dtRow(0) = strMethodMode
                    dtRow(1) = CStr(gobjMethodCollection.item(intMethodsIdxId).MethodName)   '  ""
                    dtRow(2) = strStatus
                    dtRow(3) = CStr(gobjMethodCollection.item(intMethodsIdxId).UserName)    '  ""
                    dtRow(4) = CStr(Format(gobjMethodCollection.item(intMethodsIdxId).DateOfCreation, "dd-MMM-yyyy hh:mm tt"))   '  ""
                    dtRow(5) = strDateOfModification    'CStr(Format(gobjMethodCollection.item(intMethodsIdxId).DateOfModification, "dd-MM-yyyy HH:MM"))   '  ""                    

                    dtRow(6) = strDateOfLastUse 'CStr(Format(gobjMethodCollection.item(intInstId).DateOfLastUse, "dd-MM-yyyy HH:MM"))   '  ""
                    dtRow(7) = CStr(gobjMethodCollection.item(intMethodsIdxId).Comments)   '  ""
                    DtMethosDefination.Rows.Add(dtRow)

                    Call DtArrDatafile.Add(DtMethosDefination)

                End If
                ' Set the object for "Analysis Parameters"
                If gobjMethodCollection.item(intMethodsIdxId).ReportParameters.IsAnalysisParameters = True Then
                    DtAnalysisParam = New DataTable

                    DtAnalysisParam.TableName = "AnalysisParameters"
                    Dim AnalysisParamHeader1 As New DataColumn("HeaderDefination", GetType(String))
                    Dim AnalysisParamDtCol01 As New DataColumn("Col01", GetType(String))
                    Dim AnalysisParamDtCol02 As New DataColumn("Col02", GetType(String))
                    Dim AnalysisParamDtCol03 As New DataColumn("Col03", GetType(String))
                    Dim AnalysisParamDtCol04 As New DataColumn("Col04", GetType(String))
                    Dim AnalysisParamDtCol05 As New DataColumn("Col05", GetType(String))
                    Dim AnalysisParamDtCol06 As New DataColumn("Col06", GetType(String))
                    Dim AnalysisParamDtCol07 As New DataColumn("Col07", GetType(String))
                    Dim AnalysisParamDtCol08 As New DataColumn("Col08", GetType(String))
                    Dim AnalysisParamDtCol09 As New DataColumn("Col09", GetType(String))
                    'Dim AnalysisParamDtCol10 As New DataColumn("Col10", GetType(String))

                    DtAnalysisParam.Columns.Add(AnalysisParamHeader1)
                    DtAnalysisParam.Columns.Item(0).Caption = "Analysis Parameters"

                    DtAnalysisParam.Columns.Add(AnalysisParamDtCol01)
                    DtAnalysisParam.Columns.Item(1).Caption = "Analyst's Name"

                    DtAnalysisParam.Columns.Add(AnalysisParamDtCol02)
                    DtAnalysisParam.Columns.Item(2).Caption = "Lab Name"

                    DtAnalysisParam.Columns.Add(AnalysisParamDtCol03)
                    DtAnalysisParam.Columns.Item(3).Caption = "Measurement"

                    DtAnalysisParam.Columns.Add(AnalysisParamDtCol04)
                    DtAnalysisParam.Columns.Item(4).Caption = "Result accuracy"

                    DtAnalysisParam.Columns.Add(AnalysisParamDtCol05)
                    DtAnalysisParam.Columns.Item(5).Caption = "Integration Time"

                    DtAnalysisParam.Columns.Add(AnalysisParamDtCol06)
                    DtAnalysisParam.Columns.Item(6).Caption = "Unit for results"

                    DtAnalysisParam.Columns.Add(AnalysisParamDtCol07)
                    DtAnalysisParam.Columns.Item(7).Caption = "No. of samples"

                    DtAnalysisParam.Columns.Add(AnalysisParamDtCol08)
                    DtAnalysisParam.Columns.Item(8).Caption = "Standard addition"

                    DtAnalysisParam.Columns.Add(AnalysisParamDtCol09)
                    DtAnalysisParam.Columns.Item(9).Caption = "Blank after every sample"

                    If gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).AnalysisParameters.IsBlankAfterEverySampleOrStd = True Then
                        strIsBlank = "Yes"
                    Else
                        strIsBlank = "No"
                    End If
                    Dim strStadardAddtion As String
                    If gobjMethodCollection.item(intMethodsIdxId).StandardAddition = True Then
                        strStadardAddtion = "Yes"
                    Else
                        strStadardAddtion = "No"
                    End If
                    Dim objDtUnits As DataTable
                    Dim objDtMeasurementMode As DataTable


                    objDtUnits = gobjClsAAS203.funcGetUnits()
                    objDtMeasurementMode = gobjClsAAS203.funcGetMeasurementMode()
                    Dim strUnit As String = "ppm"
                    Dim strMeasureMode As String = "Integrate"
                    Dim i As Integer
                    If Not objDtUnits Is Nothing Then
                        If objDtUnits.Rows.Count > 1 Then
                            For i = 0 To objDtUnits.Rows.Count - 1
                                'If gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).AnalysisParameters.Unit = objDtUnits.Rows.Item(i).Item(0) Then
                                If gobjMethodCollection.item(intMethodsIdxId).AnalysisParameters.Unit = objDtUnits.Rows.Item(i).Item(0) Then
                                    strUnit = objDtUnits.Rows.Item(i).Item(1)
                                End If
                            Next
                        End If
                    End If
                    If Not objDtMeasurementMode Is Nothing Then
                        If objDtMeasurementMode.Rows.Count > 1 Then
                            For i = 0 To objDtMeasurementMode.Rows.Count - 1
                                'If gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).AnalysisParameters.Unit = objDtMeasurementMode.Rows.Item(i).Item(0) Then
                                If gobjMethodCollection.item(intMethodsIdxId).AnalysisParameters.Unit = objDtMeasurementMode.Rows.Item(i).Item(0) Then
                                    strMeasureMode = objDtMeasurementMode.Rows.Item(i).Item(1)
                                End If
                            Next
                        End If
                    End If

                    dtRow = DtAnalysisParam.NewRow()

                    dtRow(0) = ""
                    dtRow(1) = CStr(gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).AnalysisParameters.AnalystName)      '  ""
                    dtRow(2) = CStr(gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).AnalysisParameters.LabName)
                    dtRow(3) = strMeasureMode   'CStr(gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mintSelectedRunIndex).AnalysisParameters.MeasurementMode)
                    dtRow(4) = CStr(gobjMethodCollection.item(intMethodsIdxId).AnalysisParameters.NumOfDecimalPlaces) & " (decimals)"
                    dtRow(5) = CStr(gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).AnalysisParameters.IntegrationTime) & " (sec)"
                    dtRow(6) = strUnit.ToLower()   'CStr(gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mintSelectedRunIndex).AnalysisParameters.Unit)
                    dtRow(7) = CStr(gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).AnalysisParameters.NumOfSamples)
                    dtRow(8) = strStadardAddtion
                    dtRow(9) = strIsBlank
                    DtAnalysisParam.Rows.Add(dtRow)
                    Call DtArrDatafile.Add(DtAnalysisParam)
                End If
                '//****************
                ' Set the object for "Instrument Condition"
                If gobjMethodCollection.item(intMethodsIdxId).ReportParameters.IsInstrumentCondition = True Then
                    If Not (.InstrumentParameterForRunNumber Is Nothing) Then

                        DtInstCondition = New DataTable
                        DtInstCondition.TableName = "Instrument Condition"

                        Dim DtInstConditionHeader1 As New DataColumn("HeaderDefination", GetType(String))
                        Dim DtInstConditionDtCol01 As New DataColumn("Col01", GetType(String))
                        Dim DtInstConditionDtCol02 As New DataColumn("Col02", GetType(String))
                        Dim DtInstConditionDtCol03 As New DataColumn("Col03", GetType(String))
                        Dim DtInstConditionDtCol04 As New DataColumn("Col04", GetType(String))
                        Dim DtInstConditionDtCol05 As New DataColumn("Col05", GetType(String))
                        Dim DtInstConditionDtCol06 As New DataColumn("Col06", GetType(String))
                        Dim DtInstConditionDtCol07 As New DataColumn("Col07", GetType(String))
                        Dim DtInstConditionDtCol08 As New DataColumn("Col08", GetType(String))

                        DtInstCondition.Columns.Add(DtInstConditionHeader1)
                        DtInstCondition.Columns.Item(0).Caption = "Instrument Conditions for"
                        If gobjMethodCollection.item(intMethodsIdxId).OperationMode = EnumOperationMode.MODE_UVABS Or
                            gobjMethodCollection.item(intMethodsIdxId).OperationMode = EnumOperationMode.MODE_UVSPECT Then

                            DtInstCondition.Columns.Add(DtInstConditionDtCol02)
                            DtInstCondition.Columns.Item(1).Caption = "Wavelength (nm)"

                            DtInstCondition.Columns.Add(DtInstConditionDtCol03)
                            DtInstCondition.Columns.Item(2).Caption = "Current (mA)"

                            DtInstCondition.Columns.Add(DtInstConditionDtCol04)
                            DtInstCondition.Columns.Item(3).Caption = "Slit (nm)"

                            DtInstCondition.Columns.Add(DtInstConditionDtCol05)
                            DtInstCondition.Columns.Item(4).Caption = "D2 Cur (mA)"

                            DtInstCondition.Columns.Add(DtInstConditionDtCol07)
                            DtInstCondition.Columns.Item(5).Caption = "Pmt (v)"

                        Else

                            DtInstCondition.Columns.Add(DtInstConditionDtCol01)
                            DtInstCondition.Columns.Item(1).Caption = "Turret No"

                            DtInstCondition.Columns.Add(DtInstConditionDtCol02)
                            DtInstCondition.Columns.Item(2).Caption = "Wavelength (nm)"

                            DtInstCondition.Columns.Add(DtInstConditionDtCol03)
                            DtInstCondition.Columns.Item(3).Caption = "Current (mA)"

                            DtInstCondition.Columns.Add(DtInstConditionDtCol04)
                            DtInstCondition.Columns.Item(4).Caption = "Slit (nm)"

                            DtInstCondition.Columns.Add(DtInstConditionDtCol05)
                            DtInstCondition.Columns.Item(5).Caption = "D2 Cur (mA)"

                            DtInstCondition.Columns.Add(DtInstConditionDtCol06)
                            DtInstCondition.Columns.Item(6).Caption = "Fuel(Litre/min)"

                            DtInstCondition.Columns.Add(DtInstConditionDtCol07)
                            DtInstCondition.Columns.Item(7).Caption = "Pmt (v)"

                            DtInstCondition.Columns.Add(DtInstConditionDtCol08)
                            DtInstCondition.Columns.Item(8).Caption = "Burner Height (mm)"
                        End If


                        dtRow = DtInstCondition.NewRow()
                        '//-----
                        'If gobjMethodCollection(intMethodsIdxId).InstrumentCondition.D2Current <= 100 Then
                        '    strD2Curr = "OFF"
                        'Else
                        '    strD2Curr = CStr(gobjMethodCollection(intMethodsIdxId).InstrumentCondition.D2Current)
                        'End If

                        'dtRow(0) = gobjMethodCollection(intMethodsIdxId).InstrumentCondition.ElementName
                        'dtRow(1) = gobjMethodCollection(intMethodsIdxId).InstrumentCondition.TurretNumber.ToString

                        'If gobjMethodCollection(intMethodsIdxId).InstrumentCondition.Wavelength.Rows.Count > 0 Then
                        '    For intCount = 0 To gobjMethodCollection(intMethodsIdxId).InstrumentCondition.Wavelength.Rows.Count - 1
                        '        If gobjMethodCollection(intMethodsIdxId).InstrumentCondition.Wavelength.Rows.Item(intCount).Item(5) Then
                        '            blnWvFound = True
                        '            Exit For
                        '        End If
                        '    Next
                        '    If blnWvFound = True Then
                        '        dtRow(2) = Format(gobjMethodCollection(intMethodsIdxId).InstrumentCondition.Wavelength.Rows.Item(intCount).Item(2), "0.0")
                        '    Else
                        '        dtRow(2) = Format(gobjMethodCollection(intMethodsIdxId).InstrumentCondition.Wavelength.Rows.Item(0).Item(2), "0.0")
                        '    End If
                        'Else
                        '    dtRow(2) = 0.0
                        'End If

                        'dtRow(3) = Format(gobjMethodCollection(intMethodsIdxId).InstrumentCondition.LampCurrent, "0.0")
                        'dtRow(4) = Format(gobjMethodCollection(intMethodsIdxId).InstrumentCondition.SlitWidth, "0.0").ToString
                        'dtRow(5) = strD2Curr
                        'dtRow(6) = Format(gobjMethodCollection(intMethodsIdxId).InstrumentCondition.FuelRatio, "0.00").ToString
                        'dtRow(7) = Format(gobjMethodCollection(intMethodsIdxId).InstrumentCondition.PmtVoltage, "####").ToString
                        'dtRow(8) = Format(gobjMethodCollection(intMethodsIdxId).InstrumentCondition.BurnerHeight, "0.00").ToString
                        '//-----
                        If .InstrumentParameterForRunNumber.D2Current <= 100 Then
                            strD2Curr = "OFF"
                        Else
                            strD2Curr = CStr(.InstrumentParameterForRunNumber.D2Current)
                        End If

                        dtRow(0) = strElementName   '.InstrumentParameterForRunNumber.ElementName
                        If gobjMethodCollection.item(intMethodsIdxId).OperationMode = EnumOperationMode.MODE_UVABS Or
                           gobjMethodCollection.item(intMethodsIdxId).OperationMode = EnumOperationMode.MODE_UVSPECT Then
                            '//----- Modified by Sachin On 31.08.07 Ref. Adding new Wv. field for Emission Mode
                            If gobjMethodCollection.item(intMethodsIdxId).OperationMode = EnumOperationMode.MODE_EMMISSION Then
                                dtRow(1) = FormatNumber(.InstrumentParameterForRunNumber.EmmWavelength, 2)
                            Else
                                '//-----
                                If .InstrumentParameterForRunNumber.Wavelength.Rows.Count > 0 Then
                                    'For intCount = 0 To gobjMethodCollection(intMethodsIdxId).InstrumentCondition.Wavelength.Rows.Count - 1
                                    For intCount = 0 To .InstrumentParameterForRunNumber.Wavelength.Rows.Count - 1
                                        'If gobjMethodCollection(intMethodsIdxId).InstrumentCondition.Wavelength.Rows.Item(intCount).Item(5) Then
                                        If .InstrumentParameterForRunNumber.Wavelength.Rows.Item(intCount).Item(5) Then
                                            blnWvFound = True
                                            Exit For
                                        End If
                                    Next
                                    If blnWvFound = True Then
                                        'dtRow(2) = Format(gobjMethodCollection(intMethodsIdxId).InstrumentCondition.Wavelength.Rows.Item(intCount).Item(2), "0.0")
                                        dtRow(1) = FormatNumber(.InstrumentParameterForRunNumber.Wavelength.Rows.Item(intCount).Item(2), 2)
                                    Else
                                        dtRow(1) = FormatNumber(.InstrumentParameterForRunNumber.Wavelength.Rows.Item(0).Item(2), 2)
                                    End If
                                Else
                                    dtRow(1) = 0.0
                                End If
                            End If
                            'dtRow(3) = FormatNumber(.InstrumentParameterForRunNumber.LampCurrent, 1) 'comment 'by pankaj for lamp current=0 if emmission mode

                            dtRow(2) = FormatNumber(.InstrumentParameterForRunNumber.LampCurrent, 1) 'by pankaj for lamp current=0 if emmission mode
                            dtRow(3) = FormatNumber(.InstrumentParameterForRunNumber.SlitWidth, 1).ToString

                            dtRow(4) = strD2Curr
                            dtRow(5) = Format(.InstrumentParameterForRunNumber.PmtVoltage, "###0.0").ToString
                        Else

                            dtRow(1) = .InstrumentParameterForRunNumber.TurretNumber.ToString

                            '//----- Modified by Sachin On 31.08.07 Ref. Adding new Wv. field for Emission Mode
                            If gobjMethodCollection.item(intMethodsIdxId).OperationMode = EnumOperationMode.MODE_EMMISSION Then
                                dtRow(1) = "-"
                                dtRow(2) = FormatNumber(.InstrumentParameterForRunNumber.EmmWavelength, 2)
                                dtRow(3) = "-"
                                dtRow(5) = "-"
                            Else
                                dtRow(1) = .InstrumentParameterForRunNumber.TurretNumber.ToString
                                '//-----
                                '''If .InstrumentParameterForRunNumber.Wavelength.Rows.Count > 0 Then
                                '''    For intCount = 0 To .InstrumentParameterForRunNumber.Wavelength.Rows.Count - 1
                                '''        If .InstrumentParameterForRunNumber.Wavelength.Rows.Item(intCount).Item(5) Then
                                '''            blnWvFound = True
                                '''            Exit For
                                '''        End If
                                '''    Next
                                '''    If blnWvFound = True Then
                                '''        dtRow(2) = FormatNumber(.InstrumentParameterForRunNumber.Wavelength.Rows.Item(intCount).Item(2), 2)
                                '''    Else
                                '''        dtRow(2) = FormatNumber(.InstrumentParameterForRunNumber.Wavelength.Rows.Item(0).Item(2), 2)
                                '''    End If
                                '''Else
                                '''    dtRow(2) = 0.0
                                '''End If
                                If .InstrumentParameterForRunNumber.Wavelength.Rows.Count > 0 Then
                                    For intCount = 0 To .InstrumentParameterForRunNumber.Wavelength.Rows.Count - 1
                                        If .InstrumentParameterForRunNumber.SelectedWavelengthID = .InstrumentParameterForRunNumber.Wavelength.Rows.Item(intCount).Item(0) Then
                                            dtRow(2) = FormatNumber(.InstrumentParameterForRunNumber.Wavelength.Rows.Item(intCount).Item(2), 2)
                                        End If
                                    Next
                                Else
                                    dtRow(2) = 0.0
                                End If
                                dtRow(5) = strD2Curr
                            End If
                            'dtRow(3) = FormatNumber(.InstrumentParameterForRunNumber.LampCurrent, 1) 'comment 'by pankaj for lamp current=0 if emmission mode
                            If gobjMethodCollection.item(intMethodsIdxId).OperationMode = EnumOperationMode.MODE_EMMISSION Then
                                'dtRow(3) = 0 'by pankaj for lamp current=0 if emmission mode
                                dtRow(4) = FormatNumber(gobjMethodCollection.item(intMethodsIdxId).InstrumentCondition.SlitWidth, 1).ToString
                            Else
                                dtRow(3) = FormatNumber(.InstrumentParameterForRunNumber.LampCurrent, 1) 'by pankaj for lamp current=0 if emmission mode
                                dtRow(4) = FormatNumber(.InstrumentParameterForRunNumber.SlitWidth, 1).ToString
                            End If

                            dtRow(6) = FormatNumber(.InstrumentParameterForRunNumber.FuelRatio, 2).ToString
                            dtRow(7) = Format(.InstrumentParameterForRunNumber.PmtVoltage, "###0.0").ToString

                            'dtRow(8) = FormatNumber(.InstrumentParameterForRunNumber.BurnerHeight, 1).ToString ' code commented by :dinesh wagh on 24.3.2009


                            ' code added by: dinesh wagh on 24.3.2009
                            ' code start
                            If gstructSettings.AppMode = EnumAppMode.DemoMode_201 Or gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                                dtRow(8) = "--"
                            Else
                                dtRow(8) = FormatNumber(.InstrumentParameterForRunNumber.BurnerHeight, 1).ToString
                            End If
                            ' code ends



                        End If

                        DtInstCondition.Rows.Add(dtRow)

                        Call DtArrDatafile.Add(DtInstCondition)
                    End If
                End If
                '//*******************
                ' Set the object for "Calculation Mode"
                DtCalculationMode = New DataTable
                DtCalculationMode.TableName = "Calculation Mode"

                DtCalculationMode.Columns.Add(CalculationModeHeader)
                DtCalculationMode.Columns.Item(0).Caption = ""

                DtCalculationMode.Columns.Add(CalculationModeDtCol01)
                DtCalculationMode.Columns.Item(1).Caption = "Calculation Mode "



                If .CalculationMode = clsQuantitativeData.enumCalculationMode.CUBIC Then
                    strCalculationMode = "CUBIC"
                ElseIf .CalculationMode = clsQuantitativeData.enumCalculationMode.DIRECT Then
                    strCalculationMode = "DIRECT"
                ElseIf .CalculationMode = clsQuantitativeData.enumCalculationMode.FIFTH_ORDER Then
                    strCalculationMode = "FIFTH_ORDER"
                ElseIf .CalculationMode = clsQuantitativeData.enumCalculationMode.FOURTH_ORDER Then
                    strCalculationMode = "FOURTH_ORDER"
                ElseIf .CalculationMode = clsQuantitativeData.enumCalculationMode.LINEAR Then
                    strCalculationMode = "LINEAR"
                ElseIf .CalculationMode = clsQuantitativeData.enumCalculationMode.QUADRATIC Then
                    strCalculationMode = "QUADRATIC"
                ElseIf .CalculationMode = clsQuantitativeData.enumCalculationMode.RATIONAL Then
                    strCalculationMode = "RATIOMETRIC"
                End If

                dtRow = DtCalculationMode.NewRow()

                dtRow(0) = ""
                dtRow(1) = strCalculationMode

                DtCalculationMode.Rows.Add(dtRow)

                Call DtArrDatafile.Add(DtCalculationMode)
                '//****************

                ' Set the object for detail info "Standard/Sample Information"
                DtStdSampleData = New DataTable

                DtStdSampleData.TableName = "Standard/Sample Information"

                Dim StdSampleDtCol01 As New DataColumn("Col01", GetType(String))
                Dim StdSampleDtCol02 As New DataColumn("Col02", GetType(String))
                Dim StdSampleDtCol03 As New DataColumn("Col03", GetType(String))
                Dim StdSampleDtCol04 As New DataColumn("Col04", GetType(String))
                Dim StdSampleDtCol05 As New DataColumn("Col05", GetType(String))
                Dim StdSampleDtCol06 As New DataColumn("Col06", GetType(String))
                Dim StdSampleDtCol07 As New DataColumn("Col07", GetType(String))

                'Dim StdSampleDtCol08 As New DataColumn("Col08", GetType(String))
                'Dim StdSampleDtCol09 As New DataColumn("Col09", GetType(String))
                'Dim StdSampleDtCol10 As New DataColumn("Col10", GetType(String))
                Dim intColIndexCount As Integer = 0
                Dim unit As Integer
                intColIndexCount = 0
                DtStdSampleData.Columns.Add(StdSampleDtCol01)
                DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Std/Sample Name"
                intColIndexCount += 1

                'unit = .AnalysisParameters.Unit
                unit = gobjMethodCollection.item(intMethodsIdxId).AnalysisParameters.Unit()

                If gobjMethodCollection.item(intMethodsIdxId).ReportParameters.IsWeightVolumeDilution = True Then
                    DtStdSampleData.Columns.Add(StdSampleDtCol02)
                    DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Weight (gms)"
                    intColIndexCount += 1
                    DtStdSampleData.Columns.Add(StdSampleDtCol03)
                    DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Volume (ml)"
                    intColIndexCount += 1
                    DtStdSampleData.Columns.Add(StdSampleDtCol04)
                    DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Dilution Factor"
                    intColIndexCount += 1
                End If

                If gobjMethodCollection.item(intMethodsIdxId).ReportParameters.IsAbsorbance = True Then
                    DtStdSampleData.Columns.Add(StdSampleDtCol05)
                    If gobjMethodCollection.item(intMethodsIdxId).OperationMode = EnumOperationMode.MODE_EMMISSION Then
                        'DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Emission"     ' Added by Sachin Dokhale on ref. VCK
                        DtStdSampleData.Columns.Item(intColIndexCount).Caption = "%E"     ' Added by Deepak Bhati with ref. to VCK/Ramesh on 26.07.09
                    Else
                        DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Abs."
                    End If
                    intColIndexCount += 1
                End If

                DtStdSampleData.Columns.Add(StdSampleDtCol06)

                '---commented on 27.03.09
                ''DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Conc. (ppm)"
                '-------------

                '---written on 27.03.09
                If unit = enumUnit.PPB Then
                    DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Conc. (ppb)"
                Else
                    DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Conc. (ppm)"
                End If
                '---------


                intColIndexCount += 1
                DtStdSampleData.Columns.Add(StdSampleDtCol07)

                ''' code commenented by : dinesh wagh on 27.3.2009
                '''.......
                ''If unit = 1 Then
                ''    DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Conc. in ppm"
                ''Else
                ''    'DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Conc.in Unit"
                ''    DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Conc. in %"
                ''End If
                '''........

                ' code added by :dinesh wagh on 27.3.2009
                ' code start
                If unit = enumUnit.PPM Then
                    DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Conc. in " & vbCrLf & "Sample" & vbCrLf & "(ppm)"
                ElseIf unit = enumUnit.Percent Then
                    'DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Conc.in Unit"
                    DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Conc.in" & vbCrLf & "Sample" & vbCrLf & "(%)"
                ElseIf unit = enumUnit.PPB Then
                    DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Conc.in" & vbCrLf & "Sample" & vbCrLf & "(ppb)"
                End If
                'code ends

                intCount = 0
                If gobjMethodCollection.item(intMethodsIdxId).ReportParameters.IsStandards = True Then
                    If gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).StandardDataCollection.Count > 0 Then
                        Do While intCount < gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).StandardDataCollection.Count
                            If (.StandardDataCollection(intCount).Abs > -0.2) And (.StandardDataCollection(intCount).Used = True) Then
                                dtRow = DtStdSampleData.NewRow()
                                intColIndexCount = 0
                                dtRow(intColIndexCount) = CStr(.StandardDataCollection(intCount).StdName)       '  ""

                                If gobjMethodCollection.item(intMethodsIdxId).ReportParameters.IsWeightVolumeDilution = True Then
                                    intColIndexCount += 1
                                    dtRow(intColIndexCount) = "-"
                                    intColIndexCount += 1
                                    dtRow(intColIndexCount) = "-"
                                    intColIndexCount += 1
                                    dtRow(intColIndexCount) = "-"
                                End If

                                If gobjMethodCollection.item(intMethodsIdxId).ReportParameters.IsAbsorbance = True Then
                                    intColIndexCount += 1
                                    'dtRow(intColIndexCount) = CStr(FormatNumber(.StandardDataCollection(intCount).Abs, intNoOfDecimalPlaces))
                                    If gobjMethodCollection.item(intMethodsIdxId).OperationMode = EnumOperationMode.MODE_EMMISSION Then
                                        dtRow(intColIndexCount) = CStr(FormatNumber(.StandardDataCollection(intCount).Abs, 1))
                                    Else
                                        dtRow(intColIndexCount) = CStr(FormatNumber(.StandardDataCollection(intCount).Abs, 3))
                                    End If

                                End If

                                intColIndexCount += 1
                                dtRow(intColIndexCount) = CStr(FormatNumber(.StandardDataCollection(intCount).Concentration, intNoOfDecimalPlaces))
                                intColIndexCount += 1
                                ' dtRow(intColIndexCount) = CStr(Format(.StandardDataCollection(intCount).Concentration, "0.000"))
                                dtRow(intColIndexCount) = ""
                                'dtRow(7) = ""
                                DtStdSampleData.Rows.Add(dtRow)
                            End If
                            intCount += 1
                        Loop
                    End If
                End If
                ' Set the object for detail info "Sample Information"
                intCount = 0
                If gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).SampleDataCollection.Count > 0 Then
                    Do While intCount < gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).SampleDataCollection.Count
                        If (.SampleDataCollection(intCount).Abs > -0.2) And (.SampleDataCollection(intCount).Used = True) Then
                            dtRow = DtStdSampleData.NewRow()
                            intColIndexCount = 0
                            'dtRow(intColIndexCount) = CStr(.SampleDataCollection(intCount).SampleName)         '  ""
                            dtRow(intColIndexCount) = CStr(gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).SampleName)         '  ""

                            If gobjMethodCollection.item(intMethodsIdxId).ReportParameters.IsWeightVolumeDilution = True Then
                                intColIndexCount += 1
                                'dtRow(intColIndexCount) = CStr(gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).Weight)
                                'By PAnkaj for formatting upto 4 digit
                                dtRow(intColIndexCount) = CStr(FormatNumber(gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).Weight, intNoOfDecimalPlaces))
                                intColIndexCount += 1
                                dtRow(intColIndexCount) = CStr(FormatNumber(gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).Volume, intNoOfDecimalPlaces))
                                intColIndexCount += 1
                                dtRow(intColIndexCount) = CStr(FormatNumber(gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).DilutionFactor, intNoOfDecimalPlaces))
                            End If
                            If gobjMethodCollection.item(intMethodsIdxId).ReportParameters.IsAbsorbance = True Then
                                intColIndexCount += 1
                                If gobjMethodCollection.item(intMethodsIdxId).OperationMode = EnumOperationMode.MODE_EMMISSION Then
                                    dtRow(intColIndexCount) = CStr(FormatNumber(.SampleDataCollection(intCount).Abs, 1))
                                Else
                                    dtRow(intColIndexCount) = CStr(FormatNumber(.SampleDataCollection(intCount).Abs, 3))
                                End If
                            End If
                            Dim dblConcInPercent As Double
                            Dim dblConc As Double
                            dblConcInPpm = 0.0
                            intColIndexCount += 1
                            '//----- added by Sachin Dokhale on 29.05.07
                            'dblConc = Format(gobjclsStandardGraph.Get_Conc(.SampleDataCollection(intCount).Abs, 0.0), "0.000")
                            If gobjMethodCollection.item(intMethodsIdxId).StandardAddition = True Then
                                dblConc = CStr(.SampleDataCollection(intCount).Conc)
                            Else
                                dblConc = gobjclsStandardGraph.Get_Conc(.SampleDataCollection(intCount).Abs, 0.0)
                            End If

                            'dblConc = .SampleDataCollection(intCount).Conc
                            'dtRow(intColIndexCount) = CStr(Format(.SampleDataCollection(intCount).Conc, "0.000"))
                            dtRow(intColIndexCount) = FormatNumber(dblConc, intNoOfDecimalPlaces)
                            intColIndexCount += 1
                            'dtRow(intColIndexCount) = CStr(Format(.SampleDataCollection(intCount).Conc, "0.000"))

                            'Dim dblConcInPercent As Double


                            '---27.03.09
                            ''If unit = 1 Then
                            ''    'dtRow(intColIndexCount) = CStr(FormatNumber(dblConc, intNoOfDecimalPlaces))
                            ''    dblConcInPpm = (dblConc * gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).Volume * gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).DilutionFactor) / gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).Weight
                            ''    dtRow(intColIndexCount) = CStr(FormatNumber(dblConcInPpm, intNoOfDecimalPlaces))
                            ''Else
                            ''    'dblConcInPercent = (dblConc * gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).Volume * gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).DilutionFactor * Math.Pow(10, -6)) / gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).Weight
                            ''    dblConcInPercent = (dblConc * gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).Volume * gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).DilutionFactor * Math.Pow(10, -6)) / gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).Weight
                            ''    dblConcInPercent = dblConcInPercent * 100
                            ''    'dtRow(7) = ""
                            ''    'dtRow(intColIndexCount) = CStr(Format(.SampleDataCollection(intCount).Conc, "###0.00#####"))
                            ''    dtRow(intColIndexCount) = CStr(FormatNumber(dblConcInPercent, intNoOfDecimalPlaces))
                            ''End If
                            '-----

                            '---27.03.09
                            If unit = enumUnit.PPM Then
                                dblConcInPpm = (dblConc * gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).Volume * gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).DilutionFactor) / gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).Weight
                                dtRow(intColIndexCount) = CStr(FormatNumber(dblConcInPpm, intNoOfDecimalPlaces))
                            ElseIf unit = enumUnit.Percent Then
                                dblConcInPercent = (dblConc * gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).Volume * gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).DilutionFactor * Math.Pow(10, -6)) / gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).Weight
                                dblConcInPercent = dblConcInPercent * 100
                                dtRow(intColIndexCount) = CStr(FormatNumber(dblConcInPercent, intNoOfDecimalPlaces))
                            ElseIf unit = enumUnit.PPB Then
                                dblConcInPpm = (dblConc * gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).Volume * gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).DilutionFactor) / gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).Weight
                                dtRow(intColIndexCount) = CStr(FormatNumber(dblConcInPpm, intNoOfDecimalPlaces))
                            End If
                            '--------------


                            'dblConcInPercent = (dblConc * samp.Volume * samp.DilutionFactor * Math.Pow(10, -6)) / samp.Weight

                            DtStdSampleData.Rows.Add(dtRow)
                        End If
                        intCount += 1
                    Loop
                End If
                '//***************
                blnGetHeaderFooter = gobjMethodCollection.item(intMethodsIdxId).ReportParameters.IsReportHeaderAndFooter

                'Add the result objects into array list
                Call ArrListMoreTabularData.Add(DtStdSampleData)
                Call ArrListMoreTabularData.Add(gobjMethodCollection.item(intMethodsIdxId).ReportParameters.ReportHeader)
                Call ArrListMoreTabularData.Add(gobjMethodCollection.item(intMethodsIdxId).ReportParameters.ReportFooter)
            End With

            funcSetDatafileTable = True

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
            If Not DtMethosDefination Is Nothing Then
                DtMethosDefination = Nothing
            End If
            If Not DtAnalysisParam Is Nothing Then
                DtAnalysisParam = Nothing
            End If
            If Not DtInstCondition Is Nothing Then
                DtInstCondition = Nothing
            End If
            If Not DtStdSampleData Is Nothing Then
                DtStdSampleData = Nothing
            End If
            If Not DtReportData Is Nothing Then
                DtReportData = Nothing
            End If
            If Not DtCalculationMode Is Nothing Then
                DtCalculationMode = Nothing
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Private Function funcSetDatafileTableForMethod(ByRef ArrListMoreTabularData As ArrayList, ByRef DtArrDatafile As ArrayList, Optional ByRef blnGetHeaderFooter As Boolean = False) As Boolean
        '=====================================================================
        ' Procedure Name        :   funcSetDatafileTableForMethod
        ' Parameters Passed     : 
        ' Parameters Affected   : ArrListMoreTabularData As ArrayList,DtArrDatafile As ArrayList,
        '                       : blnGetHeaderFooter
        ' Returns               : True if success
        ' Purpose               : Set data file results into array object to the print object
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                :   pankaj bamb
        ' Created               : 21 feb 08
        ' Revisions             : 
        '=====================================================================

        Dim strMethodMode As String
        Dim strStatus As String
        Dim strIsBlank As String
        Dim strD2Curr As String
        Dim strCalculationMode As String
        Dim strElementName As String

        Dim intCount As Integer
        Dim DtMethosDefination As DataTable
        Dim DtAnalysisParam As DataTable
        Dim DtInstCondition As DataTable
        Dim DtStdSampleData As DataTable
        Dim DtReportData As DataTable
        Dim DtCalculationMode As DataTable
        Dim objDtElements As DataTable
        Dim blnWvFound As Boolean
        Dim intNoOfDecimalPlaces As Integer
        Dim dblConcInPpm As Double
        Dim intCounter As Integer
        Try
            funcSetDatafileTableForMethod = False
            If mlngSelectedRunNumber = 0 Then
                Return False
            End If
            '--- Data table property declaration
            Dim ReportHeader1 As New DataColumn("HeaderDefination", GetType(String))
            Dim ReportDtCol01 As New DataColumn("Col01", GetType(String))
            Dim ReportDtCol02 As New DataColumn("Col02", GetType(String))


            Dim CalculationModeHeader As New DataColumn("HeaderDefination", GetType(String))
            Dim CalculationModeDtCol01 As New DataColumn("Col01", GetType(String))

            Dim Header1 As New DataColumn("HeaderDefination", GetType(String))
            Dim DtCol01 As New DataColumn("Col01", GetType(String))
            Dim DtCol02 As New DataColumn("Col02", GetType(String))
            Dim DtCol03 As New DataColumn("Col03", GetType(String))
            Dim DtCol04 As New DataColumn("Col04", GetType(String))
            Dim DtCol05 As New DataColumn("Col05", GetType(String))
            Dim DtCol06 As New DataColumn("Col06", GetType(String))
            Dim DtCol07 As New DataColumn("Col07", GetType(String))
            Dim DtCol08 As New DataColumn("Col08", GetType(String))
            Dim DtCol09 As New DataColumn("Col09", GetType(String))
            Dim DtCol10 As New DataColumn("Col10", GetType(String))
            '--- Data row 
            Dim dtRow As DataRow


            '//----- Search Element ID
            For intCount = 0 To gobjMethodCollection.Count - 1
                If gobjMethodCollection.item(intCount).MethodID = mintSelectedMethodID Then
                    intMethodsIdxId = intCount
                    For intCounter = 0 To gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Count - 1
                        If gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection(intCounter).RunNumber = mlngSelectedRunNumber Then
                            mlngSelectedRunIndex = intCounter
                            Exit For
                        End If
                    Next
                End If
            Next

            If mlngSelectedRunIndex = -1 Then
                Return False
            End If
            '--- Detect Enement name from data table
            objDtElements = gobjDataAccess.GetCookBookData(gobjMethodCollection.item(intMethodsIdxId).InstrumentCondition.ElementID)
            If Not objDtElements Is Nothing Then
                If objDtElements.Rows.Count > 0 Then
                    strElementName = objDtElements.Rows(0).Item(ConstColumnElementName)
                End If
                objDtElements = Nothing
            End If

            If gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Count <= 0 Then
                Return True
            End If

            With gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection(mlngSelectedRunIndex)
                ' Set the object for titel "Quantitative Report" 
                intNoOfDecimalPlaces = CInt(gobjMethodCollection.item(intMethodsIdxId).AnalysisParameters.NumOfDecimalPlaces)
                DtReportData = New DataTable
                DtReportData.TableName = "Quantitative Report"

                DtReportData.Columns.Add(ReportHeader1)
                DtReportData.Columns.Item(0).Caption = "Quantitative Report for"

                DtReportData.Columns.Add(ReportDtCol01)
                DtReportData.Columns.Item(1).Caption = "Run No: "


                DtReportData.Columns.Add(ReportDtCol02)
                DtReportData.Columns.Item(2).Caption = "Analysed On"

                dtRow = DtReportData.NewRow()

                dtRow(0) = strElementName
                dtRow(1) = CStr(.RunNumber)   '  ""
                If (gobjMethodCollection.item(intMethodsIdxId).DateOfLastUse) > Convert.ToDateTime("1/1/1900") Then
                    'dtRow(2) = CStr(Format(gobjMethodCollection.item(intMethodsIdxId).DateOfLastUse, "dd-MMM-yyyy hh:mm tt"))   '  "" 'commented by ; dinesh wagh on 10.2.2010
                    dtRow(2) = CStr(Format(gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection(mlngSelectedRunIndex).AnalysisParameters.Analysis_Date, "dd-MMM-yyyy hh:mm tt"))  'code added by ; dinesh wagh on 10.2.2010

                Else
                    dtRow(2) = ""
                End If


                DtReportData.Rows.Add(dtRow)
                Call DtArrDatafile.Add(DtReportData)

                '//**********
                ' Set the object for "Method Definition"
                'If gobjMethodCollection.item(intInstId).ReportParameters.IsMethodInfo = True Then
                If gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection(mlngSelectedRunIndex).ReportParameters.IsMethodInfo = True Then

                    DtMethosDefination = New DataTable
                    DtMethosDefination.TableName = "MethodDefination"

                    DtMethosDefination.Columns.Add(Header1)
                    DtMethosDefination.Columns.Item(0).Caption = "Method Definition"

                    DtMethosDefination.Columns.Add(DtCol01)
                    DtMethosDefination.Columns.Item(1).Caption = "Method Name"

                    DtMethosDefination.Columns.Add(DtCol02)
                    DtMethosDefination.Columns.Item(2).Caption = "Status"

                    DtMethosDefination.Columns.Add(DtCol03)
                    DtMethosDefination.Columns.Item(3).Caption = "Created by"

                    DtMethosDefination.Columns.Add(DtCol04)
                    DtMethosDefination.Columns.Item(4).Caption = "Created on"

                    DtMethosDefination.Columns.Add(DtCol05)
                    DtMethosDefination.Columns.Item(5).Caption = "Changed on"

                    DtMethosDefination.Columns.Add(DtCol06)
                    DtMethosDefination.Columns.Item(6).Caption = "Last used on"

                    DtMethosDefination.Columns.Add(DtCol07)
                    DtMethosDefination.Columns.Item(7).Caption = "Comments"


                    If gobjMethodCollection.item(intMethodsIdxId).OperationMode = EnumOperationMode.MODE_AA Then
                        strMethodMode = "AA Mode"
                    ElseIf gobjMethodCollection.item(intMethodsIdxId).OperationMode = EnumOperationMode.MODE_AABGC Then
                        strMethodMode = "AABGC Mode"
                    ElseIf gobjMethodCollection.item(intMethodsIdxId).OperationMode = EnumOperationMode.MODE_EMMISSION Then
                        strMethodMode = "EMISSION Mode"
                    ElseIf gobjMethodCollection.item(intMethodsIdxId).OperationMode = EnumOperationMode.MODE_UVABS Or
                    gobjMethodCollection.item(intMethodsIdxId).OperationMode = EnumOperationMode.MODE_UVSPECT Then
                        strMethodMode = "UV Mode"
                    End If

                    If gobjMethodCollection.item(intMethodsIdxId).Status = True Then
                        strStatus = "Active"
                    Else
                        strStatus = "Inactive"
                    End If
                    Dim strDateOfModification, strDateOfLastUse As String
                    If Not gobjMethodCollection.item(intMethodsIdxId).DateOfModification = Date.FromOADate(0.0) Then
                        strDateOfModification = Format(gobjMethodCollection.item(intMethodsIdxId).DateOfModification, "dd-MMM-yyyy hh:mm tt")
                    Else
                        strDateOfModification = CStr(Format(gobjMethodCollection.item(intMethodsIdxId).DateOfCreation, "dd-MMM-yyyy hh:mm tt")) '  ""
                    End If
                    If Not gobjMethodCollection.item(intMethodsIdxId).DateOfLastUse = Date.FromOADate(0.0) Then
                        strDateOfLastUse = Format(gobjMethodCollection.item(intMethodsIdxId).DateOfLastUse, "dd-MMM-yyyy hh:mm tt")
                    End If

                    dtRow = DtMethosDefination.NewRow()

                    dtRow(0) = strMethodMode
                    dtRow(1) = CStr(gobjMethodCollection.item(intMethodsIdxId).MethodName)   '  ""
                    dtRow(2) = strStatus
                    dtRow(3) = CStr(gobjMethodCollection.item(intMethodsIdxId).UserName)    '  ""
                    dtRow(4) = CStr(Format(gobjMethodCollection.item(intMethodsIdxId).DateOfCreation, "dd-MMM-yyyy hh:mm tt"))   '  ""
                    dtRow(5) = strDateOfModification    'CStr(Format(gobjMethodCollection.item(intMethodsIdxId).DateOfModification, "dd-MM-yyyy HH:MM"))   '  ""                    

                    dtRow(6) = strDateOfLastUse 'CStr(Format(gobjMethodCollection.item(intInstId).DateOfLastUse, "dd-MM-yyyy HH:MM"))   '  ""
                    dtRow(7) = CStr(gobjMethodCollection.item(intMethodsIdxId).Comments)   '  ""
                    DtMethosDefination.Rows.Add(dtRow)

                    Call DtArrDatafile.Add(DtMethosDefination)

                End If
                ' Set the object for "Analysis Parameters"

                'If gobjMethodCollection.item(intMethodsIdxId).ReportParameters.IsAnalysisParameters = True Then '4.85 12.04.09
                If gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection(mlngSelectedRunIndex).ReportParameters.IsAnalysisParameters = True Then   '4.85 12.04.09

                    DtAnalysisParam = New DataTable

                    DtAnalysisParam.TableName = "AnalysisParameters"
                    Dim AnalysisParamHeader1 As New DataColumn("HeaderDefination", GetType(String))
                    Dim AnalysisParamDtCol01 As New DataColumn("Col01", GetType(String))
                    Dim AnalysisParamDtCol02 As New DataColumn("Col02", GetType(String))
                    Dim AnalysisParamDtCol03 As New DataColumn("Col03", GetType(String))
                    Dim AnalysisParamDtCol04 As New DataColumn("Col04", GetType(String))
                    Dim AnalysisParamDtCol05 As New DataColumn("Col05", GetType(String))
                    Dim AnalysisParamDtCol06 As New DataColumn("Col06", GetType(String))
                    Dim AnalysisParamDtCol07 As New DataColumn("Col07", GetType(String))
                    Dim AnalysisParamDtCol08 As New DataColumn("Col08", GetType(String))
                    Dim AnalysisParamDtCol09 As New DataColumn("Col09", GetType(String))
                    'Dim AnalysisParamDtCol10 As New DataColumn("Col10", GetType(String))

                    DtAnalysisParam.Columns.Add(AnalysisParamHeader1)
                    DtAnalysisParam.Columns.Item(0).Caption = "Analysis Parameters"

                    DtAnalysisParam.Columns.Add(AnalysisParamDtCol01)
                    DtAnalysisParam.Columns.Item(1).Caption = "Analyst's Name"

                    DtAnalysisParam.Columns.Add(AnalysisParamDtCol02)
                    DtAnalysisParam.Columns.Item(2).Caption = "Lab Name"

                    DtAnalysisParam.Columns.Add(AnalysisParamDtCol03)
                    DtAnalysisParam.Columns.Item(3).Caption = "Measurement"

                    DtAnalysisParam.Columns.Add(AnalysisParamDtCol04)
                    DtAnalysisParam.Columns.Item(4).Caption = "Result accuracy"

                    DtAnalysisParam.Columns.Add(AnalysisParamDtCol05)
                    DtAnalysisParam.Columns.Item(5).Caption = "Integration Time"

                    DtAnalysisParam.Columns.Add(AnalysisParamDtCol06)
                    DtAnalysisParam.Columns.Item(6).Caption = "Unit for results"

                    DtAnalysisParam.Columns.Add(AnalysisParamDtCol07)
                    DtAnalysisParam.Columns.Item(7).Caption = "No. of samples"

                    DtAnalysisParam.Columns.Add(AnalysisParamDtCol08)
                    DtAnalysisParam.Columns.Item(8).Caption = "Standard addition"

                    DtAnalysisParam.Columns.Add(AnalysisParamDtCol09)
                    DtAnalysisParam.Columns.Item(9).Caption = "Blank after every sample"

                    If gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).AnalysisParameters.IsBlankAfterEverySampleOrStd = True Then
                        strIsBlank = "Yes"
                    Else
                        strIsBlank = "No"
                    End If
                    Dim strStadardAddtion As String
                    If gobjMethodCollection.item(intMethodsIdxId).StandardAddition = True Then
                        strStadardAddtion = "Yes"
                    Else
                        strStadardAddtion = "No"
                    End If
                    Dim objDtUnits As DataTable
                    Dim objDtMeasurementMode As DataTable


                    objDtUnits = gobjClsAAS203.funcGetUnits()
                    objDtMeasurementMode = gobjClsAAS203.funcGetMeasurementMode()
                    Dim strUnit As String = "ppm"
                    Dim strMeasureMode As String = "Integrate"
                    Dim i As Integer
                    If Not objDtUnits Is Nothing Then
                        If objDtUnits.Rows.Count > 1 Then
                            For i = 0 To objDtUnits.Rows.Count - 1
                                'If gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).AnalysisParameters.Unit = objDtUnits.Rows.Item(i).Item(0) Then
                                If gobjMethodCollection.item(intMethodsIdxId).AnalysisParameters.Unit = objDtUnits.Rows.Item(i).Item(0) Then
                                    strUnit = objDtUnits.Rows.Item(i).Item(1)
                                End If
                            Next
                        End If
                    End If
                    If Not objDtMeasurementMode Is Nothing Then
                        If objDtMeasurementMode.Rows.Count > 1 Then
                            For i = 0 To objDtMeasurementMode.Rows.Count - 1
                                'If gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).AnalysisParameters.Unit = objDtMeasurementMode.Rows.Item(i).Item(0) Then
                                If gobjMethodCollection.item(intMethodsIdxId).AnalysisParameters.Unit = objDtMeasurementMode.Rows.Item(i).Item(0) Then
                                    strMeasureMode = objDtMeasurementMode.Rows.Item(i).Item(1)
                                End If
                            Next
                        End If
                    End If

                    dtRow = DtAnalysisParam.NewRow()

                    dtRow(0) = ""
                    dtRow(1) = CStr(gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).AnalysisParameters.AnalystName)      '  ""
                    dtRow(2) = CStr(gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).AnalysisParameters.LabName)
                    dtRow(3) = strMeasureMode   'CStr(gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mintSelectedRunIndex).AnalysisParameters.MeasurementMode)
                    dtRow(4) = CStr(gobjMethodCollection.item(intMethodsIdxId).AnalysisParameters.NumOfDecimalPlaces) & " (decimals)"
                    dtRow(5) = CStr(gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).AnalysisParameters.IntegrationTime) & " (sec)"
                    dtRow(6) = strUnit.ToLower()   'CStr(gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mintSelectedRunIndex).AnalysisParameters.Unit)
                    dtRow(7) = CStr(gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).AnalysisParameters.NumOfSamples)
                    dtRow(8) = strStadardAddtion
                    dtRow(9) = strIsBlank
                    DtAnalysisParam.Rows.Add(dtRow)
                    Call DtArrDatafile.Add(DtAnalysisParam)
                End If
                '//****************
                ' Set the object for "Instrument Condition"

                'If gobjMethodCollection.item(intMethodsIdxId).ReportParameters.IsInstrumentCondition = True Then   '4.85 12.04.09
                If gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection(mlngSelectedRunIndex).ReportParameters.IsInstrumentCondition = True Then  '4.85 12.04.09

                    If Not (.InstrumentParameterForRunNumber Is Nothing) Then

                        DtInstCondition = New DataTable
                        DtInstCondition.TableName = "Instrument Condition"

                        Dim DtInstConditionHeader1 As New DataColumn("HeaderDefination", GetType(String))
                        Dim DtInstConditionDtCol01 As New DataColumn("Col01", GetType(String))
                        Dim DtInstConditionDtCol02 As New DataColumn("Col02", GetType(String))
                        Dim DtInstConditionDtCol03 As New DataColumn("Col03", GetType(String))
                        Dim DtInstConditionDtCol04 As New DataColumn("Col04", GetType(String))
                        Dim DtInstConditionDtCol05 As New DataColumn("Col05", GetType(String))
                        Dim DtInstConditionDtCol06 As New DataColumn("Col06", GetType(String))
                        Dim DtInstConditionDtCol07 As New DataColumn("Col07", GetType(String))
                        Dim DtInstConditionDtCol08 As New DataColumn("Col08", GetType(String))

                        DtInstCondition.Columns.Add(DtInstConditionHeader1)
                        DtInstCondition.Columns.Item(0).Caption = "Instrument Conditions for"
                        If gobjMethodCollection.item(intMethodsIdxId).OperationMode = EnumOperationMode.MODE_UVABS Or
                            gobjMethodCollection.item(intMethodsIdxId).OperationMode = EnumOperationMode.MODE_UVSPECT Then

                            DtInstCondition.Columns.Add(DtInstConditionDtCol02)
                            DtInstCondition.Columns.Item(1).Caption = "Wavelength (nm)"

                            DtInstCondition.Columns.Add(DtInstConditionDtCol03)
                            DtInstCondition.Columns.Item(2).Caption = "Current (mA)"

                            DtInstCondition.Columns.Add(DtInstConditionDtCol04)
                            DtInstCondition.Columns.Item(3).Caption = "Slit (nm)"

                            DtInstCondition.Columns.Add(DtInstConditionDtCol05)
                            DtInstCondition.Columns.Item(4).Caption = "D2 Cur (mA)"

                            DtInstCondition.Columns.Add(DtInstConditionDtCol07)
                            DtInstCondition.Columns.Item(5).Caption = "Pmt (v)"

                        Else

                            DtInstCondition.Columns.Add(DtInstConditionDtCol01)
                            DtInstCondition.Columns.Item(1).Caption = "Turret No"

                            DtInstCondition.Columns.Add(DtInstConditionDtCol02)
                            DtInstCondition.Columns.Item(2).Caption = "Wavelength (nm)"

                            DtInstCondition.Columns.Add(DtInstConditionDtCol03)
                            DtInstCondition.Columns.Item(3).Caption = "Current (mA)"

                            DtInstCondition.Columns.Add(DtInstConditionDtCol04)
                            DtInstCondition.Columns.Item(4).Caption = "Slit (nm)"

                            DtInstCondition.Columns.Add(DtInstConditionDtCol05)
                            DtInstCondition.Columns.Item(5).Caption = "D2 Cur (mA)"

                            DtInstCondition.Columns.Add(DtInstConditionDtCol06)
                            DtInstCondition.Columns.Item(6).Caption = "Fuel(Litre/min)"

                            DtInstCondition.Columns.Add(DtInstConditionDtCol07)
                            DtInstCondition.Columns.Item(7).Caption = "Pmt (v)"

                            DtInstCondition.Columns.Add(DtInstConditionDtCol08)
                            DtInstCondition.Columns.Item(8).Caption = "Burner Height (mm)"
                        End If


                        dtRow = DtInstCondition.NewRow()
                        '//-----
                        'If gobjMethodCollection(intMethodsIdxId).InstrumentCondition.D2Current <= 100 Then
                        '    strD2Curr = "OFF"
                        'Else
                        '    strD2Curr = CStr(gobjMethodCollection(intMethodsIdxId).InstrumentCondition.D2Current)
                        'End If

                        'dtRow(0) = gobjMethodCollection(intMethodsIdxId).InstrumentCondition.ElementName
                        'dtRow(1) = gobjMethodCollection(intMethodsIdxId).InstrumentCondition.TurretNumber.ToString

                        'If gobjMethodCollection(intMethodsIdxId).InstrumentCondition.Wavelength.Rows.Count > 0 Then
                        '    For intCount = 0 To gobjMethodCollection(intMethodsIdxId).InstrumentCondition.Wavelength.Rows.Count - 1
                        '        If gobjMethodCollection(intMethodsIdxId).InstrumentCondition.Wavelength.Rows.Item(intCount).Item(5) Then
                        '            blnWvFound = True
                        '            Exit For
                        '        End If
                        '    Next
                        '    If blnWvFound = True Then
                        '        dtRow(2) = Format(gobjMethodCollection(intMethodsIdxId).InstrumentCondition.Wavelength.Rows.Item(intCount).Item(2), "0.0")
                        '    Else
                        '        dtRow(2) = Format(gobjMethodCollection(intMethodsIdxId).InstrumentCondition.Wavelength.Rows.Item(0).Item(2), "0.0")
                        '    End If
                        'Else
                        '    dtRow(2) = 0.0
                        'End If

                        'dtRow(3) = Format(gobjMethodCollection(intMethodsIdxId).InstrumentCondition.LampCurrent, "0.0")
                        'dtRow(4) = Format(gobjMethodCollection(intMethodsIdxId).InstrumentCondition.SlitWidth, "0.0").ToString
                        'dtRow(5) = strD2Curr
                        'dtRow(6) = Format(gobjMethodCollection(intMethodsIdxId).InstrumentCondition.FuelRatio, "0.00").ToString
                        'dtRow(7) = Format(gobjMethodCollection(intMethodsIdxId).InstrumentCondition.PmtVoltage, "####").ToString
                        'dtRow(8) = Format(gobjMethodCollection(intMethodsIdxId).InstrumentCondition.BurnerHeight, "0.00").ToString
                        '//-----
                        If .InstrumentParameterForRunNumber.D2Current <= 100 Then
                            strD2Curr = "OFF"
                        Else
                            strD2Curr = CStr(.InstrumentParameterForRunNumber.D2Current)
                        End If

                        dtRow(0) = strElementName   '.InstrumentParameterForRunNumber.ElementName
                        If gobjMethodCollection.item(intMethodsIdxId).OperationMode = EnumOperationMode.MODE_UVABS Or
                           gobjMethodCollection.item(intMethodsIdxId).OperationMode = EnumOperationMode.MODE_UVSPECT Then
                            '//----- Modified by Sachin On 31.08.07 Ref. Adding new Wv. field for Emission Mode
                            If gobjMethodCollection.item(intMethodsIdxId).OperationMode = EnumOperationMode.MODE_EMMISSION Then
                                dtRow(1) = FormatNumber(.InstrumentParameterForRunNumber.EmmWavelength, 2)
                            Else
                                '//-----
                                If .InstrumentParameterForRunNumber.Wavelength.Rows.Count > 0 Then
                                    'For intCount = 0 To gobjMethodCollection(intMethodsIdxId).InstrumentCondition.Wavelength.Rows.Count - 1
                                    For intCount = 0 To .InstrumentParameterForRunNumber.Wavelength.Rows.Count - 1
                                        'If gobjMethodCollection(intMethodsIdxId).InstrumentCondition.Wavelength.Rows.Item(intCount).Item(5) Then
                                        If .InstrumentParameterForRunNumber.Wavelength.Rows.Item(intCount).Item(5) Then
                                            blnWvFound = True
                                            Exit For
                                        End If
                                    Next
                                    If blnWvFound = True Then
                                        'dtRow(2) = Format(gobjMethodCollection(intMethodsIdxId).InstrumentCondition.Wavelength.Rows.Item(intCount).Item(2), "0.0")
                                        dtRow(1) = FormatNumber(.InstrumentParameterForRunNumber.Wavelength.Rows.Item(intCount).Item(2), 2)
                                    Else
                                        dtRow(1) = FormatNumber(.InstrumentParameterForRunNumber.Wavelength.Rows.Item(0).Item(2), 2)
                                    End If
                                Else
                                    dtRow(1) = 0.0
                                End If
                            End If
                            'dtRow(3) = FormatNumber(.InstrumentParameterForRunNumber.LampCurrent, 1) 'comment 'by pankaj for lamp current=0 if emmission mode

                            dtRow(2) = FormatNumber(.InstrumentParameterForRunNumber.LampCurrent, 1) 'by pankaj for lamp current=0 if emmission mode
                            dtRow(3) = FormatNumber(.InstrumentParameterForRunNumber.SlitWidth, 1).ToString

                            dtRow(4) = strD2Curr
                            dtRow(5) = Format(.InstrumentParameterForRunNumber.PmtVoltage, "###0.0").ToString
                        Else

                            dtRow(1) = .InstrumentParameterForRunNumber.TurretNumber.ToString

                            '//----- Modified by Sachin On 31.08.07 Ref. Adding new Wv. field for Emission Mode
                            If gobjMethodCollection.item(intMethodsIdxId).OperationMode = EnumOperationMode.MODE_EMMISSION Then
                                dtRow(1) = "-"
                                dtRow(2) = FormatNumber(.InstrumentParameterForRunNumber.EmmWavelength, 2)
                                dtRow(3) = "-"
                                dtRow(5) = "-"
                            Else
                                dtRow(1) = .InstrumentParameterForRunNumber.TurretNumber.ToString
                                '//-----
                                '''If .InstrumentParameterForRunNumber.Wavelength.Rows.Count > 0 Then
                                '''    For intCount = 0 To .InstrumentParameterForRunNumber.Wavelength.Rows.Count - 1
                                '''        If .InstrumentParameterForRunNumber.Wavelength.Rows.Item(intCount).Item(5) Then
                                '''            blnWvFound = True
                                '''            Exit For
                                '''        End If
                                '''    Next
                                '''    If blnWvFound = True Then
                                '''        dtRow(2) = FormatNumber(.InstrumentParameterForRunNumber.Wavelength.Rows.Item(intCount).Item(2), 2)
                                '''    Else
                                '''        dtRow(2) = FormatNumber(.InstrumentParameterForRunNumber.Wavelength.Rows.Item(0).Item(2), 2)
                                '''    End If
                                '''Else
                                '''    dtRow(2) = 0.0
                                '''End If
                                If .InstrumentParameterForRunNumber.Wavelength.Rows.Count > 0 Then
                                    For intCount = 0 To .InstrumentParameterForRunNumber.Wavelength.Rows.Count - 1
                                        If .InstrumentParameterForRunNumber.SelectedWavelengthID = .InstrumentParameterForRunNumber.Wavelength.Rows.Item(intCount).Item(0) Then
                                            dtRow(2) = FormatNumber(.InstrumentParameterForRunNumber.Wavelength.Rows.Item(intCount).Item(2), 2)
                                        End If
                                    Next
                                Else
                                    dtRow(2) = 0.0
                                End If
                                dtRow(5) = strD2Curr
                            End If
                            'dtRow(3) = FormatNumber(.InstrumentParameterForRunNumber.LampCurrent, 1) 'comment 'by pankaj for lamp current=0 if emmission mode
                            If gobjMethodCollection.item(intMethodsIdxId).OperationMode = EnumOperationMode.MODE_EMMISSION Then
                                'dtRow(3) = 0 'by pankaj for lamp current=0 if emmission mode
                                dtRow(4) = FormatNumber(gobjMethodCollection.item(intMethodsIdxId).InstrumentCondition.SlitWidth, 1).ToString
                            Else
                                dtRow(3) = FormatNumber(.InstrumentParameterForRunNumber.LampCurrent, 1) 'by pankaj for lamp current=0 if emmission mode
                                dtRow(4) = FormatNumber(.InstrumentParameterForRunNumber.SlitWidth, 1).ToString
                            End If

                            dtRow(6) = FormatNumber(.InstrumentParameterForRunNumber.FuelRatio, 2).ToString
                            dtRow(7) = Format(.InstrumentParameterForRunNumber.PmtVoltage, "###0.0").ToString


                            ' code added by:dinesh wagh on 24.3.2009
                            ' code start
                            If gstructSettings.AppMode = EnumAppMode.DemoMode_201 Or gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                                dtRow(8) = "--"
                            Else
                                dtRow(8) = FormatNumber(.InstrumentParameterForRunNumber.BurnerHeight, 1).ToString
                            End If
                            ' code ends

                            ' dtRow(8) = FormatNumber(.InstrumentParameterForRunNumber.BurnerHeight, 1).ToString ' code commented by : dinesh wagh on 24.3.2009

                        End If

                        DtInstCondition.Rows.Add(dtRow)

                        Call DtArrDatafile.Add(DtInstCondition)
                    End If
                End If
                '//*******************
                ' Set the object for "Calculation Mode"
                DtCalculationMode = New DataTable
                DtCalculationMode.TableName = "Calculation Mode"

                DtCalculationMode.Columns.Add(CalculationModeHeader)
                DtCalculationMode.Columns.Item(0).Caption = ""

                DtCalculationMode.Columns.Add(CalculationModeDtCol01)
                DtCalculationMode.Columns.Item(1).Caption = "Calculation Mode "



                If .CalculationMode = clsQuantitativeData.enumCalculationMode.CUBIC Then
                    strCalculationMode = "CUBIC"
                ElseIf .CalculationMode = clsQuantitativeData.enumCalculationMode.DIRECT Then
                    strCalculationMode = "DIRECT"
                ElseIf .CalculationMode = clsQuantitativeData.enumCalculationMode.FIFTH_ORDER Then
                    strCalculationMode = "FIFTH_ORDER"
                ElseIf .CalculationMode = clsQuantitativeData.enumCalculationMode.FOURTH_ORDER Then
                    strCalculationMode = "FOURTH_ORDER"
                ElseIf .CalculationMode = clsQuantitativeData.enumCalculationMode.LINEAR Then
                    strCalculationMode = "LINEAR"
                ElseIf .CalculationMode = clsQuantitativeData.enumCalculationMode.QUADRATIC Then
                    strCalculationMode = "QUADRATIC"
                ElseIf .CalculationMode = clsQuantitativeData.enumCalculationMode.RATIONAL Then
                    strCalculationMode = "RATIOMETRIC"
                End If

                dtRow = DtCalculationMode.NewRow()

                dtRow(0) = ""
                dtRow(1) = strCalculationMode

                DtCalculationMode.Rows.Add(dtRow)

                Call DtArrDatafile.Add(DtCalculationMode)
                '//****************

                ' Set the object for detail info "Standard/Sample Information"
                DtStdSampleData = New DataTable

                DtStdSampleData.TableName = "Standard/Sample Information"

                Dim StdSampleDtCol01 As New DataColumn("Col01", GetType(String))
                Dim StdSampleDtCol02 As New DataColumn("Col02", GetType(String))
                Dim StdSampleDtCol03 As New DataColumn("Col03", GetType(String))
                Dim StdSampleDtCol04 As New DataColumn("Col04", GetType(String))
                Dim StdSampleDtCol05 As New DataColumn("Col05", GetType(String))
                Dim StdSampleDtCol06 As New DataColumn("Col06", GetType(String))
                Dim StdSampleDtCol07 As New DataColumn("Col07", GetType(String))

                'Dim StdSampleDtCol08 As New DataColumn("Col08", GetType(String))
                'Dim StdSampleDtCol09 As New DataColumn("Col09", GetType(String))
                'Dim StdSampleDtCol10 As New DataColumn("Col10", GetType(String))
                Dim intColIndexCount As Integer = 0
                Dim unit As Integer
                intColIndexCount = 0
                DtStdSampleData.Columns.Add(StdSampleDtCol01)
                DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Std/Sample Name"
                intColIndexCount += 1

                'unit = .AnalysisParameters.Unit
                unit = gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).AnalysisParameters.Unit()

                'If gobjMethodCollection.item(intMethodsIdxId).ReportParameters.IsWeightVolumeDilution = True Then   '4.85 12.04.09
                If gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection(mlngSelectedRunIndex).ReportParameters.IsWeightVolumeDilution = True Then   '4.85 12.04.09

                    DtStdSampleData.Columns.Add(StdSampleDtCol02)
                    DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Weight (gms)"
                    intColIndexCount += 1
                    DtStdSampleData.Columns.Add(StdSampleDtCol03)
                    DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Volume (ml)"
                    intColIndexCount += 1
                    DtStdSampleData.Columns.Add(StdSampleDtCol04)
                    DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Dilution Factor"
                    intColIndexCount += 1
                End If

                'If gobjMethodCollection.item(intMethodsIdxId).ReportParameters.IsAbsorbance = True Then    '4.85 12.04.09
                If gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection(mlngSelectedRunIndex).ReportParameters.IsAbsorbance = True Then   '4.85 12.04.09

                    DtStdSampleData.Columns.Add(StdSampleDtCol05)
                    If gobjMethodCollection.item(intMethodsIdxId).OperationMode = EnumOperationMode.MODE_EMMISSION Then
                        DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Emission"     ' Added by Sachin Dokhale on ref. VCK
                        DtStdSampleData.Columns.Item(intColIndexCount).Caption = "%E"     ' Added by Deepak Bhati with ref. to VCK/Ramesh on 26.07.09
                    Else
                        DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Abs."
                    End If
                    intColIndexCount += 1
                End If

                DtStdSampleData.Columns.Add(StdSampleDtCol06)

                '---commented on 27.03.09
                ''DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Conc. (ppm)"
                '-----------

                '---written on 27.03.09
                If unit = enumUnit.PPB Then
                    DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Conc. (ppb)"
                Else
                    DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Conc. (ppm)"
                End If
                '---------


                intColIndexCount += 1
                DtStdSampleData.Columns.Add(StdSampleDtCol07)

                ''' code commented by :dinesh wagh on 27.3.2009
                ''' ........
                ''If unit = 1 Then
                ''    DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Conc. in ppm"
                ''Else
                ''    'DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Conc.in Unit"
                ''    DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Conc.in %"
                ''End If
                '''..................

                ' code added by : dinesh wagh on 27.3.2009
                'code start
                If unit = enumUnit.PPM Then
                    DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Conc. in " & vbCrLf & "Sample" & vbCrLf & "(ppm)"
                ElseIf unit = enumUnit.Percent Then
                    'DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Conc.in Unit"
                    DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Conc.in" & vbCrLf & "Sample" & vbCrLf & "(%)"
                ElseIf unit = enumUnit.PPB Then
                    DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Conc.in" & vbCrLf & "Sample" & vbCrLf & "(ppb)"
                End If
                ' code ends

                intCount = 0
                'If gobjMethodCollection.item(intMethodsIdxId).ReportParameters.IsStandards = True Then   '4.85 12.04.09
                If gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection(mlngSelectedRunIndex).ReportParameters.IsStandards = True Then   '4.85 12.04.09

                    If gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).StandardDataCollection.Count > 0 Then
                        Do While intCount < gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).StandardDataCollection.Count
                            If (.StandardDataCollection(intCount).Abs > -0.2) And (.StandardDataCollection(intCount).Used = True) Then
                                dtRow = DtStdSampleData.NewRow()
                                intColIndexCount = 0
                                dtRow(intColIndexCount) = CStr(.StandardDataCollection(intCount).StdName)       '  ""

                                'If gobjMethodCollection.item(intMethodsIdxId).ReportParameters.IsWeightVolumeDilution = True Then  '4.85 12.04.09
                                If gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection(mlngSelectedRunIndex).ReportParameters.IsWeightVolumeDilution = True Then   '4.85 12.04.09

                                    intColIndexCount += 1
                                    dtRow(intColIndexCount) = "-"
                                    intColIndexCount += 1
                                    dtRow(intColIndexCount) = "-"
                                    intColIndexCount += 1
                                    dtRow(intColIndexCount) = "-"
                                End If

                                'If gobjMethodCollection.item(intMethodsIdxId).ReportParameters.IsAbsorbance = True Then  '4.85 12.04.09
                                If gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection(mlngSelectedRunIndex).ReportParameters.IsAbsorbance = True Then   '4.85 12.04.09

                                    intColIndexCount += 1
                                    'dtRow(intColIndexCount) = CStr(FormatNumber(.StandardDataCollection(intCount).Abs, intNoOfDecimalPlaces))
                                    If gobjMethodCollection.item(intMethodsIdxId).OperationMode = EnumOperationMode.MODE_EMMISSION Then
                                        dtRow(intColIndexCount) = CStr(FormatNumber(.StandardDataCollection(intCount).Abs, 1))
                                    Else
                                        dtRow(intColIndexCount) = CStr(FormatNumber(.StandardDataCollection(intCount).Abs, 3))
                                    End If

                                End If

                                intColIndexCount += 1
                                dtRow(intColIndexCount) = CStr(FormatNumber(.StandardDataCollection(intCount).Concentration, intNoOfDecimalPlaces))
                                intColIndexCount += 1
                                ' dtRow(intColIndexCount) = CStr(Format(.StandardDataCollection(intCount).Concentration, "0.000"))
                                dtRow(intColIndexCount) = ""
                                'dtRow(7) = ""
                                DtStdSampleData.Rows.Add(dtRow)
                            End If
                            intCount += 1
                        Loop
                    End If
                End If
                ' Set the object for detail info "Sample Information"
                intCount = 0
                If gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).SampleDataCollection.Count > 0 Then
                    Do While intCount < gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).SampleDataCollection.Count
                        If (.SampleDataCollection(intCount).Abs > -0.2) And (.SampleDataCollection(intCount).Used = True) Then
                            dtRow = DtStdSampleData.NewRow()
                            intColIndexCount = 0
                            dtRow(intColIndexCount) = CStr(.SampleDataCollection(intCount).SampleName)         '  ""
                            'dtRow(intColIndexCount) = CStr(gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).SampleName)         '  ""

                            'If gobjMethodCollection.item(intMethodsIdxId).ReportParameters.IsWeightVolumeDilution = True Then  '4.85 12.04.09
                            If gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection(mlngSelectedRunIndex).ReportParameters.IsWeightVolumeDilution = True Then   '4.85 12.04.09

                                intColIndexCount += 1
                                'dtRow(intColIndexCount) = CStr(gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).Weight)
                                'By PAnkaj for formatting upto 4 digit
                                dtRow(intColIndexCount) = CStr(FormatNumber(gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).SampleDataCollection(intCount).Weight, intNoOfDecimalPlaces))
                                intColIndexCount += 1
                                dtRow(intColIndexCount) = CStr(FormatNumber(gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).SampleDataCollection(intCount).Volume, intNoOfDecimalPlaces))
                                intColIndexCount += 1
                                dtRow(intColIndexCount) = CStr(FormatNumber(gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).SampleDataCollection(intCount).DilutionFactor, intNoOfDecimalPlaces))
                            End If

                            'If gobjMethodCollection.item(intMethodsIdxId).ReportParameters.IsAbsorbance = True Then   '4.85 12.04.09
                            If gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection(mlngSelectedRunIndex).ReportParameters.IsAbsorbance = True Then   '4.85 12.04.09

                                intColIndexCount += 1
                                If gobjMethodCollection.item(intMethodsIdxId).OperationMode = EnumOperationMode.MODE_EMMISSION Then
                                    dtRow(intColIndexCount) = CStr(FormatNumber(.SampleDataCollection(intCount).Abs, 1))
                                Else
                                    dtRow(intColIndexCount) = CStr(FormatNumber(.SampleDataCollection(intCount).Abs, 3))
                                End If
                            End If
                            Dim dblConcInPercent As Double
                            Dim dblConc As Double
                            dblConcInPpm = 0.0
                            intColIndexCount += 1
                            '//----- added by Sachin Dokhale on 29.05.07
                            'dblConc = Format(gobjclsStandardGraph.Get_Conc(.SampleDataCollection(intCount).Abs, 0.0), "0.000")
                            If gobjMethodCollection.item(intMethodsIdxId).StandardAddition = True Then
                                dblConc = CStr(.SampleDataCollection(intCount).Conc)
                            Else
                                dblConc = gobjclsStandardGraph.Get_Conc(.SampleDataCollection(intCount).Abs, 0.0)
                            End If

                            'dblConc = .SampleDataCollection(intCount).Conc
                            'dtRow(intColIndexCount) = CStr(Format(.SampleDataCollection(intCount).Conc, "0.000"))
                            dtRow(intColIndexCount) = FormatNumber(dblConc, intNoOfDecimalPlaces)
                            intColIndexCount += 1
                            'dtRow(intColIndexCount) = CStr(Format(.SampleDataCollection(intCount).Conc, "0.000"))

                            'Dim dblConcInPercent As Double


                            '---commented on 27.03.09
                            ''If unit = 1 Then
                            ''    'dtRow(intColIndexCount) = CStr(FormatNumber(dblConc, intNoOfDecimalPlaces))
                            ''    dblConcInPpm = (dblConc * gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).SampleDataCollection(intCount).Volume * gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).SampleDataCollection(intCount).DilutionFactor) / gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).SampleDataCollection(intCount).Weight
                            ''    dtRow(intColIndexCount) = CStr(FormatNumber(dblConcInPpm, intNoOfDecimalPlaces))
                            ''Else
                            ''    'dblConcInPercent = (dblConc * gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).Volume * gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).DilutionFactor * Math.Pow(10, -6)) / gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).Weight
                            ''    dblConcInPercent = (dblConc * gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).SampleDataCollection(intCount).Volume * gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).SampleDataCollection(intCount).DilutionFactor * Math.Pow(10, -6)) / gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).SampleDataCollection(intCount).Weight
                            ''    dblConcInPercent = dblConcInPercent * 100

                            ''    'dtRow(7) = ""
                            ''    'dtRow(intColIndexCount) = CStr(Format(.SampleDataCollection(intCount).Conc, "###0.00#####"))
                            ''    dtRow(intColIndexCount) = CStr(FormatNumber(dblConcInPercent, intNoOfDecimalPlaces))
                            ''End If
                            '--------

                            '---written on 27.03.09
                            If unit = enumUnit.PPM Then
                                dblConcInPpm = (dblConc * gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).SampleDataCollection(intCount).Volume * gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).SampleDataCollection(intCount).DilutionFactor) / gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).SampleDataCollection(intCount).Weight
                                dtRow(intColIndexCount) = CStr(FormatNumber(dblConcInPpm, intNoOfDecimalPlaces))
                            ElseIf unit = enumUnit.Percent Then
                                dblConcInPercent = (dblConc * gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).SampleDataCollection(intCount).Volume * gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).SampleDataCollection(intCount).DilutionFactor * Math.Pow(10, -6)) / gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).SampleDataCollection(intCount).Weight
                                dblConcInPercent = dblConcInPercent * 100
                                dtRow(intColIndexCount) = CStr(FormatNumber(dblConcInPercent, intNoOfDecimalPlaces))
                            ElseIf unit = enumUnit.PPB Then
                                dblConcInPpm = (dblConc * gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).SampleDataCollection(intCount).Volume * gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).SampleDataCollection(intCount).DilutionFactor) / gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).SampleDataCollection(intCount).Weight
                                dtRow(intColIndexCount) = CStr(FormatNumber(dblConcInPpm, intNoOfDecimalPlaces))
                            End If
                            '--------

                            'dblConcInPercent = (dblConc * samp.Volume * samp.DilutionFactor * Math.Pow(10, -6)) / samp.Weight

                            DtStdSampleData.Rows.Add(dtRow)
                        End If
                        intCount += 1
                    Loop
                End If
                '//***************

                'blnGetHeaderFooter = gobjMethodCollection.item(intMethodsIdxId).ReportParameters.IsReportHeaderAndFooter  '4.85 12.04.09
                blnGetHeaderFooter = gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection(mlngSelectedRunIndex).ReportParameters.IsReportHeaderAndFooter   '4.85 12.04.09

                'Add the result objects into array list
                Call ArrListMoreTabularData.Add(DtStdSampleData)
                '--4.85 12.04.09
                'Call ArrListMoreTabularData.Add(gobjMethodCollection.item(intMethodsIdxId).ReportParameters.ReportHeader)
                'Call ArrListMoreTabularData.Add(gobjMethodCollection.item(intMethodsIdxId).ReportParameters.ReportFooter)
                '--4.85 12.04.09

                '----4.85 12.04.09
                Call ArrListMoreTabularData.Add(gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection(mlngSelectedRunIndex).ReportParameters.ReportHeader)
                Call ArrListMoreTabularData.Add(gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection(mlngSelectedRunIndex).ReportParameters.ReportFooter)
                '-----
            End With

            funcSetDatafileTableForMethod = True

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
            If Not DtMethosDefination Is Nothing Then
                DtMethosDefination = Nothing
            End If
            If Not DtAnalysisParam Is Nothing Then
                DtAnalysisParam = Nothing
            End If
            If Not DtInstCondition Is Nothing Then
                DtInstCondition = Nothing
            End If
            If Not DtStdSampleData Is Nothing Then
                DtStdSampleData = Nothing
            End If
            If Not DtReportData Is Nothing Then
                DtReportData = Nothing
            End If
            If Not DtCalculationMode Is Nothing Then
                DtCalculationMode = Nothing
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Private Function funcSetMultiReport(ByVal arrRunNoList(,) As Integer, ByRef ArrListMoreTabularData As ArrayList, ByRef DtArrDatafile As ArrayList) As Boolean
        '=====================================================================
        ' Procedure Name        : funcSetMultiReport
        ' Parameters Passed     : arrRunNoList array holds Selected Run No of perticulor Method
        ' Parameters Affected   : ArrListMoreTabularData  array list return the detail records of result
        '                       : DtArrDatafile array list return the parent records of result
        ' Returns               : True if success
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : Method collection object must be present.
        ' Author                : Sachin Dokhale
        ' Created               : 
        ' Revisions             : 
        '=====================================================================

        Dim strMethodMode As String

        Dim DtStdSampleData As DataTable
        Dim DtReportData As DataTable
        Dim objDtElements As DataTable
        Dim objDtRunNos As DataTable        'Sauarbh
        Dim intCount As Integer
        Dim intFstDimeUpperBoundLength As Integer
        Dim intSndDimeUpperBoundLength As Integer
        Dim intInstId As Integer
        Dim intCount2 As Integer
        Dim intColCounter As Integer
        Dim intCount3, intLastPos, TempCount As Integer
        Dim strElementName As String
        Dim strRunNo As String              'Saurabh
        Dim strRunNos As String
        funcSetMultiReport = False
        Try
            ' Filter out the detail records of result
            Dim ReportHeader1 As New DataColumn("HeaderDefination", GetType(String))
            Dim ReportDtCol01 As New DataColumn("Col01", GetType(String))
            Dim ReportDtCol02 As New DataColumn("Col02", GetType(String))
            Dim ReportDtCol03 As New DataColumn("Col03", GetType(String))
            Dim StdSampleDtCol01 As New DataColumn("Sample_ID", GetType(String))
            Dim RunNoDtCol01 As New DataColumn("RunNo_ID", GetType(String))         'Saurabh   15.07.07
            Dim dtRow As DataRow
            Dim dtSingleRow As DataRow
            Dim arrstrRunNo() As String

            'With gobjMethodCollection.item(mintSelectedMethodID).QuantitativeDataCollection(mintSelectedRunNumber)
            For intCount = 0 To gobjMethodCollection.Count - 1
                If gobjMethodCollection.item(intCount).MethodID = mintSelectedMethodID Then
                    'If gobjMethodCollection(intCount).SelectedElementID = gobjMethodCollection(intCount).InstrumentCondition.ElementID Then
                    intInstId = intCount
                    Exit For
                    'End If
                End If
            Next

            DtReportData = New DataTable
            DtReportData.TableName = "MULTI-ELEMENT REPORT"

            DtReportData.Columns.Add(ReportHeader1)
            DtReportData.Columns.Item(0).Caption = "MULTI-ELEMENT REPORT"

            DtReportData.Columns.Add(ReportDtCol01)
            DtReportData.Columns.Item(1).Caption = "Lab Name "

            DtReportData.Columns.Add(ReportDtCol02)
            DtReportData.Columns.Item(2).Caption = "Analyst Name "

            DtReportData.Columns.Add(ReportDtCol03)
            DtReportData.Columns.Item(3).Caption = "Sample Name "

            '

            dtSingleRow = DtReportData.NewRow()

            'dtRow(1) = CStr(gobjMethodCollection.item(intInstId).QuantitativeDataCollection(0).AnalysisParameters.LabName)     '  ""
            dtSingleRow(1) = CStr(gobjMethodCollection.item(intInstId).AnalysisParameters.LabName)
            dtSingleRow(2) = CStr(gobjMethodCollection.item(intInstId).UserName)
            'gobjMethodCollection.item(arrRunNoList(0, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(0, 1) - 1).SampleDataCollection.Count()


            'dtRow(3) = CStr(gobjMethodCollection.item(intInstId).QuantitativeDataCollection(RunNumber).SampleDataCollection.item(0).SampleName)
            'dtRow(3) = CStr(gobjMethodCollection.item(arrRunNoList(0, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(0, 1) - 1).SampleDataCollection.item(0).SampleName)
            dtSingleRow(3) = CStr(gobjMethodCollection.item(arrRunNoList(0, 0) - 1).SampleDataCollection.item(0).SampleName)


            'DtReportData.Rows.Add(dtSingleRow)
            'Call DtArrDatafile.Add(DtReportData)

            '//****************

            ' Filter out the parent records of result
            intFstDimeUpperBoundLength = arrRunNoList.GetUpperBound(0)
            intSndDimeUpperBoundLength = arrRunNoList.GetUpperBound(1)


            DtStdSampleData = New DataTable

            DtStdSampleData.TableName = "Sample Information"


            DtStdSampleData.Columns.Add(StdSampleDtCol01)
            DtStdSampleData.Columns.Item(0).Caption = "Sample Name"

            'Saurabh for Adding Run Nos. to the report 12.07.07
            objDtRunNos = New DataTable
            objDtRunNos.TableName = " "
            objDtRunNos.Columns.Add(RunNoDtCol01)
            objDtRunNos.Columns.Item(0).Caption = "Run Numbers"
            'Saurabh for Adding Run Nos. to the report 12.07.07


            For intCount = 0 To intFstDimeUpperBoundLength
                If gobjMethodCollection.Count > 0 Then
                    For intCount2 = 1 To intSndDimeUpperBoundLength
                        'If gobjMethodCollection.Count > 0 Then
                        If (arrRunNoList(intCount, intCount2) - 1) > -1 Then
                            DtStdSampleData.Columns.Add(New DataColumn("Col" & Format(intColCounter + 1, "00"), GetType(String)))
                            'objDtRunNos.Columns.Add(New DataColumn("Col" & Format(intColCounter + 1, "00"), GetType(String)))
                            '//----- Search Element ID
                            objDtElements = gobjDataAccess.GetCookBookData(gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).InstrumentCondition.ElementID)
                            If Not objDtElements Is Nothing Then
                                If objDtElements.Rows.Count > 0 Then
                                    strElementName = objDtElements.Rows(0).Item(ConstColumnElementName)
                                End If
                            End If
                            'Saurabh for RunNos
                            'strRunNo = gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(0).RunNumber
                            'strRunNo = gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).RunNumber()
                            '
                            strRunNo = gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection(arrRunNoList(intCount, intCount2) - 1).RunNumber
                            If funcAddRunNoString(strRunNo, arrstrRunNo) Then
                                objDtRunNos.Columns.Add(New DataColumn("Col_" & Format(intColCounter + 1, "00"), GetType(String)))
                                objDtRunNos.Columns.Item(intColCounter + 1).Caption = strRunNo
                            End If
                            'Saurabh
                            DtStdSampleData.Columns.Item(intColCounter + 1).Caption = strElementName    'gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).InstrumentConditions(0).ElementName()
                            '//-----
                            intColCounter += 1
                        End If
                        'End If
                    Next
                Else
                    Return False
                End If
            Next



            '//----- find last Record
            TempCount = 0
            intColCounter = 0
            For intCount = 0 To intFstDimeUpperBoundLength
                If (arrRunNoList(intCount, 0) - 1) > -1 Then
                    If gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Count > 0 Then
                        For intCount2 = 1 To intSndDimeUpperBoundLength
                            If (arrRunNoList(intCount, intCount2) - 1) > -1 Then
                                If gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.Count > 0 Then
                                    'dtRow(intCount2 + 1) = CStr(gobjMethodCollection.item(arrRunNoList(intCount, 0)).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2)).SampleDataCollection.item(intCount3).Conc)
                                    TempCount = gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.Count
                                    If TempCount > intLastPos Then
                                        intLastPos = TempCount
                                    End If

                                End If
                            End If
                        Next
                    Else
                        'Return False
                    End If
                End If
            Next

            '//----- 
            'intLastPos = intFstDimeUpperBoundLength
            Dim dblConc As Double
            intCount3 = 0
            Do While intCount3 < intLastPos
                intColCounter = 0
                dtRow = DtStdSampleData.NewRow()
                dtRow(0) = "Sample " & (intCount3 + 1).ToString
                For intCount = 0 To intFstDimeUpperBoundLength
                    If (arrRunNoList(intCount, 0) - 1) > -1 Then
                        If gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Count > 0 Then
                            For intCount2 = 1 To intSndDimeUpperBoundLength
                                If (arrRunNoList(intCount, intCount2) - 1) > -1 Then
                                    If gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.Count > intCount3 Then
                                        ''Commented by pankaj on 20 Feb 08
                                        ''dtRow(intColCounter + 1) = CStr(Format(gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.item(intCount3).Conc, "0.000"))
                                        ''Added by Pankaj on 20 Feb 08
                                        dblConc = 0
                                        'If gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).AnalysisParameters.Unit = 1 Then 'from method
                                        If gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).AnalysisParameters.Unit = enumUnit.PPM Then
                                            If gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.item(intCount3).Weight > 0 Then
                                                ''dblConc = CDbl(gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.item(intCount3).Conc * gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).SampleDataCollection.item(intCount3).Volume * gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).SampleDataCollection.item(intCount3).DilutionFactor) / gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).SampleDataCollection.item(intCount3).Weight 'from method
                                                dblConc = CDbl(gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.item(intCount3).Conc * gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.item(intCount3).Volume * gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.item(intCount3).DilutionFactor) / gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.item(intCount3).Weight
                                            End If
                                            dtRow(intColCounter + 1) = CStr(Format(dblConc, "0.0000")) & " "
                                        ElseIf gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).AnalysisParameters.Unit = enumUnit.Percent Then
                                            If gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.item(intCount3).Weight > 0 Then
                                                ''dblConc = CDbl(gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.item(intCount3).Conc * gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).SampleDataCollection.item(intCount3).Volume * gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).SampleDataCollection.item(intCount3).DilutionFactor * Math.Pow(10, -6)) / gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).SampleDataCollection.item(intCount3).Weight 'from method
                                                dblConc = CDbl(gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.item(intCount3).Conc * gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.item(intCount3).Volume * gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.item(intCount3).DilutionFactor * Math.Pow(10, -6)) / gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.item(intCount3).Weight
                                                dblConc = dblConc * 100
                                            End If
                                            dtRow(intColCounter + 1) = CStr(Format(dblConc, "0.0000")) & "%"

                                        ElseIf gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).AnalysisParameters.Unit = enumUnit.PPB Then  '---27.03.09
                                            If gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.item(intCount3).Weight > 0 Then
                                                ''dblConc = CDbl(gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.item(intCount3).Conc * gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).SampleDataCollection.item(intCount3).Volume * gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).SampleDataCollection.item(intCount3).DilutionFactor) / gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).SampleDataCollection.item(intCount3).Weight 'from method
                                                dblConc = CDbl(gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.item(intCount3).Conc * gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.item(intCount3).Volume * gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.item(intCount3).DilutionFactor) / gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.item(intCount3).Weight
                                            End If
                                            dtRow(intColCounter + 1) = CStr(Format(dblConc, "0.0000")) & " "
                                        End If
                                        ''dtRow(intColCounter + 1) = CStr(Format(dblConc, "0.000"))

                                        ''------------------------

                                    Else
                                        dtRow(intColCounter + 1) = "-"
                                    End If
                                    intColCounter += 1
                                    'strRunNo = gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).RunNumber()
                                    'funcAddRunNoString(strRunNo, arrstrRunNo, RunNoString)

                                End If

                            Next
                        Else
                            '    Return False
                        End If
                    End If
                Next
                DtStdSampleData.Rows.Add(dtRow)
                intCount3 += 1
            Loop
            '//***************
            'dtSingleRow(4) = RunNoString
            DtReportData.Rows.Add(dtSingleRow)

            'Add the result objects into array list
            Call DtArrDatafile.Add(DtReportData)
            Call ArrListMoreTabularData.Add(objDtRunNos)
            Call ArrListMoreTabularData.Add(DtStdSampleData)
            'End With

            funcSetMultiReport = True

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

            If Not DtStdSampleData Is Nothing Then
                DtStdSampleData = Nothing
            End If
            If Not DtReportData Is Nothing Then
                DtReportData = Nothing
            End If
            If Not objDtElements Is Nothing Then
                objDtElements = Nothing
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Private Function funcAddRunNoString(ByVal strRunNo As String, ByRef arrstrRunNo() As String) As Boolean
        '=====================================================================
        ' Procedure Name        : funcAddRunNoString
        ' Parameters Passed     : strRunNo, arrstrRunNo()
        ' Returns               : True if success adding of Run No into array.
        ' Purpose               : To adding of Run No into multidimention array.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul At Machine SOFT1
        ' Created               : Monday, January 31, 2005
        ' Revisions             : 1
        '=====================================================================
        Dim arrIdx As Integer
        Dim blnFoundRunNo As Boolean = False
        Try

            If Not (arrstrRunNo Is Nothing) Then
                For arrIdx = 0 To arrstrRunNo.GetUpperBound(0)
                    If strRunNo = arrstrRunNo(arrIdx) Then
                        blnFoundRunNo = True
                        Exit For
                    End If
                Next
            End If
            If blnFoundRunNo = False Then

                If Not (arrstrRunNo Is Nothing) Then
                    ReDim Preserve arrstrRunNo(arrstrRunNo.GetUpperBound(0) + 1)
                Else
                    ReDim Preserve arrstrRunNo(0)
                End If
                arrstrRunNo(arrstrRunNo.GetUpperBound(0)) = strRunNo
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
            Return False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If

        End Try
    End Function

    Private Function funcSetPrintDocument(ByVal objstructReportFormatIn As clsReportingMode.structReportFormat,
                      ByVal strPageHeaderIn As clsPrintDocument.struHeaderString,
                      ByVal strPageTextIn As String,
                      ByVal blnGetHeaderFooter As Boolean,
                      ByVal arrGraphControlsListIn As ArrayList,
                      ByVal arrDtTablesListIn As ArrayList,
                      ByVal objDtImagesListIn As DataTable,
                      ByVal arrDtTextListIn As ArrayList,
                      ByVal intReportTypeIn As clsPrintDocument.enumReportType) As clsPrintDocument
        '=====================================================================
        ' Procedure Name        : funcSetPrintDocument
        ' Parameters Passed     : As above
        ' Returns               : True or false
        ' Purpose               : To set the clsPrintDocument object
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul At Machine SOFT1
        ' Created               : Monday, January 31, 2005
        ' Revisions             : 1
        '=====================================================================
        Dim intCount As Integer
        Dim objDtTable2In As DataTable
        Dim objclsPrintDocument As New clsPrintDocument
        Dim FontStyles As System.Drawing.Font = DefaultFont '=Me.DefaultFont
        Dim blnSeekFooter As Boolean = False
        Dim struRptHeader As AAS203.clsPrintDocument.struHeaderString
        Dim struRotFooter As AAS203.clsPrintDocument.struHeaderString
        Try
            '--- Seting Report format and text object
            '//----- commented by Sachin Dokhale as per Requirement
            objstructReportFormatIn.IsDisplayReportTitle = False
            objstructReportFormatIn.IsDisplayReportHeader = blnGetHeaderFooter
            objstructReportFormatIn.IsDisplayReportFooter = blnGetHeaderFooter
            objstructReportFormatIn.IsDisplayCompanyLogo = False
            objstructReportFormatIn.LogoAlignment = 1   'Left()
            objstructReportFormatIn.LogoFileName = Application.StartupPath & "\" & "CHEMITO.BMP" '"D:\ALDYS\AAS 203 Borland Windows SW\win203.5\BMP\BMP\CHEMITO.BMP"
            objclsPrintDocument.ReportFormat = objstructReportFormatIn

            objclsPrintDocument.PageText = strPageTextIn
            objclsPrintDocument.DisplayFont = Me.DefaultFont
            objclsPrintDocument.TableHeaderFont = FontStyles
            objclsPrintDocument.ReportImageList = objDtImagesListIn
            objclsPrintDocument.ReportType = intReportTypeIn
            objclsPrintDocument.ReportLayoutType = clsPrintDocument.enumReportLayoutType.Portrate
            objclsPrintDocument.PageSetting = gobjPageSetting

            '---Set Property ReportDataTables
            If IsNothing(arrDtTablesListIn) = False Then
                objclsPrintDocument.ReportDataTables = New ArrayList
                For intCount = 0 To arrDtTablesListIn.Count - 1
                    If TypeOf arrDtTablesListIn.Item(intCount) Is DataTable Then
                        objDtTable2In = arrDtTablesListIn.Item(intCount)
                        If IsNothing(objDtTable2In) = False Then
                            objclsPrintDocument.ReportDataTables.Add(objDtTable2In)
                        End If
                    End If
                Next intCount

                struRptHeader = New AAS203.clsPrintDocument.struHeaderString
                struRotFooter = New AAS203.clsPrintDocument.struHeaderString
                struRptHeader.TextFormat = New clsReportHeaderFormat
                struRotFooter.TextFormat = New clsReportHeaderFormat
                struRptHeader.TextFormat.Alignment = ContentAlignment.MiddleLeft
                struRotFooter.TextFormat.Alignment = ContentAlignment.MiddleLeft
                objclsPrintDocument.PageHeader = struRptHeader
                For intCount = 0 To arrDtTablesListIn.Count - 1
                    If TypeOf arrDtTablesListIn.Item(intCount) Is String Then
                        If blnSeekFooter = False Then
                            struRptHeader.TextString = CStr(arrDtTablesListIn.Item(intCount))
                            objclsPrintDocument.PageHeader = struRptHeader 'CStr(arrDtTablesListIn.Item(intCount))
                        End If
                        If blnSeekFooter = True Then
                            struRotFooter.TextString = arrDtTablesListIn.Item(intCount)
                            objclsPrintDocument.ReportFooter = struRotFooter
                        End If
                        blnSeekFooter = True
                    End If
                Next intCount
            End If

            '---Set Property ReportGraphControls
            If IsNothing(arrGraphControlsListIn) = False Then
                objclsPrintDocument.ReportGraphControls = New ArrayList
                For intCount = 0 To arrGraphControlsListIn.Count - 1
                    If IsNothing(arrGraphControlsListIn.Item(intCount)) = False Then
                        objclsPrintDocument.ReportGraphControls.Add(arrGraphControlsListIn.Item(intCount))
                    End If
                Next intCount
            End If

            If IsNothing(arrDtTextListIn) = False Then
                objclsPrintDocument.ReportTextList = New ArrayList
                For intCount = 0 To arrDtTextListIn.Count - 1
                    If IsNothing(arrDtTextListIn.Item(intCount)) = False Then
                        objclsPrintDocument.ReportTextList.Add(arrDtTextListIn.Item(intCount))
                    End If
                Next intCount
            End If

            '--- Return the clsPrintDocument object
            Return objclsPrintDocument
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return Nothing
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            If Not IsNothing(objclsPrintDocument) = True Then
                objclsPrintDocument.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Private Function funcSetPrintDocument(ByVal objstructReportFormatIn As clsReportingMode.structReportFormat,
                          ByVal strPageHeaderIn As clsPrintDocument.struHeaderString,
                          ByVal strPageTextIn As String,
                          ByVal blnGetHeaderFooter As Boolean,
                          ByVal arrDtTablesListIn As ArrayList,
                          ByVal arrDtTextListIn As ArrayList,
                          ByVal intReportTypeIn As clsPrintDocument.enumReportType) As clsPrintDocument
        '=====================================================================
        ' Procedure Name        : funcSetPrintDocument
        ' Parameters Passed     : As above
        ' Returns               : True or false
        ' Purpose               : To set the clsPrintDocument object
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul At Machine SOFT1
        ' Created               : Monday, January 31, 2005
        ' Revisions             : 1
        '=====================================================================
        Dim intCount As Integer
        Dim objDtTable2In As DataTable
        Dim objclsPrintDocument As New clsPrintDocument
        Dim FontStyles As System.Drawing.Font = DefaultFont '=Me.DefaultFont
        Try
            'Seting Report format and text
            '//----- commented by Sachin Dokhale as per Requirement
            objstructReportFormatIn.IsDisplayReportTitle = False
            objstructReportFormatIn.IsDisplayReportHeader = blnGetHeaderFooter
            objstructReportFormatIn.IsDisplayReportFooter = blnGetHeaderFooter
            objstructReportFormatIn.IsDisplayCompanyLogo = False
            objstructReportFormatIn.LogoAlignment = 1   'Left()
            objstructReportFormatIn.LogoFileName = Application.StartupPath & "\" & "CHEMITO.BMP" '"D:\ALDYS\AAS 203 Borland Windows SW\win203.5\BMP\BMP\CHEMITO.BMP"

            ''gobjNewMethod.ReportParameters.
            objclsPrintDocument.ReportFormat = objstructReportFormatIn

            objclsPrintDocument.PageText = strPageTextIn
            objclsPrintDocument.DisplayFont = Me.DefaultFont
            objclsPrintDocument.TableHeaderFont = FontStyles
            objclsPrintDocument.ReportType = intReportTypeIn
            objclsPrintDocument.ReportLayoutType = clsPrintDocument.enumReportLayoutType.Portrate
            objclsPrintDocument.PageSetting = gobjPageSetting

            ''---Set Property ReportDataTables
            If IsNothing(arrDtTablesListIn) = False Then
                objclsPrintDocument.ReportDataTables = New ArrayList
                For intCount = 0 To arrDtTablesListIn.Count - 1
                    If TypeOf arrDtTablesListIn.Item(intCount) Is DataTable Then
                        objDtTable2In = arrDtTablesListIn.Item(intCount)
                        If IsNothing(objDtTable2In) = False Then
                            objclsPrintDocument.ReportDataTables.Add(objDtTable2In)
                        End If
                    End If
                Next intCount

                Dim blnSeekFooter As Boolean = False
                Dim struRptHeader As New AAS203.clsPrintDocument.struHeaderString
                Dim struRotFooter As New AAS203.clsPrintDocument.struHeaderString
                struRptHeader.TextFormat = New clsReportHeaderFormat
                struRotFooter.TextFormat = New clsReportHeaderFormat
                struRptHeader.TextFormat.Alignment = ContentAlignment.MiddleLeft
                'struRotFooter.TextFormat.Alignment = ContentAlignment.MiddleCenter
                struRotFooter.TextFormat.Alignment = ContentAlignment.MiddleLeft

                For intCount = 0 To arrDtTablesListIn.Count - 1
                    If TypeOf arrDtTablesListIn.Item(intCount) Is String Then
                        If blnSeekFooter = False Then
                            struRptHeader.TextString = CStr(arrDtTablesListIn.Item(intCount))
                            objclsPrintDocument.PageHeader = struRptHeader 'CStr(arrDtTablesListIn.Item(intCount))
                        End If
                        If blnSeekFooter = True Then
                            struRotFooter.TextString = arrDtTablesListIn.Item(intCount)
                            objclsPrintDocument.ReportFooter = struRotFooter
                        End If
                        blnSeekFooter = True
                    End If
                Next intCount
            End If



            If IsNothing(arrDtTextListIn) = False Then
                'objclsPrintDocument.ReportTextList = New ArrayList
                objclsPrintDocument.RepeatDatafile = New ArrayList
                For intCount = 0 To arrDtTextListIn.Count - 1
                    If IsNothing(arrDtTextListIn.Item(intCount)) = False Then
                        objclsPrintDocument.RepeatDatafile.Add(arrDtTextListIn.Item(intCount))
                    End If
                Next intCount
            End If



            Return objclsPrintDocument

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return Nothing
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            If Not IsNothing(objclsPrintDocument) = True Then
                objclsPrintDocument.Dispose()
            End If
            '---------------------------------------------------------
        End Try

    End Function
#End Region

End Class

