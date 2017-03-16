Imports AAS203.Common
Imports AAS203Library.Method
''above are the supporting headers file for this class
''this is a class behind the new method form

Public Class frmNewMethod
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
    Friend WithEvents Office2003Header1 As CodeIntellects.Office2003Controls.Office2003Header
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnHelp As NETXP.Controls.XPButton
    Friend WithEvents btnCancel As NETXP.Controls.XPButton
    Friend WithEvents btnOk As NETXP.Controls.XPButton
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents cmbOperationMode As System.Windows.Forms.ComboBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtMethodName As NumberValidator.NumberValidator
    Friend WithEvents txtUserName As NumberValidator.NumberValidator
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkStdAddition As System.Windows.Forms.CheckBox
    Friend WithEvents Panel201Lamps As System.Windows.Forms.Panel
    Friend WithEvents rdD2Lamp As System.Windows.Forms.RadioButton
    Friend WithEvents rdSRLamp As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmNewMethod))
        Me.CustomPanel1 = New GradientPanel.CustomPanel
        Me.Panel201Lamps = New System.Windows.Forms.Panel
        Me.rdSRLamp = New System.Windows.Forms.RadioButton
        Me.rdD2Lamp = New System.Windows.Forms.RadioButton
        Me.chkStdAddition = New System.Windows.Forms.CheckBox
        Me.txtUserName = New NumberValidator.NumberValidator
        Me.txtMethodName = New NumberValidator.NumberValidator
        Me.btnCancel = New NETXP.Controls.XPButton
        Me.btnOk = New NETXP.Controls.XPButton
        Me.txtComment = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbOperationMode = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Office2003Header1 = New CodeIntellects.Office2003Controls.Office2003Header
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnHelp = New NETXP.Controls.XPButton
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CustomPanel1.SuspendLayout()
        Me.Panel201Lamps.SuspendLayout()
        Me.SuspendLayout()
        '
        'CustomPanel1
        '
        Me.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanel1.Controls.Add(Me.Panel201Lamps)
        Me.CustomPanel1.Controls.Add(Me.chkStdAddition)
        Me.CustomPanel1.Controls.Add(Me.txtUserName)
        Me.CustomPanel1.Controls.Add(Me.txtMethodName)
        Me.CustomPanel1.Controls.Add(Me.btnCancel)
        Me.CustomPanel1.Controls.Add(Me.btnOk)
        Me.CustomPanel1.Controls.Add(Me.txtComment)
        Me.CustomPanel1.Controls.Add(Me.Label5)
        Me.CustomPanel1.Controls.Add(Me.Label4)
        Me.CustomPanel1.Controls.Add(Me.Label3)
        Me.CustomPanel1.Controls.Add(Me.cmbOperationMode)
        Me.CustomPanel1.Controls.Add(Me.Label2)
        Me.CustomPanel1.Controls.Add(Me.Office2003Header1)
        Me.CustomPanel1.Controls.Add(Me.Label1)
        Me.CustomPanel1.Controls.Add(Me.btnHelp)
        Me.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanel1.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanel1.Name = "CustomPanel1"
        Me.CustomPanel1.Size = New System.Drawing.Size(378, 347)
        Me.CustomPanel1.TabIndex = 0
        '
        'Panel201Lamps
        '
        Me.Panel201Lamps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel201Lamps.Controls.Add(Me.rdSRLamp)
        Me.Panel201Lamps.Controls.Add(Me.rdD2Lamp)
        Me.Panel201Lamps.Location = New System.Drawing.Point(218, 106)
        Me.Panel201Lamps.Name = "Panel201Lamps"
        Me.Panel201Lamps.Size = New System.Drawing.Size(150, 38)
        Me.Panel201Lamps.TabIndex = 12
        Me.Panel201Lamps.Visible = False
        '
        'rdSRLamp
        '
        Me.rdSRLamp.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdSRLamp.Location = New System.Drawing.Point(80, 4)
        Me.rdSRLamp.Name = "rdSRLamp"
        Me.rdSRLamp.Size = New System.Drawing.Size(56, 28)
        Me.rdSRLamp.TabIndex = 1
        Me.rdSRLamp.Text = "With SR Lamp"
        '
        'rdD2Lamp
        '
        Me.rdD2Lamp.Checked = True
        Me.rdD2Lamp.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdD2Lamp.Location = New System.Drawing.Point(8, 6)
        Me.rdD2Lamp.Name = "rdD2Lamp"
        Me.rdD2Lamp.Size = New System.Drawing.Size(60, 26)
        Me.rdD2Lamp.TabIndex = 0
        Me.rdD2Lamp.TabStop = True
        Me.rdD2Lamp.Text = "With D2 Lamp"
        '
        'chkStdAddition
        '
        Me.chkStdAddition.Location = New System.Drawing.Point(196, 116)
        Me.chkStdAddition.Name = "chkStdAddition"
        Me.chkStdAddition.Size = New System.Drawing.Size(20, 18)
        Me.chkStdAddition.TabIndex = 2
        Me.chkStdAddition.Text = "CheckBox1"
        '
        'txtUserName
        '
        Me.txtUserName.DigitsAfterDecimalPoint = 0
        Me.txtUserName.ErrorColor = System.Drawing.Color.Empty
        Me.txtUserName.ErrorMessage = Nothing
        Me.txtUserName.Location = New System.Drawing.Point(198, 148)
        Me.txtUserName.MaximumRange = 0
        Me.txtUserName.MaxLength = 40
        Me.txtUserName.MinimumRange = 0
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.RangeValidation = False
        Me.txtUserName.Size = New System.Drawing.Size(173, 21)
        Me.txtUserName.TabIndex = 3
        Me.txtUserName.Text = ""
        Me.txtUserName.ValidationType = NumberValidator.NumberValidator.Validations.AlphaNumeric
        '
        'txtMethodName
        '
        Me.txtMethodName.DigitsAfterDecimalPoint = 0
        Me.txtMethodName.ErrorColor = System.Drawing.Color.Empty
        Me.txtMethodName.ErrorMessage = Nothing
        Me.txtMethodName.Location = New System.Drawing.Point(196, 50)
        Me.txtMethodName.MaximumRange = 0
        Me.txtMethodName.MaxLength = 10
        Me.txtMethodName.MinimumRange = 0
        Me.txtMethodName.Name = "txtMethodName"
        Me.txtMethodName.RangeValidation = False
        Me.txtMethodName.Size = New System.Drawing.Size(173, 21)
        Me.txtMethodName.TabIndex = 0
        Me.txtMethodName.Text = ""
        Me.txtMethodName.ValidationType = NumberValidator.NumberValidator.Validations.AlphaNumeric
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(277, 293)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 34)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "&Cancel"
        '
        'btnOk
        '
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Image = CType(resources.GetObject("btnOk.Image"), System.Drawing.Image)
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(176, 293)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(86, 34)
        Me.btnOk.TabIndex = 5
        Me.btnOk.Text = "&OK"
        '
        'txtComment
        '
        Me.txtComment.Location = New System.Drawing.Point(21, 202)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtComment.Size = New System.Drawing.Size(342, 70)
        Me.txtComment.TabIndex = 4
        Me.txtComment.Text = "Comments for new method."
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 182)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 16)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Comments"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(18, 152)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "User name"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(156, 20)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Standard Addition"
        '
        'cmbOperationMode
        '
        Me.cmbOperationMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOperationMode.Items.AddRange(New Object() {"", "", ""})
        Me.cmbOperationMode.Location = New System.Drawing.Point(196, 80)
        Me.cmbOperationMode.Name = "cmbOperationMode"
        Me.cmbOperationMode.Size = New System.Drawing.Size(172, 23)
        Me.cmbOperationMode.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(182, 18)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Method type(Mode of operation)"
        '
        'Office2003Header1
        '
        Me.Office2003Header1.BackColor = System.Drawing.SystemColors.Control
        Me.Office2003Header1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Office2003Header1.Location = New System.Drawing.Point(0, 0)
        Me.Office2003Header1.Name = "Office2003Header1"
        Me.Office2003Header1.Size = New System.Drawing.Size(378, 22)
        Me.Office2003Header1.TabIndex = 3
        Me.Office2003Header1.TitleFont = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Office2003Header1.TitleText = "New Method"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(166, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Enter a new method name"
        '
        'btnHelp
        '
        Me.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHelp.Image = CType(resources.GetObject("btnHelp.Image"), System.Drawing.Image)
        Me.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHelp.Location = New System.Drawing.Point(278, 318)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(86, 34)
        Me.btnHelp.TabIndex = 11
        Me.btnHelp.Text = "Help"
        Me.btnHelp.Visible = False
        '
        'frmNewMethod
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(378, 347)
        Me.ControlBox = False
        Me.Controls.Add(Me.CustomPanel1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNewMethod"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Method"
        Me.CustomPanel1.ResumeLayout(False)
        Me.Panel201Lamps.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Private Constants"
    'this are the private constants which are used in new method creation

    Private Const ConstFormLoad = "-Method-New"
    Private Const ConstParentFormLoad = "-Method"

#End Region

#Region " Form Events"

    Private Sub frmNewMethod_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmNewMethod_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To initialize and load the form
        ' Description           : this is called when form in loaded
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this is called when form is loaded.
        Dim objDtMethod As New DataTable
        ''this is a object of DataTable data structur
        Dim objWait As New CWaitCursor


        Try
            Call gobjMain.ShowProgressBar(gstrTitleInstrumentType & ConstFormLoad)
            ''it's shows the some instrument info on status bar
            Call SubAddHandlers()
            ''this add all the event or handler to control

            objDtMethod = gobjClsAAS203.funcGetMethodTypes()
            ''To get method types from database e.g. AA,AABGC,UV,Emission
            If Not IsNothing(objDtMethod) Then
                ''check is objDtMethod object is NULL or Not
                ''this is realted to method data structure
                ''here we are getting some method info from data structure
                cmbOperationMode.DataSource = objDtMethod
                cmbOperationMode.ValueMember = objDtMethod.Columns(ConstColumnMethodTypeID).ColumnName
                cmbOperationMode.DisplayMember = objDtMethod.Columns(ConstColumnMethodType).ColumnName
            End If
            'to bind objDtMethod datatable to the combobox
            txtMethodName.Focus()
            txtMethodName.Select()
            'Saurabh 10.07.07 To bring status form in front
            If Not IsInIQOQPQ Then
                ''IsInIQOQPQ is a flag for whatever IQOQPQ is to be shown or not
                gobjfrmStatus.Show()
            Else
                'code added by : dinesh wagh on 15.2.2010
                'else condition added.
                chkStdAddition.Enabled = False
            End If
            'Saurabh

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

    Private Sub frmNewMethod_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        '=====================================================================
        ' Procedure Name        : frmNewMethod_Closing
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================

        gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType & ConstParentFormLoad)

        ''this will called when we close the NewMethod window
    End Sub

#End Region

#Region " Private Functions"

    Private Sub SubAddHandlers()
        '=====================================================================
        ' Procedure Name        : SubAddHandlers
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To add handlers
        ' Description           : to add a event to a control's
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 07.10.06
        ' Revisions             : 
        '=====================================================================
        AddHandler btnCancel.Click, AddressOf btnCancel_Click
        ''it means when we click on cancel button ,btnCancel_Click will called
        ''and so on....
        AddHandler btnOk.Click, AddressOf btnOk_Click
        AddHandler cmbOperationMode.SelectedIndexChanged, AddressOf cmbOperationMode_SelectedIndexChanged
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnCancel_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To cancel the form
        ' Description           : this event is call when we click on cancel button
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
        ' Description           : this event is called when we click OK button
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Dim strMethodName As String
        Dim strUserName As String
        Dim blnStdAddition As Boolean
        Dim intMethodTypeID As Integer
        Dim intMethodID As Integer
        Dim strComments As String
        Dim intCounter As Integer
        Dim objWait As New CWaitCursor
        ''above are the temp variable for accumulate temp value
        ''for ex strMethodName will store methodname ect....

        Try
            ''check that method name and user name must be enterd properly
            ''test for the validation 
            If Trim(txtMethodName.Text) = "" Or Trim(txtUserName.Text) = "" Then
                If Trim(txtMethodName.Text) = "" Then
                    gobjMessageAdapter.ShowMessage(constEnterMethodName)
                    ''prompt msg if method name or user name empty
                    txtMethodName.Focus()
                    Application.DoEvents()
                Else
                    gobjMessageAdapter.ShowMessage(constEnterUserName)
                    ''prompt if user name is empty
                    txtUserName.Focus()
                    Application.DoEvents()
                End If
                Exit Sub
            Else
                ''make a counter of total method count to zero in step -1
                ''for getting total num of method in a data structur

                For intCounter = gobjMethodCollection.Count - 1 To 0 Step -1
                    ''check if method name already exit or not 
                    If Trim(gobjMethodCollection.item(intCounter).MethodName) = Trim(txtMethodName.Text) Then
                        ''is yes then prompt message
                        gobjMessageAdapter.ShowMessage(constMethodNameExists)
                        txtMethodName.Focus()
                        Application.DoEvents()
                        ''allow application to perfrom its panding work.
                        Exit Sub
                    End If
                Next
            End If

            'intMethodID = gobjMethodCollection.Count + 1
            intMethodID = getMaxMethodID() + 1 ' Added By Pankaj on 25 MAy 07
            ''increment the method id by 1. and store in the data structure
            strMethodName = Trim(txtMethodName.Text)
            strUserName = Trim(txtUserName.Text)

            If chkStdAddition.Checked = True Then
                blnStdAddition = True
                ''blnStdAddition is a flag for std addition option
                ''if it is true then create a method with std addition option

            Else
                blnStdAddition = False
            End If

            intMethodTypeID = cmbOperationMode.SelectedValue
            strComments = Trim(txtComment.Text)

            gobjNewMethod = New clsMethod
            ''clsMethod is a class(like data structure for method) which contains the all method info
            ''which will save as well as used in software

            ''below are the code by which we are sending all user defined method info to temp variable in method data structure
            ''for exa
            gobjNewMethod.MethodID = intMethodID
            ''this will send a method id given by user  to method data structure.
            gobjNewMethod.MethodName = strMethodName
            gobjNewMethod.OperationMode = intMethodTypeID
            gobjNewMethod.StandardAddition = blnStdAddition
            gobjNewMethod.UserName = strUserName
            gobjNewMethod.Comments = strComments
            gobjNewMethod.DateOfCreation = DateTime.Now
            gobjNewMethod.Status = True
            'gobjNewMethod.Status = False 'Added By Pankaj on 23 MAy 07
            gobjNewMethod.DateOfModification = Date.FromOADate(0.0)
            gobjNewMethod.DateOfLastUse = Date.FromOADate(0.0)

            'frmMethod.mintMethodMode = EnumMethodMode.NewMode
            Me.DialogResult = DialogResult.OK
            Application.DoEvents()

            'Saurabh on 28 MAy 2007
            ''check a cond for operation mode if mode is UVABS or not
            If gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS Then
                ''if yes then do some validation on status form 
                If gobjfrmStatus.lblTurretNo.Visible = True Then
                    gobjfrmStatus.lblTurretNo.Visible = False
                End If
                If gobjfrmStatus.lblElementName.Visible = True Then
                    gobjfrmStatus.lblElementName.Visible = False
                End If
            ElseIf gobjNewMethod.OperationMode = EnumOperationMode.MODE_AA Or _
            gobjNewMethod.OperationMode = EnumOperationMode.MODE_AABGC Then
                If gobjfrmStatus.lblTurretNo.Visible = False Then
                    gobjfrmStatus.lblTurretNo.Visible = True
                    ''this will show the turretno in status window

                End If
                If gobjfrmStatus.lblElementName.Visible = False Then
                    gobjfrmStatus.lblElementName.Visible = True
                End If
            End If
            If gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
                If gobjfrmStatus.lblTurretNo.Visible = True Then
                    gobjfrmStatus.lblTurretNo.Visible = False
                End If
                If gobjfrmStatus.lblElementName.Visible = False Then
                    gobjfrmStatus.lblElementName.Visible = True
                End If
                gobjfrmStatus.lblElementName.Text = ""
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

    Private Function getMaxMethodID() As Integer
        '=====================================================================
        ' Procedure Name        : getMaxMethodID
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : Select Max Id of Method No
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Dim i, iMax As Integer
        ''note:
        ''this function is used for getting maximum method id.
        ''so that software can provide new ID to New Method

        Try
            iMax = 0
            ''gobjMethodCollection.Count give the total count of method store in a data structure 
            For i = 0 To gobjMethodCollection.Count - 1
                If (iMax < gobjMethodCollection.item(i).MethodID) Then
                    iMax = gobjMethodCollection.item(i).MethodID
                End If

            Next
            getMaxMethodID = iMax
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

    Private Sub cmbOperationMode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : cmbOperationMode_SelectedIndexChanged
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : changed a mode on a combo box
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        'gobjAAS203Library.mobjMethod.OperationMode = cmbOperationMode.SelectedIndex
        'Added By Pankaj on 30 May 07
        ''note;
        ''this is called when we changed a mode on a combbox
        ''here we made some validation onscreen as par mode selected

        Try

            If (cmbOperationMode.Text = "AABGC Quantitative Mode") Then
                If (gstructSettings.AppMode = EnumAppMode.FullVersion_201) Then
                    Panel201Lamps.Visible = True
                End If
            Else
                Panel201Lamps.Visible = False
            End If
            '------------
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
