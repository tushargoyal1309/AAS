Imports AAS203.Common

Public Class frmChangeLampParameters 'class behind the form
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
    Friend WithEvents CustomPanel1 As GradientPanel.CustomPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnOk As NETXP.Controls.XPButton
    Friend WithEvents btnCancel As NETXP.Controls.XPButton
    Friend WithEvents cmbTurrEle As System.Windows.Forms.ComboBox
    Friend WithEvents txtHCLCurr As NumberValidator.NumberValidator
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmChangeLampParameters))
        Me.CustomPanel1 = New GradientPanel.CustomPanel
        Me.txtHCLCurr = New NumberValidator.NumberValidator
        Me.btnOk = New NETXP.Controls.XPButton
        Me.btnCancel = New NETXP.Controls.XPButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbTurrEle = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.CustomPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CustomPanel1
        '
        Me.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanel1.Controls.Add(Me.txtHCLCurr)
        Me.CustomPanel1.Controls.Add(Me.btnOk)
        Me.CustomPanel1.Controls.Add(Me.btnCancel)
        Me.CustomPanel1.Controls.Add(Me.Label4)
        Me.CustomPanel1.Controls.Add(Me.Label3)
        Me.CustomPanel1.Controls.Add(Me.cmbTurrEle)
        Me.CustomPanel1.Controls.Add(Me.Label2)
        Me.CustomPanel1.Controls.Add(Me.Label1)
        Me.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanel1.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanel1.Name = "CustomPanel1"
        Me.CustomPanel1.Size = New System.Drawing.Size(296, 199)
        Me.CustomPanel1.TabIndex = 0
        '
        'txtHCLCurr
        '
        Me.txtHCLCurr.BackColor = System.Drawing.Color.White
        Me.txtHCLCurr.DigitsAfterDecimalPoint = 1
        Me.txtHCLCurr.ErrorColor = System.Drawing.Color.Empty
        Me.txtHCLCurr.ErrorMessage = Nothing
        Me.txtHCLCurr.Location = New System.Drawing.Point(120, 78)
        Me.txtHCLCurr.MaximumRange = 25
        Me.txtHCLCurr.MaxLength = 4
        Me.txtHCLCurr.MinimumRange = 0
        Me.txtHCLCurr.Name = "txtHCLCurr"
        Me.txtHCLCurr.RangeValidation = True
        Me.txtHCLCurr.ReadOnly = True
        Me.txtHCLCurr.Size = New System.Drawing.Size(56, 21)
        Me.txtHCLCurr.TabIndex = 2
        Me.txtHCLCurr.Text = ""
        Me.txtHCLCurr.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly
        '
        'btnOk
        '
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Image = CType(resources.GetObject("btnOk.Image"), System.Drawing.Image)
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(48, 144)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(86, 34)
        Me.btnOk.TabIndex = 3
        Me.btnOk.Text = "&OK"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(168, 144)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 34)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "&Cancel"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.AliceBlue
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(184, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 24)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "0 - 25 mA"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.AliceBlue
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "HCL Current"
        '
        'cmbTurrEle
        '
        Me.cmbTurrEle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTurrEle.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTurrEle.Location = New System.Drawing.Point(120, 27)
        Me.cmbTurrEle.Name = "cmbTurrEle"
        Me.cmbTurrEle.Size = New System.Drawing.Size(120, 23)
        Me.cmbTurrEle.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.AliceBlue
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Turret, Element"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.AliceBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(264, 104)
        Me.Label1.TabIndex = 0
        '
        'frmChangeLampParameters
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(296, 199)
        Me.Controls.Add(Me.CustomPanel1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChangeLampParameters"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Change Lamp Parameters"
        Me.CustomPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables"
    Private mintNewTurretPosition As Integer = 0
    Shared mdblNewHCLCurrent As Double
    Dim mobjdtLampParameters As DataTable
    Shared mintLampNumber As Integer = 0
    Dim mintTurretNumber As Integer
#End Region

#Region "Constants"
    Private Const ConstColumnLampNumber = "LampNumber"
    Private Const ConstColumnTurretNumber = "TurretNumber"
    Private Const ConstColumnElement = "Element"
    Private Const ConstColumnDisplayElement = "DisplayElement"
#End Region

#Region "Form Events"
    Private Sub frmChangeLampParameters_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmChangeLampParameters_Load
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : Load the form Object
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 02.12.06
        ' Revisions             : Deepak on 14.08.07
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            '---call function initialize
            Call funcInitialise()
            'added by Pankaj on 04 Jun 07
            'If cmbTurrEle.SelectedIndex > -1 Then
            '    'mintNewTurretPosition = cmbTurrEle.SelectedIndex + 1
            '    'intTurrNO = CInt(Strings.Left(Trim(cmbTurrEle.SelectedItem), 1))      ' cmbTurrEle.SelectedIndex()
            '    mintNewTurretPosition = CInt(Strings.Left(Trim(cmbTurrEle.SelectedItem), 1))    ' cmbTurrEle.SelectedIndex()
            '    txtHCLCurr.Text = mdblNewHCLCurrent
            'End If
            '--------------
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

#Region "Private functions"

    Private Function funcInitialise()
        '=====================================================================
        ' Procedure Name        : funcInitialise
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : Initialise the form Object
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 02.12.06
        ' Revisions             : Deepak on 14.08.07
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim intLampIdx As Integer
        Try
            'If gobjInst.Lamp.LampParametersCollection.Count > 0 Then
            '    For intLampIdx = 0 To gobjInst.Lamp.LampParametersCollection.Count - 1
            '        If Not gobjInst.Lamp.LampParametersCollection(intLampIdx).ElementName = "" Then
            '            cmbTurrEle.Items.Add((intLampIdx + 1).ToString & ", " & gobjInst.Lamp.LampParametersCollection(intLampIdx).ElementName)
            '        End If
            '    Next
            '    If cmbTurrEle.Items.Count > 0 Then
            '        btnOk.Enabled = True
            '    Else
            '        btnOk.Enabled = False
            '    End If

            '    'If gobjInst.Lamp_Position > 0 Then
            '    '    If cmbTurrEle.Items.Count > 0 Then
            '    '        cmbTurrEle.SelectedIndex = 0
            '    '    End If
            '    'End If
            '    If (gintSelectedLampParameter > 0) Then
            '        cmbTurrEle.SelectedIndex = gintSelectedLampParameter
            '    End If
            '    'txtHCLCurr.Text = gobjInst.Current
            'End If

            mobjdtLampParameters = New DataTable
            Dim objRow As DataRow
            Dim intLampNumber As Integer = 0
            mobjdtLampParameters.Columns.Add(ConstColumnLampNumber)
            mobjdtLampParameters.Columns.Add(ConstColumnTurretNumber)
            mobjdtLampParameters.Columns.Add(ConstColumnElement)
            mobjdtLampParameters.Columns.Add(ConstColumnDisplayElement)

            '---add turret number and element name to the combo box.
            If gobjInst.Lamp.LampParametersCollection.Count > 0 Then
                For intLampIdx = 0 To gobjInst.Lamp.LampParametersCollection.Count - 1
                    If Not gobjInst.Lamp.LampParametersCollection(intLampIdx).ElementName = "" Then
                        intLampNumber = intLampNumber + 1
                        objRow = mobjdtLampParameters.NewRow
                        objRow.Item(ConstColumnLampNumber) = intLampNumber
                        objRow.Item(ConstColumnTurretNumber) = intLampIdx + 1
                        objRow.Item(ConstColumnElement) = gobjInst.Lamp.LampParametersCollection(intLampIdx).ElementName
                        objRow.Item(ConstColumnDisplayElement) = intLampIdx + 1 & " , " & gobjInst.Lamp.LampParametersCollection(intLampIdx).ElementName
                        mobjdtLampParameters.Rows.Add(objRow)
                    End If
                Next
                cmbTurrEle.DataSource = mobjdtLampParameters
                cmbTurrEle.DisplayMember = ConstColumnDisplayElement
                cmbTurrEle.ValueMember = ConstColumnLampNumber
            End If

            If mobjdtLampParameters.Rows.Count > 0 Then
                For intLampIdx = 0 To mobjdtLampParameters.Rows.Count - 1
                    If mobjdtLampParameters.Rows.Item(intLampIdx).Item(ConstColumnTurretNumber) = gobjInst.Lamp_Position Then
                        mintLampNumber = mobjdtLampParameters.Rows.Item(intLampIdx).Item(ConstColumnLampNumber)
                        cmbTurrEle.SelectedValue = mintLampNumber
                        cmbTurrEle_SelectedIndexChanged(Me, New EventArgs)
                    End If
                Next

                btnOk.Enabled = True
            Else
                btnOk.Enabled = False
            End If

            Call AddHandlers()
            ''for adding a event to a control
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
    End Function

    Private Function funcIniObject()
        '=====================================================================
        ' Procedure Name        : funcIniObject
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : Initialise the form Object
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 02.12.06
        ' Revisions             : praveen 
        '=====================================================================
        Dim dtTrretEle As DataTable
        Dim TurrAllIndx, TurrIndx As Integer

        Try
            Dim DtCol As New DataColumn
            TurrIndx = 0
            dtTrretEle = New DataTable
            For TurrAllIndx = 0 To gobjClsAAS203.funcGetMaxLamp() - 1
                ''make a counter for max num of lamp.
                If Not (LTrim(Trim(gobjInst.Lamp.LampParametersCollection(TurrAllIndx).ElementName)) = "") Then
                    cmbTurrEle.Items.Insert(TurrIndx, gobjInst.Lamp_Position.ToString & " " & (LTrim(Trim(gobjInst.Lamp.LampParametersCollection(TurrAllIndx).ElementName))))
                    TurrIndx += 1
                End If
            Next


            If gobjInst.Lamp_Position > 0 Then
                cmbTurrEle.SelectedIndex = gobjInst.Lamp_Position - 1
                'gobjInst.Lamp.LampParametersCollection(0).ElementName
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

    Private Sub AddHandlers()
        '=====================================================================
        ' Procedure Name        : AddHandlers
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To add event handlers
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 15.11.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is called for adding a event to a control
        ''this is called durong a initialisation 
        Try
            AddHandler btnOk.Click, AddressOf btnOk_Click
            ''for eg, if user clicked on OK button then btnOk_Click will called.
            AddHandler btnCancel.Click, AddressOf btnCancel_Click
            AddHandler cmbTurrEle.SelectedIndexChanged, AddressOf cmbTurrEle_SelectedIndexChanged
            '

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
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 02.12.06
        ' Revisions             : Deepak on 14.08.07
        '=====================================================================
        ''note:
        ''this is called when user clicked on OK button
        ''this is used to handle a OK cleck event.
        Dim objWait As New CWaitCursor
        Dim dblCurrent As Double
        Try
            '' funcPosition_Turret (hwnd, pos, TRUE);
            ''Set_HCL_Cur(cur , (BYTE) pos);
            ''added by Pankaj on 04 Jun 07
            'gintSelectedLampParameter = cmbTurrEle.SelectedIndex
            'If cmbTurrEle.SelectedIndex > -1 Then
            '    'mintNewTurretPosition = cmbTurrEle.SelectedIndex + 1
            '    'intTurrNO = CInt(Strings.Left(Trim(cmbTurrEle.SelectedItem), 1))      ' cmbTurrEle.SelectedIndex()
            '    mintNewTurretPosition = CInt(Strings.Left(Trim(cmbTurrEle.SelectedItem), 1))    ' cmbTurrEle.SelectedIndex()
            'End If

            '---position turret to given location
            If mintTurretNumber > 0 Then
                gobjCommProtocol.gFuncTurret_Position(mintTurretNumber, True)
            End If

            If Not Trim(txtHCLCurr.Text) = "" Then
                ''get a HCL current to temp variable.
                dblCurrent = CDbl(txtHCLCurr.Text)
            End If

            '---set hcl current to the given lamp
            If Not (dblCurrent = gobjInst.Current) Then
                gobjCommProtocol.funcSet_HCL_Cur(dblCurrent, gobjInst.Lamp_Position)
                ''function for setting HCL current at given position.
                gobjInst.Current = dblCurrent
            End If

            'Application.DoEvents()
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
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnCancel_Click
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : this is called when user click on cancel button.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 02.12.06
        ' Revisions             : Deepak on 14.08.07
        '=====================================================================
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub cmbTurrEle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : cmbTurrEle_SelectedIndexChanged
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 02.12.06
        ' Revisions             : Deepak on 14.08.07
        '=====================================================================
        ''note;
        ''this is a event realted to combo box.
        ''this is called when user change the turrert element.
        Dim objWait As New CWaitCursor
        Dim intTurrNO As Integer
        Dim intCount As Integer
        Dim intLampNumber As Integer
        Try
            'If cmbTurrEle.SelectedIndex > -1 Then
            '    'mintNewTurretPosition = cmbTurrEle.SelectedIndex + 1
            '    'intTurrNO = CInt(Strings.Left(Trim(cmbTurrEle.SelectedItem), 1))      ' cmbTurrEle.SelectedIndex()
            '    mintNewTurretPosition = CInt(Strings.Left(Trim(cmbTurrEle.SelectedItem), 1))    ' cmbTurrEle.SelectedIndex()
            '    'txtHCLCurr.Text = gobjInst.Current
            'End If

            '---display current of selected lamp element
            intLampNumber = cmbTurrEle.SelectedValue
            For intCount = 0 To mobjdtLampParameters.Rows.Count - 1
                If intLampNumber = mobjdtLampParameters.Rows.Item(intCount).Item(ConstColumnLampNumber) Then
                    mintTurretNumber = mobjdtLampParameters.Rows.Item(intCount).Item(ConstColumnTurretNumber)
                End If
            Next
            txtHCLCurr.Text = gobjInst.Current

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
