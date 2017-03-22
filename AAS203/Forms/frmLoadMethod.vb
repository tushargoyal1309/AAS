Imports AAS203.Common
Imports AAS203Library.Method

Public Class frmLoadMethod '' class behind the class.
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
    Friend WithEvents CustomPanelRightBottom As GradientPanel.CustomPanel
    Friend WithEvents lblMethodInformation As System.Windows.Forms.Label
    Friend WithEvents btnOk As NETXP.Controls.XPButton
    Friend WithEvents btnCancel As NETXP.Controls.XPButton
    Friend WithEvents btnDelete As NETXP.Controls.XPButton
    Friend WithEvents btnHelp As NETXP.Controls.XPButton
    Friend WithEvents CustomPanelMain As GradientPanel.CustomPanel
    Friend WithEvents CustomPanelBottom As GradientPanel.CustomPanel
    Friend WithEvents lblMethodComments As System.Windows.Forms.Label
    Friend WithEvents txtMethodComments As System.Windows.Forms.TextBox
    Friend WithEvents CustomPanelTop As GradientPanel.CustomPanel
    Friend WithEvents rbMethodName As System.Windows.Forms.RadioButton
    Friend WithEvents rbElementName As System.Windows.Forms.RadioButton
    Friend WithEvents Office2003Header1 As CodeIntellects.Office2003Controls.Office2003Header
    Friend WithEvents CustomPanelLeft As GradientPanel.CustomPanel
    Friend WithEvents lblOperationMode As System.Windows.Forms.Label
    Friend WithEvents txtOperationMode As System.Windows.Forms.TextBox
    Friend WithEvents CustomPanelBottomTop As GradientPanel.CustomPanel
    Friend WithEvents gbShowMethods As System.Windows.Forms.GroupBox
    Friend WithEvents lstElements As System.Windows.Forms.ListBox
    Friend WithEvents lstMethodName As System.Windows.Forms.ListBox
    Friend WithEvents lstMethodInformation As System.Windows.Forms.ListBox
    Friend WithEvents txtElement As System.Windows.Forms.TextBox
    Friend WithEvents lblElement As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkUVABS As System.Windows.Forms.CheckBox
    Friend WithEvents chkAABGCQuant As System.Windows.Forms.CheckBox
    Friend WithEvents chkEmission As System.Windows.Forms.CheckBox
    Friend WithEvents chkAAQuant As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmLoadMethod))
        Me.CustomPanelMain = New GradientPanel.CustomPanel
        Me.CustomPanelRightBottom = New GradientPanel.CustomPanel
        Me.lstMethodInformation = New System.Windows.Forms.ListBox
        Me.lblOperationMode = New System.Windows.Forms.Label
        Me.txtOperationMode = New System.Windows.Forms.TextBox
        Me.lblMethodComments = New System.Windows.Forms.Label
        Me.lblMethodInformation = New System.Windows.Forms.Label
        Me.txtMethodComments = New System.Windows.Forms.TextBox
        Me.CustomPanelLeft = New GradientPanel.CustomPanel
        Me.lstMethodName = New System.Windows.Forms.ListBox
        Me.lstElements = New System.Windows.Forms.ListBox
        Me.CustomPanelBottom = New GradientPanel.CustomPanel
        Me.CustomPanelBottomTop = New GradientPanel.CustomPanel
        Me.gbShowMethods = New System.Windows.Forms.GroupBox
        Me.chkUVABS = New System.Windows.Forms.CheckBox
        Me.chkAABGCQuant = New System.Windows.Forms.CheckBox
        Me.chkEmission = New System.Windows.Forms.CheckBox
        Me.chkAAQuant = New System.Windows.Forms.CheckBox
        Me.btnDelete = New NETXP.Controls.XPButton
        Me.btnHelp = New NETXP.Controls.XPButton
        Me.btnOk = New NETXP.Controls.XPButton
        Me.btnCancel = New NETXP.Controls.XPButton
        Me.CustomPanelTop = New GradientPanel.CustomPanel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbMethodName = New System.Windows.Forms.RadioButton
        Me.rbElementName = New System.Windows.Forms.RadioButton
        Me.lblElement = New System.Windows.Forms.Label
        Me.txtElement = New System.Windows.Forms.TextBox
        Me.Office2003Header1 = New CodeIntellects.Office2003Controls.Office2003Header
        Me.CustomPanelMain.SuspendLayout()
        Me.CustomPanelRightBottom.SuspendLayout()
        Me.CustomPanelLeft.SuspendLayout()
        Me.CustomPanelBottom.SuspendLayout()
        Me.CustomPanelBottomTop.SuspendLayout()
        Me.gbShowMethods.SuspendLayout()
        Me.CustomPanelTop.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CustomPanelMain
        '
        Me.CustomPanelMain.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanelMain.BackColor2 = System.Drawing.Color.AliceBlue
        Me.CustomPanelMain.Controls.Add(Me.CustomPanelRightBottom)
        Me.CustomPanelMain.Controls.Add(Me.CustomPanelLeft)
        Me.CustomPanelMain.Controls.Add(Me.CustomPanelBottom)
        Me.CustomPanelMain.Controls.Add(Me.CustomPanelTop)
        Me.CustomPanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanelMain.Location = New System.Drawing.Point(0, 22)
        Me.CustomPanelMain.Name = "CustomPanelMain"
        Me.CustomPanelMain.Size = New System.Drawing.Size(448, 403)
        Me.CustomPanelMain.TabIndex = 0
        '
        'CustomPanelRightBottom
        '
        Me.CustomPanelRightBottom.BackColor = System.Drawing.Color.Transparent
        Me.CustomPanelRightBottom.BackColor2 = System.Drawing.Color.Transparent
        Me.CustomPanelRightBottom.Controls.Add(Me.lstMethodInformation)
        Me.CustomPanelRightBottom.Controls.Add(Me.lblOperationMode)
        Me.CustomPanelRightBottom.Controls.Add(Me.txtOperationMode)
        Me.CustomPanelRightBottom.Controls.Add(Me.lblMethodComments)
        Me.CustomPanelRightBottom.Controls.Add(Me.lblMethodInformation)
        Me.CustomPanelRightBottom.Controls.Add(Me.txtMethodComments)
        Me.CustomPanelRightBottom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanelRightBottom.Location = New System.Drawing.Point(182, 56)
        Me.CustomPanelRightBottom.Name = "CustomPanelRightBottom"
        Me.CustomPanelRightBottom.Size = New System.Drawing.Size(266, 215)
        Me.CustomPanelRightBottom.TabIndex = 7
        '
        'lstMethodInformation
        '
        Me.lstMethodInformation.ItemHeight = 15
        Me.lstMethodInformation.Location = New System.Drawing.Point(16, 65)
        Me.lstMethodInformation.Name = "lstMethodInformation"
        Me.lstMethodInformation.Size = New System.Drawing.Size(232, 64)
        Me.lstMethodInformation.TabIndex = 7
        '
        'lblOperationMode
        '
        Me.lblOperationMode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOperationMode.Location = New System.Drawing.Point(16, 3)
        Me.lblOperationMode.Name = "lblOperationMode"
        Me.lblOperationMode.Size = New System.Drawing.Size(156, 16)
        Me.lblOperationMode.TabIndex = 5
        Me.lblOperationMode.Text = "Operation Mode"
        '
        'txtOperationMode
        '
        Me.txtOperationMode.BackColor = System.Drawing.Color.AliceBlue
        Me.txtOperationMode.Location = New System.Drawing.Point(16, 22)
        Me.txtOperationMode.Name = "txtOperationMode"
        Me.txtOperationMode.ReadOnly = True
        Me.txtOperationMode.Size = New System.Drawing.Size(234, 21)
        Me.txtOperationMode.TabIndex = 6
        Me.txtOperationMode.Text = ""
        '
        'lblMethodComments
        '
        Me.lblMethodComments.BackColor = System.Drawing.Color.Transparent
        Me.lblMethodComments.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMethodComments.Location = New System.Drawing.Point(16, 139)
        Me.lblMethodComments.Name = "lblMethodComments"
        Me.lblMethodComments.Size = New System.Drawing.Size(144, 16)
        Me.lblMethodComments.TabIndex = 3
        Me.lblMethodComments.Text = "Method Comments"
        '
        'lblMethodInformation
        '
        Me.lblMethodInformation.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMethodInformation.Location = New System.Drawing.Point(16, 47)
        Me.lblMethodInformation.Name = "lblMethodInformation"
        Me.lblMethodInformation.Size = New System.Drawing.Size(156, 16)
        Me.lblMethodInformation.TabIndex = 2
        Me.lblMethodInformation.Text = "Method Information"
        '
        'txtMethodComments
        '
        Me.txtMethodComments.BackColor = System.Drawing.Color.AliceBlue
        Me.txtMethodComments.Location = New System.Drawing.Point(16, 159)
        Me.txtMethodComments.Multiline = True
        Me.txtMethodComments.Name = "txtMethodComments"
        Me.txtMethodComments.ReadOnly = True
        Me.txtMethodComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMethodComments.Size = New System.Drawing.Size(234, 53)
        Me.txtMethodComments.TabIndex = 8
        Me.txtMethodComments.Text = ""
        '
        'CustomPanelLeft
        '
        Me.CustomPanelLeft.BackColor = System.Drawing.Color.Transparent
        Me.CustomPanelLeft.BackColor2 = System.Drawing.Color.Transparent
        Me.CustomPanelLeft.Controls.Add(Me.lstMethodName)
        Me.CustomPanelLeft.Controls.Add(Me.lstElements)
        Me.CustomPanelLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.CustomPanelLeft.Location = New System.Drawing.Point(0, 56)
        Me.CustomPanelLeft.Name = "CustomPanelLeft"
        Me.CustomPanelLeft.Size = New System.Drawing.Size(182, 215)
        Me.CustomPanelLeft.TabIndex = 10
        '
        'lstMethodName
        '
        Me.lstMethodName.Dock = System.Windows.Forms.DockStyle.Right
        Me.lstMethodName.ItemHeight = 15
        Me.lstMethodName.Location = New System.Drawing.Point(96, 0)
        Me.lstMethodName.Name = "lstMethodName"
        Me.lstMethodName.Size = New System.Drawing.Size(86, 214)
        Me.lstMethodName.TabIndex = 5
        '
        'lstElements
        '
        Me.lstElements.Dock = System.Windows.Forms.DockStyle.Left
        Me.lstElements.ItemHeight = 15
        Me.lstElements.Location = New System.Drawing.Point(0, 0)
        Me.lstElements.Name = "lstElements"
        Me.lstElements.Size = New System.Drawing.Size(86, 214)
        Me.lstElements.TabIndex = 4
        '
        'CustomPanelBottom
        '
        Me.CustomPanelBottom.BackColor = System.Drawing.Color.Transparent
        Me.CustomPanelBottom.BackColor2 = System.Drawing.Color.Transparent
        Me.CustomPanelBottom.Controls.Add(Me.CustomPanelBottomTop)
        Me.CustomPanelBottom.Controls.Add(Me.btnDelete)
        Me.CustomPanelBottom.Controls.Add(Me.btnHelp)
        Me.CustomPanelBottom.Controls.Add(Me.btnOk)
        Me.CustomPanelBottom.Controls.Add(Me.btnCancel)
        Me.CustomPanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CustomPanelBottom.Location = New System.Drawing.Point(0, 271)
        Me.CustomPanelBottom.Name = "CustomPanelBottom"
        Me.CustomPanelBottom.Size = New System.Drawing.Size(448, 132)
        Me.CustomPanelBottom.TabIndex = 8
        '
        'CustomPanelBottomTop
        '
        Me.CustomPanelBottomTop.BackColor = System.Drawing.Color.Transparent
        Me.CustomPanelBottomTop.BackColor2 = System.Drawing.Color.Transparent
        Me.CustomPanelBottomTop.Controls.Add(Me.gbShowMethods)
        Me.CustomPanelBottomTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.CustomPanelBottomTop.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanelBottomTop.Name = "CustomPanelBottomTop"
        Me.CustomPanelBottomTop.Size = New System.Drawing.Size(448, 78)
        Me.CustomPanelBottomTop.TabIndex = 9
        '
        'gbShowMethods
        '
        Me.gbShowMethods.Controls.Add(Me.chkUVABS)
        Me.gbShowMethods.Controls.Add(Me.chkAABGCQuant)
        Me.gbShowMethods.Controls.Add(Me.chkEmission)
        Me.gbShowMethods.Controls.Add(Me.chkAAQuant)
        Me.gbShowMethods.Location = New System.Drawing.Point(11, 6)
        Me.gbShowMethods.Name = "gbShowMethods"
        Me.gbShowMethods.Size = New System.Drawing.Size(424, 66)
        Me.gbShowMethods.TabIndex = 0
        Me.gbShowMethods.TabStop = False
        Me.gbShowMethods.Text = "Include Methods"
        '
        'chkUVABS
        '
        Me.chkUVABS.Location = New System.Drawing.Point(220, 38)
        Me.chkUVABS.Name = "chkUVABS"
        Me.chkUVABS.Size = New System.Drawing.Size(206, 24)
        Me.chkUVABS.TabIndex = 12
        Me.chkUVABS.Text = "&UVABS Quantitative Methods"
        '
        'chkAABGCQuant
        '
        Me.chkAABGCQuant.Location = New System.Drawing.Point(220, 14)
        Me.chkAABGCQuant.Name = "chkAABGCQuant"
        Me.chkAABGCQuant.Size = New System.Drawing.Size(202, 24)
        Me.chkAABGCQuant.TabIndex = 10
        Me.chkAABGCQuant.Text = "AA&BGC Quantitative Methods"
        '
        'chkEmission
        '
        Me.chkEmission.Location = New System.Drawing.Point(16, 38)
        Me.chkEmission.Name = "chkEmission"
        Me.chkEmission.Size = New System.Drawing.Size(220, 24)
        Me.chkEmission.TabIndex = 11
        Me.chkEmission.Text = "EMI&SSION Quantitative Methods"
        '
        'chkAAQuant
        '
        Me.chkAAQuant.Location = New System.Drawing.Point(16, 14)
        Me.chkAAQuant.Name = "chkAAQuant"
        Me.chkAAQuant.Size = New System.Drawing.Size(192, 24)
        Me.chkAAQuant.TabIndex = 9
        Me.chkAAQuant.Text = "&AA Quantitative Method"
        '
        'btnDelete
        '
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(215, 87)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(86, 34)
        Me.btnDelete.TabIndex = 15
        Me.btnDelete.Text = "&Delete"
        '
        'btnHelp
        '
        Me.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHelp.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHelp.Image = CType(resources.GetObject("btnHelp.Image"), System.Drawing.Image)
        Me.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHelp.Location = New System.Drawing.Point(348, 87)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(86, 34)
        Me.btnHelp.TabIndex = 16
        Me.btnHelp.Text = "&Help"
        Me.btnHelp.Visible = False
        '
        'btnOk
        '
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Image = CType(resources.GetObject("btnOk.Image"), System.Drawing.Image)
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(13, 87)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(86, 34)
        Me.btnOk.TabIndex = 13
        Me.btnOk.Text = "&OK"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(115, 87)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 34)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.Text = "&Cancel"
        '
        'CustomPanelTop
        '
        Me.CustomPanelTop.BackColor = System.Drawing.Color.Transparent
        Me.CustomPanelTop.BackColor2 = System.Drawing.Color.Transparent
        Me.CustomPanelTop.Controls.Add(Me.GroupBox1)
        Me.CustomPanelTop.Controls.Add(Me.lblElement)
        Me.CustomPanelTop.Controls.Add(Me.txtElement)
        Me.CustomPanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.CustomPanelTop.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanelTop.Name = "CustomPanelTop"
        Me.CustomPanelTop.Size = New System.Drawing.Size(448, 56)
        Me.CustomPanelTop.TabIndex = 9
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbMethodName)
        Me.GroupBox1.Controls.Add(Me.rbElementName)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(266, 52)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Load Element By"
        '
        'rbMethodName
        '
        Me.rbMethodName.Location = New System.Drawing.Point(25, 21)
        Me.rbMethodName.Name = "rbMethodName"
        Me.rbMethodName.Size = New System.Drawing.Size(110, 24)
        Me.rbMethodName.TabIndex = 2
        Me.rbMethodName.Text = "&Method Name"
        '
        'rbElementName
        '
        Me.rbElementName.Location = New System.Drawing.Point(143, 21)
        Me.rbElementName.Name = "rbElementName"
        Me.rbElementName.Size = New System.Drawing.Size(115, 24)
        Me.rbElementName.TabIndex = 1
        Me.rbElementName.Text = "&Element Name"
        '
        'lblElement
        '
        Me.lblElement.Location = New System.Drawing.Point(290, 22)
        Me.lblElement.Name = "lblElement"
        Me.lblElement.Size = New System.Drawing.Size(54, 14)
        Me.lblElement.TabIndex = 12
        Me.lblElement.Text = "E&lement"
        '
        'txtElement
        '
        Me.txtElement.BackColor = System.Drawing.Color.White
        Me.txtElement.Location = New System.Drawing.Point(346, 20)
        Me.txtElement.Name = "txtElement"
        Me.txtElement.ReadOnly = True
        Me.txtElement.Size = New System.Drawing.Size(71, 21)
        Me.txtElement.TabIndex = 3
        Me.txtElement.Text = ""
        '
        'Office2003Header1
        '
        Me.Office2003Header1.BackColor = System.Drawing.SystemColors.Control
        Me.Office2003Header1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Office2003Header1.Location = New System.Drawing.Point(0, 0)
        Me.Office2003Header1.Name = "Office2003Header1"
        Me.Office2003Header1.Size = New System.Drawing.Size(448, 22)
        Me.Office2003Header1.TabIndex = 11
        Me.Office2003Header1.TitleFont = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Office2003Header1.TitleText = "Load Method"
        '
        'frmLoadMethod
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(448, 425)
        Me.ControlBox = False
        Me.Controls.Add(Me.CustomPanelMain)
        Me.Controls.Add(Me.Office2003Header1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLoadMethod"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Method "
        Me.CustomPanelMain.ResumeLayout(False)
        Me.CustomPanelRightBottom.ResumeLayout(False)
        Me.CustomPanelLeft.ResumeLayout(False)
        Me.CustomPanelBottom.ResumeLayout(False)
        Me.CustomPanelBottomTop.ResumeLayout(False)
        Me.gbShowMethods.ResumeLayout(False)
        Me.CustomPanelTop.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Private Member Variables "

    Private mblnShowByMethod As Boolean = False
    Private mintSelectedMethodID As Integer = 0
    Public Event LoadMethod(ByVal objClsMethod As clsMethod)
    Public Event LampReplaced()
    Private mintSelectedElementID As Integer = 0
    'Dim objDtMethodNames As New DataTable

#End Region

#Region " Private Constants "

    Private Const ConstCreatedBy = "Created By  "
    Private Const ConstCreatedOn = "Created On  "
    Private Const ConstStatus = "Status      "
    Private Const ConstChangedOn = "Changed On  "
    Private Const ConstLastUsedOn = "Last Used On"
    Private Const ConstActive = "Active"
    Private Const ConstNotActive = "Inactive"
    Private Const ConstColumnMethodID = "MethodID"
    Private Const ConstColumnMethodName = "MethodName"
    Private Const ConstFormLoad = "-Method-Load"
    Private Const ConstParentFormLoad = "-Method"

    'Enum OperationMode
    '    AA_Quantitative_Mode = 1
    '    UV_ABS_Quantitative_Mode = 2
    '    AABGC_Quantitative_Mode = 3
    '    Emmission_Quantitative_Mode = 4
    'End Enum

#End Region

#Region " Private Properties "

    Private Property IsShowByMethod() As Boolean
        Get
            Return mblnShowByMethod
        End Get
        Set(ByVal Value As Boolean)
            mblnShowByMethod = Value


            Try
                If IsShowByMethod = True Then
                    Dim objDtMethodNames As New DataTable
                    Dim intCounter As Integer
                    Dim objRow As DataRow

                    lstMethodName.Visible = True
                    lstElements.Visible = False

                    'lstElements.Sorted = True
                    lstMethodName.Width = (2 * lstElements.Width) + 5
                    lblElement.Visible = True
                    txtElement.Visible = True
                    lstMethodName.BeginUpdate() 'Saurabh
                    objDtMethodNames.Columns.Add(ConstColumnMethodID)
                    objDtMethodNames.Columns.Add(ConstColumnMethodName)
                    For intCounter = gobjMethodCollection.Count - 1 To 0 Step -1
                        objRow = objDtMethodNames.NewRow
                        objRow.Item(ConstColumnMethodID) = gobjMethodCollection.item(intCounter).MethodID
                        objRow.Item(ConstColumnMethodName) = gobjMethodCollection.item(intCounter).MethodName
                        objDtMethodNames.Rows.Add(objRow)
                        If gobjMethodCollection.item(intCounter).OperationMode = 1 Then
                            chkAAQuant.Checked = True
                        End If
                        If gobjMethodCollection.item(intCounter).OperationMode = 2 Then
                            chkAABGCQuant.Checked = True
                        End If
                        If gobjMethodCollection.item(intCounter).OperationMode = 3 Then
                            chkEmission.Checked = True
                        End If
                        If gobjMethodCollection.item(intCounter).OperationMode = 4 Then
                            chkUVABS.Checked = True
                        End If
                    Next
                    lstMethodName.DataSource = objDtMethodNames
                    lstMethodName.DisplayMember = ConstColumnMethodName
                    lstMethodName.ValueMember = ConstColumnMethodID
                    lstMethodName.EndUpdate()   'Saurabh

                    SelectedMethodID = lstMethodName.SelectedValue
                Else
                    lstMethodName.Visible = True
                    lstElements.Visible = True
                    lstMethodName.Width = lstElements.Width
                    lblElement.Visible = False
                    txtElement.Visible = False

                    SelectedElementID = lstElements.SelectedValue
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
        End Set
    End Property

    Private Property SelectedMethodID() As Integer
        Get
            Return mintSelectedMethodID
        End Get
        Set(ByVal Value As Integer)
            mintSelectedMethodID = Value

            Dim intCount As Integer
            Dim objDtElement As New DataTable

            For intCount = 0 To gobjMethodCollection.Count - 1
                If gobjMethodCollection.item(intCount).MethodID = SelectedMethodID Then

                    funcShowMethodGeneralInfo(gobjMethodCollection.item(intCount))
                    objDtElement = gobjClsAAS203.funcGetElement(gobjMethodCollection.item(intCount).InstrumentCondition.ElementID)

                    If Not objDtElement Is Nothing Then
                        If objDtElement.Rows.Count > 0 Then
                            txtElement.Text = objDtElement.Rows(0).Item(ConstColumnElementName)
                        End If
                    End If
                    Exit For
                End If
            Next

        End Set
    End Property

    Private Property SelectedElementID() As Integer
        Get
            Return mintSelectedElementID
        End Get
        Set(ByVal Value As Integer)
            mintSelectedElementID = Value

            Dim objDtMethodNames As New DataTable
            Dim intCounter As Integer
            Dim objRow As DataRow
            Try
                objDtMethodNames.Columns.Add(ConstColumnMethodID)
                objDtMethodNames.Columns.Add(ConstColumnMethodName)
                For intCounter = gobjMethodCollection.Count - 1 To 0 Step -1
                    If gobjMethodCollection.item(intCounter).InstrumentCondition.ElementID = SelectedElementID Then
                        objRow = objDtMethodNames.NewRow
                        objRow.Item(ConstColumnMethodID) = gobjMethodCollection.item(intCounter).MethodID
                        objRow.Item(ConstColumnMethodName) = gobjMethodCollection.item(intCounter).MethodName
                        If gobjMethodCollection.item(intCounter).OperationMode = 1 Then
                            chkAAQuant.Checked = True
                        End If
                        If gobjMethodCollection.item(intCounter).OperationMode = 2 Then
                            chkAABGCQuant.Checked = True
                        End If
                        If gobjMethodCollection.item(intCounter).OperationMode = 3 Then
                            chkEmission.Checked = True
                        End If
                        If gobjMethodCollection.item(intCounter).OperationMode = 4 Then
                            chkUVABS.Checked = True
                        End If
                        objDtMethodNames.Rows.Add(objRow)
                    End If
                Next
                lstMethodName.DataSource = objDtMethodNames
                lstMethodName.DisplayMember = ConstColumnMethodName
                lstMethodName.ValueMember = ConstColumnMethodID
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
        End Set
    End Property

#End Region

#Region " Form Events "

    Private Sub frmLoadMethod_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmLoadMethod_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To initialize the form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 07.10.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is called when load method form is loaded.
        ''do some initialzation here.
        Dim objWait As New CWaitCursor
        Dim objDtMethodNames As New DataTable
        Dim intCounter As Integer
        Dim objRow As DataRow

        Try
            If (gstructUserDetails.UserID = 0) Then
                btnDelete.Visible = True
            Else
                btnDelete.Visible = False
            End If
            Call gobjMain.ShowProgressBar(gstrTitleInstrumentType & ConstFormLoad)
            ''show some instrument info on status
            ''and unchecked the following control.
            chkAABGCQuant.Checked = False
            chkAAQuant.Checked = False
            chkEmission.Checked = False
            chkUVABS.Checked = False
            'If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
            '    If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
            '        chkEmission.Visible = False
            '        chkUVABS.Visible = False
            '    End If
            'End If
            Call SubAddHandlers()
            ''for adding all the event to control.

            RemoveHandler lstMethodName.SelectedIndexChanged, AddressOf lstMethodName_SelectedIndexChanged

            If funcLoadMethods() = True Then
                ''It loads all methods from method file
                objDtMethodNames.Columns.Add(ConstColumnMethodID)
                ''for addind method ID
                objDtMethodNames.Columns.Add(ConstColumnMethodName)
                ''for adding Method name
                For intCounter = 0 To gobjMethodCollection.Count - 1
                    ''make a counter up to a collection.
                    objRow = objDtMethodNames.NewRow
                    objRow.Item(ConstColumnMethodID) = gobjMethodCollection.item(intCounter).MethodID
                    objRow.Item(ConstColumnMethodName) = gobjMethodCollection.item(intCounter).MethodName
                    objDtMethodNames.Rows.Add(objRow)
                Next
                lstMethodName.DataSource = objDtMethodNames
                lstMethodName.DisplayMember = ConstColumnMethodName
                lstMethodName.ValueMember = ConstColumnMethodID
            End If

            Call lstMethodName_SelectedIndexChanged(lstMethodName, EventArgs.Empty)
            ''handle a event of Method Name changed.
            AddHandler lstMethodName.SelectedIndexChanged, AddressOf lstMethodName_SelectedIndexChanged

            Call funcLoadElementsList()
            ''this is To load the elements list

            '----Added By Pankaj 11 May 07
            'rbMethodName.Checked = True
            'rbMethodName_CheckedChanged2(sender, e)

            '//----- Modified by Sachin Dokhale
            rbMethodName.Checked = False
            rbElementName.Checked = True
            IsShowByMethod = False
            '//-----
            'Saurabh 10.07.07 To bring status form in front
            gobjfrmStatus.Show()
            ''for showing status 
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

    Private Sub frmLoadMethod_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        '=====================================================================
        ' Procedure Name        : frmLoadMethod_Closing
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : to close the method form.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 30.10.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is called when user close the method form.
        gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType & ConstParentFormLoad)
    End Sub

    Private Sub btnDelete_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        '=====================================================================
        ' Procedure Name        : btnDelete_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To delete the selected method
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 30.10.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is called when user clicked on Delete button.
        Dim objWait As CWaitCursor
        Dim intCounter As Integer
        Dim objRow As DataRow
        Dim objDtMethodNames As New DataTable

        Try

            If gobjMessageAdapter.ShowMessage(constWantToDelete) = True Then
                Application.DoEvents()
                ''allow application to perfrom its panding work.

                objWait = New CWaitCursor
                ''ask user for deletion show a message.
                For intCounter = gobjMethodCollection.Count - 1 To 0 Step -1
                    If gobjMethodCollection.item(intCounter).MethodID = SelectedMethodID Then
                        ''serach in a data structure and delete as par methodID
                        gobjMethodCollection.RemoveAt(intCounter)
                        Exit For
                    End If
                Next
                'Added By Pankaj 27 May 07 
                If Not IsNothing(gobjNewMethod) Then
                    If (SelectedMethodID = gobjNewMethod.MethodID) Then
                        gobjNewMethod = Nothing
                    End If
                End If
                '------
                If funcSaveAllMethods(gobjMethodCollection) Then   'funcSerialize(ConstMethodsFileName, gobjMethodCollection) = True Then
                    ''To serialize the clsMethodCollection object
                    RemoveHandler lstMethodName.SelectedIndexChanged, AddressOf lstMethodName_SelectedIndexChanged
                    If funcLoadMethods() = True Then
                        ''load the remaining method
                        objDtMethodNames.Columns.Add(ConstColumnMethodID)
                        objDtMethodNames.Columns.Add(ConstColumnMethodName)
                        For intCounter = 0 To gobjMethodCollection.Count - 1
                            objRow = objDtMethodNames.NewRow
                            objRow.Item(ConstColumnMethodID) = gobjMethodCollection.item(intCounter).MethodID
                            objRow.Item(ConstColumnMethodName) = gobjMethodCollection.item(intCounter).MethodName
                            objDtMethodNames.Rows.Add(objRow)
                        Next
                        lstMethodName.DataSource = objDtMethodNames
                        lstMethodName.DisplayMember = ConstColumnMethodName
                        lstMethodName.ValueMember = ConstColumnMethodID
                    End If

                    lstMethodName_SelectedIndexChanged(sender, e)
                    AddHandler lstMethodName.SelectedIndexChanged, AddressOf lstMethodName_SelectedIndexChanged
                    funcLoadElementsList()
                    ''for loadind element list
                    IsShowByMethod = IsShowByMethod
                    gobjMessageAdapter.ShowMessage(constDeleteConfirmation)
                    Application.DoEvents()
                    ''allow application to perfrom it panding task.
                    If gobjMethodCollection.Count = 0 Then
                        ''if ther is no another method then
                        txtElement.Text = ""
                        txtOperationMode.Text = ""
                        lstMethodInformation.Items.Clear()
                        txtMethodComments.Text = ""
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

