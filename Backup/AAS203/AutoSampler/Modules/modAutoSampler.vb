Imports System
Imports System.IO
Imports System.Text

Module modAutoSampler

#Region "AutoSampler General Functions"
    Public Function gfuncInitialiseGlobalValues(ByRef structAutoSamplerIn As structAutoSampler, ByRef structAutoSamplerPosIn As structAutoSamplerPosition)
        Try
            structAutoSamplerIn.intBaudRate = 9600
            structAutoSamplerIn.intComPort = 2
            structAutoSamplerIn.blnCommunication = False
            structAutoSamplerIn.intCoordinateX = -1
            structAutoSamplerIn.intCoordinateY = -1
            structAutoSamplerIn.intIntakeTime = 20
            structAutoSamplerIn.intWashTime = 20
            structAutoSamplerIn.intWaitingTime = 10
            structAutoSamplerIn.intProbeTime = 15
            structAutoSamplerIn.blnAutoSamplerInitialised = False
            structAutoSamplerIn.blnHome = False
            structAutoSamplerIn.blnProbe = False
            structAutoSamplerIn.blnPump = False
            structAutoSamplerIn.blnPumpPrev = False
            structAutoSamplerPosIn.intSpectrumPosition = 0
            structAutoSamplerPosIn.intTimeScanPosition = 0
            structAutoSamplerPosIn.intQuantPosition = 0
            structAutoSamplerPosIn.intPhotometryPosition = 0
            structAutoSamplerPosIn.intKineticPosition = 0
            structAutoSamplerPosIn.intMultiPosition = 0
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
    Public Function gfuncReadSamplerParameterFromINI(ByRef structAutoSamplerIn As structAutoSampler)
        Try
            structAutoSamplerIn.intComPort = CInt(gFuncGetFromINI(SECTION_AUTOSAMPLER, KEY_SERIALPORT, "2", INI_SETTINGS_PATH))
            structAutoSamplerIn.intBaudRate = CInt(gFuncGetFromINI(SECTION_AUTOSAMPLER, KEY_SAMPLERBAUDRATE, "9600", INI_SETTINGS_PATH))
            structAutoSamplerIn.intIntakeTime = CInt(gFuncGetFromINI(SECTION_AUTOSAMPLER, KEY_INTAKETIME, "10", INI_SETTINGS_PATH))
            structAutoSamplerIn.intWashTime = CInt(gFuncGetFromINI(SECTION_AUTOSAMPLER, KEY_WashTime, "10", INI_SETTINGS_PATH))
            structAutoSamplerIn.intWaitingTime = CInt(gFuncGetFromINI(SECTION_AUTOSAMPLER, KEY_MeasurementTime, "10", INI_SETTINGS_PATH))
            structAutoSamplerIn.intProbeTime = CInt(gFuncGetFromINI(SECTION_AUTOSAMPLER, KEY_ProbeWaitTime, "15", INI_SETTINGS_PATH))

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
    Public Function gfuncWriteSamplerParametersToINI(ByRef structAutoSamplerIn As structAutoSampler)
        Try
            gFuncWriteToINI(SECTION_AUTOSAMPLER, KEY_SERIALPORT, structAutoSamplerIn.intComPort.ToString, INI_SETTINGS_PATH)
            gFuncWriteToINI(SECTION_AUTOSAMPLER, KEY_SAMPLERBAUDRATE, structAutoSamplerIn.intBaudRate.ToString, INI_SETTINGS_PATH)
            gFuncWriteToINI(SECTION_AUTOSAMPLER, KEY_INTAKETIME, structAutoSamplerIn.intIntakeTime.ToString, INI_SETTINGS_PATH)
            gFuncWriteToINI(SECTION_AUTOSAMPLER, KEY_WashTime, structAutoSamplerIn.intWashTime.ToString, INI_SETTINGS_PATH)
            gFuncWriteToINI(SECTION_AUTOSAMPLER, KEY_MeasurementTime, structAutoSamplerIn.intWaitingTime.ToString, INI_SETTINGS_PATH)
            gFuncWriteToINI(SECTION_AUTOSAMPLER, KEY_ProbeWaitTime, structAutoSamplerIn.intProbeTime.ToString, INI_SETTINGS_PATH)

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
    Public Function gfuncEditSamplerPosition(ByRef intAutoSamplerPosn As Integer, ByVal strSampleName As String, ByVal intMaxSample As Integer, ByVal intMaxStandard As Integer, ByRef structAutoSamplerIn As structAutoSampler) As Boolean
        Dim mobjDataTable As New DataTable("AutoSamplerPosition")
        Dim objAutoSamplerPosition As New frmAutoSampPosn(mobjDataTable)
        Dim mobjGridTableStyle As New DataGridTableStyle
        Dim mdataView As New DataView
        Dim intRowCounter As Integer = 0
        Dim arrAutoSamplerIn As New ArrayList
        Dim intCounter As Integer = 0
        Try
            Call gfuncCreateDataTableOfSamplerPosition(mobjDataTable, intAutoSamplerPosn, strSampleName, intMaxSample, intMaxStandard, structAutoSamplerIn)
            Call gfuncFormatDataGridofSamplerPosition(mobjDataTable, mobjGridTableStyle, mdataView, objAutoSamplerPosition)
            For intCounter = 0 To structAutoSamplerIn.arrAutoSamplerPosition.Count - 1
                arrAutoSamplerIn.Add(structAutoSamplerIn.arrAutoSamplerPosition.Item(intCounter))
            Next
            '    Dim objAutoSamplerPosition As New frmAutoSampPosn(mobjDataTable)
            objAutoSamplerPosition.ShowDialog()
            If objAutoSamplerPosition.DialogResult = DialogResult.OK Then
                structAutoSamplerIn.arrAutoSamplerPosition.Clear()
                For intCounter = 0 To intAutoSamplerPosn - 1
                    structAutoSamplerIn.arrAutoSamplerPosition.Add(arrAutoSamplerIn.Item(intCounter))
                Next
                While objAutoSamplerPosition.dgSamplerPosition.Item(intRowCounter, 1) <> 0
                    structAutoSamplerIn.arrAutoSamplerPosition.Add(objAutoSamplerPosition.dgSamplerPosition.Item(intRowCounter, 1))
                    intRowCounter += 1
                    If intRowCounter = intMaxSample + intMaxStandard - intAutoSamplerPosn Then
                        Exit While
                    End If
                End While

                Return True
            Else
                Return False
            End If
            objAutoSamplerPosition.Dispose()
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
        End Try
    End Function
    Public Function gfuncFormatDataGridofSamplerPosition(ByRef mobjDataTable As DataTable, ByRef mobjGridTableStyle As DataGridTableStyle, ByRef mdataView As DataView, ByRef objAutoSamplerPosition As frmAutoSampPosn)
        Dim objTextColumn As DataGridTextBoxColumn
        Dim objTextColumn1 As DataGridTextBoxColumn
        Try
            ' Dim objAutoSamplerPosition As New frmAutoSampPosn(mobjDataTable)

            objAutoSamplerPosition.dgSamplerPosition.TableStyles.Clear()
            objAutoSamplerPosition.dgSamplerPosition.DataSource = mdataView
            objAutoSamplerPosition.dgSamplerPosition.ReadOnly = False
            mdataView.Table = mobjDataTable
            mdataView.AllowNew = False


            mobjGridTableStyle.RowHeadersVisible = False
            mobjGridTableStyle.BackColor = Color.FloralWhite
            mobjGridTableStyle.GridLineColor = Color.SandyBrown
            mobjGridTableStyle.HeaderBackColor = Color.FloralWhite
            mobjGridTableStyle.HeaderForeColor = Color.Black
            mobjGridTableStyle.AlternatingBackColor = Color.FloralWhite
            mobjGridTableStyle.AllowSorting = False
            mobjGridTableStyle.MappingName = "AutoSamplerPosition"

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "SampleID"
            objTextColumn.HeaderText = "SampleID"
            objTextColumn.Width = 90
            objTextColumn.ReadOnly = True
            objTextColumn.NullText = " "
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn1 = New DataGridTextBoxColumn
            objTextColumn1.MappingName = "SamplerPosition"
            objTextColumn1.HeaderText = "Sampler Position"
            objTextColumn1.Width = 105
            objTextColumn1.ReadOnly = False
            objTextColumn1.NullText = " "
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn1)

            mobjGridTableStyle.GridLineColor = Color.Black
            objAutoSamplerPosition.dgSamplerPosition.TableStyles.Add(mobjGridTableStyle)
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
    Public Function gfuncCreateDataTableOfSamplerPosition(ByRef mobjDataTable As DataTable, ByRef intAutoSamplerPosn As Integer, ByVal strSampleName As String, ByVal intMaxSample As Integer, ByVal intMaxStandard As Integer, ByRef structAutoSamplerIn As structAutoSampler)
        Dim objDataRow As DataRow
        Dim j As Integer
        Try
            mobjDataTable.Columns.Add(New DataColumn("SampleID", GetType(String)))
            mobjDataTable.Columns.Add(New DataColumn("SamplerPosition", GetType(String)))
            Select Case OPERATION_MODE
                Case EnumService_Mode.Quantitative, EnumService_Mode.Multiomponent
                    Call gfuncSetSamplerPositionForQuant(intAutoSamplerPosn, intMaxSample, objDataRow, mobjDataTable, intMaxStandard, strSampleName, gstructAutoSampler)
                Case EnumService_Mode.TimeScan, EnumService_Mode.Kinetics
                    Call gfuncSetSamplerPositionForKinetics(intAutoSamplerPosn, intMaxSample, objDataRow, mobjDataTable, structAutoSamplerIn)
                Case Else 'photmetry & spectrum
                    Call gfuncSetSamplerPosition(intAutoSamplerPosn, intMaxSample, objDataRow, mobjDataTable, structAutoSamplerIn)
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
    End Function
    Public Function gfuncSetSamplerPosition(ByVal intCurrentposition As Integer, ByVal IntMax As Integer, ByRef objDataRow As DataRow, ByRef objDataTable As DataTable, ByRef structAutoSamplerIn As structAutoSampler)
        Dim temp_cnt As Integer
        Try
            For temp_cnt = intCurrentposition + 1 To IntMax

                'If temp_cnt <= 10 Then
                If intCurrentposition = 0 And structAutoSamplerIn.arrAutoSamplerPosition.Count = 0 Then
                    If temp_cnt <= 10 Then
                        objDataRow = objDataTable.NewRow
                        objDataRow("SamplerPosition") = (temp_cnt + 1)
                        objDataRow("SampleID") = "Sample # " & temp_cnt
                        objDataTable.Rows.Add(objDataRow)
                    Else
                        objDataRow = objDataTable.NewRow
                        objDataRow("SamplerPosition") = 0
                        objDataRow("SampleID") = "Sample # " & temp_cnt
                        objDataTable.Rows.Add(objDataRow)
                    End If

                ElseIf intCurrentposition = 0 And structAutoSamplerIn.arrAutoSamplerPosition.Count <> 0 Then
                    If structAutoSamplerIn.arrAutoSamplerPosition.Count >= temp_cnt Then
                        objDataRow = objDataTable.NewRow
                        objDataRow("SamplerPosition") = structAutoSamplerIn.arrAutoSamplerPosition.Item(temp_cnt - 1)
                        objDataRow("SampleID") = "Sample # " & temp_cnt
                        objDataTable.Rows.Add(objDataRow)
                    Else
                        objDataRow = objDataTable.NewRow
                        objDataRow("SamplerPosition") = 0
                        objDataRow("SampleID") = "Sample # " & temp_cnt
                        objDataTable.Rows.Add(objDataRow)
                    End If
                Else
                    'if loop added & code commented by sns on 200404 
                    If structAutoSamplerIn.arrAutoSamplerPosition.Count >= temp_cnt Then
                        objDataRow = objDataTable.NewRow
                        objDataRow("SamplerPosition") = structAutoSamplerIn.arrAutoSamplerPosition.Item(temp_cnt - 1)
                        objDataRow("SampleID") = "Sample # " & temp_cnt
                        objDataTable.Rows.Add(objDataRow)
                    Else
                        objDataRow = objDataTable.NewRow
                        objDataRow("SamplerPosition") = 0
                        objDataRow("SampleID") = "Sample # " & temp_cnt
                        objDataTable.Rows.Add(objDataRow)
                    End If
                    'objDataRow = objDataTable.NewRow
                    'objDataRow("SamplerPosition") = 0
                    'objDataRow("SampleID") = "Sample # " & temp_cnt
                    'objDataTable.Rows.Add(objDataRow)

                End If

            Next
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

    Public Function gfuncSetSamplerPositionForKinetics(ByVal intCurrentposition As Integer, ByVal IntMax As Integer, ByRef objDataRow As DataRow, ByRef objDataTable As DataTable, ByRef structAutoSamplerIn As structAutoSampler)
        Dim temp_cnt As Integer
        Try
            For temp_cnt = intCurrentposition + 1 To IntMax

                'If temp_cnt <= 10 Then
                If intCurrentposition = 0 And structAutoSamplerIn.arrAutoSamplerPosition.Count = 0 Then
                    If temp_cnt <= 10 Then
                        objDataRow = objDataTable.NewRow
                        objDataRow("SamplerPosition") = (temp_cnt + 1)
                        objDataRow("SampleID") = "Sample # " & temp_cnt
                        objDataTable.Rows.Add(objDataRow)
                    Else
                        objDataRow = objDataTable.NewRow
                        objDataRow("SamplerPosition") = 0
                        objDataRow("SampleID") = "Sample # " & temp_cnt
                        objDataTable.Rows.Add(objDataRow)
                    End If

                ElseIf intCurrentposition >= 0 And structAutoSamplerIn.arrAutoSamplerPosition.Count <> 0 Then
                    'ElseIf intCurrentposition = 0 And structAutoSamplerIn.arrAutoSamplerPosition.Count <> 0 Then
                    If structAutoSamplerIn.arrAutoSamplerPosition.Count >= temp_cnt Then
                        objDataRow = objDataTable.NewRow
                        objDataRow("SamplerPosition") = structAutoSamplerIn.arrAutoSamplerPosition.Item(temp_cnt - 1)
                        objDataRow("SampleID") = "Sample # " & temp_cnt
                        objDataTable.Rows.Add(objDataRow)
                    Else
                        objDataRow = objDataTable.NewRow
                        objDataRow("SamplerPosition") = 0
                        objDataRow("SampleID") = "Sample # " & temp_cnt
                        objDataTable.Rows.Add(objDataRow)
                    End If
                Else
                    objDataRow = objDataTable.NewRow
                    objDataRow("SamplerPosition") = 0
                    objDataRow("SampleID") = "Sample # " & temp_cnt
                    objDataTable.Rows.Add(objDataRow)

                End If

            Next
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


    Public Function gfuncSetSamplerPositionForQuant(ByVal intCurrentposition As Integer, ByVal IntMax As Integer, ByRef objDataRow As DataRow, ByRef objDataTable As DataTable, ByVal intNoStd As Integer, ByVal strName As String, ByRef structAutoSamplerIn As structAutoSampler)
        Dim temp_cnt As Integer
        Try
            For temp_cnt = intCurrentposition + 1 To IntMax + intNoStd
                If temp_cnt <= intNoStd Then
                    If intCurrentposition = 0 And structAutoSamplerIn.arrAutoSamplerPosition.Count = 0 Then
                        objDataRow = objDataTable.NewRow
                        objDataRow("SamplerPosition") = (temp_cnt + 1)
                        objDataRow("SampleID") = "STD # " & temp_cnt
                        objDataTable.Rows.Add(objDataRow)
                    ElseIf intCurrentposition = 0 And structAutoSamplerIn.arrAutoSamplerPosition.Count <> 0 Then
                        If structAutoSamplerIn.arrAutoSamplerPosition.Count >= temp_cnt Then
                            objDataRow = objDataTable.NewRow
                            objDataRow("SamplerPosition") = structAutoSamplerIn.arrAutoSamplerPosition.Item(temp_cnt - 1)
                            objDataRow("SampleID") = "STD # " & temp_cnt
                            objDataTable.Rows.Add(objDataRow)
                        Else
                            objDataRow = objDataTable.NewRow
                            objDataRow("SamplerPosition") = 0 '(temp_cnt + 1)
                            objDataRow("SampleID") = "STD # " & temp_cnt
                            objDataTable.Rows.Add(objDataRow)
                        End If
                    Else
                        objDataRow = objDataTable.NewRow
                        objDataRow("SamplerPosition") = 0 '(temp_cnt + 1)
                        objDataRow("SampleID") = "STD # " & temp_cnt
                        objDataTable.Rows.Add(objDataRow)
                    End If
                Else

                    objDataRow = objDataTable.NewRow

                    If temp_cnt <= 10 And intCurrentposition = 0 And structAutoSamplerIn.arrAutoSamplerPosition.Count = 0 Then
                        objDataRow("SamplerPosition") = temp_cnt + 1

                    ElseIf intCurrentposition = 0 And structAutoSamplerIn.arrAutoSamplerPosition.Count <> 0 Then
                        If structAutoSamplerIn.arrAutoSamplerPosition.Count >= temp_cnt Then
                            objDataRow("SamplerPosition") = structAutoSamplerIn.arrAutoSamplerPosition.Item(temp_cnt - 1)
                        Else
                            objDataRow("SamplerPosition") = 0
                        End If
                    Else
                        objDataRow("SamplerPosition") = 0
                    End If
                    If strName = "" Then
                        objDataRow("SampleID") = "Sample # " & temp_cnt - intNoStd
                    Else
                        objDataRow("SampleID") = strName & temp_cnt - intNoStd
                    End If
                    objDataTable.Rows.Add(objDataRow)

                End If


            Next
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
    Public Function gfuncOpenCommunicationForAutoSampler(ByRef structAutoSamplerIn As structAutoSampler) As Boolean

        Try

            If structAutoSamplerIn.blnAutoSamplerInitialised Then
                '  If gintCommPortSelected2 = cboPort_Selection.SelectedIndex + 1 Then
                If gobjCommProtocol.mobjCommdll.gFuncIsPortOpen2() Then
                    '                    gFuncShowMessage("Port Already Open", "The selected port is in use, try with other ports", EnumMessageType.Information)
                    Call gobjMessageAdapter.ShowMessage(constComPortBusy)
                    Return False
                    Exit Function
                End If
                'End If
            End If

            If gobjCommProtocol.mobjCommdll.gFuncIsPortOpen2() Then
                gobjCommProtocol.mobjCommdll.gFuncCloseComm2()
            End If

            '  gintCommPortSelected2 = cboPort_Selection.SelectedIndex + 1

            If Not gobjCommProtocol.mobjCommdll.gFuncISPortAvailable(gintCommPortSelected2) Then

                Call gobjMessageAdapter.ShowMessage(constComPortBusy)
                gintCommPortSelected2 = 0
                Return False
            Else

                If Not gobjCommProtocol.mobjCommdll.gFuncOpenCommPort2(gintCommPortSelected2, structAutoSamplerIn.intBaudRate, 0, 1, 8) Then

                    Call gobjMessageAdapter.ShowMessage(constComPortBusy)
                    structAutoSamplerIn.blnCommunication = False
                    Return False
                Else
                    structAutoSamplerIn.blnCommunication = True
                    '--- write the port to ini 
                    gFuncWriteToINI(SECTION_AUTOSAMPLER, KEY_SERIALPORT, CStr(gintCommPortSelected2), INI_SETTINGS_PATH)
                End If
                '      Call gFuncInitSampler(gstructAutoSampler)
                '     Me.Close()
            End If
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
        End Try

    End Function

