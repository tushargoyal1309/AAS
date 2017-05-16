Imports AAS203.Common
Imports AAS203Library.Method

''these are like header files

Public Class frmInstrumentParameters ''this class contain a function for setting instrument cond for particuler method
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        '//--- Added by Sachin Dokhale on 23.02.08 to display Max No of lamp on screen
        Me.subShowMaxLamps()
        '//---

    End Sub

    Public Sub New(ByVal intMethodMode As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        '//--- Added by Sachin Dokhale on 23.02.08 to display Max No of lamp on screen
        Me.subShowMaxLamps()
        '//---
        'Add any initialization after the InitializeComponent() call
        OpenMethodMode = intMethodMode

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
    Friend WithEvents CustomPanelRightBottom As GradientPanel.CustomPanel
    Friend WithEvents CustomPanelBottom As GradientPanel.CustomPanel
    Friend WithEvents CustomPanelBottomTop As GradientPanel.CustomPanel
    Friend WithEvents btnHelp As NETXP.Controls.XPButton
    Friend WithEvents btnOk As NETXP.Controls.XPButton
    Friend WithEvents btnCancel As NETXP.Controls.XPButton
    Friend WithEvents CustomPanelTop As GradientPanel.CustomPanel
    Friend WithEvents Office2003Header1 As CodeIntellects.Office2003Controls.Office2003Header
    Friend WithEvents gbMeasurementCond As System.Windows.Forms.GroupBox
    Friend WithEvents lblElementName As System.Windows.Forms.Label
    Friend WithEvents lblTurretNum As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblLampCurrent As System.Windows.Forms.Label
    Friend WithEvents lblWavelength As System.Windows.Forms.Label
    Friend WithEvents lblSlitWidth As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnOptimiseTurret As NETXP.Controls.XPButton
    Friend WithEvents btnWarmupLamp As NETXP.Controls.XPButton
    Friend WithEvents btnReplaceLamp As NETXP.Controls.XPButton
    Friend WithEvents btnOptimiseAllTurret As NETXP.Controls.XPButton
    Friend WithEvents txtTurretNum As NumberValidator.NumberValidator
    Friend WithEvents txtLampCurrent As NumberValidator.NumberValidator
    Friend WithEvents txtSlitWidth As NumberValidator.NumberValidator
    Friend WithEvents cmbWV As System.Windows.Forms.ComboBox
    Public WithEvents cmbElementName As System.Windows.Forms.ComboBox

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmInstrumentParameters))
        Me.CustomPanelMain = New GradientPanel.CustomPanel
        Me.CustomPanelRightBottom = New GradientPanel.CustomPanel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmbWV = New System.Windows.Forms.ComboBox
        Me.txtSlitWidth = New NumberValidator.NumberValidator
        Me.txtLampCurrent = New NumberValidator.NumberValidator
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblLampCurrent = New System.Windows.Forms.Label
        Me.lblWavelength = New System.Windows.Forms.Label
        Me.lblSlitWidth = New System.Windows.Forms.Label
        Me.CustomPanelBottom = New GradientPanel.CustomPanel
        Me.btnCancel = New NETXP.Controls.XPButton
        Me.CustomPanelBottomTop = New GradientPanel.CustomPanel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnOptimiseTurret = New NETXP.Controls.XPButton
        Me.btnWarmupLamp = New NETXP.Controls.XPButton
        Me.btnReplaceLamp = New NETXP.Controls.XPButton
        Me.btnOptimiseAllTurret = New NETXP.Controls.XPButton
        Me.btnHelp = New NETXP.Controls.XPButton
        Me.btnOk = New NETXP.Controls.XPButton
        Me.CustomPanelTop = New GradientPanel.CustomPanel
        Me.gbMeasurementCond = New System.Windows.Forms.GroupBox
        Me.txtTurretNum = New NumberValidator.NumberValidator
        Me.cmbElementName = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblTurretNum = New System.Windows.Forms.Label
        Me.lblElementName = New System.Windows.Forms.Label
        Me.Office2003Header1 = New CodeIntellects.Office2003Controls.Office2003Header
        Me.CustomPanelMain.SuspendLayout()
        Me.CustomPanelRightBottom.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.CustomPanelBottom.SuspendLayout()
        Me.CustomPanelBottomTop.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.CustomPanelTop.SuspendLayout()
        Me.gbMeasurementCond.SuspendLayout()
        Me.SuspendLayout()
        '
        'CustomPanelMain
        '
        Me.CustomPanelMain.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanelMain.BackColor2 = System.Drawing.Color.AliceBlue
        Me.CustomPanelMain.Controls.Add(Me.CustomPanelRightBottom)
        Me.CustomPanelMain.Controls.Add(Me.CustomPanelBottom)
        Me.CustomPanelMain.Controls.Add(Me.CustomPanelTop)
        Me.CustomPanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanelMain.Location = New System.Drawing.Point(0, 22)
        Me.CustomPanelMain.Name = "CustomPanelMain"
        Me.CustomPanelMain.Size = New System.Drawing.Size(424, 367)
        Me.CustomPanelMain.TabIndex = 12
        '
        'CustomPanelRightBottom
        '
        Me.CustomPanelRightBottom.BackColor = System.Drawing.Color.Transparent
        Me.CustomPanelRightBottom.BackColor2 = System.Drawing.Color.Transparent
        Me.CustomPanelRightBottom.Controls.Add(Me.GroupBox1)
        Me.CustomPanelRightBottom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanelRightBottom.Location = New System.Drawing.Point(0, 72)
        Me.CustomPanelRightBottom.Name = "CustomPanelRightBottom"
        Me.CustomPanelRightBottom.Size = New System.Drawing.Size(424, 127)
        Me.CustomPanelRightBottom.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbWV)
        Me.GroupBox1.Controls.Add(Me.txtSlitWidth)
        Me.GroupBox1.Controls.Add(Me.txtLampCurrent)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblLampCurrent)
        Me.GroupBox1.Controls.Add(Me.lblWavelength)
        Me.GroupBox1.Controls.Add(Me.lblSlitWidth)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(10, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(406, 112)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Working Conditions"
        '
        'cmbWV
        '
        Me.cmbWV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbWV.Location = New System.Drawing.Point(128, 48)
        Me.cmbWV.Name = "cmbWV"
        Me.cmbWV.Size = New System.Drawing.Size(104, 24)
        Me.cmbWV.TabIndex = 1
        '
        'txtSlitWidth
        '
        Me.txtSlitWidth.DigitsAfterDecimalPoint = 1
        Me.txtSlitWidth.ErrorColor = System.Drawing.Color.Empty
        Me.txtSlitWidth.ErrorMessage = Nothing
        Me.txtSlitWidth.Location = New System.Drawing.Point(128, 81)
        Me.txtSlitWidth.MaximumRange = 2
        Me.txtSlitWidth.MaxLength = 4
        Me.txtSlitWidth.MinimumRange = 0
        Me.txtSlitWidth.Name = "txtSlitWidth"
        Me.txtSlitWidth.RangeValidation = True
        Me.txtSlitWidth.Size = New System.Drawing.Size(104, 22)
        Me.txtSlitWidth.TabIndex = 2
        Me.txtSlitWidth.Text = ""
        Me.txtSlitWidth.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly
        '
        'txtLampCurrent
        '
        Me.txtLampCurrent.DigitsAfterDecimalPoint = 1
        Me.txtLampCurrent.ErrorColor = System.Drawing.Color.Empty
        Me.txtLampCurrent.ErrorMessage = Nothing
        Me.txtLampCurrent.Location = New System.Drawing.Point(128, 18)
        Me.txtLampCurrent.MaximumRange = 25
        Me.txtLampCurrent.MaxLength = 4
        Me.txtLampCurrent.MinimumRange = 0
        Me.txtLampCurrent.Name = "txtLampCurrent"
        Me.txtLampCurrent.RangeValidation = True
        Me.txtLampCurrent.Size = New System.Drawing.Size(104, 22)
        Me.txtLampCurrent.TabIndex = 0
        Me.txtLampCurrent.Text = ""
        Me.txtLampCurrent.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly
        '
        'Label4
        '
        Me.Label4.Enabled = False
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(232, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(168, 18)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "0 - 2.0 nm in steps of 0.1 nm"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Enabled = False
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(232, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(168, 18)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "185 .. 950 nm"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Enabled = False
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(232, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 18)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "0 - 25 mA"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLampCurrent
        '
        Me.lblLampCurrent.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLampCurrent.Location = New System.Drawing.Point(8, 18)
        Me.lblLampCurrent.Name = "lblLampCurrent"
        Me.lblLampCurrent.Size = New System.Drawing.Size(104, 16)
        Me.lblLampCurrent.TabIndex = 23
        Me.lblLampCurrent.Text = "Lamp Current"
        '
        'lblWavelength
        '
        Me.lblWavelength.BackColor = System.Drawing.Color.Transparent
        Me.lblWavelength.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWavelength.Location = New System.Drawing.Point(8, 50)
        Me.lblWavelength.Name = "lblWavelength"
        Me.lblWavelength.Size = New System.Drawing.Size(104, 16)
        Me.lblWavelength.TabIndex = 21
        Me.lblWavelength.Text = "Wavelength"
        '
        'lblSlitWidth
        '
        Me.lblSlitWidth.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSlitWidth.Location = New System.Drawing.Point(8, 82)
        Me.lblSlitWidth.Name = "lblSlitWidth"
        Me.lblSlitWidth.Size = New System.Drawing.Size(104, 16)
        Me.lblSlitWidth.TabIndex = 20
        Me.lblSlitWidth.Text = "Slit Width"
        '
        'CustomPanelBottom
        '
        Me.CustomPanelBottom.BackColor = System.Drawing.Color.Transparent
        Me.CustomPanelBottom.BackColor2 = System.Drawing.Color.Transparent
        Me.CustomPanelBottom.Controls.Add(Me.btnCancel)
        Me.CustomPanelBottom.Controls.Add(Me.CustomPanelBottomTop)
        Me.CustomPanelBottom.Controls.Add(Me.btnHelp)
        Me.CustomPanelBottom.Controls.Add(Me.btnOk)
        Me.CustomPanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CustomPanelBottom.Location = New System.Drawing.Point(0, 199)
        Me.CustomPanelBottom.Name = "CustomPanelBottom"
        Me.CustomPanelBottom.Size = New System.Drawing.Size(424, 168)
        Me.CustomPanelBottom.TabIndex = 2
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(305, 126)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 34)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "&Cancel"
        '
        'CustomPanelBottomTop
        '
        Me.CustomPanelBottomTop.BackColor = System.Drawing.Color.Transparent
        Me.CustomPanelBottomTop.BackColor2 = System.Drawing.Color.Transparent
        Me.CustomPanelBottomTop.Controls.Add(Me.GroupBox2)
        Me.CustomPanelBottomTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.CustomPanelBottomTop.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanelBottomTop.Name = "CustomPanelBottomTop"
        Me.CustomPanelBottomTop.Size = New System.Drawing.Size(424, 120)
        Me.CustomPanelBottomTop.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnOptimiseTurret)
        Me.GroupBox2.Controls.Add(Me.btnWarmupLamp)
        Me.GroupBox2.Controls.Add(Me.btnReplaceLamp)
        Me.GroupBox2.Controls.Add(Me.btnOptimiseAllTurret)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(406, 104)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'btnOptimiseTurret
        '
        Me.btnOptimiseTurret.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOptimiseTurret.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOptimiseTurret.Image = CType(resources.GetObject("btnOptimiseTurret.Image"), System.Drawing.Image)
        Me.btnOptimiseTurret.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOptimiseTurret.Location = New System.Drawing.Point(11, 62)
        Me.btnOptimiseTurret.Name = "btnOptimiseTurret"
        Me.btnOptimiseTurret.Size = New System.Drawing.Size(176, 34)
        Me.btnOptimiseTurret.TabIndex = 2
        Me.btnOptimiseTurret.Text = "Optimise &Turret"
        '
        'btnWarmupLamp
        '
        Me.btnWarmupLamp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWarmupLamp.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWarmupLamp.Image = CType(resources.GetObject("btnWarmupLamp.Image"), System.Drawing.Image)
        Me.btnWarmupLamp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnWarmupLamp.Location = New System.Drawing.Point(215, 17)
        Me.btnWarmupLamp.Name = "btnWarmupLamp"
        Me.btnWarmupLamp.Size = New System.Drawing.Size(176, 34)
        Me.btnWarmupLamp.TabIndex = 1
        Me.btnWarmupLamp.Text = "&Warm up Lamp"
        '
        'btnReplaceLamp
        '
        Me.btnReplaceLamp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReplaceLamp.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReplaceLamp.Image = CType(resources.GetObject("btnReplaceLamp.Image"), System.Drawing.Image)
        Me.btnReplaceLamp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReplaceLamp.Location = New System.Drawing.Point(11, 17)
        Me.btnReplaceLamp.Name = "btnReplaceLamp"
        Me.btnReplaceLamp.Size = New System.Drawing.Size(176, 34)
        Me.btnReplaceLamp.TabIndex = 0
        Me.btnReplaceLamp.Text = "&Replace Lamp"
        '
        'btnOptimiseAllTurret
        '
        Me.btnOptimiseAllTurret.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOptimiseAllTurret.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOptimiseAllTurret.Image = CType(resources.GetObject("btnOptimiseAllTurret.Image"), System.Drawing.Image)
        Me.btnOptimiseAllTurret.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOptimiseAllTurret.Location = New System.Drawing.Point(215, 62)
        Me.btnOptimiseAllTurret.Name = "btnOptimiseAllTurret"
        Me.btnOptimiseAllTurret.Size = New System.Drawing.Size(176, 34)
        Me.btnOptimiseAllTurret.TabIndex = 3
        Me.btnOptimiseAllTurret.Text = "Optimise &All Turret"
        '
        'btnHelp
        '
        Me.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHelp.Image = CType(resources.GetObject("btnHelp.Image"), System.Drawing.Image)
        Me.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHelp.Location = New System.Drawing.Point(328, 144)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(86, 34)
        Me.btnHelp.TabIndex = 11
        Me.btnHelp.Text = "Help"
        Me.btnHelp.Visible = False
        '
        'btnOk
        '
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Image = CType(resources.GetObject("btnOk.Image"), System.Drawing.Image)
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(200, 126)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(86, 34)
        Me.btnOk.TabIndex = 1
        Me.btnOk.Text = "&OK"
        '
        'CustomPanelTop
        '
        Me.CustomPanelTop.BackColor = System.Drawing.Color.Transparent
        Me.CustomPanelTop.BackColor2 = System.Drawing.Color.Transparent
        Me.CustomPanelTop.Controls.Add(Me.gbMeasurementCond)
        Me.CustomPanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.CustomPanelTop.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanelTop.Name = "CustomPanelTop"
        Me.CustomPanelTop.Size = New System.Drawing.Size(424, 72)
        Me.CustomPanelTop.TabIndex = 0
        '
        'gbMeasurementCond
        '
        Me.gbMeasurementCond.Controls.Add(Me.txtTurretNum)
        Me.gbMeasurementCond.Controls.Add(Me.cmbElementName)
        Me.gbMeasurementCond.Controls.Add(Me.Label1)
        Me.gbMeasurementCond.Controls.Add(Me.lblTurretNum)
        Me.gbMeasurementCond.Controls.Add(Me.lblElementName)
        Me.gbMeasurementCond.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMeasurementCond.Location = New System.Drawing.Point(10, 8)
        Me.gbMeasurementCond.Name = "gbMeasurementCond"
        Me.gbMeasurementCond.Size = New System.Drawing.Size(406, 56)
        Me.gbMeasurementCond.TabIndex = 0
        Me.gbMeasurementCond.TabStop = False
        Me.gbMeasurementCond.Text = "Measurement Conditions"
        '
        'txtTurretNum
        '
        Me.txtTurretNum.DigitsAfterDecimalPoint = 0
        Me.txtTurretNum.ErrorColor = System.Drawing.Color.Empty
        Me.txtTurretNum.ErrorMessage = ""
        Me.txtTurretNum.Location = New System.Drawing.Point(295, 24)
        Me.txtTurretNum.MaximumRange = 6
        Me.txtTurretNum.MaxLength = 1
        Me.txtTurretNum.MinimumRange = 1
        Me.txtTurretNum.Name = "txtTurretNum"
        Me.txtTurretNum.RangeValidation = True
        Me.txtTurretNum.Size = New System.Drawing.Size(40, 22)
        Me.txtTurretNum.TabIndex = 1
        Me.txtTurretNum.Text = ""
        Me.txtTurretNum.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly
        '
        'cmbElementName
        '
        Me.cmbElementName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbElementName.Location = New System.Drawing.Point(128, 24)
        Me.cmbElementName.Name = "cmbElementName"
        Me.cmbElementName.Size = New System.Drawing.Size(80, 24)
        Me.cmbElementName.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Enabled = False
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(339, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 18)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "1..6 only"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTurretNum
        '
        Me.lblTurretNum.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurretNum.Location = New System.Drawing.Point(223, 27)
        Me.lblTurretNum.Name = "lblTurretNum"
        Me.lblTurretNum.Size = New System.Drawing.Size(64, 18)
        Me.lblTurretNum.TabIndex = 13
        Me.lblTurretNum.Text = "Turret No."
        Me.lblTurretNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblElementName
        '
        Me.lblElementName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblElementName.Location = New System.Drawing.Point(14, 27)
        Me.lblElementName.Name = "lblElementName"
        Me.lblElementName.Size = New System.Drawing.Size(96, 18)
        Me.lblElementName.TabIndex = 11
        Me.lblElementName.Text = "Element Name"
        Me.lblElementName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Office2003Header1
        '
        Me.Office2003Header1.BackColor = System.Drawing.SystemColors.Control
        Me.Office2003Header1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Office2003Header1.Location = New System.Drawing.Point(0, 0)
        Me.Office2003Header1.Name = "Office2003Header1"
        Me.Office2003Header1.Size = New System.Drawing.Size(424, 22)
        Me.Office2003Header1.TabIndex = 13
        Me.Office2003Header1.TitleFont = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Office2003Header1.TitleText = "Instrument Parameters"
        '
        'frmInstrumentParameters
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(424, 389)
        Me.ControlBox = False
        Me.Controls.Add(Me.CustomPanelMain)
        Me.Controls.Add(Me.Office2003Header1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInstrumentParameters"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Method "
        Me.CustomPanelMain.ResumeLayout(False)
        Me.CustomPanelRightBottom.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.CustomPanelBottom.ResumeLayout(False)
        Me.CustomPanelBottomTop.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.CustomPanelTop.ResumeLayout(False)
        Me.gbMeasurementCond.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private Sub subShowMaxLamps()
        '=====================================================================
        ' Procedure Name        : subShowMaxLamps
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To show the Max. lamp No. on screen 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale 
        ' Created               : 23.02.08
        ' Revisions             : 
        '=====================================================================
        Try
            If Not gobjClsAAS203 Is Nothing Then
                Me.Label1.Text = "1.." & gobjClsAAS203.funcGetMaxLamp & " only"
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

#Region " Public Constants, Structures, Events.. "

    Public Event MethodInstrumentSettingsChanged()
    ''this is a public event which can called from anywhere of software when instrument setting is changed

#End Region

#Region " Private Class Member Variables "
    ''this are the temp variable which are used for storing a value which user entered on screen 

    Private mblnWarmupLamp As Boolean
    Private mintWarmUp_Lamp As Integer
    Private mintTurretNumber As Integer
    Private mblnIsValid As Boolean
    Private mobjInstrumentParameters As clsInstrumentParameters

    WithEvents mobjfrmLampPlacements203 As frmLampPlacements
    WithEvents mobjfrmLampPlacements201 As frmLampPlacements_201
    ''this are the object of other class which have to be used in this class

    Private mintOpenMethodMode As EnumMethodMode
    Private mintWavelengthID As Integer
    Private mblnEnableElement As Boolean
    'Private mobjInstrumentParaCollection As clsInstrumentParametersCollection
    'Private mobjInstrumentParameters As clsInstrumentParameters

#End Region

#Region " Private Properties "

    ''this are the some property which can be set and used as a cond

    Private Property OpenMethodMode() As EnumMethodMode
        Get
            Return mintOpenMethodMode
        End Get
        Set(ByVal Value As EnumMethodMode)
            mintOpenMethodMode = Value
        End Set
    End Property

    Private Property SelectedWavelengthID() As Integer
        Get
            Return mintWavelengthID
        End Get
        Set(ByVal Value As Integer)
            Dim objRow As DataRow
            Dim dblSlit As Double
            Dim intCount As Integer

            Try
                mintWavelengthID = Value

                objRow = gobjClsAAS203.funcGetCookBookDetailRow(mintWavelengthID)

                If Not IsNothing(objRow) Then
                    dblSlit = objRow.Item(ConstColumnSlit)
                    txtSlitWidth.Text = dblSlit
                End If

                If Not IsNothing(gobjNewMethod) Then
                    gobjNewMethod.InstrumentCondition.SelectedWavelengthID = mintWavelengthID
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
        End Set
    End Property

#End Region

#Region "Public Properties"

#End Region

#Region " Private Constants "

    ''this are the private constant which we used insted of direct value

    Private Const ConstColumnTurretNumber = "TurretNumber"
    Private Const Const_TableElement = "Elements"
    Private Const ConstIntMinTurretLimit = 1
    Private Const ConstIntMaxTurretLimit = 6
    Private Const ConstIntMinCurrentLimit = 0.1
    Private Const ConstIntMaxCurrentLimit = 25.99
    Private Const ConstIntMinSlitWidthLimit = 0.1
    Private Const ConstIntMaxSlitWidthLimit = 2.0
    Private Const ConstFormLoad = "-Method-InstrumentConditions"
    Private Const ConstParentFormLoad = "-Method"

#End Region

#Region " Form Load Event Function "

    Private Sub frmInstrumentParameters_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmInstrumentParameters_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To initialize the form
        ' Description           : this is called when form is loaded
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 07.10.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is called when form is loaded
        ''this is used To initialize the form
        Dim objWait As New CWaitCursor
        Dim intObjCount As Integer
        Dim objDtElements As DataTable
        ''this is a object of datastructure
        Dim objRow As DataRow
        Dim objDvElementsList As DataView
        Dim intRowCount, intRowCount1 As Integer

        Try
            'Original Code is in 'Else' part
            'Code in 'If' part is done by Saurbah
            ''EnumApplicationMode is a structure which contains some mode info
            If gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then   'Added by Saurabh
                ''by gstructSettings.ExeToRun we can decide which EXE is to be run
                'Added by Saurabh---24.06.07
                OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode
                Select Case gstructSettings.AppMode
                    ''case for app mode
                    ''validate the status form as application mode
                    Case EnumAppMode.FullVersion_201
                        btnOptimiseAllTurret.Visible = False
                        btnOptimiseTurret.Visible = False
                    Case Else
                        btnOptimiseAllTurret.Visible = True
                        btnOptimiseTurret.Visible = True
                End Select
                cmbElementName.Enabled = True
                txtTurretNum.Enabled = True
                'Added by Saurabh---24.06.07

                'gobjService.ShowProgressBar(ConstFormLoad)

                Call subSetTextValidation()
                ''this set some validation of each textbox on the screen
                ''here you can find all the validation limits

                Call funcLoadLamps()
                ''this function is called for load all the lamp.
                If OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode Then

                    ''there is two method mode either open new or edit.

                    If Not IsNothing(gobjNewMethod) Then
                        ''if gobjNewMethod is not null then
                        If gobjNewMethod.InstrumentCondition.ElementID = 0 Then
                            gobjNewMethod.InstrumentCondition = New clsInstrumentParameters
                            'cmbElementName.Enabled = True
                            If cmbElementName.Items.Count > 0 Then
                                If cmbElementName.SelectedIndex = 0 Then
                                    cmbElementName_SelectedIndexChanged(sender, e)
                                    ''parfrom event for combobox changed
                                Else
                                    cmbElementName.SelectedIndex = 0
                                End If
                            End If
                        Else
                            'cmbElementName.Enabled = False
                            'txtTurretNum.ReadOnly = True
                            If cmbElementName.SelectedValue = gobjNewMethod.InstrumentCondition.ElementID Then
                                Call cmbElementName_SelectedIndexChanged(cmbElementName, EventArgs.Empty)
                                ''call combo box event
                            Else
                                cmbElementName.SelectedValue = gobjNewMethod.InstrumentCondition.ElementID
                            End If
                        End If
                    End If

                Else
                    'cmbElementName.Enabled = False
                    'txtTurretNum.ReadOnly = True
                    If Not IsNothing(gobjNewMethod) Then
                        If cmbElementName.SelectedValue = gobjNewMethod.InstrumentCondition.ElementID Then
                            Call cmbElementName_SelectedIndexChanged(cmbElementName, EventArgs.Empty)
                        Else
                            cmbElementName.SelectedValue = gobjNewMethod.InstrumentCondition.ElementID
                        End If
                    Else
                        Call cmbElementName_SelectedIndexChanged(cmbElementName, EventArgs.Empty)
                    End If
                End If

                mintWarmUp_Lamp = Get_Warmup_Lamp_Pos()
                ''this will return gobjInst.Lamp_Warm 
                ''which lamp has to be warmup
                mblnWarmupLamp = False

            Else
                '---load gobjinst elements should load
                '---if new method then on load of this form it should show first element
                '---if new method and if elementID is already set then load the selected elementID data
                '---if edit mode then on form load load selected instrument settings

                Call gobjMain.ShowProgressBar(gstrTitleInstrumentType & ConstFormLoad)
                ''shows some instrument info on progress bar

                '---Added by Mangesh on 10-Apr-2007 for AAS202 Changes


                Select Case gstructSettings.AppMode
                    ''case depanding on appmode
                    Case EnumAppMode.FullVersion_201
                        btnOptimiseAllTurret.Visible = False
                        btnOptimiseTurret.Visible = False
                    Case Else
                        btnOptimiseAllTurret.Visible = True
                        btnOptimiseTurret.Visible = True
                End Select


                If Not IsNothing(gobjNewMethod) Then
                    If gobjNewMethod.OperationMode = EnumOperationMode.MODE_AA Then
                        ''set the title as par operation mode
                        Office2003Header1.TitleText = "Quantitative Instrument Conditions - AA Mode"
                    Else
                        If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                            If (gobjCommProtocol.SRLamp) Then
                                'SetWindowText(hwnd,"Quantitative Instrument Conditions-AA BGC (SR Lamp) MODE");
                                Office2003Header1.TitleText = "Quantitative Instrument Conditions-AA BGC (SR Lamp) MODE"
                            Else
                                'SetWindowText(hwnd,"Quantitative Instrument Conditions-AA BGC (D2 Lamp) MODE");
                                Office2003Header1.TitleText = "Quantitative Instrument Conditions-AA BGC (D2 Lamp) MODE"
                            End If
                        Else
                            Office2003Header1.TitleText = "Quantitative Instrument Conditions - AA BGC Mode"
                        End If
                    End If
                End If

                '---number validator settings here
                Call subSetTextValidation()
                ''for setting text validation
                Call funcLoadLamps()
                ''for loading all lamp
                If OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode Then
                    ''if we creating a new method then
                    If Not IsNothing(gobjNewMethod) Then
                        If gobjNewMethod.InstrumentCondition.ElementID = 0 Then
                            gobjNewMethod.InstrumentCondition = New clsInstrumentParameters
                            cmbElementName.Enabled = True
                            If cmbElementName.Items.Count > 0 Then
                                If cmbElementName.SelectedIndex = 0 Then
                                    cmbElementName_SelectedIndexChanged(sender, e)
                                Else
                                    cmbElementName.SelectedIndex = 0
                                End If
                            End If
                        Else
                            cmbElementName.Enabled = False
                            txtTurretNum.ReadOnly = True
                            If cmbElementName.SelectedValue = gobjNewMethod.InstrumentCondition.ElementID Then
                                Call cmbElementName_SelectedIndexChanged(cmbElementName, EventArgs.Empty)
                            Else
                                cmbElementName.SelectedValue = gobjNewMethod.InstrumentCondition.ElementID
                            End If
                        End If
                    End If

                Else
                    cmbElementName.Enabled = False
                    txtTurretNum.Enabled = False            'Saurabh ReadOnly to Enabled
                    If Not IsNothing(gobjNewMethod) Then
                        If cmbElementName.SelectedValue = gobjNewMethod.InstrumentCondition.ElementID Then
                            Call cmbElementName_SelectedIndexChanged(cmbElementName, EventArgs.Empty)
                        Else
                            cmbElementName.SelectedValue = gobjNewMethod.InstrumentCondition.ElementID
                        End If
                    Else
                        Call cmbElementName_SelectedIndexChanged(cmbElementName, EventArgs.Empty)
                    End If
                End If
                If (gstructSettings.AppMode = EnumAppMode.FullVersion_201) Then
                    lblTurretNum.Text = "Lamp No."
                End If
                mintWarmUp_Lamp = Get_Warmup_Lamp_Pos()
                ''this will Return gobjInst.Lamp_Warm
                mblnWarmupLamp = False

            End If

            'Saurabh
            Call AddHandlers()
            ''add all the handler to control
            Call Check_OK_Button()
            ''this will call OK button click event 
            If cmbElementName.Text = "" Then
                cmbElementName.Enabled = True
                '    btnOk.Enabled = False
            End If
            btnReplaceLamp.Focus()
            'Saurabh
            'Saurabh 10.07.07 To bring status form in front
            If Not IsInIQOQPQ Then
                gobjfrmStatus.Show()
            End If
            'Saurabh

            'added by deepak on 24.07.07
            Dim strWvRange As String
            strWvRange = gstructSettings.WavelengthRange.WvLowerBound & ".." & gstructSettings.WavelengthRange.WvUpperBound & "nm"
            Label3.Text = strWvRange

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
            'gobjMain.HideProgressBar()     'Sauarbh
            '---------------------------------------------------------
        End Try
    End Sub

#End Region

#Region " Private Functions"

    Private Sub AddHandlers()
        '=====================================================================
        ' Procedure Name        : AddHandlers
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To add the event handlers
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 07.10.06
        ' Revisions             : praveen
        '=====================================================================
        Try
            AddHandler btnCancel.Click, AddressOf btnCancel_Click
            ''for eg this will add a event of cancel button
            ''means if we click on cancel button then btnCancel_Click will called

            AddHandler btnReplaceLamp.Click, AddressOf btnReplaceLamp_Click
            AddHandler btnWarmupLamp.Click, AddressOf btnWarmupLamp_Click
            AddHandler btnOk.Click, AddressOf btnOk_Click
            AddHandler txtTurretNum.ValidationStatus, AddressOf txtTurretNum_ValidationStatus
            AddHandler txtLampCurrent.ValidationStatus, AddressOf txtCurrent_ValidationStatus
            AddHandler txtSlitWidth.ValidationStatus, AddressOf txtSlitWidth_ValidationStatus
            AddHandler btnOptimiseTurret.Click, AddressOf btnOptimiseTurret_Click
            AddHandler btnOptimiseAllTurret.Click, AddressOf btnOptimiseAllTurret_Click
            AddHandler txtTurretNum.TextChanged, AddressOf txtTurretNum_TextChanged
            AddHandler cmbWV.SelectedIndexChanged, AddressOf cmbWV_SelectedIndexChanged

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

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnCancel_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To close the form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 07.10.06
        ' Revisions             : praveen
        '=====================================================================

        'note:
        ''this is called when user close the form.
        Try
            gobjchkActiveMethod.CancelMethod = True
            'gobjchkActiveMethod.fillInstruments = False
            'Me.Close()
            funcOK(False)
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

    Private Sub btnReplaceLamp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnReplaceLamp_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To replace the lamp
        ' Description           : this is call when user click on replace lamp button
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 07.10.06
        ' Revisions             : 
        '=====================================================================
        ''below are the variable declaration
        ''note:
        ''this is call when user click on replace lamp button
        ''this is used To replace the lamp


        Dim objWait As New CWaitCursor
        Dim intObjCount As Integer
        Dim objDtElements As DataTable
        ''onject ot data structure where we have to tempe store data.
        Dim objRow As DataRow
        Dim objDv As DataView
        Dim dblCurrent As Double
        Dim intLastTurretPositionInLampPlacement As Integer
        Dim intCount As Integer
        Dim Tmp_LampPos As Integer = 0
        Dim Tmp_LampCurr As Double = 0.0
        Try
            If Not gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then
                ''case true for service utility
                gobjMain.mobjController.Cancel()
                gobjCommProtocol.mobjCommdll.subTime_Delay(500)   '10.12.07
                Application.DoEvents()
            End If

            If (gstructSettings.Enable21CFR = True) Then
                ''this is for 21 cfr 
                If Not funcCheckActivityAuthentication(enumActivityAuthentication.Lamp_Placements, gstructUserDetails.Access) Then
                    ''this will check whatever current user has a permision to replace a lamp or Not.
                    Exit Sub
                End If
                gfuncInsertActivityLog(EnumModules.Lamp_Placements, "Lamp Placement Accessed")
            End If

            objDtElements = New DataTable(Const_TableElement)

            If Not Trim(txtTurretNum.Text) = "" Then
                mintTurretNumber = CInt(txtTurretNum.Text)
            End If

            If Not Trim(txtLampCurrent.Text) = "" And Not Trim(txtTurretNum.Text) = "" Then
                Call gobjCommProtocol.funcSet_Lamp(False, CDbl(txtLampCurrent.Text), CInt(txtTurretNum.Text))
                'Description            :   To set current to the lamp
                'Parameters             :   flag = if true set current else not set current
                '                           dblLampCurrent = current to be set to lamp
                '                           intLampPos = lamp position to which current to be set
                '
                ''this is a communication function for setting a given lamp at given position 
                'Else
                'Call gobjCommProtocol.funcSet_Lamp(False, 0, 0)
            End If

            Select Case gstructSettings.AppMode
                Case EnumAppMode.FullVersion_201
                    ''this is a case for 201
                    mobjfrmLampPlacements201 = New frmLampPlacements_201(mintTurretNumber, OpenMethodMode)

                    If mobjfrmLampPlacements201.ShowDialog() = DialogResult.OK Then

                        'btnOk.Enabled = True
                        Application.DoEvents()

                        If Not IsNothing(mobjfrmLampPlacements201.mobjInstrumentParameters) Then
                            intLastTurretPositionInLampPlacement = mobjfrmLampPlacements201.mobjInstrumentParameters.TurretNumber
                            dblCurrent = mobjfrmLampPlacements201.mobjInstrumentParameters.LampCurrent

                            If gobjCommProtocol.funcSet_Lamp(True, dblCurrent, intLastTurretPositionInLampPlacement) Then
                                'Description            :   To set current to the lamp
                                'Parameters             :   flag = if true set current else not set current
                                '                           dblLampCurrent = current to be set to lamp
                                '                           intLampPos = lamp position to which current to be set
                                '
                                Call gobjCommProtocol.funcOptimise_Turret_Position(dblCurrent, intLastTurretPositionInLampPlacement)
                                'Description            :   To optimise Turret position 
                                'Parameters             :   dblLampCurrent = current to be set to lamp
                                '                           intLampPos = lamp position to which current to be set

                                Call Application.DoEvents()
                                ''allow application to perfrom its panding task


                                '---Added By Mangesh on 10-Apr-2007 for 202 Changes

                                'if(MessageBox(hwnd,"Do You Want Manual Lamp Optimisation","Lamp Optimisation",MB_YESNO)==IDYES)
                                '		  AbsorbanceScan(hwnd);
                                If gobjMessageAdapter.ShowMessage(constManualLampOptimisation) Then
                                    Call Application.DoEvents()
                                    Call gobjClsAAS203.AbsorbanceScan()
                                    ' Purpose               : To show the window for Manual Optimization
                                    '                         i.e. Continuous TimeScan Mode
                                End If
                                Call Application.DoEvents()

                            End If

                        End If
                    Else
                        checkLampPosition() 'Added By Pakaj on 27 05 07
                        ''checking for lamp position.
                        Exit Sub
                    End If

                Case Else
                    mobjfrmLampPlacements203 = New frmLampPlacements(mintTurretNumber, OpenMethodMode)
                    ''this is a case for 203 
                    Tmp_LampPos = gobjInst.Lamp_Position
                    Tmp_LampCurr = gobjInst.Current
                    If mobjfrmLampPlacements203.ShowDialog() = DialogResult.OK Then

                        'btnOk.Enabled = True        'Saurabh
                        Application.DoEvents()
                        ''this means, now software will do its
                        If Not IsNothing(mobjfrmLampPlacements203.mobjInstrumentParameters) Then
                            intLastTurretPositionInLampPlacement = mobjfrmLampPlacements203.mobjInstrumentParameters.TurretNumber
                            dblCurrent = mobjfrmLampPlacements203.mobjInstrumentParameters.LampCurrent
                            If gobjCommProtocol.funcSet_Lamp(True, dblCurrent, intLastTurretPositionInLampPlacement) Then
                                Call gobjCommProtocol.funcOptimise_Turret_Position(dblCurrent, intLastTurretPositionInLampPlacement)
                                ''To optimise Turret position
                            End If

                        End If
                    Else
                        'checkLampPosition() 'Added By Pakaj on 27 05 07
                        '//----- Added by Sachin Dokhale
                        'gobjInst.Lamp.LampParametersCollection.item(0).LampOptimizePosition()
                        If gobjCommProtocol.funcSet_Lamp(True, Tmp_LampCurr, Tmp_LampPos) Then
                            ''To set current to the lamp
                            'Parameters             :   flag = if true set current else not set current
                            '                           dblLampCurrent = current to be set to lamp
                            '                           intLampPos = lamp position to which current to be set
                        End If
                        Exit Sub
                        '//-----
                    End If
            End Select

            Call funcLoadLamps()
            ''Returns               : returns total number of lamps connected
            ' 'Purpose               : To load all lamps 

            '-----Saruabh---24.06.07
            If Not IsNothing(gobjNewMethod) Then
                calElement()

            End If
            '-----Saruabh---24.06.07

            Call cmbElementName_SelectedIndexChanged(sender, e)
            ''this is call if we change the element name
            'checkLampPosition() 'Added By Pakaj on 27 05 07

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
            If Not gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then
                If gobjMain.mobjController.IsThreadRunning = False Then
                    gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)
                    Application.DoEvents()
                    gobjMain.mobjController.Start(gobjclsBgFlameStatus)
                End If
                Application.DoEvents()
            End If
            Call Check_OK_Button()
            ''this is called when we click on ok button
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub checkLampPosition()

        ''not in used .

        'Dim blLamp As Boolean = False
        'Dim intLampPosition As Integer
        'For intLampPosition = 0 To 6
        '    If (gobjInst.Lamp.LampParametersCollection.item(intLampPosition).ElementName = cmbElementName.Text) Then
        '        blLamp = True
        '        Exit For
        '    End If
        'Next
        'If (blLamp = True) Then
        '    If intLampPosition + 1 <> CInt(txtTurretNum.Text) Then
        '        txtTurretNum.Text = intLampPosition + 1
        '    End If
        'Else
        '    cmbElementName.Enabled = True
        'End If
    End Sub

    Private Sub btnWarmupLamp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnWarmupLamp_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To select and set the WarmUp lamp.
        ' Description           : Change the Button Caption and GroupBox 
        '                         captions according to mblnWarmupLamp
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : 
        ' Created               : ??
        ' Revisions             : 2
        ' Revisions By          : Mangesh Shardul
        '=====================================================================
        Dim intElementID As Integer
        Dim dblCurrent As Double
        Dim intTurret As Integer
        Dim objWait As New CWaitCursor

        Try
            'Added by Saurabh-To stop the Thread---
            If Not gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then
                gobjMain.mobjController.Cancel()
                ''stopthe thread if any running
                gobjCommProtocol.mobjCommdll.subTime_Delay(500)   '10.12.07
                Application.DoEvents()
            End If
            '--------------------------------------
            ''get a current value from the screen
            intElementID = CInt(cmbElementName.SelectedValue)
            intTurret = CInt(txtTurretNum.Text)
            dblCurrent = CDbl(txtLampCurrent.Text)

            '---Changed and Added By Mangesh 
            mblnWarmupLamp = Not mblnWarmupLamp
            btnOk.Enabled = Not mblnWarmupLamp 'Added by Pankaj on 26 Aug 07

            If mblnWarmupLamp Then
                ''do some onscreen validation for warmup
                ''like text change
                gbMeasurementCond.Text = "Warm up Conditions"
                btnWarmupLamp.Text = "Measurement Lamp"
                cmbElementName.Enabled = True

                mintTurretNumber = CInt(txtTurretNum.Text)
                ''get a turret num invarible
                '---Set Previously selected lamp as Measurement Lamp Number
                If (mintTurretNumber >= 1 And mintTurretNumber <= gobjClsAAS203.funcGetMaxLamp()) Then
                    ''check for avaliable turrt with lamp
                    '---Changed and Added by Mangesh S.
                    '---For DisAllowing user to select same Lamp Element Lamp as 
                    '---both Measurement Lamp and Warm Lamp.
                    If mintTurretNumber = mintWarmUp_Lamp Then
                        gobjMessageAdapter.ShowMessage(constLampInUse)
                        Application.DoEvents()
                        mintTurretNumber = -1
                        Exit Sub
                    Else
                        gobjInst.Lamp_Position = mintTurretNumber
                        '---Glow selected element Measurement lamp
                        Call gobjCommProtocol.funcSet_HCL_Cur(dblCurrent, mintTurretNumber)
                        ''for setting lamp parameter as par parameter passed
                        If Not mintWarmUp_Lamp = -1 Then txtTurretNum.Text = mintWarmUp_Lamp
                    End If
                    '---Changed and Added by Mangesh S.
                End If

            Else
                gbMeasurementCond.Text = "Measurement Conditions"
                btnWarmupLamp.Text = "Warm up Lamp"
                cmbElementName.Enabled = False '07.12.07

                mintWarmUp_Lamp = CInt(txtTurretNum.Text)
                ''get a turrert num.

                '---Set Previously selected lamp as WarmUp Lamp Number
                If (mintWarmUp_Lamp >= 1 And mintWarmUp_Lamp <= gobjClsAAS203.funcGetMaxLamp()) Then
                    '---Changed and Added by Mangesh S.
                    '---For DisAllowing user to select same Lamp Element Lamp as 
                    '---both Measurement Lamp and Warm Lamp.
                    If mintTurretNumber = mintWarmUp_Lamp Then
                        gobjMessageAdapter.ShowMessage(constLampAlreadyInUse)

                        Application.DoEvents()
                        mintWarmUp_Lamp = -1
                        Exit Sub
                    Else
                        gobjInst.Lamp_Warm = mintWarmUp_Lamp
                        '---Glow selected element WarmUp lamp
                        Call gobjCommProtocol.funcSet_HCL_Cur(dblCurrent, mintWarmUp_Lamp)
                        If Not mintTurretNumber = -1 Then txtTurretNum.Text = mintTurretNumber
                    End If
                    '---Changed and Added by Mangesh S.
                End If

                If (mblnIsValid) Then
                    ''disable a control.
                    cmbElementName.Enabled = False
                    txtTurretNum.Enabled = False
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
            objWait.Dispose()
            'Added by Saurabh-To start the Thread---
            If Not gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then
                If gobjMain.mobjController.IsThreadRunning = False Then
                    gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)
                    Application.DoEvents()
                    gobjMain.mobjController.Start(gobjclsBgFlameStatus)
                End If
                Application.DoEvents()
            End If
            '---------------------------------------
            Call Check_OK_Button()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub cmbElementName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : cmbElementName_SelectedIndexChanged
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To display the element information according the selected element
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 07.10.06
        ' Revisions             : 
        '=====================================================================
        Dim intObjCount As Integer
        Dim intElementID As Integer

        ''Note:-
        ''this is called when user changed the element name 
        ''depanding on element name get a data from database 
        ''like lamp current ect...
        ''and display it on screen




        Try
            intElementID = cmbElementName.SelectedValue()

            '---Changed and Added by Mangesh S.
            '---For DisAllowing user to select same Lamp Element Lamp as 
            '---both Measurement Lamp and Warm Lamp.
            If mblnWarmupLamp Then
                If mintTurretNumber = mintWarmUp_Lamp Then
                    gobjMessageAdapter.ShowMessage(constLampAlreadyInUse)
                    ''prompt a message that lamp is already in use
                    Application.DoEvents()
                    ''allow application to perfrom its panding work.
                    Exit Sub
                End If
            End If
            '---Changed and Added by Mangesh S.
            RemoveHandler txtTurretNum.TextChanged, AddressOf txtTurretNum_TextChanged
            ''remove a event 
            If Not intElementID = 0 Then
                If Not IsNothing(gobjNewMethod) Then
                    If gobjNewMethod.InstrumentCondition.ElementID = 0 Then
                        For intObjCount = 0 To gobjInst.Lamp.LampParametersCollection.Count - 1
                            Dim intSearchEleId As Integer
                            intSearchEleId = gobjDataAccess.GetCookBookElementID(gobjInst.Lamp.LampParametersCollection.item(intObjCount).AtomicNumber)
                            If intSearchEleId = intElementID Then
                                If funcShowElementInfo(gobjInst.Lamp.LampParametersCollection.item(intObjCount), intObjCount + 1) = True Then
                                    Exit For
                                End If
                            End If
                        Next
                    Else
                        'gobjNewMethod.InstrumentCondition.ElementID = intElementID
                        'Call funcLoadMethodElement(gobjNewMethod.InstrumentCondition.ElementID)
                        Call funcLoadMethodElement(intElementID)
                        ''for loading a method element as per elementID
                    End If
                Else
                    For intObjCount = 0 To gobjInst.Lamp.LampParametersCollection.Count - 1
                        Dim intSearchEleId As Integer
                        intSearchEleId = gobjDataAccess.GetCookBookElementID(gobjInst.Lamp.LampParametersCollection.item(intObjCount).AtomicNumber)
                        If intSearchEleId = intElementID Then
                            If funcShowElementInfo(gobjInst.Lamp.LampParametersCollection.item(intObjCount), intObjCount + 1) = True Then
                                'for showing a element info.
                                Exit For
                            End If
                        End If
                    Next
                End If

            Else
                RemoveHandler cmbWV.SelectedIndexChanged, AddressOf cmbWV_SelectedIndexChanged
                txtTurretNum.Text = ""
                txtLampCurrent.Text = ""
                cmbWV.DataSource = Nothing
                cmbWV.Text = ""
                txtSlitWidth.Text = ""
                AddHandler txtTurretNum.TextChanged, AddressOf txtTurretNum_TextChanged
                'AddHandler cmbWV.SelectedIndexChanged, AddressOf cmbWV_SelectedIndexChanged
            End If

            AddHandler cmbWV.SelectedIndexChanged, AddressOf cmbWV_SelectedIndexChanged
            'AddHandler txtTurretNum.TextChanged, AddressOf txtTurretNum_TextChanged

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
            Call Check_OK_Button()
            '---------------------------------------------------------
        End Try
    End Sub

    'Private Function funcShowElementInfo(ByVal objElement As clsInstrumentParameters) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        : funcShowElementInfo
    '    ' Parameters Passed     : Object of clsInstrumentParameters
    '    ' Returns               : True or False
    '    ' Purpose               : To display the element information 
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Deepak Bhati
    '    ' Created               : 07.10.06
    '    ' Revisions             : 
    '    '=====================================================================
    '    Dim intCount As Integer
    '    Dim objDtWavelength As DataTable
    '    Dim intSensitiveWvId As Integer

    '    Try
    '        If Not IsNothing(objElement) Then
    '            txtLampCurrent.Text = FormatNumber(objElement.LampCurrent, 1)
    '            txtSlitWidth.Text = FormatNumber(objElement.SlitWidth, 1)
    '            txtTurretNum.Text = objElement.TurretNumber

    '            RemoveHandler cmbWV.SelectedIndexChanged, AddressOf cmbWV_SelectedIndexChanged

    '            objDtWavelength = objElement.Wavelength.Copy()

    '            cmbWV.DataSource = objDtWavelength
    '            cmbWV.DisplayMember = objElement.Wavelength.Columns(ConstColumnWV).ColumnName
    '            cmbWV.ValueMember = objElement.Wavelength.Columns(ConstColumnAADetailsID).ColumnName
    '            cmbWV.Refresh()

    '            If cmbWV.Items.Count > 0 Then
    '                If Not objElement.SelectedWavelengthID = 0 Then
    '                    SelectedWavelengthID = objElement.SelectedWavelengthID
    '                    txtSlitWidth.Text = objElement.SlitWidth
    '                    cmbWV.SelectedValue = SelectedWavelengthID
    '                Else
    '                    intSensitiveWvId = gobjClsAAS203.funcGetSensitiveWavelengthID(objDtWavelength)
    '                    If intSensitiveWvId <> 0 Then
    '                        cmbWV.SelectedValue = intSensitiveWvId
    '                        SelectedWavelengthID = intSensitiveWvId
    '                        txtSlitWidth.Text = objElement.SlitWidth
    '                    End If
    '                End If
    '            End If

    '            AddHandler cmbWV.SelectedIndexChanged, AddressOf cmbWV_SelectedIndexChanged

    '        End If

    '        Return True

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        Return False
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

    Private Function funcShowElementInfo(ByVal objElement As AAS203Library.Instrument.ClsLampParameters, ByVal intTurretNumber As Integer) As Boolean
        '=====================================================================
        ' Procedure Name        : funcShowElementInfo
        ' Parameters Passed     : Object of Instrument.ClsLampParameters
        ' Returns               : True or False
        ' Purpose               : To display the element information 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 28-Mar-2007
        ' Revisions             : 1
        '=====================================================================
        ''note:
        ''this is used to show some element info on screen
        ''here we get a data from database

        Dim intCount As Integer
        Dim objDtWavelength As DataTable
        Dim intSensitiveWvId As Integer
        Dim intElementID As Integer


        Try
            If Not IsNothing(objElement) Then
                intElementID = gobjDataAccess.GetCookBookElementID(objElement.AtomicNumber)
                ''get a element id from database as par atomic num
                txtLampCurrent.Text = FormatNumber(objElement.Current, 1)
                txtSlitWidth.Text = FormatNumber(objElement.SlitWidth, 1)
                ''show some info on screen
                RemoveHandler txtTurretNum.TextChanged, AddressOf txtTurretNum_TextChanged
                txtTurretNum.Text = intTurretNumber
                AddHandler txtTurretNum.TextChanged, AddressOf txtTurretNum_TextChanged

                RemoveHandler cmbWV.SelectedIndexChanged, AddressOf cmbWV_SelectedIndexChanged

                objDtWavelength = gobjDataAccess.GetElementWavelengths(intElementID)

                If Not IsNothing(objDtWavelength) Then
                    ''bind the control from data structure
                    cmbWV.DataSource = objDtWavelength
                    cmbWV.DisplayMember = ConstColumnWV
                    cmbWV.ValueMember = ConstColumnAADetailsID
                Else
                    cmbWV.DataSource = Nothing
                End If
                cmbWV.Refresh()

                If cmbWV.Items.Count > 0 Then
                    If OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode Then
                        'SelectedWavelengthID = gobjNewMethod.InstrumentCondition.SelectedWavelengthID
                        'txtSlitWidth.Text = objElement.SlitWidth
                        'cmbWV.SelectedValue = SelectedWavelengthID
                    Else
                        intSensitiveWvId = gobjClsAAS203.funcGetSensitiveWavelengthID(objDtWavelength)
                        ''objDtWavelength is a object to wavelength data structure
                        If intSensitiveWvId <> 0 Then
                            cmbWV.SelectedValue = intSensitiveWvId
                            SelectedWavelengthID = intSensitiveWvId
                            txtSlitWidth.Text = objElement.SlitWidth
                        End If
                    End If
                End If
                AddHandler cmbWV.SelectedIndexChanged, AddressOf cmbWV_SelectedIndexChanged
            End If

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

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnOk_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To set the instrument information to the object
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 07.10.06
        ' Revisions             : 
        '=====================================================================

        ''Note:
        ''this is called when user click on ok button
        ''this is set all onscreen info to a data structure

        'i= (WORD) SendMessage(GetDlgItem(hwnd, IDC_CBWV), CB_GETCURSEL, 0, 0L);
        'SendMessage(GetDlgItem(hwnd, IDC_CBWV), CB_GETLBTEXT, i, (DWORD) (LPSTR) str);
        'val = atof(str);

        'if (Inst->Lamp_par.lamp[LampNo].wv != val)
        '   Inst->Lamp_par.lamp[LampNo].wv=val;

        'if (Inst->Lamp_par.lamp[LampNo].wv <190 || Inst->Lamp_par.lamp[LampNo].wv>900)
        '{
        '   Gerror_message_new(" Wavelength entry error", "ENTRY");
        '	break;
        '}

        'If (AAflag) Then
        '   Inst->Lamp_par.lamp[LampNo].mode=AA;
        'Else
        '   Inst->Lamp_par.lamp[LampNo].mode=AABGC;

        'if (warmup)
        '{
        '   if( GetInstrument() == AA202 )
        '	    warm_lamp = GetDlgItemInt(hwnd, IDC_TUR1, NULL,FALSE)-1;
        '   Else
        '	    warm_lamp = GetDlgItemInt(hwnd, IDC_TUR, NULL,FALSE)-1;

        '	//LampNo;
        '	Set_Warmup_Lamp(warm_lamp);
        '	SendMessage(hwnd, WM_COMMAND, IDC_WORKCONDN, 0L);
        '}

        'GetDlgItemText(hwnd, IDC_CUR1, str, 4);
        'val =(double) atof(str);

        'if (LampNo>=0 && LampNo<=5 && val>0 && val<25)
        '   Inst->Lamp_par.lamp[LampNo].cur=val;

        'GetDlgItemText(hwnd, IDC_SW, str, 4);
        'val = atof(str);

        'if (LampNo>=0 && LampNo<=5 && val>=0 && val<=2.0)
        '   Inst->Lamp_par.lamp[LampNo].slitwidth=val;

        '#If !IN203DLL Then
        '	for(i=0;i<GetMaxLamp(); i++) //6
        '	    Set_Lamp_Parameters(&(Inst->Lamp_par.lamp[i]), i);
        '#End If

        'Save_Tuttet_Status();
        'EndDialog(hwnd, 1);

        'break;

        '=====================================================================
        '''Dim objWait As New CWaitCursor
        '''Dim intCount As Integer
        '''Dim intElementID As Integer
        '''Dim intLampNo As Integer
        '''Dim dblWV As Double
        '''Dim objDtWv As New DataTable
        '''Dim dblCurrent As Double
        '''Dim dblSlitWidth As Double

        '''Try
        '''    '---added by deepak on 03.09.07
        '''    Dim intCounter As Integer
        '''    For intCounter = 0 To gobjInst.Lamp.LampParametersCollection.Count - 1
        '''        ''LampParametersCollection obj to collection
        '''        If (intCounter + 1) = gobjInst.Lamp_Position Then
        '''            gobjfrmStatus.lblElementName.Text = gobjInst.Lamp.LampParametersCollection.item(intCounter).ElementName
        '''            Exit For
        '''        End If
        '''    Next
        '''    '------------

        '''    intElementID = cmbElementName.SelectedValue

        '''    If txtTurretNum.Text = "" Or txtLampCurrent.Text = "" Or txtSlitWidth.Text = "" Then
        '''        ''check all the value should be enterd
        '''        gobjMessageAdapter.ShowMessage(constFieldsRequired)
        '''        Exit Sub    'Saurabh
        '''        Application.DoEvents()
        '''    End If

        '''    If Not txtTurretNum.Text < 7 And txtTurretNum.Text > 0 Then
        '''        ''set a range for turrt no (1-6)
        '''        gobjMessageAdapter.ShowMessage(constEnterTurretNo)
        '''        Exit Sub    'Saurabh
        '''        Application.DoEvents()
        '''    End If

        '''    '******************************************************************
        '''    '----Added by Mangesh on 29-Mar-2007 for updating the gobjInst
        '''    '--- with new Instrument Settings
        '''    '******************************************************************
        '''    intLampNo = CInt(txtTurretNum.Text)
        '''    dblWV = Val(cmbWV.Text)
        '''    dblCurrent = Val(txtLampCurrent.Text)
        '''    dblSlitWidth = Val(txtSlitWidth.Text)

        '''    ''getting some value from screen to temp variables

        '''    '---Sets changed Wavelength
        '''    If (gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).Wavelength <> dblWV) Then
        '''        gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).Wavelength = dblWV
        '''    End If

        '''    'condition added by deepak on 24.07.07
        '''    If (gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).Wavelength < gstructSettings.WavelengthRange.WvLowerBound Or gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).Wavelength > gstructSettings.WavelengthRange.WvUpperBound) Then
        '''        ''set a wavelength range
        '''        gobjMessageAdapter.ShowMessage("Wavelength entry error", "ENTRY", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
        '''        Application.DoEvents()
        '''        ''allow application to perfrom its panding work
        '''        Exit Sub
        '''    End If

        '''    'If (gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).Wavelength < 190 Or gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).Wavelength > 900) Then
        '''    '    gobjMessageAdapter.ShowMessage("Wavelength entry error", "ENTRY", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
        '''    '    Application.DoEvents()
        '''    '    Exit Sub
        '''    'End If

        '''    '---Sets changed Lamp Current
        '''    If (gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).Current <> dblCurrent) Then
        '''        gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).Current = dblCurrent
        '''    End If

        '''    '---Sets changed Slit Width
        '''    If (gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).SlitWidth <> dblSlitWidth) Then
        '''        gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).SlitWidth = dblSlitWidth
        '''    End If

        '''    objDtWv = gobjClsAAS203.funcGetElementWavelengths(intElementID)

        '''    If Not IsNothing(gobjNewMethod) Then
        '''        If Not IsNothing(gobjNewMethod.InstrumentCondition) Then
        '''            gobjNewMethod.InstrumentCondition.ElementID = intElementID
        '''            gobjNewMethod.InstrumentCondition.LampCurrent = CDbl(Trim(txtLampCurrent.Text))
        '''            gobjNewMethod.InstrumentCondition.SelectedWavelengthID = cmbWV.SelectedValue
        '''            gobjNewMethod.InstrumentCondition.SlitWidth = CDbl(Trim(txtSlitWidth.Text))
        '''            gobjNewMethod.InstrumentCondition.LampNumber = intLampNo
        '''            gobjNewMethod.InstrumentCondition.TurretNumber = intLampNo
        '''            ''get all current parameter in to gobjNewMethod object

        '''            If Not objDtWv Is Nothing Then
        '''                gobjNewMethod.InstrumentCondition.Wavelength = objDtWv
        '''            End If
        '''        End If
        '''        For intCount = 0 To gobjMethodCollection.Count - 1
        '''            ''store method info in data structure

        '''            If gobjMethodCollection.item(intCount).MethodID = gobjNewMethod.MethodID Then
        '''                gobjMethodCollection.item(intCount).InstrumentCondition = gobjNewMethod.InstrumentCondition.Clone()
        '''                gobjMethodCollection.item(intCount).DateOfModification = DateTime.Now
        '''                gobjNewMethod.DateOfModification = DateTime.Now
        '''            End If
        '''        Next
        '''        If gobjNewMethod.OperationMode = EnumOperationMode.MODE_AA Or gobjNewMethod.OperationMode = EnumOperationMode.MODE_AABGC Then
        '''            gobjNewMethod.InstrumentCondition.IsOptimize = False
        '''        End If
        '''        'Call funcSerialize(ConstMethodsFileName, gobjMethodCollection)
        '''        'Added By Pankaj on 23 May 07 for adding method of inactive mode
        '''        'gobjchkActiveMethod.fillInstruments = True '27.07.07
        '''        'If (gobjchkActiveMethod.fillInstruments = True And gobjchkActiveMethod.fillParameters = True And gobjchkActiveMethod.fillStdConcentration = True And gobjchkActiveMethod.CancelMethod = True And gobjchkActiveMethod.NewMethod = True) Then
        '''        If (gobjchkActiveMethod.fillStdConcentration = True And gobjchkActiveMethod.CancelMethod = True And gobjchkActiveMethod.NewMethod = True) Then
        '''            gobjchkActiveMethod.NewMethod = False
        '''            gobjchkActiveMethod.CancelMethod = False
        '''            'gobjchkActiveMethod.fillInstruments = False  '27.07.07
        '''            'gobjchkActiveMethod.fillParameters = False   '27.07.07
        '''            gobjchkActiveMethod.fillStdConcentration = False
        '''            gobjNewMethod.Status = True
        '''            gobjMethodCollection.Add(gobjNewMethod)
        '''        End If
        '''        Call funcSaveAllMethods(gobjMethodCollection)
        '''        ''now save a method with current info to data structure
        '''        RaiseEvent MethodInstrumentSettingsChanged()
        '''        ''this is a event which called when method setting is being changed 
        '''        ''it update a current info in method
        '''    End If

        '''    'If Else is added by Saurabh
        '''    'If gstructSettings.ExeToRun = EnumApplicationMode.AAS Then   'Added by Saurabh
        '''    Call funcSaveInstStatus()
        '''    ''To serialize the object gobjinst with current instrument status


        '''    'Else
        '''    If gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then
        '''        gintTurretToOptimizeForServiceUtility = CInt(txtTurretNum.Text)
        '''    End If

        '''    'End If
        '''    'Call funcSaveInstStatus()  'Commented and added this function in the above else part by Saurabh

        '''    If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
        '''        If Not IsNothing(gobjNewMethod) Then    'Checked by Saurabh 25.06.07
        '''            ''now show the current status of instrument on a status form
        '''            gobjfrmStatus.ElementName = CStr(gobjClsAAS203.funcGetElement(gobjNewMethod.InstrumentCondition.ElementID).Rows(0).Item("NAME"))
        '''            gobjfrmStatus.TurretNumber = gobjNewMethod.InstrumentCondition.TurretNumber
        '''        End If
        '''    End If

        '''    '---kept for service mode
        '''    gblnIsInstrumentConditionsActive = True

        '''    Me.DialogResult = DialogResult.OK

        Try
            funcOK(True)
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
            '''objWait.Dispose()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub txtTurretNum_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : txtTurretNum_TextChanged
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To display the element information according to the selected turret 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak, Saurabh
        ' Created               : 07.10.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this is called when user change the turret no
        ''this will also check the validation for given turret no.
        Dim intCounter As Integer
        Dim blnIsTurretFound As Boolean = False
        Dim intLampNumber As Integer
        Dim intObjCount As Integer
        Dim intSearchEleId As Integer
        Dim objWait As New CWaitCursor

        Try
            If txtTurretNum.Text.Length > 0 Then

                '-----------Added by Saurabh on 23-05-2007
                If txtTurretNum.Text < 1 Or txtTurretNum.Text > 6 Then
                    'btnOk.Enabled = False
                ElseIf cmbWV.Text = "" Then
                    'btnOk.Enabled = False
                Else
                    'btnOk.Enabled = True
                End If
                '-----------Added by Saurabh on 23-05-2007

                '---Changed and Added by Mangesh S. on 22-Jan-2007

                intLampNumber = Val(Trim(txtTurretNum.Text))

                If mblnWarmupLamp Then
                    mintWarmUp_Lamp = intLampNumber
                Else
                    mintTurretNumber = intLampNumber
                End If
                '---Changed and Added by Mangesh S. on 22-Jan-2007

                '---Validate turret number
                If intLampNumber < 7 And intLampNumber > 0 Then

                    Select Case gstructSettings.AppMode
                        Case EnumAppMode.FullVersion_201

                            For intObjCount = 0 To 1
                                If intObjCount + 1 = intLampNumber Then
                                    If funcShowElementInfo(gobjInst.Lamp.LampParametersCollection.item(intObjCount), intObjCount + 1) = True Then
                                        blnIsTurretFound = True
                                        intSearchEleId = gobjDataAccess.GetCookBookElementID(gobjInst.Lamp.LampParametersCollection.item(intObjCount).AtomicNumber)
                                        cmbElementName.SelectedValue = intSearchEleId
                                        Exit For
                                    End If
                                End If
                            Next

                            If blnIsTurretFound = False Then
                                RemoveHandler cmbElementName.SelectedIndexChanged, AddressOf cmbElementName_SelectedIndexChanged
                                cmbElementName.DropDownStyle = ComboBoxStyle.DropDown
                                cmbElementName.Text = ""
                                txtLampCurrent.Text = ""
                                cmbWV.DropDownStyle = ComboBoxStyle.DropDown
                                cmbWV.Text = ""
                                txtSlitWidth.Text = ""
                                AddHandler cmbElementName.SelectedIndexChanged, AddressOf cmbElementName_SelectedIndexChanged
                            End If

                        Case Else

                            For intObjCount = 0 To gobjInst.Lamp.LampParametersCollection.Count - 1
                                If intObjCount + 1 = intLampNumber Then
                                    If funcShowElementInfo(gobjInst.Lamp.LampParametersCollection.item(intObjCount), intObjCount + 1) = True Then
                                        blnIsTurretFound = True
                                        intSearchEleId = gobjDataAccess.GetCookBookElementID(gobjInst.Lamp.LampParametersCollection.item(intObjCount).AtomicNumber)
                                        cmbElementName.SelectedValue = intSearchEleId
                                        Exit For
                                    End If
                                End If
                            Next

                            If blnIsTurretFound = False Then
                                RemoveHandler cmbElementName.SelectedIndexChanged, AddressOf cmbElementName_SelectedIndexChanged
                                cmbElementName.DropDownStyle = ComboBoxStyle.DropDown
                                cmbElementName.Text = ""
                                txtLampCurrent.Text = ""
                                cmbWV.DropDownStyle = ComboBoxStyle.DropDown
                                cmbWV.Text = ""
                                txtSlitWidth.Text = ""
                                AddHandler cmbElementName.SelectedIndexChanged, AddressOf cmbElementName_SelectedIndexChanged
                            End If
                    End Select
                Else
                    Application.DoEvents()
                    txtTurretNum.Select()
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
            Call Check_OK_Button()
            objWait.Dispose()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub txtTurretNum_ValidationStatus(ByVal Status As NumberValidator.NumberValidator.Status, ByVal Msg As String)
        '=====================================================================
        ' Procedure Name        : txtTurretNum_ValidationStatus
        ' Parameters Passed     : NumberValidator.Status,String
        ' Returns               : None
        ' Purpose               : To validate txtTurretnum text box
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 10.10.06
        ' Revisions             : 
        '=====================================================================

        ''note
        ''this is used for the turret no validation
        ''turret num should be in range 1 - 6 .
        Try
            If Status = NumberValidator.NumberValidator.Status.NotValidated Then
                txtTurretNum.Focus()
                'btnOk.Enabled = False
            Else
                'btnOk.Enabled = True       'Commented by Saurabh
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

    Private Sub txtCurrent_ValidationStatus(ByVal Status As NumberValidator.NumberValidator.Status, ByVal Msg As String)
        '=====================================================================
        ' Procedure Name        : txtCurrent_ValidationStatus
        ' Parameters Passed     : NumberValidator.Status,String
        ' Returns               : None
        ' Purpose               : To validate txtCurrent text box
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 10.10.06
        ' Revisions             : 
        '=====================================================================


        ''note :
        ''this is used to set the validation for current
        ''current should be in range 0 - 25.

        Try
            If Not (txtLampCurrent.Text = "") Then


                If Status = NumberValidator.NumberValidator.Status.NotValidated Then
                    txtLampCurrent.Focus()
                    'btnOk.Enabled = False
                Else
                    'btnOk.Enabled = True
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

    Private Sub txtSlitWidth_ValidationStatus(ByVal Status As NumberValidator.NumberValidator.Status, ByVal Msg As String)
        '=====================================================================
        ' Procedure Name        : txtSlitWidth_ValidationStatus
        ' Parameters Passed     : NumberValidator.Status,String
        ' Returns               : None
        ' Purpose               : To validate txtSlitWidth text box
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 10.10.06
        ' Revisions             : 
        '=====================================================================

        ''note:
        ''this is used to set slit width validation
        ''it should be in range 0-2. nm
        Try
            If Status = NumberValidator.NumberValidator.Status.NotValidated Then
                txtSlitWidth.Focus()
                'btnOk.Enabled = False
            Else
                'btnOk.Enabled = True
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

    Private Sub btnOptimiseTurret_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnOptimiseTurret_Click
        ' Parameters Passed     : 
        ' Returns               : None
        ' Purpose               : To call Turret optimisation procedure 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak B.
        ' Created               : 28.11.06
        ' Revisions             : 
        '=====================================================================
        Dim intCounter As Integer
        Dim dblCurrent As Double
        ''note:
        ''this is called when user click on optimise button
        ''get a turret no which has to be optimise
        ''start the optimise thread with current turret no
        ''perfrom all the step in thread
        ''and now display a result in optimise form as graph






        Dim objWait As New CWaitCursor
        Try
            '========
            'used in inst.c in 16 bit
            'case IDC_OPTTUR:
            '========

            '--reset lamp parameters like tur_opt_pos etc.
            'If Not IsNothing(mobjfrmLampPlacements.mobjInstrumentParameters) Then   'If mobjfrmLampPlacements.mobjClsInstrumentParaCollection.Count > 0 Then
            '    'For intCounter = 0 To mobjfrmLampPlacements.mobjClsInstrumentParaCollection.Count - 1
            '    If mobjfrmLampPlacements.mobjInstrumentParameters.TurretNumber = mintTurretNumber Then
            '        dblCurrent = mobjfrmLampPlacements.mobjInstrumentParameters.LampCurrent
            '    End If
            '    'Next

            '    Call gfuncLamp_connected(mintTurretNumber)

            '    Dim mobjfrmturretOptimisation As frmTurretOptimisation
            '    mobjfrmturretOptimisation = New frmTurretOptimisation(dblCurrent, mintTurretNumber)
            '    mobjfrmturretOptimisation.StartOptimizeTread()
            '    mobjfrmturretOptimisation.StartPosition = FormStartPosition.CenterScreen
            '    If mobjfrmturretOptimisation.ShowDialog() = DialogResult.OK Then
            '        mobjfrmturretOptimisation.Close()
            '        mobjfrmturretOptimisation.Dispose()
            '    End If
            'End If

            'If Not IsNothing(mobjfrmLampPlacements.mobjInstrumentParameters) Then   'If mobjfrmLampPlacements.mobjClsInstrumentParaCollection.Count > 0 Then
            'For intCounter = 0 To mobjfrmLampPlacements.mobjClsInstrumentParaCollection.Count - 1
            'If mobjfrmLampPlacements.mobjInstrumentParameters.TurretNumber = mintTurretNumber Then
            '    dblCurrent = mobjfrmLampPlacements.mobjInstrumentParameters.LampCurrent
            'End If
            'Next
            If Trim(txtLampCurrent.Text) = "" Then
                Exit Sub
            End If

            'Added by Saurabh-To stop the Thread---
            If Not gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then
                gobjMain.mobjController.Cancel()
                ''stop the thread if any running 
                gobjCommProtocol.mobjCommdll.subTime_Delay(500)   '10.12.07
                Application.DoEvents()
                ''allow application to perfrom its panding task
            End If
            '--------------------------------------

            dblCurrent = CDbl(txtLampCurrent.Text)
            mintTurretNumber = CInt(txtTurretNum.Text)
            ''get a lamp current and turret num in a temp variable

            Call gfuncLamp_connected(mintTurretNumber)
            ''To set lamp parameters property lamp optimise at selected position

            Dim mobjfrmturretOptimisation As frmTurretOptimisation
            ''this is object of turretoptimisation form
            mobjfrmturretOptimisation = New frmTurretOptimisation(dblCurrent, mintTurretNumber)
            mobjfrmturretOptimisation.StartOptimizeTread()
            ''this called for starting a optimized thread
            ''where thread perfrom all step for turret optimisation
            mobjfrmturretOptimisation.StartPosition = FormStartPosition.CenterScreen
            If mobjfrmturretOptimisation.ShowDialog() = DialogResult.OK Then
                ''show the turret optimization dialog
                mobjfrmturretOptimisation.Close()
                mobjfrmturretOptimisation.Dispose()
                'Saurabh on 28 MAy 2007
                If gobjfrmStatus.lblTurretNo.Visible = False Then
                    gobjfrmStatus.lblTurretNo.Visible = True
                End If
                If gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
                    gobjfrmStatus.ElementName = gobjInst.ElementName
                End If
                'Saurabh on 28 MAy 2007
            End If
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            'Added by Saurabh-To start the Thread---
            If Not gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then
                If gobjMain.mobjController.IsThreadRunning = False Then
                    gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)
                    Application.DoEvents()
                    gobjMain.mobjController.Start(gobjclsBgFlameStatus)
                End If
                Application.DoEvents()
            End If
            '---------------------------------------------------------
        End Try

    End Sub

    Private Sub btnOptimiseAllTurret_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnOptimiseTurret_Click
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
        ''note:
        ''this is called when user click on optimise all turret button
        ''here we have to optimise all turret
        ''perfrom Zeroorder first.
        ''for this start the zero order thread
        ''this will perfrom all the function and display a zero order graph.
        ''then start the optimise thread with current turret num.
        ''perfrom all the step in thread
        ''and now display a result in optimise form as graph

        Dim objWait As New CWaitCursor
        Try
            'Added by Saurabh-To stop the Thread---
            If Not gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then
                gobjMain.mobjController.Cancel()
                gobjCommProtocol.mobjCommdll.subTime_Delay(500)   '10.12.07
                Application.DoEvents()
            End If
            '--------------------------------------

            '---21.01.08
            If CInt(txtTurretNum.Text) >= 1 And CInt(txtTurretNum.Text) <= 10 Then
                If Not gobjInst Is Nothing Then
                    If IsNumeric(txtLampCurrent.Text) = True Then
                        gobjInst.Lamp.LampParametersCollection(CInt(txtTurretNum.Text) - 1).Current = CDbl(txtLampCurrent.Text)
                    End If
                End If
            End If
            '---21.01.08

            Dim mobjfrmZeroOrder As frmZeroOrder
            ''object to zero order
            mobjfrmZeroOrder = New frmZeroOrder
            mobjfrmZeroOrder.StartPosition = FormStartPosition.Manual
            mobjfrmZeroOrder.Location = New Point(ZeroOrderThreadWindowLocationX, ZeroOrderThreadWindowLocationY)
            mobjfrmZeroOrder.StartOptimizeTread()
            ''for starting a thread
            ''this will start zero order thread.
            If mobjfrmZeroOrder.ShowDialog() = DialogResult.OK Then
                ''show the zero order form
                mobjfrmZeroOrder.Close()
                mobjfrmZeroOrder.Dispose()
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
                ''destructor
            End If
            'Added by Saurabh-To start the Thread---
            If Not gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then
                If gobjMain.mobjController.IsThreadRunning = False Then '10.12.07
                    gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)
                    Application.DoEvents()
                    gobjMain.mobjController.Start(gobjclsBgFlameStatus)
                End If
                ''restart the thread if it stoped.
                Application.DoEvents()
                ''allow application to perfrom its panding work.
            End If
            '---------------------------------------------------------
        End Try

    End Sub

    Private Sub cmbWV_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : cmbWV_SelectedIndexChanged
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To set SelectedWavelengthID
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 15.12.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this is called when user change a wavelength 
        Try
            SelectedWavelengthID = cmbWV.SelectedValue
            ''get a selected Wavelength.
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
            Call Check_OK_Button()
            ''this will called OK button procedure for updating current wavelength.
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub Set_Warmup_Lamp(ByVal intWarmupLampNumber As Integer)
        '=====================================================================
        ' Procedure Name        : Set_Warmup_Lamp
        ' Parameters Passed     : intWarmupLampNumber
        ' Returns               : none
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : 
        ' Created               : 
        ' Revisions             : praveen
        '=====================================================================

        ''note:
        ''this is used to set a warmup lamp to datastructure.
        ''and later this will used in a software. 

        'void	S4FUNC Set_Warmup_Lamp(int pos)
        '{
        '	Inst.Lamp_warm = pos+1;
        '}

        Try
            gobjInst.Lamp_Warm = intWarmupLampNumber
            ''save current warmup lamp to data structure
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

    Private Function Get_Warmup_Lamp_Pos() As Integer
        '=====================================================================
        ' Procedure Name        : Get_Warmup_Lamp_Pos
        ' Parameters Passed     : 
        ' Returns               : warmup lamp position.
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : 
        ' Created               : 
        ' Revisions             : praveen
        '=====================================================================
        'int	S4FUNC Get_Warmup_Lamp_Pos()
        '{
        '	return Inst.Lamp_warm-1;
        '}
        Return gobjInst.Lamp_Warm
        ''for getting current warm up lamp position from data structure

    End Function

    Private Function Validate_AASetup(ByVal blnIsWarmUp As Boolean) As Boolean
        '=====================================================================
        ' Procedure Name        : Validate_AASetup
        ' Parameters Passed     : blnIsWarmUp
        ' Returns               : this is used for validate a setup as per parameter passed.
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : 
        ' Created               : 
        ' Revisions             : praveen
        '=====================================================================
        '//-----------------
        'BOOL	Validate_AASetup(HWND hwnd, BOOL warmup)
        '{
        'double	tempk=0;
        'int	i;
        'BOOL	flag=TRUE;
        'char	str[80]="";
        '  i= (WORD) SendMessage(GetDlgItem(hwnd, IDC_ELNAME),
        '		 CB_GETCURSEL, 0, 0L);
        '  SendMessage(GetDlgItem(hwnd, IDC_ELNAME), CB_GETLBTEXT,
        '		i, (DWORD) (LPSTR) str);
        '  if (strcmpi(ltrim(trim(str)),"")==0)
        '	 flag=FALSE;
        '  if (flag){
        '	  if( GetInstrument() == AA202 )
        '		 i=GetDlgItemInt(hwnd, IDC_TUR1, NULL,FALSE);
        '                Else
        '		 i=GetDlgItemInt(hwnd, IDC_TUR, NULL,FALSE);
        '	  if (warmup){
        '		 if (i<0 || i>GetMaxLamp()) //6
        '			flag=FALSE;
        '		 }
        '	  else{
        '		 if (i<1 || i>GetMaxLamp()) //6
        '		 flag=FALSE;
        '		}
        '	  if (flag) {
        '		 i= (WORD) SendMessage(GetDlgItem(hwnd, IDC_CBWV),
        '				 CB_GETCURSEL, 0, 0L);
        '		 SendMessage(GetDlgItem(hwnd, IDC_CBWV), CB_GETLBTEXT,
        '			i, (DWORD) (LPSTR) str);
        '		 tempk=atof(str);
        '		 if (tempk<190.0 || tempk >900)
        '			flag=FALSE;
        '		 if (flag){
        '			GetDlgItemText(hwnd, IDC_CUR1, str, 4);
        '			tempk=(double) atof(str);
        '			if (tempk<=0 || tempk>25)
        '			  flag=FALSE;
        '			if (flag){ //cur
        '				GetDlgItemText(hwnd, IDC_SW, str, 4);
        '				tempk= atof(str);
        '				if (tempk<=0.0 || tempk >2.0)
        '					flag=FALSE;
        '			  }//cur
        '		  } //wv
        '		}//tur
        '	 }//el
        '  EnableWindow(GetDlgItem(hwnd, SKOK), FALSE);
        '  If (flag) Then
        '	 EnableWindow(GetDlgItem(hwnd, SKOK), TRUE);
        '  return flag;
        '}
        '//-----------------------




        ''note:
        ''this function set all the flag true or false as par validation
        ''in above there is C code and Below .Net code


        Dim tempk As Double = 0
        Dim intTurretNumber As Integer
        Dim blnIsValid As Boolean = True
        Dim str As String = ""

        '---Validate for Element Name
        If Trim(cmbElementName.Text) = "" Then
            blnIsValid = False
        End If

        If (blnIsValid) Then
            intTurretNumber = CInt(txtTurretNum.Text)
            ''type caste text value and store it in temp variable

            If (mblnWarmupLamp) Then
                If (intTurretNumber < 1 Or intTurretNumber > gobjClsAAS203.funcGetMaxLamp()) Then blnIsValid = False
            Else
                If (intTurretNumber < 1 Or intTurretNumber > gobjClsAAS203.funcGetMaxLamp()) Then blnIsValid = False
            End If

            If (blnIsValid) Then
                '---Get Selected Wavelength from DropDown List
                tempk = Val(cmbWV.Text)
                If (tempk < gstructSettings.WavelengthRange.WvLowerBound Or tempk > gstructSettings.WavelengthRange.WvUpperBound) Then
                    blnIsValid = False
                End If

                If (blnIsValid) Then
                    tempk = CDbl(txtLampCurrent.Text)
                    If (tempk <= 0 Or tempk > 25) Then
                        blnIsValid = False
                    End If

                    If (blnIsValid) Then
                        tempk = CDbl(txtSlitWidth.Text)
                        If (tempk <= 0.0 Or tempk > 2.0) Then
                            blnIsValid = False
                        End If
                    End If
                End If
            End If
        End If

        If (blnIsValid) Then
            'btnOk.Enabled = True
        Else
            'btnOk.Enabled = False
        End If

        Return blnIsValid

    End Function

    Private Sub subSetTextValidation()
        '=====================================================================
        ' Procedure Name        : subSetTextValidation
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To validate text boxes
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak
        ' Created               : 
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this is used for setting all text validation range

        Try
            ''for eg here is slit width which can be double 
            ''and in range 1.0 - 2.0
            txtSlitWidth.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly
            txtSlitWidth.DigitsAfterDecimalPoint = 1
            txtSlitWidth.RangeValidation = True
            txtSlitWidth.MinimumRange = ConstIntMinSlitWidthLimit '1.0
            txtSlitWidth.MaximumRange = ConstIntMaxSlitWidthLimit '2.0
            txtSlitWidth.ErrorColor = Color.Gainsboro
            ''set a validation for txtLampCurrent
            txtLampCurrent.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly
            txtLampCurrent.DigitsAfterDecimalPoint = 2
            txtLampCurrent.RangeValidation = True
            txtLampCurrent.MinimumRange = ConstIntMinCurrentLimit '0.1
            txtLampCurrent.MaximumRange = ConstIntMaxCurrentLimit '25.99
            txtLampCurrent.ErrorColor = Color.Gainsboro
            ''set a validation for txtTurrertNum
            txtTurretNum.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly
            txtTurretNum.RangeValidation = True
            txtTurretNum.MinimumRange = ConstIntMinTurretLimit '1
            txtTurretNum.MaximumRange = ConstIntMaxTurretLimit '6
            txtTurretNum.ErrorColor = Color.Gainsboro

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

    Private Sub frmInstrumentParameters_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        '=====================================================================
        ' Procedure Name        : frmInstrumentParameters_Closing 
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To the information 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 
        ' Revisions             : 
        '=====================================================================
        Try
            ''note:
            'this is called when user closed the form
            If gstructSettings.ExeToRun = EnumApplicationMode.AAS Then
                gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType & ConstParentFormLoad)
            Else

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

    Private Function funcLoadLamps() As Integer
        '=====================================================================
        ' Procedure Name        : funcLoadLamps
        ' Parameters Passed     : 
        ' Returns               : returns total number of lamps connected
        ' Purpose               : To load all lamps 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 31.03.07
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this is used to load all the conected lamp
        ''and it info in a data structure.
        Dim objDtElements As New DataTable
        Dim intEleCount As Integer = 0
        Dim intObjCount As Integer
        Dim objRow As DataRow
        Dim intElementID As Integer
        Dim intLampsCount As Integer
        Dim objDvElementsList As New DataView

        Try
            objDtElements.Columns.Add(ConstColumnElementID, GetType(Integer))
            objDtElements.Columns.Add(ConstColumnElementName, GetType(String))
            objDtElements.Columns.Add(ConstColumnTurretNumber, GetType(Integer))

            For intObjCount = 0 To gobjInst.Lamp.LampParametersCollection.Count - 1
                ''make a counter up to a collection.
                If gobjInst.Lamp.LampParametersCollection.item(intObjCount).ElementName <> "" Then
                    objRow = objDtElements.NewRow()
                    If gobjInst.Lamp.LampParametersCollection.item(intObjCount).AtomicNumber <> 0 Then
                        intLampsCount = intLampsCount + 1
                    End If
                    intElementID = gobjDataAccess.GetCookBookElementID(gobjInst.Lamp.LampParametersCollection.item(intObjCount).AtomicNumber)
                    objRow.Item(ConstColumnElementID) = intElementID
                    objRow.Item(ConstColumnElementName) = gobjInst.Lamp.LampParametersCollection.item(intObjCount).ElementName
                    objRow.Item(ConstColumnTurretNumber) = intObjCount + 1
                    objDtElements.Rows.Add(objRow)
                End If
            Next

            RemoveHandler cmbElementName.SelectedIndexChanged, AddressOf cmbElementName_SelectedIndexChanged
            objDvElementsList = New DataView(objDtElements)
            objDvElementsList.Sort = ConstColumnTurretNumber

            cmbElementName.DataSource = objDvElementsList
            cmbElementName.ValueMember = ConstColumnElementID
            cmbElementName.DisplayMember = ConstColumnElementName
            cmbElementName.DropDownStyle = ComboBoxStyle.DropDownList

            AddHandler cmbElementName.SelectedIndexChanged, AddressOf cmbElementName_SelectedIndexChanged

            Return intLampsCount
            ''return a no of lamp count

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

    Private Function funcLoadMethodElement(ByVal intElementID As Integer) As Integer
        '=====================================================================
        ' Procedure Name        : funcLoadMethodElement
        ' Parameters Passed     : 
        ' Returns               : 
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 03.04.07
        ' Revisions             : 
        '=====================================================================
        Dim objDtWavelength As New DataTable

        ''note:
        ''this is used to load a methos info
        ''and display that info on form in a proper control



        Try
            If Not IsNothing(gobjNewMethod) Then
                If intElementID = gobjNewMethod.InstrumentCondition.ElementID Then
                    RemoveHandler cmbElementName.SelectedIndexChanged, AddressOf cmbElementName_SelectedIndexChanged
                    RemoveHandler txtTurretNum.TextChanged, AddressOf txtTurretNum_TextChanged
                    RemoveHandler cmbWV.SelectedIndexChanged, AddressOf cmbWV_SelectedIndexChanged

                    '--set method element to combo box.
                    cmbElementName.SelectedValue = gobjNewMethod.InstrumentCondition.ElementID
                    '--set method turret number to text box.
                    txtTurretNum.Text = gobjNewMethod.InstrumentCondition.TurretNumber
                    ''set a lamp current to lamp text box.
                    txtLampCurrent.Text = gobjNewMethod.InstrumentCondition.LampCurrent
                    ''get a wavelength as per eleID
                    objDtWavelength = gobjDataAccess.GetElementWavelengths(intElementID)

                    If Not IsNothing(objDtWavelength) Then
                        cmbWV.DataSource = objDtWavelength
                        cmbWV.DisplayMember = ConstColumnWV
                        cmbWV.ValueMember = ConstColumnAADetailsID
                    End If
                    ''get a wavwlength.
                    cmbWV.SelectedValue = gobjNewMethod.InstrumentCondition.SelectedWavelengthID
                    ''get a slit width.
                    txtSlitWidth.Text = gobjNewMethod.InstrumentCondition.SlitWidth

                    AddHandler cmbWV.SelectedIndexChanged, AddressOf cmbWV_SelectedIndexChanged
                    ''for adding a handler.
                    AddHandler cmbElementName.SelectedIndexChanged, AddressOf cmbElementName_SelectedIndexChanged
                    AddHandler txtTurretNum.TextChanged, AddressOf txtTurretNum_TextChanged
                Else
                    '---28.05.07
                    Dim intObjCount As Integer
                    For intObjCount = 0 To gobjInst.Lamp.LampParametersCollection.Count - 1
                        Dim intSearchEleId As Integer
                        intSearchEleId = gobjDataAccess.GetCookBookElementID(gobjInst.Lamp.LampParametersCollection.item(intObjCount).AtomicNumber)
                        ''get a elementID
                        If intSearchEleId = intElementID Then
                            If funcShowElementInfo(gobjInst.Lamp.LampParametersCollection.item(intObjCount), intObjCount + 1) = True Then
                                ''for showing a element info.
                                Exit For
                            End If
                        End If
                    Next
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
    End Function

    Private Sub mobjfrmLampPlacements_LampReplaced() Handles mobjfrmLampPlacements203.LampReplaced, mobjfrmLampPlacements201.LampReplaced
        '=====================================================================
        ' Procedure Name        : mobjfrmLampPlacements_LampReplaced
        ' Parameters Passed     : 
        ' Returns               : 
        ' Purpose               : this handle a lamp replaced event.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 03.04.07
        ' Revisions             : 
        '=====================================================================
        Try
            Call funcLoadLamps()
            ''it gives a info of all conected lamp


            '-----Saruabh---24.06.07
            If Not IsNothing(gobjNewMethod) Then
                'Added By Pankaj 27 May 07
                calElement()
            End If
            '-----Saruabh---24.06.07
            Call cmbElementName_SelectedIndexChanged(cmbElementName, EventArgs.Empty)
            ''called elementname changed event.
            '-------
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

    Private Sub mobjfrmLampPlacements_LampRemoved() Handles mobjfrmLampPlacements203.LampRemoved, mobjfrmLampPlacements201.LampRemoved
        '=====================================================================
        ' Procedure Name        : mobjfrmLampPlacements_LampRemoved
        ' Parameters Passed     : 
        ' Returns               : 
        ' Purpose               : this handle a lamp removed event.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 03.04.07
        ' Revisions             : 
        '=====================================================================
        Try
            Call funcLoadLamps()
            ''this called for loading all lamp.

            ''------------------------------------
            'Dim intCount As Integer
            'Dim blnExists As Boolean = False
            'For intCount = 0 To gobjInst.Lamp.LampParametersCollection.Count - 1
            '    If gobjClsAAS203.funcGetElementID(gobjInst.Lamp.LampParametersCollection.item(intCount).AtomicNumber) = gobjNewMethod.InstrumentCondition.ElementID Then
            '        blnExists = True
            '        Exit For
            '    End If
            'Next
            'If blnExists = True Then
            '    cmbElementName.SelectedValue = gobjNewMethod.InstrumentCondition.ElementID
            'End If
            ''------------------------------------

            '-----Saruabh---24.06.07
            If Not IsNothing(gobjNewMethod) Then
                'Added By Pankaj 27 May 07
                calElement()
                ''this will calculate a no of element.
            End If
            '-----Saruabh---24.06.07
            'Call cmbElementName_SelectedIndexChanged(cmbElementName, EventArgs.Empty)

            '-------
            'If cmbElementName.Text = "" Then
            'cmbElementName.Enabled = True
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

    Private Sub calElement()
        '=====================================================================
        ' Procedure Name        : calElement
        ' Parameters Passed     : 
        ' Returns               : 
        ' Purpose               : this will calculate a no of element.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 03.04.07
        ' Revisions             : 
        '=====================================================================
        'Added By Pankaj 27 May 07
        Dim blFlag As Boolean = False
        Dim i As Integer
        ''i for counter
        Try
            For i = 0 To 9
                If (gobjNewMethod.InstrumentCondition.ElementID = gobjDataAccess.GetCookBookElementID(gobjInst.Lamp.LampParametersCollection.item(i).AtomicNumber)) Then
                    ''check a ElementID frm database.
                    blFlag = True
                    Exit For
                End If
            Next
            If blFlag = False Then 'Or cmbElementName.Text = "" Then
                'If (cmbElementName.Items.Contains(gobjClsAAS203.funcGetElement(gobjNewMethod.InstrumentCondition.ElementID).Rows(0).Item(1))) Then
                '    'cmbElementName.Text = gobjClsAAS203.funcGetElement(gobjNewMethod.InstrumentCondition.ElementID).Rows(0).Item(0)
                '    cmbElementName.SelectedValue = gobjNewMethod.InstrumentCondition.ElementID
                'Else
                txtTurretNum.Enabled = True
                cmbElementName.Enabled = True
                'End If
            Else
                'If (cmbElementName.Items.Contains(gobjClsAAS203.funcGetElement(gobjNewMethod.InstrumentCondition.ElementID).Rows(0).Item(1))) Then
                'cmbElementName.Text = gobjClsAAS203.funcGetElement(gobjNewMethod.InstrumentCondition.ElementID).Rows(0).Item(1)
                If (i + 1 <> gobjNewMethod.InstrumentCondition.TurretNumber) Then
                    gobjNewMethod.InstrumentCondition.TurretNumber = i + 1
                End If
                cmbElementName.SelectedValue = gobjNewMethod.InstrumentCondition.ElementID
                ' Else
                '    txtTurretNum.Enabled = True
                '   cmbElementName.Enabled = True
                'End If
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
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try
        '-------
    End Sub

    Private Sub Check_OK_Button()
        '=====================================================================
        ' Procedure Name        : Check_OK_Button
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To enable or disable OK button
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 24.06.07
        ' Revisions             : 
        '=====================================================================

        ''note:
        ''this is called when user click on OK button
        ''this will check proper validation 
        ''and accept a user defined value to data structure


        Try
            If txtTurretNum.Text.Length > 0 Then
                If txtTurretNum.Text > 0 And txtTurretNum.Text < 7 Then
                    ''check for turrert no bet 0 to 7
                    If Not cmbElementName.Text = "" Then
                        If Not cmbWV.Text = "" Then
                            If txtLampCurrent.Text.Length > 0 Then
                                If txtLampCurrent.Text > 0 And txtLampCurrent.Text <= 25 Then
                                    ''check for lamp current.
                                    If txtSlitWidth.Text.Length > 0 Then
                                        If txtSlitWidth.Text > 0 And txtSlitWidth.Text < 2.1 Then
                                            ''check for slit width.
                                            btnOk.Enabled = True
                                            Me.AcceptButton = btnOk
                                        Else
                                            btnOk.Enabled = False
                                            Me.AcceptButton = btnCancel
                                            'btnCancel.Focus()
                                        End If
                                    Else
                                        btnOk.Enabled = False
                                        Me.AcceptButton = btnCancel
                                        'btnCancel.Focus()
                                    End If
                                Else
                                    btnOk.Enabled = False
                                    Me.AcceptButton = btnCancel
                                    'btnCancel.Focus()
                                End If
                            Else
                                btnOk.Enabled = False
                                Me.AcceptButton = btnCancel
                                'btnCancel.Focus()
                            End If
                        Else
                            btnOk.Enabled = False
                            Me.AcceptButton = btnCancel
                            'btnCancel.Focus()
                        End If
                    Else
                        btnOk.Enabled = False
                        Me.AcceptButton = btnCancel
                        'btnCancel.Focus()
                    End If
                Else
                    btnOk.Enabled = False
                    Me.AcceptButton = btnCancel
                    'btnCancel.Focus()
                End If
            Else
                btnOk.Enabled = False
                Me.AcceptButton = btnCancel
                'btnCancel.Focus()
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
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try

    End Sub

    Private Sub txtLampCurrent_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLampCurrent.TextChanged
        '=====================================================================
        ' Procedure Name        : txtLampCurrent_TextChanged
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
        Call Check_OK_Button()
        ''call a event for OK button.
    End Sub

    Private Sub txtSlitWidth_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSlitWidth.TextChanged
        '=====================================================================
        ' Procedure Name        : Check_OK_Button
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
        Call Check_OK_Button()
        ''call a event for OK button.
    End Sub

    Private Function funcOK(ByVal blnOk As Boolean)
        Dim objWait As New CWaitCursor
        Dim intCount As Integer
        Dim intElementID As Integer
        Dim intLampNo As Integer
        Dim dblWV As Double
        Dim objDtWv As New DataTable
        Dim dblCurrent As Double
        Dim dblSlitWidth As Double
        Try
            '---added by deepak on 03.09.07
            Dim intCounter As Integer
            For intCounter = 0 To gobjInst.Lamp.LampParametersCollection.Count - 1
                ''LampParametersCollection obj to collection
                If (intCounter + 1) = gobjInst.Lamp_Position Then
                    gobjfrmStatus.lblElementName.Text = gobjInst.Lamp.LampParametersCollection.item(intCounter).ElementName
                    Exit For
                End If
            Next
            '------------

            intElementID = cmbElementName.SelectedValue

            If txtTurretNum.Text = "" Or txtLampCurrent.Text = "" Or txtSlitWidth.Text = "" Then
                ''check all the value should be enterd
                gobjMessageAdapter.ShowMessage(constFieldsRequired)
                Exit Function 'Saurabh
                Application.DoEvents()
            End If

            If Not txtTurretNum.Text < 7 And txtTurretNum.Text > 0 Then
                ''set a range for turrt no (1-6)
                gobjMessageAdapter.ShowMessage(constEnterTurretNo)
                Exit Function 'Saurabh
                Application.DoEvents()
            End If

            '******************************************************************
            '----Added by Mangesh on 29-Mar-2007 for updating the gobjInst
            '--- with new Instrument Settings
            '******************************************************************
            intLampNo = CInt(txtTurretNum.Text)
            dblWV = Val(cmbWV.Text)
            dblCurrent = Val(txtLampCurrent.Text)
            dblSlitWidth = Val(txtSlitWidth.Text)

            ''getting some value from screen to temp variables

            '---Sets changed Wavelength
            If (gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).Wavelength <> dblWV) Then
                gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).Wavelength = dblWV
            End If

            'condition added by deepak on 24.07.07
            If (gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).Wavelength < gstructSettings.WavelengthRange.WvLowerBound Or gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).Wavelength > gstructSettings.WavelengthRange.WvUpperBound) Then
                ''set a wavelength range
                gobjMessageAdapter.ShowMessage("Wavelength entry error", "ENTRY", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
                Application.DoEvents()
                ''allow application to perfrom its panding work
                Exit Function
            End If

            'If (gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).Wavelength < 190 Or gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).Wavelength > 900) Then
            '    gobjMessageAdapter.ShowMessage("Wavelength entry error", "ENTRY", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
            '    Application.DoEvents()
            '    Exit Sub
            'End If

            '---Sets changed Lamp Current
            If (gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).Current <> dblCurrent) Then
                gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).Current = dblCurrent
            End If

            '---Sets changed Slit Width
            If (gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).SlitWidth <> dblSlitWidth) Then
                gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).SlitWidth = dblSlitWidth
            End If

            objDtWv = gobjClsAAS203.funcGetElementWavelengths(intElementID)

            If Not IsNothing(gobjNewMethod) Then
                If Not IsNothing(gobjNewMethod.InstrumentCondition) Then
                    gobjNewMethod.InstrumentCondition.ElementID = intElementID
                    gobjNewMethod.InstrumentCondition.LampCurrent = CDbl(Trim(txtLampCurrent.Text))
                    gobjNewMethod.InstrumentCondition.SelectedWavelengthID = cmbWV.SelectedValue
                    gobjNewMethod.InstrumentCondition.SlitWidth = CDbl(Trim(txtSlitWidth.Text))
                    gobjNewMethod.InstrumentCondition.LampNumber = intLampNo
                    gobjNewMethod.InstrumentCondition.TurretNumber = intLampNo
                    ''get all current parameter in to gobjNewMethod object

                    If Not objDtWv Is Nothing Then
                        gobjNewMethod.InstrumentCondition.Wavelength = objDtWv
                    End If
                End If
                For intCount = 0 To gobjMethodCollection.Count - 1
                    ''store method info in data structure

                    If gobjMethodCollection.item(intCount).MethodID = gobjNewMethod.MethodID Then
                        gobjMethodCollection.item(intCount).InstrumentCondition = gobjNewMethod.InstrumentCondition.Clone()
                        gobjMethodCollection.item(intCount).DateOfModification = DateTime.Now
                        gobjNewMethod.DateOfModification = DateTime.Now
                    End If
                Next

                If blnOk = True Then
                    If gobjNewMethod.OperationMode = EnumOperationMode.MODE_AA Or gobjNewMethod.OperationMode = EnumOperationMode.MODE_AABGC Then
                        gobjNewMethod.InstrumentCondition.IsOptimize = False
                    End If
                End If

                'Call funcSerialize(ConstMethodsFileName, gobjMethodCollection)
                'Added By Pankaj on 23 May 07 for adding method of inactive mode
                'gobjchkActiveMethod.fillInstruments = True '27.07.07
                'If (gobjchkActiveMethod.fillInstruments = True And gobjchkActiveMethod.fillParameters = True And gobjchkActiveMethod.fillStdConcentration = True And gobjchkActiveMethod.CancelMethod = True And gobjchkActiveMethod.NewMethod = True) Then
                If blnOk = True Then
                    If (gobjchkActiveMethod.fillStdConcentration = True And gobjchkActiveMethod.CancelMethod = True And gobjchkActiveMethod.NewMethod = True) Then
                        gobjchkActiveMethod.NewMethod = False
                        gobjchkActiveMethod.CancelMethod = False
                        'gobjchkActiveMethod.fillInstruments = False  '27.07.07
                        'gobjchkActiveMethod.fillParameters = False   '27.07.07
                        gobjchkActiveMethod.fillStdConcentration = False
                        gobjNewMethod.Status = True
                        gobjMethodCollection.Add(gobjNewMethod)
                    End If
                End If

                Call funcSaveAllMethods(gobjMethodCollection)
                ''now save a method with current info to data structure
                RaiseEvent MethodInstrumentSettingsChanged()
                ''this is a event which called when method setting is being changed 
                ''it update a current info in method
            End If

            'If Else is added by Saurabh
            'If gstructSettings.ExeToRun = EnumApplicationMode.AAS Then   'Added by Saurabh
            If gstructSettings.ExeToRun = EnumApplicationMode.AAS Then
                Call funcSaveInstStatus()
            End If
            ''To serialize the object gobjinst with current instrument status


            'Else
            If gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then
                gintTurretToOptimizeForServiceUtility = CInt(txtTurretNum.Text)
            End If

            'End If
            'Call funcSaveInstStatus()  'Commented and added this function in the above else part by Saurabh

            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                If Not IsNothing(gobjNewMethod) Then    'Checked by Saurabh 25.06.07
                    ''now show the current status of instrument on a status form
                    gobjfrmStatus.ElementName = CStr(gobjClsAAS203.funcGetElement(gobjNewMethod.InstrumentCondition.ElementID).Rows(0).Item("NAME"))
                    gobjfrmStatus.TurretNumber = gobjNewMethod.InstrumentCondition.TurretNumber
                    gobjInst.Lamp_Position = gobjNewMethod.InstrumentCondition.TurretNumber '---11.09.09
                End If
            End If

            '---kept for service mode
            gblnIsInstrumentConditionsActive = True

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
            objWait.Dispose()
            '---------------------------------------------------------
        End Try

    End Function

#End Region
End Class

