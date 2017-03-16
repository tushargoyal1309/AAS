Imports System
Imports System.Web
Imports System.Web.Mail
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports.ViewerObjectModel


Public Class clsDataSetExport
    '**********************************************************************
    ' File Header        
    ' File Name 		: clsDataSetExport.vb
    ' Author			: Mangesh Shardul
    ' Date/Time			: 01-Mar-2005 8:00 pm
    ' Description		: To export the report to Text or Htmal Format
    '**********************************************************************

    '//-----
    '//----

#Region " Public Constants "

    Public Const constWebReportExportFilePath As String = "\WebReports"
    Public Const constImagesFilePath As String = constWebReportExportFilePath & "\Images"

    Public Const constTextReportExportFilePath As String = "\TextReports"

    Public Const constHTMLFileExt As String = ".html"
    Public Const constTEXTFileExt As String = ".txt"
    Public Const constGraphImageFileExt As String = ".jpg"

    Private Const constRowBGColor_SkyBlue As String = "#cde1fa"
    Private Const constRowBGColor_LightBlue As String = "#e6efff"
    Private Const constRowBGColor_DarkBlue As String = "#000080"
    Private Const constRowBGColor_White As String = "#ffffff"

#End Region

    '//----- Private varailable 
    'Private mobjDataSet As DataSet1    'DataSet