#End Region

#Region "AutoSampler Functions by Pankaj Bamb"

    Public Function gfuncLoadAutoSamplerFlag() As Boolean
        'int i=1;
        'FILE *fptr=NULL;
        'fptr=fopen("asampler.pos","rt");
        '       If (fptr! = NULL) Then
        ' {
        'fscanf(fptr,"%d\n",&i);
        'fclose(fptr);
        ' Autosampler=FALSE;
        ' if(i==1)
        ' Autosampler=TRUE;
        ' }
        gfuncLoadAutoSamplerFlag = False
        Try
            Dim i As Integer
            Dim fs As FileStream
            Dim path As String = Application.StartupPath & "\asampler.pos"
            If File.Exists(path) = False Then
                Return False
            End If
            fs = New FileStream(path, FileMode.Open, FileAccess.Read)
            Dim r As New BinaryReader(fs)
            i = r.ReadInt32()
            If (i = 1) Then
                gstructAutoSampler.blnAutoSamplerInitialised = True
            End If
            r.Close()
            fs.Close()

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
    Public Function gfuncWriteAutoSamplerFlag() As Boolean

        Try
            Dim i As Integer
            Dim fs As FileStream
            Dim path As String = Application.StartupPath & "\asampler.pos"
            If File.Exists(path) = False Then
                File.Create(path)
            End If
            fs = New FileStream(path, FileMode.Open, FileAccess.Write)
            Dim r As New BinaryWriter(fs)
            If gstructAutoSampler.blnAutoSamplerInitialised = True Then
                i = 1
                r.Write(i)
            Else
                i = 0
                r.Write(i)
            End If
            r.Close()
            fs.Close()

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

