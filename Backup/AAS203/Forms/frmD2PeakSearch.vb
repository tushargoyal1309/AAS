Imports System.Threading
Imports AAS203.Common
Imports BgThread
Imports System.IO
Imports Microsoft.VisualBasic
'Imports AAS203.Spectrum
Public Class frmD2PeakSearch
    Inherits System.Windows.Forms.Form
    Implements Iclient

#Region " Private Variable "


    Dim mblnAvoidProcessing As Boolean
    Dim mblnD2OptimiseStarted As Boolean
    'Private mController As New clsBgThread(Me)
    '--- Declaration for the controller object of the BgThread
    Private mobjController As New BgThread.clsBgThread(Me)
    Private mobjclsBgD2Optimisation As clsBgD2Optimisation

    Private Const CONST_486XaxisMin = 480.0
    Private Const CONST_486XaxisMax = 490.0
    Dim m_486YaxisMin As Double = 0.0
    Dim m_486YaxisMax As Double = 40.0


    Private Const CONST_656XaxisMin = 650.0
    Private Const CONST_656XaxisMax = 660.0
    Dim m_656YaxisMin As Double = 0.0
    Dim m_656YaxisMax As Double = 40.0

    'Dim m_486PeakCurveItem As AldysGraph.CurveItem
    'Dim m_656PeakCurveItem As AldysGraph.CurveItem

    '//----- Display peak on Graph 
    Dim m_dblYMax486 As Double = 0.0
    Dim m_dblYMax656 As Double = 0.0

    Dim m_dblYMin486 As Double = 0.0
    Dim m_dblYMin656 As Double = 0.0

    Dim blnIsFoundPeak486Flag As Boolean
    Dim blnIsFoundPeak656Flag As Boolean

    Dim m_dtPeak486 As New DataTable
    Dim m_dtPeak656 As New DataTable
    Private m_dblXmax656 As Double      'Saurabh to Check Tolerance
    Private m_dblXmax486 As Double      'Saurabh to Check Tolerance
    Private mblnD2PeakOK As Boolean     'Saurabh to Check Tolerance
    Private mblnD2Peak486OK As Double
    Private mblnD2Peak656OK As Double
    

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
    Friend WithEvents CustomPanel1 As GradientPanel.CustomPanel
    Friend WithEvents CustomPanel2 As GradientPanel.CustomPanel
    Friend WithEvents AASD2EnergyPeak486 As AAS203.AASGraph
    Friend WithEvents AASD2EnergyPeak656 As AAS203.AASGraph
    Friend WithEvents CustomPanel3 As GradientPanel.CustomPanel
    Friend WithEvents lbl4 As System.Windows.Forms.Label
    Friend WithEvents Lbl3 As System.Windows.Forms.Label
    Friend WithEvents Lbl2 As System.Windows.Forms.Label
    Friend WithEvents btnPrintGraph As NETXP.Controls.XPButton
    Friend WithEvents btnReturn1 As System.Windows.Forms.Button
    Friend WithEvents btnReturn As NETXP.Controls.XPButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmD2PeakSearch))
        Me.CustomPanel1 = New GradientPanel.CustomPanel
        Me.CustomPanel3 = New GradientPanel.CustomPanel
        Me.btnReturn = New NETXP.Controls.XPButton
        Me.btnPrintGraph = New NETXP.Controls.XPButton
        Me.lbl4 = New System.Windows.Forms.Label
        Me.Lbl3 = New System.Windows.Forms.Label
        Me.Lbl2 = New System.Windows.Forms.Label
        Me.btnReturn1 = New System.Windows.Forms.Button
        Me.CustomPanel2 = New GradientPanel.CustomPanel
        Me.AASD2EnergyPeak656 = New AAS203.AASGraph
        Me.AASD2EnergyPeak486 = New AAS203.AASGraph
        Me.CustomPanel1.SuspendLayout()
        Me.CustomPanel3.SuspendLayout()
        Me.CustomPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'CustomPanel1
        '
        Me.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanel1.Controls.Add(Me.CustomPanel3)
        Me.CustomPanel1.Controls.Add(Me.CustomPanel2)
        Me.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanel1.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanel1.Name = "CustomPanel1"
        Me.CustomPanel1.Size = New System.Drawing.Size(650, 423)
        Me.CustomPanel1.TabIndex = 0
        '
        'CustomPanel3
        '
        Me.CustomPanel3.Controls.Add(Me.btnReturn)
        Me.CustomPanel3.Controls.Add(Me.btnPrintGraph)
        Me.CustomPanel3.Controls.Add(Me.lbl4)
        Me.CustomPanel3.Controls.Add(Me.Lbl3)
        Me.CustomPanel3.Controls.Add(Me.Lbl2)
        Me.CustomPanel3.Controls.Add(Me.btnReturn1)
        Me.CustomPanel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CustomPanel3.Location = New System.Drawing.Point(0, 327)
        Me.CustomPanel3.Name = "CustomPanel3"
        Me.CustomPanel3.Size = New System.Drawing.Size(650, 96)
        Me.CustomPanel3.TabIndex = 9
        '
        'btnReturn
        '
        Me.btnReturn.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReturn.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReturn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReturn.Location = New System.Drawing.Point(328, 64)
        Me.btnReturn.Name = "btnReturn"
        Me.btnReturn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnReturn.Size = New System.Drawing.Size(110, 25)
        Me.btnReturn.TabIndex = 8
        Me.btnReturn.Text = "&Return"
        '
        'btnPrintGraph
        '
        Me.btnPrintGraph.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintGraph.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintGraph.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrintGraph.Location = New System.Drawing.Point(328, 32)
        Me.btnPrintGraph.Name = "btnPrintGraph"
        Me.btnPrintGraph.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnPrintGraph.Size = New System.Drawing.Size(110, 25)
        Me.btnPrintGraph.TabIndex = 7
        Me.btnPrintGraph.Text = "&Print Graph"
        Me.btnPrintGraph.Visible = False
        '
        'lbl4
        '
        Me.lbl4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl4.BackColor = System.Drawing.Color.White
        Me.lbl4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl4.ForeColor = System.Drawing.Color.Blue
        Me.lbl4.Location = New System.Drawing.Point(30, 19)
        Me.lbl4.Name = "lbl4"
        Me.lbl4.Size = New System.Drawing.Size(280, 16)
        Me.lbl4.TabIndex = 5
        Me.lbl4.Text = "D2 Peak Search"
        '
        'Lbl3
        '
        Me.Lbl3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Lbl3.BackColor = System.Drawing.Color.White
        Me.Lbl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl3.ForeColor = System.Drawing.Color.Blue
        Me.Lbl3.Location = New System.Drawing.Point(30, 43)
        Me.Lbl3.Name = "Lbl3"
        Me.Lbl3.Size = New System.Drawing.Size(280, 16)
        Me.Lbl3.TabIndex = 4
        '
        'Lbl2
        '
        Me.Lbl2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Lbl2.BackColor = System.Drawing.Color.White
        Me.Lbl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl2.ForeColor = System.Drawing.Color.Blue
        Me.Lbl2.Location = New System.Drawing.Point(30, 67)
        Me.Lbl2.Name = "Lbl2"
        Me.Lbl2.Size = New System.Drawing.Size(280, 16)
        Me.Lbl2.TabIndex = 3
        '
        'btnReturn1
        '
        Me.btnReturn1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnReturn1.Location = New System.Drawing.Point(456, 32)
        Me.btnReturn1.Name = "btnReturn1"
        Me.btnReturn1.Size = New System.Drawing.Size(88, 24)
        Me.btnReturn1.TabIndex = 6
        Me.btnReturn1.Text = "&Return"
        Me.btnReturn1.Visible = False
        '
        'CustomPanel2
        '
        Me.CustomPanel2.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanel2.Controls.Add(Me.AASD2EnergyPeak656)
        Me.CustomPanel2.Controls.Add(Me.AASD2EnergyPeak486)
        Me.CustomPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanel2.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanel2.Name = "CustomPanel2"
        Me.CustomPanel2.Size = New System.Drawing.Size(650, 423)
        Me.CustomPanel2.TabIndex = 8
        '
        'AASD2EnergyPeak656
        '
        Me.AASD2EnergyPeak656.AldysGraphCursor = Nothing
        Me.AASD2EnergyPeak656.AldysGraphPrintColor = System.Drawing.Color.Black
        Me.AASD2EnergyPeak656.BackColor = System.Drawing.Color.LightGray
        Me.AASD2EnergyPeak656.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AASD2EnergyPeak656.GraphDataSource = Nothing
        Me.AASD2EnergyPeak656.GraphImage = Nothing
        Me.AASD2EnergyPeak656.IsShowGrid = True
        Me.AASD2EnergyPeak656.Location = New System.Drawing.Point(328, 3)
        Me.AASD2EnergyPeak656.Name = "AASD2EnergyPeak656"
        Me.AASD2EnergyPeak656.Size = New System.Drawing.Size(320, 312)
        Me.AASD2EnergyPeak656.TabIndex = 28
        Me.AASD2EnergyPeak656.UseDefaultSettings = False
        Me.AASD2EnergyPeak656.XAxisDateMax = New Date(CType(0, Long))
        Me.AASD2EnergyPeak656.XAxisDateMin = New Date(CType(0, Long))
        Me.AASD2EnergyPeak656.XAxisDateScaleFormat = AAS203.AASGraph.enumDateScaleFormat.YYYY
        Me.AASD2EnergyPeak656.XAxisLabel = "Wv"
        Me.AASD2EnergyPeak656.XAxisMax = 660
        Me.AASD2EnergyPeak656.XAxisMin = 650
        Me.AASD2EnergyPeak656.XAxisMinorStep = 0.5
        Me.AASD2EnergyPeak656.XAxisScaleFormat = Nothing
        Me.AASD2EnergyPeak656.XAxisStep = 1
        Me.AASD2EnergyPeak656.XAxisType = AldysGraph.AxisType.Linear
        Me.AASD2EnergyPeak656.YAxisLabel = "ENERGY"
        Me.AASD2EnergyPeak656.YAxisMax = 10
        Me.AASD2EnergyPeak656.YAxisMin = 0
        Me.AASD2EnergyPeak656.YAxisMinorStep = 0.5
        Me.AASD2EnergyPeak656.YAxisScaleFormat = Nothing
        Me.AASD2EnergyPeak656.YAxisStep = 1
        Me.AASD2EnergyPeak656.YAxisType = AldysGraph.AxisType.Linear
        '
        'AASD2EnergyPeak486
        '
        Me.AASD2EnergyPeak486.AldysGraphCursor = Nothing
        Me.AASD2EnergyPeak486.AldysGraphPrintColor = System.Drawing.Color.Black
        Me.AASD2EnergyPeak486.BackColor = System.Drawing.Color.LightGray
        Me.AASD2EnergyPeak486.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AASD2EnergyPeak486.GraphDataSource = Nothing
        Me.AASD2EnergyPeak486.GraphImage = Nothing
        Me.AASD2EnergyPeak486.IsShowGrid = True
        Me.AASD2EnergyPeak486.Location = New System.Drawing.Point(8, 3)
        Me.AASD2EnergyPeak486.Name = "AASD2EnergyPeak486"
        Me.AASD2EnergyPeak486.Size = New System.Drawing.Size(318, 313)
        Me.AASD2EnergyPeak486.TabIndex = 27
        Me.AASD2EnergyPeak486.UseDefaultSettings = True
        Me.AASD2EnergyPeak486.XAxisDateMax = New Date(CType(0, Long))
        Me.AASD2EnergyPeak486.XAxisDateMin = New Date(CType(0, Long))
        Me.AASD2EnergyPeak486.XAxisDateScaleFormat = AAS203.AASGraph.enumDateScaleFormat.YYYY
        Me.AASD2EnergyPeak486.XAxisLabel = "Wv"
        Me.AASD2EnergyPeak486.XAxisMax = 490
        Me.AASD2EnergyPeak486.XAxisMin = 480
        Me.AASD2EnergyPeak486.XAxisMinorStep = 2
        Me.AASD2EnergyPeak486.XAxisScaleFormat = Nothing
        Me.AASD2EnergyPeak486.XAxisStep = 10
        Me.AASD2EnergyPeak486.XAxisType = AldysGraph.AxisType.Linear
        Me.AASD2EnergyPeak486.YAxisLabel = "ENERGY"
        Me.AASD2EnergyPeak486.YAxisMax = 100
        Me.AASD2EnergyPeak486.YAxisMin = 0
        Me.AASD2EnergyPeak486.YAxisMinorStep = 5
        Me.AASD2EnergyPeak486.YAxisScaleFormat = Nothing
        Me.AASD2EnergyPeak486.YAxisStep = 10
        Me.AASD2EnergyPeak486.YAxisType = AldysGraph.AxisType.Linear
        '
        'frmD2PeakSearch
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(650, 423)
        Me.Controls.Add(Me.CustomPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmD2PeakSearch"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "D2 Peak Test"
        Me.CustomPanel1.ResumeLayout(False)
        Me.CustomPanel3.ResumeLayout(False)
        Me.CustomPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Form Events"

    Private Sub frmD2PeakSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmD2PeakSearch_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : to load initial settings and to start d2 peak search
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            If mblnAvoidProcessing = True Then
                Exit Sub
            End If
            mblnAvoidProcessing = True
            'ShowProgressBar(ConstFormLoad)
            '---form initialize
            Call funcInitialise()
            'funcOnContinuesScan()
            '
            '---call d2 peak search routine
            funcOnOptimise(Lbl3, Lbl2)

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
            'HideProgressBar()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub frmD2PeakSearch_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        '=====================================================================
        ' Procedure Name        : frmD2PeakSearch_Closing
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : to close the form and start flame status
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Try
            If Not mobjclsBgD2Optimisation Is Nothing Then
                If mblnAvoidProcessing = True Then
                    e.Cancel = True
                Else
                    e.Cancel = False
                    If Not IsNothing(gobjMain) Then
                        If gobjMain.mobjController.IsThreadRunning = False Then
                            gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)
                            Application.DoEvents()
                            gobjMain.mobjController.Start(gobjclsBgFlameStatus)
                        End If
                        gobjfrmStatus.Visible = True
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

    Private Sub mnuExit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuExit_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To close the Energy Spectrum Mode form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 07.10.06
        ' Revisions             : 
        '=====================================================================
        Try
            'stop thread if running

            If Not mobjclsBgD2Optimisation Is Nothing Then
                If mblnAvoidProcessing = True Then
                    Application.DoEvents()
                    mobjclsBgD2Optimisation.ThTerminate = True
                    Exit Sub
                Else
                    If Not (mobjController Is Nothing) Then
                        If mobjController.IsThreadRunning Then
                            mobjController.Cancel()
                        End If
                    End If
                End If
            End If
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

