Public Class frmTurretElements
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
    Friend WithEvents lblLamp1 As System.Windows.Forms.Label
    Friend WithEvents lblLamp2 As System.Windows.Forms.Label
    Friend WithEvents lblLamp3 As System.Windows.Forms.Label
    Friend WithEvents lblLamp4 As System.Windows.Forms.Label
    Friend WithEvents lblLamp5 As System.Windows.Forms.Label
    Friend WithEvents lblLamp6 As System.Windows.Forms.Label
    Friend WithEvents lblLamp7 As System.Windows.Forms.Label
    Friend WithEvents lblLamp8 As System.Windows.Forms.Label
    Friend WithEvents lblLamp9 As System.Windows.Forms.Label
    Friend WithEvents lblLamp10 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblLamp1 = New System.Windows.Forms.Label()
        Me.lblLamp2 = New System.Windows.Forms.Label()
        Me.lblLamp3 = New System.Windows.Forms.Label()
        Me.lblLamp4 = New System.Windows.Forms.Label()
        Me.lblLamp5 = New System.Windows.Forms.Label()
        Me.lblLamp6 = New System.Windows.Forms.Label()
        Me.lblLamp7 = New System.Windows.Forms.Label()
        Me.lblLamp8 = New System.Windows.Forms.Label()
        Me.lblLamp9 = New System.Windows.Forms.Label()
        Me.lblLamp10 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblLamp1
        '
        Me.lblLamp1.BackColor = System.Drawing.Color.Gainsboro
        Me.lblLamp1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLamp1.Location = New System.Drawing.Point(82, 34)
        Me.lblLamp1.Name = "lblLamp1"
        Me.lblLamp1.Size = New System.Drawing.Size(64, 24)
        Me.lblLamp1.TabIndex = 0
        Me.lblLamp1.Text = "1-Cu"
        Me.lblLamp1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLamp2
        '
        Me.lblLamp2.BackColor = System.Drawing.Color.Gainsboro
        Me.lblLamp2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLamp2.Location = New System.Drawing.Point(142, 49)
        Me.lblLamp2.Name = "lblLamp2"
        Me.lblLamp2.Size = New System.Drawing.Size(64, 24)
        Me.lblLamp2.TabIndex = 1
        Me.lblLamp2.Text = "2-Al"
        Me.lblLamp2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLamp3
        '
        Me.lblLamp3.BackColor = System.Drawing.Color.Gainsboro
        Me.lblLamp3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLamp3.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblLamp3.Location = New System.Drawing.Point(159, 94)
        Me.lblLamp3.Name = "lblLamp3"
        Me.lblLamp3.Size = New System.Drawing.Size(64, 24)
        Me.lblLamp3.TabIndex = 2
        Me.lblLamp3.Text = "3-Multi"
        Me.lblLamp3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLamp4
        '
        Me.lblLamp4.BackColor = System.Drawing.Color.Gainsboro
        Me.lblLamp4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLamp4.Location = New System.Drawing.Point(142, 133)
        Me.lblLamp4.Name = "lblLamp4"
        Me.lblLamp4.Size = New System.Drawing.Size(64, 24)
        Me.lblLamp4.TabIndex = 3
        Me.lblLamp4.Text = "4-Cu"
        Me.lblLamp4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLamp5
        '
        Me.lblLamp5.BackColor = System.Drawing.Color.Gainsboro
        Me.lblLamp5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLamp5.Location = New System.Drawing.Point(120, 168)
        Me.lblLamp5.Name = "lblLamp5"
        Me.lblLamp5.Size = New System.Drawing.Size(64, 24)
        Me.lblLamp5.TabIndex = 4
        Me.lblLamp5.Text = "5-Pb"
        Me.lblLamp5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLamp6
        '
        Me.lblLamp6.BackColor = System.Drawing.Color.Gainsboro
        Me.lblLamp6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLamp6.Location = New System.Drawing.Point(73, 192)
        Me.lblLamp6.Name = "lblLamp6"
        Me.lblLamp6.Size = New System.Drawing.Size(64, 24)
        Me.lblLamp6.TabIndex = 5
        Me.lblLamp6.Text = "6-As"
        Me.lblLamp6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLamp7
        '
        Me.lblLamp7.BackColor = System.Drawing.Color.Gainsboro
        Me.lblLamp7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLamp7.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblLamp7.Location = New System.Drawing.Point(12, 168)
        Me.lblLamp7.Name = "lblLamp7"
        Me.lblLamp7.Size = New System.Drawing.Size(64, 24)
        Me.lblLamp7.TabIndex = 6
        Me.lblLamp7.Text = "7-Re"
        Me.lblLamp7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLamp8
        '
        Me.lblLamp8.BackColor = System.Drawing.Color.Gainsboro
        Me.lblLamp8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLamp8.Location = New System.Drawing.Point(0, 131)
        Me.lblLamp8.Name = "lblLamp8"
        Me.lblLamp8.Size = New System.Drawing.Size(64, 24)
        Me.lblLamp8.TabIndex = 7
        Me.lblLamp8.Text = "8-Rh"
        Me.lblLamp8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLamp9
        '
        Me.lblLamp9.BackColor = System.Drawing.Color.Gainsboro
        Me.lblLamp9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLamp9.Location = New System.Drawing.Point(0, 94)
        Me.lblLamp9.Name = "lblLamp9"
        Me.lblLamp9.Size = New System.Drawing.Size(64, 24)
        Me.lblLamp9.TabIndex = 8
        Me.lblLamp9.Text = "9-Mh"
        Me.lblLamp9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLamp10
        '
        Me.lblLamp10.BackColor = System.Drawing.Color.Gainsboro
        Me.lblLamp10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLamp10.Location = New System.Drawing.Point(12, 49)
        Me.lblLamp10.Name = "lblLamp10"
        Me.lblLamp10.Size = New System.Drawing.Size(64, 24)
        Me.lblLamp10.TabIndex = 9
        Me.lblLamp10.Text = "10-Mn"
        Me.lblLamp10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Maroon
        Me.Button1.Location = New System.Drawing.Point(96, 94)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(30, 34)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "X"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'frmTurretElements
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(225, 225)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblLamp10)
        Me.Controls.Add(Me.lblLamp9)
        Me.Controls.Add(Me.lblLamp8)
        Me.Controls.Add(Me.lblLamp7)
        Me.Controls.Add(Me.lblLamp6)
        Me.Controls.Add(Me.lblLamp5)
        Me.Controls.Add(Me.lblLamp4)
        Me.Controls.Add(Me.lblLamp3)
        Me.Controls.Add(Me.lblLamp2)
        Me.Controls.Add(Me.lblLamp1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTurretElements"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TransparencyKey = System.Drawing.Color.Gainsboro
        Me.ResumeLayout(False)

    End Sub

    Private Sub frmTurretElements_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        '=====================================================================
        ' Procedure Name        : frmTurretElements_Paint
        ' Parameters Passed     : object,paint event args
        ' Returns               : 
        ' Purpose               : to draw the form in circular shape
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 09.09.08
        ' Revisions             : 
        '=====================================================================
        Dim gr As System.Drawing.Graphics = Me.CreateGraphics
        gr.FillEllipse(System.Drawing.Brushes.Gainsboro, 0, 0, Me.ClientSize.Width - 5, Me.ClientSize.Height - 5)
    End Sub

#End Region

#Region "Form Events"

    Private Sub frmTurretElements_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmTurretElements_Load
        ' Parameters Passed     : object,event args
        ' Returns               : 
        ' Purpose               : to display lamp positions in turret
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 09.09.08
        ' Revisions             : 
        '=====================================================================
        Try
            Dim intCount As Integer
            Dim ctrl As Control
            For Each ctrl In Me.Controls
                If TypeOf ctrl Is Label Then
                    CType(ctrl, Label).ForeColor = Color.Black
                End If
            Next
            For intCount = 0 To gobjInst.Lamp.LampParametersCollection.Count - 1
                If gobjInst.Lamp_Position = intCount + 1 Then
                    Select Case intCount + 1
                        Case 1
                            lblLamp1.ForeColor = Color.PaleVioletRed 'Color.LimeGreen  
                        Case 2
                            lblLamp2.ForeColor = Color.PaleVioletRed 'Color.LimeGreen  
                        Case 3
                            lblLamp3.ForeColor = Color.PaleVioletRed 'Color.LimeGreen  
                        Case 4
                            lblLamp4.ForeColor = Color.PaleVioletRed 'Color.LimeGreen  
                        Case 5
                            lblLamp5.ForeColor = Color.PaleVioletRed 'Color.LimeGreen  
                        Case 6
                            lblLamp6.ForeColor = Color.PaleVioletRed 'Color.LimeGreen  
                        Case 7
                            lblLamp7.ForeColor = Color.PaleVioletRed 'Color.LimeGreen  
                        Case 8
                            lblLamp8.ForeColor = Color.PaleVioletRed 'Color.LimeGreen  
                        Case 9
                            lblLamp9.ForeColor = Color.PaleVioletRed 'Color.LimeGreen  
                        Case 10
                            lblLamp10.ForeColor = Color.PaleVioletRed 'Color.LimeGreen 
                    End Select
                End If
                Select Case intCount + 1
                    Case 1
                        lblLamp1.Text = "1-" & gobjInst.Lamp.LampParametersCollection(intCount).ElementName
                    Case 2
                        lblLamp2.Text = "2-" & gobjInst.Lamp.LampParametersCollection(intCount).ElementName
                    Case 3
                        lblLamp3.Text = "3-" & gobjInst.Lamp.LampParametersCollection(intCount).ElementName
                    Case 4
                        lblLamp4.Text = "4-" & gobjInst.Lamp.LampParametersCollection(intCount).ElementName
                    Case 5
                        lblLamp5.Text = "5-" & gobjInst.Lamp.LampParametersCollection(intCount).ElementName
                    Case 6
                        lblLamp6.Text = "6-" & gobjInst.Lamp.LampParametersCollection(intCount).ElementName
                    Case 7
                        lblLamp7.Text = "7-" & gobjInst.Lamp.LampParametersCollection(intCount).ElementName
                    Case 8
                        lblLamp8.Text = "8-" & gobjInst.Lamp.LampParametersCollection(intCount).ElementName
                    Case 9
                        lblLamp9.Text = "9-" & gobjInst.Lamp.LampParametersCollection(intCount).ElementName
                    Case 10
                        lblLamp10.Text = "10-" & gobjInst.Lamp.LampParametersCollection(intCount).ElementName
                End Select
            Next

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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
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
    
End Class
