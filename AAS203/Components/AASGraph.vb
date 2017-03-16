Imports AAS203Library
Imports AAS203Library.Method

Public Class AASGraph
    Inherits AldysGraph.AldysGraph

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        AddHandler Me.Load, AddressOf AASGraph_Load
        'CONST_dblYpointTolerance = 0.25    'this is for 100 scale
        'CONST_dblXpointTolerance = 0.3     'this is for 5 scale


    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents CommandContextMenus As NETXP.Controls.Bars.CommandContextMenu
    Friend WithEvents btnUseDefaultSettings As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents btnCustomizedGraph As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents CommandBarSeparatorItem4 As NETXP.Controls.Bars.CommandBarSeparatorItem
    Friend WithEvents btnPeakEdit As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents CommandBarSeparatorItem3 As NETXP.Controls.Bars.CommandBarSeparatorItem
    Friend WithEvents btnGrid As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents btnZoom As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents btnLegends As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents CommandBarSeparatorItem2 As NETXP.Controls.Bars.CommandBarSeparatorItem
    Friend WithEvents btnScale As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents CommandBarSeparatorItem5 As NETXP.Controls.Bars.CommandBarSeparatorItem
    Friend WithEvents btnPrint As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents btnPrintPreview As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents CommandBarSeparatorItem6 As NETXP.Controls.Bars.CommandBarSeparatorItem
    Friend WithEvents btnShowXYValues As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents btnSelectCurve As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents btnDisablePeak As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents CommandBarSeparatorItem7 As NETXP.Controls.Bars.CommandBarSeparatorItem
    Friend WithEvents btnShowCurveLabels As NETXP.Controls.Bars.CommandBarButtonItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
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
        '
        'CustPan
        '
        Me.CustPan.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustPan.Name = "CustPan"
        Me.CustPan.Size = New System.Drawing.Size(488, 344)
        '
        'CommandContextMenus
        '
        Me.CommandContextMenus.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.btnUseDefaultSettings, Me.btnCustomizedGraph, Me.CommandBarSeparatorItem4, Me.btnPeakEdit, Me.CommandBarSeparatorItem3, Me.btnGrid, Me.btnZoom, Me.btnLegends, Me.CommandBarSeparatorItem2, Me.btnScale, Me.CommandBarSeparatorItem5, Me.btnPrint, Me.btnPrintPreview, Me.CommandBarSeparatorItem6, Me.btnShowXYValues, Me.btnSelectCurve, Me.btnDisablePeak, Me.CommandBarSeparatorItem7, Me.btnShowCurveLabels})
        '
        'btnUseDefaultSettings
        '
        Me.btnUseDefaultSettings.Text = "Use Default Settings"
        Me.btnUseDefaultSettings.Visible = False
        '
        'btnCustomizedGraph
        '
        Me.btnCustomizedGraph.Text = "Customized Graph"
        Me.btnCustomizedGraph.Visible = False
        '
        'CommandBarSeparatorItem4
        '
        Me.CommandBarSeparatorItem4.Visible = False
        '
        'btnPeakEdit
        '
        Me.btnPeakEdit.Enabled = False
        Me.btnPeakEdit.Text = "Peak Edit"
        '
        'btnGrid
        '
        Me.btnGrid.Text = "Grid"
        '
        'btnZoom
        '
        Me.btnZoom.Text = "Zoom"
        Me.btnZoom.Visible = False
        '
        'btnLegends
        '
        Me.btnLegends.Text = "Legends"
        '
        'btnScale
        '
        Me.btnScale.Text = "Scale"
        Me.btnScale.Visible = False
        '
        'CommandBarSeparatorItem5
        '
        Me.CommandBarSeparatorItem5.Visible = False
        '
        'btnPrint
        '
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
        Me.btnShowXYValues.Enabled = False
        Me.btnShowXYValues.ShowText = True
        Me.btnShowXYValues.Text = "Show X,Y Values"
        '
        'btnSelectCurve
        '
        Me.btnSelectCurve.Text = "Peak Curve"
        Me.btnSelectCurve.Visible = False
        '
        'btnDisablePeak
        '
        Me.btnDisablePeak.Text = "Disable Peak"
        Me.btnDisablePeak.Visible = False
        '
        'CommandBarSeparatorItem7
        '
        Me.CommandBarSeparatorItem7.Visible = False
        '
        'btnShowCurveLabels
        '
        Me.btnShowCurveLabels.ShowText = True
        Me.btnShowCurveLabels.Text = "Show Curve Labels"
        Me.btnShowCurveLabels.Visible = False
        '
        'AASGraph
        '
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "AASGraph"
        Me.Size = New System.Drawing.Size(488, 344)

    End Sub

#End Region

#Region " Private Member Variables & Constants "

    Private mobjDefaultSettings As AldysGraph.Defaults
    Private mblnUseDefaultSettings As Boolean

    '---A CurveItem type object to Plot the Curve on the Graph Rect
    Private mobjOfflineCurve As AldysGraph.CurveItem

    Private mblnIsOnlineCurveStarted As Boolean
    Private mblnIsOnlineGraphRunning As Boolean
    Private mblnIsOnlineGraphStopped As Boolean

    Private mobjBeforeZoomGraph As AldysGraph.AldysPane
    Private mintCurveCounter As Integer = 0

    '---A Data Table type object to get X and Y coordinates for the calling function
    Private mobjDtGraphData As DataTable

    Private mstrGraphTitle As String
    Private mstrXAxisLabel As String
    Private mstrYAxisLabel As String

    Private mXAxisType As AldysGraph.AxisType
    Private mYAxisType As AldysGraph.AxisType

    Private mstrXAxisScaleFormat As String
    Private mstrYAxisScaleFormat As String
    Private mstrXAxisDateScaleFormat As enumDateScaleFormat

    Private mdblXAxisMin As Double
    Private mdblXAxisMax As Double

    Private mdblXAxisDateMin, mdblXAxisDateMax As Date

    Private mdblXAxisMinorStep As Double
    Private mdblXAxisStep As Double
    Private mdblYAxisMin As Double
    Private mdblYAxisMax As Double
    Private mdblYAxisMinorStep As Double
    Private mdblYAxisStep As Double
    Private dblXFator As Double = 0.5

#End Region

#Region " Public Enums, Constants, Events, Structuress.. "

    Public Enum enumDateScaleFormat
        YYYY = 0        '"&yyyy"
        MMMYY = 1       '"&mmm-&yy"
        DDMMM = 2       '"&d-&mmm"
        DDMMM_HHMM = 3  '"&d-&mmm &hh:&nn"
        HHMM = 4        '"&hh:&nn"
        mmss = 5        '"&nn:&ss"
    End Enum

    Public Event GraphScaleChanged(ByVal XMin As Double, ByVal XMax As Double, ByVal YMin As Double, ByVal YMax As Double)

    Public Event GraphOptionChanged()
    'Public Const CONST_dblXpointTolerance = 0.3
    'Public Const CONST_dblYpointTolerance = 0.015
    Public CONST_dblYpointTolerance As Double = 0.015    'this is for 100 scale
    Public CONST_dblXpointTolerance As Double = 0.3     'this is for 5 scale

#End Region