#Region "Private functions"

    Private Function funcInitialise()
        '=====================================================================
        ' Procedure Name        : funcInitialise
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : Initialise the form Object
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim objdtCol1 As DataColumn
        Dim objdtCol2 As DataColumn
        Dim objdtCol3 As DataColumn
        Dim objdtCol4 As DataColumn
        Try


            '//----- Create Data Table to hold Scan Data for 486 and 656 peaks
            objdtCol1 = New DataColumn("Xaxis", GetType(Double))
            objdtCol2 = New DataColumn("Yaxis", GetType(Double))
            objdtCol3 = New DataColumn("Xaxis", GetType(Double))
            objdtCol4 = New DataColumn("Yaxis", GetType(Double))

            m_dtPeak486.Columns.Add(objdtCol1)
            m_dtPeak486.Columns.Add(objdtCol2)

            m_dtPeak656.Columns.Add(objdtCol3)
            m_dtPeak656.Columns.Add(objdtCol4)
            '//------
            'cmbSpeed.Visible = True
            lbl4.Text = "Search D2 Peak for 486"
            lbl4.Refresh()
            'Call gobjClsAAS203.funcSetInstrumentCondns(True, lblElementName, lblLampCurrent, lblWavelength, lblSlitWidth, lblBurnerFlame)

            '//----- Disable Element name and Turret no 
            gobjfrmStatus.lblElementName.Text = ""
            gobjfrmStatus.lblTurretNo.Text = ""


            '//-----
            If Not IsNothing(gobjMain) Then
                ''mblnIsfrmFlameStatusWork = True
                gobjMain.mobjController.Cancel()
                gobjCommProtocol.mobjCommdll.subTime_Delay(500)   '10.12.07
                Application.DoEvents()
            End If
            Application.DoEvents()
            Call AddHandlers()

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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Private Sub AddHandlers()
        '=====================================================================
        ' Procedure Name        : AddHandlers
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To add event handlers
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh
        ' Created               : 15.11.06
        ' Revisions             : 
        '=====================================================================
        Try
            'add handler to button
            AddHandler btnReturn.Click, AddressOf mnuExit_Click

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


    Public Function funcOnOptimise(ByRef lblScanStatus As System.Object, _
           ByRef lblOnlineWv As System.Object) As Boolean
        '=====================================================================
        ' Procedure Name        : funcOnOptimise
        ' Parameters Passed     : lblScanStatus,lblOnlineWv as object
        ' Returns               : Bool. True if success
        ' Purpose               :  Start to search D2 peak
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh
        ' Created               : 15.11.06
        ' Revisions             : 
        '=====================================================================
        mblnAvoidProcessing = True
        Try
            '//----- Orig
            'addata.counter = 0;
            ' if (addata.speed==0){
            'if (GetInstrument()==AA202) addata.speed=FASTSTEP_AA202;
            'else addata.speed=FAST;
            ' }
            ' speed = addata.speed;
            '/-----

            '----for graph initial setting
            If Not funcGraphPreRequisite(AASD2EnergyPeak486, _
                            CONST_486XaxisMin, _
                            CONST_486XaxisMax, _
                            m_486YaxisMin, _
                            m_486YaxisMax) Then
                Exit Function
            End If
            If AASD2EnergyPeak656.AldysPane.CurveList.Count > 0 Then
                AASD2EnergyPeak486.AldysPane.CurveList(0).Label = "Peak for 486.00 nm"
            End If

            '----for graph initial setting
            If Not funcGraphPreRequisite(AASD2EnergyPeak656, _
                                        CONST_656XaxisMin, _
                                        CONST_656XaxisMax, _
                                        m_656YaxisMin, _
                                        m_656YaxisMax) Then
                Exit Function
            End If
           


            mblnD2OptimiseStarted = True
            '--- Start the Spectrum analysis
            mobjController = New clsBgThread(Me)
            mobjclsBgD2Optimisation = New clsBgD2Optimisation(Lbl3, Lbl2)
            '---start d2 optimization thread
            mobjController.Start(mobjclsBgD2Optimisation)

            funcOnOptimise = True
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

