Imports AAS203.Common
Imports BgThread
Imports AAS203.AASGraph

Public Class frmZeroOrder2
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
    Friend WithEvents CustomPanel2 As GradientPanel.CustomPanel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents aasGraphOpt As AAS203.AASGraph
    Friend WithEvents lblTurretOptimisationOpt As System.Windows.Forms.Label
    Friend WithEvents lblPMTOpt As System.Windows.Forms.Label
    Friend WithEvents lblTurretPositionOpt As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmZeroOrder2))
        Me.CustomPanelMain = New GradientPanel.CustomPanel
        Me.CustomPanel1 = New GradientPanel.CustomPanel
        Me.aasGraphOpt = New AAS203.AASGraph
        Me.CustomPanel2 = New GradientPanel.CustomPanel
        Me.lblTurretOptimisationOpt = New System.Windows.Forms.Label
        Me.lblPMTOpt = New System.Windows.Forms.Label
        Me.lblTurretPositionOpt = New System.Windows.Forms.Label
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
        Me.CustomPanel1.Controls.Add(Me.aasGraphOpt)
        Me.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanel1.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanel1.Name = "CustomPanel1"
        Me.CustomPanel1.Size = New System.Drawing.Size(384, 285)
        Me.CustomPanel1.TabIndex = 0
        '
        'aasGraphOpt
        '
        Me.aasGraphOpt.AldysGraphCursor = Nothing
        Me.aasGraphOpt.AldysGraphPrintColor = System.Drawing.Color.Black
        Me.aasGraphOpt.BackColor = System.Drawing.Color.LightGray
        Me.aasGraphOpt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.aasGraphOpt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.aasGraphOpt.GraphDataSource = Nothing
        Me.aasGraphOpt.GraphImage = Nothing
        Me.aasGraphOpt.IsShowGrid = True
        Me.aasGraphOpt.Location = New System.Drawing.Point(0, 0)
        Me.aasGraphOpt.Name = "aasGraphOpt"
        Me.aasGraphOpt.Size = New System.Drawing.Size(384, 285)
        Me.aasGraphOpt.TabIndex = 5
        Me.aasGraphOpt.UseDefaultSettings = False
        Me.aasGraphOpt.XAxisDateMax = New Date(CType(0, Long))
        Me.aasGraphOpt.XAxisDateMin = New Date(CType(0, Long))
        Me.aasGraphOpt.XAxisDateScaleFormat = AAS203.AASGraph.enumDateScaleFormat.YYYY
        Me.aasGraphOpt.XAxisLabel = "TURRET POSITION"
        Me.aasGraphOpt.XAxisMax = 100
        Me.aasGraphOpt.XAxisMin = 0
        Me.aasGraphOpt.XAxisMinorStep = 5
        Me.aasGraphOpt.XAxisScaleFormat = Nothing
        Me.aasGraphOpt.XAxisStep = 10
        Me.aasGraphOpt.XAxisType = AldysGraph.AxisType.Linear
        Me.aasGraphOpt.YAxisLabel = "ENERGY"
        Me.aasGraphOpt.YAxisMax = 100
        Me.aasGraphOpt.YAxisMin = 0
        Me.aasGraphOpt.YAxisMinorStep = 5
        Me.aasGraphOpt.YAxisScaleFormat = Nothing
        Me.aasGraphOpt.YAxisStep = 10
        Me.aasGraphOpt.YAxisType = AldysGraph.AxisType.Linear
        '
        'CustomPanel2
        '
        Me.CustomPanel2.BackColor = System.Drawing.Color.Transparent
        Me.CustomPanel2.Controls.Add(Me.lblTurretOptimisationOpt)
        Me.CustomPanel2.Controls.Add(Me.lblPMTOpt)
        Me.CustomPanel2.Controls.Add(Me.lblTurretPositionOpt)
        Me.CustomPanel2.Controls.Add(Me.btnClose)
        Me.CustomPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CustomPanel2.Location = New System.Drawing.Point(0, 285)
        Me.CustomPanel2.Name = "CustomPanel2"
        Me.CustomPanel2.Size = New System.Drawing.Size(384, 100)
        Me.CustomPanel2.TabIndex = 1
        '
        'lblTurretOptimisationOpt
        '
        Me.lblTurretOptimisationOpt.BackColor = System.Drawing.Color.White
        Me.lblTurretOptimisationOpt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurretOptimisationOpt.ForeColor = System.Drawing.Color.Blue
        Me.lblTurretOptimisationOpt.Location = New System.Drawing.Point(6, 8)
        Me.lblTurretOptimisationOpt.Name = "lblTurretOptimisationOpt"
        Me.lblTurretOptimisationOpt.Size = New System.Drawing.Size(374, 16)
        Me.lblTurretOptimisationOpt.TabIndex = 2
        '
        'lblPMTOpt
        '
        Me.lblPMTOpt.BackColor = System.Drawing.Color.White
        Me.lblPMTOpt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPMTOpt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPMTOpt.ForeColor = System.Drawing.Color.Blue
        Me.lblPMTOpt.Location = New System.Drawing.Point(6, 26)
        Me.lblPMTOpt.Name = "lblPMTOpt"
        Me.lblPMTOpt.Size = New System.Drawing.Size(374, 16)
        Me.lblPMTOpt.TabIndex = 1
        '
        'lblTurretPositionOpt
        '
        Me.lblTurretPositionOpt.BackColor = System.Drawing.Color.White
        Me.lblTurretPositionOpt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTurretPositionOpt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurretPositionOpt.ForeColor = System.Drawing.Color.Blue
        Me.lblTurretPositionOpt.Location = New System.Drawing.Point(6, 46)
        Me.lblTurretPositionOpt.Name = "lblTurretPositionOpt"
        Me.lblTurretPositionOpt.Size = New System.Drawing.Size(374, 16)
        Me.lblTurretPositionOpt.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(5, 70)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(74, 22)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        Me.btnClose.Visible = False
        '
        'frmZeroOrder2
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
        Me.Name = "frmZeroOrder2"
        Me.ShowInTaskbar = False
        Me.Text = "Optimization"
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
    Private OptThread As clsBgOptimizeAll
    Private mintOccurence As Integer
    Private mobjCurve As AldysGraph.CurveItem
    Private mdblYaxis, mdblXaxis As Double
