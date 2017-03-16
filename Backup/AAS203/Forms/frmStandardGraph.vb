Imports AAS203.Common
Imports AAS203Library.Method

Public Class frmStandardGraph
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal blnIsSampleGraph As Boolean, ByVal blnIsAnalysisMode As Boolean, _
                   ByRef objclsMethod As clsMethod, ByVal intSelectedRunNumber As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mblnIsSampleGraph = blnIsSampleGraph
        mblnIsAnalysisMode = blnIsAnalysisMode
        mobjclsMethod = objclsMethod
        mintSelectedRunNumber = intSelectedRunNumber

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
    Friend WithEvents btnOk As NETXP.Controls.XPButton
    Friend WithEvents CustomPanelMain As GradientPanel.CustomPanel
    Friend WithEvents CustomPanelTop As GradientPanel.CustomPanel
    Friend WithEvents CustomPanelBottom As GradientPanel.CustomPanel
    Friend WithEvents gbCalculationMode As System.Windows.Forms.GroupBox
    Friend WithEvents rbDirect As System.Windows.Forms.RadioButton
    Friend WithEvents rbLinear As System.Windows.Forms.RadioButton
    Friend WithEvents rbRatioMethod As System.Windows.Forms.RadioButton
    Friend WithEvents rbQuadratic As System.Windows.Forms.RadioButton
    Friend WithEvents rbCubic As System.Windows.Forms.RadioButton
    Friend WithEvents rb4thOrder As System.Windows.Forms.RadioButton
    Friend WithEvents rb5thOrder As System.Windows.Forms.RadioButton
    Friend WithEvents txtCalcProcess As System.Windows.Forms.TextBox
    Friend WithEvents lblCalcDescription As System.Windows.Forms.Label
    Friend WithEvents Graph As AAS203.AASGraph
    Friend WithEvents btnPrint As NETXP.Controls.XPButton
    Friend WithEvents cmdChangeScale As NETXP.Controls.XPButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmStandardGraph))
        Me.CustomPanelMain = New GradientPanel.CustomPanel
        Me.CustomPanelTop = New GradientPanel.CustomPanel
        Me.Graph = New AAS203.AASGraph
        Me.CustomPanelBottom = New GradientPanel.CustomPanel
        Me.cmdChangeScale = New NETXP.Controls.XPButton
        Me.btnPrint = New NETXP.Controls.XPButton
        Me.btnOk = New NETXP.Controls.XPButton
        Me.lblCalcDescription = New System.Windows.Forms.Label
        Me.txtCalcProcess = New System.Windows.Forms.TextBox
        Me.gbCalculationMode = New System.Windows.Forms.GroupBox
        Me.rb5thOrder = New System.Windows.Forms.RadioButton
        Me.rb4thOrder = New System.Windows.Forms.RadioButton
        Me.rbCubic = New System.Windows.Forms.RadioButton
        Me.rbQuadratic = New System.Windows.Forms.RadioButton
        Me.rbRatioMethod = New System.Windows.Forms.RadioButton
        Me.rbLinear = New System.Windows.Forms.RadioButton
        Me.rbDirect = New System.Windows.Forms.RadioButton
        Me.CustomPanelMain.SuspendLayout()
        Me.CustomPanelTop.SuspendLayout()
        Me.CustomPanelBottom.SuspendLayout()
        Me.gbCalculationMode.SuspendLayout()
        Me.SuspendLayout()
        '
        'CustomPanelMain
        '
        Me.CustomPanelMain.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.CustomPanelMain.Controls.Add(Me.CustomPanelTop)
        Me.CustomPanelMain.Controls.Add(Me.CustomPanelBottom)
        Me.CustomPanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanelMain.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanelMain.Name = "CustomPanelMain"
        Me.CustomPanelMain.Size = New System.Drawing.Size(498, 415)
        Me.CustomPanelMain.TabIndex = 0
        '
        'CustomPanelTop
        '
        Me.CustomPanelTop.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanelTop.Controls.Add(Me.Graph)
        Me.CustomPanelTop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanelTop.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanelTop.Name = "CustomPanelTop"
        Me.CustomPanelTop.Size = New System.Drawing.Size(498, 247)
        Me.CustomPanelTop.TabIndex = 0
        '
        'Graph
        '
        Me.Graph.AldysGraphCursor = System.Windows.Forms.Cursors.Hand
        Me.Graph.AldysGraphPrintColor = System.Drawing.Color.Black
        Me.Graph.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Graph.BackColor = System.Drawing.Color.LightGray
        Me.Graph.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Graph.GraphDataSource = Nothing
        Me.Graph.GraphImage = Nothing
        Me.Graph.IsShowGrid = True
        Me.Graph.Location = New System.Drawing.Point(4, 5)
        Me.Graph.Name = "Graph"
        Me.Graph.Size = New System.Drawing.Size(492, 235)
        Me.Graph.TabIndex = 1
        Me.Graph.UseDefaultSettings = False
        Me.Graph.XAxisDateMax = New Date(CType(0, Long))
        Me.Graph.XAxisDateMin = New Date(CType(0, Long))
        Me.Graph.XAxisDateScaleFormat = AAS203.AASGraph.enumDateScaleFormat.YYYY
        Me.Graph.XAxisLabel = "CONCENTRATION"
        Me.Graph.XAxisMax = 100
        Me.Graph.XAxisMin = 0
        Me.Graph.XAxisMinorStep = 2
        Me.Graph.XAxisScaleFormat = Nothing
        Me.Graph.XAxisStep = 10
        Me.Graph.XAxisType = AldysGraph.AxisType.Linear
        Me.Graph.YAxisLabel = "ABSORBANCE"
        Me.Graph.YAxisMax = 100
        Me.Graph.YAxisMin = 0
        Me.Graph.YAxisMinorStep = 2
        Me.Graph.YAxisScaleFormat = Nothing
        Me.Graph.YAxisStep = 10
        Me.Graph.YAxisType = AldysGraph.AxisType.Linear
        '
        'CustomPanelBottom
        '
        Me.CustomPanelBottom.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanelBottom.Controls.Add(Me.cmdChangeScale)
        Me.CustomPanelBottom.Controls.Add(Me.btnPrint)
        Me.CustomPanelBottom.Controls.Add(Me.btnOk)
        Me.CustomPanelBottom.Controls.Add(Me.lblCalcDescription)
        Me.CustomPanelBottom.Controls.Add(Me.txtCalcProcess)
        Me.CustomPanelBottom.Controls.Add(Me.gbCalculationMode)
        Me.CustomPanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CustomPanelBottom.Location = New System.Drawing.Point(0, 247)
        Me.CustomPanelBottom.Name = "CustomPanelBottom"
        Me.CustomPanelBottom.Size = New System.Drawing.Size(498, 168)
        Me.CustomPanelBottom.TabIndex = 1
        '
        'cmdChangeScale
        '
        Me.cmdChangeScale.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdChangeScale.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdChangeScale.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdChangeScale.Image = CType(resources.GetObject("cmdChangeScale.Image"), System.Drawing.Image)
        Me.cmdChangeScale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdChangeScale.Location = New System.Drawing.Point(408, 32)
        Me.cmdChangeScale.Name = "cmdChangeScale"
        Me.cmdChangeScale.Size = New System.Drawing.Size(80, 34)
        Me.cmdChangeScale.TabIndex = 3
        Me.cmdChangeScale.Text = "Change Scale"
        Me.cmdChangeScale.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnPrint
        '
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrint.Location = New System.Drawing.Point(408, 126)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(80, 34)
        Me.btnPrint.TabIndex = 2
        Me.btnPrint.Text = "&Print"
        '
        'btnOk
        '
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Image = CType(resources.GetObject("btnOk.Image"), System.Drawing.Image)
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(408, 79)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(80, 34)
        Me.btnOk.TabIndex = 1
        Me.btnOk.Text = "OK"
        '
        'lblCalcDescription
        '
        Me.lblCalcDescription.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCalcDescription.Location = New System.Drawing.Point(215, 80)
        Me.lblCalcDescription.Name = "lblCalcDescription"
        Me.lblCalcDescription.Size = New System.Drawing.Size(193, 80)
        Me.lblCalcDescription.TabIndex = 2
        '
        'txtCalcProcess
        '
        Me.txtCalcProcess.BackColor = System.Drawing.Color.White
        Me.txtCalcProcess.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCalcProcess.Location = New System.Drawing.Point(8, 80)
        Me.txtCalcProcess.Multiline = True
        Me.txtCalcProcess.Name = "txtCalcProcess"
        Me.txtCalcProcess.ReadOnly = True
        Me.txtCalcProcess.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCalcProcess.Size = New System.Drawing.Size(200, 80)
        Me.txtCalcProcess.TabIndex = 1
        Me.txtCalcProcess.Text = ""
        '
        'gbCalculationMode
        '
        Me.gbCalculationMode.BackColor = System.Drawing.Color.AliceBlue
        Me.gbCalculationMode.Controls.Add(Me.rb5thOrder)
        Me.gbCalculationMode.Controls.Add(Me.rb4thOrder)
        Me.gbCalculationMode.Controls.Add(Me.rbCubic)
        Me.gbCalculationMode.Controls.Add(Me.rbQuadratic)
        Me.gbCalculationMode.Controls.Add(Me.rbRatioMethod)
        Me.gbCalculationMode.Controls.Add(Me.rbLinear)
        Me.gbCalculationMode.Controls.Add(Me.rbDirect)
        Me.gbCalculationMode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCalculationMode.Location = New System.Drawing.Point(8, 8)
        Me.gbCalculationMode.Name = "gbCalculationMode"
        Me.gbCalculationMode.Size = New System.Drawing.Size(392, 64)
        Me.gbCalculationMode.TabIndex = 0
        Me.gbCalculationMode.TabStop = False
        Me.gbCalculationMode.Text = "Calculation Mode"
        '
        'rb5thOrder
        '
        Me.rb5thOrder.Location = New System.Drawing.Point(280, 40)
        Me.rb5thOrder.Name = "rb5thOrder"
        Me.rb5thOrder.Size = New System.Drawing.Size(70, 16)
        Me.rb5thOrder.TabIndex = 6
        Me.rb5thOrder.Text = "5th Order"
        '
        'rb4thOrder
        '
        Me.rb4thOrder.Location = New System.Drawing.Point(192, 40)
        Me.rb4thOrder.Name = "rb4thOrder"
        Me.rb4thOrder.Size = New System.Drawing.Size(80, 16)
        Me.rb4thOrder.TabIndex = 5
        Me.rb4thOrder.Text = "4th Order"
        '
        'rbCubic
        '
        Me.rbCubic.Location = New System.Drawing.Point(88, 40)
        Me.rbCubic.Name = "rbCubic"
        Me.rbCubic.Size = New System.Drawing.Size(56, 16)
        Me.rbCubic.TabIndex = 4
        Me.rbCubic.Text = "Cubic"
        '
        'rbQuadratic
        '
        Me.rbQuadratic.Location = New System.Drawing.Point(8, 40)
        Me.rbQuadratic.Name = "rbQuadratic"
        Me.rbQuadratic.Size = New System.Drawing.Size(80, 16)
        Me.rbQuadratic.TabIndex = 3
        Me.rbQuadratic.Text = "Quadratic"
        '
        'rbRatioMethod
        '
        Me.rbRatioMethod.Location = New System.Drawing.Point(88, 16)
        Me.rbRatioMethod.Name = "rbRatioMethod"
        Me.rbRatioMethod.Size = New System.Drawing.Size(96, 16)
        Me.rbRatioMethod.TabIndex = 2
        Me.rbRatioMethod.Text = "Ratio Method"
        '
        'rbLinear
        '
        Me.rbLinear.Location = New System.Drawing.Point(192, 16)
        Me.rbLinear.Name = "rbLinear"
        Me.rbLinear.Size = New System.Drawing.Size(64, 16)
        Me.rbLinear.TabIndex = 1
        Me.rbLinear.Text = "Linear"
        '
        'rbDirect
        '
        Me.rbDirect.Location = New System.Drawing.Point(8, 16)
        Me.rbDirect.Name = "rbDirect"
        Me.rbDirect.Size = New System.Drawing.Size(80, 16)
        Me.rbDirect.TabIndex = 0
        Me.rbDirect.Text = "Direct"
        '
        'frmStandardGraph
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(498, 415)
        Me.Controls.Add(Me.CustomPanelMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStandardGraph"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.CustomPanelMain.ResumeLayout(False)
        Me.CustomPanelTop.ResumeLayout(False)
        Me.CustomPanelBottom.ResumeLayout(False)
        Me.gbCalculationMode.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Private Class Member Variables "

    Private mblnIsSampleGraph As Boolean
    Private mobjParameters As New Spectrum.EnergySpectrumParameter
    Private mintCalculationMode As clsQuantitativeData.enumCalculationMode
    Private Init As Boolean = False
    Private disp As Boolean = False
    Private mintRunNumberIndex As Integer
    Private mblnIsEmmissionMode As Boolean

    Private mobjStdSampleCurve As AldysGraph.CurveItem
    Private mobjScatteredPointsCurve As AldysGraph.CurveItem
    Private mblnIsAnalysisMode As Boolean

    Public mobjclsMethod As New clsMethod
    Private mintSelectedRunNumber As Integer

    Private mobjClsDataFileReport As New clsDataFileReport
    Private mintSelectedMethodID As Integer = 0
    Private GrpEvn As AAS203.AASGraph.PointAddRemoveHandler
#End Region

#Region " Private Constants"

    Private Const ConstFormDataFilesStd = "-DataFiles-StandardGraph"
    Private Const ConstFormDataFilesSam = "-DataFiles-SampleGraph"
    Private Const ConstParentFormLoadDataFiles = "-DataFiles"
    Private Const ConstFormAnalysisStd = "-Analysis-StandardGraph"
    Private Const ConstFormAnalysisSam = "-Analysis-SampleGraph"
    Private Const ConstParentFormLoadAnalysis = "-Analysis"

#End Region

#Region " Private Properties "

#End Region

#Region " Form Load and Event Handling Functions "

    Private Sub frmStandardGraph_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmStandardGraph_Load
        ' Parameters Passed     : object, eventArgs
        ' Returns               : None
        ' Purpose               : To show the Standard  Graph
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================


        '--- ORIGINAL CODE

        'case	WM_INITDIALOG :
        '   Init=FALSE;
        '   Init_Calculation_Mode(hwnd, &Method->QuantData->cMode);
        '	lMode= Method->QuantData->cMode;
        '#If !STD_ADDN Then
        '	    if (!IsStdCurve())
        '#End If
        '	CalcStdCurve(hwnd);
        '   If (!IsStdCurve()) Then
        '	    PostMessage(hwnd, WM_COMMAND, IDOK,0L);
        '   Else
        '	{
        '	    CalcSampValues();
        '		Change_Calculation_Mode(hwnd, &lMode);
        '		InCurs=FALSE;
        '		ps.hdc=NULL;
        '		if (curs==NULL)
        '		    curs =  	(HCURSOR) LoadCursor(hInst,"hand");
        '       If (oldcurs! = NULL) Then
        '		    SetCursor(oldcurs);
        '		Create_Curve(hwnd, &CurveData);
        '			hfont = Change_Button_font(hwnd, hfont, TRUE, FALSE);
        '       If (hfont) Then
        '		    SendDlgItemMessage(hwnd, IDC_EQN, WM_SETFONT,(WPARAM) hfont, 0L);
        '		SendDlgItemMessage(hwnd, IDC_THINT, WM_SETFONT,(WPARAM) hfont, 0L);
        '		InvalidateRect(hwnd, NULL, TRUE);
        '	}
        '	Init=TRUE;
        '	if(Autosampler && Started )
        '	    SendMessage(hwnd,WM_COMMAND,IDOK,0L);
        '	return TRUE;

        Dim objWaitCursor As New CWaitCursor
        ' Init Form object
        Try

            ' Set the title and messages into the form
            If Not mblnIsSampleGraph Then
                Me.Text = "QUANTITATIVE ANALYSIS - STANDARD WORKING GRAPH"
                If mblnIsAnalysisMode = False Then
                    gobjMain.ShowProgressBar(gstrTitleInstrumentType & ConstFormDataFilesStd)
                Else
                    gobjMain.ShowProgressBar(gstrTitleInstrumentType & ConstFormAnalysisStd)
                End If
            Else
                Me.Text = "QUANTITATIVE ANALYSIS - SAMPLE WORKING GRAPH"
                If mblnIsAnalysisMode = False Then
                    gobjMain.ShowProgressBar(gstrTitleInstrumentType & ConstFormDataFilesSam)
                Else
                    gobjMain.ShowProgressBar(gstrTitleInstrumentType & ConstFormAnalysisSam)
                End If
            End If

            Init = False
            '// Check for selected Run No or for last record of Methos object analysis in process 
            If mblnIsAnalysisMode Then
                If mobjclsMethod.QuantitativeDataCollection.Count > 0 Then
                    mintRunNumberIndex = gobjNewMethod.QuantitativeDataCollection.Count - 1
                Else
                    mintRunNumberIndex = 0
                End If
            Else
                '---For Data Files Mode
                mintRunNumberIndex = gfuncGetSelectedMethodRunNumberIndex(mobjclsMethod.MethodID, mintSelectedRunNumber)
            End If

            '// Init the appropriate Calculation mode 
            Call Init_Calculation_Mode(mobjclsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).CalculationMode)
            mintCalculationMode = mobjclsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).CalculationMode

            '#If !STD_ADDN Then
            '   if (!IsStdCurve())
            '#End If

            '// Calculate the Standard Curve
            Call CalcStdCurve()

            If Not gobjclsStandardGraph.IsStdCurve() Then
                'PostMessage(hwnd, WM_COMMAND, IDOK,0L)
                Call btnOk_Click(btnOk, EventArgs.Empty)
            Else
                ' Calculate the sample values
                Call gobjclsStandardGraph.CalcSampValues(mobjclsMethod.StandardAddition)
                ' set the calculated default calculation mode to the graph and data result
                Call Change_Calculation_Mode(mintCalculationMode)
                objWaitCursor.Dispose()
                objWaitCursor = New CWaitCursor
                ' Create the curve to the graph
                Call Create_Curve()
                ' display the curve to the graph
                Call Display_Curve()
            End If

            Init = True

            'Set the handler to the this form object
            Call subAddHandlers()

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
            gobjMain.HideProgressBar()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub frmStandardGraph_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        '=====================================================================
        ' Procedure Name        : frmStandardGraph_Closing
        ' Parameters Passed     : object, eventArgs
        ' Returns               : None
        ' Purpose               : This is called when user close the form.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : praveen
        '=====================================================================
        If mblnIsAnalysisMode = False Then
            gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType & ConstParentFormLoadDataFiles)
        Else
            gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType & ConstParentFormLoadAnalysis)
        End If
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnOk_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : This will handle a OK button Click event.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 31-Jan-2007 04:10 pm
        ' Revisions             : praveen
        '=====================================================================
        Try
            Me.DialogResult = DialogResult.OK
            'Me.Close()
            'Me.Dispose()

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

    'Private Sub subSetCalculationMode(ByVal sender As Object, ByVal e As EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : subSetCalculationMode
    '    ' Parameters Passed     : Object, EventArgs
    '    ' Returns               : None
    '    ' Purpose               : 
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Mangesh Shardul
    '    ' Created               : 31-Jan-2007 03:25 pm
    '    ' Revisions             : 1
    '    '=====================================================================
    '    Try
    '        If rbDirect.Checked = True Then
    '            mintCalculationMode = clsQuantitativeData.enumCalculationMode.DIRECT
    '            Call Change_Calculation_Mode(mintCalculationMode)

    '        ElseIf rbRatioMethod.Checked = True Then
    '            mintCalculationMode = clsQuantitativeData.enumCalculationMode.RATIONAL
    '            Call Change_Calculation_Mode(mintCalculationMode)

    '        ElseIf rbLinear.Checked = True Then
    '            mintCalculationMode = clsQuantitativeData.enumCalculationMode.LINEAR
    '            Call Change_Calculation_Mode(mintCalculationMode)

    '        ElseIf rbQuadratic.Checked = True Then
    '            mintCalculationMode = clsQuantitativeData.enumCalculationMode.QUADRATIC
    '            Call Change_Calculation_Mode(mintCalculationMode)

    '        ElseIf rbCubic.Checked = True Then
    '            mintCalculationMode = clsQuantitativeData.enumCalculationMode.CUBIC
    '            Call Change_Calculation_Mode(mintCalculationMode)

    '        ElseIf rb4thOrder.Checked = True Then
    '            mintCalculationMode = clsQuantitativeData.enumCalculationMode.FOURTH_ORDER
    '            Call Change_Calculation_Mode(mintCalculationMode)

    '        ElseIf rb5thOrder.Checked = True Then
    '            mintCalculationMode = clsQuantitativeData.enumCalculationMode.FIFTH_ORDER
    '            Call Change_Calculation_Mode(mintCalculationMode)

    '        End If

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try
    'End Sub

    Private Sub rbDirect_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        '=====================================================================
        ' Procedure Name        : rbDirect_CheckedChanged
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : Set the Redio button for Direct Mode
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 31-Jan-2007 03:25 pm
        ' Revisions             : praveen
        '=====================================================================
        Try
            ' Check redio button for if Direct mode is select for calculation mode
            If rbDirect.Checked = True Then
                Call Change_Calculation_Mode(clsQuantitativeData.enumCalculationMode.DIRECT)
                'lblCalcDescription.Text = ""
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

    Private Sub rbRatioMethod_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        '=====================================================================
        ' Procedure Name        : rbRatioMethod_CheckedChanged
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : for handle a changed event.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 31-Jan-2007 03:25 pm
        ' Revisions             : praveen
        '=====================================================================
        Try
            ' Check redio button for if Ratio (RATIONAL) mode is select for calculation mode function
            If rbRatioMethod.Checked = True Then
                Call Change_Calculation_Mode(clsQuantitativeData.enumCalculationMode.RATIONAL)
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

    Private Sub rbLinear_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        '=====================================================================
        ' Procedure Name        : rbLinear_CheckedChanged
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               :  ' Check redio button for if Linear mode is select for calculation mode function
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 31-Jan-2007 03:25 pm
        ' Revisions             : praveen
        '=====================================================================
        Try
            ' Check redio button for if Linear mode is select for calculation mode function
            If rbLinear.Checked = True Then
                Call Change_Calculation_Mode(clsQuantitativeData.enumCalculationMode.LINEAR)
                ''To change and apply new Mode of Calculation
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

    Private Sub rbQuadratic_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        '=====================================================================
        ' Procedure Name        : rbQuadratic_CheckedChanged
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : ' Check redio button for if Quadratic mode is select for calculation mode function
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 31-Jan-2007 03:25 pm
        ' Revisions             : praveen
        '=====================================================================
        Try
            ' Check redio button for if Quadratic mode is select for calculation mode function
            If rbQuadratic.Checked = True Then
                Call Change_Calculation_Mode(clsQuantitativeData.enumCalculationMode.QUADRATIC)
                ''To change and apply new Mode of Calculation
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

    Private Sub rbCubic_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        '=====================================================================
        ' Procedure Name        : rbCubic_CheckedChanged
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : ' Check redio button for if Cubic mode is selectd for calculation mode function
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 31-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        Try
            ' Check redio button for if Cubic mode is selectd for calculation mode function
            If rbCubic.Checked = True Then
                Call Change_Calculation_Mode(clsQuantitativeData.enumCalculationMode.CUBIC)
                ''To change and apply new Mode of Calculation
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

    Private Sub rb4thOrder_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        '=====================================================================
        ' Procedure Name        : rb4thOrder_CheckedChanged
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : ' Check redio button for if Forth Order mode is selected for calculation mode function
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 31-Jan-2007 03:25 pm
        ' Revisions             : praveen
        '=====================================================================
        Try
            ' Check redio button for if Forth Order mode is selected for calculation mode function
            If rb4thOrder.Checked = True Then
                Call Change_Calculation_Mode(clsQuantitativeData.enumCalculationMode.FOURTH_ORDER)
                ''To change and apply new Mode of Calculation
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

    Private Sub rb5thOrder_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        '=====================================================================
        ' Procedure Name        : rb5thOrder_CheckedChanged
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : ' Check redio button for if Fifth Order mode is select for calculation mode function
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 31-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        Try
            ' Check redio button for if Fifth Order mode is select for calculation mode function
            If rb5thOrder.Checked = True Then
                Call Change_Calculation_Mode(clsQuantitativeData.enumCalculationMode.FIFTH_ORDER)
                ''''To change and apply new Mode of Calculation
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

    Private Sub AASGraph_AddRemovePoint(ByVal IsAddPoint As Boolean, ByVal pointInfo As AldysGraph.Point)
        '=====================================================================
        ' Procedure Name        : AASGraph_AddRemovePoint
        ' Parameters Passed     : Boolean Flag to enable or disable point, PointInfo
        ' Returns               : None
        ' Purpose               : this is use to Add or Remove selected Std/Samp
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 01-Mar-2007 04:45 pm
        ' Revisions             : 1
        '=====================================================================
        Dim intCounter As Integer
        Dim dblConcValue As Double
        Dim dblAbsValue As Double
        ''for counter 

        Try
            'this is use to Add or Remove selected Std/Samp
            ' Check whther point to insert or remove from graph for poltting graph
            If IsAddPoint Then
                '---Enable Standard
                For intCounter = 0 To mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).StandardDataCollection.Count - 1
                    'If mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).StandardDataCollection.item(intCounter).Concentration = CDbl(FormatNumber(pointInfo.X)) Then  '09.05.08
                    dblConcValue = mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).StandardDataCollection.item(intCounter).Concentration
                    dblAbsValue = mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).StandardDataCollection.item(intCounter).Abs
                    If (Math.Abs(pointInfo.X - dblConcValue) <= Graph.CONST_dblXpointTolerance) And (Math.Abs(pointInfo.X - dblConcValue) >= 0.0) And _
                        (Math.Abs(pointInfo.Y - dblAbsValue) <= Graph.CONST_dblYpointTolerance) And (Math.Abs(pointInfo.Y - dblAbsValue) >= 0.0) Then
                        mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).StandardDataCollection.item(intCounter).Used = True
                        'Exit For
                    End If
                Next
            Else
                '---Disable Standard
                For intCounter = 0 To mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).StandardDataCollection.Count - 1

                    dblConcValue = mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).StandardDataCollection.item(intCounter).Concentration
                    dblAbsValue = mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).StandardDataCollection.item(intCounter).Abs

                    'If mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).StandardDataCollection.item(intCounter).Concentration = CDbl(FormatNumber(pointInfo.X, 2)) Then '09.05.08
                    If (Math.Abs(pointInfo.X - dblConcValue) <= Graph.CONST_dblXpointTolerance) And (Math.Abs(pointInfo.X - dblConcValue) >= 0.0) And _
                        (Math.Abs(pointInfo.Y - dblAbsValue) <= Graph.CONST_dblYpointTolerance) And (Math.Abs(pointInfo.Y - dblAbsValue) >= 0.0) Then
                        mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).StandardDataCollection.item(intCounter).Used = False
                        'Exit For
                    End If
                Next
                'If Not (mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).SampleDataCollection Is Nothing) Then
                '    For intCounter = 0 To mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).SampleDataCollection.Count - 1
                '        If CSng(gobjclsStandardGraph.Get_Conc(mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).SampleDataCollection.item(intCounter).Abs, 0.0)) = CDbl(FormatNumber(pointInfo.X)) Then  '09.05.08
                '            'mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).SampleDataCollection.item(intCounter).Used = False
                '            Exit For
                '        End If
                '    Next
                'End If
            End If

            'calculate mode for get result
            Call Change_Calculation_Mode(mintCalculationMode)

            Call Init_Calculation_Mode(mobjclsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).CalculationMode)
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

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnPrint_Click
        ' Parameters Passed     :  
        ' Returns               : None
        ' Purpose               : this is called when user clicked on print button.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 01-Mar-2007 04:45 pm
        ' Revisions             : 1
        '=====================================================================
        Call subPrintGraph()
        ''function for printing a graph.
    End Sub

    Private Sub cmdChangeScale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChangeScale.Click
        '=====================================================================
        ' Procedure Name        : cmdChangeScale_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : calculte change scale
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Pankaj Bamb
        ' Created               : 1.05.07
        ' Revisions             : praveen
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim objfrmChangeScale As frmChangeScale


        Try
            objfrmChangeScale = New frmChangeScale(mobjParameters, False)
            ''initialise the object
            objfrmChangeScale.funcSetValidatingScale(gobjInst.Mode)
            ''set a validation as per mode.
            objfrmChangeScale.lblXAxis.Visible = False

            objfrmChangeScale.SpectrumParameter.XaxisMin = Graph.XAxisMin
            objfrmChangeScale.SpectrumParameter.XaxisMax = Graph.XAxisMax

            objfrmChangeScale.SpectrumParameter.YaxisMin = Graph.YAxisMin
            objfrmChangeScale.SpectrumParameter.YaxisMax = Graph.YAxisMax
            '------------------------
            If objfrmChangeScale.ShowDialog() = DialogResult.OK Then
                ''show the dialog.
                If Not objfrmChangeScale.SpectrumParameter Is Nothing Then
                    ''set a current scale to mobjParameters object.
                    mobjParameters.XaxisMax = objfrmChangeScale.SpectrumParameter.XaxisMax
                    mobjParameters.XaxisMin = objfrmChangeScale.SpectrumParameter.XaxisMin
                    mobjParameters.YaxisMax = objfrmChangeScale.SpectrumParameter.YaxisMax
                    mobjParameters.YaxisMin = objfrmChangeScale.SpectrumParameter.YaxisMin
                End If
                Graph.XAxisMin = mobjParameters.XaxisMin
                Graph.XAxisMax = mobjParameters.XaxisMax
                Graph.YAxisMin = mobjParameters.YaxisMin
                Graph.YAxisMax = mobjParameters.YaxisMax

                Call gobjClsAAS203.Calculate_Analysis_Graph_Param(Graph, ClsAAS203.enumChangeAxis.xyAxis)
                ''for calculate a graph parameter
            End If
            objfrmChangeScale.Close()
            ''close


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
            objfrmChangeScale.Dispose()
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            'mblnAvoidProcessing = False
            '---------------------------------------------------------
        End Try
    End Sub

#End Region

#Region " Private Functions "

    Private Sub subAddHandlers()
        '=====================================================================
        ' Procedure Name        : subAddHandlers
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : initialize handler to controls
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 31-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        ''note:
        ''this is called during a initialisation
        ''this is used for adding a event to a control
        Try
            AddHandler btnOk.Click, AddressOf btnOk_Click
            AddHandler Graph.AddRemovePoint, AddressOf AASGraph_AddRemovePoint

            AddHandler rbDirect.CheckedChanged, AddressOf rbDirect_CheckedChanged
            AddHandler rbRatioMethod.CheckedChanged, AddressOf rbRatioMethod_CheckedChanged
            AddHandler rbLinear.CheckedChanged, AddressOf rbLinear_CheckedChanged
            AddHandler rbQuadratic.CheckedChanged, AddressOf rbQuadratic_CheckedChanged
            AddHandler rbCubic.CheckedChanged, AddressOf rbCubic_CheckedChanged
            AddHandler rb4thOrder.CheckedChanged, AddressOf rb4thOrder_CheckedChanged
            AddHandler rb5thOrder.CheckedChanged, AddressOf rb5thOrder_CheckedChanged
            AddHandler btnPrint.Click, AddressOf btnPrint_Click

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

    Private Sub Init_Calculation_Mode(ByRef intCalculationMode As clsQuantitativeData.enumCalculationMode)
        '=====================================================================
        ' Procedure Name        : Init_Calculation_Mode
        ' Parameters Passed     : Reference to Calculation Mode
        ' Returns               : None
        ' Purpose               : Init. decide default calculation mode 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1 praveencheck
        '=====================================================================


        '--- ORIGINAL CODE

        'void Init_Calculation_Mode(HWND hwnd, int *mode)
        '{
        '   int	nstd;
        '   int	i, j;
        '   HWND	hwnd1;

        '   nstd = GetNoValidStdConcAbs(Method->QuantData->StdTopData);
        '   #If STD_ADDN Then
        '	    if(Method->QuantData->Param.Std_Addn)
        '		    nstd--;
        '   #Else
        '       #If !ZERO_PASSING Then
        '	        nstd--;
        '       #End If
        '   #End If
        '   #if STD_ADDN // added by sss on dt 25/09/2000 for std addn method
        '	    if(Method->QuantData->Param.Std_Addn){
        '		    for(i = IDC_RBDIRECT; i<=IDC_RB5; i++){
        '		        j = i-IDC_RBDIRECT-1;
        '		        hwnd1 =  GetDlgItem(hwnd, i);
        '		        if (j==1){
        '			        if (!IsWindowEnabled(hwnd1))
        '				        EnableWindow(hwnd1, TRUE);
        '		        }
        '		        else
        '				    EnableWindow(hwnd1, FALSE);
        '           }
        '	    }
        '	    else{
        '		    for(i = IDC_RBDIRECT; i<=IDC_RB5; i++){
        '		        j = i-IDC_RBDIRECT-1;
        '		        hwnd1 =  GetDlgItem(hwnd, i);
        '		        if (j>nstd)
        '			        EnableWindow(hwnd1, FALSE);
        '		        else
        '			        if (!IsWindowEnabled(hwnd1))
        '				        EnableWindow(hwnd1, TRUE);
        '	        }
        '	    }
        '   #Else
        '	    for(i = IDC_RBDIRECT; i<=IDC_RB5; i++){
        '	        j = i-IDC_RBDIRECT-1;
        '	        hwnd1 =  GetDlgItem(hwnd, i);
        '           If (j > nstd) Then
        '		        EnableWindow(hwnd1, FALSE);
        '           Else
        '               If (!IsWindowEnabled(hwnd1)) Then
        '			        EnableWindow(hwnd1, TRUE);
        '       }
        '   #End If

        '   /*if (nstd<=2){
        '	    *mode = 2;
        '       If (nstd < 2) Then
        '	        *mode = 1;
        '	    CheckRadioButton(hwnd, IDC_RBDIRECT, IDC_RBDIRECT+FIFTH_ORDER+1, IDC_RBDIRECT+*mode+1);
        '       If (nstd < 2) Then
        '	        EnableWindow(GetDlgItem(hwnd, IDC_RBDIRECT+1), FALSE);
        '   }*/
        '   if (nstd<2){
        '	    *mode = 1;
        '	    CheckRadioButton(hwnd, IDC_RBDIRECT, IDC_RBDIRECT+FIFTH_ORDER+1,IDC_RBDIRECT+*mode+1);
        '	    EnableWindow(GetDlgItem(hwnd, IDC_RBDIRECT+1), FALSE);
        '   }
        '   if (*mode>nstd)
        '	    *mode = nstd;
        '   CheckRadioButton(hwnd, IDC_RBDIRECT, IDC_RBDIRECT+FIFTH_ORDER+1,IDC_RBDIRECT+*mode+1);
        '   SetStdCurveHint(hwnd, IDC_RBDIRECT+*mode+1);
        '}

        Dim nstd, i, j As Integer

        Try
            ' Find the total no of valid standards
            nstd = gobjclsStandardGraph.GetNoValidStdConcAbs(mobjclsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection)

            If (mobjclsMethod.StandardAddition) Then    '#If STD_ADDN Then
                ''check for std add
                If (mobjclsMethod.StandardAddition) Then
                    nstd -= 1
                End If
            Else    '#Else
                If Not gobjclsStandardGraph.ZERO_PASSING Then
                    nstd -= 1
                End If
            End If  '#End If
            ''do some validation 
            rbDirect.Enabled = False
            rbRatioMethod.Enabled = False
            rbLinear.Enabled = False
            rbQuadratic.Enabled = False
            rbCubic.Enabled = False
            rb4thOrder.Enabled = False
            rb5thOrder.Enabled = False

            '#if STD_ADDN 
            'enable radio button according to calculation mode
            If (mobjclsMethod.StandardAddition) Then
                For i = clsQuantitativeData.enumCalculationMode.DIRECT To clsQuantitativeData.enumCalculationMode.FIFTH_ORDER
                    j = i - clsQuantitativeData.enumCalculationMode.DIRECT - 1
                    Select Case i
                        Case clsQuantitativeData.enumCalculationMode.DIRECT
                            If j = 1 Then
                                If rbDirect.Enabled = False Then rbDirect.Enabled = True
                            Else
                                rbDirect.Enabled = False
                            End If

                        Case clsQuantitativeData.enumCalculationMode.RATIONAL
                            If j = 1 Then
                                If rbRatioMethod.Enabled = False Then rbRatioMethod.Enabled = True
                            Else
                                rbRatioMethod.Enabled = False
                            End If

                        Case clsQuantitativeData.enumCalculationMode.LINEAR
                            If j = 1 Then
                                If rbLinear.Enabled = False Then rbLinear.Enabled = True
                            Else
                                rbLinear.Enabled = False
                            End If

                        Case clsQuantitativeData.enumCalculationMode.QUADRATIC
                            If j = 1 Then
                                If rbQuadratic.Enabled = False Then rbQuadratic.Enabled = True
                            Else
                                rbQuadratic.Enabled = False
                            End If

                        Case clsQuantitativeData.enumCalculationMode.CUBIC
                            If j = 1 Then
                                If rbCubic.Enabled = False Then rbCubic.Enabled = True
                            Else
                                rbCubic.Enabled = False
                            End If

                        Case clsQuantitativeData.enumCalculationMode.FOURTH_ORDER
                            If j = 1 Then
                                If rb4thOrder.Enabled = False Then rb4thOrder.Enabled = True
                            Else
                                rb4thOrder.Enabled = False
                            End If

                        Case clsQuantitativeData.enumCalculationMode.FIFTH_ORDER
                            If j = 1 Then
                                If rb5thOrder.Enabled = False Then rb5thOrder.Enabled = True
                            Else
                                rb5thOrder.Enabled = False
                            End If

                    End Select
                Next i

            Else
                For i = clsQuantitativeData.enumCalculationMode.DIRECT To clsQuantitativeData.enumCalculationMode.FIFTH_ORDER
                    j = i - clsQuantitativeData.enumCalculationMode.DIRECT - 1
                    Select Case i
                        Case clsQuantitativeData.enumCalculationMode.DIRECT
                            If (j > nstd) Then
                                rbDirect.Enabled = False
                            Else
                                If rbDirect.Enabled = False Then rbDirect.Enabled = True
                            End If

                        Case clsQuantitativeData.enumCalculationMode.RATIONAL
                            If (j > nstd) Then
                                rbRatioMethod.Enabled = False
                            Else
                                If rbRatioMethod.Enabled = False Then rbRatioMethod.Enabled = True
                            End If

                        Case clsQuantitativeData.enumCalculationMode.LINEAR
                            If (j > nstd) Then
                                rbLinear.Enabled = False
                            Else
                                If rbLinear.Enabled = False Then rbLinear.Enabled = True
                            End If

                        Case clsQuantitativeData.enumCalculationMode.QUADRATIC
                            If (j > nstd) Then
                                rbQuadratic.Enabled = False
                            Else
                                If rbQuadratic.Enabled = False Then rbQuadratic.Enabled = True
                            End If

                        Case clsQuantitativeData.enumCalculationMode.CUBIC
                            If (j > nstd) Then
                                rbCubic.Enabled = False
                            Else
                                If rbCubic.Enabled = False Then rbCubic.Enabled = True
                            End If

                        Case clsQuantitativeData.enumCalculationMode.FOURTH_ORDER
                            If (j > nstd) Then
                                rb4thOrder.Enabled = False
                            Else
                                If rb4thOrder.Enabled = False Then rb4thOrder.Enabled = True
                            End If

                        Case clsQuantitativeData.enumCalculationMode.FIFTH_ORDER
                            If (j > nstd) Then
                                rb5thOrder.Enabled = False
                            Else
                                If rb5thOrder.Enabled = False Then rb5thOrder.Enabled = True
                            End If
                    End Select
                Next i
            End If

            '#Else
            'For i = IDC_RBDIRECT To IDC_RB5
            '    j = i - IDC_RBDIRECT - 1
            '    hwnd1 = GetDlgItem(hwnd, i)
            '    If (j > nstd) Then
            '        EnableWindow(hwnd1, False)
            '    Else
            '        If Not (IsWindowEnabled(hwnd1)) Then
            '            EnableWindow(hwnd1, True)
            '        End If
            '    End If
            'Next i
            '#End If

            If (nstd < 2) Then
                intCalculationMode = clsQuantitativeData.enumCalculationMode.LINEAR
                rbLinear.Checked = True
                rbRatioMethod.Enabled = False
            End If

            If (intCalculationMode > nstd) Then
                intCalculationMode = nstd
            End If

            'CheckRadioButton(hwnd, IDC_RBDIRECT, IDC_RBDIRECT + FIFTH_ORDER + 1, IDC_RBDIRECT + intCalculationMode + 1)
            i = clsQuantitativeData.enumCalculationMode.DIRECT + intCalculationMode + 1
            'check check bok true according to calculation mode
            Select Case i
                Case clsQuantitativeData.enumCalculationMode.DIRECT
                    rbDirect.Checked = True

                Case clsQuantitativeData.enumCalculationMode.RATIONAL
                    rbRatioMethod.Checked = True

                Case clsQuantitativeData.enumCalculationMode.LINEAR
                    rbLinear.Checked = True

                Case clsQuantitativeData.enumCalculationMode.QUADRATIC
                    rbQuadratic.Checked = True

                Case clsQuantitativeData.enumCalculationMode.CUBIC
                    rbCubic.Checked = True

                Case clsQuantitativeData.enumCalculationMode.FOURTH_ORDER
                    rb4thOrder.Checked = True

                Case clsQuantitativeData.enumCalculationMode.FIFTH_ORDER
                    rb5thOrder.Checked = True

            End Select

            Call SetStdCurveHint(clsQuantitativeData.enumCalculationMode.DIRECT + intCalculationMode + 1)

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

    Private Sub SetStdCurveHint(ByVal intCalculationMode As clsQuantitativeData.enumCalculationMode)
        '=====================================================================
        ' Procedure Name        : SetStdCurveHint
        ' Parameters Passed     : Calculation Mode
        ' Returns               : None
        ' Purpose               : for setting a std curve hint as per a calculation mode.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        'void	SetStdCurveHint(HWND hwnd, int id)
        '{
        '	char	str[100]="";
        '	if(Method->Mode == MODE_EMISSION )
        '	{
        '            Switch(id)
        '		{
        '			case  IDC_RBDIRECT :
        '				strcpy(str," Sample caln on bracketd stds");
        '				break;

        '			case  IDC_RBRAT :
        '#If STD_ADDN Then
        '					strcpy(str," RATIO Method :\n EMN/CONC=A+B*EMN+C*EMN^2");
        '#Else
        '					strcpy(str," RATIO Method : plot emn/conc against emn");
        '#End If
        '				break;

        '			case  IDC_RBLINEAR : strcpy(str," LINEAR graph :\nCONC=A+B*EMN ");break;
        '			case  IDC_RBQUAD:		strcpy(str," QUADRATIC curve :\nCONC=A+B*EMN+C*EMN^2");break;
        '			case  IDC_RBCUBIC	 :	strcpy(str," CUBIC curve :\n CONC=A+B*EMN+C*EMN^2+D*EMN^3");break;
        '			case  IDC_RB4	 :		strcpy(str," 4th order Polynomial fit :\nCONC=A+B*EMN+C*EMN^2+D*EMN^3+E*EMN^4");break;
        '			case  IDC_RB5		 :	strcpy(str," 5th order polynomial fit :\nCONC=A+B*EMN+C*EMN^2+D*EMN^3+E*EMN^4+F*EMN^5");break;
        '		}
        '	}
        '        Else
        '	{
        '            Switch(id)
        '		{
        '			case  IDC_RBDIRECT : strcpy(str," Sample caln on bracketd stds");break;
        '			case  IDC_RBRAT :
        '#If STD_ADDN Then
        '					strcpy(str," RATIO Method :\n ABS/CONC=A+B*ABS+C*ABS^2");
        '#Else
        '					strcpy(str," RATIO Method : plot abs/conc against abs");
        '#End If
        '				break;
        '		case  IDC_RBLINEAR :	strcpy(str," LINEAR graph :\nCONC=A+B*ABS ");break;
        '		case  IDC_RBQUAD:		strcpy(str," QUADRATIC curve :\nCONC=A+B*ABS+C*ABS^2");break;
        '		case  IDC_RBCUBIC	 :	strcpy(str," CUBIC curve :\n CONC=A+B*ABS+C*ABS^2+D*ABS^3");break;
        '		case  IDC_RB4	 :		strcpy(str," 4th order Polynomial fit :\nCONC=A+B*ABS+C*ABS^2+D*ABS^3+E*ABS^4");break;
        '		case  IDC_RB5		 :	strcpy(str," 5th order polynomial fit :\nCONC=A+B*ABS+C*ABS^2+D*ABS^3+E*ABS^4+F*ABS^5");break;
        '	  }
        '  }
        '  SetDlgItemText(hwnd, IDC_THINT, str);
        '}

        Dim strCalcDescription As String

        Try
            If (mobjclsMethod.OperationMode = EnumOperationMode.MODE_EMMISSION) Then
                ''for emission mode
                'set discription according to calculation mode
                Select Case intCalculationMode
                    'check for a calculation mode.
                    Case clsQuantitativeData.enumCalculationMode.DIRECT
                        strCalcDescription = " Sample calculation on bracketd stds "

                    Case clsQuantitativeData.enumCalculationMode.RATIONAL
                        'If mobjclsMethod.StandardAddition Then
                        '    strCalcDescription = " RATIO Method :" & vbCrLf & "EMN/CONC=A+B*EMN+C*EMN^2"
                        'Else
                        '    strCalcDescription = " RATIO Method : plot emn/conc against emn"
                        'End If
                        '//----- Added by Sachin Dokhale 
                        '//---- Practically display it's worong
                        If gblnSTD_ADDN = True Then
                            strCalcDescription = " RATIO Method :" & vbCrLf & "EMN/CONC=A+B*EMN+C*EMN^2"
                        Else
                            strCalcDescription = " RATIO Method : plot emn/conc against emn"
                        End If
                        '//-----

                    Case clsQuantitativeData.enumCalculationMode.LINEAR
                        strCalcDescription = " LINEAR graph :" & vbCrLf & "CONC=A+B*EMN "

                    Case clsQuantitativeData.enumCalculationMode.QUADRATIC
                        strCalcDescription = " QUADRATIC curve :" & vbCrLf & "CONC=A+B*EMN+C*EMN^2"

                    Case clsQuantitativeData.enumCalculationMode.CUBIC
                        strCalcDescription = " CUBIC curve :" & vbCrLf & " CONC=A+B*EMN+C*EMN^2+D*EMN^3"

                    Case clsQuantitativeData.enumCalculationMode.FOURTH_ORDER
                        strCalcDescription = " 4th order Polynomial fit :" & vbCrLf & "CONC=A+B*EMN+C*EMN^2+D*EMN^3+E*EMN^4"

                    Case clsQuantitativeData.enumCalculationMode.FIFTH_ORDER
                        strCalcDescription = " 5th order polynomial fit :" & vbCrLf & "CONC=A+B*EMN+C*EMN^2+D*EMN^3+E*EMN^4+F*EMN^5"

                End Select
            Else
                Select Case intCalculationMode
                    Case clsQuantitativeData.enumCalculationMode.DIRECT
                        strCalcDescription = " Sample calculation on bracketd stds "

                    Case clsQuantitativeData.enumCalculationMode.RATIONAL

                        'If mobjclsMethod.StandardAddition Then
                        '    strCalcDescription = " RATIO Method :" & vbCrLf & " ABS/CONC=A+B*ABS+C*ABS^2"
                        'Else
                        '    strCalcDescription = " RATIO Method : plot abs/conc against abs"
                        'End If
                        '//----- Added by Sachin Dokhale '---- Practically display it's worong
                        If gblnSTD_ADDN = True Then
                            strCalcDescription = " RATIO Method :" & vbCrLf & " ABS/CONC=A+B*ABS+C*ABS^2"
                        Else
                            strCalcDescription = " RATIO Method : plot abs/conc against abs"
                        End If
                        '//-----

                    Case clsQuantitativeData.enumCalculationMode.LINEAR
                        strCalcDescription = " LINEAR graph :" & vbCrLf & " CONC=A+B*ABS "

                    Case clsQuantitativeData.enumCalculationMode.QUADRATIC
                        strCalcDescription = " QUADRATIC curve :" & vbCrLf & " CONC=A+B*ABS+C*ABS^2"

                    Case clsQuantitativeData.enumCalculationMode.CUBIC
                        strCalcDescription = " CUBIC curve :" & vbCrLf & " CONC=A+B*ABS+C*ABS^2+D*ABS^3"

                    Case clsQuantitativeData.enumCalculationMode.FOURTH_ORDER
                        strCalcDescription = " 4th order Polynomial fit :" & vbCrLf & " CONC=A+B*ABS+C*ABS^2+D*ABS^3+E*ABS^4"

                    Case clsQuantitativeData.enumCalculationMode.FIFTH_ORDER
                        strCalcDescription = " 5th order polynomial fit :" & vbCrLf & " CONC=A+B*ABS+C*ABS^2+D*ABS^3+E*ABS^4+F*ABS^5"

                End Select
            End If

            lblCalcDescription.Text = strCalcDescription

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

    Private Sub Create_Curve()
        '=====================================================================
        ' Procedure Name        : Create_Curve
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : for crearing a curve
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 18-Jan-2007 12:35 pm
        ' Revisions             : 1
        '=====================================================================


        '---- ORIGINAL CODE

        'void	Create_Curve(HWND hwnd, CURVEDATA	*Curve)
        '{
        '	double	xmax;
        '	HWND	hwd;
        '	HDC		hdc;
        '	RECT 	R;
        '	RECT 	r;
        '	int		ww; 
        '	POINT	pt1, pt2;

        '	#define	FROMLEFT    7
        '	#define	FROMTOP		0.5
        '	#define	HTRATIO		0.6

        '	if (ht==-1 && wd==-1)
        '	{
        '		hdc= GetDC(hwnd);
        '		Para_Font(hdc, TRUE, TRUE, &ht, &wd);
        '		ReleaseDC(hwnd, hdc);
        '	}

        '	GetClientRect(hwnd, &R);

        '	r.left=FROMLEFT*wd;
        '	r.right= R.right;
        '	r.right-= (FROMLEFT/2)*wd;
        '	r.top=R.top+FROMTOP*ht;
        '	r.bottom =r.top+ (R.bottom-R.top)*HTRATIO; 	//((R.bottom-R.top)-9*ht);

        '	ww = (r.bottom-r.top)*0.2;

        '	xmax=-1;
        '	Curve->RC=r;

        '	Calculate_Curve_Param(Curve);

        '	xmax= (int) Curve->Xmax;

        '	pt1.x = r.left;
        '	pt1.y = r.bottom+2*ht;
        '	pt2.x = r.right-wd; 
        '	pt2.y = pt1.y; 

        '#If STD_ADDN Then
        '		if(Method->QuantData->Param.Std_Addn)
        '			SetWindowText(hwnd, "STANDARD ADDITION [QUANTITATIVE Analysis- STANDARD WORKING GRAPH]");
        '		else
        '#End If
        '	SetWindowText(hwnd, "QUANTITATIVE Analysis - STANDARD WORKING GRAPH");

        '	hwd=CreateWindow("SCROLLBAR","",WS_CHILD|WS_VISIBLE | SBS_HORZ,
        '	pt1.x-ww/2, pt1.y, ww, 11, hwnd, IDC_HSCROL1, hInst,NULL);
        '	ShowScrollBar(hwd, SB_CTL, SW_SHOW);
        '	SetScrollRange(hwd, SB_CTL, 0, xmax,FALSE);
        '	SetScrollPos(hwd, SB_CTL, 0,  TRUE);

        '	hwd=CreateWindow("SCROLLBAR","",WS_CHILD|WS_VISIBLE | SBS_HORZ,
        '			pt2.x-ww/2, pt2.y, ww, 11, hwnd, IDC_HSCROL2,
        '			hInst,NULL);

        '	ShowScrollBar(hwd, SB_CTL, SW_SHOW);
        '	SetScrollRange(hwd, SB_CTL, 0, xmax,FALSE);
        '	SetScrollPos(hwd, SB_CTL, xmax,  TRUE);
        '	pt2.x = r.right+wd; //r.left;
        '	pt2.y = r.top-5;

        '	hwd=CreateWindow("SCROLLBAR","",WS_CHILD|WS_VISIBLE | SBS_VERT,
        '			pt2.x, pt2.y, 11, ww, hwnd, IDC_VSCROL1,
        '			hInst,NULL);

        '	ShowScrollBar(hwd, SB_CTL, SW_SHOW);
        '	SetScrollRange(hwd, SB_CTL, 0, Curve->Ymax,FALSE);
        '	SetScrollPos(hwd, SB_CTL, Curve->Ymax,  TRUE);
        '}

        Dim xmax As Double
        Const FROMLEFT = 7
        Const FROMTOP = 0.5
        Const HTRATIO = 0.6

        Try
            'HWND	hwd;
            'HDC	hdc;
            'RECT 	R;
            'RECT 	r; 
            'int	ww;
            'POINT	pt1, pt2;

            'if (ht==-1 && wd==-1)
            '{
            '	hdc= GetDC(hwnd);
            '	Para_Font(hdc, TRUE, TRUE, &ht, &wd);
            '	ReleaseDC(hwnd, hdc);
            '}
            'GetClientRect(hwnd, &R);

            'r.left = FROMLEFT * wd;
            'r.right = R.right;
            'r.right -= (FROMLEFT/2) * wd;
            'r.top = R.top+FROMTOP * ht;
            'r.bottom = r.top + (R.bottom - R.top) * HTRATIO; 	
            'ww = (r.bottom-r.top) * 0.2;

            ' Create curve on graph
            xmax = -1

            Call Calculate_Curve_Param()
            '' cal. curve parameter
            xmax = Graph.XAxisMax

            Graph.Invalidate()
            ''checking a validation.

            Graph.Refresh()
            ''refresh the graph.
            'pt1.x = r.left;
            'pt1.y = r.bottom + 2 * ht;
            'pt2.x = r.right - wd; 
            'pt2.y = pt1.y; 

            If (mobjclsMethod.StandardAddition) Then
                ''check for std add
                Me.Text = "STANDARD ADDITION [QUANTITATIVE Analysis- STANDARD WORKING GRAPH]"
            Else
                ' Me.Text = "QUANTITATIVE Analysis - STANDARD WORKING GRAPH"
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

    Private Sub CalcStdCurve()
        '=====================================================================
        ' Procedure Name        : CalcStdCurve
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : Calculate the Std Curve and the show the std and sample value
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : praveen
        '=====================================================================


        '---- ORIGINAL CODE

        'void   CalcStdCurve(HWND hwnd)
        '{
        '  Calculate_Std_Curve();
        '  ShowStdSampValues(hwnd);
        '}

        Try
            ' Calculate the Std Curve and the show the std and sample value
            Call gobjclsStandardGraph.Calculate_Std_Curve()
            Call ShowStdSampValues()

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

    Private Sub ShowStdSampValues()
        '=====================================================================
        ' Procedure Name        : ShowStdSampValues
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : for showing a std,sample value on screen.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================


        '---- ORIGINAL CODE 

        'void   ShowStdSampValues(HWND hwnd)
        '{
        '	double	conc1=0.0; 
        '	char	str1[200]="";
        '	char	str[400]="";
        '	STDDATA	*tempk;

        '	Get_Equation(str1);
        '	strcat(str, str1);

        '#If STD_ADDN Then
        '		if(Method->QuantData->Param.Std_Addn)
        '		{
        '			if( Method->QuantData->SampTopData )
        '				sprintf(str1,"Sample Conc: %5.4f\r\n",	Get_percent(Method->QuantData->SampTopData->Data.Conc,
        '										Method->QuantData->SampTopData->Data.Weight,
        '										Method->QuantData->SampTopData->Data.Volume,
        '										Method->QuantData->SampTopData->Data.Dil_Fact,
        '										Method->QuantData->Param.Unit,
        '										Method->QuantData->Param.No_Decimals));

        '			strcat(str,str1);
        '		}
        '#End If

        '	conc1=Get_Conc(0.0, 0.0); //, Method->QuantData->Param.No_Decimals);
        '#If STD_ADDN Then
        '		if(!Method->QuantData->Param.Std_Addn)
        '		{
        '#End If
        '			sprintf(str1,"(%6.3f-0.000\r\n",conc1);
        '			strcat(str, str1);
        '#If STD_ADDN Then
        '		}
        '#End If
        '	tempk = Method->QuantData->StdTopData;
        '   While (tempk)
        '	{
        '		strcpy(str1,"");
        '		conc1=Get_Conc(tempk->Data.Abs, conc1);
        '		//, Method->QuantData->Param.No_Decimals);
        '		sprintf(str1,"(%6.3f-%5.4f\r\n",conc1,tempk->Data.Abs);
        '		strcat(str, str1);
        '		tempk=tempk->next;
        '	}
        '	SetDlgItemText(hwnd, IDC_EQN, str);
        '}

        Dim conc1 As Double
        Dim strEquation As String
        Dim intCounter As Integer
        Dim strTemp As String

        Try
            ' Get the equation into the string to display it.
            Call Get_Equation(strEquation)

            '#If STD_ADDN Then
            '   if(mobjclsMethod.StandardAddition)
            '	{
            '	    if( Method->QuantData->SampTopData )
            '		    sprintf(str1,"Sample Conc: %5.4f\r\n",	Get_percent(Method->QuantData->SampTopData->Data.Conc,
            '										Method->QuantData->SampTopData->Data.Weight,
            '										Method->QuantData->SampTopData->Data.Volume,
            '										Method->QuantData->SampTopData->Data.Dil_Fact,
            '										Method->QuantData->Param.Unit,
            '										Method->QuantData->Param.No_Decimals));

            '		    strcat(str,str1);
            '	}
            '#End If
            ' To get the concentration for 1st standard
            conc1 = gobjclsStandardGraph.Get_Conc(0.0, 0.0)
            '//--- Added by Sachin Dokhale
            strTemp = ""
            strTemp &= "("
            strTemp &= Format(conc1, "0.000")
            'strTemp &= "  -  0.000)"
            strTemp &= "  -  " & Format(gobjclsStandardGraph.Get_Abs(conc1), "0.000") & ")"
            strTemp &= vbCrLf
            strEquation &= strTemp
            '//---

            '#If STD_ADDN Then
            'if(!Method->QuantData->Param.Std_Addn)
            '{
            '#End If
            '	sprintf(str1,"(%6.3f-0.000\r\n",conc1);
            '   strcat(str, str1);
            '#If STD_ADDN Then
            '}
            '#End If

            For intCounter = 0 To mobjclsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count - 1
                strTemp = ""
                conc1 = gobjclsStandardGraph.Get_Conc(mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).StandardDataCollection.item(intCounter).Abs, conc1)
                strTemp &= "("
                strTemp &= Format(conc1, "0.000")
                strTemp &= "  -  "
                strTemp &= Format(mobjclsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCounter).Abs, "0.000")
                strTemp &= ")"
                strTemp &= vbCrLf
                strEquation &= strTemp
            Next

            txtCalcProcess.Text = strEquation

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

    Private Function funcGetSelectedCalculationMode() As clsQuantitativeData.enumCalculationMode
        '=====================================================================
        ' Procedure Name        : funcGetSelectedCalculationMode
        ' Parameters Passed     : None
        ' Returns               : User Selected Mode Calculation
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 31-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        ''note:
        ''this is used for getting a selected calculation mode.
        Try
            ' Set the selected calculation mode

            If rbDirect.Checked = True Then
                Return clsQuantitativeData.enumCalculationMode.DIRECT

            ElseIf rbRatioMethod.Checked = True Then
                Return clsQuantitativeData.enumCalculationMode.RATIONAL

            ElseIf rbLinear.Checked = True Then
                Return clsQuantitativeData.enumCalculationMode.LINEAR

            ElseIf rbQuadratic.Checked = True Then
                Return clsQuantitativeData.enumCalculationMode.QUADRATIC

            ElseIf rbCubic.Checked = True Then
                Return clsQuantitativeData.enumCalculationMode.CUBIC

            ElseIf rb4thOrder.Checked = True Then
                Return clsQuantitativeData.enumCalculationMode.FOURTH_ORDER

            ElseIf rb5thOrder.Checked = True Then
                Return clsQuantitativeData.enumCalculationMode.FIFTH_ORDER

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

    Private Sub Change_Calculation_Mode(ByVal intCalculationMode As clsQuantitativeData.enumCalculationMode)
        '=====================================================================
        ' Procedure Name        : Change_Calculation_Mode
        ' Parameters Passed     : New Calculation Mode 
        ' Returns               : None
        ' Purpose               : To change and apply new Mode of Calculation
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 18-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================


        '---- ORIGINAL CODE

        'void   Change_Calculation_Mode(HWND hwnd, int *lMode)
        '{
        '	int mode;
        '	mode=  GetIndexOfRBSelection(hwnd, DIRECT+1, FIFTH_ORDER+1, IDC_RBDIRECT);
        '   If (mode! = -1) Then
        '	{
        '		mode--;
        '		if (mode!=*lMode)
        '		{
        '			Method->QuantData->cMode=mode;
        '			*lMode=mode;
        '			CalcStdCurve(hwnd);
        '			InvalidateRect(hwnd, NULL, TRUE);
        '		}
        '       Else
        '		    ShowStdSampValues(hwnd);
        '	}
        '}

        Dim intMode As clsQuantitativeData.enumCalculationMode

        Try
            ' Get the selected calculation mode
            intMode = funcGetSelectedCalculationMode()
            ' Check selected cal. mode is not DIRECT Mode
            If (intMode <> clsQuantitativeData.enumCalculationMode.DIRECT) Then
                ' set the Cal mode value to the method object
                mobjclsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).CalculationMode = intMode

                intCalculationMode = intMode
                mintCalculationMode = intCalculationMode

                Call SetStdCurveHint(intCalculationMode)
                ''for setting a std curve hint as per a calculation mode.
                Call CalcStdCurve()
                ''Calculate the Std Curve and the show the std and sample value
                Graph.AldysPane.CurveList.Clear()
                Graph.AldysPane.AxisChange()
                Graph.Invalidate()
                Call Create_Curve()
                ''for creating a curve
                Call Display_Curve()
                ''Display curve on graph
                Refresh()
                Application.DoEvents()
            ElseIf (intMode = clsQuantitativeData.enumCalculationMode.DIRECT) Then
                mobjclsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).CalculationMode = intMode
                intCalculationMode = intMode
                mintCalculationMode = intCalculationMode
                Call SetStdCurveHint(intCalculationMode)
                Call CalcStdCurve()
                Graph.AldysPane.CurveList.Clear()
                Graph.AldysPane.AxisChange()
                Graph.Invalidate()
                ''check for validation.
                Call Create_Curve()
                Call Display_Curve()
                Refresh()
                Application.DoEvents()
            Else
                Call ShowStdSampValues()
                ''for showing a std sample value on screen.
            End If
            mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).CalculationMode = intMode
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

    Private Sub Display_Curve()
        '=====================================================================
        ' Procedure Name        : Display_Curve
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : Display curve on graph
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 04-Feb-2007 03:35 pm
        ' Revisions             : 1
        '=====================================================================


        '----- ORIGINAL CODE

        'void Display_Curve(HDC hdc, CURVEDATA *Curve,  BOOL flag,BOOL scrflag,BOOL scr)
        '{
        '	HFONT	hfont;
        '	if (Curve==NULL)
        '		return;
        '	SetBkMode(hdc, TRANSPARENT);
        '	hfont = Para_Font(hdc, FALSE, scr, &ht, &wd);
        '	Rect(hdc, Curve->Xmin, Curve->Ymax, Curve->Xmax, Curve->Ymin, Curve->RC, Curve, wd, ht, scrflag);
        '	Display_Curve_Yaxis(hdc, Curve->RC, wd, ht, Curve);
        '	if (Method->Mode==MODE_EMISSION)
        '		Display_Curve_Yaxis_Divns(hdc,  Curve, "EMISSION", scrflag);
        '            Else
        '		Display_Curve_Yaxis_Divns(hdc,  Curve, "ABSORBANCE", scrflag);
        '	Display_Chart_Xaxis(hdc, Curve,  wd, ht, flag,"Concentration",scrflag);
        '	Disp_Standards(hdc, Curve, Method->QuantData->StdTopData, scrflag);
        '#If STD_ADDN Then
        '	if (SampCurve)
        '	{
        '		Disp_Samples(hdc, Curve, Method->QuantData->SampTopData, scrflag);
        '	}
        '#Else
        '   If (SampCurve) Then
        '	   Disp_Samples(hdc, Curve, Method->QuantData->SampTopData, scrflag);
        '#End If
        '	if (flag && !scrflag)
        '		Display_Legend(hdc,Curve->RC);
        '	DeleteObject(hfont);
        '}

        Try
            If IsNothing(Graph) Then
                Return
            End If

            'SetBkMode(hdc, TRANSPARENT);
            'hfont = Para_Font(hdc, FALSE, scr, &ht, &wd);
            'Rect(hdc, Curve->Xmin, Curve->Ymax, Curve->Xmax, Curve->Ymin, Curve->RC, Curve, wd, ht, scrflag);
            'Display_Curve_Yaxis(hdc, Curve->RC, wd, ht, Curve);
            'Display_Curve_Yaxis()

            If (mobjclsMethod.OperationMode = EnumOperationMode.MODE_EMMISSION) Then
                ''check for emission mode
                Graph.YAxisLabel = "EMISSION"
                mblnIsEmmissionMode = True
            Else
                Graph.YAxisLabel = "ABSORBANCE"
                mblnIsEmmissionMode = False
            End If

            '---'---added on 26.07.09 with ref ramesh/vck
            Dim intUnit As Integer = 0
            Dim strconc As String = ""
            intUnit = mobjclsMethod.AnalysisParameters.Unit
            If intUnit = enumUnit.PPM Then
                strconc = "CONCENTRATION  (ppm)"
            ElseIf intUnit = enumUnit.Percent Then
                strconc = "CONCENTRATION  (ppm)"    '---19.04.09
            ElseIf intUnit = enumUnit.PPB Then
                strconc = "CONCENTRATION  (ppb)"
            End If
            '------------

            Graph.XAxisLabel = strconc  '---added on 26.07.09 with ref ramesh/vck
            'Graph.XAxisLabel = "CONCENTRATION"  '---commented on 26.07.09 with ref ramesh/vck

            Call Disp_Standards(mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).StandardDataCollection)
            ''display Standard from standard collection object
            If mobjclsMethod.StandardAddition Then
                If (mblnIsSampleGraph) Then
                    Call Disp_Samples(mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).SampleDataCollection)
                    ''Display Sample details
                End If
            Else
                If (mblnIsSampleGraph) Then
                    Call Disp_Samples(mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).SampleDataCollection)
                    ''Display Sample details
                End If
            End If

            Graph.AldysPane.Legend.IsVisible = False
            Graph.IsShowGrid = True
            Graph.AldysPane.AxisChange()
            Graph.Invalidate()
            Invalidate(True)

            Call Graph.ShowPointInfo(mobjScatteredPointsCurve)
            ' Purpose               : To enable Point Info window to be displayed
            '                         at left click of mouse near point.
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

    Private Sub Disp_Standards(ByVal objStandardCollection As clsAnalysisStdParametersCollection)
        '=====================================================================
        ' Procedure Name        : Disp_Standards
        ' Parameters Passed     : AASGraph reference, objStandard object
        ' Returns               : None
        ' Purpose               : display Standard from standard collection object
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 04-Feb-2007 03:45 pm
        ' Revisions             : 1
        '=====================================================================


        '----- ORIGINAL CODE

        'void Disp_Standards(HDC hdc, CURVEDATA *Curve,STDDATA	*StdTop,BOOL scr)
        '{
        '	double	xmax=0.0;//, ymax=0.0;
        '	double   x1=0.0, y1=0.0; //, FrqIntv;
        '	HPEN		hpen, hold;
        '	BOOL		first;
        '	//int 		i;
        '	STDDATA	*temp;

        '	if (StdTop==NULL)
        '		return;
        '            If (scr) Then
        '		hpen =  (HPEN) CreatePen(PS_SOLID, 1, RGB(255, 255, 255));
        '            Else
        '	{
        '		hpen =  (HPEN) CreatePen(PS_SOLID, 1, RGB(0, 0, 0));
        '		SetTextColor(hdc, RGB(0, 0,0));
        '	}
        '	hold = SelectObject(hdc, hpen);
        '	first=TRUE;
        '	//i=0;
        '	x1=(double) 0.0;

        '	while(x1<=Curve->Xmax)
        '	{
        '#If QDEMO Then
        '		if (x1>4.0)
        '			y1=0;
        '#End If
        '		y1 =  Get_Abs(x1);
        '#If STD_ADDN Then
        '			if(y1 >= 0.0 )
        '			{
        '#End If
        '		if (x1>= Curve->Xmin && x1<= Curve->Xmax && y1>=Curve->Ymin && y1<= Curve->Ymax)
        '		{
        '                        If (first) Then
        '			{
        '				PlotInit(hdc, x1, y1, Curve->RC, Curve);
        '				first=FALSE;
        '			}
        '                        Else
        '				Plotg(hdc, x1, y1, Curve->RC, Curve);
        '		}
        '#If STD_ADDN Then
        '			}
        '#End If
        '		x1+= (double) ((Curve->Xmax-Curve->Xmin)/200.0) ;
        '	}
        '	//i=0;
        '	temp=StdTop;
        '	xmax=FindMaxStdConc(StdTop);
        '	//ymax=FindMaxStdAbs(StdTop);

        '                            While (temp)
        '	{
        '		y1 =  temp->Data.Abs;
        '		x1 = temp->Data.Conc;
        '		if (x1>= Curve->Xmin && x1<= Curve->Xmax)
        '		{
        '			if (!temp->Data.Used)
        '			MarkInValid(hdc, x1, y1, Curve->RC, ht,Curve, TRUE);
        '                                    Else
        '			{
        '				PlotCurveInit(hdc, x1, y1, Curve->RC, TRUE, Curve, scr, TRUE);
        '				/* ---following fn removed by sss for avoiding the display of std values on x & y axis dt 23/11/2000
        '					Display_Curve_XYaxis(hdc,  Curve->RC, Curve,
        '						x1, y1, RGB(255,0,0),  RGB(0,0,255),
        '							xmax, TRUE, scr);
        '					-------------------------------*/
        '			}
        '		}
        '		temp=temp->next;
        '	}
        '	SelectObject(hdc, hold);
        '	DeleteObject(hpen);
        '}

        Dim xmax As Double = 0.0
        Dim x1 As Double = 0.0
        Dim y1 As Double = 0.0
        Dim first As Boolean
        Dim intCounter As Integer

        Try
            If IsNothing(objStandardCollection) Then
                Return
            End If

            'If (scr) Then
            '   hpen =  (HPEN) CreatePen(PS_SOLID, 1, RGB(255, 255, 255));
            'Else
            '   hpen =  (HPEN) CreatePen(PS_SOLID, 1, RGB(0, 0, 0));
            '	SetTextColor(hdc, RGB(0, 0,0));
            'end if

            first = True
            x1 = 0.0
            '//----- added by Sachin Dokhale
            If mobjclsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).CalculationMode = clsQuantitativeData.enumCalculationMode.DIRECT Then
                'For intCounter = 0 To objStandardCollection.Count
                intCounter = 0
                If (first) And (objStandardCollection.Count > 0) Then
                    'PlotInit(hdc, x1, y1, Curve->RC, Curve)
                    y1 = 0
                    x1 = 0
                    mobjStdSampleCurve = Graph.StartOnlineGraph("Standards/Sample", Color.Black, AldysGraph.SymbolType.NoSymbol)
                    Graph.PlotPoint(mobjStdSampleCurve, x1, y1)
                    first = False
                End If

                While intCounter < objStandardCollection.Count
                    If Graph.XAxisMax = Graph.XAxisMin Then
                        Exit While
                    End If
                    If objStandardCollection.item(intCounter).Used = True Then
                        y1 = objStandardCollection.item(intCounter).Abs
                        x1 = objStandardCollection.item(intCounter).Concentration
                        'If (x1 >= Graph.AldysPane.XAxis.Min And x1 <= Graph.AldysPane.XAxis.Max And y1 >= Graph.AldysPane.YAxis.Min And y1 <= Graph.AldysPane.YAxis.Max) Then

                        'If (first) Then
                        'PlotInit(hdc, x1, y1, Curve->RC, Curve)
                        'y1 = 0
                        'x1 = 0
                        'mobjStdSampleCurve = Graph.StartOnlineGraph("Standards/Sample", Color.Black, AldysGraph.SymbolType.NoSymbol)
                        'Graph.PlotPoint(mobjStdSampleCurve, x1, y1)
                        'first = False
                        'Else
                        'Plotg(hdc, x1, y1, Curve->RC, Curve)
                        Graph.PlotPoint(mobjStdSampleCurve, x1, y1)
                        'End If
                    End If
                    intCounter += 1
                End While
                If first = False Then
                    Graph.StopOnlineGraph(mobjStdSampleCurve)
                End If
                '//-----
            Else
                While (x1 <= Graph.XAxisMax)
                    If Graph.XAxisMax = Graph.XAxisMin Then
                        Exit While
                    End If
                    'If objStandardCollection.item(intCounter).Used = True Then

                    If gstructSettings.AppMode = EnumAppMode.DemoMode Then
                        If (x1 > 4.0) Then
                            y1 = 0.0
                        End If
                    End If

                    y1 = gobjclsStandardGraph.Get_Abs(x1)

                    If mobjclsMethod.StandardAddition Then
                        If (y1 >= 0.0) Then
                            If (x1 >= Graph.AldysPane.XAxis.Min And x1 <= Graph.AldysPane.XAxis.Max And y1 >= Graph.AldysPane.YAxis.Min And y1 <= Graph.AldysPane.YAxis.Max) Then
                                If (first) Then
                                    'PlotInit(hdc, x1, y1, Curve->RC, Curve)
                                    mobjStdSampleCurve = Graph.StartOnlineGraph("Standards/Sample", Color.Black, AldysGraph.SymbolType.NoSymbol)
                                    first = False
                                Else
                                    'Plotg(hdc, x1, y1, Curve->RC, Curve)
                                    Graph.PlotPoint(mobjStdSampleCurve, x1, y1)
                                End If
                            End If
                        End If
                    Else
                        If (x1 >= Graph.AldysPane.XAxis.Min And x1 <= Graph.AldysPane.XAxis.Max And y1 >= Graph.AldysPane.YAxis.Min And y1 <= Graph.AldysPane.YAxis.Max) Then
                            If (first) Then
                                'PlotInit(hdc, x1, y1, Curve->RC, Curve)
                                mobjStdSampleCurve = Graph.StartOnlineGraph("Standards/Sample", Color.Black, AldysGraph.SymbolType.NoSymbol)
                                Graph.PlotPoint(mobjStdSampleCurve, x1, y1)
                                first = False
                            Else
                                'Plotg(hdc, x1, y1, Curve->RC, Curve)
                                If gobjclsStandardGraph.mblnSaturation = False And _
                                    gobjclsStandardGraph.Rational = True Then
                                    Graph.PlotPoint(mobjStdSampleCurve, x1, y1)
                                ElseIf (gobjclsStandardGraph.Rational = False) Then
                                    Graph.PlotPoint(mobjStdSampleCurve, x1, y1)
                                End If
                            End If
                        End If
                    End If
                    'x1 += ((Graph.XAxisMax - Graph.XAxisMin) / 200.0)
                    'x1 = Format(x1, "0.00000")

                    'If mobjclsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).CalculationMode = clsQuantitativeData.enumCalculationMode.DIRECT Then
                    '    'x1 += ((Graph.XAxisMax - Graph.XAxisMin) / xmax)
                    '    'x1 = Format(x1, "0.00000")
                    '    x1 = objStandardCollection.item(intCounter).Concentration
                    'Else
                    x1 += ((Graph.XAxisMax - Graph.XAxisMin) / 200.0)
                    x1 = Format(x1, "0.00000")


                End While
            End If
            'If first = False Then
            '    Graph.StopOnlineGraph(mobjStdSampleCurve)
            'End If

            Graph.Refresh()
            Application.DoEvents()
            ''allow application to perfrom its panding work.
            xmax = clsStandardGraph.FindMaxStdConc(objStandardCollection)

            mobjScatteredPointsCurve = Graph.StartScatteredPointsCurve(AldysGraph.SymbolType.Circle)
            first = True
            Dim IsUse_btnRemove As Boolean = True
            Dim intStdSampeCount As Integer = 0
            For intCounter = 0 To objStandardCollection.Count - 1
                If (objStandardCollection.item(intCounter).Used) = True Then
                    intStdSampeCount += 1
                End If
            Next
            If intStdSampeCount = 1 Then
                IsUse_btnRemove = False
            End If
            For intCounter = 0 To objStandardCollection.Count - 1
                y1 = objStandardCollection.item(intCounter).Abs
                x1 = objStandardCollection.item(intCounter).Concentration

                If (x1 >= Graph.AldysPane.XAxis.Min And x1 <= Graph.AldysPane.XAxis.Max) Then
                    If (objStandardCollection.item(intCounter).Used) = False Then
                        'MarkInValid(hdc, x1, y1, Curve->RC, ht,Curve, TRUE);
                        Graph.PlotScatteredPoints(mobjScatteredPointsCurve, True, objStandardCollection.item(intCounter), Nothing, mblnIsEmmissionMode, IsUse_btnRemove)
                    Else
                        'PlotCurveInit(hdc, x1, y1, Curve->RC, TRUE, Curve, scr, TRUE);
                        Graph.PlotScatteredPoints(mobjScatteredPointsCurve, False, objStandardCollection.item(intCounter), Nothing, mblnIsEmmissionMode, IsUse_btnRemove)
                    End If
                End If

            Next intCounter
            Graph.Refresh()
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
    End Sub

    Private Sub Disp_Samples(ByVal objSampleCollection As clsAnalysisSampleParametersCollection)
        '=====================================================================
        ' Procedure Name        : Disp_Samples
        ' Parameters Passed     : AASGraph reference, Sample Data Collection
        ' Returns               : None
        ' Purpose               : Display Sample details
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 04-Feb-2007 04:20 pm
        ' Revisions             : 1
        '=====================================================================


        '----- ORIGINAL CODE

        'void   Disp_Samples(HDC hdc, CURVEDATA *Curve,SAMPDATA *SampTop, BOOL scr)
        '{
        'double   x1, y1; //, FrqIntv;
        'HPEN		hpen, hold;
        'int 		i;
        'SAMPDATA	*temp;

        'if (SampTop==NULL)
        '   return;
        'If (scr) Then
        '   hpen =  (HPEN) CreatePen(PS_SOLID, 1, RGB(255, 255, 255));
        'else {
        '   hpen =  (HPEN) CreatePen(PS_SOLID, 1, RGB(0, 0, 0));
        '	SetTextColor(hdc, RGB(0, 0,0));
        '}
        'hold = SelectObject(hdc, hpen);
        'temp=SampTop;
        'i=0;
        'while(temp!=NULL){
        '   y1 =  temp->Data.Abs;
        '	x1 = temp->Data.Conc;
        '	if (x1 < Curve->Xmin || x1> Curve->Xmax ||
        '	    y1 < Curve->Ymin || y1 > Curve->Ymax || !temp->Data.Used){
        '	    y1 =  Curve->Ymin;
        '       //MarkInValid(hdc, x1, y1, Curve->RC, ht,Curve, FALSE);
        '	}
        '	else{
        '	    if (x1>= Curve->Xmin && x1<= Curve->Xmax &&
        '			y1>=Curve->Ymin && y1<= Curve->Ymax)
        '		    PlotCurveInit(hdc, x1, y1, Curve->RC, TRUE, Curve, scr, FALSE);
        '   }
        '	if (!scr){
        '	    if (x1>= Curve->Xmin && x1<= Curve->Xmax)
        '		     Printslno(hdc, temp, Curve->RC, i+1);
        '	}
        '	i++;
        '	temp=temp->next;
        '}
        'SelectObject(hdc, hold);
        'DeleteObject(hpen);
        '}

        Dim x1, y1 As Double
        Dim i As Integer

        Try
            If IsNothing(objSampleCollection) Then
                Return
            End If

            'If (scr) Then
            '   hpen =  (HPEN) CreatePen(PS_SOLID, 1, RGB(255, 255, 255));
            'else 
            '{
            '   hpen =  (HPEN) CreatePen(PS_SOLID, 1, RGB(0, 0, 0));
            '   SetTextColor(hdc, RGB(0, 0,0));
            '}

            Dim IsUse_btnRemove As Boolean = False

            i = 0

            For i = 0 To objSampleCollection.Count - 1
                y1 = objSampleCollection.item(i).Abs
                x1 = objSampleCollection.item(i).Conc

                If (x1 < Graph.AldysPane.XAxis.Min Or x1 > Graph.AldysPane.XAxis.Max Or y1 < Graph.AldysPane.YAxis.Min Or y1 > Graph.AldysPane.YAxis.Max Or Not objSampleCollection.item(i).Used) Then
                    y1 = Graph.YAxisMin
                Else
                    If (x1 >= Graph.AldysPane.XAxis.Min And x1 <= Graph.AldysPane.XAxis.Max And y1 >= Graph.AldysPane.YAxis.Min And y1 <= Graph.AldysPane.YAxis.Max) Then
                        'PlotCurveInit(hdc, x1, y1, Curve->RC, TRUE, Curve, scr, FALSE);
                        If (objSampleCollection.item(i).Used) Then
                            Graph.PlotScatteredPoints(mobjScatteredPointsCurve, False, Nothing, objSampleCollection.item(i), mblnIsEmmissionMode, IsUse_btnRemove)
                        End If
                    End If
                End If

                'if (!scr)
                '   if (x1>= Curve->Xmin && x1<= Curve->Xmax)
                '       Printslno(hdc, temp, Curve->RC, i+1)
                '   end if
                'end if
            Next i

            Graph.Refresh()
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
    End Sub

    Private Sub Get_Equation(ByRef eqn As String)
        '=====================================================================
        ' Procedure Name        : Get_Equation
        ' Parameters Passed     : Reference of equation string 
        ' Returns               : None
        ' Purpose               : get the equation from given data
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 04-Feb-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================

        '---- ORIGINAL CODE

        'E4FUNC  void	S4FUNC  Get_Equation(char eqn[200])
        '{
        '	char	str[80]="";
        '	int	i;
        '	strcpy(eqn,"");
        '   If (!Curve_Status) Then
        '		return ;
        '	for(i=0; i<N; i++)
        '	{
        '		strcpy(str,"");
        '		if (i==0)
        '		{
        '			if (MatA[i]==(double) 0.0)
        '				sprintf(str,"0 ", MatA[i]);
        '                    Else
        '				sprintf(str,"%-5.4f ", MatA[i]);
        '		}
        '		else if (i==1)
        '		{
        '			if (MatA[i]>(double)0.0)
        '				sprintf(str,"+ %-5.4f*X ",MatA[i]);
        '			else if (MatA[i]<(double)0.0)
        '				sprintf(str,"- %5.4f*X ",fabs(MatA[i]));
        '                        Else
        '				sprintf(str,"%+ 0*X ",MatA[i]);
        '		}
        '		else
        '		{
        '			if (MatA[i]>(double)0.0)
        '				sprintf(str,"+ %-5.4f*X^%-1d ", MatA[i], i);
        '			else if (MatA[i]<(double)0.0)
        '				sprintf(str,"- %-5.4f*X^%-1d ", fabs(MatA[i]), i);
        '                            Else
        '				sprintf(str,"+ 0*X^%-1d ", MatA[i], i);
        '		}
        '		if (strcmp(str,"")!=0)
        '			strcat(eqn, str);
        '	}
        '	if (strcmp(eqn,"")!=0)
        '	{
        '		strcat(eqn, "\r\n");
        '                                        Switch(N)
        '		{
        '			case 0 : 	sprintf(str, " (DIRECT) \r\n");  break;
        '			case 2  :
        '#If STD_ADDN Then
        '					if( stdaddn)
        '						sprintf(str, " (LINEAR)\t\t");
        '					else
        '#End If
        '					sprintf(str, " (LINEAR) %7.5f\r\n", err[1]);
        '				break;
        '			case 3  :
        '                                        If (rational) Then
        '					sprintf(str, " (RATIO) %7.5f\r\n", err[0]);
        '                                        Else
        '					sprintf(str, " (QUADRATIC) %7.5f\r\n", err[2]);
        '				break;

        '			case 4  : sprintf(str, " (CUBIC) %7.5f\r\n", err[3]);break;
        '			case 5  : sprintf(str, " (4th order) %7.5f\r\n", err[4]);break;
        '			case 6  : sprintf(str, " (5th order) %7.5f\r\n", err[5]);break;
        '		}
        '		strcat(eqn, str);
        '	}
        '}

        Dim str As String
        Dim i As Integer

        Try
            ' To make the equation depending upon calculation Mode
            eqn = ""

            If Not (gobjclsStandardGraph.Curve_Status) Then
                Return
            End If

            For i = 0 To gobjclsStandardGraph.N - 1
                str = ""
                If (i = 0) Then
                    If (gobjclsStandardGraph.MatA(i) = 0.0) Then
                        'sprintf(str,"0 ", MatA(i))
                        str = "0 "
                    Else
                        'sprintf(str,"%-5.4f ", MatA(i))
                        str = Format(gobjclsStandardGraph.MatA(i), "0.0000")
                    End If

                ElseIf (i = 1) Then
                    If (gobjclsStandardGraph.MatA(i) > 0.0) Then
                        'sprintf(str,"+ %-5.4f*X ",MatA[i])
                        str = "+ " & Format(gobjclsStandardGraph.MatA(i), "0.0000") & "*X"

                    ElseIf (gobjclsStandardGraph.MatA(i) < 0.0) Then
                        'sprintf(str,"- %5.4f*X ",fabs(MatA[i]))
                        str = "- " & Format(Math.Abs(gobjclsStandardGraph.MatA(i)), "0.0000") & "*X"
                    Else
                        'sprintf(str,"%+ 0*X ",MatA[i])
                        str = gobjclsStandardGraph.MatA(i) & "*X"
                    End If
                Else
                    If (gobjclsStandardGraph.MatA(i) > 0.0) Then
                        'sprintf(str,"+ %-5.4f*X^%-1d ", MatA[i], i)
                        str = "+" & Format(gobjclsStandardGraph.MatA(i), "0.0000") & "*X^-" & i

                    ElseIf (gobjclsStandardGraph.MatA(i) < 0.0) Then
                        'sprintf(str,"- %-5.4f*X^%-1d ", fabs(MatA[i]), i)
                        str = "-" & Format(Math.Abs(gobjclsStandardGraph.MatA(i)), "0.0000") & "*X^" & i
                    Else
                        'sprintf(str,"+ 0*X^%-1d ", MatA[i], i)
                        str = "+" & "0*X^" & i
                    End If
                End If
                If Not (str = "") Then
                    eqn = eqn & str
                End If
            Next

            If Not (eqn = "") Then
                'strcat(eqn, "\r\n");
                eqn = eqn & vbCrLf

                Select Case (gobjclsStandardGraph.N)
                    Case 0
                        'sprintf(str, " (DIRECT) \r\n");  
                        'break;
                        str = " (DIRECT) " & vbCrLf

                    Case 2
                        '#If STD_ADDN Then
                        '   if( stdaddn)
                        '	    sprintf(str, " (LINEAR)\t\t");
                        '	else
                        '#End If
                        '   sprintf(str, " (LINEAR) %7.5f\r\n", err[1]);
                        'break;

                        If (gobjclsStandardGraph.mblnIsStandardAddition) Then
                            'sprintf(str, " (LINEAR)\t\t");
                            str = " (LINEAR) " & vbCrLf
                        Else
                            'sprintf(str, " (LINEAR) %7.5f\r\n", err[1]);
                            str = " (LINEAR) " & Format(gobjclsStandardGraph.err(1), "0.00000") & vbCrLf
                        End If

                    Case 3
                        If (gobjclsStandardGraph.Rational) Then
                            'sprintf(str, " (RATIO) %7.5f\r\n", err[0]);
                            str = " (RATIO) " & Format(gobjclsStandardGraph.err(0), "0.00000") & vbCrLf
                        Else
                            'sprintf(str, " (QUADRATIC) %7.5f\r\n", err[2]);
                            str = " (QUADRATIC) " & Format(gobjclsStandardGraph.err(2), "0.00000") & vbCrLf
                        End If

                    Case 4
                        'sprintf(str, " (CUBIC) %7.5f\r\n", err[3]);break;
                        str = " (CUBIC) " & Format(gobjclsStandardGraph.err(3), "0.00000") & vbCrLf

                    Case 5
                        'sprintf(str, " (4th order) %7.5f\r\n", err[4]);break;
                        str = " (4th order) " & Format(gobjclsStandardGraph.err(4), "0.00000") & vbCrLf

                    Case 6
                        'sprintf(str, " (5th order) %7.5f\r\n", err[5]);break;
                        str = " (5th order) " & Format(gobjclsStandardGraph.err(5), "0.00000") & vbCrLf

                End Select

                eqn = eqn & str
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

    Private Function Calculate_Curve_Param() As Double
        '=====================================================================
        ' Procedure Name        : Calculate_Curve_Param
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : cal. curve parameter
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 31-Jan-2007 04:25 pm
        ' Revisions             : 1
        '=====================================================================


        '---- ORIGINAL CODE

        'double	Calculate_Curve_Param(CURVEDATA *Curve)
        '{
        '	double	FrqIntv=0.0, Max=0, Min=0, xmax1=0, xmin1=0,Fmin=0, Fmax=0, Fx=0;
        '	int		fn;
        '	int		tot, tot1;

        '	if (Curve==NULL)
        '		return 0.0;
        '	//Curve->nStds
        '	tot=GetTotStds(Method->QuantData->StdTopData,TRUE);
        '	//tot = Curve->nStds;
        '	xmin1=(double) 0.0; //FindMinStdAbs(Method->QuantData->StdTopData);
        '	Min= xmin1;
        '	xmax1=FindMaxStdAbs(Method->QuantData->StdTopData);
        '	Max= xmax1;

        '	if (Max==Min || Max <Min || Min>Max)
        '	{
        '		Max = 5.0;
        '		Min=0.0;
        '	}
        '	tot1=tot;

        '	FrqIntv =GetInterval(Max, Min, tot1, TRUE);
        '	fn = (int)  (Max/ FrqIntv);
        '	Fmax = (double) fn*  FrqIntv;
        '                If (Max > Fmax) Then
        '		Fmax+= FrqIntv;
        '	fn = (int)  ( Min/ FrqIntv);
        '	Fmin = (double) fn*FrqIntv;

        '                    If (Min < Fmin) Then
        '		Fmin-= FrqIntv;

        '	if (Fmin> Min&& FrqIntv!=(double) -1.0)
        '	{
        '                            While (Fmin > Min)
        '			Fmin-=FrqIntv;
        '	}
        '	if (Fmax< Max&& FrqIntv!=(double) -1.0)
        '	{
        '       While (Fmax < Max)
        '		    Fmax+=FrqIntv;
        '	}

        '	/*if (Fmin==(double) 0.0)
        '	Fmin-=FrqIntv;*/
        '	Curve->Ymin = Fmin;
        '	Curve->Ymax= Fmax;
        '	Curve->FrqIntv =FrqIntv;

        '	xmin1=(double) 0; 
        '	xmax1 = (double)  FindMaxStdConc(Method->QuantData->StdTopData);
        '	Fx =GetInterval(xmax1, xmin1, tot1, TRUE);
        '	fn = (int)  (xmax1/ Fx);
        '	Fmax = (double) fn*  Fx;
        '   If (xmax1 > Fmax) Then
        '	    Fmax+= Fx;

        '	Curve->Xmin = xmin1;
        '	Curve->Xmax = Fmax;
        '	Calculate_Xparameters(Curve);

        '	return FrqIntv;
        '}

        '	double	FrqIntv=0.0, Max=0, Min=0, xmax1=0, xmin1=0,Fmin=0, Fmax=0, Fx=0;
        Dim FrqIntv, Max, Min, xmax1, xmin1, Fmin, Fmax, Fx As Double
        Dim fn As Integer
        Dim tot, tot1 As Integer

        Try
            'calculate the Curve parameter of graph
            If IsNothing(Graph) Then
                Return 0.0
            End If

            tot = clsStandardGraph.GetTotStds(mobjclsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection, True)

            xmin1 = 0.0
            Min = xmin1
            xmax1 = clsStandardGraph.FindMaxStdAbs(mobjclsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection)
            Max = xmax1 + 0.01

            If (Max = Min) Or (Min > Max) Then
                Max = 5.0
                Min = 0.0
            End If
            tot1 = tot

            FrqIntv = gobjclsStandardGraph.GetInterval(Max, Min, tot1, True)
            fn = CInt((Max / FrqIntv))
            Fmax = CDbl(fn * FrqIntv)
            If (Max > Fmax) Then
                Fmax += FrqIntv
            End If
            fn = CInt(Min / FrqIntv)
            Fmin = CDbl(fn * FrqIntv)

            If (Min < Fmin) Then
                Fmin -= FrqIntv
            End If

            If (Fmin > Min And FrqIntv <> -1.0) Then
                While (Fmin > Min)
                    Fmin -= FrqIntv
                End While
            End If

            If (Fmax < Max And FrqIntv <> -1.0) Then
                While (Fmax < Max)
                    Fmax += FrqIntv
                End While
            End If

            Graph.YAxisMin = Fmin
            Graph.YAxisMax = Fmax
            Graph.YAxisStep = FrqIntv

            xmin1 = 0
            xmax1 = clsStandardGraph.FindMaxStdConc(mobjclsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection)
            Fx = gobjclsStandardGraph.GetInterval(xmax1, xmin1, tot1, True)
            fn = (xmax1 / Fx) + 0.5
            Fmax = CDbl(fn * Fx)

            If (xmax1 > Fmax) Then
                Fmax += Fx
            End If

            Graph.XAxisMin = xmin1
            Graph.XAxisMax = Fmax

            Call Calculate_Xparameters()

            Return FrqIntv

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

    Private Sub Calculate_Xparameters()
        '=====================================================================
        ' Procedure Name        : Calculate_Xparameters
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : Cal. X axis parameter for graph
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 31-Jan-2007 04:45 pm
        ' Revisions             : 1
        '=====================================================================


        '---- ORIGINAL CODE

        'void(Calculate_Xparameters(CURVEDATA * Curve))
        '{
        '   int	totStd;
        '   if (Curve==NULL)
        '       return;
        '   totStd = GetTotStdsInBetweenConc(Curve->Xmin, Curve->Xmax,
        '				Method->QuantData->StdTopData, FALSE);
        '   Curve->XIntv =GetInterval(Curve->Xmax, Curve->Xmin,
        '					totStd+1, TRUE);
        '}

        Dim totStd As Integer

        Try
            If IsNothing(Graph) Then
                Return
            End If

            totStd = clsStandardGraph.GetTotStdsInBetweenConc(Graph.XAxisMin, Graph.XAxisMax, mobjclsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection, False)

            Graph.XAxisStep = gobjclsStandardGraph.GetInterval(Graph.XAxisMax, Graph.XAxisMin, totStd + 1, True)

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

    Private Sub subPrintGraph()
        '=====================================================================
        ' Procedure Name        : subPrintGraph
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : Print the graph
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 31-Jan-2007 04:45 pm
        ' Revisions             : 1
        '=====================================================================
        Dim intCount, intSelectId As Integer

        ' Check for 21CFR setting
        If (gstructSettings.Enable21CFR = True) Then
            If Not funcCheckActivityAuthentication(enumActivityAuthentication.Print, gstructUserDetails.Access) Then
                Return
                Exit Sub
            End If
            If mblnIsSampleGraph Then
                gfuncInsertActivityLog(EnumModules.Print, "Print Sample Graph Accessed")
            Else
                gfuncInsertActivityLog(EnumModules.Print, "Print Standard Graph Accessed")
            End If
        End If
        'Select  Method Id from collection object
        If mblnIsAnalysisMode Then
        Else
            For intCount = 0 To gobjMethodCollection.Count - 1
                If mintSelectedMethodID = gobjMethodCollection(intCount).MethodID Then
                    intSelectId = intCount
                    mobjClsDataFileReport.MethodID = intCount
                    Exit For
                End If
            Next
        End If

        'Select  Run No from collection object
        If mblnIsAnalysisMode Then
            If mobjclsMethod.QuantitativeDataCollection.Count > 0 Then
                mintRunNumberIndex = gobjNewMethod.QuantitativeDataCollection.Count - 1
                mobjClsDataFileReport.RunNumber = gobjNewMethod.QuantitativeDataCollection(mintRunNumberIndex).RunNumber
            Else
                mintRunNumberIndex = 0
            End If
        Else
            '---For Data Files Mode
            mintRunNumberIndex = gfuncGetSelectedMethodRunNumberIndex(mobjclsMethod.MethodID, mintSelectedRunNumber)
            mobjClsDataFileReport.RunNumber = mobjclsMethod.QuantitativeDataCollection(mintRunNumberIndex).RunNumber
        End If

        mobjClsDataFileReport.DefaultFont = Me.DefaultFont

        'Graph.XAxisDateScaleFormat = AAS203.AASGraph.enumDateScaleFormat.HHMM
        Dim conc1 As Double
        Dim strEquation As String
        Dim strLinear As String
        Dim intCounter As Integer = 0
        Dim strTemp(2) As String
        Dim strTemp1(2) As String
        Dim strtmp As String
        ' Set equation for standard graph to print
        Call Get_Equation(strEquation) 'Added by pankaj on 14 Aug 07
        strTemp = strEquation.Split(vbCrLf)
        strTemp1 = lblCalcDescription.Text.Split(vbCrLf)
        If (strTemp.Length > 1) Then
            If (strTemp(1).Length > 1) Then
                strtmp = strTemp(1).Substring(1)
            End If
        End If
        'strLinear = strTemp1(0) & strtmp & vbCrLf
        strLinear = "Calibration Graph :" & strtmp & vbCrLf
        strLinear = strLinear & "Eqn (" & strTemp(0) & " )"
        strEquation = strLinear

        ' Send the data to the Print object depending upon Sample or Standard
        If mblnIsSampleGraph Then
            Call mobjClsDataFileReport.funcSampleGraphPrint(Graph, strEquation, mobjclsMethod)     'txtCalcProcess.Text.ToString
        Else
            Call mobjClsDataFileReport.funcStandardGraphPrint(Graph, strEquation, mobjclsMethod)   'txtCalcProcess.Text.ToString
        End If

    End Sub

#End Region

    
End Class