#End Region

#Region " IClient Events for receiving the wavelength and Abs value from Receiving thread "

    Private Sub TaskStarted(ByVal BgThread As clsBgThread) _
        Implements BgThread.Iclient.Start
        '=====================================================================
        ' Procedure Name        : TaskStarted
        ' Parameters Passed     : BgThread As clsBgThread
        ' Returns               : Iclient.Start
        ' Purpose               : Thread task is started  
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh
        ' Created               : 15.11.06
        ' Revisions             : 
        '=====================================================================
        Try
            mblnAvoidProcessing = True
        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
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

    Private Sub TaskStatus(ByVal Text As String) _
        Implements Iclient.Display
        '=====================================================================
        ' Procedure Name        : TaskStatus
        ' Parameters Passed     : Text
        ' Returns               : Iclient.Display
        ' Purpose               : get the data from thread 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh
        ' Created               : 15.11.06
        ' Revisions             : 
        '=====================================================================
        Try
            '---send data to display on form
            Call funcIclientTaskDisplayData(Text)

        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '--------------------------------------------------------
        End Try
    End Sub


    Private Sub TaskFailed(ByVal e As Exception) _
    Implements Iclient.Failed
        '=====================================================================
        ' Procedure Name        : TaskFailed
        ' Parameters Passed     : Exception
        ' Returns               : Iclient.Failed as Implements
        ' Purpose               :  
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh
        ' Created               : 15.11.06
        ' Revisions             : 
        '=====================================================================
        Try
            funcIclientTaskFalied()
            mblnAvoidProcessing = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
            mblnAvoidProcessing = False
        End Try
    End Sub

    Private Sub TaskCompleted(ByVal Cancelled As Boolean) _
             Implements Iclient.Completed
        '=====================================================================
        ' Procedure Name        : TaskCompleted
        ' Parameters Passed     : Cancelled
        ' Returns               : Iclient.Completed as Implemented
        ' Purpose               :  
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh
        ' Created               : 15.11.06
        ' Revisions             : 
        '=====================================================================
        Try
            Call funcIclientTaskCompleted()

            mblnAvoidProcessing = False

        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
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