#Region " Public Shared Functions "

    Public Shared Sub Export(ByVal ds As DataSet)

        Dim objSaveFileDialog As New System.Windows.Forms.SaveFileDialog
        objSaveFileDialog.Filter = "File Xml (*.xml)|*.xml|File Html (*.htm)|*.htm|All Files (*.*)|*.*"
        objSaveFileDialog.Title = "Export Dataset"
        If objSaveFileDialog.ShowDialog() = DialogResult.OK Then
            Try
                If Right(objSaveFileDialog.FileName, 3).ToLower = "xml" Then
                    ExportXml(objSaveFileDialog.FileName, ds)
                Else
                    ExportHtml(objSaveFileDialog.FileName, ds)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
        objSaveFileDialog.Dispose()
        objSaveFileDialog = Nothing
        GC.Collect()

    End Sub

    Public Shared Sub ExportXml(ByVal strfileName As String, ByVal objDS As DataSet)

        objDS.WriteXml(strfileName)

    End Sub

    Public Shared Sub ExportHtml(ByVal strReportNameIn As String, ByVal ds As DataSet, Optional ByVal strReportHeaderIn As String = "", _
            Optional ByVal strPageHeaderIn As String = "", Optional ByVal strPageTextIn As String = "", _
            Optional ByVal objReportImageList As ArrayList = Nothing, Optional ByVal arrImageCaptionListIn As ArrayList = Nothing)

        Dim strReportFilePath As String
        Dim sw As System.IO.StreamWriter
        Dim fs As System.IO.FileStream
        Dim intCount As Integer
        Dim strImgFilePaths() As String
        Dim objfrmWebReportViewer As frmWebReportViewer

        Try
            strReportFilePath = Application.StartupPath & constWebReportExportFilePath
            '--- Check for the folders if not create the folders
            If Not System.IO.Directory.Exists(strReportFilePath) Then
                '--- Create the folder
                System.IO.Directory.CreateDirectory(strReportFilePath)
            End If
            strReportFilePath = strReportFilePath & "\" & strReportNameIn

            strReportFilePath = strReportFilePath & constHTMLFileExt
            If System.IO.File.Exists(strReportFilePath) = True Then
                System.IO.File.Delete(strReportFilePath)
            End If

            fs = New System.IO.FileStream(strReportFilePath, IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write)

            sw = funcDrawStartHtml(fs, ds.DataSetName)

            Call subDrawHtmlReportPageHeader(sw, strReportHeaderIn, strPageHeaderIn, strPageTextIn)

            Call subDrawHtmlTables(sw, ds)

            '---Save Bitmap objects to a file 
            ReDim strImgFilePaths(objReportImageList.Count - 1)
            For intCount = 0 To objReportImageList.Count - 1
                Dim objReportImage As Image = objReportImageList.Item(intCount)
                If Not IsNothing(objReportImage) Then
                    '---Save Image and Add Images Path to show them on HTML Page
                    strImgFilePaths(intCount) = funcSaveReportImages(objReportImage, strReportNameIn & intCount.ToString)
                End If
            Next intCount

            If Not strImgFilePaths Is Nothing Then
                If Not strImgFilePaths.Length = 0 Then
                    Call subDrawHtmlImages(sw, strImgFilePaths, arrImageCaptionListIn)
                End If
            End If

            Call subDrawENDHtml(sw)

            '---To Show the Html Report in Web Browser
            objfrmWebReportViewer = New frmWebReportViewer(strReportFilePath)
            objfrmWebReportViewer.ShowDialog()
            objfrmWebReportViewer.Close()
            objfrmWebReportViewer.Dispose()
            objfrmWebReportViewer = Nothing

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

            objReportImageList = Nothing
            ds.Dispose()
            ds = Nothing
            sw = Nothing
            fs.Close()
            fs = Nothing
            '---------------------------------------------------------
        End Try

    End Sub

    'Public Shared Sub SendEMail(ByVal ds As DataSet)

    '    Dim str As String
    '    str = InputBox("Insert Destination e-Mail Address", "Send e-Mail", "user@site.com")

    '    If str Is Nothing Or str = "" Then Return
    '    SendEMail("anonymous@anonymous.com", str, ds)

    'End Sub
    'Public Shared Sub SendEMail(ByVal FromAddress As String, ByVal ToAddress As String, ByVal ds As DataSet)
    '    Try
    '        Dim mail As New MailMessage
    '        mail.From = FromAddress
    '        mail.To = ToAddress
    '        mail.Subject = "Report"
    '        mail.Body = "The exported tables contained in the attachment."
    '        mail.BodyFormat = MailFormat.Text

    '        Dim fileName As String = System.IO.Path.GetTempPath() & "default.htm"

    '        Call ExportHtml(fileName, ds)

    '        Dim ma As New MailAttachment(fileName)
    '        mail.Attachments.Add(ma)
    '        SmtpMail.Send(mail)
    '        System.IO.File.Delete(fileName)

    '    Catch ex As Exception
    '        'CustomControls.InformationMessage("Errore nell'invio della Mail")
    '        MessageBox.Show(ex.Message)
    '    End Try

    'End Sub

    Public Shared Sub ExportRTF(ByVal strReportNameIn As String, ByVal dsText As DataSet, _
          ByVal ds As DataSet, ByVal strReportHeaderIn As String, ByVal strPageHeaderIn As String, _
          ByVal strPageTextIn As String)
        '=====================================================================
        ' Procedure Name        : ExportRTF
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
        Dim fs As System.IO.FileStream
        Dim bs As System.IO.BufferedStream
        Dim sw As System.IO.StreamWriter
        Dim strReportFilePath As String

        Try
            strReportFilePath = Application.StartupPath & constTextReportExportFilePath
            '--- Check for the folders if not create the folders
            If Not System.IO.Directory.Exists(strReportFilePath) Then
                '--- Create the folder
                System.IO.Directory.CreateDirectory(strReportFilePath)
            End If
            strReportFilePath = strReportFilePath & "\" & strReportNameIn

            strReportFilePath = strReportFilePath & constTEXTFileExt
            If System.IO.File.Exists(strReportFilePath) = True Then
                System.IO.File.Delete(strReportFilePath)
            End If

            fs = New System.IO.FileStream(strReportFilePath, IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write)
            bs = New System.IO.BufferedStream(fs)
            sw = New System.IO.StreamWriter(bs)

            'WriteLine(1, "Zone 1", TAB(), "Zone 2")     ' Print in two print zones.
            'WriteLine(1, "Hello", " ", "World")     ' Separate strings with space.
            sw.WriteLine("-----------------------------------------------------------------------------")
            sw.WriteLine(Space(10) & strReportHeaderIn & Space(10))
            sw.WriteLine("-----------------------------------------------------------------------------")
            sw.WriteLine(strPageHeaderIn)
            sw.WriteLine(strPageTextIn)
            sw.WriteLine("-----------------------------------------------------------------------------")
            sw.WriteLine()

            Dim i, r, c As Integer
            Dim arrColSpace() As Integer
            Dim intSpaceBetweenColumns As Integer
            '//------  Text list
            For i = 0 To dsText.Tables.Count - 1
                'sw.WriteLine(Space(10) & dsText.Tables(i).TableName & Space(10))
                If dsText.Tables(i).Rows.Count > 0 Then
                    sw.Write("{0}", dsText.Tables(i).Columns(0).Caption)
                    intSpaceBetweenColumns = CStr(dsText.Tables(i).Columns(0).Caption).Length
                    sw.Write(Space(25 - intSpaceBetweenColumns))
                    sw.Write("{0}", dsText.Tables(i).Rows(0).Item(0))
                Else
                    sw.WriteLine(Space(10) & ds.Tables(i).TableName & Space(10))
                End If
                sw.WriteLine()
                sw.WriteLine("-----------------------------------------------------------------------------")
                For r = 0 To dsText.Tables(i).Rows.Count - 1
                    ''sw.WriteLine("")
                    For c = 1 To dsText.Tables(i).Columns.Count - 1
                        sw.Write(Space(5))
                        sw.Write("{0}", dsText.Tables(i).Columns(c).Caption)
                        intSpaceBetweenColumns = CStr(dsText.Tables(i).Columns(c).Caption).Length
                        sw.Write(Space(25 - intSpaceBetweenColumns))
                        sw.Write("{0}", dsText.Tables(i).Rows(r).Item(c))

                        sw.WriteLine()
                        'sw.Write("{0}", ds.Tables(i).Rows(r).Item(c))
                        If Not IsDBNull(dsText.Tables(i).Rows(r).Item(c)) Then
                            intSpaceBetweenColumns = dsText.Tables(i).Columns.Item(c).ColumnName.Length - CStr(dsText.Tables(i).Rows(r).Item(c)).Length
                        Else
                            intSpaceBetweenColumns = dsText.Tables(i).Columns.Item(c).ColumnName.Length
                        End If
                        'If arrColSpace(c) > 5 Then
                        '    intSpaceBetweenColumns = arrColSpace(c) - CStr(dsText.Tables(i).Rows(r).Item(c)).Length - 5
                        'End If

                        'If Not intSpaceBetweenColumns < 0 Then
                        '    sw.Write(Space(intSpaceBetweenColumns))
                        'End If

                        'sw.Write(Space(5))
                    Next
                    sw.WriteLine()
                Next
                sw.WriteLine()
            Next
            '//------  Text list


            intSpaceBetweenColumns = 0
            For i = 0 To ds.Tables.Count - 1
                sw.WriteLine(Space(10) & ds.Tables(i).TableName & Space(10))
                sw.WriteLine("-----------------------------------------------------------------------------")
                For c = 0 To ds.Tables(i).Columns.Count - 1
                    sw.Write("{0}", ds.Tables(i).Columns(c).Caption)
                    'sw.Write(Space(10)) 'Saurabh Changed from (5) to (10)
                    If c = 0 Then
                        intSpaceBetweenColumns = ds.Tables(i).Columns(c).Caption.Length + 9 'Saurabh Changed from (5) to (9)
                        'intSpaceBetweenColumns = 12 - intSpaceBetweenColumns
                    Else
                        intSpaceBetweenColumns = ds.Tables(i).Columns(c).Caption.Length + 12 'Saurabh Changed from (5) to (9)
                        If intSpaceBetweenColumns < 15 Then
                            intSpaceBetweenColumns = ds.Tables(i).Columns(c).Caption.Length ' intSpaceBetweenColumns
                        Else
                            intSpaceBetweenColumns = (13 - ds.Tables(i).Columns(c).Caption.Length) + ds.Tables(i).Columns(c).Caption.Length ' intSpaceBetweenColumns
                        End If
                    End If
                    'sw.Write(Space(intSpaceBetweenColumns - 15))
                    ReDim Preserve arrColSpace(c + 1)
                    If intSpaceBetweenColumns > 5 Then
                        sw.Write(Space(intSpaceBetweenColumns - 11))
                        arrColSpace(c) = intSpaceBetweenColumns - 10
                    Else
                        sw.Write(Space((5 - intSpaceBetweenColumns) + 5))
                        'arrColSpace(c) = 5
                        arrColSpace(c) = ((7 - intSpaceBetweenColumns) + 5)
                    End If
                Next
                sw.WriteLine()
                sw.WriteLine("-----------------------------------------------------------------------------")
                For r = 0 To ds.Tables(i).Rows.Count - 1
                    ''sw.WriteLine("")
                    For c = 0 To ds.Tables(i).Columns.Count - 1
                        sw.Write("{0}", ds.Tables(i).Rows(r).Item(c))

                        If c = 0 Then
                            intSpaceBetweenColumns = 20 - CStr(ds.Tables(i).Rows(r).Item(c)).Length
                        Else
                            If Not IsDBNull(ds.Tables(i).Rows(r).Item(c)) Then
                                intSpaceBetweenColumns = ds.Tables(i).Columns.Item(c).ColumnName.Length - CStr(ds.Tables(i).Rows(r).Item(c)).Length
                                If arrColSpace(c) > 5 Then
                                    intSpaceBetweenColumns = arrColSpace(c) - CStr(ds.Tables(i).Rows(r).Item(c)).Length
                                End If
                            Else
                                intSpaceBetweenColumns = ds.Tables(i).Columns.Item(c).ColumnName.Length
                                If arrColSpace(c) > 5 Then
                                    intSpaceBetweenColumns = arrColSpace(c) - ds.Tables(i).Columns.Item(c).ColumnName.Length - 5
                                End If
                            End If
                        End If

                        If Not intSpaceBetweenColumns < 0 Then
                            sw.Write(Space(intSpaceBetweenColumns))
                        Else
                            sw.Write(Space(arrColSpace(c) + intSpaceBetweenColumns))
                        End If

                        'sw.Write(Space(5))
                        'sw.Write(Space(arrColSpace(c)))

                    Next
                    sw.WriteLine()
                Next
                sw.WriteLine()
            Next
            sw.WriteLine("-----------------------------------------------------------------------------")
            sw.WriteLine()

            sw.Close()

            '---To Show the Html Report in Web Browser
            Dim objfrmTextReportViewer As frmTextReportViewer
            objfrmTextReportViewer = New frmTextReportViewer
            objfrmTextReportViewer.ReportFilePath = strReportFilePath

            objfrmTextReportViewer.ShowDialog()
            objfrmTextReportViewer.Close()
            objfrmTextReportViewer.Dispose()
            objfrmTextReportViewer = Nothing

        Catch ex As Exception
            '------------------------------------------------------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            sw.Close()
            bs.Close()
            fs.Close()
            ds.Dispose()
            '------------------------------------------------------------------------------------------------------
        Finally
            '------------------------------------------------------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            sw.Close()
            bs.Close()
            fs.Close()
            ds.Dispose()
            '------------------------------------------------------------------------------------------------------
        End Try
    End Sub

    Public Shared Sub DatafileReportExportRTF(ByVal strReportNameIn As String, ByVal dsText As DataSet, _
          ByVal ds As DataSet, ByVal strReportHeaderIn As String, ByVal strPageHeaderIn As String, _
          ByVal strPageTextIn As String, ByVal strReportFooterIn As String)
        '=====================================================================
        ' Procedure Name        : ExportRTF
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
        Dim fs As System.IO.FileStream
        Dim bs As System.IO.BufferedStream
        Dim sw As System.IO.StreamWriter
        Dim objReportParameter As New AAS203Library.Method.clsReportParameters
        Dim strReportFilePath As String

        Try
            Call funcExportData(strReportNameIn, dsText, _
                ds, strReportHeaderIn, strPageHeaderIn, _
                strPageTextIn, strReportFooterIn, objReportParameter)
            Exit Sub
            strReportFilePath = Application.StartupPath & constTextReportExportFilePath
            '--- Check for the folders if not create the folders
            If Not System.IO.Directory.Exists(strReportFilePath) Then
                '--- Create the folder
                System.IO.Directory.CreateDirectory(strReportFilePath)
            End If
            strReportFilePath = strReportFilePath & "\" & strReportNameIn

            strReportFilePath = strReportFilePath & constTEXTFileExt
            If System.IO.File.Exists(strReportFilePath) = True Then
                System.IO.File.Delete(strReportFilePath)
            End If

            fs = New System.IO.FileStream(strReportFilePath, IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write)
            bs = New System.IO.BufferedStream(fs)
            sw = New System.IO.StreamWriter(bs)

            'WriteLine(1, "Zone 1", TAB(), "Zone 2")     ' Print in two print zones.
            'WriteLine(1, "Hello", " ", "World")     ' Separate strings with space.
            sw.WriteLine("-------------------------------------------------------------------------------------------------")
            sw.WriteLine(Space(10) & strReportHeaderIn & Space(10))
            sw.WriteLine("-------------------------------------------------------------------------------------------------")
            sw.WriteLine(strPageHeaderIn)
            sw.WriteLine(strPageTextIn)
            sw.WriteLine("-------------------------------------------------------------------------------------------------")
            sw.WriteLine()

            Dim i, r, c As Integer
            Dim arrColSpace() As Integer
            Dim intSpaceBetweenColumns As Integer
            '//------  Text list
            For i = 0 To dsText.Tables.Count - 1
                'sw.WriteLine(Space(10) & dsText.Tables(i).TableName & Space(10))
                If dsText.Tables(i).Rows.Count > 0 Then
                    sw.Write("{0}", dsText.Tables(i).Columns(0).Caption)
                    intSpaceBetweenColumns = CStr(dsText.Tables(i).Columns(0).Caption).Length
                    sw.Write(Space(25 - intSpaceBetweenColumns))
                    sw.Write("{0}", dsText.Tables(i).Rows(0).Item(0))
                Else
                    sw.WriteLine(Space(10) & ds.Tables(i).TableName & Space(10))
                End If
                sw.WriteLine()
                sw.WriteLine("-------------------------------------------------------------------------------------------------")
                For r = 0 To dsText.Tables(i).Rows.Count - 1
                    ''sw.WriteLine("")
                    For c = 1 To dsText.Tables(i).Columns.Count - 1
                        sw.Write(Space(5))
                        sw.Write("{0}", dsText.Tables(i).Columns(c).Caption)
                        intSpaceBetweenColumns = CStr(dsText.Tables(i).Columns(c).Caption).Length
                        sw.Write(Space(25 - intSpaceBetweenColumns))
                        sw.Write("{0}", dsText.Tables(i).Rows(r).Item(c))

                        sw.WriteLine()
                        'sw.Write("{0}", ds.Tables(i).Rows(r).Item(c))
                        If Not IsDBNull(dsText.Tables(i).Rows(r).Item(c)) Then
                            intSpaceBetweenColumns = dsText.Tables(i).Columns.Item(c).ColumnName.Length - CStr(dsText.Tables(i).Rows(r).Item(c)).Length
                        Else
                            intSpaceBetweenColumns = dsText.Tables(i).Columns.Item(c).ColumnName.Length
                        End If
                        'If arrColSpace(c) > 5 Then
                        '    intSpaceBetweenColumns = arrColSpace(c) - CStr(dsText.Tables(i).Rows(r).Item(c)).Length - 5
                        'End If

                        'If Not intSpaceBetweenColumns < 0 Then
                        '    sw.Write(Space(intSpaceBetweenColumns))
                        'End If

                        'sw.Write(Space(5))
                    Next
                    sw.WriteLine()
                Next
                sw.WriteLine()
            Next
            '//------  Text list

            Dim ColsRow1() As String
            Dim ColsRow2() As String

            intSpaceBetweenColumns = 0
            For i = 0 To ds.Tables.Count - 1
                sw.WriteLine(Space(10) & ds.Tables(i).TableName & Space(10))
                sw.WriteLine("-------------------------------------------------------------------------------------------------")
                ReDim ColsRow1(ds.Tables(i).Columns.Count)
                ReDim ColsRow2(ds.Tables(i).Columns.Count)
                Dim x As Integer
                For c = 0 To ds.Tables(i).Columns.Count - 1
                    For x = 0 To 1
                        If x = 0 Then
                            If ds.Tables(i).Columns(c).Caption.Length > 12 Then

                            Else

                                'ColsRow1()
                            End If
                        Else

                        End If



                    Next
                    'sw.Write("{0}", ds.Tables(i).Columns(c).Caption)
                    'sw.Write(Space(10)) 'Saurabh Changed from (5) to (10)

                    'If c = 0 Then
                    '    If ds.Tables(i).Columns(c).Caption.Length > 12 Then

                    '    End If

                    '    intSpaceBetweenColumns = ds.Tables(i).Columns(c).Caption.Length + 10 'Saurabh Changed from (5) to (9)

                    'Else
                    '    intSpaceBetweenColumns = ds.Tables(i).Columns(c).Caption.Length + 12 'Saurabh Changed from (5) to (9)
                    '    If intSpaceBetweenColumns < 15 Then
                    '        intSpaceBetweenColumns = ds.Tables(i).Columns(c).Caption.Length ' intSpaceBetweenColumns
                    '    Else
                    '        intSpaceBetweenColumns = (13 - ds.Tables(i).Columns(c).Caption.Length) + ds.Tables(i).Columns(c).Caption.Length ' intSpaceBetweenColumns
                    '    End If
                    'End If
                    ''sw.Write(Space(intSpaceBetweenColumns - 15))
                    'ReDim Preserve arrColSpace(c + 1)
                    'If intSpaceBetweenColumns > 5 Then
                    '    sw.Write(Space(intSpaceBetweenColumns - 11))
                    '    arrColSpace(c) = intSpaceBetweenColumns - 11
                    'Else
                    '    sw.Write(Space((5 - intSpaceBetweenColumns) + 5))
                    '    'arrColSpace(c) = 5
                    '    arrColSpace(c) = ((5 - intSpaceBetweenColumns) + 5)
                    'End If
                Next

                sw.WriteLine()
                sw.WriteLine("-------------------------------------------------------------------------------------------------")
                For r = 0 To ds.Tables(i).Rows.Count - 1
                    ''sw.WriteLine("")
                    For c = 0 To ds.Tables(i).Columns.Count - 1
                        sw.Write("{0}", ds.Tables(i).Rows(r).Item(c))


                        If Not IsDBNull(ds.Tables(i).Rows(r).Item(c)) Then
                            intSpaceBetweenColumns = ds.Tables(i).Columns.Item(c).ColumnName.Length - CStr(ds.Tables(i).Rows(r).Item(c)).Length
                            If arrColSpace(c) > 5 Then
                                intSpaceBetweenColumns = arrColSpace(c) - CStr(ds.Tables(i).Rows(r).Item(c)).Length - 5
                            End If
                        Else
                            intSpaceBetweenColumns = ds.Tables(i).Columns.Item(c).ColumnName.Length
                            If arrColSpace(c) > 5 Then
                                intSpaceBetweenColumns = arrColSpace(c) - ds.Tables(i).Columns.Item(c).ColumnName.Length - 5
                            End If
                        End If


                        If Not intSpaceBetweenColumns < 0 Then
                            sw.Write(Space(intSpaceBetweenColumns))
                        End If

                        sw.Write(Space(5))
                    Next
                    sw.WriteLine()
                Next
                sw.WriteLine()
            Next
            sw.WriteLine("-------------------------------------------------------------------------------------------------")
            sw.WriteLine()

            sw.Close()

            '---To Show the Html Report in Web Browser
            Dim objfrmTextReportViewer As frmTextReportViewer
            objfrmTextReportViewer = New frmTextReportViewer
            objfrmTextReportViewer.ReportFilePath = strReportFilePath

            objfrmTextReportViewer.ShowDialog()
            objfrmTextReportViewer.Close()
            objfrmTextReportViewer.Dispose()
            objfrmTextReportViewer = Nothing

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
            If Not (sw Is Nothing) Then sw.Close()
            If Not (bs Is Nothing) Then bs.Close()
            If Not (fs Is Nothing) Then fs.Close()
            If Not (ds Is Nothing) Then ds.Dispose()
            '---------------------------------------------------------
        End Try
    End Sub

    Public Shared Sub ExportText(ByVal strfileName As String, ByVal dsText As DataSet, ByVal ds As DataSet, _
          Optional ByVal strReportHeaderIn As String = "", Optional ByVal strPageHeaderIn As String = "", _
          Optional ByVal strPageTextIn As String = "")

        Try
            Call ExportRTF(strfileName, ds, dsText, strReportHeaderIn, strPageHeaderIn, strPageTextIn)

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

    Public Shared Function funcExportData(ByVal strReportNameIn As String, ByVal dsText As DataSet, _
              ByVal ds As DataSet, ByVal strReportHeaderIn As String, ByVal strPageHeaderIn As String, _
              ByVal strPageTextIn As String, _
              ByVal strReportFooterIn As String, ByVal objReportParameter As AAS203Library.Method.clsReportParameters) As Boolean
        'Dim objDataSet As DataSet

        Dim objDatafileExportCryReport As New DataRptExport
        Dim strInstInfos As String
        Dim TxtPageFooter As TextObject
        Dim strAppVersion As String
        'aa = objCryReport.Section3.ReportObjects("Text1").Name

        '--- Initialising Connection 
     
        Dim mobjDataSet As DataSet1    'DataSet
        Dim mobjDt As DataTable
        Dim intCount As Integer
        Dim intColCount As Integer
        Dim objDrCDNewRow As DataSet1.StdSampInfoRow
        Dim objSaveFileDlg As New SaveFileDialog
        Dim blnIsEmiMode As Boolean = False
        Dim blnIsUnitinPPM As Boolean = True
        Dim TxtAbs As TextObject
        Dim TxtConcinUnit As TextObject
        'Dim gobjDataSet As New DataSet

        '// Connect to, fetch data, and disconnect from database 
        Try
            mobjDataSet = New DataSet1
            mobjDt = New DataTable
            mobjDt = gobjDataAccess.GetStdSampInfo
            For intCount = 0 To ds.Tables(0).Rows.Count - 1
                objDrCDNewRow = mobjDataSet.StdSampInfo.NewStdSampInfoRow
                For intColCount = 0 To ds.Tables(0).Rows(intCount).ItemArray.Length - 1
                    If intColCount = 0 Then
                        objDrCDNewRow.Item(intColCount) = ds.Tables(0).Rows(intCount).Item(intColCount)
                    Else
                        If IsNumeric(ds.Tables(0).Rows(intCount).Item(intColCount)) Then
                            objDrCDNewRow.Item(intColCount) = ds.Tables(0).Rows(intCount).Item(intColCount)
                        Else
                            objDrCDNewRow.Item(intColCount) = 0.0
                        End If
                    End If
                Next
                'gobjDataSet.CustomerDetails.AddCustomerDetailsRow(objDrCDNewRow)
                mobjDataSet.StdSampInfo.AddStdSampInfoRow(objDrCDNewRow)
            Next
            'mobjDataSet.
            'objDatafileExportCryReport.SetDataSource(objDataSet)
            objDatafileExportCryReport.SetDataSource(mobjDataSet)
            'objCryReport.Section2.SectionFormat.EnableSuppress = True
            '//---------------------------------------------------
            '//------  Text list

            Dim ColsRow1() As String
            Dim ColsRow2() As String
            Dim inttbIdx As Integer
            Dim intColIdx As Integer
            Dim objSec1Hdr1 As TextObject
            Dim objTxtRunNo As TextObject
            Dim objTxtAnalysedOn As TextObject
            Dim blnIsShowMethodDefinition As Boolean
            Dim blnIsShowAnalysisParameters As Boolean
            Dim blnIsShowInstrumentConditions As Boolean
            Dim TxtReportHeader As TextObject
            Dim TxtReportFooter As TextObject
            Dim blnIsUVMethod As Boolean
            
            'intSpaceBetweenColumns = 0
            For inttbIdx = 0 To dsText.Tables.Count - 1
                'ReDim ColsRow1(ds.Tables(i).Columns.Count)
                'ReDim ColsRow2(ds.Tables(i).Columns.Count)
                'Dim x As Integer
                If dsText.Tables(inttbIdx).TableName = "Quantitative Report" Then
                    For intColIdx = 0 To dsText.Tables(inttbIdx).Columns.Count - 1
                        If intColIdx = 0 Then   'Quantitative Report for

                            objSec1Hdr1 = objDatafileExportCryReport.Section14.ReportObjects("Sec1Hdr1")
                            objSec1Hdr1.Text = dsText.Tables(inttbIdx).Columns(0).Caption() + vbTab & dsText.Tables(inttbIdx).Rows.Item(0).Item(0)
                        End If
                        If intColIdx = 1 Then   'Run No

                            objTxtRunNo = objDatafileExportCryReport.Section14.ReportObjects("TxtRunNo")
                            objTxtRunNo.Text = dsText.Tables(inttbIdx).Columns(1).Caption() + vbTab & dsText.Tables(inttbIdx).Rows.Item(0).Item(1)
                        End If
                        If intColIdx = 2 Then   'Analysed On
                            objTxtAnalysedOn = objDatafileExportCryReport.Section14.ReportObjects("TxtAnalysedOn")
                            'objDatafileExportCryReport.s()
                            objTxtAnalysedOn.Text = dsText.Tables(inttbIdx).Columns(2).Caption() + vbTab & dsText.Tables(inttbIdx).Rows.Item(0).Item(2)
                        End If
                    Next
                End If
                If dsText.Tables(inttbIdx).TableName = "MethodDefination" Then
                    blnIsShowMethodDefinition = True
                    Dim TxtMethodDefinition As TextObject
                    Dim TxtMethodDefinitionDetals1 As TextObject
                    Dim TxtMethodDefinitionDetals2 As TextObject
                    Dim TxtCreatedby As TextObject
                    Dim TxtChanged As TextObject
                    Dim TxtComments As TextObject
                    Dim TxtCreatedon As TextObject
                    Dim TxtLastusedon As TextObject

                    For intColIdx = 0 To dsText.Tables(inttbIdx).Columns.Count - 1

                        If intColIdx = 0 Then   'Method Title
                            TxtMethodDefinition = objDatafileExportCryReport.Section15.ReportObjects("TxtMethodDefinition")
                            '    TxtMethodDefinition = dsText.Tables(inttbIdx).Columns("MethodDefination").Caption & vbTab & dsText.Tables(inttbIdx).Rows.Item(0).Item(0)
                            TxtMethodDefinition.Text = dsText.Tables(inttbIdx).Columns(0).Caption & vbTab & dsText.Tables(inttbIdx).Rows.Item(0).Item(0)
                        End If
                        If UCase(dsText.Tables(inttbIdx).Rows.Item(0).Item(0)) = "UV MODE" Then
                            blnIsUVMethod = True
                        End If
                        If UCase(dsText.Tables(inttbIdx).Rows.Item(0).Item(0)) = "EMISSION MODE" Then
                            blnIsEmiMode = True
                        End If

                        If intColIdx = 1 Then   'Method Name
                            TxtMethodDefinitionDetals1 = objDatafileExportCryReport.Section15.ReportObjects("TxtMethodDefinitionDetails1")
                            TxtMethodDefinitionDetals1.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(1)
                        End If
                        If intColIdx = 2 Then   'Status
                            TxtMethodDefinitionDetals2 = objDatafileExportCryReport.Section15.ReportObjects("TxtMethodDefinitionDetails2")
                            TxtMethodDefinitionDetals2.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(2)
                        End If
                        If intColIdx = 3 Then   'Created by
                            TxtCreatedby = objDatafileExportCryReport.Section15.ReportObjects("TxtCreated")
                            'TxtMethodDefinitionDetals2 = objDatafileExportCryReport.Section2.ReportObjects("TxtCreatedby")
                            TxtCreatedby.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(3)
                        End If
                        If intColIdx = 4 Then   'Created on
                            TxtChanged = objDatafileExportCryReport.Section15.ReportObjects("TxtCreatedon")
                            'TxtMethodDefinitionDetals2 = objDatafileExportCryReport.Section2.ReportObjects("TxtCreatedby")
                            TxtChanged.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(4)
                        End If
                        If intColIdx = 5 Then   'changed on
                            TxtChanged = objDatafileExportCryReport.Section15.ReportObjects("TxtChanged")
                            'TxtMethodDefinitionDetals2 = objDatafileExportCryReport.Section2.ReportObjects("TxtCreatedby")
                            TxtChanged.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(5)
                        End If
                        If intColIdx = 6 Then   'Last used on
                            TxtLastusedon = objDatafileExportCryReport.Section15.ReportObjects("TxtLastusedon")
                            'TxtMethodDefinitionDetals2 = objDatafileExportCryReport.Section2.ReportObjects("TxtCreatedby")
                            TxtLastusedon.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(6)
                        End If

                        If intColIdx = 7 Then   'Commented
                            TxtComments = objDatafileExportCryReport.Section15.ReportObjects("TxtComments")
                            'TxtMethodDefinitionDetals2 = objDatafileExportCryReport.Section2.ReportObjects("TxtCreatedby")
                            TxtComments.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(7)
                        End If
                    Next

                End If
                If dsText.Tables(inttbIdx).TableName = "AnalysisParameters" Then
                    blnIsShowAnalysisParameters = True
                    Dim TxtAnalysisParameters As TextObject
                    Dim TxtAnalysisParametersDetails1 As TextObject
                    Dim TxtAnalysisParametersDetails2 As TextObject
                    Dim TxtMeasurement As TextObject
                    Dim TxtIntegrationTime As TextObject
                    Dim TxtNoofSample As TextObject
                    Dim TxtBlankEverySample As TextObject
                    Dim TxtResultAccuracy As TextObject
                    Dim TxtUnitofresults As TextObject
                    Dim TxtStandardAddition As TextObject

                    For intColIdx = 0 To dsText.Tables(inttbIdx).Columns.Count - 1
                        'If intColIdx = 0 Then   'Method Title
                        '    TxtAnalysisParameters = objDatafileExportCryReport.Section7.ReportObjects("TxtAnalysisParametersDetails1")
                        '    TxtAnalysisParameters = dsText.Tables(inttbIdx).Columns("Method Definition").Caption & vbTab & dsText.Tables(inttbIdx).Rows.Item(0).Item(0)
                        'End If
                        If intColIdx = 1 Then   'Analys't Name
                            TxtAnalysisParametersDetails1 = objDatafileExportCryReport.Section16.ReportObjects("TxtAnalysisParametersDetails1")
                            TxtAnalysisParametersDetails1.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(1) & " "
                        End If
                        If intColIdx = 2 Then   'Lab Name
                            TxtAnalysisParametersDetails2 = objDatafileExportCryReport.Section16.ReportObjects("TxtAnalysisParametersDetails2")
                            TxtAnalysisParametersDetails2.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(2)
                        End If
                        If intColIdx = 3 Then   'Measurement
                            TxtMeasurement = objDatafileExportCryReport.Section16.ReportObjects("TxtMeasurement")
                            'TxtMethodDefinitionDetals2 = objDatafileExportCryReport.Section2.ReportObjects("TxtCreatedby")
                            TxtMeasurement.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(3)
                        End If
                        If intColIdx = 4 Then   'Result Accuracy 
                            TxtResultAccuracy = objDatafileExportCryReport.Section16.ReportObjects("TxtResultAccuracy")
                            'TxtMethodDefinitionDetals2 = objDatafileExportCryReport.Section2.ReportObjects("TxtCreatedby")
                            TxtResultAccuracy.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(4)
                        End If
                        If intColIdx = 5 Then   'Integration Time
                            TxtIntegrationTime = objDatafileExportCryReport.Section16.ReportObjects("TxtIntegrationTime")
                            TxtIntegrationTime.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(5)
                        End If
                        If intColIdx = 6 Then   'Unit of Result
                            TxtUnitofresults = objDatafileExportCryReport.Section16.ReportObjects("TxtUnitofresults")
                            'TxtMethodDefinitionDetals2 = objDatafileExportCryReport.Section2.ReportObjects("TxtCreatedby")
                            TxtUnitofresults.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(6)
                        End If
                        If intColIdx = 7 Then   ' No. of Sample
                            TxtNoofSample = objDatafileExportCryReport.Section16.ReportObjects("TxtNoofSample")
                            'TxtMethodDefinitionDetals2 = objDatafileExportCryReport.Section2.ReportObjects("TxtCreatedby")
                            TxtNoofSample.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(7)
                        End If
                        If intColIdx = 8 Then   'Standard Addition 
                            TxtStandardAddition = objDatafileExportCryReport.Section16.ReportObjects("TxtStandardAddition")
                            'TxtMethodDefinitionDetals2 = objDatafileExportCryReport.Section2.ReportObjects("TxtCreatedby")
                            TxtStandardAddition.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(8)
                        End If
                        If intColIdx = 9 Then   'Blank after every Sample
                            TxtBlankEverySample = objDatafileExportCryReport.Section16.ReportObjects("TxtBlankEverySample")
                            'TxtMethodDefinitionDetals2 = objDatafileExportCryReport.Section2.ReportObjects("TxtCreatedby")
                            TxtBlankEverySample.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(9)
                        End If
                    Next
                End If

                If dsText.Tables(inttbIdx).TableName = "Instrument Condition" Then
                    blnIsShowInstrumentConditions = True
                    Dim TxtInstrumentCondition As TextObject
                    Dim TxtInstrumentConditionDetails1 As TextObject
                    Dim TxtInstrumentConditionDetails2 As TextObject
                    Dim TxtCurrent As TextObject
                    Dim TxtD2Cur As TextObject
                    Dim TxtPMT As TextObject
                    Dim TxtRefPMT As TextObject
                    Dim TxtFuel As TextObject
                    Dim TxtBurner As TextObject
                    Dim TxtSlit As TextObject
                    Dim TxtExitSlit As TextObject
                    Dim lblInstrument1 As TextObject
                    Dim strlblInstrument1 As String

                    'lblInstrument1 = objDatafileExportCryReport.Section8.ReportObjects("lblInstrument1")
                    'strlblInstrument1 = lblInstrument1.Text
                    'strlblInstrument1 = strlblInstrument1.Substring(0, strlblInstrument1.Length - Len("Ref. PMT (v)"))
                    'lblInstrument1.Text = strlblInstrument1
                    objDatafileExportCryReport.Refresh()
                    If blnIsUVMethod = True Then
                        objDatafileExportCryReport.Section19.SectionFormat.EnableSuppress = False
                        objDatafileExportCryReport.Section18.SectionFormat.EnableSuppress = True

                        For intColIdx = 0 To dsText.Tables(inttbIdx).Columns.Count - 1

                            If intColIdx = 0 Then   'Instrument Conditions for 
                                TxtInstrumentCondition = objDatafileExportCryReport.Section19.ReportObjects("TxtInstrumentConditions1")
                                TxtInstrumentCondition.Text = dsText.Tables(inttbIdx).Columns(0).Caption & vbTab & dsText.Tables(inttbIdx).Rows.Item(0).Item(0)
                            End If

                            If intColIdx = 1 Then
                                TxtInstrumentConditionDetails1 = objDatafileExportCryReport.Section19.ReportObjects("TxtInstrumentConditionsDetails3")
                                TxtInstrumentConditionDetails1.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(1)
                            End If
                            If intColIdx = 2 Then   'Wavelength (nm)
                                TxtInstrumentConditionDetails2 = objDatafileExportCryReport.Section19.ReportObjects("TxtInstrumentConditionsDetails4")
                                TxtInstrumentConditionDetails2.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(2)
                            End If
                            If intColIdx = 3 Then   'Current (mA)
                                TxtSlit = objDatafileExportCryReport.Section19.ReportObjects("TxtSlit1")
                                TxtSlit.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(3)
                            End If
                            If intColIdx = 4 Then   'Fuel (Litre/min)
                                TxtD2Cur = objDatafileExportCryReport.Section19.ReportObjects("TxtD2Cur1")
                                TxtD2Cur.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(4)
                            End If
                            If intColIdx = 5 Then   'D2 Cur (mA)
                                TxtPMT = objDatafileExportCryReport.Section19.ReportObjects("TxtPMT1")
                                TxtPMT.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(5)
                            End If
                        Next
                    Else
                        objDatafileExportCryReport.Section19.SectionFormat.EnableSuppress = True
                        objDatafileExportCryReport.Section18.SectionFormat.EnableSuppress = False
                        For intColIdx = 0 To dsText.Tables(inttbIdx).Columns.Count - 1

                            If intColIdx = 0 Then   'Instrument Conditions for 
                                TxtInstrumentCondition = objDatafileExportCryReport.Section18.ReportObjects("TxtInstrumentConditions")
                                TxtInstrumentCondition.Text = dsText.Tables(inttbIdx).Columns(0).Caption & vbTab & dsText.Tables(inttbIdx).Rows.Item(0).Item(0)
                            End If

                            If intColIdx = 1 Then   'Turret No
                                TxtInstrumentConditionDetails1 = objDatafileExportCryReport.Section18.ReportObjects("TxtInstrumentConditionsDetails1")
                                TxtInstrumentConditionDetails1.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(1)
                            End If
                            If intColIdx = 2 Then   'Wavelength (nm)
                                TxtInstrumentConditionDetails2 = objDatafileExportCryReport.Section18.ReportObjects("TxtInstrumentConditionsDetails2")
                                TxtInstrumentConditionDetails2.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(2)
                            End If
                            If intColIdx = 3 Then   'Current (mA)
                                TxtCurrent = objDatafileExportCryReport.Section18.ReportObjects("TxtCurrent")
                                TxtCurrent.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(3)
                            End If
                            If intColIdx = 4 Then   'Fuel (Litre/min)
                                TxtFuel = objDatafileExportCryReport.Section18.ReportObjects("TxtFuel")
                                TxtFuel.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(4)
                            End If
                            If intColIdx = 5 Then   'D2 Cur (mA)
                                TxtD2Cur = objDatafileExportCryReport.Section18.ReportObjects("TxtD2Cur")
                                TxtD2Cur.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(5)
                            End If
                            If intColIdx = 6 Then   'Burner Height (mm)
                                TxtBurner = objDatafileExportCryReport.Section18.ReportObjects("TxtBurner")
                                TxtBurner.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(6)
                            End If
                            If intColIdx = 7 Then   'PMT (v)
                                TxtPMT = objDatafileExportCryReport.Section18.ReportObjects("TxtPMT")
                                TxtPMT.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(7)
                            End If
                            If intColIdx = 8 Then   'Slit (nm)
                                TxtSlit = objDatafileExportCryReport.Section18.ReportObjects("TxtSlit")
                                TxtSlit.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(8)
                            End If
                            If intColIdx = 9 Then   'Ref. PMT (v)
                                TxtRefPMT = objDatafileExportCryReport.Section18.ReportObjects("TxtRefPMT")
                                TxtRefPMT.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(9)
                            End If
                            If intColIdx = 10 Then   'Exit Slit (nm)
                                TxtExitSlit = objDatafileExportCryReport.Section18.ReportObjects("TxtExitSlit")
                                TxtExitSlit.Text = dsText.Tables(inttbIdx).Rows.Item(0).Item(10)
                            End If
                        Next
                    End If
                End If
                If dsText.Tables(inttbIdx).TableName = "Calculation Mode" Then
                    Dim TxtCalculationMode As TextObject
                    For intColIdx = 0 To dsText.Tables(inttbIdx).Columns.Count - 1
                        If intColIdx = 0 Then   'Calculation Mode
                            TxtCalculationMode = objDatafileExportCryReport.Section20.ReportObjects("TxtCalculationMode")
                            TxtCalculationMode.Text = dsText.Tables(inttbIdx).Columns(1).Caption & vbTab & dsText.Tables(inttbIdx).Rows.Item(0).Item(1)
                        End If
                    Next
                End If
            Next

            inttbIdx = 0

            If blnIsEmiMode = True Then
                TxtAbs = objDatafileExportCryReport.Section10.ReportObjects("TxtAbs")
                'TxtAbs.Text = "%Emission"
                TxtAbs.Text = Space(4) & "%E" ' Added by Deepak Bhati with ref. to VCK/Ramesh on 26.07.09
            End If
            
            'code commented by : dinesh wagh on 27.3.2009
            '......
            ''If blnIsUnitinPPM = False Then
            ''    TxtConcinUnit = objDatafileExportCryReport.Section10.ReportObjects("TxtConcinUnit")
            ''    'DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Conc.in Unit"
            ''    TxtConcinUnit.Text = "Conc. (%)"
            ''End If
            '.....

            '-----------------------------------
            Dim TxtUnit As TextObject
            Dim TxtConc As TextObject


            TxtUnit = objDatafileExportCryReport.Section16.ReportObjects("TxtUnitofresults")

            TxtConcinUnit = objDatafileExportCryReport.Section10.ReportObjects("TxtConcinUnit") 'by dinesh wagh on 27.3.2009


            ' code commented by : dinesh wagh on 27.3.2009
            ''If TxtUnit.Text = "ppm" Then
            ''    TxtConc = objDatafileExportCryReport.Section10.ReportObjects("TxtConc")
            ''    TxtConc.Text = "Conc. (ppm)"
            ''Else
            ''    TxtConc = objDatafileExportCryReport.Section10.ReportObjects("TxtConc")
            ''    TxtConc.Text = "Conc. (%)"
            ''End If
            '............

            ' code added by : dinesh wagh on 27.3.2009
            '...code start

            If TxtUnit.Text = "ppm" Then
                TxtConc = objDatafileExportCryReport.Section10.ReportObjects("TxtConc")
                TxtConc.Text = "Conc. (ppm)"
                TxtConcinUnit.Text = "Conc. in Sample (ppm)"
            ElseIf (TxtUnit.Text = "ppb") Then
                TxtConc = objDatafileExportCryReport.Section10.ReportObjects("TxtConc")
                TxtConc.Text = "Conc. (ppb)"
                TxtConcinUnit.Text = "Conc. in Sample (ppb)"
                ''lblConc = objDatafileExportCryReport.Section3.ReportObjects("FldConc")
            Else
                TxtConc = objDatafileExportCryReport.Section10.ReportObjects("TxtConc")
                'TxtConc.Text = "Conc. (%)"
                TxtConc.Text = "Conc. (ppm)" ' added after discussion.
                TxtConcinUnit.Text = "Conc. in Sample (%)"
            End If
            '---code ends

            '//-------------------------------------------------------
            If blnIsShowMethodDefinition = False Then
                objDatafileExportCryReport.Section15.SectionFormat.EnableSuppress = True
            End If
            If blnIsShowAnalysisParameters = False Then
                objDatafileExportCryReport.Section16.SectionFormat.EnableSuppress = True
            End If
            If blnIsShowInstrumentConditions = False Then
                objDatafileExportCryReport.Section18.SectionFormat.EnableSuppress = True
                objDatafileExportCryReport.Section19.SectionFormat.EnableSuppress = True
            End If
            If objReportParameter.IsReportHeaderAndFooter = False Then
                objDatafileExportCryReport.Section1.SectionFormat.EnableSuppress = True
                'objDatafileExportCryReport.Section4.SectionFormat.EnableSuppress = True
                objDatafileExportCryReport.Section13.SectionFormat.EnableSuppress = True
            Else
                TxtReportHeader = objDatafileExportCryReport.Section1.ReportObjects("TxtReportHeader")
                TxtReportHeader.Text = strPageHeaderIn

                'TxtReportFooter = objDatafileExportCryReport.Section4.ReportObjects("TxtReportFooter")
                'TxtReportFooter.Text = strReportFooterIn
                TxtReportFooter = objDatafileExportCryReport.Section13.ReportObjects("TxtReportFooter")
                TxtReportFooter.Text = strReportFooterIn
            End If

            Dim intLeftPoint As Integer
            If objReportParameter.IsWeightVolumeDilution = False Then
                'objDatafileExportCryReport.Section10.SectionFormat.EnableSuppress = True
                intLeftPoint = objDatafileExportCryReport.Section10.ReportObjects("TxtWeight").Left
                objDatafileExportCryReport.Section10.ReportObjects("TxtAbs").Left = intLeftPoint
                intLeftPoint = objDatafileExportCryReport.Section10.ReportObjects("TxtVolume").Left
                objDatafileExportCryReport.Section10.ReportObjects("TxtConc").Left = intLeftPoint
                intLeftPoint = objDatafileExportCryReport.Section10.ReportObjects("TxtDilution").Left
                objDatafileExportCryReport.Section10.ReportObjects("TxtConcinUnit").Left = intLeftPoint

                'intLeftPoint = objDatafileExportCryReport.Section10.ReportObjects("TxtWeight").Left
                objDatafileExportCryReport.Section10.ReportObjects("TxtWeight").ObjectFormat.EnableSuppress = True
                objDatafileExportCryReport.Section10.ReportObjects("TxtVolume").ObjectFormat.EnableSuppress = True
                objDatafileExportCryReport.Section10.ReportObjects("TxtDilution").ObjectFormat.EnableSuppress = True
            End If
            intLeftPoint = objDatafileExportCryReport.Section10.ReportObjects("TxtAbs").Left

            ''objDatafileExportCryReport.Section10.ReportObjects("TxtAbs").Left()
            If objReportParameter.IsAbsorbance = False Then
                intLeftPoint = objDatafileExportCryReport.Section10.ReportObjects("TxtConc").Left
                objDatafileExportCryReport.Section10.ReportObjects("TxtConcinUnit").Left = intLeftPoint
                intLeftPoint = objDatafileExportCryReport.Section10.ReportObjects("TxtAbs").Left
                objDatafileExportCryReport.Section10.ReportObjects("TxtConc").Left = intLeftPoint
            Else
            End If

            'objDatafileExportCryReport.Section10.ReportObjects("TxtConc").Left = intLeftPoint
            'intLeftPoint = objDatafileExportCryReport.Section10.ReportObjects("TxtAbs").Width + 8
            'objDatafileExportCryReport.Section10.ReportObjects("TxtConcinUnit").Left = intLeftPoint

            If objReportParameter.IsReportHeaderAndFooter = False Then
                objDatafileExportCryReport.Section1.SectionFormat.EnableSuppress = True
            End If

            If objReportParameter.IsReportHeaderAndFooter = False Then
                objDatafileExportCryReport.Section1.SectionFormat.EnableSuppress = True
            End If

            strAppVersion = Application.ProductVersion
            ''get a application product version to string variable.
            strAppVersion = Mid(strAppVersion, 1, 4)

            'strInstInfos = "Thermo " & gstrTitleInstrumentType & "S/W Ver. " & strAppVersion 'COMMENTED BY : DINESH WAGH on 20.3.2009
            strInstInfos = "Thermo Scientific " & gstrTitleInstrumentType & Space(1) & "S/W Ver. " & strAppVersion 'added by :dinesh wagh on 20.3.2009  '4.85 14.04.09


            TxtPageFooter = objDatafileExportCryReport.Section5.ReportObjects("TxtPageFooter")
            TxtPageFooter.Text = strInstInfos


            objDatafileExportCryReport.Refresh()
            '//----- Export to Doc File
            ''

            objSaveFileDlg = New SaveFileDialog

            objSaveFileDlg.Filter = "Text File (*.Doc)|*.Doc|All Files (*.*)|*.*"

            If objSaveFileDlg.ShowDialog = DialogResult.OK Then
                objDatafileExportCryReport.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.WordForWindows, objSaveFileDlg.FileName)
            End If
            objSaveFileDlg.Dispose()




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
            mobjDataSet = Nothing
            objSaveFileDlg = Nothing
            objDrCDNewRow = Nothing
            '---------------------------------------------------------
        End Try
    End Function