#End Region

#Region " IClient Events for receiving the Turrent Position value from thread "
    ''this are the thread realted function.
    Public Sub Completed(ByVal Cancelled As Boolean) Implements BgThread.Iclient.Completed
        '=====================================================================
        ' Procedure Name        : Completed
        ' Parameters Passed     : Canceled
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : Saturday, January 22, 2005
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this is called form thread 
        ''this will used to perfrom a completion event of a thread.
        If Cancelled = False Then
            'btnClose.Visible = True
            If Not IsNothing(mobjCurve) Then
                aasGraphOpt.StopOnlineGraph(mobjCurve)
                ''stop a onlinegraph
                aasGraphOpt.DrawHighestPeakLine(mobjCurve)
                ''draw highest peak line
                aasGraphOpt.ShowHighPeakLineLabel(" Optimized Position", False, 0)
            End If
        Else
            mblnStop = True
            Me.DialogResult = DialogResult.OK
        End If
    End Sub

    Public Sub Display(ByVal Text As String) Implements BgThread.Iclient.Display
        ''  '=====================================================================
        ' Procedure Name        : Display
        ' Parameters Passed     : 
        ' Returns               : None
        ' Purpose               : 
        ' Description           :''here we have to pass the string to be disply. 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 24-Jan-2007 04:15 pm
        ' Revisions             : 1
        '=====================================================================
        ''note:
        ''here we have to pass the string to be disply.
        Dim strDataValues() As String
        Dim dblX, dblY As Double

        Try
            If Not Text = String.Empty Then
                strDataValues = Text.Split(",")
                ''split a passed string and store it in a temp string variable.

                If strDataValues.Length > 0 Then
                    mintOccurence = mintOccurence + 1

                    dblX = CDbl(strDataValues(0))
                    dblY = CDbl(strDataValues(1))
                    ''now get a x,y value from the passed string.
                    If mintOccurence = 1 Then
                        mobjCurve = aasGraphOpt.StartOnlineGraph("ENERGY", Color.Red, AldysGraph.SymbolType.NoSymbol)
                        ''this will display a online graph as par passed string
                    Else
                        aasGraphOpt.PlotPoint(mobjCurve, dblX, dblY)
                        ''this will plot a point with respect to the value passed by a string.
                    End If

                    mdblYaxis = dblY
                    mdblXaxis = dblX

                    aasGraphOpt.AldysPane.AxisChange()
                    ''for axis change.
                    aasGraphOpt.Invalidate()
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

    Public Sub StartOptTread()
        ''  '=====================================================================
        ' Procedure Name        : StartOptTread
        ' Parameters Passed     : 
        ' Returns               : None
        ' Purpose               : 
        ' Description           : to start the thread 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 24-Jan-2007 04:15 pm
        ' Revisions             : 1
        '=====================================================================
        ''note:
        ''this is used to start the thread.
        ''first initialise a thread object with current value
        ''then start a thread with that value.
        mController = New clsBgThread(Me)
        OptThread = New clsBgOptimizeAll(lblPMTOpt, lblTurretPositionOpt, lblTurretOptimisationOpt, aasGraphOpt)
        mController.Start(OptThread)
        ''for starting a thread.
    End Sub

#End Region

#Region "Private Functions"
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        ''  '=====================================================================
        ' Procedure Name        : btnClose_Click
        ' Parameters Passed     : 
        ' Returns               : None
        ' Purpose               : 
        ' Description           : to close the form.
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 24-Jan-2007 04:15 pm
        ' Revisions             : 1
        '=====================================================================
        Me.DialogResult = DialogResult.OK
    End Sub
#End Region

End Class