#Region "IClient Private Function"

    Private Function funcIclientTaskCompleted() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcIclientTaskCompleted
        ' Description           :   task completed received from instrument 
        '                           
        ' Purpose               :   
        ' Parameters Passed     :  None
        ' Returns               :   True, if successful.
        ' Parameters Affected   :   
        ' Assumptions           :   None.
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale
        ' Created               :   17.12.06
        ' Revisions             :
        '=====================================================================

        Try
            funcIclientTaskCompleted = False

            '---after finish of thread display highest peak
            If blnIsFoundPeak656Flag = True Then
                AASD2EnergyPeak656.YAxisMax = gFuncGetEnergy(m_dblYMax656 + 50.0)
                AASD2EnergyPeak656.YAxisMin = gFuncGetEnergy(m_dblYMin656 - 4.096)
                funcDisplayGraph(AASD2EnergyPeak656, m_dtPeak656)
                If AASD2EnergyPeak656.AldysPane.CurveList.Count > 0 Then
                    AASD2EnergyPeak656.AldysPane.CurveList(0).Label = "Peak for 656.1 nm"
                End If
                AASD2EnergyPeak656.DrawHighestPeakLine(AASD2EnergyPeak656.AldysPane.CurveList(0))
                AASD2EnergyPeak656.ShowHighPeakLineLabel("  Max. Position ", False, 20)
            Else
                '--- Else display each point on graph
                funcDisplayGraph(AASD2EnergyPeak656, m_dtPeak656)
                If AASD2EnergyPeak656.AldysPane.CurveList.Count > 0 Then
                    AASD2EnergyPeak656.AldysPane.CurveList(0).Label = "Peak for 656.1 nm"
                End If
            End If

            AASD2EnergyPeak656.AldysPane.AxisChange()
            AASD2EnergyPeak656.Refresh()
            Application.DoEvents()

            funcScanCompleted(True)
            mblnAvoidProcessing = False
            funcIclientTaskCompleted = True

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

    Private Function funcIclientTaskFalied() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcIclientTaskFalied
        ' Description           :   task falied received from instrument 
        '                           
        ' Purpose               :   
        ' Parameters Passed     :   None
        ' Returns               :   True, if successful.
        ' Parameters Affected   :   
        ' Assumptions           :   None.
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale
        ' Created               :   18.12.06
        ' Revisions             :
        '=====================================================================

        Try
            funcIclientTaskFalied = False

            ' If scan is terminated by user in between then gblnSpectrumTerminated = True
            'If ArrlstGraphCurveItem.Count >= intCurveIndex + 1 Then

            'intCurveIndex += 1
            ' End If

            'mobjOnlineChannel = New Channel(True)
            'mobjOnlineReadings = New Readings
            'mblnSpectrumStarted = False

            'Application.DoEvents()
            'display message for termination and write pmt to ini file
            funcScanCompleted(False)

            Application.DoEvents()
            gobjMessageAdapter.ShowMessage(constSpectrumScanningFailed)
            Application.DoEvents()
            'gFuncShowMessage("Error...", "Spectrum scanning failed.", EnumMessageType.Information)
            mblnAvoidProcessing = False
            funcIclientTaskFalied = True

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

    Private Function funcScanCompleted(ByVal blnCompleted As Boolean) As Boolean
        '=====================================================================
        ' Procedure Name        :   funcScanCompleted
        ' Description           :   if scan completed or terminated by user
        ' Purpose               :   to show termination message and write D2 pmt to ini file
        ' Parameters Passed     :   blnCompleted is true if completed successfully 
        '                          & false if terminated by user
        ' Returns               :   True, if successful.
        ' Parameters Affected   :   
        ' Assumptions           :   None.
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale
        ' Created               :   Tuesday, April 06, 2004 18:36
        ' Revisions             :
        '=====================================================================
        Dim dblD2_PMT As Integer
        Try
            '--- Check for D2 peak where it's detected or not and set messsage
            If blnCompleted Then
                If mblnD2PeakOK = True Then
                    lbl4.Text = "Search D2 Peak OK"
                    lbl4.Refresh()
                Else
                    lbl4.Text = "Search D2 Peak Failed"
                    lbl4.Refresh()
                End If
            Else
                lbl4.Text = "Search D2 Peak Failed"
                lbl4.Refresh()
            End If

            '--- write D2 PMT to ini 
            dblD2_PMT = gobjInst.PmtVoltage
            gFuncWriteToINI(SECTION_D2Setting, KEY_D2PMT, CStr(dblD2_PMT), INI_SETTINGS_PATH)

            Me.Cursor = Cursors.Default
            gblnSpectrumTerminated = False
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

    Private Function funcIclientTaskDisplayData(ByVal strData As String) As Boolean
        '=====================================================================
        ' Procedure Name        :   funcIclientTaskDisplayData
        ' Description           :   Plot the graph on the screen.
        ' Purpose               :   To plot the graph on the screen for the given
        '                           Wavelength and absorbtion.           
        ' Parameters Passed     :   strData.
        ' Returns               :   True, if successful.
        ' Parameters Affected   :   
        ' Assumptions           :   Graph object is already decleare.
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale 
        ' Created               :   10.12.06
        ' Revisions             :
        '=====================================================================
        '---to display graph of d2 peak search
        Try
            '-----------------------------------------------------
            'Data in the Text arg would be "Wavelength|Abs"
            '-----------------------------------------------------
            'Dim objData As New Spectrum.Data
            Dim arrData() As String
            Dim O As Integer   ' same as in function funcSmoothgraphonline
            Dim intCount As Integer
            Dim mRunningTab486 As Boolean = False
            Dim mRunningTab656 As Boolean = False
            Dim XaxisData As Double
            Dim YaxisData As Double
            Dim YaxisValue As Double
            Dim dtRow As DataRow
            Static Dim blnIsTabSetting As Boolean
            Static Dim blnIsTabChange As Boolean

            Application.DoEvents()
            '--- Split the data for Wv and Abs
            arrData = Split(strData, "|")

            If arrData(0).Length > 0 And arrData(1).Length > 0 Then
                mRunningTab486 = arrData(2)
                mRunningTab656 = arrData(3)
                XaxisData = Val(arrData(0))   ' wv

                YaxisData = Val(arrData(1))
                YaxisValue = gFuncGetEnergy(YaxisData)
                Lbl3.Text = "Wavelength : " & Format(XaxisData, "#000.0") & " Energy : " & Format(YaxisValue, "#00.00") & "%"
                Lbl3.Refresh()
                '==================================
                'for (i=0; i<n; i++){
                'if (arri]>ymax) 
                'Static Dim dblYMax As Double


                '		  ymax = arr[i];
                '		  ioff=i;
                '		  flag=TRUE;
                '		  }
                '	  if (arr[i]<ymin) ymin = arr[i];
                '		 }
                '	PeakGraph.Ymax=  GetEnergy(ymax+8.192);
                '	PeakGraph.Ymin=  GetEnergy(ymin-4.096);

                '================================

                If blnIsTabChange = False Then
                    If mRunningTab486 = False And mRunningTab656 = False Then

                        If blnIsTabSetting = False Then
                            blnIsTabSetting = True
                            blnIsTabChange = False
                            m_dblYMin486 = YaxisData
                        Else
                        End If
                        If m_dblYMax486 < YaxisData Then
                            m_dblYMax486 = YaxisData
                            blnIsFoundPeak486Flag = True
                            m_dblXmax486 = XaxisData        'Saurabh 29.07.07 To check D2Peak OK
                        End If
                        If (YaxisData < m_dblYMin486) Then
                            m_dblYMin486 = YaxisData
                        End If

                        dtRow = m_dtPeak486.NewRow
                        m_dtPeak486.Rows.Add(dtRow)
                        m_dtPeak486.Rows.Item(m_dtPeak486.Rows.Count - 1).Item(0) = XaxisData
                        m_dtPeak486.Rows.Item(m_dtPeak486.Rows.Count - 1).Item(1) = YaxisValue

                        Application.DoEvents()

                    ElseIf mRunningTab486 = True And mRunningTab656 = False Then
                        If blnIsTabSetting = False Then
                            blnIsTabSetting = True
                            blnIsTabChange = False
                            m_dblYMin656 = YaxisData
                            'funcDisplayGraph_RealTime(AASD2EnergyPeak656, m_656PeakCurveItem, XaxisData, YaxisData)
                        Else
                            'funcDisplayGraph_RealTime(AASD2EnergyPeak656, m_656PeakCurveItem, XaxisData, YaxisData)
                        End If

                        If m_dblYMax656 < YaxisData Then
                            m_dblYMax656 = YaxisData
                            blnIsFoundPeak656Flag = True
                            m_dblXmax656 = XaxisData        'Saurabh 29.07.07 To check D2Peak OK
                        End If
                        If (YaxisData < m_dblYMin656) Then
                            m_dblYMin656 = YaxisData

                        End If

                        dtRow = m_dtPeak656.NewRow
                        m_dtPeak656.Rows.Add(dtRow)
                        m_dtPeak656.Rows.Item(m_dtPeak656.Rows.Count - 1).Item(0) = XaxisData
                        m_dtPeak656.Rows.Item(m_dtPeak656.Rows.Count - 1).Item(1) = YaxisValue
                        Application.DoEvents()

                    ElseIf mRunningTab486 = True And mRunningTab656 = True Then
                        blnIsTabChange = False
                        blnIsTabSetting = False
                        AASD2EnergyPeak486.XAxisMax = 490.0
                        AASD2EnergyPeak486.XAxisMin = 480.0

                        If blnIsFoundPeak486Flag = True Then
                            AASD2EnergyPeak486.YAxisMax = gFuncGetEnergy(m_dblYMax486) + 1.5
                            AASD2EnergyPeak486.YAxisMin = gFuncGetEnergy(m_dblYMin486 - 4.096)
                            funcDisplayGraph(AASD2EnergyPeak486, m_dtPeak486)
                            If AASD2EnergyPeak486.AldysPane.CurveList.Count > 0 Then
                                AASD2EnergyPeak486.AldysPane.CurveList(0).Label = "Peak for 486.0 nm"
                            End If
                            AASD2EnergyPeak486.DrawHighestPeakLine(AASD2EnergyPeak486.AldysPane.CurveList(0))
                            AASD2EnergyPeak486.ShowHighPeakLineLabel("  Max. Position ", False, 20)


                        Else
                            funcDisplayGraph(AASD2EnergyPeak486, m_dtPeak486)
                            If AASD2EnergyPeak486.AldysPane.CurveList.Count > 0 Then
                                AASD2EnergyPeak486.AldysPane.CurveList(0).Label = "Peak for 486.0 nm"
                            End If
                        End If

                        lbl4.Text = "Search D2 Peak for 656"
                        lbl4.Refresh()
                        AASD2EnergyPeak486.Refresh()
                        Application.DoEvents()

                    End If
                Else
                    If mRunningTab486 = True And mRunningTab656 = True Then
                        blnIsTabChange = False
                        blnIsTabSetting = False
                    End If
                End If
                '--- update D2Peakflag
                '--- Check for D2 peak for 486nm
                If m_dblXmax486 > 487 Or m_dblXmax486 < 485 Then
                    mblnD2Peak486OK = False
                Else
                    mblnD2Peak486OK = True
                End If
                '--- Check for D2 peak for 656nm
                If m_dblXmax656 > 657 Or m_dblXmax656 < 655 Then
                    mblnD2Peak656OK = False
                Else
                    mblnD2Peak656OK = True
                End If
                '--- Check if both peaks are detected then D2 peak search is true
                If mblnD2Peak656OK = True And mblnD2Peak486OK = True Then
                    mblnD2PeakOK = True
                Else
                    mblnD2PeakOK = False

                End If
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
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
            '--------------------------------------------------------
        End Try
    End Function

