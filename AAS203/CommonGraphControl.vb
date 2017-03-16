Option Explicit On 
Public Class CommonGraphControl
    Inherits AldysGraph.AldysGraph
    '************************************************************************************************************
    ' File Header       : CommonGraphControl
    ' File Name 		: CommonGraphControl.vb
    ' Author			: Sachin Ashtankar
    ' Date/Time			: 31-Oct-2004 03:30 PM
    ' Description		: This class is use to Plot the generlised graph
    '************************************************************************************************************
#Region " Component Designer generated code "

    Public Sub New(ByVal Container As System.ComponentModel.IContainer)
        MyClass.New()
        Try
            Container.Add(Me)
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

    Public Sub New()
        MyBase.New()
        Try


            'This call is required by the Component Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            strYAxisScale = ""

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

    'Component overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)

        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    Friend WithEvents btnUseDefaultSettings As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents btnGrid As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents CommandContextMenus As NETXP.Controls.Bars.CommandContextMenu
    Friend WithEvents btnCustomizedGraph As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents btnZoom As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents btnPeakEdit As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents btnLegends As NETXP.Controls.Bars.CommandBarButtonItem

    Friend WithEvents CommandBarSeparatorItem1 As NETXP.Controls.Bars.CommandBarSeparatorItem
    Friend WithEvents CommandBarSeparatorItem2 As NETXP.Controls.Bars.CommandBarSeparatorItem
    Friend WithEvents CommandBarSeparatorItem3 As NETXP.Controls.Bars.CommandBarSeparatorItem
    Friend WithEvents CommandBarSeparatorItem4 As NETXP.Controls.Bars.CommandBarSeparatorItem
    Friend WithEvents btnScale As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents btnPrint As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents btnPrintPreview As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents CommandBarSeparatorItem5 As NETXP.Controls.Bars.CommandBarSeparatorItem
    Friend WithEvents CommandBarSeparatorItem6 As NETXP.Controls.Bars.CommandBarSeparatorItem
    Friend WithEvents btnSelectCurve As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents btnDisablePeak As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnShowCurveLabels As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents CommandBarSeparatorItem7 As NETXP.Controls.Bars.CommandBarSeparatorItem
    Friend WithEvents btnShowXYValues As NETXP.Controls.Bars.CommandBarButtonItem

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CommonGraphControl))
        Me.CommandContextMenus = New NETXP.Controls.Bars.CommandContextMenu
        Me.btnUseDefaultSettings = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.btnCustomizedGraph = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CommandBarSeparatorItem4 = New NETXP.Controls.Bars.CommandBarSeparatorItem
        Me.btnPeakEdit = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CommandBarSeparatorItem3 = New NETXP.Controls.Bars.CommandBarSeparatorItem
        Me.btnGrid = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.btnZoom = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.btnLegends = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CommandBarSeparatorItem2 = New NETXP.Controls.Bars.CommandBarSeparatorItem
        Me.btnScale = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CommandBarSeparatorItem5 = New NETXP.Controls.Bars.CommandBarSeparatorItem
        Me.btnPrint = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.btnPrintPreview = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CommandBarSeparatorItem6 = New NETXP.Controls.Bars.CommandBarSeparatorItem
        Me.btnShowXYValues = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.btnSelectCurve = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.btnDisablePeak = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CommandBarSeparatorItem7 = New NETXP.Controls.Bars.CommandBarSeparatorItem
        Me.btnShowCurveLabels = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CommandBarSeparatorItem1 = New NETXP.Controls.Bars.CommandBarSeparatorItem
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        '
        'CustPan
        '
        Me.CustPan.Name = "CustPan"
        Me.CustPan.Size = New System.Drawing.Size(150, 120)
        Me.ToolTip1.SetToolTip(Me.CustPan, "Right click here to see various graph options.")
        '
        'CommandContextMenus
        '
        Me.CommandContextMenus.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.btnUseDefaultSettings, Me.btnCustomizedGraph, Me.CommandBarSeparatorItem4, Me.btnPeakEdit, Me.CommandBarSeparatorItem3, Me.btnGrid, Me.btnZoom, Me.btnLegends, Me.CommandBarSeparatorItem2, Me.btnScale, Me.CommandBarSeparatorItem5, Me.btnPrint, Me.btnPrintPreview, Me.CommandBarSeparatorItem6, Me.btnShowXYValues, Me.btnSelectCurve, Me.btnDisablePeak, Me.CommandBarSeparatorItem7, Me.btnShowCurveLabels})
        '
        'btnUseDefaultSettings
        '
        Me.btnUseDefaultSettings.Text = "Use Default Settings"
        '
        'btnCustomizedGraph
        '
        Me.btnCustomizedGraph.Text = "Customized Graph"
        '
        'btnPeakEdit
        '
        Me.btnPeakEdit.Text = "Peak Edit"
        Me.btnPeakEdit.Visible = False
        '
        'CommandBarSeparatorItem3
        '
        Me.CommandBarSeparatorItem3.Visible = False
        '
        'btnGrid
        '
        Me.btnGrid.Text = "Grid"
        '
        'btnZoom
        '
        Me.btnZoom.Image = CType(resources.GetObject("btnZoom.Image"), System.Drawing.Image)
        Me.btnZoom.Text = "Zoom"
        '
        'btnLegends
        '
        Me.btnLegends.Image = CType(resources.GetObject("btnLegends.Image"), System.Drawing.Image)
        Me.btnLegends.Text = "Legends"
        '
        'btnScale
        '
        Me.btnScale.Image = CType(resources.GetObject("btnScale.Image"), System.Drawing.Image)
        Me.btnScale.Text = "Scale"
        '
        'btnPrint
        '
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.Text = "Print"
        Me.btnPrint.Visible = False
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.Text = "Print Preview"
        Me.btnPrintPreview.Visible = False
        '
        'CommandBarSeparatorItem6
        '
        Me.CommandBarSeparatorItem6.Visible = False
        '
        'btnShowXYValues
        '
        Me.btnShowXYValues.ShowText = True
        Me.btnShowXYValues.Text = "Show X,Y Values"
        '
        'btnSelectCurve
        '
        Me.btnSelectCurve.Image = CType(resources.GetObject("btnSelectCurve.Image"), System.Drawing.Image)
        Me.btnSelectCurve.Text = "Peak Curve"
        Me.btnSelectCurve.Visible = False
        '
        'btnDisablePeak
        '
        Me.btnDisablePeak.Text = "Disable Peak"
        Me.btnDisablePeak.Visible = False
        '
        'btnShowCurveLabels
        '
        Me.btnShowCurveLabels.ShowText = True
        Me.btnShowCurveLabels.Text = "Show Curve Labels"
        '
        'CommonGraphControl
        '
        Me.Name = "CommonGraphControl"
        Me.Size = New System.Drawing.Size(150, 120)

    End Sub

#End Region

