Imports BgThread
Imports AAS203.Common


Public Class frmBurnerOptimisation
    Inherits System.Windows.Forms.Form
    Implements BgThread.Iclient

    ' This form object is used to perform opration for Burner height optimisation and 
    ' Fuel optimisation

#Region " Class Member Variables "

    Private mController As clsBgThread
    Private objDefaultSettings As AldysGraph.Defaults
    Private mblnStop As Boolean = False
    Private mdblLampCurrent As Double
    Private mintLampPosition As Integer
    Private mintOccurence As Integer = 0
    Private mdblYaxis As Double
    Private mdblXaxis As Double
    Private BHOptimizationThread As New clsBgBurnerOptimization
    Dim mobjCurve As AldysGraph.CurveItem

    Private mdblMaxXaxis As Double
    Private mdblMaxYaxis As Double = 3.0
    Private mdblMinXaxis As Double
    Private mdblMinYaxis As Double = 0.0
    'Private mblnAvoideProcess As Boolean = False
    'Public BurnerHeightParameter As Object

#End Region

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents CustomPanel2 As GradientPanel.CustomPanel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents CustomPanel1 As GradientPanel.CustomPanel
    Friend WithEvents aasGraphOptimisation As AAS203.AASGraph
    Friend WithEvents custPnlInstConditions As GradientPanel.CustomPanel
    Friend WithEvents lblBurnerFlame As System.Windows.Forms.Label
    Friend WithEvents lblWavelength As System.Windows.Forms.Label
    Friend WithEvents lblSlitWidth As System.Windows.Forms.Label
    Friend WithEvents lblLampCurrent As System.Windows.Forms.Label
    Friend WithEvents lblElementName As System.Windows.Forms.Label
    Friend WithEvents lblInstConditions As System.Windows.Forms.Label
    Friend WithEvents lblBH As System.Windows.Forms.Label
    Friend WithEvents lblPosition As System.Windows.Forms.Label
    Friend WithEvents lblOptimisation As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmBurnerOptimisation))
        Me.CustomPanelMain = New GradientPanel.CustomPanel
        Me.CustomPanel2 = New GradientPanel.CustomPanel
        Me.custPnlInstConditions = New GradientPanel.CustomPanel
        Me.lblBurnerFlame = New System.Windows.Forms.Label
        Me.lblWavelength = New System.Windows.Forms.Label
        Me.lblSlitWidth = New System.Windows.Forms.Label
        Me.lblLampCurrent = New System.Windows.Forms.Label
        Me.lblElementName = New System.Windows.Forms.Label
        Me.lblInstConditions = New System.Windows.Forms.Label
        Me.lblBH = New System.Windows.Forms.Label
        Me.lblPosition = New System.Windows.Forms.Label
        Me.lblOptimisation = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.CustomPanel1 = New GradientPanel.CustomPanel
        Me.aasGraphOptimisation = New AAS203.AASGraph
        Me.CustomPanelMain.SuspendLayout()
        Me.CustomPanel2.SuspendLayout()
        Me.custPnlInstConditions.SuspendLayout()
        Me.CustomPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CustomPanelMain
        '
        Me.CustomPanelMain.BackColor = System.Drawing.Color.Transparent
        Me.CustomPanelMain.Controls.Add(Me.CustomPanel2)
        Me.CustomPanelMain.Controls.Add(Me.CustomPanel1)
        Me.CustomPanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanelMain.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanelMain.Name = "CustomPanelMain"
        Me.CustomPanelMain.Size = New System.Drawing.Size(458, 455)
        Me.CustomPanelMain.TabIndex = 1
        '
        'CustomPanel2
        '
        Me.CustomPanel2.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanel2.Controls.Add(Me.custPnlInstConditions)
        Me.CustomPanel2.Controls.Add(Me.lblBH)
        Me.CustomPanel2.Controls.Add(Me.lblPosition)
        Me.CustomPanel2.Controls.Add(Me.lblOptimisation)
        Me.CustomPanel2.Controls.Add(Me.btnClose)
        Me.CustomPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CustomPanel2.Location = New System.Drawing.Point(0, 327)
        Me.CustomPanel2.Name = "CustomPanel2"
        Me.CustomPanel2.Size = New System.Drawing.Size(458, 128)
        Me.CustomPanel2.TabIndex = 1
        '
        'custPnlInstConditions
        '
        Me.custPnlInstConditions.BackColor = System.Drawing.Color.Transparent
        Me.custPnlInstConditions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.custPnlInstConditions.Controls.Add(Me.lblBurnerFlame)
        Me.custPnlInstConditions.Controls.Add(Me.lblWavelength)
        Me.custPnlInstConditions.Controls.Add(Me.lblSlitWidth)
        Me.custPnlInstConditions.Controls.Add(Me.lblLampCurrent)
        Me.custPnlInstConditions.Controls.Add(Me.lblElementName)
        Me.custPnlInstConditions.Controls.Add(Me.lblInstConditions)
        Me.custPnlInstConditions.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.custPnlInstConditions.Location = New System.Drawing.Point(0, 74)
        Me.custPnlInstConditions.Name = "custPnlInstConditions"
        Me.custPnlInstConditions.Size = New System.Drawing.Size(458, 54)
        Me.custPnlInstConditions.TabIndex = 5
        '
        'lblBurnerFlame
        '
        Me.lblBurnerFlame.BackColor = System.Drawing.Color.White
        Me.lblBurnerFlame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBurnerFlame.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBurnerFlame.ForeColor = System.Drawing.Color.Blue
        Me.lblBurnerFlame.Location = New System.Drawing.Point(364, 8)
        Me.lblBurnerFlame.Name = "lblBurnerFlame"
        Me.lblBurnerFlame.Size = New System.Drawing.Size(74, 16)
        Me.lblBurnerFlame.TabIndex = 5
        '
        'lblWavelength
        '
        Me.lblWavelength.BackColor = System.Drawing.Color.White
        Me.lblWavelength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWavelength.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWavelength.ForeColor = System.Drawing.Color.Blue
        Me.lblWavelength.Location = New System.Drawing.Point(148, 29)
        Me.lblWavelength.Name = "lblWavelength"
        Me.lblWavelength.Size = New System.Drawing.Size(150, 16)
        Me.lblWavelength.TabIndex = 4
        '
        'lblSlitWidth
        '
        Me.lblSlitWidth.BackColor = System.Drawing.Color.White
        Me.lblSlitWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSlitWidth.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSlitWidth.ForeColor = System.Drawing.Color.Blue
        Me.lblSlitWidth.Location = New System.Drawing.Point(314, 29)
        Me.lblSlitWidth.Name = "lblSlitWidth"
        Me.lblSlitWidth.Size = New System.Drawing.Size(124, 16)
        Me.lblSlitWidth.TabIndex = 3
        '
        'lblLampCurrent
        '
        Me.lblLampCurrent.BackColor = System.Drawing.Color.White
        Me.lblLampCurrent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLampCurrent.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLampCurrent.ForeColor = System.Drawing.Color.Blue
        Me.lblLampCurrent.Location = New System.Drawing.Point(10, 29)
        Me.lblLampCurrent.Name = "lblLampCurrent"
        Me.lblLampCurrent.Size = New System.Drawing.Size(120, 16)
        Me.lblLampCurrent.TabIndex = 2
        '
        'lblElementName
        '
        Me.lblElementName.BackColor = System.Drawing.Color.White
        Me.lblElementName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblElementName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblElementName.ForeColor = System.Drawing.Color.Blue
        Me.lblElementName.Location = New System.Drawing.Point(246, 8)
        Me.lblElementName.Name = "lblElementName"
        Me.lblElementName.Size = New System.Drawing.Size(100, 16)
        Me.lblElementName.TabIndex = 1
        Me.lblElementName.Text = "Element Name"
        '
        'lblInstConditions
        '
        Me.lblInstConditions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInstConditions.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInstConditions.ForeColor = System.Drawing.Color.Blue
        Me.lblInstConditions.Location = New System.Drawing.Point(10, 8)
        Me.lblInstConditions.Name = "lblInstConditions"
        Me.lblInstConditions.Size = New System.Drawing.Size(222, 16)
        Me.lblInstConditions.TabIndex = 0
        Me.lblInstConditions.Text = "Instrument Conditions for Element :"
        '
        'lblBH
        '
        Me.lblBH.BackColor = System.Drawing.Color.White
        Me.lblBH.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBH.ForeColor = System.Drawing.Color.Blue
        Me.lblBH.Location = New System.Drawing.Point(10, 8)
        Me.lblBH.Name = "lblBH"
        Me.lblBH.Size = New System.Drawing.Size(422, 16)
        Me.lblBH.TabIndex = 2
        '
        'lblPosition
        '
        Me.lblPosition.BackColor = System.Drawing.Color.White
        Me.lblPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPosition.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPosition.ForeColor = System.Drawing.Color.Blue
        Me.lblPosition.Location = New System.Drawing.Point(10, 27)
        Me.lblPosition.Name = "lblPosition"
        Me.lblPosition.Size = New System.Drawing.Size(422, 16)
        Me.lblPosition.TabIndex = 1
        '
        'lblOptimisation
        '
        Me.lblOptimisation.BackColor = System.Drawing.Color.White
        Me.lblOptimisation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOptimisation.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOptimisation.ForeColor = System.Drawing.Color.Blue
        Me.lblOptimisation.Location = New System.Drawing.Point(10, 46)
        Me.lblOptimisation.Name = "lblOptimisation"
        Me.lblOptimisation.Size = New System.Drawing.Size(422, 16)
        Me.lblOptimisation.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(362, 65)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(74, 22)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        Me.btnClose.Visible = False
        '
        'CustomPanel1
        '
        Me.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanel1.Controls.Add(Me.aasGraphOptimisation)
        Me.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.CustomPanel1.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanel1.Name = "CustomPanel1"
        Me.CustomPanel1.Size = New System.Drawing.Size(458, 312)
        Me.CustomPanel1.TabIndex = 0
        '
        'aasGraphOptimisation
        '
        Me.aasGraphOptimisation.AldysGraphCursor = Nothing
        Me.aasGraphOptimisation.AldysGraphPrintColor = System.Drawing.Color.Black
        Me.aasGraphOptimisation.BackColor = System.Drawing.Color.LightGray
        Me.aasGraphOptimisation.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.aasGraphOptimisation.GraphDataSource = Nothing
        Me.aasGraphOptimisation.GraphImage = Nothing
        Me.aasGraphOptimisation.IsShowGrid = True
        Me.aasGraphOptimisation.Location = New System.Drawing.Point(6, 4)
        Me.aasGraphOptimisation.Name = "aasGraphOptimisation"
        Me.aasGraphOptimisation.Size = New System.Drawing.Size(442, 300)
        Me.aasGraphOptimisation.TabIndex = 3
        Me.aasGraphOptimisation.UseDefaultSettings = False
        Me.aasGraphOptimisation.XAxisDateMax = New Date(CType(0, Long))
        Me.aasGraphOptimisation.XAxisDateMin = New Date(CType(0, Long))
        Me.aasGraphOptimisation.XAxisDateScaleFormat = AAS203.AASGraph.enumDateScaleFormat.YYYY
        Me.aasGraphOptimisation.XAxisLabel = "BURNER POSITION"
        Me.aasGraphOptimisation.XAxisMax = 6
        Me.aasGraphOptimisation.XAxisMin = 0
        Me.aasGraphOptimisation.XAxisMinorStep = 0.5
        Me.aasGraphOptimisation.XAxisScaleFormat = Nothing
        Me.aasGraphOptimisation.XAxisStep = 1
        Me.aasGraphOptimisation.XAxisType = AldysGraph.AxisType.Linear
        Me.aasGraphOptimisation.YAxisLabel = "ABS"
        Me.aasGraphOptimisation.YAxisMax = 3
        Me.aasGraphOptimisation.YAxisMin = 0
        Me.aasGraphOptimisation.YAxisMinorStep = 0.2
        Me.aasGraphOptimisation.YAxisScaleFormat = Nothing
        Me.aasGraphOptimisation.YAxisStep = 1
        Me.aasGraphOptimisation.YAxisType = AldysGraph.AxisType.Linear
        '
        'frmBurnerOptimisation
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(458, 455)
        Me.ControlBox = False
        Me.Controls.Add(Me.CustomPanelMain)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBurnerOptimisation"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Burner Optimisation"
        Me.TopMost = True
        Me.CustomPanelMain.ResumeLayout(False)
        Me.CustomPanel2.ResumeLayout(False)
        Me.custPnlInstConditions.ResumeLayout(False)
        Me.CustomPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Public Property  "


    Public Property XMin() As Double
        ''this is used for setting and getting a Xmin value.
        Get
            XMin = mdblMinXaxis
        End Get
        Set(ByVal Value As Double)
            mdblMinXaxis = Value
        End Set

    End Property
    Public Property XMax() As Double
        ''this is used for setting and getting a Xmax value.
        Get
            XMax = mdblMaxXaxis
        End Get
        Set(ByVal Value As Double)
            mdblMaxXaxis = Value
        End Set
    End Property

    Public Property YMin() As Double
        ''this is used for setting and getting a Ymin value.
        Get
            YMin = mdblMinYaxis
        End Get
        Set(ByVal Value As Double)
            mdblMinYaxis = Value
        End Set
    End Property
    Public Property YMax() As Double
        ''this is used for setting and getting a Ymax value.
        Get
            YMax = mdblMaxYaxis
        End Get
        Set(ByVal Value As Double)
            mdblMaxYaxis = Value
        End Set
    End Property
