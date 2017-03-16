Imports AAS203.Common
Imports BgThread

Public Class frmLampOptimisation
    Inherits System.Windows.Forms.Form
    Implements BgThread.Iclient

#Region " Windows Form Designer generated code "

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
    Friend WithEvents lblPMT As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents aasGraphTurretOptimisation As AAS203.AASGraph
    Friend WithEvents lblLampPosition As System.Windows.Forms.Label
    Friend WithEvents lblLampOptimisation As System.Windows.Forms.Label
    Friend WithEvents lblInstConditions As System.Windows.Forms.Label
    Friend WithEvents lblElementName As System.Windows.Forms.Label
    Friend WithEvents lblLampCurrent As System.Windows.Forms.Label
    Friend WithEvents lblWavelength As System.Windows.Forms.Label
    Friend WithEvents lblSlitWidth As System.Windows.Forms.Label
    Friend WithEvents lblBurnerFlame As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmLampOptimisation))
        Me.CustomPanelMain = New GradientPanel.CustomPanel
        Me.CustomPanel2 = New GradientPanel.CustomPanel
        Me.lblPMT = New System.Windows.Forms.Label
        Me.lblLampPosition = New System.Windows.Forms.Label
        Me.lblLampOptimisation = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.lblElementName = New System.Windows.Forms.Label
        Me.lblInstConditions = New System.Windows.Forms.Label
        Me.lblWavelength = New System.Windows.Forms.Label
        Me.lblBurnerFlame = New System.Windows.Forms.Label
        Me.lblSlitWidth = New System.Windows.Forms.Label
        Me.lblLampCurrent = New System.Windows.Forms.Label
        Me.CustomPanel1 = New GradientPanel.CustomPanel
        Me.aasGraphTurretOptimisation = New AAS203.AASGraph
        Me.CustomPanelMain.SuspendLayout()
        Me.CustomPanel2.SuspendLayout()
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
        Me.CustomPanelMain.Size = New System.Drawing.Size(478, 477)
        Me.CustomPanelMain.TabIndex = 0
        '
        'CustomPanel2
        '
        Me.CustomPanel2.BackColor = System.Drawing.Color.Transparent
        Me.CustomPanel2.Controls.Add(Me.lblPMT)
        Me.CustomPanel2.Controls.Add(Me.lblLampPosition)
        Me.CustomPanel2.Controls.Add(Me.lblLampOptimisation)
        Me.CustomPanel2.Controls.Add(Me.btnClose)
        Me.CustomPanel2.Controls.Add(Me.lblElementName)
        Me.CustomPanel2.Controls.Add(Me.lblInstConditions)
        Me.CustomPanel2.Controls.Add(Me.lblWavelength)
        Me.CustomPanel2.Controls.Add(Me.lblBurnerFlame)
        Me.CustomPanel2.Controls.Add(Me.lblSlitWidth)
        Me.CustomPanel2.Controls.Add(Me.lblLampCurrent)
        Me.CustomPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CustomPanel2.Location = New System.Drawing.Point(0, 322)
        Me.CustomPanel2.Name = "CustomPanel2"
        Me.CustomPanel2.Size = New System.Drawing.Size(478, 155)
        Me.CustomPanel2.TabIndex = 1
        '
        'lblPMT
        '
        Me.lblPMT.BackColor = System.Drawing.Color.White
        Me.lblPMT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPMT.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPMT.ForeColor = System.Drawing.Color.Blue
        Me.lblPMT.Location = New System.Drawing.Point(11, 62)
        Me.lblPMT.Name = "lblPMT"
        Me.lblPMT.Size = New System.Drawing.Size(456, 16)
        Me.lblPMT.TabIndex = 2
        '
        'lblLampPosition
        '
        Me.lblLampPosition.BackColor = System.Drawing.Color.White
        Me.lblLampPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLampPosition.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblLampPosition.ForeColor = System.Drawing.Color.Blue
        Me.lblLampPosition.Location = New System.Drawing.Point(11, 84)
        Me.lblLampPosition.Name = "lblLampPosition"
        Me.lblLampPosition.Size = New System.Drawing.Size(456, 16)
        Me.lblLampPosition.TabIndex = 1
        '
        'lblLampOptimisation
        '
        Me.lblLampOptimisation.BackColor = System.Drawing.Color.Transparent
        Me.lblLampOptimisation.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblLampOptimisation.ForeColor = System.Drawing.Color.Blue
        Me.lblLampOptimisation.Location = New System.Drawing.Point(11, 31)
        Me.lblLampOptimisation.Name = "lblLampOptimisation"
        Me.lblLampOptimisation.Size = New System.Drawing.Size(456, 25)
        Me.lblLampOptimisation.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(22, 4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(74, 22)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        Me.btnClose.Visible = False
        '
        'lblElementName
        '
        Me.lblElementName.BackColor = System.Drawing.Color.White
        Me.lblElementName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblElementName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblElementName.ForeColor = System.Drawing.Color.Blue
        Me.lblElementName.Location = New System.Drawing.Point(248, 106)
        Me.lblElementName.Name = "lblElementName"
        Me.lblElementName.Size = New System.Drawing.Size(100, 16)
        Me.lblElementName.TabIndex = 1
        Me.lblElementName.Text = "Element Name"
        '
        'lblInstConditions
        '
        Me.lblInstConditions.BackColor = System.Drawing.Color.White
        Me.lblInstConditions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInstConditions.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInstConditions.ForeColor = System.Drawing.Color.Blue
        Me.lblInstConditions.Location = New System.Drawing.Point(11, 106)
        Me.lblInstConditions.Name = "lblInstConditions"
        Me.lblInstConditions.Size = New System.Drawing.Size(222, 16)
        Me.lblInstConditions.TabIndex = 0
        Me.lblInstConditions.Text = "Instrument Conditions for Element :"
        '
        'lblWavelength
        '
        Me.lblWavelength.BackColor = System.Drawing.Color.White
        Me.lblWavelength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWavelength.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWavelength.ForeColor = System.Drawing.Color.Blue
        Me.lblWavelength.Location = New System.Drawing.Point(118, 128)
        Me.lblWavelength.Name = "lblWavelength"
        Me.lblWavelength.Size = New System.Drawing.Size(148, 20)
        Me.lblWavelength.TabIndex = 4
        '
        'lblBurnerFlame
        '
        Me.lblBurnerFlame.BackColor = System.Drawing.Color.White
        Me.lblBurnerFlame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBurnerFlame.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBurnerFlame.ForeColor = System.Drawing.Color.Blue
        Me.lblBurnerFlame.Location = New System.Drawing.Point(388, 128)
        Me.lblBurnerFlame.Name = "lblBurnerFlame"
        Me.lblBurnerFlame.Size = New System.Drawing.Size(78, 20)
        Me.lblBurnerFlame.TabIndex = 5
        '
        'lblSlitWidth
        '
        Me.lblSlitWidth.BackColor = System.Drawing.Color.White
        Me.lblSlitWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSlitWidth.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSlitWidth.ForeColor = System.Drawing.Color.Blue
        Me.lblSlitWidth.Location = New System.Drawing.Point(269, 128)
        Me.lblSlitWidth.Name = "lblSlitWidth"
        Me.lblSlitWidth.Size = New System.Drawing.Size(116, 20)
        Me.lblSlitWidth.TabIndex = 3
        '
        'lblLampCurrent
        '
        Me.lblLampCurrent.BackColor = System.Drawing.Color.White
        Me.lblLampCurrent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLampCurrent.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLampCurrent.ForeColor = System.Drawing.Color.Blue
        Me.lblLampCurrent.Location = New System.Drawing.Point(11, 128)
        Me.lblLampCurrent.Name = "lblLampCurrent"
        Me.lblLampCurrent.Size = New System.Drawing.Size(104, 20)
        Me.lblLampCurrent.TabIndex = 2
        '
        'CustomPanel1
        '
        Me.CustomPanel1.BackColor = System.Drawing.Color.Transparent
        Me.CustomPanel1.Controls.Add(Me.aasGraphTurretOptimisation)
        Me.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.CustomPanel1.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanel1.Name = "CustomPanel1"
        Me.CustomPanel1.Size = New System.Drawing.Size(478, 312)
        Me.CustomPanel1.TabIndex = 0
        '
        'aasGraphTurretOptimisation
        '
        Me.aasGraphTurretOptimisation.AldysGraphCursor = Nothing
        Me.aasGraphTurretOptimisation.AldysGraphPrintColor = System.Drawing.Color.Black
        Me.aasGraphTurretOptimisation.BackColor = System.Drawing.Color.LightGray
        Me.aasGraphTurretOptimisation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.aasGraphTurretOptimisation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.aasGraphTurretOptimisation.GraphDataSource = Nothing
        Me.aasGraphTurretOptimisation.GraphImage = Nothing
        Me.aasGraphTurretOptimisation.IsShowGrid = True
        Me.aasGraphTurretOptimisation.Location = New System.Drawing.Point(0, 0)
        Me.aasGraphTurretOptimisation.Name = "aasGraphTurretOptimisation"
        Me.aasGraphTurretOptimisation.Size = New System.Drawing.Size(478, 312)
        Me.aasGraphTurretOptimisation.TabIndex = 3
        Me.aasGraphTurretOptimisation.UseDefaultSettings = False
        Me.aasGraphTurretOptimisation.XAxisDateMax = New Date(CType(0, Long))
        Me.aasGraphTurretOptimisation.XAxisDateMin = New Date(CType(0, Long))
        Me.aasGraphTurretOptimisation.XAxisDateScaleFormat = AAS203.AASGraph.enumDateScaleFormat.YYYY
        Me.aasGraphTurretOptimisation.XAxisLabel = "WAVELENGTH (nm)"
        Me.aasGraphTurretOptimisation.XAxisMax = 325
        Me.aasGraphTurretOptimisation.XAxisMin = 323
        Me.aasGraphTurretOptimisation.XAxisMinorStep = 0.1
        Me.aasGraphTurretOptimisation.XAxisScaleFormat = Nothing
        Me.aasGraphTurretOptimisation.XAxisStep = 0.5
        Me.aasGraphTurretOptimisation.XAxisType = AldysGraph.AxisType.Linear
        Me.aasGraphTurretOptimisation.YAxisLabel = "ENERGY"
        Me.aasGraphTurretOptimisation.YAxisMax = 100
        Me.aasGraphTurretOptimisation.YAxisMin = 0
        Me.aasGraphTurretOptimisation.YAxisMinorStep = 5
        Me.aasGraphTurretOptimisation.YAxisScaleFormat = Nothing
        Me.aasGraphTurretOptimisation.YAxisStep = 10
        Me.aasGraphTurretOptimisation.YAxisType = AldysGraph.AxisType.Linear
        '
        'frmLampOptimisation
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(478, 477)
        Me.ControlBox = False
        Me.Controls.Add(Me.CustomPanelMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLampOptimisation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Analytical Peak Search"
        Me.CustomPanelMain.ResumeLayout(False)
        Me.CustomPanel2.ResumeLayout(False)
        Me.CustomPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Constructors "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal blnIsHCLEMode As Boolean)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mblnIsHCLEMode = blnIsHCLEMode

    End Sub

#End Region

#Region " Class Member Variables "

    Private mController As clsBgThread
    Private objDefaultSettings As AldysGraph.Defaults

    Private mblnIsHCLEMode As Boolean
    Private mblnIsLampOptimized As Boolean
    Private mdblOptimizedWavelength As Double

    Private mintOccurence As Integer = 0

    Private LampOptimizationThread As New clsBgLampOptimization

    Dim mobjCurve As AldysGraph.CurveItem

#End Region

#Region " Public Properties "

    Public ReadOnly Property IsLampOptimized() As Boolean
        Get
            Return mblnIsLampOptimized
        End Get
    End Property

    Public ReadOnly Property OptimizedWavelength() As Double
        Get
            Return mdblOptimizedWavelength
        End Get
    End Property

#End Region

#Region " Form Events "

    Private Sub frmTurretOptimisation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmTurretOptimisation_Load
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : for handle an event
        ' Description           : initialize form and other settings
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 24.06.07
        ' Revisions             : 
        '=====================================================================
        Dim intCount As Integer
        Dim objdtWV As DataTable
        Dim intWvCount As Integer
        Dim dblWV As Double
        Dim intWv As Integer

        Try
            'Saurabh 27.07.07 Setting for Emission Mode
            If Not gstructSettings.EnableServiceUtility Then
                If gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
                    lblLampCurrent.Visible = False
                    lblBurnerFlame.Visible = False
                    lblWavelength.Location = New Point(11, 128)
                    lblSlitWidth.Location = New Point(173, 128)
                End If
            Else
                If gobjInst.Mode = EnumCalibrationMode.EMISSION Then
                    lblLampCurrent.Visible = False
                    lblBurnerFlame.Visible = False
                    lblWavelength.Location = New Point(11, 128)
                    lblSlitWidth.Location = New Point(173, 128)
                End If
            End If
            'Saurabh 27.07.07
            If Not IsNothing(gobjNewMethod) Then
                objdtWV = gobjNewMethod.InstrumentCondition.Wavelength.Copy
            End If

            '---get wavelength to latch
            If Not gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then
                If Not IsNothing(objdtWV) Then
                    For intWvCount = 0 To objdtWV.Rows.Count - 1
                        If objdtWV.Rows.Item(intWvCount).Item(0) = gobjNewMethod.InstrumentCondition.SelectedWavelengthID Then
                            dblWV = objdtWV.Rows.Item(intWvCount).Item(2)
                        End If
                    Next
                End If
                intWv = Fix(dblWV)
            Else
                intWv = Fix(gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).Wavelength)
            End If


            '---Saurabh----23.06.07
            If Not IsNothing(gobjNewMethod) Then
                If gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
                    intWv = Fix(gobjInst.Lamp.EMSCondition.Wavelength)
                End If
            End If
            '---Saurabh----23.06.07

            '---set graph axis values
            aasGraphTurretOptimisation.XAxisMin = intWv - 1
            aasGraphTurretOptimisation.XAxisMax = intWv + 1
            '---Added by Mangesh on 14-Mar-2007
            aasGraphTurretOptimisation.AldysPane.XAxis.Min = intWv - 1
            aasGraphTurretOptimisation.AldysPane.XAxis.Max = intWv + 1
            aasGraphTurretOptimisation.XAxisStep = 0.5
            aasGraphTurretOptimisation.XAxisMinorStep = 0.1
            '---Added by Mangesh on 14-Mar-2007
            '-----------------------------------------------------------------------------------------------
            aasGraphTurretOptimisation.AldysPane.Legend.IsVisible = False

            '---set form title according to operation mode
            If (mblnIsHCLEMode) Then
                'Me.Text = "Analytical Peak Search"
                Select Case gobjNewMethod.OperationMode
                    Case EnumOperationMode.MODE_AA
                        Me.Text = "ANALYTICAL LINE SEARCH - AA Mode"
                    Case EnumOperationMode.MODE_AABGC
                        Me.Text = "ANALYTICAL LINE SEARCH - AABGC Mode"
                End Select
                aasGraphTurretOptimisation.YAxisLabel = "ENERGY"
                aasGraphTurretOptimisation.YAxisMax = 80 'gFuncGetEnergy(2047.0 + 409.6 * 4)
            Else
                Me.Text = "Emission Peak Search"
                aasGraphTurretOptimisation.YAxisLabel = "EMISSION"
                aasGraphTurretOptimisation.YAxisMax = 100 'gFuncGetEnergy(2047.0 + 409.6 * 5)
            End If
            aasGraphTurretOptimisation.YAxisMin = gFuncGetEnergy(2047)
            aasGraphTurretOptimisation.XAxisLabel = "WAVELENGTH (nm)"

            btnClose.Visible = False
            mblnIsLampOptimized = False

            aasGraphTurretOptimisation.Refresh()
            Refresh()
            Application.DoEvents()
            '---start analytical peak search thread

            Call StartOptimizeTread()

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
            If Not objdtWV Is Nothing Then
                objdtWV.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub frmTurretOptimisation_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        '=====================================================================
        ' Procedure Name        : frmTurretOptimisation_Closing
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : for handle an event
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 24.06.07
        ' Revisions             : 
        '=====================================================================
        Try

            '---to close the form
            If mController.IsThreadRunning Then
                mController.Cancel()
                gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
                Application.DoEvents()
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

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        '=====================================================================
        ' Procedure Name        : btnClose_Click
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : for handle an event
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 24.06.07
        ' Revisions             : 
        '=====================================================================
        Try
            Me.Close()
            Me.Dispose()

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

#Region " IClient Events for receiving the Turrent Position value from thread "

    Public Sub Completed(ByVal Cancelled As Boolean) Implements BgThread.Iclient.Completed
        '=====================================================================
        ' Procedure Name        : Completed
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : for handle an event
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 24.06.07
        ' Revisions             : 
        '=====================================================================
        Try
            'btnClose.Visible = True

            aasGraphTurretOptimisation.AldysPane.Legend.IsVisible = False

            If Not Cancelled Then
                If Not IsNothing(mobjCurve) Then
                    aasGraphTurretOptimisation.StopOnlineGraph(mobjCurve)
                    aasGraphTurretOptimisation.DrawHighestPeakLine(mobjCurve)
                    aasGraphTurretOptimisation.ShowHighPeakLineLabel("Optimized Wavelength", False, 0)

                    If aasGraphTurretOptimisation.AldysPane.CurveList.Count > 1 Then
                        If (aasGraphTurretOptimisation.AldysPane.CurveList(1).IsHighPeakLine) Then
                            mdblOptimizedWavelength = aasGraphTurretOptimisation.AldysPane.CurveList(1).HighPeakXValue
                            lblLampPosition.Text = "Optimized Wavelength :- " & FormatNumber(mdblOptimizedWavelength, 2)
                        End If
                    End If
                    mblnIsLampOptimized = LampOptimizationThread.IsLampOptimized
                End If
            End If

            gobjCommProtocol.mobjCommdll.subTime_Delay(1500)
            Me.DialogResult = DialogResult.Cancel

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

    Public Sub Display(ByVal Text As String) Implements BgThread.Iclient.Display
        '=====================================================================
        ' Procedure Name        : Display
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               :  to plot graph
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 24.06.07
        ' Revisions             : 
        '=====================================================================
        Dim strDataValues() As String
        Dim dblX, dblY As Double

        Try
            '---to plot graph
            If Not Text = String.Empty Then
                strDataValues = Text.Split(",")

                If strDataValues.Length > 0 Then
                    mintOccurence = mintOccurence + 1

                    If gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then '06.09.07
                        dblX = CDbl(strDataValues(0))
                        dblY = CDbl(strDataValues(1))
                        If dblY < 0 Then
                            dblY = 0
                        End If
                    Else
                        dblX = CDbl(strDataValues(0))
                        dblY = CDbl(strDataValues(1))
                    End If


                    If mintOccurence = 1 Then
                        mobjCurve = aasGraphTurretOptimisation.StartOnlineGraph("AnalysisPeak", Color.Red, AldysGraph.SymbolType.NoSymbol)
                        aasGraphTurretOptimisation.PlotPoint(mobjCurve, dblX, dblY)
                    Else
                        aasGraphTurretOptimisation.PlotPoint(mobjCurve, dblX, dblY)
                    End If

                    aasGraphTurretOptimisation.AldysPane.XAxis.PickScale(aasGraphTurretOptimisation.XAxisMin, aasGraphTurretOptimisation.XAxisMax)
                    aasGraphTurretOptimisation.AldysPane.XAxis.StepAuto = True
                    aasGraphTurretOptimisation.AldysPane.XAxis.MinorStepAuto = True

                    aasGraphTurretOptimisation.AldysPane.YAxis.PickScale(aasGraphTurretOptimisation.YAxisMin, aasGraphTurretOptimisation.YAxisMax)
                    aasGraphTurretOptimisation.AldysPane.YAxis.StepAuto = True
                    aasGraphTurretOptimisation.AldysPane.YAxis.MinorStepAuto = True

                    aasGraphTurretOptimisation.AldysPane.AxisChange()
                    aasGraphTurretOptimisation.Invalidate()

                    Call Application.DoEvents()
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

    End Sub

    Public Sub Start(ByVal clsBgThread As BgThread.clsBgThread) Implements BgThread.Iclient.Start

    End Sub

#End Region

#Region " Public Functions "

    Public Sub StartOptimizeTread()
        '=====================================================================
        ' Procedure Name        : StartOptimizeTread
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               :  to start lamp optimization thread
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 24.06.07
        ' Revisions             : 
        '=====================================================================
        Try
            mController = New clsBgThread(Me)
            gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
            Application.DoEvents()
            LampOptimizationThread = New clsBgLampOptimization(mblnIsHCLEMode, aasGraphTurretOptimisation, _
                                                               lblPMT, lblLampPosition, lblLampOptimisation, _
                                                               lblElementName, lblLampCurrent, lblWavelength, _
                                                               lblSlitWidth, lblBurnerFlame)

            '---start the lamp optimization thread
            mController.Start(LampOptimizationThread)

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

End Class
