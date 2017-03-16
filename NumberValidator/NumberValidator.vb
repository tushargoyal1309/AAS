Imports System.ComponentModel

Public Class NumberValidator
    Inherits System.Windows.Forms.TextBox

    '**********************************************************************
    ' File Header       : NumberValidator
    ' File Name 		: NumberValidator.vb
    ' Author			: Deepak Bhati
    ' Date/Time			: 01.10.04
    ' Description		: This is a control for the validation of numbers.
    '                     This control can work in three validation type modes
    '                     1.AlphaNumeric (Default Mode)
    '                     2.Integer Only
    '                     3.Double Only
    '************************************************************************************************************

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        ValidationType = Validations.AlphaNumeric
    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'Validator
        '
        Me.Name = "NumberValidator"
        Me.Size = New System.Drawing.Size(80, 20)

    End Sub

#End Region

#Region "Private Variables"
    Private mObjErrorColor As New System.Drawing.Color
    Private mBoolRangeValidation As Boolean = False
    Private mIntValidationType As Integer
    Private mIntDigitsAfterDecimalPoint As Integer = 0
    Private mDblMinLimit As Double = 0
    Private mDblMaxLimit As Double = 0
    Private mIntDecimalCount As Integer
    Private mStrErrorMessage As String
    Public Event ValidationStatus(ByVal Status As Status, ByVal Msg As String)
    Private mBoolValidated As Boolean = True
#End Region

#Region "Properties"
    'The property to set the errormessage
    <Description("Error Message Sent by NumberValidator"), Category("Action")> _
    Public Property ErrorMessage() As String
        Get
            Return mStrErrorMessage
        End Get
        Set(ByVal Value As String)
            mStrErrorMessage = Value
        End Set
    End Property

    'The property to set the errorcolor of the control
    <Description("Error Color to display on Error"), Category("Action")> _
    Public Property ErrorColor() As System.Drawing.Color
        Get
            Return mObjErrorColor
        End Get
        Set(ByVal Value As System.Drawing.Color)
            mObjErrorColor = Value
        End Set
    End Property

    'The property to set whether range validation is enabled ot not.

    <Description("To set range validation enable or disable"), Category("Action")> _
    Public Property RangeValidation() As Boolean
        Get
            Return mBoolRangeValidation
        End Get
        Set(ByVal Value As Boolean)
            mBoolRangeValidation = Value
        End Set
    End Property

    'The Enumeration types
    Public Enum Validations
        AlphaNumeric = 1
        IntegerOnly = 2
        DoubleOnly = 3
    End Enum

    'The property to set the validation type
    <Description("To set the range validation type , default is Alphanumeric"), Category("Action")> _
    Public Property ValidationType() As Validations
        Get
            Return mIntValidationType
        End Get
        Set(ByVal Value As Validations)
            mIntValidationType = Value
        End Set
    End Property

    'The property to set the minimum range of number
    <Description("To set the minimum value for range validation"), Category("Action")> _
    Public Property MinimumRange() As Double
        Get
            Return mDblMinLimit
        End Get
        Set(ByVal Value As Double)
            mDblMinLimit = Value
        End Set
    End Property

    'The property to set the maximum range of number
    <Description("To set the maximum value for range validation"), Category("Action")> _
    Public Property MaximumRange() As Double
        Get
            Return mDblMaxLimit
        End Get
        Set(ByVal Value As Double)
            mDblMaxLimit = Value
        End Set
    End Property

    'The property to set the number of digits after decimal point.
    <Description("To set the number of digits after decimal point"), Category("Action")> _
    Public Property DigitsAfterDecimalPoint() As Integer
        Get
            Return mIntDigitsAfterDecimalPoint
        End Get
        Set(ByVal Value As Integer)
            mIntDigitsAfterDecimalPoint = Value
        End Set
    End Property

    Public Enum Status
        Validated = 1
        NotValidated = 2
    End Enum

#End Region