#End Region

#Region " IClient Events for receiving the Turrent Position value from thread "

    Public Sub Completed(ByVal Cancelled As Boolean) Implements BgThread.Iclient.Completed
        '=====================================================================
        ' Procedure Name        : Completed
        ' Parameters Passed     : Cancelled
        ' Returns               : None
        ' Purpose               : 
        ' Description           : to handle a completion of thread.
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 12.12.06
        ' Revisions             : praveen
        '=====================================================================
        'btnClose.Visible = True
        If Cancelled = True Then
            mblnStop = True
            'Me.DialogResult = DialogResult.OK
            'btnClose.Visible = True

            '---Added By Mangesh 
            If Not IsNothing(mobjCurve) Then
                aasGraphOptimisation.StopOnlineGraph(mobjCurve)
                ''stop a online graph.
                aasGraphOptimisation.DrawHighestPeakLine(mobjCurve)
                ''display a peak line
                If gintOptimisation = modGlobalDeclarations.EnumBH_FP_Opimisation.FuelPresure Then
                    ''for fuel presure
                    aasGraphOptimisation.ShowHighPeakLineLabel("Max. Ratio", False, 0)
                ElseIf gintOptimisation = modGlobalDeclarations.EnumBH_FP_Opimisation.BurnerHeight Then
                    ''check for burner
                    aasGraphOptimisation.ShowHighPeakLineLabel("Max. Height", False, 0)
                End If

            End If
            '---Added By Mangesh 
        End If
        gobjCommProtocol.mobjCommdll.subTime_Delay(2000)
        ''for communication delay during a thread
        Me.Close()
    End Sub

    Public Sub Display(ByVal Text As String) Implements BgThread.Iclient.Display
        '=====================================================================
        ' Procedure Name        : Display
        ' Parameters Passed     : Text
        ' Returns               : None
        ' Purpose               : 
        ' Description           : to display a thread calculation on a screen
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 12.12.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is called by burner optimization thread.
        ''this is used to diaplayed a thread calculation on a screen.
        ''here we have to pass a string ,which is to be displayed.
        Dim strDataValues() As String
        Dim dblX, dblY As Double
        Dim strGraphLedgend As String

        Try
            If Not Text = String.Empty Then
                strDataValues = Text.Split("|")
                ''set a spliter for given string
                If strDataValues.Length > 0 Then
                    ''check for length
                    mintOccurence = mintOccurence + 1

                    dblX = CDbl(strDataValues(0))
                    dblY = CDbl(strDataValues(1))
                    ''get a value of X,Y from a given string
                    If mintOccurence = 1 Then
                        'agTurretOptimisation.PlotPoint(0, 0, dblX, dblY, 1)
                        '---Added By Mangesh 
                        If gintOptimisation = modGlobalDeclarations.EnumBH_FP_Opimisation.BurnerHeight Then
                            strGraphLedgend = "Burner Height"
                        ElseIf gintOptimisation = modGlobalDeclarations.EnumBH_FP_Opimisation.FuelPresure Then
                            strGraphLedgend = "Fuel Ratio"
                        End If

                        mobjCurve = aasGraphOptimisation.StartOnlineGraph(strGraphLedgend, Color.Red, AldysGraph.SymbolType.NoSymbol)
                        ''draw a online graph as per given parameter 
                        aasGraphOptimisation.PlotPoint(mobjCurve, dblX, dblY)
                        ''plot a point on graph with respect to given value of X,Y
                    Else
                        'agTurretOptimisation.PlotPoint(mdblXaxis, mdblYaxis, dblX, dblY, 1)
                        '---Added By Mangesh 
                        aasGraphOptimisation.PlotPoint(mobjCurve, dblX, dblY)
                    End If

                    mdblYaxis = dblY
                    mdblXaxis = dblX

                    'agTurretOptimisation.RefreshGraph()
                    '---Added By Mangesh 
                    aasGraphOptimisation.AldysPane.AxisChange()
                    ''called for axis change
                    aasGraphOptimisation.Invalidate()
                    Call Application.DoEvents()
                    ''now allow application to perfrom its panding work.
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
        '=====================================================================
        ' Procedure Name        : Failed
        ' Parameters Passed     : e
        ' Returns               : Implements BgThread.Iclient.Failed
        ' Purpose               : 
        ' Description           : called when thread operation is failed.
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 12.12.06
        ' Revisions             : praveen
        '=====================================================================
        'btnClose.Visible = True
        gobjCommProtocol.mobjCommdll.subTime_Delay(2000)
        Me.Close()

    End Sub

    Public Sub Start(ByVal clsBgThread As BgThread.clsBgThread) Implements BgThread.Iclient.Start
    End Sub


