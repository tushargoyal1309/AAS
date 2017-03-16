Imports AAS203.Common
Imports AAS203Library.Method
Imports AAS203Library.Instrument

Public Class frmLampPlacements
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mblnIsOperated = False
    End Sub

    Public Sub New(ByVal intSelectedTurretNum As Integer, ByVal intOpenMethodMode As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        Call subInit(intSelectedTurretNum, intOpenMethodMode)

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
    Friend WithEvents CustomPanelMain As GradientPanel.CustomPanel
    Friend WithEvents HeaderTop As CodeIntellects.Office2003Controls.Office2003Header
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTurretNo As System.Windows.Forms.Label
    Friend WithEvents lblElementName As System.Windows.Forms.Label
    Friend WithEvents lbl1 As System.Windows.Forms.Label
    Friend WithEvents lbl2 As System.Windows.Forms.Label
    Friend WithEvents lbl3 As System.Windows.Forms.Label
    Friend WithEvents lbl4 As System.Windows.Forms.Label
    Friend WithEvents lbl5 As System.Windows.Forms.Label
    Friend WithEvents lbl6 As System.Windows.Forms.Label
    Friend WithEvents txt1 As System.Windows.Forms.TextBox
    Friend WithEvents txt3 As System.Windows.Forms.TextBox
    Friend WithEvents txt4 As System.Windows.Forms.TextBox
    Friend WithEvents txt5 As System.Windows.Forms.TextBox
    Friend WithEvents txt6 As System.Windows.Forms.TextBox
    Friend WithEvents txt2 As System.Windows.Forms.TextBox
    Friend WithEvents btnInsertLamp As NETXP.Controls.XPButton
    Friend WithEvents btnRemoveLamp As NETXP.Controls.XPButton
    Friend WithEvents btnHelp As NETXP.Controls.XPButton
    Friend WithEvents btnOk As NETXP.Controls.XPButton
    Friend WithEvents btnCancel As NETXP.Controls.XPButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmLampPlacements))
        Me.CustomPanelMain = New GradientPanel.CustomPanel
        Me.btnHelp = New NETXP.Controls.XPButton
        Me.btnOk = New NETXP.Controls.XPButton
        Me.btnCancel = New NETXP.Controls.XPButton
        Me.btnRemoveLamp = New NETXP.Controls.XPButton
        Me.btnInsertLamp = New NETXP.Controls.XPButton
        Me.txt6 = New System.Windows.Forms.TextBox
        Me.txt5 = New System.Windows.Forms.TextBox
        Me.txt4 = New System.Windows.Forms.TextBox
        Me.txt3 = New System.Windows.Forms.TextBox
        Me.txt2 = New System.Windows.Forms.TextBox
        Me.txt1 = New System.Windows.Forms.TextBox
        Me.lbl6 = New System.Windows.Forms.Label
        Me.lbl5 = New System.Windows.Forms.Label
        Me.lbl4 = New System.Windows.Forms.Label
        Me.lbl3 = New System.Windows.Forms.Label
        Me.lbl2 = New System.Windows.Forms.Label
        Me.lbl1 = New System.Windows.Forms.Label
        Me.lblElementName = New System.Windows.Forms.Label
        Me.lblTurretNo = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.HeaderTop = New CodeIntellects.Office2003Controls.Office2003Header
        Me.CustomPanelMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'CustomPanelMain
        '
        Me.CustomPanelMain.BackColor = System.Drawing.Color.Transparent
        Me.CustomPanelMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.CustomPanelMain.Controls.Add(Me.btnHelp)
        Me.CustomPanelMain.Controls.Add(Me.btnOk)
        Me.CustomPanelMain.Controls.Add(Me.btnCancel)
        Me.CustomPanelMain.Controls.Add(Me.btnRemoveLamp)
        Me.CustomPanelMain.Controls.Add(Me.btnInsertLamp)
        Me.CustomPanelMain.Controls.Add(Me.txt6)
        Me.CustomPanelMain.Controls.Add(Me.txt5)
        Me.CustomPanelMain.Controls.Add(Me.txt4)
        Me.CustomPanelMain.Controls.Add(Me.txt3)
        Me.CustomPanelMain.Controls.Add(Me.txt2)
        Me.CustomPanelMain.Controls.Add(Me.txt1)
        Me.CustomPanelMain.Controls.Add(Me.lbl6)
        Me.CustomPanelMain.Controls.Add(Me.lbl5)
        Me.CustomPanelMain.Controls.Add(Me.lbl4)
        Me.CustomPanelMain.Controls.Add(Me.lbl3)
        Me.CustomPanelMain.Controls.Add(Me.lbl2)
        Me.CustomPanelMain.Controls.Add(Me.lbl1)
        Me.CustomPanelMain.Controls.Add(Me.lblElementName)
        Me.CustomPanelMain.Controls.Add(Me.lblTurretNo)
        Me.CustomPanelMain.Controls.Add(Me.Label1)
        Me.CustomPanelMain.Controls.Add(Me.HeaderTop)
        Me.CustomPanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanelMain.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanelMain.Name = "CustomPanelMain"
        Me.CustomPanelMain.Size = New System.Drawing.Size(338, 327)
        Me.CustomPanelMain.TabIndex = 0
        '
        'btnHelp
        '
        Me.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHelp.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHelp.Image = CType(resources.GetObject("btnHelp.Image"), System.Drawing.Image)
        Me.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHelp.Location = New System.Drawing.Point(240, 216)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(86, 34)
        Me.btnHelp.TabIndex = 8
        Me.btnHelp.Text = "&Help"
        Me.btnHelp.Visible = False
        '
        'btnOk
        '
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Image = CType(resources.GetObject("btnOk.Image"), System.Drawing.Image)
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(240, 66)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(86, 34)
        Me.btnOk.TabIndex = 6
        Me.btnOk.Text = "&OK"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(240, 141)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 34)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnRemoveLamp
        '
        Me.btnRemoveLamp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemoveLamp.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveLamp.Image = CType(resources.GetObject("btnRemoveLamp.Image"), System.Drawing.Image)
        Me.btnRemoveLamp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRemoveLamp.Location = New System.Drawing.Point(171, 280)
        Me.btnRemoveLamp.Name = "btnRemoveLamp"
        Me.btnRemoveLamp.Size = New System.Drawing.Size(128, 38)
        Me.btnRemoveLamp.TabIndex = 10
        Me.btnRemoveLamp.Text = "&Remove Lamp"
        Me.btnRemoveLamp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnInsertLamp
        '
        Me.btnInsertLamp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInsertLamp.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInsertLamp.Image = CType(resources.GetObject("btnInsertLamp.Image"), System.Drawing.Image)
        Me.btnInsertLamp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnInsertLamp.Location = New System.Drawing.Point(27, 280)
        Me.btnInsertLamp.Name = "btnInsertLamp"
        Me.btnInsertLamp.Size = New System.Drawing.Size(128, 38)
        Me.btnInsertLamp.TabIndex = 9
        Me.btnInsertLamp.Text = "&Insert Lamp"
        Me.btnInsertLamp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt6
        '
        Me.txt6.BackColor = System.Drawing.Color.White
        Me.txt6.Location = New System.Drawing.Point(96, 238)
        Me.txt6.Name = "txt6"
        Me.txt6.ReadOnly = True
        Me.txt6.Size = New System.Drawing.Size(89, 20)
        Me.txt6.TabIndex = 5
        Me.txt6.Tag = "6"
        Me.txt6.Text = ""
        Me.txt6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt5
        '
        Me.txt5.BackColor = System.Drawing.Color.White
        Me.txt5.Location = New System.Drawing.Point(96, 206)
        Me.txt5.Name = "txt5"
        Me.txt5.ReadOnly = True
        Me.txt5.Size = New System.Drawing.Size(89, 20)
        Me.txt5.TabIndex = 4
        Me.txt5.Tag = "5"
        Me.txt5.Text = ""
        Me.txt5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt4
        '
        Me.txt4.BackColor = System.Drawing.Color.White
        Me.txt4.Location = New System.Drawing.Point(96, 174)
        Me.txt4.Name = "txt4"
        Me.txt4.ReadOnly = True
        Me.txt4.Size = New System.Drawing.Size(89, 20)
        Me.txt4.TabIndex = 3
        Me.txt4.Tag = "4"
        Me.txt4.Text = ""
        Me.txt4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt3
        '
        Me.txt3.BackColor = System.Drawing.Color.White
        Me.txt3.Location = New System.Drawing.Point(96, 142)
        Me.txt3.Name = "txt3"
        Me.txt3.ReadOnly = True
        Me.txt3.Size = New System.Drawing.Size(89, 20)
        Me.txt3.TabIndex = 2
        Me.txt3.Tag = "3"
        Me.txt3.Text = ""
        Me.txt3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt2
        '
        Me.txt2.BackColor = System.Drawing.Color.White
        Me.txt2.Location = New System.Drawing.Point(96, 110)
        Me.txt2.Name = "txt2"
        Me.txt2.ReadOnly = True
        Me.txt2.Size = New System.Drawing.Size(89, 20)
        Me.txt2.TabIndex = 1
        Me.txt2.Tag = "2"
        Me.txt2.Text = ""
        Me.txt2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt1
        '
        Me.txt1.BackColor = System.Drawing.Color.White
        Me.txt1.Location = New System.Drawing.Point(96, 78)
        Me.txt1.Name = "txt1"
        Me.txt1.ReadOnly = True
        Me.txt1.Size = New System.Drawing.Size(89, 20)
        Me.txt1.TabIndex = 0
        Me.txt1.Tag = "1"
        Me.txt1.Text = ""
        Me.txt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbl6
        '
        Me.lbl6.Location = New System.Drawing.Point(35, 234)
        Me.lbl6.Name = "lbl6"
        Me.lbl6.Size = New System.Drawing.Size(36, 20)
        Me.lbl6.TabIndex = 9
        Me.lbl6.Text = "6"
        Me.lbl6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl5
        '
        Me.lbl5.Location = New System.Drawing.Point(35, 202)
        Me.lbl5.Name = "lbl5"
        Me.lbl5.Size = New System.Drawing.Size(36, 20)
        Me.lbl5.TabIndex = 8
        Me.lbl5.Text = "5"
        Me.lbl5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl4
        '
        Me.lbl4.Location = New System.Drawing.Point(35, 170)
        Me.lbl4.Name = "lbl4"
        Me.lbl4.Size = New System.Drawing.Size(36, 20)
        Me.lbl4.TabIndex = 7
        Me.lbl4.Text = "4"
        Me.lbl4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl3
        '
        Me.lbl3.Location = New System.Drawing.Point(35, 138)
        Me.lbl3.Name = "lbl3"
        Me.lbl3.Size = New System.Drawing.Size(36, 20)
        Me.lbl3.TabIndex = 6
        Me.lbl3.Text = "3"
        Me.lbl3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl2
        '
        Me.lbl2.Location = New System.Drawing.Point(35, 106)
        Me.lbl2.Name = "lbl2"
        Me.lbl2.Size = New System.Drawing.Size(36, 20)
        Me.lbl2.TabIndex = 5
        Me.lbl2.Text = "2"
        Me.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl1
        '
        Me.lbl1.Location = New System.Drawing.Point(35, 74)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(36, 20)
        Me.lbl1.TabIndex = 4
        Me.lbl1.Text = "1"
        Me.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblElementName
        '
        Me.lblElementName.Location = New System.Drawing.Point(95, 38)
        Me.lblElementName.Name = "lblElementName"
        Me.lblElementName.Size = New System.Drawing.Size(89, 23)
        Me.lblElementName.TabIndex = 3
        Me.lblElementName.Text = "Element Name"
        Me.lblElementName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTurretNo
        '
        Me.lblTurretNo.Location = New System.Drawing.Point(22, 38)
        Me.lblTurretNo.Name = "lblTurretNo"
        Me.lblTurretNo.Size = New System.Drawing.Size(64, 23)
        Me.lblTurretNo.TabIndex = 2
        Me.lblTurretNo.Text = "Turret No."
        Me.lblTurretNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Location = New System.Drawing.Point(15, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(211, 236)
        Me.Label1.TabIndex = 1
        '
        'HeaderTop
        '
        Me.HeaderTop.BackColor = System.Drawing.SystemColors.Control
        Me.HeaderTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.HeaderTop.Location = New System.Drawing.Point(0, 0)
        Me.HeaderTop.Name = "HeaderTop"
        Me.HeaderTop.Size = New System.Drawing.Size(338, 20)
        Me.HeaderTop.TabIndex = 0
        Me.HeaderTop.TitleFont = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderTop.TitleText = "Insert/Remove Lamp"
        '
        'frmLampPlacements
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(338, 327)
        Me.Controls.Add(Me.CustomPanelMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLampPlacements"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lamp Placements"
        Me.CustomPanelMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Public Variables, Events, Constants "

    Public mobjInstrumentParameters As clsInstrumentParameters
    Public Event LampReplaced()
    Public Event LampRemoved()

#End Region

#Region " Private Class Member Variables "

    Private mintTurretPosition As Integer = 0
    Private mintLatestTurretPosition As Integer = 0
    Private mintOpenMethodMode As Integer = 0
    Public mblnIsOperated As Boolean = False
    Private mblnIsSetTurret_Home As Boolean

#End Region

#Region " Private Constants "

    Private Const ConstFormLoad = "-Method-InstrumentParameters-LampPlacements"
    Private Const ConstParentFormLoad = "-Method-InstrumentParameters"

#End Region

#Region " Private Properties "

    Public Property TurretPosition() As Integer
        Get
            Return mintTurretPosition
        End Get
        Set(ByVal Value As Integer)
            mintTurretPosition = Value
        End Set
    End Property

    Private Property OpenMethodMode() As EnumMethodMode
        Get
            Return mintOpenMethodMode
        End Get
        Set(ByVal Value As EnumMethodMode)
            mintOpenMethodMode = Value
        End Set
    End Property

#End Region

#Region " Form Events "

    Private Sub frmLampPlacements_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmLampPlacements_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To Add event handlers and to initialize the form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 05.10.06
        ' Revisions             : praveen
        '=====================================================================
        Dim objWait As New CWaitCursor
        ''note:

        Try
            '---to load the form by adding handlers and by initializing
            Call AddHandlers()
            ''for adding a event to a control.
            Call funcInitialise()
            ''do some initialisation.
            btnInsertLamp.Focus()

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
            objWait.Dispose()
            '---------------------------------------------------------
        End Try
    End Sub

#End Region

#Region " Functions "

    Private Sub AddHandlers()
        '=====================================================================
        ' Procedure Name        : AddHandlers
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To Add event handlers 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor

        Try
            'to add handlers
            AddHandler txt1.Enter, AddressOf GetTurretPosition
            AddHandler txt2.Enter, AddressOf GetTurretPosition
            AddHandler txt3.Enter, AddressOf GetTurretPosition
            AddHandler txt4.Enter, AddressOf GetTurretPosition
            AddHandler txt5.Enter, AddressOf GetTurretPosition
            AddHandler txt6.Enter, AddressOf GetTurretPosition

            AddHandler btnInsertLamp.Click, AddressOf btnInsertLamp_Click
            AddHandler btnRemoveLamp.Click, AddressOf btnRemoveLamp_Click
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

    Private Sub btnInsertLamp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnInsertLamp_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To insert lamp 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak, Rahul
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        'Steps:
        'Open CookBook View to select the element
        'After selection of element perform necessary instrument operations
        'Get the object of clsInstrumentParameters
        'Add this object to the object collection
        Dim objWait As New CWaitCursor
        Dim objDtElement As New DataTable
        Dim objDtElementWvs As New DataTable
        Dim objfrmCookBook As New frmCookBook
        Dim objClsInstrumentParameters As clsInstrumentParameters
        Dim intRowCounter As Integer
        Dim dblWV As Double
        Dim nosteps As Int16
        Dim objLampPar As New AAS203Library.Instrument.ClsLampParameters
        Dim objwait1 As New CWaitCursor
        Dim intCount As Integer

        Try
            '---set turret to home position
            '---10.02.08
            'If mblnIsSetTurret_Home = False Then
            '    Call gobjCommProtocol.gFuncTurret_Home()
            '    mblnIsSetTurret_Home = True
            'End If

            Dim dlgResult As New DialogResult

            'Added By Pankaj on 26 Aug 07 
            '---to show cook book form for inserting lamp
            If (ISCookBookShown() = "") Then
                dlgResult = objfrmCookBook.ShowDialog()
            Else
                If (TurretPosition > 0) Then
                    objfrmCookBook.ElementID = gobjDataAccess.GetCookBookElementID(gobjInst.Lamp.LampParametersCollection.item(TurretPosition - 1).AtomicNumber)
                Else
                    objfrmCookBook.ElementID = gobjDataAccess.GetCookBookElementID(gobjInst.Lamp.LampParametersCollection.item(0).AtomicNumber)
                End If
                dlgResult = DialogResult.OK
            End If

            If dlgResult = DialogResult.OK Then 'Added By pankaj on 26 Aug 07
                mblnIsOperated = True
                Application.DoEvents()
                objwait1 = New CWaitCursor

                If objfrmCookBook.ElementID <> 0 Then
                    '---get selected element details
                    objDtElement = gobjClsAAS203.funcGetElement(objfrmCookBook.ElementID)
                    '---get wavelengths of selected element
                    objDtElementWvs = gobjClsAAS203.funcGetElementWavelengths(objfrmCookBook.ElementID)

                    '---set element details to object variables
                    If Not IsNothing(objDtElement) And objDtElement.Rows.Count > 0 Then
                        mobjInstrumentParameters = New clsInstrumentParameters
                        mobjInstrumentParameters.ElementID = CInt(objDtElement.Rows(0).Item(ConstColumnElementID))
                        mobjInstrumentParameters.ElementName = objDtElement.Rows(0).Item(ConstColumnElementName)
                        mobjInstrumentParameters.LampCurrent = CDbl(objDtElement.Rows(0).Item(ConstColumnCurrent))
                        mobjInstrumentParameters.TurretNumber = CInt(TurretPosition)

                        If Not IsNothing(objDtElementWvs) Then
                            If objDtElementWvs.Rows.Count > 0 Then
                                mobjInstrumentParameters.SlitWidth = CDbl(objDtElementWvs.Rows(0).Item("SLIT"))
                                mobjInstrumentParameters.Wavelength = objDtElementWvs
                            End If
                        End If
                        'Saurabh on 28 May 2007
                    End If

                    '---Getting Lamp No. ## for replacement .... Please Wait
                    Call gobjMessageAdapter.ShowStatusMessageBox("Getting Lamp No. " & TurretPosition & " for replacement...Please Wait", "Lamp Replacement", EnumMessageType.Information, 0)
                    Application.DoEvents()
                    gobjfrmStatus.lblTurretNo.Visible = True        'Added by Saurabh

                    '---initialize lamp parameters
                    If gfuncInit_Lamp_Par(objLampPar) = True Then
                        If Not objDtElement Is Nothing Then
                            If objDtElement.Rows.Count > 0 Then
                                objLampPar.ElementName = CStr(objDtElement.Rows(0).Item(ConstColumnElementName))
                                objLampPar.Current = CDbl(objDtElement.Rows(0).Item("CURRENT"))
                                objLampPar.AtomicNumber = CInt(objDtElement.Rows(0).Item("ATNO"))
                                If Not objDtElementWvs Is Nothing Then
                                    If objDtElementWvs.Rows.Count > 0 Then
                                        objLampPar.SlitWidth = CDbl(objDtElementWvs.Rows(0).Item("SLIT"))
                                        objLampPar.Wavelength = CDbl(objDtElementWvs.Rows(0).Item("WV"))
                                    End If
                                End If
                            End If
                        End If

                        '---set details of lamp selected in instrument object
                        If gfuncSet_Lamp_Parameters(objLampPar, TurretPosition - 1) = True Then
                            '--- set turret to home position
                            '---10.02.08
                            'If gobjCommProtocol.gFuncTurret_Home() Then
                            '---calculate steps to reach turret at top
                            nosteps = gfuncTurretStepsForLampTop(TurretPosition)
                            '---rotate turret clockwise with above mentioned steps
                            If gobjCommProtocol.funcRotate_Steps_Tur_Clock(nosteps) Then
                                gobjMessageAdapter.CloseStatusMessageBox()
                                Application.DoEvents()
                                '---Insert Cu Lamp in turret No. 3 and click OK button                       
                                If gobjMessageAdapter.ShowMessage("Insert " & objLampPar.ElementName & " lamp in turret No. " & TurretPosition & " and click OK button", "Lamp Replacement", EnumMessageType.Information) Then
                                    Application.DoEvents()
                                    Dim objwait2 As New CWaitCursor
                                    '---Initializing .... Please Wait
                                    Application.DoEvents()

                                    'sprintf(tmsg,"Initialising .... Please Wait ");
                                    'SetDlgItemText(hwnd,100,tmsg);
                                    'UpdateWindow(hwnd);
                                    'Rotate_Steps_Tur_AntiClock(nosteps+10);
                                    'Rotate_Steps_Tur_Clock(10);

                                    gobjMessageAdapter.ShowStatusMessageBox("Initializing .... Please Wait", "Lamp Replacement", EnumMessageType.Information, 0)
                                    Application.DoEvents()
                                    '---position turret to home position
                                    '---10.02.08
                                    gobjCommProtocol.funcRotate_Steps_Tur_AntiClock(nosteps + 10)
                                    gobjCommProtocol.funcRotate_Steps_Tur_Clock(10)
                                    '---10.02.08
                                    'gobjCommProtocol.gFuncTurret_Home()
                                    mintLatestTurretPosition = TurretPosition 'objClsInstrumentParameters.TurretNumber
                                    '---set lamp as connected in instrument object
                                    gfuncLamp_connected(TurretPosition)
                                    gobjMessageAdapter.CloseStatusMessageBox()
                                    Application.DoEvents()
                                    '---display all inserted/removed lamps on screen
                                    funcInitiliaze_Lamps()
                                    RaiseEvent LampReplaced()
                                End If
                            End If
                            'End If
                        End If
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            gobjMessageAdapter.CloseStatusMessageBox()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Function ISCookBookShown() As String
        '=====================================================================
        ' Procedure Name        : ISCookBookShown
        ' Parameters Passed     : 
        ' Returns               : True or False
        ' Purpose               : To Check that CookBook Should be show or not
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Praveen S Deshmukh
        ' Created               : 14.08.07
        ' Revisions             : not in used.
        '=====================================================================
        Dim txtElementName As String
        Try
            '---check whether lamp is present in given position or not
            Select Case TurretPosition
                Case 1
                    txtElementName = txt1.Text
                Case 2
                    txtElementName = txt2.Text
                Case 3
                    txtElementName = txt3.Text
                Case 4
                    txtElementName = txt4.Text
                Case 5
                    txtElementName = txt5.Text
                Case 6
                    txtElementName = txt6.Text
                Case Else
                    txtElementName = ""
            End Select
            Return txtElementName.Trim()
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            txtElementName = ""
            Return ""
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

    Private Sub btnRemoveLamp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnRemoveLamp_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To remove lamp
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 05.10.06
        ' Revisions             : 15.12.06 by Deepak B.
        '=====================================================================
        ' void	RemoveLamp(HWND hwnd, int lamp, char *elname)
        '{
        'LAMP_PAR   tLamp;
        ' Init_Lamp_Par(&tLamp);
        ' Set_Lamp_Parameters(&tLamp, lamp);
        ' SetLampToTop(hwnd, lamp, elname, FALSE);
        ' Lamp_connected(lamp);
        ' Initiliaze_Lamps(hwnd);
        '}
        Dim intObjCount As Integer
        Dim objWait As New CWaitCursor
        Dim nosteps As Integer
        Dim objLamp As New AAS203Library.Instrument.ClsLampParameters
        Dim strLampName As String
        Dim intCount As Integer

        Try
            mblnIsOperated = True
            '//----- Added by Sachin Dokhale on 31.08.07 to init. Turret Home 
            '---set turret to home position

            '---10.02.08
            'If mblnIsSetTurret_Home = False Then
            '    Call gobjCommProtocol.gFuncTurret_Home()
            '    mblnIsSetTurret_Home = True
            'End If

            '//-----

            strLampName = gobjInst.Lamp.LampParametersCollection.item(TurretPosition - 1).ElementName
            If (strLampName = "") Then 'Added By pankaj on 25 aug 07 
                Exit Sub
            End If
            '---Getting Lamp No. ## for replacement .... Please Wait
            gobjMessageAdapter.ShowStatusMessageBox("Getting Lamp No. " & TurretPosition & " for replacement...Please Wait", "Lamp Replacement", EnumMessageType.Information, 0)
            Application.DoEvents()

            '---initialize instrument object for removal of lamp
            If gfuncInit_Lamp_Par(objLamp) = True Then
                '---set lamp parameters
                If gfuncSet_Lamp_Parameters(objLamp, TurretPosition - 1) = True Then
                    '---set turret to home position
                    '---10.02.08
                    'If gobjCommProtocol.gFuncTurret_Home() Then
                    '---calculate steps required to bring turret to top
                    nosteps = gfuncTurretStepsForLampTop(TurretPosition)
                    '---rotate turret clockwise with above mentioned steps
                    If gobjCommProtocol.funcRotate_Steps_Tur_Clock(nosteps) Then
                        '---Insert Cu Lamp in turret No. 3 and click OK button
                        gobjMessageAdapter.CloseStatusMessageBox()
                        Application.DoEvents()
                        gobjMessageAdapter.ShowMessage("Remove " & strLampName & " lamp in turret No. " & TurretPosition & " and click OK button", "Lamp Replacement", EnumMessageType.Information)
                        Application.DoEvents()
                        Dim objwait1 As New CWaitCursor
                        '---update instrument object after removal of lamp
                        gfuncLamp_connected(TurretPosition)
                        Application.DoEvents()
                        gobjMessageAdapter.ShowStatusMessageBox("Initializing .... Please Wait", "Lamp Replacement", EnumMessageType.Information, 0)
                        Application.DoEvents()
                        '---bring turret to home position

                        '---10.02.08
                        'gobjCommProtocol.gFuncTurret_Home()
                        gobjCommProtocol.funcRotate_Steps_Tur_AntiClock(nosteps + 10)
                        gobjCommProtocol.funcRotate_Steps_Tur_Clock(10)

                        gobjMessageAdapter.CloseStatusMessageBox()
                        '---display inserted/removed lamps
                        funcInitiliaze_Lamps()
                        RaiseEvent LampRemoved()
                    End If
                    'End If
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            gobjMessageAdapter.CloseStatusMessageBox()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnOk_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To send dialog result ok
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Dim intCounter As Integer
        Dim objWait As New CWaitCursor
        Try
            Application.DoEvents()
            ''allow application to perfrom its panding work.
            If mblnIsOperated = False Then
                Me.DialogResult = DialogResult.Cancel
            Else
                Me.DialogResult = DialogResult.OK
            End If
            Application.DoEvents()
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
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To send dialog result cancel
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

    Private Sub subInit(ByVal intSelectedTurretPosition As Integer, ByVal intOpenMethodMode As Integer)
        '=====================================================================
        ' Procedure Name        : subInit
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To initialize the form with lamp positions
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim intObjCount As Integer
        Dim intTurret As Integer
        Dim strElementName As String

        Try
            mblnIsOperated = False

            '---set initial turret position
            TurretPosition = intSelectedTurretPosition
            OpenMethodMode = intOpenMethodMode

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

    Private Sub GetTurretPosition(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : GetTurretPosition
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To set the turret position
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Try
            '---set turret position according to the mouse clicked
            TurretPosition = CType(sender, System.Windows.Forms.TextBox).Tag()

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

    Private Function funcInitialise() As Boolean
        '=====================================================================
        ' Procedure Name        : funcInitialise
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To initialize the form by displaying all inserted lamps
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor

        Try
            '---10.02.08
            gobjCommProtocol.gFuncTurret_Home()
            Application.DoEvents()

            '---display all elements from instrument object 
            HeaderTop.TitleText = "Insert-Remove Lamp"
            Dim intCount As Integer
            Dim strelementname As String
            For intCount = 0 To gobjInst.Lamp.LampParametersCollection.Count - 1
                strelementname = gobjInst.Lamp.LampParametersCollection.item(intCount).ElementName
                Select Case intCount + 1
                    Case 1
                        txt1.Text = strelementname
                    Case 2
                        txt2.Text = strelementname
                    Case 3
                        txt3.Text = strelementname
                    Case 4
                        txt4.Text = strelementname
                    Case 5
                        txt5.Text = strelementname
                    Case 6
                        txt6.Text = strelementname
                End Select
            Next

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

    Private Function funcAddOrRemoveLampAtGivenPosition(ByVal intTurrPos As Integer, ByVal strElementName As String) As Boolean
        '=====================================================================
        ' Procedure Name        : funcAddOrRemoveLampAtGivenPosition
        ' Parameters Passed     : intTurrPos,strElementName
        ' Returns               : True or False
        ' Purpose               : To add or remove element name at given turret position
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 15.12.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try

            Select Case intTurrPos
                Case 1
                    txt1.Text = strElementName
                    'txt1.Select()
                    txt1.Refresh()
                Case 2
                    txt2.Text = strElementName
                    'txt2.Select()
                    'txt2.Refresh()
                Case 3
                    txt3.Text = strElementName
                    'txt3.Select()
                    'txt3.Refresh()
                Case 4
                    txt4.Text = strElementName
                    'txt4.Select()
                    'txt4.Refresh()
                Case 5
                    txt5.Text = strElementName
                    'txt5.Select()
                    'txt5.Refresh()
                Case 6
                    txt6.Text = strElementName
                    'txt6.Select()
                    'txt6.Refresh()
            End Select

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

    Private Function funcInitiliaze_Lamps() As Boolean
        '=====================================================================
        ' Procedure Name        : funcInitiliaze_Lamps
        ' Parameters Passed     : 
        ' Returns               : True or False
        ' Purpose               : To add or remove element name at given turret position
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 15.12.06
        ' Revisions             : 
        '=====================================================================
        '            void	Initiliaze_Lamps(HWND hwnd)
        '{
        'LAMP_PAR   tLamp;
        'int			i;
        'for(i=0;i<GetMaxLamp(); i++){ //6
        '  Get_Lamp_Parameters(&tLamp, i);
        '  SetDlgItemText(hwnd, IDC_LAMP+i,tLamp.elname);
        ' }
        '}
        Dim objLampPar As New AAS203Library.Instrument.ClsLampParameters
        Dim intCount As Integer
        Dim objWait As New CWaitCursor

        Try
            '---display inserted or removed lamps 
            For intCount = 1 To gobjClsAAS203.funcGetMaxLamp()
                gfuncGet_Lamp_Parameters(objLampPar, intCount - 1)
                ''for gettin a lamp parameter.
                funcAddOrRemoveLampAtGivenPosition(intCount, objLampPar.ElementName)
            Next

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

End Class
