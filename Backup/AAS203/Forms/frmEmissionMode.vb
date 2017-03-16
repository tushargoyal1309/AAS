Imports AAS203.Common
Imports AAS203Library.Method

Public Class frmEmissionMode
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal intMethodMode As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        OpenMethodMode = intMethodMode

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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnHelp As NETXP.Controls.XPButton
    Friend WithEvents btnOk As NETXP.Controls.XPButton
    Friend WithEvents btnCancel As NETXP.Controls.XPButton
    Friend WithEvents cmbElementName As System.Windows.Forms.ComboBox
    Friend WithEvents Office2003Header1 As CodeIntellects.Office2003Controls.Office2003Header
    Friend WithEvents nudSlitWidth As NumberValidator.NumberValidator
    Friend WithEvents nudWavelength As NumberValidator.NumberValidator
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmEmissionMode))
        Me.CustomPanel1 = New GradientPanel.CustomPanel
        Me.Office2003Header1 = New CodeIntellects.Office2003Controls.Office2003Header
        Me.btnHelp = New NETXP.Controls.XPButton
        Me.btnOk = New NETXP.Controls.XPButton
        Me.btnCancel = New NETXP.Controls.XPButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.nudWavelength = New NumberValidator.NumberValidator
        Me.nudSlitWidth = New NumberValidator.NumberValidator
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmbElementName = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.CustomPanel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CustomPanel1
        '
        Me.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanel1.Controls.Add(Me.Office2003Header1)
        Me.CustomPanel1.Controls.Add(Me.btnHelp)
        Me.CustomPanel1.Controls.Add(Me.btnOk)
        Me.CustomPanel1.Controls.Add(Me.btnCancel)
        Me.CustomPanel1.Controls.Add(Me.GroupBox2)
        Me.CustomPanel1.Controls.Add(Me.GroupBox1)
        Me.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanel1.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanel1.Name = "CustomPanel1"
        Me.CustomPanel1.Size = New System.Drawing.Size(394, 239)
        Me.CustomPanel1.TabIndex = 0
        '
        'Office2003Header1
        '
        Me.Office2003Header1.BackColor = System.Drawing.SystemColors.Control
        Me.Office2003Header1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Office2003Header1.Location = New System.Drawing.Point(0, 0)
        Me.Office2003Header1.Name = "Office2003Header1"
        Me.Office2003Header1.Size = New System.Drawing.Size(394, 22)
        Me.Office2003Header1.TabIndex = 14
        Me.Office2003Header1.TitleFont = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Office2003Header1.TitleText = "Quantitative Instrument Conditions - Emission Mode"
        '
        'btnHelp
        '
        Me.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHelp.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHelp.Image = CType(resources.GetObject("btnHelp.Image"), System.Drawing.Image)
        Me.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHelp.Location = New System.Drawing.Point(246, 184)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(86, 34)
        Me.btnHelp.TabIndex = 6
        Me.btnHelp.Text = "&Help"
        Me.btnHelp.Visible = False
        '
        'btnOk
        '
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Image = CType(resources.GetObject("btnOk.Image"), System.Drawing.Image)
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(46, 184)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(86, 34)
        Me.btnOk.TabIndex = 4
        Me.btnOk.Text = "&OK"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(146, 184)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 34)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "&Cancel"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.nudWavelength)
        Me.GroupBox2.Controls.Add(Me.nudSlitWidth)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(21, 106)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(352, 72)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Working Conditions"
        '
        'nudWavelength
        '
        Me.nudWavelength.DigitsAfterDecimalPoint = 0
        Me.nudWavelength.ErrorColor = System.Drawing.Color.Empty
        Me.nudWavelength.ErrorMessage = Nothing
        Me.nudWavelength.Location = New System.Drawing.Point(88, 16)
        Me.nudWavelength.MaximumRange = 0
        Me.nudWavelength.MinimumRange = 0
        Me.nudWavelength.Name = "nudWavelength"
        Me.nudWavelength.RangeValidation = False
        Me.nudWavelength.Size = New System.Drawing.Size(64, 21)
        Me.nudWavelength.TabIndex = 2
        Me.nudWavelength.Text = ""
        Me.nudWavelength.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly
        '
        'nudSlitWidth
        '
        Me.nudSlitWidth.DigitsAfterDecimalPoint = 0
        Me.nudSlitWidth.ErrorColor = System.Drawing.Color.Empty
        Me.nudSlitWidth.ErrorMessage = Nothing
        Me.nudSlitWidth.Location = New System.Drawing.Point(88, 40)
        Me.nudSlitWidth.MaximumRange = 0
        Me.nudSlitWidth.MinimumRange = 0
        Me.nudSlitWidth.Name = "nudSlitWidth"
        Me.nudSlitWidth.RangeValidation = False
        Me.nudSlitWidth.Size = New System.Drawing.Size(64, 21)
        Me.nudSlitWidth.TabIndex = 3
        Me.nudSlitWidth.Text = ""
        Me.nudSlitWidth.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(163, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(164, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Range 0 - 2.0 nm in steps of 0.1"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(163, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Range 185 - 950 nm"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Slit Width"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Wavelength"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbElementName)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(21, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(352, 72)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'cmbElementName
        '
        Me.cmbElementName.BackColor = System.Drawing.Color.White
        Me.cmbElementName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbElementName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbElementName.Location = New System.Drawing.Point(155, 43)
        Me.cmbElementName.Name = "cmbElementName"
        Me.cmbElementName.Size = New System.Drawing.Size(112, 24)
        Me.cmbElementName.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(43, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Element Name"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(326, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Emission Measurement Conditions"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmEmissionMode
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(394, 239)
        Me.Controls.Add(Me.CustomPanel1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEmissionMode"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Method"
        Me.CustomPanel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Class Member Variables "

    Private mobjdtEmissionMode As DataTable

    Private mintTurretNumber As Integer
    Private mblnIsValid As Boolean

    Private objfrmLampPlacements As frmLampPlacements
    Private mobjInstrumentParaCollection As New clsInstrumentParametersCollection
    Private mintOpenMethodMode As Integer = 0

    Private mintWavelengthID As Integer

    Private Const ConstIntMinWavelength = 190.0
    Private Const ConstIntMaxWavelength = 900.0
    Private Const ConstIntMinSlitWidthLimit = 0.1
    Private Const ConstIntMaxSlitWidthLimit = 2.0
#End Region

#Region " Public Constants, Structures, Events.. "

    Public Event MethodInstrumentSettingsChanged()

#End Region

#Region " Constants"

    Private Const ConstFormLoad = "-Method-InstrumentConditions"
    Private Const ConstParentFormLoad = "-Method"

#End Region

#Region " Private Properties "

    Private Property OpenMethodMode() As EnumMethodMode
        ''for getting or setting a method mode.
        Get
            Return mintOpenMethodMode
        End Get
        Set(ByVal Value As EnumMethodMode)
            mintOpenMethodMode = Value
        End Set
    End Property

#End Region

#Region " Form Load and Event Handling Functions "

    Private Sub frmEmissionMode_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmEmissionMode_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To initialize the form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S.
        ' Created               : 07.10.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this is called when a form is loaded.
        ''do some initialisation here.
        Dim objDtElements As New DataTable("Elements")
        Dim intObjCount As Integer
        Dim objRow As DataRow
        Dim objDvElementsList As DataView
        Dim objWait As New CWaitCursor

        '---- ORIGINAL CODE from INSTDLL::Inst.c

        'if (inst && (strcmpi(Inst->Lamp_par.Ems.elname,"") == 0 ||
        '				 strcmpi(Inst->Lamp_par.Ems.elname,inst->elName) != 0 ))
        '{
        '	if (strcmpi(ltrim(trim(inst->elName)),"")!=0)
        '	{
        '		strcpy(Inst->Lamp_par.Ems.elname,inst->elName);
        '		Inst->Lamp_par.Ems.wv = inst->Wv ;
        '		Inst->Lamp_par.Ems.slitwidth = inst->Slit ;
        '	}
        '}

        Try
            If Not gstructSettings.EnableServiceUtility Then
                ''check for service.
                gobjMain.ShowProgressBar(gstrTitleInstrumentType & ConstFormLoad)
            Else
                gobjService.ShowProgressBar(gstrTitleInstrumentType & ConstFormLoad)
            End If
            '---get emission data from datatbase
            mobjdtEmissionMode = gobjDataAccess.EmissionData(gstructSettings.AppMode)

            '---bind datatable to the combobox.
            If Not mobjdtEmissionMode Is Nothing Then
                RemoveHandler cmbElementName.SelectedIndexChanged, AddressOf cmbElementName_SelectedIndexChanged
                cmbElementName.DataSource = mobjdtEmissionMode
                cmbElementName.ValueMember = mobjdtEmissionMode.Columns(ConstColumnElementID).ColumnName
                cmbElementName.DisplayMember = mobjdtEmissionMode.Columns(ConstColumnElementName).ColumnName
                AddHandler cmbElementName.SelectedIndexChanged, AddressOf cmbElementName_SelectedIndexChanged
            End If

            cmbElementName.SelectedValue = gobjNewMethod.InstrumentCondition.ElementID
            gobjInst.Lamp.EMSCondition.ElementName = gobjNewMethod.InstrumentCondition.ElementName
            gobjInst.Lamp.EMSCondition.SlitWidth = gobjNewMethod.InstrumentCondition.SlitWidth
            gobjInst.Lamp.EMSCondition.Wavelength = gobjNewMethod.InstrumentCondition.EmmWavelength

            '---display data according to mode type selected
            If OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode Then
                cmbElementName_SelectedIndexChanged(sender, e)
            ElseIf OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode Then
                'cmbElementName.Text = gobjInst.Lamp.EMSCondition.ElementName
                nudWavelength.Text = gobjInst.Lamp.EMSCondition.Wavelength
                nudSlitWidth.Text = FormatNumber(gobjInst.Lamp.EMSCondition.SlitWidth, 1) 'FormatNumber(gobjInst.SlitPosition, 1)
            End If
            Call subSetTextValidation()
            ''for setting text validation.
            cmbElementName.Focus()
            '---add event handlers
            AddHandler nudSlitWidth.ValidationStatus, AddressOf nudSlitWidth_ValidationStatus
            AddHandler nudWavelength.ValidationStatus, AddressOf nudWavelength_ValidationStatus

            'added by deepak on 24.07.07
            'Dim strWvRange As String
            'strWvRange = "Range " & gstructSettings.WavelengthRange.WvLowerBound & " - " & gstructSettings.WavelengthRange.WvUpperBound & "nm"
            'Label5.Text = strWvRange

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

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        '=====================================================================
        ' Procedure Name        : btnOk_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To set the instrument information to the object
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S.
        ' Created               : 07.10.06
        ' Revisions             : 
        '=====================================================================
        Dim intCount As Integer
        Dim intElementID As Integer
        Dim objWait As New CWaitCursor


        '---- ORIGINAL CODE

        'If (inst) Then
        '{
        '	strcpy(inst->elName,Inst->Lamp_par.Ems.elname);
        '	inst->Inst_Mode=EMISSION; //, Inst->Lamp_par.lamp[LampNo].elaneme);
        '	inst->TurNo=0; //LampNo+1;
        '	inst->Cur = 0.0;
        '	inst->Wv = Inst->Lamp_par.Ems.wv;
        '	inst->Slit = Inst->Lamp_par.Ems.slitwidth;
        '	//inst->D2cur=
        '	//inst->Pmtv=
        '}

        'case IDOK:
        'case SKOK:
        '   GetDlgItemText(hwnd, IDC_WV,str, 10);
        '   tempk=atof(str);
        '   flag=TRUE;
        '   if (tempk<190.0 || tempk >900)
        '	    flag=FALSE;
        '   Else
        '   {
        '	    Inst->Lamp_par.Ems.wv= tempk;
        '	    GetDlgItemText(hwnd, IDC_SW,str, 10);
        '	    tempk=atof(str);
        '	    if (tempk<=0.0 || tempk >2.0)
        '		    flag=FALSE;
        '       Else
        '		    Inst->Lamp_par.Ems.slitwidth=tempk;
        '   }
        '   if (!flag)
        '       break;
        '   #if	!IN203DLL
        '	    Set_Ems_Instrument_Parameters(&(Inst->Lamp_par.Ems));
        '   #End If
        '	Save_Tuttet_Status();
        '	EndDialog(hwnd, 1);
        '   break;
        '*******************************************************
        Dim dblWavelength, dblSlitWidth As Double
        Dim lngElementID As Long
        Dim flag As Boolean

        Try
            '---validate emission setup
            Call Validate_EmnSetup()
            If nudWavelength.Text = "" Or nudSlitWidth.Text = "" Then
                ''check for null value.
                gobjMessageAdapter.ShowMessage(constFieldsRequired)
                Exit Sub    'Saurabh
                Application.DoEvents()
                ''allow application to perfrom its panding work.
            End If

            '---get wavelength and slit width
            dblWavelength = Val(nudWavelength.Text)
            dblSlitWidth = Val(nudSlitWidth.Text)

            flag = True

            gobjInst.Lamp.EMSCondition.ElementName = cmbElementName.Text

            '---validate wavelength and slit width
            If (dblWavelength < 190.0 Or dblWavelength > 900.0) Then
                flag = False
            Else
                gobjInst.Lamp.EMSCondition.Wavelength = dblWavelength
                If (dblSlitWidth <= 0.0 Or dblSlitWidth > 2.0) Then
                    flag = False
                Else
                    gobjInst.Lamp.EMSCondition.SlitWidth = dblSlitWidth
                End If
            End If

            '---set data to method and instrument object.
            If (flag) Then
                If Not IsNothing(gobjInst) Then
                    gobjInst.ElementName = gobjInst.Lamp.EMSCondition.ElementName
                    gobjInst.Mode = EnumCalibrationMode.EMISSION
                    gobjInst.TurretPosition = 0
                    gobjInst.Current = 0.0
                    gobjInst.WavelengthCur = gobjInst.Lamp.EMSCondition.Wavelength
                    gobjInst.SlitPosition = gobjInst.Lamp.EMSCondition.SlitWidth

                    Dim objEmsInstrumentConditions As AAS203Library.Method.clsInstrumentParameters
                    gobjNewMethod.InstrumentCondition = New AAS203Library.Method.clsInstrumentParameters
                    gobjNewMethod.InstrumentCondition.ElementID = cmbElementName.SelectedValue
                    gobjNewMethod.InstrumentCondition.Inst_Mode = EnumCalibrationMode.EMISSION
                    gobjNewMethod.InstrumentCondition.ElementName = gobjInst.Lamp.EMSCondition.ElementName
                    gobjNewMethod.InstrumentCondition.SlitWidth = dblSlitWidth
                    gobjNewMethod.InstrumentCondition.EmmWavelength = dblWavelength

                    If Not IsNothing(gobjNewMethod) Then
                        '---if new method then set the selected element id for Emission
                        '---update current and slit width and selected wavelength values of selected method id in 
                        '---mobjInstrumentParaCollection object
                        lngElementID = cmbElementName.SelectedValue
                        If OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode Then
                            gobjNewMethod.InstrumentCondition.ElementID = lngElementID
                            gobjNewMethod.DateOfModification = Date.FromOADate(0.0)
                            gobjNewMethod.DateOfLastUse = Date.FromOADate(0.0)
                        End If
                        '---update information to method collection
                        For intCount = 0 To gobjMethodCollection.Count - 1
                            If gobjMethodCollection.item(intCount).MethodID = gobjNewMethod.MethodID Then
                                gobjMethodCollection.item(intCount).InstrumentCondition = gobjNewMethod.InstrumentCondition.Clone()
                                gobjNewMethod.DateOfModification = DateTime.Now
                                gobjMethodCollection.item(intCount).DateOfModification = gobjNewMethod.DateOfModification 'gobjNewMethod.DateOfModification
                            End If
                        Next
                    End If

                    If (gobjchkActiveMethod.fillStdConcentration = True And gobjchkActiveMethod.CancelMethod = True And gobjchkActiveMethod.NewMethod = True) Then
                        gobjchkActiveMethod.NewMethod = False
                        gobjchkActiveMethod.CancelMethod = False
                        gobjchkActiveMethod.fillStdConcentration = False
                        gobjNewMethod.Status = True
                        gobjMethodCollection.Add(gobjNewMethod)
                    End If

                    '---save all methods
                    Call funcSaveAllMethods(gobjMethodCollection)

                    If Not gstructSettings.EnableServiceUtility Then
                        ''check for service.
                        gobjMain.MethodInstrumentSettingsChanged = True
                    End If

                End If
                '---save instrument setting information
                If gstructSettings.ExeToRun = EnumApplicationMode.AAS Then
                    funcSaveInstStatus()
                End If
            End If

            '---kept for service mode
            gblnIsInstrumentConditionsActive = False

            Me.DialogResult = DialogResult.OK
            Me.Close()
            Me.Dispose()

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

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        '=====================================================================
        ' Procedure Name        : btnCancel_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To close the form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S.
        ' Created               : 07.10.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is called when user click on cancel button 

        Try
            '---to close the form
            gobjchkActiveMethod.CancelMethod = True
            Me.Close()
            Me.Dispose()

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

    Private Sub cmbElementName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbElementName.SelectedIndexChanged
        '=====================================================================
        ' Procedure Name        : cmbElementName_SelectedIndexChanged
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To set the values of selected element. 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S.
        ' Created               : 07.10.06
        ' Revisions             : praveen
        '=====================================================================
        ''note
        ''this event is called when user change a element name
        Dim objWait As New CWaitCursor
        Dim lngElementID As Long
        Dim intObjCount As Long
        Dim intAtomicNumber As Integer

        Try
            '---validate emission setup
            Call Validate_EmnSetup()

            If cmbElementName.SelectedIndex > -1 Then
                lngElementID = cmbElementName.SelectedValue()

                '---get data of selected element
                For intObjCount = 0 To mobjdtEmissionMode.Rows.Count - 1
                    If mobjdtEmissionMode.Rows.Item(intObjCount).Item(ConstColumnElementID) = lngElementID Then
                        intAtomicNumber = mobjdtEmissionMode.Rows.Item(intObjCount).Item("ATNO")
                        nudWavelength.Text = mobjdtEmissionMode.Rows.Item(intObjCount).Item("WVEMS")
                        nudSlitWidth.Text = mobjdtEmissionMode.Rows.Item(intObjCount).Item("SLITEMS")
                        Exit For
                    End If
                Next
            End If


            '----ORIGINAL CODE

            'Validate_EmnSetup(hwnd);
            'case IDC_ELNAME:
            '   if (HIWORD(lParam)==CBN_SELCHANGE)
            '	{
            '	    i= (WORD) SendMessage(GetDlgItem(hwnd, wParam),
            '		    CB_GETCURSEL, 0, 0L);
            '		SendMessage(GetDlgItem(hwnd, wParam), CB_GETLBTEXT,i,(DWORD) (LPSTR) str);
            '		strcpy(Inst->Lamp_par.Ems.elname, str);
            '		Inst->Lamp_par.Ems.wv=0.0;
            '		Inst->Lamp_par.Ems.Atno=0;
            '		Inst->Lamp_par.Ems.slitwidth=0.0;
            '       #If !IN203DLL Then
            '		    SetEmissionElements(hwnd, & (Inst->Lamp_par.Ems),
            '		    IDC_ELNAME, IDC_WV, IDC_SW, FALSE);
            '       #Else
            '           If (SetEmsElements! = NULL) Then
            '			    (*SetEmsElements)(hwnd, & (Inst->Lamp_par.Ems),
            '				    IDC_ELNAME, IDC_WV, IDC_SW, FALSE);
            '       #End If
            '	}
            '	break;

            '---set selected element data to the object
            gobjInst.Lamp.EMSCondition.ElementName = Trim(cmbElementName.Text)
            gobjInst.Lamp.EMSCondition.Wavelength = Val(nudWavelength.Text)
            gobjInst.Lamp.EMSCondition.AtomicNumber = intAtomicNumber
            gobjInst.Lamp.EMSCondition.SlitWidth = Val(nudSlitWidth.Text)

            gobjfrmStatus.ElementName = Trim(cmbElementName.Text)   'Added by Saurabh
            gobjfrmStatus.lblTurretNo.Visible = False               'Added by Saurabh

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

#Region " Private functions "

    Private Function Validate_EmnSetup() As Boolean
        '=====================================================================
        ' Procedure Name        : Validate_EmnSetup
        ' Parameters Passed     : None
        ' Returns               : True or false
        ' Purpose               : 
        ' Description           : To validate emission setup data
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 22-Jan-2007 07:15 pm
        ' Revisions             : 1
        '=====================================================================


        '---- ORIGINAL CODE

        'BOOL	Validate_EmnSetup(HWND hwnd)
        '{
        '   double	tempk=0;
        '	int	i;
        '	BOOL	flag=TRUE;
        '	char	str[80]="";

        '	i= (WORD) SendMessage(GetDlgItem(hwnd, IDC_ELNAME), CB_GETCURSEL, 0, 0L);
        '	SendMessage(GetDlgItem(hwnd, IDC_ELNAME), CB_GETLBTEXT,i, (DWORD) (LPSTR) str);

        '	if (strcmpi(ltrim(trim(str)),"")==0)
        '		flag=FALSE;

        '   If (flag) Then
        '	{
        '	    GetDlgItemText(hwnd, IDC_WV,str, 10);
        '		tempk=atof(str);
        '		if (tempk<190.0 || tempk >900)
        '			flag=FALSE;
        '       If (flag) Then
        '		{
        '			GetDlgItemText(hwnd, IDC_SW,str, 10);
        '			tempk=atof(str);
        '			if (tempk<=0.0 || tempk >2.0)
        '				flag=FALSE;
        '		}
        '	}
        '	EnableWindow(GetDlgItem(hwnd, SKOK), FALSE);

        '   If (flag) Then
        '		EnableWindow(GetDlgItem(hwnd, SKOK), TRUE);

        '	return flag;
        '}

        Dim dblWavelength, dblSlitWidth As Double
        Dim strSelectedWavelength As String
        Dim flag As Boolean

        Try
            flag = True
            strSelectedWavelength = ""

            strSelectedWavelength = Trim(cmbElementName.Text)
            If strSelectedWavelength = "" Then
                flag = False
            End If

            '---validate wavelength and slit width
            If (flag) Then
                dblWavelength = Val(nudWavelength.Text)
                If (dblWavelength < 190.0 Or dblWavelength > 900) Then
                    flag = False
                End If
                If (flag) Then
                    dblSlitWidth = Val(nudSlitWidth.Text)
                    If (dblSlitWidth <= 0.0 Or dblSlitWidth > 2.0) Then
                        flag = False
                    End If
                End If
            End If

            'btnOk.Enabled = False

            If (flag) Then
                btnOk.Enabled = True
            End If

            Return flag

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

    Private Sub subSetTextValidation()
        '=====================================================================
        ' Procedure Name        : subSetTextValidation
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To validate text boxes
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is uaed to set a validation range for text box.
        Try
            '---set properties to validate number validator
            nudSlitWidth.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly
            nudSlitWidth.DigitsAfterDecimalPoint = 1
            nudSlitWidth.RangeValidation = True
            nudSlitWidth.MinimumRange = ConstIntMinSlitWidthLimit
            nudSlitWidth.MaximumRange = ConstIntMaxSlitWidthLimit
            nudSlitWidth.ErrorColor = Color.Gainsboro

            nudWavelength.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly
            nudWavelength.DigitsAfterDecimalPoint = 2
            nudWavelength.RangeValidation = True
            nudWavelength.MinimumRange = ConstIntMinWavelength
            nudWavelength.MaximumRange = ConstIntMaxWavelength
            nudWavelength.ErrorColor = Color.Gainsboro


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

    Private Sub nudSlitWidth_ValidationStatus(ByVal Status As NumberValidator.NumberValidator.Status, ByVal Msg As String)
        '=====================================================================
        ' Procedure Name        : nudSlitWidth_ValidationStatus
        ' Parameters Passed     : Status as NumberValidator.Status,Msg
        ' Returns               : None
        ' Purpose               :  Set the validation status
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 
        ' Revisions             : praveen
        '=====================================================================
        '---set ok button enable/disable on validation status
        Try
            If Status = NumberValidator.NumberValidator.Status.NotValidated Then
                nudSlitWidth.Focus()
                btnOk.Enabled = False
            Else
                btnOk.Enabled = True
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

    Private Sub nudWavelength_ValidationStatus(ByVal Status As NumberValidator.NumberValidator.Status, ByVal Msg As String)
        '=====================================================================
        ' Procedure Name        : nudWavelength_ValidationStatus
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               :  Set the validation status
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        '---set ok button enable/disable on validation status
        Try
            If Status = NumberValidator.NumberValidator.Status.NotValidated Then
                nudWavelength.Focus()
                btnOk.Enabled = False
            Else
                btnOk.Enabled = True
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

    Private Sub frmEmissionMode_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        '=====================================================================
        ' Procedure Name        : frmEmissionMode_Closing
        ' Parameters Passed     : Object,CancelEventArgs
        ' Returns               : None
        ' Purpose               :  Close the form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        '---to show status bar information
        Try
            If Not gstructSettings.EnableServiceUtility Then
                gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType & ConstParentFormLoad)
            Else
                gobjService.ShowRunTimeInfo(gstrTitleInstrumentType & ConstParentFormLoad)
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

End Class