#Region "Control Events"

    Private Sub Validator_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '=====================================================================
        ' Procedure Name        : NumberValidator_KeyPress
        ' Parameters Passed     : Object,KeyPressEventArgs
        ' Returns               : 
        ' Purpose               : to validate the control for integer and double only types
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 01-Oct-2004 3:00 pm
        ' Revisions             : 1
        '=====================================================================
        Dim mStrPressedKey As String
        'Dim decimalerr As Boolean = False
        Dim strSelectedText As String
        Try

            strSelectedText = Me.SelectedText
            If strSelectedText.Length > 0 Then
                Me.SelectedText = ""
            End If

            mStrPressedKey = e.KeyChar.ToString
            Select Case mIntValidationType
                Case 1 'Alphnumeric Validation (Default)

                    'Do nothing
                    ErrorMessage = ""
                    mBoolValidated = True
                    RaiseEvent ValidationStatus(Status.Validated, ErrorMessage)

                Case 2 ' integer only validation 

                    If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 45 Then
                        If (IsMinusPresent() = True And Asc(e.KeyChar) = 45) Or (TotalDigitsCount() <> 0 And Asc(e.KeyChar) = 45) Then
                            ErrorMessage = "Not allowed"
                            mBoolValidated = False
                            RaiseEvent ValidationStatus(Status.NotValidated, ErrorMessage)
                        Else
                            ErrorMessage = ""
                            mBoolValidated = True
                            RaiseEvent ValidationStatus(Status.Validated, ErrorMessage)
                        End If
                    Else
                        ErrorMessage = "'" & e.KeyChar & "'" & " is Not an Integer value."
                        mBoolValidated = False
                        RaiseEvent ValidationStatus(Status.NotValidated, ErrorMessage)
                    End If

                Case 3 ' double only validation

                    If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 46 Or Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 45 Then
                        'If (IsDecimalPointPresent() = True And Asc(e.KeyChar) = 46) Or (Trim(Me.Text) = "" And Asc(e.KeyChar) = 46) Or (IsMinusPresent() = True And Asc(e.KeyChar) = 45) Or (TotalDigitsCount() <> 0 And Asc(e.KeyChar) = 45) Then
                        If (IsDecimalPointPresent() = True And Asc(e.KeyChar) = 46) Or (IsMinusPresent() = True And Asc(e.KeyChar) = 45) Or (TotalDigitsCount() <> 0 And Asc(e.KeyChar) = 45) Then
                            mBoolValidated = False
                            ErrorMessage = "Not a double value"
                            RaiseEvent ValidationStatus(Status.NotValidated, ErrorMessage)
                        ElseIf DigitsAfterDecimalCount() = DigitsAfterDecimalPoint Then
                            'decimalerr = True
                            If Asc(e.KeyChar) = 8 Or Trim(Me.Text) = "" Then
                                mBoolValidated = True
                                ErrorMessage = ""
                                RaiseEvent ValidationStatus(Status.Validated, ErrorMessage)
                            Else
                                mBoolValidated = False
                                ErrorMessage = "Not Allowed"
                                RaiseEvent ValidationStatus(Status.NotValidated, ErrorMessage)
                            End If
                        Else
                            ErrorMessage = ""
                            mBoolValidated = True
                            RaiseEvent ValidationStatus(Status.Validated, ErrorMessage)
                        End If
                    Else
                        ErrorMessage = "'" & e.KeyChar & "'" & " is Not an Double value."
                        mBoolValidated = False
                        RaiseEvent ValidationStatus(Status.NotValidated, ErrorMessage)
                    End If

                    'If decimalerr = True Then
                    '    mBoolValidated = False
                    'End If

            End Select

            If mBoolValidated = True Then
                Me.ReadOnly = False
                Me.BackColor = System.Drawing.Color.White
            Else
                Me.ReadOnly = True
                Me.BackColor = mObjErrorColor
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

    Private Sub Validator_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Leave
        '=====================================================================
        ' Procedure Name        : NumberValidator_Leave
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : 
        ' Purpose               : To refresh the control
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 01-Oct-2004 5:00 pm
        ' Revisions             : 1
        '=====================================================================
        Try
            If mBoolValidated = True Then
                Me.ReadOnly = False
                Me.BackColor = System.Drawing.Color.White
                RaiseEvent ValidationStatus(Status.Validated, ErrorMessage)
            Else
                Me.ReadOnly = True
                Me.BackColor = mObjErrorColor
                RaiseEvent ValidationStatus(Status.NotValidated, ErrorMessage)
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

    Private Sub Validator_Keyup(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        '=====================================================================
        ' Procedure Name        : Validator_Keyup
        ' Parameters Passed     : Object,KeyEventArgs
        ' Returns               : None
        ' Purpose               : to validate the control for range
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : Tuesday, December 21, 2004
        ' Revisions             : 
        '=====================================================================
        Dim min As Integer = 0
        Dim max As Integer = 0
        Dim mDblEnteredValue As Double = 0
        Try
            min = Fix(MinimumRange)
            max = Fix(MaximumRange)
            If RangeValidation = True Then
                If Not (Trim(Me.Text) = "" Or Trim(Me.Text) = ".") Then
                    If Not Trim(Me.Text) = "." Then
                        If Not Trim(Me.Text) = "-" Then
                            mDblEnteredValue = CDbl(Trim(Me.Text))
                        End If
                    End If

                    If Not (mDblEnteredValue >= MinimumRange And mDblEnteredValue <= MaximumRange) Then
                        mBoolValidated = False
                        If Asc(e.KeyCode) = 8 Then
                            Me.ReadOnly = False
                        End If
                        If ValidationType = Validations.DoubleOnly Then
                            ErrorMessage = "Value Not Within The Range " & MinimumRange & " To " & MaximumRange
                        End If
                        If ValidationType = Validations.IntegerOnly Then
                            ErrorMessage = "Value Not Within The Range " & min & " To " & max
                        End If
                        RaiseEvent ValidationStatus(Status.NotValidated, ErrorMessage)
                    Else
                        mBoolValidated = True
                        ErrorMessage = ""
                        RaiseEvent ValidationStatus(Status.Validated, ErrorMessage)
                    End If
                End If
            End If

            If mBoolValidated = True Then
                Me.ReadOnly = False
                Me.BackColor = System.Drawing.Color.White
            Else
                Me.ReadOnly = True
                Me.BackColor = mObjErrorColor
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

#Region "Private Functions"

    Private Function DigitsAfterDecimalCount() As Integer
        '=====================================================================
        ' Procedure Name        : DigitsAfterDecimalCount
        ' Parameters Passed     : Nothing
        ' Returns               : Integer value
        ' Purpose               : To return the number of digits after decimal point
        ' Description           : This function is used to return the number of digits after decimal point.
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 09-Sep-2004 5:10 pm
        ' Revisions             : 1
        '=====================================================================

        Dim intFullTextLength, intPlaceOfDecimalPoint As Integer

        Try
            If IsDecimalPointPresent() = True Then
                intFullTextLength = Me.Text.Length
                intPlaceOfDecimalPoint = CInt(Me.Text.IndexOf(".") + 1)
                mIntDecimalCount = intFullTextLength - intPlaceOfDecimalPoint
                Return mIntDecimalCount
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

    Private Function IsDecimalPointPresent() As Boolean
        '=====================================================================
        ' Procedure Name        : IsDecimalPointPresent
        ' Parameters Passed     : Nothing
        ' Returns               : Boolean value
        ' Purpose               : To check whether decimal point is there in the textbox or not
        ' Description           : This function is used to check the presence of decimal point
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 09-Sep-2004 5:00 pm
        ' Revisions             : 1
        '=====================================================================
        Dim intFullTextLength, intCount As Integer
        Try
            intFullTextLength = Me.Text.Length
            For intCount = 0 To intFullTextLength - 1
                If Me.Text.Chars(intCount) = "." Then
                    Return True
                End If
            Next
            Return False

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

    Private Function IsMinusPresent() As Boolean
        '=====================================================================
        ' Procedure Name        : IsMinusPresent
        ' Parameters Passed     : Nothing
        ' Returns               : Boolean value
        ' Purpose               : To check whether decimal point is there in the textbox or not
        ' Description           : This function is used to check the presence of decimal point
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 09-Sep-2004 5:00 pm
        ' Revisions             : 1
        '=====================================================================
        Dim intFullTextLength, intCount As Integer
        Try
            intFullTextLength = Me.Text.Length
            For intCount = 0 To intFullTextLength - 1
                If Me.Text.Chars(intCount) = "-" Then
                    Return True
                End If
            Next
            Return False

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

    Private Function TotalDigitsCount() As Integer
        '=====================================================================
        ' Procedure Name        : TotalDigitsCount
        ' Parameters Passed     : Nothing
        ' Returns               : Integer value
        ' Purpose               : To return the total number of digits 
        ' Description           : This function is used to return the number of digits 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 21-Dec-2004 5:10 pm
        ' Revisions             : 1
        '=====================================================================
        Try
            Return CInt(Trim(Me.Text).Length())
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

#End Region


End Class
