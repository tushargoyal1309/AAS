Imports AAS203.Common
Public Class frmEditValues
    Inherits System.Windows.Forms.Form
    'Dim m_intfrmNo As EnumButtonIndex


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

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
    Friend WithEvents lblText As System.Windows.Forms.Label
    Friend WithEvents btnOk As NETXP.Controls.XPButton
    Friend WithEvents btnCancel As NETXP.Controls.XPButton
    Friend WithEvents lblText1 As System.Windows.Forms.Label
    Friend WithEvents CustomPanelHide As System.Windows.Forms.Panel
    Friend WithEvents txtValue1 As NumberValidator.NumberValidator
    Friend WithEvents txtValue2 As NumberValidator.NumberValidator
    Friend WithEvents txtValue As NumberValidator.NumberValidator
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmEditValues))
        Me.CustomPanel1 = New GradientPanel.CustomPanel
        Me.txtValue = New NumberValidator.NumberValidator
        Me.txtValue1 = New NumberValidator.NumberValidator
        Me.txtValue2 = New NumberValidator.NumberValidator
        Me.CustomPanelHide = New System.Windows.Forms.Panel
        Me.lblText1 = New System.Windows.Forms.Label
        Me.lblText = New System.Windows.Forms.Label
        Me.btnCancel = New NETXP.Controls.XPButton
        Me.btnOk = New NETXP.Controls.XPButton
        Me.CustomPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CustomPanel1
        '
        Me.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanel1.Controls.Add(Me.txtValue)
        Me.CustomPanel1.Controls.Add(Me.txtValue1)
        Me.CustomPanel1.Controls.Add(Me.txtValue2)
        Me.CustomPanel1.Controls.Add(Me.CustomPanelHide)
        Me.CustomPanel1.Controls.Add(Me.lblText1)
        Me.CustomPanel1.Controls.Add(Me.lblText)
        Me.CustomPanel1.Controls.Add(Me.btnCancel)
        Me.CustomPanel1.Controls.Add(Me.btnOk)
        Me.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanel1.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanel1.Name = "CustomPanel1"
        Me.CustomPanel1.Size = New System.Drawing.Size(290, 79)
        Me.CustomPanel1.TabIndex = 0
        '
        'txtValue
        '
        Me.txtValue.DigitsAfterDecimalPoint = 0
        Me.txtValue.ErrorColor = System.Drawing.Color.Empty
        Me.txtValue.ErrorMessage = Nothing
        Me.txtValue.Location = New System.Drawing.Point(215, 16)
        Me.txtValue.MaximumRange = 1
        Me.txtValue.MinimumRange = 0
        Me.txtValue.Name = "txtValue"
        Me.txtValue.RangeValidation = False
        Me.txtValue.Size = New System.Drawing.Size(60, 20)
        Me.txtValue.TabIndex = 0
        Me.txtValue.Text = ""
        Me.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.AlphaNumeric
        '
        'txtValue1
        '
        Me.txtValue1.DigitsAfterDecimalPoint = 0
        Me.txtValue1.ErrorColor = System.Drawing.Color.Empty
        Me.txtValue1.ErrorMessage = Nothing
        Me.txtValue1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValue1.Location = New System.Drawing.Point(215, 48)
        Me.txtValue1.MaximumRange = 6
        Me.txtValue1.MaxLength = 1
        Me.txtValue1.MinimumRange = 1
        Me.txtValue1.Name = "txtValue1"
        Me.txtValue1.RangeValidation = True
        Me.txtValue1.Size = New System.Drawing.Size(60, 21)
        Me.txtValue1.TabIndex = 14
        Me.txtValue1.Text = "1"
        Me.txtValue1.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly
        Me.txtValue1.Visible = False
        '
        'txtValue2
        '
        Me.txtValue2.BackColor = System.Drawing.Color.White
        Me.txtValue2.DigitsAfterDecimalPoint = 0
        Me.txtValue2.ErrorColor = System.Drawing.Color.Empty
        Me.txtValue2.ErrorMessage = Nothing
        Me.txtValue2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValue2.Location = New System.Drawing.Point(232, 48)
        Me.txtValue2.MaximumRange = 1000
        Me.txtValue2.MaxLength = 4
        Me.txtValue2.MinimumRange = 0
        Me.txtValue2.Name = "txtValue2"
        Me.txtValue2.RangeValidation = False
        Me.txtValue2.Size = New System.Drawing.Size(16, 21)
        Me.txtValue2.TabIndex = 0
        Me.txtValue2.Text = ""
        Me.txtValue2.ValidationType = NumberValidator.NumberValidator.Validations.AlphaNumeric
        Me.txtValue2.Visible = False
        '
        'CustomPanelHide
        '
        Me.CustomPanelHide.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanelHide.Location = New System.Drawing.Point(292, 3)
        Me.CustomPanelHide.Name = "CustomPanelHide"
        Me.CustomPanelHide.Size = New System.Drawing.Size(80, 72)
        Me.CustomPanelHide.TabIndex = 12
        '
        'lblText1
        '
        Me.lblText1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblText1.Location = New System.Drawing.Point(16, 48)
        Me.lblText1.Name = "lblText1"
        Me.lblText1.Size = New System.Drawing.Size(144, 16)
        Me.lblText1.TabIndex = 10
        '
        'lblText
        '
        Me.lblText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblText.Location = New System.Drawing.Point(8, 19)
        Me.lblText.Name = "lblText"
        Me.lblText.Size = New System.Drawing.Size(208, 16)
        Me.lblText.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(294, 38)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(76, 32)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Cancel"
        '
        'btnOk
        '
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Image = CType(resources.GetObject("btnOk.Image"), System.Drawing.Image)
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(294, 7)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(76, 29)
        Me.btnOk.TabIndex = 8
        Me.btnOk.Text = "OK"
        '
        'frmEditValues
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(290, 79)
        Me.Controls.Add(Me.CustomPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEditValues"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Values"
        Me.TopMost = True
        Me.CustomPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Variables"
    Private mintValue As Integer
    Private mstrLabelText As String
    'Private mintTextValue As Integer
    Public Event ReturnValue(ByVal dblValue As Double, ByVal intValue1 As Integer)
#End Region

#Region " Properties"

    Public Property LabelText() As String
        Get
            Return mstrLabelText
        End Get
        Set(ByVal Value As String)
            mstrLabelText = Value

            lblText.Text = LabelText
            lblText.Refresh()

        End Set
    End Property

    Private Property TextValue() As Double
        Get
            Return mintValue
        End Get
        Set(ByVal Value As Double)
            mintValue = Value
        End Set
    End Property

    Private Property TextValue1() As Integer
        Get
            Return mintValue
        End Get
        Set(ByVal Value As Integer)
            mintValue = Value
        End Set
    End Property

#End Region

#Region " Enum Declaration"

    '--- Enum for the Form Button indices
    Public Enum EnumButtonIndex
        TurretPosition = 1
        D2Current = 2
        PMT = 3
        MODE = 4
        AvgValue = 5
        WvPosition = 6
        SlitPos = 7
        WvRepeats = 8
        SlitRepeats = 9
    End Enum

#End Region

#Region " Form Events"

    Private Sub frmEditValues_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim objwait As New CWaitCursor
        Try
            txtValue.SelectAll()
            Call Addhandlers()

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
            If Not objwait Is Nothing Then
                objwait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

#End Region

#Region " Private Functions"

    Private Sub Addhandlers()
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

            AddHandler btnOk.Click, AddressOf btnOk_Click
            AddHandler btnCancel.Click, AddressOf btnCancel_Click

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
        ' Purpose               : To cancel the form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Try
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

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnOk_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To send dialog result as ok
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim dblValue As Double
        Dim intValue1 As Integer
        Try
            If txtValue.Text = "" Then
                gobjMessageAdapter.ShowMessage(constInputProperData)
                Application.DoEvents()
                Exit Sub
            End If
            If IsNumeric(txtValue.Text) Then
                dblValue = CDbl(txtValue.Text)
            Else
                txtValue1.Text = CDbl(0)
            End If
            ''Added by praveen for validation

            If IsNumeric(txtValue.Text) Then
                intValue1 = txtValue.Text
                If intValue1 < txtValue.MinimumRange Then
                    intValue1 = txtValue.MinimumRange
                ElseIf intValue1 > txtValue.MaximumRange Then
                    intValue1 = txtValue.MaximumRange
                Else
                    intValue1 = txtValue.Text
                End If
            Else
                intValue1 = txtValue.MinimumRange
            End If
            ''Ended by praveen
            intValue1 = CDbl(txtValue1.Text)
            RaiseEvent ReturnValue(dblValue, intValue1)

            'If m_intfrmNo = 1 Then
            '    Application.DoEvents()
            'End If

            Me.DialogResult = DialogResult.OK
            Me.Close()
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

#End Region

    
End Class
