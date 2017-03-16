Public Class frmCoordinatePositions
    Inherits System.Windows.Forms.Form
    Public mintXCoordinate As Integer
    Public mintYCoordinate As Integer

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal mintx As Integer, ByVal minty As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        mintXCoordinate = mintx
        mintYCoordinate = minty
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblXAxis As System.Windows.Forms.Label
    Friend WithEvents lblYAxis As System.Windows.Forms.Label
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtYCoordinate As NumberValidator.NumberValidator
    Friend WithEvents txtXCoordinate As NumberValidator.NumberValidator
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCoordinatePositions))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtXCoordinate = New NumberValidator.NumberValidator
        Me.txtYCoordinate = New NumberValidator.NumberValidator
        Me.lblYAxis = New System.Windows.Forms.Label
        Me.lblXAxis = New System.Windows.Forms.Label
        Me.btnOk = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtXCoordinate)
        Me.GroupBox1.Controls.Add(Me.txtYCoordinate)
        Me.GroupBox1.Controls.Add(Me.lblYAxis)
        Me.GroupBox1.Controls.Add(Me.lblXAxis)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(272, 136)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Coordinates"
        '
        'txtXCoordinate
        '
        Me.txtXCoordinate.DigitsAfterDecimalPoint = 0
        Me.txtXCoordinate.ErrorColor = System.Drawing.Color.Empty
        Me.txtXCoordinate.ErrorMessage = Nothing
        Me.txtXCoordinate.Location = New System.Drawing.Point(161, 36)
        Me.txtXCoordinate.MaximumRange = 0
        Me.txtXCoordinate.MinimumRange = 0
        Me.txtXCoordinate.Name = "txtXCoordinate"
        Me.txtXCoordinate.RangeValidation = False
        Me.txtXCoordinate.Size = New System.Drawing.Size(80, 21)
        Me.txtXCoordinate.TabIndex = 5
        Me.txtXCoordinate.Text = ""
        Me.txtXCoordinate.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly
        '
        'txtYCoordinate
        '
        Me.txtYCoordinate.DigitsAfterDecimalPoint = 0
        Me.txtYCoordinate.ErrorColor = System.Drawing.Color.Empty
        Me.txtYCoordinate.ErrorMessage = Nothing
        Me.txtYCoordinate.Location = New System.Drawing.Point(161, 92)
        Me.txtYCoordinate.MaximumRange = 0
        Me.txtYCoordinate.MinimumRange = 0
        Me.txtYCoordinate.Name = "txtYCoordinate"
        Me.txtYCoordinate.RangeValidation = False
        Me.txtYCoordinate.Size = New System.Drawing.Size(80, 21)
        Me.txtYCoordinate.TabIndex = 4
        Me.txtYCoordinate.Text = ""
        Me.txtYCoordinate.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly
        '
        'lblYAxis
        '
        Me.lblYAxis.Location = New System.Drawing.Point(38, 88)
        Me.lblYAxis.Name = "lblYAxis"
        Me.lblYAxis.Size = New System.Drawing.Size(108, 24)
        Me.lblYAxis.TabIndex = 1
        Me.lblYAxis.Text = "Enter Y Position :"
        Me.lblYAxis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblXAxis
        '
        Me.lblXAxis.Location = New System.Drawing.Point(38, 32)
        Me.lblXAxis.Name = "lblXAxis"
        Me.lblXAxis.Size = New System.Drawing.Size(108, 24)
        Me.lblXAxis.TabIndex = 0
        Me.lblXAxis.Text = "Enter X Position :"
        Me.lblXAxis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnOk
        '
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnOk.Image = CType(resources.GetObject("btnOk.Image"), System.Drawing.Image)
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(112, 144)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(72, 32)
        Me.btnOk.TabIndex = 1
        Me.btnOk.Text = "&Ok"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(192, 144)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(72, 32)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmCoordinatePositions
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(274, 183)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCoordinatePositions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmCoordinatePositions"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Private Sub txtXCoordinate_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtXCoordinate.KeyUp
    '    mfuncAceptInteger(txtXCoordinate, e)
    'End Sub

    'Private Sub txtYCoordinate_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtYCoordinate.KeyUp
    '    mfuncAceptInteger(txtYCoordinate, e)
    'End Sub

    Private Sub frmCoordinatePositions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtXCoordinate.Text = mintXCoordinate.ToString
        txtYCoordinate.Text = mintYCoordinate.ToString
    End Sub
    Private Function funcValidation()
        Try
            If Val(txtXCoordinate.Text) > 12 Or Val(txtXCoordinate.Text) < 0 Then
                'gFuncShowMessage("Invalid X-Coordinate", "Enter the X coordinate between 0 and 12", EnumMessageType.Information)
                Call gobjMessageAdapter.ShowMessage(constAutoSamplerXaxisValue)
                txtXCoordinate.Focus()
                Return False
            End If
            If Val(txtYCoordinate.Text) > 5 Or Val(txtYCoordinate.Text) < 0 Then
                'gFuncShowMessage("Invalid Y-Coordinate", "Enter the Y coordinate between 0 and 5", EnumMessageType.Information)
                Call gobjMessageAdapter.ShowMessage(constAutoSamplerYaxisValue)
                txtYCoordinate.Focus()
                Return False
            End If
            Return True

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

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If Not funcValidation() Then
            Me.DialogResult = DialogResult.None
        Else
            mintXCoordinate = Val(txtXCoordinate.Text)
            mintYCoordinate = Val(txtYCoordinate.Text)
            Me.DialogResult = DialogResult.OK
            ' Me.Close()
        End If

    End Sub
End Class
