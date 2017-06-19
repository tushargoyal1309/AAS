Imports AAS203.Common
Imports BgThread
''this is like supporting files.
Public Class frmTurretOptimisation ''class behind the class.
    Inherits System.Windows.Forms.Form
    Implements BgThread.Iclient

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal dblLampCurrent As Double, ByVal intLampPos As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mdblLampCurrent = dblLampCurrent
        mintLampPosition = intLampPos

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
    Friend WithEvents CustomPanelMain As GradientPanel.CustomPanel
    Friend WithEvents CustomPanel1 As GradientPanel.CustomPanel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents aasGraphTurretOptimisation As AAS203.AASGraph
    Friend WithEvents CustomPanel2 As GradientPanel.CustomPanel
    Friend WithEvents lblTurretOptimisation As System.Windows.Forms.Label
    Friend WithEvents lblTurretPosition As System.Windows.Forms.Label
    Friend WithEvents lblPMT As System.Windows.Forms.Label
    Friend WithEvents lblWavelengthStatus As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTurretOptimisation))
        Me.CustomPanelMain = New GradientPanel.CustomPanel
        Me.CustomPanel1 = New GradientPanel.CustomPanel
        Me.aasGraphTurretOptimisation = New AAS203.AASGraph
        Me.CustomPanel2 = New GradientPanel.CustomPanel
        Me.lblWavelengthStatus = New System.Windows.Forms.Label
        Me.lblTurretOptimisation = New System.Windows.Forms.Label
        Me.lblTurretPosition = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.lblPMT = New System.Windows.Forms.Label
        Me.CustomPanelMain.SuspendLayout()
        Me.CustomPanel1.SuspendLayout()
        Me.CustomPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'CustomPanelMain
        '
        Me.CustomPanelMain.BackColor = System.Drawing.Color.Transparent
        Me.CustomPanelMain.Controls.Add(Me.CustomPanel1)
        Me.CustomPanelMain.Controls.Add(Me.CustomPanel2)
        Me.CustomPanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanelMain.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanelMain.Name = "CustomPanelMain"
        Me.CustomPanelMain.Size = New System.Drawing.Size(404, 405)
        Me.CustomPanelMain.TabIndex = 0
        '
        'CustomPanel1
        '
        Me.CustomPanel1.BackColor = System.Drawing.Color.Transparent
        Me.CustomPanel1.Controls.Add(Me.aasGraphTurretOptimisation)
        Me.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanel1.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanel1.Name = "CustomPanel1"
        Me.CustomPanel1.Size = New System.Drawing.Size(404, 305)
        Me.CustomPanel1.TabIndex = 0
        '
        'aasGraphTurretOptimisation
        '
        Me.aasGraphTurretOptimisation.AldysGraphCursor = Nothing
        Me.aasGraphTurretOptimisation.AldysGraphPrintColor = System.Drawing.Color.Black
        Me.aasGraphTurretOptimisation.BackColor = System.Drawing.Color.LightGray
        Me.aasGraphTurretOptimisation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.aasGraphTurretOptimisation.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.aasGraphTurretOptimisation.GraphDataSource = Nothing
        Me.aasGraphTurretOptimisation.GraphImage = Nothing
        Me.aasGraphTurretOptimisation.IsShowGrid = True
        Me.aasGraphTurretOptimisation.Location = New System.Drawing.Point(0, 0)
        Me.aasGraphTurretOptimisation.Name = "aasGraphTurretOptimisation"
        Me.aasGraphTurretOptimisation.Size = New System.Drawing.Size(404, 305)
        Me.aasGraphTurretOptimisation.TabIndex = 3
        Me.aasGraphTurretOptimisation.UseDefaultSettings = False
        Me.aasGraphTurretOptimisation.XAxisDateMax = New Date(CType(0, Long))
        Me.aasGraphTurretOptimisation.XAxisDateMin = New Date(CType(0, Long))
        Me.aasGraphTurretOptimisation.XAxisDateScaleFormat = AAS203.AASGraph.enumDateScaleFormat.YYYY
        Me.aasGraphTurretOptimisation.XAxisLabel = "TURRET STEP"
        Me.aasGraphTurretOptimisation.XAxisMax = 100
        Me.aasGraphTurretOptimisation.XAxisMin = 0
        Me.aasGraphTurretOptimisation.XAxisMinorStep = 5
        Me.aasGraphTurretOptimisation.XAxisScaleFormat = Nothing
        Me.aasGraphTurretOptimisation.XAxisStep = 10
        Me.aasGraphTurretOptimisation.XAxisType = AldysGraph.AxisType.Linear
        Me.aasGraphTurretOptimisation.YAxisLabel = "ENERGY"
        Me.aasGraphTurretOptimisation.YAxisMax = 100
        Me.aasGraphTurretOptimisation.YAxisMin = 0
        Me.aasGraphTurretOptimisation.YAxisMinorStep = 5
        Me.aasGraphTurretOptimisation.YAxisScaleFormat = Nothing
        Me.aasGraphTurretOptimisation.YAxisStep = 10
        Me.aasGraphTurretOptimisation.YAxisType = AldysGraph.AxisType.Linear
        '
        'CustomPanel2
        '
        Me.CustomPanel2.BackColor = System.Drawing.Color.Transparent
        Me.CustomPanel2.Controls.Add(Me.lblWavelengthStatus)
        Me.CustomPanel2.Controls.Add(Me.lblTurretOptimisation)
        Me.CustomPanel2.Controls.Add(Me.lblTurretPosition)
        Me.CustomPanel2.Controls.Add(Me.btnClose)
        Me.CustomPanel2.Controls.Add(Me.lblPMT)
        Me.CustomPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CustomPanel2.Location = New System.Drawing.Point(0, 305)
        Me.CustomPanel2.Name = "CustomPanel2"
        Me.CustomPanel2.Size = New System.Drawing.Size(404, 100)
        Me.CustomPanel2.TabIndex = 4
        '
        'lblWavelengthStatus
        '
        Me.lblWavelengthStatus.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWavelengthStatus.ForeColor = System.Drawing.Color.Blue
        Me.lblWavelengthStatus.Location = New System.Drawing.Point(5, 71)
        Me.lblWavelengthStatus.Name = "lblWavelengthStatus"
        Me.lblWavelengthStatus.Size = New System.Drawing.Size(210, 24)
        Me.lblWavelengthStatus.TabIndex = 4
        '
        'lblTurretOptimisation
        '
        Me.lblTurretOptimisation.BackColor = System.Drawing.Color.White
        Me.lblTurretOptimisation.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurretOptimisation.ForeColor = System.Drawing.Color.Blue
        Me.lblTurretOptimisation.Location = New System.Drawing.Point(5, 6)
        Me.lblTurretOptimisation.Name = "lblTurretOptimisation"
        Me.lblTurretOptimisation.Size = New System.Drawing.Size(395, 16)
        Me.lblTurretOptimisation.TabIndex = 2
        Me.lblTurretOptimisation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTurretPosition
        '
        Me.lblTurretPosition.BackColor = System.Drawing.Color.White
        Me.lblTurretPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTurretPosition.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurretPosition.ForeColor = System.Drawing.Color.Blue
        Me.lblTurretPosition.Location = New System.Drawing.Point(5, 44)
        Me.lblTurretPosition.Name = "lblTurretPosition"
        Me.lblTurretPosition.Size = New System.Drawing.Size(395, 16)
        Me.lblTurretPosition.TabIndex = 0
        Me.lblTurretPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(320, 70)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(74, 22)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        Me.btnClose.Visible = False
        '
        'lblPMT
        '
        Me.lblPMT.BackColor = System.Drawing.Color.White
        Me.lblPMT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPMT.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPMT.ForeColor = System.Drawing.Color.Blue
        Me.lblPMT.Location = New System.Drawing.Point(5, 25)
        Me.lblPMT.Name = "lblPMT"
        Me.lblPMT.Size = New System.Drawing.Size(395, 16)
        Me.lblPMT.TabIndex = 1
        Me.lblPMT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmTurretOptimisation
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(404, 405)
        Me.ControlBox = False
        Me.Controls.Add(Me.CustomPanelMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTurretOptimisation"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TURRET OPTIMIZATION"
        Me.CustomPanelMain.ResumeLayout(False)
        Me.CustomPanel1.ResumeLayout(False)
        Me.CustomPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Class Member Variables "

    Private mController As clsBgThread
    Private mblnStop As Boolean = False
    Private mdblLampCurrent As Double
    Private mintLampPosition As Integer
    Private mintOccurence As Integer = 0
    Private mintOccurence2 As Integer = 0
    Private mintOccurence3 As Integer = 0
    Private mintOccurence4 As Integer = 0
    Private mintOccurence5 As Integer = 0
    Private mintOccurence6 As Integer = 0

    Private TurretOptimizationThread As New clsBgTurretOptimization
    Dim mobjCurve As AldysGraph.CurveItem

#End Region

#Region " Form Events "

    Private Sub frmTurretOptimisation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ''  '=====================================================================
        ' Procedure Name        : frmTurretOptimisation_Load
        ' Parameters Passed     : 
        ' Returns               : None
        ' Purpose               : 
        ' Description           : do some initialization here .
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 24-Jan-2007 04:15 pm
        ' Revisions             : 1
        '=====================================================================
        ''note:
        ''this is called when form is loaded 
        ''do some initialization here .
        ''like setr the arrengement , setthe validation. etc.


        'used for uv graph control
        'agTurretOptimisation.xmin = 10
        'agTurretOptimisation.Xmax = 100
        'agTurretOptimisation.xdiv = 5
        'agTurretOptimisation.xlabel = "Turret Step"
        'agTurretOptimisation.ymin = 10
        'agTurretOptimisation.ymax = 100
        'agTurretOptimisation.ydiv = 5
        'agTurretOptimisation.ylabel = "Energy"
        'agTurretOptimisation.Refresh()

        '---Added By Mangesh 
        'update aasGraphTurretOptimisation data structure for graph display
        aasGraphTurretOptimisation.XAxisMin = 0     'Repalce 1 and added 0 by Saurabh 26 May 2007
        'aasGraphTurretOptimisation.XAxisMax = 100 original
        'aasGraphTurretOptimisation.XAxisStep = 10 original

        aasGraphTurretOptimisation.XAxisMax = 300 'made changes by suraj
        aasGraphTurretOptimisation.XAxisStep = 30 'made changes by suraj
        aasGraphTurretOptimisation.XAxisMinorStep = 5
        aasGraphTurretOptimisation.XAxisLabel = "TURRET STEP"
        aasGraphTurretOptimisation.XAxisType = AldysGraph.AxisType.Linear

        aasGraphTurretOptimisation.YAxisMin = 0
        aasGraphTurretOptimisation.YAxisMax = 80
        aasGraphTurretOptimisation.YAxisStep = 10
        aasGraphTurretOptimisation.YAxisMinorStep = 5
        aasGraphTurretOptimisation.YAxisLabel = "ENERGY"
        aasGraphTurretOptimisation.YAxisType = AldysGraph.AxisType.Linear

        aasGraphTurretOptimisation.AldysPane.AxisChange()
        aasGraphTurretOptimisation.Invalidate()
        '---Added By Mangesh 

        btnClose.Visible = False

    End Sub

    Private Sub frmTurretOptimisation_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ''  '=====================================================================
        ' Procedure Name        : frmTurretOptimisation_Closing
        ' Parameters Passed     : 
        ' Returns               : None
        ' Purpose               : 
        ' Description           : to close the optimisation form.
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 24-Jan-2007 04:15 pm
        ' Revisions             : 1
        '=====================================================================

        ''note:
        ''this is called when user close the form.
        ''stop the thread here if it running.
        If mController.IsThreadRunning Then
            mController.Cancel()
        End If
    End Sub

#End Region

#Region " IClient Events for receiving the Turrent Position value from thread "

    Public Sub Completed(ByVal Cancelled As Boolean) Implements BgThread.Iclient.Completed
        ''  '=====================================================================
        ' Procedure Name        : Completed
        ' Parameters Passed     : 
        ' Returns               : bool flag for cancel.
        ' Purpose               : 
        ' Description           : to completed the thread.
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 24-Jan-2007 04:15 pm
        ' Revisions             : 1
        '=====================================================================
        If Cancelled = False Then
            'Me.DialogResult = DialogResult.OK
            'btnClose.Visible = True

            '---Added By Mangesh 
            If Not IsNothing(mobjCurve) Then
                aasGraphTurretOptimisation.StopOnlineGraph(mobjCurve)
                ''stop the online graph here.
                aasGraphTurretOptimisation.DrawHighestPeakLine(mobjCurve)
                'Draw highest peak line
                aasGraphTurretOptimisation.ShowHighPeakLineLabel("Optimized Position", False, 0)
                'show highpeakline label
            End If
            'mblnStop = True
            '---Added By Mangesh 
            'Me.DialogResult = DialogResult.OK
        Else
            mblnStop = True
            Me.DialogResult = DialogResult.OK
        End If
    End Sub

    Public Sub Display(ByVal Text As String) Implements BgThread.Iclient.Display
        ''  '=====================================================================
        ' Procedure Name        : Display
        ' Parameters Passed     : 
        ' Returns               : string to be displayed.
        ' Purpose               : 
        ' Description           : for displaying a graph.
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : 
        ' Created               : 24-Jan-2007 04:15 pm
        ' Revisions             : 1
        '=====================================================================
        Dim strDataValues() As String
        Dim dblX, dblY As Double
        Dim intOcc As Integer
        Try
            If Not Text = String.Empty Then
                strDataValues = Text.Split(","c)
                ''split a passed string and stroe it a string variable.

                If strDataValues.Length > 0 Then

                    dblX = CDbl(strDataValues(0))
                    dblY = CDbl(strDataValues(1))
                    intOcc = CInt(strDataValues(2))
                    ''get a seprated value from string 
                    ''like x,y value.

                    Select Case intOcc
                        Case 1
                            mintOccurence = mintOccurence + 1
                            If mintOccurence = 1 Then
                                mobjCurve = aasGraphTurretOptimisation.StartOnlineGraph("ENERGY", Color.Red, AldysGraph.SymbolType.NoSymbol)
                                aasGraphTurretOptimisation.PlotPoint(mobjCurve, dblX, dblY)
                            Else
                                aasGraphTurretOptimisation.PlotPoint(mobjCurve, dblX, dblY)
                            End If
                        Case 2
                            mintOccurence2 = mintOccurence2 + 1
                            If mintOccurence2 = 1 Then
                                mobjCurve = aasGraphTurretOptimisation.StartOnlineGraph("ENERGY", Color.Red, AldysGraph.SymbolType.NoSymbol)
                                aasGraphTurretOptimisation.PlotPoint(mobjCurve, dblX, dblY)
                            Else
                                aasGraphTurretOptimisation.PlotPoint(mobjCurve, dblX, dblY)
                            End If
                        Case 3
                            mintOccurence3 = mintOccurence3 + 1
                            If mintOccurence3 = 1 Then
                                mobjCurve = aasGraphTurretOptimisation.StartOnlineGraph("ENERGY", Color.Red, AldysGraph.SymbolType.NoSymbol)
                                aasGraphTurretOptimisation.PlotPoint(mobjCurve, dblX, dblY)
                            Else
                                aasGraphTurretOptimisation.PlotPoint(mobjCurve, dblX, dblY)
                            End If
                        Case 4
                            mintOccurence4 = mintOccurence4 + 1
                            If mintOccurence4 = 1 Then
                                mobjCurve = aasGraphTurretOptimisation.StartOnlineGraph("ENERGY", Color.Red, AldysGraph.SymbolType.NoSymbol)
                                aasGraphTurretOptimisation.PlotPoint(mobjCurve, dblX, dblY)
                            Else
                                aasGraphTurretOptimisation.PlotPoint(mobjCurve, dblX, dblY)
                            End If
                        Case 5
                            mintOccurence5 = mintOccurence5 + 1
                            If mintOccurence5 = 1 Then
                                mobjCurve = aasGraphTurretOptimisation.StartOnlineGraph("ENERGY", Color.Red, AldysGraph.SymbolType.NoSymbol)
                                aasGraphTurretOptimisation.PlotPoint(mobjCurve, dblX, dblY)
                            Else
                                aasGraphTurretOptimisation.PlotPoint(mobjCurve, dblX, dblY)
                            End If
                        Case 6
                            mintOccurence6 = mintOccurence6 + 1
                            If mintOccurence6 = 1 Then
                                mobjCurve = aasGraphTurretOptimisation.StartOnlineGraph("ENERGY", Color.Red, AldysGraph.SymbolType.NoSymbol)
                                aasGraphTurretOptimisation.PlotPoint(mobjCurve, dblX, dblY)
                            Else
                                aasGraphTurretOptimisation.PlotPoint(mobjCurve, dblX, dblY)
                            End If
                    End Select

                    'update graph data structure
                    aasGraphTurretOptimisation.AldysPane.XAxis.PickScale(aasGraphTurretOptimisation.XAxisMin, aasGraphTurretOptimisation.XAxisMax)
                    aasGraphTurretOptimisation.AldysPane.XAxis.StepAuto = True
                    aasGraphTurretOptimisation.AldysPane.XAxis.MinorStepAuto = True

                    aasGraphTurretOptimisation.AldysPane.YAxis.PickScale(aasGraphTurretOptimisation.YAxisMin, aasGraphTurretOptimisation.YAxisMax)
                    aasGraphTurretOptimisation.AldysPane.YAxis.StepAuto = True
                    aasGraphTurretOptimisation.AldysPane.YAxis.MinorStepAuto = True

                    aasGraphTurretOptimisation.AldysPane.AxisChange()
                    aasGraphTurretOptimisation.Invalidate()

                    Application.DoEvents()
                    ''allow application to perfrom its panding work.

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

    Public Sub Failed(ByVal e As System.Exception) Implements BgThread.Iclient.Failed
        ''not in used
    End Sub

    Public Sub Start(ByVal clsBgThread As BgThread.clsBgThread) Implements BgThread.Iclient.Start
        ''not in used
    End Sub

#End Region

#Region " Public Functions "

    Public Sub StartOptimizeTread()

        ''  '=====================================================================
        ' Procedure Name        : StartOptimizeTread
        ' Parameters Passed     : 
        ' Returns               : 
        ' Purpose               : 
        ' Description           : for starting a thread.
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : 
        ' Created               : 24-Jan-2007 04:15 pm
        ' Revisions             : 1
        '=====================================================================
        ''note:
        ''this is used to start a thread 
        ''first initialise  the object of thread with needed info.
        ''then call a function for starting a thread.
        mController = New clsBgThread(Me)

        'Saurabh 06-06-2007 added parameter lblWavelengthStatus
        'TurretOptimizationThread = New clsBgTurretOptimization(lblPMT, lblTurretPosition, lblTurretOptimisation, mdblLampCurrent, mintLampPosition, aasGraphTurretOptimisation)
        'create object for turret optimization thread
        TurretOptimizationThread = New clsBgTurretOptimization(lblPMT, lblTurretPosition, lblTurretOptimisation, mdblLampCurrent, mintLampPosition, aasGraphTurretOptimisation, lblWavelengthStatus)
        'Saurabh 06-06-2007

        ''TurretOptimizationThread = New clsBgTurretOptimization(lblPMT, lblTurretPosition, lblTurretOptimisation, mdblLampCurrent, mintLampPosition, aasGraphTurretOptimisation)
        'start turret optimization thread
        mController.Start(TurretOptimizationThread)

        'mController.Start(New clsBgTurretOptimization(mdblLampCurrent, mintLampPosition))
    End Sub

#End Region

#Region " Private Functions"

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        ''  '=====================================================================
        ' Procedure Name        : btnClose_Click
        ' Parameters Passed     : 
        ' Returns               : 
        ' Purpose               : 
        ' Description           : for clodeing a form.
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : 
        ' Created               : 24-Jan-2007 04:15 pm
        ' Revisions             : 1
        '=====================================================================
        'update dialog result
        Me.DialogResult = DialogResult.OK
    End Sub

#End Region


End Class