#End Region

#Region " Private Functions "

    Private Shared Function funcDrawStartHtml(ByVal objFileStreamIn As System.IO.FileStream, ByVal strTitleName As String) As IO.StreamWriter

        Dim bs As New System.IO.BufferedStream(objFileStreamIn)
        Dim objStreamWriterIn As New System.IO.StreamWriter(bs)

        objStreamWriterIn.AutoFlush = True
        objStreamWriterIn.WriteLine("<html>")
        objStreamWriterIn.WriteLine("<head>")
        objStreamWriterIn.WriteLine("<title>")
        objStreamWriterIn.WriteLine(strTitleName)
        objStreamWriterIn.WriteLine("</title>")
        objStreamWriterIn.WriteLine("</head>")
        objStreamWriterIn.WriteLine("<body>")

        objStreamWriterIn.WriteLine("<TABLE style='WIDTH: 100%' cellSpacing=0 ")
        objStreamWriterIn.WriteLine("cellPadding=1 width='100%' align=center border=0>")

        Return objStreamWriterIn

    End Function

    Private Shared Sub subDrawENDHtml(ByRef objStreamWriterIn As System.IO.StreamWriter)
        objStreamWriterIn.WriteLine("</TABLE>")
        objStreamWriterIn.WriteLine("</body>")
        objStreamWriterIn.WriteLine("</html>")
        objStreamWriterIn.Close()
    End Sub

    Private Shared Sub subDrawHtmlReportPageHeader(ByRef objStreamWriterIn As System.IO.StreamWriter, _
                            ByVal strReportHeaderIn As String, ByVal strPageHeaderIn As String, ByVal strPageTextIn As String)

        objStreamWriterIn.WriteLine("<TR><TD>")
        objStreamWriterIn.WriteLine("<TABLE style='WIDTH: 100%' cellSpacing=0 cellPadding=1 width='100%' align=center borderColor=white bgColor='" & constRowBGColor_SkyBlue & "' border=0 style='FONT-SIZE: smaller; FONT-STYLE: normal; FONT-FAMILY: Arial'>")
        objStreamWriterIn.WriteLine("<TR><TD valign=middle bgcolor='" & constRowBGColor_SkyBlue & "' style='padding-bottom:5px;'><STRONG>{0}</STRONG></TD></TR>", strReportHeaderIn)
        objStreamWriterIn.WriteLine("<TR><TD bgcolor='" & constRowBGColor_LightBlue & "'>{0}</TD></TR>", strPageHeaderIn)
        objStreamWriterIn.WriteLine("<TR><TD bgcolor='" & constRowBGColor_LightBlue & "'>{0}</TD></TR>", strPageTextIn)
        objStreamWriterIn.WriteLine("</TABLE>")
        objStreamWriterIn.WriteLine("</TD></TR>")

    End Sub

    Private Shared Sub subDrawHtmlTables(ByRef objStreamWriterIn As System.IO.StreamWriter, ByVal objDsTablesList As DataSet)

        Dim i, r, c As Integer
        For i = 0 To objDsTablesList.Tables.Count - 1

            objStreamWriterIn.WriteLine("<table border=1 cellSpacing=0 cellPadding=2  width='100%' borderColor='" & constRowBGColor_White & "' style='FONT-SIZE: smaller; FONT-STYLE: normal; FONT-FAMILY: Arial'>")
            objStreamWriterIn.WriteLine("<TR bgcolor='" & constRowBGColor_SkyBlue & "'>")
            objStreamWriterIn.WriteLine("<TD colspan=10><STRONG>")
            objStreamWriterIn.WriteLine("{0}", objDsTablesList.Tables(i).TableName)
            objStreamWriterIn.WriteLine("<STRONG></td></tr>")

            objStreamWriterIn.WriteLine("<tr bgColor='" & constRowBGColor_DarkBlue & "' style='FONT-SIZE:12;FONT-FAMILY: Arial;color:White;'>")
            For c = 0 To objDsTablesList.Tables(i).Columns.Count - 1
                objStreamWriterIn.Write("<td style='padding-left: 5px;'><STRONG>{0}</STRONG></td>", objDsTablesList.Tables(i).Columns(c).ColumnName)
            Next
            objStreamWriterIn.WriteLine("</tr>")

            For r = 0 To objDsTablesList.Tables(i).Rows.Count - 1
                If Math.IEEERemainder(r, 2) = 0 Then
                    objStreamWriterIn.WriteLine("<tr bgcolor='" & constRowBGColor_SkyBlue & "'>")
                Else
                    objStreamWriterIn.WriteLine("<tr bgcolor='" & constRowBGColor_LightBlue & "'>")
                End If

                For c = 0 To objDsTablesList.Tables(i).Columns.Count - 1
                    objStreamWriterIn.WriteLine("<td style='padding-left: 5px;'>{0}</td>", objDsTablesList.Tables(i).Rows(r).Item(c))
                Next
                objStreamWriterIn.WriteLine("</tr>")
            Next
            objStreamWriterIn.WriteLine("</table>")
            objStreamWriterIn.WriteLine("</hr>")
        Next
        objStreamWriterIn.WriteLine("</TD></TR>")

    End Sub

    Private Shared Sub subDrawHtmlImages(ByRef objStreamWriterIn As System.IO.StreamWriter, _
                    ByVal strImageFilePaths() As String, ByVal arrImageCaptionList As ArrayList)

        Dim strGraphImagefileName As String
        Dim intImageCounter As Integer
        Dim intImageCaptionsCounter As Integer

        If arrImageCaptionList Is Nothing Then
            'ReDim strImageCaptions(strImageFilePaths.Length - 1)
        End If

        '---the following lines are commented ny deepak on 22.05.06
        '---to solve the error related to printing

        'objStreamWriterIn.WriteLine("<TR><TD align=center bgcolor='" & constRowBGColor_LightBlue & "'>")
        'objStreamWriterIn.WriteLine("<IMG SRC='file://" & strImageFilePaths(0) & "'")
        'objStreamWriterIn.WriteLine("border=0> ")
        'objStreamWriterIn.WriteLine("</TD></TR>")

        objStreamWriterIn.WriteLine("<Table>")
        For intImageCounter = 0 To strImageFilePaths.Length - 1
            If Math.IEEERemainder(intImageCounter, 2) = 0 Then
                If arrImageCaptionList(intImageCaptionsCounter) Is Nothing Then
                    arrImageCaptionList(intImageCaptionsCounter) = ""
                End If

                objStreamWriterIn.WriteLine("<TD>" & arrImageCaptionList(intImageCaptionsCounter) & " </TD>")
                objStreamWriterIn.WriteLine("<TD bgcolor='" & constRowBGColor_SkyBlue & "'>")
                objStreamWriterIn.WriteLine("<IMG SRC='file://" & strImageFilePaths(intImageCounter) & "'")
                objStreamWriterIn.WriteLine("border=0> ")
                objStreamWriterIn.WriteLine("</TD>")
                objStreamWriterIn.WriteLine("</TR>")

                intImageCaptionsCounter += 1
            Else
                objStreamWriterIn.WriteLine("<TR>")
                objStreamWriterIn.WriteLine("<TD>" & arrImageCaptionList(intImageCaptionsCounter) & " </TD>")
                objStreamWriterIn.WriteLine("<TD bgcolor='" & constRowBGColor_LightBlue & "'>")
                objStreamWriterIn.WriteLine("<IMG SRC='file://" & strImageFilePaths(intImageCounter) & "'")
                objStreamWriterIn.WriteLine("border=0> ")
                objStreamWriterIn.WriteLine("</TD>")
                objStreamWriterIn.WriteLine("</TR>")

                intImageCaptionsCounter += 1
            End If
            ''objStreamWriterIn.WriteLine("<TR><TD align=center bgcolor='" & constRowBGColor_LightBlue & "'>")
            ''objStreamWriterIn.WriteLine("<IMG SRC='file://" & strImageFilePaths(intImageCounter) & "'")
            ''objStreamWriterIn.WriteLine("border=0> ")
            ''objStreamWriterIn.WriteLine("</TD></TR>")
        Next intImageCounter
        objStreamWriterIn.WriteLine("</Table>")

    End Sub

    Private Shared Function funcSaveReportImages(ByVal objGraphImage As Bitmap, ByVal strImageName As String) As String
        Dim strFilePath As String
        Dim strGraphImageFilePath As String
        Dim strSpaceDiagramImageFilePath As String
        Try
            strGraphImageFilePath = Application.StartupPath & constImagesFilePath

            '--- Check for the folders if not create the folders
            If Not System.IO.Directory.Exists(strGraphImageFilePath) Then
                '--- Create the folder
                System.IO.Directory.CreateDirectory(strGraphImageFilePath)
            End If

            strGraphImageFilePath = strGraphImageFilePath & "\" & strImageName
            strGraphImageFilePath = strGraphImageFilePath & constGraphImageFileExt

            If System.IO.File.Exists(strGraphImageFilePath) = True Then
                System.IO.File.Delete(strGraphImageFilePath)
            End If

            objGraphImage.Save(strGraphImageFilePath, Drawing.Imaging.ImageFormat.Jpeg)

            Return strGraphImageFilePath

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

    Private Function funcDatafileReport(ByVal strFileName As String) As DataSet1
        'Dim objDataRptExport As New DataRptExport
        'Dim objOleDBconnection As New OleDbConnection
        Dim mobjDt As DataTable
        Dim intCount As Integer
        Dim intColCount As Integer
        Try
            '--- Initialising Connection String
            'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

            '--- Initialising Connection 
            'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)
            'gobjDataAdapter = New OleDbDataAdapter("SELECT * from CustomerDetails where CustomerID = 1", objOleDBconnection)
            'gobjDataSet = New dtsetExportAll

            '// Connect to, fetch data, and disconnect from database 
            'gobjDataAdapter.Fill(gobjDataSet, "CustomerDetails")
            'Dim objDrCDNewRow As dtsetExportAll.CustomerDetailsRow
            
            'gobjDataSet.Tables.Add(gobjDataAccess.GetCustomerDetails())
            'PrintDocument1.Print()
            'objDataRptExport.SetDataSource(gobjDataSet)


            'rptCustomerDetail.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
            'rptCustomerDetail.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
            '    gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
            '    gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
            '    gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)

            'Else
            'objDataRptExport.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)

            'End If


        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
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

End Class
