Imports AAS203.Common
Imports AAS203Library.Method

Public Class frmUVQuantitativeAnalysis
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
    Friend WithEvents lblUVQuantitativeAnalysis As System.Windows.Forms.Label
    Friend WithEvents gbWorkingConditions As System.Windows.Forms.GroupBox
    Friend WithEvents lblWavelength As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnHelp As NETXP.Controls.XPButton
    Friend WithEvents btnOk As NETXP.Controls.XPButton
    Friend WithEvents btnCancel As NETXP.Controls.XPButton
    Friend WithEvents btnD2Peak As NETXP.Controls.XPButton
    Friend WithEvents Office2003Header1 As CodeIntellects.Office2003Controls.Office2003Header
    Friend WithEvents txtWavelength As NumberValidator.NumberValidator
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmUVQuantitativeAnalysis))
        Me.CustomPanel1 = New GradientPanel.CustomPanel
        Me.Office2003Header1 = New CodeIntellects.Office2003Controls.Office2003Header
        Me.btnD2Peak = New NETXP.Controls.XPButton
        Me.btnHelp = New NETXP.Controls.XPButton
        Me.btnOk = New NETXP.Controls.XPButton
        Me.btnCancel = New NETXP.Controls.XPButton
        Me.gbWorkingConditions = New System.Windows.Forms.GroupBox
        Me.txtWavelength = New NumberValidator.NumberValidator
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblWavelength = New System.Windows.Forms.Label
        Me.lblUVQuantitativeAnalysis = New System.Windows.Forms.Label
        Me.CustomPanel1.SuspendLayout()
        Me.gbWorkingConditions.SuspendLayout()
        Me.SuspendLayout()
        '
        'CustomPanel1
        '
        Me.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanel1.Controls.Add(Me.Office2003Header1)
        Me.CustomPanel1.Controls.Add(Me.btnD2Peak)
        Me.CustomPanel1.Controls.Add(Me.btnHelp)
        Me.CustomPanel1.Controls.Add(Me.btnOk)
        Me.CustomPanel1.Controls.Add(Me.btnCancel)
        Me.CustomPanel1.Controls.Add(Me.gbWorkingConditions)
        Me.CustomPanel1.Controls.Add(Me.lblUVQuantitativeAnalysis)
        Me.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanel1.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanel1.Name = "CustomPanel1"
        Me.CustomPanel1.Size = New System.Drawing.Size(434, 199)
        Me.CustomPanel1.TabIndex = 0
        '
        'Office2003Header1
        '
        Me.Office2003Header1.BackColor = System.Drawing.SystemColors.Control
        Me.Office2003Header1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Office2003Header1.Location = New System.Drawing.Point(0, 0)
        Me.Office2003Header1.Name = "Office2003Header1"
        Me.Office2003Header1.Size = New System.Drawing.Size(434, 22)
        Me.Office2003Header1.TabIndex = 21
        Me.Office2003Header1.TitleFont = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Office2003Header1.TitleText = "Quantitative Instrument Conditions - Molecular ABS Mode"
        '
        'btnD2Peak
        '
        Me.btnD2Peak.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnD2Peak.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnD2Peak.Image = CType(resources.GetObject("btnD2Peak.Image"), System.Drawing.Image)
        Me.btnD2Peak.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnD2Peak.Location = New System.Drawing.Point(320, 137)
        Me.btnD2Peak.Name = "btnD2Peak"
        Me.btnD2Peak.Size = New System.Drawing.Size(86, 38)
        Me.btnD2Peak.TabIndex = 4
        Me.btnD2Peak.Text = "D2 Peaks"
        Me.btnD2Peak.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnHelp
        '
        Me.btnHelp.Enabled = False
        Me.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHelp.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHelp.Image = CType(resources.GetObject("btnHelp.Image"), System.Drawing.Image)
        Me.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHelp.Location = New System.Drawing.Point(224, 137)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(86, 38)
        Me.btnHelp.TabIndex = 3
        Me.btnHelp.Text = "Help"
        '
        'btnOk
        '
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Image = CType(resources.GetObject("btnOk.Image"), System.Drawing.Image)
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(30, 137)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(86, 38)
        Me.btnOk.TabIndex = 1
        Me.btnOk.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(128, 137)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 38)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        '
        'gbWorkingConditions
        '
        Me.gbWorkingConditions.Controls.Add(Me.txtWavelength)
        Me.gbWorkingConditions.Controls.Add(Me.Label1)
        Me.gbWorkingConditions.Controls.Add(Me.lblWavelength)
        Me.gbWorkingConditions.Location = New System.Drawing.Point(40, 77)
        Me.gbWorkingConditions.Name = "gbWorkingConditions"
        Me.gbWorkingConditions.Size = New System.Drawing.Size(352, 48)
        Me.gbWorkingConditions.TabIndex = 1
        Me.gbWorkingConditions.TabStop = False
        Me.gbWorkingConditions.Text = "Working Conditions"
        '
        'txtWavelength
        '
        Me.txtWavelength.DigitsAfterDecimalPoint = 0
        Me.txtWavelength.ErrorColor = System.Drawing.Color.Empty
        Me.txtWavelength.ErrorMessage = Nothing
        Me.txtWavelength.Location = New System.Drawing.Point(112, 18)
        Me.txtWavelength.MaximumRange = 400
        Me.txtWavelength.MinimumRange = 190
        Me.txtWavelength.Name = "txtWavelength"
        Me.txtWavelength.RangeValidation = False
        Me.txtWavelength.Size = New System.Drawing.Size(72, 21)
        Me.txtWavelength.TabIndex = 0
        Me.txtWavelength.Text = ""
        Me.txtWavelength.ValidationType = NumberValidator.NumberValidator.Validations.AlphaNumeric
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(192, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 24)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Range 190 - 400 nm"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWavelength
        '
        Me.lblWavelength.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWavelength.Location = New System.Drawing.Point(23, 16)
        Me.lblWavelength.Name = "lblWavelength"
        Me.lblWavelength.Size = New System.Drawing.Size(80, 24)
        Me.lblWavelength.TabIndex = 0
        Me.lblWavelength.Text = "Wavelength"
        Me.lblWavelength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblUVQuantitativeAnalysis
        '
        Me.lblUVQuantitativeAnalysis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUVQuantitativeAnalysis.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUVQuantitativeAnalysis.Location = New System.Drawing.Point(96, 40)
        Me.lblUVQuantitativeAnalysis.Name = "lblUVQuantitativeAnalysis"
        Me.lblUVQuantitativeAnalysis.Size = New System.Drawing.Size(248, 23)
        Me.lblUVQuantitativeAnalysis.TabIndex = 0
        Me.lblUVQuantitativeAnalysis.Text = "UV Quantitative Analysis"
        Me.lblUVQuantitativeAnalysis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmUVQuantitativeAnalysis
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(434, 199)
        Me.Controls.Add(Me.CustomPanel1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUVQuantitativeAnalysis"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Method"
        Me.CustomPanel1.ResumeLayout(False)
        Me.gbWorkingConditions.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Private Class Member Variables  "

    Private mintOpenMethodMode As Integer
    Private Wavelength As Double

#End Region

#Region " Constants"

    Private Const ConstFormLoad = "-Method-InstrumentConditions"
    Private Const ConstParentFormLoad = "-Method"

#End Region

#Region " Private Properties "

    Private Property OpenMethodMode() As EnumMethodMode
        Get
            Return mintOpenMethodMode
        End Get
        Set(ByVal Value As EnumMethodMode)
            mintOpenMethodMode = Value
        End Set
    End Property

#End Region

#Region " Form Load And Event Handling Functions "

    Private Sub frmUVQuantitativeAnalysis_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmUVQuantitativeAnalysis_Load
        ' Parameters Passed     : object, eventArgs
        ' Returns               : None
        ' Purpose               : To load and initialize the form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 22-Jan-2007 04:35 pm
        ' Revisions             : 1
        '=====================================================================


        '---- ORIGINAL CODE

        'hWv = GlobalAlloc(GHND, sizeof(double));
        'Chflag = cflag;
        'CheckInst();

        'wv = (double*) GlobalLock(hWv);
        '*wv = Inst->Wvcur;
        'if (inst && (inst->Wv>=200 && inst->Wv<=400))
        '	*wv = inst->Wv;
        'GlobalUnlock(hWv);

        Dim objDtWv As DataTable
        ''object for the data structure.
        Dim objWait As New CWaitCursor
        Try
            gobjMain.ShowProgressBar(gstrTitleInstrumentType & ConstFormLoad)
            ''show some info on progress bar.
            If OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode Then
                ''get a type of method 
                ''either it is new or edit mode
                Wavelength = 200.0
            Else
                Wavelength = gobjInst.WavelengthCur
            End If
            If Not (gobjNewMethod.InstrumentCondition Is Nothing) Then
                ''get a wavelength and show it on screen.
                objDtWv = gobjNewMethod.InstrumentCondition.Wavelength()
                If Not (objDtWv Is Nothing) Then
                    If objDtWv.Rows.Count > 0 Then
                        Wavelength = objDtWv.Rows(0).Item(2)
                    End If
                End If
            End If

            txtWavelength.Text = Wavelength

            If Not IsNothing(gobjInst) Then
                If (gobjInst.WavelengthCur >= 200 And gobjInst.WavelengthCur <= 400) Then
                    ''check a wavelength 
                    'Wavelength = gobjInst.WavelengthCur
                    txtWavelength.Text = Format(Wavelength, "#0.0")
                Else
                    ''set a format of wavwlength display
                    txtWavelength.Text = Format(Wavelength, "#0.0")
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
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click
        '=====================================================================
        ' Procedure Name        : btnOk_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               :to handle ok button event 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 22-Jan-2007 05:50 pm
        ' Revisions             : 1
        '=====================================================================
        ''note:
        ''this is called when user click on OK button.
        Dim objDtWv As DataTable
        Try
            'strcpy(inst->elName,"D2");
            'inst->Inst_Mode=D2E; 
            'inst->TurNo=0; 
            'inst->Cur = 0.0;
            'wv = (double*) GlobalLock(hWv);
            'inst->Wv = *wv;
            'inst->Slit = 2.0; 
            'inst->D2cur=300;
            'inst->Pmtv=Inst->d2Pmt;
            'GlobalUnlock(hWv);

            If Not IsNothing(gobjInst) Then
                ''set some default parameter
                gobjInst.ElementName = "D2"
                gobjInst.Mode = EnumCalibrationMode.D2E
                gobjInst.TurretPosition = 0
                gobjInst.Current = 0.0
                gobjInst.SlitPosition = 2.0
                gobjInst.D2Current = 300
                gobjInst.PmtVoltage = gobjInst.D2Pmt

                Wavelength = Val(txtWavelength.Text)
                ''get a wavwlength from wavelength text.
                If (Wavelength >= 190.0 And Wavelength <= 400.0) Then
                    ''check a wavelength range bet 190 to 400
                    gobjInst.WavelengthCur = Wavelength
                    ''stroe a wavelength to data structure
                Else
                    gobjMessageAdapter.ShowMessage(constUVRange)
                    ''show the validation mess
                    Application.DoEvents()
                    Exit Sub
                End If
                Application.DoEvents()

                'Dim objUVInstrumentConditions As AAS203Library.Method.clsInstrumentParameters
                'objUVInstrumentConditions = New AAS203Library.Method.clsInstrumentParameters

                'objUVInstrumentConditions.Inst_Mode = EnumCalibrationMode.MABS

                Dim intElementID As Integer
                Dim intCount As Integer
                If Not IsNothing(gobjNewMethod) Then
                    '//----- Added by Sachin Dokhale 23.03.07
                    '---if new method then set the selected element id for Emission
                    '---update current and slit width and selected wavelength values of selected method id in 
                    '---mobjInstrumentParaCollection object
                    intElementID = 200  'cmbElementName.SelectedValue
                    If OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode Then
                        'gobjNewMethod.SelectedElementID = intElementID
                        gobjNewMethod.InstrumentCondition = New clsInstrumentParameters
                        gobjNewMethod.InstrumentCondition.ElementID = intElementID
                        gobjNewMethod.DateOfModification = Date.FromOADate(0.0)
                        gobjNewMethod.DateOfLastUse = Date.FromOADate(0.0)
                        gobjNewMethod.InstrumentCondition.Inst_Mode = EnumCalibrationMode.D2E
                    End If

                    objDtWv = gobjClsAAS203.funcGetElementWavelengths(intElementID)

                    If Not (objDtWv Is Nothing) Then
                        If objDtWv.Rows.Count > 0 Then
                            objDtWv.Rows(0).Item(2) = gobjInst.WavelengthCur
                        Else
                            Dim Rw As DataRow
                            Rw = objDtWv.NewRow()
                            objDtWv.Rows(0).Item(2) = gobjInst.WavelengthCur
                            objDtWv.Rows.Add(Rw)
                        End If
                    End If

                    If Not (gobjNewMethod.InstrumentCondition Is Nothing) Then
                        gobjNewMethod.InstrumentCondition.SlitWidth = gobjInst.SlitPosition
                        gobjNewMethod.InstrumentCondition.ExitSlitWidth = gobjInst.SlitPositionExit
                        gobjNewMethod.InstrumentCondition.Wavelength = objDtWv
                    End If

                    For intCount = 0 To gobjMethodCollection.Count - 1
                        If gobjMethodCollection.item(intCount).MethodID = gobjNewMethod.MethodID Then
                            'gobjMethodCollection.item(intCount).InstrumentConditions = gobjNewMethod.InstrumentConditions.Clone
                            gobjMethodCollection.item(intCount).InstrumentCondition = gobjNewMethod.InstrumentCondition.Clone()
                            gobjNewMethod.DateOfModification = DateTime.Now
                            gobjMethodCollection.item(intCount).DateOfModification = gobjNewMethod.DateOfModification
                        End If
                    Next
                    'Added By Pankaj on 23 May 07 for adding method of inactive mode
                    'gobjchkActiveMethod.fillInstruments = True  '27.07.07
                    'If (gobjchkActiveMethod.fillInstruments = True And gobjchkActiveMethod.fillParameters = True And gobjchkActiveMethod.fillStdConcentration = True And gobjchkActiveMethod.CancelMethod = True And gobjchkActiveMethod.NewMethod = True) Then '27.07.07
                    If (gobjchkActiveMethod.fillStdConcentration = True And gobjchkActiveMethod.CancelMethod = True And gobjchkActiveMethod.NewMethod = True) Then
                        gobjchkActiveMethod.NewMethod = False
                        gobjchkActiveMethod.CancelMethod = False
                        'gobjchkActiveMethod.fillInstruments = False '27.07.07
                        'gobjchkActiveMethod.fillParameters = False  '27.07.07
                        gobjchkActiveMethod.fillStdConcentration = False
                        gobjNewMethod.Status = True
                        gobjMethodCollection.Add(gobjNewMethod)
                    End If
                    '//-----
                    'gobjNewMethod.InstrumentConditions.Add(objUVInstrumentConditions)
                    'gobjNewMethod.InstrumentCondition = objUVInstrumentConditions.Clone()

                    'Call funcSerialize(ConstMethodsFileName, gobjMethodCollection)
                    Call funcSaveAllMethods(gobjMethodCollection)
                    ''save the method to data structure

                    gobjMain.MethodInstrumentSettingsChanged = True
                End If
                If gstructSettings.ExeToRun = EnumApplicationMode.AAS Then
                    Call funcSaveInstStatus()
                End If
                ''save instrument current status to data structure
            End If

            Me.DialogResult = DialogResult.OK
            Me.Close()

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
            objDtWv = Nothing
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        '=====================================================================
        ' Procedure Name        : btnCancel_Click
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : to handle cancel event
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        ''note:
        ''this is called when user click on cancel button.
        Try
            gobjchkActiveMethod.CancelMethod = True
            Me.Close()

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

    Private Sub btnD2Peak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnD2Peak.Click
        '=====================================================================
        ' Procedure Name        : btnD2Peak_Click
        ' Parameters Passed     : object, EventArgs
        ' Returns               : None
        ' Purpose               : To search the D2 Peak 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 24-Jan-2007 04:15 pm
        ' Revisions             : 1
        '=====================================================================
        ''note:
        ''this is called when user clicked on D2 peak button.
        ''this will show a D2 peak dialog
        ''and start a D2 peak search routine.
        Dim objfrmD2peak As frmD2PeakSearch

        Try
            objfrmD2peak = New frmD2PeakSearch
            objfrmD2peak.ShowDialog()
            ''show dialog
            objfrmD2peak.Close()
            objfrmD2peak.Dispose()
            objfrmD2peak = Nothing

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

    Private Sub frmUVQuantitativeAnalysis_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        '=====================================================================
        ' Procedure Name        : frmUVQuantitativeAnalysis_Closing
        ' Parameters Passed     : object, EventArgs
        ' Returns               : None
        ' Purpose               : to close a dialog.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 24-Jan-2007 04:15 pm
        ' Revisions             : 1
        '=====================================================================
        gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType & ConstParentFormLoad)
    End Sub
End Class