#Region " Public Properties "

    Public Property XAxisType() As AldysGraph.AxisType
        Get
            Return mXAxisType
        End Get
        Set(ByVal Value As AldysGraph.AxisType)
            mXAxisType = Value
            AldysPane.XAxis.Type = Value
            If Value = AldysGraph.AxisType.Date Then
                XAxisDateScaleFormat = enumDateScaleFormat.HHMM
                XAxisDateMin = CDate(Format(Now, "dd-MMM-yyyy"))
                XAxisDateMax = XAxisDateMin.AddDays(1).AddSeconds(-1)
                AldysPane.AxisChange()
                Me.Invalidate()
            End If
        End Set
    End Property

    Public Property XAxisScaleFormat() As String
        Get
            Return mstrXAxisScaleFormat
        End Get
        Set(ByVal Value As String)
            mstrXAxisScaleFormat = Value
            AldysPane.XAxis.ScaleFormat = Value
            AldysPane.AxisChange()
            Me.Invalidate()
        End Set
    End Property

    Public Property XAxisDateScaleFormat() As enumDateScaleFormat
        Get
            Return mstrXAxisDateScaleFormat
        End Get
        Set(ByVal Value As enumDateScaleFormat)
            mstrXAxisDateScaleFormat = Value
            Select Case Value
                Case enumDateScaleFormat.YYYY
                    XAxisScaleFormat = "&yyyy"
                    XAxisLabel = "Time (in Years)"

                Case enumDateScaleFormat.MMMYY
                    XAxisScaleFormat = "&mmm-&yy"
                    XAxisLabel = "Time (in MMM-YY)"

                Case enumDateScaleFormat.DDMMM
                    XAxisScaleFormat = "&d-&mmm"
                    XAxisLabel = "Time (in DD-MMM)"

                Case enumDateScaleFormat.DDMMM_HHMM
                    XAxisScaleFormat = "&d-&mmm &hh:&nn"
                    XAxisLabel = "Time (in DD-MMM HH:mm)"

                Case enumDateScaleFormat.HHMM
                    XAxisScaleFormat = "&hh:&nn"
                    XAxisLabel = "Time (in HH:mm)"

                Case enumDateScaleFormat.mmss
                    XAxisScaleFormat = "&nn:&ss"
                    XAxisLabel = "Time (in mm:ss)"

            End Select

            AldysPane.XAxis.StepAuto = True
            AldysPane.XAxis.MinorStepAuto = True
            AldysPane.XAxis.PickScale(AldysPane.XAxis.Min, AldysPane.XAxis.Max)
            AldysPane.AxisChange()
            Me.Invalidate()
        End Set
    End Property

    Public Property YAxisScaleFormat() As String
        Get
            Return mstrYAxisScaleFormat
        End Get
        Set(ByVal Value As String)
            mstrYAxisScaleFormat = Value
            AldysPane.YAxis.ScaleFormat = Value
            AldysPane.AxisChange()
            Me.Invalidate()
        End Set
    End Property

    Public Property YAxisType() As AldysGraph.AxisType
        Get
            Return mYAxisType
        End Get
        Set(ByVal Value As AldysGraph.AxisType)
            mYAxisType = Value
            AldysPane.YAxis.Type = Value
            AldysPane.AxisChange()
            Me.Invalidate()
        End Set
    End Property

    Public Property XAxisLabel() As String
        Get
            Return mstrXAxisLabel
        End Get
        Set(ByVal Value As String)
            mstrXAxisLabel = Value
            AldysPane.XAxis.Title = Value
            AldysPane.AxisChange()
            Me.Invalidate()
        End Set
    End Property

    Public Property YAxisLabel() As String
        Get
            Return mstrYAxisLabel
        End Get
        Set(ByVal Value As String)
            mstrYAxisLabel = Value
            AldysPane.YAxis.Title = Value
            AldysPane.AxisChange()
            Me.Invalidate()
        End Set
    End Property

    Public Property GraphDataSource() As DataTable
        Get
            Return mobjDtGraphData
        End Get
        Set(ByVal Value As DataTable)
            mobjDtGraphData = Value
        End Set
    End Property

    Public Property UseDefaultSettings() As Boolean
        Get
            Return mblnUseDefaultSettings
        End Get
        Set(ByVal Value As Boolean)
            mblnUseDefaultSettings = Value
        End Set
    End Property

    Public Property XAxisMin() As Double
        Get
            Return mdblXAxisMin
        End Get
        Set(ByVal Value As Double)
            mdblXAxisMin = Value
            AldysPane.XAxis.Min = Value
            AldysPane.AxisChange()
            Me.Invalidate()
        End Set
    End Property

    Public Property XAxisMax() As Double
        Get
            Return mdblXAxisMax
        End Get
        Set(ByVal Value As Double)
            mdblXAxisMax = Value
            AldysPane.XAxis.Max = Value
            AldysPane.AxisChange()
            Me.Invalidate()
        End Set
    End Property

    Public Property XAxisDateMin() As Date
        Get
            Return mdblXAxisDateMin
        End Get
        Set(ByVal Value As Date)
            mdblXAxisDateMin = Value
            XAxisMin = AldysGraph.XDate.DateTimeToXLDate(Value)
            AldysPane.AxisChange()
            Me.Invalidate()
        End Set
    End Property

    Public Property XAxisDateMax() As Date
        Get
            Return mdblXAxisDateMax
        End Get
        Set(ByVal Value As Date)
            mdblXAxisDateMax = Value
            XAxisMax = AldysGraph.XDate.DateTimeToXLDate(Value)
        End Set
    End Property

    'Public Property XAxisTimeMin() As String
    '    Get
    '        Return AldysPane.XAxis.Min
    '    End Get
    '    Set(ByVal Value As String)
    '        AldysPane.XAxis.Min = AldysGraph.XDate.DateTimeToXLDate(Value)
    '    End Set
    'End Property

    'Public Property XAxisTimeMax() As String
    '    Get
    '        Return AldysPane.XAxis.Max
    '    End Get
    '    Set(ByVal Value As String)
    '        AldysPane.XAxis.Max = AldysGraph.XDate.DateTimeToXLDate(Value)
    '    End Set
    'End Property

    Public Property XAxisMinorStep() As Double
        Get
            Return mdblXAxisMinorStep
        End Get
        Set(ByVal Value As Double)
            mdblXAxisMinorStep = Value
            AldysPane.XAxis.MinorStep = Value
            AldysPane.AxisChange()
            Me.Invalidate()
        End Set
    End Property

    Public Property XAxisStep() As Double
        Get
            Return mdblXAxisStep
        End Get
        Set(ByVal Value As Double)
            mdblXAxisStep = Value
            AldysPane.XAxis.Step = Value
            AldysPane.AxisChange()
            Me.Invalidate()
        End Set
    End Property

    Public Property YAxisMin() As Double
        Get
            Return mdblYAxisMin
        End Get
        Set(ByVal Value As Double)
            mdblYAxisMin = Value
            AldysPane.YAxis.Min = Value
            AldysPane.AxisChange()
            Me.Invalidate()
        End Set
    End Property

    Public Property YAxisMax() As Double
        Get
            Return mdblYAxisMax
        End Get
        Set(ByVal Value As Double)
            mdblYAxisMax = Value
            AldysPane.YAxis.Max = Value
            AldysPane.AxisChange()
            Me.Invalidate()
        End Set
    End Property

    Public Property YAxisMinorStep() As Double
        Get
            Return mdblYAxisMinorStep
        End Get
        Set(ByVal Value As Double)
            mdblYAxisMinorStep = Value
            AldysPane.YAxis.MinorStep = Value
            AldysPane.AxisChange()
            Me.Invalidate()
        End Set
    End Property

    Public Property YAxisStep() As Double
        Get
            Return mdblYAxisStep
        End Get
        Set(ByVal Value As Double)
            mdblYAxisStep = Value
            AldysPane.YAxis.Step = Value
            AldysPane.AxisChange()
            Me.Invalidate()
        End Set
    End Property

    Public ReadOnly Property OfflineCurve() As AldysGraph.CurveItem
        Get
            Return mobjOfflineCurve
        End Get
    End Property

    Public ReadOnly Property IsOnlineGraphRunning() As Boolean
        Get
            Return mblnIsOnlineGraphRunning
        End Get
    End Property

    Public Property IsShowGrid() As Boolean
        Get
            If AldysPane.XAxis.IsShowGrid Then
                Return True
            Else
                Return False
            End If
        End Get
        Set(ByVal Value As Boolean)
            AldysPane.XAxis.IsShowGrid = Value
            AldysPane.YAxis.IsShowGrid = Value
            AldysPane.AxisChange()
            Me.Invalidate()
        End Set

    End Property

#End Region