#End Region

#Region " Private Functions "

    Private Sub SubAddHandlers()
        '=====================================================================
        ' Procedure Name        : SubAddHandlers
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To add handlers
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 07.10.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is used for adding a event to a control.
        ''this is called during the loading of a form.
        Try


            AddHandler btnCancel.Click, AddressOf btnCancel_Click
            ''for eg if we click on cancel button then btnCancel_Click event is called.
            AddHandler rbMethodName.CheckedChanged, AddressOf rbMethodName_CheckedChanged
            AddHandler btnOk.Click, AddressOf btnOk_Click
            AddHandler chkAAQuant.CheckedChanged, AddressOf chkAAQuant_CheckedChanged
            AddHandler chkAABGCQuant.CheckedChanged, AddressOf OperationMode_CheckedChanged
            AddHandler chkEmission.CheckedChanged, AddressOf OperationMode_CheckedChanged
            AddHandler chkUVABS.CheckedChanged, AddressOf OperationMode_CheckedChanged
            'AddHandler btnDelete.Click, AddressOf btnDelete_Click
            'RemoveHandler rbMethodName.CheckedChanged, AddressOf rbMethodName_CheckedChanged
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

    Private Sub rbMethodName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        ''not in used 
    End Sub

    Private Sub rbMethodName_CheckedChanged2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : rbMethodName_CheckedChanged
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To set the property IsShowByMethod
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 07.10.06
        ' Revisions             : 'Added By Pankaj 11 May 07 
        '=====================================================================
        ''note:
        ''we can display a method by two type
        ''by methodID or by element name
        ''by this function we can arrenge the method by methodname.
        Try
            RemoveHandler chkAAQuant.CheckedChanged, AddressOf chkAAQuant_CheckedChanged
            RemoveHandler chkAABGCQuant.CheckedChanged, AddressOf OperationMode_CheckedChanged
            RemoveHandler chkEmission.CheckedChanged, AddressOf OperationMode_CheckedChanged
            RemoveHandler chkUVABS.CheckedChanged, AddressOf OperationMode_CheckedChanged
            chkAAQuant.Checked = False
            chkUVABS.Checked = False
            chkAABGCQuant.Checked = False
            chkEmission.Checked = False

            If rbMethodName.Checked = True Then
                If lstMethodName.Items.Count = 0 Then
                    ''check for a item in a list.
                    btnOk.Enabled = False
                    btnDelete.Enabled = False
                Else
                    btnOk.Enabled = True
                    btnDelete.Enabled = True
                End If
                IsShowByMethod = True

            Else
                IsShowByMethod = False
            End If
            AddHandler chkAAQuant.CheckedChanged, AddressOf chkAAQuant_CheckedChanged
            AddHandler chkAABGCQuant.CheckedChanged, AddressOf OperationMode_CheckedChanged
            AddHandler chkEmission.CheckedChanged, AddressOf OperationMode_CheckedChanged
            AddHandler chkUVABS.CheckedChanged, AddressOf OperationMode_CheckedChanged
            ''adding a event handle.
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

    Private Sub lstMethodName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : lstMethodName_SelectedIndexChanged
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To display method general information of selected element
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 08.10.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this is called when user change the method id
        ''To display method general information of selected element
        Dim intCounter As Integer
        Try
            If lstMethodName.Items.Count = 0 Then
                ''check for item in a list
                btnOk.Enabled = False
                btnDelete.Enabled = False
            Else
                btnOk.Enabled = True
                btnDelete.Enabled = True
            End If
            SelectedMethodID = lstMethodName.SelectedValue
            ''get a selected method ID
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

    Private Function funcShowMethodGeneralInfo(ByVal objMethod As clsMethod) As Boolean
        '=====================================================================
        ' Procedure Name        : funcShowMethodGeneralInfo
        ' Parameters Passed     : None
        ' Returns               : True or False
        ' Purpose               : To show method information 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this is used to show method info as par method id
        Dim objRow As DataRow
        Dim strStatus As String = ""

        Try
            txtMethodComments.Text = objMethod.Comments
            ''get a comment on a comment text box.
            objRow = gobjClsAAS203.funcGetMethodType(objMethod.OperationMode)
            ''for getting method type
            If Not objRow Is Nothing Then
                If objMethod.OperationMode = 4 Then
                    ''check for operation mode 
                    txtElement.Text = "D2"
                ElseIf objMethod.OperationMode = 3 Then
                    'txtElement.Text = objMethod.InstrumentConditions.item(0).ElementName
                    txtElement.Text = objMethod.InstrumentCondition.ElementName
                End If
                txtOperationMode.Text = objRow.Item(ConstColumnMethodType)
                ''got a method type in a operation mode text.
            End If

            If objMethod.Status = True Then
                strStatus = ConstActive
            Else
                strStatus = ConstNotActive
            End If
            Dim strDateOfModification, strDateOfLastUse As String
            If Not objMethod.DateOfModification = Date.FromOADate(0.0) Then
                strDateOfModification = Format(objMethod.DateOfModification, "dd-MMM-yyyy hh:mm tt")
                ''get a date of modification for method.
            End If
            If Not objMethod.DateOfLastUse = Date.FromOADate(0.0) Then
                strDateOfLastUse = Format(objMethod.DateOfLastUse, "dd-MMM-yyyy hh:mm tt")
                ''get last used date.
            End If

            lstMethodInformation.Items.Clear()
            ''first clear the list
            lstMethodInformation.Items.Add(ConstCreatedBy & vbTab & objMethod.UserName)
            ''add user name...
            lstMethodInformation.Items.Add(ConstCreatedOn & vbTab & Format(objMethod.DateOfCreation, "dd-MMM-yyyy hh:mm tt"))
            ''add date 
            'lstMethodInformation.Items.Add(ConstStatus & Space(19) & strStatus)
            lstMethodInformation.Items.Add(ConstStatus & vbTab & vbTab & strStatus)
            ''get a status.
            lstMethodInformation.Items.Add(ConstChangedOn & vbTab & strDateOfModification)
            lstMethodInformation.Items.Add(ConstLastUsedOn & vbTab & strDateOfLastUse)
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

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnOk_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the selected method
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 08.10.06
        ' Revisions             : By Deepak on 14.01.07
        '=====================================================================
        ''note:
        ''this is called when user clicked on OK button
        ''this will load a current selected methos to software''
        ''and get software ready for analysis
        Dim objWait As New CWaitCursor
        Dim intCounter As Integer

        Try
            '-------------Added By Pankaj 27 May  07
            gobjchkActiveMethod.NewMethod = False
            gobjchkActiveMethod.CancelMethod = False
            'gobjchkActiveMethod.fillInstruments = False  '27.07.07
            'gobjchkActiveMethod.fillParameters = False     '27.07.07
            gobjchkActiveMethod.fillStdConcentration = False
            '-----------
            If Me.DialogResult = DialogResult.OK Then
                Exit Sub
            End If
            For intCounter = 0 To gobjMethodCollection.Count - 1
                ''make a counter up to a collection.
                If gobjMethodCollection.item(intCounter).MethodID = SelectedMethodID Then
                    ''check for a selected MethodID
                    gobjNewMethod = gobjMethodCollection.item(intCounter).Clone()

                    '---Changed and Added by Mangesh On 13-Feb-2007
                    Dim intCount As Integer
                    If gobjNewMethod.OperationMode = EnumOperationMode.MODE_AA _
                      Or gobjNewMethod.OperationMode = EnumOperationMode.MODE_AABGC Then
                        gobjNewMethod.InstrumentCondition.IsOptimize = False

                        gobjInst.Lamp.LampParametersCollection.item(gobjNewMethod.InstrumentCondition.TurretNumber - 1).Current = gobjNewMethod.InstrumentCondition.LampCurrent
                        gobjInst.Lamp.LampParametersCollection.item(gobjNewMethod.InstrumentCondition.TurretNumber - 1).SlitWidth = gobjNewMethod.InstrumentCondition.SlitWidth

                        ''check for a operation mode.
                        '---added by deepak on 03.09.07
                        Dim intCount2 As Integer
                        For intCount2 = 0 To gobjInst.Lamp.LampParametersCollection.Count - 1
                            If (intCount2 + 1) = gobjInst.Lamp_Position Then
                                gobjfrmStatus.lblElementName.Text = gobjInst.Lamp.LampParametersCollection.item(intCount2).ElementName
                                ''show a element name in a status form.
                                Exit For
                            End If
                        Next
                        '------------
                    End If

                    If gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
                        gobjfrmStatus.lblElementName.Text = gobjNewMethod.InstrumentCondition.ElementName
                        gobjNewMethod.InstrumentCondition.IsOptimize = False
                        ''show a element name in a status form.
                    End If

                    If gobjNewMethod.OperationMode = EnumOperationMode.MODE_AA Or _
                    gobjNewMethod.OperationMode = EnumOperationMode.MODE_AABGC Then     'Saurabh 28 May 2007----------------
                        Dim intMethodTurrNo, intCount2 As Integer
                        Dim intLamp As Integer
                        If Not gobjNewMethod.InstrumentCondition Is Nothing Then
                            If gobjNewMethod.InstrumentCondition.ElementID <> 0 And gobjNewMethod.InstrumentCondition.TurretNumber <> 0 Then
                                ''check for elementID a turrert num validation
                                intMethodTurrNo = gobjNewMethod.InstrumentCondition.TurretNumber()
                                ''get a turrert no.
                                'intLamp = gobjNewMethod.InstrumentCondition.ElementName
                                intLamp = CInt(gobjClsAAS203.funcGetElement_AtomicNo(gobjNewMethod.InstrumentCondition.ElementID).Rows(0).Item("ATNO"))
                                ''get a lamp.
                                'dr(0).GetType.ToString 
                                If (intMethodTurrNo > 0 And intMethodTurrNo < 7) Then
                                    ''check for validate turrert num.
                                    If gobjInst.Lamp.LampParametersCollection.item(intMethodTurrNo - 1).AtomicNumber = intLamp Then
                                        '---allow loading method
                                    Else
                                        gobjNewMethod.InstrumentCondition.ElementName = CStr(gobjClsAAS203.funcGetElement(gobjNewMethod.InstrumentCondition.ElementID).Rows(0).Item(1))

                                        Call funCheckMethod() 'added By PAnkaj 24 MAy 07 
                                        ''for checking a method.
                                    End If
                                End If
                            End If
                        End If
                        'Saurabh 28 May 2007----------------------------------

                        '''below we are showing a status as per proper cond.

                        If gobjfrmStatus.lblTurretNo.Visible = False Then
                            gobjfrmStatus.lblTurretNo.Visible = True
                        End If
                        If gobjfrmStatus.lblElementName.Visible = False Then
                            gobjfrmStatus.lblElementName.Visible = True
                        End If
                        'gobjfrmwStatus.lblElementName.Text = CStr(gobjClsAAS203.funcGetElement(gobjNewMethod.InstrumentCondition.ElementID).Rows(0).Item(1))
                    ElseIf (gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS) Then
                        If gobjfrmStatus.lblTurretNo.Visible = True Then
                            gobjfrmStatus.lblTurretNo.Visible = False
                        End If
                        If gobjfrmStatus.lblElementName.Visible = True Then
                            gobjfrmStatus.lblElementName.Visible = False
                        End If
                    Else
                        If gobjfrmStatus.lblTurretNo.Visible = True Then
                            gobjfrmStatus.lblTurretNo.Visible = False
                        End If
                        If gobjfrmStatus.lblElementName.Visible = False Then
                            gobjfrmStatus.lblElementName.Visible = True
                        End If
                        If Not gobjNewMethod.InstrumentCondition Is Nothing Then
                            If gobjNewMethod.InstrumentCondition.ElementID <> 0 Then
                                gobjNewMethod.InstrumentCondition.ElementName = CStr(gobjClsAAS203.funcGetElement(gobjNewMethod.InstrumentCondition.ElementID).Rows(0).Item(1))
                            End If
                        End If
                        'gobjfrmStatus.lblElementName.Text = CStr(gobjClsAAS203.funcGetElement(gobjNewMethod.InstrumentCondition.ElementID).Rows(0).Item(1))
                    End If
                    'Saurabh 28 May 2007---------------------------------------

                    Exit For
                End If
            Next

            RaiseEvent LoadMethod(gobjNewMethod)
            ''event for loading a method.
            gIntMethodID = gobjNewMethod.MethodID
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                ''for 201 instrument.
                gobjfrmStatus.ElementName = CStr(gobjClsAAS203.funcGetElement(gobjNewMethod.InstrumentCondition.ElementID).Rows(0).Item("NAME"))
                gobjfrmStatus.TurretNumber = gobjNewMethod.InstrumentCondition.TurretNumber
                gobjInst.Lamp_Position = gobjNewMethod.InstrumentCondition.TurretNumber '---11.09.09
            End If
            'gobjfrmStatus.ElementName = gobjNewMethod.InstrumentCondition.ElementName
            'gobjfrmStatus.TurretNumber = gobjNewMethod.InstrumentCondition.TurretNumber

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

    Private Function funCheckMethod()
        '=====================================================================
        ' Procedure Name        : funCheckMethod
        ' Parameters Passed     : 
        ' Returns               : None
        ' Purpose               : To check method
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Pankaj Bamb
        ' Created               : 25.05.07
        ' Revisions             : 
        '=====================================================================
        '--- display message "method lamp position and turret position mismatch"
        '---check for strLamp presense in gobjinst
        '--- if present then display instrument conditions form opened in edit mode
        '---on ok loaded method turret position will change.
        '---if strLamp not present in gobjinst then
        '---display message "lamp is not present in the turret do u want to insert lamp?"
        '---if no then display instrument conditions form opened in edit mode
        '---if yes then insert selected method element in turret at position ------??
        Dim blLamp As Boolean = False
        Dim intLamp As Integer
        Dim intMethodTurrNo As Integer
        Try
            intMethodTurrNo = gobjNewMethod.InstrumentCondition.TurretNumber()
            ''get a turrert no
            intLamp = CInt(gobjClsAAS203.funcGetElement_AtomicNo(gobjNewMethod.InstrumentCondition.ElementID).Rows(0).Item("ATNO"))
            ''get a lamp
            For intMethodTurrNo = 1 To 6
                ''loop a counter for turrert
                If (gobjInst.Lamp.LampParametersCollection.item(intMethodTurrNo - 1).AtomicNumber = intLamp) Then
                    intLamp = gobjInst.Lamp.LampParametersCollection.item(intMethodTurrNo - 1).AtomicNumber
                    blLamp = True
                    Exit For
                End If
            Next
            gobjMessageAdapter.ShowMessage(constLampPositionMismatch)
            ''show a mess of position mismatch
            Dim objfrmInstPara As New frmInstrumentParameters(modGlobalConstants.EnumMethodMode.NewMode)
            ''creat a object for instrument parameter form.
            Dim intElementID = gobjNewMethod.InstrumentCondition.ElementID
            If (blLamp = True) Then
                ''if lamp present then.
                gobjNewMethod.InstrumentCondition.ElementID = 0
                'Lamp present
                'gobjNewMethod.InstrumentCondition.ElementID = CInt(gobjClsAAS203.funcGetElementID (intLamp)
                'gobjNewMethod.InstrumentCondition.TurretNumber = intMethodTurrNo

                objfrmInstPara.ShowDialog()
                ''show a instrument parameter dialog.
            Else
                'Lamp not present
                intLamp = gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).AtomicNumber
                If (gobjMessageAdapter.ShowMessage(constLampNotPresent) = True) Then
                    objfrmInstPara = New frmInstrumentParameters(modGlobalConstants.EnumMethodMode.NewMode)
                    'gobjNewMethod.InstrumentCondition.ElementID = gobjClsAAS203.funcGetElementID(intLamp)
                    'gobjNewMethod.InstrumentCondition.TurretNumber = gobjInst.Lamp_Position
                    gobjInst.Lamp.LampParametersCollection.item(gobjNewMethod.InstrumentCondition.TurretNumber - 1).AtomicNumber = CInt(gobjClsAAS203.funcGetElement_AtomicNo(gobjNewMethod.InstrumentCondition.ElementID).Rows(0).Item("ATNO"))
                    gobjInst.Lamp.LampParametersCollection.item(gobjNewMethod.InstrumentCondition.TurretNumber - 1).ElementName = gobjNewMethod.InstrumentCondition.ElementName
                    gobjInst.Lamp.LampParametersCollection.item(gobjNewMethod.InstrumentCondition.TurretNumber - 1).Current = gobjNewMethod.InstrumentCondition.LampCurrent
                    gobjInst.Lamp.LampParametersCollection.item(gobjNewMethod.InstrumentCondition.TurretNumber - 1).SlitWidth = gobjNewMethod.InstrumentCondition.SlitWidth
                    'gobjInst.Lamp.LampParametersCollection.item(gobjNewMethod.InstrumentCondition.TurretNumber - 1).Wavelength = gobjNewMethod.InstrumentCondition.Wavelength.
                    Call InsertLamp(gobjNewMethod.InstrumentCondition.TurretNumber)
                    'gobjNewMethod.InstrumentCondition.ElementID = 0
                    'gobjMessageAdapter.ShowMessage("Insert " & gobjInst.ElementName & " Lamp in turret no " & gobjInst.Lamp_Position & " and click ok button ", "Method Load", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                Else
                    gobjNewMethod.InstrumentCondition.ElementID = 0
                End If
                objfrmInstPara.ShowDialog()
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

    Private Sub InsertLamp(ByVal TurretPosition As Integer)
        '=====================================================================
        ' Procedure Name        : InsertLamp
        ' Parameters Passed     : 
        ' Returns               : None
        ' Purpose               : To insert lamp 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Pankaj
        ' Created               : 25.05.07
        ' Revisions             : 
        '=====================================================================

        ''note:
        ''this is called for insert lamp.
        ''this will insert a selected lamp at passed turrert Num.
        Dim objWait As New CWaitCursor
        Dim objDtElement As New DataTable
        Dim objDtElementWvs As New DataTable
        Dim objfrmCookBook As New frmCookBook
        ''object for cookbook
        Dim objClsInstrumentParameters As clsInstrumentParameters
        Dim intRowCounter As Integer
        Dim dblWV As Double
        Dim nosteps As Int16
        Dim objLampPar As New AAS203Library.Instrument.ClsLampParameters
        Dim objwait1 As New CWaitCursor
        Dim intCount As Integer

        Try
            '---Getting Lamp No. ## for replacement .... Please Wait
            Call gobjMessageAdapter.ShowStatusMessageBox("Getting Lamp No. " & TurretPosition & " for replacement...Please Wait", "Lamp Replacement", EnumMessageType.Information, 0)
            Application.DoEvents()
            ''show a message and allow application to perfrom its panding work.
            If gfuncInit_Lamp_Par(objLampPar) = True Then
                ''get a info of lamp ,eg element of lamp etc.
                objLampPar.ElementName = gobjInst.Lamp.LampParametersCollection.item(TurretPosition - 1).ElementName
                ''get a element name
                objLampPar.Current = gobjInst.Lamp.LampParametersCollection.item(TurretPosition - 1).Current
                ''get a current
                objLampPar.AtomicNumber = gobjInst.Lamp.LampParametersCollection.item(TurretPosition - 1).AtomicNumber
                ''get a atomic num
                objLampPar.SlitWidth = gobjInst.Lamp.LampParametersCollection.item(TurretPosition - 1).SlitWidth
                ''get a slitwidth
                objLampPar.Wavelength = gobjInst.Lamp.LampParametersCollection.item(TurretPosition - 1).Wavelength
                ''get a wavelength.
            End If
            If gfuncSet_Lamp_Parameters(objLampPar, TurretPosition - 1) = True Then
                ''function for setting lamp at given turrert num.
                If gobjCommProtocol.gFuncTurret_Home() Then
                    ''first set a turrert at HOME position
                    nosteps = gfuncTurretStepsForLampTop(TurretPosition)
                    ''get a num of step for setting lamp to home.
                    If gobjCommProtocol.funcRotate_Steps_Tur_Clock(nosteps) Then
                        ''now rotated a turrert in clock wise direction with respect to step.

                        gobjMessageAdapter.CloseStatusMessageBox()
                        Application.DoEvents()
                        '---Insert Cu Lamp in turret No. 3 and click OK button                       
                        If gobjMessageAdapter.ShowMessage("Insert " & gobjNewMethod.InstrumentCondition.ElementName & " lamp in turret No. " & TurretPosition & " and click OK button", "Lamp Replacement", EnumMessageType.Information) Then
                            ''now prompt user for inserting a lamp.
                            Application.DoEvents()
                            Dim objwait2 As New CWaitCursor
                            '---Initializing .... Please Wait
                            Application.DoEvents()
                            gobjMessageAdapter.ShowStatusMessageBox("Initializing .... Please Wait", "Lamp Replacement", EnumMessageType.Information, 0)
                            Application.DoEvents()
                            ''allow application to perfrom its panding work
                            gobjCommProtocol.gFuncTurret_Home()
                            ''get a turrert at HOME position.
                            'mintLatestTurretPosition = TurretPosition 'objClsInstrumentParameters.TurretNumber
                            gfuncLamp_connected(TurretPosition)
                            ''check for a lamp connection
                            gobjMessageAdapter.CloseStatusMessageBox()
                            Application.DoEvents()
                            'funcInitiliaze_Lamps()
                            'RaiseEvent LampReplaced()
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
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    'Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : btnDelete_Click
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : To delete the selected method
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Deepak Bhati
    '    ' Created               : 30.10.06
    '    ' Revisions             : 
    '    '=====================================================================
    '    Dim objWait As New CWaitCursor
    '    Dim intCounter As Integer
    '    Dim objRow As DataRow
    '    Dim objDtMethodNames As New DataTable

    '    Try

    '        If gobjMessageAdapter.ShowMessage(constWantToDelete) = True Then
    '            Application.DoEvents()

    '            For intCounter = gobjMethodCollection.Count - 1 To 0 Step -1
    '                If gobjMethodCollection.item(intCounter).MethodID = SelectedMethodID Then
    '                    gobjMethodCollection.RemoveAt(intCounter)
    '                    Exit For
    '                End If
    '            Next

    '            If funcSaveAllMethods(gobjMethodCollection) Then   'funcSerialize(ConstMethodsFileName, gobjMethodCollection) = True Then
    '                RemoveHandler lstMethodName.SelectedIndexChanged, AddressOf lstMethodName_SelectedIndexChanged
    '                If funcLoadMethods() = True Then
    '                    objDtMethodNames.Columns.Add(ConstColumnMethodID)
    '                    objDtMethodNames.Columns.Add(ConstColumnMethodName)
    '                    For intCounter = 0 To gobjMethodCollection.Count - 1
    '                        objRow = objDtMethodNames.NewRow
    '                        objRow.Item(ConstColumnMethodID) = gobjMethodCollection.item(intCounter).MethodID
    '                        objRow.Item(ConstColumnMethodName) = gobjMethodCollection.item(intCounter).MethodName
    '                        objDtMethodNames.Rows.Add(objRow)
    '                    Next
    '                    lstMethodName.DataSource = objDtMethodNames
    '                    lstMethodName.DisplayMember = ConstColumnMethodName
    '                    lstMethodName.ValueMember = ConstColumnMethodID
    '                End If

    '                lstMethodName_SelectedIndexChanged(sender, e)
    '                AddHandler lstMethodName.SelectedIndexChanged, AddressOf lstMethodName_SelectedIndexChanged
    '                funcLoadElementsList()
    '                IsShowByMethod = True
    '                gobjMessageAdapter.ShowMessage(constDeleteConfirmation)
    '                lstMethodName.Refresh()
    '                Application.DoEvents()

    '            End If
    '        End If

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        If Not objWait Is Nothing Then
    '            objWait.Dispose()
    '        End If
    '        '---------------------------------------------------------
    '    End Try
    'End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnCancel_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To send dialog result as cancel
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 07.10.06
        ' Revisions             : 
        '=====================================================================
        Try
            ''note:
            ''this is called when user clicled on cancel button.
            RemoveHandler lstElements.SelectedIndexChanged, AddressOf lstElements_SelectedIndexChanged
            RemoveHandler lstMethodName.SelectedIndexChanged, AddressOf lstMethodName_SelectedIndexChanged
            RemoveHandler rbMethodName.CheckedChanged, AddressOf rbMethodName_CheckedChanged

            Me.DialogResult = DialogResult.Cancel
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

    Private Function funcLoadElementsList() As Boolean
        '=====================================================================
        ' Procedure Name        : funcLoadElementsList
        ' Parameters Passed     : None
        ' Returns               : True or False
        ' Purpose               : To load the elements list
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 11.10.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this is called for loading a element list 
        ''from datastructure
        Dim intCount As Integer
        Dim intCounter As Integer
        Dim intEleID As Integer
        Dim strEleName As String
        Dim objDtElement As DataTable
        Dim objDtShowElements As DataTable
        Dim blnIsUnique As Boolean = True
        Dim DtRow As DataRow
        Try
            RemoveHandler lstElements.SelectedIndexChanged, AddressOf lstElements_SelectedIndexChanged

            'If gobjMethodCollection.Count > 0 Then
            '    If gobjMethodCollection.item(0).OperationMode = EnumOperationMode.MODE_UVABS Or _
            '       gobjMethodCollection.item(0).OperationMode = EnumOperationMode.MODE_UVSPECT Then
            '        objDtElement = gobjClsAAS203.funcGetElement(200)
            '        objDtShowElements = objDtElement.Clone
            '    Else
            '        objDtElement = gobjClsAAS203.funcGetElement(gobjMethodCollection.item(0).InstrumentCondition.ElementID)
            '        objDtShowElements = objDtElement.Clone

            '    End If
            '    objDtElement.Clear()
            'End If

            'gobjNewMethod.InstrumentConditions(0).ElementID()

            'For intCount = 0 To gobjMethodCollection.Count - 1
            '    intEleID = gobjMethodCollection.item(intCount).InstrumentCondition.ElementID

            '    If objDtShowElements.Rows.Count > 0 Then
            '        For intCounter = 0 To objDtShowElements.Rows.Count - 1
            '            If objDtShowElements.Rows(intCounter).Item(ConstColumnElementID) = intEleID Then
            '                blnIsUnique = False
            '                'Exit For
            '            End If
            '        Next
            '    End If

            '    If blnIsUnique = True Then

            '        objDtElement = gobjClsAAS203.funcGetElement(intEleID)

            '        If Not objDtElement Is Nothing Then
            '            If objDtElement.Rows.Count > 0 Then

            '                objDtShowElements.ImportRow(objDtElement.Rows(0))

            '            End If
            '        End If
            '    End If
            '    blnIsUnique = True
            'Next

            Dim arr As New ArrayList
            blnIsUnique = True
            ''flag for checking unique
            For intCount = 0 To gobjMethodCollection.Count - 1
                ''make a counter up to a collection.
                intEleID = gobjMethodCollection.item(intCount).InstrumentCondition.ElementID
                ''get a elementID
                For intCounter = 0 To arr.Count - 1
                    If arr.Count > 0 Then
                        If intEleID = arr(intCounter) Then
                            ''check for unique elementID
                            blnIsUnique = False
                        End If
                    End If
                Next

                If blnIsUnique = True Then
                    arr.Add(intEleID)
                End If

                blnIsUnique = True
            Next

            'Dim blnIsClone As Boolean = False
            'For intCounter = 0 To arr.Count - 1
            '    objDtElement = gobjClsAAS203.funcGetElement(arr(intCounter))
            '    If Not objDtElement Is Nothing Then
            '        If blnIsClone = False Then
            '            objDtShowElements = objDtElement.Clone
            '            blnIsClone = True
            '        End If
            '        If objDtElement.Rows.Count Then
            '            objDtShowElements.ImportRow(objDtElement.Rows(0))
            '        End If
            '    End If
            'Next

            objDtElement = gobjClsAAS203.funcGetElement(1)
            ''Toget element details from cookBook
            If Not objDtElement Is Nothing Then
                objDtShowElements = objDtElement.Clone
                objDtShowElements.Clear()
            End If

            For intCounter = 0 To arr.Count - 1
                objDtElement = gobjClsAAS203.funcGetElement(arr(intCounter))
                ''Toget element details from cookBook
                If Not objDtElement Is Nothing Then
                    If objDtElement.Rows.Count > 0 Then
                        objDtShowElements.ImportRow(objDtElement.Rows(0))
                    End If
                End If
            Next


            If Not IsNothing(objDtShowElements) Then
                If objDtShowElements.Rows.Count > 0 Then
                    ''show a info on element list
                    lstElements.DataSource = objDtShowElements
                    ''connect to temp datasource.
                    lstElements.DisplayMember = ConstColumnElementName
                    ''get a element name
                    lstElements.ValueMember = ConstColumnElementID
                    SelectedElementID = lstElements.SelectedValue
                Else
                    lstElements.DataSource = Nothing
                    txtElement.Text = ""
                End If
            Else
                lstElements.DataSource = Nothing
                txtElement.Text = ""
            End If

            AddHandler lstElements.SelectedIndexChanged, AddressOf lstElements_SelectedIndexChanged

            Return True
            ''return true if succed.
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

    Private Sub lstElements_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : lstElements_SelectedIndexChanged
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To set the property selectedElementID
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 11.10.06
        ' Revisions             : 
        '=====================================================================
        Try
            ''note:
            ''this will get a element id as par "element combo box"  selected. 
            SelectedElementID = lstElements.SelectedValue

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

    Private Sub chkAAQuant_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : chkAAQuant_CheckedChanged
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To enable and disable ok button
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 11.10.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''here we are doing some on screen validation for AA quan mode
        ''for eg OK button should be disable.
        Dim objDtMethodNames As New DataTable
        Dim intCounter As Integer
        Dim objRow As DataRow
        Try
            'btnOk.Enabled = chkAAQuant.Checked

            Dim arrFilters As New ArrayList
            arrFilters = funcGetSelectedFilterOptions()
            ''get selected filter option in a array
            If Not arrFilters Is Nothing Then
                funcFilterMethods(arrFilters)
                ''filter a method as per selected filter option.
            End If

            If lstMethodName.Items.Count = 0 Then
                ''if there is no item then
                btnOk.Enabled = False
                btnDelete.Enabled = False
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

    Private Function funcFilterMethods(ByVal ArrOperationMode As ArrayList) As Boolean
        '=====================================================================
        ' Procedure Name        : funcFilterMethods
        ' Parameters Passed     : ArrayList
        ' Returns               : True or False
        ' Purpose               : To filter method listing according to the selected criteria.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 12.10.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this is used for flter a method as per selected filter option.
        Dim objDtMethodNames As New DataTable
        Dim intCounter As Integer
        Dim objRow As DataRow
        Dim intCount As Integer
        Dim blnMatch As Boolean = False

        Try
            RemoveHandler lstMethodName.SelectedIndexChanged, AddressOf lstMethodName_SelectedIndexChanged

            objDtMethodNames.Columns.Add(ConstColumnMethodID)
            objDtMethodNames.Columns.Add(ConstColumnMethodName)
            ''make a datasource for datagrid.

            For intCounter = 0 To gobjMethodCollection.Count - 1
                For intCount = 0 To ArrOperationMode.Count - 1
                    ''make a counter up to a last filter option.
                    If Not rbMethodName.Checked Then
                        If gobjMethodCollection.item(intCounter).InstrumentCondition.ElementID = SelectedElementID Then
                            If gobjMethodCollection.item(intCounter).OperationMode = ArrOperationMode(intCount) Then
                                blnMatch = True
                                Exit For
                            End If
                        Else
                        End If
                    Else
                        If gobjMethodCollection.item(intCounter).OperationMode = ArrOperationMode(intCount) Then
                            blnMatch = True
                            Exit For
                        End If
                    End If

                Next
                If blnMatch = True Then
                    objRow = objDtMethodNames.NewRow
                    objRow.Item(ConstColumnMethodID) = gobjMethodCollection.item(intCounter).MethodID
                    objRow.Item(ConstColumnMethodName) = gobjMethodCollection.item(intCounter).MethodName
                    objDtMethodNames.Rows.Add(objRow)
                End If
                blnMatch = False

            Next intCounter

            RemoveHandler lstMethodName.SelectedIndexChanged, AddressOf lstMethodName_SelectedIndexChanged

            lstMethodName.DataSource = objDtMethodNames
            lstMethodName.DisplayMember = ConstColumnMethodName
            lstMethodName.ValueMember = ConstColumnMethodID
            lstMethodName.Refresh()
            ''bind a elementlist box with data source.

            If Not rbElementName.Checked Then
                ''check whatever method is shown by element name or method ID
                If IsShowByMethod = True Then
                    SelectedMethodID = lstMethodName.SelectedValue
                    ''get a selected method ID
                Else
                    SelectedElementID = lstElements.SelectedValue
                    ''get a selected element ID
                End If
            End If

            Return True
            ''return a true if succed.

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
            AddHandler lstMethodName.SelectedIndexChanged, AddressOf lstMethodName_SelectedIndexChanged
            Application.DoEvents()
            ''allow application to perfrom its panding work.
            '---------------------------------------------------------
        End Try
    End Function

    Private Sub OperationMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : OperationMode_CheckedChanged
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To filter method listing
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 12.10.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this is used to filter the element as par a operation mode.
        Dim arrFilters As New ArrayList
        Try
            arrFilters = funcGetSelectedFilterOptions()
            ''get all filter option in an array
            If Not arrFilters Is Nothing Then
                funcFilterMethods(arrFilters)
                ''filter method as per filter option.
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

    Private Function funcGetSelectedFilterOptions() As ArrayList
        '=====================================================================
        ' Procedure Name        : funcGetSelectedFilterOptions
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To return the filter critetia
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 12.10.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this will first checked all selected option.
        ''store it in array
        ''and return this array ,then this is used in rest application.

        Dim blnAAQuant, blnAABGC, blnUV, blnEmission As Boolean
        Dim arrMode As New ArrayList
        Try
            'If lstMethodName.Items.Count = 0 Then
            '    btnOk.Enabled = False
            'End If
            blnAAQuant = chkAAQuant.Checked
            blnAABGC = chkAABGCQuant.Checked
            blnUV = chkUVABS.Checked
            blnEmission = chkEmission.Checked
            If blnAAQuant = True Then
                ''add mode as per filter option
                arrMode.Add(EnumOperationMode.MODE_AA)
            End If
            If blnAABGC = True Then
                '' add AABGC mode
                arrMode.Add(EnumOperationMode.MODE_AABGC)
            End If

            If blnUV = True Then
                ''add UV mode.
                arrMode.Add(EnumOperationMode.MODE_UVABS)
            End If
            If blnEmission = True Then
                ''add emission mode.
                arrMode.Add(EnumOperationMode.MODE_EMMISSION)
            End If

            If chkAAQuant.Checked = False Then
                ''check for AAQuant
                If chkAABGCQuant.Checked = False Then
                    If blnUV = False Then
                        If blnEmission = False Then
                            btnOk.Enabled = False
                            btnDelete.Enabled = False
                            txtElement.Text = ""
                            txtOperationMode.Text = ""
                            txtMethodComments.Text = ""
                            lstMethodInformation.Items.Clear()
                        Else
                            btnOk.Enabled = True
                            btnDelete.Enabled = True
                        End If
                    Else
                        btnOk.Enabled = True
                        btnDelete.Enabled = True
                    End If
                Else
                    btnOk.Enabled = True
                    btnDelete.Enabled = True
                End If
            ElseIf blnAAQuant = True Or blnAABGC = True Or blnUV = True Or blnEmission = True Then
                btnOk.Enabled = True
                btnDelete.Enabled = True
            End If

            If lstMethodName.Items.Count = 0 Then
                '''if null data then.
                btnOk.Enabled = False
                btnDelete.Enabled = False
                txtElement.Text = ""
                txtOperationMode.Text = ""
                txtMethodComments.Text = ""
                lstMethodInformation.Items.Clear()
            End If

            Return arrMode
            ''return a array with selected option.
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

    Private Sub lstMethodName_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstMethodName.DoubleClick
        '=====================================================================
        ' Procedure Name        : lstMethodName_DoubleClick
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the selected method on double click 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S.
        ' Created               : 10.11.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this is a event ,which called when user double click on methodname
        Try
            If lstMethodName.Items.Count = 0 Then
                ''if there is no data then
                Exit Sub
            End If
            Dim intCounter As Integer
            For intCounter = 0 To gobjMethodCollection.Count - 1
                ''make a counter up to a collection
                If gobjMethodCollection.item(intCounter).MethodID = SelectedMethodID Then
                    ''match a MethodID
                    gobjNewMethod = gobjMethodCollection.item(intCounter).Clone
                    '''make a clone for a object gobjNewMethod 
                    Exit For
                End If
            Next

            Me.DialogResult = DialogResult.OK
            RaiseEvent LoadMethod(gobjNewMethod)
            ''event for loadind method.


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

    Private Sub rbMethodName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMethodName.Click
        '=====================================================================
        ' Procedure Name        : rbMethodName_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : handle a event.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S.
        ' Created               : 10.11.06
        ' Revisions             : 
        '=====================================================================
        'Added By Pankaj 11 May 07
        rbMethodName_CheckedChanged2(sender, e)
    End Sub

    Private Sub rbElementName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbElementName.Click
        '=====================================================================
        ' Procedure Name        : rbElementName_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : handle a event.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S.
        ' Created               : 10.11.06
        ' Revisions             : 
        '=====================================================================
        'Added By Pankaj 11 May 07
        rbMethodName_CheckedChanged2(sender, e)
    End Sub

#End Region

End Class

