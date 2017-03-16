Public Class frmAboutUs
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
    Friend WithEvents btnOK As NETXP.Controls.XPButton
    Friend WithEvents ValueEditor1 As ValueEditor.ValueEditor
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAboutUs))
        Me.btnOK = New NETXP.Controls.XPButton
        Me.ValueEditor1 = New ValueEditor.ValueEditor
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Image = CType(resources.GetObject("btnOK.Image"), System.Drawing.Image)
        Me.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOK.Location = New System.Drawing.Point(450, 388)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(86, 32)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "&OK"
        '
        'ValueEditor1
        '
        Me.ValueEditor1.BackColor = System.Drawing.Color.Gray
        Me.ValueEditor1.BackgroundColor = System.Drawing.Color.Gray
        Me.ValueEditor1.ButtonClicked = ValueEditor.ValueEditor.EnumValueEditorButtons.MainButton
        Me.ValueEditor1.ChangeFactor = 0.1
        Me.ValueEditor1.DecimalPlace = 0
        Me.ValueEditor1.DnButtonText = ""
        Me.ValueEditor1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ValueEditor1.ForegroundColor = System.Drawing.SystemColors.ControlText
        Me.ValueEditor1.IsReverseOperation = False
        Me.ValueEditor1.IsUpDownButtonToBeDisabledOnValueChange = False
        Me.ValueEditor1.Location = New System.Drawing.Point(62, 50)
        Me.ValueEditor1.MaxValue = 1000
        Me.ValueEditor1.MinValue = 0
        Me.ValueEditor1.Name = "ValueEditor1"
        Me.ValueEditor1.Size = New System.Drawing.Size(102, 16)
        Me.ValueEditor1.TabIndex = 1
        Me.ValueEditor1.UpButtonText = ""
        Me.ValueEditor1.Value = 0
        Me.ValueEditor1.ValueEditorEnabled = True
        Me.ValueEditor1.ValueEditorFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.NumericUpDown1.Location = New System.Drawing.Point(80, 150)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(68, 20)
        Me.NumericUpDown1.TabIndex = 2
        '
        'frmAboutUs
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.CancelButton = Me.btnOK
        Me.ClientSize = New System.Drawing.Size(550, 478)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.ValueEditor1)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAboutUs"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About Us"
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    WithEvents obj As New frmEditValues
    Private MouseOffset As Point
    Private isMouseDown As Boolean = False

    Private Sub frmAboutUs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '-----------------------------------------------------------------
        'Procedure Name         :   frmAboutUs_Load
        'Description            :   do some initialisation here for form load.        
        'Parameters             :   None
        'Time/Date              :   25/9/06
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Praveen
        '-----------------------------------------------------------------
        Dim myPen As New System.Drawing.Pen(System.Drawing.Color.Red)
        Dim formGraphics As System.Drawing.Graphics
        Try
            If Not designmode Then
                formGraphics = Me.CreateGraphics()
                formGraphics.DrawLine(myPen, 150, 150, 200, 200)

                myPen.Dispose()
                formGraphics.Dispose()
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

    Private Sub XpButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        '-----------------------------------------------------------------
        'Procedure Name         :   XpButton1_Click
        'Description            :   to close the form       
        'Parameters             :   None
        'Time/Date              :   25/9/06
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Praveen
        '-----------------------------------------------------------------
        Me.Close()
    End Sub

    Private Sub Form3_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        '-----------------------------------------------------------------
        'Procedure Name         :   Form3_MouseDown
        'Description            :   handle a mouse down event.    
        'Parameters             :   None
        'Time/Date              :   25/9/06
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Praveen
        '-----------------------------------------------------------------
        Dim xOffset As Integer
        Dim yOffset As Integer
        Try
            If e.Button = MouseButtons.Left Then
                xOffset = -e.X - SystemInformation.FrameBorderSize.Width
                yOffset = -e.Y - SystemInformation.CaptionHeight - SystemInformation.FrameBorderSize.Height
                MouseOffset = New Point(xOffset, yOffset)
                isMouseDown = True
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

    Private Sub Form3_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        '-----------------------------------------------------------------
        'Procedure Name         :   Form3_MouseDown
        'Description            :   handle a mouse move event.    
        'Parameters             :   None
        'Time/Date              :   25/9/06
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Praveen
        '-----------------------------------------------------------------
        Try
            If isMouseDown Then
                Dim mousePos As Point = Control.MousePosition
                mousePos.Offset(MouseOffset.X, MouseOffset.Y)
                Location = mousePos
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

    Private Sub Form3_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
        '-----------------------------------------------------------------
        'Procedure Name         :   Form3_MouseUp
        'Description            :   handle a mouse up event.    
        'Parameters             :   None
        'Time/Date              :   25/9/06
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Praveen
        '-----------------------------------------------------------------
        Try
            If e.Button = MouseButtons.Left Then
                isMouseDown = False
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

    Private Sub ValueEditor1_click() Handles ValueEditor1.ValueEditorClick
        '-----------------------------------------------------------------
        'Procedure Name         :   ValueEditor1_click
        'Description            :   handle a value editor click event.    
        'Parameters             :   None
        'Time/Date              :   25/9/06
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Praveen
        '-----------------------------------------------------------------
        Try
            If obj.ShowDialog() = DialogResult.Cancel Then
                Exit Sub
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

    Private Sub mobjfrmEditValues_ReturnValue(ByVal dblValue As Double, ByVal intValue1 As Integer) 'Handles obj.ReturnValue
        '-----------------------------------------------------------------
        'Procedure Name         :   mobjfrmEditValues_ReturnValue
        'Description            :   this will set a return value for EDIT value form.   
        'Parameters             :   None
        'Time/Date              :   25/9/06
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Praveen
        '-----------------------------------------------------------------
        Try
            ValueEditor1.Value = dblValue
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

    Private Sub ValueEditor1_click(ByVal a As Double) Handles ValueEditor1.ValueEditorValueChanged

    End Sub


End Class
