Imports System.Threading
Imports AAS203.Common
Imports AAS203Library.Method
Public Class frmMDIMainService
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.mnuTest_AAS2031.Text = "Test " & gstrTitleInstrumentType 'by Pankaj on 18.1.08
        Me.mnuTest_AAS203.Text = "Test " & gstrTitleInstrumentType 'by Pankaj on 18.1.08

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
    Friend WithEvents CommandBar1 As NETXP.Controls.Bars.CommandBar
    Friend WithEvents mnuSpectrum As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuAbout As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents StatusBar1 As NETXP.Controls.Bars.StatusBar
    Friend WithEvents StatusBarPanelInfo As System.Windows.Forms.StatusBarPanel
    Friend WithEvents ProgressPanel As NETXP.Controls.Bars.ProgressPanel
    Friend WithEvents StatusBarPanelDate As System.Windows.Forms.StatusBarPanel
    Friend WithEvents mnuUVSpectrum As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuEnergySpectrum As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuIngnition As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuTest_AAS2031 As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuService1 As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuInstSetup1 As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuExit1 As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuTest_AAS203 As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuService As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuInstSetup As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuExit As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuChangePort1 As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuChangePort As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents CustomPanel2 As GradientPanel.CustomPanel
    Friend WithEvents btnN2OIgnite As NETXP.Controls.XPButton
    Friend WithEvents btnIgnite As NETXP.Controls.XPButton
    Friend WithEvents btnExtinguish As NETXP.Controls.XPButton
    Friend WithEvents btnR As NETXP.Controls.XPButton
    Friend WithEvents btnDelete As NETXP.Controls.XPButton
    Friend WithEvents mnuBeamType As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuSingleBeam As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuDoubleBeam As NETXP.Controls.Bars.CommandBarButtonItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMDIMainService))
        Me.CustomPanel1 = New GradientPanel.CustomPanel
        Me.CustomPanel2 = New GradientPanel.CustomPanel
        Me.btnN2OIgnite = New NETXP.Controls.XPButton
        Me.btnR = New NETXP.Controls.XPButton
        Me.btnIgnite = New NETXP.Controls.XPButton
        Me.btnExtinguish = New NETXP.Controls.XPButton
        Me.btnDelete = New NETXP.Controls.XPButton
        Me.CommandBar1 = New NETXP.Controls.Bars.CommandBar
        Me.mnuChangePort1 = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuChangePort = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuTest_AAS2031 = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuTest_AAS203 = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuService1 = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuService = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuInstSetup1 = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuInstSetup = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuSpectrum = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuUVSpectrum = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuEnergySpectrum = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuAbout = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuBeamType = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuSingleBeam = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuDoubleBeam = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuExit1 = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuExit = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.StatusBar1 = New NETXP.Controls.Bars.StatusBar
        Me.StatusBarPanelInfo = New System.Windows.Forms.StatusBarPanel
        Me.ProgressPanel = New NETXP.Controls.Bars.ProgressPanel
        Me.StatusBarPanelDate = New System.Windows.Forms.StatusBarPanel
        Me.mnuIngnition = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CustomPanel1.SuspendLayout()
        CType(Me.CommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanelInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProgressPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanelDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CustomPanel1
        '
        Me.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanel1.Controls.Add(Me.CustomPanel2)
        Me.CustomPanel1.Controls.Add(Me.btnN2OIgnite)
        Me.CustomPanel1.Controls.Add(Me.btnR)
        Me.CustomPanel1.Controls.Add(Me.btnIgnite)
        Me.CustomPanel1.Controls.Add(Me.btnExtinguish)
        Me.CustomPanel1.Controls.Add(Me.btnDelete)
        Me.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanel1.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanel1.Name = "CustomPanel1"
        Me.CustomPanel1.Size = New System.Drawing.Size(658, 359)
        Me.CustomPanel1.TabIndex = 1
        '
        'CustomPanel2
        '
        Me.CustomPanel2.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanel2.Location = New System.Drawing.Point(56, 272)
        Me.CustomPanel2.Name = "CustomPanel2"
        Me.CustomPanel2.Size = New System.Drawing.Size(64, 16)
        Me.CustomPanel2.TabIndex = 16
        '
        'btnN2OIgnite
        '
        Me.btnN2OIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnN2OIgnite.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnN2OIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnN2OIgnite.Location = New System.Drawing.Point(72, 280)
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
        Me.btnR.Location = New System.Drawing.Point(96, 280)
        Me.btnR.Name = "btnR"
        Me.btnR.Size = New System.Drawing.Size(8, 8)
        Me.btnR.TabIndex = 22
        Me.btnR.TabStop = False
        Me.btnR.Text = "&R"
        Me.btnR.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnIgnite
        '
        Me.btnIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIgnite.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIgnite.Location = New System.Drawing.Point(88, 280)
        Me.btnIgnite.Name = "btnIgnite"
        Me.btnIgnite.Size = New System.Drawing.Size(8, 8)
        Me.btnIgnite.TabIndex = 20
        Me.btnIgnite.TabStop = False
        Me.btnIgnite.Text = "&Ignition"
        Me.btnIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnExtinguish
        '
        Me.btnExtinguish.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExtinguish.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExtinguish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExtinguish.Location = New System.Drawing.Point(80, 280)
        Me.btnExtinguish.Name = "btnExtinguish"
        Me.btnExtinguish.Size = New System.Drawing.Size(8, 8)
        Me.btnExtinguish.TabIndex = 21
        Me.btnExtinguish.TabStop = False
        Me.btnExtinguish.Text = "&Extinguish"
        Me.btnExtinguish.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnDelete
        '
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(104, 280)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(8, 8)
        Me.btnDelete.TabIndex = 23
        Me.btnDelete.TabStop = False
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'CommandBar1
        '
        Me.CommandBar1.BackColor = System.Drawing.Color.Transparent
        Me.CommandBar1.CustomBackground = True
        Me.CommandBar1.CustomizeText = "&Customize Toolbar..."
        Me.CommandBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.CommandBar1.FullRow = True
        Me.CommandBar1.ID = 629
        Me.CommandBar1.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuChangePort1, Me.mnuTest_AAS2031, Me.mnuService1, Me.mnuInstSetup1, Me.mnuSpectrum, Me.mnuAbout, Me.mnuBeamType, Me.mnuExit1})
        Me.CommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.CommandBar1.Margins.Bottom = 1
        Me.CommandBar1.Margins.Left = 1
        Me.CommandBar1.Margins.Right = 1
        Me.CommandBar1.Margins.Top = 1
        Me.CommandBar1.Name = "CommandBar1"
        Me.CommandBar1.Size = New System.Drawing.Size(658, 23)
        Me.CommandBar1.Style = NETXP.Controls.Bars.CommandBarStyle.Menu
        Me.CommandBar1.TabIndex = 2
        Me.CommandBar1.TabStop = False
        Me.CommandBar1.Text = ""
        '
        'mnuChangePort1
        '
        Me.mnuChangePort1.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuChangePort})
        Me.mnuChangePort1.PadHorizontal = 5
        Me.mnuChangePort1.Text = "&Change Port"
        '
        'mnuChangePort
        '
        Me.mnuChangePort.Text = "&Change Port"
        '
        'mnuTest_AAS2031
        '
        Me.mnuTest_AAS2031.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuTest_AAS203})
        Me.mnuTest_AAS2031.PadHorizontal = 5
        Me.mnuTest_AAS2031.Shortcut = System.Windows.Forms.Shortcut.CtrlT
        Me.mnuTest_AAS2031.Text = "Test"
        '
        'mnuTest_AAS203
        '
        Me.mnuTest_AAS203.Image = CType(resources.GetObject("mnuTest_AAS203.Image"), System.Drawing.Image)
        Me.mnuTest_AAS203.Text = "Test"
        '
        'mnuService1
        '
        Me.mnuService1.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuService})
        Me.mnuService1.PadHorizontal = 5
        Me.mnuService1.Shortcut = System.Windows.Forms.Shortcut.CtrlS
        Me.mnuService1.Text = "&Service"
        '
        'mnuService
        '
        Me.mnuService.Image = CType(resources.GetObject("mnuService.Image"), System.Drawing.Image)
        Me.mnuService.Text = "&Service"
        '
        'mnuInstSetup1
        '
        Me.mnuInstSetup1.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuInstSetup})
        Me.mnuInstSetup1.PadHorizontal = 5
        Me.mnuInstSetup1.Text = "I&nst Setup"
        '
        'mnuInstSetup
        '
        Me.mnuInstSetup.Image = CType(resources.GetObject("mnuInstSetup.Image"), System.Drawing.Image)
        Me.mnuInstSetup.Text = "&Inst Setup"
        '
        'mnuSpectrum
        '
        Me.mnuSpectrum.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuUVSpectrum, Me.mnuEnergySpectrum})
        Me.mnuSpectrum.PadHorizontal = 5
        Me.mnuSpectrum.Text = "S&pectrum"
        '
        'mnuUVSpectrum
        '
        Me.mnuUVSpectrum.Image = CType(resources.GetObject("mnuUVSpectrum.Image"), System.Drawing.Image)
        Me.mnuUVSpectrum.Text = "&UV Spectrum"
        '
        'mnuEnergySpectrum
        '
        Me.mnuEnergySpectrum.Image = CType(resources.GetObject("mnuEnergySpectrum.Image"), System.Drawing.Image)
        Me.mnuEnergySpectrum.Text = "&Energy Spectrum"
        '
        'mnuAbout
        '
        Me.mnuAbout.PadHorizontal = 5
        Me.mnuAbout.Text = "A&bout"
        Me.mnuAbout.Visible = False
        '
        'mnuBeamType
        '
        Me.mnuBeamType.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuSingleBeam, Me.mnuDoubleBeam})
        Me.mnuBeamType.Text = "Beam Type"
        Me.mnuBeamType.Visible = False
        '
        'mnuSingleBeam
        '
        Me.mnuSingleBeam.CheckType = NETXP.Controls.Bars.ButtonItemCheckType.Radio
        Me.mnuSingleBeam.Text = "Single Beam"
        '
        'mnuDoubleBeam
        '
        Me.mnuDoubleBeam.Checked = True
        Me.mnuDoubleBeam.CheckType = NETXP.Controls.Bars.ButtonItemCheckType.Radio
        Me.mnuDoubleBeam.Text = "Double Beam"
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
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 335)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanelInfo, Me.ProgressPanel, Me.StatusBarPanelDate})
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(658, 24)
        Me.StatusBar1.TabIndex = 9
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
        'mnuIngnition
        '
        Me.mnuIngnition.Shortcut = System.Windows.Forms.Shortcut.CtrlI
        Me.mnuIngnition.Text = Nothing
        '
        'frmMDIMainService
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(658, 359)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.CommandBar1)
        Me.Controls.Add(Me.CustomPanel1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IsMdiContainer = True
        Me.Name = "frmMDIMainService"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "AA203 Service and Maintenance Software"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.CustomPanel1.ResumeLayout(False)
        CType(Me.CommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanelInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProgressPanel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanelDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Public Variables "

    'Public gobjCommdll As New RS232SerialComm.clsRS232Main(9600, 0, gintCommPortSelected, 8)
    Public gobjCommdll As New clsRS232Main(9600, 0, gintCommPortSelected, 8)

    Private mblnAvoidProcessing As Boolean = False
    Dim objfrmAASInitialisation As frmAASInitialisation
#End Region

#Region " Private Constants "

    Private Const ConstAA203FormLoad = "AA 203-Service and Maintaince Software"
    'Private Const ConstAA203DFormLoad = "AAS203D-Service and Maintaince Software" by Pankaj on 16.1.08
    Private Const ConstAA203DFormLoad = "AA 203D-Service and Maintaince Software" ' by Pankaj on 16.1.08
    Private Const ConstAA201FormLoad = "AA 201-Service and Maintaince Software"

    '---4.85 14.04.09
    Private Const ConstAA303FormLoad = "AA 303-Service and Maintaince Software"
    Private Const ConstAA303DFormLoad = "AA 303D-Service and Maintaince Software"
    Private Const ConstAA301FormLoad = "AA 301-Service and Maintaince Software"
    '---4.85 14.04.09

#End Region

#Region " Form Events "

    Private Sub frmMDIMainService_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Dim objWait As CWaitCursor

        Try
            'gobjInst.WavelengthCur = 0.0
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                btnIgnite.Enabled = False
                btnExtinguish.Enabled = False
            End If

            If gstructSettings.ExeToRun = EnumApplicationMode.AAS Then
                mnuChangePort1.Enabled = False
            End If
            CommandBar1.BackColor = System.Drawing.Color.Gainsboro

            gobjclsTimer = New clsTimer(StatusBar1, 1000)
            'gobjMain.mobjController.Cancel()
            gobjfrmStatus.Visible = False

            If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                'Call ShowProgressBar(ConstAA203DFormLoad)
                'Me.Text = ConstAA203DFormLoad

                '---4.85  14.04.09
                If gstructSettings.NewModelName = False Then
                    Call ShowProgressBar(ConstAA203DFormLoad)
                    Me.Text = ConstAA203DFormLoad
                Else
                    Call ShowProgressBar(ConstAA203DFormLoad)
                    Me.Text = ConstAA303DFormLoad
                End If
                '---4.85  14.04.09

                mnuBeamType.Visible = True
            ElseIf gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
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

            Else
                'Call ShowProgressBar(ConstAA203FormLoad)
                'Me.Text = ConstAA203FormLoad

                '---4.85  14.04.09
                If gstructSettings.NewModelName = False Then
                    Call ShowProgressBar(ConstAA203FormLoad)
                    Me.Text = ConstAA203FormLoad
                Else
                    Call ShowProgressBar(ConstAA303FormLoad)
                    Me.Text = ConstAA303FormLoad
                End If
                '---4.85  14.04.09

                mnuUVSpectrum.Enabled = True
            End If

            Me.BringToFront()

            'gobjMain.Visible = False
            Call AddHandlers()


            '---added by deepak on 21.01.08
            gobjNewMethod = New clsMethod
            '---added by deepak on 21.01.08

            Call HideProgressBar()

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
            Application.DoEvents()
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
        ' Author                : Saurabh
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Try
            AddHandler mnuExit.Click, AddressOf mnuExit_Click
            AddHandler mnuAbout.Click, AddressOf mnuAbout_Click
            AddHandler mnuService.Click, AddressOf mnuService_Click
            AddHandler mnuChangePort.Click, AddressOf mnuChangePort_Click
            AddHandler mnuTest_AAS203.Click, AddressOf mnuTest_AAS203_Click
            AddHandler mnuInstSetup.Click, AddressOf mnuInstSetup_TimeScan_Click
            AddHandler mnuUVSpectrum.Click, AddressOf mnuUVSpectrum_Click
            AddHandler mnuEnergySpectrum.Click, AddressOf mnuEnergySpectrum_Click
            AddHandler mnuSingleBeam.Click, AddressOf mnuSingleBeam_Click
            AddHandler mnuDoubleBeam.Click, AddressOf mnuDoubleBeam_Click
            'AddHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click
            'AddHandler btnDelete.Click, AddressOf btnDelete_Click
            'AddHandler btnR.Click, AddressOf btnR_Click
            'AddHandler btnIgnite.Click, AddressOf btnIgnite_Click
            'AddHandler btnExtinguish.Click, AddressOf btnExtinguish_Click
            'AddHandler btnN2OIgnite.Click, AddressOf btnN2OIgnite_Click


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
        ' Purpose               : To exit from the software 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 25.09.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub mnuService_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuService_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the Service Routines form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 25.09.06
        ' Revisions             : 
        '=====================================================================
        'Dim objWait As New CWaitCursor
        'Dim objfrmServiceRoutines As New frmServiceRoutines
        gobjService = New frmServiceRoutines
        Try
            gobjService.ShowDialog()
            gobjService.Close()
            gobjService.Dispose()
            gobjService = Nothing
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
            'If Not objWait Is Nothing Then
            '    objWait.Dispose()
            'End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub mnuChangePort_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuChangePort_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To select the Communication Port
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 30.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim objfrmCommPorts_Selection As New frmCommPorts_Selection
        Dim blnFlag As Boolean
        Try
            ''--------------------------------------------
            ''Do While (True)
            'frmCommPorts_Selection.ShowDialog() '--- there is no com port available so select one from this 

            '' if comm port selection is cancelled
            'If gintCommPortSelected = 0 Then
            '    Exit Sub       '-- -End the Communication loop
            'Else

            '    If gobjCommdll.gFuncIsPortOpen() Then
            '        MsgBox("You have successfully selected the port.")
            '        '-- -End the Communication loopS
            '    End If

            'End If
            'frmCommPorts_Selection.Dispose()
            ''---------------------------------------------



            'lngtime1 = System.DateTime.Now.Ticks / 10000



            'Do While (True)  'Commented by Saurabh

            If objfrmCommPorts_Selection.ShowDialog() = DialogResult.OK Then
                Application.DoEvents()
                If gobjCommProtocol.mobjCommdll.gFuncIsPortOpen() Then
                    gobjCommProtocol.mobjCommdll.gFuncCloseComm()
                    'Me.SendToBack()
                    '
                    blnFlag = gobjCommProtocol.funcInitInstrument()
                    Application.DoEvents()
                    If blnFlag = True Then
                        If objfrmAASInitialisation Is Nothing Then
                            objfrmAASInitialisation = New frmAASInitialisation
                        End If
                        objfrmAASInitialisation.Show()
                        objfrmAASInitialisation.BringToFront()
                        If gobjCommProtocol.mobjCommdll.gFuncIsPortOpen() Then
                            gobjCommProtocol.mobjCommdll.gFuncCloseComm()
                        End If

                        'If objfrmAASInitialisation Is Nothing Then
                        '    objfrmAASInitialisation = New frmAASInitialisation
                        'End If
                        'Me.Hide()
                        'objfrmAASInitialisation.Show()
                        If objfrmAASInitialisation.funcInstrumentInitialization() Then
                            objfrmAASInitialisation.Close()
                            objfrmAASInitialisation.Dispose()
                        Else
                            objfrmAASInitialisation.Close()
                            objfrmAASInitialisation.Dispose()
                            'End
                            Me.Close()
                            Exit Sub
                        End If
                        'Me.Show()
                    End If

                Else
                    gobjMessageAdapter.ShowMessage(constComPortNotAvailable)
                    Application.DoEvents()
                End If
            End If
            ' objfrmCommPorts_Selection.ShowDialog()       '--- there is no com port available so select one from this 

            If gintCommPortSelected = 0 Then
                objfrmCommPorts_Selection.Close()
                objfrmCommPorts_Selection.Dispose()
                Exit Sub       '-- -End the Communication loop
            End If

            If gobjCommdll.gFuncIsPortOpen() = True Then
                'GoTo AgnComm
                ' communicate again with the instrument by sending reset command
                'gobjMessageAdapter.ShowMessage()
                'MsgBox("DONE")
            Else
                gobjMessageAdapter.MessageTextAlignment = ContentAlignment.MiddleLeft
                gobjMessageAdapter.ShowMessage(constCommError)
                Application.DoEvents()
            End If


            'Loop       'Saurabh
            objfrmCommPorts_Selection.Close()
            objfrmCommPorts_Selection.Dispose()


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
            If Not (objfrmCommPorts_Selection Is Nothing) Then
                objfrmCommPorts_Selection = Nothing
            End If
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub mnuAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuAbout_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To show About Us form.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 05.12.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim objfrmAbout As New frmAbout
        Try
            objfrmAbout.ShowDialog()
            objfrmAbout.Close()
            objfrmAbout.Dispose()
            objfrmAbout = Nothing
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

    Private Sub mnuTest_AAS203_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuTest_AAS203_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To show Command Test form.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 05.12.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim objfrmCommandTest As New frmCommandTest
        Try
            'MessageBox.Show("Work Under Progress")
            'Exit Sub
            objfrmCommandTest.ShowDialog()
            objfrmCommandTest.Close()
            objfrmCommandTest.Dispose()
            objfrmCommandTest = Nothing
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

    Private Sub mnuInstSetup_TimeScan_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuInstSetup_TimeScan_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the Time scan form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 25.09.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim objfrmTimeScan As Object 'frmTimeScanMode
        Try
            If (gstructSettings.Enable21CFR = True) Then
                If Not funcCheckActivityAuthentication(enumActivityAuthentication.Energy_Spectrum_Mode, gstructUserDetails.Access) Then
                    Exit Sub
                End If
                gfuncInsertActivityLog(EnumModules.TimeScan, "TimeScan_Mode Accessed")
            End If

            Application.DoEvents()

            gintSpectrumMode = modGlobalDeclarations.EnumSpectrumMode.TimeScan
            If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                'If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam Or _
                '            gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.ReferenceBeam Then
                '    'objfrmTimeScan = New frmTimeScanMode
                '    objfrmTimeScan = New frmTimeScanDBMode
                'Else

                '    objfrmTimeScan = New frmTimeScanDBMode
                'End If
                'by Pankaj on 18.1.08 for beam type
                If gintServiceBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
                    objfrmTimeScan = New frmTimeScanDBMode
                Else
                    objfrmTimeScan = New frmTimeScanMode
                End If
            Else
                objfrmTimeScan = New frmTimeScanMode
            End If
            objfrmTimeScan.ShowDialog()
            gobjclsTimer.subTimerStart(StatusBar1)
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

    Private Sub mnuUVSpectrum_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuUVSpectrum_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the UV Spectrum form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 25.09.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim objfrmUVSpectrumMode As New frmUVScanningSpectrumMode
        Dim objfrmUVSpectrumDBMode As New frmUVScanningSpectrumDBMode
        'MessageBox.Show("Work Under Progress")
        'Exit Sub
        Try
            If Not gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then
                If (gstructSettings.Enable21CFR = True) Then
                    If Not funcCheckActivityAuthentication(enumActivityAuthentication.UV_Scanning_Spectrum_Mode, gstructUserDetails.Access) Then
                        Return
                        Exit Sub
                    End If
                    gfuncInsertActivityLog(EnumModules.UV_Scanning_Spectrum_Mode, "UV_Scanning_Spectrum_Mode Accessed")
                End If
            End If

            gintSpectrumMode = modGlobalDeclarations.EnumSpectrumMode.UVSpetrum
            If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                'objfrmUVSpectrumDBMode = New frmUVScanningSpectrumDBMode
                'objfrmUVSpectrumDBMode.ShowDialog()
                'by Pankaj on 18.1.08 for beam type
                If gintServiceBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
                    objfrmUVSpectrumDBMode = New frmUVScanningSpectrumDBMode
                    objfrmUVSpectrumDBMode.ShowDialog()
                Else
                    objfrmUVSpectrumMode = New frmUVScanningSpectrumMode
                    objfrmUVSpectrumMode.ShowDialog()
                End If
            Else
                objfrmUVSpectrumMode = New frmUVScanningSpectrumMode
                objfrmUVSpectrumMode.ShowDialog()
            End If

            'objfrmUVSpectrumMode.ShowDialog()
            gobjclsTimer.subTimerStart(StatusBar1)
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

    Private Sub mnuEnergySpectrum_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuEnergySpectrum_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the Energy Spectrum form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 25.09.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim objfrmEnergySpectrumMode As frmEnergySpectrumMode
        Dim objfrmEnergySpectrumDBMode As frmEnergySpectrumDBMode
        'MessageBox.Show("Work Under Progress")
        'Exit Sub
        Try
            If Not gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then
                If (gstructSettings.Enable21CFR = True) Then
                    If Not funcCheckActivityAuthentication(enumActivityAuthentication.Energy_Spectrum_Mode, gstructUserDetails.Access) Then
                        Exit Sub
                    End If
                    gfuncInsertActivityLog(EnumModules.Energy_Spectrum_Mode, "Energy_Spectrum_Mode Accessed")
                End If
            End If

            gintSpectrumMode = modGlobalDeclarations.EnumSpectrumMode.EnergySpectrum
            If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                'by Pankaj on 18.1.08 for beam type
                If gintServiceBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
                    objfrmEnergySpectrumDBMode = New frmEnergySpectrumDBMode
                    objfrmEnergySpectrumDBMode.ShowDialog()
                Else
                    objfrmEnergySpectrumMode = New frmEnergySpectrumMode
                    objfrmEnergySpectrumMode.ShowDialog()
                End If
                'objfrmEnergySpectrumDBMode = New frmEnergySpectrumDBMode
                'objfrmEnergySpectrumDBMode.ShowDialog()
            Else
                objfrmEnergySpectrumMode = New frmEnergySpectrumMode
                objfrmEnergySpectrumMode.ShowDialog()
            End If

            'objfrmEnergySpectrumMode.ShowDialog()
            gobjclsTimer.subTimerStart(StatusBar1)
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

    Private Sub btnAutoIgnition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnAutoIgnition_Click
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

            'If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
            ' mobjController.Cancel()
            Application.DoEvents()

            Call gobjClsAAS203.funcIgnite(True)

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
            'If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = True
            'mobjController.Start(gobjclsBgFlameStatus)
            Application.DoEvents()
            'AddHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
            '---------------------------------------------------------
        End Try
    End Sub

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
    Private Sub mnuSingleBeam_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuSingleBeam_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : beam type
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Pankaj Bamb
        ' Created               : 18.01.08
        ' Revisions             : 
        '=====================================================================

        mnuSingleBeam.Checked = True
        mnuDoubleBeam.Checked = False
        gintServiceBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam
    End Sub

    Private Sub mnuDoubleBeam_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuDoubleBeam_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : beam type
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Pankaj Bamb
        ' Created               : 18.01.08
        ' Revisions             : 
        '=====================================================================

        mnuDoubleBeam.Checked = True
        mnuSingleBeam.Checked = False
        gintServiceBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam
    End Sub

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

    'Private Sub mnuService_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuService.Enter
    '    '=====================================================================
    '    ' Procedure Name        : mnuServiceUtility_Click
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : To load the Service Utility form
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Saurabh S
    '    ' Created               : 25.09.06
    '    ' Revisions             : 
    '    '=====================================================================
    '    Dim objWait As New CWaitCursor
    '    Dim objfrmServiceRoutines As New frmServiceRoutines
    '    Try
    '        objfrmServiceRoutines.ShowDialog()
    '        Application.DoEvents()
    '        Me.Visible = True
    '        objWait = New CWaitCursor
    '        objfrmServiceRoutines.Close()
    '        objfrmServiceRoutines.Dispose()
    '        Application.DoEvents()
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

    'Private Sub mnuAbout_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuAbout.Enter
    '    '=====================================================================
    '    ' Procedure Name        : mnuAbout_Click
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : To show About Us form.
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Saurabh S
    '    ' Created               : 05.12.06
    '    ' Revisions             : 
    '    '=====================================================================
    '    Dim objWait As New CWaitCursor
    '    Dim objfrmAbout As New frmAbout
    '    Try
    '        objfrmAbout.ShowDialog()
    '        Application.DoEvents()

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

    'Private Sub mnuExit_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuExit.Enter
    '    '=====================================================================
    '    ' Procedure Name        : mnuExit_Click
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : To exit from the software 
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Saurabh S
    '    ' Created               : 25.09.06
    '    ' Revisions             : 
    '    '=====================================================================
    '    Dim objWait As New CWaitCursor
    '    Try
    '        Me.Close()

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

    'Private Sub mnuInstSetup_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuInstSetup.Enter
    '    '=====================================================================
    '    ' Procedure Name        : mnuInstSetup_TimeScan_Click
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : To load the Time scan form
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Saurabh S
    '    ' Created               : 25.09.06
    '    ' Revisions             : 
    '    '=====================================================================
    '    Dim objfrmTimeScan As New frmTimeScanMode
    '    Dim objWait As New CWaitCursor
    '    Try
    '        If (gstructSettings.Enable21CFR = True) Then
    '            If Not funcCheckActivityAuthentication(enumActivityAuthentication.Energy_Spectrum_Mode, gstructUserDetails.Access) Then
    '                Exit Sub
    '            End If
    '            gfuncInsertActivityLog(EnumModules.TimeScan, "TimeScan_Mode Accessed")
    '        End If

    '        Application.DoEvents()
    '        gintSpectrumMode = modGlobalDeclarations.EnumSpectrumMode.TimeSacn
    '        objfrmTimeScan.ShowDialog()
    '        Application.DoEvents()
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

    Private Sub frmMDIMainService_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        'gobjMain.mobjController.Start(gobjclsBgFlameStatus)
        'gobjfrmStatus.Visible = True
        'Application.DoEvents()
        If Not gobjclsTimer Is Nothing Then
            gobjclsTimer.subTimerStop()
        End If
    End Sub

    Private Sub btnIgnite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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

    Private Sub btnN2OIgnite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If

        Try
            mblnAvoidProcessing = True
            N2OAutoIgnition()
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

    Private Sub btnExtinguish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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

    Private Sub MenuBar_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CommandBar1.KeyUp
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
                    Call funcAltDelete()
                Case Keys.R
                    Call funcAltR()
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

            If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
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

            If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
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

            If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
                Call Application.DoEvents()
                Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
                Call gobjCommProtocol.funcSwitchOver()

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

    Public Function funcAltDelete() As Boolean
        '=====================================================================
        ' Procedure Name        : funcAltDelete
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 18-Dec-2007 03:15 pm
        ' Revisions             : 1
        '=====================================================================
        Try
            'RemoveHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click

            'If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
            If Not ((gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                (gstructSettings.AppMode = EnumAppMode.DemoMode_203D)) Then
                Call Application.DoEvents()
                Call gobjCommProtocol.mobjCommdll.subTime_Delay(50)
                gobjClsAAS203.ReInitInstParameters()
            Else
                'Call gobjMessageAdapter.ShowMessage(constFlameIgnited)
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

    Public Function funcAltR() As Boolean
        '=====================================================================
        ' Procedure Name        : funcAltR
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 18-Dec-2007 03:15 pm
        ' Revisions             : 1
        '=====================================================================
        Try
            'If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
            If Not ((gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                (gstructSettings.AppMode = EnumAppMode.DemoMode_203D)) Then
                Call Application.DoEvents()
                Call gobjCommProtocol.mobjCommdll.subTime_Delay(50)
                Call gobjClsAAS203.funcInstReset()
            Else
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
            If mblnAvoidProcessing = True Then
                Exit Sub
            End If
            mblnAvoidProcessing = True
            Application.DoEvents()
            Call funcAltDelete()
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
            If mblnAvoidProcessing = True Then
                Exit Sub
            End If
            mblnAvoidProcessing = True
            Application.DoEvents()
            'Alt - R
            Call funcAltR()
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
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MessageBox.Show(gobjInst.Mode.ToString)
    End Sub
End Class