#Region " Event Declaration "

    Public Event RestoreOrignalGraph(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Public Event RestoreOrignalSettings(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Public Event SetChangedSettings(ByVal sender As System.Object, ByVal e As System.EventArgs)

#End Region

#Region " Private Variables & Constants "

    Private objBeforeZoomGraph As AldysGraph.AldysPane
    Private blnShowRainBowBand As Boolean = False
    Private curve As AldysGraph.CurveItem       ' A CurveItem type object to Plot the Curve on the Graph Rect

    Private strYAxisScale As String             ' A String Type variable to store Scale to Y Axis i.e Reflectance, K/S, LOG(K/S)
    Private dtGraphData As DataTable            ' A Data Table type object to get X and Y coordinates for the calling function

    Private Const LOGKS As String = "LOG(K/S)"
    Private Const KS As String = "K/S"
    Private Const RFL As String = "REFLECTANCE"

    Private Const Y_LOGKS_AXIS_MIN As Double = -4.0
    Private Const Y_LOGKS_AXIS_MAX As Double = 2.0
    Private Const Y_LOGKS_AXIS_MINIOR_STEP As Double = 0.25
    Private Const Y_LOGKS_AXIS_STEP As Double = 1

    Private Const Y_KS_AXIS_MIN As Double = 0
    Private Const Y_KS_AXIS_MAX As Double = 25
    Private Const Y_KS_AXIS_MINIOR_STEP As Double = 1
    Private Const Y_KS_AXIS_STEP As Double = 5

    Private Const Y_RFL_AXIS_MIN As Double = 0
    Private Const Y_RFL_AXIS_MAX As Double = 100
    Private Const Y_RFL_AXIS_MINIOR_STEP As Double = 2
    Private Const Y_RFL_AXIS_STEP As Double = 10

    Private Const X_AXIS_MINOR_STEP As Double = 25
    Private Const X_AXIS_STEP As Double = 100

    Private Const X_AXIS_TITLE As String = "Wavelength(nm)"

    Private bToggleGraph As Boolean
    Private intGraphLeft As Integer
    Private intGraphWidth As Integer
    Private intGraphHeight As Integer
    Private intGraphTop As Integer

    'Private enumGraphSettings As New GraphSettings
    'Private enumGraphConstants As GraphSettings
    Private colSettings As New Hashtable
    'Private objClsQAGeneral As New clsQAGeneral
    Private objDefaultSettings As New AldysGraph.Defaults
    Private blnUseDefaultSettings As Boolean = True
    Private intICurveCounter As Integer = 0
    'Private objIniFileOperations As New clsIniFIleReadWrite
    Private frmName As String = "GeneralForm"
    Dim strSettings As String = ""
    'Dim strIniFilePath As String = Application.StartupPath & ConstGraphSettingsINIFileName

#End Region

#Region " Properties "

    'Sets the Scale for Y-Axis
    Public Property YScale() As String
        Get
            Return strYAxisScale
        End Get
        Set(ByVal Value As String)
            strYAxisScale = Value
        End Set
    End Property
    'Sets the Data Table to extract X and Y coordinates
    Public Property GraphDataSource() As DataTable
        Get
            Return dtGraphData
        End Get
        Set(ByVal Value As DataTable)
            dtGraphData = Value
        End Set
    End Property

    Friend Property CustomizedGraphSettings() As Hashtable
        Get
            Return colSettings
        End Get
        Set(ByVal Value As Hashtable)
            colSettings = Value
        End Set
    End Property

    Public Property UseDefaultSettings() As Boolean
        Get
            Return blnUseDefaultSettings
        End Get
        Set(ByVal Value As Boolean)
            blnUseDefaultSettings = Value
        End Set
    End Property

    Public Property ParentFormName() As String
        Get
            Return (frmName)
        End Get
        Set(ByVal Value As String)
            frmName = Value
        End Set
    End Property

#End Region

#Region " Private Functions "

    Private Function AddHandlers() As Boolean
        AddHandler AldysGraph.AldysGraph.StatusEvent, AddressOf CommonGraphControl_StatusEvent
        'AddHandler btnCustomizedGraph.Click, AddressOf submnuCustomize_Click
        AddHandler btnGrid.Click, AddressOf submnuGrid_Click
        AddHandler btnPeakEdit.Click, AddressOf submnuPeakEdit_Click
        AddHandler btnPrint.Click, AddressOf submnuPrint_Click
        AddHandler btnPrintPreview.Click, AddressOf submnuPrintPreview_Click
        AddHandler btnZoom.Click, AddressOf submnuZoom_Click
        AddHandler btnUseDefaultSettings.Click, AddressOf submnuUseDefaultSettings_Click
        'AddHandler btnScale.Click, AddressOf submnuScale_Click
        AddHandler btnLegends.Click, AddressOf mnuLegends_Click
        AddHandler btnDisablePeak.Click, AddressOf btnDisablePeak_Click
        AddHandler btnShowCurveLabels.Click, AddressOf btnShowCurveLabels_Click
        'AddHandler Me.OnAxisChange, AddressOf LoadRainBowBand
        AddHandler btnShowXYValues.Click, AddressOf btnShowXYValues_Click
        'AddHandler Me.CustPaneMouseDown, AddressOf CommonGraphControl_MouseDown

        'AddHandler Me.MouseDown, AddressOf Me_MouseDown
        'AddHandler CustPane.MouseDown, AddressOf CommonGraphControl_MouseDown
    End Function

    'Public Sub LoadRainBowBand()
    '    Dim RainBowBand As New RainbowBand.RainbowColorBand
    '    Dim ctrlRainBoBand As New RainbowBand.RainbowColorBand
    '    Try
    '        For Each ctrlRainBoBand In Me.CustPan.Controls
    '            ctrlRainBoBand.Dispose()
    '        Next

    '        RainBowBand.Location = New Point(Me.AldysPane.AxisRect.X, Me.AldysPane.AxisRect.Bottom)
    '        'RainBowBand.Location = New Point(Me.AldysPane.AxisRect.X, Me.AldysPane.AxisRect.Bottom + 48)
    '        RainBowBand.Width = Me.AldysPane.AxisRect.Width
    '        RainBowBand.Height = 8
    '        RainBowBand.MaxWavelength = Me.AldysPane.XAxis.Max
    '        RainBowBand.MinWavelength = Me.AldysPane.XAxis.Min
    '        If Me.AldysPane.XAxis.Max > 0 And Me.AldysPane.XAxis.Min > 0 Then
    '            RainBowBand.RGBData = gobjComputation.GetRainbowColors(Me.AldysPane.XAxis.Min, Me.AldysPane.XAxis.Max, 1)
    '            RainBowBand.ShowColorBand()
    '            Me.CustPan.Controls.Add(RainBowBand)
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

    'Private Function FillHashTableFromINIFile() As Boolean

    '    Dim strKey As String = ""
    '    Try

    '        colSettings.Clear()
    '        For Each strKey In enumGraphConstants.GetNames(GetType(GraphSettings))
    '            colSettings.Add(Trim(UCase(strKey)), objIniFileOperations.GetFromINI(UCase(frmName), UCase(strKey), ConstCheckStar))
    '        Next
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
    'End Function

#End Region

#Region " Component Events "

    Private Sub CommonGraphControl_CustPaneMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.CustPaneMouseDown
        Try
            btnGrid.Checked = AldysPane.XAxis.IsShowGrid
            btnLegends.Checked = AldysPane.Legend.IsVisible
            btnUseDefaultSettings.Checked = blnUseDefaultSettings
            If blnUseDefaultSettings = True Then
                btnCustomizedGraph.Checked = False
            Else
                btnCustomizedGraph.Checked = True
            End If

            If btnZoom.Checked = True Then
                btnShowCurveLabels.Visible = False
                'btnSelectCurve.Visible = False
                'btnDisablePeak.Visible = False
                'CommandBarSeparatorItem6.Visible = False
                'CommandBarSeparatorItem7.Visible = False
            Else
                btnShowCurveLabels.Visible = True
                'btnSelectCurve.Visible = True
                'btnDisablePeak.Visible = True
                'CommandBarSeparatorItem6.Visible = True
                'CommandBarSeparatorItem7.Visible = True
            End If

            'If Me.AldysPane.CurveList.Count > 0 Then
            '    Me.btnSelectCurve.Visible = True
            '    Me.btnDisablePeak.Visible = True

            '    If btnZoom.Checked = True Then
            '        btnSelectCurve.Visible = False
            '        btnDisablePeak.Visible = False
            '        CommandBarSeparatorItem6.Visible = False
            '        CommandBarSeparatorItem7.Visible = False
            '    Else
            '        btnSelectCurve.Visible = True
            '        btnDisablePeak.Visible = True
            '        CommandBarSeparatorItem6.Visible = True
            '        CommandBarSeparatorItem7.Visible = True
            '    End If

            '    intICurveCounter = 0
            '    Dim btnCurves(Me.AldysPane.CurveList.Count - 1) As NETXP.Controls.Bars.CommandBarButtonItem
            '    For Each curve In Me.AldysPane.CurveList

            '        btnCurves(intICurveCounter) = New NETXP.Controls.Bars.CommandBarButtonItem

            '        If Len(curve.Label) > 0 Then
            '            btnCurves(intICurveCounter).Text = curve.Label
            '        Else
            '            btnCurves(intICurveCounter).Text = "Curve : " & intICurveCounter + 1
            '        End If

            '        btnCurves(intICurveCounter).Tag = intICurveCounter
            '        AddHandler btnCurves(intICurveCounter).Click, AddressOf Curve_Click
            '        intICurveCounter += 1
            '    Next

            '    Me.btnSelectCurve.Items.Clear()

            '    Me.btnSelectCurve.Items.AddRange(btnCurves)
            'Else
            '    Me.btnSelectCurve.Visible = False
            '    Me.btnDisablePeak.Visible = False
            'End If

            If e.Button = MouseButtons.Right Then
                Dim pos As New Point
                pos.X = e.X
                pos.Y = e.Y
                CommandContextMenus.Animate = True
                CommandContextMenus.Show(Me, pos)
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

    'Private Sub submnuCustomize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim bSuccess As Boolean = False
    '    Try
    '        Dim frmGraphCust As New frmGraphCustmization(Me.AldysPane.Clone())
    '        '---Set the Graph type
    '        frmGraphCust.BackColor1 = Me.CustPan.BackColor
    '        frmGraphCust.BackColor2 = Me.CustPan.BackColor2
    '        frmGraphCust.GraphType = frmName 'ConstGraphTypeCommonGraphControl
    '        If frmGraphCust.ShowDialog() = (DialogResult.OK) Then
    '            Me.colSettings = frmGraphCust.colSettings.Clone()
    '            frmGraphCust.Close()
    '            btnCustomizedGraph.Checked = True
    '            btnUseDefaultSettings.Checked = False
    '            blnUseDefaultSettings = False
    '            bSuccess = objIniFileOperations.WriteToINI(UCase(frmName), ConstUseDefaultSettings, "False")
    '            Call SetCustomizedSettingsToGraph()
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

    Private Sub submnuZoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            btnZoom.Checked = Not (btnZoom.Checked)

            If btnZoom.Checked = True Then
                Me.Zoom = True

                If btnShowCurveLabels.Checked = True Then
                    Call RemoveCurveLabels()
                    btnShowCurveLabels.Checked = False
                End If

                blnShowRainBowBand = Me.blnShowRainboBand
                objBeforeZoomGraph = Me.AldysPane.Clone()
            Else
                Me.Zoom = False
                Me.AldysPane = objBeforeZoomGraph.Clone()


                If blnShowRainBowBand = True Then
                    'Call LoadRainBowBand()
                End If
                Me.AldysPane.AxisChange()
                Me.Invalidate()

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

    Private Sub submnuPeakEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            btnPeakEdit.Checked = Not (btnPeakEdit.Checked)

            If btnPeakEdit.Checked = True Then
                'Dim frmPeakEdit As New frmSelectPeakEdit
                Dim curve As AldysGraph.CurveItem
                Dim dtCurveNames As New DataTable
                Dim dtRow As DataRow

                dtCurveNames.Columns.Add("CurveIndex")
                dtCurveNames.Columns.Add("CurveName")


                intICurveCounter = 0

                For Each curve In Me.AldysPane.CurveList

                    dtRow = dtCurveNames.NewRow
                    dtRow("CurveIndex") = intICurveCounter

                    If Len(curve.Label) > 0 Then
                        dtRow("CurveName") = curve.Label
                    Else
                        dtRow("CurveName") = "Curve : " & intICurveCounter + 1
                    End If

                    dtCurveNames.Rows.Add(dtRow)


                    intICurveCounter += 1
                Next

                'frmPeakEdit.CurveTable = dtCurveNames

                Me.trackBarColor = Color.WhiteSmoke


                Me.peakLineWidth = 1
                intICurveCounter = 0

                Dim pos As New Point
                pos.X = MousePosition.X
                pos.Y = MousePosition.Y
                'frmPeakEdit.Location = pos
                'frmPeakEdit.Name = Me.Name

                Me.pXYFont.IsFramed = True
                Me.pXYFont.Size = 14
                'If frmPeakEdit.ShowDialog(Me) = DialogResult.OK Then
                '    intICurveCounter = CInt(frmPeakEdit.cmbCurveName.SelectedValue)
                '    Me.peakLineColor = Me.AldysPane.CurveList.Item(intICurveCounter).Line.Color()
                '    Me.ShowXYPeak = True
                '    Me.EnablePeakTrace(intICurveCounter, True)
                '    frmPeakEdit.Dispose()
                'Else
                '    Me.peakLineColor = Me.AldysPane.CurveList.Item(intICurveCounter).Line.Color()
                '    Me.ShowXYPeak = True
                '    Me.EnablePeakTrace(intICurveCounter, True)
                '    frmPeakEdit.Dispose()
                'End If
                dtCurveNames.Dispose()
                dtRow = Nothing
            Else
                Me.EnablePeakTrace(intICurveCounter, False)

                Me.Invalidate()
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

    'Private Sub submnuScale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim frmScale As New frmGraphScale
    '    Try
    '        ''17.03.06 deepak 
    '        'frmScale.NVXMin.MinimumRange = 300
    '        'frmScale.NVXMin.MaximumRange = 1100
    '        'frmScale.NVXMax.MinimumRange = 300
    '        'frmScale.NVXMax.MaximumRange = 1100
    '        'frmScale.NVYMin.MinimumRange = 0
    '        'frmScale.NVYMin.MaximumRange = 100
    '        'frmScale.NVYMax.MinimumRange = 0
    '        'frmScale.NVYMax.MaximumRange = 100
    '        ''17.03.06 deepak 

    '        frmScale.NVXMin.Text = AldysPane.XAxis.Min
    '        frmScale.NVXMax.Text = AldysPane.XAxis.Max

    '        frmScale.NVYMin.Text = AldysPane.YAxis.Min
    '        frmScale.NVYMax.Text = AldysPane.YAxis.Max

    '        If AldysPane.XAxis.Title = X_AXIS_TITLE Then
    '            frmScale.XAxisWavelength = True
    '        Else
    '            frmScale.XAxisWavelength = False
    '        End If

    '        If frmScale.ShowDialog(Me) = DialogResult.OK Then
    '            AldysPane.XAxis.Min = CDbl(frmScale.NVXMin.Text)
    '            AldysPane.XAxis.Max = CDbl(frmScale.NVXMax.Text)
    '            AldysPane.YAxis.Min = CDbl(frmScale.NVYMin.Text)
    '            AldysPane.YAxis.Max = CDbl(frmScale.NVYMax.Text)

    '            AldysPane.XAxis.MinorStepAuto = True
    '            AldysPane.XAxis.StepAuto = True
    '            AldysPane.YAxis.MinorStepAuto = True
    '            AldysPane.YAxis.StepAuto = True

    '            frmScale.Close()
    '            AldysPane.AxisChange()
    '            Me.Invalidate()
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

    Private Sub submnuPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call Me.PrintPreViewGraph()
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

    Private Sub submnuPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call Me.PrintGraph()

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

    Private Sub submnuGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            btnGrid.Checked = Not (btnGrid.Checked)
            AldysPane.XAxis.IsShowGrid = btnGrid.Checked
            AldysPane.YAxis.IsShowGrid = btnGrid.Checked
            AldysPane.AxisChange()
            Me.Invalidate()
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

    Private Sub mnuLegends_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            btnLegends.Checked = Not (btnLegends.Checked)
            AldysPane.Legend.IsVisible = btnLegends.Checked
            AldysPane.AxisChange()
            Me.Invalidate()
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

    Private Sub submnuUseDefaultSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim bSuccess As Boolean = False
        Try
            btnCustomizedGraph.Checked = False
            btnUseDefaultSettings.Checked = True
            blnUseDefaultSettings = True
            Call SetDefaultSettingsToGraph()
            AldysPane.AxisChange()
            Me.Invalidate()
            'bSuccess = objIniFileOperations.WriteToINI(UCase(frmName), ConstUseDefaultSettings, "True")
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

    Private Sub CommonGraphControl_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.DoubleClick
        If bToggleGraph = False Then
            Me.Top = 0
            Me.Left = 0
            Me.Width = Parent.Width
            Me.Height = Parent.Height
            bToggleGraph = True
        Else
            Me.Left = intGraphLeft
            Me.Height = intGraphHeight
            Me.Width = intGraphWidth
            Me.Top = intGraphTop
            bToggleGraph = False
        End If
    End Sub

    Private Sub CommonGraphControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Call AddHandlers()

            Me.SettingsChanged()

            If Not (Me.ParentForm) Is Nothing Then
                frmName = Me.ParentForm.Name
            Else
                frmName = Me.Parent.Parent.Name
            End If

            'objIniFileOperations.INIFileName = strIniFilePath

            'strSettings = objIniFileOperations.GetFromINI(UCase(frmName), ConstUseDefaultSettings, ConstCheckStar)

            'If strSettings <> ConstCheckStar Then
            '    If UCase(strSettings) = UCase("True") Then
            '        UseDefaultSettings = True
            '    Else
            '        UseDefaultSettings = False
            '        Call FillHashTableFromINIFile()
            '        Call SetCustomizedSettingsToGraph()
            '    End If
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

    Private Sub CommonGraphControl_StatusEvent(ByVal o As System.Object, ByVal e As AldysGraph.CurveStatus)

    End Sub

    Private Sub CommonGraphControl_peakEvent(ByVal o As Object, ByVal e As AldysGraph.PeakEditArgs) Handles MyBase.peakEvent
        Try
            'AldysPane.XAxis.Title = "X : " & CStr(e.X) & "  Y : " & CStr(e.Y)
            'Me.Invalidate()
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

    Private Sub btnDisablePeak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Me.btnSelectCurve.Checked = True Then
                If blnShowRainBowBand = True Then
                    Me.blnShowRainboBand = True
                    blnShowRainBowBand = False
                End If
                Me.EnablePeakTrace(Me.AldysPane.peakCurveIndex, False)
                Me.btnSelectCurve.Checked = False
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

    Private Sub Curve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Me.blnShowRainboBand = True Then
                blnShowRainBowBand = True
                Me.blnShowRainboBand = False
            End If
            Me.btnSelectCurve.Checked = True
            Me.trackBarColor = Color.Gainsboro
            Me.peakLineColor = Me.AldysPane.CurveList.Item(CInt(sender.Tag)).Line.Color()
            Me.ShowXYPeak = True
            Me.EnablePeakTrace(CInt(sender.Tag), True)
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

    Private Sub btnShowCurveLabels_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            btnShowCurveLabels.Checked = Not (btnShowCurveLabels.Checked)

            If btnShowCurveLabels.Checked = True Then
                Me.AldysPane.ShowCurveLabels = True
                Me.AldysPane.DrawCurveLabels()
                Me.Invalidate()
            Else
                Me.AldysPane.ShowCurveLabels = False
                Call RemoveCurveLabels()
                Me.Invalidate()
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

    Private Sub btnShowXYValues_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            btnShowXYValues.Checked = Not (btnShowXYValues.Checked)

            If btnShowXYValues.Checked = True Then
                Me.ShowXYValues = True
            Else
                Me.ShowXYValues = False
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

#End Region

#Region " Functions "

    Private Function RemoveCurveLabels() As Boolean
        Dim intTextCount As Integer = 0
        Dim curve As AldysGraph.CurveItem
        Try
            For Each curve In Me.AldysPane.CurveList
                If Not curve.LabelX Is Nothing Then
                    curve.Label = curve.LabelX
                End If
            Next


            For intTextCount = 0 To Me.AldysPane.TextList.Count - 1
                If Me.AldysPane.TextList.Item(intTextCount).ForCurveLabel = True Then
                    Me.AldysPane.TextList.Remove(intTextCount)
                    intTextCount -= 1
                    If Me.AldysPane.TextList.Count = 0 Then Exit For

                End If
            Next

            Me.AldysPane.AxisChange()
            Me.Invalidate()


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

    Public Function ToggleGrid() As Boolean
        '=====================================================================
        ' Procedure Name        : ToggleGrid
        ' Parameters Passed     : Nothing
        ' Returns               : Nothing
        ' Purpose               : To Show the grid on the graph
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Ashtankar
        ' Created               : 01-Nov-2004 03:30 PM
        ' Revisions             : 
        '=====================================================================
        Try
            Me.AldysPane.YAxis.IsShowGrid = Not (Me.AldysPane.YAxis.IsShowGrid)
            'Me.AldysPane.YAxis.GridColor = Color.CornflowerBlue
            Me.AldysPane.XAxis.IsShowGrid = Not (Me.AldysPane.XAxis.IsShowGrid)
            'Me.AldysPane.XAxis.GridColor = Color.CornflowerBlue
            Me.AldysPane.AxisChange()

            Me.Invalidate()
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

    Public Function PlotGraph() As Boolean
        '=====================================================================
        ' Procedure Name        : PlotGraph
        ' Parameters Passed     : Nothing
        ' Returns               : True if graph plotted successfully else False
        ' Purpose               : To Plot the Graph according to the specification
        ' Description           : 
        ' Assumptions           : DataTable to extract X and Y coordinates should available
        '                         Y-Axis Scale should be available   
        ' Dependencies          : 
        ' Author                : Sachin Ashtankar
        ' Created               : 31-Oct-2004 04:20 PM
        ' Revisions             : 
        '=====================================================================
        Dim intICounter As Integer = 0
        Dim intJCounter As Integer = 0

        Try
            Dim dblArrXCoordinates As New ArrayList       ' A Double Type array to Store X-Coordinates to be plotted

            '---Clear the Items in the Curve List
            Me.AldysPane.CurveList.Clear()
            Me.AldysPane.TextList.Clear()

            '---Extract the value of X-Coordinates into a double type array
            If dtGraphData.Rows.Count() > 0 Then
                For intICounter = 0 To dtGraphData.Rows.Count() - 1
                    dblArrXCoordinates.Add(CDbl(dtGraphData.Rows.Item(intICounter).Item(0)))
                Next
            End If

            '---Set the Properties of X-Axis
            Me.AldysPane.XAxis.Type = AldysGraph.AxisType.Linear
            Me.AldysPane.XAxis.Title = X_AXIS_TITLE
            Me.AldysPane.XAxis.MaxAuto = False
            Me.AldysPane.XAxis.MinAuto = False
            Me.AldysPane.XAxis.StepAuto = False
            Me.AldysPane.XAxis.MinorStepAuto = False
            Me.AldysPane.XAxis.Min = CInt(dtGraphData.Rows.Item(0).Item(0) & "")
            Me.AldysPane.XAxis.Max = CInt(dtGraphData.Rows.Item(dtGraphData.Rows.Count() - 1).Item(0) & "")
            Me.AldysPane.XAxis.MinorStep = X_AXIS_MINOR_STEP
            Me.AldysPane.XAxis.Step = X_AXIS_STEP

            '---Set the Properties of Y-Axis
            Me.AldysPane.YAxis.MaxAuto = False
            Me.AldysPane.YAxis.MinAuto = False
            Me.AldysPane.YAxis.StepAuto = False
            Me.AldysPane.YAxis.MinorStepAuto = False

            'If UCase(strYAxisScale.ToString) = LOGKS Or UCase(strYAxisScale.ToString) = constLOGABS Then
            '    Me.AldysPane.YAxis.Type = AldysGraph.AxisType.Linear
            '    Me.AldysPane.YAxis.Min = Y_LOGKS_AXIS_MIN
            '    Me.AldysPane.YAxis.Max = Y_LOGKS_AXIS_MAX
            '    Me.AldysPane.YAxis.MinorStep = Y_LOGKS_AXIS_MINIOR_STEP
            '    Me.AldysPane.YAxis.Step = Y_LOGKS_AXIS_STEP
            'ElseIf UCase(strYAxisScale.ToString) = KS Or UCase(strYAxisScale.ToString) = constABS Then
            '    Me.AldysPane.YAxis.Type = AldysGraph.AxisType.Linear
            '    Me.AldysPane.YAxis.Min = Y_KS_AXIS_MIN
            '    Me.AldysPane.YAxis.Max = Y_KS_AXIS_MAX
            '    Me.AldysPane.YAxis.MinorStep = Y_KS_AXIS_MINIOR_STEP
            '    Me.AldysPane.YAxis.Step = Y_KS_AXIS_STEP
            'ElseIf UCase(strYAxisScale.ToString) = RFL Or UCase(strYAxisScale.ToString) = constTRANS Then
            '    Me.AldysPane.YAxis.Type = AldysGraph.AxisType.Linear
            '    Me.AldysPane.YAxis.Min = Y_RFL_AXIS_MIN
            '    Me.AldysPane.YAxis.Max = Y_RFL_AXIS_MAX
            '    Me.AldysPane.YAxis.MinorStep = Y_RFL_AXIS_MINIOR_STEP
            '    Me.AldysPane.YAxis.Step = Y_RFL_AXIS_STEP
            'Else
            Me.AldysPane.YAxis.Type = AldysGraph.AxisType.Linear
            Me.AldysPane.YAxis.Min = Y_RFL_AXIS_MIN
            Me.AldysPane.YAxis.Max = Y_RFL_AXIS_MAX
            Me.AldysPane.YAxis.MinorStep = Y_RFL_AXIS_MINIOR_STEP
            Me.AldysPane.YAxis.Step = Y_RFL_AXIS_STEP
            'End If


            Me.AldysPane.YAxis.Title = strYAxisScale

            '---Draw the curve on the Graph Rect X Coordinates as Wavelength and Y coordinates as Rfl, K/S, Log K/S
            If dtGraphData.Columns.Count > 0 Then
                For intICounter = 1 To dtGraphData.Columns.Count() - 1
                    Dim dblArrYCoordinates As New ArrayList       '---A Double Type array to Store Y-Coordinates to be plotted
                    '---Extract the value of Y-Coordinates into a double type array for different Batch
                    If dtGraphData.Rows.Count() > 0 Then
                        For intJCounter = 0 To dtGraphData.Rows.Count() - 1
                            dblArrYCoordinates.Add(CDbl(dtGraphData.Rows.Item(intJCounter).Item(intICounter) & ""))
                        Next
                    End If

                    '---Add the Curve in Curve List
                    curve = Me.AldysPane.AddCurve(CStr(dtGraphData.Columns.Item(intICounter).ColumnName) & "", dblArrXCoordinates, dblArrYCoordinates, GetColor(intICounter - 1), AldysGraph.SymbolType.NoSymbol)
                    curve.Line.Style = Drawing2D.DashStyle.Solid
                Next
            End If

            '---Set the Properties of graph
            If blnUseDefaultSettings = True Then
                Call SetDefaultSettingsToGraph()
            Else
                'Call SetCustomizedSettingsToGraph()
            End If

            Me.AldysPane.Title = "" '---strYAxisScale & " Vs " & X_AXIS_TITLE

            'AldysPane.Legend.IsVisible = False
            Me.AldysPane.YAxis.LowerAlarmLine = True
            Me.AldysPane.YAxis.LowerAlarmLineY = 0.0F
            Me.AldysPane.YAxis.LowerAlarmLineColor = Color.Black

            btnShowCurveLabels.Checked = False
            btnZoom.Checked = False

            '---Force the Graph control to Draw according to the Change in Specification
            Me.AldysPane.AxisChange()
            Me.Invalidate()
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

    Public Function GetColor(ByVal intColorNo As Integer) As Color
        '=====================================================================
        ' Procedure Name        : GetColor
        ' Parameters Passed     : intColorNo As Color No
        ' Returns               : Color
        ' Purpose               : To Get the multiple color while adding curve
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Ashtankar
        ' Created               : 01-Nov-2004 09:00 PM
        ' Revisions             : 
        '=====================================================================
        Select Case intColorNo
            Case 0
                Return Color.Black
            Case 1
                Return Color.Red
            Case 2
                Return Color.Blue
            Case 3
                Return Color.Green
            Case 4
                Return Color.YellowGreen
            Case 5
                Return Color.Brown
            Case 6
                Return Color.Pink
            Case 7
                Return Color.Purple
            Case 8
                Return Color.OrangeRed
            Case 9
                Return Color.Maroon
            Case 10
                Return Color.CadetBlue
            Case 11
                Return Color.Chocolate
            Case 11
                Return Color.CornflowerBlue
            Case 12
                Return Color.DarkBlue
            Case 13
                Return Color.DarkMagenta
            Case 14
                Return Color.DarkOrange
            Case 15
                Return Color.DarkSeaGreen
            Case 16
                Return Color.DeepPink
            Case 17
                Return Color.Gainsboro
            Case 18
                Return Color.Honeydew
            Case 19
                Return Color.LightBlue
            Case 20
                Return Color.LimeGreen
            Case Else
                Return Color.Orange
        End Select
    End Function

    'Public Function SetCustomizedSettingsToGraph() As Boolean

    '    Try
    '        If colSettings.Count > 0 Then

    '            '---Axis Pane-------
    '            'If CStr(colSettings.Item(UCase(enumGraphSettings.AxisPaneBackColor.ToString()))) <> ConstCheckStar Then
    '            '    AldysPane.AxisBackColor = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.AxisPaneBackColor.ToString()))))
    '            'Else
    '            '    AldysPane.AxisBackColor = objDefaultSettings.Axis.BackColor
    '            'End If

    '            If CStr(colSettings.Item(UCase(enumGraphSettings.AxisPaneFrameColor.ToString()))) <> ConstCheckStar Then
    '                AldysPane.AxisFrameColor = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.AxisPaneFrameColor.ToString()))))
    '            Else
    '                AldysPane.AxisFrameColor = objDefaultSettings.Axis.FrameColor
    '            End If
    '            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.AxisPaneIsFramed.ToString())))) <> ConstCheckStar Then
    '                AldysPane.IsAxisFramed = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.AxisPaneIsFramed.ToString()))))) = UCase("True"), "True", "False"))
    '            Else
    '                AldysPane.IsAxisFramed = objDefaultSettings.Axis.IsFramed
    '            End If

    '            '---Graph Pane---
    '            'If CStr(colSettings.Item(UCase(enumGraphSettings.GraphPaneBackColor.ToString()))) <> ConstCheckStar Then
    '            '    AldysPane.PaneBackColor = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.GraphPaneBackColor.ToString()))))
    '            'Else
    '            '    AldysPane.PaneBackColor = objDefaultSettings.Pane.BackColor
    '            'End If

    '            If CStr(colSettings.Item(UCase(enumGraphSettings.GraphPaneFrameColor.ToString()))) <> ConstCheckStar Then
    '                AldysPane.PaneFrameColor = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.GraphPaneFrameColor.ToString()))))
    '            Else
    '                AldysPane.PaneFrameColor = objDefaultSettings.Pane.FrameColor
    '            End If

    '            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.GraphPaneIsFramed.ToString())))) <> ConstCheckStar Then
    '                AldysPane.IsPaneFramed = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.GraphPaneIsFramed.ToString()))))) = UCase("True"), "True", "False"))
    '            Else
    '                AldysPane.IsPaneFramed = objDefaultSettings.Pane.IsFramed
    '            End If

    '            '---Graph Title
    '            If CStr(colSettings.Item(UCase(enumGraphSettings.GraphTitleFillColor.ToString()))) <> ConstCheckStar Then
    '                AldysPane.FontSpec.FontColor = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.GraphTitleFillColor.ToString()))))
    '            Else
    '                AldysPane.FontSpec.FontColor = objDefaultSettings.Pane.FontColor
    '            End If

    '            If CStr(colSettings.Item(UCase(enumGraphSettings.GraphTitleFrameColor.ToString()))) <> ConstCheckStar Then
    '                AldysPane.FontSpec.FrameColor = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.GraphTitleFrameColor.ToString()))))
    '            Else
    '                AldysPane.FontSpec.FrameColor = objDefaultSettings.Pane.FrameColor
    '            End If

    '            If CStr(colSettings.Item(UCase(enumGraphSettings.GraphTitleFillColor.ToString()))) <> ConstCheckStar Then
    '                AldysPane.FontSpec.FillColor = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.GraphTitleFillColor.ToString()))))
    '            Else
    '                AldysPane.FontSpec.FillColor = objDefaultSettings.Pane.BackColor
    '            End If

    '            If CStr(colSettings.Item(UCase(enumGraphSettings.GraphTitleFontSpceSize.ToString()))) <> ConstCheckStar Then
    '                AldysPane.FontSpec.Size = CSng(colSettings.Item(UCase(enumGraphSettings.GraphTitleFontSpceSize.ToString())))
    '            Else
    '                AldysPane.FontSpec.Size = objDefaultSettings.Pane.FontSize
    '            End If

    '            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.GraphTitleFontSpceFamily.ToString())))) <> ConstCheckStar Then
    '                AldysPane.FontSpec.Family = CStr(colSettings.Item(UCase(CStr(enumGraphSettings.GraphTitleFontSpceFamily.ToString()))))
    '            Else
    '                AldysPane.FontSpec.Family = objDefaultSettings.Pane.FontFamily
    '            End If

    '            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.GraphTitleFontSpceBold.ToString())))) <> ConstCheckStar Then
    '                AldysPane.FontSpec.IsBold = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.GraphTitleFontSpceBold.ToString()))))) = UCase("True"), "True", "False"))
    '            Else
    '                AldysPane.FontSpec.IsBold = objDefaultSettings.Pane.FontBold
    '            End If

    '            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.GraphTitleFontSpceItalic.ToString())))) <> ConstCheckStar Then
    '                AldysPane.FontSpec.IsItalic = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.GraphTitleFontSpceItalic.ToString()))))) = UCase("True"), "True", "False"))
    '            Else
    '                AldysPane.FontSpec.IsItalic = objDefaultSettings.Pane.FontItalic
    '            End If

    '            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.GraphTitleFontSpceUnderlined.ToString())))) <> ConstCheckStar Then
    '                AldysPane.FontSpec.IsUnderline = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.GraphTitleFontSpceUnderlined.ToString()))))) = UCase("True"), "True", "False"))
    '            Else
    '                AldysPane.FontSpec.IsUnderline = objDefaultSettings.Pane.FontUnderline
    '            End If



    '            '---XAxis----
    '            If CStr(colSettings.Item(UCase(enumGraphSettings.XAxisGridColor.ToString()))) <> ConstCheckStar Then
    '                AldysPane.XAxis.GridColor = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.XAxisGridColor.ToString()))))
    '            Else
    '                AldysPane.XAxis.GridColor = objDefaultSettings.Axis.GridColor
    '            End If

    '            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisGridIsShowGrid.ToString())))) <> ConstCheckStar Then
    '                AldysPane.XAxis.IsShowGrid = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisGridIsShowGrid.ToString()))))) = UCase("True"), "True", "False"))
    '            Else
    '                AldysPane.XAxis.IsShowGrid = objDefaultSettings.Axis.IsShowGrid
    '            End If

    '            If CStr(colSettings.Item(UCase(enumGraphSettings.XAxisTitleFillColor.ToString()))) <> ConstCheckStar Then
    '                AldysPane.XAxis.TitleFontSpec.FillColor = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.XAxisTitleFillColor.ToString()))))
    '            Else
    '                AldysPane.XAxis.TitleFontSpec.FillColor = Color.Transparent
    '            End If

    '            If CStr(colSettings.Item(UCase(enumGraphSettings.XAxisTitleFontSpceColor.ToString()))) <> ConstCheckStar Then
    '                AldysPane.XAxis.TitleFontSpec.FontColor = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.XAxisTitleFontSpceColor.ToString()))))
    '            Else
    '                AldysPane.XAxis.TitleFontSpec.FontColor = objDefaultSettings.Axis.TitleFontColor
    '            End If
    '            If CStr(colSettings.Item(UCase(enumGraphSettings.XAxisTitleFrameColor.ToString()))) <> ConstCheckStar Then
    '                AldysPane.XAxis.TitleFontSpec.FrameColor = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.XAxisTitleFrameColor.ToString()))))
    '            Else
    '                AldysPane.XAxis.TitleFontSpec.FrameColor = objDefaultSettings.Axis.FrameColor
    '            End If

    '            If CStr(colSettings.Item(UCase(enumGraphSettings.XAxisTitleFontSpceSize.ToString()))) <> ConstCheckStar Then
    '                AldysPane.XAxis.TitleFontSpec.Size = CSng(colSettings.Item(UCase(enumGraphSettings.XAxisTitleFontSpceSize.ToString())))
    '            Else
    '                AldysPane.XAxis.TitleFontSpec.Size = objDefaultSettings.Axis.TitleFontSize
    '            End If

    '            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisTitleIsFilled.ToString())))) <> ConstCheckStar Then
    '                AldysPane.XAxis.TitleFontSpec.IsFilled = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisTitleIsFilled.ToString()))))) = UCase("True"), "True", "False"))
    '            Else
    '                AldysPane.XAxis.TitleFontSpec.IsFilled = False
    '            End If

    '            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisTitleIsFramed.ToString())))) <> ConstCheckStar Then
    '                AldysPane.XAxis.TitleFontSpec.IsFramed = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisTitleIsFramed.ToString()))))) = UCase("True"), "True", "False"))
    '            Else
    '                AldysPane.XAxis.TitleFontSpec.IsFramed = False
    '            End If

    '            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisTitleFontSpceBold.ToString())))) <> ConstCheckStar Then
    '                AldysPane.XAxis.TitleFontSpec.IsBold = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisTitleFontSpceBold.ToString()))))) = UCase("True"), "True", "False"))
    '            Else
    '                AldysPane.XAxis.TitleFontSpec.IsBold = objDefaultSettings.Axis.TitleFontBold
    '            End If

    '            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisTitleFontSpceItalic.ToString())))) <> ConstCheckStar Then
    '                AldysPane.XAxis.TitleFontSpec.IsItalic = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisTitleFontSpceItalic.ToString()))))) = UCase("True"), "True", "False"))
    '            Else
    '                AldysPane.XAxis.TitleFontSpec.IsItalic = objDefaultSettings.Axis.TitleFontItalic
    '            End If

    '            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisTitleFontSpceUnderlined.ToString())))) <> ConstCheckStar Then
    '                AldysPane.XAxis.TitleFontSpec.IsUnderline = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisTitleFontSpceUnderlined.ToString()))))) = UCase("True"), "True", "False"))
    '            Else
    '                AldysPane.XAxis.TitleFontSpec.IsUnderline = objDefaultSettings.Axis.TitleFontUnderline
    '            End If

    '            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisTitleFontSpceFamily.ToString())))) <> ConstCheckStar Then
    '                AldysPane.XAxis.TitleFontSpec.Family = CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisTitleFontSpceFamily.ToString()))))
    '            Else
    '                AldysPane.XAxis.TitleFontSpec.Family = objDefaultSettings.Axis.TitleFontFamily
    '            End If

    '            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisScaleFontSpceFamily.ToString())))) <> ConstCheckStar Then
    '                AldysPane.XAxis.ScaleFontSpec.Family = CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisScaleFontSpceFamily.ToString()))))
    '            Else
    '                AldysPane.XAxis.ScaleFontSpec.Family = objDefaultSettings.Axis.ScaleFontFamily
    '            End If

    '            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisScaleFontSpceBold.ToString())))) <> ConstCheckStar Then
    '                AldysPane.XAxis.ScaleFontSpec.IsBold = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisScaleFontSpceBold.ToString()))))) = UCase("True"), "True", "False"))
    '            Else
    '                AldysPane.XAxis.ScaleFontSpec.IsBold = objDefaultSettings.Axis.ScaleFontBold
    '            End If
    '            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisScaleFontSpceItalic.ToString())))) <> ConstCheckStar Then
    '                AldysPane.XAxis.ScaleFontSpec.IsItalic = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisScaleFontSpceItalic.ToString()))))) = UCase("True"), "True", "False"))
    '            Else
    '                AldysPane.XAxis.ScaleFontSpec.IsItalic = objDefaultSettings.Axis.ScaleFontItalic
    '            End If

    '            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisScaleFontSpceUnderlined.ToString())))) <> ConstCheckStar Then
    '                AldysPane.XAxis.ScaleFontSpec.IsUnderline = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.XAxisScaleFontSpceUnderlined.ToString()))))) = UCase("True"), "True", "False"))
    '            Else
    '                AldysPane.XAxis.ScaleFontSpec.IsUnderline = objDefaultSettings.Axis.ScaleFontUnderline
    '            End If
    '            If CStr(colSettings.Item(UCase(enumGraphSettings.XAxisScaleFontSpceSize.ToString()))) <> ConstCheckStar Then
    '                AldysPane.XAxis.ScaleFontSpec.Size = CSng(colSettings.Item(UCase(enumGraphSettings.XAxisScaleFontSpceSize.ToString())))
    '            Else
    '                AldysPane.XAxis.ScaleFontSpec.Size = objDefaultSettings.Axis.ScaleFontSize
    '            End If


    '            '---YAxis----
    '            If CStr(colSettings.Item(UCase(enumGraphSettings.YAxisGridColor.ToString()))) <> ConstCheckStar Then
    '                AldysPane.YAxis.GridColor = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.YAxisGridColor.ToString()))))
    '            Else
    '                AldysPane.YAxis.GridColor = objDefaultSettings.Axis.GridColor
    '            End If

    '            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisGridIsShowGrid.ToString())))) <> ConstCheckStar Then
    '                AldysPane.YAxis.IsShowGrid = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisGridIsShowGrid.ToString()))))) = UCase("True"), "True", "False"))
    '            Else
    '                AldysPane.YAxis.IsShowGrid = objDefaultSettings.Axis.IsShowGrid
    '            End If

    '            If CStr(colSettings.Item(UCase(enumGraphSettings.YAxisTitleFillColor.ToString()))) <> ConstCheckStar Then
    '                AldysPane.YAxis.TitleFontSpec.FillColor = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.YAxisTitleFillColor.ToString()))))
    '            Else
    '                AldysPane.YAxis.TitleFontSpec.FillColor = Color.Transparent
    '            End If

    '            If CStr(colSettings.Item(UCase(enumGraphSettings.YAxisTitleFontSpceColor.ToString()))) <> ConstCheckStar Then
    '                AldysPane.YAxis.TitleFontSpec.FontColor = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.YAxisTitleFontSpceColor.ToString()))))
    '            Else
    '                AldysPane.YAxis.TitleFontSpec.FontColor = objDefaultSettings.Axis.TitleFontColor
    '            End If
    '            If CStr(colSettings.Item(UCase(enumGraphSettings.YAxisTitleFrameColor.ToString()))) <> ConstCheckStar Then
    '                AldysPane.YAxis.TitleFontSpec.FrameColor = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.YAxisTitleFrameColor.ToString()))))
    '            Else
    '                AldysPane.YAxis.TitleFontSpec.FrameColor = objDefaultSettings.Axis.FrameColor
    '            End If

    '            If CStr(colSettings.Item(UCase(enumGraphSettings.YAxisTitleFontSpceSize.ToString()))) <> ConstCheckStar Then
    '                AldysPane.YAxis.TitleFontSpec.Size = CSng(colSettings.Item(UCase(enumGraphSettings.YAxisTitleFontSpceSize.ToString())))
    '            Else
    '                AldysPane.YAxis.TitleFontSpec.Size = objDefaultSettings.Axis.TitleFontSize
    '            End If

    '            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisTitleIsFilled.ToString())))) <> ConstCheckStar Then
    '                AldysPane.YAxis.TitleFontSpec.IsFilled = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisTitleIsFilled.ToString()))))) = UCase("True"), "True", "False"))
    '            Else
    '                AldysPane.YAxis.TitleFontSpec.IsFilled = False
    '            End If
    '            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisTitleIsFramed.ToString())))) <> ConstCheckStar Then
    '                AldysPane.YAxis.TitleFontSpec.IsFramed = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisTitleIsFramed.ToString()))))) = UCase("True"), "True", "False"))
    '            Else
    '                AldysPane.YAxis.TitleFontSpec.IsFramed = False
    '            End If

    '            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisTitleFontSpceBold.ToString())))) <> ConstCheckStar Then
    '                AldysPane.YAxis.TitleFontSpec.IsBold = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisTitleFontSpceBold.ToString()))))) = UCase("True"), "True", "False"))
    '            Else
    '                AldysPane.YAxis.TitleFontSpec.IsBold = objDefaultSettings.Axis.TitleFontBold
    '            End If

    '            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisTitleFontSpceItalic.ToString())))) <> ConstCheckStar Then
    '                AldysPane.YAxis.TitleFontSpec.IsItalic = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisTitleFontSpceItalic.ToString()))))) = UCase("True"), "True", "False"))
    '            Else
    '                AldysPane.YAxis.TitleFontSpec.IsItalic = objDefaultSettings.Axis.TitleFontItalic
    '            End If

    '            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisTitleFontSpceUnderlined.ToString())))) <> ConstCheckStar Then
    '                AldysPane.YAxis.TitleFontSpec.IsUnderline = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisTitleFontSpceUnderlined.ToString()))))) = UCase("True"), "True", "False"))
    '            Else
    '                AldysPane.YAxis.TitleFontSpec.IsUnderline = objDefaultSettings.Axis.TitleFontUnderline
    '            End If

    '            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisTitleFontSpceFamily.ToString())))) <> ConstCheckStar Then
    '                AldysPane.YAxis.TitleFontSpec.Family = CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisTitleFontSpceFamily.ToString()))))
    '            Else
    '                AldysPane.YAxis.TitleFontSpec.Family = objDefaultSettings.Axis.TitleFontFamily
    '            End If

    '            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisScaleFontSpceFamily.ToString())))) <> ConstCheckStar Then
    '                AldysPane.YAxis.ScaleFontSpec.Family = CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisScaleFontSpceFamily.ToString()))))
    '            Else
    '                AldysPane.YAxis.ScaleFontSpec.Family = objDefaultSettings.Axis.ScaleFontFamily
    '            End If

    '            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisScaleFontSpceBold.ToString())))) <> ConstCheckStar Then
    '                AldysPane.YAxis.ScaleFontSpec.IsBold = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisScaleFontSpceBold.ToString()))))) = UCase("True"), "True", "False"))
    '            Else
    '                AldysPane.YAxis.ScaleFontSpec.IsBold = objDefaultSettings.Axis.ScaleFontBold
    '            End If
    '            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisScaleFontSpceItalic.ToString())))) <> ConstCheckStar Then
    '                AldysPane.YAxis.ScaleFontSpec.IsItalic = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisScaleFontSpceItalic.ToString()))))) = UCase("True"), "True", "False"))
    '            Else
    '                AldysPane.YAxis.ScaleFontSpec.IsItalic = objDefaultSettings.Axis.ScaleFontItalic
    '            End If

    '            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisScaleFontSpceUnderlined.ToString())))) <> ConstCheckStar Then
    '                AldysPane.YAxis.ScaleFontSpec.IsUnderline = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.YAxisScaleFontSpceUnderlined.ToString()))))) = UCase("True"), "True", "False"))
    '            Else
    '                AldysPane.YAxis.ScaleFontSpec.IsUnderline = objDefaultSettings.Axis.ScaleFontUnderline
    '            End If
    '            If CStr(colSettings.Item(UCase(enumGraphSettings.YAxisScaleFontSpceSize.ToString()))) <> ConstCheckStar Then
    '                AldysPane.YAxis.ScaleFontSpec.Size = CSng(colSettings.Item(UCase(enumGraphSettings.YAxisScaleFontSpceSize.ToString())))
    '            Else
    '                AldysPane.YAxis.ScaleFontSpec.Size = objDefaultSettings.Axis.ScaleFontSize
    '            End If

    '            '-----Legends-----
    '            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.LegendsIsFilled.ToString())))) <> ConstCheckStar Then
    '                AldysPane.Legend.IsFilled = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.LegendsIsFilled.ToString()))))) = UCase("True"), "True", "False"))
    '            Else
    '                AldysPane.Legend.IsFilled = objDefaultSettings.Legend.IsFilled
    '            End If

    '            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.LegendsIsFramed.ToString())))) <> ConstCheckStar Then
    '                AldysPane.Legend.IsFramed = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.LegendsIsFramed.ToString()))))) = UCase("True"), "True", "False"))
    '            Else
    '                AldysPane.Legend.IsFramed = objDefaultSettings.Legend.IsFramed
    '            End If

    '            If CStr(colSettings.Item(UCase(enumGraphSettings.LegendsFillColor.ToString()))) <> ConstCheckStar Then
    '                AldysPane.Legend.FillColor = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.LegendsFillColor.ToString()))))
    '            Else
    '                AldysPane.Legend.FillColor = objDefaultSettings.Legend.FillColor
    '            End If

    '            If CStr(colSettings.Item(UCase(enumGraphSettings.LegendsFrameColor.ToString()))) <> ConstCheckStar Then
    '                AldysPane.Legend.FrameColor = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.LegendsFrameColor.ToString()))))
    '            Else
    '                AldysPane.Legend.FrameColor = objDefaultSettings.Legend.FrameColor
    '            End If

    '            If CStr(colSettings.Item(UCase(enumGraphSettings.LegendsFontSpceColor.ToString()))) <> ConstCheckStar Then
    '                AldysPane.Legend.FontSpec.FontColor = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.LegendsFontSpceColor.ToString()))))
    '            Else
    '                AldysPane.Legend.FontSpec.FontColor = objDefaultSettings.Legend.FontColor
    '            End If

    '            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.LegendsFontSpceFamily.ToString())))) <> ConstCheckStar Then
    '                AldysPane.Legend.FontSpec.Family = CStr(colSettings.Item(UCase(CStr(enumGraphSettings.LegendsFontSpceFamily.ToString()))))
    '            Else
    '                AldysPane.Legend.FontSpec.Family = objDefaultSettings.Legend.FontFamily
    '            End If

    '            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.LegendsFontSpceBold.ToString())))) <> ConstCheckStar Then
    '                AldysPane.Legend.FontSpec.IsBold = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.LegendsFontSpceBold.ToString()))))) = UCase("True"), "True", "False"))
    '            Else
    '                AldysPane.Legend.FontSpec.IsBold = objDefaultSettings.Legend.FontBold
    '            End If

    '            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.LegendsFontSpceItalic.ToString())))) <> ConstCheckStar Then
    '                AldysPane.Legend.FontSpec.IsItalic = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.LegendsFontSpceItalic.ToString()))))) = UCase("True"), "True", "False"))
    '            Else
    '                AldysPane.Legend.FontSpec.IsItalic = objDefaultSettings.Legend.FontItalic
    '            End If

    '            If CStr(colSettings.Item(UCase(CStr(enumGraphSettings.LegendsFontSpceUnderlined.ToString())))) <> ConstCheckStar Then
    '                AldysPane.Legend.FontSpec.IsUnderline = CBool(IIf(UCase(CStr(colSettings.Item(UCase(CStr(enumGraphSettings.LegendsFontSpceUnderlined.ToString()))))) = UCase("True"), "True", "False"))
    '            Else
    '                AldysPane.Legend.FontSpec.IsUnderline = objDefaultSettings.Legend.FontUnderline
    '            End If

    '            If CStr(colSettings.Item(UCase(enumGraphSettings.LegendsFontSpceSize.ToString()))) <> ConstCheckStar Then
    '                AldysPane.Legend.FontSpec.Size = CSng(colSettings.Item(UCase(enumGraphSettings.LegendsFontSpceSize.ToString())))
    '            Else
    '                AldysPane.Legend.FontSpec.Size = objDefaultSettings.Legend.FontSize
    '            End If

    '            AldysPane.AxisBackColor = Color.Transparent
    '            AldysPane.PaneBackColor = Color.Transparent

    '            If CStr(colSettings.Item(UCase(enumGraphSettings.GraphPaneBackColor.ToString()))) <> ConstCheckStar Then
    '                Me.CustPan.BackColor = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.GraphPaneBackColor.ToString()))))
    '            Else
    '                Me.CustPan.BackColor = Color.Gainsboro
    '            End If

    '            If CStr(colSettings.Item(UCase(enumGraphSettings.GraphPaneBackColor2.ToString()))) <> ConstCheckStar Then
    '                Me.CustPan.BackColor2 = objClsQAGeneral.SetColor(CStr(colSettings.Item(UCase(enumGraphSettings.GraphPaneBackColor2.ToString()))))
    '            Else
    '                Me.CustPan.BackColor2 = Color.White
    '            End If

    '            AldysPane.AxisChange()
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
    'End Function

    Public Function SetDefaultSettingsToGraph() As Boolean

        Try

            AldysPane.Legend.IsVisible = True
            AldysPane.Legend.FillColor = objDefaultSettings.Legend.FillColor
            AldysPane.Legend.FrameColor = objDefaultSettings.Legend.FrameColor
            AldysPane.Legend.IsFilled = objDefaultSettings.Legend.IsFilled
            AldysPane.Legend.IsFramed = objDefaultSettings.Legend.IsFramed

            AldysPane.FontSpec.FontColor = objDefaultSettings.Pane.FontColor
            AldysPane.FontSpec.FrameColor = objDefaultSettings.Pane.FrameColor
            AldysPane.FontSpec.FillColor = objDefaultSettings.Pane.BackColor
            AldysPane.FontSpec.Size = objDefaultSettings.Pane.FontSize
            AldysPane.FontSpec.Family = objDefaultSettings.Pane.FontFamily
            AldysPane.FontSpec.IsBold = objDefaultSettings.Pane.FontBold
            AldysPane.FontSpec.IsItalic = objDefaultSettings.Pane.FontItalic
            AldysPane.FontSpec.IsUnderline = objDefaultSettings.Pane.FontUnderline

            AldysPane.XAxis.GridColor = Color.FromArgb(175, 200, 245) '  objDefaultSettings.Axis.GridColor
            AldysPane.XAxis.IsShowGrid = objDefaultSettings.Axis.IsShowGrid
            AldysPane.XAxis.IsShowGrid = objDefaultSettings.Axis.IsShowGrid
            AldysPane.XAxis.TitleFontSpec.FillColor = Color.Transparent
            AldysPane.XAxis.TitleFontSpec.FrameColor = objDefaultSettings.Axis.FrameColor
            AldysPane.XAxis.TitleFontSpec.FontColor = objDefaultSettings.Axis.TitleFontColor
            AldysPane.XAxis.TitleFontSpec.Size = objDefaultSettings.Axis.TitleFontSize
            AldysPane.XAxis.TitleFontSpec.IsFramed = False
            AldysPane.XAxis.TitleFontSpec.IsFilled = False
            AldysPane.XAxis.TitleFontSpec.IsBold = objDefaultSettings.Axis.TitleFontBold
            AldysPane.XAxis.TitleFontSpec.IsItalic = objDefaultSettings.Axis.TitleFontItalic
            AldysPane.XAxis.TitleFontSpec.IsUnderline = objDefaultSettings.Axis.TitleFontUnderline
            AldysPane.XAxis.TitleFontSpec.Family = objDefaultSettings.Axis.TitleFontFamily
            AldysPane.XAxis.ScaleFontSpec.Family = objDefaultSettings.Axis.ScaleFontFamily
            AldysPane.XAxis.ScaleFontSpec.IsBold = objDefaultSettings.Axis.ScaleFontBold
            AldysPane.XAxis.ScaleFontSpec.IsItalic = objDefaultSettings.Axis.ScaleFontItalic
            AldysPane.XAxis.ScaleFontSpec.IsUnderline = objDefaultSettings.Axis.ScaleFontUnderline

            AldysPane.YAxis.GridColor = Color.FromArgb(175, 200, 245) 'objDefaultSettings.Axis.GridColor
            AldysPane.YAxis.IsShowGrid = objDefaultSettings.Axis.IsShowGrid
            AldysPane.YAxis.IsShowGrid = objDefaultSettings.Axis.IsShowGrid
            AldysPane.YAxis.TitleFontSpec.FillColor = Color.Transparent
            AldysPane.YAxis.TitleFontSpec.FrameColor = objDefaultSettings.Axis.FrameColor
            AldysPane.YAxis.TitleFontSpec.FontColor = objDefaultSettings.Axis.TitleFontColor
            AldysPane.YAxis.TitleFontSpec.Size = objDefaultSettings.Axis.TitleFontSize
            AldysPane.YAxis.TitleFontSpec.IsFramed = False
            AldysPane.YAxis.TitleFontSpec.IsFilled = False
            AldysPane.YAxis.TitleFontSpec.IsBold = objDefaultSettings.Axis.TitleFontBold
            AldysPane.YAxis.TitleFontSpec.IsItalic = objDefaultSettings.Axis.TitleFontItalic
            AldysPane.YAxis.TitleFontSpec.IsUnderline = objDefaultSettings.Axis.TitleFontUnderline
            AldysPane.YAxis.TitleFontSpec.Family = objDefaultSettings.Axis.TitleFontFamily
            AldysPane.YAxis.ScaleFontSpec.Family = objDefaultSettings.Axis.ScaleFontFamily
            AldysPane.YAxis.ScaleFontSpec.IsBold = objDefaultSettings.Axis.ScaleFontBold
            AldysPane.YAxis.ScaleFontSpec.IsItalic = objDefaultSettings.Axis.ScaleFontItalic
            AldysPane.YAxis.ScaleFontSpec.IsUnderline = objDefaultSettings.Axis.ScaleFontUnderline

            AldysPane.PaneBackColor = Color.Transparent 'objDefaultSettings.Pane.BackColor
            AldysPane.PaneFrameColor = Color.Transparent 'objDefaultSettings.Pane.FrameColor
            AldysPane.IsPaneFramed = False ' objDefaultSettings.Pane.IsFramed

            AldysPane.AxisBackColor = Color.Transparent 'objDefaultSettings.Axis.BackColor
            AldysPane.AxisFrameColor = Color.FromArgb(175, 200, 245) 'objDefaultSettings.Axis.FrameColor
            AldysPane.IsAxisFramed = True 'objDefaultSettings.Axis.IsFramed
            AldysPane.IsShowTitle = False
            '---------------------------------
            Me.CustPan.GradientMode = GradientPanel.LinearGradientMode.Vertical
            Me.CustPan.BackColor = Color.Gainsboro
            Me.CustPan.BackColor2 = Color.White
            '---------------------------------

            '---added by deepak b on 09.02.06 
            '---for curve lebels 
            If btnShowCurveLabels.Checked = True Then
                Me.AldysPane.ShowCurveLabels = True
                Me.AldysPane.DrawCurveLabels()
                Me.Invalidate()
            End If

            AldysPane.AxisChange()

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

    Public Function GetSymbolArraylist(ByVal intNoOfSymbol As Integer, ByVal SymType As AldysGraph.SymbolType) As ArrayList
        Dim arrSymbol As New ArrayList
        Dim intICounter As Integer = 0
        Try
            For intICounter = 0 To intNoOfSymbol
                arrSymbol.Add(SymType)
            Next

            Return arrSymbol
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

    Public Function SettingsChanged() As Boolean
        If UseDefaultSettings = True Then
            Call SetDefaultSettingsToGraph()
        Else
            'Call SetCustomizedSettingsToGraph()
        End If
    End Function

#End Region

End Class
