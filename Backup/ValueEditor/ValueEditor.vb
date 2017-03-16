Public Class ValueEditor
    Inherits System.Windows.Forms.UserControl
    '************************************************************************************************************
    ' File Header
    ' File Name 		: ValueEditor.vb
    ' Author			: Deepak Bhati
    ' Date/Time			: 30.03.07
    ' Description		: This component is used to set value with increment and decrement button provided
    '                     to change the set value.
    '************************************************************************************************************

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        InitializeErrorHandlerObject()

    End Sub
   
    'UserControl1 overrides dispose to clean up the component list.
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
    Friend WithEvents PnlBtn As System.Windows.Forms.Panel
    Friend WithEvents pnlScroll As System.Windows.Forms.Panel
    Friend WithEvents Btn As NETXP.Controls.XPButton
    Friend WithEvents BtnUp As NETXP.Controls.XPButton
    Friend WithEvents BtnDn As NETXP.Controls.XPButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.PnlBtn = New System.Windows.Forms.Panel
        Me.Btn = New NETXP.Controls.XPButton
        Me.pnlScroll = New System.Windows.Forms.Panel
        Me.BtnDn = New NETXP.Controls.XPButton
        Me.BtnUp = New NETXP.Controls.XPButton
        Me.PnlBtn.SuspendLayout()
        Me.pnlScroll.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlBtn
        '
        Me.PnlBtn.Controls.Add(Me.Btn)
        Me.PnlBtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlBtn.Location = New System.Drawing.Point(0, 0)
        Me.PnlBtn.Name = "PnlBtn"
        Me.PnlBtn.Size = New System.Drawing.Size(48, 24)
        Me.PnlBtn.TabIndex = 3
        '
        'Btn
        '
        Me.Btn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn.Location = New System.Drawing.Point(0, 0)
        Me.Btn.Name = "Btn"
        Me.Btn.Size = New System.Drawing.Size(48, 24)
        Me.Btn.TabIndex = 0
        '
        'pnlScroll
        '
        Me.pnlScroll.Controls.Add(Me.BtnDn)
        Me.pnlScroll.Controls.Add(Me.BtnUp)
        Me.pnlScroll.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlScroll.Location = New System.Drawing.Point(48, 0)
        Me.pnlScroll.Name = "pnlScroll"
        Me.pnlScroll.Size = New System.Drawing.Size(24, 24)
        Me.pnlScroll.TabIndex = 2
        '
        'BtnDn
        '
        Me.BtnDn.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnDn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDn.Font = New System.Drawing.Font("Marlett", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnDn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDn.Location = New System.Drawing.Point(0, 12)
        Me.BtnDn.Name = "BtnDn"
        Me.BtnDn.Size = New System.Drawing.Size(24, 12)
        Me.BtnDn.TabIndex = 5
        Me.BtnDn.TabStop = False
        Me.BtnDn.Text = "6"
        '
        'BtnUp
        '
        Me.BtnUp.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnUp.Font = New System.Drawing.Font("Marlett", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnUp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnUp.Location = New System.Drawing.Point(0, 0)
        Me.BtnUp.Name = "BtnUp"
        Me.BtnUp.Size = New System.Drawing.Size(24, 12)
        Me.BtnUp.TabIndex = 4
        Me.BtnUp.TabStop = False
        Me.BtnUp.Text = "5"
        '
        'ValueEditor
        '
        Me.Controls.Add(Me.PnlBtn)
        Me.Controls.Add(Me.pnlScroll)
        Me.Name = "ValueEditor"
        Me.Size = New System.Drawing.Size(72, 24)
        Me.PnlBtn.ResumeLayout(False)
        Me.pnlScroll.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Public Events"
    Public Event ValueEditorClick()
    Public Event ValueEditorValueChanged(ByVal Value As Double)
#End Region

#Region "Constants"
    Private Const CONST_CREATE_EXECUTION_LOG = 0
    Public Enum EnumValueEditorButtons
        MainButton = 1
        UpButton = 2
        DownButton = 3
    End Enum

#End Region

#Region "Private Variables"
    Private gobjErrorHandler As New ErrorHandler.ErrorHandler
    Private mdblValue As Double
    Private mdblMinValue As Double
    Private mdblMaxValue As Double
    Private mdblChangeFactor As Double
    Private mintDecimalPlace As Integer
    Private mblnIsReverseOperation As Boolean
    Private mintButtonClicked As Integer = 1
    Private mblnIsUpDownButtonToBeDisabledOnValuechange As Boolean
    Private mstrText As String
    Private mblnAvoidProcessing As Boolean
    Private mblnIsUpDownEnable As Boolean
    Private mblnIsBtnEnable As Boolean
#End Region

#Region "Public Properties"

    Public Property Value() As Double
        Get
            Return mdblValue
        End Get
        Set(ByVal Val As Double)

            'If Value <= MaxValue And Value >= MinValue Then
            If Val <= MaxValue And Val >= MinValue Then
                'mdblValue = Val
                mdblValue = funcSetDecimalPlace(Val)
                'Btn.Text = mdblValue
                mstrText = mdblValue
                RaiseEvent ValueEditorValueChanged(mdblValue)
                Btn.Text = mdblValue

            End If

        End Set
    End Property

    Public Property DecimalPlace() As Integer
        Get
            Return mintDecimalPlace
        End Get
        Set(ByVal Val As Integer)
            mintDecimalPlace = Val
            'If Value <= MaxValue And Value >= MinValue Then
            '    mdblValue = Val
            '    Btn.Text = Value
            '    RaiseEvent ValueEditorValueChanged(Value)
            'End If


        End Set
    End Property

    Public Property BackgroundColor() As Color
        Get
            Return Me.BackColor
        End Get
        Set(ByVal Value As Color)
            Me.BackColor = Value
            Btn.BackColor = Value
            BtnUp.BackColor = Value
            BtnDn.BackColor = Value
        End Set
    End Property

    Public Property ForegroundColor() As Color
        Get
            Return Me.ForeColor
        End Get
        Set(ByVal Value As Color)
            Me.ForeColor = Value
            Btn.ForeColor = Value
            BtnUp.ForeColor = Value
            BtnDn.ForeColor = Value
        End Set
    End Property

    Public Property MinValue() As Double
        Get
            Return mdblMinValue
        End Get
        Set(ByVal Value As Double)
            mdblMinValue = Value
        End Set
    End Property

    Public Property MaxValue() As Double
        Get
            Return mdblMaxValue
        End Get
        Set(ByVal Value As Double)
            mdblMaxValue = Value
        End Set
    End Property

    Public Property ChangeFactor() As Double
        Get
            Return mdblChangeFactor
        End Get
        Set(ByVal Value As Double)
            mdblChangeFactor = Value
        End Set
    End Property

    Public Property ValueEditorEnabled() As Boolean
        Get
            Return Me.Enabled
        End Get
        Set(ByVal Value As Boolean)
            Me.Enabled = Value

        End Set
    End Property

    Public Property UpButtonText() As String
        Get
            Return BtnUp.Text
        End Get
        Set(ByVal Value As String)
            BtnUp.Text = Value
        End Set
    End Property

    Public Property DnButtonText() As String
        Get
            Return BtnDn.Text
        End Get
        Set(ByVal Value As String)
            BtnDn.Text = Value
        End Set
    End Property
    Public Overloads Overrides Property Text() As String
        Get
            Return mstrText
        End Get
        Set(ByVal Value As String)
            mstrText = Value
            Btn.Text = mstrText
        End Set
    End Property

    Public Property ValueEditorFont() As Font
        Get
            Return Btn.Font
        End Get
        Set(ByVal Value As Font)
            Btn.Font = Value
        End Set
    End Property

    Public Property IsReverseOperation() As Boolean
        Get
            Return mblnIsReverseOperation
        End Get
        Set(ByVal Val As Boolean)
            mblnIsReverseOperation = Val
        End Set
    End Property

    Public Property IsUpDownButtonToBeDisabledOnValueChange() As Boolean
        Get
            Return mblnIsUpDownButtonToBeDisabledOnValuechange
        End Get
        Set(ByVal Val As Boolean)
            mblnIsUpDownButtonToBeDisabledOnValuechange = Val
        End Set
    End Property

    Public Property ButtonClicked() As EnumValueEditorButtons
        Get
            Return mintButtonClicked
        End Get
        Set(ByVal Val As EnumValueEditorButtons)
            mintButtonClicked = Val
        End Set
    End Property

    Public Property IsUpDownEnable() As Boolean
        Get
            Return mblnIsUpDownEnable
        End Get
        Set(ByVal Val As Boolean)
            mblnIsUpDownEnable = Val

            BtnUp.Enabled = Val
            BtnDn.Enabled = Val
        End Set
    End Property

    Public Property IsButtonEnable() As Boolean
        Get
            Return mblnIsBtnEnable
        End Get
        Set(ByVal Val As Boolean)
            mblnIsBtnEnable = Val

            If Val = True Then
                AddHandler BtnUp.Click, AddressOf BtnUp_Click
                AddHandler BtnDn.Click, AddressOf BtnDn_Click
                AddHandler Btn.Click, AddressOf Btn_Click
            Else
                RemoveHandler BtnUp.Click, AddressOf BtnUp_Click
                RemoveHandler BtnDn.Click, AddressOf BtnDn_Click
                RemoveHandler Btn.Click, AddressOf Btn_Click
            End If
            'BtnUp.Enabled = Val
            'BtnDn.Enabled = Val
            'Btn.Enabled = Val
        End Set
    End Property

#End Region

#Region "Private Events"
    Private Sub Btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        Try
            mblnAvoidProcessing = True
            If Not BtnUp Is Nothing Then
                BtnUp.Enabled = False
            End If
            If Not BtnDn Is Nothing Then
                BtnDn.Enabled = False
            End If
            ButtonClicked = EnumValueEditorButtons.MainButton
            RaiseEvent ValueEditorClick()
            If Not BtnUp Is Nothing Then
                BtnUp.Enabled = True
            End If
            If Not BtnDn Is Nothing Then
                BtnDn.Enabled = True
            End If
            mblnAvoidProcessing = False
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

    Private Sub BtnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim dblVal As Double
        Try
            ButtonClicked = EnumValueEditorButtons.UpButton
            If IsUpDownButtonToBeDisabledOnValueChange = True Then
                BtnUp.Enabled = False
            End If

            dblVal = Value

            If IsReverseOperation = True Then
                If dblVal > MinValue Then
                    dblVal = dblVal - ChangeFactor
                    If dblVal <= MaxValue And dblVal >= MinValue Then
                        Value = dblVal
                    End If
                End If
            Else
                If dblVal <= MaxValue And dblVal >= MinValue Then
                    dblVal = dblVal + ChangeFactor
                    If dblVal <= MaxValue And dblVal >= MinValue Then
                        Value = dblVal
                    End If
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
            If IsUpDownButtonToBeDisabledOnValueChange = True Then
                BtnUp.Enabled = True
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub BtnDn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim dblVal As Double
        Try
            ButtonClicked = EnumValueEditorButtons.DownButton
            If IsUpDownButtonToBeDisabledOnValueChange = True Then
                BtnDn.Enabled = False
            End If

            dblVal = Value

            If IsReverseOperation = True Then
                If dblVal < MaxValue Then
                    dblVal = dblVal + ChangeFactor
                    If dblVal <= MaxValue And dblVal >= MinValue Then
                        Value = dblVal
                    End If
                End If
            Else
                If dblVal <= MaxValue And dblVal >= MinValue Then
                    dblVal = dblVal - ChangeFactor
                    If dblVal <= MaxValue And dblVal >= MinValue Then
                        Value = dblVal
                    End If
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
            If IsUpDownButtonToBeDisabledOnValueChange = True Then
                BtnDn.Enabled = True
            End If
            '---------------------------------------------------------
        End Try
    End Sub

#End Region

#Region "Functions"
    Public Sub InitializeErrorHandlerObject()

        Try
            gobjErrorHandler.ErrorLogFolder = "ErrorLogs"
            gobjErrorHandler.ErrorLogFileName = CurDir() & "\" & gobjErrorHandler.ErrorLogFolder & "\ValueEditorErrorHandler.txt"
            gobjErrorHandler.CompanyName = "Aldys Technologies Pvt. Ltd."
            gobjErrorHandler.ProductName = "AAS203"
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

    Private Function funcSetDecimalPlace(ByVal dblValue As Double) As Double
        '=====================================================================
        ' Procedure Name        : funcSetDecimalPlace
        ' Parameters Passed     : dblValue As Double
        ' Returns               : Double
        ' Purpose               : 
        ' Description           : Set Decimal place
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 03.04.07
        ' Revisions             : 
        '=====================================================================
        Dim i As Integer
        Dim dblValue1 As Double
        Dim lngValue As Long
        Dim DecimalFactor As Long = 1
        Try
            funcSetDecimalPlace = dblValue
            If DecimalPlace > 0 Then
                'lngValue = dblValue
                For i = 1 To DecimalPlace
                    DecimalFactor = DecimalFactor * 10
                Next
                lngValue = CLng(dblValue * DecimalFactor)
                dblValue = lngValue / DecimalFactor
            Else
                'lngValue = dblValue
                lngValue = CLng(dblValue * DecimalFactor)
                dblValue = lngValue
            End If
            funcSetDecimalPlace = dblValue
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return funcSetDecimalPlace
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

#End Region

    Private Sub ValueEditor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler BtnUp.Click, AddressOf BtnUp_Click
        AddHandler BtnDn.Click, AddressOf BtnDn_Click
        AddHandler Btn.Click, AddressOf Btn_Click
    End Sub

End Class
