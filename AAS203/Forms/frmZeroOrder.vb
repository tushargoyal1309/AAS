Imports AAS203.Common
Imports BgThread
Imports AAS203.AASGraph

Public Class frmZeroOrder
    Inherits System.Windows.Forms.Form
    Implements BgThread.Iclient

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
    Friend WithEvents CustomPanel1 As GradientPanel.CustomPanel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents aasGraphZeroOrder As AAS203.AASGraph
    Friend WithEvents CustomPanel2 As GradientPanel.CustomPanel
    Friend WithEvents lblPMTZeroOrder As System.Windows.Forms.Label
    Friend WithEvents lblTurretPositionZeroOrder As System.Windows.Forms.Label
    Friend WithEvents lblTurretOptimisationZeroOrder As System.Windows.Forms.Label
    Friend WithEvents lblWavelengthStatus As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmZeroOrder))
        Me.CustomPanelMain = New GradientPanel.CustomPanel
        Me.CustomPanel1 = New GradientPanel.CustomPanel
        Me.aasGraphZeroOrder = New AAS203.AASGraph
        Me.CustomPanel2 = New GradientPanel.CustomPanel
        Me.lblWavelengthStatus = New System.Windows.Forms.Label
        Me.lblPMTZeroOrder = New System.Windows.Forms.Label
        Me.lblTurretPositionZeroOrder = New System.Windows.Forms.Label
        Me.lblTurretOptimisationZeroOrder = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
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
        Me.CustomPanelMain.Size = New System.Drawing.Size(384, 385)
        Me.CustomPanelMain.TabIndex = 0
        '
        'CustomPanel1
        '
        Me.CustomPanel1.BackColor = System.Drawing.Color.Transparent
        Me.CustomPanel1.Controls.Add(Me.aasGraphZeroOrder)
        Me.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanel1.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanel1.Name = "CustomPanel1"
        Me.CustomPanel1.Size = New System.Drawing.Size(384, 285)
        Me.CustomPanel1.TabIndex = 0
        '
        'aasGraphZeroOrder
        '
        Me.aasGraphZeroOrder.AldysGraphCursor = Nothing
        Me.aasGraphZeroOrder.AldysGraphPrintColor = System.Drawing.Color.Black
        Me.aasGraphZeroOrder.BackColor = System.Drawing.Color.LightGray
        Me.aasGraphZeroOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.aasGraphZeroOrder.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.aasGraphZeroOrder.GraphDataSource = Nothing
        Me.aasGraphZeroOrder.GraphImage = Nothing
        Me.aasGraphZeroOrder.IsShowGrid = True
        Me.aasGraphZeroOrder.Location = New System.Drawing.Point(0, 0)
        Me.aasGraphZeroOrder.Name = "aasGraphZeroOrder"
        Me.aasGraphZeroOrder.Size = New System.Drawing.Size(384, 285)
        Me.aasGraphZeroOrder.TabIndex = 4
        Me.aasGraphZeroOrder.UseDefaultSettings = False
        Me.aasGraphZeroOrder.XAxisDateMax = New Date(CType(0, Long))
        Me.aasGraphZeroOrder.XAxisDateMin = New Date(CType(0, Long))
        Me.aasGraphZeroOrder.XAxisDateScaleFormat = AAS203.AASGraph.enumDateScaleFormat.YYYY
        Me.aasGraphZeroOrder.XAxisLabel = "WAVELENGTH (nm)"
        Me.aasGraphZeroOrder.XAxisMax = 4
        Me.aasGraphZeroOrder.XAxisMin = -2
        Me.aasGraphZeroOrder.XAxisMinorStep = 1
        Me.aasGraphZeroOrder.XAxisScaleFormat = ""
        Me.aasGraphZeroOrder.XAxisStep = 1
        Me.aasGraphZeroOrder.XAxisType = AldysGraph.AxisType.Linear
        Me.aasGraphZeroOrder.YAxisLabel = "ENERGY"
        Me.aasGraphZeroOrder.YAxisMax = 100
        Me.aasGraphZeroOrder.YAxisMin = 0
        Me.aasGraphZeroOrder.YAxisMinorStep = 5
        Me.aasGraphZeroOrder.YAxisScaleFormat = Nothing
        Me.aasGraphZeroOrder.YAxisStep = 10
        Me.aasGraphZeroOrder.YAxisType = AldysGraph.AxisType.Linear
        '
        'CustomPanel2
        '
        Me.CustomPanel2.BackColor = System.Drawing.Color.Transparent
        Me.CustomPanel2.Controls.Add(Me.lblWavelengthStatus)
        Me.CustomPanel2.Controls.Add(Me.lblPMTZeroOrder)
        Me.CustomPanel2.Controls.Add(Me.lblTurretPositionZeroOrder)
        Me.CustomPanel2.Controls.Add(Me.lblTurretOptimisationZeroOrder)
        Me.CustomPanel2.Controls.Add(Me.btnClose)
        Me.CustomPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CustomPanel2.Location = New System.Drawing.Point(0, 285)
        Me.CustomPanel2.Name = "CustomPanel2"
        Me.CustomPanel2.Size = New System.Drawing.Size(384, 100)
        Me.CustomPanel2.TabIndex = 4
        '
        'lblWavelengthStatus
        '
        Me.lblWavelengthStatus.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWavelengthStatus.ForeColor = System.Drawing.Color.Blue
        Me.lblWavelengthStatus.Location = New System.Drawing.Point(4, 70)
        Me.lblWavelengthStatus.Name = "lblWavelengthStatus"
        Me.lblWavelengthStatus.Size = New System.Drawing.Size(210, 24)
        Me.lblWavelengthStatus.TabIndex = 5
        '
        'lblPMTZeroOrder
        '
        Me.lblPMTZeroOrder.BackColor = System.Drawing.Color.White
        Me.lblPMTZeroOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPMTZeroOrder.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPMTZeroOrder.ForeColor = System.Drawing.Color.Blue
        Me.lblPMTZeroOrder.Location = New System.Drawing.Point(4, 27)
        Me.lblPMTZeroOrder.Name = "lblPMTZeroOrder"
        Me.lblPMTZeroOrder.Size = New System.Drawing.Size(376, 16)
        Me.lblPMTZeroOrder.TabIndex = 1
        '
        'lblTurretPositionZeroOrder
        '
        Me.lblTurretPositionZeroOrder.BackColor = System.Drawing.Color.White
        Me.lblTurretPositionZeroOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTurretPositionZeroOrder.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurretPositionZeroOrder.ForeColor = System.Drawing.Color.Blue
        Me.lblTurretPositionZeroOrder.Location = New System.Drawing.Point(4, 47)
        Me.lblTurretPositionZeroOrder.Name = "lblTurretPositionZeroOrder"
        Me.lblTurretPositionZeroOrder.Size = New System.Drawing.Size(376, 16)
        Me.lblTurretPositionZeroOrder.TabIndex = 0
        '
        'lblTurretOptimisationZeroOrder
        '
        Me.lblTurretOptimisationZeroOrder.BackColor = System.Drawing.Color.White
        Me.lblTurretOptimisationZeroOrder.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurretOptimisationZeroOrder.ForeColor = System.Drawing.Color.Blue
        Me.lblTurretOptimisationZeroOrder.Location = New System.Drawing.Point(4, 7)
        Me.lblTurretOptimisationZeroOrder.Name = "lblTurretOptimisationZeroOrder"
        Me.lblTurretOptimisationZeroOrder.Size = New System.Drawing.Size(376, 16)
        Me.lblTurretOptimisationZeroOrder.TabIndex = 2
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(306, 70)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(74, 22)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        Me.btnClose.Visible = False
        '
        'frmZeroOrder
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(384, 385)
        Me.ControlBox = False
        Me.Controls.Add(Me.CustomPanelMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmZeroOrder"
        Me.ShowInTaskbar = False
        Me.Text = "Zero Order"
        Me.TopMost = True
        Me.CustomPanelMain.ResumeLayout(False)
        Me.CustomPanel1.ResumeLayout(False)
        Me.CustomPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Class Member Variables "

    Private mController As clsBgThread
    Private mblnStop As Boolean = False
    Private ZeroOrderThread As clsBgZeroOrder
    Private mintOccurence, mintOccurence1 As Integer
    Private mobjCurve As AldysGraph.CurveItem
    Private mdblYaxis, mdblXaxis As Double

#End Region

#Region " Form Events "

    Private Sub frmTurretOptimisation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmTurretOptimisation_Load
        ' Parameters Passed     : object, EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 24-Jan-2007 04:15 pm
        ' Revisions             : 
        '=====================================================================
        '---set graph properties
        aasGraphZeroOrder.XAxisMin = -2
        aasGraphZeroOrder.XAxisMax = 4
        aasGraphZeroOrder.YAxisLabel = "ENERGY"
        aasGraphZeroOrder.XAxisLabel = "WAVELENGTH (nm)"
        aasGraphZeroOrder.XAxisMinorStep = 1
        aasGraphZeroOrder.XAxisStep = 1

        aasGraphZeroOrder.AldysPane.XAxis.PickScale(-2, 4)
        aasGraphZeroOrder.AldysPane.XAxis.MinorStepAuto = True
        aasGraphZeroOrder.AldysPane.XAxis.StepAuto = True
        aasGraphZeroOrder.Refresh()
    End Sub

#End Region

#Region " IClient Events for receiving the Turrent Position value from thread "

    Public Sub Completed(ByVal Cancelled As Boolean) Implements BgThread.Iclient.Completed
        '=====================================================================
        ' Procedure Name        : Completed
        ' Parameters Passed     : Cancelled
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 24-Jan-2007 04:15 pm
        ' Revisions             : praveen
        '=====================================================================
        ''this is realted to thread
        ''this will show completion.
        If Cancelled = False Then
            mblnStop = True
            'btnClose.Visible = True
            Me.DialogResult = DialogResult.OK
        Else
            If Not IsNothing(mobjCurve) Then
                aasGraphZeroOrder.StopOnlineGraph(mobjCurve)
                aasGraphZeroOrder.DrawHighestPeakLine(mobjCurve)
                aasGraphZeroOrder.ShowHighPeakLineLabel(" Wavelength", False, 0)
            End If
        End If
    End Sub

    Public Sub Display(ByVal Text As String) Implements BgThread.Iclient.Display
        '=====================================================================
        ' Procedure Name        : Display
        ' Parameters Passed     : Text
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 24-Jan-2007 04:15 pm
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is used by a thread.
        ''this is used for the display of value on the screen.
        ''here we have to pass a string to be display.
        Dim strDataValues() As String
        Dim dblX, dblY As Double

        Try
            If Not Text = String.Empty Then
                strDataValues = Text.Split(",")
                ''split a given string
                If strDataValues.Length > 0 Then
                    mintOccurence = mintOccurence + 1

                    dblX = CDbl(strDataValues(0))
                    dblY = CDbl(strDataValues(1))
                    ''get a value for both the axis value
                    If mintOccurence = 1 Then
                        mobjCurve = aasGraphZeroOrder.StartOnlineGraph("ENERGY", Color.Red, AldysGraph.SymbolType.NoSymbol)
                        ''this will start a online graph as par passed value
                    Else
                        aasGraphZeroOrder.PlotPoint(mobjCurve, dblX, dblY)
                        ''this will plot a point on a graph
                        ''so that graph will display.
                    End If

                    mdblYaxis = dblY
                    mdblXaxis = dblX

                    aasGraphZeroOrder.AldysPane.AxisChange()
                    aasGraphZeroOrder.Invalidate()
                    Call Application.DoEvents()
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
        '=====================================================================
        ' Procedure Name        : StartOptimizeTread
        ' Parameters Passed     : 
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 24-Jan-2007 04:15 pm
        ' Revisions             : 1
        '=====================================================================
        ''note:
        ''this will start the optimize thread 
        ''and let the thread to perfrom all function.

        mController = New clsBgThread(Me)

        ZeroOrderThread = New clsBgZeroOrder(lblPMTZeroOrder, lblTurretPositionZeroOrder, lblTurretOptimisationZeroOrder, aasGraphZeroOrder, lblWavelengthStatus)
        'Saurabh 06-06-2007

        mController.Start(ZeroOrderThread)
        ''for starting a thread.

    End Sub

#End Region

#Region "Private Functions"
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        ''  '=====================================================================
        ' Procedure Name        : btnClose_Click
        ' Parameters Passed     : 
        ' Returns               : None
        ' Purpose               : this is called when user closed them form
        ' Description           : for closing a form.
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 24-Jan-2007 04:15 pm
        ' Revisions             : 1
        '=====================================================================
        ''note:
        ''this called when user clicked on close buton
        Me.Close()
        Me.Dispose()
    End Sub
#End Region

End Class
