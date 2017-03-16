Imports AAS203.Common
Imports System.IO

Public Class frmParameter
    Inherits System.Windows.Forms.Form


    'Public SpectrumParameter As Object
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
        SpectrumParameter = New Spectrum.EnergySpectrumParameter
        'SpectrumParameter = New Object
        SpectrumParameter = RefobjParameter



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
    Friend WithEvents CustomPanel2 As GradientPanel.CustomPanel
    Friend WithEvents lblComments As System.Windows.Forms.Label
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents lblSampName As System.Windows.Forms.Label
    Friend WithEvents txtSampName As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmParameter))
        Me.CustomPanel1 = New GradientPanel.CustomPanel
        Me.CustomPanel2 = New GradientPanel.CustomPanel
        Me.lblSampName = New System.Windows.Forms.Label
        Me.lblComments = New System.Windows.Forms.Label
        Me.txtSampName = New System.Windows.Forms.TextBox
        Me.txtComments = New System.Windows.Forms.TextBox
        Me.btnOk = New NETXP.Controls.XPButton
        Me.btnCancel = New NETXP.Controls.XPButton
        Me.CustomPanel1.SuspendLayout()
        Me.CustomPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'CustomPanel1
        '
        Me.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanel1.Controls.Add(Me.CustomPanel2)
        Me.CustomPanel1.Controls.Add(Me.btnOk)
        Me.CustomPanel1.Controls.Add(Me.btnCancel)
        Me.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanel1.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanel1.Name = "CustomPanel1"
        Me.CustomPanel1.Size = New System.Drawing.Size(354, 183)
        Me.CustomPanel1.TabIndex = 0
        '
        'CustomPanel2
        '
        Me.CustomPanel2.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanel2.Controls.Add(Me.lblSampName)
        Me.CustomPanel2.Controls.Add(Me.lblComments)
        Me.CustomPanel2.Controls.Add(Me.txtSampName)
        Me.CustomPanel2.Controls.Add(Me.txtComments)
        Me.CustomPanel2.Location = New System.Drawing.Point(8, 8)
        Me.CustomPanel2.Name = "CustomPanel2"
        Me.CustomPanel2.Size = New System.Drawing.Size(336, 120)
        Me.CustomPanel2.TabIndex = 0
        '
        'lblSampName
        '
        Me.lblSampName.BackColor = System.Drawing.Color.AliceBlue
        Me.lblSampName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSampName.Location = New System.Drawing.Point(16, 19)
        Me.lblSampName.Name = "lblSampName"
        Me.lblSampName.Size = New System.Drawing.Size(96, 16)
        Me.lblSampName.TabIndex = 21
        Me.lblSampName.Text = "Sample Name"
        '
        'lblComments
        '
        Me.lblComments.BackColor = System.Drawing.Color.AliceBlue
        Me.lblComments.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComments.Location = New System.Drawing.Point(16, 55)
        Me.lblComments.Name = "lblComments"
        Me.lblComments.Size = New System.Drawing.Size(72, 16)
        Me.lblComments.TabIndex = 22
        Me.lblComments.Text = "Comments"
        '
        'txtSampName
        '
        Me.txtSampName.BackColor = System.Drawing.Color.White
        Me.txtSampName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSampName.Location = New System.Drawing.Point(120, 16)
        Me.txtSampName.MaxLength = 20
        Me.txtSampName.Name = "txtSampName"
        Me.txtSampName.Size = New System.Drawing.Size(200, 22)
        Me.txtSampName.TabIndex = 0
        Me.txtSampName.Text = ""
        '
        'txtComments
        '
        Me.txtComments.BackColor = System.Drawing.Color.White
        Me.txtComments.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComments.Location = New System.Drawing.Point(120, 48)
        Me.txtComments.MaxLength = 2000
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(200, 64)
        Me.txtComments.TabIndex = 1
        Me.txtComments.Text = ""
        '
        'btnOk
        '
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Image = CType(resources.GetObject("btnOk.Image"), System.Drawing.Image)
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(88, 136)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(86, 34)
        Me.btnOk.TabIndex = 1
        Me.btnOk.Text = "&OK"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(192, 136)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 34)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "&Cancel"
        '
        'frmParameter
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(354, 183)
        Me.Controls.Add(Me.CustomPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmParameter"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Scan Parameter"
        Me.CustomPanel1.ResumeLayout(False)
        Me.CustomPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Variable Declaration"
    Dim mblnAvoidProcessing As Boolean
    Public SpectrumParameter As Object
    'Public SpectrumParameter As Spectrum.EnergySpectrumParameter
#End Region

#Region " Private Constant"

   

#End Region

#Region " Form Events"

    Private Sub frmParameter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmParameter_Load
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
        ''note:
        ''this is called when the form is loaded.
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
            End If
            gobjMain.HideProgressBar()
            '---------------------------------------------------------
        End Try
    End Sub

#End Region

#Region " Private Functions"

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
        ''this is called during the loading of a form.

        Try

            'lblXAxisMin.Text = addataSpect.dblWvMin.ToString
            'lblXAxisMax.Text = addataSpect.dblWvMax.ToString
            'lblYAxisMin.Text = addataSpect.dblYmin.ToString
            'lblYAxisMax.Text = addataSpect.dblYMax.ToString

            '---to display sample name and comment
            txtSampName.Text = SpectrumParameter.SpectrumName
            txtComments.Text = SpectrumParameter.Comments
            'lblXAxis.Text = Format(SpectrumParameter.XaxisMin, "#0.0")

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
        ' Description           : for setting a parameter
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : praveen
        '=====================================================================
        Dim objWait As New CWaitCursor
        ''note:
        ''this is called when user click on OK button
        Try
            '---set sample name and comment
            Call funcSetParameter()
            ''for setting parameter.
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            Me.DialogResult = DialogResult.OK
            '---------------------------------------------------------
        End Try
    End Sub

    Private Function funcSetParameter() As Boolean
        '=====================================================================
        ' Procedure Name        : funcSetParameter
        ' Parameters Passed     : 
        ' Returns               : True/False
        ' Purpose               : 
        ' Description           : Set Sample Name and Comments
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 15.01.07
        ' Revisions             : praveen
        '=====================================================================
        Dim objWait As New CWaitCursor

        Try
            If mblnAvoidProcessing = True Then
                ''check for a flag for avoiding a process
                Exit Function
            End If
            mblnAvoidProcessing = True


            '---set sample name and comment to object
            SpectrumParameter.SpectrumName = Trim(txtSampName.Text)
            SpectrumParameter.Comments = Trim(txtComments.Text)

            'Me.Close()

            Application.DoEvents()
            ''allow application to perfrom its panding work.
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
        ' Description           : for handle a cancel event
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : praveen
        '=====================================================================
        Dim objWait As New CWaitCursor
        ''note:
        ''this is called when user click on cancel button
        ''for handle a cancel event
        Try
            '---to cancel the dialog box
            If mblnAvoidProcessing = True Then
                Exit Sub
            End If
            'Me.Close()
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
            mblnAvoidProcessing = False
            If Not objWait Is Nothing Then
                objWait.Dispose()
                ''destructure
            End If
            Application.DoEvents()
            ''allow application to perfrom its panding work.
            '---------------------------------------------------------
        End Try
    End Sub


#End Region

End Class
