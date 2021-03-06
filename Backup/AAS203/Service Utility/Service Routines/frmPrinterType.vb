Public Class frmPrinterType
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As NETXP.Controls.XPButton
    Friend WithEvents btnOk As NETXP.Controls.XPButton
    Friend WithEvents rbColor As System.Windows.Forms.RadioButton
    Friend WithEvents lblPrinterType As System.Windows.Forms.Label
    Friend WithEvents rbNormal As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents mnuAutoIgnition As NETXP.Controls.Bars.CommandBar
    Friend WithEvents mnuIgnite As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuExtinguish As NETXP.Controls.Bars.CommandBarButtonItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPrinterType))
        Me.CustomPanel1 = New GradientPanel.CustomPanel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.mnuAutoIgnition = New NETXP.Controls.Bars.CommandBar
        Me.mnuIgnite = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuExtinguish = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.btnCancel = New NETXP.Controls.XPButton
        Me.btnOk = New NETXP.Controls.XPButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.rbColor = New System.Windows.Forms.RadioButton
        Me.lblPrinterType = New System.Windows.Forms.Label
        Me.rbNormal = New System.Windows.Forms.RadioButton
        Me.CustomPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.mnuAutoIgnition, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CustomPanel1
        '
        Me.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanel1.Controls.Add(Me.Panel2)
        Me.CustomPanel1.Controls.Add(Me.btnCancel)
        Me.CustomPanel1.Controls.Add(Me.btnOk)
        Me.CustomPanel1.Controls.Add(Me.Panel1)
        Me.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanel1.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanel1.Name = "CustomPanel1"
        Me.CustomPanel1.Size = New System.Drawing.Size(292, 119)
        Me.CustomPanel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.mnuAutoIgnition)
        Me.Panel2.Location = New System.Drawing.Point(48, 112)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(216, 56)
        Me.Panel2.TabIndex = 45
        '
        'mnuAutoIgnition
        '
        Me.mnuAutoIgnition.BackColor = System.Drawing.Color.Transparent
        Me.mnuAutoIgnition.CustomizeText = "&Customize Toolbar..."
        Me.mnuAutoIgnition.FullRow = True
        Me.mnuAutoIgnition.ID = 5117
        Me.mnuAutoIgnition.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuIgnite, Me.mnuExtinguish})
        Me.mnuAutoIgnition.Location = New System.Drawing.Point(66, 16)
        Me.mnuAutoIgnition.Margins.Bottom = 1
        Me.mnuAutoIgnition.Margins.Left = 1
        Me.mnuAutoIgnition.Margins.Right = 1
        Me.mnuAutoIgnition.Margins.Top = 1
        Me.mnuAutoIgnition.Name = "mnuAutoIgnition"
        Me.mnuAutoIgnition.Size = New System.Drawing.Size(112, 23)
        Me.mnuAutoIgnition.Style = NETXP.Controls.Bars.CommandBarStyle.Menu
        Me.mnuAutoIgnition.TabIndex = 2
        Me.mnuAutoIgnition.TabStop = False
        Me.mnuAutoIgnition.Text = "AutoIgnition"
        '
        'mnuIgnite
        '
        Me.mnuIgnite.Shortcut = System.Windows.Forms.Shortcut.CtrlI
        Me.mnuIgnite.Text = "Ignite"
        '
        'mnuExtinguish
        '
        Me.mnuExtinguish.PadHorizontal = 5
        Me.mnuExtinguish.Shortcut = System.Windows.Forms.Shortcut.CtrlE
        Me.mnuExtinguish.Text = "Extinguish"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(152, 72)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 34)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancel"
        '
        'btnOk
        '
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Image = CType(resources.GetObject("btnOk.Image"), System.Drawing.Image)
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(56, 72)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(86, 34)
        Me.btnOk.TabIndex = 9
        Me.btnOk.Text = "OK"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.rbColor)
        Me.Panel1.Controls.Add(Me.lblPrinterType)
        Me.Panel1.Controls.Add(Me.rbNormal)
        Me.Panel1.Location = New System.Drawing.Point(16, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(256, 48)
        Me.Panel1.TabIndex = 0
        '
        'rbColor
        '
        Me.rbColor.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbColor.Location = New System.Drawing.Point(103, 13)
        Me.rbColor.Name = "rbColor"
        Me.rbColor.Size = New System.Drawing.Size(56, 24)
        Me.rbColor.TabIndex = 1
        Me.rbColor.Text = "Color"
        '
        'lblPrinterType
        '
        Me.lblPrinterType.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrinterType.Location = New System.Drawing.Point(8, 14)
        Me.lblPrinterType.Name = "lblPrinterType"
        Me.lblPrinterType.Size = New System.Drawing.Size(72, 20)
        Me.lblPrinterType.TabIndex = 0
        Me.lblPrinterType.Text = "Printer Type"
        Me.lblPrinterType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rbNormal
        '
        Me.rbNormal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbNormal.Location = New System.Drawing.Point(176, 13)
        Me.rbNormal.Name = "rbNormal"
        Me.rbNormal.Size = New System.Drawing.Size(64, 24)
        Me.rbNormal.TabIndex = 1
        Me.rbNormal.Text = "Normal"
        '
        'frmPrinterType
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(292, 119)
        Me.Controls.Add(Me.CustomPanel1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrinterType"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Printer Type"
        Me.CustomPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.mnuAutoIgnition, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If rbColor.Checked = True Then
            gstructSettings.blnSelectColorPrinter = True
        ElseIf rbNormal.Checked = True Then
            gstructSettings.blnSelectColorPrinter = False
        End If
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub frmPrinterType_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If gstructSettings.blnSelectColorPrinter = True Then
            rbColor.Checked = True
            'gstructSettings.Enable21CFR = False
            '       Call gfuncSetEnable21CFRToINI(gstructApplicationSettings.Enable21CFR)
        Else
            rbNormal.Checked = True
            'gstructSettings.Enable21CFR = True
            '        Call gfuncSetEnable21CFRToINI(gstructApplicationSettings.Enable21CFR)
        End If
        AddHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click
        AddHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
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
            RemoveHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
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
            AddHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnExtinguish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
            RemoveHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click
            'If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
            'mobjController.Cancel()
            Application.DoEvents()

            Call gobjClsAAS203.funcIgnite(False)

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
            AddHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click
            '---------------------------------------------------------
        End Try
    End Sub

End Class
