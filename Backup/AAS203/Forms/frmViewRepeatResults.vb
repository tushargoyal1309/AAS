Imports AAS203Library
Imports AAS203Library.Method
Imports AAS203.Common

Public Class frmViewRepeatResults
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal objMethod As clsMethod, ByVal intSelectedRunNumberIndex As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mobjclsMethod = objMethod
        mintSelectedRunNumberIndex = intSelectedRunNumberIndex

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Office2003Header1 As CodeIntellects.Office2003Controls.Office2003Header
    Friend WithEvents btnOk As NETXP.Controls.XPButton
    Friend WithEvents btnDelete As NETXP.Controls.XPButton
    Friend WithEvents CustomPanel1 As GradientPanel.CustomPanel
    Friend WithEvents RepeatResultsViewer As GridLayoutPanel.GridLayoutPanel
    Friend WithEvents btnPrint As NETXP.Controls.XPButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmViewRepeatResults))
        Me.Office2003Header1 = New CodeIntellects.Office2003Controls.Office2003Header
        Me.RepeatResultsViewer = New GridLayoutPanel.GridLayoutPanel(Me.components)
        Me.CustomPanel1 = New GradientPanel.CustomPanel
        Me.btnPrint = New NETXP.Controls.XPButton
        Me.btnDelete = New NETXP.Controls.XPButton
        Me.btnOk = New NETXP.Controls.XPButton
        Me.Office2003Header1.SuspendLayout()
        Me.CustomPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Office2003Header1
        '
        Me.Office2003Header1.AutoScroll = True
        Me.Office2003Header1.BackColor = System.Drawing.Color.Transparent
        Me.Office2003Header1.Controls.Add(Me.RepeatResultsViewer)
        Me.Office2003Header1.Controls.Add(Me.CustomPanel1)
        Me.Office2003Header1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Office2003Header1.Location = New System.Drawing.Point(0, 0)
        Me.Office2003Header1.Name = "Office2003Header1"
        Me.Office2003Header1.Size = New System.Drawing.Size(778, 391)
        Me.Office2003Header1.TabIndex = 0
        Me.Office2003Header1.TitleFont = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Office2003Header1.TitleText = "Repeat Results"
        '
        'RepeatResultsViewer
        '
        Me.RepeatResultsViewer.AutoScroll = True
        Me.RepeatResultsViewer.ColumnCount = 1
        Me.RepeatResultsViewer.ControlHSpacing = 1
        Me.RepeatResultsViewer.ControlVSpacing = 1
        Me.RepeatResultsViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RepeatResultsViewer.ErrorText = ""
        Me.RepeatResultsViewer.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RepeatResultsViewer.Location = New System.Drawing.Point(0, 0)
        Me.RepeatResultsViewer.Name = "RepeatResultsViewer"
        Me.RepeatResultsViewer.SelectedIndex = 0
        Me.RepeatResultsViewer.ShowError = False
        Me.RepeatResultsViewer.SingleRowGrid = False
        Me.RepeatResultsViewer.Size = New System.Drawing.Size(778, 335)
        Me.RepeatResultsViewer.TabIndex = 120
        '
        'CustomPanel1
        '
        Me.CustomPanel1.Controls.Add(Me.btnPrint)
        Me.CustomPanel1.Controls.Add(Me.btnDelete)
        Me.CustomPanel1.Controls.Add(Me.btnOk)
        Me.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CustomPanel1.Location = New System.Drawing.Point(0, 335)
        Me.CustomPanel1.Name = "CustomPanel1"
        Me.CustomPanel1.Size = New System.Drawing.Size(778, 56)
        Me.CustomPanel1.TabIndex = 119
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.Color.Transparent
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrint.Location = New System.Drawing.Point(210, 14)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(100, 36)
        Me.btnPrint.TabIndex = 118
        Me.btnPrint.Text = "&Print"
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.Transparent
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(339, 13)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(100, 38)
        Me.btnDelete.TabIndex = 117
        Me.btnDelete.Text = "&Delete"
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.Color.Transparent
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Image = CType(resources.GetObject("btnOk.Image"), System.Drawing.Image)
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(468, 13)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(100, 36)
        Me.btnOk.TabIndex = 116
        Me.btnOk.Text = "&OK"
        '
        'frmViewRepeatResults
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(778, 391)
        Me.Controls.Add(Me.Office2003Header1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmViewRepeatResults"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Repeat Results"
        Me.Office2003Header1.ResumeLayout(False)
        Me.CustomPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Private Class Member Valriables "

    Private mobjclsMethod As clsMethod
    Private mintSelectedRunNumberIndex As Integer
    Private mobjRepeatResultsControlArray() As RepeatResultsControl
    Private mIntSelectedStdOrSplNo As Integer
    Private mIntSelectedRepeatNo As Integer
    Private mBlnIsStandard As Boolean
    Private mobjRepeatResultsControl As RepeatResultsControl
    Dim marrControls As New ArrayList
#End Region

#Region " Form Load and Events Handling Functions "

    Private Sub frmViewRepeatResults_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmViewRepeatResults_Load
        ' Parameters Passed     : object, eventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : To initialize and display repeat result calculations
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 10-Mar-2007 11:35 pm
        ' Revisions             : 1
        '=====================================================================
        Dim maxsamp As Integer

        Try
            '---find number of samples analyzed
            maxsamp = clsStandardGraph.FindSamplesAnalysed(mobjclsMethod, mintSelectedRunNumberIndex)
            If maxsamp > 0 Then
                '---set display properties of repeats
                RepeatResultsViewer.ColumnCount = 1
                RepeatResultsViewer.ControlHSpacing = 0
                RepeatResultsViewer.ControlVSpacing = 0
                RepeatResultsViewer.ShowError = False
                RepeatResultsViewer.BringToFront()

                ReDim mobjRepeatResultsControlArray(maxsamp - 1)
                '---display repeat result calculations on screen
                Call Init_Repeat_Screen(maxsamp)
            End If

            Dim intcount As Integer
            For intcount = 1 To 15
                marrControls.Add(intcount)
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
    End Sub

    Private Sub frmViewRepeatResults_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        '=====================================================================
        ' Procedure Name        : frmViewRepeatResults_Resize
        ' Parameters Passed     : object, eventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : to set width of each repeat result control
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 
        ' Revisions             : 0
        '=====================================================================
        Try
            '---to set width of each repeat result control
            If Not IsNothing(mobjRepeatResultsControlArray) Then
                Dim objRepeatResultsControl As RepeatResultsControl
                For Each objRepeatResultsControl In mobjRepeatResultsControlArray
                    objRepeatResultsControl.Width = RepeatResultsViewer.Width - 20
                Next
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

    Private Sub btnDelete_click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        '=====================================================================
        ' Procedure Name        : btnDelete_click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : To delete selected repeat control 
        '                         from controls collection
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 22.07.07
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim objRepeatResultsParameter As RepeatResultsControl
        Dim Count, Count1 As Integer
        Dim cursamp As AAS203Library.Method.clsAnalysisSampleParametersCollection
        Dim curstd As AAS203Library.Method.clsAnalysisStdParametersCollection
        Dim intCounter, i As Integer
        Dim blnFoundObject As Boolean = False
        Dim maxsamp As Integer
        Dim intIndexOfRepeatResultControl, intSampleIndex, intStdIndex As Integer
        Try

            '---to delete sample repeat
            If mBlnIsStandard = False Then
                For Count = 0 To mobjRepeatResultsControlArray.Length - 1
                    If Not (mobjRepeatResultsControlArray(Count).AnalysisParameter Is Nothing) Then
                        If mobjRepeatResultsControlArray(Count).AnalysisParameter.SampNumber = CInt(mIntSelectedStdOrSplNo) Then
                            objRepeatResultsParameter = mobjRepeatResultsControlArray(Count)
                            '---get the index of repeat result control which is to be deleted
                            intIndexOfRepeatResultControl = Count
                            Exit For
                        End If
                    End If
                Next

                If Not objRepeatResultsParameter Is Nothing Then
                    For Count = 0 To mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.Count - 1
                        If mIntSelectedStdOrSplNo = mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(Count).SampNumber Then
                            For Count1 = 0 To mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(Count).AbsRepeat.AbsRepeatData.Count - 1
                                If Not mIntSelectedRepeatNo = 0 Then
                                    If mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(Count).AbsRepeat.AbsRepeatData.item(mIntSelectedRepeatNo - 1).Used = True Then
                                        '---delete (logical) the selected repeat result control
                                        mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(Count).AbsRepeat.AbsRepeatData.item(mIntSelectedRepeatNo - 1).Used = False
                                        intSampleIndex = Count

                                        cursamp = mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.Clone
                                        maxsamp = clsStandardGraph.FindSamplesAnalysed(mobjclsMethod, mintSelectedRunNumberIndex)
                                        RepeatResultsViewer.RemoveControls()
                                        '---display/ refresh repeat result controls on screen
                                        Call Init_Repeat_Screen(maxsamp)
                                        blnFoundObject = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If blnFoundObject = True Then
                                Exit For
                            End If
                        End If
                    Next

                    If Not (cursamp Is Nothing) Then
                        If (cursamp.item(Count1).Used) Then
                            If Not (objRepeatResultsParameter Is Nothing) Then
                                '---display statistical calculations
                                Call objRepeatResultsParameter.ShowStatistic(cursamp.item(Count1).AbsRepeat.BasicStat, False, False)
                                Call objRepeatResultsParameter.ShowStatistic(cursamp.item(Count1).AbsRepeat.BasicStat, False, True)
                            End If
                        End If
                    End If
                    '---refresh sample controls array
                    funcRefreshControls_Sample(mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intSampleIndex))

                End If
            Else
                '---to delete std. repeat
                For Count = 0 To mobjRepeatResultsControlArray.Length - 1
                    If Not (mobjRepeatResultsControlArray(Count).StandardAnalysisParameter Is Nothing) Then
                        If mobjRepeatResultsControlArray(Count).StandardAnalysisParameter.StdNumber = CInt(mIntSelectedStdOrSplNo) Then
                            objRepeatResultsParameter = mobjRepeatResultsControlArray(Count)
                            Exit For
                        End If
                    End If
                Next

                If Not objRepeatResultsParameter Is Nothing Then
                    For Count = 0 To mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.Count - 1
                        If mIntSelectedStdOrSplNo = mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(Count).StdNumber Then
                            For Count1 = 0 To mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(Count).AbsRepeat.AbsRepeatData.Count - 1
                                If Not mIntSelectedRepeatNo = 0 Then
                                    If mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(Count).AbsRepeat.AbsRepeatData.item(mIntSelectedRepeatNo - 1).Used = True Then
                                        '---delete (logical) selected standard
                                        mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(Count).AbsRepeat.AbsRepeatData.item(mIntSelectedRepeatNo - 1).Used = False
                                        intStdIndex = Count

                                        curstd = mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.Clone
                                        RepeatResultsViewer.RemoveControls()
                                        '---refresh repeat result screen
                                        Call Init_Repeat_Screen(maxsamp)
                                        blnFoundObject = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If blnFoundObject = True Then
                                Exit For
                            End If
                        End If
                    Next


                    If Not (curstd Is Nothing) Then
                        If (curstd.item(Count1).Used) Then
                            If Not (objRepeatResultsParameter Is Nothing) Then
                                '---show statistical calculations
                                Call objRepeatResultsParameter.ShowStatistic(curstd.item(Count1).AbsRepeat.BasicStat, False, False)
                            End If
                        End If
                    End If
                End If
                '---refresh standard array
                funcRefreshControls_Std(mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(intStdIndex))
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
            '---------------------------------------------------------
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
        End Try
    End Sub

    Private Sub btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOk.Click
        '=====================================================================
        ' Procedure Name        : btnOk_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : To close the form
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 09-May-2007 02:25 pm
        ' Revisions             : Deepak on 16.10.08
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim intCount As Integer
        Dim std As AAS203Library.Method.clsAnalysisStdParameters
        Dim samp As AAS203Library.Method.clsAnalysisSampleParameters
        Dim valAbs, valConc As Double
        Try

            For intCount = 0 To mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.Count - 1
                std = mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(intCount)
                valAbs = std.AbsRepeat.BasicStat.ZAvg(0)
                std.Abs = valAbs
            Next

            For intCount = 0 To mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.Count - 1
                samp = mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intCount)
                valAbs = samp.AbsRepeat.BasicStat.ZAvg(0)
                valConc = samp.AbsRepeat.BasicStat.ZAvg(1)
                samp.Abs = valAbs
                samp.Conc = valConc
            Next

            Me.Close()

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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
        End Try
    End Sub