#End Region

#Region " Public Functions "

    'Public Function SetDefaultSettingsToGraph() As Boolean
    '    ''not in used
    '    Try


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

    'Public Sub InitializeGraph()

    '    ''not in used.

    '    '    Dim objWait As New CWaitCursor
    '    Try
    '        '        '---Set the Properties of X-Axis


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
    '        'objWait.Dispose()
    '        '---------------------------------------------------------
    '    End Try
    'End Sub

    'Public Function PlotPoint(ByVal intPosition As Integer, ByVal dblEnergy As Double) As Boolean
    '    ''not in used.
    'End Function

    Public Sub StartOptimizeTread()
        '=====================================================================
        ' Procedure Name        : StartOptimizeTread
        ' Parameters Passed     : 
        ' Returns               : None
        ' Purpose               : Star to BH Optimisation and/or Fuel optimisation
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is called for starting a burner optimization thread
        Try
            ' Init thread object and start to thread
            mController = New clsBgThread(Me)
            'btnClose.Visible = True
            btnClose.Refresh()
            BHOptimizationThread = New clsBgBurnerOptimization(lblBH, lblPosition, lblOptimisation, mdblLampCurrent, mintLampPosition, aasGraphOptimisation)
            ''initialise the BHOptimizationThread  object
            ''TurretOptimizationThread = New clsBgTurretOptimization(lblPMT, lblTurretPosition, lblTurretOptimisation, mdblLampCurrent, mintLampPosition, aasGraphTurretOptimisation)
            mController.Start(BHOptimizationThread)
            ''start a thread.

            'mController.Start(New clsBgTurretOptimization(mdblLampCurrent, mintLampPosition))
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
            'Application.DoEvents()     'Commented by Saurabh 20.07.07
            '---------------------------------------------------------
        End Try
    End Sub