#End Region

#Region "AutoSampler UtilityFunctions"
    Public Function gFuncInitSampler(ByRef structAutoSamplerIn As structAutoSampler) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name	    :   gFuncInitSampler
        'Description	    :   To initalize the sampler 
        'Parameters 	    :   None
        'Time/Date  	    :   12:34 7/04/2004
        'Dependencies	    :   Sampler unit and second com Port    
        'Author		        :   M.Kamal
        'Revision		    :
        'Revision by Person	:
        '--------------------------------------------------------------------------------------
        Dim blnFlag As Boolean = False
        Dim objfrmComPort As New frmAutoSamplerComPort
        Try
            structAutoSamplerIn.blnAutoSamplerInitialised = False
            '--- Make the Autosampler Home 
            'blnFlag = gFuncAutoSamplerHome()
            Call gfuncInitialiseGlobalValues(gstructAutoSampler, gstructAutoSamplerPosition)
            Call gfuncReadSamplerParameterFromINI(structAutoSamplerIn)
            gintCommPortSelected2 = structAutoSamplerIn.intComPort
            Cursor.Current = Cursors.WaitCursor

            If Not gfuncOpenCommunicationForAutoSampler(structAutoSamplerIn) Then
                blnFlag = False
            Else
                If gobjCommProtocol.funcAutoSamplerHome() Then
                    structAutoSamplerIn.blnHome = True
                    structAutoSamplerIn.blnCommunication = True
                    structAutoSamplerIn.intCoordinateX = 0
                    structAutoSamplerIn.intCoordinateY = 0
                    blnFlag = True
                Else
                    blnFlag = False
                End If
            End If
            Cursor.Current = Cursors.Default
            If blnFlag Then
                'gFuncShowMessage(" RS232C OK", "AutoSampler connected to COM" & gstructAutoSampler.intComPort & " port", EnumMessageType.Information)
                Call gobjMessageAdapter.ShowMessage("AutoSampler connected to COM" & gstructAutoSampler.intComPort & " port", "RS232C OK", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                structAutoSamplerIn.blnAutoSamplerInitialised = True
                '//----- Add by Sachn Dokhale on 14.12.05
                If Not objfrmComPort Is Nothing Then
                    objfrmComPort.Dispose()
                End If
                '//-----

                gFuncInitSampler = True
            Else
                'gFuncShowMessage(" RS232C ERROR", "Error reading communication port " & vbCrLf & "either instrument is swithed OFF" & vbCrLf & "or connect Autosampler to COM" & gstructAutoSampler.intComPort & " port and retry", EnumMessageType.Information)
                Call gobjMessageAdapter.ShowMessage("Error reading communication port " & vbCrLf & "either instrument is swithed OFF" & vbCrLf & "or connect Autosampler to COM" & gstructAutoSampler.intComPort & " port and retry", "RS232C ERROR", EnumMessageType.Information)
                gFuncInitSampler = False
                gobjCommProtocol.mobjCommdll.gFuncCloseComm2()
                structAutoSamplerIn.blnCommunication = False
                objfrmComPort.ShowDialog()
                objfrmComPort.Dispose()
            End If
            '//----- Add by Sachin Dokhale on 14.12.05
            If Not objfrmComPort Is Nothing Then
                objfrmComPort.Dispose()
            End If
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
            Cursor.Current = Cursors.Default
        End Try

    End Function
#End Region

#Region "AutoSampler Working Functions Like Washing , Cleaning etc"

    Public Function gfuncSetAutoSampler(ByRef objLabel As System.Object, ByRef structAutoSamplerIN As structAutoSampler, ByRef intPosition As Integer, ByVal blnFlag As Boolean) As Boolean
        Try

            If structAutoSamplerIN.blnCommunication = False Then
                Return False
            End If

            If blnFlag Then
                objLabel.Text = "Sampler => " & intPosition
                Call gfuncAutoSamplerStartStatus(intPosition, objLabel, structAutoSamplerIN)
            Else
                objLabel.Text = "Resetting Sampler"
                Call gfuncAutoSamplerEndStatus(objLabel, structAutoSamplerIN)
            End If
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
        End Try



    End Function


    Public Function gfuncAutoSamplerReadyStatus(ByVal intx As Integer, ByVal inty As Integer, ByVal blnFlag As Boolean, ByVal objLabel As Label, ByRef structAutoSamplerIn As structAutoSampler)
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name	    :   gfuncAutoSamplerReadyStatus
        'Description	    :   To prepare sampler for working 
        'Parameters 	    :   None
        'Time/Date  	    :   12:34 7/04/2004
        'Dependencies	    :  gstructAutoSampler.intposition
        'Author		        :   M.Kamal
        'Revision		    :
        'Revision by Person	:
        '--------------------------------------------------------------------------------------
        Try
            If blnFlag Then
                objLabel.Text = "Sampler =>  " & structAutoSamplerIn.intPosition
            Else
                objLabel.Text = "Washing ...     "
            End If
            'If gfuncAutoSamplerGoTo(intx, inty, structAutoSamplerIn) Then
            If gobjCommProtocol.funcAutoSamplerGoTo(intx, inty, structAutoSamplerIn) Then
                structAutoSamplerIn.intCoordinateX = intx
                structAutoSamplerIn.intCoordinateY = inty

            End If
            Call gobjCommProtocol.funcAutoSamplerProbeDown()
            Call gobjCommProtocol.funcAutoSamplerPumpON()
            If blnFlag Then
                objLabel.Text = "Sample is flowing     "
                'Wait while intaking
                'subTime_Delay(structAutoSamplerIn.intIntakeTime * 1000)
                'Call gobjCommProtocol.mobjCommdll.subTime_Delay(structAutoSamplerIn.intIntakeTime * 1000)
                Call gobjCommProtocol.mobjCommdllAutoSampler.subTime_Delay(structAutoSamplerIn.intIntakeTime * 1000)   'added by pankaj on 25 Mar 08
            Else
                objLabel.Text = "Washing ...     "
                'wait till wash time 
                'subTime_Delay(structAutoSamplerIn.intWashTime * 1000)
                'Call gobjCommProtocol.mobjCommdll.subTime_Delay(structAutoSamplerIn.intWashTime * 1000)
                Call gobjCommProtocol.mobjCommdllAutoSampler.subTime_Delay(structAutoSamplerIn.intWashTime * 1000)   'added by pankaj on 25 Mar 08
            End If
            Call gobjCommProtocol.funcAutoSamplerPumpOFF()
            '//----- Added by Sachin Dokhale on 30.12.05
            If Not blnFlag Then
                Call gobjCommProtocol.funcAutoSamplerProbeUp()
            End If
            '//-----

            If blnFlag Then
                objLabel.Text = "Measuring ...  "
                'wait till waiting time
                'subTime_Delay(structAutoSamplerIn.intWaitingTime * 1000)
                'Call gobjCommProtocol.mobjCommdll.subTime_Delay(structAutoSamplerIn.intWaitingTime * 1000)
                Call gobjCommProtocol.mobjCommdllAutoSampler.subTime_Delay(structAutoSamplerIn.intWaitingTime * 1000)   'added by pankaj on 25 Mar 08
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

    End Function

    Public Function gfuncAutoSamplerStartStatus(ByVal intPosition As Integer, ByVal objLabel As Label, ByRef structAutoSamplerIn As structAutoSampler) As Integer
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name	    :   gfuncAutoSamplerStartStatus
        'Description	    :   To start the sampler for accessing 
        'Parameters 	    :   None
        'Time/Date  	    :   12:34 7/04/2004
        'Dependencies	    :   gstructAutoSampler.intPosition  
        'Author		        :   M.Kamal
        'Revision		    :
        'Revision by Person	:
        '--------------------------------------------------------------------------------------

        Dim intx As Integer
        Dim inty As Integer

        Try
            'intx = intPosition / 5 
            intx = Int(intPosition / 5) ''by Pankaj for checking max position on 01 OCT 07

            inty = intPosition Mod 5

            If intPosition <> 0 And inty = 0 Then
                inty = 5
                intx -= 1
            End If
            If (intx > 12) Then 'by Pankaj for checking max position on 01 OCT 07
                intx = 12
            End If
            If (inty > 5) Then 'by Pankaj for checking max position on 01 OCT 07
                intx = 5
            End If
            structAutoSamplerIn.intPosition = intPosition
            Call gfuncAutoSamplerReadyStatus(intx, inty, True, objLabel, structAutoSamplerIn)
            Return 1

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

    Public Function gfuncAutoSamplerDrainStatus(ByVal objLabel As Label, ByRef structAutoSamplerIn As structAutoSampler) As Integer
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name	    :   gfuncAutoSamplerDrainStatus
        'Description	    :   To Drain the sampler 
        'Parameters 	    :   None
        'Time/Date  	    :   12:34 7/04/2004
        'Dependencies	    :   
        'Author		        :   M.Kamal
        'Revision		    :
        'Revision by Person	:
        '--------------------------------------------------------------------------------------
        Try
            Call gobjCommProtocol.funcAutoSamplerPumpOFF()
            Call gobjCommProtocol.funcAutoSamplerProbeUp()
            objLabel.Text = "Draining ...     "
            If gobjCommProtocol.funcAutoSamplerGoTo(0, 1, structAutoSamplerIn) Then
                structAutoSamplerIn.intCoordinateX = 0
                structAutoSamplerIn.intCoordinateY = 1
            End If
            Call gobjCommProtocol.funcAutoSamplerProbeDown()
            Call gobjCommProtocol.funcAutoSamplerPumpONRev()
            'Wait while WashTime
            'Call subTime_Delay(structAutoSamplerIn.intWashTime * 1000)
            'Call gobjCommProtocol.mobjCommdll.subTime_Delay(structAutoSamplerIn.intWashTime * 1000)
            Call gobjCommProtocol.mobjCommdllAutoSampler.subTime_Delay(structAutoSamplerIn.intWashTime * 1000)   'added by pankaj on 25 Mar 08
            Return 1

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

    Public Function gfuncAutoSamplerEndStatus(ByVal objLabel As Label, ByRef structAutoSamplerIn As structAutoSampler) As Integer
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name	    :   gfuncAutoSamplerEndStatus
        'Description	    :   To ending the process of the sampler 
        'Parameters 	    :   None
        'Time/Date  	    :   12:34 7/04/2004
        'Dependencies	    :       
        'Author		        :   M.Kamal
        'Revision		    :
        'Revision by Person	:
        '--------------------------------------------------------------------------------------
        Try
            Call gfuncAutoSamplerDrainStatus(objLabel, structAutoSamplerIn)
            objLabel.Text = "Washing ...  "
            Call gobjCommProtocol.funcAutoSamplerPumpOFF()
            Call gobjCommProtocol.funcAutoSamplerProbeUp()
            Call gfuncAutoSamplerCleanStatus(objLabel, structAutoSamplerIn)
            Call gfuncAutoSamplerDrainStatus(objLabel, structAutoSamplerIn)

            Call gobjCommProtocol.funcAutoSamplerPumpOFF()
            Call gobjCommProtocol.funcAutoSamplerProbeUp()
            If gobjCommProtocol.funcAutoSamplerGoTo(structAutoSamplerIn.intCoordinateX, 1, structAutoSamplerIn) Then
                structAutoSamplerIn.intCoordinateY = 1
            End If
            Return 1
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

    Public Function gfuncAutoSamplerCleanStatus(ByVal objLabel As Label, ByRef structAutoSamplerIn As structAutoSampler)
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name	    :   gfuncAutoSamplerCleanStatus
        'Description	    :   To Clean the sampler 
        'Parameters 	    :   None
        'Time/Date  	    :   12:34 7/04/2004
        'Dependencies	    :   
        'Author		        :   M.Kamal
        'Revision		    :
        'Revision by Person	:
        '--------------------------------------------------------------------------------------
        Try
            Call gfuncAutoSamplerReadyStatus(0, 0, False, objLabel, structAutoSamplerIn)
            Call gobjCommProtocol.funcAutoSamplerPumpOFF()
            Call gobjCommProtocol.funcAutoSamplerProbeUp()
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

    Public Function gfuncCheckAutoSampler(ByRef structAutoSamplerIn As structAutoSampler) As Boolean
        Dim objfrmComport As frmAutoSamplerComPort
        Try
            gobjCommProtocol.funcAutoSamplerPumpOFF()
            If structAutoSamplerIn.blnCommunication = False Then
                If gobjMessageAdapter.ShowMessage(constAutoSamplerConnectionLost) = True Then
                    objfrmComport.ShowDialog()
                    objfrmComport.Dispose()
                End If
            End If
            Return structAutoSamplerIn.blnCommunication

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

#End Region

End Module