#Region " Event Handling Fucntions "

    Private Sub AASGraph_Load(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Call SetDefaultSettingsToGraph()
            Call AddHandlers()
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

    Private Sub AASGraph_CustPaneMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Try
            btnGrid.Checked = AldysPane.XAxis.IsShowGrid

            btnLegends.Checked = AldysPane.Legend.IsVisible
            btnUseDefaultSettings.Checked = mblnUseDefaultSettings
            btnShowXYValues.Checked = Me.ShowXYValues
            btnPeakEdit.Checked = Me.ShowXYPeak
            If mblnUseDefaultSettings = True Then
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
                'btnShowCurveLabels.Visible = True
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

    Private Sub AASGraph_StatusEvent(ByVal o As Object, ByVal e As AldysGraph.CurveStatus)

    End Sub
    'AddHandler MyBase.AddRemovePoint, AddressOf AASGraph_StatusEvent
    Private Sub AASGraph_AddRemovePoint(ByVal IsAddPoint As Boolean, ByVal Point As AldysGraph.Point)

    End Sub
    Private Sub submnuGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            btnGrid.Checked = Not (btnGrid.Checked)
            Me.IsShowGrid = btnGrid.Checked
            RaiseEvent GraphOptionChanged()
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
            RaiseEvent GraphOptionChanged()
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

    Public Sub submnuScale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim objfrmGraphScale As frmGraphScale

        Try
            objfrmGraphScale = New frmGraphScale

            objfrmGraphScale.NVXMin.Text = AldysPane.XAxis.Min
            objfrmGraphScale.NVXMax.Text = AldysPane.XAxis.Max
            objfrmGraphScale.NVYMin.Text = AldysPane.YAxis.Min
            objfrmGraphScale.NVYMax.Text = AldysPane.YAxis.Max

            'If AldysPane.XAxis.Title = mstrXAxisLabel Then
            '    objfrmGraphScale.XAxisWavelength = True
            'Else
            '    objfrmGraphScale.XAxisWavelength = False
            'End If

            '---If X-Axis is Time then display date time values
            If AldysPane.XAxis.Type = AldysGraph.AxisType.Date Then
                objfrmGraphScale.IsXAxisDateTime = True

                objfrmGraphScale.dtpXMin.Format = DateTimePickerFormat.Custom
                objfrmGraphScale.dtpXMax.Format = DateTimePickerFormat.Custom

                Select Case AldysPane.XAxis.ScaleFormat
                    Case Is = "&yyyy"
                        objfrmGraphScale.dtpXMin.CustomFormat = "yyyy"
                        objfrmGraphScale.dtpXMax.CustomFormat = "yyyy"
                        objfrmGraphScale.lblXminFormat.Text = "yyyy"
                        objfrmGraphScale.lblXMaxFormat.Text = "yyyy"

                    Case Is = "&mmm-&yy"
                        objfrmGraphScale.dtpXMin.CustomFormat = "MMM-yy"
                        objfrmGraphScale.dtpXMax.CustomFormat = "MMM-yy"
                        objfrmGraphScale.lblXminFormat.Text = "MMM-yy"
                        objfrmGraphScale.lblXMaxFormat.Text = "MMM-yy"

                    Case Is = "&d-&mmm"
                        objfrmGraphScale.dtpXMin.CustomFormat = "dd-MMM"
                        objfrmGraphScale.dtpXMax.CustomFormat = "dd-MMM"
                        objfrmGraphScale.lblXminFormat.Text = "dd-MMM"
                        objfrmGraphScale.lblXMaxFormat.Text = "dd-MMM"

                    Case Is = "&d-&mmm &hh:&nn"
                        objfrmGraphScale.dtpXMin.CustomFormat = "dd-MMM HH:mm"
                        objfrmGraphScale.dtpXMax.CustomFormat = "dd-MMM HH:mm"
                        objfrmGraphScale.lblXminFormat.Text = "dd-MMM HH:mm"
                        objfrmGraphScale.lblXMaxFormat.Text = "dd-MMM HH:mm"

                    Case Is = "&hh:&nn"
                        objfrmGraphScale.dtpXMin.CustomFormat = "HH:mm"
                        objfrmGraphScale.dtpXMax.CustomFormat = "HH:mm"
                        objfrmGraphScale.lblXminFormat.Text = "HH:mm"
                        objfrmGraphScale.lblXMaxFormat.Text = "HH:mm"

                    Case Is = "&nn:&ss"
                        objfrmGraphScale.dtpXMin.CustomFormat = "mm:ss"
                        objfrmGraphScale.dtpXMax.CustomFormat = "mm:ss"
                        objfrmGraphScale.lblXminFormat.Text = "mm:ss"
                        objfrmGraphScale.lblXMaxFormat.Text = "mm:ss"

                End Select
                objfrmGraphScale.dtpXMin.Value = AldysGraph.XDate.XLDateToDateTime(AldysPane.XAxis.Min)
                objfrmGraphScale.dtpXMax.Value = AldysGraph.XDate.XLDateToDateTime(AldysPane.XAxis.Max)
            End If

            If objfrmGraphScale.ShowDialog(Me) = DialogResult.OK Then

                If AldysPane.XAxis.Type = AldysGraph.AxisType.Date Then
                    AldysPane.XAxis.Min = AldysGraph.XDate.DateTimeToXLDate(objfrmGraphScale.dtpXMin.Value)
                    AldysPane.XAxis.Max = AldysGraph.XDate.DateTimeToXLDate(objfrmGraphScale.dtpXMax.Value)
                Else
                    AldysPane.XAxis.Min = CDbl(objfrmGraphScale.NVXMin.Text)
                    AldysPane.XAxis.Max = CDbl(objfrmGraphScale.NVXMax.Text)
                End If

                AldysPane.YAxis.Min = CDbl(objfrmGraphScale.NVYMin.Text)
                AldysPane.YAxis.Max = CDbl(objfrmGraphScale.NVYMax.Text)

                AldysPane.XAxis.MinorStepAuto = True
                AldysPane.XAxis.StepAuto = True
                AldysPane.YAxis.MinorStepAuto = True
                AldysPane.YAxis.StepAuto = True

                objfrmGraphScale.Close()
                objfrmGraphScale.Dispose()

                AldysPane.AxisChange()
                Me.Invalidate()

                RaiseEvent GraphScaleChanged(AldysPane.XAxis.Min, AldysPane.XAxis.Max, _
                                             AldysPane.YAxis.Min, AldysPane.YAxis.Max)

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
    Public Sub disablePeakEdit()
        'Added by pankaj on 26 Aug 07 
        Try
            If Me.AldysPane.CurveList().Count <= 0 Then
                btnPeakEdit.Checked = False
                Me.EnablePeakTrace(mintCurveCounter, False)
                Me.ShowXYPeak = False
                Me.Invalidate()
                Me.XAxisLabel = ""
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
    'Private Sub submnuPeakEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Public Function getCurveListCount() As Integer
        'Added by pankaj on 27 Aug 07 
        Dim iretVal As Integer = 0
        Try
            iretVal = Me.AldysPane.CurveList().Count
            Return iretVal
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return iretVal
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
    Public Sub submnuPeakEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim curve As AldysGraph.CurveItem
        Dim dtCurveNames As DataTable
        Dim dtRow As DataRow
        Dim objfrmPeakEdit As frmSelectPeakEdit
        Static Dim statblnGetLegendsPos As Boolean
        Static Dim statstrGetXLabel As String
        Try
            If Me.AldysPane.CurveList().Count <= 0 Then
                gobjMessageAdapter.ShowMessage("No curve found for Peakedit", "Peakedit", MessageHandler.clsMessageHandler.enumMessageType.WarningMessage)
                Exit Sub
            End If

            btnPeakEdit.Checked = Not (btnPeakEdit.Checked)
            objfrmPeakEdit = New frmSelectPeakEdit

            If btnPeakEdit.Checked = True Then
                dtCurveNames = New DataTable
                dtCurveNames.Columns.Add("CurveIndex")
                dtCurveNames.Columns.Add("CurveName")

                mintCurveCounter = 0

                For Each curve In Me.AldysPane.CurveList
                    dtRow = dtCurveNames.NewRow
                    dtRow("CurveIndex") = mintCurveCounter
                    If Len(curve.Label) > 0 Then
                        dtRow("CurveName") = curve.Label
                    Else
                        dtRow("CurveName") = "Curve : " & mintCurveCounter + 1
                    End If
                    dtCurveNames.Rows.Add(dtRow)
                    mintCurveCounter += 1
                Next
                objfrmPeakEdit.CurveTable = dtCurveNames
                Me.trackBarColor = Color.WhiteSmoke
                Me.peakLineWidth = 1
                mintCurveCounter = 0

                Dim pos As New Point
                pos.X = MousePosition.X
                pos.Y = MousePosition.Y
                objfrmPeakEdit.Location = pos
                objfrmPeakEdit.Name = Me.Name

                Me.pXYFont.IsFramed = True
                Me.pXYFont.Size = 11


                'statstrGetLegends = Me.AldysPane.Legend.IsFilled  
                If objfrmPeakEdit.ShowDialog(Me) = DialogResult.OK Then
                    If Me.AldysPane.CurveList.Count > 0 Then
                        mintCurveCounter = CInt(objfrmPeakEdit.cmbCurveName.SelectedValue)
                        Me.peakLineColor = Me.AldysPane.CurveList.Item(mintCurveCounter).Line.Color()
                        Me.ShowXYPeak = True
                        Me.EnablePeakTrace(mintCurveCounter, True)
                        objfrmPeakEdit.Dispose()
                        statstrGetXLabel = Me.XAxisLabel
                        Me.XAxisLabel = " "
                    End If
                Else
                    'If Me.AldysPane.CurveList.Count > 0 Then
                    '    Me.peakLineColor = Me.AldysPane.CurveList.Item(mintCurveCounter).Line.Color()
                    '    Me.ShowXYPeak = True
                    '    Me.EnablePeakTrace(mintCurveCounter, True)
                    'End If
                    objfrmPeakEdit.Dispose()
                End If

                dtCurveNames.Dispose()
                dtRow = Nothing
                'statstrGetXLabel = Me.XAxisLabel
            Else

                Me.EnablePeakTrace(mintCurveCounter, False)
                Me.ShowXYPeak = False
                Me.Invalidate()
                Me.XAxisLabel = statstrGetXLabel
            End If
            RaiseEvent GraphOptionChanged()
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
                ''If blnShowRainBowBand = True Then
                ''    Me.blnShowRainboBand = True
                ''    blnShowRainBowBand = False
                ''End If
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

    Private Sub submnuZoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            btnZoom.Checked = Not (btnZoom.Checked)

            If btnZoom.Checked = True Then
                Me.Zoom = True

                'If btnShowCurveLabels.Checked = True Then
                '    Call RemoveCurveLabels()
                '    btnShowCurveLabels.Checked = False
                'End If

                ''blnShowRainBowBand = Me.blnShowRainboBand
                mobjBeforeZoomGraph = Me.AldysPane.Clone()
            Else
                Me.Zoom = False
                Me.AldysPane = mobjBeforeZoomGraph.Clone()

                'If blnShowRainBowBand = True Then
                '    'Call LoadRainBowBand()
                'End If

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

    Private Sub submnuUseDefaultSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            btnCustomizedGraph.Checked = False
            btnUseDefaultSettings.Checked = True
            mblnUseDefaultSettings = True

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

    Private Sub submnuCustomize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim bSuccess As Boolean = False
        Try
            'Dim frmGraphCust As New frmGraphCustmization(Me.AldysPane.Clone())
            ''---Set the Graph type
            'frmGraphCust.BackColor1 = Me.CustPan.BackColor
            'frmGraphCust.BackColor2 = Me.CustPan.BackColor2
            'frmGraphCust.GraphType = frmName 'ConstGraphTypeCommonGraphControl
            'If frmGraphCust.ShowDialog() = (DialogResult.OK) Then
            '    Me.colSettings = frmGraphCust.colSettings.Clone()
            '    frmGraphCust.Close()
            '    btnCustomizedGraph.Checked = True
            '    btnUseDefaultSettings.Checked = False
            '    blnUseDefaultSettings = False
            '    bSuccess = objIniFileOperations.WriteToINI(UCase(frmName), ConstUseDefaultSettings, "False")
            '    Call SetCustomizedSettingsToGraph()
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

    Private Sub btnShowXYValues_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            btnShowXYValues.Checked = Not (btnShowXYValues.Checked)

            If btnShowXYValues.Checked = True Then
                Me.ShowXYValues = True
            Else
                Me.ShowXYValues = False
            End If
            RaiseEvent GraphOptionChanged()
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

    Private Function AddHandlers() As Boolean
        Try
            AddHandler MyBase.CustPaneMouseDown, AddressOf AASGraph_CustPaneMouseDown
            AddHandler MyBase.StatusEvent, AddressOf AASGraph_StatusEvent
            AddHandler MyBase.AddRemovePoint, AddressOf AASGraph_AddRemovePoint

            AddHandler btnCustomizedGraph.Click, AddressOf submnuCustomize_Click
            AddHandler btnGrid.Click, AddressOf submnuGrid_Click
            AddHandler btnPeakEdit.Click, AddressOf submnuPeakEdit_Click
            AddHandler btnPrint.Click, AddressOf submnuPrint_Click
            AddHandler btnPrintPreview.Click, AddressOf submnuPrintPreview_Click
            AddHandler btnZoom.Click, AddressOf submnuZoom_Click
            AddHandler btnUseDefaultSettings.Click, AddressOf submnuUseDefaultSettings_Click
            AddHandler btnScale.Click, AddressOf submnuScale_Click
            AddHandler btnLegends.Click, AddressOf mnuLegends_Click
            AddHandler btnDisablePeak.Click, AddressOf btnDisablePeak_Click
            ''AddHandler btnShowCurveLabels.Click, AddressOf btnShowCurveLabels_Click
            ''AddHandler Me.OnAxisChange, AddressOf LoadRainBowBand
            AddHandler btnShowXYValues.Click, AddressOf btnShowXYValues_Click
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

#Region " Public Functions "

    Public Function PlotGraph() As AldysGraph.CurveItem
        '=====================================================================
        ' Procedure Name        : PlotGraph
        ' Parameters Passed     : Nothing
        ' Returns               : True if graph plotted successfully else False
        ' Purpose               : To Plot the Offline Graph according to the specification
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
            ' A Double Type array to Store X-Coordinates to be plotted
            Dim dblArrXCoordinates As New ArrayList

            '---Clear the Items in the Curve List
            Me.AldysPane.CurveList.Clear()
            Me.AldysPane.TextList.Clear()

            '---Extract the value of X-Coordinates into a double type array
            If mobjDtGraphData.Rows.Count() > 0 Then
                For intICounter = 0 To mobjDtGraphData.Rows.Count() - 1
                    dblArrXCoordinates.Add(CDbl(mobjDtGraphData.Rows.Item(intICounter).Item(0)))
                Next
            End If

            Me.IsShowGrid = True
            '---Set the Properties of X-Axis
            Me.AldysPane.XAxis.Type = mXAxisType  ''AldysGraph.AxisType.Linear
            Me.AldysPane.XAxis.Title = mstrXAxisLabel
            Me.AldysPane.XAxis.MaxAuto = False
            Me.AldysPane.XAxis.MinAuto = False
            Me.AldysPane.XAxis.StepAuto = False
            Me.AldysPane.XAxis.MinorStepAuto = False
            If mobjDtGraphData.Rows.Count() > 0 Then
                Me.AldysPane.XAxis.Min = CInt(mobjDtGraphData.Rows.Item(0).Item(0) & "")
                Me.AldysPane.XAxis.Max = CInt(mobjDtGraphData.Rows.Item(mobjDtGraphData.Rows.Count() - 1).Item(0) & "")
            End If
            Me.AldysPane.XAxis.MinorStep = mdblXAxisMinorStep 'X_AXIS_MINOR_STEP
            Me.AldysPane.XAxis.Step = mdblXAxisStep 'X_AXIS_STEP

            '---Set the Properties of Y-Axis
            Me.AldysPane.YAxis.MaxAuto = False
            Me.AldysPane.YAxis.MinAuto = False
            Me.AldysPane.YAxis.StepAuto = False
            Me.AldysPane.YAxis.MinorStepAuto = False

            Me.AldysPane.YAxis.Type = AldysGraph.AxisType.Linear
            Me.AldysPane.YAxis.Min = mdblYAxisMin 'Y_AXIS_MIN
            Me.AldysPane.YAxis.Max = mdblYAxisMax 'Y_AXIS_MAX
            Me.AldysPane.YAxis.MinorStep = mdblYAxisMinorStep 'Y_AXIS_MINIOR_STEP
            Me.AldysPane.YAxis.Step = mdblYAxisStep 'Y_AXIS_STEP

            Me.AldysPane.YAxis.Title = mstrYAxisLabel

            '---Draw the curve on the Graph Rect X Coordinates as Wavelength and Y coordinates as Rfl, K/S, Log K/S
            If mobjDtGraphData.Columns.Count > 0 Then
                Dim dblHighPeak As Double
                Dim dblXHighPeak As Double
                Dim dblYHighPeak As Double
                Dim blnIsFoundPeak As Boolean = False
                Dim dblArrYCoordinates As New ArrayList       '---A Double Type array to Store Y-Coordinates to be plotted
                For intICounter = 1 To mobjDtGraphData.Columns.Count() - 1
                    'Dim dblArrYCoordinates As New ArrayList       '---A Double Type array to Store Y-Coordinates to be plotted
                    '---Extract the value of Y-Coordinates into a double type array for different Batch

                    If mobjDtGraphData.Rows.Count() > 0 Then
                        'dblHighPeak = CDbl(mobjDtGraphData.Rows.Item(intICounter).Item(1))
                        dblHighPeak = CDbl(mobjDtGraphData.Rows.Item(0).Item(1))
                        For intJCounter = 0 To mobjDtGraphData.Rows.Count() - 1
                            dblArrYCoordinates.Add(CDbl(mobjDtGraphData.Rows.Item(intJCounter).Item(intICounter) & ""))

                            'If dblHighPeak < CDbl(mobjDtGraphData.Rows.Item(intJCounter).Item(intICounter)) Then
                            If dblHighPeak < CDbl(mobjDtGraphData.Rows.Item(intJCounter).Item(1)) Then
                                blnIsFoundPeak = True
                                dblXHighPeak = CDbl(mobjDtGraphData.Rows.Item(intJCounter).Item(0))
                                dblYHighPeak = CDbl(mobjDtGraphData.Rows.Item(intJCounter).Item(1))
                                'dblHighPeak = CDbl(mobjDtGraphData.Rows.Item(intICounter).Item(1))
                                dblHighPeak = CDbl(mobjDtGraphData.Rows.Item(intJCounter).Item(1))
                            End If

                        Next
                    End If

                    '---Add the Curve in Curve List
                    mobjOfflineCurve = Me.AldysPane.AddCurve(CStr(mobjDtGraphData.Columns.Item(intICounter).ColumnName) & "", dblArrXCoordinates, dblArrYCoordinates, GetColor(intICounter - 1), AldysGraph.SymbolType.NoSymbol)
                    mobjOfflineCurve.Line.Style = Drawing2D.DashStyle.Solid

                    If blnIsFoundPeak = True Then
                        mobjOfflineCurve.HighPeakYValue = dblYHighPeak
                        mobjOfflineCurve.HighPeakXValue = dblXHighPeak
                    End If

                Next


            End If

            '---Set the Properties of graph
            If mblnUseDefaultSettings = True Then
                Call SetDefaultSettingsToGraph()
            Else
                'Call SetCustomizedSettingsToGraph()
            End If

            Me.AldysPane.Title = mstrGraphTitle
            Me.AldysPane.YAxis.LowerAlarmLine = False
            Me.AldysPane.YAxis.LowerAlarmLineY = 0.0
            Me.AldysPane.YAxis.LowerAlarmLineColor = Color.Black

            '---Force the Graph control to Draw according to the Change in Specification
            Me.AldysPane.AxisChange()
            Me.Invalidate()

            If Not IsNothing(mobjOfflineCurve) Then
                Return mobjOfflineCurve
            Else
                Return Nothing
            End If

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
            '---------------------------------------------------------           
        End Try
    End Function

    Public Function StartOnlineGraph(ByVal strCurveName As String, ByVal curveColor As Color, _
                                     ByVal symbol As AldysGraph.SymbolType, _
                                     Optional ByVal blnIsColoredGraph As Boolean = False) As AldysGraph.CurveItem
        '=====================================================================
        ' Procedure Name        : StartOnlineGraph
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To plot the online graph 
        ' Description           : 
        ' Assumptions           : 
        '                         
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 28-Nov-2006 04:20 PM
        ' Revisions             : 1
        '=====================================================================
        Dim objOnlineCurve As AldysGraph.CurveItem
        Dim arrX As ArrayList
        Dim arrY As ArrayList

        Try
            Me.AldysPane.XAxis.Title = mstrXAxisLabel
            Me.AldysPane.XAxis.Type = mXAxisType
            Me.IsShowGrid = True

            If mXAxisType = AldysGraph.AxisType.Date Then
                Me.AldysPane.XAxis.MaxAuto = True
                Me.AldysPane.XAxis.MinAuto = True
                Me.AldysPane.XAxis.StepAuto = True
                Me.AldysPane.XAxis.MinorStepAuto = True
            Else
                Me.AldysPane.XAxis.MaxAuto = False
                Me.AldysPane.XAxis.MinAuto = False
                Me.AldysPane.XAxis.StepAuto = False
                Me.AldysPane.XAxis.MinorStepAuto = False

                Me.AldysPane.XAxis.Min = mdblXAxisMin
                Me.AldysPane.XAxis.Max = mdblXAxisMax
                Me.AldysPane.XAxis.MinorStep = mdblXAxisMinorStep
                Me.AldysPane.XAxis.Step = mdblXAxisStep
            End If

            Me.AldysPane.YAxis.Type = mYAxisType
            Me.AldysPane.YAxis.Title = mstrYAxisLabel
            Me.AldysPane.YAxis.Min = mdblYAxisMin
            Me.AldysPane.YAxis.Max = mdblYAxisMax
            Me.AldysPane.YAxis.MinorStep = mdblYAxisMinorStep
            Me.AldysPane.YAxis.Step = mdblYAxisStep

            If Not mXAxisType = AldysGraph.AxisType.Date Then
                arrX = New ArrayList
                arrX.Add(0.0)
            Else
                arrX = New ArrayList
                'arrX.Add(AldysGraph.XDate.XLDateToDateTime(mdblXAxisMin))
                'arrX.Add(mdblXAxisMin)
                arrX.Add(0.0)
            End If
            arrY = New ArrayList
            arrY.Add(CDbl(0.0))

            objOnlineCurve = AldysPane.AddCurve(strCurveName, arrX, arrY, curveColor, symbol)
            objOnlineCurve.Symbol.IsFilled = True
            objOnlineCurve.AddPointFlg = True
            objOnlineCurve.Line.Style = System.Drawing.Drawing2D.DashStyle.Solid

            If blnIsColoredGraph Then
                objOnlineCurve.CL = New ArrayList
            End If

            AldysPane.CurveList.isResizing = False
            AldysPane.IsIgnoreInitial = True

            mblnIsOnlineCurveStarted = True
            mblnIsOnlineGraphRunning = False
            mblnIsOnlineGraphStopped = False

            AldysPane.AxisChange()
            Invalidate()

            Return objOnlineCurve

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

    Public Sub PlotPoint(ByRef OnlineCurve As AldysGraph.CurveItem, _
                         ByVal dblX As Double, ByVal dblY As Double, Optional ByVal blnIsColoredGraph As Boolean = False)
        '=====================================================================
        ' Procedure Name        : PlotPoint
        ' Parameters Passed     : x and y co-ordinate values.
        ' Returns               : None
        ' Purpose               : To plot the next consecutive point the online curve.
        ' Description           : 
        ' Assumptions           : 
        '                         
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 28-Nov-2006 04:20 PM
        ' Revisions             : 1
        '=====================================================================
        Try
            '---If online graph is stopped then don't plot 
            '---any further point.
            If Not mblnIsOnlineGraphStopped Then
                If (mblnIsOnlineCurveStarted) Then
                    mblnIsOnlineCurveStarted = False
                    mblnIsOnlineGraphRunning = True

                    OnlineCurve.X.RemoveAt(0)
                    OnlineCurve.Y.RemoveAt(0)
                End If

                If blnIsColoredGraph Then
                    'Dim CurveSegmentColor As Color
                    'CurveSegmentColor = Color.Red
                    'OnlineCurve.CL.Add(CurveSegmentColor)
                End If

                OnlineCurve.X.Add(dblX)
                OnlineCurve.Y.Add(dblY)

                AldysPane.IsIgnoreInitial = False
                AldysPane.AxisChange()
                Invalidate()
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

    Public Sub StopOnlineGraph(ByRef OnlineCurve As AldysGraph.CurveItem)
        '=====================================================================
        ' Procedure Name        : StopOnlineGraph
        ' Parameters Passed     : Reference to the Online CurveItem
        ' Returns               : None
        ' Purpose               : To stop the online plotting of curve and
        '                         enable each point info to show to user.
        ' Description           : 
        ' Assumptions           : 
        '                         
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 28-Nov-2006 04:20 PM
        ' Revisions             : 1
        '=====================================================================
        Dim curve As AldysGraph.CurveItem
        Dim intCounter As Integer

        Try
            For intCounter = 0 To AldysPane.CurveList.Count - 1
                curve = AldysPane.CurveList.Item(intCounter)
                If curve Is OnlineCurve Then
                    '---Stop the online running of the graph
                    mblnIsOnlineGraphStopped = True
                    OnlineCurve.X.Add(curve.X.Item(curve.X.Count - 1))
                    OnlineCurve.Y.Add(curve.Y.Item(curve.Y.Count - 1))
                    Exit For
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
    End Sub

    Public Sub RestartOnlineGraph(ByRef OnlineCurve As AldysGraph.CurveItem)
        '=====================================================================
        ' Procedure Name        : RestartOnlineGraph
        ' Parameters Passed     : Reference to the Online CurveItem
        ' Returns               : None
        ' Purpose               : To re-start the online plotting of curve 
        ' Description           : 
        ' Assumptions           : 
        '                         
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 28-Nov-2006 04:20 PM
        ' Revisions             : 1
        '=====================================================================
        Dim curve As AldysGraph.CurveItem
        Dim intCounter As Integer

        Try
            For intCounter = 0 To AldysPane.CurveList.Count - 1
                curve = AldysPane.CurveList.Item(intCounter)
                If curve Is OnlineCurve Then
                    '---Restart the online running of the graph
                    mblnIsOnlineGraphStopped = False
                    Exit For
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
    End Sub

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

    Public Function SetDefaultSettingsToGraph() As Boolean

        Try
            btnPeakEdit.Checked = False
            AldysPane.Legend.IsVisible = True
            AldysPane.Legend.FillColor = mobjDefaultSettings.Legend.FillColor
            AldysPane.Legend.FrameColor = mobjDefaultSettings.Legend.FrameColor
            AldysPane.Legend.IsFilled = mobjDefaultSettings.Legend.IsFilled
            AldysPane.Legend.IsFramed = mobjDefaultSettings.Legend.IsFramed

            AldysPane.FontSpec.FontColor = mobjDefaultSettings.Pane.FontColor
            AldysPane.FontSpec.FrameColor = mobjDefaultSettings.Pane.FrameColor
            AldysPane.FontSpec.FillColor = mobjDefaultSettings.Pane.BackColor
            AldysPane.FontSpec.Size = mobjDefaultSettings.Pane.FontSize
            AldysPane.FontSpec.Family = mobjDefaultSettings.Pane.FontFamily
            AldysPane.FontSpec.IsBold = mobjDefaultSettings.Pane.FontBold
            AldysPane.FontSpec.IsItalic = mobjDefaultSettings.Pane.FontItalic
            AldysPane.FontSpec.IsUnderline = mobjDefaultSettings.Pane.FontUnderline

            AldysPane.XAxis.GridColor = Color.FromArgb(175, 200, 245) '  mobjDefaultSettings.Axis.GridColor
            AldysPane.XAxis.IsShowGrid = True                         'Saurabh    mobjDefaultSettings.Axis.IsShowGrid
            AldysPane.XAxis.IsShowGrid = True                         'Saurabh    mobjDefaultSettings.Axis.IsShowGrid
            AldysPane.XAxis.TitleFontSpec.FillColor = Color.Transparent
            AldysPane.XAxis.TitleFontSpec.FrameColor = mobjDefaultSettings.Axis.FrameColor
            AldysPane.XAxis.TitleFontSpec.FontColor = mobjDefaultSettings.Axis.TitleFontColor
            AldysPane.XAxis.TitleFontSpec.Size = mobjDefaultSettings.Axis.TitleFontSize
            AldysPane.XAxis.TitleFontSpec.IsFramed = False
            AldysPane.XAxis.TitleFontSpec.IsFilled = False
            AldysPane.XAxis.TitleFontSpec.IsBold = mobjDefaultSettings.Axis.TitleFontBold
            AldysPane.XAxis.TitleFontSpec.IsItalic = mobjDefaultSettings.Axis.TitleFontItalic
            AldysPane.XAxis.TitleFontSpec.IsUnderline = mobjDefaultSettings.Axis.TitleFontUnderline
            AldysPane.XAxis.TitleFontSpec.Family = mobjDefaultSettings.Axis.TitleFontFamily
            AldysPane.XAxis.ScaleFontSpec.Family = mobjDefaultSettings.Axis.ScaleFontFamily
            AldysPane.XAxis.ScaleFontSpec.IsBold = mobjDefaultSettings.Axis.ScaleFontBold
            AldysPane.XAxis.ScaleFontSpec.IsItalic = mobjDefaultSettings.Axis.ScaleFontItalic
            AldysPane.XAxis.ScaleFontSpec.IsUnderline = mobjDefaultSettings.Axis.ScaleFontUnderline

            AldysPane.YAxis.GridColor = Color.FromArgb(175, 200, 245) 'mobjDefaultSettings.Axis.GridColor
            AldysPane.YAxis.IsShowGrid = True                         'Sauarbh  mobjDefaultSettings.Axis.IsShowGrid
            AldysPane.YAxis.IsShowGrid = True                         'Sauarbh  mobjDefaultSettings.Axis.IsShowGrid
            AldysPane.YAxis.TitleFontSpec.FillColor = Color.Transparent
            AldysPane.YAxis.TitleFontSpec.FrameColor = mobjDefaultSettings.Axis.FrameColor
            AldysPane.YAxis.TitleFontSpec.FontColor = mobjDefaultSettings.Axis.TitleFontColor
            AldysPane.YAxis.TitleFontSpec.Size = mobjDefaultSettings.Axis.TitleFontSize
            AldysPane.YAxis.TitleFontSpec.IsFramed = False
            AldysPane.YAxis.TitleFontSpec.IsFilled = False
            AldysPane.YAxis.TitleFontSpec.IsBold = mobjDefaultSettings.Axis.TitleFontBold
            AldysPane.YAxis.TitleFontSpec.IsItalic = mobjDefaultSettings.Axis.TitleFontItalic
            AldysPane.YAxis.TitleFontSpec.IsUnderline = mobjDefaultSettings.Axis.TitleFontUnderline
            AldysPane.YAxis.TitleFontSpec.Family = mobjDefaultSettings.Axis.TitleFontFamily
            AldysPane.YAxis.ScaleFontSpec.Family = mobjDefaultSettings.Axis.ScaleFontFamily
            AldysPane.YAxis.ScaleFontSpec.IsBold = mobjDefaultSettings.Axis.ScaleFontBold
            AldysPane.YAxis.ScaleFontSpec.IsItalic = mobjDefaultSettings.Axis.ScaleFontItalic
            AldysPane.YAxis.ScaleFontSpec.IsUnderline = mobjDefaultSettings.Axis.ScaleFontUnderline

            AldysPane.PaneBackColor = Color.Transparent 'mobjDefaultSettings.Pane.BackColor
            AldysPane.PaneFrameColor = Color.Transparent 'mobjDefaultSettings.Pane.FrameColor
            AldysPane.IsPaneFramed = False ' mobjDefaultSettings.Pane.IsFramed

            AldysPane.AxisBackColor = Color.Transparent 'mobjDefaultSettings.Axis.BackColor
            AldysPane.AxisFrameColor = Color.FromArgb(175, 200, 245) 'mobjDefaultSettings.Axis.FrameColor
            AldysPane.IsAxisFramed = True 'mobjDefaultSettings.Axis.IsFramed
            AldysPane.IsShowTitle = False

            '---------------------------------
            Me.CustPan.GradientMode = GradientPanel.LinearGradientMode.Vertical
            Me.CustPan.BackColor = Color.Gainsboro
            Me.CustPan.BackColor2 = Color.White
            '---------------------------------

            ''---added by deepak b on 09.02.06 
            ''---for curve lebels 
            'If btnShowCurveLabels.Checked = True Then
            '    Me.AldysPane.ShowCurveLabels = True
            '    Me.AldysPane.DrawCurveLabels()
            '    Me.Invalidate()
            'End If

            '---Added by Mangesh S. on 10-Jan-2007
            AldysPane.XAxis.Type = AldysGraph.AxisType.Linear
            AldysPane.XAxis.Max = 100
            AldysPane.XAxis.Min = 0
            AldysPane.XAxis.StepAuto = True
            AldysPane.XAxis.MinorStepAuto = True

            AldysPane.YAxis.Type = AldysGraph.AxisType.Linear
            AldysPane.YAxis.Max = 100
            AldysPane.YAxis.Min = 0
            AldysPane.YAxis.StepAuto = True
            AldysPane.YAxis.MinorStepAuto = True

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

    Public Function ShowPointInfo(ByRef Curve As AldysGraph.CurveItem) As Boolean
        '=====================================================================
        ' Procedure Name        : ShowPointInfo
        ' Parameters Passed     : Reference to the Online CurveItem
        ' Returns               : True or false
        ' Purpose               : To enable Point Info window to be displayed
        '                         at left click of mouse near point.
        ' Description           : 
        ' Assumptions           : 
        '                         
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 02:00 PM
        ' Revisions             : 1
        '=====================================================================
        Dim curveToCheck As AldysGraph.CurveItem
        Dim intCounter As Integer

        Try
            For intCounter = 0 To AldysPane.CurveList.Count - 1
                curveToCheck = AldysPane.CurveList.Item(intCounter)
                If curveToCheck Is Curve Then
                    Call EnableShowPointInfo(intCounter, True)
                    Return True
                    Exit For
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

    Public Function StartScatteredPointsCurve(ByVal PointSymbol As AldysGraph.SymbolType) As AldysGraph.CurveItem
        '=====================================================================
        ' Procedure Name        : PlotScatteredPoints
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To plot the Scattered Points on graph 
        ' Description           : 
        ' Assumptions           : 
        '                         
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 05-Feb-2007 02:45 PM
        ' Revisions             : 1
        '=====================================================================
        Dim objScatteredPointsCurve As AldysGraph.CurveItem
        Dim arrX As ArrayList
        Dim arrY As ArrayList
        Dim strCurveName As String
        Dim curveColor As Color

        Try
            Me.AldysPane.XAxis.Title = mstrXAxisLabel
            Me.AldysPane.XAxis.Type = mXAxisType

            If mXAxisType = AldysGraph.AxisType.Date Then
                Me.AldysPane.XAxis.MaxAuto = True
                Me.AldysPane.XAxis.MinAuto = True
                Me.AldysPane.XAxis.StepAuto = True
                Me.AldysPane.XAxis.MinorStepAuto = True
            Else
                Me.AldysPane.XAxis.MaxAuto = False
                Me.AldysPane.XAxis.MinAuto = False
                Me.AldysPane.XAxis.StepAuto = False
                Me.AldysPane.XAxis.MinorStepAuto = False

                Me.AldysPane.XAxis.Min = mdblXAxisMin
                Me.AldysPane.XAxis.Max = mdblXAxisMax
                Me.AldysPane.XAxis.MinorStep = mdblXAxisMinorStep
                Me.AldysPane.XAxis.Step = mdblXAxisStep
            End If

            Me.AldysPane.YAxis.Type = mYAxisType
            Me.AldysPane.YAxis.Title = mstrYAxisLabel
            Me.AldysPane.YAxis.Min = mdblYAxisMin
            Me.AldysPane.YAxis.Max = mdblYAxisMax
            Me.AldysPane.YAxis.MinorStep = mdblYAxisMinorStep
            Me.AldysPane.YAxis.Step = mdblYAxisStep

            If Not mXAxisType = AldysGraph.AxisType.Date Then
                arrX = New ArrayList
                arrX.Add(0.0)
            Else
                arrX = New ArrayList
                'arrX.Add(AldysGraph.XDate.XLDateToDateTime(mdblXAxisMin))
                'arrX.Add(mdblXAxisMin)
                arrX.Add(0.0)
            End If

            arrY = New ArrayList
            arrY.Add(CDbl(0.0))

            strCurveName = "Scattered Points"
            curveColor = Color.Black

            objScatteredPointsCurve = AldysPane.AddCurve(strCurveName, arrX, arrY, curveColor, PointSymbol)

            objScatteredPointsCurve.IsScatteredPointsCurve = True

            objScatteredPointsCurve.Symbol.IsFilled = True
            objScatteredPointsCurve.AddPointFlg = True
            objScatteredPointsCurve.Line.Style = System.Drawing.Drawing2D.DashStyle.Solid

            AldysPane.CurveList.isResizing = False
            AldysPane.IsIgnoreInitial = True

            mblnIsOnlineCurveStarted = True
            mblnIsOnlineGraphRunning = False
            mblnIsOnlineGraphStopped = False

            AldysPane.AxisChange()
            Invalidate()

            If IO.File.Exists(Application.StartupPath & "\Images\HAND.CUR") Then
                Me.AldysGraphCursor = New Cursor(Application.StartupPath & "\Images\HAND.CUR")
            End If

            Return objScatteredPointsCurve

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

    Public Function PlotScatteredPoints(ByRef ScatteredPointsCurve As AldysGraph.CurveItem, ByVal blnIsInValid As Boolean, _
                                        Optional ByVal objStandard As Method.clsAnalysisStdParameters = Nothing, _
                                        Optional ByVal objSample As Method.clsAnalysisSampleParameters = Nothing, _
                                        Optional ByVal blnIsEmmission As Boolean = False, Optional ByVal InIsUse_btnRemove As Boolean = True) As Boolean
        '=====================================================================
        ' Procedure Name        : PlotScatteredPoints
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 05-Feb-2007 04:20 pm
        ' Revisions             : 1
        '=====================================================================
        Dim objPoint As AldysGraph.Point

        Static Dim intStdPointIndex As Integer
        Static Dim intSamplePointIndex As Integer

        
        Dim intPointIdx As Integer = -1
        Dim blnIsPointFound As Boolean = False
        Dim objDuplicatePoint As AldysGraph.Point
        Dim objRestorePont As ArrayList
        Dim pointinfo As AldysGraph.Point._point_info
        Dim PointsNo As Integer
        'Dim strSampleInfoToShow As String

        Try
            If (ScatteredPointsCurve.IsScatteredPointsCurve) Then
                If Not IsNothing(objStandard) Then
                    'pointinfo = New AldysGraph.Point._point_info
                    'objPoint.pointinfo = New AldysGraph.Point.

                    pointinfo = New AldysGraph.Point._point_info(objStandard.StdNumber, objStandard.StdName, objStandard.Used, AldysGraph.Point.points_type.Std)
                    objPoint = New AldysGraph.Point(objStandard.Concentration, objStandard.Abs, intStdPointIndex, blnIsInValid)
                    intStdPointIndex += 1
                    objPoint.PointHeading = "Standard Information"

                    'Commented and added by Sachin Dokahle
                    'objPoint.PointColor = ClsAAS203.STDCOLOR
                    If objStandard.Used = False Then
                        objPoint.PointColor = ClsAAS203.BLACKCOLOR
                        objPoint.IsUse_btnRemove = True

                    Else
                        objPoint.PointColor = ClsAAS203.STDCOLOR
                        objPoint.IsUse_btnRemove = InIsUse_btnRemove
                    End If
                    'pointinfo = New AldysGraph.Point._point_info(objStandard.StdNumber, objStandard.StdName, objStandard.Used, AldysGraph.Point.points_type.Std)
                    pointinfo.IsUsed = objStandard.Used
                    pointinfo.PointNo = objStandard.StdNumber
                    pointinfo.PointsName = objStandard.StdName
                    pointinfo.PointsType = AldysGraph.Point.points_type.Std
                    'objPoint.PointRadius = 2.0!

                    If IsNothing(objPoint.UserData) Then objPoint.UserData = New ArrayList
                    objPoint.UserData.Add("Standard No.      : " & objStandard.StdNumber)
                    objPoint.UserData.Add("Standard Name     : " & objStandard.StdName)
                    objPoint.UserData.Add("Concentration     : " & objStandard.Concentration)

                    If blnIsEmmission Then
                        objPoint.UserData.Add("Emission         : " & FormatNumber(objStandard.Abs, CONST_Format_Value_Emission))       'Saurabh Format to 3 decimal places 31.07.07
                    Else
                        objPoint.UserData.Add("Absorbance        : " & FormatNumber(objStandard.Abs, CONST_Format_Value_Absorbance))    'Saurabh Format to 3 decimal places 31.07.07
                    End If
                    PointsNo = objStandard.StdNumber
                    'objPoint.pointinfo = new AldysGraph.Point._point_info( 

                    objPoint.pointinfo = New Collections.ArrayList
                    objPoint.pointinfo.Add(pointinfo)
                    ScatteredPointsCurve.ScatteredPoints.Add(objPoint)
                End If

                If Not IsNothing(objSample) Then
                    CONST_dblXpointTolerance = (Me.XAxisMax - Me.XAxisMin) * dblXFator / 100
                    CONST_dblYpointTolerance = (Me.YAxisMax - Me.YAxisMin) * dblXFator / 100

                    blnIsPointFound = False
                    objPoint = New AldysGraph.Point(objSample.Conc, objSample.Abs, intSamplePointIndex, blnIsInValid)
                    objPoint.pointinfo = New Collections.ArrayList
                    intSamplePointIndex += 1
                    'Commented and added by Sachin Dokahle
                    'objPoint.PointColor = ClsAAS203.SAMPCOLOR
                    pointinfo = New AldysGraph.Point._point_info
                    'If objSample.Used = False Then
                    '    objPoint.PointColor = ClsAAS203.BLACKCOLOR
                    'Else
                    '    objPoint.PointColor = ClsAAS203.SAMPCOLOR
                    'End If

                    pointinfo.IsUsed = objSample.Used
                    pointinfo.PointNo = PointsNo + objSample.SampNumber
                    pointinfo.PointsName = objSample.SampleName
                    'pointinfo.PointsType = AldysGraph.Point.points_type.Samp
                    'objPoint.PointRadius = 2.0!

                    If IsNothing(objPoint.UserData) Then objPoint.UserData = New ArrayList
                    If Not (ScatteredPointsCurve.ScatteredPoints) Is Nothing Then
                        If (ScatteredPointsCurve.ScatteredPoints.Count > 0) Then
                            objRestorePont = New ArrayList
                            For intPointIdx = 0 To ScatteredPointsCurve.ScatteredPoints.Count - 1
                                objDuplicatePoint = ScatteredPointsCurve.ScatteredPoints(intPointIdx)
                                If (Math.Abs(objDuplicatePoint.X - objSample.Conc) <= CONST_dblXpointTolerance) And (Math.Abs(objDuplicatePoint.X - objSample.Conc) >= 0.0) And _
                                    (Math.Abs(objDuplicatePoint.Y - objSample.Abs) <= CONST_dblYpointTolerance) And (Math.Abs(objDuplicatePoint.Y - objSample.Abs) >= 0.0) Then
                                    blnIsPointFound = True
                                    objRestorePont = objDuplicatePoint.UserData.Clone
                                    Exit For
                                End If
                            Next
                        End If

                    End If

                    If blnIsPointFound = True Then

                        objPoint.UserData = objRestorePont.Clone
                        Dim ArrLstpointinfo As ArrayList = ScatteredPointsCurve.ScatteredPoints.Item(intPointIdx).pointinfo
                        objPoint.pointinfo = ArrLstpointinfo
                        Dim objPointInfo As AldysGraph.Point._point_info
                        Dim blnFundStd As Boolean = False
                        For Each objPointInfo In ArrLstpointinfo
                            If objPointInfo.PointsType = AldysGraph.Point.points_type.Std Then
                                blnFundStd = True
                            End If
                        Next

                        If blnFundStd = True Then
                            objPoint.PointHeading = "Std/Sample Information"
                            'If objSample.Used = False Then
                            If objPointInfo.IsUsed = False Then
                                objPoint.PointColor = ClsAAS203.YELLOW
                            Else
                                objPoint.PointColor = ClsAAS203.GREEN
                            End If
                            If ScatteredPointsCurve.ScatteredPoints.Item(intPointIdx).IsUse_btnRemove = True Then
                                objPoint.IsUse_btnRemove = True
                            Else
                                objPoint.IsUse_btnRemove = False
                            End If
                            pointinfo.PointsType = AldysGraph.Point.points_type.StdSamp
                        Else
                            objPoint.PointHeading = "Sample Information"
                            If objSample.Used = False Then
                                objPoint.PointColor = ClsAAS203.BLACKCOLOR
                            Else
                                objPoint.PointColor = ClsAAS203.SAMPCOLOR
                            End If
                            pointinfo.PointsType = AldysGraph.Point.points_type.Samp
                            objPoint.IsUse_btnRemove = False
                        End If
                        'objPoint.pointinfo.Add(pointinfo)
                    Else
                        objPoint.PointHeading = "Sample Information"
                        If objSample.Used = False Then
                            objPoint.PointColor = ClsAAS203.BLACKCOLOR
                        Else
                            objPoint.PointColor = ClsAAS203.SAMPCOLOR
                        End If
                        objPoint.IsUse_btnRemove = False
                        pointinfo.PointsType = AldysGraph.Point.points_type.Samp
                    End If

                    objPoint.UserData.Add("Sample No.          : " & objSample.SampNumber)
                    objPoint.UserData.Add("Sample Name         : " & objSample.SampleName)
                    objPoint.UserData.Add("Concentration       : " & FormatNumber(objSample.Conc, 2))   'Saurabh Format to 2 decimal places 20.07.07
                    If blnIsEmmission Then
                        objPoint.UserData.Add("Emission        : " & FormatNumber(objSample.Abs, CONST_Format_Value_Emission))    'Saurabh Format to 3 decimal places 31.07.07
                    Else
                        objPoint.UserData.Add("Absorbance      : " & FormatNumber(objSample.Abs, CONST_Format_Value_Absorbance))    'Saurabh Format to 3 decimal places 31.07.07
                    End If
                    'objPoint.pointinfo.Add(pointinfo)

                    If blnIsPointFound = True And intPointIdx > -1 Then
                        'ScatteredPointsCurve.ScatteredPoints.Insert(intPointIdx, objPoint)
                        'If CType(objPoint.PointColor, System.Drawing.Color) Is CType(ClsAAS203.STDCOLOR, Color) Then


                        'End If
                        'For Each ArrLstpointinfo In ScatteredPointsCurve.ScatteredPoints.Item(intPointIdx).pointinfo

                        'Next

                        'Dim ArrLstpointinfo As ArrayList = ScatteredPointsCurve.ScatteredPoints.Item(intPointIdx).pointinfo
                        'objPoint.pointinfo = ArrLstpointinfo
                        objPoint.pointinfo.Add(pointinfo)
                        ScatteredPointsCurve.ScatteredPoints.Item(intPointIdx) = objPoint
                        '//ScatteredPointsCurve.ScatteredPoints.Item(intPointIdx).IsUse_btnRemove = True

                    Else
                        'ScatteredPointsCurve.ScatteredPoints.Item(intPointIdx).IsUse_btnRemove = True
                        'objPoint.IsUse_btnRemove = False
                        objPoint.pointinfo.Add(pointinfo)
                        ScatteredPointsCurve.ScatteredPoints.Add(objPoint)
                    End If

                End If
                '//ScatteredPointsCurve.ScatteredPoints.Add(objPoint)
                'ScatteredPointsCurve.ScatteredPoints(ScatteredPointsCurve.ScatteredPoints.Count-1).
                AldysPane.AxisChange()
                Invalidate()
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

#End Region

End Class