#End Region

#Region "Private Functions"

    'Private Sub TurretOptimizationThread_OptimizationStatus(ByVal strLine1 As String) Handles TurretOptimizationThread.OptimizationStatus
    '    'MessageBox.Show(strLine1)
    '    lblTurretOptimisation.Text = strLine1
    'End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        '=====================================================================
        ' Procedure Name        : btnClose_Click
        ' Parameters Passed     : 
        ' Returns               : 
        ' Purpose               : this is called when user click on close button
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : praveen
        '=====================================================================
        Try
            ' Set interupte for Termination of the thread
            gblnSpectrumTerminated = True
            BHOptimizationThread.ThTerminate = True
            ''set a flag for terminate a thread
            Application.DoEvents()
            ''allow application to perfrom its panding work.
            If mController.IsThreadRunning Then
                ''check if thread is running then
                mController.Cancel()
                ''stop the thread
            End If
            Application.DoEvents()

            Me.DialogResult = DialogResult.OK
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

    Private Sub frmBurnerOptimisation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmBurnerOptimisation_Load
        ' Parameters Passed     : 
        ' Returns               : 
        ' Purpose               : this is called when burner optimization form is loaded.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : praveen
        '=====================================================================
        Try
            Me.Hide()

            If ReadAndSetBHScanConditions() = False Then
                'Set BH/Fuel setting to the form object
                Me.Close()
                Exit Sub
            End If
            Call StartOptimizeTread()
            ''for starting a burner optimization thread.
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

    Private Function ReadAndSetBHScanConditions() As Boolean
        '=====================================================================
        ' Procedure Name        : ReadAndSetBHScanConditions
        ' Parameters Passed     : 
        ' Returns               : return true when success 
        ' Purpose               : Set BH/Fuel setting to the form object
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : praveen
        '=====================================================================
        Try
            'btnClose.Visible = True
            ' Set graph parameter objects
            If gintOptimisation = modGlobalDeclarations.EnumBH_FP_Opimisation.BurnerHeight Then
                ''check a flag for burner
                aasGraphOptimisation.XAxisMin = 0
                aasGraphOptimisation.XAxisMax = 6
                aasGraphOptimisation.YAxisMin = 0
                aasGraphOptimisation.YAxisMax = 3.0
                aasGraphOptimisation.XAxisLabel = "BURNER POSITION"
                aasGraphOptimisation.YAxisMinorStep = 0.1
                aasGraphOptimisation.YAxisStep = 0.5
            ElseIf gintOptimisation = modGlobalDeclarations.EnumBH_FP_Opimisation.FuelPresure Then
                ''check a flag for fuel presure.
                aasGraphOptimisation.XAxisMin = 2.0
                aasGraphOptimisation.XAxisMax = 4.5
                aasGraphOptimisation.YAxisMin = 0
                aasGraphOptimisation.YAxisMax = 3.0
                aasGraphOptimisation.XAxisLabel = "FUEL RATIO"
                aasGraphOptimisation.YAxisMinorStep = 0.1
                aasGraphOptimisation.YAxisStep = 0.5
            End If

            aasGraphOptimisation.AldysPane.AxisChange()
            aasGraphOptimisation.Invalidate()
            aasGraphOptimisation.Refresh()

            '**********************************************
            '---STEP 15 : Set Instrument Conditions
            '**********************************************
            Call gobjClsAAS203.funcSetInstrumentCondns(True, lblElementName, lblLampCurrent, lblWavelength, lblSlitWidth, lblBurnerFlame)
            Application.DoEvents()
            ''allow application to perfrom its panding work.
            Dim objfrmBHParameter As New frmBHParameter
            ''object for BHparemeter form.
            objfrmBHParameter.BHStartScan = aasGraphOptimisation.XAxisMin
            objfrmBHParameter.BHEndScan = aasGraphOptimisation.XAxisMax
            ''set a initiale parameter for object.
            If objfrmBHParameter.ShowDialog() = DialogResult.OK Then
                aasGraphOptimisation.XAxisMin = objfrmBHParameter.BHStartScan
                aasGraphOptimisation.XAxisMax = objfrmBHParameter.BHEndScan

                aasGraphOptimisation.AldysPane.AxisChange()
                aasGraphOptimisation.Invalidate()
                aasGraphOptimisation.Refresh()
            Else
                objfrmBHParameter.Dispose()
                Return False
            End If
            objfrmBHParameter.Dispose()
            Me.BringToFront()
            Application.DoEvents()
            '---to validate burner height
            If (aasGraphOptimisation.XAxisMin > aasGraphOptimisation.XAxisMax) And _
                (gobjClsAAS203.funcValidateHt(aasGraphOptimisation.XAxisMin)) And (gobjClsAAS203.funcValidateHt(aasGraphOptimisation.XAxisMax)) Then
                Return False
            End If

            gobjMessageAdapter.ShowMessage(constAspirateMaxStd)
            Me.BringToFront()
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
            '---------------------------------------------------------
        End Try
    End Function

    Private Sub frmBurnerOptimisation_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        '=====================================================================
        ' Procedure Name        : frmBurnerOptimisation_Activated
        ' Parameters Passed     : 
        ' Returns               : 
        ' Purpose               : for activation of burneroptimization.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : praveen
        '=====================================================================
        Try
            If gintOptimisation = modGlobalDeclarations.EnumBH_FP_Opimisation.FuelPresure Then
                ''check a flag for prasure
                ''set a text 
                Me.Text = "Fuel Optimisation"
            ElseIf gintOptimisation = modGlobalDeclarations.EnumBH_FP_Opimisation.BurnerHeight Then
                ''check a flag for burner
                ''and set a text
                Me.Text = "Burner Height Optimisation"
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

End Class
