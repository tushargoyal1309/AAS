Imports AAS203.Common
Imports System.IO

Public Class frmBHParameter 'class behind the class
    Inherits System.Windows.Forms.Form

    Public BHStartScan As Double
    Public BHEndScan As Double

#Region "Private Variable"
    Dim mblnAvoidProcessing As Boolean
    ''bool flag 

#End Region

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub
    Public Sub New(ByVal RefobjParameter As Object)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        'SpectrumParameter = New Spectrum.UVSpectrumParameter

    End Sub
    'Public Sub New(ByVal RefobjParameter As Spectrum.EnergySpectrumParameter)
    '    MyBase.New()

    '    'This call is required by the Windows Form Designer.
    '    InitializeComponent()

    '    'Add any initialization after the InitializeComponent() call
    '    SpectrumParameter = New Spectrum.EnergySpectrumParameter
    '    'SpectrumParameter = New Object
    '    SpectrumParameter = RefobjParameter



    'End Sub
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
    Friend WithEvents btnOk As NETXP.Controls.XPButton
    Friend WithEvents btnCancel As NETXP.Controls.XPButton
    Friend WithEvents lblBHEnd As System.Windows.Forms.Label
    Friend WithEvents lblBHStart As System.Windows.Forms.Label
    Friend WithEvents txtBHStart As NumberValidator.NumberValidator
    Friend WithEvents txtBHEnd As NumberValidator.NumberValidator
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmBHParameter))
        Me.CustomPanel1 = New GradientPanel.CustomPanel
        Me.txtBHEnd = New NumberValidator.NumberValidator
        Me.txtBHStart = New NumberValidator.NumberValidator
        Me.btnOk = New NETXP.Controls.XPButton
        Me.btnCancel = New NETXP.Controls.XPButton
        Me.lblBHEnd = New System.Windows.Forms.Label
        Me.lblBHStart = New System.Windows.Forms.Label
        Me.CustomPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CustomPanel1
        '
        Me.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanel1.Controls.Add(Me.txtBHEnd)
        Me.CustomPanel1.Controls.Add(Me.txtBHStart)
        Me.CustomPanel1.Controls.Add(Me.btnOk)
        Me.CustomPanel1.Controls.Add(Me.btnCancel)
        Me.CustomPanel1.Controls.Add(Me.lblBHEnd)
        Me.CustomPanel1.Controls.Add(Me.lblBHStart)
        Me.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanel1.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanel1.Name = "CustomPanel1"
        Me.CustomPanel1.Size = New System.Drawing.Size(306, 151)
        Me.CustomPanel1.TabIndex = 0
        '
        'txtBHEnd
        '
        Me.txtBHEnd.DigitsAfterDecimalPoint = 0
        Me.txtBHEnd.ErrorColor = System.Drawing.Color.Empty
        Me.txtBHEnd.ErrorMessage = Nothing
        Me.txtBHEnd.Location = New System.Drawing.Point(232, 51)
        Me.txtBHEnd.MaximumRange = 6
        Me.txtBHEnd.MaxLength = 4
        Me.txtBHEnd.MinimumRange = 0
        Me.txtBHEnd.Name = "txtBHEnd"
        Me.txtBHEnd.RangeValidation = False
        Me.txtBHEnd.Size = New System.Drawing.Size(56, 20)
        Me.txtBHEnd.TabIndex = 18
        Me.txtBHEnd.Text = ""
        Me.txtBHEnd.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly
        '
        'txtBHStart
        '
        Me.txtBHStart.DigitsAfterDecimalPoint = 0
        Me.txtBHStart.ErrorColor = System.Drawing.Color.Empty
        Me.txtBHStart.ErrorMessage = Nothing
        Me.txtBHStart.Location = New System.Drawing.Point(232, 16)
        Me.txtBHStart.MaximumRange = 0
        Me.txtBHStart.MinimumRange = 0
        Me.txtBHStart.Name = "txtBHStart"
        Me.txtBHStart.RangeValidation = False
        Me.txtBHStart.Size = New System.Drawing.Size(56, 20)
        Me.txtBHStart.TabIndex = 17
        Me.txtBHStart.Text = ""
        Me.txtBHStart.ValidationType = NumberValidator.NumberValidator.Validations.AlphaNumeric
        '
        'btnOk
        '
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Image = CType(resources.GetObject("btnOk.Image"), System.Drawing.Image)
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(64, 96)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(86, 34)
        Me.btnOk.TabIndex = 15
        Me.btnOk.Text = "&OK"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(168, 96)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 34)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "&Cancel"
        '
        'lblBHEnd
        '
        Me.lblBHEnd.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBHEnd.Location = New System.Drawing.Point(13, 51)
        Me.lblBHEnd.Name = "lblBHEnd"
        Me.lblBHEnd.Size = New System.Drawing.Size(219, 16)
        Me.lblBHEnd.TabIndex = 1
        Me.lblBHEnd.Text = "Burner Height Scan End (0 - 6 mm)"
        '
        'lblBHStart
        '
        Me.lblBHStart.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBHStart.Location = New System.Drawing.Point(13, 19)
        Me.lblBHStart.Name = "lblBHStart"
        Me.lblBHStart.Size = New System.Drawing.Size(219, 16)
        Me.lblBHStart.TabIndex = 0
        Me.lblBHStart.Text = "Burner Height Scan Start (0 - 6 mm)"
        '
        'frmBHParameter
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(306, 151)
        Me.Controls.Add(Me.CustomPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBHParameter"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Change Scale"
        Me.CustomPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub funcfrmInitialise()

        '=====================================================================
        ' Procedure Name        : funcfrmInitialise
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : from Initialise 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : praveen
        '=====================================================================

        ''note:
        ''this is called when form is loaded .
        ''do some initialisation over here.
        Try


            If gintOptimisation = modGlobalDeclarations.EnumBH_FP_Opimisation.BurnerHeight Then
                ''check for burner optimization flag.
                ''if yes then set some validation here.
                lblBHStart.Text = "Burner Height Scan Start (0 - 6 mm)"
                lblBHEnd.Text = "Burner Height Scan End (0 - 6 mm)"
                txtBHStart.MaximumRange = 6.0
                txtBHStart.MinimumRange = 0.0
                txtBHEnd.MaximumRange = 6.0
                txtBHEnd.MinimumRange = 0.0

            ElseIf gintOptimisation = modGlobalDeclarations.EnumBH_FP_Opimisation.FuelPresure Then
                ''check for fuel presure
                ''and set a validation.
                lblBHStart.Text = "Fuel Scan Start (Low Fuel)"
                lblBHEnd.Text = "Fuel Scan End (High Fuel)"
                txtBHStart.MaximumRange = 5.0
                txtBHStart.MinimumRange = 1.0
                txtBHEnd.MaximumRange = 5.0
                txtBHEnd.MinimumRange = 0.0
            End If
            txtBHStart.DigitsAfterDecimalPoint = 2
            txtBHStart.RangeValidation = True
            txtBHStart.MaxLength = 6
            txtBHStart.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly

            txtBHEnd.DigitsAfterDecimalPoint = 2
            txtBHEnd.RangeValidation = True
            txtBHEnd.MaxLength = 6
            txtBHEnd.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly

            txtBHStart.Text = Format(BHStartScan, "0.0")
            txtBHEnd.Text = Format(BHEndScan, "0.0")

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

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        '=====================================================================
        ' Procedure Name        : btnOk_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : Set X & Y Axis
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is called when user click on ok button
        ''this is used to set a scale.
        Dim objWait As New CWaitCursor

        Try
            If funcSetScale() = True Then
                ''bool function for setting a scale.
                Me.DialogResult = DialogResult.OK
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
            End If

            '---------------------------------------------------------
        End Try
    End Sub

    Private Function funcSetScale() As Boolean
        '=====================================================================
        ' Procedure Name        : funcSetScale
        ' Parameters Passed     : 
        ' Returns               : True/False
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 31.12.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is called when user clicked on ok button for setting a scale .
        ''this will first check a validation of input value.
        ''the set it to data structure
        Dim objWait As New CWaitCursor
        Dim dblWvMin As Double
        Dim dblWvMax As Double
        Try
            If mblnAvoidProcessing = True Then
                ''check flag for avoiding a process
                Exit Function
            End If
            mblnAvoidProcessing = True
            Application.DoEvents()
            ''allow application to perfrom it panding work.

            'BHStartScan = CDbl(txtBHStart.Text)
            'BHEndScan = CDbl(txtBHEnd.Text)
            If CDbl(txtBHStart.Text) > CDbl(txtBHEnd.Text) Then
                ''check for min\max range
                gobjMessageAdapter.ShowMessage(constValueMinToMax)
                Return False
            End If
            ''Added by praveen Bcoz timescan mode is hanged if both value's are same
            If CDbl(txtBHStart.Text) = CDbl(txtBHEnd.Text) Then
                ''check for same range
                gobjMessageAdapter.ShowMessage(constValueMinToMax)
                Return False
            End If
            ''Ended by praveen
            '--- Check for Min and max range of start position 
            If txtBHStart.MinimumRange <= CDbl(txtBHStart.Text) And _
                txtBHStart.MaximumRange >= CDbl(txtBHStart.Text) Then
                BHStartScan = CDbl(txtBHStart.Text)
            Else
                gobjMessageAdapter.ShowMessage(constInvalidRange)
                Return False
            End If
            '--- Check for Min and max range of end position 
            If txtBHEnd.MaximumRange >= CDbl(txtBHEnd.Text) And _
            txtBHEnd.MinimumRange <= CDbl(txtBHEnd.Text) Then
                BHEndScan = CDbl(txtBHEnd.Text)
            Else
                gobjMessageAdapter.ShowMessage(constInvalidRange)
                Return False
            End If

            Me.Close()
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            mblnAvoidProcessing = False
            '---------------------------------------------------------
        End Try
    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        '=====================================================================
        ' Procedure Name        : btnCancel_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : Set X & Y Axis
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is called when user click on cancel button
        Dim objWait As New CWaitCursor

        Try
            If mblnAvoidProcessing = True Then
                ''check a flag for avoiding a process.
                Exit Sub
            End If

            Me.DialogResult = DialogResult.Cancel
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
            mblnAvoidProcessing = False
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If

            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub frmChangeScale_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmChangeScale_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : load the form object
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 12.12.06
        ' Revisions             : praveen
        '=====================================================================
        Dim objWait As New CWaitCursor
        ''note;
        ''this is called when change scale form is loaded.
        Try
            funcfrmInitialise()
            ''for initialisation of form.
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
                ''destructor.
            End If

            '---------------------------------------------------------
        End Try
    End Sub

End Class