#End Region

#Region " Private Functions "

    Private Sub Init_Repeat_Screen(ByVal page As Integer)
        '=====================================================================
        ' Procedure Name        : Init_Repeat_Screen
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 10-Mar-2007 11:35 pm
        ' Revisions             : 1
        '=====================================================================


        '---- ORIGINAL CODE

        'void	Init_Repeat_Screen(HWND hwnd, int page)
        '{
        '	STDDATA 		*curstd=NULL;
        '	SAMPDATA 	*cursamp=NULL;

        '	int	i=0,j;

        '	curstd  =	Method->QuantData->StdTopData;
        '	cursamp =	Method->QuantData->SampTopData;
        '	ClrDispRepInfoStd(hwnd );
        '	i=0;
        '   While (curstd)
        '	{
        '       If (i >= page) Then
        '			break;
        '		/*  if (curstd->Data.Used)*/
        '		i++;
        '		curstd=curstd->next;
        '	}
        '	if (i<page && curstd==NULL)
        '	{
        '       While (cursamp)
        '		{
        '           If (i >= page) Then
        '				break;
        '			/*if (cursamp->Data.Used)*/
        '			i++;
        '			cursamp=cursamp->next;
        '		}
        '	}
        '	i=0; //page%3;
        '   While (curstd)
        '	{
        '		if (curstd==CurStd)
        '			break;
        '		if (curstd->Data.Used)
        '		{
        '			DisplayRepeatInfoStd(hwnd, curstd, i);
        '			i++;
        '		}
        '       If (i > 2) Then
        '			break;
        '		curstd=curstd->next;
        '	}
        '	while(i<3 &&cursamp )
        '	{
        '#If STD_ADDN Then
        '			if (cursamp==CurSamp)
        '				break;
        '#End If
        '		if (cursamp->Data.Used)
        '		{
        '			DisplayRepeatInfoSamp(hwnd, cursamp, i);
        '			i++;
        '		}
        '       If (i > 2) Then
        '			break;
        '       #If STD_ADDN Then
        '			if(Method->QuantData->Param.Std_Addn)
        '				break;
        '       #End If
        '		cursamp=cursamp->next;
        '	}
        '   If (i < 3) Then
        '	{
        '		for(; i<3; i++)
        '			for(j=0; j<NOOFITEMS;j++)
        '				ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), FALSE);
        '	}
        '}

        Dim i, j, intCounter As Integer
        Dim curstd As AAS203Library.Method.clsAnalysisStdParametersCollection
        Dim cursamp As AAS203Library.Method.clsAnalysisSampleParametersCollection

        Try
            '---get current stadards and samples
            curstd = mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.Clone
            cursamp = mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.Clone

            For intCounter = 0 To curstd.Count - 1
                If (curstd.item(intCounter).Used) Then
                    '---added by deepak on 22.07.07
                    '---perform basic statistics calculations
                    clsBasicStatistics.CalculateBasicStats(curstd(intCounter).AbsRepeat)
                    '---added by deepak on 22.07.07
                    '---display repeat calculation result
                    Call DisplayRepeatInfoStd(curstd.item(intCounter), i)
                    'i += 1
                End If
            Next


            'If clsBasicStatistics.CalculateBasicStats(objSample.AbsRepeat) Then
            '    objSample.Abs = objSample.AbsRepeat.BasicStat.ZAvg(0)
            '    cursamp(0).Abs()
            'End If

            For intCounter = 0 To cursamp.Count - 1
                If (cursamp.item(intCounter).Used) Then
                    'objSample.Abs = objSample.AbsRepeat.BasicStat.ZAvg(0)
                    '---perform basic statistics calculations
                    clsBasicStatistics.CalculateBasicStats(cursamp(intCounter).AbsRepeat)
                    cursamp(intCounter).Abs = cursamp(intCounter).AbsRepeat.BasicStat.ZAvg(0)
                    '---display repeat calculation result
                    Call DisplayRepeatInfoSamp(cursamp.item(intCounter), i)
                    'i += 1
                End If
            Next
            '---display grid on screen
            Call RepeatResultsViewer.ShowGrid()
            'AddHandler RepeatResultsViewer.ControlClicked, AddressOf objRepeatResultsControl_RepeatResultClick
            'AddHandler mobjRepeatResultsControl.RepeatResultClick, AddressOf objRepeatResultsControl_RepeatResultClick
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

    Private Sub DisplayRepeatInfoStd(ByVal curstd As Method.clsAnalysisStdParameters, ByRef i As Integer)
        '=====================================================================
        ' Procedure Name        : DisplayRepeatInfoStd
        ' Parameters Passed     : StandardInfo
        ' Returns               : None
        ' Purpose               : 
        ' Description           : Initialize control for each repeat and add it 
        '                         to controls collection
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 10-Mar-2007 01:25 pm
        ' Revisions             : 1
        '=====================================================================

         
        'void	DisplayRepeatInfoStd(HWND hwnd, STDDATA *curstd, int i)
        '{
        '	int	j=0;
        '	char	str[40]="";
        '	ABSREPEATDATA	*rpt=NULL;
        '	j=0;
        '   If (curstd) Then
        '	{
        '		sprintf(str,"%-2d",curstd->Data.StdNo);
        '		ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), TRUE);
        '		SetWindowText(GetDlgItem(hwnd, IDC_SAMPNAME+i*NOOFITEMS+j), str); j++;
        '		ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), TRUE);
        '		SetWindowText(GetDlgItem(hwnd, IDC_SAMPNAME+i*NOOFITEMS+j), curstd->Data.Std_Name);j++;
        '		j++;
        '		if (curstd->Data.AbsRepeat)
        '		{
        '			rpt = curstd->Data.AbsRepeat->RptDataTop;
        '                While (rpt)
        '			{
        '				if (Method->Mode==MODE_EMISSION)
        '					sprintf(str,"%-4.1f",rpt->Abs);
        '                    Else
        '				{
        '					StoreAbsAccurate(rpt->Abs,str);
        '					//sprintf(str,"%-4.3f",rpt->Abs);
        '				}
        '				ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), TRUE);
        '				SetDlgItemText(hwnd, IDC_SAMPNAME+i*NOOFITEMS+j, str); j++;
        '				rpt=rpt->next;
        '			}
        '			for(; j<NOOFITEMS-6; j++)
        '				ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), FALSE);
        '			j+=2;
        '			for(; j<NOOFITEMS-2; j++)
        '				ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), FALSE);
        '			ShowStatistic(hwnd, &(curstd->Data.AbsRepeat->Data), i, TRUE);
        '		}
        '	}
        '}

        Dim j As Integer
        Dim str As String

        Dim rpt As Method.clsAbsRepeatDataCollection
        Dim intCounter As Integer

        Try
            If Not IsNothing(curstd) Then
                '---Initialize control for each repeat
                Dim objRepeatResultsControl As New RepeatResultsControl
                'Dim objRepeatResultsControl As New GridLayoutPanel.RepeatResultsControl
                objRepeatResultsControl.StandardNumber = curstd.StdNumber
                'objRepeatResultsControl.StandardName = curstd.StdName 
                '---changed on 30.01.09 as per document received from app.lab 

                '---27.03.09
                ''objRepeatResultsControl.StandardName = curstd.StdName & Space(2) & "(Conc : " & FormatNumber(curstd.Concentration, 2) & " )"
                objRepeatResultsControl.StandardName = curstd.StdName & Space(2) & "(Conc : " & FormatNumber(curstd.Concentration, 4) & " )"
                '----

                objRepeatResultsControl.lstConcStats.Visible = False
                objRepeatResultsControl.lblConc.Visible = False
                objRepeatResultsControl.lblConcStats.Visible = False
                objRepeatResultsControl.RemoveOption.Visible = False
                objRepeatResultsControl.IsStandard = True

                '---02.12.07
                'objRepeatResultsControl.Dock = DockStyle.To
                'objRepeatResultsControl.AutoScroll = True

                '---add handler for each control item clicked
                AddHandler objRepeatResultsControl.RepeatItemClick, AddressOf SubRepeatResultsControl_RepeatResultClick
                If (mobjclsMethod.OperationMode = EnumOperationMode.MODE_EMMISSION) Then
                    objRepeatResultsControl.lblAbs.Text = "Emission"
                    '---added by deepak on 22.07.07
                    objRepeatResultsControl.lblAbsStats.Text = "Statistics on Emission"
                Else
                    objRepeatResultsControl.lblAbs.Text = "Abs"
                    '---added by deepak on 22.07.07
                    objRepeatResultsControl.lblAbsStats.Text = "Statistics on Abs"
                End If

                If Not IsNothing(curstd.AbsRepeat) Then
                    rpt = curstd.AbsRepeat.AbsRepeatData
                    j = 1
                    For intCounter = 0 To rpt.Count - 1
                        If rpt.item(intCounter).Used = True Then '22.07.07
                            '---format absorbance according to the mode
                            If (mobjclsMethod.OperationMode = EnumOperationMode.MODE_EMMISSION) Then
                                str = FormatNumber(rpt.item(intCounter).Abs, 1)
                            Else
                                str = FormatNumber(rpt.item(intCounter).Abs, 3)
                            End If
                            '---set abs value in control
                            Call objRepeatResultsControl.FindNSetValueInControl(str, j)
                            'Call objRepeatResultsControl.FindNSet2ndValueInControl(str, j)
                            j += 1
                        End If
                    Next
                    '---make control visible on/off 
                    For j = j To clsStandardGraph.MAXREPEAT '+ clsStandardGraph.MAXREPEAT
                        Call objRepeatResultsControl.FindNSetControlVisible(j, False)
                    Next
                    '---make second control for conc. visible on/off 
                    For j = 1 To clsStandardGraph.MAXREPEAT '+ clsStandardGraph.MAXREPEAT
                        Call objRepeatResultsControl.FindNSet2ndControlVisible(j, False)
                    Next
                    '---display statistics
                    objRepeatResultsControl.ShowStatistic(curstd.AbsRepeat.BasicStat, True, False)

                    objRepeatResultsControl.StandardAnalysisParameter = curstd  '22.07.07
                    objRepeatResultsControl.Width = RepeatResultsViewer.Width - 20
                    mobjRepeatResultsControlArray(i) = objRepeatResultsControl
                    RepeatResultsViewer.GetControls(mobjRepeatResultsControlArray)
                    i += 1
                End If
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

    Private Sub DisplayRepeatInfoSamp(ByVal cursamp As Method.clsAnalysisSampleParameters, ByRef i As Integer)
        '=====================================================================
        ' Procedure Name        : DisplayRepeatInfoSamp
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : Initialize control for each repeat and add it 
        '                         to controls collection
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 10-Mar-2007 05:55 pm
        ' Revisions             : 1
        '=====================================================================

        
        'void	DisplayRepeatInfoSamp(HWND hwnd, SAMPDATA *cursamp, int i)
        '{
        '	int	j=0, k;
        '	char	str[40]="";
        '	ABSREPEATDATA	*rpt=NULL;
        '	j=0;
        '   If (cursamp) Then
        '	{
        '		sprintf(str,"%-2d",cursamp->Data.SampNo);
        '		ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), TRUE);
        '		SetWindowText(GetDlgItem(hwnd, IDC_SAMPNAME+i*NOOFITEMS+j), str);
        '		j++;
        '		ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), TRUE);
        '		SetWindowText(GetDlgItem(hwnd, IDC_SAMPNAME+i*NOOFITEMS+j), cursamp->Data.Samp_Name);
        '		j++;
        '		ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), TRUE);
        '		j++;
        '       #If STD_ADDN Then
        '			if(Method->QuantData->Param.Std_Addn)
        '			{
        '				k=j;
        '				ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), TRUE);
        '				SetDlgItemText(hwnd, IDC_SAMPNAME+i*NOOFITEMS+j, "");
        '				j++;
        '				for(; j<k+15; j++)
        '					ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), FALSE);
        '				ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), TRUE);
        '				j++;
        '				k=j;
        '				StoreResultAccurate(Get_percent(Method->QuantData->SampTopData->Data.Conc,
        '												  Method->QuantData->SampTopData->Data.Weight,
        '												  Method->QuantData->SampTopData->Data.Volume,
        '												  Method->QuantData->SampTopData->Data.Dil_Fact,
        '												  Method->QuantData->Param.Unit,
        '												  Method->QuantData->Param.No_Decimals),str,
        '												  Method->QuantData->Param.No_Decimals);
        '				ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), TRUE);
        '				SetDlgItemText(hwnd, IDC_SAMPNAME+i*NOOFITEMS+j, str);
        '				j++;
        '				for(; j<k+17; j++)
        '					ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), FALSE);
        '			}
        '       #Else
        '           Else
        '			{
        '       #End If
        '		    if (cursamp->Data.AbsRepeat)
        '		    {
        '				rpt = cursamp->Data.AbsRepeat->RptDataTop;
        '				k=j;
        '               While (rpt)
        '				{
        '					if (Method->Mode==MODE_EMISSION)
        '						sprintf(str,"%-4.1f",rpt->Abs);
        '                    Else
        '					{
        '						StoreAbsAccurate(rpt->Abs,str);
        '						//sprintf(str,"%-4.3f",rpt->Abs);
        '					}
        '					ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), TRUE);
        '					SetDlgItemText(hwnd, IDC_SAMPNAME+i*NOOFITEMS+j, str); j++;
        '					rpt=rpt->next;
        '				}
        '				for(; j<k+15; j++)
        '					ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), FALSE);
        '				ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), TRUE);
        '				j++;
        '				k=j;
        '				rpt = cursamp->Data.AbsRepeat->RptDataTop;
        '               While (rpt)
        '				{
        '					StoreResultAccurate(rpt->Conc, str,
        '					Method->QuantData->Param.No_Decimals);
        '					ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), TRUE);
        '					SetDlgItemText(hwnd, IDC_SAMPNAME+i*NOOFITEMS+j, str);
        '					j++;
        '					rpt=rpt->next;
        '				}
        '				for(; j<k+15; j++)
        '					ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), FALSE);
        '				ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), TRUE);
        '				j+=2;
        '				ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), TRUE);
        '				ShowStatistic(hwnd, &(cursamp->Data.AbsRepeat->Data), i, TRUE);
        '				ShowStatistic(hwnd, &(cursamp->Data.AbsRepeat->Data), i, FALSE);
        '			}
        '       #If STD_ADDN Then
        '		    }
        '       #End If
        '}

        Dim j, k As Integer
        Dim str As String
        Dim rpt As Method.clsAbsRepeatDataCollection
        Dim intCounter As Integer

        Try

            j = 0
            If Not IsNothing(cursamp) Then
                '---intialize control for new sample repeat
                Dim objRepeatResultsControl As New RepeatResultsControl
                'Dim objRepeatResultsControl As New GridLayoutPanel.RepeatResultsControl
                objRepeatResultsControl.StandardNumber = cursamp.SampNumber
                objRepeatResultsControl.StandardName = cursamp.SampleName
                objRepeatResultsControl.lstConcStats.Visible = True
                objRepeatResultsControl.lblConc.Visible = True
                objRepeatResultsControl.lblConcStats.Visible = True
                objRepeatResultsControl.IsStandard = False

                '---02.12.07
                'objRepeatResultsControl.AutoScroll = True
                'objRepeatResultsControl.Dock = DockStyle.Fill

                '---add handler for control click
                AddHandler objRepeatResultsControl.RepeatItemClick, AddressOf SubRepeatResultsControl_RepeatResultClick
                If (mobjclsMethod.OperationMode = EnumOperationMode.MODE_EMMISSION) Then
                    objRepeatResultsControl.lblAbs.Text = "Emission"
                    '---added by deepak on 22.07.07
                    objRepeatResultsControl.lblAbsStats.Text = "Statistics on Emission"
                Else
                    objRepeatResultsControl.lblAbs.Text = "Abs"
                    '---added by deepak on 22.07.07
                    objRepeatResultsControl.lblAbsStats.Text = "Statistics on Abs"
                End If
                If mobjclsMethod.StandardAddition Then
                    k = j
                    'ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), TRUE);
                    'SetDlgItemText(hwnd, IDC_SAMPNAME+i*NOOFITEMS+j, "");
                    'j+=1
                    'for(; j<k+15; j++)
                    '   ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), FALSE);
                    'ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), TRUE);
                    'j+=1
                    'k=j
                    'StoreResultAccurate(Get_percent(Method->QuantData->SampTopData->Data.Conc,
                    '                                Method->QuantData->SampTopData->Data.Weight,
                    '								 Method->QuantData->SampTopData->Data.Volume,
                    '								 Method->QuantData->SampTopData->Data.Dil_Fact,
                    '								 Method->QuantData->Param.Unit,
                    '								 Method->QuantData->Param.No_Decimals),str,
                    '								 Method->QuantData->Param.No_Decimals);
                    'ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), TRUE);
                    'SetDlgItemText(hwnd, IDC_SAMPNAME+i*NOOFITEMS+j, str);
                    'j+=1
                    'for(; j<k+17; j++)
                    '   ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), FALSE);

                Else
                    ''If Not IsNothing(cursamp.AbsRepeat) Then
                    ''    rpt = cursamp.AbsRepeat.AbsRepeatData
                    ''    j = 1
                    ''    For intCounter = 0 To rpt.Count - 1
                    ''        If (mobjclsMethod.OperationMode = EnumOperationMode.MODE_EMMISSION) Then
                    ''            str = FormatNumber(rpt.item(intCounter).Abs, 2)
                    ''        Else
                    ''            str = FormatNumber(rpt.item(intCounter).Abs, 4)
                    ''        End If
                    ''        Call objRepeatResultsControl.FindNSetValueInControl(str, j)
                    ''        j += 1
                    ''    Next
                    ''    For j = j To clsStandardGraph.MAXREPEAT + clsStandardGraph.MAXREPEAT
                    ''        Call objRepeatResultsControl.FindNSetControlVisible(j, False)
                    ''    Next
                    ''    objRepeatResultsControl.ShowStatistic(cursamp.AbsRepeat.BasicStat, i, True)
                    ''    objRepeatResultsControl.Dock = DockStyle.Bottom
                    ''    RepeatResultsViewer.Controls.Add(objRepeatResultsControl)
                    ''End If

                    If Not IsNothing(cursamp.AbsRepeat) Then
                        rpt = cursamp.AbsRepeat.AbsRepeatData
                        j = 1
                        k = j

                        '---format abs values according to the type of mode
                        For intCounter = 0 To rpt.Count - 1
                            If rpt.item(intCounter).Used = True Then
                                If (mobjclsMethod.OperationMode = EnumOperationMode.MODE_EMMISSION) Then
                                    str = FormatNumber(rpt.item(intCounter).Abs, 1)
                                Else
                                    str = FormatNumber(rpt.item(intCounter).Abs, 3)
                                End If

                                '---set abs value in control
                                Call objRepeatResultsControl.FindNSetValueInControl(str, j)
                                'Call objRepeatResultsControl.FindNSet2ndValueInControl(str, j)
                                j += 1
                            End If
                        Next

                        'For j = j To clsStandardGraph.MAXREPEAT '+ clsStandardGraph.MAXREPEAT
                        '    Call objRepeatResultsControl.FindNSetControlVisible(j, False)
                        '    ' Call objRepeatResultsControl.FindNSet2ndControlVisible(j, False)
                        'Next
                        j = 1
                        '---set value of concentration in second control
                        For intCounter = 0 To rpt.Count - 1
                            If rpt.item(intCounter).Used = True Then
                                'str = FormatNumber(rpt.item(intCounter).Concentration, 2) ' code commented by : dinesh wagh on 8.3.2009
                                str = rpt.item(intCounter).Concentration ' code added by : dinesh wagh on 8.3.2009

                                Call objRepeatResultsControl.FindNSet2ndValueInControl(str, j, mobjclsMethod.AnalysisParameters.NumOfDecimalPlaces) '---08.03.09

                                ' Call objRepeatResultsControl.FindNSet2ndValueInControl(str, j)
                                j += 1
                            End If
                        Next

                        '---make visible on/off both controls(abs and conc)
                        For j = j To clsStandardGraph.MAXREPEAT '+ clsStandardGraph.MAXREPEAT
                            Call objRepeatResultsControl.FindNSetControlVisible(j, False)
                            Call objRepeatResultsControl.FindNSet2ndControlVisible(j, False)
                            Application.DoEvents()
                        Next

                        '---display statistics
                        Call objRepeatResultsControl.ShowStatistic(cursamp.AbsRepeat.BasicStat, False, False)
                        Call objRepeatResultsControl.ShowStatistic(cursamp.AbsRepeat.BasicStat, False, True)

                        objRepeatResultsControl.Width = RepeatResultsViewer.Width - 20
                        objRepeatResultsControl.AnalysisParameter = cursamp
                        mobjRepeatResultsControlArray(i) = objRepeatResultsControl
                        mIntSelectedStdOrSplNo = objRepeatResultsControl.AnalysisParameter.SampNumber
                        'mobjRepeatResultsControl = objRepeatResultsControl
                        RepeatResultsViewer.GetControls(mobjRepeatResultsControlArray)
                        i += 1
                    End If
                End If
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

    Private Sub SubRepeatResultsControl_RepeatResultClick(ByVal StandardOrSampleNumber As Integer, ByVal RepeatNumber As Integer, ByVal IsStandard As Boolean, ByRef ctrls As Control.ControlCollection)
        '=====================================================================
        ' Procedure Name        : objRepeatResultsControl_RepeatResultClick
        ' Parameters Passed     : StandardNumber,RepeatNumber,IsStandard,ctrls
        ' Returns               : None
        ' Purpose               : 
        ' Description           : Alter tags of all repeat controls
        '                         after deletion according to current array
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 26.07.07
        ' Revisions             : 1
        '=====================================================================
        Dim cntrl As Control
        Dim intTextBoxIndex As Integer = 1
        Dim intTextBoxConcIndex As Integer = 1
        Dim intCount As Integer
        Dim intUsedCount As Integer

        Try
            '---get standard or sample count
            If IsStandard = True Then
                For intCount = 0 To mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(StandardOrSampleNumber - 1).AbsRepeat.AbsRepeatData.Count - 1
                    If mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(StandardOrSampleNumber - 1).AbsRepeat.AbsRepeatData.item(intCount).Used = True Then
                        intUsedCount = intUsedCount + 1
                    End If
                Next
            Else
                For intCount = 0 To mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(StandardOrSampleNumber - 1).AbsRepeat.AbsRepeatData.Count - 1
                    If mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(StandardOrSampleNumber - 1).AbsRepeat.AbsRepeatData.item(intCount).Used = True Then
                        intUsedCount = intUsedCount + 1
                    End If
                Next
            End If

            '---arrange array of tags according to stadard/sample deletion
            If IsStandard = True Then
                marrControls.Clear()
                For intCount = 0 To mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(StandardOrSampleNumber - 1).AbsRepeat.AbsRepeatData.Count - 1
                    If mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(StandardOrSampleNumber - 1).AbsRepeat.AbsRepeatData.item(intCount).Used = True Then
                        marrControls.Add(intCount + 1)
                    End If
                Next
            Else
                marrControls.Clear()
                For intCount = 0 To mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(StandardOrSampleNumber - 1).AbsRepeat.AbsRepeatData.Count - 1
                    If mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(StandardOrSampleNumber - 1).AbsRepeat.AbsRepeatData.item(intCount).Used = True Then
                        marrControls.Add(intCount + 1)
                    End If
                Next
            End If

            '---assign new tags to stadard/sample repeat controls
            If IsStandard = True Then
                For intCount = 0 To intUsedCount - 1
                    For Each cntrl In ctrls
                        If TypeOf cntrl Is TextBox Then
                            If cntrl.Name = "TextBox" & intTextBoxIndex Then
                                cntrl.Tag = marrControls(intTextBoxIndex - 1)
                                intTextBoxIndex = intTextBoxIndex + 1
                                Exit For
                            End If
                        End If
                    Next
                Next
            Else
                For intCount = 0 To intUsedCount - 1
                    For Each cntrl In ctrls
                        If TypeOf cntrl Is TextBox Then
                            If cntrl.Name = "TextBox" & intTextBoxIndex Then
                                cntrl.Tag = marrControls(intTextBoxIndex - 1)
                                intTextBoxIndex = intTextBoxIndex + 1
                                Exit For
                            End If
                        End If
                    Next
                Next
                '---assign new tags to sample conc. repeat controls
                For intCount = 0 To intUsedCount - 1
                    For Each cntrl In ctrls
                        If TypeOf cntrl Is TextBox Then
                            If cntrl.Name = "TextBoxConc" & intTextBoxConcIndex Then
                                cntrl.Tag = marrControls(intTextBoxConcIndex - 1)
                                intTextBoxConcIndex = intTextBoxConcIndex + 1
                                Exit For
                            End If
                        End If
                    Next
                Next
            End If

            mIntSelectedStdOrSplNo = StandardOrSampleNumber
            mIntSelectedRepeatNo = RepeatNumber
            mBlnIsStandard = IsStandard
            'MessageBox.Show(mIntSelectedRepeatNo)
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

    Private Function funcRefreshControls_Sample(ByVal sample As clsAnalysisSampleParameters) As Boolean
        '=====================================================================
        ' Procedure Name        : funcRefreshControls_Sample
        ' Parameters Passed     : sample
        ' Returns               : None
        ' Purpose               : 
        ' Description           : To refresh array of tags for sample repeat controls
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 26.07.07
        ' Revisions             : 1
        '=====================================================================
        Dim intCount As Integer
        Dim intTextBoxIndex As Integer = 1

        Try
            marrControls.Clear()
            For intCount = 0 To sample.AbsRepeat.AbsRepeatData.Count - 1
                If sample.AbsRepeat.AbsRepeatData.item(intCount).Used = True Then
                    marrControls.Add(intCount + 1)
                End If
            Next
            Return False
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

    Private Function funcRefreshControls_Std(ByVal std As clsAnalysisStdParameters) As Boolean
        '=====================================================================
        ' Procedure Name        : funcRefreshControls_Std
        ' Parameters Passed     : std
        ' Returns               : None
        ' Purpose               : 
        ' Description           : To refresh array of tags for std repeat controls
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 26.07.07
        ' Revisions             : 1
        '=====================================================================
        Dim intCount As Integer
        Dim intTextBoxIndex As Integer = 1

        Try
            marrControls.Clear()
            For intCount = 0 To std.AbsRepeat.AbsRepeatData.Count - 1
                If std.AbsRepeat.AbsRepeatData.item(intCount).Used = True Then
                    marrControls.Add(intCount + 1)
                End If
            Next
            Return False
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


#End Region

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        '=====================================================================
        ' Procedure Name        : btnPrint_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : To print repeat results
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 04-Aug-2007
        ' Revisions             : 1
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim objclsDataFileReport As clsDataFileReport
        'update data structure
        Try

            'code added by ; dinesh wagh on 24.6.2010
            'Print function will work for any condition.For 21CFR it will authenticate the user first.
            '-------------------------------------------------------
            If (gstructSettings.Enable21CFR = True) Then
                If Not funcCheckActivityAuthentication(enumActivityAuthentication.Print, gstructUserDetails.Access) Then
                    Exit Sub
                End If
            End If

            objclsDataFileReport = New clsDataFileReport
            objclsDataFileReport.MethodID = mobjclsMethod.MethodID
            objclsDataFileReport.RunNumber = mobjclsMethod.QuantitativeDataCollection(mintSelectedRunNumberIndex).RunNumber
            objclsDataFileReport.DefaultFont = Me.DefaultFont
            objclsDataFileReport.funcEditDataRepeatResult(mobjclsMethod)
            '-------------------------------------------


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
            objclsDataFileReport = Nothing
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
        End Try
    End Sub

End Class
