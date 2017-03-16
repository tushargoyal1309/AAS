Imports AAS203.Common
Imports AAS203Library.Method

Public Class frmViewResults
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mblnIsAnalysisMode = True
        mintSelectedRunNumber = 0

    End Sub

    Public Sub New(ByVal blnIsAnalysisMode As Boolean, ByVal intSelectedMethodID As Integer, ByVal intSelectedRunNumber As Integer, ByVal objClsMethod As clsMethod)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mblnIsAnalysisMode = blnIsAnalysisMode
        mintSelectedRunNumber = intSelectedRunNumber
        mintSelectedMethodID = intSelectedMethodID
        mobjClsMethod = objClsMethod.Clone

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
    Friend WithEvents CustomPanel1 As GradientPanel.CustomPanel
    Friend WithEvents dgViewResults As System.Windows.Forms.DataGrid
    Friend WithEvents btnOk As NETXP.Controls.XPButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmViewResults))
        Me.Office2003Header1 = New CodeIntellects.Office2003Controls.Office2003Header
        Me.CustomPanel1 = New GradientPanel.CustomPanel
        Me.btnOk = New NETXP.Controls.XPButton
        Me.dgViewResults = New System.Windows.Forms.DataGrid
        Me.CustomPanel1.SuspendLayout()
        CType(Me.dgViewResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Office2003Header1
        '
        Me.Office2003Header1.BackColor = System.Drawing.SystemColors.Control
        Me.Office2003Header1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Office2003Header1.Location = New System.Drawing.Point(0, 0)
        Me.Office2003Header1.Name = "Office2003Header1"
        Me.Office2003Header1.Size = New System.Drawing.Size(722, 20)
        Me.Office2003Header1.TabIndex = 0
        Me.Office2003Header1.TitleFont = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Office2003Header1.TitleText = "Standard/Sample Absorbance and Concentration"
        '
        'CustomPanel1
        '
        Me.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanel1.Controls.Add(Me.btnOk)
        Me.CustomPanel1.Controls.Add(Me.dgViewResults)
        Me.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanel1.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanel1.Name = "CustomPanel1"
        Me.CustomPanel1.Size = New System.Drawing.Size(722, 303)
        Me.CustomPanel1.TabIndex = 1
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Image = CType(resources.GetObject("btnOk.Image"), System.Drawing.Image)
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(301, 260)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(100, 36)
        Me.btnOk.TabIndex = 2
        Me.btnOk.Text = "OK"
        '
        'dgViewResults
        '
        Me.dgViewResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgViewResults.CaptionVisible = False
        Me.dgViewResults.DataMember = ""
        Me.dgViewResults.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgViewResults.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgViewResults.Location = New System.Drawing.Point(4, 24)
        Me.dgViewResults.Name = "dgViewResults"
        Me.dgViewResults.Size = New System.Drawing.Size(714, 229)
        Me.dgViewResults.TabIndex = 0
        '
        'frmViewResults
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(722, 303)
        Me.Controls.Add(Me.Office2003Header1)
        Me.Controls.Add(Me.CustomPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmViewResults"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Results"
        Me.CustomPanel1.ResumeLayout(False)
        CType(Me.dgViewResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Private Class Member Variables "

    Private mobjDtSample As DataTable
    Private mobjDtSampleDataGridclass As DataGridClass
    Private mblnIsAnalysisMode As Boolean
    Private mintRunNumberIndex As Integer
    Private mintSelectedRunNumber As Integer
    Private mintSelectedMethodID As Integer
    Private mobjClsMethod As New clsMethod

#End Region

#Region " Private Constants "

    Private Const ConstFormLoadDataFiles = "-DataFiles-ViewResults"
    Private Const ConstFormLoadAnalysis = "-Analysis-ViewResults"
    Private Const ConstParentFormLoadDataFiles = "-DataFiles"
    Private Const ConstParentFormLoadAnalysis = "-Analysis"

    '---Column Names Constants
    Private Const ConstColumnSrNo = "SrNo"
    Private Const ConstColumnSampleName = "SampleName"
    Private Const ConstColumnWeight = "Weight"
    Private Const ConstColumnVolume = "Volume"
    Private Const ConstColumnDilutionFactor = "DilutionFactor"
    Private Const ConstColumnAbs = "Abs"
    Private Const ConstColumnEnergy = "% Emission"
    Private Const ConstColumnConcInPPM = "ConcInPPM"
    'Private Const ConstColumnConcInPercentage = "ConcInPer"
    Private Const ConstColumnTotalConc = "TotalConc"

    '---Column Captions Constants
    Private Const ConstTitleSrNo = "Sr.No."
    Private Const ConstTitleSampleName = "Sample Name "
    Private Const ConstTitleWeight = "Weight (gms)"
    Private Const ConstTitleVolume = "Volume (ml)"
    Private Const ConstTitleDilutionFactor = "Dilution Factor"
    Private Const ConstTitleAbs = "Abs"
    Private Const ConstTitleEnergy = "% Emission"
    Private Const ConstTitleConcInPPM = "Conc. (ppm)"
    Private Const ConstTitleConcInPPB = "Conc. (ppb)"

    'Private Const ConstTitleConcInPercentage = "Conc. (%)"

    '---4.85  14.04.09
    'Private Const ConstTitleTotalConcInPPM = "Total Conc. (PPM)"
    'Private Const ConstTitleTotalConcInPercent = "Total Conc. (%)"
    'Private Const ConstTitleTotalConcInPPB = "Total Conc. (PPB)"
    '---4.85  14.04.09

    '---4.85  14.04.09
    Private Const ConstTitleTotalConcInPPM = "Conc. in Sample (ppm)"
    Private Const ConstTitleTotalConcInPercent = "Conc. in Sample (%)"
    Private Const ConstTitleTotalConcInPPB = "Conc. in Sample (ppb)"
    '---4.85  14.04.09

    '---Column Default Values Constants
    Private Const ConstDefaultValue = "1.0000"
    Private Const ConstDefaultSampleName = "Sample "

    '---Column Width Constants
    Private Const ConstWidthSrNo = 50
    Private Const ConstWidthSampleName = 95
    Private Const ConstWidthWeight = 90 '95
    Private Const ConstWidthVolume = 90 '95
    Private Const ConstWidthDilutionFactor = 95
    Private Const ConstWidthAbs = 50
    Private Const ConstWidthEnergy = 80

    Private Const ConstWidthConcInPercentage = 90
    Private Const ConstWidthConcInPPM = 90
    Private Const ConstWidthConcInPPB = 90

    Private Const ConstWidthTotalConcInPercentage = 150 '110
    Private Const ConstWidthTotalConcInPPM = 150 '110
    Private Const ConstWidthTotalConcInPPB = 150 '110

#End Region

#Region " Form Load Events "

    Private Sub frmViewResults_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmViewResults_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To initialize and load the form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : 
        ' Created               : 
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim intCounter As Integer
        Dim objRow As DataRow

        'case	WM_INITDIALOG :
        'hbr  = CreateSolidBrush(RGB(0, 255,255));
        'hfont = CreateFont(-11, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "Arial");
        'SendDlgItemMessage(hwnd, IDOK, WM_SETFONT,(WPARAM) hfont, 0L);
        'SendDlgItemMessage(hwnd, IDC_RESULT, WM_SETFONT,(WPARAM) hfont, 0L);
        'SendDlgItemMessage(hwnd, IDC_RESULT, LB_SETTABSTOPS,(WPARAM) 7,(LPARAM) tabs);
        'SetAbsEmnWindow(hwnd);
        'InitShowResults(hwnd);
        'return TRUE;

        Try
            If mblnIsAnalysisMode Then
                gobjMain.ShowProgressBar(gstrTitleInstrumentType & ConstFormLoadAnalysis)
            Else
                gobjMain.ShowProgressBar(gstrTitleInstrumentType & ConstFormLoadDataFiles)
            End If

            'Saurabh 01.08.07
            If Not IsNothing(mobjClsMethod) Then
                If mobjClsMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
                    Office2003Header1.TitleText = "Standard/Sample Emission and Concentration"
                Else
                    Office2003Header1.TitleText = "Standard/Sample Absorbance and Concentration"
                End If
            End If
            'Saurabh 01.08.07
            'update data grid
            mobjDtSampleDataGridclass = New DataGridClass(ConstDataGridPropertiesFileName)
            mobjDtSampleDataGridclass.AllowNew = False
            mobjDtSampleDataGridclass.AdjustColumnWidthToGrid = False

            mobjDtSample = New DataTable
            mobjDtSample.Columns.Add(ConstColumnSrNo)
            mobjDtSample.Columns.Add(ConstColumnSampleName)
            mobjDtSample.Columns.Add(ConstColumnWeight)
            mobjDtSample.Columns.Add(ConstColumnVolume)
            mobjDtSample.Columns.Add(ConstColumnDilutionFactor)
            If mobjClsMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
                mobjDtSample.Columns.Add(ConstColumnEnergy)
            Else
                mobjDtSample.Columns.Add(ConstColumnAbs)
            End If
            mobjDtSample.Columns.Add(ConstColumnConcInPPM)
            mobjDtSample.Columns.Add(ConstColumnTotalConc)

            If mblnIsAnalysisMode Then
                mobjClsMethod = gobjNewMethod.Clone
            End If

            If mblnIsAnalysisMode Then
                '---For Analysis Mode
                If mobjClsMethod.QuantitativeDataCollection.Count > 0 Then
                    mintRunNumberIndex = mobjClsMethod.QuantitativeDataCollection.Count - 1
                Else
                    mintRunNumberIndex = 0
                End If
            Else
                '---For Data Files Mode
                mintRunNumberIndex = gfuncGetSelectedMethodRunNumberIndex(mintSelectedMethodID, mintSelectedRunNumber)
            End If
            'Call InitShowResults()
            'Added by pankaj bamb on 21 Feb 08
            If mblnIsAnalysisMode = True Then
                Call InitShowResults()
            Else
                Call InitShowResultsForMethod()
            End If
            '-------------------


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
            gobjMain.HideProgressBar()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub frmViewResults_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        '=====================================================================
        ' Procedure Name        : frmViewResults_Closing
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 01-Feb-2007 08:25 pm
        ' Revisions             : 1
        '=====================================================================
        If mblnIsAnalysisMode Then
            gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType & ConstParentFormLoadAnalysis)
        Else
            gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType & ConstParentFormLoadDataFiles)
        End If
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        '=====================================================================
        ' Procedure Name        : btnOk_Click
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 01-Feb-2007 08:25 pm
        ' Revisions             : 1
        '=====================================================================
        Try
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
        End Try
    End Sub

#End Region

#Region " Private functions "

    Private Sub InitShowResults()
        '=====================================================================
        ' Procedure Name        : InitShowResults
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 01-Feb-2007 08:35 pm
        ' Revisions             : 1
        '=====================================================================

        
        'void InitShowResults(HWND hwnd)
        '{
        '	SAMPDATA		*samp=NULL;
        '	STDDATA		    *std=NULL;
        '	BOOL			unit=FALSE;
        '	char			str[256]="";
        '	char			str1[80]="";
        '	int	i;
        '	HDC		hdc;

        '	unit=Method->QuantData->Param.Unit;
        '	
        '   If (unit) Then
        '	{
        '		
        '		SetWindowText(GetDlgItem(hwnd, IDC_TCONC1), (LPCSTR) "Total Conc in ppm");
        '		SetWindowText(GetDlgItem(hwnd, IDC_TCONC), (LPCSTR) "Conc in ppm");
        '	}
        '   Else
        '	{
        '		SetWindowText(GetDlgItem(hwnd, IDC_TCONC1), (LPCSTR) "Total Conc in %");
        '		SetWindowText(GetDlgItem(hwnd, IDC_TCONC), (LPCSTR) "Conc in ppm");
        '	}
        '	SendMessage(GetDlgItem(hwnd,IDC_RESULT), LB_RESETCONTENT, 0, 0L);
        '	std=Method->QuantData->StdTopData;
        '	i=1;
        '	hdc = GetDC(hwnd);

        '   While (std! = NULL)
        '	{
        '		if (std->Data.Abs>-0.2 && std->Data.Used)
        '		{
        '			strcpy(str1,""); strcpy(str,"");
        '			sprintf(str,"%-2d\t", i);
        '			sprintf(str1,"%s\t", std->Data.Std_Name);
        '			strcat(str, str1);
        '			sprintf(str1,"   -\t" );
        '			strcat(str, str1);
        '			sprintf(str1,"   -\t" );
        '			strcat(str, str1);
        '			sprintf(str1,"   -\t" );
        '			strcat(str, str1);
        '			if (Method->Mode==MODE_EMISSION)
        '				sprintf(str1,"%-4.1f %%\t", std->Data.Abs);
        '           Else
        '			{
        '				StoreAbsAccurate(std->Data.Abs,str1);  
        '				strcat(str1,"\t");
        '				//sprintf(str1,"%-4.3f\t",std->Data.Abs);
        '			}
        '			strcat(str, str1);
        '			StoreResultAccurate(std->Data.Conc, str1, Method->QuantData->Param.No_Decimals);
        '			strcat(str, str1); strcat(str,"\t");
        '			SendMessage(GetDlgItem(hwnd,IDC_RESULT), LB_ADDSTRING, 0, (DWORD) (LPSTR) str);
        '			i++;
        '		}
        '		std=std->next;
        '	}

        '	samp=Method->QuantData->SampTopData;

        '   While (samp! = NULL)
        '	{
        '		if (samp->Data.Abs>-0.2 && samp->Data.Used)
        '		{
        '			strcpy(str1,""); strcpy(str,"");
        '			sprintf(str,"%-2d\t",  samp->Data.SampNo);
        '			sprintf(str1,"%-s\t", samp->Data.Samp_Name);
        '			strcat(str, str1);
        '			sprintf(str1,"%-7.4f\t",samp->Data.Weight );
        '			strcat(str, str1);
        '			sprintf(str1,"%-7.4f\t",samp->Data.Volume);
        '			strcat(str, str1);
        '			sprintf(str1,"%-7.4f\t",samp->Data.Dil_Fact);
        '			strcat(str, str1);
        '#If STD_ADDN Then
        '				if(Method->QuantData->Param.Std_Addn)
        '					sprintf(str1,"-\t", samp->Data.Abs);
        '				else
        '				{
        '					if (Method->Mode==MODE_EMISSION)
        '						sprintf(str1,"%-4.1f %%\t", samp->Data.Abs);
        '					else
        '					{
        '						StoreAbsAccurate(samp->Data.Abs,str1);
        '						strcat(str1,"\t");
        '						
        '					}
        '				}
        '#Else
        '				if (Method->Mode==MODE_EMISSION)
        '					sprintf(str1,"%-4.1f %%\t", samp->Data.Abs);
        '                                Else
        '					sprintf(str1,"%-4.3f\t",samp->Data.Abs );
        '#End If

        '			strcat(str, str1);

        '#If STD_ADDN Then
        '			if(Method->QuantData->Param.Std_Addn)
        '				sprintf(str1,"-\t", samp->Data.Abs);
        '			else
        '				StoreResultAccurate(samp->Data.Conc, str1, Method->QuantData->Param.No_Decimals);
        '#Else
        '				StoreResultAccurate(samp->Data.Conc, str1, Method->QuantData->Param.No_Decimals);
        '#End If
        '			strcat(str, str1); strcat(str,"\t");
        '			StoreResultAccurate(Get_percent(samp->Data.Conc, samp->Data.Weight,
        '								samp->Data.Volume,samp->Data.Dil_Fact,
        '								Method->QuantData->Param.Unit,
        '								Method->QuantData->Param.No_Decimals
        '								),
        '			str1, Method->QuantData->Param.No_Decimals);

        '			strcat(str, str1);
        '			SendMessage(GetDlgItem(hwnd,IDC_RESULT), LB_ADDSTRING, 0, (DWORD) (LPSTR) str);
        '			i++;
        '		}
        '		samp=samp->next;
        '	}
        '	ReleaseDC(hwnd, hdc); 
        '}

        Dim objWaitCursor As New Common.CWaitCursor

        Dim std As AAS203Library.Method.clsAnalysisStdParameters
        Dim samp As AAS203Library.Method.clsAnalysisSampleParameters
        Dim sampParant As AAS203Library.Method.clsAnalysisSampleParameters
        Dim i, minCnt As Integer
        Dim unit As Integer = 0
        Dim str, str1 As String
        Dim objDrNewRow As DataRow
        Dim dblConc As Double
        Dim intNoOfDecimalPlaces As Integer
        Try
            If IsNothing(mobjClsMethod.QuantitativeDataCollection) Then
                Exit Sub
            End If

            If mobjClsMethod.QuantitativeDataCollection.Count = 0 Then
                Exit Sub
            End If

            unit = mobjClsMethod.AnalysisParameters.Unit
            '1 = PPM  And 2 = %
            intNoOfDecimalPlaces = CInt(mobjClsMethod.AnalysisParameters.NumOfDecimalPlaces)


            mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnSrNo, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleSrNo, ConstWidthSrNo, True)
            mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnSampleName, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Left, ConstTitleSampleName, ConstWidthSampleName, True)
            mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnWeight, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleWeight, ConstWidthWeight, True)
            mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnVolume, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleVolume, ConstWidthVolume, True)
            mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnDilutionFactor, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleDilutionFactor, ConstWidthDilutionFactor, True)
            If mobjClsMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
                mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnEnergy, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleEnergy, ConstWidthEnergy, True)
            Else
                mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnAbs, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleAbs, ConstWidthAbs, True)
            End If

            '---commented on 27.03.09
            ''mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnConcInPPM, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleConcInPPM, ConstWidthConcInPPM, True)
            '-------------

            '---written on 27.03.09
            If unit = enumUnit.PPB Then
                mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnConcInPPM, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleConcInPPB, ConstWidthConcInPPB, True)
            Else
                mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnConcInPPM, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleConcInPPM, ConstWidthConcInPPM, True)
            End If
            '----------------

            'commented on 27.03.09
            '---Unit is PPM
            ''If unit = 1 Then
            ''    mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnTotalConc, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleTotalConcInPPM, ConstWidthTotalConcInPPM, True)
            ''Else
            ''    '---Unit is %
            ''    mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnTotalConc, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleTotalConcInPercent, ConstWidthTotalConcInPercentage, True)
            ''End If

            'written on 27.03.09
            If unit = enumUnit.PPM Then
                mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnTotalConc, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleTotalConcInPPM, ConstWidthTotalConcInPPM, True)
            ElseIf unit = enumUnit.Percent Then
                mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnTotalConc, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleTotalConcInPercent, ConstWidthTotalConcInPercentage, True)
            ElseIf unit = enumUnit.PPB Then
                mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnTotalConc, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleTotalConcInPPB, ConstWidthTotalConcInPPB, True)
            End If
            '-----------

            i = 0
            ' add Standard collection data into data table to print object
            For i = 0 To mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count - 1
                std = mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(i)

                If (std.Abs > -0.2 And std.Used) Then
                    objDrNewRow = mobjDtSample.NewRow

                    If Not std.StdName = "" Then
                        objDrNewRow.Item(ConstColumnSampleName) = std.StdName
                    Else
                        objDrNewRow.Item(ConstColumnSampleName) = ConstDefaultSampleName
                    End If

                    objDrNewRow.Item(ConstColumnSrNo) = i + 1
                    objDrNewRow.Item(ConstColumnSampleName) = std.StdName
                    objDrNewRow.Item(ConstColumnWeight) = ""
                    objDrNewRow.Item(ConstColumnVolume) = ""
                    objDrNewRow.Item(ConstColumnDilutionFactor) = ""
                    objDrNewRow.Item(ConstColumnConcInPPM) = FormatNumber(std.Concentration, intNoOfDecimalPlaces)
                    objDrNewRow.Item(ConstColumnTotalConc) = ""

                    If (mobjClsMethod.OperationMode = EnumOperationMode.MODE_EMMISSION) Then
                        'sprintf(str1,"%-4.1f %%\t", std->Data.Abs);
                        ' Set the format of decimal point to the data for emission
                        objDrNewRow.Item(ConstColumnEnergy) = FormatNumber(std.Abs, CONST_Format_Value_Emission)
                    Else
                        ' Set the format of decimal point to the data 
                        'StoreAbsAccurate(std->Data.Abs,str1);  
                        'strcat(str1,"\t");
                        objDrNewRow.Item(ConstColumnAbs) = FormatNumber(std.Abs, CONST_Format_Value_Absorbance)
                    End If
                    'StoreResultAccurate(std->Data.Conc, str1, Method->QuantData->Param.No_Decimals);

                    mobjDtSample.Rows.Add(objDrNewRow)
                End If

            Next i

            i = 0
            ' add Sasmple collection data into data table to print object
            '//----- Modified by Sachin Dokhale
            'For i = 0 To mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count - 1
            If mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count < mobjClsMethod.SampleDataCollection.Count Then
                minCnt = mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count
            Else
                minCnt = mobjClsMethod.SampleDataCollection.Count
            End If
            'For i = 0 To mobjClsMethod.SampleDataCollection.Count - 1'comment by pankaj on 23 Mar 08
            For i = 0 To mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count - 1  ' by pankaj on 23 Mar08 to handle index exception

                samp = mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(i)
                'sampParant = mobjClsMethod.SampleDataCollection.item(i)'comment by pankaj on 23 Mar 08
                If (samp.Abs > -0.2 And samp.Used) Then
                    If i < mobjClsMethod.SampleDataCollection.Count Then
                        sampParant = mobjClsMethod.SampleDataCollection.item(i) 'added by pankaj on 23 Mar 08
                    End If
                    objDrNewRow = mobjDtSample.NewRow

                    str1 = ""
                    str = ""
                    objDrNewRow.Item(ConstColumnSrNo) = i + 1
                    objDrNewRow.Item(ConstColumnSampleName) = sampParant.SampleName
                    objDrNewRow.Item(ConstColumnWeight) = Format(sampParant.Weight, "0.000")
                    objDrNewRow.Item(ConstColumnVolume) = Format(sampParant.Volume, "0.000")
                    objDrNewRow.Item(ConstColumnDilutionFactor) = Format(sampParant.DilutionFactor, "0.000")
                    If mobjClsMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
                        objDrNewRow.Item(ConstColumnEnergy) = FormatNumber(samp.Abs, CONST_Format_Value_Emission)
                    Else
                        objDrNewRow.Item(ConstColumnAbs) = FormatNumber(samp.Abs, CONST_Format_Value_Absorbance)
                    End If
                    '//-----    added by Sachin Dokhale on 19.05.07
                    'dblConc = Format(gobjclsStandardGraph.Get_Conc(samp.Abs, 0.0), "0.000")
                    If mobjClsMethod.StandardAddition = True Then
                        ' Set the Conc. data for Standard Addition
                        dblConc = samp.Conc
                    Else
                        ' Get the Conc. data from giver Abs 
                        dblConc = gobjclsStandardGraph.Get_Conc(samp.Abs, 0.0)
                    End If
                    '//----

                    objDrNewRow.Item(ConstColumnConcInPPM) = FormatNumber(dblConc, intNoOfDecimalPlaces)

                    Dim dblConcInPercent As Double
                    Dim dblConcInPpm As Double
                    ' Cal. Conc. data into percentage
                    dblConcInPercent = (dblConc * sampParant.Volume * sampParant.DilutionFactor * Math.Pow(10, -6)) / sampParant.Weight
                    '---following line is added by deepak on 18.08.07
                    dblConcInPpm = (dblConc * sampParant.Volume * sampParant.DilutionFactor) / sampParant.Weight
                    dblConcInPercent = dblConcInPercent * 100

                    '27.03.09
                    ' if unit in PPM the uses Conc. else use percentage of Conc.
                    ''If unit = 1 Then
                    ''    '---Unit is PPM
                    ''    'objDrNewRow.Item(ConstColumnConcInPercentage) = dblConc
                    ''    'objDrNewRow.Item(ConstColumnTotalConc) = FormatNumber(dblConc, intNoOfDecimalPlaces)
                    ''    '---following line is added by deepak on 18.08.07
                    ''    objDrNewRow.Item(ConstColumnTotalConc) = FormatNumber(dblConcInPpm, intNoOfDecimalPlaces)
                    ''Else
                    ''    '---Unit is Percentage
                    ''    'objDrNewRow.Item(ConstColumnConcInPercentage) = dblConcInPercent
                    ''    objDrNewRow.Item(ConstColumnTotalConc) = FormatNumber(dblConcInPercent, intNoOfDecimalPlaces)
                    ''End If
                    '--------------

                    '27.03.09
                    If unit = enumUnit.PPM Then
                        objDrNewRow.Item(ConstColumnTotalConc) = FormatNumber(dblConcInPpm, intNoOfDecimalPlaces)
                    ElseIf unit = enumUnit.Percent Then
                        objDrNewRow.Item(ConstColumnTotalConc) = FormatNumber(dblConcInPercent, intNoOfDecimalPlaces)
                    ElseIf unit = enumUnit.PPB Then
                        objDrNewRow.Item(ConstColumnTotalConc) = FormatNumber(dblConcInPpm, intNoOfDecimalPlaces)
                    End If
                    '----------------

                    ' add into data table of selected Run no
                    mobjDtSample.Rows.Add(objDrNewRow)
                End If
            Next i
            ' set Data ViewResult property 
            Call mobjDtSampleDataGridclass.SetDataGridProperties(dgViewResults, mobjDtSample)

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
            objWaitCursor.Dispose()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub InitShowResultsForMethod()
        '=====================================================================
        ' Procedure Name        : InitShowResultsForMethod
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : for Method show values form run number
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : pankaj h. bamb
        ' Created               : 21-Feb-2008 
        ' Revisions             : 1
        '=====================================================================


        'void InitShowResults(HWND hwnd)
        '{
        '	SAMPDATA		*samp=NULL;
        '	STDDATA		    *std=NULL;
        '	BOOL			unit=FALSE;
        '	char			str[256]="";
        '	char			str1[80]="";
        '	int	i;
        '	HDC		hdc;

        '	unit=Method->QuantData->Param.Unit;
        '	
        '   If (unit) Then
        '	{
        '		
        '		SetWindowText(GetDlgItem(hwnd, IDC_TCONC1), (LPCSTR) "Total Conc in ppm");
        '		SetWindowText(GetDlgItem(hwnd, IDC_TCONC), (LPCSTR) "Conc in ppm");
        '	}
        '   Else
        '	{
        '		SetWindowText(GetDlgItem(hwnd, IDC_TCONC1), (LPCSTR) "Total Conc in %");
        '		SetWindowText(GetDlgItem(hwnd, IDC_TCONC), (LPCSTR) "Conc in ppm");
        '	}
        '	SendMessage(GetDlgItem(hwnd,IDC_RESULT), LB_RESETCONTENT, 0, 0L);
        '	std=Method->QuantData->StdTopData;
        '	i=1;
        '	hdc = GetDC(hwnd);

        '   While (std! = NULL)
        '	{
        '		if (std->Data.Abs>-0.2 && std->Data.Used)
        '		{
        '			strcpy(str1,""); strcpy(str,"");
        '			sprintf(str,"%-2d\t", i);
        '			sprintf(str1,"%s\t", std->Data.Std_Name);
        '			strcat(str, str1);
        '			sprintf(str1,"   -\t" );
        '			strcat(str, str1);
        '			sprintf(str1,"   -\t" );
        '			strcat(str, str1);
        '			sprintf(str1,"   -\t" );
        '			strcat(str, str1);
        '			if (Method->Mode==MODE_EMISSION)
        '				sprintf(str1,"%-4.1f %%\t", std->Data.Abs);
        '           Else
        '			{
        '				StoreAbsAccurate(std->Data.Abs,str1);  
        '				strcat(str1,"\t");
        '				//sprintf(str1,"%-4.3f\t",std->Data.Abs);
        '			}
        '			strcat(str, str1);
        '			StoreResultAccurate(std->Data.Conc, str1, Method->QuantData->Param.No_Decimals);
        '			strcat(str, str1); strcat(str,"\t");
        '			SendMessage(GetDlgItem(hwnd,IDC_RESULT), LB_ADDSTRING, 0, (DWORD) (LPSTR) str);
        '			i++;
        '		}
        '		std=std->next;
        '	}

        '	samp=Method->QuantData->SampTopData;

        '   While (samp! = NULL)
        '	{
        '		if (samp->Data.Abs>-0.2 && samp->Data.Used)
        '		{
        '			strcpy(str1,""); strcpy(str,"");
        '			sprintf(str,"%-2d\t",  samp->Data.SampNo);
        '			sprintf(str1,"%-s\t", samp->Data.Samp_Name);
        '			strcat(str, str1);
        '			sprintf(str1,"%-7.4f\t",samp->Data.Weight );
        '			strcat(str, str1);
        '			sprintf(str1,"%-7.4f\t",samp->Data.Volume);
        '			strcat(str, str1);
        '			sprintf(str1,"%-7.4f\t",samp->Data.Dil_Fact);
        '			strcat(str, str1);
        '#If STD_ADDN Then
        '				if(Method->QuantData->Param.Std_Addn)
        '					sprintf(str1,"-\t", samp->Data.Abs);
        '				else
        '				{
        '					if (Method->Mode==MODE_EMISSION)
        '						sprintf(str1,"%-4.1f %%\t", samp->Data.Abs);
        '					else
        '					{
        '						StoreAbsAccurate(samp->Data.Abs,str1);
        '						strcat(str1,"\t");
        '						
        '					}
        '				}
        '#Else
        '				if (Method->Mode==MODE_EMISSION)
        '					sprintf(str1,"%-4.1f %%\t", samp->Data.Abs);
        '                                Else
        '					sprintf(str1,"%-4.3f\t",samp->Data.Abs );
        '#End If

        '			strcat(str, str1);

        '#If STD_ADDN Then
        '			if(Method->QuantData->Param.Std_Addn)
        '				sprintf(str1,"-\t", samp->Data.Abs);
        '			else
        '				StoreResultAccurate(samp->Data.Conc, str1, Method->QuantData->Param.No_Decimals);
        '#Else
        '				StoreResultAccurate(samp->Data.Conc, str1, Method->QuantData->Param.No_Decimals);
        '#End If
        '			strcat(str, str1); strcat(str,"\t");
        '			StoreResultAccurate(Get_percent(samp->Data.Conc, samp->Data.Weight,
        '								samp->Data.Volume,samp->Data.Dil_Fact,
        '								Method->QuantData->Param.Unit,
        '								Method->QuantData->Param.No_Decimals
        '								),
        '			str1, Method->QuantData->Param.No_Decimals);

        '			strcat(str, str1);
        '			SendMessage(GetDlgItem(hwnd,IDC_RESULT), LB_ADDSTRING, 0, (DWORD) (LPSTR) str);
        '			i++;
        '		}
        '		samp=samp->next;
        '	}
        '	ReleaseDC(hwnd, hdc); 
        '}

        Dim objWaitCursor As New Common.CWaitCursor

        Dim std As AAS203Library.Method.clsAnalysisStdParameters
        Dim samp As AAS203Library.Method.clsAnalysisSampleParameters
        'Dim sampParant As AAS203Library.Method.clsAnalysisSampleParameters
        Dim i As Integer
        Dim unit As Integer = 0
        Dim str, str1 As String
        Dim objDrNewRow As DataRow
        Dim dblConc As Double
        Dim intNoOfDecimalPlaces As Integer
        Try
            If IsNothing(mobjClsMethod.QuantitativeDataCollection) Then
                Exit Sub
            End If

            If mobjClsMethod.QuantitativeDataCollection.Count = 0 Then
                Exit Sub
            End If

            'unit = mobjClsMethod.AnalysisParameters.Unit 'by pankaj
            unit = mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit 'by pankaj on 21 feb 08
            '1 = PPM  And 2 = %
            'intNoOfDecimalPlaces = CInt(mobjClsMethod.AnalysisParameters.NumOfDecimalPlaces)
            intNoOfDecimalPlaces = CInt(mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)


            mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnSrNo, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleSrNo, ConstWidthSrNo, True)
            mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnSampleName, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Left, ConstTitleSampleName, ConstWidthSampleName, True)
            mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnWeight, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleWeight, ConstWidthWeight, True)
            mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnVolume, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleVolume, ConstWidthVolume, True)
            mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnDilutionFactor, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleDilutionFactor, ConstWidthDilutionFactor, True)
            If mobjClsMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
                mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnEnergy, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleEnergy, ConstWidthEnergy, True)
            Else
                mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnAbs, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleAbs, ConstWidthAbs, True)
            End If
            '---commented on 27.03.09
            'mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnConcInPPM, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleConcInPPM, ConstWidthConcInPPM, True)
            '-----

            '---written on 27.03.09
            If unit = enumUnit.PPB Then
                mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnConcInPPM, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleConcInPPB, ConstWidthConcInPPB, True)
            Else
                mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnConcInPPM, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleConcInPPM, ConstWidthConcInPPM, True)
            End If
            '----------------

            ''--- 27.03.09
            ''---Unit is PPM
            ''If unit = 1 Then
            ''    mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnTotalConc, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleTotalConcInPPM, ConstWidthTotalConcInPPM, True)
            ''Else
            ''    '---Unit is %
            ''    mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnTotalConc, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleTotalConcInPercent, ConstWidthTotalConcInPercentage, True)
            ''End If


            'written on 27.03.09
            If unit = enumUnit.PPM Then
                mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnTotalConc, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleTotalConcInPPM, ConstWidthTotalConcInPPM, True)
            ElseIf unit = enumUnit.Percent Then
                mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnTotalConc, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleTotalConcInPercent, ConstWidthTotalConcInPercentage, True)
            ElseIf unit = enumUnit.PPB Then
                mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnTotalConc, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleTotalConcInPPB, ConstWidthTotalConcInPPB, True)
            End If
            '-----------


            i = 0
            ' add Standard collection data into data table to print object
            For i = 0 To mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count - 1
                std = mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(i)

                If (std.Abs > -0.2 And std.Used) Then
                    objDrNewRow = mobjDtSample.NewRow

                    If Not std.StdName = "" Then
                        objDrNewRow.Item(ConstColumnSampleName) = std.StdName
                    Else
                        objDrNewRow.Item(ConstColumnSampleName) = ConstDefaultSampleName
                    End If

                    objDrNewRow.Item(ConstColumnSrNo) = i + 1
                    objDrNewRow.Item(ConstColumnSampleName) = std.StdName
                    objDrNewRow.Item(ConstColumnWeight) = ""
                    objDrNewRow.Item(ConstColumnVolume) = ""
                    objDrNewRow.Item(ConstColumnDilutionFactor) = ""
                    objDrNewRow.Item(ConstColumnConcInPPM) = FormatNumber(std.Concentration, intNoOfDecimalPlaces)
                    objDrNewRow.Item(ConstColumnTotalConc) = ""

                    If (mobjClsMethod.OperationMode = EnumOperationMode.MODE_EMMISSION) Then
                        'sprintf(str1,"%-4.1f %%\t", std->Data.Abs);
                        ' Set the format of decimal point to the data for emission
                        objDrNewRow.Item(ConstColumnEnergy) = FormatNumber(std.Abs, CONST_Format_Value_Emission)
                    Else
                        ' Set the format of decimal point to the data 
                        'StoreAbsAccurate(std->Data.Abs,str1);  
                        'strcat(str1,"\t");
                        objDrNewRow.Item(ConstColumnAbs) = FormatNumber(std.Abs, CONST_Format_Value_Absorbance)
                    End If
                    'StoreResultAccurate(std->Data.Conc, str1, Method->QuantData->Param.No_Decimals);

                    mobjDtSample.Rows.Add(objDrNewRow)
                End If

            Next i

            i = 0
            ' add Sasmple collection data into data table to print object
            '//----- Modified by Sachin Dokhale
            For i = 0 To mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count - 1
                'For i = 0 To mobjClsMethod.SampleDataCollection.Count - 1 'comment by pankaj on 21 feb 08
                samp = mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(i)
                'sampParant = mobjClsMethod.SampleDataCollection.item(i)
                If (samp.Abs > -0.2 And samp.Used) Then
                    objDrNewRow = mobjDtSample.NewRow

                    str1 = ""
                    str = ""
                    objDrNewRow.Item(ConstColumnSrNo) = i + 1
                    'objDrNewRow.Item(ConstColumnSampleName) = sampParant.SampleName
                    'objDrNewRow.Item(ConstColumnWeight) = Format(sampParant.Weight, "0.000")
                    'objDrNewRow.Item(ConstColumnVolume) = Format(sampParant.Volume, "0.000")
                    'objDrNewRow.Item(ConstColumnDilutionFactor) = Format(sampParant.DilutionFactor, "0.000")
                    'Added by Pankaj  on 21 Feb 08
                    objDrNewRow.Item(ConstColumnSampleName) = samp.SampleName
                    objDrNewRow.Item(ConstColumnWeight) = Format(samp.Weight, "0.000")
                    objDrNewRow.Item(ConstColumnVolume) = Format(samp.Volume, "0.000")
                    objDrNewRow.Item(ConstColumnDilutionFactor) = Format(samp.DilutionFactor, "0.000")

                    If mobjClsMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
                        objDrNewRow.Item(ConstColumnEnergy) = FormatNumber(samp.Abs, CONST_Format_Value_Emission)
                    Else
                        objDrNewRow.Item(ConstColumnAbs) = FormatNumber(samp.Abs, CONST_Format_Value_Absorbance)
                    End If
                    '//-----    added by Sachin Dokhale on 19.05.07
                    'dblConc = Format(gobjclsStandardGraph.Get_Conc(samp.Abs, 0.0), "0.000")
                    If mobjClsMethod.StandardAddition = True Then
                        ' Set the Conc. data for Standard Addition
                        dblConc = samp.Conc
                    Else
                        ' Get the Conc. data from giver Abs 
                        dblConc = gobjclsStandardGraph.Get_Conc(samp.Abs, 0.0)
                    End If
                    '//----

                    objDrNewRow.Item(ConstColumnConcInPPM) = FormatNumber(dblConc, intNoOfDecimalPlaces)

                    Dim dblConcInPercent As Double
                    Dim dblConcInPpm As Double
                    ' Cal. Conc. data into percentage
                    'dblConcInPercent = (dblConc * sampParant.Volume * sampParant.DilutionFactor * Math.Pow(10, -6)) / sampParant.Weight
                    ''---following line is added by deepak on 18.08.07
                    'dblConcInPpm = (dblConc * sampParant.Volume * sampParant.DilutionFactor) / sampParant.Weight
                    
                    dblConcInPercent = (dblConc * samp.Volume * samp.DilutionFactor * Math.Pow(10, -6)) / samp.Weight
                    '---following line is added by deepak on 18.08.07
                    dblConcInPpm = (dblConc * samp.Volume * samp.DilutionFactor) / samp.Weight
                    '----------------

                    dblConcInPercent = dblConcInPercent * 100

                    '---27.03.09
                    ' if unit in PPM the uses Conc. else use percentage of Conc.
                    ''If unit = 1 Then
                    ''    '---Unit is PPM
                    ''    'objDrNewRow.Item(ConstColumnConcInPercentage) = dblConc
                    ''    'objDrNewRow.Item(ConstColumnTotalConc) = FormatNumber(dblConc, intNoOfDecimalPlaces)
                    ''    '---following line is added by deepak on 18.08.07
                    ''    objDrNewRow.Item(ConstColumnTotalConc) = FormatNumber(dblConcInPpm, intNoOfDecimalPlaces)
                    ''Else
                    ''    '---Unit is Percentage
                    ''    'objDrNewRow.Item(ConstColumnConcInPercentage) = dblConcInPercent
                    ''    objDrNewRow.Item(ConstColumnTotalConc) = FormatNumber(dblConcInPercent, intNoOfDecimalPlaces)
                    ''End If
                    '------

                    '---27.03.09
                    If unit = enumUnit.PPM Then
                        objDrNewRow.Item(ConstColumnTotalConc) = FormatNumber(dblConcInPpm, intNoOfDecimalPlaces)
                    ElseIf unit = enumUnit.Percent Then
                        objDrNewRow.Item(ConstColumnTotalConc) = FormatNumber(dblConcInPercent, intNoOfDecimalPlaces)
                    ElseIf unit = enumUnit.PPB Then
                        objDrNewRow.Item(ConstColumnTotalConc) = FormatNumber(dblConcInPpm, intNoOfDecimalPlaces)
                    End If
                    '-------------


                    'sprintf(str,"%-2d\t",  samp->Data.SampNo);
                    'sprintf(str1,"%-s\t", samp->Data.Samp_Name);
                    'strcat(str, str1);
                    'sprintf(str1,"%-7.4f\t",samp->Data.Weight );
                    'strcat(str, str1);
                    'sprintf(str1,"%-7.4f\t",samp->Data.Volume);
                    'strcat(str, str1);
                    'sprintf(str1,"%-7.4f\t",samp->Data.Dil_Fact);
                    'strcat(str, str1);
                    '#If STD_ADDN Then
                    '    if(Method->QuantData->Param.Std_Addn)
                    '		sprintf(str1,"-\t", samp->Data.Abs);
                    '	else
                    '	{
                    '		if (Method->Mode==MODE_EMISSION)
                    '			sprintf(str1,"%-4.1f %%\t", samp->Data.Abs);
                    '		else
                    '		{
                    '			StoreAbsAccurate(samp->Data.Abs,str1);
                    '			strcat(str1,"\t");
                    '			}
                    '	}
                    '#Else
                    '	if (Method->Mode==MODE_EMISSION)
                    '		sprintf(str1,"%-4.1f %%\t", samp->Data.Abs);
                    '   Else
                    '    	sprintf(str1,"%-4.3f\t",samp->Data.Abs );
                    '#End If
                    'strcat(str, str1);
                    '#If STD_ADDN Then
                    '    if(Method->QuantData->Param.Std_Addn)
                    '	    sprintf(str1,"-\t", samp->Data.Abs);
                    '    else
                    '	    StoreResultAccurate(samp->Data.Conc, str1, Method->QuantData->Param.No_Decimals);
                    '#Else
                    '    StoreResultAccurate(samp->Data.Conc, str1, Method->QuantData->Param.No_Decimals);
                    '#End If
                    'strcat(str, str1); strcat(str,"\t");
                    'StoreResultAccurate(Get_percent(samp->Data.Conc, samp->Data.Weight,
                    '					samp->Data.Volume,samp->Data.Dil_Fact,
                    '					Method->QuantData->Param.Unit,
                    '					Method->QuantData->Param.No_Decimals
                    '					),
                    'str1, Method->QuantData->Param.No_Decimals);
                    'strcat(str, str1);
                    'SendMessage(GetDlgItem(hwnd,IDC_RESULT), LB_ADDSTRING, 0, (DWORD) (LPSTR) str);

                    ' add into data table of selected Run no
                    mobjDtSample.Rows.Add(objDrNewRow)
                End If
            Next i
            ' set Data ViewResult property 
            Call mobjDtSampleDataGridclass.SetDataGridProperties(dgViewResults, mobjDtSample)

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
            objWaitCursor.Dispose()
            '---------------------------------------------------------
        End Try
    End Sub

#End Region

End Class
