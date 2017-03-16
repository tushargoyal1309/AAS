Imports System.Threading
Imports AAS203.Common
Imports AAS203Library.Method

Public Class frmServiceRoutines
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents mnuOptimise As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuPneumatics As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuEmsPeakSearch As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuAnaPeakSearch As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuInstrumentSetup As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuEmissionSetup As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuAbsScan As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuManualIgnition As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuAutoIgnition As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents StatusBar1 As NETXP.Controls.Bars.StatusBar
    Friend WithEvents StatusBarPanelInfo As System.Windows.Forms.StatusBarPanel
    Friend WithEvents ProgressPanel As NETXP.Controls.Bars.ProgressPanel
    Friend WithEvents StatusBarPanelDate As System.Windows.Forms.StatusBarPanel
    Friend WithEvents mnuOptimizeTurretAll As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuOptimizeTurret1 As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuBarServiceRoutines As NETXP.Controls.Bars.CommandBar
    Friend WithEvents mnuTurret1 As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuAnalog1 As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuMonochromator1 As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuPrinterType1 As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuExit1 As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuTurret As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuAnalog As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuMonochromator As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuPrinterType As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuExit As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents btnExtinguish As NETXP.Controls.XPButton
    Friend WithEvents btnIgnite As NETXP.Controls.XPButton
    Friend WithEvents CustomPanel2 As GradientPanel.CustomPanel
    Friend WithEvents btnN2OIgnite As NETXP.Controls.XPButton
    Friend WithEvents btnDelete As NETXP.Controls.XPButton
    Friend WithEvents btnR As NETXP.Controls.XPButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmServiceRoutines))
        Me.mnuBarServiceRoutines = New NETXP.Controls.Bars.CommandBar
        Me.mnuTurret1 = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuTurret = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuAnalog1 = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuAnalog = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuMonochromator1 = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuMonochromator = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuOptimise = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuOptimizeTurretAll = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuOptimizeTurret1 = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuEmsPeakSearch = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuAnaPeakSearch = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuInstrumentSetup = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuEmissionSetup = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuAbsScan = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuPneumatics = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuManualIgnition = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuAutoIgnition = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuPrinterType1 = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuPrinterType = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuExit1 = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuExit = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CustomPanel1 = New GradientPanel.CustomPanel
        Me.CustomPanel2 = New GradientPanel.CustomPanel
        Me.btnExtinguish = New NETXP.Controls.XPButton
        Me.btnIgnite = New NETXP.Controls.XPButton
        Me.btnN2OIgnite = New NETXP.Controls.XPButton
        Me.btnR = New NETXP.Controls.XPButton
        Me.btnDelete = New NETXP.Controls.XPButton
        Me.StatusBar1 = New NETXP.Controls.Bars.StatusBar
        Me.StatusBarPanelInfo = New System.Windows.Forms.StatusBarPanel
        Me.ProgressPanel = New NETXP.Controls.Bars.ProgressPanel
        Me.StatusBarPanelDate = New System.Windows.Forms.StatusBarPanel
        CType(Me.mnuBarServiceRoutines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CustomPanel1.SuspendLayout()
        CType(Me.StatusBarPanelInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProgressPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanelDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mnuBarServiceRoutines
        '
        Me.mnuBarServiceRoutines.BackColor = System.Drawing.Color.Transparent
        Me.mnuBarServiceRoutines.CustomBackground = True
        Me.mnuBarServiceRoutines.CustomizeText = "&Customize Toolbar..."
        Me.mnuBarServiceRoutines.Dock = System.Windows.Forms.DockStyle.Top
        Me.mnuBarServiceRoutines.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuBarServiceRoutines.FullRow = True
        Me.mnuBarServiceRoutines.ID = 3987
        Me.mnuBarServiceRoutines.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuTurret1, Me.mnuAnalog1, Me.mnuMonochromator1, Me.mnuOptimise, Me.mnuPneumatics, Me.mnuPrinterType1, Me.mnuExit1})
        Me.mnuBarServiceRoutines.Location = New System.Drawing.Point(0, 0)
        Me.mnuBarServiceRoutines.Margins.Bottom = 1
        Me.mnuBarServiceRoutines.Margins.Left = 1
        Me.mnuBarServiceRoutines.Margins.Right = 1
        Me.mnuBarServiceRoutines.Margins.Top = 1
        Me.mnuBarServiceRoutines.Name = "mnuBarServiceRoutines"
        Me.mnuBarServiceRoutines.Size = New System.Drawing.Size(658, 23)
        Me.mnuBarServiceRoutines.Style = NETXP.Controls.Bars.CommandBarStyle.Menu
        Me.mnuBarServiceRoutines.TabIndex = 1
        Me.mnuBarServiceRoutines.TabStop = False
        Me.mnuBarServiceRoutines.Text = ""
        '
        'mnuTurret1
        '
        Me.mnuTurret1.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuTurret})
        Me.mnuTurret1.PadHorizontal = 5
        Me.mnuTurret1.Text = "&Turret"
        '
        'mnuTurret
        '
        Me.mnuTurret.Image = CType(resources.GetObject("mnuTurret.Image"), System.Drawing.Image)
        Me.mnuTurret.Text = "&Turret"
        '
        'mnuAnalog1
        '
        Me.mnuAnalog1.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuAnalog})
        Me.mnuAnalog1.PadHorizontal = 5
        Me.mnuAnalog1.Text = "&Analog"
        '
        'mnuAnalog
        '
        Me.mnuAnalog.Image = CType(resources.GetObject("mnuAnalog.Image"), System.Drawing.Image)
        Me.mnuAnalog.Text = "&Analog"
        '
        'mnuMonochromator1
        '
        Me.mnuMonochromator1.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuMonochromator})
        Me.mnuMonochromator1.PadHorizontal = 5
        Me.mnuMonochromator1.Text = "&Monochromator"
        '
        'mnuMonochromator
        '
        Me.mnuMonochromator.Image = CType(resources.GetObject("mnuMonochromator.Image"), System.Drawing.Image)
        Me.mnuMonochromator.Text = "&Monochromator"
        '
        'mnuOptimise
        '
        Me.mnuOptimise.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuOptimizeTurretAll, Me.mnuOptimizeTurret1, Me.mnuInstrumentSetup, Me.mnuAnaPeakSearch, Me.mnuAbsScan, Me.mnuEmissionSetup, Me.mnuEmsPeakSearch})
        Me.mnuOptimise.PadHorizontal = 5
        Me.mnuOptimise.Text = "&Optimise"
        '
        'mnuOptimizeTurretAll
        '
        Me.mnuOptimizeTurretAll.Image = CType(resources.GetObject("mnuOptimizeTurretAll.Image"), System.Drawing.Image)
        Me.mnuOptimizeTurretAll.Text = "Turret &All"
        Me.mnuOptimizeTurretAll.Visible = False
        '
        'mnuOptimizeTurret1
        '
        Me.mnuOptimizeTurret1.Image = CType(resources.GetObject("mnuOptimizeTurret1.Image"), System.Drawing.Image)
        Me.mnuOptimizeTurret1.Text = "&Turret 1"
        Me.mnuOptimizeTurret1.Visible = False
        '
        'mnuEmsPeakSearch
        '
        Me.mnuEmsPeakSearch.Image = CType(resources.GetObject("mnuEmsPeakSearch.Image"), System.Drawing.Image)
        Me.mnuEmsPeakSearch.Text = "&Emission Peak Search"
        '
        'mnuAnaPeakSearch
        '
        Me.mnuAnaPeakSearch.Image = CType(resources.GetObject("mnuAnaPeakSearch.Image"), System.Drawing.Image)
        Me.mnuAnaPeakSearch.Text = "A&nalytical Peak Search"
        '
        'mnuInstrumentSetup
        '
        Me.mnuInstrumentSetup.Image = CType(resources.GetObject("mnuInstrumentSetup.Image"), System.Drawing.Image)
        Me.mnuInstrumentSetup.Text = "&Instrument Condition"
        '
        'mnuEmissionSetup
        '
        Me.mnuEmissionSetup.Image = CType(resources.GetObject("mnuEmissionSetup.Image"), System.Drawing.Image)
        Me.mnuEmissionSetup.Text = "E&mission Setup"
        '
        'mnuAbsScan
        '
        Me.mnuAbsScan.Image = CType(resources.GetObject("mnuAbsScan.Image"), System.Drawing.Image)
        Me.mnuAbsScan.Text = "Absorbance &Scan"
        '
        'mnuPneumatics
        '
        Me.mnuPneumatics.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuManualIgnition, Me.mnuAutoIgnition})
        Me.mnuPneumatics.PadHorizontal = 5
        Me.mnuPneumatics.Text = "&Pneumatics"
        '
        'mnuManualIgnition
        '
        Me.mnuManualIgnition.Image = CType(resources.GetObject("mnuManualIgnition.Image"), System.Drawing.Image)
        Me.mnuManualIgnition.Text = "&Manual Ignition"
        '
        'mnuAutoIgnition
        '
        Me.mnuAutoIgnition.Image = CType(resources.GetObject("mnuAutoIgnition.Image"), System.Drawing.Image)
        Me.mnuAutoIgnition.Text = "&Auto Ignition"
        '
        'mnuPrinterType1
        '
        Me.mnuPrinterType1.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuPrinterType})
        Me.mnuPrinterType1.PadHorizontal = 5
        Me.mnuPrinterType1.Text = "P&rinter Type"
        '
        'mnuPrinterType
        '
        Me.mnuPrinterType.Image = CType(resources.GetObject("mnuPrinterType.Image"), System.Drawing.Image)
        Me.mnuPrinterType.Text = "P&rinter Type"
        '
        'mnuExit1
        '
        Me.mnuExit1.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuExit})
        Me.mnuExit1.PadHorizontal = 5
        Me.mnuExit1.Text = "E&xit"
        '
        'mnuExit
        '
        Me.mnuExit.Image = CType(resources.GetObject("mnuExit.Image"), System.Drawing.Image)
        Me.mnuExit.Text = "E&xit"
        '
        'CustomPanel1
        '
        Me.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanel1.Controls.Add(Me.CustomPanel2)
        Me.CustomPanel1.Controls.Add(Me.btnExtinguish)
        Me.CustomPanel1.Controls.Add(Me.btnIgnite)
        Me.CustomPanel1.Controls.Add(Me.btnN2OIgnite)
        Me.CustomPanel1.Controls.Add(Me.btnR)
        Me.CustomPanel1.Controls.Add(Me.btnDelete)
        Me.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanel1.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanel1.Name = "CustomPanel1"
        Me.CustomPanel1.Size = New System.Drawing.Size(658, 375)
        Me.CustomPanel1.TabIndex = 2
        '
        'CustomPanel2
        '
        Me.CustomPanel2.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanel2.Location = New System.Drawing.Point(32, 312)
        Me.CustomPanel2.Name = "CustomPanel2"
        Me.CustomPanel2.Size = New System.Drawing.Size(40, 32)
        Me.CustomPanel2.TabIndex = 16
        '
        'btnExtinguish
        '
        Me.btnExtinguish.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExtinguish.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExtinguish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExtinguish.Location = New System.Drawing.Point(32, 328)
        Me.btnExtinguish.Name = "btnExtinguish"
        Me.btnExtinguish.Size = New System.Drawing.Size(16, 8)
        Me.btnExtinguish.TabIndex = 15
        Me.btnExtinguish.TabStop = False
        Me.btnExtinguish.Text = "&Extinguish"
        Me.btnExtinguish.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnIgnite
        '
        Me.btnIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIgnite.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIgnite.Location = New System.Drawing.Point(56, 320)
        Me.btnIgnite.Name = "btnIgnite"
        Me.btnIgnite.Size = New System.Drawing.Size(16, 16)
        Me.btnIgnite.TabIndex = 14
        Me.btnIgnite.TabStop = False
        Me.btnIgnite.Text = "&Ignition"
        Me.btnIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnN2OIgnite
        '
        Me.btnN2OIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnN2OIgnite.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnN2OIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnN2OIgnite.Location = New System.Drawing.Point(48, 320)
        Me.btnN2OIgnite.Name = "btnN2OIgnite"
        Me.btnN2OIgnite.Size = New System.Drawing.Size(5, 5)
        Me.btnN2OIgnite.TabIndex = 19
        Me.btnN2OIgnite.TabStop = False
        Me.btnN2OIgnite.Text = "N2O&C"
        Me.btnN2OIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnR
        '
        Me.btnR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnR.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnR.Location = New System.Drawing.Point(48, 328)
        Me.btnR.Name = "btnR"
        Me.btnR.Size = New System.Drawing.Size(8, 8)
        Me.btnR.TabIndex = 24
        Me.btnR.TabStop = False
        Me.btnR.Text = "&R"
        Me.btnR.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnDelete
        '
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(40, 320)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(8, 8)
        Me.btnDelete.TabIndex = 25
        Me.btnDelete.TabStop = False
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 351)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanelInfo, Me.ProgressPanel, Me.StatusBarPanelDate})
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(658, 24)
        Me.StatusBar1.TabIndex = 13
        Me.StatusBar1.Text = "StatusBar1"
        '
        'StatusBarPanelInfo
        '
        Me.StatusBarPanelInfo.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanelInfo.MinWidth = 40
        Me.StatusBarPanelInfo.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw
        Me.StatusBarPanelInfo.Width = 413
        '
        'ProgressPanel
        '
        Me.ProgressPanel.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.ProgressPanel.Maximum = 100
        Me.ProgressPanel.Minimum = 0
        Me.ProgressPanel.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw
        Me.ProgressPanel.Value = 0
        Me.ProgressPanel.Width = 150
        '
        'StatusBarPanelDate
        '
        Me.StatusBarPanelDate.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.StatusBarPanelDate.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
        Me.StatusBarPanelDate.MinWidth = 40
        Me.StatusBarPanelDate.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw
        Me.StatusBarPanelDate.Text = "Current Date"
        Me.StatusBarPanelDate.Width = 79
        '
        'frmServiceRoutines
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(658, 375)
        Me.Controls.Add(Me.mnuBarServiceRoutines)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.CustomPanel1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IsMdiContainer = True
        Me.Name = "frmServiceRoutines"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "AAS 203 Service Routines"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.mnuBarServiceRoutines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CustomPanel1.ResumeLayout(False)
        CType(Me.StatusBarPanelInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProgressPanel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanelDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Private Class Member Variables "

    Private mintMethodMode As Integer = 0
    Private mblnInProcess As Boolean = False
    Private mblnAvoidProcessing As Boolean = False

#End Region

#Region " Private Constants "

    Private Const ConstAA203FormLoad = "AA 203-Service Routines"
    Private Const ConstAA203DFormLoad = "AA 203D-Service Routines"
    Private Const ConstAA201FormLoad = "AA 201-Service Routines"

    '---4.85  14.04.09
    Private Const ConstAA303FormLoad = "AA 303-Service Routines"
    Private Const ConstAA303DFormLoad = "AA 303D-Service Routines"
    Private Const ConstAA301FormLoad = "AA 301-Service Routines"
    '---4.85  14.04.09

#End Region

#Region " Form Events "

    Private Sub frmServiceRoutines_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmServiceRoutines_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To initialize the form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S.
        ' Created               : 07.09.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor

        Try
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                btnIgnite.Enabled = False
                btnExtinguish.Enabled = False
                mnuOptimizeTurretAll.Enabled = False                'Saurabh 22.06.07
                mnuOptimizeTurret1.Enabled = False                  'Saurabh 22.06.07
            End If

            mnuBarServiceRoutines.BackColor = System.Drawing.Color.Gainsboro
            gobjclsTimer = New clsTimer(StatusBar1, 1000)

            Call AddHandlers()

            '---added on 29.01.08
            If gobjCommProtocol.mobjCommdll.gFuncIsPortOpen() Then
                gobjCommProtocol.funcGet_Current_Wv(gobjInst.WavelengthCur)
            End If
            '---added on 29.01.08

            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                'Call ShowProgressBar(ConstAA201FormLoad)
                'Me.Text = ConstAA201FormLoad

                '---4.85  14.04.09
                If gstructSettings.NewModelName = False Then
                    Call ShowProgressBar(ConstAA201FormLoad)
                    Me.Text = ConstAA201FormLoad
                Else
                    Call ShowProgressBar(ConstAA301FormLoad)
                    Me.Text = ConstAA301FormLoad
                End If
                '---4.85  14.04.09


                mnuTurret1.Text = "Lamp" 'Added By Pankaj on 31 May 07
                mnuTurret.Text = "Lamp"
                mnuAutoIgnition.Visible = False

            ElseIf gstructSettings.AppMode = EnumAppMode.FullVersion_203 Then
                'Call ShowProgressBar(ConstAA203FormLoad)
                'Me.Text = ConstAA203FormLoad

                '---4.85  14.04.09
                If gstructSettings.NewModelName = False Then
                    Call ShowProgressBar(ConstAA201FormLoad)
                    Me.Text = ConstAA201FormLoad
                Else
                    Call ShowProgressBar(ConstAA301FormLoad)
                    Me.Text = ConstAA301FormLoad
                End If
                '---4.85  14.04.09

            ElseIf gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                'Call ShowProgressBar(ConstAA203DFormLoad)
                'Me.Text = ConstAA203DFormLoad

                '---4.85  14.04.09
                If gstructSettings.NewModelName = False Then
                    Call ShowProgressBar(ConstAA203DFormLoad)
                    Me.Text = ConstAA203DFormLoad
                Else
                    Call ShowProgressBar(ConstAA303DFormLoad)
                    Me.Text = ConstAA303DFormLoad
                End If
                '---4.85  14.04.09

            Else
                Call ShowProgressBar("Demo Mode - Service Routines")
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
            Call HideProgressBar()
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

#End Region

#Region " Private Functions "

    Private Sub AddHandlers()
        '=====================================================================
        ' Procedure Name        : AddHandlers
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To add event handlers
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S.
        ' Created               : 20.11.06
        ' Revisions             : 
        '=====================================================================
        Try
            AddHandler mnuExit.Click, AddressOf mnuExit_Click
            AddHandler mnuAnalog.Click, AddressOf mnuAnalog_Click
            AddHandler mnuPrinterType.Click, AddressOf mnuPrinterType_Click
            AddHandler mnuMonochromator.Click, AddressOf mnuMonochromator_Click
            AddHandler mnuAnaPeakSearch.Click, AddressOf mnuAnaPeakSearch_Click
            AddHandler mnuEmsPeakSearch.Click, AddressOf mnuEmsPeakSearch_Click
            AddHandler mnuEmissionSetup.Click, AddressOf mnuEmissionSetup_Click
            AddHandler mnuAbsScan.Click, AddressOf mnuAbsScan_Click
            AddHandler mnuManualIgnition.Click, AddressOf mnuManualIgnition_Click
            AddHandler mnuAutoIgnition.Click, AddressOf mnuAutoIgnition_Click
            AddHandler mnuInstrumentSetup.Click, AddressOf mnuInstrumentSetup_Click

            AddHandler mnuTurret.Click, AddressOf mnuTurret_Click
            AddHandler mnuOptimizeTurretAll.Click, AddressOf mnuOptimizeTurretAll_Click
            AddHandler mnuOptimizeTurret1.Click, AddressOf mnuOptimizeTurret1_Click
            'AddHandler btnDelete.Click, AddressOf btnDelete_Click
            'AddHandler btnR.Click, AddressOf btnR_Click
            'AddHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click
            'AddHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click

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
        ' Purpose               : To exit from Service Routine window. 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 20.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            Me.DialogResult = DialogResult.Cancel
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try

    End Sub

    Private Sub mnuTurret_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuTurret_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the Turret form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objfrmTurret As New frmTurret
        Dim objWait As New CWaitCursor
        Try
            objfrmTurret.ShowDialog()
            objfrmTurret.Close()
            objfrmTurret.Dispose()
            objfrmTurret = Nothing
            Me.Visible = True
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
    End Sub

    Private Sub mnuAnalog_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuAnalog_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the Method form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objfrmAnalog As Object    'New frmAnalog
        Dim objWait As New CWaitCursor
        Try
            If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                objfrmAnalog = New frmAnalogDB
            Else
                objfrmAnalog = New frmAnalog
            End If

            objfrmAnalog.ShowDialog()
            objfrmAnalog.Close()
            objfrmAnalog.Dispose()
            objfrmAnalog = Nothing
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
    End Sub

    Private Sub mnuMonochromator_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuMonochromator_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the Monochromator form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objfrmMonochromator As Object   'New frmMonochromator
        Dim objWait As New CWaitCursor
        Try
            If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                objfrmMonochromator = New frmMonochromatorDB
            Else
                objfrmMonochromator = New frmMonochromator
            End If
            objfrmMonochromator.ShowDialog()
            objfrmMonochromator.Close()
            objfrmMonochromator.Dispose()
            objfrmMonochromator = Nothing
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
    End Sub

    Private Sub mnuPrinterType_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuPrinterType_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the Printer type form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 04.04.07
        ' Revisions             : 
        '=====================================================================
        Dim objfrmPrinterType As New frmPrinterType
        Dim objWait As New CWaitCursor
        Try
            'objfrmPrinterType.ShowDialog()
            'objfrmPrinterType.Close()
            'objfrmPrinterType.Dispose()
            'objfrmPrinterType = Nothing
            'Application.DoEvents()
            If gstructSettings.blnSelectColorPrinter = True Then
                objfrmPrinterType.rbColor.Checked = True
                objfrmPrinterType.rbNormal.Checked = False
            Else
                objfrmPrinterType.rbColor.Checked = False
                objfrmPrinterType.rbNormal.Checked = True
            End If

            If objfrmPrinterType.ShowDialog() = DialogResult.OK Then
                If objfrmPrinterType.rbColor.Checked = True Then
                    gstructSettings.blnSelectColorPrinter = True
                ElseIf objfrmPrinterType.rbNormal.Checked = True Then
                    gstructSettings.blnSelectColorPrinter = False
                End If
            End If
            gobjPageSetting.Color = gstructSettings.blnSelectColorPrinter
            objfrmPrinterType.Close()
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
            If Not objfrmPrinterType Is Nothing Then
                objfrmPrinterType.Dispose()
            End If
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub mnuManualIgnition_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuManualIgnition_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the ManualIgnition form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 27.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim objfrmManualIgnition As New frmManualIgnition
        Try
            ' code added by : dinesh wagh on 22.3.2009
            ' code start
            If gstructSettings.AppMode = EnumAppMode.DemoMode_201 Or _
                gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                objfrmManualIgnition.Width = objfrmManualIgnition.Width - 175
                objfrmManualIgnition.StartPosition = FormStartPosition.CenterScreen
            End If
            '........code ends.

            objfrmManualIgnition.ShowDialog()
            objfrmManualIgnition.Close()
            objfrmManualIgnition.Dispose()
            objfrmManualIgnition = Nothing
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
    End Sub

    Private Sub mnuAutoIgnition_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuAutoIgnition_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the AutoIgnition form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 04.02.07
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim objfrmAutoIgnition As New frmAutoIgnition
        Try
            objfrmAutoIgnition.ShowDialog()
            ''for showing a dialog.
            objfrmAutoIgnition.Close()
            objfrmAutoIgnition.Dispose()
            objfrmAutoIgnition = Nothing
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
                ''destructure.
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub mnuInstrumentSetup_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuInstrumentSetup_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the Instrument Parameters form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 30.11.06
        ' Revisions             : Deepak B. on 15.01.07
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim objfrmInstrumentParameters As frmInstrumentParameters

        Try
            objfrmInstrumentParameters = New frmInstrumentParameters
            objfrmInstrumentParameters.ShowDialog()
            objfrmInstrumentParameters.Close()
            objfrmInstrumentParameters.Dispose()
            objfrmInstrumentParameters = Nothing
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
            objWait.Dispose()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub mnuEmissionSetup_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuEmissionSetup_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the Emission Setup form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 30.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim objfrmEmissionMode As frmEmissionMode

        Try
            objfrmEmissionMode = New frmEmissionMode(EnumMethodMode.NewMode)
            objfrmEmissionMode.ShowDialog()
            objfrmEmissionMode.Close()
            objfrmEmissionMode.Dispose()
            objfrmEmissionMode = Nothing
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
            objWait.Dispose()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub mnuEmsPeakSearch_Click(ByVal sender As Object, ByVal e As EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuEmsPeakSearch_Click
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To find the Emmision Peak
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 24-Jan-2007 12:35 pm
        ' Revisions             : 1
        '=====================================================================
        Dim objWaitCursor As New CWaitCursor

        Try
            Call gobjClsAAS203.Find_Emmission_Peak()

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

    Private Sub mnuAnaPeakSearch_Click(ByVal sender As Object, ByVal e As EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuAnaPeakSearch_Click
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 24-Jan-2007 12:35 pm
        ' Revisions             : 1
        '=====================================================================
        Dim objWaitCursor As New CWaitCursor
        Dim dblWvOpt As Double

        Try
            'Saurabh--25.06.07
            If Not IsNothing(gobjMain) Then
                gobjMain.mobjController.Cancel()
                gobjCommProtocol.mobjCommdll.subTime_Delay(500)   '10.12.07
                Application.DoEvents()
            End If
            'Saurabh--25.06.07
            Call gobjClsAAS203.Find_Analytical_Peak(gobjInst.Lamp_Position, dblWvOpt)

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
            'Saurabh--25.06.07
            If Not IsNothing(gobjMain) Then
                gobjMain.mobjController.Start(gobjclsBgFlameStatus)
                Application.DoEvents()
            End If
            'Saurabh--25.06.07
            objWaitCursor.Dispose()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub mnuOptimizeTurretAll_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuOptimizeTurretAll_Click
        ' Parameters Passed     : 
        ' Returns               : None
        ' Purpose               : To call Turret optimisation procedure 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak B.
        ' Created               : 16.12.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            Dim mobjfrmZeroOrder As frmZeroOrder
            mobjfrmZeroOrder = New frmZeroOrder
            mobjfrmZeroOrder.StartPosition = FormStartPosition.Manual
            mobjfrmZeroOrder.Location = New Point(ZeroOrderThreadWindowLocationX, ZeroOrderThreadWindowLocationY)
            mobjfrmZeroOrder.StartOptimizeTread()
            mobjfrmZeroOrder.ShowDialog()
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
    End Sub

    Private Sub mnuOptimizeTurret1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuOptimizeTurret1_Click
        ' Parameters Passed     : 
        ' Returns               : None
        ' Purpose               : To call Turret optimisation procedure 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak B.
        ' Created               : 15.01.07
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim intCounter As Integer
        Dim dblCurrent As Double
        Dim intTurretNumber As Integer

        Try
            If gstructSettings.ExeToRun = EnumApplicationMode.AAS Then
                If Not IsNothing(gobjNewMethod) Then
                    dblCurrent = gobjNewMethod.InstrumentCondition.LampCurrent
                    intTurretNumber = gobjNewMethod.InstrumentCondition.TurretNumber
                Else
                    intTurretNumber = 1
                End If
            Else
                If gintTurretToOptimizeForServiceUtility > 0 Then
                    intTurretNumber = gintTurretToOptimizeForServiceUtility
                    dblCurrent = gobjInst.Lamp.LampParametersCollection.item(gintTurretToOptimizeForServiceUtility - 1).Current
                End If
            End If

            Call gfuncLamp_connected(intTurretNumber)

            Dim mobjfrmturretOptimisation As frmTurretOptimisation
            mobjfrmturretOptimisation = New frmTurretOptimisation(dblCurrent, intTurretNumber)
            mobjfrmturretOptimisation.StartOptimizeTread()
            mobjfrmturretOptimisation.StartPosition = FormStartPosition.CenterScreen
            mobjfrmturretOptimisation.ShowDialog()

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
    End Sub

    Private Sub mnuAbsScan_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuAbsScan_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the Abs Scan form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 30.11.06
        ' Revisions             : Sachin Dokhale on 18.03.07
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim objfrmTimeScanMode As Object    'frmTimeScanMode
        Dim intCalibrationMode As Integer
        Try
            intCalibrationMode = gobjInst.Mode
            If gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.AA) Then
                gintSpectrumMode = modGlobalDeclarations.EnumSpectrumMode.TimeScan
                If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                    'If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam Or _
                    '        gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.ReferenceBeam Then
                    '    'objfrmTimeScanMode = New frmTimeScanMode
                    '    objfrmTimeScanMode = New frmTimeScanDBMode
                    'Else
                    '    objfrmTimeScanMode = New frmTimeScanDBMode
                    'End If

                    'by Pankaj on 18.1.08 for beam type
                    If gintServiceBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
                        objfrmTimeScanMode = New frmTimeScanDBMode
                    Else
                        objfrmTimeScanMode = New frmTimeScanMode
                    End If

                Else
                        objfrmTimeScanMode = New frmTimeScanMode
                    End If

                    objfrmTimeScanMode.ShowDialog()
                    objfrmTimeScanMode.Close()
                End If
                Application.DoEvents()
                gobjCommProtocol.funcCalibrationMode(intCalibrationMode)



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
            If Not objfrmTimeScanMode Is Nothing Then
                objfrmTimeScanMode.Dispose()
                objfrmTimeScanMode = Nothing
            End If
            objWait.Dispose()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    'Private Sub btnAutoIgnition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : btnAutoIgnition_Click
    '    ' Parameters Passed     : Object, EventArgs
    '    ' Returns               : None
    '    ' Purpose               : 
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Mangesh Shardul
    '    ' Created               : 18-Feb-2007 03:15 pm
    '    ' Revisions             : 1
    '    '=====================================================================
    '    Try
    '        RemoveHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click

    '        'If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
    '        ' mobjController.Cancel()
    '        Application.DoEvents()

    '        Call gobjClsAAS203.funcIgnite(True)

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
    '        'If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = True
    '        'mobjController.Start(gobjclsBgFlameStatus)
    '        Application.DoEvents()
    '        AddHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
    '        '---------------------------------------------------------
    '    End Try
    'End Sub

    'Private Sub btnExtinguish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : btnExtinguish_Click
    '    ' Parameters Passed     : Object, EventArgs
    '    ' Returns               : None
    '    ' Purpose               : 
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Mangesh Shardul
    '    ' Created               : 18-Feb-2007 03:15 pm
    '    ' Revisions             : 1
    '    '=====================================================================
    '    Try
    '        RemoveHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click
    '        'If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
    '        'mobjController.Cancel()
    '        Application.DoEvents()

    '        Call gobjClsAAS203.funcIgnite(False)

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
    '        'If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = True
    '        'mobjController.Start(gobjclsBgFlameStatus)
    '        Application.DoEvents()
    '        AddHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click
    '        '---------------------------------------------------------
    '    End Try
    'End Sub

#End Region

#Region " ProgressBar Functions "

    Public Sub ShowProgressBar(ByVal message As String)
        '=====================================================================
        ' Procedure Name        : ShowProgressBar
        ' Parameters Passed     : message
        ' Returns               : None
        ' Purpose               : to show the progress bar
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : Saturday, January 22, 2005
        ' Revisions             : 
        '=====================================================================
        Try
            ProgressPanel.Value = 20
            StatusBarPanelInfo.Text = message
            'start a new thread to increment the progressbar
            Dim progressThread As New Thread(AddressOf BackGroundIncrementProgressBar)
            progressThread.IsBackground = True
            progressThread.Name = "Progress Bar"
            progressThread.Start()

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

    Private Sub BackGroundIncrementProgressBar()
        '=====================================================================
        ' Procedure Name        : BackGroundIncrementProgressBar
        ' Parameters Passed     : None
        ' Returns               : None 
        ' Purpose               : to increment the progress of progress bar
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : Saturday, January 22, 2005
        ' Revisions             : 
        '=====================================================================
        Try
            'note: this will run on a worker thread
            While ProgressPanel.Value <> 100
                If ProgressPanel.Value < 80 Then ProgressPanel.Value += 8
                Thread.Sleep(30)
            End While

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

    Public Sub HideProgressBar()
        '=====================================================================
        ' Procedure Name        : HideProgressBar
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : to finish the progress bar
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : Sunday, January 23, 2005
        ' Revisions             : 
        '=====================================================================
        Try
            'this sleep code is only eye candy but note that we must set m_ProgressBar.Value = 100
            'so that BackGroundIncrementProgressBar() can die
            Dim i As Integer
            For i = 0 To 16
                Thread.Sleep(30)
                Application.DoEvents()

                'show 100% for a glance
                If i = 15 Then ProgressPanel.Value = 100
            Next
            ProgressPanel.Value = 0
            'ProgressPanel.Text = Application.ProductName & Space(1) & Application.ProductVersion
            ProgressPanel.Text = gstrTitleInstrumentType & Space(1) & "S/W Ver. : " & Mid(Application.ProductVersion, 1, 4)

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

    Public Sub ShowRunTimeInfo(ByVal message As String)
        '=====================================================================
        ' Procedure Name        : ShowProgressBar
        ' Parameters Passed     : message
        ' Returns               : None
        ' Purpose               : to show the progress bar
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : Saturday, January 22, 2005
        ' Revisions             : 
        '=====================================================================
        Try
            'ProgressPanel.Value = 20
            StatusBarPanelInfo.Text = message
            'start a new thread to increment the progressbar
            'Dim progressThread As New Thread(AddressOf BackGroundIncrementProgressBar)
            'progressThread.IsBackground = True
            'progressThread.Name = "Progress Bar"
            'progressThread.Start()

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

    'Private Sub mnuTurret_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTurret.Enter
    '    '=====================================================================
    '    ' Procedure Name        : mnuTurret_Click
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : To load the Turret form
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Saurabh S
    '    ' Created               : 21.11.06
    '    ' Revisions             : 
    '    '=====================================================================
    '    Dim objfrmTurret As New frmTurret
    '    Dim objWait As New CWaitCursor
    '    Try
    '        objfrmTurret.ShowDialog()
    '        Application.DoEvents()
    '        Me.Visible = True
    '        objfrmTurret.Dispose()

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
    '        If Not objWait Is Nothing Then
    '            objWait.Dispose()
    '        End If
    '        '---------------------------------------------------------
    '    End Try
    'End Sub

    Private Sub btnIgnite_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIgnite.Click
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        Try
            mblnAvoidProcessing = True
            gobjClsAAS203.funcIgnite(True)
            mblnAvoidProcessing = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnAvoidProcessing = False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try

    End Sub

    Private Sub btnExtinguish_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExtinguish.Click
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        Try
            mblnAvoidProcessing = True
            gobjClsAAS203.funcIgnite(False)
            mblnAvoidProcessing = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnAvoidProcessing = False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try

    End Sub

    Private Sub btnN2OIgnite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnN2OIgnite.Click

        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        Try
            mblnAvoidProcessing = True
            Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
            Call gobjCommProtocol.funcSwitchOver()

            mblnAvoidProcessing = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnAvoidProcessing = False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnDelete_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 18-Dec-2007 03:15 pm
        ' Revisions             : 0
        '=====================================================================
        Try
            If mblnInProcess = True Then
                Exit Sub
            End If
            mblnInProcess = True
            Application.DoEvents()
            Call gobjMainService.funcAltDelete()
            mblnInProcess = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnInProcess = False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnR_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 18-Dec-2007 03:15 pm
        ' Revisions             : 0
        '=====================================================================
        Try
            If mblnInProcess = True Then
                Exit Sub
            End If
            mblnInProcess = True
            Application.DoEvents()
            Call gobjMainService.funcAltR()
            mblnInProcess = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnInProcess = False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub MenuBar_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mnuBarServiceRoutines.KeyUp
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        mblnAvoidProcessing = True
        If e.Alt = True Then
            Select Case e.KeyCode
                Case Keys.I
                    Call AutoIgnition()
                Case Keys.C
                    N2OAutoIgnition()
                Case Keys.E
                    Extinguish()
                Case Keys.D
                    Call gobjMainService.funcAltDelete()
                Case Keys.R
                    Call gobjMainService.funcAltR()
                Case Keys.Q

            End Select
        End If
        mblnAvoidProcessing = False
        Exit Sub
    End Sub

    Public Function AutoIgnition() As Boolean
        '=====================================================================
        ' Procedure Name        : AutoIgnition
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 18-Feb-2007 03:15 pm
        ' Revisions             : 1
        '=====================================================================
        Try
            'RemoveHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click

            'If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
            If Not ((gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                (gstructSettings.AppMode = EnumAppMode.DemoMode_203D)) Then
                Call Application.DoEvents()
                Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
                Call gobjClsAAS203.funcIgnite(True)
            Else
                Call gobjMessageAdapter.ShowMessage(constFlameIgnited)
                Call Application.DoEvents()
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
            Application.DoEvents()
            'AddHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
            '---------------------------------------------------------
        End Try
    End Function

    Public Function Extinguish() As Boolean
        '=====================================================================
        ' Procedure Name        : btnExtinguish_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 18-Feb-2007 03:15 pm
        ' Revisions             : 1
        '=====================================================================
        Try
            'RemoveHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click

            'If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
            If Not ((gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                (gstructSettings.AppMode = EnumAppMode.DemoMode_203D)) Then
                Application.DoEvents()
                Call gobjClsAAS203.funcIgnite(False)
            Else
                Call gobjMessageAdapter.ShowMessage(constFlameExtinguished)
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
            Application.DoEvents()
            'AddHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click
            '---------------------------------------------------------
        End Try
    End Function

    Public Function N2OAutoIgnition() As Boolean
        '=====================================================================
        ' Procedure Name        : N2oAutoIgnition
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 18-Aug-2007 03:15 pm
        ' Revisions             : 1
        '=====================================================================
        Try
            'RemoveHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click

            'If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
            If Not ((gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                (gstructSettings.AppMode = EnumAppMode.DemoMode_203D)) Then
                Call Application.DoEvents()
                Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
                Call gobjCommProtocol.funcSwitchOver()

            Else
                '    Call gobjMessageAdapter.ShowMessage(constFlameIgnited)
                Call Application.DoEvents()
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

            Application.DoEvents()
            'AddHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
            '---------------------------------------------------------
        End Try
    End Function

    Private Sub mnuOptimise_DropDown(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mnuOptimise.DropDown
        If gblnIsInstrumentConditionsActive = True Then
            mnuAnaPeakSearch.Enabled = True
            mnuEmsPeakSearch.Enabled = False
        Else
            mnuAnaPeakSearch.Enabled = False
            mnuEmsPeakSearch.Enabled = True
        End If
    End Sub
End Class