#End Region

#Region "Graph Method"

    Private Function funcGraphPreRequisite(ByRef AASD2EnergyGraph As AAS203.AASGraph, Optional ByVal intXmin As Double = 0.0, Optional ByVal intXmax As Double = 0.0, Optional ByVal intYmin As Double = 0.0, Optional ByVal intYmax As Double = 0.0) As Boolean
        '=====================================================================
        ' Procedure Name        :   funcGraphPreRequisite
        ' Description           :   for graph settings
        ' Purpose               :   
        ' Parameters Passed     :   
        ' Returns               :   True, if successful.
        ' Parameters Affected   :   
        ' Assumptions           :   
        ' Dependencies          :   
        ' Author                :   Sachin Dokhale 
        ' Created               :   10.12.06
        ' Revisions             :
        '=====================================================================
        Dim dblDiffX As Double
        Dim dblMajorStepX, dblMinorStepX As Double
        Dim dblDiffY As Double
        Dim dblMajorStepY, dblMinorStepY As Double

        Try
            '--- get xmin and ymin
            If intXmin = 0.0 Then
                intXmin = AASD2EnergyGraph.XAxisMin
            End If
            If intXmax = 0.0 Then
                intXmax = AASD2EnergyGraph.XAxisMax
            End If
            If intYmin = 0.0 Then
                intYmin = AASD2EnergyGraph.YAxisMin
            End If
            If intYmax = 0.0 Then
                intYmax = AASD2EnergyGraph.YAxisMax
            End If
            '--- get x major and x minor steps

            dblDiffX = Fix(intXmax - intXmin)
            dblMajorStepX = dblDiffX / 5
            dblMinorStepX = dblMajorStepX / 1
            '--- get y major and y minor steps
            dblDiffY = (intYmax - intYmin)
            dblMajorStepY = dblDiffY / 10
            dblMinorStepY = dblMajorStepY / 2
            AASD2EnergyGraph.btnPeakEdit.Enabled = False
            AASD2EnergyGraph.btnShowXYValues.Enabled = False

            '--- Assigning Values to Xmin,xmax,ymin,ymax properties

            '--- Set font setting for graph 

            AASD2EnergyGraph.XAxisMin = intXmin
            AASD2EnergyGraph.XAxisMax = intXmax
            AASD2EnergyGraph.AldysPane.XAxis.Min = intXmin
            AASD2EnergyGraph.AldysPane.XAxis.Max = intXmax

            AASD2EnergyGraph.AldysPane.FontSpec.Size = 16
            AASD2EnergyGraph.AldysPane.Legend.FontSpec.Size = 20
            AASD2EnergyGraph.AldysPane.Legend.IsVisible = False
            AASD2EnergyGraph.AldysPane.CurveLabelSize = 16
            AASD2EnergyGraph.AldysPane.XAxis.ScaleFontSpec.Size = 16
            AASD2EnergyGraph.AldysPane.YAxis.ScaleFontSpec.Size = 16
            AASD2EnergyGraph.AldysPane.XAxis.TitleFontSpec.Size = 18
            AASD2EnergyGraph.AldysPane.YAxis.TitleFontSpec.Size = 18

            '--- update x min,y min, x max,y max, 
            '--- x minor steps,y minor steps,y major steps, x major steps and the axis lables
            AASD2EnergyGraph.XAxisLabel = "Wv"

            If AASD2EnergyGraph.AldysPane.CurveList.Count > 0 Then
                AASD2EnergyGraph.AldysPane.CurveList(0).Label = "ENERGY"
            End If

            AASD2EnergyGraph.YAxisMin = intYmin
            AASD2EnergyGraph.YAxisMax = intYmax
            AASD2EnergyGraph.YAxisLabel = "ENERGY"

            AASD2EnergyGraph.AldysPane.XAxis.Step = dblMajorStepX
            AASD2EnergyGraph.AldysPane.XAxis.MinorStep = dblMinorStepX
            AASD2EnergyGraph.AldysPane.YAxis.Step = dblMajorStepY
            AASD2EnergyGraph.AldysPane.YAxis.MinorStep = dblMinorStepY

            AASD2EnergyGraph.XAxisStep = dblMajorStepX
            AASD2EnergyGraph.YAxisStep = dblMajorStepY
            AASD2EnergyGraph.XAxisMinorStep = dblMinorStepX
            AASD2EnergyGraph.YAxisMinorStep = dblMinorStepY
            AASD2EnergyGraph.btnPeakEdit.Checked = False
            AASD2EnergyGraph.AldysPane.AxisChange()
            AASD2EnergyGraph.Refresh()

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

    Private Function funcDisplayGraph_RealTime(ByRef AASD2EnergyGraph As AAS203.AASGraph, ByRef PeakCurveItem As AldysGraph.CurveItem, ByVal dblXAxis As Double, _
                                         ByVal dblYAxis As Double) As Boolean
        '=====================================================================
        ' Procedure Name        :   funcDisplayGraph_RealTime
        ' Description           :   Plot the graph on the screen.
        ' Purpose               :   To plot the graph on the screen for the given
        '                           Wavelength and absorbtion.           
        ' Parameters Passed     :   AASD2EnergyGraph As AASGraph,dblXAxis,dblYAxis as double
        ' Returns               :   True, if successful.
        ' Parameters Affected   :   
        ' Assumptions           :   Graph pre-requisites are already been set.
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale 
        ' Created               :   10.12.06
        ' Revisions             :
        '=====================================================================
        Dim dblX_Axis As Double
        Dim dblToY As Double
        Dim tval As Long
        Dim dblDiffX As Double
        Dim dblMajorStepX, dblMinorStepX As Double
        Dim dblDiffY As Double
        Dim dblMajorStepY, dblMinorStepY As Double
        Try

            Application.DoEvents()
            '--- Plot the graph for the given coordinates.
            dblX_Axis = dblXAxis
            dblToY = dblYAxis

            '--- Check if the X-coordinates and Y-coordinates are less than
            '--- Xmin and Ymin

            dblYAxis = dblToY

            Lbl3.TextAlign = ContentAlignment.MiddleRight
            Lbl3.Text = "Wavelength " & Format(dblX_Axis, "#000.0") & " Energy " & Format(dblYAxis, "#0.0") & "%"

            '            if (xtime1>=AbsGraph.Xmax){
            '			tval =(AbsGraph.Xmax-AbsGraph.Xmin);
            '			AbsGraph.Xmin = AbsGraph.Xmax;//(double)5.0;
            '			AbsGraph.Xmax +=tval;// (double)5.0;
            '			Calculate_Abs_Scan_Param(&AbsGraph);
            '			Afirst=TRUE;
            '			InvalidateRect(hwnd, NULL, TRUE); //AbsGraph.RC, TRUE);
            '			UpdateWindow(hwnd);
            '			CEnd1 = clock();
            '//			CStart += (CEnd1-CEnd);
            '		  }
            '		 if (Afirst){
            '			PlotInit(hdc, xtime1, abs, AbsGraph.RC, &AbsGraph);
            '			Afirst=FALSE;
            '		  }
            '                Else
            '			Plotg(hdc, xtime1, abs, AbsGraph.RC, &AbsGraph);
            '		}

            '--- Check if the wavelength is equal to the max wv
            AASD2EnergyGraph.PlotPoint(PeakCurveItem, dblXAxis, dblYAxis)
            AASD2EnergyGraph.AldysPane.AxisChange()
            AASD2EnergyGraph.Refresh()

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

    Friend Function funcDisplayGraph(ByVal AASD2EnergyGraph As AAS203.AASGraph, ByVal dtPlotValue As DataTable) As Boolean
        '=====================================================================
        ' Procedure Name        : funcDisplayGraph
        ' Parameters Passed     : AASD2EnergyGraph,dtPlotValue
        ' Returns               : Boolean
        ' Purpose               : 
        ' Description           :  to plot the graph
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 17-May-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        Dim lngDataCount As Long
        Dim objReadingCol As New Spectrum.Readings
        Dim dblFromX As Double
        Dim dblFromY As Double
        Dim dblToX As Double
        Dim dblToY As Double

        Try
            '--- This is done when the Print overlay functionality is operated
            '--- because graph should come as overlay

            AASD2EnergyGraph.GraphDataSource = dtPlotValue
            Call AASD2EnergyGraph.PlotGraph()
            funcGraphPreRequisite(AASD2EnergyGraph)
            AASD2EnergyGraph.Refresh()
            Application.DoEvents()

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

    Friend Function funcClearGraph(ByVal AASD2EnergyGraph As AAS203.AASGraph) As Boolean
        '=====================================================================
        ' Procedure Name        : funcClearGraph
        ' Parameters Passed     : AASD2EnergyGraph
        ' Returns               : Boolean
        ' Purpose               : 
        ' Description           :  to clear the graph
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 17-May-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        Dim lngDataCount As Long
        Dim dblFromX As Double
        Dim dblFromY As Double
        Dim dblToX As Double
        Dim dblToY As Double

        '---to clear the graph
        Try
            AASD2EnergyGraph.AldysPane.CurveList.Clear()
            AASD2EnergyGraph.Refresh()
            Application.DoEvents()
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

#End Region

    Private Sub btnPrintGraph_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintGraph.Click
        '=====================================================================
        ' Procedure Name        : tlbbtnPrintGraph_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           :  to print the graph
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 17-May-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================


        'to print the graph
        Dim objWait As New CWaitCursor
        Dim mobjClsDataFileReport As clsDataFileReport

        Try
            '-----Added By Pankaj Fri 18 May 07
            If (gstructSettings.Enable21CFR = True) Then
                If Not funcCheckActivityAuthentication(enumActivityAuthentication.Print, gstructUserDetails.Access) Then
                    Return
                    Exit Sub
                End If
                gfuncInsertActivityLog(EnumModules.Print, "Print DataFiles Graph Accessed")
            End If
            '------

            '--- Print the graph to print Preview
            mobjClsDataFileReport = New clsDataFileReport
            mobjClsDataFileReport.DefaultFont = Me.DefaultFont
            mobjClsDataFileReport.funcPrintD2Peak(AASD2EnergyPeak486, AASD2EnergyPeak656)
            'AASD2EnergyPeak486.PrintPreViewGraph()
            'AASD2EnergyPeak656.PrintPreViewGraph()

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
            mobjClsDataFileReport = Nothing
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

End Class
