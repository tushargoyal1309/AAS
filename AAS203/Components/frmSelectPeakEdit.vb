
Public Class frmSelectPeakEdit
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
        CurveNames.Dispose()
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents cmbCurveName As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CustomPanelBackground As GradientPanel.CustomPanel
    Friend WithEvents btnOk As NETXP.Controls.XPButton
    Friend WithEvents btnCancel As NETXP.Controls.XPButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSelectPeakEdit))
        Me.cmbCurveName = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.CustomPanelBackground = New GradientPanel.CustomPanel
        Me.btnCancel = New NETXP.Controls.XPButton
        Me.btnOk = New NETXP.Controls.XPButton
        Me.CustomPanelBackground.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbCurveName
        '
        Me.cmbCurveName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCurveName.Location = New System.Drawing.Point(32, 53)
        Me.cmbCurveName.Name = "cmbCurveName"
        Me.cmbCurveName.Size = New System.Drawing.Size(168, 21)
        Me.cmbCurveName.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(32, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Select Curve Name"
        '
        'CustomPanelBackground
        '
        Me.CustomPanelBackground.BackColor = System.Drawing.Color.Gainsboro
        Me.CustomPanelBackground.BackColor2 = System.Drawing.Color.White
        Me.CustomPanelBackground.Controls.Add(Me.btnCancel)
        Me.CustomPanelBackground.Controls.Add(Me.btnOk)
        Me.CustomPanelBackground.Controls.Add(Me.cmbCurveName)
        Me.CustomPanelBackground.Controls.Add(Me.Label1)
        Me.CustomPanelBackground.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanelBackground.DockPadding.All = 1
        Me.CustomPanelBackground.GradientMode = GradientPanel.LinearGradientMode.Vertical
        Me.CustomPanelBackground.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanelBackground.Name = "CustomPanelBackground"
        Me.CustomPanelBackground.Size = New System.Drawing.Size(218, 135)
        Me.CustomPanelBackground.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(136, 104)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(24, 16)
        Me.btnCancel.TabIndex = 22
        Me.btnCancel.Text = "&C"
        '
        'btnOk
        '
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Image = CType(resources.GetObject("btnOk.Image"), System.Drawing.Image)
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(72, 95)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(90, 30)
        Me.btnOk.TabIndex = 1
        Me.btnOk.Text = "&OK"
        '
        'frmSelectPeakEdit
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(218, 135)
        Me.Controls.Add(Me.CustomPanelBackground)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSelectPeakEdit"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Select Curve for Peak Edit"
        Me.TopMost = True
        Me.CustomPanelBackground.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Private Class Variables "

    Private CurveNames As New DataTable

#End Region

#Region " Public Properties "

    Public WriteOnly Property CurveTable() As DataTable
        Set(ByVal Value As DataTable)
            CurveNames = Value.Copy()
        End Set
    End Property

#End Region

#Region " Private Functions "

    Private Sub frmSelectPeakEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        btnOk.BringToFront()
        AddHandler btnOk.Click, AddressOf subbtnOk_Click

        If CurveNames.Rows.Count > 0 Then
            cmbCurveName.DataSource = CurveNames
            cmbCurveName.ValueMember = CurveNames.Columns.Item(0).ColumnName
            cmbCurveName.DisplayMember = CurveNames.Columns.Item(1).ColumnName
        End If

    End Sub

    Private Sub subbtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
            '---------------------------------------------------------
        End Try
    End Sub

#End Region

End Class
