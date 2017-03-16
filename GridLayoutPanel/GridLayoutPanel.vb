Option Explicit On 
Option Strict Off

'************************************************************************************************************
' File Header
' File Name 		: GridLayoutPanel.vb
' Author			: Deepak Bhati
' Date/Time			: Thursday, December 02, 2004
' Description		: This component is used to set the grid layout with the
'                     specified number of columns and arranges the controls array
'                     accordingly.
'************************************************************************************************************

Public Class GridLayoutPanel
    Inherits Panel

#Region " Component Designer generated code "

    Public Sub New(ByVal Container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        Container.Add(Me)
        InitializeSetting()
    End Sub

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Component overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

#End Region

#Region " Private Class Member Variables "

    Private mintColumnCount As Integer
    Private mstrErrorText As String = ""

    Private mControls() As Control
    Private mintControlHSpacing As Integer = DefaultControlHSpacing
    Private mintControlVSpacing As Integer = DefaultControlVSpacing
    Private mobjErr As New ErrorProvider
    Private mblnShowError As Boolean = False
    Private mblnSingleRowGrid As Boolean = False
    Private mlngStandardId As Long
    Private mstrSelectedSampleNo As String

#End Region

#Region " Public Events, Structures, Enums, Constants... "

    Public Event ControlClicked(ByVal ControlIndex As Long)
    Public Event ControlMouseEntered(ByVal ControlIndex As Long)

#End Region

#Region " Private Constants "

    Private Const ControlCollectionLengthOverflowError As String = "Column Count Can't Be More than the Objects Collection"
    Private Const ControlCollectionLengthZeroError As String = "Column Count Can't Be Zero"
    Private Const DefaultControlHSpacing As Integer = 10
    Private Const DefaultControlVSpacing As Integer = 10

#End Region

#Region " Public Properties "

    Public Property ColumnCount() As Integer
        Get
            Return mintColumnCount
        End Get
        Set(ByVal Value As Integer)
            mintColumnCount = Value
        End Set
    End Property

    Public Property SingleRowGrid() As Boolean
        Get
            Return mblnSingleRowGrid
        End Get
        Set(ByVal Value As Boolean)
            mblnSingleRowGrid = Value
        End Set
    End Property

    Public Property ErrorText() As String
        Get
            Return mstrErrorText
        End Get
        Set(ByVal Value As String)
            mstrErrorText = Value
        End Set
    End Property

    Public Property ControlHSpacing() As Integer
        Get
            Return mintControlHSpacing
        End Get
        Set(ByVal Value As Integer)
            mintControlHSpacing = Value
        End Set
    End Property

    Public Property ControlVSpacing() As Integer
        Get
            Return mintControlVSpacing
        End Get
        Set(ByVal Value As Integer)
            mintControlVSpacing = Value
        End Set
    End Property

    Public Property ShowError() As Boolean
        Get
            Return mblnShowError
        End Get
        Set(ByVal Value As Boolean)
            mblnShowError = Value
        End Set
    End Property
    Dim mintSelectedIndex As Integer

    Public Property SelectedIndex() As Integer
        Get
            Return mintSelectedIndex
        End Get
        Set(ByVal Value As Integer)
            mintSelectedIndex = Value
        End Set
    End Property
#End Region

#Region " Public Functions "

    

    Public Function GetCurrentControls(ByVal objControls() As Control, ByVal strTag As String) As Control
        'Public Function GetCurrentControls() As Control
        '=====================================================================
        ' Procedure Name        : GetControls
        ' Parameters Passed     : controls array
        ' Returns               : true or false
        ' Purpose               : to assign the controls array to the component
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : control array
        ' Author                : Sachin Dokhale
        ' Created               : Thursday, December 02, 2004
        ' Revisions             : 
        '=====================================================================
        Dim objCntrl As Control
        Dim intControlIndex As Integer

        Try
            If Not IsNothing(mControls) Then
                intControlIndex = 0
                For Each objCntrl In mControls
                    If Not IsNothing(objCntrl) Then
                        'If objControls Is objCntrl Then
                        'If CType(objCntrl, RepeatResultsControl).AnalysisParameter = strTag Then
                        'If CType(objCntrl, me.ControlCollection).AnalysisParameter.SampNumber = strTag Then
                        Return objCntrl

                    End If
                Next
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return Nothing
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

    Public Function GetControls(ByVal objControls() As Control) As Boolean
        '=====================================================================
        ' Procedure Name        : GetControls
        ' Parameters Passed     : controls array
        ' Returns               : true or false
        ' Purpose               : to assign the controls array to the component
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : control array
        ' Author                : Deepak Bhati
        ' Created               : Thursday, December 02, 2004
        ' Revisions             : 
        '=====================================================================
        Dim objCntrl As Control
        Dim intControlIndex As Integer

        Try
            mControls = objControls

            If Not IsNothing(mControls) Then
                intControlIndex = 0
                For Each objCntrl In mControls
                    If Not IsNothing(objCntrl) Then
                        objCntrl.Tag = intControlIndex
                        Me.Tag = objCntrl.Tag
                        SelectedIndex = intControlIndex
                        AddHandler objCntrl.Click, AddressOf subControlClicked
                        AddHandler objCntrl.MouseEnter, AddressOf subControlMouseEntered
                        'AddHandler objCntrl.Click, AddressOf objRepeatResultsControl_RepeatResultClick
                        intControlIndex += 1
                    End If
                Next
            End If

            Return True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return False
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

    Public Function RemoveControls() As Boolean
        '=====================================================================
        ' Procedure Name        : GetControls
        ' Parameters Passed     : controls array
        ' Returns               : true or false
        ' Purpose               : to assign the controls array to the component
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : control array
        ' Author                : Sachin Dokhale
        ' Created               : Thursday, December 02, 2004
        ' Revisions             : 
        '=====================================================================
        Dim objCntrl As Control
        Dim intControlIndex As Integer

        Try
            If Not IsNothing(mControls) Then
                intControlIndex = 0
                For Each objCntrl In mControls
                    If Not IsNothing(objCntrl) Then
                        ' If objControls Is objCntrl Then
                        objCntrl.Visible = False
                        'End If
                    End If
                Next
            End If

            mControls = Nothing

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return Nothing
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

    Public Function ShowGrid() As Boolean
        '=====================================================================
        ' Procedure Name        : ShowGrid
        ' Parameters Passed     : None
        ' Returns               : true or false
        ' Purpose               : To show the layout with controls on the panel
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : Thursday, December 02, 2004
        ' Revisions             : 
        '=====================================================================
        Try
            If Not mControls Is Nothing Then
                If ArrangeControls(mControls) = True Then
                    Return True
                Else
                    Return False
                End If
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return False
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

    Public Function ArrangeControls(ByVal objCtrl() As Control) As Boolean
        '=====================================================================
        ' Procedure Name        : ArrangeControls
        ' Parameters Passed     : None
        ' Returns               : true or false
        ' Purpose               : To show the layout with controls on the panel
        ' Description           : if single row grid is set the set the 
        '                         columncount =number of controls otherwise divide total 
        '                         number of controls by the column count set the user
        '                         and arrange all the controls by using horizontal and 
        '                         vertical spacing and size of the controls
        '
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : Thursday, December 02, 2004
        ' Revisions             : 
        '=====================================================================
        '---if single row grid is set the set the columncount =number of controls
        '---otherwise divide total number of controls by the column count set the user
        '---and arrange all the controls by using horizontal and vertical spacing 
        '---and size of the controls
        Dim colObjects As Integer
        Dim rowCounter, ColCounter As Integer
        Dim ObjIndex As Integer = 0
        Dim RowCount As Double
        Dim unEvenObjectsCount As Integer
        Dim unEvenObjectsCounter As Integer = 0
        Dim CheckForUnEvenObjects As Boolean

        Try
            If SingleRowGrid = True Then
                ColumnCount = objCtrl.Length
            End If

            If ColumnCount > objCtrl.Length Then
                ErrorText = ControlCollectionLengthOverflowError
                If ShowError = True Then
                    mobjErr.SetError(Me, ControlCollectionLengthOverflowError)
                    Me.BorderStyle = BorderStyle.FixedSingle
                End If
                Return False

            ElseIf ColumnCount <= 0 Then
                ErrorText = ControlCollectionLengthZeroError
                If ShowError = True Then
                    mobjErr.SetError(Me, ControlCollectionLengthZeroError)
                    Me.BorderStyle = BorderStyle.FixedSingle
                End If
                Return False
            Else

                Select Case ColumnCount
                    Case 1
                        For colObjects = 0 To objCtrl.Length - 1
                            If colObjects = 0 Then
                                If Not objCtrl(colObjects) Is Nothing Then
                                    objCtrl(colObjects).Location = New Point(0, 0)
                                End If
                            Else
                                If Not objCtrl(colObjects) Is Nothing Then
                                    objCtrl(colObjects).Location = New Point(objCtrl(colObjects - 1).Location.X, objCtrl(colObjects - 1).Location.Y + objCtrl(colObjects - 1).Height + ControlVSpacing)
                                End If
                            End If
                            If Not objCtrl(colObjects) Is Nothing Then
                                Me.SuspendLayout()
                                Me.Controls.Add(objCtrl(colObjects))
                                Me.ResumeLayout()
                            End If
                        Next

                    Case Is > 1

                        RowCount = (objCtrl.Length) / ColumnCount

                        unEvenObjectsCount = (objCtrl.Length) - (Fix(RowCount) * ColumnCount)

                        If unEvenObjectsCount > 0 Then
                            RowCount = Fix(RowCount) + 1
                            CheckForUnEvenObjects = True
                        Else
                            CheckForUnEvenObjects = False
                        End If

                        For rowCounter = 0 To Fix(RowCount) - 1
                            For ColCounter = 0 To ColumnCount - 1
                                'If Trim(CType(objCtrl(ObjIndex), ShadeControl.ShadeControl).ShadeLabel) = "211G30Y-5010" Then
                                'MessageBox.Show("")
                                'End If
                                If rowCounter = 0 Then
                                    If ColCounter = 0 Then
                                        If Not objCtrl(ObjIndex) Is Nothing Then
                                            objCtrl(ObjIndex).Location = New Point(0, 0)
                                        End If
                                    Else
                                        If Not objCtrl(ObjIndex) Is Nothing Then
                                            objCtrl(ObjIndex).Location = New Point(objCtrl(ObjIndex - 1).Location.X + objCtrl(ObjIndex - 1).Width + ControlHSpacing, objCtrl(ObjIndex - 1).Location.Y)
                                        End If
                                    End If
                                Else
                                    If unEvenObjectsCount > 0 Then
                                        If rowCounter = Int(Fix(RowCount) - 1) Then
                                            unEvenObjectsCounter = unEvenObjectsCounter + 1
                                        End If
                                    End If

                                    If ColCounter = 0 Then
                                        If Not objCtrl(ObjIndex) Is Nothing Then
                                            objCtrl(ObjIndex).Location = New Point(objCtrl(ObjIndex - (ColumnCount - 1)).Location.X - objCtrl(ObjIndex - 1).Width - ControlHSpacing, objCtrl(ObjIndex - 1).Location.Y + objCtrl(ObjIndex - 1).Height + ControlVSpacing)
                                        End If
                                    Else
                                        If Not objCtrl(ObjIndex) Is Nothing Then
                                            objCtrl(ObjIndex).Location = New Point(objCtrl(ObjIndex - 1).Location.X + objCtrl(ObjIndex - 1).Width + ControlHSpacing, objCtrl(ObjIndex - 1).Location.Y)
                                        End If
                                    End If

                                End If

                                If Not objCtrl(ObjIndex) Is Nothing Then
                                    Me.SuspendLayout()
                                    Me.Controls.Add(objCtrl(ObjIndex))
                                    Me.ResumeLayout()
                                End If

                                ObjIndex = ObjIndex + 1
                                If CheckForUnEvenObjects = True Then
                                    If unEvenObjectsCounter = unEvenObjectsCount Then
                                        Exit For
                                    End If
                                End If
                            Next
                        Next

                End Select

            End If

            Return True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return False
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

#Region " Private Functions "

    Private Sub subControlClicked(ByVal sender As Object, ByVal e As EventArgs)
        '=====================================================================
        ' Procedure Name        : subControlClicked
        ' Parameters Passed     : Object, EventArgs 
        ' Returns               : None
        ' Purpose               : to raise to the parent of this component
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : Tuesday, December 14, 2004
        ' Revisions             : 
        '=====================================================================
        Dim intControlIndex As Integer

        Try
            intControlIndex = CInt(CType(sender, Control).Tag)
            SelectedIndex = intControlIndex
            RaiseEvent ControlClicked(intControlIndex)

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

    Private Sub subControlMouseEntered(ByVal sender As Object, ByVal e As EventArgs)
        '=====================================================================
        ' Procedure Name        : subControlMouseEntered
        ' Parameters Passed     : Object, EventArgs 
        ' Returns               : None
        ' Purpose               : to raise to the parent of this component
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : Tuesday, December 14, 2004
        ' Revisions             : 
        '=====================================================================
        Dim intControlIndex As Integer

        Try
            intControlIndex = CInt(CType(sender, Control).Tag)
            SelectedIndex = intControlIndex
            RaiseEvent ControlMouseEntered(intControlIndex)

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
    Private Sub objRepeatResultsControl_RepeatResultClick()

        mstrSelectedSampleNo = SelectedIndex
    End Sub
#End Region

End Class
