Imports AAS203.Common
Imports AAS203Library.Method
Imports AAS203Library.Instrument

Public Class frmLampPlacements_202
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
    Friend WithEvents txt1 As System.Windows.Forms.TextBox
    Friend WithEvents txt2 As System.Windows.Forms.TextBox
    Friend WithEvents btnInsertLamp As NETXP.Controls.XPButton
    Friend WithEvents btnRemoveLamp As NETXP.Controls.XPButton
    Friend WithEvents btnHelp As NETXP.Controls.XPButton
    Friend WithEvents btnOk As NETXP.Controls.XPButton
    Friend WithEvents btnCancel As NETXP.Controls.XPButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmLampPlacements_202))
        Me.CustomPanelMain = New GradientPanel.CustomPanel
        Me.btnHelp = New NETXP.Controls.XPButton
        Me.btnOk = New NETXP.Controls.XPButton
        Me.btnCancel = New NETXP.Controls.XPButton
        Me.btnRemoveLamp = New NETXP.Controls.XPButton
        Me.btnInsertLamp = New NETXP.Controls.XPButton
        Me.txt2 = New System.Windows.Forms.TextBox
        Me.txt1 = New System.Windows.Forms.TextBox
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
        Me.CustomPanelMain.Controls.Add(Me.txt2)
        Me.CustomPanelMain.Controls.Add(Me.txt1)
        Me.CustomPanelMain.Controls.Add(Me.lbl2)
        Me.CustomPanelMain.Controls.Add(Me.lbl1)
        Me.CustomPanelMain.Controls.Add(Me.lblElementName)
        Me.CustomPanelMain.Controls.Add(Me.lblTurretNo)
        Me.CustomPanelMain.Controls.Add(Me.Label1)
        Me.CustomPanelMain.Controls.Add(Me.HeaderTop)
        Me.CustomPanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanelMain.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanelMain.Name = "CustomPanelMain"
        Me.CustomPanelMain.Size = New System.Drawing.Size(314, 187)
        Me.CustomPanelMain.TabIndex = 0
        '
        'btnHelp
        '
        Me.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHelp.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHelp.Image = CType(resources.GetObject("btnHelp.Image"), System.Drawing.Image)
        Me.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHelp.Location = New System.Drawing.Point(288, 182)
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
        Me.btnOk.Location = New System.Drawing.Point(213, 31)
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
        Me.btnCancel.Location = New System.Drawing.Point(213, 89)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 34)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "&Cancel"
        '
        'btnRemoveLamp
        '
        Me.btnRemoveLamp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemoveLamp.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveLamp.Image = CType(resources.GetObject("btnRemoveLamp.Image"), System.Drawing.Image)
        Me.btnRemoveLamp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRemoveLamp.Location = New System.Drawing.Point(156, 140)
        Me.btnRemoveLamp.Name = "btnRemoveLamp"
        Me.btnRemoveLamp.Size = New System.Drawing.Size(132, 38)
        Me.btnRemoveLamp.TabIndex = 10
        Me.btnRemoveLamp.Text = "&Remove Lamp"
        '
        'btnInsertLamp
        '
        Me.btnInsertLamp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInsertLamp.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInsertLamp.Image = CType(resources.GetObject("btnInsertLamp.Image"), System.Drawing.Image)
        Me.btnInsertLamp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnInsertLamp.Location = New System.Drawing.Point(20, 140)
        Me.btnInsertLamp.Name = "btnInsertLamp"
        Me.btnInsertLamp.Size = New System.Drawing.Size(124, 38)
        Me.btnInsertLamp.TabIndex = 9
        Me.btnInsertLamp.Text = "&Insert Lamp"
        '
        'txt2
        '
        Me.txt2.BackColor = System.Drawing.Color.White
        Me.txt2.Location = New System.Drawing.Point(96, 94)
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
        Me.txt1.Location = New System.Drawing.Point(96, 65)
        Me.txt1.Name = "txt1"
        Me.txt1.ReadOnly = True
        Me.txt1.Size = New System.Drawing.Size(89, 20)
        Me.txt1.TabIndex = 0
        Me.txt1.Tag = "1"
        Me.txt1.Text = ""
        Me.txt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbl2
        '
        Me.lbl2.Location = New System.Drawing.Point(35, 97)
        Me.lbl2.Name = "lbl2"
        Me.lbl2.Size = New System.Drawing.Size(36, 15)
        Me.lbl2.TabIndex = 5
        Me.lbl2.Text = "2"
        Me.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl1
        '
        Me.lbl1.Location = New System.Drawing.Point(35, 68)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(36, 15)
        Me.lbl1.TabIndex = 4
        Me.lbl1.Text = "1"
        Me.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblElementName
        '
        Me.lblElementName.Location = New System.Drawing.Point(95, 39)
        Me.lblElementName.Name = "lblElementName"
        Me.lblElementName.Size = New System.Drawing.Size(89, 16)
        Me.lblElementName.TabIndex = 3
        Me.lblElementName.Text = "Element Name"
        Me.lblElementName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTurretNo
        '
        Me.lblTurretNo.Location = New System.Drawing.Point(21, 41)
        Me.lblTurretNo.Name = "lblTurretNo"
        Me.lblTurretNo.Size = New System.Drawing.Size(64, 13)
        Me.lblTurretNo.TabIndex = 2
        Me.lblTurretNo.Text = "Turret No."
        Me.lblTurretNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Location = New System.Drawing.Point(13, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(189, 98)
        Me.Label1.TabIndex = 1
        '
        'HeaderTop
        '
        Me.HeaderTop.BackColor = System.Drawing.SystemColors.Control
        Me.HeaderTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.HeaderTop.Location = New System.Drawing.Point(0, 0)
        Me.HeaderTop.Name = "HeaderTop"
        Me.HeaderTop.Size = New System.Drawing.Size(314, 20)
        Me.HeaderTop.TabIndex = 0
        Me.HeaderTop.TitleFont = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderTop.TitleText = "Insert/Remove Lamp"
        '
        'frmLampPlacements_202
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(314, 187)
        Me.Controls.Add(Me.CustomPanelMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLampPlacements_202"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lamp Placements AA 202"
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

#End Region

#Region " Private Constants "

    Private Const ConstFormLoad = "AAS203-Method-InstrumentParameters-LampPlacements"
    Private Const ConstParentFormLoad = "AAS203-Method-InstrumentParameters"

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

    Private Sub frmLampPlacements_202_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmLampPlacements_202_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To Add event handlers and to initialize the form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            gobjMain.ShowProgressBar(ConstFormLoad)
            AddHandlers()
            funcInitialise()

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

    Private Sub frmLampPlacements_202_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        gobjMain.ShowRunTimeInfo(ConstParentFormLoad)
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
            AddHandler txt1.Enter, AddressOf GetTurretPosition
            AddHandler txt2.Enter, AddressOf GetTurretPosition

            'AddHandler txt3.Enter, AddressOf GetTurretPosition
            'AddHandler txt4.Enter, AddressOf GetTurretPosition
            'AddHandler txt5.Enter, AddressOf GetTurretPosition
            'AddHandler txt6.Enter, AddressOf GetTurretPosition

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
            If objfrmCookBook.ShowDialog() = DialogResult.OK Then
                mblnIsOperated = True
                Application.DoEvents()
                objwait1 = New CWaitCursor

                If objfrmCookBook.ElementID <> 0 Then
                    objDtElement = gobjClsAAS203.funcGetElement(objfrmCookBook.ElementID)
                    objDtElementWvs = gobjClsAAS203.funcGetElementWavelengths(objfrmCookBook.ElementID)

                    If Not IsNothing(objDtElement) And objDtElement.Rows.Count > 0 Then
                        mobjInstrumentParameters = New clsInstrumentParameters
                        mobjInstrumentParameters.ElementID = CInt(objDtElement.Rows(0).Item(ConstColumnElementID))
                        mobjInstrumentParameters.ElementName = objDtElement.Rows(0).Item(ConstColumnElementName)
                        mobjInstrumentParameters.LampCurrent = CDbl(objDtElement.Rows(0).Item(ConstColumnCurrent))
                        mobjInstrumentParameters.TurretNumber = CInt(TurretPosition)
                        If Not IsNothing(objDtElementWvs) And objDtElementWvs.Rows.Count > 0 Then
                            mobjInstrumentParameters.SlitWidth = CDbl(objDtElementWvs.Rows(0).Item("SLIT"))
                            mobjInstrumentParameters.Wavelength = objDtElementWvs
                        End If
                    End If

                    '---Getting Lamp No. ## for replacement .... Please Wait
                    Call gobjMessageAdapter.ShowStatusMessageBox("Getting Lamp No. " & TurretPosition & " for replacement...Please Wait", "Lamp Replacement", EnumMessageType.Information, 0)
                    Application.DoEvents()

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

                        If gfuncSet_Lamp_Parameters(objLampPar, TurretPosition) = True Then
                            If gobjCommProtocol.gFuncTurret_Home() Then
                                nosteps = gfuncTurretStepsForLampTop(TurretPosition)
                                If gobjCommProtocol.funcRotate_Steps_Tur_Clock(nosteps) Then
                                    gobjMessageAdapter.CloseStatusMessageBox()
                                    Application.DoEvents()
                                    '---Insert Cu Lamp in turret No. 3 and click OK button                       
                                    If gobjMessageAdapter.ShowMessage("Insert " & objLampPar.ElementName & " lamp in turret No. " & TurretPosition & " and click OK button", "Lamp Replacement", EnumMessageType.Information) Then
                                        Application.DoEvents()
                                        Dim objwait2 As New CWaitCursor
                                        '---Initializing .... Please Wait
                                        Application.DoEvents()
                                        gobjMessageAdapter.ShowStatusMessageBox("Initializing .... Please Wait", "Lamp Replacement", EnumMessageType.Information, 0)
                                        Application.DoEvents()
                                        gobjCommProtocol.gFuncTurret_Home()
                                        mintLatestTurretPosition = TurretPosition 'objClsInstrumentParameters.TurretNumber
                                        gfuncLamp_connected(TurretPosition)
                                        gobjMessageAdapter.CloseStatusMessageBox()
                                        Application.DoEvents()
                                        funcInitiliaze_Lamps()
                                        RaiseEvent LampReplaced()
                                    End If
                                End If
                            End If
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
            '---------------------------------------------------------
        End Try
    End Sub

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
            'If Not IsNothing(mobjInstrumentParameters) Then
            '    If mobjInstrumentParameters.TurretNumber = TurretPosition Then
            '        mobjInstrumentParameters = New clsInstrumentParameters
            '    End If
            'Else
            '    Exit Try
            'End If
            'gobjNewMethod.InstrumentCondition = mobjInstrumentParameters

            'For intCount = 0 To gobjMethodCollection.Count - 1
            '    If gobjMethodCollection.item(intCount).OperationMode = EnumOperationMode.MODE_AA Or _
            '    gobjMethodCollection.item(intCount).OperationMode = EnumOperationMode.MODE_AABGC Then
            '        gobjMethodCollection.item(intCount).InstrumentCondition = gobjNewMethod.InstrumentCondition.Clone
            '    End If
            'Next
            'Call funcSerialize(ConstMethodsFileName, gobjMethodCollection)

            strLampName = gobjInst.Lamp.LampParametersCollection.item(TurretPosition - 1).ElementName
            '---Getting Lamp No. ## for replacement .... Please Wait
            gobjMessageAdapter.ShowStatusMessageBox("Getting Lamp No. " & TurretPosition & " for replacement...Please Wait", "Lamp Replacement", EnumMessageType.Information, 0)
            Application.DoEvents()

            If gfuncInit_Lamp_Par(objLamp) = True Then
                If gfuncSet_Lamp_Parameters(objLamp, TurretPosition) = True Then
                    If gobjCommProtocol.gFuncTurret_Home() Then
                        nosteps = gfuncTurretStepsForLampTop(TurretPosition)
                        If gobjCommProtocol.funcRotate_Steps_Tur_Clock(nosteps) Then
                            '---Insert Cu Lamp in turret No. 3 and click OK button
                            gobjMessageAdapter.CloseStatusMessageBox()
                            Application.DoEvents()
                            gobjMessageAdapter.ShowMessage("Remove " & strLampName & " lamp in turret No. " & TurretPosition & " and click OK button", "Lamp Replacement", EnumMessageType.Information)
                            Application.DoEvents()
                            Dim objwait1 As New CWaitCursor
                            gfuncLamp_connected(TurretPosition)
                            Application.DoEvents()
                            gobjMessageAdapter.ShowStatusMessageBox("Initializing .... Please Wait", "Lamp Replacement", EnumMessageType.Information, 0)
                            Application.DoEvents()
                            gobjCommProtocol.gFuncTurret_Home()
                            gobjMessageAdapter.CloseStatusMessageBox()
                            funcInitiliaze_Lamps()
                            RaiseEvent LampRemoved()
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
        Dim objWait As New CWaitCursor

        Try
            Call Application.DoEvents()

            If mblnIsOperated = False Then
                Me.DialogResult = DialogResult.Cancel
            Else
                Me.DialogResult = DialogResult.OK
            End If

            Call Application.DoEvents()

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
            'If Not IsNothing(objInstrumentParameters) Then
            '    mobjInstrumentParameters = objInstrumentParameters.Clone()
            'End If

            'Dim intCtrlCounter As Integer
            'Dim ctrl As Control

            'If Not IsNothing(mobjInstrumentParameters) Then
            '    intTurret = mobjInstrumentParameters.TurretNumber
            '    strElementName = mobjInstrumentParameters.ElementName

            '    Select Case intTurret
            '        Case 1
            '            txt1.Text = strElementName
            '        Case 2
            '            txt2.Text = strElementName
            '        Case 3
            '            txt3.Text = strElementName
            '        Case 4
            '            txt4.Text = strElementName
            '        Case 5
            '            txt5.Text = strElementName
            '        Case 6
            '            txt6.Text = strElementName
            '    End Select
            'End If

            'Select Case intSelectedTurretPosition
            '    Case 1
            '        txt1.Select()
            '    Case 2
            '        txt2.Select()
            '    Case 3
            '        txt3.Select()
            '    Case 4
            '        txt4.Select()
            '    Case 5
            '        txt5.Select()
            '    Case 6
            '        txt6.Select()
            'End Select

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
        ' Purpose               : To initialize the form by bringing turret to hotme position
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim intCount As Integer
        Dim strelementname As String

        Try
            '---To get currect turret position first get turret home position
            HeaderTop.TitleText = "Insert-Remove Lamp for AA 202"
            
            For intCount = 0 To gobjInst.Lamp.LampParametersCollection.Count - 1
                strelementname = gobjInst.Lamp.LampParametersCollection.item(intCount).ElementName
                Select Case intCount + 1
                    Case 1
                        txt1.Text = strelementname
                    Case 2
                        txt2.Text = strelementname

                        'Case 3
                        '    txt3.Text = strelementname
                        'Case 4
                        '    txt4.Text = strelementname
                        'Case 5
                        '    txt5.Text = strelementname
                        'Case 6
                        '    txt6.Text = strelementname

                End Select
            Next

            Return gobjCommProtocol.gFuncTurret_Home()

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

                    'Case 3
                    '    txt3.Text = strElementName
                    '    'txt3.Select()
                    '    'txt3.Refresh()
                    'Case 4
                    '    txt4.Text = strElementName
                    '    'txt4.Select()
                    '    'txt4.Refresh()
                    'Case 5
                    '    txt5.Text = strElementName
                    '    'txt5.Select()
                    '    'txt5.Refresh()
                    'Case 6
                    '    txt6.Text = strElementName
                    '    'txt6.Select()
                    '    'txt6.Refresh()

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
            For intCount = 1 To gobjClsAAS203.funcGetMaxLamp()
                gfuncGet_Lamp_Parameters(objLampPar, intCount)
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
